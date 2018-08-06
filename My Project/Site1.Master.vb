Option Strict On
Option Explicit On

Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID").ToString = "" Then
            Response.Redirect(Request.Cookies("MainConfigPath").Value + "Default.aspx")
            Response.End()
        Else
            lblUser.InnerText = Session("Prefix_thai").ToString + " " + Session("Name_thai").ToString + " " + Session("Surname_thai").ToString

        End If

    End Sub


End Class