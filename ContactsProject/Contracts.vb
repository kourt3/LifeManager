Imports ContactsProject.My.Entity
Imports PersonProject.My.Ables

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IViewAllModel
        Property Email As List(Of IModel)
        Property FaceBook As List(Of IModel)
        Property Instagram As List(Of IModel)
        Property TikTok As List(Of IModel)
        Property Twitter As List(Of IModel)
        Property Telephone As List(Of IModel)
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits MyBook.IHasDescription
        Inherits My.Entity.INameCategory
        Inherits MyBook.IHasValue(Of String)
    End Interface

    Public Interface ICreteria
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID
        Inherits MyBook.IHasValue(Of String)
    End Interface

    Public Interface IRegisterContact
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID
        Inherits My.Entity.INameCategory
        Inherits MyBook.IHasValue(Of String)
        Inherits MyBook.IHasDescription
    End Interface

    Public Interface IChancheContact
        Inherits My.Entity.INameCategory
        Inherits MyBook.IHasValue(Of String)
        Inherits MyBook.IHasDescription
    End Interface


    Public Class ViewAllModel
        Implements IViewAllModel

        Public Property Email As List(Of IModel) Implements IViewAllModel.Email
        Public Property FaceBook As List(Of IModel) Implements IViewAllModel.FaceBook
        Public Property Instagram As List(Of IModel) Implements IViewAllModel.Instagram
        Public Property TikTok As List(Of IModel) Implements IViewAllModel.TikTok
        Public Property Twitter As List(Of IModel) Implements IViewAllModel.Twitter
        Public Property Telephone As List(Of IModel) Implements IViewAllModel.Telephone
        Sub New()
            Email = New List(Of IModel)
            FaceBook = New List(Of IModel)
            Instagram = New List(Of IModel)
            TikTok = New List(Of IModel)
            Twitter = New List(Of IModel)
            Telephone = New List(Of IModel)
        End Sub
    End Class
    Public Class Contracts
        Implements IModel, IReference, IRegisterContact, IChancheContact, ICreteria

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Description As String Implements MyBook.IHasDescription.Description
        Public Property NameCategory As String Implements INameCategory.NameCategory
        Public Property Value As String Implements MyBook.IHasValue(Of String).Value
        Public Property ExternalID As Integer Implements MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID


    End Class
End Namespace

