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
	Public Class NAxisDockingUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_RedAxis As NAxis
		Private m_GreenAxis As NAxis
		Private m_BlueAxis As NAxis

		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents RedAxisZoneCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents GreenAxisZoneCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BlueAxisZoneCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			RedAxisZoneCombo.Items.Add("Front Left")
			RedAxisZoneCombo.Items.Add("Front Right")

			GreenAxisZoneCombo.Items.Add("Front Left")
			GreenAxisZoneCombo.Items.Add("Front Right")

			BlueAxisZoneCombo.Items.Add("Front Left")
			BlueAxisZoneCombo.Items.Add("Front Right")
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.RedAxisZoneCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.GreenAxisZoneCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.BlueAxisZoneCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 11)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(171, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Dock Red Axis To:"
			' 
			' RedAxisZoneCombo
			' 
			Me.RedAxisZoneCombo.Location = New System.Drawing.Point(7, 32)
			Me.RedAxisZoneCombo.Name = "RedAxisZoneCombo"
			Me.RedAxisZoneCombo.Size = New System.Drawing.Size(161, 21)
			Me.RedAxisZoneCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RedAxisZoneCombo.SelectedIndexChanged += new System.EventHandler(this.RedAxisZoneCombo_SelectedIndexChanged);
			' 
			' GreenAxisZoneCombo
			' 
			Me.GreenAxisZoneCombo.Location = New System.Drawing.Point(7, 91)
			Me.GreenAxisZoneCombo.Name = "GreenAxisZoneCombo"
			Me.GreenAxisZoneCombo.Size = New System.Drawing.Size(161, 21)
			Me.GreenAxisZoneCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GreenAxisZoneCombo.SelectedIndexChanged += new System.EventHandler(this.GreenAxisZoneCombo_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(4, 70)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(171, 16)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Dock Green Axis To:"
			' 
			' BlueAxisZoneCombo
			' 
			Me.BlueAxisZoneCombo.Location = New System.Drawing.Point(8, 149)
			Me.BlueAxisZoneCombo.Name = "BlueAxisZoneCombo"
			Me.BlueAxisZoneCombo.Size = New System.Drawing.Size(161, 21)
			Me.BlueAxisZoneCombo.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlueAxisZoneCombo.SelectedIndexChanged += new System.EventHandler(this.BlueAxisZoneCombo_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(6, 128)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(171, 16)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Dock Red Blue Axis To:"
			' 
			' NAxisDockingUC
			' 
			Me.Controls.Add(Me.BlueAxisZoneCombo)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.GreenAxisZoneCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.RedAxisZoneCombo)
			Me.Controls.Add(Me.label2)
			Me.Name = "NAxisDockingUC"
			Me.Size = New System.Drawing.Size(184, 284)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Docking<br/> <font size = '9pt'>Demonstrates how to use of the dock axis anchor and how to add custom axes</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))

			m_RedAxis = m_Chart.Axis(StandardAxis.PrimaryY)
			m_GreenAxis = m_Chart.Axis(StandardAxis.SecondaryY)
			m_GreenAxis.Visible = True

			' Add a custom vertical axis
			m_BlueAxis = CType(m_Chart.Axes, NCartesianAxisCollection).AddCustomAxis(AxisOrientation.Vertical, AxisDockZone.FrontLeft)

			' create three line series and dispay them on three vertical axes (red, green and blue axis)
			Dim line1 As NLineSeries = CreateLineSeries(Color.Red, Color.DarkRed, 10, 20)
			Dim line2 As NLineSeries = CreateLineSeries(Color.Green, Color.DarkGreen, 50, 100)
			Dim line3 As NLineSeries = CreateLineSeries(Color.Blue, Color.DarkBlue, 100, 200)

			line1.DisplayOnAxis(StandardAxis.PrimaryY, True)

			line2.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line2.DisplayOnAxis(StandardAxis.SecondaryY, True)

			line3.DisplayOnAxis(StandardAxis.PrimaryY, False)
			line3.DisplayOnAxis(m_BlueAxis.AxisId, True)

			' now configure the axis appearance
			Dim linearScale As NLinearScaleConfigurator

			' setup the red axis
			linearScale = New NLinearScaleConfigurator()
			m_RedAxis.ScaleConfigurator = linearScale

			linearScale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkRed)
			linearScale.RulerStyle.BorderStyle.Color = Color.Red
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Red
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Red
			linearScale.MajorGridStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.DarkRed)

			' setup the green axis
			linearScale = New NLinearScaleConfigurator()
			m_GreenAxis.ScaleConfigurator = linearScale

			linearScale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkGreen)
			linearScale.RulerStyle.BorderStyle.Color = Color.Green
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Green
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Green
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.DarkGreen)

			linearScale.RulerStyle.FillStyle = New NColorFillStyle(Color.DarkBlue)
			linearScale.RulerStyle.BorderStyle.Color = Color.Blue
			linearScale.InnerMajorTickStyle.LineStyle.Color = Color.Blue
			linearScale.OuterMajorTickStyle.LineStyle.Color = Color.Blue
			linearScale.LabelStyle.TextStyle.FillStyle = New NColorFillStyle(Color.DarkBlue)

			RedAxisZoneCombo.SelectedIndex = 0
			GreenAxisZoneCombo.SelectedIndex = 0
			BlueAxisZoneCombo.SelectedIndex = 0

			UpdateAxisAnchors()
		End Sub

		Private Function CreateLineSeries(ByVal lightColor As Color, ByVal darkColor As Color, ByVal begin As Integer, ByVal [end] As Integer) As NLineSeries
			' Add a line series
			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Values.FillRandomRange(Random, 5, begin, [end])
			line.BorderStyle.Color = darkColor
			line.DataLabelStyle.Format = "<value>"
			line.DataLabelStyle.TextStyle.BackplaneStyle.Visible = False
			line.DataLabelStyle.ArrowStrokeStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			line.DataLabelStyle.ArrowLength = New NLength(2.5F, NRelativeUnit.ParentPercentage)
			line.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 8)
			line.MarkerStyle.Visible = True
			line.MarkerStyle.BorderStyle.Color = darkColor
			line.MarkerStyle.FillStyle = New NColorFillStyle(lightColor)
			line.MarkerStyle.PointShape = PointShape.Cylinder
			line.MarkerStyle.Width = New NLength(2, NRelativeUnit.ParentPercentage)
			line.MarkerStyle.Height = New NLength(2, NRelativeUnit.ParentPercentage)

			Return line
		End Function

		Private Sub UpdateAxisAnchors()
			If RedAxisZoneCombo.SelectedIndex = 0 Then
				m_RedAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, True)
			Else
				m_RedAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True)
			End If

			If GreenAxisZoneCombo.SelectedIndex = 0 Then
				m_GreenAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, True)
			Else
				m_GreenAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True)
			End If

			If BlueAxisZoneCombo.SelectedIndex = 0 Then
				m_BlueAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontLeft, True)
			Else
				m_BlueAxis.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub RedAxisZoneCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RedAxisZoneCombo.SelectedIndexChanged
			UpdateAxisAnchors()
		End Sub

		Private Sub GreenAxisZoneCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GreenAxisZoneCombo.SelectedIndexChanged
			UpdateAxisAnchors()
		End Sub

		Private Sub BlueAxisZoneCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BlueAxisZoneCombo.SelectedIndexChanged
			UpdateAxisAnchors()
		End Sub
	End Class
End Namespace
