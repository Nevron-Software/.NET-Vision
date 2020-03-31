Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NTextShapeUC.
	''' </summary>
	Public Class NTextShapeUC
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
			Me.textEditBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.textStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.selectedTextGroupBox = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.textModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.allowDownwardCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.selectedTextGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' textEditBox
			' 
			Me.textEditBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.textEditBox.Location = New System.Drawing.Point(74, 56)
			Me.textEditBox.Multiline = True
			Me.textEditBox.Name = "textEditBox"
			Me.textEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.textEditBox.Size = New System.Drawing.Size(166, 112)
			Me.textEditBox.TabIndex = 3
'			Me.textEditBox.TextChanged += New System.EventHandler(Me.textEdit_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 56)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(49, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Text:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' textStyleButton
			' 
			Me.textStyleButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.textStyleButton.Location = New System.Drawing.Point(10, 204)
			Me.textStyleButton.Name = "textStyleButton"
			Me.textStyleButton.Size = New System.Drawing.Size(232, 23)
			Me.textStyleButton.TabIndex = 4
			Me.textStyleButton.Text = "Text Style..."
'			Me.textStyleButton.Click += New System.EventHandler(Me.textStyleButton_Click);
			' 
			' selectedTextGroupBox
			' 
			Me.selectedTextGroupBox.Controls.Add(Me.allowDownwardCheck)
			Me.selectedTextGroupBox.Controls.Add(Me.textModeCombo)
			Me.selectedTextGroupBox.Controls.Add(Me.label2)
			Me.selectedTextGroupBox.Controls.Add(Me.textStyleButton)
			Me.selectedTextGroupBox.Controls.Add(Me.textEditBox)
			Me.selectedTextGroupBox.Controls.Add(Me.label1)
			Me.selectedTextGroupBox.Dock = System.Windows.Forms.DockStyle.Top
			Me.selectedTextGroupBox.Enabled = False
			Me.selectedTextGroupBox.ImageIndex = 0
			Me.selectedTextGroupBox.Location = New System.Drawing.Point(0, 0)
			Me.selectedTextGroupBox.Name = "selectedTextGroupBox"
			Me.selectedTextGroupBox.Size = New System.Drawing.Size(250, 241)
			Me.selectedTextGroupBox.TabIndex = 0
			Me.selectedTextGroupBox.TabStop = False
			Me.selectedTextGroupBox.Text = "Selected Text Properties"
			' 
			' textModeCombo
			' 
			Me.textModeCombo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.textModeCombo.ListProperties.CheckBoxDataMember = ""
			Me.textModeCombo.ListProperties.DataSource = Nothing
			Me.textModeCombo.ListProperties.DisplayMember = ""
			Me.textModeCombo.Location = New System.Drawing.Point(74, 24)
			Me.textModeCombo.Name = "textModeCombo"
			Me.textModeCombo.Size = New System.Drawing.Size(166, 22)
			Me.textModeCombo.TabIndex = 1
			Me.textModeCombo.Text = "nComboBox1"
'			Me.textModeCombo.SelectedIndexChanged += New System.EventHandler(Me.textModeCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 24)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(49, 23)
			Me.label2.TabIndex = 0
			Me.label2.Text = "Mode:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' allowDownwardCheck
			' 
			Me.allowDownwardCheck.ButtonProperties.BorderOffset = 2
			Me.allowDownwardCheck.Location = New System.Drawing.Point(11, 174)
			Me.allowDownwardCheck.Name = "allowDownwardCheck"
			Me.allowDownwardCheck.Size = New System.Drawing.Size(229, 24)
			Me.allowDownwardCheck.TabIndex = 5
			Me.allowDownwardCheck.Text = "Allow downward orientation"
'			Me.allowDownwardCheck.CheckedChanged += New System.EventHandler(Me.allowDownwardCheck_CheckedChanged);
			' 
			' NTextShapeUC
			' 
			Me.Controls.Add(Me.selectedTextGroupBox)
			Me.Name = "NTextShapeUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.selectedTextGroupBox, 0)
			Me.selectedTextGroupBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Overrides"

		Protected Overrides Sub LoadExample()
			Me.DefaultGridCellSize = New NSizeF(200, 100)

			' begin view init
			view.BeginInit()

			' init view
			view.Selection.Mode = DiagramSelectionMode.Single
			view.Grid.Visible = False

			' start document initialization
			document.BeginInit()

			CreateWrappedText()
			CreateStretchedText()
			CreateWrappedTextWithBackplane()
			CreateStretchedTextWithBackplane()
			CreateXMLFormattedText()

			' end document initialization
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub CreateWrappedText()
			' create text
			Dim text As NTextShape = New NTextShape("Wrapped text with font: Tahoma and size: 8", MyBase.GetGridCell(0, 0))

			text.Style.TextStyle = New NTextStyle(New Font("Tahoma", 8), MyBase.GetPredefinedColor(0))
			text.Mode = BoxTextMode.Wrap

			' add to active layer
			document.ActiveLayer.AddChild(text)
			document.SmartRefreshAllViews()
		End Sub
		Private Sub CreateStretchedText()
			' create text
			Dim text As NTextShape = New NTextShape("Stretched text", MyBase.GetGridCell(0, 1))

			text.Style.TextStyle = New NTextStyle(New Font("Tahoma", 8), MyBase.GetPredefinedColor(1))
			text.Mode = BoxTextMode.Stretch

			' add to active layer
			document.ActiveLayer.AddChild(text)
			document.SmartRefreshAllViews()
		End Sub
		Private Sub CreateWrappedTextWithBackplane()
			' create text
			Dim text As NTextShape = New NTextShape("Wrapped text with backplane", MyBase.GetGridCell(1, 0))

			text.Style.TextStyle = New NTextStyle(New Font("Arial", 10), MyBase.GetPredefinedColor(2))
			text.Style.TextStyle.BackplaneStyle.Visible = True
			text.Style.TextStyle.BackplaneStyle.Shape = BackplaneShape.Ellipse
			text.Mode = BoxTextMode.Wrap

			' add to active layer
			document.ActiveLayer.AddChild(text)
			document.SmartRefreshAllViews()
		End Sub
		Private Sub CreateStretchedTextWithBackplane()
			' create text
			Dim text As NTextShape = New NTextShape("Stretched text with backplane", MyBase.GetGridCell(1, 1))

			text.Style.TextStyle = New NTextStyle(New Font("Arial", 10), MyBase.GetPredefinedColor(3))
			text.Style.TextStyle.BackplaneStyle.Visible = True
			text.Style.TextStyle.BackplaneStyle.Shape = BackplaneShape.SmoothEdgeRectangle
			text.Mode = BoxTextMode.Stretch

			' add to active layer
			document.ActiveLayer.AddChild(text)
			document.SmartRefreshAllViews()
		End Sub
		Private Sub CreateXMLFormattedText()
			Dim cell As NRectangleF = MyBase.GetGridCell(2, 0, 1, 1)

			' create text
			Dim text As NTextShape = New NTextShape("<b>XML</b> Formatted Text allows you to <br></br>" & "<font face = 'Tahoma' size = '19'>mix</font>   <font face = 'Impact' size = '22'>fonts</font> <br></br>" & "<font gradient = '0, 0, white, red'>display text with gradiens</font> <br></br>" & "<font size = '22' border = '1' bordercolor = 'gray'>display text with borders</font> <br></br>" & "<font shadowoffset = '2, 2' shadowfadelength = '3' shadowtype = 'gaussianblur'>display text with shadows</font> <br></br>" & "display text with <b>bold</b>, <i>italic</i>, <u>underline</u> and <strike>strikeout</strike>", cell)

			text.Style.TextStyle = New NTextStyle(New Font("Arial", 12), MyBase.GetPredefinedColor(4))
			text.Style.TextStyle.TextFormat = TextFormat.XML

			' add to active layer
			document.ActiveLayer.AddChild(text)
			document.SmartRefreshAllViews()
		End Sub

		Private Sub InitFormControls()
			PauseEventsHandling()

			selectedTextGroupBox.Enabled = False
			textEditBox.Text = ""
			textModeCombo.FillFromEnum(GetType(BoxTextMode))
			textModeCombo.SelectedItem = BoxTextMode.Wrap

			ResumeEventsHandling()
		End Sub
		Protected Overrides Sub AttachToEvents()
			AddHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			AddHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.AttachToEvents()
		End Sub
		Protected Overrides Sub DetachFromEvents()
			RemoveHandler view.EventSinkService.NodeSelected, AddressOf EventSinkService_NodeSelected
			RemoveHandler view.EventSinkService.NodeDeselected, AddressOf EventSinkService_NodeDeselected

			MyBase.DetachFromEvents()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub textEdit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textEditBox.TextChanged
			If EventsHandlingPaused Then
				Return
			End If

			' get the selected text shape
			Dim text As NTextShape = (TryCast(view.Selection.AnchorNode, NTextShape))
			If text Is Nothing Then
				Return
			End If

			' change its text
			text.Text = textEditBox.Text
			document.SmartRefreshAllViews()
		End Sub
		Private Sub textStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles textStyleButton.Click
			' get the selected text shape
			Dim text As NTextShape = (TryCast(view.Selection.AnchorNode, NTextShape))
			If text Is Nothing Then
				Return
			End If

			' show it text style editor
			MyBase.ShowTextStyleEditor(text)
		End Sub
		Private Sub textModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textModeCombo.SelectedIndexChanged
			If EventsHandlingPaused Then
				Return
			End If

			If textModeCombo.SelectedIndex = -1 Then
				Return
			End If

			' get the selected text shape
			Dim text As NTextShape = (TryCast(view.Selection.AnchorNode, NTextShape))
			If text Is Nothing Then
				Return
			End If

			' change its display mode
			text.Mode = CType(textModeCombo.SelectedItem, BoxTextMode)
			document.SmartRefreshAllViews()
		End Sub
		Private Sub allowDownwardCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles allowDownwardCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			If textModeCombo.SelectedIndex = -1 Then
				Return
			End If

			' get the selected text shape
			Dim text As NTextShape = (TryCast(view.Selection.AnchorNode, NTextShape))
			If text Is Nothing Then
				Return
			End If

			' change its allow downward orientation property
			text.AllowDownwardOrientation = allowDownwardCheck.Checked
			document.SmartRefreshAllViews()
		End Sub

		Private Sub EventSinkService_NodeSelected(ByVal args As NNodeEventArgs)
			' get the selected text shape
			Dim text As NTextShape = (TryCast(view.Selection.AnchorNode, NTextShape))
			If text Is Nothing Then
				Return
			End If

			' update the form controls from the shape
			PauseEventsHandling()

			selectedTextGroupBox.Enabled = True
			textEditBox.Text = text.Text
			textModeCombo.SelectedItem = text.Mode
			allowDownwardCheck.Checked = text.AllowDownwardOrientation

			ResumeEventsHandling()
		End Sub
		Private Sub EventSinkService_NodeDeselected(ByVal args As NNodeEventArgs)
			selectedTextGroupBox.Enabled = False
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label1 As System.Windows.Forms.Label
		Private WithEvents textStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private selectedTextGroupBox As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents textEditBox As Nevron.UI.WinForm.Controls.NTextBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents allowDownwardCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents textModeCombo As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace
