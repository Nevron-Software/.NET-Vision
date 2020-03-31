Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NStandardFrameStyleUC
		Inherits NExampleBaseUC

		Private m_StandardFrameStyle As NStandardFrameStyle
		Private label6 As System.Windows.Forms.Label
		Private WithEvents BackgroundFillStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents nStandardFrameStyleEditorUC1 As Nevron.Editors.NStandardFrameStyleEditorUC
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
			Me.label6 = New System.Windows.Forms.Label()
			Me.BackgroundFillStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nStandardFrameStyleEditorUC1 = New Nevron.Editors.NStandardFrameStyleEditorUC()
			Me.SuspendLayout()
			' 
			' label6
			' 
			Me.label6.Dock = System.Windows.Forms.DockStyle.Top
			Me.label6.Location = New System.Drawing.Point(0, 21)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(298, 16)
			Me.label6.TabIndex = 0
			Me.label6.Text = "Background fill style:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BackgroundFillStyleComboBox
			' 
			Me.BackgroundFillStyleComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.BackgroundFillStyleComboBox.Location = New System.Drawing.Point(0, 0)
			Me.BackgroundFillStyleComboBox.Name = "BackgroundFillStyleComboBox"
			Me.BackgroundFillStyleComboBox.Size = New System.Drawing.Size(298, 21)
			Me.BackgroundFillStyleComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackgroundFillStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundFillStyleComboBox_SelectedIndexChanged);
			' 
			' nStandardFrameStyleEditorUC1
			' 
			Me.nStandardFrameStyleEditorUC1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nStandardFrameStyleEditorUC1.Location = New System.Drawing.Point(0, 37)
			Me.nStandardFrameStyleEditorUC1.Name = "nStandardFrameStyleEditorUC1"
			Me.nStandardFrameStyleEditorUC1.Size = New System.Drawing.Size(298, 329)
			Me.nStandardFrameStyleEditorUC1.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.nStandardFrameStyleEditorUC1.StyleChanged += new System.EventHandler(this.nStandardFrameStyleEditorUC1_StandardFrameStyleChanged);
			' 
			' NStandardFrameStyleUC
			' 
			Me.Controls.Add(Me.nStandardFrameStyleEditorUC1)
			Me.Controls.Add(Me.BackgroundFillStyleComboBox)
			Me.Controls.Add(Me.label6)
			Me.Name = "NStandardFrameStyleUC"
			Me.Size = New System.Drawing.Size(298, 507)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_StandardFrameStyle = New NStandardFrameStyle()
			nChartControl1.BackgroundStyle.FrameStyle = m_StandardFrameStyle

			Dim title As New NLabel("Standard Background Frame")
			title.TextStyle.FillStyle = New NColorFillStyle(Color.Navy)
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.AliceBlue, Color.LightGray)

			Dim chart As NChart = nChartControl1.Charts(0)

			Dim area As NAreaSeries = CType(chart.Series.Add(SeriesType.Area), NAreaSeries)
			area.DataLabelStyle.Visible = False
			area.FillStyle = New NColorFillStyle(DarkOrange)
			area.Values.AddRange(monthValues)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			BackgroundFillStyleComboBox.Items.Add("Solid color")
			BackgroundFillStyleComboBox.Items.Add("Gradient")
			BackgroundFillStyleComboBox.Items.Add("Image")
			BackgroundFillStyleComboBox.Items.Add("Pattern")
			BackgroundFillStyleComboBox.Items.Add("AdvancedGradient")
			BackgroundFillStyleComboBox.SelectedIndex = 1

			nStandardFrameStyleEditorUC1.Style = CType(nChartControl1.BackgroundStyle.FrameStyle, NStandardFrameStyle)
			AddHandler nStandardFrameStyleEditorUC1.StyleChanged, AddressOf OnStandardFrameStyleChanged
		End Sub

		Private Sub OnStandardFrameStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			nChartControl1.Refresh()
		End Sub

		Private Sub BackgroundFillStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackgroundFillStyleComboBox.SelectedIndexChanged
			Select Case BackgroundFillStyleComboBox.SelectedIndex
				Case 0 ' Solid color
					nChartControl1.BackgroundStyle.FillStyle = New NColorFillStyle(Color.BlanchedAlmond)
				Case 1 ' Gradient
					nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.AliceBlue, Color.BlanchedAlmond)
				Case 2 ' Image
					Dim imageFillStyle As New NImageFillStyle(NResourceHelper.BitmapFromResource(Me.GetType(), "Back.png", "Nevron.Examples.Chart.WinForm.Resources"))
					imageFillStyle.TextureMappingStyle.MapLayout = MapLayout.Tiled

					nChartControl1.BackgroundStyle.FillStyle = imageFillStyle
				Case 3 ' Pattern
					nChartControl1.BackgroundStyle.FillStyle = New NHatchFillStyle(HatchStyle.Divot, Color.BlueViolet, Color.Beige)
				Case 4 ' Advanced gradient
					nChartControl1.BackgroundStyle.FillStyle = New NAdvancedGradientFillStyle(AdvancedGradientScheme.Ocean3, 12)
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub nStandardFrameStyleEditorUC1_StandardFrameStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nStandardFrameStyleEditorUC1.StyleChanged
			nChartControl1.BackgroundStyle.FrameStyle = DirectCast(nStandardFrameStyleEditorUC1.Style, NStandardFrameStyle)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
