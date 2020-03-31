Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Diagram
Imports Nevron.Diagram.Templates
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.WinForm
Imports Nevron.Diagram.WinForm.Commands

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NStatusBarUC.
	''' </summary>
	Public Class NStatusBarUC
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
			Me.showStatusBarCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.documentPropsGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.docWidthTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.docHeightTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.measurementUnitButton = New Nevron.Editors.NMeasurementUnitButton()
			Me.documentPropsGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' showStatusBarCheckBox
			' 
			Me.showStatusBarCheckBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.showStatusBarCheckBox.Checked = True
			Me.showStatusBarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
			Me.showStatusBarCheckBox.Location = New System.Drawing.Point(8, 152)
			Me.showStatusBarCheckBox.Name = "showStatusBarCheckBox"
			Me.showStatusBarCheckBox.Size = New System.Drawing.Size(234, 24)
			Me.showStatusBarCheckBox.TabIndex = 1
			Me.showStatusBarCheckBox.Text = "Status bar visible"
'			Me.showStatusBarCheckBox.CheckedChanged += New System.EventHandler(Me.showStatusBarCheckBox_CheckedChanged);
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
			Me.documentPropsGroup.Text = "Document properties"
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
			Me.docWidthTextBox.Size = New System.Drawing.Size(184, 20)
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
			Me.docHeightTextBox.Size = New System.Drawing.Size(184, 20)
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
			Me.measurementUnitButton.Size = New System.Drawing.Size(232, 23)
			Me.measurementUnitButton.TabIndex = 1
			Me.measurementUnitButton.Text = "Measurement Unit"
'			Me.measurementUnitButton.MeasurementUnitChanged += New System.EventHandler(Me.measurementUnitButton_MeasurementUnitChanged);
			' 
			' NStatusBarUC
			' 
			Me.Controls.Add(Me.documentPropsGroup)
			Me.Controls.Add(Me.showStatusBarCheckBox)
			Me.Name = "NStatusBarUC"
			Me.Size = New System.Drawing.Size(250, 600)
			Me.Controls.SetChildIndex(Me.showStatusBarCheckBox, 0)
			Me.Controls.SetChildIndex(Me.documentPropsGroup, 0)
			Me.documentPropsGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Component Overrides"
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				Form.CommandBarsManager.Commander.StatusBar.Visible = False
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' show the status bar
			Form.CommandBarsManager.Commander.StatusBar.Visible = True

			' begin view init
			view.BeginInit()

			document.BeginInit()
			CreateDefaultFlowDiagram()
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

			Try
				showStatusBarCheckBox.Checked = Form.CommandBarsManager.Commander.StatusBar.Visible
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

		Private Sub showStatusBarCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showStatusBarCheckBox.CheckedChanged
			Form.CommandBarsManager.Commander.StatusBar.Visible = showStatusBarCheckBox.Checked
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
		Private WithEvents showStatusBarCheckBox As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region

		#Region "Fields"

		#End Region
	End Class
End Namespace
