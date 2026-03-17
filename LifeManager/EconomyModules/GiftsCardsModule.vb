Imports Economy.GiftsCard
Module GiftsCardsModule



    Friend Sub Info(Model As Contracs.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Number Card: " & Model.NumberCard)
        Console.WriteLine("Code: " & Model.Code)
        Console.WriteLine("Description: " & Model.Description)
    End Sub

    Friend Sub Menu(Ref As AccountComponent.Contracts.IReference, RefGifts As Economy.GiftsCard.Entity.IReference)
        Do
            Console.Clear()
            Dim ValMsg As MyBook.ValMsg(Of Contracs.Contracs) = EconomyController.GiftsService.Exist(RefGifts)

            If ValMsg.Success = False Then
                Console.WriteLine(ValMsg.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Console.WriteLine("-------- Gifts Cards ------")
            Info(ValMsg.Model)
            Console.WriteLine()
            Console.WriteLine("----- Menu -----")
            Console.WriteLine("1) Αναλυτική Εμφάνηση.")
            Console.WriteLine("2) Καταχώρηση Εγραφής.")
            Console.WriteLine("3) Change Name.")
            Console.WriteLine("4) Change Description.")
            Console.WriteLine("5) Remove Gifts Cards.")
            Console.WriteLine("6) Exit.")
            Console.WriteLine("-------------")
            Console.WriteLine()
            Console.WriteLine("Επέλεξε ενα απο το μενου: ")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    TransferModule.SearchMenu(Ref, "Gifts", RefGifts.PrimaryKey)
                Case 2
                    TransferModule.Register(Ref,"Gifts", RefGifts.PrimaryKey)
                Case 3
                    ChangeName(RefGifts)
                Case 4
                    ChangeDescription(RefGifts)
                Case 5
                    Remove(Ref, RefGifts)
                Case 6
                    Exit Do
            End Select
        Loop

    End Sub
    Friend Function CreateRegisterDTO() As MyBook.ValMsg(Of Economy.GiftsCard.Contracs.IRegisterDTO)
        Dim Result As New MyBook.ValMsg(Of Economy.GiftsCard.Contracs.IRegisterDTO)
        Dim RegisterDTO As Contracs.IRegisterDTO = New Contracs.Contracs
        Console.Clear()
        Console.WriteLine("---------- Register Bank Card -----------")
        Console.WriteLine("Δώσε ονομα Card: ")
        RegisterDTO.Name = Console.ReadLine
        Console.WriteLine("Δώσε όνομα Number Card: ")
        RegisterDTO.NumberCard = Console.ReadLine
        Console.WriteLine("Δώσε Code: ")
        RegisterDTO.Code = Console.ReadLine
        Console.WriteLine("Δώσε Περιγραφή:")
        RegisterDTO.Description = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις?") Then
            Result.Success = True
            Result.Msg = "Created a DTO"
            Result.Model = RegisterDTO
        Else
            Result.Success = False
            Result.Msg = "Failed to Create a DTO"
        End If
        Return Result
    End Function
    Friend Sub ChangeName(Ref As Economy.GiftsCard.Entity.IReference)
        Dim Val As MyBook.ValMsg(Of Contracs.Contracs) = EconomyController.GiftsService.Exist(Ref)
        If Val.Success = False Then
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Dim ChangeDTO As Contracs.IChangeNumberDTO = New Contracs.Contracs

        Console.Clear()
        Console.WriteLine("------------- Change Name Gift Card ----------------")
        Info(Val.Model)
        Console.WriteLine("-----------------------------------------------------")
        Console.WriteLine()

        If Help.AccessChoice("Θέλει να Αλλάξεις το Number Card?") Then
            Console.Clear()
            Console.WriteLine("Name: " & Val.Model.NumberCard)
            Console.WriteLine("Δώσε κανουργιο ονομα: ")
            ChangeDTO.NumberCard = Console.ReadLine
            Console.Clear()
            Console.WriteLine(EconomyController.BankCardsService.Change(Ref, ChangeDTO).Msg)
            Console.ReadLine()
            Exit Sub
        End If
    End Sub
    Friend Sub ChangeCode(Ref As Economy.GiftsCard.Entity.IReference)
        Dim Val As MyBook.ValMsg(Of Contracs.Contracs) = EconomyController.GiftsService.Exist(Ref)
        If Val.Success = False Then
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Dim ChangeDTO As Contracs.IChangeDescriptionDTO = New Contracs.Contracs

        Console.Clear()
        Console.WriteLine("------------- Change Gift Card Code ----------------")
        Info(Val.Model)
        Console.WriteLine("-----------------------------------------------------")
        Console.WriteLine()
        If Help.AccessChoice("Θέλει να Αλλάξεις Code?") Then
            Console.Clear()
            Console.WriteLine("Code: " & Val.Model.Code)
            Console.WriteLine("Δώσε κανουργιο Code: ")
            ChangeDTO.Description = Console.ReadLine
            Console.Clear()
            Console.WriteLine(EconomyController.BankCardsService.Change(Ref, ChangeDTO).Msg)
            Console.ReadLine()
            Exit Sub
        End If
    End Sub
    Friend Sub ChangeDescription(Ref As Economy.GiftsCard.Entity.IReference)
        Dim Val As MyBook.ValMsg(Of Contracs.Contracs) = EconomyController.GiftsService.Exist(Ref)
        If Val.Success = False Then
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Dim ChangeDTO As Contracs.IChangeDescriptionDTO = New Contracs.Contracs

        Console.Clear()
        Console.WriteLine("------------- Change Description Gift Card ----------------")
        Info(Val.Model)
        Console.WriteLine("-----------------------------------------------------")
        Console.WriteLine()
        If Help.AccessChoice("Θέλει να Αλλάξεις Description?") Then
            Console.Clear()
            Console.WriteLine("Description: " & Val.Model.Description)
            Console.WriteLine("Δώσε κανουργιο ονομα: ")
            ChangeDTO.Description = Console.ReadLine
            Console.Clear()
            Console.WriteLine(EconomyController.BankCardsService.Change(Ref, ChangeDTO).Msg)
            Console.ReadLine()
            Exit Sub
        End If
    End Sub
    Friend Sub Remove(Ref As AccountComponent.Contracts.IReference, RefBankCard As Economy.GiftsCard.Entity.IReference)
        Dim Val As MyBook.ValMsg(Of Contracs.Contracs) = EconomyController.GiftsService.Exist(RefBankCard)
        If Val.Success = False Then
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Console.Clear()
        Console.WriteLine("------------- Remove Gift Card ----------------")
        Info(Val.Model)
        Console.WriteLine("-----------------------------------------------------")
        Console.WriteLine()
        If Help.AccessChoice("Θέλεις να Διαγράψεις τον λογαριασμο ?") Then
            Console.Clear()
            Console.WriteLine(EconomyController.RemoveGiftsCard(Ref.PrimaryKey, RefBankCard).Msg)
            Console.ReadLine()
            Exit Sub
        End If
    End Sub
End Module



