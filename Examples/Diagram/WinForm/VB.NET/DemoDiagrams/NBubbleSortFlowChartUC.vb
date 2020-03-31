Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NBubbleSortFlowChartUC.
	''' </summary>
	Public Class NBubbleSortFlowChartUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

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
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Location = New System.Drawing.Point(0, 304)
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(248, 80)
			' 
			' NBubbleSortFlowChartUC
			' 
			Me.Name = "NBubbleSortFlowChartUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			MyBase.DefaultGridOrigin = New NPointF(30, 30)
			MyBase.DefaultGridCellSize = New NSizeF(100, 50)
			MyBase.DefaultGridSpacing = New NSizeF(50, 40)

			' begin view init
			view.BeginInit()
			view.GlobalVisibility.ShowPorts = False
			view.Grid.Visible = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' setup default document fill style and shadow style
			Dim lightingFilter As NLightingImageFilter = New NLightingImageFilter()
			lightingFilter.SpecularColor = Color.Black
			lightingFilter.DiffuseColor = Color.White
			lightingFilter.LightSourceType = LightSourceType.Positional
			lightingFilter.Position = New NVector3DF(1, 1, 1)
			lightingFilter.BevelDepth = New NLength(8, NGraphicsUnit.Pixel)

			document.Style.FillStyle = New NColorFillStyle(Color.FromArgb(251, 203, 156))
			document.Style.FillStyle.ImageFiltersStyle.Filters.Add(lightingFilter)

			document.Style.ShadowStyle.Type = ShadowType.GaussianBlur
			document.Style.ShadowStyle.Offset = New NPointL(5, 5)

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument

			' create title
			Dim title As NTextShape = New NTextShape("Bubble Sort", MyBase.GetGridCell(0, 1, 2, 1))
			title.Style.TextStyle = New NTextStyle()
			title.Style.TextStyle.FillStyle = New NColorFillStyle(Color.FromArgb(68, 90, 108))
			title.Style.TextStyle.ShadowStyle = New NShadowStyle()
			title.Style.TextStyle.ShadowStyle.Type = ShadowType.GaussianBlur
			title.Style.TextStyle.FontStyle = New NFontStyle(New Font("Arial", 40, FontStyle.Bold))
			document.ActiveLayer.AddChild(title)

			' begin shape
			Dim shapeBegin As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Termination, MyBase.GetGridCell(0, 0), "BEGIN", "")

			' get array item shape
			Dim shapeGetItem As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Data, MyBase.GetGridCell(1, 0), "Get array item [1...n]", "")
			CType(shapeGetItem.Labels.DefaultLabel, NRotatedBoundsLabel).Margins = New Nevron.Diagram.NMargins(20, 20, 0, 0)

			' i = 1 shape
			Dim shapeI1 As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(2, 0), "i = 1", "")

			' j = n shape
			Dim shapeJEN As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(3, 0), "j = n", "")

			' less comparison shape
			Dim shapeLess As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Decision, MyBase.GetGridCell(4, 0), "item[i] < item[j - 1]?", "")
			CType(shapeLess.Labels.DefaultLabel, NRotatedBoundsLabel).Margins = New Nevron.Diagram.NMargins(15, 15, 0, 0)

			' swap shape
			Dim shapeSwap As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(4, 1), "Swap item[i] and item[j-1]", "")

			' j > i + 1? shape
			Dim shapeJQ As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Decision, MyBase.GetGridCell(5, 0), "j = (i + 1)?", "")

			' dec j shape
			Dim shapeDecJ As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(5, 1), "j = j - 1", "")

			' i > n - 1? shape
			Dim shapeIQ As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Decision, MyBase.GetGridCell(6, 0), "i = (n - 1)?", "")

			' inc i shape
			Dim shapeIncI As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Process, MyBase.GetGridCell(6, 1), "i = i + 1", "")

			' end shape
			Dim shapeEnd As NShape = MyBase.CreateFlowChartingShape(FlowChartingShapes.Termination, MyBase.GetGridCell(7, 0), "END", "")

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

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
