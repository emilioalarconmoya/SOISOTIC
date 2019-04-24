Imports Clases
Imports Modulos
Imports System.Data

Public Class CCliente

    'Rut del cliente sin formato
    Private mlngRut As Long
    'Rut Representante1 con Formato
    Private mstrRutRep1Formato As String
    'Rut Representante2 con Formato
    Private mstrRutRep2Formato As String
    'Digito Verificador del cliente
    Private mstrDigitoOtec As String
    'Nombre Fantasia empresa
    Private mstrNomFantasia As String
    'Razon Social
    Private mstrRazonSocial As String
    'Sigla
    Private mstrSigla As String
    'Email cliente
    Private mstrEmailOtec As String
    'Fono empresa
    Private mstrFonoOtec As String
    'Fono 2 empresa
    Private mstrFono2Otec As String
    'Fax empresa
    Private mstrFax As String
    'direccion
    Private mstrDireccion As String
    'codigo comuna
    Private mlngCodComuna As Long
    'nombre comuna
    Private mstrComuna As String
    'codigo region
    Private mlngCodRegion As Long
    'nombre region
    Private mstrRegion As String
    'casilla
    Private mstrCasilla As String
    'ciudad
    Private mstrCiudad As String
    'sitio web
    Private mstrSitioWeb As String
    'Costo administracion
    Private mdblCostoAdm As Double
    'no lineal
    Private mintCompAdmNoLineal As Integer
    'codigo rubro
    Private mintCodRubro As Integer
    'Codigo del estado del cliente
    Private mintCodEstadoCliente As Integer
    'nombre rubro
    Private mstrRubro As String
    'numero empleados
    Private mlngNumempleados As Long
    'Nombre Contacto
    Private mlngRutContacto As Long
    Private mstrApellidoContacto As String
    Private mstrContacto As String
    'Cargo Contacto
    Private mstrCargo As String
    'Fono Contacto
    Private mstrFonoContacto As String
    'Anexo Contacto
    Private mstrAnexoContacto As String
    'Email Contacto
    Private mstrEmailContacto As String
    'Nombre Representante1
    Private mstrRep1 As String
    'Rut Representante1
    Private mlngRutRep1 As Long
    'Digito Verificador Representante1
    Private mstrDigitoRep1 As String
    'Nombre Representante2
    Private mstrRep2 As String
    'Rut Representante2
    Private mlngRutRep2 As Long
    'Digito Verificador Representante2
    Private mstrDigitoRep2 As String
    'gerente general
    Private mstrGerenteGral As String
    'gerente recursos humanos
    Private mstrGerenteRRHH As String
    'Email Gerente recursos humanos
    Private mstrEmailGteRRHH As String
    'gerente Finanzas
    Private mstrGerenteFinanzas As String
    'Email Gerente Finanzas
    Private mstrEmailGteFinanzas As String
    'area cobranzas
    Private mstrAreaCobranzas As String
    'Fono gerente cobranzas o area cobranzas
    Private mstrFonoCobranzas As String
    'giro
    Private mstrGiro As String
    'codigo actividad economica
    Private mstrCodActEconomica As String
    'rut ejecutivo
    Private mlngRutEjecutivo As Long
    'Nombres ejecutivo
    Private mstrNomEjecutivo As String
    'Email Ejecutivo
    Private mstrEmailEjecutivo As String
    'Teléfono y fax del Ejecutivo
    Private mstrFonoEjecutivo As String
    Private mstrFaxEjecutivo As String
    'Codigo Sucursal o Filial
    Private mintCodSucursal As Long
    'Nombre Sucursal o Filial
    Private mstrSucursal As String
    'Venta Anual
    Private mlngVentaAnual As Long
    'Rut holding
    Private mlngRutHolding As Long
    'Observación Cambios efectuados
    Private mstrObservacion As String
    'arreglo para el lookup de comunas
    Private mdtLookUpComunas As DataTable
    'arreglo para el lookup de regiones
    Private mdtLookUpRegiones As DataTable
    'arreglo para el lookup de rubros
    Private mdtLookUpRubros As DataTable
    'arreglo para el lookup de Administracion no Lineal
    Private mdtLookUpAdmNoLineal As DataTable
    'arreglo para el lookup de Estado de Clientes
    Private mdtLookUpEstadoCliente As DataTable
    'arreglo para el lookup de ejecutivos
    Private mdtLookUpEjecutivos As DataTable
    'curso
    Public thecCurso As CCurso
    'Cuenta Capacitacion
    Private mobjCuentaCap As CCuenta
    'Cuenta Reparto
    Private mobjCuentaRep As CCuenta
    'Cuenta Administracion
    Private mobjCuentaAdm As CCuenta
    'Cuenta Excedentes de Capacitacion
    Private mobjCuentaExcCap As CCuenta
    'Cuenta Excedentes de Reparto
    Private mobjCuentaExcRep As CCuenta
    'Cuenta Becas, excedentes de 2 años
    Private mobjCuentaBecas As CCuenta
    'Cuenta Financiamiento Otic
    Private mObjCuentaFinanciamientoOtic As CCuenta
    'Cuenta Certificacion de competencias laborales
    Private mObjCuentaCertificacion As CCuenta
    'Cuenta Excedentes Certificacion de competencias laborales
    Private mObjCuentaExcCertificacion As CCuenta
    'Cuenta temporal excedentes congelados 2008
    Private mObjCuentaExcCon2008 As CCuenta
    'Cuenta temporal excedentes congelados 2009
    Private mObjCuentaExcCon2009 As CCuenta
    'arreglo datos ejecutivo de un cliente
    Private mdtEjecutivos As DataTable
    'Arreglo para el lookup de sucursales existentes
    Private mdtLookUpSucursales As DataTable
    'deuda pendiente con CST
    Private mlngAportePendCap As Long
    Private mlngAportePendRep As Long
    Private mlngAportePendAdm As Long
    'objeto csql
    Private mobjSql As CSql
    'rut del usuario conectado
    Private mlngRutUsuario As Long
    'Año siguiente al actual
    Private mintAgnoSiguiente As Integer
    'información adicional de un cliente
    Private mobjInfoCliente As CClienteInfo
    'información consolidada
    Private mblnInfoConsolidada As Boolean
    'listado de filiales
    Private mdtFiliales As DataTable
    'lista de ruts de filiales, separados por coma
    Private mstrListaRutsHolding As String
    'listado de holdings (empresas madre)
    Private mdtHoldings As DataTable
    'Año de consulta
    Private mintAgno As Integer
    'nro direccion
    Private mstrNroDireccion As String
    'objeto con los aportes del cliente (certificado de aportes)
    Private mobjAportes As CClienteAportes
    Private mlngDisponibleVTCap As Long
    Private mlngDisponibleVTExcCap As Long
    Private mlngDisponibleVTExcRep As Long
    Private mstrClaveWebService As String
    Private mstrEtiquetaClasificador As String
    Private mdblSaldoInicialCong2008 As Double
    Private mdblSaldoCargosCong2008 As Double
    Private mdblSaldoFinalCong2008 As Double
    Private mdblSaldoInicialCong2009 As Double
    Private mdblSaldoCargosCong2009 As Double
    Private mdblSaldoFinalCong2009 As Double


    'Retorna un datatable con los ejecutivos asociados a una empresa(cliente)
    Public ReadOnly Property Ejecutivos() As DataTable
        Get
            Return mdtEjecutivos
        End Get
    End Property


    'Información adicional de clientes
    Public ReadOnly Property ObjInfoAdicional() As CClienteInfo
        Get
            If mobjInfoCliente Is Nothing Then
                mobjInfoCliente = New CClienteInfo
                mobjInfoCliente.Inicializar(mobjSql, mlngRut, mobjCuentaCap.SumaCargo, _
                                            mobjCuentaExcCap.SumaCargo, mstrListaRutsHolding, mintAgno)
            End If
            Return mobjInfoCliente
        End Get
    End Property

    'Cuenta Capacitacion
    Public ReadOnly Property ObjCuentaCap() As CCuenta
        Get
            Return mobjCuentaCap
        End Get
    End Property
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    'Public ReadOnly Property RutUsuario() As Long
    '    Get
    '        Return mlngRutUsuario
    '    End Get
    'End Property
    'Cuenta Reparto
    Public ReadOnly Property ObjCuentaRep() As CCuenta
        Get
            Return mobjCuentaRep
        End Get
    End Property
    'Cuenta Administracion
    Public ReadOnly Property ObjCuentaAdm() As CCuenta
        Get
            Return mobjCuentaAdm
        End Get
    End Property

    'Cuenta Excedentes de Capacitacion
    Public ReadOnly Property ObjCuentaExcCap() As CCuenta
        Get
            Return mobjCuentaExcCap
        End Get
    End Property
    'Cuenta Excedentes de Reparto
    Public ReadOnly Property ObjCuentaExcRep() As CCuenta
        Get
            Return mobjCuentaExcRep
        End Get
    End Property

    'Cuenta Beca (excedentes 2 años)
    Public ReadOnly Property ObjCuentaBecas() As CCuenta
        Get
            Return mobjCuentaBecas
        End Get
    End Property


    'Cuenta Financiamiento Otic
    Public ReadOnly Property ObjCuentaFinanciamientoOtic() As CCuenta
        Get
            Return mObjCuentaFinanciamientoOtic
        End Get
    End Property

    'Cuenta Financiamiento Otic
    Public ReadOnly Property ObjCuentaCertificacion() As CCuenta
        Get
            Return Me.mObjCuentaCertificacion
        End Get
    End Property

    Public ReadOnly Property ObjCuentaExcCon2008() As CCuenta
        Get
            Return mObjCuentaExcCon2008
        End Get
    End Property

    Public ReadOnly Property ObjCuentaExcCon2009() As CCuenta
        Get
            Return mObjCuentaExcCon2009
        End Get
    End Property

    'Rut Holding
    Public ReadOnly Property RutHolding() As String
        Get
            If mlngRutHolding = -1 Then
                Return ""
            Else
                Return RutLngAUsr(mlngRutHolding)
            End If
        End Get
    End Property

    'Rut del cliente
    Public ReadOnly Property Rut() As String
        Get
            If mlngRut = -1 Then
                Return ""
            Else
                Return mlngRut
            End If
        End Get
    End Property

    'Digito Verificador del cliente
    Public ReadOnly Property DigitoOtec() As String
        Get
            Return mstrDigitoOtec
        End Get
    End Property

    'nombre Fantasia empresa
    Public ReadOnly Property NombreFantasia() As String
        Get
            Return mstrNomFantasia
        End Get
    End Property

    'Razon Social
    Public ReadOnly Property RazonSocial() As String
        Get
            Return mstrRazonSocial
        End Get
    End Property

    'Sigla
    Public ReadOnly Property Sigla() As String
        Get
            Return mstrSigla
        End Get
    End Property

    'email empresa
    Public ReadOnly Property EmailOtec() As String
        Get
            Return mstrEmailOtec
        End Get
    End Property

    'fono empresa
    Public ReadOnly Property FonoOtec() As String
        Get
            Return mstrFonoOtec
        End Get
    End Property


    'fono empresa
    Public ReadOnly Property Fono2Otec() As String
        Get
            Return mstrFono2Otec
        End Get
    End Property

    'fax empresa
    Public ReadOnly Property Fax() As String
        Get
            Return mstrFax
        End Get
    End Property

    'direccion empresa
    Public ReadOnly Property Direccion() As String
        Get
            Return mstrDireccion
        End Get
    End Property

    Public ReadOnly Property DireccionCompleta() As String
        Get
            Return mstrDireccion & " " & mstrNroDireccion
        End Get
    End Property


    'Codigo comuna
    Public ReadOnly Property CodigoComuna() As Long
        Get
            Return mlngCodComuna
        End Get
    End Property

    'Nombre Comuna
    Public ReadOnly Property Comuna() As String
        Get
            Return mstrComuna
        End Get
    End Property

    'Codigo Region
    Public ReadOnly Property CodigoRegion() As Long
        Get
            Return mlngCodRegion
        End Get
    End Property

    'Nombre Region
    Public ReadOnly Property Region() As String
        Get
            Return mstrRegion
        End Get
    End Property

    'Casilla
    Public ReadOnly Property Casilla() As String
        Get
            Return mstrCasilla
        End Get
    End Property

    'Nombre Ciudad
    Public ReadOnly Property Ciudad() As String
        Get
            Return mstrCiudad
        End Get
    End Property

    'Nombre del Sitio Web
    Public ReadOnly Property SitioWeb() As String
        Get
            Return mstrSitioWeb
        End Get
    End Property

    'Costo Administracion
    Public ReadOnly Property CostoAdm() As Double
        Get
            If mdblCostoAdm >= 0 And mdblCostoAdm <= 1 Then
                CostoAdm = mdblCostoAdm * 100
            ElseIf mdblCostoAdm > 1 Then
                CostoAdm = mdblCostoAdm
            End If
        End Get
    End Property
    'Comp Administracion no lineal
    Public ReadOnly Property AdmNoLineal() As Integer
        Get
            Return mintCompAdmNoLineal
        End Get
    End Property

    'Codigo Rubro
    Public ReadOnly Property CodigoRubro() As Integer
        Get
            Return mintCodRubro
        End Get
    End Property

    'Codigo del estado del cliente ==> Activo o Inactivo
    Public ReadOnly Property CodigoEstadoCliente() As Integer
        Get
            Return mintCodEstadoCliente
        End Get
    End Property


    'Nombre Rubro
    Public ReadOnly Property Rubro() As String
        Get
            Return mstrRubro
        End Get
    End Property

    'Numero empleados
    Public ReadOnly Property NumEmpleados() As Long
        Get
            Return mlngNumempleados
        End Get
    End Property


    Public Property RutContacto() As Long
        Get
            Return mlngRutContacto
        End Get
        Set(ByVal value As Long)
            mlngRutContacto = value
        End Set
    End Property
    Public Property Contacto() As String
        Get
            Return mstrContacto
        End Get
        Set(ByVal value As String)
            mstrContacto = value
        End Set
    End Property
    Public Property ApellidoContacto() As String
        Get
            Return mstrApellidoContacto
        End Get
        Set(ByVal value As String)
            mstrApellidoContacto = value
        End Set
    End Property

    'Cargo Contacto
    Public ReadOnly Property CargoContacto() As String
        Get
            Return mstrCargo
        End Get
    End Property

    'Fono Contacto
    Public ReadOnly Property FonoContacto() As String
        Get
            Return mstrFonoContacto
        End Get
    End Property

    'Anexo Contacto
    Public ReadOnly Property AnexoContacto() As String
        Get
            Return mstrAnexoContacto
        End Get
    End Property

    'Email Contacto
    Public ReadOnly Property EmailContacto() As String
        Get
            Return mstrEmailContacto
        End Get
    End Property

    'Nombre Representante1
    Public ReadOnly Property NombreRep1() As String
        Get
            Return mstrRep1
        End Get
    End Property

    'Rut Representante1
    Public ReadOnly Property RutRep1() As Long
        Get
            Return mlngRutRep1
        End Get
    End Property

    'Rut Representante 1 con formato
    Public ReadOnly Property RutRep1Formateado() As String
        Get
            Return mstrRutRep1Formato
        End Get
    End Property

    'Digito Verificador Representante1
    Public ReadOnly Property DigitoRep1() As String
        Get
            Return mstrDigitoRep1
        End Get
    End Property

    'Nombre Representante2
    Public ReadOnly Property NombreRep2() As String
        Get
            Return mstrRep2
        End Get
    End Property


    'Rut Representante2
    Public ReadOnly Property RutRep2() As Long
        Get
            Return mlngRutRep2
        End Get
    End Property

    'Rut Representante 2 con formato
    Public ReadOnly Property RutRep2Formateado() As String
        Get
            Return mstrRutRep2Formato
        End Get
    End Property
    'Digito Verificador Representante2
    Public ReadOnly Property DigitoRep2() As String
        Get
            Return mstrDigitoRep2
        End Get
    End Property

    'Gerente General
    Public ReadOnly Property GerenteGeneral() As String
        Get
            Return mstrGerenteGral
        End Get
    End Property


    'Gerente Recursos Humanos
    Public ReadOnly Property GerenteRRHH() As String
        Get
            Return mstrGerenteRRHH
        End Get
    End Property

    'email Gerente Recursos Humanos
    Public ReadOnly Property EmailGerenteRRHH() As String
        Get
            Return mstrEmailGteRRHH
        End Get
    End Property


    'Gerente Finanzas
    Public ReadOnly Property GerenteFinanzas() As String
        Get
            Return mstrGerenteFinanzas
        End Get
    End Property

    'email Gerente Finanzas
    Public ReadOnly Property EmailGerenteFinanzas() As String
        Get
            Return mstrEmailGteFinanzas
        End Get
    End Property

    'Area Cobranzas
    Public ReadOnly Property AreaCobranzas() As String
        Get
            Return mstrAreaCobranzas
        End Get
    End Property

    'fono Area Cobranzas o gerente Cobranzas
    Public ReadOnly Property FonoCobranzas() As String
        Get
            Return mstrFonoCobranzas
        End Get
    End Property


    'Giro del cliente
    Public ReadOnly Property Giro() As String
        Get
            Return mstrGiro
        End Get
    End Property

    'Codigo Actividad Economica
    Public ReadOnly Property CodActEconomica() As String
        Get
            Return mstrCodActEconomica
        End Get
    End Property

    'Rut Ejecutivo
    Public ReadOnly Property RutEjecutivo() As Long
        Get
            Return mlngRutEjecutivo
        End Get
    End Property

    'Codigo Sucursal
    Public ReadOnly Property CodigoSucursal() As Integer
        Get
            Return mintCodSucursal
        End Get
    End Property



    'Venta Neta Anual
    Public ReadOnly Property VentaAnual() As Long
        Get
            Return mlngVentaAnual
        End Get
    End Property

    'Nombres Ejecutivo
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


    'fax del ejecutivo
    Public ReadOnly Property FaxEjecutivo() As String
        Get
            Return mstrFaxEjecutivo
        End Get
    End Property


    'Nombre Sucursal o Filial
    Public ReadOnly Property NombreSucursal() As String
        Get
            Return mstrSucursal
        End Get
    End Property


    'Arreglo que contiene todas las comunas
    Public ReadOnly Property LookUpComunas() As DataTable
        Get
            Return mdtLookUpComunas
        End Get
    End Property


    'arreglo que contiene todas las regiones
    Public ReadOnly Property LookUpRegiones() As DataTable
        Get
            Return mdtLookUpRegiones
        End Get
    End Property

    'arreglo que contiene los ejecutivos asociados a un cliente en particular
    Public ReadOnly Property LookupEjecutivos() As DataTable
        Get
            Return mdtLookUpEjecutivos
        End Get
    End Property

    'arreglo que contiene las sucursales
    Public ReadOnly Property LookUpSucursales() As DataTable
        Get
            Return mdtLookUpSucursales
        End Get
    End Property

    'Rubro interno
    Public ReadOnly Property LookUpRubros() As DataTable
        Get
            Return mdtLookUpRubros
        End Get
    End Property

    'LookUpAdmNoLineal
    Public ReadOnly Property LookUpAdmNoLineal() As DataTable
        Get
            Return mdtLookUpAdmNoLineal
        End Get
    End Property

    'mdtLookUpEstadoCliente
    Public ReadOnly Property LookUpEstadoCliente() As DataTable
        Get
            Return mdtLookUpEstadoCliente
        End Get
    End Property

    'Deuda del cliente con CST (aporte pendiente)
    Public ReadOnly Property AportePendienteTotal() As Long
        Get
            AportePendienteTotal = mlngAportePendCap + mlngAportePendRep + mlngAportePendAdm
        End Get
    End Property

    'aportes pendientes
    Public ReadOnly Property AportePendienteCap() As Long
        Get
            Return mlngAportePendCap
        End Get
    End Property

    Public ReadOnly Property AportePendienteRep() As Long
        Get
            Return mlngAportePendRep
        End Get
    End Property

    Public ReadOnly Property AportePendienteAdm() As Long
        Get
            Return mlngAportePendAdm
        End Get
    End Property


    'saldo de franquicia
    Public ReadOnly Property SaldoFranquicia() As Long
        Get
            Dim lngMax As Long
            Dim lngCostoOticAdm As Long
            Dim lngAporteEnterado As Long
            lngAporteEnterado = mobjCuentaCap.SumaAbono + mobjCuentaRep.SumaAbono + mobjCuentaAdm.SumaAbono
            lngCostoOticAdm = mobjCuentaCap.SumaCargo + mobjCuentaRep.SumaCargo + mobjCuentaAdm.SumaCargo
            If lngCostoOticAdm > lngAporteEnterado Then
                lngMax = lngCostoOticAdm
            Else
                lngMax = lngAporteEnterado
            End If
            SaldoFranquicia = ObjInfoAdicional.FranquiciaActual - lngMax
        End Get
    End Property

    'porcentaje de saldo de franquicia, saldo/saldo proy
    Public ReadOnly Property SaldoFranquiciaPorc() As Double
        Get
            If ObjInfoAdicional.FranquiciaActual <= 0 Then
                SaldoFranquiciaPorc = 0
            Else
                SaldoFranquiciaPorc = 100 * Math.Abs(CDbl(SaldoFranquicia) / CDbl(ObjInfoAdicional.FranquiciaActual))
            End If
        End Get
    End Property


    'Año siguiente al actual
    Public ReadOnly Property AgnoSiguiente() As Integer
        Get
            Return mintAgnoSiguiente
        End Get
    End Property

    'indica si las cartolas se muestran consolidadas
    Public Property InfoConsolidada() As Boolean
        Get
            InfoConsolidada = mblnInfoConsolidada
        End Get
        Set(ByVal value As Boolean)
            mblnInfoConsolidada = value
        End Set
    End Property
    'indica el año de consulta de los datos
    Public Property Agno() As Integer
        Get
            InfoConsolidada = mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
            mintAgnoSiguiente = value + 1
        End Set
    End Property
    'filiales
    Public ReadOnly Property Filiales() As DataTable
        Get
            Return mdtFiliales
        End Get
    End Property

    Public ReadOnly Property TieneFiliales() As Boolean
        Get
            If mdtFiliales Is Nothing Then
                Return False
            Else
                If mdtFiliales.Rows.Count > 1 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Get
    End Property

    'holdings (empresas madre)
    Public ReadOnly Property Holdings() As DataTable
        Get
            Return mdtHoldings
        End Get
    End Property

    Public ReadOnly Property TieneHoldings() As Boolean
        Get
            If mdtHoldings Is Nothing Then
                Return False
            Else
                If mdtHoldings.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Get
    End Property
    'listado de ruts de filiales separados por comas
    Public ReadOnly Property ListaRutsHolding() As String
        Get
            Return mstrListaRutsHolding
        End Get
    End Property
    Public ReadOnly Property NroDireccion() As String
        Get
            Return mstrNroDireccion
        End Get
    End Property
    Public ReadOnly Property DisponibleVTCap() As Long
        Get
            Return mlngDisponibleVTCap
        End Get
    End Property
    Public ReadOnly Property DisponibleVTExcCap() As Long
        Get
            Return mlngDisponibleVTExcCap
        End Get
    End Property
    Public ReadOnly Property DisponibleVTExcRep() As Long
        Get
            Return mlngDisponibleVTExcRep
        End Get
    End Property
    Public ReadOnly Property ClaveWebService() As String
        Get
            ClaveWebService = DecryptINI$(mstrClaveWebService)
        End Get
    End Property
    Public ReadOnly Property EtiquetaClasificador() As String
        Get
            Return mstrEtiquetaClasificador
        End Get
    End Property
    Public ReadOnly Property SaldoInicialCong2008() As Double
        Get
            Return mdblSaldoInicialCong2008
        End Get
    End Property
    Public ReadOnly Property SaldoCargosCong2008() As Double
        Get
            Return mdblSaldoCargosCong2008
        End Get
    End Property
    Public ReadOnly Property SaldoFinalCong2008() As Double
        Get
            Return mdblSaldoFinalCong2008
        End Get
    End Property
    Public ReadOnly Property SaldoInicialCong2009() As Double
        Get
            Return mdblSaldoInicialCong2009
        End Get
    End Property
    Public ReadOnly Property SaldoCargosCong2009() As Double
        Get
            Return mdblSaldoCargosCong2009
        End Get
    End Property
    Public ReadOnly Property SaldoFinalCong2009() As Double
        Get
            Return mdblSaldoFinalCong2009
        End Get
    End Property

    Public Sub New()
        mlngRut = 0
        mstrDigitoOtec = ""
        mstrNomFantasia = ""
        mstrRazonSocial = ""
        mstrSigla = ""
        mstrEmailOtec = ""
        mstrFonoOtec = ""
        mstrFono2Otec = ""
        mstrFax = ""
        mstrDireccion = ""
        mlngCodComuna = 0
        mlngCodRegion = 0
        mstrComuna = ""
        mstrRegion = ""
        mstrCasilla = ""
        mstrCiudad = ""
        mstrSitioWeb = ""
        mdblCostoAdm = 0
        mintCompAdmNoLineal = 0
        mintCodRubro = 0
        mintCodEstadoCliente = 0
        mstrRubro = ""
        mlngNumempleados = -1
        mstrContacto = ""
        mlngRutContacto = 0
        mstrAnexoContacto = ""
        mstrCargo = ""
        mstrFonoContacto = ""
        mstrAnexoContacto = ""
        mstrEmailContacto = ""
        mstrRep1 = ""
        mlngRutRep1 = -1
        mstrDigitoRep1 = ""
        mstrRep2 = ""
        mlngRutRep2 = -1
        mstrDigitoRep2 = ""
        mstrGerenteGral = ""
        mstrGerenteRRHH = ""
        mstrEmailGteRRHH = ""
        mstrGerenteFinanzas = ""
        mstrEmailGteFinanzas = ""
        mstrAreaCobranzas = ""
        mstrFonoCobranzas = ""
        mstrGiro = ""
        mstrCodActEconomica = ""
        mlngRutEjecutivo = 0
        mintCodSucursal = 0
        mstrNomEjecutivo = ""
        mstrEmailEjecutivo = ""
        mstrFonoEjecutivo = ""
        mstrFaxEjecutivo = ""
        mstrSucursal = ""
        mlngVentaAnual = 0
        mstrSucursal = ""
        mlngRutHolding = -1
        mstrObservacion = ""

        mlngAportePendCap = -1
        mlngAportePendRep = -1
        mlngAportePendAdm = -1
        mintAgno = Now.Year
        mintAgnoSiguiente = Now.Year + 1

        mblnInfoConsolidada = False
        '--------------------------------
        mstrNroDireccion = ""
        '--------------------------------

        mlngDisponibleVTCap = 0
        mlngDisponibleVTExcCap = 0
        mlngDisponibleVTExcRep = 0

        mstrClaveWebService = ""
        mstrEtiquetaClasificador = ""
    End Sub
    Public Sub Inicializar0(ByRef objSql As CSql, _
                            ByVal lngRutUsuario As Long)
        mobjSql = objSql
        Carga_Lookup()
        If lngRutUsuario <= 0 Then
            EnviaError("CCliente:Inicializar0--> Cliente Desconocido")
            Exit Sub
        End If
        mlngRutUsuario = lngRutUsuario
    End Sub
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
        Carga_Lookup()
    End Sub

    Sub Carga_Lookup()
        'carga los lookup
        mdtLookUpComunas = mobjSql.s_comunas_todos
        mdtLookUpRegiones = mobjSql.s_regiones_todos
        mdtLookUpRubros = mobjSql.s_rubros_todos
        mdtLookUpSucursales = mobjSql.s_sucursales_todos

        'Arreglo de Comp Adm No lineal
        'ReDim mdtLookUpAdmNoLineal(1, 1)
        'mdtLookUpAdmNoLineal(0, 0) = 1
        'mdtLookUpAdmNoLineal(1, 0) = "No Lineal"
        'mdtLookUpAdmNoLineal(0, 1) = 0
        'mdtLookUpAdmNoLineal(1, 1) = "Lineal"
        mdtLookUpAdmNoLineal = New DataTable
        mdtLookUpAdmNoLineal.Columns.Add("CodTipoAdm")
        mdtLookUpAdmNoLineal.Columns.Add("NomTipoAdm")
        Dim dr As DataRow
        dr = mdtLookUpAdmNoLineal.NewRow
        dr("CodTipoAdm") = 1
        dr("NomTipoAdm") = "No Lineal"
        mdtLookUpAdmNoLineal.Rows.Add(dr)
        dr = mdtLookUpAdmNoLineal.NewRow
        dr("CodTipoAdm") = 0
        dr("NomTipoAdm") = "Lineal"
        mdtLookUpAdmNoLineal.Rows.Add(dr)

        mdtLookUpEjecutivos = mobjSql.s_ejecutivo_todos

        'Estado del Cliente Activo o Inactivo
        mdtLookUpEstadoCliente = mobjSql.s_estados_cliente
    End Sub

    'Constructor del objeto, recibe el rut buscado. Retorna False si el Rut no
    'corresponde a un Otec.
    Public Function Inicializar1(ByVal strRut As String) As Boolean
        Try
            Dim lngRut As Long
            Dim dtOtec As DataTable
            Dim lngVTAgnoAnt As Long
            Dim lngVTRepAgnoAnt As Long
            'mobjSql = New CSql

            lngRut = RutUsrALng(strRut)
            'lngRut = strRut
            dtOtec = mobjSql.s_persona_juridica2(lngRut, mlngRutUsuario)
            If mobjSql.Registros = 0 Then
                Inicializar1 = False
                Exit Function
            End If

            'asignación de valores
            mlngRut = lngRut

            'ejecutivo para un Cliente
            mdtEjecutivos = mobjSql.s_ejecutivo(mlngRut)

            mstrDigitoOtec = dtOtec.Rows(0)(1)
            mstrNomFantasia = dtOtec.Rows(0)(2)
            mstrRazonSocial = dtOtec.Rows(0)(3)
            mstrSigla = dtOtec.Rows(0)(4)
            mstrEmailOtec = dtOtec.Rows(0)(5)
            mstrFonoOtec = Trim(dtOtec.Rows(0)(6))
            If IsDBNull(dtOtec.Rows(0)(7)) Then
                mstrFono2Otec = ""
            Else
                mstrFono2Otec = Trim(dtOtec.Rows(0)(7))
            End If
            If IsDBNull(dtOtec.Rows(0)(8)) Then
                mstrFax = ""
            Else
                mstrFax = Trim(dtOtec.Rows(0)(8))
            End If
            mstrDireccion = dtOtec.Rows(0)(9)
            mlngCodComuna = dtOtec.Rows(0)(10)
            mstrComuna = dtOtec.Rows(0)(14)
            mlngCodRegion = dtOtec.Rows(0)(15)
            mstrRegion = dtOtec.Rows(0)(16)
            If IsDBNull(dtOtec.Rows(0)(11)) Then
                mstrCasilla = ""
            Else
                mstrCasilla = Trim(dtOtec.Rows(0)(11))
            End If
            mstrCiudad = dtOtec.Rows(0)(12)
            If IsDBNull(dtOtec.Rows(0)(13)) Then
                mstrSitioWeb = ""
            Else
                mstrSitioWeb = dtOtec.Rows(0)(13)
            End If
            mdblCostoAdm = dtOtec.Rows(0)(17)
            mintCompAdmNoLineal = dtOtec.Rows(0)(18)
            mintCodRubro = dtOtec.Rows(0)(36)
            mstrRubro = dtOtec.Rows(0)(37)

            'Codigo del estado del cliente ==> Activo o Ianctivo o bloqueado
            mintCodEstadoCliente = dtOtec.Rows(0)(38)


            If IsDBNull(dtOtec.Rows(0)(19)) Then
                dtOtec.Rows(0)(19) = -1
            Else
                mlngNumempleados = dtOtec.Rows(0)(19)
            End If

            If IsDBNull(dtOtec.Rows(0)(20)) Then
                mstrContacto = ""
            Else
                mstrContacto = dtOtec.Rows(0)(20)
            End If
            If IsDBNull(dtOtec.Rows(0)(21)) Then
                mstrCargo = ""
            Else
                mstrCargo = dtOtec.Rows(0)(21)
            End If
            If IsDBNull(dtOtec.Rows(0)(22)) Then
                mstrFonoContacto = ""
            Else
                mstrFonoContacto = Trim(dtOtec.Rows(0)(22))
            End If
            If IsDBNull(dtOtec.Rows(0)(23)) Then
                mstrAnexoContacto = ""
            Else
                mstrAnexoContacto = Trim(dtOtec.Rows(0)(23))
            End If
            If IsDBNull(dtOtec.Rows(0)(24)) Then
                mstrEmailContacto = ""
            Else
                mstrEmailContacto = dtOtec.Rows(0)(24)
            End If
            If IsDBNull(dtOtec.Rows(0)(25)) Then
                mstrRep1 = ""
            Else
                mstrRep1 = dtOtec.Rows(0)(25)
            End If
            If IsDBNull(dtOtec.Rows(0)(26)) Then
                dtOtec.Rows(0)(26) = -1
            Else
                mlngRutRep1 = dtOtec.Rows(0)(26)
                mstrRutRep1Formato = RutLngAUsr(mlngRutRep1)
            End If
            If IsDBNull(dtOtec.Rows(0)(27)) Then
                mstrDigitoRep1 = ""
            Else
                mstrDigitoRep1 = dtOtec.Rows(0)(27)
            End If
            If IsDBNull(dtOtec.Rows(0)(28)) Then
                mstrRep2 = ""
            Else
                mstrRep2 = dtOtec.Rows(0)(28)
            End If
            If IsDBNull(dtOtec.Rows(0)(29)) Then
                'dtOtec(29) = -1
                mlngRutRep2 = -1
                mstrRutRep2Formato = ""
            Else
                mlngRutRep2 = dtOtec.Rows(0)(29)
                mstrRutRep2Formato = RutLngAUsr(mlngRutRep2)
            End If
            If IsDBNull(dtOtec.Rows(0)(30)) Then
                mstrDigitoRep2 = ""
            Else
                mstrDigitoRep2 = dtOtec.Rows(0)(30)
            End If
            If IsDBNull(dtOtec.Rows(0)(31)) Then
                mstrGerenteGral = ""
            Else
                mstrGerenteGral = dtOtec.Rows(0)(31)
            End If
            If IsDBNull(dtOtec.Rows(0)(32)) Then
                mstrGerenteRRHH = ""
            Else
                mstrGerenteRRHH = dtOtec.Rows(0)(32)
            End If
            If IsDBNull(dtOtec.Rows(0)(33)) Then
                mstrAreaCobranzas = ""
            Else
                mstrAreaCobranzas = dtOtec.Rows(0)(33)
            End If
            If IsDBNull(dtOtec.Rows(0)(34)) Then
                mstrGiro = ""
            Else
                mstrGiro = dtOtec.Rows(0)(34)
            End If
            If IsDBNull(dtOtec.Rows(0)(35)) Then
                mstrCodActEconomica = ""
            Else
                mstrCodActEconomica = dtOtec.Rows(0)(35)
            End If

            'entrega el rut y nombre del ejecutivo
            Dim dtEjecutivo As DataTable
            dtEjecutivo = mobjSql.s_ejecutivo(lngRut)

            If mobjSql.Registros > 0 Then
                mlngRutEjecutivo = dtEjecutivo.Rows(0)(0)
                mstrNomEjecutivo = dtEjecutivo.Rows(0)(1)
                If IsDBNull(dtEjecutivo.Rows(0)(2)) Then dtEjecutivo.Rows(0)(2) = ""
                mstrEmailEjecutivo = dtEjecutivo.Rows(0)(2)
                If IsDBNull(dtEjecutivo.Rows(0)(3)) Then dtEjecutivo.Rows(0)(3) = ""
                mstrFonoEjecutivo = dtEjecutivo.Rows(0)(3)
                If IsDBNull(dtEjecutivo.Rows(0)(4)) Then dtEjecutivo.Rows(0)(4) = ""
                mstrFaxEjecutivo = dtEjecutivo.Rows(0)(4)
            Else
                mlngRutEjecutivo = 0
                mstrNomEjecutivo = "No posee"
                mstrEmailEjecutivo = "No posee"
                mstrFonoEjecutivo = "No posee"
                mstrFaxEjecutivo = "No posee"
            End If

            mintCodSucursal = dtOtec.Rows(0)(40)
            mlngVentaAnual = dtOtec.Rows(0)(41)


            'Email Gerente de Recursos Humanos
            If IsDBNull(dtOtec.Rows(0)(42)) Then
                mstrEmailGteRRHH = ""
            Else
                mstrEmailGteRRHH = dtOtec.Rows(0)(42)
            End If

            'Gerente de Finanzas
            If IsDBNull(dtOtec.Rows(0)(43)) Then
                mstrGerenteFinanzas = ""
            Else
                mstrGerenteFinanzas = dtOtec.Rows(0)(43)
            End If

            'Email Gerente Finanzas
            If IsDBNull(dtOtec.Rows(0)(44)) Then
                mstrEmailGteFinanzas = ""
            Else
                mstrEmailGteFinanzas = dtOtec.Rows(0)(44)
            End If

            'Fono Cobranzas
            If IsDBNull(dtOtec.Rows(0)(45)) Then
                mstrFonoCobranzas = ""
            Else
                mstrFonoCobranzas = Trim(dtOtec.Rows(0)(45))
            End If

            'Nombre Sucursal o Filial
            mstrSucursal = dtOtec.Rows(0)(46)

            'Rut Holding
            If IsDBNull(dtOtec.Rows(0)(47)) Then
                mlngRutHolding = -1
            Else
                mlngRutHolding = dtOtec.Rows(0)(47)
            End If
            '-------------------------------------------------------------------
            mstrNroDireccion = IIf(IsDBNull(dtOtec.Rows(0)(48)), "", dtOtec.Rows(0)(48))

            mlngRutContacto = dtOtec.Rows(0)(49)

            mstrApellidoContacto = dtOtec.Rows(0)(50)
            '-------------------------------------------------------------------

            'mstrClaveWebService = IIf(IsDBNull(dtOtec.Rows(0)(49)), "", dtOtec.Rows(0)(49))

            'mstrEtiquetaClasificador = IIf(IsDBNull(dtOtec.Rows(0)(50)), "", dtOtec.Rows(0)(50))

            'inicialización de lista de ruts de filiales
            mdtFiliales = New DataTable
            mdtFiliales.Columns.Add("RutFilial")
            mdtFiliales.Columns.Add("Nombre")
            mdtFiliales.Columns.Add("Nivel")
            mdtFiliales.Columns.Add("DigitoVerif")
            Dim dtFiliales As DataTable
            'Dim intFilas As Integer
            'Dim i As Integer
            dtFiliales = mobjSql.s_clientes_asociados(mlngRut)
            If mobjSql.Registros > 0 Then
                'asignar el resultado de la consulta al arreglo con campos
                Dim dr As DataRow
                Dim drFiliales As DataRow
                For Each dr In dtFiliales.Rows
                    drFiliales = mdtFiliales.NewRow
                    drFiliales("RutFilial") = dr.Item(0)
                    drFiliales("Nombre") = dr.Item(1)
                    drFiliales("Nivel") = dr.Item(3)
                    drFiliales("DigitoVerif") = digito_verificador(dr.Item(0))
                    mdtFiliales.Rows.Add(drFiliales)
                Next
            End If
            'si hay que consolidar y tiene filiales, generar lista de ruts
            mstrListaRutsHolding = ""
            If mblnInfoConsolidada And TieneFiliales Then
                Dim dr As DataRow
                For Each dr In mdtFiliales.Rows
                    'If mstrListaRutsHolding <> "" Then
                    mstrListaRutsHolding = mstrListaRutsHolding & dr("RutFilial") & ","
                    'Else
                    '    mstrListaRutsHolding = mstrListaRutsHolding & dr("RutFilial")
                    'End If
                Next
                mstrListaRutsHolding = Left(mstrListaRutsHolding, mstrListaRutsHolding.Length - 1)
            End If


            'inicialización de lista de ruts de holdings (empresas madre)
            mdtHoldings = New DataTable
            mdtHoldings.Columns.Add("RutFilial")
            mdtHoldings.Columns.Add("Nombre")
            mdtHoldings.Columns.Add("Nivel")
            mdtHoldings.Columns.Add("DigitoVerif")
            Dim dtHoldings As DataTable
            dtHoldings = mobjSql.s_clientes_holding(mlngRut)
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                Dim drHoldings As DataRow
                For Each dr In dtHoldings.Rows
                    drHoldings = mdtHoldings.NewRow
                    drHoldings("RutFilial") = dr.Item(0)
                    drHoldings("Nombre") = dr.Item(1)
                    drHoldings("Nivel") = dr.Item(3)
                    drHoldings("DigitoVerif") = digito_verificador(dr.Item(0))
                    mdtHoldings.Rows.Add(drHoldings)
                Next
            End If

            mobjCuentaCap = New CCuenta
            mobjCuentaCap.inicializarCsql(mobjSql)
            mobjCuentaCap.Agno = mintAgno - 1
            mobjCuentaCap.Inicializar(lngRut, 1, mstrListaRutsHolding)
            'lngVTAgnoAnt = mobjCuentaCap.SumaCargoVyT
            lngVTAgnoAnt = CLng((mobjCuentaCap.SumaAbono) * 0.1) - mobjCuentaCap.SumaCargoVyT

            mobjCuentaCap = New CCuenta
            mobjCuentaCap.inicializarCsql(mobjSql)
            mobjCuentaCap.Agno = mintAgno
            mobjCuentaCap.Inicializar(lngRut, 1, mstrListaRutsHolding)

            'Se carga el valor del 10% como tope disponible para V&T
            If mobjCuentaCap.SumaAbono > 0 Then
                mlngDisponibleVTCap = CLng((mobjCuentaCap.SumaAbono) * 0.1)
            Else
                mlngDisponibleVTCap = 0
            End If

            mobjCuentaRep = New CCuenta
            Call mobjCuentaRep.inicializarCsql(mobjSql)
            mobjCuentaRep.Agno = mintAgno - 1
            Call mobjCuentaRep.Inicializar(lngRut, 2, mstrListaRutsHolding)
            lngVTRepAgnoAnt = mobjCuentaRep.SumaCargoVyT

            mobjCuentaRep = New CCuenta
            Call mobjCuentaRep.inicializarCsql(mobjSql)
            mobjCuentaRep.Agno = mintAgno
            Call mobjCuentaRep.Inicializar(lngRut, 2, mstrListaRutsHolding)

            mobjCuentaAdm = New CCuenta
            Call mobjCuentaAdm.inicializarCsql(mobjSql)
            mobjCuentaAdm.Agno = mintAgno
            Call mobjCuentaAdm.Inicializar(lngRut, 3, mstrListaRutsHolding)

            mobjCuentaExcCap = New CCuenta
            Call mobjCuentaExcCap.inicializarCsql(mobjSql)
            mobjCuentaExcCap.Agno = mintAgno
            Call mobjCuentaExcCap.Inicializar(lngRut, 4, mstrListaRutsHolding)

            'Se carga el valor del 10% como tope disponible para V&T menos lo utilizado
            'If mobjCuentaExcCap.SumaAporte > 0 Then
            '    mlngDisponibleVTExcCap = CLng((mobjCuentaExcCap.SumaAporte * 0.1) - lngVTAgnoAnt)
            '    If mlngDisponibleVTExcCap < 0 Then
            '        mlngDisponibleVTExcCap = 0
            '    End If
            'Else
            '    mlngDisponibleVTExcCap = 0
            'End If
            If lngVTAgnoAnt >= 0 Then
                If mobjCuentaExcCap.SumaAporte < lngVTAgnoAnt Then
                    mlngDisponibleVTExcCap = mobjCuentaExcCap.SumaAporte
                Else
                    mlngDisponibleVTExcCap = lngVTAgnoAnt
                End If
            Else
                mlngDisponibleVTExcCap = 0
            End If


            mobjCuentaExcRep = New CCuenta
            Call mobjCuentaExcRep.inicializarCsql(mobjSql)
            mobjCuentaExcRep.Agno = mintAgno
            Call mobjCuentaExcRep.Inicializar(lngRut, 5, mstrListaRutsHolding)

            'Se carga el valor del 10% como tope disponible para V&T menos lo utilizado
            If mobjCuentaExcRep.SumaAporte > 0 Then
                mlngDisponibleVTExcRep = CLng((mobjCuentaExcRep.SumaAporte * 0.1) - lngVTRepAgnoAnt)
                If mlngDisponibleVTExcRep < 0 Then
                    mlngDisponibleVTExcRep = 0
                End If
            Else
                mlngDisponibleVTExcRep = 0
            End If

            'Cuenta de Excedentes de 2 años que sólo sirven para pagar cursos complementarios(**|**)
            mobjCuentaBecas = New CCuenta
            Call mobjCuentaBecas.inicializarCsql(mobjSql)
            mobjCuentaBecas.Agno = mintAgno
            Call mobjCuentaBecas.Inicializar(lngRut, 6, mstrListaRutsHolding)

            'Cuenta Financiamiento Otic
            mObjCuentaFinanciamientoOtic = New CCuenta
            Call mObjCuentaFinanciamientoOtic.inicializarCsql(mobjSql)
            mObjCuentaFinanciamientoOtic.Agno = mintAgno
            Call mObjCuentaFinanciamientoOtic.Inicializar(lngRut, 7, mstrListaRutsHolding)

            ' Certificacion Competencias Laborales
            Me.mObjCuentaCertificacion = New CCuenta
            Call mObjCuentaCertificacion.inicializarCsql(mobjSql)
            mObjCuentaCertificacion.Agno = mintAgno
            Call mObjCuentaCertificacion.Inicializar(lngRut, 8, mstrListaRutsHolding)

            ' Certificacion Competencias Laborales
            Me.mObjCuentaExcCertificacion = New CCuenta
            Call mObjCuentaExcCertificacion.inicializarCsql(mobjSql)
            mObjCuentaExcCertificacion.Agno = mintAgno
            Call mObjCuentaExcCertificacion.Inicializar(lngRut, 9, mstrListaRutsHolding)

            mObjCuentaExcCon2008 = New CCuenta
            Call mObjCuentaExcCon2008.inicializarCsql(mobjSql)
            mObjCuentaExcCon2008.Agno = mintAgno
            Call mObjCuentaExcCon2008.Inicializar(lngRut, 10, mstrListaRutsHolding)

            mObjCuentaExcCon2009 = New CCuenta
            Call mObjCuentaExcCon2009.inicializarCsql(mobjSql)
            mObjCuentaExcCon2009.Agno = mintAgno
            Call mObjCuentaExcCon2009.Inicializar(lngRut, 11, mstrListaRutsHolding)

            If lngRut <= 0 Then
                mdblSaldoInicialCong2008 = mobjSql.s_saldo_inicial_congelados2008(mstrListaRutsHolding)
                mdblSaldoCargosCong2008 = mobjSql.s_cargos_congelados2008(mstrListaRutsHolding)
                mdblSaldoInicialCong2009 = mobjSql.s_saldo_inicial_congelados2009(mstrListaRutsHolding)
                mdblSaldoCargosCong2009 = mobjSql.s_cargos_congelados2009(mstrListaRutsHolding)
            Else
                mdblSaldoInicialCong2008 = mobjSql.s_saldo_inicial_congelados2008(lngRut)
                mdblSaldoCargosCong2008 = mobjSql.s_cargos_congelados2008(lngRut)
                mdblSaldoInicialCong2009 = mobjSql.s_saldo_inicial_congelados2009(lngRut)
                mdblSaldoCargosCong2009 = mobjSql.s_cargos_congelados2009(lngRut)
            End If
            mdblSaldoFinalCong2008 = mdblSaldoInicialCong2008 - mdblSaldoCargosCong2008
            mdblSaldoFinalCong2009 = mdblSaldoInicialCong2009 - mdblSaldoCargosCong2009

            'calculo del aporte pendiente (deuda con CST)
            mlngAportePendCap = -mobjCuentaCap.SumaSaldoPend
            If mlngAportePendCap < 0 Then mlngAportePendCap = 0
            mlngAportePendRep = -mobjCuentaRep.SumaSaldoPend
            If mlngAportePendRep < 0 Then mlngAportePendRep = 0
            mlngAportePendAdm = -mobjCuentaAdm.SumaSaldoPend
            If mlngAportePendAdm < 0 Then mlngAportePendAdm = 0

            'inicializar objeto con información adicional del cliente
            mobjInfoCliente = New CClienteInfo
            mobjInfoCliente.Inicializar(mobjSql, mlngRut, mobjCuentaCap.SumaCargo, _
                                                        mobjCuentaExcCap.SumaCargo, mstrListaRutsHolding, mintAgno)
            mobjInfoCliente = Nothing

            'franquicia
            'mdtGraficoTortaCursosSence()
            Inicializar1 = True
        Catch ex As Exception
            EnviaError("" & ex.Message)
        End Try
    End Function
    'Constructor del objeto, recibe el rut buscado. Retorna False si el Rut no
    'corresponde a un Otec.
    Public Function Inicializar3(ByVal strRut As String) As Boolean
        Try
            Dim lngRut As Long
            Dim dtOtec As DataTable
            Dim lngVTAgnoAnt As Long
            Dim lngVTRepAgnoAnt As Long
            'mobjSql = New CSql

            lngRut = RutUsrALng(strRut)
            'lngRut = strRut
            dtOtec = mobjSql.s_persona_juridica2(lngRut, mlngRutUsuario)
            If mobjSql.Registros = 0 Then
                Inicializar3 = False
                Exit Function
            End If

            'asignación de valores
            mlngRut = lngRut

            'ejecutivo para un Cliente
            mdtEjecutivos = mobjSql.s_ejecutivo(mlngRut)

            mstrDigitoOtec = dtOtec.Rows(0)(1)
            mstrNomFantasia = dtOtec.Rows(0)(2)
            mstrRazonSocial = dtOtec.Rows(0)(3)
            mstrSigla = dtOtec.Rows(0)(4)
            mstrEmailOtec = dtOtec.Rows(0)(5)
            mstrFonoOtec = Trim(dtOtec.Rows(0)(6))
            If IsDBNull(dtOtec.Rows(0)(7)) Then
                mstrFono2Otec = ""
            Else
                mstrFono2Otec = Trim(dtOtec.Rows(0)(7))
            End If
            If IsDBNull(dtOtec.Rows(0)(8)) Then
                mstrFax = ""
            Else
                mstrFax = Trim(dtOtec.Rows(0)(8))
            End If
            mstrDireccion = dtOtec.Rows(0)(9)
            mlngCodComuna = dtOtec.Rows(0)(10)
            mstrComuna = dtOtec.Rows(0)(14)
            mlngCodRegion = dtOtec.Rows(0)(15)
            mstrRegion = dtOtec.Rows(0)(16)
            If IsDBNull(dtOtec.Rows(0)(11)) Then
                mstrCasilla = ""
            Else
                mstrCasilla = Trim(dtOtec.Rows(0)(11))
            End If
            mstrCiudad = dtOtec.Rows(0)(12)
            If IsDBNull(dtOtec.Rows(0)(13)) Then
                mstrSitioWeb = ""
            Else
                mstrSitioWeb = dtOtec.Rows(0)(13)
            End If
            mdblCostoAdm = dtOtec.Rows(0)(17)
            mintCompAdmNoLineal = dtOtec.Rows(0)(18)
            mintCodRubro = dtOtec.Rows(0)(36)
            mstrRubro = dtOtec.Rows(0)(37)

            'Codigo del estado del cliente ==> Activo o Ianctivo o bloqueado
            mintCodEstadoCliente = dtOtec.Rows(0)(38)


            If IsDBNull(dtOtec.Rows(0)(19)) Then
                dtOtec.Rows(0)(19) = -1
            Else
                mlngNumempleados = dtOtec.Rows(0)(19)
            End If

            If IsDBNull(dtOtec.Rows(0)(20)) Then
                mstrContacto = ""
            Else
                mstrContacto = dtOtec.Rows(0)(20)
            End If
            If IsDBNull(dtOtec.Rows(0)(21)) Then
                mstrCargo = ""
            Else
                mstrCargo = dtOtec.Rows(0)(21)
            End If
            If IsDBNull(dtOtec.Rows(0)(22)) Then
                mstrFonoContacto = ""
            Else
                mstrFonoContacto = Trim(dtOtec.Rows(0)(22))
            End If
            If IsDBNull(dtOtec.Rows(0)(23)) Then
                mstrAnexoContacto = ""
            Else
                mstrAnexoContacto = Trim(dtOtec.Rows(0)(23))
            End If
            If IsDBNull(dtOtec.Rows(0)(24)) Then
                mstrEmailContacto = ""
            Else
                mstrEmailContacto = dtOtec.Rows(0)(24)
            End If
            If IsDBNull(dtOtec.Rows(0)(25)) Then
                mstrRep1 = ""
            Else
                mstrRep1 = dtOtec.Rows(0)(25)
            End If
            If IsDBNull(dtOtec.Rows(0)(26)) Then
                dtOtec.Rows(0)(26) = -1
            Else
                mlngRutRep1 = dtOtec.Rows(0)(26)
                mstrRutRep1Formato = RutLngAUsr(mlngRutRep1)
            End If
            If IsDBNull(dtOtec.Rows(0)(27)) Then
                mstrDigitoRep1 = ""
            Else
                mstrDigitoRep1 = dtOtec.Rows(0)(27)
            End If
            If IsDBNull(dtOtec.Rows(0)(28)) Then
                mstrRep2 = ""
            Else
                mstrRep2 = dtOtec.Rows(0)(28)
            End If
            If IsDBNull(dtOtec.Rows(0)(29)) Then
                'dtOtec(29) = -1
                mlngRutRep2 = -1
                mstrRutRep2Formato = ""
            Else
                mlngRutRep2 = dtOtec.Rows(0)(29)
                mstrRutRep2Formato = RutLngAUsr(mlngRutRep2)
            End If
            If IsDBNull(dtOtec.Rows(0)(30)) Then
                mstrDigitoRep2 = ""
            Else
                mstrDigitoRep2 = dtOtec.Rows(0)(30)
            End If
            If IsDBNull(dtOtec.Rows(0)(31)) Then
                mstrGerenteGral = ""
            Else
                mstrGerenteGral = dtOtec.Rows(0)(31)
            End If
            If IsDBNull(dtOtec.Rows(0)(32)) Then
                mstrGerenteRRHH = ""
            Else
                mstrGerenteRRHH = dtOtec.Rows(0)(32)
            End If
            If IsDBNull(dtOtec.Rows(0)(33)) Then
                mstrAreaCobranzas = ""
            Else
                mstrAreaCobranzas = dtOtec.Rows(0)(33)
            End If
            If IsDBNull(dtOtec.Rows(0)(34)) Then
                mstrGiro = ""
            Else
                mstrGiro = dtOtec.Rows(0)(34)
            End If
            If IsDBNull(dtOtec.Rows(0)(35)) Then
                mstrCodActEconomica = ""
            Else
                mstrCodActEconomica = dtOtec.Rows(0)(35)
            End If

            'entrega el rut y nombre del ejecutivo
            Dim dtEjecutivo As DataTable
            dtEjecutivo = mobjSql.s_ejecutivo(lngRut)

            If mobjSql.Registros > 0 Then
                mlngRutEjecutivo = dtEjecutivo.Rows(0)(0)
                mstrNomEjecutivo = dtEjecutivo.Rows(0)(1)
                If IsDBNull(dtEjecutivo.Rows(0)(2)) Then dtEjecutivo.Rows(0)(2) = ""
                mstrEmailEjecutivo = dtEjecutivo.Rows(0)(2)
                If IsDBNull(dtEjecutivo.Rows(0)(3)) Then dtEjecutivo.Rows(0)(3) = ""
                mstrFonoEjecutivo = dtEjecutivo.Rows(0)(3)
                If IsDBNull(dtEjecutivo.Rows(0)(4)) Then dtEjecutivo.Rows(0)(4) = ""
                mstrFaxEjecutivo = dtEjecutivo.Rows(0)(4)
            Else
                mlngRutEjecutivo = 0
                mstrNomEjecutivo = "No posee"
                mstrEmailEjecutivo = "No posee"
                mstrFonoEjecutivo = "No posee"
                mstrFaxEjecutivo = "No posee"
            End If

            mintCodSucursal = dtOtec.Rows(0)(40)
            mlngVentaAnual = dtOtec.Rows(0)(41)


            'Email Gerente de Recursos Humanos
            If IsDBNull(dtOtec.Rows(0)(42)) Then
                mstrEmailGteRRHH = ""
            Else
                mstrEmailGteRRHH = dtOtec.Rows(0)(42)
            End If

            'Gerente de Finanzas
            If IsDBNull(dtOtec.Rows(0)(43)) Then
                mstrGerenteFinanzas = ""
            Else
                mstrGerenteFinanzas = dtOtec.Rows(0)(43)
            End If

            'Email Gerente Finanzas
            If IsDBNull(dtOtec.Rows(0)(44)) Then
                mstrEmailGteFinanzas = ""
            Else
                mstrEmailGteFinanzas = dtOtec.Rows(0)(44)
            End If

            'Fono Cobranzas
            If IsDBNull(dtOtec.Rows(0)(45)) Then
                mstrFonoCobranzas = ""
            Else
                mstrFonoCobranzas = Trim(dtOtec.Rows(0)(45))
            End If

            'Nombre Sucursal o Filial
            mstrSucursal = dtOtec.Rows(0)(46)

            'Rut Holding
            If IsDBNull(dtOtec.Rows(0)(47)) Then
                mlngRutHolding = -1
            Else
                mlngRutHolding = dtOtec.Rows(0)(47)
            End If
            '-------------------------------------------------------------------
            mstrNroDireccion = IIf(IsDBNull(dtOtec.Rows(0)(48)), "", dtOtec.Rows(0)(48))

            mlngRutContacto = dtOtec.Rows(0)(49)

            mstrApellidoContacto = dtOtec.Rows(0)(50)

            'mstrObservacion = IIf(IsDBNull(dtOtec.Rows(0)(49)), "", dtOtec.Rows(0)(49))
            '-------------------------------------------------------------------

            'mstrClaveWebService = IIf(IsDBNull(dtOtec.Rows(0)(49)), "", dtOtec.Rows(0)(49))

           ' mstrEtiquetaClasificador = IIf(IsDBNull(dtOtec.Rows(0)(50)), "", dtOtec.Rows(0)(50))

            'inicialización de lista de ruts de filiales
            mdtFiliales = New DataTable
            mdtFiliales.Columns.Add("RutFilial")
            mdtFiliales.Columns.Add("Nombre")
            mdtFiliales.Columns.Add("Nivel")
            mdtFiliales.Columns.Add("DigitoVerif")
            Dim dtFiliales As DataTable
            'Dim intFilas As Integer
            'Dim i As Integer
            dtFiliales = mobjSql.s_clientes_asociados(mlngRut)
            If mobjSql.Registros > 0 Then
                'asignar el resultado de la consulta al arreglo con campos
                Dim dr As DataRow
                Dim drFiliales As DataRow
                For Each dr In dtFiliales.Rows
                    drFiliales = mdtFiliales.NewRow
                    drFiliales("RutFilial") = dr.Item(0)
                    drFiliales("Nombre") = dr.Item(1)
                    drFiliales("Nivel") = dr.Item(3)
                    drFiliales("DigitoVerif") = digito_verificador(dr.Item(0))
                    mdtFiliales.Rows.Add(drFiliales)
                Next
            End If
            'si hay que consolidar y tiene filiales, generar lista de ruts
            mstrListaRutsHolding = ""
            If mblnInfoConsolidada And TieneFiliales Then
                Dim dr As DataRow
                For Each dr In mdtFiliales.Rows
                    'If mstrListaRutsHolding <> "" Then
                    mstrListaRutsHolding = mstrListaRutsHolding & dr("RutFilial") & ","
                    'Else
                    '    mstrListaRutsHolding = mstrListaRutsHolding & dr("RutFilial")
                    'End If
                Next
                mstrListaRutsHolding = Left(mstrListaRutsHolding, mstrListaRutsHolding.Length - 1)
            End If


            'inicialización de lista de ruts de holdings (empresas madre)
            mdtHoldings = New DataTable
            mdtHoldings.Columns.Add("RutFilial")
            mdtHoldings.Columns.Add("Nombre")
            mdtHoldings.Columns.Add("Nivel")
            mdtHoldings.Columns.Add("DigitoVerif")
            Dim dtHoldings As DataTable
            dtHoldings = mobjSql.s_clientes_holding(mlngRut)
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                Dim drHoldings As DataRow
                For Each dr In dtHoldings.Rows
                    drHoldings = mdtHoldings.NewRow
                    drHoldings("RutFilial") = dr.Item(0)
                    drHoldings("Nombre") = dr.Item(1)
                    drHoldings("Nivel") = dr.Item(3)
                    drHoldings("DigitoVerif") = digito_verificador(dr.Item(0))
                    mdtHoldings.Rows.Add(drHoldings)
                Next
            End If

            mobjCuentaCap = New CCuenta
            mobjCuentaCap.inicializarCsql(mobjSql)
            mobjCuentaCap.Agno = mintAgno - 1
            mobjCuentaCap.Inicializar(lngRut, 1, mstrListaRutsHolding)
            lngVTAgnoAnt = mobjCuentaCap.SumaCargoVyT

            mobjCuentaCap = New CCuenta
            mobjCuentaCap.inicializarCsql(mobjSql)
            mobjCuentaCap.Agno = mintAgno
            mobjCuentaCap.Inicializar(lngRut, 1, mstrListaRutsHolding)

            'Se carga el valor del 10% como tope disponible para V&T
            If mobjCuentaCap.SumaAbono > 0 Then
                mlngDisponibleVTCap = CLng((mobjCuentaCap.SumaAbono) * 0.1)
            Else
                mlngDisponibleVTCap = 0
            End If

            mobjCuentaRep = New CCuenta
            Call mobjCuentaRep.inicializarCsql(mobjSql)
            mobjCuentaRep.Agno = mintAgno - 1
            Call mobjCuentaRep.Inicializar(lngRut, 2, mstrListaRutsHolding)
            lngVTRepAgnoAnt = mobjCuentaRep.SumaCargoVyT

            mobjCuentaRep = New CCuenta
            Call mobjCuentaRep.inicializarCsql(mobjSql)
            mobjCuentaRep.Agno = mintAgno
            Call mobjCuentaRep.Inicializar(lngRut, 2, mstrListaRutsHolding)

            mobjCuentaAdm = New CCuenta
            Call mobjCuentaAdm.inicializarCsql(mobjSql)
            mobjCuentaAdm.Agno = mintAgno
            Call mobjCuentaAdm.Inicializar(lngRut, 3, mstrListaRutsHolding)

            mobjCuentaExcCap = New CCuenta
            Call mobjCuentaExcCap.inicializarCsql(mobjSql)
            mobjCuentaExcCap.Agno = mintAgno
            Call mobjCuentaExcCap.Inicializar(lngRut, 4, mstrListaRutsHolding)

            'Se carga el valor del 10% como tope disponible para V&T menos lo utilizado
            If mobjCuentaExcCap.SumaAporte > 0 Then
                mlngDisponibleVTExcCap = CLng((mobjCuentaExcCap.SumaAporte * 0.1) - lngVTAgnoAnt)
                If mlngDisponibleVTExcCap < 0 Then
                    mlngDisponibleVTExcCap = 0
                End If
            Else
                mlngDisponibleVTExcCap = 0
            End If

            mobjCuentaExcRep = New CCuenta
            Call mobjCuentaExcRep.inicializarCsql(mobjSql)
            mobjCuentaExcRep.Agno = mintAgno
            Call mobjCuentaExcRep.Inicializar(lngRut, 5, mstrListaRutsHolding)

            'Se carga el valor del 10% como tope disponible para V&T menos lo utilizado
            If mobjCuentaExcRep.SumaAporte > 0 Then
                mlngDisponibleVTExcRep = CLng((mobjCuentaExcRep.SumaAporte * 0.1) - lngVTRepAgnoAnt)
                If mlngDisponibleVTExcRep < 0 Then
                    mlngDisponibleVTExcRep = 0
                End If
            Else
                mlngDisponibleVTExcRep = 0
            End If

            'Cuenta de Excedentes de 2 años que sólo sirven para pagar cursos complementarios(**|**)
            mobjCuentaBecas = New CCuenta
            Call mobjCuentaBecas.inicializarCsql(mobjSql)
            mobjCuentaBecas.Agno = mintAgno
            Call mobjCuentaBecas.Inicializar(lngRut, 6, mstrListaRutsHolding)

            'Cuenta Financiamiento Otic
            mObjCuentaFinanciamientoOtic = New CCuenta
            Call mObjCuentaFinanciamientoOtic.inicializarCsql(mobjSql)
            mObjCuentaFinanciamientoOtic.Agno = mintAgno
            Call mObjCuentaFinanciamientoOtic.Inicializar(lngRut, 7, mstrListaRutsHolding)

            ' Certificacion Competencias Laborales
            Me.mObjCuentaCertificacion = New CCuenta
            Call mObjCuentaCertificacion.inicializarCsql(mobjSql)
            mObjCuentaCertificacion.Agno = mintAgno
            Call mObjCuentaCertificacion.Inicializar(lngRut, 8, mstrListaRutsHolding)

            ' Certificacion Competencias Laborales
            Me.mObjCuentaExcCertificacion = New CCuenta
            Call mObjCuentaExcCertificacion.inicializarCsql(mobjSql)
            mObjCuentaExcCertificacion.Agno = mintAgno
            Call mObjCuentaExcCertificacion.Inicializar(lngRut, 9, mstrListaRutsHolding)

            mObjCuentaExcCon2008 = New CCuenta
            Call mObjCuentaExcCon2008.inicializarCsql(mobjSql)
            mObjCuentaExcCon2008.Agno = mintAgno
            Call mObjCuentaExcCon2008.Inicializar(lngRut, 10, mstrListaRutsHolding)

            mObjCuentaExcCon2009 = New CCuenta
            Call mObjCuentaExcCon2009.inicializarCsql(mobjSql)
            mObjCuentaExcCon2009.Agno = mintAgno
            Call mObjCuentaExcCon2009.Inicializar(lngRut, 11, mstrListaRutsHolding)

            If lngRut <= 0 Then
                mdblSaldoInicialCong2008 = mobjSql.s_saldo_inicial_congelados2008(mstrListaRutsHolding)
                mdblSaldoCargosCong2008 = mobjSql.s_cargos_congelados2008(mstrListaRutsHolding)
                mdblSaldoInicialCong2009 = mobjSql.s_saldo_inicial_congelados2009(mstrListaRutsHolding)
                mdblSaldoCargosCong2009 = mobjSql.s_cargos_congelados2009(mstrListaRutsHolding)
            Else
                mdblSaldoInicialCong2008 = mobjSql.s_saldo_inicial_congelados2008(lngRut)
                mdblSaldoCargosCong2008 = mobjSql.s_cargos_congelados2008(lngRut)
                mdblSaldoInicialCong2009 = mobjSql.s_saldo_inicial_congelados2009(lngRut)
                mdblSaldoCargosCong2009 = mobjSql.s_cargos_congelados2009(lngRut)
            End If
            mdblSaldoFinalCong2008 = mdblSaldoInicialCong2008 - mdblSaldoCargosCong2008
            mdblSaldoFinalCong2009 = mdblSaldoInicialCong2009 - mdblSaldoCargosCong2009

            'calculo del aporte pendiente (deuda con CST)
            mlngAportePendCap = -mobjCuentaCap.SumaSaldoPend
            If mlngAportePendCap < 0 Then mlngAportePendCap = 0
            mlngAportePendRep = -mobjCuentaRep.SumaSaldoPend
            If mlngAportePendRep < 0 Then mlngAportePendRep = 0
            mlngAportePendAdm = -mobjCuentaAdm.SumaSaldoPend
            If mlngAportePendAdm < 0 Then mlngAportePendAdm = 0

            'inicializar objeto con información adicional del cliente
            'mobjInfoCliente.Inicializar(mobjSql, mlngRut, mobjCuentaCap.SumaCargo, _
            'mobjCuentaExcCap.SumaCargo, mstrListaRutsHolding, mintAgno)
            mobjInfoCliente = Nothing

            'franquicia
            'mdtGraficoTortaCursosSence()
            Inicializar3 = True
        Catch ex As Exception
            EnviaError("" & ex.Message)
        End Try
    End Function

    'Inicializar2: Inicializa el objeto CCliente
    '              dentro de la BD.
    Public Sub Inicializar2(ByVal strRutotec As String, _
                            ByVal strNomFantasia As String, _
                            ByVal strRazonSocial As String, ByVal strSigla As String, _
                            ByVal strEmailOtec As String, ByVal strFonoOtec As String, _
                            ByVal strFono2Otec As String, ByVal strFax As String, _
                            ByVal strDireccion As String, ByVal lngCodComuna As Long, _
                            ByVal strCasilla As String, _
                            ByVal strSitioWeb As String, ByVal dblCostoAdmin As Double, _
                            ByVal intCodRubro As Integer, _
                            ByVal lngNumempleados As Long, _
                            ByVal strNomContacto As String, _
                            ByVal strCargoContacto As String, ByVal strFonoContacto As String, _
                            ByVal strAnexoContacto As String, ByVal strEmailContacto As String, _
                            ByVal strNomRep1 As String, ByVal strRutRep1 As String, _
                            ByVal strNomRep2 As String, ByVal strRutRep2 As String, _
                            ByVal strGerenteGral As String, ByVal strGerenteRRHH As String, _
                            ByVal strAreaCobranzas As String, ByVal strGiro As String, _
                            ByVal strCodActEconomica As String, ByVal lngRutEjecutivo As Long, _
                            ByVal intCompAdmNoLineal As Integer, ByVal intCodEstadoCliente As Integer, _
                            ByVal intCodSucursal As Integer, ByVal lngVentaAnual As Long, _
                            ByVal strEmailGteRRHH As String, _
                            ByVal strGerenteFinanzas As String, ByVal strEmailGteFinanzas As String, _
                            ByVal strFonoCobranzas As String, ByVal strRutHolding As String, _
                            ByVal strCiudad As String, ByVal strNroDireccion As String, _
                            ByVal strClaveWebService As String, ByVal strEtiquetaClasificador As String, _
                            ByVal lngRutContacto As Long, ByVal strApellidoContacto As String)

        Try
            QuitarFormato(strRutotec, "Otec")
            mstrNomFantasia = strNomFantasia
            mstrRazonSocial = strRazonSocial
            mstrSigla = strSigla
            mstrEmailOtec = strEmailOtec
            mstrFonoOtec = strFonoOtec
            mstrFono2Otec = strFono2Otec
            mstrFax = strFax
            mstrDireccion = strDireccion
            mlngCodComuna = lngCodComuna
            mstrCasilla = strCasilla
            mstrSitioWeb = strSitioWeb

            'valores que seran insertados en empresa_cliente
            mdblCostoAdm = dblCostoAdmin
            mintCodRubro = intCodRubro
            'Codigo estado Cliente
            mintCodEstadoCliente = intCodEstadoCliente

            mlngNumempleados = lngNumempleados
            mlngRutContacto = lngRutContacto
            mstrContacto = strNomContacto
            mstrApellidoContacto = strApellidoContacto
            mstrCargo = strCargoContacto
            mstrFonoContacto = strFonoContacto
            mstrAnexoContacto = strAnexoContacto
            mstrEmailContacto = strEmailContacto
            mstrRep1 = strNomRep1


            If strRutRep1 <> "" Then
                Call QuitarFormato(strRutRep1, "Rep1")
            Else
                mlngRutRep1 = -1
                mstrDigitoRep1 = ""
            End If
            mstrRep2 = strNomRep2
            If strRutRep2 <> "" Then
                Call QuitarFormato(strRutRep2, "Rep2")
            Else
                mlngRutRep2 = -1
                mstrRep2 = ""
            End If
            mstrGerenteGral = strGerenteGral
            mstrGerenteRRHH = strGerenteRRHH
            mstrAreaCobranzas = strAreaCobranzas
            mstrGiro = strGiro
            mstrCodActEconomica = strCodActEconomica
            mlngRutEjecutivo = lngRutEjecutivo
            mintCodSucursal = intCodSucursal
            mlngVentaAnual = lngVentaAnual


            mstrEmailGteRRHH = strEmailGteRRHH
            mstrGerenteFinanzas = strGerenteFinanzas
            mstrEmailGteFinanzas = strEmailGteFinanzas
            mstrFonoCobranzas = strFonoCobranzas


            If strRutHolding <> "" Then
                Call QuitarFormato(strRutHolding, "RutHolding")
            Else
                mlngRutHolding = -1
            End If

            mintCompAdmNoLineal = intCompAdmNoLineal
            '------------------------------------------------
            mstrNroDireccion = strNroDireccion
            mstrCiudad = strCiudad
            '------------------------------------------------
            mstrClaveWebService = strClaveWebService

            mstrEtiquetaClasificador = strEtiquetaClasificador

            Call GrabarDatos()
        Catch ex As Exception

        End Try
    End Sub

    'Graba la informacion en las tablas persona, persona_juridica , empresa_cliente y ejecutivo
    Private Sub GrabarDatos()
        Try
            'abrir transaccion
            Call mobjSql.InicioTransaccion()

            If Not mobjSql.ExisteRegistro(mlngRut, "Persona", "rut") Then
                mobjSql.i_Persona(mlngRut, mstrDigitoOtec, "J")
            End If

            If mobjSql.ExisteRegistro(mlngRut, "Persona", "rut") Then
                If Not mobjSql.ExisteRegistro(mlngRut, "Persona_juridica", "rut") Then
                    Call mobjSql.i_Persona_Juridica(mlngRut, mstrNomFantasia, _
                                            mstrRazonSocial, mstrSigla, _
                                            mstrEmailOtec, mstrFonoOtec, _
                                            mstrFono2Otec, mstrFax, _
                                            mstrDireccion, mlngCodComuna, _
                                            mstrCasilla, mstrCiudad, mstrSitioWeb, mstrNroDireccion)

                    Call mobjSql.i_Empresa_Cliente(mlngRut, mdblCostoAdm, _
                                            mintCompAdmNoLineal, mintCodRubro, _
                                            mlngNumempleados, _
                                            mstrContacto, _
                                            mstrCargo, mstrFonoContacto, mstrAnexoContacto, _
                                            mstrEmailContacto, mstrRep1, mlngRutRep1, _
                                            mstrDigitoRep1, mstrRep2, mlngRutRep2, _
                                            mstrDigitoRep2, mstrGerenteGral, mstrGerenteRRHH, _
                                            mstrAreaCobranzas, mstrGiro, mstrCodActEconomica, _
                                            mintCodEstadoCliente, mintCodSucursal, mlngVentaAnual, _
                                            mstrEmailGteRRHH, mstrGerenteFinanzas, _
                                            mstrEmailGteFinanzas, mstrFonoCobranzas, mlngRutHolding, _
                                            mstrClaveWebService, mstrEtiquetaClasificador, mstrObservacion, _
                                             mlngRutContacto, mstrApellidoContacto)


                Else
                    'actualiza persona juridica
                    Call mobjSql.u_Persona_Juridica(mlngRut, mstrNomFantasia, _
                                              mstrRazonSocial, mstrSigla, _
                                              mstrEmailOtec, mstrFonoOtec, _
                                              mstrFono2Otec, mstrFax, _
                                              mstrDireccion, mlngCodComuna, _
                                              mstrCasilla, mstrSitioWeb, mstrCiudad, mstrNroDireccion)
                    If Not mobjSql.ExisteRegistro(mlngRut, "Empresa_Cliente", "rut") Then
                        'inserta en empresa_cliente
                        Call mobjSql.i_Empresa_Cliente(mlngRut, mdblCostoAdm, _
                                            mintCompAdmNoLineal, mintCodRubro, _
                                            mlngNumempleados, _
                                            mstrContacto, _
                                            mstrCargo, mstrFonoContacto, mstrAnexoContacto, _
                                            mstrEmailContacto, mstrRep1, mlngRutRep1, _
                                            mstrDigitoRep1, mstrRep2, mlngRutRep2, _
                                            mstrDigitoRep2, mstrGerenteGral, mstrGerenteRRHH, _
                                            mstrAreaCobranzas, mstrGiro, mstrCodActEconomica, _
                                            mintCodEstadoCliente, mintCodSucursal, mlngVentaAnual, _
                                            mstrEmailGteRRHH, mstrGerenteFinanzas, _
                                            mstrEmailGteFinanzas, mstrFonoCobranzas, mlngRutHolding, _
                                            mstrClaveWebService, mstrEtiquetaClasificador, mstrObservacion, _
                                             mlngRutContacto, mstrApellidoContacto)
                    End If
                End If
            End If

            If mobjSql.ExisteRegistro(mlngRut, "Persona_Juridica", "rut") Then
                Call mobjSql.i_ejecutivo(mlngRut, mlngRutEjecutivo)
            End If


            'Dim i
            Dim dtCuentas As DataTable
            dtCuentas = mobjSql.s_cuenta_todos
            'inserta en tabla cuenta_cliente n registros segun la cantidad de cuentas existentes
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtCuentas.Rows
                    mobjSql.i_CuentaCliente(mlngRut, dr.Item(0))
                Next
            End If

            'Inserta Registro en Bitacora
            mstrObservacion = "Ingreso Nuevo Registro cliente: " & RutLngAUsr(mlngRut)
            mobjSql.i_bitacora(mlngRutUsuario, "Ingreso", mstrObservacion, 5, mlngRut)

            'cerrar transaccion
            mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
        End Try
    End Sub

    'Permite Modificar los datos existentes en persona_juridica , empresa_cliente
    Public Sub Inicializar3(ByVal strRutotec As String, ByVal strNomFantasia As String, _
                            ByVal strRazonSocial As String, ByVal strSigla As String, _
                            ByVal strEmailOtec As String, ByVal strFonoOtec As String, _
                            ByVal strFono2Otec As String, ByVal strFax As String, _
                            ByVal strDireccion As String, ByVal lngCodComuna As Long, _
                            ByVal strCasilla As String, ByVal strSitioWeb As String, _
                            ByVal dblCostoAdmin As Double, ByVal intCompAdmNoLineal As Integer, _
                            ByVal intCodRubro As Integer, ByVal lngNumempleados As Long, _
                            ByVal strNomContacto As String, ByVal strCargoContacto As String, _
                            ByVal strFonoContacto As String, ByVal strAnexoContacto As String, _
                            ByVal strEmailContacto As String, ByVal strNomRep1 As String, _
                            ByVal strRutRep1 As String, ByVal strNomRep2 As String, _
                            ByVal strRutRep2 As String, ByVal strGerenteGral As String, _
                            ByVal strGerenteRRHH As String, ByVal strAreaCobranzas As String, _
                            ByVal strGiro As String, ByVal strCodActEconomica As String, _
                            ByVal lngRutEjecutivo As Long, ByVal intCodEstadoCliente As Integer, _
                            ByVal intCodSucursal As Integer, ByVal lngVentaAnual As Long, _
                            ByVal strEmailGteRRHH As String, _
                            ByVal strGerenteFinanzas As String, ByVal strEmailGteFinanzas As String, _
                            ByVal strFonoCobranzas As String, ByVal strRutHolding As String, _
                            ByVal strObservacion As String, ByVal strCiudad As String, ByVal strNroDireccion As String, _
                            ByVal strClaveWebService As String, ByVal strEtiquetaClasificador As String, _
                            ByVal lngRutContacto As Long, ByVal strApellidoContacto As String)
        Try
            Dim lngRutOtec As Long
            lngRutOtec = RutUsrALng(strRutotec)
            'valores que seran insertados en persona_juridica
            mlngRut = lngRutOtec
            mstrNomFantasia = strNomFantasia
            mstrRazonSocial = strRazonSocial
            mstrSigla = strSigla
            mstrEmailOtec = strEmailOtec
            mstrFonoOtec = strFonoOtec
            mstrFono2Otec = strFono2Otec
            mstrFax = strFax
            mstrDireccion = strDireccion
            mlngCodComuna = lngCodComuna
            mstrCasilla = strCasilla
            mstrSitioWeb = strSitioWeb

            'valores que seran insertados en empresa_cliente
            mdblCostoAdm = dblCostoAdmin
            mintCompAdmNoLineal = intCompAdmNoLineal
            mintCodRubro = intCodRubro
            'Codigo del estado del cliente ==> 1 Activo / 0 Inactivo
            mintCodEstadoCliente = intCodEstadoCliente

            mlngNumempleados = lngNumempleados
            mlngRutContacto = lngRutContacto
            mstrContacto = strNomContacto
            mstrApellidoContacto = strApellidoContacto
            mstrCargo = strCargoContacto
            mstrFonoContacto = strFonoContacto
            mstrAnexoContacto = strAnexoContacto
            mstrEmailContacto = strEmailContacto
            mstrRep1 = strNomRep1

            'le quita el formato al rut que viene como 13.220.307-5 pasar a ==>13220307
            If strRutRep1 <> "" Then
                Call QuitarFormato(strRutRep1, "Rep1")
            Else
                mlngRutRep1 = -1
                mstrDigitoRep1 = ""
            End If

            mstrRep2 = strNomRep2
            If strRutRep2 <> "" Then
                Call QuitarFormato(strRutRep2, "Rep2")
            Else
                mlngRutRep2 = -1
                mstrRep2 = ""
            End If
            mstrGerenteGral = strGerenteGral
            mstrGerenteRRHH = strGerenteRRHH
            mstrAreaCobranzas = strAreaCobranzas
            mstrGiro = strGiro
            mstrCodActEconomica = strCodActEconomica
            mlngRutEjecutivo = lngRutEjecutivo
            mintCodSucursal = intCodSucursal
            mlngVentaAnual = lngVentaAnual

            mstrEmailGteRRHH = strEmailGteRRHH
            mstrGerenteFinanzas = strGerenteFinanzas
            mstrEmailGteFinanzas = strEmailGteFinanzas
            mstrFonoCobranzas = strFonoCobranzas

            'le quita el formato al rut Holding que viene como 13.220.307-5 pasar a ==>13220307
            If strRutHolding <> "" Then
                Call QuitarFormato(strRutHolding, "RutHolding")
            Else
                mlngRutHolding = -1
            End If

            mstrObservacion = strObservacion
            '--------------------------------------
            mstrNroDireccion = strNroDireccion
            mstrCiudad = strCiudad
            '--------------------------------------

            mstrClaveWebService = strClaveWebService
            mstrEtiquetaClasificador = strEtiquetaClasificador

            ModificarDatos()
        Catch ex As Exception

        End Try
    End Sub

    'Recibe un rut con formato xx.xxx.xxx-x
    'y le asigna a las variables del modulo rut el numero sin formato
    Private Sub QuitarFormato(ByVal strRut As String, _
                              ByVal Nombre As String)

        Dim posicion, largo, i As Integer
        Dim ValorRut, digito As String

        largo = Len(strRut)
        posicion = 0
        ValorRut = ""
        For i = 1 To largo
            posicion = InStr(posicion + 1, strRut, ".")
            If posicion = 0 Then
                posicion = InStr(posicion + 1, strRut, "-")
                ValorRut = ValorRut + Mid(strRut, 1, posicion - 1)
                digito = CStr(Mid(strRut, Len(strRut), 1))
                Exit For
            Else
                ValorRut = ValorRut + Mid(strRut, 1, posicion - 1)
                strRut = Mid(strRut, posicion + 1, largo)
            End If
        Next
        If Nombre = "Rep1" Then
            mlngRutRep1 = CLng(ValorRut)
            mstrDigitoRep1 = CStr(digito)
        End If
        If Nombre = "Rep2" Then
            mlngRutRep2 = CLng(ValorRut)
            mstrDigitoRep2 = CStr(digito)
        End If
        If Nombre = "Otec" Then
            mlngRut = CLng(ValorRut)
            mstrDigitoOtec = CStr(digito)
        End If
        If Nombre = "RutHolding" Then
            mlngRutHolding = CLng(ValorRut)
        End If
    End Sub

    'Permite actualizar información en las tablas persona_juridica, empresa_cliente y ejecutivo
    Private Sub ModificarDatos()
        Try
            'abrir conexion y transaccion
            Call mobjSql.InicioTransaccion()

            mobjSql.u_Persona_Juridica(mlngRut, mstrNomFantasia, _
                                            mstrRazonSocial, mstrSigla, _
                                            mstrEmailOtec, mstrFonoOtec, _
                                            mstrFono2Otec, mstrFax, _
                                            mstrDireccion, mlngCodComuna, _
                                            mstrCasilla, mstrSitioWeb, mstrCiudad, mstrNroDireccion)

            mobjSql.u_Empresa_Cliente(mlngRut, mdblCostoAdm, _
                                            mintCompAdmNoLineal, mintCodRubro, _
                                            mlngNumempleados, _
                                            mstrContacto, _
                                            mstrCargo, mstrFonoContacto, mstrAnexoContacto, _
                                            mstrEmailContacto, mstrRep1, mlngRutRep1, _
                                            mstrDigitoRep1, mstrRep2, mlngRutRep2, _
                                            mstrDigitoRep2, mstrGerenteGral, mstrGerenteRRHH, _
                                            mstrAreaCobranzas, mstrGiro, mstrCodActEconomica, _
                                            mintCodEstadoCliente, mintCodSucursal, mlngVentaAnual, _
                                            mstrEmailGteRRHH, mstrGerenteFinanzas, _
                                            mstrEmailGteFinanzas, mstrFonoCobranzas, mlngRutHolding, _
                                            mstrClaveWebService, mstrEtiquetaClasificador, mstrObservacion, _
                                             mlngRutContacto, mstrApellidoContacto)

            mobjSql.d_ejecutivo(mlngRut)
            mobjSql.i_ejecutivo(mlngRut, mlngRutEjecutivo)
            mobjSql.i_bitacora(mlngRutUsuario, "Modificado", mstrObservacion, 5, mlngRut)

            'cerrar transaccion
            mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("" & ex.Message)
        End Try
    End Sub

    'Recibe el rut como string formateado y lo transforma  a long para llamar a inicializar1
    Public Function Inicializar4(ByVal strRut As String) As Boolean
        Try
            Dim Rut As Long
            Rut = RutUsrALng(strRut)
            Inicializar4 = Inicializar1(Rut)
            Exit Function
        Catch ex As Exception

        End Try
    End Function

    'Retorna true si el rut recibido pertenece a un cliente
    Public Function EsCliente(ByVal lngRut As Long, Optional ByVal strRut As String = "") As Boolean
        Try
            Dim dtOtec As DataTable
            If lngRut = -1 Then lngRut = RutUsrALng(strRut)
            dtOtec = mobjSql.s_persona_juridica2(lngRut)
            If mobjSql.Registros = 0 Then
                EsCliente = False
            Else
                EsCliente = True
            End If
            Exit Function
        Catch ex As Exception

        End Try
    End Function

    Public ReadOnly Property certificadoAportes() As CClienteAportes
        Get
            If mobjAportes Is Nothing Then
                mobjAportes = New CClienteAportes
                mobjAportes.Inicializar(mobjSql)
            End If
            mobjAportes.Consultar(mintAgno, mlngRut)
            certificadoAportes = mobjAportes
        End Get
    End Property
End Class
