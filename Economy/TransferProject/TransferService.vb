Namespace TransferProject.Service
    Public Class TransferService
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contract, Entity.Entity, Repository.TransferRepository)

        Sub New()
            MyBase.New(New Repository.TransferRepository)
        End Sub

        Function Search(Creteria As Contracts.ICreateria) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Model = New List(Of Contracts.IModel)
            For Each EntityL In Repository.Read_All
                If Creteria.ExternalID = EntityL.ExternalID And Creteria.FromCategory = EntityL.FromCategory Or Creteria.ToExternalID = EntityL.ToExternalID And Creteria.ToCategory = EntityL.ToCategory Then
                    Val.Success = True
                    Val.Msg = "Βρέθηκαν Εγραφές!"
                    Val.Model.Add(ToModel(EntityL))
                End If
            Next
            If Val.Success = False Then
                Val.Msg = "Δεν Βρέθηκαν Εγραφές!"
            End If
            Return Val
        End Function

        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contract
            Dim model As Contracts.IModel = New Contracts.Contract
            With model
                .PrimaryKey = Entity.PrimaryKey
                .CreateAt = Entity.CreateAt
                .FromCategory = Entity.FromCategory
                .ExternalID = Entity.ExternalID
                .MoneyValue = Entity.MoneyValue
                .ToCategory = Entity.ToCategory
                .ToExternalID = Entity.ToExternalID
                .Description = Entity.Description
            End With
            Return model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ToCategory = Register.ToCategory
                    .ToExternalID = Register.ToExternalID
                    .FromCategory = Register.FromCategory
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

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .FromCategory = Register.FromCategory
                    .ToCategory = Register.ToCategory
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

