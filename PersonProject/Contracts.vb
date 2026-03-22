Imports MyBook
Imports PersonProject.My
Imports PersonProject.My.Ables

Namespace Contracts


    Public Interface IModel
        Inherits My.Enity.IReference
        Inherits Ables.IFirstName
        Inherits Ables.ISecondName
        Inherits Ables.IBirthDay
        Inherits Ables.IFullName
        Inherits Ables.IAge
    End Interface
    Public Interface IRegisterDTO
        Inherits My.Ables.IFirstName
        Inherits My.Ables.ISecondName
        Inherits My.Ables.IBirthDay
    End Interface
    Public Interface IChangeFirstNameDTO
        Inherits My.Ables.IFirstName
    End Interface
    Public Interface IChangeSecondNameDTO
        Inherits My.Ables.ISecondName
    End Interface
    Public Interface IChangeFirstNameAndSecondNameDTO
        Inherits My.Ables.IFirstName, My.Ables.ISecondName
    End Interface
    Public Interface IBirthDay
        Inherits My.Ables.IBirthDay
    End Interface

    Public Class Contracts
        Implements IRegisterDTO, IChangeFirstNameDTO, IChangeSecondNameDTO, IChangeFirstNameAndSecondNameDTO, IBirthDay, IModel



        Public Property FristName As String Implements IFirstName.FristName
        Public Property SecondName As String Implements ISecondName.SecondName
        Public Property Birthday As Date Implements My.Ables.IBirthDay.Birthday
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public ReadOnly Property FullName As String Implements IFullName.FullName
            Get
                Return FristName & " " & SecondName
            End Get
        End Property

        Public ReadOnly Property Age As Integer Implements IAge.Age
            Get
                Return Now.Year - Birthday.Year
            End Get
        End Property
    End Class
End Namespace

