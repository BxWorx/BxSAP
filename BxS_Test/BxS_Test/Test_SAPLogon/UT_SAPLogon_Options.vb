Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports	xSAPtorExcel.Main.SAPLogon

<TestClass()> Public Class UT_SAPLogon_Options

	<TestMethod()>
	Public Sub TestMethod1()

		Dim lo_OptionsVM	As iLogonOptionsVM	= New LogonOptionsVM

		lo_OptionsVM.Show()


	End Sub

End Class