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

        Function AddFamily() As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Family.Contracts.IRegisterDTO = New Family.Contracts.Contracts
            With RegisterDTO
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
        Function AddMother(FamilyRef As Family.Ables.IReference, MotherID As Integer) As MyBook.ValMsg(Of Model)
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

        Function AddMotherWithCompleteChild(MyFamilyRef As Family.Ables.IReference, MotherFamilyRef As Family.Ables.IReference, MyID As Integer, MotherID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Val = AddMother(MyFamilyRef, MotherID)
            If Val.Success = False Then
                Return Val
            End If

            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = MotherFamilyRef.PrimaryKey
                .ToExternalID = MyID
            End With

            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Msg = ChildVal.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(MyFamilyRef)
        End Function
        Function AddFather(FamilyRef As Family.Ables.IReference, FatherID As Integer) As MyBook.ValMsg(Of Model)
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
        Function AddFatherWithCompleteChild(MyFamilyRef As Family.Ables.IReference, FatherFamilyRef As Family.Ables.IReference, MyId As Integer, FatherId As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Val = AddFather(MyFamilyRef, FatherId)
            If Val.Success = False Then
                Return Val
            End If

            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = FatherFamilyRef.PrimaryKey
                .ToExternalID = MyId
            End With

            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Msg = ChildVal.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(MyFamilyRef)
        End Function
        Function AddSpouce(FamilyRef As Family.Ables.IReference, HusbandID As Integer) As MyBook.ValMsg(Of Model)
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

        Function AddSpouseWithComplete(MyFamilyRef As Family.Ables.IReference, SpouceFamilyRef As Family.Ables.IReference, MyId As Integer, SpouseID As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Val = AddSpouce(MyFamilyRef, SpouseID)
            If Val.Success = False Then
                Return Val
            End If

            Val = AddSpouce(SpouceFamilyRef, MyId)
            If Val.Success = False Then
                Return Val
            End If

            Return ExistFamily(MyFamilyRef)
        End Function

        Function AddChildren(Familyref As Family.Ables.IReference, ChildId As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = Familyref.PrimaryKey
                .ToExternalID = ChildId
            End With
            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Msg = ChildVal.Msg
                Val.Success = False
                Return Val
            End If
            Return ExistFamily(Familyref)
        End Function
        Function AddChildWithCompleteMother(FamilyRef As Family.Ables.IReference, ChildFamilyRef As Family.Ables.IReference, MyId As Integer, ChildId As Integer) As MyBook.ValMsg(Of Model)

            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = FamilyRef.PrimaryKey
                .ToExternalID = ChildId
            End With

            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Register(RegisterDTO)
            If ChildVal.Success = False Then
                Val.Success = False
                Val.Msg = ChildVal.Msg
                Return Val
            End If

            Dim FamilyRegisterDTO As Family.Contracts.IRegisterMotherDTO = New Family.Contracts.Contracts
            With FamilyRegisterDTO
                .Mother = MyId
            End With

            Dim RegisterValFamily As MyBook.ValMsg = Family.Change(ChildFamilyRef, FamilyRegisterDTO)
            If RegisterValFamily.Success = False Then
                Val.Msg = RegisterValFamily.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function

        Function AddChildWithCompleteFather(FamilyRef As Family.Ables.IReference, ChildFamilyRef As Family.Ables.IReference, MyId As Integer, ChildId As Integer) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Val.Model = New Model
            ' ------------- Εγραφη Child -----------
            Dim RegisterDTO As Children.Conctracts.IRegister = New Children.Conctracts.Contracts
            With RegisterDTO
                .FamilyID = FamilyRef.PrimaryKey
                .ToExternalID = ChildId
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
                .Father = MyId
            End With


            Dim RegisterValFamily As MyBook.ValMsg = Family.Change(ChildFamilyRef, FamilyRegisterDTO)
            If RegisterValFamily.Success = False Then
                Val.Msg = RegisterValFamily.Msg
                Val.Success = False
                Return Val
            End If

            Return ExistFamily(FamilyRef)
        End Function

        Function ExistFamily(Familyref As Family.Ables.IReference) As MyBook.ValMsg(Of Model)
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

        Function RemoveFamily(FamilyRef As Family.Ables.IReference) As MyBook.ValMsg
            Return Family.Remove(FamilyRef)
        End Function
        Function RemoveMother(FamilyRef As Family.Ables.IReference) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Dim ChangeDTO As Family.Contracts.IRemoveMotherDTO = New Family.Contracts.Contracts
            ChangeDTO.Mother = 0
            Dim ValFamily As MyBook.ValMsg = Family.Change(FamilyRef, ChangeDTO)
            If ValFamily.Success = False Then
                Val.Msg = ValFamily.Msg
                Val.Success = False
                Return Val
            End If
            Return ExistFamily(FamilyRef)
        End Function
        Function RemoveMotherWithCompleteChild(FamilyRef As Family.Ables.IReference, MotherFamilyRef As Family.Ables.IReference, MyId As Integer) As MyBook.ValMsg(Of Model)
            Dim ExistVal As MyBook.ValMsg(Of Family.Contracts.Contracts) = Family.Exist(FamilyRef)

            Dim Creteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
            Creteria.ToExternalID = MyId
            Creteria.FamilyID = MotherFamilyRef.PrimaryKey
            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.IModel) = Childrens.Find(Creteria)
            Childrens.Remove(ChildVal.Model)

            Dim DTO As Family.Contracts.IRemoveMotherDTO = New Family.Contracts.Contracts
            DTO.Mother = 0
            Family.Change(FamilyRef, DTO)

            Return ExistFamily(FamilyRef)
        End Function
        Function RemoveFather(FamilyRef As Family.Ables.IReference) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Dim ChangeDTO As Family.Contracts.IRemoveFatherDTO = New Family.Contracts.Contracts
            ChangeDTO.Father = 0
            Dim ValFamily As MyBook.ValMsg = Family.Change(FamilyRef, ChangeDTO)
            If ValFamily.Success = False Then
                Val.Msg = ValFamily.Msg
                Val.Success = False
                Return Val
            End If
            Return ExistFamily(FamilyRef)
        End Function

        Function RemoveFatherWithCompleteChild(FamilyRef As Family.Ables.IReference, MotherFamilyRef As Family.Ables.IReference, MyId As Integer) As MyBook.ValMsg(Of Model)
            Dim ExistVal As MyBook.ValMsg(Of Family.Contracts.Contracts) = Family.Exist(FamilyRef)

            Dim Creteria As Children.Conctracts.ICreteria = New Children.Conctracts.Contracts
            Creteria.ToExternalID = MyId
            Creteria.FamilyID = MotherFamilyRef.PrimaryKey
            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.IModel) = Childrens.Find(Creteria)
            Childrens.Remove(ChildVal.Model)
            Dim DTO As Family.Contracts.IRemoveFatherDTO = New Family.Contracts.Contracts
            DTO.Father = 0
            Family.Change(FamilyRef, DTO)
            Return ExistFamily(FamilyRef)
        End Function
        Function RemoveSpouce(FamilyRef As Family.Ables.IReference) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Dim ChangeDTO As Family.Contracts.IRegisterHusbandDTO = New Family.Contracts.Contracts
            ChangeDTO.Spouse = 0
            Dim ValFamily As MyBook.ValMsg = Family.Change(FamilyRef, ChangeDTO)
            If ValFamily.Success = False Then
                Val.Msg = ValFamily.Msg
                Val.Success = False
                Return Val
            End If
            Return ExistFamily(FamilyRef)
        End Function

        Function RemoveSpouceWithComplete(Familyref As Family.Ables.IReference, SpouceFamilyRef As Family.Ables.IReference) As MyBook.ValMsg(Of Model)
            Dim ExistVal As MyBook.ValMsg(Of Family.Contracts.Contracts) = Family.Exist(Familyref)
            Dim DTO As Family.Contracts.IRegisterHusbandDTO = New Family.Contracts.Contracts
            DTO.Spouse = 0
            Family.Change(Familyref, DTO)
            Family.Change(SpouceFamilyRef, DTO)

            Return ExistFamily(Familyref)
        End Function
        Function RemoveChild(FamilyRef As Family.Ables.IReference, ChildRef As Children.Ables.IReference) As MyBook.ValMsg(Of Model)
            Dim Val As New MyBook.ValMsg(Of Model)
            Dim ChildVal As MyBook.ValMsg = Childrens.Remove(ChildRef)
            If ChildVal.Success = False Then
                Val.Msg = ChildVal.Msg
                Val.Success = False
                Return Val
            End If
            Return ExistFamily(FamilyRef)
        End Function
        Function RemoveChildWithCompleteMother(FamilyRef As Family.Ables.IReference, ChildRef As Children.Ables.IReference) As MyBook.ValMsg(Of Model)
            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Exist(ChildRef)
            Dim FamilyVal As MyBook.ValMsg(Of Family.Contracts.Contracts) = Family.Exist(FamilyRef)

            Childrens.Remove(ChildRef)
            Dim RemoveMother As Family.Contracts.IRegisterMotherDTO = New Family.Contracts.Contracts
            RemoveMother.Mother = 0
            Family.Change(ChildRef, RemoveMother)

            Return ExistFamily(FamilyRef)
        End Function
        Function RemoveChildWithCompleteFather(FamilyRef As Family.Ables.IReference, ChildRef As Children.Ables.IReference) As MyBook.ValMsg(Of Model)
            Dim ChildVal As MyBook.ValMsg(Of Children.Conctracts.Contracts) = Childrens.Exist(ChildRef)
            Dim FamilyVal As MyBook.ValMsg(Of Family.Contracts.Contracts) = Family.Exist(FamilyRef)

            Childrens.Remove(ChildRef)
            Dim RemoveMother As Family.Contracts.IRegisterFatherDTO = New Family.Contracts.Contracts
            RemoveMother.Father = 0
            Family.Change(ChildRef, RemoveMother)

            Return ExistFamily(FamilyRef)
        End Function
    End Class


End Namespace
