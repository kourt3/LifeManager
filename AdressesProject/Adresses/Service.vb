Public Class Service
    Inherits MyBook.Services.Service(Of Integer, Adresses.Contracts.Contracts, My.Entity.Entity, Repository)

    Sub New()
        MyBase.New(New Repository)
    End Sub
    Public Overrides Function ToModel(Entity As My.Entity.Entity) As Adresses.Contracts.Contracts
        Return New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.PrimaryKey, .Value = Entity.Value}
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
        Dim Entity As New My.Entity.Entity
        If GetType(DTO) = GetType(Adresses.Contracts.IUpdateAndRegisterDTO) Then
            Dim RegisterOrUpdate As Adresses.Contracts.IUpdateAndRegisterDTO = DTOLink
            Entity.Value = RegisterOrUpdate.Value
        End If
        Return Entity
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
        If GetType(DTO) = GetType(Adresses.Contracts.IUpdateAndRegisterDTO) Then
            Dim RegisterOrUpdate As Adresses.Contracts.IUpdateAndRegisterDTO = DTOLink
            Entity.Value = RegisterOrUpdate.Value
        End If
        Return Entity
    End Function
End Class
