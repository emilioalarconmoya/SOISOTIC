Imports Clases
Imports Modulos
Imports Clases.Web
Imports System.data
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.Image
Imports System.IO
Imports Microsoft.VisualBasic

Public Class CGeneraPDF

   


#Region "VARIABLES"


    Private mobjCsql As CSql
    Private Ruta As String = Parametros.p_DIRFISICO
    Private mstrRutaArchivo As String
    Private mstrRutaArchivoVirtual As String
    Private mobjCurso As CCursoContratado

    Private mstrCorrelativo As String
    Private mstrEstadoActual As String
    Private mstrOrigen As String
    Private mstrNSence As String
    Private mstrCodigoCurso As String
    Private mdteFecha As Date
    Private mdteFechaIngreso As Date
    Private mstrNSenceCompl As String


    Private mstrNombreEmpresa As String
    Private mstrRutEmpresa As String
    Private mstrContactoEmpresa As String
    Private mstrCargoEmpresa As String
    Private mstrFonoEmpresa As String
    Private mstrFaxEmpresa As String
    Private mstrMailEmpresa As String

    Private mstrRazonSocial As String
    Private mstrRutOtec As String
    Private mstrContactoOtec As String
    Private mstrCargoOtec As String
    Private mstrFonoOtec As String
    Private mstrFaxOtec As String
    Private mstrMailOtec As String

    Private mstrNomContacto As String
    Private mstrCargoContacto As String
    Private mstrFonoContacto As String
    Private mstrFaxContacto As String
    Private mstrMailContacto As String

    Private mstrNombreRep1 As String
    Private mstrNombreRep2 As String
    Private mstrRutRep1 As String
    Private mstrRutRep2 As String

    Private mstrNombreCurso As String
    Private mstrCodigoSenceCurso As String
    Private mstrHorasCurso As String
    Private mstrLugarCurso As String
    Private dteFechaInicioCurso As Date
    Private dteFechaFinCurso As Date
    Private mstrObservacionCurso As String
    Private mstrComunaCurso As String
    Private mstrAreaCurso As String
    Private mstrEspecialidadCurso As String

    Private mstrNumPartCosto As String
    Private mstrValorCosto As String
    Private mstrValorCurso As String
    Private mstrViaticoCosto As String
    Private mstrTransladoCosto As String
    Private mstrPorcAdminCosto As String
    Private mstrBipartitoCosto As String
    Private mstrNecesidadesCosto As String
    Private mstrPreContratoCosto As String
    Private mstrPosContratoCosto As String

    Private mstrCPCostoOtic As String
    Private mstrCPGastoEmpresa As String
    Private mstrCPCostoAdmin As String
    Private mstrCPHoras As String
    Private mstrCPCuentaDeCap As String
    Private mstrCPCuentaDeExc As String
    Private mstrCPCuentaDeBecas As String
    Private mstrCPCuentaDeTerceros As String

    Private mstrVTCostoOtic As String
    Private mstrVTGastoEmpresa As String
    Private mstrVTCostoAdmin As String
    Private mstrVTCuentaDeCap As String
    Private mstrVTCuentaDeExc As String

    Private mstrTotalCostoOtic As String
    Private mstrTotalGastoEmpresa As String
    Private mstrTotalCostoAdmin As String
    Private mstrTotalCuentaDeCap As String
    Private mstrTotalCuentaDeExc As String

    'Ficha Otec
    'direccion
    Private mstrDINombreComuna As String
    Private mstrDINombreDireccion As String
    Private mstrDIRegion As String
    Private mstrDIEmail As String

    'contacto otec
    Private mstrCONombreContacto As String
    Private mstrCOCargoOtec As String
    Private mstrCOFonoOtec As String
    Private mstrCOFaxOtec As String
    Private mstrCOEmail As String

    'representante legal
    Private mstrRLNombreRepresentante1 As String
    Private mstrRLRutRepresentante1 As String
    Private mstrRLNombreRepresentante2 As String
    Private mstrRLRutRepresentante2 As String

    'dato convenio
    Private mstrDCNroConvenio As String
    Private mstrDCTasaDescuento As String

    'actividad
    Private mstrACGiro As String
    Private mstrACCodigoActidadEconomica As String
    Private mstrACRubroInterno As String

    'otros contactos
    Private mstrOCGerenteGeneral As String
    Private mstrOCGerenteRRHH As String
    Private mstrOCAreaCobranza As String

    Private mstrNFactura As String




#End Region

