Imports Microsoft.VisualBasic
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
Imports Nevron.Dom
Imports Nevron.Chart.WinForm
Imports System.Collections.Generic
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomDragToolUC
		Inherits NExampleBaseUC
		Private m_Chart As NChart
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
			' NCustomDragToolUC
			' 
			Me.Name = "NCustomDragToolUC"
			Me.Size = New System.Drawing.Size(180, 358)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Custom Drag Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' configure the x scale
			Dim xScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale

			' configure the y scale
			Dim yScale As NLinearScaleConfigurator = New NLinearScaleConfigurator()

			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			yScale.StripStyles.Add(stripStyle)

			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale

			' Create a point series
			Dim pnt As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			pnt.InflateMargins = True
			pnt.UseXValues = True
			pnt.Name = "Series 1"
			pnt.DataLabelStyle.Visible = False

			' Add some data
			pnt.Values.Add(31)
			pnt.Values.Add(67)
			pnt.Values.Add(12)
			pnt.Values.Add(84)
			pnt.Values.Add(90)

			pnt.XValues.Add(5)
			pnt.XValues.Add(36)
			pnt.XValues.Add(51)
			pnt.XValues.Add(76)
			pnt.XValues.Add(93)

			' Add a constline for the left axis
			Dim cl1 As NAxisConstLine = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			cl1.StrokeStyle.Color = Color.SteelBlue
			cl1.StrokeStyle.Width = New NLength(1.5f)
			cl1.FillStyle = New NColorFillStyle(New NArgbColor(125, Color.SteelBlue))
			cl1.Text = "Press the left mouse key and start dragging"
			cl1.Value = 40

			Dim cl2 As NAxisConstLine = m_Chart.Axis(StandardAxis.PrimaryY).ConstLines.Add()
			cl2.StrokeStyle.Color = Color.OrangeRed
			cl2.StrokeStyle.Width = New NLength(1.5f)
			cl2.FillStyle = New NColorFillStyle(New NArgbColor(125, Color.SteelBlue))
			cl2.Text = "Press the left mouse key and start dragging"
			cl2.Value = 60

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			nChartControl1.Refresh()

			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New MyCustomDragTool())
		End Sub

		<Serializable> _
		Public Class MyCustomDragTool
			Inherits NDragTool
			#Region "Constructors"

			''' <summary>
			''' Creates a new NTrackballTool operation.
			''' </summary>
			''' <remarks>
			''' You must add the object to the InteractivityCollection of 
			''' the control in order to enable the trackball feature.
			''' </remarks>
			Public Sub New()

			End Sub

			#End Region

			#Region "Properties"


			#End Region

			#Region "Overrides"

			''' <summary>
			''' Return true if dragging can start
			''' </summary>
			''' <returns></returns>
            Public Overrides Function CanBeginDrag(ByVal sender As Object, ByVal e As NMouseEventArgs) As Boolean
                Dim constLines As Object() = GetSelectedObjectsOfType(GetType(NAxisConstLine))

                If constLines.Length = 0 Then
                    Return False
                End If

                m_ConstLine = CType(constLines(0), NAxisConstLine)
                m_OrgValue = m_ConstLine.Value

                Return True
            End Function
			''' <summary>
			''' Overriden to perform dragging
			''' </summary>
			''' <param name="sender"></param>
			''' <param name="e"></param>
			Public Overrides Sub OnDoDrag(ByVal sender As Object, ByVal e As NMouseEventArgs)
				Dim chart As NChart = Me.GetDocument().Charts(0)
				Dim viewToScale As NViewToScale2DTransformation = New NViewToScale2DTransformation(Me.GetView().Context, chart, CInt(Fix(StandardAxis.PrimaryX)), CInt(Fix(StandardAxis.PrimaryY)))

				Dim pointScale As NVector2DD = New NVector2DD()
				If viewToScale.Transform(New NPointF(e.X, e.Y), pointScale) Then
					' clamp y value to ruler range
					Dim yValue As Double = chart.Axis(StandardAxis.PrimaryY).Scale.RulerRange.GetValueInRange(pointScale.Y)
					m_ConstLine.Value = yValue

					chart.Refresh()
					Repaint()
				End If
			End Sub
			''' <summary>
			''' Overriden to rever the state to the original one if the user presses Esc key
			''' </summary>
			Public Overrides Sub CancelOperation()
				MyBase.CancelOperation()

				m_ConstLine.Value = m_OrgValue
				Repaint()
			End Sub

			#End Region

			#Region "Fields"

			Protected m_ConstLine As NAxisConstLine
			Protected m_OrgValue As Double

			#End Region

			#Region "Default values"

			#End Region
		End Class
	End Class
End Namespace
