Namespace Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, My.Entity.Entity, Repository.Repository)

        Sub New()
            MyBase.New(New Buildings.Repository.Repository)

        End Sub
        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
            Dim Model As Contracts.IModel = New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Addresess = Entity.Addresess
                .Lenght = Entity.Lenght
                .Width = Entity.Width
                .Description = Entity.Description
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
            Dim Entity As New My.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim DTOs As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Addresess = DTOs.Addresess
                    .Description = DTOs.Description
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeAddressesDTO) Then
                Dim DTOs As Contracts.IChangeAddressesDTO = DTOLink
                With Entity
                    .Addresess = DTOs.Addresess
                End With

            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim DTOs As Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = DTOs.Description
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeSquardMeter) Then
                Dim DTOs As Contracts.IChangeSquardMeter = DTOLink
                With Entity
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim DTOs As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Addresess = DTOs.Addresess
                    .Description = DTOs.Description
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeAddressesDTO) Then
                Dim DTOs As Contracts.IChangeAddressesDTO = DTOLink
                With Entity
                    .Addresess = DTOs.Addresess
                End With

            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim DTOs As Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = DTOs.Description
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeSquardMeter) Then
                Dim DTOs As Contracts.IChangeSquardMeter = DTOLink
                With Entity
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

