Namespace ContactsProject.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, ContactsProject.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As ContactsProject.Entity.Entity, Creteria As TCreteria) As Boolean
            Dim CreteriaL As ContactsProject.Contracts.ICreteria = Creteria
            If CreteriaL.ExternalID = Entity.ExternalID And CreteriaL.ToExternalID = Entity.ToExternalID Then Return True
            Return False
        End Function
    End Class
End Namespace

