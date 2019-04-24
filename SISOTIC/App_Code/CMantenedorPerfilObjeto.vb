Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorPerfilObjeto
    Implements IMantenedor
    Private mobjCsql As CSql
    Private mlngCodPerfil As Long
    Private mlngCodObjeto As Long
    Private mstrNombrePerfil As String
    Private mstrNombreObjeto As String
    Private mintFilas As Integer
    Private mdtObjetosAsignados As DataTable
    Private mdtObjetosNoAsignados As DataTable
    Private mdtObjetosTodos As DataTable
    Private mdtPerfilesAsignados As DataTable
    Private mdtPerfilesNoAsignados As DataTable
    Private mdtPerfilesTodos As DataTable
    Private mdtTraspaso As DataTable
    Public Property CodPerfil() As Long
        Get
            Return mlngCodPerfil
        End Get
        Set(ByVal value As Long)
            mlngCodPerfil = value
        End Set
    End Property
    Public Property CodObjeto() As Long
        Get
            Return mlngCodObjeto
        End Get
        Set(ByVal value As Long)
            mlngCodObjeto = value
        End Set
    End Property
    Public Property NombrePerfil() As String
        Get
            Return mstrNombrePerfil
        End Get
        Set(ByVal value As String)
            mstrNombrePerfil = value
        End Set
    End Property
    Public Property NombreObjeto() As String
        Get
            Return mstrNombreObjeto
        End Get
        Set(ByVal value As String)
            mstrNombreObjeto = value
        End Set
    End Property
    Public Property ObjetosAsignados() As DataTable
        Get
            Return mdtObjetosAsignados
        End Get
        Set(ByVal value As DataTable)
            mdtObjetosAsignados = value
        End Set
    End Property
    Public Property ObjetosNoAsignados() As DataTable
        Get
            Return mdtObjetosNoAsignados
        End Get
        Set(ByVal value As DataTable)
            mdtObjetosNoAsignados = value
        End Set
    End Property
    Public ReadOnly Property ObjetosTodos() As DataTable
        Get
            mobjCsql = New CSql
            mdtObjetosTodos = Me.mobjCsql.s_objeto_todos
            Return mdtObjetosTodos
            mobjCsql = Nothing
        End Get
    End Property
    Public Property PerfilesAsignados() As DataTable
        Get
            Return mdtPerfilesAsignados
        End Get
        Set(ByVal value As DataTable)
            mdtPerfilesAsignados = value
        End Set
    End Property
    Public Property PerfilesNoAsignados() As DataTable
        Get
            Return mdtPerfilesNoAsignados
        End Get
        Set(ByVal value As DataTable)
            mdtPerfilesNoAsignados = value
        End Set
    End Property
    Public ReadOnly Property PerfilesTodos() As DataTable
        Get
            mobjCsql = New CSql
            mdtPerfilesTodos = Me.mobjCsql.s_todos_los_perfiles
            Return mdtPerfilesTodos
            mobjCsql = Nothing
        End Get
    End Property
    Public Property Traspaso() As DataTable
        Get
            Return mdtTraspaso
        End Get
        Set(ByVal value As DataTable)
            mdtTraspaso = value
        End Set
    End Property
    Public Sub InicializarNuevo() Implements Clases.IMantenedor.InicializarNuevo
        mlngCodPerfil = 0
        mlngCodObjeto = 0
        mstrNombrePerfil = ""
        mstrNombreObjeto = ""
    End Sub
    Public Function Consultar() As System.Data.DataTable Implements Clases.IMantenedor.Consultar
        mobjCsql = New CSql
        mdtObjetosAsignados = mobjCsql.s_objetos_asignados(mlngCodPerfil)
        mdtObjetosNoAsignados = mobjCsql.s_objetos_no_asignados(mlngCodPerfil)
        Dim dtPerfilObjeto As DataTable
        dtPerfilObjeto = mobjCsql.s_perfil_objeto(mlngCodPerfil, mstrNombrePerfil, mlngCodObjeto, mstrNombreObjeto)
        Me.mintFilas = mobjCsql.Registros
        If Me.mintFilas > 0 Then
            mlngCodPerfil = dtPerfilObjeto.Rows(0)("cod_perfil")
            mlngCodObjeto = dtPerfilObjeto.Rows(0)("cod_objeto")
            mstrNombrePerfil = dtPerfilObjeto.Rows(0)("nombre_perfil")
            mstrNombreObjeto = dtPerfilObjeto.Rows(0)("nombre_objeto")
        End If
        mobjCsql = Nothing
        Return dtPerfilObjeto
    End Function
    Public Function ConsultarPerfil() As DataTable
        Try
            mobjCsql = New CSql
            Dim dtPerfiles As DataTable
            dtPerfiles = mobjCsql.s_perfil_m(mlngCodPerfil, mstrNombrePerfil)
            Me.mintFilas = mobjCsql.Registros
            If Me.mintFilas > 0 Then
                mlngCodPerfil = dtPerfiles.Rows(0)("cod_perfil")
                mstrNombrePerfil = dtPerfiles.Rows(0)("nombre")
            End If
            mobjCsql = Nothing
            Return dtPerfiles
        Catch ex As Exception
            EnviaError("CMantenedorPerfilObjeto:ConsultarPerfil->" & ex.Message)
        End Try
    End Function
    Public Function ConsultarObjeto() As DataTable
        Try
            mobjCsql = New CSql
            Dim dtObjetos As DataTable
            mdtPerfilesAsignados = mobjCsql.s_perfiles_asignados_objetos(mlngCodObjeto)
            dtObjetos = mobjCsql.s_objeto_m(mlngCodObjeto, mstrNombreObjeto)
            Me.mintFilas = mobjCsql.Registros
            If Me.mintFilas > 0 Then
                mlngCodObjeto = dtObjetos.Rows(0)("cod_objeto")
                mstrNombreObjeto = dtObjetos.Rows(0)("nombre")
            End If
            mobjCsql = Nothing
            Return dtObjetos
        Catch ex As Exception
            EnviaError("CMantenedorPerfilObjeto:ConsultarObjeto->" & ex.Message)
        End Try
    End Function

    Public Function Insertar() As Boolean Implements Clases.IMantenedor.Insertar
        Dim row As DataRow
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            For Each row In Me.mdtTraspaso.Rows
                Call mobjCsql.i_perfilObjeto(mlngCodPerfil, row("cod_objeto")) 'inserta objeto
            Next
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:Insertar->" & ex.Message)
        End Try
    End Function
    Public Function InsertarPerfil() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.i_perfil(mstrNombrePerfil)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:InsertarPerfil->" & ex.Message)
        End Try
    End Function
    Public Function InsertarObjeto() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.i_objeto(mstrNombreObjeto)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:InsertarObjeto->" & ex.Message)
        End Try
    End Function
    Public Function Actualizar() As Boolean Implements Clases.IMantenedor.Actualizar
        Dim row As DataRow
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            For Each row In Me.mdtTraspaso.Rows
                Call mobjCsql.d_perfilObjeto(mlngCodPerfil, row("cod_objeto")) 'elimina objeto
            Next
            For Each row In Me.mdtTraspaso.Rows
                Call mobjCsql.i_perfilObjeto(mlngCodPerfil, row("cod_objeto")) 'inserta objeto
            Next
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:Actualizar->" & ex.Message)
        End Try
    End Function
    Public Function ActualizarObjeto() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.u_objeto(mlngCodObjeto, mstrNombreObjeto)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:ActualizarObjeto->" & ex.Message)
        End Try
    End Function
    Public Function Eliminar() As Boolean Implements Clases.IMantenedor.Eliminar
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_perfilObjeto(mlngCodPerfil, mlngCodObjeto)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:Eliminar->" & ex.Message)
        End Try
    End Function
    Public Function EliminarPerfil() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_perfil(mlngCodPerfil)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:EliminarPerfil->" & ex.Message)
        End Try
    End Function
    Public Function EliminarObjeto() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_objeto(mlngCodObjeto)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
            EnviaError("CMantenedorPerfilObjeto:EliminarPerfil->" & ex.Message)
        End Try
    End Function
    Public ReadOnly Property Filas() As Integer Implements Clases.IMantenedor.Filas
        Get
            Return mintFilas
        End Get
    End Property
    Public Property colEliminacion() As System.Collections.ArrayList Implements Clases.IMantenedor.colEliminacion
        Get

        End Get
        Set(ByVal value As System.Collections.ArrayList)

        End Set
    End Property
End Class
