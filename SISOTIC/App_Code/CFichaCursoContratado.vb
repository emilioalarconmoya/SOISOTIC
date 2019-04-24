Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CFichaCursoContratado
    Implements IReporte
#Region "Declaraciones"

    Private objSession As New CSession
    'consultas sql y objetos de conexion
    Private mblnBajarXml As Boolean
    Private mstrXml As String
    Private mlngFilas As Long
    'objeto de coneccion a bd y de implements ireporte
    Private mobjSql As CSql

    Private mlngRutUsuario As Long
    Private mlngCodCurso As Long
    Private mlngCorrelativo As Long
    Private mlngCodElearning As Long
    Private mlngNroRegistro As Long
    Private mlngNumPerfil As Long
    Private mstrCodSence As String
    Private mlngRutCliente As Long
    Private mintCodTipoActivo As Integer
    Private mintCodEstadoCurso As Integer
    Private mintCodUltEstadoCurso As Integer
    Private mlngAgno As Long
    Private mdtmFechaInicio As Date
    Private mdtmFechaTermino As Date
    Private mdtmFechaIngreso As Date
    Private mdtmFechaModificacion As Date
    Private mlngValorMercado As Long
    Private mlngDescuento As Long
    Private mintIndDescPorc As Integer
    Private mdblPorcAdm As Double
    Private mlngCostoOtic As Long
    Private mlngCostoAdm As Double
    Private mlngGastoEmpresa As Long

    '--------------------Viatico y traslado ---------------------
    'Costo Otic de viaticos y traslado
    Private mlngCostoOticVYT
    'Costo de Administracion de Viaticos y traslado
    Private mlngCostoAdmVYT As Long
    'Gasto de la Empresa de Viaticos y traslado
    Private mlngGastoEmpresaVYT As Long
    '------------------------------------------------------------
    'Valor total del Viatico
    Private mlngTotalViatico As Long
    'Valor Total del traslado
    Private mlngTotalTraslado As Long
    'Indica si el cliente posee Adm. No Lineal
    Private mintAdmNoLineal As Integer
    Private mstrDireccionCurso As String
    Private mlngCodComuna As Long
    Private mlngCodRegion As Long
    Private mstrNomRegion As String
    Private mstrNomComuna As String
    'Código del atributo
    Private mintCodOrigen As Integer
    Private mstrObsCurso As String
    'Valor total al momento de liquidar
    Private mlngValorComunicado As Long
    'Observaciones de la liquidacion
    Private mstrObsLiquidacion As String
    'Horas de duracion del curso
    Private mlngHoras As Long
    'Horas complementarias del curso, si existen
    Private mlngHorasCompl As Long
    'Comité Bipartito
    Private mintIndAcuComBip As Integer
    'Indicador de deteccion de necesidades
    Private mintIndDetNece As Integer
    Private mintNroFacturaOtec As Integer
    Private mdtmFechaPagoFactura As Date
    Private mlngCodCursoCompl As Long
    Private mlngCodCursoParcial As Long
    Private mstrCorrEmpresa As String
    'Contacto y Observaciones Adicionales
    Private mstrContactoAdicional As String
    Private mstrObservacion As String
    Private mlngNumAlumnos As Long
    'Fecha del Comunicacion del Curso
    Private mdtmFechaComunicacion As Date
    'Fecha del Liquidacion del Curso
    Private mdtmFechaLiquidacion As Date
    'Numero de Modificaciones que se le hacen a un Curso
    Private mintNumModificaciones As Integer
    'Numero de Maximo Participantes del curso
    Private mlngMaxParticipantes As Long
    Private marrComunas As Object
    'Arreglo con los tipos de actividad
    Private marrTiposActiv As Object
    'Arreglo con las solicitudes de terceros y su información
    Private marrListaTerceros As Object
    Private mstrNombreModalidad As String
    '----------------------------------------------------------------
    'Los siguientes no se bien si sean parte de este objeto.
    'Por el momento los voy a poner aqui
    'Saldo de la cuenta de capacitacion de la Empresa
    Private mlngSaldoCtaCap As Long
    'Saldo de la cuenta de excedentes de capacitacion de la Empresa
    Private mlngSaldoCtaExcCap As Long
    Private mlngSaldoCtaBecas As Long
    '----------------------------------------------------------------
    'Monto que se carga a la cuenta de capacitacion de la Empresa
    Private mlngMontoCtaCap As Long
    'Monto que se carga a la cuenta de excedentes de capacitacion de la Empresa
    Private mlngMontoCtaExcCap As Long
    'Total del monto SOLICITADO a terceros para el pago de un curso
    Private mlngTotMontoTerc As Long
    '------------------------- Viaticos y traslado ------------------
    'Monto que se carga a la cuenta de capacitacion de la Empresa por viatico y traslado
    Private mlngMontoCtaCapVYT As Long
    'Monto que se carga a la cuenta de excedentes de capacitacion de la Empresa por viatico y traslado
    Private mlngMontoCtaExcCapVYT As Long
    '-----------------------------------------------------------------
    'Monto que se carga a la cuenta Becas (Exedentes de 2 años, sólo para cursos complementarios)
    Private mlngMontoCtaBecas As Long
    'total del monto a terceros en la tabla de transacciones, es decir, los montos
    'solicitados que no han sido aprobados o rechazados y los montos autorizados
    Private mlngMontoTercTran As Long
    Private mlngMontoRep As Long
    Private mlngMontoExcRep As Long
    ''Objeto OTEC
    'Private mobjOtec As cOtec
    ''Objeto Cliente
    Private objCliente As CCliente
    ''Objeto Factura
    Private objFactura As CFactura
    ''Arreglo de ruts de terceros y monto de sus respectivas cooperaciones
    Private marrTerceros As Object
    ''Arreglo que me indica si los datos de los montos se insertan(1) o actualizan(2)
    Private marrModifCuentas()
    ''Declaracion de un objeto curso
    Private objCurso As CCurso
    ''Declaracion de un curso complementario
    'Private mobjCursoCompl As cCursoContratado
    'Declaracion de un arreglo de Horarios
    Private marrHorarioCurso()
    'Declaracion de un arreglo de Alumnos
    Private marrAlumnos()
    'Declaracion de un arreglo de Solicitudes
    Private marrSolicitudes()
    'Indica si calcular un nuevo correlativo, se usa para no generar un nuevo correlativo en el primer curso e-learning
    Private mblnGenerarNuevoCorr As Boolean
    'Correlativo del curso originar, para asignarlo al primer curso e-learning generado
    Private mlngCorrElearning As Long
    'Inidica si los montos de las solicitudes se deben modificar (true) o se debe ingresar una en estado pendiente
    Private mblnModificarMontoSolicitudes As Boolean
    'datos adicionales del curso, para la ficha del curso
    Private mlngCorrelativoComplemento As Long
    Private mintEstadoComplemento As Integer
    Private mlngCostoOticComplemento As Long
    Private mlngCostoAdmComplemento As Long
    Private mlngGastoEmpresaComplemento As Long
    'modalidad
    Private marrModalidades As Object
    Private mlngCodModalidad As Long
    Private mstrEsComplementario As String
    '-----------------------------------------------
    Private mstrNroDireccionCurso As String
    Private mstrCiudad As String
    Private mstrEtiquetaClasificador As String
    Private mstrNombreCurso As String
    Private mlngRutOtec As Long
    Private mstrRazonSocialOtec As String
    Private mstrEmailOtec As String
    Private mlngFonoOtec As Long
    Private mlngFaxOtec As Long
    Private mstrNombreContacto As String
    Private mstrCargoContacto As String
    Private mstrEmailContacto As String
    Private mlngFonoContacto As Long
    Private mlngfaxContacto As Long
    Private mblnTieneCursoComplementario As Boolean
    Private mstrRazonSocial As String
    'Private mstrCargoContacto As String
    Private mstrFonoContacto As String
    Private mstrFaxContacto As String
    Private mstrEmail As String
    Private mstrNombreOtec As String
    Private mstrRutOtec As Long
    Private mstrContactoOtec As String
    Private mstrCargoContactoOtec As String
    Private mstrFonoContactoOtec As String
    Private mstrFaxContactoOtec As String
    Private mstrEmailContactoOtec As String
    'Private mstrNombreCurso As String
    Private mstrNombreComuna As String
    Private mlngTotalCostoOtec As Long
    Private mlngTotalGastoEmpresa As Long
    Private mlngTotalCostoAdmin As Long
    Private mlngHorasParciales As Long
    Private mstrEstadoCursoComplemetario As String
    Private mdtParticipantes As DataTable

    Private mstrDirecccionEmpresa As String
    Private mstrComunaEmpresa As String

    Private mdtBitacoraComentarios As DataTable
    Private mblnEsFinDeSemana As Boolean


