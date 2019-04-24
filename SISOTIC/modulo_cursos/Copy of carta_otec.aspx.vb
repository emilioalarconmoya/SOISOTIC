Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_carta_otec
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objGeneraCartaOtec As CGeneraCartaOtec
    Dim objCartaOtec As New CCartaOtec
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
                ' Me.litCabecera.Text = "<img src='" & Parametros.p_DIRVIRTUALMAIL & "/include/imagenes/css/fondos/reporte01.jpg' alt='Soleduc' title='Cabecera Otic'/>"
                Me.litEstilo.Text = "<link href='" & Parametros.p_DIRVIRTUALMAIL & "/estilo.css' rel='Stylesheet' type='text/css' />"
                'Me.litLogo.Text = "<img src='" & Parametros.p_DIRVIRTUALMAIL & "/include/imagenes/css/fondos/reporte06.jpg' alt='Soleduc' title='Cabecera Otic'/>"
                '  Me.litLogo.Text = "<img src='" & Parametros.p_DIRVIRTUALMAIL & "/include/imagenes/css/fondos/reporte06.jpg' alt='Soleduc' title='Cabecera Otic'/>"
                btnImprimir.Attributes.Add("onclick", "imprSelec('Carta');")
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If

                lblTRutOtic.Text = Parametros.p_RUTEMPRESA
                lblTNombreOtic.Text = Parametros.p_NOMBREEMPRESALARGO
                lblTDireccionOtic.Text = Parametros.p_DIRECIONEMPRESA
                lblTGiroOtic.Text = Parametros.p_GIROEMPRESA
                lblTFonoOtic.Text = Parametros.p_FONOEMPRESA
                'lblTFaxOtic.Text = Parametros.p_FAXEMPRESA

                litRequisitos.Text = Replace(Parametros.p_REQUISITOSYCONDICIONES, "__(dirección empresa)_____________", lblDireccCli.Text & " " & lblNroDireccionEmpresa.Text)
               
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
            EnviaError("carta_otec:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Public Sub Consultar()
        Dim lngRut As Long
        Dim lngCodCurso As Long
        lngRut = ViewState("RutUsuario")
        lngCodCurso = ViewState("CodCurso")
        objCartaOtec.BajarHtml = chkGenerar.Checked
        objCartaOtec.Inicializar(lngCodCurso, lngRut)

        Me.hdfComiteBipartito.Value = IIf(objCartaOtec.ComiteBipartito, "SI", "NO")

        hdfFonoCliente.Value = objCartaOtec.FonoContacto
        hdfGiroCliente.Value = objCartaOtec.Giro

        lblNombreContacto.Text = objCartaOtec.ContactoOtec
        lblCargoContacto.Text = objCartaOtec.CargoOtecContacto
        lblRazonSocial.Text = objCartaOtec.RazonSocialOtec
        'lblFax.Text = objCartaOtec.FaxOtecContacto
        lblContactoAd.Text = objCartaOtec.ContactoAdicional
        lblCorrelativo.Text = objCartaOtec.Correlativo
        If objCartaOtec.NumRegistro = -1 Then
            lblNroRegistroSence.Text = "--"
        Else
            lblNroRegistroSence.Text = objCartaOtec.NumRegistro
        End If
        lblModalidad.Text = objCartaOtec.Modalidad
        lblValorHora.Text = objCartaOtec.ValorHora
        If objCartaOtec.CodTipoActiv = 1 Then
            lblCodTipoAct.Text = "Normal"
        ElseIf objCartaOtec.CodTipoActiv = 2 Then
            lblCodTipoAct.Text = "Pre contrato"
        ElseIf objCartaOtec.CodTipoActiv = 2 Then
            lblCodTipoAct.Text = "Post contrato"
        End If
        ViewState("codCursoParcial") = objCartaOtec.CodCursoParcial


        ViewState("codCursoCompl") = objCartaOtec.CodCursoCompl

        If objCartaOtec.CodEstadoCurso = 0 Then
            lblEstadoCurso.Text = "Incompleto"
        ElseIf objCartaOtec.CodEstadoCurso = 1 Then
            lblEstadoCurso.Text = "Ingresado"
        ElseIf objCartaOtec.CodEstadoCurso = 2 Then
            lblEstadoCurso.Text = "Rechazado"
        ElseIf objCartaOtec.CodEstadoCurso = 3 Then
            lblEstadoCurso.Text = "Autorizado"
        ElseIf objCartaOtec.CodEstadoCurso = 4 Then
            lblEstadoCurso.Text = "Comunicado"
        ElseIf objCartaOtec.CodEstadoCurso = 5 Then
            lblEstadoCurso.Text = "Liquidado"
        ElseIf objCartaOtec.CodEstadoCurso = 6 Then
            lblEstadoCurso.Text = "Pago por Autorizar"
        ElseIf objCartaOtec.CodEstadoCurso = 7 Then
            lblEstadoCurso.Text = "En Comunicación"
        ElseIf objCartaOtec.CodEstadoCurso = 8 Then
            lblEstadoCurso.Text = "Eliminado"
        ElseIf objCartaOtec.CodEstadoCurso = 9 Then
            lblEstadoCurso.Text = "En Liquidación"
        ElseIf objCartaOtec.CodEstadoCurso = 10 Then
            lblEstadoCurso.Text = "Anulado"
        ElseIf objCartaOtec.CodEstadoCurso = 11 Then
            lblEstadoCurso.Text = "Ingreso/Modif asistencia"
        End If
        lblNomEjecutivo.Text = objSession.Nombre 'objCartaOtec.NombreEjecCliente
        lblFechaImp.Text = FechaVbAUsr(Date.Now)
        lblNomOtic.Text = Parametros.p_EMPRESA
        lblRazonSocOtic.Text = Parametros.p_NOMBREEMPRESALARGO    'objCartaOtec.RazonSocialOtic
        lblRutOtic.Text = Parametros.p_RUTEMPRESA 'objCartaOtec.RutOtic
        lblDireccOtic.Text = Parametros.p_DIRECIONEMPRESA 'objCartaOtec.DireccionOtic
        lblRazonSocialCli.Text = objCartaOtec.RazonSocialCliente
        lblRutCli.Text = RutLngAUsr(objCartaOtec.RutCliente)
        lblDireccCli.Text = objCartaOtec.DireccionCliente
        lblTNombre.Text = objCartaOtec.NombreCurso
        lblTCorrelativo.Text = objCartaOtec.Correlativo
        lblTFechaInicio.Text = objCartaOtec.FechaInicio
        lblTFechaTermino.Text = objCartaOtec.FechaTermino
        lblTDuracion.Text = objCartaOtec.DuracionCurso
        lblTHoras.Text = objCartaOtec.HorasComplementarias
        lblTCodSence.Text = objCartaOtec.CodigoSence
        If objCartaOtec.NroRegistro = -1 Then
            lblNumRegistro.Text = "-"
        Else
            lblNumRegistro.Text = objCartaOtec.NroRegistro
        End If
        lblTEmpresa.Text = objCartaOtec.RazonSocialCliente
        lblTRutEmpresa.Text = RutLngAUsr(objCartaOtec.RutCliente)

        Me.lblRutEmpresa.Text = RutLngAUsr(objCartaOtec.RutCliente)
        Me.lblNombreEmpresa.Text = objCartaOtec.RazonSocialCliente
        Me.lblDireccionEmpresa.Text = objCartaOtec.DireccionCliente
        Me.lblNroDireccionEmpresa.Text = objCartaOtec.NroDireccionCliente
        Me.lblGiroEmpresa.Text = objCartaOtec.Giro
        If objCartaOtec.FonoContacto = "" Or objCartaOtec.FonoContacto = "0" Then
            Me.lblFonoEmpresa.Text = "-"
        Else
            Me.lblFonoEmpresa.Text = objCartaOtec.FonoContacto
        End If
        'If objCartaOtec.FaxContacto = "" Or objCartaOtec.FaxContacto = "0" Then
        '    Me.lblFaxEmpresa.Text = "-"
        'Else
        '    Me.lblFaxEmpresa.Text = objCartaOtec.FaxContacto
        'End If



        If objCartaOtec.IndDescPorc = 0 Then
            lblTDescuento.Text = objCartaOtec.DescuentoCurso
            lblTDescuento.Text = "$" & lblTDescuento.Text
        ElseIf objCartaOtec.IndDescPorc = 1 Then
            lblTDescuento.Text = objCartaOtec.DescuentoCurso
            lblTDescuento.Text = lblTDescuento.Text & "%"
        End If
        lblTParticipantes.Text = objCartaOtec.NumeroAlumnos
        lblTValorFinal.Text = FormatoPeso(objCartaOtec.CostoOtic - objCartaOtec.DescuentoCurso)
        lblTOtic.Text = objCartaOtec.NombreOtic
        lblTCostoOtic.Text = FormatoPeso(objCartaOtec.CostoOtic)
        lblTGastoEmpresa.Text = FormatoPeso(objCartaOtec.GastoEmpresa)
        lblTTotalValor.Text = FormatoPeso(objCartaOtec.TotalValor)
        lblTCostoOticCompl.Text = FormatoPeso(objCartaOtec.CostoOticCompl)
        lblTAgno.Text = objCartaOtec.FechaInicio.Year + 1
        lblCursoDirecc.Text = objCartaOtec.Direccion
        lblAgno.Text = objCartaOtec.FechaInicio.Year + 1
        lblDireccionOtic.Value = objCartaOtec.DireccionOtic
        lblNroDireccionCurso.Text = objCartaOtec.NroDireccion
        lblComuna.Text = objCartaOtec.Comuna
        If objCartaOtec.Observacion = "" Then
            lblObservacion.Text = "-"
        Else
            lblObservacion.Text = objCartaOtec.Observacion
        End If
        lblOtic2.Value = Parametros.p_EMPRESA.ToUpper
        lblDireccClie.Value = objCartaOtec.DireccionCliente
        lblComunaClie.Value = objCartaOtec.ComunaCliente
        'lblFonoCobranza.Text = objCartaOtec.FonoCobranza
        If objCartaOtec.NombreOtic = "" Then
            lblOtic.Text = Parametros.p_EMPRESA.ToUpper
        Else
            lblOtic.Text = objCartaOtec.NombreOtic.ToUpper
        End If
        If objCartaOtec.ComiteBipartito Then
            ViewState("comite_bipartito") = "si"
        Else
            ViewState("comite_bipartito") = "no"
        End If


        Dim dtAlumno As DataTable
        dtAlumno = objCartaOtec.ListadoAlumnos
        ViewState("alumnos") = dtAlumno
        objWeb.LlenaGrilla(grdListadoAlumnos, dtAlumno)
        LlenaHorario()
        If objCartaOtec.BajarHtml Then
            hplGenerar.Target = "_Blank"
            hplGenerar.Text = "Botón Derecho: ""Guardar Destino Como..."" Puede abrirlo en HTML."
            hplGenerar.NavigateUrl = objCartaOtec.GenerarHtml
            Me.hplGenerar.Visible = True
        End If
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
        dtHorario = objCartaOtec.Horario
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

            Dim lblRut As Label
            lblRut = CType(e.Row.FindControl("lblRut"), Label)
            lblRut.Text = RutLngAUsr(lblRut.Text)

            Dim lblCostoOtic As Label
            lblCostoOtic = CType(e.Row.FindControl("lblCostoOtic"), Label)
            If lblCostoOtic.Text = "" Then
                lblCostoOtic.Text = 0
            Else
                lblCostoOtic.Text = Replace(lblCostoOtic.Text, "$", "")
            End If
            lblCostoOtic.Text = FormatoPeso(lblCostoOtic.Text)

            Dim lblCostoEmpresa As Label
            lblCostoEmpresa = CType(e.Row.FindControl("lblCostoEmpresa"), Label)
            If lblCostoEmpresa.Text = "" Then
                lblCostoEmpresa.Text = 0
            Else
                lblCostoEmpresa.Text = Replace(lblCostoEmpresa.Text, "$", "")
            End If
            lblCostoEmpresa.Text = FormatoPeso(lblCostoEmpresa.Text)

        End If
    End Sub

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Consultar()
    End Sub

    Protected Sub btnGenerarPdf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarPdf.Click

        Dim filename As String
        Dim dtAlumno As DataTable

        dtAlumno = ViewState("alumnos")

        objGeneraCartaOtec = New CGeneraCartaOtec
        objGeneraCartaOtec.CartaOtec(Me.lblNombreContacto.Text, Me.lblCargoContacto.Text, Me.lblRazonSocial.Text, "", Me.lblContactoAd.Text, _
                                     Me.lblCorrelativo.Text, Me.lblEstadoCurso.Text, Me.lblCodTipoAct.Text, Me.lblNomEjecutivo.Text, Me.lblFechaImp.Text, _
                                     dtAlumno, Me.lblNomOtic.Text, Me.lblRazonSocOtic.Text, Me.lblRutOtic.Text, Me.lblDireccOtic.Text, Me.lblRazonSocialCli.Text, _
                                     Me.lblRutCli.Text, Me.lblDireccCli.Text, Me.lblTNombre.Text, Me.lblTCorrelativo.Text, Me.lblTFechaInicio.Text, Me.lblTFechaTermino.Text, _
                                     Me.lblTDuracion.Text, Me.lblTHoras.Text, Me.lblTCodSence.Text, Me.lblCursoDirecc.Text, Me.lblNroDireccionCurso.Text, Me.lblComuna.Text, _
                                     Me.lblNumRegistro.Text, Me.lblTEmpresa.Text, Me.lblTRutEmpresa.Text, Me.lblObservacion.Text, Me.lblTDescuento.Text, Me.lblTParticipantes.Text, Me.lblTValorFinal.Text, _
                                     Me.lblRutEmpresa.Text, Me.lblDireccionEmpresa.Text, Me.lblNroDireccionEmpresa.Text, Me.lblGiroEmpresa.Text, Me.lblFonoEmpresa.Text, _
                                     "", Me.lblTOtic.Text, Me.lblTCostoOtic.Text, Me.lblNombreEmpresa.Text, Me.lblTGastoEmpresa.Text, Me.lblTTotalValor.Text, Me.lblTAgno.Text, _
                                     Me.lblTCostoOticCompl.Text, Me.lblAgno.Text, Me.lblLunes.Text, Me.lblMartes.Text, Me.lblMiercoles.Text, Me.lblJueves.Text, Me.lblViernes.Text, Me.lblSabado.Text, Me.lblDomingo.Text, _
                                     Me.lblDireccionOtic.Value, Me.lblOtic2.Value, Me.lblDireccClie.Value, Me.lblComunaClie.Value, Me.lblOtic.Text, lblModalidad.Text, ViewState("comite_bipartito"), _
                                     ViewState("codCursoParcial"), ViewState("codCursoCompl"), lblValorHora.Text)



        filename = "Carta_OTEC.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile(objGeneraCartaOtec.RutaArchivo)
        Response.End()
        objGeneraCartaOtec = Nothing

       


    End Sub

    Protected Sub btnGenerarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarExcel.Click
        objExcel = New CGenerarExcel
        Dim filename As String
        Try

            objExcel.CartaOtec(Me.lblNombreContacto.Text, Me.lblCargoContacto.Text, Me.lblRazonSocial.Text, "", Me.lblContactoAd.Text, _
                                     Me.lblCorrelativo.Text, Me.lblEstadoCurso.Text, Me.lblCodTipoAct.Text, Me.lblNomEjecutivo.Text, Me.lblFechaImp.Text, _
                                     ViewState("alumnos"), Me.lblNomOtic.Text, Me.lblRazonSocOtic.Text, Me.lblRutOtic.Text, Me.lblDireccOtic.Text, Me.lblRazonSocialCli.Text, _
                                     Me.lblRutCli.Text, Me.lblDireccCli.Text, Me.lblTNombre.Text, Me.lblTCorrelativo.Text, Me.lblTFechaInicio.Text, Me.lblTFechaTermino.Text, _
                                     Me.lblTDuracion.Text, Me.lblTHoras.Text, Me.lblTCodSence.Text, Me.lblCursoDirecc.Text, Me.lblNroDireccionCurso.Text, Me.lblComuna.Text, _
                                     Me.lblNumRegistro.Text, Me.lblTEmpresa.Text, Me.lblTRutEmpresa.Text, Me.lblObservacion.Text, Me.lblTDescuento.Text, Me.lblTParticipantes.Text, Me.lblTValorFinal.Text, _
                                     Me.lblRutEmpresa.Text, Me.lblDireccionEmpresa.Text, Me.lblNroDireccionEmpresa.Text, Me.lblGiroEmpresa.Text, Me.lblFonoEmpresa.Text, _
                                     "", Me.lblTOtic.Text, Me.lblTCostoOtic.Text, Me.lblNombreEmpresa.Text, Me.lblTGastoEmpresa.Text, Me.lblTTotalValor.Text, Me.lblTAgno.Text, _
                                     Me.lblTCostoOticCompl.Text, Me.lblAgno.Text, ViewState("Horario"), _
                                     Me.lblDireccionOtic.Value, Me.lblOtic2.Value, Me.lblDireccClie.Value, Me.lblComunaClie.Value, Me.lblOtic.Text, ViewState("codCursoParcial"), ViewState("codCursoCompl"), _
                                     objSession.Nombre, lblModalidad.Text, hdfComiteBipartito.Value, _
                                     hdfFonoCliente.Value, hdfGiroCliente.Value, Parametros.p_FONOEMPRESA, Parametros.p_GIROEMPRESA, lblValorHora.Text)


        Catch ex As Exception
            EnviaError("carta_otec:btnGenerarExcel_Click-->" & ex.Message)
        End Try
        filename = "CartaOtec.xls"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile(objExcel.RutaArchivo)
        Response.End()
        objExcel = Nothing
    End Sub
End Class
