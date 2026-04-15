Imports MyBook
Imports ProfileComponent.Profile.Able

Namespace Profile.Contracts
    Public Interface IModel
        Inherits Able.IReference, Able.IPersonID, Able.IFamilyID
    End Interface
    Public Interface IRegisterDTO
        Inherits Able.IPersonID, Able.IFamilyID
    End Interface
    Public Interface ICreteria
        Inherits Able.IPersonID, Able.IFamilyID
    End Interface
    Public Class Contracts
        Implements Able.IReference, IRegisterDTO, IModel, ICreteria

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property PersonID As Integer Implements IPersonID.PersonID
        Public Property FamilyID As Integer Implements IFamilyID.FamilyID

    End Class
End Namespace

