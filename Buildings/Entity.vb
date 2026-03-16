Namespace My.Entity

    Structure Data
        Dim Id As Integer
        Dim Length As Double
        Dim Width As Double
        Dim Description As String
        Dim Dieythinsi As String
    End Structure

    Public Interface IAddresess
        Property Addresess As String
    End Interface

    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer), MyBook.ISquareMeters, MyBook.IHasDescription
        Inherits IAddresess
    End Interface

    Public Class Entity
        Implements IEntity

        Private data As New Data
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return data.Id
            End Get
            Set(value As Integer)
                data.Id = value
            End Set
        End Property

        Public Property Lenght As Double Implements MyBook.ISquareMeters.Lenght
            Get
                Return data.Length
            End Get
            Set(value As Double)
                data.Length = value
            End Set
        End Property

        Public Property Width As Double Implements MyBook.ISquareMeters.Width
            Get
                Return data.Width
            End Get
            Set(value As Double)
                data.Width = value
            End Set
        End Property

        Public Property Description As String Implements MyBook.IHasDescription.Description
            Get
                Return data.Description
            End Get
            Set(value As String)
                data.Description = value
            End Set
        End Property

        Public Property Addresess As String Implements IAddresess.Addresess
            Get
                Return data.Dieythinsi
            End Get
            Set(value As String)
                data.Dieythinsi = value
            End Set
        End Property

    End Class
End Namespace

