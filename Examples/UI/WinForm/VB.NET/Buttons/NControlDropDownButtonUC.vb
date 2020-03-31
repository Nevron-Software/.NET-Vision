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
	''' Summary description for NControlDropDownButtonUC.
	''' </summary>
	Public Class NControlDropDownButtonUC
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

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nControlDropDownButton1 = New Nevron.UI.WinForm.Controls.NControlDropDownButton()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.hScrollBar1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.textBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
			Me.button1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nControlDropDownButton1
			' 
			Me.nControlDropDownButton1.DialogResult = System.Windows.Forms.DialogResult.No
			Me.nControlDropDownButton1.DropDownControl = Me.panel1
			Me.nControlDropDownButton1.Location = New System.Drawing.Point(8, 8)
			Me.nControlDropDownButton1.Name = "nControlDropDownButton1"
			Me.nControlDropDownButton1.Size = New System.Drawing.Size(176, 23)
			Me.nControlDropDownButton1.TabIndex = 0
			Me.nControlDropDownButton1.Text = "nControlDropDownButton1"
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.hScrollBar1)
			Me.panel1.Controls.Add(Me.textBox1)
			Me.panel1.Controls.Add(Me.linkLabel1)
			Me.panel1.Controls.Add(Me.button1)
			Me.panel1.Location = New System.Drawing.Point(8, 40)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(232, 200)
			Me.panel1.TabIndex = 1
			' 
			' hScrollBar1
			' 
			Me.hScrollBar1.Location = New System.Drawing.Point(112, 32)
			Me.hScrollBar1.Name = "hScrollBar1"
			Me.hScrollBar1.Size = New System.Drawing.Size(104, 17)
			Me.hScrollBar1.TabIndex = 3
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(56, 136)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(100, 22)
			Me.textBox1.TabIndex = 2
			Me.textBox1.Text = "textBox1"
			' 
			' linkLabel1
			' 
			Me.linkLabel1.Location = New System.Drawing.Point(48, 80)
			Me.linkLabel1.Name = "linkLabel1"
			Me.linkLabel1.TabIndex = 1
			Me.linkLabel1.TabStop = True
			Me.linkLabel1.Text = "linkLabel1"
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(24, 24)
			Me.button1.Name = "button1"
			Me.button1.TabIndex = 0
			Me.button1.Text = "button1"
			' 
			' NControlDropDownButtonUC
			' 
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.nControlDropDownButton1)
			Me.Name = "NControlDropDownButtonUC"
			Me.Size = New System.Drawing.Size(256, 248)
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nControlDropDownButton1 As Nevron.UI.WinForm.Controls.NControlDropDownButton
		Private panel1 As System.Windows.Forms.Panel
		Private button1 As NButton
		Private linkLabel1 As System.Windows.Forms.LinkLabel
		Private textBox1 As NTextBox
		Private hScrollBar1 As NHScrollBar

		#End Region
	End Class
End Namespace
