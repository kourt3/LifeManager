
Namespace My.Entity
    Structure ContactData
        Public Id As Integer
        Public ExternalID As Integer
        Public NameCategory As String
        Public Value As String
        Public Description As String
    End Structure


    Public Interface INameCategory
        Property NameCategory As String
    End Interface

    ''' <summary>
    ''' Email,FaceBook,Instagram,Twitter,TikToK
    ''' </summary>
    Public Interface IContactEntity
        Inherits MyBook.IHasPrimaryKey(Of Integer), MyBook.IHasDescription, MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, MyBook.IHasValue(Of String), INameCategory
    End Interface


    Public Class Entity
        Implements IContactEntity


        Private Data As ContactData
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
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

        Public Property Value As String Implements MyBook.IHasValue(Of String).Value
            Get
                Return Data.Value
            End Get
            Set(value As String)
                Data.Value = value
            End Set
        End Property

        Public Property NameCategory As String Implements INameCategory.NameCategory
            Get
                Return Data.NameCategory
            End Get
            Set(value As String)
                Data.NameCategory = value
            End Set
        End Property

        Public Property ExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
            Get
                Return Data.EXternalID
            End Get
            Set(value As Integer)
                Data.EXternalID = value
            End Set
        End Property
    End Class
End Namespace

