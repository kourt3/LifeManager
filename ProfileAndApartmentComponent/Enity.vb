Namespace My.Entity
    Structure Data
        Dim Id As Integer
        Dim ExternalID As Integer
        Dim BuildID As Integer
        Dim AparamentID As Integer
    End Structure

    Public Interface IExternalID
        Property ExternalID As Integer
    End Interface

    Public Interface IBuildAndApartmentIDs
        Property BuildID As Integer
        Property ApartmentID As Integer
    End Interface

    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits IBuildAndApartmentIDs, IExternalID
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

        Public Property ExternalID As Integer Implements IExternalID.ExternalID
            Get
                Return Data.ExternalID
            End Get
            Set(value As Integer)
                Data.ExternalID = value
            End Set
        End Property

        Public Property BuildID As Integer Implements IBuildAndApartmentIDs.BuildID
            Get
                Return Data.BuildID
            End Get
            Set(value As Integer)
                Data.BuildID = value
            End Set
        End Property

        Public Property ApartmentID As Integer Implements IBuildAndApartmentIDs.ApartmentID
            Get
                Return Data.AparamentID
            End Get
            Set(value As Integer)
                Data.AparamentID = value
            End Set
        End Property


    End Class
End Namespace