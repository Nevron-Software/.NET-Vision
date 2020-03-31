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
	<ToolboxItem(False)> _
	Public Class NSortedPieUC
		Inherits NExampleBaseUC

		Private m_Pie As NPieSeries
		Private WithEvents SortAscendingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SortDescendingButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeDataButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.SortAscendingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SortDescendingButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' SortAscendingButton
			' 
			Me.SortAscendingButton.Location = New System.Drawing.Point(5, 41)
			Me.SortAscendingButton.Name = "SortAscendingButton"
			Me.SortAscendingButton.Size = New System.Drawing.Size(170, 24)
			Me.SortAscendingButton.TabIndex = 1
			Me.SortAscendingButton.Text = "Sort Ascending"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SortAscendingButton.Click += new System.EventHandler(this.SortAscendingButton_Click);
			' 
			' SortDescendingButton
			' 
			Me.SortDescendingButton.Location = New System.Drawing.Point(5, 73)
			Me.SortDescendingButton.Name = "SortDescendingButton"
			Me.SortDescendingButton.Size = New System.Drawing.Size(170, 24)
			Me.SortDescendingButton.TabIndex = 2
			Me.SortDescendingButton.Text = "Sort Descending"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SortDescendingButton.Click += new System.EventHandler(this.SortDescendingButton_Click);
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(5, 9)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(170, 24)
			Me.ChangeDataButton.TabIndex = 0
			Me.ChangeDataButton.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' NSortedPieUC
			' 
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Controls.Add(Me.SortDescendingButton)
			Me.Controls.Add(Me.SortAscendingButton)
			Me.Name = "NSortedPieUC"
			Me.Size = New System.Drawing.Size(180, 129)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Sorted Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = New NPieChart()
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			' configure the chart
			chart.Enable3D = True
			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.VividCameraLight)
			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.Location = New NPointL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			' configure the legend
			Dim legend As NLegend = nChartControl1.Legends(0)
			legend.FillStyle = New NColorFillStyle(Color.FromArgb(100, Color.White))

			' configure the pie series
			m_Pie = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints
			m_Pie.Legend.Format = "<label> <percent>"

			' add data
			m_Pie.BorderStyle.Color = Color.LightGray
			m_Pie.AddDataPoint(New NDataPoint(0, "Cars"))
			m_Pie.AddDataPoint(New NDataPoint(0, "Trains"))
			m_Pie.AddDataPoint(New NDataPoint(0, "Airplanes"))
			m_Pie.AddDataPoint(New NDataPoint(0, "Buses"))
			m_Pie.AddDataPoint(New NDataPoint(0, "Ships"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			ChangeDataButton_Click(Nothing, Nothing)
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDataButton.Click
			m_Pie.Values.FillRandom(Random, 5)
			nChartControl1.Refresh()
		End Sub

		Private Sub SortAscendingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortAscendingButton.Click
			Dim included As DataSeriesMask = DataSeriesMask.RandomAccess Or DataSeriesMask.FillStyles Or DataSeriesMask.StrokeStyles Or DataSeriesMask.DataLabelStyles
			Dim excluded As DataSeriesMask = DataSeriesMask.PieDetachments
			Dim arr As NDataSeriesCollection = m_Pie.GetDataSeries(included, excluded, False)

			Dim masterDataSeries As Integer = arr.FindByMask(DataSeriesMask.Values)
			arr.Sort(masterDataSeries, DataSeriesSortOrder.Ascending)

			nChartControl1.Refresh()
		End Sub

		Private Sub SortDescendingButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortDescendingButton.Click
			Dim included As DataSeriesMask = DataSeriesMask.RandomAccess Or DataSeriesMask.FillStyles Or DataSeriesMask.StrokeStyles Or DataSeriesMask.DataLabelStyles
			Dim excluded As DataSeriesMask = DataSeriesMask.PieDetachments
			Dim arr As NDataSeriesCollection = m_Pie.GetDataSeries(included, excluded, False)

			Dim masterDataSeries As Integer = arr.FindByMask(DataSeriesMask.Values)
			arr.Sort(masterDataSeries, DataSeriesSortOrder.Descending)

			nChartControl1.Refresh()
		End Sub

	End Class
End Namespace
