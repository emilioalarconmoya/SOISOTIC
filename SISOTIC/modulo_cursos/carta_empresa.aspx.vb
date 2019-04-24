Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_carta_empresa
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objCartaEmpresa As New CCartaEmpresa
    Dim objGeneraFicha As New CGeneraPDF
    Dim intContador As Integer = 1
    Dim objExcel As CGenerarExcel
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            ViewState("CodCurso") = Request("codCurso")
            ViewState("RutUsuario") = Request("rutUsuario")
            ViewState("generar") = Request("generar")
            If Not Page.IsPostBack Then
                If ViewState("generar") = "si" Then
                    chkGenerar.Visible = False
                    btnVolver.Visible = False
                    btnGenerar.Visible = False
                    
                End If
                lblPie.Text = Parametros.p_PIE
                Consultar()
                'Me.litCabecera.Text = "<img src='" & Parametros.p_DIRVIRTUALMAIL & "/include/imagenes/css/fondos/reporte01.jpg' alt='Soleduc' title='Cabecera Otic'/>"
                Me.litEstilo.Text = "<link href='" & Parametros.p_DIRVIRTUALMAIL & "/estilo.css' rel='Stylesheet' type='text/css' />"
                'Me.litLogo.Text = "<img src='" & Parametros.p_DIRVIRTUALMAIL & "/include/imagenes/css/fondos/reporte06.jpg' alt='Soleduc' title='Cabecera Otic'/>"
                btnImprimir.Attributes.Add("onclick", "imprSelec('DivCarta');")
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                

            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            If ViewState("generar") = "si" Then
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "Imprimir", "<script language='javascript' type='text/javascript'> " & _
                                    "window.print(); " & _
                                      "</script>")
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("carta_empresa:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            Dim lngRut As Long
            Dim lngCodCurso As Long
            lngRut = ViewState("RutUsuario")
            lngCodCurso = ViewState("CodCurso")
            objCartaEmpresa.BajarHtml = chkGenerar.Checked
            objCartaEmpresa.Inicializar(lngCodCurso, lngRut)
            If objCartaEmpresa.CodModalidad = 1 Then
                lblModalidad.Text = "Presencial"
            ElseIf objCartaEmpresa.CodModalidad = 2 Then
                lblModalidad.Text = "E-Learning"
            ElseIf objCartaEmpresa.CodModalidad = 3 Then
                lblModalidad.Text = "Auto-Intrucción"
            End If
            If objCartaEmpresa.CodTipoActiv = 1 Then
                ViewState("tipoActividad") = "Normal"
            ElseIf objCartaEmpresa.CodTipoActiv = 2 Then
                ViewState("tipoActividad") = "Pre contrato"
            ElseIf objCartaEmpresa.CodTipoActiv = 3 Then
                ViewState("tipoActividad") = "Post contrato"
            End If
            
            ViewState("codCursoParcial") = objCartaEmpresa.CodCursoParcial

            
            ViewState("codCursoCompl") = objCartaEmpresa.CodCursoCompl

            lblNombreContacto.Text = objCartaEmpresa.ClienteNombreContacto
            lblCargoContacto.Text = objCartaEmpresa.ClienteCargoContacto
            lblRazonSocial.Text = objCartaEmpresa.ClienteRazonSocial
            lblCorrelativo.Text = objCartaEmpresa.Correlativo
            lblRegistroSence.Text = objCartaEmpresa.Numregistro

            If objCartaEmpresa.CodEstadoCurso = 0 Then
                lblEstadoCurso.Text = "Incompleto"
            ElseIf objCartaEmpresa.CodEstadoCurso = 1 Then
                lblEstadoCurso.Text = "Ingresado"
            ElseIf objCartaEmpresa.CodEstadoCurso = 2 Then
                lblEstadoCurso.Text = "Rechazado"
            ElseIf objCartaEmpresa.CodEstadoCurso = 3 Then
                lblEstadoCurso.Text = "Autorizado"
            ElseIf objCartaEmpresa.CodEstadoCurso = 4 Then
                lblEstadoCurso.Text = "Comunicado"
            ElseIf objCartaEmpresa.CodEstadoCurso = 5 Then
                lblEstadoCurso.Text = "Liquidado"
            ElseIf objCartaEmpresa.CodEstadoCurso = 6 Then
                lblEstadoCurso.Text = "Pago por Autorizar"
            ElseIf objCartaEmpresa.CodEstadoCurso = 7 Then
                lblEstadoCurso.Text = "En Comunicacion"
            ElseIf objCartaEmpresa.CodEstadoCurso = 8 Then
                lblEstadoCurso.Text = "Eliminado"
            ElseIf objCartaEmpresa.CodEstadoCurso = 9 Then
                lblEstadoCurso.Text = "En Liquidacion"
            ElseIf objCartaEmpresa.CodEstadoCurso = 10 Then
                lblEstadoCurso.Text = "Anulado"
            ElseIf objCartaEmpresa.CodEstadoCurso = 11 Then
                lblEstadoCurso.Text = "Ingreso/Modif asistencia"
            End If
            If objCartaEmpresa.CorrelativoEmpresa = "" Then
                lblCorrelativoEmp.Text = "-"
            Else
                lblCorrelativoEmp.Text = objCartaEmpresa.CorrelativoEmpresa
            End If

            lblTNombre.Text = objCartaEmpresa.NombreCurso
            lblTCorrelativo.Text = objCartaEmpresa.Correlativo
            lblTFechaInicio.Text = objCartaEmpresa.FechaInicio
            lblTFechaTermino.Text = objCartaEmpresa.FechaTermino
            lbltduracion.Text = objCartaEmpresa.DuracionCurso
            lblCursoDirecc.Text = objCartaEmpresa.DireccionCurso
            lblNroDireccionCurso.Text = objCartaEmpresa.NroDireccion
            lblComuna.Text = objCartaEmpresa.NombreComunaCurso
            lblthoras.Text = objCartaEmpresa.HorasComplementarias
            lblTCodSence.Text = objCartaEmpresa.CodSence
            If objCartaEmpresa.Numregistro = -1 Then
                lblNumRegistro.Text = "-"
            Else
                lblNumRegistro.Text = objCartaEmpresa.Numregistro
            End If
            lblTOtecRazonsocial.Text = objCartaEmpresa.RazonSocialOtec
            lblTotalParticipantes.Text = objCartaEmpresa.Participantes
            If objCartaEmpresa.IndAcuComBip = 1 Then
                lblTBipartito.Text = "Sí"
            Else
                lblTBipartito.Text = "No"
            End If
            If objCartaEmpresa.Observacion = "" Then
                lblObservacion.Text = "-"
            Else
                lblObservacion.Text = objCartaEmpresa.Observacion
            End If

            lblValorHoraSence.Text = objCartaEmpresa.ValorHora


            lblTValorCurso.Text = FormatoPeso(objCartaEmpresa.ValorMercado)
            lblTCostoOtic.Text = FormatoPeso(objCartaEmpresa.CostoOtic)
            lblTCostoOticCom.Text = FormatoPeso(objCartaEmpresa.CostoOticCompl)
            lblTCostoEmpresa.Text = FormatoPeso(objCartaEmpresa.GastoEmpresa)
            lblTotalVyT.Text = FormatoPeso((objCartaEmpresa.Viatico) + (objCartaEmpresa.Traslado))
            If objCartaEmpresa.CostoOticVyT = -1 Then
                lblTCostoOticVyT.Text = FormatoPeso(0)
            Else
                lblTCostoOticVyT.Text = FormatoPeso(objCartaEmpresa.CostoOticVyT)
            End If
            lblTCostoEmpVyT.Text = FormatoPeso(objCartaEmpresa.GastoEmpVyT)
            'lblTCapacitacion.Text = FormatoPeso(objCartaEmpresa.CuentaCap)
            'lblTExcCapacitacion.Text = FormatoPeso(objCartaEmpresa.CuentaExcCap)
            'lblTBecas.Text = FormatoPeso(objCartaEmpresa.Becas)
            'lblTerceros.Text = FormatoPeso(objCartaEmpresa.Terceros)
            If objCartaEmpresa.NombreOtic = "" Then
                lblOtic.Text = Parametros.p_EMPRESA.ToUpper
            Else
                lblOtic.Text = objCartaEmpresa.NombreOtic.ToUpper
            End If

            Dim dtAlumno As DataTable
            dtAlumno = objCartaEmpresa.ListadoAlumnos
            ViewState("dtAlumno") = dtAlumno
            objWeb.LlenaGrilla(grdListadoAlumnos, dtAlumno)
            LlenaHorario()
            If objCartaEmpresa.BajarHtml Then
                hplGenerar.Target = "_Blank"
                hplGenerar.Text = "Botón Derecho: ""Guardar Destino Como..."" Puede abrirlo en HTML."
                hplGenerar.NavigateUrl = objCartaEmpresa.GenerarHtml
                Me.hplGenerar.Visible = True
            End If
        Catch ex As Exception
            EnviaError("carta_empresa:Consultar-->" & ex.Message)
        End Try
        
    End Sub
    Public Sub LlenaHorario()
        Dim lngDia As Long
        Dim dtHorario As New DataTable
        Dim strLunes As String
        Dim strMartes As String
        Dim strMiercoles As String
        Dim strJueves As String
        Dim strViernes As String
        Dim strSabado As String
        Dim strDomingo As String
        dtHorario = objCartaEmpresa.Horario
        ViewState("Horario") = dtHorario
        Dim dr As DataRow
        For Each dr In dtHorario.Rows
            lngDia = dr.Item(1)
            If lngDia = 1 Then
                strLunes = strLunes & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 2 Then
                strMartes = strMartes & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 3 Then
                strMiercoles = strMiercoles & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 4 Then
                strJueves = strJueves & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 5 Then
                strViernes = strViernes & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 6 Then
                strSabado = strSabado & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
            If lngDia = 7 Then
                strDomingo = strDomingo & dr.Item(2) & "-" & dr.Item(3) & "<br>"
            End If
        Next
        lblLunes.Text = strLunes
        lblMartes.Text = strMartes
        lblMiercoles.Text = strMiercoles
        lblJueves.Text = strJueves
        lblViernes.Text = strViernes
        lblSabado.Text = strSabado
        lblDomingo.Text = strDomingo
    End Sub
    Protected Sub grdListadoAlumnos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdListadoAlumnos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblContador As Label
            lblContador = CType(e.Row.FindControl("lblContador"), Label)
            lblContador.Text = intContador

            intContador = intContador + 1

            Dim lngCostoOtic As Long
            Dim lngCostoEmpresa As Long
            Dim lngTotal As Long

            Dim lblRut As Label
            lblRut = CType(e.Row.FindControl("lblRut"), Label)
            lblRut.Text = RutLngAUsr(lblRut.Text)

            Dim lblFecha As Label
            lblFecha = CType(e.Row.FindControl("lblFechNac"), Label)
            lblFecha.Text = FechaVbAUsr(lblFecha.Text)

            Dim lblCostoOtic As Label
            lblCostoOtic = CType(e.Row.FindControl("lblCostoOtic"), Label)
            lngCostoOtic = lblCostoOtic.Text
            If lblCostoOtic.Text = "" Then
                lblCostoOtic.Text = 0
            Else
                lblCostoOtic.Text = Replace(lblCostoOtic.Text, "$", "")
            End If
            lblCostoOtic.Text = FormatoPeso(lblCostoOtic.Text)

            Dim lblCostoEmpresa As Label
            lblCostoEmpresa = CType(e.Row.FindControl("lblCostoEmp"), Label)
            lngCostoEmpresa = lblCostoEmpresa.Text
            If lblCostoEmpresa.Text = "" Then
                lblCostoEmpresa.Text = 0
            Else
                lblCostoEmpresa.Text = Replace(lblCostoEmpresa.Text, "$", "")
            End If
            lblCostoEmpresa.Text = FormatoPeso(lblCostoEmpresa.Text)

            Dim lblTotal As Label
            lngTotal = lngCostoOtic + lngCostoEmpresa
            lblTotal = CType(e.Row.FindControl("lblTotal"), Label)
            If lblTotal.Text = "" Then
                lblTotal.Text = 0
            Else
                lblTotal.Text = Replace(lblTotal.Text, "$", "")
            End If
            lblTotal.Text = FormatoPeso(lngTotal)

            Dim lblViatico As Label
            lblViatico = CType(e.Row.FindControl("lblViatico"), Label)
            If lblViatico.Text = "" Then
                lblViatico.Text = 0
            Else
                lblViatico.Text = Replace(lblViatico.Text, "$", "")
            End If
            lblViatico.Text = FormatoPeso(lblViatico.Text)

            Dim lblTraslado As Label
            lblTraslado = CType(e.Row.FindControl("lblTraslado"), Label)
            If lblTraslado.Text = "" Then
                lblTraslado.Text = 0
            Else
                lblTraslado.Text = Replace(lblTraslado.Text, "$", "")
            End If
            lblTraslado.Text = FormatoPeso(lblTraslado.Text)


            Dim lblTotalVyT As Label
            lblTotalVyT = CType(e.Row.FindControl("lblTotalVyT"), Label)
            lblTotalVyT.Text = FormatoPeso(CLng(Replace(Replace(lblTraslado.Text, "$", ""), ".", "")) + CLng(Replace(Replace(lblViatico.Text, "$", ""), ".", "")))


        End If
    End Sub

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Consultar()
        ViewState("generar") = "si"
    End Sub

    Protected Sub btnPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        GenerarPDF()
    End Sub
    Private Sub GenerarPDF()
        Dim filename As String

        objGeneraFicha.CartaEmpresa(ViewState("dtAlumno"), ViewState("CodCurso"), lblModalidad.Text, lblNombreContacto.Text, lblCargoContacto.Text, lblRazonSocial.Text, _
                                    lblCorrelativo.Text, lblRegistroSence.Text, lblEstadoCurso.Text, lblTNombre.Text, _
                                    lblTCorrelativo.Text, lblTFechaInicio.Text, lblTFechaTermino.Text, lbltduracion.Text, _
                                    lblCursoDirecc.Text, lblNroDireccionCurso.Text, lblComuna.Text, lblthoras.Text, _
                                    lblTCodSence.Text, lblTOtecRazonsocial.Text, lblTotalParticipantes.Text, lblTBipartito.Text, _
                                    lblObservacion.Text, lblTValorCurso.Text, lblTCostoOtic.Text, lblTCostoOticCom.Text, _
                                    lblTCostoEmpresa.Text, lblTotalVyT.Text, lblTCostoOticVyT.Text, lblTCostoEmpVyT.Text, _
                                    "", "", "", "", _
                                    lblOtic.Text, lblNumRegistro.Text, Me.lblLunes.Text, lblMartes.Text, lblMiercoles.Text, _
                                    lblJueves.Text, lblViernes.Text, lblSabado.Text, lblDomingo.Text, ViewState("tipoActividad"), objSession.Nombre, _
                                    FechaVbAUsr(Date.Now), ViewState("codCursoParcial"), ViewState("codCursoCompl"), lblValorHoraSence.Text, _
                                     lblCorrelativoEmp.Text.Trim)

        filename = "CartaEmpresa.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
        objGeneraFicha = Nothing
    End Sub

    Protected Sub btnCartaExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCartaExcel.Click
        objExcel = New CGenerarExcel
        Dim filename As String
        Try

            objExcel.CartaEmpresa(ViewState("dtAlumno"), ViewState("CodCurso"), lblModalidad.Text, lblNombreContacto.Text, lblCargoContacto.Text, lblRazonSocial.Text, _
                                    lblCorrelativo.Text, lblRegistroSence.Text, lblEstadoCurso.Text, lblTNombre.Text, _
                                    lblTCorrelativo.Text, lblTFechaInicio.Text, lblTFechaTermino.Text, lbltduracion.Text, _
                                    lblCursoDirecc.Text, lblNroDireccionCurso.Text, lblComuna.Text, lblthoras.Text, _
                                    lblTCodSence.Text, lblTOtecRazonsocial.Text, lblTotalParticipantes.Text, lblTBipartito.Text, _
                                    lblObservacion.Text, lblTValorCurso.Text, lblTCostoOtic.Text, lblTCostoOticCom.Text, _
                                    lblTCostoEmpresa.Text, lblTotalVyT.Text, lblTCostoOticVyT.Text, lblTCostoEmpVyT.Text, _
                                    "", "", "", "", _
                                    lblOtic.Text, lblNumRegistro.Text, ViewState("Horario"), ViewState("codCursoParcial"), ViewState("codCursoCompl"), _
                                    objSession.Nombre, lblValorHoraSence.Text, lblCorrelativoEmp.Text.Trim)


        Catch ex As Exception
            EnviaError("carta_empresa:btnCartaExcel_Click-->" & ex.Message)
        End Try
        filename = "CartaEmpresa.xls"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile(objExcel.RutaArchivo)
        Response.End()
        objExcel = Nothing
    End Sub
End Class
