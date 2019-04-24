Imports System.IO
Imports System
Imports Clases
Imports Modulos
Public Class CArchivoTxt
    Private mstrRuta As String
    Private mstrModo As FileMode

    Public Property Ruta() As String
        Get
            Ruta = mstrRuta
        End Get
        Set(ByVal value As String)
            mstrRuta = value
        End Set
    End Property
    Public ReadOnly Property Modo() As FileMode
        Get
            Modo = FileMode.Create
        End Get
    End Property

    Public Sub AgregarLinea(ByVal strLinea As String)
        Dim objStreamWriter As StreamWriter
        If Not System.IO.File.Exists(mstrRuta) Then
            'sino existe, lo crea
            objStreamWriter = New System.IO.StreamWriter(mstrRuta)
            objStreamWriter.Close()
        End If

        objStreamWriter = File.AppendText(mstrRuta)
        objStreamWriter.WriteLine(strLinea)
        objStreamWriter.Close()
        objStreamWriter = Nothing
    End Sub

End Class
