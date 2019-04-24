Imports system.Net
Imports System.IO
Imports Clases
Imports Modulos

'Esta clase genera un HTML de una direccion URL cualquiera
'La URL debe ser absoluta, del tipo http://host/... o http://www....
'Equivale a abrir un sitio con IE y guardar el HTML resultante
'Se pueden generar htmls de cualquier página: asp, aspx, php, etc...
Public Class CGeneraHTML
    Public mstrNombre As String
    Public Property NombreArchivo() As String
        Get
            NombreArchivo = mstrNombre
        End Get
        Set(ByVal value As String)
            mstrNombre = value
        End Set
    End Property

    Public Function Generar(ByVal strUrl As String) As String
        'Dim encode As Encoding
        Dim mywebReq As WebRequest
        Dim mywebResp As WebResponse
        Dim sr As StreamReader
        Dim strNombreArchivo, strHTML As String
        Dim sw As StreamWriter
        'Dim decode As Encoding
        Try
            mywebReq = WebRequest.Create(strUrl)
            mywebResp = mywebReq.GetResponse()
            sr = New StreamReader(mywebResp.GetResponseStream, System.Text.Encoding.Default, False)
            strHTML = sr.ReadToEnd

            mstrNombre = NombreArchivoTmp("html")

            strNombreArchivo = DIRFISICOAPP() & "contenido\tmp\" & mstrNombre

            Dim strDirVirtual = Parametros.p_DIRVIRTUALMAIL & "/contenido/tmp/" & mstrNombre


            'crea el archivo HTML, generado por la URL, se puede enviar en los correos por ej.
            sw = New StreamWriter(strNombreArchivo, False, System.Text.Encoding.UTF8)
            'sw = File.CreateText(strNombreArchivo)
            sw.WriteLine(strHTML)
            sw.Close()
            Return strDirVirtual
        Catch ex As Exception
            EnviaError("CGeneraHTML: Generar ->" & ex.Message)
        End Try
    End Function
End Class
