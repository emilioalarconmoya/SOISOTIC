Imports System.Data
Imports Modulos
Imports Clases
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Public Class CCargaCurso
    Private mobjWS As New comunicacionotic.Service

    Private mlngRutEjecutivo As Long
    Private mlngRutCliente As Long
    Private mstrClaveAcceso As String
    Private mstrUrlCarga As String
    Private mstrResultado As String

    Public WriteOnly Property RutEjecutivo() As Long
        Set(ByVal value As Long)
            mlngRutEjecutivo = value
        End Set
    End Property
    Public WriteOnly Property RutCliente() As Long
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public WriteOnly Property ClaveAcceso() As String
        Set(ByVal value As String)
            mstrClaveAcceso = value
        End Set
    End Property
    Public WriteOnly Property UrlCarga() As String
        Set(ByVal value As String)
            mstrUrlCarga = value
        End Set
    End Property
    Public ReadOnly Property Resultado() As String
        Get
            Resultado = mstrResultado
        End Get
    End Property
    Public Function ValidarXML(ByVal strNombreXML As String) As Boolean
        Try
            Dim schemaSet As New XmlSchemaSet()
            schemaSet.Add([String].Empty, XmlReader.Create(New StreamReader(Parametros.p_DIRFISICO & "XML Schemas\esquema.xsd")))

            Dim settings As New XmlReaderSettings()
            settings.Schemas = schemaSet
            settings.ValidationType = ValidationType.Schema

            Dim strXML As String
            strXML = File.OpenText(strNombreXML).ReadToEnd

            Dim reader As XmlReader = XmlReader.Create(New StringReader(strXML), settings)

            While reader.Read()
            End While
            Return True

        Catch schemaEx As XmlSchemaException
            Return False
        Catch ex As Exception
            EnviaError("CCargaCurso:ValidarXML->" & ex.Message)
        End Try
    End Function
    Public Sub Cargar()
        Try
            Me.mstrResultado = mobjWS.ProcesarCurso(Me.mstrUrlCarga, RutLngAUsr(Me.mlngRutCliente) & "+" & Me.mstrClaveAcceso, RutLngAUsr(Me.mlngRutEjecutivo))

        Catch ex As Exception
            EnviaError("CCargaCurso:Cargar->" & ex.Message)
        End Try
    End Sub
End Class
