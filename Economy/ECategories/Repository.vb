Namespace ECategory.Repositories
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, ECategory.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As ECategory.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

