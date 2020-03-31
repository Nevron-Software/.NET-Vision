Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.DataImport
Imports Nevron.Diagram.DataStructures
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Diagram.Shapes
Imports System.Collections.Generic

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NCompanyOrgChartUC.
	''' </summary>
	Public Class NCompanyOrgChartUC
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
			Me.pEmployee = New System.Windows.Forms.Panel()
			Me.lblSalary = New System.Windows.Forms.Label()
			Me.lblBirthDate = New System.Windows.Forms.Label()
			Me.lblBiography = New System.Windows.Forms.Label()
			Me.lblPosition = New System.Windows.Forms.Label()
			Me.lblName = New System.Windows.Forms.Label()
			Me.pbPhoto = New System.Windows.Forms.PictureBox()
			Me.pEmployee.SuspendLayout()
			CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pEmployee
			' 
			Me.pEmployee.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.pEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pEmployee.Controls.Add(Me.lblSalary)
			Me.pEmployee.Controls.Add(Me.lblBirthDate)
			Me.pEmployee.Controls.Add(Me.lblBiography)
			Me.pEmployee.Controls.Add(Me.lblPosition)
			Me.pEmployee.Controls.Add(Me.lblName)
			Me.pEmployee.Controls.Add(Me.pbPhoto)
			Me.pEmployee.Location = New System.Drawing.Point(3, 3)
			Me.pEmployee.Name = "pEmployee"
			Me.pEmployee.Size = New System.Drawing.Size(242, 200)
			Me.pEmployee.TabIndex = 1
			Me.pEmployee.Visible = False
			' 
			' lblSalary
			' 
			Me.lblSalary.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblSalary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.lblSalary.Location = New System.Drawing.Point(90, 83)
			Me.lblSalary.Name = "lblSalary"
			Me.lblSalary.Size = New System.Drawing.Size(146, 19)
			Me.lblSalary.TabIndex = 5
			Me.lblSalary.Text = "Salary"
			Me.lblSalary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' lblBirthDate
			' 
			Me.lblBirthDate.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblBirthDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.lblBirthDate.Location = New System.Drawing.Point(90, 57)
			Me.lblBirthDate.Name = "lblBirthDate"
			Me.lblBirthDate.Size = New System.Drawing.Size(146, 19)
			Me.lblBirthDate.TabIndex = 4
			Me.lblBirthDate.Text = "Birth Date"
			Me.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' lblBiography
			' 
			Me.lblBiography.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblBiography.Font = New System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.lblBiography.Location = New System.Drawing.Point(3, 113)
			Me.lblBiography.Name = "lblBiography"
			Me.lblBiography.Size = New System.Drawing.Size(233, 75)
			Me.lblBiography.TabIndex = 3
			Me.lblBiography.Text = "Bigraphy"
			Me.lblBiography.TextAlign = System.Drawing.ContentAlignment.TopCenter
			' 
			' lblPosition
			' 
			Me.lblPosition.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.lblPosition.Location = New System.Drawing.Point(90, 31)
			Me.lblPosition.Name = "lblPosition"
			Me.lblPosition.Size = New System.Drawing.Size(146, 19)
			Me.lblPosition.TabIndex = 2
			Me.lblPosition.Text = "Position"
			Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' lblName
			' 
			Me.lblName.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.lblName.Location = New System.Drawing.Point(90, 5)
			Me.lblName.Name = "lblName"
			Me.lblName.Size = New System.Drawing.Size(146, 19)
			Me.lblName.TabIndex = 1
			Me.lblName.Text = "Name"
			Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' pbPhoto
			' 
			Me.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pbPhoto.Location = New System.Drawing.Point(4, 3)
			Me.pbPhoto.Name = "pbPhoto"
			Me.pbPhoto.Size = New System.Drawing.Size(80, 100)
			Me.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
			Me.pbPhoto.TabIndex = 0
			Me.pbPhoto.TabStop = False
			' 
			' NCompanyOrgChartUC
			' 
			Me.Controls.Add(Me.pEmployee)
			Me.Name = "NCompanyOrgChartUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.Controls.SetChildIndex(Me.pEmployee, 0)
			Me.pEmployee.ResumeLayout(False)
			CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub AttachToEvents()
			MyBase.AttachToEvents()
			AddHandler document.EventSinkService.NodeMouseDown, AddressOf EventSinkService_NodeMouseDown
		End Sub
		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init view
			view.ViewLayout = ViewLayout.Fit
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False

			' init document
			document.BeginInit()
			CreateStyleSheets()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub DetachFromEvents()
			RemoveHandler document.EventSinkService.NodeMouseDown, AddressOf EventSinkService_NodeMouseDown
			MyBase.DetachFromEvents()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub CreateStyleSheets()
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
			m_Dict = New Dictionary(Of NTableShape, NEmployee)()

			' change default document styles
			document.Style.TextStyle.TextFormat = TextFormat.XML
			document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None
			document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None

			' configure shadow (inherited by all objects)
			document.Style.ShadowStyle = New NShadowStyle(ShadowType.GaussianBlur, Color.FromArgb(150, Color.Black), New NPointL(3, 3), 1, New NLength(4))

			document.ShadowsZOrder = ShadowsZOrder.BehindDocument

			' create the data importer
			Dim databasePath As String = Path.Combine(Application.StartupPath, "..\..\Resources\Data\OrgData.mdb")
			Dim treeImporter As NTreeDataSourceImporter = New NTreeDataSourceImporter()
			treeImporter.Document = document
			treeImporter.DataSource = New OleDbDataAdapter("SELECT * FROM Employees", String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", databasePath))

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
			m_Dict.Add(shape, employee)

			Dim stylesheetName As String = employee.Position.ToUpper()
			If stylesheetName.StartsWith("VP") Then
				stylesheetName = "VP"
			End If

			shape.InitTable(2, 2)
			shape.BeginUpdate()
			shape.ShowGrid = False
			shape.CellMargins = New Nevron.Diagram.NMargins(2)

			Dim column As NTableColumn = CType(shape.Columns.GetChildAt(1), NTableColumn)
			column.SizeMode = TableColumnSizeMode.Fixed
			column.Width = 108

			shape(0, 0).Margins = New Nevron.Diagram.NMargins(5)
			shape(0, 0).RowSpan = 2
			shape(0, 0).Bitmap = employee.Photo
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

		Private Sub treeImporter_VertexImported(ByVal dataSourceImporter As NDataSourceImporter, ByVal shape As NShape, ByVal record As INDataRecord)
			InitTableShape(CType(shape, NTableShape), New NEmployee(record))
		End Sub
		Private Sub EventSinkService_NodeMouseDown(ByVal args As NNodeMouseEventArgs)
			If args.Button <> MouseButtons.Left OrElse Not(TypeOf args.Node Is NTableShape OrElse TypeOf args.Node Is NGroupSampleUC) Then
				pEmployee.Visible = False
				Return
			End If

			Dim node As INNode = args.Node
			Do While Not(TypeOf node Is NTableShape)
				node = node.ParentNode
			Loop

			Dim employee As NEmployee = m_Dict(CType(node, NTableShape))
			pbPhoto.Image = employee.Photo
			lblName.Text = employee.Name
			lblPosition.Text = employee.Position
			lblBirthDate.Text = String.Format(CULTURE, "Birth Date: {0:MMMM dd, yyyy}", employee.BirthDate)
			lblSalary.Text = "Salary: " & employee.Salary.ToString("C", CULTURE)
			lblBiography.Text = employee.Biography

			pEmployee.Visible = True
			args.Handled = Not(TypeOf args.Node Is NGroupSampleUC)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private pEmployee As Panel
		Private pbPhoto As PictureBox
		Private lblName As Label
		Private lblPosition As Label
		Private lblBiography As Label
		Private lblBirthDate As Label
		Private lblSalary As Label

		#End Region

		#Region "Fields"

		Private m_Dict As Dictionary(Of NTableShape, NEmployee)

		#End Region

		#Region "Static"

		Private Shared ReadOnly CULTURE As CultureInfo = New CultureInfo("en-US")

		#End Region

		#Region "Nested Types"

		Private Class NEmployee
			Public Sub New(ByVal data As INDataRecord)
				Name = data.GetColumnValue("Name").ToString()
				Position = data.GetColumnValue("Position").ToString()
				BirthDate = CDate(data.GetColumnValue("BirthDate"))
				Salary = CDec(data.GetColumnValue("Salary"))
				Biography = data.GetColumnValue("Biography").ToString()

				Dim imageData As Byte() = TryCast(data.GetColumnValue("Photo"), Byte())
				If Not imageData Is Nothing Then
					' Signature bytes of an OLE container header.
					Const OLEbyte0 As Byte = 21
					Const OLEbyte1 As Byte = 28

					' Number of bytes in an OLE container header.
					Const OLEheaderLength As Integer = 78

					' Test for an OLE container header
					If (imageData(0) = OLEbyte0) AndAlso (imageData(1) = OLEbyte1) Then
						' Use a second array to strip off the header. Make it big enough to hold
						' the bytes after the header.
						Dim strippedData As Byte() = New Byte(imageData.Length - OLEheaderLength - 1){}

						' Strip off the header by copying the bytes after the header.
						Array.Copy(imageData, OLEheaderLength, strippedData, 0, imageData.Length - OLEheaderLength)
						imageData = strippedData
					End If

					Photo = New Bitmap(New MemoryStream(imageData))
				Else
					Photo = New Bitmap(80, 100)
				End If
			End Sub

			Public Name As String
			Public Position As String
			Public BirthDate As DateTime
			Public Salary As Decimal
			Public Biography As String
			Public Photo As Bitmap
		End Class

		#End Region
	End Class
End Namespace