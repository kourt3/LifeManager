Imports AdressesProject.My.Ables

Namespace FullAdress.Contracts
    Public Interface IModel
        Inherits My.Ables.IReference
        Inherits My.Ables.ICountry, My.Ables.IPerifereia, My.Ables.INomos, My.Ables.ITK, My.Ables.IDhmos, My.Ables.IAddresses, My.Ables.INumber
    End Interface

    Public Interface IRegisterDTO
        Inherits My.Ables.ICountry, My.Ables.IPerifereia, My.Ables.INomos, My.Ables.ITK, My.Ables.IDhmos, My.Ables.IAddresses, My.Ables.INumber
    End Interface

    Public Interface ICreteriaFullAdress
        Inherits My.Ables.ICountry, My.Ables.IPerifereia, My.Ables.INomos, My.Ables.ITK, My.Ables.IDhmos, My.Ables.IAddresses, My.Ables.INumber
    End Interface




    Public Class Contracts
        Implements IModel

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Country As Integer Implements ICountry.Country
        Public Property Perifereia As Integer Implements IPerifereia.Perifereia
        Public Property Nomos As Integer Implements INomos.Nomos
        Public Property TK As Integer Implements ITK.TK
        Public Property Dhmos As Integer Implements IDhmos.Dhmos
        Public Property Addresses As Integer Implements IAddresses.Addresses
        Public Property Number As Integer Implements INumber.Number
    End Class
End Namespace
