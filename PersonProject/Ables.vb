Namespace My.Ables

    Public Interface IFirstName
        Property FristName As String
    End Interface
    Public Interface ISecondName
        Property SecondName As String
    End Interface
    Public Interface IBirthDay
        Property Birthday As Date
    End Interface
    Public Interface IFullName
        ReadOnly Property FullName As String
    End Interface
    Public Interface IAge
        ReadOnly Property Age As Integer
    End Interface
End Namespace
