Namespace Account.Ables
    Public Interface ILoginID
        Property LoginID As Integer
    End Interface
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
End Namespace

Namespace Account.Entity
    Public Structure Data
        Public Id As Integer
        Public LoginId As Integer
        Public ToExternalId As Integer
    End Structure


    Public Interface IEntity
        Inherits Ables.IReference
        Inherits Ables.ILoginID
        Property ToExternalID As Integer
    End Interface

    Public Class Entity
        Implements IEntity, Ables.IReference

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

