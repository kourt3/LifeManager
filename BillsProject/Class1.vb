Namespace Base.Ables
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IEteria
        Property Etairia As String
    End Interface
    Public Interface IPersonID
        Property PersonID As Integer
    End Interface
    Public Interface IAFM
        Property AFM As String
    End Interface
    Public Interface IDOY
        Property DOY As String
    End Interface
    Public Interface IArithmousEgrafoy
        Property ArithmosEgrafoy As String
    End Interface
    Public Interface IHmeromhniaEkdoshs
        Property HmeromhniaEkdoshs As Date
    End Interface

End Namespace
Namespace Base.Entity
    Structure BaseData
        Dim ID As Integer
        Dim Etairia As String
        Dim PersonID As Integer
        Dim AFM As String
        Dim DOY As String
        Dim ArithmosEgrafou As String
        Dim HmeromhniaEkdoshs As Date
    End Structure
    Public Interface IEntity
        Inherits Ables.IReference, Ables.IPersonID, Ables.IEteria, Ables.IAFM, Ables.IDOY, Ables.IArithmousEgrafoy, Ables.IHmeromhniaEkdoshs
    End Interface
End Namespace
Namespace Electric.Ables

End Namespace
Namespace Electric.Entity
    Structure ElectricData
        Dim KwdikosPelati As String
        Dim ARParoxhs As String
        Dim NextMetrisi As Date
        Dim StartKatanalwsh As Date
        Dim EndKatanalwsh As Date
        Dim HmAnaforas As Date
        Dim PayUntil As Date
        Dim SumMoney As Double
    End Structure
End Namespace
