Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Session.Clear()
            Session.Abandon()
            Session.RemoveAll()
            'Response.Redirect(Request.Cookies("MainConfigPath").Value + "Default.aspx")
            Response.Redirect(Request.Cookies("Default.aspx")
            Response.End()

        End If

    End Sub

End Class