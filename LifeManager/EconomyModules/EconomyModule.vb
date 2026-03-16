Imports Economy

Module EconomyModule
    Friend Sub Info(Model As Economy.Controller.IModel)
        If Model.Portofolies IsNot Nothing Then Console.WriteLine("Portofolies: " & Model.Portofolies.Count)
        If Model.BankCards IsNot Nothing Then Console.WriteLine("Bank Cards: " & Model.BankCards.Count)
        If Model.Gifts IsNot Nothing Then Console.WriteLine("Gifts Cards: " & Model.Gifts.Count)
    End Sub
    Friend Sub Menu(Ref As AccountComponent.Contracts.IReference)
        Do
            Console.Clear()
            Dim ValEconomy As MyBook.ValMsg(Of Controller.IModel) = EconomyController.Model(Ref.PrimaryKey)



            Console.WriteLine("------------- Economy -------------")
            If ValEconomy.Success = False Then
                Console.WriteLine(ValEconomy.Msg)
            Else
                Info(ValEconomy.Model)
            End If
            Console.WriteLine("------------------------------------")
            Console.WriteLine()
            Console.WriteLine("------------ Menu -------------")
            Console.WriteLine("1) Πορτοφόλια.")
            Console.WriteLine("2) Bank Cards.")
            Console.WriteLine("3) Gifts Cards.")
            Console.WriteLine("4) Exit.")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    ListOfPortofolio(Ref)
                Case 2
                    ListOfBanksCards(Ref)
                Case 3
                    ListOfGiftsCards(Ref)
                Case 4
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub

    Friend Sub ListOfPortofolio(Ref As AccountComponent.Contracts.IReference, Optional Choice As Boolean = False, Optional ChoiceRef As Portofolio.Entity.IReference = Nothing)
        Do

            Dim Val As MyBook.ValMsg(Of Controller.IModel) = EconomyController.Model(Ref.PrimaryKey)

            While Val.Model IsNot Nothing AndAlso Val.Model.Portofolies.Count > 0
                Console.Clear()
                Console.WriteLine("---------- Economy: List Of Portofolies ---------------")
                For i = 0 To Val.Model.Portofolies.Count - 1
                    Console.WriteLine(i + 1 & ") " & Val.Model.Portofolies(i).Name & " " & Val.Model.Portofolies(i).Description)
                Next
                Console.WriteLine("-----------------------------------")
                Console.WriteLine(1 & "-" & Val.Model.Portofolies.Count & ") Open Portofolio.")
                Console.WriteLine(Val.Model.Portofolies.Count + 1 & ") Add Portofolio.")
                Console.WriteLine(Val.Model.Portofolies.Count + 2 & ") Exit.")
                Console.WriteLine("------------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Menu:")
                Dim Str As String = Console.ReadLine - 1
                Select Case Str
                    Case 0 To Val.Model.Portofolies.Count - 1
                        PortofolioModule.Menu(Ref, Val.Model.Portofolies(Str))
                        Continue Do
                    Case Val.Model.Portofolies.Count
                        Dim RegisterDTO As MyBook.ValMsg(Of Economy.Portofolio.Contracts.IRegisterDTO) = PortofolioModule.CreateRegisterDTO
                        If RegisterDTO.Success Then
                            Dim ValController As MyBook.ValMsg(Of Economy.Controller.IModel) = EconomyController.AddPortofolio(Ref, RegisterDTO.Model)
                            Console.WriteLine(ValController.Msg)
                            Console.ReadLine()
                            Exit While
                        End If
                    Case Val.Model.Portofolies.Count + 1
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End While

            While Val.Model Is Nothing OrElse Val.Model.Portofolies.Count = 0
                Console.Clear()
                Console.WriteLine("---------- Economy: List Of Portofolies ---------------")
                Console.WriteLine(1 & ") Add Portofolio.")
                Console.WriteLine(2 & ") Exit.")
                Console.WriteLine("------------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Menu:")
                Dim Str As String = Console.ReadLine
                Select Case Str
                    Case 1
                        Dim RegisterDTO As MyBook.ValMsg(Of Economy.Portofolio.Contracts.IRegisterDTO) = PortofolioModule.CreateRegisterDTO
                        If RegisterDTO.Success Then
                            Dim ValController As MyBook.ValMsg(Of Economy.Controller.IModel) = EconomyController.AddPortofolio(Ref, RegisterDTO.Model)
                            Console.WriteLine(ValController.Msg)
                            Console.ReadLine()
                            Continue Do
                        End If

                    Case 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End While


        Loop
    End Sub

    Friend Sub ListOfBanksCards(Ref As AccountComponent.Contracts.IReference, Optional Choice As Boolean = False, Optional ChoiceRef As BankCardsProject.My.Entity.IReference = Nothing)
        Do

            Dim Val As MyBook.ValMsg(Of Controller.IModel) = EconomyController.Model(Ref.PrimaryKey)

            While Val.Model IsNot Nothing AndAlso Val.Model.BankCards.Count > 0
                Console.Clear()
                Console.WriteLine("---------- Economy: List Of Banks Cards ---------------")
                For i = 0 To Val.Model.BankCards.Count - 1
                    Console.WriteLine(i + 1 & ") " & Val.Model.BankCards(i).NumberCard & " " & Val.Model.BankCards(i).Description)
                Next
                Console.WriteLine("-----------------------------------")
                Console.WriteLine(1 & "-" & Val.Model.BankCards.Count & ") Open Bank Card.")
                Console.WriteLine(Val.Model.BankCards.Count + 1 & ") Add Bank Card.")
                Console.WriteLine(Val.Model.BankCards.Count + 2 & ") Exit.")
                Console.WriteLine("------------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Menu:")
                Dim Str As String = Console.ReadLine - 1
                Select Case Str
                    Case 0 To Val.Model.BankCards.Count - 1
                        BankCardsModule.Menu(Ref, Val.Model.BankCards(Str))
                        Continue Do
                    Case Val.Model.BankCards.Count
                        Dim RegisterDTO As MyBook.ValMsg(Of Economy.BankCardsProject.Contracts.IRegisterDTO) = BankCardsModule.CreateRegisterDTO
                        If RegisterDTO.Success Then
                            Dim ValController As MyBook.ValMsg(Of Economy.Controller.IModel) = EconomyController.AddBankCard(Ref.PrimaryKey, RegisterDTO.Model)
                            Console.WriteLine(ValController.Msg)
                            Console.ReadLine()
                            Exit While
                        End If
                    Case Val.Model.BankCards.Count + 1
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End While

            While Val.Model Is Nothing OrElse Val.Model.BankCards.Count = 0
                Console.Clear()
                Console.WriteLine("---------- Economy: List Of Banks Cards ---------------")
                Console.WriteLine(1 & ") Add Bank Card.")
                Console.WriteLine(2 & ") Exit.")
                Console.WriteLine("------------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Menu:")
                Dim Str As String = Console.ReadLine
                Select Case Str
                    Case 1
                        Dim RegisterDTO As MyBook.ValMsg(Of Economy.BankCardsProject.Contracts.IRegisterDTO) = BankCardsModule.CreateRegisterDTO
                        If RegisterDTO.Success Then
                            Dim ValController As MyBook.ValMsg(Of Economy.Controller.IModel) = EconomyController.AddBankCard(Ref.PrimaryKey, RegisterDTO.Model)
                            Console.WriteLine(ValController.Msg)
                            Console.ReadLine()
                            Continue Do
                        End If

                    Case 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End While


        Loop
    End Sub

    Friend Sub ListOfGiftsCards(Ref As AccountComponent.Contracts.IReference, Optional Choice As Boolean = False, Optional ChoiceRef As GiftsCard.Entity.IReference = Nothing)
        Do

            Dim Val As MyBook.ValMsg(Of Controller.IModel) = EconomyController.Model(Ref.PrimaryKey)

            While Val.Model IsNot Nothing AndAlso Val.Model.Gifts.Count > 0
                Console.Clear()
                Console.WriteLine("---------- Economy: List Of Gift Cards ---------------")
                For i = 0 To Val.Model.Gifts.Count - 1
                    Console.WriteLine(i + 1 & ") " & Val.Model.Gifts(i).NumberCard & " " & Val.Model.Gifts(i).Description)
                Next
                Console.WriteLine("-----------------------------------")
                Console.WriteLine(1 & "-" & Val.Model.Gifts.Count & ") Open Gift Card.")
                Console.WriteLine(Val.Model.Gifts.Count + 1 & ") Add Gift Card.")
                Console.WriteLine(Val.Model.Gifts.Count + 2 & ") Exit.")
                Console.WriteLine("------------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Menu:")
                Dim Str As String = Console.ReadLine - 1
                Select Case Str
                    Case 0 To Val.Model.Gifts.Count - 1
                        GiftsCardsModule.Menu(Ref, Val.Model.Gifts(Str))
                        Continue Do
                    Case Val.Model.Gifts.Count
                        Dim RegisterDTO As MyBook.ValMsg(Of Economy.GiftsCard.Contracs.IRegisterDTO) = GiftsCardsModule.CreateRegisterDTO
                        If RegisterDTO.Success Then
                            Dim ValController As MyBook.ValMsg(Of Economy.Controller.IModel) = EconomyController.AddGiftsCard(Ref.PrimaryKey, RegisterDTO.Model)
                            Console.WriteLine(ValController.Msg)
                            Console.ReadLine()
                            Exit While
                        End If
                    Case Val.Model.Gifts.Count + 1
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End While

            While Val.Model Is Nothing OrElse Val.Model.Gifts.Count = 0
                Console.Clear()
                Console.WriteLine("---------- Economy: List Of Gift Cards ---------------")
                Console.WriteLine(1 & ") Add Gift Card.")
                Console.WriteLine(2 & ") Exit.")
                Console.WriteLine("------------------------------------")
                Console.WriteLine("Επέλεξε ενα απο το Menu:")
                Dim Str As String = Console.ReadLine
                Select Case Str
                    Case 1
                        Dim RegisterDTO As MyBook.ValMsg(Of Economy.GiftsCard.Contracs.IRegisterDTO) = GiftsCardsModule.CreateRegisterDTO
                        If RegisterDTO.Success Then
                            Dim ValController As MyBook.ValMsg(Of Economy.Controller.IModel) = EconomyController.AddGiftsCard(Ref.PrimaryKey, RegisterDTO.Model)
                            Console.WriteLine(ValController.Msg)
                            Console.ReadLine()
                            Continue Do
                        End If

                    Case 2
                        Exit Sub
                    Case Else
                        Continue Do
                End Select
            End While


        Loop
    End Sub
End Module
