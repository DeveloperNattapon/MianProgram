Option Strict On
Option Explicit On

Imports System.Linq

Public Class Permission
    Inherits System.Web.UI.Page
    Dim db As New DB_EaglesInternalTestEntities
    'Dim db As New DB_EaglesInternalEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadCombo()
        End If
    End Sub

    Protected Sub LoadCombo()



        Dim ds = (From c In db.tblUsers
                    Select New With
                           {
                               Key .name = c.Prefix_thai & " " & c.Name_thai & " " & c.Surname_thai,
                               c.UserId
                           }).ToList()

        ' Assign to GridView
        If ds.Count > 0 Then
            With ddlCopyUser
                .DataSource = ds
                .DataTextField = "name"
                .DataValueField = "UserId"
                .DataBind()
            End With

        End If

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim menu As String = "User Management"
        Dim id As String = Session("UserID").ToString
        Dim d3 = From c In db.tblUserMenus Where c.UserID = id And
        c.Menu = menu And c.Save_ = 1
        If Not d3.Any Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)
            Exit Sub
        End If

        Dim ds1 = (From c In db.tblUsers Where c.UserId = txtSearchUser.Text.Trim
            ).FirstOrDefault
        If ds1 Is Nothing Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล User ที่ค้นหา')", True)
            Exit Sub
        Else
            lblName.Text = ds1.Prefix_thai & " " & ds1.Name_thai & " " & ds1.Surname_thai
        End If

        Dim ds2 = (From c In db.tblUserMenus Where c.UserID = txtSearchUser.Text.Trim
          ).FirstOrDefault
        If ds2 IsNot Nothing Then
            GridDatabind()
        Else
            Dim ds3 = (From c In db.tblMenus Select c).ToList
            If ds3.Count > 0 Then

                For Each item In ds3
                    ' Insert
                    db.tblUserMenus.Add(New tblUserMenu() With { _
                             .UserID = txtSearchUser.Text.Trim, _
                             .Menu = item.Menu, _
                             .Status = "None", _
                             .Read_ = 0, _
                             .Save_ = 0, _
                             .Edit_ = 0, _
                             .Delete_ = 0, _
                             .UserBy = Session("Name_eng").ToString, _
                             .LastUpdate = Now _
                               })
                    db.SaveChanges()
                Next
                GridDatabind()
            End If

        End If

    End Sub
    Protected Sub GridDatabind()
   
        Dim ds = (From c In db.tblMenus Group Join d In (
                     From cc In db.tblUserMenus Where cc.UserID = txtSearchUser.Text.Trim
                     Select New With {cc})
                     On c.Menu Equals d.cc.Menu Into Group
                     From f In Group.DefaultIfEmpty() _
                     Select New With { _
                     .Menu = c.Menu, _
                     .Description = c.Description, _
                     .Status = If(f.cc.Status = Nothing, "None", f.cc.Status) _
                       }).ToList()

            If ds.Count > 0 Then
                Me.GridView1.DataSource = ds
                Me.GridView1.DataBind()
            End If

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow And Not IsNothing(DataBinder.Eval(e.Row.DataItem, "Menu")) Then

            Dim lblMenu As Label = DirectCast(e.Row.FindControl("lblMenu"), Label)
            If Not IsNothing(lblMenu) Then
                lblMenu.Text = DataBinder.Eval(e.Row.DataItem, "Menu").ToString()
            End If

            Dim lblDescription As Label = DirectCast(e.Row.FindControl("lblDescription"), Label)
            If Not IsNothing(lblDescription) Then
                lblDescription.Text = DataBinder.Eval(e.Row.DataItem, "Description").ToString()
            End If

            Dim lblStatus As Label = DirectCast(e.Row.FindControl("lblStatus"), Label)
            If Not IsNothing(lblStatus) Then
                lblStatus.Text = DataBinder.Eval(e.Row.DataItem, "Status").ToString()
            End If

            Dim ddlStatus As DropDownList = CType(e.Row.FindControl("ddlStatus"), DropDownList)
            If Not IsNothing(ddlStatus) Then
                With ddlStatus
                    .Items.Add("None")
                    .Items.Add("Read")
                    .Items.Add("Save")
                    .Items.Add("Edit")
                    .Items.Add("Delete")
                End With
                '    ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(e.Row.DataItem("Status")))
            End If

        End If
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        Me.GridDatabind()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim Menu As String = CStr(GridView1.DataKeys(e.RowIndex).Values(0))
        Dim UserID As String = txtSearchUser.Text.Trim
        Dim Stattus As String = TryCast(row.FindControl("ddlStatus"), DropDownList).Text
        Dim sread As Integer
        Dim ssave As Integer
        Dim sedit As Integer
        Dim sdelete As Integer


        Dim cs = (From c In db.tblUserMenus Where c.Menu = Menu And c.UserID = UserID _
                                    Select c).FirstOrDefault()
        If cs IsNot Nothing Then
            'cs.UserID = UserID.ToUpper
            cs.Menu = Menu
            cs.Status = Stattus
            If Stattus = "None" Then
                cs.Read_ = 0
                cs.Save_ = 0
                cs.Edit_ = 0
                cs.Delete_ = 0
            End If
            If Stattus = "Read" Then
                cs.Read_ = 1
                cs.Save_ = 0
                cs.Edit_ = 0
                cs.Delete_ = 0
            End If
            If Stattus = "Save" Then
                cs.Read_ = 1
                cs.Save_ = 1
                cs.Edit_ = 0
                cs.Delete_ = 0
            End If
            If Stattus = "Edit" Then
                cs.Read_ = 1
                cs.Save_ = 1
                cs.Edit_ = 1
                cs.Delete_ = 0
            End If
            If Stattus = "Delete" Then
                cs.Read_ = 1
                cs.Save_ = 1
                cs.Edit_ = 1
                cs.Delete_ = 1
            End If
            cs.UserBy = Session("Name_eng").ToString.ToUpper
            cs.LastUpdate = Now
            db.SaveChanges()
        Else

            If Stattus = "None" Then
                sread = 0
                ssave = 0
                sedit = 0
                sdelete = 0
            End If
            If Stattus = "Read" Then
                sread = 1
                ssave = 0
                sedit = 0
                sdelete = 0
            End If
            If Stattus = "Save" Then
                sread = 1
                ssave = 1
                sedit = 0
                sdelete = 0
            End If
            If Stattus = "Edit" Then
                sread = 1
                ssave = 1
                sedit = 1
                sdelete = 0
            End If
            If Stattus = "Delete" Then
                sread = 1
                ssave = 1
                sedit = 1
                sdelete = 1
            End If

            Dim ca = db.tblUserMenus.Add(New tblUserMenu() With { _
                 .UserID = UserID, _
                 .Menu = Menu, _
                 .Status = Stattus, _
                 .Read_ = sread, _
                 .Save_ = ssave, _
                 .Edit_ = sedit, _
                 .Delete_ = sdelete, _
                 .UserBy = Session("Name_eng").ToString.ToUpper, _
                 .LastUpdate = Now
            })
            db.SaveChanges()

        End If
       
        GridView1.EditIndex = -1
        Me.GridDatabind()

    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        Me.GridDatabind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Dim menu As String = "User Management"
            Dim id As String = Session("UserID").ToString
        Dim ds2 = From c In db.tblUserMenus Where c.UserID = id And
            c.Menu = menu And c.Save_ = 1
            If Not ds2.Any Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)
                Exit Sub
            End If

        Dim ds1 = (From c In db.tblUsers Where c.UserId = ddlCopyUser.SelectedValue Select c).FirstOrDefault

        Dim ds = (From c In db.tblUserMenus Where c.UserID = ds1.UserId).ToList
            If ds.Count > 0 Then
            Dim del = (From c In db.tblUserMenus Where c.UserID = txtSearchUser.Text).ToList

                For Each c In del
                db.tblUserMenus.Remove(c)
                Next
                db.SaveChanges()

                For Each item In ds
                    ' Insert
                db.tblUserMenus.Add(New tblUserMenu() With { _
                             .UserID = txtSearchUser.Text.Trim.ToUpper, _
                             .Menu = item.Menu, _
                             .Status = item.Status, _
                             .Read_ = item.Read_, _
                             .Save_ = item.Save_, _
                             .Edit_ = item.Edit_, _
                             .Delete_ = item.Delete_, _
                             .UserBy = Session("Name_eng").ToString.ToUpper, _
                             .LastUpdate = Now _
                               })
                    db.SaveChanges()
                Next
                GridDatabind()
            End If


    End Sub
End Class