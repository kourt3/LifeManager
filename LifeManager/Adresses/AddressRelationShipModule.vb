Imports Economy.Controller

Module AddressRelationShipModule
    Enum AddressRelationShipType
        CountryToPerifereies
        PerifereiesToNomoi
        NomosToTK
        TKToDhmos
        DhmosToAddress
        AddressToNumber
    End Enum
    Sub Menu()
        Do
            Console.Clear()
            Console.WriteLine("--------- Menu Addresss ---------")
            Console.WriteLine("1) Ανα Κατηγορια.")
            Console.WriteLine("2) Κυλιόμενες Διευθήνσης.")
            Console.WriteLine("3) Αποθηκευμένες Διευθηνσης.")
            Console.WriteLine("4) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    AddressesModule.Menu()
                Case 2
                    Dim Ref As AdressesProject.My.Ables.IReference = New AdressesProject.Adresses.Contracts.Contracts
                    AddressesModule.ListOf(AddressType.County, True, Ref)
                    ListOfRelationShipAdress(Ref, AddressRelationShipType.CountryToPerifereies)
                Case 3
                Case 4
                    Exit Sub
                Case Else
            End Select
        Loop
    End Sub
    Sub Open(Ref As MyBook.RelationShip.Contracts.IReference, RelType As AddressRelationShipType)
        Dim Service As AdressesProject.AddressRelationShip.Service.Service = Nothing
        Do
            Console.Clear()
            Dim Opt As String = Nothing
            Dim Actions As Action = Nothing
            If RelType = AddressRelationShipType.CountryToPerifereies Then
                Service = AddressController.CountryTOPeriferia
                Dim Model As MyBook.RelationShip.Contracts.IModel = Service.Exist(Ref).Model
                Dim CountryModel, PerifereiaModel As AdressesProject.Adresses.Contracts.IModel
                CountryModel = AddressController.Country.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model
                PerifereiaModel = AddressController.Perifereia.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model

                Console.WriteLine("----------- Perifereies Of Country ---------")
                Console.WriteLine("Country: " & CountryModel.Value)
                Console.WriteLine("Perifereia: " & PerifereiaModel.Value)

                Opt = "Continue RelationShip Nomoi Of Perifereia"
                Actions = Sub() ListOfRelationShipAdress(PerifereiaModel, AddressRelationShipType.PerifereiesToNomoi)

            ElseIf RelType = AddressRelationShipType.PerifereiesToNomoi Then
                Service = AddressController.PeriferiaTONomo
                Dim Model As MyBook.RelationShip.Contracts.IModel = Service.Exist(Ref).Model
                Dim PerifereiaModel, NomoiModel As AdressesProject.Adresses.Contracts.IModel
                PerifereiaModel = AddressController.Perifereia.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model
                NomoiModel = AddressController.Nomos.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model

                Console.WriteLine("----------- Nomoi Of Perifereies -----------")
                Console.WriteLine("Perifereia: " & PerifereiaModel.Value)
                Console.WriteLine("Nomos: " & NomoiModel.Value)

                Opt = "Continue RelationShip TK Of Nomos"
                Actions = Sub() ListOfRelationShipAdress(NomoiModel, AddressRelationShipType.NomosToTK)

            ElseIf RelType = AddressRelationShipType.NomosToTK Then
                Service = AddressController.NomosTOTK
                Dim Model As MyBook.RelationShip.Contracts.IModel = Service.Exist(Ref).Model
                Dim NomosModel, TKModel As AdressesProject.Adresses.Contracts.IModel
                NomosModel = AddressController.Nomos.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model
                TKModel = AddressController.TK.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model

                Console.WriteLine("---------- TK of Nomos -------------")
                Console.WriteLine("Nomos: " & NomosModel.Value)
                Console.WriteLine("TK: " & TKModel.Value)

                Opt = "Continue RelationShip Dhmoi Of TK"
                Actions = Sub() ListOfRelationShipAdress(TKModel, AddressRelationShipType.TKToDhmos)

            ElseIf RelType = AddressRelationShipType.TKToDhmos Then
                Service = AddressController.TKTODhmos
                Dim Model As MyBook.RelationShip.Contracts.IModel = Service.Exist(Ref).Model
                Dim TKModel, DhmosModel As AdressesProject.Adresses.Contracts.IModel
                TKModel = AddressController.TK.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model
                DhmosModel = AddressController.Dhmos.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model

                Console.WriteLine("------------ Dhmoi Of TK ------------")
                Console.WriteLine("TK: " & TKModel.Value)
                Console.WriteLine("Dhmos: " & DhmosModel.Value)

                Opt = "Continue RelationShip Addresses Of Dhmos"
                Actions = Sub() ListOfRelationShipAdress(DhmosModel, AddressRelationShipType.DhmosToAddress)

            ElseIf RelType = AddressRelationShipType.DhmosToAddress Then
                Service = AddressController.DhmosToAddress
                Dim Model As MyBook.RelationShip.Contracts.IModel = Service.Exist(Ref).Model
                Dim DhmosModel, AddressModel As AdressesProject.Adresses.Contracts.IModel
                DhmosModel = AddressController.Dhmos.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model
                AddressModel = AddressController.Address.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model

                Console.WriteLine("----------- Address Of  Dhmos -----------")
                Console.WriteLine("Dhmos: " & DhmosModel.Value)
                Console.WriteLine("Address: " & AddressModel.Value)

                Opt = "Continue RelationShip Number Of Address"
                Actions = Sub() ListOfRelationShipAdress(AddressModel, AddressRelationShipType.AddressToNumber)

            ElseIf RelType = AddressRelationShipType.AddressToNumber Then
                Service = AddressController.AddressToNumber
                Dim Model As MyBook.RelationShip.Contracts.IModel = Service.Exist(Ref).Model
                Dim AddresModel, NumberModel As AdressesProject.Adresses.Contracts.IModel
                AddresModel = AddressController.Address.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model
                NumberModel = AddressController.Number.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model

                Console.WriteLine("---------- Numbers Of Address -----------")
                Console.WriteLine("Address: " & AddresModel.Value)
                Console.WriteLine("Number: " & NumberModel.Value)
            End If

            Console.WriteLine("------------ Menu --------")
            Console.WriteLine(1 & ") " & Opt)
            Console.WriteLine("2) Update RelationShip.")
            Console.WriteLine("3) Remove RelationShip.")
            Console.WriteLine("4) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Actions.Invoke
                Case 2
                    Update(Ref, RelType)
                Case 3
                    Remove(Ref, RelType)
                Case 4
                    Exit Sub
                Case Else
                    Continue Do
            End Select

        Loop
    End Sub
    Sub ListOfRelationShipAdress(Ref As AdressesProject.My.Ables.IReference, RelType As AddressRelationShipType, Optional ByRef RelRef As MyBook.RelationShip.Contracts.IReference = Nothing)
        While RelType = AddressRelationShipType.CountryToPerifereies
            Dim ValCountry As MyBook.ValMsg(Of AdressesProject.Adresses.Contracts.Contracts) = AddressController.Country.Exist(Ref)
            If ValCountry.Success = False Then Exit Sub

            Console.Clear()
            Console.WriteLine("-------------- Το Country : " & ValCountry.Model.Value & "---------")
            Console.WriteLine("Έχει Περιφερειες:")

            Dim Creteria As MyBook.RelationShip.Contracts.ICreteriaExternal = New MyBook.RelationShip.Contracts.Contracts With {.ExternalID = Ref.PrimaryKey}
            Dim ValRelation As MyBook.ValMsg(Of List(Of MyBook.RelationShip.Contracts.Contracts)) = AddressController.CountryTOPeriferia.Search(Creteria)
            If ValRelation.Success = False Then
                Console.WriteLine(ValRelation.Msg)
                Console.WriteLine("------- Menu --------")
                Console.WriteLine("1) Register Perifereia From Country.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(Ref, AddressRelationShipType.CountryToPerifereies)
                    Case 2
                        Exit Sub
                    Case Else
                        Continue While
                End Select
            Else
                For i = 0 To ValRelation.Model.Count - 1
                    Dim Model As AdressesProject.Adresses.Contracts.IModel = AddressController.Perifereia.Exist(New AdressesProject.Adresses.Contracts.Contracts With {.PrimaryKey = ValRelation.Model(i).ToExternalID}).Model
                    Console.WriteLine(i + 1 & ") " & Model.Value)
                Next
                Console.WriteLine(1 & " - " & ValRelation.Model.Count & ")  Open Country And Perifereia Relationship.")
                Console.WriteLine(ValRelation.Model.Count + 1 & ") Register Perifereia From Country.")
                Console.WriteLine(ValRelation.Model.Count + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine - 1
                Select Case Choice
                    Case 0 To ValRelation.Model.Count - 1
                        Open(ValRelation.Model(Choice), AddressRelationShipType.CountryToPerifereies)
                    Case ValRelation.Model.Count + 1
                        Register(Ref, AddressRelationShipType.CountryToPerifereies)
                    Case ValRelation.Model.Count + 2
                    Case Else
                        Continue While
                End Select
            End If

        End While
    End Sub
    Sub Register(Ref As AdressesProject.My.Ables.IReference, RelType As AddressRelationShipType)
        Console.Clear()
        Dim RegisterDTO As MyBook.RelationShip.Contracts.IRegisterDTO = New MyBook.RelationShip.Contracts.Contracts
        Dim ToRef As AdressesProject.My.Ables.IReference = New AdressesProject.My.Entity.Entity

        If RelType = AddressRelationShipType.CountryToPerifereies Then
            Console.WriteLine("--------- Register Perifereia For Country:" & AddressController.Country.Exist(Ref).Model.Value & " -----------")
            AddressesModule.ListOf(AddressType.Perifereia, True, ToRef)
        ElseIf RelType = AddressRelationShipType.PerifereiesToNomoi Then
            Console.WriteLine("--------- Register Nomoi For Perifereies:" & AddressController.Perifereia.Exist(Ref).Model.Value & " -----------")
            AddressesModule.ListOf(AddressType.Nomos, True, ToRef)
        ElseIf RelType = AddressRelationShipType.NomosToTK Then
            Console.WriteLine("--------- Register TK For Nomos:" & AddressController.Nomos.Exist(Ref).Model.Value & " -----------")
            AddressesModule.ListOf(AddressType.TK, True, ToRef)
        ElseIf RelType = AddressRelationShipType.TKToDhmos Then
            Console.WriteLine("--------- Register Dhmos For TK:" & AddressController.TK.Exist(Ref).Model.Value & " -----------")
            AddressesModule.ListOf(AddressType.Dhmos, True, ToRef)
        ElseIf RelType = AddressRelationShipType.DhmosToAddress Then
            Console.WriteLine("--------- Register Address For Dhmos:" & AddressController.Dhmos.Exist(Ref).Model.Value & " -----------")
            AddressesModule.ListOf(AddressType.Address, True, ToRef)
        ElseIf RelType = AddressRelationShipType.AddressToNumber Then
            Console.WriteLine("--------- Register Number For Address:" & AddressController.Address.Exist(Ref).Model.Value & " -----------")
            AddressesModule.ListOf(AddressType.Number, True, ToRef)
        End If

        With RegisterDTO
            .ExternalID = Ref.PrimaryKey
            .ToExternalID = ToRef.PrimaryKey
        End With

        AddressController.CountryTOPeriferia.Register(RegisterDTO)
    End Sub
    Sub Remove(Ref As MyBook.RelationShip.Contracts.IReference, RelType As AddressRelationShipType)

    End Sub
End Module
