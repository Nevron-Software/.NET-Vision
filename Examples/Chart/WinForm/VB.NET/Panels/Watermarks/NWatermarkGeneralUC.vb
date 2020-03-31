Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NWatermarkGeneralUC
		Inherits NExampleBaseUC
		Private m_ContentPanel As NDockPanel
		Private m_ReviewLabel As NLabel

		Private WithEvents TransparencyScrollBar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label3 As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
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
			Me.TransparencyScrollBar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label3 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' TransparencyScrollBar
			' 
			Me.TransparencyScrollBar.Location = New System.Drawing.Point(7, 36)
			Me.TransparencyScrollBar.Maximum = 110
			Me.TransparencyScrollBar.MinimumSize = New System.Drawing.Size(32, 16)
			Me.TransparencyScrollBar.Name = "TransparencyScrollBar"
			Me.TransparencyScrollBar.Size = New System.Drawing.Size(164, 16)
			Me.TransparencyScrollBar.TabIndex = 1
'			Me.TransparencyScrollBar.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.TransparencyScrollBar_Scroll);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(7, 18)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(155, 16)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Transparency:"
			' 
			' NWatermarkGeneralUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.TransparencyScrollBar)
			Me.Name = "NWatermarkGeneralUC"
			Me.Size = New System.Drawing.Size(180, 594)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dim palette As Nevron.UI.WinForm.Controls.NPalette = NUIManager.Palette

			' remove all default panels
			nChartControl1.Panels.Clear()

			Dim header As NLabel = New NLabel("Watermarks")
			header.DockMode = PanelDockMode.Top
			header.Padding = New NMarginsL(0, 10, 0, 10)
			header.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			header.TextStyle.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.DarkKhaki, Color.White)
			header.ContentAlignment = ContentAlignment.BottomLeft
			header.BackgroundFillStyle = New NGradientFillStyle(Color.White, Color.Black)
			nChartControl1.Panels.Add(header)

			' create the content panel (review + preview panels)
			m_ContentPanel = New NDockPanel()
			m_ContentPanel.DockMode = PanelDockMode.Fill
			m_ContentPanel.BackgroundFillStyle = New NGradientFillStyle(Color.Black, Color.White)

			' create preview panels
			m_ContentPanel.ChildPanels.Add(CreateConceptCarPreviewPanel())

			' cretae review panel
			m_ContentPanel.ChildPanels.Add(CreateConceptCarReviewPanel())
			nChartControl1.Panels.Add(m_ContentPanel)
			AddHandler nChartControl1.MouseDown, AddressOf ChartControl_OnMouseDown
			AddHandler nChartControl1.MouseMove, AddressOf ChartControl_OnMouseMove

			TransparencyScrollBar.Maximum = 110
			TransparencyScrollBar.Value = 50
		End Sub

		Private Function CreateConceptCarPreviewPanel() As NDockPanel
			Dim conceptCarPreviewPanel As NDockPanel = New NDockPanel()
			conceptCarPreviewPanel.DockMode = PanelDockMode.Left
			conceptCarPreviewPanel.Size = New NSizeL(New NLength(30, NRelativeUnit.ParentPercentage), New NLength(100, NRelativeUnit.ParentPercentage))

			Dim cars As CarData() = New CarData() { New CarData("ConceptCar1.png", "Sebastian Calamari", New Double(){ 60, 42, 76, 41 }), New CarData("ConceptCar2.png", "Oliver Dang", New Double(){ 40, 52, 46, 81 }), New CarData("ConceptCar3.png", "Zoran Sirotic", New Double(){ 76, 66, 24, 65 }) }

			Dim i As Integer = 0
			Do While i < cars.Length
				CreateConceptCarPanels(conceptCarPreviewPanel, cars(i))
				i += 1
			Loop

			Return conceptCarPreviewPanel
		End Function
		Private Function CreateConceptCarReviewPanel() As NDockPanel
			Dim dockPanel As NDockPanel = New NDockPanel()
			dockPanel.DockMode = PanelDockMode.Fill

			m_ReviewLabel = New NLabel("Select concept car to review")
			m_ReviewLabel.DockMode = PanelDockMode.Top
			m_ReviewLabel.TextStyle.ShadowStyle.Type = ShadowType.Solid
			m_ReviewLabel.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			m_ReviewLabel.TextStyle.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.DarkKhaki, Color.White)
			m_ReviewLabel.BoundsMode = BoundsMode.None
			m_ReviewLabel.ContentAlignment = ContentAlignment.MiddleCenter
			m_ReviewLabel.UseAutomaticSize = False
			m_ReviewLabel.Size = New NSizeL(New NLength(100, NRelativeUnit.ParentPercentage), New NLength(10, NRelativeUnit.ParentPercentage))
			dockPanel.ChildPanels.Add(m_ReviewLabel)

			' setup chart
			Dim chart As NChart = New NCartesianChart()
			chart.Enable3D = True
			chart.DockMode = PanelDockMode.Fill
			chart.BoundsMode = BoundsMode.Fit
			chart.Padding = New NMarginsL(20, 20, 20, 20)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.MetallicLustre)
			chart.Projection.SetPredefinedProjection(PredefinedProjection.Perspective1)

			chart.Axis(StandardAxis.Depth).Visible = False

			Dim scaleX As NOrdinalScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			scaleX.AutoLabels = False
			scaleX.Labels.Add("Design")
			scaleX.Labels.Add("Functionality")
			scaleX.Labels.Add("Price")
			scaleX.Labels.Add("Speed")

			Dim bar As NBarSeries = New NBarSeries()
			chart.Series.Add(bar)
			bar.BarShape = BarShape.SmoothEdgeBar
			bar.DataLabelStyle.Format = "<value>"
			bar.Values.AddRange(New Double() { 0, 0, 0, 0 })

			' apply predefined style sheet to the pie
			NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.CoolMultiColor).Apply(bar)

			dockPanel.ChildPanels.Add(chart)

			Return dockPanel
		End Function

		Private Sub CreateConceptCarPanels(ByVal parentPanel As NDockPanel, ByVal car As CarData)
			Dim conceptImage As Bitmap = NResourceHelper.BitmapFromResource(Me.GetType(), car.ImageResourceName, "Nevron.Examples.Chart.WinForm.Resources")

			Dim label As NLabel = New NLabel(car.AuthorName)
			label.DockMode = PanelDockMode.Top
			label.BoundsMode = BoundsMode.Fit
			label.UseAutomaticSize = True
			label.Padding = New NMarginsL(10, 0, 0, 0)
			label.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			label.TextStyle.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.DarkKhaki, Color.White)
			parentPanel.ChildPanels.Add(label)

			Dim watermark As NWatermark = New NWatermark()
			watermark.FillStyle = New NImageFillStyle(conceptImage)
			watermark.DockMode = PanelDockMode.Top
			watermark.UseAutomaticSize = True
			watermark.Padding = New NMarginsL(10, 0, 0, 0)
			watermark.Tag = car
			parentPanel.ChildPanels.Add(watermark)
		End Sub
		Private Function SetWatermarkTransparency(ByVal alpha As Byte) As Boolean
			Dim alphaChanged As Boolean = False

			Dim i As Integer = 0
			Do While i < nChartControl1.Watermarks.Count
				Dim watermark As NWatermark = CType(nChartControl1.Watermarks(i), NWatermark)

				If Not watermark.Tag Is Nothing Then
					Dim imageFillStyle As NImageFillStyle = TryCast(watermark.FillStyle, NImageFillStyle)

					If Not imageFillStyle Is Nothing Then
						If imageFillStyle.Alpha <> alpha Then
							imageFillStyle.Alpha = alpha
							alphaChanged = True
						End If
					End If
				End If
				i += 1
			Loop

			Return alphaChanged
		End Function

		Private Sub ChartControl_OnMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			Dim watermark As NWatermark = TryCast(result.Object, NWatermark)
			If watermark Is Nothing Then
				Return
			End If

			Dim car As CarData = TryCast(watermark.Tag, CarData)
			If car Is Nothing Then
				Return
			End If

			m_ReviewLabel.Text = "Concept car from " & car.AuthorName

			Dim series As NSeries = CType(nChartControl1.Charts(0).Series(0), NSeries)
			series.Values.Clear()
			series.Values.AddRange(car.Values)

			nChartControl1.Refresh()
		End Sub
		Private Sub ChartControl_OnMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
			If Not nChartControl1.Controller.ActiveTool Is Nothing Then
				Return
			End If

			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)
			Dim watermark As NWatermark = TryCast(result.Object, NWatermark)

			If watermark Is Nothing OrElse watermark.Tag Is Nothing Then
				If SetWatermarkTransparency(CByte(TransparencyScrollBar.Value * 255 / 100)) Then
					nChartControl1.Refresh()
				End If
			Else
				Dim imageFillStyle As NImageFillStyle = CType(watermark.FillStyle, NImageFillStyle)

				If imageFillStyle.Alpha <> 255 Then
					SetWatermarkTransparency(CByte(TransparencyScrollBar.Value * 255 / 100))
					imageFillStyle.Alpha = 255
					nChartControl1.Refresh()
				End If
			End If
		End Sub
		Private Sub TransparencyScrollBar_Scroll(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles TransparencyScrollBar.ValueChanged
			If SetWatermarkTransparency(CByte(TransparencyScrollBar.Value * 255 / 100)) Then
				nChartControl1.Refresh()
			End If
		End Sub

		<Serializable> _
		Private Class CarData
'INSTANT VB NOTE: The parameter imageResourceName was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter authorName was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter values was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
			Friend Sub New(ByVal imageResourceName_Renamed As String, ByVal authorName_Renamed As String, ByVal values_Renamed As Double())
				Me.ImageResourceName = imageResourceName_Renamed
				Me.AuthorName = authorName_Renamed
				Me.Values = values_Renamed
			End Sub

			Friend ImageResourceName As String
			Friend AuthorName As String
			Friend Values As Double()
		End Class
	End Class
End Namespace
