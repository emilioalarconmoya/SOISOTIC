Imports Microsoft.VisualBasic
Imports System.Data
Namespace Clases
    'Interface para los reportes, todos deben implementarlo
    Public Interface IReporte
        Function Consultar() As DataTable            'Donde devolver� el datatable con el resultado
        ReadOnly Property Filas() As Integer         'Devolver� el total de registros  
        Property BajarXml() As Boolean               'Seteo a true previo a consultar y cargar� XML en la propiedad 
        ReadOnly Property ArchivoXml() As String     'Ruta del archivo generado
    End Interface
End Namespace
