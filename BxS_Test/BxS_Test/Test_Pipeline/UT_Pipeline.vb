Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BxS.Utilities
Imports System.Threading
Imports System.Collections.Concurrent

<TestClass()>
	Public Class UT_Pipeline

	<TestMethod()>
		Public Function TestMethod1() As Task			'Async 

			'Dim lo_PHn	As Action(Of Integer)					=	AddressOf Me.handlerprogress
			'Dim	lo_Prg	As IProgress(Of Integer)			= New Progress(Of Integer)(lo_PHn)
			'Dim lo_CTS	As CancellationTokenSource		= New CancellationTokenSource
			'Dim lo_Con	As ConsumerMaker(Of imyDTO)	= AddressOf	consmaker
			'Dim lo_PLn	As iBxS_PipeLine(Of imyDTO)		= New BxS_PipeLine(Of imyDTO)( lo_Con, lo_Prg  )

			'Dim ln_Cnt	As Integer	= 100

			'For ln_Loop = 1 To ln_Cnt

			'	Dim lo_DTO As imyDTO	= New myDTO

			'	lo_DTO.x	= 1

			'	'lo_PLn.Post(lo_DTO)

			'Next

			'lo_PLn.NoOfConsumers	= 5
			'lo_PLn.ProducingCompleted()

			''Dim x = Await lo_PLn.StartConsumers()

			''Dim y As Integer

			''For Each lo In lo_PLn.Completed
			''	y += lo.x - 1
			''Next
			''For Each lo In lo_PLn.InError
			''Next
			''For Each lo In lo_PLn.NotStarted
			''Next

			''Assert.AreEqual(ln_Cnt,x)

			Return Nothing

		End Function


		Private Function consmaker(	ByVal queue				As BlockingCollection(Of imyDTO)	,
																ByVal progress		As IProgress(Of Integer)					,
																ByVal cancelToken	As CancellationToken								)	As iBxS_Consumer(Of imyDTO)

			Dim lo_Exe	As iBxS_Executioner(of imyDTO)	= New myExecutioner
			Dim lo_cons	As iBxS_Consumer(Of imyDTO)			= New BxS_Consumer(Of imyDTO)(queue,progress,cancelToken,lo_Exe) 

			Return	lo_cons

		End Function

		Private Sub handlerprogress(byval x As Integer)
			Dim xx = x
		End Sub

	End Class
