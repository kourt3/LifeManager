Namespace Profile.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            Dim CreteriaLink As Contracts.ICreteria = Creteria
            If CreteriaLink.PersonID = Nothing And CreteriaLink.FamilyID <> Nothing Then
                If CreteriaLink.FamilyID = Entity.FamilyID Then Return True
            ElseIf CreteriaLink.PersonID <> Nothing And CreteriaLink.FamilyID = Nothing Then
                If CreteriaLink.PersonID = Entity.PersonID Then Return True
            End If
            Return False
        End Function
    End Class
End Namespace

