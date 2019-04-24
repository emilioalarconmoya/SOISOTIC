Imports Clases
Imports modulos
Imports System.xml
Imports System.xml.XPath
Imports System.Xml.Schema
Imports System.Data
Imports Clases.Web
Partial Class modulo_cursos_carga_web_service
    Inherits System.Web.UI.Page

    Private objCarga As CCargaCurso
    Dim objSession As CSession
    Dim mObjCsql As New CSql
    Dim objWeb As CWeb
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                'If Not Request("origen") = 1 Then
                '    Response.Redirect("no_autorizado.aspx")
                'End If
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

            End If

            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"

        Catch ex As Exception
            EnviaError("carga_cursos.aspx:Page_Load->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Try
            'Me.txtResultado.Text = ""
            Dim dtTmp As datatable
            If Me.fulXML.FileName = "" Then
                body.Attributes.Add("onload", "alert('Debe ingresar todos los datos solicitados');")
                Exit Sub
            End If
            If Not Right(Me.fulXML.FileName, 4).ToString.ToLower = ".xml" Then
                body.Attributes.Add("onload", "alert('El archivo de cargo debe tener extención XML');")
                Exit Sub
            End If

            Dim savePath As String = Server.MapPath("~/contenido/tmp/")
            If Not fulXML.HasFile Then
                body.Attributes.Add("onload", "alert('El archivo que esta intentando cargar no existe');")
                Exit Sub
            Else
                Dim fileName As String = fulXML.FileName
                savePath += fileName
                Dim counter As Integer = 2
                While (System.IO.File.Exists(savePath))
                    System.IO.File.Delete(savePath)
                End While
                fulXML.SaveAs(savePath)
            End If

            objCarga = New CCargaCurso
            If Not objCarga.ValidarXML(savePath) Then
                body.Attributes.Add("onload", "alert('El archivo xml ingresado no posee el formato correcto.\nFavor de revisar todos sus nodos e intentar nuevamente');")
                Exit Sub
            End If

            objCarga.RutEjecutivo = objSession.Rut
            objCarga.RutCliente = objSession.Rut
            dtTmp = mObjCsql.s_usuario(objSession.Rut)
            If Not dtTmp Is Nothing Then
                objCarga.ClaveAcceso = DecryptINI$(dtTmp.Rows(0)("passwd_enc"))
            Else
                objCarga.ClaveAcceso = ""
            End If
            objCarga.UrlCarga = savePath
            objCarga.Cargar()
            'Dim xmlDoc As New XmlDataDocument
            'xmlDoc.Load(objCarga.Resultado)
            'Me.txtResultado.Text = Replace(Replace(xmlDoc.OuterXml, ">", ">" & vbCr), "<", vbCr & "<")
            lit.Text = "<iframe class='datoResultado' src='" & objCarga.Resultado & "'></iframe>"
        Catch ex As Exception
            EnviaError("carga_cursos.aspx:btnCargar_Click->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click

    End Sub
End Class
