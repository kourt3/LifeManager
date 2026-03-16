Namespace EconomyProject.Repositories
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, EconomyProject.Entity.Entity)


        Public Overrides Function Match(Of TCreteria)(Entity As EconomyProject.Entity.Entity, Creteria As TCreteria) As Boolean
            Dim CreteriaObj As Contracts.ICreteria = New Contracts.Contact
            If Entity.ExternalID = CreteriaObj.ExternalID Then Return False
            If Entity.ToExternalID = CreteriaObj.ToExternalID Then Return False
            If Entity.Category = CreteriaObj.Category Then Return False
            Return True
        End Function

    End Class
End Namespace

