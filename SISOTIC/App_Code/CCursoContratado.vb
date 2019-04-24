Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Imports Clases.Web

Public Class CCursoContratado
#Region "Declaraciones"
    'objeto de coneccion a bd y de implements ireporte
    Private mobjSql As CSql
    Private mlngFilas As Long
    Dim mobjWeb As New CWeb
    'rut del usuario conectado
    Private mlngRutUsuario As Long
    'El Código del Curso
    Private mlngCodCurso As Long
    'El Número Correlativo del Curso
    Private mlngCorrelativo As Long
    'El Codigo de curso e-learning
    Private mlngCodElearning As Long
    'El Número de Registro
    Private mlngNroRegistro As Long
    'El Número de que representa los perfiles que el usuario tiene
    Private mlngNroPerfil As Long
    'Código Sence
    Private mstrCodSence As String
    'Rut del Cliente
    Private mlngRutCliente As Long
    'Código del Tipo de Actividad
    Private mintCodTipoActiv As Integer
    'Código del Estado del Curso
    Private mintCodEstadoCurso As Integer
    'Código del Último Estado del Curso
    Private mintCodUltEstadoCurso As Integer
    'Año
    Private mlngAgno As Long
    'Fecha de Inicio del Curso
    Private mdtmFechaInicio As Date
    'Fecha de Fin del Curso
    Private mdtmFechaTermino As Date
    'Fecha de Ingreso del Curso
    Private mdtmFechaIngreso As Date
    'Fecha de ultima Modificacion del Curso
    Private mdtmFechaModificacion As Date
    'Valor del curso en el mercado
    Private mlngValorMercado As Long
    'Descuento
    Private mlngDescuento As Double
    'Indicador si el descuento es monto (0) o porcentaje (1)
    Private mintIndDescPorc As Integer
    'Porcentaje de Administracion
    Private mdblPorcAdm As Double
    'Costo del OTIC
    Private mlngCostoOtic As Long
    'Costo de Administracion
    Private mlngCostoAdm As Double
    'Gasto de la Empresa
    Private mlngGastoEmpresa As Long
    Private mstrNombreModalidad As String
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
    'Direccion donde se dara el curso
    Private mstrDireccionCurso As String
    'Código de la Comuna
    Private mlngCodComuna As Long
    'Código de la Region
    Private mlngCodRegion As Long
    'Nombre de la Region
    Private mstrNomRegion As String
    Private mstrNomComuna As String
    'Código del atributo
    Private mintCodOrigen As Integer
    'Observaciones del Curso
    Private mstrObsCurso As String
    'Valor total al momento de liquidar
    Private mlngValorComunicado As Long
    'Observaciones de la liquidacion
    Private mstrObsLiquidacion As String
    'Horas de duracion del curso
    Private mlngHoras As Double
    'Horas complementarias del curso, si existen
    Private mlngHorasCompl As Double
    'Comité Bipartito
    Private mbolIndAcuComBip As Boolean
    'Indicador de deteccion de necesidades
    Private mbolIndDetNece As Boolean
    'Número de Factura del OTEC
    Private mintNroFacturaOtec As Integer
    'Fecha del Pago de la Factura
    Private mdtmFechaPagoFactura As Date
    'Código de curso complementario, si existe
    Private mlngCodCursoCompl As Long
    'Código de curso parcial, si existe
    Private mlngCodCursoParcial As Long
    'Correlativo Interno de la Empresa Cliente
    Private mstrCorrEmpresa As String
    'Contacto y Observaciones Adicionales
    Private mstrContactoAdicional As String
    'Observación
    Private mstrObservacion As String
    'Numero de Participantes del curso
    Private mlngNumAlumnos As Long
    'Fecha del Comunicacion del Curso
    Private mdtmFechaComunicacion As Date
    'Fecha del Liquidacion del Curso
    Private mdtmFechaLiquidacion As Date
    'Numero de Modificaciones que se le hacen a un Curso
    Private mintNumModificaciones As Integer
    'Numero de Maximo Participantes del curso
    Private mlngMaxParticipantes As Long
    'Arreglo con todas las comunas
    Private mdtComunas As DataTable
    'Arreglo con los tipos de actividad
    Private mdtTiposActiv As DataTable
    'Arreglo con las solicitudes de terceros y su información
    Private mdtListaTerceros As DataTable
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
    Private mlngMontoTercTran
    Private mlngMontoRep As Long
    Private mlngMontoExcRep As Long
    'Objeto Parametros generales
    Private mobjParamGen As CParamGen
    'Objeto OTEC
    Private mobjOtec As COtec
    'Objeto Cliente
    Private mobjCliente As CCliente
    'Objeto Factura
    Private mobjFactura As CFactura
    'Arreglo de ruts de terceros y monto de sus respectivas cooperaciones
    Private mdtTerceros As DataTable
    'Arreglo que me indica si los datos de los montos se insertan(1) o actualizan(2)
    Private mdtModifCuentas As DataTable
    'Declaracion de un objeto curso
    Private mobjCurso As CCurso
    'Declaracion de un curso complementario
    Private mobjCursoCompl As CCursoContratado
    'Declaracion de un arreglo de Horarios
    Private mdtHorarioCurso As DataTable
    'Declaracion de un arreglo de Alumnos
    Private mcolAlumnos As Collection
    'Declaracion de un arreglo de Solicitudes
    Private mcolSolicitudes As Collection
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
    Private mdtModalidades As DataTable
    Private mlngCodModalidad As Long
    Private mstrEsComplementario As String

    '-----------------------------------------------
    'Numero de la direccion del curso
    Private mstrNroDireccionCurso As String
    'Ciudad donde se realiza el curso
    Private mstrCiudad As String
    Private mstrEtiquetaClasificador As String
    Private mstrRazonSocial As String
    Private mstrCargoContacto As String
    Private mstrFonoContacto As String
    Private mstrFaxContacto As String
    Private mstrEmail As String
    Private mstrNombreOtec As String
    Private mlngRutOtec As Long
    Private mstrContactoOtec As String
    Private mstrCargoContactoOtec As String
    Private mstrFonoContactoOtec As String
    Private mstrFaxContactoOtec As String
    Private mstrEmailContactoOtec As String
    Private mstrNombreCurso As String
    Private mstrNombreComuna As String
    Private mlngTotalCostoOtec As Long
    Private mlngTotalGastoEmpresa As Long
    Private mlngTotalCostoAdmin As Long
    Private mlngHorasParciales As Double
    Private mstrEstadoCursoComplemetario As String
    Private mintCodTipoActivo As Integer
    Private mstrGiro As String
    Private mdblValorHora As Double
    Private mblnCursoCFT As Boolean
    Private mblnEsFinDeSemana As Boolean
    Private mstrXml As String


    Private mlngRutEncargado As Long

    'Comunes
    'Private mobjCsql As New CSql

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
    Public Property RutEncargado() As Long
        Get
            Return mlngRutEncargado
        End Get
        Set(ByVal value As Long)
            Me.mlngRutEncargado = value
        End Set
    End Property

    Public Property Giro() As String
        Get
            Giro = mstrGiro
        End Get
        Set(ByVal value As String)
            Me.mstrGiro = value
        End Set
    End Property
    Public Property NombreModalidad() As String
        Get
            Return mstrNombreModalidad
        End Get
        Set(ByVal value As String)
            Me.mstrNombreModalidad = value
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
    Public Property Correlativo() As Long
        Get
            Return Me.mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            Me.mlngCorrelativo = value
        End Set
    End Property
    Public Property CodElearning() As Long
        Get
            CodElearning = mlngCodElearning
        End Get
        Set(ByVal value As Long)
            Me.mlngCodElearning = value
        End Set
    End Property
    Public Property CodModalidad() As Long
        Get
            CodModalidad = mlngCodModalidad
        End Get
        Set(ByVal value As Long)
            Me.mlngCodModalidad = value
        End Set
    End Property
    Public Property NroRegistro() As Long
        Get
            Return Me.mlngNroRegistro
        End Get
        Set(ByVal value As Long)
            Me.mlngNroRegistro = value
        End Set
    End Property
    Public Property RutUsuario() As String
        Get
            RutUsuario = mlngRutUsuario
        End Get
        Set(ByVal value As String)
            Me.mlngRutUsuario = value
        End Set
    End Property
    Public ReadOnly Property NroPerfil() As Long
        Get
            Return mlngNroPerfil
        End Get
    End Property
    Public Property CodSence() As String
        Get
            Return Me.mstrCodSence
        End Get
        Set(ByVal value As String)
            Me.mstrCodSence = value
        End Set
    End Property
    Public Property RutCliente() As String
        Get
            RutCliente = Trim(RutLngAUsr(mlngRutCliente))
        End Get
        Set(ByVal value As String)
            Me.mlngRutCliente = value
        End Set
    End Property
    Public Property RutOtec() As String
        Get
            RutOtec = Trim(RutLngAUsr(mlngRutOtec))
        End Get
        Set(ByVal value As String)
            Me.mlngRutOtec = value
        End Set
    End Property
    Public Property CodTipoActiv() As Integer
        Get
            Return Me.mintCodTipoActiv
        End Get
        Set(ByVal value As Integer)
            Me.mintCodTipoActiv = value
        End Set
    End Property
    Public Property CodEstadoCurso() As Integer
        Get
            Return Me.mintCodEstadoCurso
        End Get
        Set(ByVal value As Integer)
            Me.mintCodEstadoCurso = value
        End Set
    End Property
    Public Property CodUltEstadoCurso() As Integer
        Get
            Return mintCodUltEstadoCurso
        End Get
        Set(ByVal value As Integer)
            mintCodUltEstadoCurso = value
        End Set
    End Property
    Public Property Agno() As Long
        Get
            Return Me.mlngAgno
        End Get
        Set(ByVal value As Long)
            Me.mlngAgno = value
        End Set
    End Property
    Public Property FechaInicio() As Date
        Get
            If mdtmFechaInicio = FechaMinSistema() Then
                FechaInicio = FechaVbAUsr(FechaMinSistema)
            Else
                FechaInicio = FechaVbAUsr(mdtmFechaInicio)
            End If
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = FechaUsrAVb(value)
        End Set
    End Property
    Public Property FechaTermino() As Date
        Get
            If mdtmFechaInicio = FechaMinSistema() Then
                FechaTermino = FechaVbAUsr(FechaMinSistema)
            Else
                FechaTermino = FechaVbAUsr(mdtmFechaTermino)
            End If
        End Get
        Set(ByVal value As Date)
            mdtmFechaTermino = FechaUsrAVb(value)
        End Set
    End Property
    Public ReadOnly Property FechaIngreso() As Date
        Get
            Return mdtmFechaIngreso
        End Get
    End Property
    Public ReadOnly Property FechaModificacion() As Date
        Get
            Return mdtmFechaModificacion
        End Get
    End Property
    Public Property ValorMercado() As Long
        Get
            Return Me.mlngValorMercado
        End Get
        Set(ByVal value As Long)
            Me.mlngValorMercado = value
        End Set
    End Property
    Public Property Descuento() As Long
        Get
            Return Me.mlngDescuento
        End Get
        Set(ByVal value As Long)
            Me.mlngDescuento = value
        End Set
    End Property
    Public Property IndDescPorc() As Integer
        Get
            Return Me.mintIndDescPorc
        End Get
        Set(ByVal value As Integer)
            Me.mintIndDescPorc = value
        End Set
    End Property
    Public Property PorcAdm() As Double
        Get
            If mdblPorcAdm <= 1 Then
                PorcAdm = mdblPorcAdm
            Else
                PorcAdm = mdblPorcAdm / 100
            End If
        End Get
        Set(ByVal value As Double)
            Me.mdblPorcAdm = value
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
    Public ReadOnly Property CodEstadoCompl() As Long
        Get
            CodEstadoCompl = mintEstadoComplemento
        End Get
    End Property
    Property CostoAdm() As Double
        Get
            Return Me.mlngCostoAdm
        End Get
        Set(ByVal value As Double)
            Me.mlngCostoAdm = value
        End Set
    End Property
    Public Property GastoEmpresa() As Long
        Get
            Return mlngGastoEmpresa
        End Get
        Set(ByVal value As Long)
            mlngGastoEmpresa = value
        End Set
    End Property
    Public Property CostoOticVYT() As Long
        Get
            Return mlngCostoOticVYT
        End Get
        Set(ByVal value As Long)
            mlngCostoOticVYT = value
        End Set
    End Property
    Public ReadOnly Property CostoOticVYTReal() As Long
        Get
            Return mlngMontoCtaCapVYT + mlngMontoCtaExcCapVYT
        End Get
    End Property
    Public Property CostoAdmVYT() As Long
        Get
            Return mlngCostoAdmVYT
        End Get
        Set(ByVal value As Long)
            mlngCostoAdmVYT = value
        End Set
    End Property
    Public Property MontoCtaAdmVYT() As Long
        Get
            If mlngCostoAdmVYT >= 0 Then
                MontoCtaAdmVYT = mlngCostoAdmVYT
            Else
                MontoCtaAdmVYT = 0
            End If
        End Get
        Set(ByVal value As Long)
            mlngCostoAdmVYT = value
        End Set
    End Property
    Public Property GastoEmpresaVYT() As Long
        Get
            Return mlngGastoEmpresaVYT
        End Get
        Set(ByVal value As Long)
            mlngGastoEmpresaVYT = value
        End Set
    End Property
    Public ReadOnly Property GastoEmpresaVYTReal() As Long
        Get
            If TotalViatico = 0 And TotalTraslado = 0 And mlngMontoCtaCapVYT = -1 And mlngMontoCtaExcCapVYT = -1 Then
                GastoEmpresaVYTReal = 0
            Else
                GastoEmpresaVYTReal = TotalViatico + TotalTraslado - (mlngMontoCtaCapVYT + mlngMontoCtaExcCapVYT)
            End If

        End Get
    End Property
    Public Property TotalViatico() As Long
        Get
            Return mlngTotalViatico
        End Get
        Set(ByVal value As Long)
            mlngTotalViatico = value
        End Set
    End Property
    Public Property TotalTraslado() As Long
        Get
            Return mlngTotalTraslado
        End Get
        Set(ByVal value As Long)
            mlngTotalTraslado = value
        End Set
    End Property
    Public Property AdmNoLineal() As Integer
        Get
            Return mintAdmNoLineal
        End Get
        Set(ByVal value As Integer)
            mintAdmNoLineal = value
        End Set
    End Property
    Public Property DireccionCurso() As String
        Get
            Return Me.mstrDireccionCurso
        End Get
        Set(ByVal value As String)
            Me.mstrDireccionCurso = value
        End Set
    End Property
    Public ReadOnly Property DireccionCursoCompleta() As String
        Get
            DireccionCursoCompleta = mstrDireccionCurso & " " & mstrNroDireccionCurso & " (" & mstrCiudad & ")"
        End Get
    End Property
    Public Property CodComuna() As Long
        Get
            Return Me.mlngCodComuna
        End Get
        Set(ByVal value As Long)
            Me.mlngCodComuna = value
        End Set
    End Property
    Public ReadOnly Property CodRegion() As Long
        Get
            Return mlngCodRegion
        End Get
    End Property
    Public ReadOnly Property NomRegion() As String
        Get
            Return mstrNomRegion
        End Get
    End Property
    Property NomComuna() As String
        Get
            Return Me.mstrNomComuna
        End Get
        Set(ByVal value As String)
            Me.mstrNomComuna = value
        End Set
    End Property
    Public ReadOnly Property CodOrigen() As Integer
        Get
            Return mintCodOrigen
        End Get
    End Property
    Public Property ObsCurso() As String
        Get
            Return mstrObsCurso
        End Get
        Set(ByVal value As String)
            Me.mstrObsCurso = value
        End Set
    End Property
    Public Property ValorComunicado() As Long
        Get
            Return Me.mlngValorComunicado
        End Get
        Set(ByVal value As Long)
            Me.mlngValorComunicado = value
        End Set
    End Property
    Public ReadOnly Property ObsLiquidacion() As String
        Get
            Return mstrObsLiquidacion
        End Get
    End Property
    Public Property Horas() As Double
        Get
            Return Me.mlngHoras
        End Get
        Set(ByVal value As Double)
            Me.mlngHoras = value
        End Set
    End Property
    Public ReadOnly Property HorasEjecutadas() As Double
        Get
            Return Me.mlngHoras - mlngHorasCompl
        End Get
    End Property
    Public Property HorasCompl() As Double
        Get
            Return Me.mlngHorasCompl
        End Get
        Set(ByVal value As Double)
            Me.mlngHorasCompl = value
        End Set
    End Property
    Public Property IndAcuComBip() As Boolean
        Get
            Return Me.mbolIndAcuComBip
        End Get
        Set(ByVal value As Boolean)
            Me.mbolIndAcuComBip = value
        End Set
    End Property
    Public Property IndDetNece() As Boolean
        Get
            Return Me.mbolIndDetNece
        End Get
        Set(ByVal value As Boolean)
            Me.mbolIndDetNece = value
        End Set
    End Property
    Public ReadOnly Property NroFacturaOtec() As Integer
        Get
            Return mintNroFacturaOtec
        End Get
    End Property
    Public ReadOnly Property FechaPagoFactura() As Date
        Get
            Return mdtmFechaPagoFactura
        End Get
    End Property
    Public Property CodCursoCompl() As Long
        Get
            Return Me.mlngCodCursoCompl
        End Get
        Set(ByVal value As Long)
            Me.mlngCodCursoCompl = value
        End Set
    End Property
    Public Property CodCursoParcial() As Long
        Get
            Return Me.mlngCodCursoParcial
        End Get
        Set(ByVal value As Long)
            Me.mlngCodCursoParcial = value
        End Set
    End Property
    Public Property CorrEmpresa() As String
        Get
            Return Me.mstrCorrEmpresa
        End Get
        Set(ByVal value As String)
            Me.mstrCorrEmpresa = value
        End Set
    End Property
    Public Property CursoCFT() As String
        Get
            Return Me.mblnCursoCFT
        End Get
        Set(ByVal value As String)
            Me.mblnCursoCFT = value
        End Set
    End Property
    Public Property ContactoAdicional() As String
        Get
            Return Me.mstrContactoAdicional
        End Get
        Set(ByVal value As String)
            Me.mstrContactoAdicional = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return Me.mstrObservacion
        End Get
        Set(ByVal value As String)
            Me.mstrObservacion = value
        End Set
    End Property
    Public Property NumAlumnos() As Long
        Get
            Return mlngNumAlumnos
        End Get
        Set(ByVal value As Long)
            Me.mlngNumAlumnos = value
        End Set
    End Property
    Public ReadOnly Property FechaComunicacion() As String
        Get
            If mdtmFechaComunicacion = FechaMinSistema() Then
                FechaComunicacion = FechaVbAUsr(FechaMinSistema)
            Else
                FechaComunicacion = FechaVbAUsr(mdtmFechaComunicacion)
            End If
        End Get
    End Property
    Public ReadOnly Property FechaLiquidacion() As String
        Get
            If mdtmFechaComunicacion = FechaMinSistema() Then
                FechaLiquidacion = FechaVbAUsr(FechaMinSistema)
            Else
                FechaLiquidacion = FechaVbAUsr(mdtmFechaLiquidacion)
            End If
        End Get
    End Property
    Public Property NumModificaciones() As Integer
        Get
            Return Me.mintNumModificaciones
        End Get
        Set(ByVal value As Integer)
            Me.mintNumModificaciones = value
        End Set
    End Property
    Public Property MaxParticipantes() As Long
        Get
            Return mlngMaxParticipantes
        End Get
        Set(ByVal value As Long)
            mlngMaxParticipantes = value
        End Set
    End Property
    Public ReadOnly Property LookUpComunas() As DataTable
        Get
            LookUpComunas = mdtComunas
        End Get
    End Property
    Public ReadOnly Property LookUpTiposActiv() As DataTable
        Get
            LookUpTiposActiv = mdtTiposActiv
        End Get
    End Property
    Public ReadOnly Property LookUpListaTerceros() As DataTable
        Get
            LookUpListaTerceros = mdtListaTerceros
        End Get
    End Property
    Public Property SaldoCtaCap() As Long
        Get
            Return mlngSaldoCtaCap
        End Get
        Set(ByVal value As Long)
            mlngSaldoCtaCap = value
        End Set
    End Property
    Public Property SaldoCtaExcCap() As Long
        Get
            Return mlngSaldoCtaExcCap
        End Get
        Set(ByVal value As Long)
            mlngSaldoCtaExcCap = value
        End Set
    End Property
    Public Property SaldoCtaBecas() As Long
        Get
            Return mlngSaldoCtaBecas
        End Get
        Set(ByVal value As Long)
            mlngSaldoCtaBecas = value
        End Set
    End Property
    Public Property MontoCtaCap() As Long
        Get
            If mlngMontoCtaCap >= 0 Then
                MontoCtaCap = mlngMontoCtaCap
            Else
                MontoCtaCap = 0
            End If
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaCap = value
        End Set
    End Property
    Public Property MontoCtaExcCap() As Long
        Get
            If mlngMontoCtaExcCap >= 0 Then
                MontoCtaExcCap = mlngMontoCtaExcCap
            Else
                MontoCtaExcCap = 0
            End If
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaExcCap = value
        End Set
    End Property
    Public Property TotMontoTerc() As Long
        Get
            If mlngTotMontoTerc >= 0 Then
                TotMontoTerc = mlngTotMontoTerc
            Else
                TotMontoTerc = 0
            End If
        End Get
        Set(ByVal value As Long)
            Me.mlngTotMontoTerc = value
        End Set
    End Property
    Public Property MontoCtaCapVYT() As Long
        Get
            If mlngMontoCtaCapVYT >= 0 Then
                MontoCtaCapVYT = mlngMontoCtaCapVYT
            Else
                MontoCtaCapVYT = 0
            End If
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaCapVYT = value
        End Set
    End Property
    Public Property MontoCtaExcCapVYT() As Long
        Get
            If mlngMontoCtaExcCapVYT >= 0 Then
                MontoCtaExcCapVYT = mlngMontoCtaExcCapVYT
            Else
                MontoCtaExcCapVYT = 0
            End If
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaExcCapVYT = value
        End Set
    End Property
    Public Property MontoCtaBecas() As Long
        Get
            If mlngMontoCtaBecas >= 0 Then
                MontoCtaBecas = mlngMontoCtaBecas
            Else
                MontoCtaBecas = 0
            End If
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoCtaBecas = value
        End Set
    End Property
    Public Property MontoTercTran() As Long
        Get
            If mlngMontoTercTran >= 0 Then
                MontoTercTran = mlngMontoTercTran
            Else
                MontoTercTran = 0

            End If
        End Get
        Set(ByVal value As Long)
            Me.mlngMontoTercTran = value
        End Set
    End Property
    Public Property MontoRep() As Long
        Get
            Return mlngMontoRep
        End Get
        Set(ByVal value As Long)
            mlngMontoRep = 0
        End Set
    End Property
    Public Property MontoExcRep() As Long
        Get
            Return mlngMontoExcRep
        End Get
        Set(ByVal value As Long)
            mlngMontoExcRep = value
        End Set
    End Property
    Public ReadOnly Property ParamGen() As CParamGen
        Get
            Return mobjParamGen
        End Get
    End Property
    Public ReadOnly Property Cliente() As CCliente
        Get
            Return mobjCliente
        End Get
    End Property
    Public ReadOnly Property Otec() As COtec
        Get
            Return mobjOtec
        End Get
    End Property
    Public ReadOnly Property Curso() As CCurso
        Get
            Return mobjCurso
        End Get
    End Property
    Public ReadOnly Property TotMontoTercTransacciones() As Long
        Get
            Return mlngMontoTercTran
        End Get
    End Property
    Public ReadOnly Property Factura() As CFactura
        Get
            Return mobjFactura
        End Get
    End Property
    Public Property Terceros() As DataTable
        Get
            Dim auxiliar As DataTable
            Dim i, intTamArr As Integer
            auxiliar = mdtTerceros
            If auxiliar Is Nothing Then
                auxiliar = New DataTable
                auxiliar.Columns.Add("rut_benefactor")
                auxiliar.Columns.Add("monto")
                auxiliar.Columns.Add("cod_estado_solicitud")
                auxiliar.Columns.Add("monto_adm")
                auxiliar.Columns.Add("monto2")
                auxiliar.Columns.Add("cta")
                auxiliar.Columns.Add("cod_curso")
            Else
                intTamArr = auxiliar.Rows.Count 'TamanoArreglo2(auxiliar)
                'For i = 0 To intTamArr - 1
                '    auxiliar.Rows(i)(0) = RutLngAUsr(auxiliar.Rows(i)(0))
                'Next
                'Dim dr As DataRow
                'For Each dr In auxiliar.Rows
                '    dr("rut_benefactor") = RutLngAUsr(dr("rut_benefactor"))
                'Next
            End If
            Terceros = auxiliar
        End Get
        Set(ByVal value As DataTable)
            Dim auxiliar As DataTable
            Dim i, intTamArr As Integer
            auxiliar = value
            If auxiliar Is Nothing Then
                'auxiliar = New DataTable
                'auxiliar.Columns.Add("rut_benefactor")
                'auxiliar.Columns.Add("monto")
                'auxiliar.Columns.Add("cod_estado_solicitud")
                'auxiliar.Columns.Add("monto_adm")
                'auxiliar.Columns.Add("monto2")
                'auxiliar.Columns.Add("cta")
                'auxiliar.Columns.Add("cod_curso")
            Else
                intTamArr = auxiliar.Rows.Count 'TamanoArreglo2(auxiliar)
                Dim dr As DataRow
                For Each dr In auxiliar.Rows
                    If dr("rut_benefactor") <> "-1-9" Then
                        dr("rut_benefactor") = RutUsrALng(dr("rut_benefactor"))
                        dr("monto") = CLng(dr("monto"))
                    Else
                        dr("rut_benefactor") = -1
                        dr("monto") = -1
                    End If
                Next
            End If
            'mdtTerceros.Columns.Add("rut_benefactor")
            'mdtTerceros.Columns.Add("monto")
            'mdtTerceros.Columns.Add("cod_estado_solicitud")
            'mdtTerceros.Columns.Add("monto_adm")
            'mdtTerceros.Columns.Add("monto2")
            'mdtTerceros.Columns.Add("cta")
            'mdtTerceros.Columns.Add("cod_curso")
            'For i = 0 To intTamArr - 1
            '    If auxiliar.Rows(i)(0) <> "-1-9" Then
            '        auxiliar.Rows(i)(0) = RutUsrALng(auxiliar.Rows(i)(0))
            '        auxiliar.Rows(i)(1) = CLng(auxiliar.Rows(i)(1))
            '    Else
            '        auxiliar.Rows(i)(0) = -1
            '        auxiliar.Rows(i)(1) = -1
            '    End If
            'Next
            mdtTerceros = auxiliar
        End Set
    End Property
    'Public ReadOnly Property SaldoCtaCapVYT() As Long
    '    Get
    '        Dim lngDiezPorciento As Long
    '        Dim lngMontoUsadoEnVYT As Long

    '        lngDiezPorciento = Math.Round(mobjSql.s_monto_aportes_cliente_agno(RutLngAUsr(mobjCliente.Rut), mlngAgno, 1) * 0.1)
    '        lngMontoUsadoEnVYT = mobjSql.s_monto_usado_en_VYT(RutLngAUsr(mobjCliente.Rut), mlngAgno, 1)

    '        SaldoCtaCapVYT = lngDiezPorciento - lngMontoUsadoEnVYT
    '    End Get
    'End Property
    Public ReadOnly Property SaldoCtaCapVYT() As Long
        Get
            Dim lngDiezPorciento As Long
            Dim lngMontoUsadoEnVYT As Long

            lngDiezPorciento = Math.Round(mobjSql.s_saldos_capacitacion_vyt(RutLngAUsr(mobjCliente.Rut), mlngAgno))
            lngMontoUsadoEnVYT = mobjSql.s_monto_usado_en_VYT(RutLngAUsr(mobjCliente.Rut), mlngAgno, 1)

            SaldoCtaCapVYT = lngDiezPorciento - lngMontoUsadoEnVYT
        End Get
    End Property

    ' ''Public ReadOnly Property SaldoCtaExdCApVYT() As Long
    ' ''    Get
    ' ''        Dim lngDiezPorciento As Long
    ' ''        Dim lngMontoUsadoEnVYT As Long

    ' ''        'lngDiezPorciento = Math.Round(mobjSql.s_monto_abono_excedente_cliente_agno(RutLngAUsr(mobjCliente.Rut), mlngAgno - 1) * 0.1)
    ' ''        lngDiezPorciento = Math.Round(mobjSql.s_monto_aportes_cliente_agno(RutLngAUsr(mobjCliente.Rut), mlngAgno - 1, 1) * 0.1)
    ' ''        lngMontoUsadoEnVYT = mobjSql.s_monto_usado_en_VYT(RutLngAUsr(mobjCliente.Rut), mlngAgno, 4)
    ' ''        'If mobjCliente.ObjCuentaExcCap.SaldoActual < (lngDiezPorciento - lngMontoUsadoEnVYT) Then
    ' ''        'SaldoCtaExdCApVYT = mobjCliente.ObjCuentaExcCap.SaldoActual
    ' ''        ' Else
    ' ''        mobjCliente.ObjCuentaCap.Agno = mlngAgno - 1
    ' ''        mobjCliente.ObjCuentaCap.Inicializar(mobjCliente.Rut, 1)
    ' ''        If mobjCliente.ObjCuentaCap.SumaSaldoPend < (lngDiezPorciento - lngMontoUsadoEnVYT) Then
    ' ''            SaldoCtaExdCApVYT = mobjCliente.ObjCuentaCap.SumaSaldoPend
    ' ''        Else
    ' ''            SaldoCtaExdCApVYT = lngDiezPorciento - lngMontoUsadoEnVYT
    ' ''        End If

    ' ''        'End If
    ' ''    End Get
    ' ''End Property

    Public ReadOnly Property SaldoCtaExdCApVYT() As Long
        Get
            Dim resultado As Long = 0
            Dim lngDiesExCapPorAbono As Long
            Dim lngSaldoVYTAgnoAnterior As Long
            Dim lngMontoUsadoEnVYT As Long

            lngDiesExCapPorAbono = mobjSql.s_dies_vyt_excap_por_abono(RutLngAUsr(mobjCliente.Rut), mlngAgno)

            lngSaldoVYTAgnoAnterior = mobjSql.s_saldo_vyt_agno_anterior(RutLngAUsr(mobjCliente.Rut), mlngAgno - 1)

            lngMontoUsadoEnVYT = mobjSql.s_monto_usado_en_VYT(RutLngAUsr(mobjCliente.Rut), mlngAgno, 4)

            If lngDiesExCapPorAbono > lngSaldoVYTAgnoAnterior Then
                resultado = lngSaldoVYTAgnoAnterior
            ElseIf lngDiesExCapPorAbono = lngSaldoVYTAgnoAnterior Then
                resultado = lngSaldoVYTAgnoAnterior
            ElseIf lngDiesExCapPorAbono < lngSaldoVYTAgnoAnterior Then
                resultado = lngDiesExCapPorAbono
            End If

            'If lngDiesExCapPorAbono > lngSaldoVYTAgnoAnterior Then
            '    resultado = lngDiesExCapPorAbono
            'ElseIf lngDiesExCapPorAbono = lngSaldoVYTAgnoAnterior Then
            '    resultado = lngSaldoVYTAgnoAnterior
            'ElseIf lngDiesExCapPorAbono < lngSaldoVYTAgnoAnterior Then
            '    resultado = lngSaldoVYTAgnoAnterior
            'End If


            resultado = resultado - lngMontoUsadoEnVYT

            Return resultado
        End Get
    End Property


    'Public Property Terceros()
    '    Get
    '        Dim auxiliar As Object
    '        Dim i, intTamArr As Integer
    '        auxiliar = mdtTerceros
    '        intTamArr = TamanoArreglo2(auxiliar)
    '        For i = 0 To intTamArr - 1
    '            auxiliar(0, i) = RutLngAUsr(auxiliar(0, i))
    '        Next
    '        Terceros = auxiliar
    '    End Get
    '    Set(ByVal value)
    '        Dim auxiliar As Object
    '        Dim i, intTamArr As Integer
    '        auxiliar = value
    '        intTamArr = TamanoArreglo2(auxiliar)
    '        For i = 0 To intTamArr - 1
    '            If auxiliar(0, i) <> "-1-9" Then
    '                auxiliar(0, i) = RutUsrALng(auxiliar(0, i))
    '                auxiliar(1, i) = CLng(auxiliar(1, i))
    '            Else
    '                auxiliar(0, i) = -1
    '                auxiliar(1, i) = -1
    '            End If
    '        Next
    '        mdtTerceros = auxiliar
    '    End Set
    'End Property
    Public Property ModifCuentas() As DataTable
        Get
            Return mdtModifCuentas
        End Get
        Set(ByVal value As DataTable)
            mdtModifCuentas = value
        End Set
    End Property
    Public ReadOnly Property CursoCompl() As CCursoContratado
        Get
            Dim blnInic1 As Boolean

            mobjCursoCompl = Nothing
            If mlngCodCursoCompl > 0 And Not IsNothing(mlngCodCursoCompl) Then
                mobjCursoCompl = New CCursoContratado
                Call mobjCursoCompl.Inicializar0(mobjSql, mlngRutUsuario)
                blnInic1 = mobjCursoCompl.Inicializar1(mlngCodCursoCompl)
                If Not blnInic1 Then
                    mobjCursoCompl = Nothing
                    Exit Property
                Else
                    Call mobjCursoCompl.ObtenerAlumnos()
                    Call mobjCursoCompl.ObtenerInfoCuentas()
                End If
            Else
                mobjCursoCompl = Nothing
                Exit Property
            End If
            CursoCompl = mobjCursoCompl
        End Get
    End Property


    Public Property HorarioCurso() As DataTable
        Get
            Dim arrInicio, arrFin
            Dim dr As DataRow
            If Not IsDBNull(mdtHorarioCurso) Then
                If mdtHorarioCurso.Rows.Count > 0 Then
                    For Each dr In mdtHorarioCurso.Rows
                        If Trim(CStr(dr("HoraInicio"))) <> "" Then
                            arrInicio = Split(CStr(dr("HoraInicio")), ":", 2)
                            If Len(Trim(arrInicio(0))) > 0 And Len(Trim(arrInicio(0))) < 2 Then
                                arrInicio(0) = "0" & arrInicio(0)
                            End If
                            If Len(Trim(arrInicio(1))) > 0 And Len(Trim(arrInicio(1))) < 2 Then
                                arrInicio(1) = "0" & arrInicio(1)
                            End If
                            dr("HoraInicio") = Trim(arrInicio(0)) & ":" & Trim(arrInicio(1))
                        End If
                        If Trim(CStr(dr("HoraFin"))) <> "" Then
                            arrFin = Split(CStr(dr("HoraFin")), ":", 2)
                            If Len(Trim(arrFin(0))) > 0 And Len(Trim(arrFin(0))) < 2 Then
                                arrFin(0) = "0" & arrFin(0)
                            End If
                            If Len(Trim(arrFin(1))) > 0 And Len(Trim(arrFin(1))) < 2 Then
                                arrFin(1) = "0" & arrFin(1)
                            End If
                            dr("HoraFin") = Trim(arrFin(0)) & ":" & Trim(arrFin(1))
                        End If
                    Next
                Else
                    'mdtHorarioCurso.Columns.Add("Dia")
                    'mdtHorarioCurso.Columns.Add("HoraInicio")
                    'mdtHorarioCurso.Columns.Add("HoraFin")
                    'mdtHorarioCurso.Columns.Add("CodCurso")
                End If

            End If
            HorarioCurso = mdtHorarioCurso
        End Get
        Set(ByVal value As DataTable)
            mdtHorarioCurso = value
            'Dim arrInicio, arrFin

            'Dim i As Integer
            'Dim contador As Integer
            'contador = 0

            'Dim dr As DataRow
            'If Not IsDBNull(mdtHorarioCurso) Then
            '    For Each dr In value.Rows
            '        If Trim(dr("HoraInicio")) <> "" And Trim(dr("HoraFin")) <> "" Then
            '            Dim dr2 As DataRow
            '            dr2 = mdtHorarioCurso.NewRow
            '            dr2("CodCurso") = mlngCodCurso
            '            dr2("Dia") = dr("Dia")
            '            arrInicio = Split(CStr(dr("HoraInicio")), ":", 2)
            '            If Len(Trim(arrInicio(0))) > 0 And Len(Trim(arrInicio(0))) < 2 Then
            '                arrInicio(0) = "0" & arrInicio(0)
            '            End If
            '            If Len(Trim(arrInicio(1))) > 0 And Len(Trim(arrInicio(1))) < 2 Then
            '                arrInicio(1) = "0" & arrInicio(1)
            '            End If
            '            dr2("HoraInicio") = Trim(arrInicio(0)) & ":" & Trim(arrInicio(1))
            '            arrFin = Split(CStr(dr("HoraFin")), ":", 2)
            '            If Len(Trim(arrFin(0))) > 0 And Len(Trim(arrFin(0))) < 2 Then
            '                arrFin(0) = "0" & arrFin(0)
            '            End If
            '            If Len(Trim(arrFin(1))) > 0 And Len(Trim(arrFin(1))) < 2 Then
            '                arrFin(1) = "0" & arrFin(1)
            '            End If
            '            dr2("HoraFin") = Trim(arrFin(0)) & ":" & Trim(arrFin(1))
            '            mdtHorarioCurso.Rows.Add(dr2)
            '        End If
            '    Next
            'Else
            '    mdtHorarioCurso.Columns.Add("CodCurso")
            '    mdtHorarioCurso.Columns.Add("Dia")
            '    mdtHorarioCurso.Columns.Add("HoraInicio")
            '    mdtHorarioCurso.Columns.Add("HoraFin")
            '    For Each dr In value.Rows
            '        If Trim(dr("HoraInicio")) <> "" And Trim(dr("HoraFin")) <> "" Then
            '            Dim dr2 As DataRow
            '            dr2 = mdtHorarioCurso.NewRow
            '            dr2("CodCurso") = mlngCodCurso
            '            dr2("Dia") = dr("Dia")
            '            arrInicio = Split(CStr(dr("HoraInicio")), ":", 2)
            '            If Len(Trim(arrInicio(0))) > 0 And Len(Trim(arrInicio(0))) < 2 Then
            '                arrInicio(0) = "0" & arrInicio(0)
            '            End If
            '            If Len(Trim(arrInicio(1))) > 0 And Len(Trim(arrInicio(1))) < 2 Then
            '                arrInicio(1) = "0" & arrInicio(1)
            '            End If
            '            dr2("HoraInicio") = Trim(arrInicio(0)) & ":" & Trim(arrInicio(1))
            '            arrFin = Split(CStr(dr("HoraFin")), ":", 2)
            '            If Len(Trim(arrFin(0))) > 0 And Len(Trim(arrFin(0))) < 2 Then
            '                arrFin(0) = "0" & arrFin(0)
            '            End If
            '            If Len(Trim(arrFin(1))) > 0 And Len(Trim(arrFin(1))) < 2 Then
            '                arrFin(1) = "0" & arrFin(1)
            '            End If
            '            dr2("HoraFin") = Trim(arrFin(0)) & ":" & Trim(arrFin(1))
            '            mdtHorarioCurso.Rows.Add(dr2)
            '        End If
            '    Next
            'End If
        End Set
    End Property


    Public Property Alumnos() As Collection
        Get
            Return Me.mcolAlumnos
        End Get
        Set(ByVal value As Collection)
            mcolAlumnos = value
        End Set
    End Property


    Public Property GenerarNuevoCorr() As Boolean
        Get
            Return Me.mblnGenerarNuevoCorr
        End Get
        Set(ByVal value As Boolean)
            Me.mblnGenerarNuevoCorr = value
        End Set
    End Property
    Public Property CorrElearning() As Long
        Get
            Return Me.mlngCorrElearning
        End Get
        Set(ByVal value As Long)
            Me.mlngCorrElearning = value
        End Set
    End Property
    Public Property ModificarMontoSolicitudes() As Boolean
        Get
            Return mblnModificarMontoSolicitudes
        End Get
        Set(ByVal value As Boolean)
            mblnModificarMontoSolicitudes = value
        End Set
    End Property
    Public ReadOnly Property CorrelativoComplemento() As Long
        Get
            Return mlngCorrelativoComplemento
        End Get
    End Property
    Public ReadOnly Property EstadoComplemento() As Integer
        Get
            Return mintEstadoComplemento
        End Get
    End Property
    Public ReadOnly Property CostoOticComplemento() As Long
        Get
            Return mlngCostoOticComplemento
        End Get
    End Property
    Public ReadOnly Property CostoAdmComplemento() As Long
        Get
            Return mlngCostoAdmComplemento
        End Get
    End Property
    Public ReadOnly Property GastoEmpresaComplemento() As Long
        Get
            Return mlngGastoEmpresaComplemento
        End Get
    End Property
    Public ReadOnly Property LookUpModalidades() As DataTable
        Get
            LookUpModalidades = mdtModalidades
        End Get
    End Property
    Property NroDireccionCurso() As String
        Get
            Return Me.mstrNroDireccionCurso
        End Get
        Set(ByVal value As String)
            Me.mstrNroDireccionCurso = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return Me.mstrCiudad
        End Get
        Set(ByVal value As String)
            Me.mstrCiudad = value
        End Set
    End Property
    Public ReadOnly Property EtiquetaClasificador() As String
        Get
            mstrEtiquetaClasificador = mobjSql.s_etiqueta_por_empresa(mlngRutCliente)
            EtiquetaClasificador = mstrEtiquetaClasificador
        End Get
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
    Public Property CodTipoActivo() As Integer
        Get
            Return Me.mintCodTipoActivo
        End Get
        Set(ByVal value As Integer)
            Me.mintCodTipoActivo = value
        End Set
    End Property
    Public Property ColSolicitudes() As Collection
        Get
            Return mcolSolicitudes
        End Get
        Set(ByVal value As Collection)
            mcolSolicitudes = value
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


    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property


