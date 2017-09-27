Imports xSAPtorNCO.API.SAP.System.Services
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace DONOTUSE
  Public Interface iBDCDataSheetConfiguration

    Property SAPTCode  As String

    Property CTU_Parameters As iBDCCTUParams

    Function XMLMe()  As String

  End Interface

End Namespace