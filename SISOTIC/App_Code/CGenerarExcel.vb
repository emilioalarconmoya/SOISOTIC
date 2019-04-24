'Imports Microsoft.Office.Interop.Excel 'agregar referencia a Microsoft Excel 12.0 Object Library
Imports System.Runtime.InteropServices
Imports System.Data
Imports Modulos
Imports clases
Imports Microsoft.Office.Interop.Excel

Public Class CGenerarExcel
    Private mstrRuta As String
    Private mdtResultados As Data.DataTable
    Private mstrRutaArchivo As String
    Private mstrRutaArchivoVirtual As String

    Public Property Ruta() As String
        Get
            Return mstrRuta
        End Get
        Set(ByVal value As String)
            mstrRuta = value
        End Set
    End Property
    Public ReadOnly Property Resultados()
        Get
            Return mdtResultados
        End Get
    End Property
    Public ReadOnly Property RutaArchivo() As String
        Get
            Return mstrRutaArchivo
        End Get
    End Property
    Public ReadOnly Property RutaArchivoVirtual() As String
        Get
            Return mstrRutaArchivoVirtual
        End Get
    End Property
    Public Sub New()
        mstrRuta = ""
        mdtResultados = New System.Data.DataTable
        mdtResultados.Columns.Add("archivo")
    End Sub
    Public Sub DatatableToExcel(ByVal objDT As Data.DataTable)
        Dim Excel As Object = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = Parametros.p_DIRFISICO & "tmp\" 'mstrRuta
        If Excel Is Nothing Then
            MsgBox("Este equipo no posee Microsoft Excel o la version instalada no es la correcta.", MsgBoxStyle.Critical)
            Exit Sub
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
                Dim strNombre As String = NombreArchivoTmp("xls")
                strFilename = strPath & strNombre ' "Excel.xlsx"
                .ActiveCell.Worksheet.SaveAs(strFilename)
                Dim dr As DataRow
                dr = mdtResultados.NewRow
                dr("archivo") = strFilename
                mdtResultados.Rows.Add(dr)
                'mstrRuta = strFilename

                If Mid$(Parametros.p_DIRVIRTUALMAIL, Parametros.p_DIRVIRTUALMAIL.Length, 1) <> "/" Then
                    mstrRuta = Parametros.p_DIRVIRTUALMAIL & "/tmp/" & strNombre
                Else
                    mstrRuta = Parametros.p_DIRVIRTUALMAIL & "tmp/" & strNombre
                End If
            End With
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
            'MsgBox("Data's are exported to Excel Succesfully in '" & strFilename & "'", MsgBoxStyle.Information)
        Catch ex As Exception
            EnviaError("GenerarExcel:DatatableToExcel-->" & ex.Message)
        End Try
    End Sub

    Public Sub Indicadores(ByVal objDT As Data.DataTable)
        Dim Excel As Object = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = Parametros.p_DIRFISICO & "tmp\" 'mstrRuta
        If Excel Is Nothing Then
            MsgBox("Este equipo no posee Microsoft Excel o la version instalada no es la correcta.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Try
            With Excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()
                .Worksheets(1).Name = "Indicadores"

                .Range("A1:I2").MergeCells = True
                '.Range("A1:I2").Font.Bold = True
                '.Range("A1:I2").Font.Size = 16
                '.Range("A1:I2").HorizontalAlignment = -4108
                '.Range("A1:I2").value = ""

                .Range("A3:I3").MergeCells = True
                .Range("A3:I3").Font.Bold = True
                .Range("A3:I3").Font.Size = 14
                .Range("A3:I3").HorizontalAlignment = -4108
                .Range("A3:I3").value = " INDICADORES DE GESTIÓN "

                .Range("A4:I5").MergeCells = True


                Dim intI As Integer = 1
                For intCol = 0 To objDT.Columns.Count - 1
                    .cells(6, intI).value = objDT.Columns(intCol).ColumnName
                    .cells(6, intI).EntireRow.Font.Bold = True
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
                Dim strNombre As String = NombreArchivoTmp("xls")
                strFilename = strPath & strNombre ' "Excel.xlsx"
                .ActiveCell.Worksheet.SaveAs(strFilename)
                Dim dr As DataRow
                dr = mdtResultados.NewRow
                dr("archivo") = strFilename
                mdtResultados.Rows.Add(dr)
                'mstrRuta = strFilename

                If Mid$(Parametros.p_DIRVIRTUALMAIL, Parametros.p_DIRVIRTUALMAIL.Length, 1) <> "/" Then
                    mstrRuta = Parametros.p_DIRVIRTUALMAIL & "/tmp/" & strNombre
                Else
                    mstrRuta = Parametros.p_DIRVIRTUALMAIL & "tmp/" & strNombre
                End If
            End With
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            Excel = Nothing
            'MsgBox("Data's are exported to Excel Succesfully in '" & strFilename & "'", MsgBoxStyle.Information)
        Catch ex As Exception
            EnviaError("GenerarExcel:DatatableToExcel-->" & ex.Message)
        End Try
    End Sub

    Public Sub DatasetToExcel(ByVal objDs As Data.DataSet)
        Dim Excel As Object = CreateObject("Excel.Application")
        Dim strFilename As String
        Dim intCol, intRow As Integer
        Dim strPath As String = Parametros.p_DIRFISICO & "tmp\" ' mstrRuta
        Dim strNombreArchivo As String = objDs.DataSetName
        If Excel Is Nothing Then
            MsgBox("Este equipo no posee Microsoft Excel o la version instalada no es la correcta.", MsgBoxStyle.Critical)
            Exit Sub
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
                    .Worksheets(i + 1).Name = objDs.Tables(i).TableName
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
                'Dim NombreArchivo As String = strNombreArchivo & ".xlsx"  'NombreArchivoTmp("xlsx")
                'strFilename = strPath & NombreArchivo ' "Excel.xlsx"
                Dim strNombre As String = NombreArchivoTmp("xls")
                strFilename = strPath & strNombre ' "Excel.xlsx"
                .ActiveCell.Worksheet.SaveAs(strFilename)
                Dim dr As DataRow
                dr = mdtResultados.NewRow
                dr("archivo") = strFilename 'Parametros.p_DIRVIRTUALMAIL & "/contenido/tmp/" & NombreArchivo 'strFilename
                mdtResultados.Rows.Add(dr)

                If Mid$(Parametros.p_DIRVIRTUALMAIL, Parametros.p_DIRVIRTUALMAIL.Length, 1) <> "/" Then
                    mstrRuta = Parametros.p_DIRVIRTUALMAIL & "/tmp/" & strNombre
                Else
                    mstrRuta = Parametros.p_DIRVIRTUALMAIL & "tmp/" & strNombre
                End If

            End With
            quit(Excel)
        Catch ex As Exception
            EnviaError("GenerarExcel:DatasetToExcel-->" & ex.Message)
        End Try
    End Sub

    Sub quit(ByVal Libro As Object)
        Libro.Quit()
        If Not Libro Is Nothing Then
            ' Hago un bucle de eliminaciones de las referencias de cada objeto
            ' que tiene relacion con el EXCEL
            EliminaReferencias(Libro)
        End If
        System.GC.Collect()
    End Sub
    Private Sub EliminaReferencias(ByRef Referencias As Object)
        Try
            'Bucle de eliminacion
            Do Until _
                 System.Runtime.InteropServices.Marshal.ReleaseComObject(Referencias) <= 0
            Loop
        Catch
        Finally
            Referencias = Nothing
        End Try
    End Sub
    '' ''Public Sub CartaEmpresa(ByVal dtAlumnos As System.Data.DataTable, ByVal lngCodCurso As Long, ByVal strModalidad As String, _
    '' ''                        ByVal strClienteNombreContacto As String, ByVal strClienteCargoContacto As String, _
    '' ''                        ByVal strClienteRazonSocial As String, ByVal lngCorrelativo As String, ByVal strCorrelativoEmpresa As String, _
    '' ''                        ByVal strEstadoCurso As String, ByVal strNombreCurso As String, ByVal lngCorrelativo2 As String, _
    '' ''                        ByVal dtmFechaInicio As String, ByVal dtmFechaTermino As String, ByVal strDuracionCurso As String, _
    '' ''                        ByVal strDireccionCurso As String, ByVal strNroDireccion As String, ByVal strNombreComunaCurso As String, _
    '' ''                        ByVal intHorasComplementarias As Integer, ByVal strCodSence As String, ByVal strRazonSocialOtec As String, _
    '' ''                        ByVal intParticipantes As String, ByVal strIndAcuComBip As String, ByVal strObservacion As String, _
    '' ''                        ByVal lngValorCurso As String, ByVal lngCostoOtic As String, ByVal lngCostoOticCompl As String, _
    '' ''                        ByVal lngGastoEmpresa As String, ByVal lngTotalVyT As String, ByVal lngCostoOticVyT As String, _
    '' ''                        ByVal lngGastoEmpVyT As String, ByVal lngCuentaCap As String, ByVal lngCuentaExcCap As String, _
    '' ''                        ByVal lngBecas As String, ByVal lngTerceros As String, ByVal strNombreOtic As String, ByVal lngNroRegistro As String, _
    '' ''                        ByVal dtHorario As System.Data.DataTable)

    '' ''    Dim nombreArchivo As String = NombreArchivoTmp(".xls") '    "CartaEmpresa.xls"
    '' ''    Dim archivo As String = Ruta & "\contenido\tmp\" & nombreArchivo
    '' ''    Try

    '' ''        If System.IO.File.Exists(Parametros.p_DIRFISICO & archivo) Then
    '' ''            System.IO.File.Delete(Parametros.p_DIRFISICO & archivo)
    '' ''        End If
    '' ''        System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\PlantillaExcel\CartaEmpresa.xls", Parametros.p_DIRFISICO & archivo)
    '' ''        'Una variable de tipo Libro de Excel   
    '' ''        Dim xLibro As Workbook
    '' ''        'creamos un nuevo objeto excel   
    '' ''        Dim objExcel = New Microsoft.Office.Interop.Excel.Application
    '' ''        'Usamos el método open para abrir el archivo que está _   
    '' ''        ' en el directorio del programa llamado archivo.xls   
    '' ''        xLibro = objExcel.Workbooks.Open(Parametros.p_DIRFISICO & archivo)

    '' ''        Dim intCol, intRow As Integer

    '' ''        xLibro.Worksheets(1).Range("C4:C4").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("C5:C5").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("C6:C6").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("L6:L6").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("L7:L7").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("L8:L8").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D16:F16").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D17:F17").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D18:F18").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D19:F19").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D20:F20").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D21:F21").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D22:F22").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D23:F23").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D24:F24").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D25:F25").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D26:F26").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D27:F27").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("D28:F28").MergeCells = True
    '' ''        xLibro.Worksheets(1).Range("C4:C4").value = strClienteNombreContacto
    '' ''        xLibro.Worksheets(1).Range("C5:C5").value = strClienteCargoContacto
    '' ''        xLibro.Worksheets(1).Range("C6:C6").value = strClienteRazonSocial
    '' ''        xLibro.Worksheets(1).Range("L6:L6").value = lngCorrelativo
    '' ''        xLibro.Worksheets(1).Range("L7:L7").value = strCorrelativoEmpresa
    '' ''        xLibro.Worksheets(1).Range("L8:L8").value = strEstadoCurso
    '' ''        xLibro.Worksheets(1).Range("D16:F16").value = strNombreCurso
    '' ''        xLibro.Worksheets(1).Range("D17:F17").value = strModalidad
    '' ''        xLibro.Worksheets(1).Range("D18:F18").value = lngCorrelativo2
    '' ''        xLibro.Worksheets(1).Range("D19:F19").value = dtmFechaInicio
    '' ''        xLibro.Worksheets(1).Range("D20:F20").value = dtmFechaTermino
    '' ''        xLibro.Worksheets(1).Range("D21:F21").value = strDuracionCurso & " (" & intHorasComplementarias & " hrs. complementarias)"
    '' ''        xLibro.Worksheets(1).Range("D22:F22").value = strCodSence
    '' ''        xLibro.Worksheets(1).Range("D23:F23").value = lngNroRegistro
    '' ''        xLibro.Worksheets(1).Range("D24:F24").value = strDireccionCurso & " " & strNroDireccion & " - " & strNombreComunaCurso
    '' ''        xLibro.Worksheets(1).Range("D25:F25").value = strRazonSocialOtec
    '' ''        xLibro.Worksheets(1).Range("D26:F26").value = intParticipantes
    '' ''        xLibro.Worksheets(1).Range("D27:F27").value = strIndAcuComBip
    '' ''        xLibro.Worksheets(1).Range("D28:F28").value = strObservacion


    '' ''        xLibro.Worksheets(1).Range("M17:M17").value = lngValorCurso
    '' ''        xLibro.Worksheets(1).Range("M18:M18").value = lngCostoOtic
    '' ''        xLibro.Worksheets(1).Range("M19:M19").value = lngCostoOticCompl
    '' ''        xLibro.Worksheets(1).Range("M20:M20").value = lngGastoEmpresa
    '' ''        xLibro.Worksheets(1).Range("M21:M21").value = lngTotalVyT
    '' ''        xLibro.Worksheets(1).Range("M22:M22").value = lngCostoOticVyT
    '' ''        xLibro.Worksheets(1).Range("M23:M23").value = lngGastoEmpVyT

    '' ''        xLibro.Worksheets(1).Range("M25:M25").value = lngCuentaCap
    '' ''        xLibro.Worksheets(1).Range("M26:M26").value = lngCuentaExcCap
    '' ''        xLibro.Worksheets(1).Range("M27:M27").value = lngBecas
    '' ''        xLibro.Worksheets(1).Range("M28:M28").value = lngTerceros
    '' ''        'xLibro.Worksheets(1).Range("M28:M28").value = "Guillermo Sanhueza"

    '' ''        'xLibro.Worksheets("carta").Range("B33").Value = Left(strLunes, 11)
    '' ''        'xLibro.Worksheets("carta").Range("D33").Value = Left(strMartes, 11)
    '' ''        'xLibro.Worksheets("carta").Range("F33").Value = Left(strMiercoles, 11)
    '' ''        'xLibro.Worksheets("carta").Range("K33").Value = Left(strjueves, 11)
    '' ''        'xLibro.Worksheets("carta").Range("M33").Value = Left(strViernes, 11)
    '' ''        'xLibro.Worksheets("carta").Range("O33").Value = Left(strSabado, 11)
    '' ''        'xLibro.Worksheets("carta").Range("Q33").Value = Left(strdomingo, 11)

    '' ''        Dim intFilaActual As Integer
    '' ''        Dim i As Integer
    '' ''        intFilaActual = 33
    '' ''        If dtHorario.Rows.Count > 0 Then
    '' ''            For i = 0 To dtHorario.Rows.Count - 1
    '' ''                If dtHorario.Rows.Item(i)("Dia") = 1 Then
    '' ''                    xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '' ''                End If
    '' ''                If dtHorario.Rows.Item(i)("Dia") = 2 Then
    '' ''                    xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '' ''                End If
    '' ''                If dtHorario.Rows.Item(i)("Dia") = 3 Then
    '' ''                    xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '' ''                End If
    '' ''                If dtHorario.Rows.Item(i)("Dia") = 4 Then
    '' ''                    xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '' ''                End If
    '' ''                If dtHorario.Rows.Item(i)("Dia") = 5 Then
    '' ''                    xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '' ''                End If
    '' ''                If dtHorario.Rows.Item(i)("Dia") = 6 Then
    '' ''                    xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '' ''                End If
    '' ''                If dtHorario.Rows.Item(i)("Dia") = 7 Then
    '' ''                    xLibro.Worksheets("carta").Range("Q" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("Q" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '' ''                End If
    '' ''                'xLibro.Worksheets("carta").Rows(intFilaActual + 1).EntireRow.Insert()
    '' ''                'intFilaActual = intFilaActual + 1
    '' ''            Next
    '' ''        End If
    '' ''        Dim objSql As New CSql
    '' ''        If dtAlumnos.Rows.Count > 0 Then
    '' ''            intFilaActual = intFilaActual + 5
    '' ''            For i = 0 To dtAlumnos.Rows.Count - 1
    '' ''                xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual)).Value = "Rut:"
    '' ''                xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual) & ":" & "D" & CStr(intFilaActual)).MergeCells = True
    '' ''                xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual) & ":" & "D" & CStr(intFilaActual)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual)).Value = RutLngAUsr(dtAlumnos.Rows.Item(i)("rut_alumno"))
    '' ''                xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual)).Value = "Franq:"
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("porc_franquicia")
    '' ''                xLibro.Worksheets("carta").Range("J" & CStr(intFilaActual)).Value = "Costo otic:"
    '' ''                xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("costo_otic"))
    '' ''                xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '' ''                xLibro.Worksheets("carta").Range("L" & CStr(intFilaActual)).Value = "Viático:"
    '' ''                xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("viatico"))
    '' ''                xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '' ''                xLibro.Worksheets("carta").Range("N" & CStr(intFilaActual)).Value = "Nivel Educ:"
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).MergeCells = True
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("nivel_educacional")

    '' ''                xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual + 1) & ":" & "D" & CStr(intFilaActual + 1)).MergeCells = True
    '' ''                xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual + 1) & ":" & "D" & CStr(intFilaActual + 1)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 1)).Value = "Nombre:"
    '' ''                xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual + 1)).Value = dtAlumnos.Rows.Item(i)("nombre_completo")
    '' ''                xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual + 1)).Value = "Sexo:"
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 1)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 1)).Value = dtAlumnos.Rows.Item(i)("sexo")
    '' ''                xLibro.Worksheets("carta").Range("J" & CStr(intFilaActual + 1)).Value = "Gasto emp.:"
    '' ''                xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 1)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("gasto_empresa"))
    '' ''                xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '' ''                xLibro.Worksheets("carta").Range("L" & CStr(intFilaActual + 1)).Value = "Traslado:"
    '' ''                xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual + 1)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("traslado"))
    '' ''                xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '' ''                xLibro.Worksheets("carta").Range("N" & CStr(intFilaActual + 1)).Value = "Nivel Prof:"
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).MergeCells = True
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).Value = dtAlumnos.Rows.Item(i)("nivel_ocupacional")

    '' ''                xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual + 2)).Value = "Fecha nac.:"
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 2)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 2)).Value = dtAlumnos.Rows.Item(i)("fecha_nacim")
    '' ''                xLibro.Worksheets("carta").Range("J" & CStr(intFilaActual + 2)).Value = "Total:"
    '' ''                xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 2)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("total"))
    '' ''                xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '' ''                xLibro.Worksheets("carta").Range("N" & CStr(intFilaActual + 2)).Value = "Origen:"
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).MergeCells = True
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).WrapText = True
    '' ''                xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).Value = objSql.NombreRegion(dtAlumnos.Rows.Item(i)("cod_region"))



    '' ''                xLibro.Worksheets("carta").Rows(intFilaActual + 4).EntireRow.Insert()
    '' ''                intFilaActual = intFilaActual + 4

    '' ''            Next


    '' ''            objSql = Nothing
    '' ''        End If
    '' ''        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 4)).Value = "Quedando a su entera disposición para aclarar cualquier duda,"
    '' ''        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 4)).Value = "Saluda atentamente a usted."
    '' ''        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 6) & ":" & "C" & CStr(intFilaActual + 6)).MergeCells = True
    '' ''        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 6)).Value = Parametros.p_EMPRESA

    '' ''        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 8)).Value = Parametros.p_NOMBREOC

    '' ''        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 9)).Value = Parametros.p_CARGOOC


    '' ''        xLibro.Save()
    '' ''        xLibro.Close()
    '' ''        quit(objExcel)

    '' ''        mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

    '' ''        mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo


    '' ''    Catch ex As Exception
    '' ''        EnviaError("GenerarExcel:CartaEmpresa-->" & ex.Message)
    '' ''    End Try
    '' ''End Sub
    'Public Sub CartaEmpresa(ByVal dtAlumnos As System.Data.DataTable, ByVal lngCodCurso As Long, ByVal strModalidad As String, _
    '                        ByVal strClienteNombreContacto As String, ByVal strClienteCargoContacto As String, _
    '                        ByVal strClienteRazonSocial As String, ByVal lngCorrelativo As String, ByVal strCorrelativoEmpresa As String, _
    '                        ByVal strEstadoCurso As String, ByVal strNombreCurso As String, ByVal lngCorrelativo2 As String, _
    '                        ByVal dtmFechaInicio As String, ByVal dtmFechaTermino As String, ByVal strDuracionCurso As String, _
    '                        ByVal strDireccionCurso As String, ByVal strNroDireccion As String, ByVal strNombreComunaCurso As String, _
    '                        ByVal intHorasComplementarias As Integer, ByVal strCodSence As String, ByVal strRazonSocialOtec As String, _
    '                        ByVal intParticipantes As String, ByVal strIndAcuComBip As String, ByVal strObservacion As String, _
    '                        ByVal lngValorCurso As String, ByVal lngCostoOtic As String, ByVal lngCostoOticCompl As String, _
    '                        ByVal lngGastoEmpresa As String, ByVal lngTotalVyT As String, ByVal lngCostoOticVyT As String, _
    '                        ByVal lngGastoEmpVyT As String, ByVal lngCuentaCap As String, ByVal lngCuentaExcCap As String, _
    '                        ByVal lngBecas As String, ByVal lngTerceros As String, ByVal strNombreOtic As String, ByVal lngNroRegistro As String, _
    '                        ByVal dtHorario As System.Data.DataTable)

    '    Dim nombreArchivo As String = NombreArchivoTmp(".xls") '    "CartaEmpresa.xls"
    '    Dim archivo As String = Ruta & "\contenido\tmp\" & nombreArchivo
    '    Try

    '        If System.IO.File.Exists(Parametros.p_DIRFISICO & archivo) Then
    '            System.IO.File.Delete(Parametros.p_DIRFISICO & archivo)
    '        End If
    '        System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\PlantillaExcel\FORMATO_CARTA_EMPRESA.xls", Parametros.p_DIRFISICO & archivo)
    '        'Una variable de tipo Libro de Excel   
    '        Dim xLibro As Workbook
    '        'creamos un nuevo objeto excel   
    '        Dim objExcel = New Microsoft.Office.Interop.Excel.Application
    '        'Usamos el método open para abrir el archivo que está _   
    '        ' en el directorio del programa llamado archivo.xls   
    '        xLibro = objExcel.Workbooks.Open(Parametros.p_DIRFISICO & archivo)

    '        Dim intCol, intRow As Integer

    '        'xLibro.Worksheets(1).Range("C4:C4").MergeCells = True
    '        'xLibro.Worksheets(1).Range("C5:C5").MergeCells = True
    '        'xLibro.Worksheets(1).Range("C6:C6").MergeCells = True
    '        'xLibro.Worksheets(1).Range("L6:L6").MergeCells = True
    '        'xLibro.Worksheets(1).Range("L7:L7").MergeCells = True
    '        'xLibro.Worksheets(1).Range("L8:L8").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D16:F16").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D17:F17").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D18:F18").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D19:F19").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D20:F20").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D21:F21").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D22:F22").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D23:F23").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D24:F24").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D25:F25").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D26:F26").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D27:F27").MergeCells = True
    '        'xLibro.Worksheets(1).Range("D28:F28").MergeCells = True
    '        xLibro.Worksheets(1).Range("B6:I6").value = strClienteNombreContacto
    '        xLibro.Worksheets(1).Range("A7:I7").value = strClienteCargoContacto
    '        xLibro.Worksheets(1).Range("A8:I8").value = strClienteRazonSocial
    '        xLibro.Worksheets(1).Range("M6:N6").value = lngCorrelativo
    '        xLibro.Worksheets(1).Range("M7:N7").value = lngNroRegistro 'strCorrelativoEmpresa
    '        xLibro.Worksheets(1).Range("M8:N8").value = strEstadoCurso



    '        xLibro.Worksheets(1).Range("D17:I17").value = strNombreCurso
    '        xLibro.Worksheets(1).Range("D18:I18").value = lngCorrelativo '""strModalidad
    '        xLibro.Worksheets(1).Range("D19:I19").value = lngNroRegistro 'lngCorrelativo2
    '        xLibro.Worksheets(1).Range("D20:I20").value = dtmFechaInicio
    '        xLibro.Worksheets(1).Range("D21:I21").value = dtmFechaTermino
    '        xLibro.Worksheets(1).Range("D22:I22").value = strDuracionCurso & " (" & intHorasComplementarias & " hrs. complementarias)"
    '        xLibro.Worksheets(1).Range("D23:I23").value = strCodSence
    '        xLibro.Worksheets(1).Range("D24:I24").value = strDireccionCurso & " " & strNroDireccion
    '        xLibro.Worksheets(1).Range("D25:I25").value = strNombreComunaCurso
    '        xLibro.Worksheets(1).Range("D26:I26").value = strIndAcuComBip
    '        xLibro.Worksheets(1).Range("D27:I27").value = intParticipantes
    '        xLibro.Worksheets(1).Range("D28:I28").value = strRazonSocialOtec 'strIndAcuComBip
    '        xLibro.Worksheets(1).Range("D29:I29").value = intParticipantes


    '        xLibro.Worksheets(1).Range("M17:N17").value = lngValorCurso
    '        xLibro.Worksheets(1).Range("M18:N18").value = lngCostoOtic
    '        xLibro.Worksheets(1).Range("M19:N19").value = lngCostoOticCompl
    '        xLibro.Worksheets(1).Range("M20:N20").value = "" ' lngGastoEmpresa
    '        xLibro.Worksheets(1).Range("M21:N21").value = lngGastoEmpresa
    '        xLibro.Worksheets(1).Range("M22:N22").value = lngTotalVyT
    '        xLibro.Worksheets(1).Range("M23:N23").value = lngCostoOticVyT
    '        xLibro.Worksheets(1).Range("M24:N24").value = lngGastoEmpVyT

    '        'xLibro.Worksheets(1).Range("M25:N25").value = lngCuentaCap
    '        'xLibro.Worksheets(1).Range("M26:N26").value = lngCuentaExcCap
    '        'xLibro.Worksheets(1).Range("M27:N27").value = lngBecas
    '        'xLibro.Worksheets(1).Range("M28:N28").value = lngTerceros
    '        'xLibro.Worksheets(1).Range("M28:M28").value = "Guillermo Sanhueza"

    '        'xLibro.Worksheets("carta").Range("B33").Value = Left(strLunes, 11)
    '        'xLibro.Worksheets("carta").Range("D33").Value = Left(strMartes, 11)
    '        'xLibro.Worksheets("carta").Range("F33").Value = Left(strMiercoles, 11)
    '        'xLibro.Worksheets("carta").Range("K33").Value = Left(strjueves, 11)
    '        'xLibro.Worksheets("carta").Range("M33").Value = Left(strViernes, 11)
    '        'xLibro.Worksheets("carta").Range("O33").Value = Left(strSabado, 11)
    '        'xLibro.Worksheets("carta").Range("Q33").Value = Left(strdomingo, 11)

    '        Dim intFilaActual As Integer
    '        Dim i As Integer
    '        intFilaActual = 33

    '        Dim Lunes As String = ""
    '        Dim Martes As String = ""
    '        Dim Miercoles As String = ""
    '        Dim Jueves As String = ""
    '        Dim Viernes As String = ""
    '        Dim Sabado As String = ""
    '        Dim Domingo As String = ""



    '        If dtHorario.Rows.Count > 0 Then
    '            For i = 0 To dtHorario.Rows.Count - 1
    '                If dtHorario.Rows.Item(i)("Dia") = 1 Then
    '                    Lunes = Lunes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 2 Then
    '                    Martes = Martes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 3 Then
    '                    Miercoles = Miercoles & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 4 Then
    '                    Jueves = Jueves & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 5 Then
    '                    Viernes = Viernes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 6 Then
    '                    Sabado = Sabado & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 7 Then
    '                    Domingo = Domingo & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
    '                End If
    '            Next
    '        End If

    '        xLibro.Worksheets(1).Range("A33:B33").Value = Lunes
    '        xLibro.Worksheets(1).Range("C33:D33").Value = Martes
    '        xLibro.Worksheets(1).Range("E33:F33").Value = Miercoles
    '        xLibro.Worksheets(1).Range("G33:H33").Value = Jueves
    '        xLibro.Worksheets(1).Range("I33:J33").Value = Viernes
    '        xLibro.Worksheets(1).Range("K33:L33").Value = Sabado
    '        xLibro.Worksheets(1).Range("M33:N33").Value = Domingo



    '        Dim CantFilasNuevas As Integer = (dtAlumnos.Rows.Count - 1) * 4
    '        intFilaActual = 39

    '        For i = 0 To i <= CantFilasNuevas - 1
    '            xLibro.Worksheets(1).Rows(intFilaActual + i).EntireRow.Insert()
    '            xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":N" & intFilaActual.ToString).Insert(Shift:=Microsoft.Office.Interop.Excel.XlDirection.xlDown)
    '        Next



    '        Dim objSql As New CSql
    '        If dtAlumnos.Rows.Count > 0 Then
    '            For i = 0 To dtAlumnos.Rows.Count - 1
    '                xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft


    '                xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

    '                xLibro.Worksheets(1).Range("G" & intFilaActual.ToString & ":H" & intFilaActual.ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("G" & intFilaActual.ToString & ":H" & intFilaActual.ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("G" & intFilaActual.ToString & ":H" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 1).ToString & ":H" & (intFilaActual + 1).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 1).ToString & ":H" & (intFilaActual + 1).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 1).ToString & ":H" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 2).ToString & ":H" & (intFilaActual + 2).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 2).ToString & ":H" & (intFilaActual + 2).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 2).ToString & ":H" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight

    '                xLibro.Worksheets(1).Range("J" & intFilaActual.ToString & ":K" & intFilaActual.ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("J" & intFilaActual.ToString & ":K" & intFilaActual.ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("J" & intFilaActual.ToString & ":K" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                xLibro.Worksheets(1).Range("J" & (intFilaActual + 1).ToString & ":K" & (intFilaActual + 1).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("J" & (intFilaActual + 1).ToString & ":K" & (intFilaActual + 1).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("J" & (intFilaActual + 1).ToString & ":K" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight

    '                xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 1).ToString & ":N" & (intFilaActual + 1).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 1).ToString & ":N" & (intFilaActual + 1).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 1).ToString & ":N" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 2).ToString & ":N" & (intFilaActual + 2).ToString).MergeCells = True
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 2).ToString & ":N" & (intFilaActual + 2).ToString).WrapText = True
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 2).ToString & ":N" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft



    '                xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("nombre_completo").ToString
    '                xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).Value = "Rut: " & RutLngAUsr(dtAlumnos.Rows.Item(i)("rut_alumno")).ToString

    '                xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("porc_franquicia").ToString
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).Value = dtAlumnos.Rows.Item(i)("sexo").ToString
    '                xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).Value = Left(dtAlumnos.Rows.Item(i)("fecha_nacim").ToString, 10)

    '                xLibro.Worksheets(1).Range("G" & intFilaActual.ToString & ":H" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("costo_otic").ToString
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 1).ToString & ":H" & (intFilaActual + 1).ToString).Value = dtAlumnos.Rows.Item(i)("gasto_empresa").ToString
    '                xLibro.Worksheets(1).Range("G" & (intFilaActual + 2).ToString & ":H" & (intFilaActual + 2).ToString).Value = dtAlumnos.Rows.Item(i)("total").ToString

    '                xLibro.Worksheets(1).Range("J" & intFilaActual.ToString & ":K" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("viatico").ToString
    '                xLibro.Worksheets(1).Range("J" & (intFilaActual + 1).ToString & ":K" & (intFilaActual + 1).ToString).Value = dtAlumnos.Rows.Item(i)("traslado").ToString

    '                xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("nivel_educacional").ToString
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 1).ToString & ":N" & (intFilaActual + 1).ToString).Value = dtAlumnos.Rows.Item(i)("nivel_ocupacional").ToString
    '                xLibro.Worksheets(1).Range("M" & (intFilaActual + 2).ToString & ":N" & (intFilaActual + 2).ToString).Value = dtAlumnos.Rows.Item(i)("cod_region").ToString

    '                intFilaActual = intFilaActual + 4

    '                'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual)).Value = "Rut:"
    '                'xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual) & ":" & "D" & CStr(intFilaActual)).MergeCells = True
    '                'xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual) & ":" & "D" & CStr(intFilaActual)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual)).Value = RutLngAUsr(dtAlumnos.Rows.Item(i)("rut_alumno"))
    '                'xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual)).Value = "Franq:"
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("porc_franquicia")
    '                'xLibro.Worksheets("carta").Range("J" & CStr(intFilaActual)).Value = "Costo otic:"
    '                'xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("costo_otic"))
    '                'xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                'xLibro.Worksheets("carta").Range("L" & CStr(intFilaActual)).Value = "Viático:"
    '                'xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("viatico"))
    '                'xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                'xLibro.Worksheets("carta").Range("N" & CStr(intFilaActual)).Value = "Nivel Educ:"
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).MergeCells = True
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual) & ":" & "P" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("nivel_educacional")

    '                'xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual + 1) & ":" & "D" & CStr(intFilaActual + 1)).MergeCells = True
    '                'xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual + 1) & ":" & "D" & CStr(intFilaActual + 1)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 1)).Value = "Nombre:"
    '                'xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual + 1)).Value = dtAlumnos.Rows.Item(i)("nombre_completo")
    '                'xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual + 1)).Value = "Sexo:"
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 1)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 1)).Value = dtAlumnos.Rows.Item(i)("sexo")
    '                'xLibro.Worksheets("carta").Range("J" & CStr(intFilaActual + 1)).Value = "Gasto emp.:"
    '                'xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 1)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("gasto_empresa"))
    '                'xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                'xLibro.Worksheets("carta").Range("L" & CStr(intFilaActual + 1)).Value = "Traslado:"
    '                'xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual + 1)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("traslado"))
    '                'xLibro.Worksheets("carta").Range("M" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                'xLibro.Worksheets("carta").Range("N" & CStr(intFilaActual + 1)).Value = "Nivel Prof:"
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).MergeCells = True
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 1) & ":" & "P" & CStr(intFilaActual + 1)).Value = dtAlumnos.Rows.Item(i)("nivel_ocupacional")

    '                'xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual + 2)).Value = "Fecha nac.:"
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 2)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual + 2)).Value = dtAlumnos.Rows.Item(i)("fecha_nacim")
    '                'xLibro.Worksheets("carta").Range("J" & CStr(intFilaActual + 2)).Value = "Total:"
    '                'xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 2)).Value = FormatoPeso(dtAlumnos.Rows.Item(i)("total"))
    '                'xLibro.Worksheets("carta").Range("K" & CStr(intFilaActual + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '                'xLibro.Worksheets("carta").Range("N" & CStr(intFilaActual + 2)).Value = "Origen:"
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).MergeCells = True
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).WrapText = True
    '                'xLibro.Worksheets("carta").Range("O" & CStr(intFilaActual + 2) & ":" & "P" & CStr(intFilaActual + 2)).Value = objSql.NombreRegion(dtAlumnos.Rows.Item(i)("cod_region"))



    '                'xLibro.Worksheets(1).Rows(intFilaActual + 4).EntireRow.Insert()
    '                'intFilaActual = intFilaActual + 4

    '            Next


    '            objSql = Nothing
    '        End If
    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 4)).Value = "Quedando a su entera disposición para aclarar cualquier duda,"
    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 4)).Value = "Saluda atentamente a usted."
    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 6) & ":" & "C" & CStr(intFilaActual + 6)).MergeCells = True
    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 6)).Value = Parametros.p_EMPRESA

    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 8)).Value = Parametros.p_NOMBREOC

    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 9)).Value = Parametros.p_CARGOOC


    '        xLibro.Save()
    '        xLibro.Close()
    '        quit(objExcel)

    '        mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

    '        mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo


    '    Catch ex As Exception
    '        EnviaError("GenerarExcel:CartaEmpresa-->" & ex.Message)
    '    End Try
    'End Sub
    Public Sub CartaEmpresa(ByVal dtAlumnos As System.Data.DataTable, ByVal lngCodCurso As Long, ByVal strModalidad As String, _
                            ByVal strClienteNombreContacto As String, ByVal strClienteCargoContacto As String, _
                            ByVal strClienteRazonSocial As String, ByVal lngCorrelativo As String, ByVal strCorrelativoEmpresa As String, _
                            ByVal strEstadoCurso As String, ByVal strNombreCurso As String, ByVal lngCorrelativo2 As String, _
                            ByVal dtmFechaInicio As String, ByVal dtmFechaTermino As String, ByVal strDuracionCurso As String, _
                            ByVal strDireccionCurso As String, ByVal strNroDireccion As String, ByVal strNombreComunaCurso As String, _
                            ByVal intHorasComplementarias As Integer, ByVal strCodSence As String, ByVal strRazonSocialOtec As String, _
                            ByVal intParticipantes As String, ByVal strIndAcuComBip As String, ByVal strObservacion As String, _
                            ByVal lngValorCurso As String, ByVal lngCostoOtic As String, ByVal lngCostoOticCompl As String, _
                            ByVal lngGastoEmpresa As String, ByVal lngTotalVyT As String, ByVal lngCostoOticVyT As String, _
                            ByVal lngGastoEmpVyT As String, ByVal lngCuentaCap As String, ByVal lngCuentaExcCap As String, _
                            ByVal lngBecas As String, ByVal lngTerceros As String, ByVal strNombreOtic As String, ByVal lngNroRegistro As String, _
                            ByVal dtHorario As System.Data.DataTable, ByVal lngCodCursoParcial As String, ByVal lngCodCursoCompl As String, _
                            Optional ByVal strUsuario As String = "", Optional ByVal strValorHora As String = "", Optional ByVal strCorrelativoEmp As String = "")

        Dim nombreArchivo As String = NombreArchivoTmp(".xls") '    "CartaEmpresa.xls"
        Dim archivo As String = Ruta & "\contenido\tmp\" & nombreArchivo
        Try

            If System.IO.File.Exists(Parametros.p_DIRFISICO & archivo) Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & archivo)
            End If
            System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\PlantillaExcel\FORMATO_CARTA_EMPRESA.xls", Parametros.p_DIRFISICO & archivo)
            'Una variable de tipo Libro de Excel   
            Dim xLibro As Workbook
            'creamos un nuevo objeto excel   
            Dim objExcel = New Microsoft.Office.Interop.Excel.Application
            'Usamos el método open para abrir el archivo que está _   
            ' en el directorio del programa llamado archivo.xls   
            xLibro = objExcel.Workbooks.Open(Parametros.p_DIRFISICO & archivo)

            Dim intCol, intRow As Integer
            If lngCodCursoParcial <> -1 Then
                xLibro.Worksheets(1).Range("A5:N5").value = "CORRELATIVO O/C " & lngCorrelativo & " - COMPLEMENTARIO"
            ElseIf lngCodCursoCompl <> -1 Then
                xLibro.Worksheets(1).Range("A5:N5").value = "CORRELATIVO O/C " & lngCorrelativo & " - PRRCIAL"
            Else
                xLibro.Worksheets(1).Range("A5:N5").value = "CORRELATIVO O/C " & lngCorrelativo
            End If



            xLibro.Worksheets(1).Range("A6:K6").value = Left(strClienteNombreContacto.ToUpper, 48)
            xLibro.Worksheets(1).Range("B7:K7").value = Left(strClienteCargoContacto.ToUpper, 54)
            xLibro.Worksheets(1).Range("B8:K8").value = Left(strClienteRazonSocial.ToUpper, 54)
            xLibro.Worksheets(1).Range("P6:P6").value = lngCorrelativo
            xLibro.Worksheets(1).Range("P7:Q7").value = lngNroRegistro 'strCorrelativoEmpresa
            xLibro.Worksheets(1).Range("P8:Q8").value = Left(strEstadoCurso.ToUpper, 14)
            xLibro.Worksheets(1).Range("P9:Q9").value = Left(strUsuario.ToUpper, 14)
            xLibro.Worksheets(1).Range("P10:Q10").value = Now.Date
            xLibro.Worksheets(1).Range("P11:Q11").value = strCorrelativoEmp

            xLibro.Worksheets(1).Range("D17:K17").value = Left(strNombreCurso.ToUpper, 48)
            xLibro.Worksheets(1).Range("D18:K18").value = strModalidad.ToUpper  '""strModalidad
            xLibro.Worksheets(1).Range("D19:K19").value = lngCorrelativo  'lngCorrelativo2
            xLibro.Worksheets(1).Range("D20:K20").value = dtmFechaInicio
            xLibro.Worksheets(1).Range("D21:K21").value = dtmFechaTermino
            xLibro.Worksheets(1).Range("D22:K22").value = strDuracionCurso & " (" & intHorasComplementarias & " HRS. COMPLEMENTARIAS)"
            xLibro.Worksheets(1).Range("D23:K23").value = strCodSence
            xLibro.Worksheets(1).Range("D24:K24").value = lngNroRegistro
            xLibro.Worksheets(1).Range("D25:K25").value = strDireccionCurso.ToUpper & " " & strNombreComunaCurso.ToUpper
            xLibro.Worksheets(1).Range("D26:K26").value = strRazonSocialOtec.ToUpper
            xLibro.Worksheets(1).Range("D27:K27").value = intParticipantes
            xLibro.Worksheets(1).Range("D28:K28").value = strIndAcuComBip.ToUpper
            xLibro.Worksheets(1).Range("D29:K29").value = FormatoPeso(strValorHora)

            xLibro.Worksheets(1).Range("P17:Q17").value = FormatoMonto(Replace(lngValorCurso, "$", ""))
            xLibro.Worksheets(1).Range("P18:Q18").value = FormatoMonto(Replace(lngCostoOtic, "$", ""))
            xLibro.Worksheets(1).Range("P19:Q19").value = FormatoMonto(Replace(lngCostoOticCompl, "$", ""))
            xLibro.Worksheets(1).Range("P20:Q20").value = FormatoMonto(Replace(lngGastoEmpresa, "$", ""))
            xLibro.Worksheets(1).Range("P21:Q21").value = FormatoMonto(Replace(lngTotalVyT, "$", ""))
            xLibro.Worksheets(1).Range("P22:Q22").value = FormatoMonto(Replace(lngCostoOticVyT, "$", ""))
            xLibro.Worksheets(1).Range("P23:Q23").value = FormatoMonto(Replace(lngGastoEmpVyT, "$", ""))


            xLibro.Worksheets(1).Range("L20:N20").value = "COSTO OTIC COMPLEMENTARIO"

            Dim intFilaActual As Integer
            Dim i As Integer
            intFilaActual = 33

            Dim Lunes As String = ""
            Dim Martes As String = ""
            Dim Miercoles As String = ""
            Dim Jueves As String = ""
            Dim Viernes As String = ""
            Dim Sabado As String = ""
            Dim Domingo As String = ""

            If dtHorario.Rows.Count > 0 Then
                For i = 0 To dtHorario.Rows.Count - 1
                    If dtHorario.Rows.Item(i)("Dia") = 1 Then
                        Lunes = Lunes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 2 Then
                        Martes = Martes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 3 Then
                        Miercoles = Miercoles & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 4 Then
                        Jueves = Jueves & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 5 Then
                        Viernes = Viernes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 6 Then
                        Sabado = Sabado & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 7 Then
                        Domingo = Domingo & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                Next
            End If

            xLibro.Worksheets(1).Range("A33:B33").Value = Lunes
            xLibro.Worksheets(1).Range("C33:D33").Value = Martes
            xLibro.Worksheets(1).Range("E33:F33").Value = Miercoles
            xLibro.Worksheets(1).Range("G33:I33").Value = Jueves
            xLibro.Worksheets(1).Range("J33:L33").Value = Viernes
            xLibro.Worksheets(1).Range("M33:O33").Value = Sabado
            xLibro.Worksheets(1).Range("P33:Q33").Value = Domingo

            Dim CantFilasNuevas As Integer = (dtAlumnos.Rows.Count - 1) * 4
            intFilaActual = 39

            'For i = 0 To i <= CantFilasNuevas - 1
            '    xLibro.Worksheets(1).Rows(intFilaActual + i).EntireRow.Insert()
            '    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":N" & intFilaActual.ToString).Insert(Shift:=Microsoft.Office.Interop.Excel.XlDirection.xlDown)
            'Next

            Dim objSql As New CSql
            If dtAlumnos.Rows.Count > 0 Then
                For i = 0 To dtAlumnos.Rows.Count - 1


                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("D" & intFilaActual.ToString & ":E" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("D" & intFilaActual.ToString & ":E" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("F" & intFilaActual.ToString & ":I" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("F" & intFilaActual.ToString & ":I" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("J" & intFilaActual.ToString & ":M" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("J" & intFilaActual.ToString & ":M" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("N" & intFilaActual.ToString & ":Q" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("N" & intFilaActual.ToString & ":Q" & (intFilaActual + 3).ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous




                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    'xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).NumberFormat = "dd/mm/yyyy"

                    xLibro.Worksheets(1).Range("H" & intFilaActual.ToString & ":I" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("H" & intFilaActual.ToString & ":I" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("H" & intFilaActual.ToString & ":I" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 1).ToString & ":I" & (intFilaActual + 1).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 1).ToString & ":I" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 1).ToString & ":I" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 2).ToString & ":I" & (intFilaActual + 2).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 2).ToString & ":I" & (intFilaActual + 2).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 2).ToString & ":I" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight

                    xLibro.Worksheets(1).Range("L" & intFilaActual.ToString & ":M" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("L" & intFilaActual.ToString & ":M" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("L" & intFilaActual.ToString & ":M" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                    xLibro.Worksheets(1).Range("L" & (intFilaActual + 1).ToString & ":M" & (intFilaActual + 1).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("L" & (intFilaActual + 1).ToString & ":M" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("L" & (intFilaActual + 1).ToString & ":M" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight

                    xLibro.Worksheets(1).Range("P" & intFilaActual.ToString & ":Q" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("P" & intFilaActual.ToString & ":Q" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("P" & intFilaActual.ToString & ":Q" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 2).ToString & ":Q" & (intFilaActual + 2).ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 2).ToString & ":Q" & (intFilaActual + 2).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 2).ToString & ":Q" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    xLibro.Worksheets(1).Range("D" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("D" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("D" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("D" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("D" & (intFilaActual + 2).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("D" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    xLibro.Worksheets(1).Range("F" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("F" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("F" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("F" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("F" & (intFilaActual + 2).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("F" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    xLibro.Worksheets(1).Range("J" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("J" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("J" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("J" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("J" & (intFilaActual + 2).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("J" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    xLibro.Worksheets(1).Range("N" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("N" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("N" & (intFilaActual + 1).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("N" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("N" & (intFilaActual + 2).ToString).WrapText = True
                    xLibro.Worksheets(1).Range("N" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft

                    xLibro.Worksheets(1).Range("D" & intFilaActual.ToString).Value = "FRANQ"
                    xLibro.Worksheets(1).Range("D" & (intFilaActual + 1).ToString).Value = "SEXO"
                    xLibro.Worksheets(1).Range("D" & (intFilaActual + 2).ToString).Value = "F. NAC."

                    xLibro.Worksheets(1).Range("F" & intFilaActual.ToString).Value = "C. OTIC"
                    xLibro.Worksheets(1).Range("F" & (intFilaActual + 1).ToString).Value = "C. EMP."
                    xLibro.Worksheets(1).Range("F" & (intFilaActual + 2).ToString).Value = "TOTAL"

                    xLibro.Worksheets(1).Range("J" & intFilaActual.ToString).Value = "VIATICO"
                    xLibro.Worksheets(1).Range("J" & (intFilaActual + 1).ToString).Value = "TRASLADO"

                    xLibro.Worksheets(1).Range("N" & intFilaActual.ToString).Value = "N. EDUC."
                    xLibro.Worksheets(1).Range("N" & (intFilaActual + 1).ToString).Value = "N. OCUP."
                    xLibro.Worksheets(1).Range("N" & (intFilaActual + 2).ToString).Value = "REGION"

                    xLibro.Worksheets(1).Range("G" & intFilaActual.ToString).Value = "$"
                    xLibro.Worksheets(1).Range("G" & (intFilaActual + 1).ToString).Value = "$"
                    xLibro.Worksheets(1).Range("G" & (intFilaActual + 2).ToString).Value = "$"

                    xLibro.Worksheets(1).Range("K" & intFilaActual.ToString).Value = "$"
                    xLibro.Worksheets(1).Range("K" & (intFilaActual + 1).ToString).Value = "$"

                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":C" & intFilaActual.ToString).Value = Left(dtAlumnos.Rows.Item(i)("nombre_completo").ToString, 17)
                    xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":C" & (intFilaActual + 1).ToString).Value = "RUT: " & RutLngAUsr(dtAlumnos.Rows.Item(i)("rut_alumno")).ToString

                    xLibro.Worksheets(1).Range("E" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("porc_franquicia").ToString
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 1).ToString).Value = dtAlumnos.Rows.Item(i)("sexo").ToString
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).Value = "'" & Left(dtAlumnos.Rows.Item(i)("fecha_nacim").ToString, 10)

                    xLibro.Worksheets(1).Range("H" & intFilaActual.ToString & ":I" & intFilaActual.ToString).Value = FormatoMonto(dtAlumnos.Rows.Item(i)("costo_otic").ToString)
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 1).ToString & ":I" & (intFilaActual + 1).ToString).Value = FormatoMonto(dtAlumnos.Rows.Item(i)("gasto_empresa").ToString)
                    xLibro.Worksheets(1).Range("H" & (intFilaActual + 2).ToString & ":I" & (intFilaActual + 2).ToString).Value = FormatoMonto(dtAlumnos.Rows.Item(i)("total").ToString)

                    xLibro.Worksheets(1).Range("L" & intFilaActual.ToString & ":M" & intFilaActual.ToString).Value = FormatoMonto(dtAlumnos.Rows.Item(i)("viatico").ToString)
                    xLibro.Worksheets(1).Range("L" & (intFilaActual + 1).ToString & ":M" & (intFilaActual + 1).ToString).Value = FormatoMonto(dtAlumnos.Rows.Item(i)("traslado").ToString)

                    xLibro.Worksheets(1).Range("P" & intFilaActual.ToString & ":Q" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("cod_nivel_educ").ToString
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).Value = dtAlumnos.Rows.Item(i)("cod_nivel_ocup").ToString
                    xLibro.Worksheets(1).Range("P" & (intFilaActual + 2).ToString & ":Q" & (intFilaActual + 2).ToString).Value = dtAlumnos.Rows.Item(i)("cod_region").ToString
                    xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).NumberFormat = Replace(xLibro.Worksheets(1).Range("E" & (intFilaActual + 2).ToString).NumberFormat, "\", "")


                    xLibro.Worksheets(1).Rows(intFilaActual + 4).EntireRow.Insert()
                    xLibro.Worksheets(1).Rows(intFilaActual + 4).EntireRow.Insert()
                    xLibro.Worksheets(1).Rows(intFilaActual + 4).EntireRow.Insert()
                    xLibro.Worksheets(1).Rows(intFilaActual + 4).EntireRow.Insert()

                    intFilaActual = intFilaActual + 4
                Next
                objSql = Nothing
            End If


            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).MergeCells = True
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignJustify
            'Dim border As Microsoft.Office.Interop.Excel.Borders = xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).Borders
            'border(XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            'border(XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            'border(XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 2).ToString & ":Q" & (intFilaActual + 2).ToString).MergeCells = True
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 2).ToString & ":Q" & (intFilaActual + 2).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignJustify
            'Dim border2 As Microsoft.Office.Interop.Excel.Borders = xLibro.Worksheets(1).Range("A" & (intFilaActual + 2).ToString & ":Q" & (intFilaActual + 2).ToString).Borders
            'border2(XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            'border2(XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 3).ToString & ":Q" & (intFilaActual + 3).ToString).MergeCells = True
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 3).ToString & ":Q" & (intFilaActual + 3).ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignJustify
            'Dim border3 As Microsoft.Office.Interop.Excel.Borders = xLibro.Worksheets(1).Range("A" & (intFilaActual + 3).ToString & ":Q" & (intFilaActual + 3).ToString).Borders
            'border3(XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            'border3(XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            'border3(XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).EntireRow.RowHeight = 27.75
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 3).ToString & ":Q" & (intFilaActual + 3).ToString).EntireRow.RowHeight = 27.75
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).Font.Size = 7
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 3).ToString & ":Q" & (intFilaActual + 3).ToString).Font.Size = 7

            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 1).ToString & ":Q" & (intFilaActual + 1).ToString).Value = "NIVEL EDUCACIONAL: 1 - SIN ESCOLARIDAD, 2 - LICENCIA BASICA INCOMPLETA, 3 - LICENCIA BASICA INCOMPLETA, 4 - LICENCIA MEDIA INCOMPLETA, 5 - LICENCIA MEDIA COMPLETA, 6 SUPERIOR TECNICA PROFESIONAL INCOMPLETA, 7 - SUPERIOR TECNICA PROFESIONAL COMPLETA, 8 - UNIVERSITARIO INCOMPLETO, 9 - UNIVERSITARIO COMPLETO"
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 3).ToString & ":Q" & (intFilaActual + 3).ToString).Value = "NIVEL OCUPACIONAL: 1 - EJECUTIVOS, 2 - PROFESIONALES, 3 - MANDOS MEDIOS, 4 - ADMINISTRATIVOS, 5 - TRABAJO CALIFICADO, 6 - TRABAJO SEMI CALIFICADO, 7 - TRABAJO NO CALIFICADO"

            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 5).ToString & ":Q" & (intFilaActual + 5).ToString).Value = "QUEDANDO A SU ENTERA DISPOSICION PARA ACLARAR CUALQUIER DUDA"
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 7).ToString & ":Q" & (intFilaActual + 7).ToString).Value = "SALUDA ATENTAMENTE A USTED."



            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 5).ToString & ":Q" & (intFilaActual + 5).ToString).MergeCells = True
            'xLibro.Worksheets(1).Range("A" & (intFilaActual + 7).ToString & ":Q" & (intFilaActual + 7).ToString).MergeCells = True
            xLibro.Worksheets(1).Protect(password:=Parametros.p_PASSWORDEXCEL, DrawingObjects:=True, Contents:=True, Scenarios:=True)

            xLibro.Save()
            xLibro.Close()
            quit(objExcel)

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

            mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo


        Catch ex As Exception
            EnviaError("GenerarExcel:CartaEmpresa-->" & ex.Message)
        End Try
    End Sub
    'Public Sub CartaOtec(ByVal strNombreContacto As String, ByVal strCargoContacto As String, ByVal strRazonSocial As String, _
    '                     ByVal strFax As String, ByVal strContactoAd As String, ByVal strCorrelativo As String, _
    '                     ByVal strEstadoCurso As String, ByVal strCodTipoActividad As String, ByVal strNombreEjecutivo As String, _
    '                     ByVal strFechaImp As String, ByVal dtAlumnos As System.Data.DataTable, ByVal strNombreOtic As String, _
    '                     ByVal strRazonsocOtic As String, ByVal strRutOtic As String, ByVal strDireccOtic As String, _
    '                     ByVal strRazonSocialCli As String, ByVal strRutCli As String, ByVal strDireccCli As String, _
    '                     ByVal strTnombre As String, ByVal strTcorrelativo As String, ByVal strTFechaInicio As String, _
    '                     ByVal strTFechaTermino As String, ByVal strTDuracion As String, ByVal strTHoras As String, _
    '                     ByVal strTCodSence As String, ByVal strCursoDirecc As String, ByVal strNroDireccionCurso As String, _
    '                     ByVal strComuna As String, ByVal strNumRegistro As String, ByVal strTEmpresa As String, _
    '                     ByVal strTRutEmpresa As String, ByVal strObservacion As String, ByVal strTDescuento As String, _
    '                     ByVal strTParticipantes As String, ByVal strTValorFinal As String, ByVal strRutEmpresa As String, _
    '                     ByVal strDireccionEmpresa As String, ByVal strNroDireccionEmpresa As String, ByVal strGiroEmpresa As String, _
    '                     ByVal strFonoEmpresa As String, ByVal strFaxEmpresa As String, ByVal strTOtic As String, _
    '                     ByVal strTCostoOtic As String, ByVal strNombreEmpresa As String, ByVal strTGastoEmpresa As String, _
    '                     ByVal strTTotalValor As String, ByVal strTAgno As String, ByVal strTCostoOticCompl As String, _
    '                     ByVal strAgno As String, ByVal dtHorario As System.Data.DataTable, ByVal strDireccionOtic As String, _
    '                     ByVal strOtic2 As String, ByVal strDireccClie As String, ByVal strComunaClie As String, _
    '                     ByVal strOtic As String)

    '    Dim nombreArchivo As String = NombreArchivoTmp(".xls") '    "CartaEmpresa.xls"
    '    Dim archivo As String = Ruta & "\contenido\tmp\" & nombreArchivo
    '    Try

    '        If System.IO.File.Exists(Parametros.p_DIRFISICO & archivo) Then
    '            System.IO.File.Delete(Parametros.p_DIRFISICO & archivo)
    '        End If
    '        System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\PlantillaExcel\CartaOtec.xls", Parametros.p_DIRFISICO & archivo)
    '        'Una variable de tipo Libro de Excel   
    '        Dim xLibro As Workbook
    '        'creamos un nuevo objeto excel   
    '        Dim objExcel = New Microsoft.Office.Interop.Excel.Application
    '        'Usamos el método open para abrir el archivo que está _   
    '        ' en el directorio del programa llamado archivo.xls   
    '        xLibro = objExcel.Workbooks.Open(Parametros.p_DIRFISICO & archivo)

    '        Dim intCol, intRow As Integer
    '        Dim intFilaActual As Integer
    '        Dim i As Integer

    '        xLibro.Worksheets(1).Range("B5").value = strRazonSocial
    '        xLibro.Worksheets(1).Range("C6").value = strFax
    '        xLibro.Worksheets(1).Range("I6").value = strCorrelativo
    '        xLibro.Worksheets(1).Range("H7").value = Now.Date



    '        intFilaActual = 15
    '        If dtAlumnos.Rows.Count > 0 Then
    '            For i = 0 To dtAlumnos.Rows.Count - 1
    '                xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual)).Value = RutLngAUsr(dtAlumnos.Rows.Item(i)("rut_alumno"))
    '                xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("nombre_completo")
    '                xLibro.Worksheets("carta").Range("G" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("porc_franquicia")
    '                xLibro.Worksheets("carta").Range("H" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("costo_otic")
    '                xLibro.Worksheets("carta").Range("I" & CStr(intFilaActual)).Value = dtAlumnos.Rows.Item(i)("gasto_empresa")
    '                xLibro.Worksheets("carta").Rows(intFilaActual + 1).EntireRow.Insert()
    '                intFilaActual = intFilaActual + 1

    '            Next
    '        End If

    '        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 3)).Value = "A continuación se presentan los datos relacionados " _
    '        & "con el curso que deberán ser incluídos obligatoriamente en la glosa de la factura a emitir por su OTEC. " _
    '        & "Una vez finalizado el curso deberá emitir una factura correspondiente al monto especificado a nombre de " & Parametros.p_EMPRESA _
    '        & " R.U.T. N° " & Parametros.p_RUTEMPRESA & ", " & Parametros.p_DIRECIONEMPRESA & "."


    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 8)).Value = strTnombre
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 9)).Value = strTcorrelativo
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 10)).Value = strTFechaInicio
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 11)).Value = strTFechaTermino
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 12)).Value = strTDuracion & " hrs. " & " (" & strTHoras & " hrs. complementarias)"
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 13)).Value = strTCodSence
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 14)).Value = strTEmpresa
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 15)).Value = strTRutEmpresa
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 16)).Value = strCursoDirecc & " " & strNroDireccionEmpresa & ", " & strComuna
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 17)).Value = strNumRegistro

    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 19)).Value = strTDescuento
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 20)).Value = strTParticipantes
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 21)).Value = strTValorFinal

    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 23)).Value = strTCostoOtic
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 24)).Value = strTGastoEmpresa
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 25)).Value = strTTotalValor
    '        xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual + 26)).Value = strTCostoOticCompl

    '        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 28)).Value = "* El Monto del costo complementario estimado debe ser facturado el año " & strAgno

    '        If dtHorario.Rows.Count > 0 Then
    '            intFilaActual = intFilaActual + 32
    '            For i = 0 To dtHorario.Rows.Count - 1
    '                If dtHorario.Rows.Item(i)("Dia") = 1 Then
    '                    xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 2 Then
    '                    xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("C" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 3 Then
    '                    xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("D" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 4 Then
    '                    xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("E" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 5 Then
    '                    xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("F" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 6 Then
    '                    xLibro.Worksheets("carta").Range("G" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("G" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '                End If
    '                If dtHorario.Rows.Item(i)("Dia") = 7 Then
    '                    xLibro.Worksheets("carta").Range("I" & CStr(intFilaActual)).Value = xLibro.Worksheets("carta").Range("I" & CStr(intFilaActual)).Value & dtHorario.Rows.Item(i)("HoraInicio") & "-" & dtHorario.Rows.Item(i)("HoraFin") & "; "
    '                End If
    '                'xLibro.Worksheets("carta").Rows(intFilaActual + 1).EntireRow.Insert()
    '                'intFilaActual = intFilaActual + 1
    '            Next
    '        End If

    '        '
    '        xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 19)).Value = "7° LAS FACTURAS COSTO OTIC (VALOR SENCE) DEBEN ENVIARSE A MIRAFLORES " _
    '                                                                        & " 130 PISO 17 - OF.1701, SANTIAGO (DIRECCIÓN OTIC CHILE - CORPORACIÓN DE LA BANCA), " _
    '                                                                        & "ADJUNTANDO COPIA DE ESTA ORDEN DE COMPRA. LAS FACTURAS DE GASTO EMPRESA DEBEN ENVIARSE " _
    '                                                                        & "DIRECTAMENTE A LA DIRECCIÓN DE LA EMPRESA: " & strDireccionEmpresa & ", CON " _
    '                                                                        & "FOTOCOPIA AL OTIC AL MOMENTO DE ENTREGAR LA FACTURA DEL VALOR FRANQUICIADO."

    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 23)).Value = Parametros.p_NOMBREOC
    '        'xLibro.Worksheets("carta").Range("B" & CStr(intFilaActual + 24)).Value = Parametros.p_CARGOOC

    '        xLibro.Save()
    '        xLibro.Close()

    '        quit(objExcel)

    '        mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

    '        mstrRutaArchivoVirtual = "\contenido\tmp\" & nombreArchivo


    '    Catch ex As Exception
    '        EnviaError("GenerarExcel:CartaOtec-->" & ex.Message)
    '    End Try
    'End Sub
    Public Sub CartaOtec(ByVal strNombreContacto As String, ByVal strCargoContacto As String, ByVal strRazonSocial As String, _
                         ByVal strFax As String, ByVal strContactoAd As String, ByVal strCorrelativo As String, _
                         ByVal strEstadoCurso As String, ByVal strCodTipoActividad As String, ByVal strNombreEjecutivo As String, _
                         ByVal strFechaImp As String, ByVal dtAlumnos As System.Data.DataTable, ByVal strNombreOtic As String, _
                         ByVal strRazonsocOtic As String, ByVal strRutOtic As String, ByVal strDireccOtic As String, _
                         ByVal strRazonSocialCli As String, ByVal strRutCli As String, ByVal strDireccCli As String, _
                         ByVal strTnombre As String, ByVal strTcorrelativo As String, ByVal strTFechaInicio As String, _
                         ByVal strTFechaTermino As String, ByVal strTDuracion As String, ByVal strTHoras As String, _
                         ByVal strTCodSence As String, ByVal strCursoDirecc As String, ByVal strNroDireccionCurso As String, _
                         ByVal strComuna As String, ByVal strNumRegistro As String, ByVal strTEmpresa As String, _
                         ByVal strTRutEmpresa As String, ByVal strObservacion As String, ByVal strTDescuento As String, _
                         ByVal strTParticipantes As String, ByVal strTValorFinal As String, ByVal strRutEmpresa As String, _
                         ByVal strDireccionEmpresa As String, ByVal strNroDireccionEmpresa As String, ByVal strGiroEmpresa As String, _
                         ByVal strFonoEmpresa As String, ByVal strFaxEmpresa As String, ByVal strTOtic As String, _
                         ByVal strTCostoOtic As String, ByVal strNombreEmpresa As String, ByVal strTGastoEmpresa As String, _
                         ByVal strTTotalValor As String, ByVal strTAgno As String, ByVal strTCostoOticCompl As String, _
                         ByVal strAgno As String, ByVal dtHorario As System.Data.DataTable, ByVal strDireccionOtic As String, _
                         ByVal strOtic2 As String, ByVal strDireccClie As String, ByVal strComunaClie As String, _
                         ByVal strOtic As String, ByVal lngCodCursoParcial As String, ByVal lngCodCursoCompl As String, Optional ByVal strUsuario As String = "", Optional ByVal strModalidad As String = "", _
                         Optional ByVal strComiteBipartito As String = "", Optional ByVal strFonoCliente As String = "", _
                         Optional ByVal strGiroCliente As String = "", Optional ByVal strFonoOtic As String = "", _
                         Optional ByVal strGiroOtic As String = "", Optional ByVal strValorHora As String = "", Optional ByVal strCorrelativoEmp As String = "", _
                         Optional ByVal strCorrelativoCompl As String = "")

        Dim nombreArchivo As String = NombreArchivoTmp(".xls") '    "CartaEmpresa.xls"
        Dim archivo As String = Ruta & "\contenido\tmp\" & nombreArchivo
        Try

            If System.IO.File.Exists(Parametros.p_DIRFISICO & archivo) Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & archivo)
            End If
            System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\PlantillaExcel\FORMATO_CARTA_OTEC.xls", Parametros.p_DIRFISICO & archivo)
            'Una variable de tipo Libro de Excel   
            Dim xLibro As Workbook
            'creamos un nuevo objeto excel   
            Dim objExcel = New Microsoft.Office.Interop.Excel.Application
            'Usamos el método open para abrir el archivo que está _   
            ' en el directorio del programa llamado archivo.xls   
            xLibro = objExcel.Workbooks.Open(Parametros.p_DIRFISICO & archivo)

            Dim intCol, intRow As Integer
            Dim intFilaActual As Integer
            Dim i As Integer

            If lngCodCursoParcial <> -1 Then
                xLibro.Worksheets(1).Range("A5:N5").value = "CORRELATIVO O/C " & strCorrelativo & " - COMPLEMENTARIO"
            ElseIf lngCodCursoCompl <> -1 Then
                xLibro.Worksheets(1).Range("A5:N5").value = "CORRELATIVO O/C " & strCorrelativo & " - PARCIAL"
            Else
                xLibro.Worksheets(1).Range("A5:N5").value = "CORRELATIVO O/C " & strCorrelativo
            End If


            xLibro.Worksheets(1).Range("A6:I6").value = "Sr(a). " & strRazonSocial
            xLibro.Worksheets(1).Range("A7:I7").value = "CONTACTO OTEC: " & Left(strContactoAd.ToUpper, 54)
            'xLibro.Worksheets(1).Range("B8:I8").value = Left(strRazonSocial.ToUpper, 54)
            'xLibro.Worksheets(1).Range("M6:N6").value = strCorrelativo
            xLibro.Worksheets(1).Range("M6:N6").value = strNumRegistro 'strCorrelativoEmpresa
            xLibro.Worksheets(1).Range("M7:N7").value = Left(strEstadoCurso.ToUpper, 14)
            xLibro.Worksheets(1).Range("M8:N8").value = Left(strUsuario.ToUpper, 14)
            xLibro.Worksheets(1).Range("M9:N9").value = "'" & Now.Date
            xLibro.Worksheets(1).Range("M10:N10").value = strCorrelativoEmp
            xLibro.Worksheets(1).Range("M11:N11").value = strCorrelativoCompl

            xLibro.Worksheets(1).Range("D22:I22").value = Left(strTnombre.ToUpper, 38)
            xLibro.Worksheets(1).Range("D23:I23").value = strCorrelativo '""strModalidad
            xLibro.Worksheets(1).Range("D24:I24").value = strNumRegistro 'lngCorrelativo2
            xLibro.Worksheets(1).Range("D25:I25").value = "'" & strTFechaInicio
            xLibro.Worksheets(1).Range("D26:I26").value = "'" & strTFechaTermino
            xLibro.Worksheets(1).Range("D27:I27").value = strTDuracion & " (" & strTHoras & " HRS. COMPLEMENTARIAS)"
            xLibro.Worksheets(1).Range("D28:I28").value = strTCodSence
            xLibro.Worksheets(1).Range("D29:I29").value = Left(strCursoDirecc.ToUpper & " " & strNroDireccionCurso.ToUpper, 38)
            xLibro.Worksheets(1).Range("D30:I30").value = strComuna.ToUpper
            xLibro.Worksheets(1).Range("D31:I31").value = strComiteBipartito.ToUpper
            xLibro.Worksheets(1).Range("D32:I32").value = strModalidad.ToUpper
            xLibro.Worksheets(1).Range("D33:I33").value = FormatoPeso(strValorHora)

            xLibro.Worksheets(1).Range("M22:N22").value = Replace(Replace(strTDescuento, "$", ""), "-", "0")
            xLibro.Worksheets(1).Range("M23:N23").value = Replace(strTParticipantes, "$", "")
            xLibro.Worksheets(1).Range("M24:N24").value = Replace(strTTotalValor, "$", "")
            xLibro.Worksheets(1).Range("M25:N25").value = Replace(strTCostoOtic, "$", "")
            xLibro.Worksheets(1).Range("M26:N26").value = Replace(strTGastoEmpresa, "$", "")
            'xLibro.Worksheets(1).Range("M27:N27").value = Replace(strTCostoOtic, "$", "")


            Dim strarr As Array = xLibro.Worksheets(1).Range("A18:N18").value
            xLibro.Worksheets(1).Range("A18:N18").value = Replace(strarr(1, 1), "P_EMPRESA", strRazonSocialCli.ToUpper)




            Dim Lunes As String = ""
            Dim Martes As String = ""
            Dim Miercoles As String = ""
            Dim Jueves As String = ""
            Dim Viernes As String = ""
            Dim Sabado As String = ""
            Dim Domingo As String = ""

            If dtHorario.Rows.Count > 0 Then
                For i = 0 To dtHorario.Rows.Count - 1
                    If dtHorario.Rows.Item(i)("Dia") = 1 Then
                        Lunes = Lunes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 2 Then
                        Martes = Martes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 3 Then
                        Miercoles = Miercoles & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 4 Then
                        Jueves = Jueves & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 5 Then
                        Viernes = Viernes & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 6 Then
                        Sabado = Sabado & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                    If dtHorario.Rows.Item(i)("Dia") = 7 Then
                        Domingo = Domingo & dtHorario.Rows.Item(i)("HoraInicio").ToString & "-" & dtHorario.Rows.Item(i)("HoraFin").ToString & vbCrLf
                    End If
                Next
            End If

            xLibro.Worksheets(1).Range("A37:B37").Value = Lunes
            xLibro.Worksheets(1).Range("C37:D37").Value = Martes
            xLibro.Worksheets(1).Range("E37:F37").Value = Miercoles
            xLibro.Worksheets(1).Range("G37:H37").Value = Jueves
            xLibro.Worksheets(1).Range("I37:J37").Value = Viernes
            xLibro.Worksheets(1).Range("K37:L37").Value = Sabado
            xLibro.Worksheets(1).Range("M37:N37").Value = Domingo


            xLibro.Worksheets(1).Range("E43:N43").Value = Left(strRazonsocOtic, 71)
            xLibro.Worksheets(1).Range("E44:N44").Value = strRutOtic
            xLibro.Worksheets(1).Range("E45:N45").Value = Left(strDireccOtic, 71)
            xLibro.Worksheets(1).Range("E46:N46").Value = Left(Parametros.p_GIROEMPRESA.ToUpper, 71)
            xLibro.Worksheets(1).Range("E47:N47").Value = strFonoOtic
            xLibro.Worksheets(1).Range("E48:G48").Value = Replace(Replace(strTCostoOtic, "$", ""), "-", "0")
            xLibro.Worksheets(1).Range("E49:G49").Value = Replace(Replace(strTCostoOticCompl, "$", ""), "-", "0")

            xLibro.Worksheets(1).Range("A49:D49").Value = "* COSTO OTIC COMPLEMENTARIO "
            xLibro.Worksheets(1).Range("A50:N50").Value = "* EL COSTO COMPLEMENTARIO ESTIMADO DEBE SER FACTURADO EL AÑO " & CInt(Right(strTFechaInicio, 4)) + 1


            xLibro.Worksheets(1).Range("E53:N53").Value = Left(strTEmpresa.ToUpper, 71)
            xLibro.Worksheets(1).Range("E54:N54").Value = strTRutEmpresa.ToUpper
            xLibro.Worksheets(1).Range("E55:N55").Value = Left(strDireccionEmpresa.ToUpper & " " & strNroDireccionEmpresa.ToUpper, 71)
            xLibro.Worksheets(1).Range("E56:N56").Value = Left(strGiroCliente.ToUpper, 71)
            xLibro.Worksheets(1).Range("E57:N57").Value = strFonoEmpresa
            xLibro.Worksheets(1).Range("E58:G58").Value = Replace(Replace(strTGastoEmpresa, "$", ""), "-", "0")
            xLibro.Worksheets(1).Range("E59:G59").Value = "0" ' Replace(Replace(strCostoOticCompl, "$", ""), "-", "0")

            xLibro.Worksheets(1).Range("A59:D59").Value = "* COSTO OTIC COMPLEMENTARIO "
            xLibro.Worksheets(1).Range("A60:N60").Value = "* EL COSTO COMPLEMENTARIO ESTIMADO DEBE SER FACTURADO EL AÑO " & CInt(Right(strTFechaInicio, 4)) + 1




            intFilaActual = 16
            If dtAlumnos.Rows.Count > 0 Then
                For i = 0 To dtAlumnos.Rows.Count - 1

                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":B" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":B" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":B" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("C" & intFilaActual.ToString & ":H" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("C" & intFilaActual.ToString & ":H" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("I" & intFilaActual.ToString & ":J" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("I" & intFilaActual.ToString & ":J" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("K" & intFilaActual.ToString & ":L" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("K" & intFilaActual.ToString & ":L" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous


                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":B" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("C" & intFilaActual.ToString & ":H" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("I" & intFilaActual.ToString & ":J" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("K" & intFilaActual.ToString & ":L" & intFilaActual.ToString).MergeCells = True
                    xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).MergeCells = True

                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":B" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("C" & intFilaActual.ToString & ":H" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("I" & intFilaActual.ToString & ":J" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("K" & intFilaActual.ToString & ":L" & intFilaActual.ToString).WrapText = True
                    xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).WrapText = True

                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":B" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("C" & intFilaActual.ToString & ":H" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                    xLibro.Worksheets(1).Range("I" & intFilaActual.ToString & ":J" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                    xLibro.Worksheets(1).Range("K" & intFilaActual.ToString & ":L" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                    xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight


                    xLibro.Worksheets(1).Range("A" & intFilaActual.ToString & ":B" & intFilaActual.ToString).Value = RutLngAUsr(dtAlumnos.Rows.Item(i)("rut_alumno"))
                    xLibro.Worksheets(1).Range("C" & intFilaActual.ToString & ":H" & intFilaActual.ToString).Value = Left(dtAlumnos.Rows.Item(i)("nombre_completo"), 40)
                    xLibro.Worksheets(1).Range("I" & intFilaActual.ToString & ":J" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("porc_franquicia")
                    xLibro.Worksheets(1).Range("K" & intFilaActual.ToString & ":L" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("costo_otic")
                    xLibro.Worksheets(1).Range("M" & intFilaActual.ToString & ":N" & intFilaActual.ToString).Value = dtAlumnos.Rows.Item(i)("gasto_empresa")
                    xLibro.Worksheets(1).Rows(intFilaActual + 1).EntireRow.Insert()
                    intFilaActual = intFilaActual + 1

                Next
            End If





            xLibro.Worksheets(1).Protect(password:=Parametros.p_PASSWORDEXCEL, DrawingObjects:=True, Contents:=True, Scenarios:=True)

            xLibro.Save()
            xLibro.Close()

            quit(objExcel)

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

            mstrRutaArchivoVirtual = "\contenido\tmp\" & nombreArchivo


        Catch ex As Exception
            EnviaError("GenerarExcel:CartaOtec-->" & ex.Message)
        End Try
    End Sub

    Public Sub CartolaCliente(ByVal APEcapacitacion As String, ByVal APErepato As String, ByVal APEadministracion As String, ByVal APETotal As String, ByVal FHfranquicia As String, _
                            ByVal FHsaldo1fecha As String, ByVal FHPorcfranq As String, ByVal AEaportes As String, ByVal AEadministracion As String, _
                            ByVal AEtotal As String, ByVal GEcapacitacion As String, ByVal GEexCapacitacion As String, ByVal GEterceros As String, _
                            ByVal GEtotal As String, ByVal CCabonosXaportes As String, ByVal CCcursosPropios As String, ByVal CCvtCursosPropios As String, _
                            ByVal CCvtDisponible As String, ByVal CCsaldo As String, ByVal CCEcostoOtic As String, ByVal CCEgastoEmpresa As String, _
                            ByVal CCEsaldoExcedentes As String, ByVal CCEagnoSig1 As String, ByVal CCEagnoSig2 As String, ByVal CRabonosXaporte As String, _
                            ByVal CRcursosTerceros As String, ByVal CRsaldo As String, ByVal CIcantCursosInternos As String, ByVal CItotalCursosInternos As String, _
                            ByVal CantidadAlumnosInternos As String, ByVal CantidadAlumnosInternosSR As String, ByVal EPcantCursos As String, ByVal EPalumnosCapacitados As String, _
                            ByVal EPalumnosCapacitadosSR As String, ByVal EPalumnosCapacitadosPresencial As String, ByVal EPalumnosCapacitadosElearning As String, _
                            ByVal EPalumnosCapacitadosAutoIntruccion As String, ByVal EPalumnosCapacitadosAdistancia As String, ByVal EPhhCapacitacion As String, _
                            ByVal EPhhParticipantes As String, ByVal EPhhPresenciales As String, ByVal EPhhElearning As String, ByVal EPhhAutoInduccion As String, _
                            ByVal EPhhAdistancia As String, ByVal CECAPabonoXsaldo As String, ByVal CECAPsumCursosPropios As String, ByVal CECAPvtCursosPropios As String, _
                            ByVal CECAPvtDisponible As String, ByVal CECAPsumSaldos As String, ByVal CERsumAbonoXsaldo As String, ByVal CERsumCursosTerceros As String, _
                            ByVal CERvtDisponible As String, ByVal CERsumSaldos As String, ByVal CBCabonosXsaldo As String, ByVal PorTra As String, _
                            ByVal CBCdisponible As String, ByVal CBCabonosXmandato As String, ByVal FOaportefinanciamientoOtic As String, ByVal agno As Integer, _
                            ByVal RutEmpresa As String, ByVal RazonSocial As String, ByVal DataDireccion As String, ByVal DataFono As String, _
                            ByVal TasaAdmin As String, ByVal DataNombreEjecutivo As String, ByVal DataFonoEjecutivo As String, ByVal EmailEjecutivo As String, _
                            ByVal EPcantCursosAnulados As String, ByVal EPcantCursosEliminados As String, ByVal CRRecibido As String, ByVal CERRecibido As String)


        Dim nombreArchivo As String = NombreArchivoTmp(".xls") '    "CartaEmpresa.xls"
        Dim archivo As String = Ruta & "\contenido\tmp\" & nombreArchivo
        Try

            If System.IO.File.Exists(Parametros.p_DIRFISICO & archivo) Then
                System.IO.File.Delete(Parametros.p_DIRFISICO & archivo)
            End If
            System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\PlantillaExcel\CARTOLA_CLIENTE.xls", Parametros.p_DIRFISICO & archivo)
            'Una variable de tipo Libro de Excel   
            Dim xLibro As Workbook
            'creamos un nuevo objeto excel   
            Dim objExcel = New Microsoft.Office.Interop.Excel.Application
            'Usamos el método open para abrir el archivo que está _   
            ' en el directorio del programa llamado archivo.xls   
            xLibro = objExcel.Workbooks.Open(Parametros.p_DIRFISICO & archivo)

            'CABECERA EMPRESA
            xLibro.Worksheets(1).Range("E3:G3").value = RazonSocial.ToUpper
            xLibro.Worksheets(1).Range("E4:G4").value = "RUT: " & RutEmpresa.ToUpper
            xLibro.Worksheets(1).Range("E5:G5").value = "DIRECCIÓN: " & DataDireccion.ToUpper
            xLibro.Worksheets(1).Range("E6:G6").value = "FONO: " & DataFono.ToUpper
            xLibro.Worksheets(1).Range("E7:G7").value = "TASA ADM. : " & TasaAdmin & "%"

            xLibro.Worksheets(1).Range("G2:G2").value = Now.Date
            xLibro.Worksheets(1).Range("A6:A6").value = "EJECUTIVO: " & DataNombreEjecutivo.ToUpper
            xLibro.Worksheets(1).Range("A7:A7").value = "EMAIL : " & EmailEjecutivo.ToUpper
            xLibro.Worksheets(1).Range("A8:A8").value = "FONO: " & DataFonoEjecutivo.ToUpper




            xLibro.Worksheets(1).Range("A9:G9").value = "FRANQUICIA DEL PERÍODO " & agno

            'APORTES POR ENTERAR (DEUDA TOTAL)
            xLibro.Worksheets(1).Range("C11:C11").value = APEcapacitacion
            xLibro.Worksheets(1).Range("C12:C12").value = APErepato
            xLibro.Worksheets(1).Range("C13:C13").value = APEadministracion
            xLibro.Worksheets(1).Range("C14:C14").value = APETotal

            'FRANQUICIA HISTORICA
            xLibro.Worksheets(1).Range("G11:G11").value = FHfranquicia
            xLibro.Worksheets(1).Range("E12:E12").value = "SALDO 1% A LA FECHA (" & FHPorcfranq & ")"
            xLibro.Worksheets(1).Range("G12:G12").value = FHsaldo1fecha

            'APORTES ENTERADOS
            xLibro.Worksheets(1).Range("C16:C16").value = AEaportes
            xLibro.Worksheets(1).Range("C17:C17").value = AEadministracion
            xLibro.Worksheets(1).Range("C18:C18").value = AEtotal

            'GASTO EMPRESA
            xLibro.Worksheets(1).Range("G16:G16").value = GEcapacitacion
            xLibro.Worksheets(1).Range("G17:G17").value = GEexCapacitacion
            xLibro.Worksheets(1).Range("G18:G18").value = GEterceros
            xLibro.Worksheets(1).Range("G19:G19").value = GEtotal

            'CUENTA DE CAPACITACION
            xLibro.Worksheets(1).Range("C21:C21").value = CCabonosXaportes
            xLibro.Worksheets(1).Range("C22:C22").value = CCcursosPropios
            xLibro.Worksheets(1).Range("C23:C23").value = "[" & CCvtCursosPropios & "]"
            xLibro.Worksheets(1).Range("C24:C24").value = CCvtDisponible
            xLibro.Worksheets(1).Range("C25:C25").value = CCsaldo

            'COSTO COMPLEMENTARIO ESTIMADO
            xLibro.Worksheets(1).Range("E21:E21").value = "COSTO OTIC " & CCEagnoSig1
            xLibro.Worksheets(1).Range("E22:E22").value = "GASTO EMPRESA " & CCEagnoSig2
            xLibro.Worksheets(1).Range("G21:G21").value = CCEcostoOtic
            xLibro.Worksheets(1).Range("G22:G22").value = CCEgastoEmpresa

            'CUENTA DE REPARTO
            xLibro.Worksheets(1).Range("C27:C27").value = CRabonosXaporte
            xLibro.Worksheets(1).Range("C28:C28").value = CRcursosTerceros
            xLibro.Worksheets(1).Range("C29:C29").value = CRsaldo
            xLibro.Worksheets(1).Range("C30:C30").value = CRRecibido

            'CURSOS NO SENCE
            xLibro.Worksheets(1).Range("C35:C35").value = CIcantCursosInternos
            xLibro.Worksheets(1).Range("C36:C36").value = CItotalCursosInternos
            xLibro.Worksheets(1).Range("C37:C37").value = CantidadAlumnosInternos
            xLibro.Worksheets(1).Range("C38:C38").value = CantidadAlumnosInternosSR

            'ESTADISTICASDEL PERIODO

            xLibro.Worksheets(1).Range("G27:G27").value = EPcantCursos
            xLibro.Worksheets(1).Range("G28:G28").value = EPcantCursosAnulados
            xLibro.Worksheets(1).Range("G29:G29").value = EPcantCursosEliminados
            xLibro.Worksheets(1).Range("G30:G30").value = EPalumnosCapacitados
            xLibro.Worksheets(1).Range("G31:G31").value = EPalumnosCapacitadosSR
            xLibro.Worksheets(1).Range("G32:G32").value = EPalumnosCapacitadosPresencial
            xLibro.Worksheets(1).Range("G33:G33").value = EPalumnosCapacitadosElearning
            xLibro.Worksheets(1).Range("G34:G34").value = EPalumnosCapacitadosAutoIntruccion
            xLibro.Worksheets(1).Range("G35:G35").value = EPalumnosCapacitadosAdistancia
            xLibro.Worksheets(1).Range("G36:G36").value = EPhhCapacitacion
            xLibro.Worksheets(1).Range("G37:G37").value = EPhhParticipantes
            xLibro.Worksheets(1).Range("G38:G38").value = EPhhPresenciales & "%"
            xLibro.Worksheets(1).Range("G39:G39").value = EPhhElearning & "%"
            xLibro.Worksheets(1).Range("G40:G40").value = EPhhAutoInduccion & "%"
            xLibro.Worksheets(1).Range("G41:G41").value = EPhhAdistancia & "%"

            'CUENTA ESCEDENTES DE CAPACITACION
            xLibro.Worksheets(1).Range("C44:C44").value = CECAPabonoXsaldo
            xLibro.Worksheets(1).Range("C45:C45").value = CECAPsumCursosPropios
            xLibro.Worksheets(1).Range("C46:C46").value = "[" & CECAPvtCursosPropios & "]"
            xLibro.Worksheets(1).Range("C47:C47").value = CECAPvtDisponible
            xLibro.Worksheets(1).Range("C48:C48").value = CECAPsumSaldos

            'CUENTA DE EXCEDENTES DE REPARTO
            xLibro.Worksheets(1).Range("G44:G44").value = CERsumAbonoXsaldo
            xLibro.Worksheets(1).Range("G45:G45").value = CERsumCursosTerceros
            xLibro.Worksheets(1).Range("G46:G46").value = CERsumSaldos
            xLibro.Worksheets(1).Range("G47:G47").value = CERRecibido


            'BECAS
            xLibro.Worksheets(1).Range("C52:C52").value = CBCabonosXsaldo
            xLibro.Worksheets(1).Range("C53:C53").value = CBCabonosXmandato
            xLibro.Worksheets(1).Range("C54:C54").value = CBCdisponible

            'IMPUTACIONES ESPECIALES
            xLibro.Worksheets(1).Range("G52:G52").value = FOaportefinanciamientoOtic


            xLibro.Worksheets(1).Protect(password:=Parametros.p_PASSWORDEXCEL, DrawingObjects:=True, Contents:=True, Scenarios:=True)

            xLibro.Save()
            xLibro.Close()

            quit(objExcel)

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo

            mstrRutaArchivoVirtual = "\contenido\tmp\" & nombreArchivo


        Catch ex As Exception
            EnviaError("GenerarExcel:CartolaCliente--> " & ex.Message)
        End Try
    End Sub
    
End Class
