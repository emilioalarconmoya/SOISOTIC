Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Public Class CCertificadosAporte
    Implements IReporte

    'Rut Cliente
    Private mlngRut As Long
    'Razon Social
    Private mstrRazonSocial As String
    'año
    Private mintAgno As Integer
    Private mstrDigVerif As String
    Private mlngCorrelativo As Long
    Private mstrFono As String
    Private mstrEmail As String
    Private mstrNombreContacto As String
    Private mstrFonoContacto As String
    'objeto con consultas SQL
    Private mobjSql As CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean



    Public Property Rut() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
        End Set
    End Property
    Public Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return mstrRazonSocial
        End Get
        Set(ByVal value As String)
            mstrRazonSocial = value
        End Set
    End Property
    Public Property Fono() As String
        Get
            Return mstrFono
        End Get
        Set(ByVal value As String)
            mstrFono = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mstrEmail
        End Get
        Set(ByVal value As String)
            mstrEmail = value
        End Set
    End Property
    Public Property NombreContacto() As String
        Get
            Return mstrNombreContacto
        End Get
        Set(ByVal value As String)
            mstrNombreContacto = value
        End Set
    End Property
    Public Property FonoContacto() As String
        Get
            Return mstrFonoContacto
        End Get
        Set(ByVal value As String)
            mstrFonoContacto = value
        End Set
    End Property
    Public Property DigVerif() As String
        Get
            Return mstrDigVerif
        End Get
        Set(ByVal value As String)
            mstrDigVerif = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property

    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property
    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property
  

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim dtConsulta As DataTable
            Dim intFilas As Integer
            Dim strNombreArchivo As String
            mobjSql = New CSql


            dtConsulta = mobjSql.s_certificados_clientes(mlngRut, mstrRazonSocial, mintAgno)
            intFilas = mobjSql.Registros
            If intFilas > 0 Then
                Dim dr As DataRow

                For Each dr In dtConsulta.Rows
                    mlngCorrelativo = dr("Correlativo")
                    mlngRut = dr("rut")
                    mstrDigVerif = dr("dig_verif")
                    mstrRazonSocial = dr("razon_social")
                    mstrFono = dr("Fono")
                    mstrEmail = dr("Email")
                    mstrNombreContacto = dr("nom_contacto")
                    mstrFonoContacto = dr("fono_contacto")
                Next
           
            End If
         

            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtConsulta.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If


            Return dtConsulta
        Catch ex As Exception
            EnviaError("CCertificadosAporte: Consultar-->" & ex.Message)
        End Try

    End Function
    Private Sub Initialize()
        mlngRut = 0
        mstrRazonSocial = ""
        mintAgno = Now.Year() - 1
        mlngCorrelativo = 0
        mstrDigVerif = ""
        mstrFono = ""
        mstrEmail = ""
        mstrNombreContacto = ""
        mstrFonoContacto = ""
    End Sub

    'Generación de certificados de aporte. Retorna el número de certificados generados
    '
    Function GenerarCertificados() As Long
        Try
            Dim lngNroCertificado As Long
            'Dim intFilas As Integer
            Dim dtClientes As DataTable
            mobjSql = New CSql
            mobjSql.InicioTransaccion()
            mobjSql.d_certificado_aporte(mintAgno)
            'nro máximo de certificado
            lngNroCertificado = mobjSql.s_certificado_aporte_max_correl(mintAgno)
            'consulta de clientes con aportes y sin certificado generado, ordenada por razón social
            Dim lngRutCliente As Long
            dtClientes = mobjSql.s_clientes_con_aporte_2(mintAgno)
            mlngFilas = mobjSql.Registros
            If mlngFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dtClientes.Rows
                    lngNroCertificado = lngNroCertificado + 1
                    lngRutCliente = dr("rut_cliente") 'dtClientes.Rows(i)(0) '(0, i)

                    If (mobjSql.s_existe_Certificado(mintAgno, lngRutCliente) = False) Then
                        mobjSql.i_certificado_aporte(mintAgno, lngRutCliente, lngNroCertificado)
                    End If

                Next
            End If
            'For i = 0 To TamanoArreglo2(dtClientes) - 1

            'Next
            mobjSql.FinTransaccion()

            GenerarCertificados = mlngFilas  'total de certificados nuevos
            Exit Function
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CCertificadosAporte: Consultar-->" & ex.Message)
        End Try

        
       
    End Function

End Class
