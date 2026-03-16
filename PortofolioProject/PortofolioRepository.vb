Namespace Repository
    Public Class PortofolioRepository
        Inherits MyBook.Repositories.Repository(Of Integer, My.Enity.Entity)
        Sub New()
            MyBase.New(True)
        End Sub
    End Class
End Namespace

