Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Diagnostics
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDoughnutPieUC
		Inherits NExampleBaseUC

		Private m_PieChart As NPieChart
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
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(6, 8)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(169, 24)
			Me.ChangeDataButton.TabIndex = 0
			Me.ChangeDataButton.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' NDoughnutPieUC
			' 
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Name = "NDoughnutPieUC"
			Me.Size = New System.Drawing.Size(180, 213)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Doughnut Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_PieChart = New NPieChart()
			m_PieChart.Enable3D = True
			nChartControl1.Charts.Clear()
			nChartControl1.Panels.Add(m_PieChart)

			m_PieChart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			m_PieChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)

			m_PieChart.DisplayOnLegend = nChartControl1.Legends(0)
			m_PieChart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_PieChart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))
			m_PieChart.InnerRadius = New NLength(10, NRelativeUnit.ParentPercentage)

'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()
			Dim labels() As String = { "Ships", "Trains", "Automobiles", "Airplanes" }

			For i As Integer = 0 To 3
				Dim pieSeries As New NPieSeries()

				' create a small detachment between pie rings
				pieSeries.BeginRadiusPercent = 10
				pieSeries.PieStyle = PieStyle.Ring

				m_PieChart.Series.Add(pieSeries)

				pieSeries.DataLabelStyle.ArrowLength = New NLength(0)
				pieSeries.DataLabelStyle.ArrowPointerLength = New NLength(0)
				pieSeries.DataLabelStyle.Format = "<percent>"

				If i = 0 Then
					pieSeries.Legend.Mode = SeriesLegendMode.DataPoints
					pieSeries.Legend.Format = "<label>"
				Else
					pieSeries.Legend.Mode = SeriesLegendMode.None
				End If

				pieSeries.LabelMode = PieLabelMode.Center

				For j As Integer = 0 To labels.Length - 1
					pieSeries.Values.Add(20 + random_Renamed.Next(100))
					pieSeries.Labels.Add(labels(j))
				Next j
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub


		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDataButton.Click
			For Each pie As NPieSeries In m_PieChart.Series
				pie.Values.FillRandomRange(Random, 4, 1, 60)
			Next pie

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace