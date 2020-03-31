Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NMultipleAxesZoomingAndScrollingUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary 
		''' Clean up any resources being used.
		''' </summary
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NMultipleAxesZoomingAndScrollingUC
			' 
			Me.Name = "NMultipleAxesZoomingAndScrollingUC"
			Me.Size = New System.Drawing.Size(180, 664)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Multiple Axes Zooming and Scrolling")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' configure chart
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.RangeSelections.Add(New NRangeSelection())

			' 2D line chart
			chart.BoundsMode = BoundsMode.Stretch

			' configure axis paging and set a mimimum range length on the axisthis will prevent the user from zooming too much
			chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True

			Dim palette As New NChartPalette(ChartPredefinedPalette.Fresh)
			Dim color1 As Color = palette.SeriesColors(0)
			Dim color2 As Color = palette.SeriesColors(3)

			Dim primaryY As NAxis = chart.Axis(StandardAxis.PrimaryY)
			primaryY.ScaleConfigurator.Title.Text = "Primary Y Axis"
			ApplyColorToAxis(primaryY, color1)
			primaryY.ScrollBar.Visible = True
			AddHandler primaryY.Scale.RulerRangeChanged, AddressOf Scale_RulerRangeChanged

			Dim secondaryY As NAxis = chart.Axis(StandardAxis.SecondaryY)
			secondaryY.ScaleConfigurator.Title.Text = "Secondary Y Axis"
			ApplyColorToAxis(secondaryY, color2)
			secondaryY.Visible = True

			Dim line1 As New NLineSeries()
			line1.BorderStyle.Color = color1
			line1.BorderStyle.Width = New NLength(2)
			chart.Series.Add(line1)

			line1.DataLabelStyle.Visible = False

			Dim line2 As New NLineSeries()
			line2.BorderStyle.Color = color2
			line2.BorderStyle.Width = New NLength(2)
			chart.Series.Add(line2)

			line2.DataLabelStyle.Visible = False
			line2.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line2.DisplayOnAxis(StandardAxis.SecondaryY, True)

			For i As Integer = 0 To 719
				Dim angle As Double = i * NMath.Degree2Rad

				Dim value1 As Double = Math.Sin(angle)
				Dim value2 As Double = Math.Sin(angle + 40) * 100

				line1.Values.Add(value1)
				line2.Values.Add(value2)
			Next i

			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())
			nChartControl1.Controller.Tools.Add(New NDataZoomTool())
			nChartControl1.Controller.Tools.Add(New NDataPanTool())
		End Sub

		Private Sub ApplyColorToAxis(ByVal axis As NAxis, ByVal color As Color)
'INSTANT VB NOTE: The variable scale was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim scale_Renamed As NLinearScaleConfigurator = CType(axis.ScaleConfigurator, NLinearScaleConfigurator)

			scale_Renamed.InnerMajorTickStyle.LineStyle.Color = color
			scale_Renamed.InnerMinorTickStyle.LineStyle.Color = color
			scale_Renamed.OuterMajorTickStyle.LineStyle.Color = color
			scale_Renamed.OuterMinorTickStyle.LineStyle.Color = color
			scale_Renamed.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(color)
			scale_Renamed.Title.TextStyle.FillStyle = New NColorFillStyle(color)
			scale_Renamed.RulerStyle.BorderStyle.Color = color
		End Sub

		Private Sub Scale_RulerRangeChanged(ByVal sender As Object, ByVal e As EventArgs)
			 Dim chart As NChart = nChartControl1.Charts(0)

			Dim contentRange As NRange1DD = chart.Axis(StandardAxis.PrimaryY).ContentRange
			 Dim viewRange As NRange1DD = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange

			 ' compute factors
			 Dim beginFactor As Double = contentRange.GetValueFactor(viewRange.Begin)
			 Dim endFactor As Double = contentRange.GetValueFactor(viewRange.End)

			 ' then for all other y axes make sure their view range factor equals to begin/end factor
			 If beginFactor = 0.0 AndAlso endFactor = 1.0 Then
				 ' disable zoom
				 For Each axis As NAxis In chart.Axes
					 If axis.AxisId <> CInt(StandardAxis.PrimaryY) AndAlso axis.AxisOrientation = AxisOrientation.Vertical Then
						 axis.PagingView.Enabled = False
					 End If
				 Next axis
			 Else
				 ' disable zoom
				 For Each axis As NAxis In chart.Axes
					 If (axis.AxisId <> CInt(StandardAxis.PrimaryY)) AndAlso (axis.AxisOrientation = AxisOrientation.Vertical) Then
						 axis.PagingView.Enabled = True

						 ' compute the new range based on factor
						 Dim axisContentRange As NRange1DD = axis.ContentRange
						 Dim rangeLength As Double = axisContentRange.End - axisContentRange.Begin

						 Dim begin As Double = axisContentRange.Begin + beginFactor * rangeLength
						 Dim [end] As Double = axisContentRange.Begin + endFactor * rangeLength

						 axis.PagingView.ZoomIn(New NRange1DD(begin, [end]), 0.0001)
					 End If
				 Next axis
			 End If

			 nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
