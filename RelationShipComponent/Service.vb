Public Class Service
    Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, My.Entity.Entity, Repository)

    Sub New()
        MyBase.New(New Repository)
    End Sub

    Public Function RegisterBothRelationship(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Contracts)
        Dim RegisterClone As Contracts.IRegisterDTO = RegisterDTO
        Dim Result As New MyBook.ValMsg(Of Contracts.Contracts)
        If Search(New Contracts.Contracts With {.ExternalID = RegisterClone.ExternalID, .ToExternalID = RegisterClone.ToExternalID}).Success = True Then
            Result.Success = False
            Result.Msg = "Η εγραφή υπάρχει! Δεν επιτρέπονται διπλοτυπα."
            Return Result
        End If

        Result = MyBase.Register(RegisterDTO)
        If Result.Success = False Then
            Return Result
        End If

        Dim RegisterToThirdAcc As Contracts.IRegisterDTO = New Contracts.Contracts
        With RegisterToThirdAcc
            .ExternalID = CType(RegisterDTO, Contracts.IRegisterDTO).ToExternalID
            .ToExternalID = CType(RegisterDTO, Contracts.IRegisterDTO).ExternalID
        End With
        Dim ThirdVal As MyBook.ValMsg(Of Contracts.Contracts) = MyBase.Register(RegisterToThirdAcc)
        If ThirdVal.Success = False Then
            Remove(Result.Model)
        End If
        Return ThirdVal
    End Function
    Public Function RemoveBothRelationship(Ref As Contracts.Contracts) As MyBook.ValMsg
        Dim Result As New MyBook.ValMsg
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = Exist(Ref)
        If Val.Success = False Then
            Result.Msg = Val.Msg
            Result.Success = False
            Return Result
        End If
        Dim SearchVal As MyBook.ValMsg(Of List(Of Contracts.IModel)) = Search(New Contracts.Contracts With {.ExternalID = Val.Model.ToExternalID, .ToExternalID = Val.Model.ExternalID})
        If SearchVal.Success = False Then
            Result.Success = False
            Result.Msg = "Δεν Βρέθηκε η Εγραφή! "
            Return Result
        End If
        MyBase.Remove(Ref)
        Return MyBase.Remove(SearchVal.Model(0))

    End Function
    Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of List(Of Contracts.IModel))
        Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
        Val.Success = False
        Val.Msg = "Δεν βρέθηκε Εγραφή!"
        Val.Model = New List(Of Contracts.IModel)
        If Creteria.ExternalID <> Nothing And Creteria.ToExternalID = Nothing Then
            For Each Entity In Repository.Read_All
                If Creteria.ExternalID = Entity.ExternalID Then
                    Val.Msg = "Βρέθηκε Εγραφή!"
                    Val.Success = True
                    Val.Model.Add(ToModel(Entity))
                End If
            Next
        ElseIf Creteria.ExternalID <> Nothing And Creteria.ToExternalID <> Nothing Then
            For Each Entity In Repository.Read_All
                If Creteria.ExternalID = Entity.ExternalID AndAlso Creteria.ToExternalID = Entity.ToExternalID Then
                    Val.Msg = "Βρέθηκε Εγραφή!"
                    Val.Success = True
                    Val.Model.Add(ToModel(Entity))
                End If
            Next
        ElseIf Creteria.ExternalID = Nothing And Creteria.ToExternalID <> Nothing Then
            For Each Entity In Repository.Read_All
                If Creteria.ToExternalID = Entity.ToExternalID Then
                    Val.Msg = "Βρέθηκε Εγραφή!"
                    Val.Success = True
                    Val.Model.Add(ToModel(Entity))
                End If
            Next
        End If
        Return Val
    End Function

    Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
        Dim Model As New Contracts.Contracts
        With Model
            .PrimaryKey = Entity.PrimaryKey
            .ToExternalID = Entity.ToExternalID
            .ExternalID = Entity.ExternalID
            .Description = Entity.Description
        End With
        Return Model
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
        Dim Entity As New My.Entity.Entity
        If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
            Dim Register As Contracts.IRegisterDTO = DTOLink
            With Entity
                .ExternalID = Register.ExternalID
                .ToExternalID = Register.ToExternalID
                .Description = Register.Description
            End With
        ElseIf GetType(DTO) = GetType(Contracts.IChangeDescriptionDTO) Then
            Dim Change As Contracts.IChangeDescriptionDTO = DTOLink
            With Entity
                .Description = Change.Description
            End With
        End If
        Return Entity
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
        If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
            Dim Register As Contracts.IRegisterDTO = DTOLink
            With Entity
                .ExternalID = Register.ExternalID
                .ToExternalID = Register.ToExternalID
                .Description = Register.Description
            End With
        ElseIf GetType(DTO) = GetType(Contracts.IChangeDescriptionDTO) Then
            Dim Change As Contracts.IChangeDescriptionDTO = DTOLink
            With Entity
                .Description = Change.Description
            End With
        End If
        Return Entity
    End Function
End Class