#Region "PROPIEDADES"


    Public Property DINombreComuna() As String
        Get
            Return mstrDINombreComuna
        End Get
        Set(ByVal value As String)
            mstrDINombreComuna = value
        End Set
    End Property
    Public Property nFactura() As String
        Get
            Return mstrNFactura
        End Get
        Set(ByVal value As String)
            mstrNFactura = value
        End Set
    End Property
    Public Property ValorCurso() As String
        Get
            Return mstrValorCurso
        End Get
        Set(ByVal value As String)
            mstrValorCurso = value
        End Set
    End Property

    Public Property DIRegion() As String
        Get
            Return mstrDIRegion
        End Get
        Set(ByVal value As String)
            mstrDIRegion = value
        End Set
    End Property

    Public Property DINombreDireccion() As String
        Get
            Return mstrDINombreDireccion
        End Get
        Set(ByVal value As String)
            mstrDINombreDireccion = value
        End Set
    End Property
    Public Property DIEmail() As String
        Get
            Return mstrDIEmail
        End Get
        Set(ByVal value As String)
            mstrDIEmail = value
        End Set
    End Property
    Public Property CONombreContacto() As String
        Get
            Return mstrCONombreContacto
        End Get
        Set(ByVal value As String)
            mstrCONombreContacto = value
        End Set

    End Property
    Public Property COCargoOtec() As String
        Get
            Return mstrCOCargoOtec
        End Get
        Set(ByVal value As String)
            mstrCOCargoOtec = value
        End Set
    End Property
    Public Property COFonoOtec() As String
        Get
            Return mstrCOFonoOtec
        End Get
        Set(ByVal value As String)
            mstrCOFonoOtec = value
        End Set

    End Property
    Public Property COFaxOtec() As String
        Get
            Return mstrCOFaxOtec
        End Get
        Set(ByVal value As String)
            mstrCOFaxOtec = value
        End Set
    End Property
    Public Property COEmail() As String
        Get
            Return mstrCOEmail
        End Get
        Set(ByVal value As String)
            mstrCOEmail = value
        End Set
    End Property
    Public Property RLNombreRepresentante1() As String
        Get
            Return mstrRLNombreRepresentante1
        End Get
        Set(ByVal value As String)
            mstrRLNombreRepresentante1 = value
        End Set
    End Property
    Public Property RLRutRepresentante1() As String
        Get
            Return mstrRLRutRepresentante1
        End Get
        Set(ByVal value As String)
            mstrRLRutRepresentante1 = value
        End Set
    End Property
    Public Property RLNombreRepresentante2() As String
        Get
            Return mstrRLNombreRepresentante2
        End Get
        Set(ByVal value As String)
            mstrRLNombreRepresentante2 = value
        End Set
    End Property
    Public Property RLRutRepresentante2() As String
        Get
            Return mstrRLRutRepresentante2
        End Get
        Set(ByVal value As String)
            mstrRLRutRepresentante2 = value
        End Set
    End Property
    Public Property DCNroConvenio() As String
        Get
            Return mstrDCNroConvenio
        End Get
        Set(ByVal value As String)
            mstrDCNroConvenio = value
        End Set
    End Property
    Public Property DCTasaDescuento() As String
        Get
            Return mstrDCTasaDescuento
        End Get
        Set(ByVal value As String)
            mstrDCTasaDescuento = value
        End Set
    End Property
    Public Property ACGiro() As String
        Get
            Return mstrACGiro
        End Get
        Set(ByVal value As String)
            mstrACGiro = value
        End Set
    End Property
    Public Property ACCodigoActidadEconomica() As String
        Get
            Return mstrACCodigoActidadEconomica
        End Get
        Set(ByVal value As String)
            mstrACCodigoActidadEconomica = value
        End Set
    End Property
    Public Property ACRubroInterno() As String
        Get
            Return mstrACRubroInterno
        End Get
        Set(ByVal value As String)
            mstrACRubroInterno = value
        End Set
    End Property
    Public Property OCGerenteGeneral() As String
        Get
            Return mstrOCGerenteGeneral
        End Get
        Set(ByVal value As String)
            mstrOCGerenteGeneral = value
        End Set
    End Property
    Public Property OCGerenteRRHH() As String
        Get
            Return mstrOCGerenteRRHH
        End Get
        Set(ByVal value As String)
            mstrOCGerenteRRHH = value
        End Set
    End Property
    Public Property OCAreaCobranza() As String
        Get
            Return mstrOCAreaCobranza
        End Get
        Set(ByVal value As String)
            mstrOCAreaCobranza = value
        End Set
    End Property
    
    Public Property RutRep2() As String
        Get
            Return mstrRutRep2
        End Get
        Set(ByVal value As String)
            mstrRutRep2 = value
        End Set
    End Property

    Public Property RutRep1() As String
        Get
            Return mstrRutRep1
        End Get
        Set(ByVal value As String)
            mstrRutRep1 = value
        End Set
    End Property

    Public Property NombreRep2() As String
        Get
            Return mstrNombreRep2
        End Get
        Set(ByVal value As String)
            mstrNombreRep2 = value
        End Set
    End Property

    Public Property NombreRep1() As String
        Get
            Return mstrNombreRep1
        End Get
        Set(ByVal value As String)
            mstrNombreRep1 = value
        End Set
    End Property

    Public Property MailContacto() As String
        Get
            Return mstrMailContacto
        End Get
        Set(ByVal value As String)
            mstrMailContacto = value
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

    Public Property CargoContacto() As String
        Get
            Return mstrCargoContacto
        End Get
        Set(ByVal value As String)
            mstrCargoContacto = value
        End Set
    End Property

    Public Property NomContacto() As String
        Get
            Return mstrNomContacto
        End Get
        Set(ByVal value As String)
            mstrNomContacto = value
        End Set
    End Property

    Public Property EspecialidadCurso() As String
        Get
            Return mstrEspecialidadCurso
        End Get
        Set(ByVal value As String)
            mstrEspecialidadCurso = value
        End Set
    End Property

    Public Property AreaCurso() As String
        Get
            Return mstrAreaCurso
        End Get
        Set(ByVal value As String)
            mstrAreaCurso = value
        End Set
    End Property

    Public Property TotalCuentaDeExc() As String
        Get
            Return mstrTotalCuentaDeExc
        End Get
        Set(ByVal value As String)
            mstrTotalCuentaDeExc = value
        End Set
    End Property

    Public Property TotalCuentaDeCap() As String
        Get
            Return mstrTotalCuentaDeCap
        End Get
        Set(ByVal value As String)
            mstrTotalCuentaDeCap = value
        End Set
    End Property

    Public Property TotalCostoAdmin() As String
        Get
            Return mstrTotalCostoAdmin
        End Get
        Set(ByVal value As String)
            mstrTotalCostoAdmin = value
        End Set
    End Property

    Public Property TotalGastoEmpresa() As String
        Get
            Return mstrTotalGastoEmpresa
        End Get
        Set(ByVal value As String)
            mstrTotalGastoEmpresa = value
        End Set
    End Property

    Public Property TotalCostoOtic() As String
        Get
            Return mstrTotalCostoOtic
        End Get
        Set(ByVal value As String)
            mstrTotalCostoOtic = value
        End Set
    End Property

    Public Property VTCuentaDeExc() As String
        Get
            Return mstrVTCuentaDeExc
        End Get
        Set(ByVal value As String)
            mstrVTCuentaDeExc = value
        End Set
    End Property

    Public Property VTCuentaDeCap() As String
        Get
            Return mstrVTCuentaDeCap
        End Get
        Set(ByVal value As String)
            mstrVTCuentaDeCap = value
        End Set
    End Property

    Public Property VTCostoAdmin() As String
        Get
            Return mstrVTCostoAdmin
        End Get
        Set(ByVal value As String)
            mstrVTCostoAdmin = value
        End Set
    End Property

    Public Property VTGastoEmpresa() As String
        Get
            Return mstrVTGastoEmpresa
        End Get
        Set(ByVal value As String)
            mstrVTGastoEmpresa = value
        End Set
    End Property

    Public Property VTCostoOtic() As String
        Get
            Return mstrVTCostoOtic
        End Get
        Set(ByVal value As String)
            mstrVTCostoOtic = value
        End Set
    End Property


    Public Property CPCuentaDeTerceros() As String
        Get
            Return mstrCPCuentaDeTerceros
        End Get
        Set(ByVal value As String)
            mstrCPCuentaDeTerceros = value
        End Set
    End Property

    Public Property CPCuentaDeBecas() As String
        Get
            Return mstrCPCuentaDeBecas
        End Get
        Set(ByVal value As String)
            mstrCPCuentaDeBecas = value
        End Set
    End Property

    Public Property CPCuentaDeExc() As String
        Get
            Return mstrCPCuentaDeExc
        End Get
        Set(ByVal value As String)
            mstrCPCuentaDeExc = value
        End Set
    End Property

    Public Property CPCuentaDeCap() As String
        Get
            Return mstrCPCuentaDeCap
        End Get
        Set(ByVal value As String)
            mstrCPCuentaDeCap = value
        End Set
    End Property

    Public Property CPHoras() As String
        Get
            Return mstrCPHoras
        End Get
        Set(ByVal value As String)
            mstrCPHoras = value
        End Set
    End Property

    Public Property CPCostoAdmin() As String
        Get
            Return mstrCPCostoAdmin
        End Get
        Set(ByVal value As String)
            mstrCPCostoAdmin = value
        End Set
    End Property

    Public Property CPGastoEmpresa() As String
        Get
            Return mstrCPGastoEmpresa
        End Get
        Set(ByVal value As String)
            mstrCPGastoEmpresa = value
        End Set
    End Property

    Public Property CPCostoOtic() As String
        Get
            Return mstrCPCostoOtic
        End Get
        Set(ByVal value As String)
            mstrCPCostoOtic = value
        End Set
    End Property

    Public ReadOnly Property RutaArchivo() As String
        Get
            Return mstrRutaArchivo
        End Get
    End Property
    Public ReadOnly Property RutaArchivoVirtual() As String
        Get
            Return mstrRutaArchivoVirtual
        End Get
    End Property
    Public Property Correlativo() As String
        Get
            Return mstrCorrelativo
        End Get
        Set(ByVal value As String)
            mstrCorrelativo = value
        End Set
    End Property
    Public Property EstadoActual() As String
        Get
            Return mstrEstadoActual
        End Get
        Set(ByVal value As String)
            mstrEstadoActual = value
        End Set
    End Property
    Public Property Origen() As String
        Get
            Return mstrOrigen
        End Get
        Set(ByVal value As String)
            mstrOrigen = value
        End Set
    End Property
    Public Property NSence() As String
        Get
            Return mstrNSence
        End Get
        Set(ByVal value As String)
            mstrNSence = value
        End Set
    End Property
    Public Property CodigoCurso() As String
        Get
            Return mstrCodigoCurso
        End Get
        Set(ByVal value As String)
            mstrCodigoCurso = value
        End Set
    End Property

    Public Property ComunaCurso() As String
        Get
            Return mstrComunaCurso
        End Get
        Set(ByVal value As String)
            mstrComunaCurso = value
        End Set
    End Property


    Public Property Fecha() As Date
        Get
            Return mdteFecha
        End Get
        Set(ByVal value As Date)
            mdteFecha = value
        End Set
    End Property
    Public Property FechaIngreso() As Date
        Get
            Return mdteFechaIngreso
        End Get
        Set(ByVal value As Date)
            mdteFechaIngreso = value
        End Set
    End Property
    Public Property NSenceCompl() As String
        Get
            Return mstrNSenceCompl
        End Get
        Set(ByVal value As String)
            mstrNSenceCompl = value
        End Set
    End Property

    Public Property NombreEmpresa() As String
        Get
            Return mstrNombreEmpresa
        End Get
        Set(ByVal value As String)
            mstrNombreEmpresa = value
        End Set
    End Property
    Public Property RutEmpresa() As String
        Get
            Return mstrRutEmpresa
        End Get
        Set(ByVal value As String)
            mstrRutEmpresa = value
        End Set
    End Property
    Public Property ContactoEmpresa() As String
        Get
            Return mstrContactoEmpresa
        End Get
        Set(ByVal value As String)
            mstrContactoEmpresa = value
        End Set
    End Property
    Public Property CargoEmpresa() As String
        Get
            Return mstrCargoEmpresa
        End Get
        Set(ByVal value As String)
            mstrCargoEmpresa = value
        End Set
    End Property
    Public Property FonoEmpresa() As String
        Get
            Return mstrFonoEmpresa
        End Get
        Set(ByVal value As String)
            mstrFonoEmpresa = value
        End Set
    End Property
    Public Property FaxEmpresa() As String
        Get
            Return mstrFaxEmpresa
        End Get
        Set(ByVal value As String)
            mstrFaxEmpresa = value
        End Set
    End Property
    Public Property MailEmpresa() As String
        Get
            Return mstrMailEmpresa
        End Get
        Set(ByVal value As String)
            mstrMailEmpresa = value
        End Set
    End Property

    Public Property RazonSocial() As String
        Get
            Return mstrRazonSocial
        End Get
        Set(ByVal value As String)
            mstrRazonSocial = value
        End Set
    End Property
    Public Property RutOtec() As String
        Get
            Return mstrRutOtec
        End Get
        Set(ByVal value As String)
            mstrRutOtec = value
        End Set
    End Property
    Public Property ContactoOtec() As String
        Get
            Return mstrContactoOtec
        End Get
        Set(ByVal value As String)
            mstrContactoOtec = value
        End Set
    End Property
    Public Property CargoOtec() As String
        Get
            Return mstrCargoOtec
        End Get
        Set(ByVal value As String)
            mstrCargoOtec = value
        End Set
    End Property
    Public Property FonoOtec() As String
        Get
            Return mstrFonoOtec
        End Get
        Set(ByVal value As String)
            mstrFonoOtec = value
        End Set
    End Property
    Public Property FaxOtec() As String
        Get
            Return mstrFaxOtec
        End Get
        Set(ByVal value As String)
            mstrFaxOtec = value
        End Set
    End Property
    Public Property MailOtec() As String
        Get
            Return mstrMailOtec
        End Get
        Set(ByVal value As String)
            mstrMailOtec = value
        End Set
    End Property

    Public Property ObservacionCurso() As String
        Get
            Return mstrObservacionCurso
        End Get
        Set(ByVal value As String)
            mstrObservacionCurso = value
        End Set
    End Property

    Public Property FechaFinCurso() As Date
        Get
            Return dteFechaFinCurso
        End Get
        Set(ByVal value As Date)
            dteFechaFinCurso = value
        End Set
    End Property

    Public Property FechaInicioCurso() As Date
        Get
            Return dteFechaInicioCurso
        End Get
        Set(ByVal value As Date)
            dteFechaInicioCurso = value
        End Set
    End Property

    Public Property LugarCurso() As String
        Get
            Return mstrLugarCurso
        End Get
        Set(ByVal value As String)
            mstrLugarCurso = value
        End Set
    End Property

    Public Property HorasCurso() As String
        Get
            Return mstrHorasCurso
        End Get
        Set(ByVal value As String)
            mstrHorasCurso = value
        End Set
    End Property

    Public Property CodigoSenceCurso() As String
        Get
            Return mstrCodigoSenceCurso
        End Get
        Set(ByVal value As String)
            mstrCodigoSenceCurso = value
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

    Public Property PosContratoCosto() As String
        Get
            Return mstrPosContratoCosto
        End Get
        Set(ByVal value As String)
            mstrPosContratoCosto = value
        End Set
    End Property


    Public Property PreContratoCosto() As String
        Get
            Return mstrPreContratoCosto
        End Get
        Set(ByVal value As String)
            mstrPreContratoCosto = value
        End Set
    End Property


    Public Property NecesidadesCosto() As String
        Get
            Return mstrNecesidadesCosto
        End Get
        Set(ByVal value As String)
            mstrNecesidadesCosto = value
        End Set
    End Property

    Public Property BipartitoCosto() As String
        Get
            Return mstrBipartitoCosto
        End Get
        Set(ByVal value As String)
            mstrBipartitoCosto = value
        End Set
    End Property
    Public Property PorcAdminCosto() As String
        Get
            Return mstrPorcAdminCosto
        End Get
        Set(ByVal value As String)
            mstrPorcAdminCosto = value
        End Set
    End Property
    Public Property TransladoCosto() As String
        Get
            Return mstrTransladoCosto
        End Get
        Set(ByVal value As String)
            mstrTransladoCosto = value
        End Set
    End Property

    Public Property ViaticoCosto() As String
        Get
            Return mstrViaticoCosto
        End Get
        Set(ByVal value As String)
            mstrViaticoCosto = value
        End Set
    End Property
    Public Property ValorCosto() As String
        Get
            Return mstrValorCosto
        End Get
        Set(ByVal value As String)
            mstrValorCosto = value
        End Set
    End Property
    Public Property NumPartCosto() As String
        Get
            Return mstrNumPartCosto
        End Get
        Set(ByVal value As String)
            mstrNumPartCosto = value
        End Set
    End Property

