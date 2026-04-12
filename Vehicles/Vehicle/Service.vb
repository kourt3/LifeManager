Namespace Vehicle.Vehicles.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Vehicle.Vehicles.Contracts.Contracrs, Vehicle.Vehicles.Entity.Entity, Vehicle.Vehicles.Repository.Repository)

        Sub New()
            MyBase.New(New Vehicle.Vehicles.Repository.Repository)
        End Sub
        Public Function Search(Creteria As Vehicle.Vehicles.Contracts.ICreteria) As MyBook.ValMsg(Of List(Of Vehicle.Vehicles.Contracts.Contracrs))
            Dim Val As New MyBook.ValMsg(Of List(Of Vehicle.Vehicles.Contracts.Contracrs))
            Val.Model = New List(Of Contracts.Contracrs)
            Val.Success = False
            Val.Msg = "Δεν βρέθηκε Εγραφή!"
            For Each EntityL In Repository.Search(Creteria)
                Val.Model.Add(ToModel(EntityL))
                Val.Success = True
                Val.Msg = "Βρέθηκε εγραφή!"
            Next
            Return Val
        End Function

        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contracrs
            Dim Model As New Contracts.Contracrs
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .ModelId = Entity.ModelId
                .CretatedAt = Entity.CretatedAt
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Vehicle.Vehicles.Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ModelId = Register.ModelId
                    .CretatedAt = Register.CretatedAt
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeCreatedDTO) Then
                Dim Change As Contracts.IChangeCreatedDTO = DTOLink
                With Entity
                    .CretatedAt = Change.CretatedAt
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ModelId = Register.ModelId
                    .CretatedAt = Register.CretatedAt
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeCreatedDTO) Then
                Dim Change As Contracts.IChangeCreatedDTO = DTOLink
                With Entity
                    .CretatedAt = Change.CretatedAt
                End With
            End If
            Return Entity
        End Function
    End Class

End Namespace
