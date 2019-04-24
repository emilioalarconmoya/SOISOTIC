Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorSupervisorEjecutivo
    Private mobjSql As New CSql
    Private mlngRutSupervisor As Long
    Private mstrNombreSupervisor As String
    Private mlngRutEjecutivo As Long
    Private mstrNombreEjecutivo As String
    Private mdtSupervisores As DataTable
    Private mdtEjecutivos As DataTable
    Private mdtEjecutivoAsignado As DataTable
    Private mdtEjecutivoNoAsignado As DataTable
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mdtTraspaso As DataTable
    Public Property Traspaso() As DataTable
        Get
            Return mdtTraspaso
        End Get
        Set(ByVal value As DataTable)
            mdtTraspaso = value
        End Set
    End Property

    Public Property EjecutivoAsignado() As DataTable
        Get
            Return mdtEjecutivoAsignado
        End Get
        Set(ByVal value As DataTable)
            mdtEjecutivoAsignado = value
        End Set
    End Property
    Public Property EjecutivoNoAsignado() As DataTable
        Get
            Return mdtEjecutivoNoAsignado
        End Get
        Set(ByVal value As DataTable)
            mdtEjecutivoNoAsignado = value
        End Set
    End Property
    Public Property RutSupervisor() As Long
        Get
            Return mlngRutSupervisor
        End Get
        Set(ByVal value As Long)
            mlngRutSupervisor = value
        End Set
    End Property
    Public Property RutEjecutivo() As Long
        Get
            Return mlngRutEjecutivo
        End Get
        Set(ByVal value As Long)
            mlngRutEjecutivo = value
        End Set
    End Property
    Public Property NombreSupervisor() As String
        Get
            Return mstrNombreSupervisor
        End Get
        Set(ByVal value As String)
            mstrNombreSupervisor = value
        End Set
    End Property
    Public Property NombreEjecutivo() As String
        Get
            Return mstrNombreEjecutivo
        End Get
        Set(ByVal value As String)
            mstrNombreEjecutivo = value
        End Set
    End Property
    Public ReadOnly Property LookUpSupervisores() As DataTable
        Get
            LookUpSupervisores = mdtSupervisores
        End Get
    End Property
    Public ReadOnly Property LookUpEjecutivos() As DataTable
        Get
            LookUpEjecutivos = mdtEjecutivos
        End Get
    End Property
    'Public Property Supervisores() As DataTable
    '    Get
    '        Return mdtSupervisores
    '    End Get
    '    Set(ByVal value As DataTable)
    '        mdtSupervisores = value
    '    End Set
    'End Property
    'Public Property Ejecutivos() As DataTable
    '    Get
    '        Return mdtEjecutivos
    '    End Get
    '    Set(ByVal value As DataTable)
    '        mdtEjecutivos = value
    '    End Set
    'End Property
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

    Public Function Consultar() As System.Data.DataTable

        Try
            Dim dt As DataTable
            Dim strNombreArchivo As String
            mobjSql = New CSql
            dt = mobjSql.s_SupervisorEjecutivos(mlngRutSupervisor, mstrNombreSupervisor, mlngRutEjecutivo, mstrNombreEjecutivo)
            mlngFilas = mobjSql.Registros
            Consultar = dt
            mobjSql = Nothing
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dt.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

        Catch ex As Exception
            EnviaError("CMantenedorSupervisorEjecutivo:Consultar->" & ex.Message)
        End Try
    End Function
    Public Function Actualizar() As Boolean
        Dim intCodAtrib As Integer
        Try
            mobjSql.InicioTransaccion()
            Dim dt As DataTable
            Dim row As DataRow
            Try
                mobjSql = New CSql
                mobjSql.InicioTransaccion()
                dt = mobjSql.s_supervisor(mlngRutSupervisor)
                If Not dt Is Nothing Then
                    mobjSql.d_supervisor_por_rut(mlngRutSupervisor)
                    For Each row In Me.mdtTraspaso.Rows
                        mobjSql.i_Supervisor(mlngRutSupervisor, row("rutEjecutivo"))
                    Next
                End If
                
                mobjSql.FinTransaccion()
                mobjSql = Nothing
                Return True
            Catch ex As Exception
                mobjSql.RollBackTransaccion()
                mobjSql = Nothing
                EnviaError("CMantenedorUsuario:Actualizar-->" & ex.Message)
            End Try
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorSupervisorEjecutivo:Actualizar->" & ex.Message)
        End Try
    End Function
    Public Function Insertar() As Boolean
        Dim intMaxCod As Integer
        Try
            mobjSql.InicioTransaccion()
            
            mobjSql.i_Supervisor(mlngRutSupervisor, mlngRutEjecutivo)
            'Mensaje = "Los datos fueron ingresados!"

            mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorSupervisorEjecutivo:Insertar->" & ex.Message)
        End Try
    End Function
    Public Function Eliminar() As Boolean
        'Dim strAtrCar As AtriCaracteristicas
        Try
            mobjSql.InicioTransaccion()
           
            mobjSql.d_Supervisor(mlngRutSupervisor, mlngRutEjecutivo)
            
            mobjSql.FinTransaccion()
            'Mensaje = "Los datos fueron Eliminados!"
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorSupervisorEjecutivo:Eliminar->" & ex.Message)
        End Try
    End Function

    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        Try

            mobjSql = objSql

            'lookupSupervisores
            mdtSupervisores = mobjSql.s_supervisores_todos

            'lookupEjecutivos
            mdtEjecutivoAsignado = mobjSql.s_ejecutivo_todos
        Catch ex As Exception
            EnviaError("CMantenedorSupervisorEjecutivo:Inicializar->" & ex.Message)
        End Try
        
    End Sub
    Public Sub Inicializar2(ByRef objSql As CSql)
        Try

            mobjSql = objSql

            'lookupSupervisores
            mdtSupervisores = mobjSql.s_supervisores_todos

            'lookupEjecutivos
            mdtEjecutivoAsignado = mobjSql.s_ejecutivos_asignados(mlngRutSupervisor)
            mdtEjecutivoNoAsignado = mobjSql.s_ejecutivos_no_asignados(mlngRutSupervisor)
        Catch ex As Exception
            EnviaError("CMantenedorSupervisorEjecutivo:Inicializar->" & ex.Message)
        End Try

    End Sub
    'Inicialización de variables internas del objeto y de los arreglos con lookups.
    Public Sub InitializarNuevo()
        Try
            mlngRutSupervisor = 0
            mstrNombreSupervisor = ""
            mlngRutEjecutivo = 0
            mstrNombreEjecutivo = ""
        Catch ex As Exception
            EnviaError("CMantenedorSupervisorEjecutivo:Initialize->" & ex.Message)
        End Try
    End Sub
    Private Sub Terminar()
        mdtSupervisores = New DataTable
        mdtEjecutivos = New DataTable
    End Sub



End Class
