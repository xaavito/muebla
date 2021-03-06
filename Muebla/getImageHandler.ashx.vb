﻿Imports System.Web
Imports System.Web.Services
Imports System.IO

Public Class getImageHandler
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try
            Dim imagen As Byte()

            Dim request As HttpRequest = context.Request
            Dim id As String = request.QueryString("id")
            Dim idInt As Integer = Integer.Parse(id)

            imagen = BLL.ProductoBLL.getImagenProducto(idInt)

            context.Response.ContentType = "image/JPEG"
            context.Response.BinaryWrite(imagen)
            context.Response.Buffer = True
            context.Response.Charset = ""
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            context.Response.ContentType = "application/octet-stream"
            context.Response.AddHeader("content-disposition", "attachment;filename=imagen.jpg")
            context.Response.BinaryWrite(imagen)
            context.Response.Flush()
            context.Response.End()
        Catch ex As Exception
            'no pienso hacer nada aca
        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class