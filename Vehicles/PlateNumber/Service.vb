Namespace Vehicle.Plate.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, Entity.Entity, Repository.Repository)
        Sub New()
            MyBase.New(New Repository.Repository)
        End Sub

        Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of List(Of Contracts.Contracts))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.Contracts))
            Val.Model = New List(Of Contracts.Contracts)
            Val.Success = False
            Val.Msg = "Δεν βρέθηκε εγραφή!"
            For Each EntityL In Repository.Search(Creteria)
                Val.Model.Add(ToModel(EntityL))
                Val.Success = True
                Val.Msg = "Βρέθηκε Εγραφή!"
            Next
            Return Val
        End Function
        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contracts
            Dim Model As New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .ExternalID = Entity.ExternalID
                .VehicleId = Entity.VehicleId
                .CountryId = Entity.Country
                .NumberPlate = Entity.NumberPlate
                .Icon = Entity.Icon
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ExternalID = RegisterDTO.ExternalID
                    .Country = RegisterDTO.Country
                    .NumberPlate = RegisterDTO.NumberPlate
                    .Icon = RegisterDTO.Icon
                    .VehicleId = RegisterDTO.VehicleId
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeDTO) Then
                Dim ChangeDTO As Contracts.IChangeDTO = DTOLink
                With Entity
                    .Country = ChangeDTO.Country
                    .NumberPlate = ChangeDTO.NumberPlate
                    .Icon = ChangeDTO.Icon
                    .VehicleId = ChangeDTO.VehicleId
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangePlateDTO) Then
                Dim ChangeDTO As Contracts.IChangePlateDTO = DTOLink
                With Entity
                    .NumberPlate = ChangeDTO.NumberPlate
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeIconDTO) Then
                Dim ChangeDTO As Contracts.IChangeIconDTO = DTOLink
                With Entity
                    .Icon = ChangeDTO.Icon
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeCountryDTO) Then
                Dim ChangeDTO As Contracts.IChangeCountryDTO = DTOLink
                With Entity
                    .Country = ChangeDTO.Country
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity

            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ExternalID = RegisterDTO.ExternalID
                    .Country = RegisterDTO.Country
                    .NumberPlate = RegisterDTO.NumberPlate
                    .Icon = RegisterDTO.Icon
                    .VehicleId = RegisterDTO.VehicleId
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeDTO) Then
                Dim ChangeDTO As Contracts.IChangeDTO = DTOLink
                With Entity
                    .Country = ChangeDTO.Country
                    .NumberPlate = ChangeDTO.NumberPlate
                    .Icon = ChangeDTO.Icon
                    .VehicleId = ChangeDTO.VehicleId
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangePlateDTO) Then
                Dim ChangeDTO As Contracts.IChangePlateDTO = DTOLink
                With Entity
                    .NumberPlate = ChangeDTO.NumberPlate
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeIconDTO) Then
                Dim ChangeDTO As Contracts.IChangeIconDTO = DTOLink
                With Entity
                    .Icon = ChangeDTO.Icon
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChangeCountryDTO) Then
                Dim ChangeDTO As Contracts.IChangeCountryDTO = DTOLink
                With Entity
                    .Country = ChangeDTO.Country
                End With
            End If
            Return Entity
        End Function
    End Class


End Namespace

