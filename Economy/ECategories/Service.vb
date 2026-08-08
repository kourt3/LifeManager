Imports Economy.TransferProject.Ables

Namespace ECategory.Services
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, ECategory.Contracts.Contracts, ECategory.Entity.Entity, ECategory.Repositories.Repository)

        Sub New()
            MyBase.New(New ECategory.Repositories.Repository)
        End Sub


        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As ECategory.Entity.Entity
            Dim Entity As New ECategory.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim NDTO As Contracts.IRegisterDTO = DTOLink
                Entity.Category = NDTO.Category
                Entity.Description = NDTO.Description
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim NDTO As Contracts.IChangeDescriptionDTO = DTOLink
                Entity.Description = NDTO.Description
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeCategoryNameDTO) Then
                Dim NDTO As Contracts.IChangeCategoryNameDTO = DTOLink
                Entity.Category = NDTO.Category
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As ECategory.Entity.Entity) As ECategory.Entity.Entity

            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim NDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Category = NDTO.Category
                    .Description = NDTO.Description
                End With

            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim NDTO As Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = NDTO.Description
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeCategoryNameDTO) Then
                Dim NDTO As Contracts.IChangeCategoryNameDTO = DTOLink
                With Entity
                    .Category = NDTO.Category
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contracts
            Dim Model As New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Description = Entity.Description
                .Category = Entity.Category
            End With
            Return Model
        End Function
    End Class

End Namespace
