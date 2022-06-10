Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NExampleBaseUC
		Inherits Nevron.Examples.Framework.WinForm.NExampleUserControl

		Friend nChartControl1 As NChartControl = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			' 
			' NExampleBaseUC
			' 
			Me.Name = "NExampleBaseUC"

		End Sub
		#End Region

		Friend Shared Function RandomColor() As Color
			Return Color.FromArgb(Random.Next(255), Random.Next(255), Random.Next(255))
		End Function

		Friend Sub GenerateOHLCData(ByVal s As NStockSeries, ByVal dPrevClose As Double, ByVal nCount As Integer, ByVal range As NRange1DD)
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			For nIndex As Integer = 0 To nCount - 1
				open = dPrevClose
				Dim upward As Boolean = False

				If range.Begin > dPrevClose Then
					upward = True
				ElseIf range.End < dPrevClose Then
					upward = False
				Else
					upward = Random.NextDouble() > 0.5
				End If

				If upward Then
					' upward price change
					close = open + (2 + (Random.NextDouble() * 20))
					high = close + (Random.NextDouble() * 10)
					low = open - (Random.NextDouble() * 10)
				Else
					' downward price change
					close = open - (2 + (Random.NextDouble() * 20))
					high = open + (Random.NextDouble() * 10)
					low = close - (Random.NextDouble() * 10)
				End If

				If low < 1 Then
					low = 1
				End If

				dPrevClose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
			Next nIndex
		End Sub
		Friend Sub GenerateOHLCData(ByVal s As NStockSeries, ByVal dPrevClose As Double, ByVal nCount As Integer)
			Dim open, high, low, close As Double

			s.ClearDataPoints()

			For nIndex As Integer = 0 To nCount - 1
				open = dPrevClose

				If dPrevClose < 25 OrElse Random.NextDouble() > 0.5 Then
					' upward price change
					close = open + (2 + (Random.NextDouble() * 20))
					high = close + (Random.NextDouble() * 10)
					low = open - (Random.NextDouble() * 10)
				Else
					' downward price change
					close = open - (2 + (Random.NextDouble() * 20))
					high = open + (Random.NextDouble() * 10)
					low = close - (Random.NextDouble() * 10)
				End If

				If low < 1 Then
					low = 1
				End If

				dPrevClose = close

				s.OpenValues.Add(open)
				s.HighValues.Add(high)
				s.LowValues.Add(low)
				s.CloseValues.Add(close)
			Next nIndex
		End Sub
		Friend Sub FillStockDates(ByVal stock As NStockSeries, ByVal count As Integer)
			FillStockDates(stock, count, New Date(2009, 1, 5))
		End Sub
		Friend Sub FillStockDates(ByVal stock As NStockSeries, ByVal count As Integer, ByVal startDate As Date)
			stock.XValues.Clear()

			Dim dt As Date = startDate

			Dim i As Integer = 0
			Do While i < count
				If dt.DayOfWeek <> DayOfWeek.Saturday AndAlso dt.DayOfWeek <> DayOfWeek.Sunday Then
					stock.XValues.Add(dt.ToOADate())
					i += 1
				End If

				dt = dt.AddDays(1)
			Loop
		End Sub

		Friend Sub ConfigureStandardLayout(ByVal chart As NChart, ByVal title As NLabel, ByVal legend As NLegend)
			nChartControl1.Panels.Clear()

			If title IsNot Nothing Then
				nChartControl1.Panels.Add(title)

				title.DockMode = PanelDockMode.Top
				title.Padding = New NMarginsL(5, 8, 5, 4)
			End If

			If legend IsNot Nothing Then
				nChartControl1.Panels.Add(legend)

				legend.DockMode = PanelDockMode.Right
				legend.Padding = New NMarginsL(1, 1, 5, 5)
			End If

			If chart IsNot Nothing Then
				nChartControl1.Panels.Add(chart)

				Dim topPad As Single = If(title Is Nothing, 11, 8)
				Dim rightPad As Single = If(legend Is Nothing, 11, 4)

				If chart.BoundsMode = BoundsMode.None Then
					If chart.Enable3D OrElse Not (TypeOf chart Is NCartesianChart) Then
						chart.BoundsMode = BoundsMode.Fit
					Else
						chart.BoundsMode = BoundsMode.Stretch
					End If
				End If

				chart.DockMode = PanelDockMode.Fill
				chart.Padding = New NMarginsL(New NLength(11, NRelativeUnit.ParentPercentage), New NLength(topPad, NRelativeUnit.ParentPercentage), New NLength(rightPad, NRelativeUnit.ParentPercentage), New NLength(11, NRelativeUnit.ParentPercentage))
			End If
		End Sub

		Friend Shared monthValues() As Double = { 16, 19, 16, 15, 18, 19, 24, 21, 22, 17, 19, 15 }
		Friend Shared monthLetters() As String = { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" }
		Friend Shared weekDays() As String = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }

		Friend Shared DarkOrange As Color = Color.FromArgb(238, 66, 14)
		Friend Shared LightOrange As Color = Color.FromArgb(254, 181, 25)
		Friend Shared LightGreen As Color = Color.FromArgb(126, 190, 58)
		Friend Shared Turqoise As Color = Color.FromArgb(2, 138, 122)
		Friend Shared Blue As Color = Color.FromArgb(2, 90, 156)
		Friend Shared Purple As Color = Color.FromArgb(78, 46, 134)
		Friend Shared BeautifulRed As Color = Color.FromArgb(170, 30, 96)
		Friend Shared Red As Color = Color.FromArgb(225, 7, 24)
		Friend Shared Gold As Color = Color.FromArgb(253, 202, 25)
		Friend Shared LimeGreen As Color = Color.FromArgb(206, 222, 62)
		Friend Shared Green As Color = Color.FromArgb(1, 157, 96)
		Friend Shared SeaBlue As Color = Color.FromArgb(2, 117, 137)
		Friend Shared LightPurple As Color = Color.FromArgb(69, 72, 165)
		Friend Shared DarkFuchsia As Color = Color.FromArgb(123, 22, 98)
		Friend Shared GreyBlue As Color = Color.FromArgb(68, 90, 108)

	End Class

	Friend Class NStockDataGenerator
		Private m_Rand As Random
		Private m_Range As NRange1DD
		Private m_nDirection As Integer
		Private m_nStepsInCurrentTrend As Integer
		Private m_dValue As Double
		Private m_dReversalPorbability As Double
		Private m_dReversalFactor As Double
		Private m_dValueScale As Double

		Friend Sub New(ByVal range As NRange1DD, ByVal reversalFactor As Double, ByVal valueScale As Double)
			m_Rand = New Random()
			m_Range = range
			m_nDirection = 1
			m_nStepsInCurrentTrend = 0
			m_dValue = 0
			m_dReversalPorbability = 0
			m_dReversalFactor = reversalFactor
			m_dValueScale = valueScale
		End Sub

		Friend Sub Reset()
			m_nDirection = 1
			m_nStepsInCurrentTrend = 0
			m_dValue = (m_Range.Begin + m_Range.End) / 2
			m_dReversalPorbability = 0
		End Sub

		Friend Function GetNextValue() As Double
			Dim nNewValueDirection As Integer = 0

			If m_dValue <= m_Range.Begin Then
				If m_nDirection = -1 Then
					m_dReversalPorbability = 1.0
				Else
					m_dReversalPorbability = 0.0
				End If

				nNewValueDirection = 1
			ElseIf m_dValue >= m_Range.End Then
				If m_nDirection = 1 Then
					m_dReversalPorbability = 1.0
				Else
					m_dReversalPorbability = 0.0
				End If

				nNewValueDirection = -1
			Else
				If m_Rand.NextDouble() < 0.80 Then
					nNewValueDirection = m_nDirection
				Else
					nNewValueDirection = -m_nDirection
				End If

				m_dReversalPorbability += m_nStepsInCurrentTrend * m_dReversalFactor
			End If

			If m_Rand.NextDouble() < m_dReversalPorbability Then
				m_nDirection = -m_nDirection
				m_dReversalPorbability = 0
				m_nStepsInCurrentTrend = 0
			Else
				m_nStepsInCurrentTrend += 1
			End If

			m_dValue += nNewValueDirection * m_Rand.NextDouble() * m_dValueScale

			Return m_dValue
		End Function
	End Class

	Friend Enum ExampleLayout
		Standard
		WideScreen
	End Enum
End Namespace