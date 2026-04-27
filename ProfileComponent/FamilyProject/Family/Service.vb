Namespace FamilyProject.Family.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, FamilyProject.Family.Entity.Entity, Repository.DatabaseRepository)
        Sub New(PersonServiceLink As PersonProject.Service.PersonService)
            MyBase.New(New Repository.DatabaseRepository)
        End Sub

        Public Overrides Function ToModel(Entity As FamilyProject.Family.Entity.Entity) As Contracts.Contracts
            Dim Model As Contracts.IModel = New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Mother = Entity.Mother
                .Father = Entity.Father
                .Spouse = Entity.Spouse
            End With
            Return Model
        End Function
        Public Overrides Function Change(Of DTO)(Ref As Contracts.Contracts, ChangeDTO As DTO) As MyBook.ValMsg
            Dim Result As New MyBook.ValMsg
            Result.Success = True
            Result.Msg = "Η εγγραφη ηταν επιτυχής!"

            If GetType(DTO) = GetType(Contracts.IRemoveMotherDTO) Then
                Return MyBase.Change(Ref, ChangeDTO)
            ElseIf GetType(DTO) = GetType(Contracts.IRemoveFatherDTO) Then
                Return MyBase.Change(Ref, ChangeDTO)
            ElseIf GetType(DTO) = GetType(Contracts.IRemoveHusbandDTO) Then
                Return MyBase.Change(Ref, ChangeDTO)
            End If

            Dim Model As Contracts.IModel = Exist(Ref).Model
            Dim Creteria As FamilyProject.Children.Conctracts.ICreteria = New FamilyProject.Children.Conctracts.Contracts
            Creteria.FamilyID = Ref.PrimaryKey

            If GetType(DTO) = GetType(Contracts.IRegisterMotherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterMotherDTO = ChangeDTO

                If Model.Father = RegisterDTO.Mother Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Father."
                    Return Result
                End If

                If Model.Spouse = RegisterDTO.Mother Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Wife/Husband."
                    Return Result
                End If
                If Result.Success = False Then
                    Return Result
                End If

            ElseIf GetType(DTO) = GetType(Contracts.IRegisterFatherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterFatherDTO = ChangeDTO
                If Model.Mother = RegisterDTO.Father Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Mother."
                    Return Result
                End If
                If Model.Spouse = RegisterDTO.Father Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Wife/Husband."
                    Return Result
                End If
                If Result.Success = False Then
                    Return Result
                End If

            ElseIf GetType(DTO) = GetType(Contracts.IRegisterHusbandDTO) Then
                Dim RegisterDTO As Contracts.IRegisterHusbandDTO = ChangeDTO
                If Model.Mother = RegisterDTO.Spouse Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Mother."
                    Return Result
                End If
                If Model.Father = RegisterDTO.Spouse Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Father."
                    Return Result
                End If
                If Result.Success = False Then
                    Return Result
                End If
            End If

            Return MyBase.Change(Ref, ChangeDTO)
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As FamilyProject.Family.Entity.Entity
            Dim Entity As New FamilyProject.Family.Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Mother = RegisterDTO.Mother
                    .Father = RegisterDTO.Father
                    .Spouse = RegisterDTO.Spouse
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IRegisterMotherDTO) Or GetType(DTO) = GetType(Contracts.IRemoveMotherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterMotherDTO = DTOLink
                With Entity
                    .Mother = RegisterDTO.Mother
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IRegisterFatherDTO) Or GetType(DTO) = GetType(Contracts.IRemoveFatherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterFatherDTO = DTOLink
                With Entity
                    .Father = RegisterDTO.Father
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IRegisterHusbandDTO) Or GetType(DTO) = GetType(Contracts.IRemoveHusbandDTO) Then
                Dim RegisterDTO As Contracts.IRegisterHusbandDTO = DTOLink
                With Entity
                    .Spouse = RegisterDTO.Spouse
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As FamilyProject.Family.Entity.Entity) As FamilyProject.Family.Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Mother = RegisterDTO.Mother
                    .Father = RegisterDTO.Father
                    .Spouse = RegisterDTO.Spouse
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IRegisterMotherDTO) Or GetType(DTO) = GetType(Contracts.IRemoveMotherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterMotherDTO = DTOLink
                With Entity
                    .Mother = RegisterDTO.Mother
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IRegisterFatherDTO) Or GetType(DTO) = GetType(Contracts.IRemoveFatherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterFatherDTO = DTOLink
                With Entity
                    .Father = RegisterDTO.Father
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IRegisterHusbandDTO) Or GetType(DTO) = GetType(Contracts.IRemoveHusbandDTO) Then
                Dim RegisterDTO As Contracts.IRegisterHusbandDTO = DTOLink
                With Entity
                    .Spouse = RegisterDTO.Spouse
                End With
            End If
            Return Entity
        End Function
    End Class

End Namespace
