'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class tblUser
    Public Property UserId As String
    Public Property Password As String
    Public Property Prefix_thai As String
    Public Property Name_thai As String
    Public Property Surname_thai As String
    Public Property Prefix_eng As String
    Public Property Name_eng As String
    Public Property Surname_eng As String
    Public Property Email As String
    Public Property Position As String
    Public Property Dept As String
    Public Property Section As String
    Public Property Branch As String
    Public Property UserBy As String
    Public Property UserDate As Nullable(Of Date)
    Public Property CreateBy As String
    Public Property CreateDate As Nullable(Of Date)
    Public Property NickName As String
    Public Property Approve1 As String
    Public Property Approve2 As String
    Public Property StatusID As Nullable(Of Integer)

    Public Overridable Property Branches As ICollection(Of Branch) = New HashSet(Of Branch)

End Class
