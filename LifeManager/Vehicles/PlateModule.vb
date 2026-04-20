Imports Vehicles.Vehicle.Plate
Module PlateModule
    Sub Info(PlateModel As Vehicles.Vehicle.Plate.Contracts.IModel)
        Dim ControllerModel As Vehicles.Vehicle.Controller.IModel = VehiclesController.ExistVehicle(New Vehicles.Vehicle.Vehicles.Contracts.Contracrs With {.PrimaryKey = PlateModel.VehicleId}).Model
        Console.WriteLine("ID: " & PlateModel.PrimaryKey)
        Console.WriteLine("BrandName: " & ControllerModel.Brand.Name)
        Console.WriteLine("Model: " & ControllerModel.Model.Name)
        Console.WriteLine("Category: " & ControllerModel.Model.CategoryName)
        Console.WriteLine("CreateAt: " & ControllerModel.Vehicle.CretatedAt)
        Console.WriteLine("Πινακίδα: " & PlateModel.NumberPlate)
        Console.WriteLine("Χώρα Πινακίδας: " & PlateModel.Country)
        Console.WriteLine("Icon: " & PlateModel.Icon)
    End Sub
    Sub Menu(AccountRef As ProfileComponent.Profile.Able.IReference, PlateRef As Vehicles.Vehicle.Base.IReference)
        Do
            Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = VehiclesController.Plate.Exist(PlateRef)
            If Val.Success = False Then
                Exit Sub
            End If
            Console.Clear()
            Console.WriteLine("------------- Info Paltes --------------")
            Info(Val.Model)
            Console.WriteLine()
            Console.WriteLine("------------- Menu ------------")
            Console.WriteLine("1) Update Plate Country.")
            Console.WriteLine("2) Update Plate.")
            Console.WriteLine("3) Remove.")
            Console.WriteLine("4) Exit.")
            Console.WriteLine("Επέλεξε ενα απο το μενου:")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    ChangeCountry(PlateRef)
                Case 2
                    ChangePlate(PlateRef)
                Case 3
                    Remove(PlateRef)
                Case 4
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Sub ListOfPlates(AccountRef As ProfileComponent.Profile.Able.IReference)
        Do

            Dim Val As MyBook.ValMsg(Of List(Of Vehicles.Vehicle.Controller.ModelController)) = VehiclesController.ListOfPlate(AccountRef.PrimaryKey)
            Console.Clear()
            Console.WriteLine("------------------ List Of Plates ---------------")
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.WriteLine("---------------- Menu -------------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AccountRef)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            Else
                For i = 0 To Val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & Val.Model(i).ToString)
                Next
                Console.WriteLine()
                Console.WriteLine("----------- Menu ----------")
                Console.WriteLine(1 & " - " & Val.Model.Count & ") Open Plate.")
                Console.WriteLine(Val.Model.Count + 1 & ") Register.")
                Console.WriteLine(Val.Model.Count + 2 & ") Exit.")
                Console.WriteLine("Επέλεξε ενα απο το μενου:")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To Val.Model.Count - 1
                        Menu(AccountRef, Val.Model(Choice).Plate)
                    Case Val.Model.Count
                        Register(AccountRef)
                    Case Val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End If
        Loop
    End Sub
    Sub Register(AccountRef As ProfileComponent.Profile.Able.IReference)
        Dim RegisterDTO As Contracts.IRegisterDTO = New Contracts.Contracts
        RegisterDTO.ExternalID = AccountRef.PrimaryKey
        Console.Clear()
        Console.WriteLine("-------------- Register Plate ------------")
        Dim VBrand As Vehicles.Vehicle.Base.IReference = New Contracts.Contracts
        BrandsModule.ListOfBrands(True, VBrand)

        Dim ChoiceCategory As Models.VehicleCategory
        Models.ListOfCategory(VBrand, True, ChoiceCategory)

        Dim Vmodel As Vehicles.Vehicle.Base.IReference = New Contracts.Contracts
        Models.ListModels(VBrand, ChoiceCategory, True, Vmodel)

        Dim VihecleModel As Vehicles.Vehicle.Base.IReference = New Vehicles.Vehicle.Vehicles.Contracts.Contracrs
        VehiclesModule.ListOfVehicles(Vmodel, True, VihecleModel)
        RegisterDTO.VehicleId = VihecleModel.PrimaryKey

        Console.WriteLine("Δώσε πινακίδα:")
        RegisterDTO.NumberPlate = Console.ReadLine

        Console.WriteLine("Δώσε Χώρα πινακίδας:")
        Dim CountryRef As AdressesProject.My.Ables.IReference = New AdressesProject.My.Entity.Entity
        AddressesModule.ListOf(AddressType.County, True, CountryRef)
        RegisterDTO.Country = AddressController.Country.Exist(CountryRef).Model.Value

        Console.Clear()
        Console.WriteLine("-------------- Register Plate -------------")
        Dim Model As Contracts.Contracts = RegisterDTO
        Info(Model)

        If Help.AccessChoice("Θέλεις να συνεχήσεις με την εγραφή;") Then
            Console.WriteLine(VehiclesController.Plate.Register(RegisterDTO).Msg)
            Console.ReadLine()
        End If

    End Sub
    Sub ChangePlate(PlateRef As Vehicles.Vehicle.Base.IReference)
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Plate.Contracts.Contracts) = VehiclesController.Plate.Exist(PlateRef)
        Dim ChangeDTO As Contracts.IChangePlateDTO = New Contracts.Contracts
        Console.Clear()
        Console.WriteLine("-------------- Change Plate ----------------")
        Info(Val.Model)
        Console.WriteLine("------------------")
        Console.WriteLine("Δώσε κανουργιο αριθμο πινακιδας:")
        ChangeDTO.NumberPlate = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις με την αλλαγή?") Then
            Console.WriteLine(VehiclesController.Plate.Change(PlateRef, ChangeDTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub ChangeCountry(PlateRef As Vehicles.Vehicle.Base.IReference)
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Plate.Contracts.Contracts) = VehiclesController.Plate.Exist(PlateRef)
        Dim ChangeDTO As Contracts.IChangeCountryDTO = New Contracts.Contracts
        Console.Clear()
        Console.WriteLine("-------------- Change Plate ----------------")
        Info(Val.Model)
        Console.WriteLine("------------------")
        Dim Country As AdressesProject.My.Ables.IReference = New AdressesProject.My.Entity.Entity
        AddressesModule.ListOf(AddressType.County, True, Country)
        ChangeDTO.Country = AddressController.Country.Exist(Country).Model.Value
        If Help.AccessChoice("Θέλεις να συνεχήσεις με την αλλαγή?") Then
            Console.WriteLine(VehiclesController.Plate.Change(PlateRef, ChangeDTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub Remove(PlateRef As Vehicles.Vehicle.Base.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = VehiclesController.Plate.Exist(PlateRef)
        Console.Clear()
        Console.WriteLine("------------------ Remove Plate -------------------")
        Info(Val.Model)
        Console.WriteLine("--------------------------")
        If Help.AccessChoice("Θέλεις να συνεχήσεις με την διαγραφή;") Then
            Console.WriteLine(VehiclesController.Plate.Remove(PlateRef).Msg)
        End If
    End Sub
End Module
