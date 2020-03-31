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
Imports Nevron.Dom
Imports Nevron.Chart.WinForm
Imports System.Collections.Generic
Imports Nevron.Chart.Windows


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NAnnotationDragToolUC
		Inherits NExampleBaseUC

		Private components As System.ComponentModel.Container = Nothing
		Private m_Callout1 As NRectangularCallout
		Private WithEvents AllowDragAnnotation1CheckBox As UI.WinForm.Controls.NCheckBox
		Private WithEvents AllowDragAnnotation2CheckBox As UI.WinForm.Controls.NCheckBox
		Private m_Callout2 As NRectangularCallout

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
			Me.AllowDragAnnotation1CheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.AllowDragAnnotation2CheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' AllowDragAnnotation1CheckBox
			' 
			Me.AllowDragAnnotation1CheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowDragAnnotation1CheckBox.Location = New System.Drawing.Point(3, 0)
			Me.AllowDragAnnotation1CheckBox.Name = "AllowDragAnnotation1CheckBox"
			Me.AllowDragAnnotation1CheckBox.Size = New System.Drawing.Size(152, 24)
			Me.AllowDragAnnotation1CheckBox.TabIndex = 12
			Me.AllowDragAnnotation1CheckBox.Text = "Allow Drag Annotation 1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowDragAnnotation1CheckBox.CheckedChanged += new System.EventHandler(this.AllowDragAnnotation1CheckBox_CheckedChanged);
			' 
			' AllowDragAnnotation2CheckBox
			' 
			Me.AllowDragAnnotation2CheckBox.ButtonProperties.BorderOffset = 2
			Me.AllowDragAnnotation2CheckBox.Location = New System.Drawing.Point(3, 30)
			Me.AllowDragAnnotation2CheckBox.Name = "AllowDragAnnotation2CheckBox"
			Me.AllowDragAnnotation2CheckBox.Size = New System.Drawing.Size(152, 24)
			Me.AllowDragAnnotation2CheckBox.TabIndex = 13
			Me.AllowDragAnnotation2CheckBox.Text = "Allow Drag Annotation 2"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.AllowDragAnnotation2CheckBox.CheckedChanged += new System.EventHandler(this.AllowDragAnnotation2CheckBox_CheckedChanged);
			' 
			' NAnnotationDragToolUC
			' 
			Me.Controls.Add(Me.AllowDragAnnotation2CheckBox)
			Me.Controls.Add(Me.AllowDragAnnotation1CheckBox)
			Me.Name = "NAnnotationDragToolUC"
			Me.Size = New System.Drawing.Size(180, 358)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Annotation Drag Tool")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' no legend
			nChartControl1.Legends.Clear()

			' setup chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.BoundsMode = BoundsMode.Stretch

			' configure the x scale
			Dim xScale As New NLinearScaleConfigurator()
			xScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = xScale

			' configure the y scale
			Dim yScale As New NLinearScaleConfigurator()

			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			yScale.StripStyles.Add(stripStyle)

			yScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = yScale

			' Create a point series
			Dim point As NPointSeries = CType(chart.Series.Add(SeriesType.Point), NPointSeries)
			point.InflateMargins = True
			point.UseXValues = True
			point.Name = "Series 1"
			point.DataLabelStyle.Visible = False

			' Add some data
			point.Values.Add(31)
			point.Values.Add(67)
			point.Values.Add(12)
			point.Values.Add(84)
			point.Values.Add(90)

			point.XValues.Add(5)
			point.XValues.Add(36)
			point.XValues.Add(51)
			point.XValues.Add(76)
			point.XValues.Add(93)

			m_Callout1 = New NRectangularCallout()
			m_Callout1.UseAutomaticSize = True
			m_Callout1.Text = "Annotation 1"
			m_Callout1.Orientation = 125
			m_Callout1.ArrowLength = New NLength(40, NGraphicsUnit.Point)
			m_Callout1.Anchor = New NScalePointAnchor(chart, CInt(StandardAxis.PrimaryX), CInt(StandardAxis.PrimaryY), CInt(StandardAxis.Depth), AxisValueAnchorMode.Clip, New Nevron.GraphicsCore.NVector3DD(36, 67, 0))
			chart.ChildPanels.Add(m_Callout1)

			m_Callout2 = New NRectangularCallout()
			m_Callout2.UseAutomaticSize = True
			m_Callout2.Text = "Annotation 2"
			m_Callout1.Orientation = 45
			m_Callout2.ArrowLength = New NLength(40, NGraphicsUnit.Point)
			m_Callout2.Anchor = New NScalePointAnchor(chart, CInt(StandardAxis.PrimaryX), CInt(StandardAxis.PrimaryY), CInt(StandardAxis.Depth), AxisValueAnchorMode.Clip, New Nevron.GraphicsCore.NVector3DD(76, 84, 0))
			chart.ChildPanels.Add(m_Callout2)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			nChartControl1.Controller.Tools.Add(New NSelectorTool())
			nChartControl1.Controller.Tools.Add(New NCalloutDragTool())

			AllowDragAnnotation1CheckBox.Checked = True
			AllowDragAnnotation2CheckBox.Checked = True
		End Sub

		Private Sub AllowDragAnnotation1CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowDragAnnotation1CheckBox.CheckedChanged
			m_Callout1.AllowDragging = AllowDragAnnotation1CheckBox.Checked
		End Sub

		Private Sub AllowDragAnnotation2CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles AllowDragAnnotation2CheckBox.CheckedChanged
			m_Callout2.AllowDragging = AllowDragAnnotation2CheckBox.Checked
		End Sub
	End Class
End Namespace
