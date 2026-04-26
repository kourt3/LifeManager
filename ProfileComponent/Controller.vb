Public Class Model
    Property Profile As Profile.Able.IReference
    Property PersonModel As PersonProject.Contracts.IModel
    Property Family As FamilyProject.Model
    Property Contacts As New List(Of ContactsProject.Contracts.IModel)
    Sub New()
        Profile = New ProfileComponent.Profile.Contracts.Contracts
        PersonModel = New PersonProject.Contracts.Contracts
        Family = New FamilyProject.Model
        Contacts = New List(Of ContactsProject.Contracts.IModel)
    End Sub
End Class
Public Class Controller
    Enum FamilyType
        None
        Mother
        Father
        Husband
    End Enum

    Public Profile As New Profile.Service.Service
    Public Person As New PersonProject.Service.PersonService
    Public Family As New FamilyProject.FamilyController(Person)
    Public Contact As New ContactsProject.Service.Service

    Function AddProfile(RegisterDTO As PersonProject.Contracts.IRegisterDTO) As MyBook.ValMsg(Of Model)

        Dim Val As New MyBook.ValMsg(Of Model)
        Val.Model = New Model
        Dim PersonVal As MyBook.ValMsg(Of PersonProject.Contracts.Contracts) = Person.Register(RegisterDTO)
        If PersonVal.Success = False Then
            Val.Msg = PersonVal.Msg
            Val.Success = False
            Return Val
        End If
        Dim RegisterProfileDTO As Profile.Contracts.IRegisterDTO = New Profile.Contracts.Contracts
        RegisterProfileDTO.PersonID = PersonVal.Model.PrimaryKey
        Dim FamilyRegisterDTO As FamilyProject.Family.Contracts.IRegisterDTO = New FamilyProject.Family.Contracts.Contracts
        FamilyRegisterDTO.ExternalID = PersonVal.Model.PrimaryKey
        FamilyRegisterDTO.Mother = 0
        FamilyRegisterDTO.Father = 0
        FamilyRegisterDTO.Spouse = 0
        Dim FamilyVal As MyBook.ValMsg(Of FamilyProject.Family.Contracts.Contracts) = Family.Family.Register(FamilyRegisterDTO)
        If FamilyVal.Success = False Then
            Val.Msg = FamilyVal.Msg
            Val.Success = False
            Return Val
        End If

        RegisterProfileDTO.FamilyID = FamilyVal.Model.PrimaryKey

        Dim ProfileVal As MyBook.ValMsg(Of Profile.Contracts.Contracts) = Profile.Register(RegisterProfileDTO)
        If ProfileVal.Success = False Then
            Val.Msg = ProfileVal.Msg
            Val.Success = False
            Return Val
        End If

        Val.Msg = ProfileVal.Msg
        Val.Success = True
        Val.Model.Profile = ProfileVal.Model
        Val.Model.PersonModel = PersonVal.Model
        Val.Model.Family.FamilyModel = FamilyVal.Model
        Val.Model.Contacts = New List(Of ContactsProject.Contracts.IModel)
        Return Val

    End Function

    Function RemoveProfile(ProfileRef As Profile.Able.IReference) As MyBook.ValMsg
        Dim Val As New MyBook.ValMsg
        Dim ProfileVal As MyBook.ValMsg(Of Profile.Contracts.Contracts) = Profile.Exist(ProfileRef)
        If ProfileVal.Success = False Then
            Val.Success = False
            Val.Msg = ProfileVal.Msg
            Return Val
        End If
        Person.Remove(New PersonProject.Contracts.Contracts With {.PrimaryKey = ProfileVal.Model.PersonID})
        Family.Family.Remove(New FamilyProject.Family.Contracts.Contracts With {.PrimaryKey = ProfileVal.Model.FamilyID})
        Dim Creterias As ContactsProject.Contracts.ICreteria = New ContactsProject.Contracts.Contracts
        Creterias.ExternalID = ProfileRef.PrimaryKey
        For Each EntityL In Contact.Search(Creterias).Model
            Contact.Remove(EntityL)
        Next
        Val.Success = True
        Val.Msg = "Διαγράφηκε το Profile"
        Return Val
    End Function

    Function ExistProfile(ProfileRef As Profile.Able.IReference) As MyBook.ValMsg(Of Model)
        Dim Val As New MyBook.ValMsg(Of Model)
        Val.Model = New Model
        Dim ProfileVal As Profile.Contracts.Contracts = Profile.Exist(ProfileRef).Model
        Dim PersonVal As PersonProject.Contracts.Contracts = Person.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = ProfileVal.PersonID}).Model
        Dim FamilyVal As MyBook.ValMsg(Of FamilyProject.Family.Contracts.Contracts) = Family.Family.Exist(New FamilyProject.Family.Contracts.Contracts With {.PrimaryKey = ProfileVal.FamilyID})
        If FamilyVal.Success = False Then
            FamilyVal.Model = New FamilyProject.Family.Contracts.Contracts
        End If

        Dim Creteria As ContactsProject.Contracts.ICreteria = New ContactsProject.Contracts.Contracts
        Creteria.ExternalID = ProfileRef.PrimaryKey
        Dim ContactModel As List(Of ContactsProject.Contracts.IModel) = Contact.Search(Creteria).Model
        Val.Success = True
        Val.Msg = "Βρέθηκαν εγραφες!"
        Val.Model.PersonModel = PersonVal
        Val.Model.Family.FamilyModel = FamilyVal.Model
        Val.Model.Contacts = ContactModel
        Val.Model.Profile = ProfileRef
        Return Val
    End Function

    Function ExistPerson(PersonRef As PersonProject.Enity.IReference) As MyBook.ValMsg(Of Model)

        Dim Val As New MyBook.ValMsg(Of Model)
        Dim Creteria As Profile.Contracts.ICreteria = New Profile.Contracts.Contracts
        Creteria.PersonID = PersonRef.PrimaryKey
        Dim ValProfile As MyBook.ValMsg(Of Profile.Contracts.Contracts) = Profile.Search(Creteria)
        Val.Model.Profile = ValProfile.Model
        Val.Model.PersonModel = Person.Exist(PersonRef).Model
        Val.Model.Family.FamilyModel = Family.Family.Exist(New FamilyProject.Family.Contracts.Contracts With {.PrimaryKey = ValProfile.Model.FamilyID}).Model

        Dim CreteriaContacts As ContactsProject.Contracts.ICreteria = New ContactsProject.Contracts.Contracts
        CreteriaContacts.ExternalID = Val.Model.Profile.PrimaryKey
        Dim ContactVal As MyBook.ValMsg(Of List(Of ContactsProject.Contracts.IModel)) = Contact.Search(CreteriaContacts)
        Val.Model.Contacts = ContactVal.Model
        Val.Success = True
        Val.Msg = "Βρέθηκε η εγραφή"
        Return Val

    End Function

    ''' <summary>
    ''' List Of Profile
    ''' </summary>
    ''' <param name="ProfileRef">Παρακαμπτη το Profile απο το List Of Profile</param>
    ''' <returns></returns>
    Function ListOfProfiles(Optional ProfileRef As ProfileComponent.Profile.Able.IReference = Nothing) As MyBook.ValMsg(Of List(Of Model))
        Dim Val As New MyBook.ValMsg(Of List(Of Model))
        Val.Model = New List(Of Model)
        Val.Success = False
        Val.Msg = "Δεν βρέθηκε εγραφή!"

        For Each Entity In Profile.Get_All.Model

            If ProfileRef IsNot Nothing Then
                If Entity.PrimaryKey = ProfileRef.PrimaryKey Then
                    Continue For
                End If
            End If

            Dim PersonModel As PersonProject.Contracts.Contracts = Person.Exist(New PersonProject.Contracts.Contracts With {.PrimaryKey = Entity.PersonID}).Model
            Dim FamilyModel As FamilyProject.Family.Contracts.Contracts = Family.Family.Exist(New FamilyProject.Family.Contracts.Contracts With {.PrimaryKey = Entity.FamilyID}).Model
            Dim ContactCreteria As ContactsProject.Contracts.ICreteria = New ContactsProject.Contracts.Contracts
            ContactCreteria.ExternalID = Entity.PrimaryKey
            Dim ContactModel As List(Of ContactsProject.Contracts.IModel) = Contact.Search(ContactCreteria).Model
            Dim Model As New Model
            With Model
                .PersonModel = PersonModel
                .Profile = Entity
                .Family.FamilyModel = FamilyModel
                .Contacts = ContactModel
            End With

            Val.Model.Add(Model)
            Val.Success = True
            Val.Msg = "Βρέθηκε η εγραφή!"
        Next

        Return Val
    End Function

    Function RemovePerson(PersonRef As PersonProject.Enity.IReference) As MyBook.ValMsg
        Dim Val As New MyBook.ValMsg
        Dim PersonVal As MyBook.ValMsg(Of PersonProject.Contracts.Contracts) = Person.Exist(PersonRef)

        If PersonVal.Success = False Then
            Val.Msg = PersonVal.Msg
            Val.Success = False
            Return Val
        End If

        Dim Creteria As Profile.Contracts.ICreteria = New Profile.Contracts.Contracts
        Creteria.PersonID = PersonRef.PrimaryKey
        Dim ProfileVal As MyBook.ValMsg(Of Profile.Contracts.Contracts) = Profile.Search(Creteria)
        If ProfileVal.Success = False Then
            Val.Msg = ProfileVal.Msg
            Val.Success = False
            Return Val
        End If

        Dim FamilyVal As MyBook.ValMsg(Of FamilyProject.Family.Contracts.Contracts) = Family.Family.Exist(New FamilyProject.Family.Contracts.Contracts With {.PrimaryKey = ProfileVal.Model.FamilyID})
        If FamilyVal.Success = False Then
            Val.Msg = FamilyVal.Msg
            Val.Success = False
            Return Val
        End If

        Dim ContacrsCreteria As ContactsProject.Contracts.ICreteria = New ContactsProject.Contracts.Contracts
        ContacrsCreteria.ExternalID = ProfileVal.Model.PrimaryKey
        Dim ContactVal As MyBook.ValMsg(Of List(Of ContactsProject.Contracts.IModel)) = Contact.Search(Creteria)
        If ContactVal.Success = False Then
            Val.Success = False
            Val.Msg = ContactVal.Msg
        Else
            For Each ContactEntity In ContactVal.Model
                Contact.Remove(ContactEntity)
            Next
        End If

        Family.Family.Remove(FamilyVal.Model)
        Person.Remove(PersonRef)
        Profile.Remove(ProfileVal.Model)

        Val.Success = True
        Val.Msg = "Διαγράφηκε το profile!"
        Return Val

    End Function

    ''' <summary>
    ''' Friends που εχει το profile
    ''' </summary>
    ''' <param name="ProfileRef"></param>
    ''' <returns></returns>
    Function Contact_AllowsFriend(ProfileRef As ProfileComponent.Profile.Able.IReference) As MyBook.ValMsg(Of List(Of Model))
        Dim Val As New MyBook.ValMsg(Of List(Of Model))
        Val.Model = New List(Of Model)
        Val.Success = False
        Val.Msg = "Δεν βρέθηκε εγραφή!"

        For Each ContactL In Contact.Get_All_AllowFriends(ProfileRef.PrimaryKey).Model
            Val.Model.Add(ExistProfile(New Profile.Contracts.Contracts With {.PrimaryKey = ContactL.ToExternalID}).Model)
            Val.Success = True
            Val.Msg = "Βρέθηκαν εγραφές!"
        Next

        Return Val
    End Function
    ''' <summary>
    ''' Φιλους που δεν εχει το profile
    ''' </summary>
    ''' <param name="ProfileRef"></param>
    ''' <returns></returns>
    Function Contact_NotAllowsFriends(ProfileRef As ProfileComponent.Profile.Able.IReference) As MyBook.ValMsg(Of List(Of Model))
        Dim Val As New MyBook.ValMsg(Of List(Of Model))
        Val.Model = New List(Of Model)
        Val.Success = False
        Val.Msg = "Δεν βρέθηκε εγραφή!"

        Dim Profiles As List(Of Profile.Contracts.Contracts) = Profile.Get_All().Model
        Dim ContactCreteria As ContactsProject.Contracts.ICreteria = New ContactsProject.Contracts.Contracts
        ContactCreteria.ExternalID = ProfileRef.PrimaryKey
        Dim Contacts As List(Of ProfileComponent.ContactsProject.Contracts.IModel) = Contact.Search(ContactCreteria).Model

        For Each ProfilesL In Profiles
            Dim Exist As Boolean = False
            If ProfilesL.PrimaryKey = ProfileRef.PrimaryKey Then
                Continue For
            End If


            For Each ContactsL In Contacts
                If ContactsL.ToExternalID = ProfilesL.PrimaryKey Then
                    Exist = True
                End If
            Next

            If Exist = False Then
                Val.Model.Add(ExistProfile(ProfilesL).Model)
            End If

        Next

        Return Val
    End Function
End Class
