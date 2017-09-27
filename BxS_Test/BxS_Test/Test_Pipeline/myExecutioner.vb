Imports BxS.Utilities
Imports System.Threading
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Public	Class	myExecutioner
								Implements iBxS_Executioner(of imydto)

	Public Function Execute(task As imydto) As Boolean Implements iBxS_Executioner(Of imydto).Execute

		task.x	+= 1
		Thread.SpinWait(10000000)
		Return True

	End Function

End Class

Public Interface imyDTO

	Property x As Integer

End Interface


Public Class myDTO
							Implements imyDTO

	Property x As Integer Implements imyDTO.x

End Class
