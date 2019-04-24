Imports Modulos
Imports iTextSharp '.text.Document
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class CGeneraComprobanteAporte
    Private mstrRutaArchivo As String
    Private mstrRutaArchivoVirtual As String
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

    Private Ruta As String = Parametros.p_DIRFISICO

    Public Function GenerarComprobanteAporte(ByVal NumAporte As String, ByVal FechaDocumento As Date, _
                                            ByVal Empresa As String, ByVal Rut As Long, _
                                            ByVal Direccion As String, ByVal Monto As Long, _
                                            ByVal NumDocumento As String, ByVal Banco As String, _
                                            ByVal FechaAporte As Date, ByVal Glosa As String) As String
        
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

            Dim table As New PdfPTable(2)
            table.TotalWidth = PageSize.A4.Width
            Dim widthsFichaOtec(1) As Single
            widthsFichaOtec(0) = 250
            widthsFichaOtec(1) = 250
          

            table.SetWidthPercentage(widthsFichaOtec, PageSize.A4)

            oDoc.Add(New Paragraph(" ")) 'Salto de linea
            oDoc.Add(New Paragraph(" ")) 'Salto de linea

           
            cell = New PdfPCell(New Phrase("COMPROBANTE DE APORTE", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase("FECHA: " & Now.Date, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_RIGHT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_ORGANISMO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_SUBORGANISMO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)



            Dim LINEA As Image
            LINEA = Image.GetInstance(New FileStream(Ruta & "contenido\imagenes\empresa\linea-separacion.gif", FileMode.Open, FileAccess.Read, FileShare.Read))
            LINEA.ScalePercent(50.0F)
            LINEA.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)



            cell = New PdfPCell(LINEA)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_NUMEROCOMPROBANTETITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(NumAporte.ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_FECHATITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(FechaDocumento, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_EMPRESATITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(Empresa.ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_RUTTITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(RutLngAUsr(Rut).ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_DIRECCIONTITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(Direccion.ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_MONTOLETRASTITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(Numero_a_Letras(Monto).ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_DOCUMENTOTITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(NumDocumento.ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_BANCO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(Banco.ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)


            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_OBSERVACIONES, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_FECHAAPORTETITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(FechaAporte, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_MONTONUMEROSTITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(FormatoPeso(Monto), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_GLOSATITULO, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(Glosa.ToUpper, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(LINEA)
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_TEXTOFINAL, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)

            cell = New PdfPCell(New Phrase(ComprobanteAporte.p_SUBTEXTOFINAL, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD)))
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)
            

            'firm
            cell = New PdfPCell
            cell.BorderWidthTop = 0
            cell.BorderWidthBottom = 0
            cell.BorderWidthLeft = 0
            cell.BorderWidthRight = 0
            cell.PaddingBottom = 3
            cell.PaddingTop = 0
            cell.Colspan = 2
            Dim banner2 As Image
            banner2 = Image.GetInstance(New FileStream(Parametros.p_DIRFISICO & "contenido\imagenes\empresa\firma_gerente_pdf.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            banner2.Alignment = Element.ALIGN_CENTER

            Dim percentage As Single = 0.0F
            percentage = Parametros.p_TAMANOFIRMA / banner2.Width
            banner2.ScalePercent(percentage * 100)

            cell.AddElement(banner2)
            table.AddCell(cell)
            oDoc.Add(table)


            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()

            mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo
            mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo




        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(archivo) Then
                If oDoc.IsOpen Then oDoc.Close()
                File.Delete(archivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Function

    'Public Function GenerarComprobanteAporte(ByVal NumAporte As String, ByVal FechaDocumento As Date, _
    '                                        ByVal Empresa As String, ByVal Rut As Long, _
    '                                        ByVal Direccion As String, ByVal Monto As Long, _
    '                                        ByVal NumDocumento As String, ByVal Banco As String, _
    '                                        ByVal FechaAporte As Date, ByVal Glosa As String) As String
    '    Dim texto As String = ""
    '    Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
    '    Dim pdfw As iTextSharp.text.pdf.PdfWriter
    '    Dim cb As PdfContentByte
    '    Dim fuente As iTextSharp.text.pdf.BaseFont
    '    Dim nombreArchivo As String = NombreArchivoTmp("pdf")
    '    Dim archivo As String = Ruta & "contenido\tmp\" & nombreArchivo
    '    Dim ct As ColumnText
    '    Try
    '        pdfw = PdfWriter.GetInstance(oDoc, New FileStream(archivo, _
    '        FileMode.Create, FileAccess.Write, FileShare.None))
    '        'Apertura del documento.
    '        oDoc.Open()
    '        cb = pdfw.DirectContent
    '        'Agregamos una pagina.
    '        oDoc.NewPage()


    '        Dim logo As Image
    '        logo = Image.GetInstance(New FileStream(Ruta & "contenido\imagenes\empresa\logo.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
    '        logo.SetAbsolutePosition(PageSize.A4.Width - 555, PageSize.A4.Height - 70)
    '        logo.ScalePercent(60.0F)
    '        cb.AddImage(logo)
    '        cb.BeginText()

    '        '*** TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
    '        cb.SetFontAndSize(fuente, 16)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ComprobanteAporte.p_TITULO, (PageSize.A4.Width / 2), (PageSize.A4.Height - 50), 0)

    '        '*** SUBTITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ComprobanteAporte.p_SUBTITULO, (PageSize.A4.Width / 2), (PageSize.A4.Height - 66), 0)

    '        '*** TITULO FECHA
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 8)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Fecha", 400, (PageSize.A4.Height - 85), 0)

    '        '*** DATO FECHA
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 8)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Now.Date.ToShortDateString, 450, (PageSize.A4.Height - 85), 0)

    '        '*** ORGANISMO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
    '        cb.SetFontAndSize(fuente, 14)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_ORGANISMO, 40, (PageSize.A4.Height - 140), 0)

    '        '*** SUB ORGANISMO 
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 10)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_SUBORGANISMO, 40, (PageSize.A4.Height - 155), 0)

    '        Dim Separacion As Image
    '        Separacion = Image.GetInstance(New FileStream(Ruta & "contenido\imagenes\empresa\linea-separacion.gif", FileMode.Open, FileAccess.Read, FileShare.Read))
    '        Separacion.SetAbsolutePosition(20, PageSize.A4.Height - 175)
    '        cb.AddImage(Separacion)

    '        '*** NUMERO COMPROBANTE TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_NUMEROCOMPROBANTETITULO, 40, (PageSize.A4.Height - 195), 0)

    '        '*** NUMERO COMPROBANTE DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, NumAporte, 250, (PageSize.A4.Height - 195), 0)

    '        '*** FECHA COMPROBANTE TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_FECHATITULO, 40, (PageSize.A4.Height - 210), 0)

    '        '*** FECHA COMPROBANTE DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, FechaDocumento.ToShortDateString, 250, (PageSize.A4.Height - 210), 0)

    '        '*** EMPRESA TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_EMPRESATITULO, 40, (PageSize.A4.Height - 235), 0)

    '        '*** EMPRESA DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Empresa, 250, (PageSize.A4.Height - 235), 0)

    '        '*** RUT TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_RUTTITULO, 40, (PageSize.A4.Height - 250), 0)

    '        '*** RUT DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, RutLngAUsr(Rut), 250, (PageSize.A4.Height - 250), 0)

    '        '*** DOMICILIO TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_DIRECCIONTITULO, 40, (PageSize.A4.Height - 265), 0)

    '        ''*** DOMICILIO DATO
    '        'ct = New ColumnText(cb)
    '        'ct.SetSimpleColumn(New Phrase(New Chunk(Direccion, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL))), _
    '        '           575, 0, 250, (PageSize.A4.Height - 255), 10, Element.ALIGN_LEFT)
    '        'ct.Go()

    '        '*** MONTO TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_MONTOLETRASTITULO, 40, (PageSize.A4.Height - 305), 0)

    '        ''*** MONTO DATO
    '        'ct = New ColumnText(cb)
    '        'texto = Numero_a_Letras(Monto) '"TREINTA Y OCHO MILLONES DE PESOS"
    '        'ct.SetSimpleColumn(New Phrase(New Chunk(texto, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL))), _
    '        '           575, 0, 250, (PageSize.A4.Height - 295), 10, Element.ALIGN_LEFT)
    '        'ct.Go()

    '        '*** DOCUMENTO TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_DOCUMENTOTITULO, 40, (PageSize.A4.Height - 335), 0)

    '        '*** DOCUMENTO DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, NumDocumento, 250, (PageSize.A4.Height - 335), 0)

    '        '*** BANCO TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_BANCO, 40, (PageSize.A4.Height - 350), 0)

    '        '*** BANCO DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Banco, 250, (PageSize.A4.Height - 350), 0)

    '        '*** OBSERVACIONES 
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 10)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_OBSERVACIONES, 40, (PageSize.A4.Height - 375), 0)

    '        '*** FECHA APORTE TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_FECHAAPORTETITULO, 40, (PageSize.A4.Height - 400), 0)

    '        '*** FECHA APORTE DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, FechaAporte.ToShortDateString, 250, (PageSize.A4.Height - 400), 0)

    '        '*** MONTO APORTE TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_MONTONUMEROSTITULO, 40, (PageSize.A4.Height - 415), 0)

    '        '*** MONTO APORTE DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, FormatoPeso(Monto), 250, (PageSize.A4.Height - 415), 0)

    '        '*** GLOSA TITULO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_GLOSATITULO, 40, (PageSize.A4.Height - 430), 0)

    '        '*** GLOSA DATO
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 12)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Glosa, 250, (PageSize.A4.Height - 430), 0)

    '        Dim Separacion2 As Image
    '        Separacion2 = Image.GetInstance(New FileStream(Ruta & "contenido\imagenes\empresa\linea-separacion.gif", FileMode.Open, FileAccess.Read, FileShare.Read))
    '        Separacion2.SetAbsolutePosition(20, PageSize.A4.Height - 450)
    '        cb.AddImage(Separacion2)

    '        '*** TEXTO FINAL
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 10)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_TEXTOFINAL, 40, (PageSize.A4.Height - 470), 0)

    '        '*** SUBTEXTO FINAL
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 10)
    '        cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ComprobanteAporte.p_SUBTEXTOFINAL, 40, (PageSize.A4.Height - 485), 0)

    '        Dim Firma As Image
    '        Firma = Image.GetInstance(New FileStream(Ruta & "contenido\imagenes\empresa\firmas.png", FileMode.Open, FileAccess.Read, FileShare.Read))
    '        Firma.SetAbsolutePosition(20, PageSize.A4.Height - 700)
    '        cb.AddImage(Firma)

    '        Dim Separacion3 As Image
    '        Separacion3 = Image.GetInstance(New FileStream(Ruta & "contenido\imagenes\empresa\linea-separacion.gif", FileMode.Open, FileAccess.Read, FileShare.Read))
    '        Separacion3.SetAbsolutePosition(20, 70)
    '        cb.AddImage(Separacion3)

    '        ''*** PIE FINAL
    '        'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        'cb.SetFontAndSize(fuente, 8)
    '        'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ANDRES BELLO # 2777 - TEL: (562)421-65-50 - FAX: (562)374-25-92 - http://www.asimetcapacitacion.cl - e-mail: asimet.capacitacion@asimet.cl", (PageSize.A4.Width / 2), 50, 0)

    '        ''*** SUBPIE FINAL
    '        'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        'cb.SetFontAndSize(fuente, 8)
    '        'cb.SetColorFill(iTextSharp.text.BaseColor.DARK_GRAY)
    '        'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "SANTIAGO - CHILE", (PageSize.A4.Width / 2), 40, 0)


    '        '*** DOMICILIO DATO
    '        ct = New ColumnText(cb)
    '        ct.SetSimpleColumn(New Phrase(New Chunk(Direccion, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL))), _
    '                   575, 0, 250, (PageSize.A4.Height - 255), 10, Element.ALIGN_LEFT)
    '        ct.Go()

    '        '*** MONTO DATO
    '        ct = New ColumnText(cb)
    '        texto = Numero_a_Letras(Monto) '"TREINTA Y OCHO MILLONES DE PESOS"
    '        ct.SetSimpleColumn(New Phrase(New Chunk(texto, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL))), _
    '                   575, 0, 250, (PageSize.A4.Height - 295), 10, Element.ALIGN_LEFT)
    '        ct.Go()


    '        ct = New ColumnText(cb)
    '        ct.SetSimpleColumn(New Phrase(New Chunk(ComprobanteAporte.p_PIE, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL))), _
    '                   575, 0, 20, 60, 10, Element.ALIGN_CENTER)
    '        ct.Go()


    '        cb.EndText()

    '        'Forzamos vaciamiento del buffer.
    '        pdfw.Flush()
    '        'Cerramos el documento.
    '        oDoc.Close()

    '        mstrRutaArchivo = "~/contenido/tmp/" & nombreArchivo
    '        mstrRutaArchivoVirtual = "contenido\tmp\" & nombreArchivo

    '    Catch ex As Exception
    '        'Si hubo una excepcion y el archivo existe …
    '        If File.Exists(archivo) Then
    '            If oDoc.IsOpen Then oDoc.Close()
    '            File.Delete(archivo)
    '        End If
    '        Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
    '    Finally
    '        cb = Nothing
    '        pdfw = Nothing
    '        oDoc = Nothing
    '    End Try
    'End Function

End Class
