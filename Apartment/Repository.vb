Namespace Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, My.Apartment.Entity)



        Public Overrides Function Match(Of TCreteria)(Entity As My.Apartment.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

