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
	Public Class NNumericUpDownUC
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


		#End Region

		#Region "Event Handlers"

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			For Each c As Control In Controls
				If TypeOf c Is NNumericUpDown Then
					c.Enabled = nCheckBox1.Checked
				End If
			Next c
		End Sub
		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		End Sub

		Private Sub m_CustomTextEdit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CustomTextEdit.TextChanged
			nNumericUpDown1.CustomText = m_CustomTextEdit.Text

			For Each c As Control In Controls
				If Not(TypeOf c Is NNumericUpDown) Then
					Continue For
				End If
				CType(c, NNumericUpDown).CustomText = m_CustomTextEdit.Text
			Next c
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nNumericUpDown1 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown2 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown3 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown4 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown5 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown6 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown7 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown8 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown9 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown10 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown13 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown11 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown12 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown14 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nNumericUpDown15 = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_CustomTextEdit = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown7, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown8, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown9, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown10, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown13, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown11, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown12, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown14, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nNumericUpDown15, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nNumericUpDown1
			' 
			Me.nNumericUpDown1.DecimalPlaces = 2
			Me.nNumericUpDown1.Increment = New Decimal(New Integer() { 5, 0, 0, 65536})
			Me.nNumericUpDown1.Location = New System.Drawing.Point(8, 8)
			Me.nNumericUpDown1.Name = "nNumericUpDown1"
			Me.nNumericUpDown1.Size = New System.Drawing.Size(120, 20)
			Me.nNumericUpDown1.TabIndex = 0
			' 
			' nNumericUpDown2
			' 
			Me.nNumericUpDown2.Location = New System.Drawing.Point(8, 32)
			Me.nNumericUpDown2.Name = "nNumericUpDown2"
			Me.nNumericUpDown2.Size = New System.Drawing.Size(120, 20)
			Me.nNumericUpDown2.TabIndex = 1
			' 
			' nNumericUpDown3
			' 
			Me.nNumericUpDown3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown3.Location = New System.Drawing.Point(8, 56)
			Me.nNumericUpDown3.Name = "nNumericUpDown3"
			Me.nNumericUpDown3.Size = New System.Drawing.Size(120, 26)
			Me.nNumericUpDown3.TabIndex = 2
			' 
			' nNumericUpDown4
			' 
			Me.nNumericUpDown4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown4.Location = New System.Drawing.Point(8, 88)
			Me.nNumericUpDown4.Name = "nNumericUpDown4"
			Me.nNumericUpDown4.Size = New System.Drawing.Size(120, 30)
			Me.nNumericUpDown4.TabIndex = 3
			' 
			' nNumericUpDown5
			' 
			Me.nNumericUpDown5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown5.Location = New System.Drawing.Point(8, 128)
			Me.nNumericUpDown5.Name = "nNumericUpDown5"
			Me.nNumericUpDown5.Size = New System.Drawing.Size(120, 44)
			Me.nNumericUpDown5.TabIndex = 4
			' 
			' nNumericUpDown6
			' 
			Me.nNumericUpDown6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown6.Location = New System.Drawing.Point(136, 128)
			Me.nNumericUpDown6.Name = "nNumericUpDown6"
			Me.nNumericUpDown6.Size = New System.Drawing.Size(120, 44)
			Me.nNumericUpDown6.TabIndex = 9
			Me.nNumericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			Me.nNumericUpDown6.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown7
			' 
			Me.nNumericUpDown7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown7.Location = New System.Drawing.Point(136, 88)
			Me.nNumericUpDown7.Name = "nNumericUpDown7"
			Me.nNumericUpDown7.Size = New System.Drawing.Size(120, 30)
			Me.nNumericUpDown7.TabIndex = 8
			Me.nNumericUpDown7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			Me.nNumericUpDown7.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown8
			' 
			Me.nNumericUpDown8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown8.Location = New System.Drawing.Point(136, 56)
			Me.nNumericUpDown8.Name = "nNumericUpDown8"
			Me.nNumericUpDown8.Size = New System.Drawing.Size(120, 26)
			Me.nNumericUpDown8.TabIndex = 7
			Me.nNumericUpDown8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			Me.nNumericUpDown8.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown9
			' 
			Me.nNumericUpDown9.Location = New System.Drawing.Point(136, 32)
			Me.nNumericUpDown9.Name = "nNumericUpDown9"
			Me.nNumericUpDown9.Size = New System.Drawing.Size(120, 20)
			Me.nNumericUpDown9.TabIndex = 6
			Me.nNumericUpDown9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			Me.nNumericUpDown9.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown10
			' 
			Me.nNumericUpDown10.Location = New System.Drawing.Point(136, 8)
			Me.nNumericUpDown10.Name = "nNumericUpDown10"
			Me.nNumericUpDown10.Size = New System.Drawing.Size(120, 20)
			Me.nNumericUpDown10.TabIndex = 5
			Me.nNumericUpDown10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			Me.nNumericUpDown10.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown13
			' 
			Me.nNumericUpDown13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown13.Location = New System.Drawing.Point(264, 56)
			Me.nNumericUpDown13.Name = "nNumericUpDown13"
			Me.nNumericUpDown13.Size = New System.Drawing.Size(120, 26)
			Me.nNumericUpDown13.TabIndex = 12
			Me.nNumericUpDown13.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown11
			' 
			Me.nNumericUpDown11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown11.Location = New System.Drawing.Point(264, 88)
			Me.nNumericUpDown11.Name = "nNumericUpDown11"
			Me.nNumericUpDown11.Size = New System.Drawing.Size(120, 30)
			Me.nNumericUpDown11.TabIndex = 13
			Me.nNumericUpDown11.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown12
			' 
			Me.nNumericUpDown12.Font = New System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nNumericUpDown12.Location = New System.Drawing.Point(264, 128)
			Me.nNumericUpDown12.Name = "nNumericUpDown12"
			Me.nNumericUpDown12.Size = New System.Drawing.Size(120, 44)
			Me.nNumericUpDown12.TabIndex = 14
			Me.nNumericUpDown12.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown14
			' 
			Me.nNumericUpDown14.Location = New System.Drawing.Point(264, 32)
			Me.nNumericUpDown14.Name = "nNumericUpDown14"
			Me.nNumericUpDown14.Size = New System.Drawing.Size(120, 20)
			Me.nNumericUpDown14.TabIndex = 18
			Me.nNumericUpDown14.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nNumericUpDown15
			' 
			Me.nNumericUpDown15.Location = New System.Drawing.Point(264, 8)
			Me.nNumericUpDown15.Name = "nNumericUpDown15"
			Me.nNumericUpDown15.Size = New System.Drawing.Size(120, 20)
			Me.nNumericUpDown15.TabIndex = 17
			Me.nNumericUpDown15.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 184)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(80, 24)
			Me.nCheckBox1.TabIndex = 19
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' m_CustomTextEdit
			' 
			Me.m_CustomTextEdit.Location = New System.Drawing.Point(96, 216)
			Me.m_CustomTextEdit.Name = "m_CustomTextEdit"
			Me.m_CustomTextEdit.Size = New System.Drawing.Size(168, 18)
			Me.m_CustomTextEdit.TabIndex = 21
