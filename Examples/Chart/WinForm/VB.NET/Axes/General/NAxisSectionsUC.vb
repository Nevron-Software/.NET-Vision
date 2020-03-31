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
	Public Class NAxisSectionsUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private m_Chart As NCartesianChart

		Private m_FirstVerticalSection As NScaleSectionStyle
		Private m_SecondVerticalSection As NScaleSectionStyle
		Private m_FirstHorizontalSection As NScaleSectionStyle
		Private m_SecondHorizontalSection As NScaleSectionStyle

		Private WithEvents ShowFirstHorizontalSectionCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowSecondHorizontalSectionCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowFirstVerticalSectionCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowSecondVerticalSectionCheck As Nevron.UI.WinForm.Controls.NCheckBox

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
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
			Me.ShowFirstHorizontalSectionCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowSecondHorizontalSectionCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowFirstVerticalSectionCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowSecondVerticalSectionCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowFirstHorizontalSectionCheck
			' 
			Me.ShowFirstHorizontalSectionCheck.Location = New System.Drawing.Point(8, 64)
			Me.ShowFirstHorizontalSectionCheck.Name = "ShowFirstHorizontalSectionCheck"
			Me.ShowFirstHorizontalSectionCheck.Size = New System.Drawing.Size(144, 20)
			Me.ShowFirstHorizontalSectionCheck.TabIndex = 7
			Me.ShowFirstHorizontalSectionCheck.Text = "Show X Section [2, 8]"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowFirstHorizontalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowFirstHorizontalSectionCheck_CheckedChanged);
			' 
			' ShowSecondHorizontalSectionCheck
			' 
			Me.ShowSecondHorizontalSectionCheck.Location = New System.Drawing.Point(8, 88)
			Me.ShowSecondHorizontalSectionCheck.Name = "ShowSecondHorizontalSectionCheck"
			Me.ShowSecondHorizontalSectionCheck.Size = New System.Drawing.Size(144, 20)
			Me.ShowSecondHorizontalSectionCheck.TabIndex = 8
			Me.ShowSecondHorizontalSectionCheck.Text = "Show X Section [14, 18]"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowSecondHorizontalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowSecondHorizontalSectionCheck_CheckedChanged);
			' 
			' ShowFirstVerticalSectionCheck
			' 
			Me.ShowFirstVerticalSectionCheck.Location = New System.Drawing.Point(8, 8)
			Me.ShowFirstVerticalSectionCheck.Name = "ShowFirstVerticalSectionCheck"
			Me.ShowFirstVerticalSectionCheck.Size = New System.Drawing.Size(144, 20)
			Me.ShowFirstVerticalSectionCheck.TabIndex = 9
			Me.ShowFirstVerticalSectionCheck.Text = "Show Y Section [20, 40]"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowFirstVerticalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowFirstVerticalSectionCheck_CheckedChanged);
			' 
			' ShowSecondVerticalSectionCheck
			' 
			Me.ShowSecondVerticalSectionCheck.Location = New System.Drawing.Point(8, 32)
			Me.ShowSecondVerticalSectionCheck.Name = "ShowSecondVerticalSectionCheck"
			Me.ShowSecondVerticalSectionCheck.Size = New System.Drawing.Size(136, 20)
			Me.ShowSecondVerticalSectionCheck.TabIndex = 10
			Me.ShowSecondVerticalSectionCheck.Text = "Show Y Section [70, 90]"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowSecondVerticalSectionCheck.CheckedChanged += new System.EventHandler(this.ShowSecondVerticalSectionCheck_CheckedChanged);
			' 
			' NAxisSectionsUC
			' 
			Me.Controls.Add(Me.ShowSecondVerticalSectionCheck)
			Me.Controls.Add(Me.ShowFirstVerticalSectionCheck)
			Me.Controls.Add(Me.ShowSecondHorizontalSectionCheck)
			Me.Controls.Add(Me.ShowFirstHorizontalSectionCheck)
			Me.Name = "NAxisSectionsUC"
			Me.Size = New System.Drawing.Size(160, 264)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Sections")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.BoundsMode = BoundsMode.Stretch

			' create a point series
			Dim point As NPointSeries = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			point.Name = "Point Series"
			point.DataLabelStyle.Visible = False
			point.MarkerStyle.Visible = False
			point.Size = New NLength(5, NGraphicsUnit.Point)
			point.Values.FillRandom(Random, 30)
			point.ShadowStyle.Type = ShadowType.GaussianBlur
			point.ShadowStyle.Offset = New NPointL(3, 3)
			point.ShadowStyle.FadeLength = New NLength(5)
			point.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)
			point.InflateMargins = True

			' tell the x axis to display major and minor grid lines
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorTickCount = 1

			' tell the y axis to display major and minor grid lines
			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MinorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MinorTickCount = 1

			Dim labelStyle As NTextStyle

			' configure the first horizontal section
			m_FirstHorizontalSection = New NScaleSectionStyle()
			m_FirstHorizontalSection.Range = New NRange1DD(2, 8)
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Back, True)
			m_FirstHorizontalSection.SetShowAtWall(ChartWallType.Floor, True)
			m_FirstHorizontalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(60, Color.Red))
			m_FirstHorizontalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Red)
			m_FirstHorizontalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkRed)
			m_FirstHorizontalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Red, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Red, Color.DarkRed)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_FirstHorizontalSection.LabelTextStyle = labelStyle

			' configure the second horizontal section
			m_SecondHorizontalSection = New NScaleSectionStyle()
			m_SecondHorizontalSection.Range = New NRange1DD(14, 18)
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Back, True)
			m_SecondHorizontalSection.SetShowAtWall(ChartWallType.Floor, True)
			m_SecondHorizontalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(60, Color.Green))
			m_SecondHorizontalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Green)
			m_SecondHorizontalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkGreen)
			m_SecondHorizontalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Green, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Green, Color.DarkGreen)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_SecondHorizontalSection.LabelTextStyle = labelStyle

			' configure the first vertical section
			m_FirstVerticalSection = New NScaleSectionStyle()
			m_FirstVerticalSection.Range = New NRange1DD(20, 40)
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Back, True)
			m_FirstVerticalSection.SetShowAtWall(ChartWallType.Left, True)
			m_FirstVerticalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(60, Color.Blue))
			m_FirstVerticalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Blue)
			m_FirstVerticalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkBlue)
			m_FirstVerticalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Blue, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Blue, Color.DarkBlue)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_FirstVerticalSection.LabelTextStyle = labelStyle

			' configure the second vertical section
			m_SecondVerticalSection = New NScaleSectionStyle()
			m_SecondVerticalSection.Range = New NRange1DD(70, 90)
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Back, True)
			m_SecondVerticalSection.SetShowAtWall(ChartWallType.Left, True)
			m_SecondVerticalSection.RangeFillStyle = New NColorFillStyle(Color.FromArgb(60, Color.Orange))
			m_SecondVerticalSection.MajorGridStrokeStyle = New NStrokeStyle(Color.Orange)
			m_SecondVerticalSection.MajorTickStrokeStyle = New NStrokeStyle(Color.DarkOrange)
			m_SecondVerticalSection.MinorTickStrokeStyle = New NStrokeStyle(1, Color.Orange, LinePattern.Dot, 0, 2)

			labelStyle = New NTextStyle()
			labelStyle.FillStyle = New NGradientFillStyle(Color.Orange, Color.DarkOrange)
			labelStyle.FontStyle.Style = FontStyle.Bold
			m_SecondVerticalSection.LabelTextStyle = labelStyle

			ShowFirstHorizontalSectionCheck.Checked = True
			ShowSecondHorizontalSectionCheck.Checked = True
			ShowFirstVerticalSectionCheck.Checked = True
			ShowSecondVerticalSectionCheck.Checked = True
		End Sub

		Private Sub UpdateSections()
			Dim standardScale As NStandardScaleConfigurator

			' configure horizontal axis sections
			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.Sections.Clear()

			If ShowFirstHorizontalSectionCheck.Checked Then
				standardScale.Sections.Add(m_FirstHorizontalSection)
			End If

			If ShowSecondHorizontalSectionCheck.Checked Then
				standardScale.Sections.Add(m_SecondHorizontalSection)
			End If

			' configure vertical axis sections
			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.Sections.Clear()

			If ShowFirstVerticalSectionCheck.Checked Then
				standardScale.Sections.Add(m_FirstVerticalSection)
			End If

			If ShowSecondVerticalSectionCheck.Checked Then
				standardScale.Sections.Add(m_SecondVerticalSection)
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowFirstVerticalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowFirstVerticalSectionCheck.CheckedChanged
			UpdateSections()
		End Sub

		Private Sub ShowSecondVerticalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowSecondVerticalSectionCheck.CheckedChanged
			UpdateSections()
		End Sub

		Private Sub ShowFirstHorizontalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowFirstHorizontalSectionCheck.CheckedChanged
			UpdateSections()
		End Sub

		Private Sub ShowSecondHorizontalSectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowSecondHorizontalSectionCheck.CheckedChanged
			UpdateSections()
		End Sub
	End Class
End Namespace
