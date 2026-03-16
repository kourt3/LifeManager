Namespace Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, My.Entity.Entity, Repository.Repository)

        Public FamilyTreeService As New RelationShipComponent.Service

        Public Childrens As Children.Service.ChildrenService
        Private PersonService As PersonProject.Service.PersonService
        Sub New(PersonServiceLink As PersonProject.Service.PersonService)
            MyBase.New(New Repository.Repository)
            PersonService = PersonServiceLink
            Childrens = New Children.Service.ChildrenService(PersonServiceLink)
        End Sub

        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
            Dim Model As Contracts.IModel = New Contracts.Contracts
            Model.Childrens = New List(Of Children.Conctracts.IModel)
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .MotherModel = PersonService.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Entity.Mother}).Model
                .FatherModel = PersonService.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Entity.Father}).Model
                .HusbandModel = PersonService.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Entity.Husband}).Model
                .MePersonModel = PersonService.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Entity.MePersonID}).Model
                For Each RelationModel In Childrens.Search(New Children.Conctracts.Contracts With {.FamilyID = Entity.PrimaryKey}).Model
                    .Childrens.Add(RelationModel)
                    Console.WriteLine(RelationModel)
                Next
            End With
            Return Model
        End Function
        Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of Contracts.IModel)
            Dim Val As New MyBook.ValMsg(Of Contracts.IModel)
            Val.Success = False
            Val.Msg = "Δεν βρεθηκε εγραφή!"
            For Each Entity In Repository.Read_All
                If Entity.MePersonID = Creteria.MePersonID Then
                    Val.Success = True
                    Val.Msg = "Βρέθηκε εγραφή!"
                    Val.Model = ToModel(Entity)
                End If
            Next
            Return Val
        End Function
        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Contracts)
            Return MyBase.Register(RegisterDTO)
        End Function
        Public Overloads Function Register(Ref As Contracts.IReference, RegisterDTO As Contracts.IRegisterChildrendDTO) As MyBook.ValMsg(Of Children.Conctracts.Contracts)
            Dim Result As New MyBook.ValMsg(Of Children.Conctracts.Contracts)
            Result.Success = True
            Dim Model As Contracts.IModel = Exist(Ref).Model
            Dim MotherModel As PersonProject.Contracts.IModel = Model.MotherModel
            Dim FatherModel As PersonProject.Contracts.IModel = Model.FatherModel
            Dim HusbandModel As PersonProject.Contracts.IModel = Model.HusbandModel

            Dim ListChildrens As New List(Of PersonProject.Contracts.IModel)

            Dim Creteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
            Creteria.FamilyID = Ref.PrimaryKey
            Dim ChildVal As MyBook.ValMsg(Of List(Of Children.Conctracts.IModel)) = Childrens.Search(Creteria)

            For Each ChildModel In ChildVal.Model
                ListChildrens.Add(ChildModel.PersonModel)
            Next

            If MotherModel IsNot Nothing AndAlso MotherModel.PrimaryKey = RegisterDTO.PersonID Then
                Result.Success = False
                Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Mother."
                Return Result
            End If

            If FatherModel IsNot Nothing AndAlso FatherModel.PrimaryKey = RegisterDTO.PersonID Then
                Result.Success = False
                Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Father."
                Return Result
            End If

            If HusbandModel IsNot Nothing AndAlso HusbandModel.PrimaryKey = RegisterDTO.PersonID Then
                Result.Success = False
                Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Wife/Husband."
                Return Result
            End If

            If ListChildrens.Count > 0 Then
                For Each ChildrenModel In ListChildrens
                    If ChildrenModel.PrimaryKey = RegisterDTO.PersonID Then
                        Result.Success = False
                        Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος children."
                    End If
                Next
            End If

            If Result.Success = True Then
                Dim Childreg As Children.Conctracts.IRegister = RegisterDTO

                Return Childrens.Register(Childreg)
            End If
            Return Result
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
            ElseIf GetType(DTO) = GetType(Contracts.IRemoveChildrenDTO) Then
                Return MyBase.Change(Ref, ChangeDTO)
            End If


            Dim Model As Contracts.IModel = Exist(Ref).Model
            Dim MotherModel As PersonProject.Contracts.IModel = Model.MotherModel
            Dim FatherModel As PersonProject.Contracts.IModel = Model.FatherModel
            Dim HusbandModel As PersonProject.Contracts.IModel = Model.HusbandModel
            Dim ListChildrens As New List(Of PersonProject.Contracts.IModel)
            Dim Creteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
            Creteria.FamilyID = Ref.PrimaryKey
            Dim ChildVal As MyBook.ValMsg(Of List(Of Children.Conctracts.IModel)) = Childrens.Search(Creteria)
            For Each ChildModel In ChildVal.Model
                ListChildrens.Add(ChildModel.PersonModel)
            Next

            If GetType(DTO) = GetType(Contracts.IRegisterMotherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterMotherDTO = ChangeDTO

                If FatherModel IsNot Nothing AndAlso FatherModel.PrimaryKey = RegisterDTO.Mother Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Father."
                    Return Result
                End If

                If HusbandModel IsNot Nothing AndAlso HusbandModel.PrimaryKey = RegisterDTO.Mother Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Wife/Husband."
                    Return Result
                End If

                If ListChildrens.Count > 0 Then
                    For Each ChildrenModel In ListChildrens
                        If ChildrenModel.PrimaryKey = RegisterDTO.Mother Then
                            Result.Success = False
                            Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος children."
                        End If
                    Next
                End If
                If Result.Success = False Then
                    Return Result
                End If

            ElseIf GetType(DTO) = GetType(Contracts.IRegisterFatherDTO) Then
                Dim RegisterDTO As Contracts.IRegisterFatherDTO = ChangeDTO
                If MotherModel IsNot Nothing AndAlso MotherModel.PrimaryKey = RegisterDTO.Father Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Mother."
                    Return Result
                End If
                If HusbandModel IsNot Nothing AndAlso HusbandModel.PrimaryKey = RegisterDTO.Father Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Wife/Husband."
                    Return Result
                End If
                If ListChildrens.Count > 0 Then
                    For Each ChildrenModel In ListChildrens
                        If ChildrenModel.PrimaryKey = RegisterDTO.Father Then
                            Result.Success = False
                            Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος children."
                        End If
                    Next
                End If
                If Result.Success = False Then
                    Return Result
                End If

            ElseIf GetType(DTO) = GetType(Contracts.IRegisterHusbandDTO) Then
                Dim RegisterDTO As Contracts.IRegisterHusbandDTO = ChangeDTO
                If MotherModel IsNot Nothing AndAlso MotherModel.PrimaryKey = RegisterDTO.Husband Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Mother."
                    Return Result
                End If
                If FatherModel IsNot Nothing AndAlso FatherModel.PrimaryKey = RegisterDTO.Husband Then
                    Result.Success = False
                    Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος Father."
                    Return Result
                End If
                If ListChildrens.Count > 0 Then
                    For Each ChildrenModel In ListChildrens
                        If ChildrenModel.PrimaryKey = RegisterDTO.Husband Then
                            Result.Success = False
                            Result.Msg = "Δεν Εγίνε η εγραφη, ο Χρήστης ειναι περασμενος children."
                        End If
                    Next
                End If

                If Result.Success = False Then
                    Return Result
                End If
            End If

            Return MyBase.Change(Ref, ChangeDTO)
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
            Dim Entity As New My.Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Mother = RegisterDTO.Mother
                    .Father = RegisterDTO.Father
                    .Husband = RegisterDTO.Husband
                    .MePersonID = RegisterDTO.MePersonID
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
                    .Husband = RegisterDTO.Husband
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Mother = RegisterDTO.Mother
                    .Father = RegisterDTO.Father
                    .Husband = RegisterDTO.Husband
                    .MePersonID = RegisterDTO.MePersonID
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
                    .Husband = RegisterDTO.Husband
                End With
            End If
            Return Entity
        End Function
    End Class

End Namespace
