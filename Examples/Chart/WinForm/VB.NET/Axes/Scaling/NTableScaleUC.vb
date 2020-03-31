Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports Nevron.Chart
Imports Nevron.GraphicsCore
Imports System.Diagnostics


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NTableScaleUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_TableScale As NTableScaleConfigurator
		Private WithEvents ShowRowInterlacingCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowColumnInterlacingCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents ShowRowHeadersCheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents LabelFormatComboBox As UI.WinForm.Controls.NComboBox
		Private label12 As System.Windows.Forms.Label
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
			Me.ShowRowInterlacingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowColumnInterlacingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowRowHeadersCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.LabelFormatComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label12 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' ShowRowInterlacingCheckBox
			' 
			Me.ShowRowInterlacingCheckBox.AutoSize = True
			Me.ShowRowInterlacingCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowRowInterlacingCheckBox.Location = New System.Drawing.Point(8, 8)
			Me.ShowRowInterlacingCheckBox.Name = "ShowRowInterlacingCheckBox"
			Me.ShowRowInterlacingCheckBox.Size = New System.Drawing.Size(130, 17)
			Me.ShowRowInterlacingCheckBox.TabIndex = 14
			Me.ShowRowInterlacingCheckBox.Text = "Show Row Interlacing"
			Me.ShowRowInterlacingCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowRowInterlacingCheckBox.CheckedChanged += new System.EventHandler(this.ShowRowInterlacingCheckBox_CheckedChanged);
			' 
			' ShowColumnInterlacingCheckBox
			' 
			Me.ShowColumnInterlacingCheckBox.AutoSize = True
			Me.ShowColumnInterlacingCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowColumnInterlacingCheckBox.Location = New System.Drawing.Point(8, 33)
			Me.ShowColumnInterlacingCheckBox.Name = "ShowColumnInterlacingCheckBox"
			Me.ShowColumnInterlacingCheckBox.Size = New System.Drawing.Size(143, 17)
			Me.ShowColumnInterlacingCheckBox.TabIndex = 15
			Me.ShowColumnInterlacingCheckBox.Text = "Show Column Interlacing"
			Me.ShowColumnInterlacingCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowColumnInterlacingCheckBox.CheckedChanged += new System.EventHandler(this.ShowColumnInterlacingCheckBox_CheckedChanged);
			' 
			' ShowRowHeadersCheckBox
			' 
			Me.ShowRowHeadersCheckBox.AutoSize = True
			Me.ShowRowHeadersCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowRowHeadersCheckBox.Location = New System.Drawing.Point(8, 58)
			Me.ShowRowHeadersCheckBox.Name = "ShowRowHeadersCheckBox"
			Me.ShowRowHeadersCheckBox.Size = New System.Drawing.Size(121, 17)
			Me.ShowRowHeadersCheckBox.TabIndex = 16
			Me.ShowRowHeadersCheckBox.Text = "Show Row Headers"
			Me.ShowRowHeadersCheckBox.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowRowHeadersCheckBox.CheckedChanged += new System.EventHandler(this.ShowRowHeadersCheckBox_CheckedChanged);
			' 
			' LabelFormatComboBox
			' 
			Me.LabelFormatComboBox.ListProperties.CheckBoxDataMember = ""
			Me.LabelFormatComboBox.ListProperties.DataSource = Nothing
			Me.LabelFormatComboBox.ListProperties.DisplayMember = ""
			Me.LabelFormatComboBox.Location = New System.Drawing.Point(8, 105)
			Me.LabelFormatComboBox.Name = "LabelFormatComboBox"
			Me.LabelFormatComboBox.Size = New System.Drawing.Size(143, 21)
			Me.LabelFormatComboBox.TabIndex = 18
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LabelFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.LabelFormatComboBox_SelectedIndexChanged);
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(8, 89)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(71, 13)
			Me.label12.TabIndex = 17
			Me.label12.Text = "Label Format:"
			' 
			' NTableScaleUC
			' 
			Me.Controls.Add(Me.LabelFormatComboBox)
			Me.Controls.Add(Me.label12)
			Me.Controls.Add(Me.ShowRowHeadersCheckBox)
			Me.Controls.Add(Me.ShowColumnInterlacingCheckBox)
			Me.Controls.Add(Me.ShowRowInterlacingCheckBox)
			Me.Name = "NTableScaleUC"
			Me.Size = New System.Drawing.Size(162, 304)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Table Scale")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.BoundsMode = BoundsMode.Stretch

			m_Chart.Location = New NPointL(New NLength(10, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(80, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))

			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' configure the y axis
			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)

			' add a strip line style
			Dim stripStyle As New NScaleStripStyle()
			stripStyle.FillStyle = New NColorFillStyle(Color.Beige)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			linearScale.StripStyles.Add(stripStyle)

