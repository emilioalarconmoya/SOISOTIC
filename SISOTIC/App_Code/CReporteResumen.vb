Imports Clases
Imports modulos
Imports System.data

Public Class CReporteResumen
    Implements IReporte

#Region "Declaraciones"
    Private mobjCcuenta As CCuenta

    'Filtros
    Private mlngRutCliente As Long
    Private mintAgno As Integer
    Private mbolInfoConsolidada As Boolean

    Private mblnEsEmpresaCliente As Boolean

    Private mdblCostoAdministracion As Double
    'Franquicia del período
    'Aportes por enterar (Deuda Total)
    Private mlngAPEcapacitacion As Long
    Private mlngAPEreparto As Long
    Private mlngAPEadministracion As Long
    Private mlngAPEtotal As Long
    'Franquicia Histórica
    Private mlngFHfranquicia As Long
    Private mlngFHsaldo1fecha As Long
    Private mdblFHporcentajeFranquicia As Double
    'Aportes enterados
    Private mlngAEaporte As Long
    Private mlngAEadministracion As Long
    Private mlngAEtotal As Long
    'Gasto Empresa
    Private mlngGEcapacitacion As Long
    Private mlngGEexCapacitacion As Long
    Private mlngGEterceros As Long
    Private mlngGEtotal As Long
    'Cuenta de capacitación
    Private mlngCCabonosXaporte As Long
    Private mlngCCcursosPropios As Long
    Private mlngCCvtCursosPropios As Long
    Private mlngCCvtCursosPropiosAgnoAnterior As Long
    Private mlngCCvtDisponible As Long
    Private mlngCCsaldo As Long
    Private mbolCCMostrarTexto As Boolean
    'Costo Complementario Estimado
    Private mlngCCEcostoOtic As Long
    Private mlngCCEgastoEmpresa As Long
    Private mlngCCEsaldoExdecentes As Long
    Private mintCCEagnoSiguiente As Long
    'Cuenta de reparto
    Private mlngCRabonoXaporte As Long
    Private mlngCRterceros As Long
    Private mlngCRsaldo As Long
    Private mlngCRRecibido As Long
    'Cursos Internos
    Private mlngCIcantCursosInternos As Long
    Private mlngCItotalCursosInternos As Long
    Private mlngCIAlumnosInternosCapacitados As Long
    Private mlngCIAlumnosInternosCapacitadosSR As Long
    'Estadísticas del período
    Private mlngEPcantCursos As Long
    Private mlngEPcantCursosAnulados As Long
    Private mlngEPcantCursosEliminados As Long
    Private mlngEPalumnosCapacitados As Long
    Private mlngEPalumnosCapacitadosSR As Long
    Private mlngEPalumnosCapacitadosCero As Long
    Private mlngEPalumnosCapacitadosSRCero As Long
    Private mlngEPalumnosCapacitadosPresencial As Long
    Private mlngEPalumnosCapacitadosElearning As Long
    Private mlngEPalumnosCapacitadosAutoInstruccion As Long
    Private mlngEPalumnosCapacitadosDistancia As Long

    Private mlngEPhhCapacitacion As Long
    Private mlngEPhhCapacitacionCero As Long
    Private mlngEPhhCapacitacion75 As Long
    Private mdblEPhhParticipantes As Double
    Private mlngEPhhPrecenciales As Double
    Private mlngEPhhElearning As Double
    Private mlngEPhhAutoInduccion As Double
    Private mlngEPhhAdistancia As Double
    'Excedentes del período anterior
    'Cuenta de excedente de capacitación (Totales Generales)
    Private mlngCECAPabonoXsaldo As Long
    Private mlngCECAPsumCursosPropios As Long
    Private mlngCECAPvtCursosPropios As Long
    Private mlngCECAPvtDisponible As Long
    Private mlngCECAPsumSaldos As Long
    'Cuenta de excedente de reparto (Totales Generales)
    Private mlngCERsumAbonoXsaldo As Long
    Private mlngCERsumCursosTerceros As Long
    Private mlngCERvtDisponible As Long
    Private mlngCERsumSaldos As Long
    Private mlngCERRecibido As Long
    'Cuenta de Exc. Congelados 1
    Private mlngCEC1abonoXsaldo As Long
    Private mlngCEC1cursosPagados As Long
    Private mlngCEC1saldo As Long
    'Cuenta de Exc. Congelados 2
    Private mlngCEC2abonoXsaldo As Long
    Private mlngCEC2cursosPagados As Long
    Private mlngCEC2saldo As Long
    'Cuenta becas capacitación
    Private mlngCBCabonosXsaldo As Long
    Private mlngCBCabonoXMandato As Long
    Private mlngCBCcursosComplementarios As Long
    Private mlngCBCdisponible As Long
    'Cuenta Financiamiento Otic
    Private mlngFOaportefinanciamientoOtic As Long
    'Excedentes Congelados 
    'Excedentes Congelados 
    Private mlngCECsaldo1 As Long
    Private mlngCECsaldo2 As Long

    'Otros
    Private mbolMostrarExedido As Boolean
    Private mbolTieneFiliales As Boolean
    Private mbolTieneHoldings As Boolean
    Private mdtFiliales As DataTable
    Private mdtHolding As DataTable

    'Comunes
    Private mobjCsql As New CSql

    Private mdtGraficoTortaCursosSence As DataTable
    Private mbolValMayorAcero As Boolean
    Private mdtGraficoBarraHorasHombre As DataTable
    Private mdtGraficoBarraCostosAnuales As DataTable
    Private mstrNomEjecutivo As String
    Private mstrEmailEjecutivo As String
    Private mstrFonoEjecutivo As String
    Private mlngValorTotalCursos As Long
    Private mlngAportePendienteTotal As Long
    Private mstrRazonSocial As String
    Private mstrFonoCliente As String
    Private mstrFaxCliente As String

