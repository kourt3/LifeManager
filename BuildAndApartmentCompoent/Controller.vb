Public Class Controller
    Public BuildService As BuildAndApartment.Build.Service.Service
    Public ApartmentService As BuildAndApartment.Apartment.Service.Service
    Public Cohrabication As BuildAndApartment.Cohrabication.Service.Service

    Sub New(BuildServiceLink As BuildAndApartment.Build.Service.Service, ApartmentServiceLink As BuildAndApartment.Apartment.Service.Service, CohrabicationSeriveLink As BuildAndApartment.Cohrabication.Service.Service)
        BuildService = BuildServiceLink
        ApartmentService = ApartmentServiceLink
        Cohrabication = CohrabicationSeriveLink
    End Sub
    Sub New()
        BuildService = New BuildAndApartment.Build.Service.Service
        ApartmentService = New BuildAndApartment.Apartment.Service.Service
        Cohrabication = New BuildAndApartment.Cohrabication.Service.Service(BuildService, ApartmentService)
    End Sub
End Class
