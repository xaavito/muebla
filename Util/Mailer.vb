Imports System.Net.Mail
Public Class Mailer

    Public Sub init()

    End Sub

    Public Shared Sub sendMail(ByVal para As String,
                               ByVal referencia As String,
                               ByVal contenido As String)

        Try
            Dim MyMailMessage As New MailMessage()

            'From requires an instance of the MailAddress type
            MyMailMessage.From = New MailAddress("mueblamuebles@gmail.com")

            'To is a collection of MailAddress types
            MyMailMessage.To.Add(para)

            MyMailMessage.Subject = referencia
            MyMailMessage.Body = contenido
            
            'Create the SMTPClient object and specify the SMTP GMail server
            Dim SMTPServer As New SmtpClient("smtp.gmail.com")
            SMTPServer.Port = 587
            SMTPServer.UseDefaultCredentials = False
            SMTPServer.Credentials = New System.Net.NetworkCredential("mueblamuebles@gmail.com", "Mu3bl@mU38Les")
            SMTPServer.EnableSsl = True

            SMTPServer.Send(MyMailMessage)

        Catch ex As SmtpException
            Throw New MailFalloException
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub sendMailWithAttachment(ByVal para As String,
                               ByVal referencia As String,
                               ByVal contenido As String,
                               ByVal adjunto As System.IO.Stream)

        Try
            Dim MyMailMessage As New MailMessage()

            'From requires an instance of the MailAddress type
            MyMailMessage.From = New MailAddress("mueblamuebles@gmail.com")

            'To is a collection of MailAddress types
            MyMailMessage.To.Add(para)

            MyMailMessage.Subject = referencia
            MyMailMessage.Body = contenido
            MyMailMessage.Attachments.Add(New Attachment(adjunto, "PEPE.PDF", "application/pdf"))

            'Create the SMTPClient object and specify the SMTP GMail server
            Dim SMTPServer As New SmtpClient("smtp.gmail.com")
            SMTPServer.Port = 587
            SMTPServer.UseDefaultCredentials = False
            SMTPServer.Credentials = New System.Net.NetworkCredential("mueblamuebles@gmail.com", "Mu3bl@mU38Les")
            SMTPServer.EnableSsl = True

            SMTPServer.Send(MyMailMessage)

        Catch ex As SmtpException
            Throw New MailFalloException
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

