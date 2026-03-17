Imports Economy.TransferProject
Module TransferModule
    Friend Sub Info(Model As Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Category: " & Model.FromCategory)
        Console.WriteLine("From: " & Model.ExternalID)
        Console.WriteLine("Money: " & Model.MoneyValue)
        Console.WriteLine("To Category: " & Model.ToCategory)
        Console.WriteLine("To: " & Model.ToExternalID)
        Console.WriteLine("Date: " & Model.CreateAt)
        Console.WriteLine("Description: " & Model.Description)
    End Sub
    Friend Sub Menu(Ref As Entity.IReference)
        Do
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of Contracts.Contract) = TransferService.Exist(Ref)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Exit Sub
            End If

            Console.WriteLine("------------ Info: Transfer --------------")
            Info(Val.Model)
            Console.WriteLine("-----------------------------------")
            Console.WriteLine()
            Console.WriteLine("--------- Menu ---------")
            Console.WriteLine("1) Change Money.")
            Console.WriteLine("2) Change Description.")
            Console.WriteLine("3) Remove.")
            Console.WriteLine("4) Exit.")
            Console.WriteLine("-----------------")
            Console.WriteLine("Επέλεξε ενα απο το Menu")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    ChangeMoney(Ref)
                Case 2
                    ChangeDescription(Ref)
                Case 3
                    Remove(Ref)
                Case 4
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Friend Sub ChoiceListEconomy(Myref As AccountComponent.Contracts.IReference, ByRef ChoiceCategoryEconomy As String, ByRef ChoiceEconomyId As Integer)
        Dim RefPerson As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
        Do
            Console.WriteLine("------------- Choice on the list --------------")
            Console.WriteLine("1) Friends.")
            Console.WriteLine("2) Cohrabition.")
            Console.WriteLine("3) Family.")
            Console.WriteLine("4) Exit.")
            Console.WriteLine("---------------------")
            Console.WriteLine("Επέλεξε:")
            Dim ChoicePerson As String = Console.ReadLine
            Select Case ChoicePerson
                Case 1
                    RelationShipModule.ListOfFriend(Myref, True, RefPerson)
                Case 2
                    Dim ApartmentRef As Apartment.Contracts.IReference = New Apartment.Contracts.Contracts
                    CohrabitionModule.ListOfApartment(Myref, True, ApartmentRef)
                    CohrabitionModule.ListOfCohrabition(ApartmentRef, Myref, Nothing, True, RefPerson)
                Case 3
                    FamilyModule.Menu(Myref, AccountService.Exist(Myref).Model.FamilyModel, RefPerson)
                Case 4
                    Exit Do
                Case Else
                    Continue Do
            End Select

            If RefPerson IsNot Nothing Then
                EconomyModule.Menu(RefPerson, True, ChoiceCategoryEconomy, ChoiceEconomyId)
                Exit Do
            End If

        Loop


    End Sub



    Friend Sub Register(Myref As AccountComponent.Contracts.IReference, CategoryEconomy As String, ExternalId As Integer)
        'Να κανουμε να επιλογη (Friends,relationship,cohrabition, family) -  ισως χρειαστει ενα generic function Choicer για ολα τα Project
        'Μετα να κανουμε αναζητηση το portofolio που εχει
        'και μετα να βαλουμε το ποσο 

        Do
            Dim FromTrans As String = Nothing, ToTrans As String = Nothing
            Dim RegisterDTO As Contracts.IRegisterDTO = New Contracts.Contract
            Console.Clear()
            Console.WriteLine("------------ Register Transfer -------------")
            Console.WriteLine("1) Έσοδα.")
            Console.WriteLine("2) Έξοδα.")
            Console.WriteLine("3) Exit.")
            Console.WriteLine("----------------------------------------------")
            Console.WriteLine("Επέλεξε:")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    Console.Clear()
                    Console.WriteLine("Καταχωρήστε ποιος σας Έστειλε Λεφτά:")

                    ChoiceListEconomy(Myref, RegisterDTO.FromCategory, RegisterDTO.ExternalID)
                    RegisterDTO.ToExternalID = ExternalId
                    RegisterDTO.ToCategory = CategoryEconomy

                Case 2
                    Console.Clear()
                    Console.WriteLine("Καταχωρήστε Σε ποιον Στέλνετε Λεφτά:")
                    ChoiceListEconomy(Myref, RegisterDTO.ToCategory, RegisterDTO.ToExternalID)
                    RegisterDTO.ExternalID = ExternalId
                    RegisterDTO.FromCategory = CategoryEconomy
                Case 3
                    Exit Do
                Case Else
                    Continue Do
            End Select
            Console.WriteLine("Το Ποσό:")
            RegisterDTO.MoneyValue = Console.ReadLine
            Console.WriteLine("Δωστε καποια πληροφορία:")
            RegisterDTO.Description = Console.ReadLine
            RegisterDTO.CreateAt = Now
            Dim Val As MyBook.ValMsg(Of Contracts.Contract) = TransferService.Register(RegisterDTO)
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        Loop
    End Sub
    Friend Sub ChangeMoney(Ref As Entity.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contract) = TransferService.Exist(Ref)
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Exit Sub
        End If
        Console.WriteLine("---------- Change Money -------------")
        Info(Val.Model)
        Console.WriteLine()
        If Help.AccessChoice("Θέλετε να αλλάξετε το Money;") Then
            Console.Clear()
            Dim Change As Contracts.IChangeMoney = New Contracts.Contract
            Console.WriteLine("Παρακαλώ Δώσε καινουργιο Money:")
            Change.MoneyValue = Console.ReadLine
            Console.WriteLine(TransferService.Change(Ref, Change).Msg)
            Exit Sub
        End If
    End Sub
    Friend Sub ChangeDescription(Ref As Entity.IReference)

        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contract) = TransferService.Exist(Ref)
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Exit Sub
        End If
        Console.WriteLine("---------- Change Description -------------")
        Info(Val.Model)
        Console.WriteLine()
        If Help.AccessChoice("Θέλετε να αλλάξετε το Description;") Then
            Console.Clear()
            Dim Change As Contracts.IChangeDescriptionDTO = New Contracts.Contract
            Console.WriteLine("Παρακαλώ Δώσε καινουργιο Description:")
            Change.Description = Console.ReadLine
            Console.WriteLine(TransferService.Change(Ref, Change).Msg)
            Exit Sub
        End If

    End Sub
    Sub SearchMenu(Myref As AccountComponent.Contracts.IReference, CategoryEconomy As String, ExternalId As Integer)
        Do
            Console.Clear()
            Console.WriteLine("---------- Analusis Data Transfer ----------")
            Console.WriteLine("1) Έσοδα.")
            Console.WriteLine("2) Έξοδα.")
            Console.WriteLine("3) Όλα.")
            Console.WriteLine("4) Exit.")
            Dim Str As String = Console.ReadLine
            Dim Creteria As Contracts.ICreateria = New Contracts.Contract
            Select Case Str
                Case 1
                    Creteria.ToCategory = CategoryEconomy
                    Creteria.ToExternalID = ExternalId
                Case 2
                    Creteria.FromCategory = CategoryEconomy
                    Creteria.ExternalID = ExternalId
                Case 3
                    Creteria.FromCategory = CategoryEconomy
                    Creteria.ToCategory = CategoryEconomy
                    Creteria.ExternalID = ExternalId
                    Creteria.ToExternalID = ExternalId
                Case 4
                    Exit Do
                Case Else
                    Continue Do
            End Select
            ListOfTransfer(Myref, CategoryEconomy, ExternalId, Creteria)
        Loop
    End Sub
    Friend Sub ListOfTransfer(Myref As AccountComponent.Contracts.IReference, CategoryEconomy As String, ExternalId As Integer, Creteria As Economy.TransferProject.Contracts.ICreateria)
        Do
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of List(Of Contracts.IModel)) = TransferService.Search(Creteria)
            While Val.Success = False
                Console.WriteLine(Val.Msg)
                Console.WriteLine("-------------- Menu -----------------")
                Console.WriteLine("1) Register Transfer.")
                Console.WriteLine("2) Exit.")
                Console.WriteLine()
                Console.WriteLine("Επέλεξε ενα απο το Μενου:")
                Dim str As String = Console.ReadLine
                Select Case str
                    Case 1
                        Register(Myref, CategoryEconomy, ExternalId)
                        Continue Do
                    Case 2
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            End While

            While Val.Success = True

                Dim index As Integer = 0
                For Each Transfer In Val.Model
                    index += 1
                    Console.WriteLine(index & ") " & Transfer.ExternalID & " " & Transfer.MoneyValue & " " & Transfer.ToExternalID & " " & Transfer.Description & " " & Transfer.CreateAt)
                Next
                Console.WriteLine("-------------------------------------------")
                Console.WriteLine("1 -" & index & ") Επιλογη κίνησης.")
                Console.WriteLine(index + 1 & ") Register.")
                Console.WriteLine(index + 2 & ") Exit.")
                Dim Str As String = Console.ReadLine() - 1

                Select Case Str
                    Case 0 To index - 1
                        Menu(Val.Model(Int(Str)))
                    Case index
                        Register(Myref, CategoryEconomy, ExternalId)
                        Continue Do
                    Case index + 1
                        Exit Do
                    Case Else
                        Continue While
                End Select

            End While

        Loop
    End Sub
    Friend Sub Remove(ref As Entity.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contract) = TransferService.Exist(ref)
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Exit Sub
        End If

        Console.WriteLine("--------- Remove Transfer ------------")
        Info(Val.Model)
        Console.WriteLine("--------------------------------------")
        If Help.AccessChoice("Θέλετε να διαγράψετε τον λογαριασμο?") Then
            Console.Clear()
            Console.WriteLine(TransferService.Remove(ref).Msg)
        End If

    End Sub

End Module
