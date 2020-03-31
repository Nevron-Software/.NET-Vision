Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	Public Class NClassDesignerUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' Init view and document
			view.BeginInit()
			view.VerticalRuler.Visible = False
			view.HorizontalRuler.Visible = False
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowShadows = False
			view.ViewLayout = ViewLayout.Fit

			document.AutoBoundsMode = AutoBoundsMode.AutoSizeToContent

			' Create and add the UML style sheets to the drawing document
			NUmlShape.AddUmlStyleSheets(document)

			view.EndInit()

			' Init controls
			Dim panel As Panel = New Panel()
			panel.SetBounds(0, 0, Me.Width, Me.commonControlsPanel.Top)
			panel.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top Or AnchorStyles.Bottom
			Me.Controls.Add(panel)

			Dim libView As NLibraryView = CreateLibrary()
			libView.Dock = DockStyle.Fill
			panel.Controls.Add(libView)

			Dim buttonPanel As Panel = New Panel()
			buttonPanel.Height = 45
			buttonPanel.Padding = New Padding(10)
			buttonPanel.Dock = DockStyle.Bottom
			panel.Controls.Add(buttonPanel)

			Dim importButton As NButton = New NButton()
			importButton.Text = "Import Class Hierarchy"
			importButton.Dock = DockStyle.Fill
			buttonPanel.Controls.Add(importButton)
			AddHandler importButton.Click, AddressOf OnImportButtonClick
		End Sub

		#End Region

		#Region "Implementation - Library"

		Private Function CreateLibrary() As NLibraryView
			Dim libDocument As NLibraryDocument = New NLibraryDocument()
			libDocument.BackgroundStyle = New NBackgroundStyle()
			libDocument.BackgroundStyle.FillStyle = New NGradientFillStyle(Nevron.GraphicsCore.GradientStyle.Vertical, GradientVariant.Variant1, Color.RoyalBlue, Color.LightSkyBlue)

			Dim libView As NLibraryView = New NLibraryView()
			libView.AllowDrop = False
			libView.Document = libDocument
			libView.ScrollBars = ScrollBars.None
			libView.Selection.Mode = DiagramSelectionMode.Single
			libView.Document = libDocument

			Dim shape As NUmlShape = New NUmlShape(0, 0, 100, 25, True)
			Dim master As NMaster = New NMaster(shape, NGraphicsUnit.Pixel, "Class", "Drag me on the drawing")
			libDocument.AddChild(master)
			shape.Name = "Class"

			shape = New NUmlShape(0, 0, 100, 25, True)
			shape.Abstract = True
			master = New NMaster(shape, NGraphicsUnit.Pixel, "Abstract Class", "Drag me on the drawing")
			libDocument.AddChild(master)
			shape.Name = "AbstractClass"

			' Connectors
			master = CreateGeneralizationMaster()
			libDocument.AddChild(master)

			master = CreateAssociationMaster()
			libDocument.AddChild(master)

			master = CreateAggregarionMaster()
			libDocument.AddChild(master)

			master = CreateCompositionMaster()
			libDocument.AddChild(master)

			Return libView
		End Function

		Private Function CreateGeneralizationMaster() As NMaster
			Dim c As NStep3Connector = New NStep3Connector(New NPointF(0, 0), New NPointF(100, 50), True)
			c.Name = "UML Generalization"

			Dim strokeStyle As NStrokeStyle = CType(document.ComposeStrokeStyle().Clone(), NStrokeStyle)
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Arrow, String.Empty, ArrowSize, ConFillStyle, strokeStyle)
			NStyle.SetStartArrowheadStyle(c, arrowheadStyle)

			Return New NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing")
		End Function
		Private Function CreateAssociationMaster() As NMaster
			Dim c As NStep3Connector = New NStep3Connector(New NPointF(0, 0), New NPointF(100, 50), True)
			c.Name = "UML Association"

			Dim strokeStyle As NStrokeStyle = CType(document.ComposeStrokeStyle().Clone(), NStrokeStyle)
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.OpenedArrow, String.Empty, ArrowSize, ConFillStyle, CType(strokeStyle.Clone(), NStrokeStyle))
			NStyle.SetEndArrowheadStyle(c, arrowheadStyle)

			strokeStyle.Pattern = LinePattern.Dash
			NStyle.SetStrokeStyle(c, strokeStyle)

			Return New NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing")
		End Function
		Private Function CreateAggregarionMaster() As NMaster
			Dim c As NStep3Connector = New NStep3Connector(New NPointF(0, 0), New NPointF(100, 50), True)
			c.Name = "UML Aggregation"

			Dim strokeStyle As NStrokeStyle = CType(document.ComposeStrokeStyle().Clone(), NStrokeStyle)
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Losangle, String.Empty, LosangleSize, ConFillStyle, CType(strokeStyle.Clone(), NStrokeStyle))
			NStyle.SetStartArrowheadStyle(c, arrowheadStyle)

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.OpenedArrow, String.Empty, ArrowSize, ConFillStyle, CType(strokeStyle.Clone(), NStrokeStyle))
			NStyle.SetEndArrowheadStyle(c, arrowheadStyle)

			Return New NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing")
		End Function
		Private Function CreateCompositionMaster() As NMaster
			Dim c As NStep3Connector = New NStep3Connector(New NPointF(0, 0), New NPointF(100, 50), True)
			c.Name = "UML Composition"

			Dim strokeStyle As NStrokeStyle = CType(document.ComposeStrokeStyle().Clone(), NStrokeStyle)
			Dim arrowheadStyle As NArrowheadStyle = New NArrowheadStyle(ArrowheadShape.Losangle, String.Empty, LosangleSize, New NColorFillStyle(Color.Silver), CType(strokeStyle.Clone(), NStrokeStyle))
			NStyle.SetStartArrowheadStyle(c, arrowheadStyle)

			arrowheadStyle = New NArrowheadStyle(ArrowheadShape.OpenedArrow, String.Empty, ArrowSize, ConFillStyle, CType(strokeStyle.Clone(), NStrokeStyle))
			NStyle.SetEndArrowheadStyle(c, arrowheadStyle)

			Return New NMaster(c, NGraphicsUnit.Pixel, c.Name, "Drag me on the drawing")
		End Function

		#End Region

		#Region "Event Handlers"

		Private Sub OnImportButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			If m_ClassSelectorForm Is Nothing Then
				m_ClassSelectorForm = New NClassSelectorForm()
			End If

			If m_ClassSelectorForm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Dim selectedType As Type = m_ClassSelectorForm.SelectedType
				If selectedType Is Nothing Then
					Return
				End If

				' Remove all shapes from the active layer
				document.ActiveLayer.RemoveAllChildren()

				' Import the selected class hierarchy
				Dim classImporter As NClassImporter = New NClassImporter(document)
				classImporter.ImportInActiveLayer = True
				classImporter.ImportMembers = m_ClassSelectorForm.ImportClassMembers
				CType(classImporter.Layout, NLayeredTreeLayout).Direction = m_ClassSelectorForm.Direction
				classImporter.Import(selectedType)
			End If
		End Sub

		#End Region

		#Region "Fields"

		Private m_ClassSelectorForm As NClassSelectorForm

		#End Region

		#Region "Constants"

		Private Shared ReadOnly ConFillStyle As NFillStyle = New NColorFillStyle(KnownArgbColorValue.White)
		Private Shared ReadOnly ArrowSize As NSizeL = New NSizeL(4, 4)
		Private Shared ReadOnly LosangleSize As NSizeL = New NSizeL(8, 6)

		#End Region

		#Region "Nested Types"

		Private Class NClassSelectorForm
			Inherits NForm
			#Region "Constructors"

			Public Sub New()
				Initialize()
			End Sub

			#End Region

			#Region "Properties"

			Public ReadOnly Property SelectedType() As Type
				Get
					Return TryCast(m_TypesCombo.SelectedItem, Type)
				End Get
			End Property
			Public ReadOnly Property ImportClassMembers() As Boolean
				Get
					Return m_ImportMembersCheckBox.Checked
				End Get
			End Property
			Public ReadOnly Property Direction() As LayoutDirection
				Get
					Return CType(m_DirectionComboBox.SelectedItem, LayoutDirection)
				End Get
			End Property

			#End Region

			#Region "Implementation"

			Private Sub Initialize()
				Me.Text = "Import Class Hierarchy"
				Me.Width = 400
				Me.Height = 400
				Me.StartPosition = FormStartPosition.CenterScreen

				Me.SuspendLayout()
				m_TypesCombo = New ComboBox()
				m_TypesCombo.DropDownStyle = ComboBoxStyle.Simple
				m_TypesCombo.Sorted = True
				m_TypesCombo.Dock = DockStyle.Fill
				Me.Controls.Add(m_TypesCombo)

				Dim topPanel As Panel = New Panel()
				topPanel.Padding = New Padding(0, 5, 0, 5)
				topPanel.Height = 40
				topPanel.Dock = DockStyle.Top
				Me.Controls.Add(topPanel)

				m_AssemblyLabel = New Label()
				m_AssemblyLabel.TextAlign = ContentAlignment.MiddleLeft
				m_AssemblyLabel.Text = "Click <Browse> to select an assembly"
				m_AssemblyLabel.Dock = DockStyle.Fill
				topPanel.Controls.Add(m_AssemblyLabel)

				Dim browseButton As NButton = New NButton()
				browseButton.Text = "Browse"
				browseButton.Dock = DockStyle.Right
				AddHandler browseButton.Click, AddressOf OnBrowseButtonClick
				topPanel.Controls.Add(browseButton)

				m_ImportMembersCheckBox = New CheckBox()
				m_ImportMembersCheckBox.Checked = True
				m_ImportMembersCheckBox.Text = "Import class members"
				m_ImportMembersCheckBox.Dock = DockStyle.Bottom
				Me.Controls.Add(m_ImportMembersCheckBox)

				Dim directionPanel As FlowLayoutPanel = New FlowLayoutPanel()
				directionPanel.Height = 30
				directionPanel.Dock = DockStyle.Bottom
				Me.Controls.Add(directionPanel)

				Dim directionLabel As Label = New Label()
				directionLabel.TextAlign = ContentAlignment.MiddleLeft
				directionLabel.Text = "Layout Direction:"
				directionPanel.Controls.Add(directionLabel)

				m_DirectionComboBox = New ComboBox()
				m_DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList
				m_DirectionComboBox.DataSource = System.Enum.GetValues(GetType(LayoutDirection))
				m_DirectionComboBox.SelectedItem = LayoutDirection.TopToBottom
				directionPanel.Controls.Add(m_DirectionComboBox)

				Dim importButton As NButton = New NButton()
				importButton.Text = "Import"
				importButton.Dock = DockStyle.Bottom
				AddHandler importButton.Click, AddressOf OnImportButtonClick
				Me.Controls.Add(importButton)
				Me.ResumeLayout(False)

				m_OpenAssemblyDialog = New OpenFileDialog()
				m_OpenAssemblyDialog.Title = "Open assembly"
				m_OpenAssemblyDialog.Filter = "Assemblies (*.dll)|*.dll"
			End Sub
			Private Sub FillClasses(ByVal [assembly] As System.Reflection.Assembly)
				m_TypesCombo.DataSource = Nothing

				Dim types As Type() = [assembly].GetTypes()
				Dim classes As List(Of Type) = New List(Of Type)()
				Dim i As Integer, count As Integer = types.Length
				i = 0
				Do While i < count
					If types(i).IsClass AndAlso types(i).IsPublic Then
						classes.Add(types(i))
					End If
					i += 1
				Loop

				m_TypesCombo.DataSource = classes
				m_TypesCombo.DisplayMember = "Name"
			End Sub

			#End Region

			#Region "Event Handlers"

			Private Sub OnBrowseButtonClick(ByVal sender As Object, ByVal e As EventArgs)
				If m_OpenAssemblyDialog.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
					Return
				End If

				Dim [assembly] As System.Reflection.Assembly = Nothing
				Dim fileName As String = m_OpenAssemblyDialog.FileName
				Try
					[assembly] = System.Reflection.Assembly.LoadFrom(fileName)
					m_AssemblyLabel.Text = fileName
					FillClasses([assembly])
				Catch
					MessageBox.Show("'" & fileName & "' is not a valid .NET assembly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				End Try
			End Sub
			Private Sub OnImportButtonClick(ByVal sender As Object, ByVal e As EventArgs)
				Me.DialogResult = System.Windows.Forms.DialogResult.OK
			End Sub

			#End Region

			#Region "Fields"

			Private m_TypesCombo As ComboBox
			Private m_AssemblyLabel As Label
			Private m_ImportMembersCheckBox As CheckBox
			Private m_DirectionComboBox As ComboBox
			Private m_OpenAssemblyDialog As OpenFileDialog

			#End Region
		End Class

		#End Region
	End Class
End Namespace