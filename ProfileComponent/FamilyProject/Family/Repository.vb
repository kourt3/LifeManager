Namespace FamilyProject.Family.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, FamilyProject.Family.Entity.Entity)



        Public Overrides Function Match(Of TCreteria)(Entity As FamilyProject.Family.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

