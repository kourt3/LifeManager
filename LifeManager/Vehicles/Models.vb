Module Models
    Enum VehicleCategory
        None
        Car
        Moto
        Track
        all
    End Enum
    Sub Info(Vmodel As Vehicles.Vehicle.Model.Contracts.IModel)
        Console.WriteLine("ID: " & Vmodel.PrimaryKey)
        Console.WriteLine("Name Brand: " & VehiclesController.Brand.Exist(New Vehicles.Vehicle.Brand.Contracts.Contracts With {.PrimaryKey = Vmodel.BrandId}).Model.Name)
        Console.WriteLine("Name Model: " & Vmodel.Name)
        Console.WriteLine("Category: " & Vmodel.CategoryName)
    End Sub
    Sub Menu(VmodelRef As Vehicles.Vehicle.Base.IReference)
        Do
            Console.Clear()
            Console.WriteLine("----------- Model -------------")
            Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Model.Contracts.Contracts) = VehiclesController.Model.Exist(VmodelRef)
            Info(Val.Model)
            Console.WriteLine("------------ Menu -------------")
            Console.WriteLine("1) List Of Vehicles.")
            Console.WriteLine("2) Change Name.")
            Console.WriteLine("3) Change Category.")
            Console.WriteLine("4) Remove Model.")
            Console.WriteLine("5) Exit.")
            Console.WriteLine("Επέλεξε ενα απο το Μενου:")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    VehiclesModule.ListOfVehicles(VmodelRef)
                Case 2
                    ChangeName(VmodelRef)
                Case 3
                    ChangeCategory(VmodelRef)
                Case 4
                    Remove(VmodelRef)
                Case 5
                    Exit Do
                Case Else
            End Select
        Loop
    End Sub
    Sub ListOfCategory(BrandRef As Vehicles.Vehicle.Base.IReference, Optional Choice As Boolean = False, Optional ByRef ChoiceCategory As VehicleCategory = Nothing)
        Do
            Console.Clear()
            If Choice = False Then
                Console.WriteLine("-------------- Category -------------")
            Else
                Console.WriteLine("-------------- Choice Category --------------")
            End If
            If Choice = False Then
                Console.WriteLine("1) Car")
                Console.WriteLine("2) Moto")
                Console.WriteLine("3) Truck")
                Console.WriteLine("4) All")
                Console.WriteLine("5) Exit")
                Dim ChoiceStr As String = Console.ReadLine
                Select Case ChoiceStr
                    Case 1
                        ListModels(BrandRef, VehicleCategory.Car)
                    Case 2
                        ListModels(BrandRef, VehicleCategory.Moto)
                    Case 3
                        ListModels(BrandRef, VehicleCategory.Track)
                    Case 4
                        ListModels(BrandRef, VehicleCategory.all)
                    Case 5
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            Else
                Console.WriteLine("1) Car")
                Console.WriteLine("2) Moto")
                Console.WriteLine("3) Truck")
                Console.WriteLine("4) Exit")
                Dim ChoiceStr As String = Console.ReadLine
                Select Case ChoiceStr
                    Case 1
                        ChoiceCategory = VehicleCategory.Car
                        Exit Sub
                    Case 2
                        ChoiceCategory = VehicleCategory.Moto
                        Exit Sub
                    Case 3
                        ChoiceCategory = VehicleCategory.Track
                        Exit Sub
                    Case 4
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            End If

        Loop
    End Sub
    Sub ListModels(BrandRef As Vehicles.Vehicle.Base.IReference, ChoiceCategory As VehicleCategory, Optional ChoiceModel As Boolean = False, Optional ByRef ChoiceRef As Vehicles.Vehicle.Base.IReference = Nothing)

        Do
            Dim Val As New MyBook.ValMsg(Of List(Of Vehicles.Vehicle.Model.Contracts.Contracts))
            Dim Creteria As Vehicles.Vehicle.Model.Contracts.ICreteria = New Vehicles.Vehicle.Model.Contracts.Contracts
            Console.Clear()
            If ChoiceCategory = VehicleCategory.Car Then
                Creteria.CategoryName = "Car"
                Val = VehiclesController.Model.Search(Creteria)
                Console.WriteLine("-------------------- Models Of Cars ---------------")
            ElseIf ChoiceCategory = VehicleCategory.Moto Then
                Creteria.CategoryName = "Moto"
                Val = VehiclesController.Model.Search(Creteria)
                Console.WriteLine("-------------------- Models Of Moto ---------------")
            ElseIf ChoiceCategory = VehicleCategory.Track Then
                Creteria.CategoryName = "Tracks"
                Val = VehiclesController.Model.Search(Creteria)
                Console.WriteLine("-------------------- Models Of Tracks ---------------")
            ElseIf ChoiceCategory = VehicleCategory.all Or ChoiceCategory = VehicleCategory.None Then
                Val = VehiclesController.Model.Get_All

            End If

            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.WriteLine("------------- Menu -----------")
                Console.WriteLine("1) Register Model.")
                Console.WriteLine("2) Exit.")
                Console.WriteLine("Επέλεξε ενα απο το μενου: ")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(BrandRef, ChoiceCategory)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            Else
                For i = 0 To Val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & Val.Model(i).Name)
                Next
                Console.WriteLine("----------- Menu -------------")
                If ChoiceModel = False Then
                    Console.WriteLine(1 & " - " & Val.Model.Count & ") Open Model.")
                Else
                    Console.WriteLine(1 & " - " & Val.Model.Count & ") Choice Model.")
                End If
                Console.WriteLine(Val.Model.Count + 1 & ") Register Model.")
                Console.WriteLine(Val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To Val.Model.Count - 1
                        If ChoiceModel = False Then
                            Menu(Val.Model(Choice))
                        Else
                            ChoiceRef = Val.Model(Choice)
                            Exit Sub
                        End If
                    Case Val.Model.Count
                        Register(BrandRef, Choice)
                    Case Val.Model.Count + 1
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            End If
        Loop
    End Sub
    Sub Register(BrandRef As Vehicles.Vehicle.Base.IReference, Optional ChoiceCategory As VehicleCategory = VehicleCategory.None)
        Dim Register As Vehicles.Vehicle.Model.Contracts.IRegisterDTO = New Vehicles.Vehicle.Model.Contracts.Contracts
        If BrandRef Is Nothing Then
            ListOfBrands(True, BrandRef)
        End If
        Register.BrandId = BrandRef.PrimaryKey
        Console.Clear()
        Console.WriteLine("-------------- Register Model ------------")
        If ChoiceCategory = VehicleCategory.None Or ChoiceCategory = VehicleCategory.all Then
            ListOfCategory(BrandRef, True, ChoiceCategory)
        End If
        Console.WriteLine("Δώσε το ονομα Model:")
        Register.Name = Console.ReadLine
        If ChoiceCategory = VehicleCategory.Car Then
            Register.CategoryName = "Car"
        ElseIf ChoiceCategory = VehicleCategory.Moto Then
            Register.CategoryName = "Moto"
        ElseIf ChoiceCategory = VehicleCategory.Track Then
            Register.CategoryName = "Track"
        End If

        If Help.AccessChoice("Θέλεις να συνεχισεις στην εγραφή;") Then
            Console.WriteLine(VehiclesController.Model.Register(Register).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub Change(VmodelRef As Vehicles.Vehicle.Base.IReference)

    End Sub
    Sub ChangeName(VmodelRef As Vehicles.Vehicle.Base.IReference)
        Console.Clear()
        Console.WriteLine("-------------- Change Name ----------------")
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Model.Contracts.Contracts) = VehiclesController.Model.Exist(VmodelRef)
        Info(VmodelRef)
        Dim Change As Vehicles.Vehicle.Model.Contracts.IChangeName = New Vehicles.Vehicle.Model.Contracts.Contracts
        Console.WriteLine("Δώσε το όνομα Αλλάγής:")
        Change.Name = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις;") Then
            Console.WriteLine(VehiclesController.Model.Change(VmodelRef, Change).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub ChangeCategory(VmodelRef As Vehicles.Vehicle.Base.IReference)
        Console.Clear()
        Console.WriteLine("-------------- Change Category ----------------")
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Model.Contracts.Contracts) = VehiclesController.Model.Exist(VmodelRef)
        Info(VmodelRef)
        Dim Change As Vehicles.Vehicle.Model.Contracts.IChangeCategory = New Vehicles.Vehicle.Model.Contracts.Contracts
        Dim ChoiceCategory As VehicleCategory

        ListOfCategory(VmodelRef, True, ChoiceCategory)
        If ChoiceCategory = VehicleCategory.Car Then
            Change.CategoryName = "Car"
        ElseIf ChoiceCategory = VehicleCategory.Moto Then
            Change.CategoryName = "Moto"
        ElseIf ChoiceCategory = VehicleCategory.Track Then
            Change.CategoryName = "Track"
        Else
            Exit Sub
        End If
        If Help.AccessChoice("Θέλεις να συνεχήσεις;") Then
            Console.WriteLine(VehiclesController.Model.Change(VmodelRef, Change).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub Remove(VmodelRef As Vehicles.Vehicle.Base.IReference)
        Console.Clear()
        Console.WriteLine("--------------- Remove Model --------------")
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Model.Contracts.Contracts) = VehiclesController.Model.Exist(VmodelRef)
        Info(Val.Model)
        If Help.AccessChoice("Θέλεις να Σύνεχήσεις με την Διαγραφή;") Then
            Console.WriteLine(VehiclesController.Model.Remove(VmodelRef).Msg)
            Console.ReadLine()
        End If
    End Sub
End Module
