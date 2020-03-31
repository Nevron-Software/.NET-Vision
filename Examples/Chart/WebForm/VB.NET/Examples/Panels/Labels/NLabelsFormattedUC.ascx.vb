Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports Nevron.Examples.Framework.WebForm
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WebForm

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NLabelsFormattedUC
		Inherits NExampleUC
		Protected LabelsGeneral As HtmlForm

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				SampleFormattedLabelDropDownList.Items.Add("Font size and color")
				SampleFormattedLabelDropDownList.Items.Add("Font style control")
				SampleFormattedLabelDropDownList.Items.Add("Subscript and superscript")
				SampleFormattedLabelDropDownList.Items.Add("Shapes")
				SampleFormattedLabelDropDownList.Items.Add("Bullets")
				SampleFormattedLabelDropDownList.Items.Add("Fill Effects")
				SampleFormattedLabelDropDownList.Items.Add("Borders")
				SampleFormattedLabelDropDownList.Items.Add("Shadows")
				SampleFormattedLabelDropDownList.Items.Add("Background Fill and Stroke")
				SampleFormattedLabelDropDownList.SelectedIndex = 8

				WebExamplesUtilities.FillComboWithFontNames(FontDropDownList, "Arial")
				WebExamplesUtilities.FillComboWithValues(FontSizeDropDownList, 8, 52, 1)

				WebExamplesUtilities.FillComboWithColorNames(FontColorDropDownList, KnownColor.Black)

				HasBackplaneCheckBox.Checked = True
			End If

			nChartControl1.BackgroundStyle.FrameStyle.Visible = False
			nChartControl1.Panels.Clear()
			Dim label As NLabel = New NLabel()

			Try
				label.TextStyle.FontStyle = New NFontStyle(FontDropDownList.SelectedItem.Text, FontSizeDropDownList.SelectedIndex + 8)
			Catch
			End Try

			label.Text = GetFormattedString(CInt(Fix(label.TextStyle.FontStyle.EmSize.Value)))

			label.TextStyle.FillStyle = New NColorFillStyle(WebExamplesUtilities.ColorFromDropDownList(FontColorDropDownList))
			label.TextStyle.TextFormat = TextFormat.XML
			label.TextStyle.BackplaneStyle.Visible = HasBackplaneCheckBox.Checked
			label.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Left
			label.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top
			label.TextStyle.TextFormat = TextFormat.XML
			label.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(label)
		End Sub

		Private Function GetBulletText(ByVal bulletType As String) As String
			Return bulletType & " bullets <ul liststyletype = '" & bulletType & "'>" & "<li color = 'red'>" & bulletType & " Bullet 1" & "</li>" & "<li color = 'blue'>" & bulletType & " Bullet 2" & "</li>" & "</ul><br/>"
		End Function

		Private Function GetFormattedString(ByVal nBaseSize As Integer) As String
			Dim sText As String = ""

			Select Case SampleFormattedLabelDropDownList.SelectedIndex
				Case 0
					' Font size and color 
					sText = "<font size = '" & (nBaseSize + 4).ToString() & "' color = 'red'>XML formatted</font> texts allow you to mix<br/>" & "texts with different <font color = 'blue' size = '" & (nBaseSize + 4).ToString() & "' face = 'Balthazar'>font</font> and <font face = 'Arial black' color = 'green' size = '" & (nBaseSize + 4).ToString() & "'>size</font>"
				Case 1
					' Font style control
					sText = "Demonstrates how to use <font color = 'red'><b>bold</b></font>, <font color = 'green'><i>italic</i></font>, <br/><font color = 'blue'><u>underline</u></font> and <font color = 'darkorange'><strike>strikeout</strike></font> tags"
				Case 2
					' Subscript and superscript
					sText = "World's most famous formula : <font size = '" & (nBaseSize + 4).ToString() & "' color = 'red'><b>E = MC<sup>2</sup></b></font> <br/>This text uses <sup>sup</sup> and <sub>sub</sub> tags"
				Case 3
					' Shapes
					Dim values As Array = System.Enum.GetValues(GetType(MarkerShape))
					Dim names As String() = System.Enum.GetNames(GetType(MarkerShape))
					Dim lightColors As Color() = New Color() { Color.Red, Color.Green, Color.Blue }
					Dim darkColors As Color() = New Color() { Color.DarkRed, Color.DarkGreen, Color.DarkBlue }

					Dim i As Integer = 0
					Do While i < names.Length
						sText &= names(i) & " Shape <shape shape='" & names(i).ToLower() & "' size = '10pt, 10pt' color = '" & lightColors(i Mod 3).ToKnownColor().ToString() & "' bordercolor = '" & darkColors(i Mod 3).ToKnownColor().ToString() & "'/><br/>"
						i += 1
					Loop
				Case 4
					' Bullets 
					sText = "XML formatted texts support several bullet list styles<br/><font size = '" & (nBaseSize).ToString() & "'>"

					Dim arrEnumNames As String() = System.Enum.GetNames(GetType(ListStyleType))

					Dim i As Integer = 0
					Do While i < arrEnumNames.Length
						sText &= GetBulletText(arrEnumNames(i))
						i += 1
					Loop

					sText &= "</font>"
				Case 5
					' Fill Effects
					sText = "XML formatted texts support: <br/><font color = 'red'>- Solid color</font><br/><font gradient = '0, 0, white, navy'>- Simple (two color) gradient</font><br/><font pattern = '25, white, navy'>- Pattern (hatch)</font><br/>filling types"
				Case 6
					' Borders
					sText = "Text borders can be with different <br/><font face = 'Ariel Black' gradient = '0, 1, White, Navy' size = '" & (nBaseSize + 4).ToString() & "'> <font border = '2' bordercolor = 'red'>WIDTH</font> and <font bordercolor = 'magenta' border = '1'>COLOR</font></font>"
				Case 7
					' Shadows
					sText = "There are several types of shadows: <br/>" & " <font shadowoffset = '5, 5' shadowfadearea = '5' face = 'Impact' gradient = '0, 1, White, Navy' size = '" & (nBaseSize + 4).ToString() & "'>" & "- <font shadowtype = 'solid'>Solid ShadowStyle</font> <br/>" & "- <font shadowtype = 'linearblur'>Linear Blur ShadowStyle</font> <br/>" & "- <font shadowtype = 'radialblur'>Radial Blur ShadowStyle</font> <br/>" & "- <font shadowtype = 'gaussianblur'>Gaussian Blur ShadowStyle</font> <br/>" & "</font>" & "You can also use shadows to: <br/><font face = 'Impact' gradient = '0, 1, White, DarkOrange' size = '" & (nBaseSize + 4).ToString() & "' shadowtype = 'gaussianblur' shadowcolor = 'yellow' shadowfadearea = '5' shadowoffset = '0, 0'>HIGHLIGHT TEXT</font>"
				Case 8
					' backgrounf fill & stroke
					sText = "XML Formatted text allow you to control the text background.<br/>This is <font color = 'black' back-color = 'orange'>BLACK TEXT ON AN ORANGE BACKGROUND</font><br/>This is <font color = 'white' back-gradient = '0,0,white,navy'>WHITE TEXT ON A GRADIENT BACKGROUND</font><br/>This is <font color = 'black' back-color = 'orange' back-bordercolor = 'red' back-borderwidth = '1pt'>BLACK TEXT ON AN ORANGE BACKGROUND (RED OUTLINE)</font><br/>This is <font color = 'white' back-color = 'black' back-bordercolor = 'red' back-borderwidth = '1pt'>WHITE TEXT ON A BLACK BACKGROUND</font><br/>"
			End Select

			Return sText
		End Function
	End Class
End Namespace
