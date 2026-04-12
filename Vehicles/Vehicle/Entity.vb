Imports MyBook
Imports Vehicles.Vehicle.Model.Contracts

Namespace Vehicle.Vehicles.Entity
    Public Interface ICreatedAt
        Property CretatedAt As Date
    End Interface

    Structure VehicleCreated
        Dim Id As Integer
        Dim ModelId As Integer
        Dim CratedAt As Date
    End Structure
    Public Interface IEntity
        Inherits Base.IReference, Vehicle.Model.Contracts.IModelId, ICreatedAt
    End Interface


    Public Class Entity
        Implements Base.IReference, ICreatedAt, IEntity

        Private Vehicle As VehicleCreated
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Vehicle.Id
            End Get
            Set(value As Integer)
                Vehicle.Id = value
            End Set
        End Property



        Public Property CretatedAt As Date Implements ICreatedAt.CretatedAt
            Get
                Return Vehicle.CratedAt
            End Get
            Set(value As Date)
                Vehicle.CratedAt = value
            End Set
        End Property

        Public Property ModelId As Integer Implements IModelId.ModelId
            Get
                Return Vehicle.ModelId
            End Get
            Set(value As Integer)
                Vehicle.ModelId = value
            End Set
        End Property
    End Class

End Namespace
