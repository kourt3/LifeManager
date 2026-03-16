Imports MyBook

Namespace Children.Entity
    Public Structure Data
        Dim ID As Integer
        Dim FamilyID As Integer
        Dim PersonID As Integer
    End Structure


    Public Interface IPersonID
        Property PersonID As Integer
    End Interface
    Public Interface IFamilyId
        Property FamilyID As Integer
    End Interface


    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits IPersonID, IFamilyId
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

        Public Property PersonID As Integer Implements IPersonID.PersonID
            Get
                Return Data.PersonID
            End Get
            Set(value As Integer)
                Data.PersonID = value
            End Set
        End Property

        Public Property FamilyID As Integer Implements IFamilyId.FamilyID
            Get
                Return Data.FamilyID
            End Get
            Set(value As Integer)
                Data.FamilyID = value
            End Set
        End Property
    End Class
End Namespace

