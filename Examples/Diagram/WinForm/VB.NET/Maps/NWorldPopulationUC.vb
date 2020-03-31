Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Maps
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports System.IO

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NWorldMapUC.
	''' </summary>
	Public Class NWorldPopulationUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			m_DataGrouping = New NDataGroupingOptimal()
			m_DataGrouping.RoundedRanges = True

			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.ShowDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.zoomScrollbar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.lblZoomFactor = New System.Windows.Forms.Label()
			Me.btnRecreateMap = New Nevron.UI.WinForm.Controls.NButton()
			Me.rbOptimal = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.rbEqualInterval = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.rbEqualDistribution = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.chkRoundedRanges = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowDataButton
			' 
			Me.ShowDataButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ShowDataButton.Location = New System.Drawing.Point(7, 67)
			Me.ShowDataButton.Name = "ShowDataButton"
			Me.ShowDataButton.Size = New System.Drawing.Size(244, 23)
			Me.ShowDataButton.TabIndex = 3
			Me.ShowDataButton.Text = "Show DBF Data"
			Me.ShowDataButton.UseVisualStyleBackColor = True
'			Me.ShowDataButton.Click += New System.EventHandler(Me.ShowDataButton_Click);
			' 
			' zoomScrollbar
			' 
			Me.zoomScrollbar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.zoomScrollbar.Location = New System.Drawing.Point(7, 36)
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
			Me.lblZoomFactor.Location = New System.Drawing.Point(5, 17)
			Me.lblZoomFactor.Name = "lblZoomFactor"
			Me.lblZoomFactor.Size = New System.Drawing.Size(94, 13)
			Me.lblZoomFactor.TabIndex = 9
			Me.lblZoomFactor.Text = "Zoom factor: {0:P}"
			Me.lblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' btnRecreateMap
			' 
			Me.btnRecreateMap.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnRecreateMap.Location = New System.Drawing.Point(7, 275)
			Me.btnRecreateMap.Name = "btnRecreateMap"
			Me.btnRecreateMap.Size = New System.Drawing.Size(244, 23)
			Me.btnRecreateMap.TabIndex = 21
			Me.btnRecreateMap.Text = "Recreate Map"
			Me.btnRecreateMap.UseVisualStyleBackColor = True
'			Me.btnRecreateMap.Click += New System.EventHandler(Me.btnRecreateMap_Click);
			' 
			' rbOptimal
			' 
			Me.rbOptimal.AutoSize = True
			Me.rbOptimal.ButtonProperties.BorderOffset = 2
			Me.rbOptimal.Checked = True
			Me.rbOptimal.Location = New System.Drawing.Point(8, 246)
			Me.rbOptimal.Name = "rbOptimal"
			Me.rbOptimal.Size = New System.Drawing.Size(60, 17)
			Me.rbOptimal.TabIndex = 20
			Me.rbOptimal.TabStop = True
			Me.rbOptimal.Text = "Optimal"
			Me.rbOptimal.UseVisualStyleBackColor = True
			' 
			' rbEqualInterval
			' 
			Me.rbEqualInterval.AutoSize = True
			Me.rbEqualInterval.ButtonProperties.BorderOffset = 2
			Me.rbEqualInterval.Location = New System.Drawing.Point(8, 223)
			Me.rbEqualInterval.Name = "rbEqualInterval"
			Me.rbEqualInterval.Size = New System.Drawing.Size(90, 17)
			Me.rbEqualInterval.TabIndex = 19
			Me.rbEqualInterval.Text = "Equal Interval"
			Me.rbEqualInterval.UseVisualStyleBackColor = True
			' 
			' rbEqualDistribution
			' 
			Me.rbEqualDistribution.AutoSize = True
			Me.rbEqualDistribution.ButtonProperties.BorderOffset = 2
			Me.rbEqualDistribution.Location = New System.Drawing.Point(7, 200)
			Me.rbEqualDistribution.Name = "rbEqualDistribution"
			Me.rbEqualDistribution.Size = New System.Drawing.Size(107, 17)
			Me.rbEqualDistribution.TabIndex = 18
			Me.rbEqualDistribution.Text = "Equal Distribution"
			Me.rbEqualDistribution.UseVisualStyleBackColor = True
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.label1.ForeColor = System.Drawing.Color.MediumBlue
			Me.label1.Location = New System.Drawing.Point(5, 171)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(116, 16)
			Me.label1.TabIndex = 17
			Me.label1.Tag = ""
			Me.label1.Text = "Data Grouping:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' chkRoundRanges
			' 
			Me.chkRoundedRanges.AutoSize = True
			Me.chkRoundedRanges.Location = New System.Drawing.Point(8, 141)
			Me.chkRoundedRanges.Name = "chkRoundRanges"
			Me.chkRoundedRanges.Size = New System.Drawing.Size(98, 17)
			Me.chkRoundedRanges.TabIndex = 22
			Me.chkRoundedRanges.Text = "Rounded Ranges"
			Me.chkRoundedRanges.UseVisualStyleBackColor = True
			Me.chkRoundedRanges.Checked = True
			' 
			' NWorldPopulationUC
			' 
			Me.Controls.Add(Me.chkRoundedRanges)
			Me.Controls.Add(Me.btnRecreateMap)
			Me.Controls.Add(Me.rbOptimal)
			Me.Controls.Add(Me.rbEqualInterval)
			Me.Controls.Add(Me.rbEqualDistribution)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.lblZoomFactor)
			Me.Controls.Add(Me.zoomScrollbar)
			Me.Controls.Add(Me.ShowDataButton)
			Me.Name = "NWorldPopulationUC"
			Me.Controls.SetChildIndex(Me.ShowDataButton, 0)
			Me.Controls.SetChildIndex(Me.zoomScrollbar, 0)
			Me.Controls.SetChildIndex(Me.lblZoomFactor, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.rbEqualDistribution, 0)
			Me.Controls.SetChildIndex(Me.rbEqualInterval, 0)
			Me.Controls.SetChildIndex(Me.rbOptimal, 0)
			Me.Controls.SetChildIndex(Me.btnRecreateMap, 0)
			Me.Controls.SetChildIndex(Me.chkRoundedRanges, 0)
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
			zoomScrollbar.Value = CInt(Fix(NMath.Round(zoomFactor * 100)))
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()
			AddHandler view.EventSinkService.TransformationsChanged, AddressOf EventSinkService_TransformationsChanged
		End Sub

		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()
			RemoveHandler view.EventSinkService.TransformationsChanged, AddressOf EventSinkService_TransformationsChanged
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			view.Controller.Tools.DisableTools(New String() { Nevron.Diagram.WinForm.NDWFR.ToolSelector })

			Dim zoomFactor As Single = zoomScrollbar.Value / 100.0f
			lblZoomFactor.Text = String.Format(ZoomLabel, zoomFactor)

			ResumeEventsHandling()
		End Sub
		Private Sub InitDocument()
			document.Layers.RemoveAllChildren()

			' Configure the drawing document
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.RoutingManager.Enabled = False
			document.BridgeManager.Enabled = False
			document.Bounds = New NRectangleF(0, 0, 10000, 10000)
			document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)

			' Add a style sheet
			Dim styleSheet As NStyleSheet = New NStyleSheet(WhiteTextStyleSheetName)
			Dim textStyle As NTextStyle = CType(document.ComposeTextStyle().Clone(), NTextStyle)
			textStyle.FillStyle = New NColorFillStyle(KnownArgbColorValue.White)
			NStyle.SetTextStyle(styleSheet, textStyle)
			document.StyleSheets.AddChild(styleSheet)

			' Create a map importer
			m_MapImporter = New NEsriMapImporter()
			m_MapImporter.MapBounds = NMapBounds.World

			' Add a shapefile
'INSTANT VB NOTE: The local variable countries was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
			Dim countries_Renamed As NEsriShapefile = New NEsriShapefile(Path.Combine(Application.StartupPath, Countries))
			countries_Renamed.NameColumn = "CNTRY_NAME"
			countries_Renamed.TextColumn = "CNTRY_NAME"
			m_MapImporter.AddLayer(countries_Renamed)

			' Read the map data
			m_MapImporter.Read()

			' Create a fill rule
			Dim fillRule As NMapFillRuleRange = New NMapFillRuleRange("POP_CNTRY", Color.White, Color.Black, 12)
			fillRule.DataGrouping = m_DataGrouping
			countries_Renamed.FillRule = fillRule

			' Associate a shape created listener and import the map data
			m_MapImporter.ShapeCreatedListener = New NCustomShapeCreatedListener()
			m_MapImporter.Import(document, document.Bounds)

			' Generate a legend
			Dim mapLegend As NMapLegendRange = CType(m_MapImporter.GetLegend(fillRule), NMapLegendRange)
			mapLegend.Title = "Population"
			mapLegend.RangeFormatString = "{0:N0} - {1:N0} people"
			mapLegend.LastFormatString = "{0:N0} people and more"

			If pMapLegend Is Nothing Then
				pMapLegend = New Panel()
				pMapLegend.Location = New Point(btnRecreateMap.Left, btnRecreateMap.Bottom + 10)
				pMapLegend.Width = btnRecreateMap.Width
				pMapLegend.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
				Me.Controls.Add(pMapLegend)
			End If

			mapLegend.Create(pMapLegend)
		End Sub

		#End Region

		#Region "EventHandlers"

		Private Sub ShowDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataButton.Click
			Dim f As Nevron.UI.WinForm.Controls.NForm = New Nevron.UI.WinForm.Controls.NForm()
			f.SuspendLayout()

			'Create the data grid view
			Dim dg As NDataGridView = New NDataGridView()
			dg.Dock = DockStyle.Fill
			dg.AllowUserToAddRows = False
			dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
			dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
			dg.RowHeadersVisible = False
			dg.ReadOnly = True
			dg.DataSource = m_MapImporter.GetLayerAt(0).DataTable
			f.Controls.Add(dg)

			'Init the form
			f.Icon = Me.Form.Icon
			f.WindowState = FormWindowState.Maximized
			f.Text = String.Format("DBF data for '{0}'", m_MapImporter.GetLayerAt(0).Name)

			f.ResumeLayout()
			f.ShowDialog()
		End Sub
		Private Sub EventSinkService_TransformationsChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim zoomFactor As Single = (view.ScaleX + view.ScaleY) / 2
			Dim value As Integer = CInt(Fix(NMath.Round(zoomFactor * 100)))

			If value <> zoomScrollbar.Value Then
				zoomScrollbar.Value = value
			End If
		End Sub
		Private Sub zoomScrollbar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles zoomScrollbar.ValueChanged
			Dim zoomFactor As Single = (view.ScaleX + view.ScaleY) / 2
			Dim scrollFactor As Single = e.ScrollBar.Value / 100.0f
			If zoomFactor <> scrollFactor Then
				view.Zoom(scrollFactor)
			End If

			lblZoomFactor.Text = String.Format(ZoomLabel, scrollFactor)
		End Sub
		Private Sub btnRecreateMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRecreateMap.Click
			If rbEqualDistribution.Checked Then
				m_DataGrouping = New NDataGroupingEqualDistribution()
			ElseIf rbEqualInterval.Checked Then
				m_DataGrouping = New NDataGroupingEqualInterval()
			Else
				m_DataGrouping = New NDataGroupingOptimal()
			End If

			m_DataGrouping.RoundedRanges = chkRoundedRanges.Checked
			ResetExample()
		End Sub

		#End Region

		#Region "Fields"

		Private m_DataGrouping As NDataGrouping

		Private WithEvents ShowDataButton As Nevron.UI.WinForm.Controls.NButton
		Private m_MapImporter As NEsriMapImporter
		Private WithEvents zoomScrollbar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents btnRecreateMap As Nevron.UI.WinForm.Controls.NButton
		Private rbOptimal As Nevron.UI.WinForm.Controls.NRadioButton
		Private rbEqualInterval As Nevron.UI.WinForm.Controls.NRadioButton
		Private rbEqualDistribution As Nevron.UI.WinForm.Controls.NRadioButton
		Private chkRoundedRanges As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As Label
		Private lblZoomFactor As Label
		Private pMapLegend As Panel

		#End Region

		#Region "Nested Types"

		Private Class NCustomShapeCreatedListener
			Inherits NShapeCreatedListener
			#Region "INShapeCreatedListener"

			Public Overrides Function OnPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Dim shape As NShape = TryCast(element, NShape)
				If shape Is Nothing Then
					Return True
				End If

				Dim name As String = mapFeature.GetAttributeValue("CNTRY_NAME").ToString()
				Dim population As Integer = Int32.Parse(mapFeature.GetAttributeValue("POP_CNTRY").ToString())

				Dim interactivityStyle As NInteractivityStyle
				If name.EndsWith("s") Then
					interactivityStyle = New NInteractivityStyle(String.Format("{0}'{1} population: {2:N0}", name,String.Empty, population))
				Else
					interactivityStyle = New NInteractivityStyle(String.Format("{0}'{1} population: {2:N0}", name,"s", population))
				End If
				NStyle.SetInteractivityStyle(shape, interactivityStyle)

				Return True
			End Function
			Public Overrides Function OnMultiPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Return OnPolygonCreated(element, mapFeature)
			End Function
			Public Overrides Function OnPolygonLabelCreated(ByVal polygonLabel As NMapPolygonLabel, ByVal mapFeature As NMapFeature) As Boolean
				Dim master As NStyleableElement = CType(polygonLabel.MasterElement, NStyleableElement)
				Dim color As Color = master.ComposeFillStyle().GetPrimaryColor().ToColor()

				If color.R < 128 Then
					' Make the text of dark shape labels white
					polygonLabel.StyleSheetName = WhiteTextStyleSheetName
				End If

				Return True
			End Function

			#End Region
		End Class

		#End Region

		#Region "Constants"

		Private Const ZoomLabel As String = "Zoom factor: {0:P}"
		Private Const Countries As String = "..\..\Resources\Maps\countries.shp"
		Private Const WhiteTextStyleSheetName As String = "WhiteText"

		#End Region
	End Class
End Namespace