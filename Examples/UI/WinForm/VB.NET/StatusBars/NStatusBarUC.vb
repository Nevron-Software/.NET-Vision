Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NStatusBarUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			m_StatusBar = New NStatusBar()
			m_StatusBar.ImageList = MainForm.TestImages

			InitializeComponent()
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

			Dock = DockStyle.Fill

			m_SeparatorsCheck.Checked = m_StatusBar.Separators

			Controls.Add(m_StatusBar)

			m_ControlCombo.Items.Add("(none)")
			m_ControlCombo.Items.Add("TextBox")
			m_ControlCombo.Items.Add("ComboBox")
			m_ControlCombo.Items.Add("Button")
			m_ControlCombo.Items.Add("NumericUpDown")
			m_ControlCombo.Items.Add("CheckBox")
			m_ControlCombo.Items.Add("RadioButton")
			m_ControlCombo.Items.Add("ProgressBar")

			m_BackColorButton.Color = m_StatusBar.BackColor
			m_ForeColorButton.Color = m_StatusBar.Palette.ControlText

			'populate autosize combobox
			m_AutoSizeCombo.FillFromEnum(GetType(StatusBarPanelAutoSize), False)
			m_AutoSizeCombo.SelectedIndex = 0

			'populate alignment combobox
			m_AlignmentCombo.FillFromEnum(GetType(HorizontalAlignment), False)
			m_AlignmentCombo.SelectedIndex = 0

			'populate borderstyle combobox
			m_BorderStyleCombo.FillFromEnum(GetType(BorderStyle3D), False)
			m_BorderStyleCombo.SelectedItem = BorderStyle3D.Flat

			'populate gripperstyle combobox
			m_GripperStyleCombo.FillFromEnum(GetType(GripperStyle), False)
			m_GripperStyleCombo.SelectedItem = m_StatusBar.GripperStyle

			'populate imageindex combobox
			Dim item As NListBoxItem

			item = New NListBoxItem(-1, "(none)", False)
			m_ImageIndexCombo.Items.Add(item)
			m_ImageIndexCombo.ImageList = MainForm.TestImages

			Dim i As Integer = 0
			Do While i < MainForm.TestImages.Images.Count
				item = New NListBoxItem(i, i.ToString(), False)
				m_ImageIndexCombo.Items.Add(item)
				i += 1
			Loop
		End Sub

		Friend Function GetControl() As Control
			Select Case m_ControlCombo.SelectedIndex
				Case 0
					Return Nothing
				Case 1
					Dim tb As NTextBox = New NTextBox()
					tb.Text = "NTextBox"
					Return tb
				Case 2
					Dim cb As NComboBox = New NComboBox()
					cb.ImageList = MainForm.TestImages
					For i As Integer = 0 To 19
						cb.Items.Add(New NListBoxItem(i, "Item " & (i+1), False))
					Next i
					Return cb
				Case 3
					Dim b As NButton = New NButton()
					b.Text = "Test Button"
					Return b
				Case 4
					Dim ud As NNumericUpDown = New NNumericUpDown()
					Return ud
				Case 5
					Dim chb As NCheckBox = New NCheckBox()
					chb.Text = "NCheckBox"
					chb.TransparentBackground = True
					Return chb
				Case 6
					Dim rb As NRadioButton = New NRadioButton()
					rb.Text = "NRadioButton"
					rb.TransparentBackground = True
					Return rb
				Case 7
					Dim bar As NProgressBar = New NProgressBar()
					bar.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
					bar.Properties.Value = 60
					Return bar
			End Select

			Return Nothing
		End Function


		#End Region

		#Region "Event Handlers"

		Private Sub m_AddButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AddButton.Click
			Dim panel As NStatusBarPanel = New NStatusBarPanel(m_PanelTextEdit.Text, m_ImageIndexCombo.SelectedIndex - 1)

			panel.AutoSize = CType(m_AutoSizeCombo.SelectedItem, StatusBarPanelAutoSize)
			panel.Alignment = CType(m_AlignmentCombo.SelectedItem, HorizontalAlignment)
			panel.BorderStyle = CType(m_BorderStyleCombo.SelectedItem, BorderStyle3D)

			If m_BackColorButton.Enabled Then
				panel.BackColor = m_BackColorButton.Color
			End If
			If m_ForeColorButton.Enabled Then
				panel.ForeColor = m_ForeColorButton.Color
			End If

			Dim c As Control = GetControl()
			If TypeOf c Is NProgressBar Then
				panel.Padding = New NPadding(2)
			End If

			panel.Control = c

			m_StatusBar.Panels.Add(panel)
		End Sub
		Private Sub m_RemoveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_RemoveButton.Click
			m_StatusBar.Panels.Clear()
		End Sub
		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			Me.m_StatusBar.SizingGrip = nCheckBox1.Checked
		End Sub

		Private Sub m_UseDefBackColor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_UseDefBackColor.CheckedChanged
			m_BackColorButton.Enabled = Not m_UseDefBackColor.Checked
		End Sub
		Private Sub m_UseDefForeColor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_UseDefForeColor.CheckedChanged
			m_ForeColorButton.Enabled = Not m_UseDefForeColor.Checked
		End Sub

		Private Sub m_SeparatorsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_SeparatorsCheck.CheckedChanged
			m_StatusBar.Separators = m_SeparatorsCheck.Checked
		End Sub

		Private Sub m_GripperStyleCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_GripperStyleCombo.SelectedIndexChanged
			m_StatusBar.GripperStyle = CType(m_GripperStyleCombo.SelectedItem, GripperStyle)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_AddButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_PanelTextEdit = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_AutoSizeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_AlignmentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_BorderStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.m_ImageIndexCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.m_RemoveButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ControlCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_BackColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.m_ForeColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.m_UseDefBackColor = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_UseDefForeColor = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_SeparatorsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_GripperStyleCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label9 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' m_AddButton
			' 
			Me.m_AddButton.Location = New System.Drawing.Point(216, 320)
			Me.m_AddButton.Name = "m_AddButton"
			Me.m_AddButton.Size = New System.Drawing.Size(72, 23)
			Me.m_AddButton.TabIndex = 0
			Me.m_AddButton.Text = "Add &Panel"
