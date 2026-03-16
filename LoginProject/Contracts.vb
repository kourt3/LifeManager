Imports LoginProject.My
Imports LoginProject.My.Ables
Imports MyBook

Namespace Contracts

    Public Interface IModel
        Inherits My.Entity.IReference
        Inherits My.Ables.IUserName, Ables.CreateAt
        Inherits Ables.IPassword
    End Interface
    ''' <summary>
    ''' Criteria
    ''' </summary>
    Public Interface ILoginDTO
        Inherits My.Entity.ICreteria
    End Interface
    Public Interface IRegisterDTO
        Inherits My.Ables.IUserName, My.Ables.IPassword
    End Interface
    Public Interface IChangeUsernameAndPasswordDTO
        Inherits My.Ables.IUserName, My.Ables.IPassword
    End Interface
    Public Interface IChangeNameDTO
        Inherits My.Ables.IUserName
    End Interface
    Public Interface IChangePasswordDTO
        Inherits My.Ables.IPassword
    End Interface

    Public Class Contracts
        Implements ILoginDTO, IRegisterDTO, IChangeNameDTO, IChangePasswordDTO, IChangeUsernameAndPasswordDTO, IModel

        Private Data As New My.DataStructure.Data
        Public Property Username As String Implements My.Ables.IUserName.Username
            Get
                Return Data.UserName
            End Get
            Set(value As String)
                Data.UserName = value
            End Set
        End Property
        Public Property Password As String Implements My.Ables.IPassword.Password
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
