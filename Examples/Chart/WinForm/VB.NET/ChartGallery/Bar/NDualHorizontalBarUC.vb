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


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NDualHorizontalBarUC
		Inherits NExampleBaseUC

		Private m_ChartFemale As NChart
		Private m_ChartMale As NChart
		Private m_barF As NBarSeries
		Private m_barM As NBarSeries
		Private components As System.ComponentModel.Container = Nothing
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents MaleStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents FemaleStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents MaleFEButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents FemaleFEButton As Nevron.UI.WinForm.Controls.NButton

		Private AgeLabels() As String = { "0 - 4", "5 - 9", "10 - 14", "15 - 19", "20 - 24", "25 - 29", "30 - 34", "35 - 39", "40 - 44", "45 - 49", "50 - 54", "55 - 59", "60 - 64", "65 - 69", "70 - 74", "75 - 79", "80 +" }

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
			Me.label1 = New System.Windows.Forms.Label()
			Me.MaleStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.FemaleStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.MaleFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.FemaleFEButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(7, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(159, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Male Bar Style:"
			' 
			' MaleStyleCombo
			' 
			Me.MaleStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.MaleStyleCombo.ListProperties.DataSource = Nothing
			Me.MaleStyleCombo.ListProperties.DisplayMember = ""
			Me.MaleStyleCombo.Location = New System.Drawing.Point(7, 31)
			Me.MaleStyleCombo.Name = "MaleStyleCombo"
			Me.MaleStyleCombo.Size = New System.Drawing.Size(159, 21)
			Me.MaleStyleCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaleStyleCombo.SelectedIndexChanged += new System.EventHandler(this.MaleStyleCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(7, 65)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(159, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Female Bar Style:"
			' 
			' FemaleStyleCombo
			' 
			Me.FemaleStyleCombo.ListProperties.CheckBoxDataMember = ""
			Me.FemaleStyleCombo.ListProperties.DataSource = Nothing
			Me.FemaleStyleCombo.ListProperties.DisplayMember = ""
			Me.FemaleStyleCombo.Location = New System.Drawing.Point(7, 81)
			Me.FemaleStyleCombo.Name = "FemaleStyleCombo"
			Me.FemaleStyleCombo.Size = New System.Drawing.Size(159, 21)
			Me.FemaleStyleCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FemaleStyleCombo.SelectedIndexChanged += new System.EventHandler(this.FemaleStyleCombo_SelectedIndexChanged);
			' 
			' MaleFEButton
			' 
			Me.MaleFEButton.Location = New System.Drawing.Point(7, 118)
			Me.MaleFEButton.Name = "MaleFEButton"
			Me.MaleFEButton.Size = New System.Drawing.Size(159, 28)
			Me.MaleFEButton.TabIndex = 4
			Me.MaleFEButton.Text = "Male Bars Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.MaleFEButton.Click += new System.EventHandler(this.MaleFEButton_Click);
			' 
			' FemaleFEButton
			' 
			Me.FemaleFEButton.Location = New System.Drawing.Point(7, 159)
			Me.FemaleFEButton.Name = "FemaleFEButton"
			Me.FemaleFEButton.Size = New System.Drawing.Size(159, 28)
			Me.FemaleFEButton.TabIndex = 5
			Me.FemaleFEButton.Text = "Female Bars Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.FemaleFEButton.Click += new System.EventHandler(this.FemaleFEButton_Click);
			' 
			' NDualHorizontalBarUC
			' 
			Me.Controls.Add(Me.FemaleFEButton)
			Me.Controls.Add(Me.MaleFEButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.FemaleStyleCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.MaleStyleCombo)
			Me.Name = "NDualHorizontalBarUC"
			Me.Size = New System.Drawing.Size(180, 206)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.Panels.Clear()

			' top panel
			Dim topPanel As New NDockPanel()
			topPanel.DockMode = PanelDockMode.Top
			topPanel.Size = New NSizeL(New NLength(0), New NLength(8, NRelativeUnit.ParentPercentage))

			' bottom panel
			Dim bottomPanel As New NDockPanel()
			bottomPanel.DockMode = PanelDockMode.Bottom
			bottomPanel.Size = New NSizeL(New NLength(0), New NLength(8, NRelativeUnit.ParentPercentage))

			' left panel
			Dim leftPanel As New NDockPanel()
			leftPanel.DockMode = PanelDockMode.Left
			leftPanel.Size = New NSizeL(New NLength(47.0F, NRelativeUnit.ParentPercentage), New NLength(0))

			' right panel
			Dim rightPanel As New NDockPanel()
			rightPanel.DockMode = PanelDockMode.Right
			rightPanel.Size = New NSizeL(New NLength(47.0F, NRelativeUnit.ParentPercentage), New NLength(0))

			' middle panel
			Dim middlePanel As New NDockPanel()
			middlePanel.DockMode = PanelDockMode.Fill

			' left label panel
			Dim leftLabelPanel As New NDockPanel()
			leftLabelPanel.DockMode = PanelDockMode.Left
			leftLabelPanel.Size = New NSizeL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(0))

			' left chart panel
			Dim leftChartPanel As New NDockPanel()
			leftChartPanel.DockMode = PanelDockMode.Fill

			' right label panel
			Dim rightLabelPanel As New NDockPanel()
			rightLabelPanel.DockMode = PanelDockMode.Right
			rightLabelPanel.Size = New NSizeL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(0))

			' right chart panel
			Dim rightChartPanel As New NDockPanel()
			rightChartPanel.DockMode = PanelDockMode.Fill

			' header label
			Dim headerLabel As New NLabel("Population structure of New York for 2001")
			headerLabel.ContentAlignment = ContentAlignment.MiddleCenter
			headerLabel.TextStyle.FontStyle.Name = "Times New Roman"
			headerLabel.TextStyle.FontStyle.Style = FontStyle.Italic
			headerLabel.BoundsMode = BoundsMode.Fit
			headerLabel.UseAutomaticSize = False
			headerLabel.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			headerLabel.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))

			' footer label
			Dim footerLabel As New NLabel("Population (in thousands)")
			footerLabel.ContentAlignment = ContentAlignment.MiddleCenter
			footerLabel.TextStyle.FontStyle.Name = "Times New Roman"
			footerLabel.TextStyle.FontStyle.Style = FontStyle.Italic
			footerLabel.BoundsMode = BoundsMode.Fit
			footerLabel.UseAutomaticSize = False
			footerLabel.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			footerLabel.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))

			' middle label (vertical)
			Dim midLabel As New NLabel("Age range")
			midLabel.BoundsMode = BoundsMode.Fit
			midLabel.ContentAlignment = ContentAlignment.MiddleCenter
			midLabel.UseAutomaticSize = False
			midLabel.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			midLabel.Size = New NSizeL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(80, NRelativeUnit.ParentPercentage))
			midLabel.TextStyle.FontStyle = New NFontStyle("Verdana", 12)
			midLabel.TextStyle.BackplaneStyle.Visible = False
			midLabel.TextStyle.Orientation = 90

			' label (male)
			Dim mlabel As New NLabel("Male")
			mlabel.ContentAlignment = ContentAlignment.MiddleCenter
			mlabel.TextStyle.FontStyle.Name = "Times New Roman"
			mlabel.TextStyle.FontStyle.Style = FontStyle.Italic
			mlabel.TextStyle.FillStyle = New NColorFillStyle(Blue)
			mlabel.TextStyle.BackplaneStyle.Visible = False
			mlabel.TextStyle.Orientation = 90
			mlabel.BoundsMode = BoundsMode.Fit
			mlabel.UseAutomaticSize = False
			mlabel.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			mlabel.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			' label (female)
			Dim flabel As New NLabel("Female")
			flabel.ContentAlignment = ContentAlignment.MiddleCenter
			flabel.TextStyle.FontStyle.Name = "Times New Roman"
			flabel.TextStyle.FontStyle.Style = FontStyle.Italic
			flabel.TextStyle.FillStyle = New NColorFillStyle(BeautifulRed)
			flabel.TextStyle.BackplaneStyle.Visible = False
			flabel.TextStyle.Orientation = 270
			flabel.BoundsMode = BoundsMode.Fit
			flabel.UseAutomaticSize = False
			flabel.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(50, NRelativeUnit.ParentPercentage))
			flabel.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))

			' create male chart
			m_ChartMale = New NCartesianChart()
			m_ChartMale.BoundsMode = BoundsMode.Stretch
			m_ChartMale.ContentAlignment = ContentAlignment.MiddleCenter
			m_ChartMale.DockMode = PanelDockMode.Fill
			SetupMaleChart()

			' create female chart
			m_ChartFemale = New NCartesianChart()
			m_ChartFemale.BoundsMode = BoundsMode.Stretch
			m_ChartFemale.ContentAlignment = ContentAlignment.MiddleCenter
			m_ChartFemale.DockMode = PanelDockMode.Fill
			SetupFemaleChart()

			' arrange panels
			nChartControl1.Panels.Add(topPanel)
			nChartControl1.Panels.Add(bottomPanel)
			nChartControl1.Panels.Add(leftPanel)
			nChartControl1.Panels.Add(rightPanel)
			nChartControl1.Panels.Add(middlePanel)

			leftPanel.ChildPanels.Add(leftLabelPanel)
			leftPanel.ChildPanels.Add(leftChartPanel)
			rightPanel.ChildPanels.Add(rightLabelPanel)
			rightPanel.ChildPanels.Add(rightChartPanel)

			topPanel.ChildPanels.Add(headerLabel)
			bottomPanel.ChildPanels.Add(footerLabel)
			middlePanel.ChildPanels.Add(midLabel)
			leftLabelPanel.ChildPanels.Add(mlabel)
			rightLabelPanel.ChildPanels.Add(flabel)
			leftChartPanel.ChildPanels.Add(m_ChartMale)
			rightChartPanel.ChildPanels.Add(m_ChartFemale)

			FemaleStyleCombo.FillFromEnum(GetType(BarShape))
			FemaleStyleCombo.SelectedIndex = 0

			MaleStyleCombo.FillFromEnum(GetType(BarShape))
			MaleStyleCombo.SelectedIndex = 0
		End Sub

		Private Sub SetupFemaleChart()
			' female chart setup
			m_ChartFemale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalLeft)
			m_ChartFemale.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHorizontalLeft)

			' setup Y axis
			Dim axisY As NAxis = m_ChartFemale.Axis(StandardAxis.PrimaryY)
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = False
			axisY.Anchor = New NDockAxisAnchor(AxisDockZone.FrontRight, False, 0, 100)

			' add manual labels to the female chart
			Dim axisX As NAxis = m_ChartFemale.Axis(StandardAxis.PrimaryX)
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.Invert = True
			scaleX.InnerMajorTickStyle.Visible = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
			scaleX.AutoLabels = False
			scaleX.Labels.AddRange(AgeLabels)

			' populate the female chart
			m_barF = CType(m_ChartFemale.Series.Add(SeriesType.Bar), NBarSeries)
			m_barF.FillStyle = New NGradientFillStyle(BeautifulRed, Color.White)
			m_barF.BorderStyle.Color = BeautifulRed
			m_barF.DataLabelStyle.Format = "<value>"
			m_barF.DataLabelStyle.VertAlign = VertAlign.Center
			m_barF.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 7)
			m_barF.Values.Add(210) ' 0 - 4
			m_barF.Values.Add(215) ' 5 - 9
			m_barF.Values.Add(219) ' 10 - 14
			m_barF.Values.Add(225) ' 15 - 19
			m_barF.Values.Add(245) ' 20 - 24
			m_barF.Values.Add(289) ' 25 - 29
			m_barF.Values.Add(355) ' 30 - 34
			m_barF.Values.Add(355) ' 35 - 39
			m_barF.Values.Add(380) ' 40 - 44
			m_barF.Values.Add(320) ' 45 - 49
			m_barF.Values.Add(250) ' 50 - 54
			m_barF.Values.Add(190) ' 55 - 59
			m_barF.Values.Add(112) ' 60 - 64
			m_barF.Values.Add(110) ' 65 - 69
			m_barF.Values.Add(90) ' 70 - 74
			m_barF.Values.Add(55) ' 75 - 79
			m_barF.Values.Add(45) ' 80 +
		End Sub

		Private Sub SetupMaleChart()
			' chart setup
			m_ChartMale.SetPredefinedChartStyle(PredefinedChartStyle.HorizontalRight)
			m_ChartMale.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalHorizontalRight)

			' setup Y axis
			Dim axisY As NAxis = m_ChartMale.Axis(StandardAxis.PrimaryY)
			axisY.ScaleConfigurator.InnerMajorTickStyle.Visible = False

			' add labels to the male chart X axis
			Dim axisX As NAxis = m_ChartMale.Axis(StandardAxis.PrimaryX)
			Dim scaleX As NOrdinalScaleConfigurator = TryCast(axisX.ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.InnerMajorTickStyle.Visible = False
			scaleX.MajorTickMode = MajorTickMode.AutoMaxCount
			scaleX.LabelFitModes = New LabelFitMode() { LabelFitMode.AutoScale }
			scaleX.AutoLabels = False
			scaleX.Labels.AddRange(AgeLabels)

			' populate the male chart
			m_barM = CType(m_ChartMale.Series.Add(SeriesType.Bar), NBarSeries)
			m_barM.FillStyle = New NGradientFillStyle(Blue, Color.White)
			m_barM.BorderStyle.Color = Blue
			m_barM.DataLabelStyle.Format = "<value>"
			m_barM.DataLabelStyle.VertAlign = VertAlign.Center
			m_barM.DataLabelStyle.TextStyle.FontStyle = New NFontStyle("Arial", 7)
			m_barM.Values.Add(200) ' 0 - 4
			m_barM.Values.Add(210) ' 5 - 9
			m_barM.Values.Add(205) ' 10 - 14
			m_barM.Values.Add(225) ' 15 - 19
			m_barM.Values.Add(250) ' 20 - 24
			m_barM.Values.Add(290) ' 25 - 29
			m_barM.Values.Add(340) ' 30 - 34
			m_barM.Values.Add(340) ' 35 - 39
			m_barM.Values.Add(370) ' 40 - 44
			m_barM.Values.Add(310) ' 45 - 49
			m_barM.Values.Add(260) ' 50 - 54
			m_barM.Values.Add(180) ' 55 - 59
			m_barM.Values.Add(120) ' 60 - 64
			m_barM.Values.Add(115) ' 65 - 69
			m_barM.Values.Add(100) ' 70 - 74
			m_barM.Values.Add(50) ' 75 - 79
			m_barM.Values.Add(35) ' 80 +
		End Sub

		Private Sub MaleFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaleFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_barM.FillStyle, fillStyleResult) Then
				m_barM.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub FemaleFEButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FemaleFEButton.Click
			Dim fillStyleResult As NFillStyle = Nothing

			If NFillStyleTypeEditor.Edit(m_barF.FillStyle, fillStyleResult) Then
				m_barF.FillStyle = fillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub
		Private Sub MaleStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaleStyleCombo.SelectedIndexChanged
			m_barM.BarShape = CType(MaleStyleCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
		Private Sub FemaleStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FemaleStyleCombo.SelectedIndexChanged
			m_barF.BarShape = CType(FemaleStyleCombo.SelectedIndex, BarShape)
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace