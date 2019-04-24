Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorCursosSence
    Implements IMantenedor
    Private mstrCodSence As String
    Private mstrNombreCurso As String
    Private mlngRutOtec As Long
    Private mstrArea As String
    Private mstrEspecialidad As String
    Private mlngDurCurTeorico As Long
    Private mlngDurCurPractico As Long
    Private mlngDurCurElearning As Long
    Private mlngNumMaxParticipantes As Long
    Private mstrNombreSede As String
    Private mstrFonoSede As String
    Private mstrDireccion As String
    Private mlngCodComuna As Long
    Private mlngValorCurso As Long
    'Private mlngValorHoraSence As Long
    Private mintCodModalidad As Integer
    Private mlngFilas As Long
    Private mobjCsql As CSql
    Private mblnElearning As Boolean
    Private mdblValorHora As Double

    Public Property ValorHora() As Double
        Get
            Return mdblValorHora
        End Get
        Set(ByVal value As Double)
            mdblValorHora = value
        End Set
    End Property

    Public Property CodSence() As String
        Get
            Return mstrCodSence
        End Get
        Set(ByVal value As String)
            mstrCodSence = value
        End Set
    End Property
    Public Property Elearning() As Boolean
        Get
            Return mblnElearning
        End Get
        Set(ByVal value As Boolean)
            mblnElearning = value
        End Set
    End Property
   
    Public Property NombreCurso() As String
        Get
            Return mstrNombreCurso
        End Get
        Set(ByVal value As String)
            mstrNombreCurso = value
        End Set
    End Property
    Public Property RutOtec() As String
        Get
            Return RutLngAUsr(mlngRutOtec)
        End Get
        Set(ByVal value As String)
            mlngRutOtec = RutUsrALng(value)
        End Set
    End Property
    Public Property Area() As String
        Get
            Return mstrArea
        End Get
        Set(ByVal value As String)
            mstrArea = value
        End Set
    End Property
    Public Property Especialidad() As String
        Get
            Return mstrEspecialidad
        End Get
        Set(ByVal value As String)
            mstrEspecialidad = value
        End Set
    End Property
    Public Property DurCurTeorico() As Long
        Get
            Return mlngDurCurTeorico
        End Get
        Set(ByVal value As Long)
            mlngDurCurTeorico = value
        End Set
    End Property
    Public Property DurCurPractico() As Long
        Get
            Return mlngDurCurPractico
        End Get
        Set(ByVal value As Long)
            mlngDurCurPractico = value
        End Set
    End Property
    Public Property DurCurElearning() As Long
        Get
            Return mlngDurCurElearning
        End Get
        Set(ByVal value As Long)
            mlngDurCurElearning = value
        End Set
    End Property

    Public Property NumMaxParticipantes() As Long
        Get
            Return mlngNumMaxParticipantes
        End Get
        Set(ByVal value As Long)
            mlngNumMaxParticipantes = value
        End Set
    End Property
    Public Property NombreSede() As String
        Get
            Return mstrNombreSede
        End Get
        Set(ByVal value As String)
            mstrNombreSede = value
        End Set
    End Property
    Public Property FonoSede() As String
        Get
            Return mstrFonoSede
        End Get
        Set(ByVal value As String)
            mstrFonoSede = value
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
    Public Property CodComuna() As Long
        Get
            Return mlngCodComuna
        End Get
        Set(ByVal value As Long)
            mlngCodComuna = value
        End Set
    End Property
    Public Property ValorCurso() As Long
        Get
            Return mlngValorCurso
        End Get
        Set(ByVal value As Long)
            mlngValorCurso = value
        End Set
    End Property
    'Public Property ValorHoraSence() As Long
    '    Get
    '        Return mlngValorHoraSence
    '    End Get
    '    Set(ByVal value As Long)
    '        mlngValorHoraSence = value
    '    End Set
    'End Property
    Public Property CodModalidad() As Integer
        Get
            Return mintCodModalidad
        End Get
        Set(ByVal value As Integer)
            mintCodModalidad = value
        End Set
    End Property
    Public Function Consultar() As System.Data.DataTable Implements Clases.IMantenedor.Consultar
        Dim dtCursoSence As DataTable
        Try
            mobjCsql = New CSql
            dtCursoSence = mobjCsql.s_cursos_sence_m(mstrCodSence)
            If Not dtCursoSence Is Nothing Then
                Me.mlngFilas = Me.mobjCsql.Registros
                If Me.mlngFilas > 0 Then
                    mstrCodSence = dtCursoSence.Rows(0)("Codigo_sence")
                    mstrNombreCurso = dtCursoSence.Rows(0)("nombre")
                    mlngRutOtec = dtCursoSence.Rows(0)("rut_otec")
                    mstrArea = dtCursoSence.Rows(0)("area")
                    mstrEspecialidad = dtCursoSence.Rows(0)("especialidad")
                    mlngDurCurTeorico = dtCursoSence.Rows(0)("dur_cur_teorico")
                    mlngDurCurPractico = dtCursoSence.Rows(0)("dur_cur_prac")
                    mlngNumMaxParticipantes = dtCursoSence.Rows(0)("num_max_part")
                    mstrNombreSede = dtCursoSence.Rows(0)("nombre_sede")
                    mstrFonoSede = dtCursoSence.Rows(0)("fono_sede")
                    mstrDireccion = dtCursoSence.Rows(0)("direccion")
                    mlngCodComuna = dtCursoSence.Rows(0)("cod_comuna")
                    mlngValorCurso = dtCursoSence.Rows(0)("valor_curso")
                    mintCodModalidad = dtCursoSence.Rows(0)("cod_modalidad")
                    mdblValorHora = dtCursoSence.Rows(0)("valor_hora")
                    mlngDurCurElearning = dtCursoSence.Rows(0)("dur_cur_elearning")
                End If
            End If
            Return dtCursoSence
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql = Nothing
            EnviaError("CMantenedorUsuario.vb:Consultar-->" & ex.Message)
        End Try
    End Function

    Public Function Insertar() As Boolean Implements Clases.IMantenedor.Insertar
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            If mintCodModalidad = 1 Then
                mblnElearning = False
            Else
                mblnElearning = True
            End If
            mobjCsql.i_cursos(mstrCodSence, mstrNombreCurso, mlngRutOtec, mstrArea, mstrEspecialidad, mlngDurCurTeorico, _
                            mlngDurCurPractico, mlngNumMaxParticipantes, mstrNombreSede, mstrFonoSede.Trim, mstrDireccion, mlngCodComuna, _
                            False, mlngValorCurso, mblnElearning, mintCodModalidad, mlngDurCurElearning, mdblValorHora)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
        End Try
    End Function
    Public Function ExisteCursoSence() As Boolean
        mobjCsql = New CSql
        If mobjCsql.s_existe_CursosSence(mstrCodSence) Then
            Return True
        Else
            Return False
        End If
        mobjCsql = Nothing
    End Function
    Public Function ExisteOtec() As Boolean
        mobjCsql = New CSql
        If mobjCsql.s_existe_otec(mlngRutOtec) Then
            Return True
        Else
            Return False
        End If
        mobjCsql = Nothing
    End Function

    Public Function Actualizar() As Boolean Implements Clases.IMantenedor.Actualizar
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            If mintCodModalidad = 1 Then
                mblnElearning = False
            Else
                mblnElearning = True
            End If
            mobjCsql.u_Cursos(mstrCodSence, mstrNombreCurso, mlngRutOtec, mstrArea, mstrEspecialidad, mlngDurCurTeorico, _
                            mlngDurCurPractico, mlngNumMaxParticipantes, mstrNombreSede, mstrFonoSede.Trim, mstrDireccion, mlngCodComuna, _
                            False, mlngValorCurso, mblnElearning, mintCodModalidad, mlngDurCurElearning, mdblValorHora)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            Return False
        End Try
    End Function
    'Public Function ActualizaValorHoraSence(ByVal mlngAgno As Long, ByVal mlngValorHoraSence As Long, ByVal mintCodModalidad As Integer, ByVal mstrCodigoSence As String)
    '    Try
    '        mobjCsql = New CSql
    '        mobjCsql.InicioTransaccion()
    '        mobjCsql.u_valor_hora_sence2(mlngAgno, mlngValorHoraSence, True, mintCodModalidad, mstrCodigoSence)
    '        mobjCsql.FinTransaccion()
    '        mobjCsql = Nothing
    '        Return True
    '    Catch ex As Exception
    '        mobjCsql.RollBackTransaccion()
    '        mobjCsql = Nothing
    '        Return False
    '    End Try

    'End Function
    'Public Function InsertarValorHoraSence(ByVal mlngAgno As Long, ByVal mlngValorHoraSence As Long, ByVal mintCodModalidad As Integer, ByVal mstrCodigoSence As String)
    '    Try
    '        mobjCsql = New CSql
    '        mobjCsql.InicioTransaccion()
    '        mobjCsql.i_valor_hora_sence2(mlngAgno, mlngValorHoraSence, True, mintCodModalidad, mstrCodigoSence)
    '        mobjCsql.FinTransaccion()
    '        mobjCsql = Nothing
    '        Return True
    '    Catch ex As Exception
    '        mobjCsql.RollBackTransaccion()
    '        mobjCsql = Nothing
    '        Return False
    '    End Try

    'End Function

    Public Function Eliminar() As Boolean Implements Clases.IMantenedor.Eliminar

    End Function

    Public Sub InicializarNuevo() Implements Clases.IMantenedor.InicializarNuevo
        mstrCodSence = ""
        mstrNombreCurso = ""
        mlngRutOtec = 0
        mstrArea = ""
        mstrEspecialidad = ""
        mlngDurCurTeorico = 0
        mlngDurCurPractico = 0
        mlngDurCurElearning = 0
        mlngNumMaxParticipantes = 0
        mstrNombreSede = ""
        mstrFonoSede = ""
        mstrDireccion = ""
        mlngCodComuna = 0
        mlngValorCurso = 0
        mdblValorHora = 0.0
    End Sub
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