#End Region
#Region "propiedades"

    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return Me.mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXml = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property
    Property RutUsuario() As Long
        Get
            Return Me.mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            Me.mlngRutUsuario = value
        End Set
    End Property
    Public Property CodCurso() As Long
        Get
            Return Me.mlngCodCurso
        End Get
        Set(ByVal value As Long)
            Me.mlngCodCurso = value
        End Set
    End Property
    Property Correlativo() As Long
        Get
            Return Me.mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            Me.mlngCorrelativo = value
        End Set
    End Property
    Property CodElearning() As Long
        Get
            Return Me.mlngCodElearning
        End Get
        Set(ByVal value As Long)
            Me.mlngCodElearning = value
        End Set
    End Property
    Property NroRegistro() As Long
        Get
            Return Me.mlngNroRegistro
        End Get
        Set(ByVal value As Long)
            Me.mlngNroRegistro = value
        End Set
    End Property
    Property NumPerfil() As Long
        Get
            Return Me.mlngNumPerfil
        End Get
        Set(ByVal value As Long)
            Me.mlngNumPerfil = value
        End Set
    End Property
    Property CodSence() As String
        Get
            Return Me.mstrCodSence
        End Get
        Set(ByVal value As String)
            Me.mstrCodSence = value
        End Set
    End Property
    Property RutCliente() As Long
        Get
            Return Me.mlngRutCliente
        End Get
        Set(ByVal value As Long)
            Me.mlngRutCliente = value
        End Set
    End Property
    Property CodTipoActivo() As Integer
        Get
            Return Me.mintCodTipoActivo
        End Get
        Set(ByVal value As Integer)
            Me.mintCodTipoActivo = value
        End Set
    End Property
    Property CodEstadoCurso() As Integer
        Get
            Return Me.mintCodEstadoCurso
        End Get
        Set(ByVal value As Integer)
            Me.mintCodEstadoCurso = value
        End Set
    End Property
    Property CodUltEstadoCurso() As Integer
        Get
            Return Me.mintCodUltEstadoCurso
        End Get
        Set(ByVal value As Integer)
            Me.mintCodUltEstadoCurso = value
        End Set
    End Property
    Property Agno() As Long
        Get
            Return Me.mlngAgno
        End Get
        Set(ByVal value As Long)
            Me.mlngAgno = value
        End Set
    End Property
    Property FechaInicio() As Date
        Get
            Return Me.mdtmFechaInicio
        End Get
        Set(ByVal value As Date)
            Me.mdtmFechaInicio = value
        End Set
    End Property
    Property FechaTermino() As Date
        Get
            Return Me.mdtmFechaTermino
        End Get
        Set(ByVal value As Date)
            Me.mdtmFechaTermino = value
        End Set
    End Property
    Property FechaIngreso() As Date
        Get
            Return Me.mdtmFechaIngreso
        End Get
        Set(ByVal value As Date)
            Me.mdtmFechaIngreso = value
        End Set
    End Property
    Property FechaModificacion() As Date
        Get
            Return Me.mdtmFechaModificacion
        End Get
        Set(ByVal value As Date)
            Me.mdtmFechaModificacion = value
        End Set
    End Property
    Property ValorMercado() As Long
        Get
            Return Me.mlngValorMercado
        End Get
        Set(ByVal value As Long)
            Me.mlngValorMercado = value
        End Set
    End Property
    Property Descuento() As Long
        Get
            Return Me.mlngDescuento
        End Get
        Set(ByVal value As Long)
            Me.mlngDescuento = value
        End Set
    End Property
    Property IndDescPorc() As Integer
        Get
            Return Me.mintIndDescPorc
        End Get
        Set(ByVal value As Integer)
            Me.mintIndDescPorc = value
        End Set
    End Property
    Property CostoOtic() As Long
        Get
            Return Me.mlngCostoOtic
        End Get
        Set(ByVal value As Long)
            Me.mlngCostoOtic = value
        End Set
    End Property
    Property GastoEmpresa() As Long
        Get
            Return Me.mlngGastoEmpresa
        End Get
        Set(ByVal value As Long)
            Me.mlngGastoEmpresa = value
        End Set
    End Property
    Property PorcAdm() As Double
        Get
            Return Me.mdblPorcAdm
        End Get
        Set(ByVal value As Double)
            Me.mdblPorcAdm = value
        End Set
    End Property
    Property CostoAdm() As Double
        Get
            Return Me.mlngCostoAdm
        End Get
        Set(ByVal value As Double)
            Me.mlngCostoAdm = value
        End Set
    End Property
    Property CostoOticVYT() As Long
        Get
            Return Me.mlngCostoOticVYT
        End Get
        Set(ByVal value As Long)
            Me.mlngCostoOticVYT = value
        End Set
    End Property
    Property CostoAdmVYT() As Long
        Get
            Return Me.mlngCostoAdmVYT
        End Get
        Set(ByVal value As Long)
            Me.mlngCostoAdmVYT = value
        End Set
    End Property
    Property GastoEmpresaVYT() As Long
        Get
            Return Me.mlngGastoEmpresaVYT
        End Get
        Set(ByVal value As Long)
            Me.mlngGastoEmpresaVYT = value
        End Set
    End Property
    Property TotalViatico() As Long
        Get
            Return Me.mlngTotalViatico
        End Get
        Set(ByVal value As Long)
            Me.mlngTotalViatico = value
        End Set
    End Property
    Property TotalTraslado() As Long
        Get
            Return Me.mlngTotalTraslado
        End Get
        Set(ByVal value As Long)
            Me.mlngTotalTraslado = value
        End Set
    End Property
    Property CodComuna() As Long
        Get
            Return Me.mlngCodComuna
        End Get
        Set(ByVal value As Long)
            Me.mlngCodComuna = value
        End Set
    End Property
    Property CodRegion() As Long
        Get
            Return Me.mlngCodRegion
        End Get
        Set(ByVal value As Long)
            Me.mlngCodRegion = value
        End Set
    End Property
    Property ValorComunicado() As Long
        Get
            Return Me.mlngValorComunicado
        End Get
        Set(ByVal value As Long)
            Me.mlngValorComunicado = value
        End Set
    End Property
    Property Horas() As Long
        Get
            Return Me.mlngHoras
        End Get
        Set(ByVal value As Long)
            Me.mlngHoras = value
        End Set
    End Property
    Property HorasCompl() As Long
        Get
            Return Me.mlngHorasCompl
        End Get
        Set(ByVal value As Long)
            Me.mlngHorasCompl = value
        End Set
    End Property
    Property CodCursoCompl() As Long
        Get
            Return Me.mlngCodCursoCompl
        End Get
        Set(ByVal value As Long)
            Me.mlngCodCursoCompl = value
        End Set
    End Property
    Public ReadOnly Property CodEstadoCompl() As Long
        Get
            CodEstadoCompl = mintEstadoComplemento
        End Get
    End Property
    Property CodCursoParcial() As Long
        Get
            Return Me.mlngCodCursoParcial
        End Get
        Set(ByVal value As Long)
            Me.mlngCodCursoParcial = value
        End Set
    End Property
    Property NumAlumnos() As Long
        Get
            Return Me.mlngNumAlumnos
        End Get
        Set(ByVal value As Long)
            Me.mlngNumAlumnos = value
        End Set
    End Property
    Property MaxParticipantes() As Long
        Get
            Return Me.mlngMaxParticipantes
        End Get
        Set(ByVal value As Long)
            Me.mlngMaxParticipantes = value
        End Set
    End Property
    Property SaldoCtaCap() As Long
        Get
            Return Me.mlngSaldoCtaCap
        End Get
        Set(ByVal value As Long)
            Me.mlngSaldoCtaCap = value
        End Set
    End Property
    Property SaldoCtaExcCap() As Long
        Get
            Return Me.mlngSaldoCtaExcCap
        End Get
        Set(ByVal value As Long)
            Me.mlngSaldoCtaExcCap = value
        End Set
    End Property
    Property SaldoCtaBecas() As Long
        Get
            Return Me.mlngSaldoCtaBecas
        End Get
        Set(ByVal value As Long)
            Me.mlngSaldoCtaBecas = value
        End Set
    End Property
    Public ReadOnly Property MontoTercTran() As Long
        Get
            Return mlngMontoTercTran
        End Get
    End Property
    Property MontoCtaCap() As Long
        Get
            Return Me.mlngMontoCtaCap
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaCap = value
        End Set
    End Property
    Property MontoCtaExcCap() As Long
        Get
            Return Me.mlngMontoCtaExcCap
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaExcCap = value
        End Set
    End Property
    Property TotMontoTerc() As Long
        Get
            Return Me.mlngTotMontoTerc
        End Get
        Set(ByVal value As Long)
            Me.mlngTotMontoTerc = value
        End Set
    End Property
    Property MontoCtaCapVYT() As Long
        Get
            Return Me.mlngMontoCtaCapVYT
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaCapVYT = value
        End Set
    End Property
    Property MontoCtaExcCapVYT() As Long
        Get
            Return Me.mlngMontoCtaExcCapVYT
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaExcCapVYT = value
        End Set
    End Property
    Property MontoCtaBecas() As Long
        Get
            Return Me.mlngMontoCtaBecas
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaBecas = value
        End Set
    End Property
    Property MontoRep() As Long
        Get
            Return Me.mlngMontoRep
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoRep = value
        End Set
    End Property
    Property MontoExcRep() As Long
        Get
            Return Me.mlngMontoExcRep
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoExcRep = value
        End Set
    End Property
    Property CorrElearning() As Long
        Get
            Return Me.mlngCorrElearning
        End Get
        Set(ByVal value As Long)
            Me.mlngCorrElearning = value
        End Set
    End Property
    Property CorrelativoComplemento() As Long
        Get
            Return Me.mlngCorrelativoComplemento
        End Get
        Set(ByVal value As Long)
            Me.mlngCorrelativoComplemento = value
        End Set
    End Property
    Property CostoOticComplemento() As Long
        Get
            Return Me.mlngCostoOticComplemento
        End Get
        Set(ByVal value As Long)
            Me.mlngCostoOticComplemento = value
        End Set
    End Property
    Property CostoAdmComplemento() As Long
        Get
            Return Me.mlngCostoAdmComplemento
        End Get
        Set(ByVal value As Long)
            Me.mlngCostoAdmComplemento = value
        End Set
    End Property
    Property GastoEmpresaComplemento() As Long
        Get
            Return Me.mlngGastoEmpresaComplemento
        End Get
        Set(ByVal value As Long)
            Me.mlngGastoEmpresaComplemento = value
        End Set
    End Property
    Property CodModalidad() As Long
        Get
            Return Me.mlngCodModalidad
        End Get
        Set(ByVal value As Long)
            Me.mlngCodModalidad = value
        End Set
    End Property
    Property AdmNoLineal() As Integer
        Get
            Return Me.mintAdmNoLineal
        End Get
        Set(ByVal value As Integer)
            Me.mintAdmNoLineal = value
        End Set
    End Property
    Property CodOrigen() As Integer
        Get
            Return Me.mintCodOrigen
        End Get
        Set(ByVal value As Integer)
            Me.mintCodOrigen = value
        End Set
    End Property
    Property IndAcuComBip() As Integer
        Get
            Return Me.mintIndAcuComBip
        End Get
        Set(ByVal value As Integer)
            Me.mintIndAcuComBip = value
        End Set
    End Property
    Property IndDetNece() As Integer
        Get
            Return Me.mintIndDetNece
        End Get
        Set(ByVal value As Integer)
            Me.mintIndDetNece = value
        End Set
    End Property
    Property NroFacturaOtec() As Integer
        Get
            Return Me.mintNroFacturaOtec
        End Get
        Set(ByVal value As Integer)
            Me.mintNroFacturaOtec = value
        End Set
    End Property
    Property NumModificaciones() As Integer
        Get
            Return Me.mintNumModificaciones
        End Get
        Set(ByVal value As Integer)
            Me.mintNumModificaciones = value
        End Set
    End Property
    Property EstadoComplemento() As Integer
        Get
            Return Me.mintEstadoComplemento
        End Get
        Set(ByVal value As Integer)
            Me.mintEstadoComplemento = value
        End Set
    End Property
    Property DireccionCurso() As String
        Get
            Return Me.mstrDireccionCurso
        End Get
        Set(ByVal value As String)
            Me.mstrDireccionCurso = value
        End Set
    End Property
    Property NomRegion() As String
        Get
            Return Me.mstrNomRegion
        End Get
        Set(ByVal value As String)
            Me.mstrNomRegion = value
        End Set
    End Property
    Property NombreComuna() As String
        Get
            Return Me.mstrNombreComuna
        End Get
        Set(ByVal value As String)
            Me.mstrNombreComuna = value
        End Set
    End Property
    Property ObsCurso() As String
        Get
            Return Me.mstrObsCurso
        End Get
        Set(ByVal value As String)
            Me.mstrObsCurso = value
        End Set
    End Property
    Property ObsLiquidacion() As String
        Get
            Return Me.mstrObsLiquidacion
        End Get
        Set(ByVal value As String)
            Me.mstrObsLiquidacion = value
        End Set
    End Property
    Property NroDireccionCurso() As String
        Get
            Return Me.mstrNroDireccionCurso
        End Get
        Set(ByVal value As String)
            Me.mstrNroDireccionCurso = value
        End Set
    End Property
    Property Ciudad() As String
        Get
            Return Me.mstrCiudad
        End Get
        Set(ByVal value As String)
            Me.mstrCiudad = value
        End Set
    End Property
    Property EtiquetaClasificador() As String
        Get
            Return Me.mstrEtiquetaClasificador
        End Get
        Set(ByVal value As String)
            Me.mstrEtiquetaClasificador = value
        End Set
    End Property
    Property CorrEmpresa() As String
        Get
            Return Me.mstrCorrEmpresa
        End Get
        Set(ByVal value As String)
            Me.mstrCorrEmpresa = value
        End Set
    End Property
    Property ContactoAdicional() As String
        Get
            Return Me.mstrContactoAdicional
        End Get
        Set(ByVal value As String)
            Me.mstrContactoAdicional = value
        End Set
    End Property

    Property NombreCurso() As String
        Get
            Return Me.mstrNombreCurso
        End Get
        Set(ByVal value As String)
            Me.mstrNombreCurso = value
        End Set
    End Property
    Property FechaPagoFactura() As Date
        Get
            Return Me.mdtmFechaPagoFactura
        End Get
        Set(ByVal value As Date)
            Me.mdtmFechaPagoFactura = value
        End Set
    End Property
    Property FechaComunicacion() As Date
        Get
            Return Me.mdtmFechaComunicacion
        End Get
        Set(ByVal value As Date)
            Me.mdtmFechaComunicacion = value
        End Set
    End Property
    Property FechaLiquidacion() As Date
        Get
            Return Me.mdtmFechaLiquidacion
        End Get
        Set(ByVal value As Date)
            Me.mdtmFechaLiquidacion = value
        End Set
    End Property
    Property GenerarNuevoCorr() As Boolean
        Get
            Return Me.mblnGenerarNuevoCorr
        End Get
        Set(ByVal value As Boolean)
            Me.mblnGenerarNuevoCorr = value
        End Set
    End Property
    Property ModificarMontoSolicitudes() As Boolean
        Get
            Return Me.mblnModificarMontoSolicitudes
        End Get
        Set(ByVal value As Boolean)
            Me.mblnModificarMontoSolicitudes = value
        End Set
    End Property
    'Property RutOtec() As Long
    '    Get
    '        Return Me.mlngRutOtec
    '    End Get
    '    Set(ByVal value As Long)
    '        Me.mlngRutOtec = value
    '    End Set
    'End Property
    Property RazonSocialOtec() As String
        Get
            Return Me.mstrRazonSocialOtec
        End Get
        Set(ByVal value As String)
            Me.mstrRazonSocialOtec = value
        End Set
    End Property
    Property EmailOtec() As String
        Get
            Return Me.mstrEmailOtec
        End Get
        Set(ByVal value As String)
            Me.mstrEmailOtec = value
        End Set
    End Property
    Property FonoOtec() As Long
        Get
            Return Me.mlngFonoOtec
        End Get
        Set(ByVal value As Long)
            Me.mlngFonoOtec = value
        End Set
    End Property
    Property FaxOtec() As Long
        Get
            Return Me.mlngFaxOtec
        End Get
        Set(ByVal value As Long)
            Me.mlngFaxOtec = value
        End Set
    End Property
    Property NombreContacto() As String
        Get
            Return Me.mstrNombreContacto
        End Get
        Set(ByVal value As String)
            Me.mstrNombreContacto = value
        End Set
    End Property
    'Property CargoContacto() As String
    '    Get
    '        Return Me.mstrCargoContacto
    '    End Get
    '    Set(ByVal value As String)
    '        Me.mstrCargoContacto = value
    '    End Set
    'End Property
    'Property EmailContacto() As String
    '    Get
    '        Return Me.mstrEmailContacto
    '    End Get
    '    Set(ByVal value As String)
    '        Me.mstrEmailContacto = value
    '    End Set
    'End Property
    'Property FonoContacto() As Long
    '    Get
    '        Return Me.mlngFonoContacto
    '    End Get
    '    Set(ByVal value As Long)
    '        Me.mlngFonoContacto = value
    '    End Set
    'End Property
    'Property faxContacto() As Long
    '    Get
    '        Return Me.mlngfaxContacto
    '    End Get
    '    Set(ByVal value As Long)
    '        Me.mlngfaxContacto = value
    '    End Set
    'End Property
    Property TieneCursoComplementario() As Boolean
        Get
            Return Me.mblnTieneCursoComplementario
        End Get
        Set(ByVal value As Boolean)
            Me.mblnTieneCursoComplementario = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return Me.mstrRazonSocial
        End Get
        Set(ByVal value As String)
            Me.mstrRazonSocial = value
        End Set
    End Property
    Public Property CargoContacto() As String
        Get
            Return Me.mstrCargoContacto
        End Get
        Set(ByVal value As String)
            Me.mstrCargoContacto = value
        End Set
    End Property
    Public Property FonoContacto() As String
        Get
            Return Me.mstrFonoContacto
        End Get
        Set(ByVal value As String)
            Me.mstrFonoContacto = value
        End Set
    End Property
    Public Property FaxContacto() As String
        Get
            Return Me.mstrFaxContacto
        End Get
        Set(ByVal value As String)
            Me.mstrFaxContacto = value
        End Set
    End Property
    Public Property EmailContacto() As String
        Get
            Return Me.mstrEmail
        End Get
        Set(ByVal value As String)
            Me.mstrEmail = value
        End Set
    End Property
    Public Property NombreOtec() As String
        Get
            Return Me.mstrNombreOtec
        End Get
        Set(ByVal value As String)
            Me.mstrNombreOtec = value
        End Set
    End Property
    Public Property RutOtec() As Long
        Get
            Return Me.mstrRutOtec
        End Get
        Set(ByVal value As Long)
            Me.mstrRutOtec = value
        End Set
    End Property

    Public Property ContactoOtec() As String
        Get
            Return Me.mstrContactoOtec
        End Get
        Set(ByVal value As String)
            Me.mstrContactoOtec = value
        End Set
    End Property
    Public Property CargoContactoOtec() As String
        Get
            Return Me.mstrCargoContacto
        End Get
        Set(ByVal value As String)
            Me.mstrCargoContacto = value
        End Set
    End Property
    Public Property FonoContactoOtec() As String
        Get
            Return Me.mstrFonoContactoOtec
        End Get
        Set(ByVal value As String)
            Me.mstrFonoContactoOtec = value
        End Set
    End Property
    Public Property FaxContactoOtec() As String
        Get
            Return Me.mstrFaxContactoOtec
        End Get
        Set(ByVal value As String)
            Me.mstrFaxContactoOtec = value
        End Set
    End Property
    Public Property EmailContactoOtec() As String
        Get
            Return Me.mstrEmailContactoOtec
        End Get
        Set(ByVal value As String)
            Me.mstrEmailContactoOtec = value
        End Set
    End Property
    Public Property NombreModalidad() As String
        Get
            Return Me.mstrNombreModalidad
        End Get
        Set(ByVal value As String)
            Me.mstrNombreModalidad = value
        End Set
    End Property
    Public Property Participantes() As DataTable
        Get
            Return mdtParticipantes
        End Get
        Set(ByVal value As DataTable)
            mdtParticipantes = value
        End Set
    End Property

    Property DirecccionEmpresa() As String
        Get
            Return Me.mstrDirecccionEmpresa
        End Get
        Set(ByVal value As String)
            Me.mstrDirecccionEmpresa = value
        End Set
    End Property

    Property ComunaEmpresa() As String
        Get
            Return Me.mstrComunaEmpresa
        End Get
        Set(ByVal value As String)
            Me.mstrComunaEmpresa = value
        End Set
    End Property

    Property BitacoraComentarios() As DataTable
        Get
            Return mdtBitacoraComentarios
        End Get
        Set(ByVal value As DataTable)
            mdtBitacoraComentarios = value
        End Set
    End Property
    Public Property EsFinDeSemana() As Boolean
        Get
            Return mblnEsFinDeSemana
        End Get
        Set(ByVal value As Boolean)
            mblnEsFinDeSemana = value
        End Set
    End Property

