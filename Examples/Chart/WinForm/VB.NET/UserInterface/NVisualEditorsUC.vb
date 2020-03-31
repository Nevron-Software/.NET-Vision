Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NVisualEditorsUC
		Inherits NExampleBaseUC

		Private WithEvents WizardButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ShowEditor As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
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
			Me.WizardButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ShowEditor = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' WizardButton
			' 
			Me.WizardButton.Location = New System.Drawing.Point(8, 8)
			Me.WizardButton.Name = "WizardButton"
			Me.WizardButton.Size = New System.Drawing.Size(102, 25)
			Me.WizardButton.TabIndex = 10
			Me.WizardButton.Text = "Chart Wizard"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.WizardButton.Click += new System.EventHandler(this.WizardButton_Click);
			' 
			' ShowEditor
			' 
			Me.ShowEditor.Location = New System.Drawing.Point(8, 37)
			Me.ShowEditor.Name = "ShowEditor"
			Me.ShowEditor.Size = New System.Drawing.Size(102, 25)
			Me.ShowEditor.TabIndex = 11
			Me.ShowEditor.Text = "Chart Editor"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowEditor.Click += new System.EventHandler(this.ShowEditor_Click);
			' 
			' NVisualEditorsUC
			' 
			Me.Controls.Add(Me.ShowEditor)
			Me.Controls.Add(Me.WizardButton)
			Me.Name = "NVisualEditorsUC"
			Me.Size = New System.Drawing.Size(120, 492)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			Dim title As NLabel = nChartControl1.Labels.AddHeader("Visual Editors")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

		End Sub

		Private Sub WizardButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WizardButton.Click
			nChartControl1.Wizard.ShowDialog()
		End Sub

		Private Sub ShowEditor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowEditor.Click
			nChartControl1.ShowEditor()
		End Sub
	End Class
End Namespace
