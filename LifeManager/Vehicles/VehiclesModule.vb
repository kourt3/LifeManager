Module VehiclesModule
    Sub info(Model As Vehicles.Vehicle.Vehicles.Contracts.IModel)
        Dim VModel As Vehicles.Vehicle.Model.Contracts.IModel = VehiclesController.Model.Exist(New Vehicles.Vehicle.Model.Contracts.Contracts With {.PrimaryKey = Model.ModelId}).Model
        Dim VBrand As Vehicles.Vehicle.Brand.Contracts.IModel = VehiclesController.Brand.Exist(New Vehicles.Vehicle.Brand.Contracts.Contracts With {.PrimaryKey = VModel.BrandId}).Model
        Console.WriteLine("ID: " & Model.ModelId)
        Console.WriteLine("BrandName: " & VBrand.Name)
        Console.WriteLine("Model: " & VModel.Name)
        Console.WriteLine("Category: " & VModel.CategoryName)
        Console.WriteLine("Created At: " & Model.CretatedAt)
    End Sub
    Sub Menu(Vref As Vehicles.Vehicle.Base.IReference)
        Do
            Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Vehicles.Contracts.Contracrs) = VehiclesController.Vehicle.Exist(Vref)
            Console.Clear()
            Console.WriteLine("----------------- Vehicle --------------------")
            If Val.Success = False Then
                Exit Sub
            End If
            info(Val.Model)
            Console.WriteLine()
            Console.WriteLine("------------ Menu -----------")
            Console.WriteLine("1) Update.")
            Console.WriteLine("2) Remove.")
            Console.WriteLine("3) Exit.")
            Console.WriteLine("Επέλεξε ενα απο το μενου:")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Change(Vref)
                Case 2
                    Remove(Vref)
                Case 3
                    Exit Sub
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Sub ListOfVehicles(VModelRef As Vehicles.Vehicle.Base.IReference, Optional Choicer As Boolean = False, Optional ByRef ChoiceRef As Vehicles.Vehicle.Base.IReference = Nothing)
        Do
            Dim Creteria As Vehicles.Vehicle.Vehicles.Contracts.ICreteria = New Vehicles.Vehicle.Vehicles.Contracts.Contracrs
            Creteria.ModelId = VModelRef.PrimaryKey
            Dim Val As MyBook.ValMsg(Of List(Of Vehicles.Vehicle.Vehicles.Contracts.Contracrs)) = VehiclesController.Vehicle.Search(Creteria)
            Console.Clear()
            If Choicer = False Then
                Console.WriteLine("-------------- List Of Vehicles ------------------")
            Else
                Console.WriteLine("-------------- Choice Vehicle ------------------")
            End If
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.WriteLine("------------ Menu -----------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(VModelRef)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            Else
                For i = 0 To Val.Model.Count - 1
                    Dim VModel As Vehicles.Vehicle.Model.Contracts.IModel = VehiclesController.Model.Exist(New Vehicles.Vehicle.Model.Contracts.Contracts With {.PrimaryKey = Val.Model(i).ModelId}).Model
                    Dim VBrand As Vehicles.Vehicle.Brand.Contracts.IModel = VehiclesController.Brand.Exist(New Vehicles.Vehicle.Brand.Contracts.Contracts With {.PrimaryKey = VModel.BrandId}).Model
                    Console.WriteLine(i + 1 & " ) BrandName: " & VBrand.Name & " | Model: " & VModel.Name & " | Category: " & VModel.CategoryName & " | CreatedAt: " & Val.Model(i).CretatedAt)
                Next
                Console.WriteLine()
                Console.WriteLine("-------------- Menu -------------")
                If Choicer = False Then
                    Console.WriteLine(1 & " - " & Val.Model.Count & ") Open Vehicle.")
                Else
                    Console.WriteLine(1 & " - " & Val.Model.Count & ") Choice Vehicle.")
                End If
                Console.WriteLine(Val.Model.Count + 1 & ") Register.")
                Console.WriteLine(Val.Model.Count + 2 & ") Exit.")
                Console.WriteLine("Επέλεξε ενα απο το Μενου:")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To Val.Model.Count - 1
                        If Choicer = False Then
                            Menu(Val.Model(Choice))
                        Else
                            ChoiceRef = Val.Model(Choice)
                            Exit Sub
                        End If
                    Case Val.Model.Count
                        Register(VModelRef)
                    Case Val.Model.Count + 1
                        Exit Sub
                End Select
            End If

        Loop
    End Sub
    Sub Register(Vmodelref As Vehicles.Vehicle.Base.IReference)
        Dim RegisterDTO As Vehicles.Vehicle.Vehicles.Contracts.IRegisterDTO = New Vehicles.Vehicle.Vehicles.Contracts.Contracrs
        RegisterDTO.ModelId = Vmodelref.PrimaryKey
        Console.Clear()
        Console.WriteLine("--------------- Register Vehicle -----------------")
        Console.WriteLine("Δώσε Ημμερομηνια Δημιουργιας:")
        RegisterDTO.CretatedAt = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις;") Then
            Console.WriteLine(VehiclesController.Vehicle.Register(RegisterDTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub Change(Vref As Vehicles.Vehicle.Base.IReference)
        Dim Change As Vehicles.Vehicle.Vehicles.Contracts.IChangeCreatedDTO = New Vehicles.Vehicle.Vehicles.Contracts.Contracrs
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Vehicles.Contracts.Contracrs) = VehiclesController.Vehicle.Exist(Vref)
        Console.Clear()
        Console.WriteLine("---------------- Change Date --------------")
        info(Val.Model)
        Console.WriteLine("---------------------------------")
        Console.WriteLine("Δώσε Καινουργια ημμερομηνια Δήμιουργιας: ")
        Change.CretatedAt = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχησεις στην αλλαγή;") Then
            Console.WriteLine(VehiclesController.Vehicle.Change(Vref, Change).Msg)
        End If
    End Sub
    Sub Remove(VRef As Vehicles.Vehicle.Base.IReference)
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Vehicles.Contracts.Contracrs) = VehiclesController.Vehicle.Exist(VRef)
        Console.Clear()
        Console.WriteLine("---------------- Remove Vehicles ----------------")
        info(Val.Model)
        Console.WriteLine("-----------------------------------------")
        If Help.AccessChoice("Θέλεις να συνεχήσεις με την διαγραφή;") Then
            Console.WriteLine(VehiclesController.Vehicle.Remove(VRef).Msg)
            Console.ReadLine()
        End If
    End Sub
End Module
