Imports Microsoft.VisualBasic
Imports System.Data
Namespace Clases
    'Interface para los reportes, todos deben implementarlo
    Public Interface IReporte
        Function Consultar() As DataTable            'Donde devolverá el datatable con el resultado
        ReadOnly Property Filas() As Integer         'Devolverá el total de registros  
        Property BajarXml() As Boolean               'Seteo a true previo a consultar y cargará XML en la propiedad 
        ReadOnly Property ArchivoXml() As String     'Ruta del archivo generado
    End Interface
End Namespace
