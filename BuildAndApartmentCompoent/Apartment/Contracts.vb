Imports BuildAndApartmentCompoent.BuildAndApartment.Apartment.Entity

Namespace BuildAndApartment.Apartment.Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits IBuildId
        Inherits IKoudouni, IDiamerisma, IDescription
        Inherits IOrofos, ILenght

    End Interface

    Public Interface IRegisterDTO
        Inherits IBuildId
        Inherits IKoudouni, IDiamerisma, IDescription
        Inherits IOrofos, ILenght
    End Interface


    Public Interface IChangeKoudouni
        Inherits IKoudouni
    End Interface
    Public Interface IChangeDiamerisma
        Inherits IDiamerisma
    End Interface
    Public Interface IChangeDescription
        Inherits IDescription
    End Interface

    Public Interface IChangeOrofos
        Inherits IOrofos
    End Interface

    Public Interface IChangeLenght
        Inherits ILenght
    End Interface


    Public Class Contracts
        Implements IReference, IModel, IRegisterDTO, IChangeKoudouni, IChangeDiamerisma, IChangeDescription, IChangeOrofos, IChangeLenght

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property BuildID As Integer Implements IBuildId.BuildID
        Public Property Koudouni As String Implements IKoudouni.Koudouni
        Public Property Diamenrisma As String Implements IDiamerisma.Diamenrisma
        Public Property Description As String Implements IDescription.Description
        Public Property Orofos As Integer Implements IOrofos.Orofos
        Public Property Lenght As Double Implements ILenght.Lenght
        Public Property Width As Double Implements ILenght.Width

    End Class
End Namespace

