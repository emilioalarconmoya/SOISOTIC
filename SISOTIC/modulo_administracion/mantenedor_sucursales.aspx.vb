Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_sucursales
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objCSql As New CSql
    Dim objMantenedorSucursales As New CMantenedorSucursales
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()

            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                'Me.btnEliminar.Attributes.Add("onclick", "if (typeof(Page_ClientValidate) == 'function')" & _
                '" Page_ClientValidate();return confirm('" & Me.hdfConfirmarEliminar.Value & "');")

            End If

        Catch ex As Exception
            EnviaError("modulo_administracionmantenedor_sucursales.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Sub Consultar()

        Try
            objMantenedorSucursales.BajarXml = chkBajarReporte.Checked
            If Me.txtNombreSucursal.Text = "" Then
                objMantenedorSucursales.NomSucursal = ""
            Else
                objMantenedorSucursales.NomSucursal = Me.txtNombreSucursal.Text
            End If
            Dim dt As DataTable
            dt = objMantenedorSucursales.Consultar()
            

            objWeb.LlenaGrilla(grdSucursal, dt)
            If grdSucursal.Rows.Count > 0 Then
                ' Me.btnEliminar.Visible = True
            Else
                ' Me.btnEliminar.Visible = False
            End If
            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objMantenedorSucursales.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_sucursales.aspx:SubConsultar->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdSucursal_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdSucursal.PageIndexChanging
        Me.grdSucursal.PageIndex = e.NewPageIndex 'Se posiciona en la página
        Consultar()
    End Sub
 
    Protected Overrides Sub Finalize()
        Try
            objWeb = Nothing
            objMantenedorSucursales = Nothing
            objCSql = Nothing
            MyBase.Finalize()
            grdSucursal.Dispose()
        Catch ex As System.Exception
            EnviaError("mantenedor_atributos.aspx:Finalize->" & ex.Message)
        End Try
    End Sub
    ' avisa al mantenedor sobre un ingreso nuevo
    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub
    Public Sub Agregar()
        Dim dt As DataTable
        dt = Nothing
        objMantenedorSucursales = Nothing
        Response.Redirect("mantenedor_sucursales_m.aspx?nuevo=si")
    End Sub
    Public Sub Eliminar()
        
    End Sub
    'Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
    '    Try
    '        'Dim btnEliminar As Button = CType(sender, Button) 'Obtengo el DropDownList que ha invocado al método
    '        'Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
    '        Dim fila As GridViewRow
    '        Dim chk As New CheckBox
    '        Dim objCol As New System.Collections.ArrayList
    '        Dim objSql As New CSql
    '        Dim strCodigo As Label
    '        'strCodigo = CType(row.FindControl("lblCodSucursal"), Label)
    '        Dim strTabla As String
    '        Dim strCampo As String

    '        Dim lblCodSucursal As Label

    '        strTabla = "director_sucursal"
    '        strCampo = "cod_sucursal"

    '        For Each fila In Me.grdSucursal.Rows
    '            objMantenedorSucursales = New CMantenedorSucursales
    '            chk = CType(fila.FindControl("chkEliminar"), CheckBox)
    '            lblCodSucursal = CType(fila.FindControl("lblCodSucursal"), Label)
    '            objMantenedorSucursales.CodSucursal = lblCodSucursal.Text

    '            If chk.Checked Then
    '                If objSql.ExisteCodigoString(lblCodSucursal.Text, strTabla, strCampo) Then
    '                    body.Attributes.Add("onload", "alert('¡No se puede eliminar esta sucursal!');")
    '                    Exit Sub
    '                End If
    '                objMantenedorSucursales.colEliminacion = objCol
    '                objMantenedorSucursales.Eliminar()
    '                body.Attributes.Add("onload", "alert('" & Me.hdfEliminarExito.Value & "');")
    '                'ViewState("elimino") = "si"

    '            Else
    '                body.Attributes.Add("onload", "alert('" & Me.hdfAlertSeleccionarAtributo.Value & "');")
    '            End If
    '        Next
    '        Consultar()

    '    Catch ex As Exception
    '        EnviaError("mantenedor_sucursales.aspx:Eliminar->" & ex.Message)
    '    End Try

    'End Sub
   

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button) 'Obtengo el DropDownList que ha invocado al método
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblCodSuscursal As Label
        lblCodSuscursal = CType(row.FindControl("lblCodSucursal"), Label)
        Dim lblNomSucursal As Label
        lblNomSucursal = CType(row.FindControl("lblNomSucursal"), Label)
        Response.Redirect("mantenedor_sucursales_m.aspx?CodSucursal=" & lblCodSuscursal.Text & "&NombreSucursal=" & lblNomSucursal.Text)
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim btnEliminar As Button = CType(sender, Button) 'Obtengo el DropDownList que ha invocado al método
            Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
            Dim fila As GridViewRow
            Dim chk As New CheckBox
            Dim objCol As New System.Collections.ArrayList
            Dim objSql As New CSql
            Dim strCodigo As Label
            'strCodigo = CType(row.FindControl("lblCodSucursal"), Label)
            Dim strTabla As String
            Dim strCampo As String
            Dim strTabla2 As String
            Dim strCampo2 As String

            Dim lblCodSucursal As Label

            strTabla = "director_sucursal"
            strCampo = "cod_sucursal"
            strTabla2 = "empresa_cliente"
            strCampo2 = "cod_sucursal"

            For Each fila In Me.grdSucursal.Rows
                objMantenedorSucursales = New CMantenedorSucursales
                'chk = CType(fila.FindControl("chkEliminar"), CheckBox)
                lblCodSucursal = CType(row.FindControl("lblCodSucursal"), Label)
                objMantenedorSucursales.CodSucursal = lblCodSucursal.Text

                'If chk.Checked Then
                If objSql.ExisteCodigoString(lblCodSucursal.Text, strTabla, strCampo) Then
                    body.Attributes.Add("onload", "alert('¡No se puede eliminar esta sucursal!');")
                    Exit Sub
                End If
                If objSql.ExisteCodigoString(lblCodSucursal.Text, strTabla2, strCampo2) Then
                    body.Attributes.Add("onload", "alert('¡No se puede eliminar esta sucursal!');")
                    Exit Sub
                End If
                objMantenedorSucursales.colEliminacion = objCol
                objMantenedorSucursales.Eliminar()
                body.Attributes.Add("onload", "alert('" & Me.hdfEliminarExito.Value & "');")
                'ViewState("elimino") = "si"

                'Else
                'body.Attributes.Add("onload", "alert('" & Me.hdfAlertSeleccionarAtributo.Value & "');")
                'End If
            Next
            Consultar()

        Catch ex As Exception
            EnviaError("mantenedor_sucursales.aspx:Eliminar->" & ex.Message)
        End Try
    End Sub
End Class
