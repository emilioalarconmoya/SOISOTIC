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
    Dim objFichaAporte As New CAporte
    Dim objCartaOtec As New CCartaOtec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        body.Attributes.Clear()
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        If Not Page.IsPostBack Then

            ViewState("emailEmpresa") = Request("emailEmpresa")
            'ViewState("emailOtec") = Request("emailOtec")
            ViewState("CodAporte") = Request("CodAporte")
            ViewState("rutUsuario") = Request("rutUsuario")
            Me.txtEmailEmpresas.Text = ViewState("emailEmpresa")
            'Me.txtEmailOtecs.Text = ViewState("emailOtec")
            btnCerrar.Attributes.Add("onClick", "javascript:window.close();")

        End If

    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Correo()
    End Sub
    Private Sub Correo()
        Try
            
            objFichaAporte.RutUsuario = objSession.Rut

            Dim arrDestinatariosEmpresa
            Dim arrDestinatariosCC
            arrDestinatariosEmpresa = Split(Me.txtEmailEmpresas.Text.Trim, ",")
            arrDestinatariosCC = Split(Me.txtEmailOtecs.Text.Trim, ",")

            Dim objEnviarEmail As New CEnviarCorreo
            Dim objSql As New CSql
            Dim strSubject As String = ""
            Dim strBody As String = ""
            Dim strTo As String = ""
            Dim strNobreSD As String = ""
            Dim i As Integer
            Dim j As Integer
            Dim strAdjuntoAporte As String = ""
            'Dim strAdjuntoCartaOtec As String = ""
            Dim TamDestin As Integer
            
       
            If Me.txtEmailEmpresas.Text = "" And Me.txtEmailOtecs.Text = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe agregar una dirección de correo');")
                Exit Sub
            Else
                If Me.txtEmailEmpresas.Text <> "" Then
                    objFichaAporte.BajarHtml = True
                    objFichaAporte.GenerarAportePDF(ViewState("CodAporte"))
                    strAdjuntoAporte = objFichaAporte.RutaArchivoVirtual

                    TamDestin = TamanoArreglo1(arrDestinatariosEmpresa) - 1

                    For i = 0 To TamDestin
                        strTo = arrDestinatariosEmpresa(i).ToString.Trim
                        strBody = Me.txtCuerpoEmail.Text.Trim
                        If Me.txtAsuntoEmail.Text = "" Then
                            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe agregar un asunto para enviar el correo');")
                            Exit Sub
                        End If
                        strSubject = Me.txtAsuntoEmail.Text.Trim
                        If strAdjuntoAporte <> "" Then
                            objEnviarEmail.Html = True
                            objEnviarEmail.Archivo = DIRFISICOAPP() & objFichaAporte.RutaArchivoVirtual
                        End If
                        objEnviarEmail.EnviarCorreo(Parametros.p_USUARIOCORREO, strTo, _
                                           strSubject, strBody, Parametros.p_SERVIDORCORREO)
                    Next
                ViewState("exito") = "si"

                End If
                If Me.txtEmailOtecs.Text <> "" Then
                    'objCartaOtec.BajarHtml = True
                    'objCartaOtec.Inicializar(ViewState("codCurso"), ViewState("rutUsuario"))
                    'strAdjuntoCartaOtec = objCartaOtec.DireccionArchivo
                    'TamDestin = TamanoArreglo1(arrDestinatariosOtec) - 1

                    For j = 0 To TamDestin
                        strTo = arrDestinatariosCC(j).ToString.Trim
                        strBody = Me.txtCuerpoEmail.Text.Trim
                        strSubject = Me.txtAsuntoEmail.Text.Trim
                        'If strAdjuntoCartaOtec <> "" Then
                        '    objEnviarEmail.Html = True
                        '    objEnviarEmail.Archivo = DIRFISICOAPP() & objCartaOtec.DireccionArchivo
                        'End If
                        objEnviarEmail.EnviarCorreo(Parametros.p_USUARIOCORREO, strTo, _
                                           strSubject, strBody, Parametros.p_SERVIDORCORREO)
                    Next
                    ViewState("exito") = "si"
                End If
                If ViewState("exito") = "si" Then
                    body.Attributes.Add("onload", "alert('Correo(s) enviado(s) exitosamente');")
                End If
            End If
            Dim strscript As String = "<script language=javascript>window.top.close();</script>"

            If (Not Page.IsStartupScriptRegistered("clientScript")) Then
                Page.RegisterStartupScript("clientScript", strscript)
            End If


        Catch ex As Exception
            EnviaError("modulo_cursos_enviar_correo-->Correo" & ex.Message)
        End Try
        
    End Sub

    
End Class
