Imports MyBook

Namespace ECategory.Entity
    Structure Data
        Dim ID As Integer
        Dim NameCategory As String
        Dim Description As String
    End Structure
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Class Entity
        Implements IReference, MyBook.IHasCategory, MyBook.IHasDescription

        Private Data As Data
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
            End Set
        End Property

        Public Property Category As String Implements IHasCategory.Category
            Get
                Return Data.NameCategory
            End Get
            Set(value As String)
                Data.NameCategory = value
            End Set
        End Property

        Public Property Description As String Implements IHasDescription.Description
            Get
                Return Data.Description
            End Get
            Set(value As String)
                Data.Description = value
            End Set
        End Property
    End Class
End Namespace

