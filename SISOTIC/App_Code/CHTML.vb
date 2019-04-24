Imports Microsoft.VisualBasic
Imports System.IO


Public Class CHTML
    Public Function GetHTML(ByVal strUrl As String) As String
        Dim WR As System.Net.WebRequest
        Dim Rsp As System.Net.WebResponse
        Try
            WR = System.Net.WebRequest.Create(strUrl)
            Rsp = WR.GetResponse()
            Return New StreamReader(Rsp.GetResponseStream()).ReadToEnd()
        Catch ex As System.Net.WebException
            Throw ex
        End Try
    End Function

End Class
