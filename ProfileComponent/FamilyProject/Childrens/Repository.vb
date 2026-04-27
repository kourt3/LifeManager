Namespace FamilyProject.Children.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, FamilyProject.Children.Entity.Entity)


        Public Overrides Function Match(Of TCreteria)(Entity As FamilyProject.Children.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class

    Public Class DataRepository
        Inherits MyBook.Repositories.DatabaseRepository(Of Integer, FamilyProject.Children.Entity.Entity)

        Sub New()
            MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "Childrens", "[ID],[ExternaLID],[ChildID]")
        End Sub


        Public Overrides Function ConvertRows(Entity As Entity.Entity) As String()
            Return {Entity.PrimaryKey, Entity.FamilyID, Entity.ToExternalID}
        End Function

        Public Overrides Function ConvertEntity(DT As DataRow) As Entity.Entity
            Dim Entity As New Entity.Entity
            With Entity
                .PrimaryKey = DT(0)
                .FamilyID = DT(1)
                .ToExternalID = DT(2)
            End With
            Return Entity
        End Function

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

