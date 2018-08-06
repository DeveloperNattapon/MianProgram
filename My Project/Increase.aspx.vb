Public Class Increase
    Inherits System.Web.UI.Page
    'Dim db As New DB_EaglesInternalEntities
    Dim db As New DB_EaglesInternalTestEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            showBranch()
            showPosition()
            showSide()
            showList()
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

    Private Sub showSide()
        ddlSide.Items.Clear()
        ddlSide.Items.Add(New ListItem("--select Side--", ""))
        ddlSide.AppendDataBoundItems = True

        Dim d = From ug In db.Sides
                Order By ug.SideName Ascending
                Select ug.SideID, ug.SideName
        Try
            ddlSide.DataSource = d.ToList
            ddlSide.DataTextField = "SideName"
            ddlSide.DataValueField = "SideID"
            ddlSide.DataBind()
            If ddlSide.Items.Count > 1 Then
                ddlSide.Enabled = True
            Else
                ddlSide.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub showPosition()
        ddlPosition.Items.Clear()
        ddlPosition.Items.Add(New ListItem("--select Position--", ""))
        ddlPosition.AppendDataBoundItems = True

        Dim d = From ug In db.Departments
                Order By ug.DepartmentName Ascending
                Select ug.DepartmentID, ug.DepartmentName
        Try
            ddlPosition.DataSource = d.ToList
            ddlPosition.DataTextField = "DepartmentName"
            ddlPosition.DataValueField = "DepartmentID"
            ddlPosition.DataBind()
            If ddlPosition.Items.Count > 1 Then
                ddlPosition.Enabled = True
            Else
                ddlPosition.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnBranch_Click(sender As Object, e As EventArgs)
        checkBranchID()
        'Order By ug.BranchName Descending

    End Sub
    Private Sub checkBranchID()
        Dim key As String
        Dim runno As Integer
        Dim BranchID As String
        Dim codeId As Integer
        'Dim type As String = ddlSide.Text

        key = Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))
        Dim u = (From ci In db.RunNoes
                 Where ci.Name = key Select ci).FirstOrDefault
        If Not u Is Nothing Then
            runno = CInt(u.RunNo1)
            codeId = runno + 1
            BranchID = (Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0")))
            addBranch(BranchID)
            upDateID(codeId, key)
            clear()
        Else
            db.RunNoes.Add(New RunNo With
                                     {
                                         .Name = key, _
                                         .RunNo1 = CType("0", Integer?) _
                                     })
            db.SaveChanges()

            runno = CInt("0")
            codeId = runno + 1
            BranchID = Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            addBranch(BranchID)
            upDateID(codeId, key)
            clear()

        End If

    End Sub
    Private Sub addBranch(BranID As String)
        db.Branches.Add(New Branch With
                        {.BranchID = BranID, _
                         .BranchName = txtBranch.Value
                       })
        db.SaveChanges()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึกข้อมูลสาขาสำเร็จ !');", True)

    End Sub

    Protected Sub btnside_Click(sender As Object, e As EventArgs)
        checkIDside()

    End Sub

    Private Sub checkIDside()
        Dim key As String
        Dim runno As Integer
        Dim RJITno As String
        Dim codeId As Integer

        key = "s-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))
        Dim u = (From ci In db.RunNoes
                 Where ci.Name = key Select ci).FirstOrDefault
        If Not u Is Nothing Then
            runno = CInt(u.RunNo1)
            codeId = runno + 1
            RJITno = "s-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            addside(RJITno)
            upDateID(codeId, key)
            clear()
        Else
            db.RunNoes.Add(New RunNo With
                                     {
                                         .Name = key, _
                                         .RunNo1 = CType("0", Integer?) _
                                     })
            db.SaveChanges()

            runno = CInt("0")
            codeId = runno + 1
            RJITno = "s-" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))

            addside(RJITno)
            upDateID(codeId, key)
            clear()
        End If

    End Sub
    Private Sub addside(sideID As String)

        Dim u = (From ci In db.Sides
                 Where ci.SideID = sideID Select ci).FirstOrDefault
        If Not u Is Nothing Then

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('มีรหัสซ้ำ !');", True)
        Else
            db.Sides.Add(New Side With {
                       .SideID = sideID, _
                      .SideName = txtside.Value, _
                      .CreateBy = CStr(Session("UserID")), _
                      .CreateDate = Now, _
                      .BranchID = ddlBranch.Text
                    })
            db.SaveChanges()

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึกข้อมูลฝ่ายสำเร็จ !');", True)

        End If

    End Sub
    Protected Sub btndepartment_Click(sender As Object, e As EventArgs)
        checkIDdepartment()

    End Sub

    Private Sub checkIDdepartment()
        Dim key As String
        Dim runno As Integer
        Dim RJITno As String
        Dim codeId As Integer

        key = "d" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))

        Dim u = (From ci In db.RunNoes
                 Where ci.Name = key Select ci).FirstOrDefault
        If Not u Is Nothing Then
            runno = CInt(u.RunNo1)
            codeId = runno + 1
            RJITno = "d" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            addDepartment(RJITno)
            upDateID(codeId, key)
            clear()
        Else
            db.RunNoes.Add(New RunNo With
                                     {
                                         .Name = key, _
                                         .RunNo1 = CType("0", Integer?) _
                                     })
            db.SaveChanges()

            runno = CInt("0")
            codeId = runno + 1
            RJITno = "d" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            addDepartment(RJITno)
            upDateID(codeId, key)
            clear()
        End If

    End Sub
    Private Sub addDepartment(departmentID As String)
        Try

            db.Departments.Add(New Department With {
                               .DepartmentID = departmentID, _
                               .DepartmentName = txtdepartment.Value, _
                                .CreateDate = Now, _
                                .CreateBy = CStr(Session("UserID")), _
                               .SideID = ddlSide.Text
                          })

            db.SaveChanges()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึกข้อมูลแผนกสำเร็จ !');", True)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด!');", True)
        End Try


    End Sub
    Protected Sub btnPosition_Click(sender As Object, e As EventArgs)
        checkIDPosition()

    End Sub
    Private Sub checkIDPosition()
        Dim key As String
        Dim runno As Integer
        Dim RJITno As String
        Dim codeId As Integer

        key = "P" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM")))
        Dim u = (From ci In db.RunNoes
                 Where ci.Name = key Select ci).FirstOrDefault
        If Not u Is Nothing Then
            runno = CInt(u.RunNo1)
            codeId = runno + 1
            RJITno = "P" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            addPosition(RJITno)
            upDateID(codeId, key)
            clear()
        Else
            db.RunNoes.Add(New RunNo With
                                     {
                                         .Name = key, _
                                         .RunNo1 = CType("0", Integer?) _
                                     })
            db.SaveChanges()

            runno = CInt("0")
            codeId = runno + 1
            RJITno = "P" + Mid(CStr(Now.Year), 3) + (CStr(Format(Now.Date, "MM"))) + CStr(codeId).PadLeft(3, CChar("0"))
            addPosition(RJITno)
            upDateID(codeId, key)
            clear()
        End If

    End Sub
    Private Sub addPosition(position As String)
        db.Positions.Add(New Position With
                         {.PositionID = position, _
                            .PositionName = txtPosition.Value, _
                            .CreateBy = CStr(Session("userID")), _
                            .CreateDate = Now, _
                            .DepartmentID = ddlPosition.Text
                        })
        db.SaveChanges()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('บันทึกข้อมูลตำแหน่งสำเร็จ !');", True)

    End Sub


    Private Sub upDateID(Id As Integer, key As String)
        Try
            db.Database.Connection.Open()
            Dim update = (From c In db.RunNoes Where c.Name = key
                  Select c).First
            If update IsNot Nothing Then
                update.RunNo1 = Id
                db.SaveChanges()
                Response.Redirect("Increase.aspx")
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('เกิดข้อผิดพลาด !');", True)
        End Try
    End Sub
    Private Sub clear()
        txtBranch.Value = ""
        txtdepartment.Value = ""
        txtPosition.Value = ""
        txtside.Value = ""
    End Sub

    Private Sub showList()
        Dim li = (From b In db.Branches Join s In db.Sides
                    On b.BranchID Equals s.BranchID
                    Join d In db.Departments On d.SideID Equals s.SideID
                    Join p In db.Positions On p.DepartmentID Equals d.DepartmentID
                    Select b.BranchName, s.SideName, d.DepartmentName, p.PositionName
                    ).ToList

        If li.Count > 1 Then
            Me.Repeater1.DataSource = li
            Me.Repeater1.DataBind()
        Else
            Me.Repeater1.DataSource = Nothing
            Me.Repeater1.DataBind()
        End If

    End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand

    End Sub
End Class
