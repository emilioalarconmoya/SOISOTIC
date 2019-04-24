Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_resumen
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objLookUps As Clookups
    Dim objSesion As CSession
    Dim objIndicador As CIndicadores
    Dim objChart As CChart
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSesion)
            objWeb = Nothing
            If Not Page.IsPostBack Then
                
                lblPie.Text = Parametros.p_PIE
                objWeb = New CWeb
                objLookUps = New Clookups
                objWeb.SeteaGrilla(Me.grdIndicadores1, TAM_PAG)
                objWeb.LlenaDDL(Me.ddlEjecutivos, objLookUps.Ejecutivo(objSesion.Rut), "rut", "nombres")
                objWeb.AgregaValorDDL(Me.ddlEjecutivos, "", gValorNumNulo)
                objWeb.AgregaValorDDL(Me.ddlEjecutivos, "Cursos propios", 1)
                objWeb.AgregaValorDDL(Me.ddlEjecutivos, "Todos los ejecutivos", 2)
                ddlEjecutivos.SelectedValue = gValorNumNulo
                objWeb.LlenaDDL(Me.ddlAgnos, objLookUps.Agnos2, "Agno_v", "Agno_t")
                ddlAgnos.SelectedValue = objSesion.Agno
                objSesion.Agno = ddlAgnos.SelectedValue
                objWeb = Nothing
                objLookUps = Nothing
                Consultar()
            End If
            Consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos_resumen:Page_Load->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Public Sub Consultar()
        Try
            objIndicador = New CIndicadores
            objIndicador.Agno = Me.ddlAgnos.SelectedValue
            objSesion.Agno = ddlAgnos.SelectedValue
            objIndicador.RutEjecutivo = Me.ddlEjecutivos.SelectedValue
            objIndicador.RutUsuario = objSesion.Rut
            objIndicador.CargaIndicadores()

            If objIndicador.TotalCursos > 0 Then
                objChart = New CChart
                objChart.Alto = 300
                objChart.Ancho = 480
                objChart.TipoChart = 6
                objChart.PreVal = ""
                objChart.PosVal = ""
                objChart.Decimales = 0
                objChart.xAxisName = ""
                objChart.yAxisName = "Número de cursos"
                objChart.DtDatos = objIndicador.Grafico1
                objChart.Titulo = "Resumen de cursos por estado"
                objChart.SubTitulo = "(Haga clic en las columnas si desea ver el detalle)"
                litGrafico1.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")
            Else
                objChart = New CChart
                objChart.Alto = 300
                objChart.Ancho = 480
                objChart.TipoChart = 3
                objChart.PreVal = ""
                objChart.PosVal = ""
                objChart.Decimales = 0
                objChart.xAxisName = ""
                objChart.yAxisName = "Número de cursos"
                objChart.DtDatos = objIndicador.Grafico1
                objChart.Titulo = "Resumen de cursos por estado"
                objChart.SubTitulo = "(Haga clic en las columnas si desea ver el detalle)"
                litGrafico1.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")
            End If

           
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdIndicadores1, objIndicador.Grafico1)
            objWeb = Nothing
            If ViewState("VerMasActivo") = 1 Then
                VerMas()
            End If
        Catch ex As Exception
            EnviaError("modulo_cursos_resumen:Consultar->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdIndicadores1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdIndicadores1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim hpl As HyperLink
                hpl = CType(e.Row.FindControl("hplNumCursos"), HyperLink)
                Dim hdf As HiddenField
                hdf = CType(e.Row.FindControl("hdfEstados"), HiddenField)
                hpl.NavigateUrl = "reporte_cursos.aspx?estados=" & hdf.Value & "&agno=" & Me.ddlAgnos.SelectedValue & "&resumen=si"
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                CType(e.Row.FindControl("lblTotal"), Label).Text = objIndicador.TotalCursos
            End If
        Catch ex As Exception
            EnviaError("modulo_cursos_resumen:RowDataBound->" & ex.Message)
        End Try
    End Sub

    'Protected Sub ddlAgnos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAgnos.SelectedIndexChanged
    '    objSesion.Agno = ddlAgnos.SelectedValue
    'End Sub

    Protected Sub btnVerMas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerMas.Click
        Try
            ViewState("VerMasActivo") = 1
            Grafico2.Visible = True
            btnVerMas.Visible = False
            btnOcultar.Visible = True
            lblAdvertencia.Visible = False
            VerMas()
        Catch ex As Exception
            EnviaError("modulo_cursos_resumen:btnVerMas_Click->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnOcultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOcultar.Click
        Try
            ViewState("VerMasActivo") = 0
            Grafico2.Visible = False
            btnVerMas.Visible = True
            btnOcultar.Visible = False
            lblAdvertencia.Visible = True
        Catch ex As Exception
            EnviaError("modulo_cursos_resumen:btnOcultar_Click->" & ex.Message)
        End Try
        
    End Sub
    Public Sub VerMas()
        Try
            objIndicador = New CIndicadores
            objIndicador.Agno = Me.ddlAgnos.SelectedValue
            objIndicador.RutEjecutivo = Me.ddlEjecutivos.SelectedValue
            objIndicador.RutUsuario = objSesion.Rut
            objIndicador.CargaIndicadores2()
            objChart = New CChart
            objChart.Alto = 500
            objChart.Ancho = 970
            objChart.TipoChart = 12
            objChart.PreVal = ""
            objChart.PosVal = ""
            objChart.Decimales = 0
            objChart.xAxisName = ""
            objChart.yAxisName = "Número de cursos"
            objChart.DtDatos = objIndicador.Grafico2
            objChart.Titulo = "Resumen general de cursos"
            objChart.SubTitulo = "(Haga clic en las columnas si desea ver el detalle)"
            litGrafico2.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv2")
        Catch ex As Exception
            EnviaError("modulo_cursos_resumen:VerMas->" & ex.Message)
        End Try
        
    End Sub
End Class
