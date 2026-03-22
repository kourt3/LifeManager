Imports System.Reflection

Namespace Controller
    Public Interface IModel

        Property Portofolies As List(Of Portofolio.Contracts.IModel)
        Property BankCards As List(Of BankCardsProject.Contracts.IModel)
        Property Gifts As List(Of GiftsCard.Contracs.IModel)


    End Interface
    Public Class Model
        Implements IModel


        Public Property Portofolies As List(Of Portofolio.Contracts.IModel) Implements IModel.Portofolies
        Public Property BankCards As List(Of BankCardsProject.Contracts.IModel) Implements IModel.BankCards
        Public Property Gifts As List(Of GiftsCard.Contracs.IModel) Implements IModel.Gifts


        Sub New()
            Portofolies = New List(Of Portofolio.Contracts.IModel)
            BankCards = New List(Of BankCardsProject.Contracts.IModel)
            Gifts = New List(Of GiftsCard.Contracs.IModel)

        End Sub

    End Class

    Public Class Controller(Of TExternalRef As MyBook.IHasPrimaryKey(Of Int32))

        Public Base

        Public EconomyService As EconomyProject.Services.Service
        Public PortofolioService As Portofolio.Service.PortofolioService
        Public BankCardsService As BankCardsProject.Service.Services
        Public GiftsService As GiftsCard.Services.Services

        Sub New(EconomyLink As EconomyProject.Services.Service, PortofolioServiceLink As Portofolio.Service.PortofolioService, BankCardServiceLink As BankCardsProject.Service.Services, GiftsCardServiceLink As GiftsCard.Services.Services)

            EconomyService = EconomyLink
            PortofolioService = PortofolioServiceLink
            BankCardsService = BankCardServiceLink
            GiftsService = GiftsCardServiceLink
        End Sub
        Sub New()
            EconomyService = New EconomyProject.Services.Service
            PortofolioService = New Portofolio.Service.PortofolioService
            BankCardsService = New BankCardsProject.Service.Services
            GiftsService = New GiftsCard.Services.Services
        End Sub

        Function Model(ExternalId As Integer) As MyBook.ValMsg(Of IModel)
            Dim Result As New MyBook.ValMsg(Of IModel)
            Dim Creteria As Economy.EconomyProject.Contracts.ICreteria = New EconomyProject.Contracts.Contact
            Creteria.ExternalID = ExternalId
            Dim EconomyVal As MyBook.ValMsg(Of List(Of Economy.EconomyProject.Contracts.IModel)) = EconomyService.Search(Creteria)

            If EconomyVal.Model IsNot Nothing Then
                Result.Model = New Model
                For Each EconomyModel In EconomyVal.Model
                    If EconomyModel.Category = "Portofolio" Then
                        Dim PortofolioVal As MyBook.ValMsg(Of Economy.Portofolio.Contracts.Contract) = PortofolioService.Exist(New Portofolio.Contracts.Contract With {.PrimaryKey = EconomyModel.ToExternalID})
                        If PortofolioVal.Success = True Then
                            Result.Model.Portofolies.Add(PortofolioVal.Model)
                        End If
                    ElseIf EconomyModel.Category = "BankCard" Then
                        Dim BankCardVal As MyBook.ValMsg(Of Economy.BankCardsProject.Contracts.Contracts) = BankCardsService.Exist(New BankCardsProject.Contracts.Contracts With {.PrimaryKey = EconomyModel.ToExternalID})
                        If BankCardVal.Success = True Then

                            Result.Model.BankCards.Add(BankCardVal.Model)
                        End If
                    ElseIf EconomyModel.Category = "GiftCards" Then
                        Dim GiftsCardVal As MyBook.ValMsg(Of Economy.GiftsCard.Contracs.Contracs) = GiftsService.Exist(New GiftsCard.Contracs.Contracs With {.PrimaryKey = EconomyModel.ToExternalID})
                        If GiftsCardVal.Success = True Then
                            Result.Model.Gifts.Add(GiftsCardVal.Model)
                        End If
                    End If
                Next
                Result.Success = True
                Result.Msg = "Βρέθηκαν Εγραφές!"
            Else
                Result.Success = False
                Result.Msg = "Δεν Βρέθηκαν Εγραφές!"
            End If



            Return Result
        End Function

        Function AddPortofolio(ExternalId As TExternalRef, RegisterPortofolio As Portofolio.Contracts.IRegisterDTO) As MyBook.ValMsg(Of IModel)
            Dim Result As New MyBook.ValMsg(Of IModel)


            Dim PortofolioVal As MyBook.ValMsg(Of Portofolio.Contracts.Contract) = PortofolioService.Register(RegisterPortofolio)
            If PortofolioVal.Success = False Then
                Result.Msg = PortofolioVal.Msg
                Result.Success = PortofolioVal.Success
                Result.Model = Model(ExternalId.PrimaryKey).Model
                Return Result
            End If

            Dim EconomyRegisterDTO As EconomyProject.Contracts.IRegisterDTO = New EconomyProject.Contracts.Contact
            EconomyRegisterDTO.ExternalID = ExternalId.PrimaryKey
            EconomyRegisterDTO.ToExternalID = PortofolioVal.Model.PrimaryKey
            EconomyRegisterDTO.Category = "Portofolio"

            Dim EconomyVal As MyBook.ValMsg(Of EconomyProject.Contracts.Contact) = EconomyService.Register(EconomyRegisterDTO)
            Result.Msg = EconomyVal.Msg
            Result.Success = EconomyVal.Success
            Result.Model = Model(ExternalId.PrimaryKey).Model

            Return Result
        End Function

        Function AddBankCard(ExternalId As Integer, RegisterBankCard As BankCardsProject.Contracts.IRegisterDTO) As MyBook.ValMsg(Of IModel)

            Dim EconomyRegisterDTO As EconomyProject.Contracts.IRegisterDTO = New EconomyProject.Contracts.Contact
            Dim PortofolioVal As MyBook.ValMsg(Of BankCardsProject.Contracts.Contracts) = BankCardsService.Register(RegisterBankCard)
            EconomyRegisterDTO.ExternalID = ExternalId
            EconomyRegisterDTO.ToExternalID = PortofolioVal.Model.PrimaryKey
            EconomyRegisterDTO.Category = "BankCard"
            Dim EconomyVal As MyBook.ValMsg(Of EconomyProject.Contracts.Contact) = EconomyService.Register(EconomyRegisterDTO)
            Return Model(ExternalId)
        End Function

        Function AddGiftsCard(ExternalId As Integer, RegisterGiftsCard As GiftsCard.Contracs.IRegisterDTO) As MyBook.ValMsg(Of IModel)

            Dim EconomyRegisterDTO As EconomyProject.Contracts.IRegisterDTO = New EconomyProject.Contracts.Contact
            Dim PortofolioVal As MyBook.ValMsg(Of GiftsCard.Contracs.Contracs) = GiftsService.Register(RegisterGiftsCard)
            EconomyRegisterDTO.ExternalID = ExternalId
            EconomyRegisterDTO.ToExternalID = PortofolioVal.Model.PrimaryKey
            EconomyRegisterDTO.Category = "GiftCards"
            Dim EconomyVal As MyBook.ValMsg(Of EconomyProject.Contracts.Contact) = EconomyService.Register(EconomyRegisterDTO)
            Return Model(ExternalId)
        End Function

        Function RemovePortofolio(ExternalID As Integer, RefPortofolio As Portofolio.Entity.IReference) As MyBook.ValMsg(Of IModel)
            Dim EconomyCreteria As EconomyProject.Contracts.ICreteria = New EconomyProject.Contracts.Contact
            EconomyCreteria.ExternalID = ExternalID
            EconomyCreteria.ToExternalID = RefPortofolio.PrimaryKey
            EconomyCreteria.Category = "Portofolio"

            Dim ValEconomy As MyBook.ValMsg(Of EconomyProject.Contracts.IModel) = EconomyService.Find(EconomyCreteria)
            If ValEconomy.Success = True Then
                PortofolioService.Remove(RefPortofolio)
                EconomyService.Remove(ValEconomy.Model)
            End If

            Return Model(ExternalID)
        End Function
        Function RemoveBankCard(ExternalID As Integer, RefBankCard As BankCardsProject.My.Entity.IReference) As MyBook.ValMsg(Of IModel)
            Dim EconomyCreteria As EconomyProject.Contracts.ICreteria = New EconomyProject.Contracts.Contact
            EconomyCreteria.ExternalID = ExternalID
            EconomyCreteria.ToExternalID = RefBankCard.PrimaryKey
            EconomyCreteria.Category = "BankCard"

            Dim ValEconomy As MyBook.ValMsg(Of EconomyProject.Contracts.IModel) = EconomyService.Find(EconomyCreteria)
            If ValEconomy.Success = True Then
                BankCardsService.Remove(RefBankCard)
                EconomyService.Remove(ValEconomy.Model)
            End If

            Return Model(ExternalID)
        End Function
        Function RemoveGiftsCard(ExternalID As Integer, RefGiftsCard As GiftsCard.Entity.IReference) As MyBook.ValMsg(Of IModel)
            Dim EconomyCreteria As EconomyProject.Contracts.ICreteria = New EconomyProject.Contracts.Contact
            EconomyCreteria.ExternalID = ExternalID
            EconomyCreteria.ToExternalID = RefGiftsCard.PrimaryKey
            EconomyCreteria.Category = "GiftsCard"

            Dim ValEconomy As MyBook.ValMsg(Of EconomyProject.Contracts.IModel) = EconomyService.Find(EconomyCreteria)
            If ValEconomy.Success = True Then
                GiftsService.Remove(RefGiftsCard)
                EconomyService.Remove(ValEconomy.Model)
            End If

            Return Model(ExternalID)
        End Function
    End Class
End Namespace


