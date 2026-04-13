Namespace FamilyProject.Family.Ables
    Public Interface IMother
        Property Mother As Integer
    End Interface
    Public Interface IFather
        Property Father As Integer
    End Interface
    Public Interface IHusband
        Property Husband As Integer
    End Interface
    Public Interface IMePerson
        Property MePersonID As Integer
    End Interface
End Namespace

Namespace FamilyProject.Family.Entity
    Structure FamilyData
        Dim ID As Integer
        Dim MotherID As Integer
        Dim FatherID As Integer
        Dim HusbandID As Integer
        Dim MePersonID As Integer
    End Structure

    Public Interface IFamilyEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits FamilyProject.Family.Ables.IMother
        Inherits FamilyProject.Family.Ables.IFather
        Inherits FamilyProject.Family.Ables.IHusband
        Inherits FamilyProject.Family.Ables.IMePerson
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

        Public Property Mother As Integer Implements FamilyProject.Family.Ables.IMother.Mother
            Get
                Return Data.MotherID
            End Get
            Set(value As Integer)
                Data.MotherID = value
            End Set
        End Property

        Public Property Father As Integer Implements FamilyProject.Family.Ables.IFather.Father
            Get
                Return Data.FatherID
            End Get
            Set(value As Integer)
                Data.FatherID = value
            End Set
        End Property

        Public Property Husband As Integer Implements FamilyProject.Family.Ables.IHusband.Husband
            Get
                Return Data.HusbandID
            End Get
            Set(value As Integer)
                Data.HusbandID = value
            End Set
        End Property

        Public Property MePersonID As Integer Implements FamilyProject.Family.Ables.IMePerson.MePersonID
            Get
                Return Data.MePersonID
            End Get
            Set(value As Integer)
                Data.MePersonID = value
            End Set
        End Property
    End Class
End Namespace
