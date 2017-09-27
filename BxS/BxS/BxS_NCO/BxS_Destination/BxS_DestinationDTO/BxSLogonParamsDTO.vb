'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Destination

	Friend	Class BxSLogonParamsDTO
								Implements	iBxSLogonParamsDTO

		#Region "Properties"

			Public	Property Client			As String		Implements iBxSLogonParamsDTO.Client
			Public	Property User				As String		Implements iBxSLogonParamsDTO.User
			Public	Property Password		As String		Implements iBxSLogonParamsDTO.Password
			Public	Property UseSAPGUI	As Boolean	Implements iBxSLogonParamsDTO.UseSAPGUI

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public	Sub Load(					ByVal	client		As String, _
																ByVal	user			As String, _
																ByVal	password	As String, _
											Optional	ByVal useSAPGUI As Boolean = False) _
										Implements iBxSLogonParamsDTO.Load

				Me.Client			= client
				Me.User				= user
				Me.Password		= password
				Me.UseSAPGUI	= useSAPGUI

			End Sub

		#End Region

	End Class

End Namespace