Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Nevron.Chart
Imports Nevron.Chart.Windows
Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports System.Collections.Generic

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NGridSurfaceVerticalCrossSectionUC
		Inherits NExampleBaseUC

		Private label1 As Label
		Private WithEvents DragPlaneComboBox As UI.WinForm.Controls.NComboBox
		Private components As System.ComponentModel.Container = Nothing

		Private m_DragPlane As NDragPlane
		Private m_DragPlaneTool As NDragPlaneTool
		Private m_CrossSection2DSeries As NLineSeries
		Private m_CrossSection3DSeries As NPointSeries
		Private m_SurfaceSeries As NGridSurfaceSeries

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
			Me.DragPlaneComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(11, 11)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(131, 14)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Drag Plane:"
			' 
			' DragPlaneComboBox
			' 
			Me.DragPlaneComboBox.ListProperties.CheckBoxDataMember = ""
			Me.DragPlaneComboBox.ListProperties.DataSource = Nothing
			Me.DragPlaneComboBox.ListProperties.DisplayMember = ""
			Me.DragPlaneComboBox.Location = New System.Drawing.Point(11, 27)
			Me.DragPlaneComboBox.Name = "DragPlaneComboBox"
			Me.DragPlaneComboBox.Size = New System.Drawing.Size(151, 21)
			Me.DragPlaneComboBox.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DragPlaneComboBox.SelectedIndexChanged += new System.EventHandler(this.DragPlaneComboBox_SelectedIndexChanged);
			' 
			' NGridSurfaceVerticalCrossSectionUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.DragPlaneComboBox)
			Me.Name = "NGridSurfaceVerticalCrossSectionUC"
			Me.Size = New System.Drawing.Size(180, 211)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' Enable GPU acceleration
			nChartControl1.Settings.RenderSurface = RenderSurface.Window

			nChartControl1.Panels.Clear()

			' set a chart title
			Dim title As New NLabel("Grid Surface Cross Section")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.DockMode = PanelDockMode.Top
			title.Margins = New NMarginsL(10)
			nChartControl1.Panels.Add(title)

			Dim containerPanel As New NDockPanel()
			containerPanel.PositionChildPanelsInContentBounds = True
			containerPanel.Margins = New NMarginsL(10, 0, 10, 10)
			containerPanel.DockMode = PanelDockMode.Fill
			nChartControl1.Panels.Add(containerPanel)

			' configure the chart
			Dim surfaceChart As New NCartesianChart()
			containerPanel.ChildPanels.Add(surfaceChart)
			surfaceChart.DockMode = PanelDockMode.Top
			surfaceChart.Size = New NSizeL(New NLength(0.0F), New NLength(70.0F, NRelativeUnit.ParentPercentage))
			surfaceChart.Enable3D = True
			surfaceChart.Width = 60.0F
			surfaceChart.Depth = 60.0F
			surfaceChart.Height = 15.0F
			surfaceChart.BoundsMode = BoundsMode.Fit
			surfaceChart.Projection.SetPredefinedProjection(PredefinedProjection.PerspectiveTilted)
			surfaceChart.Projection.Elevation = 22
			surfaceChart.Projection.Rotation = -68
			surfaceChart.LightModel.SetPredefinedLightModel(PredefinedLightModel.ShinyTopLeft)

			' setup axes
			Dim ordinalScale As NOrdinalScaleConfigurator = CType(surfaceChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			ordinalScale = CType(surfaceChart.Axis(StandardAxis.Depth).ScaleConfigurator, NOrdinalScaleConfigurator)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, True)
			ordinalScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, True)
			ordinalScale.DisplayDataPointsBetweenTicks = False

			' add the surface series
			m_SurfaceSeries = New NGridSurfaceSeries()
			surfaceChart.Series.Add(m_SurfaceSeries)
			m_SurfaceSeries.Name = "Surface"
			m_SurfaceSeries.Legend.Mode = SeriesLegendMode.SeriesLogic
			m_SurfaceSeries.PositionValue = 10.0
			m_SurfaceSeries.Data.SetGridSize(1000, 1000)
			m_SurfaceSeries.SyncPaletteWithAxisScale = False
			m_SurfaceSeries.PaletteSteps = 8
			m_SurfaceSeries.ValueFormatter.FormatSpecifier = "0.00"
			m_SurfaceSeries.FillStyle = New NColorFillStyle(Color.YellowGreen)
			m_SurfaceSeries.ShadingMode = ShadingMode.Smooth
			m_SurfaceSeries.FrameMode = SurfaceFrameMode.None
			m_SurfaceSeries.FillMode = SurfaceFillMode.ZoneTexture

			' add the cross section line series
			m_CrossSection3DSeries = New NPointSeries()
			surfaceChart.Series.Add(m_CrossSection3DSeries)
			m_CrossSection3DSeries.Size = New NLength(10)
			m_CrossSection3DSeries.PointShape = PointShape.Sphere
			m_CrossSection3DSeries.FillStyle = New NColorFillStyle(Color.Red)
			m_CrossSection3DSeries.DataLabelStyle.Visible = False
			m_CrossSection3DSeries.UseXValues = True
			m_CrossSection3DSeries.UseZValues = True

			FillData(m_SurfaceSeries)

			Dim crossSectionChart As New NCartesianChart()

			crossSectionChart.BoundsMode = BoundsMode.Stretch
			crossSectionChart.DockMode = PanelDockMode.Fill
			crossSectionChart.Margins = New NMarginsL(0, 10, 0, 0)

			crossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
			crossSectionChart.Axis(StandardAxis.PrimaryX).ScaleConfigurator.Title.Text = "Distance"
			crossSectionChart.Axis(StandardAxis.PrimaryY).ScaleConfigurator.Title.Text = "Value"

			m_CrossSection2DSeries = New NLineSeries()
			m_CrossSection2DSeries.DataLabelStyle.Visible = False
			m_CrossSection2DSeries.UseXValues = True
			crossSectionChart.Series.Add(m_CrossSection2DSeries)

			containerPanel.ChildPanels.Add(crossSectionChart)

			nChartControl1.View.RecalcLayout()

			Dim xAxisRange As NRange1DD = surfaceChart.Axis(StandardAxis.PrimaryX).Scale.RulerRange
			Dim yAxisRange As NRange1DD = surfaceChart.Axis(StandardAxis.PrimaryY).Scale.RulerRange
			Dim zAxisRange As NRange1DD = surfaceChart.Axis(StandardAxis.Depth).Scale.RulerRange

			m_DragPlane = New NDragPlane(New NVector3DD(0, yAxisRange.End, 0), New NVector3DD(xAxisRange.End, yAxisRange.End, zAxisRange.End), New NVector3DD(xAxisRange.End, 0, zAxisRange.End), New NVector3DD(0, 0, 0))

			AddHandler m_DragPlane.DragPlaneChanged, AddressOf OnDragPlaneChanged
			m_DragPlaneTool = New NDragPlaneTool(m_DragPlane)
			m_DragPlane.AddToChart(surfaceChart)

			nChartControl1.Controller.Tools.Add(New NPanelSelectorTool())
			nChartControl1.Controller.Tools.Add(m_DragPlaneTool)
			nChartControl1.Controller.Tools.Add(New NTrackballTool())

			' enable fixed axis ranges
			surfaceChart.Axis(StandardAxis.PrimaryX).View = New NRangeAxisView(xAxisRange, True, True)
			surfaceChart.Axis(StandardAxis.PrimaryY).View = New NRangeAxisView(yAxisRange, True, True)
			surfaceChart.Axis(StandardAxis.Depth).View = New NRangeAxisView(zAxisRange, True, True)

			' turn off plot box clipping
			surfaceChart.Axis(StandardAxis.PrimaryX).ClipMode = AxisClipMode.Never
			surfaceChart.Axis(StandardAxis.PrimaryY).ClipMode = AxisClipMode.Never
			surfaceChart.Axis(StandardAxis.Depth).ClipMode = AxisClipMode.Never

			DragPlaneComboBox.Items.Add("XY")
			DragPlaneComboBox.Items.Add("XZ")
			DragPlaneComboBox.Items.Add("ZY")
			DragPlaneComboBox.SelectedIndex = 1

			' update the cross section
			OnDragPlaneChanged(Nothing, Nothing)
		End Sub

		Private Sub FillData(ByVal surface As NGridSurfaceSeries)
			Dim stream As Stream = Nothing
			Dim reader As BinaryReader = Nothing

			Try
				' fill the XYZ data from a binary resource
				stream = NResourceHelper.GetResourceStream(Me.GetType().Assembly, "DataY.bin", "Nevron.Examples.Chart.WinForm.Resources")
				reader = New BinaryReader(stream)

				Dim dataPointsCount As Integer = CInt(stream.Length \ 4)
				Dim sizeX As Integer = CInt(Math.Truncate(Math.Sqrt(dataPointsCount)))
				Dim sizeZ As Integer = sizeX

				surface.Data.SetGridSize(sizeX, sizeZ)

				For z As Integer = 0 To sizeZ - 1
					For x As Integer = 0 To sizeX - 1
						surface.Data.SetValue(x, z, reader.ReadSingle())
					Next x
				Next z
			Finally
				If reader IsNot Nothing Then
					reader.Close()
				End If

				If stream IsNot Nothing Then
					stream.Close()
				End If
			End Try
		End Sub

		Private Sub OnDragPlaneChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim intersections3D As List(Of NVector3DD) = m_SurfaceSeries.Get3DIntersections(New NPointD(m_DragPlane.PointA.X, m_DragPlane.PointA.Z), New NPointD(m_DragPlane.PointB.X, m_DragPlane.PointB.Z))
			Dim intersections2D As List(Of NVector2DD) = m_SurfaceSeries.Get2DIntersections(New NPointD(m_DragPlane.PointA.X, m_DragPlane.PointA.Z), New NPointD(m_DragPlane.PointB.X, m_DragPlane.PointB.Z))

			m_CrossSection3DSeries.ClearDataPoints()

			For i As Integer = 0 To intersections3D.Count - 1
				Dim intersection3D As NVector3DD = intersections3D(i)

				m_CrossSection3DSeries.Values.Add(intersection3D.Z + 1)
				m_CrossSection3DSeries.XValues.Add(intersection3D.X)
				m_CrossSection3DSeries.ZValues.Add(intersection3D.Y)
			Next i

			m_CrossSection2DSeries.ClearDataPoints()

			For i As Integer = 0 To intersections2D.Count - 1
				Dim intersection2D As NVector2DD = intersections2D(i)

				m_CrossSection2DSeries.Values.Add(intersection2D.Y)
				m_CrossSection2DSeries.XValues.Add(intersection2D.X)
			Next i

			nChartControl1.Refresh()
		End Sub

		Private Sub DragPlaneComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DragPlaneComboBox.SelectedIndexChanged
			Select Case DragPlaneComboBox.SelectedIndex
				Case 0
					m_DragPlaneTool.DragPlane = DragPlaneSurface.XY
				Case 1
					m_DragPlaneTool.DragPlane = DragPlaneSurface.XZ
				Case 2
					m_DragPlaneTool.DragPlane = DragPlaneSurface.ZY
			End Select
		End Sub
	End Class

	Public Enum DragPlaneSurface
		XY
		XZ
		ZY
	End Enum

	<Serializable>
	Public Class NDragPlaneTool
		Inherits NDragTool

		#Region "Constructors"

		''' <summary>
		''' Initializer constructor
		''' </summary>
		''' <param name="dragPlane"></param>
		Public Sub New(ByVal dragPlane As NDragPlane)
			m_DragPlane = dragPlane
			m_OriginalPosition = New NVector3DD()
		End Sub

		#End Region

		#Region "Properties"

		''' <summary>
		''' The freedom plane
		''' </summary>
		Public Property DragPlane() As DragPlaneSurface
			Get
				Return m_DragPlaneSurface
			End Get
			Set(ByVal value As DragPlaneSurface)
				m_DragPlaneSurface = value
			End Set
		End Property
		''' <summary>
		''' Whether to use x locking
		''' </summary>
		Public Shared ReadOnly Property LockX() As Boolean
			Get
				Return (m_LockXKey And Control.ModifierKeys) <> 0
			End Get
		End Property
		''' <summary>
		''' Whether to use Z locking
		''' </summary>
		Public Shared ReadOnly Property LockZ() As Boolean
			Get
				Return (m_LockZKey And Control.ModifierKeys) <> 0
			End Get
		End Property

		#End Region

		#Region "Overrides"

		''' <summary>
		''' 
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Public Overrides Sub OnMouseMove(ByVal sender As Object, ByVal e As Nevron.Chart.Windows.NMouseEventArgs)
			MyBase.OnMouseMove(sender, e)

			m_LastMousePosition = e
		End Sub
		''' <summary>
		''' Return true if dragging can start
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		''' <returns></returns>
		Public Overrides Function CanBeginDrag(ByVal sender As Object, ByVal e As Nevron.Chart.Windows.NMouseEventArgs) As Boolean
			If Not MyBase.CanBeginDrag(sender, e) Then
				Return False
			End If

			m_LastMousePosition = e
			Dim dataPointIndex As Integer = GetDataPointIndexFromPoint(New NPoint(e.X, e.Y))

			If dataPointIndex = -1 Then
				Return False
			End If

			m_DataPointIndex = dataPointIndex
			m_OriginalPosition = m_DragPlane.GetVectorFromPoint(m_DataPointIndex)

			Return True
		End Function
		''' <summary>
		''' Fired when key down is pressed
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Public Overrides Sub OnKeyDown(ByVal sender As Object, ByVal e As NKeyEventArgs)
			MyBase.OnKeyDown(sender, e)

			If LockX OrElse LockZ Then
				m_DragPlane.LockX = LockX
				m_DragPlane.LockZ = LockZ

				Dim dataPointIndex As Integer = GetDataPointIndexFromPoint(New NPoint(m_LastMousePosition.X, m_LastMousePosition.Y))

				If dataPointIndex <> -1 Then
					If LockX Then
						m_DragPlane.OrientPlaneX(dataPointIndex)
					ElseIf LockZ Then
						m_DragPlane.OrientPlaneZ(dataPointIndex)
					End If

					Me.Repaint()
				End If
			End If
		End Sub
		''' <summary>
		''' Overriden to perform dragging
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Public Overrides Sub OnDoDrag(ByVal sender As Object, ByVal e As Nevron.Chart.Windows.NMouseEventArgs)
			Dim chart As NChart = Me.GetDocument().Charts(0)

			Dim viewToScale As NViewToScale3DTransformation

			Select Case m_DragPlaneSurface
				Case DragPlaneSurface.XY
					viewToScale = New NViewToScale3DTransformation(chart, CInt(StandardAxis.PrimaryX), CInt(StandardAxis.PrimaryY), CInt(StandardAxis.Depth), m_OriginalPosition.Z)
				Case DragPlaneSurface.XZ
					viewToScale = New NViewToScale3DTransformation(chart, CInt(StandardAxis.PrimaryX), CInt(StandardAxis.Depth), CInt(StandardAxis.PrimaryY), m_OriginalPosition.Y)
				Case DragPlaneSurface.ZY
					viewToScale = New NViewToScale3DTransformation(chart, CInt(StandardAxis.Depth), CInt(StandardAxis.PrimaryY), CInt(StandardAxis.PrimaryX), m_OriginalPosition.X)
				Case Else
					Debug.Assert(False) ' new drag plane
					Return
			End Select

			Dim vecNewPosition As New NVector3DD()
			viewToScale.Transform(New NPointF(e.X, e.Y), vecNewPosition)

			m_DragPlane.LockX = False
			m_DragPlane.LockZ = False

			If LockX Then
				m_DragPlane.LockX = True
			ElseIf LockZ Then
				m_DragPlane.LockZ = True
			End If

			m_DragPlane.MovePoint(m_DragPlaneSurface, vecNewPosition, m_DataPointIndex)
			m_DragPlane.PointSeries.Document.Refresh()
		End Sub
		''' <summary>
		''' Overriden to rever the state to the original one if the user presses Esc key
		''' </summary>
		Public Overrides Sub CancelOperation()
			MyBase.CancelOperation()

			m_DragPlane.RestorePoint(m_DataPointIndex, m_OriginalPosition)
			m_DragPlane.PointSeries.Document.Refresh()
		End Sub

		#End Region

		#Region "Implementation"

		''' <summary>
		''' Gets the selected data points
		''' </summary>
		''' <returns></returns>
		Protected Function GetSelectedDataPoints() As ArrayList
			Dim selection As NSelection = GetSelection()

			If selection Is Nothing Then
				Return Nothing
			End If

			Return selection.GetSelectedObjectsOfType(GetType(NDataPoint))
		End Function
		''' <summary>
		''' Gets the data point from the specified point
		''' </summary>
		''' <param name="point"></param>
		''' <returns></returns>
		Protected Function GetDataPointIndexFromPoint(ByVal point As NPoint) As Integer
			Dim pointSeries As NPointSeries = m_DragPlane.PointSeries
			Dim chart As NChart = pointSeries.Chart
			Dim model3DToViewTransformation As New NModel3DToViewTransformation(GetView().Context, chart.Projection)

			Dim xHotSpotArea As Single = 10
			Dim yHotSpotArea As Single = 10

			Dim dataPointIndex As Integer = -1

			For i As Integer = 0 To pointSeries.Values.Count - 1
				Dim x As Double = DirectCast(pointSeries.XValues(i), Double)
				Dim y As Double = DirectCast(pointSeries.Values(i), Double)
				Dim z As Double = DirectCast(pointSeries.ZValues(i), Double)

				Dim vecModelPoint As NVector3DF
				vecModelPoint.X = chart.Axis(StandardAxis.PrimaryX).TransformScaleToModel(False, x)
				vecModelPoint.Y = chart.Axis(StandardAxis.PrimaryY).TransformScaleToModel(False, y)
				vecModelPoint.Z = chart.Axis(StandardAxis.Depth).TransformScaleToModel(False, z)

				Dim viewPoint As NPointF = NPointF.Empty
				model3DToViewTransformation.Transform(vecModelPoint, viewPoint)

				If Math.Abs(viewPoint.X - point.X) < xHotSpotArea AndAlso Math.Abs(viewPoint.Y - point.Y) < yHotSpotArea Then
					dataPointIndex = i
					Exit For
				End If
			Next i

			Return dataPointIndex
		End Function


		#End Region

		#Region "Fields"

		''' <summary>
		''' The original position of the point
		''' </summary>
		Protected m_OriginalPosition As NVector3DD
		''' <summary>
		''' The data point index
		''' </summary>
		Protected m_DataPointIndex As Integer
		''' <summary>
		''' The freedom plane
		''' </summary>
		Protected m_DragPlaneSurface As DragPlaneSurface
		''' <summary>
		''' 
		''' </summary>
		Protected m_DragPlane As NDragPlane
		''' <summary>
		''' The last mouse position
		''' </summary>
		Protected m_LastMousePosition As Nevron.Chart.Windows.NMouseEventArgs

		#End Region

		#Region "Static Fields"

		Private Shared m_LockXKey As Keys = Keys.Shift
		Private Shared m_LockZKey As Keys = Keys.Alt

		#End Region
	End Class
	''' <summary>
	''' Simple class for maintaining a draggable plane
	''' </summary>
	Public Class NDragPlane
		#Region "Constructors"

		''' <summary>
		''' Initializer constructor
		''' </summary>
		''' <param name="vecA"></param>
		''' <param name="vecB"></param>
		''' <param name="vecC"></param>
		''' <param name="vecD"></param>
		Public Sub New(ByVal vecA As NVector3DD, ByVal vecB As NVector3DD, ByVal vecC As NVector3DD, ByVal vecD As NVector3DD)
'INSTANT VB NOTE: The variable pointSeries was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim pointSeries_Renamed As New NPointSeries()

			pointSeries_Renamed.Tag = CInt(1)
			pointSeries_Renamed.PointShape = PointShape.Sphere
			pointSeries_Renamed.UseXValues = True
			pointSeries_Renamed.UseZValues = True
			pointSeries_Renamed.DataLabelStyle.Visible = False
			pointSeries_Renamed.InflateMargins = False
			pointSeries_Renamed.Size = New NLength(8)

			pointSeries_Renamed.Values.Add(vecA.Y)
			pointSeries_Renamed.XValues.Add(vecA.X)
			pointSeries_Renamed.ZValues.Add(vecA.Z)
			pointSeries_Renamed.FillStyles(0) = New NColorFillStyle(Color.Red)

			pointSeries_Renamed.Values.Add(vecB.Y)
			pointSeries_Renamed.XValues.Add(vecB.X)
			pointSeries_Renamed.ZValues.Add(vecB.Z)
			pointSeries_Renamed.FillStyles(1) = New NColorFillStyle(Color.Blue)

			pointSeries_Renamed.Values.Add(vecC.Y)
			pointSeries_Renamed.XValues.Add(vecC.X)
			pointSeries_Renamed.ZValues.Add(vecC.Z)
			pointSeries_Renamed.FillStyles(2) = New NColorFillStyle(Color.Blue)


			pointSeries_Renamed.Values.Add(vecD.Y)
			pointSeries_Renamed.XValues.Add(vecD.X)
			pointSeries_Renamed.ZValues.Add(vecD.Z)
			pointSeries_Renamed.FillStyles(3) = New NColorFillStyle(Color.Red)

			m_PointSeries = pointSeries_Renamed

			Dim meshSeries As New NMeshSurfaceSeries()
			meshSeries.Data.SetGridSize(2, 2)

			m_MeshSurface = meshSeries
			m_MeshSurface.FillMode = SurfaceFillMode.Uniform
			m_MeshSurface.FrameMode = SurfaceFrameMode.None
			m_MeshSurface.FillStyle = New NColorFillStyle(Color.Blue)
			m_MeshSurface.FillStyle.SetTransparencyPercent(50.0F)

			UpdateMeshSurface()
		End Sub

		#End Region

		#Region "Properties"

		''' <summary>
		''' Gets the point series
		''' </summary>
		Public ReadOnly Property PointSeries() As NPointSeries
			Get
				Return m_PointSeries
			End Get
		End Property
		''' <summary>
		''' Gets the mesh surface
		''' </summary>
		Public ReadOnly Property MeshSurface() As NMeshSurfaceSeries
			Get
				Return m_MeshSurface
			End Get
		End Property
		''' <summary>
		''' Gets the A point
		''' </summary>
		Public ReadOnly Property PointA() As NVector3DD
			Get
				Return GetVectorFromPoint(0)
			End Get
		End Property
		''' <summary>
		''' Gets the B point
		''' </summary>
		Public ReadOnly Property PointB() As NVector3DD
			Get
				Return GetVectorFromPoint(1)
			End Get
		End Property
		''' <summary>
		''' Gets the C point
		''' </summary>
		Public ReadOnly Property PointC() As NVector3DD
			Get
				Return GetVectorFromPoint(2)
			End Get
		End Property
		''' <summary>
		''' Gets the D point
		''' </summary>
		Public ReadOnly Property PointD() As NVector3DD
			Get
				Return GetVectorFromPoint(3)
			End Get
		End Property
		''' <summary>
		''' Gets or sets whether to lock the x coordinate
		''' </summary>
		Public Property LockX() As Boolean
			Get
				Return m_LockX
			End Get
			Set(ByVal value As Boolean)
				m_LockX = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets whether to lock the z coordinate
		''' </summary>
		Public Property LockZ() As Boolean
			Get
				Return m_LockZ
			End Get
			Set(ByVal value As Boolean)
				m_LockZ = value
			End Set
		End Property

		#End Region

		#Region "Methods"

		''' <summary>
		''' Gets the horizontal plane length 
		''' </summary>
		''' <param name="axisRange"></param>
		''' <param name="origin"></param>
		''' <returns></returns>
		Public Function GetPlaneLength(ByVal axisRange As NRange1DD, ByVal origin As Double, ByVal originPoint As Integer, ByVal xOrZ As Boolean) As Double
			Dim vecA As NVector3DD = GetVectorFromPoint(0)
			Dim vecB As NVector3DD = GetVectorFromPoint(1)

			Dim lengthVector As New NVector3DD()
			lengthVector.Subtract(vecB, vecA)
			Dim orgPlaneLength As Double = lengthVector.GetLength()
			Dim sign As Double

			If originPoint = 0 OrElse originPoint = 2 Then
				' left point
				If xOrZ Then
					sign = If(vecA.X < vecB.X, 1, -1)
				Else
					sign = If(vecA.Z < vecB.Z, 1, -1)
				End If
			Else
				' right point
				If xOrZ Then
					sign = If(vecB.X < vecA.X, 1, -1)
				Else
					sign = If(vecB.Z < vecA.Z, 1, -1)
				End If
			End If

			axisRange.Normalize()

			If sign > 0 Then
				If origin + orgPlaneLength > axisRange.End Then
					orgPlaneLength = axisRange.End - origin
				End If
			Else
				If origin - orgPlaneLength < axisRange.Begin Then
					orgPlaneLength = origin - axisRange.Begin
				End If
			End If

			Return orgPlaneLength * sign
		End Function
		''' <summary>
		''' Adds the plane to the chart
		''' </summary>
		''' <param name="chart"></param>
		Public Sub AddToChart(ByVal chart As NChart)
			chart.Series.Add(m_MeshSurface)
			chart.Series.Add(m_PointSeries)
		End Sub
		''' <summary>
		''' Drags the specified point
		''' </summary>
		''' <param name="dragPlane"></param>
		''' <param name="vector"></param>
		''' <param name="dataPointIndex"></param>
		Public Sub MovePoint(ByVal dragPlane As DragPlaneSurface, ByVal vector As NVector3DD, ByVal dataPointIndex As Integer)
			' modify the point coordinates. Don't modify the y coords only x, z or xz
			' take into account the currently selected axes from NViewToScale3DTransformation
			Select Case dragPlane
				Case DragPlaneSurface.XY
						SetXPointCoordinate(dataPointIndex, ClampXCoordinateToRuler(vector.X))
				Case DragPlaneSurface.XZ
					SetXPointCoordinate(dataPointIndex, ClampXCoordinateToRuler(vector.X))
					SetZPointCoordinate(dataPointIndex, ClampZCoordinateToRuler(vector.Y))
				Case DragPlaneSurface.ZY
					SetZPointCoordinate(dataPointIndex, ClampXCoordinateToRuler(vector.X))
			End Select

			SynchronizePoints(dataPointIndex)
			UpdateMeshSurface()

			FireDragPlaneChanged()
		End Sub
		''' <summary>
		''' Orients the plane in the X direction
		''' </summary>
		''' <param name="anchorPoint"></param>
		Public Sub OrientPlaneX(ByVal anchorPoint As Integer)
			Dim z As Double = GetVectorFromPoint(anchorPoint).Z
			Dim x As Double = GetVectorFromPoint(anchorPoint).X

			Dim hasDifferentXPoint As Boolean = False
			For i As Integer = 0 To 3
				If GetVectorFromPoint(i).X <> x Then
					hasDifferentXPoint = True
				End If
			Next i

			If Not hasDifferentXPoint Then
				Return
			End If

			Dim viewRange As NRange1DD = m_PointSeries.Chart.Axis(StandardAxis.Depth).ViewRange
			Dim planeLength As Double = GetPlaneLength(viewRange, z, anchorPoint, False)

			' make the x coordinate equal
			For i As Integer = 0 To 3
				If i <> anchorPoint Then
					SetXPointCoordinate(i, x)
				End If
			Next i

			For i As Integer = 0 To 3
				If GetVectorFromPoint(i).Z <> z Then
					SetZPointCoordinate(i, z + planeLength)
				End If
			Next i

			' update the plane / intersections
			UpdateMeshSurface()
			FireDragPlaneChanged()
		End Sub
		''' <summary>
		''' Orients the plane in the Z direction
		''' </summary>
		Public Sub OrientPlaneZ(ByVal anchorPoint As Integer)
			Dim z As Double = GetVectorFromPoint(anchorPoint).Z
			Dim x As Double = GetVectorFromPoint(anchorPoint).X

			Dim hasDifferentZPoint As Boolean = False
			For i As Integer = 0 To 3
				If GetVectorFromPoint(i).Z <> z Then
					hasDifferentZPoint = True
				End If
			Next i

			If Not hasDifferentZPoint Then
				Return
			End If

			Dim viewRange As NRange1DD = m_PointSeries.Chart.Axis(StandardAxis.PrimaryX).ViewRange
			Dim planeLength As Double = GetPlaneLength(viewRange, x, anchorPoint, True)

			' make the z coordinate equal
			For i As Integer = 0 To 3
				If i <> anchorPoint Then
					SetZPointCoordinate(i, z)
				End If
			Next i

			For i As Integer = 0 To 3
				If GetVectorFromPoint(i).X <> x Then
					SetXPointCoordinate(i, x + planeLength)
				End If
			Next i

			UpdateMeshSurface()
			FireDragPlaneChanged()
		End Sub
		''' <summary>
		''' Synchronizes the points so that they are coplanar
		''' </summary>
		''' <param name="modifiedPointIndex"></param>
		Public Sub SynchronizePoints(ByVal modifiedPointIndex As Integer)
			' then align points depending on which point is being dragged
			Dim vecA As NVector3DD = GetVectorFromPoint(0)
			Dim vecB As NVector3DD = GetVectorFromPoint(1)
			Dim vecC As NVector3DD = GetVectorFromPoint(2)
			Dim vecD As NVector3DD = GetVectorFromPoint(3)

			Select Case modifiedPointIndex
				Case 0 ' left top
						' sync point 3 (left bottom)
						Dim vecCB As New NVector3DD()
						vecCB.Subtract(vecC, vecB)

						vecD.Add(vecA, vecCB)

						SetVectorToPoint(3, vecD)
				Case 1 ' right top
						' sync point 2 (right bottom)
						Dim vecDA As New NVector3DD()
						vecDA.Subtract(vecD, vecA)

						vecC.Add(vecB, vecDA)

						SetVectorToPoint(2, vecC)
				Case 2 ' right bottom
						' sync point 1 (right top)
						Dim vecAD As New NVector3DD()
						vecAD.Subtract(vecA, vecD)

						vecB.Add(vecC, vecAD)

						SetVectorToPoint(1, vecB)
				Case 3 ' left bottom
						' sync point 0 (left top)
						Dim vecCB As New NVector3DD()
						vecCB.Subtract(vecB, vecC)

						vecA.Add(vecD, vecCB)

						SetVectorToPoint(0, vecA)
			End Select

			' handle x / z locking
			If m_LockX Then
				Dim x As Double = GetVectorFromPoint(modifiedPointIndex).X
				For i As Integer = 0 To 3
					If i <> modifiedPointIndex Then
						SetXPointCoordinate(i, x)
					End If
				Next i
			End If

			If m_LockZ Then
				Dim z As Double = GetVectorFromPoint(modifiedPointIndex).Z

				For i As Integer = 0 To 3
					If i <> modifiedPointIndex Then
						SetZPointCoordinate(i, z)
					End If
				Next i
			End If
		End Sub
		''' <summary>
		''' Restores the position of the point
		''' </summary>
		''' <param name="dataPointIndex"></param>
		''' <param name="vector"></param>
		Public Sub RestorePoint(ByVal dataPointIndex As Integer, ByVal vector As NVector3DD)
			SetVectorToPoint(dataPointIndex, vector)

			SynchronizePoints(dataPointIndex)
			UpdateMeshSurface()

			FireDragPlaneChanged()
		End Sub
		''' <summary>
		''' Gets the vector from the currently selected point
		''' </summary>
		''' <param name="dataPointIndex"></param>
		''' <returns></returns>
		Public Function GetVectorFromPoint(ByVal dataPointIndex As Integer) As NVector3DD
			Dim vector As NVector3DD

			vector.X = DirectCast(m_PointSeries.XValues(dataPointIndex), Double)
			vector.Y = DirectCast(m_PointSeries.Values(dataPointIndex), Double)
			vector.Z = DirectCast(m_PointSeries.ZValues(dataPointIndex), Double)

			Return vector
		End Function

		#End Region

		#Region "Events"

		''' <summary>
		''' Occurs when the drag plane has changed
		''' </summary>
'INSTANT VB NOTE: The 'NonSerialized' attribute cannot be used on events in VB:
'		[field: NonSerialized]
		Public Event DragPlaneChanged As EventHandler

		''' <summary>
		''' Raises the drag plane changed event
		''' </summary>
		Friend Sub FireDragPlaneChanged()
			If m_DragPlaneChanged Then
				m_DragPlaneChanged = False

				RaiseEvent DragPlaneChanged(Me, New EventArgs())
			End If
		End Sub

		#End Region

		#Region "Implementation"

		''' <summary>
		''' Clamps the passed x coordinate to the x axis range
		''' </summary>
		''' <param name="x"></param>
		''' <returns></returns>
		Private Function ClampXCoordinateToRuler(ByVal x As Double) As Double
			Return m_PointSeries.Chart.Axis(StandardAxis.PrimaryX).Scale.RulerRange.GetValueInRange(x)
		End Function
		''' <summary>
		''' Clamps the passed z coordinate to the x axis range
		''' </summary>
		''' <param name="z"></param>
		''' <returns></returns>
		Private Function ClampZCoordinateToRuler(ByVal z As Double) As Double
			Return m_PointSeries.Chart.Axis(StandardAxis.Depth).Scale.RulerRange.GetValueInRange(z)
		End Function
		''' <summary>
		''' Sets the vector to the specified point
		''' </summary>
		''' <param name="dataPointIndex"></param>
		''' <param name="vector"></param>
		Private Sub SetVectorToPoint(ByVal dataPointIndex As Integer, ByVal vector As NVector3DD)
			SetXPointCoordinate(dataPointIndex, vector.X)
			SetYPointCoordinate(dataPointIndex, vector.Y)
			SetZPointCoordinate(dataPointIndex, vector.Z)
		End Sub
		''' <summary>
		''' Sets an x point coordinate
		''' </summary>
		''' <param name="dataPointIndex"></param>
		''' <param name="x"></param>
		Private Sub SetXPointCoordinate(ByVal dataPointIndex As Integer, ByVal x As Double)
			If DirectCast(m_PointSeries.XValues(dataPointIndex), Double) <> x Then
				m_DragPlaneChanged = True
				m_PointSeries.XValues(dataPointIndex) = x
			End If
		End Sub
		''' <summary>
		''' Sets an y point coordinate
		''' </summary>
		''' <param name="dataPointIndex"></param>
		''' <param name="x"></param>
		Private Sub SetYPointCoordinate(ByVal dataPointIndex As Integer, ByVal y As Double)
			If DirectCast(m_PointSeries.XValues(dataPointIndex), Double) <> y Then
				m_DragPlaneChanged = True
				m_PointSeries.Values(dataPointIndex) = y
			End If
		End Sub
		''' <summary>
		''' Sets an y point coordinate
		''' </summary>
		''' <param name="dataPointIndex"></param>
		''' <param name="x"></param>
		Private Sub SetZPointCoordinate(ByVal dataPointIndex As Integer, ByVal z As Double)
			If DirectCast(m_PointSeries.XValues(dataPointIndex), Double) <> z Then
				m_DragPlaneChanged = True
				m_PointSeries.ZValues(dataPointIndex) = z
			End If
		End Sub
		''' <summary>
		''' Updates the mesh surface from the point series
		''' </summary>
		Private Sub UpdateMeshSurface()
			Dim vecA As NVector3DD = GetVectorFromPoint(0)
			Dim vecB As NVector3DD = GetVectorFromPoint(1)
			Dim vecC As NVector3DD = GetVectorFromPoint(2)
			Dim vecD As NVector3DD = GetVectorFromPoint(3)

			m_MeshSurface.Data.SetValue(0, 0, vecA.Y, vecA.X, vecA.Z)
			m_MeshSurface.Data.SetValue(0, 1, vecB.Y, vecB.X, vecB.Z)
			m_MeshSurface.Data.SetValue(1, 1, vecC.Y, vecC.X, vecC.Z)
			m_MeshSurface.Data.SetValue(1, 0, vecD.Y, vecD.X, vecD.Z)
		End Sub

		#End Region

		#Region "Fields"

		Private m_PointSeries As NPointSeries
		Private m_MeshSurface As NMeshSurfaceSeries

		Private m_LockX As Boolean
		Private m_LockZ As Boolean

		Private m_DragPlaneChanged As Boolean

		#End Region
	End Class
End Namespace