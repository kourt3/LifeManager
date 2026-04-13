Imports MyBook

Namespace Vehicle.Brand.Contracts
    Public Interface IModel
        Inherits Vehicle.Base.IReference, MyBook.IHasName, MyBook.IHasIcon
    End Interface

    Public Interface IRegisterDTO
        Inherits MyBook.IHasName, MyBook.IHasIcon
    End Interface
    Public Interface IChangeDTO
        Inherits MyBook.IHasName, MyBook.IHasIcon
    End Interface
    Public Interface IChangeNameDTO
        Inherits MyBook.IHasName
    End Interface
    Public Interface IChangeIconDTO
        Inherits MyBook.IHasIcon
    End Interface

    Public Class Contracts
        Implements IModel, IRegisterDTO, IChangeIconDTO, IChangeNameDTO, IChangeDTO

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Name As String Implements IHasName.Name
        Public Property Icon As String Implements IHasIcon.Icon


    End Class
End Namespace
