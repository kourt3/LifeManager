Imports MyBook

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits MyBook.IHasDescription
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface
    Public Interface ICreteria
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface

    Public Interface IChangeDescriptionDTO
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IRegisterDTO
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits MyBook.IHasDescription
    End Interface

    Public Class Contracts
        Implements IReference, IModel, ICreteria, IRegisterDTO, IChangeDescriptionDTO
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Description As String Implements IHasDescription.Description
        Public Property ExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID

    End Class
End Namespace

