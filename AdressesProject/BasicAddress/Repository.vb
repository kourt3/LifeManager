Public Class Repository
    Inherits MyBook.Repositories.Repository(Of Integer, My.Entity.Entity)

    Public Overrides Function Match(Of TCreteria)(Entity As My.Entity.Entity, Creteria As TCreteria) As Boolean
        If GetType(TCreteria) = GetType(Adresses.Contracts.ICreteriaValue) Then
            Dim Crete As Adresses.Contracts.ICreteriaValue = Creteria
            If Entity.Value = Crete.Value Then Return True
        ElseIf GetType(TCreteria) = GetType(FullAdress.Contracts.ICreteriaFullAdress) Then
            Dim CreteriaL As FullAdress.Contracts.ICreteriaFullAdress = Creteria
            If CreteriaL.Country = Entity.Country And CreteriaL.Perifereia = Entity.Perifereia And CreteriaL.Nomos = Entity.Nomos And
                    CreteriaL.TK = Entity.TK And CreteriaL.Dhmos = Entity.Dhmos And CreteriaL.Addresses = Entity.Addresses And CreteriaL.Number = Entity.Number Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
