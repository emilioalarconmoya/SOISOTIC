Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CMantenedorEncargado

    Private mlngRutEncargado As Long
    Private mstrNombreEncargado As String
    Private mstrApellidoEncargado As String
    Private mstrCargoEncargado As String
    Private mstrFonoEncargado As String
    Private mstrEmailEncargado As String
    Private mlngRutEmpresa As Long
    Private mobjCsql As CSql
    Private mlngFilas As Long

    Public Property RutEncargado() As Long
        Get
            Return mlngRutEncargado
        End Get
        Set(ByVal value As Long)
            mlngRutEncargado = value
        End Set
    End Property
    Public Property NombreEncargado() As String
        Get
            Return mstrNombreEncargado
        End Get
        Set(ByVal value As String)
            mstrNombreEncargado = value
        End Set
    End Property
    Public Property ApellidoEncargado() As String
        Get
            Return mstrApellidoEncargado
        End Get
        Set(ByVal value As String)
            mstrApellidoEncargado = value
        End Set
    End Property
    Public Property CargoEncargado() As String
        Get
            Return mstrCargoEncargado
        End Get
        Set(ByVal value As String)
            mstrCargoEncargado = value
        End Set
    End Property
    Public Property FonoEncargado() As String
        Get
            Return mstrFonoEncargado
        End Get
        Set(ByVal value As String)
            mstrFonoEncargado = value
        End Set
    End Property
    Public Property EmailEncargado() As String
        Get
            Return mstrEmailEncargado
        End Get
        Set(ByVal value As String)
            mstrEmailEncargado = value
        End Set
    End Property
    Public Property RutEmpresa() As Long
        Get
            Return mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property

    Public Function Insertar() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()

            If Not mobjCsql.s_existe_encargado(mlngRutEncargado) Then
                mobjCsql.i_encargado(mlngRutEncargado, mstrNombreEncargado, mstrApellidoEncargado, _
                                               mstrCargoEncargado, mstrFonoEncargado, mstrEmailEncargado)
            Else
                mobjCsql.u_encargado(mlngRutEncargado, mstrNombreEncargado, mstrApellidoEncargado, _
                                               mstrCargoEncargado, mstrFonoEncargado, mstrEmailEncargado)
            End If

          


            If Not mobjCsql.s_existe_encargado_empresa(mlngRutEncargado, mlngRutEmpresa) Then
                mobjCsql.i_encargado_empresa(mlngRutEmpresa, mlngRutEncargado)
            End If

            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorEncargado.vb:Insertar-->" & ex.Message)
            Return False
        End Try
    End Function

    Public Function Actualizar() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()

            mobjCsql.u_encargado(mlngRutEncargado, mstrNombreEncargado, mstrApellidoEncargado, _
                                 mstrCargoEncargado, mstrFonoEncargado, mstrEmailEncargado)

            If Not mobjCsql.s_existe_encargado_empresa(mlngRutEncargado, mlngRutEmpresa) Then
                mobjCsql.i_encargado_empresa(mlngRutEmpresa, mlngRutEncargado)
            End If


            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorEncargado.vb:Actualizar-->" & ex.Message)
            Return False
        End Try
    End Function

    Public Function Consultar() As System.Data.DataTable
        Dim dt As DataTable
        Try
            mobjCsql = New CSql
            dt = mobjCsql.s_encargado(mlngRutEncargado, mlngRutEmpresa, mstrNombreEncargado)
            If Not dt Is Nothing Then
                Me.mlngFilas = Me.mobjCsql.Registros
                If Me.mlngFilas > 0 Then
                    mlngRutEncargado = dt.Rows(0)("rut_encargado")
                    mstrNombreEncargado = dt.Rows(0)("nombre_encargado")
                    mstrApellidoEncargado = dt.Rows(0)("apellido_encargado")
                    mstrCargoEncargado = dt.Rows(0)("cargo")
                    mstrFonoEncargado = dt.Rows(0)("fono")
                    mstrEmailEncargado = dt.Rows(0)("email")
                    mlngRutEmpresa = dt.Rows(0)("rut_empresa")
                End If
            End If
            Return dt
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql = Nothing
            EnviaError("CMantenedorEncargado.vb:Consultar-->" & ex.Message)
        End Try
    End Function

    Public Function Inicializar(ByVal lngCodCurso As Long) As Boolean
        Dim dt As DataTable
        Try
            mobjCsql = New CSql
            dt = mobjCsql.s_encargado_curso(lngCodCurso)
            If Not dt Is Nothing Then
                Me.mlngFilas = Me.mobjCsql.Registros
                If Me.mlngFilas > 0 Then
                    mlngRutEncargado = dt.Rows(0)("rut_encargado")
                    mstrNombreEncargado = dt.Rows(0)("nombre_encargado")
                    mstrApellidoEncargado = dt.Rows(0)("apellido_encargado")
                    mstrCargoEncargado = dt.Rows(0)("cargo")
                    mstrFonoEncargado = dt.Rows(0)("fono")
                    mstrEmailEncargado = dt.Rows(0)("email")
                    mlngRutEmpresa = dt.Rows(0)("rut_empresa")
                Else
                    Return False
                End If
            Else
                Return False
            End If
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql = Nothing
            EnviaError("CMantenedorEncargado.vb:Inicializar-->" & ex.Message)
        End Try
    End Function

End Class
