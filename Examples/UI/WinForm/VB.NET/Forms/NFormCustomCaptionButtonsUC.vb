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
	''' <summary>
	''' Summary description for NFormCustomCaptionButtonsUC.
	''' </summary>
	Public Class NFormCustomCaptionButtonsUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			m_arrButtons = New ArrayList()

			m_GlyphCombo.FillFromEnum(GetType(CommonGlyphs))
			m_GlyphCombo.SelectedIndex = 0
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


		#End Region

		#Region "Event Handlers"

		Private Sub m_AddButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AddButton.Click
			Dim button As NFrameCaptionButton = New NFrameCaptionButton()
			button.Glyph = CType(m_GlyphCombo.SelectedItem, CommonGlyphs)
			button.GlyphSize = New Size(CInt(Fix(m_GlyphWidthNumeric.Value)), CInt(Fix(m_GlyphHeightNumeric.Value)))
			m_arrButtons.Add(button)
		End Sub
		Private Sub m_ShowFormButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowFormButton.Click
			Dim f As NForm = New NForm()
			f.FrameAppearance = NUIManager.GetPredefinedFrame(PredefinedFrame.Simple)
			f.StartPosition = FormStartPosition.CenterParent
			f.Text = "Custom Caption Buttons"
			f.Palette.Copy(NUIManager.Palette)
			AddHandler f.CaptionButtonClicked, AddressOf f_CaptionButtonClicked

			For Each button As NFrameCaptionButton In m_arrButtons
				f.CustomButtons.Add(button)
			Next button

			f.ShowDialog()
		End Sub
		Private Sub m_ClearButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ClearButton.Click
			m_arrButtons.Clear()
		End Sub
		Private Sub f_CaptionButtonClicked(ByVal sender As Object, ByVal e As NUIItemEventArgs)
			'MessageBox.Show("Caption button clicked...");
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_GlyphCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_GlyphWidthNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_GlyphHeightNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_AddButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ShowFormButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ClearButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBox1.SuspendLayout()
			CType(Me.m_GlyphWidthNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_GlyphHeightNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' m_GlyphCombo
			' 
			Me.m_GlyphCombo.Location = New System.Drawing.Point(72, 24)
			Me.m_GlyphCombo.Name = "m_GlyphCombo"
			Me.m_GlyphCombo.Size = New System.Drawing.Size(128, 24)
			Me.m_GlyphCombo.TabIndex = 0
			Me.m_GlyphCombo.Text = "nComboBox1"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(56, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Style:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.m_GlyphHeightNumeric)
			Me.nGroupBox1.Controls.Add(Me.m_GlyphWidthNumeric)
			Me.nGroupBox1.Controls.Add(Me.label3)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.m_GlyphCombo)
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(224, 112)
			Me.nGroupBox1.TabIndex = 2
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Glyph"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Width:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 80)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(56, 23)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Height:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_GlyphWidthNumeric
			' 
			Me.m_GlyphWidthNumeric.Location = New System.Drawing.Point(72, 56)
			Me.m_GlyphWidthNumeric.Name = "m_GlyphWidthNumeric"
			Me.m_GlyphWidthNumeric.Size = New System.Drawing.Size(72, 20)
			Me.m_GlyphWidthNumeric.TabIndex = 4
			Me.m_GlyphWidthNumeric.Value = New System.Decimal(New Integer() { 8, 0, 0, 0})
			' 
			' m_GlyphHeightNumeric
			' 
			Me.m_GlyphHeightNumeric.Location = New System.Drawing.Point(72, 80)
			Me.m_GlyphHeightNumeric.Name = "m_GlyphHeightNumeric"
			Me.m_GlyphHeightNumeric.Size = New System.Drawing.Size(72, 20)
			Me.m_GlyphHeightNumeric.TabIndex = 5
			Me.m_GlyphHeightNumeric.Value = New System.Decimal(New Integer() { 8, 0, 0, 0})
			' 
			' m_AddButton
			' 
			Me.m_AddButton.Location = New System.Drawing.Point(144, 128)
			Me.m_AddButton.Name = "m_AddButton"
			Me.m_AddButton.Size = New System.Drawing.Size(88, 24)
			Me.m_AddButton.TabIndex = 3
			Me.m_AddButton.Text = "Add Button"
'			Me.m_AddButton.Click += New System.EventHandler(Me.m_AddButton_Click);
			' 
			' m_ShowFormButton
			' 
			Me.m_ShowFormButton.Location = New System.Drawing.Point(144, 192)
			Me.m_ShowFormButton.Name = "m_ShowFormButton"
			Me.m_ShowFormButton.Size = New System.Drawing.Size(88, 24)
			Me.m_ShowFormButton.TabIndex = 4
			Me.m_ShowFormButton.Text = "Show Form..."
'			Me.m_ShowFormButton.Click += New System.EventHandler(Me.m_ShowFormButton_Click);
			' 
			' m_ClearButton
			' 
			Me.m_ClearButton.Location = New System.Drawing.Point(144, 160)
			Me.m_ClearButton.Name = "m_ClearButton"
			Me.m_ClearButton.Size = New System.Drawing.Size(88, 24)
			Me.m_ClearButton.TabIndex = 5
			Me.m_ClearButton.Text = "Clear Buttons"
'			Me.m_ClearButton.Click += New System.EventHandler(Me.m_ClearButton_Click);
			' 
			' NFormCustomCaptionButtonsUC
			' 
			Me.Controls.Add(Me.m_ClearButton)
			Me.Controls.Add(Me.m_ShowFormButton)
			Me.Controls.Add(Me.m_AddButton)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Name = "NFormCustomCaptionButtonsUC"
			Me.Size = New System.Drawing.Size(256, 248)
			Me.nGroupBox1.ResumeLayout(False)
			CType(Me.m_GlyphWidthNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_GlyphHeightNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private m_GlyphCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private m_GlyphWidthNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private m_GlyphHeightNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents m_AddButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ShowFormButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ClearButton As Nevron.UI.WinForm.Controls.NButton

		Friend m_arrButtons As ArrayList

		#End Region
	End Class
End Namespace
