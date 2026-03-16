Imports MyBook

Namespace BankCardsProject.My.Entity
    Public Structure BankCard
        Public ID As Integer
        Public NumberCard As String
        Public Code As Integer
        Public Description As String
    End Structure

    Public Interface INumberCard
        Property NumberCard As String
        Property Code As Integer
    End Interface

    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IEntity
        Inherits IReference
        Inherits INumberCard
        Inherits MyBook.IHasDescription
    End Interface


    Public Class Entity
        Implements IEntity


        Private Data As BankCard
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
            End Set
        End Property
        Public Property NumberCard As String Implements INumberCard.NumberCard
            Get
                Return Data.NumberCard
            End Get
            Set(value As String)
                Data.NumberCard = value
            End Set
        End Property
        Public Property Code As Integer Implements INumberCard.Code
            Get
                Return Data.Code
            End Get
            Set(value As Integer)
                Data.Code = value
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
    End Class
End Namespace

