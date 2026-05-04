Public Class PEI_C

End Class
Public Class Quest
    Public NumQuest As String
    Public Quest As String
    Public Answers As New List(Of Answer)
    Public Sub AddAnswer(Answer As String, Optional Corr As Boolean = False)
        Dim Ans As New Answer
        Ans.Numb = Answers.Count + 1
        Ans.Answer = Answer
        Ans.Corr = Corr
        Answers.Add(Ans)
    End Sub
End Class
Public Class Answer
    Public Numb As Integer
    Public Answer As String
    Public Corr As Boolean
End Class

Module TestPei
    Dim Erwthseis(8) As Quest
    Sub Main()
#Region "Enwthta Prwth"
        Erwthseis(0).NumQuest = "A1"
        Erwthseis(0).Quest = "Το Επάγγεκμα του οδικού μεταφορέα μεταφοράς εμπορευμάτων"
        Erwthseis(0).AddAnswer("Ασκεί όποιος διαθέτει κατάλληλη άδεια οδήγησης (Γ ή Γ + Ε)")
        Erwthseis(0).AddAnswer("Ασκεί όποιος διαθέτει στην κατοχή του φορτηγό με μέγιστο επιτρεπόμενο βάρος μαγαλύτερο των 3,5 τόνων.")
        Erwthseis(0).AddAnswer("Ασκουν μεταφορικές επιχειρήσεις έναντι κομίστρου", True)

        Erwthseis(1).NumQuest = "A2"
        Erwthseis(1).Quest = "Το Πιστοποιητικο επαγγελατικης ικανότητα (ΠΕΙ) Πρέπει να ανανεώνεται κάθε"
        Erwthseis(1).AddAnswer("5 Χρόνια", True)
        Erwthseis(1).AddAnswer("7 Χρόνια")
        Erwthseis(1).AddAnswer("5 Χρόνια για οδηγούς ηλικίας άνω των 65 Ετών")

        Erwthseis(2).NumQuest = "A3"
        Erwthseis(2).Quest = "Οι Κάτοχοι ΠΕΙ μεταφοράς εμπορευμάτων για άδεια οδήγησης Γ που επιθυμούν ΠΕΙ για άδεια οδήγησης κατηγορίας Γ + Ε"
        Erwthseis(2).AddAnswer("Οφείλουν να επαναλάβουν την επιμόρφωση για απόκτηση ΠΕΙ")
        Erwthseis(2).AddAnswer("Δεν χρειάζεται να κάνουν κάποια επιμόργωση για ΠΕΙ.", True)
        Erwthseis(2).AddAnswer("Χρειάζεται μόνο να παρακολουθήσουν την επιμόρφωση που αντιστοιχεί στην νέα δραστηριότητα")

        Erwthseis(3).NumQuest = "A4"
        Erwthseis(3).Quest = "Οι Κάτοχοι ΠΕΙ μεταφοράς εμπορευμάτων για άδεια οδήγησης Γ που Επιθυμνούν ΠΕΙ για άδεια οδήγησης κατηγορίας Δ"
        Erwthseis(3).AddAnswer("οφείλουν να παρακολουθήσουν την αρχική επιμόρφωση για απόκτηση ΠΕΙ μεταφοράς επιβατών")
        Erwthseis(3).AddAnswer("Δεν χρειάζεται να κανουν καποια επιμόρφωση για ΠΕΙ")
        Erwthseis(3).AddAnswer("Χρειάζεται μόνο να εξεταστούν στην επιπλέον ύλη που αντιστοιχεί στη νεα δραστηριότητα", True)

        Erwthseis(4).NumQuest = "A5"
        Erwthseis(4).Quest = "Υποχρεούνται απόκτησης ΠΕΙ οι οδηγοί οχημάτων"
        Erwthseis(4).AddAnswer("των οποίων η μέγιστη επιτρεπόμενη ταχύτητα δεν υπερβαίνει τα 45 km/h")
        Erwthseis(4).AddAnswer("που χρησιμοποιούνται για εμπορικές μεταφορές εμπορευμάτων", True)
        Erwthseis(4).AddAnswer("ποθ χρησιμοποιούνται για τα μαθήματα οδήγησης για τη λήψη ΠΕΙ", )

        Erwthseis(5).NumQuest = "A6"
        Erwthseis(5).Quest = "Το Τονοχιλιόμετρο είναι μια ευρέως χρησιμοποιούμενη μονάδα μέτρησης"
        Erwthseis(5).AddAnswer("των κερδών μια μεταφορικής επιχείρησης")
        Erwthseis(5).AddAnswer("του μεταφορικού κόστους του ανά τόνο μεταφερόμενου εμπορεύματος")
        Erwthseis(5).AddAnswer("του πραγματοποιούμενου μεταφορικού έργου", True)

        Erwthseis(6).NumQuest = "A7"
        Erwthseis(6).Quest = "Ένα φορτηγό μεταφέρει 6 τόνους εμπορευμάτων απο την αθήνα στην θεσσαλονίκη (Απόσταση περίπου 500 χιλιομέτρων) και επιστρέφει απο τη Θεσσαλονίκη στην Αθήνα με 5 τόνους εμπορευμάτων. Το κόμιστρο για την απλή διαδρομή ανέρχεται στα 300 ευρω/τόνο. Αυτο αντιστοιχει σε"
        Erwthseis(6).AddAnswer("1.100 Τονοχιλιόμετρα")
        Erwthseis(6).AddAnswer("3.300 Τονοχιλιόμετρα")
        Erwthseis(6).AddAnswer("5.500 Τονοχιλιόμετρα", True)

        Erwthseis(7).NumQuest = "A8"
        Erwthseis(7).Quest = "Μετά την παρέλευση πενταετίας απο την απόκτηση ΠΕΙ, ο οδηγός, προκειμένου να συνεχίσει να ασκεί το επάγγελμα,"
        Erwthseis(7).AddAnswer("υποχρεούνται να επεναλάβει την αρχική επιμόρφωση και να μετάσχει σε εξετάσεις")
        Erwthseis(7).AddAnswer("υποχρεούνται να παρακολουθήσει μαθήματα περιοδικής κατάρτισης", True)
        Erwthseis(7).AddAnswer("δεν έχει καμία υποχρέωση εφόσον έχει αποκτήσει, βάσει εξετάσεων, το ΠΕΙ αρχικής επιμόρφωσης")

        Erwthseis(8).NumQuest = "A9"
        Erwthseis(8).Quest = "Στην Ελλάδα, η διάρκεια της περιοδικής κατάρτισης ορίστηκε σε"
        Erwthseis(8).AddAnswer("25 ώρες")
        Erwthseis(8).AddAnswer("35 ώρες", True)
        Erwthseis(8).AddAnswer("70 ώρες")
#End Region

#Region "Orthologikh Odhghsh"

#End Region
    End Sub
End Module