Imports Microsoft.VisualBasic
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
	Public Class NAlphaBlendingUC
		Inherits NExampleBaseUC
		Private m_Chart As NChart
		Private seriesId As Integer
		Private WithEvents seriesListBox As Nevron.UI.WinForm.Controls.NListBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents btnAddSeries As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents btnDeleteSeries As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents comboMultiBarMode As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents scrollTransparency As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents btnColor As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			Me.seriesListBox = New Nevron.UI.WinForm.Controls.NListBox()
			Me.btnAddSeries = New Nevron.UI.WinForm.Controls.NButton()
			Me.btnDeleteSeries = New Nevron.UI.WinForm.Controls.NButton()
			Me.comboMultiBarMode = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.scrollTransparency = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.btnColor = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' seriesListBox
			' 
			Me.seriesListBox.Location = New System.Drawing.Point(7, 8)
			Me.seriesListBox.Name = "seriesListBox"
			Me.seriesListBox.Size = New System.Drawing.Size(147, 173)
			Me.seriesListBox.TabIndex = 0
'			Me.seriesListBox.SelectedIndexChanged += New System.EventHandler(Me.seriesListBox_SelectedIndexChanged);
			' 
			' btnAddSeries
			' 
			Me.btnAddSeries.Location = New System.Drawing.Point(8, 193)
			Me.btnAddSeries.Name = "btnAddSeries"
			Me.btnAddSeries.Size = New System.Drawing.Size(99, 25)
			Me.btnAddSeries.TabIndex = 1
			Me.btnAddSeries.Text = "Add Bar Series"
'			Me.btnAddSeries.Click += New System.EventHandler(Me.btnAddSeries_Click);
			' 
			' btnDeleteSeries
			' 
			Me.btnDeleteSeries.Location = New System.Drawing.Point(8, 226)
			Me.btnDeleteSeries.Name = "btnDeleteSeries"
			Me.btnDeleteSeries.Size = New System.Drawing.Size(99, 23)
			Me.btnDeleteSeries.TabIndex = 2
			Me.btnDeleteSeries.Text = "Delete Series"
'			Me.btnDeleteSeries.Click += New System.EventHandler(Me.btnDeleteSeries_Click);
			' 
			' comboMultiBarMode
			' 
			Me.comboMultiBarMode.Location = New System.Drawing.Point(8, 44)
			Me.comboMultiBarMode.Name = "comboMultiBarMode"
			Me.comboMultiBarMode.Size = New System.Drawing.Size(132, 21)
			Me.comboMultiBarMode.TabIndex = 3
'			Me.comboMultiBarMode.SelectedIndexChanged += New System.EventHandler(Me.comboMultiBarMode_SelectedIndexChanged);
			' 
			' scrollTransparency
			' 
			Me.scrollTransparency.LargeChange = 1
			Me.scrollTransparency.Location = New System.Drawing.Point(8, 103)
			Me.scrollTransparency.Name = "scrollTransparency"
			Me.scrollTransparency.Size = New System.Drawing.Size(128, 16)
			Me.scrollTransparency.TabIndex = 4
'			Me.scrollTransparency.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.scrollTransparency_Scroll);
			' 
			' btnColor
			' 
			Me.btnColor.Location = New System.Drawing.Point(8, 134)
			Me.btnColor.Name = "btnColor"
			Me.btnColor.Size = New System.Drawing.Size(99, 23)
			Me.btnColor.TabIndex = 5
			Me.btnColor.Text = "Color"
