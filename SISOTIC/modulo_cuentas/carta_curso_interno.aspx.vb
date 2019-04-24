Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_carta_curso_interno
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim intContador As Integer = 1
    Dim objExcel As CGenerarExcel
    Dim objCurso As CCursoInterno
    Dim mobjSql As CSql
    Dim objGeneraFicha As New CGeneraPDF

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            ViewState("correlativo") = Request("correlativo")
            ViewState("agno") = Request("agno")
            If Not Page.IsPostBack Then
                If objSession.EsClienteIngresoCurso Then
                    Me.hplIngresoCurso.Visible = True
                End If
                'If ViewState("generar") = "si" Then
                '    chkGenerar.Visible = False
                '    btnVolver.Visible = False
                '    btnGenerar.Visible = False

                'End If
                btnImprimir.Attributes.Add("onclick", "imprSelec('Carta');")
                lblPie.Text = Parametros.p_PIE
                Consultar()
                ' Me.litCabecera.Text = "<img src='" & Parametros.p_DIRVIRTUALMAIL & "/include/imagenes/css/fondos/reporte01.jpg' alt='Soleduc' title='Cabecera Otic'/>"
                Me.litEstilo.Text = "<link href='" & Parametros.p_DIRVIRTUALMAIL & "/estilo.css' rel='Stylesheet' type='text/css' />"
                '  Me.litLogo.Text = "<img src='" & Parametros.p_DIRVIRTUALMAIL & "/include/imagenes/css/fondos/reporte06.jpg' alt='Soleduc' title='Cabecera Otic'/>"
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            'If ViewState("generar") = "si" Then
            '    Me.ClientScript.RegisterStartupScript(Me.GetType(), "Imprimir", "<script language='javascript' type='text/javascript'> " & _
            '                       "window.print(); " & _
            '                         "</script>")
            'End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("modulo_cuentas_carta_curso_interno:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Private Sub Consultar()
        Try
            objCurso = New CCursoInterno
            mobjSql = New CSql
            objCurso.Inicializar0(mobjSql, objSession.Rut)
            objCurso.Inicializar1(ViewState("correlativo"), ViewState("agno"))

            'cabecera
            Me.lblNombreContacto.Text = objCurso.Ejecutor
            'Me.lblCargoContacto.Text = objCurso.Cliente.CargoContacto
            'Me.lblRazonSocial.Text = objCurso.Cliente.RazonSocial

            Me.lblCorrelativo.Text = objCurso.Correlativo
            If objCurso.CodEstadoCurso = 1 Then
                Me.lblEstadoCurso.Text = "Pendiente"
            ElseIf objCurso.CodEstadoCurso = 2 Then
                Me.lblEstadoCurso.Text = "Anulado"
            ElseIf objCurso.CodEstadoCurso = 3 Then
                Me.lblEstadoCurso.Text = "Cerrado"
            End If
            Me.lblFechaImp.Text = FechaVbAUsr(Date.Now)
            ViewState("dtAlumno") = objCurso.Participantes

            'alumnos
            objWeb.LlenaGrilla(Me.grdListadoAlumnos, objCurso.Participantes)


            'curso
            Me.lblTNombre.Text = objCurso.NombreCurso
            Me.lblTCorrelativo.Text = objCurso.Correlativo
            Me.lblTFechaInicio.Text = objCurso.FechaInicio
            Me.lblTFechaTermino.Text = objCurso.FechaTermino
            Me.lblTDuracion.Text = objCurso.Horas
            Me.lblCursoDirecc.Text = objCurso.DireccionCurso
            Me.lblComuna.Text = objCurso.NombreComuna
            Me.lblTEmpresa.Text = objCurso.NombreCliente
            Me.lblTRutEmpresa.Text = RutLngAUsr(objCurso.RutCliente)
            Me.lblFono.Text = objCurso.Cliente.FonoContacto
            Me.lblObservacion.Text = objCurso.Observacion

            Me.hdfDireccionEmpresa.Value = objCurso.Cliente.Direccion
            Me.hdfGiro.Value = objCurso.Cliente.Giro
            Me.hdfComunaEmpresa.Value = objCurso.Cliente.Comuna

            'valores
            Me.lblTParticipantes.Text = objCurso.NumAlumnos
            Me.lblTDescuento.Text = FormatoPeso(objCurso.Descuento)
            Me.lblTValorFinal.Text = FormatoPeso(objCurso.ValorCurso + objCurso.TotalVyT)

        Catch ex As Exception
            EnviaError("modulo_cuentas_carta_curso_interno:Consultar-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdListadoAlumnos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdListadoAlumnos.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lblContador As Label
                lblContador = CType(e.Row.FindControl("lblContador"), Label)
                lblContador.Text = intContador

                intContador = intContador + 1

                Dim lblCostoOtic As Label
                lblCostoOtic = CType(e.Row.FindControl("lblCostoOtic"), Label)
                lblCostoOtic.Text = FormatoPeso(lblCostoOtic.Text)

            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas_carta_curso_interno:grdListadoAlumnos_RowDataBound-->" & ex.Message)
        End Try
        
    End Sub

    Protected Sub btnGeneraPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraPDF.Click
        Dim filename As String

        objGeneraFicha.CartaCursoInterno(ViewState("dtAlumno"), lblNombreContacto.Text, lblCorrelativo.Text, lblEstadoCurso.Text, _
                                         lblFechaImp.Text, lblTNombre.Text, lblTCorrelativo.Text, lblTFechaInicio.Text, _
                                         lblTFechaTermino.Text, lblTDuracion.Text, lblCursoDirecc.Text, lblComuna.Text, _
                                         lblTEmpresa.Text, lblTRutEmpresa.Text, lblFono.Text, lblObservacion.Text, _
                                         lblTParticipantes.Text, lblTDescuento.Text, lblTValorFinal.Text, Me.hdfDireccionEmpresa.Value, _
                                         Me.hdfGiro.Value, Me.hdfComunaEmpresa.Value)

        filename = "CartaCursoInterno.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
        objGeneraFicha = Nothing
    End Sub
End Class
