
Namespace My.Entity

    Public Structure Data
        Public Id As Integer
        Public LoginId As Integer
        Public PersonId As Integer
        Public FamilyID As Integer
    End Structure


    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Property LoginID As Integer
        Property PersonID As Integer
        Property FamilyID As Integer
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

        Public Property PersonID As Integer Implements IEntity.PersonID
            Get
                Return Data.PersonId
            End Get
            Set(value As Integer)
                Data.PersonId = value
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

        Public Property FamilyID As Integer Implements IEntity.FamilyID
            Get
                Return Data.FamilyID
            End Get
            Set(value As Integer)
                Data.FamilyID = value
            End Set
        End Property
    End Class
End Namespace

