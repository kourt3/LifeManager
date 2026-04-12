Namespace Vehicle.Vehicles.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, Vehicle.Vehicles.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            If GetType(TCreteria) = GetType(Vehicle.Vehicles.Contracts.ICreteria) Then
                Dim CreteriaLink As Vehicle.Vehicles.Contracts.ICreteria = Creteria
                If CreteriaLink.ModelId = Entity.ModelId Then Return True
            End If
            Return False
        End Function
    End Class
End Namespace

