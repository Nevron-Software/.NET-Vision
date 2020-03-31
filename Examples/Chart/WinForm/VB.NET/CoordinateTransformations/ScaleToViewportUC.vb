Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class ScaleToViewportUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Point As NPointSeries
		Private m_bUpdateWatermark As Boolean

		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents XPositionNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents YPositionNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents ZPositionNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private WithEvents WatermarkPositionComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents DataPointNumericUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private ScaleUnitsGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private DataPointGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			m_bUpdateWatermark = False
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ScaleUnitsGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.ZPositionNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.YPositionNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.XPositionNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.WatermarkPositionComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.DataPointGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.DataPointNumericUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.ScaleUnitsGroupBox.SuspendLayout()
			DirectCast(Me.ZPositionNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.YPositionNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.XPositionNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.DataPointGroupBox.SuspendLayout()
			DirectCast(Me.DataPointNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(14, 21)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(33, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "X:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(14, 49)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(33, 23)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Y:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(14, 84)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(33, 16)
			Me.label4.TabIndex = 4
			Me.label4.Text = "Z:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' ScaleUnitsGroupBox
			' 
			Me.ScaleUnitsGroupBox.Controls.Add(Me.ZPositionNumericUpDown)
			Me.ScaleUnitsGroupBox.Controls.Add(Me.YPositionNumericUpDown)
			Me.ScaleUnitsGroupBox.Controls.Add(Me.XPositionNumericUpDown)
			Me.ScaleUnitsGroupBox.Controls.Add(Me.label4)
			Me.ScaleUnitsGroupBox.Controls.Add(Me.label3)
			Me.ScaleUnitsGroupBox.Controls.Add(Me.label2)
			Me.ScaleUnitsGroupBox.Location = New System.Drawing.Point(6, 64)
			Me.ScaleUnitsGroupBox.Name = "ScaleUnitsGroupBox"
			Me.ScaleUnitsGroupBox.Size = New System.Drawing.Size(169, 112)
			Me.ScaleUnitsGroupBox.TabIndex = 2
			Me.ScaleUnitsGroupBox.TabStop = False
			Me.ScaleUnitsGroupBox.Text = "Position in scale units"
			' 
			' ZPositionNumericUpDown
			' 
			Me.ZPositionNumericUpDown.Location = New System.Drawing.Point(46, 80)
			Me.ZPositionNumericUpDown.Name = "ZPositionNumericUpDown"
			Me.ZPositionNumericUpDown.Size = New System.Drawing.Size(113, 20)
			Me.ZPositionNumericUpDown.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ZPositionNumericUpDown.ValueChanged += new System.EventHandler(this.ZPositionNumericUpDown_ValueChanged);
			' 
			' YPositionNumericUpDown
			' 
			Me.YPositionNumericUpDown.Location = New System.Drawing.Point(46, 52)
			Me.YPositionNumericUpDown.Name = "YPositionNumericUpDown"
			Me.YPositionNumericUpDown.Size = New System.Drawing.Size(113, 20)
			Me.YPositionNumericUpDown.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.YPositionNumericUpDown.ValueChanged += new System.EventHandler(this.YPositionNumericUpDown_ValueChanged);
			' 
			' XPositionNumericUpDown
			' 
			Me.XPositionNumericUpDown.Location = New System.Drawing.Point(46, 24)
			Me.XPositionNumericUpDown.Name = "XPositionNumericUpDown"
			Me.XPositionNumericUpDown.Size = New System.Drawing.Size(113, 20)
			Me.XPositionNumericUpDown.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.XPositionNumericUpDown.ValueChanged += new System.EventHandler(this.XPositionNumericUpDown_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(129, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Watermark position:"
			' 
			' WatermarkPositionComboBox
			' 
			Me.WatermarkPositionComboBox.ListProperties.CheckBoxDataMember = ""
			Me.WatermarkPositionComboBox.ListProperties.DataSource = Nothing
			Me.WatermarkPositionComboBox.ListProperties.DisplayMember = ""
			Me.WatermarkPositionComboBox.Location = New System.Drawing.Point(6, 32)
			Me.WatermarkPositionComboBox.Name = "WatermarkPositionComboBox"
			Me.WatermarkPositionComboBox.Size = New System.Drawing.Size(169, 21)
			Me.WatermarkPositionComboBox.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WatermarkPositionComboBox.SelectedIndexChanged += new System.EventHandler(this.WatermarkPositionComboBox_SelectedIndexChanged);
			' 
			' DataPointGroupBox
			' 
			Me.DataPointGroupBox.Controls.Add(Me.DataPointNumericUpDown)
			Me.DataPointGroupBox.Location = New System.Drawing.Point(6, 184)
			Me.DataPointGroupBox.Name = "DataPointGroupBox"
			Me.DataPointGroupBox.Size = New System.Drawing.Size(169, 56)
			Me.DataPointGroupBox.TabIndex = 3
			Me.DataPointGroupBox.TabStop = False
			Me.DataPointGroupBox.Text = "At data point:"
			' 
			' DataPointNumericUpDown
			' 
			Me.DataPointNumericUpDown.Location = New System.Drawing.Point(2, 19)
			Me.DataPointNumericUpDown.Name = "DataPointNumericUpDown"
			Me.DataPointNumericUpDown.Size = New System.Drawing.Size(169, 20)
			Me.DataPointNumericUpDown.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DataPointNumericUpDown.ValueChanged += new System.EventHandler(this.DataPointNumericUpDown_ValueChanged);
			' 
			' ScaleToViewportUC
			' 
			Me.Controls.Add(Me.DataPointGroupBox)
			Me.Controls.Add(Me.WatermarkPositionComboBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.ScaleUnitsGroupBox)
			Me.Name = "ScaleToViewportUC"
			Me.Size = New System.Drawing.Size(180, 494)
			Me.ScaleUnitsGroupBox.ResumeLayout(False)
			DirectCast(Me.ZPositionNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.YPositionNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.XPositionNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.DataPointGroupBox.ResumeLayout(False)
			DirectCast(Me.DataPointNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Converting from scale to viewport coordinates")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create the watermark that we're about to position in the AfterPaint event of the chart
			Dim watermark As New NWatermark()
			Dim bitmap As Bitmap = GetWatermarkBitmap()

			watermark.FillStyle = New NImageFillStyle(bitmap)
			watermark.StandardFrameStyle.InnerBorderWidth = New NLength(0, NGraphicsUnit.Pixel)
			watermark.ContentAlignment = ContentAlignment.MiddleCenter

			nChartControl1.Panels.Add(watermark)

			' configure a free xyz point chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.BoundsMode = BoundsMode.Fit

			m_Chart.Location = New NPointL(New NLength(8, NRelativeUnit.ParentPercentage), New NLength(8, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(84, NRelativeUnit.ParentPercentage), New NLength(84, NRelativeUnit.ParentPercentage))

			m_Chart.Depth = 55.0F
			m_Chart.Width = 55.0F
			m_Chart.Height = 55.0F
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			Dim linearScale As New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			linearScale = New NLinearScaleConfigurator()
			m_Chart.Axis(StandardAxis.Depth).ScaleConfigurator = linearScale
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			nChartControl1.Controller.Selection.Add(m_Chart)

			m_Point = CType(m_Chart.Series.Add(SeriesType.Point), NPointSeries)
			m_Point.Name = "Point Series"
			m_Point.DataLabelStyle.Visible = False
			m_Point.Legend.Mode = SeriesLegendMode.DataPoints
			m_Point.Legend.Format = "<label>"
			m_Point.PointShape = PointShape.Sphere
			m_Point.FillStyle = New NColorFillStyle(Color.Red)
			m_Point.UseXValues = True
			m_Point.UseZValues = True

			' add xyz values
			m_Point.AddDataPoint(New NDataPoint(10, 15, 34, "Item1"))
			m_Point.AddDataPoint(New NDataPoint(23, 25, -20, "Item2"))
			m_Point.AddDataPoint(New NDataPoint(12, 45, 45, "Item3"))
			m_Point.AddDataPoint(New NDataPoint(24, 35, -12, "Item4"))
			m_Point.AddDataPoint(New NDataPoint(16, 41, 3, "Item5"))
			m_Point.AddDataPoint(New NDataPoint(17, 15, -34, "Item6"))
			m_Point.AddDataPoint(New NDataPoint(13, -25, -20, "Item7"))
			m_Point.AddDataPoint(New NDataPoint(12, 45, 1, "Item8"))
			m_Point.AddDataPoint(New NDataPoint(4, -21, -12, "Item9"))
			m_Point.AddDataPoint(New NDataPoint(16, -24, 47, "Item10"))

			m_Chart.PaintCallback = New CustomPaintCallback(Me)

			' init form controls
			DataPointNumericUpDown.Minimum = 0
			DataPointNumericUpDown.Maximum = m_Point.Values.Count - 1
			DataPointNumericUpDown.Value = 0

			WatermarkPositionComboBox.Items.Add("Position in scale Units")
			WatermarkPositionComboBox.Items.Add("Position from Data Point")
			WatermarkPositionComboBox.SelectedIndex = 1

			m_bUpdateWatermark = True

			nChartControl1.Refresh()
		End Sub

		Private Function GetPolygonPoints(ByVal rect As RectangleF) As PointF()
			Dim fX13 As Single = rect.X + (1.0F / 3.0F) * rect.Width
			Dim fX23 As Single = rect.X + (2.0F / 3.0F) * rect.Width
			Dim fY13 As Single = rect.Y + (1.0F / 3.0F) * rect.Height
			Dim fY23 As Single = rect.Y + (2.0F / 3.0F) * rect.Height

			Dim arr(11) As PointF
			arr(0) = New PointF(fX13, rect.Y)
			arr(1) = New PointF(fX23, rect.Y)
			arr(2) = New PointF(fX23, fY13)
			arr(3) = New PointF(rect.Right, fY13)
			arr(4) = New PointF(rect.Right, fY23)
			arr(5) = New PointF(fX23, fY23)
			arr(6) = New PointF(fX23, rect.Bottom)
			arr(7) = New PointF(fX13, rect.Bottom)
			arr(8) = New PointF(fX13, fY23)
			arr(9) = New PointF(rect.X, fY23)
			arr(10) = New PointF(rect.X, fY13)
			arr(11) = New PointF(fX13, fY13)

			Return arr
		End Function

		Private Function GetWatermarkBitmap() As Bitmap
			Dim bitmap As New Bitmap(41, 41, PixelFormat.Format32bppArgb)
			Dim graphics As Graphics = System.Drawing.Graphics.FromImage(bitmap)

			Dim solidBrush As Brush = New SolidBrush(Color.FromArgb(125, 255, 0, 0))
			graphics.FillPolygon(solidBrush, GetPolygonPoints(New RectangleF(0, 0, 40, 40)))

			solidBrush.Dispose()
			graphics.Dispose()

			Return bitmap
		End Function

		Private Sub WatermarkPositionComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WatermarkPositionComboBox.SelectedIndexChanged
			Dim bEnableScaleUnitsGroupBox As Boolean = (WatermarkPositionComboBox.SelectedIndex = 0)

			ScaleUnitsGroupBox.Enabled = bEnableScaleUnitsGroupBox
			DataPointGroupBox.Enabled = Not bEnableScaleUnitsGroupBox

			nChartControl1.Refresh()
		End Sub

		Private Sub DataPointNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataPointNumericUpDown.ValueChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub XPositionNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles XPositionNumericUpDown.ValueChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub YPositionNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles YPositionNumericUpDown.ValueChanged
			nChartControl1.Refresh()
		End Sub

		Private Sub ZPositionNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ZPositionNumericUpDown.ValueChanged
			nChartControl1.Refresh()
		End Sub

		Private Class CustomPaintCallback
			Inherits NPaintCallback

			Private m_Parent As ScaleToViewportUC

			Public Sub New(ByVal parentUserControl As ScaleToViewportUC)
				m_Parent = parentUserControl
			End Sub

			Public Overrides Sub OnAfterPaint(ByVal panel As NPanel, ByVal eventArgs As NPanelPaintEventArgs)
				If m_Parent.m_bUpdateWatermark = False Then
					Return
				End If

				' intercepts the on chart after paint event and converts
				' point or XYZ coordniates to chart viewport coordinates
				' used to position the custom watermark
				Dim chartControl As NChartControl = m_Parent.nChartControl1
				Dim watermark As NWatermark = chartControl.Watermarks(0)
				Dim chart As NChart = m_Parent.nChartControl1.Charts(0)

				Dim viewPoint As New NPointF()
				Dim vecModelPoint As New NVector3DF()

				Dim model3DToViewTransformation As New NModel3DToViewTransformation(chartControl.View.Context, chart.Projection)

				Select Case m_Parent.WatermarkPositionComboBox.SelectedIndex
					Case 0
						vecModelPoint.X = chart.Axis(StandardAxis.PrimaryX).TransformScaleToModel(False, CDbl(m_Parent.XPositionNumericUpDown.Value))
						vecModelPoint.Y = chart.Axis(StandardAxis.PrimaryY).TransformScaleToModel(False, CDbl(m_Parent.YPositionNumericUpDown.Value))
						vecModelPoint.Z = chart.Axis(StandardAxis.Depth).TransformScaleToModel(False, CDbl(m_Parent.ZPositionNumericUpDown.Value))
					Case 1
						Dim vecPoint As New NVector3DF()
						Dim nIndex As Integer = CInt(Math.Truncate(m_Parent.DataPointNumericUpDown.Value))

						vecPoint.X = CSng(DirectCast(m_Parent.m_Point.XValues(nIndex), Double))
						vecPoint.Y = CSng(DirectCast(m_Parent.m_Point.Values(nIndex), Double))
						vecPoint.Z = CSng(DirectCast(m_Parent.m_Point.ZValues(nIndex), Double))

						vecModelPoint.X = chart.Axis(StandardAxis.PrimaryX).TransformScaleToModel(False, vecPoint.X)
						vecModelPoint.Y = chart.Axis(StandardAxis.PrimaryY).TransformScaleToModel(False, vecPoint.Y)
						vecModelPoint.Z = chart.Axis(StandardAxis.Depth).TransformScaleToModel(False, vecPoint.Z)
				End Select

				model3DToViewTransformation.Transform(vecModelPoint, viewPoint)

				' convert the view point to parent pixel coordinates
				watermark.TransformViewPointToParent(viewPoint)

				watermark.Location = New NPointL(New NLength(viewPoint.X, NGraphicsUnit.Pixel), New NLength(viewPoint.Y, NGraphicsUnit.Pixel))

				m_Parent.nChartControl1.RecalcLayout()
			End Sub
		End Class
	End Class
End Namespace
