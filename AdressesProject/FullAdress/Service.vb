Namespace FullAdress.Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, FullAdress.Contracts.Contracts, My.Entity.Entity, Repository)

        Sub New()
            MyBase.New(New Repository)
        End Sub

        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Contracts)
            Dim Val As New MyBook.ValMsg(Of Contracts.Contracts)
            Dim Creteria As Contracts.ICreteriaFullAdress = New Contracts.Contracts
            Dim RegisterL As Contracts.IRegisterDTO = RegisterDTO
            With Creteria
                .Country = RegisterL.Country
                .Perifereia = RegisterL.Perifereia
                .Nomos = RegisterL.Nomos
                .TK = RegisterL.TK
                .Dhmos = RegisterL.Dhmos
                .Addresses = RegisterL.Addresses
                .Number = RegisterL.Number
            End With
            If Repository.Exist(Creteria) Then
                Val.Success = False
                Val.Msg = "Η εγραφη  υπάρχει!"
                Val.Model = ToModel(Repository.Find(Creteria))
                Return Val
            End If

            Return MyBase.Register(RegisterDTO)
        End Function
        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
            Dim Model As New FullAdress.Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Country = Entity.Country
                .Perifereia = Entity.Perifereia
                .Nomos = Entity.Nomos
                .TK = Entity.TK
                .Dhmos = Entity.Dhmos
                .Addresses = Entity.Addresses
                .Number = Entity.Number
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
            Dim Entity As New My.Entity.Entity
            If GetType(DTO) = GetType(FullAdress.Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Country = RegisterDTO.Country
                    .Perifereia = RegisterDTO.Perifereia
                    .Nomos = RegisterDTO.Nomos
                    .TK = RegisterDTO.TK
                    .Dhmos = RegisterDTO.Dhmos
                    .Addresses = RegisterDTO.Addresses
                    .Number = RegisterDTO.Number
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity

            If GetType(DTO) = GetType(FullAdress.Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Country = RegisterDTO.Country
                    .Perifereia = RegisterDTO.Perifereia
                    .Nomos = RegisterDTO.Nomos
                    .TK = RegisterDTO.TK
                    .Dhmos = RegisterDTO.Dhmos
                    .Addresses = RegisterDTO.Addresses
                    .Number = RegisterDTO.Number
                End With
            End If
            Return Entity
        End Function
    End Class

End Namespace
