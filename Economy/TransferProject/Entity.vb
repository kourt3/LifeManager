Imports Economy.TransferProject.Ables
Imports MyBook

Namespace TransferProject.Ables

    Public Interface ICreateAT
        Property CreateAt As Date
    End Interface

    Public Interface IMoneyValue
        Property MoneyValue As Double
    End Interface

    ''' <summary>
    ''' For Economy
    ''' </summary>
    Public Interface IEconomyId
        Property EconomyID As Integer
        Interface FromEconomyId
            Property FromEconomyID As Integer
        End Interface
        Interface ToEconomyID
            Property ToEconomyID As Integer
        End Interface
    End Interface

    ''' <summary>
    ''' For PartEconomy("Portofolio,BankCard,GiftCard")
    ''' </summary>
    Public Interface PartEconomyID
        Property PartEconomyId As Integer
        Interface FromPartEconomyID
            Property FromPartEconomyID As Integer
        End Interface
        Interface ToPartEconomyID
            Property ToPartEconomyID As Integer
        End Interface
    End Interface

    ''' <summary>
    ''' Category
    ''' </summary>
    Public Interface ICategory
        Property Category As String
        Interface IFromCategory
            Property FromCategory As String
        End Interface
        Interface IToCategory
            Property ToCategory As String
        End Interface
    End Interface
End Namespace
Namespace TransferProject.Entity

    Structure Data
        Public Id As Integer
        Public CreateAt As Date
        Public FromEconomyID As Integer
        Public FromCategory As String
        Public FromExternalId As Integer
        Public MoneyValue As Double
        Public ToEconomyID As Integer
        Public ToExternaId As Integer
        Public ToCategory As String
        Public Desctiption As String
    End Structure

    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IEntity
        Inherits IReference
        Inherits MyBook.IHasDescription
        Inherits Ables.IEconomyId.FromEconomyId, Ables.IEconomyId.ToEconomyID
        Inherits Ables.PartEconomyID.FromPartEconomyID, Ables.PartEconomyID.ToPartEconomyID
        Inherits Ables.ICategory.IFromCategory, Ables.ICategory.IToCategory
        Inherits Ables.ICreateAT, Ables.IMoneyValue
    End Interface

    Public Class Entity
        Implements IEntity, IReference

        Private Data As New Data
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
            End Set
        End Property

        Public Property Description As String Implements IHasDescription.Description
            Get
                Return Data.Desctiption
            End Get
            Set(value As String)
                Data.Desctiption = value
            End Set
        End Property
        Public Property CreateAt As Date Implements ICreateAT.CreateAt
            Get
                Return Data.CreateAt
            End Get
            Set(value As Date)
                Data.CreateAt = value
            End Set
        End Property

        Public Property MoneyValue As Double Implements IMoneyValue.MoneyValue
            Get
                Return Data.MoneyValue
            End Get
            Set(value As Double)
                Data.MoneyValue = value
            End Set
        End Property

        Public Property FromCategory As String Implements ICategory.IFromCategory.FromCategory
            Get
                Return Data.FromCategory
            End Get
            Set(value As String)
                Data.FromCategory = value
            End Set
        End Property

        Public Property ToCategory As String Implements ICategory.IToCategory.ToCategory
            Get
                Return Data.ToCategory
            End Get
            Set(value As String)
                Data.ToCategory = value
            End Set
        End Property

        Public Property FromEconomyID As Integer Implements IEconomyId.FromEconomyId.FromEconomyID
            Get
                Return Data.FromEconomyID
            End Get
            Set(value As Integer)
                Data.FromEconomyID = value
            End Set
        End Property

        Public Property ToEconomyID As Integer Implements IEconomyId.ToEconomyID.ToEconomyID
            Get
                Return Data.ToEconomyID
            End Get
            Set(value As Integer)
                Data.ToEconomyID = value
            End Set
        End Property

        Public Property FromPartEconomyID As Integer Implements PartEconomyID.FromPartEconomyID.FromPartEconomyID
            Get
                Return Data.FromExternalId
            End Get
            Set(value As Integer)
                Data.FromExternalId = value
            End Set
        End Property

        Public Property ToPartEconomyID As Integer Implements PartEconomyID.ToPartEconomyID.ToPartEconomyID
            Get
                Return Data.ToExternaId
            End Get
            Set(value As Integer)
                Data.ToExternaId = value
            End Set
        End Property
    End Class
End Namespace
