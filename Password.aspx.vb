Option Explicit On
Option Strict On

Public Class Password
    Inherits System.Web.UI.Page
    Private db As New DB_EaglesInternalEntities
    'Dim db As New DB_EaglesInternalTestEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim user As String = CStr(Session("UserID"))

        If Not IsPostBack Then
            Dim s = From u In db.tblUsers Join um In db.tblUserMenus On u.UserId Equals um.UserID
                    Where u.UserId = user And u.Dept = "Information Technology" And um.Delete_ = 1 And um.Menu = "User Management"

            If s.Any Then
                If Not IsPostBack Then
                    BindData()
                    selectUser()
                End If

            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "alert('คุณไม่มีสิทธิ์เข้าเมนูนี้ !!')", True)
                ddlSearchU.Enabled = False
                btnSearch.Enabled = False

            End If

        End If
    End Sub
    Protected Sub BindData()

        ' Get data from CUSTOMER

        Dim user = From c In db.tblUsers
                                Select
                                c.UserId,
                                 Name = c.Name_thai + " " + c.Surname_thai,
                                 c.Password



        ' Assign to GridView
        If user.Count > 0 Then
            Me.Repeater1.DataSource = user.ToList
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

    Protected Sub ddlSearchU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchU.SelectedIndexChanged
        Dim Search As String = ddlSearchU.Text
        SearchUser(Search)
    End Sub

    Private Sub SearchUser(SearchUser As String)

        'Dim user = (From c In DB_EaglesInternalTestEntities Where db.tblUsers = txtSearch.tex)
        Dim user = From c In db.tblUsers Where c.UserId = SearchUser
                               Select
                               c.UserId,
                                Name = c.Name_thai + " " + c.Surname_thai,
                                c.Password


        If user.Count > 0 Then
            Me.Repeater1.DataSource = user.ToList
            Me.Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim Search As String = ddlSearchU.Text
        SearchUser(Search)
    End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim pass As String = CStr(e.CommandArgument)

        If e.CommandName.Equals("editPass") Then

            Response.Write("<script>window.open('EditPassword.aspx?UserID=" & pass & "',target='_self');</script>")
        End If
    End Sub

    Protected Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Dim password As String
        'Dim LoginCls As New LoginCls

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim lblPassword As Label = CType(e.Item.FindControl("lblPassword"), Label)

            If Not IsNothing(lblPassword) Then
                password = DataBinder.Eval(e.Item.DataItem, "Password").ToString
                Dim show As String = LoginCls.Decrypt(password, "eagles")
                lblPassword.Text = show
            End If
        End If
    End Sub
End Class