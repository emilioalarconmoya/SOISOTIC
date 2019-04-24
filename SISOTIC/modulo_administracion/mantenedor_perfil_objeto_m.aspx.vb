Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_perfil_objeto_m
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantPerfilObjeto As CMantenedorPerfilObjeto
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantPerfilObjeto = New CMantenedorPerfilObjeto
            btnGrabar.OnClientClick = "return confirm('Está apunto de hacer cambios en el perfil seleccionado\n¿Desea continuar?');"
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                If Request("nuevo") = "no" Then
                    ViewState("modo") = "actualizar"
                    TablaPerfiles.Visible = True
                    TablaNuevoPerfil.Visible = False
                    ViewState("CodPerfil") = Request("codPerfil")
                    objWeb.LlenaDDL(ddlPerfiles, objMantPerfilObjeto.PerfilesTodos, "cod_perfil", "nombre")
                    ddlPerfiles.SelectedValue = ViewState("CodPerfil")
                    objMantPerfilObjeto.CodPerfil = ddlPerfiles.SelectedValue
                    objMantPerfilObjeto.NombrePerfil = Request("nombrePerfil")
                    objMantPerfilObjeto.Consultar()
                    objWeb.LlenaLSTaux(lbxDisponibles, objMantPerfilObjeto.ObjetosNoAsignados, "cod_objeto", "nombre")
                    objWeb.LlenaLSTaux(lbxAsignados, objMantPerfilObjeto.ObjetosAsignados, "cod_objeto", "nombre")
                    
                Else
                    ViewState("modo") = "insertar"
                    TablaNuevoPerfil.Visible = True
                    TablaPerfiles.Visible = False
                    objWeb.LlenaLSTaux(lbxDisponibles, objMantPerfilObjeto.ObjetosTodos, "cod_objeto", "nombre")

                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
                objMantPerfilObjeto = Nothing
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Grabar()
        Dim i As Integer
        Dim strValidaLista As String
        Try
            Dim dt As New DataTable
            AddColumnDataTable(dt, "cod_objeto", "integer")
            Dim dr As DataRow
            dr = dt.NewRow
            objMantPerfilObjeto = New CMantenedorPerfilObjeto
            If ViewState("modo") = "actualizar" Then
                objMantPerfilObjeto.CodPerfil = ViewState("CodPerfil")
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strValidaLista = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strValidaLista)
                Next
                objMantPerfilObjeto.Traspaso = dt
                If objMantPerfilObjeto.Actualizar() Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Perfil actualizado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido actualizar perfil!');</script>")
                End If
                objMantPerfilObjeto = Nothing
            Else
                objMantPerfilObjeto.NombrePerfil = Me.txtNuevoPerfil.Text
                objMantPerfilObjeto.InsertarPerfil()
                objMantPerfilObjeto.ConsultarPerfil()
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strValidaLista = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strValidaLista)
                Next
                objMantPerfilObjeto.Traspaso = dt
                If objMantPerfilObjeto.Insertar Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Perfil insertado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido insertado perfil!');</script>")
                End If
            End If
        Catch ex As Exception
            EnviaError("mantenedor_perfil_objeto_m.aspx.vb: Grabar--> " & ex.Message)
        End Try
    End Sub

    Protected Sub btnVa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVa.Click
        objWeb.CargaLst(Me.lbxDisponibles, Me.lbxAsignados)
    End Sub
    Protected Sub btnViene_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViene.Click
        objWeb.CargaLst(lbxAsignados, lbxDisponibles)
    End Sub
    Protected Sub btnVieneall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVieneall.Click
        objWeb.CargaLstcompleta(lbxAsignados, lbxDisponibles)
    End Sub
    Protected Sub btnVaall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVaall.Click
        objWeb.CargaLstcompleta(lbxDisponibles, lbxAsignados)
    End Sub
    Sub LimpiaList()
        Me.lbxAsignados.Items.Clear()
        Me.lbxDisponibles.Items.Clear()
        Me.ddlPerfiles.Items.Clear()
    End Sub
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    'Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
    '    Response.Redirect("mantenedor_perfil_objeto.aspx")
    'End Sub
    Protected Sub ddlPerfiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPerfiles.SelectedIndexChanged
        Try
            objMantPerfilObjeto = New CMantenedorPerfilObjeto
            objWeb = New CWeb
            objMantPerfilObjeto.CodPerfil = ddlPerfiles.SelectedValue
            objMantPerfilObjeto.Consultar()
            objWeb.LlenaLSTaux(lbxDisponibles, objMantPerfilObjeto.ObjetosNoAsignados, "cod_objeto", "nombre")
            objWeb.LlenaLSTaux(lbxAsignados, objMantPerfilObjeto.ObjetosAsignados, "cod_objeto", "nombre")
        Catch ex As Exception
            EnviaError("mantenedor_perfil_objeto_m.aspx.vb: ddlPerfiles_SelectedIndexChanged--> " & ex.Message)
        End Try
    End Sub
End Class
