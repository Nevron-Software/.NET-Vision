Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLabelGeneralUC
		Inherits NExampleBaseUC

		Private HeaderGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents HeaderTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label2 As System.Windows.Forms.Label
		Private FooterGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents FooterTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents FooterTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents HeaderTextStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing
		Private m_Footer As NLabel
		Private m_Header As NLabel

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
			Me.HeaderGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.HeaderTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.HeaderTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.FooterGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.FooterTextStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.FooterTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.HeaderGroupBox.SuspendLayout()
			Me.FooterGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' HeaderGroupBox
			' 
			Me.HeaderGroupBox.Controls.Add(Me.HeaderTextStyleButton)
			Me.HeaderGroupBox.Controls.Add(Me.HeaderTextBox)
			Me.HeaderGroupBox.Controls.Add(Me.label1)
			Me.HeaderGroupBox.ImageIndex = 0
			Me.HeaderGroupBox.Location = New System.Drawing.Point(5, 12)
			Me.HeaderGroupBox.Name = "HeaderGroupBox"
			Me.HeaderGroupBox.Size = New System.Drawing.Size(171, 114)
			Me.HeaderGroupBox.TabIndex = 0
			Me.HeaderGroupBox.TabStop = False
			Me.HeaderGroupBox.Text = "Header"
			' 
			' HeaderTextStyleButton
			' 
			Me.HeaderTextStyleButton.Location = New System.Drawing.Point(2, 72)
			Me.HeaderTextStyleButton.Name = "HeaderTextStyleButton"
			Me.HeaderTextStyleButton.Size = New System.Drawing.Size(160, 23)
			Me.HeaderTextStyleButton.TabIndex = 2
			Me.HeaderTextStyleButton.Text = "Text Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HeaderTextStyleButton.Click += new System.EventHandler(this.HeaderTextStyleButton_Click);
			' 
			' HeaderTextBox
			' 
			Me.HeaderTextBox.Location = New System.Drawing.Point(1, 39)
			Me.HeaderTextBox.Name = "HeaderTextBox"
			Me.HeaderTextBox.Size = New System.Drawing.Size(160, 18)
			Me.HeaderTextBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HeaderTextBox.TextChanged += new System.EventHandler(this.HeaderTextBox_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(1, 23)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(101, 19)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Text:"
			' 
			' FooterGroupBox
			' 
			Me.FooterGroupBox.Controls.Add(Me.FooterTextStyleButton)
			Me.FooterGroupBox.Controls.Add(Me.FooterTextBox)
			Me.FooterGroupBox.Controls.Add(Me.label2)
			Me.FooterGroupBox.ImageIndex = 0
			Me.FooterGroupBox.Location = New System.Drawing.Point(6, 148)
			Me.FooterGroupBox.Name = "FooterGroupBox"
			Me.FooterGroupBox.Size = New System.Drawing.Size(171, 114)
			Me.FooterGroupBox.TabIndex = 3
			Me.FooterGroupBox.TabStop = False
			Me.FooterGroupBox.Text = "Footer"
			' 
			' FooterTextStyleButton
			' 
			Me.FooterTextStyleButton.Location = New System.Drawing.Point(2, 72)
			Me.FooterTextStyleButton.Name = "FooterTextStyleButton"
			Me.FooterTextStyleButton.Size = New System.Drawing.Size(160, 23)
			Me.FooterTextStyleButton.TabIndex = 2
			Me.FooterTextStyleButton.Text = "Text Style"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FooterTextStyleButton.Click += new System.EventHandler(this.FooterTextStyleButton_Click);
			' 
			' FooterTextBox
			' 
			Me.FooterTextBox.Location = New System.Drawing.Point(1, 39)
			Me.FooterTextBox.Name = "FooterTextBox"
			Me.FooterTextBox.Size = New System.Drawing.Size(160, 18)
			Me.FooterTextBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FooterTextBox.TextChanged += new System.EventHandler(this.FooterTextBox_TextChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(1, 23)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(101, 19)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Text:"
			' 
			' NLabelGeneralUC
			' 
			Me.Controls.Add(Me.HeaderGroupBox)
			Me.Controls.Add(Me.FooterGroupBox)
			Me.Name = "NLabelGeneralUC"
			Me.Size = New System.Drawing.Size(180, 542)
			Me.HeaderGroupBox.ResumeLayout(False)
			Me.FooterGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NTrackballTool())
			nChartControl1.Panels.Clear()

			m_Header = New NLabel("Nevron Chart for .NET")
			m_Header.DockMode = PanelDockMode.Top
			m_Header.ContentAlignment = ContentAlignment.MiddleCenter
			m_Header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			m_Header.TextStyle.FillStyle = New NGradientFillStyle(Color.LightBlue, Color.DarkBlue)
			m_Header.TextStyle.BackplaneStyle.Visible = True
			m_Header.TextStyle.BackplaneStyle.FillStyle.SetTransparencyPercent(50)
			m_Header.TextStyle.BorderStyle.Width = New NLength(1)
			m_Header.TextStyle.BorderStyle.Color = Color.LightBlue
			m_Header.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(m_Header)

			m_Footer = New NLabel("Copyright 1998 - 2011")
			m_Footer.DockMode = PanelDockMode.Bottom
			m_Footer.TextStyle.FontStyle = New NFontStyle("Times New Roman", 12, FontStyle.Italic)
			m_Footer.ContentAlignment = ContentAlignment.MiddleLeft
			m_Footer.TextStyle.FontStyle.EmSize = New NLength(9, NGraphicsUnit.Point)
			m_Footer.TextStyle.FillStyle = New NGradientFillStyle(Color.LightBlue, Color.DarkBlue)
			m_Footer.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
			m_Footer.Margins = New NMarginsL(0, 10, 0, 10)
			nChartControl1.Panels.Add(m_Footer)

			Dim chart As New NCartesianChart()
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Fill
			chart.DockMargins = New NMarginsL(20, 20, 20, 20)

			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red)
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.DataLabelStyle.Visible = False
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(3, 3)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.Values.AddRange(monthValues)

			nChartControl1.Panels.Add(chart)

			HeaderTextBox.Text = m_Header.Text
			FooterTextBox.Text = m_Footer.Text

			nChartControl1.Refresh()
		End Sub


		Private Sub HeaderTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HeaderTextBox.TextChanged
			m_Header.Text = HeaderTextBox.Text
			nChartControl1.Refresh()
		End Sub

		Private Sub FooterTextStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FooterTextStyleButton.Click
			Dim textStyle As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_Footer.TextStyle, False, textStyle) Then
				m_Footer.TextStyle = textStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub HeaderTextStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles HeaderTextStyleButton.Click
			Dim textStyle As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_Header.TextStyle, False, textStyle) Then
				m_Header.TextStyle = textStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub FooterTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FooterTextBox.TextChanged
			m_Footer.Text = FooterTextBox.Text
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
