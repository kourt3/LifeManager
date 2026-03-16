Imports MyBook
Imports PortofolioProject.My.Enity

Namespace Contracts


    Public Interface IModel
        Inherits IReference
        Inherits MyBook.IHasName
        Inherits MyBook.IHasDescription
    End Interface
    Public Interface IRegisterDTO
        Inherits MyBook.IHasName, MyBook.IHasDescription
    End Interface
    Public Interface IChangeNameDTO
        Inherits MyBook.IHasName
    End Interface
    Public Interface IChangeDescriptionDTO
        Inherits MyBook.IHasDescription
    End Interface

    Public Class Contract
        Implements IReference, IModel, IRegisterDTO, IChangeNameDTO, IChangeDescriptionDTO

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Name As String Implements IHasName.Name
        Public Property Description As String Implements IHasDescription.Description

    End Class
End Namespace

