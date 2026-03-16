''' <summary>
''' Repository 
''' </summary>
''' <typeparam name="TKey">PK</typeparam>
''' <typeparam name="TEntity">Entity</typeparam>
Public Interface IRepository(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey))
    Function Create(Entity As TEntity) As Boolean
    Function Update(PK As Tkey, Entity As TEntity) As Boolean
    Function Update(index As Integer, Entity As TEntity) As Boolean
    Function Delete(Entity As TEntity) As Boolean
    Function Delete(PK As Tkey) As Boolean
    Function DeleteAt(Index As Integer) As Boolean
    Function Read_All() As List(Of TEntity)
    Function Read_Item(PK As Tkey) As TEntity
    Function Read_Item(Index As Integer) As TEntity
    Sub RemoveAll()
End Interface


Public Class Repository(Of Tkey, TEntity As MyBook.IEntityAbles(Of Tkey))
    Implements IRepository(Of Tkey, TEntity)

    ReadOnly AutoPrimaryKey As Boolean

    Protected Friend ReadOnly Rep As New List(Of TEntity)

    ''' <summary>
    ''' Αυτόματο Πέρασμα PK αν ειναι Integer.
    ''' </summary>
    ''' <param name="PrimaryKeyAuto">Αυτόματο Random PK</param>
    Sub New(PrimaryKeyAuto As Boolean)
        AutoPrimaryKey = PrimaryKeyAuto
    End Sub

    Public Overridable Sub RemoveAll() Implements IRepository(Of Tkey, TEntity).RemoveAll
        Rep.Clear()
    End Sub

    Public Overridable Function Create(Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Create
        Dim rnd As New Random
        If AutoPrimaryKey = True AndAlso GetType(Tkey) Is GetType(Integer) Then
Again:
            Randomize()
            Entity.PrimaryKey = CType(rnd.Next, Object)
        End If

        For i = 0 To Rep.Count - 1
            If Rep(i).EqualsByPrimaryKey(Entity.PrimaryKey) Then
                If AutoPrimaryKey = True Then
                    GoTo Again
                End If
                Return False
            End If
        Next
        Rep.Add(Entity)
        Return True
    End Function

    Public Overridable Function Update(PK As Tkey, Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Update
        For i = 0 To Rep.Count - 1
            If Rep(i).EqualsByPrimaryKey(PK) Then
                Rep(i) = Entity
                Return True
            End If
        Next
        Return False
    End Function

    Public Overridable Function Delete(Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Delete
        For i = 0 To Rep.Count - 1
            If Rep(i).Equals(Entity) Then
                Rep.RemoveAt(i)
                Return True
            End If
        Next
        Return False
    End Function

    Public Overridable Function Read_All() As List(Of TEntity) Implements IRepository(Of Tkey, TEntity).Read_All
        Dim Result As New List(Of TEntity)
        For i = 0 To Rep.Count - 1
            Result.Add(Rep(i))
        Next
        Return Result
    End Function

    Public Overridable Function Read_Item(PK As Tkey) As TEntity Implements IRepository(Of Tkey, TEntity).Read_Item
        For i = 0 To Rep.Count - 1
            If Rep(i).EqualsByPrimaryKey(PK) Then
                Return Rep(i)
            End If
        Next
        Return Nothing
    End Function

    Public Overridable Function Read_Item(Index As Integer) As TEntity Implements IRepository(Of Tkey, TEntity).Read_Item
        Return Rep(Index)
    End Function

    Public Overridable Function Update(index As Integer, Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Update
        If Rep(index) IsNot Nothing Then
            Rep(index) = Entity
            Return True
        Else
            Return False
        End If
    End Function




    Public Overridable Function Delete(PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).Delete
        For i = 0 To Rep.Count - 1
            If Rep(i).EqualsByPrimaryKey(PK) Then
                Rep.RemoveAt(i)
                Return True
            End If
        Next
        Return False
    End Function

    Public Overridable Function Delete(Index As Integer) As Boolean Implements IRepository(Of Tkey, TEntity).DeleteAt
        If Rep(Index) IsNot Nothing Then
            Rep.RemoveAt(Index)
            Return True
        Else
            Return False
        End If
    End Function

End Class