Imports Apartment
Module ApartmentModule
    Friend Sub Info(Model As Apartment.Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Build ID: " & Model.BuildID)
        Console.WriteLine("Orofos: " & Model.Orofos)
        Console.WriteLine("Lenght: " & Model.Lenght)
        Console.WriteLine("Width: " & Model.Width)
        Console.WriteLine("Koudouni: " & Model.Koudouni)
        Console.WriteLine("Diamerisma: " & Model.Diamenrisma)
        Console.WriteLine("Description: " & Model.Description)
    End Sub
    Friend Sub Menu(Ref As Apartment.Contracts.IReference, MyRef As AccountComponent.Contracts.IReference, Optional ThirdRef As Contracts.IReference = Nothing)
        While True
            Console.Clear()
            Dim Val As MyBook.ValMsg(Of Apartment.Contracts.Contracts) = Apartnment.Exist(Ref)
            If Val.Success = False Then
                Console.WriteLine(Val.Msg)
                Console.ReadLine()
                Exit Sub
            End If

            Console.WriteLine("----------- Info: Apartment --------------")
            Info(Val.Model)
            Console.WriteLine("------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("--------- Menu ------------")
            Console.WriteLine("1) Cohabrition.")
            Console.WriteLine("2) Change Orofos.")
            Console.WriteLine("3) Chanhe Τετραγωνικα μετρα.")
            Console.WriteLine("4) Koudouni.")
            Console.WriteLine("5) Diamerisma.")
            Console.WriteLine("6) Description.")
            Console.WriteLine("7) Remove.")
            Console.WriteLine("8) Exit.")
            Console.WriteLine("--------------------------")
            Console.WriteLine("Επέλεξε:")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    CohrabitionModule.ListOfCohrabition(Ref, MyRef, ThirdRef)
                Case 2
                    ChangeOrofos(Ref)
                Case 3
                    ChangeTM(Ref)
                Case 4
                    ChangeKoudouni(Ref)
                Case 5
                    ChangeDiamerisma(Ref)
                Case 6
                    ChangeDescription(Ref)
                Case 7
                    Remove(Ref)
                Case 8
                    Exit Sub
                Case Else
                    Continue While
            End Select
        End While
    End Sub

    Friend Sub ListOfApartment(Ref As Buildings.Contracts.IReference, Myref As AccountComponent.Contracts.IReference, Optional ThirdRef As AccountComponent.Contracts.IReference = Nothing, Optional Choice As Boolean = False, Optional ByRef ApartmentRef As Contracts.IReference = Nothing)
        Do
            Dim Val As MyBook.ValMsg(Of List(Of Contracts.IModel)) = Apartnment.SearchByExternalID(Ref.PrimaryKey)
            Console.Clear()
            Console.WriteLine("--------- List Of Apartment -----------")

            While Val.Success = False
                Console.WriteLine(Val.Msg)
                Console.WriteLine("--------- Menu --------")
                Console.WriteLine("1) Register.")
                Console.WriteLine("2) Exit.")
                Console.WriteLine("---------------------")
                Console.WriteLine("Επέλεξε: ")
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
                Dim Index As Integer = 0
                For Each Entity In Val.Model
                    Index += 1
                    Console.WriteLine(Index & ") " & Entity.BuildID & " | " & Entity.Orofos & " | " & Entity.Diamenrisma & " | " & Entity.Koudouni & " | " &
                                      Entity.Lenght & " | " & Entity.Width & "|" & Entity.Description)
                Next
                Console.WriteLine(Index + 1 & ") Register.")
                Console.WriteLine(Index + 2 & ") Exit.")
                Dim Str As String = Console.ReadLine - 1
                Select Case Str
                    Case 0 To Index - 1
                        If Choice = False Then
                            Menu(Val.Model(Int(Str)), Myref)
                            Continue Do
                        Else
                            ApartmentRef = Val.Model(Int(Str))
                            Exit Sub
                        End If

                    Case Index
                        Register(Ref)
                        Continue Do
                    Case Index + 1
                        Exit Do
                    Case Else
                        Continue While
                End Select

            End While

        Loop
    End Sub
    Friend Sub Register(Ref As Buildings.Contracts.IReference)
        Dim RegisterDTO As Contracts.IRegisterDTO = New Contracts.Contracts
        Do
            Console.Clear()
            Console.WriteLine("--------- Register Apartment ---------")

            If Not Help.IfNotInputOrMsg("Δώσε όροφο:", RegisterDTO.Orofos) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δώσε Κουδουνι:", RegisterDTO.Koudouni) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δώσε Διαμερισμα:", RegisterDTO.Diamenrisma) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δωσε Μήκος:", RegisterDTO.Lenght) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δώσε Πλάτος:", RegisterDTO.Width) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("Δώσε Περιγραφη:", RegisterDTO.Description) Then
                Continue Do
            End If

            RegisterDTO.BuildID = Ref.PrimaryKey

            If Help.AccessChoice("Θέλετε να συνεχίσετε?") Then
                Console.WriteLine(Apartnment.Register(RegisterDTO).Msg)
                Console.ReadLine()
                Exit Do
            End If
            Exit Do
        Loop
    End Sub
    Friend Sub ChangeOrofos(Ref As Apartment.Contracts.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Apartnment.Exist(Ref)
        Console.Clear()
        Console.WriteLine("------------- Change Floor ---------------")
        Info(Val.Model)
        Console.WriteLine("------------------------------------------")
        If Help.AccessChoice("Θέλετε να αλλαξετε τον όροφο?") Then
            Dim DTO As Contracts.IChangeOrofos = New Contracts.Contracts
            Console.WriteLine("Δώσε τον καινουργιο οροφο: ")
            DTO.Orofos = Console.ReadLine
            Console.WriteLine(Apartnment.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub ChangeTM(Ref As Apartment.Contracts.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Apartnment.Exist(Ref)
        Console.Clear()
        Console.WriteLine("------------- Change Τμ ---------------")
        Info(Val.Model)
        Console.WriteLine("------------------------------------------")
        If Help.AccessChoice("Θέλετε να αλλαξετε τα Τετραφωνικά Μέτρα?") Then
            Dim DTO As Contracts.IChangeLenght = New Contracts.Contracts
            Console.WriteLine("Δώσε τον καινουργιο Μήκος: ")
            DTO.Lenght = Console.ReadLine
            Console.WriteLine("Δώσε τον καινουργιο Πλάτος: ")
            DTO.Width = Console.ReadLine
            Console.WriteLine(Apartnment.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub ChangeKoudouni(Ref As Apartment.Contracts.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Apartnment.Exist(Ref)
        Console.Clear()
        Console.WriteLine("------------- Change κουδούνι ---------------")
        Info(Val.Model)
        Console.WriteLine("------------------------------------------")
        If Help.AccessChoice("Θέλετε να αλλαξετε το κουδουνι?") Then
            Dim DTO As Contracts.IChangeKoudouni = New Contracts.Contracts
            Console.WriteLine("Δώσε το καινουργιο Κουδουνι: ")
            DTO.Koudouni = Console.ReadLine
            Console.WriteLine(Apartnment.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub ChangeDiamerisma(Ref As Apartment.Contracts.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Apartnment.Exist(Ref)
        Console.Clear()
        Console.WriteLine("------------- Change Διαμερισμα ---------------")
        Info(Val.Model)
        Console.WriteLine("------------------------------------------")
        If Help.AccessChoice("Θέλετε να αλλαξετε το διαμερισμα?") Then
            Dim DTO As Contracts.IChangeDiamerisma = New Contracts.Contracts
            Console.WriteLine("Δώσε τον καινουργιο Διαμερισμα: ")
            DTO.Diamenrisma = Console.ReadLine
            Console.WriteLine(Apartnment.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub ChangeDescription(Ref As Apartment.Contracts.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Apartnment.Exist(Ref)
        Console.Clear()
        Console.WriteLine("------------- Change Περιγραφή ---------------")
        Info(Val.Model)
        Console.WriteLine("------------------------------------------")
        If Help.AccessChoice("Θέλετε να αλλαξετε την Περιγραφή?") Then
            Dim DTO As Contracts.IChangeDescription = New Contracts.Contracts
            Console.WriteLine("Δώσε καινουργια περιγραφή: ")
            DTO.Description = Console.ReadLine
            Console.WriteLine(Apartnment.Change(Ref, DTO).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub Remove(Ref As Apartment.Contracts.IReference)
        Console.Clear()
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Apartnment.Exist(Ref)
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Console.WriteLine("--------- Remove Apartment -------")
        Info(Val.Model)
        Console.WriteLine("----------------------------------")
        If Help.AccessChoice("Θέλει να διαγράψεις; ") Then
            Console.WriteLine(Apartnment.Remove(Ref).Msg)
            Console.ReadLine()
        End If
    End Sub
End Module
