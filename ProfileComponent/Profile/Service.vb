Imports MyBook

Namespace Profile.Service
    Public Class Service

        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, Entity.Entity, Repository.DataBaseRepository)
        Sub New()
            MyBase.New(New Repository.DataBaseRepository)
        End Sub

        Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of Contracts.Contracts)
            Dim Val As New MyBook.ValMsg(Of Contracts.Contracts)
            Val.Success = False
            Val.Msg = "Δεν βρέθηκε εγραφή !"
            If Repository.Exist(Creteria) = True Then
                Val.Model = (ToModel(Repository.Find(Creteria)))
                Val.Success = True
                Val.Msg = "Βρέθηκε εγραφή!"
            End If
            Return Val
        End Function


        Public Overrides Function Change(Of DTO)(Ref As Contracts.Contracts, ChangeDTO As DTO) As ValMsg
            Throw New Exception("Δεν Μπορει να γίνει αλλαγή!")
        End Function
        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contracts
            Dim Model As New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .PersonID = Entity.PersonID
                .FamilyID = Entity.FamilyID
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity
            Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
            With Entity
                .PersonID = RegisterDTO.PersonID
                .FamilyID = RegisterDTO.FamilyID
            End With
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
            With Entity
                .PersonID = RegisterDTO.PersonID
                .FamilyID = RegisterDTO.FamilyID
            End With
            Return Entity
        End Function
    End Class
End Namespace

