Namespace Vehicle.Controller
    Public Interface IModel
        Property Brand As Vehicle.Brand.Contracts.IModel
        Property Model As Vehicle.Model.Contracts.IModel
        Property Vehicle As Vehicle.Vehicles.Contracts.IModel
    End Interface
    Public Interface IRegisterDTO
        Property Brand As Brand.Contracts.IRegisterDTO
        Property Model As Vehicle.Model.Contracts.IRegisterDTO
        Property Vehicle As Vehicle.Vehicles.Contracts.IRegisterDTO
    End Interface

    Public Class ModelController
        Implements IModel

        Public Property Brand As Brand.Contracts.IModel Implements IModel.Brand
        Public Property Vehicle As Vehicles.Contracts.IModel Implements IModel.Vehicle
        Public Property Model As Model.Contracts.IModel Implements IModel.Model
        Sub New()
            Brand = New Vehicle.Brand.Contracts.Contracts
            Vehicle = New Vehicle.Vehicles.Contracts.Contracrs
            Model = New Model.Contracts.Contracts
        End Sub

    End Class
    Public Class Controller
        Public Brand As New Vehicle.Brand.Service.Service
        Public Model As New Vehicle.Model.Service.Service
        Public Vehicle As New Vehicle.Vehicles.Service.Service

        Function AddVehicle(RegisterDTO As IRegisterDTO) As ModelController

        End Function



    End Class
End Namespace


