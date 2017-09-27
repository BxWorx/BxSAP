Imports System.Globalization
Imports System.Reflection
'••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
Namespace Convertors
	Public Class Clone
								Implements	iClone

		#Region "Methods"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function iFace2Instance(Of _class	As Class, 
																				_iface	As Class)(_srcobj As _iface)		As _class _
												Implements iClone.iFace2Instance

				Dim lo_RetObj		As _class		= CType( Me.CreateInstance(Of _class)(), _class )
				'..................................................
				Me.TransferPropertiesValues(Of _iface)(_srcobj, lo_RetObj)
				Return	lo_RetObj

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Function Instance2iFace(Of _class	As Class,
																				_iface	As Class)(_srcobj	As _class)	As _iface _
												Implements iClone.Instance2iFace

				Dim lo_RetObj		As _iface		= CType( Me.CreateInstance(Of _class)(), _iface )
				'..................................................
				Me.TransferPropertiesValues(Of _iface)(_srcobj, lo_RetObj)
				Return	lo_RetObj

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Methods: Private"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Sub TransferPropertiesValues(Of _iface)(ByRef	_srceobj	As Object,
																											ByRef _trgtobj	As Object)

				For Each lo_PI As PropertyInfo	In GetType(_iface).GetProperties()
					Try
							lo_PI.SetValue(_trgtobj, lo_PI.GetValue(_srceobj))
						Catch ex As Exception
					End Try
				Next

			End Sub
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function CreateInstance(Of _class)()	As Object

				Dim lo_Instance	As Object						= Nothing
				Dim lo_TypCls		As Type							= GetType(_class)
				Dim lo_Constr		As ConstructorInfo	= Me.GetConstructor(lo_TypCls)
				Dim lt_Parms		As List(Of Object)	= Me.GetConstructorParameterDefaults(lo_Constr)
				'..................................................
				lo_Instance		=	lo_Constr.Invoke(	BindingFlags.OptionalParamBinding Or 
																					BindingFlags.InvokeMethod					Or
																					BindingFlags.CreateInstance						,
																					Nothing																,
																					lt_Parms.ToArray()										,
																					CultureInfo.InvariantCulture						)
				'..................................................
				Return	lo_Instance

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function GetConstructor(ByVal _classtype	As Type)	As	ConstructorInfo
				
				Dim lo_ConstrInfo				As ConstructorInfo	= Nothing
				Dim lt_Constructors()		As ConstructorInfo	= _classtype.GetConstructors()

				If Not lt_Constructors.Count.Equals(0)

					lo_ConstrInfo	= Array.Find(lt_Constructors, Function(lo)	lo.GetParameters().Count.Equals(0) )

					If IsNothing(lo_ConstrInfo)
						lo_ConstrInfo	= lt_Constructors.First()
					End If

				End If
				'..................................................
				Return	lo_ConstrInfo

			End Function
			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Private Function GetConstructorParameterDefaults(ByVal _constinfo	As ConstructorInfo)		As List(Of Object)

				Dim lt_Parms		As List(Of Object)	= New List(Of Object)
				'..................................................
				If Not IsNothing(_constinfo)

					For Each lo As ParameterInfo	In _constinfo.GetParameters()
						
						If lo.IsOptional
							lt_Parms.Add(lo.DefaultValue)
						Else
							lt_Parms.Add(Type.Missing)
						End If

					Next

				End If
				'..................................................
				Return	lt_Parms

			End Function

		#End Region
		'¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯
		#Region "Constructors"

			'¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
			Public Sub New()
			End Sub

		#End Region

	End Class

End Namespace