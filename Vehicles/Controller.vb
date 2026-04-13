Namespace Vehicle.Controller
    Public Interface IModel
        Property Brand As Vehicle.Brand.Contracts.IModel
        Property Model As Vehicle.Model.Contracts.IModel
        Property Vehicle As Vehicle.Vehicles.Contracts.IModel
        Property Plate As Vehicle.Plate.Contracts.IModel
    End Interface
    Public Interface IRegisterVehicleDTO
        Property Brand As Brand.Contracts.IRegisterDTO
        Property Model As Vehicle.Model.Contracts.IRegisterDTO
        Property Vehicle As Vehicle.Vehicles.Contracts.IRegisterDTO
    End Interface
    Public Interface IRegisterPlateDTO
        Property Brand As Brand.Contracts.IRegisterDTO
        Property Model As Vehicle.Model.Contracts.IRegisterDTO
        Property Vehicle As Vehicle.Vehicles.Contracts.IRegisterDTO
        Property Plate As Vehicle.Plate.Contracts.IRegisterDTO
    End Interface
    Public Class ModelController
        Implements IModel

        Public Property Brand As Brand.Contracts.IModel Implements IModel.Brand
        Public Property Vehicle As Vehicles.Contracts.IModel Implements IModel.Vehicle
        Public Property Model As Model.Contracts.IModel Implements IModel.Model
        Public Property Plate As Plate.Contracts.IModel Implements IModel.Plate

        Public Overrides Function ToString() As String
            Return "Brand: " & Brand.Name & " | Model: " & Model.Name & " | Category: " & Model.CategoryName & " | Create At: " & Vehicle.CretatedAt & " | Plate: " & Plate.NumberPlate & " | Country Plate: " & Plate.Country
        End Function

        Sub New()
            Brand = New Vehicle.Brand.Contracts.Contracts
            Vehicle = New Vehicle.Vehicles.Contracts.Contracrs
            Model = New Model.Contracts.Contracts
            Plate = New Plate.Contracts.Contracts
        End Sub

    End Class

    Public Class Controller
        Public Brand As New Vehicle.Brand.Service.Service
        Public Model As New Vehicle.Model.Service.Service
        Public Vehicle As New Vehicle.Vehicles.Service.Service
        Public Plate As New Vehicle.Plate.Service.Service

        Function ExistVehicle(VehicleRef As Vehicle.Base.IReference) As MyBook.ValMsg(Of ModelController)
            Dim ReturnModel As New MyBook.ValMsg(Of ModelController)
            ReturnModel.Model = New ModelController
            Dim VihecleVal As MyBook.ValMsg(Of Vehicle.Vehicles.Contracts.Contracrs) = Vehicle.Exist(VehicleRef)
            Dim VModelVal As MyBook.ValMsg(Of Vehicle.Model.Contracts.Contracts) = Model.Exist(New Vehicle.Model.Contracts.Contracts With {.PrimaryKey = VihecleVal.Model.ModelId})
            Dim BrandVal As MyBook.ValMsg(Of Vehicle.Brand.Contracts.Contracts) = Brand.Exist(New Vehicle.Brand.Contracts.Contracts With {.PrimaryKey = VModelVal.Model.BrandId})
            ReturnModel.Model.Brand = BrandVal.Model
            ReturnModel.Model.Model = VModelVal.Model
            ReturnModel.Model.Vehicle = VihecleVal.Model
            Return ReturnModel
        End Function
        Function ExistPlate(PlateRef As Vehicle.Base.IReference) As MyBook.ValMsg(Of ModelController)
            Dim ReturnModel As New MyBook.ValMsg(Of ModelController)
            ReturnModel.Model = New ModelController
            Dim PlateVal As MyBook.ValMsg(Of Vehicle.Plate.Contracts.Contracts) = Plate.Exist(PlateRef)
            Dim VihecleVal As MyBook.ValMsg(Of Vehicle.Vehicles.Contracts.Contracrs) = Vehicle.Exist(New Vehicles.Contracts.Contracrs With {.PrimaryKey = PlateVal.Model.VehicleId})
            Dim VModelVal As MyBook.ValMsg(Of Vehicle.Model.Contracts.Contracts) = Model.Exist(New Vehicle.Model.Contracts.Contracts With {.PrimaryKey = VihecleVal.Model.ModelId})
            Dim BrandVal As MyBook.ValMsg(Of Vehicle.Brand.Contracts.Contracts) = Brand.Exist(New Vehicle.Brand.Contracts.Contracts With {.PrimaryKey = VModelVal.Model.BrandId})
            ReturnModel.Model.Brand = BrandVal.Model
            ReturnModel.Model.Model = VModelVal.Model
            ReturnModel.Model.Vehicle = VihecleVal.Model
            ReturnModel.Model.Plate = PlateVal.Model
            Return ReturnModel
        End Function
        Function ListOfPlate(ExteranId As Integer) As MyBook.ValMsg(Of List(Of ModelController))
            Dim Val As New MyBook.ValMsg(Of List(Of ModelController))
            Val.Model = New List(Of ModelController)
            Val.Success = False
            Val.Msg = "Δεν Βρέθηκε εγραφή!"
            Dim Creteria As Vehicle.Plate.Contracts.ICreteria = New Vehicle.Plate.Contracts.Contracts
            Creteria.ExternalID = ExteranId
            For Each Entity In Plate.Search(Creteria).Model
                Val.Model.Add(ExistPlate(Entity).Model)
                Val.Success = True
                Val.Msg = "Βρέθηκε η εγραφή!"
            Next
            Return Val
        End Function

        Function RegisterVehicle(RegisterDTO As IRegisterVehicleDTO) As MyBook.ValMsg(Of ModelController)
            Dim ValBrand As MyBook.ValMsg(Of Vehicle.Brand.Contracts.Contracts) = Brand.Register(RegisterDTO.Brand)
            Dim ValModel As MyBook.ValMsg(Of Vehicle.Model.Contracts.Contracts) = Model.Register(RegisterDTO.Model)
            Dim ValVehicle As MyBook.ValMsg(Of Vehicle.Vehicles.Contracts.Contracrs) = Vehicle.Register(RegisterDTO.Vehicle)

            Dim ReturnModel As New MyBook.ValMsg(Of ModelController)
            ReturnModel.Model.Brand = ValBrand.Model
            ReturnModel.Model.Model = ValModel.Model
            ReturnModel.Model.Vehicle = ValVehicle.Model
            Return ReturnModel
        End Function
        Function RegisterPlate(Of TExtrernalRef As MyBook.IHasPrimaryKey(Of Integer))(ExternalRef As TExtrernalRef, RegisterDTO As IRegisterPlateDTO) As MyBook.ValMsg(Of ModelController)
            Dim ValBrand As MyBook.ValMsg(Of Vehicle.Brand.Contracts.Contracts) = Brand.Register(RegisterDTO.Brand)
            Dim ValModel As MyBook.ValMsg(Of Vehicle.Model.Contracts.Contracts) = Model.Register(RegisterDTO.Model)
            Dim ValVehicle As MyBook.ValMsg(Of Vehicle.Vehicles.Contracts.Contracrs) = Vehicle.Register(RegisterDTO.Vehicle)
            Dim ValPlate As MyBook.ValMsg(Of Vehicle.Plate.Contracts.Contracts) = Plate.Register(RegisterDTO.Plate)

            Dim ReturnModel As New MyBook.ValMsg(Of ModelController)
            ReturnModel.Model.Brand = ValBrand.Model
            ReturnModel.Model.Model = ValModel.Model
            ReturnModel.Model.Vehicle = ValVehicle.Model
            ReturnModel.Model.Plate = ValPlate.Model
            Return ReturnModel

        End Function


    End Class
End Namespace


