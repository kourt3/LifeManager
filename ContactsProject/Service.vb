Namespace Service
    Public Class Service
        Enum ChoiceType
            None
            Email
            Facebook
            Instagram
            TikTok
            Twitter
            Telephone
        End Enum

        Private Person As New PersonProject.Service.PersonService
        Private Email As New Repository.ContactRepository
        Private FaceBook As New Repository.ContactRepository
        Private Instagram As New Repository.ContactRepository
        Private TikTok As New Repository.ContactRepository
        Private Twitter As New Repository.ContactRepository
        Private Telephone As New Repository.ContactRepository

        Public Function Exist(Ref As Contracts.IReference, ChoiceType As ChoiceType) As MyBook.ValMsg(Of Contracts.IModel)
            Dim Val As New MyBook.ValMsg(Of Contracts.IModel)
            Val.Success = False
            Val.Msg = "Δεν Βρέθηκε η Εγραφή!"
            If ChoiceType = ChoiceType.None Then
                Return Val
            ElseIf ChoiceType = ChoiceType.Email Then
                Dim Entity As My.Entity.IContactEntity = Email.Read_Item(Ref.PrimaryKey)
                If Entity IsNot Nothing Then
                    Val.Model = ToModel(Entity, ChoiceType)
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.Facebook Then
                Dim Entity As My.Entity.IContactEntity = FaceBook.Read_Item(Ref.PrimaryKey)
                If Entity IsNot Nothing Then
                    Val.Model = ToModel(Entity, ChoiceType)
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.Instagram Then
                Dim Entity As My.Entity.IContactEntity = Instagram.Read_Item(Ref.PrimaryKey)
                If Entity IsNot Nothing Then
                    Val.Model = ToModel(Entity, ChoiceType)
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.TikTok Then
                Dim Entity As My.Entity.IContactEntity = TikTok.Read_Item(Ref.PrimaryKey)
                If Entity IsNot Nothing Then
                    Val.Model = ToModel(Entity, ChoiceType)
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.Twitter Then
                Dim Entity As My.Entity.IContactEntity = Twitter.Read_Item(Ref.PrimaryKey)
                If Entity IsNot Nothing Then
                    Val.Model = ToModel(Entity, ChoiceType)
                    Val.Success = True
                End If
                Return Val
            ElseIf ChoiceType = ChoiceType.Telephone Then
                Dim Entity As My.Entity.IContactEntity = Telephone.Read_Item(Ref.PrimaryKey)
                If Entity IsNot Nothing Then
                    Val.Model = ToModel(Entity, ChoiceType)
                    Val.Success = True
                End If
            End If

            If Val.Success = True Then
                Val.Msg = "Βρέθηκε η Εγραφή!"
            End If
            Return Val
        End Function
        Public Function Register(DTO As Contracts.IRegisterContact, ChoiceType As ChoiceType) As MyBook.ValMsg
            Dim Val As New MyBook.ValMsg
            Val.Success = False
            Val.Msg = "Δεν Μπόρεσε να γίνει εγραφή!"
            If ChoiceType = ChoiceType.None Then
                Return Val
            ElseIf ChoiceType = ChoiceType.Email Then
                If Email.Create(ToEnity(DTO, ChoiceType)) Then
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.Facebook Then
                If FaceBook.Create(ToEnity(DTO, ChoiceType)) Then
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.Instagram Then
                If Instagram.Create(ToEnity(DTO, ChoiceType)) Then
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.TikTok Then
                If TikTok.Create(ToEnity(DTO, ChoiceType)) Then
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.Twitter Then
                If Twitter.Create(ToEnity(DTO, ChoiceType)) Then
                    Val.Success = True
                End If
            ElseIf ChoiceType = ChoiceType.Telephone Then
                If Telephone.Create(ToEnity(DTO, ChoiceType)) Then
                    Val.Success = True
                End If
            End If
            If Val.Success = True Then
                Val.Msg = "Επιτυχης Εγγραφή!"
            End If
            Return Val
        End Function
        Public Function Update(Ref As Contracts.IReference, DTO As Contracts.IChancheContact, choiceType As ChoiceType) As MyBook.ValMsg(Of Contracts.IModel)
            Dim Val As New MyBook.ValMsg(Of Contracts.IModel)
            Val.Success = False
            Val.Msg = "Δεν ήταν επιτυχης η Αλλαγή!"
            If choiceType = ChoiceType.None Then
                Return Val
            ElseIf choiceType = ChoiceType.Email Then
                Dim Entity As My.Entity.IContactEntity = Email.Read_Item(Ref.PrimaryKey)
                ToEnity(DTO, Entity, choiceType)
                If Email.Update(Ref.PrimaryKey, Entity) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Facebook Then
                Dim Entity As My.Entity.IContactEntity = FaceBook.Read_Item(Ref.PrimaryKey)
                ToEnity(DTO, Entity, choiceType)
                If FaceBook.Update(Ref.PrimaryKey, Entity) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Instagram Then
                Dim Entity As My.Entity.IContactEntity = Instagram.Read_Item(Ref.PrimaryKey)
                ToEnity(DTO, Entity, choiceType)
                If Instagram.Update(Ref.PrimaryKey, Entity) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.TikTok Then
                Dim Entity As My.Entity.IContactEntity = TikTok.Read_Item(Ref.PrimaryKey)
                ToEnity(DTO, Entity, choiceType)
                If TikTok.Update(Ref.PrimaryKey, Entity) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Twitter Then
                Dim Entity As My.Entity.IContactEntity = Twitter.Read_Item(Ref.PrimaryKey)
                ToEnity(DTO, Entity, choiceType)
                If Twitter.Update(Ref.PrimaryKey, Entity) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Telephone Then
                Dim Entity As My.Entity.IContactEntity = Telephone.Read_Item(Ref.PrimaryKey)
                ToEnity(DTO, Entity, choiceType)
                If Telephone.Update(Ref.PrimaryKey, Entity) Then
                    Val.Success = True
                End If
            End If
            If Val.Success = True Then
                Val.Msg = "Επιτυχής Αλλαγή!"
            End If
            Return Val
        End Function
        Public Function Remove(Ref As Contracts.IReference, choiceType As ChoiceType) As MyBook.ValMsg
            Dim Val As New MyBook.ValMsg
            Val.Success = False
            Val.Msg = "Δεν μπόρεσε να διαγραφή!"
            If choiceType = ChoiceType.None Then
                Return Val
            ElseIf choiceType = ChoiceType.Email Then
                If Email.Delete(Ref.PrimaryKey) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Facebook Then
                If FaceBook.Delete(Ref.PrimaryKey) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Instagram Then
                If Instagram.Delete(Ref.PrimaryKey) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.TikTok Then
                If TikTok.Delete(Ref.PrimaryKey) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Twitter Then
                If Twitter.Delete(Ref.PrimaryKey) Then
                    Val.Success = True
                End If
            ElseIf choiceType = ChoiceType.Telephone Then
                If Telephone.Delete(Ref.PrimaryKey) Then
                    Val.Success = True
                End If
            End If
            If Val.Success = True Then
                Val.Msg = "Επιτυχης Διαγραφή!"
            End If
            Return Val
        End Function

        Function Search(Createria As Contracts.ICreteria, choiceType As ChoiceType) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Model = New List(Of Contracts.IModel)
            Val.Success = False
            Val.Msg = "Δεν Βρέθηκε η Εγραφή!"
            If choiceType = ChoiceType.None Then
            ElseIf choiceType = ChoiceType.Email Then
                For Each Entity In Email.Read_All
                    If Createria.ExternalID <> Nothing And Createria.Value <> Nothing Then
                        If Createria.ExternalID = Entity.ExternalID And Createria.Value = Entity.Value Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    ElseIf Createria.ExternalID <> Nothing And Createria.Value = Nothing Then
                        If Createria.ExternalID = Entity.ExternalID Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    End If

                Next
            ElseIf choiceType = ChoiceType.Facebook Then
                For Each Entity In FaceBook.Read_All
                    If Createria.ExternalID <> Nothing And Createria.Value <> Nothing Then
                        If Createria.ExternalID = Entity.ExternalID And Createria.Value = Entity.Value Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    ElseIf Createria.ExternalID <> Nothing And Createria.Value = Nothing Then
                        If Createria.ExternalID = Entity.ExternalID Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    End If
                Next
            ElseIf choiceType = ChoiceType.Instagram Then
                For Each Entity In Instagram.Read_All
                    If Createria.ExternalID <> Nothing And Createria.Value <> Nothing Then
                        If Createria.ExternalID = Entity.ExternalID And Createria.Value = Entity.Value Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    ElseIf Createria.ExternalID <> Nothing And Createria.Value = Nothing Then
                        If Createria.ExternalID = Entity.ExternalID Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    End If
                Next
            ElseIf choiceType = ChoiceType.TikTok Then
                For Each Entity In TikTok.Read_All
                    If Createria.ExternalID <> Nothing And Createria.Value <> Nothing Then
                        If Createria.ExternalID = Entity.ExternalID And Createria.Value = Entity.Value Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    ElseIf Createria.ExternalID <> Nothing And Createria.Value = Nothing Then
                        If Createria.ExternalID = Entity.ExternalID Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    End If
                Next
            ElseIf choiceType = ChoiceType.Twitter Then
                For Each Entity In Twitter.Read_All
                    If Createria.ExternalID <> Nothing And Createria.Value <> Nothing Then
                        If Createria.ExternalID = Entity.ExternalID And Createria.Value = Entity.Value Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    ElseIf Createria.ExternalID <> Nothing And Createria.Value = Nothing Then
                        If Createria.ExternalID = Entity.ExternalID Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    End If
                Next
            ElseIf choiceType = ChoiceType.Telephone Then
                For Each Entity In Telephone.Read_All
                    If Createria.ExternalID <> Nothing And Createria.Value <> Nothing Then
                        If Createria.ExternalID = Entity.ExternalID And Createria.Value = Entity.Value Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    ElseIf Createria.ExternalID <> Nothing And Createria.Value = Nothing Then
                        If Createria.ExternalID = Entity.ExternalID Then
                            Val.Model.Add(ToModel(Entity, choiceType))
                            Val.Success = True
                        End If
                    End If
                Next
            End If

            If Val.Success = True Then
                Val.Msg = "Βρέθηκε Εγραφή!"
            End If
            Return Val
        End Function

        Function AllModelView(Ref As Contracts.IReference) As MyBook.ValMsg(Of Contracts.IViewAllModel)
            Dim Val As New MyBook.ValMsg(Of Contracts.IViewAllModel)
            Val.Model = New Contracts.ViewAllModel
            Dim Creteria As Contracts.ICreteria = New Contracts.Contracts With {.ExternalID = Ref.PrimaryKey}
            Dim ModelVal As New MyBook.ValMsg(Of List(Of Contracts.IModel))

            ModelVal = Search(Creteria, ChoiceType.Email)
            If ModelVal.Success = True Then
                Val.Model.Email = ModelVal.Model
            End If
            ModelVal = Search(Creteria, ChoiceType.Facebook)
            If ModelVal.Success = True Then
                Val.Model.FaceBook = ModelVal.Model
            End If
            ModelVal = Search(Creteria, ChoiceType.Instagram)
            If ModelVal.Success = True Then
                Val.Model.Instagram = ModelVal.Model
            End If

            ModelVal = Search(Creteria, ChoiceType.TikTok)
            If ModelVal.Success = True Then
                Val.Model.TikTok = ModelVal.Model
            End If

            ModelVal = Search(Creteria, ChoiceType.Twitter)
            If ModelVal.Success = True Then
                Val.Model.Twitter = ModelVal.Model
            End If

            ModelVal = Search(Creteria, ChoiceType.Telephone)
            If ModelVal.Success = True Then
                Val.Model.Telephone = ModelVal.Model
            End If

            Return Val
        End Function

        Function ToModel(Entity As My.Entity.IContactEntity, choiceType As ChoiceType) As Contracts.IModel
            Dim Model As Contracts.IModel = New Contracts.Contracts
            If choiceType = ChoiceType.None Then
            ElseIf choiceType = ChoiceType.Email Then
                Model.NameCategory = "Email"
            ElseIf choiceType = ChoiceType.Facebook Then
                Model.NameCategory = "Facebook"
            ElseIf choiceType = ChoiceType.Instagram Then
                Model.NameCategory = "Instagram"
            ElseIf choiceType = ChoiceType.TikTok Then
                Model.NameCategory = "Tiktok"
            ElseIf choiceType = ChoiceType.Twitter Then
                Model.NameCategory = "Twitter"
            ElseIf choiceType = ChoiceType.Telephone Then
                Model.NameCategory = "Telephone"
            End If
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Description = Entity.Description
                .Value = Entity.Value
            End With
            Return Model
        End Function
        Function ToEnity(Of DTO)(DTOLink As DTO, ChoiceType As ChoiceType) As My.Entity.IContactEntity
            Dim Entity As New My.Entity.Entity
            If GetType(DTO) = GetType(Contracts.IRegisterContact) Then
                Dim Register As Contracts.IRegisterContact = DTOLink
                With Entity
                    .ExternalID = Register.ExternalID
                    .Value = Register.Value
                    .Description = Register.Description
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChancheContact) Then
                Dim Change As Contracts.IChancheContact = DTOLink
                With Entity

                    .Value = Change.Value
                    .Description = Change.Description
                End With
            End If
            If ChoiceType = ChoiceType.None Then
            ElseIf ChoiceType = ChoiceType.Email Then
                Entity.NameCategory = "Email"
            ElseIf ChoiceType = ChoiceType.Facebook Then
                Entity.NameCategory = "Facebook"
            ElseIf ChoiceType = ChoiceType.Instagram Then
                Entity.NameCategory = "Instagram"
            ElseIf ChoiceType = ChoiceType.TikTok Then
                Entity.NameCategory = "TikTok"
            ElseIf ChoiceType = ChoiceType.Twitter Then
                Entity.NameCategory = "Twitter"
            ElseIf ChoiceType = ChoiceType.Telephone Then
                Entity.NameCategory = "Telephone"
            End If
            Return Entity
        End Function
        Sub ToEnity(Of DTO)(DTOLink As DTO, ByRef Entity As My.Entity.Entity, ChoiceType As ChoiceType)
            If GetType(DTO) = GetType(Contracts.IRegisterContact) Then
                Dim Register As Contracts.IRegisterContact = DTOLink
                With Entity
                    .ExternalID = Register.ExternalID
                    .Value = Register.Value
                    .Description = Register.Description
                End With
            ElseIf GetType(DTO) = GetType(Contracts.IChancheContact) Then
                Dim Change As Contracts.IChancheContact = DTOLink
                With Entity

                    .Value = Change.Value
                    .Description = Change.Description
                End With
            End If
            If ChoiceType = ChoiceType.None Then
            ElseIf ChoiceType = ChoiceType.Email Then
                Entity.NameCategory = "Email"
            ElseIf ChoiceType = ChoiceType.Facebook Then
                Entity.NameCategory = "Facebook"
            ElseIf ChoiceType = ChoiceType.Instagram Then
                Entity.NameCategory = "Instagram"
            ElseIf ChoiceType = ChoiceType.TikTok Then
                Entity.NameCategory = "TikTok"
            ElseIf ChoiceType = ChoiceType.Twitter Then
                Entity.NameCategory = "Twitter"
            ElseIf ChoiceType = ChoiceType.Telephone Then
                Entity.NameCategory = "Telephone"
            End If
        End Sub
    End Class
End Namespace

