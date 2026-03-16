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

        Private NewData As New My.Enity.Data
        Private _Choice As Boolean

        Public Property FristName As String Implements IFirstName.FristName
            Get
                Return NewData.FirstName
            End Get
            Set(value As String)
                NewData.FirstName = value
            End Set
        End Property

        Public Property SecondName As String Implements ISecondName.SecondName
            Get
                Return NewData.SecondName
            End Get
            Set(value As String)
                NewData.SecondName = value
            End Set
        End Property

        Public Property Birthday As Date Implements My.Ables.IBirthDay.Birthday
            Get
                Return NewData.Birthday
            End Get
            Set(value As Date)
                NewData.Birthday = value
            End Set
        End Property
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return NewData.Id
            End Get
            Set(value As Integer)
                NewData.Id = value
            End Set
        End Property

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

