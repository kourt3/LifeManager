Imports TranferEconomyProject.My.Ables

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface ICreateria
        Inherits My.Ables.IExternalId
    End Interface

    Public Interface IRegisterDTO
        Inherits My.Ables.IExternalId
        Inherits My.Ables.IDescription
        Inherits My.Ables.ICreateAT
        Inherits My.Ables.IMoneyValue
    End Interface

    Public Interface IChangeDescriptionDTO
        Inherits My.Ables.IDescription
    End Interface
    Public Interface IChangeMoney
        Inherits My.Ables.IMoneyValue
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits My.Ables.ICreateAT
        Inherits My.Ables.IDescription
        Inherits My.Ables.IExternalId
        Inherits My.Ables.IMoneyValue
    End Interface

    Public Class Contract
        Implements IReference, IModel, IChangeDescriptionDTO, IChangeMoney, IRegisterDTO, ICreateria

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property CreateAt As Date Implements ICreateAT.CreateAt
        Public Property Description As String Implements IDescription.Description
        Public Property ToExtrenalID As Integer Implements IExternalId.ToExtrenalID
        Public Property FromExternalID As Integer Implements IExternalId.FromExternalID
        Public Property MoneyValue As Double Implements IMoneyValue.MoneyValue

    End Class

End Namespace
