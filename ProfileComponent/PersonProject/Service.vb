Namespace PersonProject.Service
    Public Class PersonService
        Inherits MyBook.Services.Service(Of Integer, Contracts.Contracts, PersonProject.Enity.Entity, PersonProject.Repository.DatabaseRepository)

        Sub New()
            MyBase.New(New PersonProject.Repository.DatabaseRepository)
        End Sub


        Public Overrides Function ToModel(Entity As PersonProject.Enity.Entity) As Contracts.Contracts
            Dim Model As Contracts.IModel = New Contracts.Contracts
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .FristName = Entity.FristName
                .SecondName = Entity.SecondName
                .Birthday = Entity.Birthday
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As PersonProject.Enity.Entity
            Dim Entity As New PersonProject.Enity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .FristName = RegisterDTO.FristName
                    .SecondName = RegisterDTO.SecondName
                    .Birthday = RegisterDTO.Birthday
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeFirstNameDTO) Then
                Dim ChangeDTO As Contracts.IChangeFirstNameDTO = DTOLink
                With Entity
                    .FristName = ChangeDTO.FristName
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeSecondNameDTO) Then
                Dim ChangeDTO As Contracts.IChangeSecondNameDTO = DTOLink
                With Entity
                    .SecondName = ChangeDTO.SecondName
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeFirstNameAndSecondNameDTO) Then
                Dim ChangeDTO As Contracts.IChangeFirstNameAndSecondNameDTO = DTOLink
                With Entity
                    .FristName = ChangeDTO.FristName
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IBirthDay) Then
                Dim ChangeDTO As Contracts.IBirthDay = DTOLink
                With Entity
                    .Birthday = ChangeDTO.Birthday
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As PersonProject.Enity.Entity) As PersonProject.Enity.Entity
            If GetType(DTO) Is GetType(Contracts.IRegisterDTO) Then
                Dim RegisterDTO As Contracts.IRegisterDTO = DTOLink
                With Entity
                    .FristName = RegisterDTO.FristName
                    .SecondName = RegisterDTO.SecondName
                    .Birthday = RegisterDTO.Birthday
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeFirstNameDTO) Then
                Dim ChangeDTO As Contracts.IChangeFirstNameDTO = DTOLink
                With Entity
                    .FristName = ChangeDTO.FristName
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeSecondNameDTO) Then
                Dim ChangeDTO As Contracts.IChangeSecondNameDTO = DTOLink
                With Entity
                    .SecondName = ChangeDTO.SecondName
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IChangeFirstNameAndSecondNameDTO) Then
                Dim ChangeDTO As Contracts.IChangeFirstNameAndSecondNameDTO = DTOLink
                With Entity
                    .FristName = ChangeDTO.FristName
                End With
            ElseIf GetType(DTO) Is GetType(Contracts.IBirthDay) Then
                Dim ChangeDTO As Contracts.IBirthDay = DTOLink
                With Entity
                    .Birthday = ChangeDTO.Birthday
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

