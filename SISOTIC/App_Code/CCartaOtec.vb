Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Imports Microsoft.VisualBasic

Public Class CCartaOtec
#Region "Declaraciones"
    Dim mobjCurso As CCursoContratado
    Dim mobjCSql As CSql
    Dim mobjGenerar As CGeneraHTML
    Dim mobjGenerarPDF As CGeneraCartaOtec
    Dim mobjGenerarExcel As CGenerarExcel
    'rut del usuario conectado
    Private mlngRutUsuario As Long
    'El Código del Curso
    Private mlngCodCurso As Long
    'Indicador si el descuento es monto (0) o porcentaje (1)
    Private mintIndDescPorc As Integer
    'DataTable listado de alumnos 
    Private mdtAlumnos As DataTable
    'DataTable del horario del curso
    Private mdtHorario As DataTable
    'Número de registro sence
    Private mlngNroRegistro As Long
    'Datos del otec
    Private mstrContactoOtec As String
    Private mstrCargoOtecContacto As String
    Private mstrFaxOtecContacto As String
    Private mstrRazonSocialOtec As String
    'Datos del curso contratado
    Private mstrContactoAdicional As String
    Private mlngCorrelativo As Long
    Private mintCodEstadoCurso As Integer
    Private mdtmFechaInicio As Date
    Private mdtmFechaTermino As Date
    Private mlngHorasCompl As Long
    Private mlngCostoOtic As Long
    Private mlngGastoEmpresa As Long
    Private mlngCostoOticCompl As Long
    Private mlngTotalValor As Long
    Private mstrDireccion As String
    Private mstrNroDireccion As String
    Private mstrComuna As String
    Private mstrObservacion As String
    Private mintCodTipoActiv As Integer

    'Datos curso
    Private mstrCursoNombre As String
    Private mstrCursoDuracion As String
    Private mstrCodSence As String
    Private mlngCursoDescuento As Long
    Private mlngCursoNumAlumnos As Long
    Private mstrModalidad As String
    'Datos del cliente
    Private mstrClienteNombreEjec As String
    Private mstrClienteRazonSocial As String
    Private mstrClienteRut As String
    Private mstrClienteDireccion As String
    Private mstrClienteNroDireccion As String

    Private mstrClienteComuna As String
    'Datos del otic (paramgen)
    Private mstrOticNombre As String
    Private mstrOticRazonSocial As String
    Private mstrOticRut As String
    Private mstrOticDireccion As String
    Private mstrOticFonoCobranza As String
    Private mlngNumRegistro As Long

    'Generar HTML 
    Private mstrHtml As String
    'Bajar HTML
    Private mblnBajarHtml As Boolean
    Private mblncomiteBipartito As Boolean
    Private mstrDireccionArchivo As String
    Private mstrGiro As String
    Private mstrFonoContacto As String
    Private mstrFaxContacto As String

    Private mstrLunes As String
    Private mstrMartes As String
    Private mstrMiercoles As String
    Private mstrJueves As String
    Private mstrViernes As String
    Private mstrSabado As String
    Private mstrDomingo As String
    Private mstrCodTipoActiv As String
    Private mstrCodEstadoCurso As String
    Private mstrNumRegistro As String

    Private mstrUsuarioCreadorCurso As String
    Private mlngCodCursoCompl As Long
    Private mlngCodCursoParcial As Long

    Private mdblValorHora As Double
    Private mstrCorrelativoEmp As String

    Private mlngCorrelativoCompl As Long


