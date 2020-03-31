Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Maps
Imports Nevron.GraphicsCore
Imports Nevron.Dom

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NWorldMapUC.
	''' </summary>
	Public Class NWorldMapUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
			m_ZoomedCity = Nothing
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.ShowDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.cbFile = New System.Windows.Forms.ComboBox()
			Me.cbCity = New System.Windows.Forms.ComboBox()
			Me.NavigateToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.zoomScrollbar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.lblZoomFactor = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' ShowDataButton
			' 
			Me.ShowDataButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ShowDataButton.Location = New System.Drawing.Point(155, 11)
			Me.ShowDataButton.Name = "ShowDataButton"
			Me.ShowDataButton.Size = New System.Drawing.Size(97, 23)
			Me.ShowDataButton.TabIndex = 3
			Me.ShowDataButton.Text = "Show DBF Data"
			Me.ShowDataButton.UseVisualStyleBackColor = True
'			Me.ShowDataButton.Click += New System.EventHandler(Me.ShowDataButton_Click);
			' 
			' cbFile
			' 
			Me.cbFile.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbFile.FormattingEnabled = True
			Me.cbFile.Location = New System.Drawing.Point(8, 12)
			Me.cbFile.Name = "cbFile"
			Me.cbFile.Size = New System.Drawing.Size(140, 21)
			Me.cbFile.TabIndex = 4
			' 
			' cbCity
			' 
			Me.cbCity.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cbCity.FormattingEnabled = True
			Me.cbCity.Location = New System.Drawing.Point(8, 53)
			Me.cbCity.Name = "cbCity"
			Me.cbCity.Size = New System.Drawing.Size(140, 21)
			Me.cbCity.Sorted = True
			Me.cbCity.TabIndex = 6
			' 
			' NavigateToButton
			' 
			Me.NavigateToButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.NavigateToButton.Location = New System.Drawing.Point(154, 52)
			Me.NavigateToButton.Name = "NavigateToButton"
			Me.NavigateToButton.Size = New System.Drawing.Size(97, 23)
			Me.NavigateToButton.TabIndex = 7
			Me.NavigateToButton.Text = "Navigate To"
			Me.NavigateToButton.UseVisualStyleBackColor = True
'			Me.NavigateToButton.Click += New System.EventHandler(Me.NavigateToButton_Click);
			' 
			' zoomScrollbar
			' 
			Me.zoomScrollbar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.zoomScrollbar.Location = New System.Drawing.Point(7, 123)
			Me.zoomScrollbar.Maximum = 600
			Me.zoomScrollbar.Minimum = 1
			Me.zoomScrollbar.MinimumSize = New System.Drawing.Size(34, 17)
			Me.zoomScrollbar.Name = "zoomScrollbar"
			Me.zoomScrollbar.Size = New System.Drawing.Size(244, 17)
			Me.zoomScrollbar.TabIndex = 8
			Me.zoomScrollbar.Value = 7
'			Me.zoomScrollbar.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.zoomScrollbar_ValueChanged);
			' 
			' lblZoomFactor
			' 
			Me.lblZoomFactor.AutoSize = True
			Me.lblZoomFactor.Location = New System.Drawing.Point(5, 104)
			Me.lblZoomFactor.Name = "lblZoomFactor"
			Me.lblZoomFactor.Size = New System.Drawing.Size(94, 13)
			Me.lblZoomFactor.TabIndex = 9
			Me.lblZoomFactor.Tag = "Zoom factor: {0:P}"
			Me.lblZoomFactor.Text = "Zoom factor: {0:P}"
			Me.lblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NWorldMapUC
			' 
			Me.Controls.Add(Me.lblZoomFactor)
			Me.Controls.Add(Me.zoomScrollbar)
			Me.Controls.Add(Me.NavigateToButton)
			Me.Controls.Add(Me.cbCity)
			Me.Controls.Add(Me.cbFile)
			Me.Controls.Add(Me.ShowDataButton)
			Me.Name = "NWorldMapUC"
			Me.Controls.SetChildIndex(Me.ShowDataButton, 0)
			Me.Controls.SetChildIndex(Me.cbFile, 0)
			Me.Controls.SetChildIndex(Me.cbCity, 0)
			Me.Controls.SetChildIndex(Me.NavigateToButton, 0)
			Me.Controls.SetChildIndex(Me.zoomScrollbar, 0)
			Me.Controls.SetChildIndex(Me.lblZoomFactor, 0)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			view.BeginInit()

			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowArrowheads = False
			view.VerticalRuler.Visible = False
			view.HorizontalRuler.Visible = False

			' init document
			document.BeginInit()
			InitDocument()
			document.SizeToContent(New NSizeF(0, 0), New Nevron.Diagram.NMargins(0))
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			Dim widthFactor As Single = view.ClientSize.Width / document.Width
			Dim heightFactor As Single = view.ClientSize.Height / document.Height
			Dim zoomFactor As Single
			If widthFactor < heightFactor Then
				zoomFactor = widthFactor
			Else
				zoomFactor = heightFactor
			End If

			view.Zoom(zoomFactor)
			view.EndInit()
		End Sub
		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()

			AddHandler document.EventSinkService.NodeClick, AddressOf EventSinkService_NodeClick
		End Sub
		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()

			RemoveHandler document.EventSinkService.NodeClick, AddressOf EventSinkService_NodeClick
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			document.Layers.RemoveAllChildren()

			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.RoutingManager.Enabled = False
			document.BridgeManager.Enabled = False
			document.Bounds = New NRectangleF(0, 0, 10000, 10000)
			document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)

			CreateStyleSheets()
			CreateStarPointShape()

			m_MapImporter = New NEsriMapImporter()
			m_MapImporter.MapBounds = NMapBounds.World

			' Create the COUNTRIES shapefile
			Dim countries As NEsriShapefile = New NEsriShapefile(Path.Combine(Application.StartupPath, CountriesFileName))
			countries.NameColumn = "CNTRY_NAME"
			countries.TextColumn = "CNTRY_NAME"
			countries.MaxTextShowZoomFactor = 0.99f
			countries.FillRule = New NMapFillRuleValue("COLOR_MAP", Colors)
			m_MapImporter.AddLayer(countries)

			' Create the CITIES shapefile
			Dim cities As NEsriShapefile = New NEsriShapefile(Path.Combine(Application.StartupPath, CitiesFileName))
			cities.NameColumn = "NAME"
			cities.TextColumn = "NAME"
			cities.MinShowZoomFactor = 1.0f

			cities.PointSizeColumn = "POPULATION"
			cities.MinPointShapeSize = New NSizeF(10, 10)
			cities.MaxPointShapeSize = New NSizeF(40, 40)

			m_MapImporter.AddLayer(cities)

			' Read the map data
			m_MapImporter.Read()

			' Import the map data to the drawing document
			m_MapImporter.ShapeCreatedListener = New NCustomShapeCreatedListener()
			m_MapImporter.Import(document, document.Bounds)
		End Sub
		Private Sub InitFormControls()
			PauseEventsHandling()

			Dim i As Integer, count As Integer = m_MapImporter.LayerCount
			i = 0
			Do While i < count
				cbFile.Items.Add(m_MapImporter.GetLayerAt(i).Name)
				i += 1
			Loop

			cbFile.SelectedIndex = 0
			cbCity.DataSource = m_MapImporter.GetLayerAt(1).DataTable
			cbCity.ValueMember = "NAME"
			cbCity.DisplayMember = "NAME"
			m_ZoomWorkedOut = True

			AddHandler view.EventSinkService.TransformationsChanged, AddressOf EventSinkService_TransformationsChanged
			view.Controller.Tools.DisableTools(New String() { Nevron.Diagram.WinForm.NDWFR.ToolSelector })

			Dim zoomFactor As Single = zoomScrollbar.Value / 100.0f
			lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), zoomFactor)

			ResumeEventsHandling()
		End Sub

		Private Sub CreateStyleSheets()
			' Create the zoomed city style sheet
			Dim zoomedCity As NStyleSheet = New NStyleSheet()
			zoomedCity.Name = "Zoomed City"
			zoomedCity.Style.FillStyle = New NGradientFillStyle(GradientStyle.FromCenter, GradientVariant.Variant1, Color.DarkRed, Color.Red)
			document.StyleSheets.AddChild(zoomedCity)
		End Sub
		Private Sub CreateStarPointShape()
			' create the graphics path representing the point shape
			Dim modelBounds As NRectangleF = New NRectangleF(-1, -1, 2, 2)
			Dim path As GraphicsPath = New GraphicsPath()
			CreateNGramPath(path, modelBounds, 5, -NMath.PIHalf, 0.5f)

			' wrap it in a model and name it
			Dim customPath As NCustomPath = New NCustomPath(path, PathType.ClosedFigure)
			customPath.Name = "Star"

			' add it to the stencil
			document.PointShapeStencil.AddChild(customPath)
		End Sub
		Private Sub CreateNGramPath(ByVal path As GraphicsPath, ByVal rect As NRectangleF, ByVal edgeCount As Integer, ByVal startAngle As Single, ByVal innerRadius As Single)
			Dim halfWidth As Single = rect.Width / 2.0f
			Dim halfHeight As Single = rect.Height / 2.0f
			Dim centerX As Single = rect.X + halfWidth
			Dim centerY As Single = rect.Y + halfHeight
			Dim incAngle As Single = NMath.PI2 / edgeCount
			Dim innerOffsetAngle As Single = NMath.PI / edgeCount

			Dim outer As PointF() = New PointF(edgeCount - 1){}
			Dim inner As PointF() = New PointF(edgeCount - 1){}

			Dim i As Integer = 0
			Do While i < edgeCount
				Dim angle As Single = startAngle + i * incAngle
				outer(i).X = CSng(Math.Round(centerX + Math.Cos(angle) * halfWidth, 1))
				outer(i).Y = CSng(Math.Round(centerY + Math.Sin(angle) * halfHeight, 1))

				angle += innerOffsetAngle
				inner(i).X = CSng(Math.Round(centerX + Math.Cos(angle) * innerRadius, 1))
				inner(i).Y = CSng(Math.Round(centerY + Math.Sin(angle) * innerRadius, 1))
				i += 1
			Loop

			i = 0
			Do While i < (edgeCount - 1)
				path.AddLine(outer(i), inner(i))
				path.AddLine(inner(i), outer(i + 1))
				i += 1
			Loop

			path.AddLine(outer(edgeCount - 1), inner(edgeCount - 1))
			path.CloseAllFigures()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub zoomScrollbar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles zoomScrollbar.ValueChanged
			Dim zoomFactor As Single = (view.ScaleX + view.ScaleY) / 2
			Dim scrollFactor As Single = e.ScrollBar.Value / 100.0f
			If zoomFactor <> scrollFactor Then
				view.Zoom(scrollFactor)
			End If

			If Not lblZoomFactor.Tag Is Nothing Then
				lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), scrollFactor)
			End If
		End Sub
		Private Sub ShowDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataButton.Click
			Dim f As Nevron.UI.WinForm.Controls.NForm = New Nevron.UI.WinForm.Controls.NForm()
			f.SuspendLayout()

			'Create the data grid view
			Dim dg As Nevron.UI.WinForm.Controls.NDataGridView = New Nevron.UI.WinForm.Controls.NDataGridView()
			dg.Dock = DockStyle.Fill
			dg.AllowUserToAddRows = False
			dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
			dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
			dg.RowHeadersVisible = False
			dg.ReadOnly = True
			dg.DataSource = m_MapImporter.GetLayerAt(cbFile.SelectedIndex).DataTable
			f.Controls.Add(dg)

			'Init the form
			f.Icon = Me.Form.Icon
			f.WindowState = FormWindowState.Maximized
			f.Text = String.Format("DBF data for '{0}'", m_MapImporter.GetLayerAt(cbFile.SelectedIndex).Name)

			f.ResumeLayout()
			f.ShowDialog()
		End Sub
		Private Sub NavigateToButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NavigateToButton.Click
			If cbCity.SelectedIndex = -1 Then
				Return
			End If

			' Find the map point label corresponding to the selected city
			Dim citiesLayer As NLayer = CType(document.Layers.GetChildByName("cities"), NLayer)
			Dim mapLabelsShape As NMapLabelsShape = CType(citiesLayer.GetChildAt(0), NMapLabelsShape)
			Dim pointLabel As NMapPointLabel = CType(mapLabelsShape.MapLabels.GetChildByName(cbCity.Text), NMapPointLabel)

			If pointLabel Is Nothing Then
				Return
			End If

			view.Zoom(2.0f, pointLabel.PinPoint, True)
			If Not m_ZoomedCity Is Nothing Then
				m_ZoomedCity.StyleSheetName = String.Empty
			End If

			pointLabel.StyleSheetName = "Zoomed City"
			m_ZoomedCity = pointLabel
		End Sub
		Private Sub EventSinkService_TransformationsChanged(ByVal sender As Object, ByVal e As EventArgs)
			If m_ZoomWorkedOut Then
				m_ZoomWorkedOut = False
				Return
			End If

			Dim zoomFactor As Single = (view.ScaleX + view.ScaleY) / 2
			If Not lblZoomFactor.Tag Is Nothing Then
				lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), zoomFactor)
			End If
			zoomScrollbar.Value = CInt(Fix(Math.Round(zoomFactor * 100)))
		End Sub
		Private Sub EventSinkService_NodeClick(ByVal args As NNodeViewEventArgs)
			Dim shape As NShape = TryCast(args.Node, NShape)
			If shape Is Nothing Then
				Return
			End If

			MessageBox.Show(shape.Name, "Country clicked:", MessageBoxButtons.OK, MessageBoxIcon.None)
			args.Handled = True
		End Sub

		#End Region

		#Region "Fields"

		Private m_ZoomWorkedOut As Boolean
		Private m_MapImporter As NEsriMapImporter
		Private m_ZoomedCity As NMapPointLabel

		#End Region

		#Region "Designer Fields"

		Private WithEvents ShowDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents NavigateToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents zoomScrollbar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private lblZoomFactor As Label
		Private cbFile As ComboBox
		Private cbCity As ComboBox

		#End Region

		#Region "Constants"

		Private Const CountriesFileName As String = "..\..\Resources\Maps\countries.shp"
		Private Const CitiesFileName As String = "..\..\Resources\Maps\cities.shp"

		''' <summary>
		''' The colors used to fill the countries.
		''' </summary>
		Private Shared ReadOnly Colors As Color() = New Color() { Color.Tomato, Color.PaleGreen, Color.Gold, Color.PaleGoldenrod, Color.Tan, Color.Khaki, Color.OldLace, Color.Orange }

		#End Region

		#Region "Nested Types"

		Private Class NCustomShapeCreatedListener
			Inherits NShapeCreatedListener
			#Region "INShapeCreatedListener Overrides"

			Public Overrides Function OnPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Dim shape As NShape = TryCast(element, NShape)
				If shape Is Nothing Then
					Return True
				End If

				Dim name As String = mapFeature.GetAttributeValue("CNTRY_NAME").ToString()
				Dim population As Single = Single.Parse(mapFeature.GetAttributeValue("POP_CNTRY").ToString())
				Dim landArea As Single = Single.Parse(mapFeature.GetAttributeValue("SQKM").ToString())

				' add a tooltip to the shape
				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle(String.Format("{1}{0}======================{0}Land Area: {2:N} km2{0}Population: {3:N0} people{0}Pop. Density: {4:N} people/km2", Environment.NewLine, name, landArea, population, population / landArea))

				shape.Style.InteractivityStyle = interactivityStyle
				Return True
			End Function
			Public Overrides Function OnMultiPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Return OnPolygonCreated(element, mapFeature)
			End Function
			Public Overrides Function OnPointCreated(ByVal pointLabel As NMapPointLabel, ByVal mapFeature As NMapFeature) As Boolean
				If mapFeature.GetAttributeValue("CAPITAL").Equals("Y") Then
					pointLabel.ShapeType = PointShape.Custom
					pointLabel.CustomShapeName = "Star"
				End If

				Return True
			End Function

			#End Region

			#Region "Constants"

			Private Shared ReadOnly POP As Single(,) = New Single(, ){ {1000000, 1.3f}, {2000000, 1.6f}, {5000000, 2.0f}, {10000000, 2.5f}, {20000000, 3.0f} }

			#End Region
		End Class

		#End Region
	End Class
End Namespace