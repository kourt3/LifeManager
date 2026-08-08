Namespace Repositories
    ''' <summary>
    ''' <strong>To Αποθετήριο μιας βάση δεδομένων</strong><br/>
    ''' όλες οι εντολες που θα χρειάστεις για να κανεις ενα αποθετήριο βάση δεδομένων.
    ''' </summary>
    ''' <remarks><em>Σε ένα Αποθετήριο για την αναγνώριση,επιλογή και έλεγχο των δεδομένων σε μια βάση θα χρειαστεί σε ενα πεδιο των δεδομένων να ορήσεις <see cref="MyBook.IHasPrimaryKey(Of T)"/></em></remarks>
    ''' <typeparam name="Tkey">Τον τύπο του PK(Primary Key)</typeparam>
    ''' <typeparam name="TEntity">Βάση Δεδομένων</typeparam>
    Public Interface IRepository(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey))
        ''' <summary>
        ''' Δημιουργει ενα κλειδί για το πεδίο <see cref="MyBook.IHasPrimaryKey(Of T).PrimaryKey"/>
        ''' </summary>
        ''' <returns>Την τιμή του κλειδίου</returns>
        Function GeneredID() As Tkey
        ''' <summary>
        ''' Δημιουργει και συμπληρώνει μια τιμή για το <see cref="MyBook.IHasPrimaryKey(Of T).PrimaryKey">PK(Primary key)</see> και προσθέτει αυτόματα την <paramref name="Entity"/> στο αποθετήριο.
        ''' </summary>
        ''' <param name="Entity">Βάση δεδομένων</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Create(Entity As TEntity) As Boolean
        ''' <summary>
        ''' Προσθέτει την <paramref name="Entity">Βάση δεδομένων</paramref> στο αποθετήριο.
        ''' </summary>
        ''' <example>
        ''' 
        ''' <code>
        ''' dim a as string =  4
        ''' 
        ''' </code>
        ''' 
        ''' </example>
        ''' <param name="Entity">Βάση δεδομένων</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Add(Entity As TEntity) As Boolean
        ''' <summary>
        ''' Βάζεις Χειροκίνητα το ID
        ''' </summary>
        ''' <param name="Entity">Βάση δεδομένον</param>
        ''' <param name="PK">Πεδίο του PK</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function TryCreate(Entity As TEntity, PK As Tkey) As Boolean
        ''' <summary>
        ''' 1) <inheritdoc cref="GeneredID()"/> Επιστρέφει την τιμή στο <paramref name="PK"/><br/>
        ''' 2) <inheritdoc cref="Add(TEntity)"/><br/>
        ''' </summary>
        ''' <param name="Entity">Βάση δεδομένον</param>
        ''' <param name="PK"> Πεδίο του PK</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function CreateAndReturnID(Entity As TEntity, ByRef PK As Tkey) As Boolean
        ''' <summary>
        ''' Μεσο του <paramref name="PK"/> αναζηταει στην λιστα που βρίσκεται το πεδιο και αντικατασταει τα δεδομένα μεσο του <paramref name="Entity"/>.
        ''' </summary>
        ''' <param name="PK">To ID τον δεδομένων.</param>
        ''' <param name="Entity">Τα καινούργια δεδομένα</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Update(PK As Tkey, Entity As TEntity) As Boolean
        ''' <summary>
        ''' Μεσο του <paramref name="index"/> που βρίσκεται στην λίστα αντικατασταει τα δεδομένα μεσο του <paramref name="Entity"/>.
        ''' </summary>
        ''' <param name="index">Τον αριθμο της καταριθμημένης λίστας</param>
        ''' <param name="Entity">Τα καινούργια δεδομένα</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function UpdateAt(index As Integer, Entity As TEntity) As Boolean
        ''' <summary>
        ''' Μεσο του <paramref name="Match"/> Βρίσκει αμα τα δεδομένα ταιριαζουν μεταξή τους και τα αντικαταστάει με τον συνδεσμο [Deligate] <paramref name="Update"/>.
        ''' </summary>
        ''' <param name="Match"></param>
        ''' <param name="Update"></param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function UpdateWhere(Match As Predicate(Of TEntity), Update As Func(Of TEntity, TEntity)) As Boolean
        ''' <summary>
        ''' Βρίσκει ενα απο δεδομενα που πέρασες μεσο <paramref name="Entity"/> αν τερίαζουν και τα διαγράφει.
        ''' </summary>
        ''' <param name="Entity">Δεδομένα</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Delete(Entity As TEntity) As Boolean
        ''' <summary>
        ''' Βρίσκει το <paramref name="PK"/> του πεδιου σε μια λιστά δεδομένων και διαγραφει τα δεδομένα.
        ''' </summary>
        ''' <param name="PK">Το πεδίο PK</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Delete(PK As Tkey) As Boolean
        ''' <summary>
        ''' Πηγαίνει στον αριθμό μεσο του <paramref name="Index"/> της καταριθμημενης λιστας  και διαγράφει τα δεδομένα της επιλογής.
        ''' </summary>
        ''' <param name="Index">Ο αριθμός επιλογης της καταριθμημενης λίστας.</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function DeleteAt(Index As Integer) As Boolean

        ''' <summary>
        ''' Αναζητάει την αντιστήχηση τον δεδομένον μεσο του <paramref name="Match"/> και διαγράφει τα δεδομένα αν αυτο ειναι εφικτο.
        ''' </summary>
        ''' <param name="Match">Αντιστήχηση δεδομένον</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function DeleteWhere(Match As Predicate(Of TEntity)) As Boolean
        ''' <summary>
        ''' Επιλέγει ολα τα δεδομένα.
        ''' </summary>
        ''' <returns>τα δεδομένα που επιλέχτηκαν.</returns>
        Function Read_All() As List(Of TEntity)
        ''' <summary>
        ''' Επιλέγει το δεδομένο που περιεχει το ιδιο πεδιο με <paramref name="PK"/>.
        ''' </summary>
        ''' <param name="PK">Το Πεδιο του PK</param>
        ''' <returns>τα δεδομένα που επιλέκτηκαν.</returns>
        Function Read_Item(PK As Tkey) As TEntity
        ''' <summary>
        ''' Επιλέγει τα δεδομενα με τον αριθμο που καταμετρήθηκε στην αριθμημενη λιστα μεσο του <paramref name="Index"/>
        ''' </summary>
        ''' <param name="Index">O Αριθμος της καταμέτρησης στην αριθμημενης λίστας.</param>
        ''' <returns>τα δεδομένα που επιλέκτηκαν.</returns>
        Function Read_ItemAt(Index As Integer) As TEntity
        ''' <summary>
        ''' Ελέγχει αν τον <paramref name="PK"/> Υπάρχει στην λίστα.
        ''' </summary>
        ''' <param name="PK">Το PK της λίστας.</param>
        ''' <returns>Αν Βρέθηκε στην λίστα.</returns>
        Function Exist(PK As Tkey) As Boolean
        ''' <summary>
        ''' Ελέγχει αν καποιο απο την λίστα πληρη ολα τα κριτίρια μεσο <paramref name="Creteria"/>.
        ''' </summary>
        ''' <typeparam name="TCreteria">Τον δεδομένα τον κριτιριον.</typeparam>
        ''' <param name="Creteria">Τα κριτίρια</param>
        ''' <returns>Αν βρέθηκαν τα Κριτίρια στην λιστα δεδομένων</returns>
        Function Exist(Of TCreteria)(Creteria As TCreteria) As Boolean
        ''' <summary>
        ''' Ελέγχει αν καποιο απο την λίστα πλήρη ολα τα κριτιρια μεσο του <paramref name="Match"/>
        ''' </summary>
        ''' <param name="Match">[Deligate] Κριτίρια</param>
        ''' <returns>Αν βρέθηκαν τα Κριτίρια στην λιστα δεδομένων</returns>
        Function Exist(Match As Predicate(Of TEntity)) As Boolean
        ''' <summary>
        ''' Eπιλέγει <b>ένα απο τα Δεδομενα της λιστας</b> εφώσον πληρη τα κριτιρια μεσο <paramref name="Creteria"/>.
        ''' </summary>
        ''' <typeparam name="TCreteria">Τον δεδομένα τον κριτιριον.</typeparam>
        ''' <param name="Creteria">Τα κριτίρια</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Find(Of TCreteria)(Creteria As TCreteria) As TEntity
        ''' <summary>
        ''' Eπιλέγει <b>ενα απο τα Δεδομενα της λιστας</b> εφώσον πληρη τα κριτιρια μεσο <paramref name="Match"/>.
        ''' </summary>
        ''' <param name="Match">Τα κριτίτα μεσο Delegate</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Find(Match As Predicate(Of TEntity)) As TEntity
        ''' <summary>
        ''' Επιλέγει <b>όλα τα Δεδομένα της λίστας</b> εφώσον πληρουν τα κριτιρια μεσο <paramref name="Creteria"/>.
        ''' </summary>
        ''' <typeparam name="TCreteria">Τον δεδομένα τον κριτιριον.</typeparam>
        ''' <param name="Creteria">Τα κριτιρια.</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Search(Of TCreteria)(Creteria As TCreteria) As List(Of TEntity)

        ''' <summary>
        ''' Επιλέγει <b>όλα τα Δεδομένα της λίστας</b> εφώσον πληρουν τα κριτιρια μεσο <paramref name="Matches"/>.
        ''' </summary>
        ''' <param name="Matches">Τα κριτιρια μεσο Deligate.</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Search(Matches As Predicate(Of TEntity)) As List(Of TEntity)
        ''' <summary>
        ''' Διαγράφη ολα τα δεδομένα της λίστας δεδομένων.
        ''' </summary>
        Sub RemoveAll()
    End Interface


    ''' <summary>
    ''' <inheritdoc cref=" IRepository(Of Tkey, TEntity)"/><br/><br/>
    ''' Το Repository εκχωρίτε μεσα στην μνημη,
    ''' χρησημοποιειτε κυριος για testing.  <br/>
    ''' θα Πρέπει να περαστει απο μεσο inherits στην class που θέλεις να κανεις αποθητεριο.
    ''' </summary>
    ''' <typeparam name="Tkey">Τύπος κλίδιου</typeparam>
    ''' <typeparam name="TEntity">Βάση δεδομένων</typeparam>
    Public MustInherit Class Repository(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey))
        Implements IRepository(Of Tkey, TEntity)


        Protected Friend Property Rep As New List(Of TEntity)

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

        Public Function Exist(Of TCreteria)(Creteria As TCreteria) As Boolean Implements IRepository(Of Tkey, TEntity).Exist
            For i = 0 To Rep.Count - 1
                If Match(Rep(i), Creteria) Then Return True
            Next
            Return False
        End Function

        Public Function Exist(Match As Predicate(Of TEntity)) As Boolean Implements IRepository(Of Tkey, TEntity).Exist
            For i = 0 To Rep.Count - 1
                If Match(Rep(i)) Then
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



    ''' <summary>
    ''' <inheritdoc cref="IRepository(Of Tkey, TEntity)"/><br/><br/>
    ''' Το αποθετηριο συνδεεται με την DatabaseAccess της Microsoft
    ''' ολες οι αλλαγες που γίνονται κατευθειαν περνανε στο access,και οι αναγνωση απο την database!<br/>
    ''' θα πρεπει να το περάσεις μεσο inherits Μεσο μια αλλης class και να initallize το new μεσα se Mybase.new
    ''' </summary>
    ''' <typeparam name="Tkey"></typeparam>
    ''' <typeparam name="TEntity"></typeparam>
    Public MustInherit Class DatabaseRepository(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey))

        Implements MyBook.Repositories.IRepository(Of Tkey, TEntity)

        ReadOnly Table As String
        ReadOnly Columns As String
        Public Database As database.DatabaseContecter
        ''' <summary>
        ''' οι Ρυθμησεις για να συνδεθει με την Database.
        ''' </summary>
        ''' <param name="Version">Version Accesdatabase της microsoft</param>
        ''' <param name="ConnectDatabase">Την διαδρομη της database</param>
        ''' <param name="tablelink">Το ονομα της Table</param>
        ''' <param name="ColumnsString">Τα columns που θα χρησημοποιησεις.</param>
        Sub New(Version As String, ConnectDatabase As String, tablelink As String, ColumnsString As String)
            Database = New database.DatabaseContecter(Version, ConnectDatabase)
            Table = tablelink
            Columns = ColumnsString
        End Sub

        MustOverride Function ConvertRows(Entity As TEntity) As String()
        MustOverride Function ConvertEntity(DT As DataRow) As TEntity
        MustOverride Function Match(Of TCreteria)(Entity As TEntity, Creteria As TCreteria) As Boolean

        Public Sub RemoveAll() Implements IRepository(Of Tkey, TEntity).RemoveAll
            Database.TableDbOLe(Database.DeleteDB(Table))
        End Sub

        Public Function GeneredID() As Tkey Implements IRepository(Of Tkey, TEntity).GeneredID
            Dim rnd As New Random
            Dim PK As Tkey = CType(0, Object)
            Dim DT As New DataTable


Again:
            Randomize()
            PK = CType(rnd.Next, Object)
            Database.TableDbOLe(Database.SelectWhereDB(Table, "[ID]=" & CType(PK, Object)), DT)

            If DT.Rows.Count > 0 Then
                DT.Clear()
                GoTo Again
            End If


            Return PK
        End Function

        Public Function Create(Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Create
            Dim rnd As New Random
            Dim DT As New DataTable
Again:
            Randomize()
            Entity.PrimaryKey = CType(rnd.Next, Object)
            Database.TableDbOLe(Database.SelectWhereDB(Table, "[ID]=" & CType(Entity.PrimaryKey, Object)), DT)

            If DT.Rows.Count > 0 Then
                DT.Clear()
                GoTo Again
            End If
            Database.TableDbOLe(Database.insertDB(Table, Columns, ConvertRows(Entity)))
            Return True
        End Function

        Public Function Add(Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Add
            Database.TableDbOLe(Database.insertDB(Table, Columns, ConvertRows(Entity)))
            Return True
        End Function

        Public Function TryCreate(Entity As TEntity, PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).TryCreate
            Database.TableDbOLe(Database.insertDB(Table, Columns, ConvertRows(Entity)))
            Return True
        End Function

        Public Function CreateAndReturnID(Entity As TEntity, ByRef PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).CreateAndReturnID
            Throw New NotImplementedException()
        End Function

        Public Function Update(PK As Tkey, Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Update
            Entity.PrimaryKey = PK
            Dim Str As String() = ConvertRows(Entity)
            Dim Str1(Str.Length - 2) As String
            For i = 1 To Str.Length - 1
                Str1(i - 1) = Str(i)
            Next
            Dim ColumnCopy As String = Columns.Replace("[ID],", Nothing)
            Database.TableDbOLe(Database.updateDB(Table, "[ID]=" & CType(PK, Object), ColumnCopy, Str1))
            Return True
        End Function

        Public Function UpdateAt(index As Integer, Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).UpdateAt
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            Dim ID As Integer = DT(index)(0)
            Dim Str As String() = ConvertRows(Entity)
            Dim Str1(Str.Length - 2) As String
            For i = 1 To Str.Length - 1
                Str1(i - 1) = Str(i)
            Next
            Dim ColumnCopy As String = Columns.Replace("[ID],", Nothing)
            Database.TableDbOLe(Database.updateDB(Table, "[ID]=" & ID, ColumnCopy, Str1))
            Return True
        End Function

        Public Function UpdateWhere(Match As Predicate(Of TEntity), Update As Func(Of TEntity, TEntity)) As Boolean Implements IRepository(Of Tkey, TEntity).UpdateWhere
            Throw New NotImplementedException()
        End Function

        Public Function Delete(Entity As TEntity) As Boolean Implements IRepository(Of Tkey, TEntity).Delete
            Throw New NotImplementedException()
        End Function

        Public Function Delete(PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).Delete
            Database.TableDbOLe(Database.DeleteDB(Table, "[ID]=" & CType(PK, Object)))
            Return True
        End Function

        Public Function DeleteAt(Index As Integer) As Boolean Implements IRepository(Of Tkey, TEntity).DeleteAt
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            Dim ID As Integer = DT(Index)(0)
            Database.TableDbOLe(Database.DeleteDB(Table, "[ID]=" & ID))
            Return True
        End Function

        Public Function DeleteWhere(Match As Predicate(Of TEntity)) As Boolean Implements IRepository(Of Tkey, TEntity).DeleteWhere
            Throw New NotImplementedException()
        End Function

        Public Function Read_All() As List(Of TEntity) Implements IRepository(Of Tkey, TEntity).Read_All
            Dim DT As New DataTable
            Dim ListEntity As New List(Of TEntity)
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            For i = 0 To DT.Rows.Count - 1
                ListEntity.Add(ConvertEntity(DT(i)))
            Next
            Return ListEntity
        End Function

        Public Function Read_Item(PK As Tkey) As TEntity Implements IRepository(Of Tkey, TEntity).Read_Item
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectWhereDB(Table, "[ID]=" & CType(PK, Object)), DT)
            If DT.Rows.Count = 0 Then
                Return Nothing
            End If
            Return ConvertEntity(DT(0))
        End Function

        Public Function Read_ItemAt(Index As Integer) As TEntity Implements IRepository(Of Tkey, TEntity).Read_ItemAt
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            Return ConvertEntity(DT(Index))
        End Function

        Public Function Exist(PK As Tkey) As Boolean Implements IRepository(Of Tkey, TEntity).Exist
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectWhereDB(Table, "[ID]=" & CType(PK, Object)), DT)
            If DT.Rows.Count = 0 Then
                Return False
            End If
            Return True
        End Function

        Public Function Find(Of TCreteria)(Creteria As TCreteria) As TEntity Implements IRepository(Of Tkey, TEntity).Find
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            For i = 0 To DT.Rows.Count - 1
                If Match(ConvertEntity(DT(i)), Creteria) Then Return ConvertEntity(DT(i))
            Next
        End Function

        Public Function Find(Match As Predicate(Of TEntity)) As TEntity Implements IRepository(Of Tkey, TEntity).Find
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            For i = 0 To DT.Rows.Count - 1
                If Match(ConvertEntity(DT(i))) Then Return ConvertEntity(DT(i))
            Next
        End Function

        Public Function Search(Of TCreteria)(Creteria As TCreteria) As List(Of TEntity) Implements IRepository(Of Tkey, TEntity).Search
            Dim Entity As New List(Of TEntity)
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            For i = 0 To DT.Rows.Count - 1
                If Match(ConvertEntity(DT(i)), Creteria) Then
                    Entity.Add(ConvertEntity(DT(i)))
                End If
            Next
            Return Entity
        End Function

        Public Function Search(Matches As Predicate(Of TEntity)) As List(Of TEntity) Implements IRepository(Of Tkey, TEntity).Search
            Dim Entity As New List(Of TEntity)
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            For i = 0 To DT.Rows.Count - 1
                If Matches(ConvertEntity(DT(i))) Then
                    Entity.Add(ConvertEntity(DT(i)))
                End If
            Next
            Return Entity
        End Function

        Public Function Exist(Of TCreteria)(Creteria As TCreteria) As Boolean Implements IRepository(Of Tkey, TEntity).Exist
            Dim Entity As New List(Of TEntity)
            Dim DT As New DataTable
            Database.TableDbOLe(Database.SelectDB(Table), DT)
            For i = 0 To DT.Rows.Count - 1
                Entity.Add(ConvertEntity(DT(i)))
            Next
            For Each entiL In Entity
                If Match(entiL, Creteria) Then Return True
            Next
            Return False
        End Function

        Public Function Exist(Match As Predicate(Of TEntity)) As Boolean Implements IRepository(Of Tkey, TEntity).Exist
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace

