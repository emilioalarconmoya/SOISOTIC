Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CCargaTransaccion

#Region "declaracion"
    Private mobjCSql As New CSql
    Private mobjSqlExcel As New CSql

    Private mlngRutEmpresa As Long

    Public dtErrores As DataTable
    Private mdtMensajes As DataTable
    Private mstrMensaje As String

    Private mlngRutCliente As Long
    Private mintCodCuenta As Integer
    Private mintCodTipoTran As Integer
    Private mlngCodCurso As Long
    Private mintEstado As Integer
    Private mdtmFechaHora As Date
    Private mlngMonto As Long
    Private mstrDescripcion As String
    Private mlngCodAport As Long
    Private mlngCodTraspaso As Long
    Private mlngPorcAdm As Long
    Private mblnExiste As Boolean
#End Region
#Region "propiedades"

    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property CodCuenta() As Integer
        Get
            Return mintCodCuenta
        End Get
        Set(ByVal value As Integer)
            mintCodCuenta = value
        End Set
    End Property
    Public Property CodTipoTran() As Integer
        Get
            Return mintCodTipoTran
        End Get
        Set(ByVal value As Integer)
            mintCodTipoTran = value
        End Set
    End Property
    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
        End Set
    End Property
    Public Property Estado() As Integer
        Get
            Return mintEstado
        End Get
        Set(ByVal value As Integer)
            mintEstado = value
        End Set
    End Property
    Public Property FechaIngreso() As Date
        Get
            Return mdtmFechaHora
        End Get
        Set(ByVal value As Date)
            mdtmFechaHora = value
        End Set
    End Property
    Public Property Monto() As Long
        Get
            Return mlngMonto
        End Get
        Set(ByVal value As Long)
            mlngMonto = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return mstrDescripcion
        End Get
        Set(ByVal value As String)
            mstrDescripcion = value
        End Set
    End Property
    Public Property CodAporte() As Long
        Get
            Return mlngCodAport
        End Get
        Set(ByVal value As Long)
            mlngCodAport = value
        End Set
    End Property
    Public Property CodTraspaso() As Long
        Get
            Return mlngCodTraspaso
        End Get
        Set(ByVal value As Long)
            mlngCodTraspaso = value
        End Set
    End Property
    'Se le agregan registros
    Public ReadOnly Property Mensajes() As DataTable
        Get
            Return Me.mdtMensajes
        End Get
    End Property
    Public Property PorcAdm() As Long
        Get
            Return mlngPorcAdm
        End Get
        Set(ByVal value As Long)
            mlngPorcAdm = value
        End Set
    End Property
