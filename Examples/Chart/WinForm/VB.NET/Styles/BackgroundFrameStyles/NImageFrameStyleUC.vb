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
	Public Class NImageFrameStyleUC
		Inherits NExampleBaseUC

		Private m_ImageFrameStyle As NImageFrameStyle
		Private WithEvents BackgroundFillStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ImageFrameStyleEditorUC As Nevron.Editors.NImageFrameStyleEditorUC
		Private label1 As System.Windows.Forms.Label
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.BackgroundFillStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ImageFrameStyleEditorUC = New Nevron.Editors.NImageFrameStyleEditorUC()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(302, 19)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Background fill style:"
			' 
			' BackgroundFillStyleComboBox
			' 
			Me.BackgroundFillStyleComboBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.BackgroundFillStyleComboBox.Location = New System.Drawing.Point(0, 19)
			Me.BackgroundFillStyleComboBox.Name = "BackgroundFillStyleComboBox"
			Me.BackgroundFillStyleComboBox.Size = New System.Drawing.Size(302, 21)
			Me.BackgroundFillStyleComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackgroundFillStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundFillStyleComboBox_SelectedIndexChanged_1);
			' 
			' ImageFrameStyleEditorUC
			' 
			Me.ImageFrameStyleEditorUC.Dock = System.Windows.Forms.DockStyle.Top
			Me.ImageFrameStyleEditorUC.Location = New System.Drawing.Point(0, 40)
			Me.ImageFrameStyleEditorUC.Name = "ImageFrameStyleEditorUC"
			Me.ImageFrameStyleEditorUC.Size = New System.Drawing.Size(302, 384)
			Me.ImageFrameStyleEditorUC.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ImageFrameStyleEditorUC.StyleChanged += new System.EventHandler(this.ImageFrameStyleEditorUC_ImageFrameStyleChanged);
			' 
			' NImageFrameStyleUC
			' 
			Me.Controls.Add(Me.ImageFrameStyleEditorUC)
			Me.Controls.Add(Me.BackgroundFillStyleComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NImageFrameStyleUC"
			Me.Size = New System.Drawing.Size(302, 496)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_ImageFrameStyle = New NImageFrameStyle()
			nChartControl1.BackgroundStyle.FrameStyle = m_ImageFrameStyle
			ImageFrameStyleEditorUC.Style = m_ImageFrameStyle

			nChartControl1.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant2, Color.AliceBlue, Color.LightGray)

			Dim title As New NLabel("Image Background Frame")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(Color.Navy)
			title.TextStyle.BackplaneStyle.Visible = False

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
		End Sub

		Private Sub ImageFrameStyleEditorUC_ImageFrameStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImageFrameStyleEditorUC.StyleChanged
			nChartControl1.BackgroundStyle.FrameStyle = DirectCast(ImageFrameStyleEditorUC.Style, NImageFrameStyle)
			nChartControl1.Refresh()
		End Sub

		Private Sub BackgroundFillStyleComboBox_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackgroundFillStyleComboBox.SelectedIndexChanged
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
	End Class
End Namespace