#End Region
    Public Sub New()
        mlngCodCurso = 0
        mlngCodElearning = 0
        mlngRutCliente = 0
        mintCodTipoActiv = 0
        mbolIndAcuComBip = False
        mbolIndDetNece = False
        mlngNumAlumnos = 0
        mstrDireccionCurso = ""
        mlngCodComuna = 0
        mstrCodSence = ""
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaTermino = FechaMaxSistema()
        mlngHorasCompl = 0.0
        mlngValorMercado = 0
        mlngDescuento = 0.0
        mblnModificarMontoSolicitudes = False
        mblnGenerarNuevoCorr = True
        mlngCorrElearning = 0

        mlngCorrelativo = 0
        mlngNroRegistro = -1
        mintCodEstadoCurso = 0
        mintCodUltEstadoCurso = 0
        mlngAgno = 0
        mdblPorcAdm = 0
        mlngCostoOtic = 0
        mlngCostoAdm = 0
        mlngGastoEmpresa = 0
        mdblValorHora = 0
        '------------- viatico y traslado ------------
        mlngCostoOticVYT = 0
        mlngCostoAdmVYT = 0
        mlngGastoEmpresaVYT = 0
        '---------------------------------------------
        mlngTotalViatico = 0
        mlngTotalTraslado = 0
        mintCodOrigen = 0
        mstrObsCurso = ""
        mlngValorComunicado = 0
        mstrObsLiquidacion = ""
        mlngHoras = 0.0
        mintNroFacturaOtec = -1
        mlngCodCursoCompl = -1
        mlngCodCursoParcial = -1
        mintIndDescPorc = 0
        mstrCorrEmpresa = ""
        mstrContactoAdicional = ""
        'mlngRutOtec = 0
        mblnCursoCFT = False

        mlngMaxParticipantes = 0
        mdtmFechaIngreso = FechaMinSistema()
        mdtmFechaModificacion = FechaMaxSistema()
        mlngCodRegion = 0
        mstrNomRegion = ""
        mintNumModificaciones = 0

        mlngMontoCtaCap = -1
        mlngMontoCtaExcCap = -1
        mlngTotMontoTerc = -1
        mlngMontoCtaBecas = -1
        mlngMontoRep = -1
        mlngMontoExcRep = -1

        '---------- V&t -----------
        mlngMontoCtaCapVYT = -1
        mlngMontoCtaExcCapVYT = -1

        '--------------------------

        mdtHorarioCurso = New DataTable
        mcolAlumnos = New Collection
        mdtListaTerceros = New DataTable
        mdtModifCuentas = New DataTable
        mcolSolicitudes = New Collection

        mobjParamGen = Nothing
        mobjOtec = Nothing
        mobjCliente = Nothing
        mobjCurso = Nothing
        mobjCursoCompl = Nothing
        mobjFactura = Nothing

        mlngRutEncargado = 0
    End Sub

    Public Sub Inicializar0(ByRef objSql As CSql, ByVal lngRutUsuario As Long)
        mobjSql = objSql
        If lngRutUsuario <= 0 Then
            EnviaError("cCursoContratado:Inicializar0 Method - Usuario desconocido")
            Exit Sub
        End If
        mlngRutUsuario = lngRutUsuario

        'cargar los lookup
        mdtTiposActiv = mobjSql.s_tipos_activ_todos
        mdtComunas = mobjSql.s_comunas_todos
        mdtModalidades = mobjSql.s_modalidades_todos

    End Sub
    Public Sub InicializarCsql(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub


    Public Function Inicializar1( _
            ByVal CodCurso, Optional ByVal blnFichaCompleta = False)

        Try
            If mobjSql Is Nothing Then
                mobjSql = New CSql
            End If
            Dim dtTemporal As DataTable
            Dim dtRegion As DataTable
            Dim varAuxiliar
            Dim tam1_arrTemp, tam2_arrTemp
            Dim existe_curso
            Dim ObjOtec As COtec
            Dim objCtaCap As CCuenta
            Dim objCtaExcCap As CCuenta
            Dim objCtaBecas As CCuenta


            dtTemporal = mobjSql.s_curso_contratado(CodCurso)
            tam1_arrTemp = mobjSql.Registros
            mcolAlumnos = New Collection
            mlngNumAlumnos = mobjSql.s_nro_participantes(CodCurso)
            mblnEsFinDeSemana = mobjSql.s_es_fin_de_semana(CodCurso)
            tam2_arrTemp = mobjSql.Registros

            If tam1_arrTemp = 0 Or tam2_arrTemp = 0 Then
                existe_curso = False
            Else


                mlngCodCurso = CodCurso
                mlngRutCliente = dtTemporal.Rows(0)(0)
                mintCodTipoActiv = dtTemporal.Rows(0)(1)
                mbolIndAcuComBip = dtTemporal.Rows(0)(2)

                mlngNumAlumnos = dtTemporal.Rows(0)(3)
                mbolIndDetNece = dtTemporal.Rows(0)(4)
                mstrDireccionCurso = dtTemporal.Rows(0)(5)
                mlngCodComuna = dtTemporal.Rows(0)(6)
                mstrCodSence = dtTemporal.Rows(0)(7)
                mdtmFechaInicio = dtTemporal.Rows(0)(8)
                mdtmFechaTermino = dtTemporal.Rows(0)(9)
                mlngHorasCompl = dtTemporal.Rows(0)(10)
                mlngValorMercado = dtTemporal.Rows(0)(11)
                mlngDescuento = dtTemporal.Rows(0)(12)

                varAuxiliar = mobjSql.s_cliente_nroperfil(mlngRutCliente, mlngRutUsuario)
                If Not IsDBNull(varAuxiliar) Then
                    mlngNroPerfil = mobjSql.s_cliente_nroperfil(mlngRutCliente, mlngRutUsuario)
                Else
                    mlngNroPerfil = 0
                End If
                mstrNomComuna = mobjSql.s_nom_comuna(mlngCodComuna)
                dtRegion = mobjSql.s_region(mlngCodComuna)
                mlngCodRegion = dtRegion.Rows(0)(0)
                mstrNomRegion = dtRegion.Rows(0)(1)

                mlngCorrelativo = dtTemporal.Rows(0)(13)
                'mlngNroRegistro = dtTemporal.Rows(0)(14)
                If IsDBNull(dtTemporal.Rows(0)(14)) Then
                    mlngNroRegistro = -1
                Else
                    mlngNroRegistro = dtTemporal.Rows(0)(14)
                End If
                mintCodEstadoCurso = dtTemporal.Rows(0)(15)
                mlngAgno = dtTemporal.Rows(0)(16)
                mdblPorcAdm = dtTemporal.Rows(0)(17)
                mlngCostoOtic = dtTemporal.Rows(0)(18)
                mlngCostoAdm = dtTemporal.Rows(0)(19)
                mlngGastoEmpresa = dtTemporal.Rows(0)(20)
                mlngTotalViatico = dtTemporal.Rows(0)(21)
                mlngTotalTraslado = dtTemporal.Rows(0)(22)
                mintCodOrigen = dtTemporal.Rows(0)(23)
                mstrObsCurso = dtTemporal.Rows(0)(24)
                mlngValorComunicado = dtTemporal.Rows(0)(25)
                mstrObsLiquidacion = dtTemporal.Rows(0)(26)
                mlngHoras = dtTemporal.Rows(0)(27)
                'If Not IsDBNull(dtTemporal.Rows(0)(37) > 0) Then
                If Not IsDBNull(dtTemporal.Rows(0)(37)) Then
                    mlngHoras = mobjSql.s_horas_complementarias(dtTemporal.Rows(0)(37))
                Else
                    mlngHoras = dtTemporal.Rows(0)(27)
                End If

                'End If

                'mintNroFacturaOtec = dtTemporal.Rows(0)(28)
                If IsDBNull(dtTemporal.Rows(0)(28)) Then
                    mintNroFacturaOtec = -1
                Else
                    mintNroFacturaOtec = dtTemporal.Rows(0)(28)
                End If
                'mdtmFechaPagoFactura = dtTemporal.Rows(0)(29)
                If IsDBNull(dtTemporal.Rows(0)(29)) Then
                    mdtmFechaPagoFactura = FechaMinSistema()
                Else
                    mdtmFechaPagoFactura = dtTemporal.Rows(0)(29)
                End If
                'mlngCodCursoCompl = dtTemporal.Rows(0)(30)
                If IsDBNull(dtTemporal.Rows(0)(30)) Then
                    mlngCodCursoCompl = -1
                Else
                    mlngCodCursoCompl = dtTemporal.Rows(0)(30)
                End If
                mintIndDescPorc = dtTemporal.Rows(0)(31)
                mstrCorrEmpresa = dtTemporal.Rows(0)(32)
                If IsDBNull(dtTemporal.Rows(0)(33)) Then
                    mdtmFechaIngreso = FechaMinSistema()
                Else
                    mdtmFechaIngreso = dtTemporal.Rows(0)(33)
                End If
                If IsDBNull(dtTemporal.Rows(0)(34)) Then
                    mdtmFechaModificacion = FechaMinSistema()
                Else
                    mdtmFechaModificacion = dtTemporal.Rows(0)(34)
                End If
                If IsDBNull(dtTemporal.Rows(0)(35)) Then
                    mdtmFechaComunicacion = FechaMinSistema()
                Else
                    mdtmFechaComunicacion = dtTemporal.Rows(0)(35)
                End If
                If IsDBNull(dtTemporal.Rows(0)(36)) Then
                    mdtmFechaLiquidacion = FechaMinSistema()
                Else
                    mdtmFechaLiquidacion = dtTemporal.Rows(0)(36)
                End If

                If IsDBNull(dtTemporal.Rows(0)(37)) Then
                    mlngCodCursoParcial = -1
                Else
                    mlngCodCursoParcial = dtTemporal.Rows(0)(37)
                End If
                mstrContactoAdicional = dtTemporal.Rows(0)(38)
                mstrObservacion = dtTemporal.Rows(0)(39)
                mlngCodElearning = dtTemporal.Rows(0)(40)
                If IsDBNull(dtTemporal.Rows(0)(40)) Then
                    mlngCodElearning = 0
                Else
                    mlngCodElearning = dtTemporal.Rows(0)(40)
                End If

                mintCodUltEstadoCurso = dtTemporal.Rows(0)(41) '**|**

                '------------viatico y traslado --------------
                mlngCostoOticVYT = dtTemporal.Rows(0)(42)
                mlngCostoAdmVYT = dtTemporal.Rows(0)(43)
                mlngGastoEmpresaVYT = dtTemporal.Rows(0)(44)
                '---------------------------------------------
                '-------Detalle de la dirección-------
                If IsDBNull(dtTemporal.Rows(0)(46)) Then
                    dtTemporal.Rows(0)(46) = ""
                End If
                If IsDBNull(dtTemporal.Rows(0)(47)) Then
                    dtTemporal.Rows(0)(47) = ""
                End If
                mstrNroDireccionCurso = dtTemporal.Rows(0)(46)
                mstrCiudad = dtTemporal.Rows(0)(47)
                '-------------------------------------
                mlngCodModalidad = dtTemporal.Rows(0)(45)
                mdblValorHora = dtTemporal.Rows(0)(48)
                mblnCursoCFT = dtTemporal.Rows(0)(49)

                mlngRutEncargado = dtTemporal.Rows(0)(50)

                mstrNombreModalidad = mobjSql.s_nom_modalidad(mlngCodModalidad)

                'Los siguientes tres parametros tienen un valor invalido (-1)
                'Hasta que se pueden inicializar con la Informacion de las cuentas
                mlngMontoCtaCap = -1
                mlngMontoCtaExcCap = -1
                mlngTotMontoTerc = -1

                '------------viatico y traslado --------------
                mlngMontoCtaCapVYT = -1
                mlngMontoCtaExcCapVYT = -1

                '---------------------------------------------

                mintNumModificaciones = 0

                existe_curso = True

                ObtenerHorarioBD(mlngCodCurso)

                'obtención de información adicional, para la ficha del curso
                'If blnFichaCompleta Then
                Dim dtDatosAdic As DataTable
                'información del complemento del curso
                If mlngHorasCompl = 0 Then   'el curso no tiene complemento
                    mlngCorrelativoComplemento = -1
                    mintEstadoComplemento = -1
                    mlngCostoOticComplemento = 0
                    mlngCostoAdmComplemento = 0
                    mlngGastoEmpresaComplemento = 0

                ElseIf mlngCodCursoCompl <> -1 Then  'el curso tiene complemento generado
                    dtDatosAdic = mobjSql.s_curso_contratado(mlngCodCursoCompl)
                    'se comentó porque se quiere ver la fecha de término del curso parcial
                    'mdtmFechaTermino = arrDatosAdic(8, 0)
                    mlngCorrelativoComplemento = dtDatosAdic.Rows(0)(13)
                    mintEstadoComplemento = dtDatosAdic.Rows(0)(15)
                    mlngCostoOticComplemento = dtDatosAdic.Rows(0)(18)
                    mlngCostoAdmComplemento = dtDatosAdic.Rows(0)(19)
                    mlngGastoEmpresaComplemento = dtDatosAdic.Rows(0)(20)

                Else  'el curso tiene complemento, pero todavía no se genera
                    mlngCorrelativoComplemento = 0
                    mintEstadoComplemento = 0
                    Dim dblFactorHoras As Double
                    dblFactorHoras = mlngHorasCompl / (mlngHoras - mlngHorasCompl)
                    mlngCostoOticComplemento = Math.Round(dblFactorHoras * mlngCostoOtic, 0)
                    mlngCostoAdmComplemento = 0
                    mlngGastoEmpresaComplemento = Math.Round(dblFactorHoras * mlngGastoEmpresa, 0)
                End If

            End If  'solicitud de ficha completa

            'End If


            mobjCurso = New CCurso
            Call mobjCurso.Inicializar0(mobjSql, mlngRutUsuario)
            Call mobjCurso.Inicializar1(mstrCodSence)
            mlngRutOtec = mobjCurso.RutOtec
            ObjOtec = mobjCurso.Otec
            mobjOtec = ObjOtec
            ObjOtec = Nothing

            mobjParamGen = New CParamGen
            Call mobjParamGen.Inicializar()

            Me.mobjOtec = New COtec
            Call mobjOtec.Inicializar0(mobjSql, mlngRutUsuario)
            Call mobjOtec.Inicializar1(RutLngAUsr(mlngRutOtec))
            ObjOtec = Nothing


            mobjFactura = New CFactura
            Call mobjFactura.Inicializar0(mobjSql, mlngRutUsuario)
            Dim blnTemp
            blnTemp = mobjFactura.Inicializar2(mlngCodCurso)

            Dim blnInicCliente
            mobjCliente = New CCliente
            mobjCliente.Agno = mlngAgno
            Call mobjCliente.Inicializar0(mobjSql, mlngRutUsuario)
            blnInicCliente = mobjCliente.Inicializar1(RutLngAUsr(mlngRutCliente))
            If blnInicCliente Then
                objCtaCap = mobjCliente.ObjCuentaCap
                '**********--------------
                mstrGiro = mobjCliente.Giro
                mstrFonoContacto = mobjCliente.FonoContacto
                mstrFaxContacto = mobjCliente.Fax

                objCtaExcCap = mobjCliente.ObjCuentaExcCap
                Dim cod_cuenta As Integer
                cod_cuenta = mobjCliente.ObjCuentaCap.CodCuenta
                objCtaCap.Inicializar(mlngRutCliente, cod_cuenta, "")
                mlngSaldoCtaCap = objCtaCap.SaldoActual
                mlngSaldoCtaExcCap = objCtaExcCap.SaldoActual

                '**|**Cuenta becas, pago de cursos complementarios
                objCtaBecas = mobjCliente.ObjCuentaBecas
                mlngSaldoCtaBecas = objCtaCap.SaldoActual
                objCtaBecas = Nothing

                objCtaCap = Nothing
                objCtaExcCap = Nothing
            Else
                Inicializar1 = False
                Exit Function
            End If

            Inicializar1 = existe_curso
        Catch ex As Exception
            EnviaError("cCursoContratado:Inicializar1-->" & ex.Message)
        End Try
    End Function




    'Obtiene Horario del Curso desde la BD
    Public Sub ObtenerHorarioBD(ByVal lngCodCurso As Long)
        Try
            Dim dtHorario As DataTable
            Dim i As Integer
            Dim cols As Integer

            dtHorario = mobjSql.s_horario_curso(lngCodCurso)
            'cols = TamanoArreglo2(dtHorario)

            mdtHorarioCurso = New DataTable
            mdtHorarioCurso.Columns.Add("CodCurso")
            mdtHorarioCurso.Columns.Add("Dia")
            mdtHorarioCurso.Columns.Add("HoraInicio")
            mdtHorarioCurso.Columns.Add("HoraFin")

            Dim dr As DataRow
            Dim drHorarioCurso As DataRow
            For Each dr In dtHorario.Rows
                drHorarioCurso = mdtHorarioCurso.NewRow
                drHorarioCurso("CodCurso") = dr.Item(0)
                drHorarioCurso("Dia") = dr.Item(1)
                drHorarioCurso("HoraInicio") = dr.Item(2)
                drHorarioCurso("HoraFin") = dr.Item(3)
                mdtHorarioCurso.Rows.Add(drHorarioCurso)
            Next
        Catch ex As Exception

        End Try
    End Sub
    'Obtiene Horario del Curso desde la BD
    Public Sub ObtenerHorarioCSV(ByVal strCodCurso As String)
        Try
            Dim dtHorario As DataTable
            Dim i As Integer
            Dim cols As Integer

            dtHorario = mobjSql.s_horario_curso_csv(strCodCurso)
            'cols = TamanoArreglo2(dtHorario)

            mdtHorarioCurso = New DataTable
            mdtHorarioCurso.Columns.Add("rut_cliente")
            mdtHorarioCurso.Columns.Add("codigo_sence")
            mdtHorarioCurso.Columns.Add("fecha_inicio")
            mdtHorarioCurso.Columns.Add("CodCurso")
            mdtHorarioCurso.Columns.Add("Dia")
            mdtHorarioCurso.Columns.Add("HoraInicio")
            mdtHorarioCurso.Columns.Add("HoraFin")


            Dim dr As DataRow
            Dim drHorarioCurso As DataRow
            For Each dr In dtHorario.Rows
                drHorarioCurso = mdtHorarioCurso.NewRow
                drHorarioCurso("CodCurso") = dr.Item(0)
                drHorarioCurso("Dia") = dr.Item(1)
                drHorarioCurso("HoraInicio") = dr.Item(2)
                drHorarioCurso("HoraFin") = dr.Item(3)
                drHorarioCurso("rut_cliente") = dr.Item(4)
                drHorarioCurso("codigo_sence") = dr.Item(5)
                drHorarioCurso("fecha_inicio") = FechaVbAUsr(dr.Item(6))
                mdtHorarioCurso.Rows.Add(drHorarioCurso)
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Inicializar2: Inicializa el objeto CursoContratado
    Public Sub Inicializar2(ByVal strRutCliente As String, ByVal intCodTipoActiv As Integer, _
                            ByVal bolIndAcuComBip As Boolean, ByVal bolIndDetNece As Boolean, _
                            ByVal lngParticipantes As Long, ByVal strDireccionCurso As String, _
                            ByVal lngCodComuna As Long, ByVal strCodSence As String, _
                            ByVal dtmFechaInicio As String, ByVal dtmFechaTermino As String, _
                            ByVal lngHorasCompl As Double, ByVal lngValorMercado As Long, _
                            ByVal lngDescuento As Double, ByVal strCorrEmpresa As String, _
                            ByVal intIndDescPorc As Integer, ByVal strContactoAdicional As String, _
                            ByVal strObservacion As String, _
                            ByVal strNroDireccionCurso As String, ByVal strCiudad As String, _
                            Optional ByVal intAgno As Integer = 0, _
                            Optional ByVal intCodModalidad As Integer = 0, _
                            Optional ByVal dblValorHora As Double = 0.0, _
                            Optional ByVal blnCursoCFT As Boolean = False, _
                            Optional ByVal lngRutEncargado As Long = 0)
        Try
            Dim dtRegion As DataTable
            Dim ObjOtec As COtec
            Dim objCtaCap As CCuenta
            Dim objCtaExcCap As CCuenta

            mlngRutCliente = RutUsrALng(strRutCliente)
            mintCodTipoActiv = intCodTipoActiv
            mbolIndAcuComBip = bolIndAcuComBip
            mbolIndDetNece = bolIndDetNece
            mlngNumAlumnos = lngParticipantes
            mstrDireccionCurso = strDireccionCurso
            mlngCodComuna = lngCodComuna
            mstrCodSence = strCodSence
            mdtmFechaInicio = FechaUsrAVb(dtmFechaInicio)
            mdtmFechaTermino = FechaUsrAVb(dtmFechaTermino)
            mlngHorasCompl = lngHorasCompl
            mlngValorMercado = lngValorMercado
            mlngDescuento = lngDescuento
            mstrCorrEmpresa = strCorrEmpresa
            mstrContactoAdicional = strContactoAdicional
            mstrObservacion = strObservacion
            mdblValorHora = dblValorHora
            mblnCursoCFT = blnCursoCFT
            If intIndDescPorc Then
                mintIndDescPorc = 1
            Else
                mintIndDescPorc = 0
            End If

            mlngCodModalidad = intCodModalidad

            mlngRutEncargado = lngRutEncargado

            mdtmFechaPagoFactura = FechaMinSistema()
            mdtmFechaComunicacion = FechaMinSistema()
            mdtmFechaLiquidacion = FechaMinSistema()

            dtRegion = mobjSql.s_region(mlngCodComuna)
            mlngCodRegion = dtRegion.Rows(0)(0)
            mstrNomRegion = dtRegion.Rows(0)(1)
            If intAgno = 0 Then
                mlngAgno = Year(mdtmFechaInicio)
            Else
                mlngAgno = intAgno
            End If

            mobjCurso = New CCurso
            Call mobjCurso.Inicializar0(mobjSql, mlngRutUsuario)
            Call mobjCurso.Inicializar1(mstrCodSence)
            ObjOtec = mobjCurso.Otec
            mobjOtec = ObjOtec
            ObjOtec = Nothing

            'Me.mobjOtec = New COtec
            'Call mobjOtec.Inicializar0(mobjSql, mlngRutUsuario)
            'Call mobjOtec.Inicializar1(mlngRutOtec)
            'ObjOtec = Nothing

            Dim blnInicCliente As Boolean
            mobjCliente = New CCliente
            Call mobjCliente.Inicializar0(mobjSql, mlngRutUsuario)
            mobjCliente.Agno = intAgno
            blnInicCliente = mobjCliente.Inicializar1(RutLngAUsr(mlngRutCliente))
            If blnInicCliente Then
                mdblPorcAdm = mobjCliente.CostoAdm
                objCtaCap = mobjCliente.ObjCuentaCap
                objCtaExcCap = mobjCliente.ObjCuentaExcCap
                mlngSaldoCtaCap = objCtaCap.SaldoActual
                mlngSaldoCtaExcCap = objCtaExcCap.SaldoActual
                objCtaCap = Nothing
                objCtaExcCap = Nothing
            Else
                EnviaError("cCursoContratado:Inicilizar2 - ERROR: Cliente Mal Inicializado")
                Exit Sub
            End If

            Dim blnInicFactura As Boolean
            mobjFactura = New CFactura
            Call mobjFactura.Inicializar0(mobjSql, mlngRutUsuario)
            blnInicFactura = mobjFactura.Inicializar2(mlngCodCurso)

            'Estos son los valores que despues se deben llenar en la
            'construccion de los diferentes objetos. Por ahora se les
            'dan valores constantes.

            If mlngCodCurso = 0 Then
                mlngCorrelativo = 0
                mlngNroRegistro = -1
                mintCodEstadoCurso = 0      '0 corresponde al estado "Incompleto" del curso
                mlngCostoOtic = 0
                mlngCostoAdm = 0
                mlngGastoEmpresa = 0
                '------------viatico y traslado --------------
                mlngCostoOticVYT = 0
                mlngCostoAdmVYT = 0
                mlngGastoEmpresaVYT = 0
                '---------------------------------------------
                mlngTotalViatico = 0
                mlngTotalTraslado = 0
                mintCodOrigen = 0
                mstrObsCurso = ""
                mlngValorComunicado = 0
                mstrObsLiquidacion = ""
                If mlngCodCursoParcial <= 0 Then
                    mlngHoras = mobjCurso.DurCursoTeorico + mobjCurso.DurCursoPractico + mobjCurso.DurCurElearning
                End If
                mlngMaxParticipantes = mobjCurso.NumMaxParticip
                mintNroFacturaOtec = -1

                mlngCodCursoCompl = -1
                mdtmFechaIngreso = FechaMinSistema()
                mdtmFechaModificacion = FechaMaxSistema()
                mintNumModificaciones = 0

                mdblPorcAdm = mobjCliente.CostoAdm
            End If

            'Los siguientes tres parametros tienen un valor invalido (-1)
            'Hasta que se pueden inicializar con la Informacion de las cuentas
            mlngMontoCtaCap = -1
            mlngMontoCtaExcCap = -1
            mlngTotMontoTerc = -1

            '---------------- viatico y traslado ---------------
            mlngMontoCtaCapVYT = -1
            mlngMontoCtaExcCapVYT = -1

            '---------------------------------------------------

            '-------detalle de la dirección del curso-----------
            mstrNroDireccionCurso = strNroDireccionCurso
            mstrCiudad = strCiudad
            '---------------------------------------------------

            Exit Sub
        Catch ex As Exception
            EnviaError("cCursoContratado:Inicializar2 Function-->" & ex.Message)
        End Try
    End Sub
    'inicialización de un curso con el número de registro
    Function InicializarNroRegistro(ByVal lngNroRegistro As Long, _
            Optional ByVal strEstados As String = "") As Boolean
        Try
            'código del curso
            Dim lngCodCurso As Long
            lngCodCurso = mobjSql.s_curso_contr_6(lngNroRegistro, strEstados)

            InicializarNroRegistro = Inicializar1(lngCodCurso)
        Catch ex As Exception
            EnviaError("cCursoContratado:InicializarNroRegistro Function-->" & ex.Message)
        End Try
    End Function

    Public Sub InicializarNuevo()
        Try
            mlngCodCurso = 0
            mlngRutCliente = 0
            mintCodTipoActiv = 0
            mbolIndAcuComBip = False
            mbolIndDetNece = False
            mlngNumAlumnos = 0
            mstrDireccionCurso = ""
            mlngCodComuna = 0
            mstrCodSence = ""
            mdtmFechaInicio = FechaMinSistema()
            mdtmFechaTermino = FechaMaxSistema()
            mlngHorasCompl = 0
            mlngValorMercado = 0
            mlngDescuento = 0

            mlngCorrelativo = 0
            mlngNroRegistro = -1
            mintCodEstadoCurso = 0
            mintCodUltEstadoCurso = 0
            mlngAgno = 0
            mdblPorcAdm = 0
            mlngCostoOtic = 0
            mlngCostoAdm = 0
            mlngGastoEmpresa = 0
            '------------- viatico y traslado ------------
            mlngCostoOticVYT = 0
            mlngCostoAdmVYT = 0
            mlngGastoEmpresaVYT = 0
            '---------------------------------------------
            mlngTotalViatico = 0
            mlngTotalTraslado = 0
            mintCodOrigen = 0
            mstrObsCurso = ""
            mlngValorComunicado = 0
            mstrObsLiquidacion = ""
            mlngHoras = 0
            mintNroFacturaOtec = -1
            mdtmFechaPagoFactura = FechaMinSistema()
            mlngCodCursoCompl = -1
            mlngCodCursoParcial = -1
            mintIndDescPorc = 0
            mstrCorrEmpresa = ""
            mstrContactoAdicional = ""
            mstrObservacion = ""
            mblnCursoCFT = False

            mlngMaxParticipantes = 0
            mdtmFechaIngreso = Now.Date
            mdtmFechaModificacion = Now.Date
            mlngCodRegion = 0
            mstrNomRegion = ""
            mintNumModificaciones = 0
            mdtmFechaComunicacion = FechaMinSistema()
            mdtmFechaLiquidacion = FechaMinSistema()

            mlngMontoCtaCap = -1
            mlngMontoCtaExcCap = -1
            mlngTotMontoTerc = -1

            '---------- V&t -----------
            mlngMontoCtaCapVYT = -1
            mlngMontoCtaExcCapVYT = -1

            '--------------------------

            mdtHorarioCurso = New DataTable
            mcolAlumnos = New Collection
            mdtTerceros = New DataTable
            mdtModifCuentas = New DataTable
            mcolSolicitudes = New Collection

            mobjOtec = Nothing
            mobjCliente = Nothing
            mobjCurso = Nothing
            mobjCursoCompl = Nothing
            mobjFactura = Nothing
            ObtenerHorarioBD(mlngCodCurso)
        Catch ex As Exception
            EnviaError("cCursoContratado:InicializarNuevo-->" & ex.Message)
        End Try
    End Sub

    'reinicialización del curso
    Function ReInicializar() As Boolean
        Try
            ReInicializar = Inicializar1(mlngCodCurso)
        Catch ex As Exception
            EnviaError("cCursoContratado:ReInicializar-->" & ex.Message)
        End Try

    End Function
    Public Function GrabarDatos() As Long
        Try
            Dim dtCodCcurso As DataTable
            Dim aux As Long
            'Dim tam_arr1, tam_arr2 As Integer

            'abrir transaccion
            mobjSql.InicioTransaccion()

            Call mobjSql.i_curso_contr(mlngRutCliente, mintCodTipoActiv, _
                                       mbolIndAcuComBip, mbolIndDetNece, _
                                       mlngNumAlumnos, mstrDireccionCurso, _
                                       mlngCodComuna, mstrCodSence, _
                                       mdtmFechaInicio, mdtmFechaTermino, _
                                       mlngHorasCompl, mlngValorMercado, _
                                       mlngDescuento, mlngCorrelativo, _
                                       mlngNroRegistro, mintCodEstadoCurso, _
                                       mlngAgno, mdblPorcAdm, _
                                       mlngCostoOtic, mlngCostoAdm, _
                                       mlngGastoEmpresa, mlngCostoOticVYT, _
                                       mlngCostoAdmVYT, mlngGastoEmpresaVYT, _
                                       mlngTotalViatico, _
                                       mlngTotalTraslado, mintCodOrigen, _
                                       mstrObsCurso, mlngValorComunicado, _
                                       mstrObsLiquidacion, mlngHoras, _
                                       mintNroFacturaOtec, mdtmFechaPagoFactura, _
                                       mlngCodCursoCompl, mintIndDescPorc, _
                                       mstrCorrEmpresa, mlngCodCursoParcial, _
                                       mstrContactoAdicional, mstrObservacion, mlngCodModalidad, _
                                       mstrNroDireccionCurso, mstrCiudad, mblnCursoCFT, _
                                       mdblValorHora, mlngRutEncargado)


            'consultas para determinar el código interno del curso ingresado
            dtCodCcurso = mobjSql.s_cod_curso_contr()
            If mobjSql.Registros = 0 Then
                aux = -1
            ElseIf mobjSql.Registros = 1 Then
                aux = dtCodCcurso.Rows(0)(0)
                mlngCodCurso = CLng(aux)
            ElseIf mobjSql.Registros > 1 Then
                aux = -1
            End If

            Call mobjSql.i_bitacora(mlngRutUsuario, "Incompleto", _
                                "Ingreso del Encabezado del Curso Contratado. Cliente: " & RutLngAUsr(mlngRutCliente), _
                                1, mlngCodCurso)

            'cerrar transaccion
            mobjSql.FinTransaccion()

            GrabarDatos = CLng(aux)

        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("cCursoContratado:GrabarDatos Function-->" & ex.Message)
        End Try
    End Function
    'actualiza los datos del encabezado del curso
    'si el parámetro intCasoBitacora es > 0, ingresa un registro en la bitácora
    Public Sub ActualizarDatos(ByVal intCasoBitacora As Integer)
        Try

            Dim strEstadoCurso, strGlosa As String
            Dim blnAuxiliar As Boolean

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

            Call ObtenerAlumnos()
            Call CalcularCostos()
            Call CalcCostoAdm()

            mobjSql.InicioTransaccion()
            Call mobjSql.u_curso_contr(mlngRutCliente, mintCodTipoActiv, _
                                       mbolIndAcuComBip, mbolIndDetNece, _
                                       mlngNumAlumnos, mstrDireccionCurso, _
                                       mlngCodComuna, mstrCodSence, _
                                       mdtmFechaInicio, mdtmFechaTermino, _
                                       mlngHorasCompl, mlngValorMercado, _
                                       mlngDescuento, mlngCorrelativo, _
                                       mlngNroRegistro, mlngAgno, _
                                       mdblPorcAdm, mlngCostoOtic, _
                                       mlngCostoAdm, mlngGastoEmpresa, _
                                       mlngCostoOticVYT, mlngCostoAdmVYT, _
                                       mlngGastoEmpresaVYT, _
                                       mlngTotalViatico, mlngTotalTraslado, _
                                       mintCodOrigen, mstrObsCurso, _
                                       mlngValorComunicado, mstrObsLiquidacion, _
                                       mlngHoras, mintNroFacturaOtec, _
                                       mdtmFechaPagoFactura, mlngCodCursoCompl, _
                                       mintIndDescPorc, mstrCorrEmpresa, _
                                       mdtmFechaComunicacion, mdtmFechaLiquidacion, _
                                       mlngCodCurso, mstrContactoAdicional, mstrObservacion, _
                                       mlngCodModalidad, _
                                       mstrNroDireccionCurso, mstrCiudad, mblnCursoCFT, _
                                       mdblValorHora, mlngRutEncargado)

            Select Case intCasoBitacora
                Case 0          'No se escribe en la bitacora
                    strGlosa = ""
                Case 1          'Se actualizan los datos de encabezado del curso
                    strGlosa = "Actualizacion de los datos del Curso Contratado. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 2          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de los Alumnos del Curso Contratado. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 3          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso/Modif de asistencia. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 4          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de Nro de registro por liquidación de Curso Parcial. Cliente: " & RutLngAUsr(mlngRutCliente)
            End Select

            If intCasoBitacora > 0 Then
                Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, strGlosa, 1, mlngCodCurso)
            End If

            Call GrabarHorario()
            mobjSql.FinTransaccion()
            Exit Sub
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("cCursoContratado:ActualizarDatos Method-->" & ex.Message)
        End Try

    End Sub
    Public Sub ActualizarDatos2(ByVal intCasoBitacora As Integer)
        Try
            Dim strEstadoCurso, strGlosa As String
            Dim blnAuxiliar As Boolean

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

            Call ObtenerAlumnos()
            ' Call CalcularCostos()
            'Call CalcCostoAdm()

            Call mobjSql.u_curso_contr(mlngRutCliente, mintCodTipoActiv, _
                                       mbolIndAcuComBip, mbolIndDetNece, _
                                       mlngNumAlumnos, mstrDireccionCurso, _
                                       mlngCodComuna, mstrCodSence, _
                                       mdtmFechaInicio, mdtmFechaTermino, _
                                       mlngHorasCompl, mlngValorMercado, _
                                       mlngDescuento, mlngCorrelativo, _
                                       mlngNroRegistro, mlngAgno, _
                                       mdblPorcAdm, mlngCostoOtic, _
                                       mlngCostoAdm, mlngGastoEmpresa, _
                                       mlngCostoOticVYT, mlngCostoAdmVYT, _
                                       mlngGastoEmpresaVYT, _
                                       mlngTotalViatico, mlngTotalTraslado, _
                                       mintCodOrigen, mstrObsCurso, _
                                       mlngValorComunicado, mstrObsLiquidacion, _
                                       mlngHoras, mintNroFacturaOtec, _
                                       mdtmFechaPagoFactura, mlngCodCursoCompl, _
                                       mintIndDescPorc, mstrCorrEmpresa, _
                                       mdtmFechaComunicacion, mdtmFechaLiquidacion, _
                                       mlngCodCurso, mstrContactoAdicional, mstrObservacion, _
                                       mlngCodModalidad, _
                                       mstrNroDireccionCurso, mstrCiudad, mblnCursoCFT, mdblValorHora, mlngRutEncargado)

            Select Case intCasoBitacora
                Case 0          'No se escribe en la bitacora
                    strGlosa = ""
                Case 1          'Se actualizan los datos de encabezado del curso
                    strGlosa = "Actualizacion de los datos del Curso Contratado. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 2          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de los Alumnos del Curso Contratado. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 3          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso/Modif de asistencia. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 4          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de Nro de registro por liquidación de Curso Parcial. Cliente: " & RutLngAUsr(mlngRutCliente)
            End Select

            If intCasoBitacora > 0 Then
                Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, strGlosa, 1, mlngCodCurso)
            End If

            Call GrabarHorario()

            Exit Sub
        Catch ex As Exception
            EnviaError("cCursoContratado:ActualizarDatos Method-->" & ex.Message)
        End Try

    End Sub
    Public Function ObtenerAlumnos(Optional ByVal dblRutAlumno As Double = 0) As Collection
        Try
            Dim i, intTamArrAls, intTamArrRuts As Integer
            Dim r_inic As Boolean
            Dim dtTemporal As New DataTable
            Dim dtRutAlumnos As New DataTable
            dtRutAlumnos = mobjSql.s_rut_partic(mlngCodCurso, dblRutAlumno)
            If mobjSql.Registros > 0 Then
                mcolAlumnos = New Collection
                Dim dr As DataRow
                For Each dr In dtRutAlumnos.Rows
                    Dim objCalumno As New CAlumno
                    Dim strRut As String
                    objCalumno.Inicializar0(mobjSql)
                    objCalumno.CodCursoInscrito = mlngCodCurso
                    objCalumno.RutEmpresa = RutLngAUsr(mlngRutCliente)
                    'objCalumno.PorcAsistencia = 0
                    strRut = RutLngAUsr(dr.Item(0))
                    objCalumno.Inicializar(strRut)
                    mcolAlumnos.Add(objCalumno)
                Next
            End If
            ObtenerAlumnos = mcolAlumnos
        Catch ex As Exception
            EnviaError("CCursoContratado:ObtenerAlumnos-->" & ex.Message)
        End Try
    End Function
    Public Function ObtenerAlumnosCsv(ByVal strCodCurso As String) As DataTable
        Try
            Dim i, intTamArrAls, intTamArrRuts As Integer
            Dim r_inic As Boolean
            Dim dtTemporal As New DataTable
            Dim dtRutAlumnos As New DataTable
            dtRutAlumnos = mobjSql.s_alumno_curso_csv(strCodCurso)

            ObtenerAlumnosCsv = dtRutAlumnos
        Catch ex As Exception
            EnviaError("CCursoContratado:ObtenerAlumnos-->" & ex.Message)
        End Try
    End Function
    'Public Function ObtenerAlumnosElearning() As Collection
    '    Try
    '        Dim dtAlumnoElearning As DataTable
    '        dtAlumnoElearning = mobjSql.s_alumnos_elearning(mlngCodElearning)
    '        If mobjSql.Registros > 0 Then
    '            'inicializar los alumnos y el costo del curso de Elearning
    '            Dim objCursoContr As CCursoContratado
    '            mlngValorMercado = 0
    '            mlngDescuento = 0
    '            mlngMontoCtaCap = 0
    '            mlngMontoCtaExcCap = 0
    '            mlngTotMontoTerc = 0
    '            mlngGastoEmpresa = 0
    '            '--------- V&T --------
    '            mlngMontoCtaCapVYT = 0
    '            mlngMontoCtaExcCapVYT = 0
    '            '----------------------
    '            Dim dr As DataRow
    '            For Each dr In dtAlumnoElearning.Rows
    '                objCursoContr = New CCursoContratado
    '                Call objCursoContr.Inicializar0(mobjSql, mlngRutUsuario)
    '                Call objCursoContr.Inicializar1(dr.Item(0))  'código del curso
    '                Call objCursoContr.ObtenerAlumnos()
    '                Call objCursoContr.ObtenerInfoCuentas()
    '                'calcular valor de mercado original y descuento
    '                mlngValorMercado = mlngValorMercado + objCursoContr.ValorMercado
    '                mlngDescuento = mlngDescuento + objCursoContr.Descuento
    '                mlngMontoCtaCap = mlngMontoCtaCap + objCursoContr.MontoCtaCap
    '                mlngMontoCtaExcCap = mlngMontoCtaExcCap + objCursoContr.MontoCtaExcCap
    '                mlngTotMontoTerc = mlngTotMontoTerc + objCursoContr.TotMontoTerc
    '                mlngGastoEmpresa = mlngGastoEmpresa + objCursoContr.GastoEmpresa

    '                mlngMontoCtaCapVYT = mlngMontoCtaCapVYT + objCursoContr.MontoCtaCapVYT
    '                mlngCostoAdmVYT = mlngCostoAdmVYT + objCursoContr.MontoCtaAdmVYT
    '                mlngMontoCtaExcCapVYT = mlngMontoCtaExcCapVYT + objCursoContr.MontoCtaExcCapVYT

    '                'asignar el alumno directamente desde el objeto curso
    '                mcolAlumnos = objCursoContr.Alumnos(0)   'hay un solo alumno
    '                objCursoContr = Nothing
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function

    Public Function ConsultarListado() As DataTable
        Dim dtAlumnos As New DataTable
        mobjSql = New CSql
        dtAlumnos = mobjSql.s_alumno_curso(mlngCodCurso)
        dtAlumnos.Columns.Add("nombre_completo")
        dtAlumnos.Columns.Add("costo_otic")
        dtAlumnos.Columns.Add("gasto_empresa")
        dtAlumnos.Columns.Add("total")
        If mobjSql.Registros > 0 Then
            Dim dr As DataRow
            Dim dblValHoraSence As Double
            If mcolAlumnos.Count = 0 Then
                ObtenerAlumnos()
            End If
            mlngNumAlumnos = mcolAlumnos.Count
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno(mlngAgno)
            dblValHoraSence = mobjSql.s_val_hora_curso(mlngCodCurso)

            Dim i As Integer
            Dim a As Long
            Dim b As Long
            For i = 0 To (mlngNumAlumnos - 1)
                mcolAlumnos.Item(i + 1).CalcularCostosAl(mlngHoras, dblValHoraSence, _
                              mbolIndAcuComBip, mlngHorasCompl, mlngValorMercado, _
                              mintIndDescPorc, mlngDescuento, mlngNumAlumnos, mintCodEstadoCurso)
                'a = mcolAlumnos.Item(i + 1).CostoOticAlumno
                'b = mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                For Each dr In dtAlumnos.Rows
                    If RutLngAUsr(dr("rut_alumno")) = mcolAlumnos.Item(i + 1).Rut Then
                        dr("nombre_completo") = dr("nombre") & " " & dr("ap_paterno") & " " & dr("ap_materno")
                        dr("costo_otic") = mcolAlumnos.Item(i + 1).CostoOticAlumno
                        dr("gasto_empresa") = mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                        dr("total") = mcolAlumnos.Item(i + 1).CostoOticAlumno + mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                        'dr("viatico") = (CDbl(dr("viatico")) * (mcolAlumnos.Item(i + 1).PorcFranquicia / 100))
                        'dr("traslado") = (CDbl(dr("traslado")) * (mcolAlumnos.Item(i + 1).PorcFranquicia / 100))
                        Exit For
                    End If
                Next
            Next
        End If



        Dim dt As DataTable
        dt = dtAlumnos

        Dim strNombreArchivo As String
        strNombreArchivo = NombreArchivoTmp("csv")
        dt.TableName = "Reporte Cursos"

        ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo


        Return dtAlumnos
    End Function
    Public Function ConsultarListado2() As DataTable
        Dim dtAlumnos As New DataTable
        mobjSql = New CSql
        dtAlumnos = mobjSql.s_alumno_curso(mlngCodCurso)
        dtAlumnos.Columns.Add("nombre_completo")
        dtAlumnos.Columns.Add("costo_otic")
        dtAlumnos.Columns.Add("gasto_empresa")
        dtAlumnos.Columns.Add("total")
        If mobjSql.Registros > 0 Then
            Dim dr As DataRow
            Dim dblValHoraSence As Double
            If mcolAlumnos.Count = 0 Then
                ObtenerAlumnos()
            End If
            mlngNumAlumnos = mcolAlumnos.Count
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno(mlngAgno)
            dblValHoraSence = mobjSql.s_val_hora_curso(mlngCodCurso)

            Dim i As Integer
            Dim a As Long
            Dim b As Long
            For i = 0 To (mlngNumAlumnos - 1)
                mcolAlumnos.Item(i + 1).CalcularCostosAl(mlngHoras, dblValHoraSence, _
                              mbolIndAcuComBip, mlngHorasCompl, mlngValorMercado, _
                              mintIndDescPorc, mlngDescuento, mlngNumAlumnos, mintCodEstadoCurso)
                'a = mcolAlumnos.Item(i + 1).CostoOticAlumno
                'b = mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                For Each dr In dtAlumnos.Rows
                    If RutLngAUsr(dr("rut_alumno")) = mcolAlumnos.Item(i + 1).Rut Then
                        dr("nombre_completo") = dr("nombre") & " " & dr("ap_paterno") & " " & dr("ap_materno")
                        dr("costo_otic") = mcolAlumnos.Item(i + 1).CostoOticAlumno
                        dr("gasto_empresa") = mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                        dr("total") = mcolAlumnos.Item(i + 1).CostoOticAlumno + mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                        dr("viatico") = CDbl(dr("viatico"))
                        dr("traslado") = CDbl(dr("traslado"))
                        Exit For
                    End If
                Next
            Next

        End If
        Return dtAlumnos
    End Function
    Public Function ConsultarListadoParaPDF(ByVal lngCodCurso) As DataTable
        Dim dtAlumnos As New DataTable
        mobjSql = New CSql
        dtAlumnos = mobjSql.s_alumno_curso(lngCodCurso)
        dtAlumnos.Columns.Add("nombre_completo")
        dtAlumnos.Columns.Add("costo_otic")
        dtAlumnos.Columns.Add("gasto_empresa")
        dtAlumnos.Columns.Add("total")
        If mobjSql.Registros > 0 Then
            Dim dr As DataRow
            'Dim lngValHoraSence As Long
            Dim dblValHoraSence As Long

            If mcolAlumnos.Count = 0 Then
                ObtenerAlumnos()
            End If
            mlngNumAlumnos = mcolAlumnos.Count
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno(mlngAgno)
            dblValHoraSence = mobjSql.s_val_hora_curso(lngCodCurso)

            Dim i As Integer
            Dim a As Long
            Dim b As Long
            For i = 0 To (mlngNumAlumnos - 1)
                mcolAlumnos.Item(i + 1).CalcularCostosAl(mlngHoras, dblValHoraSence, _
                              mbolIndAcuComBip, mlngHorasCompl, mlngValorMercado, _
                              mintIndDescPorc, mlngDescuento, mlngNumAlumnos, mintCodEstadoCurso)
                'a = mcolAlumnos.Item(i + 1).CostoOticAlumno
                'b = mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                For Each dr In dtAlumnos.Rows
                    If RutLngAUsr(dr("rut_alumno")) = mcolAlumnos.Item(i + 1).Rut Then
                        dr("nombre_completo") = dr("nombre") & " " & dr("ap_paterno") & " " & dr("ap_materno")
                        dr("costo_otic") = mcolAlumnos.Item(i + 1).CostoOticAlumno
                        dr("gasto_empresa") = mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                        dr("total") = mcolAlumnos.Item(i + 1).CostoOticAlumno + mcolAlumnos.Item(i + 1).GastoEmpresaAlumno
                        Exit For
                    End If
                Next
            Next

        End If
        Return dtAlumnos
    End Function
    'procedimiento para calcular el costo otic, empresa,
    'y totales de viáticos y traslados
    Public Sub CalcularCostos()
        Try
            'Dim lngValHoraSence As Long
            Dim dblValHoraSence As Double
            Dim dblTempCostoOtic As Double, dblTempGastoEmpresa As Double
            Dim dblTempCostoOticVYT As Double, dblTempGastoEmpresaVYT As Double

            'chequear si están cargados los alumnos en el arreglo de objetos
            If mcolAlumnos.Count = 0 Then
                ObtenerAlumnos()
            End If

            'actualizar el valor de viáticos y traslados
            Call CalcTotViaticoTrasl()

            'valor de la hora sence
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno(mlngAgno)
            dblValHoraSence = mobjSql.s_val_hora_curso(mlngCodCurso)
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno2(mlngAgno, mlngCodModalidad, mstrCodSence)
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno2(mlngAgno, mlngCodModalidad, mstrCodSence)
            dblTempCostoOtic = 0
            dblTempGastoEmpresa = 0

            'costos por Viatico y traslado
            dblTempCostoOticVYT = 0
            dblTempGastoEmpresaVYT = 0

            Dim lngNumAlumnos As Integer
            lngNumAlumnos = Me.mcolAlumnos.Count

            'en el cálculo de costos por alumno
            Dim i As Integer
            For i = 0 To (lngNumAlumnos - 1)
                If Not IsDBNull(mcolAlumnos.Item(i + 1)) And Not IsNothing(mcolAlumnos.Item(i + 1)) Then
                    Call mcolAlumnos.Item(i + 1).CalcularCostosAl(mlngHoras, dblValHoraSence, _
                            mbolIndAcuComBip, mlngHorasCompl, mlngValorMercado, _
                            mintIndDescPorc, mlngDescuento, lngNumAlumnos, mintCodEstadoCurso)

                    dblTempCostoOtic = dblTempCostoOtic + mcolAlumnos.Item(i + 1).CostoOticAlumno
                    dblTempGastoEmpresa = dblTempGastoEmpresa + mcolAlumnos.Item(i + 1).GastoEmpresaAlumno

                    dblTempCostoOticVYT = dblTempCostoOticVYT + mcolAlumnos.Item(i + 1).CostoOticAlumnoVYT
                    dblTempGastoEmpresaVYT = dblTempGastoEmpresaVYT + mcolAlumnos.Item(i + 1).GastoEmpresaAlumnoVYT
                End If
            Next


            mlngCostoOtic = Math.Round(dblTempCostoOtic)
            mlngGastoEmpresa = Math.Round(dblTempGastoEmpresa)

            mlngCostoOticVYT = dblTempCostoOticVYT
            mlngGastoEmpresaVYT = dblTempGastoEmpresaVYT
        Catch ex As Exception
            EnviaError("CCursoContratado:CalcularCostos-->" & ex.Message)
        End Try
    End Sub
    Public Sub CalcularCostos2()
        Try
            'Dim lngValHoraSence As Long
            Dim dblValHoraSence As Double
            Dim dblTempCostoOtic As Double, dblTempGastoEmpresa As Double
            Dim dblTempCostoOticVYT As Double, dblTempGastoEmpresaVYT As Double

            'chequear si están cargados los alumnos en el arreglo de objetos
            If mcolAlumnos.Count = 0 Then
                ObtenerAlumnos()
                'Else
                '    mlngNumAlumnos = mcolAlumnos.Count
            End If


            'mlngNumAlumnos = mcolAlumnos.Count


            'actualizar el valor de viáticos y traslados
            Call CalcTotViaticoTrasl()

            'valor de la hora sence
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno(mlngAgno)
            dblValHoraSence = mobjSql.s_val_hora_curso(mlngCodCurso)

            dblTempCostoOtic = 0
            dblTempGastoEmpresa = 0

            'costos por Viatico y traslado
            dblTempCostoOticVYT = 0
            dblTempGastoEmpresaVYT = 0

            Dim lngNumAlumnos As Integer
            lngNumAlumnos = Me.mcolAlumnos.Count

            'en el cálculo de costos por alumno
            Dim i As Integer
            For i = 0 To (lngNumAlumnos - 1)
                If Not IsDBNull(mcolAlumnos.Item(i + 1)) And Not IsNothing(mcolAlumnos.Item(i + 1)) Then
                    Call mcolAlumnos.Item(i + 1).CalcularCostosAl2(mlngHoras, dblValHoraSence, _
                            mbolIndAcuComBip, mlngHorasCompl, mlngValorMercado, _
                            mintIndDescPorc, mlngDescuento, lngNumAlumnos, mintCodEstadoCurso)

                    dblTempCostoOtic = dblTempCostoOtic + mcolAlumnos.Item(i + 1).CostoOticAlumno
                    dblTempGastoEmpresa = dblTempGastoEmpresa + mcolAlumnos.Item(i + 1).GastoEmpresaAlumno

                    dblTempCostoOticVYT = dblTempCostoOticVYT + mcolAlumnos.Item(i + 1).CostoOticAlumnoVYT
                    dblTempGastoEmpresaVYT = dblTempGastoEmpresaVYT + mcolAlumnos.Item(i + 1).GastoEmpresaAlumnoVYT
                End If
            Next


            mlngCostoOtic = Math.Round(dblTempCostoOtic)
            mlngGastoEmpresa = Math.Round(dblTempGastoEmpresa)

            mlngCostoOticVYT = dblTempCostoOticVYT
            mlngGastoEmpresaVYT = dblTempGastoEmpresaVYT
        Catch ex As Exception
            EnviaError("CCursoContratado:CalcularCostos-->" & ex.Message)
        End Try
    End Sub
    'actualizar el número de horas del curso
    Public Sub CalcHorasCurso()
        Try
            If mlngCodCurso > 0 And mlngCodCursoParcial <= 0 Then
                mlngHoras = mobjCurso.DurCursoTeorico + mobjCurso.DurCursoPractico + mobjCurso.DurCurElearning
            ElseIf mlngCodCurso <= 0 Then
                EnviaError("")
            End If
        Catch ex As Exception
            EnviaError("CCursoContratado:CalcHorasCurso-->" & ex.Message)
        End Try
    End Sub
    'Antes tiene que haberse calculado el Costo Otic
    Public Sub CalcCostoAdm()
        Try
            If mlngMontoCtaCap < 0 Then
                'si mlngMontoCtaCap = -1,  se requiere para obtener el cargo en la cuenta de capacitación
                Call ObtenerInfoCuentas()
                Exit Sub
            End If

            Dim lngMontoCalculoAdm As Long
            Dim lngMontoCalculoAdmVYT As Long

            lngMontoCalculoAdm = mlngMontoCtaCap

            lngMontoCalculoAdmVYT = mlngMontoCtaCapVYT

            Dim intAdmNoLineal As Integer
            Dim lngCostoAdm As Double
            Dim lngCostoAdmVYT As Long

            intAdmNoLineal = mobjSql.s_adm_no_lineal(mlngRutCliente)

            If mdblPorcAdm >= 0 And mdblPorcAdm <= 1 Then
                If (100 - intAdmNoLineal * (100 * mdblPorcAdm)) <> 0 Then
                    Dim tmp As Double
                    'si el lngMontoCalculoAdm se desborda en la multiplicación
                    If lngMontoCalculoAdm > 999999999 Then
                        '' ''lngCostoAdm = Math.Round(CDbl(Mult2(lngMontoCalculoAdm, 100)) * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    Else
                        lngCostoAdm = Math.Round(lngMontoCalculoAdm * 100 * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    End If
                Else
                    lngCostoAdm = -1
                End If
                'adm viaticos y traslado
                If (100 - intAdmNoLineal * (100 * mdblPorcAdm)) <> 0 Then
                    ' OLD lngCostoAdmVYT = Round(lngMontoCalculoAdmVYT * 100 * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    'si el lngMontoCalculoAdm se desborda en la multiplicación
                    If lngMontoCalculoAdmVYT > 9999999 Then
                        '' ''lngCostoAdmVYT = Math.Round(CDbl(Mult2(lngMontoCalculoAdmVYT, 100)) * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    Else
                        lngCostoAdmVYT = Math.Round(lngMontoCalculoAdmVYT * 100 * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    End If
                Else
                    lngCostoAdmVYT = -1
                End If


            ElseIf mdblPorcAdm > 1 And mdblPorcAdm <= 100 Then
                If (100 - intAdmNoLineal * mdblPorcAdm) <> 0 Then
                    lngCostoAdm = Math.Round(lngMontoCalculoAdm * mdblPorcAdm / (100 - intAdmNoLineal * mdblPorcAdm))
                Else
                    lngCostoAdm = -1
                End If

                'adm viatico y traslado
                If (100 - intAdmNoLineal * mdblPorcAdm) <> 0 Then
                    lngCostoAdmVYT = Math.Round(lngMontoCalculoAdmVYT * mdblPorcAdm / (100 - intAdmNoLineal * mdblPorcAdm))
                Else
                    lngCostoAdmVYT = -1
                End If
            End If

            mlngCostoAdm = lngCostoAdm

            mlngCostoAdmVYT = lngCostoAdmVYT
        Catch ex As Exception
            EnviaError("CCursoContratado:CalcCostoAdm-->" & ex.Message)
        End Try
    End Sub

    Public Sub GrabarHorario()
        Try
            Dim i, intTamArr As Integer
            'intTamArr = TamanoArreglo1(mdtHorarioCurso)

            mobjSql.d_horario_curso(mlngCodCurso)
            If Not IsDBNull(mdtHorarioCurso) Then
                Dim dr As DataRow
                For Each dr In mdtHorarioCurso.Rows
                    dr("CodCurso") = mlngCodCurso
                    If dr("Dia") > 0 Then
                        Call mobjSql.i_horario_curso(CLng(dr("CodCurso")), _
                                                     CInt(dr("Dia")), _
                                                     CStr(dr("HoraInicio")), _
                                                     CStr(dr("HoraFin")))
                    End If
                Next
            End If
        Catch ex As Exception
            EnviaError("CCursoContratado:GrabarHorario-->" & ex.Message)
        End Try
    End Sub
    'calcular el total de viáticos y traslados
    Private Sub CalcTotViaticoTrasl()
        Try
            Dim i As Integer
            Dim lngAuxViatico, lngAuxTraslado As Long
            lngAuxViatico = 0
            lngAuxTraslado = 0

            Dim lngNumAlumnos As Integer
            lngNumAlumnos = Me.mcolAlumnos.Count
            For i = 0 To (lngNumAlumnos - 1)
                If Not IsDBNull(mcolAlumnos.Item(i + 1)) And Not IsNothing(mcolAlumnos.Item(i + 1)) Then
                    lngAuxViatico = lngAuxViatico + mcolAlumnos.Item(i + 1).Viatico
                    lngAuxTraslado = lngAuxTraslado + mcolAlumnos.Item(i + 1).Traslado
                End If
            Next

            mlngTotalViatico = lngAuxViatico
            mlngTotalTraslado = lngAuxTraslado
        Catch ex As Exception
            EnviaError("CCursoContratado:CalcTotViaticoTrasl-->" & ex.Message)
        End Try
    End Sub
    'Procedimiento para registrar la asistencia de los alumnos. Se asume que
    'la asistencia ya fue asignada en cada objeto de alumno
    Public Function RegistrarAsistenciaAlumnos() As Boolean
        Try
            If mintCodEstadoCurso = 4 Or mintCodEstadoCurso = 11 Then  'si está comunicado, cambiar a "con asistencia"
                mintCodEstadoCurso = 11

                'actualizar los datos del curso y actualizar los porcentajes del alumno
                'Call mobjSql.InicioTransaccion()
                Call GrabarAlumnos()

                Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
                Call mobjSql.i_bitacora(mlngRutUsuario, "Asistencia", _
                           "Ingreso de asistencias. Cliente: " _
                           & RutLngAUsr(mlngRutCliente) & ". " & "", _
                           1, mlngCodCurso)
                Call ActualizarDatos(3)

                'revisar la asistencia de los alumnos, para chequear si es necesario anular el curso
                Dim i As Integer, blnAnular As Boolean
                blnAnular = True
                For i = 0 To (mlngNumAlumnos - 1)
                    'si algún alumno tiene asistencia mínima, no anular
                    If mcolAlumnos(i + 1).PorcAsistencia >= 75 Then blnAnular = False
                Next
               
                If blnAnular Then
                    RegistrarAsistenciaAlumnos = False
                    ' Call mobjSql.RollBackTransaccion()
                    Exit Function
                End If
                'modificar información de platas si es necesario
                Call ObtenerInfoCuentas()
                Call GrabarInfoCuentas2()
                'Call mobjSql.FinTransaccion()
                RegistrarAsistenciaAlumnos = True
            Else
                RegistrarAsistenciaAlumnos = False
            End If

            Exit Function
        Catch ex As Exception
            'Call mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:RegistrarComunicacion-->" & ex.Message)
        End Try
    End Function
    'Procedimiento para registrar la asistencia de los alumnos. Se asume que
    'la asistencia ya fue asignada en cada objeto de alumno
    Public Function RegistrarAsistenciaAlumnos2() As Boolean
        Try
            If mintCodEstadoCurso = 4 Or mintCodEstadoCurso = 11 Then  'si está comunicado, cambiar a "con asistencia"
                mintCodEstadoCurso = 11

                'actualizar los datos del curso y actualizar los porcentajes del alumno
                'Call mobjSql.InicioTransaccion()
                Call GrabarAlumnos()

                Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
                Call mobjSql.i_bitacora(mlngRutUsuario, "Asistencia", _
                           "Ingreso de asistencias. Cliente: " _
                           & RutLngAUsr(mlngRutCliente) & ". " & "", _
                           1, mlngCodCurso)
                Call ActualizarDatos(3)

                'revisar la asistencia de los alumnos, para chequear si es necesario anular el curso
                Dim i As Integer, blnAnular As Boolean
                blnAnular = True
                For i = 0 To (mlngNumAlumnos - 1)
                    'si algún alumno tiene asistencia mínima, no anular
                    If mcolAlumnos(i + 1).PorcAsistencia >= 75 Then blnAnular = False
                Next

                If blnAnular Then
                    RegistrarAsistenciaAlumnos2 = False
                    'Call mobjSql.RollBackTransaccion()
                    Exit Function
                End If
                'modificar información de platas si es necesario
                Call ObtenerInfoCuentas()
                'Call GrabarInfoCuentas2()
                'Call mobjSql.FinTransaccion()
                RegistrarAsistenciaAlumnos2 = True
            Else
                RegistrarAsistenciaAlumnos2 = False
            End If

            Exit Function
        Catch ex As Exception
            'Call mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:RegistrarComunicacion-->" & ex.Message)
        End Try
    End Function
    Public Function ValidarCursoAnulado() As Boolean
        Try
            Dim i, intContador As Integer
            Call ObtenerAlumnos()
            mlngNumAlumnos = Me.mcolAlumnos.Count
            intContador = 0
            For i = 0 To (mlngNumAlumnos - 1)
                If mcolAlumnos(i + 1).PorcAsistencia < 75 Then
                    intContador = intContador + 1
                End If
            Next
            If intContador = mlngNumAlumnos Then
                ValidarCursoAnulado = True
            Else
                ValidarCursoAnulado = False
            End If
        Catch ex As Exception
            EnviaError("CCursoContratado:ValidarCursoAnulado-->" & ex.Message)
        End Try
    End Function
    'Función para chequear si los montos comprometidos en las cuentas
    'coinciden con el Costo Otic del curso
    Public Function ChequearMontoCuentasAsignadas() As Boolean
        Try
            Call ObtenerInfoCuentas()
            Call CalcularCostos()
            'Call CalcCostoOtic

            ChequearMontoCuentasAsignadas = (mlngCostoOtic = mlngMontoCtaCap + mlngMontoCtaExcCap + mlngTotMontoTerc)
        Catch ex As Exception
            EnviaError("CCursoContratado:ChequearMontoCuentasAsignadas-->" & ex.Message)
        End Try
  
    End Function
    'información de cuentas relacionadas a cursos
    Public Sub ObtenerInfoCuentas()
        Try
            Dim suma_terc As Long
            Dim dtMontos As New DataTable
            Dim objCliente As New CCliente
            mobjWeb = New CWeb

            objCliente = New CCliente
            objCliente.Inicializar0(mobjSql, mlngRutUsuario)
            objCliente.Agno = mlngAgno
            If objCliente.Inicializar1(RutLngAUsr(mlngRutCliente)) Then
                mlngSaldoCtaCap = objCliente.ObjCuentaCap.SaldoActual
                mlngSaldoCtaExcCap = objCliente.ObjCuentaExcCap.SaldoActual
                mlngSaldoCtaBecas = objCliente.ObjCuentaBecas.SaldoActual
            End If
            dtMontos = mobjSql.s_montos_cuentas(mlngCodCurso)
            mdtTerceros = mobjSql.s_monto_terceros(mlngCodCurso)
            mdtListaTerceros = mobjSql.s_lista_sol_pago(mlngCodCurso)
            mintAdmNoLineal = mobjSql.s_adm_no_lineal(mlngRutCliente)

            suma_terc = 0

            mlngMontoCtaCap = 0
            mlngMontoCtaExcCap = 0
            'mlngCostoAdm = 0
            mlngMontoTercTran = 0
            mlngMontoCtaBecas = 0
            mlngMontoRep = 0
            mlngMontoExcRep = 0

            '-------viatico y traslado--------
            mlngMontoCtaCapVYT = 0
            mlngMontoCtaExcCapVYT = 0
            '---------------------------------
            'leer los valores cargados en las diferentes cuentas
            Dim dr As DataRow
            If Not dtMontos Is Nothing Then
                For Each dr In dtMontos.Rows
                    Select Case CInt(dr.Item(0))
                        Case 1
                            If CInt(dr.Item(3)) = 5 Then 'Viatico y traslado
                                mlngMontoCtaCapVYT = dr.Item(1)
                            Else
                                mlngMontoCtaCap = dr.Item(1)
                            End If
                        Case 4
                            If CInt(dr.Item(3)) = 5 Then 'Viatico y traslado
                                mlngMontoCtaExcCapVYT = dr.Item(1)
                            Else
                                mlngMontoCtaExcCap = dr.Item(1)
                            End If
                        Case 3
                            If CLng(dr.Item(2)) = mlngRutCliente Then  'adm. del cliente
                                If CInt(dr.Item(3)) = 5 Then 'Viatico y traslado
                                    mlngCostoAdmVYT = dr.Item(1)
                                Else
                                    mlngCostoAdm = dr.Item(1)
                                End If
                            End If
                        Case 2 'Reparto
                            mlngMontoRep = mlngMontoRep + CLng(dr.Item(1))
                            mlngMontoTercTran = mlngMontoTercTran + CLng(dr.Item(1)) 'total terc
                        Case 5 'Exc. Reparto
                            mlngMontoExcRep = mlngMontoExcRep + CLng(dr.Item(1))
                            mlngMontoTercTran = mlngMontoTercTran + CLng(dr.Item(1)) 'total terc
                        Case 6
                            mlngMontoCtaBecas = CLng(dr.Item(1)) '(**|**)
                    End Select
                Next
            End If
            Dim dr2 As DataRow
            If mdtTerceros Is Nothing Then

                mlngTotMontoTerc = 0
            Else
                'If mdtTerceros.Rows.Count > 0 Then

                For Each dr2 In mdtTerceros.Rows
                    suma_terc = suma_terc + dr2.Item(1)
                    Dim objSolicitud As New CSolicitud
                    objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
                    objSolicitud.Inicializar1(mlngCodCurso, dr2.Item(0), mlngRutCliente)
                    mcolSolicitudes.Add(objSolicitud)
                Next
                mlngTotMontoTerc = suma_terc
            End If
            'End If

            'Guardo un indicador para el tipo de accion que se debe hacer
            'en la BD. 1 para insertar nueva, 2 para actualizar
            Dim dt As New DataTable
            dt.Columns.Add("dato")
            Dim dr1 As DataRow
            If mlngMontoCtaCap <> -1 Then
                'marrModifCuentas(0) = 2
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                'marrModifCuentas(0) = 1
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            If mlngMontoCtaExcCap <> -1 Then
                'marrModifCuentas(1) = 2
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                'marrModifCuentas(1) = 1
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If

            'Guardo el tamano inicial del arreglo de montos cargados a terceros
            'marrModifCuentas(2) = mdtTerceros.Rows.Count
            If Not mdtTerceros Is Nothing Then
                dr1 = dt.NewRow
                dr1("dato") = mdtTerceros.Rows.Count
                dt.Rows.Add(dr1)
            Else
                dr1 = dt.NewRow
                dr1("dato") = 0
                dt.Rows.Add(dr1)
            End If



            '--------------Prueba viaticos y traslado -------

            If mlngMontoCtaCapVYT <> -1 Then
                'marrModifCuentas(3) = 2
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                'marrModifCuentas(3) = 1
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            If mlngMontoCtaExcCapVYT <> -1 Then
                'marrModifCuentas(4) = 2
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                'marrModifCuentas(4) = 1
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            If mlngCostoAdmVYT <> -1 Then
                'marrModifCuentas(5) = 2
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                'marrModifCuentas(5) = 1
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            mdtModifCuentas = dt
        Catch ex As Exception
            EnviaError("CCursoContratado:ObtenerInfoCuentas-->" & ex.Message)
        End Try
    End Sub
    'función para grabar la asistencia de alumnos
    Public Sub GrabarAlumnos()

        Try
            Dim i, tamanoAlumno, tam_arrtemp1, tam_arrtemp2 As Integer
            Dim dtTemporal As DataTable
            Dim dig_verif As String
            Dim tipo_pers, strEstadoCurso As String

            tamanoAlumno = mcolAlumnos.Count
            mlngTotalViatico = 0
            mlngTotalTraslado = 0

            'abrir transacción
            mobjSql.InicioTransaccion()

            For i = 0 To (tamanoAlumno - 1)
                If Not IsDBNull(mcolAlumnos.Item(i + 1)) And Not IsNothing(mcolAlumnos.Item(i + 1)) Then
                    dtTemporal = mobjSql.s_persona(RutUsrALng(mcolAlumnos.Item(i + 1).Rut))
                    'tam_arrtemp1 = TamanoArreglo1(dtTemporal)
                    'tam_arrtemp2 = TamanoArreglo2(dtTemporal)

                    If mobjSql.Registros = 0 Then
                        dig_verif = digito_verificador(RutUsrALng(mcolAlumnos.Item(i + 1).Rut))
                        tipo_pers = "N"
                        Call mobjSql.i_Persona(RutUsrALng(mcolAlumnos.Item(i + 1).Rut), dig_verif, tipo_pers)
                    End If

                    dtTemporal = New DataTable
                    dtTemporal = mobjSql.s_pers_nat(RutUsrALng(mcolAlumnos.Item(i + 1).Rut))

                    'tam_arrtemp1 = TamanoArreglo1(dtTemporal)
                    'tam_arrtemp2 = TamanoArreglo2(dtTemporal)

                    If mobjSql.Registros <> 0 Then
                        Call mobjSql.u_pers_nat(RutUsrALng(mcolAlumnos.Item(i + 1).Rut), mcolAlumnos.Item(i + 1).ApPaterno, _
                                                mcolAlumnos.Item(i + 1).ApMaterno, mcolAlumnos.Item(i + 1).Nombres, _
                                                mcolAlumnos.Item(i + 1).FechaNacimiento, mcolAlumnos.Item(i + 1).Sexo, _
                                                mcolAlumnos.Item(i + 1).PorcFranquicia, mcolAlumnos.Item(i + 1).CodigoNivelOcup, _
                                                mcolAlumnos.Item(i + 1).CodigoNivelEduc, mcolAlumnos.Item(i + 1).CodigoRegion, _
                                                mlngRutCliente, mcolAlumnos.Item(i + 1).CodigoComuna, mcolAlumnos.Item(i + 1).CodigoPais, _
                                                       mcolAlumnos.Item(i + 1).Fono, mcolAlumnos.Item(i + 1).Email)
                    Else
                        Call mobjSql.i_PersonaNatural(RutUsrALng(mcolAlumnos.Item(i + 1).Rut), mcolAlumnos.Item(i + 1).ApPaterno, _
                                                      mcolAlumnos.Item(i + 1).ApMaterno, mcolAlumnos.Item(i + 1).Nombres, _
                                                      mcolAlumnos.Item(i + 1).FechaNacimiento, mcolAlumnos.Item(i + 1).Sexo, _
                                                      mcolAlumnos.Item(i + 1).PorcFranquicia, mcolAlumnos.Item(i + 1).CodigoNivelOcup, _
                                                      mcolAlumnos.Item(i + 1).CodigoNivelEduc, mcolAlumnos.Item(i + 1).CodigoRegion, _
                                                      mlngRutCliente, mcolAlumnos.Item(i + 1).CodigoComuna, mcolAlumnos.Item(i + 1).CodigoPais, _
                                                       mcolAlumnos.Item(i + 1).Fono, mcolAlumnos.Item(i + 1).Email)
                    End If

                    dtTemporal = New DataTable
                    dtTemporal = mobjSql.s_partic_curso(mlngCodCurso, RutUsrALng(mcolAlumnos.Item(i + 1).Rut))

                    'tam_arrtemp1 = TamanoArreglo1(dtTemporal)
                    'tam_arrtemp2 = TamanoArreglo2(dtTemporal)

                    If mobjSql.Registros <> 0 Then
                        Call mobjSql.u_participante(mlngCodCurso, RutUsrALng(mcolAlumnos.Item(i + 1).Rut), _
                                                     mcolAlumnos.Item(i + 1).CodigoNivelOcup, mcolAlumnos.Item(i + 1).CodigoRegion, _
                                                     mcolAlumnos.Item(i + 1).PorcFranquicia, mcolAlumnos.Item(i + 1).Viatico, _
                                                     mcolAlumnos.Item(i + 1).Traslado, mcolAlumnos.Item(i + 1).PorcAsistencia, _
                                                      mcolAlumnos.Item(i + 1).Observaciones, mcolAlumnos.Item(i + 1).CodigoNivelEduc, mcolAlumnos.Item(i + 1).CodigoComuna, mcolAlumnos.Item(i + 1).CodigoClasificador)
                    Else
                        Call mobjSql.i_participante(mlngCodCurso, RutUsrALng(mcolAlumnos.Item(i + 1).Rut), _
                                                    mcolAlumnos.Item(i + 1).CodigoNivelOcup, mcolAlumnos.Item(i + 1).CodigoRegion, _
                                                    mcolAlumnos.Item(i + 1).PorcFranquicia, mcolAlumnos.Item(i + 1).Viatico, _
                                                    mcolAlumnos.Item(i + 1).Traslado, mcolAlumnos.Item(i + 1).PorcAsistencia, _
                                                    mcolAlumnos.Item(i + 1).Observaciones, mcolAlumnos.Item(i + 1).CodigoNivelEduc, mcolAlumnos.Item(i + 1).CodigoComuna, mcolAlumnos.Item(i + 1).CodigoClasificador)
                    End If

                    mlngTotalViatico = mlngTotalViatico + mcolAlumnos.Item(i + 1).Viatico
                    mlngTotalTraslado = mlngTotalTraslado + mcolAlumnos.Item(i + 1).Traslado
                End If
            Next

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
                strEstadoCurso = "Con asistencia"
            End If

            Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, _
                                "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                & RutLngAUsr(mlngRutCliente) & ".", _
                                1, mlngCodCurso)
            'commit
            mobjSql.FinTransaccion()
        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:GrabarAlumnos-->" & ex.Message)
        End Try
    End Sub
    ''procedimiento para guardar la información de cuentas de cursos
    'Public Function GrabarInfoCuentas() As Boolean
    '    Try
    '        Dim blnGrabarExitoso, blnBorraTr, blnBorraTr2, blnEsCliente, blnInsTransaccion As Boolean
    '        Dim i, j, tam_arr_terc, tam_arr_modif, tam_arr_mon As Integer
    '        Dim cod_cuenta, tipo_trans, estado_trans As Integer
    '        Dim intContSol As Integer
    '        Dim serial_trans, serial_trans2, lngMaxCorrelativo, lngCorrTemp As Long
    '        Dim lngMontoCtaCap As Long, lngMontoCtaExCap As Long, lngMontoCtaAdm As Long, lngMontoCtaBecas As Long
    '        Dim lngMontoCtaCapVYT As Long, lngMontoCtaExcCapVYT As Long, lngMontoCtaAdmVYT As Long
    '        Dim dtMontos As New DataTable
    '        Dim IntContTemp As Integer
    '        Dim objSolTemp As CSolicitud
    '        Dim dtTemp1 As DataTable
    '        Dim dtTercTemp As DataTable   ' arreglo de solicitudes a terceros antes de grabar

    '        'inicialización de variables
    '        lngMontoCtaCap = 0
    '        lngMontoCtaExCap = 0
    '        lngMontoCtaAdm = 0
    '        lngMontoCtaBecas = 0 '(**|**)

    '        lngMontoCtaCapVYT = 0
    '        lngMontoCtaExcCapVYT = 0
    '        lngMontoCtaAdmVYT = 0

    '        If mdtTerceros Is Nothing Then
    '            tam_arr_terc = 0
    '        Else
    '            tam_arr_terc = mdtTerceros.Rows.Count 'TamanoArreglo2(mdtTerceros)
    '        End If

    '        tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)

    '        intContSol = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
    '        IntContTemp = 0

    '        If Not mdtTerceros Is Nothing Then
    '            If mdtTerceros.Rows.Count > 0 Then
    '                Dim drTerceros As DataRow
    '                For Each drTerceros In mdtTerceros.Rows
    '                    If drTerceros.Item(1) <> 0 Then
    '                        IntContTemp = IntContTemp + 1
    '                    End If
    '                Next
    '            End If
    '        End If

    '        IntContTemp = 0
    '        Dim objCliente As CCliente
    '        Dim objCtaRep As CCuenta, objCtaExcRep As CCuenta

    '        If Not mdtTerceros Is Nothing Then
    '            If mdtTerceros.Rows.Count > 0 Then
    '                Dim drTerceros As DataRow
    '                For Each drTerceros In mdtTerceros.Rows
    '                    If drTerceros.Item(0) > 0 Then
    '                        objCliente = New CCliente
    '                        Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
    '                        blnEsCliente = objCliente.EsCliente(drTerceros.Item(0))
    '                        objCliente = Nothing
    '                        If Not blnEsCliente Then
    '                            GrabarInfoCuentas = False
    '                            Exit Function
    '                        End If
    '                    End If
    '                Next
    '            End If
    '        End If

    '        Dim objDicCtaRepNuevo As Object
    '        Dim objDicCtaRepAntiguo As Object
    '        Dim objDicEstadoTran As Object
    '        Dim objDicCtaExcRepAntiguo As Object
    '        Dim objDicAdmNuevo As Object
    '        Dim objDicAdmAntiguo As Object
    '        Dim objDicCodSol As Object

    '        objDicCtaRepNuevo = CreateObject("Scripting.Dictionary")
    '        objDicCtaRepAntiguo = CreateObject("Scripting.Dictionary")
    '        objDicEstadoTran = CreateObject("Scripting.Dictionary")
    '        objDicCtaExcRepAntiguo = CreateObject("Scripting.Dictionary")
    '        objDicAdmNuevo = CreateObject("Scripting.Dictionary")
    '        objDicAdmAntiguo = CreateObject("Scripting.Dictionary")

    '        Dim dtCuentas As New DataTable
    '        dtCuentas.Columns.Add("rut")
    '        dtCuentas.Columns.Add("CtaRepNuevo")
    '        dtCuentas.Columns.Add("CtaRepAntiguo")
    '        dtCuentas.Columns.Add("EstadoTran")
    '        dtCuentas.Columns.Add("CtaExcRepAntiguo")
    '        dtCuentas.Columns.Add("AdmNuevo")
    '        dtCuentas.Columns.Add("AdmAntiguo")
    '        dtCuentas.Columns.Add("CodSol")
    '        Dim drCuentas As DataRow
    '        drCuentas = dtCuentas.NewRow

    '        If Not mdtTerceros Is Nothing Then
    '            If mdtTerceros.Rows.Count > 0 Then
    '                Dim drTerceros As DataRow
    '                For Each drTerceros In mdtTerceros.Rows
    '                    If drTerceros.Item(0) > 0 Then
    '                        '' ''objDicCtaRepNuevo(CLng(drTerceros.Item(0))) = CLng(drTerceros.Item(1))
    '                        '' ''objDicCtaRepAntiguo(CLng(drTerceros.Item(0))) = 0
    '                        '' ''objDicEstadoTran(CLng(drTerceros.Item(0))) = 3   'estado transaccion: solicitada
    '                        'drCuentas = dtCuentas.NewRow
    '                        drCuentas("rut") = CLng(drTerceros.Item(0))
    '                        drCuentas("CtaRepNuevo") = CLng(drTerceros.Item(1))
    '                        drCuentas("CtaRepAntiguo") = 0
    '                        drCuentas("EstadoTran") = 3
    '                        ' ''drCuentas("CtaExcRepAntiguo") = 0
    '                        ' ''drCuentas("AdmNuevo") = 0
    '                        ' ''drCuentas("AdmAntiguo") = 0
    '                        ' ''drCuentas("CodSol") = 0
    '                        dtCuentas.Rows.Add(drCuentas)
    '                    End If
    '                Next
    '            End If
    '        End If

    '        'genera correlativo del curso, si no tiene ninguno asignado
    '        lngCorrTemp = mlngCorrelativo
    '        If mlngCorrelativo <= 0 Then
    '            If mblnGenerarNuevoCorr Then
    '                lngMaxCorrelativo = mobjSql.s_max_correlativo(mlngAgno)
    '                If lngMaxCorrelativo >= 0 Then
    '                    mlngCorrelativo = lngMaxCorrelativo + 1
    '                Else
    '                    mlngCorrelativo = 1
    '                End If
    '            Else
    '                mlngCorrelativo = mlngCorrElearning
    '            End If
    '        End If

    '        'consulta los montos por (cuenta, rut cliente) asociados al curso en la base de datos
    '        'arrMontos = mobjSql.s_montos_cuentas(mlngCodCurso)
    '        dtMontos = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
    '        If dtMontos Is Nothing Then
    '            tam_arr_mon = 0
    '        Else
    '            tam_arr_mon = dtMontos.Rows.Count 'TamanoArreglo2(dtMontos)
    '        End If


    '        Dim intCodCuenta As Integer, lngRutEmpresaTran As Long
    '        Dim lngMonto As Long, intCodEstadoTran As Integer, intCodTipoTran As Integer
    '        Dim intCodEstadoTranPropias As Integer
    '        Dim intCodEstadoTranVYT As Integer

    '        intCodEstadoTranVYT = 1

    '        If mblnModificarMontoSolicitudes = True Then
    '            intCodEstadoTranPropias = 2
    '        Else
    '            intCodEstadoTranPropias = 1
    '        End If


    '        If Not dtMontos Is Nothing Then
    '            If dtMontos.Rows.Count > 0 Then
    '                Dim drMontos As DataRow
    '                Dim drCuenta As DataRow
    '                For Each drMontos In dtMontos.Rows
    '                    intCodCuenta = CInt(drMontos.Item(2))
    '                    lngRutEmpresaTran = drMontos.Item(1)
    '                    lngMonto = drMontos.Item(4)
    '                    intCodEstadoTran = drMontos.Item(3)
    '                    intCodTipoTran = drMontos.Item(5)

    '                    Select Case intCodCuenta
    '                        Case 1 'cta cap
    '                            If intCodTipoTran = 5 Then 'Viatico y traslado
    '                                lngMontoCtaCapVYT = lngMonto
    '                                intCodEstadoTranVYT = intCodEstadoTran
    '                            Else
    '                                lngMontoCtaCap = lngMonto
    '                                intCodEstadoTranPropias = intCodEstadoTran
    '                            End If

    '                        Case 2 'ctas de rep
    '                            '' ''objDicCtaRepAntiguo(lngRutEmpresaTran) = lngMonto
    '                            '' ''objDicEstadoTran(lngRutEmpresaTran) = intCodEstadoTran

    '                            '' ''If Trim(objDicCtaExcRepAntiguo(lngRutEmpresaTran)) = "" Then
    '                            '' ''    objDicCtaExcRepAntiguo(lngRutEmpresaTran) = 0
    '                            '' ''End If
    '                            '' '' ''drCuenta = dtCuentas.NewRow
    '                            '' '' ''drCuenta("rut") = lngRutEmpresaTran
    '                            '' '' ''drCuenta("CtaRepNuevo") = 0
    '                            drCuenta("CtaRepAntiguo") = lngMonto
    '                            drCuenta("EstadoTran") = intCodEstadoTran
    '                            If Trim(drCuenta("CtaExcRepAntiguo")) = "" Then
    '                                drCuenta("CtaExcRepAntiguo") = 0
    '                            End If
    '                            '' '' ''drCuenta("AdmNuevo") = 0
    '                            '' '' ''drCuenta("AdmAntiguo") = 0
    '                            '' '' ''drCuenta("CodSol") = 0
    '                            '' '' ''dtCuentas.Rows.Add(drCuenta)

    '                        Case 3 'administración
    '                            If lngRutEmpresaTran = mlngRutCliente Then  'cliente dueño del curso
    '                                If intCodTipoTran = 5 Then 'Viatico y traslado
    '                                    lngMontoCtaAdmVYT = lngMonto
    '                                    intCodEstadoTranVYT = intCodEstadoTran
    '                                Else
    '                                    lngMontoCtaAdm = lngMonto  'valor actual de admin
    '                                End If
    '                            Else    'reparto de un tercero
    '                                '' objDicAdmAntiguo(lngRutEmpresaTran) = lngMonto
    '                                '' ''drCuenta = dtCuentas.NewRow
    '                                '' ''drCuenta("rut") = lngRutEmpresaTran
    '                                '' ''drCuenta("CtaRepNuevo") = 0
    '                                '' ''drCuenta("CtaRepAntiguo") = 0
    '                                '' ''drCuenta("EstadoTran") = 0
    '                                '' ''drCuenta("CtaExcRepAntiguo") = 0
    '                                '' ''drCuenta("AdmNuevo") = 0
    '                                drCuenta("AdmAntiguo") = lngMonto
    '                                '' ''drCuenta("CodSol") = 0
    '                                '' ''dtCuentas.Rows.Add(drCuenta)
    '                                ' '' ''objDicAdmAntiguo(lngRutEmpresaTran) = lngMonto
    '                            End If

    '                        Case 4 'exc. cap
    '                            If intCodTipoTran = 5 Then 'Viatico y traslado
    '                                lngMontoCtaExcCapVYT = lngMonto
    '                                intCodEstadoTranVYT = intCodEstadoTran
    '                            Else
    '                                lngMontoCtaExCap = lngMonto
    '                                intCodEstadoTranPropias = intCodEstadoTran
    '                            End If
    '                        Case 5 ' exc. rep

    '                            '' '' ''objDicCtaExcRepAntiguo(lngRutEmpresaTran) = lngMonto
    '                            '' '' ''objDicEstadoTran(lngRutEmpresaTran) = intCodEstadoTran

    '                            '' '' ''If Trim(objDicCtaRepAntiguo(lngRutEmpresaTran)) = "" Then
    '                            '' '' ''    objDicCtaRepAntiguo(lngRutEmpresaTran) = 0
    '                            '' '' ''End If
    '                            ' '' ''drCuenta = dtCuentas.NewRow
    '                            ' '' ''drCuenta("rut") = lngRutEmpresaTran
    '                            ' '' ''drCuenta("CtaRepNuevo") = 0
    '                            ' '' ''drCuenta("CtaRepAntiguo") = 0
    '                            drCuenta("EstadoTran") = intCodEstadoTran
    '                            drCuenta("CtaExcRepAntiguo") = lngMonto
    '                            If Trim(drCuenta("CtaExcRepAntiguo")) = "" Then
    '                                drCuenta("CtaExcRepAntiguo") = 0
    '                            End If
    '                            ' '' ''drCuenta("AdmNuevo") = 0
    '                            ' '' ''drCuenta("AdmAntiguo") = 0
    '                            ' '' ''drCuenta("CodSol") = 0
    '                            ' '' ''dtCuentas.Rows.Add(drCuenta)

    '                        Case 6
    '                            lngMontoCtaBecas = lngMonto
    '                            intCodEstadoTranPropias = intCodEstadoTran
    '                    End Select

    '                Next
    '            End If
    '        End If

    '        'modificación cuenta de capacitación
    '        Call CalcularCostos()
    '        Call CalcCostoAdm()

    '        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 1, intCodEstadoTranPropias, _
    '                2, lngMontoCtaCap, mlngMontoCtaCap, lngMontoCtaAdm, mlngCostoAdm, mblnModificarMontoSolicitudes)
    '        If Not blnInsTransaccion Then
    '            GrabarInfoCuentas = False
    '            'Call mobjSql.RollBackTransaccion()
    '            Exit Function
    '        End If

    '        'excedentes de cap
    '        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 4, intCodEstadoTranPropias, _
    '                2, lngMontoCtaExCap, mlngMontoCtaExcCap, 0, 0, mblnModificarMontoSolicitudes)
    '        If Not blnInsTransaccion Then
    '            GrabarInfoCuentas = False
    '            'Call mobjSql.RollBackTransaccion()
    '            Exit Function
    '        End If

    '        'cuenta beca
    '        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 6, intCodEstadoTranPropias, _
    '                2, lngMontoCtaBecas, mlngMontoCtaBecas, 0, 0, mblnModificarMontoSolicitudes)
    '        If Not blnInsTransaccion Then
    '            GrabarInfoCuentas = False
    '            'Call mobjSql.RollBackTransaccion()
    '            Exit Function
    '        End If

    '        '-----cuanta cap por viaticos y traslado
    '        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 1, intCodEstadoTranVYT, _
    '                5, lngMontoCtaCapVYT, mlngMontoCtaCapVYT, lngMontoCtaAdmVYT, mlngCostoAdmVYT, mblnModificarMontoSolicitudes)
    '        If Not blnInsTransaccion Then
    '            GrabarInfoCuentas = False
    '            'Call mobjSql.RollBackTransaccion()
    '            Exit Function
    '        End If

    '        '-----excedentes de cap por viatios y traslado
    '        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 4, intCodEstadoTranVYT, _
    '                5, lngMontoCtaExcCapVYT, mlngMontoCtaExcCapVYT, 0, 0, mblnModificarMontoSolicitudes)
    '        If Not blnInsTransaccion Then
    '            GrabarInfoCuentas = False
    '            'Call mobjSql.RollBackTransaccion()
    '            Exit Function
    '        End If


    '        'actualizar las transacciones y las solicitudes a terceros
    '        Dim item, lngRutTercero As Long
    '        Dim lngMontoSolicitudAntigua As Long, lngMontoSolicitudNueva As Long
    '        Dim dr As DataRow
    '        '' '' ''For Each item In objDicCtaRepAntiguo.Keys
    '        '' '' ''    lngRutTercero = item
    '        '' '' ''    lngMontoSolicitudAntigua = CLng(objDicCtaRepAntiguo(lngRutTercero)) + CLng(objDicCtaExcRepAntiguo(lngRutTercero))
    '        '' '' ''    lngMontoSolicitudNueva = CLng(objDicCtaRepNuevo(lngRutTercero))

    '        '' '' ''    'si el nuevo monto registrado en la base es diferente a la suma de los solicitados,
    '        '' '' ''    'anular las transacciones e ingresar nuevas
    '        '' '' ''    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
    '        '' '' ''        'cuenta de rep = 2
    '        '' '' ''        If Not mblnModificarMontoSolicitudes Then
    '        '' '' ''            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, objDicEstadoTran(lngRutTercero), _
    '        '' '' ''                    2, objDicCtaRepAntiguo(lngRutTercero), lngMontoSolicitudNueva, _
    '        '' '' ''                    objDicAdmAntiguo(lngRutTercero), 0, mblnModificarMontoSolicitudes)
    '        '' '' ''            'anular cuenta de excedente de rep = 5
    '        '' '' ''            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, objDicEstadoTran(lngRutTercero), _
    '        '' '' ''                    2, objDicCtaExcRepAntiguo(lngRutTercero), 0, _
    '        '' '' ''                    0, 0, mblnModificarMontoSolicitudes)
    '        '' '' ''        Else
    '        '' '' ''            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, objDicEstadoTran(lngRutTercero), _
    '        '' '' ''                    2, objDicCtaRepAntiguo(lngRutTercero), lngMontoSolicitudNueva, _
    '        '' '' ''                    objDicAdmAntiguo(lngRutTercero), 0, mblnModificarMontoSolicitudes)
    '        '' '' ''            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, objDicEstadoTran(lngRutTercero), _
    '        '' '' ''                    2, objDicCtaExcRepAntiguo(lngRutTercero), lngMontoSolicitudNueva, _
    '        '' '' ''                    0, 0, mblnModificarMontoSolicitudes)

    '        '' '' ''        End If
    '        '' '' ''    End If

    '        '' '' ''    'buscar el rut entre las solicitudes existentes
    '        '' '' ''    Dim blnSolicitudEncontrada As Boolean
    '        '' '' ''    blnSolicitudEncontrada = False
    '        '' '' ''    For i = 0 To intContSol - 1
    '        '' '' ''        If mcolSolicitudes(i + 1).RutBenefactorLng = lngRutTercero Then  'se encontró la solicitud
    '        '' '' ''            Call mcolSolicitudes(i + 1).Inicializar1(mlngCodCurso, lngRutTercero, mlngRutCliente)
    '        '' '' ''            If lngMontoSolicitudNueva > 0 Then
    '        '' '' ''                If Not mblnModificarMontoSolicitudes Then
    '        '' '' ''                    mcolSolicitudes(i + 1).MontoCtaReparto = lngMontoSolicitudNueva
    '        '' '' ''                    mcolSolicitudes(i + 1).NroTransCtaRep = 0
    '        '' '' ''                    Call mcolSolicitudes(i + 1).Modificar()
    '        '' '' ''                    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
    '        '' '' ''                        Call mcolSolicitudes(i + 1).CambiarEstPendiente()
    '        '' '' ''                    End If
    '        '' '' ''                End If
    '        '' '' ''            Else
    '        '' '' ''                Call mcolSolicitudes(i + 1).Borrar()
    '        '' '' ''                EliminarSolicitud(i)
    '        '' '' ''                intContSol = intContSol - 1
    '        '' '' ''            End If
    '        '' '' ''            blnSolicitudEncontrada = True
    '        '' '' ''            Exit For
    '        '' '' ''        End If
    '        '' '' ''    Next
    '        '' '' ''    If Not blnSolicitudEncontrada And lngMontoSolicitudNueva > 0 Then  'crear solicitud nueva
    '        '' '' ''        Dim objSolicitud As New CSolicitud
    '        '' '' ''        Call objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
    '        '' '' ''        Call objSolicitud.Inicializar2(mlngRutCliente, lngRutTercero, mlngCodCurso, objDicCtaRepNuevo(lngRutTercero), 0)
    '        '' '' ''        Call objSolicitud.Grabar()
    '        '' '' ''        'mcolSolicitudes(intContSol) = objSolicitud
    '        '' '' ''        'intContSol = intContSol + 1
    '        '' '' ''    End If
    '        '' '' ''Next  'siguiente aporte de tercero


    '        If Not dtCuentas Is Nothing Then
    '            For Each dr In dtCuentas.Rows
    '                lngRutTercero = dr("rut") 'item
    '                lngMontoSolicitudAntigua = CLng(dr("CtaRepAntiguo")) + CLng(dr("CtaExcRepAntiguo"))
    '                lngMontoSolicitudNueva = CLng(dr("CtaRepNuevo"))

    '                'si el nuevo monto registrado en la base es diferente a la suma de los solicitados,
    '                'anular las transacciones e ingresar nuevas
    '                If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
    '                    'cuenta de rep = 2
    '                    If Not mblnModificarMontoSolicitudes Then
    '                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, dr("EstadoTran"), _
    '                                2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
    '                                dr("AdmAntiguo"), 0, mblnModificarMontoSolicitudes)
    '                        'anular cuenta de excedente de rep = 5
    '                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, dr("EstadoTran"), _
    '                                2, dr("CtaExcRepAntiguo"), 0, _
    '                                0, 0, mblnModificarMontoSolicitudes)
    '                    Else
    '                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, dr("EstadoTran"), _
    '                                2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
    '                                dr("DicAdmAntiguo"), 0, mblnModificarMontoSolicitudes)
    '                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, dr("DicEstadoTran"), _
    '                                2, dr("CtaExcRepAntiguo"), lngMontoSolicitudNueva, _
    '                                0, 0, mblnModificarMontoSolicitudes)

    '                    End If
    '                End If

    '                'buscar el rut entre las solicitudes existentes
    '                Dim blnSolicitudEncontrada As Boolean
    '                blnSolicitudEncontrada = False
    '                For i = 0 To intContSol - 1
    '                    If mcolSolicitudes(i + 1).RutBenefactorLng = lngRutTercero Then  'se encontró la solicitud
    '                        Call mcolSolicitudes(i + 1).Inicializar1(mlngCodCurso, lngRutTercero, mlngRutCliente)
    '                        If lngMontoSolicitudNueva > 0 Then
    '                            If Not mblnModificarMontoSolicitudes Then
    '                                mcolSolicitudes(i + 1).MontoCtaReparto = lngMontoSolicitudNueva
    '                                mcolSolicitudes(i + 1).NroTransCtaRep = 0
    '                                Call mcolSolicitudes(i + 1).Modificar()
    '                                If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
    '                                    Call mcolSolicitudes(i + 1).CambiarEstPendiente()
    '                                End If
    '                            End If
    '                        Else
    '                            Call mcolSolicitudes(i + 1).Borrar()
    '                            EliminarSolicitud(i + 1)
    '                            intContSol = intContSol - 1
    '                        End If
    '                        blnSolicitudEncontrada = True
    '                        Exit For
    '                    End If
    '                Next
    '                If Not blnSolicitudEncontrada And lngMontoSolicitudNueva > 0 Then  'crear solicitud nueva
    '                    Dim objSolicitud As New CSolicitud
    '                    Call objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
    '                    Call objSolicitud.Inicializar2(mlngRutCliente, lngRutTercero, mlngCodCurso, dr("CtaRepNuevo"), 0)
    '                    Call objSolicitud.Grabar()
    '                    'mcolSolicitudes(intContSol) = objSolicitud
    '                    'intContSol = intContSol + 1
    '                End If
    '            Next
    '        End If
    '        dtCuentas.Rows.Add(drCuentas)
    '        blnGrabarExitoso = True

    '        Dim tam_arr_aux As Integer

    '        If mdtTerceros Is Nothing Then
    '            mdtTerceros = New DataTable
    '            mdtTerceros.Columns.Add("rut_benefactor")
    '            mdtTerceros.Columns.Add("monto")
    '            mdtTerceros.Columns.Add("cod_estado_solicitud")
    '            mdtTerceros.Columns.Add("monto_adm")
    '            mdtTerceros.Columns.Add("monto2")
    '            mdtTerceros.Columns.Add("cta")
    '            mdtTerceros.Columns.Add("cod_curso")
    '            Dim drTerceros As DataRow
    '            drTerceros = mdtTerceros.NewRow
    '            drTerceros("rut_benefactor") = -1
    '            drTerceros("monto") = -1
    '            drTerceros("cod_estado_solicitud") = -1
    '            drTerceros("monto_adm") = -1
    '            drTerceros("monto2") = -1
    '            drTerceros("cta") = -1
    '            drTerceros("cod_curso") = -1
    '            mdtTerceros.Rows.Add(drTerceros)
    '        Else
    '            If mdtTerceros.Rows.Count = 0 Then
    '                Dim drTerceros As DataRow
    '                drTerceros = mdtTerceros.NewRow
    '                drTerceros("rut_benefactor") = -1
    '                drTerceros("monto") = -1
    '                drTerceros("cod_estado_solicitud") = 0
    '                drTerceros("monto_adm") = -1
    '                drTerceros("monto2") = -1
    '                drTerceros("cta") = 0
    '                drTerceros("cod_curso") = 0
    '                mdtTerceros.Rows.Add(drTerceros)
    '            End If
    '        End If
    '        If tam_arr_terc = 1 And mdtTerceros.Rows(0)(0) <= 0 Then
    '            tam_arr_aux = 0
    '        Else
    '            tam_arr_aux = tam_arr_terc
    '        End If

    '        Dim blnSolPendientes As Boolean
    '        blnSolPendientes = False
    '        If mcolSolicitudes.Count > 0 Then
    '            For i = 0 To mcolSolicitudes.Count ' TamanoArreglo1(mcolSolicitudes) - 1
    '                'Si hay pendientes
    '                If mcolSolicitudes(i + 1).CodEstadoSolicitud = 1 Then
    '                    blnSolPendientes = True
    '                    Exit For
    '                End If
    '            Next
    '        End If

    '        If Not mintCodEstadoCurso > 0 Then
    '            If mdtModifCuentas.Rows(2).Item(0) = tam_arr_aux And Not blnSolPendientes Then
    '                Call CambiarEstIngresado("")
    '            ElseIf (mdtModifCuentas.Rows(2).Item(0) < tam_arr_aux) Or blnSolPendientes Then
    '                Call CambiarEstPagoPorAut("")
    '            End If
    '        Else
    '            blnGrabarExitoso = False
    '        End If

    '        'grabar el nuevo costo_otic, costo_adm, gasto_empresa
    '        ActualizarDatos(0)

    '        'cerrar transacción y conexion
    '        'mobjSql.FinTransaccion()

    '        'mlngCorrelativo = lngCorrTemp
    '        GrabarInfoCuentas = blnGrabarExitoso
    '    Catch ex As Exception
    '        'mobjSql.RollBackTransaccion()
    '        EnviaError("CCursoContratado:GrabarHorario-->" & ex.Message)
    '    End Try

    'End Function
    'procedimiento para guardar la información de cuentas de cursos
    Public Function GrabarInfoCuentas() As Boolean
        Try
            Dim blnGrabarExitoso, blnBorraTr, blnBorraTr2, blnEsCliente, blnInsTransaccion As Boolean
            Dim i, j, tam_arr_terc, tam_arr_modif, tam_arr_mon As Integer
            Dim cod_cuenta, tipo_trans, estado_trans As Integer
            Dim intContSol As Integer
            Dim serial_trans, serial_trans2, lngMaxCorrelativo, lngCorrTemp As Long
            Dim lngMontoCtaCap As Long, lngMontoCtaExCap As Long, lngMontoCtaAdm As Long, lngMontoCtaBecas As Long
            Dim lngMontoCtaCapVYT As Long, lngMontoCtaExcCapVYT As Long, lngMontoCtaAdmVYT As Long
            Dim dtMontos As New DataTable
            Dim IntContTemp As Integer
            Dim objSolTemp As CSolicitud
            Dim dtTemp1 As DataTable
            Dim dtTercTemp As DataTable   ' arreglo de solicitudes a terceros antes de grabar

            'inicialización de variables
            lngMontoCtaCap = 0
            lngMontoCtaExCap = 0
            lngMontoCtaAdm = 0
            lngMontoCtaBecas = 0 '(**|**)

            lngMontoCtaCapVYT = 0
            lngMontoCtaExcCapVYT = 0
            lngMontoCtaAdmVYT = 0

            If mdtTerceros Is Nothing Then
                tam_arr_terc = 0
            Else
                tam_arr_terc = mdtTerceros.Rows.Count 'TamanoArreglo2(mdtTerceros)
            End If

            tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)

            intContSol = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
            IntContTemp = 0

            If Not mdtTerceros Is Nothing Then
                If mdtTerceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In mdtTerceros.Rows
                        If drTerceros.Item(1) <> 0 Then
                            IntContTemp = IntContTemp + 1
                        End If
                    Next
                End If
            End If

            IntContTemp = 0
            Dim objCliente As CCliente
            Dim objCtaRep As CCuenta, objCtaExcRep As CCuenta

            If Not mdtTerceros Is Nothing Then
                If mdtTerceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In mdtTerceros.Rows
                        If drTerceros.Item(0) > 0 Then
                            objCliente = New CCliente
                            Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                            blnEsCliente = objCliente.EsCliente(drTerceros.Item(0))
                            objCliente = Nothing
                            If Not blnEsCliente Then
                                GrabarInfoCuentas = False
                                Exit Function
                            End If
                        End If
                    Next
                End If
            End If

            Dim objDicCtaRepNuevo As Object
            Dim objDicCtaRepAntiguo As Object
            Dim objDicEstadoTran As Object
            Dim objDicCtaExcRepAntiguo As Object
            Dim objDicAdmNuevo As Object
            Dim objDicAdmAntiguo As Object
            Dim objDicCodSol As Object

            'objDicCtaRepNuevo = CreateObject("Scripting.Dictionary")
            'objDicCtaRepAntiguo = CreateObject("Scripting.Dictionary")
            'objDicEstadoTran = CreateObject("Scripting.Dictionary")
            'objDicCtaExcRepAntiguo = CreateObject("Scripting.Dictionary")
            'objDicAdmNuevo = CreateObject("Scripting.Dictionary")
            'objDicAdmAntiguo = CreateObject("Scripting.Dictionary")

            Dim dtCuentas As New DataTable
            dtCuentas.Columns.Add("rut")
            dtCuentas.Columns.Add("CtaRepNuevo")
            dtCuentas.Columns.Add("CtaRepAntiguo")
            dtCuentas.Columns.Add("EstadoTran")
            dtCuentas.Columns.Add("CtaExcRepAntiguo")
            dtCuentas.Columns.Add("AdmNuevo")
            dtCuentas.Columns.Add("AdmAntiguo")
            dtCuentas.Columns.Add("CodSol")
            Dim drCuentas As DataRow

            If Not mdtTerceros Is Nothing Then
                If mdtTerceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In mdtTerceros.Rows
                        If drTerceros.Item(0) > 0 Then
                            'objDicCtaRepNuevo(CLng(dr.Item(0))) = CLng(dr.Item(1))
                            'objDicCtaRepAntiguo(CLng(dr.Item(0))) = 0
                            'objDicEstadoTran(CLng(dr.Item(0))) = 3   'estado transaccion: solicitada
                            drCuentas = dtCuentas.NewRow
                            drCuentas("rut") = CLng(drTerceros.Item(0))
                            drCuentas("CtaRepNuevo") = CLng(drTerceros.Item(1))
                            drCuentas("CtaRepAntiguo") = 0
                            drCuentas("EstadoTran") = 3
                            drCuentas("CtaExcRepAntiguo") = 0
                            drCuentas("AdmNuevo") = 0
                            drCuentas("AdmAntiguo") = 0
                            drCuentas("CodSol") = 0
                            dtCuentas.Rows.Add(drCuentas)
                        End If
                    Next
                End If
            End If

            'genera correlativo del curso, si no tiene ninguno asignado
            lngCorrTemp = mlngCorrelativo
            If mlngCorrelativo <= 0 Then
                If mblnGenerarNuevoCorr Then
                    lngMaxCorrelativo = mobjSql.s_max_correlativo(mlngAgno)
                    If lngMaxCorrelativo >= 0 Then
                        mlngCorrelativo = lngMaxCorrelativo + 1
                    Else
                        mlngCorrelativo = 1
                    End If
                Else
                    mlngCorrelativo = mlngCorrElearning
                End If
            End If

            'consulta los montos por (cuenta, rut cliente) asociados al curso en la base de datos
            'arrMontos = mobjSql.s_montos_cuentas(mlngCodCurso)
            dtMontos = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If dtMontos Is Nothing Then
                tam_arr_mon = 0
            Else
                tam_arr_mon = dtMontos.Rows.Count 'TamanoArreglo2(dtMontos)
            End If


            Dim intCodCuenta As Integer, lngRutEmpresaTran As Long
            Dim lngMonto As Long, intCodEstadoTran As Integer, intCodTipoTran As Integer
            Dim intCodEstadoTranPropias As Integer
            Dim intCodEstadoTranVYT As Integer

            intCodEstadoTranVYT = 1

            If mblnModificarMontoSolicitudes = True Then
                intCodEstadoTranPropias = 2
            Else
                intCodEstadoTranPropias = 1
            End If


            If Not dtMontos Is Nothing Then
                If dtMontos.Rows.Count > 0 Then
                    Dim drMontos As DataRow
                    Dim drCuenta As DataRow
                    For Each drMontos In dtMontos.Rows
                        intCodCuenta = CInt(drMontos.Item(2))
                        lngRutEmpresaTran = drMontos.Item(1)
                        lngMonto = drMontos.Item(4)
                        intCodEstadoTran = drMontos.Item(3)
                        intCodTipoTran = drMontos.Item(5)

                        Select Case intCodCuenta
                            Case 1 'cta cap
                                If intCodTipoTran = 5 Then 'Viatico y traslado
                                    lngMontoCtaCapVYT = lngMonto
                                    intCodEstadoTranVYT = intCodEstadoTran
                                Else
                                    lngMontoCtaCap = lngMonto
                                    intCodEstadoTranPropias = intCodEstadoTran
                                End If

                            Case 2 'ctas de rep

                                Dim dr1 As DataRow
                                For Each dr1 In dtCuentas.Rows
                                    If dr1("rut") = lngRutEmpresaTran Then
                                        'dr1("rut") = lngRutEmpresaTran
                                        'dr1("CtaRepNuevo") = 0
                                        dr1("CtaRepAntiguo") = lngMonto
                                        dr1("EstadoTran") = intCodEstadoTran
                                        ''If Trim(drCuenta("CtaExcRepAntiguo")) = "" Then
                                        ''    dr1("CtaExcRepAntiguo") = 0
                                        ''End If
                                        'dr1("AdmNuevo") = 0
                                        'dr1("AdmAntiguo") = 0
                                        'dr1("CodSol") = 0
                                    End If
                                Next

                            Case 3 'administración
                                If lngRutEmpresaTran = mlngRutCliente Then  'cliente dueño del curso
                                    If intCodTipoTran = 5 Then 'Viatico y traslado
                                        lngMontoCtaAdmVYT = lngMonto
                                        intCodEstadoTranVYT = intCodEstadoTran
                                    Else
                                        lngMontoCtaAdm = lngMonto  'valor actual de admin
                                    End If
                                Else    'reparto de un tercero
                                    Dim dr2 As DataRow
                                    For Each dr2 In dtCuentas.Rows
                                        If dr2("rut") = lngRutEmpresaTran Then
                                            dr2("AdmAntiguo") = lngMonto
                                        End If
                                    Next
                                    'drCuenta = dtCuentas.NewRow
                                    'drCuenta("rut") = lngRutEmpresaTran
                                    'drCuenta("CtaRepNuevo") = 0
                                    'drCuenta("CtaRepAntiguo") = 0
                                    'drCuenta("EstadoTran") = 0
                                    'drCuenta("CtaExcRepAntiguo") = 0
                                    'drCuenta("AdmNuevo") = 0

                                    'drCuenta("CodSol") = 0
                                    'dtCuentas.Rows.Add(drCuenta)
                                    'objDicAdmAntiguo(lngRutEmpresaTran) = lngMonto
                                End If

                            Case 4 'exc. cap
                                If intCodTipoTran = 5 Then 'Viatico y traslado
                                    lngMontoCtaExcCapVYT = lngMonto
                                    intCodEstadoTranVYT = intCodEstadoTran
                                Else
                                    lngMontoCtaExCap = lngMonto
                                    intCodEstadoTranPropias = intCodEstadoTran
                                End If
                            Case 5 ' exc. rep
                                Dim dr3 As DataRow
                                For Each dr3 In dtCuentas.Rows
                                    If dr3("rut") = lngRutEmpresaTran Then
                                        dr3("EstadoTran") = intCodEstadoTran
                                        dr3("CtaExcRepAntiguo") = lngMonto
                                        ''If Trim(drCuenta("CtaRepAntiguo")) = "" Then
                                        ''    dr3("CtaRepAntiguo") = 0
                                        ''End If
                                    End If
                                Next
                                'drCuenta = dtCuentas.NewRow
                                'drCuenta("rut") = lngRutEmpresaTran
                                'drCuenta("CtaRepNuevo") = 0
                                'drCuenta("CtaRepAntiguo") = 0

                                'drCuenta("AdmNuevo") = 0
                                'drCuenta("AdmAntiguo") = 0
                                'drCuenta("CodSol") = 0
                                'dtCuentas.Rows.Add(drCuenta)

                            Case 6
                                lngMontoCtaBecas = lngMonto
                                intCodEstadoTranPropias = intCodEstadoTran
                        End Select

                    Next
                End If
            End If

            'modificación cuenta de capacitación
            Call CalcularCostos()
            Call CalcCostoAdm()

            mobjSql.InicioTransaccion()

            blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 1, intCodEstadoTranPropias, _
                    2, lngMontoCtaCap, mlngMontoCtaCap, lngMontoCtaAdm, mlngCostoAdm, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If

            'excedentes de cap
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 4, intCodEstadoTranPropias, _
                    2, lngMontoCtaExCap, mlngMontoCtaExcCap, 0, 0, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If

            'cuenta beca
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 6, intCodEstadoTranPropias, _
                    2, lngMontoCtaBecas, mlngMontoCtaBecas, 0, 0, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If

            '-----cuanta cap por viaticos y traslado
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 1, intCodEstadoTranVYT, _
                                5, lngMontoCtaCapVYT, mlngMontoCtaCapVYT, lngMontoCtaAdmVYT, mlngCostoAdmVYT, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If

            '-----excedentes de cap por viatios y traslado
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 4, intCodEstadoTranVYT, _
                    5, lngMontoCtaExcCapVYT, mlngMontoCtaExcCapVYT, 0, 0, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If
            mobjSql.FinTransaccion()

            'actualizar las transacciones y las solicitudes a terceros
            Dim item, lngRutTercero As Long
            Dim lngMontoSolicitudAntigua As Long, lngMontoSolicitudNueva As Long
            Dim dr As DataRow
            If dtCuentas.Rows.Count > 0 Then
                For Each dr In dtCuentas.Rows
                    mobjSql.InicioTransaccion()
                    lngRutTercero = dr("rut") 'item
                    lngMontoSolicitudAntigua = CLng(dr("CtaRepAntiguo")) + CLng(dr("CtaExcRepAntiguo"))
                    lngMontoSolicitudNueva = CLng(dr("CtaRepNuevo"))

                    'si el nuevo monto registrado en la base es diferente a la suma de los solicitados,
                    'anular las transacciones e ingresar nuevas
                    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
                        'cuenta de rep = 2
                        If Not mblnModificarMontoSolicitudes Then
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, dr("EstadoTran"), _
                                    2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
                                    dr("AdmAntiguo"), 0, mblnModificarMontoSolicitudes)
                            'anular cuenta de excedente de rep = 5
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, dr("EstadoTran"), _
                                    2, dr("CtaExcRepAntiguo"), 0, _
                                    0, 0, mblnModificarMontoSolicitudes)
                        Else
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, dr("EstadoTran"), _
                                    2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
                                    dr("DicAdmAntiguo"), 0, mblnModificarMontoSolicitudes)
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, dr("DicEstadoTran"), _
                                    2, dr("CtaExcRepAntiguo"), lngMontoSolicitudNueva, _
                                    0, 0, mblnModificarMontoSolicitudes)

                        End If
                    End If
                    mobjSql.FinTransaccion()

                    'buscar el rut entre las solicitudes existentes
                    Dim blnSolicitudEncontrada As Boolean
                    blnSolicitudEncontrada = False
                    For i = 0 To intContSol - 1
                        If mcolSolicitudes(i + 1).RutBenefactorLng = lngRutTercero Then  'se encontró la solicitud
                            Call mcolSolicitudes(i + 1).Inicializar1(mlngCodCurso, lngRutTercero, mlngRutCliente)
                            If lngMontoSolicitudNueva > 0 Then
                                If Not mblnModificarMontoSolicitudes Then
                                    mcolSolicitudes(i + 1).MontoCtaReparto = lngMontoSolicitudNueva
                                    mcolSolicitudes(i + 1).NroTransCtaRep = 0
                                    Call mcolSolicitudes(i + 1).Modificar()
                                    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
                                        Call mcolSolicitudes(i + 1).CambiarEstPendiente()
                                    End If
                                End If
                            Else
                                Call mcolSolicitudes(i + 1).Borrar()
                                EliminarSolicitud(i + 1)
                                intContSol = intContSol - 1
                            End If
                            blnSolicitudEncontrada = True
                            Exit For
                        End If
                    Next
                    If Not blnSolicitudEncontrada And lngMontoSolicitudNueva > 0 Then  'crear solicitud nueva
                        Dim objSolicitud As New CSolicitud
                        Call objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
                        Call objSolicitud.Inicializar2(mlngRutCliente, lngRutTercero, mlngCodCurso, dr("CtaRepNuevo"), 0)
                        Call objSolicitud.Grabar()
                        'mcolSolicitudes(intContSol) = objSolicitud
                        'intContSol = intContSol + 1
                    End If
                Next
            End If

            blnGrabarExitoso = True

            Dim tam_arr_aux As Integer

            If mdtTerceros Is Nothing Then
                mdtTerceros = New DataTable
                mdtTerceros.Columns.Add("rut_benefactor")
                mdtTerceros.Columns.Add("monto")
                mdtTerceros.Columns.Add("cod_estado_solicitud")
                mdtTerceros.Columns.Add("monto_adm")
                mdtTerceros.Columns.Add("monto2")
                mdtTerceros.Columns.Add("cta")
                mdtTerceros.Columns.Add("cod_curso")
                Dim drTerceros As DataRow
                drTerceros = mdtTerceros.NewRow
                drTerceros("rut_benefactor") = -1
                drTerceros("monto") = -1
                drTerceros("cod_estado_solicitud") = -1
                drTerceros("monto_adm") = -1
                drTerceros("monto2") = -1
                drTerceros("cta") = -1
                drTerceros("cod_curso") = -1
                mdtTerceros.Rows.Add(drTerceros)
            Else
                If mdtTerceros.Rows.Count = 0 Then
                    Dim drTerceros As DataRow
                    drTerceros = mdtTerceros.NewRow
                    drTerceros("rut_benefactor") = -1
                    drTerceros("monto") = -1
                    drTerceros("cod_estado_solicitud") = 0
                    drTerceros("monto_adm") = -1
                    drTerceros("monto2") = -1
                    drTerceros("cta") = 0
                    drTerceros("cod_curso") = 0
                    mdtTerceros.Rows.Add(drTerceros)
                End If
            End If
            If tam_arr_terc = 1 And mdtTerceros.Rows(0)(0) <= 0 Then
                tam_arr_aux = 0
            Else
                tam_arr_aux = tam_arr_terc
            End If

            Dim blnSolPendientes As Boolean
            blnSolPendientes = False
            If mcolSolicitudes.Count > 0 Then
                For i = 0 To mcolSolicitudes.Count - 1 ' TamanoArreglo1(mcolSolicitudes) - 1
                    'Si hay pendientes
                    If mcolSolicitudes(i + 1).CodEstadoSolicitud = 1 Then
                        blnSolPendientes = True
                        Exit For
                    End If
                Next
            End If

            If Not mintCodEstadoCurso > 0 Then
                If mdtModifCuentas.Rows(2).Item(0) = tam_arr_aux And Not blnSolPendientes Then
                    Call CambiarEstIngresado("")
                ElseIf (mdtModifCuentas.Rows(2).Item(0) < tam_arr_aux) Or blnSolPendientes Then
                    Call CambiarEstPagoPorAut("")
                End If
            Else
                blnGrabarExitoso = False
            End If

            'grabar el nuevo costo_otic, costo_adm, gasto_empresa
            ActualizarDatos(0)

            'cerrar transacción y conexion
            'mobjSql.FinTransaccion()

            'mlngCorrelativo = lngCorrTemp
            GrabarInfoCuentas = blnGrabarExitoso
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:GrabarHorario-->" & ex.Message)
        End Try

    End Function
    'modificado exclusivamente para las cuentas de cursos de la carga de asistencia
    Public Function GrabarInfoCuentas2() As Boolean
        Try
            Dim blnGrabarExitoso, blnBorraTr, blnBorraTr2, blnEsCliente, blnInsTransaccion As Boolean
            Dim i, j, tam_arr_terc, tam_arr_modif, tam_arr_mon As Integer
            Dim cod_cuenta, tipo_trans, estado_trans As Integer
            Dim intContSol As Integer
            Dim serial_trans, serial_trans2, lngMaxCorrelativo, lngCorrTemp As Long
            Dim lngMontoCtaCap As Long, lngMontoCtaExCap As Long, lngMontoCtaAdm As Long, lngMontoCtaBecas As Long
            Dim lngMontoCtaCapVYT As Long, lngMontoCtaExcCapVYT As Long, lngMontoCtaAdmVYT As Long
            Dim dtMontos As New DataTable
            Dim IntContTemp As Integer
            Dim objSolTemp As CSolicitud
            Dim dtTemp1 As DataTable
            Dim dtTercTemp As DataTable   ' arreglo de solicitudes a terceros antes de grabar

            'inicialización de variables
            lngMontoCtaCap = 0
            lngMontoCtaExCap = 0
            lngMontoCtaAdm = 0
            lngMontoCtaBecas = 0 '(**|**)

            lngMontoCtaCapVYT = 0
            lngMontoCtaExcCapVYT = 0
            lngMontoCtaAdmVYT = 0

            If mdtTerceros Is Nothing Then
                tam_arr_terc = 0
            Else
                tam_arr_terc = mdtTerceros.Rows.Count 'TamanoArreglo2(mdtTerceros)
            End If

            tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)

            intContSol = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
            IntContTemp = 0

            If Not mdtTerceros Is Nothing Then
                If mdtTerceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In mdtTerceros.Rows
                        If drTerceros.Item(1) <> 0 Then
                            IntContTemp = IntContTemp + 1
                        End If
                    Next
                End If
            End If

            IntContTemp = 0
            Dim objCliente As CCliente
            Dim objCtaRep As CCuenta, objCtaExcRep As CCuenta

            If Not mdtTerceros Is Nothing Then
                If mdtTerceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In mdtTerceros.Rows
                        If drTerceros.Item(0) > 0 Then
                            objCliente = New CCliente
                            Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                            blnEsCliente = objCliente.EsCliente(drTerceros.Item(0))
                            objCliente = Nothing
                            If Not blnEsCliente Then
                                GrabarInfoCuentas2 = False
                                Exit Function
                            End If
                        End If
                    Next
                End If
            End If

            Dim objDicCtaRepNuevo As Object
            Dim objDicCtaRepAntiguo As Object
            Dim objDicEstadoTran As Object
            Dim objDicCtaExcRepAntiguo As Object
            Dim objDicAdmNuevo As Object
            Dim objDicAdmAntiguo As Object
            Dim objDicCodSol As Object

            'objDicCtaRepNuevo = CreateObject("Scripting.Dictionary")
            'objDicCtaRepAntiguo = CreateObject("Scripting.Dictionary")
            'objDicEstadoTran = CreateObject("Scripting.Dictionary")
            'objDicCtaExcRepAntiguo = CreateObject("Scripting.Dictionary")
            'objDicAdmNuevo = CreateObject("Scripting.Dictionary")
            'objDicAdmAntiguo = CreateObject("Scripting.Dictionary")

            Dim dtCuentas As New DataTable
            dtCuentas.Columns.Add("rut")
            dtCuentas.Columns.Add("CtaRepNuevo")
            dtCuentas.Columns.Add("CtaRepAntiguo")
            dtCuentas.Columns.Add("EstadoTran")
            dtCuentas.Columns.Add("CtaExcRepAntiguo")
            dtCuentas.Columns.Add("AdmNuevo")
            dtCuentas.Columns.Add("AdmAntiguo")
            dtCuentas.Columns.Add("CodSol")
            Dim drCuentas As DataRow

            If Not mdtTerceros Is Nothing Then
                If mdtTerceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In mdtTerceros.Rows
                        If drTerceros.Item(0) > 0 Then
                            'objDicCtaRepNuevo(CLng(dr.Item(0))) = CLng(dr.Item(1))
                            'objDicCtaRepAntiguo(CLng(dr.Item(0))) = 0
                            'objDicEstadoTran(CLng(dr.Item(0))) = 3   'estado transaccion: solicitada
                            drCuentas = dtCuentas.NewRow
                            drCuentas("rut") = CLng(drTerceros.Item(0))
                            drCuentas("CtaRepNuevo") = CLng(drTerceros.Item(1))
                            drCuentas("CtaRepAntiguo") = 0
                            drCuentas("EstadoTran") = 3
                            drCuentas("CtaExcRepAntiguo") = 0
                            drCuentas("AdmNuevo") = 0
                            drCuentas("AdmAntiguo") = 0
                            drCuentas("CodSol") = 0
                            dtCuentas.Rows.Add(drCuentas)
                        End If
                    Next
                End If
            End If

            'genera correlativo del curso, si no tiene ninguno asignado
            lngCorrTemp = mlngCorrelativo
            If mlngCorrelativo <= 0 Then
                If mblnGenerarNuevoCorr Then
                    lngMaxCorrelativo = mobjSql.s_max_correlativo(mlngAgno)
                    If lngMaxCorrelativo >= 0 Then
                        mlngCorrelativo = lngMaxCorrelativo + 1
                    Else
                        mlngCorrelativo = 1
                    End If
                Else
                    mlngCorrelativo = mlngCorrElearning
                End If
            End If

            'consulta los montos por (cuenta, rut cliente) asociados al curso en la base de datos
            'arrMontos = mobjSql.s_montos_cuentas(mlngCodCurso)
            dtMontos = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If dtMontos Is Nothing Then
                tam_arr_mon = 0
            Else
                tam_arr_mon = dtMontos.Rows.Count 'TamanoArreglo2(dtMontos)
            End If

            Dim intCodCuenta As Integer, lngRutEmpresaTran As Long
            Dim lngMonto As Long, intCodEstadoTran As Integer, intCodTipoTran As Integer
            Dim intCodEstadoTranPropias As Integer
            Dim intCodEstadoTranVYT As Integer

            intCodEstadoTranVYT = 1

            If mblnModificarMontoSolicitudes = True Then
                intCodEstadoTranPropias = 2
            Else
                intCodEstadoTranPropias = 1
            End If


            Dim contadorCuenta As Integer = 0
            If Not dtMontos Is Nothing Then
                If dtMontos.Rows.Count > 0 Then
                    Dim drMontos As DataRow
                    Dim drCuenta As DataRow
                    For Each drMontos In dtMontos.Rows
                        intCodCuenta = CInt(drMontos.Item(2))
                        lngRutEmpresaTran = drMontos.Item(1)
                        lngMonto = drMontos.Item(4)
                        intCodEstadoTran = drMontos.Item(3)
                        intCodTipoTran = drMontos.Item(5)

                        Select Case intCodCuenta
                            Case 1 'cta cap
                                If intCodTipoTran = 5 Then 'Viatico y traslado
                                    lngMontoCtaCapVYT = lngMonto
                                    intCodEstadoTranVYT = intCodEstadoTran
                                Else
                                    lngMontoCtaCap = lngMonto
                                    intCodEstadoTranPropias = intCodEstadoTran
                                End If
                                contadorCuenta = contadorCuenta + 1
                            Case 2 'ctas de rep

                                Dim dr1 As DataRow
                                For Each dr1 In dtCuentas.Rows
                                    If dr1("rut") = lngRutEmpresaTran Then
                                        'dr1("rut") = lngRutEmpresaTran
                                        'dr1("CtaRepNuevo") = 0
                                        dr1("CtaRepAntiguo") = lngMonto
                                        dr1("EstadoTran") = intCodEstadoTran
                                        ''If Trim(drCuenta("CtaExcRepAntiguo")) = "" Then
                                        ''    dr1("CtaExcRepAntiguo") = 0
                                        ''End If
                                        'dr1("AdmNuevo") = 0
                                        'dr1("AdmAntiguo") = 0
                                        'dr1("CodSol") = 0
                                    End If
                                Next
                                'drCuenta = dtCuentas.NewRow
                                'drCuenta("rut") = lngRutEmpresaTran
                                'drCuenta("CtaRepNuevo") = 0
                                'drCuenta("CtaRepAntiguo") = lngMonto
                                'drCuenta("EstadoTran") = intCodEstadoTran
                                ''If Trim(drCuenta("CtaExcRepAntiguo")) = "" Then
                                'drCuenta("CtaExcRepAntiguo") = 0
                                ''End If
                                'drCuenta("AdmNuevo") = 0
                                'drCuenta("AdmAntiguo") = 0
                                'drCuenta("CodSol") = 0
                                'dtCuentas.Rows.Add(drCuenta)

                            Case 3 'administración
                                If lngRutEmpresaTran = mlngRutCliente Then  'cliente dueño del curso
                                    If intCodTipoTran = 5 Then 'Viatico y traslado
                                        lngMontoCtaAdmVYT = lngMonto
                                        intCodEstadoTranVYT = intCodEstadoTran
                                    Else
                                        lngMontoCtaAdm = lngMonto  'valor actual de admin
                                    End If
                                Else    'reparto de un tercero
                                    Dim dr2 As DataRow
                                    For Each dr2 In dtCuentas.Rows
                                        If dr2("rut") = lngRutEmpresaTran Then
                                            dr2("AdmAntiguo") = lngMonto
                                        End If
                                    Next
                                    'drCuenta = dtCuentas.NewRow
                                    'drCuenta("rut") = lngRutEmpresaTran
                                    'drCuenta("CtaRepNuevo") = 0
                                    'drCuenta("CtaRepAntiguo") = 0
                                    'drCuenta("EstadoTran") = 0
                                    'drCuenta("CtaExcRepAntiguo") = 0
                                    'drCuenta("AdmNuevo") = 0
                                    'drCuenta("AdmAntiguo") = lngMonto
                                    'drCuenta("CodSol") = 0
                                    'dtCuentas.Rows.Add(drCuenta)
                                    ''objDicAdmAntiguo(lngRutEmpresaTran) = lngMonto
                                End If

                            Case 4 'exc. cap
                                If intCodTipoTran = 5 Then 'Viatico y traslado
                                    lngMontoCtaExcCapVYT = lngMonto
                                    intCodEstadoTranVYT = intCodEstadoTran
                                Else
                                    lngMontoCtaExCap = lngMonto
                                    intCodEstadoTranPropias = intCodEstadoTran
                                End If

                                contadorCuenta = contadorCuenta + 1
                            Case 5 ' exc. rep
                                Dim dr3 As DataRow
                                For Each dr3 In dtCuentas.Rows
                                    If dr3("rut") = lngRutEmpresaTran Then
                                        dr3("EstadoTran") = intCodEstadoTran
                                        dr3("CtaExcRepAntiguo") = lngMonto
                                        ''If Trim(drCuenta("CtaRepAntiguo")) = "" Then
                                        ''    dr3("CtaRepAntiguo") = 0
                                        ''End If
                                    End If
                                Next
                                'drCuenta = dtCuentas.NewRow
                                'drCuenta("rut") = lngRutEmpresaTran
                                'drCuenta("CtaRepNuevo") = 0
                                'drCuenta("CtaRepAntiguo") = 0
                                'drCuenta("EstadoTran") = intCodEstadoTran
                                'drCuenta("CtaExcRepAntiguo") = lngMonto
                                'drCuenta("AdmNuevo") = 0
                                'drCuenta("AdmAntiguo") = 0
                                'drCuenta("CodSol") = 0
                                'dtCuentas.Rows.Add(drCuenta)


                            Case 6
                                lngMontoCtaBecas = lngMonto
                                intCodEstadoTranPropias = intCodEstadoTran
                        End Select

                    Next
                End If
            End If



            'modificación cuenta de capacitación
            Call CalcularCostos2()
            'Call CalcCostoAdm()

            Dim CostoOticAntiguo As Long = lngMontoCtaCap + lngMontoCtaExCap


            If CostoOticAntiguo <> mlngCostoOtic Then
                If contadorCuenta = 1 Then
                    If lngMontoCtaCap > 0 Then
                        If mlngCostoOtic <> lngMontoCtaCap Then
                            Me.mlngMontoCtaCap = mlngCostoOtic
                        End If
                    End If
                    If lngMontoCtaExCap > 0 Then
                        If mlngCostoOtic <> lngMontoCtaExCap Then
                            Me.mlngMontoCtaExcCap = mlngCostoOtic
                        End If
                    End If
                ElseIf contadorCuenta = 2 Then
                    If mlngCostoOtic > lngMontoCtaExCap Then
                        mlngMontoCtaCap = mlngCostoOtic - lngMontoCtaExCap
                        mlngMontoCtaExcCap = lngMontoCtaExCap
                    ElseIf mlngCostoOtic <= lngMontoCtaExCap Then
                        mlngMontoCtaExcCap = mlngCostoOtic
                        mlngMontoCtaCap = 0
                    End If
                End If
            End If

            Call CalcCostoAdm()

            mobjSql.InicioTransaccion()
            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(mlngRutCliente, 1, intCodEstadoTranPropias, _
                    2, lngMontoCtaCap, mlngMontoCtaCap, lngMontoCtaAdm, mlngCostoAdm, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas2 = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If

            'excedentes de cap
            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(mlngRutCliente, 4, intCodEstadoTranPropias, _
                    2, lngMontoCtaExCap, mlngMontoCtaExcCap, 0, 0, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas2 = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If

            'cuenta beca
            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(mlngRutCliente, 6, intCodEstadoTranPropias, _
                    2, lngMontoCtaBecas, mlngMontoCtaBecas, 0, 0, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas2 = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If

            '-----cuanta cap por viaticos y traslado

            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(mlngRutCliente, 1, intCodEstadoTranVYT, _
                                5, lngMontoCtaCapVYT, mlngMontoCtaCapVYT, lngMontoCtaAdmVYT, mlngCostoAdmVYT, mblnModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas2 = False
                Call mobjSql.RollBackTransaccion()
                Exit Function
            End If


            '*************************************************************************************
            '*************************************************************************************
            '*************************************************************************************
            '*************************************************************************************
            '*************************************************************************************




            '-----excedentes de cap por viatios y traslado

            ''blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 4, intCodEstadoTranVYT, _
            ''                     5, lngMontoCtaExcCapVYT, mlngMontoCtaExcCapVYT, 0, 0, mblnModificarMontoSolicitudes)
            ''If Not blnInsTransaccion Then
            ''    GrabarInfoCuentas2 = False
            ''    Call mobjSql.RollBackTransaccion()
            ''    Exit Function
            ''End If


            mobjSql.FinTransaccion()
            '*************************************************************************************
            '*************************************************************************************
            '*************************************************************************************
            '*************************************************************************************
            '*************************************************************************************

            'actualizar las transacciones y las solicitudes a terceros
            Dim item, lngRutTercero As Long
            Dim lngMontoSolicitudAntigua As Long, lngMontoSolicitudNueva As Long
            Dim dr As DataRow
            If Not dtCuentas Is Nothing Then
                For Each dr In dtCuentas.Rows
                    mobjSql.InicioTransaccion()
                    lngRutTercero = dr("rut") 'item
                    lngMontoSolicitudAntigua = CLng(dr("CtaRepAntiguo")) + CLng(dr("CtaExcRepAntiguo"))
                    lngMontoSolicitudNueva = CLng(dr("CtaRepNuevo"))

                    'si el nuevo monto registrado en la base es diferente a la suma de los solicitados,
                    'anular las transacciones e ingresar nuevas
                    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
                        'cuenta de rep = 2
                        If Not mblnModificarMontoSolicitudes Then
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(lngRutTercero, 2, dr("EstadoTran"), _
                                    2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
                                    dr("AdmAntiguo"), 0, mblnModificarMontoSolicitudes)
                            'anular cuenta de excedente de rep = 5
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(lngRutTercero, 5, dr("EstadoTran"), _
                                    2, dr("CtaExcRepAntiguo"), 0, _
                                    0, 0, mblnModificarMontoSolicitudes)
                        Else
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(lngRutTercero, 2, dr("EstadoTran"), _
                                    2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
                                    dr("DicAdmAntiguo"), 0, mblnModificarMontoSolicitudes)
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario2(lngRutTercero, 5, dr("DicEstadoTran"), _
                                    2, dr("CtaExcRepAntiguo"), lngMontoSolicitudNueva, _
                                    0, 0, mblnModificarMontoSolicitudes)

                        End If
                    End If
                    mobjSql.FinTransaccion()

                    'buscar el rut entre las solicitudes existentes
                    Dim blnSolicitudEncontrada As Boolean
                    blnSolicitudEncontrada = False
                    For i = 0 To intContSol - 1
                        If mcolSolicitudes(i + 1).RutBenefactorLng = lngRutTercero Then  'se encontró la solicitud
                            Call mcolSolicitudes(i + 1).Inicializar1(mlngCodCurso, lngRutTercero, mlngRutCliente)
                            If lngMontoSolicitudNueva > 0 Then
                                If Not mblnModificarMontoSolicitudes Then
                                    mcolSolicitudes(i + 1).MontoCtaReparto = lngMontoSolicitudNueva
                                    mcolSolicitudes(i + 1).NroTransCtaRep = 0
                                    Call mcolSolicitudes(i + 1).Modificar()
                                    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
                                        Call mcolSolicitudes(i + 1).CambiarEstPendiente()
                                    End If
                                End If
                            Else
                                Call mcolSolicitudes(i + 1).Borrar()
                                EliminarSolicitud(i + 1)
                                intContSol = intContSol - 1
                            End If
                            blnSolicitudEncontrada = True
                            Exit For
                        End If
                    Next
                    If Not blnSolicitudEncontrada And lngMontoSolicitudNueva > 0 Then  'crear solicitud nueva
                        Dim objSolicitud As New CSolicitud
                        Call objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
                        Call objSolicitud.Inicializar2(mlngRutCliente, lngRutTercero, mlngCodCurso, dr("CtaRepNuevo"), 0)
                        Call objSolicitud.Grabar()
                        'mcolSolicitudes(intContSol) = objSolicitud
                        'intContSol = intContSol + 1
                    End If
                Next
            End If

            blnGrabarExitoso = True

            Dim tam_arr_aux As Integer

            If mdtTerceros Is Nothing Then
                mdtTerceros = New DataTable
                mdtTerceros.Columns.Add("rut_benefactor")
                mdtTerceros.Columns.Add("monto")
                mdtTerceros.Columns.Add("cod_estado_solicitud")
                mdtTerceros.Columns.Add("monto_adm")
                mdtTerceros.Columns.Add("monto2")
                mdtTerceros.Columns.Add("cta")
                mdtTerceros.Columns.Add("cod_curso")
                Dim drTerceros As DataRow
                drTerceros = mdtTerceros.NewRow
                drTerceros("rut_benefactor") = -1
                drTerceros("monto") = -1
                drTerceros("cod_estado_solicitud") = -1
                drTerceros("monto_adm") = -1
                drTerceros("monto2") = -1
                drTerceros("cta") = -1
                drTerceros("cod_curso") = -1
                mdtTerceros.Rows.Add(drTerceros)
            Else
                If mdtTerceros.Rows.Count = 0 Then
                    Dim drTerceros As DataRow
                    drTerceros = mdtTerceros.NewRow
                    drTerceros("rut_benefactor") = -1
                    drTerceros("monto") = -1
                    drTerceros("cod_estado_solicitud") = 0
                    drTerceros("monto_adm") = -1
                    drTerceros("monto2") = -1
                    drTerceros("cta") = 0
                    drTerceros("cod_curso") = 0
                    mdtTerceros.Rows.Add(drTerceros)
                End If
            End If
            If tam_arr_terc = 1 And mdtTerceros.Rows(0)(0) <= 0 Then
                tam_arr_aux = 0
            Else
                tam_arr_aux = tam_arr_terc
            End If

            Dim blnSolPendientes As Boolean
            blnSolPendientes = False
            If mcolSolicitudes.Count > 0 Then
                For i = 0 To mcolSolicitudes.Count - 1 ' TamanoArreglo1(mcolSolicitudes) - 1
                    'Si hay pendientes
                    If mcolSolicitudes(i + 1).CodEstadoSolicitud = 1 Then
                        blnSolPendientes = True
                        Exit For
                    End If
                Next
            End If

            If Not mintCodEstadoCurso > 0 Then
                If mdtModifCuentas.Rows(2).Item(0) = tam_arr_aux And Not blnSolPendientes Then
                    Call CambiarEstIngresado("")
                ElseIf (mdtModifCuentas.Rows(2).Item(0) < tam_arr_aux) Or blnSolPendientes Then
                    Call CambiarEstPagoPorAut("")
                End If
            Else
                blnGrabarExitoso = False
            End If

            'grabar el nuevo costo_otic, costo_adm, gasto_empresa
            ActualizarDatos2(0)

            'cerrar transacción y conexion
            'mobjSql.FinTransaccion()

            'mlngCorrelativo = lngCorrTemp
            GrabarInfoCuentas2 = blnGrabarExitoso
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:GrabarHorario-->" & ex.Message)
        End Try

    End Function
    ' ''modificado exclusivamente para las cuentas de cursos de la carga de asistencia
    ''Public Function GrabarInfoCuentas2() As Boolean
    ''    Try
    ''        Dim blnGrabarExitoso, blnBorraTr, blnBorraTr2, blnEsCliente, blnInsTransaccion As Boolean
    ''        Dim i, j, tam_arr_terc, tam_arr_modif, tam_arr_mon As Integer
    ''        Dim cod_cuenta, tipo_trans, estado_trans As Integer
    ''        Dim intContSol As Integer
    ''        Dim serial_trans, serial_trans2, lngMaxCorrelativo, lngCorrTemp As Long
    ''        Dim lngMontoCtaCap As Long, lngMontoCtaExCap As Long, lngMontoCtaAdm As Long, lngMontoCtaBecas As Long
    ''        Dim lngMontoCtaCapVYT As Long, lngMontoCtaExcCapVYT As Long, lngMontoCtaAdmVYT As Long
    ''        Dim dtMontos As New DataTable
    ''        Dim IntContTemp As Integer
    ''        Dim objSolTemp As CSolicitud
    ''        Dim dtTemp1 As DataTable
    ''        Dim dtTercTemp As DataTable   ' arreglo de solicitudes a terceros antes de grabar

    ''        'inicialización de variables
    ''        lngMontoCtaCap = 0
    ''        lngMontoCtaExCap = 0
    ''        lngMontoCtaAdm = 0
    ''        lngMontoCtaBecas = 0 '(**|**)

    ''        lngMontoCtaCapVYT = 0
    ''        lngMontoCtaExcCapVYT = 0
    ''        lngMontoCtaAdmVYT = 0

    ''        If mdtTerceros Is Nothing Then
    ''            tam_arr_terc = 0
    ''        Else
    ''            tam_arr_terc = mdtTerceros.Rows.Count 'TamanoArreglo2(mdtTerceros)
    ''        End If

    ''        tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)

    ''        intContSol = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
    ''        IntContTemp = 0

    ''        If Not mdtTerceros Is Nothing Then
    ''            If mdtTerceros.Rows.Count > 0 Then
    ''                Dim drTerceros As DataRow
    ''                For Each drTerceros In mdtTerceros.Rows
    ''                    If drTerceros.Item(1) <> 0 Then
    ''                        IntContTemp = IntContTemp + 1
    ''                    End If
    ''                Next
    ''            End If
    ''        End If

    ''        IntContTemp = 0
    ''        Dim objCliente As CCliente
    ''        Dim objCtaRep As CCuenta, objCtaExcRep As CCuenta

    ''        If Not mdtTerceros Is Nothing Then
    ''            If mdtTerceros.Rows.Count > 0 Then
    ''                Dim drTerceros As DataRow
    ''                For Each drTerceros In mdtTerceros.Rows
    ''                    If drTerceros.Item(0) > 0 Then
    ''                        objCliente = New CCliente
    ''                        Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
    ''                        blnEsCliente = objCliente.EsCliente(drTerceros.Item(0))
    ''                        objCliente = Nothing
    ''                        If Not blnEsCliente Then
    ''                            GrabarInfoCuentas2 = False
    ''                            Exit Function
    ''                        End If
    ''                    End If
    ''                Next
    ''            End If
    ''        End If

    ''        Dim objDicCtaRepNuevo As Object
    ''        Dim objDicCtaRepAntiguo As Object
    ''        Dim objDicEstadoTran As Object
    ''        Dim objDicCtaExcRepAntiguo As Object
    ''        Dim objDicAdmNuevo As Object
    ''        Dim objDicAdmAntiguo As Object
    ''        Dim objDicCodSol As Object

    ''        objDicCtaRepNuevo = CreateObject("Scripting.Dictionary")
    ''        objDicCtaRepAntiguo = CreateObject("Scripting.Dictionary")
    ''        objDicEstadoTran = CreateObject("Scripting.Dictionary")
    ''        objDicCtaExcRepAntiguo = CreateObject("Scripting.Dictionary")
    ''        objDicAdmNuevo = CreateObject("Scripting.Dictionary")
    ''        objDicAdmAntiguo = CreateObject("Scripting.Dictionary")

    ''        Dim dtCuentas As New DataTable
    ''        dtCuentas.Columns.Add("rut")
    ''        dtCuentas.Columns.Add("CtaRepNuevo")
    ''        dtCuentas.Columns.Add("CtaRepAntiguo")
    ''        dtCuentas.Columns.Add("EstadoTran")
    ''        dtCuentas.Columns.Add("CtaExcRepAntiguo")
    ''        dtCuentas.Columns.Add("AdmNuevo")
    ''        dtCuentas.Columns.Add("AdmAntiguo")
    ''        dtCuentas.Columns.Add("CodSol")
    ''        Dim drCuentas As DataRow

    ''        If Not mdtTerceros Is Nothing Then
    ''            If mdtTerceros.Rows.Count > 0 Then
    ''                Dim drTerceros As DataRow
    ''                For Each drTerceros In mdtTerceros.Rows
    ''                    If drTerceros.Item(0) > 0 Then
    ''                        'objDicCtaRepNuevo(CLng(dr.Item(0))) = CLng(dr.Item(1))
    ''                        'objDicCtaRepAntiguo(CLng(dr.Item(0))) = 0
    ''                        'objDicEstadoTran(CLng(dr.Item(0))) = 3   'estado transaccion: solicitada
    ''                        drCuentas = dtCuentas.NewRow
    ''                        drCuentas("rut") = CLng(drTerceros.Item(0))
    ''                        drCuentas("CtaRepNuevo") = CLng(drTerceros.Item(1))
    ''                        drCuentas("CtaRepAntiguo") = 0
    ''                        drCuentas("EstadoTran") = 3
    ''                        drCuentas("CtaExcRepAntiguo") = 0
    ''                        drCuentas("AdmNuevo") = 0
    ''                        drCuentas("AdmAntiguo") = 0
    ''                        drCuentas("CodSol") = 0
    ''                        dtCuentas.Rows.Add(drCuentas)
    ''                    End If
    ''                Next
    ''            End If
    ''        End If

    ''        'genera correlativo del curso, si no tiene ninguno asignado
    ''        lngCorrTemp = mlngCorrelativo
    ''        If mlngCorrelativo <= 0 Then
    ''            If mblnGenerarNuevoCorr Then
    ''                lngMaxCorrelativo = mobjSql.s_max_correlativo(mlngAgno)
    ''                If lngMaxCorrelativo >= 0 Then
    ''                    mlngCorrelativo = lngMaxCorrelativo + 1
    ''                Else
    ''                    mlngCorrelativo = 1
    ''                End If
    ''            Else
    ''                mlngCorrelativo = mlngCorrElearning
    ''            End If
    ''        End If

    ''        'consulta los montos por (cuenta, rut cliente) asociados al curso en la base de datos
    ''        'arrMontos = mobjSql.s_montos_cuentas(mlngCodCurso)
    ''        dtMontos = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
    ''        If dtMontos Is Nothing Then
    ''            tam_arr_mon = 0
    ''        Else
    ''            tam_arr_mon = dtMontos.Rows.Count 'TamanoArreglo2(dtMontos)
    ''        End If

    ''        Dim intCodCuenta As Integer, lngRutEmpresaTran As Long
    ''        Dim lngMonto As Long, intCodEstadoTran As Integer, intCodTipoTran As Integer
    ''        Dim intCodEstadoTranPropias As Integer
    ''        Dim intCodEstadoTranVYT As Integer

    ''        intCodEstadoTranVYT = 1

    ''        If mblnModificarMontoSolicitudes = True Then
    ''            intCodEstadoTranPropias = 2
    ''        Else
    ''            intCodEstadoTranPropias = 1
    ''        End If


    ''        Dim contadorCuenta As Integer = 0
    ''        If Not dtMontos Is Nothing Then
    ''            If dtMontos.Rows.Count > 0 Then
    ''                Dim drMontos As DataRow
    ''                Dim drCuenta As DataRow
    ''                For Each drMontos In dtMontos.Rows
    ''                    intCodCuenta = CInt(drMontos.Item(2))
    ''                    lngRutEmpresaTran = drMontos.Item(1)
    ''                    lngMonto = drMontos.Item(4)
    ''                    intCodEstadoTran = drMontos.Item(3)
    ''                    intCodTipoTran = drMontos.Item(5)


    ''                    Select Case intCodCuenta
    ''                        Case 1 'cta cap
    ''                            If intCodTipoTran = 5 Then 'Viatico y traslado
    ''                                lngMontoCtaCapVYT = lngMonto
    ''                                intCodEstadoTranVYT = intCodEstadoTran
    ''                            Else
    ''                                lngMontoCtaCap = lngMonto
    ''                                intCodEstadoTranPropias = intCodEstadoTran
    ''                            End If
    ''                            contadorCuenta = contadorCuenta + 1
    ''                        Case 2 'ctas de rep

    ''                            drCuenta = dtCuentas.NewRow
    ''                            drCuenta("rut") = lngRutEmpresaTran
    ''                            drCuenta("CtaRepNuevo") = 0
    ''                            drCuenta("CtaRepAntiguo") = lngMonto
    ''                            drCuenta("EstadoTran") = intCodEstadoTran
    ''                            'If Trim(drCuenta("CtaExcRepAntiguo")) = "" Then
    ''                            drCuenta("CtaExcRepAntiguo") = 0
    ''                            'End If
    ''                            drCuenta("AdmNuevo") = 0
    ''                            drCuenta("AdmAntiguo") = 0
    ''                            drCuenta("CodSol") = 0
    ''                            dtCuentas.Rows.Add(drCuenta)

    ''                        Case 3 'administración
    ''                            If lngRutEmpresaTran = mlngRutCliente Then  'cliente dueño del curso
    ''                                If intCodTipoTran = 5 Then 'Viatico y traslado
    ''                                    lngMontoCtaAdmVYT = lngMonto
    ''                                    intCodEstadoTranVYT = intCodEstadoTran
    ''                                Else
    ''                                    lngMontoCtaAdm = lngMonto  'valor actual de admin
    ''                                End If
    ''                            Else    'reparto de un tercero
    ''                                drCuenta = dtCuentas.NewRow
    ''                                drCuenta("rut") = lngRutEmpresaTran
    ''                                drCuenta("CtaRepNuevo") = 0
    ''                                drCuenta("CtaRepAntiguo") = 0
    ''                                drCuenta("EstadoTran") = 0
    ''                                drCuenta("CtaExcRepAntiguo") = 0
    ''                                drCuenta("AdmNuevo") = 0
    ''                                drCuenta("AdmAntiguo") = lngMonto
    ''                                drCuenta("CodSol") = 0
    ''                                dtCuentas.Rows.Add(drCuenta)
    ''                                'objDicAdmAntiguo(lngRutEmpresaTran) = lngMonto
    ''                            End If

    ''                        Case 4 'exc. cap
    ''                            If intCodTipoTran = 5 Then 'Viatico y traslado
    ''                                lngMontoCtaExcCapVYT = lngMonto
    ''                                intCodEstadoTranVYT = intCodEstadoTran
    ''                            Else
    ''                                lngMontoCtaExCap = lngMonto
    ''                                intCodEstadoTranPropias = intCodEstadoTran
    ''                            End If

    ''                            contadorCuenta = contadorCuenta + 1
    ''                        Case 5 ' exc. rep
    ''                            drCuenta = dtCuentas.NewRow
    ''                            drCuenta("rut") = lngRutEmpresaTran
    ''                            drCuenta("CtaRepNuevo") = 0
    ''                            drCuenta("CtaRepAntiguo") = 0
    ''                            drCuenta("EstadoTran") = intCodEstadoTran
    ''                            drCuenta("CtaExcRepAntiguo") = lngMonto
    ''                            drCuenta("AdmNuevo") = 0
    ''                            drCuenta("AdmAntiguo") = 0
    ''                            drCuenta("CodSol") = 0
    ''                            dtCuentas.Rows.Add(drCuenta)


    ''                        Case 6
    ''                            lngMontoCtaBecas = lngMonto
    ''                            intCodEstadoTranPropias = intCodEstadoTran
    ''                    End Select

    ''                Next
    ''            End If
    ''        End If



    ''        'modificación cuenta de capacitación
    ''        Call CalcularCostos2()


    ''        Dim CostoOticAntiguo As Long = lngMontoCtaCap + lngMontoCtaExCap


    ''        If CostoOticAntiguo <> mlngCostoOtic Then
    ''            If contadorCuenta = 1 Then
    ''                If lngMontoCtaCap > 0 Then
    ''                    If mlngCostoOtic <> lngMontoCtaCap Then
    ''                        Me.mlngMontoCtaCap = mlngCostoOtic
    ''                    End If
    ''                End If
    ''                If lngMontoCtaExCap > 0 Then
    ''                    If mlngCostoOtic <> lngMontoCtaExCap Then
    ''                        Me.mlngMontoCtaExcCap = mlngCostoOtic
    ''                    End If
    ''                End If
    ''            ElseIf contadorCuenta = 2 Then
    ''                If mlngCostoOtic > lngMontoCtaExCap Then
    ''                    mlngMontoCtaCap = mlngCostoOtic - lngMontoCtaExCap
    ''                    mlngMontoCtaExcCap = lngMontoCtaExCap
    ''                ElseIf mlngCostoOtic <= lngMontoCtaExCap Then
    ''                    mlngMontoCtaExcCap = mlngCostoOtic
    ''                    mlngMontoCtaCap = 0
    ''                End If
    ''            End If
    ''        End If

    ''        Call CalcCostoAdm()


    ''        blnInsTransaccion = ModificarTransaccionSiEsNecesario2(mlngRutCliente, 1, intCodEstadoTranPropias, _
    ''                                        2, lngMontoCtaCap, mlngMontoCtaCap, lngMontoCtaAdm, mlngCostoAdm, mblnModificarMontoSolicitudes)
    ''        If Not blnInsTransaccion Then
    ''            GrabarInfoCuentas2 = False
    ''            Exit Function
    ''        End If



    ''        'excedentes de cap

    ''        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 4, intCodEstadoTranPropias, _
    ''                            2, lngMontoCtaExCap, mlngMontoCtaExcCap, 0, 0, mblnModificarMontoSolicitudes)
    ''        If Not blnInsTransaccion Then
    ''            GrabarInfoCuentas2 = False
    ''            'Call mobjSql.RollBackTransaccion()
    ''            Exit Function
    ''        End If


    ''        'cuenta beca
    ''        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 6, intCodEstadoTranPropias, _
    ''                2, lngMontoCtaBecas, mlngMontoCtaBecas, 0, 0, mblnModificarMontoSolicitudes)
    ''        If Not blnInsTransaccion Then
    ''            GrabarInfoCuentas2 = False
    ''            'Call mobjSql.RollBackTransaccion()
    ''            Exit Function
    ''        End If

    ''        '-----cuanta cap por viaticos y traslado

    ''        blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 1, intCodEstadoTranVYT, _
    ''                            5, lngMontoCtaCapVYT, mlngCostoOticVYT, lngMontoCtaAdmVYT, mlngCostoAdmVYT, mblnModificarMontoSolicitudes)
    ''        If Not blnInsTransaccion Then
    ''            GrabarInfoCuentas2 = False
    ''            'Call mobjSql.RollBackTransaccion()
    ''            Exit Function
    ''        End If


    ''        '*************************************************************************************
    ''        '*************************************************************************************
    ''        '*************************************************************************************
    ''        '*************************************************************************************
    ''        '*************************************************************************************

    ''        'LOS VYT YA NO SE PUEDEN PAGAR CON EXCEDENTES, POR LO TANTO, ESTO YA NO VA


    ''        '-----excedentes de cap por viatios y traslado

    ''        'blnInsTransaccion = ModificarTransaccionSiEsNecesario(mlngRutCliente, 4, intCodEstadoTranVYT, _
    ''        '                    5, lngMontoCtaExcCapVYT, mlngCostoOticVYT, 0, 0, mblnModificarMontoSolicitudes)
    ''        'If Not blnInsTransaccion Then
    ''        '    GrabarInfoCuentas2 = False
    ''        '    'Call mobjSql.RollBackTransaccion()
    ''        '    Exit Function
    ''        'End If

    ''        '*************************************************************************************
    ''        '*************************************************************************************
    ''        '*************************************************************************************
    ''        '*************************************************************************************
    ''        '*************************************************************************************








    ''        'actualizar las transacciones y las solicitudes a terceros
    ''        Dim item, lngRutTercero As Long
    ''        Dim lngMontoSolicitudAntigua As Long, lngMontoSolicitudNueva As Long
    ''        Dim dr As DataRow
    ''        If Not dtCuentas Is Nothing Then
    ''            For Each dr In dtCuentas.Rows
    ''                lngRutTercero = dr("rut") 'item
    ''                lngMontoSolicitudAntigua = CLng(dr("CtaRepAntiguo")) + CLng(dr("CtaExcRepAntiguo"))
    ''                lngMontoSolicitudNueva = CLng(dr("CtaRepNuevo"))

    ''                'si el nuevo monto registrado en la base es diferente a la suma de los solicitados,
    ''                'anular las transacciones e ingresar nuevas
    ''                If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
    ''                    'cuenta de rep = 2
    ''                    If Not mblnModificarMontoSolicitudes Then
    ''                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, dr("EstadoTran"), _
    ''                                2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
    ''                                dr("AdmAntiguo"), 0, mblnModificarMontoSolicitudes)
    ''                        'anular cuenta de excedente de rep = 5
    ''                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, dr("EstadoTran"), _
    ''                                2, dr("CtaExcRepAntiguo"), 0, _
    ''                                0, 0, mblnModificarMontoSolicitudes)
    ''                    Else
    ''                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 2, dr("EstadoTran"), _
    ''                                2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
    ''                                dr("DicAdmAntiguo"), 0, mblnModificarMontoSolicitudes)
    ''                        blnInsTransaccion = ModificarTransaccionSiEsNecesario(lngRutTercero, 5, dr("DicEstadoTran"), _
    ''                                2, dr("CtaExcRepAntiguo"), lngMontoSolicitudNueva, _
    ''                                0, 0, mblnModificarMontoSolicitudes)

    ''                    End If
    ''                End If

    ''                'buscar el rut entre las solicitudes existentes
    ''                Dim blnSolicitudEncontrada As Boolean
    ''                blnSolicitudEncontrada = False
    ''                For i = 0 To intContSol - 1
    ''                    If mcolSolicitudes(i + 1).RutBenefactorLng = lngRutTercero Then  'se encontró la solicitud
    ''                        Call mcolSolicitudes(i + 1).Inicializar1(mlngCodCurso, lngRutTercero, mlngRutCliente)
    ''                        If lngMontoSolicitudNueva > 0 Then
    ''                            If Not mblnModificarMontoSolicitudes Then
    ''                                mcolSolicitudes(i).MontoCtaReparto = lngMontoSolicitudNueva
    ''                                mcolSolicitudes(i).NroTransCtaRep = 0
    ''                                Call mcolSolicitudes(i + 1).Modificar()
    ''                                If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
    ''                                    Call mcolSolicitudes(i + 1).CambiarEstPendiente()
    ''                                End If
    ''                            End If
    ''                        Else
    ''                            Call mcolSolicitudes(i + 1).Borrar()
    ''                            EliminarSolicitud(i + 1)
    ''                            intContSol = intContSol - 1
    ''                        End If
    ''                        blnSolicitudEncontrada = True
    ''                        Exit For
    ''                    End If
    ''                Next
    ''                If Not blnSolicitudEncontrada And lngMontoSolicitudNueva > 0 Then  'crear solicitud nueva
    ''                    Dim objSolicitud As New CSolicitud
    ''                    Call objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
    ''                    Call objSolicitud.Inicializar2(mlngRutCliente, lngRutTercero, mlngCodCurso, dr("CtaRepNuevo"), 0)
    ''                    Call objSolicitud.Grabar()
    ''                    'mcolSolicitudes(intContSol) = objSolicitud
    ''                    'intContSol = intContSol + 1
    ''                End If
    ''            Next
    ''        End If




    ''        blnGrabarExitoso = True

    ''        Dim tam_arr_aux As Integer

    ''        If mdtTerceros Is Nothing Then
    ''            mdtTerceros = New DataTable
    ''            mdtTerceros.Columns.Add("rut_benefactor")
    ''            mdtTerceros.Columns.Add("monto")
    ''            mdtTerceros.Columns.Add("cod_estado_solicitud")
    ''            mdtTerceros.Columns.Add("monto_adm")
    ''            mdtTerceros.Columns.Add("monto2")
    ''            mdtTerceros.Columns.Add("cta")
    ''            mdtTerceros.Columns.Add("cod_curso")
    ''            Dim drTerceros As DataRow
    ''            drTerceros = mdtTerceros.NewRow
    ''            drTerceros("rut_benefactor") = -1
    ''            drTerceros("monto") = -1
    ''            drTerceros("cod_estado_solicitud") = -1
    ''            drTerceros("monto_adm") = -1
    ''            drTerceros("monto2") = -1
    ''            drTerceros("cta") = -1
    ''            drTerceros("cod_curso") = -1
    ''            mdtTerceros.Rows.Add(drTerceros)
    ''        Else
    ''            If mdtTerceros.Rows.Count = 0 Then
    ''                Dim drTerceros As DataRow
    ''                drTerceros = mdtTerceros.NewRow
    ''                drTerceros("rut_benefactor") = -1
    ''                drTerceros("monto") = -1
    ''                drTerceros("cod_estado_solicitud") = 0
    ''                drTerceros("monto_adm") = -1
    ''                drTerceros("monto2") = -1
    ''                drTerceros("cta") = 0
    ''                drTerceros("cod_curso") = 0
    ''                mdtTerceros.Rows.Add(drTerceros)
    ''            End If
    ''        End If
    ''        If tam_arr_terc = 1 And mdtTerceros.Rows(0)(0) <= 0 Then
    ''            tam_arr_aux = 0
    ''        Else
    ''            tam_arr_aux = tam_arr_terc
    ''        End If

    ''        Dim blnSolPendientes As Boolean
    ''        blnSolPendientes = False
    ''        If mcolSolicitudes.Count > 0 Then
    ''            For i = 0 To mcolSolicitudes.Count ' TamanoArreglo1(mcolSolicitudes) - 1
    ''                'Si hay pendientes
    ''                If mcolSolicitudes(i + 1).CodEstadoSolicitud = 1 Then
    ''                    blnSolPendientes = True
    ''                    Exit For
    ''                End If
    ''            Next
    ''        End If

    ''        If Not mintCodEstadoCurso > 0 Then
    ''            If mdtModifCuentas.Rows(2).Item(0) = tam_arr_aux And Not blnSolPendientes Then
    ''                Call CambiarEstIngresado("")
    ''            ElseIf (mdtModifCuentas.Rows(2).Item(0) < tam_arr_aux) Or blnSolPendientes Then
    ''                Call CambiarEstPagoPorAut("")
    ''            End If
    ''        Else
    ''            blnGrabarExitoso = False
    ''        End If

    ''        'grabar el nuevo costo_otic, costo_adm, gasto_empresa
    ''        ActualizarDatos2(0)

    ''        'cerrar transacción y conexion
    ''        'mobjSql.FinTransaccion()

    ''        'mlngCorrelativo = lngCorrTemp
    ''        GrabarInfoCuentas2 = blnGrabarExitoso
    ''    Catch ex As Exception
    ''        'mobjSql.RollBackTransaccion()
    ''        EnviaError("CCursoContratado:GrabarHorario-->" & ex.Message)
    ''    End Try

    ''End Function
    'Elimina del arreglo marrSolicitudes el elemento indicado
    Private Sub EliminarSolicitud(ByVal intElemento As Integer)
        'Dim Tamano As Integer
        'Dim i As Integer
        'Tamano = TamanoArreglo1(mcolSolicitudes)
        'For i = intElemento To Tamano - 1
        '    If i < (Tamano - 1) Then
        '        If TypeName(mcolSolicitudes(i + 1)) <> "CSolicitud" Then
        '            mcolSolicitudes(i) = mcolSolicitudes(i + 1)
        '        Else
        '            mcolSolicitudes(i) = mcolSolicitudes(i + 1)
        '        End If
        '    End If
        'Next
        'If Tamano >= 2 Then
        '    ReDim Preserve mcolSolicitudes(Tamano - 2)
        'Else
        '    mcolSolicitudes = New Collection
        'End If
    End Sub
    'Procedimiento para modificar el valor de una transacción, si es diferente a la registrada
    'en la base
    'intEstadoTras: 1=pendiente, 2=autorizada, 3=solicitada, 4=anulada
    'Retorna False si se produce algún error
    Private Function ModificarTransaccionSiEsNecesario( _
                ByVal lngRutCliente As Long, ByVal intCodCuenta As Integer, ByVal intEstadoTran As Integer, _
                ByVal intCodTipoTransaccion As Integer, _
                ByVal lngMontoAntiguo As Long, ByVal lngMontoNuevo As Long, _
                ByVal lngMontoAdmAntiguo As Long, ByVal lngMontoAdmNuevo As Long, _
                ByVal blnModMontoSolicitudes As Boolean) As Boolean

        Try
            Dim serial_trans As Long
            Dim blnActSaldoCuenta As Boolean, blnActSaldoAdm As Boolean
            blnActSaldoCuenta = False
            blnActSaldoAdm = False

            'si los montos antiguos y nuevos son iguales, no hay que hacer cambios
            If lngMontoAntiguo = lngMontoNuevo And lngMontoAdmAntiguo = lngMontoAdmNuevo Then
                ModificarTransaccionSiEsNecesario = True
                Exit Function
            End If

            'si es necesario, anular la transacción antigua
            If lngMontoAntiguo > 0 Then
                If intEstadoTran = 3 Then
                    'las transacciones solicitadas se eliminan, no se anulan
                    Call mobjSql.d_transaccion(lngRutCliente, mlngCodCurso, intCodCuenta)
                Else
                    serial_trans = InsertarTransaccion(intCodCuenta, 4, -lngMontoAntiguo, _
                                    lngRutCliente, intCodTipoTransaccion)
                End If
                blnActSaldoCuenta = True
            End If

            'si tiene administración, anularla
            If lngMontoAdmAntiguo > 0 Then
                If intEstadoTran = 3 Then   'eliminar las solicitadas
                    Call mobjSql.d_transaccion(lngRutCliente, mlngCodCurso, 3)
                Else
                    serial_trans = InsertarTransaccion(3, 4, -lngMontoAdmAntiguo, lngRutCliente, intCodTipoTransaccion)
                End If
                blnActSaldoAdm = True
            End If

            '**|** Se agregó cuenta 6 becas, no paga administración
            If Not blnModMontoSolicitudes Or intCodCuenta = 1 Or intCodCuenta = 4 Or intCodCuenta = 6 Then
                'agregar la nueva transaccion si es necesario
                If lngMontoNuevo > 0 Then
                    If intCodTipoTransaccion = 5 Then
                        serial_trans = InsertarTransaccion(intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente, intCodTipoTransaccion)
                    Else
                        serial_trans = InsertarTransaccion(intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente)
                    End If
                    blnActSaldoCuenta = True
                End If

                'si la cuenta es cta. cap o cta. rep, tiene administración
                If (intCodCuenta = 1 Or intCodCuenta = 2) And lngMontoAdmNuevo > 0 Then
                    If intCodTipoTransaccion = 5 Then
                        serial_trans = InsertarTransaccion(3, intEstadoTran, lngMontoAdmNuevo, lngRutCliente, intCodTipoTransaccion)
                    Else
                        serial_trans = InsertarTransaccion(3, intEstadoTran, lngMontoAdmNuevo, lngRutCliente)
                    End If
                    blnActSaldoAdm = True
                End If
            Else
                If lngMontoAntiguo > 0 Then
                    If lngMontoNuevo > 0 Then
                        serial_trans = InsertarTransaccion(intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente)
                        Call mobjSql.u_nro_trans_solicitud_pago_ter1(mlngCodCurso, lngRutCliente, serial_trans)
                        blnActSaldoCuenta = True
                    End If
                End If
            End If
            'actualizar los saldos si es necesario
            'actualizar saldo cuenta
            If blnActSaldoCuenta Then Call ActualizarSaldoCuenta(lngRutCliente, intCodCuenta)
            'actualizar saldo cuenta de administración
            If blnActSaldoAdm Then Call ActualizarSaldoCuenta(lngRutCliente, 3)

            ModificarTransaccionSiEsNecesario = True
        Catch ex As Exception
            'Call mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:ModificarTransaccionSiEsNecesario-->" & ex.Message)
        End Try

    End Function
    Private Function ModificarTransaccionSiEsNecesario2( _
                ByVal lngRutCliente As Long, ByVal intCodCuenta As Integer, ByVal intEstadoTran As Integer, _
                ByVal intCodTipoTransaccion As Integer, _
                ByVal lngMontoAntiguo As Long, ByVal lngMontoNuevo As Long, _
                ByVal lngMontoAdmAntiguo As Long, ByVal lngMontoAdmNuevo As Long, _
                ByVal blnModMontoSolicitudes As Boolean) As Boolean

        Try
            Dim serial_trans As Long
            Dim blnActSaldoCuenta As Boolean, blnActSaldoAdm As Boolean
            blnActSaldoCuenta = False
            blnActSaldoAdm = False

            'si los montos antiguos y nuevos son iguales, no hay que hacer cambios
            If lngMontoAntiguo = lngMontoNuevo And lngMontoAdmAntiguo = lngMontoAdmNuevo Then
                ModificarTransaccionSiEsNecesario2 = True
                Exit Function
            End If

            'si es necesario, anular la transacción antigua
            If lngMontoAntiguo > 0 Then
                If intEstadoTran = 3 Then
                    'las transacciones solicitadas se eliminan, no se anulan
                    Call mobjSql.d_transaccion(lngRutCliente, mlngCodCurso, intCodCuenta)
                Else
                    serial_trans = InsertarTransaccion(intCodCuenta, 4, -lngMontoAntiguo, _
                                    lngRutCliente, intCodTipoTransaccion)
                End If
                blnActSaldoCuenta = True
            End If

            'si tiene administración, anularla
            If lngMontoAdmAntiguo > 0 Then
                If intEstadoTran = 3 Then   'eliminar las solicitadas
                    Call mobjSql.d_transaccion(lngRutCliente, mlngCodCurso, 3)
                Else
                    serial_trans = InsertarTransaccion(3, 4, -lngMontoAdmAntiguo, lngRutCliente, intCodTipoTransaccion)
                End If
                blnActSaldoAdm = True
            End If

            '**|** Se agregó cuenta 6 becas, no paga administración
            If Not blnModMontoSolicitudes Or intCodCuenta = 1 Or intCodCuenta = 4 Or intCodCuenta = 6 Then
                'agregar la nueva transaccion si es necesario
                If lngMontoNuevo > 0 Then
                    If intCodTipoTransaccion = 5 Then
                        serial_trans = InsertarTransaccion(intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente, intCodTipoTransaccion)
                    Else
                        serial_trans = InsertarTransaccion(intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente)
                    End If
                    blnActSaldoCuenta = True
                End If

                'si la cuenta es cta. cap o cta. rep, tiene administración
                If (intCodCuenta = 1 Or intCodCuenta = 2) And lngMontoAdmNuevo > 0 Then
                    If intCodTipoTransaccion = 5 Then
                        serial_trans = InsertarTransaccion(3, intEstadoTran, lngMontoAdmNuevo, lngRutCliente, intCodTipoTransaccion)
                    Else
                        serial_trans = InsertarTransaccion(3, intEstadoTran, lngMontoAdmNuevo, lngRutCliente)
                    End If
                    blnActSaldoAdm = True
                End If
            Else
                If lngMontoAntiguo > 0 Then
                    If lngMontoNuevo > 0 Then
                        serial_trans = InsertarTransaccion(intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente)
                        Call mobjSql.u_nro_trans_solicitud_pago_ter1(mlngCodCurso, lngRutCliente, serial_trans)
                        blnActSaldoCuenta = True
                    End If
                End If
            End If
            'actualizar los saldos si es necesario
            'actualizar saldo cuenta
            If blnActSaldoCuenta Then Call ActualizarSaldoCuenta(lngRutCliente, intCodCuenta)
            'actualizar saldo cuenta de administración
            If blnActSaldoAdm Then Call ActualizarSaldoCuenta(lngRutCliente, 3)

            ModificarTransaccionSiEsNecesario2 = True
        Catch ex As Exception
            'Call mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:ModificarTransaccionSiEsNecesario-->" & ex.Message)
        End Try

    End Function
    'actualiza el saldo en la cuenta de un cliente
    Private Sub ActualizarSaldoCuenta(ByVal lngRutEmpresa As Long, ByVal intCodCuenta As Integer)

        Try
            If lngRutEmpresa = mlngRutCliente Then  'si es el cliente dueño del curso
                Dim objCliente As New CCliente

               
                Select Case intCodCuenta
                    Case 1
                        mobjCliente.ObjCuentaCap.inicializarCsql(mobjSql)
                        mobjCliente.ObjCuentaCap.Actualizar_Saldo()
                    Case 3
                        mobjCliente.ObjCuentaAdm.inicializarCsql(mobjSql)
                        mobjCliente.ObjCuentaAdm.Actualizar_Saldo()
                    Case 4
                        mobjCliente.ObjCuentaExcCap.inicializarCsql(mobjSql)
                        mobjCliente.ObjCuentaExcCap.Actualizar_Saldo()
                    Case 6 '**|**
                        mobjCliente.ObjCuentaBecas.inicializarCsql(mobjSql)
                        mobjCliente.ObjCuentaBecas.Actualizar_Saldo()

                End Select
            Else
                'actualizar la cuenta de un tercero
                Dim objCliente As New CCliente
                objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                objCliente.Inicializar1(RutLngAUsr(lngRutEmpresa))
                Select Case intCodCuenta
                    Case 2
                        mobjCliente.ObjCuentaRep.Actualizar_Saldo()
                    Case 3
                        mobjCliente.ObjCuentaAdm.Actualizar_Saldo()
                    Case 5
                        mobjCliente.ObjCuentaExcRep.Actualizar_Saldo()
                    Case 6 '**|**
                        mobjCliente.ObjCuentaBecas.Actualizar_Saldo()

                End Select
            End If
        Catch ex As Exception
            'mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:ModificarTransaccionSiEsNecesario-->" & ex.Message)
        End Try
    End Sub

    'procedimiento que inserta una transacción en la base de datos
    Private Function InsertarTransaccion(ByVal intCodCuenta As Integer, ByVal intEstadoTrans As Integer, _
                                        ByVal lngMontoTran As Long, ByVal lngRutCliente As Long, _
                                        Optional ByVal intTipoTrans As Integer = 2) As Long

        Try
            'ahora intTipoTrans lo doy como parametro
            'Dim intTipoTrans As Integer
            Dim lngSerialTrans As Long
            Dim strDescripcion As String
            Dim intEstadoTranTemp As Integer
            Dim blnError As Boolean
            'intTipoTrans = 2
            blnError = False  'no hay error
            intEstadoTranTemp = intEstadoTrans
            'intEstadoTrans: 1 pendiente, 2 autorizada, 3 solicitada, 4 anulada
            Select Case intEstadoTrans

                'intCodCuenta: 1 cap, 2 rep, 3 adm, 4 exc cap, 5 exc rep
                Case 1 'pendiente
                    Select Case intCodCuenta
                        Case 1, 4
                            If intTipoTrans = 5 Then
                                strDescripcion = "Cargo por V&T de Curso"
                            Else
                                strDescripcion = "Cargo por Curso"
                            End If
                        Case 3
                            If intTipoTrans = 5 Then
                                strDescripcion = "Cargo por Administración de V&T de Curso"
                            Else
                                strDescripcion = "Cargo por Administración de Curso"
                            End If
                        Case 2, 5
                            strDescripcion = "Cargo por Curso de Tercero"
                            intEstadoTranTemp = 3
                        Case 6
                            strDescripcion = "Cargo por Curso con Becas"
                        Case Else
                            blnError = True
                    End Select

                Case 2 'autorizada
                    Select Case intCodCuenta
                        Case 1, 4
                            If intTipoTrans = 5 Then
                                strDescripcion = "Ajuste de V&T de Curso"
                            Else
                                strDescripcion = "Ajuste de Curso"
                            End If
                        Case 3
                            If intTipoTrans = 5 Then
                                strDescripcion = "Ajuste por Administración de V&T de Curso"
                            Else
                                strDescripcion = "Ajuste por Administración de Curso"
                            End If
                        Case 2, 5
                            strDescripcion = "Ajuste por Curso de Tercero"
                        Case 6
                            strDescripcion = "Ajuste por Curso con Becas"
                        Case Else
                            blnError = True
                    End Select

                Case 3 'solicitada
                    Select Case intCodCuenta
                        Case 2, 5
                            strDescripcion = "Cargo por Curso de Tercero"
                        Case Else
                            blnError = True
                    End Select

                Case 4 'anulada
                    Select Case intCodCuenta
                        Case 1, 4
                            If intTipoTrans = 5 Then
                                strDescripcion = "Anulación de Cargo por V&T de Curso"
                            Else
                                strDescripcion = "Anulación de Cargo por Curso"
                            End If
                        Case 3
                            If intTipoTrans = 5 Then
                                strDescripcion = "Anulación de Cargo por Administración de V&T de Curso"
                            Else
                                strDescripcion = "Anulación de Cargo por Administración de Curso"
                            End If
                        Case 2, 5
                            strDescripcion = "Anulación de Cargo por Curso de Tercero"
                        Case 6
                            strDescripcion = "Anulación de Curso con Becas"
                        Case Else
                            blnError = True
                    End Select

                Case Else
                    blnError = True

            End Select

            Dim dtmFechaHoraTran As Date
            dtmFechaHoraTran = Now
            'si la fecha de inicio del curso es posterior al año actual
            If Year(mdtmFechaInicio) > Year(dtmFechaHoraTran) Then
                dtmFechaHoraTran = "02/01/" & Year(mdtmFechaInicio)
            ElseIf Year(mdtmFechaInicio) < Year(dtmFechaHoraTran) Then
                dtmFechaHoraTran = "31/12/" & Year(mdtmFechaInicio) 'fecha y hora
            End If

            lngSerialTrans = mobjSql.i_transaccion(lngRutCliente, intCodCuenta, intTipoTrans, _
                intEstadoTranTemp, lngMontoTran, _
                strDescripcion & ", Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                mlngCodCurso, 0, dtmFechaHoraTran)

        Catch ex As Exception
            'mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:ModificarTransaccionSiEsNecesario-->" & ex.Message)
        End Try


    End Function
    Public Function ObtenerSolPagoTerc(ByVal lngCodCurso As Long, _
                                   ByVal strRutBenefactor As String) As CSolicitud
        Try
            Dim lngRutBenef As Long
            Dim i, intTamArr As Integer
            'Dim col As Collection
            lngRutBenef = CLng(strRutBenefactor)
            intTamArr = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)

            For i = 0 To intTamArr - 1
                'For Each col In Me.mcolSolicitudes
                If mcolSolicitudes(i + 1).CodCurso = lngCodCurso Then
                    If mcolSolicitudes(i + 1).RutBenefactor = lngRutBenef Then
                        ObtenerSolPagoTerc = mcolSolicitudes(i + 1)
                    End If
                End If
            Next

        Catch ex As Exception
            EnviaError("CCursoContratado:ObtenerSolPagoTerc-->" & ex.Message)
        End Try


        'If Not mcollAtributoUsuario Is Nothing Then
        '    If mcollAtributoUsuario.Count > 0 Then
        '        Dim iAtributoUsuario As AtribUsuario
        '        mobjSql.d_atributos_por_usuarios(Me.Rut)
        '        For Each iAtributoUsuario In Me.mcollAtributoUsuario
        '            mobjSql.i_atributo_usuario(iAtributoUsuario.RutUsuario, iAtributoUsuario.CodCaracteristica, _
        '            iAtributoUsuario.CodAtributo)
        '        Next
        '    End If
        'End If


    End Function
