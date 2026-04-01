Imports Economy.Controller

Module AddressesModule
    Enum AddressType
        County
        Perifereia
        Nomos
        TK
        Dhmos
        Address
        Number
    End Enum
    Sub Menu()
        Do
            Console.Clear()
            Console.WriteLine("---------- Menu ------------")
            Console.WriteLine("1) Country.")
            Console.WriteLine("2) Perifereia.")
            Console.WriteLine("3) Nomos.")
            Console.WriteLine("4) TK.")
            Console.WriteLine("5) Dhmos.")
            Console.WriteLine("6) Adresses.")
            Console.WriteLine("7) Number.")
            Console.WriteLine("8) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    ListOf(AddressType.County)
                Case 2
                    ListOf(AddressType.Perifereia)
                Case 3
                    ListOf(AddressType.Nomos)
                Case 4
                    ListOf(AddressType.TK)
                Case 5
                    ListOf(AddressType.Dhmos)
                Case 6
                    ListOf(AddressType.Address)
                Case 7
                    ListOf(AddressType.Number)
                Case 8
                    Exit Do
                Case Else
                    Continue Do
            End Select

        Loop
    End Sub
    Sub Open(Ref As AdressesProject.My.Ables.IReference, AddressType As AddressType)
        Dim Showmenu As Double = True
        While Showmenu = True
            Console.Clear()

            Dim Service As AdressesProject.Service = Nothing
            Dim Opt As New List(Of String)
            Dim Actions As New List(Of Action)
            If AddressType = AddressType.County Then
                Service = AddressController.Country
                Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
                If Model Is Nothing Then Exit Sub
                Console.WriteLine("--------- Info Country ----------")
                Console.WriteLine("Όνομα Χώρας: " & Model.Value)
                Console.WriteLine()
                Help.AddOption(Opt, Actions, "Update Country Name.", Sub() Update(Ref, AddressType.County))
                Help.AddOption(Opt, Actions, "Remove Country.", Sub() Remove(Ref, AddressType.County))
            ElseIf AddressType = AddressType.Perifereia Then
                Service = AddressController.Perifereia
                Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
                If Model Is Nothing Then Exit Sub
                Console.WriteLine("--------- Info Perifereia ----------")
                Console.WriteLine("Όνομα Χώρας: " & Model.Value)
                Console.WriteLine()
                Help.AddOption(Opt, Actions, "Update Perifereia Name", Sub() Update(Ref, AddressType.Perifereia))
                Help.AddOption(Opt, Actions, "Remove Perifereia.", Sub() Remove(Ref, AddressType.Perifereia))
            ElseIf AddressType = AddressType.Nomos Then
                Service = AddressController.Nomos
                Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
                If Model Is Nothing Then Exit Sub
                Console.WriteLine("--------- Info Nomos ----------")
                Console.WriteLine("Όνομα Χώρας: " & Model.Value)
                Console.WriteLine()
                Help.AddOption(Opt, Actions, "Update Nomos Name.", Sub() Update(Ref, AddressType.Nomos))
                Help.AddOption(Opt, Actions, "Remove Nomos.", Sub() Remove(Ref, AddressType.Nomos))
            ElseIf AddressType = AddressType.TK Then
                Service = AddressController.TK
                Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
                If Model Is Nothing Then Exit Sub
                Console.WriteLine("--------- Info TK ----------")
                Console.WriteLine("Όνομα Χώρας: " & Model.Value)
                Console.WriteLine()
                Help.AddOption(Opt, Actions, "Update TK Name.", Sub() Update(Ref, AddressType.TK))
                Help.AddOption(Opt, Actions, "Remove TK.", Sub() Remove(Ref, AddressType.TK))
            ElseIf AddressType = AddressType.Dhmos Then
                Service = AddressController.Dhmos
                Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
                If Model Is Nothing Then Exit Sub
                Console.WriteLine("--------- Info Dhmos ----------")
                Console.WriteLine("Όνομα Χώρας: " & Model.Value)
                Console.WriteLine()
                Help.AddOption(Opt, Actions, "Update Dhmos Name.", Sub() Update(Ref, AddressType.Dhmos))
                Help.AddOption(Opt, Actions, "Remove Dhmos.", Sub() Remove(Ref, AddressType.Dhmos))
            ElseIf AddressType = AddressType.Address Then
                Service = AddressController.Address
                Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
                If Model Is Nothing Then Exit Sub
                Console.WriteLine("--------- Info Address ----------")
                Console.WriteLine("Όνομα Χώρας: " & Model.Value)
                Console.WriteLine()
                Help.AddOption(Opt, Actions, "Update Address Name.", Sub() Update(Ref, AddressType.Address))
                Help.AddOption(Opt, Actions, "Remove Address.", Sub() Remove(Ref, AddressType.Address))
            ElseIf AddressType = AddressType.Number Then
                Service = AddressController.Number
                Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
                If Model Is Nothing Then Exit Sub
                Console.WriteLine("--------- Info Number ----------")
                Console.WriteLine("Όνομα Χώρας: " & Model.Value)
                Console.WriteLine()
                Help.AddOption(Opt, Actions, "Update Number Name", Sub() Update(Ref, AddressType.Number))
                Help.AddOption(Opt, Actions, "Remove Number.", Sub() Remove(Ref, AddressType.Number))
            End If
            Opt.Add("Exit.")
            Actions.Add(Sub() Showmenu = False)
            Help.PrintMenu(Opt)
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Actions(0).Invoke
                Case 2
                    Actions(1).Invoke
                Case 3
                    Actions(2).Invoke
                Case Else
                    Continue While
            End Select
            Opt.Clear()
            Actions.Clear()
        End While
    End Sub
    Sub Register(AddressType As AddressType)
        Dim Service As AdressesProject.Service = Nothing
        Console.Clear()

        If AddressType = AddressType.County Then
            Service = AddressController.Country
            Console.WriteLine("---------- Register Country ----------")
            Console.WriteLine("Δώσε Ονομα Country: ")
        ElseIf AddressType = AddressType.Perifereia Then
            Service = AddressController.Perifereia
            Console.WriteLine("---------- Register Perifereia ----------")
            Console.WriteLine("Δώσε Ονομα Perifereia: ")
        ElseIf AddressType = AddressType.Nomos Then
            Service = AddressController.Nomos
            Console.WriteLine("---------- Register Nomos ----------")
            Console.WriteLine("Δώσε Ονομα Nomos: ")
        ElseIf AddressType = AddressType.TK Then
            Service = AddressController.TK
            Console.WriteLine("---------- Register TK ----------")
            Console.WriteLine("Δώσε Ονομα TK: ")
        ElseIf AddressType = AddressType.Dhmos Then
            Service = AddressController.Dhmos
            Console.WriteLine("---------- Register Dhmos ----------")
            Console.WriteLine("Δώσε Ονομα Dhmos: ")
        ElseIf AddressType = AddressType.Address Then
            Service = AddressController.Address
            Console.WriteLine("---------- Register Address ----------")
            Console.WriteLine("Δώσε Ονομα Address: ")
        ElseIf AddressType = AddressType.Number Then
            Service = AddressController.Number
            Console.WriteLine("---------- Register Number ----------")
            Console.WriteLine("Δώσε Ονομα Number: ")
        End If

        Dim RegisterDTO As AdressesProject.Adresses.Contracts.IUpdateAndRegisterDTO = New AdressesProject.Adresses.Contracts.Contracts
        RegisterDTO.Value = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις στην εγραφή?") Then
            Console.WriteLine(Service.Register(RegisterDTO).Msg)
        End If

    End Sub
    Sub Update(Ref As AdressesProject.My.Ables.IReference, AddressType As AddressType)
        Dim Service As AdressesProject.Service = Nothing
        Console.Clear()

        If AddressType = AddressType.County Then
            Service = AddressController.Country
            Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
            Console.WriteLine("---------- Update Country ----------")
            Console.WriteLine("Παλιο Ονομα Country: " & Model.Value)
            Console.WriteLine("Δώσε Ονομα Country: ")
        ElseIf AddressType = AddressType.Perifereia Then
            Service = AddressController.Perifereia
            Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
            Console.WriteLine("---------- Update Perifereia ----------")
            Console.WriteLine("Παλιο Ονομα Perifereia: " & Model.Value)
            Console.WriteLine("Δώσε Ονομα Perifereia: ")
        ElseIf AddressType = AddressType.Nomos Then
            Service = AddressController.Nomos
            Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
            Console.WriteLine("---------- Update Nomos ----------")
            Console.WriteLine("Παλιο Ονομα Nomos: " & Model.Value)
            Console.WriteLine("Δώσε Ονομα Nomos: ")
        ElseIf AddressType = AddressType.TK Then
            Service = AddressController.TK
            Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
            Console.WriteLine("---------- Update TK ----------")
            Console.WriteLine("Παλιο Ονομα TK: " & Model.Value)
            Console.WriteLine("Δώσε Ονομα TK: ")
        ElseIf AddressType = AddressType.Dhmos Then
            Service = AddressController.Dhmos
            Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
            Console.WriteLine("---------- Update Dhmos ----------")
            Console.WriteLine("Παλιο Ονομα Dhmos: " & Model.Value)
            Console.WriteLine("Δώσε Ονομα Dhmos: ")
        ElseIf AddressType = AddressType.Address Then
            Service = AddressController.Address
            Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
            Console.WriteLine("---------- Update Address ----------")
            Console.WriteLine("Παλιο Ονομα Address: " & Model.Value)
            Console.WriteLine("Δώσε Ονομα Address: ")
        ElseIf AddressType = AddressType.Number Then
            Service = AddressController.Number
            Dim Model As AdressesProject.Adresses.Contracts.IModel = Service.Exist(Ref).Model
            Console.WriteLine("---------- Update Number ----------")
            Console.WriteLine("Παλιο Ονομα Number: " & Model.Value)
            Console.WriteLine("Δώσε Ονομα Number: ")
        End If

        Dim RegisterDTO As AdressesProject.Adresses.Contracts.IUpdateAndRegisterDTO = New AdressesProject.Adresses.Contracts.Contracts
        RegisterDTO.Value = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις στην εγραφή?") Then
            Console.WriteLine(Service.Change(Ref, RegisterDTO).Msg)
        End If
    End Sub
    Sub ListOf(AddressType As AddressType, Optional Choicer As Boolean = False, Optional ByRef AddressRef As AdressesProject.My.Ables.IReference = Nothing)
        While AddressType = AddressType.County
            Console.Clear()
            Console.WriteLine("--------- List of Country ----------")
            Dim val As MyBook.ValMsg(Of List(Of AdressesProject.Adresses.Contracts.Contracts)) = AddressController.Country.Get_All
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.WriteLine("-------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AddressType.County)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & val.Model(i).Value)
                Next

                Console.WriteLine()
                Console.WriteLine("------- Menu -------")
                Console.WriteLine(1 & " - " & val.Model.Count & ") Open Country.")
                Console.WriteLine(val.Model.Count + 1 & ") Register Country.")
                Console.WriteLine(val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To val.Model.Count - 1
                        If Choicer = True Then
                            AddressRef = val.Model(Choice)
                            Exit Sub
                        End If
                        Open(val.Model(Choice), AddressType.County)
                    Case val.Model.Count
                        Register(AddressType.County)
                    Case val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            End If
        End While

        While AddressType = AddressType.Perifereia
            Console.Clear()
            Console.WriteLine("--------- List of Perifereia----------")
            Dim val As MyBook.ValMsg(Of List(Of AdressesProject.Adresses.Contracts.Contracts)) = AddressController.Perifereia.Get_All
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.WriteLine("-------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AddressType.Perifereia)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & val.Model(i).Value)
                Next

                Console.WriteLine()
                Console.WriteLine("------- Menu -------")
                Console.WriteLine(1 & " - " & val.Model.Count & ") Open Perifereia.")
                Console.WriteLine(val.Model.Count + 1 & ") Register Perifereia.")
                Console.WriteLine(val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To val.Model.Count - 1
                        If Choicer = True Then
                            AddressRef = val.Model(Choice)
                            Exit Sub
                        End If
                        Open(val.Model(Choice), AddressType.Perifereia)
                    Case val.Model.Count
                        Register(AddressType.Perifereia)
                    Case val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            End If
        End While

        While AddressType = AddressType.Nomos
            Console.Clear()
            Console.WriteLine("--------- List of Nomos ----------")
            Dim val As MyBook.ValMsg(Of List(Of AdressesProject.Adresses.Contracts.Contracts)) = AddressController.Nomos.Get_All
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.WriteLine("-------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AddressType.Nomos)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & val.Model(i).Value)
                Next

                Console.WriteLine()
                Console.WriteLine("------- Menu -------")
                Console.WriteLine(1 & " - " & val.Model.Count & ") Open Nomos.")
                Console.WriteLine(val.Model.Count + 1 & ") Register Nomos.")
                Console.WriteLine(val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To val.Model.Count - 1
                        If Choicer = True Then
                            AddressRef = val.Model(Choice)
                            Exit Sub
                        End If
                        Open(val.Model(Choice), AddressType.Nomos)
                    Case val.Model.Count
                        Register(AddressType.Nomos)
                    Case val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            End If
        End While

        While AddressType = AddressType.TK
            Console.Clear()
            Console.WriteLine("--------- List of TK ----------")
            Dim val As MyBook.ValMsg(Of List(Of AdressesProject.Adresses.Contracts.Contracts)) = AddressController.TK.Get_All
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.WriteLine("-------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AddressType.TK)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & val.Model(i).Value)
                Next

                Console.WriteLine()
                Console.WriteLine("------- Menu -------")
                Console.WriteLine(1 & " - " & val.Model.Count & ") Open TK.")
                Console.WriteLine(val.Model.Count + 1 & ") Register TK.")
                Console.WriteLine(val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To val.Model.Count - 1
                        If Choicer = True Then
                            AddressRef = val.Model(Choice)
                            Exit Sub
                        End If
                        Open(val.Model(Choice), AddressType.TK)
                    Case val.Model.Count
                        Register(AddressType.TK)
                    Case val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            End If
        End While

        While AddressType = AddressType.Dhmos
            Console.Clear()
            Console.WriteLine("--------- List of Dhmos ----------")
            Dim val As MyBook.ValMsg(Of List(Of AdressesProject.Adresses.Contracts.Contracts)) = AddressController.Dhmos.Get_All
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.WriteLine("-------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AddressType.Dhmos)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & val.Model(i).Value)
                Next

                Console.WriteLine()
                Console.WriteLine("------- Menu -------")
                Console.WriteLine(1 & " - " & val.Model.Count & ") Open Dhmos.")
                Console.WriteLine(val.Model.Count + 1 & ") Register Dhmos.")
                Console.WriteLine(val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To val.Model.Count - 1
                        If Choicer = True Then
                            AddressRef = val.Model(Choice)
                            Exit Sub
                        End If
                        Open(val.Model(Choice), AddressType.Dhmos)
                    Case val.Model.Count
                        Register(AddressType.Dhmos)
                    Case val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            End If
        End While

        While AddressType = AddressType.Address
            Console.Clear()
            Console.WriteLine("--------- List of Address ----------")
            Dim val As MyBook.ValMsg(Of List(Of AdressesProject.Adresses.Contracts.Contracts)) = AddressController.Address.Get_All
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.WriteLine("-------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AddressType.Address)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & val.Model(i).Value)
                Next

                Console.WriteLine()
                Console.WriteLine("------- Menu -------")
                Console.WriteLine(1 & " - " & val.Model.Count & ") Open Address.")
                Console.WriteLine(val.Model.Count + 1 & ") Register Address.")
                Console.WriteLine(val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To val.Model.Count - 1
                        If Choicer = True Then
                            AddressRef = val.Model(Choice)
                            Exit Sub
                        End If
                        Open(val.Model(Choice), AddressType.Address)
                    Case val.Model.Count
                        Register(AddressType.Address)
                    Case val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            End If
        End While

        While AddressType = AddressType.Number
            Console.Clear()
            Console.WriteLine("--------- List of Number ----------")
            Dim val As MyBook.ValMsg(Of List(Of AdressesProject.Adresses.Contracts.Contracts)) = AddressController.Number.Get_All
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.WriteLine("-------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(AddressType.Number)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To val.Model.Count - 1
                    Console.WriteLine(i + 1 & ") " & val.Model(i).Value)
                Next

                Console.WriteLine()
                Console.WriteLine("------- Menu -------")
                Console.WriteLine(1 & " - " & val.Model.Count & ") Open Number.")
                Console.WriteLine(val.Model.Count + 1 & ") Register Number.")
                Console.WriteLine(val.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To val.Model.Count - 1
                        If Choicer = True Then
                            AddressRef = val.Model(Choice)
                            Exit Sub
                        End If
                        Open(val.Model(Choice), AddressType.Number)
                    Case val.Model.Count
                        Register(AddressType.Number)
                    Case val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            End If


        End While
    End Sub
    Sub Remove(Ref As AdressesProject.My.Ables.IReference, AddressType As AddressType)
        Dim Service As AdressesProject.Service = Nothing

        If AddressType = AddressType.County Then
            Service = AddressController.Country
            Console.WriteLine("------- Remove Country --------")
        End If
        If AddressType = AddressType.Perifereia Then
            Service = AddressController.Perifereia
            Console.WriteLine("------- Remove Perifereia --------")
        End If
        If AddressType = AddressType.Nomos Then
            Service = AddressController.Nomos
            Console.WriteLine("------- Remove Nomos --------")
        End If
        If AddressType = AddressType.TK Then
            Service = AddressController.TK
            Console.WriteLine("------- Remove TK --------")
        End If
        If AddressType = AddressType.Dhmos Then
            Service = AddressController.Dhmos
            Console.WriteLine("------- Remove Dhmos --------")
        End If
        If AddressType = AddressType.Address Then
            Service = AddressController.Address
            Console.WriteLine("------- Remove Address --------")
        End If
        If AddressType = AddressType.Number Then
            Service = AddressController.Number
            Console.WriteLine("------- Remove Number --------")
        End If

        If Help.AccessChoice("Θέλεις να συνεχησεις στην Διαγραφή?") Then
            Console.WriteLine(Service.Remove(Ref).Msg)
        End If

    End Sub
End Module
