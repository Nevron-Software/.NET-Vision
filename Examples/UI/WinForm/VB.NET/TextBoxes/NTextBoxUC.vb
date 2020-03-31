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
	Public Class NTextBoxUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
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

			m_InputModeCombo.FillFromEnum(GetType(TextBoxInputMode), False)
			m_InputModeCombo.SelectedItem = TextBoxInputMode.Default

			m_ShowErrorMessage.Checked = False
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			For Each c As Control In Controls
				If TypeOf c Is NTextBox Then
					c.Enabled = Me.nCheckBox1.Checked
				End If
			Next c
		End Sub
		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		End Sub
		Private Sub nCheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		End Sub


		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			nTextBox1.Border.ShowEditor()
			nTextBox2.Border.Copy(nTextBox1.Border)
			nTextBox3.Border.Copy(nTextBox1.Border)
		End Sub

		Private Sub m_InputModeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_InputModeCombo.SelectedIndexChanged
			Dim tb As NTextBox
			Dim count As Integer = Controls.Count

			Dim i As Integer = 0
			Do While i < count
				tb = TryCast(Controls(i), NTextBox)
				If Not tb Is Nothing Then
					tb.InputMode = CType(m_InputModeCombo.SelectedItem, TextBoxInputMode)
				End If
				i += 1
			Loop
		End Sub

		Private Sub m_ShowErrorMessage_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowErrorMessage.CheckedChanged
			Dim tb As NTextBox
			Dim count As Integer = Controls.Count

			Dim i As Integer = 0
			Do While i < count
				tb = TryCast(Controls(i), NTextBox)
				If Not tb Is Nothing Then
					tb.DisplayErrorMessage = m_ShowErrorMessage.Checked
				End If
				i += 1
			Loop
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nTextBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nTextBox2 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_InputModeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nTextBox3 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.m_ShowErrorMessage = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' nTextBox1
			' 
			Me.nTextBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nTextBox1.Location = New System.Drawing.Point(8, 8)
			Me.nTextBox1.Name = "nTextBox1"
			Me.nTextBox1.Size = New System.Drawing.Size(320, 20)
			Me.nTextBox1.TabIndex = 0
			Me.nTextBox1.Text = ""
			' 
			' nTextBox2
			' 
			Me.nTextBox2.AcceptsReturn = True
			Me.nTextBox2.AcceptsTab = True
			Me.nTextBox2.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nTextBox2.Location = New System.Drawing.Point(8, 72)
			Me.nTextBox2.Multiline = True
			Me.nTextBox2.Name = "nTextBox2"
			Me.nTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.nTextBox2.Size = New System.Drawing.Size(320, 216)
			Me.nTextBox2.TabIndex = 1
			Me.nTextBox2.Text = "Multi-line text box. Right-click to see the custom context menu."
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 304)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(72, 24)
			Me.nCheckBox1.TabIndex = 22
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.m_BorderButton.Location = New System.Drawing.Point(184, 304)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.m_BorderButton.Size = New System.Drawing.Size(104, 24)
			Me.m_BorderButton.TabIndex = 23
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.Location = New System.Drawing.Point(8, 336)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 23)
			Me.label1.TabIndex = 25
			Me.label1.Text = "Input Mode:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_InputModeCombo
			' 
			Me.m_InputModeCombo.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_InputModeCombo.ListProperties.ColumnOnLeft = False
			Me.m_InputModeCombo.Location = New System.Drawing.Point(88, 336)
			Me.m_InputModeCombo.Name = "m_InputModeCombo"
			Me.m_InputModeCombo.Size = New System.Drawing.Size(200, 21)
			Me.m_InputModeCombo.TabIndex = 26
'			Me.m_InputModeCombo.SelectedIndexChanged += New System.EventHandler(Me.m_InputModeCombo_SelectedIndexChanged);
			' 
			' nTextBox3
			' 
			Me.nTextBox3.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nTextBox3.Location = New System.Drawing.Point(8, 40)
			Me.nTextBox3.Name = "nTextBox3"
			Me.nTextBox3.Size = New System.Drawing.Size(320, 20)
			Me.nTextBox3.TabIndex = 24
			Me.nTextBox3.Text = ""
			' 
			' m_ShowErrorMessage
			' 
			Me.m_ShowErrorMessage.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_ShowErrorMessage.Checked = True
			Me.m_ShowErrorMessage.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_ShowErrorMessage.Location = New System.Drawing.Point(80, 304)
			Me.m_ShowErrorMessage.Name = "m_ShowErrorMessage"
			Me.m_ShowErrorMessage.Size = New System.Drawing.Size(96, 24)
			Me.m_ShowErrorMessage.TabIndex = 27
			Me.m_ShowErrorMessage.Text = "Error Message"
'			Me.m_ShowErrorMessage.CheckedChanged += New System.EventHandler(Me.m_ShowErrorMessage_CheckedChanged);
			' 
			' NTextBoxUC
			' 
			Me.Controls.Add(Me.m_ShowErrorMessage)
			Me.Controls.Add(Me.m_InputModeCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nTextBox3)
			Me.Controls.Add(Me.m_BorderButton)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nTextBox2)
			Me.Controls.Add(Me.nTextBox1)
			Me.Name = "NTextBoxUC"
			Me.Size = New System.Drawing.Size(336, 368)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nTextBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private nTextBox2 As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents m_InputModeCombo As NComboBox
		Private nTextBox3 As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents m_ShowErrorMessage As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
