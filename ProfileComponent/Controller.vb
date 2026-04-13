Public Class Controller
    Public Person As New PersonProject.Service.PersonService
    Public Family As New FamilyProject.Family.Service.Service(Person)
    Public Children As New FamilyProject.Children.Service.ChildrenService(Person)
    Public Contact As New ContactsProject.Service.Service
End Class
