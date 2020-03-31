Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NLightingFilterUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bubble As NBubbleSeries
		Private m_LightingFilter As NLightingImageFilter
		Private m_Updating As Boolean

		Private colorDialog As Nevron.UI.WinForm.Controls.NColorDialog
		Private WithEvents ChangeBubbleSizes As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeYValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ChangeXValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents InflateMargins As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents BubbleShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents DiffuseColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SpecularColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositionXnumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents PositionYnumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents PositionZnumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As System.Windows.Forms.Label
		Private WithEvents LightSourceTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private WithEvents BlurTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private WithEvents SurfaceScaleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ShininessNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BevelDepthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			m_Updating = True
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
			Me.colorDialog = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.ChangeBubbleSizes = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeYValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.ChangeXValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.InflateMargins = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.BubbleShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.PositionXnumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.PositionYnumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.PositionZnumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.DiffuseColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SpecularColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label3 = New System.Windows.Forms.Label()
			Me.LightSourceTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.BevelDepthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BlurTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.SurfaceScaleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.ShininessNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			DirectCast(Me.PositionXnumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.PositionYnumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.PositionZnumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.BevelDepthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.SurfaceScaleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.ShininessNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ChangeBubbleSizes
			' 
			Me.ChangeBubbleSizes.Location = New System.Drawing.Point(11, 520)
			Me.ChangeBubbleSizes.Name = "ChangeBubbleSizes"
			Me.ChangeBubbleSizes.Size = New System.Drawing.Size(153, 23)
			Me.ChangeBubbleSizes.TabIndex = 17
			Me.ChangeBubbleSizes.Text = "Change Bubble Sizes"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeBubbleSizes.Click += new System.EventHandler(this.ChangeBubbleSizes_Click);
			' 
			' ChangeYValues
			' 
			Me.ChangeYValues.Location = New System.Drawing.Point(11, 456)
			Me.ChangeYValues.Name = "ChangeYValues"
			Me.ChangeYValues.Size = New System.Drawing.Size(153, 23)
			Me.ChangeYValues.TabIndex = 15
			Me.ChangeYValues.Text = "Change Y Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeYValues.Click += new System.EventHandler(this.ChangeYValues_Click);
			' 
			' ChangeXValues
			' 
			Me.ChangeXValues.Location = New System.Drawing.Point(11, 488)
			Me.ChangeXValues.Name = "ChangeXValues"
			Me.ChangeXValues.Size = New System.Drawing.Size(153, 23)
			Me.ChangeXValues.TabIndex = 16
			Me.ChangeXValues.Text = "Change X Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeXValues.Click += new System.EventHandler(this.ChangeXValues_Click);
			' 
			' InflateMargins
			' 
			Me.InflateMargins.Location = New System.Drawing.Point(11, 427)
			Me.InflateMargins.Name = "InflateMargins"
			Me.InflateMargins.Size = New System.Drawing.Size(153, 18)
			Me.InflateMargins.TabIndex = 14
			Me.InflateMargins.Text = "Inflate Margins"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.InflateMargins.CheckedChanged += new System.EventHandler(this.InflateMargins_CheckedChanged);
			' 
			' BubbleShapeCombo
			' 
			Me.BubbleShapeCombo.Location = New System.Drawing.Point(11, 402)
			Me.BubbleShapeCombo.Name = "BubbleShapeCombo"
			Me.BubbleShapeCombo.Size = New System.Drawing.Size(153, 21)
			Me.BubbleShapeCombo.TabIndex = 13
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BubbleShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BubbleShapeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(11, 383)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(153, 18)
			Me.label1.TabIndex = 12
			Me.label1.Text = "Bubble Style:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(11, 53)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(153, 18)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Position:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' PositionXnumericUpDown
			' 
			Me.PositionXnumericUpDown.Location = New System.Drawing.Point(11, 73)
			Me.PositionXnumericUpDown.Minimum = New System.Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.PositionXnumericUpDown.Name = "PositionXnumericUpDown"
			Me.PositionXnumericUpDown.Size = New System.Drawing.Size(153, 20)
			Me.PositionXnumericUpDown.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositionXnumericUpDown.ValueChanged += new System.EventHandler(this.PositionXnumericUpDown_ValueChanged);
			' 
			' PositionYnumericUpDown
			' 
			Me.PositionYnumericUpDown.Location = New System.Drawing.Point(11, 95)
			Me.PositionYnumericUpDown.Minimum = New System.Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.PositionYnumericUpDown.Name = "PositionYnumericUpDown"
			Me.PositionYnumericUpDown.Size = New System.Drawing.Size(153, 20)
			Me.PositionYnumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositionYnumericUpDown.ValueChanged += new System.EventHandler(this.PositionYnumericUpDown_ValueChanged);
			' 
			' PositionZnumericUpDown
			' 
			Me.PositionZnumericUpDown.Location = New System.Drawing.Point(11, 117)
			Me.PositionZnumericUpDown.Minimum = New System.Decimal(New Integer() { 100, 0, 0, -2147483648})
			Me.PositionZnumericUpDown.Name = "PositionZnumericUpDown"
			Me.PositionZnumericUpDown.Size = New System.Drawing.Size(153, 20)
			Me.PositionZnumericUpDown.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositionZnumericUpDown.ValueChanged += new System.EventHandler(this.PositionZnumericUpDown_ValueChanged);
			' 
			' DiffuseColorButton
			' 
			Me.DiffuseColorButton.Location = New System.Drawing.Point(11, 139)
			Me.DiffuseColorButton.Name = "DiffuseColorButton"
			Me.DiffuseColorButton.Size = New System.Drawing.Size(153, 23)
			Me.DiffuseColorButton.TabIndex = 10
			Me.DiffuseColorButton.Text = "Diffuse color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DiffuseColorButton.Click += new System.EventHandler(this.DiffuseColorButton_Click);
			' 
			' SpecularColorButton
			' 
			Me.SpecularColorButton.Location = New System.Drawing.Point(11, 164)
			Me.SpecularColorButton.Name = "SpecularColorButton"
			Me.SpecularColorButton.Size = New System.Drawing.Size(153, 23)
			Me.SpecularColorButton.TabIndex = 11
			Me.SpecularColorButton.Text = "Specular color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SpecularColorButton.Click += new System.EventHandler(this.SpecularColorButton_Click);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(11, 10)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(153, 18)
			Me.label3.TabIndex = 18
			Me.label3.Text = "Light source type:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' LightSourceTypeComboBox
			' 
			Me.LightSourceTypeComboBox.Location = New System.Drawing.Point(11, 30)
			Me.LightSourceTypeComboBox.Name = "LightSourceTypeComboBox"
			Me.LightSourceTypeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.LightSourceTypeComboBox.TabIndex = 19
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LightSourceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.LightSourceTypeComboBox_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(11, 189)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(153, 18)
			Me.label4.TabIndex = 20
			Me.label4.Text = "Bevel depth:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BevelDepthNumericUpDown
			' 
			Me.BevelDepthNumericUpDown.Location = New System.Drawing.Point(11, 209)
			Me.BevelDepthNumericUpDown.Name = "BevelDepthNumericUpDown"
			Me.BevelDepthNumericUpDown.Size = New System.Drawing.Size(153, 20)
			Me.BevelDepthNumericUpDown.TabIndex = 21
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BevelDepthNumericUpDown.ValueChanged += new System.EventHandler(this.BevelDepthNumericUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(11, 231)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(153, 18)
			Me.label5.TabIndex = 22
			Me.label5.Text = "Blur type:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BlurTypeComboBox
			' 
			Me.BlurTypeComboBox.Location = New System.Drawing.Point(11, 251)
			Me.BlurTypeComboBox.Name = "BlurTypeComboBox"
			Me.BlurTypeComboBox.Size = New System.Drawing.Size(153, 21)
			Me.BlurTypeComboBox.TabIndex = 23
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlurTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlurTypeComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(11, 274)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(153, 18)
			Me.label6.TabIndex = 24
			Me.label6.Text = "Surface scale:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' SurfaceScaleNumericUpDown
			' 
			Me.SurfaceScaleNumericUpDown.DecimalPlaces = 2
			Me.SurfaceScaleNumericUpDown.Increment = New System.Decimal(New Integer() { 1, 0, 0, 65536})
			Me.SurfaceScaleNumericUpDown.Location = New System.Drawing.Point(11, 294)
			Me.SurfaceScaleNumericUpDown.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 65536})
			Me.SurfaceScaleNumericUpDown.Name = "SurfaceScaleNumericUpDown"
			Me.SurfaceScaleNumericUpDown.Size = New System.Drawing.Size(153, 20)
			Me.SurfaceScaleNumericUpDown.TabIndex = 25
			Me.SurfaceScaleNumericUpDown.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SurfaceScaleNumericUpDown.ValueChanged += new System.EventHandler(this.SurfaceScaleNumericUpDown_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(11, 316)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(153, 18)
			Me.label7.TabIndex = 26
			Me.label7.Text = "Shininess:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ShininessNumericUpDown
			' 
			Me.ShininessNumericUpDown.Location = New System.Drawing.Point(11, 336)
			Me.ShininessNumericUpDown.Name = "ShininessNumericUpDown"
			Me.ShininessNumericUpDown.Size = New System.Drawing.Size(153, 20)
			Me.ShininessNumericUpDown.TabIndex = 27
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShininessNumericUpDown.ValueChanged += new System.EventHandler(this.ShininessNumericUpDown_ValueChanged);
			' 
			' LightingFilterUC
			' 
			Me.Controls.Add(Me.ShininessNumericUpDown)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.SurfaceScaleNumericUpDown)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.BlurTypeComboBox)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.BevelDepthNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.LightSourceTypeComboBox)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.SpecularColorButton)
			Me.Controls.Add(Me.DiffuseColorButton)
			Me.Controls.Add(Me.PositionZnumericUpDown)
			Me.Controls.Add(Me.PositionYnumericUpDown)
			Me.Controls.Add(Me.PositionXnumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ChangeBubbleSizes)
			Me.Controls.Add(Me.ChangeYValues)
			Me.Controls.Add(Me.ChangeXValues)
			Me.Controls.Add(Me.InflateMargins)
			Me.Controls.Add(Me.BubbleShapeCombo)
			Me.Controls.Add(Me.label1)
			Me.Name = "LightingFilterUC"
			Me.Size = New System.Drawing.Size(175, 555)
			DirectCast(Me.PositionXnumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.PositionYnumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.PositionZnumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.BevelDepthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.SurfaceScaleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.ShininessNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Lighting Filter")
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

			m_Bubble.ShadowStyle.Type = ShadowType.Solid
			m_Bubble.ShadowStyle.Offset = New NPointL(3, 3)
			m_Bubble.ShadowStyle.Color = Color.FromArgb(60, 0, 0, 0)
			m_Bubble.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Bubble.InflateMargins = True

			m_LightingFilter = New NLightingImageFilter()

			Dim fillStyle As NFillStyle = New NColorFillStyle(Color.Gold)
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(10, 34, 10, "Company1", fillStyle))

			fillStyle = New NColorFillStyle(Color.DarkOrange)
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(15, 12, 20, "Company2", fillStyle))

			fillStyle = New NColorFillStyle(Color.Crimson)
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(12, 24, 25, "Company3", fillStyle))

			fillStyle = New NColorFillStyle(Color.DarkOrchid)
			fillStyle.ImageFiltersStyle.Filters.Add(m_LightingFilter)
			m_Bubble.AddDataPoint(New NBubbleDataPoint(8, 56, 15, "Company4", fillStyle))

			BubbleShapeCombo.FillFromEnum(GetType(PointShape))
			BubbleShapeCombo.SelectedIndex = 7

			InflateMargins.Checked = True

			LightSourceTypeComboBox.FillFromEnum(GetType(LightSourceType))
			BlurTypeComboBox.FillFromEnum(GetType(BlurType))

			BevelDepthNumericUpDown.Value = CDec(m_LightingFilter.BevelDepth.Value)
			BlurTypeComboBox.SelectedIndex = CInt(m_LightingFilter.BlurType)
			SurfaceScaleNumericUpDown.Value = CDec(m_LightingFilter.SurfaceScale)
			ShininessNumericUpDown.Value = CDec(m_LightingFilter.Shininess)
			LightSourceTypeComboBox.SelectedIndex = CInt(m_LightingFilter.LightSourceType)

			Dim vector As NVector3DF = m_LightingFilter.Position
			PositionXnumericUpDown.Value = CDec(vector.X)
			PositionYnumericUpDown.Value = CDec(vector.Y)
			PositionZnumericUpDown.Value = CDec(vector.Z)

			m_Updating = False
		End Sub

		Private Sub ChangeXValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeXValues.Click
			m_Bubble.XValues.FillRandom(Random, 4)
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeYValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeYValues.Click
			m_Bubble.Values.FillRandom(Random, 4)
			nChartControl1.Refresh()
		End Sub

		Private Sub ChangeBubbleSizes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeBubbleSizes.Click
			m_Bubble.Sizes.FillRandom(Random, 4)
			nChartControl1.Refresh()
		End Sub

		Private Sub BubbleShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BubbleShapeCombo.SelectedIndexChanged
			If Not m_Updating Then
				m_Bubble.BubbleShape = CType(BubbleShapeCombo.SelectedIndex, PointShape)
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub InflateMargins_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InflateMargins.CheckedChanged
			If Not m_Updating Then
				m_Bubble.InflateMargins = InflateMargins.Checked
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub DiffuseColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiffuseColorButton.Click
			colorDialog.Color = m_LightingFilter.DiffuseColor
			If colorDialog.ShowDialog() = DialogResult.OK Then
				m_LightingFilter.DiffuseColor = colorDialog.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub SpecularColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpecularColorButton.Click
			colorDialog.Color = m_LightingFilter.SpecularColor
			If colorDialog.ShowDialog() = DialogResult.OK Then
				m_LightingFilter.SpecularColor = colorDialog.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub UpdateFilter()
			If m_Updating Then
				Return
			End If

			Dim vector As New NVector3DF(CSng(PositionXnumericUpDown.Value), CSng(PositionYnumericUpDown.Value), CSng(PositionZnumericUpDown.Value))

			m_LightingFilter.Position = vector
			m_LightingFilter.LightSourceType = CType(LightSourceTypeComboBox.SelectedIndex, LightSourceType)
			m_LightingFilter.BevelDepth = New NLength(CInt(Fix(BevelDepthNumericUpDown.Value)))
			m_LightingFilter.BlurType = CType(BlurTypeComboBox.SelectedIndex, BlurType)
			m_LightingFilter.SurfaceScale = CSng(SurfaceScaleNumericUpDown.Value)
			m_LightingFilter.Shininess = CSng(ShininessNumericUpDown.Value)

			nChartControl1.Refresh()
		End Sub


		Private Sub PositionXnumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositionXnumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub PositionYnumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositionYnumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub PositionZnumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositionZnumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub LightSourceTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LightSourceTypeComboBox.SelectedIndexChanged
			UpdateFilter()
		End Sub

		Private Sub BevelDepthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BevelDepthNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub BlurTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BlurTypeComboBox.SelectedIndexChanged
			UpdateFilter()
		End Sub

		Private Sub SurfaceScaleNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SurfaceScaleNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub ShininessNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShininessNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub
	End Class
End Namespace
