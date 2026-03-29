Public Class Question
    Public ID As Integer
    Public QuizID As Integer
    Public CategoryID As Integer
    Public Page As Integer
    Public LanguageID As Integer
    Public Quest As String
    Public Photo As String
    Public Sound As String
    Public Book As String
    Public Answers As New List(Of Answers)
End Class
Public Class Answers
    Public ID As Integer
    Public QuestionID As Integer
    Public NumberofAnswer As Integer
    Public Answer As String
    Public Correct As Boolean
    Public Sound As String
End Class

Public Class Quiz
    Private Data As New database.DatabaseContecter(database.DatabaseContecter.VersionType.Ace_OleDb_16, "C:\Users\Kourt\Documents\Database1.Accdb")
    Public Function LoadQuiz(Kategory As Integer, Language As Integer) As List(Of Question)
        Dim Questions As New List(Of Question)
        Dim DTQuestion As New DataTable
        Dim DTAnswers As New DataTable
        Data.TableDbOLe(Data.SelectWhereDB("Questions", "[QKateg]=" & Kategory & " AND [QLang]=" & Language), DTQuestion)

        For i = 0 To DTQuestion.Rows.Count - 1
            Questions.Add(New Question With {.ID = DTQuestion(i)(0),
                .QuizID = DTQuestion(i)(1),
                .CategoryID = DTQuestion(i)(2),
                .Page = DTQuestion(i)(3),
                .LanguageID = DTQuestion(i)(4),
                .Quest = DTQuestion(i)(5),
                .Photo = DTQuestion(i)(6),
                .Sound = DTQuestion(i)(7),
                .Book = DTQuestion(i)(8)})
            Data.TableDbOLe(Data.SelectWhereDB("Answers", "[AQCod]=" & DTQuestion(i)(1)), DTAnswers)

            For j = 0 To DTAnswers.Rows.Count - 1
                Questions(i).Answers.Add(New Answers With {.ID = DTAnswers(j)(0),
                                         .QuestionID = DTAnswers(j)(1),
                                         .NumberofAnswer = DTAnswers(j)(2),
                                         .Answer = DTAnswers(j)(3),
                                         .Correct = DTAnswers(j)(4),
                                         .Sound = DTAnswers(j)(5)})
            Next
        Next
        Return Questions
    End Function

    Sub RandomQuestion(ByRef Question As List(Of Question))
        Dim Rnd As New Random
        For i = 0 To Question.Count - 1
            Dim Index As Integer = Rnd.Next(i + 1)
            Dim Temp As Question = Question(i)
            Question(i) = Question(Index)
            Question(Index) = Temp
        Next
    End Sub
    Sub RandomAnswers(ByRef Answers As List(Of Answers))
        Dim Rnd As New Random
        For i = 0 To Answers.Count - 1
            Dim Index As Integer = Rnd.Next(i + 1)
            Dim Temp As Answers = Answers(i)
            Answers(i) = Answers(Index)
            Answers(Index) = Temp
        Next
    End Sub
    Sub RandomQuestionAndAnswers(ByRef Question As List(Of Question))
        RandomQuestion(Question)
        For i = 0 To Question.Count - 1
            RandomAnswers(Question(i).Answers)
        Next

    End Sub
End Class