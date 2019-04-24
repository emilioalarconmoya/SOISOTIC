Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System
Imports System.IO
Imports System.IO.Compression
Imports ICSharpCode.SharpZipLib.Checksums
Imports ICSharpCode.SharpZipLib.Zip
Public Class CZip
    '"BIN", dicha libreria compilada o en código abierto se puede conseguir en:
    'http://www.icsharpcode.net/OpenSource/SharpZipLib/Default.aspx
    Public Sub Descomprimir(ByVal strArchivoZip As String, ByVal strDirDestino As String)
        Try
            Dim fZip As New FastZip
            'Descromprime y sobreescribe los archivos
            fZip.ExtractZip(strArchivoZip, strDirDestino, "")
            fZip = Nothing

        Catch ex As Exception
            Call EnviaError("CZip:Descomprimir->" & ex.Message)
        End Try
    End Sub
    Public Sub Comprimir(ByVal NombreCarpeta As String) 'ByVal strDirDestinoZip As String, ByVal strArchivoZip As String)
        Dim fZip As New FastZip
        'Descromprime y sobreescribe los archivos

        Dim recurse As Boolean = True
        ' Include all files by recursing through the directory structure
        Dim filter As String = Nothing
        ' Dont filter any files at all
        fZip.CreateZip(DIRFISICOAPP() & "\contenido\csv\" & NombreCarpeta & ".zip", DIRFISICOAPP() & "\contenido\csv\" & NombreCarpeta, recurse, filter)

        fZip = Nothing

    End Sub
End Class
