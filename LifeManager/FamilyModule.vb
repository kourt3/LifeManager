Imports FamilyProject
Module FamilyModule
    Friend Sub info(Model As FamilyProject.Contracts.IModel)
        Console.WriteLine("------ Mother --------")
        If Model.MotherModel IsNot Nothing Then
            Console.WriteLine("FullName: " & Model.MotherModel.FullName)
        Else
            Console.WriteLine("Δεν Έχει καταχωρηθη!")
        End If
        Console.WriteLine("------- Father --------")
        If Model.FatherModel IsNot Nothing Then
            Console.WriteLine("FullName: " & Model.FatherModel.FullName)
        Else
            Console.WriteLine("Δεν Έχει καταχωρηθη!")
        End If
        Console.WriteLine("-------- Wife/Husband -------")
        If Model.HusbandModel IsNot Nothing Then
            Console.WriteLine("FullName: " & Model.HusbandModel.FullName)
        Else
            Console.WriteLine("Δεν Έχει καταχωρηθη!")
        End If
        Console.WriteLine("------- Childrens -----------")
        Console.WriteLine("Childrens: " & Model.Childrens.Count)
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
    Friend Sub Menu(Myref As AccountComponent.Contracts.IReference, FamilyRef As FamilyProject.Contracts.IReference, Optional ByRef ChoiceRef As AccountComponent.Contracts.IReference = Nothing, Optional AutoComplite As Boolean = False)
        Dim ContinueMenu As Boolean = True
        Do

            Dim ChoicerRef As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
            Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Family.Exist(FamilyRef)
            Dim Opt As New List(Of String)
            Dim Action As New List(Of Action)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Console.Clear()
            Console.WriteLine("-------- Family ---------")
            Console.WriteLine()
            info(Val.Model)
            Console.WriteLine()
            Console.WriteLine("----------- Menu ----------")

            If Val.Model.MotherModel IsNot Nothing Then
                If ChoiceRef Is Nothing Then
                    Help.AddOption(Opt, Action, "Open Mother.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Mother,, AutoComplite))
                Else
                    Help.AddOption(Opt, Action, "Choice Mother.", Sub()
                                                                      Dim Creteria As AccountComponent.Contracts.ICreteria = New AccountComponent.Contracts.Contracts
                                                                      Creteria.PersonRef = Val.Model.MotherModel
                                                                      ChoicerRef = AccountService.Search(Creteria).Model
                                                                  End Sub)
                End If
            Else
                Help.AddOption(Opt, Action, "Register Mother.", Sub() Register(Myref, FamilyRef, ChoiceFamily.Mother))
            End If

            If Val.Model.FatherModel IsNot Nothing Then
                If ChoiceRef Is Nothing Then
                    Help.AddOption(Opt, Action, "Open Father.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Father,, AutoComplite))
                Else
                    Help.AddOption(Opt, Action, "Choice Father.", Sub()
                                                                      Dim Creteria As AccountComponent.Contracts.ICreteria = New AccountComponent.Contracts.Contracts
                                                                      Creteria.PersonRef = Val.Model.FatherModel
                                                                      ChoicerRef = AccountService.Search(Creteria).Model
                                                                  End Sub)
                End If
            Else
                Help.AddOption(Opt, Action, "Register Father.", Sub() Register(Myref, FamilyRef, ChoiceFamily.Father, AutoComplite))
            End If

            If Val.Model.HusbandModel IsNot Nothing Then
                If ChoiceRef Is Nothing Then
                    Help.AddOption(Opt, Action, "Open Wife/Husband.", Sub() Open(Myref, FamilyRef, ChoiceFamily.Husband,, AutoComplite))
                Else
                    Help.AddOption(Opt, Action, "Choice Wife/Husband.", Sub()
                                                                            Dim Creteria As AccountComponent.Contracts.ICreteria = New AccountComponent.Contracts.Contracts
                                                                            Creteria.PersonRef = Val.Model.HusbandModel
                                                                            ChoicerRef = AccountService.Search(Creteria).Model
                                                                        End Sub)
                End If
            Else
                Help.AddOption(Opt, Action, "Register Wife/Husband.", Sub() Register(Myref, FamilyRef, ChoiceFamily.Husband, AutoComplite))
            End If

            If Val.Model.Childrens.Count > 0 Then
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


    Friend Sub Open(Myref As AccountComponent.Contracts.IReference, FamilyRef As FamilyProject.Contracts.IReference, ChoiceFamily As ChoiceFamily, Optional ByRef ChoiceRef As AccountComponent.Contracts.IReference = Nothing, Optional AutoComplite As Boolean = False)

        While ChoiceFamily = ChoiceFamily.Mother OrElse ChoiceFamily = ChoiceFamily.Father OrElse ChoiceFamily = ChoiceFamily.Husband
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Family.Exist(FamilyRef)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.ReadLine()
                Exit Sub
            End If

            If ChoiceFamily = ChoiceFamily.Mother Then
                If Val.Model.MotherModel Is Nothing Then Exit Sub
                Console.WriteLine("--------- Mother --------")
                PersonModule.Info(Val.Model.MotherModel)
            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                If Val.Model.FatherModel Is Nothing Then Exit Sub
                Console.WriteLine("--------- Father --------")
                PersonModule.Info(Val.Model.FatherModel)
            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                If Val.Model.HusbandModel Is Nothing Then Exit Sub
                Console.WriteLine("--------- Husband --------")
                PersonModule.Info(Val.Model.HusbandModel)
            End If

            Console.WriteLine("--------- Menu ----------")
            Console.WriteLine("1) Open Profile.")
            Console.WriteLine("2) Remove from Family.")
            Console.WriteLine("3) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    Dim AccountCreterias As AccountComponent.Contracts.ICreteria = New AccountComponent.Contracts.Contracts
                    If ChoiceFamily = ChoiceFamily.Mother Then
                        AccountCreterias.PersonRef = Val.Model.MotherModel
                    ElseIf ChoiceFamily = ChoiceFamily.Father Then
                        AccountCreterias.PersonRef = Val.Model.FatherModel
                    ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                        AccountCreterias.PersonRef = Val.Model.HusbandModel
                    End If
                    ProfileModule.Menu(Myref, AccountService.Search(AccountCreterias).Model)
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
            Dim Creteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
            Creteria.FamilyID = FamilyRef.PrimaryKey
            Dim Val As MyBook.ValMsg(Of List(Of Children.Conctracts.IModel)) = Family.Childrens.Search(Creteria)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Exit Sub
            End If
            Console.WriteLine("--------- Childrens --------")
            Dim Index As Integer = 0

            For Each PersonModel In Val.Model
                Index += 1
                Console.WriteLine(Index & ") " & PersonModel.PersonModel.FullName)
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
                        Dim AccCreteria As AccountComponent.Contracts.ICreteria = New AccountComponent.Contracts.Contracts
                        AccCreteria.LoginRef = Val.Model(Choice - 1).PersonModel
                        ChoiceRef = AccountService.Search(AccCreteria).Model
                        Exit Sub
                    End If
                    OpenChildren(Myref, Val.Model(Choice - 1), AutoComplite)
                Case Index + 1
                    Register(Myref, FamilyRef, ChoiceFamily.Childrens, AutoComplite)
                Case Index + 2
                    Exit Sub
                Case Else
                    Continue While
            End Select
        End While
    End Sub
    Friend Sub OpenChildren(Myref As AccountComponent.Contracts.IReference, Ref As Children.Conctracts.IReference, Optional AutoComplite As Boolean = False)
        Do
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Family.Childrens.Exist(Ref)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Exit Sub
            End If
            Dim PersonModel As PersonProject.Contracts.IModel = Val.Model.PersonModel
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
                    Dim Creterias As AccountComponent.Contracts.ICreteria = New AccountComponent.Contracts.Contracts
                    Creterias.PersonRef = PersonModel
                    ProfileModule.Menu(Myref, AccountService.Search(Creterias).Model)
                Case 2
                    RemoveChildren(Myref, Ref, AutoComplite)
                Case 3
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub

    Friend Sub RemoveChildren(Myref As AccountComponent.Contracts.IReference, ChildRef As Children.Conctracts.IReference, Optional AutoComplite As Boolean = False)
        Dim PersonModel As PersonProject.Contracts.IModel = Family.Childrens.Exist(ChildRef).Model.PersonModel
        Console.Clear()
        Console.WriteLine("--------- Remove Children -------")
        PersonModule.Info(PersonModel)
        Console.WriteLine("---------- Menu ---------")
        If Help.AccessChoice("Θέλεις να συνεχησεις με την διαγραφή??") Then
            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Family.Childrens.Exist(ChildRef)

            If AutoComplite = True Then
                Dim FamilyCreteria As FamilyProject.Contracts.ICreteria = New Contracts.Contracts
                FamilyCreteria.MePersonID = ChildVal.Model.PersonModel.PrimaryKey
                Dim FamilyVal As MyBook.ValMsg(Of FamilyProject.Contracts.IModel) = Family.Search(FamilyCreteria)
                Console.WriteLine("Τι Γωνιος ειστε?")
                Console.WriteLine("1) Η μητέρα του?")
                Console.WriteLine("2) Ο Πατέρας του?")
                Console.WriteLine("3) Exit.")
                Console.WriteLine("-----------------")
                Console.WriteLine("Επιλέξτε: ")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Dim FamilyRemove As FamilyProject.Contracts.IRemoveMotherDTO = New Contracts.Contracts
                        FamilyRemove.Mother = Nothing
                        Family.Change(FamilyVal.Model, FamilyRemove)
                    Case 2
                        Dim FamilyRemove As FamilyProject.Contracts.IRegisterFatherDTO = New Contracts.Contracts
                        FamilyRemove.Father = Nothing
                        Family.Change(FamilyVal.Model, FamilyRemove)
                    Case 3
                        Exit Sub
                End Select
            End If

            Family.Childrens.Remove(ChildRef)
            Console.ReadLine()
        End If
    End Sub

    Friend Sub Register(MyRef As AccountComponent.Contracts.IReference, FamilyRef As FamilyProject.Contracts.IReference, ChoiceFamily As ChoiceFamily, Optional AutoComplite As Boolean = False)

        While ChoiceFamily = ChoiceFamily.Mother OrElse ChoiceFamily = ChoiceFamily.Father OrElse ChoiceFamily = ChoiceFamily.Husband AndAlso AutoComplite = False
            Dim Ref As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
            Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Family.Exist(FamilyRef)
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


            Dim registerVal As New MyBook.ValMsg
            If ChoiceFamily = ChoiceFamily.Mother Then
                'Πρωτη εγραφή την βαζω μητερα 
                Dim RegisterDTO As FamilyProject.Contracts.IRegisterMotherDTO = New Contracts.Contracts
                RegisterDTO.Mother = AccountService.Exist(Ref).Model.PersonModel.PrimaryKey
                registerVal = Family.Change(FamilyRef, RegisterDTO)
            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                Dim RegisterDTO As FamilyProject.Contracts.IRegisterFatherDTO = New Contracts.Contracts
                RegisterDTO.Father = Ref.PrimaryKey
                registerVal = Family.Change(FamilyRef, RegisterDTO)

            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                Dim RegisterDTO As FamilyProject.Contracts.IRegisterHusbandDTO = New Contracts.Contracts
                RegisterDTO.Husband = Ref.PrimaryKey
                registerVal = Family.Change(FamilyRef, RegisterDTO)
            End If
            Console.WriteLine()
            Console.WriteLine(registerVal.Msg)
            Console.ReadLine()

            If registerVal.Success = True Then
                Exit While
            End If
        End While

        While ChoiceFamily = ChoiceFamily.Mother OrElse ChoiceFamily = ChoiceFamily.Father OrElse ChoiceFamily = ChoiceFamily.Husband AndAlso AutoComplite = True
            Dim Ref As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
            Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Family.Exist(FamilyRef)
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


            Dim registerVal As New MyBook.ValMsg
            If ChoiceFamily = ChoiceFamily.Mother Then
                'Πρωτη εγραφή την βαζω μητερα 
                Dim RegisterDTO As FamilyProject.Contracts.IRegisterMotherDTO = New Contracts.Contracts
                RegisterDTO.Mother = AccountService.Exist(Ref).Model.PersonModel.PrimaryKey
                registerVal = Family.Change(FamilyRef, RegisterDTO)
                '----------------------

                Dim ChildRegDTO As FamilyProject.Contracts.IRegisterChildrendDTO = New Contracts.Contracts
                Dim Creteria As FamilyProject.Contracts.ICreteria = New Contracts.Contracts

                'Εφωσον γνωριζω το PersonId -> Mother ψάχνω για το Family της   
                Creteria.MePersonID = RegisterDTO.Mother
                ChildRegDTO.FamilyID = Family.Search(Creteria).Model.PrimaryKey
                ChildRegDTO.PersonID = AccountService.Exist(MyRef).Model.PersonModel.PrimaryKey 'Προσθέτω τον ευτο μου για child

                '-----------------------------------------
                Dim MotherFamilyRef As FamilyProject.Contracts.IReference = New FamilyProject.Contracts.Contracts
                MotherFamilyRef.PrimaryKey = ChildRegDTO.FamilyID

                'Βάζω της Μητερας το Family για να με προσθέσω σαν Child
                Family.Register(MotherFamilyRef, ChildRegDTO)

            ElseIf ChoiceFamily = ChoiceFamily.Father Then
                Dim RegisterDTO As FamilyProject.Contracts.IRegisterFatherDTO = New Contracts.Contracts
                RegisterDTO.Father = Ref.PrimaryKey
                registerVal = Family.Change(FamilyRef, RegisterDTO)


                Dim RegisterDTO1 As FamilyProject.Contracts.IRegisterChildrendDTO = New Contracts.Contracts
                Dim Creteria As FamilyProject.Contracts.ICreteria = New Contracts.Contracts
                Creteria.MePersonID = RegisterDTO.Father
                RegisterDTO1.FamilyID = Family.Search(Creteria).Model.PrimaryKey
                RegisterDTO1.PersonID = AccountService.Exist(MyRef).Model.PersonModel.PrimaryKey
                Dim MotherFamilyRef As FamilyProject.Contracts.IReference = New FamilyProject.Contracts.Contracts
                MotherFamilyRef.PrimaryKey = RegisterDTO1.FamilyID
                Family.Register(MotherFamilyRef, RegisterDTO1)

            ElseIf ChoiceFamily = ChoiceFamily.Husband Then
                Dim RegisterDTO As FamilyProject.Contracts.IRegisterHusbandDTO = New Contracts.Contracts
                RegisterDTO.Husband = Ref.PrimaryKey
                registerVal = Family.Change(FamilyRef, RegisterDTO)

                Dim RegisterDTO1 As FamilyProject.Contracts.IRegisterHusbandDTO = New Contracts.Contracts
                RegisterDTO1.Husband = AccountService.Exist(MyRef).Model.PersonModel.PrimaryKey
                registerVal = Family.Change(AccountService.Exist(Ref).Model.FamilyModel, RegisterDTO1)
            End If
            Console.WriteLine()
            Console.WriteLine(registerVal.Msg & "Register Malakiaw")
            Console.ReadLine()

            If registerVal.Success = True Then
                Exit While
            End If
        End While

        While ChoiceFamily = ChoiceFamily.Childrens
            Dim Ref As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
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
                        Dim ChildRefFamily As FamilyProject.Contracts.IReference = AccountService.Exist(Ref).Model.FamilyModel
                        Dim RegisterMother As FamilyProject.Contracts.IRegisterMotherDTO = New Contracts.Contracts

                        RegisterMother.Mother = Family.Exist(FamilyRef).Model.MePersonModel.PrimaryKey
                        Family.Change(ChildRefFamily, RegisterMother)
                    Case 2
                        Dim ChildRefFamily As FamilyProject.Contracts.IReference = AccountService.Exist(Ref).Model.FamilyModel
                        Dim RegisterFather As FamilyProject.Contracts.IRegisterFatherDTO = New Contracts.Contracts

                        RegisterFather.Father = Family.Exist(FamilyRef).Model.MePersonID
                        Console.WriteLine(Family.Change(ChildRefFamily, RegisterFather).Msg)
                    Case 3
                        Exit Sub
                End Select
            End If
            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            RegisterDTO.FamilyID = FamilyRef.PrimaryKey
            RegisterDTO.PersonID = Ref.PrimaryKey
            Dim Val As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Family.Childrens.Register(RegisterDTO)

            Console.WriteLine()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            If Val.Success = True Then
                Exit While
            End If
        End While
    End Sub

    Friend Sub Remove(FamilyRef As FamilyProject.Contracts.IReference, ChoiceFamily As ChoiceFamily, Optional AutoComplite As Boolean = False)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of FamilyProject.Contracts.Contracts) = Family.Exist(FamilyRef)
        If ChoiceFamily = ChoiceFamily.Mother Then
            Console.WriteLine("---------- Remove Family Mother --------")
            PersonModule.Info(Val.Model.MotherModel)
        ElseIf ChoiceFamily = ChoiceFamily.Father Then
            Console.WriteLine("---------- Remove Family Father --------")
            PersonModule.Info(Val.Model.FatherModel)
        ElseIf ChoiceFamily = ChoiceFamily.Husband Then
            Console.WriteLine("---------- Remove Family Husband --------")
            PersonModule.Info(Val.Model.HusbandModel)
        End If
        Console.WriteLine()
        If Help.AccessChoice("Θέλεις να συνεχήσεις?") = False Then
            Exit Sub
        End If

        Dim registerVal As New MyBook.ValMsg
        If ChoiceFamily = ChoiceFamily.Mother Then

            If AutoComplite = True Then
                Dim Creteria As Contracts.ICreteria = New Contracts.Contracts
                Creteria.MePersonID = Val.Model.MotherModel.PrimaryKey
                Dim FamilyVal As MyBook.ValMsg(Of Contracts.IModel) = Family.Search(Creteria)

                Dim ChildCreteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
                With ChildCreteria
                    .FamilyID = FamilyVal.Model.PrimaryKey
                    .PersonID = Family.Exist(FamilyRef).Model.MePersonID
                End With

                Dim ChildVal As MyBook.ValMsg(Of List(Of FamilyProject.Children.Conctracts.IModel)) = Family.Childrens.Search(ChildCreteria)
                Family.Childrens.Remove(ChildVal.Model(0))
            End If

            Dim RegisterDTO As FamilyProject.Contracts.IRemoveMotherDTO = New Contracts.Contracts
            RegisterDTO.Mother = Nothing
            registerVal = Family.Change(FamilyRef, RegisterDTO)

        ElseIf ChoiceFamily = ChoiceFamily.Father Then
            If AutoComplite = True Then
                Dim Creteria As Contracts.ICreteria = New Contracts.Contracts
                Creteria.MePersonID = Val.Model.FatherModel.PrimaryKey
                Dim FamilyVal As MyBook.ValMsg(Of Contracts.IModel) = Family.Search(Creteria)

                Dim ChildCreteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
                With ChildCreteria
                    .FamilyID = FamilyVal.Model.PrimaryKey
                    .PersonID = Family.Exist(FamilyRef).Model.MePersonID
                End With

                Dim ChildVal As MyBook.ValMsg(Of List(Of FamilyProject.Children.Conctracts.IModel)) = Family.Childrens.Search(ChildCreteria)
                Family.Childrens.Remove(ChildVal.Model(0))
            End If

            Dim RegisterDTO As FamilyProject.Contracts.IRemoveFatherDTO = New Contracts.Contracts
            RegisterDTO.Father = Nothing
            registerVal = Family.Change(FamilyRef, RegisterDTO)
        ElseIf ChoiceFamily = ChoiceFamily.Husband Then
            Dim RegisterDTO As FamilyProject.Contracts.IRemoveHusbandDTO = New Contracts.Contracts

            If AutoComplite = True Then
                Dim Creteria As Contracts.ICreteria = New Contracts.Contracts
                Creteria.MePersonID = Val.Model.HusbandModel.PrimaryKey
                Dim FamilyVal As MyBook.ValMsg(Of Contracts.IModel) = Family.Search(Creteria)
                RegisterDTO.Husband = Nothing
                registerVal = Family.Change(FamilyVal.Model, RegisterDTO)
            End If

            RegisterDTO.Husband = Nothing
            registerVal = Family.Change(FamilyRef, RegisterDTO)

        End If
            Console.WriteLine()
        Console.WriteLine(registerVal.Msg)
        Console.ReadLine()

    End Sub

End Module
