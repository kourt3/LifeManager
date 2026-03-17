
Imports CohrabitionComponent
Module CohrabitionModule

    Friend Sub ListOfCohrabition(ApartmentRef As Apartment.Contracts.IReference, MyRef As AccountComponent.Contracts.IReference, Optional ThridRef As Contracts.IReference = Nothing, Optional Choice As Boolean = False, Optional ByRef ChoiceRefPerson As AccountComponent.Contracts.IReference = Nothing)
        Do
            Console.Clear()
            Console.WriteLine("-------------- List Of Cograbition --------------------")
            Dim Val As MyBook.ValMsg(Of List(Of Contracts.IModel)) = ProfileAndApartments.Search(New Contracts.Contracts With {.ApartmentID = ApartmentRef.PrimaryKey})

            While Val.Success = False
                Console.WriteLine(Val.Msg)
                Console.WriteLine("---------------------------------------------------")
                Console.WriteLine()
                Console.WriteLine("--------- Menu ------")
                Console.WriteLine("1) Add Cohrabition")
                Console.WriteLine("2) Exit.")
                Console.WriteLine("--------------------------------")
                Console.WriteLine("Επέλεξε Μενου:")
                Dim Str As String = Console.ReadLine
                Select Case Str
                    Case 1
                        RegisterCohrabition(ApartmentRef, MyRef)
                        Continue Do
                    Case 2
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While

            While Val.Success = True
                Dim Index As Integer = 0
                For Each Model In Val.Model
                    Index += 1
                    Dim Person As PersonProject.Contracts.IModel = AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model.PersonModel
                    Console.WriteLine(Index & ") " & Person.FullName)
                Next
                Console.WriteLine("------------ Menu --------------")
                Console.WriteLine(1 & "-" & Index & ") Open Person.")
                Console.WriteLine(Index + 1 & ") Add Cohrabition.")
                Console.WriteLine(Index + 2 & ") Remove Cohrabition.")
                Console.WriteLine(Index + 3 & ") Exit.")
                Console.WriteLine("--------------------------------")
                Console.WriteLine("Επέλεξε Μενου:")
                Dim Str As String = Console.ReadLine - 1
                Select Case Str
                    Case 0 To Index - 1
                        If Choice = True Then
                            ChoiceRefPerson = AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = Val.Model(Int(Str)).ExternalID}).Model
                            Exit Do
                        End If
                        ProfileModule.Menu(AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = Val.Model(Int(Str)).ExternalID}).Model)
                        Continue Do
                    Case Index
                        RegisterCohrabition(ApartmentRef, MyRef, ThridRef)
                        Continue Do
                    Case Index + 1
                        RemoveCohrabition(ApartmentRef)
                        Continue Do
                    Case Index + 2
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While

        Loop
    End Sub
    Friend Enum Choice As Integer
        None
        AddMe
        AddMyFriend
        AddThird
        AddThirdFriend
        Search
    End Enum
    Friend Sub RegisterCohrabition(ApartmentRef As Apartment.Contracts.IReference, Optional MyRef As AccountComponent.Contracts.IReference = Nothing, Optional ThirdRef As AccountComponent.Contracts.IReference = Nothing)
        Console.Clear()
        Dim Opt As New List(Of String)
        Dim Action As New List(Of Action)
        Dim Choicer As New Choice
        Dim Val As MyBook.ValMsg(Of List(Of CohrabitionComponent.Contracts.IModel)) = ProfileAndApartments.Search(New Contracts.Contracts With {.ApartmentID = ApartmentRef.PrimaryKey})
        Console.WriteLine("---------- Add Cohrabition -----------")
        If MyRef IsNot Nothing Then

            Dim ExistRef As Boolean = False
            For Each model In Val.Model
                If model.ExternalID = MyRef.PrimaryKey Then
                    ExistRef = True
                    Exit For
                End If
            Next
            If ExistRef = False Then
                Help.AddOption(Opt, Action, "Προσθήκη τον εαυτο μου.", Sub() Choicer = Choice.AddMe)
            End If
            Help.AddOption(Opt, Action, "Προσθήκη απο τους φίλους μου.", Sub() Choicer = Choice.AddMyFriend)
        End If


        If ThirdRef IsNot Nothing Then
            Dim ExistRef As Boolean = False
            For Each model In Val.Model
                If model.ExternalID = ThirdRef.PrimaryKey Then
                    ExistRef = True
                    Exit For
                End If
            Next
            If ExistRef = True Then
                Help.AddOption(Opt, Action, "Προσθήκη Τρίτου.", Sub() Choicer = Choice.AddThird)
            End If
            Help.AddOption(Opt, Action, "Προσθήκη Τρίτου Φίλου.", Sub() Choicer = Choice.AddThirdFriend)
        End If

        Help.AddOption(Opt, Action, "Αναζήτηση απο το συστημα", Sub() Choicer = Choice.Search)
        Help.AddOption(Opt, Action, "Exit.", Sub() Choicer = Choice.None)
        Help.PrintMenu(Opt)
        Dim Str As String = Console.ReadLine - 1
        If Str = Nothing Then
            Exit Sub
        End If
        If Str >= 0 AndAlso Str <= Action.Count - 1 Then
            Action(Int(Str)).Invoke
        Else
            Exit Sub
        End If

        Dim DTO As Contracts.IRegisterDTO = New Contracts.Contracts
        Select Case Choicer
            Case Choice.AddMe
                DTO.ApartmentID = ApartmentRef.PrimaryKey
                DTO.ExternalID = MyRef.PrimaryKey
                DTO.BuildID = Apartnment.Exist(ApartmentRef).Model.BuildID
                Console.Clear()
                Console.WriteLine(ProfileAndApartments.Register(DTO).Msg)
                Console.ReadLine()
            Case Choice.AddMyFriend
                Dim Ref As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
                RelationShipModule.ListOfFriend(MyRef, True, Ref)
                If Not Ref.PrimaryKey = Nothing Then
                    DTO.ExternalID = Ref.PrimaryKey
                    DTO.ApartmentID = ApartmentRef.PrimaryKey
                    DTO.BuildID = Apartnment.Exist(ApartmentRef).Model.BuildID
                    Console.Clear()
                    Console.WriteLine(ProfileAndApartments.Register(DTO).Msg)
                    Console.ReadLine()
                End If

            Case Choice.AddThird
                DTO.ApartmentID = ApartmentRef.PrimaryKey
                DTO.ExternalID = ThirdRef.PrimaryKey
                DTO.BuildID = Apartnment.Exist(ApartmentRef).Model.BuildID
                Console.Clear()
                Console.WriteLine(ProfileAndApartments.Register(DTO).Msg)
                Console.ReadLine()
            Case Choice.AddThirdFriend
                Dim Ref As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
                RelationShipModule.ListOfFriend(ThirdRef, True, Ref)
                If Not Ref.PrimaryKey = Nothing Then
                    DTO.ExternalID = Ref.PrimaryKey
                    DTO.ApartmentID = ApartmentRef.PrimaryKey
                    DTO.BuildID = Apartnment.Exist(ApartmentRef).Model.BuildID
                    Console.Clear()
                    Console.WriteLine(ProfileAndApartments.Register(DTO).Msg)
                    Console.ReadLine()
                End If
            Case Choice.Search
                Dim Ref As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
                ProfileModule.ListOfProfiles(MyRef, True, Ref)
                If Not Ref.PrimaryKey = Nothing Then
                    DTO.ApartmentID = ApartmentRef.PrimaryKey
                    DTO.ExternalID = Ref.PrimaryKey
                    DTO.BuildID = Apartnment.Exist(ApartmentRef).Model.BuildID
                    Console.Clear()
                    Console.WriteLine(ProfileAndApartments.Register(DTO).Msg)
                    Console.ReadLine()
                End If
            Case Choice.None
                Exit Sub
            Case Else
                Exit Sub
        End Select

    End Sub
    Friend Sub ListOfApartment(Ref As AccountComponent.Contracts.IReference, Optional Choice As Boolean = Nothing, Optional ByRef ChoiceApartmentRef As Apartment.Contracts.IReference = Nothing)
        Do
            Console.Clear()
            Console.WriteLine("---------- List Of Apartment -------------")
            Dim Val As MyBook.ValMsg(Of List(Of Contracts.IModel)) = ProfileAndApartments.Search(New Contracts.Contracts With {.ExternalID = Ref.PrimaryKey})

            While Val.Success = False
                Console.WriteLine(Val.Msg)
                Console.WriteLine("----------------------------")
                Console.WriteLine()
                Console.WriteLine("--------- Menu -------")
                Console.WriteLine("1) Add Apartment.")
                Console.WriteLine("2) Exit.")
                Dim Str As String = Console.ReadLine
                Select Case Str
                    Case 1
                        Register(Ref)
                        Continue Do
                    Case 2
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While

            While Val.Success = True

                Dim index As Integer = 0
                For Each Model In Val.Model
                    index += 1
                    Console.WriteLine(index & ") " & Model.BuildModel.Addresess & " | " & Model.ApartmentModel.Koudouni)
                Next
                Console.WriteLine(index + 1 & ") Add Apartment.")
                Console.WriteLine(index + 2 & ") Exit.")

                Dim Str As String = Console.ReadLine - 1
                Select Case Str
                    Case 0 To index - 1
                        If Choice = True Then
                            ChoiceApartmentRef = Val.Model(Int(Str)).ApartmentModel
                            Exit Do
                        End If
                        ApartmentModule.Menu(Val.Model(Int(Str)).ApartmentModel, Ref)
                        Continue Do
                    Case index
                        Register(Ref)
                        Continue Do
                    Case index + 1
                        Exit Do
                    Case Else
                        Continue While
                End Select

            End While

        Loop
    End Sub
    Friend Sub Register(Ref As AccountComponent.Contracts.IReference)
        Console.WriteLine("---------- Add Apartment ---------")
        If Help.AccessChoice("Θέλει να κανεις εγραφή ?") Then
            Dim DTO As Contracts.IRegisterDTO = New Contracts.Contracts
            Dim BuildRef As Buildings.Contracts.IReference = New Buildings.Contracts.Contracts
            BuildingsModule.ListOfBuild(Ref, Nothing, True, BuildRef)
            DTO.BuildID = BuildRef.PrimaryKey
            Dim ApartMentRef As Apartment.Contracts.IReference = New Apartment.Contracts.Contracts
            ApartmentModule.ListOfApartment(BuildRef, Ref, Nothing, True, ApartMentRef)
            DTO.ApartmentID = ApartMentRef.PrimaryKey
            DTO.ExternalID = Ref.PrimaryKey
            Console.Clear()
            Console.WriteLine(ProfileAndApartments.Register(DTO).Msg)
            Console.ReadLine()
        End If
    End Sub

    Friend Sub RemoveCohrabition(ApartmentRef As Apartment.Contracts.IReference)
        Do


            Dim Creteria As Contracts.ICreteria = New Contracts.Contracts
            Creteria.ApartmentID = ApartmentRef.PrimaryKey
            Dim Val As MyBook.ValMsg(Of List(Of Contracts.IModel)) = ProfileAndApartments.Search(Creteria)
            Dim Index As Integer = 0

            Console.Clear()
            Console.WriteLine("---------- Remove Cohrabition -----------")
            For Each Model In Val.Model
                Index += 1
                Dim Account As AccountComponent.Contracts.IModel = AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = Model.ExternalID}).Model
                Console.WriteLine(Index & ") " & Account.PersonModel.FullName)
            Next
            Console.WriteLine()
            Console.WriteLine("------- Menu -------------")
            Console.WriteLine(0 & " - " & Index & ") Επιλογη Διαγραφής απο το διαμέρισμα. ")
            Console.WriteLine(Index + 1 & ") Exit.")
            Console.WriteLine("--------------------------")
            Console.WriteLine("Παρακαλώ επιλέξτε ενα απο το μενου: ")
            Dim Choice As Integer = Nothing
            If Not Help.Input(Choice) Then
                Continue Do
            End If
            Select Case Choice
                Case 1 To Index
                    Console.WriteLine(ProfileAndApartments.Remove(Val.Model(Choice - 1)).Msg)
                    Exit Do
                Case Index + 1
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
End Module
