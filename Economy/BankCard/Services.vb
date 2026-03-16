Namespace BankCardsProject.Service
    Public Class Services
        Inherits MyBook.Services.Service(Of Integer, BankCardsProject.Contracts.Contracts, BankCardsProject.My.Entity.Entity, BankCardsProject.Repositories.Repository)

        Sub New()
            MyBase.New(New BankCardsProject.Repositories.Repository)
        End Sub

        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
            Dim Model As BankCardsProject.Contracts.IModel = New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .NumberCard = Entity.NumberCard
                .Code = Entity.Code
                .Description = Entity.Description
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
            Dim Entity As New BankCardsProject.My.Entity.Entity
            If GetType(DTO) = GetType(BankCardsProject.Contracts.IRegisterDTO) Then
                Dim RegisterDTO As BankCardsProject.Contracts.IRegisterDTO = DTOLink
                With Entity
                    .NumberCard = RegisterDTO.NumberCard
                    .Code = RegisterDTO.Code
                    .Description = RegisterDTO.Description
                End With
            ElseIf GetType(DTO) = GetType(BankCardsProject.Contracts.IChangeDTO) Then
                Dim ChangeDTO As BankCardsProject.Contracts.IChangeDTO = DTOLink
                With Entity
                    .NumberCard = ChangeDTO.NumberCard
                    .Code = ChangeDTO.Code
                    .Description = ChangeDTO.Description
                End With
            ElseIf GetType(DTO) = GetType(BankCardsProject.Contracts.IChangeNumberDTO) Then
                Dim ChangeDTO As BankCardsProject.Contracts.IChangeNumberDTO = DTOLink
                With Entity
                    .NumberCard = Entity.NumberCard
                    .Code = Entity.Code
                End With
            ElseIf GetType(DTO) = GetType(BankCardsProject.Contracts.IChangeDescriptionDTO) Then
                Dim ChangeDTO As BankCardsProject.Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = ChangeDTO.Description
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
            If GetType(DTO) = GetType(BankCardsProject.Contracts.IRegisterDTO) Then
                Dim RegisterDTO As BankCardsProject.Contracts.IRegisterDTO = DTOLink
                With Entity
                    .NumberCard = RegisterDTO.NumberCard
                    .Code = RegisterDTO.Code
                    .Description = RegisterDTO.Description
                End With
            ElseIf GetType(DTO) = GetType(BankCardsProject.Contracts.IChangeDTO) Then
                Dim ChangeDTO As BankCardsProject.Contracts.IChangeDTO = DTOLink
                With Entity
                    .NumberCard = ChangeDTO.NumberCard
                    .Code = ChangeDTO.Code
                    .Description = ChangeDTO.Description
                End With
            ElseIf GetType(DTO) = GetType(BankCardsProject.Contracts.IChangeNumberDTO) Then
                Dim ChangeDTO As BankCardsProject.Contracts.IChangeNumberDTO = DTOLink
                With Entity
                    .NumberCard = Entity.NumberCard
                    .Code = Entity.Code
                End With
            ElseIf GetType(DTO) = GetType(BankCardsProject.Contracts.IChangeDescriptionDTO) Then
                Dim ChangeDTO As BankCardsProject.Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = ChangeDTO.Description
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

