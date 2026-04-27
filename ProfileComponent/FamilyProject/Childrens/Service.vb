Namespace FamilyProject.Children.Service
    Public Class ChildrenService
        Inherits MyBook.Services.Service(Of Integer, FamilyProject.Children.Conctracts.Contracts, FamilyProject.Children.Entity.Entity, Children.Repository.DataRepository)
        Sub New(PersonLinkService As PersonProject.Service.PersonService)
            MyBase.New(New Children.Repository.DataRepository)
        End Sub
        Public Function Search(Creteria As FamilyProject.Children.Conctracts.ICreteria) As MyBook.ValMsg(Of List(Of FamilyProject.Children.Conctracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of FamilyProject.Children.Conctracts.IModel))
            Val.Model = New List(Of FamilyProject.Children.Conctracts.IModel)
            Val.Success = False
            Val.Msg = "Δεν Βρέθηκε Εγραφή!"

            For Each ChildEntity In Repository.Read_All
                If Creteria.FamilyID = Nothing And Creteria.ToExternalID <> Nothing Then
                    If Creteria.ToExternalID = ChildEntity.ToExternalID Then
                        Val.Success = True
                        Val.Model.Add(ToModel(ChildEntity))
                    End If
                ElseIf Creteria.FamilyID <> Nothing And Creteria.ToExternalID = Nothing Then
                    If Creteria.FamilyID = ChildEntity.FamilyID Then
                        Val.Success = True
                        Val.Model.Add(ToModel(ChildEntity))
                    End If
                ElseIf Creteria.FamilyID <> Nothing And Creteria.ToExternalID <> Nothing Then
                    If Creteria.FamilyID = ChildEntity.FamilyID AndAlso Creteria.ToExternalID = ChildEntity.ToExternalID Then
                        Val.Success = True
                        Val.Model.Add(ToModel(ChildEntity))
                    End If

                End If
            Next
            If Val.Success = True Then
                Val.Msg = "Βρέθηκε Εγραφή!"
            End If
            Return Val
        End Function

        Function Find(Creteria As Children.Conctracts.ICreteria) As MyBook.ValMsg(Of Children.Conctracts.IModel)
            Dim Val As New MyBook.ValMsg(Of Children.Conctracts.IModel)
            Val.Success = False
            Val.Msg = "Δεν βρέθηκε Εγραφή!!!"
            For Each EntityL In Repository.Read_All
                If EntityL.ToExternalID = Creteria.ToExternalID And EntityL.FamilyID = Creteria.FamilyID Then
                    Val.Model = ToModel(EntityL)
                    Val.Success = True
                    Val.Msg = "Βρέθηκε Εγραφή!!!"
                    Exit For
                End If

            Next
            Return Val
        End Function

        Public Overrides Function ToModel(Entity As FamilyProject.Children.Entity.Entity) As FamilyProject.Children.Conctracts.Contracts
            Dim Model As FamilyProject.Children.Conctracts.IModel = New FamilyProject.Children.Conctracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .FamilyID = Entity.FamilyID
                .ToExternalID = Entity.ToExternalID
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As FamilyProject.Children.Entity.Entity
            Dim Entity As New FamilyProject.Children.Entity.Entity
            If GetType(DTO) = GetType(FamilyProject.Children.Conctracts.IRegister) Then
                Dim Regilser As FamilyProject.Children.Conctracts.IRegister = DTOLink
                With Entity
                    .FamilyID = Regilser.FamilyID
                    .ToExternalID = Regilser.ToExternalID
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As FamilyProject.Children.Entity.Entity) As FamilyProject.Children.Entity.Entity
            If GetType(DTO) = GetType(FamilyProject.Children.Conctracts.IRegister) Then
                Dim Regilser As FamilyProject.Children.Conctracts.IRegister = DTOLink
                With Entity
                    .FamilyID = Regilser.FamilyID
                    .ToExternalID = Regilser.ToExternalID
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

