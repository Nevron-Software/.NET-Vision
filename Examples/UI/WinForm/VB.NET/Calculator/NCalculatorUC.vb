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
	''' Summary description for NCalculatorUC.
	''' </summary>
	Public Class NCalculatorUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
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


		#End Region

		#Region "Event Handlers"

		Private Sub digitGroupCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles digitGroupCheck.CheckedChanged
			nCalculator1.DigitGroupSeparator = digitGroupCheck.Checked
			nCalculator2.DigitGroupSeparator = digitGroupCheck.Checked
		End Sub
		Private Sub showDisplayCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles showDisplayCheck.CheckedChanged
			nCalculator1.ShowDisplay = showDisplayCheck.Checked
			nCalculator2.ShowDisplay = showDisplayCheck.Checked
		End Sub
		Private Sub buttonFontBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonFontBtn.Click
			Dim dlg As FontDialog = New FontDialog()
			dlg.Font = nCalculator1.ButtonFont

			If dlg.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			nCalculator1.ButtonFont = dlg.Font
			nCalculator2.ButtonFont = dlg.Font
		End Sub
		Private Sub nButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nButton1.Click
			nCalculator1.ButtonFont = Nothing
			nCalculator2.ButtonFont = Nothing
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nCalculator1 = New Nevron.UI.WinForm.Controls.NCalculator()
			Me.nCalculator2 = New Nevron.UI.WinForm.Controls.NCalculator()
			Me.calcInstancesGroup = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.buttonFontBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.digitGroupCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.showDisplayCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			CType(Me.nCalculator1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nCalculator2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.calcInstancesGroup.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nCalculator1
			' 
			Me.nCalculator1.Location = New System.Drawing.Point(8, 16)
			Me.nCalculator1.Name = "nCalculator1"
			Me.nCalculator1.Size = New System.Drawing.Size(245, 213)
			Me.nCalculator1.TabIndex = 0
			Me.nCalculator1.Text = "nCalculator1"
			' 
			' nCalculator2
			' 
			Me.nCalculator2.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(204)))
			Me.nCalculator2.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(153)), (CByte(102)))
			Me.nCalculator2.Location = New System.Drawing.Point(264, 16)
			Me.nCalculator2.Name = "nCalculator2"
            Me.nCalculator2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus
			Me.nCalculator2.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua
			Me.nCalculator2.Palette.ControlBorder = System.Drawing.Color.FromArgb((CByte(255)), (CByte(102)), (CByte(0)))
			Me.nCalculator2.Palette.ControlDark = System.Drawing.Color.FromArgb((CByte(255)), (CByte(153)), (CByte(102)))
			Me.nCalculator2.Palette.ControlLight = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(153)))
			Me.nCalculator2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nCalculator2.Size = New System.Drawing.Size(243, 213)
			Me.nCalculator2.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(255)), (CByte(102)), (CByte(0)))
			Me.nCalculator2.StrokeInfo.PenWidth = 3
			Me.nCalculator2.StrokeInfo.Rounding = 5
			Me.nCalculator2.TabIndex = 1
			Me.nCalculator2.Text = "nCalculator2"
			' 
			' calcInstancesGroup
			' 
			Me.calcInstancesGroup.Controls.Add(Me.nCalculator1)
			Me.calcInstancesGroup.Controls.Add(Me.nCalculator2)
			Me.calcInstancesGroup.ImageIndex = 0
			Me.calcInstancesGroup.Location = New System.Drawing.Point(8, 8)
			Me.calcInstancesGroup.Name = "calcInstancesGroup"
			Me.calcInstancesGroup.Size = New System.Drawing.Size(512, 232)
			Me.calcInstancesGroup.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.calcInstancesGroup.TabIndex = 2
			Me.calcInstancesGroup.TabStop = False
			Me.calcInstancesGroup.Text = "Calculator Instances"
			' 
			' buttonFontBtn
			' 
			Me.buttonFontBtn.Location = New System.Drawing.Point(8, 312)
			Me.buttonFontBtn.Name = "buttonFontBtn"
			Me.buttonFontBtn.Size = New System.Drawing.Size(88, 24)
			Me.buttonFontBtn.TabIndex = 3
			Me.buttonFontBtn.Text = "Button Font..."
'			Me.buttonFontBtn.Click += New System.EventHandler(Me.buttonFontBtn_Click);
			' 
			' digitGroupCheck
			' 
			Me.digitGroupCheck.ButtonProperties.BorderOffset = 2
			Me.digitGroupCheck.Checked = True
			Me.digitGroupCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.digitGroupCheck.Location = New System.Drawing.Point(8, 256)
			Me.digitGroupCheck.Name = "digitGroupCheck"
			Me.digitGroupCheck.Size = New System.Drawing.Size(192, 24)
			Me.digitGroupCheck.TabIndex = 4
			Me.digitGroupCheck.Text = "Digit Group Separator"
'			Me.digitGroupCheck.CheckedChanged += New System.EventHandler(Me.digitGroupCheck_CheckedChanged);
			' 
			' showDisplayCheck
			' 
			Me.showDisplayCheck.ButtonProperties.BorderOffset = 2
			Me.showDisplayCheck.Checked = True
			Me.showDisplayCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.showDisplayCheck.Location = New System.Drawing.Point(8, 280)
			Me.showDisplayCheck.Name = "showDisplayCheck"
			Me.showDisplayCheck.Size = New System.Drawing.Size(192, 24)
			Me.showDisplayCheck.TabIndex = 5
			Me.showDisplayCheck.Text = "Show Display"
'			Me.showDisplayCheck.CheckedChanged += New System.EventHandler(Me.showDisplayCheck_CheckedChanged);
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(104, 312)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.Size = New System.Drawing.Size(104, 24)
			Me.nButton1.TabIndex = 6
			Me.nButton1.Text = "Reset Button Font"
'			Me.nButton1.Click += New System.EventHandler(Me.nButton1_Click);
			' 
			' NCalculatorUC
			' 
			Me.Controls.Add(Me.nButton1)
			Me.Controls.Add(Me.showDisplayCheck)
			Me.Controls.Add(Me.digitGroupCheck)
			Me.Controls.Add(Me.buttonFontBtn)
			Me.Controls.Add(Me.calcInstancesGroup)
			Me.Name = "NCalculatorUC"
			Me.Size = New System.Drawing.Size(528, 344)
			CType(Me.nCalculator1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nCalculator2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.calcInstancesGroup.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nCalculator1 As Nevron.UI.WinForm.Controls.NCalculator
		Private nCalculator2 As Nevron.UI.WinForm.Controls.NCalculator
		Private calcInstancesGroup As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents buttonFontBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents digitGroupCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents showDisplayCheck As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
