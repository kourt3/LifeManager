Imports AccountComponent
Module ProfileModule

    Public Sub Menu(Ref As AccountComponent.Contracts.IReference, Optional ThirdRef As Contracts.IReference = Nothing)
        While ThirdRef Is Nothing
            Console.Clear()
            Dim ValModel As MyBook.ValMsg(Of Contracts.Contracts) = AccountService.Exist(Ref)
            If ValModel.Success = False Then
                Console.WriteLine(ValModel.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Dim Model As Contracts.IModel = ValModel.Model
            Console.WriteLine("--------- Profile --------")
            Console.WriteLine("Profile ID: " & Model.PrimaryKey)
            PersonModule.Info(Model.PersonModel)
            Console.WriteLine("---------- Menu ---------")
            Console.WriteLine("1) Economy.")
            Console.WriteLine("2) Διαχήρηση Προφιλ.")
            Console.WriteLine("3) Διαμερίσματα.")
            Console.WriteLine("4) Friends/Relationships")
            Console.WriteLine("5) Contacts")
            Console.WriteLine("6) Family.")
            Console.WriteLine("7) Exit.")
            Console.WriteLine("------------------")
            Console.WriteLine()
            Console.WriteLine("Επέλεξε ενα απο τα Menu:")
            Dim Str As String = Console.ReadLine

            Select Case Str
                Case 1
                    EconomyModule.Menu(Ref)
                Case 2
                    PersonModule.Menu(Model.PersonModel)
                Case 3
                    CohrabitionModule.ListOfApartment(Model)
                Case 4
                    RelationShipModule.ListOfFriend(Ref)
                Case 5
                    ContactModule.Menu(Ref)
                Case 6
                    FamilyModule.Menu(Ref, Model.FamilyModel)
                Case 7
                    Exit While
                Case Else
                    Continue While
            End Select
        End While

        Do While ThirdRef IsNot Nothing
            While RelationShip.Search(New RelationShipComponent.Contracts.Contracts With {.ExternalID = Ref.PrimaryKey, .ToExternalID = ThirdRef.PrimaryKey}).Success = False
                Console.Clear()
                Dim ValModel As MyBook.ValMsg(Of Contracts.Contracts) = AccountService.Exist(ThirdRef)
                If ValModel.Success = False Then
                    Console.WriteLine(ValModel.Msg)
                    Console.ReadLine()
                    Exit Sub
                End If
                Dim Model As Contracts.IModel = ValModel.Model
                Console.WriteLine("--------- Profile --------")
                Console.WriteLine("Profile ID: " & Model.PrimaryKey)
                PersonModule.Info(Model.PersonModel)
                Console.WriteLine("---------- Menu ---------")
                Console.WriteLine("1) Economy.")
                Console.WriteLine("2) Διαχήρηση Προφιλ.")
                Console.WriteLine("3) Διαμερίσματα.")
                Console.WriteLine("4) Friends/Relationships")
                Console.WriteLine("5) Family.")
                Console.WriteLine("6) Add Friend.")
                Console.WriteLine("7) Exit.")
                Console.WriteLine("------------------")
                Console.WriteLine()
                Console.WriteLine("Επέλεξε ενα απο τα Menu:")
                Dim Str As String = Console.ReadLine

                Select Case Str
                    Case 1
                        EconomyModule.Menu(Ref)
                    Case 2
                        PersonModule.Menu(Model.PersonModel)
                    Case 3
                        CohrabitionModule.ListOfApartment(Model)
                    Case 4
                        RelationShipModule.ListOfFriend(ThirdRef)
                    Case 5
                        FamilyModule.Menu(Ref, Model.FamilyModel)
                    Case 6
                        RelationShipModule.Register(Ref, ThirdRef)
                        Continue Do
                    Case 7
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While

            While RelationShip.Search(New RelationShipComponent.Contracts.Contracts With {.ExternalID = Ref.PrimaryKey, .ToExternalID = ThirdRef.PrimaryKey}).Success = True
                Console.Clear()
                Dim ValModel As MyBook.ValMsg(Of Contracts.Contracts) = AccountService.Exist(ThirdRef)
                If ValModel.Success = False Then
                    Console.WriteLine(ValModel.Msg)
                    Console.ReadLine()
                    Exit Sub
                End If
                Dim Model As Contracts.IModel = ValModel.Model
                Console.WriteLine("--------- Profile --------")
                Console.WriteLine("Profile ID: " & Model.PrimaryKey)
                PersonModule.Info(Model.PersonModel)
                Console.WriteLine("---------- Menu ---------")
                Console.WriteLine("1) Economy.")
                Console.WriteLine("2) Διαχήρηση Προφιλ.")
                Console.WriteLine("3) Διαμερίσματα.")
                Console.WriteLine("4) Friends/Relationships")
                Console.WriteLine("5) Family.")
                Console.WriteLine("6) Remove Friend.")
                Console.WriteLine("7) Exit.")
                Console.WriteLine("------------------")
                Console.WriteLine()
                Console.WriteLine("Επέλεξε ενα απο τα Menu:")
                Dim Str As String = Console.ReadLine

                Select Case Str
                    Case 1
                        EconomyModule.Menu(Ref)
                    Case 2
                        PersonModule.Menu(Model.PersonModel)
                    Case 3
                        CohrabitionModule.ListOfApartment(Model)
                    Case 4
                        RelationShipModule.ListOfFriend(ThirdRef)
                        Continue Do
                    Case 5
                        FamilyModule.Menu(Ref, Model.FamilyModel)
                    Case 6
                        Dim Creteria As RelationShipComponent.Contracts.ICreteria = New RelationShipComponent.Contracts.Contracts
                        With Creteria
                            .ExternalID = Ref.PrimaryKey
                            .ToExternalID = ThirdRef.PrimaryKey
                        End With
                        Dim Resultsearch As MyBook.ValMsg(Of List(Of RelationShipComponent.Contracts.IModel)) = RelationShip.Search(Creteria)
                        RelationShipModule.Remove(Resultsearch.Model(0))
                        Continue Do
                    Case 7
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While
        Loop

    End Sub
    Public Sub ListOfProfiles(ByVal MyRef As Contracts.IReference, Optional Choicer As Boolean = False, Optional ByRef ChoiceRef As Contracts.IReference = Nothing)
        Do
            Dim Val As MyBook.ValMsg(Of List(Of Contracts.Contracts)) = AccountService.Get_All()
            Console.Clear()
            Console.WriteLine("------------ List Of Profiles ----------")
            While Val.Model.Count <= 1
                Console.WriteLine(Val.Msg)
                Console.WriteLine("----------- Menu --------------")
                Console.WriteLine("1) Add Profile")
                Console.WriteLine("2) Exit.")
                Console.WriteLine("-------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Μενου:")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register()
                        Continue Do
                    Case 2
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            End While
            While Val.Model.Count > 1
                Dim Index As Integer = 0
                For Each Model In Val.Model
                    If MyRef IsNot Nothing AndAlso MyRef.PrimaryKey = Model.PrimaryKey Then
                        Continue For
                    End If

                    Index += 1
                    Console.WriteLine(Index & ") " & Model.PersonModel.FullName)
                Next

                Console.WriteLine("------------- Menu -------------")
                If Choicer = True Then
                    Console.WriteLine(1 & " -" & Index & ") Choice Profile.")
                Else
                    Console.WriteLine(1 & " -" & Index & ") Open Profile.")
                End If

                Console.WriteLine(Index + 1 & ") Add Profile.")
                Console.WriteLine(Index + 2 & ") Exit.")
                Console.WriteLine("------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Μενου.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1 To Index
                        If Choicer = True Then
                            ChoiceRef = Val.Model(Choice)
                            Exit Sub
                        End If
                        Menu(MyRef, Val.Model(Choice))
                        Continue Do
                    Case Index + 1
                        Register()
                        Continue Do
                    Case Index + 2
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            End While
        Loop

    End Sub
    Friend Sub Register()
        Dim RegisterDTO As Contracts.ILoginAndPersonRegisterDTO = New Contracts.Contracts
        Console.Clear()
        Console.WriteLine("---------- Register Profile -----------")
        PersonModule.Register(RegisterDTO.PersonDTO)
        Console.WriteLine(AccountService.RegisterWithoutLogin(RegisterDTO).Msg)
        Console.ReadLine()
    End Sub
End Module
