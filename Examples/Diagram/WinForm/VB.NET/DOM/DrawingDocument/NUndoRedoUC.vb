Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NUndoRedoUC.
	''' </summary>
	Public Class NUndoRedoUC
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
			Me.transactionGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.historyTransactionTitleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.commitHistoryTransactionButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.rollbackHistoryTransactionButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.startTransactionButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.recordHistoryCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.addShapeButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.undoButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.redoButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.undoListBox = New Nevron.UI.WinForm.Controls.NListBox()
			Me.historyGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.redoListBox = New Nevron.UI.WinForm.Controls.NListBox()
			Me.transactionGroup.SuspendLayout()
			Me.historyGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' transactionGroup
			' 
			Me.transactionGroup.Controls.Add(Me.historyTransactionTitleTextBox)
			Me.transactionGroup.Controls.Add(Me.commitHistoryTransactionButton)
			Me.transactionGroup.Controls.Add(Me.rollbackHistoryTransactionButton)
			Me.transactionGroup.Controls.Add(Me.startTransactionButton)
			Me.transactionGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.transactionGroup.ImageIndex = 0
			Me.transactionGroup.Location = New System.Drawing.Point(0, 304)
			Me.transactionGroup.Name = "transactionGroup"
			Me.transactionGroup.Size = New System.Drawing.Size(250, 160)
			Me.transactionGroup.TabIndex = 1
			Me.transactionGroup.TabStop = False
			Me.transactionGroup.Text = "History Transactions"
			' 
			' historyTransactionTitleTextBox
			' 
			Me.historyTransactionTitleTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.historyTransactionTitleTextBox.ErrorMessage = Nothing
			Me.historyTransactionTitleTextBox.Location = New System.Drawing.Point(8, 56)
			Me.historyTransactionTitleTextBox.Name = "historyTransactionTitleTextBox"
			Me.historyTransactionTitleTextBox.ReadOnly = True
			Me.historyTransactionTitleTextBox.Size = New System.Drawing.Size(232, 20)
			Me.historyTransactionTitleTextBox.TabIndex = 1
			Me.historyTransactionTitleTextBox.Text = ""
			' 
			' commitHistoryTransactionButton
			' 
			Me.commitHistoryTransactionButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.commitHistoryTransactionButton.Location = New System.Drawing.Point(8, 88)
			Me.commitHistoryTransactionButton.Name = "commitHistoryTransactionButton"
			Me.commitHistoryTransactionButton.Size = New System.Drawing.Size(232, 23)
			Me.commitHistoryTransactionButton.TabIndex = 2
			Me.commitHistoryTransactionButton.Text = "Commit"
'			Me.commitHistoryTransactionButton.Click += New System.EventHandler(Me.commitHistoryTransactionButton_Click);
			' 
			' rollbackHistoryTransactionButton
			' 
			Me.rollbackHistoryTransactionButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.rollbackHistoryTransactionButton.Location = New System.Drawing.Point(8, 120)
			Me.rollbackHistoryTransactionButton.Name = "rollbackHistoryTransactionButton"
			Me.rollbackHistoryTransactionButton.Size = New System.Drawing.Size(232, 23)
			Me.rollbackHistoryTransactionButton.TabIndex = 3
			Me.rollbackHistoryTransactionButton.Text = "Rollback"
'			Me.rollbackHistoryTransactionButton.Click += New System.EventHandler(Me.rollbackHistoryTransactionButton_Click);
			' 
			' startTransactionButton
			' 
			Me.startTransactionButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.startTransactionButton.Location = New System.Drawing.Point(8, 24)
			Me.startTransactionButton.Name = "startTransactionButton"
			Me.startTransactionButton.Size = New System.Drawing.Size(232, 23)
			Me.startTransactionButton.TabIndex = 0
			Me.startTransactionButton.Text = "Start history transaction"
'			Me.startTransactionButton.Click += New System.EventHandler(Me.startTransactionButton_Click);
			' 
			' recordHistoryCheckBox
			' 
			Me.recordHistoryCheckBox.Checked = True
			Me.recordHistoryCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
			Me.recordHistoryCheckBox.Location = New System.Drawing.Point(8, 472)
			Me.recordHistoryCheckBox.Name = "recordHistoryCheckBox"
			Me.recordHistoryCheckBox.Size = New System.Drawing.Size(112, 24)
			Me.recordHistoryCheckBox.TabIndex = 2
			Me.recordHistoryCheckBox.Text = "Record history"
'			Me.recordHistoryCheckBox.CheckedChanged += New System.EventHandler(Me.recordHistoryCheckBox_CheckedChanged);
			' 
			' addShapeButton
			' 
			Me.addShapeButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.addShapeButton.Location = New System.Drawing.Point(120, 472)
			Me.addShapeButton.Name = "addShapeButton"
			Me.addShapeButton.Size = New System.Drawing.Size(122, 23)
			Me.addShapeButton.TabIndex = 3
			Me.addShapeButton.Text = "Add random shape"
'			Me.addShapeButton.Click += New System.EventHandler(Me.addShapeButton_Click);
			' 
			' undoButton
			' 
			Me.undoButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.undoButton.Location = New System.Drawing.Point(8, 120)
			Me.undoButton.Name = "undoButton"
			Me.undoButton.Size = New System.Drawing.Size(232, 23)
			Me.undoButton.TabIndex = 2
			Me.undoButton.Text = "Undo"
'			Me.undoButton.Click += New System.EventHandler(Me.undoButton_Click);
			' 
			' redoButton
			' 
			Me.redoButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.redoButton.Location = New System.Drawing.Point(8, 256)
			Me.redoButton.Name = "redoButton"
			Me.redoButton.Size = New System.Drawing.Size(232, 23)
			Me.redoButton.TabIndex = 5
			Me.redoButton.Text = "Redo"
'			Me.redoButton.Click += New System.EventHandler(Me.redoButton_Click);
			' 
			' undoListBox
			' 
			Me.undoListBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.undoListBox.Location = New System.Drawing.Point(8, 48)
			Me.undoListBox.Name = "undoListBox"
			Me.undoListBox.Size = New System.Drawing.Size(232, 66)
			Me.undoListBox.TabIndex = 1
			' 
			' historyGroup
			' 
			Me.historyGroup.Controls.Add(Me.label2)
			Me.historyGroup.Controls.Add(Me.label1)
			Me.historyGroup.Controls.Add(Me.undoListBox)
			Me.historyGroup.Controls.Add(Me.undoButton)
			Me.historyGroup.Controls.Add(Me.redoButton)
			Me.historyGroup.Controls.Add(Me.redoListBox)
			Me.historyGroup.Dock = System.Windows.Forms.DockStyle.Top
			Me.historyGroup.Enabled = False
			Me.historyGroup.ImageIndex = 0
			Me.historyGroup.Location = New System.Drawing.Point(0, 0)
			Me.historyGroup.Name = "historyGroup"
			Me.historyGroup.Size = New System.Drawing.Size(250, 304)
			Me.historyGroup.TabIndex = 0
			Me.historyGroup.TabStop = False
			Me.historyGroup.Text = "History State"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 160)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 16)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Redo list:"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Undo list:"
			' 
			' redoListBox
			' 
			Me.redoListBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.redoListBox.Location = New System.Drawing.Point(8, 184)
			Me.redoListBox.Name = "redoListBox"
			Me.redoListBox.Size = New System.Drawing.Size(232, 66)
			Me.redoListBox.TabIndex = 4
			' 
			' NUndoRedoUC
			' 
			Me.Controls.Add(Me.addShapeButton)
			Me.Controls.Add(Me.transactionGroup)
			Me.Controls.Add(Me.historyGroup)
			Me.Controls.Add(Me.recordHistoryCheckBox)
			Me.Name = "NUndoRedoUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.recordHistoryCheckBox, 0)
			Me.Controls.SetChildIndex(Me.historyGroup, 0)
			Me.Controls.SetChildIndex(Me.transactionGroup, 0)
			Me.Controls.SetChildIndex(Me.addShapeButton, 0)
			Me.transactionGroup.ResumeLayout(False)
			Me.historyGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init document
			InitDocument()

			' update form controls
			UpdateFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			MyBase.ResetExample()
			historyTransactionTitleTextBox.Text = String.Empty
			UpdateFormControls()
		End Sub

		Protected Overrides Sub AttachToEvents()
			AddHandler document.HistoryService.OperationRecorded, AddressOf HistoryService_Changed
			AddHandler document.HistoryService.RedoExecuted, AddressOf HistoryService_Changed
			AddHandler document.HistoryService.UndoExecuted, AddressOf HistoryService_Changed

			MyBase.AttachToEvents()
		End Sub

		Protected Overrides Sub DetachFromEvents()
			RemoveHandler document.HistoryService.OperationRecorded, AddressOf HistoryService_Changed
			RemoveHandler document.HistoryService.RedoExecuted, AddressOf HistoryService_Changed
			RemoveHandler document.HistoryService.UndoExecuted, AddressOf HistoryService_Changed

			MyBase.DetachFromEvents()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			CreateGroup(0, 0, Color.Red)
			CreateGroup(0, 2, Color.Blue)
			CreateGroup(1, 1, Color.Green)
		End Sub


		Private Sub CreateGroup(ByVal row As Integer, ByVal col As Integer, ByVal color As Color)
			Dim transactionName As String = color.ToString().Replace("Color [", String.Empty).Replace("]", String.Empty) & " group"

			' start transaction
			document.StartTransaction(transactionName)

			' create the shapes in the group
			Dim polygon As NPolygonShape = New NPolygonShape(MyBase.GetRandomPoints(MyBase.GetGridCell(row, col), 6))
			Dim curve As NClosedCurveShape = New NClosedCurveShape(MyBase.GetRandomPoints(MyBase.GetGridCell(row, col + 1), 6), 1)
			Dim text As NTextShape = New NTextShape(transactionName, MyBase.GetGridCell(row, col, 0, 1))

			' create the group
			Dim group As NGroup = New NGroup()
			group.Shapes.AddChild(polygon)
			group.Shapes.AddChild(curve)
			group.Shapes.AddChild(text)
			group.UpdateModelBounds()

			' apply styles to it
			group.Style.FillStyle = New NColorFillStyle(Color.FromArgb(50, color))
			group.Style.StrokeStyle = New NStrokeStyle(1, color)
			group.Style.TextStyle = New NTextStyle(New Font("Arial", 10), color)
			group.Style.TextStyle.StringFormatStyle.VertAlign = VertAlign.Bottom

			' add the group to the active layer
			document.ActiveLayer.AddChild(group)

			' commit the transaction
			document.HistoryService.Commit()
		End Sub

		Private Sub AddRandomShape()
			Dim values As Array = System.Enum.GetValues(GetType(BasicShapes))

			Dim factory As NBasicShapesFactory = New NBasicShapesFactory(document)
			Dim shape As NShape = factory.CreateShape(CInt(Fix(values.GetValue(Random.Next(values.Length)))))

			shape.Bounds = New NRectangleF(MyBase.GetRandomPoint(view.Viewport), MyBase.GetRandomSize(New NSizeF(10, 10), New NSizeF(100, 100)))

			document.ActiveLayer.AddChild(shape)
		End Sub


		Private Sub UpdateFormControls()
			PauseEventsHandling()

			If historyTransactionTitleTextBox.Text = String.Empty Then
				commitHistoryTransactionButton.Enabled = False
				rollbackHistoryTransactionButton.Enabled = False
				startTransactionButton.Enabled = True
			Else
				commitHistoryTransactionButton.Enabled = True
				rollbackHistoryTransactionButton.Enabled = True
				startTransactionButton.Enabled = False
			End If

			undoButton.Enabled = document.HistoryService.CanUndo()
			redoButton.Enabled = document.HistoryService.CanRedo()

			DumpHistoryToListBoxes(undoListBox, redoListBox)
			undoListBox.SelectedIndex = undoListBox.Items.Count - 1
			redoListBox.SelectedIndex = redoListBox.Items.Count - 1

			historyGroup.Enabled = document.HistoryService.CanRecord()

			ResumeEventsHandling()
		End Sub

		Private Sub DumpHistoryToListBoxes(ByVal undoList As NListBox, ByVal redoList As NListBox)
			undoList.Items.Clear()
			redoList.Items.Clear()

			For Each undo As NOperation In document.HistoryService.UndoStack
				undoList.Items.Add(undo.Description)
			Next undo

			For Each redo As NOperation In document.HistoryService.RedoStack
				redoList.Items.Add(redo.Description)
			Next redo
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub addShapeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addShapeButton.Click
			AddRandomShape()
			document.RefreshAllViews()
		End Sub

		Private Sub recordHistoryCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles recordHistoryCheckBox.CheckedChanged
			If recordHistoryCheckBox.Checked Then
				document.HistoryService.Resume()
			Else
				document.HistoryService.Pause()
			End If

			UpdateFormControls()
		End Sub


		Private Sub startTransactionButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles startTransactionButton.Click
			Dim form As NHistoryTransactionNameForm = New NHistoryTransactionNameForm()
			If form.ShowDialog() = DialogResult.Cancel Then
				Return
			End If

			historyTransactionTitleTextBox.Text = form.TransactionTitle
			document.HistoryService.StartTransaction(form.TransactionTitle)
			UpdateFormControls()
		End Sub

		Private Sub commitHistoryTransactionButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles commitHistoryTransactionButton.Click
			document.HistoryService.Commit()
			historyTransactionTitleTextBox.Text = String.Empty
			UpdateFormControls()
		End Sub

		Private Sub rollbackHistoryTransactionButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rollbackHistoryTransactionButton.Click
			document.HistoryService.Rollback()
			historyTransactionTitleTextBox.Text = String.Empty
			UpdateFormControls()
			document.RefreshAllViews()
		End Sub


		Private Sub undoButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles undoButton.Click
			document.HistoryService.Undo()
		End Sub

		Private Sub redoButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles redoButton.Click
			document.HistoryService.Redo()
		End Sub


		Private Sub HistoryService_Changed(ByVal sender As Object, ByVal e As EventArgs)
			UpdateFormControls()
		End Sub


		#End Region

		#Region "Designer Fields"

		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents recordHistoryCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
		Private historyTransactionTitleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents commitHistoryTransactionButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents rollbackHistoryTransactionButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents addShapeButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents undoButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents redoButton As Nevron.UI.WinForm.Controls.NButton
		Private undoListBox As Nevron.UI.WinForm.Controls.NListBox
		Private redoListBox As Nevron.UI.WinForm.Controls.NListBox
		Private historyGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private transactionGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents startTransactionButton As Nevron.UI.WinForm.Controls.NButton
		#End Region
	End Class
End Namespace
