Imports MyBook.RelationShip.Contracts
Imports MyBook.RelationShip.Repositories
Imports MyBook.Repositories
Namespace Services
    Public Interface IService(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey))
        Function Exist(Ref As TEntity) As MyBook.ValMsg(Of TEntity)
        Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of TEntity)
        Function Change(Of DTO)(Ref As TEntity, ChangeDTO As DTO) As MyBook.ValMsg
        Function Remove(Ref As TEntity) As MyBook.ValMsg
        Function Get_All() As MyBook.ValMsg(Of List(Of TEntity))
    End Interface

    ''' <summary>
    ''' O Service Επιστρέφει το γνησιο αντικειμενο του ENTITY.
    ''' Δεν ειναι και τοσο ασφαλες γιατι η κάθε αλλαγη δεν περναει απο τον Service.
    ''' οι αλλαγες μπορουν να γινουν και χωρις καποιο ελενχο απο το χρηστη εκτως αμα περασεις μεσο αντιγραφει στο service.
    ''' </summary>
    ''' <typeparam name="TKey"></typeparam>
    ''' <typeparam name="TEntity"></typeparam>
    ''' <typeparam name="TRepository"></typeparam>
    Public MustInherit Class Service(Of TKey, TEntity As MyBook.IHasPrimaryKey(Of TKey), TRepository As IRepository(Of TKey, TEntity))
        Implements IService(Of TKey, TEntity)

        Public Property Repository As TRepository

        Sub New(RepositoryLink As MyBook.Repositories.IRepository(Of TKey, TEntity))
            Repository = RepositoryLink
        End Sub

        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO) As TEntity
        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO, Entity As TEntity) As TEntity

        Overridable Function Exist(Ref As TEntity) As MyBook.ValMsg(Of TEntity) Implements IService(Of TKey, TEntity).Exist
            Dim Result As New MyBook.ValMsg(Of TEntity)
            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If

            Result.Model = Entity
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function
        Overridable Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of TEntity) Implements IService(Of TKey, TEntity).Register
            Dim Val As New MyBook.ValMsg(Of TEntity)

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"
                Val.Model = Entity
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function
        Overridable Function Change(Of DTO)(Ref As TEntity, ChangeDTO As DTO) As MyBook.ValMsg Implements IService(Of TKey, TEntity).Change
            Dim Val As New MyBook.ValMsg

            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)
            Entity = ToEntity(ChangeDTO, Entity)
            If Repository.Update(Ref.PrimaryKey, Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Αλλαγή!"
            Else
                Val.Success = False
                Val.Msg = "Αποτηχία Αλλαγής!"
            End If
            Return Val
        End Function
        Overridable Function Remove(Ref As TEntity) As MyBook.ValMsg Implements IService(Of TKey, TEntity).Remove
            Dim Val As New MyBook.ValMsg
            If Repository.Delete(Ref.PrimaryKey) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Διαγραφής!"
            Else
                Val.Success = False
                Val.Msg = "Αποτυχία Διαγραφής!"
            End If
            Return Val
        End Function
        Overridable Function Get_All() As MyBook.ValMsg(Of List(Of TEntity)) Implements IService(Of TKey, TEntity).Get_All
            Dim Val As New MyBook.ValMsg(Of List(Of TEntity))
            Val.Model = New List(Of TEntity)
            For Each Entity In Repository.Read_All
                Val.Model.Add(Entity)
            Next
            If Val.Model.Count > 0 Then
                Val.Success = True
                Val.Msg = "Βρέθηκε Εγραφή!"
            Else
                Val.Success = False
                Val.Msg = "Δεν Βρέθηκε Εγραφή!"
            End If
            Return Val
        End Function

    End Class
    ''' <summary>
    ''' O Services Επιστρέφει ενα αντιγραφο του Entity
    ''' </summary>
    ''' <typeparam name="Tkey"></typeparam>
    ''' <typeparam name="TEntity"></typeparam>
    ''' <typeparam name="TRepository"></typeparam>
    Public MustInherit Class ServiceMC(Of Tkey, TEntity As MyBook.IHasPrimaryKey(Of Tkey), TRepository As Repositories.IRepository(Of Tkey, TEntity))
        Implements IService(Of Tkey, TEntity)

        Public Property Repository As TRepository
        Sub New(ReposirotyLink As TRepository)
            Repository = ReposirotyLink
        End Sub
        MustOverride Function MemberizeClone(Enity As TEntity) As TEntity
        MustOverride Function ToEntity(Of TDTO)(DTO As TDTO) As TEntity
        MustOverride Function ToEntity(Of TDTO)(DTO As TDTO, Entity As TEntity) As TEntity
        Public Overridable Function Exist(Ref As TEntity) As ValMsg(Of TEntity) Implements IService(Of Tkey, TEntity).Exist
            Dim Result As New MyBook.ValMsg(Of TEntity)
            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If

            Result.Model = MemberizeClone(Entity)
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function

        Public Overridable Function Register(Of DTO)(RegisterDTO As DTO) As ValMsg(Of TEntity) Implements IService(Of Tkey, TEntity).Register
            Dim Val As New MyBook.ValMsg(Of TEntity)

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"
                Val.Model = MemberizeClone(Entity)
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function

        Public Overridable Function Change(Of DTO)(Ref As TEntity, ChangeDTO As DTO) As ValMsg Implements IService(Of Tkey, TEntity).Change
            Dim Val As New MyBook.ValMsg

            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)
            Entity = ToEntity(ChangeDTO, Entity)
            If Repository.Update(Ref.PrimaryKey, Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Αλλαγή!"
            Else
                Val.Success = False
                Val.Msg = "Αποτηχία Αλλαγής!"
            End If
            Return Val
        End Function

        Public Overridable Function Remove(Ref As TEntity) As ValMsg Implements IService(Of Tkey, TEntity).Remove
            Dim Val As New MyBook.ValMsg
            If Repository.Delete(Ref.PrimaryKey) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Διαγραφής!"
            Else
                Val.Success = False
                Val.Msg = "Αποτυχία Διαγραφής!"
            End If
            Return Val
        End Function

        Public Overridable Function Get_All() As ValMsg(Of List(Of TEntity)) Implements IService(Of Tkey, TEntity).Get_All
            Dim Val As New MyBook.ValMsg(Of List(Of TEntity))
            Val.Model = New List(Of TEntity)
            For Each Entity In Repository.Read_All
                Val.Model.Add(MemberizeClone(Entity))
            Next
            If Val.Model.Count > 0 Then
                Val.Success = True
                Val.Msg = "Βρέθηκε Εγραφή!"
            Else
                Val.Success = False
                Val.Msg = "Δεν Βρέθηκε Εγραφή!"
            End If
            Return Val
        End Function
    End Class



    Public Interface IService(Of TKey, TModel As MyBook.IHasPrimaryKey(Of TKey), TEntity As MyBook.IHasPrimaryKey(Of TKey))
        Function Exist(Ref As TModel) As MyBook.ValMsg(Of TModel)
        Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of TModel)
        Function Change(Of DTO)(Ref As TModel, ChangeDTO As DTO) As MyBook.ValMsg
        Function Remove(Ref As TModel) As MyBook.ValMsg
        Function Get_All() As MyBook.ValMsg(Of List(Of TModel))
    End Interface

    ''' <summary>
    ''' Ο Service επιστρέφει το Model που ειναι ενα αντιγραφο του Entity΄,
    ''' Είναι ποιο ασφάλες και δεν μπορει να αλλαξει το αρχικο entity χώρις να περασει καποια εντολη απο τον Service!
    ''' </summary>
    ''' <typeparam name="TKey">Τον Τύπο του PK</typeparam>
    ''' <typeparam name="TModel">Το Model που κανει αντιγραφη απο το Entity</typeparam>
    ''' <typeparam name="TEntity">Το Αρχικο entity</typeparam>
    ''' <typeparam name="TRepository">To Αποθετήριο</typeparam>
    Public MustInherit Class Service(Of TKey, TModel As MyBook.IHasPrimaryKey(Of TKey), TEntity As MyBook.IHasPrimaryKey(Of TKey), TRepository As IRepository(Of TKey, TEntity))
        Implements IService(Of TKey, TModel, TEntity)

        Public Property Repository As TRepository

        Sub New(RepositoryLink As MyBook.Repositories.IRepository(Of TKey, TEntity))
            Repository = RepositoryLink
        End Sub

        MustOverride Function ToModel(Entity As TEntity) As TModel
        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO) As TEntity
        MustOverride Function ToEntity(Of DTO)(DTOLink As DTO, Entity As TEntity) As TEntity

        Overridable Function Exist(Ref As TModel) As MyBook.ValMsg(Of TModel) Implements IService(Of TKey, TModel, TEntity).Exist
            Dim Result As New MyBook.ValMsg(Of TModel)
            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)

            If Entity Is Nothing Then
                Result.Success = False
                Result.Msg = "Δεν βρέθηκε η Εγραφή!"
                Return Result
            End If

            Result.Model = ToModel(Entity)
            Result.Success = True
            Result.Msg = "Βρέθηκε η Εγραφη!"
            Return Result
        End Function
        Overridable Function Register(Of DTO)(RegisterDTO As DTO) As MyBook.ValMsg(Of TModel) Implements IService(Of TKey, TModel, TEntity).Register
            Dim Val As New MyBook.ValMsg(Of TModel)

            Dim Entity As TEntity = ToEntity(RegisterDTO)
            If Repository.Create(Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχης Εγραφή !"
                Val.Model = ToModel(Entity)
                Return Val
            Else
                Val.Success = False
                Val.Msg = "αποτυχία Εγραφής !"
                Return Val
            End If
        End Function
        Overridable Function Change(Of DTO)(Ref As TModel, ChangeDTO As DTO) As MyBook.ValMsg Implements IService(Of TKey, TModel, TEntity).Change
            Dim Val As New MyBook.ValMsg

            Dim Entity As TEntity = Repository.Read_Item(Ref.PrimaryKey)
            Entity = ToEntity(ChangeDTO, Entity)
            If Repository.Update(Ref.PrimaryKey, Entity) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Αλλαγή!"
            Else
                Val.Success = False
                Val.Msg = "Αποτηχία Αλλαγής!"
            End If
            Return Val
        End Function
        Overridable Function Remove(Ref As TModel) As MyBook.ValMsg Implements IService(Of TKey, TModel, TEntity).Remove
            Dim Val As New MyBook.ValMsg
            If Repository.Delete(Ref.PrimaryKey) Then
                Val.Success = True
                Val.Msg = "Επιτυχής Διαγραφής!"
            Else
                Val.Success = False
                Val.Msg = "Αποτυχία Διαγραφής!"
            End If
            Return Val
        End Function
        Overridable Function Get_All() As MyBook.ValMsg(Of List(Of TModel)) Implements IService(Of TKey, TModel, TEntity).Get_All
            Dim Val As New MyBook.ValMsg(Of List(Of TModel))
            Val.Model = New List(Of TModel)
            For Each Entity In Repository.Read_All
                Val.Model.Add(ToModel(Entity))
            Next
            If Val.Model.Count > 0 Then
                Val.Success = True
                Val.Msg = "Βρέθηκε Εγραφή!"
            Else
                Val.Success = False
                Val.Msg = "Δεν Βρέθηκε Εγραφή!"
            End If
            Return Val
        End Function

    End Class
End Namespace