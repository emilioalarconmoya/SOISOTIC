Imports Modulos
Imports Clases
Imports System.Data
Imports System.Web

Public Class CCargaCursosMDB
    'objsql
    Private mobjSql As CSql

    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrNombreArchivoResp As String
    Private mlngNumeroTransActual As Long

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

    Private mdtCursoContratado As DataTable
    Private mdtHorario As DataTable
    Private mdtParticipante As DataTable
    Private mdtTransaccion As DataTable
    Private mdtBitacora As DataTable
    Private mdtSolicitudPagoTerceros As DataTable
    Private mdsCarga As DataSet

    Public Function InicializarTablas()
        Try
            mdtCursoContratado = New DataTable
            mdtCursoContratado.TableName = "Curso_Contratado"
            mdtCursoContratado.Columns.Add("cod_curso")
            mdtCursoContratado.Columns.Add("correlativo")
            mdtCursoContratado.Columns.Add("nro_registro")
            mdtCursoContratado.Columns.Add("codigo_sence")
            mdtCursoContratado.Columns.Add("rut_cliente")
            mdtCursoContratado.Columns.Add("cod_tipo_activ")
            mdtCursoContratado.Columns.Add("cod_estado_curso")
            mdtCursoContratado.Columns.Add("agno")
            mdtCursoContratado.Columns.Add("fecha_inicio")
            mdtCursoContratado.Columns.Add("fecha_termino")
            mdtCursoContratado.Columns.Add("valor_mercado")
            mdtCursoContratado.Columns.Add("descuento")
            mdtCursoContratado.Columns.Add("porc_adm")
            mdtCursoContratado.Columns.Add("costo_otic")
            mdtCursoContratado.Columns.Add("costo_adm")
            mdtCursoContratado.Columns.Add("gasto_empresa")
            mdtCursoContratado.Columns.Add("total_viatico")
            mdtCursoContratado.Columns.Add("total_traslado")
            mdtCursoContratado.Columns.Add("direccion_curso")
            mdtCursoContratado.Columns.Add("cod_comuna")
            mdtCursoContratado.Columns.Add("obs_curso")
            mdtCursoContratado.Columns.Add("costo_otic_comunicar")
            mdtCursoContratado.Columns.Add("obs_liquidacion")
            mdtCursoContratado.Columns.Add("horas")
            mdtCursoContratado.Columns.Add("horas_compl")
            mdtCursoContratado.Columns.Add("cod_curso_parcial")
            mdtCursoContratado.Columns.Add("ind_acu_com_bip")
            mdtCursoContratado.Columns.Add("ind_det_nece")
            mdtCursoContratado.Columns.Add("nro_factura_otec")
            mdtCursoContratado.Columns.Add("fecha_pago_factura")
            mdtCursoContratado.Columns.Add("cod_origen")
            mdtCursoContratado.Columns.Add("correlativo_empresa")
            mdtCursoContratado.Columns.Add("ind_desc_porc")
            mdtCursoContratado.Columns.Add("num_alumnos")
            mdtCursoContratado.Columns.Add("fecha_ingreso")
            mdtCursoContratado.Columns.Add("fecha_modificacion")
            mdtCursoContratado.Columns.Add("fecha_comunicacion")
            mdtCursoContratado.Columns.Add("fecha_liquidacion")
            mdtCursoContratado.Columns.Add("cod_elearning")
            mdtCursoContratado.Columns.Add("contacto_adicional")
            mdtCursoContratado.Columns.Add("cod_ultimo_estado")
            mdtCursoContratado.Columns.Add("Cod_curso_compl")
            mdtCursoContratado.Columns.Add("costo_otic_vyt")
            mdtCursoContratado.Columns.Add("costo_adm_vyt")
            mdtCursoContratado.Columns.Add("gasto_empresa_vyt")
            mdtCursoContratado.Columns.Add("observacion")
            mdtCursoContratado.Columns.Add("cod_modalidad")
            mdtCursoContratado.Columns.Add("Nro_direccion_curso")
            mdtCursoContratado.Columns.Add("Ciudad")

            mdtHorario = New DataTable
            mdtHorario.TableName = "Horario_Curso"
            mdtHorario.Columns.Add("cod_curso")
            mdtHorario.Columns.Add("dia")
            mdtHorario.Columns.Add("hora_inicio")
            mdtHorario.Columns.Add("hora_fin")

            mdtParticipante = New DataTable
            mdtParticipante.TableName = "Participante"
            mdtParticipante.Columns.Add("cod_curso")
            mdtParticipante.Columns.Add("rut_alumno")
            mdtParticipante.Columns.Add("cod_nivel_ocup")
            mdtParticipante.Columns.Add("cod_region")
            mdtParticipante.Columns.Add("porc_franquicia")
            mdtParticipante.Columns.Add("viatico")
            mdtParticipante.Columns.Add("traslado")
            mdtParticipante.Columns.Add("porc_asistencia")
            mdtParticipante.Columns.Add("observaciones")
            mdtParticipante.Columns.Add("cod_nivel_educ")
            mdtParticipante.Columns.Add("cod_comuna")
            mdtParticipante.Columns.Add("cod_clasificador")

            mdtTransaccion = New DataTable
            mdtTransaccion.TableName = "Transaccion"
            mdtTransaccion.Columns.Add("nro_transaccion")
            mdtTransaccion.Columns.Add("rut_cliente")
            mdtTransaccion.Columns.Add("cod_cuenta")
            mdtTransaccion.Columns.Add("cod_tipo_tran")
            mdtTransaccion.Columns.Add("cod_curso")
            mdtTransaccion.Columns.Add("cod_estado_tran")
            mdtTransaccion.Columns.Add("fecha_hora")
            mdtTransaccion.Columns.Add("monto")
            mdtTransaccion.Columns.Add("descripcion")
            mdtTransaccion.Columns.Add("cod_aporte")
            mdtTransaccion.Columns.Add("cod_traspaso")

            mdtBitacora = New DataTable
            mdtBitacora.TableName = "Bitacora"
            mdtBitacora.Columns.Add("cod_bitacora")
            mdtBitacora.Columns.Add("rut_usuario")
            mdtBitacora.Columns.Add("fecha_hora")
            mdtBitacora.Columns.Add("obs")
            mdtBitacora.Columns.Add("cod_tipo_ref")
            mdtBitacora.Columns.Add("nombre_estado")
            mdtBitacora.Columns.Add("cod_ref")

            mdtSolicitudPagoTerceros = New DataTable
            mdtSolicitudPagoTerceros.TableName = "Solicitud_Pago_Terceros"
            mdtSolicitudPagoTerceros.Columns.Add("cod_solicitud_pago")
            mdtSolicitudPagoTerceros.Columns.Add("cod_curso")
            mdtSolicitudPagoTerceros.Columns.Add("rut_benefactor")
            mdtSolicitudPagoTerceros.Columns.Add("nro_transaccion")
            mdtSolicitudPagoTerceros.Columns.Add("fecha_ingreso")
            mdtSolicitudPagoTerceros.Columns.Add("monto")
            mdtSolicitudPagoTerceros.Columns.Add("cod_estado_solicitud")
            mdtSolicitudPagoTerceros.Columns.Add("monto_adm")

            mdsCarga = New DataSet
        Catch ex As Exception

        End Try
    End Function
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
            Dim codCursoTemporal As Integer = 1
            Me.InicializarTablas()


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
                    If Not objCurso.HorarioCurso Is Nothing Then
                        If objCurso.HorarioCurso.Rows.Count > 0 Then
                            horario = objCurso.HorarioCurso
                        End If
                    End If

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
                            drHorario("CodCurso") = codCursoTemporal
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



                    ''abrir conexion y transaccion
                    'mobjSql.InicioTransaccion()

                    'objCurso.GrabarDatos()
                    GrabarDatos(objCurso, codCursoTemporal)

                    'actualizar la data
                    'CalcHorasCurso(objCurso, codCursoTemporal)
                    'CalcCostoAdm(objCurso, codCursoTemporal)
                    'objCurso.ActualizarDatos(0)        'El parametro 0 indica que no escriba en la bitacora
                    ActualizarDatos(objCurso, codCursoTemporal, 0)

                    num_alumnos = mobjCsqlMDB.s_carga_mdb_2(IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")))
                    If Not num_alumnos > 0 Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************

                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                            "El curso no tiene alumnos ingresados.", _
                            Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
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
                                alPorcFranq = dtTemporal.Rows(0).Item(8) / 100
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
                                    GoTo NuevoRegistro
                                End If
                                alPorcFranq = IIf(IsDBNull(dr4("porc_franq")), 0, dr4("porc_franq") / 100)
                                If CLng(IIf(IsDBNull(dr4("traslado")), 0, dr4("traslado"))) < 0 _
                                        Or CLng(IIf(IsDBNull(dr4("viatico")), 0, dr4("viatico"))) < 0 Then
                                    '*********************************************************************
                                    '************************** AGREGA LOG *******************************
                                    '*********************************************************************
                                    AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                        "Acción rechazada. El viático y traslado del participante debe ser mayor que 0. Rut: " _
                                        & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                        Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
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
                                objAlumno.Modificar(strRutAlumno, alApPaterno, alApMaterno, alNombres, alFechaNac, alSexo, alPorcFranq, _
                                alCodNivOcup, alCodNivEduc, alCodRegion, alViatico, alTraslado, alCodComuna, "", 1, "", "") '1 codigo pais chile
                                i = i + 1
                                Alumnos.Add(objAlumno)
                            End If
                        Next
                        objCurso.Alumnos = Alumnos
                        'objCurso.GrabarAlumnos()
                        GrabarAlumnos(objCurso, codCursoTemporal)
                        ActualizarDatos(objCurso, codCursoTemporal, 0)
                    Else
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                "El curso no tiene alumnos ingresados." _
                                & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    'objCurso, codCursoTemporal
                    'objCurso.CalcularCostos()
                    'objCurso.CalcCostoAdm()
                    'objCurso.ObtenerInfoCuentas()

                    CalcularCostos(objCurso, codCursoTemporal)
                    CalcCostoAdm(objCurso, codCursoTemporal)
                    ObtenerInfoCuentas(objCurso, codCursoTemporal)
                    ActualizarDatos(objCurso, codCursoTemporal, 0)

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
                    'If Not objCurso.GrabarInfoCuentas() Then
                    If Not GrabarInfoCuentas(objCurso, codCursoTemporal) Then
                        '*********************************************************************
                        '************************** AGREGA LOG *******************************
                        '*********************************************************************
                        AgregaLog(3, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), "", _
                                "El curso no tiene alumnos ingresados." _
                                & RutLngAUsr(IIf(IsDBNull(dr4("rut_num_pers_nat")), 0, dr4("rut_num_pers_nat"))), _
                                Trim(dr1("cod_sence")), Trim(dr1("valor_total_curso")), 0, 0, "RE")
                        GoTo NuevoRegistro
                    End If
                    'si hizo todo bien
                    '*********************************************************************
                    '************************** AGREGA LOG *******************************
                    '*********************************************************************
                    AgregaLog(4, IIf(IsDBNull(dr1("id_acc_cap")), 0, dr1("id_acc_cap")), codCursoTemporal, _
                            "El curso ha sido ingresado correctamente.", _
                            Trim(dr1("cod_sence")), Trim(objCurso.CostoOtic + objCurso.GastoEmpresa), _
                            Trim(objCurso.CostoOtic + objCurso.GastoEmpresa), Trim(objCurso.CostoOtic), "AP")
                    codCursoTemporal = codCursoTemporal + 1
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

            mdsCarga.Tables.Add(Me.mdtCursoContratado)
            mdsCarga.Tables.Add(Me.mdtHorario)
            mdsCarga.Tables.Add(Me.mdtParticipante)
            mdsCarga.Tables.Add(Me.mdtBitacora)
            mdsCarga.Tables.Add(Me.mdtTransaccion)
            mdsCarga.Tables.Add(Me.mdtSolicitudPagoTerceros)

            'If mbolRestringirCursoEmpresa Then
            '    enviarCorreo()
            'End If
            CargarDatos(objCurso, codCursoTemporal)

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
            'mobjSql.RollBackTransaccion()
        End Try
    End Function
    Private Sub CargarDatos(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)
        Try
            mobjSql.InicioTransaccion()
            Dim maxCodCurso As Long = mobjSql.Serial("cod_curso", "Curso_Contratado")
            Dim maxCorrelativo As Long = mobjSql.s_correlativo(objCurso.Agno)
            Dim maxCodBitacora As Long = mobjSql.Serial("cod_bitacora", "Bitacora")
            Dim maxCodTrans As Long = mobjSql.Serial("nro_transaccion", "Transaccion")
            Dim maxSolicitud As Long = mobjSql.Serial("cod_solicitud_pago", "Solicitud_Pago_Terceros")
            Dim tabla As DataTable
            For Each tabla In mdsCarga.Tables
                Dim dr As DataRow
                Select Case tabla.TableName
                    Case "Curso_Contratado"
                        For Each dr In tabla.Rows
                            dr("cod_curso") = dr("cod_curso") + maxCodCurso
                            dr("correlativo") = dr("correlativo") + maxCorrelativo - 1
                        Next
                    Case "Horario_Curso"
                        For Each dr In tabla.Rows
                            dr("cod_curso") = dr("cod_curso") + maxCodCurso
                        Next
                    Case "Participante"
                        For Each dr In tabla.Rows
                            dr("cod_curso") = dr("cod_curso") + maxCodCurso
                        Next
                    Case "Transaccion"
                        For Each dr In tabla.Rows
                            dr("nro_transaccion") = dr("nro_transaccion") + maxCodTrans
                            dr("descripcion") = Replace(dr("descripcion"), "-" & dr("cod_curso"), dr("cod_curso") + maxCorrelativo - 1)
                            dr("cod_curso") = dr("cod_curso") + maxCodCurso
                        Next
                    Case "Bitacora"
                        For Each dr In tabla.Rows
                            dr("cod_bitacora") = dr("cod_bitacora") + maxCodBitacora
                            dr("cod_ref") = dr("cod_ref") + maxCodCurso
                        Next
                    Case "Solicitud_Pago_Terceros"
                        For Each dr In tabla.Rows
                            dr("cod_solicitud_pago") = dr("cod_solicitud_pago") + maxSolicitud
                            dr("cod_curso") = dr("cod_curso") + maxCodCurso
                            dr("nro_transaccion") = dr("nro_transaccion") + maxCodTrans
                        Next
                End Select
            Next
            For Each tabla In mdsCarga.Tables
                mobjSql.CargaMasivaSqlBulkCopy(tabla, tabla.TableName)
            Next
            If Not mdtLog Is Nothing Then
                Dim dr As DataRow
                For Each dr In mdtLog.Rows
                    If dr("Estado").ToString.ToUpper = "AP" Then
                        dr("IdNuevo") = dr("IdNuevo") + maxCorrelativo - 1
                    End If
                Next
            End If
            mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
        End Try
    End Sub
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
    Public Sub GrabarDatos(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)


        'Call mobjSql.i_curso_contr(mlngRutCliente, mintCodTipoActiv, _
        '                           mbolIndAcuComBip, mbolIndDetNece, _
        '                           mlngNumAlumnos, mstrDireccionCurso, _
        '                           mlngCodComuna, mstrCodSence, _
        '                           mdtmFechaInicio, mdtmFechaTermino, _
        '                           mlngHorasCompl, mlngValorMercado, _
        '                           mlngDescuento, mlngCorrelativo, _
        '                           mlngNroRegistro, mintCodEstadoCurso, _
        '                           mlngAgno, mdblPorcAdm, _
        '                           mlngCostoOtic, mlngCostoAdm, _
        '                           mlngGastoEmpresa, mlngCostoOticVYT, _
        '                           mlngCostoAdmVYT, mlngGastoEmpresaVYT, _
        '                           mlngTotalViatico, _
        '                           mlngTotalTraslado, mintCodOrigen, _
        '                           mstrObsCurso, mlngValorComunicado, _
        '                           mstrObsLiquidacion, mlngHoras, _
        '                           mintNroFacturaOtec, mdtmFechaPagoFactura, _
        '                           mlngCodCursoCompl, mintIndDescPorc, _
        '                           mstrCorrEmpresa, mlngCodCursoParcial, _
        '                           mstrContactoAdicional, mstrObservacion, mlngCodModalidad, _
        '                           mstrNroDireccionCurso, mstrCiudad)


        CalcHorasCurso(objCurso, CodCursoTemporal)
        CalcCostoAdm(objCurso, CodCursoTemporal)


        Dim drCurso As DataRow
        drCurso = Me.mdtCursoContratado.NewRow
        drCurso("cod_curso") = CodCursoTemporal
        drCurso("correlativo") = CodCursoTemporal
        If objCurso.NroRegistro = -1 Then
            'drCurso("nro_registro") = "null"
        Else
            drCurso("nro_registro") = objCurso.NroRegistro
        End If
        drCurso("codigo_sence") = objCurso.CodSence
        drCurso("rut_cliente") = RutUsrALng(objCurso.RutCliente)
        drCurso("cod_tipo_activ") = objCurso.CodTipoActiv
        drCurso("cod_estado_curso") = objCurso.CodEstadoCurso
        drCurso("agno") = objCurso.Agno
        drCurso("fecha_inicio") = objCurso.FechaInicio
        drCurso("fecha_termino") = objCurso.FechaTermino
        drCurso("valor_mercado") = objCurso.ValorMercado
        drCurso("descuento") = objCurso.Descuento
        drCurso("porc_adm") = objCurso.PorcAdm * 100
        drCurso("costo_otic") = objCurso.CostoOtic
        drCurso("costo_adm") = objCurso.CostoAdm
        drCurso("gasto_empresa") = objCurso.GastoEmpresa
        drCurso("total_viatico") = objCurso.TotalViatico
        drCurso("total_traslado") = objCurso.TotalTraslado
        drCurso("direccion_curso") = objCurso.DireccionCurso
        drCurso("cod_comuna") = objCurso.CodComuna
        drCurso("obs_curso") = objCurso.ObsCurso
        drCurso("costo_otic_comunicar") = objCurso.ValorComunicado
        drCurso("obs_liquidacion") = objCurso.ObsLiquidacion
        drCurso("horas") = objCurso.Horas
        drCurso("horas_compl") = objCurso.HorasCompl
        If objCurso.CodCursoParcial = -1 Then
            'drCurso("cod_curso_parcial") = "null"
        Else
            drCurso("cod_curso_parcial") = objCurso.CodCursoParcial
        End If
        drCurso("ind_acu_com_bip") = BooleanVbAbd(objCurso.IndAcuComBip)
        drCurso("ind_det_nece") = BooleanVbAbd(objCurso.IndDetNece)
        If objCurso.NroFacturaOtec = -1 Then
            'drCurso("nro_factura_otec") = "null"
        Else
            drCurso("nro_factura_otec") = objCurso.NroFacturaOtec
        End If
        If objCurso.FechaPagoFactura = FechaMinSistema() Then
            'drCurso("fecha_pago_factura") = "null"
        Else
            drCurso("fecha_pago_factura") = objCurso.FechaPagoFactura
        End If
        drCurso("cod_origen") = objCurso.CodOrigen
        drCurso("correlativo_empresa") = objCurso.CorrEmpresa
        drCurso("ind_desc_porc") = objCurso.IndDescPorc
        drCurso("num_alumnos") = objCurso.NumAlumnos
        'If Not objCurso.FechaIngreso = "" Then
        drCurso("fecha_ingreso") = Now.Date 'objCurso.FechaIngreso
        'End If
        If Not objCurso.FechaModificacion = FechaMaxSistema() Then
            drCurso("fecha_modificacion") = objCurso.FechaModificacion
        Else
            drCurso("fecha_modificacion") = Now.Date
        End If
        If Not objCurso.FechaComunicacion = "" Then
            If objCurso.FechaComunicacion = FechaMinSistema() Then
                'drCurso("fecha_comunicacion") = "null"
            Else
                drCurso("fecha_comunicacion") = objCurso.FechaComunicacion
            End If
        Else
            'drCurso("fecha_comunicacion") = "null"
        End If
        If Not objCurso.FechaLiquidacion = "" Then
            If objCurso.FechaLiquidacion = FechaMinSistema() Then
                'drCurso("fecha_liquidacion") = "null"
            Else
                drCurso("fecha_liquidacion") = objCurso.FechaLiquidacion
            End If
        Else
            'drCurso("fecha_liquidacion") = "null"
        End If
        
        drCurso("cod_elearning") = objCurso.CodElearning
        drCurso("contacto_adicional") = objCurso.ContactoAdicional
        drCurso("cod_ultimo_estado") = objCurso.CodUltEstadoCurso
        If objCurso.CodCursoCompl = -1 Then
            'drCurso("Cod_curso_compl") = "null"
        Else
            drCurso("Cod_curso_compl") = objCurso.CodCursoCompl
        End If
        drCurso("costo_otic_vyt") = objCurso.CostoOticVYT
        drCurso("costo_adm_vyt") = objCurso.CostoAdmVYT
        drCurso("gasto_empresa_vyt") = objCurso.GastoEmpresaVYT
        drCurso("observacion") = objCurso.Observacion
        If objCurso.CodModalidad = 0 Then
            'drCurso("cod_modalidad") = "null"
        Else
            drCurso("cod_modalidad") = objCurso.CodModalidad
        End If
        drCurso("Nro_direccion_curso") = objCurso.NroDireccionCurso
        drCurso("Ciudad") = objCurso.Ciudad
        mdtCursoContratado.Rows.Add(drCurso)


        'Call mobjSql.i_bitacora(mlngRutUsuario, "Incompleto", _
        '                    "Ingreso del Encabezado del Curso Contratado. Cliente: " & RutLngAUsr(mlngRutCliente), _
        '                    1, mlngCodCurso)
        Dim drBitacora As DataRow
        drBitacora = Me.mdtBitacora.NewRow
        drBitacora("cod_bitacora") = mdtBitacora.Rows.Count + 1
        drBitacora("rut_usuario") = mlngRutUsuario
        drBitacora("fecha_hora") = Now
        drBitacora("obs") = "Ingreso del Encabezado del Curso Contratado. Cliente: " & objCurso.RutCliente
        drBitacora("cod_tipo_ref") = 1
        drBitacora("nombre_estado") = "Incompleto"
        drBitacora("cod_ref") = CodCursoTemporal
        mdtBitacora.Rows.Add(drBitacora)
    End Sub
    Public Sub ObtenerInfoCuentas(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)
        Try
            Dim suma_terc As Long
            Dim dtMontos As New DataTable
            Dim objCliente As New CCliente

            objCliente = New CCliente
            objCliente.Inicializar0(mobjSql, mlngRutUsuario)
            objCliente.Agno = objCurso.Agno
            If objCliente.Inicializar1(objCurso.RutCliente) Then
                objCurso.SaldoCtaCap = objCliente.ObjCuentaCap.SaldoActual
                objCurso.SaldoCtaExcCap = objCliente.ObjCuentaExcCap.SaldoActual
                objCurso.SaldoCtaBecas = objCliente.ObjCuentaBecas.SaldoActual
            End If
            'dtMontos = mobjSql.s_montos_cuentas(CodCursoTemporal)
            Dim dtTmpMontos As New DataTable
            dtTmpMontos.Columns.Add("cod_cuenta")
            dtTmpMontos.Columns.Add("monto")
            dtTmpMontos.Columns.Add("rut_cliente")
            dtTmpMontos.Columns.Add("cod_tipo_tran")
            If Not Me.mdtTransaccion Is Nothing Then
                Dim lngMonto As Long = 0
                Dim drTmp2 As DataRow
                Dim drTmpTrans As DataRow
                Dim codCuenta As Integer = 1
                Dim bolExis As Boolean
                Dim tipoTrans As Integer = 1
                For tipoTrans = 1 To 2
                    For codCuenta = 1 To 11
                        bolExis = False
                        For Each drTmpTrans In Me.mdtTransaccion.Rows
                            If drTmpTrans("cod_curso") = CodCursoTemporal Then
                                If drTmpTrans("cod_cuenta") = codCuenta Then
                                    If drTmpTrans("rut_cliente") = RutUsrALng(objCurso.RutCliente) Then
                                        lngMonto = lngMonto + drTmpTrans("monto")
                                        bolExis = True
                                    End If
                                End If
                            End If
                        Next
                        If bolExis Then
                            drTmp2 = dtTmpMontos.NewRow
                            drTmp2("cod_cuenta") = codCuenta
                            drTmp2("monto") = lngMonto
                            drTmp2("rut_cliente") = RutUsrALng(objCurso.RutCliente)
                            drTmp2("cod_tipo_tran") = tipoTrans
                            dtTmpMontos.Rows.Add(drTmp2)
                        End If
                    Next
                Next
            End If
            dtMontos = dtTmpMontos

            'objCurso.Terceros = mobjSql.s_monto_terceros(CodCursoTemporal)
            Dim dtTmpTerceros As New DataTable
            dtTmpTerceros.Columns.Add("rut_benefactor")
            dtTmpTerceros.Columns.Add("monto")
            dtTmpTerceros.Columns.Add("cod_estado_solicitud")
            dtTmpTerceros.Columns.Add("monto_adm")
            dtTmpTerceros.Columns.Add("monto2")
            dtTmpTerceros.Columns.Add("cta")
            dtTmpTerceros.Columns.Add("cod_curso")

            Dim drTmp As DataRow
            Dim drTmp3 As DataRow
            Dim bolExiste As Boolean = False
            For Each drTmp In mdtSolicitudPagoTerceros.Rows
                If drTmp("cod_curso") = CodCursoTemporal Then
                    Dim drTmp2 As DataRow
                    For Each drTmp2 In mdtTransaccion.Rows
                        If drTmp("cod_curso") = drTmp2("cod_curso") Then
                            If Not IsDBNull(drTmp2("nro_transaccion")) Then
                                If drTmp("nro_transaccion") = drTmp2("nro_transaccion") Then
                                    drTmp3 = dtTmpTerceros.NewRow
                                    drTmp3("rut_benefactor") = drTmp("rut_benefactor")
                                    drTmp3("monto") = drTmp("monto")
                                    drTmp3("cod_estado_solicitud") = drTmp("cod_estado_solicitud")
                                    drTmp3("monto_adm") = drTmp("monto_adm")
                                    If IsDBNull(drTmp2("monto")) Then
                                        drTmp3("monto2") = drTmp("monto")
                                    Else
                                        drTmp3("monto2") = drTmp2("monto")
                                    End If
                                    If IsDBNull(drTmp2("cod_cuenta")) Then
                                        drTmp3("cta") = 0
                                    Else
                                        drTmp3("cta") = drTmp2("cod_cuenta")
                                    End If
                                    drTmp3("cod_curso") = CodCursoTemporal
                                    dtTmpTerceros.Rows.Add(drTmp3)
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            objCurso.Terceros = dtTmpTerceros

            objCurso.AdmNoLineal = mobjSql.s_adm_no_lineal(RutUsrALng(objCurso.RutCliente))

            suma_terc = 0

            objCurso.MontoCtaCap = 0
            objCurso.MontoCtaExcCap = 0
            'mlngCostoAdm = 0
            objCurso.MontoTercTran = 0
            objCurso.MontoCtaBecas = 0
            objCurso.MontoRep = 0
            objCurso.MontoExcRep = 0

            '-------viatico y traslado--------
            objCurso.MontoCtaCapVYT = 0
            objCurso.MontoCtaExcCapVYT = 0
            '---------------------------------
            'leer los valores cargados en las diferentes cuentas
            Dim dr As DataRow
            If Not dtMontos Is Nothing Then
                For Each dr In dtMontos.Rows
                    Select Case CInt(dr.Item(0))
                        Case 1
                            If CInt(dr.Item(3)) = 5 Then 'Viatico y traslado
                                objCurso.MontoCtaCapVYT = dr.Item(1)
                            Else
                                objCurso.MontoCtaCap = dr.Item(1)
                            End If
                        Case 4
                            If CInt(dr.Item(3)) = 5 Then 'Viatico y traslado
                                objCurso.MontoCtaExcCapVYT = dr.Item(1)
                            Else
                                objCurso.MontoCtaExcCap = dr.Item(1)
                            End If
                        Case 3
                            If CLng(dr.Item(1)) = RutUsrALng(objCurso.RutCliente) Then  'adm. del cliente
                                If CInt(dr.Item(3)) = 5 Then 'Viatico y traslado
                                    objCurso.CostoAdmVYT = dr.Item(1)
                                Else
                                    objCurso.CostoAdm = dr.Item(1)
                                End If
                            End If
                        Case 2 'Reparto
                            objCurso.MontoRep = objCurso.MontoRep + CLng(dr.Item(1))
                            objCurso.MontoTercTran = objCurso.MontoTercTran + CLng(dr.Item(1)) 'total terc
                        Case 5 'Exc. Reparto
                            objCurso.MontoExcRep = objCurso.MontoExcRep + CLng(dr.Item(1))
                            objCurso.MontoTercTran = objCurso.MontoTercTran + CLng(dr.Item(1)) 'total terc
                        Case 6
                            objCurso.MontoCtaBecas = CLng(dr.Item(1)) '(**|**)
                    End Select
                Next
            End If
            Dim dr2 As DataRow
            If objCurso.Terceros Is Nothing Then

                objCurso.TotMontoTerc = 0
            Else
                For Each dr2 In objCurso.Terceros.Rows
                    suma_terc = suma_terc + dr2.Item(1)
                    Dim objSolicitud As New CSolicitud
                    objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
                    objSolicitud.Inicializar1(CodCursoTemporal, dr2.Item(0), RutUsrALng(objCurso.RutCliente))
                    objCurso.ColSolicitudes.Add(objSolicitud)
                Next
                objCurso.TotMontoTerc = suma_terc
            End If

            'Guardo un indicador para el tipo de accion que se debe hacer
            'en la BD. 1 para insertar nueva, 2 para actualizar
            Dim dt As New DataTable
            dt.Columns.Add("dato")
            Dim dr1 As DataRow
            If objCurso.MontoCtaCap <> -1 Then
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            If objCurso.MontoCtaExcCap <> -1 Then
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If

            'Guardo el tamano inicial del arreglo de montos cargados a terceros
            If Not objCurso.Terceros Is Nothing Then
                dr1 = dt.NewRow
                dr1("dato") = objCurso.Terceros.Rows.Count
                dt.Rows.Add(dr1)
            Else
                dr1 = dt.NewRow
                dr1("dato") = 0
                dt.Rows.Add(dr1)
            End If



            '--------------Prueba viaticos y traslado -------
            If objCurso.MontoCtaCapVYT <> -1 Then
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            If objCurso.MontoCtaExcCapVYT <> -1 Then
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            If objCurso.CostoAdmVYT <> -1 Then
                dr1 = dt.NewRow
                dr1("dato") = 2
                dt.Rows.Add(dr1)
            Else
                dr1 = dt.NewRow
                dr1("dato") = 1
                dt.Rows.Add(dr1)
            End If
            objCurso.ModifCuentas = dt
        Catch ex As Exception
            EnviaError("CCursoContratado:ObtenerInfoCuentas-->" & ex.Message)
        End Try
    End Sub
    Public Sub CalcHorasCurso(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)
        Try
            '******************************************************************************
            '******************************************************************************
            If CodCursoTemporal > 0 And objCurso.CodCursoParcial <= 0 Then
                objCurso.Horas = objCurso.Curso.DurCursoTeorico + objCurso.Curso.DurCursoPractico
            End If
            '******************************************************************************
            '******************************************************************************
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CalcCostoAdm(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)
        Try
            '******************************************************************************
            '******************************************************************************
            If objCurso.MontoCtaCap < 0 Then
                'si mlngMontoCtaCap = -1,  se requiere para obtener el cargo en la cuenta de capacitación
                Call ObtenerInfoCuentas(objCurso, CodCursoTemporal)
                Exit Sub
            End If

            Dim lngMontoCalculoAdm As Long
            Dim lngMontoCalculoAdmVYT As Long

            lngMontoCalculoAdm = objCurso.MontoCtaCap

            lngMontoCalculoAdmVYT = objCurso.MontoCtaCapVYT

            Dim intAdmNoLineal As Integer
            Dim lngCostoAdm As Double
            Dim lngCostoAdmVYT As Long

            intAdmNoLineal = mobjSql.s_adm_no_lineal(RutUsrALng(objCurso.RutCliente))

            If objCurso.PorcAdm >= 0 And objCurso.PorcAdm <= 1 Then
                If (100 - intAdmNoLineal * (100 * objCurso.PorcAdm)) <> 0 Then
                    Dim tmp As Double
                    'si el lngMontoCalculoAdm se desborda en la multiplicación
                    If lngMontoCalculoAdm > 9999999 Then
                        '' ''lngCostoAdm = Math.Round(CDbl(Mult2(lngMontoCalculoAdm, 100)) * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    Else
                        lngCostoAdm = Math.Round(lngMontoCalculoAdm * 100 * objCurso.PorcAdm / (100 - intAdmNoLineal * (100 * objCurso.PorcAdm)))
                    End If
                Else
                    lngCostoAdm = -1
                End If
                'adm viaticos y traslado
                If (100 - intAdmNoLineal * (100 * objCurso.PorcAdm)) <> 0 Then
                    ' OLD lngCostoAdmVYT = Round(lngMontoCalculoAdmVYT * 100 * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    'si el lngMontoCalculoAdm se desborda en la multiplicación
                    If lngMontoCalculoAdmVYT > 9999999 Then
                        '' ''lngCostoAdmVYT = Math.Round(CDbl(Mult2(lngMontoCalculoAdmVYT, 100)) * mdblPorcAdm / (100 - intAdmNoLineal * (100 * mdblPorcAdm)))
                    Else
                        lngCostoAdmVYT = Math.Round(lngMontoCalculoAdmVYT * 100 * objCurso.PorcAdm / (100 - intAdmNoLineal * (100 * objCurso.PorcAdm)))
                    End If
                Else
                    lngCostoAdmVYT = -1
                End If


            ElseIf objCurso.PorcAdm > 1 And objCurso.PorcAdm <= 100 Then
                If (100 - intAdmNoLineal * objCurso.PorcAdm) <> 0 Then
                    lngCostoAdm = Math.Round(lngMontoCalculoAdm * objCurso.PorcAdm / (100 - intAdmNoLineal * objCurso.PorcAdm))
                Else
                    lngCostoAdm = -1
                End If

                'adm viatico y traslado
                If (100 - intAdmNoLineal * objCurso.PorcAdm) <> 0 Then
                    lngCostoAdmVYT = Math.Round(lngMontoCalculoAdmVYT * objCurso.PorcAdm / (100 - intAdmNoLineal * objCurso.PorcAdm))
                Else
                    lngCostoAdmVYT = -1
                End If
            End If

            objCurso.CostoAdm = lngCostoAdm

            objCurso.CostoAdmVYT = lngCostoAdmVYT
            '******************************************************************************
            '******************************************************************************
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GrabarAlumnos(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)

        Try
            Dim i, tamanoAlumno, tam_arrtemp1, tam_arrtemp2 As Integer
            Dim dtTemporal As DataTable
            Dim dig_verif As String
            Dim tipo_pers, strEstadoCurso As String

            tamanoAlumno = objCurso.Alumnos.Count
            objCurso.TotalViatico = 0
            objCurso.TotalTraslado = 0
            'mobjSql = New CSql
            For i = 0 To (tamanoAlumno - 1)
                If Not IsDBNull(objCurso.Alumnos.Item(i + 1)) And Not IsNothing(objCurso.Alumnos.Item(i + 1)) Then
                    dtTemporal = mobjSql.s_persona(RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut))

                    If mobjSql.Registros = 0 Then
                        dig_verif = digito_verificador(RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut))
                        tipo_pers = "N"
                        mobjSql.i_Persona(RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut), dig_verif, tipo_pers)
                    End If

                    dtTemporal = New DataTable
                    dtTemporal = mobjSql.s_pers_nat(RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut))

                    If mobjSql.Registros <> 0 Then
                        Call mobjSql.u_pers_nat(RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut), objCurso.Alumnos.Item(i + 1).ApPaterno, _
                                                objCurso.Alumnos.Item(i + 1).ApMaterno, objCurso.Alumnos.Item(i + 1).Nombres, _
                                                objCurso.Alumnos.Item(i + 1).FechaNacimiento, objCurso.Alumnos.Item(i + 1).Sexo, _
                                                objCurso.Alumnos.Item(i + 1).PorcFranquicia, objCurso.Alumnos.Item(i + 1).CodigoNivelOcup, _
                                                objCurso.Alumnos.Item(i + 1).CodigoNivelEduc, objCurso.Alumnos.Item(i + 1).CodigoRegion, _
                                                RutUsrALng(objCurso.RutCliente), objCurso.Alumnos.Item(i + 1).CodigoComuna, _
                                                      objCurso.Alumnos.Item(i + 1).CodigoPais, objCurso.Alumnos.Item(i + 1).Fono, _
                                                      objCurso.Alumnos.Item(i + 1).Email)
                    Else
                        Call mobjSql.i_PersonaNatural(RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut), objCurso.Alumnos.Item(i + 1).ApPaterno, _
                                                      objCurso.Alumnos.Item(i + 1).ApMaterno, objCurso.Alumnos.Item(i + 1).Nombres, _
                                                      objCurso.Alumnos.Item(i + 1).FechaNacimiento, objCurso.Alumnos.Item(i + 1).Sexo, _
                                                      objCurso.Alumnos.Item(i + 1).PorcFranquicia, objCurso.Alumnos.Item(i + 1).CodigoNivelOcup, _
                                                      objCurso.Alumnos.Item(i + 1).CodigoNivelEduc, objCurso.Alumnos.Item(i + 1).CodigoRegion, _
                                                      RutUsrALng(objCurso.RutCliente), objCurso.Alumnos.Item(i + 1).CodigoComuna, _
                                                      objCurso.Alumnos.Item(i + 1).CodigoPais, objCurso.Alumnos.Item(i + 1).Fono, _
                                                      objCurso.Alumnos.Item(i + 1).Email)
                    End If

                    'dtTemporal = New DataTable
                    'dtTemporal = mobjSql.s_partic_curso(CodCursoTemporal, RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut))

                    'If mobjSql.Registros <> 0 Then
                    '    Call mobjSql.u_participante(CodCursoTemporal, RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut), _
                    '                                 objCurso.Alumnos.Item(i + 1).CodigoNivelOcup, objCurso.Alumnos.Item(i + 1).CodigoRegion, _
                    '                                 objCurso.Alumnos.Item(i + 1).PorcFranquicia, objCurso.Alumnos.Item(i + 1).Viatico, _
                    '                                 objCurso.Alumnos.Item(i + 1).Traslado, objCurso.Alumnos.Item(i + 1).PorcAsistencia, _
                    '                                  objCurso.Alumnos.Item(i + 1).Observaciones, objCurso.Alumnos.Item(i + 1).CodigoNivelEduc, objCurso.Alumnos.Item(i + 1).CodigoComuna, objCurso.Alumnos.Item(i + 1).CodigoClasificador)
                    'Else
                    '    Call mobjSql.i_participante(CodCursoTemporal, RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut), _
                    '                                objCurso.Alumnos.Item(i + 1).CodigoNivelOcup, objCurso.Alumnos.Item(i + 1).CodigoRegion, _
                    '                                objCurso.Alumnos.Item(i + 1).PorcFranquicia, objCurso.Alumnos.Item(i + 1).Viatico, _
                    '                                objCurso.Alumnos.Item(i + 1).Traslado, objCurso.Alumnos.Item(i + 1).PorcAsistencia, _
                    '                                objCurso.Alumnos.Item(i + 1).Observaciones, objCurso.Alumnos.Item(i + 1).CodigoNivelEduc, objCurso.Alumnos.Item(i + 1).CodigoComuna, objCurso.Alumnos.Item(i + 1).CodigoClasificador)
                    'End If

                    Dim dr As DataRow
                    dr = mdtParticipante.NewRow
                    dr("cod_curso") = CodCursoTemporal
                    dr("rut_alumno") = RutUsrALng(objCurso.Alumnos.Item(i + 1).Rut)
                    dr("cod_nivel_ocup") = objCurso.Alumnos.Item(i + 1).CodigoNivelOcup
                    dr("cod_region") = objCurso.Alumnos.Item(i + 1).CodigoRegion
                    dr("porc_franquicia") = objCurso.Alumnos.Item(i + 1).PorcFranquicia / 100
                    dr("viatico") = objCurso.Alumnos.Item(i + 1).Viatico
                    dr("traslado") = objCurso.Alumnos.Item(i + 1).Traslado
                    dr("porc_asistencia") = objCurso.Alumnos.Item(i + 1).PorcAsistencia
                    If IsDBNull(objCurso.Alumnos.Item(i + 1).Observaciones) Or objCurso.Alumnos.Item(i + 1).Observaciones Is Nothing Then
                        dr("observaciones") = ""
                    Else
                        dr("observaciones") = objCurso.Alumnos.Item(i + 1).Observaciones
                    End If

                    dr("cod_nivel_educ") = objCurso.Alumnos.Item(i + 1).CodigoNivelEduc
                    dr("cod_comuna") = objCurso.Alumnos.Item(i + 1).CodigoComuna
                    dr("cod_clasificador") = objCurso.Alumnos.Item(i + 1).CodigoClasificador
                    mdtParticipante.Rows.Add(dr)


                    objCurso.TotalViatico = objCurso.TotalViatico + objCurso.Alumnos.Item(i + 1).Viatico
                    objCurso.TotalTraslado = objCurso.TotalTraslado + objCurso.Alumnos.Item(i + 1).Traslado
                End If
            Next

            If objCurso.CodEstadoCurso = 0 Then
                strEstadoCurso = "Incompleto"
            ElseIf objCurso.CodEstadoCurso = 1 Then
                strEstadoCurso = "Ingresado"
                'ElseIf objCurso.CodEstadoCurso = 2 Then
                '    strEstadoCurso = "Rechazado"
                'ElseIf objCurso.CodEstadoCurso = 3 Then
                '    strEstadoCurso = "Autorizado"
                'ElseIf objCurso.CodEstadoCurso = 4 Then
                '    strEstadoCurso = "Comunicado"
                'ElseIf objCurso.CodEstadoCurso = 5 Then
                '    strEstadoCurso = "Liquidado"
            ElseIf objCurso.CodEstadoCurso = 6 Then
                strEstadoCurso = "Pago por Autorizar"
                'ElseIf objCurso.CodEstadoCurso = 7 Then
                '    strEstadoCurso = "En Comunicacion"
                'ElseIf objCurso.CodEstadoCurso = 8 Then
                '    strEstadoCurso = "Eliminado"
                'ElseIf objCurso.CodEstadoCurso = 9 Then
                '    strEstadoCurso = "En Liquidacion"
                'ElseIf objCurso.CodEstadoCurso = 10 Then
                '    strEstadoCurso = "Anulado"
            End If

            'Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, _
            '                    "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
            '                    & objCurso.RutCliente & ".", _
            '                    1, CodCursoTemporal)
            Dim drBitacora As DataRow
            drBitacora = Me.mdtBitacora.NewRow
            drBitacora("cod_bitacora") = mdtBitacora.Rows.Count + 1
            drBitacora("rut_usuario") = mlngRutUsuario
            drBitacora("fecha_hora") = Now
            drBitacora("obs") = "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " & objCurso.RutCliente & "."
            drBitacora("cod_tipo_ref") = 1
            drBitacora("nombre_estado") = strEstadoCurso
            drBitacora("cod_ref") = CodCursoTemporal
            mdtBitacora.Rows.Add(drBitacora)

        Catch ex As Exception
            EnviaError("CCursoContratado:GrabarAlumnos-->" & ex.Message)
        End Try
    End Sub
    'procedimiento para calcular el costo otic, empresa,
    'y totales de viáticos y traslados
    Public Sub CalcularCostos(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)
        Try
            Dim dblValHoraSence As Double
            'Dim lngValHoraSence As Long
            Dim dblTempCostoOtic As Double, dblTempGastoEmpresa As Double
            Dim dblTempCostoOticVYT As Double, dblTempGastoEmpresaVYT As Double

            'chequear si están cargados los alumnos en el arreglo de objetos
            If objCurso.Alumnos.Count = 0 Then
                'ObtenerAlumnos()


            End If


            'mlngNumAlumnos = mcolAlumnos.Count


            'actualizar el valor de viáticos y traslados
            'Call CalcTotViaticoTrasl()

            'valor de la hora sence
            'lngValHoraSence = mobjSql.s_val_hora_sence_agno(objCurso.Agno)
            dblTempCostoOtic = 0
            dblTempGastoEmpresa = 0

            'costos por Viatico y traslado
            dblTempCostoOticVYT = 0
            dblTempGastoEmpresaVYT = 0

            Dim lngNumAlumnos As Integer
            lngNumAlumnos = objCurso.Alumnos.Count

            'en el cálculo de costos por alumno
            Dim i As Integer
            For i = 0 To (lngNumAlumnos - 1)
                If Not IsDBNull(objCurso.Alumnos.Item(i + 1)) And Not IsNothing(objCurso.Alumnos.Item(i + 1)) Then
                    dblValHoraSence = mobjSql.s_val_hora_curso(objCurso.CodCurso)
                    Call objCurso.Alumnos.Item(i + 1).CalcularCostosAl(objCurso.Horas, dblValHoraSence, _
                            objCurso.IndAcuComBip, objCurso.HorasCompl, objCurso.ValorMercado, _
                            objCurso.IndDescPorc, objCurso.Descuento, lngNumAlumnos, objCurso.CodEstadoCurso)

                    dblTempCostoOtic = dblTempCostoOtic + objCurso.Alumnos.Item(i + 1).CostoOticAlumno
                    dblTempGastoEmpresa = dblTempGastoEmpresa + objCurso.Alumnos.Item(i + 1).GastoEmpresaAlumno

                    dblTempCostoOticVYT = dblTempCostoOticVYT + objCurso.Alumnos.Item(i + 1).CostoOticAlumnoVYT
                    dblTempGastoEmpresaVYT = dblTempGastoEmpresaVYT + objCurso.Alumnos.Item(i + 1).GastoEmpresaAlumnoVYT
                End If
            Next


            objCurso.CostoOtic = Math.Round(dblTempCostoOtic)
            objCurso.GastoEmpresa = Math.Round(dblTempGastoEmpresa)

            objCurso.CostoOticVYT = dblTempCostoOticVYT
            objCurso.GastoEmpresaVYT = dblTempGastoEmpresaVYT
        Catch ex As Exception
            EnviaError("CCursoContratado:CalcularCostos-->" & ex.Message)
        End Try
    End Sub
    'Public Function ObtenerAlumnos(Optional ByVal dblRutAlumno As Double = 0) As Collection
    '    Try
    '        Dim i, intTamArrAls, intTamArrRuts As Integer
    '        Dim r_inic As Boolean
    '        Dim dtTemporal As New DataTable
    '        Dim dtRutAlumnos As New DataTable
    '        dtRutAlumnos = mobjSql.s_rut_partic(mlngCodCurso, dblRutAlumno)
    '        If mobjSql.Registros > 0 Then
    '            mcolAlumnos = New Collection
    '            Dim dr As DataRow
    '            For Each dr In dtRutAlumnos.Rows
    '                Dim objCalumno As New CAlumno
    '                Dim strRut As String
    '                objCalumno.Inicializar0(mobjSql)
    '                objCalumno.CodCursoInscrito = mlngCodCurso
    '                objCalumno.RutEmpresa = RutLngAUsr(mlngRutCliente)
    '                objCalumno.PorcAsistencia = 0
    '                strRut = RutLngAUsr(dr.Item(0))
    '                objCalumno.Inicializar(strRut)
    '                mcolAlumnos.Add(objCalumno)
    '            Next
    '        End If
    '        ObtenerAlumnos = mcolAlumnos
    '    Catch ex As Exception
    '        EnviaError("CCursoContratado:ObtenerAlumnos-->" & ex.Message)
    '    End Try
    'End Function



    'procedimiento para guardar la información de cuentas de cursos
    Public Function GrabarInfoCuentas(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long) As Boolean
        Try
            Dim blnGrabarExitoso, blnBorraTr, blnBorraTr2, blnEsCliente, blnInsTransaccion As Boolean
            Dim i, j, tam_arr_terc, tam_arr_modif, tam_arr_mon As Integer
            Dim cod_cuenta, tipo_trans, estado_trans As Integer
            Dim intContSol As Integer
            Dim serial_trans, serial_trans2, lngMaxCorrelativo, lngCorrTemp As Long
            Dim lngMontoCtaCap As Long, lngMontoCtaExCap As Long, lngMontoCtaAdm As Long, lngMontoCtaBecas As Long
            Dim lngMontoCtaCapVYT As Long, lngMontoCtaExcCapVYT As Long, lngMontoCtaAdmVYT As Long
            Dim dtMontos As New DataTable
            Dim IntContTemp As Integer
            Dim objSolTemp As CSolicitud
            Dim dtTemp1 As DataTable
            Dim dtTercTemp As DataTable   ' arreglo de solicitudes a terceros antes de grabar
            'inicialización de variables
            lngMontoCtaCap = 0
            lngMontoCtaExCap = 0
            lngMontoCtaAdm = 0
            lngMontoCtaBecas = 0 '(**|**)
            lngMontoCtaCapVYT = 0
            lngMontoCtaExcCapVYT = 0
            lngMontoCtaAdmVYT = 0
            If objCurso.Terceros Is Nothing Then
                tam_arr_terc = 0
            Else
                tam_arr_terc = objCurso.Terceros.Rows.Count
            End If
            tam_arr_modif = objCurso.ColSolicitudes.Count
            intContSol = objCurso.ColSolicitudes.Count
            IntContTemp = 0
            If Not objCurso.Terceros Is Nothing Then
                If objCurso.Terceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In objCurso.Terceros.Rows
                        If drTerceros.Item(1) <> 0 Then
                            IntContTemp = IntContTemp + 1
                        End If
                    Next
                End If
            End If
            IntContTemp = 0
            Dim objCliente As CCliente
            Dim objCtaRep As CCuenta, objCtaExcRep As CCuenta
            If Not objCurso.Terceros Is Nothing Then
                If objCurso.Terceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In objCurso.Terceros.Rows
                        If drTerceros.Item(0) > 0 Then
                            objCliente = New CCliente
                            Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                            blnEsCliente = objCliente.EsCliente(drTerceros.Item(0))
                            objCliente = Nothing
                            If Not blnEsCliente Then
                                GrabarInfoCuentas = False
                                Exit Function
                            End If
                        End If
                    Next
                End If
            End If
            Dim objDicCtaRepNuevo As Object
            Dim objDicCtaRepAntiguo As Object
            Dim objDicEstadoTran As Object
            Dim objDicCtaExcRepAntiguo As Object
            Dim objDicAdmNuevo As Object
            Dim objDicAdmAntiguo As Object
            Dim objDicCodSol As Object
            objDicCtaRepNuevo = CreateObject("Scripting.Dictionary")
            objDicCtaRepAntiguo = CreateObject("Scripting.Dictionary")
            objDicEstadoTran = CreateObject("Scripting.Dictionary")
            objDicCtaExcRepAntiguo = CreateObject("Scripting.Dictionary")
            objDicAdmNuevo = CreateObject("Scripting.Dictionary")
            objDicAdmAntiguo = CreateObject("Scripting.Dictionary")
            Dim dtCuentas As New DataTable
            dtCuentas.Columns.Add("rut")
            dtCuentas.Columns.Add("CtaRepNuevo")
            dtCuentas.Columns.Add("CtaRepAntiguo")
            dtCuentas.Columns.Add("EstadoTran")
            dtCuentas.Columns.Add("CtaExcRepAntiguo")
            dtCuentas.Columns.Add("AdmNuevo")
            dtCuentas.Columns.Add("AdmAntiguo")
            dtCuentas.Columns.Add("CodSol")
            Dim drCuentas As DataRow
            If Not objCurso.Terceros Is Nothing Then
                If objCurso.Terceros.Rows.Count > 0 Then
                    Dim drTerceros As DataRow
                    For Each drTerceros In objCurso.Terceros.Rows
                        If drTerceros.Item(0) > 0 Then
                            drCuentas = dtCuentas.NewRow
                            drCuentas("rut") = CLng(drTerceros.Item(0))
                            drCuentas("CtaRepNuevo") = CLng(drTerceros.Item(1))
                            drCuentas("CtaRepAntiguo") = 0
                            drCuentas("EstadoTran") = 3
                            drCuentas("CtaExcRepAntiguo") = 0
                            drCuentas("AdmNuevo") = 0
                            drCuentas("AdmAntiguo") = 0
                            drCuentas("CodSol") = 0
                            dtCuentas.Rows.Add(drCuentas)
                        End If
                    Next
                End If
            End If
            'genera correlativo del curso, si no tiene ninguno asignado
            lngCorrTemp = objCurso.Correlativo
            If objCurso.Correlativo <= 0 Then
                If objCurso.GenerarNuevoCorr Then
                    lngMaxCorrelativo = mobjSql.s_max_correlativo(objCurso.Agno)
                    If lngMaxCorrelativo >= 0 Then
                        objCurso.Correlativo = lngMaxCorrelativo + 1
                    Else
                        objCurso.Correlativo = 1
                    End If
                Else
                    objCurso.Correlativo = objCurso.CorrElearning
                End If
            End If
            'consulta los montos por (cuenta, rut cliente) asociados al curso en la base de datos 
            dtMontos = mobjSql.s_num_rut_cta_est_tran(CodCursoTemporal)
            If dtMontos Is Nothing Then
                tam_arr_mon = 0
            Else
                tam_arr_mon = dtMontos.Rows.Count
            End If
            Dim intCodCuenta As Integer, lngRutEmpresaTran As Long
            Dim lngMonto As Long, intCodEstadoTran As Integer, intCodTipoTran As Integer
            Dim intCodEstadoTranPropias As Integer
            Dim intCodEstadoTranVYT As Integer
            intCodEstadoTranVYT = 1
            If objCurso.ModificarMontoSolicitudes = True Then
                intCodEstadoTranPropias = 2
            Else
                intCodEstadoTranPropias = 1
            End If
            If Not dtMontos Is Nothing Then
                If dtMontos.Rows.Count > 0 Then
                    Dim drMontos As DataRow
                    Dim drCuenta As DataRow
                    For Each drMontos In dtMontos.Rows
                        intCodCuenta = CInt(drMontos.Item(2))
                        lngRutEmpresaTran = drMontos.Item(1)
                        lngMonto = drMontos.Item(4)
                        intCodEstadoTran = drMontos.Item(3)
                        intCodTipoTran = drMontos.Item(5)
                        Select Case intCodCuenta
                            Case 1 'cta cap
                                If intCodTipoTran = 5 Then 'Viatico y traslado
                                    lngMontoCtaCapVYT = lngMonto
                                    intCodEstadoTranVYT = intCodEstadoTran
                                ElseIf intCodTipoTran = 2 Then
                                    lngMontoCtaCap = lngMonto
                                    intCodEstadoTranPropias = intCodEstadoTran
                                End If

                            Case 2 'ctas de rep
                                drCuenta = dtCuentas.NewRow
                                drCuenta("rut") = lngRutEmpresaTran
                                drCuenta("CtaRepNuevo") = 0
                                drCuenta("CtaRepAntiguo") = lngMonto
                                drCuenta("EstadoTran") = intCodEstadoTran
                                drCuenta("CtaExcRepAntiguo") = 0
                                drCuenta("AdmNuevo") = 0
                                drCuenta("AdmAntiguo") = 0
                                drCuenta("CodSol") = 0
                                dtCuentas.Rows.Add(drCuenta)
                            Case 3 'administración
                                If lngRutEmpresaTran = RutUsrALng(objCurso.RutCliente) Then
                                    If intCodTipoTran = 5 Then 'Viatico y traslado
                                        lngMontoCtaAdmVYT = lngMonto
                                        intCodEstadoTranVYT = intCodEstadoTran
                                    ElseIf intCodTipoTran = 2 Then
                                        lngMontoCtaAdm = lngMonto  'valor actual de admin
                                    End If
                                Else    'reparto de un tercero
                                    drCuenta = dtCuentas.NewRow
                                    drCuenta("rut") = lngRutEmpresaTran
                                    drCuenta("CtaRepNuevo") = 0
                                    drCuenta("CtaRepAntiguo") = 0
                                    drCuenta("EstadoTran") = 0
                                    drCuenta("CtaExcRepAntiguo") = 0
                                    drCuenta("AdmNuevo") = 0
                                    drCuenta("AdmAntiguo") = lngMonto
                                    drCuenta("CodSol") = 0
                                    dtCuentas.Rows.Add(drCuenta)
                                End If
                            Case 4 'exc. cap
                                If intCodTipoTran = 5 Then 'Viatico y traslado
                                    lngMontoCtaExcCapVYT = lngMonto
                                    intCodEstadoTranVYT = intCodEstadoTran
                                ElseIf intCodTipoTran = 2 Then
                                    lngMontoCtaExCap = lngMonto
                                    intCodEstadoTranPropias = intCodEstadoTran
                                End If
                            Case 5 ' exc. rep
                                drCuenta = dtCuentas.NewRow
                                drCuenta("rut") = lngRutEmpresaTran
                                drCuenta("CtaRepNuevo") = 0
                                drCuenta("CtaRepAntiguo") = 0
                                drCuenta("EstadoTran") = intCodEstadoTran
                                drCuenta("CtaExcRepAntiguo") = lngMonto
                                drCuenta("AdmNuevo") = 0
                                drCuenta("AdmAntiguo") = 0
                                drCuenta("CodSol") = 0
                                dtCuentas.Rows.Add(drCuenta)
                            Case 6
                                lngMontoCtaBecas = lngMonto
                                intCodEstadoTranPropias = intCodEstadoTran
                        End Select
                    Next
                End If
            End If
            Call CalcularCostos(objCurso, CodCursoTemporal)
            Call CalcCostoAdm(objCurso, CodCursoTemporal)
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, RutUsrALng(objCurso.RutCliente), 1, intCodEstadoTranPropias, _
                    2, lngMontoCtaCap, objCurso.MontoCtaCap, lngMontoCtaAdm, objCurso.CostoAdm, objCurso.ModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Exit Function
            End If
            'excedentes de cap
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, RutUsrALng(objCurso.RutCliente), 4, intCodEstadoTranPropias, _
                    2, lngMontoCtaExCap, objCurso.MontoCtaExcCap, 0, 0, objCurso.ModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Exit Function
            End If
            'cuenta beca
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, RutUsrALng(objCurso.RutCliente), 6, intCodEstadoTranPropias, _
                    2, lngMontoCtaBecas, objCurso.MontoCtaBecas, 0, 0, objCurso.ModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Exit Function
            End If
            '-----cuanta cap por viaticos y traslado
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, RutUsrALng(objCurso.RutCliente), 1, intCodEstadoTranVYT, _
                    5, lngMontoCtaCapVYT, objCurso.MontoCtaCapVYT, lngMontoCtaAdmVYT, objCurso.CostoAdmVYT, objCurso.ModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Exit Function
            End If
            '-----excedentes de cap por viatios y traslado
            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, RutUsrALng(objCurso.RutCliente), 4, intCodEstadoTranVYT, _
                    5, lngMontoCtaExcCapVYT, objCurso.MontoCtaExcCapVYT, 0, 0, objCurso.ModificarMontoSolicitudes)
            If Not blnInsTransaccion Then
                GrabarInfoCuentas = False
                Exit Function
            End If
            'actualizar las transacciones y las solicitudes a terceros
            Dim item, lngRutTercero As Long
            Dim lngMontoSolicitudAntigua As Long, lngMontoSolicitudNueva As Long
            Dim dr As DataRow
            If Not dtCuentas Is Nothing Then
                For Each dr In dtCuentas.Rows
                    lngRutTercero = dr("rut") 'item
                    lngMontoSolicitudAntigua = CLng(dr("CtaRepAntiguo")) + CLng(dr("CtaExcRepAntiguo"))
                    lngMontoSolicitudNueva = CLng(dr("CtaRepNuevo"))
                    'si el nuevo monto registrado en la base es diferente a la suma de los solicitados,
                    'anular las transacciones e ingresar nuevas
                    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
                        'cuenta de rep = 2
                        If Not objCurso.ModificarMontoSolicitudes Then
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, lngRutTercero, 2, dr("EstadoTran"), _
                                    2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
                                    dr("AdmAntiguo"), 0, objCurso.ModificarMontoSolicitudes)
                            'anular cuenta de excedente de rep = 5
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, lngRutTercero, 5, dr("EstadoTran"), _
                                    2, dr("CtaExcRepAntiguo"), 0, _
                                    0, 0, objCurso.ModificarMontoSolicitudes)
                        Else
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, lngRutTercero, 2, dr("EstadoTran"), _
                                    2, dr("CtaRepAntiguo"), lngMontoSolicitudNueva, _
                                    dr("DicAdmAntiguo"), 0, objCurso.ModificarMontoSolicitudes)
                            blnInsTransaccion = ModificarTransaccionSiEsNecesario(objCurso, CodCursoTemporal, lngRutTercero, 5, dr("DicEstadoTran"), _
                                    2, dr("CtaExcRepAntiguo"), lngMontoSolicitudNueva, _
                                    0, 0, objCurso.ModificarMontoSolicitudes)
                        End If
                    End If
                    'buscar el rut entre las solicitudes existentes
                    Dim blnSolicitudEncontrada As Boolean
                    blnSolicitudEncontrada = False
                    For i = 0 To intContSol - 1
                        If objCurso.ColSolicitudes(i + 1).RutBenefactorLng = lngRutTercero Then  'se encontró la solicitud
                            Call objCurso.ColSolicitudes(i + 1).Inicializar1(CodCursoTemporal, lngRutTercero, RutUsrALng(objCurso.RutCliente))
                            If lngMontoSolicitudNueva > 0 Then
                                If Not objCurso.ModificarMontoSolicitudes Then
                                    objCurso.ColSolicitudes(i + 1).MontoCtaReparto = lngMontoSolicitudNueva
                                    objCurso.ColSolicitudes(i + 1).NroTransCtaRep = 0
                                    Call objCurso.ColSolicitudes(i).Modificar()
                                    If lngMontoSolicitudAntigua <> lngMontoSolicitudNueva Then
                                        Call objCurso.ColSolicitudes(i + 1I).CambiarEstPendiente()
                                    End If
                                End If
                            Else
                                Call objCurso.ColSolicitudes(i + 1).Borrar()
                                '''EliminarSolicitud(i + 1)
                                intContSol = intContSol - 1
                            End If
                            blnSolicitudEncontrada = True
                            Exit For
                        End If
                    Next
                    If Not blnSolicitudEncontrada And lngMontoSolicitudNueva > 0 Then  'crear solicitud nueva
                        Dim objSolicitud As New CSolicitud
                        Call objSolicitud.Inicializar0(mobjSql, mlngRutUsuario)
                        Call objSolicitud.Inicializar2(RutUsrALng(objCurso.RutCliente), lngRutTercero, CodCursoTemporal, dr("CtaRepNuevo"), 0)
                        Call objSolicitud.Grabar()
                        Dim drSol As DataRow
                        drSol = mdtSolicitudPagoTerceros.NewRow
                        drSol("cod_solicitud_pago") = mdtSolicitudPagoTerceros.Rows.Count + 1
                        drSol("cod_curso") = CodCursoTemporal
                        drSol("rut_benefactor") = objSolicitud.RutBenefactor
                        drSol("nro_transaccion") = mlngNumeroTransActual
                        drSol("fecha_ingreso") = Now.Date
                        drSol("monto") = objSolicitud.MontoCtaReparto
                        drSol("cod_estado_solicitud") = 1
                        drSol("monto_adm") = objSolicitud.MontoCtaAdm
                        mdtSolicitudPagoTerceros.Rows.Add(drSol)
                        intContSol = intContSol + 1
                    End If
                Next
            End If
            blnGrabarExitoso = True
            Dim tam_arr_aux As Integer
            If objCurso.Terceros Is Nothing Then
                objCurso.Terceros = New DataTable
                objCurso.Terceros.Columns.Add("rut_benefactor")
                objCurso.Terceros.Columns.Add("monto")
                objCurso.Terceros.Columns.Add("cod_estado_solicitud")
                objCurso.Terceros.Columns.Add("monto_adm")
                objCurso.Terceros.Columns.Add("monto2")
                objCurso.Terceros.Columns.Add("cta")
                objCurso.Terceros.Columns.Add("cod_curso")
                Dim drTerceros As DataRow
                drTerceros = objCurso.Terceros.NewRow
                drTerceros("rut_benefactor") = -1
                drTerceros("monto") = -1
                drTerceros("cod_estado_solicitud") = -1
                drTerceros("monto_adm") = -1
                drTerceros("monto2") = -1
                drTerceros("cta") = -1
                drTerceros("cod_curso") = -1
                objCurso.Terceros.Rows.Add(drTerceros)
            End If
            If objCurso.Terceros.Rows.Count > 0 Then
                If tam_arr_terc = 1 And objCurso.Terceros.Rows(0)(0) <= 0 Then
                    tam_arr_aux = 0
                Else
                    tam_arr_aux = tam_arr_terc
                End If
            End If
            Dim blnSolPendientes As Boolean
            blnSolPendientes = False
            If objCurso.ColSolicitudes.Count > 0 Then
                For i = 0 To objCurso.ColSolicitudes.Count
                    'Si hay pendientes
                    If objCurso.ColSolicitudes(i + 1).CodEstadoSolicitud = 1 Then
                        blnSolPendientes = True
                        Exit For
                    End If
                Next
            End If
            If objCurso.CodEstadoCurso >= 0 Then
                If objCurso.ModifCuentas.Rows(2).Item(0) = tam_arr_aux And Not blnSolPendientes Then
                    Call CambiarEstIngresado(objCurso, CodCursoTemporal, "")
                ElseIf (objCurso.ModifCuentas.Rows(2).Item(0) < tam_arr_aux) Or blnSolPendientes Then
                    Call CambiarEstPagoPorAut(objCurso, CodCursoTemporal, "")
                End If
            Else
                blnGrabarExitoso = False
            End If
            ActualizarDatos(objCurso, CodCursoTemporal, 0)
            GrabarInfoCuentas = blnGrabarExitoso
        Catch ex As Exception
            'mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:GrabarHorario-->" & ex.Message)
        End Try
    End Function
    'actualiza los datos del encabezado del curso
    'si el parámetro intCasoBitacora es > 0, ingresa un registro en la bitácora
    Public Sub ActualizarDatos(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long, ByVal intCasoBitacora As Integer)
        Try
            Dim strEstadoCurso, strGlosa As String
            Dim blnAuxiliar As Boolean

            If objCurso.CodEstadoCurso = 0 Then
                strEstadoCurso = "Incompleto"
            ElseIf objCurso.CodEstadoCurso = 1 Then
                strEstadoCurso = "Ingresado"
            ElseIf objCurso.CodEstadoCurso = 2 Then
                strEstadoCurso = "Rechazado"
            ElseIf objCurso.CodEstadoCurso = 3 Then
                strEstadoCurso = "Autorizado"
            ElseIf objCurso.CodEstadoCurso = 4 Then
                strEstadoCurso = "Comunicado"
            ElseIf objCurso.CodEstadoCurso = 5 Then
                strEstadoCurso = "Liquidado"
            ElseIf objCurso.CodEstadoCurso = 6 Then
                strEstadoCurso = "Pago por Autorizar"
            ElseIf objCurso.CodEstadoCurso = 7 Then
                strEstadoCurso = "En Comunicacion"
            ElseIf objCurso.CodEstadoCurso = 8 Then
                strEstadoCurso = "Eliminado"
            ElseIf objCurso.CodEstadoCurso = 9 Then
                strEstadoCurso = "En Liquidacion"
            ElseIf objCurso.CodEstadoCurso = 10 Then
                strEstadoCurso = "Anulado"
            ElseIf objCurso.CodEstadoCurso = 11 Then
                strEstadoCurso = "Ingreso/Modif asistencia"
            End If
            'ObtenerAlumnos(objCurso, CodCursoTemporal)
            CalcularCostos(objCurso, CodCursoTemporal)
            CalcCostoAdm(objCurso, CodCursoTemporal)
            'mobjSql.u_curso_contr(mlngRutCliente, mintCodTipoActiv, _
            '                           mbolIndAcuComBip, mbolIndDetNece, _
            '                           mlngNumAlumnos, mstrDireccionCurso, _
            '                           mlngCodComuna, mstrCodSence, _
            '                           mdtmFechaInicio, mdtmFechaTermino, _
            '                           mlngHorasCompl, mlngValorMercado, _
            '                           mlngDescuento, mlngCorrelativo, _
            '                           mlngNroRegistro, mlngAgno, _
            '                           mdblPorcAdm, mlngCostoOtic, _
            '                           mlngCostoAdm, mlngGastoEmpresa, _
            '                           mlngCostoOticVYT, mlngCostoAdmVYT, _
            '                           mlngGastoEmpresaVYT, _
            '                           mlngTotalViatico, mlngTotalTraslado, _
            '                           mintCodOrigen, mstrObsCurso, _
            '                           mlngValorComunicado, mstrObsLiquidacion, _
            '                           mlngHoras, mintNroFacturaOtec, _
            '                           mdtmFechaPagoFactura, mlngCodCursoCompl, _
            '                           mintIndDescPorc, mstrCorrEmpresa, _
            '                           mdtmFechaComunicacion, mdtmFechaLiquidacion, _
            '                           mlngCodCurso, mstrContactoAdicional, mstrObservacion, _
            '                           mlngCodModalidad, _
            '                           mstrNroDireccionCurso, mstrCiudad)

            Dim drCurso As DataRow
            For Each drCurso In Me.mdtCursoContratado.Rows
                If drCurso("cod_curso") = CodCursoTemporal Then
                    drCurso("correlativo") = CodCursoTemporal
                    If objCurso.NroRegistro = -1 Then
                        'drCurso("nro_registro") = "null"
                    Else
                        drCurso("nro_registro") = objCurso.NroRegistro
                    End If
                    drCurso("codigo_sence") = objCurso.CodSence
                    drCurso("rut_cliente") = RutUsrALng(objCurso.RutCliente)
                    drCurso("cod_tipo_activ") = objCurso.CodTipoActiv
                    drCurso("cod_estado_curso") = objCurso.CodEstadoCurso
                    drCurso("agno") = objCurso.Agno
                    drCurso("fecha_inicio") = objCurso.FechaInicio
                    drCurso("fecha_termino") = objCurso.FechaTermino
                    drCurso("valor_mercado") = objCurso.ValorMercado
                    drCurso("descuento") = objCurso.Descuento
                    drCurso("porc_adm") = objCurso.PorcAdm * 100
                    drCurso("costo_otic") = objCurso.CostoOtic
                    drCurso("costo_adm") = objCurso.CostoAdm
                    drCurso("gasto_empresa") = objCurso.GastoEmpresa
                    drCurso("total_viatico") = objCurso.TotalViatico
                    drCurso("total_traslado") = objCurso.TotalTraslado
                    drCurso("direccion_curso") = objCurso.DireccionCurso
                    drCurso("cod_comuna") = objCurso.CodComuna
                    drCurso("obs_curso") = objCurso.ObsCurso
                    drCurso("costo_otic_comunicar") = objCurso.ValorComunicado
                    drCurso("obs_liquidacion") = objCurso.ObsLiquidacion
                    drCurso("horas") = objCurso.Horas
                    drCurso("horas_compl") = objCurso.HorasCompl
                    If objCurso.CodCursoParcial = -1 Then
                        'drCurso("cod_curso_parcial") = "null"
                    Else
                        drCurso("cod_curso_parcial") = objCurso.CodCursoParcial
                    End If
                    drCurso("ind_acu_com_bip") = BooleanVbAbd(objCurso.IndAcuComBip)
                    drCurso("ind_det_nece") = BooleanVbAbd(objCurso.IndDetNece)
                    If objCurso.NroFacturaOtec = -1 Then
                        'drCurso("nro_factura_otec") = "null"
                    Else
                        drCurso("nro_factura_otec") = objCurso.NroFacturaOtec
                    End If
                    If objCurso.FechaPagoFactura = FechaMinSistema() Then
                        'drCurso("fecha_pago_factura") = "null"
                    Else
                        drCurso("fecha_pago_factura") = objCurso.FechaPagoFactura
                    End If
                    drCurso("cod_origen") = objCurso.CodOrigen
                    drCurso("correlativo_empresa") = objCurso.CorrEmpresa
                    drCurso("ind_desc_porc") = objCurso.IndDescPorc
                    drCurso("num_alumnos") = objCurso.Alumnos.Count ' objCurso.NumAlumnos
                    'If Not objCurso.FechaIngreso = "" Then
                    drCurso("fecha_ingreso") = Now.Date 'objCurso.FechaIngreso
                    'End If
                    If Not objCurso.FechaModificacion = FechaMaxSistema() Then
                        drCurso("fecha_modificacion") = objCurso.FechaModificacion
                    Else
                        drCurso("fecha_modificacion") = Now.Date
                    End If
                    If Not objCurso.FechaComunicacion = "" Then
                        If objCurso.FechaComunicacion = FechaMinSistema() Then
                            'drCurso("fecha_comunicacion") = "null"
                        Else
                            drCurso("fecha_comunicacion") = objCurso.FechaComunicacion
                        End If
                    Else
                        'drCurso("fecha_comunicacion") = "null"
                    End If
                    If Not objCurso.FechaLiquidacion = "" Then
                        If objCurso.FechaLiquidacion = FechaMinSistema() Then
                            'drCurso("fecha_liquidacion") = "null"
                        Else
                            drCurso("fecha_liquidacion") = objCurso.FechaLiquidacion
                        End If
                    Else
                        'drCurso("fecha_liquidacion") = "null"
                    End If

                    drCurso("cod_elearning") = objCurso.CodElearning
                    drCurso("contacto_adicional") = objCurso.ContactoAdicional
                    drCurso("cod_ultimo_estado") = objCurso.CodUltEstadoCurso
                    If objCurso.CodCursoCompl = -1 Then
                        'drCurso("Cod_curso_compl") = "null"
                    Else
                        drCurso("Cod_curso_compl") = objCurso.CodCursoCompl
                    End If
                    drCurso("costo_otic_vyt") = objCurso.CostoOticVYT
                    drCurso("costo_adm_vyt") = objCurso.CostoAdmVYT
                    drCurso("gasto_empresa_vyt") = objCurso.GastoEmpresaVYT
                    drCurso("observacion") = objCurso.Observacion
                    If objCurso.CodModalidad = 0 Then
                        'drCurso("cod_modalidad") = "null"
                    Else
                        drCurso("cod_modalidad") = objCurso.CodModalidad
                    End If
                    drCurso("Nro_direccion_curso") = objCurso.NroDireccionCurso
                    drCurso("Ciudad") = objCurso.Ciudad
                End If
            Next

            Select Case intCasoBitacora
                Case 0          'No se escribe en la bitacora
                    strGlosa = ""
                Case 1          'Se actualizan los datos de encabezado del curso
                    strGlosa = "Actualizacion de los datos del Curso Contratado. Cliente: " & objCurso.RutCliente
                Case 2          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de los Alumnos del Curso Contratado. Cliente: " & objCurso.RutCliente
                Case 3          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso/Modif de asistencia. Cliente: " & objCurso.RutCliente
                Case 4          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de Nro de registro por liquidación de Curso Parcial. Cliente: " & objCurso.RutCliente
            End Select
            If intCasoBitacora > 0 Then
                'Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, strGlosa, 1, CodCursoTemporal)
                Dim drBitacora As DataRow
                drBitacora = Me.mdtBitacora.NewRow
                drBitacora("cod_bitacora") = mdtBitacora.Rows.Count + 1
                drBitacora("rut_usuario") = mlngRutUsuario
                drBitacora("fecha_hora") = Now
                drBitacora("obs") = strGlosa
                drBitacora("cod_tipo_ref") = 1
                drBitacora("nombre_estado") = strEstadoCurso
                drBitacora("cod_ref") = CodCursoTemporal
                mdtBitacora.Rows.Add(drBitacora)
            End If
            Call GrabarHorario(objCurso, CodCursoTemporal)
            Exit Sub
        Catch ex As Exception
            EnviaError("cCursoContratado:ActualizarDatos Method-->" & ex.Message)
        End Try
    End Sub
    Public Sub GrabarHorario(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long)
        Try
            Dim i, intTamArr As Integer
            'intTamArr = TamanoArreglo1(mdtHorarioCurso)
            Dim drHorario As DataRow
            'mobjSql.d_horario_curso(CodCursoTemporal)

            'Dim dtTmp As New DataTable
            'dtTmp.TableName = "Horario_Curso"
            'dtTmp.Columns.Add("cod_curso", GetType(Long))
            'dtTmp.Columns.Add("dia", GetType(Integer))
            'dtTmp.Columns.Add("hora_inicio", GetType(String))
            'dtTmp.Columns.Add("hora_fin", GetType(String))
            'Dim drTmpHorario As DataRow
            'Dim drHor As DataRow
            'For Each drHor In mdtHorario.Rows
            '    If Not drHor("cod_curso") = CodCursoTemporal Then
            '        drTmpHorario = dtTmp.NewRow
            '        drTmpHorario("cod_curso") = drHor("cod_curso")
            '        drTmpHorario("dia") = drHor("dia")
            '        drTmpHorario("hora_inicio") = drHor("hora_inicio")
            '        drTmpHorario("hora_fin") = drHor("hora_fin")
            '        dtTmp.Rows.Add(drTmpHorario)
            '    End If
            'Next
            'Dim FoundRows As DataRow()
            'FoundRows = mdtHorario.Select("cod_curso <> " & CodCursoTemporal)
            ''dtTmp.ImportRow(FoundRows)
            'Dim drHor As datarow
            'For Each drhor In FoundRows
            '    dtTmp.ImportRow(drHor)
            'Next
            'mdtHorario = dtTmp
            If Not IsDBNull(objCurso.HorarioCurso) Then
                mdtHorario.Rows.Clear()
                Dim dr As DataRow
                For Each dr In objCurso.HorarioCurso.Rows
                    'dr("CodCurso") = CodCursoTemporal
                    If dr("Dia") > 0 Then
                        '    Call mobjSql.i_horario_curso(CLng(dr("CodCurso")), _
                        '                                 CInt(dr("Dia")), _
                        '                                 CStr(dr("HoraInicio")), _
                        '                                 CStr(dr("HoraFin")))

                        drHorario = mdtHorario.NewRow
                        drHorario("cod_curso") = dr("CodCurso")
                        drHorario("dia") = CInt(dr("Dia"))
                        drHorario("hora_inicio") = CStr(dr("HoraInicio"))
                        drHorario("hora_fin") = CStr(dr("HoraFin"))
                        mdtHorario.Rows.Add(drHorario)

                    End If
                Next
            End If
        Catch ex As Exception
            EnviaError("CCursoContratado:GrabarHorario-->" & ex.Message)
        End Try
    End Sub
    'Procedimiento para modificar el valor de una transacción, si es diferente a la registrada
    'en la base
    'intEstadoTras: 1=pendiente, 2=autorizada, 3=solicitada, 4=anulada
    'Retorna False si se produce algún error
    Private Function ModificarTransaccionSiEsNecesario(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long, _
                ByVal lngRutCliente As Long, ByVal intCodCuenta As Integer, ByVal intEstadoTran As Integer, _
                ByVal intCodTipoTransaccion As Integer, _
                ByVal lngMontoAntiguo As Long, ByVal lngMontoNuevo As Long, _
                ByVal lngMontoAdmAntiguo As Long, ByVal lngMontoAdmNuevo As Long, _
                ByVal blnModMontoSolicitudes As Boolean) As Boolean

        Try
            Dim serial_trans As Long
            Dim blnActSaldoCuenta As Boolean, blnActSaldoAdm As Boolean
            blnActSaldoCuenta = False
            blnActSaldoAdm = False

            'si los montos antiguos y nuevos son iguales, no hay que hacer cambios
            If lngMontoAntiguo = lngMontoNuevo And lngMontoAdmAntiguo = lngMontoAdmNuevo Then
                ModificarTransaccionSiEsNecesario = True
                Exit Function
            End If

            ''si es necesario, anular la transacción antigua
            'If lngMontoAntiguo > 0 Then
            '    If intEstadoTran = 3 Then
            '        'las transacciones solicitadas se eliminan, no se anulan
            '        Call mobjSql.d_transaccion(lngRutCliente, CodCursoTemporal, intCodCuenta)
            '    Else
            '        serial_trans = InsertarTransaccion(objCurso, CodCursoTemporal, intCodCuenta, 4, -lngMontoAntiguo, _
            '                        lngRutCliente, intCodTipoTransaccion)
            '    End If
            '    blnActSaldoCuenta = True
            'End If

            ''si tiene administración, anularla
            'If lngMontoAdmAntiguo > 0 Then
            '    If intEstadoTran = 3 Then   'eliminar las solicitadas
            '        Call mobjSql.d_transaccion(lngRutCliente, CodCursoTemporal, 3)
            '    Else
            '        serial_trans = InsertarTransaccion(objCurso, CodCursoTemporal, 3, 4, -lngMontoAdmAntiguo, lngRutCliente, intCodTipoTransaccion)
            '    End If
            '    blnActSaldoAdm = True
            'End If

            '**|** Se agregó cuenta 6 becas, no paga administración
            If Not blnModMontoSolicitudes Or intCodCuenta = 1 Or intCodCuenta = 4 Or intCodCuenta = 6 Then
                'agregar la nueva transaccion si es necesario
                If lngMontoNuevo > 0 Then
                    If intCodTipoTransaccion = 5 Then
                        serial_trans = InsertarTransaccion(objCurso, CodCursoTemporal, intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente, intCodTipoTransaccion)
                    Else
                        serial_trans = InsertarTransaccion(objCurso, CodCursoTemporal, intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente)
                    End If
                    blnActSaldoCuenta = True
                End If

                'si la cuenta es cta. cap o cta. rep, tiene administración
                If (intCodCuenta = 1 Or intCodCuenta = 2) And lngMontoAdmNuevo > 0 Then
                    If intCodTipoTransaccion = 5 Then
                        serial_trans = InsertarTransaccion(objCurso, CodCursoTemporal, 3, intEstadoTran, lngMontoAdmNuevo, lngRutCliente, intCodTipoTransaccion)
                    Else
                        serial_trans = InsertarTransaccion(objCurso, CodCursoTemporal, 3, intEstadoTran, lngMontoAdmNuevo, lngRutCliente)
                    End If
                    blnActSaldoAdm = True
                End If
            Else
                If lngMontoAntiguo > 0 Then
                    If lngMontoNuevo > 0 Then
                        serial_trans = InsertarTransaccion(objCurso, CodCursoTemporal, intCodCuenta, intEstadoTran, lngMontoNuevo, lngRutCliente)
                        Call mobjSql.u_nro_trans_solicitud_pago_ter1(CodCursoTemporal, lngRutCliente, serial_trans)
                        'Dim dr As DataRow
                        'For Each dr In Me.mdtTransaccion.Rows
                        '    If dr("cod_curso") = CodCursoTemporal Then
                        '        dr("cod_ultimo_estado") = objCurso.CodUltEstadoCurso
                        '    End If
                        'Next
                        blnActSaldoCuenta = True
                    End If
                End If
            End If
            'actualizar los saldos si es necesario
            'actualizar saldo cuenta
            If blnActSaldoCuenta Then Call ActualizarSaldoCuenta(objCurso, CodCursoTemporal, lngRutCliente, intCodCuenta)
            'actualizar saldo cuenta de administración
            If blnActSaldoAdm Then Call ActualizarSaldoCuenta(objCurso, CodCursoTemporal, lngRutCliente, 3)

            ModificarTransaccionSiEsNecesario = True
        Catch ex As Exception
            'Call mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:ModificarTransaccionSiEsNecesario-->" & ex.Message)
        End Try
    End Function
    'procedimiento que inserta una transacción en la base de datos
    Private Function InsertarTransaccion(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long, _
                                        ByVal intCodCuenta As Integer, ByVal intEstadoTrans As Integer, _
                                        ByVal lngMontoTran As Long, ByVal lngRutCliente As Long, _
                                        Optional ByVal intTipoTrans As Integer = 2) As Long

        Try
            'ahora intTipoTrans lo doy como parametro
            'Dim intTipoTrans As Integer
            Dim lngSerialTrans As Long
            Dim strDescripcion As String
            Dim intEstadoTranTemp As Integer
            Dim blnError As Boolean
            'intTipoTrans = 2
            blnError = False  'no hay error
            intEstadoTranTemp = intEstadoTrans
            'intEstadoTrans: 1 pendiente, 2 autorizada, 3 solicitada, 4 anulada
            Select Case intEstadoTrans
                'intCodCuenta: 1 cap, 2 rep, 3 adm, 4 exc cap, 5 exc rep
                Case 1 'pendiente
                    Select Case intCodCuenta
                        Case 1, 4
                            If intTipoTrans = 5 Then
                                strDescripcion = "Cargo por V&T de Curso"
                            ElseIf intTipoTrans = 2 Then
                                strDescripcion = "Cargo por Curso"
                            End If
                        Case 3
                            If intTipoTrans = 5 Then
                                strDescripcion = "Cargo por Administración de V&T de Curso"
                            ElseIf intTipoTrans = 2 Then
                                strDescripcion = "Cargo por Administración de Curso"
                            End If
                        Case 2, 5
                            strDescripcion = "Cargo por Curso de Tercero"
                            intEstadoTranTemp = 3
                        Case 6
                            strDescripcion = "Cargo por Curso con Becas"
                        Case Else
                            blnError = True
                    End Select
                Case 2 'autorizada
                    Select Case intCodCuenta
                        Case 1, 4
                            If intTipoTrans = 5 Then
                                strDescripcion = "Ajuste de V&T de Curso"
                            ElseIf intTipoTrans = 2 Then
                                strDescripcion = "Ajuste de Curso"
                            End If
                        Case 3
                            If intTipoTrans = 5 Then
                                strDescripcion = "Ajuste por Administración de V&T de Curso"
                            ElseIf intTipoTrans = 2 Then
                                strDescripcion = "Ajuste por Administración de Curso"
                            End If
                        Case 2, 5
                            strDescripcion = "Ajuste por Curso de Tercero"
                        Case 6
                            strDescripcion = "Ajuste por Curso con Becas"
                        Case Else
                            blnError = True
                    End Select
                Case 3 'solicitada
                    Select Case intCodCuenta
                        Case 2, 5
                            strDescripcion = "Cargo por Curso de Tercero"
                        Case Else
                            blnError = True
                    End Select
                Case 4 'anulada
                    Select Case intCodCuenta
                        Case 1, 4
                            If intTipoTrans = 5 Then
                                strDescripcion = "Anulación de Cargo por V&T de Curso"
                            ElseIf intTipoTrans = 2 Then
                                strDescripcion = "Anulación de Cargo por Curso"
                            End If
                        Case 3
                            If intTipoTrans = 5 Then
                                strDescripcion = "Anulación de Cargo por Administración de V&T de Curso"
                            ElseIf intTipoTrans = 2 Then
                                strDescripcion = "Anulación de Cargo por Administración de Curso"
                            End If
                        Case 2, 5
                            strDescripcion = "Anulación de Cargo por Curso de Tercero"
                        Case 6
                            strDescripcion = "Anulación de Curso con Becas"
                        Case Else
                            blnError = True
                    End Select
                Case Else
                    blnError = True
            End Select
            Dim dtmFechaHoraTran As Date
            dtmFechaHoraTran = Now
            'si la fecha de inicio del curso es posterior al año actual
            If Year(objCurso.FechaInicio) > Year(dtmFechaHoraTran) Then
                dtmFechaHoraTran = FechaMinSistema()
            ElseIf Year(objCurso.FechaInicio) < Year(dtmFechaHoraTran) Then
                dtmFechaHoraTran = FechaMaxSistema() 'fecha y hora
            End If
            'lngSerialTrans = mobjSql.i_transaccion(lngRutCliente, intCodCuenta, intTipoTrans, _
            '    intEstadoTranTemp, lngMontoTran, _
            '    strDescripcion & ", Correlativo: " & Trim(CStr(objCurso.Correlativo)), _
            '    CodCursoTemporal, 0, dtmFechaHoraTran)
            Dim drTrans As DataRow
            drTrans = mdtTransaccion.NewRow
            mlngNumeroTransActual = mdtTransaccion.Rows.Count + 1
            drTrans("nro_transaccion") = mdtTransaccion.Rows.Count + 1
            drTrans("rut_cliente") = lngRutCliente
            drTrans("cod_cuenta") = intCodCuenta
            drTrans("cod_tipo_tran") = intTipoTrans
            drTrans("cod_curso") = CodCursoTemporal
            drTrans("cod_estado_tran") = intEstadoTranTemp
            drTrans("fecha_hora") = dtmFechaHoraTran
            drTrans("monto") = lngMontoTran
            drTrans("descripcion") = strDescripcion & ", Correlativo: " & "-" & CodCursoTemporal
            drTrans("cod_aporte") = 0
            'drTrans("cod_traspaso") = "null"
            mdtTransaccion.Rows.Add(drTrans)


        Catch ex As Exception
            EnviaError("CCursoContratado:ModificarTransaccionSiEsNecesario-->" & ex.Message)
        End Try
    End Function
    'actualiza el saldo en la cuenta de un cliente
    Private Sub ActualizarSaldoCuenta(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long, _
                                        ByVal lngRutEmpresa As Long, ByVal intCodCuenta As Integer)

        Try
            If lngRutEmpresa = RutUsrALng(objCurso.RutCliente) Then  'si es el cliente dueño del curso
                Select Case intCodCuenta
                    Case 1
                        objCurso.Cliente.ObjCuentaCap.Actualizar_Saldo()
                    Case 3
                        objCurso.Cliente.ObjCuentaAdm.Actualizar_Saldo()
                    Case 4
                        objCurso.Cliente.ObjCuentaExcCap.Actualizar_Saldo()
                    Case 6 '**|**
                        objCurso.Cliente.ObjCuentaBecas.Actualizar_Saldo()

                End Select
            Else
                'actualizar la cuenta de un tercero
                Dim objCliente As New CCliente
                objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                objCliente.Inicializar1(RutLngAUsr(lngRutEmpresa))
                Select Case intCodCuenta
                    Case 2
                        objCurso.Cliente.ObjCuentaRep.Actualizar_Saldo()
                    Case 3
                        objCurso.Cliente.ObjCuentaAdm.Actualizar_Saldo()
                    Case 5
                        objCurso.Cliente.ObjCuentaExcRep.Actualizar_Saldo()
                    Case 6 '**|**
                        objCurso.Cliente.ObjCuentaBecas.Actualizar_Saldo()
                End Select
            End If
        Catch ex As Exception
            'mobjSql.RollBackTransaccion()
            EnviaError("CCursoContratado:ModificarTransaccionSiEsNecesario-->" & ex.Message)
        End Try
    End Sub
    Public Function CambiarEstIngresado(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long, _
                                        ByVal strGlosa As String) As Boolean
        Try

            'el curso puede cambiar a estdo ingresado sólo si está incompleto-0, ingresado-1,
            'rechazado-2, autorizado-3, eliminado-8 - (Pago por autorizar 6, NO devuelve el último estado)
            If objCurso.CodEstadoCurso = 6 Then
                'Deja pasar
            ElseIf objCurso.CodEstadoCurso <> 0 And objCurso.CodEstadoCurso <> 1 And objCurso.CodEstadoCurso <> 2 _
                And objCurso.CodEstadoCurso <> 3 And objCurso.CodEstadoCurso <> 6 And objCurso.CodEstadoCurso <> 8 Then
                CambiarEstIngresado = False
                Exit Function
            End If

            Dim dtEstadoTrans As DataTable
            Dim i, intTamArr, intContador As Integer
            Dim lngMaxCorrelativo As Long
            Dim blnResultado As Boolean
            dtEstadoTrans = mobjSql.s_num_rut_cta_est_tran(CodCursoTemporal)
            If mobjSql.Registros > 0 Then
                If objCurso.CodEstadoCurso = 6 Then
                    objCurso.CodEstadoCurso = mobjSql.s_ultimo_estado_curso(CodCursoTemporal)
                    If objCurso.CodEstadoCurso = 6 Or objCurso.CodEstadoCurso = 0 Then 'Esto no debería pasar
                        objCurso.CodEstadoCurso = 1
                    End If
                Else
                    objCurso.CodEstadoCurso = 1  '1 es el codigo del estado "Ingresado"
                End If

                'abrir conexion y transaccion
                'mobjSql.InicioTransaccion()
                'mobjSql.u_estado_curso(CodCursoTemporal, objCurso.CodEstadoCurso)
                Dim dr As DataRow
                For Each dr In Me.mdtCursoContratado.Rows
                    If dr("cod_curso") = CodCursoTemporal Then
                        dr("cod_estado_curso") = objCurso.CodEstadoCurso
                    End If
                Next
                'mobjSql.i_bitacora(mlngRutUsuario, "Ingresado", _
                '                "El Curso cambia a estado Ingresado. Cliente: " _
                '                & objCurso.RutCliente & ". " & strGlosa, _
                '                1, CodCursoTemporal)
                Dim drBitacora As DataRow
                drBitacora = Me.mdtBitacora.NewRow
                drBitacora("cod_bitacora") = mdtBitacora.Rows.Count + 1
                drBitacora("rut_usuario") = mlngRutUsuario
                drBitacora("fecha_hora") = Now
                drBitacora("obs") = "El Curso cambia a estado Ingresado. Cliente: " & objCurso.RutCliente & ". " & strGlosa
                drBitacora("cod_tipo_ref") = 1
                drBitacora("nombre_estado") = "Ingresado"
                drBitacora("cod_ref") = CodCursoTemporal
                mdtBitacora.Rows.Add(drBitacora)

                If objCurso.Correlativo <= 0 Then
                    If objCurso.GenerarNuevoCorr Then
                        lngMaxCorrelativo = mobjSql.s_max_correlativo(objCurso.Agno)
                        If lngMaxCorrelativo >= 0 Then
                            objCurso.Correlativo = lngMaxCorrelativo + 1
                        Else
                            objCurso.Correlativo = 1
                        End If
                    Else
                        objCurso.Correlativo = objCurso.CorrElearning
                    End If
                    Call ActualizarDatos(objCurso, CodCursoTemporal, 0)
                End If

                'cerrar transacción y conexion
                'Call mobjSql.FinTransaccion()

                blnResultado = True
            Else
                CambiarEstPagoPorAut(objCurso, CodCursoTemporal, "")
                blnResultado = False
            End If
            CambiarEstIngresado = blnResultado

        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstIngresado-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Function
    Public Sub CambiarEstPagoPorAut(ByRef objCurso As CCursoContratado, ByVal CodCursoTemporal As Long, _
                                        ByVal strGlosa As String)
        Try
            Dim dtEstadoTrans As DataTable
            Dim i, intTamArr, intContador As Integer

            dtEstadoTrans = mobjSql.s_num_rut_cta_est_tran(CodCursoTemporal)
            intTamArr = mobjSql.Registros '(dtEstadoTrans)
            intContador = 0
            For i = 0 To (intTamArr - 1)
                If dtEstadoTrans.Rows(i)(3) = 3 Then '(3, i)
                    intContador = intContador + 1
                End If
            Next

            If intContador > 0 Then
                If objCurso.CodEstadoCurso <> 6 Then
                    objCurso.CodUltEstadoCurso = objCurso.CodEstadoCurso  'Registra el último estado
                End If
                objCurso.CodEstadoCurso = 6                          '6 es el codigo del estado "Pago por Autorizar"

                'abrir conexion y transaccion
                ' Call mobjSql.InicioTransaccion()

                'Registra el ult. estado, que será devuelto cuando se autoricen los pagos o se anulen
                'Call mobjSql.u_ultimo_estado_curso(CodCursoTemporal, objCurso.CodUltEstadoCurso)
                Dim dr As DataRow
                For Each dr In Me.mdtCursoContratado.Rows
                    If dr("cod_curso") = CodCursoTemporal Then
                        dr("cod_ultimo_estado") = objCurso.CodUltEstadoCurso
                    End If
                Next
                'Call mobjSql.u_estado_curso(CodCursoTemporal, objCurso.CodEstadoCurso)
                For Each dr In Me.mdtCursoContratado.Rows
                    If dr("cod_curso") = CodCursoTemporal Then
                        dr("cod_estado_curso") = objCurso.CodEstadoCurso
                    End If
                Next
                'Call mobjSql.i_bitacora(mlngRutUsuario, "Pago por Autorizar", _
                '                "Se espera autorizacion de Tercero para Pago. " _
                '                & "El Curso cambia a estado Pago por Autorizar. Cliente: " _
                '                & objCurso.RutCliente & ". " & strGlosa, _
                '                1, CodCursoTemporal)
                Dim drBitacora As DataRow
                drBitacora = Me.mdtBitacora.NewRow
                drBitacora("cod_bitacora") = mdtBitacora.Rows.Count + 1
                drBitacora("rut_usuario") = mlngRutUsuario
                drBitacora("fecha_hora") = Now
                drBitacora("obs") = "El Curso cambia a estado Pago por Autorizar. Cliente: " & objCurso.RutCliente & ". " & strGlosa
                drBitacora("cod_tipo_ref") = 1
                drBitacora("nombre_estado") = "Pago por Autorizar"
                drBitacora("cod_ref") = CodCursoTemporal
                mdtBitacora.Rows.Add(drBitacora)
                'cerrar transacción y conexion
                'Call mobjSql.FinTransaccion()
            End If
            Exit Sub
        Catch ex As Exception
            EnviaError("CCurso2:CambiarEstPagoPorAut-->" & ex.Message)
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Sub
End Class
