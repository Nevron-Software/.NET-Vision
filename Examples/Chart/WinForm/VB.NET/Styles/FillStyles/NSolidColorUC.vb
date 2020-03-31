Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSolidColorUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NFloatBarSeries
		Private m_bSkipUpdate As Boolean
		Private WithEvents EditLightsButton As Nevron.UI.WinForm.Controls.NButton
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents BarsDiffuseButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarsAmbientButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarsSpecularButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarsEmissiveButton As Nevron.UI.WinForm.Controls.NButton
		Private groupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents WallsEmissiveButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WallsDiffuseButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WallsSpecularButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents WallsAmbientButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BarsShininessSpin As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents WallsShininessSpin As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents BackColorButton As Nevron.UI.WinForm.Controls.NButton
		Private colorDialog1 As Nevron.UI.WinForm.Controls.NColorDialog
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private components As System.ComponentModel.IContainer = Nothing

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


		#Region "Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.EditLightsButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BarsDiffuseButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BarsAmbientButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BarsSpecularButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BarsEmissiveButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.BarsShininessSpin = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.colorDialog1 = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.groupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.WallsShininessSpin = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.WallsEmissiveButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WallsDiffuseButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WallsSpecularButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.WallsAmbientButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.BackColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1.SuspendLayout()
			DirectCast(Me.BarsShininessSpin, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox2.SuspendLayout()
			DirectCast(Me.WallsShininessSpin, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' EditLightsButton
			' 
			Me.EditLightsButton.Location = New System.Drawing.Point(7, 7)
			Me.EditLightsButton.Name = "EditLightsButton"
			Me.EditLightsButton.Size = New System.Drawing.Size(141, 23)
			Me.EditLightsButton.TabIndex = 0
			Me.EditLightsButton.Text = "Edit Ligths..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.EditLightsButton.Click += new System.EventHandler(this.EditLightsButton_Click);
			' 
			' BarsDiffuseButton
			' 
			Me.BarsDiffuseButton.Location = New System.Drawing.Point(8, 21)
			Me.BarsDiffuseButton.Name = "BarsDiffuseButton"
			Me.BarsDiffuseButton.Size = New System.Drawing.Size(122, 22)
			Me.BarsDiffuseButton.TabIndex = 1
			Me.BarsDiffuseButton.Text = "Diffuse Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarsDiffuseButton.Click += new System.EventHandler(this.BarsDiffuseButton_Click);
			' 
			' BarsAmbientButton
			' 
			Me.BarsAmbientButton.Location = New System.Drawing.Point(8, 48)
			Me.BarsAmbientButton.Name = "BarsAmbientButton"
			Me.BarsAmbientButton.Size = New System.Drawing.Size(122, 22)
			Me.BarsAmbientButton.TabIndex = 2
			Me.BarsAmbientButton.Text = "Ambient Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarsAmbientButton.Click += new System.EventHandler(this.BarsAmbientButton_Click);
			' 
			' BarsSpecularButton
			' 
			Me.BarsSpecularButton.Location = New System.Drawing.Point(8, 76)
			Me.BarsSpecularButton.Name = "BarsSpecularButton"
			Me.BarsSpecularButton.Size = New System.Drawing.Size(122, 22)
			Me.BarsSpecularButton.TabIndex = 3
			Me.BarsSpecularButton.Text = "Specular Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarsSpecularButton.Click += new System.EventHandler(this.BarsSpecularButton_Click);
			' 
			' BarsEmissiveButton
			' 
			Me.BarsEmissiveButton.Location = New System.Drawing.Point(8, 104)
			Me.BarsEmissiveButton.Name = "BarsEmissiveButton"
			Me.BarsEmissiveButton.Size = New System.Drawing.Size(122, 22)
			Me.BarsEmissiveButton.TabIndex = 4
			Me.BarsEmissiveButton.Text = "Emissive Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarsEmissiveButton.Click += new System.EventHandler(this.BarsEmissiveButton_Click);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.BarsShininessSpin)
			Me.groupBox1.Controls.Add(Me.BarsEmissiveButton)
			Me.groupBox1.Controls.Add(Me.BarsDiffuseButton)
			Me.groupBox1.Controls.Add(Me.BarsSpecularButton)
			Me.groupBox1.Controls.Add(Me.BarsAmbientButton)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Location = New System.Drawing.Point(7, 50)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(141, 179)
			Me.groupBox1.TabIndex = 5
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Bars"
			' 
			' BarsShininessSpin
			' 
			Me.BarsShininessSpin.Location = New System.Drawing.Point(8, 149)
			Me.BarsShininessSpin.Maximum = New System.Decimal(New Integer() { 128, 0, 0, 0})
			Me.BarsShininessSpin.Name = "BarsShininessSpin"
			Me.BarsShininessSpin.Size = New System.Drawing.Size(81, 20)
			Me.BarsShininessSpin.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarsShininessSpin.ValueChanged += new System.EventHandler(this.BarsShininessSpin_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 133)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(122, 15)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Shininess:"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.label2)
			Me.groupBox2.Controls.Add(Me.WallsShininessSpin)
			Me.groupBox2.Controls.Add(Me.WallsEmissiveButton)
			Me.groupBox2.Controls.Add(Me.WallsDiffuseButton)
			Me.groupBox2.Controls.Add(Me.WallsSpecularButton)
			Me.groupBox2.Controls.Add(Me.WallsAmbientButton)
			Me.groupBox2.Location = New System.Drawing.Point(7, 244)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(141, 179)
			Me.groupBox2.TabIndex = 6
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Walls"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 133)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(122, 15)
			Me.label2.TabIndex = 7
			Me.label2.Text = "Shininess:"
			' 
			' WallsShininessSpin
			' 
			Me.WallsShininessSpin.Location = New System.Drawing.Point(11, 149)
			Me.WallsShininessSpin.Maximum = New System.Decimal(New Integer() { 128, 0, 0, 0})
			Me.WallsShininessSpin.Name = "WallsShininessSpin"
			Me.WallsShininessSpin.Size = New System.Drawing.Size(81, 20)
			Me.WallsShininessSpin.TabIndex = 6
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WallsShininessSpin.ValueChanged += new System.EventHandler(this.WallsShininessSpin_ValueChanged);
			' 
			' WallsEmissiveButton
			' 
			Me.WallsEmissiveButton.Location = New System.Drawing.Point(8, 104)
			Me.WallsEmissiveButton.Name = "WallsEmissiveButton"
			Me.WallsEmissiveButton.Size = New System.Drawing.Size(122, 22)
			Me.WallsEmissiveButton.TabIndex = 4
			Me.WallsEmissiveButton.Text = "Emissive Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WallsEmissiveButton.Click += new System.EventHandler(this.WallsEmissiveButton_Click);
			' 
			' WallsDiffuseButton
			' 
			Me.WallsDiffuseButton.Location = New System.Drawing.Point(8, 21)
			Me.WallsDiffuseButton.Name = "WallsDiffuseButton"
			Me.WallsDiffuseButton.Size = New System.Drawing.Size(122, 22)
			Me.WallsDiffuseButton.TabIndex = 1
			Me.WallsDiffuseButton.Text = "Diffuse Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WallsDiffuseButton.Click += new System.EventHandler(this.WallsDiffuseButton_Click);
			' 
			' WallsSpecularButton
			' 
			Me.WallsSpecularButton.Location = New System.Drawing.Point(8, 76)
			Me.WallsSpecularButton.Name = "WallsSpecularButton"
			Me.WallsSpecularButton.Size = New System.Drawing.Size(122, 22)
			Me.WallsSpecularButton.TabIndex = 3
			Me.WallsSpecularButton.Text = "Specular Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WallsSpecularButton.Click += new System.EventHandler(this.WallsSpecularButton_Click);
			' 
			' WallsAmbientButton
			' 
			Me.WallsAmbientButton.Location = New System.Drawing.Point(8, 48)
			Me.WallsAmbientButton.Name = "WallsAmbientButton"
			Me.WallsAmbientButton.Size = New System.Drawing.Size(122, 22)
			Me.WallsAmbientButton.TabIndex = 2
			Me.WallsAmbientButton.Text = "Ambient Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WallsAmbientButton.Click += new System.EventHandler(this.WallsAmbientButton_Click);
			' 
			' BackColorButton
			' 
			Me.BackColorButton.Location = New System.Drawing.Point(7, 443)
			Me.BackColorButton.Name = "BackColorButton"
			Me.BackColorButton.Size = New System.Drawing.Size(141, 23)
			Me.BackColorButton.TabIndex = 7
			Me.BackColorButton.Text = "Background Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BackColorButton.Click += new System.EventHandler(this.BackColorButton_Click);
			' 
			' NSolidColorUC
			' 
			Me.Controls.Add(Me.BackColorButton)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.EditLightsButton)
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "NSolidColorUC"
			Me.Size = New System.Drawing.Size(156, 482)
			Me.groupBox1.ResumeLayout(False)
			DirectCast(Me.BarsShininessSpin, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox2.ResumeLayout(False)
			DirectCast(Me.WallsShininessSpin, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			nChartControl1.BackgroundStyle.FillStyle = New NColorFillStyle(Color.FromArgb(230, 230, 255))

			' add label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Colors And Materials")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)

			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = True
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective)

			' Setup the light model
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
			m_Chart.LightModel.GlobalAmbientLight = Color.FromArgb(64, 64, 64)
			m_Chart.LightModel.LightSources(0).Diffuse = Color.FromArgb(160, 160, 160)
			m_Chart.LightModel.LightSources(1).Diffuse = Color.FromArgb(160, 160, 160)
			m_Chart.LightModel.LightSources(2).Diffuse = Color.FromArgb(160, 160, 160)

			' Setup axes
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			Dim standardScale As NStandardScaleConfigurator = CType(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.MajorGridStyle.LineStyle.Color = Color.White
			standardScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

			standardScale = CType(m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NStandardScaleConfigurator)
			standardScale.MajorGridStyle.LineStyle.Color = Color.White
			standardScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot
			standardScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)

			' Setup walls
			Dim diffuse As Color = Color.FromArgb(128, 128, 192)
			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Diffuse = diffuse
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Diffuse = diffuse
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Diffuse = diffuse

			Dim ambient As Color = Color.FromArgb(128, 0, 255)
			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Ambient = ambient
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Ambient = ambient
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Ambient = ambient

			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Specular = Color.White
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Specular = Color.White
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Specular = Color.White

			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Shininess = 110
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Shininess = 110
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Shininess = 110

			' Create a bar series
			m_Bar = CType(m_Chart.Series.Add(SeriesType.FloatBar), NFloatBarSeries)
			m_Bar.DataLabelStyle.Visible = False
			m_Bar.BarShape = BarShape.SmoothEdgeBar
			m_Bar.BarEdgePercent = 50
			m_Bar.WidthPercent = 60
			m_Bar.DepthPercent = 60
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints
			m_Bar.FillStyle.MaterialStyle.Diffuse = Color.FromArgb(0, 0, 64)
			m_Bar.FillStyle.MaterialStyle.Ambient = Color.White
			m_Bar.FillStyle.MaterialStyle.Specular = Color.White
			m_Bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)

			m_Bar.AddDataPoint(New NFloatBarDataPoint(2.0, 24.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(21.0, 60.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(22.0, 53.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(34.0, 80.0))
			m_Bar.AddDataPoint(New NFloatBarDataPoint(11.0, 62.0))

			' init form controls
			m_bSkipUpdate = True
			BarsShininessSpin.Value = CDec(m_Bar.FillStyle.MaterialStyle.Shininess)
			WallsShininessSpin.Value = CDec(m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Shininess)
			m_bSkipUpdate = False
		End Sub

		Private Sub EditLightsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditLightsButton.Click
			Dim result As NLightModel = Nothing

			If NLightModelTypeEditor.Edit(m_Chart.LightModel, result) Then
				m_Chart.LightModel = result
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarsDiffuseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarsDiffuseButton.Click
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Diffuse

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Bar.FillStyle.MaterialStyle.Diffuse = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarsAmbientButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarsAmbientButton.Click
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Ambient

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Bar.FillStyle.MaterialStyle.Ambient = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarsSpecularButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarsSpecularButton.Click
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Specular

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Bar.FillStyle.MaterialStyle.Specular = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarsEmissiveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarsEmissiveButton.Click
			colorDialog1.Color = m_Bar.FillStyle.MaterialStyle.Emissive

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Bar.FillStyle.MaterialStyle.Emissive = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub WallsDiffuseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WallsDiffuseButton.Click
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Diffuse

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Diffuse = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Diffuse = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Diffuse = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub WallsAmbientButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WallsAmbientButton.Click
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Ambient

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Ambient = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Ambient = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Ambient = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub WallsSpecularButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WallsSpecularButton.Click
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Specular

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Specular = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Specular = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Specular = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub WallsEmissiveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WallsEmissiveButton.Click
			colorDialog1.Color = m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Emissive

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Emissive = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Emissive = colorDialog1.Color
				m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Emissive = colorDialog1.Color
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BarsShininessSpin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarsShininessSpin.ValueChanged
			If m_bSkipUpdate Then
				Return
			End If

			m_Bar.FillStyle.MaterialStyle.Shininess = CSng(BarsShininessSpin.Value)
			nChartControl1.Refresh()
		End Sub

		Private Sub WallsShininessSpin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WallsShininessSpin.ValueChanged
			If m_bSkipUpdate Then
				Return
			End If

			Dim shininess As Single = CSng(WallsShininessSpin.Value)

			m_Chart.Wall(ChartWallType.Back).FillStyle.MaterialStyle.Shininess = shininess
			m_Chart.Wall(ChartWallType.Left).FillStyle.MaterialStyle.Shininess = shininess
			m_Chart.Wall(ChartWallType.Floor).FillStyle.MaterialStyle.Shininess = shininess
			nChartControl1.Refresh()
		End Sub

		Private Sub BackColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackColorButton.Click
			colorDialog1.Color = nChartControl1.BackgroundStyle.FillStyle.GetPrimaryColor().ToColor()

			If colorDialog1.ShowDialog() = DialogResult.OK Then
				nChartControl1.BackgroundStyle.FillStyle = New NColorFillStyle(colorDialog1.Color)
				nChartControl1.Refresh()
			End If
		End Sub
	End Class
End Namespace
