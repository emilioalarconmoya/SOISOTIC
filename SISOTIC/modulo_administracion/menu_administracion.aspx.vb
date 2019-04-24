Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_menu_administracion
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objSessionCliente As CSession

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        objWeb.ChequeaCliente(objSessionCliente)

        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE

            If objSession.EsEjecutivo And Not objSession.EsAdmin And Not objSession.EsCliente And Not objSession.EsOperaciones _
                                And Not objSession.EsSupervisor And Not objSession.EsDirectorSucursal And Not objSession.EsEjecutivoReg _
                                And Not objSession.EsEjecutivoAutorizacion And Not objSession.EsGestion And Not objSession.EsDirector _
                                And Not objSession.EsFinanzas And Not objSession.EsFinanzaRegiones Then

                'oculta estas opciones del menu administracion 
                Me.li2.Visible = False
                Me.li3.Visible = False
                'Me.li4.Visible = False
                Me.li5.Visible = False
                Me.li6.Visible = False
                Me.li7.Visible = False
                Me.li8.Visible = False
                Me.li9.Visible = False

                'oculta estas opciones del SubMenu del mantenedor
                'Me.li1_3.visible = False
                'Me.li1_4.visible = False
                Me.li1_5.visible = False
                'Me.li1_7.visible = False
                Me.li1_8.visible = False
                Me.li1_9.visible = False
                Me.li1_10.visible = False
                Me.li1_11.visible = False
                Me.li1_12.visible = False
                Me.li1_13.visible = False

            End If


            objSession = Nothing



        End If
    End Sub
End Class
