Namespace EconomyProject.Services
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contact, EconomyProject.Entity.Entity, Repositories.Repository)

        Sub New()
            MyBase.New(New Repositories.Repository)
        End Sub

        Public Function Find(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of Contracts.IModel)
            Dim Val As New MyBook.ValMsg(Of Contracts.IModel)
            Dim Entity As EconomyProject.Entity.IEntity = Repository.Find(Creteria)
            If Entity IsNot Nothing Then
                Val.Success = True
                Val.Msg = "Βρέθηκε η εγραφή!"
                Val.Model = ToModel(Entity)
                Return Val
            Else
                Val.Success = False
                Val.Msg = "Δεν Βρέθηκε η εγραφή!"
                Return Val
            End If
        End Function
        Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))

            Dim Entity As List(Of EconomyProject.Entity.Entity) = Repository.Search(Function(X)
                                                                                        If X.ExternalID = Creteria.ExternalID Then
                                                                                            Return True
                                                                                        End If
                                                                                        Return False
                                                                                    End Function)
            If Entity.Count > 0 Then
                Val.Success = True
                Val.Model = New List(Of Contracts.IModel)
                Val.Msg = "Βρέθηκε η εγραφή!"
                For Each model In Entity
                    Val.Model.Add(ToModel(model))
                Next
                Return Val
            Else
                Val.Success = False
                Val.Msg = "Δεν Βρέθηκε η εγραφή!"
                Return Val
            End If
        End Function

        Public Overrides Function ToModel(Entity As EconomyProject.Entity.Entity) As Contracts.Contact
            Dim Model As Contracts.IModel = New Contracts.Contact

            With Model
                .PrimaryKey = Entity.PrimaryKey
                .ToExternalID = Entity.ToExternalID
                .Category = Entity.Category
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As EconomyProject.Entity.Entity
            Dim Entity As EconomyProject.Entity.IEntity = New EconomyProject.Entity.Entity
            Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
            With Entity
                .ExternalID = RegisterDTO.ExternalID
                .ToExternalID = RegisterDTO.ToExternalID
                .Category = RegisterDTO.Category
            End With

            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As EconomyProject.Entity.Entity) As EconomyProject.Entity.Entity

            Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
            With Entity
                .ExternalID = RegisterDTO.ExternalID
                .ToExternalID = RegisterDTO.ToExternalID
                .Category = RegisterDTO.Category
            End With

            Return Entity
        End Function
    End Class
End Namespace

