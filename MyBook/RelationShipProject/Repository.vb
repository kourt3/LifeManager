Namespace RelationShip.Repositories
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, RelationShip.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As RelationShip.Entity.Entity, Creteria As TCreteria) As Boolean
            If GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaExtrenalAndToExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaExtrenalAndToExternal = Creteria
                If CreteriaL.ExternalID = Entity.ExternalID And CreteriaL.ToExternalID = Entity.ToExternalID Then Return True
            ElseIf GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaExternal = Creteria
                If CreteriaL.ExternalID = Entity.ExternalID Then Return True
            ElseIf GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaTOExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaTOExternal = Creteria
                If CreteriaL.ToExternalID = Entity.ToExternalID Then Return True
            End If
            Return False
        End Function
    End Class
End Namespace

