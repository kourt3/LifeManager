Imports Economy.BankCardsProject.My.Entity
Imports MyBook

Namespace BankCardsProject.Contracts

    Public Interface IModel
        Inherits BankCardsProject.My.Entity.IReference
        Inherits BankCardsProject.My.Entity.INumberCard
        Inherits MyBook.IHasDescription
    End Interface


    Public Interface IRegisterDTO
        Inherits BankCardsProject.My.Entity.INumberCard
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IChangeDTO
        Inherits BankCardsProject.My.Entity.INumberCard
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IChangeDescriptionDTO
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IChangeNumberDTO
        Inherits BankCardsProject.My.Entity.INumberCard
    End Interface


    Public Class Contracts
        Implements IModel, IRegisterDTO, IChangeDTO, IChangeDescriptionDTO, IChangeNumberDTO

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property NumberCard As String Implements INumberCard.NumberCard
        Public Property Code As Integer Implements INumberCard.Code
        Public Property Description As String Implements IHasDescription.Description

    End Class

End Namespace
