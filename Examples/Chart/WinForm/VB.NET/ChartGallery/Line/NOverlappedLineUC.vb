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
	Public Class NOverlappedLineUC
		Inherits NExampleBaseUC

		Private m_Line1 As NLineSeries
		Private m_Line2 As NLineSeries
		Private WithEvents Line1ColorButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents Line2ColorButton As Nevron.UI.WinForm.Controls.NButton
		Private colorDlg As Nevron.UI.WinForm.Controls.NColorDialog
		Private label5 As System.Windows.Forms.Label
		Private WithEvents LineStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents NewDataButton As Nevron.UI.WinForm.Controls.NButton
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(NOverlappedLineUC))
			Me.Line1ColorButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.Line2ColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.colorDlg = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.label5 = New System.Windows.Forms.Label()
			Me.LineStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.NewDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' Line1ColorButton1
			' 
			Me.Line1ColorButton1.Location = New System.Drawing.Point(9, 63)
			Me.Line1ColorButton1.Name = "Line1ColorButton1"
			Me.Line1ColorButton1.Size = New System.Drawing.Size(162, 24)
			Me.Line1ColorButton1.TabIndex = 0
			Me.Line1ColorButton1.Text = "Line 1 Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Line1ColorButton1.Click += new System.EventHandler(this.Line1ColorButton1_Click);
			' 
			' Line2ColorButton
			' 
			Me.Line2ColorButton.Location = New System.Drawing.Point(9, 94)
			Me.Line2ColorButton.Name = "Line2ColorButton"
			Me.Line2ColorButton.Size = New System.Drawing.Size(162, 24)
			Me.Line2ColorButton.TabIndex = 1
			Me.Line2ColorButton.Text = "Line 2 Color"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Line2ColorButton.Click += new System.EventHandler(this.Line2ColorButton_Click);
			' 
			' colorDlg
			' 
			Me.colorDlg.ClientSize = New System.Drawing.Size(413, 351)
			Me.colorDlg.Color = System.Drawing.Color.Empty
			Me.colorDlg.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.colorDlg.Icon = (DirectCast(resources.GetObject("colorDlg.Icon"), System.Drawing.Icon))
			Me.colorDlg.Location = New System.Drawing.Point(176, 184)
			Me.colorDlg.MaximizeBox = False
			Me.colorDlg.MinimizeBox = False
			Me.colorDlg.Name = "colorDlg"
			Me.colorDlg.ShowCaptionImage = False
			Me.colorDlg.ShowInTaskbar = False
			Me.colorDlg.Sizable = False
			Me.colorDlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.colorDlg.Text = "Edit Color"
			Me.colorDlg.Visible = False
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(9, 6)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(162, 16)
			Me.label5.TabIndex = 13
			Me.label5.Text = "Line Style:"
			' 
			' LineStyleCombo
			' 
			Me.LineStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.LineStyleCombo.ListProperties.DataSource = Nothing
			Me.LineStyleCombo.ListProperties.DisplayMember = ""
			Me.LineStyleCombo.Location = New System.Drawing.Point(9, 24)
			Me.LineStyleCombo.Name = "LineStyleCombo"
			Me.LineStyleCombo.Size = New System.Drawing.Size(162, 21)
			Me.LineStyleCombo.TabIndex = 12
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LineStyleCombo.SelectedIndexChanged += new System.EventHandler(this.LineStyleCombo_SelectedIndexChanged);
			' 
			' NewDataButton
			' 
			Me.NewDataButton.Location = New System.Drawing.Point(9, 148)
			Me.NewDataButton.Name = "NewDataButton"
			Me.NewDataButton.Size = New System.Drawing.Size(162, 24)
			Me.NewDataButton.TabIndex = 14
			Me.NewDataButton.Text = "New Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.NewDataButton.Click += new System.EventHandler(this.NewDataButton_Click);
			' 
			' NOverlappedLineUC
			' 
			Me.Controls.Add(Me.NewDataButton)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.LineStyleCombo)
			Me.Controls.Add(Me.Line2ColorButton)
			Me.Controls.Add(Me.Line1ColorButton1)
			Me.Name = "NOverlappedLineUC"
			Me.Size = New System.Drawing.Size(180, 179)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Overlapped Line Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			Dim chart As NChart = nChartControl1.Charts(0)
			chart.Enable3D = True
			chart.Width = 65
			chart.Height = 40
			chart.Axis(StandardAxis.Depth).Visible = False
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.GlitterLeft)

			' add interlaced stripe to the Y axis
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			stripStyle.Interlaced = True
			CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator).StripStyles.Add(stripStyle)

			m_Line1 = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line1.Name = "Line 1"
			m_Line1.DataLabelStyle.Visible = False

			m_Line2 = CType(chart.Series.Add(SeriesType.Line), NLineSeries)
			m_Line2.Name = "Line 2"
			m_Line2.MultiLineMode = MultiLineMode.Overlapped
			m_Line2.DataLabelStyle.Visible = False

			GenerateData()

			' apply layout
			ConfigureStandardLayout(chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' form controls
			LineStyleCombo.FillFromEnum(GetType(LineSegmentShape))
			LineStyleCombo.SelectedIndex = 1
		End Sub


		Private Sub Line1ColorButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Line1ColorButton1.Click
			colorDlg.Color = m_Line1.BorderStyle.Color

			If colorDlg.ShowDialog() = DialogResult.Cancel Then
				Return
			End If

			m_Line1.BorderStyle.Color = colorDlg.Color
			m_Line1.FillStyle = New NColorFillStyle(colorDlg.Color)
			m_Line1.MarkerStyle.FillStyle = New NColorFillStyle(colorDlg.Color)
			m_Line1.MarkerStyle.BorderStyle.Color = colorDlg.Color

			nChartControl1.Refresh()
		End Sub

		Private Sub Line2ColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Line2ColorButton.Click
			colorDlg.Color = m_Line2.BorderStyle.Color

			If colorDlg.ShowDialog() = DialogResult.Cancel Then
				Return
			End If

			m_Line2.BorderStyle.Color = colorDlg.Color
			m_Line2.FillStyle = New NColorFillStyle(colorDlg.Color)
			m_Line2.MarkerStyle.FillStyle = New NColorFillStyle(colorDlg.Color)
			m_Line2.MarkerStyle.BorderStyle.Color = colorDlg.Color

			nChartControl1.Refresh()
		End Sub

		Private Sub LineStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LineStyleCombo.SelectedIndexChanged
			Dim style As LineSegmentShape = CType(LineStyleCombo.SelectedIndex, LineSegmentShape)

			m_Line1.LineSegmentShape = style
			m_Line2.LineSegmentShape = style

			Select Case style
				Case LineSegmentShape.Line, LineSegmentShape.Tape
					m_Line1.MarkerStyle.PointShape = PointShape.Cylinder
					m_Line2.MarkerStyle.PointShape = PointShape.Cylinder
					m_Line1.MarkerStyle.Visible = True
					m_Line2.MarkerStyle.Visible = True
					m_Line1.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
					m_Line2.MarkerStyle.Width = New NLength(1.5F, NRelativeUnit.ParentPercentage)
					m_Line1.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
					m_Line2.MarkerStyle.Height = New NLength(1.5F, NRelativeUnit.ParentPercentage)
					m_Line1.DepthPercent = 50
					m_Line2.DepthPercent = 50

				Case LineSegmentShape.Tube, LineSegmentShape.Ellipsoid
					m_Line1.MarkerStyle.PointShape = PointShape.Sphere
					m_Line2.MarkerStyle.PointShape = PointShape.Sphere
					m_Line1.MarkerStyle.Visible = True
					m_Line2.MarkerStyle.Visible = True
					m_Line1.MarkerStyle.Width = New NLength(2.5F, NRelativeUnit.ParentPercentage)
					m_Line2.MarkerStyle.Width = New NLength(2.5F, NRelativeUnit.ParentPercentage)
					m_Line1.MarkerStyle.Height = New NLength(2.5F, NRelativeUnit.ParentPercentage)
					m_Line2.MarkerStyle.Height = New NLength(2.5F, NRelativeUnit.ParentPercentage)
					m_Line1.DepthPercent = 10
					m_Line2.DepthPercent = 10
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub NewDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewDataButton.Click
			GenerateData()
			nChartControl1.Refresh()
		End Sub

		Private Sub GenerateData()
			m_Line1.Values.Clear()
			m_Line2.Values.Clear()

			For i As Integer = 0 To 8
				m_Line1.Values.Add(Math.Sin(0.6 * i) + 0.5 * Random.NextDouble())
				m_Line2.Values.Add(Math.Cos(0.6 * i) + 0.5 * Random.NextDouble())
			Next i
		End Sub
	End Class
End Namespace