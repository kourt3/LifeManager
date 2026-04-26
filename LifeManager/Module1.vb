Module Module1
    Public ProfileController As New ProfileComponent.Controller
    Public TransferService As New Economy.TransferProject.Service.TransferService
    Public Contact As New ContactsProject.Service.Service
    Public AddressController As New AdressesProject.AddressesController
    Public EconomyController As New Economy.Controller.Controller(Of ProfileComponent.Profile.Able.IReference)
    Public TransferController As New Economy.TransferController(TransferService)
    Public VehiclesController As New Vehicles.Vehicle.Controller.Controller
    Public BuildAndApartment As New BuildAndApartmentCompoent.Controller
    Public AccountController As New AccountComponent.Controller

    Sub Main()

        Console.Clear()
        Console.OutputEncoding = System.Text.Encoding.UTF8
        Do
            Dim MyAccountRef As AccountComponent.Account.Ables.IReference
            Console.Clear()
            Console.WriteLine("------ My Life Manager ------")
            Console.WriteLine("1) Είσοδος.")
            Console.WriteLine("2) Εγραφή.")
            Console.WriteLine("3) Έξοδος.")
            Console.WriteLine("----------------------------------------")
            Console.WriteLine("Επέλεξε ενα απο το Menu:")

            Dim Choice As Integer = Nothing
            If Help.Input(Choice) = False Then
                Continue Do
            End If

            Select Case Choice
                Case 1
                    Dim LoginVal As MyBook.ValMsg(Of AccountComponent.LoginProject.Contracts.IModel) = LoginModule.Login()
                    If LoginVal.Success = True Then
                        Dim Creteria As AccountComponent.Account.Contracts.ICreteria = New AccountComponent.Account.Contracts.Contracts
                        Creteria.LoginID = LoginVal.Model.PrimaryKey
                        MyAccountRef = AccountController.AccountService.Search(Creteria).Model

                        Menu(MyAccountRef)
                    End If
                Case 2
                    Dim LoginRegisterDTO As AccountComponent.LoginProject.Contracts.IRegisterDTO = New AccountComponent.LoginProject.Contracts.Contracts
                    Dim PersonRegisterDTO As ProfileComponent.PersonProject.Contracts.IRegisterDTO = New ProfileComponent.PersonProject.Contracts.Contracts
                    LoginModule.Register(LoginRegisterDTO)
                    PersonModule.Register(PersonRegisterDTO)
                    Dim ProfileModel As ProfileComponent.Model = ProfileController.AddProfile(PersonRegisterDTO).Model
                    Dim ValRegister As MyBook.ValMsg(Of AccountComponent.Account.Contracts.Contracts) = AccountController.AddAccount(LoginRegisterDTO, ProfileModel.Profile.PrimaryKey)
                    Console.Clear()
                    Console.WriteLine(ValRegister.Msg)
                    Console.ReadLine()
                Case 3
                    Exit Do
            End Select

        Loop

    End Sub


    Sub Menu(Ref As AccountComponent.Account.Ables.IReference)
        Dim ContinueMenu As Boolean = True
        Do

            Dim Opt As New List(Of String)
            Dim Action As New List(Of Action)
            Dim iamAdmin As Boolean = True

            Dim Model As AccountComponent.Account.Contracts.IModel = AccountController.AccountService.Exist(Ref).Model
            If Model Is Nothing Then
                Exit Sub
            End If

            Console.Clear()
            Console.WriteLine("------ Είσοδος System ------")
            Console.WriteLine("ID: " & Model.PrimaryKey)
            Console.WriteLine()

            Help.AddOption(Opt, Action, "Προφιλ.", Sub() ProfileModule.Menu(New ProfileComponent.Profile.Contracts.Contracts With {.PrimaryKey = Model.ToExternalID}))
            Help.AddOption(Opt, Action, "Build.", Sub() BuildingsModule.ListOfBuild(Ref))
            Help.AddOption(Opt, Action, "List Of Profiles.", Sub() ProfileModule.ListOfProfiles(Ref))
            Help.AddOption(Opt, Action, "Address.", Sub() AddressRelationShipModule.Menu())
            Help.AddOption(Opt, Action, "Διπλώματα.", Sub() Diplomata.Menu())
            Help.AddOption(Opt, Action, "Vehicles.", Sub() BrandsModule.ListOfBrands())
            Help.AddOption(Opt, Action, "Διαχήρηση Είσοδου.", Sub() LoginModule.Menu(New AccountComponent.LoginProject.Contracts.Contracts With {.PrimaryKey = Model.LoginID}))
            Help.AddOption(Opt, Action, "Διαγραφή Λογαρισμού.", Sub() RemoveAcc(Model))
            Help.AddOption(Opt, Action, "Exit.", Sub() ContinueMenu = False)
            Help.PrintMenu(Opt)

            Dim Str As Integer = Nothing
            If Not Help.Input(Str) Then
                Continue Do
            End If

            Select Case Str
                Case 1 To Opt.Count
                    Action(Str - 1).Invoke
                Case Else
                    Continue Do
            End Select

        Loop While ContinueMenu = True

    End Sub
    Friend Sub RemoveAcc(Ref As MyBook.IHasPrimaryKey(Of Integer))

    End Sub
End Module
