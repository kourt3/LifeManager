Imports MyBook
Imports LoginProject

Namespace My.DataStructure

    Friend Structure Data
        Dim Id As Integer
        Dim UserName As String
        Dim Password As String
        Dim CreateAt As Date
    End Structure
End Namespace
Namespace My.Entity
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface ICreteria
        Inherits Ables.IUserName
        Inherits Ables.IPassword
    End Interface
    Public Interface IEntity
        Inherits IReference
        Inherits Ables.IUserName
        Inherits Ables.IPassword
        Inherits Ables.CreateAt
    End Interface

    Public Class Entity
        Implements IEntity, IReference, ICreteria

        Private Data As My.DataStructure.Data

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
            End Set
        End Property
        Public Property Username As String Implements Ables.IUserName.Username
            Get
                Return Data.UserName
            End Get
            Set(value As String)
                Data.UserName = value
            End Set
        End Property
        Public Property Password As String Implements Ables.IPassword.Password
            Get
                Return Data.Password
            End Get
            Set(value As String)
                Data.Password = value
            End Set
        End Property

        Public Property CreateAt As Date Implements Ables.CreateAt.CreateAt
            Get
                Return Data.CreateAt
            End Get
            Set(value As Date)
                Data.CreateAt = value
            End Set
        End Property
        Sub New()
            Data.CreateAt = Now
        End Sub

    End Class
End Namespace