'			Me.m_AddButton.Click += New System.EventHandler(Me.m_AddButton_Click);
			' 
			' m_PanelTextEdit
			' 
			Me.m_PanelTextEdit.Location = New System.Drawing.Point(104, 8)
			Me.m_PanelTextEdit.Name = "m_PanelTextEdit"
			Me.m_PanelTextEdit.Size = New System.Drawing.Size(176, 18)
			Me.m_PanelTextEdit.TabIndex = 1
			Me.m_PanelTextEdit.Text = "Example"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(88, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Panel Text:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 40)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(88, 23)
			Me.label2.TabIndex = 3
			Me.label2.Text = "AutoSize:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_AutoSizeCombo
			' 
			Me.m_AutoSizeCombo.Location = New System.Drawing.Point(104, 40)
			Me.m_AutoSizeCombo.Name = "m_AutoSizeCombo"
			Me.m_AutoSizeCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_AutoSizeCombo.TabIndex = 4
			Me.m_AutoSizeCombo.Text = "nComboBox1"
			' 
			' m_AlignmentCombo
			' 
			Me.m_AlignmentCombo.Location = New System.Drawing.Point(104, 72)
			Me.m_AlignmentCombo.Name = "m_AlignmentCombo"
			Me.m_AlignmentCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_AlignmentCombo.TabIndex = 6
			Me.m_AlignmentCombo.Text = "nComboBox1"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 72)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(88, 23)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Alignment:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_BorderStyleCombo
			' 
			Me.m_BorderStyleCombo.Location = New System.Drawing.Point(104, 104)
			Me.m_BorderStyleCombo.Name = "m_BorderStyleCombo"
			Me.m_BorderStyleCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_BorderStyleCombo.TabIndex = 8
			Me.m_BorderStyleCombo.Text = "nComboBox1"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 104)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(88, 23)
			Me.label4.TabIndex = 7
			Me.label4.Text = "Border Style:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_ImageIndexCombo
			' 
			Me.m_ImageIndexCombo.Location = New System.Drawing.Point(104, 136)
			Me.m_ImageIndexCombo.Name = "m_ImageIndexCombo"
			Me.m_ImageIndexCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_ImageIndexCombo.TabIndex = 10
			Me.m_ImageIndexCombo.Text = "nComboBox1"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 136)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(88, 23)
			Me.label5.TabIndex = 9
			Me.label5.Text = "Image Index:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_RemoveButton
			' 
			Me.m_RemoveButton.Location = New System.Drawing.Point(296, 320)
			Me.m_RemoveButton.Name = "m_RemoveButton"
			Me.m_RemoveButton.Size = New System.Drawing.Size(72, 23)
			Me.m_RemoveButton.TabIndex = 11
			Me.m_RemoveButton.Text = "Remove &All"
'			Me.m_RemoveButton.Click += New System.EventHandler(Me.m_RemoveButton_Click);
			' 
			' m_ControlCombo
			' 
			Me.m_ControlCombo.Location = New System.Drawing.Point(104, 168)
			Me.m_ControlCombo.Name = "m_ControlCombo"
			Me.m_ControlCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_ControlCombo.TabIndex = 13
			Me.m_ControlCombo.Text = "nComboBox1"
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(8, 168)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(88, 23)
			Me.label6.TabIndex = 12
			Me.label6.Text = "Control:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(104, 296)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.TabIndex = 14
			Me.nCheckBox1.Text = "Sizing Grip"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' m_BackColorButton
			' 
			Me.m_BackColorButton.ArrowClickOptions = False
			Me.m_BackColorButton.Enabled = False
			Me.m_BackColorButton.Location = New System.Drawing.Point(104, 200)
			Me.m_BackColorButton.Name = "m_BackColorButton"
			Me.m_BackColorButton.TabIndex = 15
			' 
			' label7
			' 
			Me.label7.Location = New System.Drawing.Point(8, 200)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(88, 23)
			Me.label7.TabIndex = 16
			Me.label7.Text = "BackColor:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 232)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(88, 23)
			Me.label8.TabIndex = 18
			Me.label8.Text = "ForeColor:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_ForeColorButton
			' 
			Me.m_ForeColorButton.ArrowClickOptions = False
			Me.m_ForeColorButton.Enabled = False
			Me.m_ForeColorButton.Location = New System.Drawing.Point(104, 232)
			Me.m_ForeColorButton.Name = "m_ForeColorButton"
			Me.m_ForeColorButton.TabIndex = 17
			' 
			' m_UseDefBackColor
			' 
			Me.m_UseDefBackColor.Checked = True
			Me.m_UseDefBackColor.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_UseDefBackColor.Location = New System.Drawing.Point(184, 200)
			Me.m_UseDefBackColor.Name = "m_UseDefBackColor"
			Me.m_UseDefBackColor.TabIndex = 19
			Me.m_UseDefBackColor.Text = "Use Default"
'			Me.m_UseDefBackColor.CheckedChanged += New System.EventHandler(Me.m_UseDefBackColor_CheckedChanged);
			' 
			' m_UseDefForeColor
			' 
			Me.m_UseDefForeColor.Checked = True
			Me.m_UseDefForeColor.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_UseDefForeColor.Location = New System.Drawing.Point(184, 232)
			Me.m_UseDefForeColor.Name = "m_UseDefForeColor"
			Me.m_UseDefForeColor.TabIndex = 20
			Me.m_UseDefForeColor.Text = "Use Default"
'			Me.m_UseDefForeColor.CheckedChanged += New System.EventHandler(Me.m_UseDefForeColor_CheckedChanged);
			' 
			' m_SeparatorsCheck
			' 
			Me.m_SeparatorsCheck.Checked = True
			Me.m_SeparatorsCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_SeparatorsCheck.Location = New System.Drawing.Point(104, 320)
			Me.m_SeparatorsCheck.Name = "m_SeparatorsCheck"
			Me.m_SeparatorsCheck.TabIndex = 21
			Me.m_SeparatorsCheck.Text = "Separators"
'			Me.m_SeparatorsCheck.CheckedChanged += New System.EventHandler(Me.m_SeparatorsCheck_CheckedChanged);
			' 
			' m_GripperStyleCombo
			' 
			Me.m_GripperStyleCombo.Location = New System.Drawing.Point(104, 264)
			Me.m_GripperStyleCombo.Name = "m_GripperStyleCombo"
			Me.m_GripperStyleCombo.Size = New System.Drawing.Size(152, 22)
			Me.m_GripperStyleCombo.TabIndex = 25
			Me.m_GripperStyleCombo.Text = "nComboBox1"
'			Me.m_GripperStyleCombo.SelectedIndexChanged += New System.EventHandler(Me.m_GripperStyleCombo_SelectedIndexChanged);
			' 
			' label9
			' 
			Me.label9.Location = New System.Drawing.Point(8, 264)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(88, 23)
			Me.label9.TabIndex = 24
			Me.label9.Text = "Gripper Style:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' NStatusBarUC
			' 
			Me.Controls.Add(Me.m_GripperStyleCombo)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.m_SeparatorsCheck)
			Me.Controls.Add(Me.m_UseDefForeColor)
			Me.Controls.Add(Me.m_UseDefBackColor)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.m_ForeColorButton)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.m_BackColorButton)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.m_ControlCombo)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.m_RemoveButton)
			Me.Controls.Add(Me.m_ImageIndexCombo)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.m_BorderStyleCombo)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.m_AlignmentCombo)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.m_AutoSizeCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_PanelTextEdit)
			Me.Controls.Add(Me.m_AddButton)
			Me.Name = "NStatusBarUC"
			Me.Size = New System.Drawing.Size(384, 352)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Friend m_StatusBar As NStatusBar

		Private WithEvents m_AddButton As Nevron.UI.WinForm.Controls.NButton
		Private m_PanelTextEdit As Nevron.UI.WinForm.Controls.NTextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private m_AutoSizeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private m_AlignmentCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label3 As System.Windows.Forms.Label
		Private m_BorderStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label4 As System.Windows.Forms.Label
		Private m_ImageIndexCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label5 As System.Windows.Forms.Label
		Private m_ControlCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label6 As System.Windows.Forms.Label
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_BackColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private m_ForeColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private WithEvents m_UseDefBackColor As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_UseDefForeColor As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_SeparatorsCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_GripperStyleCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label9 As System.Windows.Forms.Label
		Private WithEvents m_RemoveButton As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace
