Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_curso_contratado
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objFactura As New CFactura
    Dim objGeneraFicha As New CGeneraPDF
    Dim objReporteCurso As New CReporteCursos
    Dim objCursoContratado As New CCursoContratado
    Dim objCurso As New CCurso
    Dim objOtec As New COtec
    'Dim objReporte As New CCursoContratado
    Dim objReporte As New CFichaCursoContratado
    Dim objLookups As New Clookups
    Dim ojbCuenta As New CCuenta
    Dim objCliente As New CCliente
    Dim objSql As New CSql
    Dim strEmailEmpresa As String
    Dim strEmailOtec As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)

        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        ViewState("CodCurso") = Request("codCurso")
        ViewState("EstadoCurso") = Request("estadoCur")
        ViewState("RutCliente") = Request("rutCliente")
        ViewState("Origen") = Request("Origen")
        '************************************        
        If Not Page.IsPostBack Then
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
            lblPie.Text = Parametros.p_PIE
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
        End If
        Consultar()
        If objSession.EsCliente Then
            trAdministacion.Visible = False
            Me.btnCambiaAIngresado.Visible = False
            hplFactura.Visible = False
        End If
        If objSession.EsClienteIngresoCurso And objSession.EsCliente Then
            Me.btnVolver.Visible = False
            Me.BtnVolver2.Visible = True
            Me.BtnVolver3.Visible = False
            'Me.hplCartaEmpresa.Visible = False
            'Me.hplCartaOtec.Visible = False
        End If

        ' Me.btnPopupEnviarCorreo.Attributes.Add("onClick", "popup_pos('modulo_cursos/enviar_correo.aspx?emailEmpresa=" & strEmailEmpresa & "&emailOtec=" & strEmailOtec & "&codCurso=" & ViewState("CodCurso") & "&rutUsuario=" & objSession.Rut & "', 'NewWindow1', 600, 900, 100, 100);return false;")
        If ViewState("Origen") = "Aporte" Then
            Me.BtnVolver3.Visible = True
            Me.btnVolver.Visible = False
            Me.BtnVolver2.Visible = False
        Else
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
            Me.BtnVolver3.Visible = False

        End If


        Me.btnCambiaAIngresado.Attributes.Add("onclick", "return confirm('¿Esta seguro que desea cambiar de estado a este curso?. El curso pasará a estado ingresado y los procesos deberán realizarce manualmente, además debe considerar las inconsistencias que pudiese generar este cambio.');")

    End Sub
    Private Sub Consultar()
        Try
            'objReporte = New CCursoContratado
            objReporte = New CFichaCursoContratado
            Dim ccursocontratado As New CCursoContratado

            objReporte.CodCurso = ViewState("CodCurso")
            
            objReporte.RutCliente = objSession.Rut

            objReporte.Consultar()
           
            hplCCFichaCursoCompl.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & objReporte.CodCursoCompl
            hplCCfichaCursoParcial.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & objReporte.CodCursoParcial


            'Me.HyperLink1.NavigateUrl = "../modulo_aporte/aviso_inscripcion_de_cursos.aspx?codCurso=" & objReporte.CodCurso
            hplCartaEmpresa.NavigateUrl = "~/modulo_cursos/carta_empresa.aspx?codCurso=" & objReporte.CodCurso & "&rutUsuario=" & objReporte.RutCliente
            hplCartaOtec.NavigateUrl = "~/modulo_cursos/carta_otec.aspx?CodCurso=" & objReporte.CodCurso & "&rutUsuario=" & objReporte.RutCliente

            'Datos de la empresa
            Me.hplDErazonSocial.Text = objReporte.RazonSocial
            hplDErazonSocial.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & objReporte.RutCliente
            Me.lblDErutEmpresa.Text = RutLngAUsr(objReporte.RutCliente)
            Me.lblDEContacto.Text = objReporte.NombreContacto
            Me.lblDEcargo.Text = objReporte.CargoContacto
            Me.lblDEfono.Text = objReporte.FonoContacto
            Me.lblDEfax.Text = objReporte.FaxContacto
            Me.hplDEemail.Text = objReporte.EmailContacto
            hplDEemail.NavigateUrl = "mailto:" & objReporte.EmailContacto
            strEmailEmpresa = objReporte.EmailContacto

            'datos del otec
            Me.hplDOrazonSocial.Text = objReporte.NombreOtec
            hplDOrazonSocial.NavigateUrl = "ficha_otec.aspx?rutOtec=" & objReporte.RutOtec
            Me.lblDOrutOtec.Text = RutLngAUsr(objReporte.RutOtec)
            If objReporte.ContactoOtec = "" Then
                Me.lblDOcontacto.Text = ""
            Else
                Me.lblDOcontacto.Text = objReporte.ContactoOtec
            End If
            'Me.lblDOcontacto.Text = "" 'objReporte.ContactoOtec
            If objReporte.CargoContacto = "" Then
                Me.lblDOcargo.Text = ""
            Else
                Me.lblDOcargo.Text = objReporte.CargoContacto
            End If
            'Me.lblDOcargo.Text = "" 'objReporte.CargoContacto
            Me.lblDOfono.Text = objReporte.FonoContactoOtec
            Me.lblDOfax.Text = objReporte.FaxContactoOtec
            Me.hplDOemail.Text = objReporte.EmailContactoOtec
            hplDOemail.NavigateUrl = "mailto:" & objReporte.EmailContactoOtec
            strEmailOtec = objReporte.EmailContactoOtec
            'curso
            Me.hplCUnombreCurso.Text = objReporte.NombreCurso
            hplCUnombreCurso.NavigateUrl = "ficha_curso_sence.aspx?codSence=" & objReporte.CodSence
            Me.lblCUcodigosence.Text = objReporte.CodSence
            Me.lblCUhoras.Text = objReporte.Horas
            Me.lblCUdireccion.Text = objReporte.DireccionCurso
            Me.lblCUnumero.Text = objReporte.NroDireccionCurso
            Me.lblCUciudad.Text = objReporte.Ciudad
            Me.lblCUcomuna.Text = objReporte.NombreComuna
            Me.lblCUregion.Text = objReporte.NomRegion
            Me.lblCUfechaInicio.Text = objReporte.FechaInicio
            Me.lblCUfechaTermino.Text = objReporte.FechaTermino
            Me.lblObservacion.Text = objReporte.ObsCurso
            If objReporte.CodElearning > 0 Then
                Me.hplCUverInformacionElearning.Visible = True
            Else
                Me.hplCUverInformacionElearning.Visible = False
            End If
            Me.lblModalidad.Text = objReporte.NombreModalidad

            'costo
            hplCOnumParticipantes.NavigateUrl = "ficha_listado_alumnos.aspx?codCurso=" & objReporte.CodCurso
            Me.lblCOnumParticipantes.Text = objReporte.NumAlumnos
            Me.lblCOvalorCurso.Text = FormatoMonto(objReporte.ValorMercado)
            Me.lblCOtotalviatico.Text = FormatoMonto(objReporte.TotalViatico)
            Me.lblCOtotalTraslado.Text = FormatoMonto(objReporte.TotalTraslado)
            Me.lblCOporcAdmin.Text = FormatoMonto(objReporte.PorcAdm)
            If objReporte.IndAcuComBip = 0 Then
                Me.lblCOcomiteBipartito.Text = "NO"
            Else
                Me.lblCOcomiteBipartito.Text = "SI"
            End If

            If objReporte.IndDetNece = 0 Then
                Me.lblCOdetencionNecesidad.Text = "NO"
            Else
                Me.lblCOdetencionNecesidad.Text = "SI"
            End If

            If objReporte.CodTipoActivo = 2 Then
                Me.lblCOpreContrato.Text = "SI"
            Else
                Me.lblCOpreContrato.Text = "NO"
            End If

            If objReporte.CodTipoActivo = 3 Then
                Me.lblCOposContrato.Text = "SI"
            Else
                Me.lblCOposContrato.Text = "NO"
            End If

            'curso parcial
            Me.lblCPcostoOtic.Text = FormatoMonto(objReporte.CostoOtic)
            Me.lblCPcostoOticVyT.Text = FormatoMonto(objReporte.MontoCtaCapVYT + objReporte.MontoCtaExcCapVYT)
            Me.lblCPtotalCostoOtic.Text = FormatoMonto(objReporte.CostoOtic + objReporte.MontoCtaCapVYT + objReporte.MontoCtaExcCapVYT)

            Me.lblCPgastoEmpresa.Text = FormatoMonto(objReporte.GastoEmpresa)
            Me.lblCPgastoEmpresaVyT.Text = FormatoMonto(objReporte.TotalViatico + objReporte.TotalTraslado - (objReporte.MontoCtaCapVYT + objReporte.MontoCtaExcCapVYT))
            Me.lblCPTotalGastoEmpresa.Text = FormatoMonto(objReporte.GastoEmpresa + objReporte.TotalViatico + objReporte.TotalTraslado - (objReporte.MontoCtaCapVYT + objReporte.MontoCtaExcCapVYT))

            Me.lblCPCostoAdmin.Text = FormatoMonto(objReporte.CostoAdm)
            Me.lblCPcostoAdminVyT.Text = FormatoMonto(objReporte.CostoAdmVYT)
            Me.lblCPTotalCostoAdmin.Text = FormatoMonto(objReporte.CostoAdm + objReporte.CostoAdmVYT)

            Me.lblCPhoras.Text = objReporte.Horas - objReporte.HorasCompl

            Me.lblCPcuentaCap.Text = FormatoMonto(objReporte.MontoCtaCap)
            Me.lblCPTotalesCuentaCapVyT.Text = FormatoMonto(objReporte.MontoCtaCapVYT)
            Me.lblCPtotalCuentaCapacitacion.Text = FormatoMonto(objReporte.MontoCtaCap + objReporte.MontoCtaCapVYT)

            Me.lblCPcuentaExcCap.Text = FormatoMonto(objReporte.MontoCtaExcCap)
            Me.lblCPTotalesCuentaExcCapVyT.Text = FormatoMonto(objReporte.MontoCtaExcCapVYT)
            Me.lblCPtotalCuentaExcCapacitacion.Text = FormatoMonto(objReporte.MontoCtaExcCap + objReporte.MontoCtaExcCapVYT)

            Me.lblCPcuentaBecas.Text = FormatoMonto(objReporte.MontoCtaBecas)
            If objReporte.MontoTercTran <= 0 Then
                Me.lblCPcuentaDeterceros.Visible = True
            Else
                Me.lblCPcuentaDeterceros.Visible = False
            End If
            If objReporte.MontoTercTran > 0 Then
                Me.hplCPcuentaTerceros.Visible = True
                Me.hplCPcuentaTerceros.NavigateUrl = "ficha_curso_solicitudes_terceros.aspx?codCurso=" & objReporte.CodCurso & "&rutCliente=" & objReporte.RutCliente
            Else
                Me.hplCPcuentaTerceros.Visible = False
            End If
            Me.lblCPcuentaTerceros.Text = FormatoMonto(objReporte.MontoTercTran)


            'curso complemantario
            'If objReporte.CodCursoParcial = objReporte.CodCurso Then '-1 Then
            '    Me.lblCCesComplementario.Visible = False
            'Else
            '    Me.lblCCesComplementario.Visible = True
            'End If
            'If objReporte.CodCursoParcial = objReporte.CodCurso Then '-1 Then
            '    Me.hplCCfichaCursoParcial.Visible = False
            'Else
            '    Me.hplCCfichaCursoParcial.Visible = True
            'End If

            If objReporte.CodCursoParcial <> -1 Then '-1 Then
                Me.lblCCesComplementario.Visible = True
            Else
                Me.lblCCesComplementario.Visible = False
            End If
            If objReporte.CodCursoParcial <> -1 Then '-1 Then
                Me.hplCCfichaCursoParcial.Visible = True
            Else
                Me.hplCCfichaCursoParcial.Visible = False
            End If
            If objReporte.HorasCompl > 0 Then
                Me.lblCCoticEstimado.Visible = True
            Else
                Me.lblCCoticEstimado.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCpeso1.Visible = True
            Else
                Me.lblCCpeso1.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCcostoOticEstimado.Visible = True
            Else
                Me.lblCCcostoOticEstimado.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCgEmpresa.Visible = True
            Else
                Me.lblCCgEmpresa.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCpeso2.Visible = True
            Else
                Me.lblCCpeso2.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCgastoEmpresa.Visible = True
            Else
                Me.lblCCgastoEmpresa.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCcAdmin.Visible = True
            Else
                Me.lblCCcAdmin.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCpeso3.Visible = True
            Else
                Me.lblCCpeso3.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCcostoAdmin.Visible = True
            Else
                Me.lblCCcostoAdmin.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCChora.Visible = True
            Else
                Me.lblCChora.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCChoras.Visible = True
            Else
                Me.lblCChoras.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCClistadoCursoCompl.Visible = True
            Else
                Me.lblCClistadoCursoCompl.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCestadoCursoComp.Visible = True
            Else
                Me.lblCCestadoCursoComp.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.lblCCestadoCursoComp.Visible = True
            Else
                Me.lblCCestadoCursoComp.Visible = False
            End If

            If objReporte.HorasCompl > 0 Then
                Me.hplCCFichaCursoCompl.Visible = True
            Else
                Me.hplCCFichaCursoCompl.Visible = False
            End If

            If objReporte.HorasCompl > 0 Or objReporte.CodCursoParcial <> objReporte.CodCurso Then
                Me.lblCCnoEsComplementario.Visible = False
            Else
                Me.lblCCnoEsComplementario.Visible = True
            End If

            Me.lblCCcostoOticEstimado.Text = FormatoMonto(objReporte.CostoOticComplemento)
            Me.lblCCgastoEmpresa.Text = FormatoMonto(objReporte.GastoEmpresaComplemento)
            Me.lblCCcostoAdmin.Text = FormatoMonto(objReporte.CostoAdmComplemento)
            Me.lblCChoras.Text = objReporte.HorasCompl
            objReporte.CodCursoCompl = CLng(objReporte.CodCursoCompl)
            If objReporte.CodCursoCompl > 0 Then
                Me.lblCCestadoCursoComp.Text = NombreEstadoCurso(objReporte.CodEstadoCompl)
            End If

            If objReporte.CodEstadoCurso <> 5 And objReporte.CodEstadoCurso <> 7 And objReporte.CodEstadoCurso <> 8 And objReporte.CodEstadoCurso <> 10 _
                And objSession.TienePermiso(objReporte.NumPerfil, "Mod") And Not objSession.EsCliente And Not objSession.EsClienteIngresoCurso Then
                Me.btnModificar.Visible = True
            Else
                Me.btnModificar.Visible = False
            End If


            objFactura.Inicializar(objSql)
            objFactura.Inicializar2(ViewState("CodCurso"))
            hplFactura.NavigateUrl = "../modulo_aporte/mantenedor_factura.aspx?CodCurso=" & ViewState("CodCurso") & "&EstadosFacturas=" & objFactura.CodEstadoFactura & "&NumFactura=" & objFactura.NumFactura & "&Monto=" & objFactura.Monto _
                                    & "&FechaFactura=" & objFactura.Fecha & "&FechaRecepcion=" & objFactura.FechaRecepcion & "&FechaPago=" & objFactura.FechaPago & "&Observaciones=" & "&Agno=" & Year(objFactura.Fecha)   'MANTENEDOR FACTURA"

            objReporte = Nothing
        Catch ex As Exception
            EnviaError("CFichaCursoContratado-->Consultar" & ex.Message)
        End Try
    End Sub
   

    'Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
    '    Response.Redirect("reporte_cursos_consolidado.aspx")
    'End Sub

    
    Protected Sub btnCambiaAIngresado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiaAIngresado.Click
        Try
            objCursoContratado.CodCurso = ViewState("CodCurso")
            objCursoContratado.CambiarEstIngresado("cambio de estado")
            body.Attributes.Add("onload", "alert('ATENCIÓN: El Curso ha sido cambiado de Estado, de LIQUIDADO a INGRESADO ');")

        Catch ex As Exception
            EnviaError("CFichaCursoContratado--> btnCambiaAIngresado" & ex.Message)
        End Try
    End Sub

    Protected Sub btnPdfCursoContratado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPdfCursoContratado.Click
        Dim filename As String
        objGeneraFicha = New CGeneraPDF
        objGeneraFicha.FichaCursoContratado()

        filename = "Ficha_curso_contratado.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        'Response.AppendHeader("content-disposition", "attachment; filename=CartaEvaluacion.pdf")
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
        objGeneraFicha = Nothing
    End Sub

    Protected Sub BtnVolver2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVolver2.Click
        Response.Redirect("../menu.aspx")
    End Sub
    Protected Sub BtnVolver3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVolver3.Click
        Response.Redirect("../modulo_aporte/resumen.aspx")
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Response.Redirect("../modulo_cursos/mantenedor_cursos.aspx?CodCurso=" & ViewState("CodCurso"))
    End Sub
End Class
