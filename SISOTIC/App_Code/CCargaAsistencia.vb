Imports Clases
Imports Modulos
Imports System.Data
Imports System.IO

Public Class CCargaAsistencia

    Private mobjCsqlExcel As CSql

    Private mobjCsql As CSql
    Private mobjCurso As CCursoContratado
    Private mcolAlumnos As Collection
    Private mlngNumAlumnos As Long
    Private mlngRutUsuario As Long
    Private mlngCodCurso As Long
    Private mlngRut As Long
    Private mstrNombres As String
    Private mstrApPaterno As String
    Private mstrApMaterno As String
    Private mlngFranquicia As Long
    Private mlngViatico As Long
    Private mlngTraslado As Long
    Private mstrPorcAsistencia As String
    Private mdtLog As DataTable
    Private mdtParticipantes As DataTable
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
        End Set
    End Property
    Public Property Rut() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
        End Set
    End Property
    Public ReadOnly Property Nombres() As String
        Get
            Return mstrNombres
        End Get
    End Property
    Public ReadOnly Property ApPaterno() As String
        Get
            Return mstrApPaterno
        End Get
    End Property
    Public ReadOnly Property ApMaterno() As String
        Get
            Return mstrApMaterno
        End Get
    End Property
    Public ReadOnly Property Franquicia() As Long
        Get
            Return mlngFranquicia
        End Get
    End Property
    Public ReadOnly Property Viatico() As Long
        Get
            Return mlngViatico
        End Get
    End Property
    Public ReadOnly Property Traslado() As Long
        Get
            Return mlngTraslado
        End Get
    End Property
    Public Property PorcAsistencia() As String
        Get
            Return mstrPorcAsistencia
        End Get
        Set(ByVal value As String)
            mstrPorcAsistencia = value
        End Set
    End Property
    Public ReadOnly Property NumAlumnos() As Long
        Get
            Return mlngNumAlumnos
        End Get
    End Property
    Public ReadOnly Property DtLog() As DataTable
        Get
            DtLog = mdtLog
        End Get
    End Property
    Public Property DtParticipantes() As DataTable
        Get
            Return mdtParticipantes
        End Get
        Set(ByVal value As DataTable)
            mdtParticipantes = value
        End Set
    End Property
    Public Sub Inicializar(ByVal lngRutUsuario As Long)
        Try
            If lngRutUsuario <= 0 Then
                EnviaError("CMantenedorAsistencias:Inicializar0")
                Exit Sub
            End If
            mlngRutUsuario = lngRutUsuario
            mdtLog = New DataTable
            mdtLog.Columns.Add("rut_alumno")
            mdtLog.Columns.Add("porc_franquicia")
            mdtLog.Columns.Add("viatico")
            mdtLog.Columns.Add("traslado")
            mdtLog.Columns.Add("porc_asistencia")
            mdtLog.Columns.Add("ap_paterno")
            mdtLog.Columns.Add("ap_materno")
            mdtLog.Columns.Add("nombre")
            mdtLog.Columns.Add("descripcion")
        Catch ex As Exception
            EnviaError("CCargaCursos:Inicializar0" & ex.Message)
        End Try
    End Sub
    Public Sub CargaArchivo(ByVal strArchivo As String, ByVal Agno As Integer)
        Dim correlError As String
        Dim rutError As String
        Try

            mobjCsqlExcel = New CSql
            mobjCsqlExcel.MotorDb = "excel8"
            mobjCsqlExcel.BD = strArchivo

            Dim dtCorrelInterno As DataTable
            dtCorrelInterno = mobjCsqlExcel.s_correl_interno_excel

            Dim drCorrelInterno As DataRow
            For Each drCorrelInterno In dtCorrelInterno.Rows

                mobjCsql = New CSql


                Dim lngCodCurso As Long
                lngCodCurso = mobjCsql.s_cod_curso_desde_correl_interno(drCorrelInterno("correlativo_empresa"))
                correlError = drCorrelInterno("correlativo_empresa")
                If mobjCsql.s_existe_curso_agno(lngCodCurso, Agno) Then
                    Dim objcursoContratado As New CCursoContratado
                    objcursoContratado.Inicializar0(mobjCsql, 13432851)
                    objcursoContratado.Inicializar1(lngCodCurso)

                    Dim dtParticipantes As DataTable
                    dtParticipantes = mobjCsqlExcel.s_participante_correl_interno_excel(drCorrelInterno("correlativo_empresa"))
                    Dim drParticipante As DataRow
                    For Each drParticipante In dtParticipantes.Rows
                        Dim lngRutAlumno As Long
                        Dim dblPorcentaje As Double
                        'Columna rut
                        lngRutAlumno = RutUsrALng(drParticipante(1))
                        rutError = drParticipante(1)
                        'Columna asistencia
                        If IsNumeric(drParticipante(2)) Then dblPorcentaje = drParticipante(2)
                        Call mobjCsql.InicioTransaccion()
                        Call mobjCsql.u_porc_asist_part(lngCodCurso, lngRutAlumno, dblPorcentaje)
                        Call mobjCsql.FinTransaccion()
                    Next
                    objcursoContratado.ObtenerAlumnos()
                    objcursoContratado.GrabarAlumnos()
                    objcursoContratado.GrabarInfoCuentas2()
                    'objcursoContratado.CalcularCostos2()
                    'objcursoContratado.CalcCostoAdm()
                    objcursoContratado.CalcHorasCurso()
                    objcursoContratado.ActualizarDatos2(3)
                End If
            Next
        Catch ex As Exception
            EnviaError("CMantenedorAsistencias:CargaArchivo--> correl " & correlError & " rut " & rutError & ex.Message)
        End Try
    End Sub
End Class
