Option Explicit On
Option Strict On

Public Class User



    Private UserId As String
    Public Property setUserId() As String
        Get
            Return UserId
        End Get
        Set(ByVal value As String)
            UserId = value
        End Set
    End Property

    Private UserName As String
    Public Property setuserName() As String
        Get
            Return UserName
        End Get
        Set(ByVal value As String)
            UserName = value
        End Set
    End Property

    Private Branch As String
    Public Property setBranch() As String
        Get
            Return Branch
        End Get
        Set(ByVal value As String)
            Branch = value
        End Set
    End Property

    Private Section As String
    Public Property setSection() As String
        Get
            Return Section
        End Get
        Set(ByVal value As String)
            Section = value
        End Set
    End Property
    Private Dept As String
    Public Property setDept() As String
        Get
            Return Dept
        End Get
        Set(ByVal value As String)
            Dept = value
        End Set
    End Property

    Private Position As String
    Public Property setPosition() As String
        Get
            Return Position
        End Get
        Set(ByVal value As String)
            Position = value
        End Set
    End Property

End Class
