Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NGlowFilterUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private m_GlowFilter As NGlowImageFilter
		Private m_bUpdate As Boolean

		Private WithEvents OriginalOpacityNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BlurTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents GlowTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BubbleShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents InflateMargins As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents ChangeBubbleSizes As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents GlowColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DepthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private colorDialog As Nevron.UI.WinForm.Controls.NColorDialog
		Private label1 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing


		Public Sub New()
			InitializeComponent()

			BubbleShapeCombo.FillFromEnum(GetType(PointShape))
			BlurTypeComboBox.FillFromEnum(GetType(BlurType))
			GlowTypeComboBox.FillFromEnum(GetType(GlowType))
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
			Dim resources As New System.Resources.ResourceManager(GetType(NGlowFilterUC))
			Me.BubbleShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.colorDialog = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.GlowColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.OriginalOpacityNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label6 = New System.Windows.Forms.Label()
			Me.BlurTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.DepthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.GlowTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.ChangeBubbleSizes = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.InflateMargins = New Nevron.UI.WinForm.Controls.NCheckBox()
			DirectCast(Me.OriginalOpacityNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.DepthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' BubbleShapeCombo
			' 
			Me.BubbleShapeCombo.Location = New System.Drawing.Point(8, 256)
			Me.BubbleShapeCombo.Name = "BubbleShapeCombo"
			Me.BubbleShapeCombo.Size = New System.Drawing.Size(145, 21)
			Me.BubbleShapeCombo.TabIndex = 31
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleStyleCombo_SelectedIndexChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 232)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(145, 17)
			Me.label7.TabIndex = 30
			Me.label7.Text = "Bubble style:"
			' 
			' GlowColorButton
			' 
			Me.GlowColorButton.Location = New System.Drawing.Point(8, 192)
			Me.GlowColorButton.Name = "GlowColorButton"
			Me.GlowColorButton.Size = New System.Drawing.Size(145, 24)
			Me.GlowColorButton.TabIndex = 28
			Me.GlowColorButton.Text = "Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GlowColorButton.Click += new System.EventHandler(this.GlowColorButton_Click);
			' 
			' OriginalOpacityNumericUpDown
			' 
			Me.OriginalOpacityNumericUpDown.Location = New System.Drawing.Point(8, 166)
			Me.OriginalOpacityNumericUpDown.Name = "OriginalOpacityNumericUpDown"
			Me.OriginalOpacityNumericUpDown.Size = New System.Drawing.Size(145, 20)
			Me.OriginalOpacityNumericUpDown.TabIndex = 27
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginalOpacityNumericUpDown.ValueChanged += new System.EventHandler(this.OriginalOpacityNumericUpDown_ValueChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 145)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(145, 17)
			Me.label6.TabIndex = 26
			Me.label6.Text = "Original opacity:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BlurTypeComboBox
			' 
			Me.BlurTypeComboBox.Location = New System.Drawing.Point(8, 120)
			Me.BlurTypeComboBox.Name = "BlurTypeComboBox"
			Me.BlurTypeComboBox.Size = New System.Drawing.Size(145, 21)
			Me.BlurTypeComboBox.TabIndex = 25
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlurTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlurTypeComboBox_SelectedIndexChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 99)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(145, 17)
			Me.label5.TabIndex = 24
			Me.label5.Text = "BlurType:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DepthNumericUpDown
			' 
			Me.DepthNumericUpDown.Location = New System.Drawing.Point(8, 75)
			Me.DepthNumericUpDown.Name = "DepthNumericUpDown"
			Me.DepthNumericUpDown.Size = New System.Drawing.Size(145, 20)
			Me.DepthNumericUpDown.TabIndex = 21
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthNumericUpDown.ValueChanged += new System.EventHandler(this.DepthNumericUpDown_ValueChanged);
			' 
			' GlowTypeComboBox
			' 
			Me.GlowTypeComboBox.Location = New System.Drawing.Point(8, 29)
			Me.GlowTypeComboBox.Name = "GlowTypeComboBox"
			Me.GlowTypeComboBox.Size = New System.Drawing.Size(145, 21)
			Me.GlowTypeComboBox.TabIndex = 17
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GlowTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.GlowTypeComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(145, 17)
			Me.label1.TabIndex = 16
			Me.label1.Text = "Glow type:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 54)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(145, 17)
			Me.label8.TabIndex = 20
			Me.label8.Text = "Depth:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ChangeBubbleSizes
			' 
			Me.ChangeBubbleSizes.Location = New System.Drawing.Point(8, 384)
			Me.ChangeBubbleSizes.Name = "ChangeBubbleSizes"
			Me.ChangeBubbleSizes.Size = New System.Drawing.Size(153, 23)
			Me.ChangeBubbleSizes.TabIndex = 35
			Me.ChangeBubbleSizes.Text = "Change Bubble Sizes"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeBubbleSizes.Click += new System.EventHandler(this.ChangeBubbleSizes_Click);
			' 
			' ChangeYValues
			' 
			Me.ChangeYValues.Location = New System.Drawing.Point(8, 320)
			Me.ChangeYValues.Name = "ChangeYValues"
			Me.ChangeYValues.Size = New System.Drawing.Size(153, 23)
			Me.ChangeYValues.TabIndex = 33
			Me.ChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			' 
			' ChangeXValues
			' 
			Me.ChangeXValues.Location = New System.Drawing.Point(8, 352)
			Me.ChangeXValues.Name = "ChangeXValues"
			Me.ChangeXValues.Size = New System.Drawing.Size(153, 23)
			Me.ChangeXValues.TabIndex = 34
			Me.ChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			' 
			' InflateMargins
			' 
			Me.InflateMargins.Location = New System.Drawing.Point(8, 288)
			Me.InflateMargins.Name = "InflateMargins"
			Me.InflateMargins.Size = New System.Drawing.Size(153, 25)
			Me.InflateMargins.TabIndex = 32
			Me.InflateMargins.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			' 
			' GlowFilterUC
			' 
			Me.Controls.Add(Me.ChangeBubbleSizes)
			Me.Controls.Add(Me.ChangeYValues)
			Me.Controls.Add(Me.ChangeXValues)
			Me.Controls.Add(Me.InflateMargins)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.GlowColorButton)
			Me.Controls.Add(Me.OriginalOpacityNumericUpDown)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.BlurTypeComboBox)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.DepthNumericUpDown)
			Me.Controls.Add(Me.GlowTypeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.BubbleShapeCombo)
			Me.Controls.Add(Me.label8)
			Me.Name = "GlowFilterUC"
			Me.Size = New System.Drawing.Size(175, 555)
			DirectCast(Me.OriginalOpacityNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.DepthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Glow filter - Inner and Outer glow")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			m_Bubble = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			m_Bubble.DataLabelStyle.Visible = False
			m_Bubble.Legend.Format = "<label> X:<xvalue> Y:<value> Size:<size>"
			m_Bubble.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bubble.MinSize = New NLength(10.0F, NRelativeUnit.ParentPercentage)
			m_Bubble.MaxSize = New NLength(20.0F, NRelativeUnit.ParentPercentage)
			m_Bubble.UseXValues = True
			m_Bubble.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			m_GlowFilter = New NGlowImageFilter()

			Dim fillStyle As NFillStyle = New NColorFillStyle(Color.Gold)
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(10, 34, 10, "Company1", fillStyle))

			fillStyle = New NColorFillStyle(Color.DarkOrange)
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(15, 12, 20, "Company2", fillStyle))

			fillStyle = New NColorFillStyle(Color.Crimson)
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(12, 24, 25, "Company3", fillStyle))

			fillStyle = New NColorFillStyle(Color.DarkOrchid)
			fillStyle.ImageFiltersStyle.Filters.Add(m_GlowFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(8, 56, 15, "Company4", fillStyle))

			BubbleShapeCombo.SelectedIndex = 7
			InflateMargins.Checked = True

			m_bUpdate = True

			GlowTypeComboBox.SelectedIndex = CInt(m_GlowFilter.GlowType)
			DepthNumericUpDown.Value = CDec(m_GlowFilter.Depth.Value)
			BlurTypeComboBox.SelectedIndex = CInt(m_GlowFilter.BlurType)
			OriginalOpacityNumericUpDown.Value = CDec(m_GlowFilter.OriginalOpacity)

			m_bUpdate = False
		End Sub

		Private Sub UpdateFilter()
			If m_bUpdate Then
				Return
			End If

			m_bUpdate = True

			m_GlowFilter.GlowType = CType(GlowTypeComboBox.SelectedIndex, GlowType)
			m_GlowFilter.Depth = New NLength(CInt(Fix(DepthNumericUpDown.Value)))
			m_GlowFilter.BlurType = CType(BlurTypeComboBox.SelectedIndex, BlurType)
			m_GlowFilter.OriginalOpacity = CInt(Fix(OriginalOpacityNumericUpDown.Value))

			m_bUpdate = False

			nChartControl1.Refresh()
		End Sub

		Private Sub GlowTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GlowTypeComboBox.SelectedIndexChanged
			UpdateFilter()
		End Sub

		Private Sub DepthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepthNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub BlurTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BlurTypeComboBox.SelectedIndexChanged
			UpdateFilter()
		End Sub

		Private Sub OriginalOpacityNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OriginalOpacityNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub BubbleStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleShapeCombo.SelectedIndexChanged
			m_Bubble.BubbleShape = CType(BubbleShapeCombo.SelectedIndex, PointShape)
			nChartControl1.Refresh()
		End Sub

		Private Sub GlowColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GlowColorButton.Click
			colorDialog.Color = m_GlowFilter.Color

			If colorDialog.ShowDialog() = DialogResult.OK Then
				m_GlowFilter.Color = colorDialog.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeYValues.Click
			m_Bubble.XValues.FillRandom(Random, 4)
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValues.Click
			m_Bubble.Values.FillRandom(Random, 4)
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeBubbleSizes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeBubbleSizes.Click
			m_Bubble.Sizes.FillRandom(Random, 4)
			nChartControl1.Refresh()
		End Sub

		Private Sub InflateMargins_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMargins.CheckedChanged
			m_Bubble.InflateMargins = InflateMargins.Checked
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
