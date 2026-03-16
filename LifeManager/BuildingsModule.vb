Imports Buildings
Friend Module BuildingsModule
    Friend Sub Info(Model As Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Addresess:" & Model.Addresess)
        Console.WriteLine("Lenght: " & Model.Lenght)
        Console.WriteLine("Width: " & Model.Width)
        Console.WriteLine("Description: " & Model.Description)
    End Sub
    Friend Sub Menu(Ref As Contracts.IReference, MyRef As AccountComponent.Contracts.IReference, Optional ThirdRef As AccountComponent.Contracts.IReference = Nothing)
        Do
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Buildings.Exist(Ref)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Console.WriteLine("---------- Menu Build -------------")
            Info(Val.Model)
            Console.WriteLine("------------------------------------")
            Console.WriteLine()
            Console.WriteLine("------ Menu ------")
            Console.WriteLine("1) Apartments.")
            Console.WriteLine("2) Change Addresess.")
            Console.WriteLine("3) Change Description.")
            Console.WriteLine("4) Change Squard Meter.")
            Console.WriteLine("5) Exit.")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    ApartmentModule.ListOfApartment(Ref, MyRef, ThirdRef)
                Case 2
                    ChangeAdressess(Ref)
                Case 3
                    ChangeDescription(Ref)
                Case 4
                    ChangeSquardMeter(Ref)
                Case 5
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Friend Sub Register()
        Dim DTO As Contracts.IRegisterDTO = New Contracts.Contracts
        Do
            Console.Clear()
            Console.WriteLine("--------- Register Building -----------")
            If Not Help.IfNotInputOrMsg("Δώσε Διευθηνση: ", DTO.Addresess) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δώσε Μήκος: ", DTO.Lenght) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δώσε Πλάτος: ", DTO.Width) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δώσε Περιγραφή: ", DTO.Description) Then
                Continue Do
            End If

            If Help.AccessChoice("Θέλεις να Συνεχίσεις?") Then
                Console.WriteLine(Buildings.Register(DTO).Msg)
                Console.ReadLine()
                Exit Do
            End If
            Exit Do
        Loop
    End Sub
    Friend Sub ChangeAdressess(Ref As Contracts.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Buildings.Exist(Ref)
        Console.WriteLine("----------- Change Addresess --------")
        Info(Val.Model)
        Console.WriteLine("--------------------------------------")

        If Help.AccessChoice("Θέλεις να αλλάξεις Διευθηνση?") Then
            Dim DTO As Contracts.IChangeAddressesDTO = New Contracts.Contracts
            Console.WriteLine("Δώσε Διευθηνση: ")
            DTO.Addresess = Console.ReadLine
            Console.Clear()
            Console.WriteLine(Buildings.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If


    End Sub
    Friend Sub ChangeDescription(Ref As Contracts.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Buildings.Exist(Ref)
        Console.WriteLine("----------- Change Description --------")
        Info(Val.Model)
        Console.WriteLine("--------------------------------------")
        Console.Clear()

        If Help.AccessChoice("Θέλεις να αλλάξεις Description?") Then
            Dim DTO As Contracts.IChangeDescriptionDTO = New Contracts.Contracts
            Console.WriteLine("Δώσε Description: ")
            DTO.Description = Console.ReadLine
            Console.Clear()
            Console.WriteLine(Buildings.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub ChangeSquardMeter(Ref As Contracts.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Buildings.Exist(Ref)
        Console.WriteLine("----------- Change Meter --------")
        Info(Val.Model)
        Console.WriteLine("--------------------------------------")
        Console.Clear()

        If Help.AccessChoice("Θέλεις να αλλάξεις Meter?") Then
            Dim DTO As Contracts.IChangeSquardMeter = New Contracts.Contracts
            Console.WriteLine("Δώσε Length: ")
            DTO.Lenght = Console.ReadLine
            Console.WriteLine("Δώσε Width: ")
            DTO.Width = Console.ReadLine
            Console.Clear()
            Console.WriteLine(Buildings.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub Remove(Ref As Contracts.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Buildings.Exist(Ref)
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Console.WriteLine("-------- Remove Build ---------")
        Info(Val.Model)
        If Help.AccessChoice("Θέλεις να Διαγράψεις το Build?") Then
            Console.WriteLine(Buildings.Remove(Ref).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub ListOfBuild(Myref As AccountComponent.Contracts.IReference, Optional Thirdref As AccountComponent.Contracts.IReference = Nothing, Optional Choice As Boolean = False, Optional ByRef Ref As Contracts.IReference = Nothing)
        Do

            Dim Val As MyBook.ValMsg(Of List(Of Contracts.Contracts)) = Buildings.Get_All
            Console.Clear()
            Console.WriteLine("------------- List of Buildings -------------")
            While Val.Success = False
                Console.WriteLine(Val.Msg)
                Console.WriteLine("------------------------------------")
                Console.WriteLine("1) Add Building")
                Console.WriteLine("2) Exit.")
                Dim Str As String = Console.ReadLine
                Select Case Str
                    Case 1
                        Register()
                        Continue Do
                    Case 2
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While

            While Val.Success = True
                Dim Index As Integer = 0
                For Each Entity In Val.Model
                    Index += 1
                    Console.WriteLine(Index & ") " & Entity.Addresess & " | " & Entity.Description)
                Next
                Console.WriteLine("------------ Menu -----------")
                Console.WriteLine(1 & "-" & Index & ") Open Building.")
                Console.WriteLine(Index + 1 & ") Add Building.")
                Console.WriteLine(Index + 2 & ") Exit.")
                Dim Str As String = Console.ReadLine - 1
                Select Case Str
                    Case 0 To Index - 1
                        If Choice = False Then
                            Menu(Val.Model(Int(Str)), Myref, Thirdref)
                            Continue Do
                        Else
                            Ref = Val.Model(Int(Str))
                            Exit Do
                        End If

                    Case Index
                        Register()
                        Continue Do
                    Case Index + 1
                        Exit Do
                    Case Else
                        Continue While
                End Select
            End While

        Loop
    End Sub
End Module