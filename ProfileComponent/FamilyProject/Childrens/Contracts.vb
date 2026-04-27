Imports MyBook

Namespace FamilyProject.Children.Conctracts

    Public Interface IModel
        Inherits Ables.IReference
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasToExternalID, Children.Ables.IFamilyId

    End Interface

    Public Interface IRegister
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasToExternalID, Children.Ables.IFamilyId
    End Interface

    Public Interface ICreteria
        Inherits MyBook.IHasExtrernalID(Of Integer).IHasToExternalID, Children.Ables.IFamilyId
    End Interface

    Public Class Contracts
        Implements IModel, ICreteria, IRegister, Ables.IReference

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property FamilyID As Integer Implements FamilyProject.Children.Ables.IFamilyId.FamilyID
        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID

    End Class
End Namespace

