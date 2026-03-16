Imports TranferEconomyProject.My.Ables

Namespace My.Ables
    Public Interface ICreateAT
        Property CreateAt As Date
    End Interface
    Public Interface IExternalId
        Property ToExtrenalID As Integer
        Property FromExternalID As Integer
    End Interface
    Public Interface IMoneyValue
        Property MoneyValue As Double
    End Interface
    Public Interface IDescription
        Property Description As String
    End Interface
End Namespace
Namespace My.Entity

    Structure Data
        Public Id As Integer
        Public CreateAt As Date
        Public FromExternalId As Integer
        Public MoneyValue As Double
        Public ToExternaId As Integer
        Public Desctiption As String
    End Structure
    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits Ables.ICreateAT, Ables.IDescription, Ables.IExternalId, Ables.IMoneyValue
    End Interface

    Public Class Entity
        Implements IEntity

        Private Data As New Data
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
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

        Public Property Description As String Implements IDescription.Description
            Get
                Return Data.Desctiption
            End Get
            Set(value As String)
                Data.Desctiption = value
            End Set
        End Property

        Public Property ToExtrenalID As Integer Implements IExternalId.ToExtrenalID
            Get
                Return Data.ToExternaId
            End Get
            Set(value As Integer)
                Data.ToExternaId = value
            End Set
        End Property

        Public Property FromExternalID As Integer Implements IExternalId.FromExternalID
            Get
                Return Data.FromExternalId
            End Get
            Set(value As Integer)
                Data.FromExternalId = value
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


    End Class
End Namespace
