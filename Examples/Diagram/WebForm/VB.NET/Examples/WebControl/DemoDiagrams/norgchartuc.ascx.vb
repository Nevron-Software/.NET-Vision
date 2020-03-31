Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Globalization
Imports System.Reflection
Imports System.Web

Imports Nevron.Diagram
Imports Nevron.Diagram.DataImport
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.Shapes
Imports Nevron.Dom
Imports Nevron.Filters
Imports Nevron.GraphicsCore
Imports Nevron.UI.WebForm.Controls
Imports System.Data

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	''' Summary description for NDiagramClassHierarchyUC.
	''' </summary>
	Partial Public Class NOrgChartUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				' begin view init
				NDrawingView1.ViewLayout = CanvasLayout.Fit

				' init document
				NDrawingView1.Document.HistoryService.Stop()
				NDrawingView1.Document.BeginInit()
				CreateStyleSheets()
				InitDocument()
				NDrawingView1.Document.EndInit()
			End If
		End Sub

#Region "Implementation"

		Private Sub CreateStyleSheets()
			Dim document As NDrawingDocument = NDrawingView1.Document

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
		Private Sub InitDocument()
			Dim document As NDrawingDocument = NDrawingView1.Document

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
			AddHandler treeImporter.VertexImported, AddressOf treeImporter_VertexImported
			Dim ok As Boolean = treeImporter.Import()

			' resize document to fit all shapes
			document.SizeToContent()
		End Sub
		Private Sub InitTableShape(ByVal shape As NTableShape, ByVal employee As NEmployee)
			'	employee.Photo = this.MapPathSecure(employee.Photo);

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
			shape(0, 0).Bitmap = New Bitmap(Me.MapPathSecure(employee.PhotoPath))
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

		Protected Sub treeImporter_VertexImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
			InitTableShape(CType(shape, NTableShape), New NEmployee(record))
		End Sub
		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxMouseClickCallbackTool(True))
		End Sub
		Protected Sub NDrawingView1_AsyncClick(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackMouseEventArgs = TryCast(e, NCallbackMouseEventArgs)

			Dim nodes As NNodeList = NDrawingView1.HitTest(args)
			Dim shapes As NNodeList = nodes.Filter(TABLE_SHAPE_FILTER)

			If shapes.Count = 0 Then
				NDrawingView1.Document.Tag = Nothing
				Return
			End If

			Dim decorators As NNodeList = nodes.Filter(DECORATOR_FILTER)
			If decorators.Count > 0 Then
				CType(decorators(0), NShowHideSubtreeDecorator).ToggleState()
			End If

			Dim table As NTableShape = CType(shapes(0), NTableShape)
			Dim employee As NEmployee = CType(table.Tag, NEmployee)
			NDrawingView1.Document.Tag = employee
			NDrawingView1.Document.SmartRefreshAllViews()
		End Sub
		Protected Sub NDrawingView1_AsyncQueryCommandResult(ByVal sender As Object, ByVal e As EventArgs)
			Dim args As NCallbackQueryCommandResultArgs = TryCast(e, NCallbackQueryCommandResultArgs)
			Dim command As NCallbackCommand = args.Command
			Dim resultBuilder As NAjaxXmlTransportBuilder = args.ResultBuilder

			Select Case command.Name
				Case "mouseClick"
					'	build a custom response data section
					Dim employee As NEmployee = TryCast(NDrawingView1.Document.Tag, NEmployee)
					If employee Is Nothing Then
						Return
					End If

					employee.SetAjaxData(resultBuilder)
			End Select
		End Sub

#End Region

#Region "Static"

		Private Shared ReadOnly CULTURE As CultureInfo = New CultureInfo("en-US")
		Private Shared ReadOnly TABLE_SHAPE_FILTER As NFilter = New NInstanceOfTypeFilter(GetType(NTableShape))
		Private Shared ReadOnly DECORATOR_FILTER As NFilter = New NInstanceOfTypeFilter(GetType(NShowHideSubtreeDecorator))

#End Region

#Region "Nested Types"

		Private Class NEmployee
			Implements ICloneable
			Public Name As String
			Public Position As String
			Public BirthDate As DateTime
			Public Salary As Decimal
			Public Biography As String
			Public PhotoPath As String
			Public Photo As String

			Public Sub New(ByVal data As INDataRecord)
				Name = data.GetColumnValue("Name").ToString()
				Position = data.GetColumnValue("Position").ToString()
				BirthDate = CDate(data.GetColumnValue("BirthDate"))
				Salary = CDec(data.GetColumnValue("Salary"))
				Biography = data.GetColumnValue("Biography").ToString()

				Dim photoImage As String = data.GetColumnValue("Photo").ToString()
				PhotoPath = "~\Images\" & photoImage
				Photo = "..\Images\" & photoImage
			End Sub
			Public Sub New(ByVal other As NEmployee)
				Name = other.Name
				Position = other.Position
				BirthDate = other.BirthDate
				Salary = other.Salary
				Biography = other.Biography
				Photo = other.Photo
				Photo = other.Photo
			End Sub

#Region "ICloneable Members"

			Public Function Clone() As Object Implements ICloneable.Clone
				Return New NEmployee(Me)
			End Function

#End Region

			Public Sub SetAjaxData(ByVal resultBuilder As NAjaxXmlTransportBuilder)
				Dim fields As FieldInfo() = Me.GetType().GetFields()
				Dim i As Integer, count As Integer = fields.Length
				Dim format As String

				i = 0
				Do While i < count
					Dim dataSection As NAjaxXmlDataSection = New NAjaxXmlDataSection(fields(i).Name.ToLower())
					Select Case fields(i).FieldType.Name
						Case "DateTime"
							dataSection.Data = String.Format(CULTURE, "{0:MMMM dd, yyyy}", fields(i).GetValue(Me))

						Case Else
							If dataSection.Name = "salary" Then
								format = ":C"
							Else
								format = String.Empty
							End If
							dataSection.Data = String.Format(CULTURE, "{0" & format & "}", fields(i).GetValue(Me))
					End Select

					Select Case dataSection.Name
						Case "salary"
							dataSection.Data = "Salary: " & dataSection.Data

						Case "birthdate"
							dataSection.Data = "Birth Date: " & dataSection.Data
					End Select

					resultBuilder.AddDataSection(dataSection)
					i += 1
				Loop
			End Sub
		End Class

#End Region
	End Class
End Namespace