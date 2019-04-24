Imports System.Data
Imports System.Data.OleDb
Imports Modulos
Imports Clases
Imports System.Data.SqlClient

Namespace Clases

    Public Class CConexion_BD
        'Conector oledb genérico
        Private mstrProveedorOleDb As String
        'Motor de Base de Datos 
        Private mstrMotorBd As String

        Private mstrStringProveedorOleDb As String
        Private mstrHost As String
        Private mstrUser As String
        Private mstrPass As String
        Private mstrBD As String
        Private mstrCadenaOleDbConeccion As String

        'Para consultas select
        Private mlngRegistros As Long
        Private mlngRegistros2 As Long

        Private mdtDataTable As DataTable  'datatable resultante [Siempre será 1 (0)]

        'Para manejo de transacciones
        Private mintTransaccionesAbiertas As Integer
        Private mconConexion As New OleDbConnection 'Conector
        Private mtrnTransaccion As OleDbTransaction 'Manejador de trans
        Private mcomComandoSql As OleDbCommand = New OleDbCommand   'Comando sql
        Private mobjArchivoTxt As New CArchivoTxt 'para el modo debug
        Private mblnModoDebug As Boolean

        Public Property ProveedorOleDb() As String
            Get
                Return mstrProveedorOleDb
            End Get
            Set(ByVal Value As String)                
                mstrProveedorOleDb = Value
            End Set
        End Property
        Public Property MotorDb() As String
            Get
                Return mstrMotorBd
            End Get
            Set(ByVal Value As String)
                'sql, oracle, access2k, access2k, access2k2
                If Value.ToUpper <> "SQL" And Value.ToUpper <> "ORACLE" And Value.ToUpper <> "ACCESS97" And Value.ToUpper <> "ACCESS2K" And Value.ToUpper <> "ACCESS2K2" And Value.ToUpper <> "EXCEL8" Then
                    'error, botar sistema
                    EnviaError("No se ha asignado un proveedor OleDB válido, revise: sql, oracle o access.")
                Else
                    mstrMotorBd = Value
                End If
            End Set
        End Property
        Public WriteOnly Property Host() As String
            Set(ByVal Value As String)
                mstrHost = Value
            End Set
        End Property
        Public WriteOnly Property BD() As String
            Set(ByVal Value As String)
                mstrBD = Value
            End Set
        End Property
        Public WriteOnly Property Usuario() As String
            Set(ByVal Value As String)
                mstrUser = Value
            End Set
        End Property
        Public WriteOnly Property Clave() As String
            Set(ByVal Value As String)
                mstrPass = Value
            End Set
        End Property

        Public ReadOnly Property Registros() As Long
            Get
                Return mlngRegistros
            End Get
        End Property
        Public ReadOnly Property Registros2() As Long
            Get
                Return mlngRegistros2
            End Get
        End Property
        Public WriteOnly Property TransaccionesAbiertas() As Integer
            Set(ByVal Value As Integer)
                mintTransaccionesAbiertas = Value
            End Set
        End Property
        Public ReadOnly Property dsDataTable() As DataTable
            Get
                Return mdtDataTable 'Devuelve el dtTable de la consulta
            End Get
        End Property
        'Abierto=True
        Private ReadOnly Property ConexionAbierta() As Boolean
            Get
                Return mconConexion.State = ConnectionState.Open
            End Get
        End Property
        'Cerrado=True
        Private ReadOnly Property ConexionCerrada() As Boolean
            Get
                Return mconConexion.State = ConnectionState.Closed
            End Get
        End Property
        'Abre conexión
        Public Sub Abrir()
            Try
                Call Cerrar() 'Cierra para abrir

                mstrCadenaOleDbConeccion = CadenaConeccion( _
                                            mstrProveedorOleDb, _
                                            mstrHost, mstrBD, _
                                            mstrUser, mstrPass, _
                                            mstrMotorBd)

                mconConexion = New OleDbConnection(mstrCadenaOleDbConeccion)
                mconConexion.Open()

                'Se enlaza el objeto de comando con la conexión
                'Queda listo para recibir comandos sql's
                mcomComandoSql.Connection = mconConexion
            Catch Err As Exception
                EnviaError("CConexion_BD:Abrir -> Error en la cadena de conexión: user, pass, o bd /" & Err.Message)
            End Try
        End Sub

        'Cierra conexión
        Public Sub Cerrar()
            Try
                If mconConexion.State = ConnectionState.Open Then
                    mconConexion.Close()
                End If
            Catch Err As Exception
                Console.Write(Err.ToString)
            End Try
        End Sub
        'Sólo lo ven las clases que heredan (Protected
        Protected Sub BeginTransaction()
            Try
                'Se inicia la transacción en la conexión
                If mintTransaccionesAbiertas = 0 Then
                    mtrnTransaccion = mconConexion.BeginTransaction
                    mcomComandoSql.Transaction = mtrnTransaccion
                End If
                mintTransaccionesAbiertas = mintTransaccionesAbiertas + 1
            Catch Err As Exception
                EnviaError(Err.Message)
            End Try
        End Sub
        Protected Sub CommitTransaction()
            Try
                mtrnTransaccion.Commit()
                If mintTransaccionesAbiertas > 0 Then
                    mintTransaccionesAbiertas = mintTransaccionesAbiertas - 1
                End If
            Catch Err As Exception
                EnviaError(Err.Message)
            End Try
        End Sub
        Protected Sub RollBack()
            Try
                mtrnTransaccion.Rollback()
                If mintTransaccionesAbiertas > 0 Then
                    mintTransaccionesAbiertas = mintTransaccionesAbiertas - 1
                End If
            Catch Err As Exception
                EnviaError(Err.Message)
            End Try
        End Sub

        'Devuelve el número de registros devueltos y carga el datatable en la propiedad
        Protected Function ConsultaSql(ByVal strSql As String, _
                        Optional ByVal strConn As String = "") As DataTable
            Try
                Dim daAdaptador As New OleDbDataAdapter
                Dim blnAbrirCerrar As Boolean
                blnAbrirCerrar = False

                mstrCadenaOleDbConeccion = CadenaConeccion( _
                        mstrProveedorOleDb, _
                        mstrHost, mstrBD, _
                        mstrUser, mstrPass, mstrMotorBd)

                If Not Me.ConexionAbierta Then
                    'Abrir, si la conexión estuviera abierta, no viene de una transacción
                    'sólo viene una instrucción, al final se debe cerrar
                    Me.Abrir()
                    blnAbrirCerrar = True
                End If

                'Usa la conexión
                daAdaptador = New OleDbDataAdapter()
                mcomComandoSql.CommandText = strSql
                daAdaptador.SelectCommand = mcomComandoSql

                'carga el datatable (plano)
                mdtDataTable = New DataTable
                If mblnModoDebug Then
                    'Llena log
                    mobjArchivoTxt.AgregarLinea("1. " & Now.ToString & "~" & strSql)
                End If

                daAdaptador.Fill(mdtDataTable)

                If mblnModoDebug Then
                    'Llena log2
                    mobjArchivoTxt.AgregarLinea("2. " & Now.ToString & "~" & strSql)
                End If

                daAdaptador = Nothing

                If blnAbrirCerrar Then
                    'Cierra la conexión
                    Me.Cerrar()
                End If

                'Duevuelve el total de registros y el recordset
                If Not (mdtDataTable Is Nothing) Then
                    mdtDataTable.TableName = "Reporte"
                    mlngRegistros = mdtDataTable.Rows.Count
                Else
                    mlngRegistros = 0
                End If

                'If mlngRegistros <= 0 Then
                '    ConsultaSql = Nothing
                'Else
                ConsultaSql = mdtDataTable
                'End If
            Catch Err As Exception
                EnviaError("CConexion_BD:ConsultaSql->" & Err.Message & "/" & strSql & " - Cadena: " & mstrCadenaOleDbConeccion)
                ConsultaSql = Nothing
            End Try
        End Function

        'Devuelve true si conectó
        'Se debe abrir transacción si corresponde
        Protected Function EjecutarSql(ByVal strSql As String) As Boolean
            Try
                Dim blnAbrirCerrar As Boolean
                blnAbrirCerrar = False

                If Not Me.ConexionAbierta Then
                    'Abrir, si la conexión estuviera abierta, no viene de una transacción
                    'sólo viene una instrucción, al final se debe cerrar
                    Me.Abrir()
                    blnAbrirCerrar = True
                End If

                'ejecuta el sql
                mcomComandoSql.CommandText = strSql

                If mblnModoDebug Then
                    'Llena log (Archivo logs/lqs.txt)
                    mobjArchivoTxt.AgregarLinea("1. " & Now.ToString & "~" & strSql)
                End If

                mcomComandoSql.ExecuteNonQuery()

                If mblnModoDebug Then
                    'Llena log2
                    mobjArchivoTxt.AgregarLinea("2. " & Now.ToString & "~" & strSql)
                End If

                If blnAbrirCerrar Then
                    'Cierra la conexión
                    Me.Cerrar()
                End If
            Catch Err As Exception
                EnviaError("CConexion_BD:EjecutarSql->" & Err.Message & "/" & strSql)
            End Try
        End Function
        'Devuelve true si conectó
        'Se debe abrir transacción si corresponde
        Protected Function EjecutarCargaSqlBulkCopy(ByVal tabla As DataTable, ByVal strNombreTabla As String, _
                                                    ByVal PoseeIdentidad As Boolean) As Boolean
            Try
                Dim blnAbrirCerrar As Boolean
                blnAbrirCerrar = False

                If Not Me.ConexionAbierta Then
                    Me.Abrir()
                    blnAbrirCerrar = True
                End If
                If PoseeIdentidad Then
                    mcomComandoSql.CommandText = "SET IDENTITY_INSERT " & strNombreTabla & " ON"
                    mcomComandoSql.ExecuteNonQuery()
                End If

                Dim strCadena As String = _
                "Persist Security Info=False;User=" & Parametros.p_USER & _
                " ;Password=" & Parametros.p_PASS & _
                ";Initial Catalog=" & Parametros.p_BD & _
                ";Data Source=" & Parametros.p_HOST
                Dim copia As New SqlBulkCopy(strCadena, SqlBulkCopyOptions.KeepIdentity)
                copia.DestinationTableName = strNombreTabla
                copia.WriteToServer(tabla)
                copia.Close()
                If PoseeIdentidad Then
                    mcomComandoSql.CommandText = "SET IDENTITY_INSERT " & strNombreTabla & " off"
                    mcomComandoSql.ExecuteNonQuery()
                End If
                If blnAbrirCerrar Then
                    Me.Cerrar()
                End If
            Catch Err As Exception
                EnviaError("CConexion_BD:EjecutarCargaSqlBulkCopy->" & Err.Message)
            End Try
        End Function
        Public Sub New()
            mintTransaccionesAbiertas = 0
            'Por default carga el string de conexión de la BD del proyecto
            'Puede ser abierto cualquier conexión, indicando la BD que se desea abrir

            Dim sParam As sParam
            sParam = Parametros()

            mstrProveedorOleDb = sParam.p_TIPOCONEXION
            mstrMotorBd = sParam.p_TIPOBD
            mstrHost = sParam.p_HOST
            mstrBD = sParam.p_BD
            mstrUser = sParam.p_USER
            mstrPass = sParam.p_PASS
            mblnModoDebug = IIf(sParam.p_MODODEBUG.Trim = "1", True, False)
            mobjArchivoTxt.Ruta = DIRFISICOAPP() & "logs\lqs.txt" 'ruta para log de sql

            'objWeb = Nothing
            sParam = Nothing
        End Sub
        'Arma la cadena de conección OLEDB
        Protected Function CadenaConeccion(ByVal strProveedorOleDb As String, _
                                         ByVal strHost As String, _
                                         ByVal strBd As String, _
                                         ByVal strUser As String, _
                                         ByVal strPass As String, _
                                         ByVal strMotorBd As String)
            Try

                Dim strTemp As String
                Select Case strMotorBd.ToUpper
                    Case "SQL"
                        Select Case strProveedorOleDb.ToUpper
                            Case "OLEDB"
                                mstrStringProveedorOleDb = "sqloledb"
                                strTemp = "Provider=" & mstrStringProveedorOleDb & ";" _
                                        & "SERVER=" & strHost & ";" _
                                        & "UID=" & strUser & ";" _
                                        & "PWD=" & strPass & ";" _
                                        & "DATABASE=" & strBd
                        End Select
                    Case "ORACLE"
                        Select Case strProveedorOleDb.ToUpper
                            Case "OLEDB"
                                'msdaora: es para usar la conex via framework
                                'OraOLEDB.Oracle: es para usar la conex vía cliente oracle
                                mstrStringProveedorOleDb = "MSDAORA" 'vía framework
                                strTemp = "Provider=" & mstrStringProveedorOleDb & ";" _
                                        & "Data Source=" & mstrBD & ";" _
                                        & "User Id=" & strUser & ";" _
                                        & "Password=" & strPass
                            Case "CLIENTE"
                                'msdaora: es para usar la conex via framework
                                'OraOLEDB.Oracle: es para usar la conex vía cliente oracle
                                mstrStringProveedorOleDb = "OraOLEDB.Oracle" 'vía framework
                                strTemp = "Provider=" & mstrStringProveedorOleDb & ";" _
                                        & "Data Source=" & mstrBD & ";" _
                                        & "User Id=" & strUser & ";" _
                                        & "Password=" & strPass
                        End Select
                    Case "ACCESS97"
                        Select Case strProveedorOleDb.ToUpper
                            Case "OLEDB"
                                mstrStringProveedorOleDb = "Microsoft.Jet.OLEDB.3.51"
                                strTemp = "Provider=" & mstrStringProveedorOleDb & ";" _
                                        & "Data Source=" & mstrBD & ";" _
                                        & "User Id=" & strUser & ";" _
                                        & "Password=" & strPass
                        End Select
                    Case "ACCESS2K"
                        Select Case strProveedorOleDb.ToUpper
                            Case "OLEDB"
                                mstrStringProveedorOleDb = "Microsoft.Jet.OLEDB.4.0"
                                strTemp = "Provider=" & mstrStringProveedorOleDb & ";" _
                                        & "Data Source=" & mstrBD & ";" _
                                        & "User Id=" & strUser & ";" _
                                        & "Password=" & strPass
                        End Select
                    Case "ACCESS2K2"
                        Select Case strProveedorOleDb.ToUpper
                            Case "OLEDB"
                                mstrStringProveedorOleDb = "Microsoft.Jet.OLEDB.5.0"
                                strTemp = "Provider=" & mstrStringProveedorOleDb & ";" _
                                        & "Data Source=" & mstrBD & ";" _
                                        & "User Id=" & strUser & ";" _
                                        & "Password=" & strPass
                        End Select
                    Case "EXCEL8"
                        mstrStringProveedorOleDb = "Microsoft.Jet.OLEDB.4.0"
                        strTemp = "Provider=" & mstrStringProveedorOleDb & ";" _
                                & "Data Source=" & mstrBD & ";" _
                                & "Extended Properties=Excel 8.0;"
                    Case Else
                        EnviaError("No se ha seleccionado proveedor válido")
                End Select




                CadenaConeccion = strTemp

            Catch ex As Exception

            End Try
        End Function
        Protected Overrides Sub Finalize()
            'Libera(recursos)
            'If Not mconConexion Is Nothing Then
            '    mconConexion.Dispose()
            'End If
            If Not mcomComandoSql Is Nothing Then
                mcomComandoSql.Dispose()
            End If
            If Not dsDataTable Is Nothing Then
                dsDataTable.Dispose()
            End If

            mconConexion = Nothing
            mcomComandoSql = Nothing
            mdtDataTable = Nothing
            mtrnTransaccion = Nothing

            MyBase.Finalize()
        End Sub
    End Class
End Namespace
