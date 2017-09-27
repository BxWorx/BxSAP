
'Imports System.Collections.Concurrent
'Imports System.Linq
'Imports System.Threading.Tasks

'Namespace AsyncEventAggregator
'	Public NotInheritable Class AsyncEventHub
'		Private Const EventTypeNotFoundExceptionMessage As String = "Event type not found!"
'		Private Const SubscribersNotFoundExceptionMessage As String = "Subscribers not found!"
'		Private Const FailedToAddSubscribersExceptionMessage As String = "Failed to add subscribers!"
'		Private Const FailedToGetEventHandlerTaskFactoriesExceptionMessage As String = "Failed to get event handler task factories!"
'		Private Const FailedToAddEventHandlerTaskFactoriesExceptionMessage As String = "Failed to add event handler task factories!"
'		Private Const FailedToGetSubscribersExceptionMessage As String = "Failed to get subscribers!"
'		Private Const FailedToRemoveEventHandlerTaskFactories As String = "Failed to remove event handler task factories!"

'		Private ReadOnly _factory As TaskFactory

'		''' <summary>
'		'''     Dictionary(EventType, Dictionary(Sender, EventHandlerTaskFactories))
'		''' </summary>
'		Private ReadOnly _hub As ConcurrentDictionary(Of Type, ConcurrentDictionary(Of Object, ConcurrentBag(Of Object)))

'		Public Sub New()
'			_factory = Task.Factory

'			_hub = New ConcurrentDictionary(Of Type, ConcurrentDictionary(Of Object, ConcurrentBag(Of Object)))()
'		End Sub

'		Public Function Publish(Of TEvent)(sender As Object, eventDataTask As Task(Of TEvent)) As Task(Of Task())
'			Dim taskCompletionSource = New TaskCompletionSource(Of Task())()

'			_factory.StartNew(Function() 
'			Dim eventType As Type = GetType(TEvent)

'			If _hub.ContainsKey(eventType) Then
'				Dim subscribers As ConcurrentDictionary(Of Object, ConcurrentBag(Of Object))

'				If _hub.TryGetValue(eventType, subscribers) Then
'					If subscribers.Count > 0 Then



'						_factory.ContinueWhenAll(New ConcurrentBag(Of Task)(New ConcurrentBag(Of Object)(subscribers.Keys).Where(Function(p) p <> sender AndAlso subscribers.ContainsKey(p)).[Select](Function(p) 
'						Dim eventHandlerTaskFactories As ConcurrentBag(Of Object)
'						Dim isFailed As Boolean = Not subscribers.TryGetValue(p, eventHandlerTaskFactories)
'						Return New With { _
'							Key .IsFailed = isFailed, _
'							Key .EventHandlerTaskFactories = eventHandlerTaskFactories _
'						}

'End Function).SelectMany(Function(p) 
'						If p.IsFailed Then
'							Dim innerTaskCompletionSource = New TaskCompletionSource(Of Task)()
'							innerTaskCompletionSource.SetException(New Exception(FailedToGetEventHandlerTaskFactoriesExceptionMessage))
'							Return New ConcurrentBag(Of Task)(New () {innerTaskCompletionSource.Task})
'						End If
'						Return New ConcurrentBag(Of Task)(p.EventHandlerTaskFactories.[Select](Function(q) 
'						Try
'							Return DirectCast(q, Func(Of Task(Of TEvent), Task))(eventDataTask)
'						Catch ex As Exception
'							Return _factory.FromException(Of Object)(ex)
'						End Try

'End Function))

'End Function)).ToArray(), taskCompletionSource.SetResult)
'					Else
'						taskCompletionSource.SetException(New Exception(SubscribersNotFoundExceptionMessage))
'					End If
'				Else
'					taskCompletionSource.SetException(New Exception(SubscribersNotFoundExceptionMessage))
'				End If
'			Else
'				taskCompletionSource.SetException(New Exception(EventTypeNotFoundExceptionMessage))
'			End If

'End Function)

'			Return taskCompletionSource.Task
'		End Function

