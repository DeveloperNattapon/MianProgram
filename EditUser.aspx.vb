Option Strict On
Option Explicit On

Public Class EditUser
    Inherits System.Web.UI.Page
    'Dim db As New DB_EaglesInternalEntities
    Dim db As New DB_EaglesInternalTestEntities

    Private userClass As New User



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showEditUser()
            showBranch()
            showSide()
            showDepartment()
            showPosition()
            showStatus()

        End If

    End Sub
    Private Sub showEditUser()

        Dim UserId As String = Request.QueryString("UserID")
        Dim key As String = "Eagles"

        Try

            Dim user = (From u In db.tblUsers Join s In db.Status On s.StatusID Equals u.StatusID Where u.UserId = UserId).FirstOrDefault
            'Dim pass As String = LoginCls.Decrypt(user.u.Password, key)
            txtUser.Value = user.u.UserId
            ddlPrefix.Text = user.u.Prefix_thai
            ddlPrefix_Eng.Text = user.u.Prefix_eng
            txtNameThai.Value = user.u.Name_thai
            txtSurnameThai.Value = user.u.Surname_thai
            txtNameEng.Value = user.u.Name_eng
            txtSurnameEng.Value = user.u.Surname_eng
            txtEmaile.Value = user.u.Email

            userClass.setBranch = user.u.Branch
            ddlBranch.Text = userClass.setBranch

            userClass.setSection = user.u.Section
            ddlSection.Text = userClass.setSection

            userClass.setDept = user.u.Dept
            ddlDept.Text = userClass.setDept

            userClass.setPosition = user.u.Position
            ddlPosition.Text = userClass.setPosition
     
            lbApprove1.Value = user.u.Approve1
            lbApprove2.Value = user.u.Approve2
            ddlStatus.Text = user.s.StatusName

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !!!')", True)
        End Try
       
       

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        EditUser(ddlBranch.Text)
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
    Private Sub showStatus()
        'ddlStatus.Items.Clear()
        'ddlStatus.Items.Add(New ListItem("--select Status--", ""))
        'ddlStatus.AppendDataBoundItems = True

        Dim d = From ug In db.Status
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

    Private Sub EditUser(Branch As String)
        Try
            'If userClass.setBranch <> Branch Then
            '    MsgBox(Branch)
            'ElseIf ddlBranch.Text = Branch Then
            '    MsgBox("เท่ากับ")
            'End If

            Dim User As tblUser = (From c In db.tblUsers Where c.UserId = txtUser.Value _
                           Select c).First()

            User.Prefix_thai = ddlPrefix.Text.Trim
            User.Name_thai = txtNameThai.Value
            User.Surname_thai = txtSurnameThai.Value
            User.Prefix_eng = ddlPrefix_Eng.Text
            User.Name_eng = txtNameEng.Value
            User.Surname_eng = txtSurnameEng.Value
            User.Email = txtEmaile.Value
            User.Branch = ddlBranch.Text
            User.Section = ddlSection.Text
            User.Dept = ddlDept.Text
            User.Position = ddlPosition.Text
            User.UserBy = Session("Name_eng").ToString
            User.UserDate = Now
            User.StatusID = CType(ddlStatus.Text, Integer?)

            db.SaveChanges()
            'Response.Redirect(Request.Cookies("MainConfigPath").Value + "SearchUser.aspx")
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูล เรียบร้อย')", True)
            'Clear()
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
        ddlBranch.Text = ""
        ddlSection.Text = ""
        ddlDept.Text = ""
        ddlPosition.Text = ""
        ddlStatus.Text = ""
        
    End Sub

    
End Class