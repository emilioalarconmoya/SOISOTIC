Imports Clases
Imports Modulos
Imports System.Data

Public Class CClienteAportes
    Private mes()
    'objeto de consulta
    Private mobjSql As CSql
    'nro de certificado
    Private mlngNroCertificado As Long
    'aportes por mes
    Private mdtMeses As DataTable

    'monto por mes
    Private mlngMontoEnero As Long
    Private mlngMontoFebrero As Long
    Private mlngMontoMarzo As Long
    Private mlngMontoAbril As Long
    Private mlngMontoMayo As Long
    Private mlngMontoJunio As Long
    Private mlngMontoJulio As Long
    Private mlngMontoAgosto As Long
    Private mlngMontoSeptiembre As Long
    Private mlngMontoOctubre As Long
    Private mlngMontoNoviembre As Long
    Private mlngMontoDiciembre As Long

    'nro del certificado. Devuelve CERO si no hay nro. certificado asociado
    Public ReadOnly Property NroCertificado() As Long
        Get
            Return mlngNroCertificado
        End Get
    End Property
    'lista con aportes
    Public ReadOnly Property Aportes() As DataTable
        Get
            Return mdtMeses
        End Get
    End Property
    Public ReadOnly Property MontoEnero() As Long
        Get
            Return mlngMontoEnero
        End Get
    End Property
    Public ReadOnly Property MontoFebrero() As Long
        Get
            Return mlngMontoFebrero
        End Get
    End Property
    Public ReadOnly Property MontoMarzo() As Long
        Get
            Return mlngMontoMarzo
        End Get
    End Property
    Public ReadOnly Property MontoAbril() As Long
        Get
            Return mlngMontoAbril
        End Get
    End Property
    Public ReadOnly Property MontoMayo() As Long
        Get
            Return mlngMontoMayo
        End Get
    End Property
    Public ReadOnly Property MontoJunio() As Long
        Get
            Return mlngMontoJunio
        End Get
    End Property
    Public ReadOnly Property MontoJulio() As Long
        Get
            Return mlngMontoJulio
        End Get
    End Property
    Public ReadOnly Property MontoAgosto() As Long
        Get
            Return mlngMontoAgosto
        End Get
    End Property
    Public ReadOnly Property MontoSeptiembre() As Long
        Get
            Return mlngMontoSeptiembre
        End Get
    End Property
    Public ReadOnly Property MontoOctubre() As Long
        Get
            Return mlngMontoOctubre
        End Get
    End Property
    Public ReadOnly Property MontoNoviembre() As Long
        Get
            Return mlngMontoNoviembre
        End Get
    End Property
    Public ReadOnly Property MontoDiciembre() As Long
        Get
            Return mlngMontoDiciembre
        End Get
    End Property
    'total de aportes
    Public ReadOnly Property Total() As Long
        Get
            Return mlngTotal
        End Get
    End Property


    'monto total de aportes
    Private mlngTotal As Long

    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
        Dim mes(11)
        mes(0) = "Enero"
        mes(1) = "Febrero"
        mes(2) = "Marzo"
        mes(3) = "Abril"
        mes(4) = "Mayo"
        mes(5) = "Junio"
        mes(6) = "Julio"
        mes(7) = "Agosto"
        mes(8) = "Septiembre"
        mes(9) = "Octubre"
        mes(10) = "Noviembre"
        mes(11) = "Diciembre"

    End Sub

    Public Sub Consultar(ByVal intagno As Integer, ByVal lngRutCliente As Long)
        Try
            Dim i As Integer, intMes As Integer, intNroAportes As Integer

            Dim dtAportes As DataTable
            mobjSql = New CSql
            dtAportes = mobjSql.s_certificado_aportes(intagno, lngRutCliente)
            Dim objAportes As Object
            mdtMeses = New DataTable
            mdtMeses.Columns.Add("Mes")
            mdtMeses.Columns.Add("Aportes")
            Dim drMeses As DataRow

            intNroAportes = mobjSql.Registros
            'asignación de aportes por mes y cálculo de total
            mlngTotal = 0
            If intNroAportes > 0 Then
                Dim drAportes As DataRow
                For Each drAportes In dtAportes.Rows
                    
                    If drAportes("mes") = 1 Then
                        mlngMontoEnero = drAportes("total")
                    End If
                    If drAportes("mes") = 2 Then
                        mlngMontoFebrero = drAportes("total")
                    End If
                    If drAportes("mes") = 3 Then
                        mlngMontoMarzo = drAportes("total")
                    End If
                    If drAportes("mes") = 4 Then
                        mlngMontoAbril = drAportes("total")
                    End If
                    If drAportes("mes") = 5 Then
                        mlngMontoMayo = drAportes("total")
                    End If
                    If drAportes("mes") = 6 Then
                        mlngMontoJunio = drAportes("total")
                    End If
                    If drAportes("mes") = 7 Then
                        mlngMontoJulio = drAportes("total")
                    End If
                    If drAportes("mes") = 8 Then
                        mlngMontoAgosto = drAportes("total")
                    End If
                    If drAportes("mes") = 9 Then
                        mlngMontoSeptiembre = drAportes("total")
                    End If
                    If drAportes("mes") = 10 Then
                        mlngMontoOctubre = drAportes("total")
                    End If
                    If drAportes("mes") = 11 Then
                        mlngMontoNoviembre = drAportes("total")
                    End If
                    If drAportes("mes") = 12 Then
                        mlngMontoDiciembre = drAportes("total")
                    End If

                    'For Each drMeses In mdtMeses.Rows
                    '    If drMeses("Mes").ToString = drAportes.Item(1) Then
                    '        drMeses("Aportes") = drMeses("Aportes") + drAportes.Item(2)
                    '    End If
                    'Next
                    mlngTotal = mlngTotal + CLng(drAportes("total"))
                    'mlngTotal = mlngTotal + CLng(drAportes.Item(2))
                Next
            End If
            'For i = 0 To intNroAportes - 1
            '    intMes = arrAportes(1, i)
            '    marrMeses(intMes - 1).item("Aportes") = arrAportes(2, i)
            '    mlngTotal = mlngTotal + CLng(arrAportes(2, i))
            'Next

            'nro de certificado de aportes
            If intNroAportes = 0 Then
                mlngNroCertificado = 0
            Else
                mlngNroCertificado = mobjSql.s_certificado_aporte_1(intagno, lngRutCliente)
            End If
        Catch ex As Exception
            EnviaError("CClienteAportes: Consultar-->" & ex.Message)
        End Try
        
    End Sub

    
End Class

