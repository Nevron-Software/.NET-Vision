Imports Microsoft.VisualBasic
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
	Public Class NCustomScaleDecorations2UC
		Inherits NExampleBaseUC
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			Me.SuspendLayout()
			' 
			' NCustomScaleDecorations2UC
			' 
			Me.Name = "NCustomScaleDecorations2UC"
			Me.Size = New System.Drawing.Size(201, 495)
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Private Structure NLabelInfo
			#Region "Constructors"

'INSTANT VB NOTE: The parameter value was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter text was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter foreColor was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter backColor was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Public Sub New(ByVal value_Renamed As Double, ByVal text_Renamed As String, ByVal foreColor_Renamed As Color, ByVal backColor_Renamed As Color)
				Value = value_Renamed
				Text = text_Renamed
				ForeColor = foreColor_Renamed
				BackColor = backColor_Renamed
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

			   nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Custom Scale Decorations")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.SendToBack()
			title.Margins = New NMarginsL(20, 10, 20, 20)
			title.DockMode = PanelDockMode.Top

			Dim chart As NCartesianChart = New NCartesianChart()
			nChartControl1.Panels.Add(chart)
			chart.BoundsMode = BoundsMode.Stretch
			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(20, 2, 20, 20)
			chart.BackgroundFillStyle = New NColorFillStyle(Color.FromArgb(231, 231, 233))
			chart.MaxDockZoneMargins = New NMarginsL(100000, 100000, 100000, 100000)

			Dim strokeBorder As NStrokeBorderStyle = New NStrokeBorderStyle()
			strokeBorder.StrokeStyle.Color = Color.FromArgb(192, 192, 192)
			chart.BorderStyle =strokeBorder

			Dim dpCount As Integer = 8
			Dim bar1Values As Double() = New Double(dpCount - 1){}
			Dim bar2Values As Double() = New Double(dpCount - 1){}
			Dim xLabels As NLabelInfo() = New NLabelInfo(dpCount - 1){}

			' add some dummy data
			Dim rand As Random = New Random()
			Dim i As Integer = 0
			Do While i < dpCount
				bar1Values(i) = rand.Next(100)
				bar2Values(i) = rand.Next(100)
				If i Mod 2 = 0 Then
					xLabels(i) = New NLabelInfo(i, "Label" & i.ToString(), Color.FromArgb(100, 100, 100),Color.Red)
				Else
					xLabels(i) = New NLabelInfo(i, "Label" & i.ToString(), Color.FromArgb(100, 100, 100),Color.Orange)
				End If
				i += 1
			Loop

			Dim yLabels As NLabelInfo() = New NLabelInfo(8){}
			For i = 0 To 8
				yLabels(i).Text = ((i + 1) * 10).ToString() & "%"
				yLabels(i).Value = (i + 1) * 10
				yLabels(i).ForeColor = Color.FromArgb(100, 100, 100)
				yLabels(i).BackColor = Color.Transparent
			Next i

			' add two bars series in cluster mode
			Dim bar1 As NBarSeries = New NBarSeries()
			bar1.Values.AddRange(bar1Values)
			bar1.DataLabelStyle.Visible = False
			bar1.MultiBarMode = MultiBarMode.Clustered
			bar1.FillStyle = New NColorFillStyle(Color.FromArgb(21, 153, 215))
			bar1.FillStyle.ImageFiltersStyle.Filters.Add(New NBevelAndEmbossImageFilter())
			bar1.WidthPercent = 50
			bar1.GapPercent = 20
			chart.Series.Add(bar1)

			Dim bar2 As NBarSeries = New NBarSeries()
			bar2.Values.AddRange(bar2Values)
			bar2.DataLabelStyle.Visible = False
			bar2.MultiBarMode = MultiBarMode.Clustered
			bar2.FillStyle = New NColorFillStyle(Color.FromArgb(113, 127, 138))
			bar2.FillStyle.ImageFiltersStyle.Filters.Add(New NBevelAndEmbossImageFilter())
			bar2.WidthPercent = 50
			bar2.GapPercent = 20
			chart.Series.Add(bar2)

			' add custom labels to the x axis
			Dim xScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale
			chart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(New NRange1DD(-0.5, xLabels.Length - 0.5), True, True)
			xScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(100, 100, 100))
			xScale.AutoLabels = False
			xScale.OuterMajorTickStyle.Visible = False
			xScale.InnerMajorTickStyle.Visible = False
			xScale.LabelStyle.Offset = New NLength(10)
			xScale.RulerStyle.BorderStyle.Width = New NLength(0)
			xScale.RulerStyle.Height = New NLength(0)

			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(240, 240, 240)), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			xScale.StripStyles.Add(stripStyle)

			' hide the back wall
			chart.Wall(ChartWallType.Back).Visible = False

			' configure the Y axis
			chart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(New NRange1DD(0, 100), True, True)
			Dim yScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			yScale.AutoLabels = False
			yScale.MajorTickMode = MajorTickMode.CustomTicks
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScale.MajorGridStyle.LineStyle.Color = Color.FromArgb(192, 192, 192)
			yScale.OuterMajorTickStyle.Visible = False
			yScale.InnerMajorTickStyle.Visible = False
			yScale.RulerStyle.BorderStyle.Width = New NLength(0)
			yScale.RulerStyle.Height = New NLength(0)
			yScale.CreateNewLevelForCustomLabels = True

			' add labels 
			Dim xAxis As NAxis = chart.Axis(StandardAxis.PrimaryX)
			Dim yAxis As NAxis = chart.Axis(StandardAxis.PrimaryY)

			AddLabels(xAxis, True, xLabels)
			AddLabels(yAxis, True, yLabels)

			' create cross
			Dim xDecorator As NCustomWallDecorator = New NCustomWallDecorator()
			xDecorator.WallDecorations.Add(New NGridLine(-0.5, New NStrokeStyle(Color.FromArgb(190, 190, 190)), New ChartWallType() { ChartWallType.Back }, True))
			xAxis.Scale.WallDecorators.Add(xDecorator)

			Dim yDecorator As NCustomWallDecorator = New NCustomWallDecorator()
			yDecorator.WallDecorations.Add(New NGridLine(0, New NStrokeStyle(Color.FromArgb(190, 190, 190)), New ChartWallType() { ChartWallType.Back }, True))
			yAxis.Scale.WallDecorators.Add(yDecorator)
		End Sub

		Private Shared Sub AddLabels(ByVal axis As NAxis, ByVal addTicks As Boolean, ByVal labels As NLabelInfo())
			' First add custom labels
			Dim scale As NLinearScaleConfigurator = TryCast(axis.ScaleConfigurator, NLinearScaleConfigurator)

			Dim i As Integer = 0
			Do While i < labels.Length
				Dim labelInfo As NLabelInfo = labels(i)

				Dim label As NCustomValueLabel = New NCustomValueLabel()
				label.Value = labelInfo.Value
				label.Text = labelInfo.Text
				label.Style.Offset = New NLength(10)
				label.Style.TextStyle.FillStyle = New NColorFillStyle(labelInfo.ForeColor)

				scale.CustomLabels.Add(label)

				If addTicks Then
					scale.CustomMajorTicks.Add(labelInfo.Value - 0.5)
				End If
				i += 1
			Loop

			axis.UpdateScale()

			' then add background coloring
			Dim level As NScaleLevel = CType(axis.Scale.Levels(axis.Scale.Levels.Count - 1), NScaleLevel)

			level.TopPadding = New NLength(-1)

			Dim rulerLevel As NScaleLevel = CType(axis.Scale.Levels(0), NScaleLevel)
			rulerLevel.TopPadding = New NLength(0)
			rulerLevel.BottomPadding = New NLength(0)
			Dim scaleDecorator As NCustomScaleDecorator = New NCustomScaleDecorator()

			i = 0
			Do While i < labels.Length
				Dim labelInfo As NLabelInfo = labels(i)

				If Not labelInfo.BackColor.Equals(Color.Transparent) Then
					scaleDecorator.Decorations.Add(New NScaleRange(0, New NScaleRangeDecorationAnchor(New NRange1DD(labelInfo.Value - 0.5, labelInfo.Value + 0.5)), New NColorFillStyle(labelInfo.BackColor), New NLength(0), New NLength(20), New NLength(20)))
				End If
				i += 1
			Loop

			level.Decorators.Add(scaleDecorator)
		End Sub
	End Class
End Namespace