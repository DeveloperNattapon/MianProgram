Option Strict On
Option Explicit On

Imports System.Linq
Public Class Menu
    Inherits System.Web.UI.Page
    'Dim db As New DB_EaglesInternalTestEntities
    Private db As New DB_EaglesInternalEntities


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()
        End If
    End Sub
    
    Protected Sub BindData()
     
        Dim ds = (From c In db.tblMenus
                       Select New With {
                         c.Menu,
                         c.Description,
                         c.UserBy,
                         c.UpdateDate
                        }).ToList()

            ' Assign to GridView
            If ds.Count > 0 Then
                Me.Repeater1.DataSource = ds
                Me.Repeater1.DataBind()
            Else
                Me.Repeater1.DataSource = Nothing
                Me.Repeater1.DataBind()
            End If
    End Sub

    Protected Sub btnSaveChange_Click(sender As Object, e As EventArgs) Handles btnSaveChange.Click
        If String.IsNullOrEmpty(txtMenu.Text) Then
            lblMsg.Text = "* Menu is not empty"
            Exit Sub
        End If

     
        db.tblMenus.Add(New tblMenu() With { _
            .Menu = txtMenu.Text.Trim, _
            .Description = txtDescription.Text.Trim, _
            .UserBy = Session("Name_eng").ToString, _
            .UpdateDate = Now _
             })
            db.SaveChanges()
            'BindData("")
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EditModalScript", "hideModal();", True)
            'ClientScript.RegisterStartupScript(Me.GetType, "PopupScript", "<script>alert('" + String.Format("Delete {0} Successfully.", "") + "');</script>")
            Response.Redirect("menu.aspx")
            'Response.Redirect(Request.Cookies("MainConfigPath").Value + "menu.aspx")


    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lblMsg.Text = ""
        txtMenu.Text = ""
        txtDescription.Text = ""


        Dim menu As String = "User Management"
        Dim id As String = Session("UserID").ToString
        Dim ds1 = From c In db.tblUserMenus Where c.UserID = id And
        c.Menu = menu And c.Save_ = 1
        If ds1.Any Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EditModalScript", "openModal();", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)
        End If
       
    End Sub

    'Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting

    '    Dim strMenu As String = Me.GridView1.DataKeys(e.RowIndex).Value.ToString()

    '    Using db = New DB_EaglesInternalEntities()

    '        Dim menu As String = "User Management"
    '        Dim id As String = Session("UserID").ToString
    '        Dim ds1 = From c In db.tblUserMenu Where c.UserID = id And
    '        c.Menu = menu And c.Save_ = 1
    '        If Not ds1.Any Then

    '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)
    '            Exit Sub
    '        End If


    '        Dim del = (From c In db.tblMenu
    '                   Where c.Menu = strMenu
    '                   Select c).FirstOrDefault()
    '        If Not IsNothing(del) Then
    '            db.tblMenu.Remove(del)
    '        End If

    '        db.SaveChanges()
    '        BindData("")
    '        ClientScript.RegisterStartupScript(Me.GetType, "PopupScript", "<script>alert('" + String.Format("Delete {0} Successfully.", strMenu) + "');</script>")
    '    End Using
    'End Sub

    Sub LinkButton_Click(sender As Object, e As EventArgs)

    End Sub

    'Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow And Not IsNothing(DataBinder.Eval(e.Row.DataItem, "Menu")) Then

    '        Dim lblMenu As Label = DirectCast(e.Row.FindControl("lblMenu"), Label)
    '        If Not IsNothing(lblMenu) Then
    '            lblMenu.Text = DataBinder.Eval(e.Row.DataItem, "Menu").ToString()
    '        End If

    '        Dim lblDescription As Label = DirectCast(e.Row.FindControl("lblDescription"), Label)
    '        If Not IsNothing(lblDescription) Then
    '            lblDescription.Text = DataBinder.Eval(e.Row.DataItem, "Description").ToString()
    '        End If

    '        Dim lblUserBy As Label = DirectCast(e.Row.FindControl("lblUserBy"), Label)
    '        If Not IsNothing(lblUserBy) Then
    '            lblUserBy.Text = DataBinder.Eval(e.Row.DataItem, "UserBy").ToString()
    '        End If

    '        Dim lblUpdateDate As Label = DirectCast(e.Row.FindControl("lblUpdateDate"), Label)
    '        If Not IsNothing(lblUpdateDate) Then
    '            lblUpdateDate.Text = DataBinder.Eval(e.Row.DataItem, "UpdateDate").ToString()
    '        End If

    '        '*** Delete ***'
    '        Dim lnkDelete As LinkButton = DirectCast(e.Row.FindControl("lnkDelete"), LinkButton)
    '        If Not IsNothing(lnkDelete) Then

    '            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Record " + lblMenu.Text + " ?');")

    '        End If

    '    End If
    'End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand

    End Sub
End Class