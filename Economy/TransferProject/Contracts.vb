Imports Economy.TransferProject.Ables
Imports MyBook

Namespace TransferProject.Contracts

    Public Interface ICreateria
        Inherits Ables.PartEconomyID.FromPartEconomyID, Ables.PartEconomyID.ToPartEconomyID
        Inherits Ables.ICategory.IFromCategory, Ables.ICategory.IToCategory
        Inherits Ables.IEconomyId.FromEconomyId, Ables.IEconomyId.ToEconomyID
    End Interface
    Public Interface ICreteriaWhere
        Inherits Ables.ICategory, Ables.PartEconomyID
    End Interface


    Public Interface IRegisterDTO
        Inherits Ables.PartEconomyID.FromPartEconomyID, Ables.PartEconomyID.ToPartEconomyID
        Inherits Ables.IEconomyId.FromEconomyId, Ables.IEconomyId.ToEconomyID
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
        Inherits Ables.IEconomyId.FromEconomyId, Ables.IEconomyId.ToEconomyID
        Inherits Ables.ICategory.IFromCategory, Ables.ICategory.IToCategory
        Inherits Ables.PartEconomyID.FromPartEconomyID, Ables.PartEconomyID.ToPartEconomyID
        Inherits IMoneyValue
    End Interface

    Public Class Contract
        Implements IModel, IChangeDescriptionDTO, IChangeMoney, IRegisterDTO, ICreateria, ICreteriaWhere

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property CreateAt As Date Implements ICreateAT.CreateAt
        Public Property Description As String Implements IHasDescription.Description
        Public Property MoneyValue As Double Implements IMoneyValue.MoneyValue
        Public Property FromCategory As String Implements ICategory.IFromCategory.FromCategory
        Public Property ToCategory As String Implements ICategory.IToCategory.ToCategory
        Public Property FromEconomyID As Integer Implements IEconomyId.FromEconomyId.FromEconomyID
        Public Property ToEconomyID As Integer Implements IEconomyId.ToEconomyID.ToEconomyID
        Public Property FromPartEconomyID As Integer Implements PartEconomyID.FromPartEconomyID.FromPartEconomyID
        Public Property ToPartEconomyID As Integer Implements PartEconomyID.ToPartEconomyID.ToPartEconomyID
        Public Property Category As String Implements ICategory.Category
        Public Property PartEconomyId As Integer Implements PartEconomyID.PartEconomyId

    End Class

End Namespace
