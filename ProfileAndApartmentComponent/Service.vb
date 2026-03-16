Namespace Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, My.Entity.Entity, Repository.Repository)

        Private BuildService As Buildings.Service.Service
        Private ApartmentService As Apartment.Service.Service

        Sub New(BuildServiceLink As Buildings.Service.Service, ApartmentServiceLink As Apartment.Service.Service)
            MyBase.New(New CohrabitionComponent.Repository.Repository)
            BuildService = BuildServiceLink
            ApartmentService = ApartmentServiceLink
        End Sub

        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Contracts)
            Dim Creteria As Contracts.ICreteria = New Contracts.Contracts
            Dim Result As New MyBook.ValMsg(Of Contracts.Contracts)
            Dim Reg As Contracts.IRegisterDTO = RegisterDTO

            With Creteria
                Creteria.ExternalID = Reg.ExternalID
                Creteria.ApartmentID = Reg.ApartmentID
                Creteria.BuildID = Reg.BuildID
            End With
            If Search(Creteria).Success = True Then
                Result.Success = False
                Result.Msg = "Ο Χρήστης υπάρχει Στο Ίδο Διαμέρισμα!"
                Return Result
            End If

            Return MyBase.Register(RegisterDTO)
        End Function


        Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Model = New List(Of Contracts.IModel)
            If Creteria.ExternalID <> Nothing AndAlso Creteria.ApartmentID = Nothing AndAlso Creteria.BuildID = Nothing Then
                For Each Entity In Repository.Read_All
                    If Entity.ExternalID = Creteria.ExternalID Then
                        Val.Success = True
                        Val.Msg = "Βρέθηκε η Εγραφή!"
                        Val.Model.Add(ToModel(Entity))
                    End If
                Next
            ElseIf Creteria.ExternalID = Nothing AndAlso Creteria.ApartmentID <> Nothing AndAlso Creteria.BuildID = Nothing Then
                For Each Entity In Repository.Read_All
                    If Entity.ApartmentID = Creteria.ApartmentID Then
                        Val.Success = True
                        Val.Msg = "Βρέθηκε η Εγραφή!"
                        Val.Model.Add(ToModel(Entity))
                    End If
                Next
            ElseIf Creteria.ExternalID = Nothing AndAlso Creteria.ApartmentID = Nothing AndAlso Creteria.BuildID <> Nothing Then
                For Each Entity In Repository.Read_All
                    If Entity.BuildID = Creteria.BuildID Then
                        Val.Success = True
                        Val.Msg = "Βρέθηκε η Εγραφή!"
                        Val.Model.Add(ToModel(Entity))
                    End If
                Next
            ElseIf Creteria.ExternalID <> Nothing AndAlso Creteria.ApartmentID <> Nothing AndAlso Creteria.BuildID = Nothing Then
                For Each Entity In Repository.Read_All
                    If Entity.ExternalID = Creteria.ExternalID AndAlso Entity.ApartmentID = Creteria.ApartmentID Then
                        Val.Success = True
                        Val.Msg = "Βρέθηκε η Εγραφή!"
                        Val.Model.Add(ToModel(Entity))
                    End If
                Next
            ElseIf Creteria.ExternalID = Nothing AndAlso Creteria.ApartmentID <> Nothing AndAlso Creteria.BuildID <> Nothing Then
                For Each Entity In Repository.Read_All
                    If Entity.BuildID = Creteria.BuildID AndAlso Entity.ApartmentID = Creteria.ApartmentID Then
                        Val.Success = True
                        Val.Msg = "Βρέθηκε η Εγραφή!"
                        Val.Model.Add(ToModel(Entity))
                    End If
                Next
            ElseIf Creteria.ExternalID <> Nothing AndAlso Creteria.ApartmentID = Nothing AndAlso Creteria.BuildID <> Nothing Then
                For Each Entity In Repository.Read_All
                    If Entity.ExternalID = Creteria.ExternalID AndAlso Entity.BuildID = Creteria.BuildID Then
                        Val.Success = True
                        Val.Msg = "Βρέθηκε η Εγραφή!"
                        Val.Model.Add(ToModel(Entity))
                    End If
                Next
            ElseIf Creteria.ExternalID <> Nothing AndAlso Creteria.ApartmentID <> Nothing AndAlso Creteria.BuildID <> Nothing Then
                For Each Entity In Repository.Read_All
                    If Entity.ExternalID = Creteria.ExternalID AndAlso Entity.BuildID = Creteria.BuildID AndAlso Entity.ApartmentID = Creteria.ApartmentID Then
                        Val.Success = True
                        Val.Msg = "Βρέθηκε η Εγραφή!"
                        Val.Model.Add(ToModel(Entity))
                    End If
                Next
            End If

            If Val.Success = False Then
                Val.Msg = "Δεν Βρέθηκε Εγραφή!"
            End If
            Return Val
        End Function
        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
            Dim Model As Contracts.IModel = New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .BuildModel = BuildService.Exist(New Buildings.Contracts.Contracts With {.PrimaryKey = Entity.BuildID}).Model
                .ApartmentModel = ApartmentService.Exist(New Apartment.Contracts.Contracts With {.PrimaryKey = Entity.ApartmentID}).Model
                .ExternalID = Entity.ExternalID
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
            Dim Entity As New My.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim DTos As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ExternalID = DTos.ExternalID
                    .BuildID = DTos.BuildID
                    .ApartmentID = DTos.ApartmentID
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity

            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim DTos As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .ExternalID = DTos.ExternalID
                    .BuildID = DTos.BuildID
                    .ApartmentID = DTos.ApartmentID
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

