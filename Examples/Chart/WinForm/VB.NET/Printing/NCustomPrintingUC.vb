Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.View
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomPrintingUC
		Inherits NExampleBaseUC

		Private m_PrintDocument As PrintDocument
		Private WithEvents PrintButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrintPreviewButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrinterSetupButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PageSetupButton As Nevron.UI.WinForm.Controls.NButton
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

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
			Me.PrintButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrintPreviewButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrinterSetupButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PageSetupButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' PrintButton
			' 
			Me.PrintButton.Location = New System.Drawing.Point(5, 120)
			Me.PrintButton.Name = "PrintButton"
			Me.PrintButton.Size = New System.Drawing.Size(170, 23)
			Me.PrintButton.TabIndex = 7
			Me.PrintButton.Text = "Print"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			' 
			' PrintPreviewButton
			' 
			Me.PrintPreviewButton.Location = New System.Drawing.Point(5, 88)
			Me.PrintPreviewButton.Name = "PrintPreviewButton"
			Me.PrintPreviewButton.Size = New System.Drawing.Size(170, 23)
			Me.PrintPreviewButton.TabIndex = 6
			Me.PrintPreviewButton.Text = "Print Preview..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			' 
			' PrinterSetupButton
			' 
			Me.PrinterSetupButton.Location = New System.Drawing.Point(5, 48)
			Me.PrinterSetupButton.Name = "PrinterSetupButton"
			Me.PrinterSetupButton.Size = New System.Drawing.Size(170, 23)
			Me.PrinterSetupButton.TabIndex = 5
			Me.PrinterSetupButton.Text = "Printer setup..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrinterSetupButton.Click += new System.EventHandler(this.PrinterSetupButton_Click);
			' 
			' PageSetupButton
			' 
			Me.PageSetupButton.Location = New System.Drawing.Point(5, 16)
			Me.PageSetupButton.Name = "PageSetupButton"
			Me.PageSetupButton.Size = New System.Drawing.Size(170, 23)
			Me.PageSetupButton.TabIndex = 4
			Me.PageSetupButton.Text = "Page setup..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PageSetupButton.Click += new System.EventHandler(this.PageSetupButton_Click);
			' 
			' NCustomPrintingUC
			' 
			Me.Controls.Add(Me.PrintButton)
			Me.Controls.Add(Me.PrintPreviewButton)
			Me.Controls.Add(Me.PrinterSetupButton)
			Me.Controls.Add(Me.PageSetupButton)
			Me.Name = "NCustomPrintingUC"
			Me.Size = New System.Drawing.Size(180, 392)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub InitChart()
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False

			nChartControl1.Controller.Selection.Add(chart)
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Custom Printing")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar series"
			bar.FillStyle = New NColorFillStyle(Color.Green)
			bar.DataLabelStyle.Visible = False
			bar.Values.FillRandomRange(Random, 8, 7, 15)

			' setup the floatbar series
			Dim floatbar As NFloatBarSeries = CType(chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			floatbar.MultiFloatBarMode = MultiFloatBarMode.Clustered
			floatbar.Name = "Floatbar series"
			floatbar.FillStyle = New NColorFillStyle(Color.SandyBrown)
			floatbar.DataLabelStyle.Visible = False

			floatbar.AddDataPoint(New NFloatBarDataPoint(3.1, 5.2))
			floatbar.AddDataPoint(New NFloatBarDataPoint(4.0, 6.1))
			floatbar.AddDataPoint(New NFloatBarDataPoint(2.0, 6.4))
			floatbar.AddDataPoint(New NFloatBarDataPoint(5.3, 7.3))
			floatbar.AddDataPoint(New NFloatBarDataPoint(3.8, 8.4))
			floatbar.AddDataPoint(New NFloatBarDataPoint(4.0, 7.7))
			floatbar.AddDataPoint(New NFloatBarDataPoint(2.9, 4.1))
			floatbar.AddDataPoint(New NFloatBarDataPoint(5.0, 7.2))
		End Sub

		Public Overrides Sub Initialize()
			InitChart()

			m_PrintDocument = New PrintDocument()
			AddHandler m_PrintDocument.PrintPage, AddressOf OnPrintPage
		End Sub

		Private Sub OnPrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
			Dim marginBounds As New RectangleF(ev.MarginBounds.Left, ev.MarginBounds.Top, ev.MarginBounds.Width, ev.MarginBounds.Height)

			' create header and footer
			Dim header As String = "Custom Header"
			Dim footer As String = "Custom Footer"

'INSTANT VB NOTE: The variable font was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim font_Renamed As New Font("Arial", 15)
			Dim brush As Brush = New SolidBrush(Color.Black)

			' measure them
			Dim headerSize As SizeF = ev.Graphics.MeasureString(header, font_Renamed)
			Dim footerSize As SizeF = ev.Graphics.MeasureString(footer, font_Renamed)

			' draw header
			Dim headerBounds As New RectangleF(marginBounds.Left, marginBounds.Top, marginBounds.Width, headerSize.Height)
			ev.Graphics.DrawString(header, font_Renamed, brush, headerBounds)

			' draw chart
			Dim chartBounds As New NRectangleF(marginBounds.Left, headerBounds.Bottom, marginBounds.Width, marginBounds.Height - headerSize.Height - footerSize.Height)
			Dim printView As New NChartPrintView(nChartControl1.PrintManager, nChartControl1.Document, ev.Graphics)
			printView.Print(chartBounds)
			printView.Dispose()

			' draw footer
			Dim footerBounds As New RectangleF(marginBounds.Left, marginBounds.Bottom - footerSize.Height, marginBounds.Width, footerSize.Height)
			ev.Graphics.DrawString(footer, font_Renamed, brush, footerBounds)

			' dispose objects
			font_Renamed.Dispose()
			brush.Dispose()
		End Sub

		Private Sub PageSetupButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageSetupButton.Click
			Try
				' show page setup dialog
				Dim pageSetupDialog As New PageSetupDialog()

				pageSetupDialog.PrinterSettings = m_PrintDocument.PrinterSettings
				pageSetupDialog.PageSettings = m_PrintDocument.DefaultPageSettings

				If pageSetupDialog.ShowDialog() = DialogResult.Cancel Then
					Return
				End If

				' save changes
				m_PrintDocument.PrinterSettings = pageSetupDialog.PrinterSettings
				m_PrintDocument.DefaultPageSettings = pageSetupDialog.PageSettings
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub PrinterSetupButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrinterSetupButton.Click
			' show page setup dialog
			Dim printDialog As New PrintDialog()
			printDialog.PrinterSettings = m_PrintDocument.PrinterSettings

			If printDialog.ShowDialog() = DialogResult.Cancel Then
				Return
			End If

			' save changes
			m_PrintDocument.PrinterSettings = printDialog.PrinterSettings
		End Sub

		Private Sub PrintPreviewButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintPreviewButton.Click
			Try
				Dim printPreviewDialog As New PrintPreviewDialog()

				printPreviewDialog.Document = m_PrintDocument

				printPreviewDialog.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub PrintButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintButton.Click
			m_PrintDocument.Print()
		End Sub
	End Class
End Namespace
