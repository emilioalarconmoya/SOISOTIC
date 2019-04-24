Imports System.IO
Imports Modulos
'Permite la navegación en directorios/archivos
Public Class CArchivos
    'Elimina todos los archivos de un directorio especificado anteriores a la fecha
    Public Sub EliminarTodosFechaDir(ByVal strPath As String, ByVal dtmFechaTope As Date)
        Dim Archivo As String, dtmFechaFile As Date
        'Recorre todos los archivos del directorio
        Try
            For Each Archivo In System.IO.Directory.GetFiles(strPath) 'en archivo queda la ruta COMPLETA, incluyendo el dir
                'optiene la fecha de creación
                dtmFechaFile = System.IO.File.GetCreationTime(Archivo)
                'si fecha de creación es menor o igual a la fecha tope -> eliminar
                If dtmFechaFile.Date <= dtmFechaTope.Date Then
                    System.IO.File.Delete(Archivo) 'elimina
                End If
            Next
        Catch ex As Exception
            EnviaError("CArchivos:EliminarTodosFechaDir-> Posible problema en carpeta /TMP, asigna permiso a TODOS en Seguridad de carpeta. " & ex.Message)
        End Try
    End Sub

End Class
