Namespace Vehicle.Model.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, Vehicle.Model.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            If GetType(TCreteria) = GetType(Model.Contracts.ICreteria) Then
                Dim CreteriaLink As Contracts.ICreteria = Creteria
                If CreteriaLink.BrandId = Nothing And CreteriaLink.CategoryName = Nothing And CreteriaLink.Name <> Nothing Then
                    If Entity.Name = CreteriaLink.Name Then Return True
                ElseIf CreteriaLink.BrandId = Nothing And CreteriaLink.CategoryName <> Nothing And CreteriaLink.Name = Nothing Then
                    If CreteriaLink.CategoryName = Entity.CategoryName Then Return True
                ElseIf CreteriaLink.BrandId = Nothing And CreteriaLink.CategoryName <> Nothing And CreteriaLink.CategoryName <> Nothing Then
                    If CreteriaLink.BrandId = Nothing And CreteriaLink.CategoryName = Entity.CategoryName And CreteriaLink.Name = Entity.Name Then Return True
                ElseIf CreteriaLink.BrandId <> Nothing And CreteriaLink.CategoryName <> Nothing And CreteriaLink.Name = Nothing Then
                    If CreteriaLink.BrandId = Entity.BrandId And CreteriaLink.CategoryName = Entity.CategoryName Then Return True
                ElseIf CreteriaLink.BrandId <> Nothing And CreteriaLink.CategoryName = Nothing And CreteriaLink.Name <> Nothing Then
                    If CreteriaLink.BrandId = Entity.BrandId And CreteriaLink.Name = Entity.Name Then Return True
                ElseIf CreteriaLink.BrandId <> Nothing And CreteriaLink.CategoryName = Nothing And CreteriaLink.Name = Nothing Then
                    If CreteriaLink.BrandId = Entity.BrandId Then Return True
                End If
            End If
            Return False
        End Function
    End Class
End Namespace

