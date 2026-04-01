Imports MyBook
Imports MyBook.RelationShip.Contracts

Namespace AddressRelationShip.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, MyBook.RelationShip.Contracts.Contracts, MyBook.RelationShip.Entity.Entity, MyBook.RelationShip.Repositories.Repository)

        Sub New()
            MyBase.New(New MyBook.RelationShip.Repositories.Repository)
        End Sub

        Public Function Search(Of TCreteria)(Creteria As TCreteria) As MyBook.ValMsg(Of List(Of RelationShip.Contracts.Contracts))
            Dim Val As New MyBook.ValMsg(Of List(Of RelationShip.Contracts.Contracts))
            Val.Model = New List(Of Contracts)
            Val.Success = False
            Val.Msg = "Δεν βρέθηκε εγραφή!"
            For Each Entity In Repository.Search(Creteria)
                Val.Success = True
                Val.Msg = "Βρέθηκε Εγραφή!"
                Val.Model.Add(ToModel(Entity))
            Next
            Return Val
        End Function


        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As ValMsg(Of Contracts)
            Dim Val As New MyBook.ValMsg(Of Contracts)
            Dim RegisterDTOLink As RelationShip.Contracts.IRegisterDTO = RegisterDTO
            Dim Creteria As MyBook.RelationShip.Contracts.ICreteriaExtrenalAndToExternal = New Contracts
            With Creteria
                .ExternalID = RegisterDTOLink.ExternalID
                .ToExternalID = RegisterDTOLink.ToExternalID
            End With
            If Repository.Exist(Creteria) Then
                Val.Success = False
                Val.Msg = "Βρέθηκε η εργαφή!"
                Val.Model = ToModel(Repository.Find(Creteria))
                Return Val
            End If

            Return MyBase.Register(RegisterDTO)
        End Function

        Public Overrides Function ToModel(Entity As MyBook.RelationShip.Entity.Entity) As MyBook.RelationShip.Contracts.Contracts
            Dim Model As New MyBook.RelationShip.Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .ExternalID = Entity.ExternalID
                .ToExternalID = Entity.ToExternalID
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As MyBook.RelationShip.Entity.Entity
            Dim Entity As New MyBook.RelationShip.Entity.Entity
            Dim RegisterDTO As MyBook.RelationShip.Contracts.IRegisterDTO = DTOLink
            With Entity
                .ExternalID = RegisterDTO.ExternalID
                .ToExternalID = RegisterDTO.ToExternalID
            End With
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As MyBook.RelationShip.Entity.Entity) As MyBook.RelationShip.Entity.Entity
            Dim RegisterDTO As MyBook.RelationShip.Contracts.IRegisterDTO = DTOLink
            With Entity
                .ExternalID = RegisterDTO.ExternalID
                .ToExternalID = RegisterDTO.ToExternalID
            End With
            Return Entity
        End Function
    End Class
End Namespace