#End Region
#Region "Propiedades"
    'Filtros
    Public Property RutClienteCarta() As String
        Get
            Return RutLngAUsr(mlngRutCliente)
        End Get
        Set(ByVal value As String)
            mlngRutCliente = RutLngAUsr(value)
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
    Public Property FonoCliente() As String
        Get
            Return mstrFonoCliente
        End Get
        Set(ByVal value As String)
            mstrFonoCliente = value
        End Set
    End Property
    Public Property FaxCliente() As String
        Get
            Return mstrFaxCliente
        End Get
        Set(ByVal value As String)
            mstrFaxCliente = value
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
    Public ReadOnly Property AportePendienteTotal() As Long
        Get
            Return mlngAportePendienteTotal
        End Get
    End Property
    Public WriteOnly Property Agno() As Integer
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public WriteOnly Property InfoConsolidada() As Integer
        Set(ByVal value As Integer)
            mbolInfoConsolidada = value
        End Set
    End Property
    Public ReadOnly Property CostoAdministracion() As Double
        Get
            Return mdblCostoAdministracion
        End Get
    End Property
    'Franquicia del período
    'Aportes por enterar (Deuda Total)
    Public ReadOnly Property APEcapacitacion() As Long
        Get
            Return mlngAPEcapacitacion
        End Get
    End Property
    Public Property EsEmpresaCliente() As Boolean
        Get
            Return mblnEsEmpresaCliente
        End Get
        Set(ByVal value As Boolean)
            mblnEsEmpresaCliente = value
        End Set
    End Property
    Public ReadOnly Property APEreparto() As Long
        Get
            Return mlngAPEreparto
        End Get
    End Property
    Public ReadOnly Property APEadministracion() As Long
        Get
            Return mlngAPEadministracion
        End Get
    End Property
    Public ReadOnly Property APEtotal() As Long
        Get
            Return mlngAPEtotal
        End Get
    End Property
    'Franquicia Histórica
    Public ReadOnly Property FHfranquicia() As Long
        Get
            Return mlngFHfranquicia
        End Get
    End Property
    Public ReadOnly Property FHsaldo1fecha() As Long
        Get
            Return mlngFHsaldo1fecha
        End Get
    End Property
    Public ReadOnly Property FHporcentajeFranquicia() As Double
        Get
            Return mdblFHporcentajeFranquicia
        End Get
    End Property
    'Aportes enterados
    Public ReadOnly Property AEaporte() As Long
        Get
            Return mlngAEaporte
        End Get
    End Property
    Public ReadOnly Property AEadministracion() As Long
        Get
            Return mlngAEadministracion
        End Get
    End Property
    Public ReadOnly Property AEtotal() As Long
        Get
            Return mlngAEtotal
        End Get
    End Property
    'Gasto Empresa
    Public ReadOnly Property GEcapacitacion() As Long
        Get
            Return mlngGEcapacitacion
        End Get
    End Property
    Public ReadOnly Property GEexCapacitacion() As Long
        Get
            Return mlngGEexCapacitacion
        End Get
    End Property
    Public ReadOnly Property GEterceros() As Long
        Get
            Return mlngGEterceros
        End Get
    End Property
    Public ReadOnly Property GEtotal() As Long
        Get
            Return mlngGEtotal
        End Get
    End Property
    'Cuenta de capacitación
    Public ReadOnly Property CCabonosXaporte() As Long
        Get
            Return mlngCCabonosXaporte
        End Get
    End Property
    Public ReadOnly Property CCcursosPropios() As Long
        Get
            Return mlngCCcursosPropios
        End Get
    End Property
    Public ReadOnly Property CCvtCursosPropios() As Long
        Get
            Return mlngCCvtCursosPropios
        End Get
    End Property
    Public Property CCvtCursosPropiosAgnoAnterior() As Long
        Get
            Return mlngCCvtCursosPropiosAgnoAnterior
        End Get
        Set(ByVal value As Long)
            mlngCCvtCursosPropiosAgnoAnterior = value
        End Set
    End Property
    Public ReadOnly Property CCvtDisponible() As Long
        Get
            Return mlngCCvtDisponible
        End Get
    End Property
    Public ReadOnly Property CCsaldo() As Long
        Get
            Return mlngCCsaldo
        End Get
    End Property
    Public ReadOnly Property CCMostrarTexto() As Boolean
        Get
            Return mbolCCMostrarTexto
        End Get
    End Property
    'Costo Complementario Estimado
    Public ReadOnly Property CCEcostoOtic() As Long
        Get
            Return mlngCCEcostoOtic
        End Get
    End Property
    Public ReadOnly Property CCEgastoEmpresa() As Long
        Get
            Return mlngCCEgastoEmpresa
        End Get
    End Property
    Public ReadOnly Property CCEsaldoExdecentes() As Long
        Get
            Return mlngCCEsaldoExdecentes
        End Get
    End Property
    Public ReadOnly Property CCEagnoSiguiente() As Integer
        Get
            Return mintCCEagnoSiguiente
        End Get
    End Property
    'Cuenta de reparto
    Public ReadOnly Property CRabonoXaporte() As Long
        Get
            Return mlngCRabonoXaporte
        End Get
    End Property
    Public ReadOnly Property CRterceros() As Long
        Get
            Return mlngCRterceros
        End Get
    End Property
    Public ReadOnly Property CRsaldo() As Long
        Get
            Return mlngCRsaldo
        End Get
    End Property
    Public ReadOnly Property CRRecibido() As Long
        Get
            Return mlngCRRecibido
        End Get
    End Property

    'Cursos Internos
    Public ReadOnly Property CIcantCursosInternos() As Long
        Get
            Return mlngCIcantCursosInternos
        End Get
    End Property
    Public ReadOnly Property CItotalCursosInternos() As Long
        Get
            Return mlngCItotalCursosInternos
        End Get
    End Property
    Public ReadOnly Property CIAlumnosInternosCapacitados() As Long
        Get
            Return mlngCIAlumnosInternosCapacitados
        End Get
    End Property
    Public ReadOnly Property CIAlumnosInternosCapacitadosSR() As Long
        Get
            Return mlngCIAlumnosInternosCapacitadosSR
        End Get
    End Property
    'Estadísticas del período
    Public ReadOnly Property EPcantCursos() As Long
        Get
            Return mlngEPcantCursos
        End Get
    End Property
    Public ReadOnly Property EPcantCursosAnulados() As Long
        Get
            Return mlngEPcantCursosAnulados
        End Get
    End Property
    Public ReadOnly Property EPcantCursosEliminados() As Long
        Get
            Return mlngEPcantCursosEliminados
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitados() As Long
        Get
            Return mlngEPalumnosCapacitados
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitadosSR() As Long
        Get
            Return mlngEPalumnosCapacitadosSR
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitadosCero() As Long
        Get
            Return mlngEPalumnosCapacitadosCero
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitadosSRCero() As Long
        Get
            Return mlngEPalumnosCapacitadosSRCero
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitadosPresencial() As Long
        Get
            Return mlngEPalumnosCapacitadosPresencial
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitadosElearning() As Long
        Get
            Return mlngEPalumnosCapacitadosElearning
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitadosAutoInstruccion() As Long
        Get
            Return mlngEPalumnosCapacitadosAutoInstruccion
        End Get
    End Property
    Public ReadOnly Property EPalumnosCapacitadosDistancia() As Long
        Get
            Return mlngEPalumnosCapacitadosDistancia
        End Get
    End Property

    Public ReadOnly Property EPhhCapacitacion() As Long
        Get
            Return mlngEPhhCapacitacion
        End Get
    End Property
    Public ReadOnly Property EPhhCapacitacionCero() As Long
        Get
            Return mlngEPhhCapacitacionCero
        End Get
    End Property
    Public ReadOnly Property EPhhCapacitacion75() As Long
        Get
            Return mlngEPhhCapacitacion75
        End Get
    End Property
    Public ReadOnly Property EPhhParticipantes() As Double
        Get
            Return mdblEPhhParticipantes
        End Get
    End Property
    Public ReadOnly Property EPhhPrecenciales() As Double
        Get
            Return mlngEPhhPrecenciales
        End Get
    End Property
    Public ReadOnly Property EPhhElearning() As Double
        Get
            Return mlngEPhhElearning
        End Get
    End Property
    Public ReadOnly Property EPhhAutoInduccion() As Double
        Get
            Return mlngEPhhAutoInduccion
        End Get
    End Property
    Public ReadOnly Property EPhhAdistancia() As Double
        Get
            Return mlngEPhhAdistancia
        End Get
    End Property
    'Cuenta de excedente de capacitaci&oacute;n (Totales Generales)
    Public ReadOnly Property CECAPabonoXsaldo() As Long
        Get
            Return mlngCECAPabonoXsaldo
        End Get
    End Property 
    Public ReadOnly Property CECAPsumCursosPropios() As Long
        Get
            Return mlngCECAPsumCursosPropios
        End Get
    End Property 
    Public ReadOnly Property CECAPvtCursosPropios() As Long
        Get
            Return mlngCECAPvtCursosPropios
        End Get
    End Property 
    Public ReadOnly Property CECAPvtDisponible() As Long
        Get
            Return mlngCECAPvtDisponible
        End Get
    End Property 
    Public ReadOnly Property CECAPsumSaldos() As Long
        Get
            Return mlngCECAPsumSaldos
        End Get
    End Property
    'Excedentes del período anterior
    'Cuenta de excedente de reparto (Totales Generales)
    Public ReadOnly Property CERsumAbonoXsaldo() As Long
        Get
            Return mlngCERsumAbonoXsaldo
        End Get
    End Property
    Public ReadOnly Property CERsumCursosTerceros() As Long
        Get
            Return mlngCERsumCursosTerceros
        End Get
    End Property
    Public ReadOnly Property CERvtDisponible() As Long
        Get
            Return mlngCERvtDisponible
        End Get
    End Property
    Public ReadOnly Property CERsumSaldos() As Long
        Get
            Return mlngCERsumSaldos
        End Get
    End Property
    Public ReadOnly Property CERRecibido() As Long
        Get
            Return mlngCERRecibido
        End Get
    End Property
    'Cuenta de Exc. Congelados 1
    Public ReadOnly Property CEC1abonoXsaldo() As Long
        Get
            Return mlngCEC1abonoXsaldo
        End Get
    End Property
    Public ReadOnly Property CEC1cursosPagados() As Long
        Get
            Return mlngCEC1cursosPagados
        End Get
    End Property
    Public ReadOnly Property CEC1saldo() As Long
        Get
            Return mlngCEC1saldo
        End Get
    End Property
    'Cuenta de Exc. Congelados 2
    Public ReadOnly Property CEC2abonoXsaldo() As Long
        Get
            Return mlngCEC2abonoXsaldo
        End Get
    End Property
    Public ReadOnly Property CEC2cursosPagados() As Long
        Get
            Return mlngCEC2cursosPagados
        End Get
    End Property
    Public ReadOnly Property CEC2saldo() As Long
        Get
            Return mlngCEC2saldo
        End Get
    End Property
    'Cuenta becas capacitación 
    Public ReadOnly Property CBCabonosXsaldo() As Long
        Get
            Return mlngCBCabonosXsaldo
        End Get
    End Property 
    Public ReadOnly Property CBCcursosComplementarios() As Long
        Get
            Return mlngCBCcursosComplementarios
        End Get
    End Property 
    Public ReadOnly Property CBCdisponible() As Long
        Get
            Return mlngCBCdisponible
        End Get
    End Property
    Public ReadOnly Property CBCabonoXMandato() As Long
        Get
            Return mlngCBCabonoXMandato
        End Get
    End Property
    'Cuenta Financiamiento Otic
    Public ReadOnly Property FOaportefinanciamientoOtic() As Long
        Get
            Return mlngFOaportefinanciamientoOtic
        End Get
    End Property
    'Excedentes Congelados 
    'Excedentes Congelados 
    Public ReadOnly Property CECsaldo1() As Long
        Get
            Return mlngCECsaldo1
        End Get
    End Property
    Public ReadOnly Property CECsaldo2() As Long
        Get
            Return mlngCECsaldo2
        End Get
    End Property

    'Otros
    Public ReadOnly Property MostrarExedido() As Long
        Get
            Return mbolMostrarExedido
        End Get
    End Property
    Public ReadOnly Property TieneFiliales() As Boolean
        Get
            Return mbolTieneFiliales
        End Get
    End Property
    Public ReadOnly Property TieneHoldings() As Boolean
        Get
            Return mbolTieneHoldings
        End Get
    End Property
    Public ReadOnly Property Filiales() As DataTable
        Get
            Return mdtFiliales
        End Get
    End Property
    Public ReadOnly Property Holdings() As DataTable
        Get
            Return mdtHolding
        End Get
    End Property
    'Comunes
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get

        End Get
    End Property
    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get

        End Get
    End Property
    Public ReadOnly Property GraficoTortaCursosSence() As DataTable
        Get
            Return mdtGraficoTortaCursosSence
        End Get
    End Property
    Public ReadOnly Property ValMayorAcero() As Boolean
        Get
            Return mbolValMayorAcero
        End Get
    End Property
    Public ReadOnly Property GraficoBarraHorasHombre() As DataTable
        Get
            Return mdtGraficoBarraHorasHombre
        End Get
    End Property
    Public ReadOnly Property GraficoBarraCostosAnuales() As DataTable
        Get
            Return mdtGraficoBarraCostosAnuales
        End Get
    End Property
    Public ReadOnly Property ValorTotalCursos() As Long
        Get
            Return mlngValorTotalCursos
        End Get
    End Property

    Public ReadOnly Property NombreEjecutivo() As String
        Get
            Return mstrNomEjecutivo
        End Get
    End Property


    'Email Ejecutivo
    Public ReadOnly Property EmailEjecutivo() As String
        Get
            Return mstrEmailEjecutivo
        End Get
    End Property

    'teléfono del ejecutivo
    Public ReadOnly Property FonoEjecutivo() As String
        Get
            Return mstrFonoEjecutivo
        End Get
    End Property
