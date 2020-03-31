Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports Nevron.Serialization
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSerializingChartObjectsUC
		Inherits NExampleBaseUC

		Private label2 As System.Windows.Forms.Label
		Private SerializationContentComboBox As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ModifyFirstChartDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents LoadSecondChartButton As Nevron.UI.WinForm.Controls.NButton
		Private m_Chart1 As NChart
		Private m_Chart2 As NChart
		Private WithEvents ModifySecondChartDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ModifySecondChartAppearanceButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ModifyFirstChartAppearanceButton As Nevron.UI.WinForm.Controls.NButton
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
			Me.label2 = New System.Windows.Forms.Label()
			Me.SerializationContentComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.LoadSecondChartButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ModifyFirstChartDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ModifyFirstChartAppearanceButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ModifySecondChartAppearanceButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ModifySecondChartDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 80)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(176, 24)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Serialization content:"
			' 
			' SerializationContentComboBox
			' 
			Me.SerializationContentComboBox.Location = New System.Drawing.Point(8, 96)
			Me.SerializationContentComboBox.Name = "SerializationContentComboBox"
			Me.SerializationContentComboBox.Size = New System.Drawing.Size(176, 21)
			Me.SerializationContentComboBox.TabIndex = 3
			' 
			' LoadSecondChartButton
			' 
			Me.LoadSecondChartButton.Location = New System.Drawing.Point(8, 120)
			Me.LoadSecondChartButton.Name = "LoadSecondChartButton"
			Me.LoadSecondChartButton.Size = New System.Drawing.Size(176, 32)
			Me.LoadSecondChartButton.TabIndex = 4
			Me.LoadSecondChartButton.Text = "Load second chart from first chart"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.LoadSecondChartButton.Click += new System.EventHandler(this.LoadSecondChartButton_Click);
			' 
			' ModifyFirstChartDataButton
			' 
			Me.ModifyFirstChartDataButton.Location = New System.Drawing.Point(8, 40)
			Me.ModifyFirstChartDataButton.Name = "ModifyFirstChartDataButton"
			Me.ModifyFirstChartDataButton.Size = New System.Drawing.Size(176, 23)
			Me.ModifyFirstChartDataButton.TabIndex = 1
			Me.ModifyFirstChartDataButton.Text = "Modify first chart data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ModifyFirstChartDataButton.Click += new System.EventHandler(this.ModifyFirstChartDataButton_Click);
			' 
			' ModifyFirstChartAppearanceButton
			' 
			Me.ModifyFirstChartAppearanceButton.Location = New System.Drawing.Point(8, 8)
			Me.ModifyFirstChartAppearanceButton.Name = "ModifyFirstChartAppearanceButton"
			Me.ModifyFirstChartAppearanceButton.Size = New System.Drawing.Size(176, 23)
			Me.ModifyFirstChartAppearanceButton.TabIndex = 0
			Me.ModifyFirstChartAppearanceButton.Text = "Modify first chart appearance"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ModifyFirstChartAppearanceButton.Click += new System.EventHandler(this.ModifyFirstChartAppearanceButton_Click);
			' 
			' ModifySecondChartAppearanceButton
			' 
			Me.ModifySecondChartAppearanceButton.Location = New System.Drawing.Point(8, 208)
			Me.ModifySecondChartAppearanceButton.Name = "ModifySecondChartAppearanceButton"
			Me.ModifySecondChartAppearanceButton.Size = New System.Drawing.Size(176, 23)
			Me.ModifySecondChartAppearanceButton.TabIndex = 6
			Me.ModifySecondChartAppearanceButton.Text = "Modify second chart appearance"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ModifySecondChartAppearanceButton.Click += new System.EventHandler(this.ModifySecondChartAppearanceButton_Click);
			' 
			' ModifySecondChartDataButton
			' 
			Me.ModifySecondChartDataButton.Location = New System.Drawing.Point(8, 176)
			Me.ModifySecondChartDataButton.Name = "ModifySecondChartDataButton"
			Me.ModifySecondChartDataButton.Size = New System.Drawing.Size(176, 23)
			Me.ModifySecondChartDataButton.TabIndex = 5
			Me.ModifySecondChartDataButton.Text = "Modify second chart data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ModifySecondChartDataButton.Click += new System.EventHandler(this.ModifySecondChartDataButton_Click);
			' 
			' NSerializingChartObjects
			' 
			Me.Controls.Add(Me.ModifySecondChartAppearanceButton)
			Me.Controls.Add(Me.ModifySecondChartDataButton)
			Me.Controls.Add(Me.ModifyFirstChartAppearanceButton)
			Me.Controls.Add(Me.ModifyFirstChartDataButton)
			Me.Controls.Add(Me.LoadSecondChartButton)
			Me.Controls.Add(Me.SerializationContentComboBox)
			Me.Controls.Add(Me.label2)
			Me.Name = "NSerializingChartObjects"
			Me.Size = New System.Drawing.Size(192, 359)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Using serialization to clone Chart object")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup the chart
			m_Chart1 = nChartControl1.Charts(0)
			m_Chart1.Enable3D = True
			m_Chart1.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHalf)
			m_Chart1.Axis(StandardAxis.Depth).Visible = False

			m_Chart1.Location = New NPointL(New NLength(10, NRelativeUnit.RootPercentage), New NLength(10, NRelativeUnit.RootPercentage))

			m_Chart1.Size = New NSizeL(New NLength(80, NRelativeUnit.RootPercentage), New NLength(35, NRelativeUnit.RootPercentage))

			m_Chart1.BoundsMode = BoundsMode.Fit

			' add the first bar
			Dim bar1 As NBarSeries = CType(m_Chart1.Series.Add(SeriesType.Bar), NBarSeries)
			bar1.Name = "Bar1"
			bar1.MultiBarMode = MultiBarMode.Series
			bar1.DataLabelStyle.Format = "<value>"

			' add the second bar
			Dim bar2 As NBarSeries = CType(m_Chart1.Series.Add(SeriesType.Bar), NBarSeries)
			bar2.Name = "Bar2"
			bar2.MultiBarMode = MultiBarMode.Clustered
			bar2.DataLabelStyle.Format = "<value>"

			' add the third bar
			Dim bar3 As NBarSeries = CType(m_Chart1.Series.Add(SeriesType.Bar), NBarSeries)
			bar3.Name = "Bar2"
			bar3.MultiBarMode = MultiBarMode.Stacked
			bar3.DataLabelStyle.Format = "<value>"

			bar2.DataLabelStyle.VertAlign = VertAlign.Center
			bar3.DataLabelStyle.VertAlign = VertAlign.Center

			' fill with random data
			bar1.Values.FillRandomRange(Random, 5, 10, 100)
			bar2.Values.FillRandomRange(Random, 5, 10, 500)
			bar3.Values.FillRandomRange(Random, 5, 10, 500)

			' change the color of the bars
			bar1.FillStyle = New NColorFillStyle(Color.PaleVioletRed)
			bar2.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
			bar3.FillStyle = New NColorFillStyle(Color.LimeGreen)

			' init form controls
			SerializationContentComboBox.Items.Add("All")
			SerializationContentComboBox.Items.Add("Data")
			SerializationContentComboBox.Items.Add("Appearance")
			SerializationContentComboBox.SelectedIndex = 0

			' copy the first chart state into the second chart
			LoadSecondChartButton_Click(Nothing, Nothing)
		End Sub

		Private Sub ModifyFirstChartDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModifyFirstChartDataButton.Click
			For Each bar As NBarSeries In m_Chart1.Series
				bar.Values.FillRandomRange(Random, 5, -100, 100)
			Next bar

			nChartControl1.Refresh()
		End Sub

		Private Sub ModifyFirstChartAppearanceButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModifyFirstChartAppearanceButton.Click
			For Each bar As NBarSeries In m_Chart1.Series
				bar.FillStyle = New NColorFillStyle(RandomColor())
			Next bar

			nChartControl1.Refresh()
		End Sub

		Private Sub ModifySecondChartDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModifySecondChartDataButton.Click
			For Each bar As NBarSeries In m_Chart2.Series
				bar.Values.FillRandomRange(Random, 5, -100, 100)
			Next bar

			nChartControl1.Refresh()
		End Sub

		Private Sub ModifySecondChartAppearanceButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModifySecondChartAppearanceButton.Click
			For Each bar As NBarSeries In m_Chart2.Series
				bar.FillStyle = New NColorFillStyle(RandomColor())
			Next bar

			nChartControl1.Refresh()
		End Sub

		Private Sub LoadSecondChartButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoadSecondChartButton.Click
'			MemoryStream stream = new MemoryStream();
			Dim filter As NSerializationFilter = Nothing

			Select Case SerializationContentComboBox.SelectedIndex
				Case 0 ' All
					filter = Nothing
				Case 1 ' Data
					filter = New NDataSerializationFilter()
				Case 2 ' Appearance
					filter = New NAppearanceSerializationFilter()

			End Select

			If m_Chart2 IsNot Nothing Then
				nChartControl1.Panels.Remove(m_Chart2)
			End If

			' clone the first chart
			m_Chart2 = CType(nChartControl1.Charts(0).CloneWithNewUniqueId(Nothing), NChart)

			' filter elements
			m_Chart2 = CType(nChartControl1.Serializer.DeepClone(m_Chart2, filter), NChart)
			m_Chart2.Location = New NPointL(New NLength(10, NRelativeUnit.RootPercentage), New NLength(55, NRelativeUnit.RootPercentage))

			' add to panels collection
			nChartControl1.Panels.Add(m_Chart2)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
