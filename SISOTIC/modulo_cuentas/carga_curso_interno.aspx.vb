Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_carga_curso_interno
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim ObjCargaCurso As New CCargaCursoInternoXls
    Private objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        body.Attributes.Clear()
        lblPie.Text = Parametros.p_PIE
        objWeb.ChequeaCliente(objSessionCliente)
        If objSession.EsClienteIngresoCurso Then
            Me.hplIngresoCurso.Visible = True
        End If
        If objSession.Rut = 96616770 Then
            Me.lblCorrelativoEmpresa.Visible = True
            Me.lblCorrelativoEmpresa.Text = "Debe ingresar el correlativo : " & ObjCargaCurso.SiguienteCorrelativo(objSession.Rut)
        Else
            If objSessionCliente.Rut = 96616770 Then
                Me.lblCorrelativoEmpresa.Visible = True
                Me.lblCorrelativoEmpresa.Text = "Debe ingresar el correlativo : " & ObjCargaCurso.SiguienteCorrelativo(objSessionCliente.Rut)
            End If
        End If
    End Sub
    Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        Try
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
            If strExtension = ".xls" Then
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

                    ObjCargaCurso.inicializar()
                    ObjCargaCurso.RutUsuario = objSession.Rut
                    ObjCargaCurso.Cargar_Archivo(savePath)
                    If Not ObjCargaCurso.Errores Then
                        Session("otic.dtLog") = ObjCargaCurso.Mensajes
                    Else
                        Session("otic.dtLog") = ObjCargaCurso.MensajeAciertos
                    End If
                    'Se pasan a la ventana siguiente y se limpian automáticamente
                    body.Attributes.Add("onLoad", "popup_pos('./reporte_log.aspx', 'NewWindow', 510, 800, 100, 100);return false;")

                End If
            Else
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript1", "<script language='javascript' type='text/javascript'> " & _
                                         "alert('¡El tipo de archivo es incorrecto. el archivo debe tener una extención .xls!');</script>")
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas_curso_interno:btnSubir_Click-->" & ex.Message)
        End Try
        
    End Sub
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("menu_cargas.aspx")
    End Sub
End Class
