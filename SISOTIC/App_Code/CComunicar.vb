Imports Clases
Imports Modulos
Imports System.Data
Imports System.IO

Public Class CComunicar
    Private mobjCsql As CSql
    Private mobjCsqlAccess As CSql


    Private mstrArchivo As String
    Private mlngRutUsuario As Long

    Private mstrMensaje As String
    Private mdtMensajes As DataTable
    Private mdtDatos As DataTable
    Private mblnEnComunicacion As Boolean
    Private mblnEnLiquidacion As Boolean
    Private mstrCodigos As String
    Public Property Codigos() As String
        Get
            Return mstrCodigos
        End Get
        Set(ByVal value As String)
            mstrCodigos = value
        End Set
    End Property
    Public ReadOnly Property Archivo() As String
        Get
            Archivo = mstrArchivo
        End Get
    End Property
    Public WriteOnly Property RutUsuario() As String
        Set(ByVal value As String)
            mlngRutUsuario = value
        End Set
    End Property
    Public ReadOnly Property Mensajes() As DataTable
        Get
            Mensajes = mdtMensajes
        End Get
    End Property
    Public ReadOnly Property Datos() As datatable
        Get
            Datos = mdtDatos
        End Get
    End Property
    Public Property EnComunicacion() As Boolean
        Get
            EnComunicacion = mblnEnComunicacion
        End Get
        Set(ByVal value As Boolean)
            mblnEnComunicacion = value
        End Set
    End Property
    Public Property EnLiquidacion() As Boolean
        Get
            EnLiquidacion = mblnEnLiquidacion
        End Get
        Set(ByVal value As Boolean)
            mblnEnLiquidacion = value
        End Set
    End Property

    Public Function GenerarBase() As Boolean
        Try
            If System.IO.File.Exists(Parametros.p_DIRFISICO & "contenido\bd\acciones.mdb") Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & "contenido\bd\acciones.mdb")
            End If
            System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\BaseDatosSence\acciones.mdb", Parametros.p_DIRFISICO & "contenido\bd\acciones.mdb")

            mobjCsql = New CSql
            mobjCsqlAccess = New CSql
            mobjCsqlAccess.MotorDb = "ACCESS2K"
            mobjCsqlAccess.BD = Parametros.p_DIRFISICO & "contenido\bd\acciones.mdb"
            mobjCsqlAccess.Usuario = ""
            mobjCsqlAccess.Clave = ""

            Dim dtCursos As DataTable
            Dim dtHorariosCurso As DataTable
            'arreglo alumnos cada posicion es de tipo clase Calumno
            Dim colAlumnos As Collection
            dtCursos = mobjCsql.s_cursos_en_comuni_en_liquid(mblnEnComunicacion, mblnEnLiquidacion, mstrCodigos)

            Dim intFilas, i, j, k, intHorario, intAlumnos As Integer
            intFilas = mobjCsql.Registros

            Dim objcursoContratado As New CCursoContratado

            objcursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            'variable que recepciona las consulta sql a la base de datos access
            Dim Registro As Long
            Dim indice, indice2, indice3 As Integer
            indice = 1
            indice2 = 1
            indice3 = 1
            Dim objCursoTemp As CCursoContratado

            Dim drCursos As DataRow

            For Each drCursos In dtCursos.Rows
                If objcursoContratado.Inicializar1(drCursos("cod_curso")) = True Then
                    'copiar el curso a la base de datos Access

                    objcursoContratado.CalcularCostos()
                    objcursoContratado.CalcCostoAdm()
                    objcursoContratado.ActualizarDatos(0)
                    'objcursoContratado.ObtenerInfoCuentas()

                    Dim strTipoOp As String
                    If objcursoContratado.CodEstadoCurso = 7 Then  'en comunicacion
                        strTipoOp = "C"
                    Else
                        strTipoOp = "L"
                    End If

                    'insertar curso contratado en tabla acc_cap de la base de datos acciones.mdb

                    Dim id_acc_cap As Long
                    Dim id_comuna As Long
                    Dim fec_ini_acc_cap As Date
                    Dim cod_sence As String
                    Dim fec_ter_acc_cap As Date
                    Dim id_comunicador As Long
                    Dim dir_acc_cap As String
                    Dim tipo_accion_cap As Integer
                    Dim observ_acc_cap As String
                    Dim valor_total_curso As Long
                    Dim ind_acu_com_bip As Integer
                    Dim id_usuario_empresa As String
                    Dim tipo_operacion As String
                    Dim valor_total_liquidar As Long
                    Dim obs_liquidacion As String
                    Dim horas_ejecutadas As Long
                    Dim tipo_actividad_cap As Integer
                    Dim id_det_nece As Integer
                    Dim ind_mandato As Integer

                    'verifica si existe o no el registro en la b.d de access, si no existe inserta
                    Registro = mobjCsqlAccess.s_existe_registro_Access(objcursoContratado.CodCurso)
                    'inserta en curso contratado
                    If Registro = 0 Then
                        If strTipoOp = "C" Then
                            id_acc_cap = objcursoContratado.CodCurso
                            valor_total_curso = objcursoContratado.ValorMercado
                            'valor_total_liquidar = 0
                            valor_total_liquidar = objcursoContratado.ValorComunicado
                        Else
                            id_acc_cap = objcursoContratado.NroRegistro
                            If objcursoContratado.CodCursoCompl > 0 Then
                                valor_total_curso = objcursoContratado.CursoCompl.GastoEmpresa + _
                                                                   objcursoContratado.CursoCompl.CostoOtic + _
                                                                   objcursoContratado.GastoEmpresa + _
                                                                   objcursoContratado.CostoOtic
                                valor_total_liquidar = objcursoContratado.CursoCompl.GastoEmpresa + _
                                                                   objcursoContratado.CursoCompl.CostoOtic + _
                                                                   objcursoContratado.GastoEmpresa + _
                                                                   objcursoContratado.CostoOtic
                            ElseIf objcursoContratado.CodCursoParcial > 0 Then
                                objCursoTemp = New CCursoContratado
                                objCursoTemp.Inicializar0(mobjCsql, mlngRutUsuario)
                                objCursoTemp.Inicializar1(objcursoContratado.CodCursoParcial)
                                valor_total_curso = objCursoTemp.GastoEmpresa + _
                                                                   objCursoTemp.CostoOtic + _
                                                                   objcursoContratado.GastoEmpresa + _
                                                                   objcursoContratado.CostoOtic
                                valor_total_liquidar = objCursoTemp.GastoEmpresa + _
                                                                   objCursoTemp.CostoOtic + _
                                                                   objcursoContratado.GastoEmpresa + _
                                                                   objcursoContratado.CostoOtic
                                objCursoTemp = Nothing
                            Else
                                valor_total_curso = objcursoContratado.ValorMercado
                                valor_total_liquidar = objcursoContratado.CostoOtic + _
                                                                      objcursoContratado.GastoEmpresa
                            End If
                        End If

                        id_comuna = objcursoContratado.CodComuna
                        fec_ini_acc_cap = FechaUsrAVb(objcursoContratado.FechaInicio)
                        cod_sence = objcursoContratado.CodSence
                        fec_ter_acc_cap = FechaUsrAVb(objcursoContratado.FechaTermino)
                        objcursoContratado.ParamGen.Inicializar()
                        id_comunicador = RutUsrALng(Parametros.p_RUTEMPRESA)
                        dir_acc_cap = Left(objcursoContratado.DireccionCursoCompleta, 99)

                        tipo_accion_cap = 2

                        If objcursoContratado.Observacion = "" Then
                            observ_acc_cap = "Sin observaciones"
                        Else
                            observ_acc_cap = Left(objcursoContratado.Observacion, 254)
                        End If
                        If objcursoContratado.IndAcuComBip Then
                            ind_acu_com_bip = 1
                        Else
                            ind_acu_com_bip = 0
                        End If

                        'indica el tipo de operación: C=comunicar, L=liquidar
                        tipo_operacion = strTipoOp

                        If objcursoContratado.ObsLiquidacion = "" Then
                            obs_liquidacion = "Observación Liquidación"
                        Else
                            obs_liquidacion = Left(objcursoContratado.ObsLiquidacion, 254)
                        End If
                        id_usuario_empresa = Left(objcursoContratado.RutCliente, 20)
                        horas_ejecutadas = objcursoContratado.HorasEjecutadas
                        tipo_actividad_cap = objcursoContratado.CodTipoActiv
                        If objcursoContratado.IndDetNece Then
                            id_det_nece = 1
                        Else
                            id_det_nece = 0
                        End If
                        ind_mandato = 0

                        '**********************************************
                        '**********************************************
                        '**********************************************
                        '**********************************************
                        Dim lngValorTotalCursoTemp As Long
                        Dim objCurso As New CCurso
                        objCurso.Inicializar0(mobjCsql, mlngRutUsuario)

                        objCurso.Inicializar1(cod_sence)
                        lngValorTotalCursoTemp = (horas_ejecutadas * objCurso.ValorHora * objCurso.NumMaxParticip)
                        'if (((ValorCursoSence/maxParticipantes)*participantes) < Valor)
                        'If (((lngValorTotalCursoTemp / objCurso.NumMaxParticip) * objcursoContratado.NumAlumnos) < valor_total_curso) Then
                        '    lngValorTotalCursoTemp = (lngValorTotalCursoTemp / objCurso.NumMaxParticip)
                        '    valor_total_curso = (lngValorTotalCursoTemp * objcursoContratado.NumAlumnos)
                        'End If

                        objCurso = Nothing

                        mobjCsqlAccess.i_acc_cap(id_acc_cap, id_comuna, fec_ini_acc_cap, cod_sence, fec_ter_acc_cap, id_comunicador, _
                        dir_acc_cap, tipo_accion_cap, observ_acc_cap, valor_total_curso, ind_acu_com_bip, _
                        tipo_operacion, valor_total_liquidar, obs_liquidacion, id_usuario_empresa, _
                        horas_ejecutadas, tipo_actividad_cap, id_det_nece, ind_mandato)

                        If strTipoOp = "C" Then
                            id_acc_cap = objcursoContratado.CodCurso
                        Else
                            id_acc_cap = objcursoContratado.NroRegistro
                        End If



                        mobjCsqlAccess.i_direccion(indice, objcursoContratado.DireccionCurso, objcursoContratado.Ciudad, _
                                                objcursoContratado.CodComuna, "0", "0", objcursoContratado.NroDireccionCurso, _
                                                1, id_acc_cap, 0)


                        indice = indice + 1
                        '---------------------------------------------
                    End If

                    'insertar datos en tabla horario de la base de datos acciones.mdb
                    objcursoContratado.ObtenerHorarioBD(objcursoContratado.CodCurso)
                    dtHorariosCurso = objcursoContratado.HorarioCurso   'arreglo de tipo registro
                    Dim drHorario As DataRow
                    Dim dia_clase As Integer
                    Dim hora_desde As String
                    Dim hora_hasta As String
                    For Each drHorario In dtHorariosCurso.Rows
                        Registro = mobjCsqlAccess.s_Horario_Access(objcursoContratado.CodCurso, drHorario("Dia"), drHorario("HoraInicio"))
                        If Registro = 0 Then
                            If drHorario("Dia") <> -1 Then
                                If strTipoOp = "C" Then
                                    id_acc_cap = objcursoContratado.CodCurso
                                Else
                                    id_acc_cap = objcursoContratado.NroRegistro
                                End If
                                dia_clase = drHorario("Dia")
                                hora_desde = Left(drHorario("HoraInicio"), 5)
                                hora_hasta = Left(drHorario("HoraFin"), 5)
                                mobjCsqlAccess.i_horario(id_acc_cap, dia_clase, hora_desde, hora_hasta)
                            End If
                        End If
                    Next

                    colAlumnos = objcursoContratado.ObtenerAlumnos
                    intAlumnos = colAlumnos.Count

                    Dim rut_num_pers_nat As Long
                    Dim rut_dgv_pers_nat As String
                    Dim nombre_pers_nat As String
                    Dim ape_1_pers_nat As String
                    Dim ape_2_pers_nat As String
                    Dim fec_nac_pers_nat As Date
                    Dim rut_num_pers_jur As Long
                    Dim sexo As String
                    Dim id_escolaridad As String


                    Dim porc_franq As Double
                    Dim id_niv_ocu As Integer
                    Dim id_region As Long
                    Dim observaciones As String
                    Dim viatico As Long
                    Dim traslado As Long
                    Dim cod_asist As Long
                    Dim porc_asist As Double
                    Dim estado_participante As String


                    Dim id_pais As Integer
                    Dim fono_partcicipante As Long
                    Dim email_participante As String

                    For k = 0 To intAlumnos - 1
                        Registro = mobjCsqlAccess.s_PersonaNatural_Access(RutUsrALng(colAlumnos(k + 1).Rut))
                        If Registro = 0 Then

                            rut_num_pers_nat = RutUsrALng(colAlumnos(k + 1).Rut)
                            rut_dgv_pers_nat = colAlumnos(k + 1).DigVerificador
                            nombre_pers_nat = Left(colAlumnos(k + 1).Nombres, 20)
                            ape_1_pers_nat = Left(colAlumnos(k + 1).ApPaterno, 20)
                            ape_2_pers_nat = Left(colAlumnos(k + 1).ApMaterno, 20)
                            fec_nac_pers_nat = FechaUsrAVb(colAlumnos(k + 1).FechaNacimiento)
                            rut_num_pers_jur = RutUsrALng(colAlumnos(k + 1).RutEmpresa)
                            sexo = colAlumnos(k + 1).Sexo
                            id_escolaridad = "0" & CStr(colAlumnos(k + 1).CodigoNivelEduc)


                            mobjCsqlAccess.i_persona_natural_access(rut_num_pers_nat, rut_dgv_pers_nat, nombre_pers_nat, _
                                                                    ape_1_pers_nat, ape_2_pers_nat, fec_nac_pers_nat, _
                                                                    rut_num_pers_jur, sexo, id_escolaridad)

                        End If
                        'inserta datos en tabla participante
                        Registro = mobjCsqlAccess.s_participante_access(objcursoContratado.CodCurso, RutUsrALng(colAlumnos(k + 1).RutEmpresa), RutUsrALng(colAlumnos(k + 1).Rut))
                        If Registro = 0 Then
                            If strTipoOp = "C" Then
                                id_acc_cap = objcursoContratado.CodCurso
                            Else
                                id_acc_cap = objcursoContratado.NroRegistro
                            End If
                            rut_num_pers_jur = RutUsrALng(colAlumnos(k + 1).RutEmpresa)
                            rut_num_pers_nat = RutUsrALng(colAlumnos(k + 1).Rut)
                            porc_franq = colAlumnos(k + 1).PorcFranquicia
                            id_niv_ocu = colAlumnos(k + 1).CodigoNivelOcup
                            id_region = colAlumnos(k + 1).CodigoRegion
                            If colAlumnos(k + 1).Observaciones = "" Then
                                observaciones = "Observaciones"
                            Else
                                observaciones = Left(colAlumnos(k + 1).Observaciones, 254)
                            End If
                            viatico = colAlumnos(k + 1).Viatico
                            traslado = colAlumnos(k + 1).Traslado
                            'cod_asist:
                            '1: 100% de asistencia
                            '2: entre 75 y 99% de asistencia
                            '3: menos de 75%
                            Dim intCodAsist As Integer
                            Dim intPorcAsistencia As Integer
                            intPorcAsistencia = colAlumnos(k + 1).PorcAsistencia
                            If intPorcAsistencia = 100 Then
                                intCodAsist = 1
                            ElseIf intPorcAsistencia >= 75 Then
                                intCodAsist = 2
                            Else       'menos de 75%
                                intCodAsist = 3
                            End If

                            cod_asist = intCodAsist
                            porc_asist = intPorcAsistencia
                            id_escolaridad = "0" & CStr(colAlumnos(k + 1).CodigoNivelEduc)
                            id_comuna = colAlumnos(k + 1).CodigoComuna


                            email_participante = colAlumnos(k + 1).Email
                            If colAlumnos(k + 1).Fono = "" Then
                                fono_partcicipante = 0
                            Else
                                fono_partcicipante = CLng(colAlumnos(k + 1).Fono)
                            End If

                            id_pais = colAlumnos(k + 1).CodigoPais
                            'estado_participante = "0"


                            mobjCsqlAccess.i_participante_access(id_acc_cap, rut_num_pers_jur, rut_num_pers_nat, _
                                           porc_franq, id_niv_ocu, id_region, observaciones, viatico, traslado, _
                                           cod_asist, porc_asist, id_escolaridad, id_comuna, id_pais, email_participante, _
                                           fono_partcicipante)
                        End If
                    Next

                    Dim rut_dgv_pers_jur As String
                    Dim nom_fan_pers_jur As String
                    Dim raz_soc_pers_jur As String
                    Dim dir_pers_jur As String
                    Dim sigla_pers_jur As String
                    Dim fono1_pers_jur As String
                    Dim fono2_pers_jur As String
                    Dim e_mail As String
                    Dim fax_pers_jur As String
                    Dim casilla As String
                    Dim ciudad As String


                   

                    Dim objCliente As New CCliente
                    objCliente.Inicializar0(mobjCsql, mlngRutUsuario)
                    If objCliente.Inicializar1(objcursoContratado.RutCliente) = True Then
                        Registro = mobjCsqlAccess.s_persona_juridica_access(RutUsrALng(objcursoContratado.RutCliente))
                        If Registro = 0 Then

                            rut_num_pers_jur = RutUsrALng(objcursoContratado.RutCliente)
                            rut_dgv_pers_jur = objCliente.DigitoOtec
                            nom_fan_pers_jur = Left(objCliente.NombreFantasia,50)
                            raz_soc_pers_jur = Left(objCliente.RazonSocial, 100)
                            dir_pers_jur = objCliente.Direccion
                            sigla_pers_jur = Left(objCliente.Sigla, 20)
                            If UCase(Trim(objCliente.FonoOtec)) = "" Then
                                fono1_pers_jur = "NO POSEE"
                            Else
                                fono1_pers_jur = Left(Trim(objCliente.FonoOtec), 10)
                            End If
                            If UCase(Trim(objCliente.Fono2Otec)) = "" Then
                                fono2_pers_jur = "NO POSEE"
                            Else
                                fono2_pers_jur = Left(Trim(objCliente.Fono2Otec), 10)
                            End If
                            id_comuna = objCliente.CodigoComuna
                            'soporta solo 20 carcteres en la tabla de access
                            If UCase(Trim(objCliente.EmailOtec)) = "" Then
                                e_mail = "0"
                            Else
                                e_mail = Mid(objCliente.EmailOtec, 1, 20)
                            End If

                            If UCase(Trim(objCliente.Fax)) = "" Then
                                fax_pers_jur = "0"
                            Else
                                fax_pers_jur = Trim(objCliente.Fax)
                            End If

                            If UCase(Trim(objCliente.Casilla)) = "" Then
                                casilla = "0"
                            Else
                                casilla = Left(Trim(objCliente.Casilla), 12)
                            End If
                            ciudad = objCliente.Ciudad

                            mobjCsqlAccess.i_persona_juridica_access(rut_num_pers_jur, rut_dgv_pers_jur, _
                                                 nom_fan_pers_jur, raz_soc_pers_jur, _
                                                 dir_pers_jur, sigla_pers_jur, _
                                                 fono1_pers_jur, fono2_pers_jur, _
                                                 id_comuna, e_mail, _
                                                 fax_pers_jur, casilla, _
                                                 ciudad)


                           

                            ''--------------------------------------------
                            'Inserta datos de la direccion del curso

                            Dim id_direccion As Long
                            Dim nombre_dire As String
                            Dim villa_poblacion As String
                            Dim n_oficina As String
                            Dim n_dire As String
                            Dim id_tipo As Long

                            id_direccion = indice
                            If objCliente.Direccion = "" Then
                                nombre_dire = "S/D"
                            Else
                                nombre_dire = Left(objCliente.Direccion, 199)
                            End If
                            If objCliente.Ciudad = "" Then
                                ciudad = "Santiago"
                            Else
                                ciudad = Left(objCliente.Ciudad, 49)
                            End If

                            id_comuna = objCliente.CodigoComuna
                            villa_poblacion = "0"
                            n_oficina = "0"
                            If objCliente.NroDireccion = "" Then
                                n_dire = "S/N"
                            Else
                                n_dire = Left(objCliente.NroDireccion, 10)
                            End If
                            id_tipo = 2
                            id_acc_cap = 0
                            rut_num_pers_jur = RutUsrALng(objcursoContratado.RutCliente)

                            mobjCsqlAccess.i_direccion(indice, nombre_dire, ciudad, _
                                                id_comuna, villa_poblacion, n_oficina, n_dire, _
                                                id_tipo, id_acc_cap, rut_num_pers_jur)

                            indice = indice + 1
                            '---------------------------------------------
                        End If


                        'inserta datos encargado

                        'encargado
                        Dim rut_encargado As String
                        Dim nombre_encargado As String
                        Dim apellido_encargado As String
                        Dim cargo_encargado As String
                        Dim telefono_encargado As Long
                        Dim email_encargado As String

                        Dim objEncargado As New CMantenedorEncargado

                        If objEncargado.Inicializar(objcursoContratado.CodCurso) Then


                            rut_encargado = Replace(RutLngAUsr(objEncargado.RutEncargado), ".", "")
                            nombre_encargado = objEncargado.NombreEncargado
                            apellido_encargado = objEncargado.ApellidoEncargado

                            If objEncargado.CargoEncargado = "" Then
                                cargo_encargado = ""
                            Else
                                cargo_encargado = objEncargado.CargoEncargado
                            End If

                            If objEncargado.FonoEncargado = "" Then
                                telefono_encargado = 0
                            Else
                                telefono_encargado = 0
                            End If

                            If objEncargado.EmailEncargado = "" Then
                                email_encargado = ""
                            Else
                                email_encargado = objEncargado.EmailEncargado
                            End If

                            If strTipoOp = "C" Then
                                id_acc_cap = objcursoContratado.CodCurso
                            Else
                                id_acc_cap = objcursoContratado.NroRegistro
                            End If

                            mobjCsqlAccess.i_encargado_access(rut_encargado, nombre_encargado, apellido_encargado, cargo_encargado, _
                                                         telefono_encargado, id_acc_cap, email_encargado)
                        Else
                            Return False
                        End If




                        



                        'insertar en organismo_acc_cap
                        Registro = mobjCsqlAccess.s_organismo_acc_cap_access(objcursoContratado.CodCurso, RutUsrALng(objcursoContratado.RutCliente))
                        If Registro = 0 Then

                            If strTipoOp = "C" Then
                                id_acc_cap = objcursoContratado.CodCurso         'codigo curso contratado
                            Else
                                id_acc_cap = objcursoContratado.NroRegistro
                            End If
                            rut_num_pers_jur = RutUsrALng(objcursoContratado.RutCliente) 'rut empresa que contrato el curso

                            mobjCsqlAccess.i_organismo_acc_cap_access(id_acc_cap, rut_num_pers_jur)

                        End If
                    End If
                    'objCliente = Nothing

                    'inserta datos del otec que dicta el curso en la tabla persona_juridica
                    Dim ObjOtec As COtec
                    ObjOtec = objcursoContratado.Otec
                    Registro = mobjCsqlAccess.s_persona_juridica_access(ObjOtec.Rutotec)
                    If Registro = 0 Then
                        rut_num_pers_jur = ObjOtec.Rutotec
                        rut_dgv_pers_jur = ObjOtec.DigitoOtec
                        If ObjOtec.NombreFantasia = "" Then
                            nom_fan_pers_jur = Left(ObjOtec.RazonSocial, 100)
                        Else
                            nom_fan_pers_jur = Left(ObjOtec.NombreFantasia, 100)
                        End If

                        raz_soc_pers_jur = Left(ObjOtec.RazonSocial, 100)
                        dir_pers_jur = ObjOtec.Direccion
                        sigla_pers_jur = Mid(ObjOtec.Sigla, 1, 20)
                        If UCase(Trim(ObjOtec.Fono)) = "" Then
                            fono1_pers_jur = "NO POSEE"
                        Else
                            fono1_pers_jur = Left(Trim(ObjOtec.Fono), 10)
                        End If
                        If UCase(Trim(ObjOtec.Fono2)) = "" Then
                            fono2_pers_jur = "NO POSEE"
                        Else
                            fono2_pers_jur = Left(Trim(ObjOtec.Fono2), 10)
                        End If
                        id_comuna = ObjOtec.CodComuna
                        If UCase(Trim(ObjOtec.Email)) = "" Then
                            e_mail = "0"
                        Else
                            e_mail = Mid(ObjOtec.Email, 1, 20)
                        End If


                        If UCase(Trim(ObjOtec.Fax)) = "" Then
                            fax_pers_jur = "0"
                        Else
                            fax_pers_jur = Left(Trim(ObjOtec.Fax), 11)
                        End If
                        If UCase(Trim(ObjOtec.Casilla)) = "" Then
                            casilla = "NO POSEE"
                        Else
                            casilla = Left(Trim(ObjOtec.Casilla), 12)
                        End If
                        ciudad = ObjOtec.Ciudad

                        mobjCsqlAccess.i_persona_juridica_access(rut_num_pers_jur, rut_dgv_pers_jur, _
                                                nom_fan_pers_jur, raz_soc_pers_jur, _
                                                dir_pers_jur, sigla_pers_jur, _
                                                fono1_pers_jur, fono2_pers_jur, _
                                                id_comuna, e_mail, _
                                                fax_pers_jur, casilla, _
                                                ciudad)

                        '--------------------------------------------

                        Dim id_direccion As Long
                        Dim nombre_dire As String
                        Dim villa_poblacion As String
                        Dim n_oficina As String
                        Dim n_dire As String
                        Dim id_tipo As Long

                        id_direccion = indice
                        If objCliente.Direccion = "" Then
                            nombre_dire = "S/D"
                        Else
                            nombre_dire = objCliente.Direccion
                        End If
                        If objCliente.Ciudad = "" Then
                            ciudad = "Santiago"
                        Else
                            ciudad = objCliente.Ciudad
                        End If
                        id_comuna = ObjOtec.CodComuna
                        villa_poblacion = "0"
                        n_oficina = "0"
                        If ObjOtec.NroDireccion = "" Then
                            n_dire = "S/N"
                        Else
                            n_dire = ObjOtec.NroDireccion
                        End If
                        id_tipo = 2
                        id_acc_cap = 0
                        rut_num_pers_jur = ObjOtec.Rutotec

                        mobjCsqlAccess.i_direccion(indice, nombre_dire, ciudad, _
                                                id_comuna, villa_poblacion, n_oficina, n_dire, _
                                                id_tipo, id_acc_cap, rut_num_pers_jur)

                        indice = indice + 1
                        '---------------------------------------------
                    Else
                        Dim id_direccion As Long
                        Dim nombre_dire As String
                        Dim villa_poblacion As String
                        Dim n_oficina As String
                        Dim n_dire As String
                        Dim id_tipo As Long

                        id_direccion = indice
                        If objCliente.Direccion = "" Then
                            nombre_dire = "S/D"
                        Else
                            nombre_dire = objCliente.Direccion
                        End If
                        If objCliente.Ciudad = "" Then
                            ciudad = "Santiago"
                        Else
                            ciudad = objCliente.Ciudad
                        End If
                        id_comuna = ObjOtec.CodComuna
                        villa_poblacion = "0"
                        n_oficina = "0"
                        If ObjOtec.NroDireccion = "" Then
                            n_dire = "S/N"
                        Else
                            n_dire = ObjOtec.NroDireccion
                        End If
                        id_tipo = 2
                        id_acc_cap = 0
                        rut_num_pers_jur = ObjOtec.Rutotec

                        mobjCsqlAccess.i_direccion(indice, nombre_dire, ciudad, _
                                                id_comuna, villa_poblacion, n_oficina, n_dire, _
                                                id_tipo, id_acc_cap, rut_num_pers_jur)

                        indice = indice + 1
                    End If
                    objCliente = Nothing
                    'llena los datos de las cuentas, imputaciones
                    Dim tipo_cuenta As Integer
                    Dim monto_comunicado As Long
                    Dim monto_liquidado As Long
                    Dim Tipo_monto As Integer
                    Dim Rut_reparto As Long


                    Registro = mobjCsqlAccess.s_ctas_otic_access(objcursoContratado.CodCurso)

                    If Registro = 0 Then
                        'MapeaCtaSisOticASence, trae el cod. cuenta para SENCE
                        If objcursoContratado.MontoCtaCap > 0 Then

                            id_acc_cap = IIf(strTipoOp = "C", objcursoContratado.CodCurso, objcursoContratado.NroRegistro)
                            tipo_cuenta = MapeaCtaSisOticASence("capac")
                            Tipo_monto = 1 'Normal:Cursos
                            If strTipoOp = "C" Then 'comunicación
                                monto_comunicado = objcursoContratado.MontoCtaCap
                                monto_liquidado = 0
                            Else                    'liquidación
                                monto_liquidado = objcursoContratado.MontoCtaCap
                                monto_comunicado = 0
                            End If

                            mobjCsqlAccess.i_acc_cuenta_otic(id_acc_cap, tipo_cuenta, monto_comunicado, monto_liquidado, Tipo_monto, 0)

                        End If

                        If objcursoContratado.MontoCtaExcCap > 0 Then

                            id_acc_cap = IIf(strTipoOp = "C", objcursoContratado.CodCurso, objcursoContratado.NroRegistro)
                            tipo_cuenta = MapeaCtaSisOticASence("excap")
                            Tipo_monto = 1 'Normal:Cursos
                            If strTipoOp = "C" Then 'comunicación
                                monto_comunicado = objcursoContratado.MontoCtaExcCap
                                monto_liquidado = 0
                            Else                    'liquidación
                                monto_liquidado = objcursoContratado.MontoCtaExcCap
                                monto_comunicado = 0
                            End If

                            mobjCsqlAccess.i_acc_cuenta_otic(id_acc_cap, tipo_cuenta, monto_comunicado, monto_liquidado, Tipo_monto, 0)


                        End If

                        Dim dtTerceros As New DataTable
                        dtTerceros = objcursoContratado.Terceros
                        If Not objcursoContratado.Terceros Is Nothing Then
                            Dim drTerceros As DataRow
                            For Each drTerceros In dtTerceros.Rows
                                If drTerceros.Item(6) = objcursoContratado.CodCurso And drTerceros.Item(5) > 0 And drTerceros.Item(4) > 0 Then

                                    id_acc_cap = IIf(strTipoOp = "C", objcursoContratado.CodCurso, objcursoContratado.NroRegistro)
                                    If drTerceros.Item(5) = 2 Then
                                        tipo_cuenta = MapeaCtaSisOticASence("repar")
                                    ElseIf drTerceros.Item(5) = 5 Then
                                        tipo_cuenta = MapeaCtaSisOticASence("excre")
                                    Else
                                        mstrMensaje = "Hay un curso pagado por tercero que no ha autorizado el pago. Debe autorizar para comunicar/liquidar."
                                        GenerarBase = False
                                        Exit Function
                                    End If
                                    Tipo_monto = 1 'Normal:Cursos
                                    If strTipoOp = "C" Then 'comunicación
                                        monto_comunicado = drTerceros.Item(4)
                                    Else                    'liquidación
                                        monto_liquidado = drTerceros.Item(4)
                                    End If
                                    Rut_reparto = drTerceros.Item(0)

                                    mobjCsqlAccess.i_acc_cuenta_otic(id_acc_cap, tipo_cuenta, monto_comunicado, monto_liquidado, Tipo_monto, Rut_reparto)
                                End If
                            Next
                        End If
                        If objcursoContratado.MontoCtaBecas > 0 Then

                            id_acc_cap = IIf(strTipoOp = "C", objcursoContratado.CodCurso, objcursoContratado.NroRegistro)
                            tipo_cuenta = MapeaCtaSisOticASence("becas")
                            Tipo_monto = 1 'Normal:Cursos
                            If strTipoOp = "C" Then 'comunicación
                                monto_comunicado = objcursoContratado.MontoCtaBecas
                            Else                    'liquidación
                                monto_liquidado = objcursoContratado.MontoCtaBecas
                            End If

                            mobjCsqlAccess.i_acc_cuenta_otic(id_acc_cap, tipo_cuenta, monto_comunicado, monto_liquidado, Tipo_monto, 0)

                        End If

                        'VyT
                        If objcursoContratado.MontoCtaCapVYT > 0 Then

                            id_acc_cap = IIf(strTipoOp = "C", objcursoContratado.CodCurso, objcursoContratado.NroRegistro)
                            tipo_cuenta = MapeaCtaSisOticASence("capac")
                            Tipo_monto = 2 'V&T
                            If strTipoOp = "C" Then 'comunicación
                                monto_comunicado = objcursoContratado.MontoCtaCapVYT
                            Else                    'liquidación
                                monto_liquidado = objcursoContratado.MontoCtaCapVYT
                            End If
                            mobjCsqlAccess.i_acc_cuenta_otic(id_acc_cap, tipo_cuenta, monto_comunicado, monto_liquidado, Tipo_monto, 0)

                        End If
                        If objcursoContratado.MontoCtaExcCapVYT > 0 Then

                            id_acc_cap = IIf(strTipoOp = "C", objcursoContratado.CodCurso, objcursoContratado.NroRegistro)
                            tipo_cuenta = MapeaCtaSisOticASence("excap")
                            Tipo_monto = 2 'V&T
                            If strTipoOp = "C" Then 'comunicación
                                monto_comunicado = objcursoContratado.MontoCtaExcCapVYT
                            Else                    'liquidación
                                monto_liquidado = objcursoContratado.MontoCtaExcCapVYT
                            End If
                            mobjCsqlAccess.i_acc_cuenta_otic(id_acc_cap, tipo_cuenta, monto_comunicado, monto_liquidado, Tipo_monto, 0)

                        End If


                        Dim num_doc As Integer
                        Dim monto As Integer
                        Dim rut_emisor As Integer
                        Dim rut_dgv_emisor As String
                        Dim id_tipo_doc As Integer
                        Dim fec_ing As Date
                        Dim Fec_pago As Date

                        Registro = mobjCsqlAccess.s_doc_pago_access(objcursoContratado.CodCurso)
                        If Registro = 0 Then
                            If objcursoContratado.Factura.NumFactura > 0 Then

                                id_acc_cap = IIf(strTipoOp = "C", objcursoContratado.CodCurso, objcursoContratado.NroRegistro)
                                num_doc = objcursoContratado.Factura.NumFactura
                                monto = objcursoContratado.Factura.Monto
                                rut_emisor = RutUsrALng(objcursoContratado.Otec.Rutotec)
                                rut_dgv_emisor = Trim(digito_verificador(RutUsrALng(objcursoContratado.Otec.Rutotec)))
                                id_tipo_doc = 1 'Factura
                                fec_ing = FechaUsrAVb(objcursoContratado.Factura.FechaRecepcion)
                                If objcursoContratado.Factura.FechaPago <> FechaMinSistema() Then
                                    Fec_pago = FechaUsrAVb(objcursoContratado.Factura.FechaPago)
                                Else
                                    Fec_pago = FechaMinSistema()
                                End If


                            End If
                        End If
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            mobjCsql.Cerrar()
            mobjCsqlAccess.Cerrar()
            EnviaError("CComunicar:GenerarBase-->" & ex.Message)
        End Try
    End Function
    '***************** IMPORTANTE *****************************
    'SE HA CAMBIADO EL CODIGO DE EXCEDENTES DE 3 A 1, DEBIDO A QUE SENCE NO ACEPTA QUE TENGA CODIGO 3 COMO CORRESPONDE.
    'CUANDO SENCE ARREGLE SU SISTEMA, VOLVER A COLOCAR EL CODIGO 3 EN EXCEDENTES DE CAPACITACION
    Private Function MapeaCtaSisOticASence(ByVal strCuentaSisOtic As String) As Integer
        Select Case strCuentaSisOtic
            Case "capac"          'Capacitación
                MapeaCtaSisOticASence = 1
            Case "repar"          'Reparto
                MapeaCtaSisOticASence = 2
            Case "excap"          'Exc. Cap
                MapeaCtaSisOticASence = Parametros.p_CUENTAEXCCAPACITACION
            Case "excre"          'Exc. Re.
                MapeaCtaSisOticASence = 4
            Case "becas"          'Becas
                MapeaCtaSisOticASence = 5
            Case Else
                MapeaCtaSisOticASence = -1
        End Select
    End Function
    Public Function RespaldarBase() As Boolean
        Try
            Dim agno, mes, Dia As String
            agno = Now.Year
            mes = Now.Month
            Dia = Now.Day
            If Len(mes) < 2 Then mes = "0" & mes
            If Len(Dia) < 2 Then Dia = "0" & Dia
            Dim strFecha As String = agno & mes & Dia
            If System.IO.File.Exists(Parametros.p_DIRFISICO & "contenido\bd\respaldos\acciones " & strFecha & ".mdb") Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & "contenido\bd\respaldos\acciones " & strFecha & ".mdb")
            End If
            System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\bd\acciones.mdb", Parametros.p_DIRFISICO & "contenido\bd\respaldos\acciones " & strFecha & ".mdb")
            'System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\bd\acciones.mdb", Parametros.p_DIRFISICO & "contenido\bd\respaldos\acciones.mdb")
            RespaldarBase = True
        Catch ex As Exception

        End Try
    End Function
    Public Function RespaldarCSV() As Boolean
        Try
            Dim agno, mes, Dia As String
            agno = Now.Year
            mes = Now.Month
            Dia = Now.Day
            If Len(mes) < 2 Then mes = "0" & mes
            If Len(Dia) < 2 Then Dia = "0" & Dia
            Dim strFecha As String = agno & mes & Dia
            If System.IO.File.Exists(Parametros.p_DIRFISICO & "contenido\csv\respaldos\acciones_a_comunicar " & strFecha & ".zip") Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & "contenido\csv\respaldos\acciones_a_comunicar " & strFecha & ".zip")
            End If
            System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar.zip", Parametros.p_DIRFISICO & "contenido\csv\respaldos\acciones_a_comunicar " & strFecha & ".zip")
            'System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\bd\acciones.mdb", Parametros.p_DIRFISICO & "contenido\bd\respaldos\acciones.mdb")
            RespaldarCSV = True
        Catch ex As Exception

        End Try
    End Function
    'llena los logs de tipo datatable
    Private Sub AgregaRegLogDt(ByVal mstrMensaje As String, ByRef dt As System.Data.DataTable)
        If dt Is Nothing Then
            dt = New DataTable
            dt.Columns.Add("log")
        End If
        Dim dr As System.Data.DataRow
        dr = dt.NewRow
        dr("log") = mstrMensaje
        dt.Rows.Add(dr)
    End Sub
    '    '-------Proceso de Comunicación

    '    'Es un archivo plano entregado por el sence (despues de ejecutar el proceso
    '    'que genera la base de datos de Intercambio Access accciones.mdb),
    '    'en donde se indica que cursos fueron aprobados y cuales fueron rechazados de la base de datos Access acciones.mdb que se les envió

    Public Sub RespuestaSence(ByVal strArchivo As String)
        Try
            Dim file As FileStream
            file = New FileStream(strArchivo, FileMode.Open)
            Dim reader As New StreamReader(file, System.Text.Encoding.UTF7)
            Dim strDatos As String
            Dim arrCursos() As String
            Dim intArreglo As Long
            Dim boolError As Boolean
            Dim lngCuentaEmpleadosCorrec As Long
            Dim lngCuentaEmpleadosIncorrec As Long
            lngCuentaEmpleadosCorrec = 0
            lngCuentaEmpleadosIncorrec = 0

            mobjCsql = New CSql
            Dim objcursoContratado As New CCursoContratado
            objcursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)

            While Not reader.EndOfStream
                strDatos = reader.ReadLine
                strDatos = Replace(strDatos, "'", "")
                strDatos = Replace(strDatos, ", este es solo un mensaje", ". este es solo un mensaje")
                arrCursos = strDatos.Split(",")
                intArreglo = TamanoArreglo1(arrCursos)
                Dim blnExisteCurso As Boolean = False
                If intArreglo = 8 Then 'valida el tamaño
                    blnExisteCurso = objcursoContratado.Inicializar1(arrCursos(0), True)  'true para cargar información del complemento
                ElseIf intArreglo = 7 Then
                    blnExisteCurso = objcursoContratado.InicializarNroRegistro(arrCursos(0), "9")  'debe estar en liquidación
                Else
                    boolError = True
                    AgregaRegLogDt("Error. Número de campos distinto al requerido para el curso " & arrCursos(0), Me.mdtMensajes)
                    lngCuentaEmpleadosIncorrec = lngCuentaEmpleadosIncorrec + 1
                End If
                If blnExisteCurso Then
                    'Dim dtEstado As DataTable
                    Dim intCodEstado As Integer
                    intCodEstado = objcursoContratado.CodEstadoCurso
                    'dtEstado = mobjCsql.s_estado_curso(intCodEstado)

                    Dim strEstado As String 'AP o RE
                    'variables Sence
                    Dim lngValorTotalCursoS As Long, lngValorCursoS As Long, lngCostoOticS As Long
                    If objcursoContratado.CodEstadoCurso = 7 Then 'En Comunicación
                        strEstado = UCase(arrCursos(6))
                        If IsNumeric(arrCursos(3)) Then lngValorTotalCursoS = arrCursos(3)
                        If IsNumeric(arrCursos(4)) Then lngValorCursoS = arrCursos(4)
                        If IsNumeric(arrCursos(5)) Then lngCostoOticS = arrCursos(5)
                    End If
                    If objcursoContratado.CodEstadoCurso = 9 Then 'En Liquidación
                        strEstado = UCase(arrCursos(4))
                        If IsNumeric(arrCursos(2)) Then lngValorTotalCursoS = arrCursos(2)
                        If IsNumeric(arrCursos(3)) Then lngValorCursoS = arrCursos(3)
                    End If

                    '
                    ' CODIGO PARA VALIDAR SI LOS MONTOS CORRESPONDEN
                    '
                    lngValorTotalCursoS = lngValorTotalCursoS - objcursoContratado.ValorMercado
                    lngValorCursoS = lngValorCursoS - objcursoContratado.ValorMercado
                    lngCostoOticS = lngCostoOticS - objcursoContratado.CostoOtic
                    If objcursoContratado.HorasCompl > -1 Then
                        'costo otic del curso complementario
                        lngCostoOticS = lngCostoOticS - objcursoContratado.CostoOticComplemento
                    End If
                    If objcursoContratado.CodCursoParcial > -1 Then  'tiene parcial
                        Dim objCursoParcial As New CCursoContratado
                        objCursoParcial.Inicializar0(mobjCsql, mlngRutUsuario)
                        objCursoParcial.Inicializar1(objcursoContratado.CodCursoParcial)
                        'considerar el valor del curso parcial
                        lngValorTotalCursoS = lngValorTotalCursoS - objCursoParcial.ValorMercado
                        objCursoParcial = Nothing
                    End If
                    'chequear que los montos calculados por el Sence son iguales a los del Webcap
                    mstrMensaje = ""
                    If lngValorTotalCursoS <> 0 Then
                        mstrMensaje = ". EXISTEN DIFERENCIAS EN EL VALOR TOTAL DEL CURSO ($" & lngValorTotalCursoS & ")." & vbcr
                    End If
                    If lngValorCursoS <> 0 Then
                        mstrMensaje = mstrMensaje & ". EXISTEN DIFERENCIAS EN EL VALOR DEL PERIODO DEL CURSO ($" & lngValorCursoS & ")." & vbcr
                    End If

                    If strEstado = "AP" Then 'AP ==> Aprobado
                        If objcursoContratado.CodEstadoCurso = 7 Then  'en comunicacion
                            'chequear que los montos calculados por el Sence son iguales a los del Webcap
                            If lngCostoOticS <> 0 Then
                                mstrMensaje = mstrMensaje & ". EXISTEN DIFERENCIAS EN EL COSTO OTIC ($" & lngCostoOticS & ")." & vbcr
                            End If

                            'recibe la glosa y el numero de registro cambiando el estado a Comunicado
                            objcursoContratado.CambiarEstComunicado(arrCursos(7), arrCursos(1))
                            AlmacenamientoEstadoCursos(mobjCsql, objcursoContratado.CodCurso, "Aprobado" & mstrMensaje)
                        ElseIf objcursoContratado.CodEstadoCurso = 9 Then  'en liquidacion
                            'si el curso tiene complemento, asignar el nro de registro
                            'que viene en la comunicación
                            Dim strNroRegistroCompl As String
                            If objcursoContratado.CodCursoCompl > 0 Then  'tiene complemento

                                strNroRegistroCompl = arrCursos(5)
                                If IsNumeric(strNroRegistroCompl) Then
                                    mstrMensaje = mstrMensaje & ". Se asignó número de registro al Curso Complementario." & vbcr
                                Else
                                    mstrMensaje = mstrMensaje & ". ADVERTENCIA: No se asignó nro. de registro al complemento." & vbcr
                                    strNroRegistroCompl = "0"
                                End If
                            End If
                            objcursoContratado.ObtenerAlumnos()
                            objcursoContratado.CambiarEstLiquidado(arrCursos(6), strNroRegistroCompl) 'Glosa
                            AlmacenamientoEstadoCursos(mobjCsql, objcursoContratado.CodCurso, "Aprobado" & mstrMensaje)
                        Else
                            AlmacenamientoEstadoCursos(mobjCsql, objcursoContratado.CodCurso, "Este curso no está en Comunicación o en Liquidación")
                        End If
                    Else
                        If objcursoContratado.CodEstadoCurso = 7 Then  'en comunicacion
                            objcursoContratado.CambiarEstRechazado(arrCursos(7))
                            AlmacenamientoEstadoCursos(mobjCsql, objcursoContratado.CodCurso, "Rechazado")
                        ElseIf objcursoContratado.CodEstadoCurso = 9 Then  'en liquidacion
                            objcursoContratado.CambiarEstRechazado(arrCursos(6)) 'Glosa
                            AlmacenamientoEstadoCursos(mobjCsql, objcursoContratado.CodCurso, "Rechazado")
                        Else
                            AlmacenamientoEstadoCursos(mobjCsql, objcursoContratado.CodCurso, "Este curso no está en Comunicación o en Liquidación")
                        End If
                    End If
                End If
            End While

            file.Close()
        Catch ex As Exception
            EnviaError("CComunicar: RespuestaSence--> " & ex.Message)
        End Try
    End Sub
    'Captura el estado en que el sence dejo cada curso que se le envió
    Sub AlmacenamientoEstadoCursos(ByVal objCsql As CSql, ByVal strCodCurso As String, _
                                   ByVal strEstadoCurso As String)
        Dim intNumRegistros As Integer
        Dim objcurso As New CCursoContratado
        objcurso.Inicializar0(objCsql, mlngRutUsuario)
        objcurso.Inicializar1(strCodCurso)
        If Not mdtDatos Is Nothing Then
            intNumRegistros = mdtDatos.Rows.Count
            Dim dr As DataRow
            dr = mdtDatos.NewRow
            dr.Item(0) = strCodCurso
            dr.Item(1) = strEstadoCurso
            dr.Item(2) = objcurso.Correlativo
            dr.Item(3) = objcurso.Cliente.RazonSocial
            dr.Item(4) = objcurso.Curso.NombreCurso
            dr.Item(5) = objcurso.Otec.NombreFantasia
            dr.Item(6) = objcurso.NumAlumnos
            dr.Item(7) = FechaVbAUsr(objcurso.FechaInicio)
            dr.Item(8) = FechaVbAUsr(objcurso.FechaTermino)
            mdtDatos.Rows.Add(dr)
        End If
        objcurso = Nothing
    End Sub
    Public Sub inicializar()
        Try
            mdtDatos = New DataTable
            mdtDatos.Columns.Add("strCodCurso")
            mdtDatos.Columns.Add("strEstadoCurso")
            mdtDatos.Columns.Add("folio")
            mdtDatos.Columns.Add("empresa")
            mdtDatos.Columns.Add("curso")
            mdtDatos.Columns.Add("otec")
            mdtDatos.Columns.Add("alumnos")
            mdtDatos.Columns.Add("inicio")
            mdtDatos.Columns.Add("fin")
        Catch ex As Exception

        End Try
    End Sub
End Class
