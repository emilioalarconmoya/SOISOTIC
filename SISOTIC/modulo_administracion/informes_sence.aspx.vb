Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_informes_sence
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CReporteFormatoSence
    Dim objLookups As Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                objLookups = New Clookups
                objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
                ddlAgnos.SelectedValue = objSession.Agno
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                objLookups = Nothing
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Public Sub Generar()
        objReporte = New CReporteFormatoSence
        If chkCap.Checked And Not chkRep.Checked And Not chkExcCap.Checked _
        And Not chkExcRep.Checked And Not chkBec.Checked And Not chkApor.Checked And Not chkAporteSence.Checked Then
            objReporte.Tipo = 1
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = True
            objReporte.Consultar()
            If objReporte.Filas > 0 Then
                hplBajar.Target = "_Blank"
                hplBajar.Text = "Descargar archivo"
                hplBajar.NavigateUrl = objReporte.ArchivoXml
                hplBajar.Visible = True
            End If
        ElseIf chkRep.Checked And Not chkCap.Checked And Not chkExcCap.Checked _
        And Not chkExcRep.Checked And Not chkBec.Checked And Not chkApor.Checked And Not chkAporteSence.Checked Then
            objReporte.Tipo = 2
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = True
            objReporte.Consultar()
            If objReporte.Filas > 0 Then
                hplBajar.Target = "_Blank"
                hplBajar.Text = "Descargar archivo"
                hplBajar.NavigateUrl = objReporte.ArchivoXml
                hplBajar.Visible = True
            End If
        ElseIf chkExcCap.Checked And Not chkCap.Checked And Not chkRep.Checked _
        And Not chkExcRep.Checked And Not chkBec.Checked And Not chkApor.Checked And Not chkAporteSence.Checked Then
            objReporte.Tipo = 3
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = True
            objReporte.Consultar()
            If objReporte.Filas > 0 Then
                hplBajar.Target = "_Blank"
                hplBajar.Text = "Descargar archivo"
                hplBajar.NavigateUrl = objReporte.ArchivoXml
                hplBajar.Visible = True
            End If
        ElseIf chkExcRep.Checked And Not chkCap.Checked And Not chkRep.Checked _
        And Not chkExcCap.Checked And Not chkBec.Checked And Not chkApor.Checked And Not chkAporteSence.Checked Then
            objReporte.Tipo = 4
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = True
            objReporte.Consultar()
            If objReporte.Filas > 0 Then
                hplBajar.Target = "_Blank"
                hplBajar.Text = "Descargar archivo"
                hplBajar.NavigateUrl = objReporte.ArchivoXml
                hplBajar.Visible = True
            End If
        ElseIf chkBec.Checked And Not chkCap.Checked And Not chkRep.Checked _
        And Not chkExcCap.Checked And Not chkExcRep.Checked And Not chkApor.Checked And Not chkAporteSence.Checked Then
            objReporte.Tipo = 5
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = True
            objReporte.Consultar()
            If objReporte.Filas > 0 Then
                hplBajar.Target = "_Blank"
                hplBajar.Text = "Descargar archivo"
                hplBajar.NavigateUrl = objReporte.ArchivoXml
                hplBajar.Visible = True
            End If
        ElseIf chkApor.Checked And Not chkCap.Checked And Not chkRep.Checked _
        And Not chkExcCap.Checked And Not chkExcRep.Checked And Not chkBec.Checked And Not chkAporteSence.Checked Then
            objReporte.Tipo = 6
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = True
            objReporte.Consultar()
            If objReporte.Filas > 0 Then
                hplBajar.Target = "_Blank"
                hplBajar.Text = "Descargar archivo"
                hplBajar.NavigateUrl = objReporte.ArchivoXml
                hplBajar.Visible = True
            End If
        ElseIf chkAporteSence.Checked And Not chkCap.Checked And Not chkRep.Checked _
        And Not chkExcCap.Checked And Not chkExcRep.Checked And Not chkBec.Checked And Not chkApor.Checked Then
            objReporte.Tipo = 7
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = True
            objReporte.Consultar()
            If objReporte.Filas > 0 Then
                hplBajar.Target = "_Blank"
                hplBajar.Text = "Descargar archivo"
                hplBajar.NavigateUrl = objReporte.ArchivoXml
                hplBajar.Visible = True
            End If
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar sólo un informe');")
            Exit Sub
        End If
        objReporte = Nothing
    End Sub

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Generar()
    End Sub
End Class
