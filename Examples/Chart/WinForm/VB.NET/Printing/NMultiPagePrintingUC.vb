Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NMultiPagePrintingUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_FloatBar As NFloatBarSeries
		Private m_Updating As Boolean
		Private m_PrintManager As NPrintManager

		Private label1 As System.Windows.Forms.Label
		Private WithEvents PrintPreviewButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PrintButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private WithEvents VerticalPageSizeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents HorizontalPageSizeComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents EnableHorizontalPagingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents EnableVerticalPagingCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

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
			Me.label1 = New System.Windows.Forms.Label()
			Me.PrintPreviewButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.PrintButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.HorizontalPageSizeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.VerticalPageSizeComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.EnableHorizontalPagingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.EnableVerticalPagingCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(6, 40)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(168, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Horizontal page size:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' PrintPreviewButton
			' 
			Me.PrintPreviewButton.Location = New System.Drawing.Point(6, 240)
			Me.PrintPreviewButton.Name = "PrintPreviewButton"
			Me.PrintPreviewButton.Size = New System.Drawing.Size(168, 23)
			Me.PrintPreviewButton.TabIndex = 6
			Me.PrintPreviewButton.Text = "Print Preview..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
			' 
			' PrintButton
			' 
			Me.PrintButton.Location = New System.Drawing.Point(6, 272)
			Me.PrintButton.Name = "PrintButton"
			Me.PrintButton.Size = New System.Drawing.Size(168, 23)
			Me.PrintButton.TabIndex = 7
			Me.PrintButton.Text = "Print"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
			' 
			' HorizontalPageSizeComboBox
			' 
			Me.HorizontalPageSizeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.HorizontalPageSizeComboBox.ListProperties.DataSource = Nothing
			Me.HorizontalPageSizeComboBox.ListProperties.DisplayMember = ""
			Me.HorizontalPageSizeComboBox.Location = New System.Drawing.Point(6, 56)
			Me.HorizontalPageSizeComboBox.Name = "HorizontalPageSizeComboBox"
			Me.HorizontalPageSizeComboBox.Size = New System.Drawing.Size(168, 21)
			Me.HorizontalPageSizeComboBox.TabIndex = 2
			Me.HorizontalPageSizeComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.HorizontalPageSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.HorizontalPageSizeComboBox_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(6, 123)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(168, 16)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Vertical page size:"
			' 
			' VerticalPageSizeComboBox
			' 
			Me.VerticalPageSizeComboBox.ListProperties.CheckBoxDataMember = ""
			Me.VerticalPageSizeComboBox.ListProperties.DataSource = Nothing
			Me.VerticalPageSizeComboBox.ListProperties.DisplayMember = ""
			Me.VerticalPageSizeComboBox.Location = New System.Drawing.Point(6, 139)
			Me.VerticalPageSizeComboBox.Name = "VerticalPageSizeComboBox"
			Me.VerticalPageSizeComboBox.Size = New System.Drawing.Size(168, 21)
			Me.VerticalPageSizeComboBox.TabIndex = 5
			Me.VerticalPageSizeComboBox.Text = "comboBox1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.VerticalPageSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.VerticalPageSizeComboBox_SelectedIndexChanged);
			' 
			' EnableHorizontalPagingCheckBox
			' 
			Me.EnableHorizontalPagingCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableHorizontalPagingCheckBox.Location = New System.Drawing.Point(6, 16)
			Me.EnableHorizontalPagingCheckBox.Name = "EnableHorizontalPagingCheckBox"
			Me.EnableHorizontalPagingCheckBox.Size = New System.Drawing.Size(168, 24)
			Me.EnableHorizontalPagingCheckBox.TabIndex = 0
			Me.EnableHorizontalPagingCheckBox.Text = "Enable horizontal paging"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableHorizontalPagingCheckBox.CheckedChanged += new System.EventHandler(this.EnableHorizontalPagingCheckBox_CheckedChanged);
			' 
			' EnableVerticalPagingCheckBox
			' 
			Me.EnableVerticalPagingCheckBox.ButtonProperties.BorderOffset = 2
			Me.EnableVerticalPagingCheckBox.Location = New System.Drawing.Point(6, 99)
			Me.EnableVerticalPagingCheckBox.Name = "EnableVerticalPagingCheckBox"
			Me.EnableVerticalPagingCheckBox.Size = New System.Drawing.Size(168, 24)
			Me.EnableVerticalPagingCheckBox.TabIndex = 3
			Me.EnableVerticalPagingCheckBox.Text = "Enable vertical paging"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EnableVerticalPagingCheckBox.CheckedChanged += new System.EventHandler(this.EnableVerticalPagingCheckBox_CheckedChanged);
			' 
			' NMultiPagePrintingUC
			' 
			Me.Controls.Add(Me.EnableVerticalPagingCheckBox)
			Me.Controls.Add(Me.EnableHorizontalPagingCheckBox)
			Me.Controls.Add(Me.VerticalPageSizeComboBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.HorizontalPageSizeComboBox)
			Me.Controls.Add(Me.PrintButton)
			Me.Controls.Add(Me.PrintPreviewButton)
			Me.Controls.Add(Me.label1)
			Me.Name = "NMultiPagePrintingUC"
			Me.Size = New System.Drawing.Size(180, 304)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub InitChart()
			m_Chart = nChartControl1.Charts(0)

			nChartControl1.Controller.Selection.Add(m_Chart)

			nChartControl1.Controller.Tools.Add(New NDataPanTool())
			nChartControl1.Controller.Tools.Add(New NAxisScrollTool())

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Multi Page Printing")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.MiddleCenter
			title.DockMargins = New NMarginsL(5, 5, 5, 5)
			title.DockMode = PanelDockMode.Top

			nChartControl1.Legends(0).Mode = LegendMode.Disabled

			' setup chart
			m_Chart.BoundsMode = BoundsMode.Stretch
			m_Chart.DockMode = PanelDockMode.Fill
			m_Chart.DockMargins = New NMarginsL(15, 20, 30, 20)

			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = True
			m_Chart.Axis(StandardAxis.PrimaryY).ScrollBar.ResetButton.Visible = False

			Dim dateTimeScale As New NDateTimeScaleConfigurator()
			dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2
			m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = dateTimeScale
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = True
			m_Chart.Axis(StandardAxis.PrimaryX).ScrollBar.ResetButton.Visible = False
			m_Chart.BringToFront()

			' create the float bar series
			m_FloatBar = CType(m_Chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			m_FloatBar.UseXValues = True
			m_FloatBar.UseZValues = False
			m_FloatBar.InflateMargins = True
			m_FloatBar.DataLabelStyle.Visible = False

			' bar appearance
			m_FloatBar.BorderStyle.Color = Color.Bisque
			m_FloatBar.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.LightGray, Color.DarkBlue)
			m_FloatBar.ShadowStyle.Type = ShadowType.Solid
			m_FloatBar.ShadowStyle.Color = Color.FromArgb(30, 0, 0, 0)

			m_FloatBar.Values.ValueFormatter = New NNumericValueFormatter("0.00")
			m_FloatBar.EndValues.ValueFormatter = New NNumericValueFormatter("0.00")

			' show the begin end values in the legend
			m_FloatBar.Legend.Format = "<begin> - <end>"
			m_FloatBar.Legend.Mode = SeriesLegendMode.DataPoints

			GenerateData()

			m_PrintManager = New NPrintManager(nChartControl1.Document)
		End Sub

		Private Sub GenerateData()
			Const nCount As Integer = 12

			m_FloatBar.Values.Clear()
			m_FloatBar.EndValues.Clear()
			m_FloatBar.XValues.Clear()

			' generate Y values
			For i As Integer = 0 To nCount - 1
				Dim dBeginValue As Double = Random.NextDouble() * 5
				Dim dEndValue As Double = dBeginValue + 2 + Random.NextDouble()
				m_FloatBar.Values.Add(dBeginValue)
				m_FloatBar.EndValues.Add(dEndValue)
			Next i

			' generate X values
			Dim dt As New Date(2005, 5, 24, 11, 0, 0)

			For i As Integer = 0 To nCount - 1
				dt = dt.AddDays(Random.NextDouble() * 15)
				m_FloatBar.XValues.Add(dt)
			Next i
		End Sub

		Public Overrides Sub Initialize()
			InitChart()

			m_PrintManager.PrintDocumentController = New NAxisPagingDocumentController()

			' update form controls
			HorizontalPageSizeComboBox.Items.Add("3 Months")
			HorizontalPageSizeComboBox.Items.Add("4 Months")
			HorizontalPageSizeComboBox.Items.Add("5 Months")
			HorizontalPageSizeComboBox.SelectedIndex = 0

			VerticalPageSizeComboBox.Items.Add("3")
			VerticalPageSizeComboBox.Items.Add("4")
			VerticalPageSizeComboBox.Items.Add("5")
			VerticalPageSizeComboBox.SelectedIndex = 0

			EnableHorizontalPagingCheckBox.Checked = True
			EnableVerticalPagingCheckBox.Checked = True
			m_Updating = False

			UpdateAxisPaging()
		End Sub

		Private Sub UpdateAxisPaging()
			If m_Updating Then
				Return
			End If

			Dim axis As NAxis

			axis = m_Chart.Axis(StandardAxis.PrimaryX)
			axis.PagingView = GetHorizontalAxisPagingView()
			axis.PagingView.Enabled = EnableHorizontalPagingCheckBox.Checked
			HorizontalPageSizeComboBox.Enabled = EnableHorizontalPagingCheckBox.Checked

			axis = m_Chart.Axis(StandardAxis.PrimaryY)
			axis.PagingView = GetVerticalAxisPagingView()
			axis.PagingView.Enabled = EnableVerticalPagingCheckBox.Checked
			VerticalPageSizeComboBox.Enabled = EnableVerticalPagingCheckBox.Checked

			nChartControl1.Refresh()
		End Sub

		Private Function GetHorizontalAxisPagingView() As NDateTimeAxisPagingView
			Dim view As NDateTimeAxisPagingView = Nothing
			Dim dt As New Date(2005, 5, 24, 11, 0, 0)

			Select Case HorizontalPageSizeComboBox.SelectedIndex
				Case 0
					view = New NDateTimeAxisPagingView(dt, New NDateTimeSpan(1, NDateTimeUnit.Month))
				Case 1
					view = New NDateTimeAxisPagingView(dt, New NDateTimeSpan(2, NDateTimeUnit.Month))
				Case 2
					view = New NDateTimeAxisPagingView(dt, New NDateTimeSpan(3, NDateTimeUnit.Month))
				Case Else
					Debug.Assert(False)
			End Select

			Return view
		End Function

		Private Function GetVerticalAxisPagingView() As NNumericAxisPagingView
			Dim view As NNumericAxisPagingView = Nothing

			Select Case VerticalPageSizeComboBox.SelectedIndex
				Case 0
					view = New NNumericAxisPagingView(New NRange1DD(0, 3))
				Case 1
					view = New NNumericAxisPagingView(New NRange1DD(0, 4))
				Case 2
					view = New NNumericAxisPagingView(New NRange1DD(0, 5))
				Case Else
					Debug.Assert(False)
			End Select

			Return view
		End Function

		Private Sub PrintPreviewButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintPreviewButton.Click
			m_PrintManager.ShowPrintPreview()
		End Sub

		Private Sub PrintButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintButton.Click
			m_PrintManager.Print()
		End Sub

		Private Sub HorizontalPageSizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HorizontalPageSizeComboBox.SelectedIndexChanged
			UpdateAxisPaging()
		End Sub

		Private Sub VerticalPageSizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerticalPageSizeComboBox.SelectedIndexChanged
			UpdateAxisPaging()
		End Sub

		Private Sub EnableVerticalPagingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableVerticalPagingCheckBox.CheckedChanged
			UpdateAxisPaging()
		End Sub

		Private Sub EnableHorizontalPagingCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableHorizontalPagingCheckBox.CheckedChanged
			UpdateAxisPaging()
		End Sub
	End Class
End Namespace
