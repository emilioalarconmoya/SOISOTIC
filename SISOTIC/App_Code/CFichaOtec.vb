Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data


Public Class CFichaOtec
    Implements IReporte

    Private objSession As New CSession
    'consultas sql y objetos de conexion
    Private mblnBajarXml As Boolean
    Private mstrXml As String
    Private mlngFilas As Long

    Private mobjSql As CSql

    'Rut Otec
    Private mlngRut As Long
    'Rut con Formato del Otec
    Private mstrRutFormato As String
    'Digito verificador Otec
    Private mstrDigitoOtec As String
    'Nombre Fantasia
    Private mstrNombreFantasia As String
    'Razon Social
    Private mstrRazonSocial As String
    'Sigla
    Private mstrSigla As String
    'Email Otec
    Private mstrEmail As String
    'Fono Otec
    Private mstrFono As String
    'Fono 2 Otec
    Private mstrFono2 As String
    'Fax Otec
    Private mstrFax As String
    'Direccion Otec
    Private mstrDireccion As String
    'Codigo Comuna
    Private mlngCodComuna As Long
    'Nombre Comuna
    Private mstrComuna As String
    'Nombre Region
    Private mstrRegion As String
    'Casilla
    Private mstrCasilla As String
    'Ciudad
    Private mstrCiudad As String
    'Sitio Web
    Private mstrSitioWeb As String
    'Nombre Contacto
    Private mstrContacto As String
    'Cargo Contacto
    Private mstrCargo As String
    'Fono Contacto
    Private mstrFonoContacto As String
    'Email Contacto
    Private mstrEmailContacto As String
    'Tasa de Descuento
    Private mdblTasaDescuento As Double
    'Fax Contacto
    Private mstrFaxContacto As String
    'Nombre Representante Legal 1
    Private mstrRep1 As String
    'Rut Representante Legal 1
    Private mlngRutRep1 As Long
    'Rut Representante Legal 1 con Formato
    Private mstrRutRep1Formato As String
    'Digito verificador Representante Legal 1
    Private mstrDigitoRep1 As String
    'Nombre Representante Legal 2
    Private mstrRep2 As String
    'Rut Representante Legal 2
    Private mlngRutRep2 As Long
    'Rut Representante Legal 2 con Formato
    Private mstrRutRep2Formato As String
    'Digito verificador Representante Legal 2
    Private mstrDigitoRep2 As String
    'Gerente General
    Private mstrGtegeneral As String
    'Gerente Recursos Humanos
    Private mstrGteRRHH As String
    'Area Cobranzas
    Private mstrAreaCobranzas As String
    'Giro
    Private mstrGiro As String
    'Cod actividad Economica
    Private mstrCodActEco As String
    'Codigo Rubro
    Private mintCodRubro As Integer
    'Nombre Rubro
    Private mstrNombreRubro As String
    'Numero Convenio
    Private mlngNumConvenio As Long
    'arreglo para el lookup de rubros
    Private mdtLookUpRubros As DataTable
    'arreglo para el lookup de comunas
    Private mdtLookUpComunas As DataTable
    'Observación Cambios efectuados
    Private mstrObservacion As String
    'rut del usuario conectado
    Private mlngRutUsuario As Long
    '--------------------------------------
    'nro de la direccion
    Private mstrNroDireccion As String
    Private mobjCsql As New CSql

    Public ReadOnly Property Rut() As Long
        Get
            Return mlngRut
        End Get
    End Property
    Public Property Rutotec() As Long
        Get
            Return Me.mlngRut
        End Get
        Set(ByVal value As Long)
            Me.mlngRut = value
        End Set
    End Property
    'Public ReadOnly Property Rutotec() As String
    '    Get
    '        Rutotec = mlngRut
    '    End Get
    'End Property
    Public Property RutFormateadoOtec() As String
        Get
            RutFormateadoOtec = RutLngAUsr(mlngRut)
        End Get
        Set(ByVal value As String)
            Me.mlngRut = value
        End Set
    End Property
    'Public ReadOnly Property RutFormateadoOtec() As String
    '    Get
    '        RutFormateadoOtec = RutLngAUsr(mlngRut)
    '    End Get
    'End Property

    Public ReadOnly Property RutFormato() As String
        Get
            Return mstrRutFormato
        End Get
    End Property
    Public ReadOnly Property DigitoOtec() As String
        Get
            Return mstrDigitoOtec
        End Get
    End Property
    Public ReadOnly Property NombreFantasia() As String
        Get
            Return mstrNombreFantasia
        End Get
    End Property
    Public Property RazonSocial() As String
        Get
            Return mstrRazonSocial
        End Get
        Set(ByVal value As String)
            Me.mstrRazonSocial = value
        End Set
    End Property
    'Public ReadOnly Property RazonSocial() As String
    '    Get
    '        Return mstrRazonSocial
    '    End Get
    'End Property
    Public ReadOnly Property Sigla() As String
        Get
            Return mstrSigla
        End Get
    End Property
    Public Property Email() As String
        Get
            Return Me.mstrEmail
        End Get
        Set(ByVal value As String)
            Me.mstrEmail = value
        End Set
    End Property
    'Public ReadOnly Property Email() As String
    '    Get
    '        Return mstrEmail
    '    End Get
    'End Property
    Public Property Fono() As String
        Get
            Return Me.mstrFono
        End Get
        Set(ByVal value As String)
            Me.mstrFono = value
        End Set
    End Property
    'Public ReadOnly Property Fono() As String
    '    Get
    '        Return mstrFono
    '    End Get
    'End Property
    Public ReadOnly Property Fono2() As String
        Get
            Return mstrFono2
        End Get
    End Property
    Public Property Fax() As String
        Get
            Return Me.mstrFax
        End Get
        Set(ByVal value As String)
            Me.mstrFax = value
        End Set
    End Property
    'Public ReadOnly Property Fax() As String
    '    Get
    '        Return mstrFax
    '    End Get
    'End Property
    Public Property Direccion() As String
        Get
            Return Me.mstrDireccion
        End Get
        Set(ByVal value As String)
            Me.mstrDireccion = value
        End Set
    End Property
    'Public ReadOnly Property Direccion() As String
    '    Get
    '        Return mstrDireccion
    '    End Get
    'End Property
    Public ReadOnly Property CodComuna() As Long
        Get
            Return mlngCodComuna
        End Get
    End Property
    Public Property Comuna() As String
        Get
            Return Me.mstrComuna
        End Get
        Set(ByVal value As String)
            Me.mstrComuna = value
        End Set
    End Property
    'Public ReadOnly Property Comuna() As String
    '    Get
    '        Return mstrComuna
    '    End Get
    'End Property
    Public Property Region() As String
        Get
            Return Me.mstrRegion
        End Get
        Set(ByVal value As String)
            Me.mstrRegion = value
        End Set
    End Property
    'Public ReadOnly Property Region() As String
    '    Get
    '        Return mstrRegion
    '    End Get
    'End Property
    Public ReadOnly Property Casilla() As String
        Get
            Return mstrCasilla
        End Get
    End Property
    Public ReadOnly Property Ciudad() As String
        Get
            Return mstrCiudad
        End Get
    End Property
    Public ReadOnly Property SitioWeb() As String
        Get
            Return mstrSitioWeb
        End Get
    End Property
    Public Property Contacto() As String
        Get
            Return Me.mstrContacto
        End Get
        Set(ByVal value As String)
            Me.mstrContacto = value
        End Set
    End Property
    'Public ReadOnly Property Contacto() As String
    '    Get
    '        Return mstrContacto
    '    End Get
    'End Property
    Public Property Cargo() As String
        Get
            Return Me.mstrCargo
        End Get
        Set(ByVal value As String)
            Me.mstrCargo = value
        End Set
    End Property
    'Public ReadOnly Property Cargo() As String
    '    Get
    '        Return mstrCargo
    '    End Get
    'End Property
    Public Property FonoContacto() As String
        Get
            Return Me.mstrFonoContacto
        End Get
        Set(ByVal value As String)
            Me.mstrFonoContacto = value
        End Set
    End Property
    'Public ReadOnly Property FonoContacto() As String
    '    Get
    '        Return mstrFonoContacto
    '    End Get
    'End Property
    Public Property EmailContacto() As String
        Get
            Return Me.mstrEmailContacto
        End Get
        Set(ByVal value As String)
            Me.mstrEmailContacto = value
        End Set
    End Property
    'Public ReadOnly Property EmailContacto() As String
    '    Get
    '        Return mstrEmailContacto
    '    End Get
    'End Property
    Public Property TasaDescuento() As Double
        Get
            Return Me.mdblTasaDescuento
        End Get
        Set(ByVal value As Double)
            Me.mdblTasaDescuento = value
        End Set
    End Property
    'Public ReadOnly Property TasaDescuento() As Double
    '    Get
    '        Return mdblTasaDescuento
    '    End Get
    'End Property
    Public Property FaxContacto() As String
        Get
            Return Me.mstrFaxContacto
        End Get
        Set(ByVal value As String)
            Me.mstrFaxContacto = value
        End Set
    End Property
    'Public ReadOnly Property FaxContacto() As String
    '    Get
    '        Return mstrFaxContacto
    '    End Get
    'End Property
    Public Property Rep1() As String
        Get
            Return Me.mstrRep1
        End Get
        Set(ByVal value As String)
            Me.mstrRep1 = value
        End Set
    End Property
    'Public ReadOnly Property Rep1() As String
    '    Get
    '        Return mstrRep1
    '    End Get
    'End Property
    Public Property RutRep1() As Long
        Get
            Return Me.mlngRutRep1
        End Get
        Set(ByVal value As Long)
            Me.mlngRutRep1 = value
        End Set
    End Property
    'Public ReadOnly Property RutRep1() As Long
    '    Get
    '        Return mlngRutRep1
    '    End Get
    'End Property
    Public ReadOnly Property RutRep1Formato() As String
        Get
            Return mstrRutRep1Formato
        End Get
    End Property
    Public ReadOnly Property DigitoRep1() As String
        Get
            Return mstrDigitoRep1
        End Get
    End Property
    Public Property Rep2() As String
        Get
            Return Me.mstrRep2
        End Get
        Set(ByVal value As String)
            Me.mstrRep2 = value
        End Set
    End Property
    'Public ReadOnly Property Rep2() As String
    '    Get
    '        Return mstrRep2
    '    End Get
    'End Property
    Public Property RutRep2() As Long
        Get
            Return Me.mlngRutRep2
        End Get
        Set(ByVal value As Long)
            Me.mlngRutRep2 = value
        End Set
    End Property
    'Public ReadOnly Property RutRep2() As Long
    '    Get
    '        Return mlngRutRep2
    '    End Get
    'End Property
    Public ReadOnly Property RutRep2Formato() As String
        Get
            Return mstrRutRep2Formato
        End Get
    End Property
    Public ReadOnly Property DigitoRep2() As String
        Get
            Return mstrDigitoRep2
        End Get
    End Property
    Public Property Gtegeneral() As String
        Get
            Return Me.mstrGtegeneral
        End Get
        Set(ByVal value As String)
            Me.mstrGtegeneral = value
        End Set
    End Property
    'Public ReadOnly Property Gtegeneral() As String
    '    Get
    '        Return mstrGtegeneral
    '    End Get
    'End Property
    Public Property GteRRHH() As String
        Get
            Return Me.mstrGteRRHH
        End Get
        Set(ByVal value As String)
            Me.mstrGteRRHH = value
        End Set
    End Property
    'Public ReadOnly Property GteRRHH() As String
    '    Get
    '        Return mstrGteRRHH
    '    End Get
    'End Property
    Public Property AreaCobranzas() As String
        Get
            Return Me.mstrAreaCobranzas
        End Get
        Set(ByVal value As String)
            Me.mstrAreaCobranzas = value
        End Set
    End Property
    'Public ReadOnly Property AreaCobranzas() As String
    '    Get
    '        Return mstrAreaCobranzas
    '    End Get
    'End Property
    Public Property Giro() As String
        Get
            Return Me.mstrGiro
        End Get
        Set(ByVal value As String)
            Me.mstrGiro = value
        End Set
    End Property
    'Public ReadOnly Property Giro() As String
    '    Get
    '        Return mstrGiro
    '    End Get
    'End Property
    Public Property CodActEco() As String
        Get
            Return Me.mstrCodActEco
        End Get
        Set(ByVal value As String)
            Me.mstrCodActEco = value
        End Set
    End Property
    'Public ReadOnly Property CodActEco() As String
    '    Get
    '        Return mstrCodActEco
    '    End Get
    'End Property
    Public ReadOnly Property CodRubro() As Integer
        Get
            Return mintCodRubro
        End Get
    End Property
    Public Property NombreRubro() As String
        Get
            Return Me.mstrNombreRubro
        End Get
        Set(ByVal value As String)
            Me.mstrNombreRubro = value
        End Set
    End Property
    'Public ReadOnly Property NombreRubro() As String
    '    Get
    '        Return mstrNombreRubro
    '    End Get
    'End Property
    Public Property NumConvenio() As Long
        Get
            Return Me.mlngNumConvenio
        End Get
        Set(ByVal value As Long)
            Me.mlngNumConvenio = value
        End Set
    End Property
    'Public ReadOnly Property NumConvenio() As Long
    '    Get
    '        Return mlngNumConvenio
    '    End Get
    'End Property
    Public ReadOnly Property LookUpRubros() As DataTable
        Get
            Return mdtLookUpRubros
        End Get
    End Property
    Public ReadOnly Property LookUpComunas() As DataTable
        Get
            Return mdtLookUpComunas
        End Get
    End Property
    Public ReadOnly Property Observacion() As String
        Get
            Return mstrObservacion
        End Get
    End Property
    Public Property RutUsuario() As Long
        Get
            Return Me.mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            Me.mlngRutUsuario = value
        End Set
    End Property
    'Public ReadOnly Property RutUsuario() As Long
    '    Get
    '        Return mlngRutUsuario
    '    End Get
    'End Property
    Public ReadOnly Property NroDireccion() As String
        Get
            Return mstrNroDireccion
        End Get
    End Property

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

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            mobjSql = New CSql
            Dim Otec As New COtec
            Otec.Inicializar0(mobjSql, Me.RutUsuario)
            Otec.Inicializar1(Me.Rut)

            Me.mstrDireccion = Otec.Direccion
            Me.mstrComuna = Otec.Comuna
            Me.mstrRegion = Otec.Region
            Me.mstrEmail = Otec.Email

            Me.mstrContacto = Otec.Contacto
            Me.mstrCargo = Otec.Cargo
            Me.mstrFonoContacto = Otec.FonoContacto
            Me.mstrFaxContacto = Otec.FaxContacto
            Me.mstrEmailContacto = Otec.EmailContacto

            Me.mstrRep1 = Otec.Rep1
            Me.mlngRutRep1 = Otec.RutRep1
            Me.mstrRep2 = Otec.Rep2
            Me.mlngRutRep2 = Otec.RutRep2

            Me.mlngNumConvenio = Otec.NumConvenio
            Me.mdblTasaDescuento = Otec.TasaDescuento

            Me.mstrGiro = Otec.Giro
            Me.mstrCodActEco = Otec.CodActEco
            Me.mstrNombreRubro = Otec.NombreRubro

            Me.mstrGtegeneral = Otec.Gtegeneral
            Me.mstrGteRRHH = Otec.GteRRHH
            Me.mstrAreaCobranzas = Otec.AreaCobranzas

            Me.RutFormateadoOtec = Otec.RutFormateadoOtec
            Me.RazonSocial = Otec.RazonSocial
            Me.Fono = Otec.Fono
            Me.Fax = Otec.Fax
            Me.Email = Otec.Email







        Catch ex As Exception

        End Try
    End Function
End Class
