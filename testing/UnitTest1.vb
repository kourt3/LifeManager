Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1
    Public EconomyController As New Economy.Controller.Controller
    <TestMethod()> Public Sub TestMethod1()
        Dim RegisterPortofolio As Economy.Portofolio.Contracts.IRegisterDTO = New Economy.Portofolio.Contracts.Contract
        With RegisterPortofolio
            .Name = "Kourt"
            .Description = "malakia"
        End With

        Dim EconomyVal As MyBook.ValMsg(Of Economy.Controller.IModel) = EconomyController.AddPortofolio(1, RegisterPortofolio)

        'Dim Creteria As Economy.EconomyProject.Contracts.ICreteria = New Economy.EconomyProject.Contracts.Contact
        'Creteria.ExternalID = 1
        'Dim ValEconomyServiceProject As MyBook.ValMsg(Of List(Of Economy.EconomyProject.Contracts.IModel)) = EconomyController.EconomyService.Search(Creteria)


        Console.WriteLine(EconomyController.EconomyService.Repository.Read_All.Count)
        Console.WriteLine(EconomyController.EconomyService.Repository.Read_ItemAt(0).ExternalID)
        ' Console.WriteLine(ValEconomyServiceProject.Model(0).ExternalID & " " & ValEconomyServiceProject.Model(0).ToExternalID & " " & ValEconomyServiceProject.Model(0).Category)

    End Sub


End Class