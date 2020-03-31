Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NPageSettingsUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_FloatBar As NFloatBarSeries
		Private m_PrintManager As NPrintManager
		Private m_Updating As Boolean
		Private PageOrientationGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents PortraitRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private WithEvents LandscapeRadioButton As Nevron.UI.WinForm.Controls.NRadioButton
		Private PageMarginsGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents PageMarginsEditorUC As Nevron.Editors.NMarginsEditorUC
		Private PaperGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents PagePaperSizeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PagePaperSourceComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PrintButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrintPreviewButton As Nevron.UI.WinForm.Controls.NButton

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			m_Updating = True
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
			Me.PageOrientationGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LandscapeRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.PortraitRadioButton = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.PageMarginsGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.PageMarginsEditorUC = New Nevron.Editors.NMarginsEditorUC()
			Me.PaperGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.PagePaperSourceComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.PagePaperSizeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.PrintPreviewButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrintButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PageOrientationGroupBox.SuspendLayout()
			Me.PageMarginsGroupBox.SuspendLayout()
			Me.PaperGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' PageOrientationGroupBox
			' 
			Me.PageOrientationGroupBox.Controls.Add(Me.LandscapeRadioButton)
			Me.PageOrientationGroupBox.Controls.Add(Me.PortraitRadioButton)
			Me.PageOrientationGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.PageOrientationGroupBox.ImageIndex = 0
			Me.PageOrientationGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.PageOrientationGroupBox.Name = "PageOrientationGroupBox"
			Me.PageOrientationGroupBox.Size = New System.Drawing.Size(272, 72)
			Me.PageOrientationGroupBox.TabIndex = 0
			Me.PageOrientationGroupBox.TabStop = False
			Me.PageOrientationGroupBox.Text = "Page Orientation"
			' 
			' LandscapeRadioButton
			' 
			Me.LandscapeRadioButton.Location = New System.Drawing.Point(8, 40)
			Me.LandscapeRadioButton.Name = "LandscapeRadioButton"
			Me.LandscapeRadioButton.TabIndex = 1
			Me.LandscapeRadioButton.Text = "Landscape"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LandscapeRadioButton.CheckedChanged += new System.EventHandler(this.LandscapeRadioButton_CheckedChanged);
			' 
			' PortraitRadioButton
			' 
			Me.PortraitRadioButton.Location = New System.Drawing.Point(8, 16)
			Me.PortraitRadioButton.Name = "PortraitRadioButton"
			Me.PortraitRadioButton.TabIndex = 0
			Me.PortraitRadioButton.Text = "Portrait"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PortraitRadioButton.CheckedChanged += new System.EventHandler(this.PortraitRadioButton_CheckedChanged);
			' 
			' PageMarginsGroupBox
			' 
			Me.PageMarginsGroupBox.Controls.Add(Me.PageMarginsEditorUC)
			Me.PageMarginsGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.PageMarginsGroupBox.ImageIndex = 0
			Me.PageMarginsGroupBox.Location = New System.Drawing.Point(0, 72)
			Me.PageMarginsGroupBox.Name = "PageMarginsGroupBox"
			Me.PageMarginsGroupBox.Size = New System.Drawing.Size(272, 128)
			Me.PageMarginsGroupBox.TabIndex = 1
			Me.PageMarginsGroupBox.TabStop = False
			Me.PageMarginsGroupBox.Text = "Page Margins"
			' 
			' PageMarginsEditorUC
			' 
			Me.PageMarginsEditorUC.BackColor = System.Drawing.SystemColors.Control
			Me.PageMarginsEditorUC.ForeColor = System.Drawing.SystemColors.ControlText
			Me.PageMarginsEditorUC.Location = New System.Drawing.Point(8, 24)
			Me.PageMarginsEditorUC.Name = "PageMarginsEditorUC"
			Me.PageMarginsEditorUC.Size = New System.Drawing.Size(256, 96)
			Me.PageMarginsEditorUC.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PageMarginsEditorUC.MarginsChanged += new System.EventHandler(this.PageMarginsEditorUC_MarginsChanged);
			' 
			' PaperGroupBox
			' 
			Me.PaperGroupBox.Controls.Add(Me.PagePaperSourceComboBox)
			Me.PaperGroupBox.Controls.Add(Me.PagePaperSizeComboBox)
			Me.PaperGroupBox.Controls.Add(Me.label2)
			Me.PaperGroupBox.Controls.Add(Me.label1)
			Me.PaperGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.PaperGroupBox.ImageIndex = 0
			Me.PaperGroupBox.Location = New System.Drawing.Point(0, 200)
			Me.PaperGroupBox.Name = "PaperGroupBox"
			Me.PaperGroupBox.Size = New System.Drawing.Size(272, 80)
			Me.PaperGroupBox.TabIndex = 2
			Me.PaperGroupBox.TabStop = False
			Me.PaperGroupBox.Text = "Page Paper"
			' 
			' PagePaperSourceComboBox
			' 
			Me.PagePaperSourceComboBox.Location = New System.Drawing.Point(64, 48)
			Me.PagePaperSourceComboBox.Name = "PagePaperSourceComboBox"
			Me.PagePaperSourceComboBox.Size = New System.Drawing.Size(192, 21)
			Me.PagePaperSourceComboBox.TabIndex = 3
			Me.PagePaperSourceComboBox.Text = "comboBox2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PagePaperSourceComboBox.SelectedIndexChanged += new System.EventHandler(this.PagePaperSourceComboBox_SelectedIndexChanged);
			' 
			' PagePaperSizeComboBox
			' 
			Me.PagePaperSizeComboBox.Location = New System.Drawing.Point(64, 16)
			Me.PagePaperSizeComboBox.Name = "PagePaperSizeComboBox"
			Me.PagePaperSizeComboBox.Size = New System.Drawing.Size(192, 21)
			Me.PagePaperSizeComboBox.TabIndex = 2
			Me.PagePaperSizeComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PagePaperSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.PagePaperSizeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 46)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(48, 16)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Source:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 21)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(48, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Size:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' PrintPreviewButton
			' 
			Me.PrintPreviewButton.Location = New System.Drawing.Point(8, 304)
			Me.PrintPreviewButton.Name = "PrintPreviewButton"
			Me.PrintPreviewButton.Size = New System.Drawing.Size(256, 23)
			Me.PrintPreviewButton.TabIndex = 3
			Me.PrintPreviewButton.Text = "Print Preview..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			' 
			' PrintButton
			' 
			Me.PrintButton.Location = New System.Drawing.Point(8, 336)
			Me.PrintButton.Name = "PrintButton"
			Me.PrintButton.Size = New System.Drawing.Size(256, 23)
			Me.PrintButton.TabIndex = 4
			Me.PrintButton.Text = "Print"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			' 
			' NPageSettingsUC
			' 
			Me.Controls.Add(Me.PrintButton)
			Me.Controls.Add(Me.PrintPreviewButton)
			Me.Controls.Add(Me.PaperGroupBox)
			Me.Controls.Add(Me.PageMarginsGroupBox)
			Me.Controls.Add(Me.PageOrientationGroupBox)
			Me.Name = "NPageSettingsUC"
			Me.Size = New System.Drawing.Size(272, 384)
			Me.PageOrientationGroupBox.ResumeLayout(False)
			Me.PageMarginsGroupBox.ResumeLayout(False)
			Me.PaperGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub InitChart()
			m_Chart = nChartControl1.Charts(0)

			nChartControl1.Controller.Selection.Add(m_Chart)
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Page Settings")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart.Width = 90
			m_Chart.BoundsMode = BoundsMode.Fit
			m_Chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			' switch the X axis to date time scale
			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			dateTimeScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale

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

			nChartControl1.Controller.Tools.Add(New NDataPanTool())
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
			UpdateControlsFromPageSettings()
		End Sub

		Private Sub UpdateControlsFromPageSettings()
			If PrinterSettings.InstalledPrinters.Count = 0 Then
				PortraitRadioButton.Enabled = False
				LandscapeRadioButton.Enabled = False
				PageMarginsEditorUC.Enabled = False
				PagePaperSizeComboBox.Enabled = False

				Return
			End If

			m_Updating = True
			Dim pageSettings As PageSettings = m_PrintManager.PageSettings

			' portrait / landscape
			If pageSettings.Landscape Then
				PortraitRadioButton.Checked = False
				LandscapeRadioButton.Checked = True
			Else
				PortraitRadioButton.Checked = True
				LandscapeRadioButton.Checked = False
			End If

			' margins
			Dim margins As New NMarginsL(New NLength(pageSettings.Margins.Left / 100.0F, NGraphicsUnit.Inch), New NLength(pageSettings.Margins.Top / 100.0F, NGraphicsUnit.Inch), New NLength(pageSettings.Margins.Right / 100.0F, NGraphicsUnit.Inch), New NLength(pageSettings.Margins.Bottom / 100.0F, NGraphicsUnit.Inch))

			Me.PageMarginsEditorUC.Margins = margins

			' paper sizes
			For i As Integer = 0 To pageSettings.PrinterSettings.PaperSizes.Count - 1
				Dim paperName As String = pageSettings.PrinterSettings.PaperSizes(i).PaperName
				PagePaperSizeComboBox.Items.Add(paperName)

				If paperName = pageSettings.PaperSize.PaperName Then
					PagePaperSizeComboBox.SelectedIndex = i
				End If
			Next i

			' paper sources
			For i As Integer = 0 To pageSettings.PrinterSettings.PaperSources.Count - 1
				Dim paperSourceName As String = pageSettings.PrinterSettings.PaperSources(i).SourceName
				PagePaperSourceComboBox.Items.Add(paperSourceName)

				If paperSourceName = pageSettings.PaperSource.SourceName Then
					PagePaperSourceComboBox.SelectedIndex = i
				End If
			Next i

			PagePaperSizeComboBox.SelectedItem = pageSettings.PaperSource

			m_Updating = False
		End Sub

		Private Sub UpdatePageSettingsFromControls()
			If m_Updating Then
				Return
			End If

			If PrinterSettings.InstalledPrinters.Count = 0 Then
				Return
			End If

			m_Updating = True

			Dim pageSettings As PageSettings = m_PrintManager.PageSettings

			' portrait / landscape
			pageSettings.Landscape = LandscapeRadioButton.Checked

			' margins
			Dim margins As NMarginsL = Me.PageMarginsEditorUC.Margins

			Dim converter As New NMeasurementUnitConverter(pageSettings.PrinterResolution.X, pageSettings.PrinterResolution.Y)

'INSTANT VB NOTE: The variable left was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim left_Renamed As Single = converter.ConvertX(margins.Left.MeasurementUnit, NGraphicsUnit.Inch, margins.Left.Value) * 100
'INSTANT VB NOTE: The variable top was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim top_Renamed As Single = converter.ConvertY(margins.Top.MeasurementUnit, NGraphicsUnit.Inch, margins.Top.Value) * 100
'INSTANT VB NOTE: The variable right was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim right_Renamed As Single = converter.ConvertX(margins.Right.MeasurementUnit, NGraphicsUnit.Inch, margins.Right.Value) * 100
'INSTANT VB NOTE: The variable bottom was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim bottom_Renamed As Single = converter.ConvertY(margins.Bottom.MeasurementUnit, NGraphicsUnit.Inch, margins.Bottom.Value) * 100

			pageSettings.Margins = New Margins(CInt(Math.Truncate(left_Renamed)), CInt(Math.Truncate(right_Renamed)), CInt(Math.Truncate(top_Renamed)), CInt(Math.Truncate(bottom_Renamed)))

			' paper sizes
			If PagePaperSizeComboBox.SelectedIndex <> -1 Then
				Dim paperName As String = PagePaperSizeComboBox.SelectedItem.ToString()

				For i As Integer = 0 To pageSettings.PrinterSettings.PaperSizes.Count - 1
					If pageSettings.PrinterSettings.PaperSizes(i).PaperName = paperName Then
						pageSettings.PaperSize = pageSettings.PrinterSettings.PaperSizes(i)
						Exit For
					End If
				Next i
			End If

			' paper source
			If PagePaperSourceComboBox.SelectedIndex <> -1 Then
				Dim paperSourceName As String = PagePaperSourceComboBox.SelectedItem.ToString()

				For i As Integer = 0 To pageSettings.PrinterSettings.PaperSources.Count - 1
					If paperSourceName = pageSettings.PrinterSettings.PaperSources(i).SourceName Then
						pageSettings.PaperSource = pageSettings.PrinterSettings.PaperSources(i)
						Exit For
					End If
				Next i
			End If

			nChartControl1.PrintManager.PageSettings = pageSettings

			m_Updating = False
		End Sub

		Private Sub PortraitRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PortraitRadioButton.CheckedChanged
			UpdatePageSettingsFromControls()
		End Sub

		Private Sub LandscapeRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LandscapeRadioButton.CheckedChanged
			UpdatePageSettingsFromControls()
		End Sub

		Private Sub PageMarginsEditorUC_MarginsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageMarginsEditorUC.MarginsChanged
			UpdatePageSettingsFromControls()
		End Sub

		Private Sub PagePaperSourceComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagePaperSourceComboBox.SelectedIndexChanged
			UpdatePageSettingsFromControls()
		End Sub

		Private Sub PagePaperSizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagePaperSizeComboBox.SelectedIndexChanged
			UpdatePageSettingsFromControls()
		End Sub

		Private Sub PrintPreviewButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintPreviewButton.Click
			m_PrintManager.ShowPrintPreview()
		End Sub

		Private Sub PrintButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintButton.Click
			m_PrintManager.Print()
		End Sub
	End Class
End Namespace
