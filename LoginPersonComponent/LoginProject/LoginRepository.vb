Imports LoginProject.My.Ables
Imports MyBook.Repositories
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


    Public Class DatabaseRepository
        Inherits MyBook.Repositories.DatabaseRepository(Of Integer, My.Entity.Entity)

        Sub New()
            MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "Eisodos", "[ID],[Username],[Password],[CreateAt]")
        End Sub

        Public Overrides Function ConvertRows(Entity As My.Entity.Entity) As String()
            Return {Entity.PrimaryKey, Entity.Username, Entity.Password, Entity.CreateAt}
        End Function

        Public Overrides Function ConvertEntity(DT As DataRow) As My.Entity.Entity
            Dim Entity As New My.Entity.Entity
            With Entity
                .PrimaryKey = DT(0)
                .Username = DT(1)
                .Password = DT(2)
                .CreateAt = DT(3)
            End With
            Return Entity
        End Function



        Public Function ExistByCreteria(Creteria As My.Entity.ICreteria) As Boolean
            Dim DT As New DataTable


            Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

            For i = 0 To DT.Rows.Count - 1
                If Match(ConvertEntity(DT(i)), Creteria) Then Return True
            Next
            Return False
        End Function
        Public Function FindByUserNameAndPassword(UserName As String, Password As String) As My.Entity.IEntity
            Dim DT As New DataTable

            Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

            For i = 0 To DT.Rows.Count - 1
                If DT(i)(1) = UserName And Password = DT(i)(2) Then Return ConvertEntity(DT(i))
            Next
            Return Nothing
        End Function
        Public Function ExistByUsernameAndPassword(UserName As String, Password As String) As Boolean
            Dim DT As New DataTable

            Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

            For i = 0 To DT.Rows.Count - 1
                If DT(i)(1) = UserName And Password = DT(i)(2) Then Return True
            Next
            Return False
        End Function
        Public Function ExistByUsername(Username As String) As Boolean
            Dim DT As New DataTable

            Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

            For i = 0 To DT.Rows.Count - 1
                If DT(i)(1) = Username Then Return True
            Next
            Return False
        End Function
        Public Function ExistByPassword(Password As String) As Boolean
            Dim DT As New DataTable

            Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

            For i = 0 To DT.Rows.Count - 1
                If DT(i)(2) = Password Then Return True
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