Imports MyBook

Namespace Vehicle.Plate.Contracts
    Public Interface IModel
        Inherits Base.IReference, MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, Entity.IVehicleID, Entity.IPlateNumber, Entity.ICountryId, MyBook.IHasIcon
    End Interface

    Public Interface ICreteria
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID, Entity.ICountryId, Entity.IVehicleID
    End Interface

    Public Interface IRegisterDTO
        Inherits Entity.IVehicleID, Entity.IPlateNumber, Entity.ICountryId, MyBook.IHasIcon, MyBook.IHasExtrernalID(Of Integer).IHasFromExternalID
    End Interface
    Public Interface IChangeDTO
        Inherits Entity.IPlateNumber, MyBook.IHasIcon, Entity.ICountryId, Entity.IVehicleID
    End Interface
    Public Interface IChangePlateDTO
        Inherits Entity.IPlateNumber
    End Interface
    Public Interface IChangeIconDTO
        Inherits MyBook.IHasIcon
    End Interface
    Public Interface IChangeCountryDTO
        Inherits Entity.ICountryId
    End Interface

    Public Class Contracts
        Implements IModel, Base.IReference, IRegisterDTO, IChangeDTO, IChangePlateDTO, IChangeIconDTO, IChangeCountryDTO, ICreteria

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property VehicleId As Integer Implements Entity.IVehicleID.VehicleId
        Public Property NumberPlate As String Implements Entity.IPlateNumber.NumberPlate
        Public Property CountryId As String Implements Entity.ICountryId.Country
        Public Property Icon As String Implements IHasIcon.Icon
        Public Property ExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasFromExternalID.ExternalID

    End Class
End Namespace
