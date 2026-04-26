Imports AccountComponent
Module ProfileModule

    Public Sub Menu(Ref As ProfileComponent.Profile.Able.IReference, Optional ThirdRef As ProfileComponent.Profile.Able.IReference = Nothing)
        While ThirdRef Is Nothing
            Console.Clear()
            Dim Profile As MyBook.ValMsg(Of ProfileComponent.Model) = ProfileController.ExistProfile(Ref)
            If Profile.Success = False Then
                Console.WriteLine(Profile.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Console.WriteLine("--------- Profile --------")
            Console.WriteLine("Profile ID: " & Profile.Model.Profile.PrimaryKey)
            PersonModule.Info(Profile.Model.PersonModel)
            Console.WriteLine("---------- Menu ---------")
            Console.WriteLine("1) Economy.")
            Console.WriteLine("2) Διαχήρηση Προφιλ.")
            Console.WriteLine("3) Διαμερίσματα.")
            Console.WriteLine("4) Δήλωσεις οχημάτον.")
            Console.WriteLine("5) Friends/Relationships")
            Console.WriteLine("6) Contacts")
            Console.WriteLine("7) Family.")
            Console.WriteLine("8) Exit.")
            Console.WriteLine("------------------")
            Console.WriteLine()
            Console.WriteLine("Επέλεξε ενα απο τα Menu:")
            Dim Str As String = Console.ReadLine

            Select Case Str
                Case 1
                    EconomyModule.Menu(Profile.Model.Profile)
                Case 2
                    PersonModule.Menu(Profile.Model.PersonModel)
                Case 3
                    CohrabitionModule.ListOfApartment(Profile.Model.Profile)
                Case 4
                    PlateModule.ListOfPlates(Profile.Model.Profile)
                Case 5
                    RelationShipModule.ListOfFriend(Profile.Model.Profile)
                Case 6
                    ContactModule.Menu(Profile.Model.Profile)
                Case 7
                    FamilyModule.Menu(Profile.Model.Profile, Profile.Model.Family.FamilyModel)
                Case 8
                    Exit While
                Case Else
                    Continue While
            End Select
        End While

        Do While ThirdRef IsNot Nothing
            While ProfileController.Contact.Search(New ProfileComponent.ContactsProject.Contracts.Contracts With {.ExternalID = Ref.PrimaryKey, .ToExternalID = ThirdRef.PrimaryKey}).Success = False
                Console.Clear()
                Dim ValModel As MyBook.ValMsg(Of ProfileComponent.Model) = ProfileController.ExistProfile(ThirdRef)
                If ValModel.Success = False Then
                    Console.WriteLine(ValModel.Msg)
                    Console.ReadLine()
                    Exit Sub
                End If
                Console.WriteLine("--------- Profile --------")
                Console.WriteLine("Profile ID: " & ValModel.Model.Profile.PrimaryKey)
                PersonModule.Info(ValModel.Model.PersonModel)
                Console.WriteLine("---------- Menu ---------")
                Console.WriteLine("1) Economy.")
                Console.WriteLine("2) Διαχήρηση Προφιλ.")
                Console.WriteLine("3) Διαμερίσματα.")
                Console.WriteLine("4) Δήλωσεις οχημάτον.")
                Console.WriteLine("5) Friends/Relationships")
                Console.WriteLine("6) Family.")
                Console.WriteLine("7) Add Friend.")
                Console.WriteLine("8) Exit.")
                Console.WriteLine("------------------")
                Console.WriteLine()
                Console.WriteLine("Επέλεξε ενα απο τα Menu:")
                Dim Str As String = Console.ReadLine

                Select Case Str
                    Case 1
                        EconomyModule.Menu(ThirdRef)
                    Case 2
                        PersonModule.Menu(ValModel.Model.PersonModel)
                    Case 3
                        CohrabitionModule.ListOfApartment(ValModel.Model)
                    Case 4
                        PlateModule.ListOfPlates(ThirdRef)
                    Case 5
                        RelationShipModule.ListOfFriend(ThirdRef)
                    Case 6
                        FamilyModule.Menu(Ref, ValModel.Model.Family.FamilyModel)
                    Case 7
                        RelationShipModule.Register(Ref, ThirdRef)
                        Continue Do
                    Case 8
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While

            While ProfileController.Contact.Search(New ProfileComponent.ContactsProject.Contracts.Contracts With {.ExternalID = Ref.PrimaryKey, .ToExternalID = ThirdRef.PrimaryKey}).Success = True
                Console.Clear()
                Dim ValModel As MyBook.ValMsg(Of ProfileComponent.Model) = ProfileController.ExistProfile(ThirdRef)
                If ValModel.Success = False Then
                    Console.WriteLine(ValModel.Msg)
                    Console.ReadLine()
                    Exit Sub
                End If
                Console.WriteLine("--------- Profile --------")
                Console.WriteLine("Profile ID: " & ValModel.Model.Profile.PrimaryKey)
                PersonModule.Info(ValModel.Model.PersonModel)
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
                        EconomyModule.Menu(ThirdRef)
                    Case 2
                        PersonModule.Menu(ValModel.Model.PersonModel)
                    Case 3
                        CohrabitionModule.ListOfApartment(ValModel.Model)
                    Case 4
                        RelationShipModule.ListOfFriend(ThirdRef)
                        Continue Do
                    Case 5
                        FamilyModule.Menu(Ref, ValModel.Model.Family.FamilyModel)
                    Case 6
                        Dim Creteria As ProfileComponent.ContactsProject.Contracts.ICreteria = New ProfileComponent.ContactsProject.Contracts.Contracts
                        With Creteria
                            .ExternalID = Ref.PrimaryKey
                            .ToExternalID = ThirdRef.PrimaryKey
                        End With
                        Dim Resultsearch As MyBook.ValMsg(Of List(Of ProfileComponent.ContactsProject.Contracts.IModel)) = ProfileController.Contact.Search(Creteria)
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
    Public Sub ListOfProfiles(ByVal MyRef As ProfileComponent.Profile.Able.IReference, Optional Choicer As Boolean = False, Optional ByRef ChoiceRef As ProfileComponent.Profile.Able.IReference = Nothing)
        Do
            Dim Val As MyBook.ValMsg(Of List(Of ProfileComponent.Model)) = ProfileController.ListOfProfiles(MyRef)
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
                            ChoiceRef = Val.Model(Choice - 1).Profile
                            Exit Sub
                        End If
                        Menu(MyRef, Val.Model(Choice - 1).Profile)
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
        Dim RegisterDTO As ProfileComponent.PersonProject.Contracts.IRegisterDTO = New ProfileComponent.PersonProject.Contracts.Contracts
        Console.Clear()
        Console.WriteLine("---------- Register Profile -----------")
        PersonModule.Register(RegisterDTO)
        Dim Val As MyBook.ValMsg(Of ProfileComponent.Model) = ProfileController.AddProfile(RegisterDTO)
        Console.WriteLine(Val.Msg)
        Console.ReadLine()
    End Sub
End Module
