Imports ProfileComponent
Namespace Account.Service
    Public Class AcountService
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, Account.Entity.Entity, Account.Repository.AccountDatabaseRepository)
        Sub New()
            MyBase.New(New Account.Repository.AccountDatabaseRepository)
        End Sub

        Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of Contracts.IModel)
            Dim Result As New MyBook.ValMsg(Of Contracts.IModel)
            Result.Success = False
            Result.Msg = "Δεν Βρεθηκε Εγραφή!"

            For Each EntityL In Repository.Read_All
                If EntityL.LoginID = Creteria.LoginID Or Creteria.ToExternalID = EntityL.ToExternalID Then
                    Result.Success = True
                    Result.Msg = "Βρέθηκε ο Χρήστης"
                    Result.Model = ToModel(EntityL)
                End If
            Next
            Return Result
        End Function
        Public Overrides Function ToModel(Entity As Account.Entity.Entity) As Contracts.Contracts
            Dim Model As Contracts.IModel = New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .LoginID = Entity.LoginID
                .ToExternalID = Entity.ToExternalID
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Account.Entity.Entity
            Dim Entity As New Account.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim AcountRegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .LoginID = AcountRegisterDTO.LoginID
                    .ToExternalID = AcountRegisterDTO.ToExternalID
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Account.Entity.Entity) As Account.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim AcountRegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .LoginID = AcountRegisterDTO.LoginID
                    .ToExternalID = AcountRegisterDTO.ToExternalID
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

