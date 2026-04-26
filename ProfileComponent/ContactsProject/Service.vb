Namespace ContactsProject.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, ContactsProject.Entity.Entity, ContactsProject.Repository.Repository)

        Sub New()
            MyBase.New(New ContactsProject.Repository.Repository)
        End Sub
        ''' <summary>
        ''' Το External Εχει Φίλους.
        ''' </summary>
        ''' <param name="ExternalId"></param>
        ''' <returns></returns>
        Public Function Get_All_AllowFriends(ExternalId As Integer) As MyBook.ValMsg(Of List(Of ContactsProject.Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of ContactsProject.Contracts.IModel))

            Val.Success = False
            Val.Msg = "Δεν βρέθηκε εγραφή!"
            Val.Model = New List(Of Contracts.IModel)
            Dim listOf As List(Of Entity.Entity) = Repository.Search(Function(x As ContactsProject.Entity.Entity)
                                                                         If x.ExternalID = ExternalId Then Return True
                                                                         Return False
                                                                     End Function)
            If listOf.Count > 0 Then
                Val.Success = True
                Val.Msg = "Βρέθηκε η Εγραφή!"
                For i = 0 To listOf.Count - 1
                    Val.Model.Add(ToModel(listOf(i)))

                Next
            End If
            Return Val
        End Function
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

        Public Function Find(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of Contracts.IModel)
            Dim Val As New MyBook.ValMsg(Of Contracts.IModel)
            Val.Success = False
            Val.Msg = "Δεν βρέθηκε εγραφή!!!"
            Val.Model = Nothing
            Dim entity As Entity.Entity = Repository.Find(Creteria)
            If entity IsNot Nothing Then
                Val.Model = ToModel(entity)
                Val.Msg = "Βρέθηκε εγραφή!"
                Val.Success = True
            End If

            Return Val
        End Function

        Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Success = False
            Val.Msg = "Δεν βρέθηκε Εγραφή!"
            Val.Model = New List(Of Contracts.IModel)
            If Creteria.ExternalID <> Nothing And Creteria.ToExternalID = Nothing Then
                For Each EntityL In Repository.Read_All
                    If Creteria.ExternalID = EntityL.ExternalID Then
                        Val.Msg = "Βρέθηκε Εγραφή!"
                        Val.Success = True
                        Val.Model.Add(ToModel(EntityL))
                    End If
                Next
            ElseIf Creteria.ExternalID <> Nothing And Creteria.ToExternalID <> Nothing Then
                For Each EntityL In Repository.Read_All
                    If Creteria.ExternalID = EntityL.ExternalID AndAlso Creteria.ToExternalID = EntityL.ToExternalID Then
                        Val.Msg = "Βρέθηκε Εγραφή!"
                        Val.Success = True
                        Val.Model.Add(ToModel(EntityL))
                    End If
                Next
            ElseIf Creteria.ExternalID = Nothing And Creteria.ToExternalID <> Nothing Then
                For Each EntityL In Repository.Read_All
                    If Creteria.ToExternalID = EntityL.ToExternalID Then
                        Val.Msg = "Βρέθηκε Εγραφή!"
                        Val.Success = True
                        Val.Model.Add(ToModel(EntityL))
                    End If
                Next
            End If
            Return Val
        End Function

        Public Overrides Function ToModel(Entity As ContactsProject.Entity.Entity) As Contracts.Contracts
            Dim Model As New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .ToExternalID = Entity.ToExternalID
                .ExternalID = Entity.ExternalID
                .Description = Entity.Description
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As ContactsProject.Entity.Entity
            Dim Entity As New ContactsProject.Entity.Entity
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

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As ContactsProject.Entity.Entity) As ContactsProject.Entity.Entity
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

End Namespace
