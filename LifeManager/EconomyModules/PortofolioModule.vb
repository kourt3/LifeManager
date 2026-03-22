Imports MyBook
Imports Economy.Portofolio
Module PortofolioModule
    Friend Sub Info(Model As Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Name: " & Model.Name)
        Console.WriteLine("Description: " & Model.Description)

        Dim ValTransferController As MyBook.ValMsg(Of Economy.TransferController.IModelController) = TransferController.Model("Portofolio", Model.PrimaryKey)
        If ValTransferController.Model IsNot Nothing Then
            Console.WriteLine("Έσοδα: " & ValTransferController.Model.Esoda)
            Console.WriteLine("Έξοδα: " & ValTransferController.Model.Exoda)
            Console.WriteLine("Σύνολο: " & ValTransferController.Model.Sum)
        End If
    End Sub

    Friend Sub Menu(Ref As AccountComponent.Contracts.IReference, RefPortofolio As Economy.Portofolio.Entity.IReference)
        Do
            Console.Clear()
            Dim ValMsg As MyBook.ValMsg(Of Contracts.Contract) = EconomyController.PortofolioService.Exist(RefPortofolio)

            If ValMsg.Success = False Then
                Console.WriteLine(ValMsg.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Console.WriteLine("-------- Portofolio ------")
            Info(ValMsg.Model)
            Console.WriteLine()
            Console.WriteLine("----- Menu -----")
            Console.WriteLine("1) Αναλυτική Εμφάνηση.")
            Console.WriteLine("2) Καταχώρηση Εγραφής.")
            Console.WriteLine("3) Change Name.")
            Console.WriteLine("4) Change Description.")
            Console.WriteLine("5) Remove Portofolio.")
            Console.WriteLine("6) Exit.")
            Console.WriteLine("-------------")
            Console.WriteLine()
            Console.WriteLine("Επέλεξε ενα απο το μενου: ")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    TransferModule.SearchMenu(Ref, "Portofolio", RefPortofolio.PrimaryKey)
                Case 2
                    TransferModule.Register(Ref, "Portofolio", RefPortofolio.PrimaryKey)
                Case 3
                    ChangeName(RefPortofolio)
                Case 4
                    ChangeDescription(RefPortofolio)
                Case 5
                    Remove(Ref, RefPortofolio)
                Case 6
                    Exit Do
            End Select
        Loop

    End Sub
    Friend Function CreateRegisterDTO() As MyBook.ValMsg(Of Economy.Portofolio.Contracts.IRegisterDTO)
        Dim Result As New MyBook.ValMsg(Of Economy.Portofolio.Contracts.IRegisterDTO)
        Dim RegisterDTO As Contracts.IRegisterDTO = New Contracts.Contract
        Console.Clear()
        Console.WriteLine("---------- Register Portofolio -----------")
        Console.WriteLine("Δώσε όνομα πορτοφόλιο: ")
        RegisterDTO.Name = Console.ReadLine
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
    Friend Sub ChangeName(Ref As Economy.Portofolio.Entity.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contract) = EconomyController.PortofolioService.Exist(Ref)
        If Val.Success = False Then
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Dim ChangeDTO As Contracts.IChangeNameDTO = New Contracts.Contract

        Console.Clear()
        Console.WriteLine("------------- Change Name Portofolio ----------------")
        Info(Val.Model)
        Console.WriteLine("-----------------------------------------------------")
        Console.WriteLine()

        If Help.AccessChoice("Θέλει να Αλλάξεις το όνομα?") Then
            Console.Clear()
            Console.WriteLine("Name: " & Val.Model.Name)
            Console.WriteLine("Δώσε κανουργιο ονομα: ")
            ChangeDTO.Name = Console.ReadLine
            Console.Clear()
            Console.WriteLine(EconomyController.PortofolioService.Change(Ref, ChangeDTO).Msg)
            Console.ReadLine()
            Exit Sub
        End If
    End Sub
    Friend Sub ChangeDescription(Ref As Entity.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contract) = EconomyController.PortofolioService.Exist(Ref)
        If Val.Success = False Then
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Dim ChangeDTO As Contracts.IChangeDescriptionDTO = New Contracts.Contract

        Console.Clear()
        Console.WriteLine("------------- Change Description Portofolio ----------------")
        Info(Val.Model)
        Console.WriteLine("-----------------------------------------------------")
        Console.WriteLine()
        If Help.AccessChoice("Θέλει να Αλλάξεις Description?") Then
            Console.Clear()
            Console.WriteLine("Name: " & Val.Model.Name)
            Console.WriteLine("Δώσε κανουργιο ονομα: ")
            ChangeDTO.Description = Console.ReadLine
            Console.Clear()
            Console.WriteLine(EconomyController.PortofolioService.Change(Ref, ChangeDTO).Msg)
            Console.ReadLine()
            Exit Sub
        End If
    End Sub
    Friend Sub Remove(Ref As AccountComponent.Contracts.IReference, RefPortofolio As Entity.IReference)
        Dim Val As MyBook.ValMsg(Of Contracts.Contract) = EconomyController.PortofolioService.Exist(RefPortofolio)
        If Val.Success = False Then
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Console.Clear()
        Console.WriteLine("------------- Remove Portofolio ----------------")
        Info(Val.Model)
        Console.WriteLine("-----------------------------------------------------")
        Console.WriteLine()
        If Help.AccessChoice("Θέλεις να Διαγράψεις τον λογαριασμο ?") Then
            Console.Clear()
            Console.WriteLine(EconomyController.RemovePortofolio(Ref.PrimaryKey, RefPortofolio).Msg)
            Console.ReadLine()
            Exit Sub
        End If
    End Sub
End Module
