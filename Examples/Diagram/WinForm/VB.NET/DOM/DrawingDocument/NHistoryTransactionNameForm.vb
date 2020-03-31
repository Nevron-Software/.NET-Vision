Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NHistoryTransactionNameForm.
	''' </summary>
	Public Class NHistoryTransactionNameForm
		Inherits System.Windows.Forms.Form
		Private cancelBtn As Nevron.UI.WinForm.Controls.NButton
		Private okButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents titleTextBox As Nevron.UI.WinForm.Controls.NTextBox
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.cancelBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.okButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.titleTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' cancelBtn
			' 
			Me.cancelBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.cancelBtn.Location = New System.Drawing.Point(198, 40)
			Me.cancelBtn.Name = "cancelBtn"
			Me.cancelBtn.TabIndex = 2
			Me.cancelBtn.Text = "Cancel"
			' 
			' okButton
			' 
			Me.okButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.okButton.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.okButton.Location = New System.Drawing.Point(118, 40)
			Me.okButton.Name = "okButton"
			Me.okButton.TabIndex = 1
			Me.okButton.Text = "OK"
			' 
			' titleTextBox
			' 
			Me.titleTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.titleTextBox.ErrorMessage = Nothing
			Me.titleTextBox.Location = New System.Drawing.Point(8, 8)
			Me.titleTextBox.Name = "titleTextBox"
			Me.titleTextBox.Size = New System.Drawing.Size(262, 20)
			Me.titleTextBox.TabIndex = 0
			Me.titleTextBox.Text = "My transaction"
'			Me.titleTextBox.TextChanged += New System.EventHandler(Me.titleTextBox_TextChanged);
			' 
			' NHistoryTransactionNameForm
			' 
			Me.AcceptButton = Me.okButton
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.cancelBtn
			Me.ClientSize = New System.Drawing.Size(282, 72)
			Me.ControlBox = False
			Me.Controls.Add(Me.titleTextBox)
			Me.Controls.Add(Me.cancelBtn)
			Me.Controls.Add(Me.okButton)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Name = "NHistoryTransactionNameForm"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Enter transaction name"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub titleTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles titleTextBox.TextChanged
			If titleTextBox.Text.Length = 0 Then
				okButton.Enabled = False
				Return
			End If

			okButton.Enabled = True
		End Sub

		Public ReadOnly Property TransactionTitle() As String
			Get
				Return titleTextBox.Text
			End Get
		End Property
	End Class
End Namespace
