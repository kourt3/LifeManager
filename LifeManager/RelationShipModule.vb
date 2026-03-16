Imports System.Reflection
Imports RelationShipComponent
Module RelationShipModule

    Friend Sub Info(Model As RelationShipComponent.Contracts.IModel)
        Dim AccountModel As AccountComponent.Contracts.IModel = AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model
        PersonModule.Info(AccountService.Exist(AccountModel).Model.PersonModel)
        Console.WriteLine("Description: " & Model.Description)
    End Sub
    Friend Sub Menu(MyRef As AccountComponent.Contracts.IReference, Ref As RelationShipComponent.Contracts.IReference)
        Do
            Console.Clear()
            Dim val As MyBook.ValMsg(Of Contracts.Contracts) = RelationShip.Exist(Ref)
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.ReadLine()
                Exit Do
            End If

            Dim AccountModel As AccountComponent.Contracts.IModel = AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = val.Model.ToExternalID}).Model
            Console.WriteLine("--------- Menu Relationship ---------")
            Info(val.Model)
            Console.WriteLine("--------- Menu ---------")
            Console.WriteLine("1) Open Profile.")
            Console.WriteLine("2) Change Description.")
            Console.WriteLine("3) Remove Relationship.")
            Console.WriteLine("4) Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    ProfileModule.Menu(MyRef, AccountModel)
                Case 2
                    ChangeDescription(Ref)
                Case 3
                    Remove(Ref)
                Case 4
                    Exit Sub
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Friend Sub ChangeDescription(Ref As RelationShipComponent.Contracts.IReference)
        Dim Val As MyBook.ValMsg(Of RelationShipComponent.Contracts.Contracts) = RelationShip.Exist(Ref)
        Dim AccountModel As AccountComponent.Contracts.IModel = AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = Val.Model.ToExternalID}).Model
        Console.Clear()
        Console.WriteLine("-------- Change description ----------")
        Info(Val.Model)
        Console.WriteLine("-------------------------------------")
        If Help.AccessChoice("Θέλεις να αλλάξεις Περιγραφη?") Then
            Dim Change As Contracts.IChangeDescriptionDTO = New Contracts.Contracts
            Console.WriteLine("Δώσε καινουργια Περιγραφή:")
            Change.Description = Console.ReadLine()
            Console.WriteLine(RelationShip.Change(Ref, Change).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub Remove(Ref As RelationShipComponent.Contracts.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of RelationShipComponent.Contracts.Contracts) = RelationShip.Exist(Ref)
        Console.WriteLine("-------- Remove Relationship ---------")
        Info(Val.Model)
        Console.WriteLine("-------------------------------")
        If Help.AccessChoice("Θέλεις να διαγραψεις το Relationship?") Then
            Console.WriteLine(RelationShip.RemoveBothRelationship(Ref).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub ListOfFriend(Ref As AccountComponent.Contracts.IReference, Optional SelecectChoice As Boolean = False, Optional ByRef ChoiceRef As AccountComponent.Contracts.IReference = Nothing)
        Do
            Dim Val As MyBook.ValMsg(Of List(Of Contracts.IModel)) = RelationShip.Search(New Contracts.Contracts With {.ExternalID = Ref.PrimaryKey})
            Console.Clear()
            Console.WriteLine("---------- List Of Relationship -------------")
            While Val.Success = False
                Console.WriteLine(Val.Msg)
                Console.WriteLine("------------------------------------")
                Console.WriteLine("1) Add Relationship.")
                Console.WriteLine("2) Exit.")
                Console.WriteLine("-----------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Μενου:")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        Register(Ref)
                        Continue Do
                    Case 2
                        Exit Do
                    Case Else
                        Continue Do
                End Select
            End While

            While Val.Success = True
                Dim Index As Integer = 0
                For Each Model In Val.Model
                    Index += 1
                    Dim Account As AccountComponent.Contracts.Contracts = AccountService.Exist(New AccountComponent.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model
                    Console.WriteLine(Index & ") " & Account.PersonModel.FullName & " | " & Model.Description)
                Next
                Console.WriteLine("-------- Menu ----------")

                If SelecectChoice = True Then
                    Console.WriteLine(1 & " - " & Index & ") Choice Person.")
                Else
                    Console.WriteLine(1 & " - " & Index & ") Open Person.")
                End If
                Console.WriteLine(Index + 1 & ") Add Friend.")
                Console.WriteLine(Index + 2 & ") Exit.")
                Console.WriteLine("---------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Μενου:")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1 To Index
                        If SelecectChoice = True Then
                            ChoiceRef = New AccountComponent.Contracts.Contracts With {.PrimaryKey = Val.Model(Choice - 1).ToExternalID}
                            Exit Do
                        End If
                        Menu(Ref, Val.Model(Choice - 1))
                        Continue Do
                    Case Index + 1
                        Register(Ref)
                        Continue Do
                    Case Index + 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select

            End While
        Loop
    End Sub
    Friend Function ChoiceRelationShipByAccount(Ref As AccountComponent.Contracts.IReference, ByRef ChoiceRef As AccountComponent.Contracts.IReference) As Boolean
        Do
            Console.Clear()
            Dim AccountVal As MyBook.ValMsg(Of List(Of AccountComponent.Contracts.Contracts)) = AccountService.Get_All
            Dim SearchVal As MyBook.ValMsg(Of List(Of RelationShipComponent.Contracts.IModel)) = RelationShip.Search(New Contracts.Contracts With {.ExternalID = Ref.PrimaryKey})
            Dim ListOfModelFromAccount As New List(Of AccountComponent.Contracts.IModel)
            For Each Model In AccountVal.Model
                Dim Exist As Boolean = False
                If Model.PrimaryKey = Ref.PrimaryKey Then
                    Continue For
                End If

                For i = 0 To SearchVal.Model.Count - 1
                    If SearchVal.Model(i).ToExternalID = Model.PrimaryKey Then
                        Exist = True
                        Exit For
                    End If
                Next

                If Exist = False Then
                    ListOfModelFromAccount.Add(Model)
                End If
            Next

            While ListOfModelFromAccount.Count = 0
                Console.WriteLine("----------- Menu ----------")
                Console.WriteLine("1) Add Profile.")
                Console.WriteLine("2) Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1
                        ProfileModule.Register()
                        Continue Do
                    Case 2
                        Return False
                End Select
            End While

            While ListOfModelFromAccount.Count > 0
                Dim index As Integer = 0
                For Each ModelAfterResize In ListOfModelFromAccount
                    index += 1
                    Console.WriteLine(index & ") " & ModelAfterResize.PersonModel.FullName)
                Next
                Console.WriteLine("----------- Menu ----------")
                Console.WriteLine(1 & " - " & index & ") Choice Profile.")
                Console.WriteLine(index + 1 & ") Add Profile.")
                Console.WriteLine(index + 2 & ") Exit.")
                Dim Choice As String = Console.ReadLine
                Select Case Choice
                    Case 1 To index
                        ChoiceRef = ListOfModelFromAccount(Choice - 1)
                        Return True
                    Case 2
                        ProfileModule.Register()
                        Continue Do
                    Case 3
                        Return False
                End Select
            End While
        Loop
    End Function
    Public Sub Register(Ref As AccountComponent.Contracts.IReference, Optional ThirdRef As AccountComponent.Contracts.IReference = Nothing)
        Do While ThirdRef Is Nothing
            Dim RegisterDTO As Contracts.IRegisterDTO = New Contracts.Contracts
            Dim NewRef As AccountComponent.Contracts.IReference = New AccountComponent.Contracts.Contracts
            Console.Clear()
            Console.WriteLine("------------ Register Relationship -----------")
            If ChoiceRelationShipByAccount(Ref, NewRef) Then
                RegisterDTO.ExternalID = Ref.PrimaryKey
                RegisterDTO.ToExternalID = NewRef.PrimaryKey
            Else
                Exit Sub
            End If

            Help.IfNotInputOrMsg("Δώσε μια Περιγραφή:", RegisterDTO.Description)
            If Help.AccessChoice("Θέλεις να συνεχήσεις με την Εγραφή ?") Then
                Console.WriteLine(RelationShip.RegisterBothRelationship(RegisterDTO).Msg)
                Console.ReadLine()
            End If
            Exit Do
        Loop

        Do While ThirdRef IsNot Nothing
            Dim RegisterDTO As Contracts.IRegisterDTO = New Contracts.Contracts
            RegisterDTO.ExternalID = Ref.PrimaryKey
            RegisterDTO.ToExternalID = ThirdRef.PrimaryKey
            Console.Clear()
            Console.WriteLine("------------ Add Relationship ----------")
            PersonModule.Info(AccountService.Exist(ThirdRef).Model.PersonModel)
            Console.WriteLine("----------------------------------------")
            Help.IfNotInputOrMsg("Δώσε Description: ", RegisterDTO.Description)
            If Help.AccessChoice("Θέλεις να συνεχίσεις με την εγραφή: ") Then
                Console.WriteLine(RelationShip.RegisterBothRelationship(RegisterDTO).Msg)
                Console.ReadLine()
            End If
            Exit Do
        Loop
    End Sub
End Module
