Imports Microsoft.VisualBasic
	Imports System
	Imports System.Data
	Imports System.Xml
	Imports System.Runtime.Serialization
Namespace Nevron.Examples.Chart.WebForm

	<Serializable(), System.ComponentModel.DesignerCategoryAttribute("code"), System.Diagnostics.DebuggerStepThrough(), System.ComponentModel.ToolboxItem(True)> _
	Public Class dsTable
		Inherits DataSet

		Private tableMyTable As MyTableDataTable

		Public Sub New()
			Me.InitClass()
			Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = New System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
			AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
			AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
		End Sub

		Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
			Dim strSchema As String = (CStr(info.GetValue("XmlSchema", GetType(String))))
			If (Not strSchema Is Nothing) Then
				Dim ds As DataSet = New DataSet()
				ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
				If (Not ds.Tables("MyTable") Is Nothing) Then
					Me.Tables.Add(New MyTableDataTable(ds.Tables("MyTable")))
				End If
				Me.DataSetName = ds.DataSetName
				Me.Prefix = ds.Prefix
				Me.Namespace = ds.Namespace
				Me.Locale = ds.Locale
				Me.CaseSensitive = ds.CaseSensitive
				Me.EnforceConstraints = ds.EnforceConstraints
				Me.Merge(ds, False, System.Data.MissingSchemaAction.Add)
				Me.InitVars()
			Else
				Me.InitClass()
			End If
			Me.GetSerializationData(info, context)
			Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = New System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
			AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
			AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
		End Sub

		<System.ComponentModel.Browsable(False), System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)> _
		Public ReadOnly Property MyTable() As MyTableDataTable
			Get
				Return Me.tableMyTable
			End Get
		End Property

		Public Overrides Function Clone() As DataSet
			Dim cln As dsTable = (CType(MyBase.Clone(), dsTable))
			cln.InitVars()
			Return cln
		End Function

		Protected Overrides Function ShouldSerializeTables() As Boolean
			Return False
		End Function

		Protected Overrides Function ShouldSerializeRelations() As Boolean
			Return False
		End Function

		Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
			Me.Reset()
			Dim ds As DataSet = New DataSet()
			ds.ReadXml(reader)
			If (Not ds.Tables("MyTable") Is Nothing) Then
				Me.Tables.Add(New MyTableDataTable(ds.Tables("MyTable")))
			End If
			Me.DataSetName = ds.DataSetName
			Me.Prefix = ds.Prefix
			Me.Namespace = ds.Namespace
			Me.Locale = ds.Locale
			Me.CaseSensitive = ds.CaseSensitive
			Me.EnforceConstraints = ds.EnforceConstraints
			Me.Merge(ds, False, System.Data.MissingSchemaAction.Add)
			Me.InitVars()
		End Sub

		Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
			Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream()
			Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
			stream.Position = 0
			Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
		End Function

		Friend Sub InitVars()
			Me.tableMyTable = (CType(Me.Tables("MyTable"), MyTableDataTable))
			If (Not Me.tableMyTable Is Nothing) Then
				Me.tableMyTable.InitVars()
			End If
		End Sub

		Private Sub InitClass()
			Me.DataSetName = "dsTable"
			Me.Prefix = ""
			Me.Namespace = "http://www.tempuri.org/dsTable.xsd"
			Me.Locale = New System.Globalization.CultureInfo("bg-BG")
			Me.CaseSensitive = False
			Me.EnforceConstraints = True
			Me.tableMyTable = New MyTableDataTable()
			Me.Tables.Add(Me.tableMyTable)
		End Sub

		Private Function ShouldSerializeMyTable() As Boolean
			Return False
		End Function

		Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
			If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
				Me.InitVars()
			End If
		End Sub

		Public Delegate Sub MyTableRowChangeEventHandler(ByVal sender As Object, ByVal e As MyTableRowChangeEvent)

		<System.Diagnostics.DebuggerStepThrough()> _
		Public Class MyTableDataTable
			Inherits DataTable
			Implements System.Collections.IEnumerable

			Public columnid As DataColumn
			Public columncolors As DataColumn
			Public columnvalues As DataColumn

			Friend Sub New()
				MyBase.New("MyTable")
				Me.InitClass()
			End Sub

			Friend Sub New(ByVal table As DataTable)
				MyBase.New(table.TableName)
				If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
					Me.CaseSensitive = table.CaseSensitive
				End If
				If (table.Locale.ToString() <> table.DataSet.Locale.ToString()) Then
					Me.Locale = table.Locale
				End If
				If (table.Namespace <> table.DataSet.Namespace) Then
					Me.Namespace = table.Namespace
				End If
				Me.Prefix = table.Prefix
				Me.MinimumCapacity = table.MinimumCapacity
				Me.DisplayExpression = table.DisplayExpression
			End Sub

			<System.ComponentModel.Browsable(False)> _
			Public ReadOnly Property Count() As Integer
				Get
					Return Me.Rows.Count
				End Get
			End Property

			Friend ReadOnly Property idColumn() As DataColumn
				Get
					Return Me.columnid
				End Get
			End Property

			Friend ReadOnly Property colorsColumn() As DataColumn
				Get
					Return Me.columncolors
				End Get
			End Property

			Friend ReadOnly Property valuesColumn() As DataColumn
				Get
					Return Me.columnvalues
				End Get
			End Property

			Public ReadOnly Default Property Item(ByVal index As Integer) As MyTableRow
				Get
					Return (CType(Me.Rows(index), MyTableRow))
				End Get
			End Property

			Public Event MyTableRowChanged As MyTableRowChangeEventHandler

			Public Event MyTableRowChanging As MyTableRowChangeEventHandler

			Public Event MyTableRowDeleted As MyTableRowChangeEventHandler

			Public Event MyTableRowDeleting As MyTableRowChangeEventHandler

			Public Sub AddMyTableRow(ByVal row As MyTableRow)
				Me.Rows.Add(row)
			End Sub

			Public Function AddMyTableRow(ByVal colors As String, ByVal values As Integer) As MyTableRow
				Dim rowMyTableRow As MyTableRow = (CType(Me.NewRow(), MyTableRow))
				rowMyTableRow.ItemArray = New Object() { Nothing, colors, values}
				Me.Rows.Add(rowMyTableRow)
				Return rowMyTableRow
			End Function

			Public Function FindByid(ByVal id As Integer) As MyTableRow
				Return (CType(Me.Rows.Find(New Object() { id}), MyTableRow))
			End Function

			Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
				Return Me.Rows.GetEnumerator()
			End Function

			Public Overrides Function Clone() As DataTable
				Dim cln As MyTableDataTable = (CType(MyBase.Clone(), MyTableDataTable))
				cln.InitVars()
				Return cln
			End Function

			Protected Overrides Function CreateInstance() As DataTable
				Return New MyTableDataTable()
			End Function

			Friend Sub InitVars()
				Me.columnid = Me.Columns("id")
				Me.columncolors = Me.Columns("colors")
				Me.columnvalues = Me.Columns("values")
			End Sub

			Private Sub InitClass()
				Me.columnid = New DataColumn("id", GetType(Integer), Nothing, System.Data.MappingType.Element)
				Me.Columns.Add(Me.columnid)
				Me.columncolors = New DataColumn("colors", GetType(String), Nothing, System.Data.MappingType.Element)
				Me.Columns.Add(Me.columncolors)
				Me.columnvalues = New DataColumn("values", GetType(Integer), Nothing, System.Data.MappingType.Element)
				Me.Columns.Add(Me.columnvalues)
				Me.Constraints.Add(New UniqueConstraint("Constraint1", New DataColumn() { Me.columnid}, True))
				Me.columnid.AutoIncrement = True
				Me.columnid.AllowDBNull = False
				Me.columnid.Unique = True
			End Sub

			Public Function NewMyTableRow() As MyTableRow
				Return (CType(Me.NewRow(), MyTableRow))
			End Function

			Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
				Return New MyTableRow(builder)
			End Function

			Protected Overrides Function GetRowType() As System.Type
				Return GetType(MyTableRow)
			End Function

			Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
				MyBase.OnRowChanged(e)
				If (Not Me.MyTableRowChangedEvent Is Nothing) Then
					RaiseEvent MyTableRowChanged(Me, New MyTableRowChangeEvent((CType(e.Row, MyTableRow)), e.Action))
				End If
			End Sub

			Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
				MyBase.OnRowChanging(e)
				If (Not Me.MyTableRowChangingEvent Is Nothing) Then
					RaiseEvent MyTableRowChanging(Me, New MyTableRowChangeEvent((CType(e.Row, MyTableRow)), e.Action))
				End If
			End Sub

			Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
				MyBase.OnRowDeleted(e)
				If (Not Me.MyTableRowDeletedEvent Is Nothing) Then
					RaiseEvent MyTableRowDeleted(Me, New MyTableRowChangeEvent((CType(e.Row, MyTableRow)), e.Action))
				End If
			End Sub

			Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
				MyBase.OnRowDeleting(e)
				If (Not Me.MyTableRowDeletingEvent Is Nothing) Then
					RaiseEvent MyTableRowDeleting(Me, New MyTableRowChangeEvent((CType(e.Row, MyTableRow)), e.Action))
				End If
			End Sub

			Public Sub RemoveMyTableRow(ByVal row As MyTableRow)
				Me.Rows.Remove(row)
			End Sub
		End Class

		<System.Diagnostics.DebuggerStepThrough()> _
		Public Class MyTableRow
			Inherits DataRow

			Private tableMyTable As MyTableDataTable

			Friend Sub New(ByVal rb As DataRowBuilder)
				MyBase.New(rb)
				Me.tableMyTable = (CType(Me.Table, MyTableDataTable))
			End Sub

			Public Property id() As Integer
				Get
					Return (CInt(Fix(Me(Me.tableMyTable.idColumn))))
				End Get
				Set
					Me(Me.tableMyTable.idColumn) = Value
				End Set
			End Property

			Public Property colors() As String
				Get
					Try
						Return (CStr(Me(Me.tableMyTable.colorsColumn)))
					Catch e As InvalidCastException
						Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
					End Try
				End Get
				Set
					Me(Me.tableMyTable.colorsColumn) = Value
				End Set
			End Property

			Public Property values() As Integer
				Get
					Try
						Return (CInt(Fix(Me(Me.tableMyTable.valuesColumn))))
					Catch e As InvalidCastException
						Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
					End Try
				End Get
				Set
					Me(Me.tableMyTable.valuesColumn) = Value
				End Set
			End Property

			Public Function IscolorsNull() As Boolean
				Return Me.IsNull(Me.tableMyTable.colorsColumn)
			End Function

			Public Sub SetcolorsNull()
				Me(Me.tableMyTable.colorsColumn) = System.Convert.DBNull
			End Sub

			Public Function IsvaluesNull() As Boolean
				Return Me.IsNull(Me.tableMyTable.valuesColumn)
			End Function

			Public Sub SetvaluesNull()
				Me(Me.tableMyTable.valuesColumn) = System.Convert.DBNull
			End Sub
		End Class

		<System.Diagnostics.DebuggerStepThrough()> _
		Public Class MyTableRowChangeEvent
			Inherits EventArgs

			Private eventRow As MyTableRow

			Private eventAction As DataRowAction

			Public Sub New(ByVal tableRow As MyTableRow, ByVal dataRowAction As DataRowAction)
				Me.eventRow = tableRow
				Me.eventAction = dataRowAction
			End Sub

			Public ReadOnly Property Row() As MyTableRow
				Get
					Return Me.eventRow
				End Get
			End Property

			Public ReadOnly Property Action() As DataRowAction
				Get
					Return Me.eventAction
				End Get
			End Property
		End Class
	End Class
End Namespace
