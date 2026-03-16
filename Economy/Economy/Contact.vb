Namespace EconomyProject.Contracts

    Public Interface IModel
        Inherits EconomyProject.Entity.IReference
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits MyBook.IHasCategory
    End Interface

    Public Interface ICreteria
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits MyBook.IHasCategory
    End Interface


    Public Interface IRegisterDTO
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits MyBook.IHasCategory
    End Interface


    Public Class Contact

        Implements IModel, IRegisterDTO, ICreteria

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property ToExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID
        Public Property Category As String Implements MyBook.IHasCategory.Category
        Public Property ExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID

    End Class
End Namespace

