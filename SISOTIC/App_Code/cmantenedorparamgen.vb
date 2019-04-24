Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorParamGen
    Private mobjCsql As CSql
    Private mlngDiasComunicacion As Long
    Private mlngRutJefeFinanzas As Long
    Private mlngRutOperaciones As Long
    Private mstrServidorCorreo As String
    Private mstrDireccionCorreoOrigen As String
    Private mstrDireccionCorreoDestino As String
    Private mdtUsuarios As DataTable
    Public Property Usuarios() As DataTable
        Get
            Return mdtUsuarios
        End Get
        Set(ByVal value As DataTable)
            mdtUsuarios = value
        End Set
    End Property
    Public Property DiasComunicacion() As Long
        Get
            Return mlngDiasComunicacion
        End Get
        Set(ByVal value As Long)
            mlngDiasComunicacion = value
        End Set
    End Property
    Public Property RutJefeFinanzas() As Long
        Get
            Return mlngRutJefeFinanzas
        End Get
        Set(ByVal value As Long)
            mlngRutJefeFinanzas = value
        End Set
    End Property
    Public Property RutJefeOperaciones() As Long
        Get
            Return mlngRutOperaciones
        End Get
        Set(ByVal value As Long)
            mlngRutOperaciones = value
        End Set
    End Property
    Public Property ServidorCorreo() As String
        Get
            Return mstrServidorCorreo
        End Get
        Set(ByVal value As String)
            mstrServidorCorreo = value
        End Set
    End Property
    Public Property DireccionCorreoOrigen() As String
        Get
            Return mstrDireccionCorreoOrigen
        End Get
        Set(ByVal value As String)
            mstrDireccionCorreoOrigen = value
        End Set
    End Property
    Public Property DireccionCorreoDestino() As String
        Get
            Return mstrDireccionCorreoDestino
        End Get
        Set(ByVal value As String)
            mstrDireccionCorreoDestino = value
        End Set
    End Property
    Public Sub Consultar()
        Dim dtConsulta As DataTable
        Try
            mobjCsql = New CSql
            dtConsulta = mobjCsql.s_param_gen_todos
            mlngDiasComunicacion = dtConsulta.Rows(0)("dias_comunic")
            mlngRutJefeFinanzas = dtConsulta.Rows(0)("rut_jefe_finanzas")
            mlngRutOperaciones = dtConsulta.Rows(0)("rut_operaciones")
            mstrServidorCorreo = dtConsulta.Rows(0)("servidor_correo")
            mstrDireccionCorreoOrigen = dtConsulta.Rows(0)("direccion_correo_origen")
            mstrDireccionCorreoDestino = dtConsulta.Rows(0)("direccion_correo_destino")
            mdtUsuarios = mobjCsql.s_usuario_todos
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql = Nothing
        End Try
    End Sub
    Public Function Modificar() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.u_param_gen(mlngDiasComunicacion, mstrServidorCorreo, mstrDireccionCorreoOrigen, mstrDireccionCorreoDestino, _
            mlngRutJefeFinanzas, mlngRutOperaciones)
            mobjCsql.FinTransaccion()
            Return True
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            Return False
            mobjCsql = Nothing
        End Try
    End Function
End Class
