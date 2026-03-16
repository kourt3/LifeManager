Imports MyBook

Namespace GiftsCard.Entity

    Public Structure GiftsCard
        Dim ID As Integer
        Dim Name As String
        Dim NumberCard As String
        Dim Code As String
        Dim Description As String
    End Structure

    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IEntity
        Inherits IReference
        Inherits MyBook.IHasName
        Inherits MyBook.IHasDescription
        Inherits BankCardsProject.My.Entity.INumberCard
    End Interface
    Public Class Entity
        Implements IEntity

        Private Data As New GiftsCard
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
            End Set
        End Property

        Public Property Name As String Implements IHasName.Name
            Get
                Return Data.Name
            End Get
            Set(value As String)
                Data.Name = value
            End Set
        End Property

        Public Property Description As String Implements IHasDescription.Description
            Get
                Return Data.Description
            End Get
            Set(value As String)
                Data.Description = value
            End Set
        End Property

        Public Property NumberCard As String Implements BankCardsProject.My.Entity.INumberCard.NumberCard
            Get
                Return Data.NumberCard
            End Get
            Set(value As String)
                Data.NumberCard = value
            End Set
        End Property

        Public Property Code As Integer Implements BankCardsProject.My.Entity.INumberCard.Code
            Get
                Return Data.Code
            End Get
            Set(value As Integer)
                Data.Code = value
            End Set
        End Property
    End Class
End Namespace