#End Region
#Region "Propiedades"


    Public Property ValorHora() As Double
        Get
            ValorHora = mdblValorHora
        End Get
        Set(ByVal value As Double)
            Me.mdblValorHora = value
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
    Public Property CodTipoActiv() As Integer
        Get
            Return mintCodTipoActiv
        End Get
        Set(ByVal value As Integer)
            mintCodTipoActiv = value
        End Set
    End Property
    Public Property UsuarioCreadorCurso() As String
        Get
            Return mstrUsuarioCreadorCurso
        End Get
        Set(ByVal value As String)
            mstrUsuarioCreadorCurso = value
        End Set
    End Property
    Public Property FaxContacto() As String
        Get
            Return mstrFaxContacto
        End Get
        Set(ByVal value As String)
            mstrFaxContacto = value
        End Set
    End Property

    Public Property FonoContacto() As String
        Get
            Return mstrFonoContacto
        End Get
        Set(ByVal value As String)
            mstrFonoContacto = value
        End Set
    End Property
    Public ReadOnly Property CodEstadoCurso() As Integer
        Get
            Return mintCodEstadoCurso
        End Get
    End Property

    Public Property Modalidad() As String
        Get
            Return mstrModalidad
        End Get
        Set(ByVal value As String)
            mstrModalidad = value
        End Set
    End Property
    Public Property Giro() As String
        Get
            Return mstrGiro
        End Get
        Set(ByVal value As String)
            mstrGiro = value
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


    Public Property DireccionArchivo() As String
        Get
            Return mstrDireccionArchivo
        End Get
        Set(ByVal value As String)
            mstrDireccionArchivo = value
        End Set
    End Property
    Public Property NumRegistro() As Long
        Get
            Return mlngNumRegistro
        End Get
        Set(ByVal value As Long)
            mlngNumRegistro = value
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
    Public Property CodigoCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
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
    Public Property ComiteBipartito() As Boolean
        Get
            Return mblncomiteBipartito
        End Get
        Set(ByVal value As Boolean)
            mblncomiteBipartito = value
        End Set
    End Property
    Public ReadOnly Property IndDescPorc() As Integer
        Get
            Return mintIndDescPorc
        End Get
    End Property
    Public Property ListadoAlumnos() As DataTable
        Get
            Return mdtAlumnos
        End Get
        Set(ByVal value As DataTable)
            mdtAlumnos = value
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
    Public ReadOnly Property ContactoOtec() As String
        Get
            Return mstrContactoOtec
        End Get
    End Property
    Public ReadOnly Property Comuna() As String
        Get
            Return mstrComuna
        End Get
    End Property
    Public ReadOnly Property CargoOtecContacto() As String
        Get
            Return mstrCargoOtecContacto
        End Get
    End Property
    Public ReadOnly Property FaxOtecContacto() As String
        Get
            Return mstrFaxOtecContacto
        End Get
    End Property
    Public ReadOnly Property RazonSocialOtec() As String
        Get
            Return mstrRazonSocialOtec
        End Get
    End Property
    Public ReadOnly Property ContactoAdicional() As String
        Get
            Return mstrContactoAdicional
        End Get
    End Property
    Public ReadOnly Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
    End Property
    Public ReadOnly Property CorrelativoEmp() As String
        Get
            Return mstrCorrelativoEmp
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
    Public ReadOnly Property CostoOtic() As Long
        Get
            Return mlngCostoOtic
        End Get
    End Property
    Public ReadOnly Property GastoEmpresa() As Long
        Get
            Return mlngGastoEmpresa
        End Get
    End Property
    Public ReadOnly Property CostoOticCompl() As Long
        Get
            Return mlngCostoOticCompl
        End Get
    End Property
    Public ReadOnly Property TotalValor() As Long
        Get
            Return mlngTotalValor
        End Get
    End Property
    Public ReadOnly Property Direccion() As String
        Get
            Return mstrDireccion
        End Get
    End Property
    Public ReadOnly Property NombreCurso() As String
        Get
            Return mstrCursoNombre
        End Get
    End Property
    Public ReadOnly Property Observacion() As String
        Get
            Return mstrObservacion
        End Get
    End Property
    Public ReadOnly Property DuracionCurso() As String
        Get
            Return mstrCursoDuracion
        End Get
    End Property
    Public ReadOnly Property CodigoSence() As String
        Get
            Return mstrCodSence
        End Get
    End Property
    Public ReadOnly Property DescuentoCurso() As Long
        Get
            Return mlngCursoDescuento
        End Get
    End Property
    Public ReadOnly Property NumeroAlumnos() As Long
        Get
            Return mlngCursoNumAlumnos
        End Get
    End Property
    Public ReadOnly Property NombreEjecCliente() As String
        Get
            Return mstrClienteNombreEjec
        End Get
    End Property
    Public ReadOnly Property RazonSocialCliente() As String
        Get
            Return mstrClienteRazonSocial
        End Get
    End Property
    Public ReadOnly Property RutCliente() As String
        Get
            Return mstrClienteRut
        End Get
    End Property
    Public ReadOnly Property DireccionCliente() As String
        Get
            Return mstrClienteDireccion
        End Get
    End Property
    Public ReadOnly Property NroDireccionCliente() As String
        Get
            Return mstrClienteNroDireccion
        End Get
    End Property
    Public ReadOnly Property NroDireccion() As String
        Get
            Return mstrNroDireccion
        End Get
    End Property
    Public ReadOnly Property ComunaCliente() As String
        Get
            Return mstrClienteComuna
        End Get
    End Property
    Public ReadOnly Property NombreOtic() As String
        Get
            Return mstrOticNombre
        End Get
    End Property
    Public ReadOnly Property RazonSocialOtic() As String
        Get
            Return mstrOticRazonSocial
        End Get
    End Property
    Public ReadOnly Property RutOtic() As String
        Get
            Return mstrOticRut
        End Get
    End Property
    Public ReadOnly Property DireccionOtic() As String
        Get
            Return mstrOticDireccion
        End Get
    End Property
    Public ReadOnly Property FonoCobranza() As String
        Get
            Return mstrOticFonoCobranza
        End Get
    End Property
    Public ReadOnly Property NroRegistro() As Long
        Get
            Return mlngNroRegistro
        End Get
    End Property
    Public ReadOnly Property CorrelativoCompl() As Long
        Get
            Return mlngCorrelativoCompl
        End Get
    End Property

