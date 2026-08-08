Imports MyBook

Namespace Portofolio.Contracts


    Public Interface IModel
        Inherits Portofolio.Entity.IReference
        Inherits MyBook.IHasName
        Inherits MyBook.IHasDescription
        Inherits MyBook.IHasCreation
    End Interface
    Public Interface IRegisterDTO
        Inherits MyBook.IHasName, MyBook.IHasDescription, MyBook.IHasCreation
    End Interface
    Public Interface IChangeNameDTO
        Inherits MyBook.IHasName
    End Interface
    Public Interface IChangeCreationDTO
        Inherits MyBook.IHasCreation
    End Interface
    Public Interface IChangeDescriptionDTO
        Inherits MyBook.IHasDescription
    End Interface

    Public Class Contract
        Implements Portofolio.Entity.IReference, IModel, IRegisterDTO, IChangeNameDTO, IChangeDescriptionDTO, IChangeCreationDTO

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Name As String Implements IHasName.Name
        Public Property Description As String Implements IHasDescription.Description
        Public Property Creation As Date Implements IHasCreation.Creation

    End Class
End Namespace

