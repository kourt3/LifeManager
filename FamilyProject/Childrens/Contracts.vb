Imports FamilyProject.Children.Entity
Imports MyBook
Imports PersonProject.My.Ables

Namespace Children.Conctracts

    Public Interface IReference
        Inherits MyBook.IHasPrimaryKey(Of Integer)
    End Interface

    Public Interface IModel
        Inherits IReference
        Inherits Children.Entity.IPersonID, Children.Entity.IFamilyId
        Property PersonModel As PersonProject.Contracts.IModel

    End Interface

    Public Interface IRegister
        Inherits Children.Entity.IPersonID, Children.Entity.IFamilyId
    End Interface

    Public Interface ICreteria
        Inherits Children.Entity.IPersonID, Children.Entity.IFamilyId
    End Interface

    Public Class Contracts
        Implements IModel, ICreteria, IRegister

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property PersonModel As PersonProject.Contracts.IModel Implements IModel.PersonModel
        Public Property PersonID As Integer Implements IPersonID.PersonID
        Public Property FamilyID As Integer Implements IFamilyId.FamilyID


        Sub New()
            PersonModel = New PersonProject.Contracts.Contracts
        End Sub
    End Class
End Namespace

