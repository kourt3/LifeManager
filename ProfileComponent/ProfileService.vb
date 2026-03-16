Public Class ProfileService
    Inherits ServiceProject.Service(Of Integer, Contracts.Contracts, My.Entity.Entity, Repository.ProfileRepository)

    Private PersonService As New PersonProject.Service.PersonService
    Private EcononomyService As New EconomyComponent.Service.EconomyService

    Sub New(PersonServiceLink As PersonProject.Service.PersonService, EconomyServiceLink As EconomyComponent.Service.EconomyService)
        MyBase.New(New Repository.ProfileRepository)
        PersonService = PersonServiceLink
        EcononomyService = EconomyServiceLink
    End Sub
    Sub New()
        MyBase.New(New Repository.ProfileRepository)
        PersonService = New PersonProject.Service.PersonService
        EcononomyService = New EconomyComponent.Service.EconomyService
    End Sub
    Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Contracts)
        Dim Val As New MyBook.ValMsg(Of Contracts.Contracts)
        Dim ProfileRegister As Contracts.IProfileRegisterDTO = New Contracts.Contracts
        Dim ValPersonRegister As New MyBook.ValMsg(Of PersonProject.Contracts.Contracts)
        If GetType(DTO) Is GetType(PersonProject.Contracts.IRegisterDTO) Then
            ValPersonRegister = PersonService.Register(RegisterDTO)
            If ValPersonRegister.Success = False Then
                Val.Success = False
                Val.Msg = ValPersonRegister.Msg
                Return Val
            End If
            ProfileRegister.PersonRef.PrimaryKey = ValPersonRegister.Model.PrimaryKey
        End If

        Val = MyBase.Register(ProfileRegister)
        If Val.Success = False Then
            PersonService.Remove(ValPersonRegister.Model)
            Return Val
        End If
        Dim EconomyRegisterDTO As EconomyComponent.Contracts.IRegisterDTO = New EconomyComponent.Contracts.Contracts
        EconomyRegisterDTO.ExternalID = Val.Model.PrimaryKey
        Dim ValEconomy As MyBook.ValMsg(Of EconomyComponent.Contracts.Contracts) = EcononomyService.Register(EconomyRegisterDTO)
        If ValEconomy.Success = False Then
            PersonService.Remove(ValPersonRegister.Model)
            MyBase.Remove(Val.Model)
            Val.Success = False
            Val.Msg = ValEconomy.Msg
            Return Val
        End If
        Return Val
    End Function

    Public Overrides Function Change(Of DTO)(Ref As Contracts.Contracts, ChangeDTO As DTO) As MyBook.ValMsg
        Dim Result As New MyBook.ValMsg
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = MyBase.Exist(Ref)
        If Val.Success = False Then
            Result.Success = False
            Result.Msg = Val.Msg
            Return Result
        End If
        If GetType(DTO) Is GetType(PersonProject.Contracts.IChangeFirstNameDTO) Or GetType(DTO) Is GetType(PersonProject.Contracts.IChangeSecondNameDTO) Or GetType(DTO) Is GetType(PersonProject.Contracts.IChangeFirstNameAndSecondNameDTO) Or GetType(DTO) Is GetType(PersonProject.Contracts.IBirthDay) Then
            Return PersonService.Change(Of DTO)(Val.Model.PersonRef, ChangeDTO)
        End If
        Result.Success = False
        Result.Msg = "Δεν ηταν Αποδεχτά τα Attributes!"
        Return Result
    End Function

    Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
        Dim Model As Contracts.IModel = New Contracts.Contracts
        With Model
            .PrimaryKey = Entity.PrimaryKey
            .PersonModel = PersonService.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Entity.PersonId}).Model

        End With
        Return Model
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
        Dim Entity As New My.Entity.Entity
        If GetType(DTO) Is GetType(Contracts.IProfileRegisterDTO) Then
            Dim PersonDTO As Contracts.IProfileRegisterDTO = DTOLink
            With Entity
                .PersonId = PersonDTO.PersonRef.PrimaryKey
            End With
        End If
        Return Entity
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
        If GetType(DTO) Is GetType(Contracts.IProfileRegisterDTO) Then
            Dim PersonDTO As Contracts.IProfileRegisterDTO = DTOLink
            With Entity
                .PersonId = PersonDTO.PersonRef.PrimaryKey
            End With
        End If
        Return Entity
    End Function
End Class
