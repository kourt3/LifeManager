Namespace BuildAndApartment.Apartment.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, Apartment.Entity.Entity)



        Public Overrides Function Match(Of TCreteria)(Entity As Apartment.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

