Imports System.Windows.Forms
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Main.SAPLogon

	Friend Interface iSapGuiXmlModel

		#Region "Methods: Exposed"

			Function GetSapGuiXmlTree(					ByVal XMLFilePathName		As String	,
																Optional	ByVal	OnlySAPGui				As Boolean	= True	)		As List(Of TreeNode)
			Function GetSapGuiData(ByVal ID	As String)		As iLogonConnectionDTO

		#End Region

	End Interface

End Namespace