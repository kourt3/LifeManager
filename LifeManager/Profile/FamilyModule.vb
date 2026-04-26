Imports ProfileComponent
Module FamilyModule
    Friend Sub info(Model As FamilyProject.Model)
        Console.WriteLine("------ Mother --------")
        If Model.FamilyModel.Mother <> Nothing Then
            Console.WriteLine("FullName: " & ProfileController.ExistProfile(New Profile.Contracts.Contracts With {.PrimaryKey = Model.FamilyModel.Mother}).Model.PersonModel.FullName)
        Else
            Console.WriteLine("Δεν Έχει καταχωρηθη!")
        End If
        Console.WriteLine("------- Father --------")
        If Model.FamilyModel.Father <> Nothing Then
            Console.WriteLine("FullName: " & ProfileController.ExistProfile(New Profile.Contracts.Contracts With {.PrimaryKey = Model.FamilyModel.Father}).Model.PersonModel.FullName)
        Else
            Console.WriteLine("Δεν Έχει καταχωρηθη!")
        End If
        Console.WriteLine("-------- Wife/Husband -------")
        If Model.FamilyModel.Spouse <> Nothing Then
            Console.WriteLine("FullName: " & ProfileController.ExistProfile(New PersonProject.Contracts.Contracts With {.PrimaryKey = Model.FamilyModel.Spouse}).Model.PersonModel.FullName)
        Else
            Console.WriteLine("Δεν Έχει καταχωρηθη!")
        End If
        Console.WriteLine("------- Childrens -----------")
        Console.WriteLine("Childrens: " & Model.Childrends.Count)
    End Sub
    Enum ChoiceFamily
        Mother
        Father
        Husband
        Childrens
    End Enum
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Myref"></param>
    ''' <param name="FamilyRef"></param>
    ''' <param name="ChoiceRef">Μόνο Αν Θέλεις επιλογη</param>
    ''' <param name="AutoComplite">Μπορει να περναει αυτοματα της σχέσεις μεταξυ τους(Bydefault =  false)</param> ' Προτημότερο ειναι το false!
    Friend Sub Menu(Myref As ProfileComponent.Profile.Able.IReference, FamilyRef As FamilyProject.Family.Ables.IReference, Optional ByRef ChoiceRef As ProfileComponent.Profile.Able.IReference = Nothing, Optional AutoComplite As Boolean = False)
        Dim ContinueMenu As Boolean = True
        Do
            Dim ChoicerRef As ProfileComponent.Profile.Able.IReference = New ProfileComponent.Profile.Contracts.Contracts
            Dim Val As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Model) = ProfileController.Family.ExistFamily(FamilyRef)
            Dim Opt As New List(Of String)
            Dim Action As New List(Of Action)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.ReadLine()
                Continue Do
            End If

            Console.Clear()
            Console.WriteLine("-------- Family ---------")
            Console.WriteLine()
            info(Val.Model)
            Console.WriteLine()
            Console.WriteLine("----------- Menu ----------")

            If Val.Model.FamilyModel.Mother <> Nothing Then
                If ChoiceRef Is Nothing Then
                    Help.AddOption(Opt, Action, "Open Mother.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Mother,, AutoComplite))
                Else
                    Help.AddOption(Opt, Action, "Choice Mother.", Sub()
                                                                      Dim Creteria As ProfileComponent.Profile.Contracts.ICreteria = New ProfileComponent.Profile.Contracts.Contracts
                                                                      Creteria.PersonID = Val.Model.FamilyModel.Mother
                                                                      ChoicerRef = ProfileController.Profile.Search(Creteria).Model
                                                                  End Sub)
                End If
            Else
                Help.AddOption(Opt, Action, "Register Mother.", Sub() Register(Myref, FamilyRef, ChoiceFamily.Mother))
            End If

            If Val.Model.FamilyModel.Father <> Nothing Then
                If ChoiceRef Is Nothing Then
                    Help.AddOption(Opt, Action, "Open Father.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Father,, AutoComplite))
                Else
                    Help.AddOption(Opt, Action, "Choice Father.", Sub()
                                                                      Dim Creteria As ProfileComponent.Profile.Contracts.ICreteria = New ProfileComponent.Profile.Contracts.Contracts
                                                                      Creteria.PersonID = Val.Model.FamilyModel.Father
                                                                      ChoicerRef = ProfileController.Profile.Search(Creteria).Model
                                                                  End Sub)
                End If
            Else
                Help.AddOption(Opt, Action, "Register Father.", Sub() Register(Myref, FamilyRef, ChoiceFamily.Father, AutoComplite))
            End If

            If Val.Model.FamilyModel.Spouse <> Nothing Then
                If ChoiceRef Is Nothing Then
                    Help.AddOption(Opt, Action, "Open Wife/Husband.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Husband,, AutoComplite))
                Else
                    Help.AddOption(Opt, Action, "Choice Wife/Husband.", Sub()
                                                                            Dim Creteria As ProfileComponent.Profile.Contracts.ICreteria = New ProfileComponent.Profile.Contracts.Contracts
                                                                            Creteria.PersonID = Val.Model.FamilyModel.Spouse
                                                                            ChoicerRef = ProfileController.Profile.Search(Creteria).Model
                                                                        End Sub)
                End If
            Else
                Help.AddOption(Opt, Action, "Register Wife/Husband.", Sub() Register(Myref, FamilyRef, ChoiceFamily.Husband, AutoComplite))
            End If

            If Val.Model.Childrends.Count > 0 Then
                If ChoiceRef Is Nothing Then
                    Help.AddOption(Opt, Action, "Open Childrens.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Childrens,, AutoComplite))
                Else
                    Help.AddOption(Opt, Action, "Choice Childrens.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Childrens, ChoicerRef, AutoComplite))
                End If

            Else
                Help.AddOption(Opt, Action, "Register Childrens.", Sub() Register(Myref, FamilyRef, ChoiceFamily.Childrens, AutoComplite))
            End If
            '--------------------------------------

            Help.AddOption(Opt, Action, "Exit.", Sub() ContinueMenu = False)

            Help.PrintMenu(Opt)
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1 To Action.Count
                    Action(Choice - 1).Invoke
                    If ChoiceRef IsNot Nothing Then
                        ChoiceRef = ChoicerRef
                    End If
                Case Else
                    Continue Do
            End Select
        Loop While ContinueMenu = True
    End Sub


    Friend Sub Open(Myref As ProfileComponent.Profile.Able.IReference, FamilyRef As FamilyProject.Family.Ables.IReference, ChoiceFamily As ChoiceFamily, Optional ByRef ChoiceRef As ProfileComponent.Profile.Able.IReference = Nothing, Optional AutoComplite As Boolean = False)

        While ChoiceFamily = ChoiceFamily.Mother OrElse ChoiceFamily = ChoiceFamily.Father OrElse ChoiceFamily = ChoiceFamily.Husband
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.Contracts) = ProfileController.Family.Family.Exist(FamilyRef)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.ReadLine()
                Exit Sub
            End If

            If ChoiceFamily = ChoiceFamily.Mother Then
                If Val.Model.Mother = Nothing Then Exit Sub
                Console.WriteLine("--------- Mother --------")
                PersonModule.Info(ProfileController.ExistProfile(New Profile.Contracts.Contracts With {.PrimaryKey = Val.Model.Mother}).Model.PersonModel)
            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                If Val.Model.Father = Nothing Then Exit Sub
                Console.WriteLine("--------- Father --------")
                PersonModule.Info(ProfileController.ExistProfile(New Profile.Contracts.Contracts With {.PrimaryKey = Val.Model.Father}).Model.PersonModel)
            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                If Val.Model.Spouse = Nothing Then Exit Sub
                Console.WriteLine("--------- Husband --------")
                PersonModule.Info(ProfileController.ExistProfile(New Profile.Contracts.Contracts With {.PrimaryKey = Val.Model.Spouse}).Model.PersonModel)
            End If

            Console.WriteLine("--------- Menu ----------")
            Console.WriteLine("1) Open Profile.")
            Console.WriteLine("2) Remove from Family.")
            Console.WriteLine("3) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Dim SelectRef As ProfileComponent.Profile.Able.IReference = New ProfileComponent.Profile.Contracts.Contracts
                    If ChoiceFamily = ChoiceFamily.Mother Then
                        SelectRef.PrimaryKey = Val.Model.Mother
                    ElseIf ChoiceFamily = ChoiceFamily.Father Then
                        SelectRef.PrimaryKey = Val.Model.Father
                    ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                        SelectRef.PrimaryKey = Val.Model.Spouse
                    End If
                    ProfileModule.Menu(Myref, SelectRef)
                Case 2
                    Remove(FamilyRef, ChoiceFamily, AutoComplite)
                Case 3
                    Exit Sub
                Case Else
                    Continue While
            End Select
        End While

        While ChoiceFamily = ChoiceFamily.Childrens
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Model) = ProfileController.Family.ExistFamily(FamilyRef)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Exit Sub
            End If
            Console.WriteLine("--------- Childrens --------")
            Dim Index As Integer = 0

            For Each PersonModel In Val.Model.Childrends
                Index += 1
                Console.WriteLine(Index & ") " & ProfileController.ExistProfile(New Profile.Contracts.Contracts With {.PrimaryKey = PersonModel.PersonID}).Model.PersonModel.FullName)
            Next
            Console.WriteLine("----------- Menu ---------")
            If ChoiceRef Is Nothing Then
                Console.WriteLine(1 & " - " & Index & ") Open Children.")
            Else
                Console.WriteLine(1 & " - " & Index & ") Choice Children.")
            End If

            Console.WriteLine(Index + 1 & ") Add Children.")
            Console.WriteLine(Index + 2 & ") Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1 To Index
                    If ChoiceRef IsNot Nothing Then
                        Dim AccCreteria As ProfileComponent.Profile.Contracts.ICreteria = New ProfileComponent.Profile.Contracts.Contracts
                        AccCreteria.PersonID = New Profile.Contracts.Contracts With {.PrimaryKey = Val.Model.Childrends(Choice - 1).PersonID}.PersonID
                        ChoiceRef = ProfileController.Profile.Search(AccCreteria).Model
                        Exit Sub
                    End If
                    OpenChildren(Myref, Val.Model.Childrends(Choice - 1), AutoComplite)
                Case Index + 1
                    Register(Myref, FamilyRef, ChoiceFamily.Childrens, AutoComplite)
                Case Index + 2
                    Exit Sub
                Case Else
                    Continue While
            End Select
        End While
    End Sub
    Friend Sub OpenChildren(Myref As ProfileComponent.Profile.Able.IReference, Ref As FamilyProject.Children.Conctracts.IReference, Optional AutoComplite As Boolean = False)
        Do
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Children.Conctracts.Contracts) = ProfileController.Family.Childrens.Exist(Ref)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Exit Sub
            End If
            Dim PersonModel As ProfileComponent.Model = ProfileController.ExistPerson(New Profile.Contracts.Contracts With {.PrimaryKey = Val.Model.PersonID}).Model
            Console.WriteLine("---------- Children ----------")
            PersonModule.Info(PersonModel)
            Console.WriteLine("------- Menu --------")
            Console.WriteLine("1) Open Profile.")
            Console.WriteLine("2) Remove Child.")
            Console.WriteLine("3) Exit.")
            Console.WriteLine("---------------------")
            Console.WriteLine("Επέλεξε  ενα απο το Μενου:")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Dim Creterias As ProfileComponent.Profile.Contracts.ICreteria = New ProfileComponent.Profile.Contracts.Contracts
                    Creterias.PersonID = PersonModel.PersonModel.PrimaryKey
                    ProfileModule.Menu(Myref, ProfileController.Profile.Search(Creterias).Model)
                Case 2
                    RemoveChildren(Myref, Ref, AutoComplite)
                Case 3
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub

    Friend Sub RemoveChildren(Myref As ProfileComponent.Profile.Able.IReference, ChildRef As FamilyProject.Children.Conctracts.IReference, Optional AutoComplite As Boolean = False)
        Dim PersonModel As ProfileComponent.Model = ProfileController.ExistProfile(ChildRef).Model.PersonModel
        Console.Clear()
        Console.WriteLine("--------- Remove Children -------")
        PersonModule.Info(PersonModel)
        Console.WriteLine("---------- Menu ---------")
        If Help.AccessChoice("Θέλεις να συνεχησεις με την διαγραφή??") Then
            Dim ChildVal As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Children.Conctracts.Contracts) = ProfileController.Family.Childrens.Exist(ChildRef)

            If AutoComplite = True Then
                Dim FamilyCreteria As FamilyProject.Family.Contracts.ICreteria = New FamilyProject.Family.Contracts.Contracts
                ' FamilyCreteria.ExternalID = ChildVal.Model.PersonModel.PrimaryKey
                Dim FamilyVal As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.IModel) = ProfileController.Family.Family.Search(FamilyCreteria)
                Console.WriteLine("Τι Γωνιος ειστε?")
                Console.WriteLine("1) Η μητέρα του?")
                Console.WriteLine("2) Ο Πατέρας του?")
                Console.WriteLine("3) Exit.")
                Console.WriteLine("-----------------")
                Console.WriteLine("Επιλέξτε: ")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Dim FamilyRemove As FamilyProject.Family.Contracts.IRemoveMotherDTO = New FamilyProject.Family.Contracts.Contracts
                        FamilyRemove.Mother = Nothing
                        ProfileController.Family.Family.Change(FamilyVal.Model, FamilyRemove)
                    Case 2
                        Dim FamilyRemove As FamilyProject.Family.Contracts.IRegisterFatherDTO = New FamilyProject.Family.Contracts.Contracts
                        FamilyRemove.Father = Nothing
                        ProfileController.Family.Family.Change(FamilyVal.Model, FamilyRemove)
                    Case 3
                        Exit Sub
                End Select
            End If

            ProfileController.Family.Childrens.Remove(ChildRef)
            Console.ReadLine()
        End If
    End Sub

    Friend Sub Register(MyRef As ProfileComponent.Profile.Able.IReference, FamilyRef As FamilyProject.Family.Ables.IReference, ChoiceFamily As ChoiceFamily, Optional AutoComplite As Boolean = False)

        While ChoiceFamily = ChoiceFamily.Mother OrElse ChoiceFamily = ChoiceFamily.Father OrElse ChoiceFamily = ChoiceFamily.Husband AndAlso AutoComplite = False
            Dim Ref As ProfileComponent.Profile.Able.IReference = New ProfileComponent.Profile.Contracts.Contracts
            Dim Val As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.Contracts) = ProfileController.Family.Family.Exist(FamilyRef)
            Console.Clear()
            If ChoiceFamily = ChoiceFamily.Mother Then
                Console.WriteLine("---------- Register Family Mother --------")
            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                Console.WriteLine("---------- Register Family Father --------")
            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                Console.WriteLine("---------- Register Family Husband --------")
            End If
            Console.WriteLine("Επέλεξε απο ποια λίστα να προσθέσουμε:")
            Console.WriteLine("1) From My Friends.")
            Console.WriteLine("2) From System.")
            Console.WriteLine("3) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    RelationShipModule.ListOfFriend(MyRef, True, Ref)
                Case 2
                    ProfileModule.ListOfProfiles(MyRef, True, Ref)
                Case 3
                    Exit While
                Case Else
                    Continue While
            End Select


            Dim registerVal As New MyBook.ValMsg(Of ProfileComponent.FamilyProject.Model)
            If ChoiceFamily = ChoiceFamily.Mother Then
                registerVal = ProfileController.Family.AddMotherWithCompleteChild(FamilyRef, Ref.PrimaryKey)
            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                registerVal = ProfileController.Family.AddFatherWithCompleteChild(FamilyRef, Ref.PrimaryKey)
            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                registerVal = ProfileController.Family.AddSpouseWithComplete(FamilyRef, Ref.PrimaryKey)
            End If
            Console.WriteLine()
            Console.WriteLine(registerVal.Msg)
            Console.ReadLine()

            If registerVal.Success = True Then
                Exit While
            End If
        End While

        While ChoiceFamily = ChoiceFamily.Mother OrElse ChoiceFamily = ChoiceFamily.Father OrElse ChoiceFamily = ChoiceFamily.Husband AndAlso AutoComplite = True
            Dim Ref As ProfileComponent.Profile.Able.IReference = New ProfileComponent.Profile.Contracts.Contracts
            Dim Val As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.Contracts) = ProfileController.Family.Family.Exist(FamilyRef)
            Console.Clear()
            If ChoiceFamily = ChoiceFamily.Mother Then
                Console.WriteLine("---------- Register Family Mother --------")
            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                Console.WriteLine("---------- Register Family Father --------")
            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                Console.WriteLine("---------- Register Family Husband --------")
            End If
            Console.WriteLine("Επέλεξε απο ποια λίστα να προσθέσουμε:")
            Console.WriteLine("1) From My Friends.")
            Console.WriteLine("2) From System.")
            Console.WriteLine("3) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    RelationShipModule.ListOfFriend(MyRef, True, Ref)
                Case 2
                    ProfileModule.ListOfProfiles(MyRef, True, Ref)
                Case 3
                    Exit While
                Case Else
                    Continue While
            End Select


            Dim registerVal As New MyBook.ValMsg(Of ProfileComponent.FamilyProject.Model)
            If ChoiceFamily = ChoiceFamily.Mother Then
                registerVal = ProfileController.Family.AddMotherWithCompleteChild(FamilyRef, Ref.PrimaryKey)
            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                registerVal = ProfileController.Family.AddFatherWithCompleteChild(FamilyRef, Ref.PrimaryKey)
            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                registerVal = ProfileController.Family.AddSpouseWithComplete(FamilyRef, Ref.PrimaryKey)
            End If
            Console.WriteLine()
            Console.WriteLine(registerVal.Msg & "Register Malakias")
            Console.ReadLine()

            If registerVal.Success = True Then
                Exit While
            End If
        End While

        While ChoiceFamily = ChoiceFamily.Childrens
            Dim Ref As ProfileComponent.Profile.Able.IReference = New ProfileComponent.Profile.Contracts.Contracts
            Console.Clear()
            Console.WriteLine("---------- Register Family Children --------")
            Console.WriteLine("Επέλεξε απο ποια λίστα να προσθέσουμε:")
            Console.WriteLine("1) From My Friends.")
            Console.WriteLine("2) From System.")
            Console.WriteLine("3) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    RelationShipModule.ListOfFriend(MyRef, True, Ref)
                Case 2
                    ProfileModule.ListOfProfiles(MyRef, True, Ref)
                Case 3
                    Exit While
                Case Else
                    Continue While
            End Select
            If AutoComplite = True Then
                Console.WriteLine("Τι γόνεις ειστε:")
                Console.WriteLine("1) Mother.")
                Console.WriteLine("2) Father.")
                Console.WriteLine("3) Exit.")
                Console.WriteLine("------------")
                Console.WriteLine("Επέλεξε: ")
                Dim Choice1 As String = Console.ReadLine
                Select Case Choice1
                    Case 1
                        Dim ChildRefFamily As FamilyProject.Children.Conctracts.IReference = ProfileController.Family.Childrens.Exist(Ref).Model
                        ProfileController.Family.AddChildWithCompleteMother(FamilyRef, ChildRefFamily.PrimaryKey)
                    Case 2
                        Dim ChildRefFamily As FamilyProject.Children.Conctracts.IReference = ProfileController.Family.Childrens.Exist(Ref).Model
                        Console.WriteLine(ProfileController.Family.AddChildWithCompleteFather(FamilyRef, Ref.PrimaryKey).Msg)
                    Case 3
                        Exit Sub
                End Select
            End If
        End While
    End Sub

    Friend Sub Remove(FamilyRef As FamilyProject.Family.Ables.IReference, ChoiceFamily As ChoiceFamily, Optional AutoComplite As Boolean = False)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.Contracts) = ProfileController.Family.Family.Exist(FamilyRef)
        If ChoiceFamily = ChoiceFamily.Mother Then
            Console.WriteLine("---------- Remove Family Mother --------")
            PersonModule.Info(ProfileController.Person.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Val.Model.Mother}).Model)
        ElseIf ChoiceFamily = ChoiceFamily.Father Then
            Console.WriteLine("---------- Remove Family Father --------")
            PersonModule.Info(ProfileController.Person.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Val.Model.Father}).Model)
        ElseIf ChoiceFamily = ChoiceFamily.Husband Then
            Console.WriteLine("---------- Remove Family Husband --------")
            PersonModule.Info(ProfileController.Person.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Val.Model.Spouse}).Model)
        End If
        Console.WriteLine()
        If Help.AccessChoice("Θέλεις να συνεχήσεις?") = False Then
            Exit Sub
        End If

        Dim registerVal As New MyBook.ValMsg
        If ChoiceFamily = ChoiceFamily.Mother Then

            If AutoComplite = True Then
                Dim Creteria As FamilyProject.Family.Contracts.ICreteria = New FamilyProject.Family.Contracts.Contracts
                Creteria.ExternalID = Val.Model.Mother
                Dim FamilyVal As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.IModel) = ProfileController.Family.Family.Search(Creteria)

                Dim ChildCreteria As FamilyProject.Children.Conctracts.ICreteria = New FamilyProject.Children.Conctracts.Contracts
                With ChildCreteria
                    .FamilyID = FamilyVal.Model.PrimaryKey
                    .PersonID = ProfileController.Family.Family.Exist(FamilyRef).Model.ExternalID
                End With

                Dim ChildVal As MyBook.ValMsg(Of List(Of ProfileComponent.FamilyProject.Children.Conctracts.IModel)) = ProfileController.Family.Childrens.Search(ChildCreteria)
                ProfileController.Family.Childrens.Remove(ChildVal.Model(0))
            End If

            Dim RegisterDTO As FamilyProject.Family.Contracts.IRemoveMotherDTO = New FamilyProject.Family.Contracts.Contracts
            RegisterDTO.Mother = Nothing
            registerVal = ProfileController.Family.Family.Change(FamilyRef, RegisterDTO)

        ElseIf ChoiceFamily = ChoiceFamily.Father Then
            If AutoComplite = True Then
                Dim Creteria As FamilyProject.Family.Contracts.ICreteria = New FamilyProject.Family.Contracts.Contracts
                Creteria.ExternalID = Val.Model.Father
                Dim FamilyVal As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.IModel) = ProfileController.Family.Family.Search(Creteria)

                Dim ChildCreteria As FamilyProject.Children.Conctracts.ICreteria = New FamilyProject.Children.Conctracts.Contracts
                With ChildCreteria
                    .FamilyID = FamilyVal.Model.PrimaryKey
                    .PersonID = ProfileController.Family.Family.Exist(FamilyRef).Model.ExternalID
                End With

                Dim ChildVal As MyBook.ValMsg(Of List(Of ProfileComponent.FamilyProject.Children.Conctracts.IModel)) = ProfileController.Family.Childrens.Search(ChildCreteria)
                ProfileController.Family.Childrens.Remove(ChildVal.Model(0))
            End If

            Dim RegisterDTO As FamilyProject.Family.Contracts.IRemoveFatherDTO = New FamilyProject.Family.Contracts.Contracts
            RegisterDTO.Father = Nothing
            registerVal = ProfileController.Family.Family.Change(FamilyRef, RegisterDTO)
        ElseIf ChoiceFamily = ChoiceFamily.Husband Then
            Dim RegisterDTO As FamilyProject.Family.Contracts.IRemoveHusbandDTO = New FamilyProject.Family.Contracts.Contracts

            If AutoComplite = True Then
                Dim Creteria As FamilyProject.Family.Contracts.ICreteria = New FamilyProject.Family.Contracts.Contracts
                Creteria.ExternalID = Val.Model.Spouse
                Dim FamilyVal As MyBook.ValMsg(Of ProfileComponent.FamilyProject.Family.Contracts.IModel) = ProfileController.Family.Family.Search(Creteria)
                RegisterDTO.Spouse = Nothing
                registerVal = ProfileController.Family.Family.Change(FamilyVal.Model, RegisterDTO)
            End If

            RegisterDTO.Spouse = Nothing
            registerVal = ProfileController.Family.Family.Change(FamilyRef, RegisterDTO)

        End If
        Console.WriteLine()
        Console.WriteLine(registerVal.Msg)
        Console.ReadLine()

    End Sub

End Module
