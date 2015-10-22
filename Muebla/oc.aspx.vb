Public Class oc
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (rdoDownload.Checked) Then
        DownloadPDF(Util.PDFGenerator.CreatePDF())
        'Else
        'Dim MS As MemoryStream = CreatePDF()
        'MS.Position = 0
        'Dim PDFData as byte() = new byte[ms.Length]
        'ms.Read(PDFData, 0, (int)ms.Length)
    End Sub

    Protected Sub DownloadPDF(ByVal PDFData As System.IO.MemoryStream)
        'Clear response content & headers
        Response.Clear()
        Response.ClearContent()
        Response.ClearHeaders()
        Response.ContentType = "application/pdf"
        Response.Charset = String.Empty
        Response.Cache.SetCacheability(System.Web.HttpCacheability.Public)
        Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Receipt-{0}.pdf", "1"))
        Response.OutputStream.Write(PDFData.GetBuffer(), 0, PDFData.GetBuffer().Length)
        Response.OutputStream.Flush()
        Response.OutputStream.Close()
        Response.End()
    End Sub

End Class