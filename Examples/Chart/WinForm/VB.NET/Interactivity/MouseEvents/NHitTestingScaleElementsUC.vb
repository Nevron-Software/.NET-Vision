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
	Public Class NHitTestingScaleElementsUC
		Inherits NExampleBaseUC

		Private label7 As Label
		Private AxisElementTextBox As UI.WinForm.Controls.NTextBox
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
			Me.label7 = New System.Windows.Forms.Label()
			Me.AxisElementTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(3, 11)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(191, 16)
			Me.label7.TabIndex = 21
			Me.label7.Text = "Axis Element:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' AxisElementTextBox
			' 
			Me.AxisElementTextBox.Location = New System.Drawing.Point(6, 30)
			Me.AxisElementTextBox.Name = "AxisElementTextBox"
			Me.AxisElementTextBox.ReadOnly = True
			Me.AxisElementTextBox.Size = New System.Drawing.Size(171, 18)
			Me.AxisElementTextBox.TabIndex = 22
			' 
			' NHitTestingScaleElementsUC
			' 
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.AxisElementTextBox)
			Me.Name = "NHitTestingScaleElementsUC"
			Me.Size = New System.Drawing.Size(180, 495)
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Private Structure NLabelInfo
			#Region "Constructors"

			Public Sub New(ByVal value As Double, ByVal text As String, ByVal foreColor As Color, ByVal backColor As Color)
				Me.Value = value
				Me.Text = text
				Me.ForeColor = foreColor
				Me.BackColor = backColor
			End Sub

			#End Region

			#Region "Fields"

			Public Value As Double
			Public Text As String
			Public ForeColor As Color
			Public BackColor As Color

			#End Region
		End Structure

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' create a title
			Dim title As New NLabel("Hit Testing Scale Elements")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' hide the legend
			nChartControl1.Legends(0).Visible = False

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim scaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			scaleY.Title.Text = "Y Axis Title"
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			scaleY.StripStyles.Add(stripStyle)

			' add the line
			Dim line As NLineSeries = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			line.LineSegmentShape = LineSegmentShape.Line
			line.DataLabelStyle.Visible = False
			line.Legend.Mode = SeriesLegendMode.DataPoints
			line.InflateMargins = True
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			line.Name = "Line Series"
			line.UseXValues = True

			' add xy values
			line.AddDataPoint(New NDataPoint(15, 10))
			line.AddDataPoint(New NDataPoint(25, 23))
			line.AddDataPoint(New NDataPoint(45, 12))

			ConfigureAxis(chart.Axis(StandardAxis.PrimaryX))
			ConfigureAxis(chart.Axis(StandardAxis.PrimaryY))

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove
		End Sub

		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If result.Axis Is Nothing Then
				AxisElementTextBox.Text = "The mouse is not over an axis."
			Else
'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim text_Renamed As String = "The mouse is over "

				Select Case result.AxisScalePartId
					Case 1
						text_Renamed &= "an inner major tick."
					Case 2
						text_Renamed &= "an outer major tick."
					Case 3
						text_Renamed &= "an inner minor tick."
					Case 4
						text_Renamed &= "an outer minor tick."
					Case 5
						text_Renamed &= "a ruler."
					Case 6
						text_Renamed &= "an auto label."
					Case 7
						text_Renamed &= "a title."
				End Select

				AxisElementTextBox.Text = text_Renamed
			End If
		End Sub

		Private Sub ConfigureAxis(ByVal axis As NAxis)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As New NLinearScaleConfigurator()
			axis.ScaleConfigurator = scale_Renamed

			scale_Renamed.InnerMajorTickStyle.LineStyle.Color = Color.Red
			scale_Renamed.InnerMajorTickStyle.Length = New NLength(10)
			scale_Renamed.InnerMajorTickStyle.Visible = True
			scale_Renamed.InnerMajorTickStyle.PartId = 1

			scale_Renamed.OuterMajorTickStyle.Length = New NLength(10)
			scale_Renamed.OuterMajorTickStyle.PartId = 2

			scale_Renamed.InnerMinorTickStyle.LineStyle.Color = Color.Red
			scale_Renamed.InnerMinorTickStyle.Length = New NLength(5)
			scale_Renamed.InnerMinorTickStyle.Visible = True
			scale_Renamed.InnerMinorTickStyle.PartId = 3

			scale_Renamed.OuterMinorTickStyle.Length = New NLength(5)
			scale_Renamed.OuterMinorTickStyle.PartId = 4

			scale_Renamed.RulerStyle.PartId = 5

			scale_Renamed.LabelStyle.PartId = 6
			scale_Renamed.LabelStyle.TextStyle.FontStyle.EmSize = New NLength(15)

			scale_Renamed.Title.Text = "Axis Title"
			scale_Renamed.Title.TextStyle.FontStyle.EmSize = New NLength(18)
			scale_Renamed.Title.PartId = 7
		End Sub
	End Class
End Namespace