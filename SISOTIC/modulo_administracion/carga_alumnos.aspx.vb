Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_carga_alumnos
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objCarga As CCargaAlumnos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objWeb = Nothing

            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("modo") = Request("modo")
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Try
            objCarga = New CCargaAlumnos

            Dim fileName As String
            Dim savePath As String = Server.MapPath("~/contenido/tmp/")
            fileName = Me.fulAlumnos.FileName
            savePath += fileName
            If fulAlumnos.HasFile Then
                If fileName.Substring(fileName.Length - 3) = "txt" Then
                    fileName = NombreArchivoTmp("txt")
                    fulAlumnos.SaveAs(savePath)
                    objCarga.RutUsuario = objSession.Rut
                    objCarga.Inicializar()
                    objCarga.CargarAlumnos(savePath)
                    Session("dt_log1") = objCarga.Mensajes 'trae los mensajes de la carga
                    'Se pasan a la ventana siguiente y se limpian automáticamente
                    body.Attributes.Add("onLoad", "popup_pos('./reporte_log.aspx', 'NewWindow', 510, 800, 100, 100);return false;")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " & _
                          "alert('¡ATENCIÓN: El formato del archivo debe que 'txt'!');" & _
                          "</script>")
                End If
            Else
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " & _
                                          "alert('¡ATENCIÓN: Debe ingresar un archivo para ser cargado.!');" & _
                                          "</script>")
            End If
            objCarga = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion_carga_alumnos:btnCargar_Click-->" & ex.Message)
        End Try
    End Sub
End Class
