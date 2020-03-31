Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Chart
Imports Nevron.Chart.WinForm

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NBindingToIBindingListUC
		Inherits NExampleBaseUC

		Private m_MyBindingList As MyBindingList
		Private m_TypedList As MyList
		Private dataGrid1 As System.Windows.Forms.DataGrid
		Private WithEvents comboBox1 As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label

		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()
			m_MyBindingList = New MyBindingList()
			m_TypedList = New MyList()
			comboBox1.Items.Add("List Of Custom Objects")
			comboBox1.Items.Add("ITypedList")
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
			Me.dataGrid1 = New System.Windows.Forms.DataGrid()
			Me.comboBox1 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			DirectCast(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataGrid1
			' 
			Me.dataGrid1.DataMember = ""
			Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dataGrid1.Location = New System.Drawing.Point(8, 72)
			Me.dataGrid1.Name = "dataGrid1"
			Me.dataGrid1.ReadOnly = True
			Me.dataGrid1.RowHeadersVisible = False
			Me.dataGrid1.Size = New System.Drawing.Size(192, 232)
			Me.dataGrid1.TabIndex = 0
			' 
			' comboBox1
			' 
			Me.comboBox1.Location = New System.Drawing.Point(8, 40)
			Me.comboBox1.Name = "comboBox1"
			Me.comboBox1.Size = New System.Drawing.Size(192, 21)
			Me.comboBox1.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(176, 23)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Bind To:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NBindingToIBindingListUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.comboBox1)
			Me.Controls.Add(Me.dataGrid1)
			Me.Name = "NBindingToIBindingListUC"
			Me.Size = New System.Drawing.Size(208, 504)
			DirectCast(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' setup background

			nChartControl1.Legends(0).Visible = False

			' add a label
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Binding to IBindingList")

			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))


			Dim chart As NChart = nChartControl1.Charts(0)

			' add the bar series
			Dim bar As NBarSeries = CType(chart.Series.Add(SeriesType.Bar), NBarSeries)
			bar.Name = "Bar"
			bar.Legend.Format = "<label>"
			bar.DataLabelStyle.Format = "<label>"

			comboBox1.SelectedIndex = 0

			SetChartControl()
		End Sub


		Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboBox1.SelectedIndexChanged
			SetChartControl()
		End Sub

		Private Sub SetChartControl()
			m_MyBindingList.Clear()
			m_TypedList.Clear()

			nChartControl1.DataBindingManager.RemoveAllBindings()

			dataGrid1.DataSource = Nothing

			'Binding to a list of custom objects.
			If comboBox1.SelectedIndex = 0 Then
				m_MyBindingList.Add(New MyCustomObject(5, "Violet", New NColorFillStyle(Color.Violet)))
				m_MyBindingList.Add(New MyCustomObject(7, "Blue", New NColorFillStyle(Color.Blue)))
				m_MyBindingList.Add(New MyCustomObject(3, "Green", New NColorFillStyle(Color.Green)))
				m_MyBindingList.Add(New MyCustomObject(15, "Yellow-Green", New NColorFillStyle(Color.YellowGreen)))
				m_MyBindingList.Add(New MyCustomObject(2, "Yellow", New NColorFillStyle(Color.Yellow)))
				m_MyBindingList.Add(New MyCustomObject(9, "Orange", New NColorFillStyle(Color.Orange)))
				m_MyBindingList.Add(New MyCustomObject(6, "Orange-Red", New NColorFillStyle(Color.OrangeRed)))
				m_MyBindingList.Add(New MyCustomObject(10, "Red", New NColorFillStyle(Color.Red)))
				m_MyBindingList.Add(New MyCustomObject(6, "Purple", New NColorFillStyle(Color.Purple)))

				dataGrid1.DataSource = m_MyBindingList

				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", m_MyBindingList, "ValueY")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", m_MyBindingList, "Label")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", m_MyBindingList, "FillStyle")
			End If

			'Binding to a ITypedList
			If comboBox1.SelectedIndex = 1 Then
				m_TypedList.Add(New MyCustomObject(1, "Violet", New NColorFillStyle(Color.Violet)))
				m_TypedList.Add(New MyCustomObject(5, "Blue", New NColorFillStyle(Color.Blue)))
				m_TypedList.Add(New MyCustomObject(14, "Green", New NColorFillStyle(Color.Green)))
				m_TypedList.Add(New MyCustomObject(6, "Yellow-Green", New NColorFillStyle(Color.YellowGreen)))
				m_TypedList.Add(New MyCustomObject(3, "Yellow", New NColorFillStyle(Color.Yellow)))
				m_TypedList.Add(New MyCustomObject(9, "Orange", New NColorFillStyle(Color.Orange)))
				m_TypedList.Add(New MyCustomObject(8, "Orange-Red", New NColorFillStyle(Color.OrangeRed)))
				m_TypedList.Add(New MyCustomObject(7, "Red", New NColorFillStyle(Color.Red)))
				m_TypedList.Add(New MyCustomObject(4, "Purple", New NColorFillStyle(Color.Purple)))

				dataGrid1.DataSource = m_TypedList

				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", m_TypedList, "ValueY")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", m_TypedList, "Label")
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", m_TypedList, "FillStyle")
			End If
		End Sub


		Private Class MyCustomObject
			#Region "Constructors"

			Public Sub New()

			End Sub


			Public Sub New(ByVal valueY As Double, ByVal label As String)
				m_ValueY = valueY
				m_Label = label
			End Sub


			Public Sub New(ByVal valueY As Double, ByVal label As String, ByVal fillStyle As NFillStyle)
				m_ValueY = valueY
				m_Label = label
				m_FillStile = fillStyle
			End Sub


			#End Region

			#Region "Properties"

			Public Property ValueY() As Double
				Get
					Return m_ValueY
				End Get
				Set(ByVal value As Double)
					m_ValueY = value
				End Set
			End Property

			Public Property Label() As String
				Get
					Return m_Label
				End Get
				Set(ByVal value As String)
					m_Label = value
				End Set
			End Property


			Public Property FillStyle() As NFillStyle
				Get
					If m_FillStile Is Nothing Then
						m_FillStile = New NColorFillStyle()
					End If
					Return m_FillStile
				End Get
				Set(ByVal value As NFillStyle)
					m_FillStile = value
				End Set
			End Property


			#End Region

			#Region "Fields"

			Private m_ValueY As Double
			Private m_Label As String
			Private m_FillStile As NFillStyle

			#End Region    
		End Class


		Private Class MyBindingList
			Implements IBindingList

			#Region "Constructors"

			Public Sub New()
				m_List = New ArrayList()
				m_SortDirection = ListSortDirection.Ascending
				m_ResetEventArgs = New ListChangedEventArgs(ListChangedType.Reset, -1)
			End Sub


			#End Region

			#Region "IBindingList Members"

			#Region "Methods"

			Public Sub AddIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.AddIndex

			End Sub


			Public Sub ApplySort(ByVal [property] As PropertyDescriptor, ByVal direction As System.ComponentModel.ListSortDirection) Implements IBindingList.ApplySort

			End Sub


			Public Function Find(ByVal [property] As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
				Return -1
			End Function


			Public Sub RemoveSort() Implements IBindingList.RemoveSort

			End Sub


			Public Function AddNew() As Object Implements IBindingList.AddNew
				Dim o As New Object()
				Dim n As Integer = m_List.Add(o)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, n))
				Return o
			End Function


			Public Sub RemoveIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.RemoveIndex

			End Sub


			#End Region

			#Region "Properties"

			Public ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
				Get
					Return Nothing
				End Get
			End Property


			Public ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
				Get
					Return m_SortDirection
				End Get
			End Property


			Public Custom Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged
				AddHandler(ByVal value As ListChangedEventHandler)
					m_OnListChanged = DirectCast(System.Delegate.Combine(m_OnListChanged, value), ListChangedEventHandler)
				End AddHandler
				RemoveHandler(ByVal value As ListChangedEventHandler)
					m_OnListChanged = DirectCast(System.Delegate.Remove(m_OnListChanged, value), ListChangedEventHandler)
				End RemoveHandler
				RaiseEvent(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
					If m_OnListChanged IsNot Nothing Then
						For Each d As ListChangedEventHandler In m_OnListChanged.GetInvocationList()
							d.Invoke(sender, e)
						Next d
					End If
				End RaiseEvent
			End Event


			Public ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
				Get

					Return True
				End Get
			End Property


			Public ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
				Get
					Return True
				End Get
			End Property


			#End Region

			#End Region

			#Region "IList Members"

			#Region "Methods"

			Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
				m_List.RemoveAt(index)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
			End Sub


			Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
				m_List.Insert(index, value)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
			End Sub


			Public Sub Remove(ByVal value As Object) Implements System.Collections.IList.Remove
				m_List.Remove(value)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, m_List.IndexOf(value)))
			End Sub


			Public Function Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
				Return m_List.Contains(value)
			End Function


			Public Sub Clear() Implements System.Collections.IList.Clear
				m_List.Clear()
				OnListChanged(m_ResetEventArgs)
			End Sub


			Public Function IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf
				Return m_List.IndexOf(value)
			End Function


			Public Function Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
				m_List.Add(value)
				Dim last As Integer = m_List.IndexOf(value)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, last))
				Return last
			End Function


			#End Region

			#Region "Properties"

			Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
				Get
					Return m_List.IsReadOnly
				End Get
			End Property


			Default Public Property Item(ByVal index As Integer) As Object Implements System.Collections.IList.Item
				Get
					Return m_List(index)
				End Get
				Set(ByVal value As Object)
					m_List(index) = value
					OnListChanged(New ListChangedEventArgs(ListChangedType.ItemChanged, index))
				End Set
			End Property


			Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
				Get
					Return True
				End Get
			End Property


			#End Region

			#End Region

			#Region "ICollection Members"

			Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
				m_List.CopyTo(array, index)
			End Sub


			Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
				Get
					Return m_List.IsSynchronized
				End Get
			End Property


			Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
				Get
					Return m_List.Count
				End Get
			End Property


			Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
				Get
					Return m_List.SyncRoot
				End Get
			End Property


			#End Region

			#Region "IEnumerable Members"

			Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
				Return m_List.GetEnumerator()
			End Function


			#End Region

			Protected Overridable Sub OnListChanged(ByVal ev As ListChangedEventArgs)
				If m_OnListChanged IsNot Nothing Then
					m_OnListChanged(Me, ev)
				End If
			End Sub


			#Region "Fields"

			Private m_List As ArrayList
			Private m_SortDirection As ListSortDirection
			Private m_OnListChanged As ListChangedEventHandler
			Friend Shared m_ResetEventArgs As ListChangedEventArgs

			#End Region
		End Class


		Private Class MyList
			Implements IBindingList, ITypedList

			#Region "Constructors"

			Public Sub New()
				m_List = New ArrayList()
				m_SortDirection = ListSortDirection.Ascending
				m_ResetEventArgs = New ListChangedEventArgs(ListChangedType.Reset, -1)
			End Sub


			#End Region

			#Region "IBindingList Members"


			#Region "Methods"

			Public Sub AddIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.AddIndex

			End Sub


			Public Sub ApplySort(ByVal [property] As PropertyDescriptor, ByVal direction As System.ComponentModel.ListSortDirection) Implements IBindingList.ApplySort

			End Sub


			Public Function Find(ByVal [property] As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
				Return -1
			End Function


			Public Sub RemoveSort() Implements IBindingList.RemoveSort

			End Sub


			Public Function AddNew() As Object Implements IBindingList.AddNew
				Dim o As New Object()
				Dim n As Integer = m_List.Add(o)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, n))
				Return o
			End Function


			Public Sub RemoveIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.RemoveIndex

			End Sub


			#End Region

			#Region "Properties"

			Public ReadOnly Property AllowNew() As Boolean Implements IBindingList.AllowNew
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
				Get
					Return Nothing
				End Get
			End Property


			Public ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property AllowRemove() As Boolean Implements IBindingList.AllowRemove
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
				Get
					Return True
				End Get
			End Property


			Public ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
				Get
					Return m_SortDirection
				End Get
			End Property


			Public Custom Event ListChanged As ListChangedEventHandler Implements IBindingList.ListChanged
				AddHandler(ByVal value As ListChangedEventHandler)
					m_OnListChanged = DirectCast(System.Delegate.Combine(m_OnListChanged, value), ListChangedEventHandler)
				End AddHandler
				RemoveHandler(ByVal value As ListChangedEventHandler)
					m_OnListChanged = DirectCast(System.Delegate.Remove(m_OnListChanged, value), ListChangedEventHandler)
				End RemoveHandler
				RaiseEvent(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs)
					If m_OnListChanged IsNot Nothing Then
						For Each d As ListChangedEventHandler In m_OnListChanged.GetInvocationList()
							d.Invoke(sender, e)
						Next d
					End If
				End RaiseEvent
			End Event


			Public ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
				Get

					Return True
				End Get
			End Property


			Public ReadOnly Property AllowEdit() As Boolean Implements IBindingList.AllowEdit
				Get
					Return True
				End Get
			End Property


			#End Region

			#End Region

			#Region "IList Members"

			#Region "Methods"

			Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
				m_List.RemoveAt(index)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
			End Sub


			Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
				m_List.Insert(index, value)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, index))
			End Sub


			Public Sub Remove(ByVal value As Object) Implements System.Collections.IList.Remove
				m_List.Remove(value)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, m_List.IndexOf(value)))
			End Sub


			Public Function Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
				Return m_List.Contains(value)
			End Function


			Public Sub Clear() Implements System.Collections.IList.Clear
				m_List.Clear()
				OnListChanged(m_ResetEventArgs)
			End Sub


			Public Function IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf
				Return m_List.IndexOf(value)
			End Function


			Public Function Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
				m_List.Add(value)
				Dim last As Integer = m_List.IndexOf(value)
				OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, last))
				Return last
			End Function


			#End Region

			#Region "Properties"

			Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
				Get
					Return m_List.IsReadOnly
				End Get
			End Property


			Default Public Property Item(ByVal index As Integer) As Object Implements System.Collections.IList.Item
				Get
					Return m_List(index)
				End Get
				Set(ByVal value As Object)
					m_List(index) = value
					OnListChanged(New ListChangedEventArgs(ListChangedType.ItemChanged, index))
				End Set
			End Property


			Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
				Get
					Return True
				End Get
			End Property


			#End Region

			#End Region

			#Region "ICollection Members"

			Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
				m_List.CopyTo(array, index)
			End Sub


			Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
				Get
					Return m_List.IsSynchronized
				End Get
			End Property


			Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
				Get
					Return m_List.Count
				End Get
			End Property


			Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
				Get
					Return m_List.SyncRoot
				End Get
			End Property


			#End Region

			#Region "IEnumerable Members"

			Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
				Return m_List.GetEnumerator()
			End Function


			#End Region

			#Region "ITypedList Members"

			Public Function GetItemProperties(ByVal listAccessors() As PropertyDescriptor) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
				Return TypeDescriptor.GetProperties(GetType(MyCustomObject))
			End Function


			Public Function GetListName(ByVal listAccessors() As PropertyDescriptor) As String Implements ITypedList.GetListName
				Return "MyCustomObject"
			End Function


			#End Region

			Protected Overridable Sub OnListChanged(ByVal ev As ListChangedEventArgs)
				If m_OnListChanged IsNot Nothing Then
					m_OnListChanged(Me, ev)
				End If
			End Sub


			#Region "Fields"

			Private m_List As ArrayList
			Private m_SortDirection As ListSortDirection
			Private m_ResetEventArgs As ListChangedEventArgs
			Private m_OnListChanged As ListChangedEventHandler

			#End Region
		End Class

	End Class
End Namespace
