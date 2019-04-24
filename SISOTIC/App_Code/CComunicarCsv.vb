Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Imports Clases.Web


Public Class CComunicarCsv
    Private mlngRutCliente As Long
    Private mlngRutUsuario As Long
    Private mstrCodCursos As String
    Private mblnComunicar As Boolean
    Private mblnLiquidar As Boolean
    Private mobjCsql As CSql
    Private mstrXml As String
    Private mstrMensaje As String

    Property RutCliente() As Long
        Get
            Return Me.mlngRutCliente
        End Get
        Set(ByVal value As Long)
            Me.mlngRutCliente = value
        End Set
    End Property
    Property RutUsuario() As Long
        Get
            Return Me.mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            Me.mlngRutUsuario = value
        End Set
    End Property
    Property CodCurso() As String
        Get
            Return Me.mstrCodCursos
        End Get
        Set(ByVal value As String)
            Me.mstrCodCursos = value
        End Set
    End Property
    Property Comunicar() As Boolean
        Get
            Return Me.mblnComunicar
        End Get
        Set(ByVal value As Boolean)
            Me.mblnComunicar = value
        End Set
    End Property
    Property Liquidar() As Boolean
        Get
            Return Me.mblnLiquidar
        End Get
        Set(ByVal value As Boolean)
            Me.mblnLiquidar = value
        End Set
    End Property
    Property Xml() As String
        Get
            Return Me.mstrXml
        End Get
        Set(ByVal value As String)
            Me.mstrXml = value
        End Set
    End Property
    Property Mensaje() As String
        Get
            Return Me.mstrMensaje
        End Get
        Set(ByVal value As String)
            Me.mstrMensaje = value
        End Set
    End Property

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
                MapeaCtaSisOticASence = 3
            Case "excre"          'Exc. Re.
                MapeaCtaSisOticASence = 4
            Case "capac y excap"          'ambas cuentas (Capacitación y Exc. Cap)
                MapeaCtaSisOticASence = 5
            Case "repar y excre"     'ambas cuentas (Reparto y Exc. Re.)
                MapeaCtaSisOticASence = 6
            Case Else
                MapeaCtaSisOticASence = -1
        End Select
    End Function
    Public Function GenerarCsv() As Boolean
        Try

            If System.IO.File.Exists(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar\ComunicacionAcciones.csv") Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar\ComunicacionAcciones.csv")
            End If
            If System.IO.File.Exists(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar\Horario.csv") Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar\Horario.csv")
            End If
            If System.IO.File.Exists(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar\Participantes.csv") Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar\Participantes.csv")
            End If
            mobjCsql = New CSql

            Dim objcursoContratado As CCursoContratado
            Dim dtCursos As DataTable
            Dim dtHorariosCurso As DataTable
            Dim dtAlumnos As DataTable
            Dim dtTerceros As New DataTable
            Dim strNombreArchivo As String
            'arreglo alumnos cada posicion es de tipo clase Calumno
            Dim colAlumnos As Collection

            '***************************************************************
            '***************************************************************
            '**********************  CURSO  ********************************
            '***************************************************************
            '***************************************************************

            dtCursos = mobjCsql.s_cursos_en_comuni_en_liquid(mblnComunicar, mblnLiquidar, mstrCodCursos)
            'dtCursos.Columns.Add("Codigo Curso")
            dtCursos.Columns.Add("Rut Empresa") 'ok
            dtCursos.Columns.Add("Codigo SENCE") 'ok
            dtCursos.Columns.Add("Modulo CFT") 'ok
            dtCursos.Columns.Add("Fecha Inicio") 'ok
            dtCursos.Columns.Add("Fecha Termino") 'ok
            dtCursos.Columns.Add("Tipo Beneficiarios")
            dtCursos.Columns.Add("Comite Bipartito de Capacitacion") 'ok
            dtCursos.Columns.Add("Estudio de Necesidades de Capacitacion")
            dtCursos.Columns.Add("Calle") 'ok
            dtCursos.Columns.Add("Numero") 'ok
            dtCursos.Columns.Add("Sector/Villa/Poblacion") 'ok
            dtCursos.Columns.Add("Comuna") 'ok
            dtCursos.Columns.Add("Valor Total Accion") 'ok
            dtCursos.Columns.Add("Tipo de Cuenta")  'ok
            dtCursos.Columns.Add("Porcentaje de la cuenta principal") 'ok
            dtCursos.Columns.Add("Rut Empresa de Reparto") 'ok

            Dim intFilas, i, j, k, intHorario, intAlumnos As Integer
            intFilas = mobjCsql.Registros
            objcursoContratado = New CCursoContratado
            objcursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            'variable que recepciona las consulta sql a la base de datos access
            Dim Registro As Long
            Dim objCursoTemp As CCursoContratado


            Dim drCursos As DataRow

            For Each drCursos In dtCursos.Rows

                If objcursoContratado.Inicializar1(drCursos("cod_curso")) = True Then
                    'copiar el curso

                    objcursoContratado.CalcularCostos()
                    objcursoContratado.CalcCostoAdm()

                    Dim strTipoOp As String
                    If objcursoContratado.CodEstadoCurso = 7 Then  'en comunicacion
                        strTipoOp = "C"
                    Else
                        strTipoOp = "L"
                    End If

                    'If strTipoOp = "C" Then
                    '    id_acc_cap = objcursoContratado.CodCurso
                    'Else
                    '    id_acc_cap = objcursoContratado.NroRegistro
                    'End If

                    If strTipoOp = "C" Then
                        drCursos("Valor Total Accion") = objcursoContratado.ValorMercado
                    Else
                        If objcursoContratado.CodCursoCompl > 0 Then
                            drCursos("Valor Total Accion") = objcursoContratado.CursoCompl.GastoEmpresa + _
                                                               objcursoContratado.CursoCompl.CostoOtic + _
                                                               objcursoContratado.GastoEmpresa + _
                                                               objcursoContratado.CostoOtic
                        ElseIf objcursoContratado.CodCursoParcial > 0 Then
                            objCursoTemp = New CCursoContratado
                            objCursoTemp.Inicializar0(mobjCsql, mlngRutUsuario)
                            objCursoTemp.Inicializar1(objcursoContratado.CodCursoParcial)
                            drCursos("Valor Total Accion") = objCursoTemp.GastoEmpresa + _
                                                               objCursoTemp.CostoOtic + _
                                                               objcursoContratado.GastoEmpresa + _
                                                               objcursoContratado.CostoOtic
                            objCursoTemp = Nothing
                        Else
                            drCursos("Valor Total Accion") = objcursoContratado.ValorMercado
                        End If
                    End If
                    drCursos("Comuna") = objcursoContratado.CodComuna
                    drCursos("Fecha Inicio") = FechaVbAUsr(objcursoContratado.FechaInicio)
                    drCursos("Codigo SENCE") = objcursoContratado.CodSence
                    drCursos("Fecha Termino") = FechaVbAUsr(objcursoContratado.FechaTermino)
                    drCursos("Calle") = objcursoContratado.DireccionCurso
                    drCursos("Numero") = objcursoContratado.NroDireccionCurso
                    drCursos("Sector/Villa/Poblacion") = ""
                    drCursos("Modulo CFT") = ""

                    If objcursoContratado.IndAcuComBip Then
                        drCursos("Comite Bipartito de Capacitacion") = 1
                    Else
                        drCursos("Comite Bipartito de Capacitacion") = 0
                    End If

                    drCursos("Rut Empresa") = Replace(objcursoContratado.RutCliente, ".", "")
                    drCursos("Tipo Beneficiarios") = objcursoContratado.CodTipoActiv

                    If objcursoContratado.IndDetNece Then
                        drCursos("Estudio de Necesidades de Capacitacion") = 1
                    Else
                        drCursos("Estudio de Necesidades de Capacitacion") = 0
                    End If

                    If objcursoContratado.MontoCtaCap > 0 And objcursoContratado.MontoCtaExcCap > 0 Then
                        drCursos("Tipo de Cuenta") = MapeaCtaSisOticASence("capac y excap")
                        drCursos("Porcentaje de la cuenta principal") = Math.Round(((objcursoContratado.MontoCtaCap * 100) / objcursoContratado.CostoOtic), 0)
                    ElseIf objcursoContratado.MontoCtaCap > 0 Then
                        drCursos("Tipo de Cuenta") = MapeaCtaSisOticASence("capac")
                        drCursos("Porcentaje de la cuenta principal") = ""
                    ElseIf objcursoContratado.MontoCtaExcCap > 0 Then
                        drCursos("Tipo de Cuenta") = MapeaCtaSisOticASence("excap")
                        drCursos("Porcentaje de la cuenta principal") = ""
                    End If


                    dtTerceros = objcursoContratado.Terceros
                    If objcursoContratado.Terceros.Rows.Count > 0 Then
                        Dim drTerceros As DataRow
                        For Each drTerceros In dtTerceros.Rows
                            If drTerceros.Item(6) = objcursoContratado.CodCurso And drTerceros.Item(5) > 0 And drTerceros.Item(4) > 0 Then
                                If drTerceros.Item(5) = 2 And drTerceros.Item(5) = 5 Then
                                    drCursos("Tipo de Cuenta") = MapeaCtaSisOticASence("repar y excre")
                                    drCursos("Porcentaje de la cuenta principal") = Math.Round(((objcursoContratado.MontoRep * 100) / objcursoContratado.CostoOtic), 0)
                                ElseIf drTerceros.Item(5) = 2 Then
                                    drCursos("Tipo de Cuenta") = MapeaCtaSisOticASence("repar")
                                    drCursos("Porcentaje de la cuenta principal") = ""
                                ElseIf drTerceros.Item(5) = 5 Then
                                    drCursos("Tipo de Cuenta") = MapeaCtaSisOticASence("excre")
                                    drCursos("Porcentaje de la cuenta principal") = ""
                                Else
                                    mstrMensaje = "Hay un curso pagado por tercero que no ha autorizado el pago. Debe autorizar para comunicar/liquidar."
                                    GenerarCsv = False
                                    Exit Function
                                End If

                                drCursos("Rut Empresa de Reparto") = Replace(RutLngAUsr(drTerceros.Item(0)), ".", "")

                            End If
                        Next
                    Else
                        drCursos("Rut Empresa de Reparto") = ""
                    End If
                End If
            Next

            dtCursos.Columns.Remove("cod_curso")
            '***************************************************************
            '***************************************************************
            '**********************  HORARIO  ******************************
            '***************************************************************
            '***************************************************************

            'insertar datos en tabla horario
            objcursoContratado.ObtenerHorarioCSV(mstrCodCursos)
            dtHorariosCurso = objcursoContratado.HorarioCurso   'arreglo de tipo registro

            Dim intTotalHoras As Integer = objcursoContratado.Horas
            Dim intHorasXDia As Integer
            Dim intContador As Integer
            'dtCursos.Columns.Add("Codigo Curso")
            dtHorariosCurso.Columns.Add("Rut Empresa") 'ok
            'dtHorariosCurso.Columns.Add("Codigo SENCE") 'ok
            dtHorariosCurso.Columns.Add("Modulo CFT") 'ok
            'dtHorariosCurso.Columns.Add("Fecha Inicio Accion") 'ok
            dtHorariosCurso.Columns.Add("Dia de Clases") 'ok
            dtHorariosCurso.Columns.Add("Hora Inicio") 'ok
            dtHorariosCurso.Columns.Add("Hora Termino") 'ok
            Dim drHorario As DataRow
            Dim dia_clase As Integer
            Dim hora_desde As String
            Dim hora_hasta As String
            For Each drHorario In dtHorariosCurso.Rows
                If Registro = 0 Then
                    If drHorario("Dia") <> -1 Then
                        drHorario("Rut Empresa") = Replace(RutLngAUsr(drHorario("rut_cliente")), ".", "")
                        'drHorario("Codigo SENCE") = objcursoContratado.CodSence
                        drHorario("Modulo CFT") = ""
                        'drHorario("Fecha Inicio Accion") = FechaVbAUsr(objcursoContratado.FechaInicio)
                        drHorario("Dia de Clases") = drHorario("Dia")

                        drHorario("Hora Inicio") = drHorario("HoraInicio")
                        drHorario("Hora Termino") = drHorario("HoraFin")

                        'If strTipoOp = "C" Then
                        '    id_acc_cap = objcursoContratado.CodCurso
                        'Else
                        '    id_acc_cap = objcursoContratado.NroRegistro
                        'End If
                    End If
                End If
            Next
            objcursoContratado = Nothing
            dtHorariosCurso.Columns(7).SetOrdinal(0)
            dtHorariosCurso.Columns(8).SetOrdinal(3)
            dtHorariosCurso.Columns.Remove("rut_cliente")
            dtHorariosCurso.Columns.Remove("CodCurso")
            dtHorariosCurso.Columns.Remove("Dia")
            dtHorariosCurso.Columns.Remove("HoraInicio")
            dtHorariosCurso.Columns.Remove("HoraFin")


            '***************************************************************
            '***************************************************************
            '**********************  ALUMNOS  ******************************
            '***************************************************************
            '***************************************************************
            objcursoContratado = New CCursoContratado
            objcursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            dtAlumnos = objcursoContratado.ObtenerAlumnosCsv(mstrCodCursos)
            'intAlumnos = colAlumnos.Count
            dtAlumnos.Columns.Add("Rut Empresa") 'ok
            'dtAlumnos.Columns.Add("Codigo SENCE") 'ok
            dtAlumnos.Columns.Add("Modulo CFT") 'ok
            'dtAlumnos.Columns.Add("Fecha Inicio Accion") 'ok
            dtAlumnos.Columns.Add("Rut Participante")
            dtAlumnos.Columns.Add("Tramo Remuneracion Bruta Mensual")
            dtAlumnos.Columns.Add("Primas")
            dtAlumnos.Columns.Add("Fecha Suscripcion Precontrato")
            dtAlumnos.Columns.Add("Fecha Inicio Precontrato")
            dtAlumnos.Columns.Add("Fecha Termino Precontrato")
            dtAlumnos.Columns.Add("Discapacidad/Vulnerabilidad")
            dtAlumnos.Columns.Add("Fecha Finiquito")
            dtAlumnos.Columns.Add("Monto ultima remuneracion")
            Dim drAlumnos As DataRow


            For Each drAlumnos In dtAlumnos.Rows

                If objcursoContratado.Inicializar1(drAlumnos("cod_curso")) = True Then
                    objcursoContratado.CalcularCostos()
                    objcursoContratado.CalcCostoAdm()
                    drAlumnos("Rut Participante") = Replace(RutLngAUsr(drAlumnos("rut_alumno")), ".", "")
                    dtTerceros = objcursoContratado.Terceros
                    If objcursoContratado.Terceros.Rows.Count > 0 Then
                        Dim drTerceros As DataRow
                        For Each drTerceros In dtTerceros.Rows
                            If drTerceros.Item(5) = 2 And drTerceros.Item(5) = 5 Then
                                drAlumnos("Tramo Remuneracion Bruta Mensual") = 4 'drAlumnos("porc_franquicia") = 4
                            ElseIf drTerceros.Item(5) = 2 Then
                                drAlumnos("Tramo Remuneracion Bruta Mensual") = 4 'drAlumnos("porc_franquicia") = 4
                            ElseIf drTerceros.Item(5) = 5 Then
                                drAlumnos("Tramo Remuneracion Bruta Mensual") = 4 'drAlumnos("porc_franquicia") = 4
                            End If
                        Next
                    Else
                        If drAlumnos("porc_franquicia") = 100 Then
                            drAlumnos("Tramo Remuneracion Bruta Mensual") = 1
                        ElseIf drAlumnos("porc_franquicia") = 50 Then
                            drAlumnos("Tramo Remuneracion Bruta Mensual") = 2
                        ElseIf drAlumnos("porc_franquicia") = 15 Then
                            drAlumnos("Tramo Remuneracion Bruta Mensual") = 3
                        End If

                    End If
                    drAlumnos("Rut Empresa") = Replace(RutLngAUsr(drAlumnos("rut_cliente")), ".", "")
                    'drAlumnos("Codigo SENCE") = objcursoContratado.CodSence
                    drAlumnos("Modulo CFT") = ""
                    'drAlumnos("Fecha Inicio Accion") = FechaVbAUsr(objcursoContratado.FechaInicio)
                    drAlumnos("Primas") = ""
                    If drAlumnos("cod_tipo_activ") = 2 Then
                        drAlumnos("Fecha Suscripcion Precontrato") = "02/01/2000"
                        drAlumnos("Fecha Inicio Precontrato") = "02/01/2000"
                        drAlumnos("Fecha Termino Precontrato") = "02/01/2000"
                        drAlumnos("Discapacidad/Vulnerabilidad") = 0
                    Else
                        drAlumnos("Fecha Suscripcion Precontrato") = ""
                        drAlumnos("Fecha Inicio Precontrato") = ""
                        drAlumnos("Fecha Termino Precontrato") = ""
                        drAlumnos("Discapacidad/Vulnerabilidad") = ""
                    End If
                    If drAlumnos("cod_tipo_activ") = 3 Then
                        drAlumnos("Fecha Finiquito") = "02/01/2000"
                        drAlumnos("Monto ultima remuneracion") = 450000
                    Else
                        drAlumnos("Fecha Finiquito") = ""
                        drAlumnos("Monto ultima remuneracion") = ""
                    End If
                End If

            Next
            objcursoContratado = Nothing

            dtAlumnos.Columns.Remove("cod_curso")
            dtAlumnos.Columns.Remove("rut_cliente")
            dtAlumnos.Columns.Remove("rut_alumno")
            dtAlumnos.Columns.Remove("porc_franquicia")
            dtAlumnos.Columns.Remove("cod_tipo_activ")
            dtAlumnos.Columns(7).SetOrdinal(0)
            dtAlumnos.Columns(8).SetOrdinal(2)
            dtAlumnos.Columns(9).SetOrdinal(4)
            dtAlumnos.Columns(10).SetOrdinal(5)
           


            strNombreArchivo = "Participantes.csv"
            dtAlumnos.TableName = "Horario"
            ConvierteDTaCSV(dtAlumnos, DIRFISICOAPP() & "\contenido\csv\acciones_a_comunicar\", strNombreArchivo)


            strNombreArchivo = "Horario.csv"
            dtHorariosCurso.TableName = "Horario"
            ConvierteDTaCSV(dtHorariosCurso, DIRFISICOAPP() & "\contenido\csv\acciones_a_comunicar\", strNombreArchivo)


            strNombreArchivo = "ComunicacionAcciones.csv"
            dtCursos.TableName = "Cursos"
            ConvierteDTaCSV(dtCursos, DIRFISICOAPP() & "\contenido\csv\acciones_a_comunicar\", strNombreArchivo)

         
            Return True

        Catch ex As Exception
            EnviaError("CComunicarCsv:Consultar-->" & ex.Message)
        End Try
    End Function

End Class
