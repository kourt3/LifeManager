Imports MyBook
Imports Vehicles.Vehicle.Brand.Contracts

Namespace Vehicle.Model.Entity
    Public Interface ICategoryName
        Property CategoryName As String
    End Interface
    Structure VehicleModels
        Dim Id As Integer
        Dim BrandId As Integer
        Dim ModelName As String
        Dim CategoryName As String
    End Structure

    Public Interface IEntity
        Inherits Vehicle.Base.IReference, MyBook.IHasName, Vehicle.Brand.Contracts.IBrandId, ICategoryName

    End Interface

    Public Class Entity
        Implements IEntity, Vehicle.Base.IReference


        Private ModelData As VehicleModels

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return ModelData.Id
            End Get
            Set(value As Integer)
                ModelData.Id = value
            End Set
        End Property
        Public Property Name As String Implements IHasName.Name
            Get
                Return ModelData.ModelName
            End Get
            Set(value As String)
                ModelData.ModelName = value
            End Set
        End Property

        Public Property BrandId As Integer Implements IBrandId.BrandId
            Get
                Return ModelData.BrandId
            End Get
            Set(value As Integer)
                ModelData.BrandId = value
            End Set
        End Property

        Public Property CategoryName As String Implements ICategoryName.CategoryName
            Get
                Return ModelData.CategoryName
            End Get
            Set(value As String)
                ModelData.CategoryName = value
            End Set
        End Property
    End Class
End Namespace

