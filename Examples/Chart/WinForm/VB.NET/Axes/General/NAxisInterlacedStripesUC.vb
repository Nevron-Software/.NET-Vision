Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAxisInterlacedStripesUC
		Inherits NExampleBaseUC

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label7 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private WithEvents YAxisInterlacedStripesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents YAxisInterlacedStripeFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private groupBox0 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents YAxisInterlacedStripesEnd As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents YAxisInterlacedStripesBegin As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents YAxisInterlacedStripesInfinite As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents YAxisInterlacedStripesLength As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents YAxisInterlacedStripeInterval As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents XAxisInterlacedStripesBegin As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents XAxisInterlacedStripeFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents XAxisInterlacedStripesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents XAxisInterlacedStripesEnd As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents XAxisInterlacedStripesInfinite As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents XAxisInterlacedStripesLength As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents XAxisInterlacedStripeInterval As Nevron.UI.WinForm.Controls.NNumericUpDown
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private m_YAxisInterlaceStyle As NScaleStripStyle
		Private m_XAxisInterlaceStyle As NScaleStripStyle
		Private m_Chart As NCartesianChart
		Private m_Updating As Boolean

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
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.XAxisInterlacedStripeInterval = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label7 = New System.Windows.Forms.Label()
			Me.XAxisInterlacedStripesLength = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.XAxisInterlacedStripesEnd = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.XAxisInterlacedStripesInfinite = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.XAxisInterlacedStripesBegin = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.XAxisInterlacedStripeFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.XAxisInterlacedStripesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox0 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.YAxisInterlacedStripeInterval = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label8 = New System.Windows.Forms.Label()
			Me.YAxisInterlacedStripesLength = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label9 = New System.Windows.Forms.Label()
			Me.YAxisInterlacedStripesEnd = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label10 = New System.Windows.Forms.Label()
			Me.YAxisInterlacedStripesInfinite = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.YAxisInterlacedStripesBegin = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label11 = New System.Windows.Forms.Label()
			Me.YAxisInterlacedStripeFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.YAxisInterlacedStripesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.XAxisInterlacedStripeInterval, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.XAxisInterlacedStripesLength, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.XAxisInterlacedStripesEnd, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.XAxisInterlacedStripesBegin, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox0.SuspendLayout()
			DirectCast(Me.YAxisInterlacedStripeInterval, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.YAxisInterlacedStripesLength, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.YAxisInterlacedStripesEnd, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.YAxisInterlacedStripesBegin, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.XAxisInterlacedStripeInterval)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.XAxisInterlacedStripesLength)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.XAxisInterlacedStripesEnd)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.XAxisInterlacedStripesInfinite)
			Me.groupBox1.Controls.Add(Me.XAxisInterlacedStripesBegin)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.XAxisInterlacedStripeFillStyleButton)
			Me.groupBox1.Controls.Add(Me.XAxisInterlacedStripesCheckBox)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(8, 240)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(168, 232)
			Me.groupBox1.TabIndex = 58
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Horizontal interlacing"
			' 
			' XAxisInterlacedStripeInterval
			' 
			Me.XAxisInterlacedStripeInterval.Location = New System.Drawing.Point(80, 200)
			Me.XAxisInterlacedStripeInterval.Name = "XAxisInterlacedStripeInterval"
			Me.XAxisInterlacedStripeInterval.Size = New System.Drawing.Size(72, 20)
			Me.XAxisInterlacedStripeInterval.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisInterlacedStripeInterval.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripeInterval_ValueChanged);
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 200)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(48, 20)
			Me.label7.TabIndex = 9
			Me.label7.Text = "Interval:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' XAxisInterlacedStripesLength
			' 
			Me.XAxisInterlacedStripesLength.Location = New System.Drawing.Point(80, 168)
			Me.XAxisInterlacedStripesLength.Name = "XAxisInterlacedStripesLength"
			Me.XAxisInterlacedStripesLength.Size = New System.Drawing.Size(72, 20)
			Me.XAxisInterlacedStripesLength.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisInterlacedStripesLength.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripesLength_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 168)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(48, 20)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Length:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' XAxisInterlacedStripesEnd
			' 
			Me.XAxisInterlacedStripesEnd.Location = New System.Drawing.Point(80, 112)
			Me.XAxisInterlacedStripesEnd.Name = "XAxisInterlacedStripesEnd"
			Me.XAxisInterlacedStripesEnd.Size = New System.Drawing.Size(72, 20)
			Me.XAxisInterlacedStripesEnd.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisInterlacedStripesEnd.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripesEnd_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 112)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(48, 20)
			Me.label2.TabIndex = 5
			Me.label2.Text = "End:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' XAxisInterlacedStripesInfinite
			' 
			Me.XAxisInterlacedStripesInfinite.Location = New System.Drawing.Point(80, 136)
			Me.XAxisInterlacedStripesInfinite.Name = "XAxisInterlacedStripesInfinite"
			Me.XAxisInterlacedStripesInfinite.Size = New System.Drawing.Size(72, 20)
			Me.XAxisInterlacedStripesInfinite.TabIndex = 4
			Me.XAxisInterlacedStripesInfinite.Text = "Infinite"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisInterlacedStripesInfinite.CheckedChanged += new System.EventHandler(this.XAxisInterlacedStripesInfinite_CheckedChanged);
			' 
			' XAxisInterlacedStripesBegin
			' 
			Me.XAxisInterlacedStripesBegin.Location = New System.Drawing.Point(80, 80)
			Me.XAxisInterlacedStripesBegin.Name = "XAxisInterlacedStripesBegin"
			Me.XAxisInterlacedStripesBegin.Size = New System.Drawing.Size(72, 20)
			Me.XAxisInterlacedStripesBegin.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisInterlacedStripesBegin.ValueChanged += new System.EventHandler(this.XAxisInterlacedStripesBegin_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 80)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(48, 20)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Begin:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' XAxisInterlacedStripeFillStyleButton
			' 
			Me.XAxisInterlacedStripeFillStyleButton.Location = New System.Drawing.Point(8, 48)
			Me.XAxisInterlacedStripeFillStyleButton.Name = "XAxisInterlacedStripeFillStyleButton"
			Me.XAxisInterlacedStripeFillStyleButton.Size = New System.Drawing.Size(152, 24)
			Me.XAxisInterlacedStripeFillStyleButton.TabIndex = 1
			Me.XAxisInterlacedStripeFillStyleButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisInterlacedStripeFillStyleButton.Click += new System.EventHandler(this.XAxisInterlacedStripeFillStyleButton_Click);
			' 
			' XAxisInterlacedStripesCheckBox
			' 
			Me.XAxisInterlacedStripesCheckBox.Location = New System.Drawing.Point(8, 16)
			Me.XAxisInterlacedStripesCheckBox.Name = "XAxisInterlacedStripesCheckBox"
			Me.XAxisInterlacedStripesCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.XAxisInterlacedStripesCheckBox.TabIndex = 0
			Me.XAxisInterlacedStripesCheckBox.Text = "Enable"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XAxisInterlacedStripesCheckBox.CheckedChanged += new System.EventHandler(this.XAxisInterlacedStripesCheckBox_CheckedChanged);
			' 
			' groupBox0
			' 
			Me.groupBox0.Controls.Add(Me.YAxisInterlacedStripeInterval)
			Me.groupBox0.Controls.Add(Me.label8)
			Me.groupBox0.Controls.Add(Me.YAxisInterlacedStripesLength)
			Me.groupBox0.Controls.Add(Me.label9)
			Me.groupBox0.Controls.Add(Me.YAxisInterlacedStripesEnd)
			Me.groupBox0.Controls.Add(Me.label10)
			Me.groupBox0.Controls.Add(Me.YAxisInterlacedStripesInfinite)
			Me.groupBox0.Controls.Add(Me.YAxisInterlacedStripesBegin)
			Me.groupBox0.Controls.Add(Me.label11)
			Me.groupBox0.Controls.Add(Me.YAxisInterlacedStripeFillStyleButton)
			Me.groupBox0.Controls.Add(Me.YAxisInterlacedStripesCheckBox)
			Me.groupBox0.ImageIndex = 0
			Me.groupBox0.Location = New System.Drawing.Point(8, 8)
			Me.groupBox0.Name = "groupBox0"
			Me.groupBox0.Size = New System.Drawing.Size(168, 232)
			Me.groupBox0.TabIndex = 59
			Me.groupBox0.TabStop = False
			Me.groupBox0.Text = "Vertical interlacing"
			' 
			' YAxisInterlacedStripeInterval
			' 
			Me.YAxisInterlacedStripeInterval.Location = New System.Drawing.Point(80, 200)
			Me.YAxisInterlacedStripeInterval.Name = "YAxisInterlacedStripeInterval"
			Me.YAxisInterlacedStripeInterval.Size = New System.Drawing.Size(72, 20)
			Me.YAxisInterlacedStripeInterval.TabIndex = 10
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisInterlacedStripeInterval.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripeInterval_ValueChanged);
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 200)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(48, 20)
			Me.label8.TabIndex = 9
			Me.label8.Text = "Interval:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' YAxisInterlacedStripesLength
			' 
			Me.YAxisInterlacedStripesLength.Location = New System.Drawing.Point(80, 168)
			Me.YAxisInterlacedStripesLength.Name = "YAxisInterlacedStripesLength"
			Me.YAxisInterlacedStripesLength.Size = New System.Drawing.Size(72, 20)
			Me.YAxisInterlacedStripesLength.TabIndex = 8
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisInterlacedStripesLength.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripesLength_ValueChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 168)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(48, 20)
			Me.label9.TabIndex = 7
			Me.label9.Text = "Length:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' YAxisInterlacedStripesEnd
			' 
			Me.YAxisInterlacedStripesEnd.Location = New System.Drawing.Point(80, 112)
			Me.YAxisInterlacedStripesEnd.Name = "YAxisInterlacedStripesEnd"
			Me.YAxisInterlacedStripesEnd.Size = New System.Drawing.Size(72, 20)
			Me.YAxisInterlacedStripesEnd.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisInterlacedStripesEnd.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripesEnd_ValueChanged);
			' 
			' label10
			' 
			Me.label10.Location = New System.Drawing.Point(8, 112)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(48, 20)
			Me.label10.TabIndex = 5
			Me.label10.Text = "End:"
			Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' YAxisInterlacedStripesInfinite
			' 
			Me.YAxisInterlacedStripesInfinite.Location = New System.Drawing.Point(80, 136)
			Me.YAxisInterlacedStripesInfinite.Name = "YAxisInterlacedStripesInfinite"
			Me.YAxisInterlacedStripesInfinite.Size = New System.Drawing.Size(72, 20)
			Me.YAxisInterlacedStripesInfinite.TabIndex = 4
			Me.YAxisInterlacedStripesInfinite.Text = "Infinite"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisInterlacedStripesInfinite.CheckedChanged += new System.EventHandler(this.YAxisInterlacedStripesInfinite_CheckedChanged);
			' 
			' YAxisInterlacedStripesBegin
			' 
			Me.YAxisInterlacedStripesBegin.Location = New System.Drawing.Point(80, 80)
			Me.YAxisInterlacedStripesBegin.Name = "YAxisInterlacedStripesBegin"
			Me.YAxisInterlacedStripesBegin.Size = New System.Drawing.Size(72, 20)
			Me.YAxisInterlacedStripesBegin.TabIndex = 3
			Me.YAxisInterlacedStripesBegin.Value = New System.Decimal(New Integer() { 2, 0, 0, 0})
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisInterlacedStripesBegin.ValueChanged += new System.EventHandler(this.YAxisInterlacedStripesBegin_ValueChanged);
			' 
			' label11
			' 
			Me.label11.Location = New System.Drawing.Point(8, 80)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(48, 20)
			Me.label11.TabIndex = 2
			Me.label11.Text = "Begin:"
			Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' YAxisInterlacedStripeFillStyleButton
			' 
			Me.YAxisInterlacedStripeFillStyleButton.Location = New System.Drawing.Point(8, 48)
			Me.YAxisInterlacedStripeFillStyleButton.Name = "YAxisInterlacedStripeFillStyleButton"
			Me.YAxisInterlacedStripeFillStyleButton.Size = New System.Drawing.Size(152, 24)
			Me.YAxisInterlacedStripeFillStyleButton.TabIndex = 1
			Me.YAxisInterlacedStripeFillStyleButton.Text = "Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisInterlacedStripeFillStyleButton.Click += new System.EventHandler(this.YAxisInterlacedStripeFillStyleButton_Click);
			' 
			' YAxisInterlacedStripesCheckBox
			' 
			Me.YAxisInterlacedStripesCheckBox.Location = New System.Drawing.Point(8, 16)
			Me.YAxisInterlacedStripesCheckBox.Name = "YAxisInterlacedStripesCheckBox"
			Me.YAxisInterlacedStripesCheckBox.Size = New System.Drawing.Size(152, 24)
			Me.YAxisInterlacedStripesCheckBox.TabIndex = 0
			Me.YAxisInterlacedStripesCheckBox.Text = "Enable"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YAxisInterlacedStripesCheckBox.CheckedChanged += new System.EventHandler(this.YAxisInterlacedStripesCheckBox_CheckedChanged);
			' 
			' NAxisInterlacedStripesUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox0)
			Me.Name = "NAxisInterlacedStripesUC"
			Me.Size = New System.Drawing.Size(184, 528)
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.XAxisInterlacedStripeInterval, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.XAxisInterlacedStripesLength, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.XAxisInterlacedStripesEnd, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.XAxisInterlacedStripesBegin, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox0.ResumeLayout(False)
			DirectCast(Me.YAxisInterlacedStripeInterval, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.YAxisInterlacedStripesLength, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.YAxisInterlacedStripesEnd, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.YAxisInterlacedStripesBegin, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Interlaced Stripes")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			m_Chart = CType(nChartControl1.Charts(0), NCartesianChart)
			m_Chart.BoundsMode = BoundsMode.Stretch

			Dim line As NLineSeries = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			line.Name = "Line Series"
			line.DataLabelStyle.Format = "<value>"
			line.MarkerStyle.Visible = True
			line.MarkerStyle.PointShape = PointShape.Sphere
			line.LineSegmentShape = LineSegmentShape.Tape
			line.BorderStyle.Width = New NLength(2, NGraphicsUnit.Point)
			line.DataLabelStyle.Visible = False
			line.Values.FillRandom(Random, 20)
			line.ShadowStyle.Type = ShadowType.GaussianBlur
			line.ShadowStyle.Offset = New NPointL(3, 3)
			line.ShadowStyle.FadeLength = New NLength(5)
			line.ShadowStyle.Color = Color.FromArgb(55, 0, 0, 0)

			m_YAxisInterlaceStyle = New NScaleStripStyle()
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, True)
			m_YAxisInterlaceStyle.SetShowAtWall(ChartWallType.Left, True)
			m_YAxisInterlaceStyle.Interlaced = True
			m_YAxisInterlaceStyle.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.Beige, Color.FromArgb(254, 237, 226))
			m_YAxisInterlaceStyle.Begin = 0
			m_YAxisInterlaceStyle.End = 10
			m_YAxisInterlaceStyle.Infinite = True
			m_YAxisInterlaceStyle.Interval = 1
			m_YAxisInterlaceStyle.Length = 1

			m_XAxisInterlaceStyle = New NScaleStripStyle()
			m_XAxisInterlaceStyle.FillStyle = New NGradientFillStyle(Color.FromArgb(125, 166, 166, 166), Color.FromArgb(125, 211, 211, 211))
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Back, True)
			m_XAxisInterlaceStyle.SetShowAtWall(ChartWallType.Floor, True)
			m_XAxisInterlaceStyle.Interlaced = True
			m_XAxisInterlaceStyle.Begin = 0
			m_XAxisInterlaceStyle.End = 10
			m_XAxisInterlaceStyle.Infinite = True
			m_XAxisInterlaceStyle.Interval = 1
			m_XAxisInterlaceStyle.Length = 1

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' update controls
			YAxisInterlacedStripesBegin.Value = m_YAxisInterlaceStyle.Begin
			YAxisInterlacedStripesEnd.Value = m_YAxisInterlaceStyle.End
			YAxisInterlacedStripesInfinite.Checked = m_YAxisInterlaceStyle.Infinite
			YAxisInterlacedStripesLength.Value = m_YAxisInterlaceStyle.Length
			YAxisInterlacedStripeInterval.Value = m_YAxisInterlaceStyle.Interval

			XAxisInterlacedStripesBegin.Value = m_XAxisInterlaceStyle.Begin
			XAxisInterlacedStripesEnd.Value = m_XAxisInterlaceStyle.End
			XAxisInterlacedStripesInfinite.Checked = m_XAxisInterlaceStyle.Infinite
			XAxisInterlacedStripesLength.Value = m_XAxisInterlaceStyle.Length
			XAxisInterlacedStripeInterval.Value = m_XAxisInterlaceStyle.Interval

			m_Updating = False

			YAxisInterlacedStripesCheckBox.Checked = True
		End Sub

		Private Sub UpdateInterlaceStirpes()
			If m_Updating Then
				Return
			End If

			Dim standardScale As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)

			standardScale.StripStyles.Clear()
			If YAxisInterlacedStripesCheckBox.Checked Then
				standardScale.StripStyles.Add(m_YAxisInterlaceStyle)
			End If

			m_YAxisInterlaceStyle.Begin = CInt(Math.Truncate(YAxisInterlacedStripesBegin.Value))
			m_YAxisInterlaceStyle.End = CInt(Math.Truncate(YAxisInterlacedStripesEnd.Value))
			m_YAxisInterlaceStyle.Infinite = YAxisInterlacedStripesInfinite.Checked
			m_YAxisInterlaceStyle.Length = CInt(Math.Truncate(YAxisInterlacedStripesLength.Value))
			m_YAxisInterlaceStyle.Interval = CInt(Math.Truncate(YAxisInterlacedStripeInterval.Value))

			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)

			standardScale.StripStyles.Clear()
			If XAxisInterlacedStripesCheckBox.Checked Then
				standardScale.StripStyles.Add(m_XAxisInterlaceStyle)
			End If

			m_XAxisInterlaceStyle.Begin = CInt(Math.Truncate(XAxisInterlacedStripesBegin.Value))
			m_XAxisInterlaceStyle.End = CInt(Math.Truncate(XAxisInterlacedStripesEnd.Value))
			m_XAxisInterlaceStyle.Infinite = XAxisInterlacedStripesInfinite.Checked
			m_XAxisInterlaceStyle.Length = CInt(Math.Truncate(XAxisInterlacedStripesLength.Value))
			m_XAxisInterlaceStyle.Interval = CInt(Math.Truncate(XAxisInterlacedStripeInterval.Value))

			nChartControl1.Refresh()
		End Sub

		Private Sub YAxisInterlacedStripesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisInterlacedStripesCheckBox.CheckedChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub YAxisInterlacedStripeFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisInterlacedStripeFillStyleButton.Click
			Dim fillStyle As NFillStyle = Nothing

			If NFillStyleTypeEditorNoAutomatic.Edit(m_YAxisInterlaceStyle.FillStyle, False, fillStyle) Then
				m_YAxisInterlaceStyle.FillStyle = fillStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub YAxisInterlacedStripesBegin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisInterlacedStripesBegin.ValueChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub YAxisInterlacedStripesEnd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisInterlacedStripesEnd.ValueChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub YAxisInterlacedStripesInfinite_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisInterlacedStripesInfinite.CheckedChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub YAxisInterlacedStripesLength_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisInterlacedStripesLength.ValueChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub YAxisInterlacedStripeInterval_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YAxisInterlacedStripeInterval.ValueChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub XAxisInterlacedStripesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisInterlacedStripesCheckBox.CheckedChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub XAxisInterlacedStripeFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisInterlacedStripeFillStyleButton.Click
			Dim fillStyle As NFillStyle = Nothing

			If NFillStyleTypeEditorNoAutomatic.Edit(m_XAxisInterlaceStyle.FillStyle, False, fillStyle) Then
				m_XAxisInterlaceStyle.FillStyle = fillStyle
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub XAxisInterlacedStripesBegin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisInterlacedStripesBegin.ValueChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub XAxisInterlacedStripesEnd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisInterlacedStripesEnd.ValueChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub XAxisInterlacedStripesInfinite_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisInterlacedStripesInfinite.CheckedChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub XAxisInterlacedStripesLength_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisInterlacedStripesLength.ValueChanged
			UpdateInterlaceStirpes()
		End Sub

		Private Sub XAxisInterlacedStripeInterval_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XAxisInterlacedStripeInterval.ValueChanged
			UpdateInterlaceStirpes()
		End Sub
	End Class
End Namespace
