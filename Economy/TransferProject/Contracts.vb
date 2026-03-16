Imports Economy.TransferProject.My.Ables
Imports MyBook

Namespace TransferProject.Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface ICreateria
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface

    Public Interface IRegisterDTO
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits MyBook.IHasDescription
        Inherits ICreateAT
        Inherits IMoneyValue
    End Interface

    Public Interface IChangeDescriptionDTO
        Inherits MyBook.IHasDescription
    End Interface
    Public Interface IChangeMoney
        Inherits IMoneyValue
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits ICreateAT
        Inherits MyBook.IHasDescription
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits IMoneyValue
    End Interface

    Public Class Contract
        Implements IReference, IModel, IChangeDescriptionDTO, IChangeMoney, IRegisterDTO, ICreateria

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property CreateAt As Date Implements ICreateAT.CreateAt
        Public Property Description As String Implements IHasDescription.Description
        Public Property MoneyValue As Double Implements IMoneyValue.MoneyValue
        Public Property ExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID

    End Class

End Namespace
