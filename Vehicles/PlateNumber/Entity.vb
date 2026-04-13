Imports MyBook
Imports Vehicles.Vehicle.Vehicles.Contracts

Namespace Vehicle.Plate.Entity
    Public Interface IPlateNumber
        Property NumberPlate As String
    End Interface
    Public Interface IVehicleID
        Property VehicleId As Integer
    End Interface
    Public Interface ICountryId
        Property Country As String
    End Interface
    Structure Data
        Dim ID As Integer
        Dim ExternalId As Integer
        Dim VehicleID As Integer
        Dim Country As String
        Dim NumberPlate As String
        Dim Icon As String
    End Structure
    Public Interface IEntity
        Inherits Base.IReference, MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, ICountryId, IPlateNumber, IVehicleID, MyBook.IHasIcon
    End Interface
    Public Class Entity
        Implements IEntity, Base.IReference

        Private Data As Data
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.ID
            End Get
            Set(value As Integer)
                Data.ID = value
            End Set
        End Property

        Public Property Country As String Implements ICountryId.Country
            Get
                Return Data.Country
            End Get
            Set(value As String)
                Data.Country = value
            End Set
        End Property

        Public Property NumberPlate As String Implements IPlateNumber.NumberPlate
            Get
                Return Data.NumberPlate
            End Get
            Set(value As String)
                Data.NumberPlate = value
            End Set
        End Property

        Public Property VehicleId As Integer Implements IVehicleID.VehicleId
            Get
                Return Data.VehicleID
            End Get
            Set(value As Integer)
                Data.VehicleID = value
            End Set
        End Property

        Public Property Icon As String Implements IHasIcon.Icon
            Get
                Return Data.Icon
            End Get
            Set(value As String)
                Data.Icon = value
            End Set
        End Property

        Public Property ExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID
            Get
                Return Data.ExternalId
            End Get
            Set(value As Integer)
                Data.ExternalId = value
            End Set
        End Property
    End Class
End Namespace

