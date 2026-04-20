Namespace Account.Repository
    Public Class AcountRepository
        Inherits MyBook.Repositories.Repository(Of Integer, Account.Entity.Entity)


        Public Overrides Function Match(Of TCreteria)(Entity As Account.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class

    Public Class AccountDatabaseRepository
        Inherits MyBook.Repositories.DatabaseRepository(Of Integer, Account.Entity.Entity)


        Sub New()
            MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "AccountComponent", "[ID],[LoginID],[ExternalID]")
        End Sub

        Public Overrides Function ConvertRows(Entity As Account.Entity.Entity) As String()
            Return {Entity.PrimaryKey, Entity.LoginID, Entity.ToExternalID}
        End Function

        Public Overrides Function ConvertEntity(DT As DataRow) As Account.Entity.Entity
            Dim Entity As New Account.Entity.Entity
            With Entity
                .PrimaryKey = DT(0)
                .LoginID = DT(1)
                .ToExternalID = DT(2)
            End With
            Return Entity
        End Function

        Public Overrides Function Match(Of TCreteria)(Entity As Account.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace
