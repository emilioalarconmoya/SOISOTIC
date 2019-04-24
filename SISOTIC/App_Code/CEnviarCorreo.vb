Imports System.Net.Mail
Imports Modulos
Imports System.Web.UI
Namespace Clases
    Public Class CEnviarCorreo
        Private mblnFormatoHtml As Boolean
        Private mstrServidorSmtp As String
        Private mstrArchivoAdjunto As String
        Public Property Html() As Boolean
            Get
                Return mblnFormatoHtml
            End Get
            Set(ByVal value As Boolean)
                mblnFormatoHtml = value
            End Set
        End Property
        Public Property ServidorSmtp() As String
            Get
                Return mstrServidorSmtp
            End Get
            Set(ByVal value As String)
                mstrServidorSmtp = value
            End Set
        End Property
        Public WriteOnly Property Archivo() As String
            Set(ByVal value As String)
                mstrArchivoAdjunto = value
            End Set
        End Property
        Public Function EnviarCorreo(ByVal strFrom As String, ByVal strTo As String, _
                                                ByVal strSubject As String, ByVal strBody As String, _
                                                Optional ByVal strServerSmtp As String = "", _
                                                Optional ByVal strCC As String = "") As Boolean
            Dim oMsg As MailMessage = New MailMessage
            Try
                Select Case Parametros.p_TIPOENVIOCORREO
                    Case "net"
                        oMsg.From = New MailAddress(strFrom)
                        oMsg.To.Add(strTo)
                        If strCC <> "" Then
                            oMsg.CC.Add(strCC)                   'tiene CC
                        End If
                        oMsg.Subject = Replace(strSubject, "(0)", "")
                        oMsg.SubjectEncoding = System.Text.Encoding.UTF8

                        oMsg.IsBodyHtml = Me.mblnFormatoHtml  'Formato HTML, sin formato eliminar línea
                        If mstrArchivoAdjunto.Trim <> "" Then
                            'Creamos el archivo attachment para este correo electrónico.        
                            Dim item As Attachment
                            item = New Attachment(Me.mstrArchivoAdjunto)
                            item.TransferEncoding = Net.Mime.TransferEncoding.Base64

                            'para atachar files
                            oMsg.Attachments.Add(item)
                        End If
                        If Me.mblnFormatoHtml Then 'Se agrega etiquetas HTML, en este caso no debe venir de afuera esto
                            strBody = "<HTML><BODY>" & strBody & "</BODY></HTML>"
                        End If
                        oMsg.Body = strBody
                        oMsg.Priority = MailPriority.Normal 'podría ser una propiedad

                        Dim SmtpMail As New SmtpClient(Parametros.p_SERVIDORCORREOSMTP, 587)
                        SmtpMail.EnableSsl = True
                        SmtpMail.UseDefaultCredentials = False
                        SmtpMail.Credentials = New System.Net.NetworkCredential(DecryptINI$(Parametros.p_USUARIOCORREONET), DecryptINI$(Parametros.p_PASSUSUARIOCORREONET))

                        SmtpMail.Send(oMsg)

                        oMsg = Nothing

                        EnviarCorreo = True
                    Case "cl"
                        'strTo = "angel.barbaran@soleduc.cl"
                        oMsg.From = New MailAddress(strFrom)
                        oMsg.To.Add(strTo)                      'es colection, podrían ingresarse muchos
                        'oMsg.CC.Add                            'tiene CC
                        oMsg.Subject = Replace(strSubject, "(0)", "")
                        oMsg.SubjectEncoding = System.Text.Encoding.UTF8

                        oMsg.IsBodyHtml = Me.mblnFormatoHtml  'Formato HTML, sin formato eliminar línea
                        If mstrArchivoAdjunto.Trim <> "" Then
                            'Creamos el archivo attachment para este correo electrónico.        
                            Dim item As Attachment
                            item = New Attachment(Me.mstrArchivoAdjunto)
                            item.TransferEncoding = Net.Mime.TransferEncoding.Base64

                            'para atachar files
                            oMsg.Attachments.Add(item)
                        End If
                        If Me.mblnFormatoHtml Then 'Se agrega etiquetas HTML, en este caso no debe venir de afuera esto
                            strBody = "<HTML><BODY>" & strBody & "</BODY></HTML>"
                        End If
                        oMsg.Body = strBody
                        oMsg.Priority = MailPriority.Normal 'podría ser una propiedad

                        Dim SmtpMail As New SmtpClient
                        If strServerSmtp = "" Then
                            'obtiene el servidor desde el xml ini
                            strServerSmtp = mstrServidorSmtp
                        End If
                        SmtpMail.Host = strServerSmtp

                        'Si necesitara autenticación
                        'SmtpMail.Credentials = New System.Net.NetworkCredential("rmunoz", "Clave12345", "exadom.local")

                        SmtpMail.Send(oMsg)

                        oMsg = Nothing

                        EnviarCorreo = True
                End Select
            Catch ex As Exception
                EnviaError("CEnviarCorreo:EnviarCorreo-->" & ex.Message)
            End Try
        End Function


        'Public Sub EnviarCorreo(ByVal strFrom As String, ByVal strTo As String, _
        '                        ByVal strSubject As String, ByVal strBody As String, _
        '                        Optional ByVal strServerSmtp As String = "", _
        '                        Optional ByVal strCC As String = "")
        '    Dim oMsg As MailMessage = New MailMessage
        '    Try

        '        oMsg.From = New MailAddress(strFrom)
        '        oMsg.To.Add(strTo)                      'es colection, podrían ingresarse muchos
        '        If strCC <> "" Then
        '            oMsg.CC.Add(strCC)                   'tiene CC
        '        End If
        '        oMsg.Subject = strSubject
        '        oMsg.IsBodyHtml = Me.mblnFormatoHtml  'Formato HTML, sin formato eliminar línea
        '        If mstrArchivoAdjunto.Trim <> "" Then
        '            'Creamos el archivo attachment para este correo electrónico.        
        '            Dim item As Attachment
        '            item = New Attachment(Me.mstrArchivoAdjunto)
        '            item.TransferEncoding = Net.Mime.TransferEncoding.Base64

        '            'para atachar files
        '            oMsg.Attachments.Add(item)
        '        End If
        '        If Me.mblnFormatoHtml Then 'Se agrega etiquetas HTML, en este caso no debe venir de afuera esto
        '            strBody = "<HTML><BODY>" & strBody & "</BODY></HTML>"
        '        End If
        '        oMsg.Body = strBody
        '        oMsg.Priority = MailPriority.Normal 'podría ser una propiedad

        '        Dim SmtpMail As New SmtpClient
        '        If strServerSmtp = "" Then
        '            'obtiene el servidor desde el xml ini
        '            strServerSmtp = mstrServidorSmtp
        '        End If
        '        SmtpMail.Host = strServerSmtp

        '        'Si necesitara autenticación
        '        'SmtpMail.Credentials = New System.Net.NetworkCredential("rmunoz", "Clave12345", "exadom.local")

        '        SmtpMail.Send(oMsg)
        '        oMsg = Nothing

        '    Catch ex As Exception
        '        Console.Write(ex.Message)
        '    End Try
        'End Sub


        Public Sub New()
            'así no se consulta cada vez
            Me.mstrServidorSmtp = Parametros.p_SERVIDORCORREO
            Me.mblnFormatoHtml = False
            mstrArchivoAdjunto = ""
        End Sub
    End Class
End Namespace