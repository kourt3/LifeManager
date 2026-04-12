Module BrandsModule
    Sub Info(Model As Vehicles.Vehicle.Brand.Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Name: " & Model.Name)
        Console.WriteLine("Icon: " & Model.Icon)
    End Sub
    Sub Menu(Brandref As Vehicles.Vehicle.Base.IReference)
        Do
            Console.Clear()
            Console.WriteLine("------------- Brands -----------")
            Dim Model As MyBook.ValMsg(Of Vehicles.Vehicle.Brand.Contracts.Contracts) = VehiclesController.Brand.Exist(Brandref)
            If Model.Success = False Then
                Console.WriteLine(Model.Msg)
                Exit Do
            End If
            Info(Model.Model)
            Console.WriteLine()
            Console.WriteLine("---------- Menu -------------")
            Console.WriteLine("1) List Of Models")
            Console.WriteLine("2) Change Name.")
            Console.WriteLine("3) Remove Brand.")
            Console.WriteLine("4) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    ListOfCategory(Brandref)
                Case 2
                    ChangeName(Model.Model)
                Case 3
                    RemoveBrand(Model.Model)
                Case 4
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Sub ListOfBrands(Optional Choice As Boolean = False, Optional ByRef ChoiceRef As Vehicles.Vehicle.Base.IReference = Nothing)
        Do
            Console.Clear()
            Console.WriteLine("----------- List Of Brands -------------")
            Dim Val As MyBook.ValMsg(Of List(Of Vehicles.Vehicle.Brand.Contracts.Contracts)) = VehiclesController.Brand.Get_All
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.WriteLine("--------- Menu ---------")
                Console.WriteLine("1) Register Brand.")
                Console.WriteLine("2) Exit.")
                Dim ChoiceStr As String = Console.ReadLine
                Select Case ChoiceStr
                    Case 1
                        Register()
                    Case 2
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            Else
                For i = 0 To Val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & Val.Model(i).Name & " | Icon:" & Val.Model(i).Icon)
                Next
                Console.WriteLine()
                Console.WriteLine("---------- Menu ---------")
                If Choice = False Then
                    Console.WriteLine(1 & " - " & Val.Model.Count & ") Open Brand.")
                    Console.WriteLine(Val.Model.Count + 1 & ") Register Brand.")
                    Console.WriteLine(Val.Model.Count + 2 & ") List Of Brands and Models.")
                    Console.WriteLine(Val.Model.Count + 3 & ") Exit.")
                    Dim ChoiceStr As String = Console.ReadLine - 1
                    Select Case ChoiceStr
                        Case 0 To Val.Model.Count - 1
                            If Choice = False Then
                                Menu(Val.Model(ChoiceStr))
                            Else
                                ChoiceRef = Val.Model(ChoiceStr)
                                Exit Do
                            End If
                        Case Val.Model.Count
                            Register()
                        Case Val.Model.Count + 1
                            ListModels(Nothing, VehicleCategory.None)
                        Case Val.Model.Count + 2
                            Exit Do
                        Case Else
                            Continue Do
                    End Select
                Else
                    Console.WriteLine(1 & " - " & Val.Model.Count & ") Choice Brand.")
                    Console.WriteLine(Val.Model.Count + 1 & ") Register Brand.")
                    Console.WriteLine(Val.Model.Count + 2 & ") Exit.")
                    Dim ChoiceStr As String = Console.ReadLine - 1
                    Select Case ChoiceStr
                        Case 0 To Val.Model.Count - 1
                            If Choice = False Then
                                Menu(Val.Model(ChoiceStr))
                            Else
                                ChoiceRef = Val.Model(ChoiceStr)
                                Exit Do
                            End If
                        Case Val.Model.Count
                            Register()
                        Case Val.Model.Count + 1
                            Exit Do
                        Case Else
                            Continue Do
                    End Select
                End If

            End If
        Loop
    End Sub
    Sub Register()
        Console.Clear()
        Console.WriteLine("---------- Register ------------")
        Dim RegisterDTO As Vehicles.Vehicle.Brand.Contracts.IRegisterDTO = New Vehicles.Vehicle.Brand.Contracts.Contracts
        Console.WriteLine("Δώσε το ονομα:")
        RegisterDTO.Name = Console.ReadLine
        Console.WriteLine("Δώσε το Αρχειο Διαδρομης Εικόνας.")
        RegisterDTO.Icon = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις στην Εγραφή?") Then
            Console.WriteLine(VehiclesController.Brand.Register(RegisterDTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub ChangeName(BrandRef As Vehicles.Vehicle.Base.IReference)
        Console.Clear()
        Console.WriteLine("----------- Change Name ------------")
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Brand.Contracts.Contracts) = VehiclesController.Brand.Exist(BrandRef)
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Exit Sub
        End If
        Dim Change As Vehicles.Vehicle.Brand.Contracts.IChangeNameDTO = New Vehicles.Vehicle.Brand.Contracts.Contracts
        If Help.IfNotInputOrMsg("Δώσε το ονομα: ", Change.Name) = True Then
            If Help.AccessChoice("Θέλεις να συνέχησεις;") Then
                Console.WriteLine(VehiclesController.Brand.Change(BrandRef, Change).Msg)
                Console.ReadLine()
            End If
        End If

    End Sub
    Sub ChangeIcon(BrandRef As Vehicles.Vehicle.Base.IReference)
        Console.Clear()
        Console.WriteLine("----------- Change Icon ------------")
        Dim Val As MyBook.ValMsg(Of Vehicles.Vehicle.Brand.Contracts.Contracts) = VehiclesController.Brand.Exist(BrandRef)
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Exit Sub
        End If
        Dim Change As Vehicles.Vehicle.Brand.Contracts.IChangeIconDTO = New Vehicles.Vehicle.Brand.Contracts.Contracts
        If Help.IfNotInputOrMsg("Δώσε το ονομα: ", Change.Icon) = True Then
            If Help.AccessChoice("Θέλεις να συνέχησεις;") Then
                Console.WriteLine(VehiclesController.Brand.Change(BrandRef, Change).Msg)
                Console.ReadLine()
            End If
        End If
    End Sub
    Sub RemoveBrand(BrandRef As Vehicles.Vehicle.Base.IReference)
        Console.Clear()
        Console.WriteLine("----------- Remove Brand ----------")
        Dim val As MyBook.ValMsg(Of Vehicles.Vehicle.Brand.Contracts.Contracts) = VehiclesController.Brand.Exist(BrandRef)
        If val.Success = False Then
            Console.WriteLine(val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        If Help.AccessChoice("Θέλεις να διαγράψεις το Brand? ") Then
            Console.WriteLine(VehiclesController.Brand.Remove(BrandRef).Msg)
            Console.ReadLine()
        End If
    End Sub
End Module
