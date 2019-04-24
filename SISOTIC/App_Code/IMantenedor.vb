Imports System.Data
Namespace Clases
    'Interface para los reportes, todos deben implementarlo
    Public Interface IMantenedor
        'Devolver� el total de registros de la consulta
        ReadOnly Property Filas() As Integer
        'Collection con los id's a eliminar seg�n mantenedor
        'Se deben agregar separados por ; si son m�s de un id
        'Es para eliminaci�n masiva, ejemplo enviar un collection de rut's a eliminar
        Property colEliminacion() As System.Collections.ArrayList
        'Devolver� el datatable con el resultado, s�lo para navegaci�n

        Function Consultar() As DataTable
        'Inicializa el objeto para inserci�n
        Sub InicializarNuevo()
        'Update de lo que est� cargado en el objeto
        Function Actualizar() As Boolean
        'Insert de lo que est� cargado en el objeto
        Function Insertar() As Boolean
        'Delete de los c�digos en el arraylist
        Function Eliminar() As Boolean
    End Interface
End Namespace
