Imports Microsoft.VisualBasic
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
	Public Class NBevelAndEmbossFilterUC
		Inherits NExampleBaseUC

		Private m_bUpdating As Boolean
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private colorDialog As Nevron.UI.WinForm.Controls.NColorDialog
		Private WithEvents LightColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShadowColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BevelTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents AngleNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents DepthNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents SoftenNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BlurTypeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents OriginalOpacityNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BarStyleComboBox As Nevron.UI.WinForm.Controls.NComboBox
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
			Dim resources As New System.Resources.ResourceManager(GetType(NBevelAndEmbossFilterUC))
			Me.label1 = New System.Windows.Forms.Label()
			Me.BevelTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.AngleNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.DepthNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.SoftenNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BlurTypeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.OriginalOpacityNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.LightColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShadowColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.colorDialog = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.label7 = New System.Windows.Forms.Label()
			Me.BarStyleComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			DirectCast(Me.AngleNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.DepthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.SoftenNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.OriginalOpacityNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(14, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(145, 17)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Bevel type:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BevelTypeComboBox
			' 
			Me.BevelTypeComboBox.Location = New System.Drawing.Point(14, 28)
			Me.BevelTypeComboBox.Name = "BevelTypeComboBox"
			Me.BevelTypeComboBox.Size = New System.Drawing.Size(145, 21)
			Me.BevelTypeComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BevelTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BevelTypeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(14, 51)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(145, 17)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Angle:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' AngleNumericUpDown
			' 
			Me.AngleNumericUpDown.Location = New System.Drawing.Point(14, 70)
			Me.AngleNumericUpDown.Maximum = New System.Decimal(New Integer() { 360, 0, 0, 0})
			Me.AngleNumericUpDown.Name = "AngleNumericUpDown"
			Me.AngleNumericUpDown.Size = New System.Drawing.Size(145, 20)
			Me.AngleNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AngleNumericUpDown.ValueChanged += new System.EventHandler(this.AngleNumericUpDown_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(14, 92)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(145, 17)
			Me.label3.TabIndex = 4
			Me.label3.Text = "Depth:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' DepthNumericUpDown
			' 
			Me.DepthNumericUpDown.Location = New System.Drawing.Point(14, 111)
			Me.DepthNumericUpDown.Name = "DepthNumericUpDown"
			Me.DepthNumericUpDown.Size = New System.Drawing.Size(145, 20)
			Me.DepthNumericUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DepthNumericUpDown.ValueChanged += new System.EventHandler(this.DepthNumericUpDown_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(14, 133)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(145, 17)
			Me.label4.TabIndex = 6
			Me.label4.Text = "Soften (blur depth):"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' SoftenNumericUpDown
			' 
			Me.SoftenNumericUpDown.Location = New System.Drawing.Point(14, 152)
			Me.SoftenNumericUpDown.Maximum = New System.Decimal(New Integer() { 20, 0, 0, 0})
			Me.SoftenNumericUpDown.Name = "SoftenNumericUpDown"
			Me.SoftenNumericUpDown.Size = New System.Drawing.Size(145, 20)
			Me.SoftenNumericUpDown.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SoftenNumericUpDown.ValueChanged += new System.EventHandler(this.SoftenNumericUpDown_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(14, 174)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(145, 17)
			Me.label5.TabIndex = 8
			Me.label5.Text = "BlurType:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' BlurTypeComboBox
			' 
			Me.BlurTypeComboBox.Location = New System.Drawing.Point(14, 193)
			Me.BlurTypeComboBox.Name = "BlurTypeComboBox"
			Me.BlurTypeComboBox.Size = New System.Drawing.Size(145, 21)
			Me.BlurTypeComboBox.TabIndex = 9
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BlurTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BlurTypeComboBox_SelectedIndexChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(14, 216)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(145, 17)
			Me.label6.TabIndex = 10
			Me.label6.Text = "Original opacity:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' OriginalOpacityNumericUpDown
			' 
			Me.OriginalOpacityNumericUpDown.Location = New System.Drawing.Point(14, 235)
			Me.OriginalOpacityNumericUpDown.Name = "OriginalOpacityNumericUpDown"
			Me.OriginalOpacityNumericUpDown.Size = New System.Drawing.Size(145, 20)
			Me.OriginalOpacityNumericUpDown.TabIndex = 11
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.OriginalOpacityNumericUpDown.ValueChanged += new System.EventHandler(this.OriginalOpacityNumericUpDown_ValueChanged);
			' 
			' LightColorButton
			' 
			Me.LightColorButton.Location = New System.Drawing.Point(14, 267)
			Me.LightColorButton.Name = "LightColorButton"
			Me.LightColorButton.Size = New System.Drawing.Size(145, 24)
			Me.LightColorButton.TabIndex = 12
			Me.LightColorButton.Text = "Light Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LightColorButton.Click += new System.EventHandler(this.LightColorButton_Click);
			' 
			' ShadowColorButton
			' 
			Me.ShadowColorButton.Location = New System.Drawing.Point(14, 296)
			Me.ShadowColorButton.Name = "ShadowColorButton"
			Me.ShadowColorButton.Size = New System.Drawing.Size(145, 24)
			Me.ShadowColorButton.TabIndex = 13
			Me.ShadowColorButton.Text = "Shadow color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShadowColorButton.Click += new System.EventHandler(this.ShadowColorButton_Click);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(14, 343)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(145, 17)
			Me.label7.TabIndex = 14
			Me.label7.Text = "Bar style:"
			' 
			' BarStyleComboBox
			' 
			Me.BarStyleComboBox.Location = New System.Drawing.Point(14, 366)
			Me.BarStyleComboBox.Name = "BarStyleComboBox"
			Me.BarStyleComboBox.Size = New System.Drawing.Size(145, 21)
			Me.BarStyleComboBox.TabIndex = 15
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.BarStyleComboBox_SelectedIndexChanged);
			' 
			' bevelAndEmbossImageFilterFilterUC
			' 
			Me.Controls.Add(Me.BarStyleComboBox)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.ShadowColorButton)
			Me.Controls.Add(Me.LightColorButton)
			Me.Controls.Add(Me.OriginalOpacityNumericUpDown)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.BlurTypeComboBox)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.SoftenNumericUpDown)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.DepthNumericUpDown)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.AngleNumericUpDown)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.BevelTypeComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "bevelAndEmbossImageFilterFilterUC"
			Me.Size = New System.Drawing.Size(175, 424)
			DirectCast(Me.AngleNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.DepthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.SoftenNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.OriginalOpacityNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Bevel and Emboss Filter")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' configure chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Wall(ChartWallType.Back).Visible = False

			' add bar and change bar color
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar Series"
			bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkRed, Color.Red)
			bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			bar.DataLabelStyle.Visible = False
			bar.Values.Add(18)
			bar.Values.Add(15)
			bar.Values.Add(21)
			bar.Values.Add(23)
			bar.Values.Add(28)
			bar.Values.Add(29)

			Dim bevelAndEmbossImageFilter As New NBevelAndEmbossImageFilter()
			bevelAndEmbossImageFilter.BlurType = BlurType.Gaussian
			bar.FillStyle.ImageFiltersStyle.Filters.Add(bevelAndEmbossImageFilter)

			' init form controls
			m_bUpdating = True

			BevelTypeComboBox.FillFromEnum(GetType(BevelType))
			BlurTypeComboBox.FillFromEnum(GetType(BlurType))
			BarStyleComboBox.FillFromEnum(GetType(BarShape))
			BarStyleComboBox.SelectedIndex = 0

			BevelTypeComboBox.SelectedIndex = CInt(bevelAndEmbossImageFilter.BevelType)
			AngleNumericUpDown.Value = CDec(bevelAndEmbossImageFilter.Angle)
			DepthNumericUpDown.Value = CDec(bevelAndEmbossImageFilter.Depth.Value)
			SoftenNumericUpDown.Value = CDec(bevelAndEmbossImageFilter.Soften.Value)
			BlurTypeComboBox.SelectedIndex = CInt(bevelAndEmbossImageFilter.BlurType)
			OriginalOpacityNumericUpDown.Value = CDec(bevelAndEmbossImageFilter.OriginalOpacity)

			m_bUpdating = False
		End Sub

		Private Sub UpdateFilter()
			If m_bUpdating Then
				Return
			End If

			m_bUpdating = True

			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			Dim bevelAndEmbossImageFilter As NBevelAndEmbossImageFilter = (CType(bar.FillStyle.ImageFiltersStyle.Filters(0), NBevelAndEmbossImageFilter))

			bevelAndEmbossImageFilter.BevelType = CType(BevelTypeComboBox.SelectedIndex, BevelType)
			bevelAndEmbossImageFilter.Angle = CSng(AngleNumericUpDown.Value)
			bevelAndEmbossImageFilter.Depth = New NLength(CInt(Fix(DepthNumericUpDown.Value)))
			bevelAndEmbossImageFilter.Soften = New NLength(CInt(Fix(SoftenNumericUpDown.Value)))
			bevelAndEmbossImageFilter.BlurType = CType(BlurTypeComboBox.SelectedIndex, BlurType)
			bevelAndEmbossImageFilter.OriginalOpacity = CInt(Fix(OriginalOpacityNumericUpDown.Value))

			m_bUpdating = False

			nChartControl1.Refresh()
		End Sub

		Private Sub BevelTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BevelTypeComboBox.SelectedIndexChanged
			UpdateFilter()
		End Sub

		Private Sub AngleNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AngleNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub DepthNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DepthNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub SoftenNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SoftenNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub BlurTypeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BlurTypeComboBox.SelectedIndexChanged
			UpdateFilter()
		End Sub

		Private Sub OriginalOpacityNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OriginalOpacityNumericUpDown.ValueChanged
			UpdateFilter()
		End Sub

		Private Sub LightColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LightColorButton.Click
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			Dim bevelAndEmbossImageFilter As NBevelAndEmbossImageFilter = (CType(bar.FillStyle.ImageFiltersStyle.Filters(0), NBevelAndEmbossImageFilter))
			colorDialog.Color = bevelAndEmbossImageFilter.LightColor

			If colorDialog.ShowDialog() = DialogResult.OK Then
				bevelAndEmbossImageFilter.LightColor = colorDialog.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ShadowColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShadowColorButton.Click
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			Dim bevelAndEmbossImageFilter As NBevelAndEmbossImageFilter = (CType(bar.FillStyle.ImageFiltersStyle.Filters(0), NBevelAndEmbossImageFilter))
			colorDialog.Color = bevelAndEmbossImageFilter.ShadowColor

			If colorDialog.ShowDialog() = DialogResult.OK Then
				bevelAndEmbossImageFilter.ShadowColor = colorDialog.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarStyleComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarStyleComboBox.SelectedIndexChanged
			Dim bar As NBarSeries = CType(nChartControl1.Charts(0).Series(0), NBarSeries)
			bar.BarShape = CType(BarStyleComboBox.SelectedIndex, BarShape)

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
