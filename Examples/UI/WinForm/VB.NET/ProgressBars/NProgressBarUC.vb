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
	''' Summary description for NProgressBarUC.
	''' </summary>
	Public Class NProgressBarUC
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

			nProgressBar1.Properties.Value = 20

			m_StyleCombo.FillFromEnum(GetType(Nevron.UI.WinForm.Controls.ProgressBarStyle), False)
			m_StyleCombo.SelectedItem = Nevron.UI.WinForm.Controls.ProgressBarStyle.Solid

			m_OrientationCombo.FillFromEnum(GetType(Orientation), False)
			m_OrientationCombo.SelectedItem = Orientation.Horizontal

			m_ValueNumeric.Value = nProgressBar1.Properties.Value

			m_iSuspendUpdate -= 1
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_ValueNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ValueNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			nProgressBar1.Properties.Value = CInt(Fix(m_ValueNumeric.Value))
		End Sub
		Private Sub m_StyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StyleCombo.SelectedIndexChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			Dim style As Nevron.UI.WinForm.Controls.ProgressBarStyle = CType(m_StyleCombo.SelectedItem, Nevron.UI.WinForm.Controls.ProgressBarStyle)
			nProgressBar1.Properties.Style = style
		End Sub
		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			nProgressBar1.Border.ShowEditor()
		End Sub
		Private Sub m_SegmentsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_SegmentsCheck.CheckedChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			nProgressBar1.Properties.Segments = m_SegmentsCheck.Checked
		End Sub
		Private Sub m_SegmentStepNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_SegmentStepNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			nProgressBar1.Properties.SegmentStep = CInt(Fix(m_SegmentStepNumeric.Value))
		End Sub
		Private Sub m_PaletteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_PaletteButton.Click
			nProgressBar1.Palette.ShowEditor()
			nProgressBar1.Refresh()
		End Sub

		Private Sub m_OrientationCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_OrientationCombo.SelectedIndexChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			Dim orientation As Orientation = CType(m_OrientationCombo.SelectedItem, Orientation)
			nProgressBar1.Properties.Orientation = orientation
		End Sub

		Private Sub m_ShowTextCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowTextCheck.CheckedChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			nProgressBar1.Properties.ShowText = m_ShowTextCheck.Checked
		End Sub
		Private Sub m_TextEdit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_TextEdit.TextChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If
			nProgressBar1.Properties.Text = m_TextEdit.Text
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_StyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_ValueNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nProgressBar1 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_SegmentsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_SegmentStepNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_PaletteButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.m_OrientationCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_TextEdit = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.m_ShowTextCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.m_ValueNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_SegmentStepNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.Location = New System.Drawing.Point(136, 256)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.TabIndex = 0
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' m_StyleCombo
			' 
			Me.m_StyleCombo.Location = New System.Drawing.Point(136, 152)
			Me.m_StyleCombo.Name = "m_StyleCombo"
			Me.m_StyleCombo.Size = New System.Drawing.Size(176, 22)
			Me.m_StyleCombo.TabIndex = 1
			Me.m_StyleCombo.Text = "nComboBox1"
'			Me.m_StyleCombo.SelectedIndexChanged += New System.EventHandler(Me.m_StyleCombo_SelectedIndexChanged);
			' 
			' m_ValueNumeric
			' 
			Me.m_ValueNumeric.Location = New System.Drawing.Point(136, 64)
			Me.m_ValueNumeric.Name = "m_ValueNumeric"
			Me.m_ValueNumeric.Size = New System.Drawing.Size(72, 20)
			Me.m_ValueNumeric.TabIndex = 2
'			Me.m_ValueNumeric.ValueChanged += New System.EventHandler(Me.m_ValueNumeric_ValueChanged);
			' 
			' nProgressBar1
			' 
			Me.nProgressBar1.Location = New System.Drawing.Point(8, 8)
			Me.nProgressBar1.Name = "nProgressBar1"
			Me.nProgressBar1.Properties.Text = ""
			Me.nProgressBar1.Size = New System.Drawing.Size(280, 24)
			Me.nProgressBar1.TabIndex = 3
			Me.nProgressBar1.Text = "nProgressBar1"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(64, 64)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 23)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Value:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(64, 152)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 23)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Style:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_SegmentsCheck
			' 
			Me.m_SegmentsCheck.Location = New System.Drawing.Point(232, 216)
			Me.m_SegmentsCheck.Name = "m_SegmentsCheck"
			Me.m_SegmentsCheck.Size = New System.Drawing.Size(96, 24)
			Me.m_SegmentsCheck.TabIndex = 24
			Me.m_SegmentsCheck.Text = "Segments"
'			Me.m_SegmentsCheck.CheckedChanged += New System.EventHandler(Me.m_SegmentsCheck_CheckedChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(48, 88)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(80, 23)
			Me.label3.TabIndex = 26
			Me.label3.Text = "Segment Step:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_SegmentStepNumeric
			' 
			Me.m_SegmentStepNumeric.Location = New System.Drawing.Point(136, 88)
			Me.m_SegmentStepNumeric.Minimum = New System.Decimal(New Integer() { 4, 0, 0, 0})
			Me.m_SegmentStepNumeric.Name = "m_SegmentStepNumeric"
			Me.m_SegmentStepNumeric.Size = New System.Drawing.Size(72, 20)
			Me.m_SegmentStepNumeric.TabIndex = 25
			Me.m_SegmentStepNumeric.Value = New System.Decimal(New Integer() { 20, 0, 0, 0})
'			Me.m_SegmentStepNumeric.ValueChanged += New System.EventHandler(Me.m_SegmentStepNumeric_ValueChanged);
			' 
			' m_PaletteButton
			' 
			Me.m_PaletteButton.Location = New System.Drawing.Point(224, 256)
			Me.m_PaletteButton.Name = "m_PaletteButton"
			Me.m_PaletteButton.TabIndex = 27
			Me.m_PaletteButton.Text = "Palette..."
'			Me.m_PaletteButton.Click += New System.EventHandler(Me.m_PaletteButton_Click);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(64, 184)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 23)
			Me.label4.TabIndex = 29
			Me.label4.Text = "Orientation:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_OrientationCombo
			' 
			Me.m_OrientationCombo.Location = New System.Drawing.Point(136, 184)
			Me.m_OrientationCombo.Name = "m_OrientationCombo"
			Me.m_OrientationCombo.Size = New System.Drawing.Size(176, 22)
			Me.m_OrientationCombo.TabIndex = 28
			Me.m_OrientationCombo.Text = "nComboBox1"
'			Me.m_OrientationCombo.SelectedIndexChanged += New System.EventHandler(Me.m_OrientationCombo_SelectedIndexChanged);
			' 
			' m_TextEdit
			' 
			Me.m_TextEdit.Location = New System.Drawing.Point(136, 120)
			Me.m_TextEdit.Name = "m_TextEdit"
			Me.m_TextEdit.Size = New System.Drawing.Size(176, 20)
			Me.m_TextEdit.TabIndex = 30
			Me.m_TextEdit.Text = ""
'			Me.m_TextEdit.TextChanged += New System.EventHandler(Me.m_TextEdit_TextChanged);
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(48, 120)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(80, 23)
			Me.label5.TabIndex = 31
			Me.label5.Text = "Text:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_ShowTextCheck
			' 
			Me.m_ShowTextCheck.Location = New System.Drawing.Point(136, 216)
			Me.m_ShowTextCheck.Name = "m_ShowTextCheck"
			Me.m_ShowTextCheck.Size = New System.Drawing.Size(96, 24)
			Me.m_ShowTextCheck.TabIndex = 32
			Me.m_ShowTextCheck.Text = "Show Text"
'			Me.m_ShowTextCheck.CheckedChanged += New System.EventHandler(Me.m_ShowTextCheck_CheckedChanged);
			' 
			' NProgressBarUC
			' 
			Me.Controls.Add(Me.m_ShowTextCheck)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.m_TextEdit)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.m_OrientationCombo)
			Me.Controls.Add(Me.m_PaletteButton)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_SegmentStepNumeric)
			Me.Controls.Add(Me.m_SegmentsCheck)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nProgressBar1)
			Me.Controls.Add(Me.m_ValueNumeric)
			Me.Controls.Add(Me.m_StyleCombo)
			Me.Controls.Add(Me.m_BorderButton)
			Me.Name = "NProgressBarUC"
			Me.Size = New System.Drawing.Size(384, 296)
			CType(Me.m_ValueNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_SegmentStepNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nProgressBar1 As Nevron.UI.WinForm.Controls.NProgressBar
		Private WithEvents m_ValueNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_StyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents m_SegmentsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents m_SegmentStepNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents m_PaletteButton As Nevron.UI.WinForm.Controls.NButton
		Private label4 As System.Windows.Forms.Label
		Private WithEvents m_OrientationCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_TextEdit As Nevron.UI.WinForm.Controls.NTextBox
		Private label5 As System.Windows.Forms.Label
		Private WithEvents m_ShowTextCheck As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
