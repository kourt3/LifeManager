Public Class AcountService
    Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, My.Entity.Entity, AcountRepository)

    Private LoginService As LoginProject.Service.LoginService
    Private PersonService As PersonProject.Service.PersonService
    Private FamilyService As FamilyProject.Service.Service
    Sub New(LoginServiceLink As LoginProject.Service.LoginService, PersonServiceLink As PersonProject.Service.PersonService, FamilyServiceLink As FamilyProject.Service.Service)
        MyBase.New(New AcountRepository)
        LoginService = LoginServiceLink
        PersonService = PersonServiceLink
        FamilyService = FamilyServiceLink
    End Sub
    Sub New()
        MyBase.New(New AcountRepository)
        LoginService = New LoginProject.Service.LoginService
        PersonService = New PersonProject.Service.PersonService
        FamilyService = New FamilyProject.Service.Service(PersonService)
    End Sub
    Public Overrides Function Change(Of DTO)(Ref As Contracts.Contracts, ChangeDTO As DTO) As MyBook.ValMsg
        Dim Result As New MyBook.ValMsg
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = MyBase.Exist(Ref)
        If Val.Success = False Then
            Result.Success = False
            Result.Msg = Val.Msg
            Return Result
        End If
        If GetType(DTO) Is GetType(LoginProject.Contracts.IChangeNameDTO) Or GetType(DTO) Is GetType(LoginProject.Contracts.IChangePasswordDTO) Or GetType(DTO) Is GetType(LoginProject.Contracts.IChangeUsernameAndPasswordDTO) Then
            Return LoginService.Change(Of DTO)(Val.Model.LoginRef, ChangeDTO)
        End If
        Result.Success = False
        Result.Msg = "Δεν ηταν Αποδεχτά τα Attributes!"
        Return Result
    End Function
    Public Overrides Function Remove(Ref As Contracts.Contracts) As MyBook.ValMsg
        Dim Val As MyBook.ValMsg(Of Contracts.Contracts) = MyBase.Exist(Ref)
        Dim Result As New MyBook.ValMsg
        If LoginService.Remove(Val.Model.LoginRef).Success = False Then
            Result.Success = False
            Result.Msg = "Δεν Μπόρεσε να διαγραφή λόγο Login"
            Return Result
        End If
        If PersonService.Remove(Val.Model.LoginRef).Success = False Then
            Result.Success = False
            Result.Msg = "Δεν Μπόρεσε να διαγραφή λόγο Person"
            Return Result
        End If
        Return MyBase.Remove(Ref)
    End Function
    Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Contracts)
        Dim Result As New MyBook.ValMsg(Of Contracts.Contracts)
        Dim RegisterLink As Contracts.ILoginAndPersonRegisterDTO = RegisterDTO
        Dim LoginVal As MyBook.ValMsg(Of LoginProject.Contracts.Contracts) = LoginService.Register(Of LoginProject.Contracts.IRegisterDTO)(RegisterLink.LoginDTO)
        If LoginVal.Success = False Then
            Result.Success = False
            Result.Msg = LoginVal.Msg
            Return Result
        End If
        Dim AcountRegisterDTO As Contracts.IAcountRegisterDTO = New Contracts.Contracts
        AcountRegisterDTO.LoginRef = LoginVal.Model
        Dim PersonVal As MyBook.ValMsg(Of PersonProject.Contracts.Contracts) = PersonService.Register(Of PersonProject.Contracts.IRegisterDTO)(RegisterLink.PersonDTO)
        If PersonVal.Success = False Then
            Result.Success = False
            Result.Msg = PersonVal.Msg
            LoginService.Remove(LoginVal.Model)
            Return Result
        End If
        AcountRegisterDTO.PersonRef = PersonVal.Model
        Dim FamilyregisterDTO As FamilyProject.Contracts.IRegisterDTO = New FamilyProject.Contracts.Contracts
        With FamilyregisterDTO
            .Mother = 0
            .Father = 0
            .Husband = 0
            .MePersonID = PersonVal.Model.PrimaryKey
        End With
        AcountRegisterDTO.FamilyRef = FamilyService.Register(FamilyregisterDTO).Model
        Return MyBase.Register(AcountRegisterDTO)

    End Function

    Public Function RegisterWithoutLogin(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of Contracts.Contracts)
        Dim Result As New MyBook.ValMsg(Of Contracts.Contracts)
        Dim RegisterLink As Contracts.ILoginAndPersonRegisterDTO = RegisterDTO
        Dim AcountRegisterDTO As Contracts.IAcountRegisterDTO = New Contracts.Contracts
        Dim PersonVal As MyBook.ValMsg(Of PersonProject.Contracts.Contracts) = PersonService.Register(Of PersonProject.Contracts.IRegisterDTO)(RegisterLink.PersonDTO)
        If PersonVal.Success = False Then
            Result.Success = False
            Result.Msg = PersonVal.Msg
            Return Result
        End If
        AcountRegisterDTO.PersonRef = PersonVal.Model
        Dim FamilyregisterDTO As FamilyProject.Contracts.IRegisterDTO = New FamilyProject.Contracts.Contracts
        With FamilyregisterDTO
            .Mother = 0
            .Father = 0
            .Husband = 0
            .MePersonID = PersonVal.Model.PrimaryKey
        End With
        AcountRegisterDTO.FamilyRef = FamilyService.Register(FamilyregisterDTO).Model

        Return MyBase.Register(AcountRegisterDTO)
    End Function

    Public Function Search(Creteria As Contracts.ICreteria) As MyBook.ValMsg(Of Contracts.IModel)
        Dim Result As New MyBook.ValMsg(Of Contracts.IModel)
        Result.Success = False
        Result.Msg = "Δεν Βρεθηκε Εγραφή!"

        For Each Entity In Repository.Read_All
            If Entity.LoginID = Creteria.LoginRef.PrimaryKey Or Creteria.PersonRef.PrimaryKey = Entity.PersonID Or Entity.FamilyID = Creteria.FamilyRef.PrimaryKey Then
                Result.Success = True
                Result.Msg = "Βρέθηκε ο Χρήστης"
                Result.Model = ToModel(Entity)
            End If
        Next
        Return Result
    End Function
    Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
        Dim Model As Contracts.IModel = New Contracts.Contracts
        Model.LoginModel = LoginService.Exist(New LoginProject.Contracts.Contracts With {.PrimaryKey = Entity.LoginID}).Model
        Model.PersonModel = PersonService.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Entity.PrimaryKey}).Model
        Model.FamilyModel = FamilyService.Exist(New FamilyProject.Contracts.Contracts With {.PrimaryKey = Entity.FamilyID}).Model
        Model.PrimaryKey = Entity.PrimaryKey
        Return Model
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
        Dim Entity As New My.Entity.Entity
        If GetType(DTO) Is GetType(Contracts.IAcountRegisterDTO) Then
            Dim AcountRegisterDTO As Contracts.IAcountRegisterDTO = DTOLink
            With Entity
                .LoginID = AcountRegisterDTO.LoginRef.PrimaryKey
                .PersonID = AcountRegisterDTO.PersonRef.PrimaryKey
                .FamilyID = AcountRegisterDTO.FamilyRef.PrimaryKey
            End With
        End If
        Return Entity
    End Function

    Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
        If GetType(DTO) Is GetType(Contracts.IAcountRegisterDTO) Then
            Dim AcountRegisterDTO As Contracts.IAcountRegisterDTO = DTOLink
            With Entity
                .LoginID = AcountRegisterDTO.LoginRef.PrimaryKey
                .PersonID = AcountRegisterDTO.PersonRef.PrimaryKey
                .FamilyID = AcountRegisterDTO.FamilyRef.PrimaryKey
            End With
        End If
        Return Entity
    End Function
End Class
