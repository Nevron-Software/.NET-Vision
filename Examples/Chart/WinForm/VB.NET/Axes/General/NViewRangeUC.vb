Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NViewRangeUC
		Inherits NExampleBaseUC

		Private WithEvents UseCustomViewRangeCheckBox As UI.WinForm.Controls.NCheckBox
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
			Me.UseCustomViewRangeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' UseCustomViewRangeCheckBox
			' 
			Me.UseCustomViewRangeCheckBox.AutoSize = True
			Me.UseCustomViewRangeCheckBox.ButtonProperties.BorderOffset = 2
			Me.UseCustomViewRangeCheckBox.Location = New System.Drawing.Point(15, 16)
			Me.UseCustomViewRangeCheckBox.Name = "UseCustomViewRangeCheckBox"
			Me.UseCustomViewRangeCheckBox.Size = New System.Drawing.Size(122, 17)
			Me.UseCustomViewRangeCheckBox.TabIndex = 3
			Me.UseCustomViewRangeCheckBox.Text = "Custom View Range"
			Me.UseCustomViewRangeCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseCustomViewRangeCheckBox.CheckedChanged += new System.EventHandler(this.UseCustomViewRangeCheckBox_CheckedChanged);
			' 
			' NViewRangeUC
			' 
			Me.Controls.Add(Me.UseCustomViewRangeCheckBox)
			Me.Name = "NViewRangeUC"
			Me.Size = New System.Drawing.Size(202, 182)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis View Range")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' turn off the legend
			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit

			' apply predefined lighting and projection
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.ShadowStyle.Type = ShadowType.GaussianBlur
			bar.ShadowStyle.Offset = New NPointL(2, 2)
			bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			bar.ShadowStyle.FadeLength = New NLength(5)
			bar.HasBottomEdge = False

			' add some data to the bar series
			bar.AddDataPoint(New NDataPoint(18, "C++"))
			bar.AddDataPoint(New NDataPoint(15, "Ruby"))
			bar.AddDataPoint(New NDataPoint(21, "Python"))
			bar.AddDataPoint(New NDataPoint(23, "Java"))
			bar.AddDataPoint(New NDataPoint(27, "Javascript"))
			bar.AddDataPoint(New NDataPoint(29, "C#"))
			bar.AddDataPoint(New NDataPoint(26, "PHP"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document.Charts(0))

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))
		End Sub

		Private Sub UseCustomViewRangeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseCustomViewRangeCheckBox.CheckedChanged
			Dim chart As NChart = nChartControl1.Charts(0)

			If UseCustomViewRangeCheckBox.Checked Then
				' specify custom view range
				chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(14, 30), True, True)
			Else
				chart.Axis(StandardAxis.PrimaryY).View = New NContentAxisView()
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
