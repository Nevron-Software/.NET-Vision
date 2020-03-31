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
	Public Class NSeriesAppearanceAttributesUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private WithEvents btnDefaultFillStyle As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnDefaultBorder As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnBar3FillStyle As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnBar3Border As Nevron.UI.WinForm.Controls.NButton
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
			Me.btnDefaultFillStyle = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnDefaultBorder = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnBar3FillStyle = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnBar3Border = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' btnDefaultFillStyle
			' 
			Me.btnDefaultFillStyle.Location = New System.Drawing.Point(5, 7)
			Me.btnDefaultFillStyle.Name = "btnDefaultFillStyle"
			Me.btnDefaultFillStyle.Size = New System.Drawing.Size(170, 23)
			Me.btnDefaultFillStyle.TabIndex = 0
			Me.btnDefaultFillStyle.Text = "Default Bar Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnDefaultFillStyle.Click += new System.EventHandler(this.DefaultFillStyle_Click);
			' 
			' btnDefaultBorder
			' 
			Me.btnDefaultBorder.Location = New System.Drawing.Point(5, 39)
			Me.btnDefaultBorder.Name = "btnDefaultBorder"
			Me.btnDefaultBorder.Size = New System.Drawing.Size(170, 23)
			Me.btnDefaultBorder.TabIndex = 1
			Me.btnDefaultBorder.Text = "Default Bar Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnDefaultBorder.Click += new System.EventHandler(this.DefaultBorder_Click);
			' 
			' btnBar3FillStyle
			' 
			Me.btnBar3FillStyle.Location = New System.Drawing.Point(5, 98)
			Me.btnBar3FillStyle.Name = "btnBar3FillStyle"
			Me.btnBar3FillStyle.Size = New System.Drawing.Size(170, 23)
			Me.btnBar3FillStyle.TabIndex = 2
			Me.btnBar3FillStyle.Text = "Bar #3 Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnBar3FillStyle.Click += new System.EventHandler(this.Bar3FillStyle_Click);
			' 
			' btnBar3Border
			' 
			Me.btnBar3Border.Location = New System.Drawing.Point(5, 130)
			Me.btnBar3Border.Name = "btnBar3Border"
			Me.btnBar3Border.Size = New System.Drawing.Size(170, 23)
			Me.btnBar3Border.TabIndex = 3
			Me.btnBar3Border.Text = "Bar #3 Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.btnBar3Border.Click += new System.EventHandler(this.Bar3Border_Click);
			' 
			' NSeriesAttribsAppearanceUC
			' 
			Me.Controls.Add(Me.btnBar3FillStyle)
			Me.Controls.Add(Me.btnBar3Border)
			Me.Controls.Add(Me.btnDefaultFillStyle)
			Me.Controls.Add(Me.btnDefaultBorder)
			Me.Name = "NSeriesAttribsAppearanceUC"
			Me.Size = New System.Drawing.Size(180, 190)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Series Appearance Attributes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' apply lighting and projectection
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			' setup bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.FillStyle = New NColorFillStyle(LightGreen)
			m_Bar.Name = "Bar"

			' fill data
			m_Bar.AddDataPoint(New NDataPoint(10))
			m_Bar.AddDataPoint(New NDataPoint(20))
			m_Bar.AddDataPoint(New NDataPoint(30))

			' set an individual Fill Style and Stroke Style for data point #3
			Dim dp As New NDataPoint(25)
			dp(DataPointValue.FillStyle) = New NGradientFillStyle(LightOrange, DarkOrange)
			dp(DataPointValue.StrokeStyle) = New NStrokeStyle(1, DarkOrange, LinePattern.Dot, 0, 1)
			m_Bar.AddDataPoint(dp)

			m_Bar.AddDataPoint(New NDataPoint(29))
			m_Bar.AddDataPoint(New NDataPoint(27))

			' apply layout
			ConfigureStandardLayout(m_Chart, title, Nothing)
		End Sub

		Private Sub DefaultFillStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefaultFillStyle.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_Bar.FillStyle, fillStyleResult) Then
				m_Bar.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub DefaultBorder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefaultBorder.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing

			If NStrokeStyleTypeEditor.Edit(m_Bar.BorderStyle, strokeStyleResult) Then
				m_Bar.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub Bar3FillStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBar3FillStyle.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim inFillStyle As NFillStyle = DirectCast(m_Bar.FillStyles(3), NFillStyle)

			If NFillStyleTypeEditor.Edit(inFillStyle, False, fillStyleResult) Then
				m_Bar.FillStyles(3) = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub Bar3Border_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBar3Border.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim inStrokeStyle As NStrokeStyle = DirectCast(m_Bar.BorderStyles(3), NStrokeStyle)

			If NStrokeStyleTypeEditor.Edit(inStrokeStyle, False, strokeStyleResult) Then
				m_Bar.BorderStyles(3) = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace