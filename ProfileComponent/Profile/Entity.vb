Imports MyBook
Imports ProfileComponent.Profile.Able

Namespace Profile.Able
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IPersonID
        Property PersonID As Integer
    End Interface
    Public Interface IFamilyID
        Property FamilyID As Integer
    End Interface
End Namespace
Namespace Profile.Entity

    Structure Data
        Public ID As Integer
        Public PersonID As Integer
        Public FamilyID As Integer
    End Structure
    Public Interface IEntity
        Inherits Able.IReference, Able.IPersonID, Able.IFamilyID
    End Interface

    Public Class Entity
        Implements Able.IReference, IEntity

        Private Data As Data
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
            End Set
        End Property

        Public Property PersonID As Integer Implements IPersonID.PersonID
            Get
                Return Data.PersonID
            End Get
            Set(value As Integer)
                Data.PersonID = value
            End Set
        End Property

        Public Property FamilyID As Integer Implements IFamilyID.FamilyID
            Get
                Return Data.FamilyID
            End Get
            Set(value As Integer)
                Data.FamilyID = value
            End Set
        End Property
    End Class

End Namespace
