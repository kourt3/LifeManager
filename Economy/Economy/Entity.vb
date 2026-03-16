Namespace EconomyProject.Entity

    Public Structure Economy
        Public ID As Integer
        Public FromExternalID As Integer
        Public ToExternalID As Integer
        Public Category As String
    End Structure

    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IEntity
        Inherits IReference
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
        Inherits MyBook.IHasCategory
    End Interface

    Public Class Entity
        Implements IEntity

        Private Data As New Economy
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
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
        Public Property Category As String Implements MyBook.IHasCategory.Category
            Get
                Return Data.Category
            End Get
            Set(value As String)
                Data.Category = value
            End Set
        End Property

        Public Property ExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
            Get
                Return Data.FromExternalID
            End Get
            Set(value As Integer)
                Data.FromExternalID = value
            End Set
        End Property
    End Class
End Namespace


