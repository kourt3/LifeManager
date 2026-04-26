Imports System.Reflection
Imports ProfileComponent.ContactsProject
Module RelationShipModule

    Friend Sub Info(Model As Contracts.IModel)
        Dim AccountModel As ProfileComponent.Profile.Contracts.IModel = ProfileController.Profile.Exist(New ProfileComponent.Profile.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}).Model
        PersonModule.Info(ProfileController.Person.Exist(New ProfileComponent.PersonProject.Contracts.Contracts With {.PrimaryKey = AccountModel.PersonID}).Model)
        Console.WriteLine("Description: " & Model.Description)
    End Sub
    Friend Sub Menu(MyRef As ProfileComponent.Profile.Able.IReference, Ref As Contracts.IReference)
        Do
            Console.Clear()
            Dim val As MyBook.ValMsg(Of Contracts.Contracts) = ProfileController.Contact.Exist(Ref)
            If val.Success = False Then
                Console.WriteLine(val.Msg)
                Console.ReadLine()
                Exit Do
            End If


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
                    Dim ProfileVal As ProfileComponent.Profile.Contracts.Contracts = ProfileController.Profile.Exist(New ProfileComponent.Profile.Contracts.Contracts With {.PrimaryKey = val.Model.ToExternalID}).Model
                    ProfileModule.Menu(MyRef, ProfileVal)
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
    Friend Sub ChangeDescription(Ref As Contracts.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = ProfileController.Contact.Exist(Ref)
        Dim AccountModel As ProfileComponent.ContactsProject.Contracts.IModel = ProfileController.Contact.Exist(New ProfileComponent.ContactsProject.Contracts.Contracts With {.PrimaryKey = Val.Model.ToExternalID}).Model
        Console.Clear()
        Console.WriteLine("-------- Change description ----------")
        Info(Val.Model)
        Console.WriteLine("-------------------------------------")
        If Help.AccessChoice("Θέλεις να αλλάξεις Περιγραφη?") Then
            Dim Change As Contracts.IChangeDescriptionDTO = New Contracts.Contracts
            Console.WriteLine("Δώσε καινουργια Περιγραφή:")
            Change.Description = Console.ReadLine()
            Console.WriteLine(ProfileController.Contact.Change(Ref, Change).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub Remove(Ref As Contracts.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = ProfileController.Contact.Exist(Ref)
        Console.WriteLine("-------- Remove Relationship ---------")
        Info(Val.Model)
        Console.WriteLine("-------------------------------")
        If Help.AccessChoice("Θέλεις να διαγραψεις το Relationship?") Then
            Console.WriteLine(ProfileController.Contact.RemoveBothRelationship(Ref).Msg)
            Console.ReadLine()
        End If
    End Sub
    Sub ListOfFriend(Ref As ProfileComponent.Profile.Able.IReference, Optional SelecectChoice As Boolean = False, Optional ByRef ChoiceRef As ProfileComponent.Profile.Able.IReference = Nothing)
        Do
            Dim Val As MyBook.ValMsg(Of List(Of ProfileComponent.Model)) = ProfileController.Contact_AllowsFriend(Ref)
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

                    Console.WriteLine(Index & ") " & Model.PersonModel.FullName)
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

                        Dim Creteria As ProfileComponent.ContactsProject.Contracts.ICreteria = New ProfileComponent.ContactsProject.Contracts.Contracts
                        Creteria.ExternalID = Ref.PrimaryKey
                        Creteria.ToExternalID = Val.Model(Choice - 1).Profile.PrimaryKey

                        If SelecectChoice = True Then
                            ChoiceRef = Val.Model(Choice - 1).Profile
                            Exit Do
                        End If

                        Dim ValContact As ProfileComponent.ContactsProject.Contracts.IModel = ProfileController.Contact.Find(Creteria).Model
                        Menu(Ref, ValContact)
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
    Friend Function ChoiceRelationShipByAccount(Ref As ProfileComponent.Profile.Able.IReference, ByRef ChoiceRef As ProfileComponent.Profile.Able.IReference) As Boolean
        Do
            Console.Clear()
            Dim NotAllowsFriend As MyBook.ValMsg(Of List(Of ProfileComponent.Model)) = ProfileController.Contact_NotAllowsFriends(Ref)
            If NotAllowsFriend.Success = False Then

            End If



            While NotAllowsFriend.Model.Count = 0
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

            While NotAllowsFriend.Model.Count > 0
                Dim index As Integer = 0
                For Each ModelAfterResize In NotAllowsFriend.Model
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
                        ChoiceRef = NotAllowsFriend.Model(Choice - 1).Profile
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
    Public Sub Register(Ref As ProfileComponent.Profile.Able.IReference, Optional ThirdRef As ProfileComponent.Profile.Able.IReference = Nothing)
        Do While ThirdRef Is Nothing
            Dim RegisterDTO As Contracts.IRegisterDTO = New Contracts.Contracts
            Dim NewRef As ProfileComponent.Profile.Able.IReference = New ProfileComponent.Profile.Contracts.Contracts
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
                Console.WriteLine(ProfileController.Contact.RegisterBothRelationship(RegisterDTO).Msg)
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
            PersonModule.Info(ProfileController.Profile.Exist(ThirdRef).Model)
            Console.WriteLine("----------------------------------------")
            Help.IfNotInputOrMsg("Δώσε Description: ", RegisterDTO.Description)
            If Help.AccessChoice("Θέλεις να συνεχίσεις με την εγραφή: ") Then
                Console.WriteLine(ProfileController.Contact.RegisterBothRelationship(RegisterDTO).Msg)
                Console.ReadLine()
            End If
            Exit Do
        Loop
    End Sub
End Module
