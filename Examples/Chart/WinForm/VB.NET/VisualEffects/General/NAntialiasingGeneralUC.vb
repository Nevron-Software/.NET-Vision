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
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAntialiasingGeneralUC
		Inherits NExampleBaseUC
		Private WithEvents WidthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents DepthScroll As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents LightsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableAntialiasingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
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
			Me.WidthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.DepthScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LightsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableAntialiasingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' WidthScroll
			' 
			Me.WidthScroll.Location = New System.Drawing.Point(11, 95)
			Me.WidthScroll.Name = "WidthScroll"
			Me.WidthScroll.Size = New System.Drawing.Size(128, 16)
			Me.WidthScroll.TabIndex = 3
'			Me.WidthScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.WidthScroll_Scroll);
			' 
			' DepthScroll
			' 
			Me.DepthScroll.Location = New System.Drawing.Point(11, 146)
			Me.DepthScroll.Name = "DepthScroll"
			Me.DepthScroll.Size = New System.Drawing.Size(128, 16)
			Me.DepthScroll.TabIndex = 4
'			Me.DepthScroll.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.DepthScroll_Scroll);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(11, 78)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(128, 16)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Width %:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(11, 130)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(128, 16)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Depth %:"
			' 
			' LightsCheck
			' 
			Me.LightsCheck.Location = New System.Drawing.Point(11, 41)
			Me.LightsCheck.Name = "LightsCheck"
			Me.LightsCheck.Size = New System.Drawing.Size(128, 22)
			Me.LightsCheck.TabIndex = 8
			Me.LightsCheck.Text = "Lights"
'			Me.LightsCheck.CheckedChanged += New System.EventHandler(Me.LightsCheck_CheckedChanged);
			' 
			' EnableAntialiasingCheckBox
			' 
			Me.EnableAntialiasingCheckBox.Location = New System.Drawing.Point(11, 10)
			Me.EnableAntialiasingCheckBox.Name = "EnableAntialiasingCheckBox"
			Me.EnableAntialiasingCheckBox.Size = New System.Drawing.Size(128, 22)
			Me.EnableAntialiasingCheckBox.TabIndex = 15
			Me.EnableAntialiasingCheckBox.Text = "Enable antialiasing"
'			Me.EnableAntialiasingCheckBox.CheckedChanged += New System.EventHandler(Me.EnableAntialiasingCheckBox_CheckedChanged);
			' 
			' NAntialiasingGeneralUC
			' 
			Me.Controls.Add(Me.EnableAntialiasingCheckBox)
			Me.Controls.Add(Me.LightsCheck)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.DepthScroll)
			Me.Controls.Add(Me.WidthScroll)
			Me.Name = "NAntialiasingGeneralUC"
			Me.Size = New System.Drawing.Size(153, 203)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Line Antialiasing")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.Axis(StandardAxis.Depth).Visible = False

			' create a bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "My Bar Series"
			bar.DataLabelStyle.Visible = False
			bar.Values.AddRange(monthValues)

			' apply stylesheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.AutumnMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' enable mouse trackball
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' form controls
			EnableAntialiasingCheckBox.Checked = True
			LightsCheck.Checked = True
		End Sub

		Private Sub WidthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles WidthScroll.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.WidthPercent = WidthScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub DepthScroll_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles DepthScroll.ValueChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.DepthPercent = DepthScroll.Value
			nChartControl1.Refresh()
		End Sub

		Private Sub LightsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LightsCheck.CheckedChanged
			Dim chart As NChart = CType(nChartControl1.Charts(0), NChart)

			If LightsCheck.Checked Then
				chart.LightModel.EnableLighting = True
				chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftCameraLight)
			Else
				chart.LightModel.EnableLighting = False
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub EnableAntialiasingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableAntialiasingCheckBox.CheckedChanged
			If EnableAntialiasingCheckBox.Checked Then
				nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.AntiAlias
			Else
				nChartControl1.Settings.ShapeRenderingMode = ShapeRenderingMode.None
			End If
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace

