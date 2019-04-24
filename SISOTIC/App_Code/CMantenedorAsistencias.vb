Imports Clases
Imports Modulos
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic

Public Class CMantenedorAsistencias
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
    Private mlngCorrelativo As Long
    Private mintAgno As Integer


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
    Public Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
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
    Public Function ListadoParticipantes() As DataTable
        Try
            mobjCsql = New CSql
            mlngNumAlumnos = mobjCsql.s_nro_participantes(mlngCodCurso)
            mlngCorrelativo = mobjCsql.s_correlativo2(mintAgno, mlngCodCurso)
            mdtParticipantes = mobjCsql.s_participantes(mlngCodCurso)
            Return mdtParticipantes
        Catch ex As Exception
            EnviaError("CMantenedorAsistencias:ListadoParticipantes-->" & ex.Message)
        End Try
    End Function
    Public Function ValidarCursoAnulado() As Boolean
        Try
            mobjCsql = New CSql
            mobjCurso = New CCursoContratado
            mobjCurso.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCurso.Inicializar1(mlngCodCurso)
            If mobjCurso.ValidarCursoAnulado() Then
                ValidarCursoAnulado = True
            Else
                ValidarCursoAnulado = False
            End If
        Catch ex As Exception
            EnviaError("CMantenedorAsistencias:ValidarCursoAnulado-->" & ex.Message)
        End Try
    End Function
    Public Function RegistrarAsistencia() As Boolean
        Try
            mobjCsql = New CSql
            mobjCurso = New CCursoContratado
            mobjCurso.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCurso.Inicializar1(mlngCodCurso)
            'mobjCsql.InicioTransaccion 
            If mobjCurso.RegistrarAsistenciaAlumnos2() Then
                RegistrarAsistencia = True
            Else
                RegistrarAsistencia = False
                'Call mobjCsql.RollBackTransaccion()
                Exit Function
            End If


            ' mobjCsql.FinTransaccion()
            RegistrarAsistencia = True
        Catch ex As Exception
            'Call mobjCsql.RollBackTransaccion()
            EnviaError("CMantenedorAsistencias:RegistrarAsistencia-->" & ex.Message)

        End Try
    End Function

    Public Function ChequearMontoCuentasAsignada() As Boolean
        Try
            mobjCsql = New CSql
            mobjCurso = New CCursoContratado
            mobjCurso.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCurso.Inicializar1(mlngCodCurso)
            'mobjCsql.InicioTransaccion 
            If mobjCurso.ChequearMontoCuentasAsignadas() Then
                ChequearMontoCuentasAsignada = True
            Else
                ChequearMontoCuentasAsignada = False
                'Call mobjCsql.RollBackTransaccion()
                Exit Function
            End If
            ' mobjCsql.FinTransaccion()
            ChequearMontoCuentasAsignada = True
        Catch ex As Exception
            'Call mobjCsql.RollBackTransaccion()
            EnviaError("CMantenedorAsistencias:RegistrarAsistencia-->" & ex.Message)

        End Try
    End Function
    Public Function AnularCurso() As Boolean
        Try
            mobjCsql = New CSql
            mobjCurso = New CCursoContratado
            mobjCurso.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCurso.Inicializar1(mlngCodCurso)
            mobjCsql.InicioTransaccion()
            If mobjCurso.CambiarEstAnuladoPorAsistencia() Then
                AnularCurso = True
            Else
                AnularCurso = False
                Call mobjCsql.RollBackTransaccion()
                Exit Function
            End If
            mobjCsql.FinTransaccion()
            AnularCurso = True
        Catch ex As Exception
            Call mobjCsql.RollBackTransaccion()
            EnviaError("CMantenedorAsistencias:AnularCurso-->" & ex.Message)

        End Try
    End Function
    Public Function ActualizarAsistencia(ByVal lngRutAlumno As Long, ByVal dblPorcAsistencia As Double) As Boolean
        Try
            mobjCsql = New CSql
            Call mobjCsql.InicioTransaccion()
            Call mobjCsql.u_porc_asist_part(mlngCodCurso, lngRutAlumno, dblPorcAsistencia)
            'cerrar transacción y conexion
            Call mobjCsql.FinTransaccion()
            ActualizarAsistencia = True
            Exit Function
        Catch ex As Exception
            Call mobjCsql.RollBackTransaccion()
            EnviaError("CMantenedorAsistencias:ActualizarAsistencia-->" & ex.Message)

        End Try
    End Function
    Public Function ActualizarAsistencia2(ByVal lngRutAlumno As Long, ByVal dblPorcAsistencia As Double, ByVal notaObtenida As Double, ByVal detalleAsistencia As String) As Boolean
        Try
            mobjCsql = New CSql
            Call mobjCsql.InicioTransaccion()
            Call mobjCsql.u_porc_asist_part2(mlngCodCurso, lngRutAlumno, dblPorcAsistencia, notaObtenida) ', notaAlum, detalleAsistencia)
            'cerrar transacción y conexion
            Call mobjCsql.FinTransaccion()
            ActualizarAsistencia2 = True
            Exit Function
        Catch ex As Exception
            Call mobjCsql.RollBackTransaccion()
            EnviaError("CMantenedorAsistencias:ActualizarAsistencia-->" & ex.Message)

        End Try
    End Function
    Public Sub CargaArchivo(ByVal strArchivo As String)
        Try
            mobjCsql = New CSql
            Dim objcursoContratado As New CCursoContratado
            objcursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            objcursoContratado.Inicializar1(mlngCodCurso)
            Dim file As FileStream
            file = New FileStream(strArchivo, FileMode.Open)
            Dim reader As New StreamReader(file, System.Text.Encoding.UTF7)
            Dim strDatos As String
            Dim arrAlumnos() As String
            Dim intArreglo As Long
            While Not reader.EndOfStream
                strDatos = reader.ReadLine
                arrAlumnos = strDatos.Split(";")
                intArreglo = TamanoArreglo1(arrAlumnos)
                If intArreglo <> 2 Then
                    MsgBox("Tamaño del archivo no es el indicado")
                    Exit Sub
                End If
                Dim dr As DataRow

                Dim lngRutAlumno As Long
                Dim dblPorcentaje As Double
                'Columna rut
                lngRutAlumno = RutUsrALng(arrAlumnos(0))
                'Columna asistencia
                If IsNumeric(arrAlumnos(1)) Then dblPorcentaje = arrAlumnos(1)
                Call mobjCsql.InicioTransaccion()
                Call mobjCsql.u_porc_asist_part(mlngCodCurso, lngRutAlumno, dblPorcentaje)
                Call mobjCsql.FinTransaccion()
            End While
            file.Close()
            objcursoContratado.ObtenerAlumnos()
            objcursoContratado.GrabarAlumnos()
            objcursoContratado.CalcularCostos()
            objcursoContratado.CalcCostoAdm()
            objcursoContratado.CalcHorasCurso()
            ListadoParticipantes()
        Catch ex As Exception
            EnviaError("CMantenedorAsistencias:CargaArchivo-->" & ex.Message)
        End Try
    End Sub
    Public Sub AgregaLog(ByVal lngRutAlumno As Long, ByVal dblPorcFranquicia As Double, ByVal lngViatico As Long, ByVal lngTraslado As Long, _
    ByVal lngPorcentaje As Double, ByVal strApPaterno As String, ByVal strApMaterno As String, ByVal strNombre As String, ByVal strDescripcion As String)
        Dim dr As DataRow
        dr = mdtLog.NewRow
        dr("rut_alumno") = lngRutAlumno
        dr("porc_franquicia") = dblPorcFranquicia
        dr("viatico") = lngViatico
        dr("traslado") = lngTraslado
        dr("porc_asistencia") = lngPorcentaje
        dr("ap_paterno") = strApPaterno
        dr("ap_materno") = strApMaterno
        dr("nombre") = strNombre
        dr("descripcion") = strDescripcion
        mdtLog.Rows.Add(dr)
    End Sub
End Class
