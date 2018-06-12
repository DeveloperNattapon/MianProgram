Option Strict On
Option Explicit On

Public Class EditUser
    Inherits System.Web.UI.Page
    'Dim db As New DB_EaglesInternalEntities
    Dim db As New DB_EaglesInternalTestEntities
    Dim Branch As String
    Dim Dept As String
    Dim Position As String
    Dim Section As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showEditUser()
            showBranch()
            showSide()
            showDepartment()
            showPosition()
        End If

    End Sub
    Private Sub showEditUser()

        Dim UserId As String = Request.QueryString("UserID")
        Dim key As String = "Eagles"

        Dim user = (From u In db.tblUsers Where u.UserId = UserId).SingleOrDefault
        Dim pass As String = LoginCls.Decrypt(user.Password, key)
        txtUser.Value = user.UserId
        'txtPassworde.Value = pass
        ddlPrefix.Text = user.Prefix_thai
        ddlPrefix_Eng.Text = user.Prefix_eng
        txtNameThai.Value = user.Name_thai
        txtSurnameThai.Value = user.Surname_thai
        txtNameEng.Value = user.Name_eng
        txtSurnameEng.Value = user.Surname_eng
        txtEmaile.Value = user.Email
        ddlBranch.Text = user.Branch
        ddlDept.Text = user.Dept
        ddlPosition.Text = user.Position
        ddlSection.Text = user.Section
        lbApprove1.Value = user.Approve1
        lbApprove2.Value = user.Approve2
       

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        EditUser()
    End Sub

    Private Sub showBranch()
        'ddlBranch.Items.Clear()
        'ddlBranch.Items.Add(New ListItem("--select Branch--", ""))
        'ddlBranch.AppendDataBoundItems = True

        Dim d = From ug In db.Branches
                Order By ug.BranchName Ascending
                Select ug.BranchID, ug.BranchName
        Try
            ddlBranch.DataSource = d.ToList
            ddlBranch.DataTextField = "BranchName"
            ddlBranch.DataValueField = "BranchID"
            ddlBranch.DataBind()
            If ddlBranch.Items.Count > 1 Then
                ddlBranch.Enabled = True
            Else
                ddlBranch.Enabled = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub showSide()

        'ddlSection.Items.Clear()
        'ddlSection.Items.Add(New ListItem("--select Side--", ""))
        'ddlSection.AppendDataBoundItems = True

        Dim d = From ug In db.Sides
                Order By ug.SideName Ascending
                Select ug.SideID, ug.SideName
        Try
            ddlSection.DataSource = d.ToList
            ddlSection.DataTextField = "SideName"
            ddlSection.DataValueField = "SideID"
            ddlSection.DataBind()
            If ddlSection.Items.Count > 1 Then
                ddlSection.Enabled = True
            Else
                ddlSection.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub showSideList(BranchID As String)

        ddlSection.Items.Clear()
        ddlSection.Items.Add(New ListItem("--select Side--", ""))
        ddlSection.AppendDataBoundItems = True

        Dim d = From ug In db.Sides
                Where ug.BranchID = BranchID
                Order By ug.SideName Ascending
                Select ug.SideID, ug.SideName
        Try
            ddlSection.DataSource = d.ToList
            ddlSection.DataTextField = "SideName"
            ddlSection.DataValueField = "SideID"
            ddlSection.DataBind()
            If ddlSection.Items.Count > 1 Then
                ddlSection.Enabled = True
            Else
                ddlSection.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub showDepartment()
        'ddlDept.Items.Clear()
        'ddlDept.Items.Add(New ListItem("--select Position--", ""))
        'ddlDept.AppendDataBoundItems = True

        Dim d = From ug In db.Departments
                Order By ug.DepartmentName Ascending
                Select ug.DepartmentID, ug.DepartmentName
        Try
            ddlDept.DataSource = d.ToList
            ddlDept.DataTextField = "DepartmentName"
            ddlDept.DataValueField = "DepartmentID"
            ddlDept.DataBind()
            If ddlDept.Items.Count > 1 Then
                ddlDept.Enabled = True
            Else
                ddlDept.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub showDepartmentList(SideID As String)
        ddlDept.Items.Clear()
        ddlDept.Items.Add(New ListItem("--select Position--", ""))
        ddlDept.AppendDataBoundItems = True

        Dim d = From ug In db.Departments
                Where ug.SideID = SideID
                Order By ug.DepartmentName Ascending
                Select ug.DepartmentID, ug.DepartmentName
        Try
            ddlDept.DataSource = d.ToList
            ddlDept.DataTextField = "DepartmentName"
            ddlDept.DataValueField = "DepartmentID"
            ddlDept.DataBind()
            If ddlDept.Items.Count > 1 Then
                ddlDept.Enabled = True
            Else
                ddlDept.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub showPositionList(dept As String)
        ddlPosition.Items.Clear()
        ddlPosition.Items.Add(New ListItem("--select Position--", ""))
        ddlPosition.AppendDataBoundItems = True

        Dim d = From ug In db.Positions
                Where ug.DepartmentID = dept
                Order By ug.PositionName Ascending
                Select ug.PositionID, ug.PositionName
        Try
            ddlPosition.DataSource = d.ToList
            ddlPosition.DataTextField = "PositionName"
            ddlPosition.DataValueField = "PositionID"
            ddlPosition.DataBind()
            If ddlPosition.Items.Count > 1 Then
                ddlPosition.Enabled = True
            Else
                ddlPosition.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub showPosition()
        'ddlPosition.Items.Clear()
        'ddlPosition.Items.Add(New ListItem("--select Position--", ""))
        'ddlPosition.AppendDataBoundItems = True

        Dim d = From ug In db.Positions
                Order By ug.PositionName Ascending
                Select ug.PositionID, ug.PositionName
        Try
            ddlPosition.DataSource = d.ToList
            ddlPosition.DataTextField = "PositionName"
            ddlPosition.DataValueField = "PositionID"
            ddlPosition.DataBind()
            If ddlPosition.Items.Count > 1 Then
                ddlPosition.Enabled = True
            Else
                ddlPosition.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim BranchId As String = ddlBranch.Text
        showSideList(BranchId)
    End Sub

    Protected Sub ddlSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSection.SelectedIndexChanged
        Dim Section As String = ddlSection.Text
        showDepartmentList(Section)
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDept.SelectedIndexChanged
        Dim dept As String = ddlDept.Text
        showPositionList(dept)
    End Sub

    Private Sub EditUser()
        Try


            Dim User As tblUser = (From c In db.tblUsers Where c.UserId = txtUser.Value _
                           Select c).First()

            User.Prefix_thai = ddlPrefix.Text.Trim
            User.Name_thai = txtNameThai.Value
            User.Surname_thai = txtSurnameThai.Value
            User.Prefix_eng = ddlPrefix_Eng.Text
            User.Name_eng = txtNameEng.Value
            User.Surname_eng = txtSurnameEng.Value
            User.Email = txtEmaile.Value
            User.Section = ddlSection.Text
            User.Dept = ddlDept.Text
            User.Branch = ddlBranch.Text
            User.Position = ddlPosition.Text
            User.UserBy = Session("Name_eng").ToString
            User.UserDate = Now

            db.SaveChanges()
            'Response.Redirect(Request.Cookies("MainConfigPath").Value + "SearchUser.aspx")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล เรียบร้อย')", True)
            Clear()
            Response.Redirect("SearchUser.aspx")
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !!!')", True)
        End Try
       
    End Sub

    Private Sub Clear()
        txtUser.Value = ""
        ddlPrefix.Text = ""
        txtNameThai.Value = ""
        txtSurnameThai.Value = ""
        ddlPrefix_Eng.Text = ""
        txtNameEng.Value = ""
        txtSurnameEng.Value = ""
        txtEmaile.Value = ""
        ddlPosition.Text = ""
        ddlDept.Text = ""
        ddlBranch.Text = ""

    End Sub
End Class