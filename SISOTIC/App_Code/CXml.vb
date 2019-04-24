Imports Modulos
Imports System.Data
Imports System.Xml
Imports System.Xml.Schema
Imports System.ComponentModel
Imports System.IO

Namespace Clases


    'Clase para manipular XML's
    Public Class CXml
        Private mdsDataSet As DataSet
        Private mintNivel As Integer

        'Lee un XML y lo transforma en un dataset
        'Cada nodo hijo que contenga nodos se transforma en un data table
        'Cada nodo de un nivel es un registro
        Public Sub LeerXml(ByVal strRuta As String)
            Try
                mdsDataSet = New DataSet
                mdsDataSet.ReadXml(strRuta)

            Catch Err As Exception
                EnviaError(Err.Message)
            End Try
        End Sub
        'Lee un nodo (Que tiene sub nodos con datos)
        Public Function LeerNodo(ByVal strNodo As String) As DataTable
            Try
                LeerNodo = mdsDataSet.Tables(strNodo)

            Catch Err As Exception
                EnviaError(Err.Message)
            End Try
        End Function
        'Lee un nodo terminal (Se indica el nodo padre y el terminal)
        'ej: 
        '<datos>                 <--- NODO PADRE    [DataTable]
        '  <nombre>Luis</nombre> <--- NODO TERMINAL [Column]
        '</datos>
        Public Function LeerNodoDato(ByVal strNodoPadre As String, _
                                     ByVal strNodoDato As String) As String
            Try
                LeerNodoDato = mdsDataSet.Tables(strNodoPadre).Rows(0)(strNodoDato)

            Catch Err As Exception
                LeerNodoDato = ""
                EnviaError(Err.Message)
            End Try
        End Function

        'Por ahora no aplica
        Public Property NivelNodo() As Integer
            Set(ByVal Value As Integer)
                If Value > 0 Then
                    mintNivel = Value
                End If
            End Set
            Get
                Return mintNivel
            End Get
        End Property

        Protected Overrides Sub Finalize()
            mdsDataSet.Dispose()
            mdsDataSet = Nothing
            MyBase.Finalize()
        End Sub
        Public Function ValidarXML(ByVal strNombreXML As String) As Boolean
            Try
                Dim strNombreSchema As String
                strNombreSchema = Replace(strNombreXML.ToUpper, ".XML", ".XSD")

                Dim schemaSet As New XmlSchemaSet()
                schemaSet.Add([String].Empty, XmlReader.Create(New StreamReader(Parametros.p_DIRFISICO & "\XML Schemas\" & strNombreSchema)))

                Dim settings As New XmlReaderSettings()
                settings.Schemas = schemaSet
                settings.ValidationType = ValidationType.Schema

                Dim strXML As String
                strXML = File.OpenText(Parametros.p_DIRFISICO & "\tmp\" & strNombreXML).ReadToEnd

                Dim reader As XmlReader = XmlReader.Create(New StringReader(strXML), settings)

                While reader.Read()
                End While

                ValidarXML = True


            Catch schemaEx As XmlSchemaException
                ValidarXML = False
            Catch Err As Exception
                EnviaError(Err.Message)
            End Try
        End Function
    End Class
End Namespace


