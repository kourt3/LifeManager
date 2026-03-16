Namespace TransferProject.Service
    Public Class TransferService
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contract, My.Entity.Entity, Repository.TransferRepository)

        Sub New()
            MyBase.New(New Repository.TransferRepository)
        End Sub

        Function Search(Creteria As Contracts.ICreateria) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Model = New List(Of Contracts.IModel)
            For Each Entity In Repository.Read_All
                If Creteria.ExternalID = Entity.ExternalID Or Creteria.ToExternalID = Entity.ToExternalID Then
                    Val.Success = True
                    Val.Msg = "Βρέθηκαν Εγραφές!"
                    Val.Model.Add(ToModel(Entity))
                End If
            Next
            If Val.Success = False Then
                Val.Msg = "Δεν Βρέθηκαν Εγραφές!"
            End If
            Return Val
        End Function

        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contract
            Dim model As Contracts.IModel = New Contracts.Contract
            With model
                .PrimaryKey = Entity.PrimaryKey
                .CreateAt = Entity.CreateAt
                .ExternalID = Entity.ExternalID
                .MoneyValue = Entity.MoneyValue
                .ToExternalID = Entity.ToExternalID
                .Description = Entity.Description
            End With
            Return model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
            Dim Entity As New My.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ToExternalID = Register.ToExternalID
                    .ExternalID = Register.ExternalID
                    .MoneyValue = Register.MoneyValue
                    .Description = Register.Description
                    .CreateAt = Register.CreateAt
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim CDescription As Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = CDescription.Description
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeMoney) Then
                Dim CMoney As Contracts.IChangeMoney = DTOLink
                With Entity
                    .MoneyValue = CMoney.MoneyValue
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ToExternalID = Register.ToExternalID
                    .ExternalID = Register.ExternalID
                    .MoneyValue = Register.MoneyValue
                    .Description = Register.Description
                    .CreateAt = Register.CreateAt
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim CDescription As Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = CDescription.Description
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeMoney) Then
                Dim CMoney As Contracts.IChangeMoney = DTOLink
                With Entity
                    .MoneyValue = CMoney.MoneyValue
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

