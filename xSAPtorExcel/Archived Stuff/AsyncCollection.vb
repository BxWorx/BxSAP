Imports System.Collections.Concurrent
Imports System.Threading.Tasks




Public NotInheritable Class AsyncCollection(Of T)

	' The underlying collection of items.
	Private ReadOnly collection As IProducerConsumerCollection(Of T)

	' The maximum number of items allowed.
	Private ReadOnly maxCount As Integer

	' Synchronization primitives.
	Private ReadOnly mutex As AsyncLock
	Private ReadOnly notFull As AsyncConditionVariable
	Private ReadOnly notEmpty As AsyncConditionVariable

	Public Sub New(Optional collection As IProducerConsumerCollection(Of T) = Nothing, Optional maxCount As Integer = Integer.MaxValue)
		If maxCount <= 0 Then
			Throw New ArgumentOutOfRangeException("maxCount", "The maximum count must be greater than zero.")
		End If
		Me.collection = If(collection, New ConcurrentQueue(Of T)())
		Me.maxCount = maxCount

		mutex			= New AsyncLock()
		notFull		= New AsyncConditionVariable(mutex)
		notEmpty	= New AsyncConditionVariable(mutex)

	End Sub

	' Convenience properties to make the code a bit clearer.
	Private ReadOnly Property Empty() As Boolean
		Get
			Return collection.Count = 0
		End Get
	End Property
	Private ReadOnly Property Full() As Boolean
		Get
			Return collection.Count = maxCount
		End Get
	End Property

	Public Async Function AddAsync(item As T) As Task
		Using Await mutex.LockAsync()
			While Full
				Await notFull.WaitAsync()
			End While

			If Not collection.TryAdd(item) Then
				Throw New InvalidOperationException("The underlying collection refused the item.")
			End If
			notEmpty.NotifyOne()
		End Using
	End Function

	Public Async Function TakeAsync() As Task(Of T)
		Using Await mutex.LockAsync()
			While Empty
				Await notEmpty.WaitAsync()
			End While

			Dim ret As T
			If Not collection.TryTake(ret) Then
				Throw New InvalidOperationException("The underlying collection refused to provide an item.")
			End If
			notFull.NotifyOne()
			Return ret
		End Using
	End Function
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
