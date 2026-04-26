Namespace FamilyProject.Family.Ables
    Public Interface IMotherID
        Property Mother As Integer
    End Interface
    Public Interface IFatherID
        Property Father As Integer
    End Interface
    Public Interface IHusbandID
        Property Spouse As Integer
    End Interface
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
End Namespace

Namespace FamilyProject.Family.Entity
    Structure FamilyData
        Dim ID As Integer
        Dim MotherID As Integer
        Dim FatherID As Integer
        Dim SpouseID As Integer
        Dim ExternalID As Integer
    End Structure

    Public Interface IFamilyEntity
        Inherits Ables.IReference
        Inherits FamilyProject.Family.Ables.IMotherID
        Inherits FamilyProject.Family.Ables.IFatherID
        Inherits FamilyProject.Family.Ables.IHusbandID
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID
    End Interface

    Public Class Entity
        Implements IFamilyEntity

        Private Data As New FamilyData
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
            End Set
        End Property

        Public Property Mother As Integer Implements FamilyProject.Family.Ables.IMotherID.Mother
            Get
                Return Data.MotherID
            End Get
            Set(value As Integer)
                Data.MotherID = value
            End Set
        End Property

        Public Property Father As Integer Implements FamilyProject.Family.Ables.IFatherID.Father
            Get
                Return Data.FatherID
            End Get
            Set(value As Integer)
                Data.FatherID = value
            End Set
        End Property

        Public Property Spouse As Integer Implements FamilyProject.Family.Ables.IHusbandID.Spouse
            Get
                Return Data.SpouseID
            End Get
            Set(value As Integer)
                Data.SpouseID = value
            End Set
        End Property

        Public Property ExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
            Get
                Return Data.ExternalID
            End Get
            Set(value As Integer)
                Data.ExternalID = value
            End Set
        End Property
    End Class
End Namespace
