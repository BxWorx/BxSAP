Namespace API.BDC

		Public Class BxS_BDC_CTUParameters
									Implements iBxS_BDC_CTUParameters

		'	The OPTIONS addition covers the functions of the MODE and UPDATE additions and provides further
		'	options for controlling processing of the batch input table. The control parameters are
		'	specified in an opt structure of the type CTU_PARAMS from ABAP Dictionary. The CTU_PARAMS
		'	structure has the components displayed in the following table: 

		'	DISMODE:	Processing mode. Values as for the MODE addition. 
		'	UPMODE:		Update mode for processing. Values as for the UPDATE addition. 
		'	CATTMODE:	CATT mode for processing. While batch input is used mostly for data transfer, CATT
		'						processes are more complex transactions, since they are reusable tests.
		'						Values:	" " (no CATT mode),
		'										"N" (CATT without single screen control),
		'										"A" (CATT with single screen control). 
		'	DEFSIZE:	Selects whether the screens of the called transaction are displayed in the standard
		'						screen size. Values: "X" (standard size), " " (current size). 
		'	RACOMMIT:	Selects whether the COMMIT WORK statement terminates processing or not.
		'						Values: " " (COMMIT WORK terminates processing),
		'										"X" (COMMIT WORK does not terminate processing). 
		'	NOBINPT:	Selection for the system field sy-binpt.
		'						Values: " " (sy-binpt contains "X" in the called transaction),
		'										"X" (sy-binpt contains " " in the called transaction). 
		'	NOBIEND:	Selection for the system field sy-binpt.
		'						Values: " " (sy-binpt contains "X" after the end of the batch input table data in the called transaction )
		'										"X" (sy-binpt contains " " after the end of the data in the called transaction). 

			#Region "Properties"

				'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
				'	"A":		Processing with screens displayed 
				'	"E":		Screens displayed only if an error occurs 
				'	"N":		Processing without screens displayed.
				'						If a breakpoint is reached in one of the called transactions, processing is terminated
				'						with sy-subrc equal to 1001.
				'					The field sy-msgty contains "S", sy-msgid contains "00", sy-msgno contains "344",
				'						sy-msgv1 contains "SAPMSSY3", and sy-msgv2 contains "0131". 
				'	"P":		Processing without screens displayed.
				'						If a breakpoint is reached in one of the called transactions, the system branches to
				'						the ABAP Debugger. 
				'	Others:	As for "A". 

				Private cc_DisMode	As String
				Property DisMode	As String	Implements iBxS_BDC_CTUParameters.DisMode
					Get
						Return Me.cc_DisMode
					End Get
				  Set(value As String)
						If Not IsNothing(value)
							If "AENP".Contains(value)
								Me.cc_DisMode	= value
							Else
								Me.cc_DisMode	= "A"
							End If
						Else
							Me.cc_DisMode	= "A"
						End If
				  End Set
				End Property
				'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
				'	The UPDATE addition determines the update mode for processing. upd can be specified as a 
				'	character-like data object, whose content and purpose are shown in the following table.
				'	If one of the additions UPDATE or OPTIONS FROM is not used, the effect is the same as if
				'	upd had the content "A". 

				'	"A":		Asynchronous update. Updates of called programs are executed in the same way as
				'						if the AND WAIT addition was not specified in the COMMIT WORK statement.
				'	"S":		Synchronous update. Updates of the called programs are executed in the same way
				'						as if the AND WAIT addition had been specified in the COMMIT WORK statement.
				'	"L":		Local updates. Updates of the called program are executed in the same way as if
				'						the SET UPDATE TASK LOCAL statement had been executed in the program.
				'	Others:	As for "A". 
				'
				'	Note:		This option is not available for execution of batch input sessions in batch input.
				'					Updates are always synchronous. 

				Private cc_UpdMode	As String
				Property UpdMode	As String	Implements iBxS_BDC_CTUParameters.UpdMode
					Get
						Return Me.cc_UpdMode
					End Get
				  Set(value As String)
						If Not IsNothing(value)
							If "ASL".Contains(value)
								Me.cc_UpdMode	= value
							Else
								Me.cc_UpdMode	= "A"
							End If
						Else
							Me.cc_UpdMode	= "A"
						End If
				  End Set
				End Property
				'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
				Property CattMode As String	Implements iBxS_BDC_CTUParameters.CattMode
				Property DefSize  As String	Implements iBxS_BDC_CTUParameters.DefSize
				Property RACommit As String	Implements iBxS_BDC_CTUParameters.RACommit
				Property NoBInpt  As String	Implements iBxS_BDC_CTUParameters.NoBInpt
				Property NoBIEnd	As String	Implements iBxS_BDC_CTUParameters.NoBIEnd

			#End Region
			'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
			#Region "Constructor"

				Public Sub New()

					Me.DisMode	= "N"c
					Me.UpdMode	= "A"c
					Me.CattMode	= " "c
					Me.DefSize	= "X"c
					Me.RACommit	= " "c
					Me.NoBInpt	= " "c
					Me.NoBIEnd	= " "c

				End Sub

			#End Region

		End Class

	End Namespace
