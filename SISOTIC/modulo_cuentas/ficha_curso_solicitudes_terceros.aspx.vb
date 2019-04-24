Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_curso_solicitudes_terceros
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objGeneraFicha As New CGeneraPDF
    Dim objCursoContratado As New CCursoContratado
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)

        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        ViewState("CodCurso") = Request("codCurso")
        ViewState("RutCliente") = Request("rutCliente")
        '************************************

        If Not Page.IsPostBack Then
            If objSession.EsClienteIngresoCurso Then
                Me.hplIngresoCurso.Visible = True
            End If
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
            objWeb.SeteaGrilla(grdResultados, TAM_PAG)
            Consultar()
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If
        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
    End Sub
    Private Sub Consultar()
        Try
            Dim mobjSql As New CSql
            objCursoContratado.CodCurso = ViewState("CodCurso")
            objCursoContratado.RutCliente = ViewState("RutCliente")
            objCursoContratado.Inicializar0(mobjSql, objSession.Rut)
            objCursoContratado.ObtenerInfoCuentas()
            Dim dt As DataTable
            dt = objCursoContratado.LookUpListaTerceros
            objWeb.LlenaGrilla(grdResultados, dt)
        Catch ex As Exception
            EnviaError("modulo_cursos_curso_solicitudes_terceros-->Consultar" & ex.Message)
        End Try
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim lblRut As Label
                lblRut = CType(e.Row.FindControl("lblRutCliente"), Label)
                lblRut.Text = RutLngAUsr(lblRut.Text)

                Dim hplRazonSocial As HyperLink
                hplRazonSocial = CType(e.Row.FindControl("hplRazonSocial"), HyperLink)
                hplRazonSocial.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & RutUsrALng(lblRut.Text)

                Dim lblReaprtoSolicitado As Label
                lblReaprtoSolicitado = CType(e.Row.FindControl("lblReaprtoSolicitado"), Label)
                lblReaprtoSolicitado.Text = FormatoPeso(lblReaprtoSolicitado.Text)


                Dim lblReaprtoUtilizado As Label
                lblReaprtoUtilizado = CType(e.Row.FindControl("lblReaprtoUtilizado"), Label)
                lblReaprtoUtilizado.Text = FormatoPeso(lblReaprtoUtilizado.Text)

            End If
        Catch ex As Exception
            EnviaError("modulo_cursos_curso_solicitudes_terceros-->grdResultados_RowDataBound" & ex.Message)
        End Try
    End Sub
End Class
