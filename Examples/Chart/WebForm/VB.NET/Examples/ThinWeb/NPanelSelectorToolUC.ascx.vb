Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.Chart.ThinWeb
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WebForm
	Public Partial Class NPanelSelectorToolUC
		Inherits NExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not NThinChartControl1.Initialized) Then
				' get the default chart 
				NThinChartControl1.Panels.Clear()
				NThinChartControl1.BackgroundStyle.FrameStyle.Visible = False
				NThinChartControl1.Settings.EnableJittering = True

				' set a chart title
				Dim title As NLabel = NThinChartControl1.Labels.AddHeader("Panel Selector Tool")
				title.TextStyle.TextFormat = GraphicsCore.TextFormat.XML
				title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 14, FontStyle.Italic)
				title.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur
				title.DockMode = PanelDockMode.Top

				Dim contentPanel As NDockPanel = New NDockPanel()
				contentPanel.DockMode = PanelDockMode.Fill

				' create the first pie chart
				Dim pieChart1 As NPieChart = CreatePieChart()
				pieChart1.Location = New NPointL(0, 0)
				pieChart1.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
				contentPanel.ChildPanels.Add(pieChart1)

				' create the second pie chart
				Dim pieChart2 As NPieChart = CreatePieChart()
				pieChart2.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(0))
				pieChart2.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))
				contentPanel.ChildPanels.Add(pieChart2)

				NThinChartControl1.Panels.Add(contentPanel)

				' apply style sheet
				Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.BrightMultiColor)
				styleSheet.Apply(NThinChartControl1.Document)

				' add panel selector and trackball tools
				Dim panelSelector As NPanelSelectorTool = New NPanelSelectorTool()
				panelSelector.ActivatePanelCallback = New ActivatePanelCallback()
				NThinChartControl1.Controller.Tools.Add(panelSelector)

				NThinChartControl1.Controller.Tools.Add(New NTrackballTool())
			End If
		End Sub

		Private Function CreatePieChart() As NPieChart
			Dim pieChart As NPieChart = New NPieChart()
			pieChart.Enable3D = True
			pieChart.Margins = New NMarginsL(10, 10, 10, 10)
			pieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			pieChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveElevated)

			Dim pieSeries As NPieSeries = New NPieSeries()
			pieSeries.LabelMode = PieLabelMode.Center
			pieSeries.PieStyle = PieStyle.SmoothEdgePie
			pieChart.Series.Add(pieSeries)

			Dim rand As Random = New Random()
			For i As Integer = 0 To 5
				pieSeries.Values.Add(rand.Next(100) + 10)
			Next i

			Return pieChart
		End Function

		<Serializable> _
		Public Class ActivatePanelCallback
            Implements INActivatePanelCallback
			#Region "INActivatePanelCallback Members"

			Private Sub OnActivatePanel(ByVal control As NThinChartControl, ByVal newActivePanel As NContentPanel, ByVal oldActivePanel As NContentPanel) Implements INActivatePanelCallback.OnActivatePanel
				' when the currently active panel changes, change its border to prompt the user
				If Not oldActivePanel Is Nothing Then
					oldActivePanel.BorderStyle = Nothing
				End If

				If Not newActivePanel Is Nothing Then
					Dim border As NStrokeBorderStyle = New NStrokeBorderStyle(BorderShape.RoundedRect)
					border.StrokeStyle.Color = Color.Red
					newActivePanel.BorderStyle = border
				End If

				control.UpdateView()
			End Sub

			#End Region
		End Class
	End Class
End Namespace
