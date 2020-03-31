Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLegendPositionUC
		Inherits NExampleBaseUC

		Private TransparencyLabel As System.Windows.Forms.Label
		Private WithEvents TransparencyScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents HasShadowCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents ShowLegendGridCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private ContentAlignmentLabel As System.Windows.Forms.Label
		Private WithEvents UseAutomaticSizeCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents ContentAlignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private LocationEditorUC As Nevron.Editors.NPointEditorUC
		Private SizeEditorUC As Nevron.Editors.NSizeLEditorUC
		Private m_Legend As NLegend

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
			Me.ContentAlignmentLabel = New System.Windows.Forms.Label()
			Me.TransparencyLabel = New System.Windows.Forms.Label()
			Me.TransparencyScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.HasShadowCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowLegendGridCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.UseAutomaticSizeCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LocationEditorUC = New Nevron.Editors.NPointEditorUC()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.SizeEditorUC = New Nevron.Editors.NSizeLEditorUC()
			Me.ContentAlignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' ContentAlignmentLabel
			' 
			Me.ContentAlignmentLabel.Location = New System.Drawing.Point(8, 162)
			Me.ContentAlignmentLabel.Name = "ContentAlignmentLabel"
			Me.ContentAlignmentLabel.Size = New System.Drawing.Size(266, 22)
			Me.ContentAlignmentLabel.TabIndex = 3
			Me.ContentAlignmentLabel.Text = "ContentAlignment:"
			Me.ContentAlignmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' TransparencyLabel
			' 
			Me.TransparencyLabel.Location = New System.Drawing.Point(8, 266)
			Me.TransparencyLabel.Name = "TransparencyLabel"
			Me.TransparencyLabel.Size = New System.Drawing.Size(266, 16)
			Me.TransparencyLabel.TabIndex = 7
			Me.TransparencyLabel.Text = "Transparency:"
			Me.TransparencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' TransparencyScrollBar
			' 
			Me.TransparencyScrollBar.Location = New System.Drawing.Point(8, 288)
			Me.TransparencyScrollBar.Maximum = 110
			Me.TransparencyScrollBar.Name = "TransparencyScrollBar"
			Me.TransparencyScrollBar.Size = New System.Drawing.Size(266, 16)
			Me.TransparencyScrollBar.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.TransparencyScrollBar.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.TransparencyScrollBar_ValueChanged);
			' 
			' HasShadowCheckBox
			' 
			Me.HasShadowCheckBox.Location = New System.Drawing.Point(8, 210)
			Me.HasShadowCheckBox.Name = "HasShadowCheckBox"
			Me.HasShadowCheckBox.Size = New System.Drawing.Size(266, 25)
			Me.HasShadowCheckBox.TabIndex = 5
			Me.HasShadowCheckBox.Text = "Has shadow"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HasShadowCheckBox.CheckedChanged += new System.EventHandler(this.HasShadowCheckBox_CheckedChanged);
			' 
			' ShowLegendGridCheckBox
			' 
			Me.ShowLegendGridCheckBox.Location = New System.Drawing.Point(8, 236)
			Me.ShowLegendGridCheckBox.Name = "ShowLegendGridCheckBox"
			Me.ShowLegendGridCheckBox.Size = New System.Drawing.Size(266, 25)
			Me.ShowLegendGridCheckBox.TabIndex = 6
			Me.ShowLegendGridCheckBox.Text = "Show legend grid"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowLegendGridCheckBox.CheckedChanged += new System.EventHandler(this.ShowLegendGridCheckBox_CheckedChanged);
			' 
			' UseAutomaticSizeCheckBox
			' 
			Me.UseAutomaticSizeCheckBox.Location = New System.Drawing.Point(8, 69)
			Me.UseAutomaticSizeCheckBox.Name = "UseAutomaticSizeCheckBox"
			Me.UseAutomaticSizeCheckBox.Size = New System.Drawing.Size(266, 24)
			Me.UseAutomaticSizeCheckBox.TabIndex = 1
			Me.UseAutomaticSizeCheckBox.Text = "Use automatic size"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UseAutomaticSizeCheckBox.CheckedChanged += new System.EventHandler(this.UseAutomaticSizeCheckBox_CheckedChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LocationEditorUC)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(8, 0)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(266, 68)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Location"
			' 
			' LocationEditorUC
			' 
			Me.LocationEditorUC.Location = New System.Drawing.Point(7, 16)
			Me.LocationEditorUC.Name = "LocationEditorUC"
			Me.LocationEditorUC.Size = New System.Drawing.Size(252, 45)
			Me.LocationEditorUC.TabIndex = 0
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.SizeEditorUC)
			Me.groupBox2.ImageIndex = 0
			Me.groupBox2.Location = New System.Drawing.Point(8, 93)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(266, 68)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Size"
			' 
			' SizeEditorUC
			' 
			Me.SizeEditorUC.Location = New System.Drawing.Point(7, 16)
			Me.SizeEditorUC.Name = "SizeEditorUC"
			Me.SizeEditorUC.Size = New System.Drawing.Size(252, 45)
			Me.SizeEditorUC.TabIndex = 0
			' 
			' ContentAlignmentComboBox
			' 
			Me.ContentAlignmentComboBox.Location = New System.Drawing.Point(8, 184)
			Me.ContentAlignmentComboBox.Name = "ContentAlignmentComboBox"
			Me.ContentAlignmentComboBox.Size = New System.Drawing.Size(266, 21)
			Me.ContentAlignmentComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ContentAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.ContentAlignmentComboBox_SelectedIndexChanged);
			' 
			' NLegendPositioningUC
			' 
			Me.Controls.Add(Me.ShowLegendGridCheckBox)
			Me.Controls.Add(Me.HasShadowCheckBox)
			Me.Controls.Add(Me.TransparencyScrollBar)
			Me.Controls.Add(Me.TransparencyLabel)
			Me.Controls.Add(Me.ContentAlignmentComboBox)
			Me.Controls.Add(Me.ContentAlignmentLabel)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.UseAutomaticSizeCheckBox)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NLegendPositioningUC"
			Me.Size = New System.Drawing.Size(280, 578)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			InitChartAndLegend()

			' init form controls
			LocationEditorUC.Point = m_Legend.Location

			UseAutomaticSizeCheckBox.Checked = m_Legend.UseAutomaticSize
			SizeEditorUC.SizeL = m_Legend.Size

			Dim names() As String = System.Enum.GetNames(GetType(ContentAlignment))
			For i As Integer = 0 To names.Length - 1
				ContentAlignmentComboBox.Items.Add(names(i))
			Next i

			ContentAlignmentComboBox.SelectedItem = m_Legend.ContentAlignment.ToString()
			HasShadowCheckBox.Checked = (m_Legend.ShadowStyle.Type <> ShadowType.None)
			TransparencyScrollBar.Value = 100 - CInt(Math.Truncate(m_Legend.FillStyle.GetPrimaryColor().ToColor().A * 100.0F / 255.0F))
			ShowLegendGridCheckBox.Checked = True

			AddHandler LocationEditorUC.PointChanged, AddressOf OnLegendLocationChanged
			AddHandler SizeEditorUC.SizeLChanged, AddressOf OnLegendSizeChanged
		End Sub

		Private Sub InitChartAndLegend()
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Legend Position")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' there is one legend by default when the chart is initialized
			m_Legend = CType(nChartControl1.Legends(0), NLegend)

			' switch the legend to manual mode
			m_Legend.Data.ExpandMode = LegendExpandMode.RowsFixed
			m_Legend.Data.RowCount = 4

			m_Legend.Header.Text = "EU Parliament Election"
			m_Legend.Footer.Text = "Number of seats for 2004"
			m_Legend.ShadowStyle.Offset = New NPointL(3, 3)

			' now configure the chart to display some information
			Dim chart As NCartesianChart = CType(nChartControl1.Charts(0), NCartesianChart)
			chart.Enable3D = True
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Axis(StandardAxis.PrimaryX).Visible = False

			' apply predefined projection and lighting
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add bar and change bar color
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.DataLabelStyle.Visible = True
			bar.Legend.Mode = SeriesLegendMode.DataPoints

			bar.AddDataPoint(New NDataPoint(39, "EUL"))
			bar.AddDataPoint(New NDataPoint(200, "PES"))
			bar.AddDataPoint(New NDataPoint(42, "EFA"))
			bar.AddDataPoint(New NDataPoint(15, "EDD"))
			bar.AddDataPoint(New NDataPoint(67, "ELDR"))
			bar.AddDataPoint(New NDataPoint(276, "EPP"))
			bar.AddDataPoint(New NDataPoint(27, "UEN"))
			bar.AddDataPoint(New NDataPoint(66, "Other"))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.NevronMultiColor)
			styleSheet.Apply(nChartControl1.Document)
		End Sub

		Private Sub HasShadowCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HasShadowCheckBox.CheckedChanged
			If HasShadowCheckBox.Checked Then
				m_Legend.ShadowStyle.Type = ShadowType.Solid
			Else
				m_Legend.ShadowStyle.Type = ShadowType.None
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub LegendHeaderFontButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_Legend.Header.TextStyle, textStyleResult) Then
				m_Legend.Header.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub LegendFooterFontButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim textStyleResult As NTextStyle = Nothing

			If NTextStyleTypeEditor.Edit(m_Legend.Footer.TextStyle, textStyleResult) Then
				m_Legend.Footer.TextStyle = textStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ShowLegendGridCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowLegendGridCheckBox.CheckedChanged
			Dim nWidht As Integer

			If ShowLegendGridCheckBox.Checked = True Then
				nWidht = 1
			Else
				nWidht = 0
			End If

			m_Legend.VerticalBorderStyle.Width = New NLength(nWidht, NGraphicsUnit.Pixel)
			m_Legend.HorizontalBorderStyle.Width = New NLength(nWidht, NGraphicsUnit.Pixel)

			nChartControl1.Refresh()
		End Sub

		Private Sub OnLegendLocationChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			m_Legend.Location = LocationEditorUC.Point

			nChartControl1.Refresh()
		End Sub

		Private Sub OnLegendSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			m_Legend.Size = SizeEditorUC.SizeL

			nChartControl1.Refresh()
		End Sub

		Private Sub UseAutomaticSizeCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UseAutomaticSizeCheckBox.CheckedChanged
			m_Legend.UseAutomaticSize = UseAutomaticSizeCheckBox.Checked
			SizeEditorUC.Enabled = Not UseAutomaticSizeCheckBox.Checked

			nChartControl1.Refresh()
		End Sub

		Private Sub ContentAlignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContentAlignmentComboBox.SelectedIndexChanged
			Dim values As Array = System.Enum.GetValues(GetType(ContentAlignment))
			m_Legend.ContentAlignment = DirectCast(values.GetValue(ContentAlignmentComboBox.SelectedIndex), ContentAlignment)

			nChartControl1.Refresh()
		End Sub

		Private Sub TransparencyScrollBar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles TransparencyScrollBar.ValueChanged
			m_Legend.FillStyle.SetTransparencyPercent(TransparencyScrollBar.Value)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
