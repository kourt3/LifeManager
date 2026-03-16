Public Class PortofolioService
    Inherits MyBook.Services.Service(Of Integer, Contracts.Contract, My.Enity.Entity, Repository.PortofolioRepository)

    Sub New()
        MyBase.New(New PortofolioProject.Repository.PortofolioRepository)
    End Sub


    Public Overrides Function ToModel(Entity As My.Enity.Entity) As Contracts.Contract
        Dim Model As Contracts.IModel = New Contracts.Contract
        With Model
            .PrimaryKey = Entity.PrimaryKey
            .Name = Entity.Name
            .Description = Entity.Description
        End With
        Return Model
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Enity.Entity
        Dim NewEntity As New My.Enity.Entity
        If GetType(DTO) Is GetType(Contracts.IChangeNameDTO) Then
            Dim ChangeDTO As Contracts.IChangeNameDTO = DTOLink
            NewEntity.Name = ChangeDTO.Name
        ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
            Dim ChangeDTO As Contracts.IChangeDescriptionDTO = DTOLink
            NewEntity.Description = ChangeDTO.Description
        ElseIf GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
            Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
            NewEntity.Name = RegisterDTO.Name
            NewEntity.Description = RegisterDTO.Description

        End If
        Return NewEntity
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Enity.Entity) As My.Enity.Entity
        If GetType(DTO) Is GetType(Contracts.IChangeNameDTO) Then
            Dim ChangeDTO As Contracts.IChangeNameDTO = DTOLink
            Entity.Name = ChangeDTO.Name
        ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
            Dim ChangeDTO As Contracts.IChangeDescriptionDTO = DTOLink
            Entity.Description = ChangeDTO.Description
        ElseIf GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
            Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
            Entity.Name = RegisterDTO.Name
            Entity.Description = RegisterDTO.Description
        End If
        Return Entity
    End Function
End Class
