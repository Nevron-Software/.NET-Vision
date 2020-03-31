Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NRasterImageExportUC
		Inherits NExampleBaseUC

		Private label1 As System.Windows.Forms.Label
		Private WithEvents BarShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BarFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarBorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowDataLabelsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ExportBMPButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportPNGButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportJPEGButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportGIFButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportTIFFButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.BarShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BarFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BarBorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowDataLabelsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ExportBMPButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportPNGButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportJPEGButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportGIFButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportTIFFButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 10)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(171, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Bar Shape:"
			' 
			' BarShapeCombo
			' 
			Me.BarShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BarShapeCombo.ListProperties.DataSource = Nothing
			Me.BarShapeCombo.ListProperties.DisplayMember = ""
			Me.BarShapeCombo.Location = New System.Drawing.Point(5, 27)
			Me.BarShapeCombo.Name = "BarShapeCombo"
			Me.BarShapeCombo.Size = New System.Drawing.Size(171, 21)
			Me.BarShapeCombo.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarStyleCombo_SelectedIndexChanged);
			' 
			' BarFEButton
			' 
			Me.BarFEButton.Location = New System.Drawing.Point(5, 58)
			Me.BarFEButton.Name = "BarFEButton"
			Me.BarFEButton.Size = New System.Drawing.Size(171, 24)
			Me.BarFEButton.TabIndex = 4
			Me.BarFEButton.Text = "Bar Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarFEButton.Click += new System.EventHandler(this.BarFEButton_Click);
			' 
			' BarBorderButton
			' 
			Me.BarBorderButton.Location = New System.Drawing.Point(5, 89)
			Me.BarBorderButton.Name = "BarBorderButton"
			Me.BarBorderButton.Size = New System.Drawing.Size(171, 24)
			Me.BarBorderButton.TabIndex = 18
			Me.BarBorderButton.Text = "Bar Border..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarBorderButton.Click += new System.EventHandler(this.BarBorderButton_Click);
			' 
			' ShowDataLabelsCheck
			' 
			Me.ShowDataLabelsCheck.ButtonProperties.BorderOffset = 2
			Me.ShowDataLabelsCheck.Location = New System.Drawing.Point(5, 131)
			Me.ShowDataLabelsCheck.Name = "ShowDataLabelsCheck"
			Me.ShowDataLabelsCheck.Size = New System.Drawing.Size(171, 21)
			Me.ShowDataLabelsCheck.TabIndex = 27
			Me.ShowDataLabelsCheck.Text = "Show Data Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowDataLabelsCheck.CheckedChanged += new System.EventHandler(this.ShowDataLabelsCheck_CheckedChanged);
			' 
			' ExportBMPButton
			' 
			Me.ExportBMPButton.Location = New System.Drawing.Point(5, 176)
			Me.ExportBMPButton.Name = "ExportBMPButton"
			Me.ExportBMPButton.Size = New System.Drawing.Size(171, 24)
			Me.ExportBMPButton.TabIndex = 28
			Me.ExportBMPButton.Text = "Export BMP"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportBMPButton.Click += new System.EventHandler(this.ExportBMPButton_Click);
			' 
			' ExportPNGButton
			' 
			Me.ExportPNGButton.Location = New System.Drawing.Point(5, 208)
			Me.ExportPNGButton.Name = "ExportPNGButton"
			Me.ExportPNGButton.Size = New System.Drawing.Size(171, 24)
			Me.ExportPNGButton.TabIndex = 29
			Me.ExportPNGButton.Text = "Export PNG"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportPNGButton.Click += new System.EventHandler(this.ExportPNGButton_Click);
			' 
			' ExportJPEGButton
			' 
			Me.ExportJPEGButton.Location = New System.Drawing.Point(5, 240)
			Me.ExportJPEGButton.Name = "ExportJPEGButton"
			Me.ExportJPEGButton.Size = New System.Drawing.Size(171, 24)
			Me.ExportJPEGButton.TabIndex = 30
			Me.ExportJPEGButton.Text = "Export JPEG"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportJPEGButton.Click += new System.EventHandler(this.ExportJPEGButton_Click);
			' 
			' ExportGIFButton
			' 
			Me.ExportGIFButton.Location = New System.Drawing.Point(5, 272)
			Me.ExportGIFButton.Name = "ExportGIFButton"
			Me.ExportGIFButton.Size = New System.Drawing.Size(171, 24)
			Me.ExportGIFButton.TabIndex = 31
			Me.ExportGIFButton.Text = "Export GIF"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportGIFButton.Click += new System.EventHandler(this.ExportGIFButton_Click);
			' 
			' ExportTIFFButton
			' 
			Me.ExportTIFFButton.Location = New System.Drawing.Point(5, 304)
			Me.ExportTIFFButton.Name = "ExportTIFFButton"
			Me.ExportTIFFButton.Size = New System.Drawing.Size(171, 24)
			Me.ExportTIFFButton.TabIndex = 32
			Me.ExportTIFFButton.Text = "Export TIFF"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportTIFFButton.Click += new System.EventHandler(this.ExportTIFFButton_Click);
			' 
			' NRasterImageExportUC
			' 
			Me.Controls.Add(Me.ExportTIFFButton)
			Me.Controls.Add(Me.ExportGIFButton)
			Me.Controls.Add(Me.ExportJPEGButton)
			Me.Controls.Add(Me.ExportPNGButton)
			Me.Controls.Add(Me.ExportBMPButton)
			Me.Controls.Add(Me.ShowDataLabelsCheck)
			Me.Controls.Add(Me.BarBorderButton)
			Me.Controls.Add(Me.BarFEButton)
			Me.Controls.Add(Me.BarShapeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "NRasterImageExportUC"
			Me.Size = New System.Drawing.Size(180, 347)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("3D Floating Bars")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' no legend
			nChartControl1.Legends.Clear()

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.SoftTopLeft)

			' setup X axis
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.DisplayDataPointsBetweenTicks = False
			For i As Integer = 0 To monthLetters.Length - 1
				scaleX.CustomLabels.Add(New NCustomValueLabel(i, monthLetters(i)))
			Next i

			' add interlaced stripe to the Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.ShowAtWalls = New ChartWallType() { ChartWallType.Back, ChartWallType.Left }
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

			' create the float bar series
			Dim floatBar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatBar.DataLabelStyle.Visible = False
			floatBar.DataLabelStyle.VertAlign = VertAlign.Center
			floatBar.DataLabelStyle.Format = "<begin> - <end>"

			' add bars
			floatBar.AddDataPoint(New NFloatBarDataPoint(2, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 16))
			floatBar.AddDataPoint(New NFloatBarDataPoint(9, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(12, 21))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(7, 18))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 11))
			floatBar.AddDataPoint(New NFloatBarDataPoint(5, 12))
			floatBar.AddDataPoint(New NFloatBarDataPoint(8, 17))
			floatBar.AddDataPoint(New NFloatBarDataPoint(6, 15))
			floatBar.AddDataPoint(New NFloatBarDataPoint(3, 10))
			floatBar.AddDataPoint(New NFloatBarDataPoint(1, 7))

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			BarShapeCombo.FillFromEnum(GetType(BarShape))
			BarShapeCombo.SelectedIndex = 0
		End Sub

		Private Sub BarFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NFillStyleTypeEditor.Edit(series.FillStyle, fillStyleResult) Then
				series.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BarBorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarBorderButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)

			If NStrokeStyleTypeEditor.Edit(series.BorderStyle, strokeStyleResult) Then
				series.BorderStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub BarStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarShapeCombo.SelectedIndexChanged
			Dim floatBar As NFloatBarSeries = CType(nChartControl1.Charts(0).Series(0), NFloatBarSeries)
			floatBar.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub ShowDataLabelsCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataLabelsCheck.CheckedChanged
			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			series.DataLabelStyle.Visible = ShowDataLabelsCheck.Checked
			nChartControl1.Refresh()
		End Sub

		Private Sub ExportBMPButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportBMPButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.bmp"

				Dim fmt As New NBitmapImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub

		Private Sub ExportPNGButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportPNGButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.png"

				Dim fmt As New NPngImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub

		Private Sub ExportJPEGButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportJPEGButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.jpg"

				Dim fmt As New NJpegImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub

		Private Sub ExportGIFButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportGIFButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.gif"

				Dim fmt As New NGifImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub

		Private Sub ExportTIFFButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportTIFFButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.tif"

				Dim fmt As New NTiffImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub
	End Class
End Namespace
