Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorEmpresas
    Implements IMantenedor
    Private mobjCsql As CSql
    Private mlngFilas As Long
    Private mlngRutUsuario As Long
    Private mlngRut As Long
    Private mstrDigito As String
    Private mstrRazonSocial As String
    Private mstrNomFantasia As String
    Private mstrSigla As String
    Private mlngRutHolding As Long
    Private mstrDireccion As String
    Private mstrNroDireccion As String
    Private mstrCiudad As String
    Private mlngCodComuna As Long
    Private mstrSitioWeb As String
    Private mstrFono1 As String
    Private mstrFono2 As String
    Private mstrFax As String
    Private mstrEmail As String
    Private mstrCasilla As String
    'Sucursal
    Private mlngCodSucursal As Long
    Private mstrSucursal As String
    'Ejecutivo
    Private mlngRutEjecutivo As Long
    Private mstrNomEjecutivo As String
    'Datos franquicia tributaria 
    Private mlngNumEmpleados As Long
    Private mdblCostoAdm As Double  'Tasa administración
    Private mstrObservacion As String
    Private mobjCliente As CCliente
    'Contacto principal
    Private mstrContacto As String
    Private mstrCargo As String
    Private mstrFonoContacto As String
    Private mstrAnexoContacto As String
    Private mstrEmailContacto As String
    Private mstrAreaCobranzas As String
    Private mstrFonoCobranzas As String
    Private mlngRutContacto As Long
    Private mstrApellidoContacto As String
    'Representante legal 1
    Private mstrNombreRep1 As String
    Private mlngRutRep1 As Long
    Private mstrDigitoRep1 As String
    'Representante legal 2
    Private mstrNombreRep2 As String
    Private mlngRutRep2 As Long
    Private mstrDigitoRep2 As String
    'Otros contactos
    Private mstrGerenteGral As String
    Private mstrGerenteRRHH As String
    Private mstrEmailGteRRHH As String
    Private mstrGerenteFinanzas As String
    Private mstrEmailGteFinanzas As String
    'Actividad
    Private mstrGiro As String
    Private mstrCodActEconomica As String
    Private mlngCodRubro As Long
    Private mlngAdmNoLineal As Long
    Private mlngCodEstadoCliente As Long
    Private mlngVentaAnual As Long
    Private mstrClaveWebService As String
    Private mstrEtiquetaClasificador As String
    'lookUp
    Private mdtLookUpComunas As DataTable
    Private mdtLookUpRegiones As DataTable
    Private mdtLookUpRubros As DataTable
    Private mdtLookUpSucursales As DataTable
    Private mdtLookUpAdmNoLineal As DataTable
    Private mdtLookUpEjecutivos As DataTable
    Private mdtLookUpEstadoCliente As DataTable
    Private mlngFranquiciaActual As Long

    Private mstrXml As String
    'Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property
    Public Property FranquiciaActual() As Long
        Get
            Return mlngFranquiciaActual
        End Get
        Set(ByVal value As Long)
            mlngFranquiciaActual = value
        End Set
    End Property
    Public ReadOnly Property LookUpComunas() As DataTable
        Get
            Return mdtLookUpComunas
        End Get
    End Property
    Public ReadOnly Property LookUpRegiones() As DataTable
        Get
            Return mdtLookUpRegiones
        End Get
    End Property
    Public ReadOnly Property LookUpRubros() As DataTable
        Get
            Return mdtLookUpRubros
        End Get
    End Property
    Public ReadOnly Property LookUpSucursales() As DataTable
        Get
            Return mdtLookUpSucursales
        End Get
    End Property
    Public ReadOnly Property LookUpAdmNoLineal() As DataTable
        Get
            Return mdtLookUpAdmNoLineal
        End Get
    End Property
    Public ReadOnly Property LookUpEjecutivos() As DataTable
        Get
            Return mdtLookUpEjecutivos
        End Get
    End Property
    Public ReadOnly Property LookUpEstadoCliente() As DataTable
        Get
            Return mdtLookUpEstadoCliente
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
    'Rut del cliente
    Public Property Rut() As String
        Get
            If mlngRut = -1 Then
                Return ""
            Else
                Return RutLngAUsr(mlngRut)
            End If
        End Get
        Set(ByVal value As String)
            mlngRut = RutUsrALng(value)
        End Set
    End Property
    'Razon Social
    Public Property RazonSocial() As String
        Get
            Return mstrRazonSocial
        End Get
        Set(ByVal value As String)
            mstrRazonSocial = value
        End Set
    End Property
    'nombre Fantasia empresa
    Public Property NombreFantasia() As String
        Get
            Return mstrNomFantasia
        End Get
        Set(ByVal value As String)
            mstrNomFantasia = value
        End Set
    End Property
    Public Property Sigla() As String
        Get
            Return mstrSigla
        End Get
        Set(ByVal value As String)
            mstrSigla = value
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
    Public Property Direccion() As String
        Get
            Return mstrDireccion
        End Get
        Set(ByVal value As String)
            mstrDireccion = value
        End Set
    End Property
    Public Property NroDireccion() As String
        Get
            Return mstrNroDireccion
        End Get
        Set(ByVal value As String)
            mstrNroDireccion = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return mstrCiudad
        End Get
        Set(ByVal value As String)
            mstrCiudad = value
        End Set
    End Property
    Public Property CodComuna() As Long
        Get
            Return mlngCodComuna
        End Get
        Set(ByVal value As Long)
            mlngCodComuna = value
        End Set
    End Property
    Public Property SitioWeb() As String
        Get
            Return mstrSitioWeb
        End Get
        Set(ByVal value As String)
            mstrSitioWeb = value
        End Set
    End Property
    Public Property Fono1() As String
        Get
            Return mstrFono1
        End Get
        Set(ByVal value As String)
            mstrFono1 = value
        End Set
    End Property
    Public Property Fono2() As String
        Get
            Return mstrFono2
        End Get
        Set(ByVal value As String)
            mstrFono2 = value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return mstrFax
        End Get
        Set(ByVal value As String)
            mstrFax = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mstrEmail
        End Get
        Set(ByVal value As String)
            mstrEmail = value
        End Set
    End Property
    Public Property Casilla() As String
        Get
            Return mstrCasilla
        End Get
        Set(ByVal value As String)
            mstrCasilla = value
        End Set
    End Property
    Public Property CodSucursal() As Long
        Get
            Return mlngCodSucursal
        End Get
        Set(ByVal value As Long)
            mlngCodSucursal = value
        End Set
    End Property
    Public Property Sucursal() As String
        Get
            Return mstrSucursal
        End Get
        Set(ByVal value As String)
            mstrSucursal = value
        End Set
    End Property
    Public Property RutEjecutivo() As Long
        Get
            Return mlngRutEjecutivo
        End Get
        Set(ByVal value As Long)
            mlngRutEjecutivo = value
        End Set
    End Property
    Public Property NombreEjecutivo() As String
        Get
            Return mstrNomEjecutivo
        End Get
        Set(ByVal value As String)
            mstrNomEjecutivo = value
        End Set
    End Property
    Public Property NumEmpleados() As Long
        Get
            Return mlngNumEmpleados
        End Get
        Set(ByVal value As Long)
            mlngNumEmpleados = value
        End Set
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
    Public Property Cargo() As String
        Get
            Return mstrCargo
        End Get
        Set(ByVal value As String)
            mstrCargo = value
        End Set
    End Property
    Public Property FonoCargo() As String
        Get
            Return mstrFonoContacto
        End Get
        Set(ByVal value As String)
            mstrFonoContacto = value
        End Set
    End Property
    Public Property AnexoContacto() As String
        Get
            Return mstrAnexoContacto
        End Get
        Set(ByVal value As String)
            mstrAnexoContacto = value
        End Set
    End Property
    Public Property EmailContacto() As String
        Get
            Return mstrEmailContacto
        End Get
        Set(ByVal value As String)
            mstrEmailContacto = value
        End Set
    End Property
    Public Property AreaCobranzas() As String
        Get
            Return mstrAreaCobranzas
        End Get
        Set(ByVal value As String)
            mstrAreaCobranzas = value
        End Set
    End Property
    Public Property FonoCobranzas() As String
        Get
            Return mstrFonoCobranzas
        End Get
        Set(ByVal value As String)
            mstrFonoCobranzas = value
        End Set
    End Property
    Public Property NombreRepresentante1() As String
        Get
            Return mstrNombreRep1
        End Get
        Set(ByVal value As String)
            mstrNombreRep1 = value
        End Set
    End Property
    Public Property RutRepresentante1() As Long
        Get
            Return mlngRutRep1
        End Get
        Set(ByVal value As Long)
            mlngRutRep1 = value
        End Set
    End Property
    Public Property NombreRepresentante2() As String
        Get
            Return mstrNombreRep2
        End Get
        Set(ByVal value As String)
            mstrNombreRep2 = value
        End Set
    End Property
    Public Property RutRepresentante2() As Long
        Get
            Return mlngRutRep2
        End Get
        Set(ByVal value As Long)
            mlngRutRep2 = value
        End Set
    End Property
    'Gerente General
    Public Property GerenteGeneral() As String
        Get
            Return mstrGerenteGral
        End Get
        Set(ByVal value As String)
            mstrGerenteGral = value
        End Set
    End Property
    'Gerente Recursos Humanos
    Public Property GerenteRRHH() As String
        Get
            Return mstrGerenteRRHH
        End Get
        Set(ByVal value As String)
            mstrGerenteRRHH = value
        End Set
    End Property
    'email Gerente Recursos Humanos
    Public Property EmailGerenteRRHH() As String
        Get
            Return mstrEmailGteRRHH
        End Get
        Set(ByVal value As String)
            mstrEmailGteRRHH = value
        End Set
    End Property
    'Gerente Finanzas
    Public Property GerenteFinanzas() As String
        Get
            Return mstrGerenteFinanzas
        End Get
        Set(ByVal value As String)
            mstrGerenteFinanzas = value
        End Set
    End Property
    'email Gerente Finanzas
    Public Property EmailGerenteFinanzas() As String
        Get
            Return mstrEmailGteFinanzas
        End Get
        Set(ByVal value As String)
            mstrEmailGteFinanzas = value
        End Set
    End Property
    'Costo Administracion
    Public Property CostoAdm() As Double
        Get
            If mdblCostoAdm >= 0 And mdblCostoAdm <= 1 Then
                CostoAdm = mdblCostoAdm * 100
            ElseIf mdblCostoAdm > 1 Then
                CostoAdm = mdblCostoAdm
            End If
        End Get
        Set(ByVal value As Double)
            mdblCostoAdm = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return mstrObservacion
        End Get
        Set(ByVal value As String)
            mstrObservacion = value
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
    Public Property CodActEconomica() As String
        Get
            Return mstrCodActEconomica
        End Get
        Set(ByVal value As String)
            mstrCodActEconomica = value
        End Set
    End Property
    Public Property Rubro() As Long
        Get
            Return mlngCodRubro
        End Get
        Set(ByVal value As Long)
            mlngCodRubro = value
        End Set
    End Property
    Public Property AdmNoLineal() As Long
        Get
            Return mlngAdmNoLineal
        End Get
        Set(ByVal value As Long)
            mlngAdmNoLineal = value
        End Set
    End Property
    Public Property CodEstadoCliente() As Long
        Get
            Return mlngCodEstadoCliente
        End Get
        Set(ByVal value As Long)
            mlngCodEstadoCliente = value
        End Set
    End Property
    Public Property VentaAnual() As Long
        Get
            Return mlngVentaAnual
        End Get
        Set(ByVal value As Long)
            mlngVentaAnual = value
        End Set
    End Property
    Public Property ClaveWebService() As String
        Get
            ClaveWebService = DecryptINI$(mstrClaveWebService)
        End Get
        Set(ByVal value As String)
            mstrClaveWebService = DecryptINI$(value)
        End Set
    End Property
    Public Property EtiquetaClasificador() As String
        Get
            Return mstrEtiquetaClasificador
        End Get
        Set(ByVal value As String)
            mstrEtiquetaClasificador = value
        End Set
    End Property
    Public Sub ConsultaCliente()
        Try
            mobjCsql = New CSql
            mobjCliente = New CCliente
            mobjCliente.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCliente.Inicializar1(RutLngAUsr(mlngRut))
            mlngFranquiciaActual = mobjCliente.ObjInfoAdicional.FranquiciaActual
            mobjCliente = Nothing
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql = Nothing
        End Try
    End Sub
    Public Function ConsultaActualizacion() As DataTable
        Dim dtConsulta As DataTable
        Dim dtEjecutivo As DataTable
        Try
            mobjCsql = New CSql
            dtConsulta = mobjCsql.s_persona_juridica2(mlngRut)
            If Not dtConsulta Is Nothing Then
                Me.mlngFilas = Me.mobjCsql.Registros
                If Me.mlngFilas > 0 Then
                    'Datos generales
                    mlngRut = dtConsulta.Rows(0)("RutEmpresa")
                    mstrRazonSocial = dtConsulta.Rows(0)("razon_social")
                    mstrNomFantasia = dtConsulta.Rows(0)("nom_fantasia")
                    mstrSigla = dtConsulta.Rows(0)("sigla")
                    mlngRutHolding = dtConsulta.Rows(0)("rut_holding")
                    mstrDireccion = dtConsulta.Rows(0)("direccion")
                    mstrNroDireccion = dtConsulta.Rows(0)("nro_direccion")
                    mstrCiudad = dtConsulta.Rows(0)("ciudad")
                    mlngCodComuna = dtConsulta.Rows(0)("cod_comuna")
                    mstrSitioWeb = dtConsulta.Rows(0)("SitioWeb")
                    mstrFono1 = dtConsulta.Rows(0)("fono")
                    mstrFono2 = dtConsulta.Rows(0)("fono2")
                    mstrFax = dtConsulta.Rows(0)("fax")
                    mstrEmail = dtConsulta.Rows(0)("email")
                    mstrCasilla = dtConsulta.Rows(0)("casilla")
                    mlngCodSucursal = dtConsulta.Rows(0)("cod_sucursal")
                    dtEjecutivo = mobjCsql.s_ejecutivo(mlngRut)
                    mlngRutEjecutivo = dtEjecutivo.Rows(0)("rut_ejecutivo")
                    'Franquicia tributaria
                    mlngNumEmpleados = dtConsulta.Rows(0)("num_empleados")
                    mdblCostoAdm = dtConsulta.Rows(0)("costo_admin")
                    'Contacto principal
                    mstrContacto = dtConsulta.Rows(0)("nom_contacto")
                    mstrCargo = dtConsulta.Rows(0)("cargo_contacto")
                    mstrFonoContacto = dtConsulta.Rows(0)("fono_contacto")
                    mstrAnexoContacto = dtConsulta.Rows(0)("anexo_contacto")
                    mstrEmailContacto = dtConsulta.Rows(0)("email_contacto")
                    mstrAreaCobranzas = dtConsulta.Rows(0)("area_cobranzas")
                    mstrFonoCobranzas = dtConsulta.Rows(0)("fono_cobranzas")
                    mlngRutContacto = dtConsulta.Rows(0)("rut_contacto")
                    mstrApellidoContacto = dtConsulta.Rows(0)("apellido_contacto")
                    'Representantes legales
                    mstrNombreRep1 = dtConsulta.Rows(0)("nom_rep1")
                    mstrNombreRep2 = dtConsulta.Rows(0)("nom_rep2")
                    mlngRutRep1 = dtConsulta.Rows(0)("rut_rep1")
                    mlngRutRep2 = dtConsulta.Rows(0)("rut_rep2")
                    'Otros contactos
                    mstrGerenteGral = dtConsulta.Rows(0)("gerente_general")
                    mstrGerenteRRHH = dtConsulta.Rows(0)("gerente_rrhh")
                    mstrEmailGteRRHH = dtConsulta.Rows(0)("email_gerente_rrhh")
                    mstrGerenteFinanzas = dtConsulta.Rows(0)("gerente_finanzas")
                    mstrEmailGteFinanzas = dtConsulta.Rows(0)("email_gerente_finanzas")
                    'Actividad
                    mstrGiro = dtConsulta.Rows(0)("giro")
                    mstrCodActEconomica = dtConsulta.Rows(0)("cod_act_economica")
                    mlngCodRubro = dtConsulta.Rows(0)("cod_rubro")
                    mlngAdmNoLineal = dtConsulta.Rows(0)("comp_adm_no_lineal")
                    mlngCodEstadoCliente = dtConsulta.Rows(0)("cod_estado_cliente")
                    mlngVentaAnual = dtConsulta.Rows(0)("ventas_anuales")
                    'Otros
                    mstrClaveWebService = dtConsulta.Rows(0)("clave_web_service")
                    mstrEtiquetaClasificador = dtConsulta.Rows(0)("etiqueta_clasificador")
                    mstrObservacion = dtConsulta.Rows(0)("Observacion")

                End If
            End If
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql = Nothing
        End Try
    End Function
    Sub Carga_Lookup()
        mobjCsql = New CSql
        mdtLookUpComunas = mobjCsql.s_comunas_todos
        mdtLookUpRegiones = mobjCsql.s_regiones_todos
        mdtLookUpRubros = mobjCsql.s_rubros_todos
        mdtLookUpSucursales = mobjCsql.s_sucursales_todos
        mdtLookUpAdmNoLineal = New DataTable
        mdtLookUpAdmNoLineal.columns.add("CodTipoAdm")
        mdtLookUpAdmNoLineal.columns.add("NomTipoAdm")
        Dim dr As DataRow
        dr = mdtLookUpAdmNoLineal.NewRow
        dr("CodTipoAdm") = 1
        dr("NomTipoAdm") = "No Lineal"
        mdtLookUpAdmNoLineal.Rows.Add(dr)
        dr = mdtLookUpAdmNoLineal.NewRow
        dr("CodTipoAdm") = 0
        dr("NomTipoAdm") = "Lineal"
        mdtLookUpAdmNoLineal.Rows.Add(dr)
        mdtLookUpEjecutivos = mobjCsql.s_ejecutivo_todos
        'Estado del Cliente Activo o Inactivo
        mdtLookUpEstadoCliente = mobjCsql.s_estados_cliente
        mobjCsql = Nothing
    End Sub
    Public Function Consultar() As System.Data.DataTable Implements Clases.IMantenedor.Consultar
        Dim dtConsulta As DataTable
        Try
            mobjCsql = New CSql
            Dim strNombreArchivo As String
            dtConsulta = mobjCsql.s_persona_juridica(mlngRut, mstrNomFantasia, mstrRazonSocial, mlngRutEjecutivo)

            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtConsulta.TableName = "Reporte Empresa"
                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If
            Return dtConsulta
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql = Nothing
            EnviaError("CMantenedorEmpresas:Consultar->" & ex.Message)
        End Try
    End Function
    Public Function Insertar() As Boolean Implements Clases.IMantenedor.Insertar
        Try
            QuitarFormato(RutLngAUsr(mlngRut), "Empresa")
            If RutLngAUsr(mlngRutRep1) <> "" Then
                Call QuitarFormato(RutLngAUsr(mlngRutRep1), "Rep1")
            Else
                mlngRutRep1 = -1
                mstrDigitoRep1 = ""
            End If
            If RutLngAUsr(mlngRutRep2) <> "" Then
                Call QuitarFormato(RutLngAUsr(mlngRutRep2), "Rep2")
            Else
                mlngRutRep2 = -1
                mstrDigitoRep2 = ""
            End If
            If RutLngAUsr(mlngRutHolding) <> "" Then
                Call QuitarFormato(RutLngAUsr(mlngRutHolding), "RutHolding")
            Else
                mlngRutHolding = -1
            End If
            GrabarDatos()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Actualizar() As Boolean Implements Clases.IMantenedor.Actualizar
        Try
            QuitarFormato(RutLngAUsr(mlngRut), "Empresa")
            If RutLngAUsr(mlngRutRep1) <> "" Then
                Call QuitarFormato(RutLngAUsr(mlngRutRep1), "Rep1")
            Else
                mlngRutRep1 = -1
                mstrDigitoRep1 = ""
            End If
            If RutLngAUsr(mlngRutRep2) <> "" Then
                Call QuitarFormato(RutLngAUsr(mlngRutRep2), "Rep2")
            Else
                mlngRutRep2 = -1
                mstrDigitoRep2 = ""
            End If
            If RutLngAUsr(mlngRutHolding) <> "" Then
                Call QuitarFormato(RutLngAUsr(mlngRutHolding), "RutHolding")
            Else
                mlngRutHolding = -1
            End If
            ModificarDatos()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Eliminar() As Boolean Implements Clases.IMantenedor.Eliminar
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_ejecutivo(mlngRut)
            mobjCsql.d_empresa_cliente(mlngRut)
            mobjCsql.d_CuentaCliente(mlngRut)
            'Solo si no existe el mismo rut como otec se permite borrar en la tabla
            'persona_juridica
            If mobjCsql.ExisteRegistro(mlngRut, "Otec") = False Then
                mobjCsql.d_Persona_Juridica(mlngRut)
                If mobjCsql.ExisteRegistro(mlngRut, "Usuario") = False Then
                    mobjCsql.d_Persona(mlngRut)
                End If
            End If
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
        End Try
    End Function
    Private Sub GrabarDatos()
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            If Not mobjCsql.ExisteRegistro(mlngRut, "Persona", "rut") Then
                mobjCsql.i_Persona(mlngRut, mstrDigito, "J")
            End If
            If mobjCsql.ExisteRegistro(mlngRut, "Persona", "rut") Then
                If Not mobjCsql.ExisteRegistro(mlngRut, "Persona_juridica", "rut") Then
                    mobjCsql.i_Persona_Juridica(mlngRut, mstrNomFantasia, _
                                            mstrRazonSocial, mstrSigla, _
                                            mstrEmail, mstrFono1, _
                                            mstrFono2, mstrFax, _
                                            mstrDireccion, mlngCodComuna, _
                                            mstrCasilla, mstrCiudad, mstrSitioWeb, mstrNroDireccion)
                    If Not mobjCsql.ExisteRegistro(mlngRut, "Empresa_Cliente", "rut") Then
                        mobjCsql.i_Empresa_Cliente(mlngRut, mdblCostoAdm, _
                                                                    mlngAdmNoLineal, mlngCodRubro, _
                                                                    mlngNumEmpleados, _
                                                                    mstrContacto, _
                                                                    mstrCargo, mstrFonoContacto, mstrAnexoContacto, _
                                                                    mstrEmailContacto, mstrNombreRep1, mlngRutRep1, _
                                                                    mstrDigitoRep1, mstrNombreRep2, mlngRutRep2, _
                                                                    mstrDigitoRep2, mstrGerenteGral, mstrGerenteRRHH, _
                                                                    mstrAreaCobranzas, mstrGiro, mstrCodActEconomica, _
                                                                    mlngCodEstadoCliente, mlngCodSucursal, mlngVentaAnual, _
                                                                    mstrEmailGteRRHH, mstrGerenteFinanzas, _
                                                                    mstrEmailGteFinanzas, mstrFonoCobranzas, mlngRutHolding, _
                                                                    mstrClaveWebService, mstrEtiquetaClasificador, mstrObservacion, _
                                                                    mlngRutContacto, mstrApellidoContacto)
                    End If

                    
                Else
                    mobjCsql.u_Persona_Juridica(mlngRut, mstrNomFantasia, _
                                              mstrRazonSocial, mstrSigla, _
                                              mstrEmail, mstrFono1, _
                                              mstrFono2, mstrFax, _
                                              mstrDireccion, mlngCodComuna, _
                                              mstrCasilla, mstrSitioWeb, mstrCiudad, mstrNroDireccion)
                    If Not mobjCsql.ExisteRegistro(mlngRut, "Empresa_Cliente", "rut") Then
                        mobjCsql.i_Empresa_Cliente(mlngRut, mdblCostoAdm, _
                                            mlngAdmNoLineal, mlngCodRubro, _
                                            mlngNumEmpleados, _
                                            mstrContacto, _
                                            mstrCargo, mstrFonoContacto, mstrAnexoContacto, _
                                            mstrEmailContacto, mstrNombreRep1, mlngRutRep1, _
                                            mstrDigitoRep1, mstrNombreRep2, mlngRutRep2, _
                                            mstrDigitoRep2, mstrGerenteGral, mstrGerenteRRHH, _
                                            mstrAreaCobranzas, mstrGiro, mstrCodActEconomica, _
                                            mlngCodEstadoCliente, mlngCodSucursal, mlngVentaAnual, _
                                            mstrEmailGteRRHH, mstrGerenteFinanzas, _
                                            mstrEmailGteFinanzas, mstrFonoCobranzas, mlngRutHolding, _
                                            mstrClaveWebService, mstrEtiquetaClasificador, mstrObservacion, _
                                            mlngRutContacto, mstrApellidoContacto)
                    End If
                End If
            End If
            If mobjCsql.ExisteRegistro(mlngRut, "Persona_Juridica", "rut") Then
                mobjCsql.i_ejecutivo(mlngRut, mlngRutEjecutivo)
            End If
            Dim dtCuentas As DataTable
            dtCuentas = mobjCsql.s_cuenta_todos
            If mobjCsql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtCuentas.Rows
                    mobjCsql.i_CuentaCliente(mlngRut, dr.Item(0))
                Next
            End If
            mstrObservacion = "Ingreso Nuevo Registro cliente: " & RutLngAUsr(mlngRut)
            mobjCsql.i_bitacora(mlngRutUsuario, "Ingreso", mstrObservacion, 5, mlngRut)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorEmpresa :GrabarDatos-->" & ex.Message)
        End Try
    End Sub
    Private Sub ModificarDatos()
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.u_Persona_Juridica(mlngRut, mstrNomFantasia, _
                                            mstrRazonSocial, mstrSigla, _
                                            mstrEmail, mstrFono1, _
                                            mstrFono2, mstrFax, _
                                            mstrDireccion, mlngCodComuna, _
                                            mstrCasilla, mstrSitioWeb, mstrCiudad, mstrNroDireccion)

            mobjCsql.u_Empresa_Cliente(mlngRut, mdblCostoAdm, _
                                            mlngAdmNoLineal, mlngCodRubro, _
                                            mlngNumEmpleados, _
                                            mstrContacto, _
                                            mstrCargo, mstrFonoContacto, mstrAnexoContacto, _
                                            mstrEmailContacto, mstrNombreRep1, mlngRutRep1, _
                                            mstrDigitoRep1, mstrNombreRep2, mlngRutRep2, _
                                            mstrDigitoRep2, mstrGerenteGral, mstrGerenteRRHH, _
                                            mstrAreaCobranzas, mstrGiro, mstrCodActEconomica, _
                                            mlngCodEstadoCliente, mlngCodSucursal, mlngVentaAnual, _
                                            mstrEmailGteRRHH, mstrGerenteFinanzas, _
                                            mstrEmailGteFinanzas, mstrFonoCobranzas, mlngRutHolding, _
                                            mstrClaveWebService, mstrEtiquetaClasificador, mstrObservacion, _
                                             mlngRutContacto, mstrApellidoContacto)

            mobjCsql.d_ejecutivo(mlngRut)
            mobjCsql.i_ejecutivo(mlngRut, mlngRutEjecutivo)
            mobjCsql.i_bitacora(mlngRutUsuario, "Modificado", mstrObservacion, 5, mlngRut)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("" & ex.Message)
        End Try
    End Sub
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
        If Nombre = "Empresa" Then
            mlngRut = CLng(ValorRut)
            mstrDigito = CStr(digito)
        End If
        If Nombre = "RutHolding" Then
            mlngRutHolding = CLng(ValorRut)
        End If
    End Sub
    Public Function ExisteEmpresa() As Boolean
        mobjCsql = New CSql
        If mobjCsql.ExisteRegistro(mlngRut, "EMPRESA_CLIENTE", "rut") Then
            Return True
        Else
            Return False
        End If
        mobjCsql = Nothing
    End Function
    Public ReadOnly Property Filas() As Integer Implements Clases.IMantenedor.Filas
        Get

        End Get
    End Property
    Public Sub InicializarNuevo() Implements Clases.IMantenedor.InicializarNuevo

    End Sub
    Public Property colEliminacion() As System.Collections.ArrayList Implements Clases.IMantenedor.colEliminacion
        Get

        End Get
        Set(ByVal value As System.Collections.ArrayList)

        End Set
    End Property
End Class
