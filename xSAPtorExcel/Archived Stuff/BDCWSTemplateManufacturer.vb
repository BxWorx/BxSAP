Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent
Imports xSAPtorNCO.API.Destination
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace SessionProcessing
  Friend Class BDCWSTemplateManufacturer
                Implements iBDCWSTemplateManufacturer

    #Region "Definitions"

      Private ct_Tasks        As BlockingCollection(Of Task(Of Boolean))

      Private co_ct           As CancellationToken
      Private co_Destination  As ixSAPDestinationProfile
      Private ct_SessionList  As Dictionary(Of String, String)

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Methods"

      Friend Function Manufacture() As Boolean  Implements iBDCWSTemplateManufacturer.Manufacture
        Return True
        'Using lo_bc As New BlockingCollection(Of 





      End Function

    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Private Methods"


      Private Shared Sub Producer()

      End Sub


    #End Region
    '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
    #Region "Constructors/Constructor Events; Destructors"

      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Friend Shared Function Create(ByRef i_Destination As ixSAPDestinationProfile,
                                          i_SessionList As Dictionary(Of String, String),
                                          i_ct          As CancellationToken              ) As iBDCWSTemplateManufacturer

        Return New BDCWSTemplateManufacturer( i_Destination := i_Destination,
                                              i_SessionList := i_SessionList,
                                              i_ct          := i_ct)

      End Function
      '¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
      Private Sub New(ByRef i_Destination As ixSAPDestinationProfile,
                            i_SessionList As Dictionary(Of String, String),
                            i_ct          As CancellationToken)

        Me.co_ct          = i_ct
        Me.co_Destination = i_Destination
        Me.ct_SessionList = i_SessionList

      End Sub

    #End Region

  End Class

End Namespace