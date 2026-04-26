Namespace RelationShip.Repositories
    Public Class Repository
        Inherits MyBook.Repositories.Repository(Of Integer, RelationShip.Entity.Entity)

        Public Overrides Function Match(Of TCreteria)(Entity As RelationShip.Entity.Entity, Creteria As TCreteria) As Boolean
            If GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaExtrenalAndToExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaExtrenalAndToExternal = Creteria
                If CreteriaL.ExternalID = Entity.ExternalID And CreteriaL.ToExternalID = Entity.ToExternalID Then Return True
            ElseIf GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaExternal = Creteria
                If CreteriaL.ExternalID = Entity.ExternalID Then Return True
            ElseIf GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaTOExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaTOExternal = Creteria
                If CreteriaL.ToExternalID = Entity.ToExternalID Then Return True
            End If
            Return False
        End Function
    End Class
    Public Class DataRepository
        Inherits MyBook.Repositories.DatabaseRepository(Of Integer, RelationShip.Entity.Entity)

        Sub New(Src As String, NameDatabase As String, Columns As String)
            MyBase.New("Microsoft.ACE.OLEDB.16.0", Src, NameDatabase, Columns)
        End Sub
        Public Overrides Function ConvertRows(Entity As Entity.Entity) As String()
            Return {Entity.PrimaryKey, Entity.ExternalID, Entity.ToExternalID}
        End Function

        Public Overrides Function ConvertEntity(DT As DataRow) As Entity.Entity
            Dim Entity As New Entity.Entity
            With Entity
                .PrimaryKey = DT(0)
                .ExternalID = DT(1)
                .ToExternalID = DT(2)
            End With
            Return Entity
        End Function

        Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
            If GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaExtrenalAndToExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaExtrenalAndToExternal = Creteria
                If CreteriaL.ExternalID = Entity.ExternalID And CreteriaL.ToExternalID = Entity.ToExternalID Then Return True
            ElseIf GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaExternal = Creteria
                If CreteriaL.ExternalID = Entity.ExternalID Then Return True
            ElseIf GetType(TCreteria) = GetType(RelationShip.Contracts.ICreteriaTOExternal) Then
                Dim CreteriaL As RelationShip.Contracts.ICreteriaTOExternal = Creteria
                If CreteriaL.ToExternalID = Entity.ToExternalID Then Return True
            End If
            Return False
        End Function
    End Class
End Namespace

