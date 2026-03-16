Imports PersonProject.My.Ables

Namespace My.Enity
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Structure Data
        Public Id As Integer
        Public FirstName As String
        Public SecondName As String
        Public Birthday As Date
    End Structure

    Public Interface IEntity
        Inherits IReference
        Inherits Ables.IFirstName
        Inherits Ables.ISecondName
        Inherits Ables.IBirthDay
    End Interface

    Public Class Entity
        Implements IEntity, IReference
        Private Data As New Data
        Public Property FristName As String Implements IFirstName.FristName
            Get
                Return Data.FirstName
            End Get
            Set(value As String)
                Data.FirstName = value
            End Set
        End Property

        Public Property SecondName As String Implements ISecondName.SecondName
            Get
                Return Data.SecondName
            End Get
            Set(value As String)
                Data.SecondName = value
            End Set
        End Property

        Public Property Birthday As Date Implements IBirthDay.Birthday
            Get
                Return Data.Birthday
            End Get
            Set(value As Date)
                Data.Birthday = value
            End Set
        End Property

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
            End Set
        End Property
    End Class
End Namespace