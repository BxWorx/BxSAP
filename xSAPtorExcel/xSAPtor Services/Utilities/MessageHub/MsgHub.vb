Imports System.Collections
Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities.MsgHub
	Friend Class MsgHub
								Implements	iMsgHub

		#Region "Definitions"

			Private	ct_Subscribers	As	ConcurrentDictionary(Of String, IList)
			Private co_LckObj				As	Object

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Properties"
		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Exposed"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	CreateSubscription(Of T)(ByVal	_action	As Action(Of T))	_
													As	iSubscription(Of T)	_
														Implements	iMsgHub.CreateSubscription

				Return	New Subscription(Of T)(_action)

			End Function

			Private cacheLock As New ReaderWriterLockSlim()
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend Async Sub Publish(Of T)(_msg As T)	_
												Implements	iMsgHub.Publish

				Dim	lo_Type	As String	= GetType(T).Name

				If Me.ct_Subscribers.ContainsKey(lo_Type)

					Dim	lt_Subs	As IList(Of iSubscription(Of T))	= New List(Of iSubscription(Of T))

					SyncLock Me.co_LckObj
						lt_Subs	= New List(Of iSubscription(Of T))(Me.ct_Subscribers(lo_Type).Cast(Of iSubscription(Of T)))
					End SyncLock

					Await Me.PublishForSubscriberList(lt_Subs, _msg)

				End If

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Subscribe(Of T)(					ByVal	_action					As	Action(Of T)	, 
																				Optional	ByVal	_noduplicates		As	Boolean	= True	) _
													As iSubscription(Of T)	_
														Implements	iMsgHub.Subscribe

				Dim lo_Subs	= Me.CreateSubscription(_action)
				'..................................................
				If Not Me.SubscribeSubscription(lo_Subs, _noduplicates)
					lo_Subs	=	Nothing
				End If
				'..................................................
				Return	lo_Subs

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Function	Unsubscribe(Of T)(ByVal	_subscription	As iSubscription(Of T)) As Boolean _
													Implements	iMsgHub.Unsubscribe

				Dim	lb_Ret	As Boolean	= False
				'..................................................
				If IsNothing(_subscription)

				Else

					SyncLock	Me.co_LckObj

						Dim	lt_List	As IList	= Nothing

						If Me.ct_Subscribers.TryGetValue(_subscription.MyTypeID, lt_List)

							For Each lo_Obj In lt_List

								Dim	lo_Sub	As iSubscription(Of T)	= DirectCast(lo_Obj, iSubscription(Of T))

								If lo_Sub	IsNot	Nothing
									If lo_Sub.ID = _subscription.ID
										lt_List.Remove(lo_Obj)
										lb_Ret	= True
										Exit	For
									End If
								End If

							Next

						End If

					End	SyncLock

				End If
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub	UnsubscribeAll()	_
										Implements	iMsgHub.UnsubscribeAll

				Me.ct_Subscribers.Clear()

			End Sub

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private	Function SubscribeSubscription(Of T)(						ByVal	_subscription	As	iSubscription(Of T)	, 
																										Optional	ByVal	_noduplicates	As	Boolean	= True		) As Boolean

				Dim	lb_Ret	As Boolean	= True
				'..................................................
				SyncLock	Me.co_LckObj

					Dim	lt_List	As IList	= Nothing

					If Not Me.ct_Subscribers.TryGetValue(_subscription.MyTypeID, lt_List)

						Dim	lt_Subs	As IList(Of iSubscription(Of T))	=	New	List(Of iSubscription(Of T))
						lt_Subs.Add(_subscription)
						Me.ct_Subscribers.TryAdd(_subscription.MyTypeID, lt_Subs.ToList())
					
					Else

						If _noduplicates

							For Each lo_Obj In lt_List

								Dim	lo_Sub	As iSubscription(Of T)	= DirectCast(lo_Obj, iSubscription(Of T))

								If lo_Sub	IsNot	Nothing
									If lo_Sub.ID = _subscription.ID
										lb_Ret	= False
										Exit	For
									End If
								End If

							Next

						End If

						If lb_Ret	Then	lt_List.Add(_subscription)

					End If

				End SyncLock
				'..................................................
				Return	lb_Ret

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Async Function PublishForSubscriberList(Of T)(ByVal _sublist	As IList(Of iSubscription(Of T)) ,
																														ByVal _msg			As T) As Task

				Await Task.Factory.StartNew(
					Sub()
						For Each lo_Sub	In _sublist
							If lo_Sub	IsNot	Nothing	Then	lo_Sub.Invoke(_msg)
						Next
					End Sub,
					TaskCreationOptions.PreferFairness )

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructor"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Friend	Sub New()

				Me.ct_Subscribers	=	New	ConcurrentDictionary(Of String, IList)()
				Me.co_LckObj			=	New	Object

			End Sub

		#End Region

	End Class

