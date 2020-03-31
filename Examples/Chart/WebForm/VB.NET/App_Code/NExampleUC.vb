Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NExampleUC
		Inherits System.Web.UI.UserControl
		#Region "Overrides"

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad (e)
		End Sub

		Protected Overrides Sub LoadViewState(ByVal savedState As Object)
			MyBase.LoadViewState(savedState)

			LoadExample()
		End Sub

		Protected Overrides Sub OnInit(ByVal e As EventArgs)
			EnableViewState = True
			Me.Session.Timeout = 20

			MyBase.OnInit(e)
		End Sub

		#End Region

		#Region "Overridables"

		Protected Overridable Sub LoadExample()
		End Sub


		#End Region

		#Region "Operations"

		Protected Sub ApplyLayoutTemplate(ByVal template As Integer, ByVal control As INChartControl, ByVal chart As NDockPanel, ByVal title As NLabel, ByVal legend As NLegend)
			control.Panels.Clear()

			If Not title Is Nothing Then
				control.Panels.Add(title)

				title.DockMode = PanelDockMode.Top
				title.Padding = New NMarginsL(4, 6, 4, 6)
			End If

			If Not legend Is Nothing Then
				control.Panels.Add(legend)

				legend.DockMode = PanelDockMode.Right
				legend.Padding = New NMarginsL(1, 1, 3, 3)
			End If

			If Not chart Is Nothing Then
				control.Panels.Add(chart)

				Dim topPad As Single
				If (title Is Nothing) Then
					topPad = 3
				Else
					topPad = 3
				End If
				Dim rightPad As Single
				If (legend Is Nothing) Then
					rightPad = 3
				Else
					rightPad = 3
				End If

				If chart.BoundsMode = BoundsMode.None Then
					If ((TypeOf chart Is NChart) AndAlso ((CType(chart, NChart)).Enable3D)) OrElse Not(TypeOf chart Is NCartesianChart) Then
						chart.BoundsMode = BoundsMode.Fit
					Else
						chart.BoundsMode = BoundsMode.Stretch
					End If
				End If

				chart.DockMode = PanelDockMode.Fill

				' fit axes if chart is Cartesian 3D
				Dim cartesianChart As NCartesianChart = TryCast(chart, NCartesianChart)
				If Not cartesianChart Is Nothing Then
					cartesianChart.Fit3DAxisContent = True
				End If

				chart.Padding = New NMarginsL(New NLength(3, NRelativeUnit.ParentPercentage), New NLength(topPad, NRelativeUnit.ParentPercentage), New NLength(rightPad, NRelativeUnit.ParentPercentage), New NLength(3, NRelativeUnit.ParentPercentage))
			End If
		End Sub
		Protected Sub FillStockDates(ByVal stock As NStockSeries, ByVal count As Integer)
			FillStockDates(stock, count, New DateTime(2009, 1, 5))
		End Sub
		Protected Sub FillStockDates(ByVal stock As NStockSeries, ByVal count As Integer, ByVal startDate As DateTime)
			stock.XValues.Clear()

			Dim dt As DateTime = startDate

			Dim i As Integer = 0
			Do While i < count
				If dt.DayOfWeek <> DayOfWeek.Saturday AndAlso dt.DayOfWeek <> DayOfWeek.Sunday Then
					stock.XValues.Add(dt.ToOADate())
					i += 1
				End If

				dt = dt.AddDays(1)
			Loop
		End Sub

		#End Region

		#Region "Fields"

		Protected Shared ReadOnly Random As Random = New Random()

		Protected Shared ReadOnly monthValues As Double() = New Double() { 16, 19, 16, 15, 18, 19, 24, 21, 22, 17, 19, 15 }
		Protected Shared ReadOnly monthLetters As String() = New String() { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" }
		Protected Shared ReadOnly weekDays As String() = New String() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }

		Protected Shared ReadOnly DarkOrange As Color = Color.FromArgb(238, 66, 14)
		Protected Shared ReadOnly LightOrange As Color = Color.FromArgb(254, 181, 25)
		Protected Shared ReadOnly LightGreen As Color = Color.FromArgb(126, 190, 58)
		Protected Shared ReadOnly Turqoise As Color = Color.FromArgb(2, 138, 122)
		Protected Shared ReadOnly Blue As Color = Color.FromArgb(2, 90, 156)
		Protected Shared ReadOnly Purple As Color = Color.FromArgb(78, 46, 134)
		Protected Shared ReadOnly BeautifulRed As Color = Color.FromArgb(170, 30, 96)
		Protected Shared ReadOnly Red As Color = Color.FromArgb(225, 7, 24)
		Protected Shared ReadOnly Gold As Color = Color.FromArgb(253, 202, 25)
		Protected Shared ReadOnly LimeGreen As Color = Color.FromArgb(206, 222, 62)
		Protected Shared ReadOnly Green As Color = Color.FromArgb(1, 157, 96)
		Protected Shared ReadOnly SeaBlue As Color = Color.FromArgb(2, 117, 137)
		Protected Shared ReadOnly LightPurple As Color = Color.FromArgb(69, 72, 165)
		Protected Shared ReadOnly DarkFuchsia As Color = Color.FromArgb(123, 22, 98)
		Protected Shared ReadOnly GreyBlue As Color = Color.FromArgb(68, 90, 108)


		Protected Shared ReadOnly arrCustomColors1 As Color() = New Color() { Color.Firebrick, Color.Tomato, Color.Orange, Color.Gold, Color.GreenYellow, Color.LimeGreen, Color.MediumAquamarine, Color.CadetBlue, Color.SlateBlue, Color.MediumPurple }

		Protected Shared arrCustomColors2 As Color() = New Color() { Color.IndianRed, Color.Peru, Color.DarkKhaki, Color.OliveDrab, Color.DarkSeaGreen, Color.MediumSeaGreen, Color.SteelBlue, Color.SlateBlue, Color.MediumOrchid, Color.HotPink }

		Protected Shared arrCustomColors3 As Color() = New Color() { Color.Snow, Color.PaleGoldenrod, Color.White, Color.Silver, Color.WhiteSmoke, Color.Khaki, Color.Azure, Color.AntiqueWhite, Color.AliceBlue, Color.Wheat }


		#End Region

		#Region "Protected classes"

		Protected Class NStockDataGenerator
			Private m_Rand As Random
			Private m_Range As NRange1DD
			Private m_nDirection As Integer
			Private m_nStepsInCurrentTrend As Integer
			Private m_dValue As Double
			Private m_dReversalPorbability As Double
			Private m_dReversalFactor As Double
			Private m_dValueScale As Double

			Public Sub New(ByVal range As NRange1DD, ByVal reversalFactor As Double, ByVal valueScale As Double)
				m_Rand = New Random()
				m_Range = range
				m_nDirection = 1
				m_nStepsInCurrentTrend = 0
				m_dValue = 0
				m_dReversalPorbability = 0
				m_dReversalFactor = reversalFactor
				m_dValueScale = valueScale
			End Sub

			Public Sub Reset()
				m_nDirection = 1
				m_nStepsInCurrentTrend = 0
				m_dValue = (m_Range.Begin + m_Range.End) / 2
				m_dReversalPorbability = 0
			End Sub

			Public Function GetNextValue() As Double
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

		#End Region
	End Class
End Namespace
