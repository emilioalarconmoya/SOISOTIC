Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantanedor_feriados
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objLookups As Clookups
    Dim objMantenedor As CMantenedorFeriados

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '***********************************************************************************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            '***********************************************************************************
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                objWeb = New CWeb
                objLookups = New Clookups
                objWeb.LlenaDDL(Me.ddlAgno, objLookups.Agnos, "Agno_v", "Agno_t")
                Me.ddlAgno.SelectedValue = Now.Year
                objWeb = Nothing
                objLookups = Nothing
                Consultar()
            End If
            Dim dia As Date = ProximoDiaHabil()
        Catch ex As Exception
            EnviaError("modulo_administracion/mantanedor_feriados:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objMantenedor = New CMantenedorFeriados
            objMantenedor.Inicializar()
            objMantenedor.Agno = Me.ddlAgno.SelectedValue
            objMantenedor.Consultar()
            ViewState("feriados") = objMantenedor.Feriados
            objWeb = New CWeb
            objLookups = New Clookups
            objWeb.LlenaGrilla(Me.grdFeriados, ViewState("feriados"))
            objWeb = Nothing
            objLookups = Nothing
            If grdFeriados.Rows.Count = 0 Then
                AgregarNuevo()
            End If
        Catch ex As Exception
            EnviaError("modulo_administracion/mantanedor_feriados:Consultar-->" & ex.Message)
        End Try
    End Sub
    Public Sub AgregarNuevo()
        Try
            'Dim dt As DataTable
            'dt = ViewState("feriados")

            Dim dt As New DataTable
            dt.Columns.Add("fecha")
            dt.Columns.Add("motivo")
            Dim dr As DataRow

            Dim grdRow As GridViewRow
            For Each grdRow In Me.grdFeriados.Rows
                'If Not CType(grdRow.FindControl("chkEliminar"), CheckBox).Checked Then
                dr = dt.NewRow
                dr("fecha") = FechaUsrAVb(CType(grdRow.FindControl("calFechaInicio"), eWorld.UI.CalendarPopup).SelectedDate)
                dr("motivo") = CType(grdRow.FindControl("txtMotivo"), TextBox).Text.Trim
                dt.Rows.Add(dr)
                'End If
            Next


            'Dim dr As DataRow
            dr = dt.NewRow
            dr("fecha") = FechaVbAUsr(Now.Date)
            dr("motivo") = ""
            dt.Rows.Add(dr)
            ViewState("feriados") = dt
            objWeb = New CWeb
            objLookups = New Clookups
            objWeb.LlenaGrilla(Me.grdFeriados, ViewState("feriados"))
            objWeb = Nothing
            objLookups = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantanedor_feriados:AgregarNuevo-->" & ex.Message)
        End Try
    End Sub
    Public Sub AplicarCambios()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("fecha")
            dt.Columns.Add("motivo")
            Dim dr As DataRow

            Dim grdRow As GridViewRow
            For Each grdRow In Me.grdFeriados.Rows
                If Not CType(grdRow.FindControl("chkEliminar"), CheckBox).Checked Then
                    dr = dt.NewRow
                    dr("fecha") = FechaUsrAVb(CType(grdRow.FindControl("calFechaInicio"), eWorld.UI.CalendarPopup).SelectedDate)
                    dr("motivo") = CType(grdRow.FindControl("txtMotivo"), TextBox).Text.Trim
                    dt.Rows.Add(dr)
                End If
            Next
            objMantenedor = New CMantenedorFeriados
            objMantenedor.Agno = Me.ddlAgno.SelectedValue
            objMantenedor.Inicializar()
            objMantenedor.Feriados = dt
            objMantenedor.AplicarCambios()
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantanedor_feriados:AplicarCambios-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregarNuevo()
    End Sub

    Protected Sub btnAplicar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAplicar1.Click
        AplicarCambios()
        Consultar()
    End Sub

    Protected Sub btnAplicar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAplicar2.Click
        AplicarCambios()
        Consultar()
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
End Class
