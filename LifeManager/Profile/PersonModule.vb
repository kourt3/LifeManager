Imports ProfileComponent.PersonProject
Friend Module PersonModule
    Friend Sub Info(Model As ProfileComponent.PersonProject.Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("Firstname: " & Model.FristName)
        Console.WriteLine("Secondname: " & Model.SecondName)
        Console.WriteLine("Full name: " & Model.FullName)
        Console.WriteLine("Birdhday: " & Model.Birthday)
        Console.WriteLine("Age: " & Model.Age)

    End Sub
    Friend Sub Menu(Ref As Enity.IReference)
        Do
            Dim ValModel As MyBook.ValMsg(Of Contracts.Contracts) = ProfileController.Person.Exist(Ref)
            If ValModel.Success = False Then
                Console.WriteLine(ValModel.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Console.Clear()
            Console.WriteLine("------- Person ------")
            Info(ValModel.Model)
            Console.WriteLine()
            Console.WriteLine("--------- Menu --------")
            Console.WriteLine("1) Change Firstname")
            Console.WriteLine("2) Change Secondname")
            Console.WriteLine("3) Change Firstname and Secondname")
            Console.WriteLine("4) Change Birthday")
            '    Console.WriteLine("5) Remove Profil")
            Console.WriteLine("5) Exit.")
            Console.WriteLine("------------------")
            Console.WriteLine()
            Console.WriteLine("Επέλεξε ενα απο το Μενου:")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    ChangeFirstName(Ref)
                Case 2
                    ChangeSecondName(Ref)
                Case 3
                    ChangeFirstnameAndSecondname(Ref)
                Case 4
                    ChangeBirthday(Ref)
                'Case 5
                '    Remove(Ref)
                Case 5
                    Exit Do
            End Select

        Loop
    End Sub
    Friend Sub Register(ByRef RegisterDTO As Contracts.IRegisterDTO)
        Do
            Console.Clear()
            Console.WriteLine("------ Register Person ------")
            Console.WriteLine()
            If Not Help.IfNotInputOrMsg("FirstName: ", RegisterDTO.FristName) Then
                Continue Do
            End If

            If Not Help.IfNotInputOrMsg("SecondName: ", RegisterDTO.SecondName) Then
                Continue Do
            End If
            If Not Help.IfNotInputOrMsg("Birthday: ", RegisterDTO.Birthday) Then
                Continue Do
            End If

            Exit Do
        Loop
    End Sub
    Friend Sub ChangeFirstName(Ref As Enity.IReference)
        Dim Model As Contracts.IModel = ProfileController.Person.Exist(Ref).Model
        Console.Clear()
        Console.WriteLine("------- Person ------")
        Info(Model)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλετε να συνεχήσετε? (Αλλαγή Firstname)") Then
            Console.WriteLine("Δώσε καινουργιο όνομα:")
            Dim Change As Contracts.IChangeFirstNameDTO = New Contracts.Contracts
            Change.FristName = Console.ReadLine
            Dim Val As MyBook.ValMsg = ProfileController.Person.Change(Ref, Change)
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
        End If

    End Sub
    Friend Sub ChangeSecondName(Ref As Enity.IReference)
        Dim Model As Contracts.IModel = ProfileController.Person.Exist(Ref).Model

        Console.Clear()
        Console.WriteLine("------- Person ------")
        Info(Model)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλετε να συνεχήσετε? (Αλλαγή Secondname)") Then
            Console.WriteLine("Δώσε καινουργιο όνομα:")
            Dim Change As Contracts.IChangeSecondNameDTO = New Contracts.Contracts
            Change.SecondName = Console.ReadLine
            Console.Clear()
            Console.WriteLine(ProfileController.Person.Change(Ref, Change).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub ChangeFirstnameAndSecondname(Ref As Enity.IReference)
        Dim Model As Contracts.IModel = ProfileController.Person.Exist(Ref).Model

        Console.Clear()
        Console.WriteLine("------- Person ------")
        Info(Model)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλετε να συνεχήσετε? (Αλλαγή Firstname and Secondname)") Then
            Console.WriteLine("Δώσε καινουργιο όνομα:")
            Dim Change As Contracts.IChangeFirstNameAndSecondNameDTO = New Contracts.Contracts
            Change.FristName = Console.ReadLine
            Console.WriteLine("Δώσε καινουργιο Επίθετο:")
            Change.SecondName = Console.ReadLine
            Dim Val As MyBook.ValMsg = ProfileController.Person.Change(Ref, Change)
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
        End If

    End Sub
    Friend Sub ChangeBirthday(Ref As Enity.IReference)
        Dim Model As Contracts.IModel = ProfileController.Person.Exist(Ref).Model

        Console.Clear()
        Console.WriteLine("------- Person ------")
        Info(Model)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλετε να συνεχήσετε? (Αλλαγή Birthday)") Then
            Console.WriteLine("Δώσε καινουργια Ημμερομηνία:")
            Dim Change As Contracts.IBirthDay = New Contracts.Contracts
            Change.Birthday = Console.ReadLine
            Dim Val As MyBook.ValMsg = ProfileController.Person.Change(Ref, Change)
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
        End If


    End Sub
    Friend Sub Remove(Ref As Enity.IReference)
        Dim Model As Contracts.IModel = ProfileController.Person.Exist(Ref).Model

        Console.Clear()
        Console.WriteLine("------- Person ------")
        Info(Model)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλετε να Διαγράψετε το Προφίλ?") Then
            Dim Val As MyBook.ValMsg = ProfileController.Person.Remove(Ref)
            Console.Clear()
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
        End If


    End Sub
End Module
