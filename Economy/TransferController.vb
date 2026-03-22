Imports Economy.TransferProject
Public Class TransferController
    Public Class IModelController
        Dim ExternalId As Integer
        Dim Model As List(Of Contracts.IModel)
        ReadOnly Property Esoda As Double
            Get
                Dim Posa As Double = 0
                For Each Models In Model
                    If Models.ToPartEconomyID = ExternalId Then
                        Posa += Models.MoneyValue
                    End If
                Next
                Return Posa
            End Get
        End Property
        ReadOnly Property Exoda As Double
            Get
                Dim Posa As Double = 0
                For Each Models In Model
                    If Models.FromPartEconomyID = ExternalId Then
                        Posa += Models.MoneyValue
                    End If
                Next
                Return Posa
            End Get
        End Property
        ReadOnly Property Sum As Double
            Get
                Return Esoda - Exoda
            End Get
        End Property
        Sub New(ExternalIdL As Integer, ModelLink As List(Of Contracts.IModel))
            ExternalId = ExternalIdL
            Model = ModelLink
        End Sub
    End Class

    Public TransferService As Service.TransferService

    Sub New(Transfer As Service.TransferService)
        TransferService = Transfer
    End Sub

    Public Function Model(Category As String, ExternalId As Integer) As MyBook.ValMsg(Of IModelController)
        Dim ReturnModel As New MyBook.ValMsg(Of IModelController)
        Dim Creteria As Contracts.ICreteriaWhere = New Contracts.Contract
        With Creteria
            .Category = Category
            .PartEconomyId = ExternalId
        End With

        Dim TransferModel As MyBook.ValMsg(Of List(Of TransferProject.Contracts.IModel)) = TransferService.Search(Creteria)
        If TransferModel.Success = False Then
            ReturnModel.Success = False
            ReturnModel.Msg = TransferModel.Msg
            Return ReturnModel
        End If

        ReturnModel.Model = New IModelController(ExternalId, TransferModel.Model)

        Return ReturnModel
    End Function
End Class
