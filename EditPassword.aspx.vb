Option Explicit On
Option Strict On

Public Class EditPassword
    Inherits System.Web.UI.Page
    Dim db As New DB_EaglesInternalEntities
    'Dim db As New DB_EaglesInternalTestEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs)
        selectPass()

    End Sub

    Private Sub selectPass()
        'Dim pass_word As String
        Dim UserId As String = Request.QueryString("UserID")
        Dim LoginCls As New LoginCls

        Dim Key As String = LoginCls.EncryptPass
        Dim PassEncrypt As String

        PassEncrypt = LoginCls.Encrypt(txtPass.Value.Trim, Key)
        Dim pass = (From p In db.tblUsers Where p.Password = PassEncrypt And p.UserId = UserId
                   Select p).Count
        If pass > 0 Then
            editPasswordr()

        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('รหัสผ่านไม่ถูกต้อง !!!')", True)
        End If

    End Sub

    Private Sub editPasswordr()
        Dim UserId As String = Request.QueryString("UserID")
        Dim User_id As String = CStr(Session("UserID"))
        Dim LoginCls As New LoginCls

        Dim Key As String = LoginCls.EncryptPass
        Dim PassEncrypt As String

        PassEncrypt = LoginCls.Encrypt(txtPasswordeName.Value.Trim, Key)
        Try
            Dim User As tblUser = (From c In db.tblUsers Where c.UserId = UserId.ToUpper _
                      Select c).First()
            User.Password = PassEncrypt
            db.SaveChanges()

            If UserId = User_id.ToUpper Then
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูลรหัสผ่าน เรียบร้อย')", True)
                'LogOut()
                Response.Redirect("Logout.aspx")
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('แก้ไขข้อมูลรหัสผ่าน เรียบร้อย')", True)
            End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !!!')", True)
        End Try
       
    End Sub

    'Private Sub LogOut()

    '    Session.Clear()
    '    Session.Abandon()
    '    Session.RemoveAll()
    '    'Response.Redirect(Request.Cookies("MainConfigPath").Value + "Default.aspx")
    '    Response.Redirect("Default.aspx")
    '    Response.End()
    'End Sub
End Class