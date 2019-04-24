Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_buscador_cursos
    Inherits System.Web.UI.Page
    Dim mstrBusqueda As String
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)

        Me.txtCorrelativo.Attributes.Add("onFocus", "if (document.form1.rbCorrelativo1.checked == true ) " _
                                                    & "{document.form1.rbCorrelativo1.checked = false; " _
                                                   & "document.form1.rbCorrelativo2.checked = true; " _
                                                   & "document.form1.rbCorrelEmp1.checked = true; " _
                                                   & "document.form1.rbCorrelEmp2.checked = false; " _
                                                   & "document.form1.rbCorrelEmp3.checked = false; " _
                                                   & "document.form1.rbCorrelEmp4.checked = false; " _
                                                   & "document.form1.rbCorrelEmp5.checked = false; " _
                                                   & "document.form1.rbCodigoCurso1.checked = true; " _
                                                   & "document.form1.rbCodigoCurso2.checked = false; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbNroRegistro1.checked = true; " _
                                                   & "document.form1.rbNroRegistro2.checked = false; " _
                                                   & "document.form1.rbNroRegistro3.checked = false; " _
                                                   & "document.form1.rbNroRegistro4.checked = false; " _
                                                   & "document.form1.rbNroRegistro5.checked = false; " _
                                                   & "document.form1.rbNroVoucher1.checked = true; " _
                                                   & "document.form1.rbNroVoucher2.checked = false; " _
                                                   & "document.form1.rbNroVoucher3.checked = false; " _
                                                   & "document.form1.rbNroVoucher4.checked = false; " _
                                                   & "document.form1.rbNroVoucher5.checked = false; " _
                                                   & "document.form1.rbOrdenCompra1.checked = true; " _
                                                   & "document.form1.rbOrdenCompra2.checked = false; " _
                                                   & "document.form1.rbOrdenCompra3.checked = false; " _
                                                   & "document.form1.rbOrdenCompra4.checked = false; " _
                                                   & "document.form1.rbOrdenCompra5.checked = false; " _
                                                   & "document.form1.rbFechaIngreso1.checked = true; " _
                                                   & "document.form1.rbFechaIngreso2.checked = false; " _
                                                   & "document.form1.rbFechaIngreso3.checked = false; " _
                                                   & "document.form1.rbFechaIngreso4.checked = false; " _
                                                   & "document.form1.rbFechaIngreso5.checked = false; " _
                                                   & "document.form1.rbRutEmpresa1.checked = true; " _
                                                   & "document.form1.rbRutEmpresa2.checked = false; " _
                                                   & "document.form1.rbRutEmpresa3.checked = false; " _
                                                   & "document.form1.rbRutEmpresa4.checked = false; " _
                                                   & "document.form1.rbRutEmpresa5.checked = false; }")

        Me.txtCodigoCurso.Attributes.Add("onFocus", "if (document.form1.rbCodigoCurso1.checked == true){ " _
                                                   & "document.form1.rbCodigoCurso1.checked = false; " _
                                                   & "document.form1.rbCodigoCurso2.checked = true; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbCorrelEmp1.checked = true; " _
                                                   & "document.form1.rbCorrelEmp2.checked = false; " _
                                                   & "document.form1.rbCorrelEmp3.checked = false; " _
                                                   & "document.form1.rbCorrelEmp4.checked = false; " _
                                                   & "document.form1.rbCorrelEmp5.checked = false; " _
                                                   & "document.form1.rbNroRegistro1.checked = true; " _
                                                   & "document.form1.rbNroRegistro2.checked = false; " _
                                                   & "document.form1.rbNroRegistro3.checked = false; " _
                                                   & "document.form1.rbNroRegistro4.checked = false; " _
                                                   & "document.form1.rbNroRegistro5.checked = false; " _
                                                   & "document.form1.rbNroVoucher1.checked = true; " _
                                                   & "document.form1.rbNroVoucher2.checked = false; " _
                                                   & "document.form1.rbNroVoucher3.checked = false; " _
                                                   & "document.form1.rbNroVoucher4.checked = false; " _
                                                   & "document.form1.rbNroVoucher5.checked = false; " _
                                                   & "document.form1.rbOrdenCompra1.checked = true; " _
                                                   & "document.form1.rbOrdenCompra2.checked = false; " _
                                                   & "document.form1.rbOrdenCompra3.checked = false; " _
                                                   & "document.form1.rbOrdenCompra4.checked = false; " _
                                                   & "document.form1.rbOrdenCompra5.checked = false; " _
                                                   & "document.form1.rbFechaIngreso1.checked = true; " _
                                                   & "document.form1.rbFechaIngreso2.checked = false; " _
                                                   & "document.form1.rbFechaIngreso3.checked = false; " _
                                                   & "document.form1.rbFechaIngreso4.checked = false; " _
                                                   & "document.form1.rbFechaIngreso5.checked = false; " _
                                                   & "document.form1.rbRutEmpresa1.checked = true; " _
                                                   & "document.form1.rbRutEmpresa2.checked = false; " _
                                                   & "document.form1.rbRutEmpresa3.checked = false; " _
                                                   & "document.form1.rbRutEmpresa4.checked = false; " _
                                                   & "document.form1.rbRutEmpresa5.checked = false; }")

        Me.txtCorrelativoEmp.Attributes.Add("onFocus", "if (document.form1.rbCorrelEmp1.checked == true ) " _
                                                    & "{document.form1.rbCorrelEmp1.checked = false; " _
                                                    & "document.form1.rbCorrelEmp2.checked = true;}" _
                                                    & "document.form1.rbCorrelativo1.checked = true; " _
                                                   & "document.form1.rbCorrelativo2.checked = false; " _
                                                   & "document.form1.rbCorrelativo3.checked = false; " _
                                                   & "document.form1.rbCorrelativo4.checked = false; " _
                                                   & "document.form1.rbCorrelativo5.checked = false; " _
                                                   & "document.form1.rbCodigoCurso1.checked = true; " _
                                                   & "document.form1.rbCodigoCurso2.checked = false; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbNroRegistro1.checked = true; " _
                                                   & "document.form1.rbNroRegistro2.checked = false; " _
                                                   & "document.form1.rbNroRegistro3.checked = false; " _
                                                   & "document.form1.rbNroRegistro4.checked = false; " _
                                                   & "document.form1.rbNroRegistro5.checked = false; " _
                                                   & "document.form1.rbNroVoucher1.checked = true; " _
                                                   & "document.form1.rbNroVoucher2.checked = false; " _
                                                   & "document.form1.rbNroVoucher3.checked = false; " _
                                                   & "document.form1.rbNroVoucher4.checked = false; " _
                                                   & "document.form1.rbNroVoucher5.checked = false; " _
                                                   & "document.form1.rbOrdenCompra1.checked = true; " _
                                                   & "document.form1.rbOrdenCompra2.checked = false; " _
                                                   & "document.form1.rbOrdenCompra3.checked = false; " _
                                                   & "document.form1.rbOrdenCompra4.checked = false; " _
                                                   & "document.form1.rbOrdenCompra5.checked = false; " _
                                                   & "document.form1.rbFechaIngreso1.checked = true; " _
                                                   & "document.form1.rbFechaIngreso2.checked = false; " _
                                                   & "document.form1.rbFechaIngreso3.checked = false; " _
                                                   & "document.form1.rbFechaIngreso4.checked = false; " _
                                                   & "document.form1.rbFechaIngreso5.checked = false; " _
                                                   & "document.form1.rbRutEmpresa1.checked = true; " _
                                                   & "document.form1.rbRutEmpresa2.checked = false; " _
                                                   & "document.form1.rbRutEmpresa3.checked = false; " _
                                                   & "document.form1.rbRutEmpresa4.checked = false; " _
                                                   & "document.form1.rbRutEmpresa5.checked = false;")

        Me.txtNroRegistro.Attributes.Add("onFocus", " if (document.form1.rbNroRegistro1.checked == true ) " _
                                                    & "{document.form1.rbNroRegistro1.checked = false; " _
                                                    & "document.form1.rbNroRegistro2.checked = true;}" _
                                                    & "document.form1.rbCorrelativo1.checked = true; " _
                                                   & "document.form1.rbCorrelativo2.checked = false; " _
                                                   & "document.form1.rbCorrelativo3.checked = false; " _
                                                   & "document.form1.rbCorrelativo4.checked = false; " _
                                                   & "document.form1.rbCorrelativo5.checked = false; " _
                                                   & "document.form1.rbCodigoCurso1.checked = true; " _
                                                   & "document.form1.rbCodigoCurso2.checked = false; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbNroVoucher1.checked = true; " _
                                                   & "document.form1.rbNroVoucher2.checked = false; " _
                                                   & "document.form1.rbNroVoucher3.checked = false; " _
                                                   & "document.form1.rbNroVoucher4.checked = false; " _
                                                   & "document.form1.rbNroVoucher5.checked = false; " _
                                                   & "document.form1.rbCorrelEmp1.checked = true; " _
                                                   & "document.form1.rbCorrelEmp2.checked = false; " _
                                                   & "document.form1.rbCorrelEmp3.checked = false; " _
                                                   & "document.form1.rbCorrelEmp4.checked = false; " _
                                                   & "document.form1.rbCorrelEmp5.checked = false; " _
                                                   & "document.form1.rbOrdenCompra1.checked = true; " _
                                                   & "document.form1.rbOrdenCompra2.checked = false; " _
                                                   & "document.form1.rbOrdenCompra3.checked = false; " _
                                                   & "document.form1.rbOrdenCompra4.checked = false; " _
                                                   & "document.form1.rbOrdenCompra5.checked = false; " _
                                                   & "document.form1.rbFechaIngreso1.checked = true; " _
                                                   & "document.form1.rbFechaIngreso2.checked = false; " _
                                                   & "document.form1.rbFechaIngreso3.checked = false; " _
                                                   & "document.form1.rbFechaIngreso4.checked = false; " _
                                                   & "document.form1.rbFechaIngreso5.checked = false; " _
                                                   & "document.form1.rbRutEmpresa1.checked = true; " _
                                                   & "document.form1.rbRutEmpresa2.checked = false; " _
                                                   & "document.form1.rbRutEmpresa3.checked = false; " _
                                                   & "document.form1.rbRutEmpresa4.checked = false; " _
                                                   & "document.form1.rbRutEmpresa5.checked = false; ")

        Me.txtNroVoucher.Attributes.Add("onFocus", " if (document.form1.rbNroVoucher1.checked == true ) " _
                                                    & "{document.form1.rbNroVoucher1.checked = false; " _
                                                    & "document.form1.rbNroVoucher2.checked = true;}" _
                                                    & "document.form1.rbCorrelativo1.checked = true; " _
                                                   & "document.form1.rbCorrelativo2.checked = false; " _
                                                   & "document.form1.rbCorrelativo3.checked = false; " _
                                                   & "document.form1.rbCorrelativo4.checked = false; " _
                                                   & "document.form1.rbCorrelativo5.checked = false; " _
                                                   & "document.form1.rbCodigoCurso1.checked = true; " _
                                                   & "document.form1.rbCodigoCurso2.checked = false; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbNroRegistro1.checked = true; " _
                                                   & "document.form1.rbNroRegistro2.checked = false; " _
                                                   & "document.form1.rbNroRegistro3.checked = false; " _
                                                   & "document.form1.rbNroRegistro4.checked = false; " _
                                                   & "document.form1.rbNroRegistro5.checked = false; " _
                                                   & "document.form1.rbCorrelEmp1.checked = true; " _
                                                   & "document.form1.rbCorrelEmp2.checked = false; " _
                                                   & "document.form1.rbCorrelEmp3.checked = false; " _
                                                   & "document.form1.rbCorrelEmp4.checked = false; " _
                                                   & "document.form1.rbCorrelEmp5.checked = false; " _
                                                   & "document.form1.rbOrdenCompra1.checked = true; " _
                                                   & "document.form1.rbOrdenCompra2.checked = false; " _
                                                   & "document.form1.rbOrdenCompra3.checked = false; " _
                                                   & "document.form1.rbOrdenCompra4.checked = false; " _
                                                   & "document.form1.rbOrdenCompra5.checked = false; " _
                                                   & "document.form1.rbFechaIngreso1.checked = true; " _
                                                   & "document.form1.rbFechaIngreso2.checked = false; " _
                                                   & "document.form1.rbFechaIngreso3.checked = false; " _
                                                   & "document.form1.rbFechaIngreso4.checked = false; " _
                                                   & "document.form1.rbFechaIngreso5.checked = false; " _
                                                   & "document.form1.rbRutEmpresa1.checked = true; " _
                                                   & "document.form1.rbRutEmpresa2.checked = false; " _
                                                   & "document.form1.rbRutEmpresa3.checked = false; " _
                                                   & "document.form1.rbRutEmpresa4.checked = false; " _
                                                   & "document.form1.rbRutEmpresa5.checked = false; ")

        Me.txtOrdenCompra.Attributes.Add("onFocus", " if (document.form1.rbOrdenCompra1.checked == true ) " _
                                                    & "{document.form1.rbOrdenCompra1.checked = false; " _
                                                    & "document.form1.rbOrdenCompra2.checked = true;}" _
                                                    & "document.form1.rbCorrelativo1.checked = true; " _
                                                   & "document.form1.rbCorrelativo2.checked = false; " _
                                                   & "document.form1.rbCorrelativo3.checked = false; " _
                                                   & "document.form1.rbCorrelativo4.checked = false; " _
                                                   & "document.form1.rbCorrelativo5.checked = false; " _
                                                   & "document.form1.rbCodigoCurso1.checked = true; " _
                                                   & "document.form1.rbCodigoCurso2.checked = false; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbCorrelEmp1.checked = true; " _
                                                   & "document.form1.rbCorrelEmp2.checked = false; " _
                                                   & "document.form1.rbCorrelEmp3.checked = false; " _
                                                   & "document.form1.rbCorrelEmp4.checked = false; " _
                                                   & "document.form1.rbCorrelEmp5.checked = false; " _
                                                   & "document.form1.rbNroRegistro1.checked = true; " _
                                                   & "document.form1.rbNroRegistro2.checked = false; " _
                                                   & "document.form1.rbNroRegistro3.checked = false; " _
                                                   & "document.form1.rbNroRegistro4.checked = false; " _
                                                   & "document.form1.rbNroRegistro5.checked = false; " _
                                                   & "document.form1.rbNroVoucher1.checked = true; " _
                                                   & "document.form1.rbNroVoucher2.checked = false; " _
                                                   & "document.form1.rbNroVoucher3.checked = false; " _
                                                   & "document.form1.rbNroVoucher4.checked = false; " _
                                                   & "document.form1.rbNroVoucher5.checked = false; " _
                                                   & "document.form1.rbFechaIngreso1.checked = true; " _
                                                   & "document.form1.rbFechaIngreso2.checked = false; " _
                                                   & "document.form1.rbFechaIngreso3.checked = false; " _
                                                   & "document.form1.rbFechaIngreso4.checked = false; " _
                                                   & "document.form1.rbFechaIngreso5.checked = false; " _
                                                   & "document.form1.rbRutEmpresa1.checked = true; " _
                                                   & "document.form1.rbRutEmpresa2.checked = false; " _
                                                   & "document.form1.rbRutEmpresa3.checked = false; " _
                                                   & "document.form1.rbRutEmpresa4.checked = false; " _
                                                   & "document.form1.rbRutEmpresa5.checked = false; ")

        Me.txtFechaIngreso.Attributes.Add("onFocus", "if (document.form1.rbFechaIngreso1.checked == true ) " _
                                                    & "{document.form1.rbFechaIngreso1.checked = false; " _
                                                    & "document.form1.rbFechaIngreso2.checked = true;}" _
                                                    & "document.form1.rbCorrelativo1.checked = true; " _
                                                   & "document.form1.rbCorrelativo2.checked = false; " _
                                                   & "document.form1.rbCorrelativo3.checked = false; " _
                                                   & "document.form1.rbCorrelativo4.checked = false; " _
                                                   & "document.form1.rbCorrelativo5.checked = false; " _
                                                   & "document.form1.rbCodigoCurso1.checked = true; " _
                                                   & "document.form1.rbCodigoCurso2.checked = false; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbCorrelEmp1.checked = true; " _
                                                   & "document.form1.rbCorrelEmp2.checked = false; " _
                                                   & "document.form1.rbCorrelEmp3.checked = false; " _
                                                   & "document.form1.rbCorrelEmp4.checked = false; " _
                                                   & "document.form1.rbCorrelEmp5.checked = false; " _
                                                   & "document.form1.rbNroRegistro1.checked = true; " _
                                                   & "document.form1.rbNroRegistro2.checked = false; " _
                                                   & "document.form1.rbNroRegistro3.checked = false; " _
                                                   & "document.form1.rbNroRegistro4.checked = false; " _
                                                   & "document.form1.rbNroRegistro5.checked = false; " _
                                                   & "document.form1.rbNroVoucher1.checked = true; " _
                                                   & "document.form1.rbNroVoucher2.checked = false; " _
                                                   & "document.form1.rbNroVoucher3.checked = false; " _
                                                   & "document.form1.rbNroVoucher4.checked = false; " _
                                                   & "document.form1.rbNroVoucher5.checked = false; " _
                                                   & "document.form1.rbOrdenCompra1.checked = true; " _
                                                   & "document.form1.rbOrdenCompra2.checked = false; " _
                                                   & "document.form1.rbOrdenCompra3.checked = false; " _
                                                   & "document.form1.rbOrdenCompra4.checked = false; " _
                                                   & "document.form1.rbOrdenCompra5.checked = false; " _
                                                   & "document.form1.rbRutEmpresa1.checked = true; " _
                                                   & "document.form1.rbRutEmpresa2.checked = false; " _
                                                   & "document.form1.rbRutEmpresa3.checked = false; " _
                                                   & "document.form1.rbRutEmpresa4.checked = false; " _
                                                   & "document.form1.rbRutEmpresa5.checked = false; ")

        Me.txtRutEmp.Attributes.Add("onFocus", "if (document.form1.rbRutEmpresa1.checked == true ) " _
                                                & "{document.form1.rbRutEmpresa1.checked = false; " _
                                                & "document.form1.rbRutEmpresa2.checked = true;}" _
                                                & "document.form1.rbCorrelativo1.checked = true; " _
                                                   & "document.form1.rbCorrelativo2.checked = false; " _
                                                   & "document.form1.rbCorrelativo3.checked = false; " _
                                                   & "document.form1.rbCorrelativo4.checked = false; " _
                                                   & "document.form1.rbCorrelativo5.checked = false; " _
                                                   & "document.form1.rbCorrelEmp1.checked = true; " _
                                                   & "document.form1.rbCorrelEmp2.checked = false; " _
                                                   & "document.form1.rbCorrelEmp3.checked = false; " _
                                                   & "document.form1.rbCorrelEmp4.checked = false; " _
                                                   & "document.form1.rbCorrelEmp5.checked = false; " _
                                                   & "document.form1.rbCodigoCurso1.checked = true; " _
                                                   & "document.form1.rbCodigoCurso2.checked = false; " _
                                                   & "document.form1.rbCodigoCurso3.checked = false; " _
                                                   & "document.form1.rbCodigoCurso4.checked = false; " _
                                                   & "document.form1.rbCodigoCurso5.checked = false; " _
                                                   & "document.form1.rbNroRegistro1.checked = true; " _
                                                   & "document.form1.rbNroRegistro2.checked = false; " _
                                                   & "document.form1.rbNroRegistro3.checked = false; " _
                                                   & "document.form1.rbNroRegistro4.checked = false; " _
                                                   & "document.form1.rbNroRegistro5.checked = false; " _
                                                   & "document.form1.rbNroVoucher1.checked = true; " _
                                                   & "document.form1.rbNroVoucher2.checked = false; " _
                                                   & "document.form1.rbNroVoucher3.checked = false; " _
                                                   & "document.form1.rbNroVoucher4.checked = false; " _
                                                   & "document.form1.rbNroVoucher5.checked = false; " _
                                                   & "document.form1.rbOrdenCompra1.checked = true; " _
                                                   & "document.form1.rbOrdenCompra2.checked = false; " _
                                                   & "document.form1.rbOrdenCompra3.checked = false; " _
                                                   & "document.form1.rbOrdenCompra4.checked = false; " _
                                                   & "document.form1.rbOrdenCompra5.checked = false; " _
                                                   & "document.form1.rbFechaIngreso1.checked = true; " _
                                                   & "document.form1.rbFechaIngreso2.checked = false; " _
                                                   & "document.form1.rbFechaIngreso3.checked = false; " _
                                                   & "document.form1.rbFechaIngreso4.checked = false; " _
                                                   & "document.form1.rbFechaIngreso5.checked = false; ")

        If Not Page.IsPostBack Then
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
            'mensaje de pie de pagina 
            lblPie.Text = Parametros.p_PIE

            objWeb.LlenaDDL(Me.ddlAgno, objLookups.Agnos2, "Agno_v", "Agno_t")
            Me.ddlAgno.SelectedValue = objSession.Agno

        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
        End If
        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If ((Not Me.rbCorrelativo1.Checked) And (txtCorrelativo.Text <> "")) Then
            If Not IsNumeric(txtCorrelativo.Text) Then
                body.Attributes.Add("onload", "alert('El correlativo debe ser numerico');")
                txtCorrelativo.Focus()
                Exit Sub
            End If
        End If
        If ((Not Me.rbCodigoCurso1.Checked) And (txtCodigoCurso.Text <> "")) Then
            If Not IsNumeric(txtCodigoCurso.Text) Then
                body.Attributes.Add("onload", "alert('El código de curso debe ser numerico');")
                txtCodigoCurso.Focus()
                Exit Sub
            End If
        End If
        If Not Me.rbNroRegistro1.Checked And txtNroRegistro.Text <> "" Then
            If Not IsNumeric(txtNroRegistro.Text) Then
                body.Attributes.Add("onload", "alert('El número de resgistro debe ser numerico');")
                Me.txtNroRegistro.Focus()
                Exit Sub
            End If
        End If
        If Not Me.rbOrdenCompra1.Checked And txtOrdenCompra.Text <> "" Then
            If Not IsNumeric(txtOrdenCompra.Text) Then
                body.Attributes.Add("onload", "alert('El número de orden de compra debe ser numerico');")
                Me.txtOrdenCompra.Focus()
                Exit Sub
            End If
        End If
        Dim strVoucher = ""
        objSession.Agno = Me.ddlAgno.SelectedValue
        If Not Me.rbCorrelativo1.Checked And txtCorrelativo.Text <> "" Then
            strVoucher = "no"
            If Me.rbCorrelativo2.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo = " & Me.txtCorrelativo.Text & " "
            End If
            If Me.rbCorrelativo3.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo > " & Me.txtCorrelativo.Text & " "
            End If
            If Me.rbCorrelativo4.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo < " & Me.txtCorrelativo.Text & " "
            End If
            If Me.rbCorrelativo5.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo <> " & Me.txtCorrelativo.Text & " "
            End If
        ElseIf Not Me.rbCorrelativo1.Checked And txtCorrelativo.Text = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar correlativo');")
            txtCorrelativo.Focus()
            Exit Sub
        End If


        If Not Me.rbCodigoCurso1.Checked And txtCodigoCurso.Text <> "" Then
            strVoucher = "no"
            If Me.rbCodigoCurso2.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso = " & Me.txtCodigoCurso.Text & " "
            End If
            If Me.rbCodigoCurso3.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso > " & Me.txtCodigoCurso.Text & " "
            End If
            If Me.rbCodigoCurso4.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso < " & Me.txtCodigoCurso.Text & " "
            End If
            If Me.rbCodigoCurso5.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso <> " & Me.txtCodigoCurso.Text & " "
            End If
        ElseIf Not Me.rbCodigoCurso1.Checked And txtCodigoCurso.Text = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar el código del curso');")
            txtCodigoCurso.Focus()
            Exit Sub
        End If


        If Not Me.rbCorrelEmp1.Checked And txtCorrelativoEmp.Text <> "" Then
            strVoucher = "no"
            If Me.rbCorrelEmp2.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo_empresa = " & "'" & Me.txtCorrelativoEmp.Text & "'" & " "
            End If
            If Me.rbCorrelEmp3.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo_empresa > " & "'" & Me.txtCorrelativoEmp.Text & "'" & " "
            End If
            If Me.rbCorrelEmp4.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo_empresa < " & "'" & Me.txtCorrelativoEmp.Text & "'" & " "
            End If
            If Me.rbCorrelEmp5.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.correlativo_empresa <> " & "'" & Me.txtCorrelativoEmp.Text & "'" & " "
            End If
        ElseIf Not Me.rbCorrelEmp1.Checked And txtCorrelativoEmp.Text = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar correlativo empresa');")
            Me.txtCorrelativoEmp.Focus()
            Exit Sub
        End If
        If Not Me.rbNroRegistro1.Checked And txtNroRegistro.Text <> "" Then
            strVoucher = "no"
            If Me.rbNroRegistro2.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.nro_registro = " & Me.txtNroRegistro.Text & " "
            End If
            If Me.rbNroRegistro3.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.nro_registro > " & Me.txtNroRegistro.Text & " "
            End If
            If Me.rbNroRegistro4.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.nro_registro < " & Me.txtNroRegistro.Text & " "
            End If
            If Me.rbNroRegistro5.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.nro_registro <> " & Me.txtNroRegistro.Text & " "
            End If
        ElseIf Not Me.rbNroRegistro1.Checked And txtNroRegistro.Text = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar nro de registro');")
            Me.txtNroRegistro.Focus()
            Exit Sub
        End If

        If Not Me.rbNroVoucher1.Checked And txtNroVoucher.Text <> "" Then
            strVoucher = "si"
            If Me.rbNroVoucher2.Checked Then
                mstrBusqueda = mstrBusqueda & " And fa.num_voucher = " & Me.txtNroVoucher.Text & " "
            End If
            If Me.rbNroVoucher3.Checked Then
                mstrBusqueda = mstrBusqueda & " And fa.num_voucher > " & Me.txtNroVoucher.Text & " "
            End If
            If Me.rbNroVoucher4.Checked Then
                mstrBusqueda = mstrBusqueda & " And fa.num_voucher < " & Me.txtNroVoucher.Text & " "
            End If
            If Me.rbNroVoucher5.Checked Then
                mstrBusqueda = mstrBusqueda & " And fa.num_voucher <> " & Me.txtNroVoucher.Text & " "
            End If
        ElseIf Not Me.rbNroVoucher1.Checked And txtNroVoucher.Text = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar nro de voucher');")
            txtNroVoucher.Focus()
            Exit Sub
        End If

        'ORDEN DE COMPRA (COD CURSO)
        If Not Me.rbOrdenCompra1.Checked And txtOrdenCompra.Text <> "" Then
            strVoucher = "no"
            If Me.rbOrdenCompra2.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso = " & Me.txtOrdenCompra.Text & " "
            End If
            If Me.rbOrdenCompra3.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso > " & Me.txtOrdenCompra.Text & " "
            End If
            If Me.rbOrdenCompra4.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso < " & Me.txtOrdenCompra.Text & " "
            End If
            If Me.rbOrdenCompra5.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.cod_curso <> " & Me.txtOrdenCompra.Text & " "
            End If
        ElseIf Not Me.rbOrdenCompra1.Checked And txtOrdenCompra.Text = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar orden de compra');")
            Me.txtOrdenCompra.Focus()
            Exit Sub
        End If

        If Not Me.rbRutEmpresa1.Checked And txtRutEmp.Text <> "" Then
            strVoucher = "no"
            If Me.rbRutEmpresa2.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.rut_cliente = " & RutUsrALng(Me.txtRutEmp.Text) & " "
            End If
            If Me.rbRutEmpresa3.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.rut_cliente > " & RutUsrALng(Me.txtRutEmp.Text) & " "
            End If
            If Me.rbRutEmpresa4.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.rut_cliente < " & RutUsrALng(Me.txtRutEmp.Text) & " "
            End If
            If Me.rbRutEmpresa5.Checked Then
                mstrBusqueda = mstrBusqueda & " And cc.rut_cliente <> " & RutUsrALng(Me.txtRutEmp.Text) & " "
            End If
        ElseIf Not Me.rbRutEmpresa1.Checked And txtRutEmp.Text <> "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar rut de empresa');")
            Me.txtRutEmp.Focus()
            Exit Sub
        End If

        If Not Me.rbFechaIngreso1.Checked And txtFechaIngreso.Text <> "" Then
            strVoucher = "no"
            If EsFechaValidaVB(txtFechaIngreso.Text.Trim) Then
                If Me.rbFechaIngreso2.Checked Then
                    mstrBusqueda = mstrBusqueda & " and cc.fecha_ingreso = " & FechaHoraVbABd(Me.txtFechaIngreso.Text) & " "
                End If
                If Me.rbFechaIngreso3.Checked Then
                    mstrBusqueda = mstrBusqueda & " and cc.fecha_ingreso > " & FechaHoraVbABd(Me.txtFechaIngreso.Text) & " "
                End If
                If Me.rbFechaIngreso4.Checked Then
                    mstrBusqueda = mstrBusqueda & " and cc.fecha_ingreso < " & FechaHoraVbABd(Me.txtFechaIngreso.Text) & " "
                End If
                If Me.rbFechaIngreso5.Checked Then
                    mstrBusqueda = mstrBusqueda & " and cc.fecha_ingreso <> " & FechaHoraVbABd(Me.txtFechaIngreso.Text) & " "
                End If
            Else
                body.Attributes.Add("onload", "alert('Debe ingresar una fecha con formato dd/mm/aaaa');")
                Me.txtFechaIngreso.Focus()
                Exit Sub
            End If
        ElseIf Not Me.rbFechaIngreso1.Checked And txtFechaIngreso.Text <> "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar una fecha de ingreso');")
            Me.txtFechaIngreso.Focus()
            Exit Sub
        End If


        Response.Redirect("./reporte_cursos.aspx?Origen=BuscarCursos&Filtros=" & mstrBusqueda & "&agno=" & objSession.Agno & "&voucher=" & strVoucher)
    End Sub
    
End Class
