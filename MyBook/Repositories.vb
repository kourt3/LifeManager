Namespace Repositories
    ''' <summary>
    ''' Repository Με PK για μοναδικές εγραφές
    ''' </summary>
    ''' <typeparam name="Tkey">Type PK</typeparam>
    ''' <typeparam name="TEntity">Entity</typeparam>
    Public Interface IRepository(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey))
        Property Rep As List(Of TEntity)
        ''' <summary>
        ''' Δινει καινουργιο ID
        ''' </summary>
        ''' <returns></returns>
        Function GeneredID() As Tkey
        ''' <summary>
        ''' Διμιουργει ID αυτοματα
        ''' </summary>
        ''' <param name="Entity">Αν ειναι class Πέρνεις και το To ID ολοκληρο απο το Entity (Ιδιο σαν το CreateAndReturnID)</param>
        ''' <returns></returns>
        Function Create(Entity As TEntity) As Boolean

        ''' <summary>
        ''' Δεν έχει καμια λειτουργεια με το PK
        ''' </summary>
        ''' <param name="Entity"></param>
        ''' <returns></returns>
        Function Add(Entity As TEntity) As Boolean


        ''' <summary>
        ''' Βάζεις Χειροκήνητα το ID
        ''' </summary>
        ''' <param name="Entity"></param>
        ''' <param name="PK"></param>
        ''' <returns></returns>
        Function TryCreate(Entity As TEntity, PK As Tkey) As Boolean
        ''' <summary>
        ''' Διμιουργει αυτόματα ID και Επιστρέφει το ID Στα attribute
        ''' </summary>
        ''' <param name="Entity"></param>
        ''' <param name="PK">Επιστροφή ID</param>
        ''' <returns></returns>
        Function CreateAndReturnID(Entity As TEntity, ByRef PK As Tkey) As Boolean

        Function Update(PK As Tkey, Entity As TEntity) As Boolean
        Function UpdateAt(index As Integer, Entity As TEntity) As Boolean
        Function UpdateWhere(Match As Predicate(Of TEntity), Update As Func(Of TEntity, TEntity)) As Boolean
        Function Delete(Entity As TEntity) As Boolean
        Function Delete(PK As Tkey) As Boolean
        Function DeleteAt(Index As Integer) As Boolean
        Function DeleteWhere(Match As Predicate(Of TEntity)) As Boolean
        Function Read_All() As List(Of TEntity)
        Function Read_Item(PK As Tkey) As TEntity
        Function Read_ItemAt(Index As Integer) As TEntity
        Function Exist(PK As Tkey) As Boolean
        Function Find(Of TCreteria)(Creteria As TCreteria) As TEntity
        Function Find(Match As Predicate(Of TEntity)) As TEntity
        Function Search(Of TCreteria)(Creteria As TCreteria) As List(Of TEntity)
        Function Search(Matches As Predicate(Of TEntity)) As List(Of TEntity)
        Sub RemoveAll()
    End Interface

    Public MustInherit Class Repository(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey))
        Implements IRepository(Of Tkey, TEntity)

        Protected Friend Property Rep As New List(Of TEntity) Implements IRepository(Of Tkey, TEntity).Rep

        Public Overridable Sub RemoveAll() Implements IRepository(Of Tkey, TEntity).RemoveAll
            Rep.Clear()
        End Sub

        Public Overridable Function Create(Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Create
            Dim rnd As New Random
Again:
                Randomize()
            Entity.PrimaryKey = CType(rnd.Next, Object)
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, Entity.PrimaryKey) Then
                    GoTo Again
                    Return False
                End If
            Next
            Rep.Add(Entity)
            Return True
        End Function

        Public Overridable Function Update(PK As Tkey, Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Update
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
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
                If Equals(Rep(i).PrimaryKey, PK) Then
                    Return Rep(i)
                End If
            Next
            Return Nothing
        End Function

        Public Overridable Function Read_ItemAt(Index As Integer) As TEntity Implements IRepository(Of Tkey, TEntity).Read_ItemAt
            Return Rep(Index)
        End Function

        Public Overridable Function UpdateAT(index As Integer, Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).UpdateAt
            If Rep(index) IsNot Nothing Then
                Rep(index) = Entity
                Return True
            Else
                Return False
            End If
        End Function




        Public Overridable Function Delete(PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).Delete
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
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

        Public Function GeneredID() As Tkey Implements IRepository(Of Tkey, TEntity).GeneredID
            Dim rnd As New Random
            Dim PK As Tkey = CType(0, Object)
Again:
                Randomize()
                PK = CType(rnd.Next, Object)

            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    GoTo Again
                End If
            Next

            Return PK
        End Function

        Public Function TryCreate(Entity As TEntity, PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).TryCreate
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    Return False
                End If
            Next
            Entity.PrimaryKey = PK
            Rep.Add(Entity)
            Return True
        End Function

        Public Function CreateAndReturnID(Entity As TEntity, ByRef PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).CreateAndReturnID
            Dim rnd As New Random
Again:
                Randomize()
                PK = CType(rnd.Next, Object)
            Entity.PrimaryKey = PK
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, Entity.PrimaryKey) Then
                    GoTo Again
                End If
            Next
            Rep.Add(Entity)
            Return True
        End Function

        Public Function Exist(PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).Exist
            For i = 0 To Rep.Count - 1
                If Equals(Rep(i).PrimaryKey, PK) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function UpdateWhere(Match As Predicate(Of TEntity), Update As Func(Of TEntity, TEntity)) As Boolean Implements IRepository(Of Tkey, TEntity).UpdateWhere
            Dim Change As Boolean = False
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
                    Rep(i) = Update(Rep(i))
                    Change = True
                End If
            Next
            Return Change
        End Function

        Public Function Search(Of TCreteria)(Creteria As TCreteria) As List(Of TEntity) Implements IRepository(Of Tkey, TEntity).Search
            Dim Result As New List(Of TEntity)
            For i = 0 To Rep.Count - 1
                If Match(Rep(i), Creteria) Then Result.Add(Rep(i))
            Next
            Return Result
        End Function

        Public Function Search(Match As Predicate(Of TEntity)) As List(Of TEntity) Implements IRepository(Of Tkey, TEntity).Search
            Dim Result As New List(Of TEntity)
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
                    Result.Add(Rep(i))
                End If
            Next
            Return Result
        End Function

        MustOverride Function Match(Of TCreteria)(Entity As TEntity, Creteria As TCreteria) As Boolean
        Public Function Find(Of TCreteria)(Creteria As TCreteria) As TEntity Implements IRepository(Of Tkey, TEntity).Find
            For i = 0 To Rep.Count - 1
                If Match(Rep(i), Creteria) Then Return Rep(i)
            Next
            Return Nothing
        End Function
        Public Function Find(Match As Predicate(Of TEntity)) As TEntity Implements IRepository(Of Tkey, TEntity).Find
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then Return Rep(i)
            Next
            Return Nothing
        End Function

        Public Function DeleteWhere(Match As Predicate(Of TEntity)) As Boolean Implements IRepository(Of Tkey, TEntity).DeleteWhere
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
                    Rep.RemoveAt(i)
                    Return True
                End If
            Next
            Return False
        End Function

        Public Function Add(Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Add
            Rep.Add(Entity)
            Return True
        End Function
    End Class
End Namespace

