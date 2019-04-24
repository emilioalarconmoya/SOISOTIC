Imports Clases
Imports Modulos
Imports Clases.Web
Imports System.data
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.Image
Imports System.IO
Imports Microsoft.VisualBasic

Public Class CGeneraCartaOtec

    Private mobjCsql As CSql
    Private Ruta As String = Parametros.p_DIRFISICO
    Private mstrRutaArchivo As String
    Private mstrRutaFisica As String

    Public ReadOnly Property RutaArchivo() As String
        Get
            Return mstrRutaArchivo
        End Get
    End Property
    Public ReadOnly Property RutaFisica() As String
        Get
            Return mstrRutaFisica
        End Get
    End Property


    Public Sub CartaOtec(ByVal strNombreContacto As String, ByVal strCargoContacto As String, ByVal strRazonSocial As String, ByVal strFax As String, _
    ByVal strContactoAd As String, ByVal strCorrelativo As String, ByVal strEstadoCurso As String, ByVal strCodTipoActividad As String, _
     ByVal strNombreEjecutivo As String, ByVal strFechaImp As String, ByVal dtAlumnos As DataTable, ByVal strNombreOtic As String, _
     ByVal strRazonsocOtic As String, ByVal strRutOtic As String, ByVal strDireccOtic As String, ByVal strRazonSocialCli As String, _
      ByVal strRutCli As String, ByVal strDireccCli As String, ByVal strTnombre As String, ByVal strTcorrelativo As String, _
      ByVal strTFechaInicio As String, ByVal strTFechaTermino As String, ByVal strTDuracion As String, ByVal strTHoras As String, _
     ByVal strTCodSence As String, ByVal strCursoDirecc As String, ByVal strNroDireccionCurso As String, ByVal strComuna As String, _
    ByVal strNumRegistro As String, ByVal strTEmpresa As String, ByVal strTRutEmpresa As String, ByVal strObservacion As String, _
    ByVal strTDescuento As String, ByVal strTParticipantes As String, ByVal strTValorFinal As String, ByVal strRutEmpresa As String, _
     ByVal strDireccionEmpresa As String, ByVal strNroDireccionEmpresa As String, ByVal strGiroEmpresa As String, ByVal strFonoEmpresa As String, _
     ByVal strFaxEmpresa As String, ByVal strTOtic As String, ByVal strTCostoOtic As String, ByVal strNombreEmpresa As String, _
   ByVal strTGastoEmpresa As String, ByVal strTTotalValor As String, ByVal strTAgno As String, ByVal strTCostoOticCompl As String, _
    ByVal strAgno As String, ByVal strLunes As String, ByVal strMartes As String, ByVal strMiercoles As String, ByVal strJueves As String, _
    ByVal strViernes As String, ByVal strSabado As String, ByVal strDomingo As String, ByVal strDireccionOtic As String, _
     ByVal strOtic2 As String, ByVal strDireccClie As String, ByVal strComunaClie As String, ByVal strOtic As String, ByVal strModalidad As String, _
     ByVal strComiteBipartito As String, ByVal lngCodCursoParcial As String, ByVal lngCodCursoCompl As String, Optional ByVal strValorHora As String = "", _
     Optional ByVal strCorrelativoEmp As String = "", Optional ByVal strCorrelativoCompl As String = "")

        Dim texto As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 10.0F, 10.0F, 50.0F, 30.0F)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nombreArchivo As String = NombreArchivoTmp("pdf")
        Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
        Dim ct As ColumnText
        Dim ColorAzul = New BaseColor(0, 174, 199)
        Dim ColorGris = New BaseColor(0, 174, 199) 'BaseColor(50, 224, 249)

        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
                      FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()


            Dim logo As Image
            logo = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "\include\imagenes\css\fondos\reporte06.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            logo.ScalePercent(40.0F)
            logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
            cb.AddImage(logo)



            Dim cell As PdfPCell

            Dim table As New PdfPTable(4)
            table.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(3) As Single
            widthsFichaOtec(0) = 105
            widthsFichaOtec(1) = 175
            widthsFichaOtec(2) = 105
            widthsFichaOtec(3) = 115


            table.SetWidthPercentage(widthsFichaOtec, PageSize.A4)


            ' primera fila
            If lngCodCursoParcial <> -1 Then
                cell = New PdfPCell(New Phrase("CORRELATIVO O/C " & strCorrelativo & " - COMPLEMENTARIO", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 4
                cell.BackgroundColor = ColorAzul
                'Dim par As New Paragraph("CORRELATIVO O/C " & strCorrelativo & " - COMPLEMENTARIO", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
                'par.Alignment = Element.ALIGN_CENTER
                'cell.AddElement(par)
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table.AddCell(cell)
            ElseIf lngCodCursoCompl <> -1 Then
                cell = New PdfPCell(New Phrase("CORRELATIVO O/C " & strCorrelativo & " - PARCIAL", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 4
                cell.BackgroundColor = ColorAzul
                'Dim par As New Paragraph("CORRELATIVO O/C " & strCorrelativo & " - PARCIAL", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
                'par.Alignment = Element.ALIGN_CENTER
                'cell.AddElement(par)
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table.AddCell(cell)
            Else
                cell = New PdfPCell(New Phrase("CORRELATIVO O/C " & strCorrelativo, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
                cell.BorderWidthTop = 0.5
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                cell.Colspan = 4
                cell.BackgroundColor = ColorAzul
                'Dim par As New Paragraph("CORRELATIVO O/C " & strCorrelativo, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
                'par.Alignment = Element.ALIGN_CENTER
                'cell.AddElement(par)
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table.AddCell(cell)
            End If

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            'segunda fila


            cell = New PdfPCell(New Phrase("SRES. " & strRazonSocial.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'cell.AddElement(New Paragraph("SRES.", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("Nº REGISTRO SENCE", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Nº REGISTRO SENCE", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strNumRegistro, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strNumRegistro, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("CONTACTO OTEC: " & strContactoAd.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 2
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("            " & strRazonSocial.ToUpper, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)


            '' ''cell = New PdfPCell(New Phrase("ESTADO CURSO", FontFactory.GetFont("Arial", 7)))
            '' ''cell.BorderWidthTop = 0
            '' ''cell.BorderWidthBottom = 0
            '' ''cell.BorderWidthLeft = 0
            '' ''cell.BorderWidthRight = 0
            '' ''cell.PaddingBottom = 3
            '' ''cell.PaddingTop = 0
            ' '' ''cell.AddElement(New Paragraph("ESTADO CURSO", FontFactory.GetFont("Arial", 8)))
            '' ''table.AddCell(cell)

            '' ''cell = New PdfPCell
            '' ''cell.BorderWidthTop = 0
            '' ''cell.BorderWidthBottom = 0
            '' ''cell.BorderWidthLeft = 0
            '' ''cell.BorderWidthRight = 0.5
            '' ''cell.PaddingBottom = 3
            '' ''cell.PaddingTop = 0
            '' ''cell.AddElement(New Paragraph(strEstadoCurso.ToUpper, FontFactory.GetFont("Arial", 7)))
            '' ''table.AddCell(cell)

            cell = New PdfPCell(New Phrase("ESTADO CURSO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("TIPO ACTIVIDAD", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strEstadoCurso.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strCodTipoActividad.ToUpper, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            'tercera fila



            'cuarta fila

            'cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0.5
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            ''cell.AddElement(New Paragraph("            " & "CONTACTO OTEC", FontFactory.GetFont("Arial", 8)))
            'table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 2
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)

            'cell = New PdfPCell(New Phrase(strContactoAd.ToUpper.Trim, FontFactory.GetFont("Arial", 7)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0.5
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            ''cell.AddElement(New Paragraph(strContactoAd.ToUpper, FontFactory.GetFont("Arial", 8)))
            'table.AddCell(cell)

            cell = New PdfPCell(New Phrase("TIPO ACTIVIDAD", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("TIPO ACTIVIDAD", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strCodTipoActividad.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strCodTipoActividad.ToUpper, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("RESPONSABLE OTIC", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("RESPONSABLE OTIC", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strNombreEjecutivo.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strNombreEjecutivo.ToUpper, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            'quinta fila

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("FECHA", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("FECHA", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strFechaImp, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strFechaImp, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            'sexta fila

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("CORRELATIVO EMP.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("FECHA", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strCorrelativoEmp, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strFechaImp, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            '******
            'sexta fila

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("CORRELATIVO COMPL.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("FECHA", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(strCorrelativoCompl, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strFechaImp, FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            'septima fila

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            table.AddCell(cell)


            oDoc.Add(table)


            Dim tableAlumnos As New PdfPTable(5)
            tableAlumnos.TotalWidth = PageSize.A4.Width
            Dim widthsTablaAlumnos(4) As Single
            widthsTablaAlumnos(0) = 80
            widthsTablaAlumnos(1) = 180
            widthsTablaAlumnos(2) = 80
            widthsTablaAlumnos(3) = 80
            widthsTablaAlumnos(4) = 80

            tableAlumnos.SetWidthPercentage(widthsTablaAlumnos, PageSize.A4)

            Dim dr As DataRow

            Dim parrafo14 As String = "DE NUESTRA CONSIDERACION:" & vbCr & "A TRAVES DE LA PRESENTE, SOLICITO A USTED INSCRIBIR " _
                                   & "LA SIGUIENTE NOMINA DE ALUMNOS EN EL CURSO QUE SE DETALLA A CONTINUACION SEGUN LO ORDENADO POR NUESTRO CLIENTE"
            cell = New PdfPCell(New Phrase(parrafo14, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 5
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableAlumnos.AddCell(cell)

            'encabezado
            cell = New PdfPCell(New Phrase("LISTADO DE ALUMNOS", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 5
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim listado_alumno As New Paragraph("LISTADO DE ALUMNOS", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'listado_alumno.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(listado_alumno)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            'nombre columnas

            cell = New PdfPCell(New Phrase("RUT", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            'Dim rut As New Paragraph("RUT", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'rut.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(rut)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            'Dim nombre As New Paragraph("NOMBRE", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'nombre.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(nombre)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("FRANQUICIA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            'Dim franquicia As New Paragraph("FRANQUICIA", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'franquicia.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(franquicia)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO OTIC", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            'Dim costo_otic As New Paragraph("COSTO OTIC", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'costo_otic.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(costo_otic)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            cell = New PdfPCell(New Phrase("GASTO EMPRESA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            'Dim gasto_empresa As New Paragraph("GASTO EMPRESA", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'gasto_empresa.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(gasto_empresa)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableAlumnos.AddCell(cell)

            'datos alumnos

            For Each dr In dtAlumnos.Rows

                cell = New PdfPCell(New Phrase(RutLngAUsr(dr("rut_alumno")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                'Dim RUT_ALUMNO As New Paragraph(RutLngAUsr(dr("rut_alumno")), FontFactory.GetFont("Arial", 8))
                'RUT_ALUMNO.Alignment = Element.ALIGN_LEFT
                'cell.AddElement(RUT_ALUMNO)
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("nombre_completo").ToString.ToUpper, FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                'Dim NOMBRE_COMPLETO As New Paragraph(dr("nombre_completo").ToString.ToUpper, FontFactory.GetFont("Arial", 8))
                'NOMBRE_COMPLETO.Alignment = Element.ALIGN_LEFT
                'cell.AddElement(NOMBRE_COMPLETO)
                cell.HorizontalAlignment = Element.ALIGN_LEFT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(dr("porc_franquicia") & "%", FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                'Dim FRANQUICIA2 As New Paragraph(dr("porc_franquicia") & "%", FontFactory.GetFont("Arial", 8))
                'FRANQUICIA2.Alignment = Element.ALIGN_RIGHT
                'cell.AddElement(FRANQUICIA2)
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(dr("costo_otic")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                'Dim COSTO_OTIC_PART As New Paragraph(FormatoPeso(dr("costo_otic")), FontFactory.GetFont("Arial", 8))
                'COSTO_OTIC_PART.Alignment = Element.ALIGN_RIGHT
                'cell.AddElement(COSTO_OTIC_PART)
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)

                cell = New PdfPCell(New Phrase(FormatoPeso(dr("gasto_empresa")), FontFactory.GetFont("Arial", 7)))
                cell.BorderWidthTop = 0
                cell.BorderWidthBottom = 0.5
                cell.BorderWidthLeft = 0.5
                cell.BorderWidthRight = 0.5
                cell.PaddingBottom = 3
                cell.PaddingTop = 0
                'Dim GASTO_EMPRESA_PART As New Paragraph(FormatoPeso(dr("gasto_empresa")), FontFactory.GetFont("Arial", 8))
                'GASTO_EMPRESA_PART.Alignment = Element.ALIGN_RIGHT
                'cell.AddElement(GASTO_EMPRESA_PART)
                cell.HorizontalAlignment = Element.ALIGN_RIGHT
                tableAlumnos.AddCell(cell)


            Next


            oDoc.Add(tableAlumnos)



            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            Dim tableDatosCurso As New PdfPTable(4)
            tableDatosCurso.TotalWidth = PageSize.A4.Width
            Dim widthsDatosCurso(3) As Single
            widthsDatosCurso(0) = 95
            widthsDatosCurso(1) = 220
            widthsDatosCurso(2) = 125
            widthsDatosCurso(3) = 60

            tableDatosCurso.SetWidthPercentage(widthsDatosCurso, PageSize.A4)
            tableDatosCurso.SplitRows = True
            Dim drPlan As DataRow



            Dim parrafo13A As New Chunk("A CONTINUACION SE PRESENTAN LOS DATOS RELACIONADOS CON EL CURSO QUE DEBERAN SER INCLUIDOS " _
            & "OBLIGATORIAMENTE EN LA GLOSA DE LA FACTURA. UNA VEZ FINALIZADO EL CURSO DEBERA EMITIR UNA FACTURA CORRESPONDIENTE AL MONTO " _
            & "ESPECIFICADO EN LA LINEA 'FACTURACION " & Parametros.p_EMPRESA.ToUpper & "'" _
            & "DE LA SIGUIENTE TABLA, DEL PERIODO RESPECTIVO, A NOMBRE DE ", FontFactory.GetFont("Arial", 7))
            Dim parrafo13B As New Chunk(Parametros.p_NOMBREEMPRESALARGO.ToUpper & ", R.U.T. N° " & Parametros.p_RUTEMPRESA & ", " & Parametros.p_DIRECIONEMPRESA.ToUpper & ". ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim parrafo13C As New Chunk("POR OTRO LADO, DEBERA EMITIR FACTURA A NOMBRE DE ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim parrafo13d As New Chunk(strRazonSocialCli.ToUpper, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim parrafo13e As New Chunk(", POR EL MONTO ESPECIFICADO EN LA LINEA 'FACTURACION EMPRESA' DE LA SIGUIENTE TABLA.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))


            Dim fraseAcont As New Phrase()
            fraseAcont.Add(parrafo13A)
            fraseAcont.Add(parrafo13B)
            fraseAcont.Add(parrafo13C)
            fraseAcont.Add(parrafo13d)
            fraseAcont.Add(parrafo13e)


            cell = New PdfPCell(fraseAcont)
            cell.Colspan = 4
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim encabezado2 As New Paragraph(parrafo13.ToUpper, FontFactory.GetFont("Arial", 8))
            'encabezado2.Alignment = Element.ALIGN_JUSTIFIED
            'cell.AddElement(encabezado2)
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.FixedHeight = 5
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            'encabezado tabla

            cell = New PdfPCell(New Phrase("FACTURACION CURSO", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim curso_inscrito As New Paragraph("FACTURACION CURSO", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'curso_inscrito.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(curso_inscrito)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("DATOS DEL CURSO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 2
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim datos_curso As New Paragraph("DATOS DEL CURSO", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'datos_curso.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(datos_curso)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("VALORES ASOCIADOS", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 2
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim valores_asociados As New Paragraph("VALORES ASOCIADOS", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'valores_asociados.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(valores_asociados)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableDatosCurso.AddCell(cell)

            'pripera fila

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("NOMBRE", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTnombre.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strTnombre.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("DESCUENTO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("DESCUENTO", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTDescuento, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim DESCUENTO As New Paragraph(strTDescuento, FontFactory.GetFont("Arial", 8))
            'DESCUENTO.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(DESCUENTO)
            'cell.Right.ToString()
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableDatosCurso.AddCell(cell)

            ' segunda fila

            cell = New PdfPCell(New Phrase("CORRELATIVO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("CORRELATIVO", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTcorrelativo, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strTcorrelativo, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("PARTICIPANTES", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("PARTICIPANTES", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTParticipantes, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim PARTICIPANTES As New Paragraph(strTParticipantes, FontFactory.GetFont("Arial", 8))
            'PARTICIPANTES.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(PARTICIPANTES)
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableDatosCurso.AddCell(cell)

            ' 3 fila

            cell = New PdfPCell(New Phrase("Nº REGISTRO SENCE", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("Nº REGISTRO SENCE", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strNumRegistro, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strNumRegistro, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            tableDatosCurso.AddCell(cell)


            cell = New PdfPCell(New Phrase("VALOR TOTAL", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("VALOR FINAL", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTTotalValor, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim VALOR_FINAL As New Paragraph(strTValorFinal, FontFactory.GetFont("Arial", 8))
            'VALOR_FINAL.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(VALOR_FINAL)
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableDatosCurso.AddCell(cell)


            cell = New PdfPCell(New Phrase("FECHA INICIO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("FECHA INICIO", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTFechaInicio, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strTFechaInicio, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)


            '4 fila
            cell = New PdfPCell(New Phrase("COSTO OTIC COMPLEMENTARIO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("COSTO OTIC " & strTAgno, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTCostoOticCompl, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim COSTO_OTIC_COMPL As New Paragraph(strTCostoOticCompl, FontFactory.GetFont("Arial", 8))
            'COSTO_OTIC_COMPL.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(COSTO_OTIC_COMPL)
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableDatosCurso.AddCell(cell)


            cell = New PdfPCell(New Phrase("FECHA TERMINO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("FECHA TERMINO", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTFechaTermino, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strTFechaTermino, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO EMPRESA", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("COSTO EMPRESA", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTGastoEmpresa, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim GASTO_EMPRESA2 As New Paragraph(strTGastoEmpresa, FontFactory.GetFont("Arial", 8))
            'GASTO_EMPRESA2.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(GASTO_EMPRESA2)
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableDatosCurso.AddCell(cell)

            '5 fila

            cell = New PdfPCell(New Phrase("DURACION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("DURACION", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTDuracion & " (" & strTHoras & " HRS. COMPLEMENTARIAS)", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strTDuracion & " (" & strTHoras & " HRS. COMPLEMENTARIAS)", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO OTIC", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("COSTO OTIC", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTCostoOtic, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim COSTO_OTIC1 As New Paragraph(strTCostoOtic, FontFactory.GetFont("Arial", 8))
            'COSTO_OTIC1.Alignment = Element.ALIGN_RIGHT
            'cell.AddElement(COSTO_OTIC1)
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableDatosCurso.AddCell(cell)
            '6 fila

            cell = New PdfPCell(New Phrase("CODIGO SENCE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("CODIGO SENCE", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTCodSence, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strTCodSence, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.Colspan = 2
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            '7 fila
            cell = New PdfPCell(New Phrase("LUGAR DE EJECUCION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("LUGAR DE EJECUCION", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strCursoDirecc.ToUpper & " " & strNroDireccionCurso.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strCursoDirecc.ToUpper & " " & strNroDireccionCurso.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)


            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.Colspan = 2
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            '8 fila

            cell = New PdfPCell(New Phrase("COMUNA ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("COMUNA ", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strComuna.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strComuna.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.Colspan = 2
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            '9 fila

            cell = New PdfPCell(New Phrase("COMITE BIPARTITO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("COMITE BIPARTITO", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strComiteBipartito.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strComiteBipartito.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.Colspan = 2
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            '10 fila

            cell = New PdfPCell(New Phrase("RUT EMPRESA", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("RUT EMPRESA", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTRutEmpresa.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strTRutEmpresa.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.Colspan = 2
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            '11 fila

            cell = New PdfPCell(New Phrase("MODALIDAD", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("MODALIDAD", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)


            cell = New PdfPCell(New Phrase(strModalidad.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColorBottom = iTextSharp.text.BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph(strModalidad.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)



            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.Colspan = 2
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)

            'fila  12

            cell = New PdfPCell(New Phrase("VALOR HORA SENCE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("MODALIDAD", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)


            cell = New PdfPCell(New Phrase(FormatoPeso(CLng(strValorHora)), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.BorderColorBottom = iTextSharp.text.BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph(strModalidad.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)



            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.Colspan = 2
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableDatosCurso.AddCell(cell)


            oDoc.Add(tableDatosCurso)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea


            Dim tableHorario As New PdfPTable(7)
            tableHorario.TotalWidth = PageSize.A4.Width
            Dim widthshorario(6) As Single
            widthshorario(0) = 72
            widthshorario(1) = 72
            widthshorario(2) = 72
            widthshorario(3) = 72
            widthshorario(4) = 72
            widthshorario(5) = 72
            widthshorario(6) = 72
            tableHorario.SetWidthPercentage(widthshorario, PageSize.A4)
            tableHorario.SplitRows = True

            'cabecera
            cell = New PdfPCell(New Phrase("HORARIO", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 7
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim horario As New Paragraph("HORARIO", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'horario.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(horario)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            'cabecera
            cell = New PdfPCell(New Phrase("LUNES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim lunes As New Paragraph("LUNES", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'lunes.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(lunes)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("MARTES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim martes As New Paragraph("MARTES", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'martes.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(martes)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("MIERCOLES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim miercoles As New Paragraph("MIERCOLES", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'miercoles.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(miercoles)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("JUEVES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim jueves As New Paragraph("JUEVES", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'jueves.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(jueves)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("VIERNES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris ' iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim viernes As New Paragraph("VIERNES", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'viernes.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(viernes)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("SABADO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim sabado As New Paragraph("SABADO", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'sabado.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(sabado)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("DOMINGO", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim domingo As New Paragraph("DOMINGO", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'domingo.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(domingo)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            ' primera fila

            cell = New PdfPCell(New Phrase(Replace(strLunes, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Replace(strLunes, "<br>", vbCr), FontFactory.GetFont("Arial", 8)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strMartes, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Replace(strMartes, "<br>", vbCr), FontFactory.GetFont("Arial", 8)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strMiercoles, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Replace(strMiercoles, "<br>", vbCr), FontFactory.GetFont("Arial", 8)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strJueves, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Replace(strJueves, "<br>", vbCr), FontFactory.GetFont("Arial", 8)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strViernes, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Replace(strViernes, "<br>", vbCr), FontFactory.GetFont("Arial", 8)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strSabado, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Replace(strSabado, "<br>", vbCr), FontFactory.GetFont("Arial", 8)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase(Replace(strDomingo, "<br>", vbCr), FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Replace(strDomingo, "<br>", vbCr), FontFactory.GetFont("Arial", 8)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableHorario.AddCell(cell)


            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 7
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BorderColorBottom = iTextSharp.text.BaseColor.LIGHT_GRAY
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)))
            tableHorario.AddCell(cell)

            cell = New PdfPCell(New Phrase("OBSERVACION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("OBSERVACION: ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)))
            tableHorario.AddCell(cell)


            cell = New PdfPCell(New Phrase(strObservacion.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 6
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strObservacion.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableHorario.AddCell(cell)

            oDoc.Add(tableHorario)


            Dim tableFacturacion As New PdfPTable(4)
            tableFacturacion.TotalWidth = PageSize.A4.Width
            Dim widthsFacturacion(3) As Single
            widthsFacturacion(0) = 150
            widthsFacturacion(1) = 350
            widthsFacturacion(2) = 0
            widthsFacturacion(3) = 0
            tableFacturacion.SetWidthPercentage(widthsFacturacion, PageSize.A4)
            tableFacturacion.SplitRows = True

            'cabecera

            cell = New PdfPCell(New Phrase("FACTURACION", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorAzul 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim facturacion As New Paragraph("FACTURACION", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'facturacion.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(facturacion)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableFacturacion.AddCell(cell)


            cell = New PdfPCell(New Phrase("OTIC DE LA BANCA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris 'iTextSharp.text.BaseColor.LIGHT_GRAY
            'Dim otic As New Paragraph("OTIC DE LA BANCA", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'otic.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(otic)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableFacturacion.AddCell(cell)

            '1 fila

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("NOMBRE", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(Parametros.p_NOMBREEMPRESALARGO.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Parametros.p_NOMBREEMPRESALARGO.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase("RUT", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("RUT", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(Parametros.p_RUTEMPRESA.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Parametros.p_RUTEMPRESA.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)


            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 2
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            '2 fila

            cell = New PdfPCell(New Phrase("DIRECCION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("DIRECCION", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(Parametros.p_DIRECIONEMPRESA.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Parametros.p_DIRECIONEMPRESA.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)


            '3fila

            cell = New PdfPCell(New Phrase("GIRO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("GIRO", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(Parametros.p_GIROEMPRESA.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Parametros.p_GIROEMPRESA.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            '4 fila

            cell = New PdfPCell(New Phrase("FONO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("FONO", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(Parametros.p_FONOEMPRESA, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(Parametros.p_FONOEMPRESA, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO " & strTOtic, FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("COSTO " & strTOtic, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTCostoOtic, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim MONTO_OTIC As New Paragraph(strTCostoOtic, FontFactory.GetFont("Arial", 8))
            'MONTO_OTIC.Alignment = Element.ALIGN_LEFT
            'cell.AddElement(MONTO_OTIC)
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase("* COSTO OTIC COMPLEMENTARIO ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("* COSTO OTIC ESTIMADO AÑO " & strTAgno, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTCostoOticCompl, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim COSTO_ESTIMADO As New Paragraph(strTCostoOticCompl, FontFactory.GetFont("Arial", 8))
            'COSTO_ESTIMADO.Alignment = Element.ALIGN_LEFT
            'cell.AddElement(COSTO_ESTIMADO)
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableFacturacion.AddCell(cell)



            cell = New PdfPCell(New Phrase("* EL COSTO COMPLEMENTARIO DEBE SER FACTURADO EL AÑO " & strTAgno, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("* EL COSTO COMPLEMENTARIO ESTIMADO DEBE SER FACTURADO EL AÑO " & strTAgno, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)


            '-------------
            cell = New PdfPCell(New Phrase("EMPRESA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.BackgroundColor = ColorGris
            'Dim empresa As New Paragraph("EMPRESA", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'empresa.Alignment = Element.ALIGN_CENTER
            'cell.AddElement(empresa)
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            tableFacturacion.AddCell(cell)

            '5 fila

            cell = New PdfPCell(New Phrase("NOMBRE", FontFactory.GetFont("Arial", 7)))
            cell.BorderColorTop = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("NOMBRE", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strNombreEmpresa.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderColorTop = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strNombreEmpresa.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 2
            cell.BorderColorTop = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase("RUT", FontFactory.GetFont("Arial", 7)))
            cell.BorderColorTop = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("RUT", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strRutEmpresa.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.BorderColorTop = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strRutEmpresa.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)



            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 2
            cell.BorderColorTop = iTextSharp.text.BaseColor.LIGHT_GRAY
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)



            ' 7 fila

            cell = New PdfPCell(New Phrase("DIRECCION", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("DIRECCION", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strDireccionEmpresa.ToUpper & " " & strNroDireccionEmpresa.ToUpper & "," & strComunaClie.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strDireccionEmpresa.ToUpper & "," & strComuna.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)


            ' 8 fila

            cell = New PdfPCell(New Phrase("GIRO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("GIRO", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strGiroEmpresa.ToUpper, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strGiroEmpresa.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)


            ' 9 fila

            cell = New PdfPCell(New Phrase("FONO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("FONO", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strFonoEmpresa, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph(strFonoEmpresa, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase("COSTO EMPRESA", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("COSTO EMPRESA", FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTGastoEmpresa, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim MONTO_EMPRESA As New Paragraph(strTGastoEmpresa, FontFactory.GetFont("Arial", 8))
            'MONTO_EMPRESA.Alignment = Element.ALIGN_LEFT
            'cell.AddElement(MONTO_EMPRESA)
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase("* COSTO OTIC COMPLEMENTARIO", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("* COSTO OTIC ESTIMADO AÑO " & strTAgno, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            cell = New PdfPCell(New Phrase(strTCostoOticCompl, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 3
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'Dim COSTO_ESTIMADO_EMPRESA As New Paragraph(strTCostoOticCompl, FontFactory.GetFont("Arial", 8))
            'COSTO_ESTIMADO.Alignment = Element.ALIGN_LEFT
            'cell.AddElement(COSTO_ESTIMADO_EMPRESA)
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            tableFacturacion.AddCell(cell)



            cell = New PdfPCell(New Phrase("* EL COSTO COMPLEMENTARIO DEBE SER FACTURADO EL AÑO " & strTAgno, FontFactory.GetFont("Arial", 7)))
            cell.Colspan = 4
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            'cell.AddElement(New Paragraph("* EL COSTO COMPLEMENTARIO ESTIMADO DEBE SER FACTURADO EL AÑO " & strTAgno, FontFactory.GetFont("Arial", 8)))
            tableFacturacion.AddCell(cell)

            oDoc.Add(tableFacturacion)


            '***********************************
            '***********************************


            '******************************************

            oDoc.Add(New Paragraph(" ")) 'Salto de linea

            Dim tableRequisitos As New PdfPTable(2)
            tableRequisitos.TotalWidth = PageSize.A4.Width
            Dim widthsRequisitos(1) As Single
            widthsRequisitos(0) = 250
            widthsRequisitos(1) = 250


            tableRequisitos.SetWidthPercentage(widthsRequisitos, PageSize.A4)
            tableRequisitos.SplitRows = True

            cell = New PdfPCell(New Phrase("REQUISITOS Y CONDICIONES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)))
            cell.BorderWidthTop = 0.5
            cell.BorderWidthBottom = 0.5
            cell.BorderWidthLeft = 0.5
            cell.BorderWidthRight = 0.5
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.BackgroundColor = ColorGris
            'Dim requisitos As New Paragraph("REQUISITOS Y CONDICIONES DE CANCELACION:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE))
            'requisitos.Alignment = Element.ALIGN_LEFT
            'cell.AddElement(requisitos)
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            tableRequisitos.AddCell(cell)



            Dim destacado1a As New Chunk("1° ES OBLIGACIÓN DEL OTEC ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal1a As New Chunk("REVISAR QUE LA OC SE ENCUENTRE CON TODOS SUS DATOS CORRECTOS ANTES DE LA FECHA DE " _
                                         & "INICIO, RECLAMOS POSTERIORES NO SERÁ RESPONSABILIDAD DEL OTIC.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase1a As New Phrase()
            frase1a.Add(destacado1a)
            frase1a.Add(normal1a)
            cell = New PdfPCell(frase1a)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)



            Dim destacado1b As New Chunk("2° ACUSAR RECIBO DE ESTA OC ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal1b As New Chunk("AL OTIC Y EMPRESA, EN SEÑAL DE CONFIRMACIÓN QUE LA INSCRIPCIÓN DE LOS PARTICIPANTES " _
                                         & "DESIGNADOS POR LA EMPRESA ESTÁ EN ORDEN.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase1b As New Phrase()
            frase1b.Add(destacado1b)
            frase1b.Add(normal1b)
            cell = New PdfPCell(frase1b)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)



            Dim destacado1 As New Chunk("3° EL CORRESPONDIENTE PAGO DE LA ACTIVIDAD, SE REALIZARA UNA VEZ QUE ESTA SE ENCUENTRE FINALIZADA, ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal1 As New Chunk("Y LOS PARTICIPANTES DEBERAN TENER REGISTRADA UNA ASISTENCIA EQUIVALENTE AL 75% DE SU DURACION TOTAL. EN CASO  " _
                                         & "CONTRARIO, EL IMPORTE CORRESPONDIENTE SERA DE CARGO DE LA EMPRESA A LA QUE PERTENECEN.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase1 As New Phrase()
            frase1.Add(destacado1)
            frase1.Add(normal1)
            cell = New PdfPCell(frase1)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)


            '''cell = New PdfPCell(New Phrase( & , FontFactory.GetFont("Arial", 7, iTextSharp.text.BaseColor.BLACK)))

            Dim normal33a As New Chunk("         -	SI HAY ALUMNOS QUE NO CUENTEN CON EL 75% DE ASISTENCIA MÍNIMA, HACER ENVÍO DEL  CORRESPONDIENTE" _
                                           & " CERTIFICADO DE ASISTENCIA Y SOLICITAR LA RECTIFICACIÓN DE LA OC INICIAL A " _
                                           , FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado33a As New Chunk(Parametros.p_EMAIL1OC, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK))

            'Dim normal33b As New Chunk(" CON COPIA A ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            'Dim destacado33b As New Chunk(Parametros.p_EMAIL2OC, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))


            Dim frase33 As New Phrase()
            frase33.Add(normal33a)
            frase33.Add(destacado33a)
            'frase33.Add(normal33b)
            'frase33.Add(destacado33b)
            cell = New PdfPCell(frase33)

            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            tableRequisitos.AddCell(cell)





            Dim requisito2 As New Paragraph()
            Dim destacado2 As New Chunk("4° SE CONSIDERARA ACTIVIDAD NO EJECUTADA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal2 As New Chunk(", SI DENTRO DE LOS ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado2b As New Chunk("10 DIAS HABILES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal2b As New Chunk(" SIGUIENTES A LA FECHA DE TERMINO DEL CURSO, NO SE HAN RECEPCIONADO LA(S) FACTURA(S) Y EL RESPECTIVO INFORME DE ASISTENCIA  Y DECLARACIONES JURADAS SI CORRESPONDEN.", _
            FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim frase2 As New Phrase()
            frase2.Add(destacado2)
            frase2.Add(normal2)
            frase2.Add(destacado2b)
            frase2.Add(normal2b)
            cell = New PdfPCell(frase2)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)




            Dim destacado3 As New Chunk("5° SERA REQUISITO INDISPENSABLE PARA LA CANCELACION DE LA FACTURA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal3 As New Chunk(", ADJUNTAR A ESTA EL INFORME DE " _
                                        & "ASISTENCIA O DECLARACION JURADA EN CASO DE CURSOS E-LEARNING O DISTANCIA, DE LOS ALUMNOS INSCRITOS EN " _
                                        & "ESTA ORDEN DE COMPRA. IMPORTANTE: EN CASO DE PARTICIPANTES QUE NO CUMPLAN CON LA ASISTENCIA MINIMA " _
                                        & "EXIGIDA POR SENCE (LEY 19.518), SE DEBERAN REBAJAR DE LA FACTURACION DEL MONTO FRANQUICIABLE (OTIC), LOS  " _
                                        & "VALORES CORRESPONDIENTES POR ESTE CONCEPTO. LA DIFERENCIA PRODUCIDA NO AFECTA A FRANQUICIA TRIBUTARIA;  " _
                                        & "DEBERA FACTURARSE A LA EMPRESA COMO GASTO.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase3 As New Phrase()
            frase3.Add(destacado3)
            frase3.Add(normal3)
            'Dim requisito3 As New Paragraph()
            'requisito3.Alignment = Element.ALIGN_JUSTIFIED
            'requisito3.Add(frase3)
            'cell.AddElement(New Paragraph(requisito3))
            cell = New PdfPCell(frase3)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("6° DATOS QUE DEBE CONTENER LA FACTURA SON LOS SIGUIENTES: ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim requisito4 As New Paragraph("4° DATOS QUE DEBE CONTENER LA FACTURA SON LOS SIGUIENTES: ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            'cell.AddElement(New Paragraph(requisito4))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	IDENTIFICACION DEL OTIC (RAZON SOCIAL Y RUT).", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_1 As String = "          -	IDENTIFICACION DEL OTIC (RAZON SOCIAL Y RUT)."
            'cell.AddElement(New Paragraph(parrafo5_1.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	NOMBRE DE LA ACTIVIDAD DE CAPACITACION.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_2 As String = "          -	NOMBRE DE LA ACTIVIDAD DE CAPACITACION."
            'cell.AddElement(New Paragraph(parrafo5_2.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	RUT Y RAZON SOCIAL DE LA EMPRESA BENEFICIARIA DE LA ACTIVIDAD.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_3 As String = "          -	RUT Y RAZON SOCIAL DE LA EMPRESA BENEFICIARIA DE LA ACTIVIDAD."
            'cell.AddElement(New Paragraph(parrafo5_3.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	CODIGO SENCE.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_4 As String = "          -	CODIGO SENCE."
            'cell.AddElement(New Paragraph(parrafo5_4.ToUpper, FontFactory.GetFont("Arial", 7)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	CANTIDAD DE HORAS CRONOLOGICAS.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	FECHAS DE INICIO Y TERMINO.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_6 As String = "          -	FECHAS DE INICIO Y TERMINO."
            'cell.AddElement(New Paragraph(parrafo5_6.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	NOMBRE Y RUT DE LOS TRABAJADORES CAPACITADOS, O EN SU DEFECTO POR RAZONES DE ESPACIO, SOLO NUMERO " _
                                                & "DE REGISTRO DE ACCION.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_7 As String = "          -	NOMBRE Y RUT DE LOS TRABAJADORES CAPACITADOS, O EN SU DEFECTO POR RAZONES DE ESPACIO, SOLO            	NUMERO " _
            '                                    & "DE REGISTRO DE ACCION."
            'cell.AddElement(New Paragraph(parrafo5_7.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("(EN EL CASO QUE SE REQUIERA MODIFICAR LA FACTURA A FIN DE CORREGIR O AGREGAR DATOS, SE DISPONDRA DE DOS  " _
                                        & "ALTERNATIVAS: ANULAR LA FACTURA CON UNA NOTA DE CREDITO, Y EMITIR OTRA FACTURA, O BIEN GESTIONAR UNA NOTA  " _
                                        & "DE CREDITO PARA AGREGAR O CORREGIR EL DATO EN CUESTION.) ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim requisito5 As New Paragraph("(EN EL CASO QUE SE REQUIERA MODIFICAR LA FACTURA A FIN DE CORREGIR O AGREGAR DATOS, SE DISPONDRA DE DOS  " _
            '                            & "ALTERNATIVAS: ANULAR LA FACTURA CON UNA NOTA DE CREDITO, Y EMITIR OTRA FACTURA, O BIEN GESTIONAR UNA NOTA  " _
            '                            & "DE CREDITO PARA AGREGAR O CORREGIR EL DATO EN CUESTION.) ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            'requisito5.Alignment = Element.ALIGN_JUSTIFIED
            'cell.AddElement(New Paragraph(requisito5))
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)





            Dim requisito6 As New Paragraph()
            Dim destacado6 As New Chunk("7° PARA LOS CURSOS E-LEARNING Y/O DISTANCIA QUE NO CUENTEN CON TODOS LOS RESPALDOS (DECLARACIONES " _
                                    & "JURADAS Y CI) DE EL O LOS PARTICIPANTES", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal6 As New Chunk(", SE LIQUIDARAN DE ACUERDO A LA DOCUMENTACION EXISTENTE Y SE SOLICITARA " _
                                    & "LA NOTA DE CREDITO PARA AJUSTAR LOS VALORES. ESTE PROCESO PUEDE DEMORAR EL PAGO DE LA FACTURA " _
                                    & "CORRESPONDIENTE.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim frase6 As New Phrase()
            frase6.Add(destacado6)
            frase6.Add(normal6)
            'requisito6.Alignment = Element.ALIGN_JUSTIFIED
            'requisito6.Add(frase6)
            'cell.AddElement(New Paragraph(requisito6))
            cell = New PdfPCell(frase6)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)





            Dim requisito7 As New Paragraph()

            Dim destacado7 As New Chunk("8° EL CERTIFICADO DE ASISTENCIA Y DECLARACIONES JURADAS ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal7 As New Chunk(" DEBE SER EN LOS FORMATOS SOLICITADOS POR SENCE Y CON SU RESPECTIVA FIRMA " _
                                    & "DIGITAL.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase7 As New Phrase()
            frase7.Add(destacado7)
            frase7.Add(normal7)

            'requisito7.Alignment = Element.ALIGN_JUSTIFIED
            'requisito7.Add(frase7)
            'cell.AddElement(New Paragraph(requisito7))
            cell = New PdfPCell(frase7)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)



            Dim requisito8 As New Paragraph()

            Dim destacado8 As New Chunk("9° POR SU PARTE LOS DATOS QUE DEBE CONTENER EL CERTIFICADO DE ASISTENCIA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal8 As New Chunk(" SON LOS ESPECIFICADOS EN EL  " _
                                    & "FORMATO SENCE (ELECTRONICO CON FIRMA DIGITAL), SALVO QUE EL SENCE DISPONGA ALGUN SISTEMA QUE PERMITA " _
                                    & "AUTOMATIZAR LA CERTIFICACION DE LA ASISTENCIA. EN EL CASO DE LOS CURSOS E-LEARNING- DISTANCIA PARA " _
                                    & "PROCEDER SE SOLICITARA DECLARACION JURADA SIMPLE DEL OTEC CUYO FORMATO ESTA DISPONIBLE " _
                                    & "EN ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado8A As New Chunk("WWW.SENCE.CL ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK))
            Dim normal8A As New Chunk("U OTRO MECANISMO QUE EL SENCE DISPONGA. ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase8 As New Phrase()
            frase8.Add(destacado8)
            frase8.Add(normal8)
            frase8.Add(destacado8A)
            frase8.Add(normal8A)

            'requisito8.Alignment = Element.ALIGN_JUSTIFIED
            'requisito8.Add(frase8)
            'cell.AddElement(New Paragraph(requisito8))
            cell = New PdfPCell(frase8)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)



            '' ''Dim requisito9 As New Paragraph()

            '' ''Dim destacado9 As New Chunk("10° PARA LOS PARTICIPANTES QUE FIGUREN SIN NOMBRE EN EL CERTIFICADO DE ASISTENCIA (LCE)", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            '' ''Dim normal9 As New Chunk(", EL OTEC EJECUTOR " _
            '' ''                        & "DEL CURSO DEBERA SOLICITAR A ACEPTA EL ENROLAMIENTO DEL O LOS ALUMNOS, ENVIANDO MEDIANTE EL FORMULARIO " _
            '' ''                        & "DE SOPORTE DEL LCE (HTTP://SOPORTESENCE.ACEPTA.COM/), UNA COPIA DE LA CEDULA DE IDENTIDAD POR AMBOS " _
            '' ''                        & "LADOS. ESTO DEBERA REALIZARSE DENTRO DE LOS PLAZOS ESTABLECIDOS PARA LA LIQUIDACION DE LOS CURSOS " _
            '' ''                        & "ACOGIDOS AL USO DE LA FRANQUICIA TRIBUTARIA.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            '' ''Dim frase9 As New Phrase()
            '' ''frase9.Add(destacado9)
            '' ''frase9.Add(normal9)

            ' '' ''requisito9.Alignment = Element.ALIGN_JUSTIFIED
            ' '' ''requisito9.Add(frase9)
            ' '' ''cell.AddElement(New Paragraph(requisito9))
            '' ''cell = New PdfPCell(frase9)
            '' ''cell.BorderWidthTop = 0
            '' ''cell.BorderWidthBottom = 0
            '' ''cell.BorderWidthLeft = 0
            '' ''cell.BorderWidthRight = 0
            '' ''cell.PaddingBottom = 3
            '' ''cell.PaddingTop = 0
            '' ''cell.Colspan = 2
            '' ''cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            '' ''tableRequisitos.AddCell(cell)

            '' ''cell = New PdfPCell(New Phrase("SI POR ALGUNA RAZON NO FUESE POSIBLE ACTUALIZAR ESTA INFORMACION DENTRO DE LOS PLAZOS DEFINIDOS, EL " _
            '' ''                        & "OTEC PODRA MODIFICAR EL CERTIFICADO DE ASISTENCIA, RETIRANDO DEL MISMO A AQUELLOS PARTICIPANTES CON " _
            '' ''                        & "INFORMACION INCOMPLETA PUDIENDO DE ESTA FORMA LIQUIDAR A LOS RESTANTES.", FontFactory.GetFont("Arial", 7)))
            '' ''cell.BorderWidthTop = 0
            '' ''cell.BorderWidthBottom = 0
            '' ''cell.BorderWidthLeft = 0
            '' ''cell.BorderWidthRight = 0
            '' ''cell.PaddingBottom = 3
            '' ''cell.PaddingTop = 0
            '' ''cell.Colspan = 2
            ' '' ''Dim requisito10 As New Paragraph("SI POR ALGUNA RAZON NO FUESE POSIBLE DE ACTUALIZAR ESTA INFORMACION DENTRO DE LOS PLAZOS DEFINIDOS, EL " _
            ' '' ''                        & "OTEC PODRA MODIFICAR EL CERTIFICADO DE ASISTENCIA, RETIRANDO DEL MISMO A AQUELLOS PARTICIPANTES CON " _
            ' '' ''                        & "INFORMACION INCOMPLETA PUDIENDO DE ESTA FORMA LIQUIDAR A LOS RESTANTES.", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            ' '' ''requisito10.Alignment = Element.ALIGN_JUSTIFIED
            ' '' ''cell.AddElement(New Paragraph(requisito10))
            '' ''cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            '' ''tableRequisitos.AddCell(cell)



            Dim requisito11 As New Paragraph()

            Dim destacado11 As New Chunk("10° LAS FACTURAS COSTO OTIC (VALOR SENCE) DEBEN ENVIARSE", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal11 As New Chunk(" AL CORREO ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado11b As New Chunk(Parametros.p_EMAIL3OC, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK))
            Dim normal11b As New Chunk(" O DIRECCION MIRAFLORES 130 PISO 17, SANTIAGO " _
                                    & "(DIRECCION OTIC DE LA BANCA), ADJUNTANDO COPIA DE ESTA ORDEN DE COMPRA. LAS FACTURAS " _
                                    & "DE COSTO EMPRESA DEBEN ENVIARSE DIRECTAMENTE A LA EMPRESA, CON COPIA AL OTIC.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase11 As New Phrase()
            frase11.Add(destacado11)
            frase11.Add(normal11)
            frase11.Add(destacado11b)
            frase11.Add(normal11b)

            'requisito11.Alignment = Element.ALIGN_JUSTIFIED
            'requisito11.Add(frase11)
            'cell.AddElement(New Paragraph(requisito11))
            cell = New PdfPCell(frase11)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)

            Dim destacado12 As New Chunk("11° NUESTRO OTIC CUENTA CON EL SELLO PRO PYME ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal12 As New Chunk("(PAGO MÁXIMO A 30 DIAS CON LA DOCUMENTACIÓN COMPLETA DEL CURSO),  " _
                                    & "(VER INSTRUCTIVO EN NUESTRA PAGINA WEB. ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado12A As New Chunk("http://www.banotic.cl/preguntas-frecuentes.html", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK))

            Dim frase12 As New Phrase()
            frase12.Add(destacado12)
            frase12.Add(normal12)
            frase12.Add(destacado12A)

            'requisito11.Alignment = Element.ALIGN_JUSTIFIED
            'requisito11.Add(frase11)
            'cell.AddElement(New Paragraph(requisito11))
            cell = New PdfPCell(frase12)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)


            Dim destacado13 As New Chunk("12° CUALQUIER RECLAMO DE PAGO ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal13 As New Chunk("DEBE REALIZARSE AL CORREO ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado13b As New Chunk(Parametros.p_EMAIL3OC, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK))

            Dim frase13 As New Phrase()
            frase13.Add(destacado13)
            frase13.Add(normal13)
            frase13.Add(destacado13b)

            'requisito11.Alignment = Element.ALIGN_JUSTIFIED
            'requisito11.Add(frase11)
            'cell.AddElement(New Paragraph(requisito11))
            cell = New PdfPCell(frase13)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)



            ' ''cell = New PdfPCell(New Phrase("12° SOLO SE CANCELARAN LAS FACTURAS CON LA RECEPCION DE LA 4TA. COPIA Y TIMBRE DE PAGO QUE DIGA " _
            ' ''                            & "CANCELADO POR PARTE DEL OTEC.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)))
            ' ''cell.BorderWidthTop = 0
            ' ''cell.BorderWidthBottom = 0
            ' ''cell.BorderWidthLeft = 0
            ' ''cell.BorderWidthRight = 0
            ' ''cell.PaddingBottom = 3
            ' ''cell.PaddingTop = 0
            ' ''cell.Colspan = 2
            '' ''Dim requisito12 As New Paragraph("10° SOLO SE CANCELARAN LAS FACTURAS CON LA RECEPCION DE LA 4TA. COPIA Y TIMBRE DE PAGO QUE DIGA " _
            '' ''                            & "CANCELADO POR PARTE DEL OTEC.", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            '' ''requisito12.Alignment = Element.ALIGN_JUSTIFIED
            '' ''cell.AddElement(New Paragraph(requisito12))
            ' ''cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            ' ''tableRequisitos.AddCell(cell)


            Dim requisito15 As New Paragraph()
            Dim destacado15a As New Chunk("13° ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal15 As New Chunk("COMO MEJORA DE NUESTRO SERVICIO, SE SUGIERE QUE EL PAGO SE REALICE POR MEDIO DE ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado15b As New Chunk("TRANSFERENCIA ELECTRONICA", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal15b As New Chunk(", SOLICITAMOS EL ENVÍO DE LOS SIGUIENTES DATOS ADJUNTO A LA FACTURA:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase15 As New Phrase()
            frase15.Add(destacado15a)
            frase15.Add(normal15)
            frase15.Add(destacado15b)
            frase15.Add(normal15b)

            cell = New PdfPCell(frase15)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)

            'cell = New PdfPCell(New Phrase("DATOS PARA TRANSFERENCIA:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLD)))
            'cell.BorderWidthTop = 0
            'cell.BorderWidthBottom = 0
            'cell.BorderWidthLeft = 0
            'cell.BorderWidthRight = 0
            'cell.PaddingBottom = 3
            'cell.PaddingTop = 0
            'cell.Colspan = 2
            ''Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            ''cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            'tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	RAZON SOCIAL OTEC:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	RUT:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	BANCO:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	N° CUENTA DE CORRIENTE:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	NOMBRE DE CONTACTO:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	FONO:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("          -	CORREO:", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo5_5 As String = "          -	CANTIDAD DE HORAS CRONOLOGICAS."
            'cell.AddElement(New Paragraph(parrafo5_5.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            'Dim requisito13 As New Paragraph()

            Dim destacado13a As New Chunk("14° ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal13a As New Chunk("HORARIOS DE PAGO Y RECEPCION DE DOCUMENTOS: DE LUNES A JUEVES 09:00 A 14:00 HORAS.", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))

            Dim frase13a As New Phrase()
            frase13a.Add(destacado13a)
            frase13a.Add(normal13a)

            'requisito13.Alignment = Element.ALIGN_JUSTIFIED
            'requisito13.Add(frase13)
            'cell.AddElement(New Paragraph(requisito13))

            cell = New PdfPCell(frase13a)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)


            Dim requisito14 As New Paragraph()

            Dim destacado14 As New Chunk("15° ", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            Dim normal14 As New Chunk("PARA CONSULTAS SOBRE EL PAGO DE FACTURAS COMUNICARSE DIRECTAMENTE AL: 228894400 O ", _
                                        FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK))
            Dim destacado14b As New Chunk(Parametros.p_EMAIL3OC, FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK))

            Dim frase14 As New Phrase()
            frase14.Add(destacado14)
            frase14.Add(normal14)
            frase14.Add(destacado14b)

            'requisito14.Alignment = Element.ALIGN_JUSTIFIED
            'requisito14.Add(frase14)
            'cell.AddElement(New Paragraph(requisito14))
            cell = New PdfPCell(frase14)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim requisito15 As New Paragraph("DUDAS O CONSULTAS DE ESTA OC CONTACTARSE CON EL AREA DE OPERACIONES AL 228894400", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            'requisito15.Alignment = Element.ALIGN_JUSTIFIED
            'cell.AddElement(New Paragraph(requisito15))
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("DUDAS O CONSULTAS DE ESTA OC, CONTACTARSE CON EL AREA DE OPERACIONES AL 228894400", FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim requisito15 As New Paragraph("DUDAS O CONSULTAS DE ESTA OC CONTACTARSE CON EL AREA DE OPERACIONES AL 228894400", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            'requisito15.Alignment = Element.ALIGN_JUSTIFIED
            'cell.AddElement(New Paragraph(requisito15))
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim requisito15 As New Paragraph("DUDAS O CONSULTAS DE ESTA OC CONTACTARSE CON EL AREA DE OPERACIONES AL 228894400", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK))
            'requisito15.Alignment = Element.ALIGN_JUSTIFIED
            'cell.AddElement(New Paragraph(requisito15))
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase("SALUDA ATENTAMENTE A USTED.", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo17 As String = "SALUDA ATENTAMENTE A USTED."
            'cell.AddElement(New Paragraph(parrafo17.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo17 As String = "SALUDA ATENTAMENTE A USTED."
            'cell.AddElement(New Paragraph(parrafo17.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 7)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            'Dim parrafo17 As String = "SALUDA ATENTAMENTE A USTED."
            'cell.AddElement(New Paragraph(parrafo17.ToUpper, FontFactory.GetFont("Arial", 8)))
            tableRequisitos.AddCell(cell)

            'firma
            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            Dim banner2 As Image
            banner2 = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "contenido\imagenes\empresa\firma2.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            banner2.Alignment = Element.ALIGN_RIGHT

            Dim percentage As Single = 0.0F
            percentage = Parametros.p_TAMANOFIRMA / banner2.Width
            banner2.ScalePercent(percentage * 170)

            'banner2.ScalePercent(50.0F)
            cell.AddElement(banner2)
            tableRequisitos.AddCell(cell)

            'sello pyme
            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            Dim pyme As Image
            pyme = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "contenido\imagenes\empresa\logoPyme.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            pyme.Alignment = Element.ALIGN_CENTER

            Dim percentagepyme As Single = 0.0F
            percentagepyme = Parametros.p_TAMANOFIRMA / pyme.Width
            pyme.ScalePercent(percentagepyme * 80)

            'banner2.ScalePercent(50.0F)
            cell.AddElement(pyme)
            tableRequisitos.AddCell(cell)

            oDoc.Add(tableRequisitos)


            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo
            mstrRutaFisica = "\contenido\tmp\" & nombreArchivo

        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            EnviaError("CGeneraCartaOtec:CartaOtec-->" & ex.Message)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    
End Class
