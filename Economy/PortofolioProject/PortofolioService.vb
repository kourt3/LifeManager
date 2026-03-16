Namespace Portofolio.Service

    Public Class PortofolioService
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contract, Portofolio.Entity.Entity, Repository.PortofolioRepository)

        Sub New()
            MyBase.New(New Portofolio.Repository.PortofolioRepository)
        End Sub


        Public Overrides Function ToModel(Entity As Portofolio.Entity.Entity) As Contracts.Contract
            Dim Model As Contracts.IModel = New Contracts.Contract
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Name = Entity.Name
                .Description = Entity.Description
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Portofolio.Entity.Entity
            Dim NewEntity As New Portofolio.Entity.Entity
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

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Portofolio.Entity.Entity) As Portofolio.Entity.Entity
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

End Namespace

