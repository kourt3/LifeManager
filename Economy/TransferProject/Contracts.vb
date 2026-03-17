Imports Economy.TransferProject.Ables
Imports MyBook

Namespace TransferProject.Contracts

    Public Interface ICreateria
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits Ables.ICategory.IFromCategory, Ables.ICategory.IToCategory
    End Interface

    Public Interface IRegisterDTO
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits Ables.ICategory.IFromCategory, Ables.ICategory.IToCategory
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
        Inherits Entity.IReference
        Inherits ICreateAT
        Inherits MyBook.IHasDescription
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits Ables.ICategory.IFromCategory
        Inherits Ables.ICategory.IToCategory
        Inherits IMoneyValue
    End Interface

    Public Class Contract
        Implements IModel, IChangeDescriptionDTO, IChangeMoney, IRegisterDTO, ICreateria

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property CreateAt As Date Implements ICreateAT.CreateAt
        Public Property Description As String Implements IHasDescription.Description
        Public Property MoneyValue As Double Implements IMoneyValue.MoneyValue
        Public Property ExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID
        Public Property FromCategory As String Implements ICategory.IFromCategory.FromCategory
        Public Property ToCategory As String Implements ICategory.IToCategory.ToCategory

    End Class

End Namespace
