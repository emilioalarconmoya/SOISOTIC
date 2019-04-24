Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorUsuario
    Implements IMantenedor
    Private mobjCsql As CSql
    Private mlngRutUsuario As Long
    Private mlngRutUsuarioSesion As Long
    Private mstrNombres As String
    Private mstrClave As String
    Private mstrEmail As String
    Private mstrTelefono As String
    Private mstrFax As String
    Private mlngFilas As Long
    Private mdtPerfilesAsignados As DataTable
    Private mdtPerfilesNoAsignados As DataTable
    Private mdtEjecutivosAsignados As DataTable
    Private mdtEjecutivosNoAsignados As DataTable
    Private mdtEjecutivosTodos As DataTable
    Private mdtPerfilesTodos As DataTable
    Private mdtTraspaso As DataTable
    Private mdtTraspasoEjecutivo As DataTable
    Private mlngRutSupervisor As Long
    Private mstrNombreSupervisor As String
    Private mlngRutEjecutivo As Long
    Private mstrNombreEjecutivo As String
    Private mintCodSucursal As Integer
    Private mstrNomSucursal As String
    Private mstrTipo As String
    Public Property RutUsuarioSesion() As Long
        Get
            Return mlngRutUsuarioSesion
        End Get
        Set(ByVal value As Long)
            mlngRutUsuarioSesion = value
        End Set
    End Property
    Public Property RutUsuario() As String
        Get
            Return RutLngAUsr(mlngRutUsuario)
        End Get
        Set(ByVal value As String)
            mlngRutUsuario = RutUsrALng(value)
        End Set
    End Property
    Public Property Tipo() As String
        Get
            Return mstrTipo
        End Get
        Set(ByVal value As String)
            mstrTipo = value
        End Set
    End Property
    Public Property Nombres() As String
        Get
            Return mstrNombres
        End Get
        Set(ByVal value As String)
            mstrNombres = value
        End Set
    End Property
    Public Property Clave() As String
        Get
            Return mstrClave
        End Get
        Set(ByVal value As String)
            mstrClave = value
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
    Public Property Telefono() As String
        Get
            Return mstrTelefono
        End Get
        Set(ByVal value As String)
            mstrTelefono = value
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
    Public ReadOnly Property PerfilesTodos() As DataTable
        Get
            mobjCsql = New CSql
            mdtPerfilesTodos = Me.mobjCsql.s_todos_los_perfiles
            Return mdtPerfilesTodos
            mobjCsql = Nothing
        End Get
    End Property
    Public ReadOnly Property EjecutivosTodos() As DataTable
        Get
            mobjCsql = New CSql
            mdtEjecutivosTodos = Me.mobjCsql.s_ejecutivo_todos
            Return mdtEjecutivosTodos
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
    Public Property EjecutivosAsignados() As DataTable
        Get
            Return mdtEjecutivosAsignados
        End Get
        Set(ByVal value As DataTable)
            mdtEjecutivosAsignados = value
        End Set
    End Property
    Public Property EjecutivosNoAsignados() As DataTable
        Get
            Return mdtEjecutivosNoAsignados
        End Get
        Set(ByVal value As DataTable)
            mdtEjecutivosNoAsignados = value
        End Set
    End Property
    Public Property Traspaso() As DataTable
        Get
            Return mdtTraspaso
        End Get
        Set(ByVal value As DataTable)
            mdtTraspaso = value
        End Set
    End Property
    Public Property TtraspasoEjecutivo() As DataTable
        Get
            Return mdtTraspasoEjecutivo
        End Get
        Set(ByVal value As DataTable)
            mdtTraspasoEjecutivo = value
        End Set
    End Property
    Public Property RutSupervisor() As Long
        Get
            Return mlngRutSupervisor
        End Get
        Set(ByVal value As Long)
            mlngRutSupervisor = value
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
    Public Property NombreSupervisor() As String
        Get
            Return mstrNombreSupervisor
        End Get
        Set(ByVal value As String)
            mstrNombreSupervisor = value
        End Set
    End Property
    Public Property NombreEjecutivo() As String
        Get
            Return mstrNombreEjecutivo
        End Get
        Set(ByVal value As String)
            mstrNombreEjecutivo = value
        End Set
    End Property
    Public Property CodSucursal() As Integer
        Get
            Return mintCodSucursal
        End Get
        Set(ByVal value As Integer)
            mintCodSucursal = value
        End Set
    End Property
    Public Property NomSucursal() As String
        Get
            NomSucursal = mstrNomSucursal
        End Get
        Set(ByVal value As String)
            mstrNomSucursal = value
        End Set
    End Property
    Public Sub InicializarNuevo() Implements Clases.IMantenedor.InicializarNuevo
        mlngRutUsuario = 0
        mstrNombres = ""
        mstrClave = ""
        mstrEmail = ""
        mstrTelefono = ""
        mstrFax = ""
    End Sub
    Public Function Consultar() As System.Data.DataTable Implements Clases.IMantenedor.Consultar
        Dim dtUsuarios As DataTable
        Try
            mobjCsql = New CSql
            mdtPerfilesAsignados = mobjCsql.s_perfiles_asignados(mlngRutUsuario)
            mdtPerfilesNoAsignados = mobjCsql.s_perfiles_no_asignados(mlngRutUsuario)
            mdtEjecutivosAsignados = mobjCsql.s_ejecutivos_asignados(mlngRutUsuario)
            mdtEjecutivosNoAsignados = mobjCsql.s_ejecutivos_no_asignados(mlngRutUsuario)
            dtUsuarios = mobjCsql.s_consulta_usuario(mlngRutUsuario, mstrNombres)
            If Not dtUsuarios Is Nothing Then
                Me.mlngFilas = Me.mobjCsql.Registros
                If Me.mlngFilas > 0 Then
                    Dim dr As DataRow
                    For Each dr In dtUsuarios.Rows
                        mlngRutUsuario = dr("rut")
                        mstrNombres = dr("nombres")
                        mstrClave = DecryptINI$(Trim(dr("passwd_enc")))
                        mstrEmail = dr("email")
                        If IsDBNull(dr("telefono")) Then
                            mstrTelefono = "no posee fono"
                        Else
                            mstrTelefono = dr("telefono")
                        End If
                        If IsDBNull(dr("fax")) Then
                            mstrFax = "no poesee fax"
                        Else
                            mstrFax = dr("fax")
                        End If


                    Next
                End If
            End If
            Return dtUsuarios
        Catch ex As Exception
            EnviaError("CMantenedorUsuario.vb:Consultar-->" & ex.Message)
        Finally
            dtUsuarios = Nothing
            mobjCsql = Nothing
        End Try
    End Function
    Function ConsultarExisteUsuario() As Boolean
        Dim respuesta As New Boolean
        Try
            mobjCsql = New CSql
            respuesta = mobjCsql.s_existe_usuario(mlngRutUsuario)
            Return respuesta
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorUsuario.vb: ConsultarExisteUsuario-->" & ex.Message)
        End Try
    End Function
    Public Function InsertaPersona() As Boolean
        mobjCsql = New CSql
        Dim dt As DataTable = mobjCsql.s_persona(mlngRutUsuario)
        Me.mlngFilas = Me.mobjCsql.Registros
        If Me.mlngFilas = 0 Then
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            Dim strDigito As String = digito_verificador(mlngRutUsuario)
            mobjCsql.i_Persona(mlngRutUsuario, strDigito, mstrTipo)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Insertar() As Boolean Implements Clases.IMantenedor.Insertar
        Dim strpass As String
        Dim row As DataRow
        Try
            mobjCsql = New CSql
            strpass = EncryptINI$(Me.mstrClave)
            mobjCsql.InicioTransaccion()
            mobjCsql.i_usuario(mlngRutUsuario, mstrNombres, strpass, mstrEmail, mstrTelefono, mstrFax)
            For Each row In Me.mdtTraspaso.Rows
                mobjCsql.i_perfil_Usuario(row("cod_perfil"), mlngRutUsuario) 'inserta perfil
            Next
            mobjCsql.i_bitacora(mlngRutUsuarioSesion, "Insertar", _
                              "Se insertó exitosamente el usuario con Rut : " _
                              & RutLngAUsr(mlngRutUsuario) & ". ", _
                              5, mlngRutUsuario)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:Insertar->" & ex.Message)
        End Try
    End Function
    Public Function InsertarEjecutivo() As Boolean
        Try
            Dim row As DataRow
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            'mobjCsql.i_Supervisor(mlngRutSupervisor, mlngRutEjecutivo)
            For Each row In Me.mdtTraspasoEjecutivo.Rows
                mobjCsql.i_Supervisor(mlngRutUsuario, row("rut_ejecutivo"))
            Next
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:InsertarEjecutivo->" & ex.Message)
        End Try
    End Function
    Public Function InsertarSucursal() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.i_sucursal(mintCodSucursal, mstrNomSucursal)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:InsertarSucursal->" & ex.Message)
        End Try
    End Function
    Public Function InsertarDirector() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.i_director_suc(mlngRutUsuario, mintCodSucursal)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:InsertarDirector->" & ex.Message)
        End Try
    End Function
    Public Function Actualizar() As Boolean Implements Clases.IMantenedor.Actualizar
        Dim strpass As String
        Dim dt As DataTable
        Dim row As DataRow
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            dt = mobjCsql.s_usuario(mlngRutUsuario)
            If Not dt Is Nothing Then 'si existe, se compara la password
                If Me.mstrClave <> "" Then
                    If DecryptINI$(dt.Rows(0)("passwd_enc").ToString.Trim) <> Me.mstrClave Then
                        strpass = EncryptINI$(Me.mstrClave)
                    Else
                        strpass = dt.Rows(0)("passwd_enc").ToString.Trim 'mantiene la antigua si no se modifica
                    End If
                    mobjCsql.u_usuario(mlngRutUsuario, mstrNombres, strpass, mstrEmail, mstrTelefono, mstrFax)
                    mobjCsql.d_perfilUsuario_porRut(mlngRutUsuario)
                    For Each row In Me.mdtTraspaso.Rows
                        mobjCsql.i_perfil_Usuario(row("cod_perfil"), mlngRutUsuario)

                    Next
                Else
                    strpass = dt.Rows(0)("passwd_enc").ToString.Trim  'mantiene la antigua si no se modifica

                    mobjCsql.u_usuario(mlngRutUsuario, mstrNombres, strpass, mstrEmail, mstrTelefono, mstrFax)
                    mobjCsql.d_perfilUsuario_porRut(mlngRutUsuario)
                    For Each row In Me.mdtTraspaso.Rows
                        mobjCsql.i_perfil_Usuario(row("cod_perfil"), mlngRutUsuario)

                    Next
                End If
                
            End If
            mobjCsql.i_bitacora(mlngRutUsuarioSesion, "Actualizar", _
                             "Se actualizó exitosamente el usuario con Rut : " _
                             & RutLngAUsr(mlngRutUsuario) & ". ", _
                             5, mlngRutUsuario)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:Actualizar-->" & ex.Message)
        End Try
    End Function
    Public Function ActualizarSupervisor() As Boolean
        Try
            Dim row As DataRow
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            For Each row In Me.mdtTraspasoEjecutivo.Rows
                mobjCsql.d_Supervisor(mlngRutUsuario, row("rut_ejecutivo"))
            Next
            For Each row In Me.mdtTraspasoEjecutivo.Rows
                mobjCsql.i_Supervisor(mlngRutUsuario, row("rut_ejecutivo"))
            Next
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:ActualizarSupervisor-->" & ex.Message)
        End Try
    End Function
    Public Function ActualizarSucursal() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.u_sucursal(mintCodSucursal, mstrNomSucursal)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True

        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:ActualizarSucursal-->" & ex.Message)
        End Try
    End Function
    Public Function ActualizarDirector() As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_director_suc(mlngRutUsuario, mintCodSucursal)
            mobjCsql.i_director_suc(mlngRutUsuario, mintCodSucursal)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            EnviaError("CMantenedorUsuario:ActualizarSucursal-->" & ex.Message)
        End Try
    End Function
    Public Function EliminarSucursal() As Boolean
        Dim respuesta As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_director_suc(mlngRutUsuario, mintCodSucursal)
            respuesta = True
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuarioYPerfil.vb:EliminarSupervisor-->" & ex.Message)
        End Try

    End Function
    Public Function Eliminar() As Boolean Implements Clases.IMantenedor.Eliminar
        Dim respuesta As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_perfilUsuario_porRut(mlngRutUsuario)
            mobjCsql.d_usuario(mlngRutUsuario)
            mobjCsql.i_bitacora(mlngRutUsuarioSesion, "Eliminar", _
                             "Se eliminó exitosamente el usuario con Rut : " _
                             & RutLngAUsr(mlngRutUsuario) & ". ", _
                             5, mlngRutUsuario)
            respuesta = True
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            respuesta = False
            Exit Function
            EnviaError("CMantenedorUsuarioYPerfil.vb:Eliminar-->" & ex.Message)
        End Try

    End Function
    Public Function EliminarSupervisor() As Boolean
        Dim respuesta As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCsql.d_Supervisor(mlngRutSupervisor, mlngRutEjecutivo)
            respuesta = True
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuarioYPerfil.vb:EliminarSupervisor-->" & ex.Message)
        End Try

    End Function
    Public Function InsertarUsuarioEmp(ByVal lngRutUsuario As Long, ByVal strNombres As String, ByVal strpass As String, _
                                    ByVal strEmail As String, ByVal strTelefono As String, ByVal strFax As String, ByVal lngRutUsuarioSesion As Long) As Boolean

        Dim row As DataRow
        Try
            mobjCsql = New CSql
            ' strpass = EncryptINI$(Me.mstrClave)
            mobjCsql.InicioTransaccion()
            mobjCsql.i_usuario(lngRutUsuario, strNombres, strpass, strEmail, strTelefono, strFax)

            mobjCsql.i_perfil_Usuario(2, lngRutUsuario) 'inserta perfil de cliente

            mobjCsql.i_bitacora(lngRutUsuarioSesion, "Insertar", _
                              "Se insertó exitosamente el usuario con Rut : " _
                              & RutLngAUsr(lngRutUsuario) & ". ", _
                              5, lngRutUsuario)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario:Insertar->" & ex.Message)
        End Try
    End Function
    Public ReadOnly Property Filas() As Integer Implements Clases.IMantenedor.Filas
        Get

        End Get
    End Property
    Public Property colEliminacion() As System.Collections.ArrayList Implements Clases.IMantenedor.colEliminacion
        Get

        End Get
        Set(ByVal value As System.Collections.ArrayList)

        End Set
    End Property
    
End Class
