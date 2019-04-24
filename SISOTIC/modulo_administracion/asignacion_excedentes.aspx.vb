Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_asignacion_excedentes
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objCSql As New CSql
    Dim objReporteExc As CReporteExcedentes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("rutCliente") = Request("rutCliente")
                ViewState("nomEmpresa") = Request("nomEmpresa")
                ViewState("ejecutivo") = Request("ejecutivo")
                ViewState("sucursal") = Request("sucursal")
                ViewState("agno") = Request("agno")

                objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
                objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                objWeb.LlenaDDL(Me.ddlAgno, objLookups.Agnos2, "Agno_v", "Agno_t")
                objWeb.AgregaValorDDL(Me.ddlEjecutivo, "Todos", -1)
                objWeb.AgregaValorDDL(Me.ddlSucursal, "Todas", -1)
                Me.ddlEjecutivo.SelectedValue = -1
                Me.ddlSucursal.SelectedValue = -1
                Me.ddlAgno.SelectedValue = Now.Year() - 1
                'objWeb.SeteaGrilla(grdResultados, 20)

                ' Consultar()

                btn_buscar_empresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")


            End If

        Catch ex As Exception
            EnviaError("modulo_administracion_asignacion_excedentes.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Public Sub Consultar()
        Try

            objReporteExc = New CReporteExcedentes
            objReporteExc.BajarXml = chkBajarReporte.Checked
            If Me.txtRutEmpresa.Text = "" Then
                objReporteExc.RutCliente = 0
            Else
                objReporteExc.RutCliente = RutUsrALng(Me.txtRutEmpresa.Text)
            End If

            If Me.txtNomEmpresa.Text = "" Then
                objReporteExc.NombreEmpresa = ""
            Else
                objReporteExc.NombreEmpresa = Me.txtNomEmpresa.Text
            End If

            If Me.ddlEjecutivo.SelectedValue = -1 Then
                objReporteExc.RutEjecutivo = 0
            Else
                objReporteExc.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
            End If

            If Me.ddlSucursal.SelectedValue = -1 Then
                objReporteExc.CodSucursal = 0
            Else
                objReporteExc.CodSucursal = Me.ddlSucursal.SelectedValue
            End If

            objReporteExc.Agno = Me.ddlAgno.SelectedValue

            Dim dt As DataTable

            dt = objReporteExc.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)

            If dt.Rows.Count > 0 Then
                Me.btnMofidicarTodos.Visible = True
                Me.btnTraspasarTodos.Visible = True
            Else
                Me.btnMofidicarTodos.Visible = False
                Me.btnTraspasarTodos.Visible = False
            End If
          


            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporteExc.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If



        Catch ex As Exception
            EnviaError("modulo_administracion_asignacion_excedentes.aspx.vb:Consultar-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim rutCliente As Label
            rutCliente = CType(e.Row.FindControl("lblRutEmpresa"), Label)
            ''If rutCliente.Text = "" Then
            ''    rutCliente.Text = 0
            ''Else
            ''    rutCliente.Text = Replace(rutCliente.Text, "-", "")
            ''End If
            'rutCliente.Text = objReporteExc.RutClientes

            Dim nomCliente As HyperLink
            nomCliente = CType(e.Row.FindControl("hplRazonSocial"), HyperLink)


            Dim cuentaCap As Label
            cuentaCap = CType(e.Row.FindControl("lblSaldoCap"), Label)
            If cuentaCap.Text = "" Then
                cuentaCap.Text = 0
            Else
                cuentaCap.Text = Replace(cuentaCap.Text, "$", "")
            End If
            cuentaCap.Text = FormatoPeso(cuentaCap.Text)

            Dim cuentaRep As Label
            cuentaRep = CType(e.Row.FindControl("lblSaldoRep"), Label)
            If cuentaRep.Text = "" Then
                cuentaRep.Text = 0
            Else
                cuentaRep.Text = Replace(cuentaRep.Text, "$", "")
            End If
            cuentaRep.Text = FormatoPeso(cuentaRep.Text)

            Dim cuentaAdm As Label
            cuentaAdm = CType(e.Row.FindControl("lblSaldoAdm"), Label)
            If cuentaAdm.Text = "" Then
                cuentaAdm.Text = 0
            Else
                cuentaAdm.Text = Replace(cuentaAdm.Text, "$", "")
            End If
            cuentaAdm.Text = FormatoPeso(cuentaAdm.Text)

            Dim excCompl As Label
            excCompl = CType(e.Row.FindControl("lblExcCompl"), Label)
            If excCompl.Text = "" Then
                excCompl.Text = 0
            Else
                excCompl.Text = Replace(excCompl.Text, "$", "")
            End If
            excCompl.Text = FormatoPeso(excCompl.Text)

            Dim excBecas As Label
            excBecas = CType(e.Row.FindControl("lblExcBecas"), Label)
            If excBecas.Text = "" Then
                excBecas.Text = 0
            Else
                excBecas.Text = Replace(excBecas.Text, "$", "")
            End If
            excBecas.Text = FormatoPeso(excBecas.Text)

            Dim total As Label
            total = CType(e.Row.FindControl("lblTotal"), Label)
            If total.Text = "" Then
                total.Text = 0
            Else
                total.Text = Replace(total.Text, "$", "")
            End If
            total.Text = FormatoPeso(total.Text)

            Dim porcAdmin As Label
            porcAdmin = CType(e.Row.FindControl("lblPorcAdmin"), Label)
            nomCliente.NavigateUrl = "modulo_cursos/ficha_empresa.aspx?rutCliente=" & rutCliente.Text

        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Public Sub traspasarTodos()
        Dim row As GridViewRow
        For Each row In Me.grdResultados.Rows
            'objReporteExc = New CReporteExcedentes
            'Dim lngTotal As Long
            'Dim total As Label
            'total = CType(row.FindControl("lblTotal"), Label)
            'If total.Text = "" Then
            '    total.Text = 0
            'Else
            '    total.Text = Replace(total.Text, "$", "")
            'End If
            'lngTotal = total.Text

            'Dim lngMontoTraspasable As Long
            'Dim montoTraspasable As Label
            'montoTraspasable = CType(row.FindControl("lblExcCompl"), Label)
            'If montoTraspasable.Text = "" Then
            '    montoTraspasable.Text = 0
            'Else
            '    montoTraspasable.Text = Replace(montoTraspasable.Text, "$", "")
            'End If
            'lngMontoTraspasable = montoTraspasable.Text

            'Dim lngMontoNoTraspasable As Long
            'Dim montoNoTraspasable As Label
            'montoNoTraspasable = CType(row.FindControl("lblExcBecas"), Label)
            'If montoNoTraspasable.Text = "" Then
            '    montoNoTraspasable.Text = 0
            'Else
            '    montoNoTraspasable.Text = Replace(montoNoTraspasable.Text, "$", "")
            'End If
            'lngMontoNoTraspasable = montoNoTraspasable.Text

            'Dim lngPorcAdmin As Long
            'Dim porcAdmin As Label
            'porcAdmin = CType(row.FindControl("lblPorcAdmin"), Label)
            ''If porcAdmin.Text = "" Then
            ''    porcAdmin.Text = 0
            ''Else
            ''    porcAdmin.Text = Replace(porcAdmin.Text, "$", "")
            ''End If
            'lngPorcAdmin = porcAdmin.Text

            'Dim lngExccap As Long
            'Dim excCap As TextBox
            'excCap = CType(row.FindControl("txtExcCap"), TextBox)
            ''If excCap.Text = "" Then
            ''    excCap.Text = 0
            ''Else
            ''    excCap.Text = Replace(excCap.Text, "$", "")
            ''End If
            'lngExccap = excCap.Text

            'Dim lngAdmin As Long
            'Dim admin As TextBox
            'admin = CType(row.FindControl("txtAdmin"), TextBox)
            ''If admin.Text = "" Then
            ''    admin.Text = 0
            ''Else
            ''    admin.Text = Replace(admin.Text, "$", "")
            ''End If
            'lngAdmin = admin.Text

            'Dim lngBecas As Long
            'Dim becas As TextBox
            'becas = CType(row.FindControl("txtBecas"), TextBox)
            ''If becas.Text = "" Then
            ''    becas.Text = 0
            ''Else
            ''    becas.Text = Replace(becas.Text, "$", "")
            ''End If
            'lngBecas = becas.Text

            'Dim saldoAsignar As TextBox
            'saldoAsignar = CType(row.FindControl("txtSaldoAsignar"), TextBox)

            'If saldoAsignar.Text = 0 Then
            '    GoTo siguiente
            '    'Exit Sub
            'End If


            'Dim porc As Double
            'porc = (lngTotal - lngMontoTraspasable - lngMontoNoTraspasable) * lngPorcAdmin / 100

            'excCap.Text = Math.Round(lngTotal - porc - lngMontoTraspasable - lngMontoNoTraspasable - lngExccap, 0)

            'admin.Text = Math.Round(porc, 0)
            'becas.Text = Math.Round(lngMontoTraspasable + lngMontoNoTraspasable, 0)

            'total.Text = FormatoPeso(total.Text)
            'montoTraspasable.Text = FormatoPeso(montoTraspasable.Text)
            'montoNoTraspasable.Text = FormatoPeso(montoNoTraspasable.Text)

            'Dim suma As Long
            'suma = CLng(CType(row.FindControl("txtExcCap"), TextBox).Text) + _
            '        CLng(CType(row.FindControl("txtExcRep"), TextBox).Text) + _
            '        CLng(CType(row.FindControl("txtBecas"), TextBox).Text) + _
            '        CLng(CType(row.FindControl("txtAdmin"), TextBox).Text)

            'saldoAsignar.Text = saldoAsignar.Text - suma
            ''If saldoAsignar.Text = 1 Or saldoAsignar.Text = -1 Then
            ''    saldoAsignar.Text = 0
            ''End If
            objReporteExc = New CReporteExcedentes
            Dim lngTotal As Long
            Dim total As Label
            total = CType(row.FindControl("lblTotal"), Label)
            If total.Text = "" Then
                total.Text = 0
            Else
                total.Text = Replace(total.Text, "$", "")
            End If
            lngTotal = total.Text

            'saldo capacitación
            Dim lblSaldoCap As Label
            lblSaldoCap = CType(row.FindControl("lblSaldoCap"), Label)

            'saldo reparto
            Dim lblSaldoRep As Label
            lblSaldoRep = CType(row.FindControl("lblSaldoRep"), Label)

            'saldo adm
            Dim lblSaldoAdm As Label
            lblSaldoAdm = CType(row.FindControl("lblSaldoAdm"), Label)

            'saldo exc compl
            Dim lblExcCompl As Label
            lblExcCompl = CType(row.FindControl("lblExcCompl"), Label)

            'saldo exc becas
            Dim lblExcBecas As Label
            lblExcBecas = CType(row.FindControl("lblExcBecas"), Label)



            Dim lngMontoTraspasable As Long
            Dim montoTraspasable As Label
            montoTraspasable = CType(row.FindControl("lblExcCompl"), Label)
            If montoTraspasable.Text = "" Then
                montoTraspasable.Text = 0
            Else
                montoTraspasable.Text = Replace(montoTraspasable.Text, "$", "")
            End If
            lngMontoTraspasable = montoTraspasable.Text

            Dim lngMontoNoTraspasable As Long
            Dim montoNoTraspasable As Label
            montoNoTraspasable = CType(row.FindControl("lblExcBecas"), Label)
            If montoNoTraspasable.Text = "" Then
                montoNoTraspasable.Text = 0
            Else
                montoNoTraspasable.Text = Replace(montoNoTraspasable.Text, "$", "")
            End If
            lngMontoNoTraspasable = montoNoTraspasable.Text

            Dim lngPorcAdmin As Long
            Dim porcAdmin As Label
            porcAdmin = CType(row.FindControl("lblPorcAdmin"), Label)

            lngPorcAdmin = porcAdmin.Text

            'Dim lngExccap As Long
            Dim excCap As TextBox
            excCap = CType(row.FindControl("txtExcCap"), TextBox)

            excCap.Text = Replace(Replace(lblSaldoCap.Text, "$", ""), ".", "")
            'lngExccap = excCap.Text

            'Dim lngExcrep As Long
            Dim excRep As TextBox
            excRep = CType(row.FindControl("txtExcRep"), TextBox)

            excRep.Text = Replace(Replace(lblSaldoRep.Text, "$", ""), ".", "")
            'lngExccap = excCap.Text

            'Dim lngAdmin As Long
            Dim admin As TextBox
            admin = CType(row.FindControl("txtAdmin"), TextBox)
            admin.Text = Replace(Replace(lblSaldoAdm.Text, "$", ""), ".", "")

            'lngAdmin = admin.Text

            'Dim lngBecas As Long
            Dim becas As TextBox
            becas = CType(row.FindControl("txtBecas"), TextBox)
            becas.Text = Replace(Replace(lngMontoTraspasable + lngMontoNoTraspasable, "$", ""), ".", "")

            'lngBecas = becas.Text

            Dim saldoAsignar As TextBox
            saldoAsignar = CType(row.FindControl("txtSaldoAsignar"), TextBox)

            If saldoAsignar.Text = 0 Then
                'Exit Sub
                GoTo siguiente
            End If

            Dim porc As Double
            porc = Math.Round((lngTotal - lngMontoTraspasable - lngMontoNoTraspasable) * lngPorcAdmin / 100, 0)

            'excCap.Text = Math.Round(lngTotal - porc - lngMontoTraspasable - lngMontoNoTraspasable, 0)

            'admin.Text = Math.Round(porc, 0)
            'becas.Text = Math.Round(lngMontoTraspasable + lngMontoNoTraspasable, 0)

            total.Text = FormatoPeso(total.Text)
            montoTraspasable.Text = FormatoPeso(montoTraspasable.Text)
            montoNoTraspasable.Text = FormatoPeso(montoNoTraspasable.Text)

            Dim suma As Long
            suma = CLng(CType(row.FindControl("txtExcCap"), TextBox).Text) + _
                    CLng(CType(row.FindControl("txtExcRep"), TextBox).Text) + _
                    CLng(CType(row.FindControl("txtBecas"), TextBox).Text) + _
                    CLng(CType(row.FindControl("txtAdmin"), TextBox).Text)

            saldoAsignar.Text = saldoAsignar.Text - suma
siguiente:
        Next
    End Sub
    'Protected Sub btnTraspasar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim btnTraspasar As Button = CType(sender, Button)
    '    Dim row As GridViewRow = CType(btnTraspasar.NamingContainer, GridViewRow)

    '    objReporteExc = New CReporteExcedentes
    '    Dim lngTotal As Long
    '    Dim total As Label
    '    total = CType(row.FindControl("lblTotal"), Label)
    '    If total.Text = "" Then
    '        total.Text = 0
    '    Else
    '        total.Text = Replace(total.Text, "$", "")
    '    End If
    '    lngTotal = total.Text

    '    Dim lngMontoTraspasable As Long
    '    Dim montoTraspasable As Label
    '    montoTraspasable = CType(row.FindControl("lblExcCompl"), Label)
    '    If montoTraspasable.Text = "" Then
    '        montoTraspasable.Text = 0
    '    Else
    '        montoTraspasable.Text = Replace(montoTraspasable.Text, "$", "")
    '    End If
    '    lngMontoTraspasable = montoTraspasable.Text

    '    Dim lngMontoNoTraspasable As Long
    '    Dim montoNoTraspasable As Label
    '    montoNoTraspasable = CType(row.FindControl("lblExcBecas"), Label)
    '    If montoNoTraspasable.Text = "" Then
    '        montoNoTraspasable.Text = 0
    '    Else
    '        montoNoTraspasable.Text = Replace(montoNoTraspasable.Text, "$", "")
    '    End If
    '    lngMontoNoTraspasable = montoNoTraspasable.Text

    '    Dim lngPorcAdmin As Long
    '    Dim porcAdmin As Label
    '    porcAdmin = CType(row.FindControl("lblPorcAdmin"), Label)
    '    'If porcAdmin.Text = "" Then
    '    '    porcAdmin.Text = 0
    '    'Else
    '    '    porcAdmin.Text = Replace(porcAdmin.Text, "$", "")
    '    'End If
    '    lngPorcAdmin = porcAdmin.Text

    '    Dim lngExccap As Long
    '    Dim excCap As TextBox
    '    excCap = CType(row.FindControl("txtExcCap"), TextBox)
    '    'If excCap.Text = "" Then
    '    '    excCap.Text = 0
    '    'Else
    '    '    excCap.Text = Replace(excCap.Text, "$", "")
    '    'End If
    '    lngExccap = excCap.Text

    '    Dim lngAdmin As Long
    '    Dim admin As TextBox
    '    admin = CType(row.FindControl("txtAdmin"), TextBox)
    '    'If admin.Text = "" Then
    '    '    admin.Text = 0
    '    'Else
    '    '    admin.Text = Replace(admin.Text, "$", "")
    '    'End If
    '    lngAdmin = admin.Text

    '    Dim lngBecas As Long
    '    Dim becas As TextBox
    '    becas = CType(row.FindControl("txtBecas"), TextBox)
    '    'If becas.Text = "" Then
    '    '    becas.Text = 0
    '    'Else
    '    '    becas.Text = Replace(becas.Text, "$", "")
    '    'End If
    '    lngBecas = becas.Text

    '    Dim saldoAsignar As TextBox
    '    saldoAsignar = CType(row.FindControl("txtSaldoAsignar"), TextBox)

    '    If saldoAsignar.Text = 0 Then
    '        Exit Sub
    '    End If

    '    Dim porc As Double
    '    porc = Math.Round((lngTotal - lngMontoTraspasable - lngMontoNoTraspasable) * lngPorcAdmin / 100, 0)

    '    excCap.Text = Math.Round(lngTotal - porc - lngMontoTraspasable - lngMontoNoTraspasable, 0)

    '    admin.Text = Math.Round(porc, 0)
    '    becas.Text = Math.Round(lngMontoTraspasable + lngMontoNoTraspasable, 0)

    '    total.Text = FormatoPeso(total.Text)
    '    montoTraspasable.Text = FormatoPeso(montoTraspasable.Text)
    '    montoNoTraspasable.Text = FormatoPeso(montoNoTraspasable.Text)

    '    Dim suma As Long
    '    suma = CLng(CType(row.FindControl("txtExcCap"), TextBox).Text) + _
    '            CLng(CType(row.FindControl("txtExcRep"), TextBox).Text) + _
    '            CLng(CType(row.FindControl("txtBecas"), TextBox).Text) + _
    '            CLng(CType(row.FindControl("txtAdmin"), TextBox).Text)

    '    saldoAsignar.Text = saldoAsignar.Text - suma


    'End Sub
    Protected Sub btnTraspasar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnTraspasar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnTraspasar.NamingContainer, GridViewRow)

        objReporteExc = New CReporteExcedentes
        Dim lngTotal As Long
        Dim total As Label
        total = CType(row.FindControl("lblTotal"), Label)
        If total.Text = "" Then
            total.Text = 0
        Else
            total.Text = Replace(total.Text, "$", "")
        End If
        lngTotal = total.Text

        'saldo capacitación
        Dim lblSaldoCap As Label
        lblSaldoCap = CType(row.FindControl("lblSaldoCap"), Label)

        'saldo reparto
        Dim lblSaldoRep As Label
        lblSaldoRep = CType(row.FindControl("lblSaldoRep"), Label)

        'saldo adm
        Dim lblSaldoAdm As Label
        lblSaldoAdm = CType(row.FindControl("lblSaldoAdm"), Label)

        'saldo exc compl
        Dim lblExcCompl As Label
        lblExcCompl = CType(row.FindControl("lblExcCompl"), Label)

        'saldo exc becas
        Dim lblExcBecas As Label
        lblExcBecas = CType(row.FindControl("lblExcBecas"), Label)

        

        Dim lngMontoTraspasable As Long
        Dim montoTraspasable As Label
        montoTraspasable = CType(row.FindControl("lblExcCompl"), Label)
        If montoTraspasable.Text = "" Then
            montoTraspasable.Text = 0
        Else
            montoTraspasable.Text = Replace(montoTraspasable.Text, "$", "")
        End If
        lngMontoTraspasable = montoTraspasable.Text

        Dim lngMontoNoTraspasable As Long
        Dim montoNoTraspasable As Label
        montoNoTraspasable = CType(row.FindControl("lblExcBecas"), Label)
        If montoNoTraspasable.Text = "" Then
            montoNoTraspasable.Text = 0
        Else
            montoNoTraspasable.Text = Replace(montoNoTraspasable.Text, "$", "")
        End If
        lngMontoNoTraspasable = montoNoTraspasable.Text

        Dim lngPorcAdmin As Long
        Dim porcAdmin As Label
        porcAdmin = CType(row.FindControl("lblPorcAdmin"), Label)
       
        lngPorcAdmin = porcAdmin.Text

        'Dim lngExccap As Long
        Dim excCap As TextBox
        excCap = CType(row.FindControl("txtExcCap"), TextBox)

        excCap.Text = Replace(Replace(lblSaldoCap.Text, "$", ""), ".", "")
        'lngExccap = excCap.Text

        'Dim lngExcrep As Long
        Dim excRep As TextBox
        excRep = CType(row.FindControl("txtExcRep"), TextBox)

        excRep.Text = Replace(Replace(lblSaldoRep.Text, "$", ""), ".", "")
        'lngExccap = excCap.Text

        'Dim lngAdmin As Long
        Dim admin As TextBox
        admin = CType(row.FindControl("txtAdmin"), TextBox)
        admin.Text = Replace(Replace(lblSaldoAdm.Text, "$", ""), ".", "")
      
        'lngAdmin = admin.Text

        'Dim lngBecas As Long
        Dim becas As TextBox
        becas = CType(row.FindControl("txtBecas"), TextBox)
        becas.Text = Replace(Replace(lngMontoTraspasable + lngMontoNoTraspasable, "$", ""), ".", "")
       
        'lngBecas = becas.Text

        Dim saldoAsignar As TextBox
        saldoAsignar = CType(row.FindControl("txtSaldoAsignar"), TextBox)

        If saldoAsignar.Text = 0 Then
            Exit Sub
        End If

        Dim porc As Double
        porc = Math.Round((lngTotal - lngMontoTraspasable - lngMontoNoTraspasable) * lngPorcAdmin / 100, 0)

        'excCap.Text = Math.Round(lngTotal - porc - lngMontoTraspasable - lngMontoNoTraspasable, 0)

        'admin.Text = Math.Round(porc, 0)
        'becas.Text = Math.Round(lngMontoTraspasable + lngMontoNoTraspasable, 0)

        total.Text = FormatoPeso(total.Text)
        montoTraspasable.Text = FormatoPeso(montoTraspasable.Text)
        montoNoTraspasable.Text = FormatoPeso(montoNoTraspasable.Text)

        Dim suma As Long
        suma = CLng(CType(row.FindControl("txtExcCap"), TextBox).Text) + _
                CLng(CType(row.FindControl("txtExcRep"), TextBox).Text) + _
                CLng(CType(row.FindControl("txtBecas"), TextBox).Text) + _
                CLng(CType(row.FindControl("txtAdmin"), TextBox).Text)

        saldoAsignar.Text = saldoAsignar.Text - suma


    End Sub
    Public Sub ModificarTodos()
        Dim row As GridViewRow
        For Each row In Me.grdResultados.Rows
            objReporteExc = New CReporteExcedentes
            Dim rutCliente As Label
            rutCliente = CType(row.FindControl("lblRutEmpresa"), Label)
            Dim ejecutivo As Label
            ejecutivo = CType(row.FindControl("lblEjecutivo"), Label)
            Dim sucursal As Label
            sucursal = CType(row.FindControl("lblSucursal"), Label)
            Dim nombreEmpresa As HyperLink
            nombreEmpresa = CType(row.FindControl("hplRazonSocial"), HyperLink)

            Dim lngTotal As Long
            Dim total As Label
            total = CType(row.FindControl("lblTotal"), Label)
            If total.Text = "" Then
                total.Text = 0
            Else
                total.Text = Replace(total.Text, "$", "")
            End If

            lngTotal = total.Text

            Dim lngExccap As Long
            Dim excCap As TextBox
            excCap = CType(row.FindControl("txtExcCap"), TextBox)
            If excCap.Text = "" Then
                excCap.Text = 0
            Else
                excCap.Text = Replace(excCap.Text, "$", "")
            End If
            ' excCap.Text = FormatoPeso(excCap.Text)
            lngExccap = excCap.Text

            Dim lngExcRep As Long
            Dim excRep As TextBox
            excRep = CType(row.FindControl("txtExcRep"), TextBox)
            If excRep.Text = "" Then
                excRep.Text = 0
            Else
                excRep.Text = Replace(excRep.Text, "$", "")
            End If
            'excRep.Text = FormatoPeso(excRep.Text)
            lngExcRep = excRep.Text

            Dim lngAdmin As Long
            Dim admin As TextBox
            admin = CType(row.FindControl("txtAdmin"), TextBox)
            If admin.Text = "" Then
                admin.Text = 0
            Else
                admin.Text = Replace(admin.Text, "$", "")
            End If
            'admin.Text = FormatoPeso(admin.Text)
            lngAdmin = admin.Text

            Dim lngBecas As Long
            Dim becas As TextBox
            becas = CType(row.FindControl("txtBecas"), TextBox)
            If becas.Text = "" Then
                becas.Text = 0
            Else
                becas.Text = Replace(becas.Text, "$", "")
            End If
            'becas.Text = FormatoPeso(becas.Text)
            lngBecas = becas.Text

            Dim saldoAsignar As TextBox
            saldoAsignar = CType(row.FindControl("txtSaldoAsignar"), TextBox)

            If saldoAsignar.Text = 1 Then
                lngExccap = lngExccap + 1
            End If
            If saldoAsignar.Text = -1 Then
                lngExccap = lngExccap - 1
            End If

            If (lngTotal - (lngExccap + lngExcRep + lngAdmin + lngBecas)) <> 0 Then
                body.Attributes.Add("onload", "alert('Debe asignar el saldo total completo');")
                total.Text = FormatoPeso(total.Text)
                'Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                '           & "alert('Debe asignar el saldo total completo');document.location=('./asignacion_excedentes.aspx');</script>")
                'Exit Sub
                GoTo siguiente
            End If

            ' Dim mdtListadoExcedentes As DataTable
            objReporteExc.RutCliente = RutUsrALng(rutCliente.Text)
            objReporteExc.NombreEmpresa = nombreEmpresa.Text
            objReporteExc.CodSucursal = Me.ddlSucursal.SelectedValue
            objReporteExc.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
            objReporteExc.Agno = Me.ddlAgno.SelectedValue

            objReporteExc.ListadoExcedentes = objReporteExc.Consultar()

            objReporteExc.AbonoExCap = lngExccap
            objReporteExc.AbonoExRep = lngExcRep
            objReporteExc.AbonoAdm = lngAdmin
            objReporteExc.AbonoBeca = lngBecas

            ' objReporteExc.GrabarDatos()
            If objReporteExc.GrabarDatos() = True Then
                saldoAsignar.Text = lngTotal - (lngExccap + lngExcRep + lngAdmin + lngBecas)
            Else
                body.Attributes.Add("onload", "alert('No se pudo realizar la modificación');")
            End If

            total.Text = FormatoPeso(total.Text)
