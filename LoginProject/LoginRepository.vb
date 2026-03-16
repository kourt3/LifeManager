Imports LoginProject.My.Ables
Namespace Repositories

    Public Class LoginRepository

        Inherits MyBook.Repositories.Repository(Of Integer, My.Entity.Entity)


        Public Function ExistByCreteria(Creteria As My.Entity.ICreteria) As Boolean
            For i = 0 To Rep.Count - 1
                If Match(Rep(i), Creteria) Then Return True
            Next
            Return False
        End Function
        Public Function FindByUserNameAndPassword(UserName As String, Password As String) As My.Entity.IEntity
            For i = 0 To Rep.Count - 1
                If Rep(i).Username = UserName And Password = Rep(i).Password Then Return Rep(i)
            Next
            Return Nothing
        End Function
        Public Function ExistByUsernameAndPassword(UserName As String, Password As String) As Boolean
            For i = 0 To Rep.Count - 1
                If Rep(i).Username = UserName And Password = Rep(i).Password Then Return True
            Next
            Return False
        End Function
        Public Function ExistByUsername(Username As String) As Boolean
            For i = 0 To Rep.Count - 1
                If Rep(i).Username = Username Then Return True
            Next
            Return False
        End Function
        Public Function ExistByPassword(Password As String) As Boolean
            For i = 0 To Rep.Count - 1
                If Rep(i).Password = Password Then Return True
            Next
            Return False
        End Function

        Public Overrides Function Match(Of TCreteria)(Entity As My.Entity.Entity, Creteria As TCreteria) As Boolean
            Dim Creterias As My.Entity.ICreteria = Creteria
            If Creterias.Username IsNot Nothing AndAlso Creterias.Username <> Entity.Username Then Return False
            If Creterias.Password IsNot Nothing AndAlso Creterias.Password <> Entity.Password Then Return False
            Return True
        End Function


    End Class
End Namespace