#Region "Cambios de estado"
    Public Sub CambiarEstIncompleto(ByVal strGlosa As String)
        Try
            mintCodEstadoCurso = 0  '0 es el codigo del estado "Incompleto"

            'abrir conexion y transaccion
            'Call mobjSql.InicioTransaccion()

            Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
            Call mobjSql.i_bitacora(mlngRutUsuario, "Incompleto", _
                            "El Curso cambia a estado Incompleto. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, _
                            1, mlngCodCurso)
            'cerrar transacción y conexion
            'Call mobjSql.FinTransaccion()

            Exit Sub
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstIncompleto-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try

    End Sub

    Public Function CambiarEstIngresado(ByVal strGlosa As String) As Boolean
        Try

            'el curso puede cambiar a estdo ingresado sólo si está incompleto-0, ingresado-1,
            'rechazado-2, autorizado-3, eliminado-8 - (Pago por autorizar 6, NO devuelve el último estado)
            If mintCodEstadoCurso = 6 Then
                'Deja pasar
            ElseIf mintCodEstadoCurso <> 0 And mintCodEstadoCurso <> 1 And mintCodEstadoCurso <> 2 _
                And mintCodEstadoCurso <> 3 And mintCodEstadoCurso <> 6 And mintCodEstadoCurso <> 8 _
                And mintCodEstadoCurso <> 7 And mintCodEstadoCurso <> 5 And mintCodEstadoCurso <> 4 _
                And mintCodEstadoCurso <> 9 And mintCodEstadoCurso <> 11 And mintCodEstadoCurso <> 10 Then
                CambiarEstIngresado = False
                Exit Function
            End If


            Dim dtEstadoTrans As DataTable
            Dim i, intTamArr, intContador As Integer
            Dim lngMaxCorrelativo As Long
            Dim blnResultado As Boolean
            mobjSql = New CSql
            'dtEstadoTrans = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            'If mobjSql.Registros > 0 Then
            If mintCodEstadoCurso = 6 Then
                mintCodEstadoCurso = mobjSql.s_ultimo_estado_curso(mlngCodCurso)
                If mintCodEstadoCurso = 6 Or mintCodEstadoCurso = 0 Then 'Esto no debería pasar
                    mintCodEstadoCurso = 1
                End If
            Else
                mintCodEstadoCurso = 1  '1 es el codigo del estado "Ingresado"
            End If

            'abrir conexion y transaccion
            mobjSql.InicioTransaccion()
            mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
            mobjSql.i_bitacora(mlngRutUsuario, "Ingresado", _
                            "El Curso cambia a estado Ingresado. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, _
                            1, mlngCodCurso)

            If mlngCorrelativo <= 0 Then
                If mblnGenerarNuevoCorr Then
                    lngMaxCorrelativo = mobjSql.s_max_correlativo(mlngAgno)
                    If lngMaxCorrelativo >= 0 Then
                        mlngCorrelativo = lngMaxCorrelativo + 1
                    Else
                        mlngCorrelativo = 1
                    End If
                Else
                    mlngCorrelativo = mlngCorrElearning
                End If
                Call ActualizarDatos(0)
            End If

            'cerrar transacción y conexion
            Call mobjSql.FinTransaccion()

            blnResultado = True
            'Else
            'CambiarEstPagoPorAut("")
            'blnResultado = False
            'End If
            CambiarEstIngresado = blnResultado

        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CCurso2:CambiarEstIngresado-->" & ex.Message)

        End Try
    End Function


    'Este cambio de estado es sólo llamado por fuera, y es para cambiar el estado de cursos
    'liquidados a ingresados. Por fuera se deebe verificar el permiso para realizar esta operación
    Public Function CambiarEstIngresado2(ByVal strGlosa As String) As Boolean
        Try
            'Este es sólo para cursos anulados, liquidados o comunicados
            If mintCodEstadoCurso = 10 Or mintCodEstadoCurso = 5 Or mintCodEstadoCurso = 4 Then
                'Deja pasar
            Else
                CambiarEstIngresado2 = False
                Exit Function
            End If

            Dim dtEstadoTrans As DataTable
            Dim i, intTamArr, intContador As Integer
            Dim lngMaxCorrelativo As Long
            Dim blnResultado As Boolean
            dtEstadoTrans = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If mobjSql.Registros > 0 Then
                If mintCodEstadoCurso = 6 Then
                    mintCodEstadoCurso = mobjSql.s_ultimo_estado_curso(mlngCodCurso)
                    If mintCodEstadoCurso = 6 Or mintCodEstadoCurso = 0 Then 'Esto no debería pasar
                        mintCodEstadoCurso = 1
                    End If
                Else
                    mintCodEstadoCurso = 1  '1 es el codigo del estado "Ingresado"
                End If

                'abrir conexion y transaccion
                'Call mobjSql.InicioTransaccion()
                Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
                Call mobjSql.i_bitacora(mlngRutUsuario, "Ingresado", _
                                "El Curso cambia a estado Ingresado. Cliente: " _
                                & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, _
                                1, mlngCodCurso)

                If mlngCorrelativo <= 0 Then
                    If mblnGenerarNuevoCorr Then
                        lngMaxCorrelativo = mobjSql.s_max_correlativo(mlngAgno)
                        If lngMaxCorrelativo >= 0 Then
                            mlngCorrelativo = lngMaxCorrelativo + 1
                        Else
                            mlngCorrelativo = 1
                        End If
                    Else
                        mlngCorrelativo = mlngCorrElearning
                    End If
                    Call ActualizarDatos(0)
                End If

                'cerrar transacción y conexion
                'Call mobjSql.FinTransaccion()

                blnResultado = True
            Else
                Call CambiarEstPagoPorAut("")
                blnResultado = False
            End If
            CambiarEstIngresado2 = blnResultado
            Exit Function
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstIngresado2-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function


    Public Function CambiarEstRechazado(ByVal strGlosa As String) As Boolean
        Try
            mintCodEstadoCurso = 2  '2 es el codigo del estado "Rechazado"

            'abrir conexion y transaccion
            'Call mobjSql.InicioTransaccion()

            Call mobjSql.u_estado_curso(mlngCodCurso, 2)
            Call mobjSql.i_bitacora(mlngRutUsuario, "Rechazado", _
                            "El Curso cambia a estado Rechazado. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, _
                            1, mlngCodCurso)

            Call mobjSql.d_transaccion_solic(mlngCodCurso)
            Dim dtTransacciones As DataTable
            Dim intNumTrans, i As Integer
            dtTransacciones = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtTransacciones.Rows
                    Call InsertarTransaccion(dr("cod_cuenta"), 4, _
                                            -dr("monto"), dr("rut_cliente"), dr("cod_tipo_tran"))
                Next
            End If
            'Elimina las solicitudes de pago a terceros
            'Se debe antes inicializar las cuentas
            Dim tam_arr_modif As Integer
            tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
            For i = 0 To tam_arr_modif - 1
                mcolSolicitudes(i).Borrar()
            Next

            'cerrar transacción y conexion
            'Call mobjSql.FinTransaccion()
            CambiarEstRechazado = True
            Exit Function
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstRechazado-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function

    Public Function CambiarEstEliminado(ByVal strGlosa As String) As Boolean
        Try

            mintCodEstadoCurso = 8  '8 es el codigo del estado "Eliminado"

            'abrir transaccion
            'Call mobjSql.InicioTransaccion()

            Call mobjSql.u_estado_curso(mlngCodCurso, 8)
            Call mobjSql.i_bitacora(mlngRutUsuario, "Eliminado", _
                            "El Curso cambia a estado Eliminado. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, _
                            1, mlngCodCurso)
            Call mobjSql.d_transaccion_solic(mlngCodCurso)
            Dim dtTransacciones As DataTable
            Dim intNumTrans, i As Integer
            dtTransacciones = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtTransacciones.Rows
                    Call InsertarTransaccion(dr("cod_cuenta"), 4, _
                                            -dr("monto"), dr("rut_cliente"), dr("cod_tipo_tran"))
                Next
            End If
            'Elimina las solicitudes de pago a terceros
            'Se debe antes inicializar las cuentas
            Dim tam_arr_modif As Integer
            tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
            For i = 0 To tam_arr_modif - 1
                mcolSolicitudes(i).Borrar()
            Next

            'cerrar transacción y conexion
            'Call mobjSql.FinTransaccion()
            CambiarEstEliminado = True
            Exit Function
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstEliminado-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function

    'anulación de curso. Si la glosa es vacía, se asume que es anulación automática, es decir,
    'todos los alumnos tienen asistencia < 75%.
    Public Function CambiarEstAnulado(ByVal strGlosa As String) As Boolean
        Try
            Dim strGlosaTemp As String
            If strGlosa = "" Then
                strGlosaTemp = "Curso Anulado debido a que la asistencia de los alumnos fué " _
                                & "menor que 75%."
            Else
                strGlosaTemp = strGlosa
            End If
            mintCodEstadoCurso = 10  '10 es el codigo del estado "Anulado"

            'abrir conexion y transaccion
            'Call mobjSql.InicioTransaccion()

            Call mobjSql.u_estado_curso(mlngCodCurso, 10)
            Call mobjSql.u_anular_curso_gasto_empresa(mlngCodCurso)
            Call mobjSql.i_bitacora(mlngRutUsuario, "Anulado", _
                            "El Curso cambia a estado Anulado. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ". " & strGlosaTemp, _
                            1, mlngCodCurso)
            Call mobjSql.d_transaccion_solic(mlngCodCurso)
            Dim dtTransacciones As DataTable
            Dim intNumTrans, i As Integer
            dtTransacciones = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtTransacciones.Rows
                    Call InsertarTransaccion(dr("cod_cuenta"), 4, _
                                            -dr("monto"), dr("rut_cliente"), dr("cod_tipo_tran"))
                Next
            End If

            'Elimina las solicitudes de pago a terceros
            'Se debe antes inicializar las cuentas
            Dim tam_arr_modif As Integer
            tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
            For i = 0 To tam_arr_modif - 1
                mcolSolicitudes(i + 1).Borrar()
            Next

            'cerrar transacción y conexion
            'Call mobjSql.FinTransaccion()
            CambiarEstAnulado = True
            Exit Function
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstAnulado-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function
    'anulación de curso. Si la glosa es vacía, se asume que es anulación automática, es decir,
    'todos los alumnos tienen asistencia < 75%.

    '¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡IMPORTATE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    'EN ASIMET, CUANDO TODOS LOS PARTICIPANTES TIENEN UNA ASISTENCIA MENOR A 75%, LOS COSTOS PASAN A GASTO EMPRESA (COMO SIEMPRE)
    ' Y EL CURSO QUEDA EN EL ESTADO LIQUIDADO 
    Public Function CambiarEstAnuladoPorAsistencia() As Boolean
        Try
            Dim strGlosaTemp As String

            strGlosaTemp = "Curso Liquidado debido a que la asistencia de los alumnos fué " _
                            & "menor que 75%."
            mintCodEstadoCurso = 10 '10 es el codigo del estado "Anulado"

            'abrir conexion y transaccion
            'Call mobjSql.InicioTransaccion()

            Call mobjSql.u_estado_curso_por_asitencia(mlngCodCurso, mintCodEstadoCurso)
            Call mobjSql.i_bitacora(mlngRutUsuario, "Anulado", _
                            "El Curso cambia a estado Anulado. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ". " & strGlosaTemp, _
                            1, mlngCodCurso)
            Call mobjSql.d_transaccion_solic(mlngCodCurso)
            Dim dtTransacciones As DataTable
            Dim intNumTrans, i As Integer
            dtTransacciones = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtTransacciones.Rows
                    Call InsertarTransaccion(dr("cod_cuenta"), 4, _
                                            -dr("monto"), dr("rut_cliente"), dr("cod_tipo_tran"))
                Next
            End If

            'Elimina las solicitudes de pago a terceros
            'Se debe antes inicializar las cuentas
            Dim tam_arr_modif As Integer
            tam_arr_modif = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)
            For i = 0 To tam_arr_modif - 1
                mcolSolicitudes(i + 1).Borrar()
            Next

            'cerrar transacción y conexion
            'Call mobjSql.FinTransaccion()
            CambiarEstAnuladoPorAsistencia = True
            Exit Function
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstAnulado-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function

    Public Function CambiarEstAutorizado(ByVal strGlosa As String) As Boolean
        Try
            Dim dtEstadoTrans As DataTable
            Dim i, intTamArr, intContador As Integer

            dtEstadoTrans = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If mobjSql.Registros > 0 Then
                If mintCodEstadoCurso = 1 Or mintCodEstadoCurso = 6 Then
                    mintCodEstadoCurso = 3  '3 es el codigo del estado "Autorizado"

                    'abrir conexion y transaccion
                    'Call mobjSql.InicioTransaccion()

                    Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
                    Call mobjSql.i_bitacora(mlngRutUsuario, "Autorizado", _
                                    "El Curso cambia a estado Autorizado. Cliente: " _
                                    & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, _
                                    1, mlngCodCurso)

                    'cerrar transacción y conexion
                    'Call mobjSql.FinTransaccion()
                    CambiarEstAutorizado = True
                Else
                    Call CambiarEstPagoPorAut("")
                    CambiarEstAutorizado = False
                End If
            End If
            Exit Function
        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CCurso2:CambiarEstAutorizado-->" & ex.Message)

        End Try
    End Function

    'Precondicion: Todas las transacciones relacionadas con el curso estan autorizadas
    'Comunicación del curso
    Public Function CambiarEstComunicado(ByVal strGlosa As String, _
                                         ByVal lngNroRegistro As Long) As Boolean
        Try
            'Dentro de este cambio de estado hay que llenar una Base de
            'Datos Access y enviarla al Sence

            Dim dtEstadoTrans As DataTable
            Dim i, intTamArr, intContador As Integer
            Dim blnAux As Boolean

            dtEstadoTrans = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            If mobjSql.Registros > 0 Then
                If mintCodEstadoCurso = 7 Then
                    mintCodEstadoCurso = 4  '4 es el codigo del estado "Comunicado"
                    mlngNroRegistro = lngNroRegistro
                    mdtmFechaComunicacion = Date.Now

                    'registrar la información en la base
                    Call RegistrarComunicacion("Comunicación aprobada. " & strGlosa)
                    CambiarEstComunicado = True
                Else
                    CambiarEstComunicado = False
                End If

                Exit Function
            End If
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstComunicado-->" & ex.Message)
        End Try
    End Function

    'registra en la base de datos la comunicación de un curso
    Public Function RegistrarComunicacion(ByVal strGlosa As String) As Boolean
        Try
            'abrir conexion y transaccion


            'generar complemento del curso
            If mlngHorasCompl > 0 And (IsDBNull(mlngCodCursoCompl) Or mlngCodCursoCompl <= 0) Then
                If Not GenerarComplementario() Then
                    Call mobjSql.FinTransaccion()
                    RegistrarComunicacion = False
                    Exit Function
                End If
            End If
            Call mobjSql.InicioTransaccion()
            Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
            Call mobjSql.i_bitacora(mlngRutUsuario, "Comunicado", strGlosa & ". Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ". Fecha: " & FechaVbAUsr(mdtmFechaComunicacion), _
                            1, mlngCodCurso)
            Call mobjSql.u_estado_transaccion2(mlngCodCurso)

            mlngValorComunicado = mlngCostoOtic + mlngGastoEmpresa
            'cerrar transacción y conexion
            Call mobjSql.FinTransaccion()

            Call ActualizarDatos(0)

           
            RegistrarComunicacion = True
            Exit Function
        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CCurso2:RegistrarComunicacion-->" & ex.Message)

        End Try
    End Function


    'Precondicion: El curso está "con asistencia"
    Public Function CambiarEstEnLiquidacion(ByVal strGlosa As String) As Boolean
        Try
            If mintCodEstadoCurso = 11 Then  'con asistencia
                mintCodEstadoCurso = 9  '9 es el codigo del estado "En Liquidación"
                mdtmFechaLiquidacion = Date.Now

                'abrir conexion y transaccion
                'Call mobjSql.InicioTransaccion()

                Call mobjSql.i_bitacora(mlngRutUsuario, "En Liquidación", _
                                "El Curso cambia a estado En Liquidacion. Cliente: " _
                                & RutLngAUsr(mlngRutCliente) & ". Fecha: " & FechaVbAUsr(mdtmFechaLiquidacion) _
                                & ". " & strGlosa, _
                                1, mlngCodCurso)
                Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)

                'cerrar transacción y conexion
                'Call mobjSql.FinTransaccion()

                'Call ActualizarDatos
                CambiarEstEnLiquidacion = True
            Else
                CambiarEstEnLiquidacion = False
            End If

            Exit Function
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstEnLiquidacion-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function

    '
    ' Cambia el estado de un curso a Liquidado.
    '
    ' Este código es igual a CambiarEstEnLiquidación, seguramente hay
    ' que sacar varias actualizaciones y consultas que no son necesarias
    ' para optimizarlo. Dionel, 19/02/2002
    '
    Public Function CambiarEstLiquidado(ByVal strGlosa As String, _
    Optional ByVal strNroRegistroCompl As String = "") As Boolean
        Try
            If mintCodEstadoCurso = 9 Then
                mintCodEstadoCurso = 5  '5 es el codigo del estado "Liquidado"
                mdtmFechaLiquidacion = Date.Now

                'abrir conexion y transaccion
                Call mobjSql.InicioTransaccion()

                Call mobjSql.i_bitacora(mlngRutUsuario, "Liquidado", _
                                "El Curso cambia a estado Liquidado. Cliente: " _
                                & RutLngAUsr(mlngRutCliente) & ". Fecha: " & FechaVbAUsr(mdtmFechaLiquidacion) _
                                & ". " & strGlosa, _
                                1, mlngCodCurso)
                Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
                Call mobjSql.FinTransaccion()
                'actualización del encabezado
                Call ObtenerAlumnos()
                Call CalcularCostos()
                '        Call CalcCostoOtic
                '        Call CalcGastoEmpresa
                Call CalcCostoAdm()



                Call ActualizarDatos(0)

                'el curso tiene complemento, debe ingresar el nro de registro
                If mlngCodCursoCompl > 0 Then
                    'asignar nro
                    Dim objCursoCompl As CCursoContratado
                    objCursoCompl = CursoCompl
                    objCursoCompl.NroRegistro = CLng(strNroRegistroCompl)
                    Call objCursoCompl.ActualizarDatos(4)
                    objCursoCompl = Nothing
                End If

                'cerrar transacción y conexion
                ' Call mobjSql.FinTransaccion()

                CambiarEstLiquidado = True
            Else
                CambiarEstLiquidado = False
            End If

            Exit Function
        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CCurso2:CambiarEstLiquidado-->" & ex.Message)

        End Try
    End Function


    Public Sub CambiarEstPagoPorAut(ByVal strGlosa As String)
        Try
            Dim dtEstadoTrans As DataTable
            Dim i, intTamArr, intContador As Integer

            dtEstadoTrans = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            ' ''1:          Pendiente
            ' ''2:          Autorizada
            ' ''3:          Solicitada
            ' ''4:          Anulada
            intTamArr = mobjSql.Registros '(dtEstadoTrans)
            intContador = 0
            For i = 0 To (intTamArr - 1)
                If dtEstadoTrans.Rows(i)(3) = 3 Then '(3, i)
                    intContador = intContador + 1
                End If
            Next

            If intContador > 0 Then
                If mintCodEstadoCurso <> 6 Then
                    mintCodUltEstadoCurso = mintCodEstadoCurso  'Registra el último estado
                End If
                mintCodEstadoCurso = 6                          '6 es el codigo del estado "Pago por Autorizar"

                'abrir conexion y transaccion
                ' Call mobjSql.InicioTransaccion()

                'Registra el ult. estado, que será devuelto cuando se autoricen los pagos o se anulen
                Call mobjSql.u_ultimo_estado_curso(mlngCodCurso, mintCodUltEstadoCurso)

                Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
                Call mobjSql.i_bitacora(mlngRutUsuario, "Pago por Autorizar", _
                                "Se espera autorizacion de Tercero para Pago. " _
                                & "El Curso cambia a estado Pago por Autorizar. Cliente: " _
                                & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, _
                                1, mlngCodCurso)
                'cerrar transacción y conexion
                'Call mobjSql.FinTransaccion()
            End If
            Exit Sub
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstPagoPorAut-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Sub

    'Precondicion: Todas las transacciones relacionadas con el curso estan autorizadas
    Public Function EnComunicacion(ByVal lngCodCurso As Long, _
            ByVal strGlosa As String) As Boolean
        Try
            Dim arrEstadoTrans As Object
            Dim i, intTamArr, intContador As Integer
            arrEstadoTrans = mobjSql.s_num_rut_cta_est_tran(mlngCodCurso)
            intTamArr = TamanoArreglo2(arrEstadoTrans)
            intContador = 0
            For i = 0 To (intTamArr - 1)
                If arrEstadoTrans(3, i) <> 3 Then
                    intContador = intContador + 1
                End If
            Next
            If mintCodEstadoCurso = 3 And intContador = intTamArr Then
                mintCodEstadoCurso = 7  '7 es el codigo del estado "En Comunicacion"

                'actualizar cálculos
                Call ObtenerAlumnos()
                Call CalcularCostos()
                '        Call CalcCostoOtic
                '        Call CalcGastoEmpresa
                Call CalcCostoAdm()

                'abrir conexion y transaccion
                'Call mobjSql.InicioTransaccion()
                Call mobjSql.u_estado_curso(mlngCodCurso, mintCodEstadoCurso)
                Call ActualizarDatos(1)

                'cerrar transacción y conexion
                'Call mobjSql.FinTransaccion()

                EnComunicacion = True
            Else
                EnComunicacion = False
            End If

            Exit Function
        Catch ex As Exception
            EnviaError("CCurso2:EnComunicacion-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function
    Public Function ComunicacionManual(ByVal strFechaComunicacion, ByVal lngNroRegistro, ByVal strGlosa) As Boolean
        Try
            If mintCodEstadoCurso <> 3 And mintCodEstadoCurso <> 7 Then
                ComunicacionManual = False
                Exit Function
            End If

            mdtmFechaComunicacion = FechaUsrAVb(strFechaComunicacion)
            mlngNroRegistro = lngNroRegistro
            mstrObsCurso = mstrObsCurso & strGlosa
            mintCodEstadoCurso = 4  'comunicado

            RegistrarComunicacion("Comunicación manual. " & strGlosa)
            Exit Function
        Catch ex As Exception
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function
#End Region

    Public Function GenerarComplementario() As Boolean
        Try
            Dim blnInic1 As Boolean
            Dim i, intTamArr As Integer
            Dim dtTerceros As DataTable
            Dim arrTemp As Object
            Dim mobjCursoComp As CCursoContratado

            mobjCursoComp = New CCursoContratado
            Call mobjCursoComp.Inicializar0(mobjSql, mlngRutUsuario)
            blnInic1 = mobjCursoComp.Inicializar1(mlngCodCurso)
            If Not blnInic1 Then
                GenerarComplementario = False
                Exit Function
            Else
                '
                'generar el curso complementario
                'Los viáticos y traslados se cargan todos al año actual (del curso parcial)
                arrTemp = mobjCursoComp.ObtenerAlumnos
                Call ObtenerAlumnos()
                intTamArr = TamanoArreglo1(arrTemp)
                mobjCursoComp.Agno = mlngAgno + 1
                'asignar nro registro
                'mobjCursoComp.NroRegistro = mlngNroRegistro
                mobjCursoComp.NroRegistro = -1
                'Seteo las fechas
                mobjCursoComp.FechaInicio = "01/01/" & CStr(mlngAgno + 1)
                mdtmFechaTermino = FechaUsrAVb("31/12/" & CStr(mlngAgno))

                'Seteo las horas
                mobjCursoComp.Horas = mlngHorasCompl
                mobjCursoComp.HorasCompl = 0
                'Seteo Valor Mercado y Descuento
                Dim dblFactorHoras As Double
                dblFactorHoras = mlngHorasCompl / mlngHoras
                mobjCursoComp.ValorMercado = Math.Round(dblFactorHoras * mlngValorMercado)
                If mintIndDescPorc = 0 Then  'si el descuento es en monto
                    mobjCursoComp.Descuento = Math.Round(dblFactorHoras * mlngDescuento)
                End If

                'estado, código del parcial y valor comercial
                mobjCursoComp.CodEstadoCurso = 4   'comunicado
                mobjCursoComp.CodCursoParcial = mlngCodCurso
                mobjCursoComp.ValorComunicado = mobjCursoComp.ValorMercado
                'correlativo del complemento
                Dim lngMaxCorrelativo As Long
                lngMaxCorrelativo = mobjSql.s_max_correlativo(mobjCursoComp.Agno)
                If lngMaxCorrelativo >= 0 Then
                    mobjCursoComp.Correlativo = lngMaxCorrelativo + 1
                Else
                    mobjCursoComp.Correlativo = 1
                End If

                'Seteo Costos y Montos.
                Call mobjCursoComp.CalcularCostos()
                mobjCursoComp.MontoCtaCap = mobjCursoComp.CostoOtic
                mobjCursoComp.MontoCtaExcCap = 0
                mobjCursoComp.Terceros = dtTerceros
                mobjCursoComp.TotMontoTerc = 0
                'Call mobjCursoCompl.CalcCostoAdm
                mobjCursoComp.CostoAdm = 0

                'Grabar
                Call mobjCursoComp.GrabarDatos()
                Call mobjCursoComp.GrabarHorario()
                'Call mobjCursoCompl.ObtenerInfoCuentas
                mlngCodCursoCompl = mobjCursoComp.CodCurso
                Call mobjCursoComp.GrabarAlumnos()

                Call ActualizarDatos(1)
                'esto no es necesario, así obligamos a repasar los cursos el próximo año
                'blnInic1 = mobjCursoCompl.GrabarInfoCuentas()
                If Not blnInic1 Then
                    GenerarComplementario = False
                    Exit Function
                End If

                GenerarComplementario = True
                Exit Function
            End If
        Catch ex As Exception
            EnviaError("CCurso2:GenerarComplementario-->" & ex.Message)
        End Try
    End Function
    ''generación del complemento de un curso
    'Public Function GenerarComplementario() As Boolean
    '    Try
    '        Dim blnInic1 As Boolean
    '        Dim i, intTamArr As Integer
    '        Dim dtTerceros As DataTable
    '        Dim arrTemp As Object
    '        Dim mobjCursoComp As CCursoContratado

    '        mobjCursoComp = New CCursoContratado
    '        Call mobjCursoComp.Inicializar0(mobjSql, mlngRutUsuario)
    '        blnInic1 = mobjCursoComp.Inicializar1(mlngCodCurso)
    '        If Not blnInic1 Then
    '            GenerarComplementario = False
    '            Exit Function
    '        Else
    '            '
    '            'generar el curso complementario
    '            'Los viáticos y traslados se cargan todos al año actual (del curso parcial)
    '            arrTemp = mobjCursoComp.ObtenerAlumnos
    '            Call ObtenerAlumnos()
    '            intTamArr = TamanoArreglo1(arrTemp)
    '            mobjCursoComp.Agno = mlngAgno + 1
    '            'asignar nro registro
    '            'mobjCursoComp.NroRegistro = mlngNroRegistro
    '            mobjCursoComp.NroRegistro = -1
    '            'Seteo las fechas
    '            mobjCursoComp.FechaInicio = "01/01/" & CStr(mlngAgno + 1)
    '            mdtmFechaTermino = FechaUsrAVb("31/12/" & CStr(mlngAgno))

    '            'Seteo las horas
    '            mobjCursoComp.Horas = mlngHorasCompl
    '            mobjCursoComp.HorasCompl = 0
    '            'Seteo Valor Mercado y Descuento
    '            Dim dblFactorHoras As Double
    '            dblFactorHoras = mlngHorasCompl / (mlngHoras + mlngHorasCompl)
    '            mobjCursoComp.ValorMercado = Math.Round(dblFactorHoras * mlngValorMercado)
    '            If mintIndDescPorc = 0 Then  'si el descuento es en monto
    '                mobjCursoComp.Descuento = Math.Round(dblFactorHoras * mlngDescuento)
    '            End If

    '            'estado, código del parcial y valor comercial
    '            mobjCursoComp.CodEstadoCurso = 4   'comunicado
    '            mobjCursoComp.CodCursoParcial = mlngCodCurso
    '            mobjCursoComp.ValorComunicado = mobjCursoComp.ValorMercado


    '            mlngValorMercado = mlngValorMercado - mobjCursoComp.ValorMercado
    '            mlngValorComunicado = mlngValorMercado

    '            'correlativo del complemento
    '            Dim lngMaxCorrelativo As Long
    '            lngMaxCorrelativo = mobjSql.s_max_correlativo(mobjCursoComp.Agno)
    '            If lngMaxCorrelativo >= 0 Then
    '                mobjCursoComp.Correlativo = lngMaxCorrelativo + 1
    '            Else
    '                mobjCursoComp.Correlativo = 1
    '            End If

    '            'Seteo Costos y Montos.
    '            Call mobjCursoComp.CalcularCostos()
    '            mobjCursoComp.MontoCtaCap = mobjCursoComp.CostoOtic
    '            mobjCursoComp.MontoCtaExcCap = 0
    '            mobjCursoComp.Terceros = dtTerceros
    '            mobjCursoComp.TotMontoTerc = 0
    '            'Call mobjCursoCompl.CalcCostoAdm
    '            mobjCursoComp.CostoAdm = 0

    '            'Grabar
    '            Call mobjCursoComp.GrabarDatos()
    '            Call mobjCursoComp.GrabarHorario()
    '            'Call mobjCursoCompl.ObtenerInfoCuentas
    '            mlngCodCursoCompl = mobjCursoComp.CodCurso
    '            Call mobjCursoComp.GrabarAlumnos()

    '            Call ActualizarDatos(1)
    '            'esto no es necesario, así obligamos a repasar los cursos el próximo año
    '            'blnInic1 = mobjCursoCompl.GrabarInfoCuentas()
    '            If Not blnInic1 Then
    '                GenerarComplementario = False
    '                Exit Function
    '            End If

    '            GenerarComplementario = True
    '            Exit Function
    '        End If
    '    Catch ex As Exception
    '        EnviaError("CCurso2:GenerarComplementario-->" & ex.Message)
    '    End Try
    'End Function
    Public Sub EntregarSolPagoTerc(ByVal objSolicitud As CSolicitud)
        Try
            Dim i, intTamArr, intNroTranSol As Integer

            intTamArr = mcolSolicitudes.Count 'TamanoArreglo1(mcolSolicitudes)

            For i = 0 To intTamArr - 1

                If mcolSolicitudes(i + 1).CodCurso = objSolicitud.CodCurso Then
                    If mcolSolicitudes(i + 1).RutBenefactor = objSolicitud.RutBenefactor Then
                        objSolicitud = mcolSolicitudes(i + 1)
                    End If
                End If
            Next
            intNroTranSol = 0
            For i = 0 To intTamArr - 1
                If mcolSolicitudes(i + 1).CodEstadoSolicitud <> 2 Then
                    intNroTranSol = intNroTranSol + 1
                End If
            Next
            If intNroTranSol > 0 Then
                Call CambiarEstPagoPorAut("")
            Else
                Call CambiarEstIngresado("")
            End If


        Catch ex As Exception
            EnviaError("cCursoContratado:EntregarSolPagoTerc----->" & ex.Message)
        End Try


    End Sub

    'SOLO PARA LA CARGA HISTORICA
    Public Function GenerarParcial() As Boolean
        Try
            Dim blnInic1 As Boolean
            Dim i, intTamArr As Integer
            Dim dtTerceros As DataTable
            Dim arrTemp As Object
            Dim mobjCursoComp As CCursoContratado

            mobjCursoComp = New CCursoContratado
            Call mobjCursoComp.Inicializar0(mobjSql, mlngRutUsuario)
            blnInic1 = mobjCursoComp.Inicializar1(mlngCodCurso)
            If Not blnInic1 Then
                GenerarParcial = False
                Exit Function
            Else
                '
                'generar el curso Parcial
                'Los viáticos y traslados se cargan todos al año anterior (del curso parcial)
                arrTemp = mobjCursoComp.ObtenerAlumnos
                Call ObtenerAlumnos()
                intTamArr = TamanoArreglo1(arrTemp)
                mobjCursoComp.Agno = mlngAgno - 1
                'asignar nro registro
                mobjCursoComp.NroRegistro = mlngNroRegistro
                'Seteo las fechas
                mobjCursoComp.FechaInicio = "01/01/" & CStr(mlngAgno - 1)
                mdtmFechaTermino = FechaUsrAVb("31/12/" & CStr(mlngAgno))

                'Seteo las horas
                mobjCursoComp.Horas = mlngHorasCompl
                mobjCursoComp.HorasCompl = 0
                'Seteo Valor Mercado y Descuento
                Dim dblFactorHoras As Double
                dblFactorHoras = mlngHorasCompl / (mlngHoras + mlngHorasCompl)
                mobjCursoComp.ValorMercado = Math.Round(dblFactorHoras * mlngValorMercado)
                If mintIndDescPorc = 0 Then  'si el descuento es en monto
                    mobjCursoComp.Descuento = Math.Round(dblFactorHoras * mlngDescuento)
                End If

                'estado, código del parcial y valor comercial
                mobjCursoComp.CodEstadoCurso = 4   'comunicado
                mobjCursoComp.CodCursoParcial = mlngCodCurso
                mobjCursoComp.ValorComunicado = mobjCursoComp.ValorMercado
                'correlativo del complemento
                Dim lngMaxCorrelativo As Long
                lngMaxCorrelativo = mobjSql.s_max_correlativo(mobjCursoComp.Agno)
                If lngMaxCorrelativo >= 0 Then
                    mobjCursoComp.Correlativo = lngMaxCorrelativo + 1
                Else
                    mobjCursoComp.Correlativo = 1
                End If

                'Seteo Costos y Montos.
                Call mobjCursoComp.CalcularCostos()
                mobjCursoComp.MontoCtaCap = mobjCursoComp.CostoOtic
                mobjCursoComp.MontoCtaExcCap = 0
                mobjCursoComp.Terceros = dtTerceros
                mobjCursoComp.TotMontoTerc = 0
                'Call mobjCursoCompl.CalcCostoAdm
                mobjCursoComp.CostoAdm = 0

                'Grabar
                Call mobjCursoComp.GrabarDatos()
                Call mobjCursoComp.GrabarHorario()
                'Call mobjCursoCompl.ObtenerInfoCuentas
                mlngCodCursoCompl = mobjCursoComp.CodCurso
                Call mobjCursoComp.GrabarAlumnos()

                Call ActualizarDatos(1)
                'esto no es necesario, así obligamos a repasar los cursos el próximo año
                'blnInic1 = mobjCursoCompl.GrabarInfoCuentas()
                If Not blnInic1 Then
                    GenerarParcial = False
                    Exit Function
                End If

                GenerarParcial = True
                Exit Function
            End If
        Catch ex As Exception
            EnviaError("CCurso2:GenerarComplementario-->" & ex.Message)
        End Try
    End Function
    'verifica si un participante ya hiso el curso este año
    Public Function ExisteAlumnoEnCurso(ByVal lngRutAlumno As Long, ByVal strCodSence As String, _
                                        ByVal intAgno As Integer, ByVal lngRutEmpresa As Long) As Boolean
        mobjSql = New CSql
        Dim existeAlumno As Boolean
        existeAlumno = mobjSql.ExisteAlumnoCursandoCurso(lngRutAlumno, strCodSence, intAgno, lngRutEmpresa)
        Return existeAlumno
    End Function
    ' verifica si el alumno esta repetido para el mismo curso en las mismas fechas
    Public Function ExisteAlumnoEnCurso2(ByVal lngRutAlumno As Long, ByVal strCodSence As String, _
                                        ByVal dtmFechaInicio As Date, ByVal lngRutEmpresa As Long) As Boolean
        mobjSql = New CSql
        Dim existeAlumno As Boolean
        existeAlumno = mobjSql.ExisteAlumnoCursandoCurso2(lngRutAlumno, strCodSence, dtmFechaInicio, lngRutEmpresa)
        Return existeAlumno
    End Function
    Public Sub ActualizaNroParticipante(ByVal lngCodCurso As Long, ByVal intNroParticipante As Integer)
        mobjSql = New CSql
        mobjSql.u_nro_alumno_curso(lngCodCurso, intNroParticipante)
        mobjSql = Nothing
    End Sub
    Public Function CreadorCurso(ByVal lngCodCurso As Long) As String
        mobjSql = New CSql
        Dim strUsuarioCreador As String
        strUsuarioCreador = mobjSql.s_creador_curso(lngCodCurso)
        Return strUsuarioCreador
    End Function
    Public Sub IngresaBitacora(ByVal lngRutUsuario As Long, ByVal strNombreEstadoCurso As String, _
                                ByVal strComentario As String, ByVal lngCodCurso As Long, ByVal lngRutCliente As Long)
        mobjSql = New CSql
        Call mobjSql.i_bitacora(lngRutUsuario, strNombreEstadoCurso, strComentario, 1, lngCodCurso)
        mobjSql = Nothing
    End Sub
    Public Sub IngresaBitacoraComentario(ByVal lngRutUsuario As Long, ByVal strNombreEstadoCurso As String, _
                                ByVal strComentario As String, ByVal lngCodCurso As Long, ByVal lngRutCliente As Long)
        mobjSql = New CSql
        Call mobjSql.i_bitacora(lngRutUsuario, strNombreEstadoCurso, strComentario, 7, lngCodCurso)
        mobjSql = Nothing
    End Sub
    Public Function AlumnosCurso(ByVal lngCodCurso As Long) As DataTable
        mobjSql = New CSql
        Dim dt As DataTable
        dt = mobjSql.s_alumno_curso2(lngCodCurso)
        Return dt
        mobjSql = Nothing
    End Function
    Public Function BitacoraComentario(ByVal lngCodCurso As Long) As DataTable
        mobjSql = New CSql
        Dim dt As DataTable
        dt = mobjSql.s_bitacora_comentario(lngCodCurso)
        Return dt
        mobjSql = Nothing
    End Function
    Public Sub IngresaCertificado(ByVal lngCodCurso As Long)
        mobjSql = New CSql
        mobjSql.u_certificado_asistencia(lngCodCurso)
        mobjSql = Nothing
    End Sub
End Class
