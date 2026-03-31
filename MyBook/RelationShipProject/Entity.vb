Namespace RelationShip.Entity
    Structure Data
        Dim Id As Integer
        Dim ExternalID As Integer
        Dim ToExternalID As Integer
    End Structure

    Public Interface IEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
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

        Public Property ExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
            Get
                Return Data.ExternalID
            End Get
            Set(value As Integer)
                Data.ExternalID = value
            End Set
        End Property

        Public Property ToExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID
            Get
                Return Data.ToExternalID
            End Get
            Set(value As Integer)
                Data.ToExternalID = value
            End Set
        End Property
    End Class
End Namespace

