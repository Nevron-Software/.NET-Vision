Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.UI
Imports System.Collections.Generic

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NChartCommandBarsUC
		Inherits NExampleBaseUC

		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			m_Manager = DirectCast(MyBase.m_MainForm, NMainForm).chartCommandBarsManager


			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Command Bars")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' hide the legend
			CType(nChartControl1.Legends(0), NLegend).Mode = LegendMode.Disabled

			' create chart 1
			Dim chart1 As NChart = nChartControl1.Charts(0)
			chart1.Enable3D = True
			chart1.Name = "Bar Chart"
			chart1.Location = New NPointL(New NLength(5, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			chart1.Size = New NSizeL(New NLength(40, NRelativeUnit.ParentPercentage), New NLength(95, NRelativeUnit.ParentPercentage))
			chart1.BoundsMode = BoundsMode.Fit
			chart1.Axis(StandardAxis.Depth).Visible = False

			' create chart 2
			Dim chart2 As NChart = New NPieChart()
			chart2.Enable3D = True
			nChartControl1.Charts.Add(chart2)
			chart2.Name = "Pie Chart"
			chart2.Location = New NPointL(New NLength(55, NRelativeUnit.ParentPercentage), New NLength(5, NRelativeUnit.ParentPercentage))
			chart2.Size = New NSizeL(New NLength(40, NRelativeUnit.ParentPercentage), New NLength(95, NRelativeUnit.ParentPercentage))
			chart2.BoundsMode = BoundsMode.Fit
			chart2.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)

			' add series to first chart
			Dim bar As NBarSeries = CType(chart1.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar"
			bar.Values.FillRandom(Random, 10)
			bar.DataLabelStyle.Visible = False

			' add series to second chart
			Dim pie As NPieSeries = CType(chart2.Series.Add(SeriesType.Pie), NPieSeries)
			pie.Name = "Pie"
			pie.Values.FillRandom(Random, 5)
			pie.PieStyle = PieStyle.SmoothEdgePie
			pie.FillStyles(0) = New NColorFillStyle(Color.FromArgb(169,121,11))
			pie.FillStyles(1) = New NColorFillStyle(Color.FromArgb(157,157,92))
			pie.FillStyles(2) = New NColorFillStyle(Color.FromArgb(98,152,92))
			pie.FillStyles(3) = New NColorFillStyle(Color.FromArgb(111,134,181))
			pie.FillStyles(4) = New NColorFillStyle(Color.FromArgb(179,63,92))
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.UpDownOffset = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.UpDownRotation = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.UpDownZoom = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.UpDownElevation = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.UpDownOffset, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.UpDownRotation, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.UpDownZoom, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.UpDownElevation, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' UpDownOffset
			' 
			Me.UpDownOffset.DecimalPlaces = 2
			Me.UpDownOffset.Location = New System.Drawing.Point(8, 192)
			Me.UpDownOffset.Name = "UpDownOffset"
			Me.UpDownOffset.Size = New System.Drawing.Size(100, 20)
			Me.UpDownOffset.TabIndex = 20
			' 
			' UpDownRotation
			' 
			Me.UpDownRotation.DecimalPlaces = 2
			Me.UpDownRotation.Location = New System.Drawing.Point(8, 136)
			Me.UpDownRotation.Name = "UpDownRotation"
			Me.UpDownRotation.Size = New System.Drawing.Size(100, 20)
			Me.UpDownRotation.TabIndex = 19
			' 
			' UpDownZoom
			' 
			Me.UpDownZoom.DecimalPlaces = 2
			Me.UpDownZoom.Location = New System.Drawing.Point(8, 80)
			Me.UpDownZoom.Name = "UpDownZoom"
			Me.UpDownZoom.Size = New System.Drawing.Size(100, 20)
			Me.UpDownZoom.TabIndex = 18
			' 
			' UpDownElevation
			' 
			Me.UpDownElevation.DecimalPlaces = 2
			Me.UpDownElevation.Location = New System.Drawing.Point(8, 24)
			Me.UpDownElevation.Name = "UpDownElevation"
			Me.UpDownElevation.Size = New System.Drawing.Size(100, 20)
			Me.UpDownElevation.TabIndex = 17
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 176)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(75, 15)
			Me.label4.TabIndex = 16
			Me.label4.Text = "Offset Step:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 64)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(78, 15)
			Me.label3.TabIndex = 15
			Me.label3.Text = "Zoom Step:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(82, 12)
			Me.label2.TabIndex = 14
			Me.label2.Text = "Elevation Step:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 120)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(77, 13)
			Me.label1.TabIndex = 13
			Me.label1.Text = "Rotation Step:"
			' 
			' NChartCommandBarsUC
			' 
			Me.Controls.Add(Me.UpDownOffset)
			Me.Controls.Add(Me.UpDownRotation)
			Me.Controls.Add(Me.UpDownZoom)
			Me.Controls.Add(Me.UpDownElevation)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NChartCommandBarsUC"
			Me.Size = New System.Drawing.Size(120, 232)
			DirectCast(Me.UpDownOffset, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.UpDownRotation, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.UpDownZoom, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.UpDownElevation, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Friend m_Manager As NChartCommandBarsManager
		Private UpDownOffset As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private UpDownRotation As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private UpDownZoom As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private UpDownElevation As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label4 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label

		#End Region
	End Class
End Namespace
