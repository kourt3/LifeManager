Public Class PersonRepository
    Inherits MyBook.Repositories.Repository(Of Integer, My.Enity.Entity)



    Public Overrides Function Match(Of TCreteria)(Entity As My.Enity.Entity, Creteria As TCreteria) As Boolean
        Throw New NotImplementedException()
    End Function
End Class