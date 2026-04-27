Imports MyBook
Imports ProfileComponent.FamilyProject.Family.Ables

Namespace FamilyProject.Family.Contracts
    Public Interface IModel
        Inherits IReference
        Inherits Ables.IMotherID
        Inherits Ables.IFatherID
        Inherits Ables.IHusbandID
    End Interface

    Public Interface IRegisterDTO
        Inherits FamilyProject.Family.Ables.IMotherID
        Inherits FamilyProject.Family.Ables.IFatherID
        Inherits FamilyProject.Family.Ables.IHusbandID
    End Interface

    Public Interface IRegisterMotherDTO
        Inherits FamilyProject.Family.Ables.IMotherID
    End Interface
    Public Interface IRegisterFatherDTO
        Inherits FamilyProject.Family.Ables.IFatherID
    End Interface
    Public Interface IRegisterHusbandDTO
        Inherits FamilyProject.Family.Ables.IHusbandID
    End Interface
    Public Interface IRegisterChildrendDTO
        Inherits FamilyProject.Children.Conctracts.IRegister
    End Interface

    Public Interface IRemoveMotherDTO
        Inherits FamilyProject.Family.Ables.IMotherID
    End Interface
    Public Interface IRemoveFatherDTO
        Inherits FamilyProject.Family.Ables.IFatherID
    End Interface
    Public Interface IRemoveHusbandDTO
        Inherits FamilyProject.Family.Ables.IHusbandID
    End Interface
    Public Class Contracts
        Implements IReference, IModel, IRegisterDTO, IRegisterMotherDTO, IRegisterFatherDTO, IRegisterHusbandDTO, IRemoveMotherDTO, IRemoveFatherDTO, IRemoveHusbandDTO

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Mother As Integer Implements FamilyProject.Family.Ables.IMotherID.Mother
        Public Property Father As Integer Implements IFatherID.Father
        Public Property Spouse As Integer Implements IHusbandID.Spouse
    End Class

End Namespace
