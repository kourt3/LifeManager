Namespace GiftsCard.Services
    Public Class Services
        Inherits MyBook.Services.Service(Of Integer, GiftsCard.Contracs.Contracs, GiftsCard.Entity.Entity, GiftsCard.Repository.Repository)

        Sub New()
            MyBase.New(New GiftsCard.Repository.Repository)
        End Sub

        Public Overrides Function ToModel(Entity As Entity.Entity) As Contracs.Contracs
            Dim Model As GiftsCard.Contracs.IModel = New GiftsCard.Contracs.Contracs
            With Model
                .PrimaryKey = Entity.PrimaryKey
                .Name = Entity.Name
                .NumberCard = Entity.NumberCard
                .Code = Entity.Code
                .Description = Entity.Description
            End With
            Return Model
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As GiftsCard.Entity.IEntity = New Entity.Entity
            If GetType(DTO) = GetType(Contracs.IRegisterDTO) Then
                Dim RegisterDTO As Contracs.IRegisterDTO = DTOLink
                With Entity
                    .Name = RegisterDTO.Name
                    .NumberCard = RegisterDTO.Name
                    .Code = RegisterDTO.Code
                    .Description = RegisterDTO.Description
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) = GetType(Contracs.IRegisterDTO) Then
                Dim RegisterDTO As Contracs.IRegisterDTO = DTOLink
                With Entity
                    .Name = RegisterDTO.Name
                    .NumberCard = RegisterDTO.Name
                    .Code = RegisterDTO.Code
                    .Description = RegisterDTO.Description
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

