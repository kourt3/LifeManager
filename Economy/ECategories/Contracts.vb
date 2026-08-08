Imports MyBook

Namespace ECategory.Contracts
    Public Interface IModel
        Inherits ECategory.Entity.IReference, MyBook.IHasDescription, MyBook.IHasCategory
    End Interface
    Public Interface IRegisterDTO
        Inherits ECategory.Entity.IReference, MyBook.IHasCategory, MyBook.IHasDescription
    End Interface

    Public Interface IChangeCategoryNameDTO
        Inherits ECategory.Entity.IReference
        Inherits MyBook.IHasCategory
    End Interface

    Public Interface IChangeDescriptionDTO
        Inherits ECategory.Entity.IReference
        Inherits MyBook.IHasDescription
    End Interface

    Public Class Contracts
        Implements IModel, IRegisterDTO, IChangeCategoryNameDTO, IChangeDescriptionDTO

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Category As String Implements IHasCategory.Category
        Public Property Description As String Implements IHasDescription.Description

    End Class
End Namespace

