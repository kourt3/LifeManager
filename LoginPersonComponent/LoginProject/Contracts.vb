
Imports MyBook

Namespace LoginProject.Contracts

    Public Interface IModel
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits LoginProject.Ables.IUserName, Ables.CreateAt
        Inherits Ables.IPassword
    End Interface
    ''' <summary>
    ''' Criteria
    ''' </summary>
    Public Interface ILoginDTO
        Inherits LoginProject.Entity.ICreteria
    End Interface
    Public Interface IRegisterDTO
        Inherits LoginProject.Ables.IUserName, LoginProject.Ables.IPassword
    End Interface
    Public Interface IChangeUsernameAndPasswordDTO
        Inherits LoginProject.Ables.IUserName, LoginProject.Ables.IPassword
    End Interface
    Public Interface IChangeNameDTO
        Inherits LoginProject.Ables.IUserName
    End Interface
    Public Interface IChangePasswordDTO
        Inherits LoginProject.Ables.IPassword
    End Interface

    Public Class Contracts
        Implements ILoginDTO, IRegisterDTO, IChangeNameDTO, IChangePasswordDTO, IChangeUsernameAndPasswordDTO, IModel

        Private Data As New LoginProject.DataStructure.Data
        Public Property Username As String Implements LoginProject.Ables.IUserName.Username
            Get
                Return Data.UserName
            End Get
            Set(value As String)
                Data.UserName = value
            End Set
        End Property
        Public Property Password As String Implements LoginProject.Ables.IPassword.Password
            Get
                Return Data.Password
            End Get
            Set(value As String)
                Data.Password = value
            End Set
        End Property
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
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
    End Class
End Namespace
