Imports MyBook

Namespace Vehicle.Brand.Entity
    Structure VehicleBrand
        Dim Id As Integer
        Dim BrandName As String
        Dim Icon As String
    End Structure
    Public Interface IBrand
        Inherits Vehicle.Base.IReference, MyBook.IHasName, MyBook.IHasIcon
    End Interface
    Public Class Entity
        Implements Vehicle.Base.IReference, IBrand

        Private Brand As VehicleBrand
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Brand.Id
            End Get
            Set(value As Integer)
                Brand.Id = value
            End Set
        End Property

        Public Property Name As String Implements IBrand.Name
            Get
                Return Brand.BrandName
            End Get
            Set(value As String)
                Brand.BrandName = value
            End Set
        End Property

        Public Property Icon As String Implements IBrand.Icon
            Get
                Return Brand.Icon
            End Get
            Set(value As String)
                Brand.Icon = value
            End Set
        End Property
    End Class
End Namespace
