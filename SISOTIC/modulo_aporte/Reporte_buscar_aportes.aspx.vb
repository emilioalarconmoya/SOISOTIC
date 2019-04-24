Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_aporte_Reporte_buscar_aportes
    Inherits System.Web.UI.Page

    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objBuscadorAportes As New CReporteAportes
    Dim mstrBusqueda As String
    Dim objLookups As New Clookups
    'Private objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        Me.TxtNumeroAporte.Attributes.Add("onFocus", " if (document.form1.RbNumeroAporte1.checked == true ){document.form1.RbNumeroAporte1.checked = false;document.form1.RbNumeroAporte2.checked = true;}")
        Me.TxtRutEmpresa.Attributes.Add("onFocus", "if (document.form1.RbRutEmpresa1.checked == true ){document.form1.RbRutEmpresa1.checked = false;document.form1.RbRutEmpresa2.checked = true;}")
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            objWeb.LlenaDDL(Me.DdlCuentaDestino, objLookups.Cuentas2, "cod_cuenta", "nombre")
            objWeb.AgregaValorDDL(Me.DdlCuentaDestino, "Ambos", gValorNumNulo)
            DdlCuentaDestino.SelectedValue = gValorNumNulo
            objWeb.LlenaDDL(Me.ddlEjecutivos, objLookups.EjecutivosTodos, "rut", "nombres")
            objWeb.AgregaValorDDL(Me.ddlEjecutivos, "Todos", gValorNumNulo)
            ddlEjecutivos.SelectedValue = gValorNumNulo
            'Me.RbNumeroAporte1.Checked = True
            'Me.RbRutEmpresa1.Checked = True

        End If
        
    End Sub


    Public Sub Consultar()
        If Not TxtNumeroAporte.Text = "" Then
            If Not IsNumeric(TxtNumeroAporte.Text) Then
                body.Attributes.Add("onload", "alert('ATECIÓN: El número de aporte debe ser un número entero');")
                Exit Sub
            End If
        End If
        
        'filtra por numero aporte
        If Not Me.RbNumeroAporte1.Checked And TxtNumeroAporte.Text <> "" Then
            If Me.RbNumeroAporte2.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.num_aporte = " & Me.TxtNumeroAporte.Text & " "
            End If
            If Me.RbNumeroAporte3.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.num_aporte > " & Me.TxtNumeroAporte.Text & " "
            End If
            If Me.RbNumeroAporte4.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.num_aporte < " & Me.TxtNumeroAporte.Text & " "
            End If
            If Me.RbNumeroAporte5.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.num_aporte <> " & Me.TxtNumeroAporte.Text & " "
            End If
        ElseIf Not Me.RbNumeroAporte1.Checked And TxtNumeroAporte.Text <> "" Then
            'body.Attributes.Add("onload", "alert('Debe ingresar rut de empresa');")
            Me.TxtRutEmpresa.Focus()
            Exit Sub
        End If


        'filtra por rut empresa 
        If Not Me.RbRutEmpresa1.Checked And TxtRutEmpresa.Text <> "" Then
            If Me.RbRutEmpresa2.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.rut_cliente = " & RutUsrALng(Me.TxtRutEmpresa.Text) & " "
            End If
            If Me.RbRutEmpresa3.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.rut_cliente > " & RutUsrALng(Me.TxtRutEmpresa.Text) & " "
            End If
            If Me.rbRutEmpresa4.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.rut_cliente < " & RutUsrALng(Me.TxtRutEmpresa.Text) & " "
            End If
            If Me.RbRutEmpresa5.Checked Then
                mstrBusqueda = mstrBusqueda & " And ap.rut_cliente <> " & RutUsrALng(Me.TxtRutEmpresa.Text) & " "
            End If
        ElseIf Not Me.RbRutEmpresa1.Checked And TxtRutEmpresa.Text <> "" Then
            'body.Attributes.Add("onload", "alert('Debe ingresar rut de empresa');")
            Me.TxtRutEmpresa.Focus()
            Exit Sub
        End If

        'filtra por tipo de cuenta
        If DdlCuentaDestino.SelectedValue = gValorNumNulo Then
            mstrBusqueda = mstrBusqueda & " And ap.cod_cuenta in (1,2) "
        ElseIf DdlCuentaDestino.SelectedValue = 1 Then
            mstrBusqueda = mstrBusqueda & " And ap.cod_cuenta in (" & DdlCuentaDestino.SelectedValue & ") "
        ElseIf DdlCuentaDestino.SelectedValue = 2 Then
            mstrBusqueda = mstrBusqueda & " And ap.cod_cuenta in (" & DdlCuentaDestino.SelectedValue & ") "
        End If
        If ddlEjecutivos.SelectedValue <> gValorNumNulo Then
            mstrBusqueda = mstrBusqueda & " and ej.rut_ejecutivo =" & ddlEjecutivos.SelectedValue
        End If

        'filtra por nombre
        If Me.TxtPalabraClave.Text <> "" Then
            mstrBusqueda = mstrBusqueda & " And pj.razon_social like '" & TxtPalabraClave.Text & "%' "
        End If
        Response.Redirect("./reporte_aportes.aspx?Origen=BuscarCursos&Filtros=" & mstrBusqueda)
    End Sub

    
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Consultar()
    End Sub

    Protected Sub TxtRutEmpresa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRutEmpresa.TextChanged

    End Sub
End Class
