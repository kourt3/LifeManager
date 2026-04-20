Namespace Profile.Repository
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            Dim CreteriaLink As Contracts.ICreteria = Creteria
            If CreteriaLink.PersonID = Nothing And CreteriaLink.FamilyID <> Nothing Then
                If CreteriaLink.FamilyID = Entity.FamilyID Then Return True
            ElseIf CreteriaLink.PersonID <> Nothing And CreteriaLink.FamilyID = Nothing Then
                If CreteriaLink.PersonID = Entity.PersonID Then Return True
            End If
            Return False
        End Function
    End Class
    Public Class DataBaseRepository
        Inherits MyBook.Repositories.DatabaseRepository(Of Integer, Entity.Entity)

        Sub New()
            MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "Profile", "[ID],[PersonID],[FamilyID]")
        End Sub

        Public Overrides Function ConvertRows(Entity As Entity.Entity) As String()
            Return {Entity.PrimaryKey, Entity.PersonID, Entity.FamilyID}

        End Function

        Public Overrides Function ConvertEntity(DT As DataRow) As Entity.Entity
            Dim Entity As New Entity.Entity
            With Entity
                .PrimaryKey = DT(0)
                .PersonID = DT(1)
                .FamilyID = DT(2)
            End With
            Return Entity
        End Function

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            Dim CreteriaLink As Contracts.ICreteria = Creteria
            If CreteriaLink.PersonID = Nothing And CreteriaLink.FamilyID <> Nothing Then
                If CreteriaLink.FamilyID = Entity.FamilyID Then Return True
            ElseIf CreteriaLink.PersonID <> Nothing And CreteriaLink.FamilyID = Nothing Then
                If CreteriaLink.PersonID = Entity.PersonID Then Return True
            End If
            Return False
        End Function
    End Class
End Namespace

