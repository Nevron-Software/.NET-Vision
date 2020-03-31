Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPrintingUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_FloatBar As NFloatBarSeries
		Private m_PrintManager As NPrintManager

		Private WithEvents PageSetupButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrinterSetupButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrintPreviewButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrintButton As Nevron.UI.WinForm.Controls.NButton

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
			Me.PageSetupButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrinterSetupButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrintPreviewButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrintButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' PageSetupButton
			' 
			Me.PageSetupButton.Location = New System.Drawing.Point(5, 16)
			Me.PageSetupButton.Name = "PageSetupButton"
			Me.PageSetupButton.Size = New System.Drawing.Size(169, 23)
			Me.PageSetupButton.TabIndex = 0
			Me.PageSetupButton.Text = "Page setup..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PageSetupButton.Click += new System.EventHandler(this.PageSetupButton_Click);
			' 
			' PrinterSetupButton
			' 
			Me.PrinterSetupButton.Location = New System.Drawing.Point(5, 48)
			Me.PrinterSetupButton.Name = "PrinterSetupButton"
			Me.PrinterSetupButton.Size = New System.Drawing.Size(169, 23)
			Me.PrinterSetupButton.TabIndex = 1
			Me.PrinterSetupButton.Text = "Printer setup..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrinterSetupButton.Click += new System.EventHandler(this.PrinterSetupButton_Click);
			' 
			' PrintPreviewButton
			' 
			Me.PrintPreviewButton.Location = New System.Drawing.Point(5, 88)
			Me.PrintPreviewButton.Name = "PrintPreviewButton"
			Me.PrintPreviewButton.Size = New System.Drawing.Size(169, 23)
			Me.PrintPreviewButton.TabIndex = 2
			Me.PrintPreviewButton.Text = "Print Preview..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			' 
			' PrintButton
			' 
			Me.PrintButton.Location = New System.Drawing.Point(5, 120)
			Me.PrintButton.Name = "PrintButton"
			Me.PrintButton.Size = New System.Drawing.Size(169, 23)
			Me.PrintButton.TabIndex = 3
			Me.PrintButton.Text = "Print"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			' 
			' NPrintingUC
			' 
			Me.Controls.Add(Me.PrintButton)
			Me.Controls.Add(Me.PrintPreviewButton)
			Me.Controls.Add(Me.PrinterSetupButton)
			Me.Controls.Add(Me.PageSetupButton)
			Me.Name = "NPrintingUC"
			Me.Size = New System.Drawing.Size(180, 456)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub InitChart()
			m_Chart = nChartControl1.Charts(0)

			nChartControl1.Controller.Selection.Add(m_Chart)
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Printing")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart.Width = 90
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			Dim linearScale As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale
			dateTimeScale.LabelValueFormatter = New NDateTimeValueFormatter(DateTimeValueFormat.Date)
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2

			' create the float bar series
			m_FloatBar = CType(m_Chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			m_FloatBar.UseXValues = True
			m_FloatBar.UseZValues = False
			m_FloatBar.InflateMargins = True
			m_FloatBar.DataLabelStyle.Visible = False

			' bar appearance
			m_FloatBar.BorderStyle.Color = Color.Bisque
			m_FloatBar.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightGray, Color.DarkBlue)
			m_FloatBar.ShadowStyle.Type = ShadowType.Solid
			m_FloatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0)

			m_FloatBar.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_FloatBar.EndValues.ValueFormatter = New NNumericValueFormatter("0.00")

			' show the begin end values in the legend
			m_FloatBar.Legend.Format = "<begin> - <end>"
			m_FloatBar.Legend.Mode = SeriesLegendMode.DataPoints

			m_PrintManager = New NPrintManager(nChartControl1.Document)

			GenerateData()
		End Sub

		Private Sub GenerateData()
			Const nCount As Integer = 6

			m_FloatBar.Values.Clear()
			m_FloatBar.EndValues.Clear()
			m_FloatBar.XValues.Clear()

			' generate Y values
			For i As Integer = 0 To nCount - 1
				Dim dBeginValue As Double = Random.NextDouble() * 5
				Dim dEndValue As Double = dBeginValue + 2 + Random.NextDouble()
				m_FloatBar.Values.Add(dBeginValue)
				m_FloatBar.EndValues.Add(dEndValue)
			Next i

			' generate X values
			Dim dt As New Date(2005, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddHours(12 + Random.NextDouble() * 60)

				m_FloatBar.XValues.Add(dt)
			Next i
		End Sub

		Public Overrides Sub Initialize()
			InitChart()
		End Sub

		Private Sub PageSetupButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageSetupButton.Click
			Try
				m_PrintManager.ShowPageSetupDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		Private Sub PrinterSetupButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrinterSetupButton.Click
			m_PrintManager.ShowPrintDialog()
		End Sub

		Private Sub PrintPreviewButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintPreviewButton.Click
			m_PrintManager.ShowPrintPreview()
		End Sub

		Private Sub PrintButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintButton.Click
			m_PrintManager.Print()
		End Sub
	End Class
End Namespace
