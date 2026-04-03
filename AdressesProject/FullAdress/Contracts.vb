Imports AdressesProject.My.Ables

Namespace FullAdress.Contracts
    Public Interface IModel
        Inherits My.Ables.IReference
        Property Country As Adresses.Contracts.IModel
        Property Perifereia As Adresses.Contracts.IModel
        Property Nomos As Adresses.Contracts.IModel
        Property TK As Adresses.Contracts.IModel
        Property Dhmos As Adresses.Contracts.IModel
        Property Addresses As Adresses.Contracts.IModel
        Property Number As Adresses.Contracts.IModel
    End Interface

    Public Interface IRegisterDTO
        Inherits My.Ables.ICountry, My.Ables.IPerifereia, My.Ables.INomos, My.Ables.ITK, My.Ables.IDhmos, My.Ables.IAddresses, My.Ables.INumber
    End Interface

    Public Interface ICreteriaFullAdress
        Inherits My.Ables.ICountry, My.Ables.IPerifereia, My.Ables.INomos, My.Ables.ITK, My.Ables.IDhmos, My.Ables.IAddresses, My.Ables.INumber
    End Interface


    Public Class Model
        Implements IModel, My.Ables.IReference

        Public Property Country As Adresses.Contracts.IModel Implements IModel.Country
        Public Property Perifereia As Adresses.Contracts.IModel Implements IModel.Perifereia
        Public Property Nomos As Adresses.Contracts.IModel Implements IModel.Nomos
        Public Property TK As Adresses.Contracts.IModel Implements IModel.TK
        Public Property Dhmos As Adresses.Contracts.IModel Implements IModel.Dhmos
        Public Property Addresses As Adresses.Contracts.IModel Implements IModel.Addresses
        Public Property Number As Adresses.Contracts.IModel Implements IModel.Number
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
    End Class

    Public Class Contracts
        Implements My.Ables.IReference, IRegisterDTO, ICreteriaFullAdress


        Public Property Country As Integer Implements ICountry.Country
        Public Property Perifereia As Integer Implements IPerifereia.Perifereia
        Public Property Nomos As Integer Implements INomos.Nomos
        Public Property TK As Integer Implements ITK.TK
        Public Property Dhmos As Integer Implements IDhmos.Dhmos
        Public Property Addresses As Integer Implements IAddresses.Addresses
        Public Property Number As Integer Implements INumber.Number
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey

    End Class
End Namespace
