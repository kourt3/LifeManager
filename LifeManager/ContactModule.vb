Imports ContactsProject
Module ContactModule

    ' Θα περναμε για external το Myref
    Friend Sub Info(Model As Contracts.IModel)
        Console.WriteLine(Model.NameCategory & ": " & Model.Value & " | Description: " & Model.Description)
    End Sub
    Friend Sub InfoAll(Model As Contracts.IViewAllModel)

        If Model.Email.Count > 0 Then
            Console.Write("Email: (" & Model.Email.Count & ")")
            For Each Emails In Model.Email
                Console.Write(" | " & Emails.Value)
            Next
            Console.WriteLine()
        Else
            Console.WriteLine("Email: Δεν έχει καταχωρηθει!")
        End If
        If Model.FaceBook.Count > 0 Then
            Console.Write("Facebook: (" & Model.FaceBook.Count & ")")
            For Each Facebook In Model.FaceBook
                Console.Write(" | " & Facebook.Value)
            Next
            Console.WriteLine()
        Else
            Console.WriteLine("Facebook: Δεν έχει καταχωρηθει!")
        End If

        If Model.Instagram.Count > 0 Then
            Console.Write("Instagram: (" & Model.Instagram.Count & ")")
            For Each Instagram In Model.Instagram
                Console.Write(" | " & Instagram.Value)
            Next
            Console.WriteLine()
        Else
            Console.WriteLine("Instagram: Δεν έχει καταχωρηθει!")
        End If

        If Model.TikTok.Count > 0 Then
            Console.Write("TikTok: (" & Model.TikTok.Count & ")")
            For Each Tiktok In Model.TikTok
                Console.Write(" | " & Tiktok.Value)
            Next
            Console.WriteLine()
        Else
            Console.WriteLine("TikTok: Δεν έχει καταχωρηθει!")
        End If
        If Model.Twitter.Count > 0 Then
            Console.Write("Twitter: (" & Model.Twitter.Count & ")")
            For Each Twitter In Model.Twitter
                Console.Write(" | " & Twitter.Value)
            Next
            Console.WriteLine()
        Else
            Console.WriteLine("Twitter: Δεν έχει καταχωρηθει!")
        End If
        If Model.Telephone.Count > 0 Then
            Console.Write("Telephone: (" & Model.Telephone.Count & ")")
            For Each Telephone In Model.Telephone
                Console.Write(" | " & Telephone.Value)
            Next
            Console.WriteLine()
        Else
            Console.WriteLine("Telephone: Δεν έχει καταχωρηθει!")
        End If


    End Sub
    Friend Sub Menu(Myref As AccountComponent.Contracts.IReference)
        Dim Ref As Contracts.IReference = New Contracts.Contracts
        Do

            Ref.PrimaryKey = Myref.PrimaryKey
            Dim Val As MyBook.ValMsg(Of Contracts.IViewAllModel) = Contact.AllModelView(Ref)
            Console.Clear()
            Console.WriteLine("--------- Contacts -----------")
            InfoAll(Val.Model)
            Console.WriteLine()
            Console.WriteLine("------------- Menu -----------")
            Console.WriteLine()
            If Val.Model.Email.Count > 0 Then Console.WriteLine("1) Emails.") Else Console.WriteLine("1) Register Emails.")
            If Val.Model.FaceBook.Count > 0 Then Console.WriteLine("2) Facebook.") Else Console.WriteLine("2) Register Facebook.")
            If Val.Model.Instagram.Count > 0 Then Console.WriteLine("3) Instagram.") Else Console.WriteLine("3) Register Instagram.")
            If Val.Model.TikTok.Count > 0 Then Console.WriteLine("4) TikTok.") Else Console.WriteLine("4) Register TikTok.")
            If Val.Model.TikTok.Count > 0 Then Console.WriteLine("5) Twitter.") Else Console.WriteLine("4) Register Twitter.")
            If Val.Model.Telephone.Count > 0 Then Console.WriteLine("6) Telephone.") Else Console.WriteLine("6) Register Telephone.")
            Console.WriteLine("7) Others.")
            Console.WriteLine("8) Exit.")
            Console.WriteLine("----------------------------")
            Console.WriteLine("Επέλεξε ενα απο το Menu:")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1 : If Val.Model.Email.Count > 0 Then ListofContact(Myref, Service.Service.ChoiceType.Email) Else Register(Myref, Service.Service.ChoiceType.Email)
                Case 2 : If Val.Model.FaceBook.Count > 0 Then ListofContact(Myref, Service.Service.ChoiceType.Facebook) Else Register(Myref, Service.Service.ChoiceType.Facebook)
                Case 3 : If Val.Model.Instagram.Count > 0 Then ListofContact(Myref, Service.Service.ChoiceType.Instagram) Else Register(Myref, Service.Service.ChoiceType.Instagram)
                Case 4 : If Val.Model.TikTok.Count > 0 Then ListofContact(Myref, Service.Service.ChoiceType.TikTok) Else Register(Myref, Service.Service.ChoiceType.TikTok)
                Case 5 : If Val.Model.Twitter.Count > 0 Then ListofContact(Myref, Service.Service.ChoiceType.Twitter) Else Register(Myref, Service.Service.ChoiceType.Twitter)
                Case 6 : If Val.Model.Telephone.Count > 0 Then ListofContact(Myref, Service.Service.ChoiceType.Telephone) Else Register(Myref, Service.Service.ChoiceType.Telephone)
                Case 7 : ListofContact(Myref, Service.Service.ChoiceType.None)
                Case 8 : Exit Sub
                Case Else : Continue Do
            End Select
        Loop
    End Sub
    Friend Sub ListofContact(Myref As AccountComponent.Contracts.IReference, ChoiceType As Service.Service.ChoiceType)
        Do
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Creteria As Contracts.ICreteria = New Contracts.Contracts
            Creteria.ExternalID = Myref.PrimaryKey
            Val = Contact.Search(Creteria, ChoiceType)
            If Val.Success = False Then
                Console.Clear()
                Console.WriteLine(Val.Msg)
                Exit Sub
            End If
            Console.Clear()
            Console.WriteLine("------- List Of Contacts -------")
            Dim Index As Integer = 0
            For Each Model In Val.Model
                Index += 1
                Console.WriteLine(Index & ") " & Model.Value & " | " & Model.Description)
            Next
            Console.WriteLine("--------- Menu --------")
            Console.WriteLine(1 & " - " & Index & ") Open Contact.")
            Console.WriteLine(Index + 1 & ") Add.")
            Console.WriteLine(Index + 2 & ") Exit.")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1 To Index
                    Open(Val.Model(Choice - 1), ChoiceType)
                Case Index + 1
                    Register(Myref, ChoiceType)
                Case Index + 2
                    Exit Sub
            End Select
        Loop
    End Sub
    Friend Sub Open(ContactRef As Contracts.IReference, ChoiceType As Service.Service.ChoiceType)
        Do
            Dim Val As MyBook.ValMsg(Of Contracts.IModel) = Contact.Exist(ContactRef, ChoiceType)
            If Val.Success = False Then
                Console.Clear()
                Console.WriteLine(Val.Msg)
                Console.ReadLine()
                Exit Sub
            End If
            Console.Clear()
            Console.WriteLine("--------- Contact --------")
            Info(Val.Model)
            Console.WriteLine("--------- Menu ----------")
            Console.WriteLine("1) Update Description.")
            Console.WriteLine("2) Update Value.")
            Console.WriteLine("3) Remove Contact.")
            Console.WriteLine("4) Exit.")
            Console.WriteLine("--------------------")
            Console.WriteLine("Παρακαλώ επέλεξε ενα απο το Μενου: ")
            Dim Choice As String = Console.ReadLine
            Select Case Choice
                Case 1 : UpdateDescription(ContactRef, ChoiceType)
                Case 2 : UpdateValue(ContactRef, ChoiceType)
                Case 3 : Remove(ContactRef, ChoiceType)
                Case 4 : Exit Sub
                Case Else : Continue Do
            End Select
        Loop
    End Sub
    Friend Sub Register(Myref As AccountComponent.Contracts.IReference, ChoiceType As Service.Service.ChoiceType)
        Dim Val As New MyBook.ValMsg
        Dim DTO As Contracts.IRegisterContact = New Contracts.Contracts
        DTO.ExternalID = Myref.PrimaryKey
        Console.Clear()
        Console.WriteLine("--------- Add Contact -------")
        Console.WriteLine("Παρακαλώ δώσε Value:")
        DTO.Value = Console.ReadLine
        Console.WriteLine("Παρακαλώ δώσε Description:")
        DTO.Description = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις;") Then
            Console.Clear()
            Console.WriteLine(Contact.Register(DTO, ChoiceType).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub UpdateValue(ContactRef As Contracts.IReference, ChoiceType As Service.Service.ChoiceType)
        Dim Val As MyBook.ValMsg(Of Contracts.IModel) = Contact.Exist(ContactRef, ChoiceType)
        Console.Clear()
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Console.WriteLine("------------- Update Value ----------")
        Info(Val.Model)
        Console.WriteLine("--------------------------------")
        Dim DTO As ContactsProject.Contracts.IChancheContact = New Contracts.Contracts
        DTO.Description = Val.Model.Description
        Console.WriteLine("Παρακαλώ Δώσε καινουργιο Value")
        DTO.Value = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις?") Then
            Console.Clear()
            Console.WriteLine(Contact.Update(ContactRef, DTO, ChoiceType).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub UpdateDescription(ContactRef As Contracts.IReference, ChoiceType As Service.Service.ChoiceType)
        Dim Val As MyBook.ValMsg(Of Contracts.IModel) = Contact.Exist(ContactRef, ChoiceType)
        Console.Clear()
        If Val.Success = False Then
            Console.WriteLine(Val.Msg)
            Console.ReadLine()
            Exit Sub
        End If
        Console.WriteLine("------------- Update Description ----------")
        Info(Val.Model)
        Console.WriteLine("--------------------------------")
        Dim DTO As ContactsProject.Contracts.IChancheContact = New Contracts.Contracts
        DTO.Value = Val.Model.Value
        Console.WriteLine("Παρακαλώ Δώσε καινουργιο Description")
        DTO.Description = Console.ReadLine
        If Help.AccessChoice("Θέλεις να συνεχήσεις?") Then
            Console.Clear()
            Console.WriteLine(Contact.Update(ContactRef, DTO, ChoiceType).Msg)
            Console.ReadLine()
        End If
    End Sub
    Friend Sub Remove(ContactRef As Contracts.IReference, ChoiceType As Service.Service.ChoiceType)
        Dim Val As MyBook.ValMsg(Of Contracts.IModel) = Contact.Exist(ContactRef, ChoiceType)
        Console.Clear()
        If Val.ToString = False Then
            Console.WriteLine(Val.Msg)
            Exit Sub
        End If
        Console.WriteLine("----------- Remove Contact ----------")
        Info(Val.Model)
        Console.WriteLine("------------------------------")
        If Help.AccessChoice("Θέλεις να διαγράψεις το Contact;") Then
            Console.Clear()
            Console.WriteLine(Contact.Remove(ContactRef, ChoiceType))
            Console.ReadLine()
        End If
    End Sub
End Module
