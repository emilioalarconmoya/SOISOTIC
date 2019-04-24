Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CUsuario
    Implements IReporte


    Private objSession As New CSession
    'consultas sql y objetos de conexion
    Private mblnBajarXml As Boolean
    Private mstrXml As String
    Private mlngFilas As Long
    'objeto de coneccion a bd y de implements ireporte
    Private mobjSql As CSql
    'Rut del usuario, sin dígito verificador.
    Private mlngRut As Long ' = 0
    'Dígito verificador.
    Private mstrDigVerif As String
    'Nombres del usuario.
    Private mstrNombres As String
    'clave del usuario. Esta variable no debe ser pública
    Private mstrClave As String

    'Indica si un usuario está conectado.
    Private mblnConectado As Boolean ' = False

    'Arreglo con los objetos a los que tiene acceso un usuario.
    Private marrPermisos() As Object

    'Indica si un usuario es administrador del sistema.
    Private mblnEsAdmin As Boolean ' = False
    'Indica si un usuario es cliente
    Private mblnEsCliente As Boolean ' = False
    'Indica si un usuario es Ejecutivo
    Private mblnEsEjecutivo As Boolean ' = False
    'Indica si un usuario es Ejecutivo Regional ing/mod
    Private mblnEsEjecutivoRegIngMod As Boolean ' = False
    'Indica si un usuario es Ejecutivo Regional aut
    Private mblnEsEjecutivoRegAut As Boolean ' = False
    'Indica si un usuario es Supervisor
    Private mblnEsSupervisor As Boolean ' = False
    'Indica si un usuario es de operaciones
    Private mblnEsOper As Boolean ' = False
    'Indica si un usuario es de Finanzas
    Private mblnEsFinan As Boolean
    'indica si un usuario tiene el perfil de finanzas de regiones
    Private mblnEsFinanReg As Boolean
    'Indica si el usuario puede ver los reportes de RRHH.
    Private mblnEsRRHH As Boolean ' = False
    'Indica si el usuario es director de sucursal
    Private mblnEsDirectorSucursal As Boolean '= False
    'Indica si el usuario es administrador de noticias del portal
    Private mblnEsNoticiasPortal As Boolean '= False
    'Indica si el usuario es director
    Private mblnEsDirector As Boolean '= False

    'arreglo con las filiales de los clientes
    Private marrFiliales()

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
    Property Conectado() As Boolean
        Get
            Return Me.mblnConectado
        End Get
        Set(ByVal value As Boolean)
            Me.mblnConectado = value
        End Set
    End Property
    Property EsAdmin() As Boolean
        Get
            Return Me.mblnEsAdmin
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsAdmin = value
        End Set
    End Property
    Property EsCliente() As Boolean
        Get
            Return Me.mblnEsCliente
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsCliente = value
        End Set
    End Property
    Property EsEjecutivo() As Boolean
        Get
            Return Me.mblnEsEjecutivo
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsEjecutivo = value
        End Set
    End Property
    Property EjecutivoRegIngMod() As Boolean
        Get
            Return Me.mblnEsEjecutivoRegIngMod
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsEjecutivoRegIngMod = value
        End Set
    End Property
    Property EsEjecutivoRegAut() As Boolean
        Get
            Return Me.mblnEsEjecutivoRegAut
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsEjecutivoRegAut = value
        End Set
    End Property
    Property EsSupervisor() As Boolean
        Get
            Return Me.mblnEsSupervisor
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsSupervisor = value
        End Set
    End Property
    Property EsOper() As Boolean
        Get
            Return Me.mblnEsOper
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsOper = value
        End Set
    End Property
    Property EsFinan() As Boolean
        Get
            Return Me.mblnEsFinan
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsFinan = value
        End Set
    End Property
    Property EsFinanReg() As Boolean
        Get
            Return Me.mblnEsFinanReg
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsFinanReg = value
        End Set
    End Property
    Property EsRRHH() As Boolean
        Get
            Return Me.mblnEsRRHH
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsRRHH = value
        End Set
    End Property
    Property EsDirectorSucursal() As Boolean
        Get
            Return Me.mblnEsDirectorSucursal
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsDirectorSucursal = value
        End Set
    End Property
    Property EsNoticiasPortal() As Boolean
        Get
            Return Me.mblnEsNoticiasPortal
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsNoticiasPortal = value
        End Set
    End Property
    Property EsDirector() As Boolean
        Get
            Return Me.mblnEsDirector
        End Get
        Set(ByVal value As Boolean)
            Me.mblnEsDirector = value
        End Set
    End Property
    Property DigVerif() As String
        Get
            Return Me.mstrDigVerif
        End Get
        Set(ByVal value As String)
            Me.mstrDigVerif = value
        End Set
    End Property
    Property Nombres() As String
        Get
            Return Me.mstrNombres
        End Get
        Set(ByVal value As String)
            Me.mstrNombres = value
        End Set
    End Property
    Property Clave() As String
        Get
            Return Me.mstrClave
        End Get
        Set(ByVal value As String)
            Me.mstrClave = value
        End Set
    End Property
    Property Rut() As Long
        Get
            Return Me.mlngRut
        End Get
        Set(ByVal value As Long)
            Me.mlngRut = value
        End Set
    End Property
    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar


        Try

        Catch ex As Exception
            EnviaError("CFichaActividad->Consultar" & ex.Message)
        End Try
    End Function
End Class
