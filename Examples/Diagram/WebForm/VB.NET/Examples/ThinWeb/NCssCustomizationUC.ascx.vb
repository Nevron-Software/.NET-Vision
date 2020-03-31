Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NThinWebGeneral.
	''' </summary>
	Public Partial Class NCssCustomizationUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			' begin view init
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			If (Not NThinDiagramControl1.Initialized) Then
				' begin view init
				Dim document As NDrawingDocument = NThinDiagramControl1.Document

				NThinDiagramControl1.Controller.Tools.Add(New NTooltipTool())
				NThinDiagramControl1.Controller.Tools.Add(New NBrowserRedirectTool())
				NThinDiagramControl1.Controller.Tools.Add(New NCursorTool())
				NThinDiagramControl1.Controller.Tools.Add(New NRectZoomTool())
				Dim panTool As NPanTool = New NPanTool()
				panTool.Enabled = False
				NThinDiagramControl1.Controller.Tools.Add(panTool)

				' configure the toolbar
				NThinDiagramControl1.Toolbar.Visible = True
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomInAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomOutAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())

				Dim values As Array = System.Enum.GetValues(GetType(CanvasLayout))
				Dim i As Integer = 0
				Do While i < values.Length
					NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleViewLayoutAction(CType(values.GetValue(i), CanvasLayout))))
					i += 1
				Loop

				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NTogglePanToolAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleRectZoomToolAction()))


				' init NDrawingView1.Document.
				document.BeginInit()
				InitDocument(document)
				document.EndInit()

				' modify the css styles for state default, state active and state hover
				' customize the CSS
				NThinDiagramControl1.ServerSettings.Css.StatePressed = "border: 1px solid rgb(255, 0, 0); background: rgb(252, 226, 203);"
				NThinDiagramControl1.ServerSettings.Css.StateHover = "border: 1px solid rgb(178, 0, 0); background: rgb(255, 255, 255);"
				NThinDiagramControl1.ServerSettings.Css.StateDefault = "margin: 0px; padding: 2px; border : 1px solid rgb(200, 200, 200); background: rgb(255, 255, 255);"
				NThinDiagramControl1.ServerSettings.Css.ToolbarSeparator = "width: 10px; height: 22px; font-size : 0px; background-color: rgb(255, 255, 255);"
				NThinDiagramControl1.ServerSettings.Css.View = "margin-left: 0px; margin-right: 0px; margin-top: 1px; margin-bottom: 0px; padding: 0px; border : 1px solid rgb(204, 204, 204);"
				NThinDiagramControl1.ServerSettings.Css.Scrollbar = "margin : 0px; padding : 0px; border : 1px solid rgb(204, 204, 204); background: rgb(255, 255, 255);"

				' reflects view css margin + padding + border inflate
				NThinDiagramControl1.ServerSettings.Css.ViewInflate = New NSize(2, 3)

				' show loader images and enable tiling
				NThinDiagramControl1.ServerSettings.ShowLoaderImages = True
				NThinDiagramControl1.ServerSettings.JQuery.SourceType = JQuerySourceType.Url
				NThinDiagramControl1.ServerSettings.JQuery.Url = "http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"
			End If
		End Sub

		#Region "Implementation"

		Private Function CreateInteractivityStyle(ByVal text As String) As NInteractivityStyle
			Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle()
			interactivityStyle.Tooltip.Text = text
			interactivityStyle.Cursor = New NCursorAttribute(CursorType.Hand)

			Return interactivityStyle
		End Function

		Private Sub InitDocument(ByVal document As NDrawingDocument)
			' setup default NDrawingView1.Document. fill style, background style and shadow style
			Dim color1 As Color = Color.FromArgb(225, 232, 232)
			Dim color2 As Color = Color.FromArgb(32, 136, 178)

			Dim lightingFilter As NLightingImageFilter = New NLightingImageFilter()
			lightingFilter.SpecularColor = Color.Black
			lightingFilter.DiffuseColor = Color.White
			lightingFilter.LightSourceType = LightSourceType.Positional
			lightingFilter.Position = New NVector3DF(1, 1, 1)
			lightingFilter.BevelDepth = New NLength(8, NGraphicsUnit.Pixel)

			document.Style.FillStyle = New NColorFillStyle(color1)
			document.Style.FillStyle.ImageFiltersStyle.Filters.Add(lightingFilter)

			document.BackgroundStyle.FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1, Color.LightBlue, color2)

			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			document.Style.ShadowStyle.Offset = New NPointL(5, 5)

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument

			' create title
			Dim title As NTextShape = New NTextShape("Bubble Sort", GetGridCell(0, 1, 2, 1))
			title.Style.TextStyle = New NTextStyle()
			title.Style.TextStyle.FillStyle = (TryCast(document.Style.FillStyle.Clone(), NFillStyle))
			title.Style.TextStyle.ShadowStyle = New NShadowStyle()
			title.Style.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
			title.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 40, FontStyle.Bold))

			title.Style.InteractivityStyle = CreateInteractivityStyle("Bubble Sort")

			document.ActiveLayer.AddChild(title)



			' begin shape
			Dim shapeBegin As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Termination, GetGridCell(0, 0), "BEGIN", "")

			' get array item shape
			Dim shapeGetItem As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Data, GetGridCell(1, 0), "Get array item [1...n]", "")
			Dim rotatedBoundsLabel As NRotatedBoundsLabel = CType(shapeGetItem.Labels.DefaultLabel, NRotatedBoundsLabel)
			rotatedBoundsLabel.Margins = New Nevron.Diagram.NMargins(20, 20, 0, 0)

			' i = 1 shape
			Dim shapeI1 As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(2, 0), "i = 1", "")

			' j = n shape
			Dim shapeJEN As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(3, 0), "j = n", "")

			' less comparison shape
			Dim shapeLess As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(4, 0), "item[i] < item[j - 1]?", "")
			rotatedBoundsLabel = CType(shapeLess.Labels.DefaultLabel, NRotatedBoundsLabel)
			rotatedBoundsLabel.Margins = New Nevron.Diagram.NMargins(15, 15, 0, 0)

			' swap shape
			Dim shapeSwap As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(4, 1), "Swap item[i] and item[j-1]", "")

			' j > i + 1? shape
			Dim shapeJQ As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(5, 0), "j = (i + 1)?", "")

			' dec j shape
			Dim shapeDecJ As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(5, 1), "j = j - 1", "")

			' i > n - 1? shape
			Dim shapeIQ As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Decision, GetGridCell(6, 0), "i = (n - 1)?", "")

			' inc i shape
			Dim shapeIncI As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Process, GetGridCell(6, 1), "i = i + 1", "")

			' end shape
			Dim shapeEnd As NShape = CreateFlowChartingShape(document, FlowChartingShapes.Termination, GetGridCell(7, 0), "END", "")

			' connect begin with get array item
			Dim connector1 As NLineShape = New NLineShape()
			connector1.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector1)
			connector1.FromShape = shapeBegin
			connector1.ToShape = shapeGetItem

			' connect get array item with i = 1
			Dim connector2 As NLineShape = New NLineShape()
			connector2.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector2)

			connector2.FromShape = shapeGetItem
			connector2.ToShape = shapeI1

			' connect i = 1 and j = n
			Dim connector3 As NLineShape = New NLineShape()
			connector3.StyleSheetName = NDR.NameConnectorsStyleSheet

			connector3.CreateShapeElements(ShapeElementsMask.Ports)
			connector3.Ports.AddChild(New NLogicalLinePort(connector3.UniqueId, 50))
			connector3.Ports.DefaultInwardPortUniqueId = (TryCast(connector3.Ports.GetChildAt(0), INDiagramElement)).UniqueId
			document.ActiveLayer.AddChild(connector3)

			connector3.FromShape = shapeI1
			connector3.ToShape = shapeJEN

			' connect j = n and item[i] < item[j-1]?
			Dim connector4 As NLineShape = New NLineShape()
			connector4.StyleSheetName = NDR.NameConnectorsStyleSheet

			connector4.CreateShapeElements(ShapeElementsMask.Ports)
			connector4.Ports.AddChild(New NLogicalLinePort(connector4.UniqueId, 50))
			connector4.Ports.DefaultInwardPortUniqueId = (TryCast(connector4.Ports.GetChildAt(0), INDiagramElement)).UniqueId
			document.ActiveLayer.AddChild(connector4)

			connector4.FromShape = shapeJEN
			connector4.ToShape = shapeLess

			' connect item[i] < item[j-1]? and j = (i + 1)? 
			Dim connector5 As NLineShape = New NLineShape()
			connector5.StyleSheetName = NDR.NameConnectorsStyleSheet
			connector5.Text = "No"
			connector5.Style.TextStyle = New NTextStyle()
			connector5.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Top

			connector5.CreateShapeElements(ShapeElementsMask.Ports)
			connector5.Ports.AddChild(New NLogicalLinePort(connector5.UniqueId, 50))
			connector5.Ports.DefaultInwardPortUniqueId = (TryCast(connector5.Ports.GetChildAt(0), INDiagramElement)).UniqueId
			document.ActiveLayer.AddChild(connector5)

			connector5.FromShape = shapeLess
			connector5.ToShape = shapeJQ

			' connect j = (i + 1)? and i = (n - 1)?
			Dim connector6 As NLineShape = New NLineShape()
			connector6.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector6)

			connector6.FromShape = shapeJQ
			connector6.ToShape = shapeIQ

			' connect i = (n - 1) and END
			Dim connector7 As NLineShape = New NLineShape()
			connector7.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector7)
			connector7.FromShape = shapeIQ
			connector7.ToShape = shapeEnd

			' connect item[i] < item[j-1]? and Swap
			Dim connector8 As NLineShape = New NLineShape()
			connector8.StyleSheetName = NDR.NameConnectorsStyleSheet
			connector8.Text = "Yes"
			connector8.Style.TextStyle = New NTextStyle()
			connector8.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom
			document.ActiveLayer.AddChild(connector8)

			connector8.FromShape = shapeLess
			connector8.ToShape = shapeSwap

			' connect j = (i + 1)? and j = (j - 1)
			Dim connector9 As NLineShape = New NLineShape()
			connector9.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector9)

			connector9.FromShape = shapeJQ
			connector9.ToShape = shapeDecJ

			' connect i = (n - 1)? and i = (i + 1)
			Dim connector10 As NLineShape = New NLineShape()
			connector10.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector10)

			connector10.FromShape = shapeIQ
			connector10.ToShape = shapeIncI

			' connect Swap to No connector
			Dim connector11 As NStep2Connector = New NStep2Connector(True)
			connector11.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector11)

			connector11.FromShape = shapeSwap
			connector11.ToShape = connector5

			' connect i = i + 1 to connector3
			Dim connector12 As NStep3Connector = New NStep3Connector(False, 50, 60, False)
			connector12.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector12)

			connector12.StartPlug.Connect(TryCast(shapeIncI.Ports.GetChildByName("Right", 0), NPort))
			connector12.EndPlug.Connect(connector3.Ports.DefaultInwardPort)

			' connect j = j - 1 to connector4
			Dim connector13 As NStep3Connector = New NStep3Connector(False, 50, 30, False)
			connector13.StyleSheetName = NDR.NameConnectorsStyleSheet
			document.ActiveLayer.AddChild(connector13)

			connector13.StartPlug.Connect(TryCast(shapeDecJ.Ports.GetChildByName("Right", 0), NPort))
			connector13.EndPlug.Connect(connector4.Ports.DefaultInwardPort)
		End Sub

	   #End Region
	End Class
End Namespace