Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDigitalClockUC
		Inherits NExampleBaseUC
		Private components As System.ComponentModel.IContainer
		Private WithEvents m_Timer As System.Windows.Forms.Timer

		Private m_Indicator1 As NRangeIndicator
		Private m_Indicator2 As NRangeIndicator
		Private m_Random As Random
		Private m_Indicator3 As NRangeIndicator

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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
			Me.components = New System.ComponentModel.Container()
			Me.m_Timer = New System.Windows.Forms.Timer(Me.components)
			' 
			' timer1
			' 
'			Me.m_Timer.Tick += New System.EventHandler(Me.timer1_Tick);
			' 
			' NDigitalClockUC
			' 
			Me.Name = "NDigitalClockUC"

		End Sub
		#End Region



		Public Overrides Sub Initialize()
			m_Random = New Random()
			nChartControl1.Panels.Clear()

			Dim digitalClock As NDigitalClockPanel = New NDigitalClockPanel()
			digitalClock.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))

			nChartControl1.Panels.Add(digitalClock)

			m_Indicator1 = New NRangeIndicator(30)
			m_Indicator2 = New NRangeIndicator(40)
			m_Indicator3 = New NRangeIndicator(50)

			Dim meter1 As NPanel = CreateStatusMeterPanel("Battery Meter 1", New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage)), m_Indicator1)

			Dim meter2 As NPanel= CreateStatusMeterPanel("Battery Meter 2", New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(45, NRelativeUnit.ParentPercentage)), m_Indicator2)

			Dim meter3 As NPanel = CreateStatusMeterPanel("Battery Meter 3", New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage)), m_Indicator3)

			nChartControl1.Panels.Add(meter1)
			nChartControl1.Panels.Add(meter2)
			nChartControl1.Panels.Add(meter3)

			m_Timer.Interval = 1000
			m_Timer.Start()
		End Sub

		Private Function CreateStatusMeterPanel(ByVal labelText As String, ByVal location As NPointL, ByVal rangeIndicator As NRangeIndicator) As NBackgroundDecoratorPanel
			Dim backgroundPanel As NBackgroundDecoratorPanel = New NBackgroundDecoratorPanel()

			backgroundPanel.Location = location
			backgroundPanel.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))

			Dim imageFrameStyle As NImageFrameStyle = New NImageFrameStyle(PredefinedImageFrame.Embed)
			imageFrameStyle.BackgroundColor = Color.Transparent
			imageFrameStyle.ShadowStyle.Type = ShadowType.None
			imageFrameStyle.FillStyle = New NColorFillStyle(Color.Transparent)
			backgroundPanel.BackgroundStyle.FillStyle = New NColorFillStyle(Color.White)
			backgroundPanel.BackgroundStyle.FrameStyle = imageFrameStyle

			Dim contentPanel As NDockPanel = New NDockPanel()
			contentPanel.DockMargins = New NMarginsL(New NLength(15), New NLength(3), New NLength(15), New NLength(3))
			contentPanel.DockMode = PanelDockMode.Fill
			backgroundPanel.ChildPanels.Add(contentPanel)

			Dim label As NLabel = New NLabel()
			label.DockMode = PanelDockMode.Bottom
			label.Text = labelText
			label.ContentAlignment = ContentAlignment.MiddleLeft
			label.DockMargins = New NMarginsL(New NLength(0), New NLength(0), New NLength(0), New NLength(0))
			label.BoundsMode = BoundsMode.Fit
			contentPanel.ChildPanels.Add(label)

			Dim linearGauge As NLinearGaugePanel = New NLinearGaugePanel()
			linearGauge.Indicators.Add(rangeIndicator)
			linearGauge.DockMode = PanelDockMode.Fill
			linearGauge.DockMargins = New NMarginsL(New NLength(15), New NLength(0), New NLength(15), New NLength(0))

			Dim axis As NGaugeAxis = CType(linearGauge.Axes(0), NGaugeAxis)
			axis.Anchor = New NModelGaugeAxisAnchor()
			Dim configurator As NStandardScaleConfigurator = CType(axis.ScaleConfigurator, NStandardScaleConfigurator)
			configurator.SetPredefinedScaleStyle(PredefinedScaleStyle.Scientific)
			contentPanel.ChildPanels.Add(linearGauge)

			Return backgroundPanel
		End Function

		Private Sub GenerateRandomValue(ByVal indicator As NRangeIndicator)
			Dim factor As Double
			If indicator.Value > 50 Then
				factor = 6
			Else
				factor = 4
			End If
			Dim value As Double = indicator.Value + m_Random.Next(10) - factor

			If value < 0 Then
				value = 0
			ElseIf value > 100 Then
				value = 100
			End If

			indicator.Value = value
		End Sub

		Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
			GenerateRandomValue(m_Indicator1)
			GenerateRandomValue(m_Indicator2)
			GenerateRandomValue(m_Indicator3)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
