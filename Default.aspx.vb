﻿Option Strict On
Option Explicit On

Imports System.Linq
Imports System.Web
Imports System.Web.Configuration
Imports System.Security

Public Class _Default1
    Inherits System.Web.UI.Page
    'Dim db As New DB_EaglesInternalTestEntities
    Private db As New DB_EaglesInternalEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = True Then


        End If

    End Sub

    Protected Sub btnSigIN_Click(sender As Object, e As EventArgs) Handles btnSigIN.Click
        Dim LoginCls As New LoginCls
        Dim menu As String = "User Management"

        If LoginCls.chkUser(txtusername.Value, txtpassword.Value) Then

            Dim ds = (From c In db.tblUsers
            Where c.UserId = txtusername.Value.Trim
               Select New With
               {
                 c.UserId,
                 c.Prefix_thai,
                 c.Name_thai,
                 c.Surname_thai,
                 c.Name_eng
                 }).FirstOrDefault()

            Dim ds1 = (From c In db.tblUserMenus Where c.UserID = ds.UserId And c.Menu = menu And c.Read_ = 1).FirstOrDefault
            If Not ds1 Is Nothing Then
                Session("UserID") = txtusername.Value.Trim
                Session("Prefix_thai") = ds.Prefix_thai
                Session("Name_thai") = ds.Name_thai
                Session("Surname_thai") = ds.Surname_thai
                Session("Name_eng") = ds.Name_eng
                'Response.Redirect(Request.Cookies("MainConfigPath").Value & "SearchUser.aspx")
                Response.Redirect("UserProject.aspx")
            Else
                lblMsg.Text = "* You do not have access"
            End If



        Else
            lblMsg.Text = "* Your Username and/or password  is not correct."
        End If
    End Sub
End Class