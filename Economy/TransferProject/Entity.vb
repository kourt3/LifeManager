Imports Economy.TransferProject.Ables
Imports MyBook

Namespace TransferProject.Ables

    Public Interface ICreateAT
        Property CreateAt As Date
    End Interface

    Public Interface IMoneyValue
        Property MoneyValue As Double
    End Interface

    Public Interface ICategory
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
        Public FromCategory As String
        Public FromExternalId As Integer
        Public MoneyValue As Double
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
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits Ables.ICreateAT, Ables.IMoneyValue
        Inherits Ables.ICategory.IFromCategory, Ables.ICategory.IToCategory
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

        Public Property ExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
            Get
                Return Data.FromExternalId
            End Get
            Set(value As Integer)
                Data.FromExternalId = value
            End Set
        End Property

        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID
            Get
                Return Data.ToExternaId
            End Get
            Set(value As Integer)
                Data.ToExternaId = value
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
    End Class
End Namespace
