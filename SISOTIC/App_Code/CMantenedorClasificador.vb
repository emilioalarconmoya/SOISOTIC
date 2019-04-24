Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CMantenedorClasificador
    Private mobjSql As CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    'Arreglo con los datos del mantenedor
    Private mdtDatos As DataTable
    'Rut de la empresa cliente
    Private mlngRutEmpresa As Long
    'String contenido en los nombres del clasificador
    Private mstrNombre As String
    'Código del clasificador
    Private mstrCodClasificador As String
    'Nombre de la empresa cliente
    Private mstrNombreEmpresa As String
    'Arreglo con las empresas del sistema. Se utiliza para el lookup de perfiles
    Private mdtEmpresasCliente As DataTable
    Private mdblExito As Boolean
    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property
    Public Property BajarXml() As Boolean
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property
    Public ReadOnly Property Filas() As Long
        Get
            Return mlngFilas
        End Get
    End Property
    Public Property Exito() As Boolean
        Get
            Return mdblExito
        End Get
        Set(ByVal value As Boolean)
            mdblExito = value
        End Set
    End Property
    Public Property Datos() As DataTable
        Get
            Return mdtDatos
        End Get
        Set(ByVal value As DataTable)
            mdtDatos = value
        End Set
    End Property
    Public Property RutEmpresa() As Long
        Get
            Return mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return mstrNombre
        End Get
        Set(ByVal value As String)
            mstrNombre = value
        End Set
    End Property
    Public Property CodClasificador() As String
        Get
            Return mstrCodClasificador
        End Get
        Set(ByVal value As String)
            mstrCodClasificador = value
        End Set
    End Property
    Public Property NombreEmpresa() As String
        Get
            Return mstrNombreEmpresa
        End Get
        Set(ByVal value As String)
            mstrNombreEmpresa = value
        End Set
    End Property
    Public ReadOnly Property LookUpEmpresasCliente() As DataTable
        Get
            LookUpEmpresasCliente = mdtEmpresasCliente
        End Get
    End Property
    Public Function Consultar()
        Try
            Dim dt As DataTable
            Dim strNombreArchivo As String
            mobjSql = New CSql
            dt = mobjSql.s_clasificador_todos(mstrCodClasificador, mlngRutEmpresa, mstrNombre)
            mlngFilas = mobjSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    mstrCodClasificador = dr("cod_clasificador")
                    mlngRutEmpresa = dr("rut")
                    mstrNombre = dr("Nombre")
                    mstrNombreEmpresa = dr("razon_social")
                Next
            End If
            Consultar = dt
            mobjSql = Nothing
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dt.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

        Catch ex As Exception
            EnviaError("CMantenedorClasificador:Consultar->" & ex.Message)

        End Try
    End Function
    Public Function Eliminar() As Boolean
        Dim respuesta As Boolean
        Try
            mobjSql = New CSql
            mobjSql.InicioTransaccion()
            mobjSql.d_clasificador(mstrCodClasificador, mlngRutEmpresa)
            respuesta = True
            mdblExito = respuesta
            mobjSql.FinTransaccion()
            mobjSql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            mobjSql = Nothing
            EnviaError("CMantenedorClasificador.vb:Eliminar-->" & ex.Message)
        End Try

    End Function
    Public Function Actualizar() As Boolean
        Dim respuesta As Boolean
        Try
            mobjSql = New CSql
            mobjSql.InicioTransaccion()
            mobjSql.u_clasificador(mstrCodClasificador, mstrNombre, mlngRutEmpresa)
            respuesta = True
            mdblExito = respuesta
            mobjSql.FinTransaccion()
            mobjSql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            mobjSql = Nothing
            EnviaError("CMantenedorClasificador.vb:Eliminar-->" & ex.Message)
        End Try

    End Function
    Public Function Insertar() As Boolean
        Dim respuesta As Boolean
        Try
            mobjSql = New CSql
            mobjSql.InicioTransaccion()
            mobjSql.i_clasificador(mstrCodClasificador, mstrNombre, mlngRutEmpresa)
            respuesta = True
            mdblExito = respuesta
            mobjSql.FinTransaccion()
            mobjSql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            mobjSql = Nothing
            EnviaError("CMantenedorClasificador.vb:Eliminar-->" & ex.Message)
        End Try

    End Function
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql

        'lookEmpresas
        mdtEmpresasCliente = mobjSql.s_empresa_cliente_todas

    End Sub
End Class
