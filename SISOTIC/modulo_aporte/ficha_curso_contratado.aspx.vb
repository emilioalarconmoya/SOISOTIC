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
            ' btnImprimir.Attributes.Add("onclick", "Imprimir();")
            btnImprimir.Attributes.Add("onclick", "imprSelec('Carta');")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
            lblPie.Text = Parametros.p_PIE
            objWeb.SeteaGrilla(Me.grdComentarios, 30, "No se han ingresado comentarios")
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
        End If
        Consultar()
        If objSession.EsCliente Then
            trAdministacion.Visible = False
            Me.btnCambiaAIngresado.Visible = False
            hplFactura.Visible = False
            Me.fupCertificadoAsist.Visible = False
            Me.btnSubirArchivo.Visible = False
        End If
        If objSession.EsClienteIngresoCurso And objSession.EsCliente Then
            Me.btnVolver.Visible = False
            Me.BtnVolver2.Visible = True
            Me.BtnVolver3.Visible = False
            'Me.hplIngresoCurso.Visible = True
            'Me.hplCartaEmpresa.Visible = False
            'Me.hplCartaOtec.Visible = False
        End If
        If ViewState("codEstadoCurso") <> 1 Then
            btnAutorizar.Visible = False
        Else
            btnAutorizar.Visible = True
        End If
        ' Me.btnPopupEnviarCorreo.Attributes.Add("onClick", "popup_pos('modulo_cursos/enviar_correo.aspx?emailEmpresa=" & strEmailEmpresa & "&emailOtec=" & strEmailOtec & "&codCurso=" & ViewState("CodCurso") & "&rutUsuario=" & objSession.Rut & "', 'NewWindow1', 600, 900, 100, 100);return false;")
        If ViewState("Origen") = "factura" Then
            Me.BtnVolver3.Visible = True
            Me.btnVolver.Visible = False
            Me.BtnVolver2.Visible = False
        Else
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
            Me.BtnVolver3.Visible = False

        End If

        body.Attributes.Clear()
        Me.btnCambiaAIngresado.Attributes.Add("onclick", "return confirm('¿Esta seguro que desea cambiar de estado a este curso?. El curso pasará a estado ingresado y los procesos deberán realizarce manualmente, además debe considerar las inconsistencias que pudiese generar este cambio.');")

    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CFichaCursoContratado
            Dim ccursocontratado As New CCursoContratado
            objReporte.CodCurso = ViewState("CodCurso")
            Dim lngCodCurso As Long
            Dim lngRutCliente As Long
            lngCodCurso = ViewState("CodCurso")
            lngRutCliente = objSession.Rut
            objReporte.RutCliente = objSession.Rut
            objReporte.Agno = objSession.Agno
            objReporte.Consultar()
            ViewState("dtAlumnos") = objReporte.Participantes
            hplCCFichaCursoCompl.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & objReporte.CodCursoCompl '& "&estadoCur=" & NombreEstadoCurso(objReporte.CodCursoCompl) & "&rutCliente=" & ViewState("RutCliente")
            hplCCfichaCursoParcial.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & objReporte.CodCursoParcial '& "&estadoCur=" & NombreEstadoCurso(objReporte.CodCursoParcial) & "&rutCliente=" & ViewState("RutCliente")
            Dim lngRut As Long
            lngRut = ViewState("RutCliente")
            ViewState("codEstadoCurso") = objReporte.CodEstadoCurso
            'Datos de la empresa
            Me.hplDErazonSocial.Text = objReporte.RazonSocial
            hplDErazonSocial.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & lngRut
            Me.lblDErutEmpresa.Text = RutLngAUsr(objReporte.RutCliente)
            ViewState("RUT_CLIENTE") = objReporte.RutCliente
            Me.lblDireccionEmpresa.Text = objReporte.DirecccionEmpresa
            hdfComunaEmpresa.Value = objReporte.ComunaEmpresa
            Me.lblDEContacto.Text = objReporte.NombreContacto
            Me.lblDEcargo.Text = objReporte.CargoContacto
            Me.lblDEfono.Text = objReporte.FonoContacto
            'Me.lblDEfax.Text = objReporte.FaxContacto
            Me.hplDEemail.Text = objReporte.EmailContacto
            hplDEemail.NavigateUrl = "mailto:" & objReporte.EmailContacto
            strEmailEmpresa = objReporte.EmailContacto
            'Me.lblCorrelEmp.Text = objReporte.CodCurso

            If objReporte.CorrEmpresa = "" Then
                Me.lblCorrelativoEmpresa.Text = "-"
            Else
                lblCorrelativoEmpresa.Text = objReporte.CorrEmpresa
            End If

            Dim dt As DataTable
            dt = objReporte.BitacoraComentarios

            objWeb.LlenaGrilla(Me.grdComentarios, dt)

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
            'Me.lblDOfax.Text = objReporte.FaxContactoOtec
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
            Me.lblModalidad.Text = objReporte.NombreModalidad
            If objReporte.CodElearning > 0 Then
                Me.hplCUverInformacionElearning.Visible = True
            Else
                Me.hplCUverInformacionElearning.Visible = False
            End If
            Me.lblCorrelativo.Text = objReporte.Correlativo
            Me.lblFecha.Text = FechaVbAUsr(objReporte.FechaModificacion)
            'If Trim(objReporte.CodOrigen) = "0" Then
            '    lblOrigen.Text = "Interno"
            'ElseIf Trim(objReporte.CodOrigen) = "1" Then
            '    lblOrigen.Text = "Cliente"
            'Else
            '    lblOrigen.Text = "--"
            'End If
            ViewState("NroRegistro") = objReporte.NroRegistro
            If objReporte.NroRegistro <> "-1" Then
                Me.lblRegSence.Text = objReporte.NroRegistro
            Else
                Me.lblRegSence.Text = "--"
            End If
            Me.lblFechIngreso.Text = objReporte.FechaIngreso
            If objReporte.CorrelativoComplemento <> -1 Then
                lblCorrelCompl.Text = objReporte.CorrelativoComplemento
            Else
                lblCorrelCompl.Text = "-"
            End If
            Dim strEstado As String
            strEstado = ViewState("EstadoCurso")
            'Me.hplEstado.Text = ViewState("EstadoCurso")
            If objReporte.CodEstadoCurso = 0 Then
                Me.hplEstado.Text = "Incompleto"
            ElseIf objReporte.CodEstadoCurso = 1 Then
                Me.hplEstado.Text = "Ingresado"
            ElseIf objReporte.CodEstadoCurso = 2 Then
                Me.hplEstado.Text = "Rechazado"
            ElseIf objReporte.CodEstadoCurso = 3 Then
                Me.hplEstado.Text = "Autorizado"
            ElseIf objReporte.CodEstadoCurso = 4 Then
                Me.hplEstado.Text = "Comunicado"
            ElseIf objReporte.CodEstadoCurso = 5 Then
                Me.hplEstado.Text = "Liquidado"
            ElseIf objReporte.CodEstadoCurso = 6 Then
                Me.hplEstado.Text = "Pago por Autorizar"
            ElseIf objReporte.CodEstadoCurso = 7 Then
                Me.hplEstado.Text = "En comunicación"
            ElseIf objReporte.CodEstadoCurso = 8 Then
                Me.hplEstado.Text = "Eliminados"
            ElseIf objReporte.CodEstadoCurso = 9 Then
                Me.hplEstado.Text = "En liquidación"
            ElseIf objReporte.CodEstadoCurso = 10 Then
                Me.hplEstado.Text = "Anulados"
            ElseIf objReporte.CodEstadoCurso = 11 Then
                Me.hplEstado.Text = "Con asistencia"
            End If
            hplEstado.NavigateUrl = "reporte_bitacoras.aspx?codCurso=" & lngCodCurso & "&tipo=1" & "&estado=" & hplEstado.Text
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
            If objReporte.NroFacturaOtec = -1 Then
                Me.lblNumFactura.Text = "-"
            Else
                Me.lblNumFactura.Text = objReporte.NroFacturaOtec
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

            hplCartaEmpresa.NavigateUrl = "carta_empresa.aspx?codCurso=" & lngCodCurso & "&rutUsuario=" & lngRutCliente
            hplCartaOtec.NavigateUrl = "carta_otec.aspx?CodCurso=" & lngCodCurso & "&rutUsuario=" & lngRutCliente

            objFactura.Inicializar(objSql)
            objFactura.Inicializar2(lngCodCurso)
            hplFactura.NavigateUrl = "mantenedor_factura.aspx?CodCurso=" & lngCodCurso & "&EstadosFacturas=" & objFactura.CodEstadoFactura & "&NumFactura=" & objFactura.NumFactura & "&Monto=" & objFactura.Monto _
                                    & "&FechaFactura=" & objFactura.Fecha & "&FechaRecepcion=" & objFactura.FechaRecepcion & "&FechaPago=" & objFactura.FechaPago & "&Observaciones=" & "&Agno=" & Year(objFactura.Fecha)   'MANTENEDOR FACTURA"

            If objReporte.CodCursoCompl = -1 Then
                hplCCFichaCursoCompl.Visible = False
            End If

            If System.IO.File.Exists(Server.MapPath("~/contenido/certificados_asistencias/CERTIFICADO_ASISTENCIA_" & ViewState("NroRegistro") & ".pdf")) Then
                Me.lkbtnBajarCertficado.Visible = True
            End If

            If objReporte.EsFinDeSemana Then
                lkbtnAcuerdo.Visible = True
            Else
                lkbtnAcuerdo.Visible = False
            End If


            objReporte = Nothing
        Catch ex As Exception
            EnviaError("modulo_aporte/ficha_curso_contratado-->Consultar" & ex.Message)
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
            EnviaError("modulo_aporte/ficha_curso_contratado--> btnCambiaAIngresado" & ex.Message)
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
        Response.Redirect("resumen.aspx")
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Response.Redirect("mantenedor_cursos.aspx?CodCurso=" & ViewState("CodCurso"))
    End Sub

    Protected Sub btnAgregaComentario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregaComentario.Click
        Try
            objCursoContratado = New CCursoContratado

            objCursoContratado.IngresaBitacoraComentario(objSession.Rut, Me.hplEstado.Text, Me.txtComentarios.Text, ViewState("CodCurso"), ViewState("RutCliente"))
            body.Attributes.Add("onload", "alert('ATENCIÓN: El comentario ha sido ingresado a la bitácora.');")
            objCursoContratado = Nothing
            Consultar()
            Me.txtComentarios.Text = ""
        Catch ex As Exception
            EnviaError("modulo_aporte/ficha_curso_contratado--> btnAgregaComentario_Click" & ex.Message)
        End Try
    End Sub

    Protected Sub btnSubirArchivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubirArchivo.Click
        'verifica si se cargo algún archivo
        If Me.fupCertificadoAsist.HasFile Then
            Try
                Dim savePath As String
                Dim strExtension As String
                Dim strNombreSinExtension As String
                'Toma la Ruta del servidor donde se encuentra la carpeta 
                savePath = Server.MapPath("~/contenido/certificados_asistencias/")
                'verifico que la extension del archivo
                strExtension = System.IO.Path.GetExtension(fupCertificadoAsist.FileName).ToLower()
                strNombreSinExtension = System.IO.Path.GetFileNameWithoutExtension(fupCertificadoAsist.FileName)
                If strExtension = ".pdf" Then
                    'Cocateno el la Ruta del Servidor con el nombre del archivo
                    savePath += "CERTIFICADO_ASISTENCIA_" & ViewState("NroRegistro") & strExtension
                    Dim tempfileName As String
                    tempfileName = ""
                    'Verificamos si el archivo que vamos a subir en la carpeta existe.
                    If (System.IO.File.Exists(savePath)) Then
                        System.IO.File.Delete(savePath)
                    End If
                    fupCertificadoAsist.PostedFile.SaveAs(savePath)

                    body.Attributes.Add("onload", "alert('ATENCIÓN: El archivo ha subido exitosamente');")
                    Consultar()
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El archivo seleccionado debe tener una extension .pdf');")

                End If
            Catch ex As Exception
                EnviaError("modulo_aporte/ficha_curso_contratado--> btnSubirArchivo_Click" & ex.Message)
            End Try
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar un archivo para subir la asistecia');")
        End If
    End Sub

    Protected Sub lkbtnBajarCertficado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkbtnBajarCertficado.Click
        Dim filename As String = "CERTIFICADO_ASISTENCIA_" & ViewState("NroRegistro") & ".pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile("../contenido/certificados_asistencias/CERTIFICADO_ASISTENCIA_" & ViewState("NroRegistro") & ".pdf")
        Response.End()
    End Sub

    Protected Sub lkbtnAcuerdo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkbtnAcuerdo.Click
        Dim filename As String = "ACUERDO_FIN_DE_SEMANA_" & ViewState("CodCurso") & ".pdf"

        objGeneraFicha = New CGeneraPDF
        objGeneraFicha.AFinSemana(ViewState("dtAlumnos"), lblCUfechaInicio.Text, lblCUfechaTermino.Text, _
        lblCUcodigosence.Text, lblRegSence.Text, hplDErazonSocial.Text, lblDErutEmpresa.Text, _
         Right(lblCUfechaInicio.Text, 4), lblDireccionEmpresa.Text, hdfComunaEmpresa.Value)


        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
    End Sub
    Protected Sub GoPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oIraPag As DropDownList = DirectCast(sender, DropDownList)
        Dim iNumPag As Integer = 0
        If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdComentarios.PageCount Then
            If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdComentarios.PageCount Then
                grdComentarios.PageIndex = iNumPag - 1
            Else
                grdComentarios.PageIndex = 0
            End If
        End If
        Call Consultar()
    End Sub

    Protected Sub grdComentarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdComentarios.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            grdComentarios.PageIndex = e.NewPageIndex
            Consultar()
        End If
    End Sub

    Protected Sub grdComentarios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdComentarios.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Pager AndAlso Not grdComentarios.DataSource Is Nothing Then
                'TRAE EL TOTAL DE PAGINAS
                Dim _TotalPags As Label = e.Row.FindControl("lblTotalNumberOfPages")
                _TotalPags.Text = grdComentarios.PageCount.ToString

                'LLENA LA LISTA CON EL NUMERO DE PAGINAS
                Dim list As DropDownList = e.Row.FindControl("paginasDropDownList")
                For i As Integer = 1 To CInt(grdComentarios.PageCount)
                    Dim it As ListItem
                    Dim Existe As Boolean = False
                    For Each it In list.Items
                        If it.Text = i.ToString Then
                            Existe = True
                        End If
                    Next
                    If Not Existe Then
                        list.Items.Add(i.ToString)
                    End If
                Next
                list.SelectedValue = grdComentarios.PageIndex + 1
            End If

        Catch ex As Exception
            EnviaError("modulo_aporte/ficha_curso_contratado--> grdComentarios_RowDataBound" & ex.Message)
        End Try
    End Sub

    Protected Sub btnAutorizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        Try
            objCursoContratado = New CCursoContratado
            objCursoContratado.InicializarCsql(objSql)
            objCursoContratado.CodCurso = ViewState("CodCurso")
            objCursoContratado.RutUsuario = objSession.Rut
            objCursoContratado.RutCliente = ViewState("RUT_CLIENTE")
            objCursoContratado.CodEstadoCurso = ViewState("codEstadoCurso")
            If objCursoContratado.CambiarEstAutorizado("") Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El curso ha sido autorizado.');")
                btnAutorizar.Visible = False
            End If
            Consultar()
        Catch ex As Exception
            EnviaError("modulo_aporte/ficha_curso_contratado--> btnAutorizar_Click" & ex.Message)
        End Try
    End Sub
End Class
