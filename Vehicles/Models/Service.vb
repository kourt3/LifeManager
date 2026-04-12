Namespace Vehicle.Model.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Vehicle.Model.Contracts.Contracts, Vehicle.Model.Entity.Entity, Vehicle.Model.Repository.Repository)

        Sub New()
            MyBase.New(New Repository.Repository)
        End Sub


        Public Function Search(CreateriaLink As Vehicle.Model.Contracts.ICreteria) As MyBook.ValMsg(Of List(Of Vehicle.Model.Contracts.Contracts))
            Dim Val As New MyBook.ValMsg(Of List(Of Vehicle.Model.Contracts.Contracts))
            Val.Model = New List(Of Contracts.Contracts)
            Val.Success = False
            Val.Msg = "Δεν Βρέθηκαν εγραφές!"
            For Each EntityLink In Repository.Search(CreateriaLink)
                Val.Model.Add(ToModel(EntityLink))
                Val.Success = True
                Val.Msg = "Βρέθηκαν εγραφές!"
            Next
            Return Val
        End Function
        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contracts
            Dim Model As New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Name = Entity.Name
                .BrandId = Entity.BrandId
                .CategoryName = Entity.CategoryName
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Name = Register.Name
                    .BrandId = Register.BrandId
                    .CategoryName = Register.CategoryName
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeName) Then
                Dim Change As Contracts.IChangeName = DTOLink
                Entity.Name = Change.Name
            ElseIf GetType(DTO) = GetType(Contracts.IChangeCategory) Then
                Dim Change As Contracts.IChangeCategory = DTOLink
                Entity.CategoryName = Change.CategoryName
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Name = Register.Name
                    .BrandId = Register.BrandId
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeName) Then
                Dim Change As Contracts.IChangeName = DTOLink
                Entity.Name = Change.Name
            ElseIf GetType(DTO) = GetType(Contracts.IChangeCategory) Then
                Dim Change As Contracts.IChangeCategory = DTOLink
                Entity.CategoryName = Change.CategoryName
            End If
            Return Entity
        End Function
    End Class
End Namespace
