Namespace Services.Excel
  Friend NotInheritable Partial Class WBookCloseHandler

    Private Class CloseRequest

      Private m_WBookCount  As Integer
      Private m_WBookName   As String

      Protected Friend Sub New(i_WBName     As String,
                               i_WBCurCount As Integer)
        Me.m_WBookName  = i_WBName
        Me.m_WBookCount = i_WBCurCount
      End Sub

      Protected Friend ReadOnly Property WorkbookName() As String
        Get
          Return m_WBookName
        End Get
      End Property

      Protected Friend ReadOnly Property WorkbookCount() As Integer
        Get
          Return m_WBookCount
        End Get
      End Property

    End Class

  End Class

End Namespace
