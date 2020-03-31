Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Web

Imports Nevron.Diagram
Imports Nevron.Diagram.DataImport
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.ThinWeb
Imports Nevron.Dom
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NBusinessCompanyUC.
	''' </summary>
	Partial Public Class NBusinessCompanyUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized = False Then
				' Init the diagram control
				NThinDiagramControl1.StateId = "Diagram1"

				' Init the drawing view
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit

				' Configure the controller
				Dim serverMouseEventTool As NServerMouseEventTool = New NServerMouseEventTool()
				NThinDiagramControl1.Controller.Tools.Add(serverMouseEventTool)
				serverMouseEventTool.MouseDown = New NMouseDownEventCallback()

				' Init the drawing document
				Dim document As NDrawingDocument = NThinDiagramControl1.Document
				document.BeginInit()
				CreateStyleSheets(document)
				InitDocument(document)
				document.EndInit()
			End If
		End Sub

#Region "Implementation"

		Private Sub CreateStyleSheets(ByVal document As NDrawingDocument)
			' create a stylesheet for the president
			Dim styleSheet As NStyleSheet = New NStyleSheet("PRESIDENT")
			styleSheet.Style.FillStyle = New NColorFillStyle(Color.FromArgb(129, 133, 133))
			styleSheet.Style.FillStyle.ImageFiltersStyle.Filters.Add(New NLightingImageFilter())
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the VPs
			styleSheet = New NStyleSheet("VP")
			styleSheet.Style.FillStyle = New NColorFillStyle(Color.FromArgb(162, 173, 182))
			styleSheet.Style.FillStyle.ImageFiltersStyle.Filters.Add(New NLightingImageFilter())
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the managers
			styleSheet = New NStyleSheet("MANAGER")
			styleSheet.Style.FillStyle = New NColorFillStyle(Color.FromArgb(251, 203, 156))
			styleSheet.Style.FillStyle.ImageFiltersStyle.Filters.Add(New NLightingImageFilter())
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the person name labels
			styleSheet = New NStyleSheet("NAME")

			Dim textStyle As NTextStyle = TryCast(document.Style.TextStyle.Clone(), NTextStyle)
			textStyle.FontStyle.InitFromFont(New Font("Arial", 10, FontStyle.Bold))
			textStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
			textStyle.StringFormatStyle.VertAlign = VertAlign.Bottom

			styleSheet.Style.TextStyle = textStyle
			document.StyleSheets.AddChild(styleSheet)

			' create a stylesheet for the person position labels
			styleSheet = New NStyleSheet("POSITION")

			textStyle = TryCast(document.Style.TextStyle.Clone(), NTextStyle)
			textStyle.FontStyle.InitFromFont(New Font("Arial", 10, FontStyle.Bold))
			textStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
			textStyle.StringFormatStyle.VertAlign = VertAlign.Center

			styleSheet.Style.TextStyle = textStyle
			document.StyleSheets.AddChild(styleSheet)
		End Sub
		Private Sub InitDocument(ByVal document As NDrawingDocument)
			' change default document styles
			document.Style.TextStyle.TextFormat = TextFormat.XML
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None
			document.BackgroundStyle.FrameStyle.Visible = False

			' configure shadow (inherited by all objects)
			document.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(150, Color.Black), New NPointL(3, 3), 1, New NLength(4))

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument

			' create the data importer
			Dim databasePath As String = HttpContext.Current.Server.MapPath("..\App_Data\OrgData.xml")
			Dim treeImporter As NTreeDataSourceImporter = New NTreeDataSourceImporter()
			treeImporter.Document = document

			Dim dataSet As DataSet = New DataSet()
			dataSet.ReadXml(databasePath, XmlReadMode.ReadSchema)
			treeImporter.DataSource = dataSet.Tables("Employees")

			' records are uniquely identified by their Id column
			' records link to their parent record by their ParentId column
			treeImporter.IdColumnName = "Id"
			treeImporter.ParentIdColumnName = "ParentId"
			treeImporter.CollapsibleSubtrees = True
			treeImporter.VertexShapesFactory = New NBasicShapesFactory()
			treeImporter.VertexShapesName = BasicShapes.Table.ToString()

			' use tip over tree layout
			Dim tipOverLayout As NTipOverTreeLayout = New NTipOverTreeLayout()
			tipOverLayout.ColRightParentPlacement.Offset = 70
			tipOverLayout.HorizontalSpacing = 30
			tipOverLayout.LeafsPlacement = TipOverChildrenPlacement.ColRight
			treeImporter.Layout = tipOverLayout

			' import the shapes
			AddHandler treeImporter.VertexImported, AddressOf OnTreeImporterVertexImported
			Dim ok As Boolean = treeImporter.Import()

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub InitTableShape(ByVal shape As NTableShape, ByVal employee As NEmployee)
			Dim stylesheetName As String = employee.Position.ToUpper()
			If stylesheetName.StartsWith("VP") Then
				stylesheetName = "VP"
			End If

			shape.Name = employee.Name
			shape.Tag = employee
			shape.InitTable(2, 2)
			shape.BeginUpdate()
			shape.ShowGrid = False
			shape.CellMargins = New Nevron.Diagram.NMargins(2)

			Dim column As NTableColumn = CType(shape.Columns.GetChildAt(1), NTableColumn)
			column.SizeMode = TableColumnSizeMode.Fixed
			column.Width = 108

			shape(0, 0).Margins = New Nevron.Diagram.NMargins(5)
			shape(0, 0).RowSpan = 2
			shape(0, 0).Bitmap = New Bitmap(Me.MapPathSecure(employee.PhotoFileName))
			shape(0, 0).Borders = TableCellBorder.All
			shape(1, 0).Text = employee.Position
			shape(1, 1).Text = employee.Name
			shape(1, 0).StyleSheetName = "POSITION"
			shape(1, 1).StyleSheetName = "NAME"
			shape.StyleSheetName = stylesheetName
			shape.EndUpdate()

			shape.Ports.DefaultInwardPortUniqueId = (CType(shape.Ports.GetChildByName("Bottom"), NPort)).UniqueId
		End Sub

#End Region

#Region "Event Handlers"

		Protected Sub OnTreeImporterVertexImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
			InitTableShape(CType(shape, NTableShape), New NEmployee(record))
		End Sub

#End Region

#Region "Static"

		Private Shared ReadOnly UsCulture As CultureInfo = New CultureInfo("en-US")
		Private Shared ReadOnly TableShapeFilter As NFilter = New NInstanceOfTypeFilter(GetType(NTableShape))
		Private Shared ReadOnly DecoratorFilter As NFilter = New NInstanceOfTypeFilter(GetType(NShowHideSubtreeDecorator))

#End Region

#Region "Nested Types"

		<Serializable()> _
		Private Class NMouseDownEventCallback
			Implements INMouseEventCallback
#Region "INMouseEventCallback Members"

			Private Sub OnMouseEvent(ByVal control As NAspNetThinWebControl, ByVal e As NBrowserMouseEventArgs) Implements INMouseEventCallback.OnMouseEvent
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				Dim nodes As NNodeList = diagramControl.HitTest(New NPointF(e.X, e.Y))
				Dim shapes As NNodeList = nodes.Filter(TableShapeFilter)

				If shapes.Count = 0 Then
					diagramControl.Document.Tag = Nothing
					Return
				End If

				Dim decorators As NNodeList = nodes.Filter(DecoratorFilter)
				If decorators.Count > 0 Then
					' Toggle the clicked show/hide subtree decorator and update the view
					CType(decorators(0), NShowHideSubtreeDecorator).ToggleState()
					diagramControl.UpdateView()
				End If

				' Send a custom command
				Dim table As NTableShape = CType(shapes(0), NTableShape)
				Dim employee As NEmployee = CType(table.Tag, NEmployee)
				diagramControl.AddCustomClientCommand(employee.GetData())
			End Sub

#End Region
		End Class

		<Serializable()> _
		Private Class NEmployee
			Public Sub New(ByVal data As INDataRecord)
				Name = data.GetColumnValue("Name").ToString()
				Position = data.GetColumnValue("Position").ToString()
				BirthDate = CDate(data.GetColumnValue("BirthDate"))
				Salary = CDec(data.GetColumnValue("Salary"))
				Biography = data.GetColumnValue("Biography").ToString()

				Dim photoImage As String = data.GetColumnValue("Photo").ToString()
				PhotoFileName = "~\Images\" & photoImage
			End Sub
			Public Sub New(ByVal other As NEmployee)
				Name = other.Name
				Position = other.Position
				BirthDate = other.BirthDate
				Salary = other.Salary
				Biography = other.Biography
				PhotoFileName = other.PhotoFileName
			End Sub

			Public Function GetData() As String
				Dim sb As StringBuilder = New StringBuilder()
				sb.AppendLine("Name=" & Name)
				sb.AppendLine("Position=" & Position)
				sb.AppendLine("BirthDate=" & BirthDate.ToString("MMMM dd, yyyy", UsCulture))
				sb.AppendLine("Salary=" & Salary.ToString("C", UsCulture))
				sb.AppendLine("Biography=" & Biography)
				sb.AppendLine("Photo=" & PhotoFileName.Replace("~", ".."))

				Return sb.ToString()
			End Function

			Public Name As String
			Public Position As String
			Public BirthDate As DateTime
			Public Salary As Decimal
			Public Biography As String
			Public PhotoFileName As String
		End Class

#End Region
	End Class
End Namespace