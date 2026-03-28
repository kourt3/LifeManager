Public Class AcountRepository
    Inherits MyBook.Repositories.Repository(Of Integer, My.Entity.Entity)


    Public Overrides Function Match(Of TCreteria)(Entity As My.Entity.Entity, Creteria As TCreteria) As Boolean
        Throw New NotImplementedException()
    End Function
End Class

Public Class AccountDatabaseRepository
    Inherits MyBook.Repositories.DatabaseRepository(Of Integer, My.Entity.Entity)


    Sub New()
        MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "AccountComponent", "[ID],[LoginID],[PersonID],[FamilyID]")
    End Sub

    Public Overrides Function ConvertRows(Entity As My.Entity.Entity) As String()
        Return {Entity.PrimaryKey, Entity.LoginID, Entity.PersonID, Entity.FamilyID}
    End Function

    Public Overrides Function ConvertEntity(DT As DataRow) As My.Entity.Entity
        Dim Entity As New My.Entity.Entity
        With Entity
            .PrimaryKey = DT(0)
            .LoginID = DT(1)
            .PersonID = DT(2)
            .FamilyID = DT(3)
        End With
        Return Entity
    End Function

    Public Overrides Function Match(Of TCreteria)(Entity As My.Entity.Entity, Creteria As TCreteria) As Boolean
        Throw New NotImplementedException()
    End Function
End Class
