
Namespace Account.Entity
    Public Interface ILoginID
        Property LoginID As Integer
    End Interface
    Public Structure Data
        Public Id As Integer
        Public LoginId As Integer
        Public ToExternalId As Integer
    End Structure


    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits ILoginID
        Property ToExternalID As Integer
    End Interface

    Public Class Entity
        Implements IEntity

        Private Data As New Data

        Public Property LoginID As Integer Implements IEntity.LoginID
            Get
                Return Data.LoginId
            End Get
            Set(value As Integer)
                Data.LoginId = value
            End Set
        End Property

        Public Property ToExternalID As Integer Implements IEntity.ToExternalID
            Get
                Return Data.ToExternalId
            End Get
            Set(value As Integer)
                Data.ToExternalId = value
            End Set
        End Property

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
            End Set
        End Property
    End Class
End Namespace

