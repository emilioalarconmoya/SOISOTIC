Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_listado_generacion_certificados_aporte
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As New CSession
    Dim objLookups As New Clookups
    Dim mstrBusqueda As String
    Dim objCertificadoAporte As New CCertificadosAporte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("Agno") = Request("Agno")
                ViewState("RutEmpresa") = Request("RutEmpresa")
                ViewState("RazonSocial") = Request("RazonSocial")
                objWeb.LlenaDDL(Me.ddlAgno, objLookups.Agnos2, "Agno_v", "Agno_t")
                Me.ddlAgno.SelectedValue = Now.Year()
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"


        Catch ex As Exception
            EnviaError("listado_generacion_certificados_aporte:Page_Load-->" & ex.Message)

        End Try
    End Sub
    Public Sub Consultar()
        Try
            objCertificadoAporte = New CCertificadosAporte
            objCertificadoAporte.BajarXml = chkBajarReporte.Checked
            If Me.txtRutEmpresa.Text = "" Then
                objCertificadoAporte.Rut = 0
            Else
                objCertificadoAporte.Rut = RutUsrALng(Me.txtRutEmpresa.Text)
            End If
            If Me.txtRazonSocial.Text = "" Then
                objCertificadoAporte.RazonSocial = ""
            Else
                objCertificadoAporte.RazonSocial = Me.txtRazonSocial.Text
            End If
            objCertificadoAporte.Agno = Me.ddlAgno.SelectedValue

            Dim dt As DataTable
            dt = objCertificadoAporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)

            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objCertificadoAporte.ArchivoXml
                Me.hplBajarReporte.Visible = True

            End If
        Catch ex As Exception
            EnviaError("listado_generacion_certificados_aporte:Consultar-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Public Sub GenerarCertificado()
        Try
            objCertificadoAporte = New CCertificadosAporte
            objCertificadoAporte.Agno = Me.ddlAgno.SelectedValue
            objCertificadoAporte.GenerarCertificados()

            If objCertificadoAporte.Filas > 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:Se generaron certificados con exito.');")
            Else
                body.Attributes.Add("onload", "alert('ATENCIÓN:No se genero ningun certificado.');")
            End If
        Catch ex As Exception
            EnviaError("listado_generacion_certificados_aporte:GenerarCertificado-->" & ex.Message)
        End Try
        Response.Redirect("generacion_certificados_aporte.aspx?filas=" & objCertificadoAporte.Filas)
    End Sub

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        GenerarCertificado()
    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click

    End Sub


  
    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim rutEmpresa As Label
            rutEmpresa = CType(e.Row.FindControl("lblRutEmpresa"), Label)
            rutEmpresa.Text = RutLngAUsr(rutEmpresa.Text)
        End If
        
    End Sub
End Class
