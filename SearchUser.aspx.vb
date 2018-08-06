Option Strict On
Option Explicit On

Imports System.Linq

Public Class SearchUser
    Inherits System.Web.UI.Page
    Private db As New DB_EaglesIntemalEntities
    'Dim db As New DB_EaglesInternalTestEntities



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            BindData()
            selectUser()

        End If
    End Sub
    Protected Sub BindData()

        ' Get data from CUSTOMER
        Dim user = (From c In db.tblUsers
                                Select New With {
                                c.UserId,
                                c.Name_thai,
                                c.Surname_thai,
                                c.Email,
                                c.Branch,
                                c.Section,
                                c.Dept,
                                c.Position}).ToList


        ' Assign to GridView
        If user.Count > 0 Then
            Me.Repeater1.DataSource = user
            Me.Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If

    End Sub
 
    Private Sub selectUser()
        Dim u = From us In db.tblUsers
                Select
                 us.UserId,
                 Name = us.Name_thai + " " + us.Surname_thai




        ddlSearchU.DataSource = u.ToList
        ddlSearchU.DataTextField = "Name"
        ddlSearchU.DataValueField = "UserId"
        ddlSearchU.DataBind()

        If ddlSearchU.Items.Count > 1 Then
            ddlSearchU.Enabled = True
        Else
            ddlSearchU.Enabled = False
        End If
    End Sub
    '------------------------------------------------------------------------------------------------------------

    'Protected Sub BindDataSearch(SearchUser As String)
    '    Using db = New DB_EaglesInternalEntities
    '        ' Get data from CUSTOMER
    '        Dim ds = (From c In db.tblUser Where c.UserId.Contains(SearchUser)
    '                                Select New With {
    '                     c.UserId,
    '                     c.Name_thai,
    '                     c.Surname_thai,
    '                     c.Email,
    '                     c.Section,
    '                     c.Dept,
    '                     c.Branch,
    '                     c.Position
    '                    }).ToList()

    '        ' Assign to GridView
    '        If ds.Count > 0 Then
    '            Me.myGridView.DataSource = ds
    '            Me.myGridView.DataBind()
    '        Else
    '            Me.myGridView.DataSource = Nothing
    '            Me.myGridView.DataBind()
    '        End If
    '    End Using
    'End Sub
    'Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    '    Using db = New DB_EaglesInternalEntities
    '        Dim menu As String = "User Management"
    '        Dim id As String = Session("UserID").ToString
    '        Dim ds1 = From c In db.tblUserMenu Where c.UserID = id And
    '        c.Menu = menu And c.Save_ = 1
    '        If ds1.Any Then
    '            BindDataSearch(txtSearchUser.Text)
    '        Else
    '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)
    '        End If
    '    End Using

    'End Sub
    'Protected Sub myGridView_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles myGridView.RowCommand
    '    Dim index As String = CStr(e.CommandArgument)
    '    Dim LoginCls As New LoginCls

    '    Dim Key As String = LoginCls.EncryptPass
    '    Dim id As String = Session("UserID").ToString
    '    Dim menu As String = "User Management"
    '    If e.CommandName.Equals("EditUser") Then
    '        Using db = New DB_EaglesInternalEntities
    '            Dim ds1 = From c In db.tblUserMenu Where c.UserID = id And
    '            c.Menu = menu And c.Edit_ = 1

    '            If ds1.Any Then
    '                Dim ds = (From c In db.tblUser Where c.UserId = index).SingleOrDefault
    '                txtUserID.Value = ds.UserId
    '                txtPassword.Text = LoginCls.Decrypt(ds.Password, Key)
    '                ddlPrefix.Text = ds.Prefix_thai
    '                txtName_thai.Text = ds.Name_thai
    '                txtSurname_thai.Text = ds.Surname_thai
    '                ddlPrefix_Eng.Text = ds.Prefix_eng
    '                txtName_eng.Text = ds.Name_eng
    '                txtSurname_eng.Text = ds.Surname_eng
    '                txtEmail.Text = ds.Email
    '                txtPosition.Text = ds.Position
    '                ddlSection.Text = ds.Section
    '                txtDept.Text = ds.Dept
    '                ddlBranch.Text = ds.Branch
    '                lbApprove1.Text = ds.Approve1
    '                lbApprove2.Text = ds.Approve2

    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EditModalScript", "openModal();", True)
    '            Else
    '                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)

    '            End If

    '        End Using
    '    End If
    'End Sub

    'Protected Sub btnSaveChange_Click(sender As Object, e As EventArgs) Handles btnSaveChange.Click

    '    Dim LoginCls As New LoginCls

    '    Dim Key As String = LoginCls.EncryptPass
    '    Dim PassEncrypt As String

    '    PassEncrypt = LoginCls.Encrypt(txtPassword.Text.Trim, Key)

    '    Using db = New DB_EaglesInternalEntities

    '        Dim User As tblUser = (From c In db.tblUser _
    '                    Where c.UserId = txtUserID.Value _
    '                    Select c).First()

    '        User.Password = PassEncrypt
    '        User.Prefix_thai = ddlPrefix.Text.Trim
    '        User.Name_thai = txtName_thai.Text.Trim
    '        User.Surname_thai = txtSurname_thai.Text.Trim
    '        User.Prefix_eng = ddlPrefix_Eng.Text.Trim
    '        User.Name_eng = txtName_eng.Text.Trim
    '        User.Surname_eng = txtSurname_eng.Text.Trim
    '        User.Email = txtEmail.Text.Trim
    '        User.Section = ddlSection.Text.Trim
    '        User.Dept = txtDept.Text.Trim
    '        User.Branch = ddlBranch.Text.Trim
    '        User.Position = txtPosition.Text.Trim
    '        User.UserBy = Session("Name_eng").ToString
    '        User.UserDate = Now

    '        db.SaveChanges()
    '        Response.Redirect(Request.Cookies("MainConfigPath").Value + "SearchUser.aspx")
    '        'Response.Redirect("SearchUser.aspx")
    '    End Using

    'End Sub



    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)

        Dim menu As String = "User Management"
        Dim id As String = Session("UserID").ToString
        Dim ds1 = From c In db.tblUserMenus Where c.UserID = id And
        c.Menu = menu And c.Save_ = 1
        If ds1.Any Then

            'Response.Redirect(Request.Cookies("MainConfigPath").Value + "AddUser.aspx")
            Response.Redirect("AddUser.aspx")
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)
        End If


    End Sub

    'Protected Sub myGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles myGridView.PageIndexChanging
    '    myGridView.PageIndex = e.NewPageIndex
    '    BindDataSearch(txtSearchUser.Text)
    'End Sub

    'Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
    'Dim LoginCls As New LoginCls

    'Dim Key As String = LoginCls.EncryptPass

    'Using db = New DB_EaglesInternalEntities
    ' Dim id As String = Session("UserID").ToString

    ' Dim ds = (From c In db.tblUser Where c.UserId = id).SingleOrDefault
    'lblUserID.Text = ds.UserId
    'txtPassword.Text = LoginCls.Decrypt(ds.Password, Key)
    'ddlPrefix.Text = ds.Prefix_thai
    'txtName_thai.Text = ds.Name_thai
    'txtSurname_thai.Text = ds.Surname_thai
    'ddlPrefix_Eng.Text = ds.Prefix_eng
    'txtName_eng.Text = ds.Name_eng
    'txtSurname_eng.Text = ds.Surname_eng
    'txtEmail.Text = ds.Email
    'txtPosition.Text = ds.Position
    'ddlSection.Text = ds.Section
    'txtDept.Text = ds.Dept
    'ddlBranch.Text = ds.Branch
    'lbApprove1.Text = ds.Approve1
    'lbApprove2.Text = ds.Approve2

    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EditModalScript", "openModal();", True)
    ' End Using
    'End Sub
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand

        Dim id As String = Session("UserID").ToString
        Dim menu As String = "User Management"
        Dim EditU As String = CStr(e.CommandArgument)
        If e.CommandName.Equals("edituser") Then
            Dim ds1 = From c In db.tblUserMenus Where c.UserID = id And
           c.Menu = menu And c.Edit_ = 1
            If ds1.Any Then
                Response.Write("<script>window.open('EditUser.aspx?UserID=" & EditU & "',target='_self');</script>")
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธ์การแก้ไข')", True)
            End If


        End If

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim Search As String = ddlSearchU.Text
        SearchUser(Search)
    End Sub

    Protected Sub ddlSearchU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchU.SelectedIndexChanged
        Dim Search As String = ddlSearchU.Text
        SearchUser(Search)
    End Sub

    Private Sub SearchUser(SearchUser As String)

        'Dim user = (From c In DB_EaglesInternalTestEntities Where db.tblUsers = txtSearch.tex)
        Dim user = (From c In db.tblUsers Where c.UserId = SearchUser
        Select New With {
                            c.UserId,
                            c.Name_thai,
                            c.Surname_thai,
                            c.Email,
                            c.Branch,
                            c.Section,
                            c.Dept,
                            c.Position
                               }).ToList



        If user Is Nothing Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('ไม่พบข้อมูล User ที่ค้นหา')", True)
            Exit Sub
            'Else
            '    lblName.Text = User.Prefix_thai & " " & User.Name_thai & " " & User.Surname_thai
        End If

        If user.Count > 0 Then
            Me.Repeater1.DataSource = user
            Me.Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub

    Protected Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound

    End Sub
End Class