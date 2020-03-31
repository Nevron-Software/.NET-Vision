Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NDragDropUC.
	''' </summary>
	Public Class NDragDropUC
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
			Me.sourceMoveModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.targetMoveModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.sourceViewPanel = New System.Windows.Forms.Panel()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' sourceMoveModeCombo
			' 
			Me.sourceMoveModeCombo.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.sourceMoveModeCombo.Location = New System.Drawing.Point(80, 96)
			Me.sourceMoveModeCombo.Name = "sourceMoveModeCombo"
			Me.sourceMoveModeCombo.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue
			Me.sourceMoveModeCombo.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.sourceMoveModeCombo.Size = New System.Drawing.Size(160, 21)
			Me.sourceMoveModeCombo.TabIndex = 3
'			Me.sourceMoveModeCombo.SelectedIndexChanged += New System.EventHandler(Me.sourceMoveModeCombo_SelectedIndexChanged);
			' 
			' targetMoveModeCombo
			' 
			Me.targetMoveModeCombo.Location = New System.Drawing.Point(8, 32)
			Me.targetMoveModeCombo.Name = "targetMoveModeCombo"
			Me.targetMoveModeCombo.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaOlive
			Me.targetMoveModeCombo.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.targetMoveModeCombo.Size = New System.Drawing.Size(152, 21)
			Me.targetMoveModeCombo.TabIndex = 2
'			Me.targetMoveModeCombo.SelectedIndexChanged += New System.EventHandler(Me.targetMoveModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.ForeColor = System.Drawing.SystemColors.ControlText
			Me.label2.Location = New System.Drawing.Point(8, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(152, 16)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Green view move mode:"
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label1.ForeColor = System.Drawing.SystemColors.ControlText
			Me.label1.Location = New System.Drawing.Point(80, 72)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(160, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Blue view move mode:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.TopRight
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.targetMoveModeCombo)
			Me.panel1.Controls.Add(Me.label2)
			Me.panel1.Controls.Add(Me.label1)
			Me.panel1.Controls.Add(Me.sourceMoveModeCombo)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(248, 128)
			Me.panel1.TabIndex = 4
			' 
			' sourceViewPanel
			' 
			Me.sourceViewPanel.Dock = System.Windows.Forms.DockStyle.Fill
			Me.sourceViewPanel.Location = New System.Drawing.Point(0, 128)
			Me.sourceViewPanel.Name = "sourceViewPanel"
			Me.sourceViewPanel.Size = New System.Drawing.Size(248, 280)
			Me.sourceViewPanel.TabIndex = 5
			' 
			' NDragDropUC
			' 
			Me.Controls.Add(Me.sourceViewPanel)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NDragDropUC"
			Me.Size = New System.Drawing.Size(248, 408)
			Me.Controls.SetChildIndex(Me.panel1, 0)
			Me.Controls.SetChildIndex(Me.sourceViewPanel, 0)
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			commonControlsPanel.SendToBack()

			' create the source view (blue view)
			CreateSourceView()

			' begin view init
			view.BeginInit()

			view.AllowDrop = True
			view.GlobalVisibility.ShowPorts = False

			' init document
			document.BeginInit()
			document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.FromArgb(90, Color.YellowGreen))
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			sourceMoveModeCombo.ListProperties.ColumnOnLeft = False
			targetMoveModeCombo.ListProperties.ColumnOnLeft = False

			sourceMoveModeCombo.FillFromEnum(GetType(MoveToolMode))
			targetMoveModeCombo.FillFromEnum(GetType(MoveToolMode))

			sourceMoveModeCombo.SelectedIndex = 1
			targetMoveModeCombo.SelectedIndex = 0

			ResumeEventsHandling()
		End Sub

		Private Sub CreateSourceView()
			If sourceView Is Nothing Then
				' begin view init
				sourceView = New NDrawingView()
				sourceView.BeginInit()

				sourceView.Dock = DockStyle.Fill
				sourceView.Parent = sourceViewPanel

				' begin document init
				sourceDocument = New NDrawingDocument()
				sourceDocument.BeginInit()
				sourceDocument.BackgroundStyle.FillStyle = New NColorFillStyle(Color.FromArgb(70, Color.RoyalBlue))

				' attach document to view
				sourceView.Document = sourceDocument
			Else
				' begin view init
				sourceView.BeginInit()

				' begin document init
				sourceDocument.BeginInit()
				sourceDocument.ActiveLayer.RemoveAllChildren()
			End If

			sourceView.AllowDrop = True
			sourceView.HorizontalRuler.Visible = False
			sourceView.VerticalRuler.Visible = False
			sourceView.GlobalVisibility.ShowPorts = False

			Dim toolNames As String() = New String(){ NDWFR.ToolCreateGuideline, NDWFR.ToolHandle, NDWFR.ToolMove, NDWFR.ToolSelector, NDWFR.ToolContextMenu, NDWFR.ToolKeyboard, NDWFR.ToolInplaceEdit}

			sourceView.Controller.Tools.SingleEnableTools(toolNames)

			CreateSourceScene()

			' end document init
			sourceDocument.EndInit()

			' end view init
			sourceView.EndInit()
		End Sub

		Private Sub CreateSourceScene()
			sourceDocument.AutoBoundsMode = AutoBoundsMode.CustomNonConstrained

			Dim cell As NRectangleF
			Dim row As Integer = 0, col As Integer = 0
			Dim width As Integer = (sourceView.Width - 40) / 3

			Dim shape As NShape = Nothing
			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			factory.DefaultSize = New NSizeF(50, 50)

			For Each basicShape As BasicShapes In System.Enum.GetValues(GetType(BasicShapes))
				shape = factory.CreateShape(CInt(Fix(basicShape)))
				shape.Bounds = GetGridCell(row, col, New NPointF(0, 0), New NSizeF(50, 50), New NSizeF(10, 10))

				sourceDocument.ActiveLayer.AddChild(shape)
				col += 1

				If col > 2 Then
					row += 1
					col = 0
				End If
			Next basicShape

			' Add some content to the table shape
			Dim table As NTableShape = CType(shape, NTableShape)
			table.InitTable(2, 2)
			table.BeginUpdate()
			table.CellMargins = New Nevron.Diagram.NMargins(8)
			table(0, 0).Text = "1"
			table(1, 0).Text = "2"
			table(0, 1).Text = "3"
			table(1, 1).Text = "4"
			table.PortDistributionMode = TablePortDistributionMode.CellBased
			table.EndUpdate()

			sourceDocument.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent
			sourceDocument.RefreshAllViews()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub sourceMoveModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sourceMoveModeCombo.SelectedIndexChanged
			Dim moveTool As NMoveTool = TryCast(sourceView.Controller.Tools.GetToolByName(NDWFR.ToolMove), NMoveTool)
			If moveTool Is Nothing Then
				Return
			End If

			moveTool.Mode = CType(sourceMoveModeCombo.SelectedItem, MoveToolMode)
		End Sub

		Private Sub targetMoveModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles targetMoveModeCombo.SelectedIndexChanged
			Dim moveTool As NMoveTool = TryCast(view.Controller.Tools.GetToolByName(NDWFR.ToolMove), NMoveTool)
			If moveTool Is Nothing Then
				Return
			End If

			moveTool.Mode = CType(targetMoveModeCombo.SelectedItem, MoveToolMode)
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private label1 As System.Windows.Forms.Label
		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents sourceMoveModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents targetMoveModeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private sourceViewPanel As System.Windows.Forms.Panel
		Private label2 As System.Windows.Forms.Label

		#End Region

		#Region "Fields"

		Private sourceView As NDrawingView
		Private sourceDocument As NDrawingDocument

		#End Region
	End Class
End Namespace