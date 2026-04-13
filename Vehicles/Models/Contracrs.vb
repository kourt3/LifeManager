Imports MyBook
Imports Vehicles.Vehicle.Model.Entity

Namespace Vehicle.Model.Contracts

    Public Interface ICreteria
        Inherits Model.Entity.ICategoryName, MyBook.IHasName, Entity.IBrandId
    End Interface
    Public Interface IModel
        Inherits Entity.IBrandId, MyBook.IHasName, Vehicle.Base.IReference, Model.Entity.ICategoryName
    End Interface
    Public Interface IRegisterDTO
        Inherits MyBook.IHasName, Entity.IBrandId, Vehicle.Model.Entity.ICategoryName
    End Interface
    Public Interface IChangeName
        Inherits MyBook.IHasName
    End Interface
    Public Interface IChangeCategory
        Inherits Model.Entity.ICategoryName
    End Interface
    Public Class Contracts
        Implements IModel, IRegisterDTO, IChangeName, Vehicle.Base.IReference, IChangeCategory, ICreteria


        Public Property Name As String Implements IHasName.Name
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property CategoryName As String Implements ICategoryName.CategoryName
        Public Property BrandId As Integer Implements IBrandId.BrandId

    End Class
End Namespace