#End Region
    'inicialización del objeto vacío
    Function Inicializar()
        Try
            mlngRutCliente = 0
            mintCodCuenta = 0
            mintCodTipoTran = 0
            mlngCodCurso = 0
            mintEstado = 0
            mdtmFechaHora = FechaMinSistema()
            mlngMonto = 0
            mstrDescripcion = ""
            mlngCodAport = 0
            mlngCodTraspaso = 0
        Catch ex As Exception
            EnviaError("CCargaTransaccion:Inicializar-->" & ex.Message)
        End Try

    End Function

    Function GrabarDatos() As Boolean
        Try
            mobjCSql.i_transaccion(mlngRutCliente, mintCodCuenta, mintCodTipoTran, mintEstado, _
                               mlngMonto, mstrDescripcion, mlngCodCurso, mlngCodAport, mdtmFechaHora, mlngCodTraspaso)

            Return True
        Catch ex As Exception
            EnviaError("CCargaTransaccion:GrabarDatos-->" & ex.Message)
        End Try
    End Function
    Function grabardatos2() As Boolean
        Try
            mobjCSql.i_transaccion2(mlngRutCliente, mintCodCuenta, mintCodTipoTran, mintEstado, _
                           mlngMonto, mstrDescripcion, mlngCodCurso, mlngCodAport, mdtmFechaHora, mlngCodTraspaso)
        Catch ex As Exception
            EnviaError("CCargaTransaccion:grabardatos2-->" & ex.Message)
        End Try
    End Function
    Function PorcentajeAdn() As Long
        Try
            If mobjCSql.s_porc_admin(mlngRutCliente) > 0 Then
                PorcAdm = mobjCSql.s_porc_admin(mlngRutCliente)
            Else
                mstrMensaje = "La empresa no posee % de administracion,Verificar datos"
                EnvioErrores(mstrMensaje)
                Exit Function
            End If
            Return PorcAdm
        Catch ex As Exception
            EnviaError("CCargaTransaccion:PorcentajeAdn-->" & ex.Message)
        End Try
    End Function

    Public Function Cargar_Archivo(ByVal strRuta As String)
        Try
            mobjCSql = New CSql
            'mobjSqlExcel = New CSql
            Dim dtTemporal
            Dim dr

            mobjSqlExcel.MotorDb = "excel8"
            mobjSqlExcel.BD = strRuta

            dtTemporal = mobjSqlExcel.s_carga_hoja_excel_cabecera("[hoja1$]")
            If Not dtTemporal Is Nothing Then
                If dtTemporal.Columns.Count <> 4 Then
                    mstrMensaje = "Numero de columnas erróneas"
                    EnvioErrores(mstrMensaje)
                    Exit Function
                End If
            Else
                mstrMensaje = "El archivo cargado tiene errores"
                EnvioErrores(mstrMensaje)
                Exit Function
            End If

            mobjCSql.InicioTransaccion()

            For Each dr In dtTemporal.Rows
                If Not IsDBNull(dr(0)) Then
                    If EsRut(dr(0)) Then
                        mblnExiste = True
                        If mobjCSql.s_existe_cuenta_cliente(RutUsrALng(dr(0))) Then
                            mlngRutCliente = RutUsrALng(dr(0))
                        Else
                            mstrMensaje = "El rut es erroneo en la empresa con rut: " & dr(0)
                            EnvioErrores(mstrMensaje)
                            mblnExiste = False
                        End If
                    Else
                        mstrMensaje = "El rut es erroneo en la empresa con rut: " & dr(0)
                        EnvioErrores(mstrMensaje)
                        mobjCSql.RollBackTransaccion()
                        Exit Function
                    End If
                Else
                    mstrMensaje = "EL rut de la empresa esta vacio : "
                    EnvioErrores(mstrMensaje)
                    mobjCSql.RollBackTransaccion()
                    Exit Function
                End If
                If Not IsDBNull(dr(1)) Then
                    If dr(1) = 1 Or dr(1) = 2 Or dr(1) = 4 Or dr(1) = 5 Or dr(1) = 6 Or dr(1) = 3 Then
                        mintCodCuenta = dr(1)
                    Else
                        mstrMensaje = "EL codigo de cuenta no es valido en la empresa con rut: " & dr(0)
                        EnvioErrores(mstrMensaje)
                        mobjCSql.RollBackTransaccion()
                        Exit Function
                    End If
                Else
                    mstrMensaje = "EL codigo cuenta esta vacio en la empresa con rut: " & dr(0)
                    EnvioErrores(mstrMensaje)
                    mobjCSql.RollBackTransaccion()
                    Exit Function
                End If
                mintCodTipoTran = 4
                'If Not IsDBNull(dr(2)) Then
                '    If IsNumeric(dr(2)) Then
                '        If dr(2) = 6 Then
                '            mintCodTipoTran = dr(2)
                '        Else
                '            mstrMensaje = "EL tipo de transaccion no es valido en el correlativo: " & dr(2)
                '            EnvioErrores(mstrMensaje)
                '            Exit Function
                '        End If
                '    Else
                '        mstrMensaje = "Falta tipo de transaccion no es un valor numerico en el correlativo: " & dr(2)
                '        EnvioErrores(mstrMensaje)
                '        Exit Function
                '    End If

                'Else
                '    mstrMensaje = "EL tipo de transaccion esta vacio en el correlativo: " & dr(2)
                '    EnvioErrores(mstrMensaje)
                '    Exit Function
                'End If
                'If Not IsDBNull(dr(3)) Then
                '    If dr(3) = 0 Then
                '        mlngCodCurso = dr(3)
                '    Else
                '        mstrMensaje = "EL codigo debe ser 0 en el correlativo: " & dr(3)
                '        EnvioErrores(mstrMensaje)
                '        Exit Function
                '    End If
                'Else
                '    mlngCodCurso = 0
                'End If
                mlngCodCurso = 0
                'If Not IsDBNull(dr(4)) Then
                '    If IsNumeric(dr(4)) Then
                '        If dr(4) = 2 Then
                '            mintEstado = dr(4)
                '        Else
                '            mstrMensaje = "El codigo estado transaccion no es valido en el correlativo: " & dr(4)
                '            EnvioErrores(mstrMensaje)
                '            Exit Function
                '        End If
                '    Else
                '        mstrMensaje = "Falta codigo no es un valor numerico en el correlativo: " & dr(4)
                '        EnvioErrores(mstrMensaje)
                '        Exit Function
                '    End If
                'Else
                '    mstrMensaje = "EL codigo estado transaccion esta vacio en el correlativo: " & dr(4)
                '    EnvioErrores(mstrMensaje)
                '    Exit Function
                'End If
                mintEstado = 2
                'valida si no es nulo
                If Not IsDBNull(dr(3)) Then
                    'valida el formato fecha
                    If IsDate(dr(3)) Then
                        'valida que sea mayor a la fecha de hoy 
                        'if CDate(dr(3)) >= CDate(FechaVbAUsr(Now)) Then
                        'valida entre fecha minima y maxima del sistema
                        If CDate(dr(3)) > CDate(FechaMinSistema()) And CDate(dr(3)) < CDate(FechaMaxSistema()) Then
                            mdtmFechaHora = dr(3)
                        Else
                            mstrMensaje = "La fecha ingresada no se encuentra entre el rango en la empresa con rut: " & dr(0)
                            EnvioErrores(mstrMensaje)
                            mobjCSql.RollBackTransaccion()
                            Exit Function
                        End If
                        'Else
                        '    mstrMensaje = "La fecha ingresada no puede ser menor que la de hoy en la empresa con rut: " & dr(0)
                        '    EnvioErrores(mstrMensaje)
                        '    Exit Function
                        'End If
                    Else
                        mstrMensaje = "La fecha ingresada no tiene el formato correcto en la empresa con rut: " & dr(0)
                        EnvioErrores(mstrMensaje)
                        mobjCSql.RollBackTransaccion()
                        Exit Function
                    End If
                Else
                    mstrMensaje = "La fecha de ingreso de la transaccion esta vacia en la empresa con rut: " & dr(0)
                    EnvioErrores(mstrMensaje)
                    mobjCSql.RollBackTransaccion()
                    Exit Function
                End If

                If Not IsDBNull(dr(2)) Then
                    If IsNumeric(dr(2)) Then
                        'If dr(2) > 0 Then
                        mlngMonto = dr(2)
                        'Else
                        '    mstrMensaje = "El monto debe ser mayor a 0 en la empresa con rut: " & dr(0)
                        '    EnvioErrores(mstrMensaje)
                        '    mobjCSql.RollBackTransaccion()
                        '    Exit Function
                        'End If
                    Else
                        mstrMensaje = "El monto no es un valor numerico en la empresa con rut " & dr(0)
                        EnvioErrores(mstrMensaje)
                        mobjCSql.RollBackTransaccion()
                        Exit Function
                    End If
                Else
                    mstrMensaje = "EL monto a ingresar esta vacio en la empresa con rut: " & dr(0)
                    EnvioErrores(mstrMensaje)
                    mobjCSql.RollBackTransaccion()
                    Exit Function
                End If
                'If Not IsDBNull(dr(7)) Then
                '    mstrDescripcion = dr(7)
                'Else
                '    mstrDescripcion = "Carga de inicio"
                'End If
                'If Not IsDBNull(dr(8)) Then
                '    If dr(8) = 0 Then
                '        mlngCodAport = dr(8)
                '    Else
                '        mstrMensaje = "EL codigo aporte debe ser 0 en el correlativo: " & dr(9)
                '        EnvioErrores(mstrMensaje)
                '        Exit Function
                '    End If
                'Else
                '    mlngCodAport = 0
                'End If
                mstrDescripcion = "Carga de inicio"
                'If Not IsDBNull(dr(9)) Then
                '    If dr(9) = 0 Then
                '        mlngCodTraspaso = dr(9)
                '    Else
                '        mstrMensaje = "EL codigo traspaso debe ser 0 en el correlativo: " & dr(9)
                '        EnvioErrores(mstrMensaje)
                '        Exit Function
                '    End If
                'Else
                '    mlngCodTraspaso = 0
                'End If
                mlngCodTraspaso = 0
                'If mblnExiste Then
                '    '*********************
                '    Me.GrabarDatos()
                '    '*********************
                'End If
                'If dr(1) = 1 Or dr(1) = 2 Then
                '    'Dim mdblMontoAdm As Double
                '    'Dim mintTipoTransaccion As Double
                '    'PorcAdm = PorcentajeAdn()
                '    'mdblMontoAdm = ((PorcAdm * dr(2)) / (100 - PorcAdm))
                '    'mintTipoTransaccion = 3

                '    'If Not IsDBNull(mintTipoTransaccion) Then
                '    '    If mintTipoTransaccion = 3 Then

                '    '        mintCodCuenta = mintTipoTransaccion
                '    '    Else
                '    '        mstrMensaje = "EL codigo no es valido en la empresa con rut: " & dr(0)
                '    '        EnvioErrores(mstrMensaje)
                '    '        mobjCSql.RollBackTransaccion()
                '    '        Exit Function
                '    '    End If
                '    'Else
                '    '    mstrMensaje = "EL codigo cuenta esta vacio en la empresa con rut: " & dr(0)
                '    '    EnvioErrores(mstrMensaje)
                '    '    mobjCSql.RollBackTransaccion()
                '    '    Exit Function
                '    'End If


                '    If Not IsDBNull(mdblMontoAdm) Then
                '        If IsNumeric(mdblMontoAdm) Then
                '            'If mdblMontoAdm > 0 Then
                '            mlngMonto = mdblMontoAdm
                '            'Else
                '            '    mstrMensaje = "El monto debe ser mayor a 0 en la empresa con rut: " & dr(0)
                '            '    EnvioErrores(mstrMensaje)
                '            '    mobjCSql.RollBackTransaccion()
                '            '    Exit Function
                '            'End If
                '        Else
                '            mstrMensaje = "El monto no es un valor numerico en la empresa con rut: " & dr(0)
                '            EnvioErrores(mstrMensaje)
                '            mobjCSql.RollBackTransaccion()
                '            Exit Function
                '        End If
                '    Else
                '        mstrMensaje = "EL monto a ingresar esta vacio en la empresa con rut: " & dr(0)
                '        EnvioErrores(mstrMensaje)
                '        mobjCSql.RollBackTransaccion()
                '        Exit Function
                '    End If
                If mblnExiste Then
                    Me.grabardatos2()
                End If
                'End If

            Next

            'Call mobjCSql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
            '                                                        "Ingreso de carga Inicial Transaccion: ")
            mobjCSql.FinTransaccion()
            mstrMensaje = "se ingresaron datos exitosamente"
            EnvioErrores(mstrMensaje)
        Catch ex As Exception
            mobjCSql.RollBackTransaccion()
            EnviaError("CCargaTransaccion:cargar_archivos-->" & ex.Message)
        End Try
    End Function
    Public Sub EnvioErrores(ByVal strMensaje As String)
        Try
            Dim dr As DataRow
            mdtMensajes = New DataTable
            Me.mdtMensajes.Columns.Add(New DataColumn("log", GetType(String)))

            dr = mdtMensajes.NewRow()
            dr("log") = strMensaje
            mdtMensajes.Rows.Add(dr)
        Catch ex As Exception
            EnviaError("CCargaTransaccion:EnvioErrores-->" & ex.Message)
        End Try
    End Sub
End Class
