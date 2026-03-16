Imports Apartment.My.Apartment

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits My.Apartment.IBuildId
        Inherits My.Apartment.IKoudouni, My.Apartment.IDiamerisma, My.Apartment.IDescription
        Inherits My.Apartment.IOrofos, My.Apartment.ILenght

    End Interface

    Public Interface IRegisterDTO
        Inherits My.Apartment.IBuildId
        Inherits My.Apartment.IKoudouni, My.Apartment.IDiamerisma, My.Apartment.IDescription
        Inherits My.Apartment.IOrofos, My.Apartment.ILenght
    End Interface


    Public Interface IChangeKoudouni
        Inherits My.Apartment.IKoudouni
    End Interface
    Public Interface IChangeDiamerisma
        Inherits My.Apartment.IDiamerisma
    End Interface
    Public Interface IChangeDescription
        Inherits My.Apartment.IDescription
    End Interface

    Public Interface IChangeOrofos
        Inherits My.Apartment.IOrofos
    End Interface

    Public Interface IChangeLenght
        Inherits My.Apartment.ILenght
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

