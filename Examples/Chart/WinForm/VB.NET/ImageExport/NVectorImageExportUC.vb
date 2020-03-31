Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Data
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVectorImageExportUC
		Inherits NExampleBaseUC

		Private Const categoriesCount As Integer = 6
		Private m_Chart As NChart
		Private m_Bar1 As NBarSeries
		Private m_Bar2 As NBarSeries
		Private m_Bar3 As NBarSeries
		Private label5 As System.Windows.Forms.Label
		Private WithEvents BarShapeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents PositiveNegativeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents PositiveData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportPDFButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportFlashButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportSilverlightButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportEMFButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ExportSVGButton As UI.WinForm.Controls.NButton
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
			Me.PositiveNegativeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.PositiveData = New Nevron.UI.WinForm.Controls.NButton()
			Me.label5 = New System.Windows.Forms.Label()
			Me.BarShapeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.ExportPDFButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportFlashButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportSilverlightButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportEMFButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ExportSVGButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' PositiveNegativeData
			' 
			Me.PositiveNegativeData.Location = New System.Drawing.Point(5, 99)
			Me.PositiveNegativeData.Name = "PositiveNegativeData"
			Me.PositiveNegativeData.Size = New System.Drawing.Size(169, 32)
			Me.PositiveNegativeData.TabIndex = 3
			Me.PositiveNegativeData.Text = "Positive and Negative Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveNegativeData.Click += new System.EventHandler(this.PositiveNegativeDataButton_Click);
			' 
			' PositiveData
			' 
			Me.PositiveData.Location = New System.Drawing.Point(5, 61)
			Me.PositiveData.Name = "PositiveData"
			Me.PositiveData.Size = New System.Drawing.Size(169, 32)
			Me.PositiveData.TabIndex = 2
			Me.PositiveData.Text = "Positive Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.PositiveData.Click += new System.EventHandler(this.PositiveDataButton_Click);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(5, 8)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(169, 16)
			Me.label5.TabIndex = 0
			Me.label5.Text = "Bar Shape:"
			' 
			' BarShapeCombo
			' 
			Me.BarShapeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BarShapeCombo.ListProperties.DataSource = Nothing
			Me.BarShapeCombo.ListProperties.DisplayMember = ""
			Me.BarShapeCombo.Location = New System.Drawing.Point(5, 24)
			Me.BarShapeCombo.Name = "BarShapeCombo"
			Me.BarShapeCombo.Size = New System.Drawing.Size(169, 21)
			Me.BarShapeCombo.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BarShapeCombo.SelectedIndexChanged += new System.EventHandler(this.BarShapeCombo_SelectedIndexChanged);
			' 
			' ExportPDFButton
			' 
			Me.ExportPDFButton.Location = New System.Drawing.Point(5, 184)
			Me.ExportPDFButton.Name = "ExportPDFButton"
			Me.ExportPDFButton.Size = New System.Drawing.Size(169, 32)
			Me.ExportPDFButton.TabIndex = 4
			Me.ExportPDFButton.Text = "Export to PDF"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportPDFButton.Click += new System.EventHandler(this.ExportPDFButton_Click);
			' 
			' ExportFlashButton
			' 
			Me.ExportFlashButton.Location = New System.Drawing.Point(5, 276)
			Me.ExportFlashButton.Name = "ExportFlashButton"
			Me.ExportFlashButton.Size = New System.Drawing.Size(169, 32)
			Me.ExportFlashButton.TabIndex = 6
			Me.ExportFlashButton.Text = "Export to Flash"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportFlashButton.Click += new System.EventHandler(this.ExportFlashButton_Click);
			' 
			' ExportSilverlightButton
			' 
			Me.ExportSilverlightButton.Location = New System.Drawing.Point(5, 322)
			Me.ExportSilverlightButton.Name = "ExportSilverlightButton"
			Me.ExportSilverlightButton.Size = New System.Drawing.Size(169, 32)
			Me.ExportSilverlightButton.TabIndex = 7
			Me.ExportSilverlightButton.Text = "Export to Silverlight"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportSilverlightButton.Click += new System.EventHandler(this.ExportSilverlightButton_Click);
			' 
			' ExportEMFButton
			' 
			Me.ExportEMFButton.Location = New System.Drawing.Point(5, 368)
			Me.ExportEMFButton.Name = "ExportEMFButton"
			Me.ExportEMFButton.Size = New System.Drawing.Size(169, 32)
			Me.ExportEMFButton.TabIndex = 8
			Me.ExportEMFButton.Text = "Export to Metafile"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportEMFButton.Click += new System.EventHandler(this.ExportEMFButton_Click);
			' 
			' ExportSVGButton
			' 
			Me.ExportSVGButton.Location = New System.Drawing.Point(6, 230)
			Me.ExportSVGButton.Name = "ExportSVGButton"
			Me.ExportSVGButton.Size = New System.Drawing.Size(169, 32)
			Me.ExportSVGButton.TabIndex = 5
			Me.ExportSVGButton.Text = "Export to SVG"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ExportSVGButton.Click += new System.EventHandler(this.ExportSVGButton_Click);
			' 
			' NVectorImageExportUC
			' 
			Me.Controls.Add(Me.ExportSVGButton)
			Me.Controls.Add(Me.ExportEMFButton)
			Me.Controls.Add(Me.ExportSilverlightButton)
			Me.Controls.Add(Me.ExportFlashButton)
			Me.Controls.Add(Me.ExportPDFButton)
			Me.Controls.Add(Me.BarShapeCombo)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.PositiveNegativeData)
			Me.Controls.Add(Me.PositiveData)
			Me.Name = "NVectorImageExportUC"
			Me.Size = New System.Drawing.Size(180, 484)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Function CreateAnimationsStyle() As NAnimationsStyle
			Dim animationsStyle As New NAnimationsStyle()

			Dim scaleAnimation As New NScaleAnimation()
			scaleAnimation.StartScale = New NPointF(1, 0)
			scaleAnimation.EndScale = New NPointF(1, 1)

			scaleAnimation.AnchorX = 0
			scaleAnimation.AnchorY = 0

			scaleAnimation.Duration = 3
			animationsStyle.Animations.Add(scaleAnimation)

			Return animationsStyle
		End Function

		Private Sub ApplyIndividualAnimation(ByVal series As NBarSeries, ByVal start As Integer, ByVal duration As Integer)
			For i As Integer = 0 To series.Values.Count - 1
				Dim animationsStyle As New NAnimationsStyle()

				Dim scaleAnimation As New NScaleAnimation()
				scaleAnimation.StartScale = New NPointF(1, 0)
				scaleAnimation.EndScale = New NPointF(1, 1)

				scaleAnimation.AnchorX = 0
				scaleAnimation.AnchorY = 1

				scaleAnimation.StartTime = start
				scaleAnimation.Duration = 3
				animationsStyle.Animations.Add(scaleAnimation)

				start += duration

				series.AnimationsStyles(i) = animationsStyle
			Next i
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Vector Image Export")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			' configure the chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Enable3D = False
			m_Chart.Axis(StandardAxis.Depth).Visible = False
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.BrightCameraLight)

			' add interlace stripe
			Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			stripStyle.SetShowAtWall(ChartWallType.Left, True)
			linearScale.StripStyles.Add(stripStyle)

			' add the first bar
			m_Bar1 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar1.Name = "Bar1"
			m_Bar1.MultiBarMode = MultiBarMode.Series
			m_Bar1.DataLabelStyle.Visible = False

			' add the second bar
			m_Bar2 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar2.Name = "Bar2"
			m_Bar2.MultiBarMode = MultiBarMode.Stacked
			m_Bar2.DataLabelStyle.Visible = False

			' add the third bar
			m_Bar3 = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar3.Name = "Bar3"
			m_Bar3.MultiBarMode = MultiBarMode.Stacked
			m_Bar3.DataLabelStyle.Visible = False

			PositiveDataButton_Click(Nothing, Nothing)

			' apply layout
			ConfigureStandardLayout(m_Chart, title, nChartControl1.Legends(0))

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
			styleSheet.Apply(nChartControl1.Document)

			' init form controls
			BarShapeCombo.FillFromEnum(GetType(BarShape))
			BarShapeCombo.SelectedIndex = 0
		End Sub

		Private Sub PositiveDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveData.Click
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, 10, 100)
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, 10, 100)

			nChartControl1.Refresh()
		End Sub
		Private Sub PositiveNegativeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PositiveNegativeData.Click
			m_Bar1.Values.FillRandomRange(Random, categoriesCount, -100, 100)
			m_Bar2.Values.FillRandomRange(Random, categoriesCount, -100, 100)
			m_Bar3.Values.FillRandomRange(Random, categoriesCount, -100, 100)

			nChartControl1.Refresh()
		End Sub
		Private Sub BarShapeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarShapeCombo.SelectedIndexChanged
			m_Bar1.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)
			m_Bar2.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)
			m_Bar3.BarShape = CType(BarShapeCombo.SelectedIndex, BarShape)

			nChartControl1.Refresh()
		End Sub

		Private Sub ExportPDFButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportPDFButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.pdf"

				Dim fmt As New NPdfImageFormat()
				fmt.CompressContentStream = True
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub
		Private Sub ExportFlashButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportFlashButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.swf"

				Dim fmt As New NSwfImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub
		Private Sub ExportSilverlightButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportSilverlightButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.xaml"

				Dim fmt As New NXamlImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub
		Private Sub ExportEMFButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportEMFButton.Click
			Try
				Dim path As String = Application.StartupPath & "\ChartExport.emf"

				Dim fmt As New NEmfImageFormat()
				nChartControl1.ImageExporter.SaveToFile(path, fmt)

				Process.Start(path)
			Catch x As Exception
				MessageBox.Show(x.Message)
			End Try
		End Sub

		Private Sub ExportSVGButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExportSVGButton.Click
			Dim path As String = Application.StartupPath & "\ChartExport.svg"

			Dim fmt As New NSvgImageFormat()
			nChartControl1.ImageExporter.SaveToFile(path, fmt)

			Process.Start(path)
		End Sub
	End Class
End Namespace
