Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Maps
Imports Nevron.Dom
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NMapDrillDownUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NMapDrillDownUC))
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' label2
			' 
			Me.label2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label2.BackColor = System.Drawing.Color.LemonChiffon
			Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.label2.Location = New System.Drawing.Point(12, 63)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(236, 87)
			Me.label2.TabIndex = 4
			Me.label2.Text = resources.GetString("label2.Text")
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' label1
			' 
			Me.label1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label1.BackColor = System.Drawing.Color.AliceBlue
			Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.label1.ForeColor = System.Drawing.Color.Red
			Me.label1.Location = New System.Drawing.Point(13, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(235, 43)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Map Drill Down"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' NMapDrillDownUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "NMapDrillDownUC"
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.ResumeLayout(False)

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
			view.ViewLayout = ViewLayout.Fit

			' disable the selector tool
			view.Controller.Tools.DisableTools(New String() { Nevron.Diagram.WinForm.NDWFR.ToolSelector })

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()
			document.SizeToContent()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()

			AddHandler document.EventSinkService.NodeMouseDown, AddressOf OnNodeMouseDown
		End Sub
		Protected Overrides Sub DetachFromEvents()
			MyBase.DetachFromEvents()

			RemoveHandler document.EventSinkService.NodeMouseDown, AddressOf OnNodeMouseDown
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' Set up visual formatting
			document.BackgroundStyle.FrameStyle.Visible = False
			document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)
			document.GraphicsSettings.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

			' Create style sheets
			Dim clickedCounty As NStyleSheet = New NStyleSheet("ClickedCounty")
			NStyle.SetFillStyle(clickedCounty, New NColorFillStyle(KnownArgbColorValue.Red))
			NStyle.SetTextStyle(clickedCounty, New NTextStyle(document.ComposeTextStyle().FontStyle, New NArgbColor(KnownArgbColorValue.White)))
			document.StyleSheets.AddChild(clickedCounty)

			' Load the map of the USA
			LoadUsaMap()
		End Sub
'INSTANT VB NOTE: The parameter mapWidth was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
'INSTANT VB NOTE: The parameter mapHeight was renamed since Visual Basic will not uniquely identify class members when parameters have the same name:
		Private Sub LoadMap(ByVal fileName As String, ByVal nameColumn As String, ByVal textColumn As String, ByVal toolTipColumn As String, ByVal mapWidth_Renamed As Single, ByVal mapHeight_Renamed As Single)
			document.Layers.RemoveAllChildren()
			document.Width = mapWidth_Renamed
			document.Height = mapHeight_Renamed

			Dim mapImporter As NEsriMapImporter = New NEsriMapImporter()

			' Create the shapefile
			Dim shapefile As NEsriShapefile = New NEsriShapefile(Path.Combine(Application.StartupPath, fileName))
			shapefile.NameColumn = nameColumn
			shapefile.TextColumn = textColumn
			mapImporter.AddLayer(shapefile)

			' Import the map
			mapImporter.Read()
			If String.IsNullOrEmpty(toolTipColumn) = False Then
				mapImporter.ShapeCreatedListener = New NCustomShapeCreatedListener(toolTipColumn)
			End If

			mapImporter.Import(document, document.Bounds)
		End Sub
		Private Sub LoadUsaMap()
			LoadMap(UsaMapFile, "STATE_ABBR", "STATE_ABBR", "STATE_NAME", MapWidth, MapHeight)
		End Sub
		Private Sub LoadStateMap(ByVal abbrStateName As String)
			Dim fileName As String = Path.Combine(StatesFolder, abbrStateName)
			fileName = Path.Combine(fileName, abbrStateName & ".shp")
			LoadMap(fileName, "FIPS", Nothing, "NAME", MapWidth / 2, MapHeight / 2)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub OnNodeMouseDown(ByVal args As NNodeMouseEventArgs)
			Dim node As INNode = args.Node
			Do While Not node Is Nothing AndAlso TypeOf node Is NShape = False
				node = node.ParentNode
			Loop

			Dim shape As NShape = CType(node, NShape)
			args.Handled = True

			If document.Tag Is Nothing Then
				If shape Is Nothing Then
					Return
				End If

				' The user has clicked a state
				document.Tag = shape
				LoadStateMap(shape.Name)
				document.SizeToContent()
			Else
				If shape Is Nothing Then
					' Return to the States map
					document.Tag = Nothing
					LoadUsaMap()
					document.SizeToContent()
				Else
					If shape.StyleSheetName = "ClickedCounty" Then
						' The user has clicked a selected county - unselect it
						shape.StyleSheetName = String.Empty
						shape.Text = String.Empty
					Else
						' The user has clicked a non selected county - select it (make it red)
						shape.StyleSheetName = "ClickedCounty"
						shape.Text = shape.Name
					End If
				End If
			End If

		End Sub

		#End Region

		#Region "Designer Fields"

		Private label1 As Label
		Private label2 As Label

		#End Region

		#Region "Constants"

		Private Const MapWidth As Integer = 1600
		Private Const MapHeight As Integer = 1600

		Private Const UsaMapFile As String = "..\..\Resources\Maps\usa.shp"
		Private Const StatesFolder As String = "..\..\Resources\Maps\States"

		#End Region

		#Region "Nested Types"

		Private Class NCustomShapeCreatedListener
			Inherits NShapeCreatedListener
			Public Sub New(ByVal tooltipColumnName As String)
				m_sTooltipColumnName = tooltipColumnName
			End Sub

			Public Overrides Function OnPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Dim shape As NShape = TryCast(element, NShape)
				If Not shape Is Nothing Then
					Dim iStyle As NInteractivityStyle = New NInteractivityStyle(True, Nothing, mapFeature.GetAttributeValue(m_sTooltipColumnName).ToString())
					NStyle.SetInteractivityStyle(shape, iStyle)
				End If

				Return MyBase.OnPolygonCreated(element, mapFeature)
			End Function
			Public Overrides Function OnMultiPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Return OnPolygonCreated(element, mapFeature)
			End Function

			Private m_sTooltipColumnName As String
		End Class

		#End Region
	End Class
End Namespace