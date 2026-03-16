Imports Buildings.My.Entity

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IModel
        Inherits IReference
        Inherits MyBook.ISquareMeters, MyBook.IHasDescription, My.Entity.IAddresess
    End Interface

    Public Interface IRegisterDTO
        Inherits MyBook.ISquareMeters, MyBook.IHasDescription, My.Entity.IAddresess
    End Interface
    Public Interface IChangeDescriptionDTO
        Inherits MyBook.IHasDescription
    End Interface
    Public Interface IChangeAddressesDTO
        Inherits My.Entity.IAddresess
    End Interface
    Public Interface IChangeSquardMeter
        Inherits MyBook.ISquareMeters
    End Interface

    Public Class Contracts
        Implements IModel, IReference, IRegisterDTO, IChangeDescriptionDTO, IChangeAddressesDTO, IChangeSquardMeter

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Lenght As Double Implements MyBook.ISquareMeters.Lenght
        Public Property Width As Double Implements MyBook.ISquareMeters.Width
        Public Property Description As String Implements MyBook.IHasDescription.Description
        Public Property Addresess As String Implements IAddresess.Addresess

    End Class
End Namespace

