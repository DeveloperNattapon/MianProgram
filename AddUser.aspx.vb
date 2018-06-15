Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class AddUser
    Inherits System.Web.UI.Page
    Dim db As New DB_EaglesInternalTestEntities
    'Dim db As New DB_EaglesInternalEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showBranch()
            showStatus()

        End If
    End Sub
    Private Sub showBranch()
        ddlBranch.Items.Clear()
        ddlBranch.Items.Add(New ListItem("--select Branch--", ""))
        ddlBranch.AppendDataBoundItems = True

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

    Private Sub showSide(BranchID As String)

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
    Private Sub showDepartment(SideID As String)
        ddlDept.Items.Clear()
        ddlDept.Items.Add(New ListItem("--select Department--", ""))
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
    Private Sub showPosition(dept As String)
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
    Private Sub showStatus()
        ddlStatus.Items.Clear()
        ddlStatus.Items.Add(New ListItem("--select Status--", ""))
        ddlStatus.AppendDataBoundItems = True

        Dim d = From ug In db.Status
                Order By ug.StatusName Ascending
                Select ug.StatusID, ug.StatusName
        Try
            ddlStatus.DataSource = d.ToList
            ddlStatus.DataTextField = "StatusName"
            ddlStatus.DataValueField = "StatusID"
            ddlStatus.DataBind()
            If ddlStatus.Items.Count > 1 Then
                ddlStatus.Enabled = True
            Else
                ddlStatus.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Using db = New DB_EaglesInternalEntities
                Dim user = (From u In db.tblUsers Where u.UserId = txtUser.Value
                Select u).FirstOrDefault

                If Not user Is Nothing Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('ชื่อ user ซ้ำ กรุณาเปลี่ยนใหม่');", True)
                Else
                    AddUser()
                End If
            End Using
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด');", True)
            Clear()

        End Try
    End Sub

    Private Sub AddUser()
        Dim LoginCls As New LoginCls

        Dim Key As String = LoginCls.EncryptPass
        Dim PassEncrypt As String

        PassEncrypt = LoginCls.Encrypt(txtPassworde.Value.Trim, Key)

        ' Insert 
        db.tblUsers.Add(New tblUser() With { _
                 .UserId = txtUser.Value.Trim, _
                 .Password = PassEncrypt, _
                 .Prefix_thai = ddlPrefix.Text.Trim, _
                 .Name_thai = txtNameThai.Value.Trim, _
                 .Surname_thai = txtSurnameThai.Value.Trim, _
                 .Prefix_eng = ddlPrefix_Eng.Text.Trim, _
                 .Name_eng = txtNameEng.Value.Trim.ToUpper, _
                 .Surname_eng = txtSurnameEng.Value.Trim.ToUpper, _
                 .Email = txtEmaile.Value.Trim, _
                 .Position = ddlPosition.Text.Trim, _
                 .Section = ddlSection.Text.Trim, _
                 .Dept = ddlDept.Text.Trim, _
                 .Branch = ddlBranch.Text.Trim, _
                 .CreateBy = Session("Name_eng").ToString, _
                 .StatusID = CType(ddlStatus.Text.Trim.Trim, Integer?), _
                 .CreateDate = Now _
            })
        db.SaveChanges()

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('บันทึกข้อมูล เรียบร้อย')", True)
        Response.Redirect(Request.Cookies("MainConfigPath").Value & "SearchUser.aspx")
        'Response.Redirect("SearchUser.aspx")
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
        ddlSection.Text = ""
        ddlStatus.Text = ""

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