'		Public Function Subscribe(Of TEvent)(sender As Object, eventHandlerTaskFactory As Func(Of Task(Of TEvent), Task)) As Task
'			Dim taskCompletionSource = New TaskCompletionSource(Of Object)()

'			_factory.StartNew(Function() 
'			Dim subscribers As ConcurrentDictionary(Of Object, ConcurrentBag(Of Object))
'			Dim eventHandlerTaskFactories As ConcurrentBag(Of Object)

'			Dim eventType As Type = GetType(TEvent)

'			If _hub.ContainsKey(eventType) Then
'				If _hub.TryGetValue(eventType, subscribers) Then
'					If subscribers.ContainsKey(sender) Then
'						If subscribers.TryGetValue(sender, eventHandlerTaskFactories) Then
'							eventHandlerTaskFactories.Add(eventHandlerTaskFactory)
'							taskCompletionSource.SetResult(Nothing)
'						Else
'							taskCompletionSource.SetException(New Exception(FailedToGetEventHandlerTaskFactoriesExceptionMessage))
'						End If
'					Else
'						eventHandlerTaskFactories = New ConcurrentBag(Of Object)()

'						If subscribers.TryAdd(sender, eventHandlerTaskFactories) Then
'							eventHandlerTaskFactories.Add(eventHandlerTaskFactory)
'							taskCompletionSource.SetResult(Nothing)
'						Else
'							taskCompletionSource.SetException(New Exception(FailedToAddEventHandlerTaskFactoriesExceptionMessage))
'						End If
'					End If
'				Else
'					taskCompletionSource.SetException(New Exception(FailedToGetSubscribersExceptionMessage))
'				End If
'			Else
'				subscribers = New ConcurrentDictionary(Of Object, ConcurrentBag(Of Object))()

'				If _hub.TryAdd(eventType, subscribers) Then
'					eventHandlerTaskFactories = New ConcurrentBag(Of Object)()

'					If subscribers.TryAdd(sender, eventHandlerTaskFactories) Then
'						eventHandlerTaskFactories.Add(eventHandlerTaskFactory)
'						taskCompletionSource.SetResult(Nothing)
'					Else
'						taskCompletionSource.SetException(New Exception(FailedToAddEventHandlerTaskFactoriesExceptionMessage))
'					End If
'				Else
'					taskCompletionSource.SetException(New Exception(FailedToAddSubscribersExceptionMessage))
'				End If
'			End If

'End Function)

'			Return taskCompletionSource.Task
'		End Function

'		Public Function Unsubscribe(Of TEvent)(sender As Object) As Task
'			Dim taskCompletionSource = New TaskCompletionSource(Of Object)()

'			_factory.StartNew(Function() 
'			Dim eventType As Type = GetType(TEvent)

'			If _hub.ContainsKey(eventType) Then
'				Dim subscribers As ConcurrentDictionary(Of Object, ConcurrentBag(Of Object))

'				If _hub.TryGetValue(eventType, subscribers) Then
'					If subscribers Is Nothing Then
'						taskCompletionSource.SetException(New Exception(FailedToGetSubscribersExceptionMessage))
'					Else
'						If subscribers.ContainsKey(sender) Then
'							Dim eventHandlerTaskFactories As ConcurrentBag(Of Object)

'							If subscribers.TryRemove(sender, eventHandlerTaskFactories) Then
'								taskCompletionSource.SetResult(Nothing)
'							Else
'								taskCompletionSource.SetException(New Exception(FailedToRemoveEventHandlerTaskFactories))
'							End If
'						Else
'							taskCompletionSource.SetException(New Exception(FailedToGetEventHandlerTaskFactoriesExceptionMessage))
'						End If
'					End If
'				Else
'					taskCompletionSource.SetException(New Exception(FailedToGetSubscribersExceptionMessage))
'				End If
'			Else
'				taskCompletionSource.SetException(New Exception(EventTypeNotFoundExceptionMessage))
'			End If

'End Function)

'			Return taskCompletionSource.Task
'		End Function
'	End Class
'End Namespace

''=======================================================
''Service provided by Telerik (www.telerik.com)
''Conversion powered by NRefactory.
''Twitter: @telerik
''Facebook: facebook.com/telerik
''=======================================================
