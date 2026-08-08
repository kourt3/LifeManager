Namespace Portofolio.Repository
    Public Class PortofolioRepository
        Inherits MyBook.Repositories.Repository(Of Integer, Portofolio.Entity.Entity)



        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            Throw New NotImplementedException()
        End Function

    End Class
End Namespace

