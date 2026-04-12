Namespace Vehicle.Brand.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Vehicle.Brand.Contracts.Contracts, Vehicle.Brand.Entity.Entity, Vehicle.Brand.Repository.Repository)

        Sub New()
            MyBase.New(New Brand.Repository.Repository)
        End Sub

        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contracts
            Dim Model As New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Name = Entity.Name
                .Icon = Entity.Icon
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Vehicle.Brand.Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Name = Register.Name
                    .Icon = Register.Icon
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeDTO) Then
                Dim Change As Contracts.IChangeDTO = DTOLink
                With Entity
                    .Name = Change.Name
                    .Icon = Change.Icon
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeNameDTO) Then
                Dim ChangeName As Contracts.IChangeNameDTO = DTOLink
                With Entity
                    .Name = ChangeName.Name
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeIconDTO) Then
                Dim ChangeIcon As Contracts.IChangeIconDTO = DTOLink
                With Entity
                    .Icon = ChangeIcon.Icon
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Name = Register.Name
                    .Icon = Register.Icon
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeDTO) Then
                Dim Change As Contracts.IChangeDTO = DTOLink
                With Entity
                    .Name = Change.Name
                    .Icon = Change.Icon
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeNameDTO) Then
                Dim ChangeName As Contracts.IChangeNameDTO = DTOLink
                With Entity
                    .Name = ChangeName.Name
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeIconDTO) Then
                Dim ChangeIcon As Contracts.IChangeIconDTO = DTOLink
                With Entity
                    .Icon = ChangeIcon.Icon
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace
