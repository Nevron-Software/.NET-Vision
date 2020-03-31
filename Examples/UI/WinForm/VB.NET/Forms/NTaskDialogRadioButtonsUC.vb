Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NQ1TaskDialogFeaturesUC.
	''' </summary>
	Public Class NTaskDialogRadioButtonsUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

			' TODO: Add any initialization after the InitializeComponent call

		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				For Each element As NRadioBoxElement In m_arrButtons
					element.Dispose()
				Next element
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_arrButtons = New ArrayList()

			'add 5 buttons by default
			For i As Integer = 0 To 4
				addBtn_Click(Nothing, Nothing)
			Next i
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub addBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addBtn.Click
			Dim box As NRadioBoxElement = New NRadioBoxElement()
			m_arrButtons.Add(box)

			box.Text = "Test <b>Radio</b> Button " & m_arrButtons.Count

			Dim item As NListBoxItem = New NListBoxItem()
			item.Tag = box
			item.Text = "Button " & m_arrButtons.Count

			buttonsList.Items.Add(item)

			buttonProperties.SelectedObject = box
		End Sub
		Private Sub removeBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeBtn.Click
			Dim box As NRadioBoxElement = TryCast(buttonsList.SelectedItemTag, NRadioBoxElement)
			If box Is Nothing Then
				Return
			End If

			m_arrButtons.Remove(box)
			buttonsList.Items.RemoveAt(buttonsList.SelectedIndex)
			buttonProperties.SelectedObject = Nothing
		End Sub
		Private Sub buttonsList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonsList.SelectedIndexChanged
			Dim box As NRadioBoxElement = TryCast(buttonsList.SelectedItemTag, NRadioBoxElement)
			buttonProperties.SelectedObject = box
		End Sub
		Private Sub showBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showBtn.Click
			Dim dlg As NTaskDialog = New NTaskDialog()
			dlg.Title = "Q2 2007 Radio Buttons Support"
			dlg.Content.Text = "<font size='12' face='Trebuchet MS'>Task Dialog <b>Radio Buttons</b> example</font>"
			dlg.Content.Image = NSystemImages.Information
			dlg.Content.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			dlg.Content.ImageSize = New NSize(32, 32)
			dlg.PreferredWidth = 300

			If m_arrButtons.Count > 0 Then
				Dim buttons As NRadioBoxElement() = New NRadioBoxElement(m_arrButtons.Count - 1){}
				m_arrButtons.CopyTo(buttons)
				dlg.RadioButtons = buttons
			End If

			dlg.Show()

			Dim box As NRadioBoxElement = dlg.CheckedRadioButton
			If Not box Is Nothing Then
				checkedButtonLabel.Text = box.Text
			Else
				checkedButtonLabel.Text = "None"
			End If

			dlg.RadioButtons = Nothing
			dlg.Dispose()
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.buttonProperties = New System.Windows.Forms.PropertyGrid()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.addBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.buttonsList = New Nevron.UI.WinForm.Controls.NListBox()
			Me.removeBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.showBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.checkedButtonLabel = New System.Windows.Forms.Label()
			Me.nGroupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' buttonProperties
			' 
			Me.buttonProperties.HelpVisible = False
			Me.buttonProperties.LargeButtons = False
			Me.buttonProperties.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.buttonProperties.Location = New System.Drawing.Point(256, 24)
			Me.buttonProperties.Name = "buttonProperties"
			Me.buttonProperties.Size = New System.Drawing.Size(232, 248)
			Me.buttonProperties.TabIndex = 0
			Me.buttonProperties.Text = "propertyGrid1"
			Me.buttonProperties.ToolbarVisible = False
			Me.buttonProperties.ViewBackColor = System.Drawing.SystemColors.Window
			Me.buttonProperties.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.removeBtn)
			Me.nGroupBox1.Controls.Add(Me.buttonsList)
			Me.nGroupBox1.Controls.Add(Me.addBtn)
			Me.nGroupBox1.Controls.Add(Me.buttonProperties)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(504, 288)
			Me.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Radio Buttons"
			' 
			' addBtn
			' 
			Me.addBtn.Location = New System.Drawing.Point(8, 24)
			Me.addBtn.Name = "addBtn"
			Me.addBtn.Size = New System.Drawing.Size(112, 24)
			Me.addBtn.TabIndex = 1
			Me.addBtn.Text = "Add Button"
'			Me.addBtn.Click += New System.EventHandler(Me.addBtn_Click);
			' 
			' buttonsList
			' 
			Me.buttonsList.IntegralHeight = False
			Me.buttonsList.Location = New System.Drawing.Point(8, 56)
			Me.buttonsList.Name = "buttonsList"
			Me.buttonsList.Size = New System.Drawing.Size(232, 216)
			Me.buttonsList.TabIndex = 2
'			Me.buttonsList.SelectedIndexChanged += New System.EventHandler(Me.buttonsList_SelectedIndexChanged);
			' 
			' removeBtn
			' 
			Me.removeBtn.Location = New System.Drawing.Point(128, 24)
			Me.removeBtn.Name = "removeBtn"
			Me.removeBtn.Size = New System.Drawing.Size(112, 24)
			Me.removeBtn.TabIndex = 3
			Me.removeBtn.Text = "Remove Button"
'			Me.removeBtn.Click += New System.EventHandler(Me.removeBtn_Click);
			' 
			' showBtn
			' 
			Me.showBtn.Location = New System.Drawing.Point(8, 304)
			Me.showBtn.Name = "showBtn"
			Me.showBtn.Size = New System.Drawing.Size(144, 24)
			Me.showBtn.TabIndex = 2
			Me.showBtn.Text = "Show Dialog.."
'			Me.showBtn.Click += New System.EventHandler(Me.showBtn_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 336)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(136, 23)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Checked Radio Button:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' checkedButtonLabel
			' 
			Me.checkedButtonLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.checkedButtonLabel.Location = New System.Drawing.Point(8, 360)
			Me.checkedButtonLabel.Name = "checkedButtonLabel"
			Me.checkedButtonLabel.Size = New System.Drawing.Size(504, 23)
			Me.checkedButtonLabel.TabIndex = 4
			' 
			' NQ1TaskDialogFeaturesUC
			' 
			Me.Controls.Add(Me.checkedButtonLabel)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.showBtn)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NQ1TaskDialogFeaturesUC"
			Me.Size = New System.Drawing.Size(520, 392)
			Me.nGroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_arrButtons As ArrayList

		Private buttonProperties As System.Windows.Forms.PropertyGrid
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents addBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents buttonsList As Nevron.UI.WinForm.Controls.NListBox
		Private WithEvents removeBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents showBtn As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private checkedButtonLabel As System.Windows.Forms.Label
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
