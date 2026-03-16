Imports System.Security.Principal
Imports LoginProject
Friend Module LoginModule
    Friend Sub Info(Model As Contracts.IModel)
        Console.WriteLine("ID: " & Model.PrimaryKey)
        Console.WriteLine("UserName: " & Model.Username)
        Console.WriteLine("Password: " & Model.Password)
        Console.WriteLine("ημ. Λογαριασμού: " & Model.CreateAt)
    End Sub
    Friend Sub Menu(Ref As LoginProject.My.Entity.IReference)
        Do
            Dim ValModel As MyBook.ValMsg(Of Contracts.Contracts) = LoginService.Exist(Ref)
            If ValModel.Success = False Then
                Exit Sub
            End If
            Dim model As Contracts.IModel = ValModel.Model
            Console.Clear()

            Console.WriteLine("------ Είσοδος Χρήστη ------")
            Info(model)
            Console.WriteLine()
            Console.WriteLine("------------ Menu -----------")
            Console.WriteLine("1) Αλλαγή Username.")
            Console.WriteLine("2) Αλλαγή Password.")
            Console.WriteLine("3) Αλλαγή Username and Passowrd.")
            '     Console.WriteLine("4) Διαγραφή Λογαρισμού.")
            Console.WriteLine("4) Exit.")
            Dim Str As Integer = Nothing
            If Help.Input(Str) = False Then
                Continue Do
            End If

            Select Case Str
                Case 1
                    ChangeUserName(model)
                Case 2
                    ChangePassword(model)
                Case 3
                    ChangeUsernameAndPassword(model)
                'Case 4
                '    RemoveAcc(model)
                Case 4
                    Exit Do
                Case Else
                    Continue Do
            End Select

        Loop
    End Sub

    Friend Function Login() As MyBook.ValMsg(Of Contracts.IModel)
        Dim Result As New MyBook.ValMsg(Of Contracts.IModel)
        Do
            'Login ----------------
            Console.Clear()
            Console.WriteLine("------ My Life Manager ------" & vbNewLine)

            Console.WriteLine("Για έξοδος(Exit).")
            Console.WriteLine("UserName:")
            Dim UserName As String = Console.ReadLine
            If UserName = "Exit" Then
                Console.Clear()
                Console.WriteLine("Έξοδος Εισόδου.")
                Console.ReadKey()
                Result.Success = False
                Return Result
            End If

            Console.WriteLine("Password:")
            Dim Password As String = Console.ReadLine

            If Password = "Exit" Then
                Console.Clear()
                Console.WriteLine("Έξοδος Εισόδου.")
                Console.ReadKey()
                Result.Success = False
                Return Result
            End If

            Dim LoginDTO As LoginProject.Contracts.ILoginDTO = New LoginProject.Contracts.Contracts
            LoginDTO.Username = UserName
            LoginDTO.Password = Password
            '--------------------------------------
            Result = LoginService.Login(LoginDTO)
            Console.Clear()

            If Result.Success = True Then
                Console.WriteLine("η Είσοδος ήταν επιτυχης!")
                Console.ReadLine()
                Return Result
            Else
                Console.WriteLine("Λαθος UserName or Password.")
                Console.ReadKey()
                Return Result
            End If

        Loop
        Result.Success = False
        Result.Msg = "Δεν ήταν Δυνατή η είσοδος!"
        Return Result
    End Function


    Friend Sub Register(ByRef LoginRegisterDTO As LoginProject.Contracts.IRegisterDTO)

        Do

            Console.Clear()
            Console.WriteLine("------ My Life Manager ------" & vbNewLine)
            Console.WriteLine("------ (Register Account) ------")
            Console.WriteLine("Για έξοδος(Exit).")
            Console.WriteLine("New UserName:")
            Dim UserName As String = Console.ReadLine

            If UserName = "Exit" Then
                Console.Clear()
                Console.WriteLine("Έξοδος Εγραφής.")
                Console.ReadKey()
                Exit Do
            End If

            Console.WriteLine("New Password:")
            Dim Password As String = Console.ReadLine

            If Password = "Exit" Then
                Console.Clear()
                Console.WriteLine("Έξοδος Εγγραφής.")
                Console.ReadKey()
                Exit Do
            End If

            Console.WriteLine("Again Passowrd:")
            Dim AgainPassword As String = Console.ReadLine

            If AgainPassword = "Exit" Then
                Console.Clear()
                Console.WriteLine("Έξοδος Εγγραφής.")
                Console.ReadKey()
                Exit Do
            End If

            If AgainPassword = Password Then
                LoginRegisterDTO.Username = UserName
                LoginRegisterDTO.Password = Password
                Exit Do
            Else
                Console.WriteLine("Λαθος Password.")
            End If
            Console.ReadKey()
        Loop
    End Sub

    Friend Function ChangeUserName(Ref As LoginProject.My.Entity.IReference) As Boolean

        Dim Model As LoginProject.Contracts.IModel = LoginService.Exist(Ref).Model



        Console.Clear()
        Console.WriteLine("------ Αλλαγή UserName ------")
        Info(Model)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλεις να αλλάξεις το Username:") Then

            Console.Clear()
            Console.WriteLine("Δώσε Username:")
            Dim DTO As LoginProject.Contracts.ILoginDTO = New Contracts.Contracts
            DTO.Username = Console.ReadLine
            Console.WriteLine("Δώσε Password:")
            DTO.Password = Console.ReadLine
            Dim LoginVal As MyBook.ValMsg(Of LoginProject.Contracts.IModel) = LoginService.Login(DTO)
            If LoginVal.Success = True Then
                Console.WriteLine("Δώσε το New Username:")
                Dim ChangeDTO As Contracts.IChangeNameDTO = New Contracts.Contracts
                Dim Str As String = Console.ReadLine
                If Str <> Nothing Then
                    ChangeDTO.Username = Str
                    Console.WriteLine(LoginService.Change(Model, ChangeDTO).Msg)
                    Console.ReadLine()
                    Return True
                Else
                    Return False
                End If
            Else
                Console.Clear()
                Console.WriteLine(LoginVal.Msg)
                Console.ReadKey()
                Return LoginVal.Success
            End If
        End If
        Return False

    End Function
    Friend Function ChangePassword(Ref As LoginProject.My.Entity.IReference) As Boolean


        Dim Model As LoginProject.Contracts.IModel = LoginService.Exist(Ref).Model

        Console.Clear()
        Console.WriteLine("------ Αλλαγή Password ------")
        Console.WriteLine("ID :" & Model.PrimaryKey)
        Console.WriteLine("Username: " & Model.Username)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλεις να αλλάξεις το Password:") Then

            Console.Clear()
            Console.WriteLine("Δώσε Username:")
            Dim DTO As LoginProject.Contracts.ILoginDTO = New Contracts.Contracts
            DTO.Username = Console.ReadLine
            Console.WriteLine("Δώσε Password:")
            DTO.Password = Console.ReadLine
            Dim LoginVal As MyBook.ValMsg(Of LoginProject.Contracts.IModel) = LoginService.Login(DTO)
            If LoginVal.Success = True Then
                Dim ChangeDTO As Contracts.IChangePasswordDTO = New Contracts.Contracts
                Console.WriteLine("Δώσε το New Password:")
                ChangeDTO.Password = Console.ReadLine
                If ChangeDTO.Password <> Nothing Then
                    Console.WriteLine("Again New Password:")
                    Dim Str1 As String = Console.ReadLine
                    If Str1 <> Nothing Then
                        If ChangeDTO.Password = Str1 Then
                            LoginService.Change(Model, ChangeDTO)
                            Return True
                        Else
                            Console.Clear()
                            Console.WriteLine("Δεν Συμφονουν οι χαρακτήρες Ματαξή τους!")
                            Console.ReadKey()
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Console.Clear()
                Console.WriteLine(LoginVal.Msg)
                Return LoginVal.Success
            End If
        End If



        Return False

    End Function

    Friend Function ChangeUsernameAndPassword(Ref As LoginProject.My.Entity.IReference) As Boolean
        Dim Model As LoginProject.Contracts.IModel = LoginService.Exist(Ref).Model
        Console.Clear()
        Console.WriteLine("------ Αλλαγή Username and Password ------")
        Info(Model)
        Console.WriteLine()
        Console.WriteLine("----------------")
        If Help.AccessChoice("Θέλεις να αλλάξεις το Username and Password:") Then
            Console.Clear()
            Console.WriteLine("Δώσε Username:")
            Dim DTO As LoginProject.Contracts.ILoginDTO = New Contracts.Contracts
            DTO.Username = Console.ReadLine
            Console.WriteLine("Δώσε Password:")
            DTO.Password = Console.ReadLine
            Dim LoginVal As MyBook.ValMsg(Of LoginProject.Contracts.IModel) = LoginService.Login(DTO)
            If LoginVal.Success = True Then
                Dim ChangeDTO As Contracts.IChangeUsernameAndPasswordDTO = New Contracts.Contracts
                Console.WriteLine("Δώσε καινουργιο Username")
                ChangeDTO.Username = Console.ReadLine
                If ChangeDTO.Username = Nothing Then
                    Return False
                End If
                Console.WriteLine("Δώσε το New Password:")
                ChangeDTO.Password = Console.ReadLine
                If ChangeDTO.Password <> Nothing Then
                    Console.WriteLine("Again New Password:")
                    Dim Str1 As String = Console.ReadLine
                    If Str1 <> Nothing Then
                        If ChangeDTO.Password = Str1 Then
                            Dim ValChange As MyBook.ValMsg = LoginService.Change(Model, ChangeDTO)
                            Console.Clear()
                            Console.WriteLine(ValChange.Msg)
                            Console.ReadKey()
                            Return ValChange.Success
                        Else
                            Console.Clear()
                            Console.WriteLine("Δεν Συμφονουν οι χαρακτήρες Ματαξή τους!")
                            Console.ReadKey()
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Console.Clear()
                Console.WriteLine(LoginVal.Msg)
                Return LoginVal.Success
            End If
        End If

        Return False
    End Function

    Friend Function RemoveAcc(Ref As LoginProject.My.Entity.IReference) As Boolean

        Dim Model As LoginProject.Contracts.IModel = LoginService.Exist(Ref).Model

        Console.Clear()
        Console.WriteLine("------ Διαγραφή Λογαριασμου --------")
        Info(Model)
        If Help.AccessChoice("Θέλετε να διαγράψετε τον λογαριασμο ?") Then
            Dim DTO As LoginProject.Contracts.ILoginDTO = New LoginProject.Contracts.Contracts
            Console.WriteLine("Δώσε το Username:")
            DTO.Username = Console.ReadLine
            Console.WriteLine("Δώσε το Password:")
            DTO.Password = Console.ReadLine
            Dim LoginVal As MyBook.ValMsg(Of LoginProject.Contracts.IModel) = LoginService.Login(DTO)
            Dim RemoveVal As MyBook.ValMsg
            If LoginVal.Success = True Then
                RemoveVal = LoginService.Remove(Model)
                Console.Clear()
                Console.WriteLine(RemoveVal.Msg)
                Console.ReadKey()
                Return RemoveVal.Success
            Else
                Console.Clear()
                Console.WriteLine(LoginVal.Msg)
                Console.ReadKey()
                Return LoginVal.Success
            End If
        End If

        Return False
    End Function
End Module
