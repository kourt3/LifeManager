Imports MyBook
Imports ProfileComponent.My.Entity

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IModel
        Inherits IReference
        Property PersonModel As PersonProject.Contracts.IModel
    End Interface

    Public Interface IProfileRegisterDTO
        Property PersonRef As PersonProject.Contracts.IReference
    End Interface

    Public Class Contracts
        Implements IReference, IModel, IProfileRegisterDTO

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property PersonModel As PersonProject.Contracts.IModel Implements IModel.PersonModel
        Public Property PersonRef As PersonProject.Contracts.IReference Implements IProfileRegisterDTO.PersonRef

        Sub New()
            PersonModel = New PersonProject.Contracts.Contracts
            PersonRef = New PersonProject.Contracts.Contracts
        End Sub

    End Class
End Namespace