#End Region
    Public Sub Inicializar(ByVal mlngCodCurso, ByVal mlngRutUsuario)
        mobjCurso = New CCursoContratado
        mobjCSql = New CSql
        mobjCurso.Inicializar0(mobjCSql, mlngRutUsuario)
        mobjCurso.Inicializar1(mlngCodCurso)
        mstrContactoOtec = mobjCurso.Otec.Contacto
        mstrCargoOtecContacto = mobjCurso.Otec.Cargo
        mstrRazonSocialOtec = mobjCurso.Otec.RazonSocial
        mstrFaxOtecContacto = mobjCurso.Otec.FaxContacto
        mintCodTipoActiv = mobjCurso.CodTipoActiv
        mdblValorHora = mobjCurso.ValorHora


        If mintCodTipoActiv = 1 Then
            mstrCodTipoActiv = "Normal"
        ElseIf mintCodTipoActiv = 2 Then
            mstrCodTipoActiv = "Precontrato"
        ElseIf mintCodTipoActiv = 2 Then
            mstrCodTipoActiv = "Poscontrato"
        End If
        mstrContactoAdicional = mobjCurso.ContactoAdicional
        mlngCorrelativo = mobjCurso.Correlativo
        mintCodEstadoCurso = mobjCurso.CodEstadoCurso
        If mintCodEstadoCurso = 0 Then
            mstrCodEstadoCurso = "Incompleto"
        ElseIf mintCodEstadoCurso = 1 Then
            mstrCodEstadoCurso = "Ingresado"
        ElseIf mintCodEstadoCurso = 2 Then
            mstrCodEstadoCurso = "Rechazado"
        ElseIf mintCodEstadoCurso = 3 Then
            mstrCodEstadoCurso = "Autorizado"
        ElseIf mintCodEstadoCurso = 4 Then
            mstrCodEstadoCurso = "Comunicado"
        ElseIf mintCodEstadoCurso = 5 Then
            mstrCodEstadoCurso = "Liquidado"
        ElseIf mintCodEstadoCurso = 6 Then
            mstrCodEstadoCurso = "Pago por Autorizar"
        ElseIf mintCodEstadoCurso = 7 Then
            mstrCodEstadoCurso = "En Comunicacion"
        ElseIf mintCodEstadoCurso = 8 Then
            mstrCodEstadoCurso = "Eliminado"
        ElseIf mintCodEstadoCurso = 9 Then
            mstrCodEstadoCurso = "En Liquidacion"
        ElseIf mintCodEstadoCurso = 10 Then
            mstrCodEstadoCurso = "Anulado"
        ElseIf mintCodEstadoCurso = 11 Then
            mstrCodEstadoCurso = "Ingreso/Modif asistencia"
        End If
        mstrCorrelativoEmp = mobjCurso.CorrEmpresa
        mstrModalidad = mobjCurso.NombreModalidad
        mdtmFechaInicio = mobjCurso.FechaInicio
        mdtmFechaTermino = mobjCurso.FechaTermino
        mlngHorasCompl = mobjCurso.HorasCompl
        mlngCostoOtic = mobjCurso.CostoOtic
        mlngGastoEmpresa = mobjCurso.GastoEmpresa
        mlngTotalValor = mobjCurso.CostoOtic + mobjCurso.GastoEmpresa
        mlngCostoOticCompl = mobjCurso.CostoOticComplemento
        mstrDireccion = mobjCurso.DireccionCurso
        mstrNroDireccion = mobjCurso.NroDireccionCurso
        mstrComuna = mobjCurso.NomComuna
        mstrObservacion = mobjCurso.Observacion
        mstrCursoNombre = mobjCurso.Curso.NombreCurso
        If mobjCurso.CodCursoParcial <> -1 Then
            mstrCursoDuracion = mobjCurso.Horas
        Else
            mstrCursoDuracion = mobjCurso.Curso.DurCurso
        End If
        mstrCodSence = mobjCurso.Curso.CodSence
        mlngCursoDescuento = mobjCurso.Descuento
        mlngCursoNumAlumnos = mobjCurso.NumAlumnos
        mlngNumRegistro = mobjCurso.NroRegistro
        If mlngNumRegistro = -1 Then
            mstrNumRegistro = "-"
        Else
            mstrNumRegistro = mlngNumRegistro
        End If
        mstrOticNombre = Parametros.p_EMPRESA
        mstrOticRazonSocial = mobjCurso.ParamGen.RazonSocialOtic
        mstrOticRut = mobjCurso.ParamGen.RutOtic
        mstrOticDireccion = mobjCurso.ParamGen.DireccionOtic
        mstrOticFonoCobranza = mobjCurso.ParamGen.FonoCobranza
        ' mstrClienteNombreEjec = mobjCurso.Cliente.NombreEjecutivo
        mstrClienteNombreEjec = mobjCurso.CreadorCurso(mlngCodCurso)
        mstrClienteRazonSocial = mobjCurso.Cliente.RazonSocial
        mstrClienteRut = mobjCurso.Cliente.Rut
        mstrClienteDireccion = mobjCurso.Cliente.Direccion
        mstrClienteNroDireccion = mobjCurso.Cliente.NroDireccion
        mstrClienteComuna = mobjCurso.Cliente.Comuna
        mintIndDescPorc = mobjCurso.IndDescPorc
        mdtAlumnos = mobjCurso.ConsultarListado
        mdtHorario = mobjCurso.HorarioCurso
        mlngNroRegistro = mobjCurso.NroRegistro
        mstrGiro = mobjCurso.Giro
        mstrFonoContacto = mobjCurso.FonoContacto
        mstrFaxContacto = mobjCurso.FaxContacto
        mblncomiteBipartito = mobjCurso.IndAcuComBip
        Dim ComiteBipartito As String
        If mobjCurso.IndAcuComBip Then
            ComiteBipartito = "SI"
        Else
            ComiteBipartito = "NO"
        End If

        mlngCodCursoCompl = mobjCurso.CodCursoCompl
        mlngCodCursoParcial = mobjCurso.CodCursoParcial
        mlngCorrelativoCompl = mobjCurso.CorrelativoComplemento



        If mblnBajarHtml Then
            Dim strUrl As String
            'strUrl = Parametros.p_DIRVIRTUALMAIL
            'mobjGenerar = New CGeneraHTML
            'mstrHtml = mobjGenerar.Generar(strUrl & "/modulo_cursos/carta_otec.aspx?CodCurso=" & mlngCodCurso & "&rutUsuario=" & mlngRutUsuario & "&generar=si")
            'mstrDireccionArchivo = mobjGenerar.NombreArchivo
            LlenaHorario()

            strUrl = Parametros.p_DIRVIRTUALMAIL
            mobjGenerarPDF = New CGeneraCartaOtec
            mobjGenerarPDF.CartaOtec(mstrContactoOtec, mstrCargoOtecContacto, mstrRazonSocialOtec, mstrFaxOtecContacto, mstrContactoAdicional, mlngCorrelativo, mstrCodEstadoCurso, _
            mstrCodTipoActiv, mstrClienteNombreEjec, Date.Now.ToString, mdtAlumnos, mstrOticNombre, mstrOticRazonSocial, mstrOticRut, mstrOticDireccion, mstrClienteRazonSocial, _
            RutLngAUsr(mstrClienteRut), mstrClienteDireccion, mstrCursoNombre, mlngCorrelativo, mdtmFechaInicio, mdtmFechaTermino, mstrCursoDuracion, mlngHorasCompl, mstrCodSence, mstrDireccion, _
            mstrNroDireccion, mstrComuna, mstrNumRegistro, mstrClienteRazonSocial, RutLngAUsr(mstrClienteRut), mstrObservacion, FormatoPeso(mlngCursoDescuento), mlngCursoNumAlumnos, FormatoPeso(mlngTotalValor), RutLngAUsr(mstrClienteRut), _
            mstrClienteDireccion, mstrClienteNroDireccion, mstrGiro, mstrFonoContacto, mstrFaxContacto, mstrOticNombre, FormatoPeso(mlngCostoOtic), mstrClienteRazonSocial, FormatoPeso(mlngGastoEmpresa), _
            FormatoPeso(mlngTotalValor), Date.Now.Year + 1, FormatoPeso(mlngCostoOticCompl), Date.Now.Year + 1, mstrLunes, mstrMartes, mstrMiercoles, mstrJueves, mstrViernes, mstrSabado, mstrDomingo, mstrOticDireccion, _
            Parametros.p_EMPRESA.ToUpper, mstrClienteDireccion, mstrClienteComuna, mstrOticNombre, mstrModalidad, ComiteBipartito, mlngCodCursoParcial, mlngCodCursoCompl)

            mstrDireccionArchivo = mobjGenerarPDF.RutaFisica
        End If
    End Sub
    Public Sub EnviaCartaOtec(ByVal mlngCodCurso, ByVal mlngRutUsuario)
        mobjCurso = New CCursoContratado
        mobjCSql = New CSql
        mobjCurso.Inicializar0(mobjCSql, mlngRutUsuario)
        mobjCurso.Inicializar1(mlngCodCurso)
        mstrContactoOtec = mobjCurso.Otec.Contacto
        mstrCargoOtecContacto = mobjCurso.Otec.Cargo
        mstrRazonSocialOtec = mobjCurso.Otec.RazonSocial
        mstrFaxOtecContacto = mobjCurso.Otec.FaxContacto
        mintCodTipoActiv = mobjCurso.CodTipoActiv
        If mintCodTipoActiv = 1 Then
            mstrCodTipoActiv = "Normal"
        ElseIf mintCodTipoActiv = 2 Then
            mstrCodTipoActiv = "Precontrato"
        ElseIf mintCodTipoActiv = 2 Then
            mstrCodTipoActiv = "Poscontrato"
        End If
        mstrContactoAdicional = mobjCurso.ContactoAdicional
        mlngCorrelativo = mobjCurso.Correlativo
        mintCodEstadoCurso = mobjCurso.CodEstadoCurso
        If mintCodEstadoCurso = 0 Then
            mstrCodEstadoCurso = "Incompleto"
        ElseIf mintCodEstadoCurso = 1 Then
            mstrCodEstadoCurso = "Ingresado"
        ElseIf mintCodEstadoCurso = 2 Then
            mstrCodEstadoCurso = "Rechazado"
        ElseIf mintCodEstadoCurso = 3 Then
            mstrCodEstadoCurso = "Autorizado"
        ElseIf mintCodEstadoCurso = 4 Then
            mstrCodEstadoCurso = "Comunicado"
        ElseIf mintCodEstadoCurso = 5 Then
            mstrCodEstadoCurso = "Liquidado"
        ElseIf mintCodEstadoCurso = 6 Then
            mstrCodEstadoCurso = "Pago por Autorizar"
        ElseIf mintCodEstadoCurso = 7 Then
            mstrCodEstadoCurso = "En Comunicacion"
        ElseIf mintCodEstadoCurso = 8 Then
            mstrCodEstadoCurso = "Eliminado"
        ElseIf mintCodEstadoCurso = 9 Then
            mstrCodEstadoCurso = "En Liquidacion"
        ElseIf mintCodEstadoCurso = 10 Then
            mstrCodEstadoCurso = "Anulado"
        ElseIf mintCodEstadoCurso = 11 Then
            mstrCodEstadoCurso = "Ingreso/Modif asistencia"
        End If
        mstrModalidad = mobjCurso.NombreModalidad
        mdtmFechaInicio = mobjCurso.FechaInicio
        mdtmFechaTermino = mobjCurso.FechaTermino
        mlngHorasCompl = mobjCurso.HorasCompl
        mlngCostoOtic = mobjCurso.CostoOtic
        mlngGastoEmpresa = mobjCurso.GastoEmpresa
        mlngTotalValor = mobjCurso.CostoOtic + mobjCurso.GastoEmpresa
        mlngCostoOticCompl = mobjCurso.CostoOticComplemento
        mstrDireccion = mobjCurso.DireccionCurso
        mstrNroDireccion = mobjCurso.NroDireccionCurso
        mstrComuna = mobjCurso.NomComuna
        mstrObservacion = mobjCurso.Observacion
        mstrCursoNombre = mobjCurso.Curso.NombreCurso
        mstrCursoDuracion = mobjCurso.Curso.DurCurso
        mstrCodSence = mobjCurso.Curso.CodSence
        mlngCursoDescuento = mobjCurso.Descuento
        mlngCursoNumAlumnos = mobjCurso.NumAlumnos
        mlngNumRegistro = mobjCurso.NroRegistro
        If mlngNumRegistro = -1 Then
            mstrNumRegistro = "-"
        Else
            mstrNumRegistro = mlngNumRegistro
        End If
        mstrOticNombre = Parametros.p_EMPRESA
        mstrOticRazonSocial = mobjCurso.ParamGen.RazonSocialOtic
        mstrOticRut = mobjCurso.ParamGen.RutOtic
        mstrOticDireccion = mobjCurso.ParamGen.DireccionOtic
        mstrOticFonoCobranza = mobjCurso.ParamGen.FonoCobranza
        ' mstrClienteNombreEjec = mobjCurso.Cliente.NombreEjecutivo
        mstrClienteNombreEjec = mobjCurso.CreadorCurso(mlngCodCurso)
        mstrClienteRazonSocial = mobjCurso.Cliente.RazonSocial
        mstrClienteRut = mobjCurso.Cliente.Rut
        mstrClienteDireccion = mobjCurso.Cliente.Direccion
        mstrClienteNroDireccion = mobjCurso.Cliente.NroDireccion
        mstrClienteComuna = mobjCurso.Cliente.Comuna
        mintIndDescPorc = mobjCurso.IndDescPorc
        mdtAlumnos = mobjCurso.ConsultarListado
        mdtHorario = mobjCurso.HorarioCurso
        mlngNroRegistro = mobjCurso.NroRegistro
        mstrGiro = mobjCurso.Giro
        mstrFonoContacto = mobjCurso.FonoContacto
        mstrFaxContacto = mobjCurso.FaxContacto
        mblncomiteBipartito = mobjCurso.IndAcuComBip
        Dim ComiteBipartito As String
        If mobjCurso.IndAcuComBip Then
            ComiteBipartito = "SI"
        Else
            ComiteBipartito = "NO"
        End If
        mlngCodCursoCompl = mobjCurso.CodCursoCompl
        mlngCodCursoParcial = mobjCurso.CodCursoParcial

        Dim objSql As New CSql
        Dim strNombreUsuario As String
        strNombreUsuario = objSql.s_nom_usuario(mlngRutUsuario)
        objSql = Nothing

        If mblnBajarHtml Then
            Dim strUrl As String
            strUrl = Parametros.p_DIRVIRTUALMAIL
            mobjGenerarExcel = New CGenerarExcel
            mobjGenerarExcel.CartaOtec(mstrContactoOtec, mstrCargoOtecContacto, mstrRazonSocialOtec, mstrFaxOtecContacto, mstrContactoAdicional, mlngCorrelativo, mstrCodEstadoCurso, _
            mstrCodTipoActiv, mstrClienteNombreEjec, Date.Now.ToString, mdtAlumnos, Parametros.p_EMPRESA.ToUpper, Parametros.p_NOMBREEMPRESALARGO.ToUpper, Parametros.p_RUTEMPRESA, Parametros.p_DIRECIONEMPRESA.ToUpper, mstrClienteRazonSocial, _
            RutLngAUsr(mstrClienteRut), mstrClienteDireccion, mstrCursoNombre, mlngCorrelativo, mdtmFechaInicio, mdtmFechaTermino, mstrCursoDuracion, mlngHorasCompl, mstrCodSence, mstrDireccion, _
            mstrNroDireccion, mstrComuna, mstrNumRegistro, mstrClienteRazonSocial, RutLngAUsr(mstrClienteRut), mstrObservacion, FormatoPeso(mlngCursoDescuento), mlngCursoNumAlumnos, FormatoPeso(mlngTotalValor), RutLngAUsr(mstrClienteRut), _
            mstrClienteDireccion, mstrClienteNroDireccion, mstrGiro, mstrFonoContacto, mstrFaxContacto, mstrOticNombre, FormatoPeso(mlngCostoOtic), mstrClienteRazonSocial, FormatoPeso(mlngGastoEmpresa), _
            FormatoPeso(mlngTotalValor), Date.Now.Year + 1, FormatoPeso(mlngCostoOticCompl), Date.Now.Year + 1, mdtHorario, Parametros.p_DIRECIONEMPRESA.ToUpper, _
            Parametros.p_EMPRESA.ToUpper, mstrClienteDireccion, mstrClienteComuna, mstrOticNombre, mlngCodCursoParcial, mlngCodCursoCompl, strNombreUsuario, _
             mstrModalidad, ComiteBipartito, mstrFonoContacto, mstrGiro, Parametros.p_FONOEMPRESA.ToUpper, Parametros.p_GIROEMPRESA.ToUpper)

            mstrDireccionArchivo = mobjGenerarExcel.RutaArchivoVirtual
        End If
    End Sub
    Public Sub LlenaHorario()
        Dim lngDia As Long
        Dim dtHorario As New DataTable
        dtHorario = mdtHorario
        Dim dr As DataRow
        mstrLunes = ""
        mstrMartes = ""
        mstrMiercoles = ""
        mstrJueves = ""
        mstrViernes = ""
        mstrSabado = ""
        mstrDomingo = ""
        For Each dr In dtHorario.Rows
            lngDia = dr.Item(1)
            If lngDia = 1 Then
                mstrLunes = mstrLunes & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 2 Then
                mstrMartes = mstrMartes & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 3 Then
                mstrMiercoles = mstrMiercoles & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 4 Then
                mstrJueves = mstrJueves & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 5 Then
                mstrViernes = mstrViernes & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 6 Then
                mstrSabado = mstrSabado & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 7 Then
                mstrDomingo = mstrDomingo & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
        Next
    End Sub
End Class
