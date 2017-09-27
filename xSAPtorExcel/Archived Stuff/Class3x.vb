Imports System.Reflection
Imports	System.Collections

'Does used by EventAggregator to reserve subscription
Public	Class	Subscription(Of Tmessage)
							Implements IDisposable

	Public	ReadOnly	MethodInfo			As MethodInfo
	Private ReadOnly	EventAggregator As EventAggregator
	Public	ReadOnly	TargetObjet			As WeakReference
	Public	ReadOnly	IsStatic				As Boolean

	Private isDisposed As Boolean
	Public Sub New(action As Action(Of Tmessage), eventAggregator__1 As EventAggregator)
		MethodInfo = action.Method
		If action.Target Is Nothing Then
			IsStatic = True
		End If
		TargetObjet = New WeakReference(action.Target)
		EventAggregator = eventAggregator__1
	End Sub

	Protected Overrides Sub Finalize()
		Try
			If Not isDisposed Then
				Dispose()
			End If
		Finally
			MyBase.Finalize()
		End Try
	End Sub

	Public Sub Dispose() Implements IDisposable.Dispose
		EventAggregator.UnSbscribe(Me)
		isDisposed = True
	End Sub

	Public Function CreatAction() As Action(Of Tmessage)
		If TargetObjet.Target IsNot Nothing AndAlso TargetObjet.IsAlive Then
			Return DirectCast([Delegate].CreateDelegate(GetType(Action(Of Tmessage)), TargetObjet.Target, MethodInfo), Action(Of Tmessage))
		End If
		If Me.IsStatic Then
			Return DirectCast([Delegate].CreateDelegate(GetType(Action(Of Tmessage)), MethodInfo), Action(Of Tmessage))
		End If

		Return Nothing
	End Function

End Class





Public Class EventAggregator
	Private ReadOnly lockObj As New Object()
	Private subscriber As Dictionary(Of Type, IList)

	Public Sub New()
		subscriber = New Dictionary(Of Type, IList)()
	End Sub

	Public Sub Publish(Of TMessageType)(message As TMessageType)
		Dim t As Type = GetType(TMessageType)
		Dim sublst As IList
		If subscriber.ContainsKey(t) Then
			SyncLock lockObj
				sublst = New List(Of Subscription(Of TMessageType))(subscriber(t).Cast(Of Subscription(Of TMessageType))())
			End SyncLock

			For Each lo As Subscription(Of TMessageType) In sublst
				Dim ev_action = lo.CreatAction()
				If ev_action IsNot Nothing	Then	ev_action(message)
			Next
		End If
	End Sub

	Public Function Subscribe(Of TMessageType)(action As Action(Of TMessageType)) As Subscription(Of TMessageType)
		Dim t As Type = GetType(TMessageType)
		Dim actionlst As IList
		Dim actiondetail = New Subscription(Of TMessageType)(action, Me)

		SyncLock lockObj
			If Not subscriber.TryGetValue(t, actionlst) Then
				actionlst = New List(Of Subscription(Of TMessageType))()
				actionlst.Add(actiondetail)
				subscriber.Add(t, actionlst)
			Else
				actionlst.Add(actiondetail)
			End If
		End SyncLock

		Return actiondetail
	End Function

	Public Sub UnSbscribe(Of TMessageType)(subscription As Subscription(Of TMessageType))
		Dim t As Type = GetType(TMessageType)
		If subscriber.ContainsKey(t) Then
			SyncLock lockObj
				subscriber(t).Remove(subscription)
			End SyncLock
			subscription = Nothing
		End If
	End Sub

End Class



Public Class Publisher
	Private EventAggregator As EventAggregator
	Public Sub New(eventAggregator__1 As EventAggregator)
		EventAggregator = eventAggregator__1
	End Sub

	Public Sub PublishMessage()
		EventAggregator.Publish(New Mymessage())
		EventAggregator.Publish(10)
	End Sub
End Class



Public Class Subscriber
	Private myMessageToken As Subscription(Of Mymessage)
	Private intToken As Subscription(Of Integer)
	Private eventAggregator As EventAggregator

	Public Sub New(eve As EventAggregator)
		eventAggregator = eve
		eve.Subscribe(Of Mymessage)(AddressOf Me.Test)
		eve.Subscribe(Of Integer)(AddressOf Me.IntTest)
	End Sub

	Private Sub IntTest(obj As Integer)
		Console.WriteLine(obj)
		eventAggregator.UnSbscribe(intToken)
	End Sub

	Private Sub Test(test__1 As Mymessage)
		Console.WriteLine(test__1.ToString())
		eventAggregator.UnSbscribe(myMessageToken)
	End Sub
End Class

Public	Class mymessage

End Class




'Private Shared Sub Main(args As String())
'	Dim eve As New EventAggregator()
'	Dim pub As New Publisher(eve)
'	Dim [sub] As New Subscriber(eve)

'	pub.PublishMessage()

'	Console.ReadLine()

'End Sub