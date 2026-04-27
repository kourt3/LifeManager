Imports MyBook
Namespace FamilyProject.Children.Ables
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IFamilyId
        Property FamilyID As Integer
    End Interface
End Namespace
Namespace FamilyProject.Children.Entity
    Public Structure Data
        Dim ID As Integer
        Dim FamilyID As Integer
        Dim ToExternalID As Integer
    End Structure




    Public Interface IEntity
        Inherits Ables.IReference
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasToExternalID, Ables.IFamilyId
    End Interface

    Public Class Entity
        Implements IEntity

        Private Data As New Data

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
            End Set
        End Property

        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID
            Get
                Return Data.ToExternalID
            End Get
            Set(value As Integer)
                Data.ToExternalID = value
            End Set
        End Property

        Public Property FamilyID As Integer Implements Ables.IFamilyId.FamilyID
            Get
                Return Data.FamilyID
            End Get
            Set(value As Integer)
                Data.FamilyID = value
            End Set
        End Property
    End Class
End Namespace