#End Region

    Public Sub Inicializar()
        mobjCsql = New CSql
    End Sub

    Public Sub FichaCursoContratado()

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText
        'Dim ColorAzul = New BaseColor(105, 144, 195)
        Dim ColorBlanco = New BaseColor(255, 255, 255)


        Dim ColorAzul = New BaseColor(0, 174, 199)
        Dim ColorGris = New BaseColor(0, 174, 199) 'BaseColor(50, 224, 249)

        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
           FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)
            cb.BeginText()

            ''*** TITULO
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            'cb.SetFontAndSize(fuente, 16)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            ''cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "OTIC DE LA BANCA", (PageSize.A4.Width / 2), (PageSize.A4.Height - 50), 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_EMPRESA, (PageSize.A4.Width / 2), (PageSize.A4.Height - 50), 0)

            ''*** SUBTITULO
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'cb.SetFontAndSize(fuente, 12)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Orden de compra", (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)

            ''*** TITULO FECHA
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'cb.SetFontAndSize(fuente, 8)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha", 400, (PageSize.A4.Height - 85), 0)

            ''*** DATO FECHA
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'cb.SetFontAndSize(fuente, 8)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Now.Date.ToShortDateString, 450, (PageSize.A4.Height - 85), 0)

            ''*** PIE
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            'cb.SetFontAndSize(fuente, 6)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_PIE, (PageSize.A4.Width / 2), (PageSize.A4.Height - 780), 0)

            cb.EndText()

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea


            'Dim tableEmpleado As New PdfPTable(8)
            'tableEmpleado.TotalWidth = PageSize.A4.Width
            'Dim widthsEmpleado(7) As Single
            'widthsEmpleado(0) = 55 '50
            'widthsEmpleado(1) = 40 '4
            'widthsEmpleado(2) = 60 '150
            'widthsEmpleado(3) = 60 '50
            'widthsEmpleado(4) = 55 '4
            'widthsEmpleado(5) = 55 '200
            'widthsEmpleado(6) = 90 '200
            'widthsEmpleado(7) = 55 '200

            Dim tableEmpleado As New PdfPTable(6)
            tableEmpleado.TotalWidth = PageSize.A4.Width
            Dim widthsEmpleado(5) As Single
            widthsEmpleado(0) = 78 '78
            widthsEmpleado(1) = 58 '58
            widthsEmpleado(2) = 98 '98
            widthsEmpleado(3) = 68 '58
            widthsEmpleado(4) = 100 '110
            widthsEmpleado(5) = 68 '68

            tableEmpleado.SetWidthPercentage(widthsEmpleado, PageSize.A4)

            Dim cell As PdfPCell

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 6
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            Dim par As New Paragraph("FICHA CURSO CONTRATADO", FontFactory.GetFont("Arial", 10, BaseColor.WHITE))
            par.Alignment = Element.ALIGN_LEFT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            '**********************
            'cell = New PdfPCell
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.Colspan = 4
            'cell.BackgroundColor = colorAzulOscuro
            'Dim par As New Paragraph("ORDEN DE COMPRA ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'par.Alignment = Element.ALIGN_LEFT
            'cell.AddElement(par)
            'Table.AddCell(cell)

            '**********************

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            'cell.AddElement(New Paragraph("CORRELATIVO", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("CORRELATIVO", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            'cell.AddElement(New Paragraph(": " & Me.mstrCorrelativo.ToUpper, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(": " & Me.mstrCorrelativo.ToUpper, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_LEFT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            'cell.AddElement(New Paragraph("ESTADO ACTUAL", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("ESTADO ACTUAL", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            'cell.AddElement(New Paragraph(": " & Me.mstrEstadoActual.ToUpper, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(": " & Me.mstrEstadoActual.ToUpper, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_LEFT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            'cell = New PdfPCell
            'cell.Border = 0
            'cell.AddElement(New Paragraph("ORIGEN", FontFactory.GetFont("Arial", 8)))
            'tableEmpleado.AddCell(cell)

            'cell = New PdfPCell
            'cell.Border = 0
            'cell.AddElement(New Paragraph(": " & Me.mstrOrigen, FontFactory.GetFont("Arial", 8)))
            'tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            'cell.AddElement(New Paragraph("Nº REG.SENCE", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("Nº REG.SENCE", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            'cell.AddElement(New Paragraph(": " & Me.NSence, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(": " & Me.NSence, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_LEFT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)
            '_____________________segunda fila________________

            'cell = New PdfPCell
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0.5
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Codigo curso", FontFactory.GetFont("Arial", 8)))
            'tableEmpleado.AddCell(cell)

            'cell = New PdfPCell
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0.5
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(": " & Me.mstrCodigoCurso, FontFactory.GetFont("Arial", 8)))
            'tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("Fecha", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("FECHA", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph(": " & Me.mdteFecha, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(": " & Me.mdteFecha, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_LEFT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("Fecha ingreso", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("FECHA INGRESO", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph(": " & Me.mdteFechaIngreso, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(": " & Me.mdteFechaIngreso, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_LEFT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("NºREG.SENCE COMPL", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("CORRELATIVO COMPL.", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph(": " & Me.mstrNSenceCompl, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(": " & Me.mstrNSenceCompl, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_LEFT
            cell.AddElement(par)
            tableEmpleado.AddCell(cell)

            oDoc.Add(tableEmpleado)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea



            Dim tableEmpresa As New PdfPTable(8)
            tableEmpresa.TotalWidth = PageSize.A4.Width
            Dim widthsEmpresa(7) As Single
            widthsEmpresa(0) = 55 '50
            widthsEmpresa(1) = 40 '4
            widthsEmpresa(2) = 75 '150
            widthsEmpresa(3) = 50 '50
            widthsEmpresa(4) = 55 '4
            widthsEmpresa(5) = 60 '200
            widthsEmpresa(6) = 75 '200
            widthsEmpresa(7) = 60 '200

            tableEmpresa.SetWidthPercentage(widthsEmpresa, PageSize.A4)


            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            cell.AddElement(New Paragraph("DATOS DE LA EMPRESA", FontFactory.GetFont("Arial", 10, BaseColor.WHITE)))
            tableEmpresa.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            cell.AddElement(New Paragraph("DATOS DEL OTEC", FontFactory.GetFont("Arial", 10, BaseColor.WHITE)))
            tableEmpresa.AddCell(cell)

            '_________________1ª fila______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(mstrNombreEmpresa.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(mstrRazonSocial.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            '_________________2ª fila______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("RUT :" & mstrRutEmpresa, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("RUT :" & mstrRutOtec, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            '_________________3ª fila______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("CONTACTO : " & mstrContactoEmpresa.ToUpper & "CARGO: " & mstrCargoEmpresa.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Contacto : " & mstrContactoOtec.ToUpper & "CARGO: " & mstrCargoOtec.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            '_________________4ª fila______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("FONO : " & mstrFonoEmpresa, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("FONO : " & mstrFonoOtec, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            '_________________5ª fila______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("MAIL :" & mstrMailEmpresa.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("MAIL :" & mstrMailOtec.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableEmpresa.AddCell(cell)

            oDoc.Add(tableEmpresa)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            '___________ tabla costos y cursos

            Dim tableCursos As New PdfPTable(8)
            tableCursos.TotalWidth = PageSize.A4.Width
            Dim widthsCursos(7) As Single
            widthsCursos(0) = 65 '50
            widthsCursos(1) = 40 '4
            widthsCursos(2) = 55 '150
            widthsCursos(3) = 50 '50
            widthsCursos(4) = 65 '4
            widthsCursos(5) = 60 '200
            widthsCursos(6) = 105 '200
            widthsCursos(7) = 30 '200

            tableCursos.SetWidthPercentage(widthsCursos, PageSize.A4)



            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            cell.AddElement(New Paragraph("CURSO", FontFactory.GetFont("Arial", 10, BaseColor.WHITE)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            cell.AddElement(New Paragraph("COSTO", FontFactory.GetFont("Arial", 10, BaseColor.WHITE)))
            tableCursos.AddCell(cell)


            '_________________1ª fila  ______________


            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrNombreCurso, FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nº PART. ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Me.mstrNumPartCosto, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(Me.mstrNumPartCosto, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderWidthLeft = 0.5
            cell.PaddingLeft = 6
            cell.AddElement(New Paragraph("VBº COMITE BIPARTITO ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Me.mstrBipartitoCosto.ToUpper, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(Me.mstrBipartitoCosto, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            '_________________2ª fila  ______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("CODIGO SENCE: " & Me.mstrCodigoSenceCurso & " - HORAS: " & Me.mstrHorasCurso, FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("VALOR CURSO ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrValorCosto, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrValorCurso, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderWidthLeft = 0.5
            cell.PaddingLeft = 6
            cell.AddElement(New Paragraph("DETECCION NECESIDADES", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Me.mstrNecesidadesCosto.ToUpper, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(Me.mstrNecesidadesCosto, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            '_________________3ª fila  ______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("LUGAR DE EJECUCION: " & Me.mstrLugarCurso, FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("T. VIATICO ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrViaticoCosto, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrViaticoCosto, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderWidthLeft = 0.5
            cell.PaddingLeft = 6
            cell.AddElement(New Paragraph("PRE CONTRATO", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Me.mstrPreContratoCosto.ToUpper, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(Me.mstrPreContratoCosto, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            '_________________4ª fila  ______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrComunaCurso.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)


            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("T. TRASLADO ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrTransladoCosto, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrTransladoCosto, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderWidthLeft = 0.5
            cell.PaddingLeft = 6
            cell.AddElement(New Paragraph("POST CONTRATO", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Me.mstrPosContratoCosto.ToUpper, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(Me.mstrPosContratoCosto, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            '_________________5ª fila  ______________

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("FECHA INICIO: " & Me.dteFechaInicioCurso, FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)


            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("PORC. ADM ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph(Me.mstrPorcAdminCosto & " %", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(Me.mstrPorcAdminCosto & " %", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingLeft = 6
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColorBottom = BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("Nº FACTURA", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph(Me.nFactura, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(Me.nFactura, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursos.AddCell(cell)

            '____________ 6 fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.Colspan = 4
            cell.AddElement(New Paragraph("FECHA TERMINO: " & Me.dteFechaFinCurso, FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)


            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(" ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(" ", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            '____________ 7 fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 8
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 8
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("OBSERVACION: " & Me.mstrObservacionCurso.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableCursos.AddCell(cell)

            'cell = New PdfPCell
            'cell.Border = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.Colspan = 4
            'cell.AddElement(New Paragraph(" ", FontFactory.GetFont("Arial", 8)))
            'tableCursos.AddCell(cell)

            oDoc.Add(tableCursos)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea


            Dim tableCursosParcial As New PdfPTable(4)
            tableCursos.TotalWidth = PageSize.A4.Width
            Dim widthsCursosCursosParcial(3) As Single
            widthsCursosCursosParcial(0) = 119
            widthsCursosCursosParcial(1) = 117
            widthsCursosCursosParcial(2) = 117
            widthsCursosCursosParcial(3) = 117

            tableCursosParcial.SetWidthPercentage(widthsCursosCursosParcial, PageSize.A4)


            cell = New PdfPCell 'celda cabecera
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorAzul
            cell.AddElement(New Paragraph("CURSO PARCIAL ", FontFactory.GetFont("Arial", 10, BaseColor.WHITE)))
            tableCursosParcial.AddCell(cell)

            'primera fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            'cell.AddElement(New Paragraph("V&T", FontFactory.GetFont("Arial", 10, BaseColor.WHITE)))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            par = New Paragraph("V&T", FontFactory.GetFont("Arial", 10, BaseColor.WHITE))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            'cell.AddElement(New Paragraph("TOTAL", FontFactory.GetFont("Arial", 10, BaseColor.WHITE)))
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            par = New Paragraph("TOTAL", FontFactory.GetFont("Arial", 10, BaseColor.WHITE))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            'cell = New PdfPCell
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            ''cell.AddElement(New Paragraph("V&T", FontFactory.GetFont("Arial", 8)))
            'par = New Paragraph("V&T", FontFactory.GetFont("Arial", 8))
            'par.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(par)
            'tableCursosParcial.AddCell(cell)

            'cell = New PdfPCell
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            ''cell.AddElement(New Paragraph("Total", FontFactory.GetFont("Arial", 8)))
            'par = New Paragraph("Total", FontFactory.GetFont("Arial", 8))
            'par.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(par)
            'tableCursosParcial.AddCell(cell)

            'segunda fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Costo OTIC ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("COSTO OTIC ", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrCPCostoOtic, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrCPCostoOtic, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrVTCostoOtic, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrVTCostoOtic, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrTotalCostoOtic, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrTotalCostoOtic, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            '3ª fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("GASTO EMPRESA ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("GASTO EMPRESA ", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrCPGastoEmpresa, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrCPGastoEmpresa, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrVTGastoEmpresa, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrVTGastoEmpresa, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrTotalGastoEmpresa, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrTotalGastoEmpresa, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            '4ª fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Costo admin. ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("COSTO ADMIN. ", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrCPCostoAdmin, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrCPCostoAdmin, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrVTCostoAdmin, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrVTCostoAdmin, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrTotalCostoAdmin, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrTotalCostoAdmin, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            '5ª fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Horas ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("HORAS ", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("  " & Me.mstrCPHoras, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("  " & Me.mstrCPHoras, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(" - ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph(" - ", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("-", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("-", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            '6ª fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Cuenta de Cap ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("CUENTA DE CAP", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrCPCuentaDeCap, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrCPCuentaDeCap, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrVTCuentaDeCap, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrVTCuentaDeCap, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrTotalCuentaDeCap, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrTotalCuentaDeCap, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            '7ª fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Cuenta de exc. cap ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("CUENTA DE EXC. CAP", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrCPCuentaDeExc, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrCPCuentaDeExc, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrVTCuentaDeExc, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrVTCuentaDeExc, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrTotalCuentaDeExc, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrTotalCuentaDeExc, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            '7ª fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Cuenta de becas ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("CUENTA DE BECAS ", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.Border = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("$ " & Me.mstrCPCuentaDeBecas, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrCPCuentaDeBecas, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("-", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("-", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("-", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("-", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            '8ª fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("Cuenta terceros ", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("CUENTA TERCEROS", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("$ " & Me.mstrCPCuentaDeTerceros, FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("$ " & Me.mstrCPCuentaDeTerceros, FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("-", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("-", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColor = BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("-", FontFactory.GetFont("Arial", 8)))
            par = New Paragraph("-", FontFactory.GetFont("Arial", 8))
            par.Alignment = Element.ALIGN_RIGHT
            cell.AddElement(par)
            tableCursosParcial.AddCell(cell)



            oDoc.Add(tableCursosParcial)


            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo


        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try

    End Sub

    Public Sub FichaCursoSence()

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText

        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
           FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)
            cb.BeginText()

            '*** TITULO
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            cb.SetFontAndSize(fuente, 16)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_EMPRESA, (PageSize.A4.Width / 2), (PageSize.A4.Height - 50), 0)

            '*** SUBTITULO
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 12)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)

            '*** TITULO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha", 400, (PageSize.A4.Height - 85), 0)

            '*** DATO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Now.Date.ToShortDateString, 450, (PageSize.A4.Height - 85), 0)

            '*** PIE
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_PIE, (PageSize.A4.Width / 2), (PageSize.A4.Height - 650), 0)
            cb.EndText()

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea


            Dim tableFichaCursoSence As New PdfPTable(4)
            tableFichaCursoSence.TotalWidth = PageSize.A4.Width
            Dim widthsFichaCursoSence(3) As Single
            widthsFichaCursoSence(0) = 119
            widthsFichaCursoSence(1) = 117
            widthsFichaCursoSence(2) = 117
            widthsFichaCursoSence(3) = 117

            tableFichaCursoSence.SetWidthPercentage(widthsFichaCursoSence, PageSize.A4)
            Dim cell As PdfPCell

            cell = New PdfPCell 'celda cabecera
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.AddElement(New Paragraph("FICHA CURSO SENCE ", FontFactory.GetFont("Arial", 10)))
            tableFichaCursoSence.AddCell(cell)

            'primera fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(Me.mstrNombreCurso, FontFactory.GetFont("Arial", 8)))
            tableFichaCursoSence.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(" ", FontFactory.GetFont("Arial", 8)))
            tableFichaCursoSence.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("COdigo Sence: " & Me.mstrCodigoSenceCurso, FontFactory.GetFont("Arial", 8)))
            tableFichaCursoSence.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(" ", FontFactory.GetFont("Arial", 8)))
            tableFichaCursoSence.AddCell(cell)

            oDoc.Add(tableFichaCursoSence)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea


            Dim tableDatosCurso As New PdfPTable(4)
            tableDatosCurso.TotalWidth = PageSize.A4.Width
            Dim widthsDatosCurso(3) As Single
            widthsDatosCurso(0) = 119
            widthsDatosCurso(1) = 117
            widthsDatosCurso(2) = 117
            widthsDatosCurso(3) = 117

            tableDatosCurso.SetWidthPercentage(widthsDatosCurso, PageSize.A4)

            cell = New PdfPCell 'celda cabecera
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("DATOS CURSO ", FontFactory.GetFont("Arial", 10)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell 'celda cabecera
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("DATOS OTEC ", FontFactory.GetFont("Arial", 10)))
            tableDatosCurso.AddCell(cell)

            'primera fila

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("Horas " & Me.mstrHorasCurso, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(Me.mstrNombreEmpresa, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("Area " & Me.mstrAreaCurso, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(Me.mstrRutOtec, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("Especialidad " & Me.mstrEspecialidadCurso, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("fono: " & Me.mstrFonoOtec, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(" ", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph("e-mail " & Me.mstrMailOtec, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)





            oDoc.Add(tableDatosCurso)


            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try


    End Sub


    Public Sub FichaOtec()


        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText

        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
          FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)
            cb.BeginText()

            '*** TITULO
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            cb.SetFontAndSize(fuente, 16)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_EMPRESA, (PageSize.A4.Width / 2), (PageSize.A4.Height - 50), 0)

            '*** SUBTITULO
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 12)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)

            '*** TITULO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha", 400, (PageSize.A4.Height - 85), 0)

            '*** DATO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Now.Date.ToShortDateString, 450, (PageSize.A4.Height - 85), 0)

            '*** PIE
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_PIE, (PageSize.A4.Width / 2), (PageSize.A4.Height - 650), 0)
            cb.EndText()

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            Dim cell As PdfPCell

            Dim tableFichaOtec As New PdfPTable(4)
            tableFichaOtec.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(3) As Single
            widthsFichaOtec(0) = 79
            widthsFichaOtec(1) = 157
            widthsFichaOtec(2) = 117
            widthsFichaOtec(3) = 117

            tableFichaOtec.SetWidthPercentage(widthsFichaOtec, PageSize.A4)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("FICHA OTEC ", FontFactory.GetFont("Arial", 10)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rut ", FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrRutOtec, FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Fono", FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrFonoOtec, FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Razon social", FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            cell.AddElement(New Paragraph(Me.mstrRazonSocial, FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            'cell = New PdfPCell
            'cell.BorderWidthTop = 0.5
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Fax", FontFactory.GetFont("Arial", 8)))
            'tableFichaOtec.AddCell(cell)

            'cell = New PdfPCell
            'cell.BorderWidthTop = 0.5
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Me.mstrFaxOtec, FontFactory.GetFont("Arial", 8)))
            'tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.AddElement(New Paragraph(" ", FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Email", FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrMailOtec, FontFactory.GetFont("Arial", 8)))
            tableFichaOtec.AddCell(cell)



            oDoc.Add(tableFichaOtec)
            oDoc.Add(New Paragraph(" ")) 'Salto de linea


            Dim tableContactoOtec As New PdfPTable(3)
            tableContactoOtec.TotalWidth = PageSize.A4.Width
            Dim widthsContactoOtec(2) As Single
            widthsContactoOtec(0) = 156
            widthsContactoOtec(1) = 156
            widthsContactoOtec(2) = 156

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("DIRECCION", FontFactory.GetFont("Arial", 10)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("CONTACTO OTEC", FontFactory.GetFont("Arial", 10)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("REPRESENTANTE LEGAL", FontFactory.GetFont("Arial", 10)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrDINombreDireccion, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nombre: " & Me.mstrCONombreContacto, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nombre Rep. 1: " & Me.mstrRLNombreRepresentante1, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrDINombreComuna, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Cargo: " & Me.mstrCOCargoOtec, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rut: " & Me.mstrRLRutRepresentante1, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.mstrDIRegion, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Fono: " & Me.COFonoOtec, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nombre Rep. 2: " & Me.mstrRLNombreRepresentante2, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.DIEmail, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(Me.COEmail, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rut: " & Me.mstrRLRutRepresentante2, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("DATOS CONVENIO", FontFactory.GetFont("Arial", 10)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("ACTIVIDAD", FontFactory.GetFont("Arial", 10)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("OTROS CONTACTOS", FontFactory.GetFont("Arial", 10)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nro convenio: " & Me.mstrDCNroConvenio, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Giro: " & Me.mstrACGiro, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Gerente general: " & Me.mstrOCGerenteGeneral, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Tasa de descuento: " & Me.mstrDCTasaDescuento, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Cod. Act. Economica: " & Me.mstrACCodigoActidadEconomica, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Gerente RRHH: " & Me.mstrOCGerenteRRHH, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("-", FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rubro interno: " & Me.mstrACRubroInterno, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Area cobranza: " & Me.mstrOCAreaCobranza, FontFactory.GetFont("Arial", 8)))
            tableContactoOtec.AddCell(cell)

            oDoc.Add(tableContactoOtec)

            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo


        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub

    Public Sub FichaEmpresa(ByVal strRazonSocial As String, ByVal lngRut As String, ByVal strFonoOtec As String, ByVal strFax As String, _
                           ByVal strEmailOtec As String, ByVal strNombreSucursal As String, ByVal strNombreEjecutivo As String, ByVal strDireccion As String, _
                           ByVal strComuna As String, ByVal strCiudad As String, ByVal strRegion As String, ByVal strSitioWeb As String, _
                           ByVal strNombreContacto As String, ByVal strCargoContacto As String, ByVal strFonoContacto As String, ByVal strAnexoContacto As String, _
                           ByVal strEmailContacto As String, ByVal strNombreRep1 As String, ByVal strRutRep1 As String, ByVal strNombreRep2 As String, _
                           ByVal strRutRep2 As String, ByVal strNumEmpleados As String, ByVal strFranquiciaActual As String, _
                           ByVal strCostoAdm As String, ByVal strGiro As String, ByVal strCodActEconomica As String, ByVal strRubro As String, _
                           ByVal strVentaAnual As String, ByVal strGerenteGeneral As String, ByVal strGerenteRRHH As String, ByVal strEmailGerenteRRHH As String, _
                           ByVal strGerenteFinanzas As String, ByVal strEmailGerenteFinanzas As String, ByVal strAreaCobranzas As String, ByVal strFonoCobranzas As String)

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText

        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
                      FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)
            cb.BeginText()

            '*** TITULO
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            cb.SetFontAndSize(fuente, 16)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_EMPRESA, (PageSize.A4.Width / 2), (PageSize.A4.Height - 50), 0)

            '*** SUBTITULO
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 12)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)

            '*** TITULO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha", 400, (PageSize.A4.Height - 85), 0)

            '*** DATO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Now.Date.ToShortDateString, 450, (PageSize.A4.Height - 85), 0)

            '*** PIE
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_PIE, (PageSize.A4.Width / 2), (PageSize.A4.Height - 650), 0)
            cb.EndText()

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            Dim cell As PdfPCell

            Dim table As New PdfPTable(3)
            table.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(2) As Single
            widthsFichaOtec(0) = 157
            widthsFichaOtec(1) = 157
            widthsFichaOtec(2) = 157

            table.SetWidthPercentage(widthsFichaOtec, PageSize.A4)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("FICHA EMPRESA ", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(strRazonSocial, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Fono: " & strFonoOtec, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Sucursal: " & strNombreSucursal, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rut: " & lngRut, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Email: " & strEmailOtec, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Ejecutivo: " & strNombreEjecutivo, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            'cell = New PdfPCell
            'cell.BorderWidthTop = 0.5
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.Colspan = 3
            'cell.AddElement(New Paragraph("Email: " & strEmailOtec, FontFactory.GetFont("Arial", 8)))
            'table.AddCell(cell)


            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("DIRECCION", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("CONTACTO ABIF", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("REPRESENTANTE LEGAL", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(strDireccion, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Fono: " & strFonoContacto & " - Anexo: " & strAnexoContacto, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nombre 1: " & strNombreRep1, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(strComuna & " - " & strCiudad, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rut 1: " & strRutRep1, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(strRegion, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nombre 2: " & strNombreRep2, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rut 2: " & strRutRep2, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("DATOS FRANQUICIA TRIBUTARIA", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("ACTIVIDAD", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("OTROS CONTACTOS", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Giro: " & strNumEmpleados, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Nº Empleados: " & strGiro, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Gerente general: " & strGerenteGeneral, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Franquicia Actual: " & strFranquiciaActual, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Cod.Act.Economica: " & strCodActEconomica, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Gerente RRHH: " & strGerenteRRHH, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)


            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Tasa Admin. Aportes: " & strCostoAdm, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rubro Interno: " & strRubro, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Email Gerente RRHH: " & strEmailGerenteRRHH, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Venta Neta Anual: " & strVentaAnual, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Gerente Finanzas: " & strGerenteFinanzas, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Email Gerente Finanzas: " & strEmailGerenteFinanzas, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Area Cobranzas: " & strAreaCobranzas, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Fono Cobranzas: " & strFonoCobranzas, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            oDoc.Add(table)

            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub

    Public Sub FichaCursoInterno(ByVal strRutUsuario As String, ByVal strRazonSocial As String, ByVal strDireccionCurso As String, ByVal strNombreComuna As String, _
                                 ByVal strNomRegion As String, ByVal strCorrelativo As String, ByVal strNombreEstadoCurso As String, ByVal strNombreCurso As String, _
                                 ByVal strEjecutor As String, ByVal strNumAlumnos As String, ByVal strCorrEmpresa As String, ByVal strHorario As String, _
                                 ByVal strHoras As String, ByVal strObservacion As String, ByVal strValorCurso As String)

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText

        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
                      FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()

            'Dim banner As Image
            'banner = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "contenido\imagenes\empresa\bannerup.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            'banner.ScalePercent(60.0F)
            'banner.SetAbsolutePosition(0, PageSize.A4.Height - 70)
            'cb.AddImage(banner)

            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)


            ''*** TITULO
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            'cb.SetFontAndSize(fuente, 16)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ASIMET CAPACITACION", (PageSize.A4.Width / 2), (PageSize.A4.Height - 50), 0)

            '*** SUBTITULO
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 12)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)

            '*** TITULO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha", 400, (PageSize.A4.Height - 85), 0)

            '*** DATO FECHA
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Now.Date.ToShortDateString, 450, (PageSize.A4.Height - 85), 0)

            '*** PIE
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
            'cb.SetFontAndSize(fuente, 6)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Parametros.p_PIE, (PageSize.A4.Width / 2), (PageSize.A4.Height - 650), 0)
            'cb.EndText()

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            
            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            Dim cell As PdfPCell

            Dim table As New PdfPTable(2)
            table.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(1) As Single
            widthsFichaOtec(0) = 275
            widthsFichaOtec(1) = 275
            ' widthsFichaOtec(2) = 117

            table.SetWidthPercentage(widthsFichaOtec, PageSize.A4)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("FICHA CURSO NO SENCE ", FontFactory.GetFont("Arial", 10)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Rut: " & strRutUsuario, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("DirecciOn: " & strDireccionCurso, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("RazOn social: " & strRazonSocial, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Comuna: " & strNombreComuna, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Ciudad: " & strNomRegion, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            oDoc.Add(table)

            Dim table2 As New PdfPTable(4)
            table2.TotalWidth = PageSize.A4.Width
            Dim widthsFichaInterno2(3) As Single
            widthsFichaInterno2(0) = 90
            widthsFichaInterno2(1) = 200
            widthsFichaInterno2(2) = 200
            widthsFichaInterno2(3) = 60

            table2.SetWidthPercentage(widthsFichaInterno2, PageSize.A4)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("CORRELATIVO", FontFactory.GetFont("Arial", 10)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("CURSO Y OTEC", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.AddElement(New Paragraph("COSTOS", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Correlativo: " & strCorrelativo, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Curso: " & strNombreCurso, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("NUmero interno: " & strCorrEmpresa, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("$" & strValorCurso, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Estado: " & strNombreEstadoCurso, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Otec: " & strEjecutor, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Horario: " & strHorario, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)


            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Alumnos: " & strNumAlumnos, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Horas: " & strHoras, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("Observaciones: " & strObservacion, FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table2.AddCell(cell)


            oDoc.Add(table2)


            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo


        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try

    End Sub
    Public Sub CartaCursoInterno(ByVal dtAlumnos As DataTable, ByVal NombreContacto As String, ByVal Correlativo As String, ByVal EstadoCurso As String, _
                                 ByVal FechaImp As String, ByVal TNombre As String, ByVal TCorrelativo As String, ByVal TFechaInicio As String, _
                                 ByVal TFechaTermino As String, ByVal TDuracion As String, ByVal CursoDirecc As String, ByVal Comuna As String, _
                                 ByVal TEmpresa As String, ByVal TRutEmpresa As String, ByVal Fono As String, ByVal Observacion As String, _
                                 ByVal TParticipantes As String, ByVal TDescuento As String, ByVal TValorFinal As String, ByVal DireccionEmpresa As String, _
                                 ByVal Giro As String, ByVal ComunaEmpresa As String)

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 10.0F, 10.0F, 50.0F, 30.0F)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText
        Dim dr As DataRow
        Dim ColorAzul = New BaseColor(0, 174, 199)
        Dim ColorGris = New BaseColor(0, 174, 199) 'BaseColor(50, 224, 249)

        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
                      FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)

            '****************CABECERA***************************

            Dim cell As PdfPCell

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            Dim table As New PdfPTable(4)
            table.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(3) As Single
            widthsFichaOtec(0) = 40
            widthsFichaOtec(1) = 295
            widthsFichaOtec(2) = 133
            widthsFichaOtec(3) = 72

            table.SetWidthPercentage(widthsFichaOtec, PageSize.A4)

            cell = New PdfPCell(New Phrase("ORDEN DE COMPRA", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.BackgroundColor = ColorAzul
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("SRES. ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(NombreContacto, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("ORDEN DE COMPRA: ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(Correlativo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("ESTADO CURSO: ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(EstadoCurso.ToUpper, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(FechaImp, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            oDoc.Add(table)


            '****************DATOS ALUMNOS***************************

            Dim table2 As New PdfPTable(3)
            table2.TotalWidth = PageSize.A4.Width
            Dim widthsCartaEmp(2) As Single
            widthsCartaEmp(0) = 106
            widthsCartaEmp(1) = 302
            widthsCartaEmp(2) = 132

            table2.SetWidthPercentage(widthsCartaEmp, PageSize.A4)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            table2.AddCell(cell)


            cell = New PdfPCell(New Phrase("DE NUESTRA CONSIDERACION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("A TRAVÉS DE LA PRESENTE,SOLICITO A USTED INSCRIBIR LA SIGUIENTE NÓMINA DE ALUMNOS EN EL CURSO QUE SE DETALLA A CONTINUACIÓN SEGÚN LO ORDENADO POR NUESTRO CLIENTE:", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("DATOS ALUMNOS", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.Colspan = 3
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("RUT", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table2.AddCell(cell)



            For Each dr In dtAlumnos.Rows
                cell = New PdfPCell(New Phrase(dr("rut").ToUpper, FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table2.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("nombre"), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                table2.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(dr("total_costo_alumno")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                table2.AddCell(cell)

            Next

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table2.AddCell(cell)

            oDoc.Add(table2)

            Dim table3 As New PdfPTable(4)
            table2.TotalWidth = PageSize.A4.Width
            Dim widthstable3(3) As Single
            widthstable3(0) = 116
            widthstable3(1) = 252
            widthstable3(2) = 92
            widthstable3(3) = 80

            table3.SetWidthPercentage(widthstable3, PageSize.A4)

            cell = New PdfPCell(New Phrase("CURSO", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.Colspan = 4
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("DATOS DEL CURSO", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("VALORES ASOCIADOS", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("NOMBRE CURSO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TNombre, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("PARTICIPANTES", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TParticipantes, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table3.AddCell(cell)

            '**
            cell = New PdfPCell(New Phrase("CORRELATIVO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TCorrelativo, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("DESCUENTO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TDescuento, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table3.AddCell(cell)

            '**
            cell = New PdfPCell(New Phrase("FECHA INICIO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TFechaInicio, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("VALOR TOTAL", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TValorFinal, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table3.AddCell(cell)

            '**
            cell = New PdfPCell(New Phrase("FECHA FIN", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TFechaTermino, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("* INCLUYE VIÁTICOS Y TRASLADOS", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 0
            'cell.PaddingTop = 0
            'cell.HorizontalAlignment = Element.ALIGN_LEFT
            'table3.AddCell(cell)

            '**
            cell = New PdfPCell(New Phrase("DURACIÓN", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TDuracion & " HRS.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            '**
            cell = New PdfPCell(New Phrase("LUGAR DE EJECUCIÓN", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(CursoDirecc & " - " & Comuna, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            '**
            cell = New PdfPCell(New Phrase("OBSERVACIÓN", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(Observacion, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)


            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 0
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("FACTURACIÓN", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.Colspan = 4
            table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase("OTIC DE LA BANCA", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0.5
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.BackgroundColor = ColorGris
            'cell.Colspan = 4
            'cell.HorizontalAlignment = Element.ALIGN_CENTER
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase(Parametros.p_NOMBREEMPRESALARGO.ToUpper, FontFactory.GetFont("Arial", 7)))
            'cell.Colspan = 3
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase("RUT", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase(Parametros.p_RUTEMPRESA.ToUpper, FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.Colspan = 3
            'table3.AddCell(cell)

            ''2 fila

            'cell = New PdfPCell(New Phrase("DIRECCION", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase(Parametros.p_DIRECIONEMPRESA.ToUpper, FontFactory.GetFont("Arial", 7)))
            'cell.Colspan = 3
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)


            ''3fila

            'cell = New PdfPCell(New Phrase("GIRO", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase(Parametros.p_GIROEMPRESA.ToUpper, FontFactory.GetFont("Arial", 7)))
            'cell.Colspan = 3
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            ''4 fila

            'cell = New PdfPCell(New Phrase("FONO", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase(Parametros.p_FONOEMPRESA, FontFactory.GetFont("Arial", 7)))
            'cell.Colspan = 3
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase("COSTO ", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)

            'cell = New PdfPCell(New Phrase("$0", FontFactory.GetFont("Arial", 7)))
            'cell.Colspan = 3
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'table3.AddCell(cell)


            cell = New PdfPCell(New Phrase("EMPRESA", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TEmpresa.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("RUT", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TRutEmpresa.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 3
            table3.AddCell(cell)

            '2 fila

            cell = New PdfPCell(New Phrase("DIRECCION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(DireccionEmpresa.ToUpper & ", " & ComunaEmpresa, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)


            '3fila

            cell = New PdfPCell(New Phrase("GIRO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(Giro, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            '4 fila

            cell = New PdfPCell(New Phrase("FONO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(Fono, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)

            cell = New PdfPCell(New Phrase(TValorFinal, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table3.AddCell(cell)




            cell = New PdfPCell
            cell.Border = 0
            cell.Colspan = 4
            Dim banner2 As Image
            banner2 = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "contenido\imagenes\empresa\firma_gerente_pdf.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            banner2.Alignment = Element.ALIGN_CENTER

            Dim percentage As Single = 0.0F
            percentage = parametros.p_TAMANOFIRMA / banner2.Width
            banner2.ScalePercent(percentage * 100)
            'banner2.ScaleAbsoluteWidth(182)
            'banner2.ScaleAbsoluteHeight(106.4)
            cell.AddElement(banner2)
            table3.AddCell(cell)

            oDoc.Add(table3)




            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

            mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo


        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub

    Public Sub CartaEmpresa(ByVal dtAlumnos As DataTable, ByVal lngCodCurso As Long, ByVal strModalidad As String, ByVal strClienteNombreContacto As String, ByVal strClienteCargoContacto As String, _
                            ByVal strClienteRazonSocial As String, ByVal lngCorrelativo As String, ByVal strCorrelativoEmpresa As String, _
                            ByVal strEstadoCurso As String, ByVal strNombreCurso As String, ByVal lngCorrelativo2 As String, _
                            ByVal dtmFechaInicio As String, ByVal dtmFechaTermino As String, ByVal strDuracionCurso As String, _
                            ByVal strDireccionCurso As String, ByVal strNroDireccion As String, ByVal strNombreComunaCurso As String, _
                            ByVal intHorasComplementarias As Integer, ByVal strCodSence As String, ByVal strRazonSocialOtec As String, _
                            ByVal intParticipantes As String, ByVal strIndAcuComBip As String, ByVal strObservacion As String, _
                            ByVal lngValorCurso As String, ByVal lngCostoOtic As String, ByVal lngCostoOticCompl As String, _
                            ByVal lngGastoEmpresa As String, ByVal lngTotalVyT As String, ByVal lngCostoOticVyT As String, _
                            ByVal lngGastoEmpVyT As String, ByVal lngCuentaCap As String, ByVal lngCuentaExcCap As String, _
                            ByVal lngBecas As String, ByVal lngTerceros As String, ByVal strNombreOtic As String, ByVal lngNroRegistro As String, _
    ByVal strLunes As String, ByVal strMartes As String, ByVal strMiercoles As String, ByVal strJueves As String, ByVal strViernes As String, _
    ByVal strSabado As String, ByVal strDomingo As String, ByVal strCodTipoActividad As String, ByVal strNombreEjecutivo As String, _
    ByVal strFechaImp As String, ByVal lngCodCursoParcial As String, ByVal lngCodCursoCompl As String, Optional ByVal strValorHora As String = "", _
        Optional ByVal strCorrelativoEmp As String = "")

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 10.0F, 10.0F, 50.0F, 30.0F)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText
        Dim dr As DataRow

        Dim ColorAzul = New BaseColor(0, 174, 199)
        Dim ColorGris = New BaseColor(0, 174, 199) 'BaseColor(50, 224, 249)
        'Dim colorAzulOscuro = New BaseColor(17, 9, 59)


        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
                      FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)



            ''*** SUBTITULO
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'cb.SetFontAndSize(fuente, 12)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)



            'oDoc.Add(New Paragraph(" ")) 'Salto de linea


            Dim cell As PdfPCell

            Dim table As New PdfPTable(4)
            table.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(3) As Single
            widthsFichaOtec(0) = 145
            widthsFichaOtec(1) = 135
            widthsFichaOtec(2) = 115
            widthsFichaOtec(3) = 145

            table.SetWidthPercentage(widthsFichaOtec, PageSize.A4)


            If lngCodCursoParcial <> -1 Then
                cell = New PdfPCell(New Phrase("CORRELATIVO O/C " & lngCorrelativo & " - COMPLEMENTARIO", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 4
                cell.BackgroundColor = ColorAzul
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table.AddCell(cell)
            ElseIf lngCodCursoCompl <> -1 Then
                cell = New PdfPCell(New Phrase("CORRELATIVO O/C " & lngCorrelativo & " - PARCIAL", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 4
                cell.BackgroundColor = ColorAzul
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table.AddCell(cell)
            Else
                cell = New PdfPCell(New Phrase("CORRELATIVO O/C " & lngCorrelativo, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 4
                cell.BackgroundColor = ColorAzul
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table.AddCell(cell)
            End If



            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            cell = New PdfPCell(New Phrase("SRES. " & strClienteNombreContacto.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("Nº REGISTRO SENCE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngNroRegistro, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strClienteCargoContacto.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 2
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase("ESTADO CURSO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strEstadoCurso.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)


            'cuarta fila

            cell = New PdfPCell(New Phrase(strClienteRazonSocial.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase("TIPO ACTIVIDAD", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strCodTipoActividad.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("RESPONSABLE OTIC", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strNombreEjecutivo.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            'quinta fila

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("FECHA", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strFechaImp, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            'sexta fila

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("CORRELATIVO EMP.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strCorrelativoEmp, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            oDoc.Add(table)

            '**********************************




            '*********************************************************************************
            '*********************************************************************************
            '*********************************************************************************
            Dim table2 As New PdfPTable(4)
            table2.TotalWidth = PageSize.A4.Width
            Dim widthsCartaEmp(3) As Single
            widthsCartaEmp(0) = 95
            widthsCartaEmp(1) = 235
            widthsCartaEmp(2) = 135
            widthsCartaEmp(3) = 75

            table2.SetWidthPercentage(widthsCartaEmp, PageSize.A4)


            cell = New PdfPCell(New Phrase("DE NUESTRA CONSIDERACION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("A TRAVES DEL PRESENTE DOCUMENTO INFORMO A USTED QUE DE ACUERDO A SUS INSTRUCCIONES, HEMOS CONTRATADO PARA SU EMPRESA EL CURSO QUE SE DETALLA A CONTINUACION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            table2.AddCell(cell)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            cell = New PdfPCell(New Phrase("CURSO INSCRITO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.BackgroundColor = ColorAzul
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("DATOS DEL CURSO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("VALORES ASOCIADOS", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strNombreCurso.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("VALOR CURSO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngValorCurso, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("MODALIDAD", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strModalidad.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO OTIC", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngCostoOtic, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("CORRELATIVO O/C", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngCorrelativo2, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO OTIC COMPLEMENTARIO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngCostoOticCompl, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("FECHA INICIO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(dtmFechaInicio, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO EMPRESA", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngGastoEmpresa, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("FECHA TERMINO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(dtmFechaTermino, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("TOTAL VYT", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngTotalVyT, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("DURACION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strDuracionCurso & " HRS. (" & intHorasComplementarias & " HRS. COMPLEMENTARIAS)", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO OTIC VYT", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngCostoOticVyT, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("CODIGO SENCE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strCodSence, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO EMPRESA VYT", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngGastoEmpVyT, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("Nº REGISTRO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngNroRegistro, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("LUGAR DE EJECUCION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strDireccionCurso.ToUpper & " " & strNroDireccion.ToUpper & " - " & strNombreComunaCurso.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("ORGANISMO EJECUTOR", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strRazonSocialOtec.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.Colspan = 2
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("Nº PARTICIPANTES", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(intParticipantes, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngCuentaCap, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("COMITE BIPARTITO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strIndAcuComBip.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngCuentaExcCap, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)



            cell = New PdfPCell(New Phrase("VALOR HORA SENCE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(strValorHora.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)

            cell = New PdfPCell(New Phrase(lngCuentaExcCap, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table2.AddCell(cell)


            oDoc.Add(table2)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            Dim tableHorario As New PdfPTable(7)
            tableHorario.TotalWidth = PageSize.A4.Width
            Dim widthshorario(6) As Single
            widthshorario(0) = 77
            widthshorario(1) = 77
            widthshorario(2) = 77
            widthshorario(3) = 77
            widthshorario(4) = 77
            widthshorario(5) = 77
            widthshorario(6) = 77
            tableHorario.SetWidthPercentage(widthshorario, PageSize.A4)
            tableHorario.SplitRows = True

            'cabecera
            cell = New PdfPCell(New Phrase("HORARIO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 7
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul 'iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            'cabecera
            cell = New PdfPCell(New Phrase("LUNES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("MARTES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("MIERCOLES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("JUEVES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("VIERNES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris ' iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("SABADO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("DOMINGO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            ' primera fila

            cell = New PdfPCell(New Phrase(Replace(strLunes, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strMartes, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strMiercoles, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strJueves, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strViernes, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strSabado, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strDomingo, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)


            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 7
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 7)))
            tableHorario.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph("OBSERVACION", FontFactory.GetFont("Arial", 7)))
            tableHorario.AddCell(cell)


            cell = New PdfPCell
            cell.Colspan = 6
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.AddElement(New Paragraph(strObservacion.ToUpper, FontFactory.GetFont("Arial", 7)))
            tableHorario.AddCell(cell)
            oDoc.Add(tableHorario)


            '************************************************************************
            '************************************************************************
            '************************************************************************

            Dim tableAlumnos As New PdfPTable(9)
            tableAlumnos.TotalWidth = PageSize.A4.Width
            Dim widthsAlumnos(8) As Single
            widthsAlumnos(0) = 170
            widthsAlumnos(1) = 65
            widthsAlumnos(2) = 45
            widthsAlumnos(3) = 50
            widthsAlumnos(4) = 40
            widthsAlumnos(5) = 50
            widthsAlumnos(6) = 40
            widthsAlumnos(7) = 60
            widthsAlumnos(8) = 20



            tableAlumnos.SetWidthPercentage(widthsAlumnos, PageSize.A4)

            Dim texto3 As String = "En la siguiente tabla se presenta el listado de alumnos que se inscribieron en el curso, de acuerdo a la informaciOn proporcionada por usted: "

            cell = New PdfPCell(New Phrase(texto3.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)

            Dim par3 As String = "LISTADO DE ALUMNOS" ', FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            cell = New PdfPCell(New Phrase(par3, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            cell.BackgroundColor = ColorAzul
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)


            Dim par33 As String = "DATOS ALUMNO" ', FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            cell = New PdfPCell(New Phrase(par33.ToUpper, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)



            Dim par34 As String = "FRANQUICIA" ', FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            cell = New PdfPCell(New Phrase(par34.ToUpper, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)


            Dim par35 As String = "COSTOS" ', FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            cell = New PdfPCell(New Phrase(par35.ToUpper, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)


            Dim par36 As String = "VYT" ', FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            cell = New PdfPCell(New Phrase(par36.ToUpper, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)


            Dim par37 As String = "NIVELES" ', FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            cell = New PdfPCell(New Phrase(par37.ToUpper, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorGris
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            For Each dr In dtAlumnos.Rows
                cell = New PdfPCell(New Phrase(dr("nombre_completo").ToUpper, FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("FRANQUICIA ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("porc_franquicia"), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("OTIC ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(dr("costo_otic")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.HorizontalAlignment = cell.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("VIATICO ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(dr("viatico")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.HorizontalAlignment = cell.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("NIVEL EDUC. ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("cod_nivel_educ"), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("RUT " & RutLngAUsr(dr("rut_alumno")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("SEXO ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("sexo").ToUpper, FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("EMP. ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(dr("gasto_empresa")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.HorizontalAlignment = cell.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("TRASLADO ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(dr("traslado")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.HorizontalAlignment = cell.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("NIVEL OCUP. ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("cod_nivel_ocup"), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("FECHA NAC. ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("fecha_nacim"), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("TOTAL ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(CLng(dr("costo_otic")) + CLng(dr("gasto_empresa"))), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.HorizontalAlignment = cell.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 2
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase("REGION ", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("cod_region"), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                tableAlumnos.AddCell(cell)


            Next

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("NIVEL EDUCACIONAL: 1 - SIN ESCOLARIDAD, 2 - LICENCIA BASICA INCOMPLETA, 3 - LICENCIA BASICA INCOMPLETA, 4 - LICENCIA MEDIA INCOMPLETA, 5 - LICENCIA MEDIA COMPLETA, 6 SUPERIOR TECNICA PROFESIONAL INCOMPLETA, 7 - SUPERIOR TECNICA PROFESIONAL COMPLETA, 8 - UNIVERSITARIO INCOMPLETO, 9 - UNIVERSITARIO COMPLETO", FontFactory.GetFont("Arial", 5)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("NIVEL OCUPACIONAL: 1 - EJECUTIVOS, 2 - PROFESIONALES, 3 - MANDOS MEDIOS, 4 - ADMINISTRATIVOS, 5 - TRABAJO CALIFICADO, 6 - TRABAJO SEMI CALIFICADO, 7 - TRABAJO NO CALIFICADO", FontFactory.GetFont("Arial", 5)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)



            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 5)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)



            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 5)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            tableAlumnos.AddCell(cell)



            cell = New PdfPCell(New Phrase("QUEDANDO A SU ENTERA DISPOSICION PARA ACLARAR CUALQUIER DUDA.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("SALUDA ATENTAMENTE A USTED.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)


            cell = New PdfPCell
            cell.Border = 0
            cell.Colspan = 9
            Dim banner2 As Image
            banner2 = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "contenido\imagenes\empresa\firma_gerente_pdf.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            banner2.Alignment = Element.ALIGN_CENTER

            Dim percentage As Single = 0.0F
            percentage = Parametros.p_TAMANOFIRMA / banner2.Width
            banner2.ScalePercent(percentage * 100)
            'banner2.ScaleAbsoluteWidth(182)
            'banner2.ScaleAbsoluteHeight(106.4)
            'banner2.ScalePercent(50.0F)
            cell.AddElement(banner2)
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 9
            cell.FixedHeight = 5
            cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 7)))
            tableAlumnos.AddCell(cell)






            oDoc.Add(tableAlumnos)






            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

            mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo


        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub

    Public Sub AFinSemana(ByVal dtAlumnos As DataTable, ByVal strFechaInicio As String, ByVal strFechaFin As String, _
                                  ByVal strCodigoSence As String, ByVal strRegistroSence As String, ByVal StrNombreEmpresa As String, _
                                     ByVal strRutEmpresa As String, ByVal strAgno As String, ByVal strDireccionEmpresa As String, _
                                        ByVal strComunaEmpresa As String)

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 10.0F, 10.0F, 50.0F, 30.0F)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText
        Dim dr As DataRow

        Dim ColorAzul = New BaseColor(0, 174, 199)
        Dim ColorGris = New BaseColor(0, 174, 199) 'BaseColor(50, 224, 249)

        Dim fechaInicio As Date
        If CDate(strFechaInicio) < Now.Date Then
            fechaInicio = strFechaFin
        Else
            fechaInicio = Now.Date
        End If


        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
                      FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)



            ''*** SUBTITULO
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'cb.SetFontAndSize(fuente, 12)
            'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)



            'oDoc.Add(New Paragraph(" ")) 'Salto de linea


            Dim cell As PdfPCell

            Dim table As New PdfPTable(4)
            table.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(3) As Single
            widthsFichaOtec(0) = 145
            widthsFichaOtec(1) = 135
            widthsFichaOtec(2) = 115
            widthsFichaOtec(3) = 145

            table.SetWidthPercentage(widthsFichaOtec, PageSize.A4)






            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            cell = New PdfPCell(New Phrase("Acuerdo Actividades de Capacitacion en días festivos o Fines de Semana ", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase("En Santiago a " & Day(fechaInicio) & " de " & MesIntAUsr(Month(fechaInicio)) & " de " & strAgno & ", entre " _
                                            & StrNombreEmpresa & ", R.U.T. " & strRutEmpresa & " ubicado en " & strDireccionEmpresa & ", " _
                                            & "comuna de " & strComunaEmpresa & ", en adelante 'el Empleador' y los señores (as) mencionados en " _
                                            & "detalle adjunto, 'Trabajador (es)', se ha celebrado el siguiente acuerdo de " _
                                            & "capacitación en días festivos o fines de semana, cuyo objetivo es entregar a los " _
                                            & "trabajadores las herramientas y habilidades necesarias para el ejercicio de sus labores.", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            table.AddCell(cell)



            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            table.AddCell(cell)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            cell = New PdfPCell(New Phrase("Fecha Inicio", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("Fecha Termino", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("Código Sence", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("Registro Sence", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strFechaInicio, FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strFechaFin, FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase(strCodigoSence, FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strRegistroSence, FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase("Se deja estipulada la voluntad concordante de las partes individualizadas para la " _
                                            & "realización de esta actividad en las circunstancias anteriormente citadas.", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("RUT", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("FIRMA", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)


            For Each dr In dtAlumnos.Rows
                cell = New PdfPCell(New Phrase(RutLngAUsr(dr("rut_alumno")), FontFactory.GetFont("Arial", 12)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.MinimumHeight = 50
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("nombre"), FontFactory.GetFont("Arial", 12)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 2
                cell.MinimumHeight = 50
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table.AddCell(cell)

                cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.MinimumHeight = 50
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                table.AddCell(cell)
            Next

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 12)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(StrNombreEmpresa, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strRutEmpresa, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 4
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            oDoc.Add(table)

            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

            mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo


        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub



End Class
