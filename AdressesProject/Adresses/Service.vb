Imports AdressesProject.Adresses.Contracts

Public Class Service
    Inherits MyBook.Services.Service(Of Integer, Adresses.Contracts.Contracts, My.Entity.Entity, Repository)

    Sub New()
        MyBase.New(New Repository)
    End Sub

    Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts)
        Dim Val As New MyBook.ValMsg(Of Contracts)
        Dim Creteria As Adresses.Contracts.ICreteriaValue = New Contracts
        Dim RegisterDTOL As Adresses.Contracts.IUpdateAndRegisterDTO = RegisterDTO
        Creteria.Value = RegisterDTOL.Value
        If Repository.Exist(Creteria) Then
            Val.Success = False
            Val.Msg = "Η Εγραφή Υπάρχει!"
            Val.Model = ToModel(Repository.Find(Creteria))
            Return Val
        End If

        Return MyBase.Register(RegisterDTO)
    End Function

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
