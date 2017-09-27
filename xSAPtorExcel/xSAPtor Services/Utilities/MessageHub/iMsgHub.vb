'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Utilities.MsgHub

	Friend Interface iMsgHub

		#Region "Methods: Exposed"

			Function	CreateSubscription(Of T)(ByVal	Action	As Action(Of T))	As iSubscription(Of T)

			'....................................................
			Sub Publish(Of T)(message As T)

			Function	Subscribe(Of T)(					ByVal	Action	As Action(Of T)	, 
																Optional	ByVal	NoDuplicates	As	Boolean	= True				)	As iSubscription(Of T)
			Function	Unsubscribe(Of T)(ByVal	Subscription	As	iSubscription(Of T))	As Boolean

			Sub	UnsubscribeAll()

		#End Region

	End Interface

End Namespace