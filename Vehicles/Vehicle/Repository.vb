Namespace Vehicle.Vehicles.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, Vehicle.Vehicles.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

