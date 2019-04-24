Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_supervisor_ejecutivos_m
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objSql As New CSql
    Dim objMantenedorSuperEjec As New CMantenedorSupervisorEjecutivo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            '***********************************************************************************
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSupervisor") = Request("RutSupervisor")
                ViewState("NombreSupervisor") = Request("NombreSupervisor")
                ViewState("RutEjecutivo") = Request("RutEjecutivo")
                ViewState("NombreEjecutivo") = Request("NombreEjecutivo")
                objMantenedorSuperEjec = New CMantenedorSupervisorEjecutivo
                Session("objeto") = objMantenedorSuperEjec
                objMantenedorSuperEjec.Inicializar(objSql)
                objWeb.LlenaDDL(Me.ddlSupervisor, objLookups.SupervisoresTodos, "rut", "nombres")
                'objWeb.LlenaLSTaux(lbxDisponibles, objMantenedorSuperEjec.EjecutivoAsignado, "rut", "nombres")

                If Not ViewState("RutSupervisor") Is Nothing Then
                    ViewState("modo") = "actualizar"
                    objMantenedorSuperEjec.RutSupervisor = ViewState("RutSupervisor")
                    objMantenedorSuperEjec.NombreSupervisor = ViewState("NombreSupervisor")
                    objMantenedorSuperEjec.Inicializar2(objSql)
                    'Me.txtNomSupervisor.Text = objMantenedorSuperEjec.NombreSupervisor
                    Me.ddlSupervisor.SelectedValue = objMantenedorSuperEjec.RutSupervisor
                    objWeb.LlenaLSTaux(lbxAsignados, objMantenedorSuperEjec.EjecutivoAsignado, "rut", "nombres")
                    objWeb.LlenaLSTaux(lbxDisponibles, objMantenedorSuperEjec.EjecutivoNoAsignado, "rut", "nombres")

                Else
                    If Request("RutSupervisor") = "" Then
                        If Request("nuevo") = "si" Then
                            ViewState("modo") = "insertar"
                            objMantenedorSuperEjec.InitializarNuevo()
                            objMantenedorSuperEjec.Inicializar(objSql)
                            objWeb.LlenaLSTaux(lbxDisponibles, objMantenedorSuperEjec.EjecutivoAsignado, "rut", "nombres")
                        End If

                    End If
                End If
            End If

            Me.btnGrabar.Attributes.Add("Onclick", "if (typeof(Page_ClientValidate) == 'function')" & _
                                    "Page_ClientValidate();return confirm('¿Está seguro de grabar los datos ingresados?');")
        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_supervisor_ejecutivos_m.aspx:Page_Load->" & ex.Message)
        End Try
    End Sub
    Public Sub Grabar()
        Try
            Dim strValidaLista As String
            Dim i As Integer
            Dim dt As New DataTable
            'Dim dtEjec As New DataTable
            AddColumnDataTable(dt, "rutEjecutivo", "long")
            Dim dr As DataRow
            dr = dt.NewRow
            'objMantenedorSuperEjec.RutSupervisor = Me.ddlSupervisor.SelectedValue
            'objMantenedorSuperEjec.NombreSupervisor = Me.ddlSupervisor.SelectedItem.Text


            If ViewState("modo") = "actualizar" Then
                objMantenedorSuperEjec.RutSupervisor = Me.ddlSupervisor.SelectedValue
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strValidaLista = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strValidaLista)
                Next
                objMantenedorSuperEjec.Traspaso = dt
                objMantenedorSuperEjec.Actualizar()
                body.Attributes.Add("onload", "alert('Los datos se actualizaron exitosamente');")
            ElseIf ViewState("modo") = "insertar" Then
                objMantenedorSuperEjec.RutSupervisor = Me.ddlSupervisor.SelectedValue
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    objMantenedorSuperEjec.RutEjecutivo = Me.lbxAsignados.Items(i).Value
                    If objSql.ExisteEjecutivoParaSupervisor(Me.lbxAsignados.Items(i).Value, Me.ddlSupervisor.SelectedValue) Then
                        body.Attributes.Add("onload", "alert('El supervisor ya posee asignado al ejecutivo: " & Me.lbxAsignados.Items(i).Text & "');")
                        Exit Sub
                    End If
                    objMantenedorSuperEjec.Insertar()
                Next
                body.Attributes.Add("onload", "alert('Los datos de ingresaron exitosamente');")
                'Me.txtNomSupervisor.Text = ""
                'Me.txtRutSupervisor.Text = 0
            Else
                objMantenedorSuperEjec.RutSupervisor = Me.ddlSupervisor.SelectedValue
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    objMantenedorSuperEjec.RutEjecutivo = Me.lbxAsignados.Items(i).Value
                    objMantenedorSuperEjec.Insertar()
                Next
                body.Attributes.Add("onload", "alert('Los datos de ingresaron exitosamente');")
                'Me.txtNomSupervisor.Text = ""
                'Me.txtRutSupervisor.Text = 0
            End If
        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_supervisor_ejecutivos_m.aspx:Page_Load->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub

    Protected Sub btnVa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVa.Click
        objWeb.CargaLst(Me.lbxDisponibles, Me.lbxAsignados)
    End Sub

    Protected Sub btnVaall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVaall.Click
        objWeb.CargaLstcompleta(lbxDisponibles, lbxAsignados)
    End Sub

    Protected Sub btnViene_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViene.Click
        objWeb.CargaLst(lbxAsignados, lbxDisponibles)
    End Sub

    Protected Sub btnVieneall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVieneall.Click
        objWeb.CargaLstcompleta(lbxAsignados, lbxDisponibles)
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_supervisor_ejecutivos.aspx")
    End Sub
End Class
