Imports MyBook
Namespace PersonProject.Contracts


    Public Interface IModel
        Inherits PersonProject.Enity.IReference
        Inherits Ables.IFirstName
        Inherits Ables.ISecondName
        Inherits Ables.IBirthDay
        Inherits Ables.IFullName
        Inherits Ables.IAge
    End Interface
    Public Interface IRegisterDTO
        Inherits PersonProject.Ables.IFirstName
        Inherits PersonProject.Ables.ISecondName
        Inherits PersonProject.Ables.IBirthDay
    End Interface
    Public Interface IChangeFirstNameDTO
        Inherits PersonProject.Ables.IFirstName
    End Interface
    Public Interface IChangeSecondNameDTO
        Inherits PersonProject.Ables.ISecondName
    End Interface
    Public Interface IChangeFirstNameAndSecondNameDTO
        Inherits PersonProject.Ables.IFirstName, PersonProject.Ables.ISecondName
    End Interface
    Public Interface IBirthDay
        Inherits PersonProject.Ables.IBirthDay
    End Interface

    Public Class Contracts
        Implements IRegisterDTO, IChangeFirstNameDTO, IChangeSecondNameDTO, IChangeFirstNameAndSecondNameDTO, IBirthDay, IModel, Enity.IReference



        Public Property FristName As String Implements PersonProject.Ables.IFirstName.FristName
        Public Property SecondName As String Implements PersonProject.Ables.ISecondName.SecondName
        Public Property Birthday As Date Implements PersonProject.Ables.IBirthDay.Birthday
        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public ReadOnly Property FullName As String Implements PersonProject.Ables.IFullName.FullName
            Get
                Return FristName & " " & SecondName
            End Get
        End Property

        Public ReadOnly Property Age As Integer Implements PersonProject.Ables.IAge.Age
            Get
                Return Now.Year - Birthday.Year
            End Get
        End Property
    End Class
End Namespace