#End Region

    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try


            mobjSql = New CSql
            Dim objcurso As New CCursoContratado
            Dim objcliente As New CCliente
            'Dim objUsuario As New CUsuario
            Dim objcursosence As New CCurso
            Dim objOtec As New COtec
            Dim ccursocontratado As New CCursoContratado
            Dim otec As New COtec
            ccursocontratado.Inicializar0(mobjSql, Me.mlngRutCliente)
            ccursocontratado.Inicializar1(mlngCodCurso)

            ccursocontratado.ObtenerInfoCuentas()
            'ccursocontratado.CalcularCostos()

            Me.mdtParticipantes = ccursocontratado.AlumnosCurso(mlngCodCurso)
            Me.mdtBitacoraComentarios = ccursocontratado.BitacoraComentario(mlngCodCurso)
            Me.mblnEsFinDeSemana = ccursocontratado.EsFinDeSemana

            'datos de la empresa
            Me.mstrRazonSocial = ccursocontratado.Cliente.RazonSocial       'si
            Me.mlngRutCliente = RutUsrALng(ccursocontratado.RutCliente)
            Me.mstrNombreContacto = ccursocontratado.Cliente.Contacto 'si
            Me.mstrCargoContacto = ccursocontratado.Cliente.CargoContacto   'si
            Me.mstrFonoContacto = ccursocontratado.Cliente.FonoContacto     'si
            Me.mstrFaxContacto = ccursocontratado.Cliente.Fax               'si
            Me.mstrEmail = ccursocontratado.Cliente.EmailContacto
            Me.mstrDirecccionEmpresa = ccursocontratado.Cliente.DireccionCompleta
            Me.mstrComunaEmpresa = ccursocontratado.Cliente.Comuna


            'datos del otec
            Me.mstrNombreOtec = ccursocontratado.Otec.RazonSocial
            Me.mstrRutOtec = ccursocontratado.Curso.RutOtec
            Me.mstrContactoOtec = ccursocontratado.Otec.Contacto
            Me.mstrCargoContactoOtec = ccursocontratado.Otec.Cargo
            Me.mstrFonoContactoOtec = ccursocontratado.Otec.Fono
            Me.mstrFaxContactoOtec = ccursocontratado.Otec.Fax
            Me.mstrEmailContactoOtec = ccursocontratado.Otec.Email

            'curso
            Me.mstrNombreCurso = ccursocontratado.Curso.NombreCurso
            Me.mstrCodSence = ccursocontratado.CodSence                     'si
            Me.mlngHoras = ccursocontratado.Horas                           'si
            Me.mstrDireccionCurso = ccursocontratado.DireccionCurso
            Me.mstrNroDireccionCurso = ccursocontratado.NroDireccionCurso
            Me.mstrCiudad = ccursocontratado.Ciudad
            Me.mstrNombreComuna = ccursocontratado.Curso.Comuna
            Me.mstrNomRegion = ccursocontratado.NomRegion                   'si
            Me.mdtmFechaInicio = ccursocontratado.FechaInicio               'si
            Me.mdtmFechaTermino = ccursocontratado.FechaTermino
            Me.mstrObsCurso = ccursocontratado.Observacion & " - "
            Me.mlngCodElearning = ccursocontratado.CodElearning
            Me.mstrNombreModalidad = ccursocontratado.NombreModalidad

            'costo
            Me.mlngNumAlumnos = ccursocontratado.NumAlumnos                 'si
            Me.mlngValorMercado = FormatoMonto(ccursocontratado.ValorMercado)   'si
            Me.mlngTotalViatico = FormatoMonto(ccursocontratado.TotalViatico)   'si
            Me.mlngTotalTraslado = FormatoMonto(ccursocontratado.TotalTraslado) 'si
            Me.mdblPorcAdm = ccursocontratado.PorcAdm * 100                 'si
            Me.mintIndAcuComBip = ccursocontratado.IndAcuComBip  'si
            Me.mintIndDetNece = ccursocontratado.IndDetNece  'si
            Me.mintCodTipoActivo = ccursocontratado.CodTipoActiv  'si
            Me.mintNroFacturaOtec = ccursocontratado.Factura.NumFactura



            'curso parcial
            Me.mlngCostoOtic = FormatoMonto(ccursocontratado.CostoOtic)     'si
            Me.mlngCostoOticVYT = FormatoMonto(ccursocontratado.MontoCtaCapVYT + ccursocontratado.MontoCtaExcCapVYT)
            Me.mlngTotalCostoOtec = FormatoMonto(ccursocontratado.CostoOtic + ccursocontratado.MontoCtaCapVYT + ccursocontratado.MontoCtaExcCapVYT) 'si

            'If (ccursocontratado.CostoOtic + ccursocontratado.GastoEmpresa + ccursocontratado.CostoOticComplemento + ccursocontratado.GastoEmpresaComplemento) = ccursocontratado.ValorMercado Then
            'Me.mlngGastoEmpresa = FormatoMonto(ccursocontratado.GastoEmpresa + ccursocontratado.GastoEmpresaComplemento) 'siç
            'Else
            Me.mlngGastoEmpresa = FormatoMonto(ccursocontratado.GastoEmpresa) 'si
            ' End If


            'Me.mlngGastoEmpresa = FormatoMonto(ccursocontratado.GastoEmpresa + ccursocontratado.GastoEmpresaComplemento) 'siç

            Me.mlngGastoEmpresaVYT = FormatoMonto(ccursocontratado.TotalViatico + ccursocontratado.TotalTraslado - (ccursocontratado.MontoCtaCapVYT + ccursocontratado.MontoCtaExcCapVYT))  'si
            Me.mlngTotalGastoEmpresa = FormatoMonto(ccursocontratado.GastoEmpresa + ccursocontratado.TotalViatico + ccursocontratado.TotalTraslado - (ccursocontratado.MontoCtaCapVYT + ccursocontratado.MontoCtaExcCapVYT))    'si
            Me.mlngCostoAdm = FormatoMonto(ccursocontratado.CostoAdm)       'si
            Me.mlngCostoAdmVYT = FormatoMonto(ccursocontratado.CostoAdmVYT)         'si
            Me.mlngTotalCostoAdmin = FormatoMonto(ccursocontratado.CostoAdm + ccursocontratado.CostoAdmVYT)  'si
            Me.mlngHorasParciales = ccursocontratado.Horas - ccursocontratado.HorasCompl   'si
            Me.mlngMontoCtaCap = FormatoMonto(ccursocontratado.MontoCtaCap)
            Me.mlngMontoCtaCapVYT = FormatoMonto(ccursocontratado.MontoCtaCapVYT)
            Me.mlngSaldoCtaCap = FormatoMonto(ccursocontratado.MontoCtaCap + ccursocontratado.MontoCtaCapVYT)
            Me.mlngMontoCtaExcCap = FormatoMonto(ccursocontratado.MontoCtaExcCap)
            Me.mlngMontoCtaExcCapVYT = FormatoMonto(ccursocontratado.MontoCtaExcCapVYT)
            Me.mlngSaldoCtaExcCap = FormatoMonto(ccursocontratado.MontoCtaExcCap + ccursocontratado.MontoCtaExcCapVYT)
            Me.mlngMontoCtaBecas = FormatoMonto(ccursocontratado.MontoCtaBecas)
            Me.mlngMontoTercTran = FormatoMonto(ccursocontratado.MontoTercTran)




            'curso complementario

            Me.mintEstadoComplemento = ccursocontratado.EstadoComplemento
            Me.mlngCostoOticComplemento = FormatoMonto(ccursocontratado.CostoOticComplemento)
            Me.mlngGastoEmpresaComplemento = FormatoMonto(ccursocontratado.GastoEmpresaComplemento)
            Me.mlngCostoAdmComplemento = FormatoMonto(ccursocontratado.CostoAdmComplemento)
            Me.mlngHorasCompl = ccursocontratado.HorasCompl
            Me.mlngCodCursoCompl = ccursocontratado.CodCursoCompl
            Me.mlngCodCursoParcial = ccursocontratado.CodCursoParcial

            'cabecera
            Me.mstrCorrEmpresa = ccursocontratado.CorrEmpresa  'si
            Me.mlngCorrelativo = ccursocontratado.Correlativo
            Me.mintCodEstadoCurso = ccursocontratado.CodEstadoCurso
            Me.mdtmFechaModificacion = ccursocontratado.FechaModificacion
            Me.mintCodOrigen = ccursocontratado.CodOrigen
            Me.mdtmFechaIngreso = ccursocontratado.FechaIngreso
            Me.mlngNroRegistro = ccursocontratado.NroRegistro
            Me.mlngCorrelativoComplemento = ccursocontratado.CorrelativoComplemento
            Me.mlngNumPerfil = ccursocontratado.NroPerfil



        Catch ex As Exception
            EnviaError("CFichaCursoContratado-->Consultar" & ex.Message)
        End Try
    End Function
    Public Function Correo()
        Try
            Dim objEnviarEmail As New CEnviarCorreo
            Dim objSql As New CSql
            Dim strSubject As String = ""
            Dim strBody As String = ""
            Dim strTo As String = ""
            Dim strNobreSD As String = ""
            Dim strNobreColaborador As String = ""
            Dim strElElla As String = ""
            Dim consultaJefe As DataTable


            mstrEmail = "emilio.alarcon@soleduc.cl"
            mstrEmailContactoOtec = "claudio.aguilera@soleduc.cl"
            'consultaJefe = objSql.s_notificar_jefe_proyecto(mstrJefeProyecto, mlngIdProyecto)
            strSubject = "Ingreso de curso"
            strTo = Me.mstrEmail & ";" & Me.mstrEmailContactoOtec

            strBody = "Se ha ingresado un curso exitosamente " _
                               & vbCr & "DETALLE: " _
                               & vbCr & "Correlativo curso: " & Me.mlngCorrelativo & " Rut Cliente: " & Me.RutCliente & vbCr _
                               & "IMPORTANTE: Este mensaje ha sido generado automáticamente por el sistema, favor NO RESPONDER"


            objEnviarEmail.EnviarCorreo(Parametros.p_USUARIOCORREO, strTo, _
                    strSubject, strBody, Parametros.p_SERVIDORCORREO)
        Catch ex As Exception
            EnviaError("CmantenedorProyectos Correo >" & ex.Message)
        End Try

    End Function
End Class