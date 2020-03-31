Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Editors
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NImageExportUC.
	''' </summary>
	Public Class NImageExportUC
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
			Me.showImageExportDialogButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.documentPropsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.docWidthTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.docHeightTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.measurementUnitButton = New Nevron.Editors.NMeasurementUnitButton()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.documentPropsGroup.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' showImageExportDialogButton
			' 
			Me.showImageExportDialogButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.showImageExportDialogButton.Location = New System.Drawing.Point(8, 24)
			Me.showImageExportDialogButton.Name = "showImageExportDialogButton"
			Me.showImageExportDialogButton.Size = New System.Drawing.Size(234, 23)
			Me.showImageExportDialogButton.TabIndex = 0
			Me.showImageExportDialogButton.Text = "Show Image Export Dialog..."
'			Me.showImageExportDialogButton.Click += New System.EventHandler(Me.showImageExportDialogButton_Click);
			' 
			' documentPropsGroup
			' 
			Me.documentPropsGroup.Controls.Add(Me.label1)
			Me.documentPropsGroup.Controls.Add(Me.docWidthTextBox)
			Me.documentPropsGroup.Controls.Add(Me.docHeightTextBox)
			Me.documentPropsGroup.Controls.Add(Me.label2)
			Me.documentPropsGroup.Controls.Add(Me.label8)
			Me.documentPropsGroup.Controls.Add(Me.measurementUnitButton)
			Me.documentPropsGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.documentPropsGroup.ImageIndex = 0
			Me.documentPropsGroup.Location = New System.Drawing.Point(0, 0)
			Me.documentPropsGroup.Name = "documentPropsGroup"
			Me.documentPropsGroup.Size = New System.Drawing.Size(250, 144)
			Me.documentPropsGroup.TabIndex = 0
			Me.documentPropsGroup.TabStop = False
			Me.documentPropsGroup.Text = "Document Properties"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 88)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(48, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Width:"
			' 
			' docWidthTextBox
			' 
			Me.docWidthTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.docWidthTextBox.ErrorMessage = Nothing
			Me.docWidthTextBox.Location = New System.Drawing.Point(56, 88)
			Me.docWidthTextBox.Name = "docWidthTextBox"
			Me.docWidthTextBox.ReadOnly = True
			Me.docWidthTextBox.Size = New System.Drawing.Size(186, 20)
			Me.docWidthTextBox.TabIndex = 3
			Me.docWidthTextBox.Text = ""
			' 
			' docHeightTextBox
			' 
			Me.docHeightTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.docHeightTextBox.ErrorMessage = Nothing
			Me.docHeightTextBox.Location = New System.Drawing.Point(56, 112)
			Me.docHeightTextBox.Name = "docHeightTextBox"
			Me.docHeightTextBox.ReadOnly = True
			Me.docHeightTextBox.Size = New System.Drawing.Size(186, 20)
			Me.docHeightTextBox.TabIndex = 5
			Me.docHeightTextBox.Text = ""
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 112)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(48, 23)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Height:"
			' 
			' label8
			' 
			Me.label8.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label8.Location = New System.Drawing.Point(8, 24)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(234, 16)
			Me.label8.TabIndex = 0
			Me.label8.Text = "Document measurement unit:"
			' 
			' measurementUnitButton
			' 
			Me.measurementUnitButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.measurementUnitButton.ArrowClickOptions = False
			Me.measurementUnitButton.DialogResult = System.Windows.Forms.DialogResult.No
			Me.measurementUnitButton.Location = New System.Drawing.Point(8, 48)
			Me.measurementUnitButton.Name = "measurementUnitButton"
			Me.measurementUnitButton.Size = New System.Drawing.Size(234, 23)
			Me.measurementUnitButton.TabIndex = 1
			Me.measurementUnitButton.Text = "Measurement Unit"
'			Me.measurementUnitButton.MeasurementUnitChanged += New System.EventHandler(Me.measurementUnitButton_MeasurementUnitChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.showImageExportDialogButton)
			Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox1.Location = New System.Drawing.Point(0, 144)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(250, 64)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Image Export Actions"
			' 
			' NImageExporterUC
			' 
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.documentPropsGroup)
			Me.Name = "NImageExportUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.documentPropsGroup, 0)
			Me.Controls.SetChildIndex(Me.groupBox1, 0)
			Me.documentPropsGroup.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
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

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler document.EventSinkService.NodePropertyChanged, AddressOf EventSinkService_NodePropertyChanged
			AddHandler document.EventSinkService.NodeBoundsChanged, AddressOf EventSinkService_NodeBoundsChanged

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler document.EventSinkService.NodePropertyChanged, AddressOf EventSinkService_NodePropertyChanged
			RemoveHandler document.EventSinkService.NodeBoundsChanged, AddressOf EventSinkService_NodeBoundsChanged

			MyBase.DetachFromEvents()
		End Sub

		Protected Overrides Sub CreateDefaultFlowDiagram()
			MyBase.CreateDefaultFlowDiagram()

			' create a rectangle shape
			Dim rect As NRectangleShape = New NRectangleShape(New NRectangleF(10, 10, 100, 60))
			rect.Text = "Non-image exportable shape"
			rect.Style.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(&Hff, &H55, &H55), Color.FromArgb(&H66, &H00, &H00))

			' protect from export
			Dim protection As NAbilities = rect.Protection
			protection.Export = True
			rect.Protection = protection

			' add it to the active layer
			document.ActiveLayer.AddChild(rect)
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			Try
				measurementUnitButton.SetSystemManagerAndUnit(NMeasurementSystemManager.DefaultMeasurementSystemManager, document.MeasurementUnit)
				UpdateDocumentProperties()
			Finally
				ResumeEventsHandling()
			End Try
		End Sub

		Private Sub UpdateDocumentProperties()
			docWidthTextBox.Text = document.Width.ToString() & " " & document.MeasurementUnit.Abbreviation
			docHeightTextBox.Text = document.Height.ToString() & " " & document.MeasurementUnit.Abbreviation
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub showImageExportDialogButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showImageExportDialogButton.Click
			Dim imageExporter As NImageExporter = New NImageExporter(document)

			' register selection bounds
			Dim nodes As NNodeList = view.Selection.Nodes
			If nodes.Count <> 0 Then
				imageExporter.KnownBoundsTable.Add("Selected nodes", NFunctions.ComputeNodesBounds(nodes, Nothing))
			End If

			imageExporter.ShowDialog()
		End Sub

		Private Sub measurementUnitButton_MeasurementUnitChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles measurementUnitButton.MeasurementUnitChanged
			If EventsHandlingPaused Then
				Return
			End If

			PauseEventsHandling()
			Try
				document.MeasurementUnit = measurementUnitButton.MeasurementUnit
				document.RefreshAllViews()
			Finally
				ResumeEventsHandling()
				UpdateDocumentProperties()
			End Try
		End Sub


		Private Sub EventSinkService_NodePropertyChanged(ByVal args As NNodePropertyEventArgs)
			If EventsHandlingPaused Then
				Return
			End If

			If Not(TypeOf args.Node Is NDocument) Then
				Return
			End If

			UpdateDocumentProperties()
		End Sub

		Private Sub EventSinkService_NodeBoundsChanged(ByVal args As NNodeEventArgs)
			If Not(TypeOf args.Node Is NDocument) Then
				Return
			End If

			UpdateDocumentProperties()
		End Sub


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private documentPropsGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private docWidthTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private docHeightTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label2 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private WithEvents measurementUnitButton As Nevron.Editors.NMeasurementUnitButton
		Private groupBox1 As System.Windows.Forms.GroupBox

		Private WithEvents showImageExportDialogButton As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace