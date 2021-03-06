Imports Modulos
Imports Clases
Imports System.Data
Imports System.Web
Imports System.Collections.Specialized

Namespace Clases
    Public Class CSql
        'Hereda CConexion_BD: Es hija de una conexi�n BD
        Inherits CConexion_BD

        'Registros devueltos por las consultas
        Private mlngRegistros As Long
        'Tiene costo emp franq(tipo 2) + los tipos de costos emp (franq=0) 
        'incluyendo proyectos emp. (tipo 6 con franq=0) **se antepone where o and
        Private Const mstrWhereCostoEmp = " (cod_tipo_cuenta In (2,5) or (cod_tipo_cuenta in (3,4,5,10,11,12,13,14,15,6) and flag_franq=0)) "
        'Tiene costo otic + adm (tipo cuenta=1) 
        '+ los proyectos franq (tipo 6 con franq=1)     **se antepone where o and
        Private Const mstrWhereCostoOtic = " (cod_tipo_cuenta In (1) or (cod_tipo_cuenta in (6) and flag_franq=1)) "
        Private Const mstrWhereCursosNoValidos = " (2) " 'anulados
        Private mstrTipoBD As String
        'Abre la BD y la transacci�nf
        Public Sub InicioTransaccion()
            Me.Abrir()
            Me.BeginTransaction()
        End Sub

        'Cierra la transacci�n y BD
        Public Sub FinTransaccion()
            Me.CommitTransaction()
            Me.Cerrar()
        End Sub

        'Aplica rollback y cierra BD
        Public Sub RollBackTransaccion()
            Me.RollBack()
            Me.Cerrar()
        End Sub

        'Reemplaza los par�metros por valores
        Private Function SqlParam(ByVal strQuery As String, ByRef arrParam As Array) As String
            Try
                Dim intMaxParam, i As Integer
                intMaxParam = arrParam.GetLength(0)  'tama�o del arreglo
                For i = 0 To intMaxParam - 1
                    strQuery = Replace(strQuery, "[" & i & "]", arrParam(i))
                Next

                SqlParam = strQuery
            Catch ex As Exception
                EnviaError(ex.Message)
            End Try
        End Function

        'funcion para obtener un valor retornado por una consulta
        Public Function ValorSql(ByVal strSqlQuery As String) As Object
            Try
                Call Me.ConsultaSql(strSqlQuery)
                If Me.Registros <= 0 Then
                    ValorSql = Nothing
                Else
                    'Obtiene el 1er valor    
                    ValorSql = Me.dsDataTable.Rows(0)(0)
                End If

            Catch ex As Exception
                EnviaError(ex.Message)
            End Try
        End Function
        Public Function CargaMasivaSqlBulkCopy(ByVal dt As DataTable, ByVal strNombreTabla As String) As Boolean
            Try
                If Not dt Is Nothing Then
                    Dim dtEstruct As New DataTable
                    dtEstruct = s_estructura_tabla(strNombreTabla)
                    
                    Dim bolPoseeIdentidad As Boolean
                    bolPoseeIdentidad = PoseeIdentidad(strNombreTabla)
                    CargaMasivaSqlBulkCopy = EjecutarCargaSqlBulkCopy(dt, strNombreTabla, bolPoseeIdentidad)
                Else
                    CargaMasivaSqlBulkCopy = False
                    Exit Function
                End If
            Catch ex As Exception
                EnviaError(ex.Message)
            End Try
        End Function
        'funcion para obtener el serial de una tabla
        Public Function Serial(ByVal strCampo As String, ByVal strTabla As String) As Long
            Dim val As Long
            val = ValorSql("SELECT " & IsNullCampo("MAX(" & strCampo & ")", 0) & "FROM " & strTabla)
            If IsNothing(val) Then
                Serial = 0   'no existen registros
            Else
                Serial = val
            End If
        End Function
        'busca si existe el un registro en la tabla y con el campo proporcionados
        Public Function ExisteRegistro(ByVal lngRut As Long, ByVal Tabla As String, _
                                       ByVal campo As String, _
                                       Optional ByVal strValor As String = "") As Boolean

            Dim strQuery As String, arrParam(0)

            If lngRut <> -1 Then
                arrParam(0) = lngRut
            Else
                arrParam(0) = StringSql(strValor)
            End If

            strQuery = _
                "Select count(*) as Registros " _
                & "From " & Tabla _
                & " Where " & campo & " = [0] "

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If IsDBNull(dt.Rows(0)("Registros")) Then
                ExisteRegistro = False
            Else
                If dt.Rows(0)("Registros") > 0 Then
                    ExisteRegistro = True
                Else
                    ExisteRegistro = False
                End If
            End If

        End Function
        Public Function ExisteEjecutivoParaSupervisor(ByVal lngRutEjecutivo As Long, ByVal lngRutSupervisor As Long) As Boolean

            Dim strQuery As String, arrParam(1)

            If lngRutEjecutivo <> -1 Then
                arrParam(0) = lngRutEjecutivo
            End If
            If lngRutSupervisor <> -1 Then
                arrParam(1) = lngRutSupervisor
            End If

            strQuery = _
                "Select count(*) as Registros " _
                & "From supervisor " _
                & " Where rut_ejecutivo = [0] and rut_supervisor = [1] "

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If IsDBNull(dt.Rows(0)("Registros")) Then
                ExisteEjecutivoParaSupervisor = False
            Else
                If dt.Rows(0)("Registros") > 0 Then
                    ExisteEjecutivoParaSupervisor = True
                Else
                    ExisteEjecutivoParaSupervisor = False
                End If
            End If

        End Function
        'busca si existe el un registro en la tabla para el mantenedor de clasificador
        Public Function ExisteRegistroClasificador(ByVal lngRut As Long, ByVal codClasificador As String, ByVal Tabla As String, _
                                       ByVal campo1 As String, _
                                       ByVal campo2 As String, _
                                       Optional ByVal strValor As String = "") As Boolean

            Dim strQuery As String, arrParam(1)

            'If lngRut <> -1 Then
            arrParam(0) = lngRut
            arrParam(1) = StringSql(codClasificador)

            'Else
            'arrParam(0) = StringSql(strValor)
            'End If

            strQuery = _
                "Select count(*) as Registros " _
                & "From " & Tabla _
                & " Where " & campo1 & " = [0] and " & campo2 & " = [1]"

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If IsDBNull(dt.Rows(0)("Registros")) Then
                ExisteRegistroClasificador = False
            Else
                If dt.Rows(0)("Registros") > 0 Then
                    ExisteRegistroClasificador = True
                Else
                    ExisteRegistroClasificador = False
                End If
            End If

        End Function
        'Funcion que retorna true si el registro ya existe en la base de datos
        Public Function Existe_Franquicia(ByVal lngRut As Long, ByVal intAgno As Integer) As Boolean
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRut
            arrParam(1) = intAgno

            strQuery = _
                "Select count(*) " _
                & "From franquicia " _
                & "Where Rut = [0] and agno=[1] "

            Dim arrDatos As DataTable
            arrDatos = ConsultaSql(SqlParam(strQuery, arrParam))
            If arrDatos.Rows(0)(0) > 0 Then
                Existe_Franquicia = True
            Else
                Existe_Franquicia = False
            End If
        End Function
        Public Function PoseeIdentidad(ByVal NombreTabla As String) As Boolean
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(NombreTabla)
            strQuery = _
                "select table_name, column_name, data_type " _
                & "from information_schema.columns " _
                & "where " _
                & "table_schema = 'dbo' " _
                & "and columnproperty(object_id(table_name), column_name,'IsIdentity') = 1 " _
                & "and table_name=[0] " _
                & "order by table_name "
            Dim dtDatos As DataTable
            dtDatos = ConsultaSql(SqlParam(strQuery, arrParam))
            If Not dtDatos Is Nothing Then
                If dtDatos.Rows.Count > 0 Then
                    PoseeIdentidad = True
                Else

                End If
            Else
                PoseeIdentidad = False
            End If
        End Function
        'busca si existe el un registro en la tabla y con el campo proporcionados
        Public Function ExisteCodigoString(ByVal strCodigo As String, ByVal Tabla As String, _
                                       ByVal campo As String) As Boolean

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigo)

            strQuery = _
                "Select count(*) as Registros " _
                & "From " & Tabla _
                & " Where " & campo & " = [0] "

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If IsDBNull(dt.Rows(0)("Registros")) Then
                ExisteCodigoString = False
            Else
                If dt.Rows(0)("Registros") > 0 Then
                    ExisteCodigoString = True
                Else
                    ExisteCodigoString = False
                End If
            End If
        End Function
        'busca si existe el un registro en la tabla y con el campo proporcionados
        Public Function ExisteCodigoSence(ByVal strCodigo As String) As Boolean

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigo)

            strQuery = _
                "Select count(*) as Registros " _
                & "From valor_hora_sence Where codigo_sence = [0] and agno = year(getdate()) and vigente=1"

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If IsDBNull(dt.Rows(0)("Registros")) Then
                ExisteCodigoSence = False
            Else
                If dt.Rows(0)("Registros") > 0 Then
                    ExisteCodigoSence = True
                Else
                    ExisteCodigoSence = False
                End If
            End If
        End Function
        Public Function ExisteCursoSence(ByVal strCodigo As String) As Boolean

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigo)

            strQuery = _
                "Select count(*) as Registros " _
                & "From curso Where codigo_sence = [0] "

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If IsDBNull(dt.Rows(0)("Registros")) Then
                ExisteCursoSence = False
            Else
                If dt.Rows(0)("Registros") > 0 Then
                    ExisteCursoSence = True
                Else
                    ExisteCursoSence = False
                End If
            End If
        End Function


        Public Function ExisteDiaFeriado(ByVal dtmFecha As Date) As Boolean

            Dim strQuery As String, arrParam(0)
            arrParam(0) = FechaVbABd(dtmFecha)

            strQuery = _
                "select count(feriado) resultado from feriados where feriado=[0] "

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If IsDBNull(dt.Rows(0)("resultado")) Then
                ExisteDiaFeriado = False
            Else
                If dt.Rows(0)("resultado") > 0 Then
                    ExisteDiaFeriado = True
                Else
                    ExisteDiaFeriado = False
                End If
            End If
        End Function

        'Cuenta la cantidad de registros encontrados por la consulta segun rut para
        'determinar la Existencia o no de los datos en una tabla cuyo nombre es pasado como parametro
        Public Function ExisteRegistro(ByVal intRut As Long, ByVal Tabla As String) As Boolean
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intRut
            strQuery = _
                "Select count(*) " _
                & "From " & Tabla _
                & " Where rut = [0] "

            Dim dtDatos As DataTable
            dtDatos = ConsultaSql(SqlParam(strQuery, arrParam))
            If dtDatos.Rows(0)(0) > 0 Then
                ExisteRegistro = True
            Else
                ExisteRegistro = False
            End If
        End Function
        Public Function ExisteAlumnoCursandoCurso(ByVal lngRut As Long, ByVal strcodigoSence As String, _
                                                  ByVal intAgno As Integer, ByVal lngRutEmpresa As Long) As Boolean
            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRut
            arrParam(1) = StringSql(strcodigoSence)
            arrParam(2) = intAgno
            arrParam(3) = lngRutEmpresa
            strQuery = _
                "Select count(*) " _
                & "From participante " _
                & "Where cod_curso in (select cod_curso from curso_contratado " _
                & "where codigo_sence = [1] and agno = [2] and rut_cliente = [3] and cod_estado_curso not in(8,10)) and rut_alumno = [0]"

            Dim dtDatos As DataTable
            dtDatos = ConsultaSql(SqlParam(strQuery, arrParam))
            If dtDatos.Rows(0)(0) > 2 Then
                ExisteAlumnoCursandoCurso = True
            Else
                ExisteAlumnoCursandoCurso = False
            End If
        End Function
        ' verifica si el alumno esta repetido para el mismo curso en las mismas fechas
        Public Function ExisteAlumnoCursandoCurso2(ByVal lngRut As Long, ByVal strcodigoSence As String, _
                                                  ByVal dtmFechaInicio As Date, ByVal lngRutEmpresa As Long) As Boolean
            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRut
            arrParam(1) = StringSql(strcodigoSence)
            arrParam(2) = FechaVbABd(dtmFechaInicio)
            arrParam(3) = lngRutEmpresa
            strQuery = _
                "Select count(*) " _
                & "From participante " _
                & "Where cod_curso in (select cod_curso from curso_contratado " _
                & "where codigo_sence = [1] and fecha_inicio = [2] and rut_cliente = [3] and cod_estado_curso not in(8,10)) and rut_alumno = [0]"

            Dim dtDatos As DataTable
            dtDatos = ConsultaSql(SqlParam(strQuery, arrParam))
            If dtDatos.Rows(0)(0) > 2 Then
                ExisteAlumnoCursandoCurso2 = True
            Else
                ExisteAlumnoCursandoCurso2 = False
            End If
        End Function
        'Public Function Existe_Valor_Hora_Sence(ByVal intAgno As Integer) As Boolean
        '    Dim strQuery As String, arrParam(0)
        '    arrParam(0) = intAgno
        '    strQuery = _
        '        "Select count(*) " _
        '        & "From valor_hora_sence " _
        '        & "Where agno = [0] "

        '    Dim dtDatos As DataTable
        '    dtDatos = ConsultaSql(SqlParam(strQuery, arrParam))
        '    If dtDatos.Rows(0)(0) > 0 Then
        '        Existe_Valor_Hora_Sence = True
        '    Else
        '        Existe_Valor_Hora_Sence = False
        '    End If
        'End Function
        Public Function Existe_Valor_Hora_Sence(ByVal intAgno As Integer, ByVal strCodigoSence As String) As Boolean
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intAgno
            arrParam(1) = StringSql(strCodigoSence)
            strQuery = _
                "Select count(*) " _
                & "From valor_hora_sence " _
                & "Where agno = [0]  and codigo_sence = [1]"

            Dim dtDatos As DataTable
            dtDatos = ConsultaSql(SqlParam(strQuery, arrParam))
            If dtDatos.Rows(0)(0) > 0 Then
                Existe_Valor_Hora_Sence = True
            Else
                Existe_Valor_Hora_Sence = False
            End If
        End Function


#Region "SELECT"
        Public Function s_es_dia_habil(ByVal Dia As Date) As Boolean
            'DatePart(WeekDay, [0]) not in (6,7) " _
            '& "and 
            Dim strQuery As String, arrParam(0)
            arrParam(0) = FechaVbABd(Dia)
            strQuery = _
            "select count(feriado) from feriados " _
            & "where [0] not in (select feriado from feriados) "
            Dim valor As Integer
            valor = ValorSql(SqlParam(strQuery, arrParam))
            If valor > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_es_fin_de_semana(ByVal codCurso As Long) As Boolean
            'DatePart(WeekDay, [0]) not in (6,7) " _
            '& "and 
            Dim strQuery As String, arrParam(0)
            arrParam(0) = codCurso
            strQuery = _
            "select count(*) from horario_curso " _
            & "where cod_curso = [0] and dia in (6,7) "
            Dim valor As Integer
            valor = ValorSql(SqlParam(strQuery, arrParam))
            If valor > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_feriados(ByVal Agno As Integer) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = Agno
            strQuery = _
            "select feriado fecha, motivo from feriados where year(feriado) = [0] order by feriado"
            s_feriados = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_curso_alumno_sence(ByVal lngRutAlumno As Long, ByVal lngRutEmpresa As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutAlumno
            arrParam(1) = lngRutEmpresa
            strQuery = _
            "Select cc.correlativo, ec.nombre as estado_curso, pj.razon_social, cs.nombre as nombre_curso, " _
            & "ot.razon_social as razon_social_otec, cc.fecha_inicio, cc.fecha_termino, " _
            & "cc.correlativo_empresa, (pa.porc_franquicia*100) porc_franquicia, ne.nombre as nivel_educacional, no.nombre as nivel_ocupacional," _
            & "pa.Viatico , pa.Traslado, cc.rut_cliente, cc.codigo_sence, cs.rut_otec, " _
            & "cc.cod_curso, " _
            & "cc.cod_estado_curso, cc.valor_mercado, cc.Descuento, cc.porc_adm, " _
            & "cc.horas, cc.horas_compl, cc.ind_acu_com_bip, cc.ind_desc_porc, cc.num_alumnos, (pa.porc_asistencia*100) porc_asistencia " _
            & "From participante pa, curso_contratado cc, nivel_educacional ne," _
            & "nivel_ocupacional no, estado_curso ec, persona_juridica pj, " _
            & "persona_juridica ot, curso cs " _
            & "Where pa.rut_alumno = [0] " _
            & "And pa.cod_curso = cc.cod_curso " _
            & "and cc.rut_cliente = [1] " _
            & "And pa.cod_nivel_educ = ne.cod_nivel_educ " _
            & "And pa.cod_nivel_ocup = no.cod_nivel_ocup " _
            & "And ec.cod_estado_curso = cc.cod_estado_curso " _
            & "And cc.cod_estado_curso IN (0,1,3,4,5,6,7,9,11) " _
            & "And pj.rut = cc.rut_cliente " _
            & "And ot.rut = cs.rut_otec " _
            & "And cs.codigo_sence = cc.codigo_sence " _
            & "Order By cc.correlativo "
            s_curso_alumno_sence = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_curso_alumno_sence2(ByVal lngRutAlumno As Long, ByVal lngRutEmpresa As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutAlumno
            arrParam(1) = lngRutEmpresa
            strQuery = _
            "Select cc.correlativo, ec.nombre as estado_curso, pj.razon_social, cs.nombre as nombre_curso, " _
            & "ot.razon_social as razon_social_otec, cc.fecha_inicio, cc.fecha_termino, " _
            & "cc.correlativo_empresa, (pa.porc_franquicia*100) porc_franquicia, ne.nombre as nivel_educacional, no.nombre as nivel_ocupacional," _
            & "pa.Viatico , pa.Traslado, cc.rut_cliente, cc.codigo_sence, cs.rut_otec, " _
            & "cc.cod_curso, " _
            & "cc.cod_estado_curso, cc.valor_mercado, cc.Descuento, cc.porc_adm, " _
            & "cc.horas, cc.horas_compl, cc.ind_acu_com_bip, cc.ind_desc_porc, cc.num_alumnos, (pa.porc_asistencia*100) porc_asistencia, isnull(cc.valor_hora, 0.0) valor_hora " _
            & "From participante pa, curso_contratado cc, nivel_educacional ne," _
            & "nivel_ocupacional no, estado_curso ec, persona_juridica pj, " _
            & "persona_juridica ot, curso cs " _
            & "Where pa.rut_alumno = [0] " _
            & "And pa.cod_curso = cc.cod_curso " _
            & "And pa.cod_nivel_educ = ne.cod_nivel_educ " _
            & "And pa.cod_nivel_ocup = no.cod_nivel_ocup " _
            & "And ec.cod_estado_curso = cc.cod_estado_curso " _
            & "And cc.cod_estado_curso IN (0,1,3,4,5,6,7,9,11) " _
            & "And pj.rut = cc.rut_cliente " _
            & "And ot.rut = cs.rut_otec " _
            & "And cs.codigo_sence = cc.codigo_sence " _
            & "Order By cc.agno desc, cc.correlativo desc"
            s_curso_alumno_sence2 = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        'Consulta los valores de franquicia para un cliente en especifico
        Public Function s_franquicia(ByVal lngRut As Long)

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut

            strQuery = _
                "select  valor_hora_sence.agno 'a�o', 0 as valor from valor_hora_sence " _
                & "where valor_hora_sence.agno not in (select franquicia.agno from franquicia where rut=[0]) " _
                & " Union " _
                & "Select franquicia.agno 'a�o' ,franquicia.valor " _
                & " From franquicia " _
                & " Where Rut = [0] " _
                & " order by agno "
            s_franquicia = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_franquicia2(ByVal lngRut As Long, ByVal intAgno As Integer)

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRut
            arrParam(1) = intAgno


            strQuery = _
                "Select franquicia.agno,franquicia.valor  " _
                & "From franquicia  Where Rut = [0] and agno = [1]  "
            s_franquicia2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Selecciona el horario de un curso determinado, por el codigo del curso

        Public Function s_horario_curso_csv(ByVal strCodCurso As String) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = strCodCurso

            strQuery = _
                    "Select hc.cod_curso, hc.dia, hc.hora_inicio, hc.hora_fin, cc.rut_cliente, cc.codigo_sence, cc.fecha_inicio " _
                    & "From Horario_Curso hc , curso_contratado cc " _
                    & "Where cc.cod_curso in ([0]) and hc.cod_curso = cc.cod_curso "

            s_horario_curso_csv = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_alumno_curso_csv(ByVal strCodCurso As String) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = strCodCurso

            strQuery = _
                    "select cc.rut_cliente, cc.codigo_sence, cc.fecha_inicio , p.rut_alumno, (p.porc_franquicia*100) as porc_franquicia, p.cod_nivel_educ,p.cod_nivel_ocup, " _
                    & "pj.cod_comuna, p.viatico, p.traslado, cc.cod_tipo_activ , p.cod_curso " _
                    & "from participante p , persona_juridica pj, curso_contratado cc " _
                    & "where cc.rut_cliente = pj.rut And p.cod_Curso = cc.cod_curso And p.cod_Curso in ([0]) "

            s_alumno_curso_csv = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_curso_alumno_interno(ByVal lngRutAlumno As Long, ByVal lngRutEmpresa As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutAlumno
            arrParam(1) = lngRutEmpresa
            strQuery = _
           "select ci.correlativo correlativo, eci.nombre estado_curso, pj.razon_social razon_social, ci.nombre_curso nombre_curso, " _
           & "'' razon_social_otec, ci.inicio_curso fecha_inicio, ci.fin_curso fecha_termino, " _
           & "'' correlativo_empresa, 0 porc_franquicia,0 porc_asistencia, (select nombre from nivel_educacional where cod_nivel_educ*=pn.cod_nivel_educ)nivel_educacional, " _
           & "(select nombre from nivel_ocupacional where cod_nivel_ocup*=pn.cod_nivel_ocup) nivel_ocupacional, 0 Viatico, 0 Traslado, ci.rut rut_cliente, " _
           & "0 codigo_sence, 0 rut_otec,ci.correlativo cod_curso, ci.cod_estado_curso_interno cod_estado_curso, ci.valor_curso CostoEmpAl, 0 CostoOticAl " _
           & "from curso_interno ci, estado_curso_interno eci, persona_juridica pj, persona_natural pn, participante_interno pi " _
           & "where pi.rut*=pn.rut " _
           & "and pj.rut = ci.rut " _
           & "and eci.nombre= 'Ingresado' " _
           & "and ci.correlativo = pi.correlativo " _
           & "and pi.rut= [0] " _
           & "and ci.rut= [1] " _
           & "Order By ci.correlativo "
            s_curso_alumno_interno = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_director_sucursal(ByVal lngRutDirector As Long, _
                                    ByVal strNombreDirector As String, _
                                    ByVal lngCodSucursal As Long, _
                                    ByVal strNombreSucursal As String) As Object
            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRutDirector
            arrParam(1) = SubStringSql(strNombreDirector)
            arrParam(2) = lngCodSucursal
            arrParam(3) = SubStringSql(strNombreSucursal)

            strQuery = _
                "Select ds.rut ,usuario.nombres,  " _
                & "ds.cod_sucursal, sucursal.nombre " _
                & "From usuario as usuario, sucursal as sucursal , director_sucursal as ds " _
                & "Where (ds.rut = [0] or [0] = 0) " _
                & "And (usuario.nombres like [1] or [1] = '') " _
                & "And (ds.cod_sucursal = [2] or [2] = 0) " _
                & "And (sucursal.nombre like [3] or [3] = '') " _
                & "And ds.rut = usuario.rut " _
                & "And ds.cod_sucursal = sucursal.cod_sucursal " _
                & "order by nombres"

            s_director_sucursal = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_rubros(ByVal lngCodRubro As Long, _
                                    ByVal strNombreRubro As String) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodRubro
            arrParam(1) = SubStringSql(strNombreRubro)

            strQuery = _
                "Select cod_rubro, nombre " _
              & "From rubro " _
              & "Where (cod_rubro = [0] Or [0] = 0) " _
              & "And (nombre like [1] or [1] = '')"
            s_rubros = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Consulta para cargar saldos de cursos completos sin VyT
        Public Function s_gastos_cursos_completos_sin_vyt(ByVal lngRut As Long, _
                                                        ByVal intCodCuenta As Integer, _
                                                        ByVal intAgno As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intAgno

            strQuery = _
                "Select " _
                & " isnull(Sum(monto),0),count(monto) " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_parcial Is Null " _
                & " And cod_curso_compl Is Null " _
                & " And agno = [2]) " _
                & " And Cod_Cuenta = [1] " _
                & " And rut_cliente = [0] " _
                & " And cod_tipo_tran <> 5 " _
                & " and year(fecha_hora) = [2] "

            s_gastos_cursos_completos_sin_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Consulta para sumar cursos completos
        Public Function s_suma_cursos_completos_sin_vyt(ByVal lngRut As Long, _
                                                        ByVal intCodCuenta As Integer, _
                                                        ByVal intAgno As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intAgno


            strQuery = _
            " Select isnull(count(cant),0) " _
            & " From transaccion ,(Select sum(monto) as cant " _
            & " From transaccion " _
            & " Where cod_curso in (Select cod_curso From curso_contratado " _
            & " Where cod_curso_parcial Is Null " _
            & " And cod_curso_compl Is Null " _
            & " And agno = [2] and cod_Estado_curso in (1,3,4,5,6,7,8,11) ) " _
            & " And cod_cuenta = [1] " _
            & " And rut_cliente = [0] " _
            & " And cod_tipo_tran <> 5 " _
            & " and year(fecha_hora) = [2]) as monto_ultimo " _
            & " Where cod_curso in (Select cod_curso From curso_contratado " _
            & " Where cod_curso_parcial Is Null " _
            & " And cod_curso_compl Is Null " _
            & " And agno = [2] and cod_Estado_curso in (1,3,4,5,6,7,8,11) ) " _
            & " And Cod_Cuenta = [1] " _
            & "And rut_cliente = [0] " _
            & "And cod_tipo_tran <> 5 " _
            & "and year(fecha_hora) = [2] " _
            & "and monto_ultimo.cant > 0 "

            s_suma_cursos_completos_sin_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Consulta para sumar cursos parciales sin VyT
        Public Function s_suma_cursos_parciales_sin_vyt(ByVal lngRut As Long, _
                                                        ByVal intCodCuenta As Integer, _
                                                        ByVal intAgno As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intAgno
            strQuery = _
                " Select isnull(count(cant),0) " _
                & " From transaccion ,(Select sum(monto) as cant " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_compl Is Not Null " _
                & " And agno = [2] and cod_Estado_curso in (1,3,4,5,6,7,8,11) ) " _
                & " And cod_cuenta = [1] " _
                & " And rut_cliente = [0] " _
                & " And cod_tipo_tran <> 5 " _
                & " and year(fecha_hora) = [2]) as monto_ultimo " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_compl Is Not Null " _
                & " And agno = [2] and cod_Estado_curso in (1,3,4,5,6,7,8,11) ) " _
                & " And Cod_Cuenta = [1] " _
                & "And rut_cliente = [0] " _
                & "And cod_tipo_tran <> 5 " _
                & "and year(fecha_hora) = [2] " _
                & "and monto_ultimo.cant > 0 "

            s_suma_cursos_parciales_sin_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Consulta para suma cursos complementarios sin VyT

        Public Function s_suma_cursos_complementarios_sin_vyt(ByVal lngRut As Long, _
                                                                ByVal intCodCuenta As Integer, _
                                                                ByVal intAgno As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intAgno

            strQuery = _
                " Select isnull(count(cant),0) " _
                & " From transaccion ,(Select sum(monto) as cant " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_parcial Is Not Null " _
                & " And agno = [2] and cod_Estado_curso in (1,3,4,5,6,7,8,11) ) " _
                & " And cod_cuenta = [1] " _
                & " And rut_cliente = [0] " _
                & " And cod_tipo_tran <> 5 " _
                & " and year(fecha_hora) = [2]) as monto_ultimo " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_parcial Is Not Null " _
                & " And agno = [2] and cod_Estado_curso in (1,3,4,5,6,7,8,11) ) " _
                & " And Cod_Cuenta = [1] " _
                & "And rut_cliente = [0] " _
                & "And cod_tipo_tran <> 5 " _
                & "and year(fecha_hora) = [2] " _
                & "and monto_ultimo.cant > 0 "

            s_suma_cursos_complementarios_sin_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_rankingotec_horas(ByVal intAno As Integer) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAno

            strQuery = _
                "select Sum(cc.horas*cc.num_alumnos) as total, otec.razon_social, otec.rut " _
                & "From persona_juridica as otec,curso_contratado as cc, curso as ccotec " _
                & "Where ccotec.rut_otec = Otec.Rut " _
                & "and cc.codigo_sence=ccotec.codigo_sence " _
                & "And cc.Agno = [0] and cc.cod_estado_curso in (1,3,4,5,6,7,9,11) " _
                & "group by otec.razon_social, otec.rut " _
                & "order by total desc"

            s_rankingotec_horas = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_curso_terceros(ByVal strListaRutsBenefactor As String, _
                                 ByVal strEstados As String, _
                                 ByVal dtmFechaIni As Date, _
                                 ByVal dtmFechaFin As Date) As DataTable
            Dim strQuery As String, arrParam(3)
            arrParam(0) = strListaRutsBenefactor
            arrParam(1) = strEstados
            arrParam(2) = FechaVbABd(dtmFechaIni)
            arrParam(3) = FechaVbABd(dtmFechaFin)
            Dim strWhere As String
            strWhere = ""
            If strListaRutsBenefactor <> "" Then strWhere = " And spt.rut_benefactor In ([0]) "
            If strEstados <> "" Then strWhere = " And cc.cod_estado_curso IN ([1]) " & strWhere

            strQuery = _
                "Select  cc.cod_curso, cc.correlativo, isnull(cc.nro_registro,0) as nro_registro, " _
                & "cc.codigo_sence, cs.nombre as nombre_curso, otec.rut, otec.razon_social, " _
                & "cc.cod_estado_curso, ec.nombre as estado_curso, " _
                & "cc.rut_cliente,isnull(cc.cod_curso_parcial,0) cod_curso_parcial, pj.razon_social as razon_social_empresa, " _
                & "cc.fecha_inicio, cc.fecha_termino, Origen.nombre, " _
                & "isnull(cc.cod_curso_compl,0) cod_curso_compl, 'ingreso', cc.num_alumnos, " _
                & "spt.rut_benefactor, " _
                & "isnull((Select monto From Transaccion tr " _
                & " Where spt.nro_transaccion = tr.nro_transaccion " _
                & " And cod_cuenta = 2),0) monto_rep, " _
                & "isnull((Select monto From Transaccion tr " _
                & " Where spt.nro_transaccion = tr.nro_transaccion " _
                & " And cod_cuenta = 5),0) monto_exc_rep, " _
                & "isnull((Select monto From Transaccion tr " _
                & " Where spt.nro_transaccion = tr.nro_transaccion " _
                & " And cod_cuenta = 3),0) monto_adm, " _
                & " cc.costo_otic, cc.costo_adm, cc.gasto_empresa,cc.horas_compl,  " _
                & "isnull((Select monto From Transaccion tr " _
                & " Where spt.nro_transaccion = tr.nro_transaccion " _
                & " And cod_cuenta = 6),0) monto_becas "


            strQuery = strQuery _
                & "From Curso_Contratado cc, Curso cs, Estado_Curso ec, " _
                & "Persona_Juridica pj, Persona_Juridica otec, Origen, " _
                & "Solicitud_Pago_Terceros spt " _
                & "Where fecha_inicio Between [2] And [3] " _
                & "And cc.cod_estado_curso = ec.cod_estado_curso " _
                & "And cc.codigo_sence = cs.codigo_sence " _
                & "And cs.rut_otec = otec.rut " _
                & "And cc.rut_cliente = pj.rut " _
                & "And cc.cod_origen = Origen.cod_origen " _
                & "And spt.cod_curso = cc.cod_curso " _
                & "And spt.cod_estado_solicitud <> 3 " _
                & strWhere _
                & "Order By cc.correlativo"
            s_curso_terceros = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_rankingotec_gasto(ByVal intAno As Integer) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAno

            strQuery = _
                "select Sum(cc.costo_otic + cc.costo_adm  +  cc.gasto_empresa) as total, otec.razon_social, otec.rut " _
                & "From persona_juridica as otec,curso_contratado as cc, curso as ccotec " _
                & "Where ccotec.rut_otec = Otec.Rut " _
                & "and cc.codigo_sence=ccotec.codigo_sence " _
                & "And cc.Agno = [0] and cc.cod_estado_curso in (1,3,4,5,6,7,9,11) " _
                & "group by otec.razon_social, otec.rut " _
                & "order by total desc"

            s_rankingotec_gasto = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_resumen_por_franquicia(ByVal lngRutCliente As Long, _
                                   ByVal intAgno As Integer, Optional ByVal franq As Integer = gValorNumNulo)
            Dim strQuery As String, arrParam(2)
            Dim strWhere As String


            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno

            If Not franq = gValorNumNulo Then
                arrParam(2) = franq
            End If

            strQuery = _
            "select [2] franquicia, count(Distinct(p.rut_alumno)) cant_tramo, " _
            & "count(porc_franquicia)/ count(num_alumnos)  * sum(c.horas-c.horas_compl) as HH " _
            & "from participante p, curso_contratado c " _
            & "Where P.cod_curso = c.cod_curso " _
            & "and c.agno = [1] " _
            & "and c.rut_cliente = [0] " _
            & "and c.cod_estado_curso in (1,3,4,5,6,7,9,11) " _
            & "and porc_franquicia*100 = [2] " _
            & "group by porc_franquicia " _
            & "order by franquicia "


            s_resumen_por_franquicia = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_rankingotec_participaciones(ByVal intAno As Integer) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAno

            strQuery = _
                "select Sum(cc.num_alumnos) as total, otec.razon_social, otec.rut " _
                & "From persona_juridica as otec,curso_contratado as cc, curso as ccotec " _
                & "Where ccotec.rut_otec = Otec.Rut " _
                & "and cc.codigo_sence=ccotec.codigo_sence " _
                & "And cc.Agno = [0] and cc.cod_estado_curso in (1,3,4,5,6,7,9,11) " _
                & "group by otec.razon_social, otec.rut " _
                & "order by total desc"

            s_rankingotec_participaciones = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_rankingotec_participantes(ByVal intAno As Integer) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAno

            strQuery = _
                "select count(distinct(p.rut_alumno)) as total , otec.razon_social,otec.rut " _
                & "from participante p, curso_contratado cc,curso cur, persona_juridica otec " _
                & "Where cc.cod_curso = P.cod_curso " _
                & "and cc.codigo_sence=cur.codigo_sence " _
                & "and otec.rut=cur.rut_otec and cc.agno=[0] " _
                & "and cc.cod_estado_curso in (1,3,4,5,6,7,9,11) " _
                & "group by otec.rut,otec.razon_social " _
                & "order by total desc"

            s_rankingotec_participantes = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_resumen_cliente(ByVal lngRutCliente As Long, _
                                   ByVal strNombreCliente As String, _
                                   ByVal intAgno As Integer)
            Dim strQuery As String, arrParam(2)
            Dim strWhere As String
            strWhere = ""

            If lngRutCliente > 0 Then
                strWhere = strWhere & " And t.Rut_cliente=[0] "
            End If
            If strNombreCliente <> "" Then
                strWhere = strWhere & " And (pj.razon_social)  LIKE [1] "
            End If

            arrParam(0) = lngRutCliente
            arrParam(1) = SubStringSql(strNombreCliente)
            arrParam(2) = intAgno
            'd�a siguiente

            strQuery = _
            " Select cast(isnull(t.rut_cliente,0) as varchar) rut_cliente, isnull(t.cod_cuenta,0) cod_cuenta, isnull(t.cod_tipo_tran,0) cod_tipo_tran, " _
            & "isnull(Sum(t.monto),0) as monto, isnull(pj.razon_social,'') razon_social, isnull(ec.nom_contacto,'') nom_contacto , " _
            & "isnull(ec.fono_contacto,0) fono_contacto , isnull(ec.anexo_contacto,0) anexo_contacto, isnull(u.Nombres,'') nombres, isnull(S.Nombre,'') nombre, " _
            & "(select isnull(sum(dur_cur_teorico+dur_cur_prac),0) " _
            & "from curso_contratado cc,curso c " _
            & "where cc.codigo_sence*=c.codigo_sence and cc.rut_cliente=t.rut_cliente and cc.agno = [2] And cc.cod_estado_curso IN (1,3,4,5,6,7,9,11)) as horas, " _
            & "(select isnull(sum((dur_cur_teorico+dur_cur_prac) * num_alumnos),0) from curso_contratado cc,curso c " _
            & "where cc.codigo_sence*=c.codigo_sence and cc.rut_cliente=t.rut_cliente " _
            & "and cc.agno = [2] And cc.cod_estado_curso IN (1,3,4,5,6,7,9,11)) as hh, " _
            & "(select isnull(sum(num_alumnos),0) from curso_contratado cc,curso c " _
            & "where cc.codigo_sence*=c.codigo_sence and cc.rut_cliente=t.rut_cliente " _
            & "and cc.agno = [2] And cc.cod_estado_curso IN (1,3,4,5,6,7,9,11)) as cant_part " _
            & "From transaccion t, persona_juridica pj, empresa_cliente ec, " _
            & "sucursal s, ejecutivo e, usuario u " _
            & "Where t.rut_cliente=pj.rut And t.rut_cliente=ec.rut And " _
            & "s.cod_sucursal=ec.cod_sucursal And " _
            & "t.rut_cliente = e.rut_empresa And e.rut_ejecutivo = u.Rut And " _
            & " year(t.fecha_hora)= [2] " _
            & "And (month(t.fecha_hora) <> 12 Or day(t.fecha_hora) <> 31 Or DATEPART(hh, fecha_hora) <> 23 or DATEPART(mi, fecha_hora) <> 59 Or datepart(ss, t.fecha_hora) <> 59 or t.cod_tipo_tran <> 3) " _
            & strWhere _
            & "Group by t.rut_cliente, t.cod_cuenta, t.cod_tipo_tran, " _
            & "pj.razon_social, ec.nom_contacto, ec.fono_contacto, " _
            & "ec.anexo_contacto , u.Nombres, S.Nombre " _
            & "Order By t.rut_cliente "

            s_resumen_cliente = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_resumen_cliente2(ByVal lngRutCliente As Long, _
                                   ByVal strNombreCliente As String, _
                                   ByVal intAgno As Integer)
            Dim strQuery As String, arrParam(2)
            Dim strWhere As String
            strWhere = ""

            If lngRutCliente > 0 Then
                strWhere = strWhere & " And t.Rut_cliente=[0] "
            End If
            If strNombreCliente <> "" Then
                strWhere = strWhere & " And (pj.razon_social)  LIKE [1] "
            End If

            arrParam(0) = lngRutCliente
            arrParam(1) = SubStringSql(strNombreCliente)
            arrParam(2) = intAgno
            'd�a siguiente

            strQuery = _
            "Select t.rut_cliente, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta1_cap_aporte, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran1_cap_aporte, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto1_cap_aporte, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta1_cap_ins_curso, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran1_cap_ins_curso, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto1_cap_ins_curso, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta1_cap_ingreso_exc, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran1_cap_ingreso_exc, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto1_cap_ingreso_exc, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta1_cap_tras_fondos, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran1_cap_tras_fondos, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto1_cap_tras_fondos, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta1_cap_VyT, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran1_cap_VyT, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 1 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto1_cap_VyT, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta2_rep_aporte, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran2_rep_aporte, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto2_rep_aporte, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta2_rep_ins_curso, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran2_rep_ins_curso, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto2_rep_ins_curso, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta2_rep_ingreso_exc, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran2_cap_ingreso_exc, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto2_rep_ingreso_exc, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta2_rep_tras_fondos, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran2_rep_tras_fondos, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto2_rep_tras_fondos, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta2_rep_VyT, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran2_rep_VyT, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 2 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto2_rep_VyT, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta3_adm_aporte, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran3_adm_aporte, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto3_adm_aporte, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta3_adm_ins_curso, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran3_adm_ins_curso, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto3_adm_ins_curso, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta3_adm_ingreso_exc, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran3_adm_ingreso_exc, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto3_adm_ingreso_exc, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta3_adm_tras_fondos, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran3_adm_tras_fondos, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto3_adm_tras_fondos, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta3_adm_VyT, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran3_adm_VyT, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 3 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto3_adm_VyT, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta4_exCap_aporte, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran4_exCap_aporte, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto4_exCap_aporte, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta4_exCap_ins_curso, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran4_exCap_ins_curso, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto4_exCap_ins_curso, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta4_exCap_ingreso_exc, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran4_exCap_ingreso_exc, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto4_exCap_ingreso_exc, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta4_exCap_tras_fondos, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran4_exCap_tras_fondos, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto4_exCap_tras_fondos, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta4_exCap_VyT, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran4_exCap_VyT, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 4 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto4_exCap_VyT, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta5_exRep_aporte, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran5_exRep_aporte, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=1 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto5_exRep_aporte, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta5_exRep_ins_curso, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran5_exRep_ins_curso, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=2 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto5_exRep_ins_curso, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta5_exRep_ingreso_exc, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran5_exRep_ingreso_exc, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=3 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto5_exRep_ingreso_exc, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta5_exRep_tras_fondos, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran5_exRep_tras_fondos, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=4 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto5_exRep_tras_fondos, " _
            & "isnull((Select tr.cod_cuenta " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_cuenta5_exRep_VyT, " _
            & "isnull((Select tr.cod_tipo_tran " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran= 5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) cod_tipo_tran5_exRep_VyT, " _
            & "isnull((Select Sum(tr.monto) " _
            & "From transaccion tr , empresa_cliente ec " _
            & "Where(Year(tr.fecha_hora) = [2]) " _
            & "And tr.rut_cliente=ec.rut " _
            & "and t.rut_cliente = tr.rut_cliente " _
            & "and tr.cod_cuenta = 5 " _
            & "and tr.cod_tipo_tran=5 " _
            & "Group by tr.rut_cliente, tr.cod_cuenta, tr.cod_tipo_tran),0) monto5_exRep_VyT, " _
            & "pj.razon_social, ec.nom_contacto, " _
            & "ec.fono_contacto , ec.anexo_contacto, u.Nombres, S.Nombre, " _
            & "(select isnull(sum(dur_cur_teorico+dur_cur_prac),0) " _
            & "from curso_contratado cc,curso c " _
            & "where cc.codigo_sence*=c.codigo_sence and cc.rut_cliente=t.rut_cliente and cc.agno = [2] " _
            & "And cc.cod_estado_curso IN (1,3,4,5,6,7,9,11)) as horas, " _
            & "(select isnull(sum((dur_cur_teorico+dur_cur_prac) * num_alumnos),0) " _
            & "from curso_contratado cc,curso c " _
            & "where cc.codigo_sence*=c.codigo_sence and cc.rut_cliente=t.rut_cliente and cc.agno = [2] " _
            & "And cc.cod_estado_curso IN (1,3,4,5,6,7,9,11)) as hh, " _
            & "(select isnull(sum(num_alumnos),0) " _
            & "from curso_contratado cc,curso c " _
            & "where cc.codigo_sence*=c.codigo_sence and cc.rut_cliente=t.rut_cliente and cc.agno = [2] " _
            & "And cc.cod_estado_curso IN (1,3,4,5,6,7,9,11)) as cant_part " _
            & "From transaccion t, persona_juridica pj, empresa_cliente ec, sucursal s, ejecutivo e, usuario u " _
            & "Where(t.rut_cliente = pj.rut) " _
            & "And t.rut_cliente=ec.rut " _
            & "And s.cod_sucursal=ec.cod_sucursal " _
            & "And t.rut_cliente = e.rut_empresa " _
            & "And e.rut_ejecutivo = u.Rut " _
            & "And  year(t.fecha_hora)= [2] " _
            & strWhere _
            & "Group by t.rut_cliente, " _
            & "pj.razon_social, ec.nom_contacto, ec.fono_contacto, " _
            & "ec.anexo_contacto , u.Nombres, S.Nombre " _
            & "Order By t.rut_cliente "

            s_resumen_cliente2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_saldo_cuenta_finanOtic(ByVal intAgno As Integer) As Object
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAgno

            strQuery = _
                "Select persona_juridica.rut,razon_social,isnull(sum(transaccion.monto),0) total_monto " _
                & "From transaccion, empresa_cliente, persona_juridica " _
                & "Where cod_cuenta = 7 " _
                & "And Transaccion.rut_cliente = empresa_cliente.rut " _
                & "And empresa_cliente.rut = persona_juridica.rut " _
                & "And year(Fecha_Hora) = [0] " _
                & "group by persona_juridica.rut,razon_social "

            s_saldo_cuenta_finanOtic = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_niveles_educacionales_todos() As Object

            Dim strQuery As String
            strQuery = _
                "Select cod_nivel_educ, nombre " _
                & "From  nivel_educacional " _
                & "Order by cod_nivel_educ "
            s_niveles_educacionales_todos = ConsultaSql(strQuery)

        End Function
        'total de cursos en un a�o
        Public Function s_total_cursos_contratados( _
                ByVal intAgno As Integer, _
                ByVal strEstadoCursos As String, _
                ByVal strRutClientes As String, _
                ByVal intCodSucursal As Integer, _
                ByVal lngRutEjecutivo As Long, _
                ByVal lngRutUsuario As Long _
                ) As Object
            Dim strQuery As String, arrParam(5)
            arrParam(0) = intAgno
            arrParam(1) = strEstadoCursos
            arrParam(2) = strRutClientes
            arrParam(3) = intCodSucursal
            arrParam(4) = lngRutEjecutivo
            arrParam(5) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""

            If strEstadoCursos <> "" Then strWhere = " And cc.cod_estado_curso In ([1]) "
            If strRutClientes <> "" Then strWhere = " And cc.rut_cliente In ([2]) " & strWhere
            If intCodSucursal <> 0 Or lngRutEjecutivo <> 0 Then
                strFrom = ",Empresa_Cliente ec "
                strWhere = " And ec.rut = cc.rut_cliente " & strWhere

                If intCodSucursal <> 0 Then
                    strWhere = " And ec.cod_sucursal = [3] " & strWhere
                End If
                If lngRutEjecutivo <> 0 Then
                    strFrom = ",Ejecutivo ej " & strFrom
                    strWhere = " And ej.rut_ejecutivo = [4] " _
                             & " And ej.rut_empresa = ec.rut " & strWhere
                End If
            End If

            strQuery = _
                "Select Month(cc.fecha_inicio) as cod_mes, Count(*) as total " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.Agno = [0] " _
                & "And cc.rut_cliente In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [5] ) " _
                & strWhere _
                & "Group By Month(cc.fecha_inicio) " _
                & "Order by Month(cc.fecha_inicio) "
            s_total_cursos_contratados = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'total de participantes agrupados por nivel educacional y por mes
        Public Function s_participantes_niveleduc( _
                ByVal intAgno As Integer, _
                ByVal strEstadoCursos As String, _
                ByVal strRutClientes As String, _
                ByVal intCodSucursal As Integer, _
                ByVal lngRutEjecutivo As Long, _
                ByVal lngRutUsuario As Long _
                ) As Object
            Dim strQuery As String, arrParam(5)
            arrParam(0) = intAgno
            arrParam(1) = strEstadoCursos
            arrParam(2) = strRutClientes
            arrParam(3) = intCodSucursal
            arrParam(4) = lngRutEjecutivo
            arrParam(5) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""

            If strEstadoCursos <> "" Then strWhere = " And cc.cod_estado_curso In ([1]) "
            If strRutClientes <> "" Then strWhere = " And cc.rut_cliente In ([2]) " & strWhere
            If intCodSucursal <> 0 Or lngRutEjecutivo <> 0 Then
                strFrom = ",Empresa_Cliente ec "
                strWhere = " And ec.rut = cc.rut_cliente " & strWhere

                If intCodSucursal <> 0 Then
                    strWhere = " And ec.cod_sucursal = [3] " & strWhere
                End If
                If lngRutEjecutivo <> 0 Then
                    strFrom = ",Ejecutivo ej " & strFrom
                    strWhere = " And ej.rut_ejecutivo = [4] " _
                             & " And ej.rut_empresa = ec.rut " & strWhere
                End If
            End If

            strQuery = _
                "Select ne.nombre, Month(cc.fecha_inicio), Count(*) as total " _
                & "From Participante p, Curso_Contratado cc, Nivel_Educacional ne " _
                & strFrom _
                & "Where cc.cod_curso = P.cod_curso " _
                & "And Agno = [0] " _
                & "And cc.rut_cliente In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [5] ) " _
                & "And p.cod_nivel_educ = ne.cod_nivel_educ " _
                & strWhere _
                & "Group By ne.nombre, Month(cc.fecha_inicio) "
            s_participantes_niveleduc = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'total de horas-hombre agrupadas por nivel educacional y por mes
        Public Function s_horashombre_niveleduc( _
                ByVal intAgno As Integer, _
                ByVal strEstadoCursos As String, _
                ByVal strRutClientes As String, _
                ByVal intCodSucursal As Integer, _
                ByVal lngRutEjecutivo As Long, _
                ByVal lngRutUsuario As Long _
                ) As Object
            Dim strQuery As String, arrParam(5)
            arrParam(0) = intAgno
            arrParam(1) = strEstadoCursos
            arrParam(2) = strRutClientes
            arrParam(3) = intCodSucursal
            arrParam(4) = lngRutEjecutivo
            arrParam(5) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""

            If strEstadoCursos <> "" Then strWhere = " And cc.cod_estado_curso In ([1]) "
            If strRutClientes <> "" Then strWhere = " And cc.rut_cliente In ([2]) " & strWhere
            If intCodSucursal <> 0 Or lngRutEjecutivo <> 0 Then
                strFrom = ",Empresa_Cliente ec "
                strWhere = " And ec.rut = cc.rut_cliente " & strWhere

                If intCodSucursal <> 0 Then
                    strWhere = " And ec.cod_sucursal = [3] " & strWhere
                End If
                If lngRutEjecutivo <> 0 Then
                    strFrom = ",Ejecutivo ej " & strFrom
                    strWhere = " And ej.rut_ejecutivo = [4] " _
                             & " And ej.rut_empresa = ec.rut " & strWhere
                End If
            End If

            strQuery = _
                "Select ne.nombre, Month(cc.fecha_inicio), " _
                & "Sum(cc.Horas) As horas_hombre " _
                & "From Participante p, Curso_Contratado cc, Nivel_Educacional ne " _
                & strFrom _
                & "Where cc.cod_curso = p.cod_curso " _
                & "And agno = [0] " _
                & "And cc.rut_cliente In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [5] ) " _
                & "And p.cod_nivel_educ = ne.cod_nivel_educ " _
                & strWhere _
                & "Group By ne.nombre, Month(cc.fecha_inicio) "
            s_horashombre_niveleduc = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Consulta para cargar saldos de cursos complementarios sin VyT

        Public Function s_gastos_cursos_complementarios_sin_vyt(ByVal lngRut As Long, _
                                                                ByVal intCodCuenta As Integer, _
                                                                ByVal intAgno As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intAgno

            strQuery = _
                "Select " _
                & " isnull(Sum(monto),0),count(monto) " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_parcial Is Not Null " _
                & " And agno = [2]) " _
                & " And Cod_Cuenta = [1] " _
                & " And rut_cliente = [0] " _
                & " And cod_tipo_tran <> 5 " _
                & " and year(fecha_hora) = [2] "

            s_gastos_cursos_complementarios_sin_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_gastos_cursos_parciales_sin_vyt(ByVal lngRut As Long, _
                                                        ByVal intCodCuenta As Integer, _
                                                        ByVal intAgno As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intAgno

            strQuery = _
                "Select " _
                & " isnull(Sum(monto),0),count(monto) " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_compl Is Not Null " _
                & " And agno = [2]) " _
                & " And Cod_Cuenta = [1] " _
                & " And rut_cliente = [0] " _
                & " And cod_tipo_tran <> 5 " _
                & " and year(fecha_hora) = [2] "

            s_gastos_cursos_parciales_sin_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_gastos_vyt(ByVal lngRut As Long, _
                            ByVal intCodCuenta As Integer, _
                            ByVal intAgno As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intAgno

            strQuery = _
                "Select " _
                & " isnull(Sum(monto),0) " _
                & " From transaccion " _
                & " Where Cod_Cuenta = [1] " _
                & " And rut_cliente = [0] " _
                & " And cod_tipo_tran = 5 " _
                & " And year(fecha_hora) = [2] "

            s_gastos_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'complemento de la funcion que sigue, con datos para calcular
        'el porcentaje promedio anual
        Public Function s_porc_adm_anual_aportes(ByVal intAgno As Integer, _
                                                 ByVal lngRut As Long, _
                                                 ByVal intCodCuenta As Integer) As DataTable
            Dim strQuery As String, arrParam(2)
            arrParam(0) = intAgno
            arrParam(1) = lngRut
            arrParam(2) = intCodCuenta

            strQuery = _
                " select " _
                & " monto_adm, (monto_adm + monto_neto ) as pocentaje,monto_neto " _
                & " From aporte " _
                & " Where rut_cliente = [1] " _
                & " And agno = [0] " _
                & " And (cod_estado = 1 or cod_estado = 2) " _
                & " And cod_cuenta = [2] "

            s_porc_adm_anual_aportes = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_empresas_con_mov(ByVal intAgno As Integer) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAgno

            strQuery = _
                " select rut " _
                & " From  empresa_Cliente ec, transaccion tr " _
                & " Where ec.Rut = tr.rut_cliente " _
                & " and year(tr.fecha_hora) = [0] " _
                & " group by rut "

            s_empresas_con_mov = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_razon_social_cliente(ByVal mlngRutCliente As Long) As String
            Dim strQuery As String, arrParam(0)

            arrParam(0) = mlngRutCliente

            strQuery = _
                    " Select razon_social from persona_juridica where rut= [0] "
            s_razon_social_cliente = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Mantendor de Supervisores con sus ejecutivos
        Public Function s_SupervisorEjecutivos(ByVal lngRutSupervisor As Long, _
                                               ByVal strNombreSupervisor As String, _
                                               ByVal lngRutEjecutivo As Long, _
                                               ByVal strNombreEjecutivo As String) As Object
            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRutSupervisor
            arrParam(1) = SubStringSql(strNombreSupervisor)
            arrParam(2) = lngRutEjecutivo
            arrParam(3) = SubStringSql(strNombreEjecutivo)

            strQuery = _
                "Select supervisor.rut_supervisor, persona1.dig_verif as dig_verif_supervisor ,usuario1.nombres as nomSuper,  " _
                & "supervisor.rut_ejecutivo,persona2.dig_verif as dig_verif_ejecutivo, usuario2.nombres as nomEjec " _
                & "From usuario as Usuario1,usuario as Usuario2 , supervisor, " _
                & "persona as persona1, persona as persona2 " _
                & "Where (supervisor.rut_supervisor = [0] or [0] = 0) " _
                & "And (Usuario1.nombres like [1] or [1] = '') " _
                & "And (supervisor.rut_ejecutivo = [2] or [2] = 0) " _
                & "And (Usuario2.nombres like [3] or [3] = '') " _
                & "And supervisor.rut_supervisor = usuario1.rut " _
                & "And supervisor.rut_ejecutivo = usuario2.rut " _
                & "and persona1.rut=usuario1.rut and persona2.rut=usuario2.rut "

            s_SupervisorEjecutivos = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        ' Estados de una factura
        '
        Public Function s_estados_factura() As Object
            Dim strQuery As String
            strQuery = _
                "Select cod_estado_fact, nombre " _
                & "From  estado_factura " _
                & "Order by cod_estado_fact "
            s_estados_factura = ConsultaSql(strQuery)

        End Function
        Public Function s_existe_usuario(ByVal lngRutUsuario As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutUsuario
            strSql = _
              "select count(rut) from usuario " _
              & "where rut=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_empresa_cliente(ByVal lngRutUsuario As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutUsuario
            strSql = _
              "select count(rut) from empresa_cliente " _
              & "where rut=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_ejecutivo(ByVal lngRutUsuario As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutUsuario
            strSql = _
              "select count(rut) from usuario " _
              & "where rut=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_ejecutivo_empresa(ByVal lngRutUsuario As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutUsuario
            strSql = _
              "select count(rut) from usuario " _
              & "where rut=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_encargado_empresa(ByVal lngRutEncargado As Long, ByVal lngRutEmptresa As Long) As Boolean
            Dim arrParam(1)
            Dim strSql As String
            arrParam(0) = lngRutEncargado
            arrParam(1) = lngRutEmptresa
            strSql = _
              "select count(rut_encargado) from encargado_empresa " _
              & "where rut_encargado=[0] and rut_empresa=[1]"
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_encargado(ByVal lngRutEncargado As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutEncargado
            strSql = _
              "select count(rut_encargado) from encargado " _
              & "where rut_encargado=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        'selecciona un aporte
        Public Function s_aporte_1(ByVal lngCodAporte As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodAporte

            strQuery = _
                "Select rut_cliente, cod_cuenta, agno, correlativo, fecha, " _
                & "cod_estado, monto_neto, monto_adm, (monto_neto+ monto_adm) as monto_total, " _
                & "cod_tipo_doc, IsNull(nro_documento,'') nro_documento, IsNull(banco,'') banco, " _
                & "IsNull(fecha_venc_doc,'19000101') fecha_venc_doc, IsNull(fecha_cobro,'19000101') fecha_cobro, num_aporte, " _
                & "IsNull(observaciones, '') observaciones " _
                & "From Aporte " _
                & "Where cod_aporte = [0] "
            s_aporte_1 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_encargado_curso(ByVal lngCodCurso As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                "select en.rut_encargado ,en.nombre_encargado, en.apellido_encargado,  " _
                & "isnull(en.cargo,'') cargo, isnull(en.fono,'') fono, isnull(en.email,'') email, ec.rut as rut_empresa " _
                & "from encargado en, encargado_empresa ee, empresa_cliente ec, curso_contratado cc " _
                & "where en.rut_encargado = ee.rut_encargado and ee.rut_empresa = ec.rut " _
                & "and en.rut_encargado = cc.rut_encargado and cc.cod_curso = [0] "
            s_encargado_curso = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_encargado(ByVal lngRutEncargado As Long, ByVal lngRutEmpresa As Long, ByVal strNombre As String) As DataTable

            Dim strQuery, strWhere As String, arrParam(2)
            arrParam(0) = lngRutEncargado
            arrParam(1) = lngRutEmpresa
            arrParam(2) = SubStringSql(strNombre)

            strWhere = ""

            If lngRutEncargado <> 0 Then
                strWhere = " and en.rut_encargado = [0] "
            End If
            If lngRutEmpresa <> 0 Then
                strWhere = " and ec.rut = [1] "
            End If

            If strNombre <> "" Then
                strWhere = " and (en.nombre_encargado + ' ' + en.apellido_encargado) like [2] "
            End If

            strQuery = _
                "select en.rut_encargado, en.nombre_encargado, en.apellido_encargado, isnull(en.cargo,'') cargo, " _
                & "isnull(en.fono,'') fono, isnull(en.email,'') email, ec.rut as rut_empresa " _
                & "from encargado en, encargado_empresa ee, empresa_cliente ec " _
                & "where en.rut_encargado = ee.rut_encargado " _
                & "and ee.rut_empresa = ec.rut " _
                & strWhere _
                & " ORDER BY en.rut_encargado "
            s_encargado = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Retorna true si existe el numero de aporte
        Public Function s_existe_numero_aporte(ByVal lngNumAporte As Long) As Boolean
            Dim strQuery As String, arrParam(0)
            Dim intResultado As Integer
            arrParam(0) = lngNumAporte

            strQuery = "Select count(cod_aporte) " _
                     & "From aporte " _
                     & "Where num_aporte = [0] " _
                     & "And cod_estado <> 3"

            intResultado = ValorSql(SqlParam(strQuery, arrParam))
            If intResultado > 0 Then
                s_existe_numero_aporte = True
            Else
                s_existe_numero_aporte = False
            End If
        End Function
        Public Function s_alumno_curso_interno(ByVal lngCodCurso As Long, ByVal lngRutEmpresa As Long, ByVal intAgno As Integer) As DataTable

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutEmpresa
            arrParam(2) = intAgno
            strQuery = _
            "Select p.rut, pn.nombre, pn.ap_paterno, pn.ap_materno, " _
                    & "pn.fecha_nacim, pn.cod_nivel_educ, " _
                    & "(select nombre from nivel_educacional where cod_nivel_educ = pn.cod_nivel_educ) nivel_educacional, " _
                    & "pn.sexo, (pn.porc_franquicia * 100) porc_franquicia, " _
                    & "pn.cod_nivel_ocup,(select nombre from nivel_ocupacional where cod_nivel_ocup = pn.cod_nivel_ocup) nivel_ocupacional, " _
                    & "ci.rut, ci.correlativo cod_curso, ci.nombre_curso, ci.valor_curso, p.viatico, p.traslado " _
                    & "From Participante_interno p, Persona_Natural pn, curso_interno ci, persona_juridica pj " _
                    & "Where p.rut = pn.rut And p.correlativo = [0] " _
                    & "and ci.correlativo = p.correlativo " _
                    & "and ci.rut = [1] " _
                    & "and ci.rut = pj.rut " _
                    & "and ci.ano = [2] " _
                    & "and ci.ano = p.ano"

            s_alumno_curso_interno = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_estado_alumno_curso_interno(ByVal lngCodCurso As Long, ByVal intAgno As Integer) As DataTable

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = intAgno
            strQuery = _
            "Select p.rut, p.cod_estado_part " _
                    & "From Participante_interno p " _
                    & "Where p.correlativo = [0] " _
                    & "and p.ano = [1] "

            s_estado_alumno_curso_interno = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_num_aporte_siguiente() As Long
            Dim strQuery As String
            Dim lngResultado As Long

            strQuery = "Select isnull(max(num_aporte), 0) as num_aporte from aporte " _
                     & "Where cod_estado <> 3"

            lngResultado = ValorSql(strQuery)
            'If lngResultado < 20000 Then
            '    lngResultado = 20000
            'Else
            '    lngResultado = lngResultado + 1
            'End If
            s_num_aporte_siguiente = lngResultado + 1
        End Function
        'Consulta Reporte Facturas
        Public Function s_consulta_facturas(ByVal intCodEstadoFactura As Integer, _
                                            ByVal lngRutEmpresa As Long, _
                                            ByVal lngRutOtec As Long, _
                                            ByVal lngNumFac As Long, _
                                            ByVal lngRutUsuario As Long, _
                                            Optional ByVal intAgno As Integer = 0, _
                                            Optional ByVal lngCodCurso As Long = 0)

            Dim strQuery As String, arrParam(6)
            arrParam(0) = intCodEstadoFactura
            arrParam(1) = lngRutEmpresa
            arrParam(2) = lngRutOtec
            arrParam(3) = lngNumFac
            arrParam(4) = lngRutUsuario 'Usuario Conectado
            arrParam(5) = intAgno
            arrParam(6) = lngCodCurso

            Dim strWhere As String
            strWhere = ""
            If intCodEstadoFactura > 0 Then strWhere = strWhere & " And f.cod_estado_fact = [0] "
            If lngRutEmpresa > 0 Then strWhere = strWhere & " And cc.rut_cliente = [1] "
            If lngRutOtec > 0 Then strWhere = strWhere & " And cs.rut_otec = [2] "
            If lngNumFac > 0 Then strWhere = strWhere & " And f.num_factura = [3] "
            If intAgno > 0 Then strWhere = strWhere & " And year(f.fecha) = [5] "
            If lngCodCurso > 0 Then strWhere = strWhere & " And cc.cod_curso = [6] "

            strQuery = _
                    " Select distinct cc.cod_curso, isnull(cc.correlativo,0) correlativo, isnull(cc.nro_registro,0) nro_registro, " _
                  & " cc.codigo_sence, REPLACE(REPLACE(REPLACE(cs.nombre, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_curso, " _
                  & " otec.rut as rut_otec,pe.dig_verif as dig_verif_otec, " _
                  & " REPLACE(REPLACE(REPLACE(otec.razon_social, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_otec, " _
                  & " cc.cod_estado_curso, REPLACE(REPLACE(REPLACE(ec.nombre, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_estado_curso, " _
                  & " cc.rut_cliente,pe2.dig_verif as dig_verif_cliente, REPLACE(REPLACE(REPLACE(pj.razon_social, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_persona_juridica, " _
                  & " cc.fecha_inicio, cc.fecha_termino,cc.num_alumnos, " _
                  & " isnull(cc.correlativo_empresa,'') correlativo_empresa, f.cod_estado_fact ,f.num_factura, " _
                  & " f.monto , f.fecha, f.fecha_recepcion, f.fecha_pago, " _
                  & " REPLACE(REPLACE(REPLACE(ef.Nombre, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_factura , " _
                  & " Sum(vcp.nro_perfil) as num_perfil,  isnull(f.num_voucher,0) num_voucher, isnull(f.observacion,'') observacion " _
                  & " From Curso_Contratado cc, Curso cs, Estado_Curso ec, " _
                  & " Persona_Juridica pj, Persona_Juridica otec, factura f , " _
                  & " estado_factura ef , V_Cliente_Permiso vcp, persona pe, persona pe2 " _
                  & " Where  cc.cod_curso = f.cod_curso " _
                  & " and f.cod_estado_fact = ef.cod_estado_fact " _
                  & " And cc.cod_estado_curso = ec.cod_estado_curso " _
                  & " And cc.codigo_sence = cs.codigo_sence " _
                  & " And cs.rut_otec = otec.rut and cc.rut_cliente = pj.rut " _
                  & " and cc.rut_cliente = vcp.rut_empresa AND vcp.rut_empresa=pj.rut " _
                  & " and vcp.rut_usuario=[4] " _
                  & " and pe.rut=otec.rut and pe2.rut=pj.rut "
            strQuery = strQuery & strWhere _
              & " Group By  cc.cod_curso, cc.correlativo, cc.nro_registro, " _
              & " cc.codigo_sence, cs.nombre,otec.rut, otec.razon_social, " _
              & " cc.cod_estado_curso, ec.nombre, cc.rut_cliente,pj.razon_social, " _
              & " cc.fecha_inicio, cc.fecha_termino, cc.num_alumnos, " _
              & " cc.correlativo_empresa,f.cod_estado_fact,f.num_factura, " _
              & " f.monto , f.fecha, f.fecha_recepcion, f.fecha_pago, ef.nombre, " _
              & " vcp.rut_empresa , vcp.rut_usuario, vcp.rut_usuario,pe2.dig_verif,pe.dig_verif, " _
              & " f.num_voucher, f.observacion Order By cc.rut_cliente "

            s_consulta_facturas = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Public Function s_consulta_facturas(ByVal intCodEstadoFactura As Integer, _
        '                                    ByVal lngRutEmpresa As Long, _
        '                                    ByVal lngRutOtec As Long, _
        '                                    ByVal lngNumFac As Long, _
        '                                    ByVal lngRutUsuario As Long, _
        '                                    Optional ByVal intAgno As Integer = 0, _
        '                                    Optional ByVal lngCodCurso As Long = 0)

        '    Dim strQuery As String, arrParam(6)
        '    arrParam(0) = intCodEstadoFactura
        '    arrParam(1) = lngRutEmpresa
        '    arrParam(2) = lngRutOtec
        '    arrParam(3) = lngNumFac
        '    arrParam(4) = lngRutUsuario 'Usuario Conectado
        '    arrParam(5) = intAgno
        '    arrParam(6) = lngCodCurso

        '    Dim strWhere As String
        '    strWhere = ""
        '    If intCodEstadoFactura > 0 Then strWhere = strWhere & " And f.cod_estado_fact = [0] "
        '    If lngRutEmpresa > 0 Then strWhere = strWhere & " And cc.rut_cliente = [1] "
        '    If lngRutOtec > 0 Then strWhere = strWhere & " And cs.rut_otec = [2] "
        '    If lngNumFac > 0 Then strWhere = strWhere & " And f.num_factura = [3] "
        '    If intAgno > 0 Then strWhere = strWhere & " And year(f.fecha) = [5] "
        '    If lngCodCurso > 0 Then strWhere = strWhere & " And cc.cod_curso = [6] "

        '    strQuery = _
        '            " Select distinct cc.cod_curso, isnull(cc.correlativo,0) correlativo, isnull(cc.nro_registro,0) nro_registro, " _
        '          & " cc.codigo_sence, REPLACE(REPLACE(REPLACE(cs.nombre, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_curso, otec.rut as rut_otec,pe.dig_verif as dig_verif_otec, REPLACE(REPLACE(REPLACE(otec.razon_social, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_otec, " _
        '          & " cc.cod_estado_curso, REPLACE(REPLACE(REPLACE(ec.nombre, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_estado_curso, cc.rut_cliente,pe2.dig_verif as dig_verif_cliente, REPLACE(REPLACE(REPLACE(pj.razon_social, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_persona_juridica, " _
        '          & " cc.fecha_inicio, cc.fecha_termino,cc.num_alumnos, " _
        '          & " isnull(cc.correlativo_empresa,'') correlativo_empresa, f.cod_estado_fact ,f.num_factura, " _
        '          & " f.monto , f.fecha, f.fecha_recepcion, f.fecha_pago, isnull(f.nro_documento,'') nro_documento, isnull(f.nota_credito,0) nota_credito, " _
        '          & " REPLACE(REPLACE(REPLACE(ef.Nombre, char(10), ' '), char(13), ' '), char(34), ' ') as nombre_factura , Sum(vcp.nro_perfil) as num_perfil, REPLACE(REPLACE(REPLACE(isnull(f.observacion,''), char(10), ' '), char(13), ' '), char(34), ' ') observacion,isnull(f.nro_egreso,'') nro_egreso " _
        '          & " From Curso_Contratado cc, Curso cs, Estado_Curso ec, " _
        '          & " Persona_Juridica pj, Persona_Juridica otec, factura f , " _
        '          & " estado_factura ef , V_Cliente_Permiso vcp, persona pe, persona pe2 " _
        '          & " Where  cc.cod_curso = f.cod_curso " _
        '          & " and f.cod_estado_fact = ef.cod_estado_fact " _
        '          & " And cc.cod_estado_curso = ec.cod_estado_curso " _
        '          & " And cc.codigo_sence = cs.codigo_sence " _
        '          & " And cs.rut_otec = otec.rut and cc.rut_cliente = pj.rut " _
        '          & " and cc.rut_cliente = vcp.rut_empresa AND vcp.rut_empresa=pj.rut " _
        '          & " and vcp.rut_usuario=[4] " _
        '          & "and pe.rut=otec.rut and pe2.rut=pj.rut "
        '    strQuery = strQuery & strWhere _
        '      & " Group By f.observacion, cc.cod_curso, cc.correlativo, cc.nro_registro, " _
        '      & " cc.codigo_sence, cs.nombre,otec.rut, otec.razon_social, " _
        '      & " cc.cod_estado_curso, ec.nombre, cc.rut_cliente,pj.razon_social, " _
        '      & " cc.fecha_inicio, cc.fecha_termino, cc.num_alumnos, " _
        '      & " cc.correlativo_empresa,f.cod_estado_fact,f.num_factura, " _
        '      & " f.monto , f.fecha, f.fecha_recepcion, f.fecha_pago, f.nro_documento, f.nota_credito, ef.nombre, " _
        '      & " vcp.rut_empresa , vcp.rut_usuario, vcp.rut_usuario,pe2.dig_verif,pe.dig_verif,f.nro_egreso Order By cc.rut_cliente "

        '    s_consulta_facturas = ConsultaSql(SqlParam(strQuery, arrParam))
        'End Function
        Public Function s_sucursales_todos2() As Object

            Dim strQuery As String
            strQuery = _
                "Select cod_sucursal, nombre " _
                & "From  Sucursal " _
                & "Order by cod_sucursal "
            s_sucursales_todos2 = ConsultaSql(strQuery)

        End Function
        Public Function s_sucursales_todos3(Optional ByVal strNombre As String = "") As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = SubStringSql(strNombre)
            Dim strWhere As String
            If strNombre <> "" Then
                strWhere = " where nombre like [0] "
            Else
                strWhere = ""
            End If
            strQuery = _
                "Select cod_sucursal, nombre " _
                & "From  Sucursal " & strWhere _
                & "Order by cod_sucursal "
            s_sucursales_todos3 = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_union_alumnos3(ByVal strRutClie As String, _
                                          ByVal lngRutAlumno As Long, _
                                          ByVal strNombreAlumno As String, _
                                          ByVal dtmFechaIni As Date, _
                                          ByVal dtmFechaFin As Date, _
                                          ByVal blnInterno As Boolean, _
                                          ByVal blnSence As Boolean, _
                                          ByVal intCorrelativo As Integer, _
                                          ByVal blnCurAnulados As Boolean, _
                                          ByVal blnCurEliminados As Boolean) As DataTable
            Dim strQuery As String, arrParam(7)


            Dim strEstados As String = "1,3,4,5,6,7,9,11"
            If blnCurAnulados Then
                strEstados = strEstados & ", 10"
            End If
            If blnCurEliminados Then
                strEstados = strEstados & ", 8"
            End If


            Dim strAlumnoSence As String
            Dim strAlumnoInterno As String
            Dim strUnion As String
            strAlumnoSence = ""
            strAlumnoInterno = ""
            strUnion = " union "
            Dim strWhere, condicion As String
            strWhere = ""
            condicion = " And pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno "
            If lngRutAlumno > 0 Then
                strWhere = strWhere & " And p.Rut_alumno=[0] "
            End If
            If strNombreAlumno <> "" Then
                strWhere = strWhere & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [1] "
            End If

            If intCorrelativo > 0 Then
                strWhere = strWhere & " And cc.correlativo =[6] "
            End If

            Dim strWhereUnion As String
            strWhereUnion = ""
            If lngRutAlumno > 0 Then
                strWhereUnion = strWhereUnion & " And pi.rut In ([0]) "
            End If
            If strNombreAlumno <> "" Then
                strWhereUnion = strWhereUnion & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [1] "
            End If

            arrParam(0) = lngRutAlumno
            arrParam(1) = SubStringSql(strNombreAlumno)
            arrParam(2) = FechaVbABd(dtmFechaIni)
            arrParam(3) = FechaVbABd(dtmFechaFin)
            arrParam(4) = blnInterno
            arrParam(5) = blnSence
            arrParam(6) = intCorrelativo
            arrParam(7) = strRutClie
            strAlumnoSence = _
            "Select row_number() over (order by rut_alumno ) as nFila, " _
            & "'Sence' as tipo_alumno, " _
            & "cast(p.rut_alumno as varchar) rut_alumno,  " _
            & "pe.dig_verif as dig_verif_alumno,  " _
            & "(select count(rut_alumno) from participante where rut_alumno=p.rut_alumno and cod_curso " _
            & "in (select cod_curso from curso_contratado where Fecha_inicio >= [2] and Fecha_inicio <= [3] and cod_estado_curso " _
            & "IN (" & strEstados & "))) 'repeticiones'," _
            & "isnull(pn.nombre,'') nombre ,  " _
            & "isnull(pn.ap_paterno ,'') apellido_paterno ,  " _
            & "isnull( pn.ap_materno ,'') apellido_materno,  " _
            & "pn.fecha_nacim,  isnull(pn.sexo, 'M') sexo, " _
            & "ne.nombre as nivel_educacional,  " _
            & "no.nombre as nivel_ocupacional,  " _
            & "p.cod_region,  " _
            & "cast(cc.rut_cliente as varchar) rut_cliente,  " _
            & "pe3.dig_verif as dig_verif_cliente, " _
            & "pj.razon_social,  " _
            & "cast((cc.porc_adm * 100) as float) porc_adm,  " _
            & "cc.cod_curso ,   " _
            & "cc.Correlativo,  " _
            & "cc.codigo_sence, " _
            & "isnull(cc.nro_registro, 0) nro_registro, " _
            & "isnull(cc.correlativo_empresa,'') correlativo_empresa,  " _
            & "cs.Nombre as nombre_curso,  " _
            & "mo.nombre modalidad,  " _
            & "ta.nombre tipo_actividad,  " _
            & "case isnull(cc.ind_acu_com_bip, 0) when 1 then 'SI' else 'NO' end comite_bipartito, " _
            & "case isnull(cc.flag_curso_cft, 0) when 1 then 'SI' else 'NO' end CFT, " _
            & "case isnull(cc.ind_det_nece, 0) when 1 then 'SI' else 'NO' end DNC, " _
            & "cs.rut_otec,  " _
            & "pe2.dig_verif as dig_verif_otec,  " _
            & "pj1.razon_social as nombre_otec, " _
            & "'' as 'par/compl',  " _
            & "isnull(cc.cod_curso_parcial,0) cod_curso_parcial, " _
            & "isnull((select correlativo from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) correlativo_parcial,  " _
            & "isnull((select horas from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) horas_parciales, " _
            & "cast(isnull(case isnull(cc.cod_curso_parcial,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_parcial)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_parcial and rut_alumno=p.rut_alumno)) end, 0) as numeric) costo_otic_parcial, " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_parcial) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) - isnull(case isnull(cc.cod_curso_parcial,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_parcial)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_parcial and rut_alumno=p.rut_alumno)) end, 0) as numeric) gasto_emp_parcial, " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_parcial) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) as numeric) total_parcial, " _
            & "isnull(cc.cod_curso_compl,0) cod_curso_compl, " _
            & "isnull((select correlativo from curso_contratado where cod_curso=cc.cod_curso_compl), 0) correlativo_complemento,  " _
            & "isnull((select horas from curso_contratado where cod_curso=cc.cod_curso_compl), 0) horas_compl, " _
            & "cast(isnull(case isnull(cc.cod_curso_compl,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_compl)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_compl and rut_alumno=p.rut_alumno)) end, 0) as numeric) costo_otic_complemento, " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_compl) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_compl), 0) - isnull(case isnull(cc.cod_curso_compl,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_compl)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_compl and rut_alumno=p.rut_alumno)) end, 0) as numeric) gasto_emp_complemento,  " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_compl) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_compl), 0) as numeric) total_complemento, " _
            & "cc.horas,  " _
            & "cc.horas_compl,  " _
            & "cc.agno 'a�o',  " _
            & "cc.fecha_inicio,  " _
            & "cc.fecha_termino,  " _
            & "isnull((SELECT case hc.dia when 1 then ' LUN' when 2 then ' MAR' when 3 then ' MIE' when 4 then ' JUE' when 5 then ' VIE' when 6 then ' SAB' when 7 then ' DOM' end + ':' + hora_inicio + '-' + hora_fin FROM horario_curso hc WHERE hc.cod_curso = cc.cod_curso ORDER BY hc.dia FOR XML PATH('')),'') horario_curso, " _
            & " (cc.direccion_curso + ' ' + cc.Nro_direccion_curso) direccion_curso,  " _
            & "cc.num_alumnos,  " _
            & "cc.cod_estado_curso, " _
            & "ec.nombre estado_curso,  " _
            & "cast((p.porc_franquicia*100) as float) porc_franquicia,  " _
            & "cast((p.porc_asistencia*100) as float) porc_asistencia,  " _
            & "case when cc.cod_estado_curso in (1,3,4,7) then 'EN CURSO' when cc.cod_estado_curso in (5,9,11) and cast((p.porc_asistencia*100) as float) >= 75 then 'APROBADO' when cc.cod_estado_curso in (5,9,11) and cast((p.porc_asistencia*100) as float) < 75 then 'REPROBADO' else '-' end estado_aprobacion,  " _
            & "isnull(cast(p.nota_obtenida as varchar), '-') evaluacion, " _
            & " (cc.valor_mercado / num_alumnos) valor_mercado,  " _
            & "0 as 'costo_otic_curso', " _
            & "0 as 'gasto_emp_curso', " _
            & " (p.porc_franquicia * p.viatico) +  (p.viatico - (p.porc_franquicia * p.viatico)) viatico_total, " _
            & " (p.porc_franquicia * p.viatico) viatico_otic,  " _
            & " (p.viatico - (p.porc_franquicia * p.viatico)) viatico_ge,  " _
            & " (p.porc_franquicia * p.traslado) +  (p.traslado - (p.porc_franquicia * p.traslado)) traslado_total," _
            & " (p.porc_franquicia * p.traslado) traslado_otic,  " _
            & " (p.traslado - (p.porc_franquicia * p.traslado)) traslado_ge,  " _
            & "0 as 'total_otic',  " _
            & "0 as 'total_empresa',  " _
            & "0 as 'total_alumno'  " _
                        & "From Participante p, Persona_Natural pn, curso_contratado cc, Persona_Juridica pj1, " _
                        & "Persona_Juridica pj, Curso cs , Nivel_Educacional ne, Nivel_Ocupacional no,persona pe, " _
                        & "persona pe2, persona pe3, tipo_actividad ta, estado_curso ec, modalidad mo " _
                        & "Where p.rut_alumno = pn.rut And p.cod_curso = cc.cod_curso and " _
                        & "pj.rut = cc.rut_cliente And " _
                        & "cs.codigo_sence=cc.codigo_sence and " _
                        & "ne.cod_nivel_educ = P.cod_nivel_educ And no.cod_nivel_ocup = P.cod_nivel_ocup " _
                        & "And pj1.rut=cs.rut_otec " & strWhere _
                        & "and cc.Fecha_inicio >= [2] and cc.Fecha_inicio <= [3] " _
                        & "and pe.rut = pn.rut and pe2.rut = pj1.rut and pe3.rut = pj.rut " _
                        & "and cc.rut_cliente in (select rut from empresa_cliente where cod_estado_cliente = 1) " _
                        & "and ta.cod_tipo_activ = cc.cod_tipo_activ " _
                        & "and cc.cod_estado_curso IN (" & strEstados & ") " _
                        & "and cc.cod_estado_curso = ec.cod_estado_curso and cc.cod_modalidad = mo.cod_modalidad and cc.cod_tipo_activ = ta.cod_tipo_activ  "


            strAlumnoInterno = _
                         "select row_number() over (order by pi.rut ) as nFila, " _
                & "'Interno' as tipo_alumno,  " _
                & "cast(pi.rut as varchar) rut_alumno, " _
                & "pe.dig_verif as dig_verif_alumno, " _
                & "'' 'repeticiones'," _
                & "isnull(pn.nombre,'') nombre , " _
                & "isnull(pn.ap_paterno ,'')apellido_paterno , " _
                & "isnull( pn.ap_materno ,'') apellido_materno,  " _
                & "pn.fecha_nacim fecha_nacim,  isnull(pn.sexo, 'M') sexo, " _
                & " (select nombre from nivel_educacional where cod_nivel_educ=pn.cod_nivel_educ)nivel_educacional,  " _
                & " (select nombre from nivel_ocupacional where cod_nivel_ocup=pn.cod_nivel_ocup) nivel_ocupacional,  " _
                & "pn.cod_region,  " _
                & "cast(ci.rut as varchar) rut_cliente,  " _
                & "pe3.dig_verif as dig_verif_cliente, " _
                & "pj.razon_social razon_social,  " _
                & "0 porc_adm,  " _
                & "0 cod_curso, " _
                & "ci.correlativo correlativo,  " _
                & "0 codigo_sence,  " _
                & "0 nro_registro,  " _
                & "isnull(ci.correlativo_empresa,'') correlativo_empresa, " _
                & "ci.nombre_curso nombre_curso,   " _
                & "'-' modalidad , " _
                & "'-' tipo_actividad ,  " _
                & "'-' comite_bipartito,  " _
                & "'-' CFT, " _
                & "'-' DNC, " _
                & "0 rut_otec, " _
                & "'-' dig_verif_otec,  " _
                & "ci.ejecutor as nombre_otec,  " _
                & "'' as 'par/compl',  " _
                & "0 cod_curso_parcial, 0,0,0,0,0, " _
                & "0 cod_curso_compl, 0,0,0,0,0, " _
                & "ci.horas, " _
                & "0 horas_compl,  " _
                & "ci.ano 'a�o',  " _
                & "ci.inicio_curso fecha_inicio,  " _
                & "ci.fin_curso fecha_termino,  " _
                & "ci.horario horario_curso,  " _
                & "ci.direccion as direccion_curso,  " _
                & "ci.num_participantes num_alumnos,  " _
                & "ci.cod_estado_curso_interno cod_estado_curso,  " _
                & "ec.nombre estado_curso,  " _
                & "0 porc_franquicia, " _
                & "0 porc_asistencia,  " _
                & "case pi.COD_ESTADO_PART when 1 then 'APROBADO' when 2 then 'REPROBADO' else 'EN CURSO'  end estado_aprobacion,  " _
                & "'-' evaluacion, " _
                & " isnull((ci.valor_curso / nullif(ci.num_participantes,0)),0) valor_mercado, " _
                & "0 as 'costo_otic_curso',  " _
                & "0 as 'gasto_emp_curso', " _
                & "pi.viatico viatico_total, " _
                & "0 viatico_otic, " _
                & "pi.viatico viatico_ge, " _
                & "pi.traslado traslado_total, " _
                & "0 traslado_otic, " _
                & "pi.traslado traslado_ge,  " _
                & "0 as 'total_otic',  " _
                & "0 as 'total_empresa',  " _
                & "0 as 'total_alumno' " _
                        & "from participante_interno pi, persona_natural pn, curso_interno ci, " _
                        & "persona_juridica pj,persona pe, persona pe3, estado_curso_interno ec " _
                        & "where pi.rut=pn.rut " _
                        & "and pe.rut = pn.rut and pe3.rut = pn.rut " _
                        & "and ci.correlativo = pi.correlativo and pj.rut = ci.rut  " _
                        & "and  ci.inicio_curso >= [2] and ci.fin_curso <= [3] " _
                        & "and ci.cod_estado_curso_interno = 1 " _
                        & "and ci.rut in (select rut from empresa_cliente where cod_estado_cliente = 1) and ci.cod_estado_curso_interno = ec.cod_estado_curso_interno " _
                        & strWhereUnion
            If blnInterno And blnSence Then
                strQuery = strAlumnoSence & strUnion & strAlumnoInterno
                s_union_alumnos3 = ConsultaSql(SqlParam(strQuery, arrParam))
            ElseIf blnInterno Then
                strQuery = strAlumnoInterno
                s_union_alumnos3 = ConsultaSql(SqlParam(strQuery, arrParam))
            ElseIf blnSence Then
                strQuery = strAlumnoSence
                s_union_alumnos3 = ConsultaSql(SqlParam(strQuery, arrParam))
            End If
        End Function

        '        Public Function s_union_alumnos3(ByVal strRutClie As String, _
        '                                          ByVal lngRutAlumno As Long, _
        '                                          ByVal strNombreAlumno As String, _
        '                                          ByVal dtmFechaIni As Date, _
        '                                          ByVal dtmFechaFin As Date, _
        '                                          ByVal blnInterno As Boolean, _
        '                                          ByVal blnSence As Boolean, _
        '                                          ByVal intCorrelativo As Integer) As DataTable
        '            Dim strQuery As String, arrParam(7)
        '            Dim strAlumnoSence As String
        '            Dim strAlumnoInterno As String
        '            Dim strUnion As String
        '            strAlumnoSence = ""
        '            strAlumnoInterno = ""
        '            strUnion = " union "
        '            Dim strWhere, condicion As String
        '            strWhere = ""
        '            condicion = " And pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno "
        '            If lngRutAlumno > 0 Then
        '                strWhere = strWhere & " And p.Rut_alumno=[0] "
        '            End If
        '            If strNombreAlumno <> "" Then
        '                strWhere = strWhere & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [1] "
        '            End If

        '            If intCorrelativo > 0 Then
        '                strWhere = strWhere & " And cc.correlativo =[6] "
        '            End If

        '            Dim strWhereUnion As String
        '            strWhereUnion = ""
        '            If lngRutAlumno > 0 Then
        '                strWhereUnion = strWhereUnion & " And pi.rut In ([0]) "
        '            End If
        '            If strNombreAlumno <> "" Then
        '                strWhereUnion = strWhereUnion & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [1] "
        '            End If

        '            arrParam(0) = lngRutAlumno
        '            arrParam(1) = SubStringSql(strNombreAlumno)
        '            arrParam(2) = FechaVbABd(dtmFechaIni)
        '            arrParam(3) = FechaVbABd(dtmFechaFin)
        '            arrParam(4) = blnInterno
        '            arrParam(5) = blnSence
        '            arrParam(6) = intCorrelativo
        '            arrParam(7) = strRutClie
        '            strAlumnoSence = _
        '                        "Select row_number() over (order by rut_alumno ) as nFila, " _
        '& "'Sence' as tipo_alumno, " _
        '& "cast(p.rut_alumno as varchar) rut_alumno, " _
        '& "pe.dig_verif as dig_verif_alumno, " _
        '            & "(select count(rut_alumno) from participante where rut_alumno=p.rut_alumno and cod_curso in (select cod_curso from curso_contratado where Fecha_inicio >= [2] and Fecha_inicio <= [3] and rut_cliente In (cc.rut_cliente) and cod_estado_curso IN (1,3,4,5,6,7,9,11))) 'repeticiones'," _
        '& "isnull((pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno), '')nombre_completo, " _
        '& "pn.fecha_nacim, " _
        '& "pn.sexo, " _
        '& "ne.nombre as nivel_educacional, " _
        '& "no.nombre as nivel_ocupacional, " _
        '& "p.cod_region, " _
        '& "cast(cc.rut_cliente as varchar) rut_cliente, " _
        '& "pe3.dig_verif as dig_verif_cliente, " _
        '& "pj.razon_social, " _
        '& "cc.cod_curso , " _
        '& "cc.Correlativo, " _
        '& "cc.codigo_sence, " _
        '& "isnull(cc.correlativo_empresa,'') correlativo_empresa, " _
        '& "isnull(cc.nro_registro, 0) nro_registro, " _
        '& "ac.nombre as nombre_actividad, " _
        '& "cs.Nombre as nombre_curso, " _
        '& "cs.direccion as direccion_curso, " _
        '& "cs.rut_otec, " _
        '& "pe2.dig_verif as dig_verif_otec, " _
        '& "pj1.razon_social as nombre_otec, " _
        '& "cc.cod_modalidad, " _
        '& "cc.ind_acu_com_bip, " _
        '& "cc.ind_desc_porc, " _
        '& "cc.porc_adm, " _
        '& "cc.num_alumnos, " _
        '& "cc.horas, " _
        '& "cc.horas, " _
        '& "cc.horas_compl, " _
        '& "isnull(cc.cod_curso_compl,0) cod_curso_compl, " _
        '& "cc.agno, " _
        '& "cc.fecha_inicio, " _
        '& "cc.fecha_termino, " _
        '& "cc.cod_estado_curso, " _
        '& "(p.porc_franquicia*100) porc_franquicia, " _
        '& "(p.porc_asistencia*100) porc_asistencia, " _
        '& "(cc.valor_mercado / cc.num_alumnos) valor_mercado, " _
        '& "cc.Descuento, " _
        '& "cc.costo_otic, " _
        '& "cc.gasto_empresa, " _
        '& "0 gasto_otic, " _
        '& "0 gasto_emp, " _
        '& "p.viatico, " _
        '& "p.traslado,  " _
        '& "0 total " _
        '                        & "From Participante p, Persona_Natural pn, curso_contratado cc, Persona_Juridica pj1, " _
        '                        & "Persona_Juridica pj, Curso cs , Nivel_Educacional ne, Nivel_Ocupacional no,persona pe, " _
        '                        & "persona pe2, persona pe3, tipo_actividad ac " _
        '                        & "Where p.rut_alumno = pn.rut And p.cod_curso = cc.cod_curso and " _
        '                        & "pj.rut = cc.rut_cliente And " _
        '                        & "cs.codigo_sence=cc.codigo_sence and " _
        '                        & "ne.cod_nivel_educ = P.cod_nivel_educ And no.cod_nivel_ocup = P.cod_nivel_ocup " _
        '                        & "And pj1.rut=cs.rut_otec " & strWhere _
        '                        & "and cc.Fecha_inicio >= [2] and cc.Fecha_inicio <= [3] " _
        '                        & "and pe.rut = pn.rut and pe2.rut = pj1.rut and pe3.rut = pj.rut " _
        '                        & "and cc.rut_cliente in (select rut from empresa_cliente where cod_estado_cliente = 1) " _
        '                        & "and ac.cod_tipo_activ = cc.cod_tipo_activ " _
        '                        & "and cc.cod_estado_curso not in (2,8,10) "


        '            strAlumnoInterno = _
        '                         "select row_number() over (order by pi.rut ) as nFila, " _
        '& "'Interno' as tipo_alumno, " _
        '& "cast(pi.rut as varchar) rut_alumno, " _
        '& "pe.dig_verif as dig_verif_alumno, " _
        '& "'' 'repeticiones', " _
        '& "isnull((pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno), '')nombre_completo, " _
        '& "pn.fecha_nacim fecha_nacim, " _
        '& "pn.sexo,  " _
        '& "(select nombre from nivel_educacional where cod_nivel_educ=pn.cod_nivel_educ)nivel_educacional, " _
        '& "(select nombre from nivel_ocupacional where cod_nivel_ocup=pn.cod_nivel_ocup) nivel_ocupacional, " _
        '& "pn.cod_region, " _
        '& "cast(ci.rut as varchar) rut_cliente, " _
        '& "pe3.dig_verif as dig_verif_cliente, " _
        '& "pj.razon_social razon_social, " _
        '& "ci.correlativo cod_curso, " _
        '& "ci.correlativo correlativo, " _
        '& "0 codigo_sence, " _
        '& "ci.correlativo_empresa correlativo_empresa, " _
        '& "0 nro_registro, " _
        '& "'' nombre_actividad, " _
        '& "ci.nombre_curso nombre_curso, " _
        '& "ci.direccion as direccion_curso, " _
        '& "0 rut_otec, " _
        '& "'' dig_verif, " _
        '& "'' nombre_otec, " _
        '& "0 cod_modalidad, " _
        '& "0 ind_acu_com_bip, " _
        '& "0 ind_desc_porc, " _
        '& "0 porc_adm, " _
        '& "ci.num_participantes num_alumnos, " _
        '& "0 horas, " _
        '& "0 horas, " _
        '& "0 horas_compl, " _
        '& "0 cod_curso_compl, " _
        '& "ci.ano as agno, " _
        '& "ci.inicio_curso fecha_inicio, " _
        '& "ci.fin_curso fecha_termino, " _
        '& "ci.cod_estado_curso_interno cod_estado_curso, " _
        '& "0 porc_franquicia, " _
        '& "0 porc_asistencia, " _
        '& "0 valor_mercado, " _
        '& "0 Descuento, " _
        '& "0 costo_otic, " _
        '& "(ci.valor_curso / ci.num_participantes) gasto_empresa, " _
        '& "0 gasto_otic, " _
        '& "0 gasto_emp, " _
        '& "0 viatico, " _
        '& "0 traslado, " _
        '& "0 total " _
        '                        & "from participante_interno pi, persona_natural pn, curso_interno ci, " _
        '                        & "persona_juridica pj,persona pe, persona pe3 " _
        '                        & "where pi.rut=pn.rut " _
        '                        & "and pe.rut = pn.rut and pe3.rut = pn.rut " _
        '                        & "and ci.correlativo = pi.correlativo and pj.rut = ci.rut  " _
        '                        & "and  ci.inicio_curso >= [2] and ci.fin_curso <= [3] " _
        '                        & "and ci.cod_estado_curso_interno = 1 " _
        '                        & "and ci.rut in (select rut from empresa_cliente where cod_estado_cliente = 1) " _
        '                        & strWhereUnion
        '            If blnInterno And blnSence Then
        '                strQuery = strAlumnoSence & strUnion & strAlumnoInterno
        '                s_union_alumnos3 = ConsultaSql(SqlParam(strQuery, arrParam))
        '            ElseIf blnInterno Then
        '                strQuery = strAlumnoInterno
        '                s_union_alumnos3 = ConsultaSql(SqlParam(strQuery, arrParam))
        '            ElseIf blnSence Then
        '                strQuery = strAlumnoSence
        '                s_union_alumnos3 = ConsultaSql(SqlParam(strQuery, arrParam))
        '            End If
        '        End Function
        Public Function s_union_alumnos(ByVal strRutClie As String, _
                                         ByVal lngRutAlumno As Long, _
                                         ByVal strNombreAlumno As String, _
                                         ByVal dtmFechaIni As Date, _
                                         ByVal dtmFechaFin As Date, _
                                         ByVal blnInterno As Boolean, _
                                         ByVal blnSence As Boolean, _
                                         ByVal blnCurAnulados As Boolean, _
                                         ByVal blnCurEliminados As Boolean) As DataTable
            Dim strQuery As String, arrParam(6)

            Dim strEstados As String = "1,3,4,5,6,7,9,11"
            If blnCurAnulados Then
                strEstados = strEstados & ", 10"
            End If
            If blnCurEliminados Then
                strEstados = strEstados & ", 8"
            End If

            Dim strAlumnoSence As String
            Dim strAlumnoInterno As String
            Dim strUnion As String
            strAlumnoSence = ""
            strAlumnoInterno = ""
            strUnion = " union "
            Dim strWhere, condicion As String
            strWhere = ""
            condicion = " And pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno "
            If lngRutAlumno > 0 Then
                strWhere = strWhere & " And p.Rut_alumno=[1] "
            End If
            If strNombreAlumno <> "" Then
                strWhere = strWhere & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [2] "
            End If

            Dim strWhereUnion As String
            strWhereUnion = ""
            If lngRutAlumno > 0 Then
                strWhereUnion = strWhereUnion & " And pi.rut In ([1]) "
            End If
            If strNombreAlumno <> "" Then
                strWhereUnion = strWhereUnion & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [2] "
            End If

            arrParam(0) = strRutClie
            arrParam(1) = lngRutAlumno
            arrParam(2) = SubStringSql(strNombreAlumno)
            arrParam(3) = FechaVbABd(dtmFechaIni)
            arrParam(4) = FechaVbABd(dtmFechaFin)
            arrParam(5) = blnInterno
            arrParam(6) = blnSence
            strAlumnoSence = _
            "Select row_number() over (order by rut_alumno ) as nFila, " _
            & "'Sence' as tipo_alumno, " _
            & "cast(p.rut_alumno as varchar) rut_alumno,  " _
            & "pe.dig_verif as dig_verif_alumno,  " _
            & "(select count(rut_alumno) from participante where rut_alumno=p.rut_alumno and cod_curso " _
            & "in (select cod_curso from curso_contratado where Fecha_inicio >= [3] and Fecha_inicio <= [4] and rut_cliente " _
            & "In ([0]) and cod_estado_curso IN (" & strEstados & "))) 'repeticiones'," _
            & "isnull(pn.nombre,'') nombre ,  " _
            & "isnull(pn.ap_paterno ,'') apellido_paterno ,  " _
            & "isnull( pn.ap_materno ,'') apellido_materno,  " _
            & "pn.fecha_nacim, isnull(pn.sexo, 'M') sexo," _
            & "ne.nombre as nivel_educacional,  " _
            & "no.nombre as nivel_ocupacional,  " _
            & "p.cod_region,  " _
            & "cast(cc.rut_cliente as varchar) rut_cliente,  " _
            & "pe3.dig_verif as dig_verif_cliente, " _
            & "pj.razon_social,  " _
            & "cast((cc.porc_adm * 100) as float) porc_adm,  " _
            & "cc.cod_curso ,   " _
            & "cc.Correlativo,  " _
            & "cc.codigo_sence, " _
            & "isnull(cc.nro_registro, 0) nro_registro, " _
            & "isnull(cc.correlativo_empresa,'') correlativo_empresa,  " _
            & "cs.Nombre as nombre_curso,  " _
            & "mo.nombre modalidad,  " _
            & "ta.nombre tipo_actividad,  " _
            & "case isnull(cc.ind_acu_com_bip, 0) when 1 then 'SI' else 'NO' end comite_bipartito, " _
            & "case isnull(cc.flag_curso_cft, 0) when 1 then 'SI' else 'NO' end CFT, " _
            & "case isnull(cc.ind_det_nece, 0) when 1 then 'SI' else 'NO' end DNC, " _
            & "cs.rut_otec,  " _
            & "pe2.dig_verif as dig_verif_otec,  " _
            & "pj1.razon_social as nombre_otec, " _
            & "'' as 'par/compl',  " _
            & "isnull(cc.cod_curso_parcial,0) cod_curso_parcial, " _
            & "isnull((select correlativo from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) correlativo_parcial,  " _
            & "isnull((select horas from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) horas_parciales, " _
            & "cast(isnull(case isnull(cc.cod_curso_parcial,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_parcial)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_parcial and rut_alumno=p.rut_alumno)) end, 0) as numeric) costo_otic_parcial, " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_parcial) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) - isnull(case isnull(cc.cod_curso_parcial,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_parcial)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_parcial and rut_alumno=p.rut_alumno)) end, 0) as numeric) gasto_emp_parcial, " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_parcial) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_parcial), 0) as numeric) total_parcial, " _
            & "isnull(cc.cod_curso_compl,0) cod_curso_compl, " _
            & "isnull((select correlativo from curso_contratado where cod_curso=cc.cod_curso_compl), 0) correlativo_complemento,  " _
            & "isnull((select horas from curso_contratado where cod_curso=cc.cod_curso_compl), 0) horas_compl, " _
            & "cast(isnull(case isnull(cc.cod_curso_compl,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_compl)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_compl and rut_alumno=p.rut_alumno)) end, 0) as numeric) costo_otic_complemento, " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_compl) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_compl), 0) - isnull(case isnull(cc.cod_curso_compl,0) when 0 then 0 else ((cc.valor_hora * (select horas from curso_contratado where cod_curso=cc.cod_curso_compl)) * (select porc_franquicia from participante where cod_curso=cc.cod_curso_compl and rut_alumno=p.rut_alumno)) end, 0) as numeric) gasto_emp_complemento,  " _
            & "cast(isnull((select valor_mercado from curso_contratado where cod_curso=cc.cod_curso_compl) / (select num_alumnos from curso_contratado where cod_curso=cc.cod_curso_compl), 0) as numeric) total_complemento, " _
            & "cc.horas,  " _
            & "cc.horas_compl,  " _
            & "cc.valor_hora, " _
            & "cc.agno 'a�o',  " _
            & "cc.fecha_inicio,  " _
            & "cc.fecha_termino,  " _
            & "isnull((SELECT case hc.dia when 1 then ' LUN' when 2 then ' MAR' when 3 then ' MIE' when 4 then ' JUE' when 5 then ' VIE' when 6 then ' SAB' when 7 then ' DOM' end + ':' + hora_inicio + '-' + hora_fin FROM horario_curso hc WHERE hc.cod_curso = cc.cod_curso ORDER BY hc.dia FOR XML PATH('')),'') horario_curso, " _
            & " (cc.direccion_curso + ' ' + cc.Nro_direccion_curso) direccion_curso,  " _
            & "cc.num_alumnos,  " _
            & "cc.cod_estado_curso, " _
            & "ec.nombre estado_curso,  " _
            & "cast((p.porc_franquicia*100) as float) porc_franquicia,  " _
            & "cast((p.porc_asistencia*100) as float) porc_asistencia,  " _
            & "case when cc.cod_estado_curso in (1,3,4,7) then 'EN CURSO' when cc.cod_estado_curso in (5,9,11) and cast((p.porc_asistencia*100) as float) >= 75 then 'APROBADO' when cc.cod_estado_curso in (5,9,11) and cast((p.porc_asistencia*100) as float) < 75 then 'REPROBADO' else '-' end estado_aprobacion,  " _
            & "isnull(cast(p.nota_obtenida as varchar), '-') evaluacion, " _
            & " CAST((cc.valor_mercado / num_alumnos) AS NUMERIC) valor_mercado,  " _
            & "0 as 'costo_otic_curso', " _
            & "0 as 'gasto_emp_curso', " _
            & " CAST((p.porc_franquicia * p.viatico) +  (p.viatico - (p.porc_franquicia * p.viatico)) AS NUMERIC) viatico_total, " _
            & " CAST((p.porc_franquicia * p.viatico) AS NUMERIC) viatico_otic,  " _
            & " CAST((p.viatico - (p.porc_franquicia * p.viatico)) AS NUMERIC) viatico_ge,  " _
            & " CAST((p.porc_franquicia * p.traslado) +  (p.traslado - (p.porc_franquicia * p.traslado)) AS NUMERIC) traslado_total," _
            & " CAST((p.porc_franquicia * p.traslado) AS NUMERIC) traslado_otic,  " _
            & " CAST((p.traslado - (p.porc_franquicia * p.traslado)) AS NUMERIC) traslado_ge,  " _
            & "0 as 'total_otic',  " _
            & "0 as 'total_empresa',  " _
            & "0 as 'total_alumno'  " _
                    & "From Participante p, Persona_Natural pn, curso_contratado cc, Persona_Juridica pj1, " _
                    & "Persona_Juridica pj, Curso cs , Nivel_Educacional ne, Nivel_Ocupacional no, " _
                    & "persona pe, persona pe2, persona pe3, estado_curso ec , " _
                    & "modalidad mo, tipo_actividad ta Where p.rut_alumno = pn.rut " _
                    & "And p.cod_curso = cc.cod_curso And cc.rut_cliente In ([0]) " _
                    & "and pj.rut = cc.rut_cliente And cs.codigo_sence=cc.codigo_sence and " _
                    & "ne.cod_nivel_educ = P.cod_nivel_educ And no.cod_nivel_ocup = P.cod_nivel_ocup " _
                    & "And pj1.rut=cs.rut_otec " & strWhere _
                    & "and cc.Fecha_inicio >= [3] and cc.Fecha_inicio <= [4] " _
                    & "And cc.cod_estado_curso IN (" & strEstados & ") " _
                    & "and pe.rut = pn.rut and pe2.rut = pj1.rut and pe3.rut = pj.rut and cc.cod_estado_curso = ec.cod_estado_curso " _
                    & "and cc.cod_modalidad = mo.cod_modalidad and cc.cod_tipo_activ = ta.cod_tipo_activ "

            strAlumnoInterno = _
            "select row_number() over (order by pi.rut ) as nFila, " _
                & "'Interno' as tipo_alumno,  " _
                & "cast(pi.rut as varchar) rut_alumno, " _
                & "pe.dig_verif as dig_verif_alumno, " _
                & "'' 'repeticiones'," _
                & "isnull(pn.nombre,'') nombre , " _
                & "isnull(pn.ap_paterno ,'')apellido_paterno , " _
                & "isnull( pn.ap_materno ,'') apellido_materno,  " _
                & "pn.fecha_nacim fecha_nacim,  isnull(pn.sexo, 'M') sexo, " _
                & " (select nombre from nivel_educacional where cod_nivel_educ=pn.cod_nivel_educ)nivel_educacional,  " _
                & " (select nombre from nivel_ocupacional where cod_nivel_ocup=pn.cod_nivel_ocup) nivel_ocupacional,  " _
                & "pn.cod_region,  " _
                & "cast(ci.rut as varchar) rut_cliente,  " _
                & "pe3.dig_verif as dig_verif_cliente, " _
                & "pj.razon_social razon_social,  " _
                & "0 porc_adm,  " _
                & "0 cod_curso, " _
                & "ci.correlativo correlativo,  " _
                & "0 codigo_sence,  " _
                & "0 nro_registro,  " _
                & "isnull(ci.correlativo_empresa,'') correlativo_empresa, " _
                & "ci.nombre_curso nombre_curso,   " _
                & "'-' modalidad , " _
                & "'-' tipo_actividad ,  " _
                & "'-' comite_bipartito,  " _
                & "'-' CFT, " _
                & "'-' DNC, " _
                & "0 rut_otec, " _
                & "'-' dig_verif_otec,  " _
                & "ci.ejecutor as nombre_otec,  " _
                & "'' as 'par/compl',  " _
                & "0 cod_curso_parcial, 0,0,0,0,0, " _
                & "0 cod_curso_compl, 0,0,0,0,0, " _
                & "ci.horas, " _
                & "0 horas_compl,  " _
                & "0 valor_hora, " _
                & "ci.ano 'a�o',  " _
                & "ci.inicio_curso fecha_inicio,  " _
                & "ci.fin_curso fecha_termino,  " _
                & "ci.horario horario_curso,  " _
                & "ci.direccion as direccion_curso,  " _
                & "ci.num_participantes num_alumnos,  " _
                & "ci.cod_estado_curso_interno cod_estado_curso,  " _
                & "ec.nombre estado_curso,  " _
                & "0 porc_franquicia, " _
                & "0 porc_asistencia,  " _
                & "case pi.COD_ESTADO_PART when 1 then 'APROBADO' when 2 then 'REPROBADO' else 'EN CURSO'  end estado_aprobacion,  " _
                & "'-' evaluacion, " _
                & " isnull((ci.valor_curso / nullif(ci.num_participantes,0)),0) valor_mercado, " _
                & "0 as 'costo_otic_curso',  " _
                & "0 as 'gasto_emp_curso', " _
                & "pi.viatico viatico_total, " _
                & "0 viatico_otic, " _
                & "pi.viatico viatico_ge, " _
                & "pi.traslado traslado_total, " _
                & "0 traslado_otic, " _
                & "pi.traslado traslado_ge,  " _
                & "0 as 'total_otic',  " _
                & "0 as 'total_empresa',  " _
                & "0 as 'total_alumno' " _
                & "from participante_interno pi, persona_natural pn, curso_interno ci, " _
                & "persona_juridica pj,persona pe, persona pe3, estado_curso_interno ec " _
                & "where(pi.rut *= pn.rut) and ci.correlativo = pi.correlativo and ci.ano = pi.ano " _
                & "and pj.rut = ci.rut and pe.rut = pn.rut and pe3.rut = pn.rut " _
                & "and ci.rut in ([0]) and  ci.inicio_curso >= [3] and ci.inicio_curso <= [4] " _
                & "and ci.cod_estado_curso_interno = ec.cod_estado_curso_interno " _
                        & strWhereUnion
            If blnInterno And blnSence Then
                strQuery = strAlumnoSence & strUnion & strAlumnoInterno
                s_union_alumnos = ConsultaSql(SqlParam(strQuery, arrParam))
            ElseIf blnInterno Then
                strQuery = strAlumnoInterno
                s_union_alumnos = ConsultaSql(SqlParam(strQuery, arrParam))
            ElseIf blnSence Then
                strQuery = strAlumnoSence
                s_union_alumnos = ConsultaSql(SqlParam(strQuery, arrParam))
            End If
        End Function
        'Public Function s_union_alumnos(ByVal strRutClie As String, _
        '                                 ByVal lngRutAlumno As Long, _
        '                                 ByVal strNombreAlumno As String, _
        '                                 ByVal dtmFechaIni As Date, _
        '                                 ByVal dtmFechaFin As Date, _
        '                                 ByVal blnInterno As Boolean, _
        '                                 ByVal blnSence As Boolean) As DataTable
        '    Dim strQuery As String, arrParam(6)
        '    Dim strAlumnoSence As String
        '    Dim strAlumnoInterno As String
        '    Dim strUnion As String
        '    strAlumnoSence = ""
        '    strAlumnoInterno = ""
        '    strUnion = " union "
        '    Dim strWhere, condicion As String
        '    strWhere = ""
        '    condicion = " And pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno "
        '    If lngRutAlumno > 0 Then
        '        strWhere = strWhere & " And p.Rut_alumno=[1] "
        '    End If
        '    If strNombreAlumno <> "" Then
        '        strWhere = strWhere & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [2] "
        '    End If

        '    Dim strWhereUnion As String
        '    strWhereUnion = ""
        '    If lngRutAlumno > 0 Then
        '        strWhereUnion = strWhereUnion & " And pi.rut In ([1]) "
        '    End If
        '    If strNombreAlumno <> "" Then
        '        strWhereUnion = strWhereUnion & " And (pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno)  LIKE [2] "
        '    End If

        '    arrParam(0) = strRutClie
        '    arrParam(1) = lngRutAlumno
        '    arrParam(2) = fSubStringSql1(strNombreAlumno)
        '    arrParam(3) = FechaVbABd(dtmFechaIni)
        '    arrParam(4) = FechaVbABd(dtmFechaFin)
        '    arrParam(5) = blnInterno
        '    arrParam(6) = blnSence
        '    strAlumnoSence = _
        '    "Select row_number() over (order by rut_alumno ) as nFila, 'Sence' as tipo_alumno, p.rut_alumno,pe.dig_verif as dig_verif_alumno, pn.nombre as nombre_alumno, pn.ap_paterno, pn.ap_materno, " _
        '                & "pn.fecha_nacim, ne.nombre as nivel_educacional, (p.porc_franquicia*100) porc_franquicia, " _
        '                & "no.nombre as nivel_ocupacional, p.cod_region, p.viatico, p.traslado, (p.porc_asistencia*100) porc_asistencia, " _
        '                & "cc.cod_curso , pj.razon_social, cs.Nombre as nombre_curso, cc.Correlativo, cc.fecha_inicio, " _
        '                & "cc.fecha_termino, cc.rut_cliente, pe3.dig_verif as dig_verif_cliente, cc.codigo_sence, cc.cod_estado_curso, cc.costo_otic, cc.gasto_empresa, " _
        '                & "cc.valor_mercado, cc.Descuento, cc.porc_adm, " _
        '                & "cc.horas, cc.horas_compl, cc.ind_acu_com_bip, cc.ind_desc_porc, cc.num_alumnos, isnull((pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno), '')nombre_completo, " _
        '                & "isnull(cc.cod_curso_compl,0) cod_curso_compl, pj1.razon_social as nombre_otec, cs.rut_otec, pe2. dig_verif as dig_verif_otec, isnull(cc.correlativo_empresa,'') correlativo_empresa,cc.horas,isnull(cc.nro_registro, 0) nro_registro " _
        '                & "From Participante p, Persona_Natural pn, curso_contratado cc, Persona_Juridica pj1, " _
        '                & "Persona_Juridica pj, Curso cs , Nivel_Educacional ne, Nivel_Ocupacional no, persona pe, persona pe2, persona pe3 " _
        '                & "Where p.rut_alumno = pn.rut And p.cod_curso = cc.cod_curso And " _
        '                & "cc.rut_cliente In ([0]) and pj.rut = cc.rut_cliente And " _
        '                & "cs.codigo_sence=cc.codigo_sence and " _
        '                & "ne.cod_nivel_educ = P.cod_nivel_educ And no.cod_nivel_ocup = P.cod_nivel_ocup " _
        '                & "And pj1.rut=cs.rut_otec " & strWhere _
        '                & " and cc.Fecha_inicio >= [3] and cc.Fecha_inicio < [4] " _
        '                & " And cc.cod_estado_curso IN (1,3,4,5,6,7,9,11) " _
        '                & "and pe.rut = pn.rut and pe2.rut = pj1.rut and pe3.rut = pj.rut "

        '    strAlumnoInterno = _
        '    "select row_number() over (order by pi.rut ) as nFila, 'Interno' as tipo_alumno,pi.rut rut_alumno,pe.dig_verif as dig_verif_alumno, pn.nombre nombre_alumno, pn.ap_paterno ap_paterno, pn.ap_materno ap_materno, pn.fecha_nacim fecha_nacim, (select nombre from nivel_educacional where cod_nivel_educ=pn.cod_nivel_educ)nivel_educacional, " _
        '                & "0 porc_franquicia,(select nombre from nivel_ocupacional where cod_nivel_ocup=pn.cod_nivel_ocup) nivel_ocupacional,pn.cod_region,ci.valor_curso viatico,0 traslado,0 porc_asistencia,ci.cod_estado_curso_interno cod_curso, " _
        '                 & "pj.razon_social razon_social, ci.nombre_curso nombre_curso, ci.correlativo correlativo, ci.inicio_curso fecha_inicio, " _
        '                 & "ci.fin_curso fecha_termino, ci.rut rut_cliente, pe3.dig_verif as dig_verif_cliente, 0 codigo_sence, ci.cod_estado_curso_interno cod_estado_curso, " _
        '                 & "0 costo_otic,ci.valor_curso gasto_empresa,0 valor_mercado,0 Descuento,0 porc_adm,0 horas,0 horas_compl, 0 ind_acu_com_bip, " _
        '                 & "0 ind_desc_porc,ci.num_participantes num_alumnos, isnull((pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno), '')nombre_completo, " _
        '                & "0 cod_curso_compl, '' nombre_otec, 0 rut_otec,'' dig_verif,'' correlativo_empresa, 0 horas, 0 nro_registro " _
        '                & "from participante_interno pi, persona_natural pn, curso_interno ci, persona_juridica pj,persona pe, persona pe3 " _
        '                & "where(pi.rut *= pn.rut) " _
        '                & "and ci.correlativo = pi.correlativo " _
        '                & "and pj.rut = ci.rut " _
        '                & "and pe.rut = pn.rut " _
        '                & "and ci.rut in ([0]) " _
        '                & strWhereUnion
        '    If blnInterno And blnSence Then
        '        strQuery = strAlumnoSence & strUnion & strAlumnoInterno
        '        s_union_alumnos = ConsultaSql(SqlParam(strQuery, arrParam))
        '    ElseIf blnInterno Then
        '        strQuery = strAlumnoInterno
        '        s_union_alumnos = ConsultaSql(SqlParam(strQuery, arrParam))
        '    ElseIf blnSence Then
        '        strQuery = strAlumnoSence
        '        s_union_alumnos = ConsultaSql(SqlParam(strQuery, arrParam))
        '    End If
        'End Function
        'consulta de datos con criterios
        Public Function s_bitacora(ByVal lngRutUsuario As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                ByVal intTipoRef As Integer, ByVal lngCodRef As Long) As DataTable

            Dim strQuery As String, arrParam(4)
            arrParam(0) = lngRutUsuario
            arrParam(1) = FechaVbABd(dtmInicio)
            arrParam(2) = FechaVbABd(DateAdd(DateInterval.Day, 1, dtmFin))
            arrParam(3) = intTipoRef
            arrParam(4) = lngCodRef

            Dim strWhere As String
            strWhere = ""
            If lngRutUsuario <> 0 Then strWhere = " And b.rut_usuario = [0] "
            If intTipoRef >= 0 Then strWhere = " And b.cod_tipo_ref = [3] " & strWhere
            If lngCodRef >= 0 Then strWhere = " And b.cod_ref = [4] " & strWhere
            If Trim(dtmInicio) <> "" And Trim(dtmFin) <> "" Then
                strWhere = " And b.fecha_hora >= [1] and b.fecha_hora <= [2] " & strWhere
            End If

            strQuery = _
                "Select b.cod_bitacora, b.rut_usuario, u.nombres, " _
                & "b.fecha_hora, b.nombre_estado, b.obs, " _
                & "b.cod_tipo_ref , tr.Nombre, b.cod_ref " _
                & "From Bitacora b, Usuario u, Tipo_Referencia tr " _
                & "Where b.rut_usuario = u.rut " _
                & "And b.cod_tipo_ref = tr.cod_tipo_ref " _
                & strWhere _
                & "Order By fecha_hora, b.cod_bitacora Desc "
            s_bitacora = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_bitacora_comentario(ByVal lngCodRef As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodRef
            strQuery = _
            "Select us.nombres , bi.fecha_hora as fecha , bi.obs as glosa " _
            & "from bitacora bi, usuario us " _
            & "where us.rut = bi.rut_usuario and bi.cod_tipo_ref = 7 and bi.cod_ref = [0]"
            s_bitacora_comentario = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_creador_curso(ByVal lngCodCurso As Long) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso
            strQuery = _
            "Select u.nombres " _
                & "From Bitacora b, Usuario u, Tipo_Referencia tr " _
                & "Where b.rut_usuario = u.rut " _
                & "And b.cod_tipo_ref = tr.cod_tipo_ref " _
                & "And b.cod_ref = [0] " _
                & "and b.nombre_estado = 'ingresado' and b.cod_tipo_ref = 1 " _
                & "group by b.cod_bitacora, b.rut_usuario, u.nombres, " _
                & "b.fecha_hora, b.nombre_estado, b.obs, " _
                & "b.cod_tipo_ref , tr.Nombre, b.cod_ref " _
                & "having b.fecha_hora = (select min(b.fecha_hora) From Bitacora b, Usuario u, Tipo_Referencia tr " _
                & "Where b.rut_usuario = u.rut " _
                & "And b.cod_tipo_ref = tr.cod_tipo_ref " _
                & "And b.cod_ref = [0] " _
                & "and b.nombre_estado = 'ingresado' and b.cod_tipo_ref = 1) " _
                & "Order By fecha_hora, b.cod_bitacora Desc "

            s_creador_curso = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        '        Public Function s_cursos_consolidado2(ByVal strRutClientes As String, _
        '                                       ByVal strEstados As String, _
        '                                       ByVal dtmFechaIni As Date, _
        '                                       ByVal dtmFechaFin As Date, _
        '                                       ByVal blnCurInterno As Boolean, _
        '                                       ByVal blnCurSence As Boolean, _
        '                                       ByVal blnCurAnulados As Boolean, _
        '                                       ByVal blnCurEliminados As Boolean) As DataTable
        '            Dim strQuery As String, arrParam(5)
        '            If blnCurAnulados Then
        '                strEstados = strEstados & ", 10"
        '            End If
        '            If blnCurEliminados Then
        '                strEstados = strEstados & ", 8"
        '            End If
        '            arrParam(0) = strRutClientes
        '            arrParam(1) = strEstados
        '            arrParam(2) = FechaVbABd(dtmFechaIni)
        '            arrParam(3) = FechaVbABd(dtmFechaFin)
        '            arrParam(4) = blnCurInterno
        '            arrParam(5) = blnCurSence
        '            Dim strWhereUnion As String
        '            strWhereUnion = ""
        '            If strRutClientes <> "" Then strWhereUnion = " And ci.rut In ([0]) "
        '            Dim strWhere As String
        '            strWhere = ""
        '            If strRutClientes <> "" Then strWhere = " And cc.rut_cliente In ([0]) "
        '            If strEstados <> "" Then strWhere = " And cc.cod_estado_curso IN ([1]) " & strWhere
        '            Dim strCursoSence As String
        '            Dim strCursoInterno As String
        '            Dim strUnion As String
        '            strCursoSence = ""
        '            strCursoInterno = ""
        '            strUnion = " union "

        '            strCursoSence = _
        '            "Select row_number() over (order by cc.correlativo) as nFila, " _
        '& "'Sence' as tipo_curso, " _
        '& "cc.cod_curso, " _
        '& "cast(isnull(cc.correlativo,0) as varchar) correlativo, " _
        '& "isnull(cc.nro_registro, 0) nro_registro, " _
        '& "isnull(cc.correlativo_empresa,'0') correlativo_empresa, " _
        '& "cc.codigo_sence, " _
        '& "cs.nombre as nombre_curso, " _
        '& "isnull(cs.area,'') area, " _
        '& "isnull(cs.especialidad,'') especialidad, " _
        '& "mo.nombre modalidad, " _
        '& "ta.nombre tipo_actividad, " _
        '& "isnull((select case cc.ind_acu_com_bip when 1 then 'SI' else 'NO' end ORDER BY cc.ind_acu_com_bip FOR XML PATH('')),0) comite_bipartito, " _
        '& "isnull((select case cc.flag_curso_cft when 1 then 'si' else 'no' end ORDER BY cc.flag_curso_cft FOR XML PATH('')),0) curso_cft, " _
        '& "(cc.direccion_curso + ' ' + cc.Nro_direccion_curso) direccion_curso, " _
        '& "otec.rut as rut_otec, " _
        '& "pe.dig_verif as dig_verif_otec, " _
        '& "otec.razon_social as razon_social_otec, " _
        '& "cc.rut_cliente, " _
        '& "pe2.dig_verif as dig_verif_cliente, " _
        '& "pj.razon_social, " _
        '& "(cc.porc_adm*100) porcentaje_adm, " _
        '& "isnull((SELECT case hc.dia when 1 then ' LUN' when 2 then ' MAR' when 3 then ' MIE' when 4 then ' JUE' when 5 then ' VIE' when 6 then ' SAB' when 7 then ' DOM' end + ':' + hora_inicio + '-' + hora_fin FROM horario_curso hc WHERE hc.cod_curso = cc.cod_curso ORDER BY hc.dia FOR XML PATH('')),'') horario_curso, " _
        '& "cc.agno 'a�o' , " _
        '& "cc.fecha_inicio, " _
        '& "cc.fecha_termino, " _
        '& "isnull(cc.cod_curso_compl,0) cod_curso_compl, " _
        '& "isnull(cc.cod_curso_parcial,0) cod_curso_parcial, " _
        '& "cc.horas_compl as horas_complementarias, " _
        '& "cc.cod_estado_curso, " _
        '& "ec.nombre as estado_curso, " _
        '& "(cc.horas-cc.horas_compl) as horas, " _
        '& "num_alumnos as numero_alumnos, " _
        '& "((cc.horas-cc.horas_compl) * num_alumnos) as HH, " _
        '& "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante where cod_curso=cc.cod_curso and porc_asistencia > 0))as hh_con_asistencia_mayor_a_cero, " _
        '& "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante where cod_curso=cc.cod_curso and porc_asistencia >= 0.75))as hh_con_asistencia_mayor_igual_75, " _
        '& "(select count(*) from participante p where p.cod_curso = cc.cod_curso And porc_asistencia >= 0.75) participantes_aprobado_por_asistencia, " _
        '& "cc.valor_mercado, " _
        '& "(select sum((cco.valor_hora * cco.horas) * pa.porc_franquicia) from participante pa, curso_contratado cco " _
        '& "where pa.cod_curso=cco.cod_curso and cco.cod_curso = cc.cod_curso) costo_otic_comunicado, " _
        '& "cc.costo_otic, " _
        '& "cc.costo_adm, " _
        '& "cc.gasto_empresa, " _
        '& "(cc.total_viatico + cc.total_traslado) total_vyt, " _
        '& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And(cod_cuenta = 1 Or cod_cuenta = 4) And cod_tipo_tran=5 And rut_cliente = cc.rut_cliente),0) as costo_otic_vyt, " _
        '& "(cc.gasto_empresa_vyt) total_gasto_empresa_vyt, " _
        '& "cc.total_viatico, " _
        '& "(select sum(viatico) from participante where cod_curso = cc.cod_curso) costo_otic_viatico, " _
        '& "cc.total_viatico - (select sum(viatico) from participante where cod_curso = cc.cod_curso) gasto_emp_viatico, " _
        '& "cc.total_traslado, " _
        '& "(select sum(traslado) from participante where cod_curso = cc.cod_curso) costo_otic_traslado, " _
        '& "cc.total_traslado - (select sum(traslado) from participante where cod_curso = cc.cod_curso) gasto_emp_traslado, " _
        '& "" _
        '& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 1 ),0) as cuenta_capacitacion, " _
        '& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 4 ),0) as cuenta_exc_capacitacion, " _
        '& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 2 ),0) as cuenta_reparto, " _
        '& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 5 ),0) as cuenta_exc_reparto, " _
        '& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 3 And rut_cliente = cc.rut_cliente ),0) as cuenta_adm, " _
        '& "isnull((Select Sum(convert(numeric, monto)) From Transaccion  Where cod_curso = cc.cod_curso And cod_cuenta = 6 And rut_cliente = cc.rut_cliente),0) as cuenta_becas, " _
        '& "isnull(f.num_factura,0) as numero_factura, " _
        '& "isnull(f.monto,0) as monto_factura,  " _
        '& "isnull((select nombre from estado_factura where cod_estado_fact = f.cod_estado_fact),'S/F') as estado_factura, " _
        '& "isnull(f.num_voucher,0) num_voucher, " _
        '& "Origen.nombre " _
        '                & "From Curso_Contratado cc, Curso cs, Estado_Curso ec, Persona_Juridica pj, Persona_Juridica otec, " _
        '                & "Origen,factura f, persona pe, persona pe2, modalidad mo,tipo_actividad ta " _
        '                & "Where cc.fecha_inicio >= [2] and cc.fecha_termino <= [3] And cc.cod_curso*=f.cod_curso And cc.cod_estado_curso = ec.cod_estado_curso " _
        '                & "And cc.codigo_sence = cs.codigo_sence And cs.rut_otec = otec.rut And cc.rut_cliente = pj.rut And cc.cod_origen = Origen.cod_origen " _
        '                & " and pe.rut=otec.rut and pe2.rut=pj.rut and mo.cod_modalidad = cc.cod_modalidad and cc.cod_tipo_activ = ta.cod_tipo_activ  " _
        '                & strWhere
        '            strCursoInterno = _
        '             "select row_number() over (order by ci.correlativo) as nFila, " _
        '                    & "'Interno' as tipo_curso, " _
        '                    & "ci.correlativo cod_curso, " _
        '                    & "ci.correlativo, " _
        '                    & "0 nro_registro, " _
        '                    & "ci.correlativo_empresa, " _
        '                    & "0 codigo_sence, " _
        '                    & "ci.nombre_curso nombre_curso, " _
        '                    & "'S/F' area, " _
        '                    & "'S/F' especialidad, " _
        '                    & "'-' modalidad, " _
        '                    & "'-' tipo_actividad, " _
        '                    & "'NO' comite_bipartito, " _
        '                    & "'No' curso_cft, " _
        '                    & "ci.direccion as direccion_curso, " _
        '                    & "0 rut_otec, " _
        '                    & "'' dig_verif_otec, " _
        '                    & "ci.ejecutor as razon_social_otec, " _
        '                    & "ci.rut rut_cliente, " _
        '                    & "pe.dig_verif as dig_verif_cliente, " _
        '                    & "pj.razon_social razon_social, " _
        '                    & "0 porcentaje_adm, " _
        '                    & "ci.horario horario_curso, " _
        '                    & "ci.ano 'a�o', " _
        '                    & "ci.inicio_curso fecha_inicio, " _
        '                    & "ci.fin_curso fecha_termino, " _
        '                    & "0 cod_curso_compl, " _
        '                    & "0 cod_curso_parcial, " _
        '                    & "0 horas_complementarias, " _
        '                    & "ci.cod_estado_curso_interno cod_estado_curso, " _
        '                    & "e.nombre estado_curso, " _
        '                    & "ci.horas, " _
        '                    & "ci.num_participantes numero_alumnos,  " _
        '                    & "(ci.horas * ci.num_participantes) as hh, " _
        '                    & "0 hh_con_asistencia_mayor_a_cero, " _
        '                    & "0 hh_con_asistencia_mayor_igual_75, " _
        '                    & "0 participantes_aprobado_por_asistencia, " _
        '                    & "ci.valor_curso as valor_mercado, " _
        '                    & "0 costo_otic, " _
        '                    & "0 costo_otic_comunicado, " _
        '                    & "0 costo_adm, " _
        '                    & "0 gasto_empresa, " _
        '                    & "(ci.total_viatico + ci.total_traslado) total_vyt, " _
        '                    & "0 costo_otic_vyt,   " _
        '                    & "0 total_gasto_empresa_vyt, " _
        '                    & "ci.total_viatico, " _
        '                    & "0 costo_otic_viatico, " _
        '                    & "0 gasto_emp_viatico, " _
        '                    & "ci.total_traslado, " _
        '                    & "0 costo_otic_traslado, " _
        '                    & "0 gasto_emp_traslado, " _
        '                    & "" _
        '                    & "0 cuenta_capacitacion, " _
        '                    & "0 cuenta_exc_capacitacion, " _
        '                    & "0 cuenta_reparto, " _
        '                    & "0 cuenta_exc_reparto, " _
        '                    & "0 cuenta_adm, " _
        '                    & "0 cuenta_becas, " _
        '                    & "0 numero_factura, " _
        '                    & "0 monto_factura, " _
        '                    & "'S/F' estado_factura, " _
        '                    & "0 num_voucher, " _
        '                    & "'' nombre " _
        '                & "from curso_interno ci, estado_curso_interno e, persona_juridica pj, persona pe " _
        '                & "where ci.rut *= pj.rut and ci.cod_estado_curso_interno in (1,2,3) " _
        '                & "And ci.cod_estado_curso_interno = e.cod_estado_curso_interno " _
        '                & "and ci.inicio_curso >= [2] and ci.inicio_curso <= [3] and pe.rut = pj.rut " _
        '                & strWhereUnion
        '            If blnCurInterno And blnCurSence Then
        '                strQuery = strCursoSence & strUnion & strCursoInterno
        '                s_cursos_consolidado2 = ConsultaSql(SqlParam(strQuery, arrParam))
        '            ElseIf blnCurInterno Then
        '                strQuery = strCursoInterno
        '                s_cursos_consolidado2 = ConsultaSql(SqlParam(strQuery, arrParam))
        '            ElseIf blnCurSence Then
        '                strQuery = strCursoSence
        '                s_cursos_consolidado2 = ConsultaSql(SqlParam(strQuery, arrParam))
        '            End If
        '        End Function
        Public Function s_cursos_consolidado2(ByVal strRutClientes As String, _
                                               ByVal strEstados As String, _
                                               ByVal dtmFechaIni As Date, _
                                               ByVal dtmFechaFin As Date, _
                                               ByVal blnCurInterno As Boolean, _
                                               ByVal blnCurSence As Boolean, _
                                               ByVal blnCurAnulados As Boolean, _
                                               ByVal blnCurEliminados As Boolean) As DataTable
            Dim strQuery As String, arrParam(5)
            If blnCurAnulados Then
                strEstados = strEstados & ", 10"
            End If
            If blnCurEliminados Then
                strEstados = strEstados & ", 8"
            End If
            arrParam(0) = strRutClientes
            arrParam(1) = strEstados
            arrParam(2) = FechaVbABd(dtmFechaIni)
            arrParam(3) = FechaVbABd(dtmFechaFin)
            arrParam(4) = blnCurInterno
            arrParam(5) = blnCurSence
            Dim strWhereUnion As String
            strWhereUnion = ""
            If strRutClientes <> "" Then strWhereUnion = " And ci.rut In ([0]) "
            Dim strWhere As String
            strWhere = ""
            If strRutClientes <> "" Then strWhere = " And cc.rut_cliente In ([0]) "
            If strEstados <> "" Then strWhere = " And cc.cod_estado_curso IN ([1]) " & strWhere
            Dim strCursoSence As String
            Dim strCursoInterno As String
            Dim strUnion As String
            strCursoSence = ""
            strCursoInterno = ""
            strUnion = " union "

            strCursoSence = _
            "Select row_number() over (order by cc.correlativo) as nFila, " _
& "'Sence' as tipo_curso, " _
& "cc.cod_curso, " _
& "cast(isnull(cc.correlativo,0) as varchar) correlativo, " _
& "isnull(cc.nro_registro, 0) nro_registro, " _
& "isnull(cc.correlativo_empresa,'0') correlativo_empresa, " _
& "cc.codigo_sence, " _
& "cs.nombre as nombre_curso, " _
& "isnull(cs.area,'') area, " _
& "isnull(cs.especialidad,'') especialidad, " _
& "mo.nombre modalidad, " _
& "ta.nombre tipo_actividad, " _
& "isnull((select case cc.ind_acu_com_bip when 1 then 'SI' else 'NO' end ORDER BY cc.ind_acu_com_bip FOR XML PATH('')),0) comite_bipartito, " _
& "isnull((select case cc.flag_curso_cft when 1 then 'si' else 'no' end ORDER BY cc.flag_curso_cft FOR XML PATH('')),0) curso_cft, " _
& "(cc.direccion_curso + ' ' + cc.Nro_direccion_curso) direccion_curso, co.nombre as comuna, isnull(cc.Ciudad,'') ciudad, " _
& "otec.rut as rut_otec, " _
& "pe.dig_verif as dig_verif_otec, " _
& "otec.razon_social as razon_social_otec, " _
& "cc.rut_cliente, " _
& "pe2.dig_verif as dig_verif_cliente, " _
& "pj.razon_social, " _
& "(cc.porc_adm*100) porcentaje_adm, " _
& "isnull((SELECT case hc.dia when 1 then ' LUN' when 2 then ' MAR' when 3 then ' MIE' when 4 then ' JUE' when 5 then ' VIE' when 6 then ' SAB' when 7 then ' DOM' end + ':' + hora_inicio + '-' + hora_fin FROM horario_curso hc WHERE hc.cod_curso = cc.cod_curso ORDER BY hc.dia FOR XML PATH('')),'') horario_curso, " _
& "cc.agno 'a�o' , " _
& "cc.fecha_inicio, " _
& "cc.fecha_termino, " _
& "isnull(cc.cod_curso_compl,0) cod_curso_compl, " _
& "isnull(cc.cod_curso_parcial,0) cod_curso_parcial, " _
& "cc.horas_compl as horas_complementarias, " _
& "cc.cod_estado_curso, " _
& "ec.nombre as estado_curso, " _
& "(cc.horas-cc.horas_compl) as horas, " _
& "num_alumnos as numero_alumnos, " _
& "((cc.horas-cc.horas_compl) * num_alumnos) as HH, " _
& "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante where cod_curso=cc.cod_curso and porc_asistencia > 0))as hh_con_asistencia_mayor_a_cero, " _
& "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante where cod_curso=cc.cod_curso and porc_asistencia >= 0.75))as hh_con_asistencia_mayor_igual_75, " _
& "(select count(*) from participante p where p.cod_curso = cc.cod_curso And porc_asistencia >= 0.75) participantes_aprobado_por_asistencia, " _
& "cc.valor_mercado, " _
& "" _
& "cc.costo_otic, " _
& "cc.costo_adm, " _
& "cc.gasto_empresa, " _
& "(cc.total_viatico + cc.total_traslado) total_vyt, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And(cod_cuenta = 1 Or cod_cuenta = 4) And cod_tipo_tran=5 And rut_cliente = cc.rut_cliente),0) as costo_otic_vyt, " _
& "(cc.gasto_empresa_vyt) total_gasto_empresa_vyt, " _
& "cc.total_viatico, " _
& "CAST((select sum(viatico * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) costo_otic_viatico, " _
& "CAST(cc.total_viatico - (select sum(viatico * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) gasto_emp_viatico, " _
& "cc.total_traslado, " _
& "CAST((select sum(traslado * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) costo_otic_traslado, " _
& "CAST(cc.total_traslado - (select sum(traslado * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) gasto_emp_traslado, " _
& "" _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 1 ),0) as cuenta_capacitacion, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 4 ),0) as cuenta_exc_capacitacion, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 2 ),0) as cuenta_reparto, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 5 ),0) as cuenta_exc_reparto, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 3 And rut_cliente = cc.rut_cliente ),0) as cuenta_adm, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion  Where cod_curso = cc.cod_curso And cod_cuenta = 6 And rut_cliente = cc.rut_cliente),0) as cuenta_becas, " _
& "isnull(f.num_factura,0) as numero_factura, " _
& "isnull(f.monto,0) as monto_factura,  " _
& "isnull((select nombre from estado_factura where cod_estado_fact = f.cod_estado_fact),'S/F') as estado_factura, " _
& "isnull(f.num_voucher,0) num_voucher, " _
& "Origen.nombre " _
                & "From Curso_Contratado cc, Curso cs, Estado_Curso ec, Persona_Juridica pj, Persona_Juridica otec, " _
                & "Origen,factura f, persona pe, persona pe2, modalidad mo,tipo_actividad ta, comuna co " _
                & "Where cc.fecha_inicio >= [2] and cc.fecha_termino <= [3] And cc.cod_curso*=f.cod_curso And cc.cod_estado_curso = ec.cod_estado_curso " _
                & "And cc.codigo_sence = cs.codigo_sence And cs.rut_otec = otec.rut And cc.rut_cliente = pj.rut And cc.cod_origen = Origen.cod_origen " _
                & " and pe.rut=otec.rut and pe2.rut=pj.rut and mo.cod_modalidad = cc.cod_modalidad and cc.cod_tipo_activ = ta.cod_tipo_activ and co.cod_comuna = cc.cod_comuna  " _
                & strWhere
            strCursoInterno = _
             "select row_number() over (order by ci.correlativo) as nFila, " _
                    & "'Interno' as tipo_curso, " _
                    & "ci.correlativo cod_curso, " _
                    & "ci.correlativo, " _
                    & "0 nro_registro, " _
                    & "ci.correlativo_empresa, " _
                    & "0 codigo_sence, " _
                    & "ci.nombre_curso nombre_curso, " _
                    & "'S/F' area, " _
                    & "'S/F' especialidad, " _
                    & "'-' modalidad, " _
                    & "'-' tipo_actividad, " _
                    & "'NO' comite_bipartito, " _
                    & "'No' curso_cft, " _
                    & "ci.direccion as direccion_curso, co.nombre as comuna, '' ciudad, " _
                    & "0 rut_otec, " _
                    & "'' dig_verif_otec, " _
                    & "ci.ejecutor as razon_social_otec, " _
                    & "ci.rut rut_cliente, " _
                    & "pe.dig_verif as dig_verif_cliente, " _
                    & "pj.razon_social razon_social, " _
                    & "0 porcentaje_adm, " _
                    & "ci.horario horario_curso, " _
                    & "ci.ano 'a�o', " _
                    & "ci.inicio_curso fecha_inicio, " _
                    & "ci.fin_curso fecha_termino, " _
                    & "0 cod_curso_compl, " _
                    & "0 cod_curso_parcial, " _
                    & "0 horas_complementarias, " _
                    & "ci.cod_estado_curso_interno cod_estado_curso, " _
                    & "e.nombre estado_curso, " _
                    & "ci.horas, " _
                    & "ci.num_participantes numero_alumnos,  " _
                    & "(ci.horas * ci.num_participantes) as hh, " _
                    & "0 hh_con_asistencia_mayor_a_cero, " _
                    & "0 hh_con_asistencia_mayor_igual_75, " _
                    & "0 participantes_aprobado_por_asistencia, " _
                    & "ci.valor_curso as valor_mercado, " _
                    & "0 costo_otic, " _
                    & "" _
                    & "0 costo_adm, " _
                    & "0 gasto_empresa, " _
                    & "(ci.total_viatico + ci.total_traslado) total_vyt, " _
                    & "0 costo_otic_vyt,   " _
                    & "0 total_gasto_empresa_vyt, " _
                    & "ci.total_viatico, " _
                    & "0 costo_otic_viatico, " _
                    & "0 gasto_emp_viatico, " _
                    & "ci.total_traslado, " _
                    & "0 costo_otic_traslado, " _
                    & "0 gasto_emp_traslado, " _
                    & "" _
                    & "0 cuenta_capacitacion, " _
                    & "0 cuenta_exc_capacitacion, " _
                    & "0 cuenta_reparto, " _
                    & "0 cuenta_exc_reparto, " _
                    & "0 cuenta_adm, " _
                    & "0 cuenta_becas, " _
                    & "0 numero_factura, " _
                    & "0 monto_factura, " _
                    & "'S/F' estado_factura, " _
                    & "0 num_voucher, " _
                    & "'' nombre " _
                & "from curso_interno ci, estado_curso_interno e, persona_juridica pj, persona pe, comuna co " _
                & "where ci.rut *= pj.rut and ci.cod_estado_curso_interno in (1,2,3) " _
                & "And ci.cod_estado_curso_interno = e.cod_estado_curso_interno " _
                & "and ci.inicio_curso >= [2] and ci.inicio_curso <= [3] and pe.rut = pj.rut and co.cod_comuna = ci.cod_comuna " _
                & strWhereUnion

            '& "(select sum((cco.valor_hora * cco.horas) * pa.porc_franquicia) from participante pa, curso_contratado cco " _
            '& "where pa.cod_curso=cco.cod_curso and cco.cod_curso = cc.cod_curso) costo_otic_comunicado, " _


            If blnCurInterno And blnCurSence Then
                strQuery = strCursoSence & strUnion & strCursoInterno
                s_cursos_consolidado2 = ConsultaSql(SqlParam(strQuery, arrParam))
            ElseIf blnCurInterno Then
                strQuery = strCursoInterno
                s_cursos_consolidado2 = ConsultaSql(SqlParam(strQuery, arrParam))
            ElseIf blnCurSence Then
                strQuery = strCursoSence
                s_cursos_consolidado2 = ConsultaSql(SqlParam(strQuery, arrParam))
            End If
        End Function


        'Cuenta los alumnos participantes de un curso interno.

        Public Function s_nro_participantes_interno(ByVal lngCodCurso As Long, _
                                                    ByVal intAgno As Integer) As Long

            Dim auxiliar() As Object
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = intAgno

            strQuery = _
                    "Select count(rut) " _
                    & "From Participante_interno " _
                    & "Where correlativo = [0] " _
                    & " and ano = [1]"

            s_nro_participantes_interno = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'retorna el correlativo de un curso interno maximo para un a�o
        Public Function s_correlativo_curso_interno_max_ano(ByVal intAgno) As Long
            Dim strQuery As String


            'strQuery = "Select * from cursointerno"
            strQuery = "Select isnull(max(correlativo),0) from curso_interno where ano = " & intAgno

            s_correlativo_curso_interno_max_ano = ValorSql(strQuery)

        End Function
        'retorna el correlativo de un curso interno maximo para un a�o
        Public Function s_correlativo_curso_interno_max_ano2(ByVal intAgno) As DataTable
            Dim strQuery As String


            'strQuery = "Select * from cursointerno"
            strQuery = "Select isnull(max(correlativo),0) from curso_interno where ano = " & intAgno

            s_correlativo_curso_interno_max_ano2 = ConsultaSql(strQuery)

        End Function
        'Public Function s_curso_interno(ByVal lngCodCurso As Long, _
        '                        ByVal intAgno As Integer) As Object

        '    Dim strQuery As String, arrParam(1)
        '    arrParam(0) = lngCodCurso
        '    arrParam(1) = intAgno

        '    strQuery = _
        '            "Select rut as rut_cliente, " _
        '            & "direccion, cod_comuna, " _
        '            & "inicio_curso as fecha_inicio, fin_curso as fecha_termino, valor_curso, " _
        '            & "descuento, correlativo, cod_estado_curso_interno, " _
        '            & "ano, tipo_descuento_porcentaje, correlativo_empresa, isnull(observacion,''), " _
        '            & "nombre_curso, ejecutor, horario,isnull(horas_curso,0) as horas, num_participantes " _
        '            & "From Curso_Interno " _
        '            & "Where correlativo = [0] " _
        '            & "And ano = [1] "

        '    s_curso_interno = ConsultaSql(SqlParam(strQuery, arrParam))

        'End Function
        Public Function s_curso_interno(ByVal lngCodCurso As Long, _
                               ByVal intAgno As Integer) As Object

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = intAgno

            strQuery = _
                    "Select rut as rut_cliente, " _
                    & "direccion, cod_comuna, " _
                    & "inicio_curso as fecha_inicio, fin_curso as fecha_termino, valor_curso, " _
                    & "descuento, correlativo, cod_estado_curso_interno, " _
                    & "ano, tipo_descuento_porcentaje, correlativo_empresa, isnull(observacion,''), " _
                    & "nombre_curso, ejecutor, horario,isnull(horas,0) as horas, num_participantes " _
                    & "From Curso_Interno " _
                    & "Where correlativo = [0] " _
                    & "And ano = [1] "

            s_curso_interno = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_perfil_objeto(ByVal intCodPerfil As Integer, ByVal strNombrePerfil As String, _
                                          ByVal intCodObjeto As Integer, ByVal strNombreObjeto As String) As DataTable
            Dim strQuery As String, arrParam(3)
            arrParam(0) = intCodPerfil
            arrParam(1) = StringSql(strNombrePerfil)
            arrParam(2) = intCodObjeto
            arrParam(3) = StringSql(strNombreObjeto)
            strQuery = _
                "Select po.cod_perfil, po.cod_objeto, " _
                & "ob.Nombre as nombre_objeto , p.Nombre as nombre_perfil" _
                & " From Perfil_Objeto po, Objeto ob, Perfil p " _
                & "Where (po.cod_perfil = [0] Or [0] = 0) " _
                & "And (po.cod_objeto = [2] Or [2] = 0) " _
                & "And (p.nombre like [1] Or [1] = '') " _
                & "And (ob.nombre like [3] Or [3] = '') " _
                & "And ob.cod_objeto = po.cod_objeto " _
                & "And p.cod_perfil = po.cod_perfil "
            s_perfil_objeto = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_perfil_m(ByVal intCodPerfil As Integer, ByVal strNombrePerfil As String) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodPerfil
            arrParam(1) = StringSql(strNombrePerfil)
            strQuery = _
                "Select p.cod_perfil, p.nombre  " _
                & " From Perfil p " _
                & "Where (p.cod_perfil = [0] Or [0] = 0) " _
                & "And (p.nombre like [1] Or [1] = '') "
            s_perfil_m = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_objeto_m(ByVal intCodObjeto As Integer, ByVal strNombreObjeto As String) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodObjeto
            arrParam(1) = SubStringSql(strNombreObjeto)

            strQuery = _
                          "Select o.cod_objeto, o.nombre   " _
                          & " From Objeto o " _
                          & " Where(o.cod_objeto =[0]  Or [0] = 0 ) " _
                          & " and (o.nombre like [1] Or o.nombre = [1]) "

            'Dim strWhere As String

            'If (StringSql(strNombreObjeto) <> "") Then
            '    strWhere = "(o.nombre like [1] Or o.nombre = [1])"
            'Else
            '    strWhere = "(o.cod_objeto =[0]  Or o.cod_objeto > [0])"
            'End If
            'strQuery = _
            '      "Select o.cod_objeto, o.nombre  From Objeto o " _
            '      & " Where  " & strWhere

            s_objeto_m = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        ' Consulta de todos los registros de Usuario
        Public Function s_usuario_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select rut, nombres, passwd_enc, email , conectado, telefono, fax " _
                & "From Usuario " _
                & "Order By nombres"
            s_usuario_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_supervisor(ByVal mlnrut As Long) As DataTable
            Dim strQuery As String
            Dim arrParam(0)
            arrParam(0) = mlnrut
            strQuery = _
            "select rut_supervisor " _
            & "from supervisor " _
            & "where rut_supervisor = [0]"
            s_supervisor = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_usuario(ByVal mlnrut As Long) As DataTable
            Dim strQuery As String
            Dim arrParam(0)
            arrParam(0) = mlnrut
            strQuery = _
            "select rut, nombres, passwd_enc, email, conectado, telefono, fax " _
            & "from usuario " _
            & "where rut = [0]"
            s_usuario = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'maximo correlativo de un a�o
        Public Function s_certificado_aporte_max_correl(ByVal intAgno As Integer) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAgno

            strQuery = _
                "Select Max(correlativo) " _
                & "From Certificado_Aporte " _
                & "Where agno = [0] "
            Dim vntCorrel As Object
            vntCorrel = ValorSql(SqlParam(strQuery, arrParam))
            If IsNumeric(vntCorrel) Then
                s_certificado_aporte_max_correl = CLng(vntCorrel)
            Else
                s_certificado_aporte_max_correl = 0
            End If
        End Function
        'busca si existe registro 
        Public Function s_existe_Certificado(ByVal intAgno As Integer, ByVal lngRutCliente As Long) As Boolean
            Dim strQuery As String, arrParam(2)
            arrParam(0) = intAgno
            arrParam(1) = lngRutCliente
            strQuery = _
                "select agno, rut_cliente from Certificado_Aporte" _
                & " where agno = [0] and rut_cliente = [1]  "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        'Clientes con aportes en un a�o, ordenados por Raz�n Social, que no tienen certificado
        'de aportes en el a�o consultado
        Public Function s_clientes_con_aporte_2(ByVal intAgno As Integer) As Object
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAgno

            strQuery = _
                "Select Distinct(rut_cliente), pj.razon_social " _
                & "From Aporte ap, Persona_Juridica pj " _
                & "Where Agno = [0] " _
                & "And ap.cod_estado In (1, 2) " _
                & "And ap.rut_cliente = pj.rut " _
                & "And (Monto_neto + monto_adm) > 0 " _
                & "And rut_cliente not In " _
                    & "(Select rut_cliente From Certificado_Aporte Where agno = [0]) " _
                & "Order By rut_cliente "
            s_clientes_con_aporte_2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'consulta de certificados con informaci�n de clientes
        Public Function s_certificados_clientes( _
                ByVal lngRutCliente As Long, ByVal strNombre As String, _
                ByVal intAgno As Integer) As Object

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRutCliente
            arrParam(1) = SubStringSql(strNombre)
            arrParam(2) = intAgno

            'criterios de b�squeda opcionales
            Dim strWhere As String
            strWhere = ""
            If lngRutCliente > 0 Then strWhere = "And ec.rut = [0] "
            If strNombre <> "" Then strWhere = "And pj.razon_social like [1] " & strWhere
            'consulta
            strQuery = _
                "Select ca.correlativo, p.rut, p.dig_verif, pj.razon_social, " _
                & "pj.Fono , pj.Email, isnull(ec.nom_contacto,'') nom_contacto, isnull(ec.fono_contacto,'') fono_contacto " _
                & "From Empresa_Cliente ec, Persona_Juridica pj, Persona p, Certificado_Aporte ca " _
                & "Where ca.Agno = [2] " _
                & "And ca.rut_cliente = ec.rut " _
                & "And ec.Rut = pj.Rut " _
                & "And pj.rut = p.rut " _
                & strWhere _
                & "Order By ca.correlativo "

            s_certificados_clientes = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        Public Function s_clasificador_todos(ByVal strCodClasificador As String, _
                                     ByVal lngRutEmpresa As Long, _
                                     ByVal strNombreClasificador As String) As Object
            Dim strQuery, strWhere As String, arrParam(2)
            arrParam(0) = SubStringSql(strCodClasificador)
            arrParam(1) = SubStringSql(strNombreClasificador)
            arrParam(2) = lngRutEmpresa
            strWhere = ""
            If strCodClasificador <> "" Then
                strWhere = strWhere & "And c.cod_clasificador like [0] "
            End If
            If strNombreClasificador <> "" Then
                strWhere = strWhere & "And c.nombre like [1] "
            End If
            If lngRutEmpresa > 0 Then
                strWhere = strWhere & "And c.rut = [2] "
            End If

            strQuery = _
                "Select cod_clasificador,c.rut,nombre,ec.razon_social,p.dig_verif " _
                & "From clasificador c, persona_juridica ec ,persona p " _
                & "where c.rut=ec.rut and p.rut=ec.rut " _
                & strWhere

            s_clasificador_todos = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        ' Consulta un usuario segun los parametros
        Public Function s_consulta_usuario(ByVal lngRutUsuario As Long, _
                                    ByVal strNombres As String) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutUsuario
            arrParam(1) = SubStringSql(strNombres)

            strQuery = _
                "SELECT usuario.rut, usuario.nombres, usuario.passwd_enc, " _
                & "usuario.email, 0, usuario.telefono, usuario.fax " _
                & "FROM usuario " _
                & "WHERE (usuario.rut = [0] Or [0] = 0) " _
                & "And (usuario.nombres like [1] or [1] = '') " _
                & "Order By usuario.nombres"

            s_consulta_usuario = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'muestra los ejecutivos asignados de un supervisor
        Public Function s_ejecutivos_asignados(ByVal strRut As String) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = strRut
            strQuery = "Select distinct u.rut, u.nombres" _
                    & " From  usuario u, perfil_usuario pu, supervisor s" _
                    & " Where s.rut_supervisor = [0] and pu.rut = u.rut" _
                    & " And s.rut_ejecutivo = u.rut" _
                    & " And (pu.cod_perfil = 3 Or pu.cod_perfil = 11 Or pu.cod_perfil = 12)"
            s_ejecutivos_asignados = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'muestra los ejecutivos no asignados de un supervisor
        Public Function s_ejecutivos_no_asignados(ByVal strRut As String) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = strRut
            strQuery = "Select distinct us.rut, us.nombres from usuario us, perfil_usuario pu" _
                     & " where us.rut=pu.rut and pu.cod_perfil in (3,11,12)" _
                     & " and us.rut not in (Select u.rut" _
                    & " From  usuario u, perfil_usuario pu, supervisor s" _
                    & " Where s.rut_supervisor = [0]  and pu.rut = u.rut" _
                    & " And s.rut_ejecutivo = u.rut" _
                    & " And (pu.cod_perfil = 3 Or pu.cod_perfil = 11 Or pu.cod_perfil = 12))"
            s_ejecutivos_no_asignados = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'se ocupa en Mantenedor usuario y perfil
        Public Function s_perfiles_asignados(ByVal strRut As String) As DataTable
            Dim strsql As String, arrParam(0)
            arrParam(0) = (strRut)
            strsql = "select pu.rut, pu.cod_perfil,p.nombre,p.cod_perfil from Perfil_Usuario pu," _
             & " perfil p where rut = [0]" _
             & " And pu.cod_perfil = p.cod_perfil order by p.nombre"
            Return ConsultaSql(SqlParam(strsql, arrParam))
        End Function

        Public Function s_perfiles_no_asignados(ByVal strRut As String) As DataTable
            Dim strsql As String, arrParam(0)
            arrParam(0) = (strRut)
            strsql = "select cod_perfil, nombre from perfil " _
            & " where cod_perfil not in(select cod_perfil from Perfil_Usuario" _
            & " where rut=[0] ) order by nombre"
            Return ConsultaSql(SqlParam(strsql, arrParam))
        End Function
        Public Function s_perfiles_asignados_objetos(ByVal lngCodObjeto As String) As DataTable
            Dim strsql As String, arrParam(0)
            arrParam(0) = lngCodObjeto
            strsql = "select p.cod_perfil, p.nombre, obj.cod_objeto, obj.nombre from perfil p, " _
          & "perfil_objeto po, objeto obj " _
          & "where(obj.cod_objeto = [0]) " _
          & "and po.cod_perfil = p.cod_perfil " _
          & "and po.cod_objeto = obj.cod_objeto order by p.nombre"
            Return ConsultaSql(SqlParam(strsql, arrParam))
        End Function
        ' Consulta de todos los registros de perfil
        Public Function s_perfil_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_perfil, perfil.nombre " _
                & "From Perfil order by nombre"
            s_perfil_todos = ConsultaSql(strQuery)
        End Function
        'se ocupa en Mantenedor perfil/objeto
        Public Function s_objetos_asignados(ByVal lngPerfil As Long) As DataTable
            Dim strsql As String, arrParam(0)
            arrParam(0) = (lngPerfil)
            strsql = "select obj.cod_objeto, obj.nombre, p.cod_perfil from objeto obj, " _
                   & "perfil_objeto po, perfil p " _
                   & "where p.cod_perfil = [0] " _
                   & "and po.cod_perfil = p.cod_perfil " _
                   & "and po.cod_objeto = obj.cod_objeto "
            Return ConsultaSql(SqlParam(strsql, arrParam))
        End Function
        Public Function s_objetos_no_asignados(ByVal lngPerfil As Long) As DataTable
            Dim strsql As String, arrParam(0)
            arrParam(0) = (lngPerfil)
            strsql = "select cod_objeto, nombre from objeto " _
                   & "where cod_objeto not in(select cod_objeto from perfil_objeto " _
                   & "where cod_perfil = [0]) "
            Return ConsultaSql(SqlParam(strsql, arrParam))
        End Function
        ' Consulta de todos los registros de objetos
        Public Function s_objeto_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_objeto, nombre " _
                & "From Objeto "
            s_objeto_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_solicitud_pago_ter_todos(ByVal lngRutBenefactor As Long, ByVal lngCodCurso As Long, ByVal intAgno As Integer) As DataTable
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRutBenefactor
            arrParam(1) = lngCodCurso
            arrParam(2) = intAgno
            Dim strWhere As String
            Dim strWhere2 As String
            Dim strWhere3 As String
            If lngRutBenefactor <> 0 Then
                strWhere = " s.rut_benefactor = [0] And "
            Else
                strWhere = ""
            End If
            If lngCodCurso <> 0 Then
                strWhere2 = " s.cod_curso = [1] And "
            Else
                strWhere2 = ""
            End If
            If intAgno <> 0 Then
                strWhere3 = " cc.agno = [2] And "
            Else
                strWhere3 = ""
            End If
            strQuery = _
                "Select s.cod_solicitud_pago, s.rut_benefactor, s.cod_curso, " _
                & "s.fecha_ingreso, s.monto, isnull(s.nro_transaccion, 0) nro_transaccion, cc.rut_cliente " _
                & ", cc.correlativo, cc.fecha_inicio, pj1.razon_social as razon_social_benefactor, pj2.razon_social " _
                & ", cc.costo_otic, cs.nombre " _
                & "From Solicitud_Pago_Terceros s, curso_contratado cc , persona_juridica pj1, " _
                & "persona_juridica pj2, curso cs " _
                & " Where  " & strWhere & strWhere2 & strWhere3 & " cc.cod_curso = s.cod_curso  " _
                & "And pj1.rut=s.rut_benefactor And pj2.rut=cc.rut_cliente " _
                & "And cs.codigo_sence=cc.codigo_sence " _
                & "And s.cod_estado_solicitud=1 Order By cod_solicitud_pago"
            s_solicitud_pago_ter_todos = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_solicitud_pago_ter_todos2(ByVal lngCodCurso As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            Dim strWhere As String
            If lngCodCurso <> 0 Then
                strWhere = " cc.Cod_curso = [0] And "
            Else
                strWhere = ""
            End If
            strQuery = _
                "Select cc.correlativo, cc.porc_adm, s.cod_solicitud_pago, s.rut_benefactor, s.cod_curso, " _
                & "s.fecha_ingreso, s.monto, s.nro_transaccion, cc.rut_cliente " _
                & ", cc.correlativo, cc.fecha_inicio, pj1.razon_social as razon_social_benefactor, pj2.razon_social " _
                & ", cc.costo_otic, cs.nombre " _
                & "From Solicitud_Pago_Terceros s, curso_contratado cc , persona_juridica pj1, " _
                & "persona_juridica pj2, curso cs " _
                & " Where  " & strWhere & " cc.cod_curso = s.cod_curso  " _
                & "And pj1.rut=s.rut_benefactor And pj2.rut=cc.rut_cliente " _
                & "And cs.codigo_sence=cc.codigo_sence " _
                & "And s.cod_estado_solicitud=1 Order By cod_solicitud_pago"
            s_solicitud_pago_ter_todos2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        Public Function s_cursos_contratados(ByVal strSelect As String, _
                                ByVal lngRutUsuario As Long, _
                                ByVal strWhere As String, _
                                ByVal dtmFechaInicio As Date, _
                                ByVal dtmFechaFin As Date, _
                                ByVal intAgno As Integer, _
                                ByVal intCuentaTercero As Integer, _
                                ByVal lngCorrelativo As Long, _
                                Optional ByVal blnProximoDiaHabil As Boolean = False, _
                                Optional ByVal intCodEstadoCurso As Integer = gValorNumNulo, _
                                Optional ByVal strVoucher As String = "no", _
                                Optional ByVal lngCodCurso As Long = 0, _
                                Optional ByVal lngNumRegistro As Long = 0) As DataTable

            Dim strQuery As String, arrParam(7)
            Dim strFrom As String = ""
            Dim strWhereTercero As String = ""
            Dim strHaving As String = ""
            Dim strWhereVoucher As String = ""
            Dim strWhereCodCurso As String = ""
            Dim strWhereRegistro As String = ""
            Dim strWhereFechas As String = ""

            arrParam(0) = lngRutUsuario
            arrParam(2) = FechaVbABd(dtmFechaInicio)
            arrParam(3) = FechaVbABd(dtmFechaFin)
            arrParam(4) = intAgno

            If Not intCodEstadoCurso = 2 Then
                If Not intCodEstadoCurso = 8 Then
                    If Not intCodEstadoCurso = 10 Then
                        If intCuentaTercero = 0 Then
                            strFrom = ", transaccion tr "
                            strWhereTercero = " and cc.cod_curso = tr.cod_curso " ' and tr.cod_cuenta in (2,5) "
                            strHaving = " having sum(tr.monto) > 0 "
                        ElseIf intCuentaTercero = 1 Then
                            strFrom = ", transaccion tr "
                            strWhereTercero = " and cc.cod_curso = tr.cod_curso  and tr.cod_cuenta = 2 "
                            strHaving = " having sum(tr.monto) > 0 "
                        ElseIf intCuentaTercero = 2 Then
                            strFrom = ", transaccion tr "
                            strWhereTercero = " and cc.cod_curso = tr.cod_curso  and tr.cod_cuenta = 5 "
                            strHaving = " having sum(tr.monto) > 0 "
                        ElseIf intCuentaTercero = gValorNumNulo Then
                            strFrom = " "
                            strWhereTercero = " "
                            strHaving = " "
                        End If
                    End If
                End If
            End If

            If strSelect = "" Then
                arrParam(1) = " Where "
            Else
                arrParam(1) = " Where cc.cod_curso in " & strSelect & " And "
            End If
            If blnProximoDiaHabil Then
                arrParam(2) = FechaVbABd(ProximoDiaHabil())
                'strWhere = strWhere & " And cc.fecha_inicio = [2] "
                strWhereFechas = strWhere & " And cc.fecha_inicio = [2] "
                If intAgno <> 1900 Then
                    'strWhere = strWhere & " and cc.agno = [4]"
                    strWhereFechas = strWhere & " and cc.agno = [4]"
                Else
                    'strWhere = strWhere & " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] "
                    strWhereFechas = strWhere & " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] "
                End If
            Else
                If intAgno <> 0 Then
                    If intAgno <> 1900 Then
                        'strWhere = strWhere & " and cc.agno = [4]"
                        strWhereFechas = strWhere & " and cc.agno = [4]"
                    Else
                        'strWhere = strWhere & " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] "
                        strWhereFechas = strWhere & " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] "
                    End If
                End If

            End If
            If lngCorrelativo <> 0 Then
                arrParam(5) = lngCorrelativo
                strWhere = strWhere & " and cc.correlativo = [5] "
            End If

            If strVoucher = "si" Then
                strWhereVoucher = " and cc.cod_curso = fa.cod_curso "
            Else
                strWhereVoucher = "and cc.cod_curso *= fa.cod_curso "
            End If



            If lngCodCurso > 0 Then
                arrParam(6) = lngCodCurso
                strWhereCodCurso = " and cc.cod_curso = [6] "
                strWhereFechas = ""
            End If

            If lngNumRegistro > 0 Then
                arrParam(7) = lngNumRegistro
                strWhereRegistro = " and cc.nro_registro = [7] "
                strWhereFechas = ""
            End If


            strQuery = _
                "Select row_number() over (order by cc.correlativo) as nFila, " _
& "'Sence' as tipo_curso, " _
& "cc.cod_curso, " _
& "cast(isnull(cc.correlativo,0) as varchar) correlativo, " _
& "isnull(cc.nro_registro, 0) nro_registro, " _
& "isnull(cc.correlativo_empresa,'0') correlativo_empresa, " _
& "cc.codigo_sence, " _
& "cs.nombre as nombre_curso, " _
& "isnull(cs.area,'') area, " _
& "isnull(cs.especialidad,'') especialidad, " _
& "mo.nombre modalidad, " _
& "ta.nombre tipo_actividad, " _
& "(cc.direccion_curso + ' ' + cc.Nro_direccion_curso) direccion_curso, co.nombre as comuna, isnull(cc.Ciudad,'') ciudad, " _
& "otec.rut as rut_otec, " _
& "pe.dig_verif as dig_verif_otec, " _
& "otec.razon_social as nombre_otec, " _
& "cc.rut_cliente, " _
& "pe2.dig_verif as dig_verif_cliente, " _
& "pj.razon_social nombre_empresa, cc.fecha_ingreso,cc.fecha_modificacion, SUM(vcp.nro_perfil) nro_perfil, " _
& "isnull((select case cc.ind_acu_com_bip when 1 then 'SI' else 'NO' end ORDER BY cc.ind_acu_com_bip FOR XML PATH('')),0) comite_bipartito, " _
& "isnull((select case cc.flag_curso_cft when 1 then 'si' else 'no' end ORDER BY cc.flag_curso_cft FOR XML PATH('')),0) curso_cft, " _
& "isnull((SELECT case hc.dia when 1 then ' LUN' when 2 then ' MAR' when 3 then ' MIE' when 4 then ' JUE' when 5 then ' VIE' when 6 then ' SAB' when 7 then ' DOM' end + ':' + hora_inicio + '-' + hora_fin FROM horario_curso hc WHERE hc.cod_curso = cc.cod_curso ORDER BY hc.dia FOR XML PATH('')),'') horario_curso, " _
& "cc.agno 'a�o' , " _
& "cc.fecha_inicio, " _
& "cc.fecha_termino, " _
& "isnull(cc.cod_curso_compl,0) cod_curso_compl, " _
& "isnull(cc.cod_curso_parcial,0) cod_curso_parcial, " _
& "cc.horas_compl as horas_complementarias, " _
& "cc.cod_estado_curso, " _
& "ec.nombre as estado_curso, isnull(cc.fecha_comunicacion, '1900-01-01') fecha_comunicacion, isnull(cc.fecha_liquidacion, '1900-01-01') fecha_liquidacion, Origen.nombre as origen, " _
& "(cc.porc_adm*100) porcentaje_adm, " _
& "(cc.horas-cc.horas_compl) as horas, " _
& "num_alumnos as numero_alumnos, " _
& "((cc.horas-cc.horas_compl) * num_alumnos) as HH, " _
& "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante where cod_curso=cc.cod_curso and porc_asistencia > 0))as hh_con_asistencia_mayor_a_cero, " _
& "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante where cod_curso=cc.cod_curso and porc_asistencia >= 0.75))as hh_con_asistencia_mayor_igual_75, " _
& "(select count(*) from participante p where p.cod_curso = cc.cod_curso And porc_asistencia >= 0.75) participantes_aprobado_por_asistencia, " _
& "cc.valor_mercado, " _
& "(select sum((cco.valor_hora * cco.horas) * pa.porc_franquicia) from participante pa, curso_contratado cco " _
& "where pa.cod_curso=cco.cod_curso and cco.cod_curso = cc.cod_curso) costo_otic_comunicado, " _
& "cc.costo_otic, " _
& "cc.costo_adm, " _
& "cc.gasto_empresa, " _
& "(cc.total_viatico + cc.total_traslado) total_vyt, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And(cod_cuenta = 1 Or cod_cuenta = 4) And cod_tipo_tran=5 And rut_cliente = cc.rut_cliente),0) as costo_otic_vyt, " _
& "(cc.gasto_empresa_vyt) total_gasto_empresa_vyt, " _
& "cc.total_viatico, " _
& "CAST((select sum(viatico * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) costo_otic_viatico, " _
& "CAST(cc.total_viatico - (select sum(viatico * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) gasto_emp_viatico, " _
& "cc.total_traslado, " _
& "CAST((select sum(traslado * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) costo_otic_traslado, " _
& "CAST(cc.total_traslado - (select sum(traslado * porc_franquicia) from participante where cod_curso = cc.cod_curso AND ((PORC_ASISTENCIA >= 0.75 AND CC.COD_ESTADO_CURSO IN (5, 9, 11)) OR (PORC_ASISTENCIA >= 0 AND CC.COD_ESTADO_CURSO NOT IN (5, 9, 11))) ) AS NUMERIC) gasto_emp_traslado, " _
& "" _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 1 ),0) as cuenta_capacitacion, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 4 ),0) as cuenta_exc_capacitacion, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 2 ),0) as cuenta_reparto, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 5 ),0) as cuenta_exc_reparto, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 3 And rut_cliente = cc.rut_cliente ),0) as cuenta_adm, " _
& "isnull((Select Sum(convert(numeric, monto)) From Transaccion  Where cod_curso = cc.cod_curso And cod_cuenta = 6 And rut_cliente = cc.rut_cliente),0) as cuenta_becas, " _
& "isnull(f.num_factura,0) as numero_factura, " _
& "isnull(f.monto,0) as monto_factura,  " _
& "isnull((select nombre from estado_factura where cod_estado_fact = f.cod_estado_fact),'S/F') as estado_factura,isnull(fa.fecha_pago,'1900-01-01') as fecha_factura, " _
& "isnull(f.num_voucher,0) num_voucher "


            strQuery = strQuery _
                & "From Curso_Contratado cc, Curso cs, Estado_Curso ec, Estado_Curso ec2, " _
                & "Persona_Juridica pj, Persona_Juridica otec, Origen, factura fa, modalidad mo, " _
                & "V_Cliente_Permiso vcp, Ejecutivo ej, persona pe, persona pe2, persona per3,tipo_actividad ta,factura f, comuna co " & strFrom & " [1]" _
                & " cc.cod_estado_curso = ec.cod_estado_curso And cc.cod_curso*=f.cod_curso  " _
                & " and cc.cod_tipo_activ = ta.cod_tipo_activ  " _
                & " And cc.cod_ultimo_estado *= ec2.cod_estado_curso " _
                & " And cc.codigo_sence = cs.codigo_sence " _
                & " And cs.rut_otec = otec.rut And cc.cod_origen = Origen.cod_origen " _
                & " and cc.rut_cliente = pj.rut " _
                & " And cc.cod_origen = Origen.cod_origen " _
                & " And cc.rut_cliente = vcp.rut_empresa " _
                & " And cc.rut_cliente = ej.rut_empresa " _
                & " AND vcp.rut_empresa = pj.rut " _
                & " and cc.cod_modalidad *= mo.cod_modalidad " _
                & " And vcp.rut_usuario = [0] and pe.rut = otec.rut and pe2.rut = cc.rut_cliente and per3.rut = ej.rut_ejecutivo and co.cod_comuna = cc.cod_comuna " _
                & strWhereVoucher _
                & strWhere & "  " & strWhereTercero & " " & strWhereFechas & " " & strWhereCodCurso & " " & strWhereRegistro            '& " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] " _
            strQuery = strQuery _
                & "Group By cc.cod_curso, cc.correlativo, cc.nro_registro, " _
                & "cc.codigo_sence, cs.nombre, cs.direccion, otec.rut, otec.razon_social, " _
                & "cc.cod_estado_curso, mo.nombre, ec.nombre, cc.rut_cliente, pj.razon_social, " _
                & "cc.fecha_inicio, cc.fecha_termino, Origen.nombre, " _
                & "cc.cod_curso_compl, cc.fecha_ingreso, cc.num_alumnos, " _
                & "cc.fecha_comunicacion, cc.fecha_liquidacion, cc.correlativo_empresa, " _
                & "cs.dur_cur_teorico, cs.dur_cur_prac, cs.dur_cur_elearning, horas_compl, cc.cod_curso_parcial, " _
                & "cc.costo_otic, ej.rut_ejecutivo, cc.gasto_empresa, cc.porc_adm, cc.horas, cc.observacion, ec2.nombre, " _
                & "cc.total_viatico, cc.total_traslado, cc.costo_adm,cc.direccion_curso, cc.Nro_direccion_curso, cc.ciudad,fa.num_factura,  " _
                & "fa.num_voucher, cc.fecha_modificacion, cc.gasto_empresa_vyt, fa.monto, fa.cod_estado_fact, fa.fecha_pago, " _
                & "pe.dig_verif, pe2.dig_verif, per3.dig_verif,cc.valor_mercado, cs.area, cs.especialidad, " _
                & "cc.ind_acu_com_bip, ta.nombre, cc.flag_curso_cft, cc.agno, f.num_factura,f.monto,f.cod_estado_fact,f.num_voucher, Origen.nombre, " _
                & "co.nombre, cc.Ciudad Order By nFila"   'cc.rut_cliente"


            '& strHaving _
            s_cursos_contratados = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Public Function s_cursos_contratados(ByVal strSelect As String, _
        '                        ByVal lngRutUsuario As Long, _
        '                        ByVal strWhere As String, _
        '                        ByVal dtmFechaInicio As Date, _
        '                        ByVal dtmFechaFin As Date, _
        '                        ByVal intAgno As Integer, _
        '                        ByVal intCuentaTercero As Integer, _
        '                        ByVal lngCorrelativo As Long, _
        '                        Optional ByVal blnProximoDiaHabil As Boolean = False, _
        '                        Optional ByVal intCodEstadoCurso As Integer = gValorNumNulo, _
        '                        Optional ByVal strVoucher As String = "no") As DataTable

        '    Dim strQuery As String, arrParam(5)
        '    Dim strFrom As String = ""
        '    Dim strWhereTercero As String = ""
        '    Dim strHaving As String = ""
        '    Dim strWhereVoucher As String = ""

        '    arrParam(0) = lngRutUsuario
        '    arrParam(2) = FechaVbABd(dtmFechaInicio)
        '    arrParam(3) = FechaVbABd(dtmFechaFin)
        '    arrParam(4) = intAgno

        '    If Not intCodEstadoCurso = 2 Then
        '        If Not intCodEstadoCurso = 8 Then
        '            If Not intCodEstadoCurso = 10 Then
        '                If intCuentaTercero = 0 Then
        '                    strFrom = ", transaccion tr "
        '                    strWhereTercero = " and cc.cod_curso = tr.cod_curso " ' and tr.cod_cuenta in (2,5) "
        '                    strHaving = " having sum(tr.monto) > 0 "
        '                ElseIf intCuentaTercero = 1 Then
        '                    strFrom = ", transaccion tr "
        '                    strWhereTercero = " and cc.cod_curso = tr.cod_curso  and tr.cod_cuenta = 2 "
        '                    strHaving = " having sum(tr.monto) > 0 "
        '                ElseIf intCuentaTercero = 2 Then
        '                    strFrom = ", transaccion tr "
        '                    strWhereTercero = " and cc.cod_curso = tr.cod_curso  and tr.cod_cuenta = 5 "
        '                    strHaving = " having sum(tr.monto) > 0 "
        '                ElseIf intCuentaTercero = gValorNumNulo Then
        '                    strFrom = " "
        '                    strWhereTercero = " "
        '                    strHaving = " "
        '                End If
        '            End If
        '        End If
        '    End If

        '    If strSelect = "" Then
        '        arrParam(1) = " Where "
        '    Else
        '        arrParam(1) = " Where cc.cod_curso in " & strSelect & " And "
        '    End If
        '    If blnProximoDiaHabil Then
        '        arrParam(2) = FechaVbABd(ProximoDiaHabil())
        '        strWhere = strWhere & " And cc.fecha_inicio = [2] "
        '        If intAgno <> 1900 Then
        '            strWhere = strWhere & " and cc.agno = [4]"
        '        Else
        '            strWhere = strWhere & " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] "
        '        End If
        '    Else
        '        If intAgno <> 0 Then
        '            If intAgno <> 1900 Then
        '                strWhere = strWhere & " and cc.agno = [4]"
        '            Else
        '                strWhere = strWhere & " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] "
        '            End If
        '        End If

        '    End If
        '    If lngCorrelativo <> 0 Then
        '        arrParam(5) = lngCorrelativo
        '        strWhere = strWhere & " and cc.correlativo = [5] "
        '    End If

        '    If strVoucher = "si" Then
        '        strWhereVoucher = " and cc.cod_curso = fa.cod_curso "
        '    Else
        '        strWhereVoucher = "and cc.cod_curso *= fa.cod_curso "
        '    End If
        '    strQuery = _
        '        "Select row_number() over (order by cc.cod_curso) as nFila, cc.cod_curso, isnull(cc.correlativo, 0) correlativo, isnull(cc.nro_registro, 0) nro_registro, " _
        '        & "cc.codigo_sence, REPLACE(REPLACE(REPLACE(cs.nombre, char(10), ' '), char(13), ' '), char(34), ' ')  as nombre_curso, " _
        '        & "REPLACE(REPLACE(REPLACE(cs.direccion, char(10), ' '), char(13), ' '), char(34), ' ') as direccion_curso ,otec.rut as rut_otec, " _
        '        & "per1.dig_verif as dig_otec, otec.razon_social as nombre_otec, cc.cod_estado_curso, ec.nombre  as estado_curso, mo.nombre as modalidad, " _
        '        & "isnull((select case cc.ind_acu_com_bip when 1 then 'SI' else 'NO' end ORDER BY cc.ind_acu_com_bip FOR XML PATH('')),0) comite_bipartito, " _
        '        & " cc.rut_cliente, per2.dig_verif as dig_cliente, pj.razon_social as nombre_empresa, " _
        '        & "cc.fecha_inicio, cc.fecha_termino, Origen.nombre as origen, " _
        '        & "isnull((select correlativo from curso_contratado where cod_curso = cc.cod_curso_compl),0) cod_curso_compl, cc.fecha_ingreso, " _
        '        & "cc.fecha_modificacion, SUM(vcp.nro_perfil) nro_perfil, cc.num_alumnos as numero_alumnos, (cc.horas-cc.horas_compl) as horas , " _
        '        & "(select count(*) from participante p where p.cod_curso = cc.cod_curso And porc_asistencia >= 0.75) participantes_aprobado_por_asistencia, " _
        '        & "((cc.horas-cc.horas_compl) * cc.num_alumnos) as HH, " _
        '        & "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante " _
        '        & "where cod_curso=cc.cod_curso and porc_asistencia > 0))as hh_con_asistencia_mayor_a_cero, " _
        '        & "((cc.horas-cc.horas_compl) * (select count(rut_alumno) from participante " _
        '        & "where cod_curso=cc.cod_curso and porc_asistencia >= 0.75))as hh_con_asistencia_mayor_igual_75, " _
        '        & "isnull(cc.fecha_comunicacion, '1900-01-01') fecha_comunicacion, isnull(cc.fecha_liquidacion, '1900-01-01') fecha_liquidacion, " _
        '        & " ej.rut_ejecutivo, per3.dig_verif as dig_ejecutivo, " _
        '        & "replace(cc.observacion,char(13)+char(10),' ') observacion,  " _
        '        & "REPLACE(REPLACE(REPLACE(cc.direccion_curso, char(10), ' '), char(13), ' '), char(34), ' ') as direccion_curso, " _
        '        & "REPLACE(REPLACE(REPLACE(cc.Nro_direccion_curso, char(10), ' '), char(13), ' '), char(34), ' ') as Nro_direccion_curso, cc.ciudad, " _
        '        & "isnull(cc.correlativo_empresa, 'S/C') correlativo_empresa, " _
        '        & "isnull((SELECT case hc.dia when 1 then ' LUN' when 2 then ' MAR' when 3 then ' MIE' when 4 then ' JUE' " _
        '        & "when 5 then ' VIE' when 6 then ' SAB' when 7 then ' DOM' end + ':' + hora_inicio + '-' + hora_fin " _
        '        & " FROM horario_curso hc WHERE hc.cod_curso = cc.cod_curso ORDER BY hc.dia FOR XML PATH('')),'') horario_curso, " _
        '        & " cs.area, cs.especialidad, cc.valor_mercado, " _
        '        & "isnull(cc.cod_curso_parcial,0) cod_curso_parcial, " _
        '        & "cc.costo_otic,  cc.gasto_empresa, cc.costo_adm, cc.total_viatico, cc.total_traslado,(cc.total_viatico + cc.total_traslado) total_vyt, (cc.porc_adm*100) porc_adm, " _
        '        & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 1 ),0) as cuenta_capacitacion, " _
        '        & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 4 ),0) as cuenta_exc_capacitacion, " _
        '        & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 2 ),0) as cuenta_reparto, " _
        '        & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 5 ),0) as cuenta_exc_reparto, " _
        '        & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 3 " _
        '        & "And rut_cliente = cc.rut_cliente ),0) as cuenta_adm, " _
        '        & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And(cod_cuenta = 1 Or cod_cuenta = 4) " _
        '        & "And cod_tipo_tran=5 And rut_cliente = cc.rut_cliente),0) as costo_otic_vyt,  " _
        '        & "(cc.gasto_empresa_vyt) total_gasto_empresa_vyt, " _
        '        & "isnull(fa.num_factura,0) as numero_factura, isnull(fa.monto,0) as monto_factura,  " _
        '        & "isnull((select nombre from estado_factura where cod_estado_fact = fa.cod_estado_fact),'S/F') as estado_factura, " _
        '        & "isnull(fa.fecha_pago,'1900-01-01') as fecha_factura, isnull(fa.num_voucher,0) num_voucher "

        '    strQuery = strQuery _
        '        & "From Curso_Contratado cc, Curso cs, Estado_Curso ec, Estado_Curso ec2, " _
        '        & "Persona_Juridica pj, Persona_Juridica otec, Origen, factura fa, modalidad mo, " _
        '        & "V_Cliente_Permiso vcp, Ejecutivo ej, persona per1, persona per2, persona per3 " & strFrom & " [1]" _
        '        & " cc.cod_estado_curso = ec.cod_estado_curso " _
        '        & " And cc.cod_ultimo_estado *= ec2.cod_estado_curso " _
        '        & " And cc.codigo_sence = cs.codigo_sence " _
        '        & " And cs.rut_otec = otec.rut " _
        '        & " and cc.rut_cliente = pj.rut " _
        '        & " And cc.cod_origen = Origen.cod_origen " _
        '        & " And cc.rut_cliente = vcp.rut_empresa " _
        '        & " And cc.rut_cliente = ej.rut_empresa " _
        '        & " AND vcp.rut_empresa = pj.rut " _
        '        & " and cc.cod_modalidad = mo.cod_modalidad " _
        '        & " And vcp.rut_usuario = [0] and per1.rut = otec.rut and per2.rut = cc.rut_cliente and per3.rut = ej.rut_ejecutivo  " _
        '        & strWhereVoucher _
        '        & strWhere & "  " & strWhereTercero             '& " And cc.fecha_inicio >= [2] and cc.fecha_termino <=[3] " _
        '    strQuery = strQuery _
        '        & "Group By cc.cod_curso, cc.correlativo, cc.nro_registro, " _
        '        & "cc.codigo_sence, cs.nombre, cs.direccion, otec.rut, otec.razon_social, " _
        '        & "cc.cod_estado_curso, mo.nombre, ec.nombre, cc.rut_cliente, pj.razon_social, " _
        '        & "cc.fecha_inicio, cc.fecha_termino, Origen.nombre, " _
        '        & "cc.cod_curso_compl, cc.fecha_ingreso, cc.num_alumnos, " _
        '        & "cc.fecha_comunicacion, cc.fecha_liquidacion, cc.correlativo_empresa, " _
        '        & "cs.dur_cur_teorico, cs.dur_cur_prac, cs.dur_cur_elearning, horas_compl, cc.cod_curso_parcial, " _
        '        & "cc.costo_otic, ej.rut_ejecutivo, cc.gasto_empresa, cc.porc_adm, cc.horas, cc.observacion, ec2.nombre, " _
        '        & "cc.total_viatico, cc.total_traslado, cc.costo_adm,cc.direccion_curso, cc.Nro_direccion_curso, cc.ciudad,fa.num_factura,  " _
        '        & "fa.num_voucher, cc.fecha_modificacion, cc.gasto_empresa_vyt, fa.monto, fa.cod_estado_fact, fa.fecha_pago, " _
        '        & "per1.dig_verif, per2.dig_verif, per3.dig_verif,cc.valor_mercado, cs.area, cs.especialidad, " _
        '        & "cc.ind_acu_com_bip Order By cc.correlativo"   'cc.rut_cliente"


        '    '& strHaving _
        '    s_cursos_contratados = ConsultaSql(SqlParam(strQuery, arrParam))
        'End Function
        Public Function s_lista_cursos(ByVal CodCurso As String) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = CodCurso
            strQuery = _
            "select cs.nombre, cs.direccion, cc.correlativo, cc.fecha_inicio, " _
            & "cc.fecha_termino from curso cs, curso_contratado cc " _
            & "where(cs.codigo_sence = cc.codigo_sence) " _
            & "and cod_curso in ([0])"
            s_lista_cursos = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_clientes(ByVal RutEmpresa As Long, _
                                    ByVal RazonSocial As String, _
                                    ByVal RutUsuario As Long) As DataTable
            Dim strQuery As String, arrParam(2)
            Dim strWhere As String = ""
            If RutEmpresa <> gValorNumNulo Then
                arrParam(0) = RutEmpresa
                strWhere = "and ec.rut = [0] "
            End If
            If RazonSocial <> "" Then
                arrParam(1) = SubStringSql(RazonSocial)
                strWhere = "and pj.razon_social like [1]"
            End If
            arrParam(2) = RutUsuario

            strQuery = _
                "Select p.rut, p.dig_verif, pj.razon_social, " _
                & "pj.fono, pj.email, ec.nom_contacto, ec.fono_contacto " _
                & "From Empresa_Cliente ec, Persona_Juridica pj, Persona p " _
                & "Where ec.Rut = pj.Rut " _
                & "And pj.rut = p.rut " _
                & "And Exists (Select * From V_Cliente_Permiso " _
                & "Where rut_usuario = [2] And rut_empresa = ec.Rut) " _
                & strWhere _
                & "Order By pj.razon_social "
            s_clientes = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_etiqueta_por_empresa(ByVal lngRutEmp As Long) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutEmp

            strQuery = _
                "Select isnull(etiqueta_clasificador,'') " _
                & "From empresa_cliente " _
                & "Where (rut = [0] Or [0] = 0) "

            s_etiqueta_por_empresa = CStr(ValorSql(SqlParam(strQuery, arrParam)))

        End Function
        Public Function s_porcentaje_empresa(ByVal lngRutEmp As Long) As Double
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutEmp

            strQuery = _
                "Select isnull(costo_admin,0) " _
                & "From empresa_cliente " _
                & "Where (rut = [0] Or [0] = 0) "

            s_porcentaje_empresa = CStr(ValorSql(SqlParam(strQuery, arrParam)))
        End Function
        Public Function s_empresa_beneficiada(ByVal lngAgno As Long, ByVal lngRutEmpresa As Long, ByVal lngCodCuenta As Long) As DataTable
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngAgno
            arrParam(1) = lngRutEmpresa
            arrParam(2) = lngCodCuenta
            strQuery = _
               "Select cc.rut_cliente " _
             & "From transaccion tr, curso_contratado cc " _
             & "where tr.cod_Cuenta = [2] " _
             & "And tr.rut_cliente = [1] " _
             & "and year(tr.fecha_hora) = [0] " _
             & "and year(tr.fecha_hora) = cc.agno " _
             & "and tr.cod_curso = cc.cod_curso "
            s_empresa_beneficiada = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_rut_clientes(ByVal strCodigos As String) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = strCodigos

            strQuery = _
                           "Select rut_cliente, cod_estado_curso, cod_curso " _
                           & " From Curso_Contratado  " _
                           & "Where cod_curso IN ([0]) "
            s_rut_clientes = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_tipos_activ_todos() As DataTable

            Dim strQuery As String
            strQuery = _
                "Select cod_tipo_activ, nombre " _
                & "From  Tipo_Actividad "
            s_tipos_activ_todos = ConsultaSql(strQuery)

        End Function
        Public Function s_estado_part_interno() As DataTable

            Dim strQuery As String
            strQuery = _
                "Select codigo, descripcion " _
                & "From  estado_particip_interno "
            s_estado_part_interno = ConsultaSql(strQuery)

        End Function
        Public Function s_tipo_documentos() As DataTable

            Dim strQuery As String
            strQuery = _
                "select cod_tipo_doc, nombre from tipo_documento"
            s_tipo_documentos = ConsultaSql(strQuery)

        End Function
        Public Function s_modalidades_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_modalidad, nombre " _
                & "From Modalidad "

            s_modalidades_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_encargado_empresa(ByVal lngRutEmpresa As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutEmpresa
            strQuery = _
                "select en.rut_encargado, (en.nombre_encargado + ' ' + en.apellido_encargado) nombre " _
                & "from encargado en, encargado_empresa ee " _
                & "where en.rut_encargado = ee.rut_encargado and ee.rut_empresa = [0]"

            s_encargado_empresa = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_comunas_todos() As DataTable

            Dim strQuery As String
            strQuery = _
                "Select cod_comuna, nombre " _
                & "From  Comuna " _
                & "Order by nombre "
            s_comunas_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_pais_todos() As DataTable

            Dim strQuery As String
            strQuery = _
                "Select cod_pais, nombre_pais " _
                & "From  pais " _
                & "Order by nombre_pais "
            s_pais_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_comunas_region(ByVal intCodregion As Integer) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodregion
            strQuery = _
            "select co.nombre,co.cod_comuna from region re, provincia pr, comuna co " _
            & "where re.cod_region = pr.cod_region And pr.cod_provincia = co.cod_provincia " _
            & "and re.cod_region = [0] order by co.nombre "
            s_comunas_region = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_region_comunas(ByVal intCodComuna As Integer) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodComuna
            strQuery = _
            "select re.nombre, re.cod_region from region re, provincia pr, comuna co " _
            & "where re.cod_region = pr.cod_region And pr.cod_provincia = co.cod_provincia " _
            & "and co.cod_comuna = [0] order by co.nombre "
            s_region_comunas = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_comuna(ByVal intCodComuna As Integer) As String

            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodComuna
            strQuery = _
            "select nombre from comuna where cod_comuna = [0] "
            s_comuna = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta los datos de un curso contratado por su codigo interno.

        Public Function s_curso_contratado(ByVal lngCodCurso As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
               "Select  rut_cliente, cod_tipo_activ, ind_acu_com_bip, num_alumnos, " _
            & "ind_det_nece, direccion_curso, cod_comuna, codigo_sence, " _
            & "fecha_inicio, fecha_termino, horas_compl, valor_mercado, " _
            & "descuento, correlativo, nro_registro, cod_estado_curso, " _
            & "agno, porc_adm, costo_otic, costo_adm, gasto_empresa, " _
            & "total_viatico, total_traslado, cod_origen, obs_curso, " _
            & "costo_otic_comunicar, obs_liquidacion, horas, nro_factura_otec, " _
            & "fecha_pago_factura, cod_curso_compl, ind_desc_porc, " _
            & "correlativo_empresa, fecha_ingreso, fecha_modificacion, " _
            & "fecha_comunicacion, fecha_liquidacion, cod_curso_parcial,contacto_adicional, " _
            & "isnull(observacion,'') as observacion, isnull(cod_elearning,0) as cod_elearning, " _
            & "isnull(cod_ultimo_estado,0) as cod_ultmino_estado, costo_otic_vyt, costo_adm_vyt, " _
            & "gasto_empresa_vyt, isnull(cod_modalidad,0) as cod_modalidad, " _
            & "nro_direccion_curso,ciudad, isnull(valor_hora, 0) valor_hora, " _
            & "isnull(flag_curso_cft,0) flag_curso_cft, isnull(rut_encargado,0) rut_encargado  " _
            & "From Curso_Contratado " _
            & "Where cod_curso = [0] "
            s_curso_contratado = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_param_gen() As DataTable
            Dim strQuery As String
            strQuery = _
            "Select * from param_gen"
            s_param_gen = ConsultaSql(strQuery)
        End Function
        Function s_todos_los_perfiles() As DataTable
            Dim strQuery As String
            strQuery = " select cod_perfil,nombre " _
            & " From perfil order by nombre"

            Return ConsultaSql(strQuery)
        End Function
        'muestra numero de participantes
        Public Function s_nro_participantes(ByVal lngCodCurso As Long) As Long

            'Dim auxiliar() As Object
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                    "Select count(rut_alumno) as num_participantes " _
                    & "From Participante " _
                    & "Where cod_curso = [0] "

            s_nro_participantes = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'muestra informaci�n de participantes
        Public Function s_participantes(ByVal lngCodCurso As Long) As DataTable

            'Dim auxiliar() As Object
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                    "Select row_number() over (order by p.rut_alumno ) as nFila, p.rut_alumno,(p.porc_franquicia * 100) porc_franquicia, " _
                    & "p.viatico, p.traslado,(p.porc_asistencia * 100) porc_asistencia, " _
                    & "pn.ap_paterno, pn.ap_materno, pn.nombre, isnull(p.nota_obtenida,0.0) nota_obtenida " _
                    & "from participante p, persona_natural pn " _
                    & "where cod_curso = [0] And p.rut_alumno = pn.rut "
            s_participantes = ConsultaSql(SqlParam(strQuery, arrParam))
            'isnull(p.asistencia_detallada,'') asistencia_detallada, isnull(p.nota_obtenida,0) nota_obtenida " _
        End Function
        ' N�mero de pefil de un cliente
        '
        Public Function s_cliente_nroperfil(ByVal lngRutEmpresa As Long, _
                                            ByVal lngRutUsuario As Long) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutEmpresa
            arrParam(1) = lngRutUsuario
            strQuery = _
                "Select isnull(SUM(nro_perfil),0) as nro_perfil " _
                & "From V_Cliente_Permiso " _
                & "Where rut_empresa = [0] " _
                & "And rut_usuario = [1] "
            s_cliente_nroperfil = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_region(ByVal lngCodComuna As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodComuna

            strQuery = _
                "Select r.cod_region, r.nombre " _
                & "From Comuna c, Provincia p, Region r " _
                & "Where c.cod_comuna = [0] And c.cod_provincia = p.cod_provincia " _
                & "And p.cod_region = r.cod_region "

            s_region = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_horas_complementarias(ByVal lngCodCurso As Long) As Double
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                "select horas_compl " _
                & "From curso_contratado " _
                & "Where cod_curso = [0] "
            s_horas_complementarias = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Horarios de los Cursos
        '
        'Selecciona el horario de un curso determinado, por el codigo del curso

        Public Function s_horario_curso(ByVal lngCodCurso As Long)

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                    "Select cod_curso, dia, hora_inicio, hora_fin " _
                    & "From Horario_Curso " _
                    & "Where cod_curso = [0] order by dia, hora_inicio"

            s_horario_curso = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        'consulta el c�digo de un curso dado su n�mero de registro
        '
        Public Function s_curso_contr_6(ByVal lngNroRegistro As Long, ByVal strEstados As String) As Long

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngNroRegistro
            arrParam(1) = strEstados
            Dim strWhere As String
            If strEstados <> "" Then strWhere = " And cod_estado_curso In ([1])"

            strQuery = _
                "Select cod_curso " _
                & "From Curso_Contratado " _
                & "Where nro_registro = [0] " _
                & strWhere

            s_curso_contr_6 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta el codigo interno de un curso contratado, el cual
        'recien ingresamos
        Public Function s_cod_curso_contr() As DataTable

            Dim strQuery As String

            strQuery = _
                    "Select Max(cod_curso) " _
                    & "From Curso_Contratado "

            s_cod_curso_contr = ConsultaSql(strQuery)
        End Function
        'Selecciona los ruts de los alumnos participantes en un curso.
        Public Function s_rut_partic(ByVal lngCodCurso As Long, Optional ByVal dblRutAlumno As Double = 0) As Object

            Dim strQuery, strWhere As String, arrParam(1)
            arrParam(0) = lngCodCurso
            strWhere = ""
            If dblRutAlumno <> 0 Then
                arrParam(1) = dblRutAlumno
                strWhere = strWhere & " AND rut_alumno = [1] "
            End If
            strQuery = _
                    "Select rut_alumno " _
                    & "From Participante " _
                    & "Where cod_curso = [0] " _
                    & strWhere

            s_rut_partic = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_alumno_curso(ByVal lngCodCurso As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                    "Select row_number() over (order by p.rut_alumno) as nFila, p.rut_alumno, pn.nombre, pn.ap_paterno, pn.ap_materno, " _
                    & "pn.fecha_nacim, p.cod_nivel_educ,(select nombre from nivel_educacional where cod_nivel_educ = p.cod_nivel_educ) nivel_educacional, pn.sexo, (p.porc_franquicia * 100) porc_franquicia, " _
                    & "p.cod_nivel_ocup,(select nombre from nivel_ocupacional where cod_nivel_ocup = p.cod_nivel_ocup) nivel_ocupacional, p.cod_region, p.viatico, p.traslado, (p.porc_asistencia * 100) porc_asistencia " _
                    & ",p.cod_comuna,isnull(p.cod_clasificador, 0) cod_clasificador, " _
                    & "sum(viatico * p.porc_franquicia) viatico_otic, sum(traslado * p.porc_franquicia) traslado_otic, " _
                    & "(p.viatico - sum(viatico * p.porc_franquicia)) viatico_emp, " _
                    & "(p.traslado - sum(traslado * p.porc_franquicia)) traslado_emp " _
                    & "From Participante p, Persona_Natural pn " _
                    & "Where p.rut_alumno = pn.rut And p.cod_curso = [0] " _
                    & "group by p.rut_alumno, pn.nombre, pn.ap_paterno, pn.ap_materno, " _
                    & "pn.fecha_nacim, p.cod_nivel_educ,pn.sexo, p.porc_franquicia, " _
                    & "p.cod_nivel_ocup, p.cod_region, p.viatico, p.traslado, p.porc_asistencia, p.cod_comuna, p.cod_clasificador "

            ''strQuery = _
            ''        "Select row_number() over (order by p.rut_alumno) as nFila, p.rut_alumno, pn.nombre, pn.ap_paterno, pn.ap_materno, " _
            ''        & "pn.fecha_nacim, p.cod_nivel_educ,(select nombre from nivel_educacional where cod_nivel_educ = p.cod_nivel_educ) nivel_educacional, pn.sexo, (p.porc_franquicia * 100) porc_franquicia, " _
            ''        & "p.cod_nivel_ocup,(select nombre from nivel_ocupacional where cod_nivel_ocup = p.cod_nivel_ocup) nivel_ocupacional, p.cod_region, p.viatico, p.traslado, (p.porc_asistencia * 100) porc_asistencia " _
            ''        & ",p.cod_comuna,isnull(p.cod_clasificador, 0) cod_clasificador, cc.valor_hora " _
            ''        & "From Participante p, Persona_Natural pn, curso_contratado cc " _
            ''        & "Where p.cod_curso=cc.cod_curso and p.rut_alumno = pn.rut And p.cod_curso = [0]"

            s_alumno_curso = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_alumno_curso2(ByVal lngCodCurso As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                    "Select  p.rut_alumno, (pn.nombre + ' ' +  pn.ap_paterno + ' ' + pn.ap_materno) nombre " _
                    & "From Participante p, Persona_Natural pn, curso_contratado cc " _
                    & "Where p.cod_curso=cc.cod_curso and p.rut_alumno = pn.rut And p.cod_curso = [0]"

            s_alumno_curso2 = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        ''Consulta el valor de la hora sence en un a�o espec�fico
        'Public Function s_val_hora_sence_agno(ByVal intAgno As Integer) As Long
        '    Dim strQuery As String

        '    strQuery = _
        '        "Select valor " _
        '        & "From Valor_Hora_Sence " _
        '        & "Where agno = " & intAgno

        '    s_val_hora_sence_agno = ValorSql(strQuery)
        'End Function
        'Consulta el valor de la hora sence de un curso contratado
        Public Function s_val_hora_curso(ByVal CodCurso As Long) As Double
            Dim strQuery As String, arrParam(0)
            arrParam(0) = CodCurso

            strQuery = _
                "Select isnull(valor_hora, 0) valor_hora " _
                & "From curso_contratado " _
                & "Where cod_curso = [0]"

            s_val_hora_curso = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_valor_hora_curso_sence(ByVal CodSence As String) As Double
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(CodSence)

            strQuery = _
                "Select isnull(valor_hora, 0) valor_hora " _
                & "From curso " _
                & "Where codigo_sence = [0]"

            s_valor_hora_curso_sence = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        ''Consulta el valor de la hora sence en un a�o ,modalidad  y curso espec�fico 
        'Public Function s_val_hora_sence_agno2(ByVal intAgno As Integer, ByVal intCodModalidad As Integer, ByVal strCodigoSence As String) As Long
        '    Dim strQuery As String, arrParam(0)
        '    arrParam(0) = StringSql(strCodigoSence)
        '    strQuery = _
        '        "Select valor " _
        '        & "From Valor_Hora_Sence " _
        '        & "Where agno = " & intAgno & " and cod_modalidad = " & intCodModalidad & " and codigo_sence = [0]"

        '    s_val_hora_sence_agno2 = ValorSql(SqlParam(strQuery, arrParam))
        'End Function
        'Consulta por el Indicador de Administracion No Lineal de una Empresa
        Public Function s_adm_no_lineal(ByVal lngRutEmpresa As Long) As Integer


            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutEmpresa

            strQuery = _
                "Select comp_adm_no_lineal " _
                & "From Empresa_Cliente " _
                & "Where rut = [0] "

            s_adm_no_lineal = ValorSql(SqlParam(strQuery, arrParam))

        End Function
        'Consulta por el Indicador de Administracion No Lineal de una Empresa
        Public Function s_cod_curso_desde_correl_interno(ByVal Correl As String) As Long


            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(Correl)

            strQuery = _
                "Select cod_curso From curso_Contratado " _
                & "Where correlativo_empresa = [0] "

            s_cod_curso_desde_correl_interno = ValorSql(SqlParam(strQuery, arrParam))

        End Function



        'Retorna los codigos de las cuentas de un cliente con los respectivos
        'montos que se le han cargado por el pago del curso
        Public Function s_montos_cuentas(ByVal lngCodCurso As Long) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                "Select cod_cuenta, sum(monto) as monto, rut_cliente, cod_tipo_tran " _
                & "From Transaccion " _
                & "Where cod_curso = [0] " _
                & "Group By rut_cliente, cod_cuenta, cod_tipo_tran "
            s_montos_cuentas = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Solicitud de Pagos A Terceros
        '

        'Retorna el rut de un tercero al que se le ha pedido el costeo de
        'un curso junto con el monto que se ha solicitado.
        Public Function s_monto_terceros(ByVal lngCodCurso As Long) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                "Select cast(s.rut_benefactor as varchar) rut_benefactor, s.monto, s.cod_estado_solicitud, s.monto_adm, isnull(tr.monto,s.monto) monto2, isnull(tr.cod_cuenta,0) as cta, s.cod_curso " _
                & "From Solicitud_Pago_Terceros s Left Join transaccion tr on(tr.nro_transaccion = s.nro_transaccion) " _
                & "Where s.cod_curso = [0] "
            s_monto_terceros = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_lista_sol_pago(ByVal lngCodCurso As Long) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                "Select s.rut_benefactor, pj.razon_social, s.monto, ept.nombre, isnull(tr.monto,s.monto) monto_utilizado, S.cod_estado_solicitud " _
                & "From Solicitud_Pago_Terceros s Left Join transaccion tr on(tr.nro_transaccion = s.nro_transaccion) , persona_juridica pj, estado_pago_terceros ept " _
                & "Where S.cod_curso = [0] And pj.Rut = S.rut_benefactor And ept.cod_sol_pago_ter = S.cod_estado_solicitud"
            s_lista_sol_pago = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Entrega el rut, digito verificador y el tipo de una Persona
        Public Function s_persona(ByVal lngRut As Long) As Object
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut

            strQuery = _
                "select rut, dig_verif, tipo " _
                & " From Persona " _
                & "Where rut = [0] "
            s_persona = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta los datos de una Persona Natural por el rut

        Public Function s_pers_nat(ByVal lngRut As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut

            strQuery = _
                    "Select pn.rut, pn.nombre, pn.ap_paterno, pn.ap_materno, pn.fecha_nacim, pn.cod_nivel_educ, " _
                    & "pn.sexo, pn.porc_franquicia, pn.cod_nivel_ocup, pn.cod_region, pn.rut_empresa, pj.razon_social,pn.cod_comuna, " _
                    & "isnull(pn.cod_pais,1) cod_pais, isnull(pn.fono,'') fono, isnull(pn.email,'') email " _
                    & "From Persona_Natural pn, Persona_Juridica pj " _
                    & "Where pn.rut = [0] And pn.rut_empresa=pj.rut "

            s_pers_nat = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta los datos de un alumno participante en un curso,
        'por el codigo interno del curso y el rut del alumno.
        'Supone que el alumno existe en las tabla Participante y Persona_Natural
        Public Function s_partic_curso(ByVal lngCodCurso As Long, _
                                       ByVal lngRutAlumno As Long) As DataTable

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutAlumno

            strQuery = _
                    "Select p.rut_alumno, pn.nombre, pn.ap_paterno, pn.ap_materno, " _
                    & "pn.fecha_nacim, p.cod_nivel_educ, pn.sexo, p.porc_franquicia, " _
                    & "p.cod_nivel_ocup, p.cod_region, p.viatico, p.traslado, p.porc_asistencia " _
                    & ",p.cod_comuna,isnull(p.cod_clasificador, 0) cod_clasificador, pn.cod_pais, " _
                    & "isnull(pn.fono, '') fono, isnull(pn.email, '') email " _
                    & "From Participante p, Persona_Natural pn " _
                    & "Where p.rut_alumno = pn.rut And p.cod_curso = [0] And " _
                    & "p.rut_alumno = [1] "

            s_partic_curso = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        'Selecciona el maximo correlativo para un a�o determinado en la tabla Curso Contratado
        Public Function s_max_correlativo(ByVal lngAgno As Long)

            Dim auxiliar As Object
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngAgno

            strQuery = _
                    "Select Max(correlativo) " _
                    & "From Curso_Contratado " _
                    & "Where agno = [0] "

            auxiliar = ValorSql(SqlParam(strQuery, arrParam))

            If IsDBNull(auxiliar) Then
                s_max_correlativo = 0
            Else
                s_max_correlativo = auxiliar
            End If

        End Function
        'Retorna los maximos numeros de transacciones, rut del cliente, codigo de cuenta,
        'y codigo de estado de transaccion para cierto estado de transaccion
        'cierta cuenta y cierto cliente
        Public Function s_num_rut_cta_est_tran(ByVal lngCodCurso As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                "Select nro_transaccion, rut_cliente, cod_cuenta, cod_estado_tran, monto, cod_tipo_tran " _
                & "From Transaccion tr1 " _
                & "Where cod_curso = [0] " _
                & "And nro_transaccion = " _
                & " (Select Max(tr2.nro_transaccion) From Transaccion tr2 " _
                & "  Where tr2.cod_curso = [0] " _
                & "  And tr2.cod_cuenta = tr1.cod_cuenta " _
                & "  And tr2.rut_cliente = tr1.rut_cliente " _
                & "  And tr2.cod_tipo_tran = tr1.cod_tipo_tran) " _
                & "And monto > 0 "
            s_num_rut_cta_est_tran = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta el saldo de alguna de las cuentas de un cliente
        Public Function s_saldo_cuenta(ByVal lngRutCliente As Long, _
                                       ByVal intCodCuenta As Integer) As Long

            Dim dtauxiliar As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodCuenta

            strQuery = _
                "Select saldo " _
                & "From Cuenta_Cliente " _
                & "Where rut_cliente = [0] And cod_cuenta = [1] "
            dtauxiliar = ValorSql(SqlParam(strQuery, arrParam))
            If dtauxiliar > 0 Then
                s_saldo_cuenta = CLng(dtauxiliar)
            Else
                s_saldo_cuenta = 0
            End If
            'If TamanoArreglo2(dtauxiliar) > 0 Then
            '    s_saldo_cuenta = CLng(dtauxiliar.Rows(0)(0))
            'Else
            '    s_saldo_cuenta = 0
            'End If
            'dtauxiliar = ConsultaSql(SqlParam(strQuery, arrParam))       
            's_saldo_cuenta = CLng(dtauxiliar.Rows(0)(0))
        End Function
        Public Function s_saldo_cuenta2(ByVal lngRutCliente As Long) As Long

            Dim dtauxiliar As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutCliente
            strQuery = _
                "Select saldo " _
                & "From Cuenta_Cliente " _
                & "Where rut_cliente = [0] And cod_cuenta = 3 "
            dtauxiliar = ValorSql(SqlParam(strQuery, arrParam))
            If dtauxiliar > 0 Then
                s_saldo_cuenta2 = CLng(dtauxiliar)
            Else
                s_saldo_cuenta2 = 0
            End If

        End Function

        'consulta los registros de un otec
        Public Function s_Otec_PersonaJuridica(ByVal lngRut As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut

            strQuery = _
                "Select persona.dig_verif,persona_juridica.nom_fantasia,persona_juridica.razon_social," _
                & "persona_juridica.sigla,persona_juridica.email,persona_juridica.fono," _
                & "persona_juridica.fono2,persona_juridica.fax," _
                & "persona_juridica.direccion,persona_juridica.cod_comuna,comuna.nombre as nombre_comuna," _
                & "persona_juridica.casilla,persona_juridica.ciudad,persona_juridica.SitioWeb," _
                & "region.nombre as nombre_region,Otec.nombre_contacto , Otec.cargo_contacto, " _
                & "Otec.fono_contacto,otec.email_contacto,otec.tasa_descuento," _
                & "otec.fax_contacto,otec.cod_rubro,otec.nom_rep1,otec.rut_rep1," _
                & "otec.dig_verif_rep1,otec.nom_rep2,otec.rut_rep2,otec.dig_verif_rep2," _
                & "otec.gerente_general,otec.gerente_RRHH,otec.area_cobranzas," _
                & "otec.giro,otec.cod_act_economica,otec.num_convenio,rubro.nombre as nombre_rubro " _
                & ",persona_juridica.nro_direccion " _
                & " From persona_juridica,persona,comuna,provincia,region,otec,rubro " _
                & "Where (persona_juridica.Rut = [0] or [0] = 0) and " _
                & " persona_juridica.rut = Otec.rut and " _
                & " persona_juridica.rut = persona.rut and " _
                & " persona_juridica.cod_comuna=comuna.cod_comuna and " _
                & " comuna.cod_provincia=provincia.cod_provincia and " _
                & " provincia.cod_region=region.cod_region and " _
                & " otec.cod_rubro=rubro.cod_rubro "

            s_Otec_PersonaJuridica = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_factura(ByVal lngCodCurso) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso
            strQuery = _
                "Select cod_curso, cod_estado_fact, num_factura, fecha, fecha_recepcion, " _
                & "fecha_pago, monto , isnull(num_voucher,0) num_voucher, isnull(observacion,'') observacion " _
                & "From factura " _
                & "Where cod_curso = [0]"
            s_factura = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        ' Cursos Sence
        '
        Public Function s_curso_1(ByVal strCodigoSence) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigoSence)
            'strQuery = _
            '    "Select Curso.nombre, rut_otec, area, especialidad, dur_cur_teorico, " _
            '    & "dur_cur_prac, num_max_part, nombre_sede, fono_sede, direccion, Curso.cod_comuna,  " _
            '    & "pendiente, Comuna.nombre,isnull(valor_curso,0) as valor_curso, elearning, " _
            '    & "valor_hora_Sence.cod_modalidad, valor_hora_Sence.valor valor_hora, valor_hora_Sence.vigente " _
            '    & "From Curso, Comuna, valor_hora_sence " _
            '    & "Where curso.cod_comuna=comuna.cod_comuna and valor_hora_sence.codigo_sence=curso.codigo_sence " _
            '    & "and valor_hora_Sence.agno= year(getdate()) and curso.codigo_sence = [0] "

            'strQuery = _
            '        "Select Curso.nombre, rut_otec, area, especialidad, dur_cur_teorico, dur_cur_prac, num_max_part, nombre_sede, " _
            '        & "fono_sede, direccion, Curso.cod_comuna,  pendiente, Comuna.nombre,isnull(valor_curso,0) " _
            '        & "as valor_curso, valor_hora_Sence.valor valor_hora, valor_hora_Sence.vigente " _
            '        & "From Curso, Comuna, valor_hora_sence " _
            '        & "Where curso.cod_comuna=comuna.cod_comuna " _
            '        & "and valor_hora_Sence.agno= year(getdate()) and curso.codigo_sence = [0] "
            strQuery = _
                    "Select Curso.nombre, rut_otec, area, especialidad, dur_cur_teorico, dur_cur_prac, num_max_part, nombre_sede, " _
                    & "fono_sede, direccion, Curso.cod_comuna,  pendiente, Comuna.nombre,isnull(valor_curso,0) " _
                    & "as valor_curso,  isnull(curso.valor_hora,0) valor_hora,curso.cod_modalidad, isnull(dur_cur_elearning,0) dur_cur_elearning " _
                    & "From Curso, Comuna " _
                    & "Where curso.cod_comuna=comuna.cod_comuna " _
                    & "and curso.codigo_sence = [0] "

            s_curso_1 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
      
        Public Function s_saldo_inicial_por_cuenta(ByVal mintCodCuenta As Integer, _
                                          ByVal mlngRutCliente As Long, _
                                          ByVal dtmFecha As Date) As Long

            Dim strQuery As String, arrParam(2)

            arrParam(0) = mintCodCuenta
            arrParam(1) = mlngRutCliente
            arrParam(2) = FechaVbABd(dtmFecha)
            strQuery = _
                    "select isnull(sum(monto),0) " _
                    & "From transaccion " _
                    & "where fecha_hora = [2]" _
                    & "And cod_tipo_tran in (1,3) " _
                    & "And cod_cuenta = [0] " _
                    & "And rut_cliente = [1] "
            s_saldo_inicial_por_cuenta = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'consulta los datos de un cliente
        Public Function s_persona_juridica2(ByVal lngRutEmpresa As Long, _
                                            Optional ByVal lngRutUsuario As Long = 0) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutEmpresa
            arrParam(1) = lngRutUsuario

            'Dim strWhere As String
            'If lngRutUsuario = 0 Then
            '    strWhere = ""
            'Else 'chequea que el usuario tiene permiso para ver la empresa
            '    strWhere = " And Exists (Select * From V_Cliente_Permiso " _
            '               & " Where rut_usuario = [1] And rut_empresa = [0]) "
            'End If

            strQuery = _
                "Select persona_juridica.rut as RutEmpresa,persona.dig_verif as DigitoEmpresa," _
                & "nom_fantasia,razon_social, sigla,persona_juridica.email,fono,isnull(fono2, 0) fono2,isnull(fax, 0) fax," _
                & "direccion,comuna.cod_comuna, isnull(casilla, '') casilla,ciudad, isnull(SitioWeb, '') SitioWeb," _
                & "comuna.nombre as NombreComuna, region.cod_region," _
                & "region.nombre as NombreRegion, ec.costo_admin,ec.comp_adm_no_lineal," _
                & "isnull(ec.num_empleados, 0) num_empleados," _
                & "isnull(ec.nom_contacto, '') nom_contacto, isnull(ec.cargo_contacto, '') cargo_contacto, isnull(ec.fono_contacto, '') fono_contacto," _
                & "isnull(ec.anexo_contacto, '') anexo_contacto, isnull(ec.email_contacto, '') email_contacto, isnull(ec.nom_rep1, '') nom_rep1," _
                & "isnull(ec.rut_rep1, 0) rut_rep1, isnull(ec.dig_verif_rep1, '') dig_verif_rep1, isnull(ec.nom_rep2, '') nom_rep2," _
                & "isnull(ec.rut_rep2, 0) rut_rep2, isnull(ec.dig_verif_rep2, '') dig_verif_rep2, isnull(ec.gerente_general, '') gerente_general," _
                & "isnull(ec.gerente_rrhh, '') gerente_rrhh, isnull(ec.area_cobranzas, '') area_cobranzas, isnull(ec.giro, '') giro, isnull(ec.cod_act_economica, '') cod_act_economica, rubro.cod_rubro," _
                & "rubro.nombre as NombreRubro, estado_cliente.cod_estado_cliente, estado_cliente.nombre,ec.cod_sucursal," _
                & "ec.ventas_anuales, isnull(ec.email_gerente_rrhh, '') email_gerente_rrhh," _
                & "isnull(ec.gerente_finanzas, '') gerente_finanzas, isnull(ec.email_gerente_finanzas, '') email_gerente_finanzas, isnull(ec.fono_cobranzas, '') fono_cobranzas," _
                & "isnull(sucursal.nombre, '') nombre, isnull(ec.rut_holding, 0) rut_holding, isnull(nro_direccion, '') nro_direccion, " _
                & " isnull(ec.rut_contacto, 0) rut_contacto, isnull(apellido_contacto, '') apellido_contacto " _
                & " From persona_juridica, persona, Comuna, provincia, Region," _
                & " empresa_cliente ec, rubro,estado_cliente, sucursal " _
                & "Where (persona_juridica.Rut = [0] or [0] = 0) And " _
                & " persona_juridica.rut = persona.rut and persona_juridica.cod_comuna=comuna.cod_comuna and " _
                & " comuna.cod_provincia=provincia.cod_provincia and provincia.cod_region=region.cod_region and " _
                & " persona_juridica.rut=ec.rut and ec.cod_rubro = rubro.cod_rubro and " _
                & " ec.cod_estado_cliente = estado_cliente.cod_Estado_cliente and " _
                & " ec.cod_sucursal=sucursal.cod_sucursal " '_
            '& strWhere
            s_persona_juridica2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        ''consulta los registros de Empresas segun criterio de busqueda
        Public Function s_buscar_empresa(ByVal lngRut As Long, _
                                                  ByVal strNomFantasia As String, _
                                                  ByVal strRazonSocial As String, _
                                                  ByVal lngRutEjecutivo As Long) As Object
            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRut
            arrParam(1) = SubStringSql(strNomFantasia)
            arrParam(2) = SubStringSql(strRazonSocial)
            arrParam(3) = lngRutEjecutivo
            Dim strWhere As String
            If (lngRut = "") Then
                strWhere = "rut > 0 "
            Else
                strWhere = "rut = [0]"
            End If

            strQuery = _
                 "select rut,nom_fantasia, razon_social , sigla ,fono , direccion " _
                 & "from persona_juridica, ejecutivo ej " _
                 & " where " & strWhere _
                 & "and razon_social = [2] or razon_social like '%' " _
                 & " and nom_fantasia like '%' or nom_fantasia = [1] " _
                 & " and ej.rut_ejecutivo = [3]"
            s_buscar_empresa = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'consulta los registros de Empresas segun criterio de busqueda
        Public Function s_persona_juridica(ByVal lngRut As Long, _
                                           ByVal strNomFantasia As String, _
                                           ByVal strRazonSocial As String, _
                                           ByVal lngRutEjecutivo As Long) As Object
            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRut
            arrParam(1) = SubStringSql(strNomFantasia)
            arrParam(2) = SubStringSql(strRazonSocial)
            arrParam(3) = lngRutEjecutivo

            Dim strWhere, strFrom, strSelect As String
            strWhere = ""
            strFrom = ""
            strSelect = ""
            If lngRutEjecutivo <> gValorNumNulo Then
                strWhere = strWhere _
                    & " and persona_juridica.rut = ejecutivo.rut_empresa and " _
                    & " ejecutivo.rut_ejecutivo = [3]"
                strFrom = " , ejecutivo "
                strSelect = " ,ejecutivo.rut_ejecutivo "
            End If

            strQuery = _
                "Select persona_juridica.rut,persona.dig_verif, nom_fantasia,razon_social,isnull(sigla,'')as sigla, " _
                & "isnull(persona_juridica.email,'') as email,isnull(fono,0) as fono ,isnull(fono2,0) as fono2, isnull(fax,0) as fax, " _
                & "isnull(direccion,'') as direccion ,comuna.cod_comuna,isnull(casilla,'') as casilla ,ciudad,isnull(SitioWeb,'') as sitio_web, " _
                & "comuna.nombre as NombreComuna,region.cod_region, region.nombre as NombreRegion,ec.costo_admin,ec.comp_adm_no_lineal, " _
                & "isnull(ec.num_empleados,0) num_empleados, isnull(ec.rut_contacto,0) as rut_contacto, isnull(ec.nom_contacto,'') as nombre_contacto , " _
                & "isnull(ec.apellido_contacto,'') as apellido_contacto, isnull(ec.cargo_contacto,'') as cargo_contacto ,isnull(ec.fono_contacto,0) as fono_contacto, " _
                & "isnull(ec.anexo_contacto,0) as anexo_contacto ,isnull(ec.email_contacto,'') as email_contacto , " _
                & "isnull(ec.nom_rep1,'') as nom_representante1 ,isnull(ec.rut_rep1,0) as rut_representante1 ," _
                & "isnull(ec.dig_verif_rep1,'') dig_verif_representante1 ,isnull(ec.nom_rep2,'') as nom_representante2 ," _
                & "isnull(ec.rut_rep2,0) as rut_representante2 ,isnull(ec.dig_verif_rep2,'') dig_verif_representante2 ," _
                & "isnull(ec.gerente_general,'') as gerente_general ,isnull(ec.gerente_rrhh,'') as gerente_rrhh, " _
                & "isnull(ec.area_cobranzas,'') as area_cobranza ,isnull(ec.giro,'') as giro, " _
                & "isnull(ec.cod_act_economica,0) as cod_act_economica ,isnull(rubro.cod_rubro,0) as cod_rubro ," _
                & "isnull(rubro.nombre,'') as rubro, " _
                & "(Select isnull(us.nombres,'') From Ejecutivo ej, Usuario us " _
                & " Where us.Rut = ej.rut_ejecutivo And ej.rut_empresa = ec.rut) as nombre_ejecutivo,  " _
                & "isnull(ec.email_gerente_rrhh,'') as email_gerente_rrhh, isnull(ec.gerente_finanzas,'') as gerente_finanzas, " _
                & "isnull(email_gerente_finanzas,'') as email_gerente_finanzas,isnull(ec.fono_cobranzas,0) as fono_cobranza , isnull(ec.rut_holding,0) as rut_holding "
            strQuery = strQuery & strSelect _
                & " From persona_juridica, persona, Comuna, provincia, Region," _
                & " empresa_cliente ec, rubro  "
            strQuery = strQuery & strFrom _
                & "Where (persona_juridica.Rut = [0] or [0] = 0) And " _
                & "(nom_fantasia like [1] Or [1] = '') and (razon_social like [2] Or [2] = '') and " _
                & " persona_juridica.rut = persona.rut and persona_juridica.cod_comuna=comuna.cod_comuna and " _
                & " comuna.cod_provincia=provincia.cod_provincia and provincia.cod_region=region.cod_region and " _
                & " persona_juridica.rut=ec.rut and ec.cod_rubro = rubro.cod_rubro and  " _
                & " persona_juridica.rut=ec.rut and ec.cod_rubro = rubro.cod_rubro order by persona_juridica.rut "
            strQuery = strQuery & strWhere
            s_persona_juridica = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'consulta los registros de un otec
        Public Function s_Otec(ByVal lngRut As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut

            strQuery = _
                "Select persona.dig_verif,Otec.nombre_contacto , Otec.cargo_contacto, " _
                & "Otec.fono_contacto,otec.email_contacto,otec.tasa_descuento," _
                & "otec.fax_contacto,otec.cod_rubro,otec.nom_rep1,otec.rut_rep1," _
                & "otec.dig_verif_rep1,otec.nom_rep2,otec.rut_rep2,otec.dig_verif_rep2," _
                & "otec.gerente_general,otec.gerente_RRHH,otec.area_cobranzas," _
                & "otec.giro,otec.cod_act_economica,otec.num_convenio,rubro.nombre " _
                & " From persona,otec ,rubro " _
                & "Where (otec.Rut = [0] or [0] = 0) and " _
                & " otec.rut = persona.rut and otec.cod_rubro=rubro.cod_rubro"
            s_Otec = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'consulta por un otec en particular
        Public Function s_OtecTodos(ByVal lngRut As Long) As Long

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut

            strQuery = _
                "select pj.rut, pj.razon_social " _
                & "from persona_juridica pj, otec o " _
                & "where pj.rut= o.rut " _
                & "and pj.rut = [0]"
            s_OtecTodos = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta por estado cliente (1,2,3 -> bloqueado)
        Public Function s_estado_cliente(ByVal lngRut As Long) As DataTable
            Dim strQuery As String, arrParam(0)

            arrParam(0) = lngRut

            strQuery = _
                "Select cod_estado_cliente " _
                & "From empresa_cliente " _
                & "Where rut=[0] "

            s_estado_cliente = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        '''' Consulta para cargar saldos de cursos completos
        Public Function s_gastos_cursos_completos(ByVal lngRut As Long, _
                                                   ByVal intCodCuenta As Integer, _
                                                   ByVal intagno As Integer) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intagno
            strQuery = _
                "Select " _
                & " isnull(Sum(monto),0) " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_parcial Is Null " _
                & " And cod_curso_compl Is Null " _
                & " And agno = [2]) " _
                & " And Cod_Cuenta = [1] " _
                & " And rut_cliente = [0] "
            s_gastos_cursos_completos = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Consulta para cargar saldos de cursos parciales
        Public Function s_gastos_cursos_parciales(ByVal lngRut As Long, _
                                                   ByVal intCodCuenta As Integer, _
                                                   ByVal intagno As Integer) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intagno
            strQuery = _
                "Select " _
                & " isnull(Sum(monto),0) " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_compl Is Not Null " _
                & " And agno = [2]) " _
                & " And Cod_Cuenta = [1] " _
                & " And rut_cliente = [0] "
            s_gastos_cursos_parciales = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' Consulta para cargar saldos de cursos complementarios
        Public Function s_gastos_cursos_complementarios(ByVal lngRut As Long, _
                                                   ByVal intCodCuenta As Integer, _
                                                   ByVal intagno As Integer) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = intagno

            strQuery = _
                "Select " _
                & " isnull(Sum(monto),0) " _
                & " From transaccion " _
                & " Where cod_curso in (Select cod_curso From curso_contratado " _
                & " Where cod_curso_parcial Is Not Null " _
                & " And agno = [2]) " _
                & " And Cod_Cuenta = [1] " _
                & " And rut_cliente = [0] "
            s_gastos_cursos_complementarios = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'busca transacciones realizadas entre un periodo de tiempo
        'desde fecha inicio hasta fecha termino para un cliente y cuenta en particular
        'si la lista de ruts no es vac�a, obtiene los movimientos de la lista indicada
        Public Function s_busqueda_cuentas(ByVal lngRut As Long, _
                                           ByVal intCodCuenta As Integer, _
                                           ByVal FechaInicio As Date, _
                                           ByVal FechaTermino As Date, _
                                           ByVal strListaRuts As String) As DataTable

            Dim strQuery As String, arrParam(4)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = FechaVbABd(FechaInicio)
            arrParam(3) = FechaVbABd(FechaTermino)
            arrParam(4) = strListaRuts

            Dim strWhere As String
            If strListaRuts = "" Then
                strWhere = "rut_cliente = [0]"
            Else
                strWhere = "rut_cliente In ([4])"
            End If
            'If intCodCuenta = 3 Then
            '    strWhere = strWhere & " and tr.cod_tipo_tran not in (1) "
            'End If

            strQuery = _
                "Select tr.nro_transaccion, " _
                & "tr.cod_tipo_tran ,tt.nombre as nom_transaccion, " _
                & "tr.cod_estado_tran,et.nombre as estado_transaccion, " _
                & "tr.fecha_hora,tr.monto,tr.rut_cliente," _
                & "isnull(tr.cod_curso, 0) cod_curso,isnull(tr.cod_aporte, 0) cod_aporte, " _
                & "rtrim(tr.descripcion) descripcion " _
                & " From Transaccion tr,estado_transaccion et,tipo_transaccion tt " _
                & "Where " & strWhere _
                & " And cod_cuenta = [1] " _
                & " And tr.cod_tipo_tran = tt.cod_tipo_tran " _
                & " And tr.cod_estado_tran = et.cod_estado_tran " _
                & " And Fecha_Hora >= [2] And Fecha_Hora < [3] " _
                & " ORDER BY tr.fecha_hora "
            s_busqueda_cuentas = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        ''Public Function s_busqueda_cuentas(ByVal lngRut As Long, _
        ''                                  ByVal intCodCuenta As Integer, _
        ''                                  ByVal FechaInicio As Date, _
        ''                                  ByVal FechaTermino As Date, _
        ''                                  ByVal strListaRuts As String) As DataTable

        ''    Dim strQuery As String, arrParam(5)
        ''    arrParam(0) = lngRut
        ''    arrParam(1) = intCodCuenta
        ''    arrParam(2) = FechaVbABd(FechaInicio)
        ''    arrParam(3) = FechaVbABd(FechaTermino)
        ''    arrParam(4) = strListaRuts
        ''    arrParam(5) = FechaInicio.Year.ToString

        ''    Dim strWhere, strWhere2 As String
        ''    If strListaRuts = "" Then
        ''        strWhere = "rut_cliente = [0]"
        ''    Else
        ''        strWhere = "rut_cliente In ([4])"
        ''    End If

        ''    strQuery = _
        ''        "Select tr.nro_transaccion, " _
        ''        & "tr.cod_tipo_tran ,tt.nombre as nom_transaccion, " _
        ''        & "tr.cod_estado_tran,et.nombre as estado_transaccion, " _
        ''        & "tr.fecha_hora,tr.monto,tr.rut_cliente," _
        ''        & "isnull(tr.cod_curso, 0) cod_curso,isnull(tr.cod_aporte, 0) cod_aporte, " _
        ''        & "rtrim(tr.descripcion) descripcion " _
        ''        & " From Transaccion tr,estado_transaccion et,tipo_transaccion tt " _
        ''        & "Where " & strWhere _
        ''        & " And cod_cuenta = [1] " _
        ''        & " And tr.cod_tipo_tran = tt.cod_tipo_tran " _
        ''        & " And tr.cod_estado_tran = et.cod_estado_tran " _
        ''        & " And Fecha_Hora >= [2] And Fecha_Hora < [3] and tr.cod_tipo_tran <> 1 " _
        ''        & " UNION " _
        ''        & "Select tr.nro_transaccion, " _
        ''        & "tr.cod_tipo_tran ,tt.nombre as nom_transaccion, " _
        ''        & "tr.cod_estado_tran,et.nombre as estado_transaccion, " _
        ''        & "tr.fecha_hora,tr.monto,tr.rut_cliente," _
        ''        & "isnull(tr.cod_curso, 0) cod_curso,isnull(tr.cod_aporte, 0) cod_aporte, " _
        ''        & "rtrim(tr.descripcion) descripcion " _
        ''        & " From Transaccion tr,estado_transaccion et,tipo_transaccion tt, aporte ap " _
        ''        & "Where " & strWhere _
        ''        & " And tr.cod_cuenta = [1] " _
        ''        & " And tr.cod_tipo_tran = tt.cod_tipo_tran " _
        ''        & " And tr.cod_estado_tran = et.cod_estado_tran and tr.cod_aporte=ap.cod_aporte " _
        ''        & " and tr.cod_tipo_tran = 1 And ap.agno = [5] "
        ''    s_busqueda_cuentas = ConsultaSql(SqlParam(strQuery, arrParam))
        ''End Function


        Public Function s_regiones_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_region, nombre " _
                & "From  Region "
            s_regiones_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_regiones_todos_por_codigo() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_region, cod_region as nombre " _
                & "From  Region "
            s_regiones_todos_por_codigo = ConsultaSql(strQuery)
        End Function
        Public Function s_nivel_ocupacional_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "select cod_nivel_ocup,cast(cod_nivel_ocup as varchar) + '-' + nombre as nombre from nivel_ocupacional"
            s_nivel_ocupacional_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_nivel_ocupacional_todos_por_codigo() As DataTable
            Dim strQuery As String
            strQuery = _
                "select cod_nivel_ocup,cod_nivel_ocup as nombre from nivel_ocupacional"
            s_nivel_ocupacional_todos_por_codigo = ConsultaSql(strQuery)
        End Function
        Public Function s_nivel_educacional_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "select cod_nivel_educ,cast(cod_nivel_educ as varchar) + '-' + nombre as nombre from nivel_educacional"
            s_nivel_educacional_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_nivel_educacional_todos_por_codigo() As DataTable
            Dim strQuery As String
            strQuery = _
                "select cod_nivel_educ,cod_nivel_educ as nombre from nivel_educacional"
            s_nivel_educacional_todos_por_codigo = ConsultaSql(strQuery)
        End Function
        Public Function s_rubros_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_rubro, nombre " _
                & "From  rubro "
            s_rubros_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_sucursales_todos() As DataTable

            Dim strQuery As String
            strQuery = _
                "Select cod_sucursal, nombre " _
                & "From  Sucursal " _
                & "Order by nombre "
            s_sucursales_todos = ConsultaSql(strQuery)

        End Function
        Public Function s_supervisor_todos() As DataTable
            Dim strQuery As String
            ' 4 es el codigo del perfil de supervisor
            strQuery = _
                "Select Distinct u.rut, u.nombres " _
                & "From  usuario u, perfil_usuario pu " _
                & "Where pu.rut = u.rut " _
                & "And pu.cod_perfil = 4 " _
                & "Order by u.nombres "
            s_supervisor_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_ejecutivo_todos() As DataTable
            Dim strQuery As String
            ' 3,11 y 12 son el codigo de los perfiles de ejecutivo, ejecutivoReg Ing/mod y ejecutivo Reg Aut.
            strQuery = _
                "Select Distinct u.rut, u.nombres " _
                & "From  usuario u, perfil_usuario pu " _
                & "Where pu.rut = u.rut " _
                & "And (pu.cod_perfil = 3 Or pu.cod_perfil = 11 Or pu.cod_perfil = 12) " _
                & "Order by u.nombres "
            s_ejecutivo_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_director_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select Distinct u.rut, u.nombres " _
                & "From  usuario u, perfil_usuario pu " _
                & "Where pu.rut = u.rut " _
                & "And pu.cod_perfil = 8 " _
                & "Order by u.nombres "
            s_director_todos = ConsultaSql(strQuery)
        End Function
        'Estados del cliente => Activo o Inactivo
        Public Function s_estados_cliente() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_estado_cliente, nombre " _
                & "From  estado_cliente " _
                & "Order by cod_estado_cliente "

            s_estados_cliente = ConsultaSql(strQuery)

        End Function
        'entrega el nombre y rut del ejecutivo asociado a una empresa(persona_juridica)
        Public Function s_ejecutivo(ByVal lngRut As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut

            strQuery = _
                "select ejecutivo.rut_ejecutivo, usuario.nombres, " _
                & " usuario.email, usuario.telefono, usuario.fax " _
                & " From ejecutivo, Usuario " _
                & "Where (ejecutivo.rut_empresa = [0] or [0] = 0) " _
                & "And ejecutivo.rut_ejecutivo=usuario.rut "

            s_ejecutivo = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'filiales de un rut (holding)
        Public Function s_clientes_asociados(ByVal lngRutCliente As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutCliente

            strQuery = _
                " Select ec.rut, pj.razon_social, '', 0 " _
                & " From Empresa_Cliente ec, Persona_Juridica pj " _
                & " Where ec.rut = [0] " _
                & " And pj.rut = [0] " _
                & " Union " _
                & " Select ec.rut, (SPACE(2) + '  --- ' + pj.razon_social) razon_social, rtrim(ec.rut_holding), 1 " _
                & " From Empresa_Cliente ec, Persona_Juridica pj " _
                & " Where ec.rut_holding = [0] " _
                & " And ec.rut = pj.rut " _
                & " Union " _
                & " Select ec1.rut, (SPACE(2) + '  --- ' + pj.razon_social) razon_social, rtrim(ec2.rut_holding) + rtrim(ec1.rut_holding), 2 " _
                & " From Empresa_Cliente ec1, Empresa_Cliente ec2, Persona_Juridica pj " _
                & " Where ec2.rut_holding = [0] " _
                & " And ec1.rut_holding = ec2.rut " _
                & " And ec1.rut = pj.rut " _
                & " Union " _
                & " Select ec1.rut, (SPACE(2) + '  --- ' + pj.razon_social) razon_social, rtrim(ec3.rut_holding) + rtrim(ec2.rut_holding) + rtrim(ec1.rut_holding), 3 " _
                & " From Empresa_Cliente ec1, Empresa_Cliente ec2, Empresa_Cliente ec3, Persona_Juridica pj " _
                & " Where ec3.rut_holding = [0] " _
                & " And ec2.rut_holding = ec3.rut " _
                & " And ec1.rut_holding = ec2.rut " _
                & " And ec1.rut = pj.rut " _
                & " Order By 3"
            s_clientes_asociados = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'empresas madres de un cliente
        Public Function s_clientes_holding(ByVal lngRutCliente As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutCliente

            strQuery = _
                " Select ec.rut_holding, pj.razon_social, '', -1 " _
                & " From Empresa_Cliente ec, Persona_Juridica pj " _
                & " Where ec.rut = [0] " _
                & " And ec.rut_holding = pj.rut " _
                & " Union " _
                & " Select ec1.rut_holding, pj.razon_social, rtrim(ec1.rut), -2 " _
                & " From Empresa_Cliente ec1, Empresa_Cliente ec2, Persona_Juridica pj " _
                & " Where ec2.rut = [0] " _
                & " And ec1.rut = ec2.rut_holding " _
                & " And ec1.rut_holding = pj.rut " _
                & " Union " _
                & " Select ec1.rut_holding, pj.razon_social, rtrim(ec2.rut) + rtrim(ec1.rut), -3 " _
                & " From Empresa_Cliente ec1, Empresa_Cliente ec2, Empresa_Cliente ec3, Persona_Juridica pj " _
                & " Where ec3.rut = [0] " _
                & " And ec2.rut = ec3.rut_holding " _
                & " And ec1.rut = ec2.rut_holding " _
                & " And ec1.rut_holding = pj.rut " _
                & " Order By 3 Desc"
            s_clientes_holding = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_saldo_inicial_congelados2008(ByVal strListaRuts As String) As Double
            Dim strQuery As String, arrParam(0)
            If strListaRuts = "" Then
                arrParam(0) = 0
            Else
                arrParam(0) = strListaRuts
            End If

            strQuery = _
                "Select isnull(sum(t.monto * -1) - (select isnull(sum(monto),0) from transaccion " _
                & "Where cod_traspaso in( select cod_traspaso from transaccion " _
                & "Where year(fecha_hora)=2010 and month(fecha_hora)<=6 " _
                & "and rut_cliente in ([0]) and cod_cuenta in(4,5) and cod_tipo_tran=4 " _
                & "and monto<0 ) and cod_cuenta=7),0) from transaccion t " _
                & "where  year(fecha_hora)=2009 and t.rut_cliente in ([0]) and t.cod_cuenta in(4) " _
                & "and t.cod_tipo_tran=3 and t.monto < 0 "

            s_saldo_inicial_congelados2008 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_cargos_congelados2008(ByVal strListaRuts As String) As Double
            Dim strQuery As String, arrParam(0)
            If strListaRuts = "" Then
                arrParam(0) = 0
            Else
                arrParam(0) = strListaRuts
            End If
            strQuery = _
                "Select isnull(sum(tt.monto),0)as cargos " _
                & "From transaccion tt,empresa_cliente ec where cod_curso in " _
                & "( select cod_curso from curso_contratado where agno=2010 " _
                & "and ((year(fecha_ingreso)=2010 and month(fecha_ingreso) " _
                & "between 1 and 6 )or(year(fecha_ingreso)=2009 " _
                & "and month(fecha_ingreso) between 1 and 12 )) " _
                & "and cod_estado_curso in(1,3,4,5,6,7,9,11) ) " _
                & "and tt.cod_cuenta in (4,5) and tt.rut_cliente=*ec.rut " _
                & "and ec.rut in ([0]) group by ec.rut"

            s_cargos_congelados2008 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_saldo_inicial_congelados2009(ByVal strListaRuts As String) As Double
            Dim strQuery As String, arrParam(0)
            If strListaRuts = "" Then
                arrParam(0) = 0
            Else
                arrParam(0) = strListaRuts
            End If
            strQuery = _
                "select isnull(sum(t.monto * -1) - (select isnull(sum(monto),0)  " _
                & "from transaccion where cod_traspaso in( select cod_traspaso from transaccion " _
                & "where year(fecha_hora)=2010 and month(fecha_hora)>6 and rut_cliente in ([0]) " _
                & "and cod_cuenta in(4,5) and cod_tipo_tran=4 " _
                & "and monto<0 ) and cod_cuenta=7),0 ) from transaccion t " _
                & "where  year(fecha_hora)=2009 and t.rut_cliente in ([0]) " _
                & "and t.cod_cuenta in(1) and t.cod_tipo_tran=3 and t.monto < 0 "

            s_saldo_inicial_congelados2009 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_cargos_congelados2009(ByVal strListaRuts As String) As Double
            Dim strQuery As String, arrParam(0)
            If strListaRuts = "" Then
                arrParam(0) = 0
            Else
                arrParam(0) = strListaRuts
            End If
            strQuery = _
                "select isnull(sum(tt.monto),0)as cargos " _
                & "from transaccion tt,empresa_cliente ec where cod_curso in " _
                & "( select cod_curso from curso_contratado where agno=2010 " _
                & "and year(fecha_ingreso)=2010 and month(fecha_ingreso) between 7 and 12 " _
                & "and cod_estado_curso in(1,3,4,5,6,7,9,11) ) " _
                & "and tt.cod_cuenta in (4,5) " _
                & "and tt.rut_cliente=*ec.rut " _
                & "and ec.rut in([0]) " _
                & "group by ec.rut "

            s_cargos_congelados2009 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_param_gen_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select dias_comunic,rut_jefe_finanzas, " _
                & " rut_operaciones,servidor_correo,direccion_correo_origen, " _
                & " direccion_correo_destino " _
                & " From Param_Gen "
            s_param_gen_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_saldo_anual_por_cuenta_aportes_traspasos(ByVal mintCodCuenta As Integer, _
                                           ByVal mlngRutCliente As Long, _
                                           ByVal mintAgno As Integer) As Long
            Dim strQuery As String, arrParam(2)

            arrParam(0) = mintCodCuenta
            arrParam(1) = mlngRutCliente
            arrParam(2) = mintAgno
            strQuery = _
                    "select isnull(sum(monto),0) " _
                    & "From transaccion " _
                    & "Where Year(fecha_hora) = [2] " _
                    & "And cod_tipo_tran in (1,3) " _
                    & "And cod_cuenta = [0] " _
                    & "And rut_cliente = [1] "
            s_saldo_anual_por_cuenta_aportes_traspasos = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        'Selecciona todas las cuentas existentes
        Public Function s_cuenta_todos() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_cuenta, nombre " _
                & "From Cuenta "
            s_cuenta_todos = ConsultaSql(strQuery)
        End Function
        'Valor Franquicia del a�o actual para un cliente en especifico, o una lista de clientes
        Public Function s_franquicia_actual(ByVal strRut As String, _
                                            ByVal intAgnoActual As Integer) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strRut
            arrParam(1) = intAgnoActual

            strQuery = _
                "Select Sum(Valor) From Franquicia " _
                & "Where rut In ([0]) " _
                & "And agno = [1] "

            Dim vntValor As Object
            vntValor = ValorSql(SqlParam(strQuery, arrParam))
            If IsNumeric(vntValor) Then
                s_franquicia_actual = CLng(vntValor)
            Else
                s_franquicia_actual = 0
            End If
        End Function
        'Suma de costos por cursos:
        'El primer par�metro corresponde a los campos que se suman de la
        'tabla de cursos: costo_otic, costo_adm, gasto_empresa
        Public Function s_suma_costos_cursos( _
                ByVal strCosto As String, ByVal strRutsClientes As String, _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                Optional ByVal lngRutUsuario As Long = 0 _
            ) As Long
            Dim strQuery As String, arrParam(6)
            arrParam(0) = strCosto
            arrParam(1) = strRutsClientes
            arrParam(2) = intCodSucursal
            arrParam(3) = lngRutEjecutivo
            arrParam(4) = FechaVbABd(dtmInicio)
            arrParam(5) = FechaVbABd(dtmFin)
            arrParam(6) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [2] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [3] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If
            If strRutsClientes <> "" Then
                strWhere = " And cc.rut_cliente In ([1]) " & strWhere
            End If
            If lngRutUsuario <> 0 Then
                strWhere = " And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [6]) " & strWhere
            End If

            Dim strSelect As String
            strSelect = ""


            strSelect = "Select IsNull(Sum( [0] ), 0) "

            strQuery = _
                strSelect _
                & " From Curso_Contratado cc, Empresa_Cliente ec " _
                & strFrom _
                & " Where cod_estado_curso In (1,2,3,4,5,6,7,9,11)" _
                & " And cc.fecha_inicio Between [4] And [5] " _
                & " And ec.rut = cc.rut_cliente " _
                & strWhere

            s_suma_costos_cursos = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente
        Public Function suma_alumnos_internos_capacitados_cliente(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(pi.rut) " _
                & "From Participante_interno pi, Curso_interno ci  " _
                & "Where pi.correlativo = ci.correlativo  " _
                & "and pi.ano = ci.ano " _
                & "And ci.rut In ([0]) And " _
                & "pi.ano = [1] " _
                & "and ci.cod_estado_curso_interno = 1 "
            suma_alumnos_internos_capacitados_cliente = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente SIN REPETICION
        Public Function suma_alumnos_internos_capacitados_SR(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(distinct pi.rut) " _
                & "From Participante_interno pi, Curso_interno ci  " _
                & "Where pi.correlativo = ci.correlativo  " _
                & "and pi.ano = ci.ano " _
                & "And ci.rut In ([0]) And " _
                & "pi.ano = [1] " _
                & "and ci.cod_estado_curso_interno = 1 "
            suma_alumnos_internos_capacitados_SR = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'cursos de un cliente
        Public Function s_suma_cursos_cliente(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " Select count(distinct cc.cod_curso) " _
                & "From  Curso_Contratado cc " _
                & "Where cc.rut_cliente In ([0]) And " _
                & "cc.fecha_inicio >= [1] And cc.fecha_termino <= [2]" _
                & " And cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11) "

            s_suma_cursos_cliente = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'cursos de un cliente
        Public Function s_suma_cursos_anulados_cliente(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " Select count(distinct cc.cod_curso) " _
                & "From  Curso_Contratado cc " _
                & "Where cc.rut_cliente In ([0]) And " _
                & "cc.fecha_inicio >= [1] And cc.fecha_termino <= [2]" _
                & " And cc.cod_estado_curso = 10 "

            s_suma_cursos_anulados_cliente = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'cursos de un cliente
        Public Function s_suma_cursos_eliminados_cliente(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " Select count(distinct cc.cod_curso) " _
                & "From  Curso_Contratado cc " _
                & "Where cc.rut_cliente In ([0]) And " _
                & "cc.fecha_inicio >= [1] And cc.fecha_termino <= [2]" _
                & " And cc.cod_estado_curso = 8 "

            s_suma_cursos_eliminados_cliente = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        'alumnos capacitados del cliente
        Public Function suma_alumnos_capacitados_cliente(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And " _
                & "cc.agno = [1] " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_cliente = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente
        Public Function suma_alumnos_capacitados_cliente_mayor_a_cero(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And " _
                & "cc.agno = [1] and p.porc_asistencia > 0 " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_cliente_mayor_a_cero = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        'alumnos capacitados del cliente SIN REPETICION
        Public Function suma_alumnos_capacitados_SR(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(distinct p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And " _
                & "cc.agno = [1] " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_SR = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente SIN REPETICION
        Public Function suma_alumnos_capacitados_SR_mayor_a_cero(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(distinct p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And " _
                & "cc.agno = [1] and p.porc_asistencia > 0 " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_SR_mayor_a_cero = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente PRESENCIAL
        Public Function suma_alumnos_capacitados_presencial(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And CC.COD_MODALIDAD=1 AND " _
                & "cc.agno = [1] " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_presencial = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente elearning
        Public Function suma_alumnos_capacitados_elearning(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And CC.COD_MODALIDAD=2 AND " _
                & "cc.agno = [1] " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_elearning = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente elearning
        Public Function suma_alumnos_capacitados_autoinstruccion(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And CC.COD_MODALIDAD=3 AND " _
                & "cc.agno = [1] " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_autoinstruccion = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente elearning
        Public Function suma_alumnos_capacitados_a_distancia(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = Year(dtmFechaIni)
            strQuery = _
                " Select count(p.rut_alumno) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And CC.COD_MODALIDAD=4 AND " _
                & "cc.agno = [1] " _
                & " and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11)"
            suma_alumnos_capacitados_a_distancia = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente
        Public Function s_suma_horas_de_capacitacion_cliente(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " Select IsNull(Sum(cc.horas-cc.horas_compl), 0) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And " _
                & " cc.fecha_inicio >= [1] And cc.fecha_termino <= [2] " _
                & " And cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11) "


            s_suma_horas_de_capacitacion_cliente = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        'alumnos capacitados del cliente
        Public Function s_suma_horas_de_capacitacion_cliente2(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " Select IsNull(Sum(cc.horas-cc.horas_compl), 0) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And " _
                & " cc.fecha_inicio >= [1] And cc.fecha_termino <= [2] " _
                & " And cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11) AND P.porc_asistencia >= 0.75"


            s_suma_horas_de_capacitacion_cliente2 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_suma_horas_de_capacitacion_cliente_cero(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " Select IsNull(Sum(cc.horas-cc.horas_compl), 0) " _
                & "From  Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & " cc.rut_cliente In ([0]) And " _
                & " cc.fecha_inicio >= [1] And cc.fecha_termino <= [2] " _
                & " And cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11) AND P.porc_asistencia > 0"


            s_suma_horas_de_capacitacion_cliente_cero = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente
        Public Function s_suma_horas_de_curso(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " Select IsNull(Sum(cc.horas-cc.horas_compl), 0) " _
                & "From  Curso_Contratado cc  " _
                & "Where cc.rut_cliente In ([0]) And " _
                & " cc.fecha_inicio >= [1] And cc.fecha_termino <= [2] " _
                & " And cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11) "


            s_suma_horas_de_curso = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente
        Public Function s_alumnos_aprobados_por_asistencia(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            'Dim strWhere As String

            strQuery = _
                " select count(*) from participante pa, Curso_Contratado cco  " _
                & "where pa.cod_curso = cco.cod_curso And porc_asistencia >= 0.75  " _
                & " and cco.rut_cliente In ([0]) " _
                & "And cco.fecha_inicio >= [1] And cco.fecha_termino <= [2] " _
                & " And cco.cod_estado_curso in (0,1,3,4,5,6,7,9,11) "


            s_alumnos_aprobados_por_asistencia = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_beca(ByVal lngRutCliente As Long, _
                       ByVal intAgno As Integer) As Object
            Dim strQuery As String, arrParam(1)
            Dim strWhere As String
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno

            strQuery = _
                "Select rut, agno, becas, adm_asignacion " _
                & "From Asignacion_Exced " _
                & "Where rut = [0] And agno = [1]"
            s_beca = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'alumnos capacitados del cliente
        Public Function s_suma_horas_modalidad(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date, _
                                              ByVal intCodModalidad As Long)
            Dim strQuery As String, arrParam(3)

            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            arrParam(3) = intCodModalidad

            strQuery = _
                " Select IsNull(Sum(cc.horas-cc.horas_compl), 0) " _
                & "From Participante p, Curso_Contratado cc  " _
                & "Where p.cod_curso=cc.cod_curso And " _
                & "cc.rut_cliente In ([0]) And " _
                & "cc.fecha_inicio >= [1] And cc.fecha_termino <= [2] And " _
                & "cc.cod_modalidad = [3] " _
                & "and cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11) "

            s_suma_horas_modalidad = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_aportes_anuales(ByVal intAgno As Integer) As DataTable
            Dim strQuery As String, arrParam(0)

            arrParam(0) = intAgno
            strQuery = _
                    " Select fecha,correlativo,rut_cliente, " _
                    & "monto_neto + monto_adm as monto_total,razon_social " _
                    & "from aporte a, persona_juridica pj " _
                    & "Where a.rut_cliente = pj.Rut " _
                    & "And Agno = [0] "

            s_aportes_anuales = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_aportes_anuales_sence(ByVal intAgno As Integer) As DataTable
            Dim strQuery As String, arrParam(0)

            arrParam(0) = intAgno
            strQuery = _
                    " select " & StringSql(RutUsrALng(Parametros.p_RUTEMPRESA)) & " RUT_OTIC, rut as RUT_EMPRESA, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=1), 0) ENERO_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=1), 0) ENERO_R, " _
                    & "0 ENERO_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=2), 0) FEBRERO_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=2), 0) FEBRERO_R, " _
                    & "0 FEBRERO_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=3), 0) MARZO_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=3), 0) MARZO_R, " _
                    & "0 MARZO_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=4), 0) ABRIL_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=4), 0) ABRIL_R, " _
                    & "0 ABRIL_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=5), 0) MAYO_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=5), 0) MAYO_R, " _
                    & "0 MAYO_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=6), 0) JUNIO_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=6), 0) JUNIO_R, " _
                    & "0 JUNIO_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=7), 0) JULIO_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=7), 0) JULIO_R, " _
                    & "0 JULIO_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=8), 0) AGOSTO_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=8), 0) AGOSTO_R, " _
                    & "0 AGOSTO_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=9), 0) SEPTIEMBRE_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=9), 0) SEPTIEMBRE_R, " _
                    & "0 SEPTIEMBRE_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=10), 0) OCTUBRE_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=10), 0) OCTUBRE_R, " _
                    & "0 OCTUBRE_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=11), 0) NOVIEMBRE_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=11), 0) NOVIEMBRE_R, " _
                    & "0 NOVIEMBRE_CCL, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=1 and cod_estado <> 3 and month(fecha)=12), 0) DICIEMBRE_C, " _
                    & "isnull((select sum(monto_neto + monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta=2 and cod_estado <> 3 and month(fecha)=12), 0) DICIEMBRE_R, " _
                    & "0 DICIEMBRE_CCL, " _
                    & "isnull((select sum(monto_adm) from aporte where year(fecha) = [0] and rut_cliente=rut and cod_cuenta in (1,2) and cod_estado <> 3), 0) COSTO_ADM_CR, " _
                    & "0 COSTO_ADM_CCL " _
                    & "from empresa_cliente "

            s_aportes_anuales_sence = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_hh_anuales_cursos_sence(ByVal strRutCliente As String) As DataTable
            Dim strQuery, arrParam(0)
            arrParam(0) = strRutCliente


            strQuery = _
                        "select sum(isnull(ci.horas,0))+ " _
                        & "(select isnull(sum(cii.horas* " _
                        & "(datediff(dd,cii.inicio_curso, " _
                        & "cast(year(cii.inicio_curso)as varchar) + '1231')*100) " _
                        & "/datediff(dd,cii.inicio_curso,cast(year(cii.fin_curso)as varchar)))/100,0) " _
                        & "from curso_interno cii " _
                        & "where(cii.ano = ci.ano And cii.cod_estado_curso_interno = 1) " _
                        & "and year(cii.fin_curso)>ci.ano and cii.rut=ci.rut) as cantidad, " _
                        & "ci.ano as agno,1 as tipo " _
                        & "from curso_interno ci " _
                        & "where Year(ci.fin_curso) = ano And ci.rut In ([0]) " _
                        & "And ci.cod_estado_curso_interno = 1 " _
                        & "group by ci.ano,ci.rut " _
                        & "union " _
                        & "Select IsNull(Sum(cc.horas-cc.horas_compl), 0) as cantidad,cc.agno,2 as tipo " _
                        & "From  Participante p, Curso_Contratado cc  " _
                        & "Where p.cod_curso=cc.cod_curso And " _
                        & "cc.rut_cliente In ([0]) " _
                        & "And cc.cod_estado_curso in (0,1,3,4,5,6,7,9,11) " _
                        & "GROUP BY cc.agno order by cc.agno "

            s_hh_anuales_cursos_sence = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_deuda_consolidada_por_rut(ByVal lngRutCliente As Long, ByVal intAgno As Integer) As DataTable
            Dim strQuery, arrParam(1)
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno


            strQuery = _
                        "select ec.rut, ec.costo_admin,ec.comp_adm_no_lineal, ((select isnull(sum(tr1.monto),0) from transaccion tr1 where tr1.rut_cliente = [0] " _
                        & "and year(tr1.fecha_hora)= [1] and tr1.cod_cuenta in (1,2) " _
                        & "and tr1.cod_tipo_tran = 1) - (select isnull(sum(tr2.monto),0) from transaccion tr2 " _
                        & "where tr2.rut_cliente = [0] and year(tr2.fecha_hora)= [1] and tr2.cod_cuenta in (1,2) " _
                        & "and tr2.cod_tipo_tran in(2,5))) deuda_cap_rep from empresa_cliente ec where ec.rut = [0] "

            s_deuda_consolidada_por_rut = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_monto_cursos_anuales(ByVal strRutCliente As String) As DataTable
            Dim strQuery, arrParam(0)
            arrParam(0) = strRutCliente


            strQuery = _
                " Select isnull(sum(cast (ci.valor_curso as numeric) ),0) as monto,ano ,1 as tipo " _
            & "From Curso_Interno ci " _
            & "Where ci.rut In ([0]) " _
            & "And ci.cod_estado_curso_interno = 1 " _
            & "group by ano " _
            & "union " _
            & "select sum(monto),year(fecha_hora),2 as tipo " _
            & "from transaccion where cod_tipo_tran=2 and rut_cliente in([0]) " _
            & "group by year(fecha_hora) order by ano "

            s_monto_cursos_anuales = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        's_monto_cursos
        Public Function s_monto_cursos(ByVal strRutCliente As String, _
                                        ByVal intAgno As Integer _
                                        ) As Long
            Dim strQuery, arrParam(1)
            arrParam(0) = strRutCliente
            arrParam(1) = intAgno

            strQuery = "select IsNull(Sum(monto),0) " _
            & "from transaccion where cod_tipo_tran in (2,5) and rut_cliente in([0]) " _
            & "And year(Fecha_Hora) = [1] "

            s_monto_cursos = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'cursos internos -cant. de un cliente
        Public Function s_suma_cursos_internos(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date, _
                                              ByVal intCodEstado As Integer) As Long
            Dim strQuery As String, arrParam(3)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            arrParam(3) = intCodEstado

            strQuery = _
                " Select isnull(count(distinct ci.correlativo),0) " _
                & "From  Curso_Interno ci " _
                & "Where ci.rut In ([0]) And " _
                & "ci.inicio_curso >= [1] And ci.fin_curso < [2] " _
                & "And ci.cod_estado_curso_interno = [3] "

            s_suma_cursos_internos = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'cursos internos -cant. de un cliente
        Public Function s_suma_valor_cursos_internos(ByVal strListaRutsHolding As String, _
                                              ByVal dtmFechaIni As Date, _
                                              ByVal dtmFechaFin As Date, _
                                              ByVal intCodEstado As Integer) As Long
            Dim strQuery As String, arrParam(3)
            arrParam(0) = strListaRutsHolding
            arrParam(1) = FechaVbABd(dtmFechaIni)
            arrParam(2) = FechaVbABd(dtmFechaFin)
            arrParam(3) = intCodEstado

            strQuery = _
                " Select isnull(sum(ci.valor_curso),0) " _
                & "From Curso_Interno ci " _
                & "Where ci.rut In ([0]) And " _
                & "ci.inicio_curso >= [1] And ci.fin_curso < [2] " _
                & "And ci.cod_estado_curso_interno = [3] "

            s_suma_valor_cursos_internos = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Suma de costos por cursos (complementarios)
        'El primer par�metro corresponde a los campos que se suman de la
        'tabla de cursos: costo_otic, costo_adm, gasto_empresa
        Public Function s_suma_costos_cursos_compl( _
                ByVal strCosto As String, ByVal strRutsClientes As String, _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                Optional ByVal lngRutUsuario As Long = 0 _
            ) As Long
            Dim strQuery As String, arrParam(6)
            arrParam(0) = strCosto
            arrParam(1) = strRutsClientes
            arrParam(2) = intCodSucursal
            arrParam(3) = lngRutEjecutivo
            arrParam(4) = FechaVbABd(dtmInicio)
            arrParam(5) = FechaVbABd(dtmFin)
            arrParam(6) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = " And cc.cod_curso_parcial > 0 "   ' Consulta solo los cursos complementarios
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [2] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [3] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If
            If strRutsClientes <> "" Then
                strWhere = " And cc.rut_cliente In ([1]) " & strWhere
            End If
            If lngRutUsuario <> 0 Then
                strWhere = " And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [6]) " & strWhere
            End If

            Dim strSelect As String
            strSelect = ""

            strSelect = "Select IsNull(Sum( [0] ), 0) "

            strQuery = _
                strSelect _
                & " From Curso_Contratado cc, Empresa_Cliente ec " _
                & strFrom _
                & " Where cod_estado_curso In (1,2,3,4,5,6,7,9,11)" _
                & " And cc.fecha_inicio Between [4] And [5] " _
                & " And ec.rut = cc.rut_cliente " _
                & strWhere

            s_suma_costos_cursos_compl = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'n�mero de aportes por cobrar de un cliente
        Public Function s_aportes_por_cobrar(ByVal strRutCliente As String, _
                                            ByVal intagno As Integer) As Integer
            Dim strQuery, arrParam(1)
            arrParam(0) = strRutCliente
            arrParam(1) = intagno
            strQuery = _
                "Select Count(*) " _
                & "From Aporte " _
                & "Where rut_cliente In ([0]) " _
                & "And cod_estado = 1 " _
                & "And year(fecha) = [1] "
            s_aportes_por_cobrar = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_es_curso_elearning(ByVal CodSence As String) As Boolean
            Dim strQuery As String, arrParam(1)
            arrParam(0) = StringSql(CodSence)


            strQuery = _
                "select elearning " _
                & "from curso  " _
                & "Where codigo_sence = [0] "

            Dim arrDatos As DataTable
            arrDatos = ConsultaSql(SqlParam(strQuery, arrParam))
            If arrDatos.Rows(0)(0) = True Then
                s_es_curso_elearning = True
            Else
                s_es_curso_elearning = False
            End If
        End Function
        'n�mero de aportes por cobrar de un cliente, consiera los cobrados y por cobrar
        'por cuenta
        Public Function s_aportes_costo_otic(ByVal strRutCliente As String, _
                                             ByVal intagno As Integer, _
                                             ByVal intCodCuenta As Integer) As Long
            Dim strQuery, arrParam(2)
            arrParam(0) = strRutCliente
            arrParam(1) = intagno
            arrParam(2) = intCodCuenta

            strQuery = _
                "Select isnull(Sum(monto_neto),0) " _
                & "From Aporte " _
                & "Where rut_cliente In ([0]) " _
                & "And cod_estado in (1,2) " _
                & "And year(fecha) = [1] " _
                & "And cod_cuenta = [2] "

            s_aportes_costo_otic = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_reporte_excedentes(ByVal lngRutCliente As Long, _
                                     ByVal strNombreEmpresa As String, _
                                     ByVal intCodSucursal As Integer, _
                                     ByVal lngRutEjecutivo As Long, _
                                     ByVal intAno As Integer)
            Dim strQuery As String, arrParam(6)
            Dim strWhere As String
            Dim intLargo As Integer

            intLargo = Len(strNombreEmpresa)

            strWhere = ""
            arrParam(0) = lngRutCliente
            arrParam(1) = StringSql(strNombreEmpresa)
            arrParam(2) = intCodSucursal
            arrParam(3) = lngRutEjecutivo
            arrParam(4) = intAno
            arrParam(5) = intAno + 1
            arrParam(6) = FechaHoraVbABd(FechaMinAgno(intAno + 1))
            strWhere = " And LEFT(pj.razon_social," & intLargo & ") = [1] "
            If lngRutCliente > 0 Then
                strWhere = strWhere & " And pj.rut = [0] "
            End If
            If intCodSucursal > 0 Then
                strWhere = strWhere & " And ec.cod_sucursal = [2] "
            End If
            If lngRutEjecutivo > 0 Then
                strWhere = strWhere & " And e.rut_ejecutivo = [3] "
            End If
            strQuery = _
            "Select distinct(pj.razon_social), pj.rut, u.nombres, s.nombre, " _
            & "isnull(v1.saldo, 0), isnull(v2.saldo, 0), " _
            & "isnull(v3.saldo, 0), isnull(v4.saldo, 0), isnull(v5.saldo, 0), " _
            & "isnull(tr1.monto, 0), isnull(tr2.monto, 0), isnull(b.adm_asignacion, 0)," _
            & "isnull(ec.costo_admin,0) as costo_admin, isnull(v8.saldo, 0), " _
            & "isnull(v6.saldo, 0), isnull(v7.saldo, 0) " _
            & "from empresa_cliente ec, " _
            & "ejecutivo e, usuario u, sucursal s, " _
            & "persona_juridica pj Left join v_saldo_cuenta_cap_cliente v1 on(pj.rut = v1.rut_cliente and v1.ano = [4]) " _
            & "Left join v_saldo_cuenta_rep_cliente v2 on(pj.rut = v2.rut_cliente and v2.ano = [4]) " _
            & "Left join v_saldo_cuenta_adm_cliente v3 on(pj.rut = v3.rut_cliente and v3.ano = [4]) " _
            & "Left join v_saldo_cuenta_excap_cliente v4 on(pj.rut = v4.rut_cliente and v4.ano = [5]) " _
            & "Left join v_saldo_cuenta_exrep_cliente v5 on(pj.rut = v5.rut_cliente and v5.ano = [5]) "

            '**|** Se agreg� la cuenta becas(6)
            strQuery = strQuery _
            & "Left join v_saldo_cuenta_becas_cliente v8 on(pj.rut = v8.rut_cliente and v8.ano = [5]) " _
            & "Left join transaccion tr1 on(pj.rut = tr1.rut_cliente and tr1.cod_cuenta=4 and tr1.cod_tipo_tran = 3 and tr1.fecha_hora = [6]) " _
            & "Left join transaccion tr2 on(pj.rut = tr2.rut_cliente and tr2.cod_cuenta=5 and tr2.cod_tipo_tran = 3 and tr2.fecha_hora = [6]) " _
            & "Left join asignacion_exced b on(b.rut = pj.rut And b.agno = [5]) " _
            & "Left join v_saldo_cuenta_excap_cliente1 v6 on(pj.rut = v6.rut_cliente and v6.ano = [4]) " _
            & "Left join v_saldo_cuenta_exrep_cliente1 v7 on(pj.rut = v7.rut_cliente and v7.ano = [4]) " _
            & "Where pj.Rut = ec.Rut And e.rut_empresa = pj.Rut " _
            & "And u.rut=e.rut_ejecutivo And s.cod_sucursal = ec.cod_sucursal " _
            & "And ( (tr1.monto > 0 or tr2.monto > 0) " _
            & "Or (isnull(v1.saldo, 0) > 0 or isnull(v2.saldo, 0) > 0  or isnull(v6.saldo, 0) > 0 or isnull(v7.saldo, 0) > 0)) " _
            & strWhere _
            & " Order by pj.razon_social"
            'And isnull(v3.saldo, 0) >= 0
            s_reporte_excedentes = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_reporte_excedentes2(ByVal lngRutCliente As Long, _
                                     ByVal strNombreEmpresa As String, _
                                     ByVal intCodSucursal As Integer, _
                                     ByVal lngRutEjecutivo As Long, _
                                     ByVal intAno As Integer)
            Dim strQuery As String, arrParam(6)
            Dim strWhere As String
            Dim intLargo As Integer

            intLargo = Len(strNombreEmpresa)

            strWhere = ""
            arrParam(0) = lngRutCliente
            arrParam(1) = StringSql(strNombreEmpresa)
            arrParam(2) = intCodSucursal
            arrParam(3) = lngRutEjecutivo
            arrParam(4) = intAno
            arrParam(5) = intAno + 1
            arrParam(6) = FechaHoraVbABd(FechaMinAgno(intAno + 1))
            strWhere = " And LEFT(pj.razon_social," & intLargo & ") = [1] "
            If lngRutCliente > 0 Then
                strWhere = strWhere & " And pj.rut = [0] "
            End If
            If intCodSucursal > 0 Then
                strWhere = strWhere & " And ec.cod_sucursal = [2] "
            End If
            If lngRutEjecutivo > 0 Then
                strWhere = strWhere & " And e.rut_ejecutivo = [3] "
            End If
            strQuery = _
            "Select distinct(pj.razon_social), cast(pj.rut as varchar) as rut_cliente, u.nombres as ejecutivo, s.nombre as sucursal, " _
            & "isnull(v1.saldo, 0) SaldoCap, isnull(v2.saldo, 0) SaldoRep, " _
            & "isnull(v3.saldo, 0) SaldoAdm, isnull(v4.saldo, 0) SaldoExCap, isnull(v5.saldo, 0) SaldoExRep, " _
            & "isnull(tr1.monto, 0) AbonoExCap, isnull(tr2.monto, 0) AbonoExRep, isnull(b.adm_asignacion, 0) AbonoAdm," _
            & "isnull((ec.costo_admin*100),0) as PorcAdm, isnull(v8.saldo, 0) AbonoBeca, " _
            & "isnull(v6.saldo, 0) SaldoExcCapAnt, isnull(v7.saldo, 0)  SaldoExcRepAnt " _
            & "from empresa_cliente ec, " _
            & "ejecutivo e, usuario u, sucursal s, " _
            & "persona_juridica pj Left join v_saldo_cuenta_cap_cliente v1 on(pj.rut = v1.rut_cliente and v1.ano = [4]) " _
            & "Left join v_saldo_cuenta_rep_cliente v2 on(pj.rut = v2.rut_cliente and v2.ano = [4]) " _
            & "Left join v_saldo_cuenta_adm_cliente v3 on(pj.rut = v3.rut_cliente and v3.ano = [4]) " _
            & "Left join v_saldo_cuenta_excap_cliente v4 on(pj.rut = v4.rut_cliente and v4.ano = [5]) " _
            & "Left join v_saldo_cuenta_exrep_cliente v5 on(pj.rut = v5.rut_cliente and v5.ano = [5]) "

            '**|** Se agreg� la cuenta becas(6)
            strQuery = strQuery _
            & "Left join v_saldo_cuenta_becas_cliente v8 on(pj.rut = v8.rut_cliente and v8.ano = [5]) " _
            & "Left join transaccion tr1 on(pj.rut = tr1.rut_cliente and tr1.cod_cuenta=4 and tr1.cod_tipo_tran = 3 and tr1.fecha_hora = [6]) " _
            & "Left join transaccion tr2 on(pj.rut = tr2.rut_cliente and tr2.cod_cuenta=5 and tr2.cod_tipo_tran = 3 and tr2.fecha_hora = [6]) " _
            & "Left join asignacion_exced b on(b.rut = pj.rut And b.agno = [5]) " _
            & "Left join v_saldo_cuenta_excap_cliente1 v6 on(pj.rut = v6.rut_cliente and v6.ano = [4]) " _
            & "Left join v_saldo_cuenta_exrep_cliente1 v7 on(pj.rut = v7.rut_cliente and v7.ano = [4]) " _
            & "Where pj.Rut = ec.Rut And e.rut_empresa = pj.Rut " _
            & "And u.rut=e.rut_ejecutivo And s.cod_sucursal = ec.cod_sucursal " _
            & "And ( (tr1.monto > 0 or tr2.monto > 0) " _
            & "Or (isnull(v1.saldo, 0) > 0 or isnull(v2.saldo, 0) > 0  or isnull(v6.saldo, 0) > 0 or isnull(v7.saldo, 0) > 0)) " _
            & strWhere _
            & " Order by pj.razon_social"
            'And isnull(v3.saldo, 0) >= 0
            s_reporte_excedentes2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_reporte_excedentes_para_otic_banca(ByVal lngRutCliente As Long, _
                                     ByVal strNombreEmpresa As String, _
                                     ByVal intCodSucursal As Integer, _
                                     ByVal lngRutEjecutivo As Long, _
                                     ByVal intAno As Integer)
            Dim strQuery As String, arrParam(6)
            Dim strWhere As String
            Dim intLargo As Integer

            intLargo = Len(strNombreEmpresa)

            strWhere = ""
            arrParam(0) = lngRutCliente
            arrParam(1) = StringSql(strNombreEmpresa)
            arrParam(2) = intCodSucursal
            arrParam(3) = lngRutEjecutivo
            arrParam(4) = intAno
            arrParam(5) = intAno + 1
            arrParam(6) = FechaHoraVbABd(FechaMinAgno(intAno + 1))
            strWhere = " And LEFT(pj.razon_social," & intLargo & ") = [1] "
            If lngRutCliente > 0 Then
                strWhere = strWhere & " And pj.rut = [0] "
            End If
            If intCodSucursal > 0 Then
                strWhere = strWhere & " And ec.cod_sucursal = [2] "
            End If
            If lngRutEjecutivo > 0 Then
                strWhere = strWhere & " And e.rut_ejecutivo = [3] "
            End If
            strQuery = _
            "Select distinct(pj.razon_social), cast(pj.rut as varchar) as rut_cliente, u.nombres as ejecutivo, s.nombre as sucursal, " _
            & "isnull(v1.saldo, 0) SaldoCap, isnull(v2.saldo, 0) SaldoRep, " _
            & "isnull(v3.saldo, 0) SaldoAdm, isnull(v4.saldo, 0) SaldoExCap, isnull(v5.saldo, 0) SaldoExRep, " _
            & "isnull(tr1.monto, 0) AbonoExCap, isnull(tr2.monto, 0) AbonoExRep, isnull(b.adm_asignacion, 0) AbonoAdm," _
            & "isnull((ec.costo_admin*100),0) as PorcAdm, isnull(v8.saldo, 0) AbonoBeca, " _
            & "isnull(v6.saldo, 0) SaldoExcCapAnt, isnull(v7.saldo, 0)  SaldoExcRepAnt " _
            & "from empresa_cliente ec, " _
            & "ejecutivo e, usuario u, sucursal s, " _
            & "persona_juridica pj Left join v_saldo_cuenta_cap_cliente v1 on(pj.rut = v1.rut_cliente and v1.ano = [4]) " _
            & "Left join v_saldo_cuenta_rep_cliente v2 on(pj.rut = v2.rut_cliente and v2.ano = [4]) " _
            & "Left join v_saldo_cuenta_adm_cliente v3 on(pj.rut = v3.rut_cliente and v3.ano = [4]) " _
            & "Left join v_saldo_cuenta_excap_cliente v4 on(pj.rut = v4.rut_cliente and v4.ano = [5]) " _
            & "Left join v_saldo_cuenta_exrep_cliente v5 on(pj.rut = v5.rut_cliente and v5.ano = [5]) "

            '**|** Se agreg� la cuenta becas(6)
            strQuery = strQuery _
            & "Left join v_saldo_cuenta_becas_cliente v8 on(pj.rut = v8.rut_cliente and v8.ano = [5]) " _
            & "Left join transaccion tr1 on(pj.rut = tr1.rut_cliente and tr1.cod_cuenta=4 and tr1.cod_tipo_tran = 3 and tr1.fecha_hora = [6]) " _
            & "Left join transaccion tr2 on(pj.rut = tr2.rut_cliente and tr2.cod_cuenta=5 and tr2.cod_tipo_tran = 3 and tr2.fecha_hora = [6]) " _
            & "Left join asignacion_exced b on(b.rut = pj.rut And b.agno = [5]) " _
            & "Left join v_saldo_cuenta_excap_cliente1 v6 on(pj.rut = v6.rut_cliente and v6.ano = [4]) " _
            & "Left join v_saldo_cuenta_exrep_cliente1 v7 on(pj.rut = v7.rut_cliente and v7.ano = [4]) " _
            & "Where pj.Rut = ec.Rut And e.rut_empresa = pj.Rut " _
            & "And u.rut=e.rut_ejecutivo And s.cod_sucursal = ec.cod_sucursal " _
            & "And ( (tr1.monto > 0 or tr2.monto > 0) " _
            & "Or (isnull(v1.saldo, 0) > 0 or isnull(v2.saldo, 0) > 0  or isnull(v6.saldo, 0) > 0 or isnull(v7.saldo, 0) > 0)) " _
            & strWhere _
            & " Order by pj.razon_social"
            'And isnull(v3.saldo, 0) >= 0
            s_reporte_excedentes_para_otic_banca = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta los valores de franquicia para un cliente en especifico
        Public Function s_certificado_aportes(ByVal intagno As Integer, Optional ByVal lngRut As Long = 0) As DataTable

            Dim strQuery As String, arrParam(1)
            arrParam(0) = intagno
            arrParam(1) = lngRut

            Dim strWhere As String
            strWhere = ""
            If lngRut > 0 Then strWhere = "And rut_cliente = [1] "

            strQuery = _
                "Select rut_cliente, Month(fecha) mes, Sum(Monto_neto + monto_adm) total " _
                & "From Aporte " _
                & "Where Agno = [0] " _
                & "And cod_estado In (1, 2) " _
                & strWhere _
                & "Group By rut_cliente, Month(fecha) "
            s_certificado_aportes = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_empresa_cliente_todas() As Object
            Dim strQuery As String

            strQuery = _
                "Select ec.rut,pj.razon_social " _
                & "From empresa_cliente ec,persona_juridica pj " _
                & "where ec.rut *= pj.rut " _
                & "Order by pj.razon_social "

            s_empresa_cliente_todas = ConsultaSql(strQuery)
        End Function
        'funciones para certificados de aportes
        '
        'consulta un registro
        Public Function s_certificado_aporte_1(ByVal intagno As Integer, ByVal lngRut As Long) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intagno
            arrParam(1) = lngRut

            strQuery = _
                "Select correlativo " _
                & "From Certificado_Aporte " _
                & "Where agno = [0] " _
                & "And rut_cliente = [1] "
            Dim vntCorrel As Object
            vntCorrel = ValorSql(SqlParam(strQuery, arrParam))
            If IsNumeric(vntCorrel) Then
                s_certificado_aporte_1 = CLng(vntCorrel)
            Else
                s_certificado_aporte_1 = 0
            End If
        End Function
        'Consulta los nombres de un Nivel Educacional, Ocupacional y una Region

        Public Function s_nombre_niv_reg(ByVal intCodNivelEduc As Integer, _
                                         ByVal intCodNivelOcup As Integer, _
                                         ByVal intCodRegion As Integer) As DataTable

            Dim strQuery As String, arrParam(2)
            arrParam(0) = intCodNivelEduc
            arrParam(1) = intCodNivelOcup
            arrParam(2) = intCodRegion

            strQuery = _
                    "Select ne.nombre as nivel_educ, no.nombre as nivel_ocup, r.nombre as nom_region " _
                    & "From Nivel_Educacional ne, Nivel_Ocupacional no, " _
                    & "Region r " _
                    & "Where ne.cod_nivel_educ = [0] And no.cod_nivel_ocup = [1] " _
                    & "And r.cod_region = [2] "

            s_nombre_niv_reg = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_nom_comuna(ByVal lngCodComuna As Long) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodComuna

            strQuery = _
                "Select nombre " _
                & "From Comuna " _
                & "Where cod_comuna = [0] "

            s_nom_comuna = CStr(ValorSql(SqlParam(strQuery, arrParam)))
        End Function
        Public Function s_nom_pais(ByVal lngCodPais As Long) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodPais

            strQuery = _
                "Select nombre_pais " _
                & "From pais " _
                & "Where cod_pais = [0] "

            s_nom_pais = CStr(ValorSql(SqlParam(strQuery, arrParam)))
        End Function
        Public Function s_nom_usuario(ByVal lngRutUsuario As Long) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutUsuario

            strQuery = _
                "Select nombres " _
                & "From usuario " _
                & "Where rut = [0] "

            s_nom_usuario = CStr(ValorSql(SqlParam(strQuery, arrParam)))
        End Function
        Public Function s_nom_modalidad(ByVal lngCodModalidad As Long) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodModalidad

            strQuery = _
                "Select nombre " _
                & "From modalidad " _
                & "Where cod_modalidad = [0] "

            s_nom_modalidad = CStr(ValorSql(SqlParam(strQuery, arrParam)))
        End Function
        Public Function NombreRegion(ByVal intCodRegion As Integer) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodRegion

            strQuery = _
                "Select nombre from region " _
                & "Where cod_region = [0] "

            NombreRegion = ValorSql(SqlParam(strQuery, arrParam))
            Exit Function
        End Function
        Public Function s_sol_pago_terc(ByVal lngCodCurso As Long, ByVal lngRutBenefactor As Long) As Object

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutBenefactor

            strQuery = _
                "Select cod_solicitud_pago, rut_benefactor, cod_curso, " _
                & "fecha_ingreso, monto, nro_transaccion, cod_estado_solicitud, monto_adm " _
                & "From Solicitud_Pago_Terceros " _
                & "Where cod_curso = [0] And rut_benefactor = [1] "
            s_sol_pago_terc = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_cta_est_tran1(ByVal lngNroTransaccion As Long) As Object

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngNroTransaccion

            strQuery = _
                "Select cod_cuenta, cod_estado_tran " _
                & "From Transaccion " _
                & "Where nro_transaccion = [0] "
            s_cta_est_tran1 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Retorna el codigo de cuenta y el estado de la transaccion segun el rut
        'del cliente y el cod. curso, de las transacciones relacionadas con Solicitudes
        'de Pago a Terceros
        Public Function s_cta_est_tran2(ByVal mlngRutCliente As Long, ByVal mlngCodCurso As Long) As Object

            Dim strQuery As String, arrParam(1)
            arrParam(0) = mlngRutCliente
            arrParam(1) = mlngCodCurso

            strQuery = _
                "Select tr.cod_cuenta, tr.cod_estado_tran, tr.monto " _
                & "From Transaccion tr, Solicitud_Pago_Terceros spt " _
                & "Where tr.rut_cliente = [0] And tr.cod_curso = [1] " _
                & "And tr.rut_cliente = spt.rut_benefactor And tr.cod_curso = spt.cod_curso " _
                & "And tr.cod_estado_tran = 3 " 'transaccion solicitada
            s_cta_est_tran2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_transaccion_excedente(ByVal lngRutCliente As Long, _
                                        ByVal dtmFechaHora As Date, _
                                        Optional ByVal strCodigoCuentas As String = "") As DataTable
            Dim strQuery As String, arrParam(1)
            Dim strWhere As String
            arrParam(0) = lngRutCliente
            arrParam(1) = FechaHoraVbABd(dtmFechaHora)
            If Len(strCodigoCuentas) > 0 Then
                strWhere = " and tr.cod_cuenta In (" & strCodigoCuentas & ")"
            End If

            strQuery = _
                "Select tr.nro_transaccion, tr.cod_cuenta," _
                & " tr.monto " _
                & " From Transaccion tr" _
                & " Where tr.rut_cliente = [0] And " _
                & " tr.cod_tipo_tran=3 and " _
                & " tr.fecha_hora = [1] " _
                & strWhere


            s_transaccion_excedente = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_cursos_sence(ByVal strCodigoSence As String, _
                                      ByVal strNombreCursoSence As String, _
                                      ByVal strNombreOtec As String) As DataTable
            Dim strQuery As String, arrParam(2)
            arrParam(0) = SubStringSql(strCodigoSence)
            arrParam(1) = SubStringSql(strNombreCursoSence)
            arrParam(2) = SubStringSql(strNombreOtec)
            'criterios de b�squeda opcionales
            Dim strWhere As String
            strWhere = ""
            If strCodigoSence <> "" Then strWhere = " And curso.codigo_sence like [0] "
            If strNombreCursoSence <> "" Then strWhere = " And curso.nombre like [1] " & strWhere
            If strNombreOtec <> "" Then strWhere = " And persona_juridica.razon_social like [2] " & strWhere
            'consulta
            strQuery = _
                "Select curso.Codigo_sence, curso.nombre, persona_juridica.razon_social, " _
                & "curso.dur_cur_teorico + curso.dur_cur_prac horas, valor_curso,valor_hora " _
                & "From curso, Persona_Juridica  " _
                & "Where curso.rut_otec = persona_juridica.Rut " _
                & strWhere _
                & "Order By curso.Codigo_Sence"
            s_cursos_sence = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Consulta de Cursos Sence
        Public Function s_cursos_sence_m(ByVal strCodigoSence As String) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigoSence)
            Dim strWhere As String
            strWhere = ""
            If strCodigoSence <> "" Then
                strWhere = strWhere & " And curso.codigo_sence = [0] "
            End If
            'consulta
            strQuery = _
                "Select curso.Codigo_sence, curso.nombre, persona_juridica.razon_social, curso.rut_otec, " _
                & "curso.dur_cur_teorico + curso.dur_cur_prac + curso.dur_cur_elearning as horas, curso.area, curso.especialidad, " _
                & "curso.dur_cur_teorico, curso.dur_cur_prac, curso.num_max_part, curso.nombre_sede, " _
                & "curso.fono_sede, curso.direccion, curso.cod_comuna, curso.valor_curso, curso.cod_modalidad, " _
                & "isnull(curso.valor_hora, 0) valor_hora, isnull(curso.dur_cur_elearning, 0) dur_cur_elearning " _
                & "From curso, Persona_Juridica  " _
                & "Where curso.rut_otec = persona_juridica.Rut " _
                & strWhere _
                & "Order By curso.Codigo_Sence"
            s_cursos_sence_m = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_persona_natural(ByVal Rut As Long, _
                                      ByVal Nombres As String, _
                                      ByVal Apellido As String) As DataTable
            Dim strQuery As String, arrParam(2)
            arrParam(0) = Rut
            arrParam(1) = SubStringSql(Nombres)
            arrParam(2) = SubStringSql(Apellido)
            'criterios de b�squeda opcionales
            Dim strWhere As String
            strWhere = ""
            If Rut <> gValorNumNulo Then
                If strWhere.Length = 0 Then
                    strWhere = strWhere & " where rut = [0] "
                Else
                    strWhere = strWhere & " and rut = [0] "
                End If
            End If
            If Nombres <> "" Then
                If strWhere.Length = 0 Then
                    strWhere = strWhere & " where nombre like [1] "
                Else
                    strWhere = strWhere & " and nombre like [1] "
                End If
            End If
            If Apellido <> "" Then
                If strWhere.Length = 0 Then
                    strWhere = strWhere & " where ap_paterno like [2] "
                Else
                    strWhere = strWhere & " and ap_paterno like [2] "
                End If
            End If
            'consulta
            strQuery = _
                "select cast(rut as varchar) rut, ap_paterno apellido_paterno, ap_materno apellido_materno, nombre nombres from persona_natural" _
                & strWhere _
                & "order by ap_paterno"
            s_persona_natural = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Function s_perfil(ByVal lngRutUsuario As Long) As DataTable
            Dim arrParam(0)
            Dim strSql As String

            arrParam(0) = lngRutUsuario

            strSql = _
            "select up.rut,up.cod_perfil,us.nombres, pe.Nombre " _
            & "From perfil_usuario up,Usuario us, perfil pe " _
            & "Where up.rut = us.rut and pe.cod_perfil=up.cod_perfil And " _
            & "up.rut=[0] order by pe.nombre"

            Return ConsultaSql(SqlParam(strSql, arrParam))
        End Function
        Public Function s_persona_juridica3(ByVal lngRutEmpresa As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutEmpresa

            'consulta
            strQuery = _
                "select rut, isnull(razon_social,'') razon_social from persona_juridica " _
                & "where rut=[0] "
            s_persona_juridica3 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Obtiene el ejecutivo de la empresa x
        Public Function s_ejecutivo_empresa(ByVal strRutEmpresa As String)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = strRutEmpresa

            strQuery = _
            "Select      " _
            & "pj.nom_fantasia as nombre_empresa, pj.rut as rut_empresa, pj.direccion, pj.fono, pj.fax, " _
            & "us.nombres as nombre_ejecutivo, us.telefono, us.fax as fax_ejecutivo, us.email, us.rut as rut_ejecutivo, " _
            & "(select cargo_contacto from empresa_cliente where rut = ej.rut_empresa) as cargo_contacto " _
            & "From Persona_Juridica pj, Ejecutivo ej, usuario us " _
            & "Where ej.rut_empresa = [0] " _
            & "and pj.rut=ej.rut_empresa " _
            & "and ej.rut_ejecutivo=us.rut"

            s_ejecutivo_empresa = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_rut_holding(ByVal lngRutCliente As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutCliente
            strQuery = _
                "Select  isnull(rut_holding,0) rut_holding " _
                & "From empresa_cliente " _
                & "Where rut = [0]"
            s_rut_holding = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'entrega el nombre y rut del ejecutivo asociado a un supervisor
        Public Function s_ejecutivo_supervisor(ByVal lngRutSup As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutSup
            arrParam(1) = 3 ' c�digo del perfil ejecutivo
            strQuery = _
                " Select distinct u.rut, u.nombres From usuario u , supervisor s , " _
                & " ejecutivo e  " _
                & " where S.rut_supervisor=[0] and s.rut_ejecutivo=e.rut_ejecutivo " _
                & " and e.rut_ejecutivo=u.rut "

            s_ejecutivo_supervisor = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_nombre_empresa(ByVal lngRutEmpresa As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutEmpresa
            strQuery = _
                "select ec.rut, pj.razon_social, costo_admin * 100 porc_admin " _
                & "from empresa_cliente ec, persona_juridica pj " _
                & "where ec.rut=pj.rut and " _
                & "ec.rut = [0] "
            s_nombre_empresa = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Public Function s_datos_curso(ByVal strCodSence As String) As DataTable
        '    Dim strQuery As String, arrParam(0)
        '    arrParam(0) = StringSql(strCodSence)
        '    strQuery = _
        '        "select cu.codigo_sence, cu.nombre, cu.dur_cur_teorico + cu.dur_cur_prac horas, " _
        '        & "num_max_part, pj.razon_social otec " _
        '        & "from curso cu, persona_juridica pj " _
        '        & "where cu.rut_otec=pj.rut " _
        '        & "and cu.codigo_sence= [0] "
        '    s_datos_curso = ConsultaSql(SqlParam(strQuery, arrParam))
        'End Function
        Public Function s_datos_curso(ByVal strCodSence As String) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodSence)
            strQuery = _
                "select cu.codigo_sence, cu.nombre, cu.dur_cur_teorico + cu.dur_cur_prac + cu.dur_cur_elearning horas, " _
                & "num_max_part, pj.razon_social otec, pj.rut rut_otec, cu.valor_curso, cu.cod_modalidad " _
                & "from curso cu, persona_juridica pj " _
                & "where cu.rut_otec=pj.rut " _
                & "and cu.codigo_sence= [0] "
            s_datos_curso = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_datos_curso2(ByVal strCodigoSence As String) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigoSence)
            strQuery = _
                "Select dur_cur_teorico + dur_cur_prac horas_sence, " _
                & " isnull(rut_otec,0) rut_otec " _
                & "From Curso " _
                & "Where codigo_sence = [0] "
            Return ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_alumno(ByVal mlngRutAlumno As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = mlngRutAlumno
            arrParam(1) = FechaBDaUSR("pn.fecha_nacim")
            strQuery = _
               "select cast(pn.rut as varchar) rut, pn.nombre, pn.ap_paterno, " _
                & "pn.ap_materno, sexo, pn.cod_region, re.nombre region, " _
                & "pn.cod_nivel_ocup cod_nivel_ocupacional, no.nombre nivel_ocupacional, pn.porc_franquicia franquicia, " _
                & "0 viatico, 0 traslado, 0 porc_asistencia, pn.cod_nivel_educ cod_nivel_educacional, ne.nombre nivel_educacional, " _
                & "[1] fecha_nacimiento, pn.cod_comuna, co.nombre comuna,  '' existe, isnull(pn.cod_pais,1) cod_pais, pa.nombre_pais, " _
                & "isnull(pn.fono,'') fono, isnull(pn.email,'') email " _
                & "from persona_natural pn, nivel_ocupacional no, " _
                & "nivel_educacional ne, comuna co, region re, pais pa " _
                & "where pn.cod_nivel_ocup=no.cod_nivel_ocup " _
                & "and pn.cod_nivel_educ=ne.cod_nivel_educ " _
                & "and pn.cod_comuna=co.cod_comuna " _
                & "and pn.cod_region=re.cod_region and pn.cod_pais = pa.cod_pais " _
                & "and rut = [0]"
            s_alumno = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_alumno_interno(ByVal mlngRutAlumno As Long) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = mlngRutAlumno
            arrParam(1) = FechaBDaUSR("pn.fecha_nacim")
            strQuery = _
               "select cast(pn.rut as varchar) rut, pn.nombre, pn.ap_paterno, " _
                & "pn.ap_materno, sexo, pn.cod_region, re.nombre region, " _
                & "pn.cod_nivel_ocup cod_nivel_ocupacional, no.nombre nivel_ocupacional, pn.porc_franquicia franquicia, " _
                & "0 viatico, 0 traslado, pn.cod_nivel_educ cod_nivel_educacional, ne.nombre nivel_educacional, " _
                & "[1] fecha_nacimiento, pn.cod_comuna, co.nombre comuna, '' existe, 3 COD_ESTADO_PART " _
                & "from persona_natural pn, nivel_ocupacional no, " _
                & "nivel_educacional ne, comuna co, region re " _
                & "where pn.cod_nivel_ocup=no.cod_nivel_ocup " _
                & "and pn.cod_nivel_educ=ne.cod_nivel_educ " _
                & "and pn.cod_comuna=co.cod_comuna " _
                & "and pn.cod_region=re.cod_region " _
                & "and rut = [0]"
            s_alumno_interno = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_alumno2(ByVal mlngRutAlumno As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = mlngRutAlumno
            strQuery = _
               "select cast(pn.rut as varchar) rut, pn.nombre, pn.ap_paterno, " _
                & "pn.ap_materno, sexo, '' existe " _
                & "from persona_natural pn " _
                & "where rut = [0]"
            s_alumno2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'reporte de alumnos de curso e-learning
        Public Function s_alumnos_elearning(ByVal lngCodModalidad As Long, ByVal lngCodCurso As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodModalidad
            arrParam(1) = lngCodCurso

            strQuery = _
               "select cc.correlativo, cc.nro_registro," _
               & "cc.cod_estado_curso, (select ec.nombre from  Estado_Curso ec where cod_estado_curso=cc.cod_estado_curso) nombre, " _
               & "p.rut_alumno, ps.dig_verif, pnat.nombre, pnat.ap_paterno, pnat.ap_materno, " _
               & "p.porc_asistencia " _
               & "From Curso_Contratado cc, Participante p, Persona_Natural pnat, Persona ps " _
               & "Where(cc.cod_modalidad = [0]) " _
               & "And cc.cod_curso = p.cod_curso " _
               & "And pnat.rut = p.rut_alumno " _
               & "And ps.rut = pnat.rut " _
               & "and cc.cod_curso = [1]"

            s_alumnos_elearning = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        'Consulta por el �ltimo estado antes de quedar en pago por autorizar
        'si es Null devuelve estado ingresado (1)
        Public Function s_ultimo_estado_curso(ByVal lngCodCurso As Long) As Integer
            Dim strQuery As String, arrParam(0), arrTemp
            arrParam(0) = lngCodCurso

            strQuery = _
                "Select cod_ultimo_estado " _
                & "From Curso_Contratado " _
                & "Where cod_curso = [0] "

            arrTemp = ConsultaSql(SqlParam(strQuery, arrParam))
            If TamanoArreglo1(arrTemp) <> 1 Then
                s_ultimo_estado_curso = 1               'Por condici�n de borde, devuelve a estado ingresado
            Else
                s_ultimo_estado_curso = arrTemp(0, 0)   'Devuelve el �ltimo estado almacenado
            End If
        End Function
        Public Function s_monto_aportes_cliente_agno(ByVal strRutCliente As String, _
                                                     ByVal intagno As Integer, _
                                                     ByVal intCodCuenta As Integer) As Long

            Dim strQuery As String, arrParam(2)


            arrParam(0) = RutUsrALng(strRutCliente)
            arrParam(1) = intagno
            arrParam(2) = intCodCuenta

            strQuery = "Select isnull(sum(monto),0) " _
                     & "From transaccion " _
                     & "where rut_cliente = [0] and " _
                     & "year(fecha_hora) = [1] and " _
                     & "cod_aporte > 0 and cod_cuenta = [2] and " _
                     & "cod_estado_tran in(1,2,4)"
            s_monto_aportes_cliente_agno = ValorSql(SqlParam(strQuery, arrParam))
        End Function


        Public Function s_saldos_capacitacion_vyt(ByVal strRutCliente As String, _
                                                     ByVal intagno As Integer) As Long

            Dim strQuery As String, arrParam(2)


            arrParam(0) = RutUsrALng(strRutCliente)
            arrParam(1) = intagno

            strQuery = "Select isnull(sum(monto),0) * 0.1 " _
                & "From transaccion " _
                & "where rut_cliente = [0] and " _
                & "year(fecha_hora) = [1] and " _
                & "cod_cuenta = 1 and " _
                & "cod_estado_tran in(1,2,4) and cod_tipo_tran in (1,4) "
            s_saldos_capacitacion_vyt = ValorSql(SqlParam(strQuery, arrParam))
        End Function



        Public Function s_dies_vyt_excap_por_abono(ByVal strRutCliente As String, _
                                                     ByVal intagno As Integer) As Long

            Dim strQuery As String, arrParam(2)


            arrParam(0) = RutUsrALng(strRutCliente)
            arrParam(1) = intagno

            strQuery = "Select isnull(sum(monto),0) * 0.1 " _
                        & "From transaccion  " _
                        & "where rut_cliente = [0] and " _
                        & "year(fecha_hora) = [1] and " _
                        & "cod_cuenta = 4 and " _
                        & "cod_estado_tran in(1,2,4) and cod_tipo_tran in (3,4) "
            s_dies_vyt_excap_por_abono = ValorSql(SqlParam(strQuery, arrParam))
        End Function


        Public Function s_saldo_vyt_agno_anterior(ByVal strRutCliente As String, _
                                                     ByVal intagno As Integer) As Long

            Dim strQuery As String, arrParam(2)


            arrParam(0) = RutUsrALng(strRutCliente)
            arrParam(1) = intagno

            strQuery = "Select isnull(sum(monto),0) * 0.1 - (Select isnull(sum(monto),0) " _
                        & "From transaccion " _
                        & "where rut_cliente = [0] and " _
                        & "year(fecha_hora) = [1] and " _
                        & "cod_cuenta = 1 and " _
                        & "cod_estado_tran in(1,2,4) and cod_tipo_tran in (5)) " _
                        & "From transaccion " _
                        & "where rut_cliente = [0] and " _
                        & "year(fecha_hora) = [1] and " _
                        & "cod_cuenta = 1 and " _
                        & "cod_estado_tran in(1,2,4) and cod_tipo_tran in (1) "
            s_saldo_vyt_agno_anterior = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        Public Function s_monto_usado_en_VYT(ByVal strRutCliente As String, _
                                     ByVal intagno As Integer, _
                                     ByVal intCodCuenta As Integer) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = RutUsrALng(strRutCliente)
            arrParam(1) = intagno
            arrParam(2) = intCodCuenta

            strQuery = "Select isnull(sum(monto),0) from transaccion " _
                     & "Where rut_cliente = [0] " _
                     & "and year(fecha_hora) = [1] " _
                     & "and cod_curso > 0 " _
                     & "and cod_tipo_tran = 5 " _
                     & "and cod_cuenta = [2]"

            s_monto_usado_en_VYT = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_monto_abono_excedente_cliente_agno(ByVal strRutCliente As String, _
                                                     ByVal intagno As Integer) As Long
            Dim strQuery As String, arrParam(1)
            Dim consulta As DataTable
            arrParam(0) = RutUsrALng(strRutCliente)
            arrParam(1) = intagno

            strQuery = "Select monto from transaccion " _
                     & "where rut_cliente = [0] " _
                     & "and year(fecha_hora) = [1] " _
                     & "and month(fecha_hora) = 1 " _
                     & "and cod_cuenta = 4 " _
                     & "and cod_tipo_tran = 3"
            consulta = ConsultaSql(SqlParam(strQuery, arrParam))
            If consulta.Rows.Count = 0 Then
                s_monto_abono_excedente_cliente_agno = 0
            Else
                s_monto_abono_excedente_cliente_agno = CLng(consulta.Rows.Item(0)(0))
            End If
        End Function
        'Public Function s_indicadores1(ByVal lngRutEjecutivo As Long, _
        '                                ByVal lngAgnoCurso As Long, _
        '                                ByVal lngRutUsuario As Long) As DataTable

        '    Dim strQuery As String, arrParam(2)
        '    arrParam(0) = lngRutEjecutivo
        '    arrParam(1) = lngAgnoCurso
        '    arrParam(2) = lngRutUsuario


        '    Dim strWhere, strFrom As String
        '    strFrom = ""
        '    strWhere = ""
        '    If lngRutEjecutivo = 1 Then
        '        strWhere = strWhere & " And  e.rut_ejecutivo = [2]  "
        '        strFrom = strFrom & ", ejecutivo e "
        '    ElseIf lngRutEjecutivo = 2 Then
        '        strWhere = strWhere & " And e.rut_empresa=cc.rut_cliente and  s.rut_supervisor=[2] " _
        '                 & " And s.rut_ejecutivo=e.rut_ejecutivo "
        '        strFrom = strFrom & ", ejecutivo e ,supervisor s "
        '    ElseIf lngRutEjecutivo = gValorNumNulo Then
        '        strWhere = strWhere & ""
        '    End If

        '    strQuery = _
        '        "select '01' orden,'Incompletos' indicador, count(distinct cc.cod_curso) cantidad, '0' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (0) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '02' orden,'Ingresados' indicador, count(distinct cc.cod_curso) cantidad, '1' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where  cc.agno = [1] and cc.cod_estado_curso in (1) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '03' orden,'Rechazados' indicador, count(distinct cc.cod_curso) cantidad, '2' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (2) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '04' orden,'Autorizados' indicador, count(distinct cc.cod_curso) cantidad, '3' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (3) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '05' orden,'Pago por autorizar' indicador, count(distinct cc.cod_curso) cantidad, '6' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (6) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '06' orden,'Comunicados' indicador, count(distinct cc.cod_curso) cantidad, '4,11' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (4,11) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '07' orden,'Liquidados' indicador, count(distinct cc.cod_curso) cantidad, '5' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (5) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '08' orden,'En comunicacion' indicador, count(distinct cc.cod_curso) cantidad, '7' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (7) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '09' orden,'En liquidacion' indicador, count(distinct cc.cod_curso) cantidad, '9' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (9) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '10' orden,'Eliminados' indicador, count(distinct cc.cod_curso) cantidad, '8' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (8) " _
        '        & strWhere _
        '        & " Union " _
        '        & "select '11' orden,'Anulados' indicador, count(distinct cc.cod_curso) cantidad, '10' estados " _
        '        & "From Curso_Contratado cc " _
        '        & strFrom _
        '        & "Where cc.agno = [1] and cc.cod_estado_curso in (10) " _
        '        & strWhere
        '    s_indicadores1 = ConsultaSql(SqlParam(strQuery, arrParam))
        'End Function
        Public Function s_indicadores1(ByVal lngRutEjecutivo As Long, _
                                        ByVal lngAgnoCurso As Long, _
                                        ByVal lngRutUsuario As Long) As DataTable

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRutEjecutivo
            arrParam(1) = lngAgnoCurso
            arrParam(2) = lngRutUsuario


            Dim strWhere, strFrom As String
            strFrom = ""
            strWhere = ""
            If lngRutEjecutivo = 1 Then
                strWhere = strWhere & " And  e.rut_ejecutivo = [2]  "
                strFrom = strFrom & ", ejecutivo e "
            ElseIf lngRutEjecutivo = 2 Then
                strWhere = strWhere & " And e.rut_empresa=cc.rut_cliente and  s.rut_supervisor=[2] " _
                         & " And s.rut_ejecutivo=e.rut_ejecutivo "
                strFrom = strFrom & ", ejecutivo e ,supervisor s "
            ElseIf lngRutEjecutivo = gValorNumNulo Then
                strWhere = strWhere & ""
            End If

            strQuery = _
                "select '01' orden,'Incompletos' indicador, count(distinct cc.cod_curso) cantidad, '0' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (0) " _
                & strWhere _
                & " Union " _
                & "select '02' orden,'Ingresados' indicador, count(distinct cc.cod_curso) cantidad, '1' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where  cc.agno = [1] and cc.cod_estado_curso in (1) " _
                & strWhere _
                & " Union " _
                & "select '03' orden,'Rechazados' indicador, count(distinct cc.cod_curso) cantidad, '2' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (2) " _
                & strWhere _
                & " Union " _
                & "select '04' orden,'Autorizados' indicador, count(distinct cc.cod_curso) cantidad, '3' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (3) " _
                & strWhere _
                & " Union " _
                & "select '05' orden,'Pago por autorizar' indicador, count(distinct cc.cod_curso) cantidad, '6' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (6) " _
                & strWhere _
                & " Union " _
                & "select '06' orden,'Comunicados' indicador, count(distinct cc.cod_curso) cantidad, '4,11' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (4,11) " _
                & strWhere _
                & " Union " _
                & "select '07' orden,'Liquidados' indicador, count(distinct cc.cod_curso) cantidad, '5' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (5) " _
                & strWhere _
                & " Union " _
                & "select '08' orden,'En comunicacion' indicador, count(distinct cc.cod_curso) cantidad, '7' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (7) " _
                & strWhere _
                & " Union " _
                & "select '09' orden,'En liquidacion' indicador, count(distinct cc.cod_curso) cantidad, '9' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (9) " _
                & strWhere _
                & " Union " _
                & "select '10' orden,'Eliminados' indicador, count(distinct cc.cod_curso) cantidad, '8' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (8) " _
                & strWhere _
                & " Union " _
                & "select '11' orden,'Anulados' indicador, count(distinct cc.cod_curso) cantidad, '10' estados " _
                & "From Curso_Contratado cc " _
                & strFrom _
                & "Where cc.agno = [1] and cc.cod_estado_curso in (10) " _
                & strWhere
            s_indicadores1 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_indicadores2(ByVal lngAgnoCurso As Long, _
                                        ByVal lngRutUsuario As Long, ByVal lngRutEjecutivo As Long) As DataTable
            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngRutUsuario
            arrParam(1) = lngAgnoCurso
            arrParam(2) = FechaVbABd(Now.Date) ' HOY
            arrParam(3) = FechaVbABd(DateAdd("w", 1, Now.Date)) ' HOY + 1 DIA HABIL
            arrParam(4) = lngRutEjecutivo
            arrParam(5) = FechaVbABd(DateAdd("d", -50, Now.Date))

            Dim intAgnoComplemento As Integer = lngAgnoCurso + 1

            Dim strFromPagoTerceros As String = ""
            Dim strWherePagoTerceros As String = ""

            If lngRutEjecutivo = 1 Then
                strWherePagoTerceros = strWherePagoTerceros & " And  e.rut_ejecutivo = [0]  "
            ElseIf lngRutEjecutivo = 2 Then
                strWherePagoTerceros = strWherePagoTerceros & " And s.rut_supervisor=[0] " _
                         & " And s.rut_ejecutivo=e.rut_ejecutivo "
                strFromPagoTerceros = strFromPagoTerceros & " ,supervisor s "
            ElseIf lngRutEjecutivo = gValorNumNulo Then
                strWherePagoTerceros = strWherePagoTerceros & ""
                'Else
                '    strWherePagoTerceros = strWherePagoTerceros & " And  e.rut_ejecutivo = [0]  "
            End If
            '& intAgnoComplemento & " " _
            strQuery = _
                "select '01' orden,'Con complemento' indicador,count(distinct cc.cod_curso) cantidad, '1' tipo " _
                & "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_curso_compl Is Not Null " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] " _
                & "And cc.cod_estado_curso Not In (0,2,8,10) and year(cc.fecha_inicio) = [1] " _
                & " union " _
                & "select '02' orden,'Complementarios' indicador,count(distinct cc.cod_curso) cantidad, '2' tipo " _
                & "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_curso_parcial Is Not Null " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] " _
                & "And cc.agno = [1]" _
                & "And cc.cod_estado_curso Not In (0,2,8,10) " _
                & " union " _
                & "select '03' orden,'Iniciados sin comunicar' indicador,count(distinct cc.cod_curso) cantidad, '3' tipo " _
                & "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where (cc.cod_estado_curso = 1 Or " _
                & "cc.cod_estado_curso = 3 Or cc.cod_estado_curso = 6) " _
                & "And cc.fecha_inicio < [2] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '04' orden,'Iniciados sin autorizar' indicador,count(distinct cc.cod_curso) cantidad, '4' tipo " _
                & "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where (cc.cod_estado_curso = 1 Or " _
                & "cc.cod_estado_curso = 6) And cc.fecha_inicio < [2] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '05' orden,'Terminados sin asistencia' indicador,count(distinct cc.cod_curso) cantidad, '5' tipo " _
                & "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.Fecha_Termino < [2] And cc.num_alumnos = (Select Count(*) From participante p " _
                & "Where p.cod_curso = cc.cod_curso And porc_asistencia = 0.0) " _
                & "And cc.cod_estado_curso <> 0 And cc.Cod_estado_curso <> 2 " _
                & "And cc.cod_estado_curso <> 8 And cc.Cod_estado_curso <> 10 " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '06' orden,'Terminados, con asistencia, sin liquidar' indicador,count(distinct cc.cod_curso) cantidad, '6' tipo " _
                & "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.Fecha_Termino < [2] And cc.num_alumnos <> (Select Count(*) From participante p " _
                & "Where p.cod_curso = cc.cod_curso And p.porc_asistencia = 0.0) " _
                & "And cc.Cod_estado_curso <> 5 And cc.Cod_Estado_Curso <> 9 " _
                & "And cc.Cod_estado_curso <> 8 And cc.Cod_Estado_Curso <> 10 " _
                & "And cc.Cod_estado_curso <> 0 And cc.Cod_Estado_Curso <> 2 " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '07' orden,'Comunicacion atrasada' indicador,count(distinct cc.cod_curso) cantidad, '7' tipo " _
                & "From Curso_Contratado cc , v_cliente_permiso vcp " _
                & "Where (cc.cod_estado_curso = 0 Or " _
                & "cc.cod_estado_curso = 1 Or cc.cod_estado_curso = 2 " _
                & " Or cc.cod_estado_curso = 3 or cc.cod_estado_curso = 7) " _
                & " And cc.fecha_inicio >= [3] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '08' orden,'Fecha de termino mayor a hoy + 55' indicador,count(distinct cc.cod_curso) cantidad, '8' tipo " _
                & "From Curso_Contratado cc , v_cliente_permiso vcp " _
                & "Where (DateAdd(day, 55, cc.fecha_termino )) >= [2] and " _
                & "cc.cod_estado_curso <> 5 and cc.cod_estado_curso <> 8 " _
                & "and cc.cod_estado_curso <> 10 " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '09' orden,'Con pago de Terceros' indicador,count(distinct cc.cod_curso) cantidad, '9' tipo " _
                & " From Curso_Contratado cc , Solicitud_Pago_Terceros spt ,v_cliente_permiso vcp, " _
                & " ejecutivo e " _
                & strFromPagoTerceros _
                & " Where vcp.rut_usuario = [0] " _
                & " And vcp.rut_empresa=cc.rut_cliente " _
                & " And e.rut_empresa=cc.rut_cliente " _
                & " And cc.cod_curso=spt.cod_curso " _
                & " And cc.cod_estado_curso <> 8 " _
                & " And cc.cod_estado_curso <> 10 and cc.agno = [1] " _
                & strWherePagoTerceros _
                & " union " _
                & "select '10' orden,'Pagados solo con cuenta de capacitacion' indicador,count(distinct cc.cod_curso) cantidad, '10' tipo " _
                & "From curso_contratado cc  " _
                & "where cc.cod_curso in ( Select cc1.cod_curso " _
                & "From Transaccion tr1 , Curso_Contratado cc1 , " _
                & " ejecutivo e " _
                & strFromPagoTerceros _
                & "Where cc1.rut_cliente=e.rut_empresa  " _
                & strWherePagoTerceros _
                & "and cc1.rut_cliente=tr1.rut_cliente " _
                & "and cc1.cod_curso = tr1.cod_curso " _
                & "And nro_transaccion = (Select Max(tr2.nro_transaccion) " _
                & "From Transaccion tr2 " _
                & "Where tr2.cod_curso = tr1.cod_curso " _
                & "and tr2.cod_cuenta = tr1.cod_cuenta " _
                & "and tr2.rut_cliente = tr1.rut_cliente " _
                & "and tr2.cod_cuenta <> 3 ) And monto > 0 and cc.agno = [1] " _
                & "group by cc1.cod_curso " _
                & "HAVING (min(tr1.cod_cuenta)=1) and max(tr1.cod_cuenta)=1) " _
                & " union " _
                & "select '11' orden,'Pagados con cuenta de exc. capacitacion' indicador,count(distinct cc.cod_curso) cantidad, '11' tipo " _
                & " From curso_contratado cc " _
                & " where cc.cod_curso in (Select cc1.cod_curso " _
                & " From Transaccion tr1 , Curso_Contratado cc1,v_cliente_permiso vcp, " _
                & " ejecutivo e  " _
                & strFromPagoTerceros _
                & " Where vcp.rut_usuario = [0] " _
                & " And vcp.rut_empresa =cc1.rut_cliente " _
                & " and cc1.rut_cliente=tr1.rut_cliente " _
                & " And cc1.rut_cliente=e.rut_empresa " _
                & " and cc1.cod_curso = tr1.cod_curso " _
                & strWherePagoTerceros _
                & " And nro_transaccion = (Select Max(tr2.nro_transaccion) " _
                & " From Transaccion tr2 " _
                & " Where tr2.cod_curso = tr1.cod_curso " _
                & " And tr2.cod_cuenta = tr1.cod_cuenta " _
                & " And tr2.rut_cliente = tr1.rut_cliente " _
                & " and tr2.cod_cuenta <> 3 ) " _
                & " And monto > 0 and tr1.cod_cuenta = 4) and cc.agno = [1] " _
                & " union " _
                & "select '12' orden,'Con viaticos y traslado' indicador,count(distinct cc.cod_curso) cantidad, '12' tipo " _
                & "From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where (cc.total_viatico > 0 OR cc.total_traslado > 0) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "And vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '13' orden,'No liquidados con fecha de termino menor a hoy - 50' indicador,count(distinct cc.cod_curso) cantidad, '13' tipo " _
                & "From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where [5] > cc.fecha_termino " _
                & "And cc.cod_estado_curso not in (5,10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '14' orden,'Con precontrato' indicador,count(distinct cc.cod_curso) cantidad, '14' tipo " _
                & "From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_tipo_activ = 2 " _
                & "And cc.cod_estado_curso not in (10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] and cc.agno = [1] " _
                & " union " _
                & "select '15' orden,'Con postcontrato' indicador,count(distinct cc.cod_curso) cantidad, '15' tipo " _
                & " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_tipo_activ = 3 " _
                & "And cc.cod_estado_curso not in (10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] and cc.agno = [1] " _
                & "union " _
                & "select '16' orden, 'Presenciales' indicador, count(distinct cc.cod_curso) cantidad, '16' tipo " _
                & "from curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_modalidad = 1 And cc.cod_estado_curso not in (10,8) And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] and cc.agno = [1] " _
                & "union " _
                & "select '17' orden, 'E-Learning' indicador, count(distinct cc.cod_curso) cantidad, '17' tipo " _
                & "from curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_modalidad = 2 And cc.cod_estado_curso not in (10,8) And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] and cc.agno = [1] " _
                & "union " _
                & "select '18' orden, 'A Distancia' indicador, count(distinct cc.cod_curso) cantidad, '18' tipo " _
                & "from curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_modalidad = 4 And cc.cod_estado_curso not in (10,8) And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] and cc.agno = [1] "


            s_indicadores2 = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'listado de aportes
        Public Function s_aportes_3(ByVal lngRutUsuario As Long, ByVal lngRutCliente As Long, _
                                    ByVal intCodEstado As Integer, ByVal intCodTipoDoc As Integer, _
                                    Optional ByVal intAgno As Integer = 0)
            Dim strQuery, strWhere As String, arrParam(4)
            arrParam(0) = lngRutUsuario
            arrParam(1) = lngRutCliente
            arrParam(2) = intCodEstado
            arrParam(3) = intCodTipoDoc
            arrParam(4) = intAgno

            strWhere = ""

            If lngRutCliente <> 0 Then
                strWhere = "And a.Rut_Cliente = [1] " & strWhere
            End If
            If intCodEstado <> 0 Then
                strWhere = "And a.cod_estado = [2] " & strWhere
            End If
            If intCodTipoDoc <> 0 Then
                strWhere = "And a.cod_tipo_doc = [3] " & strWhere
            End If
            If intAgno <> 0 Then
                strWhere = " And year(a.fecha) = [4] " & strWhere
            End If

            strQuery = _
                "Select Count(Distinct a.cod_aporte) From aporte a, v_cliente_permiso vcp " _
                & "Where " _
                & "a.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] " _
                & strWhere


            s_aportes_3 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_sol_pago_terc1(ByVal lngRutUsuario As Long, _
                                ByVal lngRutCliente As Long, _
                                ByVal intCodEstado As Integer, _
                                Optional ByVal intAgno As Integer = 0) As Long

            Dim strQuery, strWhere As String, arrParam(3)
            arrParam(0) = lngRutUsuario
            arrParam(1) = lngRutCliente
            arrParam(2) = intCodEstado
            arrParam(3) = intAgno

            strWhere = ""


            If lngRutCliente <> 0 Then
                strWhere = "And s.rut_benefactor = [1] " & strWhere
            End If
            If intCodEstado <> 0 Then
                strWhere = "And s.cod_estado_solicitud = [2] " & strWhere
            End If
            If intAgno <> 0 Then
                strWhere = " And year(s.fecha_ingreso) = [3] " & strWhere
            End If

            strQuery = _
                "Select count(distinct s.cod_solicitud_pago) " _
                & "From Solicitud_Pago_Terceros s, v_cliente_permiso vcp " _
                & "Where s.rut_benefactor = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] " _
                & strWhere

            s_sol_pago_terc1 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Selecciona los ruts de los alumnos participantes en un curso interno.
        Public Function s_rut_partic_interno(ByVal lngCorrelativo As Long, ByVal intAgno As Integer, Optional ByVal dblRutAlumno As Double = 0) As Object

            Dim strQuery, strWhere As String, arrParam(2)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno
            strWhere = ""
            If dblRutAlumno <> 0 Then
                arrParam(2) = dblRutAlumno
                strWhere = strWhere & " AND rut = [2] "
            End If
            strQuery = _
                    "Select rut " _
                    & "From Participante_interno " _
                    & "Where correlativo = [0] and ano = [1] " _
                    & strWhere

            s_rut_partic_interno = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        'Consulta los datos de un alumno participante en un curso interno,
        'por el codigo interno del curso y el rut del alumno.
        'Supone que el alumno existe en las tabla Participante y Persona_Natural
        Public Function s_partic_curso_interno(ByVal lngCorrelativo As Long, _
                                                ByVal intAgno As Integer, _
                                       ByVal lngRutAlumno As Long) As Object

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno
            arrParam(2) = lngRutAlumno

            strQuery = _
                    "Select p.correlativo, pn.nombre, pn.ap_paterno, pn.ap_materno, " _
                    & "pn.sexo, p.ano,p.rut, p.viatico, p.traslado, p.COD_ESTADO_PART " _
                    & "From Participante_interno p, Persona_Natural pn " _
                    & "Where p.rut = pn.rut And p.correlativo = [0] And p.ano = [1] And " _
                    & "p.rut = [2] "

            s_partic_curso_interno = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_partic_curso_interno3(ByVal lngCorrelativo As Long, _
                                                ByVal intAgno As Integer) As DataTable

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno

            strQuery = _
                    "select cast(pi.rut as varchar) + '-' + cast(pe.dig_verif as varchar) as rut, " _
                    & "(pn.nombre + ' ' + pn.ap_paterno + ' ' + pn.ap_materno) as nombre, " _
                    & "((ci.valor_curso / ci.num_participantes) + (pi.viatico + pi.traslado)) as total_costo_alumno, " _
                    & " sum(pi.viatico + pi.traslado) as total_vyt " _
                    & "from participante_interno pi, persona_natural pn, curso_interno ci, persona pe " _
                    & "where pi.rut = pn.rut and pn.rut = pe.rut and ci.correlativo = pi.correlativo " _
                    & "and ci.ano = pi.ano and ci.correlativo = [0] and ci.ano = [1] " _
                    & "group by pi.rut,pe.dig_verif,pn.nombre,pn.ap_paterno,pn.ap_materno, " _
                    & "ci.valor_curso, ci.num_participantes, pi.viatico, pi.traslado"

            s_partic_curso_interno3 = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        'Consulta los datos de un alumno participante en un curso interno,
        'por el codigo interno del curso y el rut del alumno.
        'Supone que el alumno existe en las tabla Participante y Persona_Natural
        Public Function s_partic_curso_interno2(ByVal lngCorrelativo As Long, _
                                                ByVal lngRutAlumno As Long) As Object

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCorrelativo
            arrParam(1) = lngRutAlumno

            strQuery = _
                    "Select p.correlativo, pn.nombre, pn.ap_paterno, pn.ap_materno, " _
                    & "pn.sexo, p.ano " _
                    & "From Participante_interno p, Persona_Natural pn " _
                    & "Where p.rut = pn.rut And p.correlativo = [0] And " _
                    & "p.rut = [1] "

            s_partic_curso_interno2 = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        'consulta los c�digos de cursos contratados en comunicacion y en liquidacion
        Public Function s_cursos_en_comuni_en_liquid(ByVal blnEnComunicacion As Boolean, ByVal blnEnLiquidacion As Boolean, _
                                                        ByVal strCodigosCursos As String) As DataTable
            Dim strQuery As String, arrParam(2)
            arrParam(0) = blnEnComunicacion
            arrParam(1) = blnEnLiquidacion
            arrParam(2) = strCodigosCursos
            Dim strWhere As String = ""
            If blnEnComunicacion = True Then
                strWhere = "and cod_estado_curso = 7 "
            End If
            If blnEnLiquidacion = True Then
                strWhere = "and cod_estado_curso = 9 "
            End If
            If blnEnComunicacion = True And blnEnLiquidacion = True Then
                strWhere = "and cod_estado_curso In (7, 9) "
            End If

            strQuery = _
                "Select cod_curso " _
                & "From Curso_Contratado " _
                & "where cod_curso in([2]) " _
                & strWhere
            s_cursos_en_comuni_en_liquid = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Verifica si ya existe registro en Access para no provocar error de claves duplicadas
        Public Function s_existe_registro_Access(ByVal lngCodigoCurso As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodigoCurso
            strQuery = _
                "select count(*) " & _
                " from acc_cap " & _
                " Where id_acc_cap = [0]"
            s_existe_registro_Access = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        'clientes con franquicia y franquicia toyal ocupada
        Public Function s_clientes_franquicia( _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                ByVal lngRutUsuario As Long, _
                Optional ByVal strListaRuts As String = "" _
            ) As Object
            Dim strQuery As String, arrParam(6)
            arrParam(0) = intCodSucursal
            arrParam(1) = lngRutEjecutivo
            arrParam(2) = FechaVbABd(dtmInicio)
            arrParam(3) = FechaVbABd(DateAdd("d", 1, dtmFin))  'sumar un d�a
            arrParam(4) = Year(dtmInicio)
            arrParam(5) = strListaRuts
            arrParam(6) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [0] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [1] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If
            If strListaRuts <> "" Then
                strWhere = " And ec.rut In ([5]) " & strWhere
            End If

            'devuelve rut del cliente, valor de franquicia,
            'cargos en cuentas cap, rep y adm, y vi�ticos+traslados
            strQuery = _
                " Select ec.rut, fq.valor, " _
                & "(Select IsNull(Sum(monto), 0) From Transaccion " _
                & " Where cod_tipo_tran = 2 " _
                & " And cod_cuenta In (1, 2, 3) " _
                & " And fecha_hora >= [2] " _
                & " And fecha_hora < [3] " _
                & " And rut_cliente = ec.rut), " _
                & "(Select IsNull(Sum(cc.total_viatico + cc.total_traslado), 0) " _
                & " From Curso_Contratado cc " _
                & " Where cc.Agno = [4] " _
                & " And cc.cod_estado_curso In (1,2,3,4,5,6,7,9,11) " _
                & " And cc.fecha_inicio >= [2] " _
                & " And cc.fecha_inicio < [3] " _
                & " And cc.rut_cliente = ec.rut) " _
                & "From Empresa_Cliente ec, Franquicia fq " _
                & strFrom _
                & "Where ec.Rut = fq.Rut " _
                & "And fq.valor > 0 " _
                & "And fq.agno = [4] " _
                & "And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [6]) " _
                & strWhere
            s_clientes_franquicia = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'suma de valores asociados a los aportes
        'El par�metro strCampo indica el valor considerado: monto_neto, monto_adm
        Public Function s_suma_aportes( _
                ByVal strCampo As String, ByVal strRutsClientes As String, _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                Optional ByVal lngRutUsuario As Long = 0 _
            ) As Decimal
            Dim strQuery As String, arrParam(6)
            arrParam(0) = strCampo
            arrParam(1) = strRutsClientes
            arrParam(2) = intCodSucursal
            arrParam(3) = lngRutEjecutivo
            arrParam(4) = FechaVbABd(dtmInicio)
            arrParam(5) = FechaVbABd(dtmFin)
            arrParam(6) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [2] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [3] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If
            If strRutsClientes <> "" Then
                strWhere = " And ap.rut_cliente In ([1]) " & strWhere
            End If
            If lngRutUsuario <> 0 Then
                strWhere = " And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [6]) " & strWhere
            End If

            strQuery = _
                " Select IsNull(Sum( Cast([0] as FLOAT) ), 0)" _
                & " From Aporte ap, Empresa_Cliente ec " _
                & strFrom _
                & " Where ap.cod_estado <> 3 " _
                & " And ap.fecha Between [4] And [5] " _
                & " And ec.rut = ap.rut_cliente " _
                & strWhere
            s_suma_aportes = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'retorna el n�mero de facturas que cumplen con los criterios indicados
        Public Function s_factura_cont(ByVal intEstado As Integer, ByVal strRutsClientes As String, _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                ByVal lngRutUsuario As Long) As Long

            Dim strQuery As String, arrParam(6)
            arrParam(0) = strRutsClientes
            arrParam(1) = intCodSucursal
            arrParam(2) = lngRutEjecutivo
            arrParam(3) = FechaVbABd(dtmInicio)
            arrParam(4) = FechaVbABd(dtmFin)
            arrParam(5) = intEstado
            arrParam(6) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Or lngRutEjecutivo <> 0 Then
                strFrom = ",Empresa_Cliente ec "
                strWhere = " And ec.rut = cc.rut_cliente "

                If intCodSucursal <> 0 Then
                    strWhere = " And ec.cod_sucursal = [1] " & strWhere
                End If
                If lngRutEjecutivo <> 0 Then
                    strFrom = ",Ejecutivo ej " & strFrom
                    strWhere = " And ej.rut_ejecutivo = [2] " _
                             & " And ej.rut_empresa = ec.rut " & strWhere
                End If
            End If
            If strRutsClientes <> "" Then
                strWhere = " And cc.rut_cliente In ([0]) " & strWhere
            End If

            strQuery = _
                "Select Count(*) " _
                & "From Factura fc, Curso_Contratado cc " _
                & strFrom _
                & "Where fc.fecha Between [3] And [4] " _
                & "And fc.cod_curso = cc.cod_curso " _
                & "And fc.cod_estado_fact = [5] " _
                & "And cc.rut_cliente In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [6]) " _
                & strWhere
            s_factura_cont = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'suma de montos en las cuenta espec�fica, seg�n par�metros indicados
        Public Function s_transaccion_suma_cuenta(ByVal strCodCuenta As String, _
                ByVal strRutsClientes As String, _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                ByVal lngRutUsuario As Long) As Long

            Dim strQuery As String, arrParam(6)
            arrParam(0) = strRutsClientes
            arrParam(1) = intCodSucursal
            arrParam(2) = lngRutEjecutivo
            arrParam(3) = FechaVbABd(dtmInicio)
            arrParam(4) = FechaVbABd(dtmFin)
            arrParam(5) = strCodCuenta
            arrParam(6) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Or lngRutEjecutivo <> 0 Then
                strFrom = ",Empresa_Cliente ec "
                strWhere = " And ec.rut = tr.rut_cliente "

                If intCodSucursal <> 0 Then
                    strWhere = " And ec.cod_sucursal = [1] " & strWhere
                End If
                If lngRutEjecutivo <> 0 Then
                    strFrom = ",Ejecutivo ej " & strFrom
                    strWhere = " And ej.rut_ejecutivo = [2] " _
                             & " And ej.rut_empresa = ec.rut " & strWhere
                End If
            End If
            If strRutsClientes <> "" Then
                strWhere = " And tr.rut_cliente In ([0]) " & strWhere
            End If

            strQuery = _
                "Select IsNull(Sum(tr.monto), 0) " _
                & "From Transaccion tr, Curso_Contratado cc " _
                & strFrom _
                & "Where tr.cod_tipo_tran = 2 " _
                & "And tr.cod_cuenta In ([5]) " _
                & "And cc.fecha_inicio >= [3] " _
                & "And cc.fecha_inicio < [4] " _
                & "And tr.cod_curso = cc.cod_curso " _
                & "And cc.rut_cliente In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [6]) " _
                & strWhere
            s_transaccion_suma_cuenta = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'suma de pagos de terceros
        'suma de montos en una cuenta espec�fica, seg�n par�metros indicados
        Public Function s_transaccion_suma_de_terceros( _
                ByVal strRutsClientes As String, _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                ByVal lngRutUsuario As Long) As Long

            Dim strQuery As String, arrParam(5)
            arrParam(0) = strRutsClientes
            arrParam(1) = intCodSucursal
            arrParam(2) = lngRutEjecutivo
            arrParam(3) = FechaVbABd(dtmInicio)
            arrParam(4) = FechaVbABd(dtmFin)
            arrParam(5) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Or lngRutEjecutivo <> 0 Then
                strFrom = ",Empresa_Cliente ec "
                strWhere = " And ec.rut = tr.rut_cliente "

                If intCodSucursal <> 0 Then
                    strWhere = " And ec.cod_sucursal = [1] " & strWhere
                End If
                If lngRutEjecutivo <> 0 Then
                    strFrom = ",Ejecutivo ej " & strFrom
                    strWhere = " And ej.rut_ejecutivo = [2] " _
                             & " And ej.rut_empresa = ec.rut " & strWhere
                End If
            End If
            If strRutsClientes <> "" Then
                strWhere = " And cc.rut_cliente In ([0]) " & strWhere
            End If

            strQuery = _
                "Select IsNull(Sum(tr.monto), 0) " _
                & "From Transaccion tr, Curso_Contratado cc " _
                & strFrom _
                & "Where tr.cod_tipo_tran = 2 " _
                & "And tr.cod_cuenta In (2,5) " _
                & "And cc.fecha_inicio >= [3] " _
                & "And cc.fecha_inicio < [4] " _
                & "And tr.cod_curso = cc.cod_curso " _
                & "And cc.rut_cliente In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [5]) " _
                & strWhere
            s_transaccion_suma_de_terceros = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Verifica si ya existe registro en Access para no provocar error de claves duplicadas
        Public Function s_Horario_Access(ByVal lngCodigoCurso As Long, _
                                         ByVal intDia As Integer, _
                                         ByVal strHoraInicio As String) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodigoCurso
            arrParam(1) = intDia
            arrParam(2) = StringSql(strHoraInicio)
            strQuery = _
                "select count(*) from horario " & _
                                            "where id_acc_cap=[0] and " & _
                                            "dia_clase=[1] and " & _
                                            "hora_desde=[2]"
            s_Horario_Access = ValorSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_PersonaNatural_Access(ByVal lngRut As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut
            strQuery = _
                "select count(*) from pers_nat where rut_num_pers_nat=[0]"
            s_PersonaNatural_Access = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'consulta de clientes
        Public Function s_cursos_internos(ByVal lngRutCliente As Long, _
                                        ByVal intAgno As Integer) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno

            'consulta
            strQuery = _
            "select correlativo,ci.cod_estado_curso_interno,ec.nombre,nombre_curso, " _
            & "ejecutor,num_participantes,inicio_curso, " _
            & "fin_curso , valor_curso, correlativo_empresa, ci.Rut, cl.razon_social " _
            & "from curso_interno ci,estado_curso_interno ec,persona_juridica cl " _
            & "Where ci.Rut = [0] " _
            & "And ano = [1] " _
            & "And ci.cod_estado_curso_interno=ec.cod_estado_curso_interno " _
            & "And ci.rut=cl.rut "

            s_cursos_internos = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_cursos_internos_todos(ByVal lngRutCliente As Long, _
                                        ByVal intAgno As Integer) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno
            Dim strWhere As String
            Dim strWhere2 As String
            If lngRutCliente <> 0 Then
                strWhere = " ci.Rut = [0] And "
            Else
                strWhere = ""
            End If
            If intAgno <> 0 Then
                strWhere2 = " ano = [1] And "
            Else
                strWhere2 = ""
            End If

            'consulta
            strQuery = _
            "select row_number() over (order by correlativo) as nFila, correlativo,ci.cod_estado_curso_interno,ec.nombre,nombre_curso, " _
            & "ejecutor,num_participantes,inicio_curso, " _
            & "fin_curso , valor_curso, correlativo_empresa, ci.Rut,pe.dig_verif, cl.razon_social " _
            & "from curso_interno ci,estado_curso_interno ec,persona_juridica cl, persona pe " _
            & "Where " & strWhere & strWhere2 & " ci.cod_estado_curso_interno=ec.cod_estado_curso_interno " _
            & "And ci.rut=cl.rut " _
            & "and pe.rut = cl.rut "

            s_cursos_internos_todos = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_duracion_curso(ByVal CodSence As String) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(CodSence)
            strQuery = _
                "select dur_cur_teorico + dur_cur_prac duracion_curso from curso where codigo_sence = [0]"
            s_duracion_curso = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_participante_access(ByVal lngCodigoCurso As Long, _
                                              ByVal lngRutEmpresa As Long, _
                                              ByVal lngRutAlumno As Long) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodigoCurso
            arrParam(1) = lngRutEmpresa
            arrParam(2) = lngRutAlumno
            strQuery = _
                "select count(*) from participante  " & _
                                "where id_acc_cap=[0] and " & _
                                " rut_num_pers_jur=[1] and " & _
                                " rut_num_pers_nat=[2]"
            s_participante_access = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_persona_juridica_access(ByVal lngRutCliente As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutCliente
            strQuery = _
                "select count(*) from pers_jur where rut_num_pers_jur=[0] "
            s_persona_juridica_access = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_organismo_acc_cap_access(ByVal lngCodigoCurso As Long, _
                                                ByVal lngRutOtec As Long) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodigoCurso
            arrParam(1) = lngRutOtec
            strQuery = _
                "select count(*) " & _
                                " from  organismo_acc_cap where id_acc_cap=[0] and " & _
                                " rut_num_pers_jur=[1]"
            s_organismo_acc_cap_access = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_ctas_otic_access(ByVal lngCodigoCurso As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodigoCurso
            strQuery = _
                "select count(*) from acc_cuenta_otic Where id_acc_cap = [0]"
            s_ctas_otic_access = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_doc_pago_access(ByVal lngCodigoCurso As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodigoCurso
            strQuery = _
                "select count(*) from doc_pago where id_acc_cap= [0]"
            s_doc_pago_access = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_codigo_curso(ByVal lngCorrelativo As Long, ByVal intAgno As Integer) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno
            strQuery = _
                "select cod_estado_curso from curso_contratado where correlativo = [0] and agno = [1]"
            s_codigo_curso = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'Estado de los cursos
        Public Function s_estado_curso(ByVal intCodEstado As Integer) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodEstado
            strQuery = _
                "Select cod_estado_curso, nombre " _
                & "From  estado_curso " _
                & " where estado_curso.cod_estado_curso = [0] or [0] = 0 "
            s_estado_curso = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_carga_mdb_1() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select " _
                            & "id_acc_cap,id_comuna, " _
                            & "fec_ini_acc_cap, cod_sence, " _
                            & "fec_ter_acc_cap," _
                            & "id_comunicador,dir_acc_cap, " _
                            & "tipo_accion_cap,observ_acc_cap, " _
                            & "valor_total_curso, " _
                            & "ind_acu_com_bip, tipo_operacion, " _
                            & "id_det_nece,tipo_actividad_cap " _
                            & "From acc_cap where id_acc_cap > 0 "
            Return ConsultaSql(strQuery)
        End Function
        Public Function s_carga_mdb_2(ByVal lngAccion As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngAccion
            strQuery = _
                "Select " _
                            & "count(id_acc_cap) as num_participantes " _
                            & "From participante " _
                            & "Where id_acc_cap = [0]"

            s_carga_mdb_2 = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_carga_mdb_3(ByVal lngAccion As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngAccion
            strQuery = _
               "Select " _
                        & "id_acc_cap,nombre_dire, " _
                        & "ciudad,id_comuna, " _
                        & "n_dire " _
                        & "From direccion " _
                        & "Where id_acc_cap = [0]"
            Return ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_carga_mdb_4(ByVal lngAccion As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngAccion
            strQuery = _
              "Select " _
                            & "id_acc_cap,dia_clase, " _
                            & "hora_desde,hora_hasta " _
                            & "From horario " _
                            & "Where id_acc_cap = [0]"
            Return ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        Public Function existe_curso_empresa(ByVal lngRut As Long, _
                                     ByVal lngCodCursoEmpresa As Long, _
                                     ByVal intagno As Integer, _
                                     Optional ByVal blnExcluyeEliminados As Boolean = False) As Boolean
            Dim strQuery As String, arrParam(2)
            Dim strWhere As String = ""
            arrParam(0) = lngRut
            arrParam(1) = StringSql(CStr(lngCodCursoEmpresa))
            arrParam(2) = intagno

            If blnExcluyeEliminados Then
                strWhere = strWhere & " and cod_estado_curso <> 8 " _
                                    & " and cod_estado_curso <> 10 "
            End If


            strQuery = "Select isnull(count(*),0) as num_cursos " _
                        & "from curso_contratado " _
                        & "where rut_cliente = [0] " _
                        & "And correlativo_empresa = [1] " _
                        & "And year(fecha_inicio) = [2] " _
                        & strWhere

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                existe_curso_empresa = True
            Else
                existe_curso_empresa = False
            End If
        End Function
        Public Function s_existe_comuna(ByVal lngCodComuna As Long) As Boolean
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodComuna

            strQuery = _
                "Select count(isnull(cod_comuna,0)) " _
                & "From Comuna " _
                & "Where cod_comuna = [0] "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_comuna_por_nombre(ByVal strNomComuna As String) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strNomComuna)

            strQuery = _
                "Select cod_comuna, nombre " _
                & "From Comuna " _
                & "Where nombre = [0] "

            Return ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_existe_pais(ByVal lngCodPais As Long) As Boolean
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodPais

            strQuery = _
                "Select count(isnull(cod_pais,0)) " _
                & "From pais " _
                & "Where cod_pais = [0] "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_pais_por_nombre(ByVal strNomPais As String) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strNomPais)

            strQuery = _
                "Select cod_pais, nombre_pais " _
                & "From pais " _
                & "Where nombre_pais = [0] "

            Return ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_existe_cuenta(ByVal mintCodCuenta As Integer) As Boolean
            Dim strQuery As String, arrParam(0)
            arrParam(0) = mintCodCuenta

            strQuery = _
            "Select cod_cuenta " _
           & " From(Cuenta)" _
           & " Where cod_cuenta in (1,2,3,4,5,6,7,10,11)"

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_CursosSence(ByVal strCodigoSence As String) As Boolean

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigoSence)

            'consulta
            strQuery = _
                "Select count(Codigo_sence) " _
                & "From curso " _
                & "Where curso.codigo_sence = [0] "
            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_existe_CursosSence = True
            Else
                s_existe_CursosSence = False
            End If
        End Function
        Public Function s_existe_horario_curso(ByVal lngCodCurso As Long, ByVal intDia As Integer, ByVal strHoraInicio As String) As Boolean

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodCurso
            arrParam(1) = intDia
            arrParam(2) = StringSql(strHoraInicio)

            'consulta
            strQuery = _
                "Select count(*) " _
                & "from horario_curso " _
                & "where  cod_curso = [0] and dia = [1] and hora_inicio = [2]  "
            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_existe_horario_curso = True
            Else
                s_existe_horario_curso = False
            End If
        End Function
        Public Function s_existe_otec(ByVal lngRutOtec As Long) As Boolean

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutOtec

            'consulta
            strQuery = _
                "Select count(rut) " _
                & "From otec " _
                & "Where rut = [0] "
            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_existe_otec = True
            Else
                s_existe_otec = False
            End If
        End Function
        Public Function s_existe_correlativo_emp(ByVal lngCorrelatoviEmp As String) As Boolean

            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(lngCorrelatoviEmp)

            'consulta
            strQuery = _
                "Select count(correlativo_empresa) " _
                & "From curso_contratado " _
                & "Where correlativo_empresa = [0] "
            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_existe_correlativo_emp = True
            Else
                s_existe_correlativo_emp = False
            End If
        End Function
        Public Function s_valor_curso_sence(ByVal strCodCursoSence As String) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodCursoSence)
            strQuery = _
                "select isnull(valor_curso,0) " _
                & "from curso " _
                & "where codigo_sence = [0]  "

            s_valor_curso_sence = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_num_max_part_sence(ByVal strCodCursoSence As String) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodCursoSence)
            strQuery = _
                "select isnull(num_max_part,0) " _
                & "from curso " _
                & "where codigo_sence = [0]  "

            s_num_max_part_sence = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_carga_mdb_5(ByVal lngAccion As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngAccion
            strQuery = _
              "Select " _
              & "id_acc_cap,rut_num_pers_jur, " _
              & "rut_num_pers_nat,porc_franq, " _
              & "id_niv_ocu , " _
              & "id_region,observaciones, " _
              & "viatico, traslado, " _
              & "id_escolaridad,id_comuna " _
              & " From participante " _
              & " Where id_acc_cap = [0]"
            Return ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_carga_mdb_6(ByVal RutPersNat As Long) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = RutPersNat
            strQuery = _
              "Select " _
              & "rut_num_pers_nat,rut_dgv_pers_nat, " _
              & "nombre_pers_nat,ape_1_pers_nat, " _
              & "ape_2_pers_nat, fec_nac_pers_nat, rut_num_pers_jur, sexo, " _
              & "id_escolaridad " _
              & "From pers_nat where rut_num_pers_nat = [0]"
            Return ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_existe_persona_natural(ByVal lngRut As Long, _
                                         ByVal lngRutEmp As Long) As Boolean
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRut
            arrParam(1) = lngRutEmp
            strQuery = _
                "select count(rut) from persona_natural " _
                & "where rut = [0] and rut_empresa = [1] "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_existe_persona_natural = True
            Else
                s_existe_persona_natural = False
            End If
        End Function
        Public Function s_datos_persona_natural(ByVal lngRut As Long) As DataTable


            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut
            strQuery = _
                "Select ap_paterno,ap_materno,nombre,fecha_nacim,sexo,cod_nivel_educ " _
                & ",cod_comuna,cod_nivel_ocup,porc_franquicia,cod_region " _
                & "From persona_natural " _
                & "where rut = [0] "

            s_datos_persona_natural = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_porc_admin(ByVal RutCliente As Long) As Double
            Dim strQuery As String, arrParam(0)
            arrParam(0) = RutCliente
            strQuery = _
                "select round(costo_admin * 100,1) porc_admin from empresa_cliente where rut = [0]"
            s_porc_admin = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_hora_sence(ByVal CodSence As String) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(CodSence)
            strQuery = _
                "select dur_cur_teorico from curso where codigo_sence = [0]"
            s_hora_sence = ValorSql(SqlParam(strQuery, arrParam))
        End Function


        Public Function s_carga_hoja_excel(ByVal strHojaExcel As String, ByVal lngCorrelativo As Long) As DataTable
            Dim strQuery As String, arrparam(1)
            arrparam(0) = strHojaExcel
            arrparam(1) = lngCorrelativo
            strQuery = _
                "Select *  From [0] where Correlativo_empresa = [1] "
            s_carga_hoja_excel = ConsultaSql(SqlParam(strQuery, arrparam))
        End Function

        's_carga_hoja_excel para la carga de cursos del sistema banca antiguo
        Public Function s_carga_hoja_excel(ByVal strHojaExcel As String) As DataTable
            Dim strQuery As String, arrparam(0)
            arrparam(0) = strHojaExcel
            strQuery = _
                "Select *  From [0] "
            s_carga_hoja_excel = ConsultaSql(SqlParam(strQuery, arrparam))
        End Function
        Public Function s_carga_hoja_excel_union(ByVal strHojaExcel1 As String, ByVal strHojaExcel2 As String, _
                                                 ByVal strHojaExcel3 As String, ByVal lngCorrelativo As Long) As DataTable
            Dim strQuery As String, arrparam(3)
            arrparam(0) = strHojaExcel1
            arrparam(1) = strHojaExcel2
            arrparam(2) = strHojaExcel3
            arrparam(3) = lngCorrelativo
            strQuery = _
                "Select *  From [0] where Correlativo_empresa = [3] " _
                & "union Select *  From [1] where Correlativo_empresa = [3] " _
                & "union Select *  From [2] where Correlativo_empresa = [3] "
            s_carga_hoja_excel_union = ConsultaSql(SqlParam(strQuery, arrparam))
        End Function
        Public Function s_carga_hoja_excel_cabecera(ByVal strHojaExcel As String) As DataTable
            Dim strQuery As String, arrparam(0)
            arrparam(0) = strHojaExcel
            strQuery = _
                "Select *  From [0] "
            s_carga_hoja_excel_cabecera = ConsultaSql(SqlParam(strQuery, arrparam))
        End Function
        Public Function s_carga_hoja_excel_cabecera2(ByVal strHojaExcel As String, ByVal strCorrelativoEmpresa As String, _
                                                     ByVal strRutEmpresa As String) As DataTable
            Dim strQuery As String, arrparam(2)
            arrparam(0) = strHojaExcel
            If IsNumeric(strCorrelativoEmpresa) Then
                arrparam(1) = strCorrelativoEmpresa
            Else
                arrparam(1) = StringSql(strCorrelativoEmpresa)
            End If
            arrparam(2) = StringSql(strRutEmpresa)
            strQuery = _
                "Select *  From [0] where Correlativo_Empresa = [1] and rut_empresa = [2]"
            s_carga_hoja_excel_cabecera2 = ConsultaSql(SqlParam(strQuery, arrparam))
        End Function
        Public Function s_carga_hoja_excel_cabecera3(ByVal strHojaExcel As String, ByVal strCorrelativoEmpresa As String, _
                                                     ByVal strRutEmpresa As String) As DataTable
            Dim strQuery As String, arrparam(2)
            arrparam(0) = strHojaExcel
            If IsNumeric(strCorrelativoEmpresa) Then
                arrparam(1) = strCorrelativoEmpresa
            Else
                arrparam(1) = StringSql(strCorrelativoEmpresa)
            End If
            arrparam(2) = StringSql(strRutEmpresa)
            strQuery = _
                "Select *  From [0] where Correlativo_Empresa = [1] and rut_empresa = [2] "
            s_carga_hoja_excel_cabecera3 = ConsultaSql(SqlParam(strQuery, arrparam))
        End Function
        Public Function Existe_correlativo_empresa_interno(ByVal lngRutEmpresa As Long, _
                                                          ByVal intAgno As Integer, _
                                                          ByVal strCorrelativoEmpresa As String _
                                                          ) As Boolean
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRutEmpresa
            arrParam(1) = intAgno
            arrParam(2) = StringSql(strCorrelativoEmpresa)

            strQuery = _
                "Select count(*) " _
                & "From curso_interno " _
                & "Where rut = [0] and ano = [1] and correlativo_empresa = [2] "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function Existe_correlativo_empresa(ByVal lngRutEmpresa As Long, _
                                                          ByVal strCorrelativoEmpresa As String _
                                                          ) As Boolean
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutEmpresa
            arrParam(1) = StringSql(strCorrelativoEmpresa)

            strQuery = _
                "Select count(*) " _
                & "From curso_contratado " _
                & "Where rut_cliente = [0] and correlativo_empresa = [1] "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_porcentaje_administracion(ByVal lngRutCliente As Long) As Double
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutCliente

            strQuery = _
                "select costo_admin " _
                & "from empresa_cliente where  rut = [0]"

            Return ValorSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_curso_sence(ByVal strCodigoSence) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strCodigoSence)
            strQuery = _
                "Select Curso.nombre, isnull(rut_otec,0) rut_otec, area, especialidad, " _
                & "dur_cur_teorico, dur_cur_prac, num_max_part, nombre_sede, " _
                & "fono_sede, direccion, Curso.cod_comuna, pendiente, " _
                & "Comuna.nombre " _
                & "From Curso, Comuna " _
                & "Where codigo_sence = [0] and curso.cod_comuna=comuna.cod_comuna "
            s_curso_sence = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        'Private Function s_correlativo_curso_interno_max_ano(ByVal intAgno) As Long
        '    Dim strQuery As String


        '    'strQuery = "Select * from cursointerno"
        '    strQuery = "Select isnull(max(correlativo),0) from curso_interno where ano = " & intAgno

        '    s_correlativo_curso_interno_max_ano = ValorSql(strQuery)

        'End Function
        Public Function s_correlativo(ByVal lngAgno As Long) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngAgno

            strQuery = "select isnull(max(correlativo),0) + 1 from curso_contratado where agno = [0]"

            s_correlativo = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_correlativo2(ByVal lngAgno As Long, ByVal lngCodCurso As Long) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngAgno
            arrParam(1) = lngCodCurso

            strQuery = "select correlativo from curso_contratado where agno = [0] and cod_curso = [1]"

            s_correlativo2 = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        ''Consulta segun los valores ingresados en los campos de texto agno y valor hora
        'Public Function s_valor_horas_sence(ByVal intAgno As Integer, ByVal lngValorHora As Long) As DataTable

        '    Dim strQuery As String, arrParam(1)
        '    arrParam(0) = intAgno
        '    arrParam(1) = lngValorHora

        '    strQuery = _
        '        "Select agno, valor,vigente " _
        '        & " From valor_hora_sence " _
        '        & "Where (agno = [0] Or [0] = 0) " _
        '        & "And (valor = [1] Or [1] = 0) "

        '    s_valor_horas_sence = ConsultaSql(SqlParam(strQuery, arrParam))
        'End Function

        Public Function s_nombre_cliente(ByVal lngRutCliente As Long) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutCliente

            strQuery = _
                "select isnull(razon_social,'') razon_social " _
                & "from persona_juridica where  rut = [0]"

            s_nombre_cliente = ValorSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_nombre_cuenta(ByVal intCodCuenta As Integer) As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodCuenta
            strQuery = _
                "Select nombre " _
                & "From Cuenta " _
                & "Where cod_cuenta = [0] "
            s_nombre_cuenta = CStr(ValorSql(SqlParam(strQuery, arrParam)))
        End Function
        Public Function s_cuentas_traspaso() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_cuenta, nombre " _
                & "From Cuenta " _
                & "Where cod_cuenta in (1,2,3,4,5,6,7,10,11)"
            s_cuentas_traspaso = ConsultaSql(strQuery)
        End Function
        ' Consulta de todos los registros de perfil que correspondan a supervisores codigo 4
        Public Function s_supervisores_todos() As Object
            Dim strQuery As String
            strQuery = _
                "Select usuario.rut, usuario.nombres " _
                & "From usuario,perfil_usuario " _
                & " where usuario.rut=perfil_usuario.rut and " _
                & " perfil_usuario.cod_perfil= 4 " _
                & " order by usuario.nombres "
            s_supervisores_todos = ConsultaSql(strQuery)
        End Function
        Public Function s_estructura_tabla(ByVal strNombreTabla As String) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strNombreTabla)

            strQuery = _
                "SELECT COLUMN_NAME, IS_NULLABLE, DATA_TYPE FROM information_schema.columns WHERE table_name = [0]"

            s_estructura_tabla = ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_Otec2(ByVal lngRut As Long, _
                        ByVal strNomFantasia As String, _
                        ByVal strRazonSocial As String) As DataTable


            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = SubStringSql(strNomFantasia)
            arrParam(2) = SubStringSql(strRazonSocial)

            strQuery = _
                  "Select cast(Otec.rut as varchar) + '-' + cast(persona.dig_verif as varchar) " _
                  & "as RutOtec,persona.dig_verif as DigitoOtec," _
                  & "persona_juridica.nom_fantasia,persona_juridica.razon_social," _
                  & "isnull(otec.nombre_contacto,'') nombre_contacto ,isnull(otec.cargo_contacto,'') cargo_contacto ,isnull(otec.fono_contacto,'') fono_contacto ," _
                  & "isnull(otec.email_contacto,'') email_contacto ,isnull(otec.fax_contacto,'') fax_contacto, isnull(otec.cod_rubro,'') cod_rubro," _
                  & "isnull(rubro.nombre,'') NombreRubro,isnull(otec.nom_rep1,'') nom_rep1, isnull(otec.rut_rep1,0) rut_rep1, " _
                  & "isnull(otec.dig_verif_rep1,'') dig_verif_rep1, isnull(otec.nom_rep2,'') nom_rep2 ,isnull(otec.rut_rep2,0) rut_rep2 ,isnull(otec.dig_verif_rep2, 0) dig_verif_rep2, " _
                  & "isnull(otec.gerente_general,'') gerente_general, isnull(otec.gerente_rrhh,'') gerente_rrhh ,isnull(otec.area_cobranzas,'') area_cobranzas, " _
                  & "isnull(otec.giro,'') giro, isnull(otec.cod_act_economica,'') cod_act_economica ,isnull(otec.num_convenio,0) num_convenio, isnull(otec.tasa_descuento,0.0) tasa_descuento " _
                  & " From persona_juridica, persona,rubro, otec " _
                  & "Where (persona_juridica.Rut = [0] or [0] = 0) And " _
                  & "(persona_juridica.nom_fantasia like [1] Or [1] = '') and (persona_juridica.razon_social like [2] Or [2] = '') and " _
                  & " persona_juridica.rut = persona.rut and " _
                  & " persona_juridica.rut=otec.rut and otec.cod_rubro = rubro.cod_rubro "
            Return ConsultaSql(SqlParam(strQuery, arrParam))

        End Function
        Public Function s_Otec3(ByVal lngRut As Long, ByVal strRazonSocial As String) As DataTable


            Dim strQuery As String, arrParam(1)
            Dim strWhere As String = ""
            arrParam(0) = lngRut
            arrParam(1) = SubStringSql(strRazonSocial)
            If lngRut <> gValorNumNulo Then
                arrParam(0) = lngRut
                strWhere = "and o.rut = [0] "
            End If
            If strRazonSocial <> "" Then
                arrParam(1) = SubStringSql(strRazonSocial)
                strWhere = "and pj.razon_social like [1]"
            End If
            strQuery = _
                    "select o.rut,pj.razon_social,o.nombre_contacto,pj.fono from otec o, persona_juridica pj " _
                    & " where o.rut = pj.rut " _
                    & strWhere
            Return ConsultaSql(SqlParam(strQuery, arrParam))

        End Function

        Public Function s_nro_clientes( _
                ByVal intCodSucursal As Integer, _
                ByVal lngRutEjecutivo As Long, _
                ByVal lngRutUsuario As Long _
            ) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = intCodSucursal
            arrParam(1) = lngRutEjecutivo
            arrParam(2) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [0] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [1] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If

            strQuery = _
                "Select count(*) " _
                & "From Empresa_Cliente ec " & strFrom _
                & "Where ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [2]) " _
                & strWhere
            s_nro_clientes = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        'clientes con aportes
        Public Function s_clientes_con_aporte( _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                ByVal lngRutUsuario As Long _
            ) As Long
            Dim strQuery As String, arrParam(5)
            arrParam(0) = intCodSucursal
            arrParam(1) = lngRutEjecutivo
            arrParam(2) = FechaVbABd(dtmInicio)
            arrParam(3) = FechaVbABd(dtmFin)
            arrParam(4) = Year(dtmInicio)
            arrParam(5) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [0] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [1] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If

            strQuery = _
                " Select count(distinct ap.rut_cliente) " _
                & " From Aporte ap, Empresa_Cliente ec " _
                & strFrom _
                & " Where ap.rut_cliente = ec.rut " _
                & " And agno = [4] " _
                & " And cod_estado <> 3 " _
                & " And fecha Between [2] And [3] " _
                & " And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [5]) " _
                & strWhere
            s_clientes_con_aporte = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'retorna el n�mero de clientes con saldo negativo (deuda) en alguna de sus cuentas
        Public Function s_cuenta_cliente_deuda( _
                ByVal intCodSucursal As Integer, _
                ByVal lngRutEjecutivo As Long, _
                ByVal lngRutUsuario As Long) As Long

            Dim strQuery As String, arrParam(2)
            arrParam(0) = intCodSucursal
            arrParam(1) = lngRutEjecutivo
            arrParam(2) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [0] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [1] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If

            strQuery = _
                "Select Count(Distinct cc.rut_cliente) " _
                & "From Cuenta_Cliente cc, Empresa_Cliente ec " _
                & strFrom _
                & "Where cc.saldo < 0 " _
                & "And cc.rut_cliente = ec.rut " _
                & " And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [2]) " _
                & strWhere
            s_cuenta_cliente_deuda = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'nro de clientes con cursos iniciados en un per�odo
        Public Function s_clientes_cursos_ini( _
                ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                ByVal dtmInicio As Date, ByVal dtmFin As Date, _
                ByVal lngRutUsuatio As Long _
            ) As Long
            Dim strQuery As String, arrParam(4)
            arrParam(0) = intCodSucursal
            arrParam(1) = lngRutEjecutivo
            arrParam(2) = FechaVbABd(dtmInicio)
            arrParam(3) = FechaVbABd(dtmFin)
            arrParam(4) = lngRutUsuatio

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [0] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [1] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If

            strQuery = _
                " Select count(distinct rut_cliente)" _
                & " From Curso_Contratado cc, Empresa_Cliente ec " _
                & strFrom _
                & " Where cc.fecha_inicio Between [2] And [3] " _
                & " And ec.rut = cc.rut_cliente " _
                & " And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [4]) " _
                & strWhere
            s_clientes_cursos_ini = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        'nro de clientes con cursos iniciados en un per�odo
        Public Function s_aporte_total(ByVal RutCliente As Long, ByVal Agno As Integer, ByVal strListaRuts As String) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = RutCliente
            arrParam(1) = Agno
            arrParam(2) = strListaRuts

            Dim strWhere As String
            If strListaRuts = "" Then
                strWhere = "rut_cliente = [0]"
            Else
                strWhere = "rut_cliente In ([2])"
            End If

            strQuery = _
                "select isnull(sum(monto), 0) from transaccion " _
                & "where " & strWhere _
                & " and cod_tipo_tran = 1 and year(fecha_hora) = [1] "
            s_aporte_total = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        Public Function s_suma_vyt_agno_anterior_consolidado(ByVal RutCliente As Long, ByVal Agno As Integer, ByVal strListaRuts As String) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = RutCliente
            arrParam(1) = Agno
            arrParam(2) = strListaRuts

            Dim strWhere As String
            If strListaRuts = "" Then
                strWhere = "rut_cliente = [0]"
            Else
                strWhere = "rut_cliente In ([2])"
            End If

            strQuery = _
                "select isnull(sum(monto),0) monto from transaccion  " _
                & "where " & strWhere _
                & " and cod_tipo_tran = 5 and cod_cuenta = 1 and year(fecha_hora) = [1] "
            s_suma_vyt_agno_anterior_consolidado = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_suma_reparto_recibido(ByVal RutCliente As Long, ByVal Agno As Integer, ByVal strListaRuts As String) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = RutCliente
            arrParam(1) = Agno
            arrParam(2) = strListaRuts

            Dim strWhere As String
            If strListaRuts = "" Then
                strWhere = "cc.rut_cliente = [0]"
            Else
                strWhere = "cc.rut_cliente In ([2])"
            End If

            strQuery = _
                "select isnull(sum(tr.monto),0) monto from transaccion tr, solicitud_pago_terceros spt, curso_contratado cc " _
                & "where " & strWhere _
                & " and tr.cod_cuenta = 2 and spt.cod_curso = tr.cod_curso and tr.cod_curso = cc.cod_curso  and year(fecha_hora) = [1] "

            s_suma_reparto_recibido = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_suma_excedente_reparto_recibido(ByVal RutCliente As Long, ByVal Agno As Integer, ByVal strListaRuts As String) As Long
            Dim strQuery As String, arrParam(2)
            arrParam(0) = RutCliente
            arrParam(1) = Agno
            arrParam(2) = strListaRuts

            Dim strWhere As String
            If strListaRuts = "" Then
                strWhere = "cc.rut_cliente = [0]"
            Else
                strWhere = "cc.rut_cliente In ([2])"
            End If

            strQuery = _
                "select isnull(sum(tr.monto),0) monto from transaccion tr, solicitud_pago_terceros spt, curso_contratado cc " _
                & "where " & strWhere _
                & " and tr.cod_cuenta = 5 and spt.cod_curso = tr.cod_curso and tr.cod_curso = cc.cod_curso  " _
                & " and tr.nro_transaccion = spt.nro_transaccion and year(fecha_hora) = [1] "

            s_suma_excedente_reparto_recibido = ValorSql(SqlParam(strQuery, arrParam))
        End Function

        'n�mero de clientes con saldo positivo en una cuenta
        Public Function s_cuenta_cliente_saldo_positivo( _
                ByVal intCodCuenta As Integer, _
                ByVal intCodSucursal As Integer, _
                ByVal lngRutEjecutivo As Long, _
                ByVal lngRutUsuario As Long) As Long

            Dim strQuery As String, arrParam(3)
            arrParam(0) = intCodSucursal
            arrParam(1) = lngRutEjecutivo
            arrParam(2) = intCodCuenta
            arrParam(3) = lngRutUsuario

            Dim strFrom As String, strWhere As String
            strFrom = ""
            strWhere = ""
            If intCodSucursal <> 0 Then
                strWhere = " And ec.cod_sucursal = [0] "
            End If
            If lngRutEjecutivo <> 0 Then
                strFrom = ",Ejecutivo ej "
                strWhere = " And ej.rut_ejecutivo = [1] " _
                         & " And ej.rut_empresa = ec.rut " & strWhere
            End If

            strQuery = _
                "Select Count(*) " _
                & "From Cuenta_Cliente cc, Empresa_Cliente ec " _
                & strFrom _
                & "Where cc.cod_cuenta = [2] " _
                & "And cc.saldo > 0 " _
                & "And cc.rut_cliente = ec.rut " _
                & "And ec.rut In " _
                    & "(Select rut_empresa From V_Cliente_Permiso " _
                    & " Where rut_usuario = [3]) " _
                & strWhere
            s_cuenta_cliente_saldo_positivo = ValorSql(SqlParam(strQuery, arrParam))
        End Function
        Function s_reporte_aporte(ByVal strEstados As String, _
                                   ByVal strRutsEmp As String, _
                                   ByVal lngNumAporte As Long, _
                                   ByVal lngRutEmp As Long, _
                                   ByVal intCodCuenta As Integer, _
                                   ByVal strNombreEmp As String, _
                                   ByVal strCondNum As String, _
                                   ByVal strCondRutEmp As String, _
                                   ByVal dtmFechaIni As Date, _
                                   ByVal dtmFechaFin As Date) As DataTable
            Dim strSql As String, arrParam(9)
            arrParam(0) = lngNumAporte
            arrParam(1) = strRutsEmp
            arrParam(2) = intCodCuenta
            arrParam(3) = SubStringSql(strNombreEmp)
            arrParam(4) = strCondNum
            arrParam(5) = strCondRutEmp
            arrParam(6) = FechaVbABd(dtmFechaIni)
            arrParam(7) = FechaVbABd(dtmFechaFin)
            arrParam(8) = FechaBDaUSR("ap.fecha")
            arrParam(9) = lngRutEmp

            Dim strWhere As String
            strWhere = ""
            If strEstados <> "" Then
                strWhere = " And ap.cod_estado In (" & strEstados & ") "
            End If
            If Trim(strRutsEmp) <> "0" Then
                strWhere = strWhere & " And ap.rut_cliente In ([1]) "
            End If
            ' If lngNumAporte <> -1 Then strWhere = " And ap.num_aporte [4] [0] " & strWhere
            If lngNumAporte <> 0 Then strWhere = " And ap.num_aporte = [0] " & strWhere
            'If lngRutEmp <> -1 Then strWhere = " And ap.rut_cliente [5] [1] " & strWhere
            'If lngRutEmp <> -1 Then strWhere = " And ap.rut_cliente = [9] " & strWhere
            If intCodCuenta <> 0 Then strWhere = " And ap.cod_cuenta = [2] " & strWhere
            'If strNombreEmp <> "-1" Then strWhere = " And pj.razon_social like [3] " & strWhere
            strWhere = strWhere & " and ap.Fecha >= [6] and ap.Fecha <= [7] "

            strSql = _
            " Select ap.cod_aporte, ap.correlativo, ap.cod_estado, ea.Nombre, " _
            & "ap.rut_cliente,per.dig_verif, pj.Razon_Social, ap.monto_neto, ap.monto_adm, (ap.monto_neto+ ap.monto_adm) as monto_total, " _
            & "ap.cod_cuenta, ct.nombre, " _
            & "ap.cod_tipo_doc , td.Nombre, " _
            & "ap.nro_documento, ap.banco, ap.fecha_venc_doc, " _
            & "[8] fecha_ingreso, ap.fecha_cobro, ap.num_aporte, ap.observaciones,ct.nombre as nombre_cuenta " _
            & "From Aporte ap, Estado_Aporte ea, Persona_Juridica pj, " _
            & "Tipo_Documento td, Cuenta ct, persona per " _
            & "Where(ap.cod_estado = ea.cod_estado) " _
            & "and ea.cod_estado not in (3) " _
            & "And ap.rut_cliente = pj.rut " _
            & "And ap.cod_tipo_doc = td.cod_tipo_doc " _
            & "And ap.cod_cuenta = ct.cod_cuenta " _
            & "And pj.rut = per.rut " _
            & strWhere _
            & "Order By ap.num_aporte "
            Return ConsultaSql(SqlParam(strSql, arrParam))
        End Function
        Function s_reporte_aporte2(ByVal lngCorrelativo As Long) As DataTable
            Dim strSql As String, arrParam(0)
            arrParam(0) = lngCorrelativo

            Dim strWhere As String
            strWhere = ""

            strSql = _
            " Select ap.cod_aporte, ap.correlativo, ap.cod_estado, ea.Nombre, " _
            & "ap.rut_cliente, pj.Razon_Social, ap.monto_neto, ap.monto_adm, (ap.monto_neto+ ap.monto_adm) as monto_total, " _
            & "ap.cod_cuenta, ct.nombre, " _
            & "ap.cod_tipo_doc , td.Nombre, " _
            & "ap.nro_documento, ap.banco, ap.fecha_venc_doc, " _
            & "ap.fecha_cobro, ap.num_aporte, ap.observaciones, per.dig_verif,ct.nombre as nombre_cuenta " _
            & "From Aporte ap, Estado_Aporte ea, Persona_Juridica pj, " _
            & "Tipo_Documento td, Cuenta ct, persona per, curso_contratado cc " _
            & "Where(ap.cod_estado = ea.cod_estado) " _
            & "and ea.cod_estado not in (3) " _
            & "And ap.rut_cliente = pj.rut " _
            & "And ap.cod_tipo_doc = td.cod_tipo_doc " _
            & "And ap.cod_cuenta = ct.cod_cuenta " _
            & "And pj.rut = per.rut " _
            & "and ap.correlativo=cc.correlativo " _
            & "and ap.correlativo= [0] " _
            & "Order By ap.fecha, ap.num_aporte "
            Return ConsultaSql(SqlParam(strSql, arrParam))

        End Function
        Function s_listado_aporte(ByVal lngRutCliente As Long, _
                                    ByVal intAgno As Integer, _
                                   ByVal intCodCuenta As Integer, ByVal mstrBusqueda As String) As DataTable
            Dim strSql As String, arrParam(9)
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno
            arrParam(3) = mstrBusqueda

            Dim strWhere As String
            strWhere = ""

            If lngRutCliente <> "0" Then
                strWhere = strWhere & " And ap.rut_cliente = [0] "
            End If
            If mstrBusqueda <> "" Then strWhere = mstrBusqueda

            If intCodCuenta = 4 Then
                arrParam(2) = "1,2"
            Else
                arrParam(2) = intCodCuenta
            End If

            strSql = _
            " Select ap.cod_aporte, ap.correlativo, ap.cod_estado, isnull(ea.Nombre,'') as estado_aporte, ap.rut_cliente, " _
            & "per.dig_verif, pj.Razon_Social, ap.monto_neto, ap.monto_adm, (ec.costo_admin * 100) as costo_admin," _
            & "ap.cod_cuenta, isnull(ct.nombre,'') as nombre_cuenta, ap.cod_tipo_doc, isnull(td.Nombre,'') as nom_tipo_docu, ap.nro_documento, " _
            & "isnull(ap.banco,'') as banco, isnull(ap.fecha_venc_doc,'19000101') as fecha_venc_doc , isnull(ap.fecha,'19000101') as fecha_ingreso,  " _
            & "isnull(ap.fecha_cobro,'19000101') as fecha_cobro,ap.num_aporte, ap.observaciones, us.nombres ejecutivo, " _
            & "per2.rut as rut_ejecutivo, per2.dig_verif as dig_verif_ejecutivo " _
            & "From Aporte ap, Estado_Aporte ea, Persona_Juridica pj, Tipo_Documento td, Cuenta ct, persona per, ejecutivo ej, " _
            & "empresa_cliente ec, usuario us, persona per2 " _
            & "Where(ap.cod_estado = ea.cod_estado) And ap.rut_cliente = pj.rut And ap.cod_tipo_doc = td.cod_tipo_doc And " _
            & "ap.cod_cuenta = ct.cod_cuenta And pj.rut = per.rut  and ej.rut_empresa = ap.rut_cliente " _
            & "and ec.rut=pj.rut and ej.rut_ejecutivo = us.rut And us.rut = per2.rut And  ap.cod_estado In ([2]) and year(ap.fecha)= [1] " _
            & strWhere
            Return ConsultaSql(SqlParam(strSql, arrParam))
        End Function
        Function s_listado_aporte2(ByVal mstrWhere As String) As DataTable
            Dim strSql As String, arrParam(0)
            arrParam(0) = mstrWhere

            Dim strWhere As String
            strWhere = "[0]"

            strSql = _
            " Select ap.cod_aporte, ap.correlativo, ap.cod_estado, isnull(ea.Nombre,'') as estado_aporte, ap.rut_cliente, pj.Razon_Social, " _
            & "ap.monto_neto, ap.monto_adm, ap.cod_cuenta, isnull(ct.nombre,'') as nombre_cuenta, ap.cod_tipo_doc, isnull(td.Nombre,'') as nom_tipo_docu, ap.nro_documento, " _
            & "isnull(ap.banco,'') as banco, isnull(ap.fecha_venc_doc,'19000101') as fecha_venc_doc , isnull(ap.fecha,'19000101') as fecha_ingreso, " _
            & "isnull(ap.fecha_cobro,'19000101') as fecha_cobro,ap.num_aporte, ap.observaciones, per.dig_verif " _
            & "From Aporte ap, Estado_Aporte ea, Persona_Juridica pj, Tipo_Documento td, Cuenta ct, persona per, ejecutivo ej " _
            & "Where(ap.cod_estado = ea.cod_estado) And ap.rut_cliente = pj.rut And ap.cod_tipo_doc = td.cod_tipo_doc And " _
            & "ap.cod_cuenta = ct.cod_cuenta And pj.rut = per.rut and ej.rut_empresa = ap.rut_cliente " _
            & strWhere
            Return ConsultaSql(SqlParam(strSql, arrParam))
        End Function
        Function s_listado_aporte_Sence(ByVal lngRutCliente As Long, _
                                    ByVal intAgno As Integer, _
                                   ByVal intCodCuenta As Integer) As DataTable
            Dim strSql As String, arrParam(9)
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno
            arrParam(2) = intCodCuenta


            Dim strWhere As String
            strWhere = ""

            If lngRutCliente <> "0" Then
                strWhere = strWhere & " And ap.rut_cliente = [0] "
            End If


            strSql = _
            " Select ap.num_aporte, ap.rut_cliente, ap.cod_cuenta, ap.monto_neto, ap.monto_adm, " _
            & "isnull(ap.fecha,'19000101') as fecha " _
            & "From Aporte ap, Estado_Aporte ea, Persona_Juridica pj, Tipo_Documento td, Cuenta ct, persona per " _
            & "Where(ap.cod_estado = ea.cod_estado) And ap.rut_cliente = pj.rut And ap.cod_tipo_doc = td.cod_tipo_doc And " _
            & "ap.cod_cuenta = ct.cod_cuenta And pj.rut = per.rut  And  ap.cod_estado In ([2]) and year(ap.fecha)= [1] " _
            & strWhere _
            & "order by ap.fecha "

            Return ConsultaSql(SqlParam(strSql, arrParam))
        End Function


        Public Function s_reporte_vyt(ByVal strListaRuts As String, _
                                              ByVal dtmFechaInicio As Date, _
                                              ByVal dtmFechaFin As Date) As DataTable

            Dim strQuery As String, arrParam(2)
            arrParam(0) = strListaRuts
            arrParam(1) = FechaVbABd(dtmFechaInicio)
            arrParam(2) = FechaVbABd(dtmFechaFin)

            strQuery = _
                "Select cc.fecha_inicio, cc.total_viatico, cc.total_traslado, cc.costo_otic_vyt + gasto_empresa_vyt total_vyt, cc.costo_otic_vyt, gasto_empresa_vyt, " _
                & "c.nombre, cc.correlativo, cc.cod_curso " _
                & "From Curso_Contratado cc, Curso c " _
                & "Where cc.rut_cliente in ([0]) " _
                & "And (cc.total_viatico > 0 Or cc.total_traslado > 0) " _
                & "And c.codigo_sence = cc.codigo_sence " _
                & "And cc.fecha_inicio >= [1] " _
                & "And cc.fecha_inicio <= [2] " _
                & "Order By cc.fecha_inicio"

            s_reporte_vyt = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_estados_aporte() As DataTable
            Dim strQuery As String
            strQuery = _
                "select cod_estado, nombre from estado_aporte where cod_estado in (1,2)"
            s_estados_aporte = ConsultaSql(strQuery)
        End Function

        Public Function s_cuentas_traspaso2() As DataTable
            Dim strQuery As String
            strQuery = _
                "Select cod_cuenta, nombre " _
                & "From Cuenta " _
                & "Where cod_cuenta in (1,2)"
            s_cuentas_traspaso2 = ConsultaSql(strQuery)
        End Function
        Public Function s_esta_aporte_anulado(ByVal lngCodAporte As Long) As Boolean
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodAporte
            strQuery = _
                "Select count(*) " _
                & "From Aporte " _
                & " Where cod_aporte = [0] " _
                & " And cod_estado = 3 "

            Dim dt As DataTable
            dt = ConsultaSql(SqlParam(strQuery, arrParam))
            If Registros > 0 Then
                If dt.Rows(0).Item(0) > 0 Then
                    s_esta_aporte_anulado = True
                Else
                    s_esta_aporte_anulado = False
                End If
            End If
        End Function
        Public Function s_reporte_cobranza(ByVal lngRutCliente As Long, _
                                   ByVal strNombreCliente As String, _
                                   ByVal dtmFechaIni As Date, _
                                   ByVal dtmFechaFin As Date)
            Dim strQuery As String, arrParam(4)
            Dim strWhere As String
            Dim intAgnoAnterior As Integer

            strWhere = ""

            intAgnoAnterior = Year(dtmFechaIni) '- 1

            If lngRutCliente > 0 Then
                strWhere = strWhere & " And t.Rut_cliente=[0] "
            End If
            If strNombreCliente <> "" Then
                strWhere = strWhere & " And (pj.razon_social)  LIKE [1] "
            End If

            arrParam(0) = lngRutCliente
            arrParam(1) = SubStringSql(strNombreCliente)
            arrParam(2) = FechaVbABd(dtmFechaIni)
            arrParam(3) = FechaVbABd(DateAdd("d", 1, dtmFechaFin))  'd�a siguiente
            arrParam(4) = intAgnoAnterior
            'cast(t.rut_cliente as varchar) + '-' cast(pe.dig_verif as varchar) rut_cliente,
            strQuery = _
            "Select cast(t.rut_cliente as varchar) + '-' + cast(pe.dig_verif as varchar) rut_cliente, t.cod_cuenta, t.cod_tipo_tran, " _
            & "Sum(t.monto), pj.razon_social, isnull(ec.nom_contacto,'') nom_contacto , " _
            & "isnull(ec.fono_contacto,'sin fono') fono_contacto , isnull(ec.anexo_contacto,'sin anexo') anexo_contacto, u.Nombres, S.Nombre, isnull(f.valor,0) as Franquicia, " _
            & "(select isnull(sum(monto),0) from transaccion " _
            & "where fecha_hora >= [2] And fecha_hora < [3] " _
            & "And (month(fecha_hora) <> 12 Or day(fecha_hora) <> 31 Or DATEPART(hh, fecha_hora) <> 23 or DATEPART(mi, fecha_hora) <> 59 Or datepart(ss, fecha_hora) <> 59 or cod_tipo_tran <> 3) " _
            & "And t.cod_cuenta=cod_cuenta " _
            & "And cod_curso in "
            strQuery = strQuery _
            & "( " _
            & "select cod_curso from curso_contratado " _
            & "Where cod_estado_curso in (1,3,4,5,6,7,9,11) " _
            & "and cod_curso_parcial>0 " _
            & "And t.rut_cliente = rut_cliente " _
            & ") " _
            & ") as gasto_curso_complementario, "
            strQuery = strQuery _
            & "(select isnull(sum(monto),0) from transaccion " _
            & "where fecha_hora >= [2] And fecha_hora < [3] " _
            & "And (month(fecha_hora) <> 12 Or day(fecha_hora) <> 31 Or DATEPART(hh, fecha_hora) <> 23 or DATEPART(mi, fecha_hora) <> 59 Or datepart(ss, fecha_hora) <> 59 or cod_tipo_tran <> 3) " _
            & "And t.cod_cuenta=cod_cuenta " _
            & "And cod_curso in "
            strQuery = strQuery _
            & "( " _
            & "select cod_curso from curso_contratado " _
            & "Where cod_estado_curso in (1,3,4,5,6,7,9,11) " _
            & "and cod_curso_compl>0 " _
            & "And t.rut_cliente = rut_cliente " _
            & ") " _
            & ") as gasto_curso_parcial, (ec.costo_admin *100) costo_admin " _
            & "From transaccion t, persona_juridica pj, empresa_cliente ec, " _
            & "sucursal s, ejecutivo e, usuario u, franquicia f, persona pe " _
            & "Where t.rut_cliente=pj.rut And t.rut_cliente=ec.rut " _
            & "And f.rut =* ec.rut " _
            & "And f.agno = [4] " _
            & "And s.cod_sucursal=ec.cod_sucursal And " _
            & "t.rut_cliente = e.rut_empresa And e.rut_ejecutivo = u.Rut And " _
            & "t.fecha_hora >= [2] And t.fecha_hora < [3] " _
            & "And (month(t.fecha_hora) <> 12 Or day(t.fecha_hora) <> 31 Or DATEPART(hh, fecha_hora) <> 23 or DATEPART(mi, fecha_hora) <> 59 Or datepart(ss, t.fecha_hora) <> 59 or t.cod_tipo_tran <> 3) " _
            & "and pe.rut = pj.rut " _
            & strWhere _
            & "Group by t.rut_cliente, t.cod_cuenta, t.cod_tipo_tran, " _
            & "pj.razon_social, ec.nom_contacto, ec.fono_contacto, " _
            & "ec.anexo_contacto , u.Nombres, S.Nombre, f.valor, pe.dig_verif, ec.costo_admin " _
            & "Order By t.rut_cliente "

            s_reporte_cobranza = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        Public Function s_correl_interno_excel() As DataTable

            Dim strQuery As String

            strQuery = _
                    "Select distinct correlativo_empresa from [Hoja1$]"

            s_correl_interno_excel = ConsultaSql(strQuery)
        End Function
        Public Function s_max_correl_curso_interno(ByVal lngRutCliente As Long) As Long
            Dim strQuery As String

            strQuery = _
                        "select max(cast(correlativo_empresa as int)) correlativo_empresa from curso_interno " _
                        & "where rut = " & lngRutCliente

            s_max_correl_curso_interno = ValorSql(strQuery)
        End Function
        Public Function s_participante_correl_interno_excel(ByVal Correl As Long) As DataTable

            Dim strQuery As String, arrParam(0)
            arrParam(0) = Correl
            strQuery = _
                    "Select * from [Hoja1$] where correlativo_empresa=[0] "

            s_participante_correl_interno_excel = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function s_existe_curso_agno(ByVal lngCodCurso As Long, ByVal intagno As Integer) As Boolean
            Dim strQuery As String, arrParam(2)
            Dim strWhere As String = ""
            arrParam(0) = lngCodCurso
            arrParam(1) = intagno

            strQuery = "Select isnull(count(*),0) as num_cursos " _
                        & "from curso_contratado " _
                        & "where cod_curso = [0] " _
                        & "And year(fecha_inicio) = [1] "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_existe_curso_agno = True
            Else
                s_existe_curso_agno = False
            End If
        End Function
        'Public Function s_gasto_empresa_por_cuenta(ByVal lngRutCliente As Long, ByVal intAgno As Integer)
        '    Dim strQuery As String, arrParam(4)
        '    arrParam(0) = lngRutCliente
        '    arrParam(1) = intAgno
        '    strQuery = _
        '    "select (select isnull(sum(gasto_empresa),0) from curso_contratado where agno=c.agno " _
        '    & "and rut_cliente=ec.rut and cod_estado_curso not in (8,10) " _
        '    & "and cod_curso in (select cod_curso from transaccion where rut_cliente=ec.rut " _
        '    & "and cod_tipo_tran=2 and cod_cuenta=1 and year(fecha_hora)=c.agno group by cod_curso having sum(monto)>0)) ge_cap, " _
        '    & "(select isnull(sum(gasto_empresa),0) from curso_contratado where agno=c.agno " _
        '    & "and rut_cliente=ec.rut and cod_estado_curso not in (8,10) " _
        '    & "and cod_curso in (select cod_curso from transaccion where rut_cliente=ec.rut " _
        '    & "and cod_tipo_tran=2 and cod_cuenta=4 and year(fecha_hora)=c.agno " _
        '    & "and cod_curso not in (select cod_curso from transaccion where rut_cliente=ec.rut " _
        '    & "and cod_tipo_tran=2 and cod_cuenta=1 and year(fecha_hora)=c.agno group by cod_curso having sum(monto)>0))) ge_exc, " _
        '    & "(select isnull(sum(gasto_empresa),0) from curso_contratado where agno=c.agno " _
        '    & "and rut_cliente=ec.rut and cod_estado_curso not in (8,10) " _
        '    & "and cod_curso in (select cod_curso from transaccion where rut_cliente=ec.rut " _
        '    & "and cod_tipo_tran=2 and cod_cuenta=2 and year(fecha_hora)=c.agno group by cod_curso having sum(monto)>0)) ge_terc " _
        '    & "from empresa_cliente ec, curso_contratado c " _
        '    & "where ec.rut=c.rut_cliente " _
        '    & "and rut = [0] and c.agno = [1] " _
        '    & "group by ec.rut, c.rut_cliente, c.agno "

        '    s_gasto_empresa_por_cuenta = ConsultaSql(SqlParam(strQuery, arrParam))
        'End Function
        Public Function s_gasto_empresa_por_cuenta(ByVal strRutCliente As String, ByVal intAgno As Integer)
            Dim strQuery As String, arrParam(4)
            arrParam(0) = strRutCliente
            arrParam(1) = intAgno
            strQuery = _
                "select (gasto_empresa*CAST((CAST(isnull(cap.monto, 0) AS FLOAT) * 100) AS FLOAT) / " _
                & "case CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) when 0.0 then 1.0 else CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) end)/100 CAP," _
                & "(gasto_empresa*CAST((CAST(isnull(EXcap.monto, 0) AS FLOAT) * 100) AS FLOAT) / " _
                & "case CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) when 0.0 then 1.0 else CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) end)/100 EXCAP, " _
                & "(select isnull(sum(gasto_empresa),0) from curso_contratado cc where agno=cc.agno and rut_cliente=ec.rut " _
                & "and cod_estado_curso not in (8,10) and cod_curso in (select cod_curso from transaccion where rut_cliente=ec.rut " _
                & "and cod_tipo_tran=2 and cod_cuenta=2 and year(fecha_hora)=cc.agno group by cod_curso having sum(monto)>0) ) TERC " _
                & "from (select cod_curso, case when sum(monto) = 0 then 0 else sum(monto) end monto, rut_cliente from transaccion " _
                & "where cod_tipo_tran=2 and cod_cuenta=1 and year(fecha_hora)= [1] group by cod_curso, rut_cliente) cap, " _
                & "(select cod_curso, case when sum(monto) = 0 then 0 else sum(monto) end monto, rut_cliente from transaccion where cod_tipo_tran=2 " _
                & "and cod_cuenta=4 and year(fecha_hora)= [1] group by cod_curso, rut_cliente) excap, " _
                & "curso_contratado cc, empresa_cliente ec " _
                & "where cc.cod_curso*=cap.cod_curso and cc.cod_curso*=excap.cod_curso and cod_estado_curso not in (8,10) " _
                & "and cc.rut_cliente = ec.rut and ec.rut IN ([0]) and cc.agno = [1]  order by cc.cod_curso "

            s_gasto_empresa_por_cuenta = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        'Public Function s_gasto_empresa_por_cuenta(ByVal lngRutCliente As Long, ByVal intAgno As Integer)
        '    Dim strQuery As String, arrParam(4)
        '    arrParam(0) = lngRutCliente
        '    arrParam(1) = intAgno
        '    strQuery = _
        '        "select (gasto_empresa*CAST((CAST(isnull(cap.monto, 0) AS FLOAT) * 100) AS FLOAT) / " _
        '        & "case CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) when 0.0 then 1.0 else CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) end)/100 CAP," _
        '        & "(gasto_empresa*CAST((CAST(isnull(EXcap.monto, 0) AS FLOAT) * 100) AS FLOAT) / " _
        '        & "case CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) when 0.0 then 1.0 else CAST((isnull(cap.monto, 0) + isnull(excap.monto, 0)) AS FLOAT) end)/100 EXCAP, " _
        '        & "(select isnull(sum(gasto_empresa),0) from curso_contratado cc where agno=cc.agno and rut_cliente=ec.rut " _
        '        & "and cod_estado_curso not in (8,10) and cod_curso in (select cod_curso from transaccion where rut_cliente=ec.rut " _
        '        & "and cod_tipo_tran=2 and cod_cuenta=2 and year(fecha_hora)=cc.agno group by cod_curso having sum(monto)>0) ) TERC " _
        '        & "from (select cod_curso, case when sum(monto) = 0 then 0 else sum(monto) end monto, rut_cliente from transaccion " _
        '        & "where cod_tipo_tran=2 and cod_cuenta=1 and year(fecha_hora)= [1] group by cod_curso, rut_cliente) cap, " _
        '        & "(select cod_curso, case when sum(monto) = 0 then 0 else sum(monto) end monto, rut_cliente from transaccion where cod_tipo_tran=2 " _
        '        & "and cod_cuenta=4 and year(fecha_hora)= [1] group by cod_curso, rut_cliente) excap, " _
        '        & "curso_contratado cc, empresa_cliente ec " _
        '        & "where cc.cod_curso*=cap.cod_curso and cc.cod_curso*=excap.cod_curso and cod_estado_curso not in (8,10) " _
        '        & "and cc.rut_cliente = ec.rut and ec.rut = [0] and cc.agno = [1]  order by cc.cod_curso "

        '    s_gasto_empresa_por_cuenta = ConsultaSql(SqlParam(strQuery, arrParam))
        'End Function

        Public Function s_acciones_liquidadas(ByVal Agno As Integer) As DataTable
            Dim strQuery As String, arrParam(1)
            arrParam(0) = Agno

            strQuery = _
               "select '73048900' rut_otic, '' digv_otic, cc.rut_cliente rut_empresa, '' digv_empresa, cc.nro_registro 'numero accion', " _
                & "case isnull(cc.flag_curso_cft, 0) when 1 then 'CFT' when 0 then  " _
                & "case when (cod_curso_compl is null and cod_curso_parcial is null) then 'NORMAL'  " _
                & "when (cod_curso_compl is not null) then 'PARCIAL' when (cod_curso_parcial is not null)  " _
                & "then 'COMPLEMENTARIO' END END 'tipo_accion', " _
                & "case isnull(cc.flag_curso_cft, 0) when 1 then 'CFT' when 0 then case cc.cod_tipo_activ when 1 then 'CONTRATADA' " _
                & "when 2 then 'PRECONTRATO' when 3 then 'POSTCONTRATO' end end 'tipo_actividad', " _
                & "(select count(rut_alumno) from participante where porc_asistencia >= 0.75 and cod_curso = cc.cod_curso) 'Participantes Aprobados', " _
                & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 1 ),0) as cuenta_capacitacion,  " _
                & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 2 ),0) as cuenta_reparto,  " _
                & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 4 ),0) as cuenta_exc_capacitacion,  " _
                & "isnull((Select Sum(convert(numeric, monto)) From Transaccion Where cod_curso = cc.cod_curso And cod_cuenta = 5 ),0) as cuenta_exc_reparto, " _
                & "0 'cargo eccl', 0 'cargo ex-eccl', " _
                & "isnull((select sum(viatico) from participante where cod_curso = cc.cod_curso), 0) 'monto viatico',  " _
                & "isnull((select sum(traslado) from participante where cod_curso = cc.cod_curso), 0) 'monto traslado', " _
                & "case ind_acu_com_bip when 1 then 'SI' else 'NO' end 'comite bipartito', ec.nombre 'estado' " _
                & "from curso_contratado cc, estado_curso ec " _
                & "where cc.cod_estado_curso = ec.cod_estado_curso " _
                & "and agno = [0] and ec.cod_estado_curso = 5 "
            s_acciones_liquidadas = ConsultaSql(SqlParam(strQuery, arrParam))
        End Function

        Public Function s_alumno_con_tope_fechas(ByVal RutAlumno As Long, ByVal FechaInicio As Date, _
                                                ByVal FechaFin As Date, ByVal CodCurso As Long) As Boolean
            Dim strQuery As String, arrParam(3)
            Dim strWhere As String = ""
            arrParam(0) = RutAlumno
            arrParam(1) = FechaVbABd(FechaInicio)
            arrParam(2) = FechaVbABd(FechaFin)
            arrParam(3) = CodCurso

            strQuery = "select count(cod_curso) resultados from curso_contratado " _
                    & "where cod_curso in (select cod_curso from participante " _
                    & "where rut_alumno = [0] and cod_curso not in([3])) " _
                    & "and (([1] between fecha_inicio and fecha_termino) " _
                    & "or ([1] between fecha_inicio and fecha_termino)) "

            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_alumno_con_tope_fechas = True
            Else
                s_alumno_con_tope_fechas = False
            End If
        End Function

        Public Function s_alumno_con_curso_repetido(ByVal RutAlumno As Long, ByVal Agno As Integer, _
                                                ByVal CodSence As Long, ByVal CodCurso As Long) As Integer
            Dim strQuery As String, arrParam(3)
            Dim strWhere As String = ""
            arrParam(0) = RutAlumno
            arrParam(1) = Agno
            arrParam(2) = StringSql(CodSence)
            arrParam(3) = CodCurso

            strQuery = "select count(cod_curso) from curso_contratado " _
                    & "where agno=[1] and codigo_sence=[2] " _
                    & "and cod_curso in (select cod_curso from participante where rut_alumno = [0] and cod_curso not in([3])) " _
                    & "and cod_estado_curso not in (2,8,10)"

            's_alumno_con_curso_repetido = ValorSql(SqlParam(strQuery, arrParam))
            If ValorSql(SqlParam(strQuery, arrParam)) > 0 Then
                s_alumno_con_curso_repetido = True
            Else
                s_alumno_con_curso_repetido = False
            End If
        End Function

#End Region

#Region "INSERT"
        'Inserta un participante de un curso interno en la BD

        Public Sub i_participante_interno(ByVal lngCorrelativo As Long, ByVal intAgno As Integer, ByVal lngRutAlumno As Long, _
                                            ByVal lngViatico As Long, ByVal lngTraslado As Long, _
                                            ByVal intCodEstadoAprobado As Integer)

            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno
            arrParam(2) = lngRutAlumno
            arrParam(3) = lngViatico
            arrParam(4) = lngTraslado
            arrParam(5) = intCodEstadoAprobado

            strQuery = _
                    "Insert Into Participante_interno (correlativo, ano, rut, viatico, traslado, cod_estado_part) " _
                    & "Values ([0], [1], [2], [3], [4], [5]) "

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        Public Sub i_sucursal(ByVal intCodigo As Integer, ByVal strNombre As String)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodigo
            arrParam(1) = StringSql(strNombre)
            strQuery = _
                "Insert Into Sucursal (cod_sucursal, nombre) " _
                & "Values([0], [1])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_clasificador(ByVal strCodigoClasificador As String, ByVal strNombre As String, _
                          ByVal lngRutEmpresa As Long)
            Dim strQuery As String, arrParam(2)
            arrParam(0) = StringSql(strCodigoClasificador)
            arrParam(1) = StringSql(strNombre)
            arrParam(2) = lngRutEmpresa
            strQuery = _
                "Insert Into Clasificador (cod_clasificador, nombre, rut ) " _
                & "Values([0], [1],[2])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'inserta Supervisor
        Public Sub i_director_suc(ByVal RutDirector As Long, ByVal CodSucursal As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = RutDirector
            arrParam(1) = CodSucursal
            strQuery = _
                "insert into Director_Sucursal(rut,cod_sucursal) " _
                & "values([0] ,[1]) "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserta Valor hora sence
        Public Sub i_valor_hora_sence(ByVal intAgno As Integer, _
                                      ByVal lngValor As Long, _
                                      ByVal blnVigente As Boolean)
            Dim strQuery As String, arrParam(2)
            arrParam(0) = intAgno
            arrParam(1) = lngValor
            arrParam(2) = BooleanAspAbd(blnVigente)

            strQuery = _
                "Insert Into Valor_hora_sence (agno,valor,vigente) " _
                & "Values([0], [1], [2])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserta Valor hora sence
        Public Sub i_valor_hora_sence2(ByVal intAgno As Integer, _
                                      ByVal lngValor As Long, _
                                      ByVal blnVigente As Boolean, _
                                      ByVal intCodModalidad As Integer, _
                                      ByVal strCodigoSence As String)
            Dim strQuery As String, arrParam(4)
            arrParam(0) = intAgno
            arrParam(1) = lngValor
            arrParam(2) = BooleanAspAbd(blnVigente)
            arrParam(3) = intCodModalidad
            arrParam(4) = StringSql(strCodigoSence)

            strQuery = _
                "Insert Into Valor_hora_sence (agno,valor,vigente,cod_modalidad,codigo_sence) " _
                & "Values([0], [1], [2],[3],[4])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Function i_curso_interno(ByVal lngRutCliente As Long, _
                                ByVal intCodEstado As Integer, _
                                ByVal lngParticipantes As Long, _
                                ByVal strDireccionCurso As String, _
                                ByVal lngCodComuna As Long, _
                                ByVal dtmFechaInicio As String, _
                                ByVal dtmFechaTermino As String, _
                                ByVal lngValorCurso As Long, _
                                ByVal lngDescuento As Long, _
                                ByVal strCorrEmpresa As String, _
                                ByVal intIndDescPorc As Integer, _
                                ByVal strObservacion As String, _
                                ByVal intAgno As Integer, _
                                ByVal strNombreCurso As String, _
                                ByVal strEjecutor As String, _
                                ByVal strHorario As String, _
                                ByVal intHoras As Integer, _
                                ByVal lngTotalViatico As Long, _
                                ByVal lngTotalTraslado As Long) As Long


            Dim strQuery As String, arrParam(19)
            Dim lngCorrelativo As Long

            arrParam(0) = lngRutCliente
            arrParam(1) = lngParticipantes
            arrParam(2) = StringSql(strDireccionCurso)
            arrParam(3) = lngCodComuna
            arrParam(4) = FechaVbABd(dtmFechaInicio)
            arrParam(5) = FechaVbABd(dtmFechaTermino)
            arrParam(6) = lngValorCurso
            arrParam(7) = lngDescuento
            arrParam(8) = StringSql(strCorrEmpresa)
            arrParam(9) = intIndDescPorc
            arrParam(10) = StringSql(strObservacion)
            arrParam(11) = intAgno
            arrParam(12) = StringSql(strNombreCurso)
            arrParam(13) = StringSql(strEjecutor)
            arrParam(14) = StringSql(strHorario)
            arrParam(15) = s_correlativo_curso_interno_max_ano(intAgno) + 1
            arrParam(16) = intCodEstado
            arrParam(17) = intHoras
            arrParam(18) = lngTotalViatico
            arrParam(19) = lngTotalTraslado

            'strQuery = "Insert into Curso_Interno(correlativo,rut, cod_estado_curso_interno, num_participantes, direccion, " _
            '         & "cod_comuna, inicio_curso, fin_curso, valor_curso, descuento, " _
            '         & "correlativo_empresa, tipo_descuento_porcentaje, observacion, " _
            '         & "ano, nombre_curso, ejecutor, horario,cod_estado,horas_curso) " _
            '         & "values([15],[0],[16],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13], [14],1,[17])"
            strQuery = "Insert into Curso_Interno(correlativo,rut, cod_estado_curso_interno, num_participantes, direccion, " _
                     & "cod_comuna, inicio_curso, fin_curso, valor_curso, descuento, " _
                     & "correlativo_empresa, tipo_descuento_porcentaje, observacion, " _
                     & "ano, nombre_curso, ejecutor, horario,horas, total_viatico, total_traslado) " _
                     & "values([15],[0],[16],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13], [14],[17],[18],[19])"

            Call EjecutarSql(SqlParam(strQuery, arrParam))
            i_curso_interno = arrParam(15)

        End Function
        'Inserta un certificado
        Public Sub i_certificado_aporte(ByVal intAgno As Integer, ByVal lngRut As Long, _
                                        ByVal lngCorrelativo As Long)
            Dim strQuery As String, arrParam(2)
            arrParam(0) = intAgno
            arrParam(1) = lngRut
            arrParam(2) = lngCorrelativo
            strQuery = _
                "Insert Into Certificado_Aporte(agno, rut_cliente, correlativo) " _
                & "Values([0], [1], [2]) "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserci�n de datos en tabla OBJETO
        Public Sub i_objeto(ByVal strNombre As String)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = Serial("cod_objeto", "Objeto") + 1
            arrParam(1) = StringSql(strNombre)
            strQuery = _
                "Insert Into Objeto (cod_objeto, nombre) " _
                & "Values([0], [1])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserta una Solicitud de Pago a un Tercero
        Public Sub i_sol_pago_terc(ByVal lngRutBenefactor As Long, ByVal lngCodCurso As Long, _
                                   ByVal lngMonto As Long, ByVal lngNroTrans As Long, ByVal lngMontoAdm As Long)

            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngRutBenefactor
            arrParam(1) = lngCodCurso
            arrParam(2) = FechaVbABd(Now.Date)
            arrParam(3) = lngMonto
            If lngNroTrans > 0 Then
                arrParam(4) = lngNroTrans
            Else
                arrParam(4) = "Null"
            End If
            arrParam(5) = lngMontoAdm
            strQuery = _
                    "Insert Into Solicitud_Pago_Terceros " _
                    & "(rut_benefactor, cod_curso, fecha_ingreso, monto, nro_transaccion, cod_estado_solicitud, monto_adm) " _
                    & "Values ([0], [1], [2], [3], [4], 1, [5]) "

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        'Insertar registro en la tabla becas
        Public Sub i_beca(ByVal lngRutCliente As Long, ByVal intAgno As Integer, _
                          ByVal lngBecas As Long, ByVal lngAdmAsign As Long)
            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno
            arrParam(2) = lngBecas
            arrParam(3) = lngAdmAsign

            strQuery = _
                "Insert Into Asignacion_Exced(rut, agno, becas, adm_asignacion) " _
                & "Values([0], [1], [2], [3])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserta las Cuentas de un cliente
        Public Function i_CuentaCliente(ByVal lngRut As Long, _
                                        ByVal CodigoCuenta As Integer)


            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = CodigoCuenta
            arrParam(2) = 0

            strQuery = _
                "Insert Into Cuenta_Cliente(rut_cliente, cod_cuenta,saldo) " _
                & " Values([0], [1], [2])"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        'Inserci�n de datos en tabla ejecutivo
        Public Sub i_ejecutivo(ByVal lngRutCliente As Long, ByVal lngRutEjecutivo As Long)

            Dim strQuery As String, arrParam(1)

            arrParam(0) = lngRutCliente
            arrParam(1) = lngRutEjecutivo

            strQuery = _
                "Insert Into ejecutivo (rut_empresa, rut_ejecutivo)  " _
                & "Values([0], [1])"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_Empresa_Cliente(ByVal lngRut As Long, _
                             ByVal dblCostoAdm As Double, _
                             ByVal intCompAdmNoLineal As Integer, _
                             ByVal intCodRubro As Integer, _
                             ByVal lngNumempleados As Long, _
                             ByVal strContacto As String, _
                             ByVal strCargo As String, _
                             ByVal strFonoContacto As String, _
                             ByVal strAnexoContacto As String, _
                             ByVal strEmailContacto As String, _
                             ByVal strRep1 As String, _
                             ByVal lngRutRep1 As Long, _
                             ByVal strDigitoRep1 As String, ByVal strRep2 As String, _
                             ByVal lngRutRep2 As Long, ByVal strDigitoRep2 As String, _
                             ByVal strGerenteGral As String, ByVal strGerenteRRHH As String, _
                             ByVal strAreaCobranzas As String, ByVal strGiro As String, _
                             ByVal strCodActEconomica As String, ByVal intCodEstadoCliente As Integer, _
                             ByVal intCodSucursal As Integer, ByVal lngVentaAnual As Long, _
                             ByVal strEmailGteRRHH As String, _
                             ByVal strGerenteFinanzas As String, ByVal strEmailGteFinanzas As String, _
                             ByVal strFonoCobranzas As String, ByVal lngRutHolding As Long, _
                             ByVal strClaveWebService As String, ByVal strEtiquetaClasificador As String, ByVal strObservacion As String, _
                             ByVal lngRutContacto As Long, ByVal strApellidoContacto As String)


            Dim strQuery As String, arrParam(33)
            arrParam(0) = CLng(lngRut)
            If dblCostoAdm >= 0 And dblCostoAdm <= 1 Then
                arrParam(1) = DoubleVbABd(dblCostoAdm)
            Else
                arrParam(1) = DoubleVbABd(dblCostoAdm / 100)
            End If
            arrParam(2) = intCompAdmNoLineal
            arrParam(3) = intCodRubro
            If lngNumempleados = -1 Then
                arrParam(4) = "Null"
            Else
                arrParam(4) = lngNumempleados
            End If


            If strContacto = "" Then
                arrParam(5) = "Null"
            Else
                arrParam(5) = StringSql(strContacto)
            End If
            If strCargo = "" Then
                arrParam(6) = "Null"
            Else
                arrParam(6) = StringSql(strCargo)
            End If
            If strFonoContacto = "" Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = StringSql(strFonoContacto)
            End If
            If strAnexoContacto = "" Then
                arrParam(8) = "Null"
            Else
                arrParam(8) = StringSql(strAnexoContacto)
            End If
            If strEmailContacto = "" Then
                arrParam(9) = "Null"
            Else
                arrParam(9) = StringSql(strEmailContacto)
            End If
            If strRep1 = "" Then
                arrParam(10) = "Null"
            Else
                arrParam(10) = StringSql(strRep1)
            End If
            If lngRutRep1 = -1 Then
                arrParam(11) = "Null"
            Else
                arrParam(11) = CLng(lngRutRep1)
            End If
            If strDigitoRep1 = "" Then
                arrParam(12) = "Null"
            Else
                arrParam(12) = StringSql(strDigitoRep1)
            End If
            If strRep2 = "" Then
                arrParam(13) = "Null"
            Else
                arrParam(13) = StringSql(strRep2)
            End If
            If lngRutRep2 = -1 Then
                arrParam(14) = "Null"
            Else
                arrParam(14) = CLng(lngRutRep2)
            End If
            If strDigitoRep2 = "" Then
                arrParam(15) = "Null"
            Else
                arrParam(15) = StringSql(strDigitoRep2)
            End If
            If strGerenteGral = "" Then
                arrParam(16) = "Null"
            Else
                arrParam(16) = StringSql(strGerenteGral)
            End If
            If strGerenteRRHH = "" Then
                arrParam(17) = "Null"
            Else
                arrParam(17) = StringSql(strGerenteRRHH)
            End If
            If strAreaCobranzas = "" Then
                arrParam(18) = "Null"
            Else
                arrParam(18) = StringSql(strAreaCobranzas)
            End If
            If strGiro = "" Then
                arrParam(19) = "Null"
            Else
                arrParam(19) = StringSql(strGiro)
            End If
            If strCodActEconomica = "" Then
                arrParam(20) = "Null"
            Else
                arrParam(20) = StringSql(strCodActEconomica)
            End If

            arrParam(21) = intCodEstadoCliente
            arrParam(22) = intCodSucursal
            arrParam(23) = lngVentaAnual


            'Email Gerente Recursos Humanos
            If strEmailGteRRHH = "" Then
                arrParam(24) = "Null"
            Else
                arrParam(24) = StringSql(strEmailGteRRHH)
            End If

            'Nombre Gerente Finanzas
            If strGerenteFinanzas = "" Then
                arrParam(25) = "Null"
            Else
                arrParam(25) = StringSql(strGerenteFinanzas)
            End If

            'Email Gerente Finanzas
            If strEmailGteFinanzas = "" Then
                arrParam(26) = "Null"
            Else
                arrParam(26) = StringSql(strEmailGteFinanzas)
            End If

            'Fono Cobranzas
            If strFonoCobranzas = "" Then
                arrParam(27) = "Null"
            Else
                arrParam(27) = StringSql(strFonoCobranzas)
            End If

            If lngRutHolding = -1 Then
                arrParam(28) = "Null"
            Else
                arrParam(28) = lngRutHolding
            End If
            If strClaveWebService = "" Then
                arrParam(29) = "Null"
            Else
                arrParam(29) = StringSql(EncryptINI$(strClaveWebService))
            End If
            If strEtiquetaClasificador = "" Then
                arrParam(30) = "Null"
            Else
                arrParam(30) = StringSql(strEtiquetaClasificador)
            End If
            If strObservacion = "" Then
                arrParam(31) = "Null"
            Else
                arrParam(31) = StringSql(strObservacion)
            End If

            arrParam(32) = lngRutContacto
            arrParam(33) = StringSql(strApellidoContacto)

            strQuery = _
                "Insert Into Empresa_Cliente (rut, costo_admin,comp_adm_no_lineal,cod_rubro, " _
                & "num_empleados,nom_contacto, cargo_contacto, " _
                & "fono_contacto,anexo_contacto,email_contacto,nom_rep1,rut_rep1,dig_verif_rep1, " _
                & "nom_rep2,rut_rep2,dig_verif_rep2,gerente_general,gerente_rrhh,area_cobranzas, " _
                & "giro,cod_act_economica,cod_estado_cliente,cod_sucursal,ventas_anuales, " _
                & "email_gerente_RRHH,gerente_finanzas,email_gerente_finanzas, " _
                & "fono_cobranzas,rut_holding, rut_contacto, apellido_contacto) " _
                & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11]," _
                & "[12], [13],[14], [15],[16], [17],[18], [19],[20], [21],[22],[23],[24],[25],[26],[27],[28],[32],[33])"

            ''strQuery = _
            ''    "Insert Into Empresa_Cliente (rut, costo_admin,comp_adm_no_lineal,cod_rubro, " _
            ''    & "num_empleados,nom_contacto, cargo_contacto, " _
            ''    & "fono_contacto,anexo_contacto,email_contacto,nom_rep1,rut_rep1,dig_verif_rep1, " _
            ''    & "nom_rep2,rut_rep2,dig_verif_rep2,gerente_general,gerente_rrhh,area_cobranzas, " _
            ''    & "giro,cod_act_economica,cod_estado_cliente,cod_sucursal,ventas_anuales, " _
            ''    & "email_gerente_RRHH,gerente_finanzas,email_gerente_finanzas, " _
            ''    & "fono_cobranzas,rut_holding,clave_web_service,etiqueta_clasificador, observacion) " _
            ''    & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11]," _
            ''    & "[12], [13],[14], [15],[16], [17],[18], [19],[20], [21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31])"

            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserci�n datos de la base de datos cursos.mdb de access
        'en tabla Cursos de la base de datos de sql
        Public Sub i_cursos(ByVal strCodigoSence As String, _
                            ByVal strCurso As String, _
                            ByVal intRutOtec As Long, _
                            ByVal strArea As String, _
                            ByVal strEspecialidad As String, _
                            ByVal intDur_cur_teorico As Long, _
                            ByVal intDur_cur_practico As Long, _
                            ByVal intNum_max_part As Integer, _
                            ByVal strNombre_Sede As String, _
                            ByVal strFono_Sede As String, _
                            ByVal strDireccion As String, _
                            ByVal lngCodComuna As Long, _
                            ByVal blnPendiente As Boolean, _
                            ByVal lngValorCurso As Long, _
                            ByVal blnElearning As Boolean, _
                            ByVal lngCodModalidad As Integer, _
                            ByVal intDur_cur_elearning As Long, _
                            Optional ByVal dblValorHora As Double = 0.0)

            Dim strQuery As String, arrParam(17)
            arrParam(0) = StringSql(strCodigoSence)
            arrParam(1) = StringSql(strCurso)
            arrParam(2) = intRutOtec
            arrParam(3) = StringSql(strArea)
            arrParam(4) = StringSql(strEspecialidad)
            arrParam(5) = intDur_cur_teorico
            arrParam(6) = intDur_cur_practico
            arrParam(7) = intNum_max_part
            arrParam(8) = StringSql(strNombre_Sede)
            arrParam(9) = StringSql(strFono_Sede)
            arrParam(10) = StringSql(strDireccion)
            arrParam(11) = lngCodComuna
            arrParam(12) = BooleanAspAbd(blnPendiente)
            arrParam(13) = lngValorCurso
            arrParam(14) = BooleanVbAbd(blnElearning)
            arrParam(15) = DoubleVbABd(dblValorHora)
            arrParam(16) = lngCodModalidad
            arrParam(17) = intDur_cur_elearning

            Dim strInsValorHora As String = ""
            Dim strValueValorHora As String = ""
            If dblValorHora > 0.0 Then
                strInsValorHora = " , valor_hora "
                strValueValorHora = " , [15] "
            End If
            strQuery = _
                "Insert Into Curso(codigo_sence, nombre,rut_otec,area," _
                & "especialidad,dur_cur_teorico,dur_cur_prac,num_max_part," _
                & "nombre_sede,fono_sede,direccion,cod_comuna,pendiente,valor_curso, cod_modalidad, dur_cur_elearning" & strInsValorHora & ") " _
                & "Values([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[16],[17]" & strValueValorHora & ")"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'cambio al ingresar el valor hora sence
        Public Sub i_cursos2(ByVal strCodigoSence As String, _
                            ByVal strCurso As String, _
                            ByVal intRutOtec As Long, _
                            ByVal strArea As String, _
                            ByVal strEspecialidad As String, _
                            ByVal intDur_cur_teorico As Integer, _
                            ByVal intDur_cur_practico As Integer, _
                            ByVal intNum_max_part As Integer, _
                            ByVal strNombre_Sede As String, _
                            ByVal strFono_Sede As String, _
                            ByVal strDireccion As String, _
                            ByVal lngCodComuna As Long, _
                            ByVal blnPendiente As Boolean, _
                            ByVal lngValorCurso As Long, _
                            ByVal lngValorHoraSence As Long, _
                            ByVal blnElearning As Boolean)

            Dim strQuery As String, arrParam(15)
            arrParam(0) = StringSql(strCodigoSence)
            arrParam(1) = StringSql(strCurso)
            arrParam(2) = intRutOtec
            arrParam(3) = StringSql(strArea)
            arrParam(4) = StringSql(strEspecialidad)
            arrParam(5) = intDur_cur_teorico
            arrParam(6) = intDur_cur_practico
            arrParam(7) = intNum_max_part
            arrParam(8) = StringSql(strNombre_Sede)
            arrParam(9) = StringSql(strFono_Sede)
            arrParam(10) = StringSql(strDireccion)
            arrParam(11) = lngCodComuna
            arrParam(12) = BooleanAspAbd(blnPendiente)
            arrParam(13) = lngValorCurso
            arrParam(14) = BooleanVbAbd(blnElearning)
            arrParam(15) = lngValorHoraSence
            'strQuery = _
            '    "Insert Into Curso(codigo_sence, nombre,rut_otec,area," _
            '    & "especialidad,dur_cur_teorico,dur_cur_prac,num_max_part," _
            '    & "nombre_sede,fono_sede,direccion,cod_comuna,pendiente,valor_curso,elearning) " _
            '    & "Values([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14])"
            strQuery = _
                "Insert Into Curso(codigo_sence, nombre,rut_otec,area," _
                & "especialidad,dur_cur_teorico,dur_cur_prac,num_max_part," _
                & "nombre_sede,fono_sede,direccion,cod_comuna,pendiente,valor_curso,elearning,valor_hora_sence) " _
                & "Values([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserci�n de datos en tabla Factura
        Public Sub i_factura(ByVal lngCodCurso As Long, ByVal intCodEstadoFectura As Integer, _
                             ByVal lngNumFactura As Long, ByVal dtmFecha As Date, _
                             ByVal dtmFechaRecepcion As Date, ByVal dtmFechaPago As Date, _
                             ByVal lngMonto As Long, ByVal lngNumVoucher As Long, _
                             ByVal strObservacion As String)

            Dim strQuery As String, arrParam(8)
            arrParam(0) = lngCodCurso
            arrParam(1) = intCodEstadoFectura
            arrParam(2) = lngNumFactura
            arrParam(3) = FechaVbABd(dtmFecha)
            arrParam(4) = FechaVbABd(dtmFechaRecepcion)
            arrParam(5) = FechaVbABd(dtmFechaPago)
            arrParam(6) = lngMonto
            If lngNumVoucher = 0 Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = lngNumVoucher
            End If
            If strObservacion = "" Then
                arrParam(8) = "Null"
            Else
                arrParam(8) = StringSql(strObservacion)
            End If


            '& "fecha_recepcion, fecha_pago, monto, nro_documento, nota_credito, observacion,nro_egreso) " _

            strQuery = _
                "Insert Into factura (cod_curso, cod_estado_fact, num_factura, fecha, " _
                & "fecha_recepcion, fecha_pago, monto, num_voucher, observacion) " _
                & "Values([0], [1], [2], [3], [4], [5], [6],[7],[8])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_otec(ByVal lngRut As Long, ByVal strContacto As String, _
                  ByVal strCargo As String, ByVal strFonoContacto As String, _
                  ByVal strEmailContacto As String, ByVal strFaxContacto As String, _
                  ByVal intCodRubro As Integer, ByVal strRep1 As String, _
                  ByVal lngRutRep1 As Long, ByVal strDigitoRep1 As String, _
                  ByVal strRep2 As String, ByVal lngRutRep2 As Long, _
                  ByVal strDigitoRep2 As String, ByVal strGerenteGral As String, _
                  ByVal strGerenteRRHH As String, ByVal strAreaCobranzas As String, _
                  ByVal strGiro As String, ByVal strCodActEconomica As String, _
                  ByVal lngNumConvenio As Long, ByVal dblTasaDescuento As Double)


            Dim strQuery As String, arrParam(19)
            arrParam(0) = CLng(lngRut)

            If strContacto = "" Then
                arrParam(1) = "Null"
            Else
                arrParam(1) = StringSql(strContacto)
            End If
            If strCargo = "" Then
                arrParam(2) = "Null"
            Else
                arrParam(2) = StringSql(strCargo)
            End If
            If strFonoContacto = "" Then
                arrParam(3) = "Null"
            Else
                arrParam(3) = StringSql(strFonoContacto)
            End If
            If strEmailContacto = "" Then
                arrParam(4) = "Null"
            Else
                arrParam(4) = StringSql(strEmailContacto)
            End If
            If strFaxContacto = "" Then
                arrParam(5) = "Null"
            Else
                arrParam(5) = StringSql(strFaxContacto)
            End If

            arrParam(6) = intCodRubro

            If strRep1 = "" Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = StringSql(strRep1)
            End If
            If lngRutRep1 = -1 Then
                arrParam(8) = "Null"
            Else
                arrParam(8) = CLng(lngRutRep1)
            End If
            If strDigitoRep1 = "" Then
                arrParam(9) = "Null"
            Else
                arrParam(9) = StringSql(strDigitoRep1)
            End If
            If strRep2 = "" Then
                arrParam(10) = "Null"
            Else
                arrParam(10) = StringSql(strRep2)
            End If
            If lngRutRep2 = -1 Then
                arrParam(11) = "Null"
            Else
                arrParam(11) = CLng(lngRutRep2)
            End If
            If strDigitoRep2 = "" Then
                arrParam(12) = "Null"
            Else
                arrParam(12) = StringSql(strDigitoRep2)
            End If
            If strGerenteGral = "" Then
                arrParam(13) = "Null"
            Else
                arrParam(13) = StringSql(strGerenteGral)
            End If
            If strGerenteRRHH = "" Then
                arrParam(14) = "Null"
            Else
                arrParam(14) = StringSql(strGerenteRRHH)
            End If
            If strAreaCobranzas = "" Then
                arrParam(15) = "Null"
            Else
                arrParam(15) = StringSql(strAreaCobranzas)
            End If
            If strGiro = "" Then
                arrParam(16) = "Null"
            Else
                arrParam(16) = StringSql(strGiro)
            End If
            If strCodActEconomica = "" Then
                arrParam(17) = "Null"
            Else
                arrParam(17) = StringSql(strCodActEconomica)
            End If
            If lngNumConvenio = -1 Then
                arrParam(18) = "Null"
            Else
                arrParam(18) = lngNumConvenio
            End If
            arrParam(19) = dblTasaDescuento

            strQuery = _
                "Insert Into Otec (rut, nombre_contacto,cargo_contacto, " _
                & "fono_contacto,email_contacto,fax_contacto,cod_rubro, " _
                & "nom_rep1,rut_rep1,dig_verif_rep1, " _
                & "nom_rep2,rut_rep2,dig_verif_rep2, " _
                & "gerente_general,gerente_rrhh,area_cobranzas, " _
                & "giro,cod_act_economica,num_convenio,tasa_descuento) " _
                & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11]," _
                & "[12], [13],[14], [15],[16], [17],[18], [19])"

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        'Inserci�n datos de la base de datos otec.mdb de access
        'en tabla Persona_Juridica de la base de datos de sql
        Public Sub i_Persona_Juridica(ByVal intRutOtec As Long, _
                            ByVal strNomFantasia As String, _
                            ByVal strNombreOtec As String, _
                            ByVal strSigla As String, _
                            ByVal strEmail As String, _
                            ByVal strFono As String, _
                            ByVal strFono2 As String, _
                            ByVal strFax As String, _
                            ByVal strDireccion As String, _
                            ByVal lngCodComuna As Long, _
                            ByVal strCasilla As String, _
                            ByVal strCiudad As String, _
                            ByVal strSitioWeb As String, _
                            ByVal strNroDireccion As String)


            Dim strQuery As String, arrParam(13)
            arrParam(0) = intRutOtec
            arrParam(1) = StringSql(strNomFantasia)
            arrParam(2) = StringSql(strNombreOtec)
            arrParam(3) = StringSql(strSigla)
            arrParam(4) = StringSql(strEmail)
            arrParam(5) = StringSql(strFono)
            arrParam(6) = StringSql(strFono2)
            If strFax = "" Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = StringSql(strFax)
            End If
            arrParam(8) = StringSql(strDireccion)
            arrParam(9) = lngCodComuna
            If strCasilla = "" Then
                arrParam(10) = "Null"
            Else
                arrParam(10) = StringSql(strCasilla)
            End If
            arrParam(11) = StringSql(strCiudad)
            If strSitioWeb = "" Then
                arrParam(12) = "Null"
            Else
                arrParam(12) = StringSql(strSitioWeb)
            End If
            arrParam(13) = StringSql(strNroDireccion)

            strQuery = _
                "Insert Into Persona_Juridica(rut, nom_fantasia,razon_social," _
                & "sigla,email,fono,fono2,fax,direccion,cod_comuna,casilla, " _
                & "ciudad,SitioWeb,nro_direccion) " _
                & "Values([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13])"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserci�n datos de la base de datos otec.mdb de access
        'en tabla Persona de la base de datos de sql
        Public Sub i_Persona(ByVal intRut As Long, _
                             ByVal strDigito As String, _
                             ByVal strTipo As String)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = intRut
            arrParam(1) = StringSql(strDigito)
            arrParam(2) = StringSql(strTipo)

            strQuery = _
                "Insert Into Persona(rut, dig_verif, tipo) " _
                & "Values([0],[1],[2])"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserta un curso contratado en la BD.

        'Public Sub i_curso_contr(ByVal lngRutCliente As Long, ByVal intCodTipoActiv As Integer, _
        '                         ByVal bolIndAcuComBip As Boolean, ByVal bolIndDetNece As Boolean, _
        '                         ByVal lngParticipantes As Long, ByVal strDireccionCurso As String, _
        '                         ByVal lngCodComuna As Long, ByVal strCodSence As String, _
        '                         ByVal dtmFechaInicio As Date, ByVal dtmFechaTermino As Date, _
        '                         ByVal lngHorasCompl As Double, ByVal lngValorMercado As Long, _
        '                         ByVal lngDescuento As Long, ByVal lngCorrelativo As Long, _
        '                         ByVal lngNroRegistro As Long, ByVal intCodEstadoCurso As Integer, _
        '                         ByVal lngAgno As Long, ByVal dblPorcAdm As Double, _
        '                         ByVal lngCostoOtic As Long, ByVal lngCostoAdm As Long, _
        '                         ByVal lngGastoEmpresa As Long, ByVal lngCostoOticVYT As Long, _
        '                         ByVal lngCostoAdmVYT As Long, ByVal lngGastoEmpresaVYT As Long, _
        '                         ByVal lngTotalViatico As Long, _
        '                         ByVal lngTotalTraslado As Long, ByVal intCodAtributo As Integer, _
        '                         ByVal strObsCurso As String, ByVal mlngValorComunicado As Long, _
        '                         ByVal strObsLiquidacion As String, ByVal lngHoras As Double, _
        '                         ByVal intNroFacturaOtec As Integer, ByVal dtmFechaPagoFactura As Date, _
        '                         ByVal lngCodCursoCompl As Long, ByVal intIndDescPorc As Integer, _
        '                         ByVal strCorrEmpresa As String, ByVal lngCodCursoParcial As Long, _
        '                         ByVal strContactoAdicional As String, ByVal strObservacion As String, _
        '                         ByVal lngCodModalidad As Long, _
        '                         ByVal strNroDireccionCurso As String, ByVal strCiudad As String)


        '    Dim strQuery As String, arrParam(42)
        '    arrParam(0) = lngRutCliente
        '    arrParam(1) = intCodTipoActiv
        '    arrParam(2) = BooleanAspAbd(bolIndAcuComBip)
        '    arrParam(3) = BooleanAspAbd(bolIndDetNece)
        '    arrParam(4) = lngParticipantes
        '    arrParam(5) = StringSql(strDireccionCurso)
        '    arrParam(6) = lngCodComuna
        '    arrParam(7) = StringSql(strCodSence)
        '    arrParam(8) = FechaVbABd(dtmFechaInicio)
        '    arrParam(9) = FechaVbABd(dtmFechaTermino)
        '    arrParam(10) = lngHorasCompl
        '    arrParam(11) = lngValorMercado
        '    arrParam(12) = lngDescuento
        '    arrParam(13) = lngCorrelativo
        '    arrParam(14) = lngNroRegistro
        '    arrParam(15) = intCodEstadoCurso
        '    arrParam(16) = lngAgno
        '    If dblPorcAdm >= 0 And dblPorcAdm <= 1 Then
        '        arrParam(17) = DoubleVbABd(dblPorcAdm)
        '    Else
        '        arrParam(17) = DoubleVbABd(dblPorcAdm / 100)
        '    End If
        '    arrParam(18) = lngCostoOtic
        '    arrParam(19) = lngCostoAdm
        '    arrParam(20) = lngGastoEmpresa
        '    arrParam(21) = lngCostoOticVYT
        '    arrParam(22) = lngCostoAdmVYT
        '    arrParam(23) = lngGastoEmpresaVYT

        '    arrParam(24) = lngTotalViatico
        '    arrParam(25) = lngTotalTraslado
        '    arrParam(26) = intCodAtributo
        '    arrParam(27) = StringSql(strObsCurso)
        '    arrParam(28) = mlngValorComunicado
        '    arrParam(29) = StringSql(strObsLiquidacion)
        '    arrParam(30) = lngHoras
        '    arrParam(31) = intNroFacturaOtec
        '    If dtmFechaPagoFactura = FechaMinSistema() Then
        '        arrParam(32) = "Null"
        '    Else
        '        arrParam(32) = FechaVbABd(dtmFechaPagoFactura)
        '    End If
        '    arrParam(33) = lngCodCursoCompl
        '    arrParam(34) = intIndDescPorc
        '    arrParam(35) = StringSql(strCorrEmpresa)
        '    arrParam(36) = FechaVbABd(Now.Date)
        '    arrParam(37) = lngCodCursoParcial
        '    arrParam(38) = StringSql(strContactoAdicional)
        '    arrParam(39) = StringSql(strObservacion)
        '    arrParam(40) = lngCodModalidad
        '    arrParam(41) = StringSql(strNroDireccionCurso)
        '    arrParam(42) = StringSql(strCiudad)

        '    If (arrParam(13) = -1) Then
        '        arrParam(13) = "Null"
        '    End If
        '    If (arrParam(14) = -1) Then
        '        arrParam(14) = "Null"
        '    End If
        '    If (arrParam(31) = -1) Then
        '        arrParam(31) = "Null"
        '    End If
        '    If (arrParam(33) = -1) Then
        '        arrParam(33) = "Null"
        '    End If
        '    If (arrParam(35) = "") Then
        '        arrParam(35) = "Null"
        '    End If
        '    If (arrParam(37) = -1) Then
        '        arrParam(37) = "Null"
        '    End If
        '    If (arrParam(40) = 0) Then
        '        arrParam(40) = "Null"
        '    End If

        '    strQuery = _
        '            "Insert Into Curso_Contratado (rut_cliente, cod_tipo_activ, ind_acu_com_bip, " _
        '            & "ind_det_nece, num_alumnos, direccion_curso, cod_comuna, codigo_sence, fecha_inicio, " _
        '            & "fecha_termino, horas_compl, valor_mercado, descuento, " _
        '            & "correlativo, nro_registro, cod_estado_curso, " _
        '            & "agno, porc_adm, costo_otic, costo_adm, gasto_empresa, " _
        '            & "costo_otic_vyt, costo_adm_vyt, gasto_empresa_vyt, " _
        '            & "total_viatico, total_traslado, cod_origen, obs_curso, " _
        '            & "costo_otic_comunicar, obs_liquidacion, horas, nro_factura_otec, " _
        '            & "fecha_pago_factura, cod_curso_compl, ind_desc_porc, correlativo_empresa, " _
        '            & "fecha_ingreso, fecha_modificacion, cod_curso_parcial,contacto_adicional,observacion,cod_modalidad" _
        '            & ",nro_direccion_curso,ciudad) " _
        '            & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], " _
        '            & "[13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], " _
        '            & "[25], [26], [27], [28], [29], [30], [31], [32], [33], [34],[35],[36],[36], " _
        '            & "[37], [38], [39], [40],[41],[42])"

        '    Call EjecutarSql(SqlParam(strQuery, arrParam))

        'End Sub
        Public Sub i_curso_contr(ByVal lngRutCliente As Long, ByVal intCodTipoActiv As Integer, _
                                  ByVal intIndAcuComBip As Integer, ByVal intIndDetNece As Integer, _
                                  ByVal lngParticipantes As Long, ByVal strDireccionCurso As String, _
                                  ByVal lngCodComuna As Long, ByVal strCodSence As String, _
                                  ByVal dtmFechaInicio As Date, ByVal dtmFechaTermino As Date, _
                                  ByVal lngHorasCompl As Double, ByVal lngValorMercado As Long, _
                                  ByVal lngDescuento As Long, ByVal lngCorrelativo As Long, _
                                  ByVal lngNroRegistro As Long, ByVal intCodEstadoCurso As Integer, _
                                  ByVal lngAgno As Long, ByVal dblPorcAdm As Double, _
                                  ByVal lngCostoOtic As Long, ByVal lngCostoAdm As Long, _
                                  ByVal lngGastoEmpresa As Long, ByVal lngCostoOticVYT As Long, _
                                  ByVal lngCostoAdmVYT As Long, ByVal lngGastoEmpresaVYT As Long, _
                                  ByVal lngTotalViatico As Long, _
                                  ByVal lngTotalTraslado As Long, ByVal intCodAtributo As Integer, _
                                  ByVal strObsCurso As String, ByVal mlngValorComunicado As Long, _
                                  ByVal strObsLiquidacion As String, ByVal lngHoras As Double, _
                                  ByVal intNroFacturaOtec As Integer, ByVal dtmFechaPagoFactura As Date, _
                                  ByVal lngCodCursoCompl As Long, ByVal intIndDescPorc As Integer, _
                                  ByVal strCorrEmpresa As String, ByVal lngCodCursoParcial As Long, _
                                  ByVal strContactoAdicional As String, ByVal strObservacion As String, _
                                  ByVal lngCodModalidad As Long, _
                                  ByVal strNroDireccionCurso As String, ByVal strCiudad As String, Optional ByVal blnCursoCFT As Boolean = False, _
                                  Optional ByVal dblValorHora As Double = 0.0, Optional ByVal lngRutEncargado As Long = 0)


            Dim strQuery As String, arrParam(45)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodTipoActiv
            arrParam(2) = intIndAcuComBip
            arrParam(3) = intIndDetNece
            arrParam(4) = lngParticipantes
            arrParam(5) = StringSql(strDireccionCurso)
            arrParam(6) = lngCodComuna
            arrParam(7) = StringSql(strCodSence)
            arrParam(8) = FechaVbABd(dtmFechaInicio)
            arrParam(9) = FechaVbABd(dtmFechaTermino)
            arrParam(10) = DoubleVbABd(lngHorasCompl)
            arrParam(11) = lngValorMercado
            arrParam(12) = lngDescuento
            arrParam(13) = lngCorrelativo
            arrParam(14) = lngNroRegistro
            arrParam(15) = intCodEstadoCurso
            arrParam(16) = lngAgno
            If dblPorcAdm >= 0 And dblPorcAdm <= 1 Then
                arrParam(17) = DoubleVbABd(dblPorcAdm)
            Else
                arrParam(17) = DoubleVbABd(dblPorcAdm / 100)
            End If
            arrParam(18) = lngCostoOtic
            arrParam(19) = lngCostoAdm
            arrParam(20) = lngGastoEmpresa
            arrParam(21) = lngCostoOticVYT
            arrParam(22) = lngCostoAdmVYT
            arrParam(23) = lngGastoEmpresaVYT

            arrParam(24) = lngTotalViatico
            arrParam(25) = lngTotalTraslado
            arrParam(26) = intCodAtributo
            arrParam(27) = StringSql(strObsCurso)
            arrParam(28) = mlngValorComunicado
            arrParam(29) = StringSql(strObsLiquidacion)
            arrParam(30) = DoubleVbABd(lngHoras)
            arrParam(31) = intNroFacturaOtec
            arrParam(32) = FechaVbABd(dtmFechaPagoFactura)
            arrParam(33) = lngCodCursoCompl
            arrParam(34) = intIndDescPorc
            arrParam(35) = StringSql(strCorrEmpresa)
            arrParam(36) = FechaVbABd(Now.Date)
            arrParam(37) = lngCodCursoParcial
            arrParam(38) = StringSql(strContactoAdicional)
            arrParam(39) = StringSql(strObservacion)
            arrParam(40) = lngCodModalidad
            arrParam(41) = StringSql(strNroDireccionCurso)
            arrParam(42) = StringSql(strCiudad)
            arrParam(43) = DoubleVbABd(dblValorHora)
            arrParam(44) = BooleanVbAbd(blnCursoCFT)


            If lngRutEncargado = 0 Then
                arrParam(45) = "Null"
            Else
                arrParam(45) = lngRutEncargado
            End If

            If (arrParam(13) = -1) Then
                arrParam(13) = "Null"
            End If
            If (arrParam(14) = -1) Then
                arrParam(14) = "Null"
            End If
            If (arrParam(31) = -1) Then
                arrParam(31) = "Null"
            End If
            If (arrParam(33) = -1) Then
                arrParam(33) = "Null"
            End If
            If (arrParam(35) = "") Then
                arrParam(35) = "Null"
            End If
            If (arrParam(37) = -1) Then
                arrParam(37) = "Null"
            End If
            If (arrParam(40) = 0) Then
                arrParam(40) = "Null"
            End If


            Dim strInsValorHora As String = ""
            Dim strValueValorHora As String = ""
            If dblValorHora > 0.0 Then
                strInsValorHora = " , valor_hora "
                strValueValorHora = " , [43] "
            End If

            strQuery = _
                    "Insert Into Curso_Contratado (rut_cliente, cod_tipo_activ, ind_acu_com_bip, " _
                    & "ind_det_nece, num_alumnos, direccion_curso, cod_comuna, codigo_sence, fecha_inicio, " _
                    & "fecha_termino, horas_compl, valor_mercado, descuento, " _
                    & "correlativo, nro_registro, cod_estado_curso, " _
                    & "agno, porc_adm, costo_otic, costo_adm, gasto_empresa, " _
                    & "costo_otic_vyt, costo_adm_vyt, gasto_empresa_vyt, " _
                    & "total_viatico, total_traslado, cod_origen, obs_curso, " _
                    & "costo_otic_comunicar, obs_liquidacion, horas, nro_factura_otec, " _
                    & "fecha_pago_factura, cod_curso_compl, ind_desc_porc, correlativo_empresa, " _
                    & "fecha_ingreso, fecha_modificacion, cod_curso_parcial,contacto_adicional,observacion,cod_modalidad" _
                    & ",nro_direccion_curso,ciudad,flag_curso_cft, rut_encargado" & strInsValorHora & ") " _
                    & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], " _
                    & "[13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], " _
                    & "[25], [26], [27], [28], [29], [30], [31], [32], [33], [34],[35],[36],[36], " _
                    & "[37], [38], [39], [40],[41],[42],[44],[45]" & strValueValorHora & ")"

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_curso_contr(ByVal lngRutCliente As Long, ByVal intCodTipoActiv As Integer, _
                          ByVal blnIndAcuComBip As Boolean, ByVal blnIndDetNece As Boolean, _
                          ByVal lngParticipantes As Long, ByVal strDireccionCurso As String, _
                          ByVal lngCodComuna As Long, ByVal strCodSence As String, _
                          ByVal dtmFechaInicio As Date, ByVal dtmFechaTermino As Date, _
                          ByVal lngHorasCompl As Long, ByVal lngValorMercado As Long, ByVal lngDescuento As Long, _
                          ByVal lngCorrelativo As Long, ByVal lngNroRegistro As Integer, ByVal intCodEstadoCurso As Long, _
                          ByVal lngAgno As Long, ByVal dblPorcAdm As Double, _
                          ByVal lngCostoOtic As Long, ByVal lngCostoAdm As Long, _
                          ByVal lngGastoEmpresa As Long, ByVal lngCostoOticVYT As Long, _
                          ByVal lngCostoAdmVYT As Long, ByVal lngGastoEmpresaVYT As Long, _
                          ByVal lngTotalViatico As Long, _
                          ByVal lngTotalTraslado As Long, _
                          ByVal strObsCurso As String, ByVal mlngValorComunicado As Long, _
                          ByVal strObsLiquidacion As String, ByVal lngHoras As Long, _
                          ByVal intNroFacturaOtec As Integer, ByVal dtmFechaPagoFactura As Date, _
                          ByVal lngCodCursoCompl As Long, ByVal intIndDescPorc As Integer, _
                          ByVal strCorrEmpresa As String, ByVal lngCodCursoParcial As Long, _
                          ByVal strContactoAdicional As String, ByVal strObservacion As String, _
                          ByVal lngCodModalidad As Long, _
                          ByVal strNroDireccionCurso As String, ByVal strCiudad As String, ByVal doubValor_hora As Double)


            Dim strQuery As String, arrParam(43)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodTipoActiv
            arrParam(2) = BooleanAspAbd(blnIndAcuComBip)
            arrParam(3) = BooleanAspAbd(blnIndDetNece)
            arrParam(4) = lngParticipantes
            arrParam(5) = StringSql(strDireccionCurso)
            arrParam(6) = lngCodComuna
            arrParam(7) = StringSql(strCodSence)
            arrParam(8) = FechaVbABd(dtmFechaInicio)
            arrParam(9) = FechaVbABd(dtmFechaTermino)
            arrParam(10) = lngHorasCompl
            arrParam(11) = lngValorMercado
            arrParam(12) = lngDescuento
            arrParam(13) = lngCorrelativo
            arrParam(14) = lngNroRegistro
            arrParam(15) = intCodEstadoCurso
            arrParam(16) = lngAgno
            If dblPorcAdm >= 0 And dblPorcAdm <= 1 Then
                arrParam(17) = DoubleVbABd(dblPorcAdm)
            Else
                arrParam(17) = DoubleVbABd(dblPorcAdm / 100)
            End If
            arrParam(18) = lngCostoOtic
            arrParam(19) = lngCostoAdm
            arrParam(20) = lngGastoEmpresa
            arrParam(21) = lngCostoOticVYT
            arrParam(22) = lngCostoAdmVYT
            arrParam(23) = lngGastoEmpresaVYT

            arrParam(24) = lngTotalViatico
            arrParam(25) = lngTotalTraslado
            arrParam(27) = StringSql(strObsCurso)
            arrParam(28) = mlngValorComunicado
            arrParam(29) = StringSql(strObsLiquidacion)
            arrParam(30) = lngHoras
            arrParam(31) = intNroFacturaOtec
            If dtmFechaPagoFactura = FechaMinSistema() Then
                arrParam(32) = "Null"
            Else
                arrParam(32) = FechaVbABd(dtmFechaPagoFactura)
            End If
            If lngCodCursoCompl <> 0 Then
                arrParam(33) = lngCodCursoCompl
            Else
                arrParam(33) = "null"
            End If
            arrParam(34) = intIndDescPorc
            arrParam(35) = StringSql(strCorrEmpresa)
            arrParam(36) = FechaVbABd(Now.Date)
            If lngCodCursoParcial <> 0 Then
                arrParam(37) = lngCodCursoParcial
            Else
                arrParam(37) = "null"
            End If
            arrParam(38) = StringSql(strContactoAdicional)
            arrParam(39) = StringSql(strObservacion)
            arrParam(40) = lngCodModalidad
            arrParam(41) = StringSql(strNroDireccionCurso)
            arrParam(42) = StringSql(strCiudad)
            arrParam(43) = DoubleVbABd(doubValor_hora)

            If (arrParam(13) = -1) Then
                arrParam(13) = "Null"
            End If
            If (arrParam(14) = 0) Then
                arrParam(14) = "Null"
            End If
            If (arrParam(31) = 0) Then
                arrParam(31) = "Null"
            End If
            If (arrParam(35) = "") Then
                arrParam(35) = "Null"
            End If
            If (arrParam(40) = 0) Then
                arrParam(40) = "Null"
            End If
            strQuery = _
                    "Insert Into Curso_Contratado (rut_cliente, cod_tipo_activ, ind_acu_com_bip, " _
                    & "ind_det_nece, num_alumnos, direccion_curso, cod_comuna, codigo_sence, fecha_inicio, " _
                    & "fecha_termino, horas_compl, valor_mercado, descuento, " _
                    & "correlativo, nro_registro, cod_estado_curso, " _
                    & "agno, porc_adm, costo_otic, costo_adm, gasto_empresa, " _
                    & "costo_otic_vyt, costo_adm_vyt, gasto_empresa_vyt, " _
                    & "total_viatico, total_traslado, cod_origen, obs_curso, " _
                    & "costo_otic_comunicar, obs_liquidacion, horas, nro_factura_otec, " _
                    & "fecha_pago_factura, cod_curso_compl, ind_desc_porc, correlativo_empresa, " _
                    & "fecha_ingreso, fecha_modificacion, cod_curso_parcial,contacto_adicional,observacion,cod_modalidad" _
                    & ",nro_direccion_curso,ciudad,valor_hora) " _
                    & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], " _
                    & "[13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], " _
                    & "[25], 0, [27], [28], [29], [30], [31], [32], [33], [34],[35],[36],[36], " _
                    & "[37], [38], [39], [40],[41],[42],[43])"

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        ' bit�cora de acciones del sistema
        '
        'insercion de datos en la bitacora
        Public Sub i_bitacora( _
                ByVal lngRutUsuario As Long, _
                ByVal strNombreEstado As String, ByVal strDesc As String, _
                ByVal intCodTipoRef As Long, ByVal lngCodRef As Long)
            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngRutUsuario
            arrParam(1) = FechaHoraVbABd(Now)
            arrParam(2) = StringSql(strNombreEstado)
            arrParam(3) = StringSql(strDesc)
            arrParam(4) = intCodTipoRef
            arrParam(5) = lngCodRef

            strQuery = _
                "Insert Into Bitacora(rut_usuario, fecha_hora, nombre_estado, " _
                & "obs, cod_tipo_ref, cod_ref) " _
                & "Values([0], [1], [2], [3], [4], [5])"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserta un horario de un curso en la BD

        Public Sub i_horario_curso(ByVal lngCodCurso As Long, ByVal intDia As Integer, _
                                   ByVal strHoraInicio As String, ByVal strHoraTermino As String)

            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngCodCurso
            arrParam(1) = intDia
            arrParam(2) = StringSql(strHoraInicio)
            arrParam(3) = StringSql(strHoraTermino)

            strQuery = _
                    "Insert Into Horario_Curso (cod_curso, dia, hora_inicio, hora_fin) " _
                & "Values ([0], [1], [2], [3]) "

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        Public Sub i_PersonaNatural(ByVal lngRut As Long, _
                           ByVal Strap_paterno As String, _
                           ByVal Strap_Materno As String, _
                           ByVal strNombre As String, _
                           ByVal dtFechaNacim As String, _
                           ByVal strSexo As String, _
                           ByVal intporc_franquicias As Integer, _
                           ByVal intCod_nivel_ocup As Integer, _
                           ByVal intCod_nivel_educ As Integer, _
                           ByVal intCod_Region As Long, _
                           ByVal lngRut_Empresa As Long, _
                           ByVal lngCodComuna As Long, _
                           ByVal lngCodPais As Long, _
                            ByVal strFono As String, _
                             ByVal strEmail As String)

            Dim strQuery As String, arrParam(14)
            arrParam(0) = CLng(lngRut)
            arrParam(1) = StringSql(Strap_paterno)
            arrParam(2) = StringSql(Strap_Materno)
            arrParam(3) = StringSql(strNombre)
            arrParam(4) = FechaVbABd(FechaUsrAVb(dtFechaNacim))
            If strSexo = "" Then
                arrParam(5) = StringSql("")
            Else
                arrParam(5) = StringSql(strSexo)
            End If

            arrParam(6) = DoubleVbABd(CDbl((CInt(intporc_franquicias)) / 100))
            arrParam(7) = CInt(intCod_nivel_ocup)
            arrParam(8) = CInt(intCod_nivel_educ)
            arrParam(9) = CInt(intCod_Region)
            arrParam(10) = CLng(lngRut_Empresa)
            arrParam(11) = lngCodComuna
            arrParam(12) = lngCodPais
            If strFono = "" Then
                arrParam(13) = "NULL"
            Else
                arrParam(13) = StringSql(strFono)
            End If
            If strEmail = "" Then
                arrParam(14) = "NULL"
            Else
                arrParam(14) = StringSql(strEmail)
            End If

            strQuery = _
                "Insert Into Persona_Natural (rut, ap_paterno,ap_materno,nombre, " _
                & "fecha_nacim, sexo, porc_franquicia, cod_nivel_ocup, cod_nivel_educ, " _
                & "cod_region, rut_empresa,cod_comuna, cod_pais, fono, email) " _
                & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10],[11],[12],[13],[14])"

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_PersonaNatural2(ByVal lngRut As Long, _
                           ByVal Strap_paterno As String, _
                           ByVal Strap_Materno As String, _
                           ByVal strNombre As String, _
                           ByVal dtFechaNacim As String, _
                           ByVal strSexo As String, _
                           ByVal intporc_franquicias As Integer, _
                           ByVal intCod_nivel_ocup As Integer, _
                           ByVal intCod_nivel_educ As Integer, _
                           ByVal intCod_Region As Long, _
                           ByVal lngRut_Empresa As Long, _
                           ByVal lngCodComuna As Long, _
                           ByVal lngCodPais As Long, _
                            ByVal strFono As String, _
                             ByVal strEmail As String)

            Dim strQuery As String, arrParam(14)
            arrParam(0) = CLng(lngRut)
            arrParam(1) = StringSql(Strap_paterno)
            arrParam(2) = StringSql(Strap_Materno)
            arrParam(3) = StringSql(strNombre)
            arrParam(4) = FechaVbABd(FechaUsrAVb(dtFechaNacim))
            If strSexo = "" Then
                arrParam(5) = ""
            Else
                arrParam(5) = StringSql(strSexo)
            End If
            arrParam(6) = DoubleVbABd(intporc_franquicias)
            arrParam(7) = CInt(intCod_nivel_ocup)
            arrParam(8) = CInt(intCod_nivel_educ)
            arrParam(9) = CInt(intCod_Region)
            arrParam(10) = CLng(lngRut_Empresa)
            arrParam(11) = lngCodComuna
            arrParam(12) = lngCodPais
            If strFono = "" Then
                arrParam(13) = "NULL"
            Else
                arrParam(13) = StringSql(strFono)
            End If
            If strEmail = "" Then
                arrParam(14) = "NULL"
            Else
                arrParam(14) = StringSql(strEmail)
            End If
            strQuery = _
                "Insert Into Persona_Natural (rut, ap_paterno,ap_materno,nombre, " _
                & "fecha_nacim, sexo, porc_franquicia, cod_nivel_ocup, cod_nivel_educ, " _
                & "cod_region, rut_empresa,cod_comuna, cod_pais, fono, email) " _
                & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10],[11],[12],[13],[14])"

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_participante(ByVal lngCodCurso As Long, ByVal lngRutAlumno As Long, _
                                  ByVal intCodNivelOcup As Integer, ByVal intCodRegion As Integer, _
                                  ByVal dblPorcFranquicia As Double, ByVal lngViatico As Long, _
                                  ByVal lngTraslado As Long, ByVal dblPorcAsistencia As Double, _
                                  ByVal strObservaciones As String, ByVal intCodNivelEduc As Integer, _
                                  ByVal lngCodComuna As Long, Optional ByVal CodigoClasificador As String = "")

            Dim strQuery As String, arrParam(11)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutAlumno
            arrParam(2) = intCodNivelOcup
            arrParam(3) = intCodRegion
            If dblPorcFranquicia >= 0 And dblPorcFranquicia <= 1 Then
                arrParam(4) = DoubleVbABd(dblPorcFranquicia)
            Else
                arrParam(4) = DoubleVbABd(dblPorcFranquicia / 100)
            End If
            arrParam(5) = lngViatico
            arrParam(6) = lngTraslado
            If dblPorcAsistencia >= 0 And dblPorcAsistencia <= 1 Then
                arrParam(7) = DoubleVbABd(dblPorcAsistencia)
            Else
                arrParam(7) = DoubleVbABd(dblPorcAsistencia / 100)
            End If
            If strObservaciones Is Nothing Then
                strObservaciones = "..."
                arrParam(8) = StringSql(strObservaciones)
            Else
                arrParam(8) = StringSql(strObservaciones)
            End If

            arrParam(9) = intCodNivelEduc
            arrParam(10) = lngCodComuna
            Dim str1 As String = ""
            Dim str2 As String = ""
            If CodigoClasificador <> "" Then
                arrParam(11) = StringSql(CodigoClasificador)
                str1 = str1 & ",cod_clasificador"
                str2 = str2 & ",[11]"
            End If

            strQuery = _
                    "Insert Into Participante (cod_curso, rut_alumno, cod_nivel_ocup, " _
                & "cod_region, porc_franquicia, viatico, traslado, porc_asistencia, " _
                & "observaciones, cod_nivel_educ,cod_comuna" & str1 & ") " _
                    & "Values ([0], [1], [2], [3], [4], [5], [6], [7], [8], [9],[10]" & str2 & ") "

            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'insertar. Retorna el c�digo (serial) generado
        Public Function i_transaccion(ByVal lngRutCliente As Long, ByVal intCodCuenta As Integer, _
                                            ByVal intCodTipoTran As Integer, ByVal intEstado As Integer, _
                                            ByVal lngMonto As Long, ByVal strDescripcion As String, _
                                            ByVal lngCodCurso As Long, ByVal lngCodAporte As Long, _
                                            ByVal dtmFechaHora As Date, _
                                            Optional ByVal lngCodTraspaso As Long = 0) As Long
            Dim strQuery As String, arrParam(9)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodCuenta
            arrParam(2) = intCodTipoTran
            arrParam(3) = intEstado
            arrParam(4) = lngMonto
            arrParam(5) = StringSql(strDescripcion)
            If dtmFechaHora <= FechaMinSistema() Or IsDBNull(dtmFechaHora) Then
                arrParam(6) = FechaHoraVbABd(Now)
            Else
                arrParam(6) = FechaHoraVbABd(dtmFechaHora)
            End If
            If lngCodCurso > 0 Then
                arrParam(7) = lngCodCurso
            Else
                arrParam(7) = "Null"
            End If
            If lngCodAporte > 0 Then
                arrParam(8) = lngCodAporte
            Else
                arrParam(8) = "Null"
            End If
            If IsDBNull(lngCodTraspaso) Or (lngCodTraspaso <= 0) Then
                arrParam(9) = "Null"
            Else
                arrParam(9) = lngCodTraspaso
            End If

            Dim lngSaldoCta As Long

            strQuery = _
                "Insert Into Transaccion(rut_cliente, cod_cuenta, cod_tipo_tran," _
                & "cod_estado_tran, fecha_hora, monto, descripcion, " _
                & "cod_curso, cod_aporte, cod_traspaso) " _
                & "Values([0], [1], [2], [3], [6], [4], [5], [7], [8], [9])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            lngSaldoCta = s_saldo_cuenta(lngRutCliente, intCodCuenta)
            Call u_SaldoCuentaCliente(lngRutCliente, intCodCuenta, lngSaldoCta + lngMonto)
            'retorna el serial
            i_transaccion = Serial("nro_transaccion", "Transaccion")
        End Function
        Public Function i_transaccion2(ByVal lngRutCliente As Long, ByVal intCodCuenta As Integer, _
                                          ByVal intCodTipoTran As Integer, ByVal intEstado As Integer, _
                                          ByVal lngMonto As Long, ByVal strDescripcion As String, _
                                          ByVal lngCodCurso As Long, ByVal lngCodAporte As Long, _
                                          ByVal dtmFechaHora As Date, _
                                          Optional ByVal lngCodTraspaso As Long = 0) As Long
            Dim strQuery As String, arrParam(9)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodCuenta
            arrParam(2) = intCodTipoTran
            arrParam(3) = intEstado
            arrParam(4) = lngMonto
            arrParam(5) = StringSql(strDescripcion)
            If dtmFechaHora <= FechaMinSistema() Or IsDBNull(dtmFechaHora) Then
                arrParam(6) = FechaHoraVbABd(Now)
            Else
                arrParam(6) = FechaHoraVbABd(dtmFechaHora)
            End If
            If lngCodCurso > 0 Then
                arrParam(7) = lngCodCurso
            Else
                arrParam(7) = "Null"
            End If
            If lngCodAporte > 0 Then
                arrParam(8) = lngCodAporte
            Else
                arrParam(8) = "Null"
            End If
            If IsDBNull(lngCodTraspaso) Or (lngCodTraspaso <= 0) Then
                arrParam(9) = "Null"
            Else
                arrParam(9) = lngCodTraspaso
            End If

            Dim lngSaldoCta As Long

            strQuery = _
                "Insert Into Transaccion(rut_cliente, cod_cuenta, cod_tipo_tran," _
                & "cod_estado_tran, fecha_hora, monto, descripcion, " _
                & "cod_curso, cod_aporte, cod_traspaso) " _
                & "Values([0], [1], [2], [3], [6], [4], [5], [7], [8], [9])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            lngSaldoCta = s_saldo_cuenta2(lngRutCliente)
            Call u_SaldoCuentaCliente2(lngRutCliente, intCodCuenta, lngSaldoCta + lngMonto)
            'retorna el serial
            i_transaccion2 = Serial("nro_transaccion", "Transaccion")
        End Function

        Public Function i_acc_cap(ByVal id_acc_cap As Long, ByVal id_comuna As Long, _
                                  ByVal fec_ini_acc_cap As Date, ByVal cod_sence As String, _
                                  ByVal fec_ter_acc_cap As Date, ByVal id_comunicador As Long, _
                                  ByVal dir_acc_cap As String, ByVal tipo_accion_cap As Integer, _
                                  ByVal observ_acc_cap As String, ByVal valor_total_curso As Long, _
                                  ByVal ind_acu_com_bip As Integer, ByVal tipo_operacion As String, _
                                  ByVal valor_total_liquidar As Long, ByVal obs_liquidacion As String, _
                                  ByVal id_usuario_empresa As String, ByVal horas_ejecutadas As Long, _
                                  ByVal tipo_actividad_cap As Integer, ByVal id_det_nece As Integer, _
                                  ByVal ind_mandato As Integer) As Long
            Dim strQuery As String, arrParam(18)
            arrParam(0) = id_acc_cap
            arrParam(1) = id_comuna
            arrParam(2) = FechaVbABdAccess(fec_ini_acc_cap)
            arrParam(3) = StringSql(cod_sence)
            arrParam(4) = FechaVbABdAccess(fec_ter_acc_cap)
            arrParam(5) = StringSql(id_comunicador)
            arrParam(6) = StringSql(dir_acc_cap)
            arrParam(7) = tipo_accion_cap
            arrParam(8) = StringSql(observ_acc_cap)
            arrParam(9) = valor_total_curso
            arrParam(10) = ind_acu_com_bip
            arrParam(11) = StringSql(tipo_operacion)
            arrParam(12) = valor_total_liquidar
            arrParam(13) = StringSql(obs_liquidacion)
            arrParam(14) = StringSql(id_usuario_empresa)
            arrParam(15) = horas_ejecutadas
            arrParam(16) = tipo_actividad_cap
            arrParam(17) = id_det_nece
            arrParam(18) = ind_mandato
            strQuery = _
                "insert into acc_cap (id_acc_cap, id_comuna, fec_ini_acc_cap, " _
                & "cod_sence, fec_ter_acc_cap, id_comunicador, dir_acc_cap, " _
                & "tipo_accion_cap, observ_acc_cap, valor_total_curso, ind_acu_com_bip, " _
                & "tipo_operacion, valor_total_liquidar, obs_liquidacion, id_usuario_empresa, " _
                & "horas_ejecutadas, tipo_actividad_cap, id_det_nece, ind_mandato) " _
                & "values ([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11], " _
                & "[12],[13],[14],[15],[16],[17],[18]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        'Inserci�n de datos en tabla Rubro
        Public Sub i_Rubro(ByVal strNombre As String)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = Serial("cod_rubro", "Rubro") + 1
            arrParam(1) = StringSql(strNombre)
            strQuery = _
                "Insert Into Rubro (cod_rubro, nombre) " _
                & "Values([0], [1])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Function i_direccion(ByVal id_direccion As Long, ByVal nombre_dire As String, _
                                  ByVal ciudad As String, ByVal id_comuna As Long, _
                                  ByVal villa_poblacion As String, ByVal n_oficina As String, _
                                  ByVal n_dire As String, ByVal id_tipo As Long, _
                                  ByVal id_acc_cap As Long, ByVal rut_num_pers_jur As Long) As Long
            Dim strQuery As String, arrParam(9)
            arrParam(0) = id_direccion
            arrParam(1) = StringSql(nombre_dire)
            arrParam(2) = StringSql(ciudad)
            arrParam(3) = id_comuna
            arrParam(4) = StringSql(villa_poblacion)
            arrParam(5) = StringSql(n_oficina)
            arrParam(6) = StringSql(n_dire)
            arrParam(7) = id_tipo
            arrParam(8) = id_acc_cap
            arrParam(9) = rut_num_pers_jur
            strQuery = _
                "insert into direccion (id_direccion, nombre_dire, ciudad, " _
                & "id_comuna, villa_poblacion, n_oficina, n_dire, id_tipo,  " _
                & "id_acc_cap, rut_num_pers_jur) " _
                & "values ([0],[1],[2],[3],[4],[5],[6],[7],[8],[9]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function i_encargado_access(ByVal rut_encargado As String, ByVal nombre_encargado As String, _
                                  ByVal apellido_encargado As String, ByVal cargo_encargado As String, _
                                   ByVal telefono_encargado As Long, _
                                  ByVal id_acc_cap As Long, ByVal email_encargado As String) As Long

            Dim strQuery As String, arrParam(6)
            arrParam(0) = StringSql(rut_encargado)
            arrParam(1) = StringSql(nombre_encargado)
            arrParam(2) = StringSql(apellido_encargado)
            arrParam(3) = StringSql(cargo_encargado)
            arrParam(4) = telefono_encargado
            arrParam(5) = StringSql(email_encargado)
            arrParam(6) = id_acc_cap

            strQuery = _
                "insert into encargado (id_acc_cap, rut, nombre, " _
                & "apellido, email, telefono, cargo) " _
                & "values ([6],[0],[1],[2],[5],[4],[3]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        'Public Function i_encargado(ByVal rut_encargado As String, ByVal nombre_encargado As String, _
        '                          ByVal apellido_encargado As String, ByVal cargo_encargado As String, _
        '                           ByVal telefono_encargado As Long, _
        '                          ByVal id_acc_cap As Long, ByVal email_encargado As String) As Long

        '    Dim strQuery As String, arrParam(6)
        '    arrParam(0) = StringSql(rut_encargado)
        '    arrParam(1) = StringSql(nombre_encargado)
        '    arrParam(2) = StringSql(apellido_encargado)
        '    arrParam(3) = StringSql(cargo_encargado)
        '    arrParam(4) = telefono_encargado
        '    arrParam(5) = StringSql(email_encargado)
        '    arrParam(6) = id_acc_cap

        '    strQuery = _
        '        "insert into encargado (id_acc_cap, rut, nombre, " _
        '        & "apellido, email) " _
        '        & "values ([6],[0],[1],[2],[5]) "
        '    EjecutarSql(SqlParam(strQuery, arrParam))
        'End Function
        Public Function i_horario(ByVal id_acc_cap As Long, ByVal dia_clase As Long, _
                                  ByVal hora_desde As String, ByVal hora_hasta As String) As Long
            Dim strQuery As String, arrParam(3)
            arrParam(0) = id_acc_cap
            arrParam(1) = dia_clase
            arrParam(2) = StringSql(hora_desde)
            arrParam(3) = StringSql(hora_hasta)
            strQuery = _
                "insert into horario (id_acc_cap, dia_clase, hora_desde, " _
                & "hora_hasta) " _
                & "values ([0],[1],[2],[3]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function i_persona_natural_access(ByVal rut_num_pers_nat As Long, ByVal rut_dgv_pers_nat As String, _
                                                ByVal nombre_pers_nat As String, ByVal ape_1_pers_nat As String, _
                                                ByVal ape_2_pers_nat As String, ByVal fec_nac_pers_nat As Date, _
                                                ByVal rut_num_pers_jur As Long, ByVal sexo As String, _
                                                ByVal id_escolaridad As String) As Long
            Dim strQuery As String, arrParam(8)
            arrParam(0) = rut_num_pers_nat
            arrParam(1) = StringSql(rut_dgv_pers_nat)
            arrParam(2) = StringSql(nombre_pers_nat)
            arrParam(3) = StringSql(ape_1_pers_nat)
            arrParam(4) = StringSql(ape_2_pers_nat)
            arrParam(5) = FechaVbABdAccess(fec_nac_pers_nat)
            arrParam(6) = rut_num_pers_jur
            arrParam(7) = StringSql(sexo)
            arrParam(8) = StringSql(id_escolaridad)
            strQuery = _
                "insert into pers_nat(rut_num_pers_nat, rut_dgv_pers_nat, nombre_pers_nat, ape_1_pers_nat, " _
                & "ape_2_pers_nat, fec_nac_pers_nat, rut_num_pers_jur, sexo, id_escolaridad) " _
                & "values ([0],[1],[2],[3],[4],[5],[6],[7],[8]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function i_participante_access(ByVal id_acc_cap As Long, ByVal rut_num_pers_jur As Long, _
                                                ByVal rut_num_pers_nat As Long, ByVal porc_franq As Integer, _
                                                ByVal id_niv_ocu As Long, ByVal id_region As Long, _
                                                ByVal observaciones As String, ByVal viatico As Long, _
                                                ByVal traslado As Long, ByVal cod_asist As Long, _
                                                ByVal porc_asist As Long, ByVal id_escolaridad As String, _
                                                ByVal id_comuna As Long, ByVal id_pais As Integer, _
                                                ByVal email As String, ByVal fono As Long) As Long
            Dim strQuery As String, arrParam(15)
            arrParam(0) = id_acc_cap
            arrParam(1) = rut_num_pers_jur
            arrParam(2) = rut_num_pers_nat
            arrParam(3) = porc_franq
            arrParam(4) = id_niv_ocu
            arrParam(5) = id_region
            arrParam(6) = StringSql(observaciones)
            arrParam(7) = viatico
            arrParam(8) = traslado
            arrParam(9) = cod_asist
            arrParam(10) = porc_asist
            arrParam(11) = StringSql(id_escolaridad)
            arrParam(12) = id_comuna
            arrParam(13) = StringSql(email)
            arrParam(14) = fono
            arrParam(15) = id_pais
            'arrParam(13) = StringSql(estado_participante)
            strQuery = _
                "insert into participante(id_acc_cap, rut_num_pers_jur, rut_num_pers_nat, porc_franq, " _
                & "id_niv_ocu, id_region, observaciones, viatico, traslado, cod_asist, porc_asist, " _
                & "id_escolaridad, id_comuna, email, telefono, id_pais) " _
                & "values ([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function i_persona_juridica_access(ByVal rut_num_pers_jur As Long, ByVal rut_dgv_pers_jur As String, _
                                                ByVal nom_fan_pers_jur As String, ByVal raz_soc_pers_jur As String, _
                                                ByVal dir_pers_jur As String, ByVal sigla_pers_jur As String, _
                                                ByVal fono1_pers_jur As String, ByVal fono2_pers_jur As String, _
                                                ByVal id_comuna As Long, ByVal e_mail As String, _
                                                ByVal fax_pers_jur As String, ByVal casilla As String, _
                                                ByVal ciudad As String) As Long
            Dim strQuery As String, arrParam(12)
            arrParam(0) = rut_num_pers_jur
            arrParam(1) = StringSql(rut_dgv_pers_jur)
            arrParam(2) = StringSql(nom_fan_pers_jur)
            arrParam(3) = StringSql(raz_soc_pers_jur)
            arrParam(4) = StringSql(dir_pers_jur)
            arrParam(5) = StringSql(sigla_pers_jur)
            arrParam(6) = StringSql(fono1_pers_jur)
            arrParam(7) = StringSql(fono2_pers_jur)
            arrParam(8) = id_comuna
            arrParam(9) = StringSql(e_mail)
            arrParam(10) = StringSql(fax_pers_jur)
            arrParam(11) = StringSql(casilla)
            arrParam(12) = StringSql(ciudad)
            strQuery = _
                "insert into pers_jur (rut_num_pers_jur, rut_dgv_pers_jur, nom_fan_pers_jur, raz_soc_pers_jur, " _
                & "dir_pers_jur, sigla_pers_jur, fono1_pers_jur, fono2_pers_jur, id_comuna, e_mail, fax_pers_jur, " _
                & "casilla, ciudad) " _
                & "values ([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function i_organismo_acc_cap_access(ByVal rut_num_pers_jur As Long, ByVal rut_dgv_pers_jur As String) As Long
            Dim strQuery As String, arrParam(1)
            arrParam(0) = rut_num_pers_jur
            arrParam(1) = rut_dgv_pers_jur
            strQuery = _
                "insert into organismo_acc_cap (id_acc_cap, rut_num_pers_jur) " _
                & "values ([0],[1]) "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function i_acc_cuenta_otic(ByVal id_acc_cap As Long, ByVal tipo_cuenta As Long, _
                                            ByVal monto_comunicado As Long, ByVal monto_liquidado As Long, _
                                            ByVal Tipo_monto As Long, ByVal Rut_reparto As Long) As Long
            Dim strQuery As String, arrParam(5)
            arrParam(0) = id_acc_cap
            arrParam(1) = tipo_cuenta
            arrParam(2) = monto_comunicado
            arrParam(3) = monto_liquidado
            arrParam(4) = Tipo_monto
            arrParam(5) = Rut_reparto

            strQuery = _
                "insert into acc_cuenta_otic (id_acc_cap, tipo_cuenta, monto_comunicado, " _
                & "monto_liquidado, tipo_monto, rut_reparto) " _
                & "values([0],[1],[2],[3],[4],[5])"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Function i_doc_pago(ByVal id_acc_cap As Long, ByVal num_doc As Long, _
                                            ByVal monto As Long, ByVal rut_emisor As Long, _
                                            ByVal rut_dgv_emisor As String, ByVal id_tipo_doc As Long, _
                                            ByVal fec_ing As Date, ByVal Fec_pago As Date) As Long
            Dim strQuery As String, arrParam(7)
            arrParam(0) = id_acc_cap
            arrParam(1) = num_doc
            arrParam(2) = monto
            arrParam(3) = rut_emisor
            arrParam(4) = StringSql(rut_dgv_emisor)
            arrParam(5) = id_tipo_doc
            arrParam(6) = FechaVbABdAccess(fec_ing)
            If Not Fec_pago = FechaMinSistema() Then
                arrParam(7) = FechaVbABdAccess(Fec_pago)
            Else
                arrParam(7) = ""
            End If
            strQuery = _
                "insert into doc_pago(id_acc_cap,num_doc,monto,rut_emisor,rut_dgv_emisor, " _
                & "id_tipo_doc,fec_ing,Fec_pago) " _
                & "values ([0],[1],[2],[3],[4],[5],[6],[7],)"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Sub i_curso_contr2(ByVal lngRutCliente As Long, ByVal intCodTipoActiv As Integer, _
                          ByVal blnIndAcuComBip As Boolean, ByVal blnIndDetNece As Boolean, _
                          ByVal lngParticipantes As Long, ByVal strDireccionCurso As String, _
                          ByVal lngCodComuna As Long, ByVal strCodSence As String, _
                          ByVal dtmFechaInicio As Date, ByVal dtmFechaTermino As Date, _
                          ByVal lngHorasCompl As Long, ByVal lngValorMercado As Long, ByVal lngDescuento As Long, _
                          ByVal lngCorrelativo As Long, ByVal lngNroRegistro As Integer, ByVal intCodEstadoCurso As Long, _
                          ByVal lngAgno As Long, ByVal dblPorcAdm As Double, _
                          ByVal lngCostoOtic As Long, ByVal lngCostoAdm As Long, _
                          ByVal lngGastoEmpresa As Long, ByVal lngCostoOticVYT As Long, _
                          ByVal lngCostoAdmVYT As Long, ByVal lngGastoEmpresaVYT As Long, _
                          ByVal lngTotalViatico As Long, _
                          ByVal lngTotalTraslado As Long, _
                          ByVal strObsCurso As String, ByVal mlngValorComunicado As Long, _
                          ByVal strObsLiquidacion As String, ByVal lngHoras As Long, _
                          ByVal intNroFacturaOtec As Integer, ByVal dtmFechaPagoFactura As Date, _
                          ByVal lngCodCursoCompl As Long, ByVal intIndDescPorc As Integer, _
                          ByVal strCorrEmpresa As String, ByVal lngCodCursoParcial As Long, _
                          ByVal strContactoAdicional As String, ByVal strObservacion As String, _
                          ByVal lngCodModalidad As Long, _
                          ByVal strNroDireccionCurso As String, ByVal strCiudad As String)

            Try

                Dim strQuery As String, arrParam(42)
                arrParam(0) = lngRutCliente
                arrParam(1) = intCodTipoActiv
                arrParam(2) = BooleanAspAbd(blnIndAcuComBip)
                arrParam(3) = BooleanAspAbd(blnIndDetNece)
                arrParam(4) = lngParticipantes
                arrParam(5) = StringSql(strDireccionCurso)
                arrParam(6) = lngCodComuna
                arrParam(7) = StringSql(strCodSence)
                arrParam(8) = FechaVbABd(dtmFechaInicio)
                arrParam(9) = FechaVbABd(dtmFechaTermino)
                arrParam(10) = lngHorasCompl
                arrParam(11) = lngValorMercado
                arrParam(12) = lngDescuento
                arrParam(13) = lngCorrelativo
                arrParam(14) = lngNroRegistro
                arrParam(15) = intCodEstadoCurso
                arrParam(16) = lngAgno
                If dblPorcAdm >= 0 And dblPorcAdm <= 1 Then
                    arrParam(17) = DoubleVbABd(dblPorcAdm)
                Else
                    arrParam(17) = DoubleVbABd(dblPorcAdm / 100)
                End If
                arrParam(18) = lngCostoOtic
                arrParam(19) = lngCostoAdm
                arrParam(20) = lngGastoEmpresa
                arrParam(21) = lngCostoOticVYT
                arrParam(22) = lngCostoAdmVYT
                arrParam(23) = lngGastoEmpresaVYT

                arrParam(24) = lngTotalViatico
                arrParam(25) = lngTotalTraslado
                arrParam(27) = StringSql(strObsCurso)
                arrParam(28) = mlngValorComunicado
                arrParam(29) = StringSql(strObsLiquidacion)
                arrParam(30) = lngHoras
                arrParam(31) = intNroFacturaOtec
                If dtmFechaPagoFactura = FechaMinSistema() Then
                    arrParam(32) = "Null"
                Else
                    arrParam(32) = FechaVbABd(dtmFechaPagoFactura)
                End If
                If lngCodCursoCompl <> 0 Then
                    arrParam(33) = lngCodCursoCompl
                Else
                    arrParam(33) = "null"
                End If
                arrParam(34) = intIndDescPorc
                arrParam(35) = StringSql(strCorrEmpresa)
                arrParam(36) = FechaVbABd(Now.Date)
                If lngCodCursoParcial <> 0 Then
                    arrParam(37) = lngCodCursoParcial
                Else
                    arrParam(37) = "null"
                End If
                arrParam(38) = StringSql(strContactoAdicional)
                arrParam(39) = StringSql(strObservacion)
                arrParam(40) = lngCodModalidad
                arrParam(41) = StringSql(strNroDireccionCurso)
                arrParam(42) = StringSql(strCiudad)

                If (arrParam(13) = -1) Then
                    arrParam(13) = "Null"
                End If
                If (arrParam(14) = 0) Then
                    arrParam(14) = "Null"
                End If
                If (arrParam(31) = 0) Then
                    arrParam(31) = "Null"
                End If
                If (arrParam(35) = "") Then
                    arrParam(35) = "Null"
                End If
                If (arrParam(40) = 0) Then
                    arrParam(40) = "Null"
                End If
                strQuery = _
                        "Insert Into Curso_Contratado (rut_cliente, cod_tipo_activ, ind_acu_com_bip, " _
                        & "ind_det_nece, num_alumnos, direccion_curso, cod_comuna, codigo_sence, fecha_inicio, " _
                        & "fecha_termino, horas_compl, valor_mercado, descuento, " _
                        & "correlativo, nro_registro, cod_estado_curso, " _
                        & "agno, porc_adm, costo_otic, costo_adm, gasto_empresa, " _
                        & "costo_otic_vyt, costo_adm_vyt,gasto_empresa_vyt gasto_emp_vyt, " _
                        & "total_viatico, total_traslado, cod_origen, obs_curso, " _
                        & "costo_otic_comunicar, obs_liquidacion, horas, nro_factura_otec, " _
                        & "fecha_pago_factura, cod_curso_compl, ind_desc_porc, correlativo_empresa, " _
                        & "fecha_ingreso, fecha_modificacion, cod_curso_parcial,contacto_adicional,observacion,cod_modalidad" _
                        & ",nro_direccion_curso,ciudad) " _
                        & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], " _
                        & "[13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], " _
                        & "[25], 0, [27], [28], [29], [30], [31], [32], [33], [34],[35],[36],[36], " _
                        & "[37], [38], [39], [40],[41],[42])"
                Call EjecutarSql(SqlParam(strQuery, arrParam))
            Catch ex As Exception

            End Try
        End Sub
        Public Sub i_curso_contr2Adm(ByVal lngRutCliente As Long, ByVal intCodTipoActiv As Integer, _
                          ByVal blnIndAcuComBip As Boolean, ByVal blnIndDetNece As Boolean, _
                          ByVal lngParticipantes As Long, ByVal strDireccionCurso As String, _
                          ByVal lngCodComuna As Long, ByVal strCodSence As String, _
                          ByVal dtmFechaInicio As Date, ByVal dtmFechaTermino As Date, _
                          ByVal lngHorasCompl As Long, ByVal lngValorMercado As Long, ByVal lngDescuento As Long, _
                          ByVal lngCorrelativo As Long, ByVal lngNroRegistro As Integer, ByVal intCodEstadoCurso As Long, _
                          ByVal lngAgno As Long, ByVal dblPorcAdm As Double, _
                          ByVal lngCostoOtic As Long, ByVal lngCostoAdm As Long, _
                          ByVal lngGastoEmpresa As Long, ByVal lngCostoOticVYT As Long, _
                          ByVal lngCostoAdmVYT As Long, ByVal lngGastoEmpresaVYT As Long, _
                          ByVal lngTotalViatico As Long, _
                          ByVal lngTotalTraslado As Long, _
                          ByVal strObsCurso As String, ByVal mlngValorComunicado As Long, _
                          ByVal strObsLiquidacion As String, ByVal lngHoras As Long, _
                          ByVal intNroFacturaOtec As Integer, ByVal dtmFechaPagoFactura As Date, _
                          ByVal lngCodCursoCompl As Long, ByVal intIndDescPorc As Integer, _
                          ByVal strCorrEmpresa As String, ByVal lngCodCursoParcial As Long, _
                          ByVal strContactoAdicional As String, ByVal strObservacion As String, _
                          ByVal lngCodModalidad As Long, _
                          ByVal strNroDireccionCurso As String, ByVal strCiudad As String, ByVal intOrigen As Integer)



            Dim strQuery As String, arrParam(42)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodTipoActiv
            arrParam(2) = BooleanAspAbd(blnIndAcuComBip)
            arrParam(3) = BooleanAspAbd(blnIndDetNece)
            arrParam(4) = lngParticipantes
            arrParam(5) = StringSql(strDireccionCurso)
            arrParam(6) = lngCodComuna
            arrParam(7) = StringSql(strCodSence)
            arrParam(8) = FechaVbABd(dtmFechaInicio)
            arrParam(9) = FechaVbABd(dtmFechaTermino)
            arrParam(10) = lngHorasCompl
            arrParam(11) = lngValorMercado
            arrParam(12) = lngDescuento
            arrParam(13) = lngCorrelativo
            arrParam(14) = lngNroRegistro
            arrParam(15) = intCodEstadoCurso
            arrParam(16) = lngAgno
            If dblPorcAdm >= 0 And dblPorcAdm <= 1 Then
                arrParam(17) = DoubleVbABd(dblPorcAdm)
            Else
                arrParam(17) = DoubleVbABd(dblPorcAdm / 100)
            End If
            arrParam(18) = lngCostoOtic
            arrParam(19) = lngCostoAdm
            arrParam(20) = lngGastoEmpresa
            arrParam(21) = lngCostoOticVYT
            arrParam(22) = lngCostoAdmVYT
            arrParam(23) = lngGastoEmpresaVYT

            arrParam(24) = lngTotalViatico
            arrParam(25) = lngTotalTraslado
            arrParam(27) = StringSql(strObsCurso)
            arrParam(28) = mlngValorComunicado
            arrParam(29) = StringSql(strObsLiquidacion)
            arrParam(30) = lngHoras
            arrParam(31) = intNroFacturaOtec
            If dtmFechaPagoFactura = FechaMinSistema() Then
                arrParam(32) = "Null"
            Else
                arrParam(32) = FechaVbABd(dtmFechaPagoFactura)
            End If
            If lngCodCursoCompl <> 0 Then
                arrParam(33) = lngCodCursoCompl
            Else
                arrParam(33) = "null"
            End If
            arrParam(34) = intIndDescPorc
            arrParam(35) = StringSql(strCorrEmpresa)
            If intOrigen = 0 Then
                arrParam(36) = FechaVbABd(Now.Date)
            End If
            If intOrigen = 0 Then
                arrParam(36) = FechaVbABd(DateAdd(DateInterval.Day, -7, dtmFechaInicio)) 'dtmFechaInicio   'StringSql("20100702")
            End If
            If intOrigen = 1 Then
                arrParam(36) = StringSql("20100629")
            End If
            If intOrigen = 2 Then
                arrParam(36) = StringSql("20100702")
            End If

            If lngCodCursoParcial <> 0 Then
                arrParam(37) = lngCodCursoParcial
            Else
                arrParam(37) = "null"
            End If
            arrParam(38) = StringSql(strContactoAdicional)
            arrParam(39) = StringSql(strObservacion)
            arrParam(40) = lngCodModalidad
            arrParam(41) = StringSql(strNroDireccionCurso)
            arrParam(42) = StringSql(strCiudad)

            If (arrParam(13) = -1) Then
                arrParam(13) = "Null"
            End If
            If (arrParam(14) = 0) Then
                arrParam(14) = "Null"
            End If
            If (arrParam(31) = 0) Then
                arrParam(31) = "Null"
            End If
            If (arrParam(35) = "") Then
                arrParam(35) = "Null"
            End If
            If (arrParam(40) = 0) Then
                arrParam(40) = "Null"
            End If
            strQuery = _
                    "Insert Into Curso_Contratado (rut_cliente, cod_tipo_activ, ind_acu_com_bip, " _
                    & "ind_det_nece, num_alumnos, direccion_curso, cod_comuna, codigo_sence, fecha_inicio, " _
                    & "fecha_termino, horas_compl, valor_mercado, descuento, " _
                    & "correlativo, nro_registro, cod_estado_curso, " _
                    & "agno, porc_adm, costo_otic, costo_adm, gasto_empresa, " _
                    & "costo_otic_vyt, costo_adm_vyt,gasto_empresa_vyt gasto_emp_vyt, " _
                    & "total_viatico, total_traslado, cod_origen, obs_curso, " _
                    & "costo_otic_comunicar, obs_liquidacion, horas, nro_factura_otec, " _
                    & "fecha_pago_factura, cod_curso_compl, ind_desc_porc, correlativo_empresa, " _
                    & "fecha_ingreso, fecha_modificacion, cod_curso_parcial,contacto_adicional,observacion,cod_modalidad" _
                    & ",nro_direccion_curso,ciudad) " _
                    & "Values([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], " _
                    & "[13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], " _
                    & "[25], 0, [27], [28], [29], [30], [31], [32], [33], [34],[35],[36],[36], " _
                    & "[37], [38], [39], [40],[41],[42])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        Public Function i_traspaso_manual(ByVal lngRutEmpresa As Long, ByVal dtmFechaContTraspaso As Date, _
                             ByVal intCodCtaOrigen As Integer, ByVal intCodCtaDestino As Integer, _
                             ByVal lngMontoTraspaso As Long, ByVal strObservacion As String, _
                             ByVal lngRutUsuario As Long) As Long

            Dim strQuery As String, arrParam(7)
            arrParam(0) = lngRutEmpresa
            arrParam(1) = FechaVbABd(dtmFechaContTraspaso)
            arrParam(2) = intCodCtaOrigen
            arrParam(3) = intCodCtaDestino
            arrParam(4) = lngMontoTraspaso
            arrParam(5) = StringSql(strObservacion)
            arrParam(6) = FechaHoraVbABd(Now)
            arrParam(7) = lngRutUsuario

            strQuery = _
                "Insert Into Traspaso_Manual(rut, fecha, cod_cuenta_origen, " _
                & "cod_cuenta_destino, monto, observacion, fecha_hora) " _
                & "Values([0], [1], [2], [3], [4], [5], [6]) "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
            'retorna el serial
            i_traspaso_manual = Serial("cod_traspaso", "Traspaso_Manual")

        End Function
        Sub i_usuario(ByVal lngRutUsuario As Long, _
                              ByVal strNombres As String, _
                              ByVal strClave As String, _
                              ByVal strEmail As String, _
                              ByVal strTelefono As String, _
                              ByVal strFax As String)

            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngRutUsuario
            arrParam(1) = StringSql(strNombres)
            arrParam(2) = StringSql(strClave)
            arrParam(3) = StringSql(strEmail)
            arrParam(4) = StringSql(strTelefono)
            arrParam(5) = StringSql(strFax)

            strQuery = "Insert Into Usuario (rut,nombres,passwd_enc,email,conectado,telefono,fax) " _
                           & "Values([0],[1],[2],[3],0,[4],[5])"

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_encargado(ByVal lngRutEncargado As Long, _
                              ByVal strNombres As String, _
                              ByVal strApellido As String, _
                              ByVal strCargo As String, _
                              ByVal lngTelefono As String, _
                              ByVal strEmail As String)

            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngRutEncargado
            arrParam(1) = StringSql(strNombres)
            arrParam(2) = StringSql(strApellido)
            If strCargo = "" Then
                arrParam(3) = "NULL"
            Else
                arrParam(3) = StringSql(strCargo)
            End If
            If lngTelefono = "" Then
                arrParam(4) = "NULL"
            Else
                arrParam(4) = lngTelefono
            End If
            If strEmail = "" Then
                arrParam(5) = "NULL"
            Else
                arrParam(5) = StringSql(strEmail)
            End If
            strQuery = _
                "Insert Into encargado (rut_encargado, nombre_encargado,apellido_encargado,cargo,fono,email) " _
                & "Values([0],[1],[2],[3],[4],[5])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_perfil(ByVal strNombre As String)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = Serial("cod_perfil", "Perfil") + 1
            arrParam(1) = StringSql(strNombre)
            strQuery = _
                "Insert Into Perfil (cod_perfil, nombre) " _
                & "Values([0], [1])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Sub i_encargado_empresa(ByVal lngRutEmpresa As Long, ByVal lngRutEncargado As Long)
            Dim strQuery As String, arrparam(1)
            arrparam(0) = lngRutEncargado
            arrparam(1) = lngRutEmpresa
            strQuery = _
                "insert into encargado_empresa(rut_encargado,rut_empresa) " _
                & "values([0] ,[1]) "
            Call EjecutarSql(SqlParam(strQuery, arrparam))
        End Sub
        Sub i_perfil_Usuario(ByVal intCodPerfil As Integer, ByVal RutUsuario As Long)
            Dim strQuery As String, arrparam(1)
            arrparam(0) = intCodPerfil
            arrparam(1) = RutUsuario
            strQuery = _
                "insert into Perfil_Usuario(cod_perfil,rut) " _
                & "values([0] ,[1]) "
            Call EjecutarSql(SqlParam(strQuery, arrparam))
        End Sub
        'inserta Supervisor
        Public Sub i_Supervisor(ByVal RutSupervisor As Long, ByVal RutEjecutivo As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = RutSupervisor
            arrParam(1) = RutEjecutivo
            strQuery = _
                "insert into supervisor(rut_supervisor,rut_ejecutivo) " _
                & "values([0] ,[1]) "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'inserta perfilobjeto
        Public Sub i_perfilObjeto(ByVal intCodPerfil As Integer, ByVal intCodObjeto As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodPerfil
            arrParam(1) = intCodObjeto
            strQuery = _
                "insert perfil_objeto(cod_perfil,cod_objeto) " _
                & "Values([0], [1])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            'Call EjecutarSql("Execute i_perfilObjeto " & intCodPerfil & ", " _
            '& intCodObjeto & "")
        End Sub
        'Nuevo aporte. Retorna el serial generado
        Public Function i_aporte(ByVal lngRutCliente As Long, ByVal intCodCuenta As Integer, _
                                 ByVal dtmFechaContable As Date, _
                                 ByVal lngMontoNeto As Long, ByVal lngMontoAdm As Long, _
                                 ByVal intCodTipoDoc As Integer, ByVal strNroDoc As String, _
                                 ByVal strBanco As String, ByVal dtmFechaVenc As Date, _
                                 ByVal dtmFechaCobro As Date, ByVal lngNumAporte As Long, _
                                 ByVal intEstadoAporte As Integer, ByVal strObs As String) As Long
            Dim strQuery As String, arrParam(15)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodCuenta
            arrParam(2) = intEstadoAporte
            arrParam(3) = intCodTipoDoc
            arrParam(4) = 1   'cod_origen
            arrParam(5) = Year(dtmFechaContable)
            'correlativo del aporte
            strQuery = _
                "Select Max(correlativo)+1 " _
                & "From Aporte " _
                & "Where agno = [5] "
            arrParam(6) = ValorSql(SqlParam(strQuery, arrParam))
            If IsDBNull(arrParam(6)) Then arrParam(6) = 1 'si no existe
            arrParam(7) = FechaVbABd(dtmFechaContable)
            arrParam(8) = lngMontoNeto
            arrParam(9) = lngMontoAdm
            arrParam(10) = StringSql(strNroDoc)
            arrParam(11) = StringSql(strBanco)
            arrParam(12) = FechaVbABd(dtmFechaVenc)
            arrParam(13) = FechaVbABd(dtmFechaCobro)
            arrParam(14) = lngNumAporte
            arrParam(15) = StringSql(strObs)


            strQuery = _
                "Insert Into Aporte(rut_cliente, cod_cuenta, cod_estado, cod_tipo_doc, cod_origen," _
                & "agno, correlativo, fecha, monto_neto, monto_adm, nro_documento, banco, " _
                & "fecha_venc_doc, fecha_cobro, num_aporte, observaciones) " _
                & "Values([0],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            'retorna el serial
            i_aporte = Serial("cod_aporte", "Aporte")
        End Function
        Public Function s_existe_cuenta_cliente(ByVal lngRutCliente As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutCliente
            strSql = _
              "select count(rut_cliente) from cuenta_cliente " _
              & "where rut_cliente=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_persona(ByVal lngRutCliente As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutCliente
            strSql = _
              "select count(rut) from persona " _
              & "where rut=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Function s_existe_persona_juridica(ByVal lngRutCliente As Long) As Boolean
            Dim arrParam(0)
            Dim strSql As String
            arrParam(0) = lngRutCliente
            strSql = _
              "select count(rut) from persona_juridica " _
              & "where rut=[0] "
            If ValorSql(SqlParam(strSql, arrParam)) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        'Inserci�n de datos en tabla franquicia
        Public Sub i_franquicia(ByVal lngRut As Long, _
                                ByVal intAgno As Integer, _
                                ByVal lngValor As Long)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intAgno
            arrParam(2) = lngValor

            strQuery = _
                "Insert Into Franquicia (rut, agno, valor)  " _
                & "Values([0], [1], [2])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub i_feriados(ByVal Fecha As Date, ByVal Motivo As String)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = FechaVbABd(Fecha)
            arrParam(1) = StringSql(Motivo)

            strQuery = _
                "Insert Into feriados (feriado, motivo)  " _
                & "Values([0], [1])"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
#End Region

#Region "UPDATE"
        ' Actualizar registro en franquicia
        Public Sub u_franquicia(ByVal lngRut As Long, _
                                ByVal intAgno As Integer, _
                                ByVal lngValor As Long)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intAgno
            arrParam(2) = lngValor

            strQuery = _
                "Update  franquicia Set " _
                & "valor = [2] " _
                & "Where Rut = [0] and agno=[1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_perfilUsuario(ByVal RutUsuario As Long, ByVal intCodPerfil As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodPerfil
            arrParam(1) = RutUsuario
            strQuery = _
                "update perfil_usuario Set " _
                & "cod_perfil = [0] " _
                & "where rut = [1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub

        Public Sub u_perfilObjeto(ByVal intCodPerfil As Integer, ByVal intCodObjeto As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodPerfil
            arrParam(1) = intCodObjeto
            strQuery = _
                "update perfil_objeto set " _
                & "cod_objeto = [1] " _
                & "Where cod_perfil = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            'Call EjecutarSql("Execute u_perfilObjeto " & intCodPerfil & ", " _
            '& intCodObjeto & "")
        End Sub
        'Actualiza los datos de una Persona Natural (curso interno)

        Public Sub u_pers_nat_interno(ByVal lngRut As Long, ByVal strApPaterno As String, _
                      ByVal strApMaterno As String, ByVal strNombre As String, _
                      ByVal strSexo As String, ByVal lngRutEmpresa As Long)

            Dim strQuery As String, arrParam(6)
            arrParam(0) = lngRut
            arrParam(1) = StringSql(strApPaterno)
            arrParam(2) = StringSql(strApMaterno)
            arrParam(3) = StringSql(strNombre)
            arrParam(4) = StringSql(strSexo)
            arrParam(5) = lngRutEmpresa

            strQuery = _
                    "Update Persona_Natural Set " _
                & "ap_paterno = [1], ap_materno = [2], " _
                & "nombre = [3], " _
                & "sexo = [4], " _
                & "rut_empresa = [5] " _
                & "Where rut = [0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        'Public Function u_curso_interno(ByVal lngCorrelativo As Long, _
        '                        ByVal lngRutCliente As Long, _
        '                        ByVal lngParticipantes As Long, _
        '                        ByVal strDireccionCurso As String, _
        '                        ByVal lngCodComuna As Long, _
        '                        ByVal dtmFechaInicio As String, _
        '                        ByVal dtmFechaTermino As String, _
        '                        ByVal lngValorCurso As Long, _
        '                        ByVal lngDescuento As Long, _
        '                        ByVal strCorrEmpresa As String, _
        '                        ByVal intIndDescPorc As Integer, _
        '                        ByVal strObservacion As String, _
        '                        ByVal intAgno As Integer, _
        '                        ByVal strNombreCurso As String, _
        '                        ByVal strEjecutor As String, _
        '                        ByVal strHorario As String, _
        '                        ByVal intHoras As Integer) As Long


        '    Dim strQuery As String, arrParam(16)


        '    arrParam(0) = lngRutCliente
        '    arrParam(1) = lngParticipantes
        '    arrParam(2) = StringSql(strDireccionCurso)
        '    arrParam(3) = lngCodComuna
        '    arrParam(4) = FechaVbABd(dtmFechaInicio)
        '    arrParam(5) = FechaVbABd(dtmFechaTermino)
        '    arrParam(6) = lngValorCurso
        '    arrParam(7) = lngDescuento
        '    arrParam(8) = StringSql(strCorrEmpresa)
        '    arrParam(9) = intIndDescPorc
        '    arrParam(10) = StringSql(strObservacion)
        '    arrParam(11) = intAgno
        '    arrParam(12) = StringSql(strNombreCurso)
        '    arrParam(13) = StringSql(strEjecutor)
        '    arrParam(14) = StringSql(strHorario)


        '    arrParam(15) = lngCorrelativo
        '    arrParam(16) = intHoras

        '    strQuery = "update Curso_Interno set rut = [0], num_participantes = [1], direccion = [2], " _
        '             & "cod_comuna = [3], inicio_curso = [4], fin_curso = [5], valor_curso = [6], descuento = [7], " _
        '             & "correlativo_empresa = [8], tipo_descuento_porcentaje = [9], observacion = [10], " _
        '             & "ano = [11], nombre_curso = [12], ejecutor = [13], horario = [14],horas_curso = [16] " _
        '             & "where correlativo = [15] and ano = [11] "


        '    Call EjecutarSql(SqlParam(strQuery, arrParam))
        'End Function
        Public Function u_curso_interno(ByVal lngCorrelativo As Long, _
                                ByVal lngRutCliente As Long, _
                                ByVal lngParticipantes As Long, _
                                ByVal strDireccionCurso As String, _
                                ByVal lngCodComuna As Long, _
                                ByVal dtmFechaInicio As String, _
                                ByVal dtmFechaTermino As String, _
                                ByVal lngValorCurso As Long, _
                                ByVal lngDescuento As Long, _
                                ByVal strCorrEmpresa As String, _
                                ByVal intIndDescPorc As Integer, _
                                ByVal strObservacion As String, _
                                ByVal intAgno As Integer, _
                                ByVal strNombreCurso As String, _
                                ByVal strEjecutor As String, _
                                ByVal strHorario As String, _
                                ByVal intHoras As Integer, _
                                ByVal lngTotalViatico As Long, _
                                ByVal lngTotalTraslado As Long) As Long


            Dim strQuery As String, arrParam(18)


            arrParam(0) = lngRutCliente
            arrParam(1) = lngParticipantes
            arrParam(2) = StringSql(strDireccionCurso)
            arrParam(3) = lngCodComuna
            arrParam(4) = FechaVbABd(dtmFechaInicio)
            arrParam(5) = FechaVbABd(dtmFechaTermino)
            arrParam(6) = lngValorCurso
            arrParam(7) = lngDescuento
            arrParam(8) = StringSql(strCorrEmpresa)
            arrParam(9) = intIndDescPorc
            arrParam(10) = StringSql(strObservacion)
            arrParam(11) = intAgno
            arrParam(12) = StringSql(strNombreCurso)
            arrParam(13) = StringSql(strEjecutor)
            arrParam(14) = StringSql(strHorario)
            arrParam(15) = lngCorrelativo
            arrParam(16) = intHoras
            arrParam(17) = lngTotalViatico
            arrParam(18) = lngTotalTraslado

            strQuery = "update Curso_Interno set rut = [0], num_participantes = [1], direccion = [2], " _
                     & "cod_comuna = [3], inicio_curso = [4], fin_curso = [5], valor_curso = [6], descuento = [7], " _
                     & "correlativo_empresa = [8], tipo_descuento_porcentaje = [9], observacion = [10], " _
                     & "ano = [11], nombre_curso = [12], ejecutor = [13], horario = [14],horas = [16], total_viatico = [17], total_traslado = [18] " _
                     & "where correlativo = [15] and ano = [11] "


            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        Public Sub u_encargado(ByVal lngRutEncargado As Long, _
                              ByVal strNombres As String, _
                              ByVal strApellido As String, _
                              ByVal strCargo As String, _
                              ByVal lngTelefono As String, _
                              ByVal strEmail As String)

            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngRutEncargado
            arrParam(1) = StringSql(strNombres)
            arrParam(2) = StringSql(strApellido)
            If strCargo = "" Then
                arrParam(3) = "NULL"
            Else
                arrParam(3) = StringSql(strCargo)
            End If
            If lngTelefono = "" Then
                arrParam(4) = "NULL"
            Else
                arrParam(4) = lngTelefono
            End If
            If strEmail = "" Then
                arrParam(5) = "NULL"
            Else
                arrParam(5) = StringSql(strEmail)
            End If

            strQuery = _
                "update encargado set nombre_encargado=[1], apellido_encargado=[2], cargo=[3], fono=[4], email=[5] where rut_encargado=[0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Sub u_encargado_empresa_por_rut(ByVal lngRutEncargado As Long, ByVal lngRutEmpresa As Long)
            Dim strQuery, arrparam(1) As String
            arrparam(0) = lngRutEncargado
            arrparam(1) = lngRutEmpresa
            strQuery = _
                "update encargado_empresa " _
                & "set rut_empresa=[1] where rut_encargado=[0]"
            Call EjecutarSql(SqlParam(strQuery, arrparam))
        End Sub
        Sub u_usuario(ByVal lngRutUsuario As Long, _
                              ByVal strNombres As String, _
                              ByVal strClave As String, _
                              ByVal strEmail As String, _
                              ByVal strTelefono As String, _
                              ByVal strFax As String)

            Dim strQuery, updateClave As String, arrParam(5)
            arrParam(0) = lngRutUsuario
            arrParam(1) = StringSql(strNombres)
            arrParam(2) = StringSql(strClave)
            arrParam(3) = StringSql(strEmail)
            arrParam(4) = StringSql(strTelefono)
            arrParam(5) = StringSql(strFax)

            If strClave.Trim <> "" Then
                updateClave = " passwd_enc=[2],"
            End If

            strQuery = "Update Usuario Set " _
                           & updateClave _
                           & " nombres=[1]," _
                           & " email=[3]," _
                           & " telefono=[4]," _
                           & " fax=[5] " _
                           & " Where rut=[0]"

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Cambia el estado de un aporte a anulado
        Public Sub u_cambio_estado_curso_interno(ByVal lngCodCurso As Long, ByVal intAgno As Integer, _
                                                ByVal intCodEstado As Integer)
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodCurso
            arrParam(1) = intAgno
            arrParam(2) = intCodEstado

            strQuery = _
                    "Update curso_interno Set " _
                    & "cod_estado_curso_interno = [2] " _
                    & "Where correlativo = [0] " _
                    & "And ano = [1] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza el n�mero de transacci�n de la solicitud de pago de terceros
        Public Sub u_nro_trans_solicitud_pago_ter(ByVal lngCodSolicitud As Long, _
                                        ByVal lngNroTransaccion As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodSolicitud
            arrParam(1) = lngNroTransaccion
            If lngNroTransaccion <> -1 Then
                strQuery = _
                        "Update solicitud_pago_terceros Set " _
                        & "nro_transaccion = [1] " _
                        & "Where cod_solicitud_pago = [0]"
            Else
                strQuery = _
                            "Update solicitud_pago_terceros Set " _
                            & "nro_transaccion = Null " _
                            & "Where cod_solicitud_pago = [0]"
            End If
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub

        'Actualiza el estado de un Curso Contratado
        Public Sub u_estado_curso(ByVal lngCodCurso As Long, ByVal intEstadoCurso As Integer)

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = intEstadoCurso

            strQuery = _
                    "Update Curso_Contratado Set " _
                    & "cod_estado_curso = [1], fecha_modificacion =  GETDATE() " _
                    & "Where cod_curso = [0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza el estado de un Curso Contratado si la asistencia es menor a 75 %
        Public Sub u_estado_curso_por_asitencia(ByVal lngCodCurso As Long, ByVal intEstadoCurso As Integer)

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = intEstadoCurso

            strQuery = _
                    "Update Curso_Contratado Set " _
                    & "cod_estado_curso = [1], costo_otic = 0, gasto_empresa = costo_otic+gasto_empresa " _
                    & "Where cod_curso = [0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza el estado de un Curso Contratado
        Public Sub u_estado_curso_masivo(ByVal strCodCurso As Long, ByVal intEstadoCurso As Integer)

            Dim strQuery As String, arrParam(1)
            arrParam(0) = strCodCurso
            arrParam(1) = intEstadoCurso

            strQuery = _
                    "Update Curso_Contratado Set " _
                    & "cod_estado_curso = [1] " _
                    & "Where cod_curso IN ([0]) "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Modifica el monto de administraci�n de la solicitud de pago a terceros
        Public Sub u_monto_adm_sol(ByVal lngCodCurso As Long, _
                                   ByVal lngRutBenefactor As Long, _
                                   ByVal lngMontoAdm As Long)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutBenefactor
            arrParam(2) = lngMontoAdm
            strQuery = _
                    "Update Solicitud_Pago_Terceros Set " _
                    & "monto_adm = [2] " _
                    & "Where cod_curso = [0] And rut_benefactor = [1]"

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        ' Actualizar registro en Rubro
        Public Sub u_Rubro(ByVal lngCodigo As Long, ByVal strNombre As String)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodigo
            arrParam(1) = StringSql(strNombre)
            strQuery = _
                "Update  Rubro Set " _
                & "nombre = [1] " _
                & "Where cod_rubro = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza el estado de una solicitud de pago de terceros
        Public Sub u_estado_sol_pago_ter(ByVal lngCodCurso As Long, _
                                         ByVal intEstadoSol As Integer, _
                                         ByVal lngRutBenefactor As Long)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodCurso
            arrParam(1) = intEstadoSol
            arrParam(2) = lngRutBenefactor
            strQuery = _
                    "Update Solicitud_Pago_Terceros Set " _
                    & "cod_estado_solicitud = [1] " _
                    & "Where cod_curso = [0] And rut_benefactor = [2]"

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        Public Sub u_sol_pago_ter(ByVal lngRutBenefactor As Long, ByVal lngCodCurso As Long, _
                           ByVal lngMonto As Long, ByVal lngNroTrans As Long, _
                           ByVal intCodSolicitud As Integer, ByVal lngMontoAdm As Long, _
                           ByVal intCodEstadoSolicitud As Integer)

            Dim strQuery As String, arrParam(7)
            arrParam(0) = lngRutBenefactor
            arrParam(1) = lngCodCurso
            arrParam(2) = lngMonto
            arrParam(3) = intCodEstadoSolicitud
            If lngNroTrans > 0 Then
                arrParam(4) = lngNroTrans
            Else
                arrParam(4) = "Null"
            End If
            arrParam(5) = 1
            arrParam(6) = intCodSolicitud
            arrParam(7) = lngMontoAdm
            strQuery = _
                    "Update Solicitud_Pago_Terceros " _
                    & "Set rut_benefactor=[0], cod_curso=[1], monto=[2], nro_transaccion=[4], cod_estado_solicitud=[3], monto_adm = [7] " _
                    & "Where cod_solicitud_pago = [6]"

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_Empresa_Cliente(ByVal lngRut As Long, ByVal dblCostoAdm As Double, _
                             ByVal intCompAdmNoLineal As Double, ByVal lngCodRubro As Long, _
                             ByVal lngNumempleados As Long, _
                             ByVal strContacto As String, _
                             ByVal strCargo As String, ByVal strFonoContacto As String, _
                             ByVal strAnexoContacto As String, ByVal strEmailContacto As String, _
                             ByVal strRep1 As String, ByVal lngRutRep1 As Long, _
                             ByVal strDigitoRep1 As String, ByVal strRep2 As String, _
                             ByVal lngRutRep2 As Long, ByVal strDigitoRep2 As String, _
                             ByVal strGerenteGral As String, ByVal strGerenteRRHH As String, _
                             ByVal strAreaCobranzas As String, ByVal strGiro As String, _
                             ByVal strCodActEconomica As String, ByVal intCodEstadoCliente As Integer, _
                             ByVal intCodSucursal As Integer, ByVal lngVentaAnual As Long, _
                             ByVal strEmailGteRRHH As String, _
                             ByVal strGerenteFinanzas As String, ByVal strEmailGteFinanzas As String, _
                             ByVal strFonoCobranzas As String, ByVal lngRutHolding As Long, _
                             ByVal strClaveWebService As String, ByVal strEtiquetaClasificador As String, ByVal strObservacion As String, _
                             ByVal lngRutContacto As Long, ByVal strApellidoContacto As String)



            Dim strQuery As String, arrParam(33)
            arrParam(0) = lngRut
            If dblCostoAdm >= 0 And dblCostoAdm <= 1 Then
                arrParam(1) = DoubleVbABd(dblCostoAdm)
            Else
                arrParam(1) = DoubleVbABd(dblCostoAdm / 100)
            End If
            arrParam(2) = intCompAdmNoLineal
            arrParam(3) = lngCodRubro
            If lngNumempleados = -1 Then
                arrParam(4) = "Null"
            Else
                arrParam(4) = lngNumempleados
            End If

            If strContacto = "" Then
                arrParam(5) = "Null"
            Else
                arrParam(5) = StringSql(strContacto)
            End If
            If strCargo = "" Then
                arrParam(6) = "Null"
            Else
                arrParam(6) = StringSql(strCargo)
            End If
            If strFonoContacto = "" Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = StringSql(strFonoContacto)
            End If
            If strAnexoContacto = "" Then
                arrParam(8) = "Null"
            Else
                arrParam(8) = StringSql(strAnexoContacto)
            End If
            If strEmailContacto = "" Then
                arrParam(9) = "Null"
            Else
                arrParam(9) = StringSql(strEmailContacto)
            End If
            If strRep1 = "" Then
                arrParam(10) = "Null"
            Else
                arrParam(10) = StringSql(strRep1)
            End If
            If lngRutRep1 = -1 Then
                arrParam(11) = "Null"
            Else
                arrParam(11) = lngRutRep1
            End If
            If strDigitoRep1 = "" Then
                arrParam(12) = "Null"
            Else
                arrParam(12) = StringSql(strDigitoRep1)
            End If
            If strRep2 = "" Then
                arrParam(13) = "Null"
            Else
                arrParam(13) = StringSql(strRep2)
            End If
            If lngRutRep2 = -1 Then
                arrParam(14) = "Null"
            Else
                arrParam(14) = lngRutRep2
            End If
            If strDigitoRep2 = "" Then
                arrParam(15) = "Null"
            Else
                arrParam(15) = StringSql(strDigitoRep2)
            End If
            If strGerenteGral = "" Then
                arrParam(16) = "Null"
            Else
                arrParam(16) = StringSql(strGerenteGral)
            End If
            If strGerenteRRHH = "" Then
                arrParam(17) = "Null"
            Else
                arrParam(17) = StringSql(strGerenteRRHH)
            End If
            If strAreaCobranzas = "" Then
                arrParam(18) = "Null"
            Else
                arrParam(18) = StringSql(strAreaCobranzas)
            End If
            If strGiro = "" Then
                arrParam(19) = "Null"
            Else
                arrParam(19) = StringSql(strGiro)
            End If
            If strCodActEconomica = "" Then
                arrParam(20) = "Null"
            Else
                arrParam(20) = StringSql(strCodActEconomica)
            End If
            arrParam(21) = intCodEstadoCliente

            arrParam(22) = intCodSucursal
            arrParam(23) = lngVentaAnual


            'Email Gerente Recursos Humanos
            If strEmailGteRRHH = "" Then
                arrParam(24) = "Null"
            Else
                arrParam(24) = StringSql(strEmailGteRRHH)
            End If

            'Nombre Gerente Finanzas
            If strGerenteFinanzas = "" Then
                arrParam(25) = "Null"
            Else
                arrParam(25) = StringSql(strGerenteFinanzas)
            End If

            'Email Gerente Finanzas
            If strEmailGteFinanzas = "" Then
                arrParam(26) = "Null"
            Else
                arrParam(26) = StringSql(strEmailGteFinanzas)
            End If

            'Fono Cobranzas
            If strFonoCobranzas = "" Then
                arrParam(27) = "Null"
            Else
                arrParam(27) = StringSql(strFonoCobranzas)
            End If

            If lngRutHolding = -1 Then
                arrParam(28) = "Null"
            Else
                arrParam(28) = lngRutHolding
            End If
            If strClaveWebService = "" Then
                arrParam(29) = "Null"
            Else
                arrParam(29) = StringSql(EncryptINI$(strClaveWebService))
            End If
            If strEtiquetaClasificador = "" Then
                arrParam(30) = "Null"
            Else
                arrParam(30) = StringSql(strEtiquetaClasificador)
            End If
            If strObservacion = "" Then
                arrParam(31) = "Null"
            Else
                arrParam(31) = StringSql(strObservacion)
            End If

            arrParam(32) = lngRutContacto
            arrParam(33) = StringSql(strApellidoContacto)

            strQuery = _
                "Update Empresa_Cliente set " _
                & "costo_admin = [1] ,comp_adm_no_lineal=[2], cod_rubro = [3], " _
                & "num_empleados = [4] , " _
                & "nom_contacto = [5] , cargo_contacto = [6] , " _
                & "fono_contacto = [7] ,anexo_contacto=[8], email_contacto = [9]," _
                & "nom_rep1= [10],rut_rep1=[11] ,dig_verif_rep1=[12],nom_rep2=[13]," _
                & "rut_rep2=[14],dig_verif_rep2=[15],gerente_general=[16]," _
                & "gerente_rrhh=[17],area_cobranzas=[18],giro=[19],cod_act_economica=[20]," _
                & "cod_estado_cliente = [21],cod_sucursal=[22],ventas_anuales=[23], " _
                & "email_gerente_rrhh =[24],gerente_finanzas = [25], " _
                & "email_gerente_finanzas = [26], fono_cobranzas = [27], rut_holding = [28],  " _
                & "rut_contacto = [32], apellido_contacto = [33]" _
                & "where rut = [0]"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza los datos de la base de datos de sql
        'con los datos existentes en la base de datos cursos.mdb de access
        Public Sub u_Cursos(ByVal strCodigoSence As String, _
                            ByVal strCurso As String, _
                            ByVal intRutOtec As Long, _
                            ByVal strArea As String, _
                            ByVal strEspecialidad As String, _
                            ByVal intDur_cur_teorico As Long, _
                            ByVal intDur_cur_practico As Long, _
                            ByVal intNum_max_part As Integer, _
                            ByVal strNombre_Sede As String, _
                            ByVal strFono_Sede As String, _
                            ByVal strDireccion As String, _
                            ByVal lngCodComuna As Long, _
                            ByVal bPendiente As Byte, _
                            ByVal lngValorCurso As Long, _
                            ByVal blnElearning As Boolean, _
                            ByVal intCodModalidad As Integer, _
                            ByVal intDur_cur_elearning As Long, _
                            Optional ByVal dblValorHora As Double = 0.0)

            Dim strQuery As String, arrParam(17)
            arrParam(0) = StringSql(strCodigoSence)
            arrParam(1) = StringSql(strCurso)
            arrParam(2) = intRutOtec
            arrParam(3) = StringSql(strArea)
            arrParam(4) = StringSql(strEspecialidad)
            arrParam(5) = intDur_cur_teorico
            arrParam(6) = intDur_cur_practico
            arrParam(7) = intNum_max_part
            arrParam(8) = StringSql(strNombre_Sede)
            arrParam(9) = StringSql(strFono_Sede)
            arrParam(10) = StringSql(strDireccion)
            arrParam(11) = lngCodComuna
            arrParam(12) = bPendiente
            arrParam(13) = lngValorCurso
            arrParam(14) = BooleanVbAbd(blnElearning)
            arrParam(15) = DoubleVbABd(dblValorHora)
            arrParam(16) = intCodModalidad
            arrParam(17) = intDur_cur_elearning

            Dim strUpValorHora As String = ""
            If dblValorHora > 0.0 Then
                strUpValorHora = " , valor_hora = [15] "
            End If

            strQuery = _
                "Update Curso set " _
                & "nombre = [1] , rut_otec = [2], " _
                & "area = [3] , especialidad = [4] , " _
                & "dur_cur_teorico = [5] , dur_cur_prac = [6] , " _
                & "num_max_part = [7] , nombre_sede = [8] , " _
                & "fono_sede = [9] , direccion = [10] , " _
                & "cod_comuna = [11] , pendiente = [12],valor_curso=[13], " _
                & "cod_modalidad = [16], dur_cur_elearning = [17] " _
                & strUpValorHora _
                & "where codigo_sence = [0]"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        ' Actualizar registro en factura
        Public Sub u_factura(ByVal lngCodCurso As Long, _
                             ByVal intCodEstadoFactura As Integer, _
                             ByVal lngNumFactura As Long, _
                             ByVal dtmFecha As Date, _
                             ByVal dtmFechaRecepcion As Date, _
                             ByVal dtmFechaPago As Date, _
                             ByVal lngMonto As Long, _
                             ByVal lngNumVoucher As Long, _
                             ByVal strObservacion As String)

            Dim strQuery As String, arrParam(8)
            arrParam(0) = lngCodCurso
            arrParam(1) = intCodEstadoFactura
            arrParam(2) = lngNumFactura
            arrParam(3) = FechaVbABd(dtmFecha)
            arrParam(4) = FechaVbABd(dtmFechaRecepcion)
            arrParam(5) = FechaVbABd(dtmFechaPago)
            arrParam(6) = lngMonto
            If lngNumVoucher = 0 Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = lngNumVoucher
            End If
            If strObservacion = "" Then
                arrParam(8) = "Null"
            Else
                arrParam(8) = StringSql(strObservacion)
            End If


            strQuery = _
                "Update factura Set " _
                & "cod_estado_fact = [1], num_factura = [2], fecha = [3], fecha_recepcion = [4], fecha_pago = [5], " _
                & "monto = [6], num_voucher = [7], observacion = [8] " _
                & "Where cod_curso = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_Otec(ByVal lngRut As Long, ByVal strContacto As String, _
                  ByVal strCargo As String, ByVal strFonoContacto As String, _
                  ByVal strEmailContacto As String, ByVal strFaxContacto As String, _
                  ByVal intCodRubro As Integer, ByVal strRep1 As String, _
                  ByVal lngRutRep1 As Long, ByVal strDigitoRep1 As String, _
                  ByVal strRep2 As String, ByVal lngRutRep2 As Long, _
                  ByVal strDigitoRep2 As String, ByVal strgtegeneral As String, _
                  ByVal strgteRRHH As String, ByVal strAreaCobranzas As String, _
                  ByVal strGiro As String, ByVal strCodActEco As String, _
                  ByVal lngNumConvenio As Long, ByVal dblTasaDescuento As Double)


            Dim strQuery As String, arrParam(19)
            arrParam(0) = lngRut

            If strContacto = "" Then
                arrParam(1) = "Null"
            Else
                arrParam(1) = StringSql(strContacto)
            End If
            If strCargo = "" Then
                arrParam(2) = "Null"
            Else
                arrParam(2) = StringSql(strCargo)
            End If
            If strFonoContacto = "" Then
                arrParam(3) = "Null"
            Else
                arrParam(3) = StringSql(strFonoContacto)
            End If
            If strEmailContacto = "" Then
                arrParam(4) = "Null"
            Else
                arrParam(4) = StringSql(strEmailContacto)
            End If
            If strFaxContacto = "" Then
                arrParam(5) = "Null"
            Else
                arrParam(5) = StringSql(strFaxContacto)
            End If
            arrParam(6) = intCodRubro

            If strRep1 = "" Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = StringSql(strRep1)
            End If
            If lngRutRep1 = -1 Then
                arrParam(8) = "Null"
            Else
                arrParam(8) = lngRutRep1
            End If
            If strDigitoRep1 = "" Then
                arrParam(9) = "Null"
            Else
                arrParam(9) = StringSql(strDigitoRep1)
            End If
            If strRep2 = "" Then
                arrParam(10) = "Null"
            Else
                arrParam(10) = StringSql(strRep2)
            End If
            If lngRutRep2 = -1 Then
                arrParam(11) = "Null"
            Else
                arrParam(11) = lngRutRep2
            End If
            If strDigitoRep2 = "" Then
                arrParam(12) = "Null"
            Else
                arrParam(12) = StringSql(strDigitoRep2)
            End If
            If strgtegeneral = "" Then
                arrParam(13) = "Null"
            Else
                arrParam(13) = StringSql(strgtegeneral)
            End If
            If strgteRRHH = "" Then
                arrParam(14) = "Null"
            Else
                arrParam(14) = StringSql(strgteRRHH)
            End If
            If strAreaCobranzas = "" Then
                arrParam(15) = "Null"
            Else
                arrParam(15) = StringSql(strAreaCobranzas)
            End If
            If strGiro = "" Then
                arrParam(16) = "Null"
            Else
                arrParam(16) = StringSql(strGiro)
            End If
            If strCodActEco = "" Then
                arrParam(17) = "Null"
            Else
                arrParam(17) = StringSql(strCodActEco)
            End If
            If lngRutRep2 = -1 Then
                arrParam(11) = "Null"
            Else
                arrParam(11) = lngRutRep2
            End If
            If lngNumConvenio = -1 Then
                arrParam(18) = "Null"
            Else
                arrParam(18) = lngNumConvenio
            End If
            arrParam(19) = dblTasaDescuento

            strQuery = _
                "Update Otec set " _
                & "nombre_contacto = [1] ,cargo_contacto=[2], fono_contacto = [3], " _
                & "email_contacto = [4] ,fax_contacto = [5],cod_rubro = [6], " _
                & "nom_rep1 = [7] ,rut_rep1 = [8],dig_verif_rep1 = [9], " _
                & "nom_rep2 = [10] ,rut_rep2 = [11],dig_verif_rep2 = [12], " _
                & "gerente_general=[13],gerente_rrhh=[14],area_cobranzas=[15] , " _
                & "giro=[16],cod_act_economica=[17],num_convenio=[18], " _
                & "tasa_descuento = [19] " _
                & " where rut = [0]"
            Call EjecutarSql(SqlParam(strQuery, arrParam))


        End Sub
        'Actualiza los datos de la base de datos de sql
        'con los datos existentes en la base de datos otec.mdb de access
        Public Sub u_Persona_Juridica(ByVal lngRutOtec As Long, _
                            ByVal strNomFantasia As String, _
                            ByVal strNombreOtec As String, _
                            ByVal strSigla As String, _
                            ByVal strEmailOtec As String, _
                            ByVal strFono As String, _
                            ByVal strFono2 As Object, _
                            ByVal strFax As Object, _
                            ByVal strDireccion As String, _
                            ByVal lngCodComuna As Long, _
                            ByVal strCasilla As Object, _
                            ByVal strSitioWeb As String, _
                            ByVal strCiudad As String, _
                            ByVal strNroDireccion As String)

            Dim strQuery As String, arrParam(13)
            arrParam(0) = lngRutOtec
            arrParam(1) = StringSql(strNomFantasia)
            arrParam(2) = StringSql(strNombreOtec)
            arrParam(3) = StringSql(strSigla)
            arrParam(4) = StringSql(strEmailOtec)
            arrParam(5) = StringSql(strFono)

            If strFono2 = "" Then
                arrParam(6) = "Null"
            Else
                arrParam(6) = StringSql(strFono2)
            End If

            If strFax = "" Then
                arrParam(7) = "Null"
            Else
                arrParam(7) = StringSql(strFax)
            End If
            arrParam(8) = StringSql(strDireccion)
            arrParam(9) = lngCodComuna
            If strCasilla = "" Then
                arrParam(10) = "Null"
            Else
                arrParam(10) = StringSql(strCasilla)
            End If
            If strSitioWeb = "" Then
                arrParam(11) = "Null"
            Else
                arrParam(11) = StringSql(strSitioWeb)
            End If
            arrParam(12) = StringSql(strCiudad)
            arrParam(13) = StringSql(strNroDireccion)

            strQuery = _
                "Update Persona_Juridica set " _
                & "nom_fantasia = [1] ,razon_social=[2], sigla = [3], email=[4]," _
                & "fono = [5] ,fono2=[6] ," _
                & "fax = [7] , direccion = [8] , " _
                & "cod_comuna = [9] ,casilla=[10],SitioWeb= [11], " _
                & "ciudad = [12], nro_direccion = [13] " _
                & "where rut = [0]"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza el n�mero de transacci�n de la solicitud de pago de terceros
        Public Sub u_nro_trans_solicitud_pago_ter1(ByVal lngCodCurso As Long, _
                                                   ByVal lngRutBenefactor As Long, _
                                                   ByVal lngNroTransaccion As Long)
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutBenefactor
            arrParam(2) = lngNroTransaccion
            If lngNroTransaccion <> -1 Then
                strQuery = _
                        "Update solicitud_pago_terceros Set " _
                        & "nro_transaccion = [2] " _
                        & "Where cod_curso = [0] " _
                        & "And rut_benefactor = [1]"
            Else
                strQuery = _
                            "Update solicitud_pago_terceros Set " _
                            & "nro_transaccion = Null " _
                            & "Where cod_curso = [0] " _
                            & "And rut_benefactor = [1]"
            End If
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza Saldo Actual de una de las Cuentas de un Cliente
        Public Sub u_SaldoCuentaCliente(ByVal lngRut As Long, _
                                        ByVal intCodCuenta As Integer, _
                                        ByVal lngSaldoActual As Long)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = lngSaldoActual

            strQuery = _
                    "Update Cuenta_Cliente Set " _
                    & "saldo = [2] " _
                    & "Where rut_cliente = [0] And cod_cuenta = [1] "

            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_SaldoCuentaCliente2(ByVal lngRut As Long, _
                                        ByVal intCodCuenta As Integer, _
                                       ByVal lngSaldoActual As Long)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngRut
            arrParam(1) = intCodCuenta
            arrParam(2) = lngSaldoActual

            strQuery = _
                    "Update Cuenta_Cliente Set " _
                    & "saldo = [2] " _
                    & "Where rut_cliente = [0] And cod_cuenta = [1] "

            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_participante(ByVal lngCodCurso As Long, ByVal lngRutAlumno As Long, _
                                  ByVal intCodNivelOcup As Integer, ByVal intCodRegion As Integer, _
                                  ByVal dblPorcFranquicia As Double, ByVal lngViatico As Long, _
                                  ByVal lngTraslado As Long, ByVal dblPorcAsistencia As Double, _
                                  ByVal strObservaciones As String, ByVal intCodNivelEduc As Integer, _
                                  ByVal lngCodComuna As Long, Optional ByVal CodigoClasificador As String = "")

            Dim strQuery As String, arrParam(11)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutAlumno
            arrParam(2) = intCodNivelOcup
            arrParam(3) = intCodRegion
            If dblPorcFranquicia >= 0 And dblPorcFranquicia <= 1 Then
                arrParam(4) = DoubleVbABd(dblPorcFranquicia)
            Else
                arrParam(4) = DoubleVbABd(dblPorcFranquicia / 100)
            End If
            arrParam(5) = lngViatico
            arrParam(6) = lngTraslado
            If dblPorcAsistencia >= 0 And dblPorcAsistencia <= 1 Then
                arrParam(7) = DoubleVbABd(dblPorcAsistencia)
            Else
                arrParam(7) = DoubleVbABd(dblPorcAsistencia / 100)
            End If
            arrParam(8) = StringSql(strObservaciones)
            arrParam(9) = intCodNivelEduc
            arrParam(10) = lngCodComuna
            Dim str As String = ""
            If CodigoClasificador <> "" Then
                arrParam(11) = StringSql(CodigoClasificador)
                str = str & ", cod_clasificador=[11] "
            End If

            strQuery = _
                    "Update Participante Set " _
                & "cod_nivel_ocup = [2], cod_region = [3], " _
                & "porc_franquicia = [4], viatico = [5], " _
                & "traslado = [6], porc_asistencia = [7], " _
                & "observaciones = [8], cod_nivel_educ = [9], " _
                & "cod_comuna = [10] " _
                & str _
                & "Where cod_curso = [0] And rut_alumno = [1] "

            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Modifica el monto de la tabla becas
        Public Sub u_monto_beca(ByVal lngRutCliente As Long, ByVal intAgno As Integer, _
                ByVal lngBecas As Long, ByVal lngAdmAsign As Long)

            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRutCliente
            arrParam(1) = intAgno
            arrParam(2) = lngBecas
            arrParam(3) = lngAdmAsign
            strQuery = _
                "Update Asignacion_Exced Set " _
                & "becas = [2], " _
                & "adm_asignacion = [3] " _
                & "Where rut = [0] And agno = [1]"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_pers_nat(ByVal lngRut As Long, ByVal strApPaterno As String, _
                      ByVal strApMaterno As String, ByVal strNombre As String, _
                      ByVal dtmFechaNacimiento As String, ByVal strSexo As String, _
                      ByVal dblPorcFranquicia As Double, ByVal intCodNivelOcup As Integer, _
                      ByVal intCodNivelEduc As Integer, ByVal intCodRegion As Integer, _
                      ByVal lngRutEmpresa As Long, ByVal lngCodComuna As Long, _
                           ByVal lngCodPais As Long, _
                            ByVal strFono As String, _
                             ByVal strEmail As String)

            Dim strQuery As String, arrParam(14)
            arrParam(0) = lngRut
            arrParam(1) = StringSql(strApPaterno)
            arrParam(2) = StringSql(strApMaterno)
            arrParam(3) = StringSql(strNombre)
            arrParam(4) = FechaVbABd(FechaUsrAVb(dtmFechaNacimiento))
            arrParam(5) = StringSql(strSexo)
            If dblPorcFranquicia >= 0 And dblPorcFranquicia <= 1 Then
                arrParam(6) = DoubleVbABd(dblPorcFranquicia)
            Else
                arrParam(6) = DoubleVbABd(dblPorcFranquicia / 100)
            End If
            arrParam(7) = intCodNivelOcup
            arrParam(8) = intCodNivelEduc
            arrParam(9) = intCodRegion
            arrParam(10) = lngRutEmpresa
            arrParam(11) = lngCodComuna
            arrParam(12) = lngCodPais
            If strFono = "" Then
                arrParam(13) = "NULL"
            Else
                arrParam(13) = StringSql(strFono)
            End If
            If strEmail = "" Then
                arrParam(14) = "NULL"
            Else
                arrParam(14) = StringSql(strEmail)
            End If
            strQuery = _
                    "Update Persona_Natural Set " _
                & "ap_paterno = [1], ap_materno = [2], " _
                & "nombre = [3], fecha_nacim = [4], " _
                & "sexo = [5], porc_franquicia = [6], " _
                & "cod_nivel_ocup = [7], cod_nivel_educ = [8], " _
                & "cod_region = [9], rut_empresa = [10], " _
                & "cod_comuna = [11], cod_pais = [12], fono = [13], email = [14] " _
                & "Where rut = [0] "

            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_pers_nat2(ByVal lngRut As Long, ByVal strApPaterno As String, _
                              ByVal strApMaterno As String, ByVal strNombre As String, _
                              ByVal dtmFechaNacimiento As String, ByVal strSexo As String, _
                              ByVal dblPorcFranquicia As Double, ByVal intCodNivelOcup As Integer, _
                              ByVal intCodNivelEduc As Integer, ByVal intCodRegion As Integer, _
                              ByVal lngRutEmpresa As Long, ByVal lngCodComuna As Long, _
                              ByVal lngCodPais As Long, _
                              ByVal strFono As String, _
                              ByVal strEmail As String)

            Dim strQuery As String, arrParam(14)
            arrParam(0) = lngRut
            arrParam(1) = StringSql(strApPaterno)
            arrParam(2) = StringSql(strApMaterno)
            arrParam(3) = StringSql(strNombre)
            arrParam(4) = FechaVbABd(FechaUsrAVb(dtmFechaNacimiento))
            arrParam(5) = StringSql(strSexo)
            'If dblPorcFranquicia >= 0 And dblPorcFranquicia <= 1 Then
            arrParam(6) = DoubleVbABd(dblPorcFranquicia)
            'Else
            'arrParam(6) = DoubleVbABd(dblPorcFranquicia / 100)
            'End If
            arrParam(7) = intCodNivelOcup
            arrParam(8) = intCodNivelEduc
            arrParam(9) = intCodRegion
            arrParam(10) = lngRutEmpresa
            arrParam(11) = lngCodComuna
            arrParam(12) = lngCodPais
            If strFono = "" Then
                arrParam(13) = "NULL"
            Else
                arrParam(13) = StringSql(strFono)
            End If
            If strEmail = "" Then
                arrParam(14) = "NULL"
            Else
                arrParam(14) = StringSql(strEmail)
            End If
            strQuery = _
                    "Update Persona_Natural Set " _
                & "ap_paterno = [1], ap_materno = [2], " _
                & "nombre = [3], fecha_nacim = [4], " _
                & "sexo = [5], porc_franquicia = [6], " _
                & "cod_nivel_ocup = [7], cod_nivel_educ = [8], " _
                & "cod_region = [9], rut_empresa = [10], " _
                & "cod_comuna = [11], cod_pais = [12], fono = [13], email = [14] " _
                & "Where rut = [0] "

            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza un curso contratado en la BD.
        Public Sub u_curso_contr(ByVal lngRutCliente As Long, ByVal intCodTipoActiv As Integer, _
                                 ByVal bolIndAcuComBip As Boolean, ByVal bolIndDetNece As Boolean, _
                                 ByVal lngParticipantes As Long, ByVal strDireccionCurso As String, _
                                 ByVal lngCodComuna As Long, ByVal strCodSence As String, _
                                 ByVal dtmFechaInicio As Date, ByVal dtmFechaTermino As Date, _
                                 ByVal lngHorasCompl As Double, ByVal lngValorMercado As Long, _
                                 ByVal lngDescuento As Long, ByVal lngCorrelativo As Long, _
                                 ByVal lngNroRegistro As Long, ByVal lngAgno As Long, _
                                 ByVal dblPorcAdm As Double, ByVal lngCostoOtic As Long, _
                                 ByVal lngCostoAdm As Long, ByVal lngGastoEmpresa As Long, _
                                 ByVal lngCostoOticVYT As Long, ByVal lngCostoAdmVYT As Long, _
                                 ByVal lngGastoEmpresaVYT As Long, _
                                 ByVal lngTotalViatico As Long, ByVal lngTotalTraslado As Long, _
                                 ByVal intCodAtributo As Integer, ByVal strObsCurso As String, _
                                 ByVal mlngValorComunicado As Long, ByVal strObsLiquidacion As String, _
                                 ByVal lngHoras As Double, ByVal intNroFacturaOtec As Integer, _
                                 ByVal dtmFechaPagoFactura As Date, ByVal lngCodCursoCompl As Object, _
                                 ByVal intIndDescPorc As Integer, ByVal strCorrEmpresa As String, _
                                 ByVal dtmFechaComunicacion As Date, ByVal dtmFechaLiquidacion As Date, _
                                 ByVal lngCodCurso As Long, ByVal strContactoAdicional As String, _
                                 ByVal strObservacion As String, ByVal lngCodModalidad As Long, _
                                 ByVal strNroDireccionCurso As String, ByVal strCiudad As String, Optional ByVal blnCursoCFT As Boolean = False, _
                                 Optional ByVal dblValorHora As Double = 0.0, Optional ByVal lngRutEncargado As Long = 0)


            Dim strQuery As String, arrParam(46)
            arrParam(0) = lngRutCliente
            arrParam(1) = intCodTipoActiv
            arrParam(2) = BooleanAspAbd(bolIndAcuComBip)
            arrParam(3) = BooleanAspAbd(bolIndDetNece)
            arrParam(4) = lngParticipantes
            arrParam(5) = StringSql(strDireccionCurso)
            arrParam(6) = lngCodComuna
            arrParam(7) = StringSql(strCodSence)
            arrParam(8) = FechaVbABd(dtmFechaInicio)
            arrParam(9) = FechaVbABd(dtmFechaTermino)
            arrParam(10) = DoubleVbABd(lngHorasCompl)
            arrParam(11) = lngValorMercado
            arrParam(12) = lngDescuento
            arrParam(13) = lngCorrelativo
            arrParam(14) = lngNroRegistro
            arrParam(15) = lngAgno
            If dblPorcAdm >= 0 And dblPorcAdm <= 1 Then
                arrParam(16) = DoubleVbABd(dblPorcAdm)
            Else
                arrParam(16) = DoubleVbABd(dblPorcAdm / 100)
            End If
            arrParam(17) = lngCostoOtic
            arrParam(18) = lngCostoAdm
            arrParam(19) = lngGastoEmpresa
            arrParam(20) = lngCostoOticVYT
            arrParam(21) = lngCostoAdmVYT
            arrParam(22) = lngGastoEmpresaVYT
            arrParam(23) = lngTotalViatico
            arrParam(24) = lngTotalTraslado
            arrParam(25) = intCodAtributo

            arrParam(26) = StringSql(strObsCurso)

            arrParam(27) = mlngValorComunicado

            arrParam(28) = StringSql(strObsLiquidacion)


            arrParam(29) = DoubleVbABd(lngHoras)
            arrParam(30) = intNroFacturaOtec

            arrParam(31) = FechaVbABd(dtmFechaPagoFactura)

            arrParam(32) = lngCodCursoCompl
            arrParam(33) = intIndDescPorc

            arrParam(34) = StringSql(strCorrEmpresa)


            arrParam(35) = FechaVbABd(Now.Date)

            arrParam(36) = FechaVbABd(dtmFechaComunicacion)


            arrParam(37) = FechaVbABd(dtmFechaLiquidacion)

            arrParam(38) = lngCodCurso
            arrParam(39) = StringSql(strContactoAdicional)
            arrParam(40) = StringSql(strObservacion)
            arrParam(41) = lngCodModalidad

            If (arrParam(13) = -1) Then
                arrParam(13) = "Null"
            End If
            If (arrParam(14) = -1) Then
                arrParam(14) = "Null"
            End If
            If (arrParam(30) = -1) Then
                arrParam(30) = "Null"
            End If
            If (arrParam(32) = -1) Then
                arrParam(32) = "Null"
            End If
            If (arrParam(34) = "") Then
                arrParam(34) = "Null"
            End If
            If (arrParam(41) <= 0) Then
                arrParam(41) = "Null"
            End If
            arrParam(42) = StringSql(strNroDireccionCurso)
            arrParam(43) = StringSql(strCiudad)
            arrParam(44) = DoubleVbABd(dblValorHora)
            arrParam(45) = BooleanVbAbd(blnCursoCFT)
            If lngRutEncargado = 0 Then
                arrParam(46) = "NULL"
            Else
                arrParam(46) = lngRutEncargado
            End If


            Dim strValorHora As String = ""
            If dblValorHora > 0.0 Then
                strValorHora = " , valor_hora = [44] "
            End If

            strQuery = _
                    "Update Curso_Contratado Set " _
                    & "rut_cliente = [0], cod_tipo_activ = [1], " _
                    & "ind_acu_com_bip = [2], ind_det_nece = [3], num_alumnos = [4], " _
                    & "direccion_curso = [5], cod_comuna = [6], " _
                    & "codigo_sence = [7], fecha_inicio = [8], " _
                    & "fecha_termino = [9], horas_compl = [10], " _
                    & "valor_mercado = [11], descuento = [12], " _
                    & "correlativo = [13], nro_registro = [14], " _
                    & "agno = [15], " _
                    & "porc_adm = [16], costo_otic = [17], " _
                    & "costo_adm = [18], gasto_empresa = [19], " _
                    & "costo_otic_vyt = [20], costo_adm_vyt = [21] , " _
                    & "gasto_empresa_vyt = [22], " _
                    & "total_viatico = [23], total_traslado = [24], " _
                    & "cod_origen = [25], obs_curso = [26], " _
                    & "costo_otic_comunicar = [27], obs_liquidacion = [28], " _
                    & "horas = [29], nro_factura_otec = [30], " _
                    & "fecha_pago_factura = [31], cod_curso_compl = [32], " _
                    & "ind_desc_porc = [33], correlativo_empresa = [34], fecha_modificacion = [35], " _
                    & "fecha_comunicacion = [36], fecha_liquidacion = [37],contacto_adicional= [39]  " _
                    & ", observacion = [40], cod_modalidad = [41],nro_direccion_curso = [42]," _
                    & "ciudad = [43], flag_curso_cft = [45], rut_encargado=[46] " _
                    & strValorHora _
                    & "Where cod_curso = [38] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_estado_transaccion2(ByVal lngCodCurso As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso
            strQuery = _
                "Update Transaccion Set " _
                & "cod_estado_tran = 2 " _
                & "Where nro_transaccion In (" _
                    & "Select Max(nro_transaccion) From transaccion " _
                    & "Where cod_curso = [0] " _
                    & "And cod_tipo_tran = 2 " _
                    & "Group By cod_cuenta, rut_cliente) " _
                & "And monto > 0 "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_clasificador(ByVal strCodigoClasificador As String, ByVal strNombre As String, _
                          ByVal lngRutEmpresa As Long)
            Dim strQuery As String, arrParam(2)
            arrParam(0) = StringSql(strCodigoClasificador)
            arrParam(1) = StringSql(strNombre)
            arrParam(2) = lngRutEmpresa

            strQuery = _
                "Update  clasificador  " _
                & "Set nombre = [1] " _
                & "Where cod_clasificador = [0] and rut = [2] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_valor_hora_sence2(ByVal intAgno As Integer, _
                                      ByVal lngValor As Long, _
                                      ByVal blnVigente As Boolean, _
                                      ByVal intCodModalidad As Integer, _
                                      ByVal strCodigoSence As String)

            Dim strQuery As String, arrParam(4)
            arrParam(0) = intAgno
            arrParam(1) = lngValor
            arrParam(2) = BooleanAspAbd(blnVigente)
            arrParam(3) = intCodModalidad
            arrParam(4) = StringSql(strCodigoSence)

            strQuery = _
                "Update valor_hora_sence Set " _
                & "valor = [1] , vigente=[2] , cod_modalidad = [3] " _
                & "Where agno = [0] and  codigo_sence = [4]"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Almacena el �ltimo estado de un curso por pasar a estado Pago por Autorizar (6)
        Public Sub u_ultimo_estado_curso(ByVal lngCodCurso As Long, ByVal intCodEstado As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = intCodEstado

            strQuery = _
                "Update curso_contratado  " _
                & "Set cod_ultimo_estado = [1] " _
                & "Where cod_curso = [0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Inserci�n datos de la base de datos otec.mdb de access
        'en tabla Persona de la base de datos de sql
        Public Sub u_Persona(ByVal intRut As Long, _
                             ByVal strDigito As String, _
                             ByVal strTipo As String)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = intRut
            arrParam(1) = StringSql(strDigito)
            arrParam(2) = StringSql(strTipo)

            strQuery = _
                "update Persona set tipo=[2] where rut=[0] "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Modifica el monto de una transaccion
        Public Sub u_monto_transaccion(ByVal lngNroTransaccion As Long, _
                                       ByVal lngMonto As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngNroTransaccion
            arrParam(1) = lngMonto
            strQuery = _
                "Update Transaccion " _
                & "Set monto = [1]" _
                & "Where nro_transaccion = [0]"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        ' Actualizar registro en valor_hora_sence
        Public Sub u_valor_hora_sence(ByVal intAgno As Integer, _
                                      ByVal lngValor As Long, _
                                      ByVal blnVigente As Boolean)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = intAgno
            arrParam(1) = lngValor
            arrParam(2) = BooleanAspAbd(blnVigente)

            strQuery = _
                "Update valor_hora_sence Set " _
                & "valor = [1] , vigente=[2] " _
                & "Where agno = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub

        Public Sub u_sucursal(ByVal intCodigo As Integer, ByVal strNombre As String)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodigo
            arrParam(1) = StringSql(strNombre)
            strQuery = _
                "Update Sucursal Set " _
                & "nombre = [1] " _
                & "Where cod_sucursal = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_PersonaNatural(ByVal lngRut As Long, _
                                   ByVal Strap_paterno As String, _
                                   ByVal Strap_Materno As String, _
                                   ByVal strNombre As String, _
                                   ByVal dtFechaNacim As String, _
                                   ByVal strSexo As String, _
                                   ByVal intporc_franquicias As Integer, _
                                   ByVal intCod_nivel_ocup As Integer, _
                                   ByVal intCod_nivel_educ As Integer, _
                                   ByVal intCod_Region As Long, _
                                   ByVal lngRut_Empresa As Long, _
                                   ByVal lngCodComuna As Long, _
                                   ByVal lngCodPais As Long, _
                                   ByVal strFono As String, _
                                   ByVal strEmail As String)

            Dim strQuery As String, arrParam(14)
            arrParam(0) = CLng(lngRut)
            arrParam(1) = StringSql(Strap_paterno)
            arrParam(2) = StringSql(Strap_Materno)
            arrParam(3) = StringSql(strNombre)
            arrParam(4) = FechaVbABd(FechaUsrAVb(dtFechaNacim))
            arrParam(5) = StringSql(strSexo)
            arrParam(6) = DoubleVbABd(CDbl((CInt(intporc_franquicias)) / 100))
            arrParam(7) = CInt(intCod_nivel_ocup)
            arrParam(8) = CInt(intCod_nivel_educ)
            arrParam(9) = CInt(intCod_Region)
            arrParam(10) = CLng(lngRut_Empresa)
            arrParam(11) = lngCodComuna
            arrParam(12) = lngCodPais
            If strFono = "" Then
                arrParam(13) = "NULL"
            Else
                arrParam(13) = StringSql(strFono)
            End If
            If strEmail = "" Then
                arrParam(14) = "NULL"
            Else
                arrParam(14) = StringSql(strEmail)
            End If
            strQuery = _
                "update Persona_Natural set ap_paterno=[1],ap_materno=[2],nombre=[3], " _
                & "fecha_nacim=[4], sexo=[5], porc_franquicia=[6], cod_nivel_ocup=[7], cod_nivel_educ=[8], " _
                & "cod_region=[9], rut_empresa=[10],cod_comuna=[11], cod_pais=[12], fono = [13], email=[14] where rut=[0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_participante_interno(ByVal lngCorrelativo As Long, _
                                   ByVal strObservacion As String, _
                                   ByVal intAgno As Integer, ByVal lngRut As Long, _
                                    ByVal lngViatico As Long, ByVal lngTraslado As Long, _
                                    ByVal intCodEstadoAprobado As Integer)

            Dim strQuery As String, arrParam(6)
            arrParam(0) = lngCorrelativo
            arrParam(1) = StringSql(strObservacion)
            arrParam(2) = intAgno
            arrParam(3) = lngRut
            arrParam(4) = lngViatico
            arrParam(5) = lngTraslado
            arrParam(6) = intCodEstadoAprobado

            strQuery = _
                    "Update participante_interno  " _
                    & "Set correlativo = [0], ano=[2], observacion = [1], viatico = [4], traslado = [5], cod_estado_part = [6] " _
                    & "Where rut = [3] and correlativo = [0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_vyt_curso_interno(ByVal lngCorrelativo As Long, ByVal intAgno As Integer, _
                                    ByVal lngViatico As Long, ByVal lngTraslado As Long)

            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno
            arrParam(2) = lngViatico
            arrParam(3) = lngTraslado

            strQuery = _
                    "Update curso_interno  " _
                    & "Set total_viatico = [2], total_traslado = [3] " _
                    & "Where correlativo = [0] and ano = [1] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_param_gen(ByVal lngDiasComunicacion As Long, _
                       ByVal strServidorCorreo As String, _
                       ByVal strDireccionCorreoOrigen As String, _
                       ByVal strDireccionCorreoDestino As String, _
                       ByVal lngRutJefeFinanzas As Long, _
                       ByVal lngRutOperaciones As Long)

            Dim strQuery As String, arrParam(5)
            arrParam(0) = lngDiasComunicacion
            arrParam(1) = lngRutJefeFinanzas
            arrParam(2) = lngRutOperaciones
            arrParam(3) = StringSql(strServidorCorreo)
            arrParam(4) = StringSql(strDireccionCorreoOrigen)
            arrParam(5) = StringSql(strDireccionCorreoDestino)

            strQuery = _
                "update Param_Gen Set " _
                & "dias_comunic = [0], " _
                & "rut_jefe_finanzas = [1], " _
                & "rut_operaciones = [2], " _
                & "servidor_correo = [3], " _
                & "direccion_correo_origen = [4] , " _
                & "direccion_correo_destino = [5] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza el Porcentaje de Asistencia de un alumno a un Curso

        Public Sub u_porc_asist_part(ByVal lngCodCurso As Long, ByVal lngRutAlumno As Long, _
                                     ByVal dblPorcAsistencia As Double)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutAlumno
            If dblPorcAsistencia >= 0 And dblPorcAsistencia <= 1 Then
                arrParam(2) = DoubleVbABd(dblPorcAsistencia)
            Else
                arrParam(2) = DoubleVbABd(dblPorcAsistencia / 100)
            End If

            strQuery = _
                    "Update Participante Set " _
                    & "porc_asistencia = [2] " _
                    & "Where cod_curso = [0] And rut_alumno = [1] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Actualiza el Porcentaje de Asistencia de un alumno a un Curso

        'Public Sub u_porc_asist_part2(ByVal lngCodCurso As Long, ByVal lngRutAlumno As Long, _
        '                             ByVal dblPorcAsistencia As Double, ByVal dblNotaAlum As Double, ByVal txtDetalleAsistencia As String)

        '    Dim strQuery As String, arrParam(4)
        '    arrParam(0) = lngCodCurso
        '    arrParam(1) = lngRutAlumno
        '    arrParam(3) = DoubleVbABd(dblNotaAlum)
        '    arrParam(4) = StringSql(txtDetalleAsistencia)
        '    If dblPorcAsistencia >= 0 And dblPorcAsistencia <= 1 Then
        '        arrParam(2) = DoubleVbABd(dblPorcAsistencia)
        '    Else
        '        arrParam(2) = DoubleVbABd(dblPorcAsistencia / 100)
        '    End If

        '    strQuery = _
        '            "Update Participante Set " _
        '            & "porc_asistencia = [2], " _
        '            & "nota_obtenida = [3], " _
        '            & "asistencia_detallada = [4] " _
        '            & "Where cod_curso = [0] And rut_alumno = [1] "

        '    Call EjecutarSql(SqlParam(strQuery, arrParam))
        'End Sub
        Public Sub u_porc_asist_part2(ByVal lngCodCurso As Long, ByVal lngRutAlumno As Long, _
                                      ByVal dblPorcAsistencia As Double, ByVal dblNotaObtenida As Double)

            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngCodCurso
            arrParam(1) = lngRutAlumno
            'arrParam(3) = DoubleVbABd(dblNotaAlum)
            'arrParam(4) = StringSql(txtDetalleAsistencia)
            If dblPorcAsistencia >= 0 And dblPorcAsistencia <= 1 Then
                arrParam(2) = DoubleVbABd(dblPorcAsistencia)
            Else
                arrParam(2) = DoubleVbABd(dblPorcAsistencia / 100)
            End If

            arrParam(3) = DoubleVbABd(dblNotaObtenida)

            strQuery = _
                    "Update Participante Set " _
                    & "porc_asistencia = [2], nota_obtenida = [3] " _
                    & "Where cod_curso = [0] And rut_alumno = [1] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        ' Actualizar registro en OBJETO
        Public Sub u_objeto(ByVal intCodigo As Integer, ByVal strNombre As String)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodigo
            arrParam(1) = StringSql(strNombre)
            strQuery = _
                "Update Objeto Set " _
                & "nombre = [1] " _
                & "Where cod_objeto = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            'Call EjecutarSql("Execute u_objeto " & intCodigo & ", '" & strNombre & "'")
        End Sub
        Public Sub u_aporte(ByVal lngCodAporte As Long, ByVal lngRutCliente As Long, _
                    ByVal intCodCuenta As Integer, _
                    ByVal dtmFechaContable As Date, _
                    ByVal intCodEstado As Integer, ByVal lngMontoNeto As Long, _
                    ByVal lngMontoAdm As Long, ByVal intTipoDoc As Integer, _
                    ByVal strNroDoc As String, ByVal strBanco As String, _
                    ByVal dtmFechaVencDoc As Date, _
                    ByVal dtmFechaCobro As Date, _
                    ByVal lngNumAporte As Long, ByVal strObs As String)
            Dim strQuery As String, arrParam(14)
            arrParam(0) = lngCodAporte
            arrParam(1) = lngRutCliente
            arrParam(2) = intCodCuenta
            arrParam(3) = Year(dtmFechaContable)
            arrParam(4) = FechaVbABd(dtmFechaContable)
            arrParam(5) = intCodEstado
            arrParam(6) = lngMontoNeto
            arrParam(7) = lngMontoAdm
            arrParam(8) = intTipoDoc
            arrParam(9) = StringSql(strNroDoc)
            arrParam(10) = StringSql(strBanco)
            arrParam(11) = FechaVbABd(dtmFechaVencDoc)
            arrParam(12) = FechaVbABd(dtmFechaCobro)
            arrParam(13) = lngNumAporte
            arrParam(14) = StringSql(strObs)

            strQuery = _
                "Update Aporte Set " _
                & "rut_cliente = [1], " _
                & "cod_cuenta = [2], " _
                & "agno = [3], " _
                & "fecha = [4], " _
                & "cod_estado = [5], " _
                & "monto_neto = [6], " _
                & "monto_adm = [7], " _
                & "cod_tipo_doc = [8], " _
                & "nro_documento = [9], " _
                & "banco = [10], " _
                & "fecha_venc_doc = [11], " _
                & "fecha_cobro = [12], " _
                & "num_aporte = [13], " _
                & "observaciones = [14] " _
                & "Where cod_aporte = [0] "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'actualiza el estado de la �ltima transacci�n de un aporte
        Public Sub u_transaccion_aporte_estado(ByVal lngCodAporte As Long, ByVal intCodNuevoEstado As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodAporte
            arrParam(1) = intCodNuevoEstado
            strQuery = _
                "Update Transaccion " _
                & "Set cod_estado_tran = [1]" _
                & "Where cod_aporte = [0] " _
                & "And nro_transaccion In (" _
                    & "Select Max(nro_transaccion) From Transaccion " _
                    & "Where cod_aporte = [0] " _
                    & "Group By cod_cuenta )"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Cambia el estado de un aporte a anulado
        Public Sub u_anular_aporte(ByVal lngCodAporte)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodAporte
            strQuery = _
                    "Update Aporte Set " _
                    & "cod_estado = 3 " _
                    & "Where cod_aporte = [0] "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_nro_alumno_curso(ByVal lngCodCurso As Long, ByVal intNroAlumno As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngCodCurso
            arrParam(1) = intNroAlumno
            strQuery = _
                    "Update curso_contratado Set " _
                    & "num_alumnos = [1] " _
                    & "Where cod_curso = [0] "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_certificado_asistencia(ByVal lngCodCurso As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso
            strQuery = _
                    "Update curso_contratado Set " _
                    & "tiene_certificado = 1 " _
                    & "Where cod_curso = [0] "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_nro_alumno_curso_interno(ByVal lngCorrelativo As Long, ByVal intAgno As Integer, ByVal intNroAlumno As Integer)
            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno
            arrParam(2) = intNroAlumno
            strQuery = _
                    "Update curso_interno Set " _
                    & "num_participantes = [2] " _
                    & "Where correlativo = [0] and ano = [1]"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub u_anular_curso_gasto_empresa(ByVal lngCodCurso As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso
            strQuery = _
                    "update curso_contratado set gasto_empresa=(gasto_empresa+75000), costo_otic=0 where cod_curso = [0]"
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
#End Region

#Region "DELETE"

        Public Function d_feriados(ByVal Agno As Integer) As DataTable
            Dim strQuery As String, arrParam(0)
            arrParam(0) = Agno
            strQuery = _
            "delete feriados where year(feriado) = [0]"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Function
        'Elina una registro en la tabla franquicia para un rut y a�o especifico
        Public Sub d_franquicia(ByVal lngRut As Long, ByVal intAgno As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRut
            arrParam(1) = intAgno
            strQuery = _
                "delete from franquicia " _
                & "where rut = [0] And Agno = [1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub d_Supervisor(ByVal RutSupervisor As Long, ByVal RutEjecutivo As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = RutSupervisor
            arrParam(1) = RutEjecutivo
            strQuery = _
                "delete from supervisor " _
                & "where supervisor.rut_supervisor = [0] " _
                & "And supervisor.rut_ejecutivo = [1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub d_perfilObjeto(ByVal intCodPerfil As Integer, ByVal intCodObjeto As Integer)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = intCodPerfil
            arrParam(1) = intCodObjeto
            strQuery = _
                "Delete From perfil_objeto " _
                & "Where perfil_objeto.cod_perfil = [0] " _
                & "and perfil_objeto.cod_objeto = [1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            'Call EjecutarSql("Execute d_perfilObjeto " & intCodPerfil & ", " _
            '& intCodObjeto & "")
        End Sub
        ' Delete de registro en tabla OBJETO
        Public Sub d_objeto(ByVal intCodigo As Integer)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodigo
            strQuery = _
                "Delete From Objeto " _
                & "Where cod_objeto = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
            'Call EjecutarSql("Execute d_objeto " & intCodigo)
        End Sub
        ' Delete de registro en tabla perfil
        Public Sub d_perfil(ByVal intCodigo As Integer)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodigo
            strQuery = _
                "Delete From Perfil " _
                & "Where cod_perfil = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Borra a un participante interno de un curso de la BD

        Public Sub d_participante_interno(ByVal lngCorrelativo As Long, ByVal intAgno As Integer, ByVal lngRutAlumno As Long)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno
            arrParam(2) = lngRutAlumno

            strQuery = _
                    "Delete From Participante_interno " _
                    & "Where correlativo = [0] and ano = [1] And rut = [2]"

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        'Borra los participantes asociados a un curso
        Public Sub d_participante(ByVal lngCodCurso As Long)

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                    "Delete From Participante " _
                    & "Where cod_curso = [0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub
        Public Sub d_participante_interno_todos(ByVal lngCorrelativo As Long, ByVal intAgno As Integer)

            Dim strQuery As String, arrParam(2)
            arrParam(0) = lngCorrelativo
            arrParam(1) = intAgno


            strQuery = _
                    "Delete From Participante_interno " _
                    & "Where correlativo = [0] and ano = [1] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))

        End Sub

        ' elimina una transacci�n solicitada
        Public Sub d_transaccion_solic(ByVal lngCodCurso As Long)
            Dim strQuery, strQueryAux As String, arrParam(1)
            Dim arrAux As DataTable
            Dim lngRut, lngMonto As Long
            Dim intCodCuenta, i As Integer
            Dim lngSaldoCta As Long

            arrParam(0) = lngCodCurso
            arrParam(1) = 3
            strQuery = _
            "Delete From Transaccion " _
            & "Where cod_curso = [0] And cod_estado_tran = [1]"

            strQueryAux = _
                "Select rut_cliente, cod_cuenta, monto From Transaccion " _
                & "Where cod_curso = [0] And cod_estado_tran = [1]"
            arrAux = ConsultaSql(SqlParam(strQueryAux, arrParam))

            Call EjecutarSql(SqlParam(strQuery, arrParam))

            If mlngRegistros > 0 Then
                For i = 0 To mlngRegistros - 1
                    lngRut = arrAux.Rows(i)(0) '(0, i)
                    intCodCuenta = arrAux.Rows(i)(1) '(1, i)
                    lngMonto = arrAux.Rows(i)(2) '(2, i)
                    lngSaldoCta = s_saldo_cuenta(lngRut, intCodCuenta)
                    Call u_SaldoCuentaCliente(lngRut, intCodCuenta, lngSaldoCta - lngMonto)
                Next
            End If
        End Sub
        Public Sub d_director_suc(ByVal RutDirector As Long, ByVal CodSucursal As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = RutDirector
            arrParam(1) = CodSucursal
            strQuery = _
                "delete from Director_Sucursal " _
                & "where rut = [0] " _
                & "And cod_sucursal = [1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        ' Delete de registro en tabla valor_hora_sence
        Public Sub d_valor_hora_sence(ByVal intAgno As Integer)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intAgno
            strQuery = _
                "Delete From Valor_hora_sence " _
                & "Where agno = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Borra una Solicitud de Pago a Tercero
        Public Sub d_sol_pago_terc(ByVal lngRutBenefactor As Long, ByVal lngCodCurso As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutBenefactor
            arrParam(1) = lngCodCurso


            strQuery = _
                "Delete From Solicitud_Pago_Terceros " _
                & "Where rut_benefactor = [0] And cod_curso = [1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        ' Delete de registro en tabla sucursal
        Public Sub d_sucursal(ByVal intCodigo As Integer)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = intCodigo
            strQuery = _
                "Delete From Sucursal " _
                & "Where cod_sucursal = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Sub d_perfilUsuario_porRut(ByVal lngRutUsuario As Long)
            Dim strQuery, arrparam(0) As String
            arrparam(0) = lngRutUsuario
            strQuery = _
                "delete from Perfil_Usuario " _
                & "where rut=[0] "
            Call EjecutarSql(SqlParam(strQuery, arrparam))
        End Sub
        Sub d_encargado_empresa_por_rut(ByVal lngRutEncargado As Long, ByVal lngRutEmpresa As Long)
            Dim strQuery, arrparam(1) As String
            arrparam(0) = lngRutEncargado
            arrparam(1) = lngRutEmpresa
            strQuery = _
                "delete from encargado_empresa " _
                & "where rut_encargado=[0] and rut_empresa=[1]"
            Call EjecutarSql(SqlParam(strQuery, arrparam))
        End Sub
        Sub d_supervisor_por_rut(ByVal lngRutUsuario As Long)
            Dim strQuery, arrparam(0) As String
            arrparam(0) = lngRutUsuario
            strQuery = _
                "delete from supervisor " _
                & "where rut_supervisor=[0] "
            Call EjecutarSql(SqlParam(strQuery, arrparam))
        End Sub
        Sub d_usuario(ByVal lngRut As Long)
            'Elmina usuario de tabla usuario
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRut
            strQuery = _
                    "Delete " _
                    & "From usuario  " _
                    & "Where usuario.rut = [0]"
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'elimina ejecutivos de una empresa en particular
        Public Sub d_ejecutivo(ByVal RutEmpresa As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = RutEmpresa

            strQuery = _
                "delete from ejecutivo " _
                & "where ejecutivo.rut_empresa = [0] "
            EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'Borra una transaccion. Solo debe ser llamada si el estado de la transaccion es "Solicitada"
        Public Function d_transaccion(ByVal lngRutCliente As Long, ByVal lngCodCurso As Long, _
                                 ByVal intCodCuenta As Integer) As Boolean

            Dim strQuery, strQueryAux As String, arrParam(3)
            arrParam(0) = lngRutCliente
            arrParam(1) = lngCodCurso
            arrParam(2) = -1
            arrParam(3) = 3

            Dim arrEstadoTrCuenta As DataTable
            Dim i, intTamArr As Integer
            Dim lngMonto As Long
            Dim arrAux As DataTable
            arrEstadoTrCuenta = s_num_rut_cta_est_tran(lngCodCurso)
            intTamArr = Registros
            If intTamArr = 0 Then
                d_transaccion = True
                Exit Function
            End If
            For i = 0 To intTamArr - 1
                If arrEstadoTrCuenta.Rows(i)(2) = intCodCuenta Then '(2, i)
                    'If arrEstadoTrCuenta.Rows(i)(3) = 3 And arrEstadoTrCuenta.Rows(i)(1) = lngRutCliente Then  
                    If arrEstadoTrCuenta.Rows(i)(1) = lngRutCliente Then   '(3, i) (1, i)  'El estado de la transaccion es "Solicitada"
                        arrParam(2) = intCodCuenta
                    End If
                End If
            Next
            If arrParam(2) = -1 Then
                d_transaccion = False
                Exit Function
            Else
                strQueryAux = _
                    "Select monto From Transaccion " _
                    & "Where rut_cliente = [0] And cod_curso = [1] And cod_cuenta = [2] And cod_estado_tran = [3]"
                arrAux = ConsultaSql(SqlParam(strQueryAux, arrParam))
                lngMonto = arrAux.Rows(0)(0)

                strQuery = _
                    "Delete From Transaccion " _
                    & "Where rut_cliente = [0] And cod_curso = [1] And cod_cuenta = [2] And cod_estado_tran = [3]"

                Call EjecutarSql(SqlParam(strQuery, arrParam))

                Dim lngSaldoCta As Long
                lngSaldoCta = s_saldo_cuenta(lngRutCliente, intCodCuenta)
                Call u_SaldoCuentaCliente(lngRutCliente, intCodCuenta, lngSaldoCta - lngMonto)
                d_transaccion = True
            End If

        End Function
        'Borra el horario de un curso determinado
        Public Sub d_horario_curso(ByVal lngCodCurso As Long)

            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodCurso

            strQuery = _
                    "Delete From Horario_Curso " _
                    & "Where cod_curso = [0] "

            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub

        'elimina registro tabla empresa_cliente
        Public Sub d_empresa_cliente(ByVal RutEmpresa As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = RutEmpresa

            strQuery = _
                "delete from empresa_cliente " _
                & "where empresa_cliente.rut = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        'elimina todas las cuentas asociadas a un cliente
        Public Sub d_CuentaCliente(ByVal Rut As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = Rut

            strQuery = _
                "delete from cuenta_cliente " _
                & "where cuenta_cliente.rut_cliente = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))


        End Sub
        Public Sub d_Otec(ByVal Rutotec As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = Rutotec
            strQuery = _
                "delete from Otec " _
                & "where rut = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        ' Delete de registro en tabla Rubro
        Public Sub d_Rubro(ByVal lngCodigo As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngCodigo
            strQuery = _
                "Delete From Rubro " _
                & "Where cod_rubro = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub d_Persona_Juridica(ByVal RutEmpresa As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = RutEmpresa
            strQuery = _
                "delete from persona_juridica " _
                & "where persona_juridica.rut = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub d_clasificador(ByVal strCodigoClasificador As String, _
                          ByVal lngRutEmpresa As Long)
            Dim strQuery As String, arrParam(1)
            arrParam(0) = StringSql(strCodigoClasificador)
            arrParam(1) = lngRutEmpresa
            strQuery = _
                "Delete From clasificador " _
                & "Where cod_clasificador = [0] and rut = [1] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub d_certificado_aporte(ByVal lngAgno As Integer)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngAgno
            strQuery = _
                "Delete From Certificado_Aporte " _
                & "Where agno = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
        Public Sub d_Persona(ByVal Rut As Long)
            Dim strQuery As String, arrParam(0)
            arrParam(0) = Rut
            strQuery = _
                "delete from persona " _
                & "where persona.rut = [0] "
            Call EjecutarSql(SqlParam(strQuery, arrParam))
        End Sub
#End Region

        Public Sub New()
            MyBase.New()
            mstrTipoBD = TipoBd().ToUpper 's�lo se consulta 1 vez
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize() 'Destruye el padre
        End Sub
    End Class
End Namespace

