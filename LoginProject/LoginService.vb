Imports MyBook
Namespace Service
    Public Class LoginService
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, My.Entity.Entity, LoginProject.Repositories.LoginRepository)

        Function Login(LoginDTO As Contracts.ILoginDTO) As MyBook.ValMsg(Of Contracts.IModel)
            Dim Result As New ValMsg(Of Contracts.IModel)
            If Repository.ExistByCreteria(LoginDTO) Then
                Result.Success = True
                Result.Msg = "Βρέθηκε ο Χρήστης."
                Result.Model = ToModel(Repository.Find(LoginDTO))
                Return Result
            End If

            Result.Success = False
            Result.Msg = "Δεν Βρέθηκε ο χρήστης!"
            Return Result
        End Function
        Public Overrides Function Change(Of DTO)(Ref As Contracts.Contracts, ChangeDTO As DTO) As ValMsg
            Dim Val As New MyBook.ValMsg
            If TypeOf ChangeDTO Is My.Ables.IUserName Then
                Console.WriteLine("True")
                Dim ChangeDTOLink As My.Ables.IUserName = ChangeDTO
                If Repository.ExistByUsername(ChangeDTOLink.Username) Then
                    With Val
                        .Success = False
                        .Msg = "Παρακαλώ άλλαξε Username!"
                    End With
                    Return Val
                End If
            End If
            Return MyBase.Change(Ref, ChangeDTO)
        End Function
        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As ValMsg(Of Contracts.Contracts)
            Dim LinkRegisterDTO As Contracts.IRegisterDTO = RegisterDTO
            Dim Val As New MyBook.ValMsg(Of Contracts.Contracts)
            If Repository.ExistByUsername(LinkRegisterDTO.Username) Then
                With Val
                    .Success = False
                    .Msg = "Παρακαλώ άλλαξε Username!"
                End With
                Return Val
            End If
            Return MyBase.Register(RegisterDTO)
        End Function
        Sub New()
            MyBase.New(New Repositories.LoginRepository)
        End Sub

        Public Overrides Function ToModel(Entity As My.Entity.Entity) As Contracts.Contracts
            Dim Model As Contracts.IModel = New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Username = Entity.Username
                .Password = Entity.Password
                .CreateAt = Entity.CreateAt
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Entity.Entity
            Dim Entity As New My.Entity.Entity


            If GetType(DTO) Is GetType(Contracts.ILoginDTO) Then
                Dim Obj As Contracts.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Obj As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeNameDTO) Then
                Dim Obj As Contracts.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangePasswordDTO) Then
                Dim Obj As Contracts.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As Contracts.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Entity.Entity) As My.Entity.Entity
            If GetType(DTO) Is GetType(Contracts.ILoginDTO) Then
                Dim Obj As Contracts.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim Obj As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeNameDTO) Then
                Dim Obj As Contracts.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangePasswordDTO) Then
                Dim Obj As Contracts.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As Contracts.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function
    End Class

End Namespace