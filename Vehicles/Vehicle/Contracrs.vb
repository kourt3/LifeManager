Imports MyBook
Imports Vehicles.Vehicle.Vehicles.Entity

Namespace Vehicle.Vehicles.Contracts
    Public Interface IModel
        Inherits Vehicle.Vehicles.Entity.ICreatedAt, Base.IReference, Vehicle.Model.Contracts.IModelId
    End Interface

    Public Interface ICreteria
        Inherits Vehicle.Model.Contracts.IModelId
    End Interface
    Public Interface IRegisterDTO
        Inherits Vehicle.Vehicles.Entity.ICreatedAt, Vehicle.Model.Contracts.IModelId
    End Interface
    Public Interface IChangeCreatedDTO
        Inherits Vehicles.Entity.ICreatedAt
    End Interface

    Public Class Contracrs
        Implements IRegisterDTO, IChangeCreatedDTO, IModel, Base.IReference, ICreteria

        Public Property CretatedAt As Date Implements ICreatedAt.CretatedAt
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property ModelId As Integer Implements Model.Contracts.IModelId.ModelId

    End Class

End Namespace
