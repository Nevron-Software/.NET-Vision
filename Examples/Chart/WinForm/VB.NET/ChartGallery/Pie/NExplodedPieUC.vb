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
	Public Class NExplodedPieUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Pie As NPieSeries
		Private WithEvents ExplodeSmallestButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExpodeBiggestButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents RemoveExplosionsButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.ExplodeSmallestButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExpodeBiggestButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.RemoveExplosionsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ExplodeSmallestButton
			' 
			Me.ExplodeSmallestButton.Location = New System.Drawing.Point(6, 73)
			Me.ExplodeSmallestButton.Name = "ExplodeSmallestButton"
			Me.ExplodeSmallestButton.Size = New System.Drawing.Size(169, 24)
			Me.ExplodeSmallestButton.TabIndex = 2
			Me.ExplodeSmallestButton.Text = "Explode Smallest"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExplodeSmallestButton.Click += new System.EventHandler(this.ExplodeSmallestButton_Click);
			' 
			' ExpodeBiggestButton
			' 
			Me.ExpodeBiggestButton.Location = New System.Drawing.Point(6, 105)
			Me.ExpodeBiggestButton.Name = "ExpodeBiggestButton"
			Me.ExpodeBiggestButton.Size = New System.Drawing.Size(169, 24)
			Me.ExpodeBiggestButton.TabIndex = 3
			Me.ExpodeBiggestButton.Text = "Expode Biggest"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExpodeBiggestButton.Click += new System.EventHandler(this.ExpodeBiggestButton_Click);
			' 
			' RemoveExplosionsButton
			' 
			Me.RemoveExplosionsButton.Location = New System.Drawing.Point(6, 40)
			Me.RemoveExplosionsButton.Name = "RemoveExplosionsButton"
			Me.RemoveExplosionsButton.Size = New System.Drawing.Size(169, 24)
			Me.RemoveExplosionsButton.TabIndex = 1
			Me.RemoveExplosionsButton.Text = "Remove Explosions"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.RemoveExplosionsButton.Click += new System.EventHandler(this.RemoveExplosionsButton_Click);
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
			' NExplodedPieUC
			' 
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Controls.Add(Me.RemoveExplosionsButton)
			Me.Controls.Add(Me.ExpodeBiggestButton)
			Me.Controls.Add(Me.ExplodeSmallestButton)
			Me.Name = "NExplodedPieUC"
			Me.Size = New System.Drawing.Size(180, 213)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Exploded Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = New NPieChart()
			m_Chart.Enable3D = True
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_Chart)

			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)

			m_Chart.DisplayOnLegend = nChartControl1.Legends(0)
			m_Chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			m_Pie = CType(m_Chart.Series.Add(SeriesType.Pie), NPieSeries)
			m_Pie.PieEdgePercent = 30
			m_Pie.PieStyle = PieStyle.SmoothEdgePie
			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints
			m_Pie.Legend.Format = "<label> <percent>"

			m_Pie.AddDataPoint(New NDataPoint(12, "Ships"))
			m_Pie.AddDataPoint(New NDataPoint(42, "Trains"))
			m_Pie.AddDataPoint(New NDataPoint(56, "Cars"))
			m_Pie.AddDataPoint(New NDataPoint(23, "Buses"))
			m_Pie.AddDataPoint(New NDataPoint(18, "Airplanes"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			FillDetachments()
		End Sub

		Private Sub FillDetachments()
			m_Pie.Detachments.Clear()

			For i As Integer = 0 To m_Pie.Values.Count - 1
				m_Pie.Detachments.Add(0.0)
			Next i
		End Sub

		Private Sub RemoveExplosionsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveExplosionsButton.Click
			' set all pie detachments to 0
			For i As Integer = 0 To m_Pie.Detachments.Count - 1
				m_Pie.Detachments(i) = 0.0
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub ExplodeSmallestButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExplodeSmallestButton.Click
			Dim nIndex As Integer = m_Pie.Values.FindMinValue()
			m_Pie.Detachments(nIndex) = 5.0F
			nChartControl1.Refresh()
		End Sub

		Private Sub ExpodeBiggestButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpodeBiggestButton.Click
			Dim nIndex As Integer = m_Pie.Values.FindMaxValue()
			m_Pie.Detachments(nIndex) = 5.0F
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDataButton.Click
			m_Pie.Values.FillRandomRange(Random, 5, 1, 60)
			FillDetachments()

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace