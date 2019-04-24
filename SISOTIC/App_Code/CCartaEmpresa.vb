Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Imports Microsoft.VisualBasic

Public Class CCartaEmpresa
#Region "Declaraciones"
    Private mdtHorario As DataTable
    Private mobjCurso As CCursoContratado
    Private mobjCSql As CSql
    Private mobjGenerarh As CGeneraHTML
    Private mobjGenerar As CGeneraPDF
    Private mobjGenerarExcel As CGenerarExcel
    'rut del usuario conectado
    Private mlngRutUsuario As Long
    'El Código del Curso
    Private mlngCodCurso As Long
    'Datos del cliente
    Private mstrClienteNombreContacto As String
    Private mstrClienteCargoContacto As String
    Private mstrClienteRazonSocial As String
    'Datos de curso contratado
    Private mlngCorrelativo As Long
    Private mstrCorrelativoEmpresa As String
    Private mintCodEstadoCurso As Integer
    Private mdtmFechaInicio As Date
    Private mdtmFechaTermino As Date
    Private mlngHorasCompl As Long
    Private mlngParticipantes As Long
    Private mblnIndAcuComBip As Boolean
    Private mstrDireccionCurso As String
    Private mstrNroDireccion As String
    Private mlngValorMercado As Long
    Private mlngCostoOtic As Long
    Private mlngCostoOticComp As Long
    Private mlngGastoEmpresa As Long
    Private mlngViatico As Long
    Private mlngTraslado As Long
    Private mlngCostoOticVyT As Long
    Private mlngGastoEmpVyT As Long
    Private mlngMontoCtaCap As Long
    Private mlngMontoCtaCapVyT As Long
    Private mlngMontoExcCtaCap As Long
    Private mlngMontoExcCtaCapVyT As Long
    Private mlngMontoBecas As Long
    Private mlngMontoTerceros As Long
    'Datos del curso
    Private mstrCursoNombre As String
    Private mstrCursoDuracion As String
    Private mstrCursoCodSence As String
    Private mstrCursoDireccion As String
    Private mstrCursiNroDireccion As String
    Private mstrCursoNombreComuna As String
    'Datos del otec
    Private mstrOtecRazonSocial As String
    'Datos del otic
    Private mstrOticNombre As String
    'DataTable listado alumnos
    Private mdtListadoAlumnos As DataTable
    'Código E-learning
    Private mlngCodElearning As Long
    'Codigo de Modalidad
    Private mlngCodModalidad As Long
    'Generar HTML 
    Private mstrHtml As String
    'Bajar HTML
    Private mblnBajarHtml As Boolean
    Private mlngNumregistro As Long
    Private mstrDireccionArchivo As String
    Private mstrObservacion As String
    Private mlngCorrelativoCompl As Long
    Private mintCodTipoActiv As Integer
    Private mlngCodCursoCompl As Long
    Private mlngCodCursoParcial As Long

    Private mdblValorHora As Double
