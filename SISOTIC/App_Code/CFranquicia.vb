Imports Clases
Imports Modulos
Imports System.Data
Imports Microsoft.VisualBasic

Public Class CFranquicia
    'Rut Cliente
    Private mlngRut As Long
    Private mintAgno As Integer
    Private mlngValor As Long
    'arreglo con los datos de franquicia
    Private mdtDatos As DataTable
    Private mdtErrores As DataTable
    Private mblnHayError As Boolean
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean

    'objeto con consultas SQL
    Private mobjSql As CSql

    'Rut del cliente
    Public Property Rut() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
        End Set
    End Property
    Public Property Valor() As Long
        Get
            Return mlngValor
        End Get
        Set(ByVal value As Long)
            mlngValor = value
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
    Public Property Datos() As DataTable
        Get
            Return mdtDatos
        End Get
        Set(ByVal value As DataTable)
            mdtDatos = value
        End Set
    End Property
    Public Property Errores() As DataTable
        Get
            Return mdtErrores
        End Get
        Set(ByVal value As DataTable)
            mdtErrores = value
        End Set
    End Property
    Public Property HayError() As Boolean
        Get
            Return mblnHayError
        End Get
        Set(ByVal value As Boolean)
            mblnHayError = value
        End Set
    End Property
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

    ' Consultar los datos del mantenedor
    Public Function Consultar() As DataTable
        Try
            Dim dt As DataTable
            Dim strNombreArchivo As String
            mobjSql = New CSql
            dt = mobjSql.s_franquicia(mlngRut)
            mlngFilas = mobjSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    mlngValor = dr("valor")
                    mintAgno = dr("año")
                Next
            End If
            ' CargarMantenedor = mdtDatos
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dt.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If
            Return dt
        Catch ex As Exception
            EnviaError("CFranquicia: CargarMantenedor-->" & ex.Message)
        End Try

    End Function
    Public Function Consultar2() As DataTable
        Try
            Dim dt As DataTable
            Dim strNombreArchivo As String
            mobjSql = New CSql
            dt = mobjSql.s_franquicia2(mlngRut, mintAgno)
            mlngFilas = mobjSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    mlngValor = dr("valor")
                    mintAgno = dr("agno")
                Next
            End If
            ' CargarMantenedor = mdtDatos
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dt.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If
            Return dt
        Catch ex As Exception
            EnviaError("CFranquicia: CargarMantenedor-->" & ex.Message)
        End Try

    End Function
    ' Consulta la Existencia de un registro en la base de datos
    Public Function ExisteFranquicia(ByVal lngRut As Long, _
                                     ByVal intAgno As Integer) As Boolean
        Try
            If mobjSql.Existe_Franquicia(lngRut, intAgno) = True Then
                ExisteFranquicia = True
            Else
                ExisteFranquicia = False
            End If
        Catch ex As Exception
            EnviaError("CFranquicia: ExisteFranquicia-->" & ex.Message)
        End Try

    End Function

    Public Function Actualizar() As Boolean
        Dim respuesta As Boolean
        Try
            mobjSql = New CSql
            mobjSql.InicioTransaccion()
            mobjSql.u_franquicia(mlngRut, mintAgno, mlngValor)
            respuesta = True
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
            mobjSql.i_franquicia(mlngRut, mintAgno, mlngValor)
            respuesta = True
            mobjSql.FinTransaccion()
            mobjSql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            mobjSql = Nothing
            EnviaError("CMantenedorClasificador.vb:Eliminar-->" & ex.Message)
        End Try

    End Function
    Public Function Eliminar() As Boolean
        Dim respuesta As Boolean
        Try
            mobjSql = New CSql
            mobjSql.InicioTransaccion()
            mobjSql.d_franquicia(mlngRut, mintAgno)
            respuesta = True
            mobjSql.FinTransaccion()
            mobjSql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            mobjSql = Nothing
            EnviaError("CMantenedorClasificador.vb:Eliminar-->" & ex.Message)
        End Try

    End Function
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub
End Class
    'Public Sub ActualizarMantenedor(ByVal Datos As DataTable, ByVal cambios As DataTable, ByVal intLargo As Integer)
    '    Try
    '        Dim i As Integer
    '        mblnHayError = False
    '        For i = 0 To intLargo - 1
    '            'If cambios(i) = 0 Then      ' No cambia el registro
    '            'nada
    '            'ElseIf cambios(i) = 1 Then  ' Cambiar registro
    '            If mobjSql.Existe_Franquicia(mlngRut, Datos.Rows(i)(0)) Then '(0, i)
    '                Call mobjSql.u_franquicia(mlngRut, Datos.Rows(i)(0), Datos.Rows(i)(0))
    '                'End If
    '                'ElseIf cambios(i) = 2 Then  ' Borrar registro
    '                If mobjSql.Existe_Franquicia(mlngRut, Datos.Rows(i)(0)) Then
    '                    Call mobjSql.d_franquicia(mlngRut, Datos.Rows(i)(0))
    '                End If
    '                'ElseIf cambios(i) = 3 Then  ' Agregar nuevo registro
    '                If Not mobjSql.Existe_Franquicia(mlngRut, Datos.Rows(i)(0)) Then
    '                    Call mobjSql.i_franquicia(mlngRut, Datos.Rows(i)(0), Datos.Rows(i)(0))
    '                End If
    '            End If

    '        Next

    '    Catch ex As Exception
    '        EnviaError("CFranquicia: ActualizarMantenedor-->" & ex.Message)
    '    End Try


    'End Sub


    'inicialización del objeto
   
