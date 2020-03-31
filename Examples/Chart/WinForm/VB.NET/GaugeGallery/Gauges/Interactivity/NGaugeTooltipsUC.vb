Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGaugeTooltipsUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents NeedleTooltipTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents MarkerTooltipTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents RangeTooltipTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents ScaleTooltipTextBox As Nevron.UI.WinForm.Controls.NTextBox
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Private m_Indicator1 As NRangeIndicator
		Private m_Indicator2 As NNeedleValueIndicator
		Private m_Indicator3 As NMarkerValueIndicator
		Private m_Axis As NGaugeAxis

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
		End Sub

		Public Overrides Sub Initialize()
			nChartControl1.Panels.Clear()

			' set a chart title
			Dim header As New NLabel("Gauge Tooltips")
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.ContentAlignment = ContentAlignment.BottomRight
			header.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(header)

			' create the radial gauge
			Dim radialGauge As New NRadialGaugePanel()
			radialGauge.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			radialGauge.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			radialGauge.PaintEffect = New NGlassEffectStyle()
			radialGauge.BorderStyle = New NEdgeBorderStyle(BorderShape.Auto)
			radialGauge.BackgroundFillStyle = New NAdvancedGradientFillStyle(AdvancedGradientScheme.WhiteOnBlack, 0)

			' configure scale
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = TryCast(DirectCast(radialGauge.Axes(0), NGaugeAxis).ScaleConfigurator, NLinearScaleConfigurator)
			scale_Renamed.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke)
			scale_Renamed.LabelFitModes = New LabelFitMode(){}
			scale_Renamed.MinorTickCount = 3
			scale_Renamed.RulerStyle.FillStyle = New NColorFillStyle(Color.FromArgb(40, Color.White))
			scale_Renamed.OuterMajorTickStyle.FillStyle = New NColorFillStyle(Color.Orange)
			scale_Renamed.LabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 12, FontStyle.Bold Or FontStyle.Italic)
			scale_Renamed.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.White)

			m_Axis = DirectCast(radialGauge.Axes(0), NGaugeAxis)

			nChartControl1.Panels.Add(radialGauge)

			m_Indicator1 = New NRangeIndicator()
			m_Indicator1.Value = 50
			m_Indicator1.FillStyle = New NColorFillStyle(Color.LightBlue)
			m_Indicator1.StrokeStyle.Color = Color.DarkBlue
			m_Indicator1.EndWidth = New NLength(20)
			radialGauge.Indicators.Add(m_Indicator1)

			m_Indicator2 = New NNeedleValueIndicator()
			m_Indicator2.Value = 79
			m_Indicator2.Shape.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.White, Color.Red)
			m_Indicator2.Shape.StrokeStyle.Color = Color.Red
			radialGauge.Indicators.Add(m_Indicator2)
			radialGauge.SweepAngle = 270

			m_Indicator3 = New NMarkerValueIndicator()
			m_Indicator3.Value = 90
			radialGauge.Indicators.Add(m_Indicator3)

			nChartControl1.Controller.Tools.Add(New NTooltipTool())

			' init form controls
			UpdateTooltips()
		End Sub

		Private Sub UpdateTooltips()
			If m_Axis Is Nothing Then
				Return
			End If

			m_Indicator1.InteractivityStyle.Tooltip.Text = RangeTooltipTextBox.Text
			m_Indicator2.InteractivityStyle.Tooltip.Text = NeedleTooltipTextBox.Text
			m_Indicator3.InteractivityStyle.Tooltip.Text = MarkerTooltipTextBox.Text
			m_Axis.InteractivityStyle.Tooltip.Text = ScaleTooltipTextBox.Text
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
			Me.NeedleTooltipTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.RangeTooltipTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.ScaleTooltipTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.MarkerTooltipTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(171, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Needle Tooltip:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' NeedleTooltipTextBox
			' 
			Me.NeedleTooltipTextBox.Location = New System.Drawing.Point(5, 45)
			Me.NeedleTooltipTextBox.Name = "NeedleTooltipTextBox"
			Me.NeedleTooltipTextBox.Size = New System.Drawing.Size(171, 18)
			Me.NeedleTooltipTextBox.TabIndex = 1
			Me.NeedleTooltipTextBox.Text = "Needle Tooltip"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NeedleTooltipTextBox.TextChanged += new System.EventHandler(this.NeedleTooltipTextBox_TextChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 126)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(171, 23)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Range Tooltip:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' RangeTooltipTextBox
			' 
			Me.RangeTooltipTextBox.Location = New System.Drawing.Point(5, 155)
			Me.RangeTooltipTextBox.Name = "RangeTooltipTextBox"
			Me.RangeTooltipTextBox.Size = New System.Drawing.Size(171, 18)
			Me.RangeTooltipTextBox.TabIndex = 5
			Me.RangeTooltipTextBox.Text = "Range Tooltip"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RangeTooltipTextBox.TextChanged += new System.EventHandler(this.RangeTooltipTextBox_TextChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(5, 181)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(171, 23)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Scale Tooltip:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' ScaleTooltipTextBox
			' 
			Me.ScaleTooltipTextBox.Location = New System.Drawing.Point(5, 210)
			Me.ScaleTooltipTextBox.Name = "ScaleTooltipTextBox"
			Me.ScaleTooltipTextBox.Size = New System.Drawing.Size(171, 18)
			Me.ScaleTooltipTextBox.TabIndex = 7
			Me.ScaleTooltipTextBox.Text = "Scale Tooltip"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ScaleTooltipTextBox.TextChanged += new System.EventHandler(this.ScaleTooltipTextBox_TextChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(5, 71)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(171, 23)
			Me.label4.TabIndex = 2
			Me.label4.Text = "Marker Tooltip:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			' 
			' MarkerTooltipTextBox
			' 
			Me.MarkerTooltipTextBox.Location = New System.Drawing.Point(5, 100)
			Me.MarkerTooltipTextBox.Name = "MarkerTooltipTextBox"
			Me.MarkerTooltipTextBox.Size = New System.Drawing.Size(171, 18)
			Me.MarkerTooltipTextBox.TabIndex = 3
			Me.MarkerTooltipTextBox.Text = "Marker Tooltip"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MarkerTooltipTextBox.TextChanged += new System.EventHandler(this.MarkerTooltipTextBox_TextChanged);
			' 
			' NGaugeTooltipsUC
			' 
			Me.Controls.Add(Me.MarkerTooltipTextBox)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ScaleTooltipTextBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.RangeTooltipTextBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.NeedleTooltipTextBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NGaugeTooltipsUC"
			Me.Size = New System.Drawing.Size(180, 264)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub NeedleTooltipTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NeedleTooltipTextBox.TextChanged
			UpdateTooltips()
		End Sub

		Private Sub MarkerTooltipTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarkerTooltipTextBox.TextChanged
			UpdateTooltips()
		End Sub

		Private Sub RangeTooltipTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RangeTooltipTextBox.TextChanged
			UpdateTooltips()
		End Sub

		Private Sub ScaleTooltipTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ScaleTooltipTextBox.TextChanged
			UpdateTooltips()
		End Sub
	End Class
End Namespace
