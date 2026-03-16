Namespace Repository
    Public Class TransferRepository
        Inherits MyBook.Repositories.Repository(Of Integer, My.Entity.Entity)
        Sub New()
            MyBase.New(True)
        End Sub
    End Class
End Namespace

