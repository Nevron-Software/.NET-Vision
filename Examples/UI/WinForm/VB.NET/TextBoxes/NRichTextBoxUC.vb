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
	''' Summary description for NRichTextBoxUC.
	''' </summary>
	Public Class NRichTextBoxUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
		End Sub


		#End Region

		#Region "Overrides"

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

			nCheckBox1.Checked = richTextBox1.Enabled
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			richTextBox1.Enabled = nCheckBox1.Checked
		End Sub

		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			richTextBox1.Border.ShowEditor()
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.richTextBox1 = New Nevron.UI.WinForm.Controls.NRichTextBox()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' richTextBox1
			' 
			Me.richTextBox1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.richTextBox1.Location = New System.Drawing.Point(8, 8)
			Me.richTextBox1.Name = "richTextBox1"
			Me.richTextBox1.Size = New System.Drawing.Size(288, 208)
			Me.richTextBox1.TabIndex = 0
			Me.richTextBox1.Text = ""
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.m_BorderButton.Location = New System.Drawing.Point(88, 224)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.PaletteInheritance = (CType((Nevron.UI.WinForm.Controls.PaletteInheritance.ColorTable Or Nevron.UI.WinForm.Controls.PaletteInheritance.UseThemes), Nevron.UI.WinForm.Controls.PaletteInheritance))
			Me.m_BorderButton.Size = New System.Drawing.Size(104, 24)
			Me.m_BorderButton.TabIndex = 25
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 224)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(72, 24)
			Me.nCheckBox1.TabIndex = 24
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' NRichTextBoxUC
			' 
			Me.Controls.Add(Me.m_BorderButton)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.richTextBox1)
			Me.Name = "NRichTextBoxUC"
			Me.Size = New System.Drawing.Size(304, 256)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox

		Private richTextBox1 As NRichTextBox

		#End Region
	End Class
End Namespace
