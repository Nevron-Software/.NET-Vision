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
	''' Summary description for NFormUC.
	''' </summary>
	Public Class NFormUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
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

			m_CustomAppearance = New NFrameAppearance()
			m_Properties.SelectedObject = m_CustomAppearance

			m_PredefinedFrameCombo.FillFromEnum(GetType(PredefinedFrame))
			m_PredefinedFrameCombo.SelectedIndex = 0
		End Sub


		#End Region

		#Region "Implementation"
		#End Region

		#Region "Event Handlers"

		Private Sub m_ShowFormButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowFormButton.Click
			Dim appearance As NFrameAppearance

			If m_PredefinedRadio.Checked Then
				appearance = NUIManager.GetPredefinedFrame(CType(m_PredefinedFrameCombo.SelectedItem, PredefinedFrame))
			Else
				appearance = m_CustomAppearance
			End If

			Dim form As NForm = New NForm()
			form.UseGlassIfEnabled = CommonTriState.False
			form.EnableSkinning = False
			form.Palette.Copy(NUIManager.Palette)
			form.Text = "Custom Form Example"
			form.FrameAppearance = appearance
			form.ShowCaptionImage = True
			form.StartPosition = FormStartPosition.CenterParent
			form.ShowDialog()
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.m_PredefinedFrameCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_ShowFormButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_Properties = New System.Windows.Forms.PropertyGrid()
			Me.m_PredefinedRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nLineControl1 = New Nevron.UI.WinForm.Controls.NLineControl()
			Me.nLineControl2 = New Nevron.UI.WinForm.Controls.NLineControl()
			Me.m_CustomRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nLineControl3 = New Nevron.UI.WinForm.Controls.NLineControl()
			Me.SuspendLayout()
			' 
			' m_PredefinedFrameCombo
			' 
			Me.m_PredefinedFrameCombo.Location = New System.Drawing.Point(96, 32)
			Me.m_PredefinedFrameCombo.Name = "m_PredefinedFrameCombo"
			Me.m_PredefinedFrameCombo.Size = New System.Drawing.Size(216, 22)
			Me.m_PredefinedFrameCombo.TabIndex = 0
			Me.m_PredefinedFrameCombo.Text = "nComboBox1"
			' 
			' m_ShowFormButton
			' 
			Me.m_ShowFormButton.Location = New System.Drawing.Point(352, 448)
			Me.m_ShowFormButton.Name = "m_ShowFormButton"
			Me.m_ShowFormButton.Size = New System.Drawing.Size(104, 23)
			Me.m_ShowFormButton.TabIndex = 3
			Me.m_ShowFormButton.Text = "Show Form..."
'			Me.m_ShowFormButton.Click += New System.EventHandler(Me.m_ShowFormButton_Click);
			' 
			' m_Properties
			' 
			Me.m_Properties.CommandsVisibleIfAvailable = True
			Me.m_Properties.Cursor = System.Windows.Forms.Cursors.HSplit
			Me.m_Properties.LargeButtons = False
			Me.m_Properties.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.m_Properties.Location = New System.Drawing.Point(96, 104)
			Me.m_Properties.Name = "m_Properties"
			Me.m_Properties.Size = New System.Drawing.Size(360, 312)
			Me.m_Properties.TabIndex = 0
			Me.m_Properties.Text = "propertyGrid1"
			Me.m_Properties.ToolbarVisible = False
			Me.m_Properties.ViewBackColor = System.Drawing.SystemColors.Window
			Me.m_Properties.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' m_PredefinedRadio
			' 
			Me.m_PredefinedRadio.Checked = True
			Me.m_PredefinedRadio.Location = New System.Drawing.Point(8, 8)
			Me.m_PredefinedRadio.Name = "m_PredefinedRadio"
			Me.m_PredefinedRadio.Size = New System.Drawing.Size(80, 24)
			Me.m_PredefinedRadio.TabIndex = 4
			Me.m_PredefinedRadio.TabStop = True
			Me.m_PredefinedRadio.Text = "Predefined"
			' 
			' nLineControl1
			' 
			Me.nLineControl1.Location = New System.Drawing.Point(96, 16)
			Me.nLineControl1.Name = "nLineControl1"
			Me.nLineControl1.Size = New System.Drawing.Size(360, 2)
			Me.nLineControl1.Text = "nLineControl1"
			' 
			' nLineControl2
			' 
			Me.nLineControl2.Location = New System.Drawing.Point(96, 88)
			Me.nLineControl2.Name = "nLineControl2"
			Me.nLineControl2.Size = New System.Drawing.Size(360, 2)
			Me.nLineControl2.Text = "nLineControl2"
			' 
			' m_CustomRadio
			' 
			Me.m_CustomRadio.Location = New System.Drawing.Point(8, 80)
			Me.m_CustomRadio.Name = "m_CustomRadio"
			Me.m_CustomRadio.Size = New System.Drawing.Size(80, 24)
			Me.m_CustomRadio.TabIndex = 7
			Me.m_CustomRadio.Text = "Custom"
			' 
			' nLineControl3
			' 
			Me.nLineControl3.Location = New System.Drawing.Point(96, 432)
			Me.nLineControl3.Name = "nLineControl3"
			Me.nLineControl3.Size = New System.Drawing.Size(360, 2)
			Me.nLineControl3.Text = "nLineControl3"
			' 
			' NFormUC
			' 
			Me.Controls.Add(Me.nLineControl3)
			Me.Controls.Add(Me.nLineControl2)
			Me.Controls.Add(Me.m_CustomRadio)
			Me.Controls.Add(Me.nLineControl1)
			Me.Controls.Add(Me.m_PredefinedRadio)
			Me.Controls.Add(Me.m_Properties)
			Me.Controls.Add(Me.m_ShowFormButton)
			Me.Controls.Add(Me.m_PredefinedFrameCombo)
			Me.Name = "NFormUC"
			Me.Size = New System.Drawing.Size(472, 480)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_CustomAppearance As NFrameAppearance

		Private components As System.ComponentModel.Container = Nothing

		Private m_PredefinedFrameCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_ShowFormButton As Nevron.UI.WinForm.Controls.NButton
		Private m_Properties As System.Windows.Forms.PropertyGrid
		Private nLineControl1 As Nevron.UI.WinForm.Controls.NLineControl
		Private nLineControl2 As Nevron.UI.WinForm.Controls.NLineControl
		Private m_PredefinedRadio As Nevron.UI.WinForm.Controls.NRadioButton
		Private m_CustomRadio As Nevron.UI.WinForm.Controls.NRadioButton
		Private nLineControl3 As Nevron.UI.WinForm.Controls.NLineControl

		#End Region
	End Class
End Namespace
