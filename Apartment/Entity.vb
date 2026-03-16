Namespace My.Apartment
    Public Structure Data
        Dim Id As Integer
        Dim BuildID As Integer
        Dim Lenght As Double
        Dim Width As Double
        Dim Orofos As Integer
        Dim Diamerisma As String
        Dim Koudouni As String
        Dim Description As String
    End Structure

    Public Interface IBuildId
        Property BuildID As Integer
    End Interface

    Public Interface ILenght
        Property Lenght As Double
        Property Width As Double
    End Interface

    Public Interface IOrofos
        Property Orofos As Integer
    End Interface

    Public Interface IDiamerisma
        Property Diamenrisma As String
    End Interface
    Public Interface IKoudouni
        Property Koudouni As String
    End Interface
    Public Interface IDescription
        Property Description As String
    End Interface

    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits ILenght, IOrofos, IDiamerisma, IKoudouni, IDescription, IBuildId
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

        Public Property Lenght As Double Implements ILenght.Lenght
            Get
                Return Data.Lenght
            End Get
            Set(value As Double)
                Data.Lenght = value
            End Set
        End Property

        Public Property Width As Double Implements ILenght.Width
            Get
                Return Data.Width
            End Get
            Set(value As Double)
                Data.Width = value
            End Set
        End Property

        Public Property Orofos As Integer Implements IOrofos.Orofos
            Get
                Return Data.Orofos
            End Get
            Set(value As Integer)
                Data.Orofos = value
            End Set
        End Property

        Public Property Diamenrisma As String Implements IDiamerisma.Diamenrisma
            Get
                Return Data.Diamerisma
            End Get
            Set(value As String)
                Data.Diamerisma = value
            End Set
        End Property

        Public Property Koudouni As String Implements IKoudouni.Koudouni
            Get
                Return Data.Koudouni
            End Get
            Set(value As String)
                Data.Koudouni = value
            End Set
        End Property

        Public Property Description As String Implements IDescription.Description
            Get
                Return Data.Description
            End Get
            Set(value As String)
                Data.Description = value
            End Set
        End Property

        Public Property BuildID As Integer Implements IBuildId.BuildID
            Get
                Return Data.BuildID
            End Get
            Set(value As Integer)
                Data.BuildID = value
            End Set
        End Property

    End Class
End Namespace

