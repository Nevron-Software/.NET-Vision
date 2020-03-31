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
Imports Nevron.Chart.View


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomToolUC
		Inherits NExampleBaseUC
		Private m_Chart As NChart
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
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
			' NCustomToolUC
			' 
			Me.Name = "NCustomToolUC"
			Me.Size = New System.Drawing.Size(180, 358)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Custom Interactivity Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As NScaleStripStyle = New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add a bar series
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Format = "<value>"

			' add another bar series
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Clustered
			m_Bar2.DataLabelStyle.Format = "<value>"

			' fill with random data
			m_Bar1.Values.FillRandomRange(Random, 5, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, 5, 10, 500)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			nChartControl1.Controller.Tools.Add(New MyCustomTool())
		End Sub

		<Serializable> _
		Public Class MyCustomTool
			Inherits NTool
			#Region "Construcotrs"

			Public Sub New()
				m_MaxTransparencyPercent = 90
				m_SeriesToPercents = New Dictionary(Of NSeries, Single)()
			End Sub

			#End Region

			#Region "Event handlers"

			Private Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
				Dim view As NView = GetView()

				If view Is Nothing OrElse view.Document Is Nothing Then
					Return
				End If

				Dim alphaChanged As Boolean = False

				For Each series As NSeries In m_SeriesToPercents.Keys
					If (m_SelectedSeries Is Nothing) OrElse (series Is m_SelectedSeries) Then
						'selected series or no selection.
						alphaChanged = UpdateAlpha(series, -m_TransparencyStep) OrElse alphaChanged
					Else
						'not selected series when there is a selected series.
						alphaChanged = UpdateAlpha(series, m_TransparencyStep) OrElse alphaChanged
					End If
				Next series

				If alphaChanged Then
					Me.Repaint()
				End If
			End Sub

			#End Region

			#Region "Overrides"

			Public Overrides Sub UpdateReferences(ByVal provider As INReferenceProvider)
				MyBase.UpdateReferences(provider)

				If provider Is Nothing Then
					If Not m_Timer Is Nothing Then
						m_Timer.Stop()
						RemoveHandler m_Timer.Tick, AddressOf OnTimerTick
						m_Timer.Dispose()
						m_Timer = Nothing
					End If
				Else
					m_Timer = New Timer()
					m_Timer.Interval = 50
					AddHandler m_Timer.Tick, AddressOf OnTimerTick
					m_Timer.Start()

					m_SeriesToPercents.Clear()

					Dim enumerator As NNodeTreeEnumerator = New NNodeTreeEnumerator(GetView().Document, TreeTraversalOrder.DepthFirstPreOrder)
					Do While enumerator.MoveNext()
						Dim series As NSeries = TryCast(enumerator.Current, NSeries)
						If Not series Is Nothing Then
							m_SeriesToPercents.Add(series, GetTransparencyPercent(series.FillStyle))
						End If
					Loop
				End If
			End Sub

			Public Overrides Sub OnMouseMove(ByVal sender As Object, ByVal e As NMouseEventArgs)
				m_SelectedSeries = Nothing

				Dim hitTestService As NHitTestCacheService = TryCast(GetView().GetServiceOfType(GetType(NHitTestCacheService)), NHitTestCacheService)

				If hitTestService Is Nothing Then
					Return
				End If

				Dim node As INNode = hitTestService.HitTest(New NPointF(e.X, e.Y))

				If node Is Nothing Then
					Return
				End If

				Dim dataPoint As NDataPoint = TryCast(node, NDataPoint)
				If Not dataPoint Is Nothing Then
					m_SelectedSeries = TryCast(dataPoint.ParentNode, NSeries)
				End If
			End Sub

			#End Region

			#Region "Implementation"

			''' <summary>
			''' Changes the transparency percent for a series FillStyle with a specified step.
			''' </summary>
			''' <param name="series"></param>
			''' <param name="step"></param>
			Private Function UpdateAlpha(ByVal series As NSeries, ByVal [step] As Integer) As Boolean
				Dim curPercent As Single = Math.Min(m_MaxTransparencyPercent, GetTransparencyPercent(series.FillStyle))
				Dim newPercent As Single = curPercent + [step]
				Dim orgPercent As Single = m_SeriesToPercents(series)

				' clamp
				newPercent = Math.Max(orgPercent, newPercent)
				newPercent = Math.Min(m_MaxTransparencyPercent, newPercent)

				series.FillStyle.SetTransparencyPercent(newPercent)

				Return newPercent <> curPercent
			End Function

			''' <summary>
			''' Gets the transparency percent depending on the type of the fillStyle.
			''' </summary>
			''' <param name="fillStyle"></param>
			''' <returns>The transparency percent.</returns>
			Private Function GetTransparencyPercent(ByVal fillStyle As NFillStyle) As Single
				If fillStyle Is Nothing Then
					Return 0
				End If

				If TypeOf fillStyle Is NColorFillStyle Then
					Dim alpha As Byte = (CType(fillStyle, NColorFillStyle)).Color.A
					Return PercentFromAlpha(alpha)
				End If

				If TypeOf fillStyle Is NGradientFillStyle Then
					Dim alphaBeginColor As Byte = (CType(fillStyle, NGradientFillStyle)).BeginColor.A
					Dim alphaEndColor As Byte = (CType(fillStyle, NGradientFillStyle)).EndColor.A
					Return Math.Max(alphaBeginColor, alphaEndColor)
				End If

				If TypeOf fillStyle Is NHatchFillStyle Then
					Dim foregroundAlpha As Byte = (CType(fillStyle, NHatchFillStyle)).ForegroundColor.A
					Dim backgroundAlpha As Byte = (CType(fillStyle, NHatchFillStyle)).BackgroundColor.A
					Return Math.Max(foregroundAlpha, backgroundAlpha)
				End If

				If TypeOf fillStyle Is NImageFillStyle Then
					Dim alpha As Byte = (CType(fillStyle, NImageFillStyle)).Alpha
					Return PercentFromAlpha(alpha)
				End If

				If TypeOf fillStyle Is NAdvancedGradientFillStyle Then
					Dim alpha As Byte = (CType(fillStyle, NAdvancedGradientFillStyle)).BackgroundColor.A
					Return PercentFromAlpha(alpha)
				End If
				Return 0
			End Function

			Private Shared Function PercentFromAlpha(ByVal alpha As Byte) As Single
				Return 100 - (alpha * 100 / 255)
			End Function

			Private Shared Function AlphaFromPercent(ByVal percent As Single) As Byte
				If percent > 100 Then
					percent = 100
				End If
				If percent < 0 Then
					percent = 0
				End If

				Return CByte(percent * 255 / 100)
			End Function

			#End Region

			#Region "Properties"

			Public Property MaxTransparencyPercent() As Single
				Get
					Return m_MaxTransparencyPercent
				End Get
				Set
					If Value > 100 Then
						m_MaxTransparencyPercent = 100
						Return
					End If

					If Value < 0 Then
						m_MaxTransparencyPercent = 0
						Return
					End If
					m_MaxTransparencyPercent = Value
				End Set
			End Property

			#End Region

			#Region "Fields"

			Friend m_Timer As Timer
			Friend m_SelectedSeries As NSeries
			Friend m_MaxTransparencyPercent As Single
			Friend m_SeriesToPercents As Dictionary(Of NSeries, Single)

			#End Region

			#Region "Constants"

			Private Const m_TransparencyStep As Integer = 20

			#End Region
		End Class
	End Class
End Namespace
