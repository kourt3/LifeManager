Namespace FamilyProject.Family.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, FamilyProject.Family.Entity.Entity)



        Public Overrides Function Match(Of TCreteria)(Entity As FamilyProject.Family.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class

    Public Class DatabaseRepository
        Inherits MyBook.Repositories.DatabaseRepository(Of Integer, Family.Entity.Entity)

        Sub New()
            MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "Family", "[ID],[MotherID],[FatherID],[HusbandID]")
        End Sub

        Public Overrides Function ConvertRows(Entity As Entity.Entity) As String()
            Return {Entity.PrimaryKey, Entity.Mother, Entity.Father, Entity.Spouse}
        End Function

        Public Overrides Function ConvertEntity(DT As DataRow) As Entity.Entity
            Dim Entity As New Family.Entity.Entity
            With Entity
                .PrimaryKey = DT(0)
                .Mother = DT(1)
                .Father = DT(2)
                .Spouse = DT(3)
            End With
            Return Entity
        End Function

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

