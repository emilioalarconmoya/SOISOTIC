Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteSolicitudes
    Implements IReporte
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean

    Private mlngRutCliente As Long   'rut beneficiado
    Private mintAgno As Integer
    Private mstrNombreBeneficiado As String
    Private mintCodigoSolicitudPago As Integer
    Private mlngCodCurso As Long
    Private mdtmFechaIngreso As Date
    Private mlngMontoSolicitud As Long
    Private mlnNumTransaccion As Long
    Private mlngCorrelativo As Long
    Private mdtmFechaInicio As Date
    Private mstrNombreBenefactor As String
    Private mlngRutBenefactor As Long
    Private mlngCostoOtic As Long
    Private mstrNombreCurso As String




    Private mdtSolicitudes As DataTable

    

    'rut del cliente que hizo el aporte
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public Property NombreBeneficiado() As String
        Get
            Return mstrNombreBeneficiado
        End Get
        Set(ByVal value As String)
            mstrNombreBeneficiado = value
        End Set
    End Property
    Public Property CodigoSolicitudPago() As Integer
        Get
            Return mintCodigoSolicitudPago
        End Get
        Set(ByVal value As Integer)
            mintCodigoSolicitudPago = value
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
    Public Property FechaIngreso() As Date
        Get
            Return mdtmFechaIngreso
        End Get
        Set(ByVal value As Date)
            mdtmFechaIngreso = value
        End Set
    End Property
    Public Property FechaInicio() As Date
        Get
            Return mdtmFechaInicio
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = value
        End Set
    End Property
    Public Property MontoSolicitud() As Long
        Get
            Return mlngMontoSolicitud
        End Get
        Set(ByVal value As Long)
            mlngMontoSolicitud = value
        End Set
    End Property
    Public Property NumTransaccion() As Long
        Get
            Return mlnNumTransaccion
        End Get
        Set(ByVal value As Long)
            mlnNumTransaccion = value
        End Set
    End Property
    Public Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    Public Property NombreBenefactor() As String
        Get
            Return mstrNombreBenefactor
        End Get
        Set(ByVal value As String)
            mstrNombreBenefactor = value
        End Set
    End Property
    Public Property RutBenefactor() As Long
        Get
            Return mlngRutBenefactor
        End Get
        Set(ByVal value As Long)
            mlngRutBenefactor = value
        End Set
    End Property
    Public Property CostoOtic() As Long
        Get
            Return mlngCostoOtic
        End Get
        Set(ByVal value As Long)
            mlngCostoOtic = value
        End Set
    End Property
    Public Property NombreCurso() As String
        Get
            Return mstrNombreCurso
        End Get
        Set(ByVal value As String)
            mstrNombreCurso = value
        End Set
    End Property
    Public ReadOnly Property Solicitudes() As DataTable
        Get
            Return mdtSolicitudes
        End Get
    End Property
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property
    'inicialización de variables
    Private Sub Initialize()
        mlngRutCliente = 0
    End Sub
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    ' Consulta
    '
    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim dtConsulta As DataTable
            Dim strNombreArchivo As String

            dtConsulta = mobjSql.s_solicitud_pago_ter_todos(mlngRutCliente, mlngCodCurso, mintAgno)
            Me.mlngFilas = Me.mobjSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow

                For Each dr In dtConsulta.Rows
                    If IsDBNull(dr("cod_solicitud_pago")) Then
                        mintCodigoSolicitudPago = 0
                    Else
                        mintCodigoSolicitudPago = dr("cod_solicitud_pago")
                    End If
                    If IsDBNull(dr("rut_benefactor")) Then
                        mlngRutBenefactor = 0
                    Else
                        mlngRutBenefactor = dr("rut_benefactor")
                    End If
                    If IsDBNull(dr("cod_curso")) Then
                        mlngCodCurso = 0
                    Else
                        mlngCodCurso = dr("cod_curso")
                    End If
                    If IsDBNull(dr("fecha_ingreso")) Then
                        mdtmFechaIngreso = FechaMinSistema()
                    Else
                        mdtmFechaIngreso = dr("fecha_ingreso")
                    End If
                    If IsDBNull(dr("monto")) Then
                        mlngMontoSolicitud = 0
                    Else
                        mlngMontoSolicitud = dr("monto")
                    End If
                    If IsDBNull(dr("nro_transaccion")) Then
                        mlnNumTransaccion = 0
                    Else
                        mlnNumTransaccion = dr("nro_transaccion")
                    End If
                    If IsDBNull(dr("rut_cliente")) Then
                        mlngRutCliente = 0
                    Else
                        mlngRutCliente = dr("rut_cliente")
                    End If
                    If IsDBNull(dr("correlativo")) Then
                        mlngCorrelativo = 0
                    Else
                        mlngCorrelativo = dr("correlativo")
                    End If
                    If IsDBNull(dr("fecha_inicio")) Then
                        mdtmFechaInicio = FechaMinSistema()
                    Else
                        mdtmFechaInicio = dr("fecha_inicio")
                    End If
                    If IsDBNull(dr("razon_social_benefactor")) Then
                        mstrNombreBenefactor = ""
                    Else
                        mstrNombreBenefactor = dr("razon_social_benefactor")
                    End If
                    If IsDBNull(dr("razon_social")) Then
                        mstrNombreBeneficiado = ""
                    Else
                        mstrNombreBeneficiado = dr("razon_social")
                    End If
                    If IsDBNull(dr("costo_otic")) Then
                        mlngCostoOtic = 0
                    Else
                        mlngCostoOtic = dr("costo_otic")
                    End If
                    If IsDBNull(dr("nombre")) Then
                        mstrNombreCurso = ""
                    Else
                        mstrNombreCurso = dr("nombre")
                    End If



                Next
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtConsulta.TableName = "Reporte Cursos"
                    ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
            End If

            Return dtConsulta

        Catch ex As Exception
            EnviaError("CReporteSolicitudes: Consultar-->" & ex.Message)
        End Try
       


        
    End Function
    'Public Function Consultar2() As System.Data.DataTable
    '    Try
    '        mobjSql = New CSql
    '        Dim solicitud As New CReporteSolicitudes
    '        Dim CCursoContratado As New CCursoContratado
    '        Dim solicita As New CSolicitud
    '        Dim cliente As New CCliente
    '        CCursoContratado.Inicializar0(mobjSql, Me.mlngRutBenefactor)
    '        CCursoContratado.Inicializar1(mlngCodCurso)
    '        CCursoContratado.ObtenerSolPagoTerc(CodCurso, RutBenefactor)
    '        CCursoContratado.ObtenerInfoCuentas()
    '        CCursoContratado.EntregarSolPagoTerc(solicita)
    '        solicita.Inicializar0(mobjSql, Me.RutBenefactor)

    '        solicita.Inicializar1(Me.CodCurso, Me.RutBenefactor, Me.RutCliente)
    '        'solicita.Inicializar2(mlngRutCliente, mlngRutBenefactor, mlngCodCurso, mlngMontoSolicitud, mlngNroTransaccion)
    '        solicita.RechazarSolPago()
    '        'cliente.Inicializar0(mobjSql, Me.RutBenefactor)
    '        'solicitud.RutCliente = Me.mlngRutBenefactor
    '        'solicitud.Consultar()
    '    Catch ex As Exception

    '    End Try



    'End Function




   




    'función para mostrar una fecha en formato usuario, puede recibir Null
    Private Function MostrarFecha(ByVal vntFecha As Object) As String
        If IsDBNull(vntFecha) Then
            MostrarFecha = ""
        ElseIf IsDate(vntFecha) Then
            MostrarFecha = FechaVbAUsr(vntFecha)
        Else
            MostrarFecha = "Error en la fecha!"
        End If
    End Function


   
End Class
