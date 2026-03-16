Module Help

    Friend Function IfNotInputOrMsg(Of Type)(Title As String, ByRef Val As Type, Optional ExceptionCharacter() As String = Nothing) As Boolean
        Console.WriteLine(Title)
        If GetType(Type) = GetType(String) Then
            If DirectCast(CType(Val, Object), String) = Nothing Then
                Return Input(Val, ExceptionCharacter)
            Else
                Console.WriteLine(Val)
                Return True
            End If
        ElseIf GetType(Type) = GetType(Integer) Then
            If DirectCast(CType(Val, Object), Integer) = Nothing Then
                Return Input(Val, ExceptionCharacter)
            Else
                Console.WriteLine(Val)
                Return True
            End If
        ElseIf GetType(Type) = GetType(Boolean) Then
            If DirectCast(CType(Val, Object), Boolean) = Nothing Then
                Return Input(Val, ExceptionCharacter)
            Else
                Console.WriteLine(Val)
                Return True
            End If
        ElseIf GetType(Type) = GetType(Double) Then
            If DirectCast(CType(Val, Object), Double) = Nothing Then
                Return Input(Val, ExceptionCharacter)
            Else
                Console.WriteLine(Val)
                Return True
            End If
        ElseIf GetType(type) = GetType(Date) Then
            If DirectCast(CType(Val, Object), Date) = Nothing Then
                Return Input(Val, ExceptionCharacter)
            Else
                Console.WriteLine(Val)
                Return True
            End If
        End If

        Return False
    End Function
    Friend Function Input(Of Type)(ByRef inputStr As Type, Optional ExceptionCharacter() As String = Nothing) As Boolean
        Try
            Dim Value As String = Console.ReadLine

            If GetType(Type) = GetType(String) Then
                CheckInput(Value, TypeCode.String, ExceptionCharacter)
            ElseIf GetType(Type) = GetType(Integer) OrElse GetType(Type) = GetType(Double) Then
                CheckInput(Value, TypeCode.Int32, ExceptionCharacter)
            ElseIf GetType(Type) = GetType(Boolean) Then
                CheckInput(Value, TypeCode.Boolean, ExceptionCharacter)
            ElseIf GetType(Type) = GetType(Date) Then
                CheckInput(Value, TypeCode.DateTime, ExceptionCharacter)
            Else
                Console.WriteLine(GetType(Type).ToString)
                Return False
            End If

            inputStr = CType(Convert.ChangeType(Value, GetType(Type)), Type)
            Return True
        Catch ex As Exception
            inputStr = Nothing
            Console.WriteLine(ex.Message)
            Console.ReadLine()
            Return False
        End Try
    End Function

    Private Sub CheckInput(ByRef inputStr As String, ByVal Type As TypeCode, Optional ExceptionCharacter() As String = Nothing)

        If Type = TypeCode.Boolean Then
            If Not {"0", "1", "true", "false", "t", "f"}.Contains(inputStr.ToLower) Then
                Throw New Exception("Δεν επιτρέπονται χαρακτηρες εκτως boolean: ( 0, 1 , (T)rue , (F)alse )")
            End If
        End If

        If Type = TypeCode.Int32 Then
            For i = 0 To inputStr.Length - 1
                If Not Char.IsDigit(inputStr(i)) Then
                    Throw New Exception("Επιτρέπονται μονο Νουμερα (0 ,1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9)")
                End If
            Next
        End If


        If ExceptionCharacter IsNot Nothing Then
            For i = 0 To ExceptionCharacter.Count - 1
                If inputStr.Contains(ExceptionCharacter(i)) Then
                    Throw New Exception("Δεν επιτρέπονται οι χαρακτήρες: (" & String.Join(",", ExceptionCharacter) & ")")
                End If

            Next
        End If
    End Sub
    Function AccessChoice(Str As String) As Boolean

        Console.WriteLine(Str)
        Console.WriteLine("1) Ναι.")
        Console.WriteLine("2) Οχι.(Blank = Cancel)")
        Console.WriteLine()
        Console.WriteLine("Επέλεξε ενα απο το Μενου:")
        Dim Choice As String = Console.ReadLine
        If Choice = "1" Then
            Return True
        ElseIf Choice = "2" Then
            Return False
        End If
        Return False
    End Function

    Sub AddOption(ByRef Options As List(Of String), ByRef Action As List(Of Action), ByVal Title As String, ByVal Del As Action)
        Options.Add(Title)
        Action.Add(Del)
    End Sub
    Sub PrintMenu(Options As List(Of String))
        Console.WriteLine("------- Menu --------")
        For i = 0 To Options.Count - 1
            Console.WriteLine(i + 1 & ") " & Options(i))
        Next
        Console.WriteLine("---------------------")
        Console.WriteLine("Επέλεξε ενα απο το Menu:")
    End Sub


End Module
