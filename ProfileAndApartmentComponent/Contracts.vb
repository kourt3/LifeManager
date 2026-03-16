Imports CohrabitionComponent.My.Entity

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface IModel
        Inherits IReference
        Inherits My.Entity.IExternalID
        Property BuildModel As Buildings.Contracts.IModel
        Property ApartmentModel As Apartment.Contracts.IModel
    End Interface
    Public Interface IRegisterDTO
        Inherits My.Entity.IBuildAndApartmentIDs, IExternalID
    End Interface
    Public Interface ICreteria
        Inherits My.Entity.IExternalID
        Inherits My.Entity.IBuildAndApartmentIDs
    End Interface


    Public Class Contracts
        Implements IReference, IModel, IRegisterDTO, ICreteria

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property ExternalID As Integer Implements IExternalID.ExternalID
        Public Property BuildID As Integer Implements IBuildAndApartmentIDs.BuildID
        Public Property ApartmentID As Integer Implements IBuildAndApartmentIDs.ApartmentID
        Public Property BuildModel As Buildings.Contracts.IModel Implements IModel.BuildModel
        Public Property ApartmentModel As Apartment.Contracts.IModel Implements IModel.ApartmentModel
        Sub New()
            BuildModel = New Buildings.Contracts.Contracts
            ApartmentModel = New Apartment.Contracts.Contracts
        End Sub

    End Class
End Namespace

