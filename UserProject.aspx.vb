Option Explicit On
Option Strict On


Public Class UserProject
    Inherits System.Web.UI.Page

    'Dim db As New DB_EaglesInternalEntities
    Dim db As New DB_EaglesInternalTestEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showUserProject()
        End If
    End Sub
    Private Sub showUserProject()

        Dim UserId As String = CStr(Session("UserID"))
        Dim key As String = "Eagles"

        Try

            Dim user = (From u In db.tblUsers Join s In db.Status On s.StatusID Equals u.StatusID Where u.UserId = UserId).FirstOrDefault
            'Dim pass As String = LoginCls.Decrypt(user.u.Password, key)
            txtUser.Value = user.u.UserId
            txtPrefix.Value = user.u.Prefix_thai
            txtPrefix_Eng.Value = user.u.Prefix_eng
            txtNameThai.Value = user.u.Name_thai
            txtSurnameThai.Value = user.u.Surname_thai
            txtNameEng.Value = user.u.Name_eng
            txtSurnameEng.Value = user.u.Surname_eng
            txtEmaile.Value = user.u.Email

            'userClass.setBranch = user.u.Branch
            txtBranch.Value = user.u.Branch

            'userClass.setSection = user.u.Section
            txtSection.Value = user.u.Section

            'userClass.setDept = user.u.Dept
            txtDept.Value = user.u.Dept

            'userClass.setPosition = user.u.Position
            txtPosition.Value = user.u.Position

            lbApprove1.Value = user.u.Approve1
            lbApprove2.Value = user.u.Approve2
            txtStatus.Value = user.s.StatusName

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !!!')", True)
        End Try

    End Sub

    Protected Sub btnSave_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnEdit_ServerClick(sender As Object, e As EventArgs)
        Dim menu As String = "User Management"
        Dim id As String = Session("UserID").ToString
        Dim ds1 = From c In db.tblUsers Where c.UserId = id

        If ds1.Any Then
            Response.Write("<script>window.open('EditUser.aspx?UserID=" & id & "',target='_self');</script>")
            'Response.Redirect(Request.Cookies("MainConfigPath").Value + "AddUser.aspx")
            'Response.Redirect("AddUser.aspx")
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('You do not have access')", True)
        End If

    End Sub
End Class