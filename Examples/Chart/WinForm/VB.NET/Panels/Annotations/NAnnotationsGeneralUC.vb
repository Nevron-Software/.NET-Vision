Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports Nevron.Chart
Imports Nevron.Chart.Functions
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAnnotationsGeneralUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Legend As NLegend
		Private m_Bar As NBarSeries
		Private m_Line As NLineSeries
		Private m_RectangularCallout As NRectangularCallout
		Private m_RoundedRectangularCallout As NRoundedRectangularCallout
		Private m_CutEdgeRectangularCallout As NCutEdgeRectangularCallout
		Private m_OvalCallout As NOvalCallout
		Private m_ArrowAnnotation As NArrowAnnotation

		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents CurrentAnnotationComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents AnnotationPropertyGrid As System.Windows.Forms.PropertyGrid
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
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.AnnotationPropertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.label2 = New System.Windows.Forms.Label()
			Me.CurrentAnnotationComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.AnnotationPropertyGrid)
			Me.groupBox1.Location = New System.Drawing.Point(8, 64)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(296, 496)
			Me.groupBox1.TabIndex = 2
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Annotation properties"
			' 
			' AnnotationPropertyGrid
			' 
			Me.AnnotationPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.AnnotationPropertyGrid.Location = New System.Drawing.Point(8, 16)
			Me.AnnotationPropertyGrid.Name = "AnnotationPropertyGrid"
			Me.AnnotationPropertyGrid.Size = New System.Drawing.Size(280, 472)
			Me.AnnotationPropertyGrid.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AnnotationPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.AnnotationPropertyGrid_PropertyValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(128, 16)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Current annotation:"
			' 
			' CurrentAnnotationComboBox
			' 
			Me.CurrentAnnotationComboBox.ListProperties.CheckBoxDataMember = ""
			Me.CurrentAnnotationComboBox.ListProperties.DataSource = Nothing
			Me.CurrentAnnotationComboBox.ListProperties.DisplayMember = ""
			Me.CurrentAnnotationComboBox.Location = New System.Drawing.Point(8, 32)
			Me.CurrentAnnotationComboBox.Name = "CurrentAnnotationComboBox"
			Me.CurrentAnnotationComboBox.Size = New System.Drawing.Size(296, 21)
			Me.CurrentAnnotationComboBox.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.CurrentAnnotationComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrentAnnotationComboBox_SelectedIndexChanged);
			' 
			' NAnnotationsGeneralUC
			' 
			Me.Controls.Add(Me.CurrentAnnotationComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.groupBox1)
			Me.Name = "NAnnotationsGeneralUC"
			Me.Size = New System.Drawing.Size(312, 658)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			ConfigureChart()
			ConfigureAnnotations()

			CurrentAnnotationComboBox.Items.Add("RectangularCallout")
			CurrentAnnotationComboBox.Items.Add("RoundedRectangularCallout")
			CurrentAnnotationComboBox.Items.Add("CutEdgeRectangularCallout")
			CurrentAnnotationComboBox.Items.Add("OvalCallout")
			CurrentAnnotationComboBox.Items.Add("ArrowAnnotation")
			CurrentAnnotationComboBox.SelectedIndex = 0
		End Sub

		Private Sub ConfigureChart()
			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Annotations")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.TextStyle.TextFormat = TextFormat.XML
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			m_Legend = nChartControl1.Legends(0)

			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			' add the line series
			m_Line = CType(m_Chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line.Name = "Cumulative"
			m_Line.DataLabelStyle.Visible = False
			m_Line.MarkerStyle.Visible = True
			m_Line.MarkerStyle.PointShape = PointShape.Cylinder
			m_Line.MarkerStyle.FillStyle = New NColorFillStyle(Color.LimeGreen)
			m_Line.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
			m_Line.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Line.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			m_Line.ShadowStyle.Offset = New NPointL(2, 2)
			m_Line.ShadowStyle.FadeLength = New NLength(4)

			' add the bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Name = "Bar Series"
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
			m_Bar.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant2, Color.DarkBlue, Color.CornflowerBlue)
			m_Bar.ShadowStyle.Type = ShadowType.GaussianBlur
			m_Bar.ShadowStyle.Color = Color.FromArgb(80, 0, 0, 0)
			m_Bar.ShadowStyle.Offset = New NPointL(3, 3)
			m_Bar.ShadowStyle.FadeLength = New NLength(4)

			' fill with random data and sort in descending order
			m_Bar.Values.FillRandom(Random, 10)
			m_Bar.Values.Sort(DataSeriesSortOrder.Descending)

			' generate a data series cumulative sum of the bar values
			Dim fc As New NFunctionCalculator()
			fc.Expression = "CUMSUM(Value)"
			fc.Arguments.Add(m_Bar.Values)
			m_Line.Values = fc.Calculate()
		End Sub
		Private Function GetTextForAnnotation(ByVal annotation As NAnchorPanel) As String
			Dim sText As String = ""

			If TypeOf annotation Is NRectangularCallout Then
				sText = "This is a rectangular callout panel " & ControlChars.CrLf
			ElseIf TypeOf annotation Is NRoundedRectangularCallout Then
				sText = "This is a rounded rectangular callout panel " & ControlChars.CrLf
			ElseIf TypeOf annotation Is NCutEdgeRectangularCallout Then
				sText = "This is a cut edge rectangular callout panel " & ControlChars.CrLf
			ElseIf TypeOf annotation Is NOvalCallout Then
				sText = "This is an oval callout panel " & ControlChars.CrLf
			ElseIf TypeOf annotation Is NArrowAnnotation Then
				sText = "This is an arrow annotation " & ControlChars.CrLf
			ElseIf TypeOf annotation Is NArrowCallout Then
				sText = "This is an arrow callout"
			Else
				Debug.Assert(False)
			End If

			Return sText & GetTextForAnchor(annotation.Anchor)
		End Function
		Private Function GetTextForAnchor(ByVal anchor As NAnchor) As String
			Dim sText As String = "attached to "

			If TypeOf anchor Is NAxisValueAnchor Then
				sText &= "an axis value."
			ElseIf TypeOf anchor Is NDataPointAnchor Then
				sText &= "a chart data point."
			ElseIf TypeOf anchor Is NLegendDataItemAnchor Then
				sText &= "a legend data point."
			ElseIf TypeOf anchor Is NModelPointAnchor Then
				sText &= "a model point."
			ElseIf TypeOf anchor Is NScalePointAnchor Then
				sText &= "a scale point."
			Else
				Debug.Assert(False)
			End If

			Return sText
		End Function
		Private Sub ConfigureAnnotations()
			m_RectangularCallout = New NRectangularCallout()
			m_RectangularCallout.ArrowLength = New NLength(15, NRelativeUnit.ParentPercentage)
			m_RectangularCallout.FillStyle = New NGradientFillStyle(Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.CadetBlue))
			m_RectangularCallout.UseAutomaticSize = True
			m_RectangularCallout.Orientation = 225
			m_RectangularCallout.Anchor = New NDataPointAnchor(m_Bar, 2, ContentAlignment.MiddleCenter, StringAlignment.Center)
			m_RectangularCallout.Text = GetTextForAnnotation(m_RectangularCallout)
			nChartControl1.Panels.Add(m_RectangularCallout)

			m_RoundedRectangularCallout = New NRoundedRectangularCallout()
			m_RoundedRectangularCallout.ArrowLength = New NLength(15, NRelativeUnit.ParentPercentage)
			m_RoundedRectangularCallout.FillStyle = New NGradientFillStyle(Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightGreen))
			m_RoundedRectangularCallout.UseAutomaticSize = True
			m_RoundedRectangularCallout.Orientation = 135
			m_RoundedRectangularCallout.Anchor = New NModelPointAnchor(m_Chart, New NVector3DF(0, 0, 0))
			m_RoundedRectangularCallout.Text = GetTextForAnnotation(m_RoundedRectangularCallout)
			nChartControl1.Panels.Add(m_RoundedRectangularCallout)

			m_CutEdgeRectangularCallout = New NCutEdgeRectangularCallout()
			m_CutEdgeRectangularCallout.FillStyle = New NGradientFillStyle(Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.LightBlue))
			m_CutEdgeRectangularCallout.ArrowLength = New NLength(40, NRelativeUnit.ParentPercentage)
			m_CutEdgeRectangularCallout.UseAutomaticSize = True
			m_CutEdgeRectangularCallout.Orientation = 190
			m_CutEdgeRectangularCallout.Anchor = New NLegendDataItemAnchor(m_Legend, 1)
			m_CutEdgeRectangularCallout.Text = GetTextForAnnotation(m_CutEdgeRectangularCallout)
			nChartControl1.Panels.Add(m_CutEdgeRectangularCallout)

			m_OvalCallout = New NOvalCallout()
			m_OvalCallout.FillStyle = New NColorFillStyle(Color.FromArgb(200, Color.AliceBlue))
			m_OvalCallout.ArrowLength = New NLength(15, NRelativeUnit.ParentPercentage)
			m_OvalCallout.UseAutomaticSize = True
			m_OvalCallout.Orientation = 315
			m_OvalCallout.Anchor = New NScalePointAnchor(m_Chart, CInt(StandardAxis.PrimaryX), CInt(StandardAxis.PrimaryY), CInt(StandardAxis.Depth), AxisValueAnchorMode.Clip, New NVector3DD(7, 100, 0))

			m_OvalCallout.Text = GetTextForAnnotation(m_OvalCallout)
			nChartControl1.Panels.Add(m_OvalCallout)

			m_ArrowAnnotation = New NArrowAnnotation()
			m_ArrowAnnotation.UseAutomaticSize = True
			m_ArrowAnnotation.ArrowHeadWidthPercent = 30
			m_ArrowAnnotation.TextStyle.FontStyle.EmSize = New NLength(11, NGraphicsUnit.Point)
			m_ArrowAnnotation.TextStyle.FontStyle.Style = m_ArrowAnnotation.TextStyle.FontStyle.Style Or FontStyle.Bold
			m_ArrowAnnotation.Orientation = 45
			m_ArrowAnnotation.FillStyle = New NGradientFillStyle(GradientStyle.Vertical, GradientVariant.Variant1, Color.FromArgb(125, Color.White), Color.FromArgb(125, Color.Orange))
			m_ArrowAnnotation.Anchor = New NDataPointAnchor(m_Bar, 4, ContentAlignment.MiddleCenter, StringAlignment.Center)
			m_ArrowAnnotation.Text = GetTextForAnnotation(m_ArrowAnnotation)
			nChartControl1.Panels.Add(m_ArrowAnnotation)

			nChartControl1.Controller.Selection.Clear()
			nChartControl1.Controller.Selection.Add(m_Chart)

			nChartControl1.Controller.Tools.Add(New NTrackballTool())
		End Sub

		Private Sub CurrentAnnotationComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrentAnnotationComboBox.SelectedIndexChanged
			Select Case CurrentAnnotationComboBox.SelectedIndex
				Case 0 ' RectangularCallout
					AnnotationPropertyGrid.SelectedObject = m_RectangularCallout
				Case 1 ' RoundedRectangularCallout
					AnnotationPropertyGrid.SelectedObject = m_RoundedRectangularCallout
				Case 2 ' CutEdgeRectangularCallout
					AnnotationPropertyGrid.SelectedObject = m_CutEdgeRectangularCallout
				Case 3 ' OvalCallout
					AnnotationPropertyGrid.SelectedObject = m_OvalCallout
				Case 4 ' ArrowAnnotation
					AnnotationPropertyGrid.SelectedObject = m_ArrowAnnotation
			End Select
		End Sub
		Private Sub AnnotationPropertyGrid_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles AnnotationPropertyGrid.PropertyValueChanged
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