#End Region
#Region "Propiedades"
    Public Property ValorHora() As Double
        Get
            Return mdblValorHora
        End Get
        Set(ByVal value As Double)
            mdblValorHora = value
        End Set
    End Property
    Public Property CodCursoCompl() As Long
        Get
            Return mlngCodCursoCompl
        End Get
        Set(ByVal value As Long)
            mlngCodCursoCompl = value
        End Set
    End Property
    Public Property CodCursoParcial() As Long
        Get
            Return mlngCodCursoParcial
        End Get
        Set(ByVal value As Long)
            mlngCodCursoParcial = value
        End Set
    End Property
    Public Property Horario() As DataTable
        Get
            Return mdtHorario
        End Get
        Set(ByVal value As DataTable)
            mdtHorario = value
        End Set
    End Property
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property Numregistro() As Long
        Get
            Return mlngNumregistro
        End Get
        Set(ByVal value As Long)
            mlngNumregistro = value
        End Set
    End Property
    Public Property CodigoCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
        End Set
    End Property
    Public Property DireccionArchivo() As String
        Get
            Return mstrDireccionArchivo
        End Get
        Set(ByVal value As String)
            mstrDireccionArchivo = value
        End Set
    End Property
    Public ReadOnly Property GenerarHtml() As String
        Get
            Return mstrHtml
        End Get
    End Property
    Public Property BajarHtml() As Boolean
        Get
            Return mblnBajarHtml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarHtml = value
        End Set
    End Property
    Public Property Html() As String
        Get
            Return mstrHtml
        End Get
        Set(ByVal value As String)
            mstrHtml = value
        End Set
    End Property
    Public ReadOnly Property ClienteNombreContacto() As String
        Get
            Return mstrClienteNombreContacto
        End Get
    End Property
    Public ReadOnly Property ClienteCargoContacto() As String
        Get
            Return mstrClienteCargoContacto
        End Get
    End Property
    Public ReadOnly Property ClienteRazonSocial() As String
        Get
            Return mstrClienteRazonSocial
        End Get
    End Property
    Public ReadOnly Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
    End Property
    Public ReadOnly Property CorrelativoEmpresa() As String
        Get
            Return mstrCorrelativoEmpresa
        End Get
    End Property
    Public ReadOnly Property CodEstadoCurso() As String
        Get
            Return mintCodEstadoCurso
        End Get
    End Property

    Public ReadOnly Property NroDireccion() As String
        Get
            Return mstrNroDireccion
        End Get
    End Property
    Public ReadOnly Property FechaInicio() As Date
        Get
            Return mdtmFechaInicio
        End Get
    End Property
    Public ReadOnly Property FechaTermino() As Date
        Get
            Return mdtmFechaTermino
        End Get
    End Property
    Public ReadOnly Property HorasComplementarias() As Long
        Get
            Return mlngHorasCompl
        End Get
    End Property
    Public ReadOnly Property Participantes() As Long
        Get
            Return mlngParticipantes
        End Get
    End Property
    Public ReadOnly Property DireccionCurso() As String
        Get
            Return mstrDireccionCurso
        End Get
    End Property
    Public ReadOnly Property Observacion() As String
        Get
            Return mstrObservacion
        End Get
    End Property
    Public ReadOnly Property ValorMercado() As Long
        Get
            Return mlngValorMercado
        End Get
    End Property
    Public ReadOnly Property CostoOtic() As Long
        Get
            Return mlngCostoOtic
        End Get
    End Property
    Public ReadOnly Property CostoOticCompl() As Long
        Get
            Return mlngCostoOticComp
        End Get
    End Property
    Public ReadOnly Property GastoEmpresa() As Long
        Get
            Return mlngGastoEmpresa
        End Get
    End Property
    Public ReadOnly Property Viatico() As Long
        Get
            Return mlngViatico
        End Get
    End Property
    Public ReadOnly Property Traslado() As Long
        Get
            Return mlngTraslado
        End Get
    End Property
    Public ReadOnly Property CostoOticVyT() As Long
        Get
            Return mlngCostoOticVyT
        End Get
    End Property
    Public ReadOnly Property GastoEmpVyT() As Long
        Get
            Return mlngGastoEmpVyT
        End Get
    End Property
    Public ReadOnly Property CuentaCap() As Long
        Get
            Return mlngMontoCtaCap
        End Get
    End Property
    Public ReadOnly Property CuentaCapVyT() As Long
        Get
            Return mlngMontoCtaCapVyT
        End Get
    End Property
    Public ReadOnly Property CuentaExcCap() As Long
        Get
            Return mlngMontoExcCtaCap
        End Get
    End Property
    Public ReadOnly Property CuentaExcCapVyT() As Long
        Get
            Return mlngMontoExcCtaCapVyT
        End Get
    End Property
    Public ReadOnly Property Becas() As Long
        Get
            Return mlngMontoBecas
        End Get
    End Property
    Public ReadOnly Property Terceros() As Long
        Get
            Return mlngMontoTerceros
        End Get
    End Property
    Public ReadOnly Property NombreCurso() As String
        Get
            Return mstrCursoNombre
        End Get
    End Property
    Public ReadOnly Property NombreComunaCurso() As String
        Get
            Return mstrCursoNombreComuna
        End Get
    End Property

    Public ReadOnly Property DuracionCurso() As String
        Get
            Return mstrCursoDuracion
        End Get
    End Property
    Public ReadOnly Property CodSence() As String
        Get
            Return mstrCursoCodSence
        End Get
    End Property
    Public ReadOnly Property RazonSocialOtec() As String
        Get
            Return mstrOtecRazonSocial
        End Get
    End Property
    Public ReadOnly Property NombreOtic() As String
        Get
            Return mstrOticNombre
        End Get
    End Property
    Public ReadOnly Property IndAcuComBip() As Boolean
        Get
            Return mblnIndAcuComBip
        End Get
    End Property
    Public Property CodElearning() As Long
        Get
            Return mlngCodElearning
        End Get
        Set(ByVal value As Long)
            mlngCodElearning = value
        End Set
    End Property
    Public ReadOnly Property CodModalidad() As Long
        Get
            Return mlngCodModalidad
        End Get
    End Property
    Public Property CodTipoActiv() As Integer
        Get
            Return mintCodTipoActiv
        End Get
        Set(ByVal value As Integer)
            mintCodTipoActiv = value
        End Set
    End Property
    Public Property ListadoAlumnos() As DataTable
        Get
            Return mdtListadoAlumnos
        End Get
        Set(ByVal value As DataTable)
            mdtListadoAlumnos = value
        End Set
    End Property
    Public Property CorrelativoCompl() As Long
        Get
            Return mlngCorrelativoCompl
        End Get
        Set(ByVal value As Long)
            mlngCorrelativoCompl = value
        End Set
    End Property
