Imports Modulos
Imports Clases
Imports System.Data
Imports System.Web

Public Class CCargaCursos
    'objsql
    Private mobjSql As CSql

    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrNombreArchivoResp As String

    'objeto usuario
    Private mobjUsuario As CUsuario
    'rut del usuario
    Private mlngRutUsuario As Long
    'nombre y ruta del archivo mdb que tiene la información de los cursos
    Private mstrNombreArchivo As String

    Private mbolRestringirCursoEmpresa As Boolean
    Private mlngRutEmpresaUsuario As Long
    Private mstrNombreUsuario As String
    Private mstrEmailUsuario As String

    Private mdtLog As DataTable

    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property
    Public Property BajarXml() As Boolean
        Get
            Return Me.mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXml = value
        End Set
    End Property
    Public ReadOnly Property Filas() As Integer
        Get
            Return mlngFilas
        End Get
    End Property
    Public WriteOnly Property Archivo() As String
        Set(ByVal value As String)
            mstrNombreArchivo = value
        End Set
    End Property
    Public WriteOnly Property RestringirCursoEmpresa() As Boolean
        Set(ByVal value As Boolean)
            mbolRestringirCursoEmpresa = value
        End Set
    End Property
    Public WriteOnly Property RutEmpresaUsuario() As Long
        Set(ByVal value As Long)
            mlngRutEmpresaUsuario = value
        End Set
    End Property
    Public WriteOnly Property NombreUsuario() As String
        Set(ByVal value As String)
            mstrNombreUsuario = value
        End Set
    End Property
    Public WriteOnly Property EmailUsuario() As String
        Set(ByVal value As String)
            mstrEmailUsuario = value
        End Set
    End Property
    Public ReadOnly Property NombreArchivoResp() As String
        Get
            NombreArchivoResp = mstrNombreArchivoResp
        End Get
    End Property
    Public ReadOnly Property DtLog() As DataTable
        Get
            DtLog = mdtLog
        End Get
    End Property

    Public Sub Inicializar(ByVal lngRutUsuario As Long)
        Try
            If lngRutUsuario <= 0 Then
                EnviaError("CCargaCursos:Inicializar0")
                Exit Sub
            End If
            mlngRutUsuario = lngRutUsuario
            mdtLog = New DataTable
            mdtLog.Columns.Add("Tipo")
            mdtLog.Columns.Add("IdEmpresa")
            mdtLog.Columns.Add("IdNuevo")
            mdtLog.Columns.Add("Descripcion")
            mdtLog.Columns.Add("CodSence")
            mdtLog.Columns.Add("ValorTotal")
            mdtLog.Columns.Add("ValorCurso")
            mdtLog.Columns.Add("CostoOtic")
            mdtLog.Columns.Add("Estado")
        Catch ex As Exception
            EnviaError("CCargaCursos:Inicializar0" & ex.Message)
        End Try
    End Sub

    'llena los logs de tipo datatable
    Private Sub AgregaRegLogDt(ByVal strMensaje As String, ByRef dt As System.Data.DataTable)
        Dim dr As System.Data.DataRow
        dr = dt.NewRow
        dr("log") = strMensaje
        dt.Rows.Add(dr)
    End Sub
    'proceso que carga cursos en el sistema a partir de una base de datos access
    Public Function CargarCursos() As DataTable
        Try
            'Dim fs
            'Dim dbAccess As Database
            'Dim rst 'As Recordset
            'Dim rst1 'As Recordset
            'Dim rst2 'As Recordset
            'Dim rst3
            'Dim rstTmp
            'Dim strQuery As String
            Dim objCurso As CCursoContratado
            'Dim objLogs, lngTamanoLog As Long

            Dim horario As New DataTable
            horario.Columns.Add("Dia")
            horario.Columns.Add("HoraInicio")
            horario.Columns.Add("HoraFin")
            horario.Columns.Add("CodCurso")

            mobjSql = New CSql
            Dim mobjCsqlMDB As New CSql
            mobjCsqlMDB.MotorDb = "ACCESS2K"
            mobjCsqlMDB.BD = mstrNombreArchivo
            mobjCsqlMDB.Usuario = ""
            mobjCsqlMDB.Clave = ""



            Dim dt1 As New DataTable
            dt1 = mobjCsqlMDB.s_carga_mdb_1()

            If mobjCsqlMDB.Registros > 0 Then
                Dim strRutCliente As String, tipoactividad As Integer, combip As Integer
                Dim detnec As Integer, numalumnos As Integer, Direccion As String
                Dim Comuna As Long, CodSence As String, finicio As Date
                Dim ftermino As Date, hrscompl As Integer, ValorMercado As Long
                Dim Descuento As Long, CorrEmp As String, IndDescPorc As Integer
                Dim Contacto As String, obs As String, Agno As Integer
                Dim i As Integer, num_alumnos As Integer
                Dim al As CAlumno

                'datos del alumno
                Dim Alumnos As Collection
                Dim strRutAlumno As String, alApPaterno As String, alApMaterno As String, alNombres As String
                Dim alFechaNac As String, alSexo As String, RutEmp As String
                Dim alPorcFranq As Double, alCodNivOcup As Integer, alCodNivEduc As Integer
                Dim alCodRegion As Integer, alViatico As Long, alTraslado As Long
                Dim alCodComuna As Long

                'datos de la direccion
                Dim dirNombre, dirCiudad, dirNumero As String
                Dim dirCodComuna As Long
                Dim objCliente As CCliente

                Dim dr1 As DataRow
                For Each dr1 In dt1.Rows
                    objCurso = New CCursoContratado
                    Call objCurso.Inicializar0(mobjSql, mlngRutUsuario)
                    If Not IsDBNull(dr1("id_comunicador")) Then
                        strRutCliente = RutLngAUsr(dr1("id_comunicador"))
                    Else
                        strRutCliente = 0
                    End If
                    If mbolRestringirCursoEmpresa Then
                        If Trim(mlngRutEmpresaUsuario) <> Trim(dr1("id_comunicador")) Then
                            '*********************************************************************
                            '************************** AGREGA LOG *******************************
                            '*********************************************************************
                            AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "No esta autorizado para cargar cursos de este cliente: " & strRutCliente, _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                            GoTo NuevoRegistro
                        End If
                    End If
                    objCliente = New CCliente
                    objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                    If Not objCliente.Inicializar1(strRutCliente) Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El rut del cliente no esta registrado en el sistema: " & strRutCliente, _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    'valida que no exista el curso de esa empresa, corr. interno
                    Agno = Year(dr1("fec_ini_acc_cap"))
                    If mobjSql.existe_curso_empresa(dr1("id_comunicador"), IIf(IsDBNull(dr1("id_acc_cap")), -1, dr1("id_acc_cap")), Agno, True) Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El curso ya fue ingresado en el sistema. correlativo empresa " & CStr(dr1("id_acc_cap")), _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    tipoactividad = IIf(IsDBNull(dr1("tipo_actividad_cap")), 0, dr1("tipo_actividad_cap"))
                    If CInt(tipoactividad) <= 0 Or CInt(tipoactividad) > 3 Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El cód. tipo de actividad debe ser entre 0 y 4", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    combip = IIf(IsDBNull(dr1("ind_acu_com_bip")), 0, dr1("ind_acu_com_bip"))
                    If CInt(combip) <> 0 And CInt(combip) <> 1 Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El campo ind_acu_com_bip debe ser igual a 0 ó 1", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    detnec = CInt(IIf(IsDBNull(dr1("id_det_nece")), 0, dr1("id_det_nece")))
                    If CInt(detnec) <> 0 And CInt(detnec) <> 1 Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El campo id_det_nece debe ser igual a 0 ó 1", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    numalumnos = 0
                    Direccion = IIf(IsDBNull(dr1("dir_acc_cap")), "", dr1("dir_acc_cap"))
                    Comuna = IIf(IsDBNull(dr1("id_comuna")), 0, dr1("id_comuna"))
                    If Not mobjSql.s_existe_comuna(Comuna) Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El código de la comuna " & Comuna & " de este curso no esta registrado en el sistema", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    CodSence = Trim(IIf(IsDBNull(dr1("cod_sence")), "", dr1("cod_sence")))
                    If Not mobjSql.s_existe_CursosSence(CodSence) Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El curso" & CodSence & " no esta registrado en sistema", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    Dim mlngValorCursoSence As Long
                    Dim mlngMaxPartSence As Long
                    Dim lngNumerodeParticipantes As Long
                    'se obtiene el valor del curso sence
                    mlngValorCursoSence = mobjSql.s_valor_curso_sence(Trim(dr1("cod_sence")))
                    ' se obtiene el tope máximo de participantes
                    mlngMaxPartSence = mobjSql.s_num_max_part_sence(Trim(dr1("cod_sence")))

                    'Se obtiene la cantidad de participantes cargados
                    lngNumerodeParticipantes = mobjCsqlMDB.s_carga_mdb_2(IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap"))) 'rstTmp("num_participantes")
                    If mlngMaxPartSence < lngNumerodeParticipantes Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "Se ha superado el tope máximo de alumnos Sence", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    If CLng(mlngValorCursoSence) > 0 Then
                        ' se compara el valor total del curso sence
                        ' dividido por el nro. maximo de participante y multiplicado por
                        ' la cantidad de participantes efectivos y se compara con el monto ingresado
                        ' si se supera valor maximo se agrega error
                        If (((CLng(mlngValorCursoSence) / CLng(mlngMaxPartSence)) * CLng(lngNumerodeParticipantes)) < CLng(Trim(dr1("valor_total_curso")))) Then
                            '*********************************************************************
                            '************************** AGREGA LOG *******************************
                            '*********************************************************************
                            AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "El valor total del cursos supera el valor de referencia de Sence", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), Trim(dr1("valor_total_curso")), "", "RE")
                            GoTo NuevoRegistro
                        End If
                    End If
                    finicio = IIf(IsDBNull(dr1("fec_ini_acc_cap")), CDate(FechaMinSistema()), dr1("fec_ini_acc_cap"))
                    ftermino = IIf(IsDBNull(dr1("fec_ter_acc_cap")), CDate(FechaMinSistema()), dr1("fec_ter_acc_cap"))

                    If CDate(finicio) < DateAdd("d", -1, Now) Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "La fecha de inicio del curso debe ser mayor a la fecha actual", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    If CDate(finicio) > CDate(ftermino) Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                   "La fecha de inicio del curso debe ser menor a la fecha fin", _
                                   Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    If Year(CDate(finicio)) > Year(Now) + 1 Or Year(CDate(ftermino)) > Year(Now) + 1 Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                   "Las fechas de inicio y término deben estar en año actual o siguiente.", _
                                   Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    hrscompl = 0
                    ValorMercado = IIf(IsDBNull(dr1("valor_total_curso")), 0, dr1("valor_total_curso"))
                    If ValorMercado <= 0 Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                   "El valor total del curso debe ser mayor a 0", _
                                   Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    Descuento = 0
                    CorrEmp = IIf(IsDBNull(dr1("id_acc_cap")), "", dr1("id_acc_cap"))
                    IndDescPorc = 1
                    Contacto = "" 'rst("id_usuario_empresa")
                    obs = IIf(IsDBNull(dr1("observ_acc_cap")), "", dr1("observ_acc_cap"))
                    If Len(obs) + 24 <= 255 Then
                        obs = obs & ".Carga Masiva de cursos."
                    End If
                    Agno = Year(IIf(IsDBNull(dr1("fec_ini_acc_cap")), CDate(FechaMinSistema()), dr1("fec_ini_acc_cap")))
                    '*********************************************************
                    'Detalle de la direccion del curso
                    '*********************************************************
                    'consulta por la direccion del curso                   
                    Dim dt2 As New DataTable
                    dt2 = mobjCsqlMDB.s_carga_mdb_3(IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")))
                    If mobjCsqlMDB.Registros > 0 Then
                        If mobjCsqlMDB.Registros > 1 Then
                            '*********************************************************************
                            '************************** AGREGA LOG *******************************
                            '*********************************************************************
                            AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                   "Existe más de una dirección para el curso.", _
                                   Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                            GoTo NuevoRegistro
                        Else
                            Dim dr2 As DataRow
                            For Each dr2 In dt2.Rows
                                'Nombre de la direccion en la tabla de detalle
                                If Trim(IIf(IsDBNull(dr2("nombre_dire")), "", dr2("nombre_dire"))) = "" Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                       "No existe el nombre de la dirección.", _
                                       Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    GoTo NuevoRegistro
                                End If
                                dirNombre = Trim(dr2("nombre_dire"))
                                'Ciudad en la tabla de detalle de la direccion
                                If Trim(IIf(IsDBNull(dr2("ciudad")), "", dr2("ciudad"))) = "" Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                       "La ciudad no existe en el curso. ", _
                                       Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    GoTo NuevoRegistro
                                End If
                                dirCiudad = Trim(dr2("ciudad"))
                                'Numero de la direccion en la tabla de detalle de la direccion
                                If Trim(IIf(IsDBNull(dr2("n_dire")), "", dr2("n_dire"))) = "" Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                       "Número de la dirección no existe. ", _
                                       Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    GoTo NuevoRegistro
                                End If
                                dirNumero = Trim(dr2("n_dire"))
                                If Not mobjSql.s_existe_comuna(CLng(IIf(IsDBNull(dr2("id_comuna")), 0, dr2("id_comuna")))) Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                       "El id de la comuna de la dirección no existe. ", _
                                       Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    GoTo NuevoRegistro
                                Else
                                    If CLng(IIf(IsDBNull(dr2("id_comuna")), 0, dr2("id_comuna"))) <> Comuna Then
                                        '*********************************************************************
                                        '************************** AGREGA LOG *******************************
                                        '*********************************************************************
                                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                           "La comuna en el curso es diferente a la del detalle de la dirección. ", _
                                           Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                        GoTo NuevoRegistro
                                    End If
                                End If
                                dirCodComuna = CLng(IIf(IsDBNull(dr2("id_comuna")), 0, dr2("id_comuna")))
                            Next
                        End If
                    Else
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                             "El curso no tiene los destalles del lugar de ejecución(dirección).", _
                             Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    objCurso.Inicializar2(strRutCliente, tipoactividad, combip, detnec, numalumnos, dirNombre, dirCodComuna, CodSence, FechaVbAUsr(finicio), FechaVbAUsr(ftermino), hrscompl, ValorMercado, Descuento, CorrEmp, IndDescPorc, Contacto, obs, dirNumero, dirCiudad, Agno)
                    'Horario
                    horario = objCurso.HorarioCurso

                    Dim dt3 As New DataTable
                    dt3 = mobjCsqlMDB.s_carga_mdb_4(IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")))
                    If mobjCsqlMDB.Registros > 0 Then
                        Dim dr3 As DataRow
                        For Each dr3 In dt3.Rows
                            If CInt(IIf(IsDBNull(dr3("dia_clase")), 0, dr3("dia_clase"))) < 1 _
                                Or CInt(IIf(IsDBNull(dr3("dia_clase")), 0, dr3("dia_clase"))) > 7 Then
                                '*********************************************************************
                                '************************** AGREGA LOG *******************************
                                '*********************************************************************
                                AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "Horario del curso, el dia debe ser un numero entre 1 y 7.", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                GoTo NuevoRegistro
                            End If
                            'valida que la hora de inicio sea menor que la de termino
                            If ValidaHoras(IIf(IsDBNull(dr3("hora_desde")), "", dr3("hora_desde")), _
                                            IIf(IsDBNull(dr3("hora_hasta")), "", dr3("hora_hasta"))) = -2 Then
                                '*********************************************************************
                                '************************** AGREGA LOG *******************************
                                '*********************************************************************
                                AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "Error horario, el formato de la hora debe ser Hora:Minutos.", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                GoTo NuevoRegistro
                            End If

                            If ValidaHoras(IIf(IsDBNull(dr3("hora_desde")), "", dr3("hora_desde")), _
                                            IIf(IsDBNull(dr3("hora_hasta")), "", dr3("hora_hasta"))) = -3 Then
                                '*********************************************************************
                                '************************** AGREGA LOG *******************************
                                '*********************************************************************
                                AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "Error en , las horas deben ser numeros entre 0 y 23 y minutos entre 0 y 59", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                GoTo NuevoRegistro
                            End If

                            If ValidaHoras(IIf(IsDBNull(dr3("hora_desde")), "", dr3("hora_desde")), _
                                            IIf(IsDBNull(dr3("hora_hasta")), "", dr3("hora_hasta"))) <= 0 Then
                                '*********************************************************************
                                '************************** AGREGA LOG *******************************
                                '*********************************************************************
                                AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                    "Error en horario, la hora de inicio  debe ser menor a la hora término.", _
                                    Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                GoTo NuevoRegistro
                            End If

                            Dim drHorario As DataRow
                            drHorario = horario.NewRow
                            drHorario("Dia") = IIf(IsDBNull(dr3("dia_clase")), 0, dr3("dia_clase"))
                            drHorario("HoraInicio") = IIf(IsDBNull(dr3("hora_desde")), "", dr3("hora_desde"))
                            drHorario("HoraFin") = IIf(IsDBNull(dr3("hora_hasta")), "", dr3("hora_hasta"))
                            drHorario("CodCurso") = 0
                            horario.Rows.Add(drHorario)
                        Next
                        objCurso.HorarioCurso = horario
                    Else
                        ''el curso no tiene horario
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                             "El curso no tiene ningún horario asignado.", _
                             Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    'abrir conexion y transaccion
                    mobjSql.InicioTransaccion()

                    objCurso.GrabarDatos()

                    'actualizar la data
                    objCurso.CalcHorasCurso()
                    objCurso.CalcCostoAdm()
                    objCurso.ActualizarDatos(0)        'El parametro 0 indica que no escriba en la bitacora


                    num_alumnos = mobjCsqlMDB.s_carga_mdb_2(IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")))
                    If Not num_alumnos > 0 Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                            "El curso no tiene alumnos ingresados.", _
                            Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        mobjSql.RollBackTransaccion()
                        GoTo NuevoRegistro
                    End If

                    'objCurso.Participantes = num_alumnos

                    'Alumnos
                    Alumnos = objCurso.Alumnos

                    Dim dt4 As New DataTable
                    dt4 = mobjCsqlMDB.s_carga_mdb_5(IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")))

                    Dim blnEsDesconocido As Boolean
                    Dim dr4 As DataRow
                    If mobjCsqlMDB.Registros > 0 Then
                        For Each dr4 In dt4.Rows
                            i = 0
                            blnEsDesconocido = False
                            If mobjSql.s_existe_persona_natural(dr4("rut_num_pers_nat"), dr4("rut_num_pers_jur")) _
                                    And (IsDBNull(dr4("porc_franq")) Or dr4("porc_franq") = 0) _
                                    And (IsDBNull(dr4("id_niv_ocu")) Or dr4("id_niv_ocu") = 0) _
                                    And (IsDBNull(dr4("id_region")) Or dr4("id_region") = 0) _
                                    And (IsDBNull(dr4("id_escolaridad")) Or dr4("id_region") = 0) Then
                                Dim dtTemporal As New DataTable
                                dtTemporal = mobjSql.s_datos_persona_natural(dr4("rut_num_pers_nat"))
                                strRutAlumno = RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat")))
                                alApPaterno = dtTemporal.Rows(0).Item(0)
                                alApMaterno = dtTemporal.Rows(0).Item(1)
                                alNombres = dtTemporal.Rows(0).Item(2)
                                alFechaNac = dtTemporal.Rows(0).Item(3)
                                alSexo = dtTemporal.Rows(0).Item(4)
                                alCodNivEduc = dtTemporal.Rows(0).Item(5)
                                alCodComuna = dtTemporal.Rows(0).Item(6)
                                alCodNivOcup = dtTemporal.Rows(0).Item(7)
                                alPorcFranq = dtTemporal.Rows(0).Item(8)
                                If IsDBNull(dr4("Viatico")) Or dr4("Viatico") <= 0 Then
                                    alViatico = 0
                                Else
                                    alViatico = dr4("Viatico")
                                End If
                                If IsDBNull(dr4("traslado")) Or dr4("traslado") <= 0 Then
                                    alTraslado = 0
                                Else
                                    alTraslado = dr4("traslado")
                                End If
                                alCodRegion = dtTemporal.Rows(0).Item(9)


                            ElseIf Not mobjSql.s_existe_persona_natural(dr4("rut_num_pers_nat"), dr4("rut_num_pers_jur")) _
                                    And (IsDBNull(dr4("porc_franq")) Or dr4("porc_franq") = 0) _
                                    And (IsDBNull(dr4("id_niv_ocu")) Or dr4("id_niv_ocu") = 0) _
                                    And (IsDBNull(dr4("id_region")) Or dr4("id_region") = 0) _
                                    And (IsDBNull(dr4("id_escolaridad")) Or dr4("id_region") = 0) Then
                                blnEsDesconocido = True
                                num_alumnos = num_alumnos - 1
                            Else
                                Dim dt5 As New DataTable
                                dt5 = mobjCsqlMDB.s_carga_mdb_6(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat")))
                                If mobjCsqlMDB.Registros > 0 Then
                                    Dim dr5 As DataRow
                                    For Each dr5 In dt5.Rows
                                        alApPaterno = IIf(IsDBNull(dr5("ape_1_pers_nat")), "", dr5("ape_1_pers_nat"))
                                        alApMaterno = IIf(IsDBNull(dr5("ape_2_pers_nat")), "", dr5("ape_2_pers_nat"))
                                        alNombres = IIf(IsDBNull(dr5("nombre_pers_nat")), "", dr5("nombre_pers_nat"))
                                        alFechaNac = FechaVbAUsr(IIf(IsDBNull(dr5("fec_nac_pers_nat")), CDate(FechaMinSistema()), dr5("fec_nac_pers_nat")))
                                        If UCase(Trim(IIf(IsDBNull(dr5("sexo")), "", dr5("sexo")))) <> "M" _
                                                    And UCase(Trim(IIf(IsDBNull(dr5("sexo")), "", dr5("sexo")))) <> "F" Then
                                            '*********************************************************************
                                            '************************** AGREGA LOG *******************************
                                            '*********************************************************************
                                            AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                                "El sexo del participante debe ser M ó F. Rut: " _
                                                & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                                Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                            mobjSql.RollBackTransaccion()
                                            GoTo NuevoRegistro
                                        End If
                                        alSexo = IIf(IsDBNull(dr5("sexo")), "", dr5("sexo"))
                                        If CInt(IIf(IsDBNull(dr5("id_escolaridad")), 0, dr5("id_escolaridad"))) < 1 _
                                                Or CInt(IIf(IsDBNull(dr5("id_escolaridad")), 0, dr5("id_escolaridad"))) > 9 Then
                                            '*********************************************************************
                                            '************************** AGREGA LOG *******************************
                                            '*********************************************************************
                                            AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                                "El id de esolaridad debe ser un numero entre 1 y 9. Rut: " _
                                                & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                                Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                            mobjSql.RollBackTransaccion()
                                            GoTo NuevoRegistro
                                        End If
                                        alCodNivEduc = dr5("id_escolaridad")
                                        If Not mobjSql.s_existe_comuna(CLng(IIf(IsDBNull(dr4("id_comuna")), 0, dr4("id_comuna")))) Then
                                            '*********************************************************************
                                            '************************** AGREGA LOG *******************************
                                            '*********************************************************************
                                            AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                                "El id de la comuna del participante no existe. Rut: " _
                                                & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                                Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                            mobjSql.RollBackTransaccion()
                                            GoTo NuevoRegistro
                                        Else
                                            alCodComuna = CLng(IIf(IsDBNull(dr4("id_comuna")), 0, dr4("id_comuna")))
                                        End If
                                    Next
                                Else
                                    alApPaterno = ""
                                    alApMaterno = ""
                                    alNombres = ""
                                    alFechaNac = "01/01/1970"
                                    alSexo = "M"
                                    alCodNivEduc = 1
                                End If
                                strRutAlumno = RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat")))
                                If CInt(IIf(IsDBNull(dr4("id_niv_ocu")), 0, dr4("id_niv_ocu"))) < 1 _
                                        Or CInt(IIf(IsDBNull(dr4("id_niv_ocu")), 0, dr4("id_niv_ocu"))) > 7 Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                        "El id del nivel ocupacional debe ser entre 1 y 7. Rut: " _
                                        & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                        Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    mobjSql.RollBackTransaccion()
                                    GoTo NuevoRegistro
                                End If
                                alCodNivOcup = CInt(IIf(IsDBNull(dr4("id_niv_ocu")), 0, dr4("id_niv_ocu")))
                                If CInt(IIf(IsDBNull(dr4("porc_franq")), 0, dr4("porc_franq"))) < 0 _
                                        Or CInt(IIf(IsDBNull(dr4("porc_franq")), 0, dr4("porc_franq"))) > 100 Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                        "La franquicia del participante debe ser un número entre 0 y 100. Rut: " _
                                        & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                        Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    mobjSql.RollBackTransaccion()
                                    GoTo NuevoRegistro
                                End If
                                alPorcFranq = IIf(IsDBNull(dr4("porc_franq")), 0, dr4("porc_franq"))
                                If CLng(IIf(IsDBNull(dr4("traslado")), 0, dr4("traslado"))) < 0 _
                                        Or CLng(IIf(IsDBNull(dr4("viatico")), 0, dr4("viatico"))) < 0 Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                        "Acción rechazada. El viático y traslado del participante debe ser mayor que 0. Rut: " _
                                        & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                        Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    mobjSql.RollBackTransaccion()
                                    GoTo NuevoRegistro
                                End If
                                alTraslado = IIf(IsDBNull(dr4("traslado")), 0, dr4("traslado"))
                                alViatico = IIf(IsDBNull(dr4("viatico")), 0, dr4("viatico"))
                                If CInt(IIf(IsDBNull(dr4("id_region")), 0, dr4("id_region"))) < 1 _
                                        Or CInt(IIf(IsDBNull(dr4("id_region")), 0, dr4("id_region"))) > 15 Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                        "El código de la región debe ser un número entre 1 y 15. Rut: " _
                                        & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                        Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                                    mobjSql.RollBackTransaccion()
                                    GoTo NuevoRegistro
                                End If
                                alCodRegion = IIf(IsDBNull(dr4("id_region")), 0, dr4("id_region"))
                            End If
                            RutEmp = objCurso.RutCliente
                            If Not blnEsDesconocido Then
                                Dim objAlumno As New CAlumno
                                'If Alumnos.Item(i) Is Nothing Then
                                objAlumno.Inicializar0(mobjSql)
                                'End If
                                objAlumno.Modificar(strRutAlumno, alApPaterno, alApMaterno, alNombres, alFechaNac, alSexo, _
                                 alPorcFranq, alCodNivOcup, alCodNivEduc, alCodRegion, alViatico, alTraslado, alCodComuna, "", 1, "", "") '1 codigo pais chile
                                i = i + 1
                                Alumnos.Add(objAlumno)
                            End If
                        Next
                        objCurso.Alumnos = Alumnos
                        objCurso.GrabarAlumnos()
                    Else
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                "El curso no tiene alumnos ingresados." _
                                & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        mobjSql.RollBackTransaccion()
                        GoTo NuevoRegistro
                    End If
                    objCurso.CalcularCostos()
                    objCurso.CalcCostoAdm()
                    objCurso.ObtenerInfoCuentas()

                    objCurso.MontoCtaCap = objCurso.CostoOtic
                    objCurso.MontoCtaExcCap = 0
                    objCurso.TotMontoTerc = 0
                    If (1 - objCurso.AdmNoLineal * objCurso.PorcAdm) <> 0 Then
                        objCurso.CostoAdm = objCurso.CostoOtic * objCurso.PorcAdm / (1 - objCurso.AdmNoLineal * objCurso.PorcAdm)
                    End If
                    'objcurso.CostoAdm =
                    objCurso.MontoCtaBecas = 0
                    objCurso.MontoCtaCapVYT = objCurso.TotalViatico + objCurso.TotalTraslado
                    objCurso.MontoCtaExcCapVYT = 0
                    If (1 - objCurso.AdmNoLineal * objCurso.PorcAdm) <> 0 Then
                        objCurso.MontoCtaAdmVYT = (objCurso.TotalViatico + objCurso.TotalTraslado) * objCurso.PorcAdm / (1 - objCurso.AdmNoLineal * objCurso.PorcAdm)
                    End If
                    'objcurso.MontoCtaAdmVYT=0
                    If Not objCurso.GrabarInfoCuentas() Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                "El curso no tiene alumnos ingresados." _
                                & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        mobjSql.RollBackTransaccion()
                        GoTo NuevoRegistro
                    End If
                    'si hizo todo bien
                    mobjSql.FinTransaccion()
                    '*********************************************************************
                    '************************** AGREGA LOG *******************************
                    '*********************************************************************
                    AgregaLog(4, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), CStr(objCurso.Correlativo), _
                            "El curso ha sido ingresado correctamente.", _
                            Trim(dr1("cod_sence")), Trim(objCurso.CostoOtic + objCurso.GastoEmpresa), _
                            Trim(objCurso.CostoOtic + objCurso.GastoEmpresa), Trim(objCurso.CostoOtic), "AP")
                    GoTo NuevoRegistro
NuevoRegistro:
                Next
            Else
                '*********************************************************************
                '************************** AGREGA LOG *******************************
                '*********************************************************************
                AgregaLog(2, "", "", _
                        "No hay cursos que cargar en la base de datos ingresada.", _
                        "", 0, 0, 0, "")
            End If
            If mbolRestringirCursoEmpresa Then
                enviarCorreo()
            End If
            If Not mdtLog Is Nothing Then
                Me.mlngFilas = mdtLog.Rows.Count
                Dim strNombreArchivo As String
                mblnBajarXml = True
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    mdtLog.TableName = "Reporte logs de carga"
                    ConvierteDTaCSV(mdtLog, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
            End If
        Catch ex As Exception
            AgregaLog(1, "", "", _
                     "Hubo problema inesperado en el proceso de carga de cursos, es posible que algunos cursos no hayan sido cargados.", _
                     "", 0, 0, 0, "RE")
            mobjSql.RollBackTransaccion()
        End Try
    End Function
    'valida las horas de inicio y fin. 
    'Retorna:
    '-1 si hora1 < hora2, 
    '0 si son iguales y
    '1 si es mayor hora 1. 
    'Valida que el formato de las horas sean los correctos
    Private Function ValidaHoras(ByVal strHora1, ByVal strHora2) As Integer
        Dim arrHora1, arrHora2

        If Trim(strHora1) = Trim(strHora2) Then
            ValidaHoras = 0
            Exit Function
        End If
        arrHora1 = Split(strHora1, ":")
        arrHora2 = Split(strHora2, ":")
        If TamanoArreglo1(arrHora1) <> 2 Or TamanoArreglo1(arrHora2) <> 2 Then
            ValidaHoras = -2
            Exit Function
        End If
        If CInt(arrHora1(0)) < 0 Or CInt(arrHora1(1)) < 0 Or CInt(arrHora2(0)) < 0 Or CInt(arrHora2(1)) < 0 _
            Or CInt(arrHora1(0)) > 23 Or CInt(arrHora1(1)) > 59 Or CInt(arrHora2(0)) > 23 Or CInt(arrHora2(1)) > 59 Then
            ValidaHoras = -3
            Exit Function
        End If
        If (CInt(arrHora1(0)) > CInt(arrHora2(0))) Or (CInt(arrHora1(0)) = CInt(arrHora2(0)) And CInt(arrHora1(1)) > CInt(arrHora2(1))) Then
            ValidaHoras = -1
            Exit Function
        End If
        ValidaHoras = 1
    End Function

    Public Sub AgregaLog(ByVal Tipo As Integer, ByVal IdEmpresa As String, ByVal IdNuevo As String, _
                        ByVal Descripcion As String, ByVal CodSence As String, ByVal ValorTotal As Long, _
                        ByVal ValorCurso As Long, ByVal CostoOtic As Long, ByVal Estado As String)
        Dim dr As DataRow
        dr = mdtLog.NewRow
        dr("Tipo") = Tipo
        dr("IdEmpresa") = IdEmpresa
        dr("IdNuevo") = IdNuevo
        dr("Descripcion") = Descripcion
        dr("CodSence") = CodSence
        dr("ValorTotal") = ValorTotal
        dr("ValorCurso") = ValorCurso
        dr("CostoOtic") = CostoOtic
        dr("Estado") = Estado
        mdtLog.Rows.Add(dr)
    End Sub
    Public Sub enviarCorreo()
        Try
            Dim objEmail As New CEnviarCorreo
            Dim strTextoEmail As String
            Dim intCantLog, intBuenos As Integer, intMalos As Integer
            intCantLog = mdtLog.Rows.Count
            intBuenos = 0
            intMalos = 0
            strTextoEmail = strTextoEmail & vbCr & "DETALLE:" & vbCr & vbCr
            Dim dr As DataRow
            For Each dr In mdtLog.Rows
                strTextoEmail = strTextoEmail & "Correlativo OTIC:" & dr("IdNuevo") & " ; "
                strTextoEmail = strTextoEmail & "Correlativo EMP:" & dr("IdEmpresa") & " ; "
                strTextoEmail = strTextoEmail & "Costo Curso:" & dr("ValorCurso") & " ; "
                If UCase(dr("Estado")) = "AP" Then
                    strTextoEmail = strTextoEmail & "APROBADO" & vbCr
                    intBuenos = intBuenos + 1
                Else
                    strTextoEmail = strTextoEmail & dr("Descripcion") & vbCr
                    intMalos = intMalos + 1
                End If
            Next
            strTextoEmail = strTextoEmail & vbCr & vbCr & "De ellos " & CStr(intBuenos) & " fueron exitosos y " & CStr(intMalos) & " no fueron cargados por errores de los datos contenidos en el archivo." & vbCr
            objEmail.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_MAILAVISOMDB, _
                        CStr(intCantLog) & " curso(s) intento cargar " & Me.mstrNombreUsuario & "(" & RutLngAUsr(Me.mlngRutUsuario) & ") a través de SisOTIC.", _
                        strTextoEmail)
            objEmail = Nothing
        Catch ex As Exception
            EnviaError("CCargaCursos:enviarCorreo-->" & ex.Message)
        End Try
    End Sub

End Class
