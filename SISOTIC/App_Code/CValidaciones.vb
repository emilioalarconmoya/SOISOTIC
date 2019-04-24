Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CValidaciones
    Private objSession As New CSession
    'consultas sql y objetos de conexion
    Private mblnBajarXml As Boolean
    Private mstrXml As String
    Private mlngFilas As Long
    'objeto de coneccion a bd y de implements ireporte
    Private mobjSql As CSql

    'collection con información que puede ser desplegada
    Private mcolInfo As Collection

    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean
        Get
            Return Me.mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXml = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer
        Get
            Return mlngFilas
        End Get
    End Property
    Public ReadOnly Property Info() As Collection
        Get
            Return mcolInfo
        End Get
    End Property
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub




    Public Function Consultar(ByVal Codigo As String, ByVal Tipo As String) As Boolean
        'If ActivarOnError Then
        '    On Error GoTo ConsultarErr
        'End If
        mcolInfo = Nothing
        mcolInfo = New Collection

        Consultar = False
        If Tipo = "Cliente" Then
            If Codigo <> "" Then
                If EsCliente(-1, Codigo) Then
                    Consultar = True
                End If
            End If
        End If

        'Ideal que se consulte por si es cliente 1ro.
        If Tipo = "Moroso" Then
            If Codigo <> "" Then
                If EsMoroso(RutUsrALng(Codigo), "") Then
                    Consultar = True
                End If
            End If
        End If

        'Ideal que se consulte por si es cliente 1ro.
        If Tipo = "ClienteBloqueado" Then
            If Codigo <> "" Then
                If ClienteBloqueado(Codigo) Then
                    Consultar = True
                End If
            End If
        End If

        If Tipo = "CursoSence" Then
            If EsCurso(Codigo) Then
                Consultar = True
            End If
        End If
        Exit Function
        Try

        Catch ex As Exception
            EnviaError("CFichaActividad->Consultar" & ex.Message)
        End Try
    End Function
    'Retorna true si el rut recibido pertenece a un cliente
    Public Function EsCliente(ByVal lngRut As Long, ByVal strRut As String) As Boolean
      

        Dim dtOtec As DataTable
        If lngRut = -1 Then lngRut = RutUsrALng(strRut)
        dtOtec = mobjSql.s_persona_juridica2(lngRut)
        If TamanoArreglo2(dtOtec) = 0 Then
            EsCliente = False
        Else
            EsCliente = True
        End If
        Exit Function

EsClienteErr:
        EnviaError("CValidaciones: EsCliente ")
    End Function

    Public Function EsOtec(ByVal strRut As String) As Boolean
       

        Dim dtOtes As DataTable
        dtOtes = mobjSql.s_Otec(RutUsrALng(strRut))
        If TamanoArreglo2(dtOtes) = 0 Then
            EsOtec = False
        Else
            EsOtec = True
        End If
        Exit Function

EsOtecErr:
        EnviaError("CValidaciones: EsOtec")

    End Function

    'Retorna true si el rut recibido pertenece a un cliente moroso
    Public Function EsMoroso(ByVal lngRut As Long, ByVal strRut As String) As Boolean
       
        Dim blnFlag As Boolean, i As Integer
        Dim objCuenta As New CCuenta
        Call objCuenta.inicializarCsql(mobjSql)

        blnFlag = False

        'De la cuenta 1 a la 5------------------------
        'No considera la cuenta Becas
        For i = 1 To 5
            objCuenta.ConsultarSaldoMorosidad = True
            Call objCuenta.Inicializar(lngRut, i, strRut)
            If objCuenta.SaldoMorosidad < 0 Then
                blnFlag = True
            End If
            'Este saldo no considera los aportes que no han sido cobrados (ch y docs a fecha)
            mcolInfo.Add("Saldo de cuenta " & NombreCuenta(i) & ": " & objCuenta.SaldoMorosidad)
        Next

        objCuenta = Nothing
        '---------------------------------------------

        EsMoroso = blnFlag

        Exit Function
EsMorosoErr:
        EnviaError("CValidaciones: EsMoroso ")
    End Function


    'Retorna true si el codigo sence recibido pertenece a un curso
    Public Function EsCurso(ByVal strCodSence As String) As Boolean
       
        Dim arrCurso As DataTable
        arrCurso = mobjSql.s_curso_1(strCodSence)
        If TamanoArreglo2(arrCurso) = 0 Then
            EsCurso = False
        Else
            EsCurso = True
        End If
        Exit Function

EsCursoErr:
        EnviaError("CValidaciones: EsCliente ")
    End Function

    'Retorna true si el cliente esta en estado bloqueado
    Public Function ClienteBloqueado(ByVal strRut As String) As Boolean
       

        Dim arrCliente
        arrCliente = mobjSql.s_estado_cliente(RutUsrALng(strRut))

        If TamanoArreglo2(arrCliente) = 0 Then
            'Cliente no existe
            ClienteBloqueado = True
        ElseIf arrCliente(0, 0) = 3 Then
            ClienteBloqueado = True
        Else
            ClienteBloqueado = False
        End If
        Exit Function

ClienteBloqueadoErr:
        EnviaError("CValidaciones: ClienteBloqueado ")
    End Function



    Public Sub New()
        mcolInfo = New Collection
    End Sub

End Class
