Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPointDropLines3DUC
		Inherits NExampleBaseUC

		Private m_Point As NPointSeries
		Private WithEvents ShowVerticalDropLinesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowHorizontalDropLinesCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowDepthDropLinesCheckBox As UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing

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
			Me.ShowVerticalDropLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowHorizontalDropLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowDepthDropLinesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowVerticalDropLinesCheckBox
			' 
			Me.ShowVerticalDropLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowVerticalDropLinesCheckBox.Location = New System.Drawing.Point(0, 29)
			Me.ShowVerticalDropLinesCheckBox.Name = "ShowVerticalDropLinesCheckBox"
			Me.ShowVerticalDropLinesCheckBox.Size = New System.Drawing.Size(172, 21)
			Me.ShowVerticalDropLinesCheckBox.TabIndex = 1
			Me.ShowVerticalDropLinesCheckBox.Text = "Show Vertical Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowVerticalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowVerticalDropLinesCheckBox_CheckedChanged);
			' 
			' ShowHorizontalDropLinesCheckBox
			' 
			Me.ShowHorizontalDropLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowHorizontalDropLinesCheckBox.Location = New System.Drawing.Point(0, 2)
			Me.ShowHorizontalDropLinesCheckBox.Name = "ShowHorizontalDropLinesCheckBox"
			Me.ShowHorizontalDropLinesCheckBox.Size = New System.Drawing.Size(172, 21)
			Me.ShowHorizontalDropLinesCheckBox.TabIndex = 0
			Me.ShowHorizontalDropLinesCheckBox.Text = "Show Horizontal Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowHorizontalDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowHorizontalDropLinesCheckBox_CheckedChanged);
			' 
			' ShowDepthDropLinesCheckBox
			' 
			Me.ShowDepthDropLinesCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowDepthDropLinesCheckBox.Location = New System.Drawing.Point(0, 56)
			Me.ShowDepthDropLinesCheckBox.Name = "ShowDepthDropLinesCheckBox"
			Me.ShowDepthDropLinesCheckBox.Size = New System.Drawing.Size(172, 21)
			Me.ShowDepthDropLinesCheckBox.TabIndex = 2
			Me.ShowDepthDropLinesCheckBox.Text = "Show Depth Drop Lines"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDepthDropLinesCheckBox.CheckedChanged += new System.EventHandler(this.ShowDepthDropLinesCheckBox_CheckedChanged);
			' 
			' NPointDropLines3DUC
			' 
			Me.Controls.Add(Me.ShowDepthDropLinesCheckBox)
			Me.Controls.Add(Me.ShowHorizontalDropLinesCheckBox)
			Me.Controls.Add(Me.ShowVerticalDropLinesCheckBox)
			Me.Name = "NPointDropLines3DUC"
			Me.Size = New System.Drawing.Size(180, 320)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Point Chart Droplines")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: chart.Width = chart.Height = chart.Depth = 50;
			chart.Depth = 50
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: chart.Width = chart.Height = chart.Depth
			chart.Height = chart.Depth
			chart.Width = chart.Height
			chart.Axis(StandardAxis.Depth).Visible = True
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = New NLinearScaleConfigurator()

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup point series
			m_Point = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point.Name = "Point Series"
			m_Point.InflateMargins = True
			m_Point.UseXValues = True
			m_Point.UseZValues = True
			m_Point.Size = New NLength(10, NGraphicsUnit.Point)
			m_Point.DataLabelStyle.Visible = False

'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()

			For i As Integer = 0 To 99 Step 5
				m_Point.Values.Add(random_Renamed.Next(200) - 100)
				m_Point.XValues.Add(random_Renamed.Next(200) - 100)
				m_Point.ZValues.Add(random_Renamed.Next(200) - 100)
			Next i

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply interactivity
			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' init form controls
			ShowVerticalDropLinesCheckBox.Checked = True
			ShowHorizontalDropLinesCheckBox.Checked = True
			ShowDepthDropLinesCheckBox.Checked = True
		End Sub

		Private Sub ShowVerticalDropLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowVerticalDropLinesCheckBox.CheckedChanged
			m_Point.ShowVerticalDropLines = ShowVerticalDropLinesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowHorizontalDropLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowHorizontalDropLinesCheckBox.CheckedChanged
			m_Point.ShowHorizontalDropLines = ShowHorizontalDropLinesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ShowDepthDropLinesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDepthDropLinesCheckBox.CheckedChanged
			m_Point.ShowDepthDropLines = ShowDepthDropLinesCheckBox.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace