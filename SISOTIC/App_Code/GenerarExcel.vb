Imports Microsoft.Office.Interop.Excel 'agregar referencia a Microsoft Excel 12.0 Object Library
Imports System.Data
Imports Modulos
Imports clases

Public Class GenerarExcel
    Private mstrRuta As String
    Private mdtResultados As Data.DataTable

    Public WriteOnly Property Ruta() As String
        Set(ByVal value As String)
            mstrRuta = value
        End Set
    End Property
    Public ReadOnly Property Resultados()
        Get
            Return mdtResultados
        End Get
    End Property
    Public Sub New()
        mstrRuta = ""
        mdtResultados = New System.Data.DataTable
        mdtResultados.Columns.Add("archivo")
    End Sub

    Private Sub DatatableToExcel(ByVal objDT As Data.DataTable)
        Dim Excel As Object = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = mstrRuta

        If Excel Is Nothing Then
            MsgBox("Este equipo no posee Microsoft Excel o la version instalada no es la correcta.", MsgBoxStyle.Critical)
            Return
        End If

        Try
            With Excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()

                Dim intI As Integer = 1
                For intCol = 0 To objDT.Columns.Count - 1
                    .cells(1, intI).value = objDT.Columns(intCol).ColumnName
                    .cells(1, intI).EntireRow.Font.Bold = True
                    intI += 1
                Next
                intI = 2
                Dim intK As Integer = 1
                For intCol = 0 To objDT.Columns.Count - 1
                    intI = 2
                    For intRow = 0 To objDT.Rows.Count - 1
                        .Cells(intI, intK).Value = objDT.Rows(intRow).ItemArray(intCol)
                        intI += 1
                    Next
                    intK += 1
                Next
                If Mid$(strPath, strPath.Length, 1) <> "\" Then
                    strPath = strPath & "\"
                End If

                strFilename = strPath & NombreArchivoTmp("xlsx") ' "Excel.xlsx"
                .ActiveCell.Worksheet.SaveAs(strFilename)


                Dim dr As DataRow
                dr = mdtResultados.NewRow
                dr("archivo") = strFilename
                mdtResultados.Rows.Add(dr)

                '.Workbooks.SaveAss(strFilename)
            End With



            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
            MsgBox("Data's are exported to Excel Succesfully in '" & strFilename & "'", MsgBoxStyle.Information)
        Catch ex As Exception
            EnviaError("GenerarExcel:DatatableToExcel-->" & ex.Message)
        End Try
    End Sub

    Private Sub DatasetToExcel(ByVal objDs As Data.DataSet)
        Dim Excel As Object = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = mstrRuta


        If Excel Is Nothing Then
            MsgBox("Este equipo no posee Microsoft Excel o la version instalada no es la correcta.", MsgBoxStyle.Critical)
            Return
        End If
        Try
            Dim Count As Integer
            Count = objDs.Tables.Count - 1
            Dim i As Integer

            With Excel
                .SheetsInNewWorkbook = Count + 1
                .Workbooks.Add()
                For i = 0 To Count


                    .Worksheets(i + 1).Select()

                    Dim intI As Integer = 1
                    For intCol = 0 To objDs.Tables(i).Columns.Count - 1
                        .cells(1, intI).value = objDs.Tables(i).Columns(intCol).ColumnName
                        .cells(1, intI).EntireRow.Font.Bold = True
                        intI += 1
                    Next
                    intI = 2
                    Dim intK As Integer = 1
                    For intCol = 0 To objDs.Tables(i).Columns.Count - 1
                        intI = 2
                        For intRow = 0 To objDs.Tables(i).Rows.Count - 1
                            .Cells(intI, intK).Value = objDs.Tables(i).Rows(intRow).ItemArray(intCol)
                            intI += 1
                        Next
                        intK += 1
                    Next
                Next
                If Mid$(strPath, strPath.Length, 1) <> "\" Then
                    strPath = strPath & "\"
                End If
                strFilename = strPath & NombreArchivoTmp("xlsx") ' "Excel.xlsx"
                .ActiveCell.Worksheet.SaveAs(strFilename)


                Dim dr As DataRow
                dr = mdtResultados.NewRow
                dr("archivo") = strFilename
                mdtResultados.Rows.Add(dr)

            End With

            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
        Catch ex As Exception
            EnviaError("GenerarExcel:DatasetToExcel-->" & ex.Message)
        End Try
    End Sub

End Class
