Imports MyBook

Namespace RelationShip.Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface
    Public Interface ICreteriaExtrenalAndToExternal
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface
    Public Interface ICreteriaExternal
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID
    End Interface
    Public Interface ICreteriaTOExternal
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface
    Public Interface IRegisterDTO
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface

    Public Class Contracts
        Implements IReference, IModel, ICreteriaExtrenalAndToExternal, IRegisterDTO, ICreteriaExternal, ICreteriaTOExternal
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property ExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID

    End Class
End Namespace