End Namespace



				'Me.ct_Queue				= New ConcurrentQueue(Of Object)
					'Private	ct_Queue				As	ConcurrentQueue(Of Object)
					'Private	cb_Busy					As	Boolean

				'Me.ct_Queue.Enqueue(_msg)
				'..................................................

								'Dim	lo_Typex		As	Type	= GetType(T)

							'Dim lo_Cmd		As Object	= Nothing
							'Dim	lo_Type		As Type	= lo_Cmd.GetType()
							'Dim	lt_Subs		As IList(Of iSubscription(Of  ))			

							'lt_Subs	= New List(Of iSubscription(Of lo_Type))(Me.ct_Subscribers(lo_Type).Cast(Of iSubscription(Of T)))


								'Dim genericClass As Type = GetType(Subscription(Of))
								'Dim xy As Type = genericClass.MakeGenericType(lo_Typex)

								'Dim cc = Activator.CreateInstance(xy)
								'Dim lt = DirectCast(Me.ct_Subscribers(lo_Typex.Name), xy )

								'Dim lt = Me.ct_Subscribers(lo_Typex.Name)

				'Dim lst As IList = DirectCast(Activator.CreateInstance((GetType(List(Of )).MakeGenericType(lo_Typex))), IList)
				'Dim lst As IList = DirectCast(Activator.CreateInstance((GetType(Subscription(Of )).MakeGenericType(lo_Typex))), IList)
								'Dim 	lt_Subs	= New List(Of iSubscription(Of T))(Me.ct_Subscribers(lo_Typex.Name).Cast(Of iSubscription(Of T)))
				'				Dim y = 1


				'Await Task.Factory.StartNew(
				'	Sub	()

				'		If Not Me.cacheLock.TryEnterUpgradeableReadLock(0)	Then Exit Sub
				'		If Not Me.cacheLock.TryEnterWriteLock(0)						Then Exit Sub

				'		Dim lo_Cmd	As Object	= Nothing

				'		Do

				'			If Me.ct_Queue.TryDequeue(lo_Cmd)

				'				Dim	lo_Type	As Type	= lo_Cmd.GetType()
				'				Dim x As T	= DirectCast(lo_Cmd,T)
				'				If Me.ct_Subscribers.ContainsKey(lo_Type.Name)

				'					Dim	lt_Subs		As IList(Of iSubscription(Of T)) = Nothing

				'				SyncLock	Me.co_LckObj
				'					lt_Subs	= New List(Of iSubscription(Of T))(Me.ct_Subscribers(lo_Type.Name).Cast(Of iSubscription(Of T)))
				'				End SyncLock

				'				For Each lo_Sub	In lt_Subs
				'					If lo_Sub	IsNot	Nothing	Then	lo_Sub.Invoke(x)
				'				Next



				'				'Dim x = 1



				'				'Dim lt = Me.ct_Subscribers(lo_Type).Cast

				'				'SyncLock	Me.co_LckObj
				'					'lt_Subs	= New List(Of iSubscription(Of lo_Type))(Me.ct_Subscribers(lo_Type).Cast(Of iSubscription(Of T)))
				'				'End SyncLock


				'				End If

				'			End If

				'			If Me.ct_Queue.Count.Equals(0)	Then Exit Do

				'		Loop

				'		Me.cacheLock.ExitWriteLock()
				'		Me.cacheLock.ExitUpgradeableReadLock()

				'	End Sub,
				'	TaskCreationOptions.PreferFairness )



				'If Me.cb_Busy	Then	Exit Sub

				'SyncLock Me.co_LckObj
				'	If Me.cb_Busy Then	Exit Sub
				'	Me.cb_Busy	= True
				'End SyncLock
				''..................................................
				'Await Task.Factory.StartNew(
				'	Sub	()




				'		Do

				'			Dim lo_Cmd	As Object	= Nothing

				'			If Me.ct_Queue.TryDequeue(lo_Cmd)
				'			End If

				'			If Me.ct_Queue.Count.Equals(0)	Then Exit Do

				'		Loop

				'	End Sub,
				'	TaskCreationOptions.PreferFairness )
				''..................................................
				'Await Task.Delay(3000)

				'SyncLock Me.co_LckObj
				'	Me.cb_Busy	= False
				'End SyncLock


