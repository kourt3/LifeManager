



Public Interface IBooleanAble
    Property Choice As Boolean
End Interface

''' <summary>
''' Το Πρωτευον Κλείδι για αναγώρηση Δεδομένων
''' </summary>
''' <typeparam name="T">ο Τυπος του πρωτέυον κλειδι</typeparam>
Public Interface IHasPrimaryKey(Of T)
    ''' <summary>
    ''' Προτέυον κλείδι.
    ''' </summary>
    ''' <returns>Την τιμή του πρωτέυον κλειδίου</returns>
    Property PrimaryKey As T
End Interface

''' <summary>
''' <para>Η Σχέση που θα καταχώρητε απο μια εξωτερική βάση δεδομένον</para>
''' <para><i>Βοηθαει στης σχέσης μεταξη βάσης δεδομένων</i></para>
''' </summary>
''' <typeparam name="T">ο τύπος του εξωτερικου κλειδιου. για την αναγνώρηση πεδίου</typeparam>
Public Interface IHasExtrernalID(Of T)
    ''' <summary>
    ''' <para>Το προτευών κλειδί που κοιταει απο μια βαση εξωτερικά.</para>
    ''' 
    ''' <i>Βοηθάει στης βάσης 1:1(Ένα προς Ένα)</i>
    ''' </summary>
    Public Interface IHasFromExternalID
        ''' <summary>
        ''' Το εξωτερικό κλείδι
        ''' </summary>
        ''' <returns>την τιμή του εξωτερικού κλειδιου</returns>
        Property ExternalID As T
    End Interface

    ''' <summary>
    ''' <para>Το προτευών κλειδί που κοιταει σε μια βαση εξωτερικά.</para>
    ''' 
    ''' <i>Βοηθάει στης βάσης 1:-(ενα προς πολλά)</i>
    ''' </summary>
    Public Interface IHasToExternalID
        ''' <summary>
        ''' Το εξωτερικό κλείδι
        ''' </summary>
        ''' <returns>την τιμή του εξωτερικού κλειδιου</returns>
        Property ToExternalID As T
    End Interface
End Interface


Public Interface ISquareMeters
    Property Lenght As Double
    Property Width As Double
End Interface

''' <summary>
''' Το πεδιο που θα έχει την υπογραφή Description
''' </summary>
Public Interface IHasDescription
    Property Description As String
End Interface
''' <summary>
''' Το πεδιο που θα έχει την υπογραφή Title
''' </summary>
Public Interface IHasTitle
    Property Title As String
End Interface
''' <summary>
''' Το πεδιο που θα έχει την υπογραφή Name
''' </summary>
Public Interface IHasName
    Property Name As String
End Interface
''' <summary>
''' Το πεδιο που θα έχει την υπογραφή Icon
''' </summary>
Public Interface IHasIcon
    Property Icon As String
End Interface
''' <summary>
''' Το πεδιο που θα έχει την υπογραφή Value
''' </summary>
''' <typeparam name="T">Τον τύπο της Value</typeparam>
Public Interface IHasValue(Of T)
    Property Value As T
End Interface
''' <summary>
''' Το πεδιο που θα έχει την υπογραφή Category
''' </summary>
Public Interface IHasCategory
    Property Category As String
End Interface

''' <summary>
''' το Πεδιο που θα εχει την υπογραφη Creation
''' </summary>
Public Interface IHasCreation
    Property Creation As Date
End Interface
