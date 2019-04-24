Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_aporte_anular_aporte
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSesion As CSession
    Dim objIngresoAporte As New CIngresoAporte
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSesion)
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                If Not Request("CodAporte") Is Nothing Then
                    If Not Request("CodAporte").ToString.Trim = "" Then
                        ViewState("CodAporte") = Request("CodAporte").ToString.Trim
                        CargarAporte()
                    Else
                        body.Attributes.Add("onload", "alert('ATENCIÓN: No se ha seleccionado un aporte a anular.');")
                    End If
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: No se ha seleccionado un aporte a anular.');")
                End If
            End If
        Catch ex As Exception
            EnviaError("modulo_aporte/ingreso_aporte:Page_load-->" & ex.Message)
        End Try
    End Sub
    Public Sub CargarAporte()
        Try
            objIngresoAporte = New CIngresoAporte
            objIngresoAporte.Inicializar()
            objIngresoAporte.CodAporte = ViewState("CodAporte")
            objIngresoAporte.CargarAporte()

            Me.lblFolio.Text = objIngresoAporte.Correlativo
            Me.lblEstado.Text = objIngresoAporte.Estado
            Me.lblOrigen.Text = objIngresoAporte.Origen
            Me.lblFechaIngreso.Text = objIngresoAporte.FechaIngreso

        Catch ex As Exception
            EnviaError("modulo_aporte/ingreso_aporte:CargarAporte-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            If Me.txtMotivo.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un motivo para anular el aporte.');")
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If
            objIngresoAporte = New CIngresoAporte
            objIngresoAporte.Inicializar()
            objIngresoAporte.Glosa = Me.txtMotivo.Text
            objIngresoAporte.RutUsuario = objSesion.Rut
            objIngresoAporte.CodAporte = ViewState("CodAporte")
            objIngresoAporte.AnularAporte()
            body.Attributes.Add("onload", "alert('ATENCIÓN: El aporte ha sido anulado correctamente.');")
            Me.btnAnular.Visible = False
            Me.hdfEnvioDatos.Value = 0
            CargarAporte()
        Catch ex As Exception
            Me.hdfEnvioDatos.Value = 0
            EnviaError("modulo_aporte/ingreso_aporte:btnAnular_Click-->" & ex.Message)
        End Try
        
    End Sub
End Class
