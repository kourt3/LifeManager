Imports Economy.Controller

Module FullAddressModule
    Sub SimpleInfo(Ref As AdressesProject.My.Ables.IReference)
        Dim Model As AdressesProject.FullAdress.Contracts.IModel = AddressController.FullAddress.Exist(Ref).Model
        Console.Write(Model.Country.Value)
        Console.Write("," & Model.Perifereia.Value)
        Console.Write("," & Model.Nomos.Value)
        Console.Write("," & Model.TK.Value)
        Console.Write("," & Model.Dhmos.Value)
        Console.Write("," & Model.Addresses.Value)
        Console.Write("," & Model.Number.Value)
    End Sub
    Sub Info(Model As AdressesProject.FullAdress.Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Country: " & Model.Country.Value)
        Console.WriteLine("Perifereia: " & Model.Perifereia.Value)
        Console.WriteLine("Nomoi: " & Model.Nomos.Value)
        Console.WriteLine("TK: " & Model.TK.Value)
        Console.WriteLine("Dhmos: " & Model.Dhmos.Value)
        Console.WriteLine("Address: " & Model.Addresses.Value)
        Console.WriteLine("Number: " & Model.Number.Value)
    End Sub
    Sub ListOf(Optional Choice As Boolean = False, Optional ByRef ChoiceRef As AdressesProject.My.Ables.IReference = Nothing)
        Do
            Console.Clear()
            If Choice = False Then
                Console.WriteLine("----------- List Of FullAddress -----------")
            Else
                Console.WriteLine("----------- Choice Address -------------")
            End If
            Dim Val As MyBook.ValMsg(Of List(Of AdressesProject.FullAdress.Contracts.Model)) = AddressController.FullAddress.Get_All
            If Val.Success = False Then
                Console.WriteLine("---------- Menu ---------")
                Console.WriteLine("1) Register Address")
                Console.WriteLine("2) Exit.")
                Dim Str As String = Console.ReadLine
                Select Case Str
                    Case 1
                        Register()
                    Case 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select

            Else
                For i = 0 To Val.Model.Count - 1
                    Console.Write(i + 1 & ") ")
                    SimpleInfo(Val.Model(i))
                    Console.WriteLine()
                Next
                Console.WriteLine("--------- Menu ----------")
                Console.WriteLine(1 & " - " & Val.Model.Count & ") Open Address.")
                Console.WriteLine(Val.Model.Count + 1 & ") Register Address.")
                Console.WriteLine(Val.Model.Count + 2 & ") Exit.")
                Dim ChoiceStr As String = Console.ReadLine - 1
                Select Case ChoiceStr
                    Case 0 To Val.Model.Count - 1
                        If Choice = True Then
                            ChoiceRef = Val.Model(ChoiceStr)
                            Exit Sub
                        End If
                        Open(Val.Model(ChoiceStr))
                    Case Val.Model.Count
                        Register()
                    Case Val.Model.Count + 1
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End If

        Loop
    End Sub
    Sub Open(Ref As AdressesProject.My.Ables.IReference)
        Do
            Dim Val As MyBook.ValMsg(Of AdressesProject.FullAdress.Contracts.Model) = AddressController.FullAddress.Exist(Ref)
            If Val.Success = False Then Exit Sub
            Console.Clear()
            Console.WriteLine("----------- Address -----------")
            Info(Val.Model)
            Console.WriteLine()
            Console.WriteLine("----------- Menu -----------")
            Console.WriteLine("1) Remove Address.")
            Console.WriteLine("2) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Remove(Ref)
                Case 2
                    Exit Sub
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Sub Register()
        Dim RegisterDTO As AdressesProject.FullAdress.Contracts.IRegisterDTO = New AdressesProject.FullAdress.Contracts.Contracts

        Console.Clear()
        Console.WriteLine("----------- Register Address ----------")
        Dim CountryRef, PerifereiaRef, NomoiRef, TKRef, DhmoiRef, AddressRef, NumberRef As AdressesProject.My.Ables.IReference
        CountryRef = New AdressesProject.Adresses.Contracts.Contracts
        PerifereiaRef = New AdressesProject.Adresses.Contracts.Contracts
        NomoiRef = New AdressesProject.Adresses.Contracts.Contracts
        TKRef = New AdressesProject.Adresses.Contracts.Contracts
        DhmoiRef = New AdressesProject.Adresses.Contracts.Contracts
        AddressRef = New AdressesProject.Adresses.Contracts.Contracts
        NumberRef = New AdressesProject.Adresses.Contracts.Contracts


        AddressesModule.ListOf(AddressType.County, True, CountryRef)
        Console.Clear()
        AddressRelationShipModule.ListOfRelationShipAdress(CountryRef, AddressRelationShipType.CountryToPerifereies, PerifereiaRef)
        If CountryRef.PrimaryKey = Nothing OrElse CountryRef.PrimaryKey = Nothing Then Exit Sub
        Console.Clear()
        AddressRelationShipModule.ListOfRelationShipAdress(PerifereiaRef, AddressRelationShipType.PerifereiesToNomoi, NomoiRef)
        If PerifereiaRef.PrimaryKey = Nothing OrElse NomoiRef.PrimaryKey = Nothing Then Exit Sub
        Console.Clear()
        AddressRelationShipModule.ListOfRelationShipAdress(NomoiRef, AddressRelationShipType.NomosToTK, TKRef)
        If NomoiRef.PrimaryKey = Nothing OrElse TKRef.PrimaryKey = Nothing Then Exit Sub
        Console.Clear()
        AddressRelationShipModule.ListOfRelationShipAdress(TKRef, AddressRelationShipType.TKToDhmos, DhmoiRef)
        If TKRef.PrimaryKey = Nothing OrElse DhmoiRef.PrimaryKey = Nothing Then Exit Sub
        Console.Clear()
        AddressRelationShipModule.ListOfRelationShipAdress(DhmoiRef, AddressRelationShipType.DhmosToAddress, AddressRef)
        If DhmoiRef.PrimaryKey = Nothing OrElse AddressRef.PrimaryKey = Nothing Then Exit Sub
        Console.Clear()
        AddressRelationShipModule.ListOfRelationShipAdress(AddressRef, AddressRelationShipType.AddressToNumber, NumberRef)
        If AddressRef.PrimaryKey = Nothing OrElse NumberRef.PrimaryKey = Nothing Then Exit Sub
        Console.Clear()


        Console.WriteLine("------------ Info Address -----------")
        Console.WriteLine("Country: " & AddressController.Country.Exist(CountryRef).Model.Value)
        Console.WriteLine("Perifereia: " & AddressController.Perifereia.Exist(PerifereiaRef).Model.Value)
        Console.WriteLine("Nomoi: " & AddressController.Nomos.Exist(NomoiRef).Model.Value)
        Console.WriteLine("TK: " & AddressController.TK.Exist(TKRef).Model.Value)
        Console.WriteLine("Dhmos: " & AddressController.Dhmos.Exist(DhmoiRef).Model.Value)
        Console.WriteLine("Address: " & AddressController.Address.Exist(AddressRef).Model.Value)
        Console.WriteLine("Number: " & AddressController.Number.Exist(NumberRef).Model.Value)


        With RegisterDTO
            .Country = CountryRef.PrimaryKey
            .Perifereia = PerifereiaRef.PrimaryKey
            .Nomos = NomoiRef.PrimaryKey
            .TK = TKRef.PrimaryKey
            .Dhmos = DhmoiRef.PrimaryKey
            .Addresses = AddressRef.PrimaryKey
            .Number = NumberRef.PrimaryKey
        End With

        If Help.AccessChoice("Θέλεις να συνεχισεις στην εγραφή ?") Then
            Console.WriteLine(AddressController.FullAddress.Register(RegisterDTO).Msg)
        End If
    End Sub
    Sub Remove(Ref As AdressesProject.My.Ables.IReference)
        Dim Val As MyBook.ValMsg(Of AdressesProject.FullAdress.Contracts.Model) = AddressController.FullAddress.Exist(Ref)
        If Val.Success = False Then Exit Sub
        Console.Clear()
        Console.WriteLine("---------- Remove Address ---------")
        Info(Val.Model)
        If Help.AccessChoice("Θέλεις να συνεχήσεις?") Then
            Console.WriteLine(AddressController.FullAddress.Remove(Ref).Msg)
        End If
    End Sub
End Module
