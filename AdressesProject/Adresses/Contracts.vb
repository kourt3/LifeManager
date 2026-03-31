Imports AdressesProject.My.Ables

Namespace Adresses.Contracts
    Public Interface IModel
        Inherits MyBook.IHasPrimaryKey(Of Integer)
        Inherits My.Ables.IValue
    End Interface

    Public Interface IUpdateAndRegisterDTO
        Inherits My.Ables.IValue
    End Interface


    Public Class Contracts
        Implements IModel, IUpdateAndRegisterDTO

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Value As String Implements IValue.Value

    End Class
End Namespace

