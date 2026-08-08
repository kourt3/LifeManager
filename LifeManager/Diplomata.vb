Imports System.Reflection

Module Diplomata
    Enum KatType
        Car = 1
        Moto = 2
        Forthgo = 3
        MegaloForthgo = 4
        Leoforio = 5
    End Enum
    Enum LangType
        None = 1
        Greek = 1
        English = 2
        Russia = 3
        Albanian = 4
    End Enum
    Sub Menu()
        Do
            Console.Clear()
            Console.WriteLine("--------- Menu Diplomatos ---------")
            Console.WriteLine("1) Car")
            Console.WriteLine("2) Moto")
            Console.WriteLine("3) Φορτηγο C")
            Console.WriteLine("4) φορτηγο D")
            Console.WriteLine("5) Λεοφορείο")
            Console.WriteLine("6) Exit")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    Lang(KatType.Car)
                Case 2
                    Lang(KatType.Moto)
                Case 3
                    Lang(KatType.Forthgo)
                Case 4
                    Lang(KatType.MegaloForthgo)
                Case 5
                    Lang(KatType.Leoforio)
                Case 6
                    Exit Sub
            End Select
        Loop
    End Sub
    Sub Lang(Kategory As KatType)
        Do
            Console.Clear()
            Console.WriteLine("------------ Menu Choice Language -----------")
            Console.WriteLine("1) Greek.")
            Console.WriteLine("2) English.")
            Console.WriteLine("3) Russia.")
            Console.WriteLine("4) Albanian.")
            Console.WriteLine("5) Exit.")
            Dim Str As String = Console.ReadLine
            Select Case Str
                Case 1
                    Question(Kategory, LangType.Greek)
                Case 2
                    Question(Kategory, LangType.English)
                Case 3
                    Question(Kategory, LangType.Russia)
                Case 4
                    Question(Kategory, LangType.Albanian)
                Case 5
                    Exit Do
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub
    Sub Question(Kategory As KatType, Lang As LangType)
        Dim Diploma As New DiplomataProject.Quiz

        Dim Quiz As List(Of DiplomataProject.Question) = Diploma.LoadQuiz(Kategory, Lang)
        Do
            Console.Clear()
            Console.WriteLine("----------- Menu ------------")
            Console.WriteLine("Το Quiz Περιεχει " & Quiz.Count & " Ερωτήσεις")
            Console.WriteLine("απο Ποια ερώτηση θέλεις να ξεκινησείς? 0 or E(Exit) - 1 To " & Quiz.Count & "(Επιλογή)")
            Dim Start As String = Console.ReadLine
            If Start = " " Or Start = "0" Or Start = "" Or Start = "E" Then
                Exit Do
            End If
            Console.WriteLine("Σε ποια ερώτηση θέλεις να Σταματήσεις? 0 or E(Exit) - 1 To " & Quiz.Count & "(Επιλογή)")
            Dim EndStr As String = Console.ReadLine
            If EndStr = " " Or EndStr = "0" Or EndStr = "" Or EndStr = "E" Then
                Exit Do
            End If
            Console.WriteLine("Θέλεις να ανακατέψουμε της Ερωτησεις? Ναι(Υ),Οχι(Χ),E(Exit)")
            Dim ChoiceQuestion As String = Console.ReadLine
            If ChoiceQuestion = "Y" Then
                Diploma.RandomQuestion(Quiz)
            ElseIf ChoiceQuestion = "E" Or ChoiceQuestion = "" Or ChoiceQuestion = " " Then
                Exit Do
            End If
            Console.WriteLine("Θέλεις να ανακατέψουμε της Απαντήσεις? Ναι(Υ),Οχι(Χ),E(Exit)")
            Dim ChoiceAnswer As String = Console.ReadLine
            If ChoiceAnswer = "Y" Then
                For i = 0 To Quiz.Count - 1
                    Diploma.RandomAnswers(Quiz(i).Answers)
                Next
            ElseIf ChoiceAnswer = "E" Or ChoiceAnswer = "" Or ChoiceAnswer = " " Then
                Exit Sub
            End If
            Console.Clear()
            Console.WriteLine("------- Menu ------")
            Console.WriteLine("1) Διάβασμα ερωτήσεων.")
            Console.WriteLine("2) Test Ερωτήσεων.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1
                    ReadQuiz(Quiz, Start - 1, EndStr - 1)
                    Exit Do
                Case 2
                    TestQuiz(Quiz, Start - 1, EndStr - 1)
                    Exit Do
                Case 3
                    Exit Do
                Case Else
                    Continue Do
            End Select

        Loop
    End Sub
    Sub ReadQuiz(Quiz As List(Of DiplomataProject.Question), StartIndex As Integer, EndIndex As Integer)
        Dim Index As Integer = StartIndex
        Do
            Console.Clear()
            Console.WriteLine("---------- Ερωτήσεις " & Index + 1 & " ---------")
            Console.WriteLine(Quiz(Index).Quest)
            Console.WriteLine()
            Console.WriteLine("-------------------------------------")
            ReadQuestion(Quiz(Index), True)
            Console.WriteLine()
            Console.WriteLine("------------- Menu -------------------")
            Console.WriteLine("N) Next Or Enter Or -> .")
            Console.WriteLine("P) Preview Or BackSpace Or <-.")
            Console.WriteLine("E) Exit Or Escape.")
            Console.WriteLine("Παρακαλώ επιλέξτε.")
            Dim Choice As ConsoleKeyInfo = Console.ReadKey
            Select Case Choice.Key
                Case ConsoleKey.N, ConsoleKey.RightArrow, ConsoleKey.Enter
                    Index += 1

                    If EndIndex < Index Then
                        Index = StartIndex
                    End If

                Case ConsoleKey.P, ConsoleKey.LeftArrow, ConsoleKey.Backspace
                    Index -= 1
                    If Index < 0 Then
                        Index = EndIndex
                    End If
                Case ConsoleKey.E, ConsoleKey.Escape
                    Exit Sub
                Case Else
                    Continue Do
            End Select
        Loop
    End Sub

    Sub TestQuiz(Quiz As List(Of DiplomataProject.Question), StartIndex As Integer, EndIndex As Integer)
        Dim Answers As New List(Of DiplomataProject.Answers)
        Dim Index As Integer = StartIndex
        Do
            Console.Clear()
            Console.WriteLine("Απαντήσατε: " & Answers.Count)
            Console.WriteLine("Ερωτήσεις: " & EndIndex - StartIndex)
            Console.WriteLine("Υπόλυπο: " & Answers.Count - (EndIndex - StartIndex))
            Dim Exist As Boolean = False
            Do
                Exist = False
                For j = 0 To Answers.Count - 1

                    If Quiz(Index).QuizID = Answers(j).QuestionID Then
                        Index += 1
                        If EndIndex < Index Then
                            Index = StartIndex
                        End If
                        Exist = True
                    End If
                Next
            Loop Until Exist = False
            Console.WriteLine("---------- Ερωτήση " & Index + 1 & " ---------")
            ReadQuestion(Quiz(Index), False)
            Console.WriteLine()
            Console.WriteLine("------------- Menu -------------------")
            Console.WriteLine("1 - " & Quiz(Index).Answers.Count & ") Απάντηση.")
            Console.WriteLine("N) Next Or Enter Or -> .")
            Console.WriteLine("P) Preview Or BackSpace Or <-.")
            Console.WriteLine("E) Exit Or Escape.")
            Console.WriteLine("Παρακαλώ επιλέξτε.")
            Dim Choice As ConsoleKeyInfo = Console.ReadKey
            Select Case Choice.Key
                Case ConsoleKey.NumPad0, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9, ConsoleKey.NumPad0
                    Dim ChoicerIndex As Integer = Nothing
                    If Choice.Key = ConsoleKey.NumPad0 Then
                        ChoicerIndex = 0
                    ElseIf Choice.Key = ConsoleKey.NumPad1 Then
                        ChoicerIndex = 1
                    ElseIf Choice.Key = ConsoleKey.NumPad2 Then
                        ChoicerIndex = 2
                    ElseIf Choice.Key = ConsoleKey.NumPad3 Then
                        ChoicerIndex = 3
                    ElseIf Choice.Key = ConsoleKey.NumPad4 Then
                        ChoicerIndex = 4
                    ElseIf Choice.Key = ConsoleKey.NumPad5 Then
                        ChoicerIndex = 5
                    ElseIf Choice.Key = ConsoleKey.NumPad6 Then
                        ChoicerIndex = 6
                    ElseIf Choice.Key = ConsoleKey.NumPad7 Then
                        ChoicerIndex = 7
                    ElseIf Choice.Key = ConsoleKey.NumPad8 Then
                        ChoicerIndex = 8
                    ElseIf Choice.Key = ConsoleKey.NumPad9 Then
                        ChoicerIndex = 9
                    End If
                    If Quiz(Index).Answers.Count - 1 >= ChoicerIndex - 1 Then
                        Answers.Add(Quiz(Index).Answers(ChoicerIndex - 1))
                    Else
                        Continue Do
                    End If
                Case ConsoleKey.N, ConsoleKey.Enter, ConsoleKey.RightArrow
                    Index += 1
                    If EndIndex < Index Then
                        Index = StartIndex
                    End If
                Case ConsoleKey.P, ConsoleKey.Backspace, ConsoleKey.LeftArrow
                    Index -= 1
                    If Index < 0 Then
                        Index = EndIndex
                    End If
                Case ConsoleKey.E, ConsoleKey.Escape
                    Exit Sub
                Case Else
                    Continue Do
            End Select
        Loop Until Answers.Count - 1 = EndIndex - StartIndex





        Dim Swstes, Lathos As Integer

        Swstes = 0
        Lathos = 0
        For i = 0 To Answers.Count - 1
            If Answers(i).Correct = True Then
                Swstes += 1
            Else
                Lathos += 1
            End If
        Next

        For i = 0 To Answers.Count - 1
            Console.Clear()
            Console.WriteLine("------------- Απαντήσεις -------------")
            Console.WriteLine("Corrects: " & Swstes)
            Console.WriteLine("UnCorrects: " & Lathos)
            Console.WriteLine("-----------------------------")
            Console.WriteLine()
            For j = 0 To Quiz.Count - 1
                If Quiz(j).QuizID = Answers(i).QuestionID Then
                    ReadQuestion(Quiz(j), True)
                End If
            Next


            Console.WriteLine()
            Console.WriteLine("--------------- Απαντήσατε: -------------")
            If Answers(i).Correct = True Then
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(Answers(i).Answer & " (" & Char.ConvertFromUtf32(&H2713) & ")")
            Else
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.WriteLine(Answers(i).Answer & " (" & Char.ConvertFromUtf32(&H2717) & ")")
            End If
            Console.ResetColor()
            Console.WriteLine()
            Console.WriteLine("---------- Menu ----------")
            Console.WriteLine("Menu: E(Exit),Enter(Next Quest)")
            Dim Menu As String = Console.ReadLine
            If Menu = "E" Then
                Exit Sub
            End If
        Next

    End Sub
    Sub ReadAnswers(Answer As DiplomataProject.Answers, Colorize As Boolean)

    End Sub
    Sub ReadQuestion(Question As DiplomataProject.Question, Colorize As Boolean)
        Console.WriteLine(Question.Quest)
        Console.WriteLine()
        Console.WriteLine("-------------------------------------")
        For i = 0 To Question.Answers.Count - 1
            If Colorize = True Then
                If Question.Answers(i).Correct = True Then
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.WriteLine(i + 1 & ") " & Question.Answers(i).Answer & " (" & Char.ConvertFromUtf32(&H2713) & ")")
                Else
                    Console.ForegroundColor = ConsoleColor.DarkRed
                    Console.WriteLine(i + 1 & ") " & Question.Answers(i).Answer & " (" & Char.ConvertFromUtf32(&H2717) & ")")
                End If
                Console.ResetColor()
            Else
                Console.WriteLine(i + 1 & ") " & Question.Answers(i).Answer)
            End If
        Next
    End Sub
End Module
