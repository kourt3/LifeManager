Imports Economy.BankCardsProject.My.Entity
Imports MyBook

Namespace GiftsCard.Contracs
    Public Interface IModel
        Inherits GiftsCard.Entity.IReference
        Inherits MyBook.IHasName
        Inherits MyBook.IHasDescription
        Inherits BankCardsProject.My.Entity.INumberCard
    End Interface

    Public Interface IRegisterDTO
        Inherits MyBook.IHasName
        Inherits BankCardsProject.My.Entity.INumberCard
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IChangeDTO
        Inherits MyBook.IHasName
        Inherits BankCardsProject.My.Entity.INumberCard
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IChangeDescriptionDTO
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IChangeNumberDTO
        Inherits BankCardsProject.Contracts.IChangeNumberDTO
    End Interface
    Public Interface IChangeNamedDTO
        Inherits MyBook.IHasName
    End Interface
    Public Class Contracs
        Implements IModel, IRegisterDTO, IChangeDTO, IChangeDescriptionDTO, IChangeNumberDTO, IChangeNamedDTO

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Name As String Implements IHasName.Name
        Public Property Description As String Implements IHasDescription.Description
        Public Property NumberCard As String Implements INumberCard.NumberCard
        Public Property Code As Integer Implements INumberCard.Code

    End Class
End Namespace

