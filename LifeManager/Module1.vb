Module Module1
    Public LoginService As New LoginProject.Service.LoginService
    Public PersonService As New PersonProject.Service.PersonService
    Public TransferService As New Economy.TransferProject.Service.TransferService
    Public Apartnment As New Apartment.Service.Service
    Public Buildings As New Buildings.Service.Service
    Public RelationShip As New RelationShipComponent.Service
    Public Family As New FamilyProject.Service.Service(PersonService)
    Public Contact As New ContactsProject.Service.Service

    Public EconomyController As New Economy.Controller.Controller(Of AccountComponent.Contracts.IReference)
    Public TransferController As New Economy.TransferController(TransferService)


    Public ProfileAndApartments As New CohrabitionComponent.Service.Service(Buildings, Apartnment)
    Public AccountService As New AccountComponent.AcountService(LoginService, PersonService, Family)



    Sub Main()

        Dim DTO As AccountComponent.Contracts.ILoginAndPersonRegisterDTO = New AccountComponent.Contracts.Contracts
        DTO.LoginDTO.Username = "paok"
        DTO.LoginDTO.Password = "paok"
        DTO.PersonDTO.FristName = "Dimitrios"
        DTO.PersonDTO.SecondName = "Kourtesis"
        DTO.PersonDTO.Birthday = "23/06/1995"
        Dim Model As AccountComponent.Contracts.IModel = AccountService.Register(DTO).Model
        Dim EconomyDTO As Economy.Portofolio.Contracts.IRegisterDTO = New Economy.Portofolio.Contracts.Contract
        With EconomyDTO
            .Name = "Spiti"
            .Description = "Apo to spiti"
        End With
        EconomyController.AddPortofolio(Model, EconomyDTO)


        DTO.LoginDTO.Username = "Pablos"
        DTO.LoginDTO.Password = "Kourtesis"
        DTO.PersonDTO.FristName = "Pavlos"
        DTO.PersonDTO.SecondName = "Kourtesis"
        DTO.PersonDTO.Birthday = "23/06/1997"
        Model = AccountService.Register(DTO).Model


        With EconomyDTO
            .Name = "Spiti1"
            .Description = "Apo to spiti1"
        End With

        EconomyController.AddPortofolio(Model, EconomyDTO)



        Console.Clear()
        Console.OutputEncoding = System.Text.Encoding.UTF8
        Do
            Dim MyAccountRef As AccountComponent.Contracts.IReference
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
                    Dim LoginVal As MyBook.ValMsg(Of LoginProject.Contracts.IModel) = LoginModule.Login()
                    If LoginVal.Success = True Then
                        Dim Creteria As AccountComponent.Contracts.ICreteria = New AccountComponent.Contracts.Contracts
                        Creteria.LoginRef = LoginVal.Model
                        MyAccountRef = AccountService.Search(Creteria).Model
                        Menu(MyAccountRef)
                    End If
                Case 2
                    Dim AccounRegister As AccountComponent.Contracts.ILoginAndPersonRegisterDTO = New AccountComponent.Contracts.Contracts
                    LoginModule.Register(AccounRegister.LoginDTO)
                    PersonModule.Register(AccounRegister.PersonDTO)
                    Dim ValRegister As MyBook.ValMsg(Of AccountComponent.Contracts.Contracts) = AccountService.Register(AccounRegister)
                    Console.Clear()
                    Console.WriteLine(ValRegister.Msg)
                    Console.ReadLine()
                Case 3
                    Exit Do
            End Select

        Loop

    End Sub


    Sub Menu(Ref As AccountComponent.Contracts.IReference)
        Dim ContinueMenu As Boolean = True
        Do

            Dim Opt As New List(Of String)
            Dim Action As New List(Of Action)
            Dim iamAdmin As Boolean = True

            Dim Model As AccountComponent.Contracts.IModel = AccountService.Exist(Ref).Model
            If Model Is Nothing Then
                Exit Sub
            End If
            Console.Clear()
            Console.WriteLine("------ Είσοδος System ------")
            Console.WriteLine("ID: " & Model.PrimaryKey)
            Console.WriteLine()

        Help.AddOption(Opt, Action, "Προφιλ.", Sub() ProfileModule.Menu(Model))
            Help.AddOption(Opt, Action, "Build.", Sub() BuildingsModule.ListOfBuild(Ref))
            Help.AddOption(Opt, Action, "List Of Profiles.", Sub() ProfileModule.ListOfProfiles(Ref))
            Help.AddOption(Opt, Action, "Διαχήρηση Είσοδου.", Sub() LoginModule.Menu(Model.LoginModel))
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
    Friend Sub RemoveAcc(Ref As AccountComponent.Contracts.IReference)

    End Sub
End Module
