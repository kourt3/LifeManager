Namespace Vehicle.Plate.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            If GetType(TCreteria) = GetType(Contracts.ICreteria) Then
                Dim CreteriaL As Contracts.ICreteria = Creteria
                If CreteriaL.ExternalID = Entity.ExternalID Then Return True
            End If
            Return False
        End Function
    End Class

End Namespace
