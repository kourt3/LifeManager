Public Class AddressesController
    Public Country As New Service
    Public Perifereia As New Service
    Public Nomos As New Service
    Public TK As New Service
    Public Dhmos As New Service
    Public Address As New Service
    Public Number As New Service

    Public FullAddress As New FullAdress.Service.Service

    Public CountryTOPeriferia As New AddressRelationShip.Service.Service
    Public PeriferiaTONomo As New AddressRelationShip.Service.Service
    Public NomosTOTK As New AddressRelationShip.Service.Service
    Public TKTODhmos As New AddressRelationShip.Service.Service
    Public DhmosToAddress As New AddressRelationShip.Service.Service
    Public AddressToNumber As New AddressRelationShip.Service.Service


End Class