siguiente:
        Next
        
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        objReporteExc = New CReporteExcedentes
        Dim btnModificar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnModificar.NamingContainer, GridViewRow)
        Dim rutCliente As Label
        rutCliente = CType(row.FindControl("lblRutEmpresa"), Label)
        Dim ejecutivo As Label
        ejecutivo = CType(row.FindControl("lblEjecutivo"), Label)
        Dim sucursal As Label
        sucursal = CType(row.FindControl("lblSucursal"), Label)
        Dim nombreEmpresa As HyperLink
        nombreEmpresa = CType(row.FindControl("hplRazonSocial"), HyperLink)

        Dim lngTotal As Long
        Dim total As Label
        total = CType(row.FindControl("lblTotal"), Label)
        If total.Text = "" Then
            total.Text = 0
        Else
            total.Text = Replace(total.Text, "$", "")
        End If

        lngTotal = total.Text

        Dim lngExccap As Long
        Dim excCap As TextBox
        excCap = CType(row.FindControl("txtExcCap"), TextBox)
        If excCap.Text = "" Then
            excCap.Text = 0
        Else
            excCap.Text = Replace(excCap.Text, "$", "")
        End If
        ' excCap.Text = FormatoPeso(excCap.Text)
        lngExccap = excCap.Text

        Dim lngExcRep As Long
        Dim excRep As TextBox
        excRep = CType(row.FindControl("txtExcRep"), TextBox)
        If excRep.Text = "" Then
            excRep.Text = 0
        Else
            excRep.Text = Replace(excRep.Text, "$", "")
        End If
        'excRep.Text = FormatoPeso(excRep.Text)
        lngExcRep = excRep.Text

        Dim lngAdmin As Long
        Dim admin As TextBox
        admin = CType(row.FindControl("txtAdmin"), TextBox)
        If admin.Text = "" Then
            admin.Text = 0
        Else
            admin.Text = Replace(admin.Text, "$", "")
        End If
        'admin.Text = FormatoPeso(admin.Text)
        lngAdmin = admin.Text

        Dim lngBecas As Long
        Dim becas As TextBox
        becas = CType(row.FindControl("txtBecas"), TextBox)
        If becas.Text = "" Then
            becas.Text = 0
        Else
            becas.Text = Replace(becas.Text, "$", "")
        End If
        'becas.Text = FormatoPeso(becas.Text)
        lngBecas = becas.Text

        Dim saldoAsignar As TextBox
        saldoAsignar = CType(row.FindControl("txtSaldoAsignar"), TextBox)

        If saldoAsignar.Text = 1 Then
            lngExccap = lngExccap + 1
        End If
        If saldoAsignar.Text = -1 Then
            lngExccap = lngExccap - 1
        End If

        If (lngTotal - (lngExccap + lngExcRep + lngAdmin + lngBecas)) <> 0 Then
            body.Attributes.Add("onload", "alert('Debe asignar el saldo total completo');")
            total.Text = FormatoPeso(total.Text)
            'Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
            '           & "alert('Debe asignar el saldo total completo');document.location=('./asignacion_excedentes.aspx');</script>")
            Exit Sub
        End If

        ' Dim mdtListadoExcedentes As DataTable
        objReporteExc.RutCliente = RutUsrALng(rutCliente.Text)
        objReporteExc.NombreEmpresa = nombreEmpresa.Text
        objReporteExc.CodSucursal = Me.ddlSucursal.SelectedValue
        objReporteExc.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
        objReporteExc.Agno = Me.ddlAgno.SelectedValue

        objReporteExc.ListadoExcedentes = objReporteExc.Consultar()

        objReporteExc.AbonoExCap = lngExccap
        objReporteExc.AbonoExRep = lngExcRep
        objReporteExc.AbonoAdm = lngAdmin
        objReporteExc.AbonoBeca = lngBecas

        ' objReporteExc.GrabarDatos()
        If objReporteExc.GrabarDatos() = True Then
            saldoAsignar.Text = lngTotal - (lngExccap + lngExcRep + lngAdmin + lngBecas)
        Else
            body.Attributes.Add("onload", "alert('No se pudo realizar la modificación');")
        End If

        total.Text = FormatoPeso(total.Text)

    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub

    Protected Sub btnTraspasarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTraspasarTodos.Click
        traspasarTodos()
    End Sub

    Protected Sub btnMofidicarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMofidicarTodos.Click
        ModificarTodos()
    End Sub

    Protected Sub lnkTraspasoFondos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTraspasoFondos.Click
        Response.Redirect("mantenedor_traspaso_cuentas.aspx?rut_empresa=" & Me.txtRutEmpresa.Text.Trim)
    End Sub
End Class
