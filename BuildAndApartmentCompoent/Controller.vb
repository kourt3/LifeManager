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

    Sub AddBuild()

    End Sub
    Sub UpdateBuild()

    End Sub
    Sub RemoveBuild()

    End Sub
    Sub AddApartment()

    End Sub
    Sub UpdateApartment()

    End Sub
    Sub RemoveApartment()

    End Sub
    Sub AddCohrabication()

    End Sub
    Sub UpdateCohrabication()

    End Sub
    Sub RemoveCohrabication()

    End Sub
End Class