'INSTANT VB NOTE: The variable random was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim random_Renamed As New Random()

			' create two series with random data
			Dim alcoholSales As New NBarSeries()
			alcoholSales.Name = "Alcohol"
			alcoholSales.MultiBarMode = MultiBarMode.Stacked
			alcoholSales.Values.FillRandom(random_Renamed, 12)
			alcoholSales.DataLabelStyle.Visible = False
			m_Chart.Series.Add(alcoholSales)

			Dim beveragesSales As New NBarSeries()
			beveragesSales.Name = "Beverages"
			beveragesSales.MultiBarMode = MultiBarMode.Stacked
			beveragesSales.Values.FillRandom(random_Renamed, 12)
			beveragesSales.DataLabelStyle.Visible = False
			m_Chart.Series.Add(beveragesSales)

			' create a table scale
			m_TableScale = New NTableScaleConfigurator()

			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = m_TableScale

			Dim customRow As New NCustomTableScaleRow()
			customRow.Items = New Object() { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
			m_TableScale.Rows.Add(customRow)

			For i As Integer = 0 To m_Chart.Series.Count - 1
				Dim row As New NSeriesTableScaleRow()

				row.Series = m_Chart.Series(i)
				m_TableScale.Rows.Add(row)
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' init form controls
			LabelFormatComboBox.Items.Add("<value>")
			LabelFormatComboBox.Items.Add("<percent>")
			LabelFormatComboBox.SelectedIndex = 0

			ShowRowHeadersCheckBox.Checked = True
			ShowColumnInterlacingCheckBox.Checked = True
			ShowRowInterlacingCheckBox.Checked = True
		End Sub

		Private Sub ShowRowInterlacingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowRowInterlacingCheckBox.CheckedChanged
			' row interlacing
			If ShowRowInterlacingCheckBox.Checked Then
				Dim interlaceStyle As New NTableInterlaceStyle()

				interlaceStyle.Type = TableInterlaceStyleType.Row
				interlaceStyle.Length = 1
				interlaceStyle.Interval = 1
				interlaceStyle.FillStyle = New NColorFillStyle(Color.FromArgb(124, Color.Beige))

				m_TableScale.InterlaceStyles.Add(interlaceStyle)
			Else
				For Each interlaceStyle As NTableInterlaceStyle In m_TableScale.InterlaceStyles
					If interlaceStyle.Type = TableInterlaceStyleType.Row Then
						m_TableScale.InterlaceStyles.Remove(interlaceStyle)
						Exit For
					End If
				Next interlaceStyle
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowColumnInterlacingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowColumnInterlacingCheckBox.CheckedChanged
			' col interlacing
			If ShowColumnInterlacingCheckBox.Checked Then
				Dim interlaceStyle As New NTableInterlaceStyle()

				interlaceStyle.Type = TableInterlaceStyleType.Col
				interlaceStyle.Length = 1
				interlaceStyle.Interval = 1
				interlaceStyle.FillStyle = New NColorFillStyle(Color.FromArgb(124, Color.Red))

				m_TableScale.InterlaceStyles.Add(interlaceStyle)
			Else
				For Each interlaceStyle As NTableInterlaceStyle In m_TableScale.InterlaceStyles
					If interlaceStyle.Type = TableInterlaceStyleType.Col Then
						m_TableScale.InterlaceStyles.Remove(interlaceStyle)
						Exit For
					End If
				Next interlaceStyle
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub ShowRowHeadersCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowRowHeadersCheckBox.CheckedChanged
			For Each row As NTableScaleRow In m_TableScale.Rows
				Dim seriesRow As NSeriesTableScaleRow = TryCast(row, NSeriesTableScaleRow)

				If seriesRow IsNot Nothing Then
					seriesRow.ShowLeftRowHeader = ShowRowHeadersCheckBox.Checked
				End If
			Next row

			nChartControl1.Refresh()
		End Sub

		Private Sub LabelFormatComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LabelFormatComboBox.SelectedIndexChanged
			Select Case LabelFormatComboBox.SelectedIndex
				Case 0 ' value
					For Each series As NSeriesBase In m_Chart.Series
						series.Legend.Format = "<value>"
					Next series
				Case 1 ' percent
					For Each series As NSeriesBase In m_Chart.Series
						series.Legend.Format = "<percent>"
					Next series
				Case Else
					Debug.Assert(False)
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
