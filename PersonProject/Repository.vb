Public Class PersonRepository
    Inherits MyBook.Repositories.Repository(Of Integer, My.Enity.Entity)



    Public Overrides Function Match(Of TCreteria)(Entity As My.Enity.Entity, Creteria As TCreteria) As Boolean
        Throw New NotImplementedException()
    End Function
End Class

Public Class DatabaseRepository
    Inherits MyBook.Repositories.DatabaseRepository(Of Integer, My.Enity.Entity)


    Sub New()
        MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "Person", "[ID],[Firstname],[SecondName],[Birthday]")
    End Sub

    Public Overrides Function ConvertRows(Entity As My.Enity.Entity) As String()
        Return {Entity.PrimaryKey, Entity.FristName, Entity.SecondName, Entity.Birthday}
    End Function

    Public Overrides Function ConvertEntity(DT As DataRow) As My.Enity.Entity
        Dim Entity As New My.Enity.Entity
        With Entity
            .PrimaryKey = DT(0)
            .FristName = DT(1)
            .SecondName = DT(2)
            .Birthday = DT(3)
        End With
        Return Entity
    End Function

    Public Overrides Function Match(Of TCreteria)(Entity As My.Enity.Entity, Creteria As TCreteria) As Boolean
        Throw New NotImplementedException()
    End Function
End Class