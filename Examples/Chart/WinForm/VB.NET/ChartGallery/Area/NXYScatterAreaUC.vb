Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NXYScatterAreaUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Area As NAreaSeries
		Private WithEvents ChangeXValuesButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrimaryXRoundToTick As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InvertXCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents InvertYCheck As Nevron.UI.WinForm.Controls.NCheckBox
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
			Me.ChangeXValuesButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrimaryXRoundToTick = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InvertXCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.InvertYCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ChangeXValuesButton
			' 
			Me.ChangeXValuesButton.Location = New System.Drawing.Point(8, 10)
			Me.ChangeXValuesButton.Name = "ChangeXValuesButton"
			Me.ChangeXValuesButton.Size = New System.Drawing.Size(158, 24)
			Me.ChangeXValuesButton.TabIndex = 1
			Me.ChangeXValuesButton.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValuesButton.Click += new System.EventHandler(this.ChangeXValuesButton_Click);
			' 
			' PrimaryXRoundToTick
			' 
			Me.PrimaryXRoundToTick.ButtonProperties.BorderOffset = 2
			Me.PrimaryXRoundToTick.Location = New System.Drawing.Point(8, 53)
			Me.PrimaryXRoundToTick.Name = "PrimaryXRoundToTick"
			Me.PrimaryXRoundToTick.Size = New System.Drawing.Size(171, 19)
			Me.PrimaryXRoundToTick.TabIndex = 2
			Me.PrimaryXRoundToTick.Text = "X Axis Round To Tick"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrimaryXRoundToTick.CheckedChanged += new System.EventHandler(this.PrimaryXRoundToTick_CheckedChanged);
			' 
			' InvertXCheck
			' 
			Me.InvertXCheck.ButtonProperties.BorderOffset = 2
			Me.InvertXCheck.Location = New System.Drawing.Point(8, 84)
			Me.InvertXCheck.Name = "InvertXCheck"
			Me.InvertXCheck.Size = New System.Drawing.Size(171, 19)
			Me.InvertXCheck.TabIndex = 3
			Me.InvertXCheck.Text = "Invert X Axis Ruler"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertXCheck.CheckedChanged += new System.EventHandler(this.InvertXCheck_CheckedChanged);
			' 
			' InvertYCheck
			' 
			Me.InvertYCheck.ButtonProperties.BorderOffset = 2
			Me.InvertYCheck.Location = New System.Drawing.Point(8, 107)
			Me.InvertYCheck.Name = "InvertYCheck"
			Me.InvertYCheck.Size = New System.Drawing.Size(171, 19)
			Me.InvertYCheck.TabIndex = 4
			Me.InvertYCheck.Text = "Invert Y Axis Ruler"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InvertYCheck.CheckedChanged += new System.EventHandler(this.InvertYCheck_CheckedChanged);
			' 
			' NXYScatterAreaUC
			' 
			Me.Controls.Add(Me.InvertYCheck)
			Me.Controls.Add(Me.InvertXCheck)
			Me.Controls.Add(Me.PrimaryXRoundToTick)
			Me.Controls.Add(Me.ChangeXValuesButton)
			Me.Name = "NXYScatterAreaUC"
			Me.Size = New System.Drawing.Size(180, 277)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("XY Area Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' setup the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' apply linear scaling to the x axis
			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			linearScale = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			' add the area series
			m_Area = CType(m_Chart.Series.Add(SeriesType.Area), NAreaSeries)
			m_Area.Name = "Area Series"
			m_Area.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Area.DataLabelStyle.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			m_Area.DataLabelStyle.TextStyle.BackplaneStyle.StandardFrameStyle.InnerBorderColor = Color.Crimson
			m_Area.DataLabelStyle.Format = "<value>"
			m_Area.UseXValues = True

			' add xy values
			m_Area.AddDataPoint(New NDataPoint(12, 10))
			m_Area.AddDataPoint(New NDataPoint(25, 23))
			m_Area.AddDataPoint(New NDataPoint(45, 12))
			m_Area.AddDataPoint(New NDataPoint(55, 24))
			m_Area.AddDataPoint(New NDataPoint(61, 16))
			m_Area.AddDataPoint(New NDataPoint(69, 19))
			m_Area.AddDataPoint(New NDataPoint(78, 17))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			PrimaryXRoundToTick.Checked = True
		End Sub


		Private Sub ChangeXValuesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValuesButton.Click
			m_Area.XValues(0) = CDbl(Random.Next(10))

			For i As Integer = 1 To m_Area.XValues.Count - 1
				m_Area.XValues(i) = DirectCast(m_Area.XValues(i - 1), Double) + Random.Next(1, 10)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub PrimaryXRoundToTick_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrimaryXRoundToTick.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.RoundToTickMax = PrimaryXRoundToTick.Checked
			linearScale.RoundToTickMin = PrimaryXRoundToTick.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub InvertXCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InvertXCheck.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.Invert = InvertXCheck.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub InvertYCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InvertYCheck.CheckedChanged
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.Invert = InvertYCheck.Checked

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace