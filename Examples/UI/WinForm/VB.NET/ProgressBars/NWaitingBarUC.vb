Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NWaitingBarUC.
	''' </summary>
	Public Class NWaitingBarUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
			m_iSuspendUpdate = 0
		End Sub


		#End Region

		#Region "Implementation"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub
		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_iSuspendUpdate += 1

			m_StyleCombo.FillFromEnum(GetType(Nevron.UI.WinForm.Controls.ProgressBarStyle), False)
			m_StyleCombo.SelectedItem = Nevron.UI.WinForm.Controls.ProgressBarStyle.Solid

			m_OrientationCombo.FillFromEnum(GetType(Orientation), False)
			m_OrientationCombo.SelectedItem = Orientation.Horizontal
			nhScrollBar1.Value = 100 - nWaitingBar1.Properties.Interval

			m_WaitSizeNumeric.Value = nWaitingBar1.Properties.WaitSize
			m_StepNumeric.Value = nWaitingBar1.Properties.Step

			textEdit.Text = "Installing... Please, wait!"

			m_iSuspendUpdate -= 1

			Me.nWaitingBar1.BeginWait()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StyleCombo.SelectedIndexChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			Dim style As Nevron.UI.WinForm.Controls.ProgressBarStyle = CType(m_StyleCombo.SelectedItem, Nevron.UI.WinForm.Controls.ProgressBarStyle)
			nWaitingBar1.Properties.Style = style
		End Sub
		Private Sub m_OrientationCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_OrientationCombo.SelectedIndexChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			Dim orientation As Orientation = CType(m_OrientationCombo.SelectedItem, Orientation)
			nWaitingBar1.Properties.Orientation = orientation
		End Sub
		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			nWaitingBar1.Border.ShowEditor()
		End Sub
		Private Sub m_PaletteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_PaletteButton.Click
			nWaitingBar1.Palette.ShowEditor()
		End Sub
		Private Sub m_BeginWaitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BeginWaitButton.Click
			nWaitingBar1.BeginWait()
		End Sub
		Private Sub m_EndWaitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_EndWaitButton.Click
			nWaitingBar1.EndWait()
		End Sub

		Private Sub nhScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles nhScrollBar1.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			nWaitingBar1.Properties.Interval = 100 - nhScrollBar1.Value
		End Sub
		Private Sub m_WaitSizeNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_WaitSizeNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			nWaitingBar1.Properties.WaitSize = CInt(Fix(m_WaitSizeNumeric.Value))
		End Sub
		Private Sub m_IncrementButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_IncrementButton.Click
			nWaitingBar1.Properties.Position += 1
		End Sub
		Private Sub m_StepNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StepNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			nWaitingBar1.Properties.Step = CInt(Fix(m_StepNumeric.Value))
		End Sub

		Private Sub textEdit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textEdit.TextChanged
			nWaitingBar1.Properties.Text = textEdit.Text
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nWaitingBar1 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.label4 = New System.Windows.Forms.Label()
			Me.m_OrientationCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_PaletteButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_BeginWaitButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_EndWaitButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nhScrollBar1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_WaitSizeNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label5 = New System.Windows.Forms.Label()
			Me.m_StepNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_IncrementButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.textEdit = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label6 = New System.Windows.Forms.Label()
			CType(Me.m_WaitSizeNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_StepNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nWaitingBar1
			' 
			Me.nWaitingBar1.Location = New System.Drawing.Point(16, 16)
			Me.nWaitingBar1.Name = "nWaitingBar1"
			Me.nWaitingBar1.Size = New System.Drawing.Size(312, 24)
			Me.nWaitingBar1.TabIndex = 0
			Me.nWaitingBar1.Text = "nWaitingBar1"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(48, 144)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(88, 23)
			Me.label4.TabIndex = 35
			Me.label4.Text = "Orientation:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_OrientationCombo
			' 
			Me.m_OrientationCombo.Location = New System.Drawing.Point(144, 144)
			Me.m_OrientationCombo.Name = "m_OrientationCombo"
			Me.m_OrientationCombo.Size = New System.Drawing.Size(176, 22)
			Me.m_OrientationCombo.TabIndex = 34
			Me.m_OrientationCombo.Text = "nComboBox1"
'			Me.m_OrientationCombo.SelectedIndexChanged += New System.EventHandler(Me.m_OrientationCombo_SelectedIndexChanged);
			' 
			' m_PaletteButton
			' 
			Me.m_PaletteButton.Location = New System.Drawing.Point(232, 304)
			Me.m_PaletteButton.Name = "m_PaletteButton"
			Me.m_PaletteButton.TabIndex = 33
			Me.m_PaletteButton.Text = "Palette..."
'			Me.m_PaletteButton.Click += New System.EventHandler(Me.m_PaletteButton_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(48, 112)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(88, 23)
			Me.label2.TabIndex = 32
			Me.label2.Text = "Style:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_StyleCombo
			' 
			Me.m_StyleCombo.Location = New System.Drawing.Point(144, 112)
			Me.m_StyleCombo.Name = "m_StyleCombo"
			Me.m_StyleCombo.Size = New System.Drawing.Size(176, 22)
			Me.m_StyleCombo.TabIndex = 31
			Me.m_StyleCombo.Text = "nComboBox1"
'			Me.m_StyleCombo.SelectedIndexChanged += New System.EventHandler(Me.m_StyleCombo_SelectedIndexChanged);
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.Location = New System.Drawing.Point(144, 304)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.TabIndex = 30
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' m_BeginWaitButton
			' 
			Me.m_BeginWaitButton.Location = New System.Drawing.Point(336, 16)
			Me.m_BeginWaitButton.Name = "m_BeginWaitButton"
			Me.m_BeginWaitButton.TabIndex = 36
			Me.m_BeginWaitButton.Text = "Begin Wait"
'			Me.m_BeginWaitButton.Click += New System.EventHandler(Me.m_BeginWaitButton_Click);
			' 
			' m_EndWaitButton
			' 
			Me.m_EndWaitButton.Location = New System.Drawing.Point(336, 48)
			Me.m_EndWaitButton.Name = "m_EndWaitButton"
			Me.m_EndWaitButton.TabIndex = 37
			Me.m_EndWaitButton.Text = "End Wait"
'			Me.m_EndWaitButton.Click += New System.EventHandler(Me.m_EndWaitButton_Click);
			' 
			' nhScrollBar1
			' 
			Me.nhScrollBar1.Location = New System.Drawing.Point(144, 176)
			Me.nhScrollBar1.Name = "nhScrollBar1"
			Me.nhScrollBar1.Size = New System.Drawing.Size(176, 17)
			Me.nhScrollBar1.TabIndex = 38
			Me.nhScrollBar1.Text = "nhScrollBar1"
'			Me.nhScrollBar1.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.nhScrollBar1_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(72, 176)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 23)
			Me.label1.TabIndex = 39
			Me.label1.Text = "Speed:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(72, 240)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 23)
			Me.label3.TabIndex = 41
			Me.label3.Text = "Wait Size:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_WaitSizeNumeric
			' 
			Me.m_WaitSizeNumeric.Location = New System.Drawing.Point(144, 240)
			Me.m_WaitSizeNumeric.Name = "m_WaitSizeNumeric"
			Me.m_WaitSizeNumeric.Size = New System.Drawing.Size(72, 20)
			Me.m_WaitSizeNumeric.TabIndex = 40
'			Me.m_WaitSizeNumeric.ValueChanged += New System.EventHandler(Me.m_WaitSizeNumeric_ValueChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(72, 272)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(64, 23)
			Me.label5.TabIndex = 43
			Me.label5.Text = "Step:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_StepNumeric
			' 
			Me.m_StepNumeric.Location = New System.Drawing.Point(144, 272)
			Me.m_StepNumeric.Name = "m_StepNumeric"
			Me.m_StepNumeric.Size = New System.Drawing.Size(72, 20)
			Me.m_StepNumeric.TabIndex = 42
'			Me.m_StepNumeric.ValueChanged += New System.EventHandler(Me.m_StepNumeric_ValueChanged);
			' 
			' m_IncrementButton
			' 
			Me.m_IncrementButton.Location = New System.Drawing.Point(336, 80)
			Me.m_IncrementButton.Name = "m_IncrementButton"
			Me.m_IncrementButton.TabIndex = 44
			Me.m_IncrementButton.Text = "Increment"
'			Me.m_IncrementButton.Click += New System.EventHandler(Me.m_IncrementButton_Click);
			' 
			' textEdit
			' 
			Me.textEdit.Location = New System.Drawing.Point(144, 208)
			Me.textEdit.Name = "textEdit"
			Me.textEdit.Size = New System.Drawing.Size(176, 18)
			Me.textEdit.TabIndex = 45
'			Me.textEdit.TextChanged += New System.EventHandler(Me.textEdit_TextChanged);
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(72, 208)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(64, 23)
			Me.label6.TabIndex = 46
			Me.label6.Text = "Text:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' NWaitingBarUC
			' 
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.textEdit)
			Me.Controls.Add(Me.m_IncrementButton)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.m_StepNumeric)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_WaitSizeNumeric)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nhScrollBar1)
			Me.Controls.Add(Me.m_EndWaitButton)
			Me.Controls.Add(Me.m_BeginWaitButton)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.m_OrientationCombo)
			Me.Controls.Add(Me.m_PaletteButton)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.m_StyleCombo)
			Me.Controls.Add(Me.m_BorderButton)
			Me.Controls.Add(Me.nWaitingBar1)
			Me.Name = "NWaitingBarUC"
			Me.Size = New System.Drawing.Size(424, 336)
			CType(Me.m_WaitSizeNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_StepNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nWaitingBar1 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private label4 As System.Windows.Forms.Label
		Private WithEvents m_OrientationCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_PaletteButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private WithEvents m_StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_BeginWaitButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_EndWaitButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents nhScrollBar1 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private label1 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private WithEvents m_WaitSizeNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label5 As System.Windows.Forms.Label
		Private WithEvents m_StepNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents textEdit As Nevron.UI.WinForm.Controls.NTextBox
		Private label6 As System.Windows.Forms.Label
		Private WithEvents m_IncrementButton As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace
