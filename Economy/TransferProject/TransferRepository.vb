Namespace TransferProject.Repository
    Public Class TransferRepository
        Inherits MyBook.Repositories.Repository(Of Integer, Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            If GetType(TCreteria) = GetType(Contracts.ICreateria) Then
                Dim CreteriaLink As Contracts.ICreateria = Creteria
                If Entity.FromPartEconomyID <> CreteriaLink.FromPartEconomyID Then Return False
                If Entity.FromCategory <> CreteriaLink.FromCategory Then Return False
                If Entity.ToPartEconomyID <> CreteriaLink.ToPartEconomyID Then Return False
                If Entity.ToCategory <> CreteriaLink.ToCategory Then Return False
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

