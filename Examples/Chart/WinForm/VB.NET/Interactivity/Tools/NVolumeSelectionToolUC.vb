Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVolumeSelectionToolUC
		Inherits NExampleBaseUC

		Private WithEvents ActiveToolComboBox As UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
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
			Me.ActiveToolComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' ActiveToolComboBox
			' 
			Me.ActiveToolComboBox.ListProperties.CheckBoxDataMember = ""
			Me.ActiveToolComboBox.ListProperties.DataSource = Nothing
			Me.ActiveToolComboBox.ListProperties.DisplayMember = ""
			Me.ActiveToolComboBox.Location = New System.Drawing.Point(2, 27)
			Me.ActiveToolComboBox.Name = "ActiveToolComboBox"
			Me.ActiveToolComboBox.Size = New System.Drawing.Size(157, 21)
			Me.ActiveToolComboBox.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ActiveToolComboBox.SelectedIndexChanged += new System.EventHandler(this.ActiveToolComboBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(2, 7)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 16)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Active Tool:"
			' 
			' NVolumeSelectionToolUC
			' 
			Me.Controls.Add(Me.ActiveToolComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "NVolumeSelectionToolUC"
			Me.Size = New System.Drawing.Size(180, 664)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As New NLabel("Volume Selection Tool")
			title.DockMode = PanelDockMode.Top
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))
			nChartControl1.Panels.Add(title)

			Dim chart As NChart = nChartControl1.Charts(0)

			chart.Enable3D = True
			chart.BoundsMode = BoundsMode.Fit
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			chart.Axis(StandardAxis.Depth).ScaleConfigurator = New NLinearScaleConfigurator()
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: chart.Width = chart.Height = chart.Depth = 50;
			chart.Depth = 50
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: chart.Width = chart.Height = chart.Depth
			chart.Height = chart.Depth
			chart.Width = chart.Height
			chart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)

			Dim point As New NPointSeries()
			point.UseXValues = True
			point.UseZValues = True
			point.DataLabelStyle.Visible = False
			point.InflateMargins = True

			Dim rand As New Random()

			For i As Integer = 0 To 99
				point.Values.Add(rand.Next(100))
				point.XValues.Add(rand.Next(100))
				point.ZValues.Add(rand.Next(100))
			Next i

			chart.Series.Add(point)

			ActiveToolComboBox.Items.Add("Trackball")
			ActiveToolComboBox.Items.Add("Volume Selector")
			ActiveToolComboBox.SelectedIndex = 1
		End Sub

		Private Sub ActiveToolComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ActiveToolComboBox.SelectedIndexChanged
			nChartControl1.Controller.Selection.SelectedObjects.Clear()
			nChartControl1.Controller.Tools.Clear()

			Select Case ActiveToolComboBox.SelectedIndex
				Case 0
					nChartControl1.Controller.Selection.SelectedObjects.Add(nChartControl1.Charts(0))
					nChartControl1.Controller.Tools.Add(New NTrackballTool())
				Case 1
					Dim volumeSelectionTool As New NVolumeSelectorTool()
					AddHandler volumeSelectionTool.EndDrag, AddressOf VolumeSelectionTool_EndDrag
					nChartControl1.Controller.Tools.Add(volumeSelectionTool)
			End Select
		End Sub

		Private Sub VolumeSelectionTool_EndDrag(ByVal sender As Object, ByVal e As EventArgs)
			Dim point As NPointSeries = CType(nChartControl1.Charts(0).Series(0), NPointSeries)
			Dim volumeTool As NVolumeSelectorTool = DirectCast(sender, NVolumeSelectorTool)
			For i As Integer = 0 To point.Values.Count - 1
				Dim vec As New NVector3DD(CSng(DirectCast(point.XValues(i), Double)), CSng(DirectCast(point.Values(i), Double)), CSng(DirectCast(point.ZValues(i), Double)))
				If volumeTool.TopPlane.Distance(vec) < 0 AndAlso volumeTool.RightPlane.Distance(vec) < 0 AndAlso volumeTool.BottomPlane.Distance(vec) < 0 AndAlso volumeTool.LeftPlane.Distance(vec) < 0 Then
					' point is contained in the set
					point.FillStyles(i) = New NColorFillStyle(Color.Red)
				End If
			Next i

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