'			Me.m_CustomTextEdit.TextChanged += New System.EventHandler(Me.m_CustomTextEdit_TextChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(0, 216)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(88, 23)
			Me.label1.TabIndex = 22
			Me.label1.Text = "Custom Text:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' NNumericUpDownUC
			' 
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_CustomTextEdit)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nNumericUpDown15)
			Me.Controls.Add(Me.nNumericUpDown14)
			Me.Controls.Add(Me.nNumericUpDown12)
			Me.Controls.Add(Me.nNumericUpDown11)
			Me.Controls.Add(Me.nNumericUpDown13)
			Me.Controls.Add(Me.nNumericUpDown6)
			Me.Controls.Add(Me.nNumericUpDown7)
			Me.Controls.Add(Me.nNumericUpDown8)
			Me.Controls.Add(Me.nNumericUpDown9)
			Me.Controls.Add(Me.nNumericUpDown10)
			Me.Controls.Add(Me.nNumericUpDown5)
			Me.Controls.Add(Me.nNumericUpDown4)
			Me.Controls.Add(Me.nNumericUpDown3)
			Me.Controls.Add(Me.nNumericUpDown2)
			Me.Controls.Add(Me.nNumericUpDown1)
			Me.Name = "NNumericUpDownUC"
			Me.Size = New System.Drawing.Size(392, 296)
			CType(Me.nNumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown7, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown8, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown9, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown10, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown13, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown11, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown12, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown14, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nNumericUpDown15, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nNumericUpDown1 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown2 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown3 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown4 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown6 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown7 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown8 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown9 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown10 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown13 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown11 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown12 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown14 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nNumericUpDown15 As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_CustomTextEdit As Nevron.UI.WinForm.Controls.NTextBox
		Private label1 As System.Windows.Forms.Label
		Private nNumericUpDown5 As Nevron.UI.WinForm.Controls.NNumericUpDown

		#End Region
	End Class
End Namespace
