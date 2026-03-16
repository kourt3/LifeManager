Namespace TransferProject.Repository
    Public Class TransferRepository
        Inherits MyBook.Repositories.Repository(Of Integer, My.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As My.Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

