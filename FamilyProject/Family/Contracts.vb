Imports FamilyProject.Children.Entity
Imports FamilyProject.My.Ables

Namespace Contracts
    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface
    Public Interface ICreteria
        Inherits My.Ables.IMePerson
    End Interface

    Public Interface IModel
        Inherits IReference
        Property MotherModel As PersonProject.Contracts.IModel
        Property FatherModel As PersonProject.Contracts.IModel
        Property HusbandModel As PersonProject.Contracts.IModel
        Property MePersonModel As PersonProject.Contracts.IModel
        Property Childrens As List(Of Children.Conctracts.IModel)
    End Interface

    Public Interface IRegisterDTO
        Inherits My.Ables.IMother
        Inherits My.Ables.IFather
        Inherits My.Ables.IHusband
        Inherits My.Ables.IMePerson
    End Interface

    Public Interface IRegisterMotherDTO
        Inherits My.Ables.IMother
    End Interface
    Public Interface IRegisterFatherDTO
        Inherits My.Ables.IFather
    End Interface
    Public Interface IRegisterHusbandDTO
        Inherits My.Ables.IHusband
    End Interface
    Public Interface IRegisterChildrendDTO
        Inherits Children.Conctracts.IRegister
    End Interface

    Public Interface IRemoveMotherDTO
        Inherits My.Ables.IMother
    End Interface
    Public Interface IRemoveFatherDTO
        Inherits My.Ables.IFather
    End Interface
    Public Interface IRemoveHusbandDTO
        Inherits My.Ables.IHusband
    End Interface
    Public Interface IRemoveChildrenDTO
        Inherits Children.Conctracts.IRegister
    End Interface
    Public Class Contracts
        Implements IReference, IModel, IRegisterDTO, IRegisterMotherDTO, IRegisterFatherDTO, IRegisterHusbandDTO, IRegisterChildrendDTO, ICreteria, IRemoveMotherDTO, IRemoveFatherDTO, IRemoveHusbandDTO, IRemoveChildrenDTO

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Mother As Integer Implements IMother.Mother
        Public Property Father As Integer Implements IFather.Father
        Public Property Husband As Integer Implements IHusband.Husband
        Public Property MotherModel As PersonProject.Contracts.IModel Implements IModel.MotherModel
        Public Property FatherModel As PersonProject.Contracts.IModel Implements IModel.FatherModel
        Public Property HusbandModel As PersonProject.Contracts.IModel Implements IModel.HusbandModel
        Public Property Childrens As List(Of Children.Conctracts.IModel) Implements IModel.Childrens
        Public Property MePersonModel As PersonProject.Contracts.IModel Implements IModel.MePersonModel
        Public Property MePersonID As Integer Implements IMePerson.MePersonID
        Public Property PersonID As Integer Implements IPersonID.PersonID
        Public Property FamilyID As Integer Implements IFamilyId.FamilyID


        Sub New()
            MotherModel = New PersonProject.Contracts.Contracts
            FatherModel = New PersonProject.Contracts.Contracts
            HusbandModel = New PersonProject.Contracts.Contracts
            MePersonModel = New PersonProject.Contracts.Contracts
            Childrens = New List(Of Children.Conctracts.IModel)
        End Sub
    End Class

End Namespace
