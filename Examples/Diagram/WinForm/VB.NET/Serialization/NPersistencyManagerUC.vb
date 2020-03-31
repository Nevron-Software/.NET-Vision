Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Xml.Serialization

Imports Nevron.Serialization
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NPersistencyManagerUC.
	''' </summary>
	Public Class NPersistencyManagerUC
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
			Me.loadFromFileButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.saveToFileButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.loadFromStreamButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.saveToStreamButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.persistencyFormatCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.filePersistanceGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.memoryPersistanceGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.filePersistanceGroupBox.SuspendLayout()
			Me.memoryPersistanceGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' loadFromFileButton
			' 
			Me.loadFromFileButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.loadFromFileButton.Location = New System.Drawing.Point(8, 48)
			Me.loadFromFileButton.Name = "loadFromFileButton"
			Me.loadFromFileButton.Size = New System.Drawing.Size(234, 24)
			Me.loadFromFileButton.TabIndex = 1
			Me.loadFromFileButton.Text = "Load from file..."
			'			Me.loadFromFileButton.Click += New System.EventHandler(Me.loadFromFileButton_Click);
			' 
			' saveToFileButton
			' 
			Me.saveToFileButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.saveToFileButton.Location = New System.Drawing.Point(8, 16)
			Me.saveToFileButton.Name = "saveToFileButton"
			Me.saveToFileButton.Size = New System.Drawing.Size(234, 24)
			Me.saveToFileButton.TabIndex = 0
			Me.saveToFileButton.Text = "Save to file..."
			'			Me.saveToFileButton.Click += New System.EventHandler(Me.saveToFileButton_Click);
			' 
			' loadFromStreamButton
			' 
			Me.loadFromStreamButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.loadFromStreamButton.Location = New System.Drawing.Point(8, 104)
			Me.loadFromStreamButton.Name = "loadFromStreamButton"
			Me.loadFromStreamButton.Size = New System.Drawing.Size(234, 24)
			Me.loadFromStreamButton.TabIndex = 3
			Me.loadFromStreamButton.Text = "Load from stream"
			'			Me.loadFromStreamButton.Click += New System.EventHandler(Me.loadFromStreamButton_Click);
			' 
			' saveToStreamButton
			' 
			Me.saveToStreamButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.saveToStreamButton.Location = New System.Drawing.Point(8, 72)
			Me.saveToStreamButton.Name = "saveToStreamButton"
			Me.saveToStreamButton.Size = New System.Drawing.Size(234, 24)
			Me.saveToStreamButton.TabIndex = 2
			Me.saveToStreamButton.Text = "Save to stream"
			'			Me.saveToStreamButton.Click += New System.EventHandler(Me.saveToStreamButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(112, 24)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Persistency format:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' persistencyFormatCombo
			' 
			Me.persistencyFormatCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.persistencyFormatCombo.Location = New System.Drawing.Point(8, 40)
			Me.persistencyFormatCombo.Name = "persistencyFormatCombo"
			Me.persistencyFormatCombo.Size = New System.Drawing.Size(234, 21)
			Me.persistencyFormatCombo.TabIndex = 1
			'			Me.persistencyFormatCombo.SelectedIndexChanged += New System.EventHandler(Me.persistencyFormatCombo_SelectedIndexChanged);
			' 
			' filePersistanceGroupBox
			' 
			Me.filePersistanceGroupBox.Controls.Add(Me.loadFromFileButton)
			Me.filePersistanceGroupBox.Controls.Add(Me.saveToFileButton)
			Me.filePersistanceGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.filePersistanceGroupBox.ImageIndex = 0
			Me.filePersistanceGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.filePersistanceGroupBox.Name = "filePersistanceGroupBox"
			Me.filePersistanceGroupBox.Size = New System.Drawing.Size(250, 80)
			Me.filePersistanceGroupBox.TabIndex = 0
			Me.filePersistanceGroupBox.TabStop = False
			Me.filePersistanceGroupBox.Text = "File persistency"
			' 
			' memoryPersistanceGroupBox
			' 
			Me.memoryPersistanceGroupBox.Controls.Add(Me.label1)
			Me.memoryPersistanceGroupBox.Controls.Add(Me.persistencyFormatCombo)
			Me.memoryPersistanceGroupBox.Controls.Add(Me.saveToStreamButton)
			Me.memoryPersistanceGroupBox.Controls.Add(Me.loadFromStreamButton)
			Me.memoryPersistanceGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.memoryPersistanceGroupBox.ImageIndex = 0
			Me.memoryPersistanceGroupBox.Location = New System.Drawing.Point(0, 80)
			Me.memoryPersistanceGroupBox.Name = "memoryPersistanceGroupBox"
			Me.memoryPersistanceGroupBox.Size = New System.Drawing.Size(250, 144)
			Me.memoryPersistanceGroupBox.TabIndex = 1
			Me.memoryPersistanceGroupBox.TabStop = False
			Me.memoryPersistanceGroupBox.Text = "Memory persistency"
			' 
			' NPersistencyManagerUC
			' 
			Me.Controls.Add(Me.memoryPersistanceGroupBox)
			Me.Controls.Add(Me.filePersistanceGroupBox)
			Me.Name = "NPersistencyManagerUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.filePersistanceGroupBox, 0)
			Me.Controls.SetChildIndex(Me.memoryPersistanceGroupBox, 0)
			Me.filePersistanceGroupBox.ResumeLayout(False)
			Me.memoryPersistanceGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
#End Region

#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			persistencyManager = New NPersistencyManager()

			' IMPORTANT: custom types added to the DOM must be registered 
			' in the persistency manager if you intend to save/load in XML format
			persistencyManager.Serializer.XmlExtraTypes = New Type() {GetType(NCustomShape)}

			' begin view init
			view.BeginInit()

			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()
			CreateDefaultFlowDiagram()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end desigenr init
			view.EndInit()

			UpdateControlsState()
		End Sub

		Protected Overrides Sub ResetExample()
			MemoryStream = Nothing
			MemoryStreamFormat = PersistencyFormat.Binary
			persistencyFormatCombo.SelectedItem = PersistencyFormat.Binary

			MyBase.ResetExample()
		End Sub

		Protected Overrides Sub CreateDefaultFlowDiagram()
			MyBase.CreateDefaultFlowDiagram()

			Dim cs As NCustomShape = New NCustomShape()
			cs.Bounds = New NRectangleF(10, 10, 100, 60)
			document.ActiveLayer.AddChild(cs)
		End Sub

#End Region

#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			persistencyFormatCombo.FillFromEnum(GetType(PersistencyFormat))
			persistencyFormatCombo.SelectedItem = PersistencyFormat.Binary

			ResumeEventsHandling()
		End Sub

		Private Sub UpdateControlsState()
			Dim format As PersistencyFormat = CType(persistencyFormatCombo.SelectedIndex, PersistencyFormat)
			loadFromStreamButton.Enabled = MemoryStreamFormat = format AndAlso Not MemoryStream Is Nothing AndAlso MemoryStream.Length > 0

		End Sub
#End Region

#Region "Event Handlers"

		Private Sub saveToStreamButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveToStreamButton.Click
			MemoryStream = New MemoryStream()
			MemoryStreamFormat = CType(persistencyFormatCombo.SelectedIndex, PersistencyFormat)

			Dim saveCursor As Cursor = Cursor.Current
			Cursor.Current = Cursors.WaitCursor

			Try
				persistencyManager.PersistentDocument.Sections.Clear()
				persistencyManager.PersistentDocument.Sections.Add(New NPersistentSection("DOC", document))

				If persistencyManager.SaveToStream(MemoryStream, MemoryStreamFormat, Nothing) = False Then
					MemoryStream = Nothing
				End If
			Finally
				Cursor.Current = saveCursor
			End Try

			UpdateControlsState()
		End Sub

		Private Sub loadFromStreamButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loadFromStreamButton.Click
			MemoryStream.Seek(0, SeekOrigin.Begin)

			Dim saveCursor As Cursor = Cursor.Current
			Cursor.Current = Cursors.WaitCursor

			Try
				persistencyManager.LoadFromStream(MemoryStream, MemoryStreamFormat, Nothing)
				document = (TryCast(persistencyManager.PersistentDocument.Sections(0).Object, NDrawingDocument))

				Form.Document = document
				view.Document = document
			Finally
				Cursor.Current = saveCursor
				If document Is Nothing Then
					document = TryCast(view.Document, NDrawingDocument)
				End If
			End Try

			view.SmartRefresh()
		End Sub

		Private Sub saveToFileButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveToFileButton.Click
			persistencyManager.SaveDrawingToFile(document)
		End Sub

		Private Sub loadFromFileButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loadFromFileButton.Click
			document = persistencyManager.LoadDrawingFromFile()
			If Not document Is Nothing Then
				view.Document = document
				Form.Document = document
			Else
				document = TryCast(view.Document, NDrawingDocument)
			End If

			view.SmartRefresh()
		End Sub

		Private Sub persistencyFormatCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles persistencyFormatCombo.SelectedIndexChanged
			UpdateControlsState()
		End Sub

#End Region

#Region "Designer Fields"

		Private label1 As System.Windows.Forms.Label
		Private WithEvents loadFromFileButton As Nevron.UI.WinForm.Controls.NButton
		Private filePersistanceGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private memoryPersistanceGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents loadFromStreamButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents saveToStreamButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents saveToFileButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents persistencyFormatCombo As Nevron.UI.WinForm.Controls.NComboBox

		Private components As System.ComponentModel.Container = Nothing

#End Region

#Region "Fields"

		Private persistencyManager As NPersistencyManager
		Private MemoryStream As MemoryStream
		Private MemoryStreamFormat As PersistencyFormat

#End Region
	End Class

	<Serializable()> _
	Public Class NCustomShape
		Inherits NCompositeShape
		''' <summary>
		''' Default constructor
		''' </summary>
		Public Sub New()
			Primitives.AddChild(New NRectanglePath(New NRectangleF(0, 0, 1, 1)))
			UpdateModelBounds()

			Style.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(&HFF, &H55, &H55), Color.FromArgb(&H66, &H0, &H0))

			Text = "Custom serializable shape"

			m_boolProperty = False
		End Sub

		''' <summary>
		''' Serializable and history aware custom boolean property
		''' </summary>
		<XmlAttribute(), DefaultValue(False)> _
		Public Property BoolProperty() As Boolean
			Get
				Return m_boolProperty
			End Get
			Set(value As Boolean)
				If m_boolProperty = Value Then
					Return
				End If

				If OnPropertyChanging("m_boolProperty", Value) = False Then
					Return
				End If

				RecordProperty("BoolProperty")
				m_boolProperty = Value

				OnPropertyChanged("BoolProperty")
			End Set
		End Property

		''' <summary>
		''' bool property value
		''' </summary>
		Friend m_boolProperty As Boolean
	End Class
End Namespace