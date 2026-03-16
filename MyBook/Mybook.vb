Public Interface IBooleanAble
    Property Choice As Boolean
End Interface
Public Interface IHasPrimaryKey(Of T)
    Property PrimaryKey As T
End Interface

Public Interface IHasExtrernalID(Of T)
    Public Interface IHasFromExternalID
        Property ExternalID As T
    End Interface
    Public Interface IHasToExternalID
        Property ToExternalID As T
    End Interface
End Interface

Public Interface ISquareMeters
    Property Lenght As Double
    Property Width As Double
End Interface
Public Interface IHasDescription
    Property Description As String
End Interface
Public Interface IHasTitle
    Property Title As String
End Interface
Public Interface IHasName
    Property Name As String
End Interface
Public Interface IHasValue(Of T)
    Property Value As T
End Interface
Public Interface IHasCategory
    Property Category As String
End Interface