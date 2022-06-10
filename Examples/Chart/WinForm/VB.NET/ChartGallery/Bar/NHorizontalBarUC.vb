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
	<ToolboxItem(False)>
	Public Class NHorizontalBarUC
		Inherits NExampleBaseUC

		Private Const categoriesCount As Integer = 6
		Private WithEvents PositiveData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveNegativeData As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
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
			Me.PositiveData = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveNegativeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' PositiveData
			' 
			Me.PositiveData.Location = New System.Drawing.Point(8, 58)
			Me.PositiveData.Name = "PositiveData"
			Me.PositiveData.Size = New System.Drawing.Size(156, 23)
			Me.PositiveData.TabIndex = 2
			Me.PositiveData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveData.Click += new System.EventHandler(this.PositiveData_Click);
			' 
			' PositiveNegativeData
			' 
			Me.PositiveNegativeData.Location = New System.Drawing.Point(8, 90)
			Me.PositiveNegativeData.Name = "PositiveNegativeData"
			Me.PositiveNegativeData.Size = New System.Drawing.Size(156, 23)
			Me.PositiveNegativeData.TabIndex = 3
			Me.PositiveNegativeData.Text = "Positive And Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeData_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Bar Style:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(8, 25)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(158, 21)
			Me.StyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' NHorizontalBarUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.PositiveNegativeData)
			Me.Controls.Add(Me.PositiveData)
			Me.Name = "NHorizontalBarUC"
			Me.Size = New System.Drawing.Size(180, 196)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Horizontal Bar Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterRight)
			chart.Width = 40
			chart.Height = 65

			chart.Axis(StandardAxis.PrimaryY).Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, True, 0, 100)
			chart.Axis(StandardAxis.Depth).Visible = False

			' add interlace stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add a bar series
			Dim b1 As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			b1.MultiBarMode = MultiBarMode.Series
			b1.Name = "Bar 1"
			b1.DataLabelStyle.Format = "<value>"
			b1.Legend.Mode = SeriesLegendMode.DataPoints
			b1.Values.AddRange(New Double(){ 10, 27, 43, 71, 89, 93 })

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			StyleCombo.FillFromEnum(GetType(BarShape))
			StyleCombo.SelectedIndex = 0
		End Sub

		Private Sub PositiveData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveData.Click
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			nChartControl1.Refresh()
		End Sub

		Private Sub PositiveNegativeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveNegativeData.Click
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.Values.FillRandomRange(Random, categoriesCount, -100, 100)
			nChartControl1.Refresh()
		End Sub

		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.BarShape = CType(StyleCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