#End Region
    Public Sub Inicializar(ByVal mlngCodCurso, ByVal mlngRutUsuario)
        mobjCurso = New CCursoContratado
        mobjCSql = New CSql
        mobjCurso.Inicializar0(mobjCSql, mlngRutUsuario)
        mobjCurso.Inicializar1(mlngCodCurso)
        mobjCurso.ObtenerInfoCuentas()
        mlngCodElearning = mobjCurso.CodElearning
        'If mlngCodElearning = 1 Then
        '    mobjCurso.ObtenerAlumnosElearning()
        'End If
        mlngCodModalidad = mobjCurso.CodModalidad
        Dim strModalidad As String
        If mlngCodModalidad = 1 Then
            strModalidad = "Presencial"
        ElseIf mlngCodModalidad = 2 Then
            strModalidad = "E-Learning"
        ElseIf mlngCodModalidad = 3 Then
            strModalidad = "Auto-Intrucción"
        End If
        mintCodTipoActiv = mobjCurso.CodTipoActiv
        mstrClienteNombreContacto = mobjCurso.Cliente.Contacto
        mstrClienteCargoContacto = mobjCurso.Cliente.CargoContacto
        mstrClienteRazonSocial = mobjCurso.Cliente.RazonSocial
        mlngCorrelativo = mobjCurso.Correlativo
        mstrCorrelativoEmpresa = mobjCurso.CorrEmpresa
        mintCodEstadoCurso = mobjCurso.CodEstadoCurso
        mstrOtecRazonSocial = mobjCurso.Otec.RazonSocial
        Dim strEstadoCurso As String
        If mintCodEstadoCurso = 0 Then
            strEstadoCurso = "Incompleto"
        ElseIf mintCodEstadoCurso = 1 Then
            strEstadoCurso = "Ingresado"
        ElseIf mintCodEstadoCurso = 2 Then
            strEstadoCurso = "Rechazado"
        ElseIf mintCodEstadoCurso = 3 Then
            strEstadoCurso = "Autorizado"
        ElseIf mintCodEstadoCurso = 4 Then
            strEstadoCurso = "Comunicado"
        ElseIf mintCodEstadoCurso = 5 Then
            strEstadoCurso = "Liquidado"
        ElseIf mintCodEstadoCurso = 6 Then
            strEstadoCurso = "Pago por Autorizar"
        ElseIf mintCodEstadoCurso = 7 Then
            strEstadoCurso = "En Comunicacion"
        ElseIf mintCodEstadoCurso = 8 Then
            strEstadoCurso = "Eliminado"
        ElseIf mintCodEstadoCurso = 9 Then
            strEstadoCurso = "En Liquidacion"
        ElseIf mintCodEstadoCurso = 10 Then
            strEstadoCurso = "Anulado"
        ElseIf mintCodEstadoCurso = 11 Then
            strEstadoCurso = "Ingreso/Modif asistencia"
        End If
        mdtmFechaInicio = mobjCurso.FechaInicio
        mdtmFechaTermino = mobjCurso.FechaTermino
        mlngHorasCompl = mobjCurso.HorasCompl
        mlngParticipantes = mobjCurso.NumAlumnos
        mblnIndAcuComBip = mobjCurso.IndAcuComBip
        Dim strIndAcuComBip As String
        If mblnIndAcuComBip = 1 Then
            strIndAcuComBip = "Sí"
        Else
            strIndAcuComBip = "No"
        End If
        mstrDireccionCurso = mobjCurso.DireccionCurso
        mstrNroDireccion = mobjCurso.NroDireccionCurso
        mstrCursoNombreComuna = mobjCurso.NomComuna
        mlngNumregistro = mobjCurso.NroRegistro
        mlngValorMercado = mobjCurso.ValorMercado
        mlngCostoOtic = mobjCurso.CostoOtic
        mlngCostoOticComp = mobjCurso.CostoOticComplemento
        mlngGastoEmpresa = mobjCurso.GastoEmpresa
        mlngViatico = mobjCurso.TotalViatico
        mlngTraslado = mobjCurso.TotalTraslado
        Dim lngTotalVyT As Long = mlngViatico + mlngTraslado
        mlngCostoOticVyT = mobjCurso.CostoOticVYTReal
        mlngGastoEmpVyT = mobjCurso.GastoEmpresaVYTReal
        mlngMontoCtaCap = mobjCurso.MontoCtaCap
        mlngMontoCtaCapVyT = mobjCurso.MontoCtaCapVYT
        mlngMontoExcCtaCap = mobjCurso.MontoCtaExcCap
        mlngMontoBecas = mobjCurso.MontoCtaBecas
        mlngMontoTerceros = mobjCurso.TotMontoTercTransacciones
        mstrCursoNombre = mobjCurso.Curso.NombreCurso
        mstrCursoDuracion = mobjCurso.Curso.DurCurso
        mstrCursoCodSence = mobjCurso.CodSence
        mstrOticNombre = mobjCurso.ParamGen.NombreOtic
        If mstrOticNombre = "" Then
            mstrOticNombre = Parametros.p_EMPRESA.ToUpper
        Else
            mstrOticNombre = mobjCurso.Otec.RazonSocial
        End If
        mdtListadoAlumnos = mobjCurso.ConsultarListado2
        If mobjCurso.Observacion = "" Then
            mstrObservacion = "-"
        Else
            mstrObservacion = mobjCurso.Observacion
        End If
        mdtHorario = mobjCurso.HorarioCurso
        mlngCorrelativoCompl = mobjCurso.CorrelativoComplemento
        mlngCodCursoCompl = mobjCurso.CodCursoCompl
        mlngCodCursoParcial = mobjCurso.CodCursoParcial
        mdblValorHora = mobjCurso.ValorHora

        'If mblnBajarHtml Then
        '    mobjGenerar = New CGeneraPDF
        '    mobjGenerar.CartaEmpresa(mdtListadoAlumnos, mlngCodCurso, strModalidad, mstrClienteNombreContacto, _
        '                                     mstrClienteCargoContacto, mstrClienteRazonSocial, mlngCorrelativo, mstrCorrelativoEmpresa, _
        '                                     strEstadoCurso, mstrCursoNombre, mlngCorrelativo, mdtmFechaInicio, _
        '                                     mdtmFechaTermino, mstrCursoDuracion, mstrDireccionCurso, mstrNroDireccion, _
        '                                     mstrCursoNombreComuna, mlngHorasCompl, mstrCursoCodSence, mstrOtecRazonSocial, _
        '                                     mlngParticipantes, strIndAcuComBip, mstrObservacion, mlngValorMercado, _
        '                                     mlngCostoOtic, mlngCostoOticComp, mlngGastoEmpresa, lngTotalVyT, _
        '                                     mlngCostoOticVyT, mlngGastoEmpVyT, mlngMontoCtaCap, mlngMontoExcCtaCap, _
        '                                     mlngMontoBecas, mlngMontoTerceros, mstrOticNombre, mlngNumregistro, "", "", "", "", "", "", "")

        '    mstrDireccionArchivo = mobjGenerar.RutaArchivoVirtual

        'End If


        'If mblnBajarHtml Then
        '    Dim strUrl As String
        '    strUrl = Parametros.p_DIRVIRTUALMAIL
        '    mobjGenerarh = New CGeneraHTML
        '    mstrHtml = mobjGenerarh.Generar(strUrl & "/modulo_cursos/carta_empresa.aspx?codCurso=" & mlngCodCurso & "&rutUsuario=" & mlngRutUsuario & "&generar=si")
        '    mstrDireccionArchivo = mobjGenerarh.NombreArchivo
        'End If

    End Sub
    Public Sub EnviaCartaEmpresa(ByVal mlngCodCurso, ByVal mlngRutUsuario)
        mobjCurso = New CCursoContratado
        mobjCSql = New CSql
        mobjCurso.Inicializar0(mobjCSql, mlngRutUsuario)
        mobjCurso.Inicializar1(mlngCodCurso)
        mobjCurso.ObtenerInfoCuentas()
        mlngCodElearning = mobjCurso.CodElearning
        mlngCodModalidad = mobjCurso.CodModalidad
        Dim strModalidad As String
        If mlngCodModalidad = 1 Then
            strModalidad = "Presencial"
        ElseIf mlngCodModalidad = 2 Then
            strModalidad = "E-Learning"
        ElseIf mlngCodModalidad = 3 Then
            strModalidad = "Auto-Intrucción"
        End If
        mstrClienteNombreContacto = mobjCurso.Cliente.Contacto
        mstrClienteCargoContacto = mobjCurso.Cliente.CargoContacto
        mstrClienteRazonSocial = mobjCurso.Cliente.RazonSocial
        mstrOtecRazonSocial = mobjCurso.Otec.RazonSocial
        mlngCorrelativo = mobjCurso.Correlativo
        mstrCorrelativoEmpresa = mobjCurso.CorrEmpresa
        mintCodEstadoCurso = mobjCurso.CodEstadoCurso
        Dim strEstadoCurso As String
        If mintCodEstadoCurso = 0 Then
            strEstadoCurso = "Incompleto"
        ElseIf mintCodEstadoCurso = 1 Then
            strEstadoCurso = "Ingresado"
        ElseIf mintCodEstadoCurso = 2 Then
            strEstadoCurso = "Rechazado"
        ElseIf mintCodEstadoCurso = 3 Then
            strEstadoCurso = "Autorizado"
        ElseIf mintCodEstadoCurso = 4 Then
            strEstadoCurso = "Comunicado"
        ElseIf mintCodEstadoCurso = 5 Then
            strEstadoCurso = "Liquidado"
        ElseIf mintCodEstadoCurso = 6 Then
            strEstadoCurso = "Pago por Autorizar"
        ElseIf mintCodEstadoCurso = 7 Then
            strEstadoCurso = "En Comunicacion"
        ElseIf mintCodEstadoCurso = 8 Then
            strEstadoCurso = "Eliminado"
        ElseIf mintCodEstadoCurso = 9 Then
            strEstadoCurso = "En Liquidacion"
        ElseIf mintCodEstadoCurso = 10 Then
            strEstadoCurso = "Anulado"
        ElseIf mintCodEstadoCurso = 11 Then
            strEstadoCurso = "Ingreso/Modif asistencia"
        End If
        mdtmFechaInicio = mobjCurso.FechaInicio
        mdtmFechaTermino = mobjCurso.FechaTermino
        mlngHorasCompl = mobjCurso.HorasCompl
        mlngParticipantes = mobjCurso.NumAlumnos
        mblnIndAcuComBip = mobjCurso.IndAcuComBip
        Dim strIndAcuComBip As String
        If mblnIndAcuComBip = 1 Then
            strIndAcuComBip = "Sí"
        Else
            strIndAcuComBip = "No"
        End If
        mstrDireccionCurso = mobjCurso.DireccionCurso
        mstrNroDireccion = mobjCurso.NroDireccionCurso
        mstrCursoNombreComuna = mobjCurso.NomComuna
        mlngNumregistro = mobjCurso.NroRegistro
        mlngValorMercado = mobjCurso.ValorMercado
        mlngCostoOtic = mobjCurso.CostoOtic
        mlngCostoOticComp = mobjCurso.CostoOticComplemento
        mlngGastoEmpresa = mobjCurso.GastoEmpresa
        mlngViatico = mobjCurso.TotalViatico
        mlngTraslado = mobjCurso.TotalTraslado
        Dim lngTotalVyT As Long = mlngViatico + mlngTraslado
        If mobjCurso.CostoOticVYTReal = -1 Then
            mlngCostoOticVyT = 0
        Else
            mlngCostoOticVyT = mobjCurso.CostoOticVYTReal
        End If
        mlngGastoEmpVyT = mobjCurso.GastoEmpresaVYTReal
        mlngMontoCtaCap = mobjCurso.MontoCtaCap
        mlngMontoCtaCapVyT = mobjCurso.MontoCtaCapVYT
        mlngMontoExcCtaCap = mobjCurso.MontoCtaExcCap
        mlngMontoBecas = mobjCurso.MontoCtaBecas
        mlngMontoTerceros = mobjCurso.TotMontoTercTransacciones
        mstrCursoNombre = mobjCurso.Curso.NombreCurso
        mstrCursoDuracion = mobjCurso.Curso.DurCurso
        mstrCursoCodSence = mobjCurso.CodSence
        mstrOticNombre = mobjCurso.ParamGen.NombreOtic
        If mstrOticNombre = "" Then
            mstrOticNombre = Parametros.p_EMPRESA.ToUpper
        Else
            mstrOticNombre = mobjCurso.Otec.RazonSocial
        End If
        mdtListadoAlumnos = mobjCurso.ConsultarListado
        If mobjCurso.Observacion = "" Then
            mstrObservacion = "-"
        Else
            mstrObservacion = mobjCurso.Observacion
        End If
        mdtHorario = mobjCurso.HorarioCurso
        mlngCodCursoCompl = mobjCurso.CodCursoCompl
        mlngCodCursoParcial = mobjCurso.CodCursoParcial

        Dim objSql As New CSql
        Dim strNombreUsuario As String
        strNombreUsuario = objSql.s_nom_usuario(mlngRutUsuario)
        objSql = Nothing

        If mblnBajarHtml Then
            mobjGenerarExcel = New CGenerarExcel
            mobjGenerarExcel.CartaEmpresa(mdtListadoAlumnos, mlngCodCurso, strModalidad, mstrClienteNombreContacto, _
                                             mstrClienteCargoContacto, mstrClienteRazonSocial, mlngCorrelativo, mstrCorrelativoEmpresa, _
                                             strEstadoCurso, mstrCursoNombre, mlngCorrelativo, mdtmFechaInicio, _
                                             mdtmFechaTermino, mstrCursoDuracion, mstrDireccionCurso, mstrNroDireccion, _
                                             mstrCursoNombreComuna, mlngHorasCompl, mstrCursoCodSence, mstrOtecRazonSocial, _
                                             mlngParticipantes, strIndAcuComBip, mstrObservacion, mlngValorMercado, _
                                             mlngCostoOtic, mlngCostoOticComp, mlngGastoEmpresa, lngTotalVyT, _
                                             mlngCostoOticVyT, mlngGastoEmpVyT, mlngMontoCtaCap, mlngMontoExcCtaCap, _
                                             mlngMontoBecas, mlngMontoTerceros, mstrOticNombre, mlngNumregistro, mdtHorario, _
                                             CStr(mlngCodCursoParcial), CStr(mlngCodCursoCompl), strNombreUsuario)

            mstrDireccionArchivo = mobjGenerarExcel.RutaArchivoVirtual

        End If

    End Sub
End Class
