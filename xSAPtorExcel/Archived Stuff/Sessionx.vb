'Imports xSAPtorExcel.Main.Session
'Imports System.Threading.Tasks
'Public Class Sessionx


'		'Private Delegate Function GetProfileDel(ByVal i_Request As iSessionCreateRequest) As Task(Of iSessionProfile)
'		Private Delegate Function GetProfileDel(ByVal i_Request As iSessionCreateRequest) As Task(Of iSessionProfile)

'		Public Function x As Boolean

'			Dim lo_AsyncCall  As Func(Of iSessionCreateRequest, Task(Of iSessionProfile) ) = AddressOf GetProfile




'			Dim lo_Task As GetProfileDel                        = New GetProfileDel(AddressOf GetProfile)
'			Dim lo_Call As AsyncCall(Of iSessionCreateRequest)  = New AsyncCall(Of iSessionCreateRequest)(lo_AsyncCall)
		
'			Dim lo_Req As iSessionCreateRequest = New SessionCreateRequest()


'			For ln As Integer = 1 To 5

'				lo_Req.QID = ln.ToString

'				lo_Call.Post(lo_Req)

				


'			Next



'		End Function


'		Private Async Function GetProfile(ByVal i_Request As iSessionCreateRequest) As Task(Of iSessionProfile)

'			Dim lo_Profile As iSessionProfile = New SessionProfile()

'			Return lo_Profile


'			'Dim lo_profile As Task(Of iSessionProfile)  = New Task(Of iSessionProfile)(Function()

'			'                                                                           End Function)

'			'Return lo_profile

'		End Function

'		Private la As List(Of Integer) = New List(Of Integer) From {}

'		Function xxxx() As Boolean


'			Dim lo_Call As AsyncCall(Of Integer)  = AsyncCall.Create(Of Integer)(Sub(i)
'																																						DoWork(i)
'																																					 End Sub)

'		 lo_Call.Post(1)
'			lo_Call.Post(2)

'			Return True

'		End Function


'		Function DoWork(ByVal i As Integer) As Integer

'			la.Add(i)

'		End Function





'Public Async Function ConsumerReceivesCorrectValues() As Task

'	Dim results1 = New List(Of Integer)()
'	Dim results2 = New List(Of Integer)()
'	Dim results3 = New List(Of Integer)()

'	' Define the mesh.
'	Dim queue           = New BufferBlock(Of Integer)(New DataflowBlockOptions() With { .BoundedCapacity = 5 })
'	Dim consumerOptions = New ExecutionDataflowBlockOptions() With { .BoundedCapacity = 1 }
'	Dim consumer1       = New ActionBlock(Of Integer)(Function(x) results1.Add(x), consumerOptions)
'	Dim consumer2       = New ActionBlock(Of Integer)(Function(x) results2.Add(x), consumerOptions)
'	Dim consumer3       = New ActionBlock(Of Integer)(Function(x) results3.Add(x), consumerOptions)
'	Dim linkOptions     = New DataflowLinkOptions() With { .PropagateCompletion = True }

'	queue.LinkTo(consumer1, linkOptions)
'	queue.LinkTo(consumer2, linkOptions)
'	queue.LinkTo(consumer3, linkOptions)

'	' Start the producers.
'	Dim producers = ProduceAll(queue)

'	' Wait for everything to complete.
'	Await Task.WhenAll(producers, consumer1.Completion, consumer2.Completion, consumer3.Completion)

'	' Ensure the consumer got what the producer sent.
'	Dim results = results1.Concat(results2).Concat(results3)
'	Assert.IsTrue(results.OrderBy(Function(x) x).SequenceEqual(Enumerable.Range(0, 30)))
'End Function


'Public Function SendMessage(message As String, Optional secondsToWait As Integer = 1) As Task(Of String)

'	Dim task__1 As Task(Of String) = Task.Factory.StartNew(Of String)(Function() 

'	Dim msg = message


'	If String.IsNullOrEmpty(message) Then
'		msg = _defaultMessage
'	End If

'	Dim inTime = DateTime.Now

'	Thread.Sleep(secondsToWait * 1000)

'	Dim rtn = String.Format("I am sending this Message:{0} from within the Tasks, Time in: {1}, Time out: {2}", msg, inTime.ToString(_fmt), DateTime.Now.ToString(_fmt))
'	Console.WriteLine(rtn)
'		'return the string as the TResult


'	Return rtn

'End Function)
'	Return task__1

'End Function





'		Public Function SendMessageEx(					message As String,
'																	Optional	secondsToWait As Integer = 1) As Task(Of MessengerResult)

'			Dim task__1 As Task(Of MessengerResult) = Task.Factory.StartNew(Of MessengerResult)(
'				Function() 
'					Dim msg = message
'					If String.IsNullOrEmpty(message) Then	msg = _defaultMessage
'					Dim inTime = DateTime.Now
'					' put in some time-consuming behavior
'					Thread.Sleep(secondsToWait * 1000)
'					Dim outTime = DateTime.Now
'					Dim rtn = String.Format(msg)
'					Return New MessengerResult() With {	.Message = msg, _
'																							.ReceivedTime = inTime, _
'																							.SendTime = outTime }

'				End Function)

'			Return task__1

'		End Function

'End Class

'Public Class messengerresult


'End Class