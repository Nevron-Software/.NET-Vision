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
	Public Class NAxisModelCrossingUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private label3 As System.Windows.Forms.Label
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents LeftAxisAlignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BottomAxisAlignmentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BottomAxisOffsetUC As Nevron.Editors.NLengthEditorUC
		Private WithEvents LeftAxisOffsetUC As Nevron.Editors.NLengthEditorUC
		Private components As System.ComponentModel.Container = Nothing
		Private m_Updating As Boolean

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
			Me.label3 = New System.Windows.Forms.Label()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.LeftAxisOffsetUC = New Nevron.Editors.NLengthEditorUC()
			Me.LeftAxisAlignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BottomAxisAlignmentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BottomAxisOffsetUC = New Nevron.Editors.NLengthEditorUC()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(6, 28)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(80, 15)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Alignment:"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LeftAxisAlignmentComboBox)
			Me.groupBox1.Controls.Add(Me.LeftAxisOffsetUC)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.ImageIndex = 0
			Me.groupBox1.Location = New System.Drawing.Point(7, 7)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(268, 100)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Left Axis"
			' 
			' LeftAxisOffsetUC
			' 
			Me.LeftAxisOffsetUC.Location = New System.Drawing.Point(5, 49)
			Me.LeftAxisOffsetUC.Name = "LeftAxisOffsetUC"
			Me.LeftAxisOffsetUC.Size = New System.Drawing.Size(256, 24)
			Me.LeftAxisOffsetUC.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftAxisOffsetUC.LengthChanged += new System.EventHandler(this.LeftAxisOffsetUC_LengthChanged);
			' 
			' LeftAxisAlignmentComboBox
			' 
			Me.LeftAxisAlignmentComboBox.Location = New System.Drawing.Point(89, 24)
			Me.LeftAxisAlignmentComboBox.Name = "LeftAxisAlignmentComboBox"
			Me.LeftAxisAlignmentComboBox.Size = New System.Drawing.Size(167, 22)
			Me.LeftAxisAlignmentComboBox.TabIndex = 1
			Me.LeftAxisAlignmentComboBox.Text = "nComboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LeftAxisAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.LeftAxisAlignmentComboBox_SelectedIndexChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.BottomAxisAlignmentComboBox)
			Me.nGroupBox1.Controls.Add(Me.BottomAxisOffsetUC)
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(6, 125)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(268, 100)
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Bottom Axis"
			' 
			' BottomAxisAlignmentComboBox
			' 
			Me.BottomAxisAlignmentComboBox.Location = New System.Drawing.Point(89, 24)
			Me.BottomAxisAlignmentComboBox.Name = "BottomAxisAlignmentComboBox"
			Me.BottomAxisAlignmentComboBox.Size = New System.Drawing.Size(167, 22)
			Me.BottomAxisAlignmentComboBox.TabIndex = 1
			Me.BottomAxisAlignmentComboBox.Text = "nComboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomAxisAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this.BottomAxisAlignmentComboBox_SelectedIndexChanged);
			' 
			' BottomAxisOffsetUC
			' 
			Me.BottomAxisOffsetUC.Location = New System.Drawing.Point(5, 48)
			Me.BottomAxisOffsetUC.Name = "BottomAxisOffsetUC"
			Me.BottomAxisOffsetUC.Size = New System.Drawing.Size(256, 24)
			Me.BottomAxisOffsetUC.TabIndex = 2
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BottomAxisOffsetUC.LengthChanged += new System.EventHandler(this.BottomAxisOffsetUC_LengthChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 32)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 15)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Alignment:"
			' 
			' NAxisModelCrossingUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NAxisModelCrossingUC"
			Me.Size = New System.Drawing.Size(276, 250)
			Me.groupBox1.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Axis Model Crossing <br/> <font size = '9pt'>Demonstrates how to use of the model cross anchor</font>")
			title.TextStyle.TextFormat = TextFormat.XML
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Center
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legends
			nChartControl1.Legends.Clear()

			m_Chart = nChartControl1.Charts(0)

			' configure scales
			Dim yScaleConfigurator As NLinearScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim yStripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			yStripStyle.SetShowAtWall(ChartWallType.Back, True)
			yStripStyle.Interlaced = True
			yScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			yScaleConfigurator.StripStyles.Add(yStripStyle)

			Dim xScaleConfigurator As New NLinearScaleConfigurator()
			Dim xStripStyle As New NScaleStripStyle(New NColorFillStyle(Color.FromArgb(40, Color.LightGray)), Nothing, True, 0, 0, 1, 1)
			xStripStyle.SetShowAtWall(ChartWallType.Back, True)
			xStripStyle.Interlaced = True
			xScaleConfigurator.StripStyles.Add(xStripStyle)
			xScaleConfigurator.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScaleConfigurator

			' cross X and Y axes
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor = New NCrossAxisAnchor(AxisOrientation.Horizontal, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryY), 0))
			m_Chart.Axis(StandardAxis.PrimaryX).Anchor.RulerOrientation = RulerOrientation.Right

			m_Chart.Axis(StandardAxis.PrimaryY).Anchor = New NCrossAxisAnchor(AxisOrientation.Vertical, New NValueAxisCrossing(m_Chart.Axis(StandardAxis.PrimaryX), 0))

			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Wall(ChartWallType.Floor).Visible = False
			m_Chart.Wall(ChartWallType.Left).Visible = False

			' setup bubble series
			Dim bubble As NBubbleSeries = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
			bubble.Name = "Bubble Series"
			bubble.InflateMargins = True
			bubble.DataLabelStyle.Visible = False
			bubble.UseXValues = True
			bubble.BubbleShape = PointShape.Sphere

			' fill with random data
			bubble.Values.FillRandomRange(Random, 10, -20, 20)
			bubble.XValues.FillRandomRange(Random, 10, -20, 20)
			bubble.Sizes.FillRandomRange(Random, 10, 1, 6)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			LeftAxisAlignmentComboBox.FillFromEnum(GetType(HorzAlign))
			LeftAxisAlignmentComboBox.SelectedIndex = CInt(HorzAlign.Center)
			LeftAxisOffsetUC.Length = New NLength(0, NRelativeUnit.ParentPercentage)

			BottomAxisAlignmentComboBox.FillFromEnum(GetType(VertAlign))
			BottomAxisAlignmentComboBox.SelectedIndex = CInt(HorzAlign.Center)
			BottomAxisOffsetUC.Length = New NLength(0, NRelativeUnit.ParentPercentage)

			m_Updating = False

			UpdateCrossings()
		End Sub

		Private Sub UpdateCrossings()
			If m_Updating Then
				Return
			End If

			Dim xAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryX)
			Dim yAxis As NAxis = m_Chart.Axis(StandardAxis.PrimaryY)

			Dim crossAnchor As NCrossAxisAnchor

			' update the x axis anchor
			crossAnchor = New NCrossAxisAnchor()
			xAxis.Anchor = crossAnchor
			crossAnchor.AxisOrientation = AxisOrientation.Horizontal
			crossAnchor.Crossings.Add(New NModelAxisCrossing(yAxis, CType(Me.BottomAxisAlignmentComboBox.SelectedIndex, HorzAlign), BottomAxisOffsetUC.Length))

			' update the y axis anchor
			crossAnchor = New NCrossAxisAnchor()
			crossAnchor.AxisOrientation = AxisOrientation.Vertical
			yAxis.Anchor = crossAnchor
			crossAnchor.Crossings.Add(New NModelAxisCrossing(xAxis, CType(Me.LeftAxisAlignmentComboBox.SelectedIndex, HorzAlign), LeftAxisOffsetUC.Length))

			nChartControl1.Refresh()
		End Sub

		Private Sub LeftAxisOffsetUC_LengthChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftAxisOffsetUC.LengthChanged
			UpdateCrossings()
		End Sub

		Private Sub BottomAxisOffsetUC_LengthChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomAxisOffsetUC.LengthChanged
			UpdateCrossings()
		End Sub

		Private Sub LeftAxisAlignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LeftAxisAlignmentComboBox.SelectedIndexChanged
			UpdateCrossings()
		End Sub

		Private Sub BottomAxisAlignmentComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BottomAxisAlignmentComboBox.SelectedIndexChanged
			UpdateCrossings()
		End Sub
	End Class
End Namespace