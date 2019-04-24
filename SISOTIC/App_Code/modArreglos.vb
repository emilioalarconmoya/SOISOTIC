Imports System.Data
Namespace Modulos

    Public Module modArreglos
        ' Tamaño de arreglo: retorna el tamaño de dimensión 2 de un arreglo
        '
        '***************************************************
        'Ahora se usa arr.getlenght(0..n) según la dimensión
        '***************************************************
        Public Function TamanoArreglo2(ByRef arreglo As Object) As Integer
            Try
                TamanoArreglo2 = UBound(arreglo, 2) + 1
            Catch ex As Exception
                TamanoArreglo2 = 0
            End Try
        End Function

        '
        ' Tamaño de arreglo: retorna el tamaño de dimensión 1 de un arreglo
        '
        Public Function TamanoArreglo1(ByRef arreglo As Object) As Integer
            Try
                TamanoArreglo1 = UBound(arreglo, 1) + 1
            Catch ex As Exception
                TamanoArreglo1 = 0
            End Try
        End Function
        Public Function AddColumnDataTable(ByRef Dt As DataTable, _
                                           ByRef NombreColumna As String, _
                                           ByVal Tipo As String) As Boolean


            If Tipo.ToUpper = "STRING" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(String)))
            ElseIf Tipo.ToUpper = "INTEGER" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Integer)))
            ElseIf Tipo.ToUpper = "LONG" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Long)))
            ElseIf Tipo.ToUpper = "DOUBLE" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Double)))
            ElseIf Tipo.ToUpper = "BOOLEAN" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Boolean)))
            ElseIf Tipo.ToUpper = "BYTE" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Byte)))
            ElseIf Tipo.ToUpper = "CHAR" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Char)))
            ElseIf Tipo.ToUpper = "DATE" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Date)))
            ElseIf Tipo.ToUpper = "DECIMAL" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Decimal)))
            ElseIf Tipo.ToUpper = "OBJECT" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Object)))
            ElseIf Tipo.ToUpper = "SBYTE" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(SByte)))
            ElseIf Tipo.ToUpper = "SHORT" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Short)))
            ElseIf Tipo.ToUpper = "SINGLE" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(Single)))
            ElseIf Tipo.ToUpper = "UINTEGER" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(UInteger)))
            ElseIf Tipo.ToUpper = "ULONG" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(ULong)))
            ElseIf Tipo.ToUpper = "USHORT" Then
                Dt.Columns.Add(New DataColumn(NombreColumna, GetType(UShort)))
            Else
                Return False
                Exit Function
            End If
            Return True
        End Function
        Public Function AddRowDataTable(ByRef Dt As DataTable, _
                                        ByVal arrDatos As Object) As Boolean
            Dim intNumColumn, intLargoDatos, i As Integer
            Dim Dr As DataRow
            intNumColumn = Dt.Columns.Count
            intLargoDatos = TamanoArreglo2(arrDatos)
            If intNumColumn <> intLargoDatos Then
                Return False
                Exit Function
            Else
                For i = 0 To i < intLargoDatos
                    Dr = Dt.NewRow()
                    Dr(arrDatos(0, i)) = arrDatos(1, i)
                Next
                Dt.Rows.Add(Dr)
                Return True
            End If
        End Function
        
    End Module

End Namespace