'			Me.btnColor.Click += New System.EventHandler(Me.btnColor_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 22)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(93, 17)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Multi Bar Mode:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 82)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(103, 15)
			Me.label2.TabIndex = 7
			Me.label2.Text = "Transparency:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.btnColor)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.comboMultiBarMode)
			Me.groupBox1.Controls.Add(Me.scrollTransparency)
			Me.groupBox1.Location = New System.Drawing.Point(7, 264)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(147, 174)
			Me.groupBox1.TabIndex = 8
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Bar Properties"
			' 
			' AlphaBlendingUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.btnDeleteSeries)
			Me.Controls.Add(Me.btnAddSeries)
			Me.Controls.Add(Me.seriesListBox)
			Me.Name = "AlphaBlendingUC"
			Me.Size = New System.Drawing.Size(164, 454)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Alpha Blending / Transparency")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Depth = 30
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			AddSeries(MultiBarMode.Series, Color.Plum, 210)
			AddSeries(MultiBarMode.Clustered, Color.Red, 210)
			AddSeries(MultiBarMode.Series, Color.CornflowerBlue, 210)
			AddSeries(MultiBarMode.Stacked, Color.Gold, 210)

			comboMultiBarMode.Items.Add("Series")
			comboMultiBarMode.Items.Add("Clustered")
			comboMultiBarMode.Items.Add("Stacked")
			comboMultiBarMode.Items.Add("StackedPercent")

			Dim i As Integer = 0
			Do While i < m_Chart.Series.Count
				Dim series As NSeriesBase = CType(m_Chart.Series(i), NSeriesBase)
				seriesListBox.Items.Add(series.Name)
				i += 1
			Loop

			seriesListBox.SelectedIndex = 0
		End Sub

		Private Function AddSeries(ByVal mode As MultiBarMode, ByVal color As Color, ByVal alpha As Integer) As NBarSeries
			seriesId += 1

			Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar " & seriesId.ToString()
			bar.DataLabelStyle.Visible = False
			bar.Legend.Mode = SeriesLegendMode.Series
			bar.FillStyle = New NColorFillStyle(Color.FromArgb(alpha, color))
			bar.BorderStyle.Width = New NLength(0)
			bar.Values.FillRandom(Random, 7)
			bar.MultiBarMode = mode

			Return bar
		End Function

		Private Function GetSelectedSeries() As NBarSeries
			Dim selectedIndex As Integer = seriesListBox.SelectedIndex

			If (selectedIndex < 0) OrElse (selectedIndex >= m_Chart.Series.Count) Then
				Return Nothing
			End If

			Return CType(m_Chart.Series(selectedIndex), NBarSeries)
		End Function

		Private Sub btnAddSeries_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSeries.Click
			Dim bar As NBarSeries = AddSeries(MultiBarMode.Series, RandomColor(), 210)

			seriesListBox.Items.Add(bar.Name)

			seriesListBox.SelectedIndex = seriesListBox.Items.Count - 1

			nChartControl1.Refresh()
		End Sub

		Private Sub btnDeleteSeries_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteSeries.Click
			Dim selectedIndex As Integer = seriesListBox.SelectedIndex

			If selectedIndex < 0 Then
				Return
			End If

			m_Chart.Series.RemoveAt(selectedIndex)
			nChartControl1.Refresh()

			' delete the selected list box item
			seriesListBox.Items.RemoveAt(selectedIndex)

			' select another item in the list box
			Dim nNewSelectedIndex As Integer = selectedIndex

			If nNewSelectedIndex = seriesListBox.Items.Count Then
				nNewSelectedIndex -= 1
			End If

			If nNewSelectedIndex >= 0 Then
				seriesListBox.SelectedIndex = nNewSelectedIndex
			End If
		End Sub

		Private Sub comboMultiBarMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboMultiBarMode.SelectedIndexChanged
			Dim bar As NBarSeries = GetSelectedSeries()

			If Not bar Is Nothing Then
				bar.MultiBarMode = CType(comboMultiBarMode.SelectedIndex, MultiBarMode)
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub scrollTransparency_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles scrollTransparency.ValueChanged
			Dim bar As NBarSeries = GetSelectedSeries()

			If Not bar Is Nothing Then
				bar.FillStyle.SetTransparencyPercent(scrollTransparency.Value)
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub btnColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnColor.Click
			Dim bar As NBarSeries = GetSelectedSeries()

			Dim colorDialog As ColorDialog = New ColorDialog()

			' get the current color of the bar series
			colorDialog.Color = bar.FillStyle.GetPrimaryColor().ToColor()
			Dim alpha As Integer = colorDialog.Color.A

			If colorDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				' set new color for the bar series, keep the transparency
				Dim newColor As Color = Color.FromArgb(alpha, colorDialog.Color)
				bar.FillStyle = New NColorFillStyle(newColor)

				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub seriesListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles seriesListBox.SelectedIndexChanged
			Dim selectedIndex As Integer = seriesListBox.SelectedIndex

			If selectedIndex < 0 Then
				groupBox1.Enabled = False
			Else
				groupBox1.Enabled = True
			End If

			Dim bar As NBarSeries = GetSelectedSeries()

			If Not bar Is Nothing Then
				comboMultiBarMode.SelectedIndex = CInt(Fix(bar.MultiBarMode))

				Dim nCurrentAlpha As Integer = bar.FillStyle.GetPrimaryColor().ToColor().A

				scrollTransparency.Value = 100 - CInt(Fix(100 * (nCurrentAlpha / 255.0)))
			End If
		End Sub

	End Class
End Namespace
