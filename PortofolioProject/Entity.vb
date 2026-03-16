Namespace My.Enity
    Structure Data
        Public Id As Integer
        Public Name As String
        Public Description As String
    End Structure

    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IEntity
        Inherits IReference
        Inherits MyBook.IHasName
        Inherits MyBook.IHasDescription
    End Interface

    Public Class Entity
        Implements IEntity

        Private Data As New Data
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
            End Set
        End Property

        Public Property Name As String Implements MyBook.IHasName.Name
            Get
                Return Data.Name
            End Get
            Set(value As String)
                Data.Name = value
            End Set
        End Property

        Public Property Description As String Implements MyBook.IHasDescription.Description
            Get
                Return Data.Description
            End Get
            Set(value As String)
                Data.Description = value
            End Set
        End Property
    End Class
End Namespace

