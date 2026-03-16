Namespace Service
    Public Class Service
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, My.Apartment.Entity, Repository.Repository)

        Sub New()
            MyBase.New(New Repository.Repository)
        End Sub

        Public Function SearchByExternalID(BuildID As Integer) As MyBook.ValMsg(Of List(Of Contracts.IModel))
            Dim Val As New MyBook.ValMsg(Of List(Of Contracts.IModel))
            Val.Model = New List(Of Contracts.IModel)
            For Each Entity In Repository.Read_All
                If Entity.BuildID = BuildID Then
                    Val.Success = True
                    Val.Msg = "Βρέθηκε εγραφή!"
                    Val.Model.Add(ToModel(Entity))
                End If
            Next
            If Val.Success = False Then
                Val.Msg = "Δεν βρέθηκε Εργαφή! "
            End If
            Return Val
        End Function

        Public Overrides Function ToModel(Entity As My.Apartment.Entity) As Contracts.Contracts
            Dim Model As New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Orofos = Entity.Orofos
                .Lenght = Entity.Lenght
                .Koudouni = Entity.Koudouni
                .BuildID = Entity.BuildID
                .Description = Entity.Description
                .Diamenrisma = Entity.Diamenrisma
                .Width = Entity.Width
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As My.Apartment.Entity
            Dim Entity As New My.Apartment.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim DTOs As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .BuildID = DTOs.BuildID
                    .Koudouni = DTOs.Koudouni
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                    .Description = DTOs.Description
                    .Orofos = DTOs.Orofos
                    .Diamenrisma = DTOs.Diamenrisma
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeOrofos) Then
                Dim DTOs As Contracts.IChangeOrofos = DTOLink
                With Entity
                    .Orofos = DTOs.Orofos
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeLenght) Then
                Dim DTOs As Contracts.IChangeLenght = DTOLink
                With Entity
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDiamerisma) Then
                Dim DTOs As Contracts.IChangeDiamerisma = DTOLink
                With Entity
                    .Diamenrisma = DTOs.Diamenrisma
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeKoudouni) Then
                Dim DTOs As Contracts.IChangeKoudouni = DTOLink
                With Entity
                    .Koudouni = DTOs.Koudouni
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescription) Then
                Dim DTOs As Contracts.IChangeDescription = DTOLink
                With Entity
                    .Description = DTOs.Description
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As My.Apartment.Entity) As My.Apartment.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim DTOs As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .BuildID = DTOs.BuildID
                    .Koudouni = DTOs.Koudouni
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                    .Description = DTOs.Description
                    .Orofos = DTOs.Orofos
                    .Diamenrisma = DTOs.Diamenrisma
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeOrofos) Then
                Dim DTOs As Contracts.IChangeOrofos = DTOLink
                With Entity
                    .Orofos = DTOs.Orofos
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeLenght) Then
                Dim DTOs As Contracts.IChangeLenght = DTOLink
                With Entity
                    .Lenght = DTOs.Lenght
                    .Width = DTOs.Width
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDiamerisma) Then
                Dim DTOs As Contracts.IChangeDiamerisma = DTOLink
                With Entity
                    .Diamenrisma = DTOs.Diamenrisma
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeKoudouni) Then
                Dim DTOs As Contracts.IChangeKoudouni = DTOLink
                With Entity
                    .Koudouni = DTOs.Koudouni
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeDescription) Then
                Dim DTOs As Contracts.IChangeDescription = DTOLink
                With Entity
                    .Description = DTOs.Description
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

