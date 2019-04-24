Imports System.Data
Namespace Clases
    'Interface para los reportes, todos deben implementarlo
    Public Interface IMantenedor
        'Devolverá el total de registros de la consulta
        ReadOnly Property Filas() As Integer
        'Collection con los id's a eliminar según mantenedor
        'Se deben agregar separados por ; si son más de un id
        'Es para eliminación masiva, ejemplo enviar un collection de rut's a eliminar
        Property colEliminacion() As System.Collections.ArrayList
        'Devolverá el datatable con el resultado, sólo para navegación

        Function Consultar() As DataTable
        'Inicializa el objeto para inserción
        Sub InicializarNuevo()
        'Update de lo que está cargado en el objeto
        Function Actualizar() As Boolean
        'Insert de lo que está cargado en el objeto
        Function Insertar() As Boolean
        'Delete de los códigos en el arraylist
        Function Eliminar() As Boolean
    End Interface
End Namespace
