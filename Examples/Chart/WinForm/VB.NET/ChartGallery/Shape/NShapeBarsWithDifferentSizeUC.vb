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
	Public Class NShapeBarsWithDifferentSizeUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Shape As NShapeSeries
		Private WithEvents Bar1FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bar2FillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Bar3FillStyleButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.Bar1FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bar2FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.Bar3FillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' Bar1FillStyleButton
			' 
			Me.Bar1FillStyleButton.Location = New System.Drawing.Point(5, 9)
			Me.Bar1FillStyleButton.Name = "Bar1FillStyleButton"
			Me.Bar1FillStyleButton.Size = New System.Drawing.Size(170, 26)
			Me.Bar1FillStyleButton.TabIndex = 0
			Me.Bar1FillStyleButton.Text = "Bar1 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar1FillStyleButton.Click += new System.EventHandler(this.Bar1FillStyleButton_Click);
			' 
			' Bar2FillStyleButton
			' 
			Me.Bar2FillStyleButton.Location = New System.Drawing.Point(5, 40)
			Me.Bar2FillStyleButton.Name = "Bar2FillStyleButton"
			Me.Bar2FillStyleButton.Size = New System.Drawing.Size(170, 26)
			Me.Bar2FillStyleButton.TabIndex = 1
			Me.Bar2FillStyleButton.Text = "Bar2 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar2FillStyleButton.Click += new System.EventHandler(this.Bar2FillStyleButton_Click);
			' 
			' Bar3FillStyleButton
			' 
			Me.Bar3FillStyleButton.Location = New System.Drawing.Point(5, 71)
			Me.Bar3FillStyleButton.Name = "Bar3FillStyleButton"
			Me.Bar3FillStyleButton.Size = New System.Drawing.Size(170, 26)
			Me.Bar3FillStyleButton.TabIndex = 2
			Me.Bar3FillStyleButton.Text = "Bar3 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Bar3FillStyleButton.Click += new System.EventHandler(this.Bar3FillStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 114)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(170, 18)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Bars Shape:"
			' 
			' StyleCombo
			' 
			Me.StyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.StyleCombo.ListProperties.DataSource = Nothing
			Me.StyleCombo.ListProperties.DisplayMember = ""
			Me.StyleCombo.Location = New System.Drawing.Point(5, 132)
			Me.StyleCombo.Name = "StyleCombo"
			Me.StyleCombo.Size = New System.Drawing.Size(170, 21)
			Me.StyleCombo.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.StyleCombo.SelectedIndexChanged += new System.EventHandler(this.StyleCombo_SelectedIndexChanged);
			' 
			' NShapeBarsWithDifferentSizeUC
			' 
			Me.Controls.Add(Me.StyleCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.Bar3FillStyleButton)
			Me.Controls.Add(Me.Bar2FillStyleButton)
			Me.Controls.Add(Me.Bar1FillStyleButton)
			Me.Name = "NShapeBarsWithDifferentSizeUC"
			Me.Size = New System.Drawing.Size(180, 177)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bars with different X and Z sizes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe 
			Dim linearScale As New NLinearScaleConfigurator()
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale

			' create the shape series
			m_Shape = CType(m_Chart.Series.Add(SeriesType.Shape), NShapeSeries)

			' show information about the data points in the legend
			m_Shape.Legend.Mode = SeriesLegendMode.DataPoints

			' show the Y size and label in the legend
			m_Shape.Legend.Format = "<ysize> <label>"

			' show the Y size and label in the data point labels
			m_Shape.DataLabelStyle.Format = "<ysize> <label>"

			' use default category positions
			m_Shape.UseXValues = False
			m_Shape.UseZValues = False

			' add the bars
			' add Bar1
			m_Shape.AddDataPoint(New NShapeDataPoint(10, 0, 0, 0.5, 20, 0.66, "Bar1")) ' label -  Z size - 2 thirds of series depth -  Y size of bar -  X size - half category in width -  Z position - not used since UseZValue is set to false -  X position - not used since UseXValue is set to false -  Y center of bar -> half its Y size

			' add Bar2
			m_Shape.AddDataPoint(New NShapeDataPoint(20, 0, 0, 0.33, 40, 0.33, "Bar2")) ' label -  Z size - 1 third of series depth -  Y size of bar -  X size - approximately 1 third of category width -  Z position - not used since UseZValue is set to false -  X position - not used since UseXValue is set to false -  Y center of bar -> half its Y size

			' add Bar3
			m_Shape.AddDataPoint(New NShapeDataPoint(15, 0, 0, 0.5, 30, 0.5, "Bar3")) ' label) -  Z size - half series depth -  Y size of bar -  X size - half category width -  Z position - not used since UseZValue is set to false -  X position - not used since UseXValue is set to false -  Y center of bar -> half its Y size

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			StyleCombo.FillFromEnum(GetType(BarShape))
			StyleCombo.SelectedIndex = 0
		End Sub

		Private Sub Bar1FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar1FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(DirectCast(m_Shape.FillStyles(0), NFillStyle), fillStyleResult) Then
				m_Shape.FillStyles(0) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub Bar2FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar2FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(DirectCast(m_Shape.FillStyles(1), NFillStyle), fillStyleResult) Then
				m_Shape.FillStyles(1) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub Bar3FillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bar3FillStyleButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(DirectCast(m_Shape.FillStyles(2), NFillStyle), fillStyleResult) Then
				m_Shape.FillStyles(2) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StyleCombo.SelectedIndexChanged
			m_Shape.Shape = CType(StyleCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace