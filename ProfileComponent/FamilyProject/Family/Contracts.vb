Imports ProfileComponent.FamilyProject.Children.Entity
Imports ProfileComponent.FamilyProject.Family.Ables

Namespace FamilyProject.Family.Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface ICreteria
        Inherits FamilyProject.Family.Ables.IMePerson
    End Interface

    Public Interface IModel
        Inherits IReference
        Property MotherModel As PersonProject.Contracts.IModel
        Property FatherModel As PersonProject.Contracts.IModel
        Property HusbandModel As PersonProject.Contracts.IModel
        Property MePersonModel As PersonProject.Contracts.IModel
        Property Childrens As List(Of FamilyProject.Children.Conctracts.IModel)
    End Interface

    Public Interface IRegisterDTO
        Inherits FamilyProject.Family.Ables.IMother
        Inherits FamilyProject.Family.Ables.IFather
        Inherits FamilyProject.Family.Ables.IHusband
        Inherits FamilyProject.Family.Ables.IMePerson
    End Interface

    Public Interface IRegisterMotherDTO
        Inherits FamilyProject.Family.Ables.IMother
    End Interface
    Public Interface IRegisterFatherDTO
        Inherits FamilyProject.Family.Ables.IFather
    End Interface
    Public Interface IRegisterHusbandDTO
        Inherits FamilyProject.Family.Ables.IHusband
    End Interface
    Public Interface IRegisterChildrendDTO
        Inherits FamilyProject.Children.Conctracts.IRegister
    End Interface

    Public Interface IRemoveMotherDTO
        Inherits FamilyProject.Family.Ables.IMother
    End Interface
    Public Interface IRemoveFatherDTO
        Inherits FamilyProject.Family.Ables.IFather
    End Interface
    Public Interface IRemoveHusbandDTO
        Inherits FamilyProject.Family.Ables.IHusband
    End Interface
    Public Interface IRemoveChildrenDTO
        Inherits FamilyProject.Children.Conctracts.IRegister
    End Interface
    Public Class Contracts
        Implements IReference, IModel, IRegisterDTO, IRegisterMotherDTO, IRegisterFatherDTO, IRegisterHusbandDTO, IRegisterChildrendDTO, ICreteria, IRemoveMotherDTO, IRemoveFatherDTO, IRemoveHusbandDTO, IRemoveChildrenDTO

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Mother As Integer Implements FamilyProject.Family.Ables.IMother.Mother
        Public Property Father As Integer Implements IFather.Father
        Public Property Husband As Integer Implements IHusband.Husband
        Public Property MotherModel As PersonProject.Contracts.IModel Implements IModel.MotherModel
        Public Property FatherModel As PersonProject.Contracts.IModel Implements IModel.FatherModel
        Public Property HusbandModel As PersonProject.Contracts.IModel Implements IModel.HusbandModel
        Public Property Childrens As List(Of FamilyProject.Children.Conctracts.IModel) Implements IModel.Childrens
        Public Property MePersonModel As PersonProject.Contracts.IModel Implements IModel.MePersonModel
        Public Property MePersonID As Integer Implements IMePerson.MePersonID
        Public Property PersonID As Integer Implements IPersonID.PersonID
        Public Property FamilyID As Integer Implements IFamilyId.FamilyID


        Sub New()
            MotherModel = New PersonProject.Contracts.Contracts
            FatherModel = New PersonProject.Contracts.Contracts
            HusbandModel = New PersonProject.Contracts.Contracts
            MePersonModel = New PersonProject.Contracts.Contracts
            Childrens = New List(Of FamilyProject.Children.Conctracts.IModel)
        End Sub
    End Class

End Namespace
