Imports Modulos
Imports Clases
Imports System.Data
Imports Clases.Web
Imports System.Web.Mail
Partial Class modulo_cursos_enviar_correo
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As New CFichaCursoContratado
    Dim curso As New CCursoInterno
    Dim objLookups As New Clookups
    Dim objCartaEmpresa As New CCartaEmpresa
    Dim objCartaOtec As New CCartaOtec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        body.Attributes.Clear()
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        If Not Page.IsPostBack Then

            ViewState("emailEmpresa") = Request("emailEmpresa")
            ViewState("emailOtec") = Request("emailOtec")
            ViewState("codCurso") = Request("codCurso")
            ViewState("rutUsuario") = Request("rutUsuario")
            Me.txtEmailEmpresas.Text = ViewState("emailEmpresa")
            Me.txtEmailOtecs.Text = ViewState("emailOtec")
            btnCerrar.Attributes.Add("onClick", "javascript:window.close();")

        End If

    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Correo()
    End Sub
    Private Sub Correo()
        Try
            objReporte = New CFichaCursoContratado
            Dim ccursocontratado As New CCursoContratado
            objReporte.CodCurso = ViewState("codCurso")
            Dim lngCodCurso As Long
            Dim lngRutCliente As Long
            lngCodCurso = ViewState("CodCurso")
            lngRutCliente = objSession.Rut
            objReporte.RutCliente = objSession.Rut
            objReporte.Agno = objSession.Agno

            Dim arrDestinatariosEmpresa
            Dim arrDestinatariosOtec
            arrDestinatariosEmpresa = Split(Me.txtEmailEmpresas.Text.Trim, ",")
            arrDestinatariosOtec = Split(Me.txtEmailOtecs.Text.Trim, ",")

            Dim objEnviarEmail As New CEnviarCorreo
            Dim objSql As New CSql
            Dim strSubject As String = ""
            Dim strBody As String = ""
            Dim strTo As String = ""
            Dim strNobreSD As String = ""
            Dim i As Integer
            Dim j As Integer
            Dim strAdjuntoCartaEmpresa As String = ""
            Dim strAdjuntoCartaOtec As String = ""
            Dim TamDestin As Integer
            
       
            If Me.txtEmailEmpresas.Text = "" And Me.txtEmailOtecs.Text = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe agregar una dirección de correo');")
                Exit Sub
            Else
                If Me.txtEmailEmpresas.Text <> "" Then
                    objCartaEmpresa.BajarHtml = True
                    objCartaEmpresa.EnviaCartaEmpresa(ViewState("codCurso"), ViewState("rutUsuario"))
                    strAdjuntoCartaEmpresa = objCartaEmpresa.DireccionArchivo

                    TamDestin = TamanoArreglo1(arrDestinatariosEmpresa) - 1

                    For i = 0 To TamDestin
                        strTo = arrDestinatariosEmpresa(i).ToString.Trim
                        strBody = Me.txtCuerpoEmail.Text.Trim
                        If Me.txtAsuntoEmail.Text = "" Then
                            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe agregar un asunto para enviar el correo');")
                            Exit Sub
                        End If
                        strSubject = Me.txtAsuntoEmail.Text.Trim
                        If strAdjuntoCartaEmpresa <> "" Then
                            objEnviarEmail.Html = True
                            objEnviarEmail.Archivo = DIRFISICOAPP() & objCartaEmpresa.DireccionArchivo
                        End If
                        objEnviarEmail.EnviarCorreo(Parametros.p_USUARIOCORREO, strTo, _
                                           strSubject, strBody, Parametros.p_SERVIDORCORREO)
                    Next
                ViewState("exito") = "si"

                End If
                If Me.txtEmailOtecs.Text <> "" Then
                    objCartaOtec.BajarHtml = True
                    objCartaOtec.EnviaCartaOtec(ViewState("codCurso"), ViewState("rutUsuario"))
                    strAdjuntoCartaOtec = objCartaOtec.DireccionArchivo
                    TamDestin = TamanoArreglo1(arrDestinatariosOtec) - 1

                    For j = 0 To TamDestin
                        strTo = arrDestinatariosOtec(j).ToString.Trim
                        strBody = Me.txtCuerpoEmail.Text.Trim
                        strSubject = Me.txtAsuntoEmail.Text.Trim
                        If strAdjuntoCartaOtec <> "" Then
                            objEnviarEmail.Html = True
                            objEnviarEmail.Archivo = DIRFISICOAPP() & objCartaOtec.DireccionArchivo
                        End If
                        objEnviarEmail.EnviarCorreo(Parametros.p_USUARIOCORREO, strTo, _
                                           strSubject, strBody, Parametros.p_SERVIDORCORREO)
                    Next
                    ViewState("exito") = "si"
                End If
                If ViewState("exito") = "si" Then
                    body.Attributes.Add("onload", "alert('Correo(s) enviado(s) exitosamente');")
                End If
            End If
            

        Catch ex As Exception
            EnviaError("modulo_cursos_enviar_correo-->Correo" & ex.Message)
        End Try
        
    End Sub

    
End Class