#End Region


    Public Sub inicializar()
        'Filtros
        mlngRutCliente = 0
        mintAgno = 0

        mdblCostoAdministracion = 0.0
        'Franquicia del período
        'Aportes por enterar (Deuda Total)
        mlngAPEcapacitacion = 0
        mlngAPEreparto = 0
        mlngAPEadministracion = 0
        mlngAPEtotal = 0
        'Franquicia Histórica
        mlngFHfranquicia = 0
        mlngFHsaldo1fecha = 0
        'Aportes enterados
        mlngAEaporte = 0
        mlngAEadministracion = 0
        mlngAEtotal = 0
        'Gasto Empresa
        mlngGEcapacitacion = 0
        mlngGEexCapacitacion = 0
        mlngGEterceros = 0
        mlngGEtotal = 0
        'Cuenta de capacitación
        mlngCCabonosXaporte = 0
        mlngCCcursosPropios = 0
        mlngCCvtCursosPropios = 0
        mlngCCvtDisponible = 0
        mlngCCsaldo = 0
        mbolCCMostrarTexto = False
        'Costo Complementario Estimado
        mlngCCEcostoOtic = 0
        mlngCCEgastoEmpresa = 0
        mlngCCEsaldoExdecentes = 0
        mintCCEagnoSiguiente = 0
        'Cuenta de reparto
        mlngCRabonoXaporte = 0
        mlngCRterceros = 0
        mlngCRsaldo = 0
        mlngCRRecibido = 0
        'Cursos Internos
        mlngCIcantCursosInternos = 0
        mlngCItotalCursosInternos = 0
        'Estadísticas del período
        mlngEPcantCursos = 0
        mlngEPcantCursosAnulados = 0
        mlngEPcantCursosEliminados = 0
        mlngEPalumnosCapacitados = 0

        mlngEPalumnosCapacitadosSR = 0
        mlngEPalumnosCapacitadosCero = 0

        mlngEPalumnosCapacitadosSRCero = 0
        mlngEPalumnosCapacitadosPresencial = 0
        mlngEPalumnosCapacitadosElearning = 0
        mlngEPalumnosCapacitadosAutoInstruccion = 0
        mlngEPalumnosCapacitadosDistancia = 0

        mlngEPhhCapacitacion = 0
        mlngEPhhCapacitacionCero = 0
        mlngEPhhCapacitacion75 = 0
        mdblEPhhParticipantes = 0.0
        mlngEPhhPrecenciales = 0
        mlngEPhhElearning = 0
        mlngEPhhAutoInduccion = 0
        mlngEPhhAdistancia = 0
        'Excedentes del período anterior
        'Cuenta de excedente de capacitación (Totales Generales)
        mlngCECAPabonoXsaldo = 0
        mlngCECAPsumCursosPropios = 0
        mlngCECAPvtCursosPropios = 0
        mlngCECAPvtDisponible = 0
        mlngCECAPsumSaldos = 0
        'Cuenta de excedente de reparto (Totales Generales)
        mlngCERsumAbonoXsaldo = 0
        mlngCERsumCursosTerceros = 0
        mlngCERvtDisponible = 0
        mlngCERsumSaldos = 0
        mlngCERRecibido = 0
        'Cuenta de Exc. Congelados 1
        mlngCEC1abonoXsaldo = 0
        mlngCEC1cursosPagados = 0
        mlngCEC1saldo = 0
        'Cuenta de Exc. Congelados 2
        mlngCEC2abonoXsaldo = 0
        mlngCEC2cursosPagados = 0
        mlngCEC2saldo = 0
        'Cuenta becas capacitación
        mlngCBCabonosXsaldo = 0
        mlngCBCcursosComplementarios = 0
        mlngCBCdisponible = 0
        'Cuenta Financiamiento Otic
        mlngFOaportefinanciamientoOtic = 0
        'Excedentes Congelados
        mlngCECsaldo1 = 0
        mlngCECsaldo2 = 0

        mbolValMayorAcero = False
    End Sub

   

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim objCliente As New CCliente
            Dim objClienteInfo As New CClienteInfo
            objCliente.Inicializar0(mobjCsql, Me.mlngRutCliente)
            objCliente.Agno = Me.mintAgno
            objCliente.InfoConsolidada = mbolInfoConsolidada
            objCliente.Inicializar1(RutLngAUsr(Me.mlngRutCliente))



            mdtFiliales = objCliente.Filiales
            mdtHolding = objCliente.Holdings
            mbolTieneFiliales = objCliente.TieneFiliales
            mbolTieneHoldings = objCliente.TieneHoldings

            mdblCostoAdministracion = objCliente.CostoAdm

            Dim lngAdministracionGastada As Long = objCliente.ObjCuentaAdm.SumaCargoCursos

            Dim dblAdm As Double = objCliente.CostoAdm / 100
            'APE
            Me.mlngAPEcapacitacion = objCliente.AportePendienteCap
            Me.mlngAPEreparto = objCliente.AportePendienteRep
            Me.mlngAPEadministracion = ((objCliente.AportePendienteCap + objCliente.AportePendienteRep) * 100 * CDbl(dblAdm)) / (100 - objCliente.AdmNoLineal * (100 * CDbl(dblAdm)))
            '((objCliente.AportePendienteCap + objCliente.AportePendienteRep) * CDbl(objCliente.CostoAdm)) / (100 - CDbl(objCliente.CostoAdm))
            Me.mlngAPEtotal = Me.mlngAPEcapacitacion + Me.mlngAPEreparto + Me.mlngAPEadministracion
            'AE
            Me.mlngAEtotal = objCliente.AportePendienteCap + objCliente.AportePendienteRep + mlngAPEadministracion

            'Me.mlngAEaporte = objCliente.ObjCuentaCap.SumaAporte + objCliente.ObjCuentaRep.SumaAporte + objCliente.ObjCuentaAdm.SumaAporte
            Me.mlngAEaporte = objCliente.ObjCuentaCap.AporteTotal
            Me.mlngAEadministracion = objCliente.ObjCuentaAdm.SumaAporte
            Me.mlngAEtotal = objCliente.ObjCuentaCap.SumaAporte + objCliente.ObjCuentaRep.SumaAporte
            'CC
            Me.mlngCCabonosXaporte = objCliente.ObjCuentaCap.SumaAporte
            Me.mlngCCcursosPropios = objCliente.ObjCuentaCap.SumaCargoCursos
            Me.mlngCCvtDisponible = objCliente.DisponibleVTCap

            'Me.mlngCCvtDisponible = CLng(mlngAEaporte * 0.1)
            Me.mlngCCvtCursosPropios = objCliente.ObjCuentaCap.SumaCargoVyT
            Me.mlngCCvtCursosPropiosAgnoAnterior = objCliente.ObjCuentaCap.SumavtCursosPropiosAgnoAnterior
            Me.mlngCCsaldo = objCliente.ObjCuentaCap.SumaSaldoPend
            If objCliente.ObjCuentaCap.SumaSaldoPend > 0 Then
                mbolCCMostrarTexto = True
            End If
            'CR
            Me.mlngCRabonoXaporte = objCliente.ObjCuentaRep.SumaAporte
            Me.mlngCRterceros = objCliente.ObjCuentaRep.SumaCargoCursos
            Me.mlngCRsaldo = objCliente.ObjCuentaRep.SumaSaldoPend
            Me.mlngCRRecibido = objCliente.ObjCuentaRep.SumaRepartoRecibido
            'CI
            Me.mlngCIcantCursosInternos = objCliente.ObjInfoAdicional.CantCursosInternos
            Me.mlngCItotalCursosInternos = objCliente.ObjInfoAdicional.TotalCursosInternos
            Me.mlngCIAlumnosInternosCapacitados = objCliente.ObjInfoAdicional.AlumnosInternosCapacitados
            Me.mlngCIAlumnosInternosCapacitadosSR = objCliente.ObjInfoAdicional.AlumnosInternosCapacitadosSR
            'FH
            Me.mlngFHfranquicia = objCliente.ObjInfoAdicional.FranquiciaActual
            Me.mlngFHsaldo1fecha = objCliente.SaldoFranquicia
            'GE
            Me.mlngGEcapacitacion = objCliente.ObjInfoAdicional.GastoEmpresaCap
            Me.mlngGEexCapacitacion = objCliente.ObjInfoAdicional.GastoEmpresaExcCap
            Me.mlngGEterceros = objCliente.ObjInfoAdicional.GastoEmpresaTerceros
            Me.mlngGEtotal = objCliente.ObjInfoAdicional.GastoEmpresaAcumulado
            'CCE
            Me.mlngCCEcostoOtic = objCliente.ObjInfoAdicional.CostoOticComplementario
            Me.mlngCCEgastoEmpresa = objCliente.ObjInfoAdicional.GastoEmpresaComplementario
            Me.mlngCCEsaldoExdecentes = (objCliente.ObjCuentaExcCap.SumaSaldoPend + objCliente.ObjCuentaExcRep.SumaSaldoPend)
            Me.mintCCEagnoSiguiente = objCliente.AgnoSiguiente
            'EP
            Me.mlngEPcantCursos = objCliente.ObjInfoAdicional.CantidadDeCursos
            Me.mlngEPcantCursosAnulados = objCliente.ObjInfoAdicional.CantidadDeCursosAnulados
            Me.mlngEPcantCursosEliminados = objCliente.ObjInfoAdicional.CantidadDeCursosEliminados
            Me.mlngEPalumnosCapacitados = objCliente.ObjInfoAdicional.AlumnosCapacitados
            mlngEPalumnosCapacitadosSR = objCliente.ObjInfoAdicional.AlumnosCapacitadosSR

            Me.mlngEPalumnosCapacitadosCero = objCliente.ObjInfoAdicional.AlumnosCapacitadosCero
            mlngEPalumnosCapacitadosSRCero = objCliente.ObjInfoAdicional.AlumnosCapacitadosSRCero

            mlngEPalumnosCapacitadosPresencial = objCliente.ObjInfoAdicional.AlumnosCapacitadosPresencial
            mlngEPalumnosCapacitadosElearning = objCliente.ObjInfoAdicional.AlumnosCapacitadosElearning
            mlngEPalumnosCapacitadosAutoInstruccion = objCliente.ObjInfoAdicional.AlumnosCapacitadosAutoInstruccion
            mlngEPalumnosCapacitadosDistancia = objCliente.ObjInfoAdicional.AlumnosCapacitadosDistancia



            Me.mlngEPhhCapacitacion = objCliente.ObjInfoAdicional.HorasHombreDeCapacitacion
            Me.mlngEPhhCapacitacionCero = objCliente.ObjInfoAdicional.HorasHombreDeCapacitacionCero
            Me.mlngEPhhCapacitacion75 = objCliente.ObjInfoAdicional.HorasHombreDeCapacitacion75
            Me.mdblEPhhParticipantes = Math.Round(objCliente.ObjInfoAdicional.PromHorasParticipantes, 1)
            'Me.mdblEPhhParticipantes = objCliente.ObjInfoAdicional.PromHorasParticipantes
            Me.mlngEPhhPrecenciales = objCliente.ObjInfoAdicional.SumaHorasPresencial
            Me.mlngEPhhElearning = objCliente.ObjInfoAdicional.SumaHorasElearning
            Me.mlngEPhhAutoInduccion = objCliente.ObjInfoAdicional.SumaHorasAutoInstruccion
            Me.mlngEPhhAdistancia = objCliente.ObjInfoAdicional.SumaHorasAdistancia
            'CECAP
            Me.mlngCECAPabonoXsaldo = objCliente.ObjCuentaExcCap.SumaAporte
            Me.mlngCECAPsumCursosPropios = objCliente.ObjCuentaExcCap.SumaCargoCursos
            Me.mlngCECAPvtCursosPropios = objCliente.ObjCuentaExcCap.SumaCargoVyT
            If objCliente.DisponibleVTExcCap < (objCliente.ObjCuentaExcCap.SumaAporte * 0.1) Then
                Me.mlngCECAPvtDisponible = (objCliente.DisponibleVTExcCap)
            Else
                Me.mlngCECAPvtDisponible = (objCliente.ObjCuentaExcCap.SumaAporte * 0.1)
            End If

            'If objCliente.DisponibleVTExcCap > (objCliente.ObjCuentaExcCap.SumaAporte * 0.1) Then
            '    Me.mlngCECAPvtDisponible = (objCliente.DisponibleVTExcCap)
            'Else
            '    Me.mlngCECAPvtDisponible = (objCliente.ObjCuentaExcCap.SumaAporte * 0.1)
            'End If

            Me.mlngCECAPsumSaldos = objCliente.ObjCuentaExcCap.SumaSaldoPend
            'CER
            Me.mlngCERsumAbonoXsaldo = objCliente.ObjCuentaExcRep.SumaAporte
            Me.mlngCERsumCursosTerceros = objCliente.ObjCuentaExcRep.SumaCargoCursos
            Me.mlngCERvtDisponible = objCliente.DisponibleVTExcRep
            Me.mlngCERsumSaldos = objCliente.ObjCuentaExcRep.SumaSaldoPend
            Me.mlngCERRecibido = objCliente.ObjCuentaRep.SumaExcRepartoRecibido
            'CEC1
            Me.mlngCEC1abonoXsaldo = objCliente.SaldoInicialCong2008
            Me.mlngCEC1cursosPagados = objCliente.SaldoCargosCong2008
            Me.mlngCEC1saldo = objCliente.SaldoFinalCong2008
            'CEC2
            Me.mlngCEC2abonoXsaldo = objCliente.SaldoInicialCong2009
            Me.mlngCEC2cursosPagados = objCliente.SaldoCargosCong2009
            Me.mlngCEC2saldo = objCliente.SaldoFinalCong2009
            'CBC
            Me.mlngCBCabonosXsaldo = objCliente.ObjCuentaBecas.SaldoActual 'objCliente.ObjInfoAdicional.SumaAbonosAporteBecas
            Me.mlngCBCcursosComplementarios = objCliente.ObjCuentaBecas.SumaCargoCursos
            Me.mlngCBCdisponible = objCliente.ObjCuentaBecas.SaldoActual + objCliente.ObjCuentaBecas.SumaAbonoXMandato
            Me.mlngCBCabonoXMandato = objCliente.ObjCuentaBecas.SumaAbonoXMandato
            'FO
            Me.mlngFOaportefinanciamientoOtic = objCliente.ObjCuentaFinanciamientoOtic.SaldoActual
            'CEC
            Me.mlngCECsaldo1 = objCliente.ObjCuentaExcCon2008.SaldoActual
            Me.mlngCECsaldo2 = objCliente.ObjCuentaExcCon2009.SaldoActual

            If objCliente.SaldoFranquicia < 0 Then
                mbolMostrarExedido = True
            Else
                mbolMostrarExedido = False
            End If
            mdblFHporcentajeFranquicia = objCliente.SaldoFranquiciaPorc

            mlngAportePendienteTotal = objCliente.AportePendienteTotal

            mstrRazonSocial = objCliente.RazonSocial
            mstrFonoCliente = objCliente.Fono2Otec
            mstrFaxCliente = objCliente.Fax


            

            Dim dt As DataTable
            dt = New DataTable
            dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("Monto", GetType(Long)))


            dt.TableName = "Detalle"
            Dim dr As DataRow
            dr = dt.NewRow()
            dr("Descripcion") = "Cursos Sence "
            dr("Monto") = mlngCCcursosPropios + mlngCECAPsumCursosPropios + mlngCBCcursosComplementarios
            dt.Rows.Add(dr)
            If (mlngCCcursosPropios + mlngCECAPsumCursosPropios + mlngCBCcursosComplementarios) > 0 Then
                mbolValMayorAcero = True
            End If
            dr = dt.NewRow()
            dr("Descripcion") = "Cursos Sence Terceros"
            dr("Monto") = mlngCERsumCursosTerceros + mlngCRterceros
            dt.Rows.Add(dr)
            If (mlngCERsumCursosTerceros + mlngCRterceros) > 0 Then
                mbolValMayorAcero = True
            End If
            dr = dt.NewRow()
            dr("Descripcion") = "Administración"
            dr("Monto") = lngAdministracionGastada
            dt.Rows.Add(dr)
            If (lngAdministracionGastada) > 0 Then
                mbolValMayorAcero = True
            End If
            dr = dt.NewRow()
            dr("Descripcion") = "Cursos No Sence"
            dr("Monto") = mlngCItotalCursosInternos
            dt.Rows.Add(dr)
            If (mlngCItotalCursosInternos) > 0 Then
                mbolValMayorAcero = True
            End If
            mdtGraficoTortaCursosSence = dt
            Me.mdtGraficoBarraHorasHombre = objCliente.ObjInfoAdicional.HorasHombreAgno
            mdtGraficoBarraCostosAnuales = objCliente.ObjInfoAdicional.CostosAnuales
            mstrNomEjecutivo = objCliente.NombreEjecutivo
            mstrEmailEjecutivo = objCliente.EmailEjecutivo
            mstrFonoEjecutivo = objCliente.FonoEjecutivo
            mlngValorTotalCursos = objCliente.ObjInfoAdicional.CostosTotalesCursos
        Catch ex As Exception
            EnviaError("CReporteResumen:Consultar-->" & ex.Message)
        End Try
    End Function

    Public Sub DeudaConsolidada(ByVal dtfiliales As DataTable, ByVal intAgno As Integer)
        Try

            Dim objSql As New CSql
            Dim dr As DataRow
            Dim lngDeuda As Long = 0
            Dim lngDeudaAdm As Long = 0
            Dim lngSaldo As Long = 0
            Dim dt As DataTable
            For Each dr In dtfiliales.Rows
                dt = objSql.s_deuda_consolidada_por_rut(dr("RutFilial"), intAgno)


                If CLng(dt.Rows(0)("deuda_cap_rep")) < 0 Then
                    lngDeuda = lngDeuda + CLng(dt.Rows(0)("deuda_cap_rep"))
                    lngDeudaAdm = lngDeudaAdm + ((dt.Rows(0)("deuda_cap_rep")) * 100 * CDbl(dt.Rows(0)("costo_admin"))) / (100 - dt.Rows(0)("comp_adm_no_lineal") * (100 * CDbl(dt.Rows(0)("costo_admin"))))
                Else
                    lngSaldo = lngSaldo + CLng(dt.Rows(0)("deuda_cap_rep"))
                End If



            Next

            mlngAPEcapacitacion = lngDeuda
            mlngAPEadministracion = lngDeudaAdm
            mlngCCsaldo = lngSaldo

        Catch ex As Exception
            EnviaError("CReporteResumen:DeudaConsolidada-->" & ex.Message)
        End Try



    End Sub

End Class
