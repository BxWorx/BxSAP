Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.Session


	Friend Class ixPCManager

		Private co_bc As BlockingCollection(Of iSessionCreateRequest)




		Friend Sub CloseForAdding()
			Me.co_BC.CompleteAdding()
		End Sub







		Friend Shared Function Create()	As ixPCManager
			Return New ixPCManager()
		End Function

		Private Sub New()
			Me.co_bc = New BlockingCollection(Of iSessionCreateRequest)
		End Sub

	End Class

















	Friend Class ixProducer(Of T)

		Private co_BC As BlockingCollection(Of T)


		Friend Sub Post(ByVal i_List As List(Of iSessionCreateRequest) )

			For Each lo_Req As iSessionCreateRequest In i_List

				Dim lo_Req1	As iSessionCreateRequest	= New SessionCreateRequest

				lo_Req1.QID					= lo_Req.QID
				lo_Req1.SessionName	= lo_Req.SessionName

				Me.co_BC.Add(CType(lo_Req1, T))

			Next

		End Sub

		Friend Shared Function Create(ByVal bc As BlockingCollection(Of T))	As ixProducer(Of T)
			Return New ixProducer(Of T)(bc:=bc)
		End Function

		Private Sub New(ByVal bc As BlockingCollection(Of T))
			Me.co_BC	= bc
		End Sub

	End Class



	Friend Class ixConsumer(Of T)

		Private co_BC As BlockingCollection(Of T)

		Friend Sub Start()

			For Each item As T In co_BC.GetConsumingEnumerable()

			Next

		End Sub




		Friend Shared Function Create(ByVal bc As BlockingCollection(Of T))	As ixConsumer(Of T)
			Return New ixConsumer(Of T)(bc:=bc)
		End Function

		Private Sub New(ByVal bc As BlockingCollection(Of T))
			Me.co_BC	= bc
		End Sub

	End Class




'	Shared coll As New BlockingCollection(Of String)()

'Private Shared Sub Consume()
'	For Each i As var In coll.GetConsumingEnumerable()
'		Console.WriteLine([String].Format("Thread {0} Consuming: {1}", Thread.CurrentThread.ManagedThreadId, i))
'		Thread.Sleep(1000)
'	Next
'End Sub

'Private Shared Sub Main(args As String())
'	Dim item As Integer = 0

'	Task.Factory.StartNew(Function() 
'	While True
'		coll.Add(String.Format("Item {0}", System.Math.Max(System.Threading.Interlocked.Increment(item),item - 1)))
'		Thread.Sleep(500)
'	End While

'End Function)

'	For i As Integer = 0 To 1
'		Task.Factory.StartNew(Function() Consume())
'	Next

'	While True
		

'	End While
'End Sub






'	Public Class WorkQueue
'	Private _workQueue As BlockingCollection(Of WorkTask)

'	Public Sub New(workTaskCollection As IProducerConsumerCollection(Of WorkTask))
'		_workQueue = New BlockingCollection(Of WorkTask)(workTaskCollection)
'	End Sub

'	Public Sub AddTask(workTask As WorkTask)
'		_workQueue.Add(workTask)
'	End Sub

'	Public Sub AllItemsAdded()
'		_workQueue.CompleteAdding()
'	End Sub

'	Public Sub MonitorWorkQueue()
'		While True
'			Try
'				Dim wt As WorkTask = _workQueue.Take()
'				Debug.WriteLine(String.Format("Thread {0} processing work task {1}, entered on {2}", Thread.CurrentThread.ManagedThreadId, wt.Description, wt.InsertedUtc))
'			Catch e As InvalidOperationException
'				Debug.WriteLine(String.Format("Work queue on thread {0} has been closed.", Thread.CurrentThread.ManagedThreadId))
'				Exit Try
'			End Try
'		End While
'	End Sub
'End Class







Public Class Subscriber(Of T)
	Private Property UnSubscribeAction() As Action(Of Subscriber(Of T))
		Get
			Return m_UnSubscribeAction
		End Get
		Set
			m_UnSubscribeAction = Value
		End Set
	End Property
	Private m_UnSubscribeAction As Action(Of Subscriber(Of T))

	Public Property OnNext() As Action(Of T)
		Get
			Return m_OnNext
		End Get
		Private Set
			m_OnNext = Value
		End Set
	End Property
	Private m_OnNext As Action(Of T)

	Public Sub UnSubscribe()
		UnSubscribeAction().Invoke(Me)
	End Sub

	Public Sub New(unsubscribe	As Action(Of Subscriber(Of T)),
								 onNext__1		As Action(Of T))

		UnSubscribeAction = unsubscribe
		OnNext						= onNext__1

	End Sub

End Class


Public Class SPMC(Of T)
							Implements IDisposable

	Private _lock								As New Object()
	Private _consumers					As New ConcurrentQueue(Of Subscriber(Of T))()
	Private _blockingCollection As BlockingCollection(Of T)

	Public Sub New(Optional boundedSize As Integer = Integer.MaxValue)
		_blockingCollection = New BlockingCollection(Of T)(boundedSize)
	End Sub


	Public Function Subscribe(onNext As Action(Of T)) As Subscriber(Of T)

'		SyncLock _lock

'			Dim removalAction As Action(Of Subscriber(Of T)) = Function(instance As) 
'			SyncLock _lock
'				_consumers.Remove(instance)
'			End SyncLock

'End Function

			Dim removalAction As Action(Of Subscriber(Of T))

			Dim subscriber = New Subscriber(Of T)(removalAction, onNext)

			_consumers.Enqueue(subscriber)

			Return subscriber
		'End SyncLock
	End Function

	Public Sub Start()

		Dim nt = New Thread(Sub()
													For Each item As T In _blockingCollection.GetConsumingEnumerable()
														'SyncLock _lock
														'	Parallel.ForEach(_consumers, Function(consumer) consumer.OnNext(item))
														'End SyncLock
													Next
		                    End Sub)

		nt.Start


		'Dim nt = New Thread(AddressOf Me.Process)
			'Function() 
			'	For Each item As T In _blockingCollection.GetConsumingEnumerable()
			'		SyncLock _lock
			'			Parallel.ForEach(_consumers, Function(consumer) consumer.OnNext(item))
			'		End SyncLock
			'	Next
			'End Function).Start

	End Sub


	Private Sub Process()

		'For Each item As T In _blockingCollection.GetConsumingEnumerable()
		'	SyncLock _lock
		'		Parallel.ForEach(_consumers, Function(consumer) consumer.OnNext(item))
		'	End SyncLock
		'Next

	End Sub




	Public Sub FinishedAdding()
		_blockingCollection.CompleteAdding()
	End Sub

	Public Sub Publish(item As T)
		_blockingCollection.Add(item)
	End Sub



		#Region "IDisposable implementation"

			Public Sub Dispose()  Implements IDisposable.Dispose
				FinishedAdding()
			End Sub

		#End Region

	End Class

End Namespace