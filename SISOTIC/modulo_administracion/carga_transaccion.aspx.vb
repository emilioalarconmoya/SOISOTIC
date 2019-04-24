Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_carga_inicio
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE

            End If

        Catch ex As Exception
            EnviaError("carga_inicio:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub

    Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        Try
            Dim objCargaTransaccion As New CCargaTransaccion
            Dim fileName As String
            Dim len As Integer
            Dim strExtension As String

            'Toma la Ruta del servidor donde se encuentra la carpeta TMP
            Dim savePath As String = Parametros.p_DIRFISICO & "Contenido\tmp\"
            'Obtengo el nombre de archivo.
            fileName = flpCarga.FileName
            len = fileName.Length
            strExtension = Right(fileName, 4).Trim.ToLower()
            If flpCarga.FileName.Trim = "" Then
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript1", "<script language='javascript' type='text/javascript'> " & _
                                         "alert('¡No existe archivo para cargar datos!');</script>")
                Exit Sub
            End If
            If strExtension = ".xls" Or strExtension = "xlsx" Then
                'Concateno la Ruta del Servidor con el nombre del archivo
                savePath += fileName
                If flpCarga.HasFile Then
                    'Crea un Nombre de Archivo temporal para verificar si existen
                    'archivos duplicados en la carpeta TMP
                    Dim tempfileName As String
                    'Verificamos si el archivo que vamos a bajar a la
                    'carpeta TMP existe.
                    Dim counter As Integer = 2
                    While (System.IO.File.Exists(savePath))
                        savePath = Parametros.p_DIRFISICO & "Contenido\tmp\" '& gstrDirTmp
                        'Si el archivo ya existe, le anteponemos un
                        'número como prefijo, depndiendo de la cantidad
                        'de veces que este archivo exista.
                        tempfileName = ""
                        tempfileName = counter.ToString() + fileName
                        savePath += tempfileName
                        counter = counter + 1
                    End While
                    fileName = tempfileName
                    'graba el archivo en disco
                    flpCarga.SaveAs(savePath)
                    objCargaTransaccion.Inicializar()
                    objCargaTransaccion.RutCliente = objSession.Rut
                    objCargaTransaccion.Cargar_Archivo(savePath)

                    Session("otic.dtLog") = objCargaTransaccion.Mensajes
                    'Se pasan a la ventana siguiente y se limpian automáticamente
                    body.Attributes.Add("onLoad", "popup_pos('../modulo_cursos/reporte_log.aspx', 'NewWindow', 510, 800, 100, 100);return false;")

                End If
            Else
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript1", "<script language='javascript' type='text/javascript'> " & _
                                         "alert('¡El tipo de archivo es incorrecto!');</script>")
            End If
        Catch ex As Exception
            EnviaError("carga_inicio:btnSubir_Click-->" & ex.Message)
        End Try
    End Sub
End Class

