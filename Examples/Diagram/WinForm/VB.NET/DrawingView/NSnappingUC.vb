Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Editors
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NSnappingUC.
	''' </summary>
	Public Class NSnappingUC
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
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.snapStrengthButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.snapRotatorsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapPinPointsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapShapePortsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapShapePlugsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapShapeControlPointsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapGeometryMidPointsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapGeometryControlPointsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.snapGeometryBasePointsToButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.rotationStepTextBox = New System.Windows.Forms.TextBox()
			Me.rotationDeviationTextBox = New System.Windows.Forms.TextBox()
			Me.snapRotationCheck = New System.Windows.Forms.CheckBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.snapStrengthButton)
			Me.nGroupBox1.Controls.Add(Me.snapToButton)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(250, 88)
			Me.nGroupBox1.TabIndex = 0
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "General"
			' 
			' snapStrengthButton
			' 
			Me.snapStrengthButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapStrengthButton.Location = New System.Drawing.Point(16, 56)
			Me.snapStrengthButton.Name = "snapStrengthButton"
			Me.snapStrengthButton.Size = New System.Drawing.Size(216, 23)
			Me.snapStrengthButton.TabIndex = 1
			Me.snapStrengthButton.Text = "Snap strength..."
'			Me.snapStrengthButton.Click += New System.EventHandler(Me.snapStrengthButton_Click);
			' 
			' snapToButton
			' 
			Me.snapToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapToButton.Location = New System.Drawing.Point(16, 24)
			Me.snapToButton.Name = "snapToButton"
			Me.snapToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapToButton.TabIndex = 0
			Me.snapToButton.Text = "Snap to..."
'			Me.snapToButton.Click += New System.EventHandler(Me.snapToButton_Click);
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.snapRotatorsToButton)
			Me.nGroupBox2.Controls.Add(Me.snapPinPointsToButton)
			Me.nGroupBox2.Controls.Add(Me.snapShapePortsToButton)
			Me.nGroupBox2.Controls.Add(Me.snapShapePlugsToButton)
			Me.nGroupBox2.Controls.Add(Me.snapShapeControlPointsToButton)
			Me.nGroupBox2.Controls.Add(Me.snapGeometryMidPointsToButton)
			Me.nGroupBox2.Controls.Add(Me.snapGeometryControlPointsToButton)
			Me.nGroupBox2.Controls.Add(Me.snapGeometryBasePointsToButton)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 88)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(250, 282)
			Me.nGroupBox2.TabIndex = 1
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Points snapping"
			' 
			' snapRotatorsToButton
			' 
			Me.snapRotatorsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapRotatorsToButton.Location = New System.Drawing.Point(16, 245)
			Me.snapRotatorsToButton.Name = "snapRotatorsToButton"
			Me.snapRotatorsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapRotatorsToButton.TabIndex = 8
			Me.snapRotatorsToButton.Text = "Snap rotators to..."
'			Me.snapRotatorsToButton.Click += New System.EventHandler(Me.snapRotatorsToButton_Click);
			' 
			' snapPinPointsToButton
			' 
			Me.snapPinPointsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapPinPointsToButton.Location = New System.Drawing.Point(15, 213)
			Me.snapPinPointsToButton.Name = "snapPinPointsToButton"
			Me.snapPinPointsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapPinPointsToButton.TabIndex = 7
			Me.snapPinPointsToButton.Text = "Snap pins to..."
'			Me.snapPinPointsToButton.Click += New System.EventHandler(Me.snapPinPointsToButton_Click);
			' 
			' snapShapePortsToButton
			' 
			Me.snapShapePortsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapShapePortsToButton.Location = New System.Drawing.Point(15, 149)
			Me.snapShapePortsToButton.Name = "snapShapePortsToButton"
			Me.snapShapePortsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapShapePortsToButton.TabIndex = 5
			Me.snapShapePortsToButton.Text = "Snap ports to..."
'			Me.snapShapePortsToButton.Click += New System.EventHandler(Me.snapShapePortsToButton_Click);
			' 
			' snapShapePlugsToButton
			' 
			Me.snapShapePlugsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapShapePlugsToButton.Location = New System.Drawing.Point(15, 181)
			Me.snapShapePlugsToButton.Name = "snapShapePlugsToButton"
			Me.snapShapePlugsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapShapePlugsToButton.TabIndex = 6
			Me.snapShapePlugsToButton.Text = "Snap plugs to..."
'			Me.snapShapePlugsToButton.Click += New System.EventHandler(Me.snapShapePlugsToButton_Click);
			' 
			' snapShapeControlPointsToButton
			' 
			Me.snapShapeControlPointsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapShapeControlPointsToButton.Location = New System.Drawing.Point(15, 117)
			Me.snapShapeControlPointsToButton.Name = "snapShapeControlPointsToButton"
			Me.snapShapeControlPointsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapShapeControlPointsToButton.TabIndex = 4
			Me.snapShapeControlPointsToButton.Text = "Snap start end points to..."
'			Me.snapShapeControlPointsToButton.Click += New System.EventHandler(Me.snapShapeControlPointsToButton_Click);
			' 
			' snapGeometryMidPointsToButton
			' 
			Me.snapGeometryMidPointsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapGeometryMidPointsToButton.Location = New System.Drawing.Point(16, 85)
			Me.snapGeometryMidPointsToButton.Name = "snapGeometryMidPointsToButton"
			Me.snapGeometryMidPointsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapGeometryMidPointsToButton.TabIndex = 3
			Me.snapGeometryMidPointsToButton.Text = "Snap mid points to..."
'			Me.snapGeometryMidPointsToButton.Click += New System.EventHandler(Me.snapGeometryMidPointsToButton_Click);
			' 
			' snapGeometryControlPointsToButton
			' 
			Me.snapGeometryControlPointsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapGeometryControlPointsToButton.Location = New System.Drawing.Point(16, 53)
			Me.snapGeometryControlPointsToButton.Name = "snapGeometryControlPointsToButton"
			Me.snapGeometryControlPointsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapGeometryControlPointsToButton.TabIndex = 2
			Me.snapGeometryControlPointsToButton.Text = "Snap control points to..."
'			Me.snapGeometryControlPointsToButton.Click += New System.EventHandler(Me.snapGeometryControlPointsToButton_Click);
			' 
			' snapGeometryBasePointsToButton
			' 
			Me.snapGeometryBasePointsToButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.snapGeometryBasePointsToButton.Location = New System.Drawing.Point(15, 21)
			Me.snapGeometryBasePointsToButton.Name = "snapGeometryBasePointsToButton"
			Me.snapGeometryBasePointsToButton.Size = New System.Drawing.Size(216, 23)
			Me.snapGeometryBasePointsToButton.TabIndex = 1
			Me.snapGeometryBasePointsToButton.Text = "Snap base points to..."
'			Me.snapGeometryBasePointsToButton.Click += New System.EventHandler(Me.snapGeometryBasePointsToButton_Click);
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.label2)
			Me.nGroupBox3.Controls.Add(Me.label1)
			Me.nGroupBox3.Controls.Add(Me.rotationStepTextBox)
			Me.nGroupBox3.Controls.Add(Me.rotationDeviationTextBox)
			Me.nGroupBox3.Controls.Add(Me.snapRotationCheck)
			Me.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Top
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(0, 370)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(250, 112)
			Me.nGroupBox3.TabIndex = 2
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Rotation snapping"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(16, 79)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(100, 23)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Rotation step:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 47)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(100, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Rotation deviation:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' rotationStepTextBox
			' 
			Me.rotationStepTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.rotationStepTextBox.Location = New System.Drawing.Point(128, 80)
			Me.rotationStepTextBox.Name = "rotationStepTextBox"
			Me.rotationStepTextBox.Size = New System.Drawing.Size(100, 20)
			Me.rotationStepTextBox.TabIndex = 4
			Me.rotationStepTextBox.Text = "textBox2"
'			Me.rotationStepTextBox.TextChanged += New System.EventHandler(Me.rotationStepTextBox_TextChanged);
			' 
			' rotationDeviationTextBox
			' 
			Me.rotationDeviationTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.rotationDeviationTextBox.Location = New System.Drawing.Point(128, 48)
			Me.rotationDeviationTextBox.Name = "rotationDeviationTextBox"
			Me.rotationDeviationTextBox.Size = New System.Drawing.Size(100, 20)
			Me.rotationDeviationTextBox.TabIndex = 2
			Me.rotationDeviationTextBox.Text = "textBox1"
'			Me.rotationDeviationTextBox.TextChanged += New System.EventHandler(Me.rotationDeviationTextBox_TextChanged);
			' 
			' snapRotationCheck
			' 
			Me.snapRotationCheck.Location = New System.Drawing.Point(16, 16)
			Me.snapRotationCheck.Name = "snapRotationCheck"
			Me.snapRotationCheck.Size = New System.Drawing.Size(104, 24)
			Me.snapRotationCheck.TabIndex = 0
			Me.snapRotationCheck.Text = "Snap rotation"
'			Me.snapRotationCheck.CheckedChanged += New System.EventHandler(Me.snapRotationCheck_CheckedChanged);
			' 
			' NSnappingUC
			' 
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NSnappingUC"
			Me.Size = New System.Drawing.Size(250, 571)
			Me.Controls.SetChildIndex(Me.nGroupBox1, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox2, 0)
			Me.Controls.SetChildIndex(Me.nGroupBox3, 0)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.nGroupBox3.PerformLayout()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' begin view init
			view.BeginInit()

			' init document
			document.BeginInit()
			CreateDefaultFlowDiagram()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub

		Protected Overrides Sub ResetExample()
			view.Reset()
			MyBase.ResetExample()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			snapRotationCheck.Checked = view.SnapManager.SnapRotation
			rotationStepTextBox.Text = view.SnapManager.RotationStep.ToString()
			rotationDeviationTextBox.Text = view.SnapManager.RotationDeviation.ToString()

			ResumeEventsHandling()
		End Sub

		Private Sub InitDocument()
			document.ActiveLayer.AddChild(New NRectangleShape(10, 10, 50, 50))
			document.ActiveLayer.AddChild(New NRectangleShape(100, 100, 50, 50))
			document.ActiveLayer.AddChild(New NRectangleShape(100, 10, 50, 50))
			document.ActiveLayer.AddChild(New NRectangleShape(10, 100, 50, 50))
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub snapToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapTo, targets) Then
				view.SnapManager.SnapTo = targets
			End If
		End Sub
		Private Sub snapStrengthButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapStrengthButton.Click
			Dim strength As NSnapStrength
			If NSnapStrengthTypeEditor.Edit(view.SnapManager.SnapStrength, strength) Then
				view.SnapManager.SnapStrength = strength
			End If
		End Sub

		Private Sub snapGeometryBasePointsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapGeometryBasePointsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapGeometryBasePointsTo, targets) Then
				view.SnapManager.SnapGeometryBasePointsTo = targets
			End If
		End Sub
		Private Sub snapGeometryMidPointsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapGeometryMidPointsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapGeometryMidPointsTo, targets) Then
				view.SnapManager.SnapGeometryMidPointsTo = targets
			End If
		End Sub
		Private Sub snapGeometryControlPointsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapGeometryControlPointsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapGeometryControlPointsTo, targets) Then
				view.SnapManager.SnapGeometryControlPointsTo = targets
			End If
		End Sub
		Private Sub snapShapeControlPointsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapShapeControlPointsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapShapeControlPointsTo, targets) Then
				view.SnapManager.SnapShapeControlPointsTo = targets
			End If
		End Sub
		Private Sub snapShapePortsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapShapePortsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapShapePortsTo, targets) Then
				view.SnapManager.SnapShapePortsTo = targets
			End If
		End Sub
		Private Sub snapShapePlugsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapShapePlugsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapShapePlugsTo, targets) Then
				view.SnapManager.SnapShapePlugsTo = targets
			End If
		End Sub
		Private Sub snapPinPointsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapPinPointsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapPinPointsTo, targets) Then
				view.SnapManager.SnapPinPointsTo = targets
			End If
		End Sub
		Private Sub snapRotatorsToButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapRotatorsToButton.Click
			Dim targets As NSnapTargets
			If NSnapTargetsTypeEditor.Edit(view.SnapManager.SnapRotatorsTo, targets) Then
				view.SnapManager.SnapRotatorsTo = targets
			End If
		End Sub
		Private Sub snapRotationCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles snapRotationCheck.CheckedChanged
			If EventsHandlingPaused Then
				Return
			End If

			view.SnapManager.SnapRotation = snapRotationCheck.Checked
		End Sub
		Private Sub rotationDeviationTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rotationDeviationTextBox.TextChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim deviation As Single = 0
			Try
				deviation = Single.Parse(rotationDeviationTextBox.Text)
			Catch
				Return
			End Try

			view.SnapManager.RotationDeviation = deviation
		End Sub
		Private Sub rotationStepTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rotationStepTextBox.TextChanged
			If EventsHandlingPaused Then
				Return
			End If

			Dim [step] As Single = 0
			Try
				[step] = Single.Parse(rotationStepTextBox.Text)
			Catch
				Return
			End Try

			view.SnapManager.RotationStep = [step]
		End Sub

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents snapToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapStrengthButton As Nevron.UI.WinForm.Controls.NButton
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents snapGeometryBasePointsToButton As Nevron.UI.WinForm.Controls.NButton
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents snapGeometryControlPointsToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapGeometryMidPointsToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapShapeControlPointsToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapShapePlugsToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapShapePortsToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapPinPointsToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapRotatorsToButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents snapRotationCheck As System.Windows.Forms.CheckBox
		Private WithEvents rotationDeviationTextBox As System.Windows.Forms.TextBox
		Private WithEvents rotationStepTextBox As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label

		#End Region

	End Class
End Namespace