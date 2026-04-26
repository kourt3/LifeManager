Imports ProfileComponent.FamilyProject.Family.Ables

Namespace FamilyProject
    Public Class Model
        Property FamilyModel As Family.Contracts.IModel
        Property Childrends As List(Of Children.Conctracts.IModel)
        Sub New()
            FamilyModel = New Family.Contracts.Contracts
            Childrends = New List(Of Children.Conctracts.IModel)
        End Sub
    End Class

    Public Class FamilyController
        Property Family As FamilyProject.Family.Service.Service
        Property Childrens As FamilyProject.Children.Service.ChildrenService

        Sub New(PersonServiceLink As PersonProject.Service.PersonService)
            Family = New Family.Service.Service(PersonServiceLink)
            Childrens = New Children.Service.ChildrenService(PersonServiceLink)
        End Sub

        Function AddFamily(ExternalID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Family.Contracts.IRegisterDTO = New Family.Contracts.Contracts
            With RegisterDTO
                .ExternalID = ExternalID
                .Mother = 0
                .Father = 0
                .Spouse = 0
            End With
            Dim FamilyVal As MyBook.ValMsg(Of Family.Contracts.Contracts) = Family.Register(RegisterDTO)
            If FamilyVal.Success = False Then
                Val.Success = False
                Val.Msg = FamilyVal.Msg
                Return Val
            End If

            Val.Success = True
            Val.Msg = "Η εγραφή ολοκληρώθηκε!"
            Return Val
        End Function
        Function AddMother(FamilyRef As Family.Contracts.IReference, MotherID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Family.Contracts.IRemoveMotherDTO = New Family.Contracts.Contracts
            With RegisterDTO
                .Mother = MotherID
            End With
            Dim ValFamily As MyBook.ValMsg = Family.Change(FamilyRef, RegisterDTO)

            If ValFamily.Success = False Then
                Val.Success = False
                Val.Msg = ValFamily.Msg
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function

        Function AddMotherWithCompleteChild(FamilyRef As Family.Contracts.IReference, MotherID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model

            Val = AddMother(FamilyRef, MotherID)
            If Val.Success = False Then
                Return Val
            End If



            Dim Creteria As Family.Contracts.ICreteria = New Family.Contracts.Contracts
            With Creteria
                .ExternalID = MotherID
            End With

            Dim Mother As MyBook.ValMsg(Of Family.Contracts.IModel) = Family.Search(Creteria)

            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = Mother.Model.PrimaryKey
                .PersonID = FamilyRef.PrimaryKey
            End With

            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Msg = ChildVal.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function
        Function AddFather(FamilyRef As Family.Contracts.IReference, FatherID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Family.Contracts.IRegisterFatherDTO = New Family.Contracts.Contracts
            With RegisterDTO
                .Father = FatherID
            End With
            Dim ValFamily As MyBook.ValMsg = Family.Change(FamilyRef, RegisterDTO)
            If ValFamily.Success = False Then
                Val.Success = False
                Val.Msg = ValFamily.Msg
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function
        Function AddFatherWithCompleteChild(FamilyRef As Family.Contracts.IReference, FatherId As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Val = AddFather(FamilyRef, FatherId)
            If Val.Success = False Then
                Return Val
            End If



            Dim Creteria As Family.Contracts.ICreteria = New Family.Contracts.Contracts
            With Creteria
                .ExternalID = FatherId
            End With

            Dim Mother As MyBook.ValMsg(Of Family.Contracts.IModel) = Family.Search(Creteria)

            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = Mother.Model.PrimaryKey
                .PersonID = FamilyRef.PrimaryKey
            End With

            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Msg = ChildVal.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function
        Function AddSpouce(FamilyRef As Family.Contracts.IReference, HusbandID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Family.Contracts.IRegisterHusbandDTO = New Family.Contracts.Contracts
            With RegisterDTO
                .Spouse = HusbandID
            End With
            Dim ValFamily As MyBook.ValMsg = Family.Change(FamilyRef, RegisterDTO)
            If ValFamily.Success = False Then
                Val.Success = False
                Val.Msg = ValFamily.Msg
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function

        Function AddSpouseWithComplete(FamilyRef As Family.Contracts.IReference, SpouseID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Val = AddSpouce(FamilyRef, SpouseID)
            If Val.Success = False Then
                Return Val
            End If
            Dim Creteria As Family.Contracts.ICreteria = New Family.Contracts.Contracts
            With Creteria
                .ExternalID = SpouseID
            End With

            Val = AddSpouce(New Family.Contracts.Contracts With {.PrimaryKey = SpouseID}, FamilyRef.PrimaryKey)
            If Val.Success = False Then
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function

        Function AddChildren(Familyref As Family.Contracts.IReference, ChildId As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = Familyref.PrimaryKey
                .PersonID = ChildId
            End With
            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Msg = ChildVal.Msg
                Val.Success = False
                Return Val
            End If
            Return ExistFamily(Familyref)
        End Function
        Function AddChildWithCompleteMother(FamilyRef As Family.Contracts.IReference, ChildId As Integer) As MyBook.ValMsg(Of Model)

            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = FamilyRef.PrimaryKey
                .PersonID = ChildId
            End With

            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Success = False
                Val.Msg = ChildVal.Msg
                Return Val
            End If

            Dim ExistRef As Family.Contracts.Contracts = Family.Exist(FamilyRef).Model

            Dim FamilyRegisterDTO As Family.Contracts.IRegisterMotherDTO = New Family.Contracts.Contracts
            With FamilyRegisterDTO
                .Mother = ExistRef.ExternalID
            End With

            Dim FindFamilyRefOfChild As Family.Contracts.ICreteria = New Family.Contracts.Contracts
            FindFamilyRefOfChild.ExternalID = ChildId

            Dim FindFamilyOfChild As MyBook.ValMsg(Of Family.Contracts.IModel) = Family.Search(FindFamilyRefOfChild)
            If FindFamilyOfChild.Success = False Then
                Val.Msg = FindFamilyOfChild.Msg
                Val.Success = False
                Return Val
            End If

            Dim RegisterValFamily As MyBook.ValMsg = Family.Change(FindFamilyOfChild.Model, FamilyRegisterDTO)
            If RegisterValFamily.Success = False Then
                Val.Msg = RegisterValFamily.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function

        Function AddChildWithCompleteFather(FamilyRef As Family.Contracts.IReference, ChildId As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            ' ------------- Εγραφη Child
            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = FamilyRef.PrimaryKey
                .PersonID = ChildId
            End With

            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Success = False
                Val.Msg = ChildVal.Msg
                Return Val
            End If
            '-------------------
            ' Βρισκω το Id  profile 
            Dim ExistRef As Family.Contracts.Contracts = Family.Exist(FamilyRef).Model
            'Βρήκα το ID 
            '----------

            Dim FamilyRegisterDTO As Family.Contracts.IRegisterFatherDTO = New Family.Contracts.Contracts
            With FamilyRegisterDTO
                .Father = ExistRef.ExternalID
            End With



            Dim FindFamilyRefOfChild As Family.Contracts.ICreteria = New Family.Contracts.Contracts
            FindFamilyRefOfChild.ExternalID = ChildId

            Dim FindFamilyOfChild As MyBook.ValMsg(Of Family.Contracts.IModel) = Family.Search(FindFamilyRefOfChild)
            If FindFamilyOfChild.Success = False Then
                Val.Msg = FindFamilyOfChild.Msg
                Val.Success = False
                Return Val
            End If

            Dim RegisterValFamily As MyBook.ValMsg = Family.Change(FindFamilyOfChild.Model, FamilyRegisterDTO)
            If RegisterValFamily.Success = False Then
                Val.Msg = RegisterValFamily.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function

        Function ExistFamily(Familyref As Family.Contracts.IReference) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)

            Val.Model = New Model
            Dim FamilyVal As MyBook.ValMsg(Of Family.Contracts.Contracts) = Family.Exist(Familyref)
            If FamilyVal.Success = False Then
                Val.Success = False
                Val.Msg = FamilyVal.Msg
                Return Val
            End If
            Val.Model.FamilyModel = FamilyVal.Model
            Val.Success = True
            Val.Msg = FamilyVal.Msg
            Dim Creteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
            With Creteria
                .FamilyID = Familyref.PrimaryKey
            End With

            Dim ChildVals As MyBook.ValMsg(Of List(Of Children.Conctracts.IModel)) = Childrens.Search(Creteria)
            Val.Model.Childrends = ChildVals.Model

            Return Val

        End Function

        Function RemoveFamily(FamilyRef As Family.Contracts.IReference) As MyBook.ValMsg
            Return Family.Remove(FamilyRef)
        End Function
        Function RemoveMother(FamilyRef As Family.Contracts.IReference) As MyBook.ValMsg(Of Model)

        End Function
        Function RemoveFather(FamilyRef As Family.Contracts.IReference) As MyBook.ValMsg(Of Model)

        End Function
        Function RemoveHusband(FamilyRef As Family.Contracts.IReference) As MyBook.ValMsg(Of Model)

        End Function
        Function RemoveChildren(FamilyRef As Family.Contracts.IReference) As MyBook.ValMsg(Of Model)

        End Function

    End Class


End Namespace
