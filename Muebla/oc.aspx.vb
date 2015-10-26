Imports System.IO

Public Class oc
    Inherits ExtendedPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO TESTEAR ESTO
        Util.Mailer.sendMailWithAttachment("javiermartingonzalez@gmail.com", "test", "a ver...", Util.PDFGenerator.CreatePDF())
        'DownloadPDF(Util.PDFGenerator.CreatePDF())
        'Dim ms As MemoryStream = Util.PDFGenerator.CreatePDF()
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