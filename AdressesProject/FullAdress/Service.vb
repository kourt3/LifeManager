Namespace FullAdress.Service

    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, FullAdress.Contracts.Model, My.Entity.Entity, Repository)

        Dim Country As AdressesProject.Service
        Dim Perifereia As AdressesProject.Service
        Dim Nomoi As AdressesProject.Service
        Dim TK As AdressesProject.Service
        Dim Dhmoi As AdressesProject.Service
        Dim Address As AdressesProject.Service
        Dim Number As AdressesProject.Service

        Sub New(CountryServ As AdressesProject.Service, PerifereiaServ As AdressesProject.Service, NomoiServ As AdressesProject.Service,
                TKServ As AdressesProject.Service, DhmoiServ As AdressesProject.Service, AddressServ As AdressesProject.Service, NumberServ As AdressesProject.Service)
            MyBase.New(New Repository)
            Country = CountryServ
            Perifereia = PerifereiaServ
            Nomoi = NomoiServ
            TK = TKServ
            Dhmoi = DhmoiServ
            Address = AddressServ
            Number = NumberServ
        End Sub

        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Model)
            Dim Val As New MyBook.ValMsg(Of Contracts.Model)
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
        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Model
            Dim Model As New FullAdress.Contracts.Model
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Country = Country.Exist(New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.Country}).Model
                .Perifereia = Perifereia.Exist(New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.Perifereia}).Model
                .Nomos = Nomoi.Exist(New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.Nomos}).Model
                .TK = TK.Exist(New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.TK}).Model
                .Dhmos = Dhmoi.Exist(New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.Dhmos}).Model
                .Addresses = Address.Exist(New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.Addresses}).Model
                .Number = Number.Exist(New Adresses.Contracts.Contracts With {.PrimaryKey = Entity.Number}).Model
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
