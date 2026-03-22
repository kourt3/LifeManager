Namespace TransferProject.Service
    Public Class TransferService
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contract, Entity.Entity, Repository.TransferRepository)



        Sub New()
            MyBase.New(New Repository.TransferRepository)
        End Sub

        Function Search(Creteria As Contracts.ICreateria) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Model = New List(Of Contracts.IModel)


            If Creteria.FromPartEconomyID <> 0 And Creteria.FromCategory IsNot Nothing And Creteria.ToPartEconomyID <> 0 And Creteria.ToCategory IsNot Nothing Then
                For Each EntityL In Repository.Search(Creteria)
                    Val.Success = True
                    Val.Msg = "Βρέθηκαν Εγραφές!"
                    Val.Model.Add(ToModel(EntityL))
                Next
            ElseIf Creteria.FromPartEconomyID <> 0 And Creteria.FromCategory IsNot Nothing And Creteria.ToPartEconomyID = 0 And Creteria.ToCategory Is Nothing Then
                For Each EntityL In Repository.Search(Function(X As Economy.TransferProject.Entity.Entity)
                                                          If X.FromPartEconomyID <> Creteria.FromPartEconomyID Then Return False
                                                          If X.FromCategory <> Creteria.FromCategory Then Return False
                                                          Return True
                                                      End Function)
                    Val.Success = True
                    Val.Msg = "Βρέθηκαν Εγραφές!"
                    Val.Model.Add(ToModel(EntityL))
                Next
            ElseIf Creteria.FromPartEconomyID = 0 And Creteria.FromCategory Is Nothing And Creteria.ToPartEconomyID <> 0 And Creteria.ToCategory IsNot Nothing Then
                For Each EntityL In Repository.Search(Function(X As Economy.TransferProject.Entity.Entity)
                                                          If X.ToPartEconomyID <> Creteria.ToPartEconomyID Then Return False
                                                          If X.ToCategory <> Creteria.ToCategory Then Return False
                                                          Return True
                                                      End Function)
                    Val.Success = True
                    Val.Msg = "Βρέθηκαν Εγραφές!"
                    Val.Model.Add(ToModel(EntityL))
                Next
            End If


            If Val.Success = False Then
                Val.Msg = "Δεν Βρέθηκαν Εγραφές!"
            End If
            Return Val
        End Function
        Function Search(Creteria As Contracts.ICreteriaWhere) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Model = New List(Of Contracts.IModel)
            For Each Entities In Repository.Search(Function(X As Entity.Entity)
                                                       If X.FromCategory = Creteria.Category And X.FromPartEconomyID = Creteria.PartEconomyId Then Return True Else
                                                       If X.ToCategory = Creteria.Category And X.ToPartEconomyID = Creteria.PartEconomyId Then Return True
                                                       Return False
                                                   End Function)
                Val.Success = True
                Val.Msg = "Βρέθηκαν εγραφές!"
                Val.Model.Add(ToModel(Entities))

            Next

            If Val.Success = False Then
                Val.Msg = "Δεν Βρέθηκαν εγραφές!"
            End If
            Return Val
        End Function


        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracts.Contract
            Dim model As Contracts.IModel = New Contracts.Contract
            With model
                .PrimaryKey = Entity.PrimaryKey
                .CreateAt = Entity.CreateAt
                .FromEconomyID = Entity.FromEconomyID
                .FromCategory = Entity.FromCategory
                .FromPartEconomyID = Entity.FromPartEconomyID
                .MoneyValue = Entity.MoneyValue
                .ToEconomyID = Entity.ToEconomyID
                .ToCategory = Entity.ToCategory
                .ToPartEconomyID = Entity.ToPartEconomyID
                .Description = Entity.Description
            End With
            Return model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ToEconomyID = Register.ToEconomyID
                    .ToCategory = Register.ToCategory
                    .ToPartEconomyID = Register.ToPartEconomyID
                    .FromEconomyID = Register.FromEconomyID
                    .FromCategory = Register.FromCategory
                    .FromPartEconomyID = Register.FromPartEconomyID
                    .MoneyValue = Register.MoneyValue
                    .Description = Register.Description
                    .CreateAt = Register.CreateAt
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim CDescription As Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = CDescription.Description
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeMoney) Then
                Dim CMoney As Contracts.IChangeMoney = DTOLink
                With Entity
                    .MoneyValue = CMoney.MoneyValue
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Register As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .FromEconomyID = Register.FromEconomyID
                    .FromCategory = Register.FromCategory
                    .ToCategory = Register.ToCategory
                    .ToEconomyID = Register.ToEconomyID
                    .ToPartEconomyID = Register.ToPartEconomyID
                    .FromPartEconomyID = Register.FromPartEconomyID
                    .MoneyValue = Register.MoneyValue
                    .Description = Register.Description
                    .CreateAt = Register.CreateAt
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescriptionDTO) Then
                Dim CDescription As Contracts.IChangeDescriptionDTO = DTOLink
                With Entity
                    .Description = CDescription.Description
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeMoney) Then
                Dim CMoney As Contracts.IChangeMoney = DTOLink
                With Entity
                    .MoneyValue = CMoney.MoneyValue
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

