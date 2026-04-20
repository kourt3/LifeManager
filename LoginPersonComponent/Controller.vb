Public Class Controller
    Public AccountService As New AccountComponent.Account.Service.AcountService
    Public LoginService As New LoginProject.Service.LoginService

    Function AddAccount(RegisterDTO As LoginProject.Contracts.IRegisterDTO, ExternalID As Integer) As MyBook.ValMsg(Of Account.Contracts.Contracts)
        Dim LoginVal As MyBook.ValMsg(Of LoginProject.Contracts.Contracts) = LoginService.Register(RegisterDTO)

        Dim AccountRegisterDTO As Account.Contracts.IRegisterDTO = New Account.Contracts.Contracts
        AccountRegisterDTO.LoginID = LoginVal.Model.PrimaryKey
        AccountRegisterDTO.ToExternalID = ExternalID

        Return AccountService.Register(AccountRegisterDTO)
    End Function

    Overloads Function ExistAccountBy(LoginRef As MyBook.IHasPrimaryKey(Of Integer)) As MyBook.ValMsg(Of Account.Contracts.IModel)
        Dim Creteria As Account.Contracts.ICreteria = New Account.Contracts.Contracts
        Creteria.LoginID = LoginRef.PrimaryKey
        Return AccountService.Search(Creteria)
    End Function

    Overloads Function ExistAccountBy(ExternalId As Integer) As MyBook.ValMsg(Of Account.Contracts.IModel)
        Dim Creteria As Account.Contracts.ICreteria = New Account.Contracts.Contracts
        Creteria.ToExternalID = ExternalId
        Return AccountService.Search(Creteria)
    End Function

    Function RemoveAccount(AccountRef As MyBook.IHasPrimaryKey(Of Integer)) As MyBook.ValMsg
        Dim LoginRef As MyBook.IHasPrimaryKey(Of Integer) = New LoginProject.Contracts.Contracts
        Dim AccountVal As MyBook.ValMsg(Of Account.Contracts.Contracts) = AccountService.Exist(AccountRef)
        LoginRef.PrimaryKey = AccountVal.Model.PrimaryKey
        Dim LoginVal As MyBook.ValMsg = LoginService.Remove(LoginRef)
        If LoginVal.Success = False Then
            Return LoginVal
        End If

        Return AccountService.Remove(AccountRef)
    End Function
End Class
