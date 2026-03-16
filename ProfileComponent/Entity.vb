Namespace My.Entity

    Structure Data
        Public Id As Integer
        Public PersonId As Integer
        Public EconomyId As Integer
    End Structure

    Public Interface IPersonId
        Property PersonId As Integer

    End Interface
    Public Interface IEconomyId
        Property EconomyID As Integer
    End Interface

    Public Interface IEntity
        Inherits IPersonId
        Inherits IEconomyId
        Inherits MyBook.IEntityAbles(Of Integer)
    End Interface


    Public Class Entity
        Implements IEntity

        Private Data As New Data

        Public Property PersonId As Integer Implements IPersonId.PersonId
            Get
                Return Data.PersonId
            End Get
            Set(value As Integer)
                Data.PersonId = value
            End Set
        End Property

        Public Property EconomyID As Integer Implements IEconomyId.EconomyID
            Get
                Return Data.EconomyId
            End Get
            Set(value As Integer)
                Data.EconomyId = value
            End Set
        End Property

        Public Property PrimaryKey As Integer Implements MyBook.IHasPrimaryKey(Of Integer).PrimaryKey
            Get
                Return Data.Id
            End Get
            Set(value As Integer)
                Data.Id = value
            End Set
        End Property

        Public Function EqualsByPrimaryKey(PK As Integer) As Boolean Implements MyBook.IEntityAbles(Of Integer).EqualsByPrimaryKey
            If PrimaryKey = PK Then
                Return True
            End If
            Return False
        End Function

        Public Function CopyAsNewObject(Of TEntinty)() As TEntinty Implements MyBook.IEntityAbles(Of Integer).CopyAsNewObject
            Dim newEntity As New Entity
            With newEntity
                .PrimaryKey = Data.Id
                .PersonId = Data.PersonId
                .EconomyID = Data.EconomyId
            End With
            Return CType(newEntity, My.Entity.IEntity)
        End Function
    End Class
End Namespace
