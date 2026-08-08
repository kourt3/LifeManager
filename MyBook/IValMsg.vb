''' <summary>
''' Καταχώρητης Δεδομένων εκτέλεσης. 
''' </summary>
''' <typeparam name="IModel">καταχώρηση Δεδομένων μετα την εκτέλεση</typeparam>
Public Class ValMsg(Of IModel)
    ''' <summary>
    ''' Η εκτέλεση αν ήταν με επυτηχία : TRUE OR FALSE
    ''' </summary>
    Public Success As Boolean
    ''' <summary>
    ''' Μήνημα εκτέλεσης.
    ''' </summary>
    Public Msg As String
    ''' <summary>
    ''' Τα Δεδομενα καταχώρησεις μετα την εκτέλεση.
    ''' </summary>
    Public Model As IModel
End Class

''' <summary>
''' Καταχωρήτης Εκτέλεσης
''' </summary>
Public Class ValMsg
    ''' <summary>
    ''' Η εκτέλεση αν ήταν με επυτηχία : TRUE OR FALSE
    ''' </summary>
    Public Success As Boolean
    ''' <summary>
    ''' Μήνημα εκτέλεσης.
    ''' </summary>
    Public Msg As String
End Class