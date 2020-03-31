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
	Public Class NTwinGuidelineUC
		Inherits NExampleBaseUC

		Private m_ChartFemale As NCartesianChart
		Private m_ChartMale As NCartesianChart
		Private m_barF As NBarSeries
		Private m_barM As NBarSeries
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents TwinChartsCheckBox As UI.WinForm.Controls.NCheckBox

		Private AgeLabels() As String = { "0 - 4", "5 - 9", "10 - 14", "15 - 19", "20 - 24", "25 - 29", "30 - 34", "35 - 39", "40 - 44", "45 - 49", "50 - 54", "55 - 59", "60 - 64", "65 - 69", "70 - 74", "75 - 79", "80 +" }

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
			Me.TwinChartsCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' TwinChartsCheckBox
			' 
			Me.TwinChartsCheckBox.ButtonProperties.BorderOffset = 2
			Me.TwinChartsCheckBox.Location = New System.Drawing.Point(3, 16)
			Me.TwinChartsCheckBox.Name = "TwinChartsCheckBox"
			Me.TwinChartsCheckBox.Size = New System.Drawing.Size(119, 21)
			Me.TwinChartsCheckBox.TabIndex = 8
			Me.TwinChartsCheckBox.Text = "Twin Charts"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TwinChartsCheckBox.CheckedChanged += new System.EventHandler(this.TwinChartsCheckBox_CheckedChanged);
			' 
			' NTwinGuidelineUC
			' 
			Me.Controls.Add(Me.TwinChartsCheckBox)
			Me.Name = "NTwinGuidelineUC"
			Me.Size = New System.Drawing.Size(180, 206)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' header label
			Dim headerLabel As NLabel = nChartControl1.Labels.AddHeader("Population structure of New York for 2001")
			headerLabel.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			headerLabel.ContentAlignment = ContentAlignment.MiddleCenter
			headerLabel.TextStyle.FontStyle.Name = "Times New Roman"
			headerLabel.TextStyle.FontStyle.Style = FontStyle.Italic
			headerLabel.DockMode = PanelDockMode.Top
			headerLabel.Margins = New NMarginsL(10, 10, 10, 10)

			' footer label
			Dim footerLabel As NLabel = nChartControl1.Labels.AddFooter("Population (in thousands)")
			footerLabel.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			footerLabel.ContentAlignment = ContentAlignment.MiddleCenter
			footerLabel.TextStyle.FontStyle.Name = "Times New Roman"
			footerLabel.TextStyle.FontStyle.Style = FontStyle.Italic
			footerLabel.Margins = New NMarginsL(10, 10, 10, 10)
			footerLabel.DockMode = PanelDockMode.Bottom

			Dim containerPanel As New NDockPanel()
			containerPanel.DockMode = PanelDockMode.Fill
			containerPanel.Margins = New NMarginsL(10, 0, 10, 0)
			nChartControl1.Panels.Add(containerPanel)

			' create male chart
			m_ChartMale = New NCartesianChart()
			m_ChartMale.BoundsMode = BoundsMode.Stretch
			m_ChartMale.ContentAlignment = ContentAlignment.MiddleCenter
			m_ChartMale.DockMode = PanelDockMode.Left
			m_ChartMale.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			m_ChartMale.Margins = New NMarginsL(10, 10, 0, 10)
			SetupMaleChart()
			containerPanel.ChildPanels.Add(m_ChartMale)

			' create female chart
			m_ChartFemale = New NCartesianChart()
			m_ChartFemale.BoundsMode = BoundsMode.Stretch
			m_ChartFemale.ContentAlignment = ContentAlignment.MiddleCenter
			m_ChartFemale.DockMode = PanelDockMode.Left
			m_ChartFemale.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
			m_ChartFemale.Margins = New NMarginsL(0, 10, 10, 10)
			SetupFemaleChart()
			containerPanel.ChildPanels.Add(m_ChartFemale)

			' add twin guide line
			Dim twinGuideLine As New NTwinGuideline()

			twinGuideLine.Side = PanelSide.Left
			twinGuideLine.Target1 = m_ChartFemale
			twinGuideLine.Target2 = m_ChartMale

			nChartControl1.Document.RootPanel.Guidelines.Add(twinGuideLine)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			TwinChartsCheckBox.Checked = True
		End Sub

		Private Sub SetupFemaleChart()
			' female chart setup
			m_ChartFemale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)

			' setup Y axis
			Dim axisY As NAxis = m_ChartFemale.Axis(StandardAxis.PrimaryY)
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = False
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, False, 0, 100)

			' add manual labels to the female chart
			Dim ordinalScale As NOrdinalScaleConfigurator = TryCast(m_ChartFemale.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.AutoLabels = False
			ordinalScale.MajorTickMode = MajorTickMode.CustomStep
			ordinalScale.CustomStep = 1

			' populate the female chart
			m_barF = CType(m_ChartFemale.Series.Add(SeriesType.Bar), NBarSeries)
			m_barF.BorderStyle.Color = DarkOrange
			m_barF.DataLabelStyle.Format = "<value>"
			m_barF.DataLabelStyle.VertAlign = VertAlign.Center
			m_barF.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 7)
			m_barF.Values.Add(210) ' 0 - 4
			m_barF.Values.Add(215) ' 5 - 9
			m_barF.Values.Add(219) ' 10 - 14
			m_barF.Values.Add(225) ' 15 - 19
			m_barF.Values.Add(245) ' 20 - 24
			m_barF.Values.Add(289) ' 25 - 29
			m_barF.Values.Add(355) ' 30 - 34
			m_barF.Values.Add(355) ' 35 - 39
			m_barF.Values.Add(380) ' 40 - 44
			m_barF.Values.Add(320) ' 45 - 49
			m_barF.Values.Add(250) ' 50 - 54
			m_barF.Values.Add(190) ' 55 - 59
			m_barF.Values.Add(112) ' 60 - 64
			m_barF.Values.Add(110) ' 65 - 69
			m_barF.Values.Add(90) ' 70 - 74
			m_barF.Values.Add(55) ' 75 - 79
			m_barF.Values.Add(45) ' 80 +
		End Sub

		Private Sub SetupMaleChart()
			' chart setup
			m_ChartMale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalRight)

			' setup Y axis
			Dim axisY As NAxis = m_ChartMale.Axis(StandardAxis.PrimaryY)
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = False

			' add labels to the male chart X axis
			Dim axisX As NAxis = m_ChartMale.Axis(StandardAxis.PrimaryX)
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.MajorTickMode = MajorTickMode.CustomStep
			scaleX.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
			scaleX.AutoLabels = False
			scaleX.Labels.AddRange(AgeLabels)

			' populate the male chart
			m_barM = CType(m_ChartMale.Series.Add(SeriesType.Bar), NBarSeries)
			m_barM.BorderStyle.Color = GreyBlue
			m_barM.DataLabelStyle.Format = "<value>"
			m_barM.DataLabelStyle.VertAlign = VertAlign.Center
			m_barM.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 7)
			m_barM.Values.Add(200) ' 0 - 4
			m_barM.Values.Add(210) ' 5 - 9
			m_barM.Values.Add(205) ' 10 - 14
			m_barM.Values.Add(225) ' 15 - 19
			m_barM.Values.Add(250) ' 20 - 24
			m_barM.Values.Add(290) ' 25 - 29
			m_barM.Values.Add(340) ' 30 - 34
			m_barM.Values.Add(340) ' 35 - 39
			m_barM.Values.Add(370) ' 40 - 44
			m_barM.Values.Add(310) ' 45 - 49
			m_barM.Values.Add(260) ' 50 - 54
			m_barM.Values.Add(180) ' 55 - 59
			m_barM.Values.Add(120) ' 60 - 64
			m_barM.Values.Add(115) ' 65 - 69
			m_barM.Values.Add(100) ' 70 - 74
			m_barM.Values.Add(50) ' 75 - 79
			m_barM.Values.Add(35) ' 80 +
		End Sub

		Private Sub TwinChartsCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TwinChartsCheckBox.CheckedChanged
			nChartControl1.Document.RootPanel.Guidelines.Clear()

			If TwinChartsCheckBox.Checked Then
				' add twin guide line
				Dim twinGuideLine As New NTwinGuideline()

				twinGuideLine.Side = PanelSide.Left
				twinGuideLine.Target1 = m_ChartFemale
				twinGuideLine.Target2 = m_ChartMale

				nChartControl1.Document.RootPanel.Guidelines.Add(twinGuideLine)
			End If

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace