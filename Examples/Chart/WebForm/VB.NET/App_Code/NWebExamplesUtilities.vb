Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WebForm
	Public Class WebExamplesUtilities
		Public Sub New()
		End Sub



		Public Shared Function GetXmlFormatString(ByVal sFormatString As String) As String
			sFormatString = sFormatString.Replace("[", "<")
			sFormatString = sFormatString.Replace("]", ">")

			Return sFormatString
		End Function

		Public Shared Sub FillComboWithFontNames(ByVal dropDownList As DropDownList, ByVal fontToSelect As String)
			dropDownList.Items.Clear()
			Dim currentIndex As Integer = 0, selectedFontIndex As Integer = -1

			For Each fontFamily As FontFamily In FontFamily.Families
				dropDownList.Items.Add(fontFamily.Name)

				If fontFamily.Name = fontToSelect Then
					selectedFontIndex = currentIndex
				End If
				currentIndex += 1
			Next fontFamily

			If currentIndex = 0 Then
				Return
			End If

			If selectedFontIndex <> -1 Then
				dropDownList.SelectedIndex = selectedFontIndex
			Else
				dropDownList.SelectedIndex = 0
			End If
		End Sub

		Public Shared Sub FillComboWithPredefinedProjections(ByVal dropDownList As DropDownList)
			dropDownList.Items.Clear()
			dropDownList.Items.Add("Orthogonal")
			dropDownList.Items.Add("Orthogonal Elevated")
			dropDownList.Items.Add("Orthogonal Horizontal Left")
			dropDownList.Items.Add("Orthogonal Horizontal Right")
			dropDownList.Items.Add("Orthogonal Half")
			dropDownList.Items.Add("Orthogonal Half Horizontal Left")
			dropDownList.Items.Add("Orthogonal Half Horizontal Right")
			dropDownList.Items.Add("Orthogonal Half Rotated")
			dropDownList.Items.Add("Orthogonal Half Elevated")
			dropDownList.Items.Add("Orthogonal Top")
			dropDownList.Items.Add("Perspective")
			dropDownList.Items.Add("Perspective Horizontal Left")
			dropDownList.Items.Add("Perspective Horizontal Right")
			dropDownList.Items.Add("Perspective Rotated")
			dropDownList.Items.Add("Perspective Elevated")
			dropDownList.Items.Add("Perspective Tilted")
		End Sub

		Public Shared Sub FillComboWithPercents(ByVal dropDownList As DropDownList, ByVal percentStep As Integer)
			dropDownList.Items.Clear()

			For i As Integer = 0 To 100 Step percentStep
				dropDownList.Items.Add(i.ToString() & "%")
			Next i
		End Sub

		Public Shared Sub FillComboWithFloatValues(ByVal dropDownList As DropDownList, ByVal min As Single, ByVal max As Single, ByVal interval As Single)
			dropDownList.Items.Clear()

			Dim i As Single = min
			Do While i <= max
				dropDownList.Items.Add(i.ToString("0.00"))
				i += interval
			Loop
		End Sub

		Public Shared Sub FillComboWithValues(ByVal dropDownList As DropDownList, ByVal min As Integer, ByVal max As Integer, ByVal interval As Integer)
			dropDownList.Items.Clear()

			Dim i As Integer = min
			Do While i <= max
				dropDownList.Items.Add(i.ToString())
				i += interval
			Loop
		End Sub

		Public Shared Function GetPercentFromCombo(ByVal dropDownList As DropDownList, ByVal percentStep As Integer) As Integer
			Return dropDownList.SelectedIndex * percentStep
		End Function

		Public Shared Sub FillComboWithColorNames(ByVal dropDownList As DropDownList, ByVal selectedColor As KnownColor)
			Dim index As Integer = -1, currentIndex As Integer = 0
			Dim currentColor As Color

			dropDownList.Items.Clear()

			Dim enumValue As KnownColor = 0
			Do While enumValue <= KnownColor.YellowGreen
				currentColor = Color.FromKnownColor(enumValue)

				If currentColor.IsSystemColor = False Then
					dropDownList.Items.Add(currentColor.ToString())
					If selectedColor = enumValue Then
						index = currentIndex
					End If

					currentIndex += 1
				End If
				enumValue += 1
			Loop

			If index <> -1 Then
				dropDownList.SelectedIndex = index
			End If
		End Sub

		Public Shared Sub FillComboWithEnumValues(ByVal dropDownList As DropDownList, ByVal enumType As Type)
			dropDownList.Items.Clear()

			For Each obj As Object In System.Enum.GetValues(enumType)
				dropDownList.Items.Add(TypeNameToName(obj.ToString(), True, False))
			Next obj
		End Sub

		Public Shared Sub FillComboWithEnumNames(ByVal dropDownList As DropDownList, ByVal enumType As Type)
			dropDownList.Items.Clear()

			For Each obj As Object In System.Enum.GetNames(enumType)
				dropDownList.Items.Add(obj.ToString())
			Next obj
		End Sub


		Public Shared Sub FillComboWithColorNames(ByVal dropDownList As DropDownList)
			Dim currentColor As Color

			dropDownList.Items.Clear()

			Dim enumValue As KnownColor = 0
			Do While enumValue <= KnownColor.YellowGreen
				currentColor = Color.FromKnownColor(enumValue)
				If currentColor.IsSystemColor = False Then
					dropDownList.Items.Add(currentColor.ToString())
				End If
				enumValue += 1
			Loop
		End Sub

		Public Shared Sub FillComboWithBarShapes(ByVal dropDownList As DropDownList)
			dropDownList.Items.Add("Bar")
			dropDownList.Items.Add("Cylinder")
			dropDownList.Items.Add("Cone")
			dropDownList.Items.Add("Inverted Cone")
			dropDownList.Items.Add("Pyramid")
			dropDownList.Items.Add("Inverted Pyramid")
			dropDownList.Items.Add("Ellipsoid")
			dropDownList.Items.Add("Smooth Edge Bar")
			dropDownList.Items.Add("Cut Edge Bar")
		End Sub

		Public Shared Function ColorFromDropDownList(ByVal dropDownList As DropDownList) As Color
			Return ColorFromString(dropDownList.SelectedItem.Text)
		End Function

		Public Shared Function ColorFromString(ByVal stringColor As String) As Color
			Dim currentColor As Color

			Dim enumValue As KnownColor = 0
			Do While enumValue <= KnownColor.YellowGreen
				currentColor = Color.FromKnownColor(enumValue)

				If currentColor.ToString() = stringColor Then
					Return currentColor
				End If
				enumValue += 1
			Loop

			Return Color.FromKnownColor(KnownColor.Blue)
		End Function

		Public Shared Function RandomColor() As Color
			Return Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255))
		End Function

		Public Shared Function TypeNameToName(ByVal typeName As String, ByVal allowNPrefix As Boolean, ByVal allowNamespace As Boolean) As String
			Dim caption As String = ""

			If typeName.Length = 0 Then
				Return caption
			End If

			If (Not allowNamespace) Then
				Dim index As Integer = typeName.LastIndexOf(".")

				If index <> -1 Then
					typeName = typeName.Substring(index + 1)
				End If
			End If

			If allowNPrefix = False AndAlso typeName.StartsWith("N") Then
				typeName = typeName.Substring(1)
			End If

			caption &= typeName.Chars(0)

			Dim i As Integer = 1
			Do While i < typeName.Length
				If Char.IsUpper(typeName.Chars(i)) Then
					caption &= " "
				End If

				caption &= typeName.Chars(i)
				i += 1
			Loop

			Return caption
		End Function

		Public Shared Sub GenerateOHLCDataPoint(ByVal dPrevClose As Double, ByVal range As NRange1DD, <System.Runtime.InteropServices.Out()> ByRef open As Double, <System.Runtime.InteropServices.Out()> ByRef high As Double, <System.Runtime.InteropServices.Out()> ByRef low As Double, <System.Runtime.InteropServices.Out()> ByRef close As Double)
			open = dPrevClose
			Dim upward As Boolean = False

			If range.Begin > dPrevClose Then
				upward = True
			ElseIf range.End < dPrevClose Then
				upward = False
			Else
				upward = rand.NextDouble() > 0.5
			End If

			If upward Then
				' upward price change
				close = open + (2 + (rand.NextDouble() * 20))
				high = close + (rand.NextDouble() * 10)
				low = open - (rand.NextDouble() * 10)
			Else
				' downward price change
				close = open - (2 + (rand.NextDouble() * 20))
				high = open + (rand.NextDouble() * 10)
				low = close - (rand.NextDouble() * 10)
			End If

			If low < 1 Then
				low = 1
			End If
		End Sub

		Public Shared Sub GenerateOHLCData(ByVal s As NStockSeries, ByVal dPrevClose As Double, ByVal nCount As Integer, ByVal range As NRange1DD)
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			Dim nIndex As Integer = 0
			Do While nIndex < nCount
				GenerateOHLCDataPoint(dPrevClose, range, open, high, low, close)

				dPrevClose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
				nIndex += 1
			Loop
		End Sub

		Public Shared Sub GenerateOHLCData(ByVal s As NStockSeries, ByVal dPrevClose As Double, ByVal nCount As Integer)
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			Dim nIndex As Integer = 0
			Do While nIndex < nCount
				open = dPrevClose

				If dPrevClose < 25 OrElse rand.NextDouble() > 0.5 Then
					' upward price change
					close = open + (2 + (rand.NextDouble() * 20))
					high = close + (rand.NextDouble() * 10)
					low = open - (rand.NextDouble() * 10)
				Else
					' downward price change
					close = open - (2 + (rand.NextDouble() * 20))
					high = open + (rand.NextDouble() * 10)
					low = close - (rand.NextDouble() * 10)
				End If

				If low < 1 Then
					low = 1
				End If

				dPrevClose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
				nIndex += 1
			Loop
		End Sub

		Public Shared Sub GenerateDataPoint(ByVal dPrev As Double, ByVal range As NRange1DD, <System.Runtime.InteropServices.Out()> ByRef aValue As Double, ByRef factor As Integer)
			aValue = dPrev
			Dim upward As Boolean = False
			If dPrev <= range.Begin Then
				upward = True
			Else
				If dPrev >= range.End Then
					upward = False
				Else
					Dim u As Double = rand.NextDouble()
					If Math.Abs(factor) > 30 Then
						upward = u / Math.Abs(factor) > 0.1
					Else
						upward = u > 0.5
					End If
				End If
			End If
			If upward Then
				' upward value change
				aValue = aValue + (rand.NextDouble() * 10)
				factor += 1
			Else
				' downward value change
				aValue = aValue - (rand.NextDouble() * 10)
				factor -= 1
			End If
		End Sub


		Public Shared rand As Random = New Random()
	End Class
End Namespace
