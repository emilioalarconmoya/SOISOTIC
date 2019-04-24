Imports Modulos
Imports system.Data
Imports System.Data.OleDb
'Objeto que verifica la conexión de un usuario (User, Class)
Namespace Clases
    Public Class CSession
        'variables
        Private mlngLogin As Long 'Rut
        Private mstrPass As String 'No debe ser pública,password del usuario
        Private mstrNombre As String   'nombres del usuario
        Private mstrEmail As String   'email del usuario
        Private mlngRut As Long 'Rut Usuario
        Private mlngRutCliente As Long 'Rut de la empresa 
        Private mstrRazonSocial As String 'Razon social usuario
        Private mstrDireccion As String 'Direccion usuario
        Private mstrFono As String 'Fono usuario
        Private mstrFax As String 'Fax usuario
        Private mblnConectado As Boolean  'indica si algun usuario esta conectado
        Private mobjCsql As CSql 'Cada objeto usará su csql
        Private mintAgno As Integer ' Indicara el año que se selecione para las consultas
        Private mbolInfoConsolidada As Boolean ' Indica si la informacion se presenta en forma consolidada
        Private mlngRutHolding As Long


        'Datos del ejecutivo
        Private mlngRutEjecutivo As Long 'Rut ejecutivo
        Private mstrNombreEjecutivo As String 'Nombre ejecutivo
        Private mstrFonoEjecutivo As String 'Fono ejecutivo 
        Private mstrFaxEjecutivo As String 'Fax ejecutivo
        Private mstrEmailEjecutivo As String 'Email ejecutivo
        Private mstrcargoEjecutivo As String 'cargo ejecutivo
        Private mstrEmailEmpresa As String



        'Filas
        Private mlngFilas As Long

        'perfiles indexados por el cod_perfil con valores true o false
        'OJO, el 0 no se usa
        Private marrPerfiles(16) As Boolean
        Private mdtObjetos As DataTable

        'metodos de usuario
        Public Property Login() As Long
            Get
                Return mlngLogin
            End Get
            Set(ByVal value As Long)
                mlngLogin = value
            End Set
        End Property
        Public Property RutHolding() As Long
            Get
                Return mlngRutHolding
            End Get
            Set(ByVal value As Long)
                mlngRutHolding = value
            End Set
        End Property
        Public ReadOnly Property Conectado() As Boolean
            Get
                Return mblnConectado
            End Get
        End Property
        'cod_perfil nombre                                                           
        '---------- ---------------------------------------------------------------- 
        '1          Administrador
        '2          Cliente
        '3          Ejecutivo
        '4          Supervisor
        '5          Operaciones
        '6          Finanzas
        '7          Gestion
        '8          Director sucursal
        '9          Noticias Portal
        '10         Director
        '11         Ejecutivo Reg Ingreso/Modif
        '12         Ejecutivo Autorización
        '13         Finanzas Regiones
        '14         Operaciones Cambio Estado
        Public ReadOnly Property EsAdmin() As Boolean
            Get
                Return marrPerfiles(1)
            End Get
        End Property
        Public ReadOnly Property EsCliente() As Boolean
            Get
                Return marrPerfiles(2)
            End Get
        End Property
        Public ReadOnly Property EsEjecutivo() As Boolean
            Get
                Return marrPerfiles(3)
            End Get
        End Property
        Public ReadOnly Property EsSupervisor() As Boolean
            Get
                Return marrPerfiles(4)
            End Get
        End Property
        Public ReadOnly Property EsOperaciones() As Boolean
            Get
                Return marrPerfiles(5)
            End Get
        End Property
        Public ReadOnly Property EsFinanzas() As Boolean
            Get
                Return marrPerfiles(6)
            End Get
        End Property


        Public ReadOnly Property EsGestion() As Boolean
            Get
                Return marrPerfiles(7)
            End Get
        End Property
        Public ReadOnly Property EsDirectorSucursal() As Boolean
            Get
                Return marrPerfiles(8)
            End Get
        End Property
        Public ReadOnly Property EsNoticiasPortal() As Boolean
            Get
                Return marrPerfiles(9)
            End Get
        End Property
        Public ReadOnly Property EsDirector() As Boolean
            Get
                Return marrPerfiles(10)
            End Get
        End Property
        Public ReadOnly Property EsEjecutivoReg() As Boolean
            Get
                Return marrPerfiles(11)
            End Get
        End Property
        Public ReadOnly Property EsEjecutivoAutorizacion() As Boolean
            Get
                Return marrPerfiles(12)
            End Get
        End Property
        Public ReadOnly Property EsFinanzaRegiones() As Boolean
            Get
                Return marrPerfiles(13)
            End Get
        End Property
        Public ReadOnly Property EsOperacionesCambioEstado() As Boolean
            Get
                Return marrPerfiles(14)
            End Get
        End Property
        Public ReadOnly Property EsClienteIngresoCurso() As Boolean
            Get
                Return marrPerfiles(15)
            End Get
        End Property
        Public ReadOnly Property EsOperaciones2() As Boolean
            Get
                Return marrPerfiles(16)
            End Get
        End Property
        Public ReadOnly Property Nombre() As String
            Get
                Return mstrNombre
            End Get
        End Property
        Public ReadOnly Property Email() As String
            Get
                Return Me.mstrEmail
            End Get
        End Property
        Public Property Rut() As Long
            Get
                Return Me.mlngRut
            End Get
            Set(ByVal value As Long)
                mlngRut = value
            End Set
        End Property
        Public Property RutCliente() As Long
            Get
                Return Me.mlngRutCliente
            End Get
            Set(ByVal value As Long)
                mlngRutCliente = value
            End Set
        End Property
        Public ReadOnly Property RazonSocial() As String
            Get
                Return Me.mstrRazonSocial
            End Get
        End Property
        Public ReadOnly Property Direccion() As String
            Get
                Return Me.mstrDireccion
            End Get
        End Property
        Public ReadOnly Property Fono() As String
            Get
                Return Me.mstrFono
            End Get
        End Property
        Public ReadOnly Property Fax() As String
            Get
                Return Me.mstrFax
            End Get
        End Property
        Public ReadOnly Property EmailEmpresa() As String
            Get
                Return Me.mstrEmailEmpresa
            End Get
        End Property
        Public Property RutEjecutivo() As Long
            Get
                Return Me.mlngRutEjecutivo
            End Get
            Set(ByVal value As Long)
                mlngRutEjecutivo = value
            End Set
        End Property
        Public ReadOnly Property NombreEjecutivo() As String
            Get
                Return Me.mstrNombreEjecutivo
            End Get
        End Property
        Public ReadOnly Property FonoEjecutivo() As String
            Get
                Return Me.mstrFonoEjecutivo
            End Get
        End Property
        Public ReadOnly Property FaxEjecutivo() As String
            Get
                Return Me.mstrFaxEjecutivo
            End Get
        End Property
        Public ReadOnly Property EmailEjecutivo() As String
            Get
                Return Me.mstrEmailEjecutivo
            End Get
        End Property
        Public ReadOnly Property CargoEjecutivo() As String
            Get
                Return mstrcargoEjecutivo
            End Get
        End Property
        Public Property Agno() As Integer
            Get
                Return mintAgno
            End Get
            Set(ByVal value As Integer)
                mintAgno = value
            End Set
        End Property
        Public Property InfoConsolidada() As Boolean
            Get
                Return mbolInfoConsolidada
            End Get
            Set(ByVal value As Boolean)
                mbolInfoConsolidada = value
            End Set
        End Property
        'Setea a true si la clave es correcta
        Public Function ChequearClave(ByVal strLogin As String, ByVal strPass As String) As Boolean
            Try
                Dim dtTablaTemp As DataTable
                Dim row As DataRow
                Dim arrSiEsRut As Array

                InicializaNuevo() 'limpia todo
                arrSiEsRut = Split(strLogin, "-")
                mlngLogin = RutUsrALng(strLogin)
                mobjCsql = New CSql
                If strLogin.Contains("-") Then 'Entra como Rut
                    If IsNumeric(strLogin) Then 'Si tiene formato de rut sin el guion
                        If digito_verificador(Left(strLogin, strLogin.Length - 1)).Trim.ToUpper = Right(strLogin, 1).Trim.ToUpper Then
                            'corresponde el dig. verificador? SI
                            dtTablaTemp = mobjCsql.s_usuario(Left(strLogin, strLogin.Length - 1))
                        Else 'NO
                            ChequearClave = False
                            mblnConectado = False
                            Exit Function
                        End If
                    ElseIf arrSiEsRut.Length = 2 And IsNumeric(arrSiEsRut(0)) Then  'Si tiene formato de rut con el guion
                        mlngLogin = CLng(arrSiEsRut(0))
                        If Not (digito_verificador(mlngLogin).Trim.ToUpper = arrSiEsRut(1).ToString.Trim.ToUpper) Then 'Si el dig. verif no corresponde
                            ChequearClave = False
                            mblnConectado = False
                            Exit Function
                        End If
                    End If
                End If
                dtTablaTemp = mobjCsql.s_usuario(mlngLogin)
                If mobjCsql.Registros <= 0 Then
                    ChequearClave = False
                    mblnConectado = False
                    Exit Function
                End If

                If DecryptINI$(dtTablaTemp.Rows(0)("passwd_enc")) = strPass Then
                    'Datos del usuario para login
                    ChequearClave = True
                    Me.mblnConectado = True
                    Me.mlngRut = dtTablaTemp.Rows(0)("rut")
                    Me.mstrNombre = dtTablaTemp.Rows(0)("nombres")
                    Me.mstrPass = DecryptINI$(dtTablaTemp.Rows(0)("passwd_enc"))
                    Me.mstrEmail = dtTablaTemp.Rows(0)("email")
                    Me.mstrFono = dtTablaTemp.Rows(0)("telefono")
                    Me.mstrFax = dtTablaTemp.Rows(0)("fax")

                Else
                    ChequearClave = False
                    mblnConectado = False
                End If

                If mblnConectado Then
                    dtTablaTemp = mobjCsql.s_perfil(mlngLogin)
                    If Not dtTablaTemp Is Nothing Then
                        For Each row In dtTablaTemp.Rows
                            'Deja en true los perfiles
                            marrPerfiles(CInt(row("cod_perfil"))) = True
                        Next
                    End If
                End If

                If Me.EsCliente Then
                    'Datos del ejecutivo (si es cliente)
                    Me.CargaEjecutivoEmpresa(mlngRut)
                End If


                'Libera
                If Not dtTablaTemp Is Nothing Then
                    dtTablaTemp.Dispose()
                End If
                Me.mintAgno = Now.Year
                mobjCsql = Nothing
            Catch ex As Exception
                Call EnviaError("CSession:ChequearClave->" & ex.Message)
            End Try
        End Function
        'Setea a true si la clave es correcta
        Public Function ChequearCliente(ByVal strRut As String) As Boolean
            Try
                Dim dtTablaTemp As DataTable
                Dim row As DataRow
                Dim arrSiEsRut As Array

                'InicializaNuevo() 'limpia todo
                arrSiEsRut = Split(strRut, "-")
                mlngLogin = RutUsrALng(strRut)
                mobjCsql = New CSql
                If strRut.Contains("-") Then 'Entra como Rut
                    If IsNumeric(strRut) Then 'Si tiene formato de rut sin el guion
                        If digito_verificador(Left(strRut, strRut.Length - 1)).Trim.ToUpper = Right(strRut, 1).Trim.ToUpper Then
                            'corresponde el dig. verificador? SI
                            dtTablaTemp = mobjCsql.s_usuario(Left(strRut, strRut.Length - 1))
                        Else 'NO
                            ChequearCliente = False
                            mblnConectado = False
                            Exit Function
                        End If
                    ElseIf arrSiEsRut.Length = 2 And IsNumeric(arrSiEsRut(0)) Then  'Si tiene formato de rut con el guion
                        mlngLogin = CLng(arrSiEsRut(0))
                        If Not (digito_verificador(mlngLogin).Trim.ToUpper = arrSiEsRut(1).ToString.Trim.ToUpper) Then 'Si el dig. verif no corresponde
                            ChequearCliente = False
                            mblnConectado = False
                            Exit Function
                        End If
                    End If
                End If
                dtTablaTemp = mobjCsql.s_usuario(mlngLogin)
                If mobjCsql.Registros <= 0 Then
                    ChequearCliente = False
                    mblnConectado = False
                    Exit Function
                Else
                    Me.mlngRutCliente = dtTablaTemp.Rows(0)("rut")
                    Me.mlngRut = dtTablaTemp.Rows(0)("rut")
                    Me.mstrNombre = dtTablaTemp.Rows(0)("nombres")
                    Me.mstrPass = DecryptINI$(dtTablaTemp.Rows(0)("passwd_enc"))
                    Me.mstrEmail = dtTablaTemp.Rows(0)("email")
                    Me.mstrFono = dtTablaTemp.Rows(0)("telefono")
                    Me.mstrFax = dtTablaTemp.Rows(0)("fax")
                End If
                mblnConectado = True
                ChequearCliente = True
                'If DecryptINI$(dtTablaTemp.Rows(0)("passwd_enc")) = strPass Then
                '    'Datos del usuario para login
                '    ChequearClave = True
                '    Me.mblnConectado = True
                '    Me.mlngRut = dtTablaTemp.Rows(0)("rut")
                '    Me.mstrNombre = dtTablaTemp.Rows(0)("nombres")
                '    Me.mstrPass = DecryptINI$(dtTablaTemp.Rows(0)("passwd_enc"))
                '    Me.mstrEmail = dtTablaTemp.Rows(0)("email")
                '    Me.mstrFono = dtTablaTemp.Rows(0)("telefono")
                '    Me.mstrFax = dtTablaTemp.Rows(0)("fax")

                'Else
                '    ChequearClave = False
                '    mblnConectado = False
                'End If

                If mblnConectado Then
                    dtTablaTemp = mobjCsql.s_perfil(mlngLogin)
                    If Not dtTablaTemp Is Nothing Then
                        For Each row In dtTablaTemp.Rows
                            'Deja en true los perfiles
                            marrPerfiles(CInt(row("cod_perfil"))) = True
                        Next
                    End If
                End If

                If Me.EsCliente Then
                    'Datos del ejecutivo (si es cliente)
                    Me.CargaEjecutivoEmpresa(mlngRutCliente)
                End If


                'Libera
                If Not dtTablaTemp Is Nothing Then
                    dtTablaTemp.Dispose()
                End If
                'Me.mintAgno = Now.Year
                mobjCsql = Nothing
            Catch ex As Exception
                Call EnviaError("CSession:ChequearClave->" & ex.Message)
            End Try
        End Function
        Public Sub CargaEjecutivoEmpresa(ByVal lngRut As Long)
            Dim dtconsulta As DataTable
            Try
                If mobjCsql Is Nothing Then
                    mobjCsql = New CSql
                End If
                dtconsulta = mobjCsql.s_ejecutivo_empresa(lngRut)
                Me.mlngFilas = Me.mobjCsql.Registros
                If Me.mlngFilas > 0 Then
                    mstrRazonSocial = dtconsulta.Rows(0)("nombre_empresa").ToString
                    mstrDireccion = dtconsulta.Rows(0)("direccion").ToString
                    mstrFono = dtconsulta.Rows(0)("fono").ToString
                    mstrFax = dtconsulta.Rows(0)("fax").ToString
                    mstrNombreEjecutivo = dtconsulta.Rows(0)("nombre_ejecutivo").ToString
                    mstrEmailEjecutivo = dtconsulta.Rows(0)("cargo_contacto").ToString
                    mstrFonoEjecutivo = dtconsulta.Rows(0)("telefono").ToString
                    mstrFaxEjecutivo = dtconsulta.Rows(0)("fax_ejecutivo").ToString
                    mstrEmailEjecutivo = dtconsulta.Rows(0)("email").ToString
                    mlngRutCliente = lngRut
                End If

                dtconsulta.Dispose()
                dtconsulta = Nothing

            Catch ex As Exception
                Call EnviaError("CSession:CargaEjecutivo->" & ex.Message)
            End Try
        End Sub



        Public Function AccesoObjeto(ByVal intCodObjeto As Integer) As Boolean
            If mdtObjetos Is Nothing Or intCodObjeto = 0 Then
                Return True
            End If

            Dim intObj As Integer
            For Each intObj In Me.mdtObjetos.Rows
                If intObj = intCodObjeto Then
                    Return True
                    Exit Function
                End If
            Next
            'Si no encontró el objeto, devuelve false, no tiene permiso para acceder
            Return False
        End Function

        Public Sub New()
            InicializaNuevo()
        End Sub
        Private Sub InicializaNuevo()
            mlngLogin = 0
            mstrPass = ""
            mstrNombre = ""
            mblnConectado = False
            mbolInfoConsolidada = False
            Dim i As Integer

            For i = 1 To 2
                'llena con false todos los perfiles, OJO el indice 0 no se usa
                Me.marrPerfiles(i) = False
            Next
        End Sub

        Protected Overrides Sub Finalize()
            mobjCsql = Nothing
            MyBase.Finalize()
        End Sub
        Public Function TienePermiso(ByVal lngNroPerfil As Long, ByVal strAccion As String) As Boolean
            Dim arrPerfiles As Object
            'Posiciones en el arreglo:
            'Posición 1 -> Administrador
            'Posición 2 -> Cliente
            'Posición 3 -> Ejecutivo
            'Posición 4 -> Supervisor
            'Posición 5 -> Operaciones
            'Posicion 6 -> Ejecutivo Reg Ing/Mod
            'Posicion 7 -> Ejecutivo Reg AUT
            'Posicion 8 -> Operaciones Cambio de estado, puede cambiar estado de curso de liq. a ingresado
            arrPerfiles = Decodifica(lngNroPerfil)
            'Accion = Ing -> Ingresar
            'Accion = Mod -> Modificar
            'Accion = Eli -> Eliminar
            'Accion = Aut -> Autorizar/Rechazar
            'Accion = Com -> Comunicar
            'Accion = Liq -> Liquidar
            'Accion = Anu -> Anular
            'Accion = Mdc -> Modificar después de comunicado
            'Accion = Ces -> Cambia Estado de liquidado a ingresado

            'Cambio de estado de curso de liq a ingresado
            If strAccion = "Ces" Then
                If arrPerfiles(8) = 1 Then
                    TienePermiso = True
                    Exit Function
                End If
            End If


            If strAccion = "Mod" Then
                If arrPerfiles(2) = 1 Or arrPerfiles(5) = 1 Or arrPerfiles(4) = 1 Or arrPerfiles(6) = 1 Or arrPerfiles(9) = 1 Then
                    TienePermiso = True
                    Exit Function
                End If
            End If


            If strAccion = "Ing" Or strAccion = "Eli" Then
                If arrPerfiles(2) = 1 Or arrPerfiles(5) = 1 Or arrPerfiles(3) = 1 Or arrPerfiles(4) = 1 Or arrPerfiles(6) = 1 Then
                    TienePermiso = True
                    Exit Function
                End If
            End If
            If strAccion = "Aut" Then
                If arrPerfiles(3) = 1 Or arrPerfiles(4) = 1 Or arrPerfiles(7) = 1 Then
                    TienePermiso = True
                    Exit Function
                End If
            End If
            If strAccion = "Com" Or strAccion = "Liq" Or strAccion = "Anu" Or strAccion = "Mdc" Then
                If arrPerfiles(3) = 1 Or arrPerfiles(4) = 1 Or arrPerfiles(5) = 1 Then
                    TienePermiso = True
                    Exit Function
                End If
            End If
            TienePermiso = False
        End Function
        Public Function Decodifica(ByVal lngCodigo As Long) As Object
            Dim arrTemp(14) As Integer
            Dim resultado, i As Integer
            resultado = lngCodigo
            i = 0
            Do While resultado >= 2
                arrTemp(i) = resultado Mod 2
                resultado = resultado \ 2
                i = i + 1
            Loop
            arrTemp(i) = resultado
            Decodifica = arrTemp
        End Function
        Public Function TieneHolding(ByVal lngRutCliente As Long) As Boolean
            Try
                mobjCsql = New CSql
                mlngRutHolding = mobjCsql.s_rut_holding(lngRutCliente)
                If mlngRutHolding > 0 Then
                    TieneHolding = True
                Else
                    TieneHolding = False
                End If
            Catch ex As Exception
                Call EnviaError("CSession:TieneHolding->" & ex.Message)
            End Try
        End Function
    End Class

End Namespace

