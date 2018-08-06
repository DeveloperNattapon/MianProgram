Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Web
Imports System.Web.Configuration
Imports System.Security

Public Class HomePage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'Dim UserID As New HttpCookie("UserID")
            Dim MainConfigPath As New HttpCookie("MainConfigPath")

            Dim CurrentCF = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
            Dim MainConfig = CurrentCF.AppSettings.Settings("Main").Value
            Response.Cookies("MainConfigPath").Value = MainConfig

            'If Session("UserID").ToString = "" Then
            '    Response.Redirect(Request.Cookies("MainConfigPath").Value)
            '    Response.End()
            '    'Else
            '    '    Me.lblLogin.Text = "Welcome : " & Session("Prefix_thai").ToString & " " & Session("Name_thai").ToString & " " & Session("Surname_thai").ToString
            'End If
        End If

    End Sub

    Protected Sub ImgMessenger_Click(sender As Object, e As ImageClickEventArgs) Handles ImgMessenger.Click

        Dim url As String = "http://171.99.132.98:5445/WebMessenger/" + "Login.aspx"
        Dim s As String = "window.open('" & url & "', '_blank');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

    End Sub

    Protected Sub iconus_Click(sender As Object, e As ImageClickEventArgs) Handles iconus.Click
        'Dim url As String = "Default.aspx"
        Dim url As String = Request.Cookies("MainConfigPath").Value + "Default.aspx"
        Dim s As String = "window.open('" & url & "', '_blank');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

    End Sub

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    '    Session.Abandon()
    '    Session.RemoveAll()
    '    Response.Redirect(Request.Cookies("MainConfigPath").Value)

    'End Sub

    Protected Sub Imgreferal_click(sender As Object, e As EventArgs) Handles Imgreferal.Click
        Dim url As String = "http://171.99.132.98:5445/DocumentManagement/" + "Referal.aspx"
        Dim s As String = "window.open('" & url & "', '_blank');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub

    Protected Sub Imgehr_Click(sender As Object, e As ImageClickEventArgs) Handles Imgehr.Click
        'Dim url As String = "http://171.99.132.98:5445/E-HR/" + "index.aspx"
        'Dim s As String = "window.open('" & url & "', '_blank');"
        'ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
        Response.Redirect("http://171.99.132.98:5445/E-HR/index.aspx")
    End Sub
    Protected Sub Imgewh_Click(sender As Object, e As ImageClickEventArgs) Handles Imgewh.Click
       
        Response.Redirect("http://171.99.132.98:5445/WMSweb/")
    End Sub
    Protected Sub Imageit_Click(sender As Object, e As ImageClickEventArgs) Handles Imageit.Click
        Dim url As String = "http://171.99.132.98:5445/ITJOB_V.1.0.1/" + "Login.aspx"
        Dim s As String = "window.open('" & url & "', '_blank');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub
End Class