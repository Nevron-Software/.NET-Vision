Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Globalization
Imports System.Reflection

Imports Nevron.Diagram.Layout

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Provides methods that are used by the Layout examples.
	''' </summary>
	Public Class NLayoutsHelper
		#Region "Public Methods"

		''' <summary>
		''' Configures the layout using the property/value pairs in the specified hash table.
		''' </summary>
		''' <param name="layout"></param>
		''' <param name="args"></param>
		Private Sub New()
		End Sub
		Public Shared Sub ConfigureLayout(ByVal layout As NLayout, ByVal args As Hashtable)
			' Configure the layout
			If args Is Nothing Then
				Return
			End If

			Dim type As Type = layout.GetType()
			Dim enumerator As IDictionaryEnumerator = args.GetEnumerator()
			Do While enumerator.MoveNext()
				Dim p As PropertyInfo = type.GetProperty(enumerator.Key.ToString())
				If p Is Nothing Then
					Throw New Exception(String.Format("The property {0} is not defined for the class {1}", enumerator.Key, layout.GetType().Name))
				End If

				Try
					Dim value As Object = enumerator.Value
					If p.PropertyType.Equals(FLOAT_TYPE) Then
						value = ParseFloat(value)
					End If

					If p.PropertyType.IsEnum Then
						value = System.Enum.Parse(p.PropertyType, enumerator.Value.ToString())
					Else
						value = Convert.ChangeType(value, p.PropertyType)
					End If

					p.SetValue(layout, value, Nothing)
				Catch
					Throw New Exception(String.Format("The value '{0}' is not valid for the {1} property", enumerator.Value, enumerator.Key))
				End Try
			Loop
		End Sub
		''' <summary>
		''' Parses the given object to float using the proper decimal separator.
		''' </summary>
		''' <param name="value"></param>
		''' <returns></returns>
		Public Shared Function ParseFloat(ByVal value As Object) As Single
			Dim s As String = value.ToString()
			If s.Contains(".") Then
				s = s.Replace(".", DECIMAL_SEPARATOR)
			ElseIf s.Contains(",") Then
				s = s.Replace(",", DECIMAL_SEPARATOR)
			End If

			Return Single.Parse(s)
		End Function

		#End Region

		#Region "Static"

		Private Shared ReadOnly FLOAT_TYPE As Type = GetType(Single)
		Private Shared ReadOnly DECIMAL_SEPARATOR As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

		#End Region
	End Class
End Namespace