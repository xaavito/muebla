﻿Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data
Imports System.Web

Public Class PDFGenerator

    Shared r As New Random

    'Return 1000000000 + r.Next(1000000000)

    Public Shared Function CreatePDF() As MemoryStream

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

        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/smallMuebla.png"))
        logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim nesthousing As PdfPCell = New PdfPCell(logo)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        headertable.AddCell(nesthousing)

        Dim emptyCell As PdfPCell = New PdfPCell(New Phrase("", titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(emptyCell)

        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("ORDEN DE COMPRA", titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(invoiceCell)

        Dim noCell As PdfPCell = New PdfPCell(New Phrase("Nro :", bodyFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(noCell)

        Dim nroDato As PdfPCell = New PdfPCell(New Phrase("0001-000001", titleFont))
        nroDato.HorizontalAlignment = 2
        nroDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(nroDato)

        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Fecha :", bodyFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(dateCell)

        Dim fechaDato As PdfPCell = New PdfPCell(New Phrase(Date.Now, titleFont))
        fechaDato.HorizontalAlignment = 2
        fechaDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(fechaDato)


        Dim billCell As PdfPCell = New PdfPCell(New Phrase("Para :", bodyFont))
        billCell.HorizontalAlignment = 2
        billCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(billCell)

        Dim paraDato As PdfPCell = New PdfPCell(New Phrase("Mr Coco", titleFont))
        paraDato.HorizontalAlignment = 2
        paraDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(paraDato)

        document.Add(headertable)

        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(4)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40, 20, 30})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NRO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell2 As PdfPCell = New PdfPCell(New Phrase("ITEM", boldTableFont))
        cell2.HorizontalAlignment = 1
        itemTable.AddCell(cell2)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("CANTIDAD", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)
        Dim cell4 As PdfPCell = New PdfPCell(New Phrase("PRECIO", boldTableFont))
        cell4.HorizontalAlignment = 1
        itemTable.AddCell(cell4)

        'For Each row As DataRow In dt.rows
        Dim numberCell As PdfPCell = New PdfPCell(New Phrase("1", bodyFont))
        numberCell.HorizontalAlignment = 0
        numberCell.PaddingLeft = 10.0F
        numberCell.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        itemTable.AddCell(numberCell)

        Dim descCell As PdfPCell = New PdfPCell(New Phrase("Una Silla Copada", bodyFont))
        descCell.HorizontalAlignment = 0
        descCell.PaddingLeft = 10.0F
        descCell.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        itemTable.AddCell(descCell)

        Dim qtyCell As PdfPCell = New PdfPCell(New Phrase("1", bodyFont))
        qtyCell.HorizontalAlignment = 0
        qtyCell.PaddingLeft = 10.0F
        qtyCell.Border = Rectangle.LEFT_BORDER And Rectangle.RIGHT_BORDER
        itemTable.AddCell(qtyCell)

        Dim amtCell As PdfPCell = New PdfPCell(New Phrase("1500", bodyFont))
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
        Dim totalAmtStrCell As PdfPCell = New PdfPCell(New Phrase("Total", boldTableFont))
        totalAmtStrCell.Border = Rectangle.TOP_BORDER   'Rectangle.NO_BORDER 'Rectangle.TOP_BORDER
        totalAmtStrCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtStrCell)
        Dim totalAmtCell As PdfPCell = New PdfPCell(New Phrase(String.Format("{0:C}", "$15000"), boldTableFont))
        totalAmtCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtCell)

        document.Add(itemTable)

        writer.CloseStream = False 'set the closestream property
        ' Close the Document without closing the underlying stream
        document.Close()
        Return PDFData
    End Function

    Public Shared Function PedidoPDF(ByVal pedido As BE.PedidoBE) As MemoryStream
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

        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/smallMuebla.png"))
        logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim nesthousing As PdfPCell = New PdfPCell(logo)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        headertable.AddCell(nesthousing)

        Dim emptyCell As PdfPCell = New PdfPCell(New Phrase("", titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(emptyCell)

        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("PEDIDO", titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(invoiceCell)

        Dim noCell As PdfPCell = New PdfPCell(New Phrase("Nro :", bodyFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(noCell)

        Dim nroDato As PdfPCell = New PdfPCell(New Phrase("0001-000001", titleFont))
        nroDato.HorizontalAlignment = 2
        nroDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(nroDato)

        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Fecha :", bodyFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(dateCell)

        Dim fechaDato As PdfPCell = New PdfPCell(New Phrase(Date.Now, titleFont))
        fechaDato.HorizontalAlignment = 2
        fechaDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(fechaDato)


        Dim billCell As PdfPCell = New PdfPCell(New Phrase("Para :", bodyFont))
        billCell.HorizontalAlignment = 2
        billCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(billCell)

        Dim paraDato As PdfPCell = New PdfPCell(New Phrase(pedido.usr.apellido + " " + pedido.usr.nombre, titleFont))
        paraDato.HorizontalAlignment = 2
        paraDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(paraDato)

        document.Add(headertable)

        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(4)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40, 20, 30})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NRO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell2 As PdfPCell = New PdfPCell(New Phrase("ITEM", boldTableFont))
        cell2.HorizontalAlignment = 1
        itemTable.AddCell(cell2)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("CANTIDAD", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)
        Dim cell4 As PdfPCell = New PdfPCell(New Phrase("PRECIO", boldTableFont))
        cell4.HorizontalAlignment = 1
        itemTable.AddCell(cell4)

        Dim numberCell As PdfPCell
        Dim descCell As PdfPCell
        Dim qtyCell As PdfPCell
        Dim amtCell As PdfPCell

        For Each pp As BE.PedidoProductoBE In pedido.productos
            numberCell = New PdfPCell(New Phrase(pp.id, bodyFont))
            numberCell.HorizontalAlignment = 0
            numberCell.PaddingLeft = 10.0F
            itemTable.AddCell(numberCell)

            descCell = New PdfPCell(New Phrase(pp.producto.producto.descripcion, bodyFont))
            descCell.HorizontalAlignment = 0
            descCell.PaddingLeft = 10.0F
            itemTable.AddCell(descCell)

            qtyCell = New PdfPCell(New Phrase(pp.cantidad, bodyFont))
            qtyCell.HorizontalAlignment = 0
            qtyCell.PaddingLeft = 10.0F
            itemTable.AddCell(qtyCell)

            amtCell = New PdfPCell(New Phrase(pp.getPrecio, bodyFont))
            amtCell.HorizontalAlignment = 1
            itemTable.AddCell(amtCell)
        Next


        ' Table footer
        Dim totalAmtCell1 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell1.Border = Rectangle.LEFT_BORDER And Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell1)
        Dim totalAmtCell2 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell2.Border = Rectangle.TOP_BORDER
        'Rectangle.NO_BORDER //Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell2)
        Dim totalAmtStrCell As PdfPCell = New PdfPCell(New Phrase("Total", boldTableFont))
        totalAmtStrCell.Border = Rectangle.TOP_BORDER   'Rectangle.NO_BORDER 'Rectangle.TOP_BORDER
        totalAmtStrCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtStrCell)
        Dim totalAmtCell As PdfPCell = New PdfPCell(New Phrase(String.Format("{0:C}", pedido.getTotalCalculado()), boldTableFont))
        totalAmtCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtCell)

        document.Add(itemTable)

        Dim barTable As PdfPTable = New PdfPTable(1)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100

        Dim barCode As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/bar_code.jpg"))
        'barCode.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim barcell As PdfPCell = New PdfPCell(barCode)
        barcell.Rowspan = 4
        barcell.Padding = 0.0F
        barTable.AddCell(barcell)

        document.Add(barTable)

        writer.CloseStream = False 'set the closestream property
        ' Close the Document without closing the underlying stream
        document.Close()
        Return PDFData
    End Function

    Public Shared Function OrdenCompraPDF(ByVal oc As BE.OrdenCompraBE) As MemoryStream

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

        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/smallMuebla.png"))
        logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim nesthousing As PdfPCell = New PdfPCell(logo)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        headertable.AddCell(nesthousing)

        Dim emptyCell As PdfPCell = New PdfPCell(New Phrase("", titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(emptyCell)

        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("ORDEN DE COMPRA", titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(invoiceCell)

        Dim noCell As PdfPCell = New PdfPCell(New Phrase("Nro :", bodyFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(noCell)

        Dim nroDato As PdfPCell = New PdfPCell(New Phrase(oc.id.ToString().PadLeft(8, "0"), titleFont))
        nroDato.HorizontalAlignment = 2
        nroDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(nroDato)

        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Fecha :", bodyFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(dateCell)

        Dim fechaDato As PdfPCell = New PdfPCell(New Phrase(oc.fecha, titleFont))
        fechaDato.HorizontalAlignment = 2
        fechaDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(fechaDato)


        Dim billCell As PdfPCell = New PdfPCell(New Phrase("Para :", bodyFont))
        billCell.HorizontalAlignment = 2
        billCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(billCell)

        Dim paraDato As PdfPCell = New PdfPCell(New Phrase((oc.proveedor.razonSocial + " " + oc.proveedor.dom.formatedLine() + " " + oc.proveedor.cuit.ToString).ToString))
        paraDato.HorizontalAlignment = 2
        paraDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(paraDato)

        document.Add(headertable)

        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(4)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40, 20, 30})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NRO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell2 As PdfPCell = New PdfPCell(New Phrase("ITEM", boldTableFont))
        cell2.HorizontalAlignment = 1
        itemTable.AddCell(cell2)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("CANTIDAD", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)
        Dim cell4 As PdfPCell = New PdfPCell(New Phrase("PRECIO", boldTableFont))
        cell4.HorizontalAlignment = 1
        itemTable.AddCell(cell4)

        Dim numberCell As PdfPCell
        Dim descCell As PdfPCell
        Dim qtyCell As PdfPCell
        Dim amtCell As PdfPCell

        Dim id As Integer = 0
        For Each pp As BE.OrdenCompraDetalleBE In oc.detalle
            id = id + 1
            numberCell = New PdfPCell(New Phrase(id, bodyFont))
            numberCell.HorizontalAlignment = 0
            numberCell.PaddingLeft = 10.0F
            itemTable.AddCell(numberCell)

            descCell = New PdfPCell(New Phrase(pp.producto.descripcion, bodyFont))
            descCell.HorizontalAlignment = 0
            descCell.PaddingLeft = 10.0F
            itemTable.AddCell(descCell)

            qtyCell = New PdfPCell(New Phrase(pp.cantidad, bodyFont))
            qtyCell.HorizontalAlignment = 0
            qtyCell.PaddingLeft = 10.0F
            itemTable.AddCell(qtyCell)

            amtCell = New PdfPCell(New Phrase(pp.precioUnitario, bodyFont))
            amtCell.HorizontalAlignment = 1
            itemTable.AddCell(amtCell)
        Next


        ' Table footer
        Dim totalAmtCell1 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell1.Border = Rectangle.LEFT_BORDER And Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell1)
        Dim totalAmtCell2 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell2.Border = Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell2)
        Dim totalAmtStrCell As PdfPCell = New PdfPCell(New Phrase("Total", boldTableFont))
        totalAmtStrCell.Border = Rectangle.TOP_BORDER
        totalAmtStrCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtStrCell)
        Dim totalAmtCell As PdfPCell = New PdfPCell(New Phrase(String.Format("{0:C}", oc.getTotal()), boldTableFont))
        totalAmtCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtCell)

        document.Add(itemTable)

        writer.CloseStream = False 'set the closestream property
        ' Close the Document without closing the underlying stream
        document.Close()
        Return PDFData
    End Function

    Shared Function FacturaPDF(facturaBE As BE.FacturaBE) As MemoryStream
        ' Create a Document object
        Dim document As Document = New Document(iTextSharp.text.PageSize.A4, 70, 70, 70, 70)

        Dim generico As PdfPCell

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

        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/smallMuebla.png"))
        logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim nesthousing As PdfPCell = New PdfPCell(logo)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        nesthousing.Border = Rectangle.NO_BORDER
        headertable.AddCell(nesthousing)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        generico = New PdfPCell(New Phrase("", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        headertable.AddCell(generico)

        document.Add(headertable)

        ' Create the middle table 

        Dim middleTable As PdfPTable = New PdfPTable(2)
        middleTable.HorizontalAlignment = 0
        middleTable.WidthPercentage = 100
        middleTable.SetWidths(New Integer() {4, 6})
        ' then set the column's __relative__ widths
        middleTable.DefaultCell.Border = Rectangle.BOX
        'for testing
        middleTable.SpacingAfter = 30

        Dim emptyCell As PdfPCell = New PdfPCell(New Phrase("ORIGINAL", titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        middleTable.AddCell(emptyCell)

        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("Factura " + facturaBE.letra, titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        middleTable.AddCell(invoiceCell)

        Dim noCell As PdfPCell = New PdfPCell(New Phrase("Nro", titleFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        middleTable.AddCell(noCell)

        Dim nroDato As PdfPCell = New PdfPCell(New Phrase(facturaBE.sucursal.ToString().PadLeft(4, "0") + "-" + facturaBE.nro.ToString().PadLeft(8, "0"), titleFont))
        nroDato.HorizontalAlignment = 2
        nroDato.Border = Rectangle.NO_BORDER
        middleTable.AddCell(nroDato)

        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Fecha de Emision", titleFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        middleTable.AddCell(dateCell)

        Dim fechaDato As PdfPCell = New PdfPCell(New Phrase(facturaBE.fecha, titleFont))
        fechaDato.HorizontalAlignment = 2
        fechaDato.Border = Rectangle.NO_BORDER
        middleTable.AddCell(fechaDato)
        
        generico = New PdfPCell(New Phrase("CUIT", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        middleTable.AddCell(generico)

        generico = New PdfPCell(New Phrase("27-2719382630-5", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        middleTable.AddCell(generico)

        generico = New PdfPCell(New Phrase("Domicilio Comercial", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        middleTable.AddCell(generico)

        generico = New PdfPCell(New Phrase("25 de Mayo 468 CABA", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        middleTable.AddCell(generico)

        
        generico = New PdfPCell(New Phrase("Condicion IVA", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        middleTable.AddCell(generico)

        generico = New PdfPCell(New Phrase("Responsable Inscripto", titleFont))
        generico.HorizontalAlignment = 2
        generico.Border = Rectangle.NO_BORDER
        middleTable.AddCell(generico)

        'DATOS CLIENTE
        Dim billCell As PdfPCell = New PdfPCell(New Phrase("PARA", titleFont))
        billCell.HorizontalAlignment = 2
        billCell.Border = Rectangle.NO_BORDER
        middleTable.AddCell(billCell)

        emptyCell = New PdfPCell(New Phrase(facturaBE.usr.apellido + " " + facturaBE.usr.nombre, titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        middleTable.AddCell(emptyCell)

        Dim cuil As PdfPCell = New PdfPCell(New Phrase("CUIL", titleFont))
        cuil.HorizontalAlignment = 2
        cuil.Border = Rectangle.NO_BORDER
        middleTable.AddCell(cuil)

        emptyCell = New PdfPCell(New Phrase(facturaBE.usr.cuil.ToString, titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        middleTable.AddCell(emptyCell)

        Dim cons As PdfPCell = New PdfPCell(New Phrase("CONSUMIDOR FINAL", titleFont))
        cons.HorizontalAlignment = 2
        cons.Border = Rectangle.NO_BORDER
        middleTable.AddCell(cons)

        document.Add(middleTable)

        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(5)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40, 20, 10, 20})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NRO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell2 As PdfPCell = New PdfPCell(New Phrase("ITEM", boldTableFont))
        cell2.HorizontalAlignment = 1
        itemTable.AddCell(cell2)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("CANTIDAD", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)
        Dim cell4 As PdfPCell = New PdfPCell(New Phrase("IVA", boldTableFont))
        cell4.HorizontalAlignment = 1
        itemTable.AddCell(cell4)
        Dim cell5 As PdfPCell = New PdfPCell(New Phrase("PRECIO", boldTableFont))
        cell5.HorizontalAlignment = 1
        itemTable.AddCell(cell5)

        Dim numberCell As PdfPCell
        Dim descCell As PdfPCell
        Dim qtyCell As PdfPCell
        Dim ivaCell As PdfPCell
        Dim amtCell As PdfPCell

        For Each pp As BE.FacturaDetalleBE In facturaBE.detalles
            numberCell = New PdfPCell(New Phrase(pp.lpd.id, bodyFont))
            numberCell.HorizontalAlignment = 0
            numberCell.PaddingLeft = 10.0F
            itemTable.AddCell(numberCell)

            descCell = New PdfPCell(New Phrase(pp.lpd.producto.descripcion, bodyFont))
            descCell.HorizontalAlignment = 0
            descCell.PaddingLeft = 10.0F
            itemTable.AddCell(descCell)

            qtyCell = New PdfPCell(New Phrase(pp.cant, bodyFont))
            qtyCell.HorizontalAlignment = 0
            qtyCell.PaddingLeft = 10.0F
            itemTable.AddCell(qtyCell)

            ivaCell = New PdfPCell(New Phrase(pp.iva, bodyFont))
            ivaCell.HorizontalAlignment = 0
            ivaCell.PaddingLeft = 10.0F
            itemTable.AddCell(ivaCell)

            amtCell = New PdfPCell(New Phrase(String.Format("{0:C}", pp.lpd.precio), bodyFont))
            amtCell.HorizontalAlignment = 1
            itemTable.AddCell(amtCell)
        Next


        ' Table footer
        Dim totalAmtCell1 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell1.Border = Rectangle.LEFT_BORDER And Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell1)
        Dim totalAmtCell2 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell2.Border = Rectangle.TOP_BORDER
        'Rectangle.NO_BORDER //Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell2)
        Dim totalAmtCell3 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell3.Border = Rectangle.TOP_BORDER
        'Rectangle.NO_BORDER //Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell3)
        Dim totalAmtStrCell As PdfPCell = New PdfPCell(New Phrase("Total", boldTableFont))
        totalAmtStrCell.Border = Rectangle.TOP_BORDER   'Rectangle.NO_BORDER 'Rectangle.TOP_BORDER
        totalAmtStrCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtStrCell)
        Dim totalAmtCell As PdfPCell = New PdfPCell(New Phrase(String.Format("{0:C}", facturaBE.total), boldTableFont))
        totalAmtCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtCell)

        document.Add(itemTable)

        Dim barTable As PdfPTable = New PdfPTable(1)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100

        Dim barCode As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/bar_code.jpg"))
        'barCode.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim barcell As PdfPCell = New PdfPCell(barCode)
        barcell.Rowspan = 4
        barcell.Padding = 0.0F
        barTable.AddCell(barcell)

        document.Add(barTable)

        Dim closeTable As PdfPTable = New PdfPTable(2)
        closeTable.HorizontalAlignment = 0
        closeTable.WidthPercentage = 100
        closeTable.SetWidths(New Integer() {4, 4})
        ' then set the column's __relative__ widths
        closeTable.DefaultCell.Border = Rectangle.NO_BORDER
        closeTable.DefaultCell.Border = Rectangle.BOX
        'for testing
        closeTable.SpacingAfter = 30

        closeTable.AddCell(New PdfPCell(New Phrase("CAE " + (1000000000 + r.Next(1000000000)).ToString, bodyFont)))
        closeTable.AddCell(New PdfPCell(New Phrase("VENCIMIENTO CAE 01/01/2016", bodyFont)))

        document.Add(closeTable)

        writer.CloseStream = False 'set the closestream property
        document.Close()
        Return PDFData
    End Function

    Shared Function RemitoPDF(remito As BE.RemitoBE) As MemoryStream
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

        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/smallMuebla.png"))
        logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim nesthousing As PdfPCell = New PdfPCell(logo)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        headertable.AddCell(nesthousing)

        Dim emptyCell As PdfPCell = New PdfPCell(New Phrase("", titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(emptyCell)

        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("Remito " + remito.letra, titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(invoiceCell)

        Dim noCell As PdfPCell = New PdfPCell(New Phrase("Nro :", bodyFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(noCell)

        Dim nroDato As PdfPCell = New PdfPCell(New Phrase(remito.sucursal.ToString().PadLeft(4, "0") + "-" + remito.nro.ToString().PadLeft(8, "0"), titleFont))
        nroDato.HorizontalAlignment = 2
        nroDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(nroDato)

        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Fecha :", bodyFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(dateCell)

        Dim fechaDato As PdfPCell = New PdfPCell(New Phrase(remito.fecha, titleFont))
        fechaDato.HorizontalAlignment = 2
        fechaDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(fechaDato)


        'Dim billCell As PdfPCell = New PdfPCell(New Phrase("Para :", bodyFont))
        'billCell.HorizontalAlignment = 2
        'billCell.Border = Rectangle.NO_BORDER
        'headertable.AddCell(billCell)

        'Dim paraDato As PdfPCell = New PdfPCell(New Phrase(facturaBE.usr.apellido + " " + facturaBE.usr.nombre, titleFont))
        'paraDato.HorizontalAlignment = 2
        'paraDato.Border = Rectangle.NO_BORDER
        'headertable.AddCell(paraDato)

        document.Add(headertable)

        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(3)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40, 20})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NRO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell2 As PdfPCell = New PdfPCell(New Phrase("ITEM", boldTableFont))
        cell2.HorizontalAlignment = 1
        itemTable.AddCell(cell2)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("CANTIDAD", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)

        Dim numberCell As PdfPCell
        Dim descCell As PdfPCell
        Dim qtyCell As PdfPCell

        For Each pp As BE.RemitoDetalleBE In remito.detalles
            numberCell = New PdfPCell(New Phrase(pp.producto.id, bodyFont))
            numberCell.HorizontalAlignment = 0
            numberCell.PaddingLeft = 10.0F
            itemTable.AddCell(numberCell)

            descCell = New PdfPCell(New Phrase(pp.producto.descripcion, bodyFont))
            descCell.HorizontalAlignment = 0
            descCell.PaddingLeft = 10.0F
            itemTable.AddCell(descCell)

            qtyCell = New PdfPCell(New Phrase(pp.cantidad, bodyFont))
            qtyCell.HorizontalAlignment = 0
            qtyCell.PaddingLeft = 10.0F
            itemTable.AddCell(qtyCell)


        Next

        document.Add(itemTable)

        writer.CloseStream = False 'set the closestream property
        document.Close()
        Return PDFData
    End Function


    Shared Function HojaRutaPDF(hr As BE.HojaRutaBE) As MemoryStream
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

        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/smallMuebla.png"))
        logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim nesthousing As PdfPCell = New PdfPCell(logo)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        headertable.AddCell(nesthousing)

        Dim emptyCell As PdfPCell = New PdfPCell(New Phrase("", titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(emptyCell)

        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("Hoja de Ruta " + hr.letra, titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(invoiceCell)

        Dim noCell As PdfPCell = New PdfPCell(New Phrase("Nro :", bodyFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(noCell)

        Dim nroDato As PdfPCell = New PdfPCell(New Phrase(hr.sucursal.ToString().PadLeft(4, "0") + "-" + hr.nro.ToString().PadLeft(8, "0"), titleFont))
        nroDato.HorizontalAlignment = 2
        nroDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(nroDato)

        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Fecha :", bodyFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(dateCell)

        Dim fechaDato As PdfPCell = New PdfPCell(New Phrase(hr.fecha, titleFont))
        fechaDato.HorizontalAlignment = 2
        fechaDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(fechaDato)

        document.Add(headertable)

        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(2)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NRO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("DESCRIPCION", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)

        Dim numberCell As PdfPCell
        Dim qtyCell As PdfPCell

        Dim row As Integer = 0
        For Each pp As BE.HojaRutaDetalleBE In hr.detalles
            row = row + 1
            numberCell = New PdfPCell(New Phrase(row.ToString, bodyFont))
            numberCell.HorizontalAlignment = 0
            numberCell.PaddingLeft = 10.0F
            itemTable.AddCell(numberCell)

            qtyCell = New PdfPCell(New Phrase(pp.descripcion, bodyFont))
            qtyCell.HorizontalAlignment = 0
            qtyCell.PaddingLeft = 10.0F
            itemTable.AddCell(qtyCell)


        Next

        document.Add(itemTable)

        writer.CloseStream = False 'set the closestream property
        document.Close()
        Return PDFData
    End Function

    Shared Function NotaCreditoPDF(nc As BE.NotaCreditoBE) As MemoryStream
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

        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/smallMuebla.png"))
        logo.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim nesthousing As PdfPCell = New PdfPCell(logo)
        nesthousing.Rowspan = 4
        nesthousing.Padding = 0.0F
        headertable.AddCell(nesthousing)

        Dim emptyCell As PdfPCell = New PdfPCell(New Phrase("", titleFont))
        emptyCell.HorizontalAlignment = 2
        emptyCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(emptyCell)

        Dim invoiceCell As PdfPCell = New PdfPCell(New Phrase("Nota de Credito " + nc.letra, titleFont))
        invoiceCell.HorizontalAlignment = 2
        invoiceCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(invoiceCell)

        Dim noCell As PdfPCell = New PdfPCell(New Phrase("Nro :", bodyFont))
        noCell.HorizontalAlignment = 2
        noCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(noCell)

        Dim nroDato As PdfPCell = New PdfPCell(New Phrase(nc.sucursal.ToString().PadLeft(4, "0") + "-" + nc.nro.ToString().PadLeft(8, "0"), titleFont))
        nroDato.HorizontalAlignment = 2
        nroDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(nroDato)

        Dim dateCell As PdfPCell = New PdfPCell(New Phrase("Fecha :", bodyFont))
        dateCell.HorizontalAlignment = 2
        dateCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(dateCell)

        Dim fechaDato As PdfPCell = New PdfPCell(New Phrase(nc.fecha, titleFont))
        fechaDato.HorizontalAlignment = 2
        fechaDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(fechaDato)


        Dim billCell As PdfPCell = New PdfPCell(New Phrase("Para :", bodyFont))
        billCell.HorizontalAlignment = 2
        billCell.Border = Rectangle.NO_BORDER
        headertable.AddCell(billCell)

        Dim paraDato As PdfPCell = New PdfPCell(New Phrase(nc.usr.apellido + " " + nc.usr.nombre, titleFont))
        paraDato.HorizontalAlignment = 2
        paraDato.Border = Rectangle.NO_BORDER
        headertable.AddCell(paraDato)

        document.Add(headertable)

        'Create body table
        Dim itemTable As PdfPTable = New PdfPTable(5)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100
        itemTable.SetWidths(New Integer() {10, 40, 20, 10, 20})
        ' then set the column's __relative__ widths
        itemTable.SpacingAfter = 40
        itemTable.DefaultCell.Border = Rectangle.BOX
        Dim cell1 As PdfPCell = New PdfPCell(New Phrase("NRO", boldTableFont))
        cell1.HorizontalAlignment = 1
        itemTable.AddCell(cell1)
        Dim cell2 As PdfPCell = New PdfPCell(New Phrase("ITEM", boldTableFont))
        cell2.HorizontalAlignment = 1
        itemTable.AddCell(cell2)
        Dim cell3 As PdfPCell = New PdfPCell(New Phrase("DESCRIPCION", boldTableFont))
        cell3.HorizontalAlignment = 1
        itemTable.AddCell(cell3)
        Dim cell4 As PdfPCell = New PdfPCell(New Phrase("IVA", boldTableFont))
        cell4.HorizontalAlignment = 1
        itemTable.AddCell(cell4)
        Dim cell5 As PdfPCell = New PdfPCell(New Phrase("PRECIO", boldTableFont))
        cell5.HorizontalAlignment = 1
        itemTable.AddCell(cell5)

        Dim numberCell As PdfPCell
        Dim descCell As PdfPCell
        Dim qtyCell As PdfPCell
        Dim ivaCell As PdfPCell
        Dim amtCell As PdfPCell

        For Each pp As BE.NotaCreditoDetalleBE In nc.detalles
            numberCell = New PdfPCell(New Phrase("", bodyFont))
            numberCell.HorizontalAlignment = 0
            numberCell.PaddingLeft = 10.0F
            itemTable.AddCell(numberCell)

            descCell = New PdfPCell(New Phrase("", bodyFont))
            descCell.HorizontalAlignment = 0
            descCell.PaddingLeft = 10.0F
            itemTable.AddCell(descCell)

            qtyCell = New PdfPCell(New Phrase(pp.texto, bodyFont))
            qtyCell.HorizontalAlignment = 0
            qtyCell.PaddingLeft = 10.0F
            itemTable.AddCell(qtyCell)

            ivaCell = New PdfPCell(New Phrase(pp.iva, bodyFont))
            ivaCell.HorizontalAlignment = 0
            ivaCell.PaddingLeft = 10.0F
            itemTable.AddCell(ivaCell)

            amtCell = New PdfPCell(New Phrase(String.Format("{0:C}", pp.valor), bodyFont))
            amtCell.HorizontalAlignment = 1
            itemTable.AddCell(amtCell)
        Next


        ' Table footer
        Dim totalAmtCell1 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell1.Border = Rectangle.LEFT_BORDER And Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell1)
        Dim totalAmtCell2 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell2.Border = Rectangle.TOP_BORDER
        'Rectangle.NO_BORDER //Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell2)
        Dim totalAmtCell3 As PdfPCell = New PdfPCell(New Phrase(""))
        totalAmtCell3.Border = Rectangle.TOP_BORDER
        'Rectangle.NO_BORDER //Rectangle.TOP_BORDER
        itemTable.AddCell(totalAmtCell3)
        Dim totalAmtStrCell As PdfPCell = New PdfPCell(New Phrase("Total", boldTableFont))
        totalAmtStrCell.Border = Rectangle.TOP_BORDER   'Rectangle.NO_BORDER 'Rectangle.TOP_BORDER
        totalAmtStrCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtStrCell)
        Dim totalAmtCell As PdfPCell = New PdfPCell(New Phrase(String.Format("{0:C}", nc.total), boldTableFont))
        totalAmtCell.HorizontalAlignment = 1
        itemTable.AddCell(totalAmtCell)

        document.Add(itemTable)

        Dim barTable As PdfPTable = New PdfPTable(1)
        itemTable.HorizontalAlignment = 0
        itemTable.WidthPercentage = 100

        Dim barCode As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Hosting.HostingEnvironment.MapPath("~/images/bar_code.jpg"))
        'barCode.SetAbsolutePosition(pageSize.GetLeft(300), 140)

        Dim barcell As PdfPCell = New PdfPCell(barCode)
        barcell.Rowspan = 4
        barcell.Padding = 0.0F
        barTable.AddCell(barcell)

        document.Add(barTable)

        writer.CloseStream = False 'set the closestream property
        document.Close()
        Return PDFData
    End Function

End Class
