Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_comunicar_curso_sence_csv
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objComunicar As CComunicar
    Dim objZip As CZip

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            objWeb = New CWeb

            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            ViewState("CodCurso") = Request("codCurso")

            If Not Page.IsPostBack Then
                Dim strOrigen As String
                Dim blnEnComunicacion As Boolean
                Dim blnEnLiquidacion As Boolean
                Dim strCodigosCursos As String
                lblPie.Text = Parametros.p_PIE
                strOrigen = Request("hdfOrigen")
                If ViewState("CodCurso") Is Nothing Then
                    strCodigosCursos = "-1"
                Else
                    strCodigosCursos = ViewState("CodCurso")
                End If

                If Not Request("enComunicacion") Is Nothing Then
                    blnEnComunicacion = Request("enComunicacion")
                End If
                If Not Request("enLiquidacion") Is Nothing Then
                    blnEnLiquidacion = Request("enLiquidacion")
                End If

                If strOrigen Is Nothing Then
                    If strOrigen = "ADMINISTRACION" Then
                        Me.menu.Visible = False
                        Me.btnVolver.Visible = True
                    End If
                End If
                objComunicar = New CComunicar
                objComunicar.RutUsuario = objSession.Rut
                If Not strOrigen = "ADMINISTRACION" Then
                    objComunicar.EnComunicacion = blnEnComunicacion
                    objComunicar.EnLiquidacion = blnEnLiquidacion
                    objComunicar.Codigos = strCodigosCursos
                    'objComunicar.GenerarBase()
                End If
                objComunicar = Nothing
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception

            EnviaError("comunicar_cursos_sence.aspx:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub hplPaso2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hplPaso2.Click
        Try
            objComunicar = New CComunicar
            If objComunicar.RespaldarCSV() Then
                body.Attributes.Add("onload", "alert('Se ha respaldado correctamente el archivo.');")
            End If
            objComunicar = Nothing
        Catch ex As Exception
            EnviaError("comunicar_cursos_sence.aspx:hplPaso2_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnComunicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComunicar.Click
        Try
            Dim objComunicar As New CComunicar
            objComunicar.inicializar()
            objComunicar.RutUsuario = objSession.Rut
            Dim fileName As String
            Dim savePath As String = Server.MapPath("~/contenido/tmp/")
            fileName = fulRespuesta.FileName
            savePath += fileName
            If fulRespuesta.HasFile Then
                If fileName.Substring(fileName.Length - 3) = "txt" Then
                    fileName = NombreArchivoTmp("txt")
                    Me.fulRespuesta.SaveAs(savePath)
                    objComunicar.RespuestaSence(savePath)
                ElseIf fileName.Substring(fileName.Length - 3) = "bak" Then
                    fileName = NombreArchivoTmp("bak")
                    Me.fulRespuesta.SaveAs(savePath)
                    objComunicar.RespuestaSence(savePath)
                ElseIf fileName.Substring(fileName.Length - 3) = "BAK" Then
                    fileName = NombreArchivoTmp("BAK")
                    Me.fulRespuesta.SaveAs(savePath)
                    objComunicar.RespuestaSence(savePath)
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " & _
                          "alert('¡Error con el formato del archivo tiene que ser un txt o bak!');" & _
                          "</script>")
                End If
            End If
            objweb = New cweb
            objWeb.LlenaGrilla(Me.grdResultados, objComunicar.Datos)
            If Not objComunicar.Mensajes Is Nothing Then
                Dim numErrores As Integer
                numErrores = objComunicar.Mensajes.Rows.Count
                If numErrores > 0 Then
                    Me.lblNumErrores.Text = numErrores
                    objWeb.LlenaGrilla(Me.grdErrores, objComunicar.Mensajes)
                    Me.tblErrores.Visible = True
                    Me.grdErrores.Visible = True
                Else
                    Me.tblErrores.Visible = False
                    Me.grdErrores.Visible = False
                End If
            Else
                Me.tblErrores.Visible = False
                Me.grdErrores.Visible = False
            End If
            objWeb = Nothing
            Comunicacion.Visible = False
        Catch ex As Exception
            EnviaError("comunicar_cursos_sence.aspx:btnComunicar_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim NombreCarpeta As String = ""
        NombreCarpeta = "acciones_a_comunicar"
        'System.IO.Directory.CreateDirectory(Parametros.p_DIRFISICO & "contenido\tmp\" & NombreCarpeta)
        objZip = New CZip
        objZip.Comprimir(NombreCarpeta)
        objZip = Nothing
        Response.AppendHeader("content-disposition", "attachment; filename=acciones_a_comunicar.zip")
        Response.Clear()
        Response.WriteFile(Parametros.p_DIRFISICO & "contenido\csv\acciones_a_comunicar.zip")
        Response.End()
    End Sub
End Class
