Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Resources
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NChartAspect2DUC
		Inherits NExampleBaseUC

		Private label2 As Label
		Private WithEvents XProportionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As Label
		Private label3 As Label
		Private WithEvents YProportionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents UsePlotAspectCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowContentAreaCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private label4 As Label
		Private WithEvents FitAxisContentModeComboBox As UI.WinForm.Controls.NComboBox
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.XProportionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.YProportionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.UsePlotAspectCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowContentAreaCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.FitAxisContentModeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 75)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 14)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Proportion:"
			' 
			' XProportionCombo
			' 
			Me.XProportionCombo.ListProperties.CheckBoxDataMember = ""
			Me.XProportionCombo.ListProperties.DataSource = Nothing
			Me.XProportionCombo.ListProperties.DisplayMember = ""
			Me.XProportionCombo.Location = New System.Drawing.Point(41, 96)
			Me.XProportionCombo.Name = "XProportionCombo"
			Me.XProportionCombo.Size = New System.Drawing.Size(118, 21)
			Me.XProportionCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XProportionCombo.SelectedIndexChanged += new System.EventHandler(this.XProportionCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 103)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(29, 14)
			Me.label1.TabIndex = 4
			Me.label1.Text = "X:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 130)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(29, 14)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Y:"
			' 
			' YProportionCombo
			' 
			Me.YProportionCombo.ListProperties.CheckBoxDataMember = ""
			Me.YProportionCombo.ListProperties.DataSource = Nothing
			Me.YProportionCombo.ListProperties.DisplayMember = ""
			Me.YProportionCombo.Location = New System.Drawing.Point(41, 123)
			Me.YProportionCombo.Name = "YProportionCombo"
			Me.YProportionCombo.Size = New System.Drawing.Size(118, 21)
			Me.YProportionCombo.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YProportionCombo.SelectedIndexChanged += new System.EventHandler(this.YProportionCombo_SelectedIndexChanged);
			' 
			' UsePlotAspectCheckBox
			' 
			Me.UsePlotAspectCheckBox.ButtonProperties.BorderOffset = 2
			Me.UsePlotAspectCheckBox.Location = New System.Drawing.Point(8, 51)
			Me.UsePlotAspectCheckBox.Name = "UsePlotAspectCheckBox"
			Me.UsePlotAspectCheckBox.Size = New System.Drawing.Size(157, 21)
			Me.UsePlotAspectCheckBox.TabIndex = 2
			Me.UsePlotAspectCheckBox.Text = "Use Plot Aspect"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UsePlotAspectCheckBox.CheckedChanged += new System.EventHandler(this.UsePlotAspectCheckBox_CheckedChanged);
			' 
			' ShowContentAreaCheckBox
			' 
			Me.ShowContentAreaCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowContentAreaCheckBox.Location = New System.Drawing.Point(8, 150)
			Me.ShowContentAreaCheckBox.Name = "ShowContentAreaCheckBox"
			Me.ShowContentAreaCheckBox.Size = New System.Drawing.Size(157, 21)
			Me.ShowContentAreaCheckBox.TabIndex = 8
			Me.ShowContentAreaCheckBox.Text = "Show Content Area"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowContentAreaCheckBox.CheckedChanged += new System.EventHandler(this.ShowContentAreaCheckBox_CheckedChanged);
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(8, 8)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(113, 13)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Fit Axis Content Mode:"
			' 
			' FitAxisContentModeComboBox
			' 
			Me.FitAxisContentModeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.FitAxisContentModeComboBox.ListProperties.DataSource = Nothing
			Me.FitAxisContentModeComboBox.ListProperties.DisplayMember = ""
			Me.FitAxisContentModeComboBox.Location = New System.Drawing.Point(8, 24)
			Me.FitAxisContentModeComboBox.Name = "FitAxisContentModeComboBox"
			Me.FitAxisContentModeComboBox.Size = New System.Drawing.Size(151, 21)
			Me.FitAxisContentModeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FitAxisContentModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FitAxisContentModeComboBox_SelectedIndexChanged);
			' 
			' NChartAspect2DUC
			' 
			Me.Controls.Add(Me.FitAxisContentModeComboBox)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.ShowContentAreaCheckBox)
			Me.Controls.Add(Me.UsePlotAspectCheckBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.YProportionCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.XProportionCombo)
			Me.Name = "NChartAspect2DUC"
			Me.Size = New System.Drawing.Size(180, 370)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Chart Aspect 2D")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10, 10, 10, 0)
			nChartControl1.Panels.Add(title)

			Dim chart As New NCartesianChart()
			nChartControl1.Panels.Add(chart)

			chart.DockMode = PanelDockMode.Fill
			chart.Margins = New NMarginsL(New NLength(30))
			chart.Padding = New NMarginsL(0)
			chart.BoundsMode = BoundsMode.Stretch
			chart.UsePlotAspect = True
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: chart.Width = chart.Height = 50;
			chart.Height = 50
			chart.Width = chart.Height

			' switch all axes to linear mode
			Dim xScale As New NLinearScaleConfigurator()
			xScale.Title.Text = "X Scale Title"
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			xScale.LabelStyle.Angle = New NScaleLabelAngle(ScaleLabelAngleMode.View, 90, False)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale

			Dim yScale As New NLinearScaleConfigurator()
			yScale.Title.Text = "Y Scale Title"
			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale

			chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator = New NLinearScaleConfigurator()

			' cross secondary X and Y axes
			chart.Axis(StandardAxis.SecondaryX).Anchor = New NCrossAxisAnchor(AxisOrientation.Horizontal, New NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryY), 0))
			chart.Axis(StandardAxis.SecondaryY).Anchor = New NCrossAxisAnchor(AxisOrientation.Vertical, New NValueAxisCrossing(chart.Axis(StandardAxis.PrimaryX), 0))

			' show secondary axes
			chart.Axis(StandardAxis.SecondaryX).Visible = True
			chart.Axis(StandardAxis.SecondaryY).Visible = True

			' turn off labels for cross axes
			Dim secondaryScaleX As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.SecondaryX).ScaleConfigurator, NLinearScaleConfigurator)
			secondaryScaleX.AutoLabels = False

			Dim secondaryScaleY As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.SecondaryY).ScaleConfigurator, NLinearScaleConfigurator)
			secondaryScaleY.AutoLabels = False

			' add some dummy data
			Dim point As New NPointSeries()
			chart.Series.Add(point)
			point.DataLabelStyle.Visible = False
			point.UseXValues = True

			point.DisplayOnAxis(CInt(StandardAxis.SecondaryX), True)
			point.DisplayOnAxis(CInt(StandardAxis.SecondaryY), True)
			point.Size = New NLength(1)
			point.BorderStyle.Width = New NLength(0)
			point.ClusterMode = ClusterMode.Enabled

			' add some random data in the range [-100, 100]
			Dim rand As New Random()

			For i As Integer = 0 To 2999
				point.Values.Add(rand.Next(200) - 100)
				point.XValues.Add(rand.Next(200) - 100)
			Next i

			' init form controls
			For i As Integer = 1 To 5
				XProportionCombo.Items.Add(i.ToString())
				YProportionCombo.Items.Add(i.ToString())
			Next i
			FitAxisContentModeComboBox.FillFromEnum(GetType(Fit2DAxisContentMode))

			FitAxisContentModeComboBox.SelectedIndex = CInt(chart.Fit2DAxisContentMode)
			XProportionCombo.SelectedIndex = 0
			YProportionCombo.SelectedIndex = 0

			UsePlotAspectCheckBox.Checked = False
			ShowContentAreaCheckBox.Checked = True
		End Sub

		Private Sub UpdateChart()
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)

			chart.DisableContentAreaPixelSnapping = True

			chart.Width = (XProportionCombo.SelectedIndex + 1) * 10
			chart.Height = (YProportionCombo.SelectedIndex + 1) * 10
			chart.UsePlotAspect = UsePlotAspectCheckBox.Checked

			If ShowContentAreaCheckBox.Checked Then
				chart.BorderStyle = New NStrokeBorderStyle()
			Else
				chart.BorderStyle = Nothing
			End If

			chart.Fit2DAxisContentMode = CType(FitAxisContentModeComboBox.SelectedIndex, Fit2DAxisContentMode)

			Dim fit2DAxisContent As Boolean = chart.Fit2DAxisContentMode <> Fit2DAxisContentMode.Disabled

			XProportionCombo.Enabled = fit2DAxisContent AndAlso UsePlotAspectCheckBox.Checked
			YProportionCombo.Enabled = fit2DAxisContent AndAlso UsePlotAspectCheckBox.Checked
			UsePlotAspectCheckBox.Enabled = fit2DAxisContent

			nChartControl1.Refresh()
		End Sub

		Private Sub XProportionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles XProportionCombo.SelectedIndexChanged
			UpdateChart()
		End Sub

		Private Sub YProportionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles YProportionCombo.SelectedIndexChanged
			UpdateChart()
		End Sub

		Private Sub UsePlotAspectCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UsePlotAspectCheckBox.CheckedChanged
			UpdateChart()
		End Sub

		Private Sub ShowContentAreaCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowContentAreaCheckBox.CheckedChanged
			UpdateChart()
		End Sub

		Private Sub FitAxisContentCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateChart()
		End Sub

		Private Sub FitAxisContentModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles FitAxisContentModeComboBox.SelectedIndexChanged
			UpdateChart()
		End Sub
	End Class
End Namespace
