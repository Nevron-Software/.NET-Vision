Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NMultiMeasureRadarUC
		Inherits NExampleBaseUC

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' NMultiMeasureRadarUC
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Name = "NMultiMeasureRadarUC"
			Me.Size = New System.Drawing.Size(180, 150)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Montana County Comparison<br/><font size = '9pt'>Demonstrates how to create a multi measure radar chart</font>")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.TextFormat = TextFormat.XML
			title.ContentAlignment = ContentAlignment.BottomRight
			title.Location = New NPointL(New NLength(2, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(0, 5, 0, 5)
			nChartControl1.Panels.Add(title)

			Dim legend As New NLegend()
			legend.DockMode = PanelDockMode.Right
			legend.Margins = New NMarginsL(5, 0, 5, 0)
			nChartControl1.Panels.Add(legend)

			' setup chart
			Dim radarChart As New NRadarChart()
			radarChart.Margins = New NMarginsL(5, 0, 0, 5)
			nChartControl1.Panels.Add(radarChart)
			radarChart.DisplayOnLegend = legend
			radarChart.DockMode = PanelDockMode.Fill
			radarChart.RadarMode = RadarMode.MultiMeasure
			radarChart.InnerRadius = New NLength(10, NRelativeUnit.ParentPercentage)

			' set some axis labels
			AddAxis(radarChart, "Population", True)
			AddAxis(radarChart, "Housing Units", True)
			AddAxis(radarChart, "Water", False)
			AddAxis(radarChart, "Land", True)
			AddAxis(radarChart, "Population" & ControlChars.CrLf & "Density", False)
			AddAxis(radarChart, "Housing" & ControlChars.CrLf & "Density", False)

			' sample data
			Dim data() As Object = { "Cascade County", 80357, 35225, 13.75, 2697.90, 29.8, 13.1, "Custer County", 11696, 5360, 10.09, 3783.13, 3.1, 1.4, "Dawson County", 9059, 4168, 9.99, 2373.14, 3.8, 1.8, "Jefferson County", 10049, 4199, 2.19, 1656.64, 6.1, 2.5, "Missoula County", 95802, 41319, 20.37, 2597.97, 36.9, 15.9, "Powell County", 7180, 2930, 6.74, 2325.94, 3.1, 1.3 }

			For i As Integer = 0 To 5
				Dim radarLine As New NRadarLineSeries()
				radarChart.Series.Add(radarLine)

				Dim baseIndex As Integer = i * 7
				radarLine.Name = data(baseIndex).ToString()
				baseIndex = baseIndex + 1

				For j As Integer = 0 To 5
					radarLine.Values.Add(System.Convert.ToDouble(data(baseIndex)))
					baseIndex = baseIndex + 1
				Next j

				radarLine.DataLabelStyle.Visible = False
				radarLine.MarkerStyle.Width = New NLength(4)
				radarLine.MarkerStyle.Height = New NLength(4)
				radarLine.MarkerStyle.Visible = True
				radarLine.BorderStyle.Width = New NLength(2)
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub AddAxis(ByVal radar As NRadarChart, ByVal title As String, ByVal applyKFormatting As Boolean)
			Dim axis As New NRadarAxis()

			' set title
			axis.Title = title
			radar.Axes.Add(axis)

			If applyKFormatting Then
				Dim linearScale As NLinearScaleConfigurator = TryCast(axis.ScaleConfigurator, NLinearScaleConfigurator)
				linearScale.LabelValueFormatter = New NNumericValueFormatter("0,K")
			End If
		End Sub
	End Class
End Namespace
