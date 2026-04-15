Imports LoginProject.My.Ables
Imports MyBook
Imports ProfileComponent

Namespace Contracts
    Public Interface ICreteria
        Inherits IAcountRegisterDTO
    End Interface

    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IModel
        Inherits IReference
        Property LoginModel As LoginProject.Contracts.IModel
        Property PersonModel As PersonProject.Contracts.IModel
    End Interface
    Public Interface ILoginAndPersonRegisterDTO
        Property LoginDTO As LoginProject.Contracts.IRegisterDTO
        Property PersonDTO As PersonProject.Contracts.IRegisterDTO
    End Interface
    Public Interface IAcountRegisterDTO
        Property LoginRef As LoginProject.My.Entity.IReference
        Property PersonRef As PersonProject.Enity.IReference
    End Interface

    Public Class Contracts
        Implements IReference, IModel, ILoginAndPersonRegisterDTO, IAcountRegisterDTO, ICreteria

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey

        Public Property LoginModel As LoginProject.Contracts.IModel Implements IModel.LoginModel
        Public Property PersonModel As PersonProject.Contracts.IModel Implements IModel.PersonModel
        Public Property LoginDTO As LoginProject.Contracts.IRegisterDTO Implements ILoginAndPersonRegisterDTO.LoginDTO
        Public Property PersonDTO As PersonProject.Contracts.IRegisterDTO Implements ILoginAndPersonRegisterDTO.PersonDTO
        Public Property LoginRef As LoginProject.My.Entity.IReference Implements IAcountRegisterDTO.LoginRef
        Public Property PersonRef As PersonProject.Enity.IReference Implements IAcountRegisterDTO.PersonRef



        Sub New()
            LoginRef = New LoginProject.Contracts.Contracts
            LoginModel = New LoginProject.Contracts.Contracts
            LoginDTO = New LoginProject.Contracts.Contracts

            PersonRef = New PersonProject.Contracts.Contracts
            PersonModel = New PersonProject.Contracts.Contracts
            PersonDTO = New PersonProject.Contracts.Contracts
        End Sub
    End Class
End Namespace

