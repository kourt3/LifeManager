Namespace FamilyProject.Children.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, FamilyProject.Children.Entity.Entity)


        Public Overrides Function Match(Of TCreteria)(Entity As FamilyProject.Children.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

