Option Strict On
Option Explicit On

Public Class EditUser
    Inherits System.Web.UI.Page
    Dim db As New DB_EaglesInternalEntities

    Dim Branch As String
    Dim Dept As String
    Dim Position As String
    Dim Section As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showEditUser()
            showBranch()
        End If

    End Sub
    Private Sub showEditUser()

        Dim UserId As String = Request.QueryString("UserID")
        Dim key As String = ""

        Dim user = (From u In db.tblUser Where u.UserId = UserId).SingleOrDefault
        Dim pass As String = LoginCls.Decrypt(user.Password, key)
        txtUser.Value = user.UserId
        txtPassworde.Value = pass
        ddlPrefix.Text = user.Prefix_thai
        ddlPrefix_Eng.Text = user.Prefix_eng
        txtNameThai.Value = user.Name_thai
        txtSurnameThai.Value = user.Surname_thai
        txtNameEng.Value = user.Name_eng
        txtSurnameEng.Value = user.Surname_eng
        txtEmaile.Value = user.Email
        Branch = user.Branch
        Dept = user.Dept
        Position = user.Position
        Section = user.Section
        lbApprove1.Value = user.Approve1
        lbApprove2.Value = user.Approve2


    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub showBranch()
        ddlBranch.Items.Clear()
        ddlBranch.Items.Add(New ListItem("--select Branch--", ""))
        ddlBranch.AppendDataBoundItems = True

        Dim d = From ug In db.Branch
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

    Private Sub showSide(BranchID As String)

        ddlSection.Items.Clear()
        ddlSection.Items.Add(New ListItem("--select Side--", ""))
        ddlSection.AppendDataBoundItems = True

        Dim d = From ug In db.Side
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
    Private Sub showDepartment(SideID As String)
        ddlDept.Items.Clear()
        ddlDept.Items.Add(New ListItem("--select Position--", ""))
        ddlDept.AppendDataBoundItems = True

        Dim d = From ug In db.Department
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
    Private Sub showPosition(dept As String)
        ddlPosition.Items.Clear()
        ddlPosition.Items.Add(New ListItem("--select Position--", ""))
        ddlPosition.AppendDataBoundItems = True

        Dim d = From ug In db.Position
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

    Protected Sub ddlBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBranch.SelectedIndexChanged
        Dim BranchId As String = ddlBranch.Text
        showSide(BranchId)
    End Sub

    Protected Sub ddlSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSection.SelectedIndexChanged
        Dim Section As String = ddlSection.Text
        showDepartment(Section)
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDept.SelectedIndexChanged
        Dim dept As String = ddlDept.Text
        showPosition(dept)
    End Sub


End Class