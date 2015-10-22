Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data

Public Class PDFGenerator

    public Shared Function CreatePDF() As MemoryStream

        ' Create a Document object
        Dim document As Document = New Document(iTextSharp.text.PageSize.A4, 70, 70, 70, 70)

        'MemoryStream
        Dim PDFData As MemoryStream = New MemoryStream()
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, PDFData)

        ' First, create our fonts
        Dim titleFont = FontFactory.GetFont("Arial", 14, Font.BOLD)
        Dim boldTableFont = FontFactory.GetFont("Arial", 10, Font.BOLD)
        Dim bodyFont = FontFactory.GetFont("Arial", 10, Font.NORMAL)
        Dim pageSize As Rectangle = writer.PageSize

        ' Open the Document for writing
        document.Open()
        'Add elements to the document here


        ' Create the header table 
        Dim headertable As PdfPTable = New PdfPTable(3)
        headertable.HorizontalAlignment = 0
        headertable.WidthPercentage = 100
        headertable.SetWidths(New Integer() {4, 2, 4})
        ' then set the column's __relative__ widths
        headertable.DefaultCell.Border = Rectangle.NO_BORDER
        headertable.DefaultCell.Border = Rectangle.BOX
        'for testing
        headertable.SpacingAfter = 30
        Dim nested As PdfPTable = New PdfPTable(1)
        nested.DefaultCell.Border = Rectangle.BOX
        Dim nextPostCell1 As PdfPCell = New PdfPCell(New Phrase("ABC Co.,Ltd", bodyFont))
        nextPostCell1.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        nested.AddCell(nextPostCell1)
        Dim nextPostCell2 As PdfPCell = New PdfPCell(New Phrase("111/206 Moo 9, Ramkhamheang Road,", bodyFont))
        nextPostCell2.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        nested.AddCell(nextPostCell2)
        Dim nextPostCell3 As PdfPCell = New PdfPCell(New Phrase("Nonthaburi 11120", bodyFont))
        nextPostCell3.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        nested.AddCell(nextPostCell3)
        Dim nesthousing As PdfPCell = New PdfPCell(nested)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        headertable.AddCell(nesthousing)

        headertable.AddCell("")
        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("INVOICE", titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(invoiceCell)
        Dim noCell As PdfPCell = New PdfPCell(New Phrase("No :", bodyFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(noCell)
        headertable.AddCell(New Phrase("1", bodyFont))
        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Date :", bodyFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(dateCell)
        headertable.AddCell(New Phrase("1", bodyFont))
        Dim billCell As PdfPCell = New PdfPCell(New Phrase("Bill To :", bodyFont))
        billCell.HorizontalAlignment = 2
        billCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(billCell)
        headertable.AddCell(New Phrase("1" + "\n" + "1", bodyFont))
        document.Add(headertable)


        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(4)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40, 20, 30})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell2 As PdfPCell = New PdfPCell(New Phrase("ITEM", boldTableFont))
        cell2.HorizontalAlignment = 1
        itemTable.AddCell(cell2)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("QUANTITY", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)
        Dim cell4 As PdfPCell = New PdfPCell(New Phrase("AMOUNT(USD)", boldTableFont))
        cell4.HorizontalAlignment = 1
        itemTable.AddCell(cell4)

        'For Each row As DataRow In dt.rows
        Dim numberCell As PdfPCell = New PdfPCell(New Phrase("coco", bodyFont))
        numberCell.HorizontalAlignment = 0
        numberCell.PaddingLeft = 10.0F
        numberCell.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        itemTable.AddCell(numberCell)

        Dim descCell As PdfPCell = New PdfPCell(New Phrase("coco", bodyFont))
        descCell.HorizontalAlignment = 0
        descCell.PaddingLeft = 10.0F
        descCell.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        itemTable.AddCell(descCell)

        Dim qtyCell As PdfPCell = New PdfPCell(New Phrase("coco", bodyFont))
        qtyCell.HorizontalAlignment = 0
        qtyCell.PaddingLeft = 10.0F
        qtyCell.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        itemTable.AddCell(qtyCell)

        Dim amtCell As PdfPCell = New PdfPCell(New Phrase("coco", bodyFont))
        amtCell.HorizontalAlignment = 1
        amtCell.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        itemTable.AddCell(amtCell)
        'Next

        ' Table footer
        Dim totalAmtCell1 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell1.Border = Rectangle.LEFT_BORDER And Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell1)
        Dim totalAmtCell2 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell2.Border = Rectangle.TOP_BORDER
        'Rectangle.NO_BORDER //Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell2)
        Dim totalAmtStrCell As PdfPCell = New PdfPCell(New Phrase("Total Amount", boldTableFont))
        totalAmtStrCell.Border = Rectangle.TOP_BORDER   'Rectangle.NO_BORDER 'Rectangle.TOP_BORDER
        totalAmtStrCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtStrCell)
        'Dim totalAmtCell As PdfPCell = New PdfPCell(New Phrase("100".ToString("#,###.00"), boldTableFont))
        Dim totalAmtCell As PdfPCell = New PdfPCell(New Phrase("100", boldTableFont))
        totalAmtCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtCell)

        Dim cell As PdfPCell = New PdfPCell(New Phrase("*** Please note that ABC Co., Ltd’s bank account is USD Bank Account ***", bodyFont))
        cell.Colspan = 4
        cell.HorizontalAlignment = 1
        itemTable.AddCell(cell)
        document.Add(itemTable)


        Dim transferBank As Chunk = New Chunk("Your Bank Account:", boldTableFont)
        transferBank.SetUnderline(0.1F, -2.0F) '0.1 thick, -2 y-location
        document.Add(transferBank)
        document.Add(Chunk.NEWLINE)

        ' Bank Account Info
        Dim bottomTable As PdfPTable = New PdfPTable(3)
        bottomTable.HorizontalAlignment = 0
        bottomTable.TotalWidth = 300.0F
        bottomTable.SetWidths(New Integer() {90, 10, 200})
        bottomTable.LockedWidth = True
        bottomTable.SpacingBefore = 20
        bottomTable.DefaultCell.Border = Rectangle.NO_BORDER
        bottomTable.AddCell(New Phrase("Account No", bodyFont))
        bottomTable.AddCell(":")
        bottomTable.AddCell(New Phrase("1", bodyFont))
        bottomTable.AddCell(New Phrase("Account Name", bodyFont))
        bottomTable.AddCell(":")
        bottomTable.AddCell(New Phrase("pepe", bodyFont))
        bottomTable.AddCell(New Phrase("Branch", bodyFont))
        bottomTable.AddCell(":")
        bottomTable.AddCell(New Phrase("coco", bodyFont))
        bottomTable.AddCell(New Phrase("Bank", bodyFont))
        bottomTable.AddCell(":")
        bottomTable.AddCell(New Phrase("lolo", bodyFont))
        document.Add(bottomTable)

        'Approved by
        Dim cb As PdfContentByte = New PdfContentByte(writer)
        Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, True)
        cb = writer.DirectContent
        cb.BeginText()
        cb.SetFontAndSize(bf, 10)
        cb.SetTextMatrix(pageSize.GetLeft(300), 200)
        cb.ShowText("Approved by,")
        cb.EndText()
        'Image Singature
        'Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Bill_Gates2.png"))
        'logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)
        'document.Add(logo)

        cb = New PdfContentByte(writer)
        bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, True)
        cb = writer.DirectContent
        cb.BeginText()
        cb.SetFontAndSize(bf, 10)
        cb.SetTextMatrix(pageSize.GetLeft(70), 100)
        cb.ShowText("Thank you for your business! If you have any questions about your order, please contact us at 800-555-NORTH.")
        cb.EndText()

        writer.CloseStream = False 'set the closestream property
        ' Close the Document without closing the underlying stream
        document.Close()
        Return PDFData
    End Function
End Class
