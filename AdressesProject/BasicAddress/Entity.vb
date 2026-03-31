Imports AdressesProject.My.Ables

Namespace My.Ables
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IValue
        Property Value As String
    End Interface
    Public Interface ICountry
        Property Country As Integer
    End Interface
    Public Interface IPerifereia
        Property Perifereia As Integer
    End Interface
    Public Interface INomos
        Property Nomos As Integer
    End Interface
    Public Interface ITK
        Property TK As Integer
    End Interface
    Public Interface IDhmos
        Property Dhmos As Integer
    End Interface
    Public Interface IAddresses
        Property Addresses As Integer
    End Interface
    Public Interface INumber
        Property Number As Integer
    End Interface
End Namespace
Namespace My.Entity
    Public Structure ValueData
        Dim ID As Integer
        Dim Value As String
    End Structure
    Public Structure AddressesData
        Dim ID As Integer
        Dim Country As Integer
        Dim Perifereia As Integer
        Dim Nomos As Integer
        Dim TK As Integer
        Dim Dhmos As String
        Dim Adresses As Integer
        Dim Number As Integer
    End Structure
    Interface IValueEntity
        Inherits My.Ables.IReference
        Inherits My.Ables.IValue
    End Interface
    Interface IAddressesEntity
        Inherits IReference, My.Ables.ICountry, My.Ables.IPerifereia, My.Ables.INomos, My.Ables.ITK, My.Ables.IDhmos, My.Ables.IAddresses, My.Ables.INumber
    End Interface


    Public Class Entity
        Implements My.Ables.IReference, My.Ables.IValue, IValueEntity
        Implements My.Ables.ICountry, My.Ables.IPerifereia, My.Ables.INomos, My.Ables.ITK, My.Ables.IDhmos, My.Ables.IAddresses, My.Ables.INumber, IAddressesEntity

        Private ValueData As ValueData
        Private AdData As AddressesData
        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return ValueData.ID
            End Get
            Set(value As Integer)
                ValueData.ID = value
            End Set
        End Property

        Public Property Value As String Implements IValue.Value
            Get
                Return ValueData.Value
            End Get
            Set(value As String)
                ValueData.Value = value
            End Set
        End Property

        Public Property Country As Integer Implements ICountry.Country
            Get
                Return AdData.Country
            End Get
            Set(value As Integer)
                AdData.Country = value
            End Set
        End Property

        Public Property Perifereia As Integer Implements IPerifereia.Perifereia
            Get
                Return AdData.Perifereia
            End Get
            Set(value As Integer)
                AdData.Perifereia = value
            End Set
        End Property

        Public Property Nomos As Integer Implements INomos.Nomos
            Get
                Return AdData.Nomos
            End Get
            Set(value As Integer)
                AdData.Nomos = value
            End Set
        End Property

        Public Property TK As Integer Implements ITK.TK
            Get
                Return AdData.TK
            End Get
            Set(value As Integer)
                AdData.TK = value
            End Set
        End Property

        Public Property Dhmos As Integer Implements IDhmos.Dhmos
            Get
                Return AdData.Dhmos
            End Get
            Set(value As Integer)
                AdData.Dhmos = value
            End Set
        End Property

        Public Property Addresses As Integer Implements IAddresses.Addresses
            Get
                Return AdData.Adresses
            End Get
            Set(value As Integer)
                AdData.Adresses = value
            End Set
        End Property

        Public Property Number As Integer Implements INumber.Number
            Get
                Return AdData.Number
            End Get
            Set(value As Integer)
                AdData.Number = value
            End Set
        End Property
    End Class
End Namespace
