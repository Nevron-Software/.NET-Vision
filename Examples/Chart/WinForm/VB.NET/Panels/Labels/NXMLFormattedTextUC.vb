Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.UI
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NXMLFormattedTextUC
		Inherits NExampleBaseUC

		Private WithEvents TextFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents TextBorderbutton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents TextShadowButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents TextFontButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PredefinedSampleTextComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private TextDefaultFontDialog As System.Windows.Forms.FontDialog
		Private WithEvents TextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.TextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.PredefinedSampleTextComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.TextFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.TextBorderbutton = New Nevron.UI.WinForm.Controls.NButton()
			Me.TextShadowButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.TextFontButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.TextDefaultFontDialog = New System.Windows.Forms.FontDialog()
			Me.SuspendLayout()
			' 
			' TextBox
			' 
			Me.TextBox.Location = New System.Drawing.Point(5, 29)
			Me.TextBox.Multiline = True
			Me.TextBox.Name = "TextBox"
			Me.TextBox.Size = New System.Drawing.Size(170, 162)
			Me.TextBox.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 195)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Load sample text:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' PredefinedSampleTextComboBox
			' 
			Me.PredefinedSampleTextComboBox.ListProperties.CheckBoxDataMember = ""
			Me.PredefinedSampleTextComboBox.ListProperties.DataSource = Nothing
			Me.PredefinedSampleTextComboBox.ListProperties.DisplayMember = ""
			Me.PredefinedSampleTextComboBox.Location = New System.Drawing.Point(5, 222)
			Me.PredefinedSampleTextComboBox.Name = "PredefinedSampleTextComboBox"
			Me.PredefinedSampleTextComboBox.Size = New System.Drawing.Size(170, 21)
			Me.PredefinedSampleTextComboBox.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PredefinedSampleTextComboBox.SelectedIndexChanged += new System.EventHandler(this.PredefinedSampleTextComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 5)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(170, 23)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Label text:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' TextFillStyleButton
			' 
			Me.TextFillStyleButton.Location = New System.Drawing.Point(5, 259)
			Me.TextFillStyleButton.Name = "TextFillStyleButton"
			Me.TextFillStyleButton.Size = New System.Drawing.Size(170, 23)
			Me.TextFillStyleButton.TabIndex = 4
			Me.TextFillStyleButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextFillStyleButton.Click += new System.EventHandler(this.TextFillStyleButton_Click);
			' 
			' TextBorderbutton
			' 
			Me.TextBorderbutton.Location = New System.Drawing.Point(5, 294)
			Me.TextBorderbutton.Name = "TextBorderbutton"
			Me.TextBorderbutton.Size = New System.Drawing.Size(170, 23)
			Me.TextBorderbutton.TabIndex = 5
			Me.TextBorderbutton.Text = "Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextBorderbutton.Click += new System.EventHandler(this.TextBorderbutton_Click);
			' 
			' TextShadowButton
			' 
			Me.TextShadowButton.Location = New System.Drawing.Point(5, 330)
			Me.TextShadowButton.Name = "TextShadowButton"
			Me.TextShadowButton.Size = New System.Drawing.Size(170, 23)
			Me.TextShadowButton.TabIndex = 6
			Me.TextShadowButton.Text = "Shadow..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextShadowButton.Click += new System.EventHandler(this.TextShadowButton_Click);
			' 
			' TextFontButton
			' 
			Me.TextFontButton.Location = New System.Drawing.Point(5, 364)
			Me.TextFontButton.Name = "TextFontButton"
			Me.TextFontButton.Size = New System.Drawing.Size(170, 23)
			Me.TextFontButton.TabIndex = 7
			Me.TextFontButton.Text = "Font..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TextFontButton.Click += new System.EventHandler(this.TextFontButton_Click);
			' 
			' NXMLFormattedTextUC
			' 
			Me.Controls.Add(Me.TextFontButton)
			Me.Controls.Add(Me.TextShadowButton)
			Me.Controls.Add(Me.TextBorderbutton)
			Me.Controls.Add(Me.TextFillStyleButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.PredefinedSampleTextComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.TextBox)
			Me.Name = "NXMLFormattedTextUC"
			Me.Size = New System.Drawing.Size(180, 408)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.BackplaneStyle.Visible = True
			title.TextStyle.BackplaneStyle.FillStyle = New NColorFillStyle(Color.FromArgb(125, 255, 255, 255))
			title.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderWidth = New NLength(0, NGraphicsUnit.Pixel)
			title.TextStyle.FillStyle = New NColorFillStyle(Color.Black)
			title.TextStyle.FontStyle = New NFontStyle("Arial", 16)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Charts.Clear()

			PredefinedSampleTextComboBox.Items.Add("Font size and color")
			PredefinedSampleTextComboBox.Items.Add("Font style control")
			PredefinedSampleTextComboBox.Items.Add("Subscript and superscript")
			PredefinedSampleTextComboBox.Items.Add("Shapes")
			PredefinedSampleTextComboBox.Items.Add("Bullets")
			PredefinedSampleTextComboBox.Items.Add("Fill Styles")
			PredefinedSampleTextComboBox.Items.Add("Border Styles")
			PredefinedSampleTextComboBox.Items.Add("Shadows Styles")
			PredefinedSampleTextComboBox.Items.Add("Text Background")
			PredefinedSampleTextComboBox.SelectedIndex = 8
		End Sub

		Private Function GetBulletText(ByVal sBulletType As String) As String
			Return sBulletType & " bullets <ul liststyletype = '" & sBulletType & "'>" & "<li color = 'red'>" & sBulletType & " Bullet 1" & "</li>" & "<li color = 'blue'>" & sBulletType & " Bullet 2" & "</li>" & "</ul><br/>"
		End Function

		Private Sub PredefinedSampleTextComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PredefinedSampleTextComboBox.SelectedIndexChanged
			Dim sText As String = ""

			Select Case PredefinedSampleTextComboBox.SelectedIndex
				Case 0
					' Font size and color 
					sText = "<font size = '19' color = 'red'>XML formatted</font> texts allow you to mix<br/>" & "texts with different <font color = 'blue' size = '24' face = 'Balthazar'>font</font> and <font face = 'Arial black' color = 'green' size = '24'>size</font>"
				Case 1
					' Font style control
					sText = "Demonstrates how to use <font color = 'red'><b>bold</b></font>, <font color = 'green'><i>italic</i></font>, <br/><font color = 'blue'><u>underline</u></font> and <font color = 'darkorange'><strike>strikeout</strike></font> tags"
				Case 2
					' Subscript and superscript
					sText = "World's most famous formula : <font size = '25' color = 'red'><b>E = MC<sup>2</sup></b></font> <br/>This text uses <sup>sup</sup> and <sub>sub</sub> tags"
				Case 3
					' Shapes
					Dim values As Array = System.Enum.GetValues(GetType(MarkerShape))
					Dim names() As String = System.Enum.GetNames(GetType(MarkerShape))
					Dim lightColors() As Color = { Color.Red, Color.Green, Color.Blue }
					Dim darkColors() As Color = { Color.DarkRed, Color.DarkGreen, Color.DarkBlue }

					For i As Integer = 0 To names.Length - 1
						sText &= names(i) & " Shape <shape shape='" & names(i).ToLower() & "' size = '20pt, 20pt' color = '" & lightColors(i Mod 3).ToKnownColor().ToString() & "' bordercolor = '" & darkColors(i Mod 3).ToKnownColor().ToString() & "'/><br/>"
					Next i
				Case 4
					' Bullets 
						sText = "XML formatted texts support several bullet list styles<br/><font size = '12'>"

						Dim arrEnumNames() As String = System.Enum.GetNames(GetType(ListStyleType))

						For i As Integer = 0 To arrEnumNames.Length - 1
							sText &= GetBulletText(arrEnumNames(i))
						Next i

						sText &= "</font>"
				Case 5
					' Fill Styles
					sText = "XML formatted texts support: <br/><font color = 'red'>- Solid color</font><br/><font gradient = '0, 0, white, navy'>- Simple (two color) gradient</font><br/><font pattern = '25, white, navy'>- Pattern (hatch)</font><br/>filling types"
				Case 6
					' Border Styles
					sText = "Text borders can be with different <br/><font face = 'Impact' gradient = '0, 1, White, Navy' size = '33'> <font border = '2' bordercolor = 'red'>WIDTH</font> and <font bordercolor = 'magenta' border = '1'>COLOR</font></font>"
				Case 7
					' Shadow Styles
					sText = "There are several types of shadows: <br/>" & " <font shadowoffset = '10, 10' shadowfadelength = '8' face = 'Impact' gradient = '0, 1, White, Navy' size = '33'>" & "- <font shadowtype = 'solid'>Solid Shadow</font> <br/>" & "- <font shadowtype = 'linearblur'>Linear Blur Shadow</font> <br/>" & "- <font shadowtype = 'radialblur'>Radial Blur Shadow</font> <br/>" & "- <font shadowtype = 'gaussianblur'>Gaussian Blur Shadow</font> <br/>" & "</font>" & "You can also use shadows to <font face = 'Impact' gradient = '0, 1, White, DarkOrange' size = '33' shadowtype = 'gaussianblur' shadowcolor = 'yellow' shadowfadelength = '8' shadowoffset = '0, 0'>HIGHLIGHT TEXT</font>"
				Case 8
					' Text background
					sText = "XML Formatted text allow you to control the text background.<br/>" & "This is <font color = 'black' back-color = 'orange'>BLACK TEXT ON AN ORANGE BACKGROUND</font><br/>" & "This is <font color = 'white' back-gradient = '0,0,white,navy'>WHITE TEXT ON A GRADIENT BACKGROUND</font><br/>" & "This is <font color = 'black' back-color = 'orange' back-bordercolor = 'red' back-borderwidth = '1pt'>BLACK TEXT ON AN ORANGE BACKGROUND, WITH RED OUTLINE</font><br/>" & "This is <font color = 'white' back-color = 'black' back-bordercolor = 'red' back-borderwidth = '1pt'>WHITE TEXT ON A BLACK BACKGROUND</font><br/>"
			End Select

			TextBox.Text = sText
		End Sub

		Private Sub TextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox.TextChanged
			Dim label As NLabel = nChartControl1.Labels(0)
			label.Text = TextBox.Text
			nChartControl1.Refresh()
		End Sub

		Private Sub TextFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFillStyleButton.Click
			Dim label As NLabel = nChartControl1.Labels(0)
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(label.TextStyle.FillStyle, fillStyleResult) Then
				label.TextStyle.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub TextBorderbutton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBorderbutton.Click
			Dim label As NLabel = nChartControl1.Labels(0)
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(label.TextStyle.BorderStyle, strokeStyleResult) Then
				label.TextStyle.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub TextShadowButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextShadowButton.Click
			Dim label As NLabel = nChartControl1.Labels(0)
			Dim shadowStyleResult As NShadowStyle = Nothing

			If NShadowStyleTypeEditor.Edit(label.TextStyle.ShadowStyle, shadowStyleResult) Then
				label.TextStyle.ShadowStyle = shadowStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub TextFontButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFontButton.Click
			Dim label As NLabel = nChartControl1.Labels(0)

			TextDefaultFontDialog = New FontDialog()
			TextDefaultFontDialog.Font = New Font(label.TextStyle.FontStyle.Name, label.TextStyle.FontStyle.EmSize.Value, label.TextStyle.FontStyle.Style)

			If TextDefaultFontDialog.ShowDialog() = DialogResult.OK Then
				label.TextStyle.FontStyle.Name = TextDefaultFontDialog.Font.Name
				label.TextStyle.FontStyle.EmSize = New NLength(TextDefaultFontDialog.Font.SizeInPoints, NGraphicsUnit.Point)
				label.TextStyle.FontStyle.Style = TextDefaultFontDialog.Font.Style

				nChartControl1.Refresh()
			End If
		End Sub

	End Class
End Namespace