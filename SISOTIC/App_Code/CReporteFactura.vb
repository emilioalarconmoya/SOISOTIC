Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteFactura
    Implements IReporte
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    'rut del usuario
    Private mlngRutUsuario As Long
    'estado de las facturas
    Private mstrEstadoFac As String

    'Criterios de búsqueda
    'Estado Factura
    Private mintCodEstadoFactura As Integer
    'Rut Empresa
    Private mlngRutEmpresa As Long
    'Rut Otec
    Private mlngRutOtec As Long
    'Número Factura
    Private mlngNumFactura As Long
    'año de consulta
    Private mintAgno As Integer
    'arreglo para el lookup de estados facturas
    Private mdtLookUpEstadosFac As DataTable
    'Arreglo con las Etiquetas para impresion
    Private mdtEtiquetas As DataTable
    'objeto con consultas SQL
    Private mobjSql As CSql
    Private mlngCorrelativo As Long
    Private mlngNroregistro As Long
    Private mlngCodigoSence As Long
    Private mstrNombreCurso As String
    Private mstrNombreOtec As String
    Private mintCodEstadoCurso As Integer
    Private mstrNombreEstadoCurso As String
    Private mlngRutCliente As Long
    Private mstrNombreCliente As String
    Private mdtmFechaInicio As Date
    Private mdtmFechaTermino As Date
    Private mlngNumAlumnos As Long
    Private mstrCorrEmpresa As String
    Private mlngMontoFactura As Long
    Private mdtmFechaFactura As Date
    Private mdtmFechaRecepcion As Date
    Private mdtmFechaPago As Date
    Private mlngNroPerfil As Long
    Private mlngCodCurso As Long
    Private mstrObservacion As String
    Private mstrNroDocumento As String
    Private mlngNotaCredito As Long
    Private mstrNroEgreso As String
    Private mlngNroVoucher As Long

    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
        End Set
    End Property
    Public Property NotaCredito() As Long
        Get
            Return mlngNotaCredito
        End Get
        Set(ByVal value As Long)
            mlngNotaCredito = value
        End Set
    End Property
    Public Property NroEgreso() As String
        Get
            Return mstrNroEgreso
        End Get
        Set(ByVal value As String)
            mstrNroEgreso = value
        End Set
    End Property
    Public Property FechaPago() As Date
        Get
            Return mdtmFechaPago
        End Get
        Set(ByVal value As Date)
            mdtmFechaPago = value
        End Set
    End Property
    Public Property FechaRecepcion() As Date
        Get
            Return mdtmFechaRecepcion
        End Get
        Set(ByVal value As Date)
            mdtmFechaRecepcion = value
        End Set
    End Property
    Public Property FechaFactura() As Date
        Get
            Return mdtmFechaFactura
        End Get
        Set(ByVal value As Date)
            mdtmFechaFactura = value
        End Set
    End Property
    Public Property MontoFactura() As Long
        Get
            Return mlngMontoFactura
        End Get
        Set(ByVal value As Long)
            mlngMontoFactura = value
        End Set
    End Property
    Public Property CorrEmpresa() As String
        Get
            Return mstrCorrEmpresa
        End Get
        Set(ByVal value As String)
            mstrCorrEmpresa = value
        End Set
    End Property
    Public Property NumAlumnos() As Long
        Get
            Return mlngNumAlumnos
        End Get
        Set(ByVal value As Long)
            mlngNumAlumnos = value
        End Set
    End Property
    Public Property FechaTermino() As Date
        Get
            Return mdtmFechaTermino
        End Get
        Set(ByVal value As Date)
            mdtmFechaTermino = value
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
    Public Property NombreCliente() As String
        Get
            Return mstrNombreCliente
        End Get
        Set(ByVal value As String)
            mstrNombreCliente = value
        End Set
    End Property
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property NombreEstadoCurso() As String
        Get
            Return mstrNombreEstadoCurso
        End Get
        Set(ByVal value As String)
            mstrNombreEstadoCurso = value
        End Set
    End Property
    Public Property CodEstadoCurso() As Integer
        Get
            Return mintCodEstadoCurso
        End Get
        Set(ByVal value As Integer)
            mintCodEstadoCurso = value
        End Set
    End Property
    Public Property NombreOtec() As String
        Get
            Return mstrNombreOtec
        End Get
        Set(ByVal value As String)
            mstrNombreOtec = value
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
    Public Property NroPerfil() As Long
        Get
            Return mlngNroPerfil
        End Get
        Set(ByVal value As Long)
            mlngNroPerfil = value
        End Set
    End Property
    Public Property CodigoSence() As Long
        Get
            Return mlngCodigoSence
        End Get
        Set(ByVal value As Long)
            mlngCodigoSence = value
        End Set
    End Property
    Public Property Nroregistro() As Long
        Get
            Return mlngNroregistro
        End Get
        Set(ByVal value As Long)
            mlngNroregistro = value
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
    Public Property RutUsuario() As Long
        Get
            RutUsuario = mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property EstadoFac() As String
        Get
            EstadoFac = mstrEstadoFac
        End Get
        Set(ByVal value As String)
            mstrEstadoFac = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Observacion = mstrObservacion
        End Get
        Set(ByVal value As String)
            mstrObservacion = value
        End Set
    End Property
    Public Property NroDocumento() As String
        Get
            NroDocumento = mstrNroDocumento
        End Get
        Set(ByVal value As String)
            mstrNroDocumento = value
        End Set
    End Property

    Public Property CodEstadoFactura() As Integer
        Get
            CodEstadoFactura = mintCodEstadoFactura
        End Get
        Set(ByVal value As Integer)
            mintCodEstadoFactura = value
        End Set
    End Property
    Public Property RutEmpresa() As Long
        Get
            RutEmpresa = mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property
    Public Property RutOtec() As Long
        Get
            RutOtec = mlngRutOtec
        End Get
        Set(ByVal value As Long)
            mlngRutOtec = value
        End Set
    End Property
    Public Property NumFactura() As Long
        Get
            NumFactura = mlngNumFactura
        End Get
        Set(ByVal value As Long)
            mlngNumFactura = value
        End Set
    End Property
    Public Property NroVoucher() As Long
        Get
            Return mlngNroVoucher
        End Get
        Set(ByVal value As Long)
            mlngNroVoucher = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Agno = mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public ReadOnly Property LookUpEstadosFac() As DataTable
        Get
            LookUpEstadosFac = mdtLookUpEstadosFac
        End Get
    End Property
    Public Property Etiquetas() As DataTable
        Get
            Etiquetas = mdtEtiquetas
        End Get
        Set(ByVal value As DataTable)
            mdtEtiquetas = value
        End Set
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
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub
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

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
           
            Dim i As Integer, intFilas As Integer
            Dim dtConsulta As DataTable
            Dim strNombreArchivo As String
            mobjSql = New CSql
            dtConsulta = mobjSql.s_consulta_facturas(mintCodEstadoFactura, mlngRutEmpresa, mlngRutOtec, mlngNumFactura, mlngRutUsuario, mintAgno, mlngCodCurso)

           
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtConsulta.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If
            Return dtConsulta
        Catch ex As Exception
            EnviaError("CReporteCursoInterno: Consultar-->" & ex.Message)
        End Try
    End Function
    Public Function Consultar2() As System.Data.DataTable
        Try

            Dim i As Integer, intFilas As Integer
            Dim dtConsulta As DataTable
            'Dim strNombreArchivo As String
            mobjSql = New CSql
            dtConsulta = mobjSql.s_consulta_facturas(mintCodEstadoFactura, mlngRutEmpresa, mlngRutOtec, mlngNumFactura, mlngRutUsuario, mintAgno, mlngCodCurso)

            intFilas = mobjSql.Registros
            If intFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dtConsulta.Rows
                    mlngCodCurso = dr("cod_curso")
                    mlngCorrelativo = dr("correlativo")
                    mlngNroregistro = dr("nro_registro")
                    mlngCodigoSence = dr("codigo_sence")
                    mstrNombreCurso = dr("nombre_curso")
                    mlngRutOtec = dr("rut_otec")
                    mstrNombreOtec = dr("nombre_otec")
                    mintCodEstadoCurso = dr("cod_estado_curso")
                    mstrNombreEstadoCurso = dr("nombre_estado_curso")
                    mlngRutCliente = dr("rut_cliente")
                    mstrNombreCliente = dr("nombre_persona_juridica")
                    mdtmFechaInicio = dr("fecha_inicio")
                    mdtmFechaTermino = dr("fecha_termino")
                    mlngNumAlumnos = dr("num_alumnos")
                    mstrCorrEmpresa = dr("correlativo_empresa")
                    mintCodEstadoFactura = dr("cod_estado_fact")
                    mlngNumFactura = dr("num_factura")
                    mlngMontoFactura = dr("monto")
                    mdtmFechaFactura = dr("fecha")
                    mdtmFechaRecepcion = dr("fecha_recepcion")
                    mdtmFechaPago = dr("fecha_pago")
                    mstrEstadoFac = dr("nombre_factura")
                    mlngNroPerfil = dr("num_perfil")
                    mlngNroVoucher = dr("num_voucher")
                    mstrObservacion = dr("observacion")
                    mlngNroregistro = dr("nro_registro")
                    
                Next
            End If
            Return dtConsulta
        Catch ex As Exception
            EnviaError("CReporteCursoInterno: Consultar-->" & ex.Message)
        End Try
    End Function

    ''inicialización del objeto
    Public Sub Inicializar0(ByRef objSql As CSql)
        mobjSql = objSql
        mintAgno = Now.Year
        'llena lookup de Estado Facturas
        mdtLookUpEstadosFac = mobjSql.s_estados_factura
    End Sub
    '
    ''inicialización de variables
    Public Sub Initializar()
        mintCodEstadoFactura = 0
        mlngRutEmpresa = 0
        mlngRutOtec = 0
        mlngNumFactura = 0
        mlngRutUsuario = 0
        mstrEstadoFac = ""
        mintAgno = 0
        mdtLookUpEstadosFac = New DataTable
        mdtEtiquetas = New DataTable
        mlngCorrelativo = 0
        mlngNroregistro = 0
        mlngCodigoSence = 0
        mstrNombreOtec = ""
        mintCodEstadoCurso = 0
        mstrNombreEstadoCurso = ""
        mlngRutCliente = 0
        mstrNombreCliente = ""
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaTermino = FechaMinSistema()
        mlngNumAlumnos = 0
        mstrCorrEmpresa = ""
        mlngMontoFactura = 0
        mdtmFechaFactura = FechaMinSistema()
        mdtmFechaRecepcion = FechaMinSistema()
        mdtmFechaPago = FechaMinSistema()
        mlngNroPerfil = 0
        mlngCodCurso = 0
        mstrNroEgreso = ""
        
    End Sub

End Class
