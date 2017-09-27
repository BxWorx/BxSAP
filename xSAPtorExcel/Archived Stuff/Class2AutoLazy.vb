
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Threading

<ComVisible(False)> _
<HostProtection(Action		:=	SecurityAction.LinkDemand,
								Resources	:=	HostProtectionResource.Synchronization Or HostProtectionResource.SharedState)> _
Public Class Auto(Of T As Class)

	Private _syncRoot									As Object
	Private _value										As T

	Public Sub New(					_initializationFunction As Func(Of T),
								 Optional safetyMode								As LazyThreadSafetyMode = LazyThreadSafetyMode.ExecutionAndPublication)

		_syncRoot								= New Object()

		ThreadSafety						= safetyMode
		InitializationFunction	= _initializationFunction

	End Sub

	'...........................................................
	Private m_InitializationFunction	As Func(Of T)
	Private m_ThreadSafety						As LazyThreadSafetyMode

	Protected Property ThreadSafety() As LazyThreadSafetyMode
		Get
			Return m_ThreadSafety
		End Get
		Private Set
			m_ThreadSafety = Value
		End Set
	End Property
	Protected Property InitializationFunction() As Func(Of T)
		Get
			Return m_InitializationFunction
		End Get
		Private Set
			m_InitializationFunction = Value
		End Set
	End Property
	'...........................................................


	Public ReadOnly Property Value() As T
		Get
			If _value Is Nothing Then

				If ThreadSafety = LazyThreadSafetyMode.PublicationOnly Then
					Dim value__1 = InitializationFunction().Invoke
					SyncLock _syncRoot
						If _value Is Nothing Then
							_value = value__1
						End If
					End SyncLock
				ElseIf ThreadSafety = LazyThreadSafetyMode.ExecutionAndPublication Then
					SyncLock _syncRoot
						If _value Is Nothing Then
							_value = m_InitializationFunction()
						End If
					End SyncLock
				Else
					_value = m_InitializationFunction()
				End If
			End If

			Return _value

		End Get
	End Property




	'...........................................................
	Public ReadOnly Property IsValueCreated() As Boolean
		Get
			Return	(_value IsNot Nothing)
		End Get
	End Property
	'...........................................................
	Public Sub ResetValue()

		If ThreadSafety <> LazyThreadSafetyMode.None Then
			SyncLock _syncRoot
				_value = Nothing
			End SyncLock
		Else
			_value = Nothing
		End If

	End Sub

End Class
'...........................................................
Public NotInheritable Class Auto
	Private Sub New()
	End Sub
	Public Shared Function Create(Of T As Class)(					initializationFunction	As Func(Of T),
																							 Optional safetyMode							As LazyThreadSafetyMode = LazyThreadSafetyMode.ExecutionAndPublication) As Auto(Of T)

		Return New Auto(Of T)(initializationFunction, safetyMode)

	End Function

End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
