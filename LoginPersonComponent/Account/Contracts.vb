
Imports MyBook
Imports ProfileComponent

Namespace Account.Contracts
    Public Interface ICreteria
        Inherits Ables.ILoginID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface

    Public Interface IModel
        Inherits Ables.IReference, Ables.ILoginID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface

    Public Interface IRegisterDTO
        Inherits Ables.ILoginID, MyBook.IHasExtrernalID(Of Integer).IHasToExternalID
    End Interface


    Public Class Contracts
        Implements IModel, ICreteria, IRegisterDTO, MyBook.IHasPrimaryKey(Of Integer)

        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property LoginID As Integer Implements Ables.ILoginID.LoginID
        Public Property ToExternalID As Integer Implements IHasExtrernalID(Of Integer).IHasToExternalID.ToExternalID


        Sub New()

        End Sub
    End Class
End Namespace

