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
	''' Summary description for NColorToolsUC.
	''' </summary>
	Public Class NColorToolsUC
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

			nColorComboBox1.PopulateKnownColors()
			nColorListBox1.PopulateKnownColors()
		End Sub




		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nColorBar1 = New Nevron.UI.WinForm.Controls.NColorBar()
			Me.nColorPool1 = New Nevron.UI.WinForm.Controls.NColorPool()
			Me.nLuminanceBar1 = New Nevron.UI.WinForm.Controls.NLuminanceBar()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.nColorButton1 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.nColorComboBox1 = New Nevron.UI.WinForm.Controls.NColorComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.nColorListBox1 = New Nevron.UI.WinForm.Controls.NColorListBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' nColorBar1
			' 
			Me.nColorBar1.Location = New System.Drawing.Point(112, 8)
			Me.nColorBar1.Name = "nColorBar1"
			Me.nColorBar1.Size = New System.Drawing.Size(192, 32)
			Me.nColorBar1.TabIndex = 0
			Me.nColorBar1.Text = "nColorBar1"
			Me.nColorBar1.Value = 155
			' 
			' nColorPool1
			' 
			Me.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.nColorPool1.Color = System.Drawing.Color.Empty
			Me.nColorPool1.Location = New System.Drawing.Point(117, 80)
			Me.nColorPool1.Name = "nColorPool1"
			Me.nColorPool1.Size = New System.Drawing.Size(184, 102)
			Me.nColorPool1.TabIndex = 1
			' 
			' nLuminanceBar1
			' 
			Me.nLuminanceBar1.Color = System.Drawing.Color.Brown
			Me.nLuminanceBar1.Location = New System.Drawing.Point(112, 40)
			Me.nLuminanceBar1.Mode = Nevron.UI.WinForm.Controls.ColorBarMode.Custom
			Me.nLuminanceBar1.Name = "nLuminanceBar1"
			Me.nLuminanceBar1.Size = New System.Drawing.Size(192, 32)
			Me.nLuminanceBar1.TabIndex = 2
			Me.nLuminanceBar1.Text = "nLuminanceBar1"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(0, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 23)
			Me.label1.TabIndex = 3
			Me.label1.Text = "NColorBar:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(0, 40)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(107, 23)
			Me.label2.TabIndex = 4
			Me.label2.Text = "NLuminanceBar:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(0, 80)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(107, 23)
			Me.label3.TabIndex = 5
			Me.label3.Text = "NColorPool:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nColorButton1
			' 
			Me.nColorButton1.ArrowClickOptions = False
			Me.nColorButton1.Color = System.Drawing.Color.White
			Me.nColorButton1.Location = New System.Drawing.Point(118, 202)
			Me.nColorButton1.Name = "nColorButton1"
			Me.nColorButton1.Size = New System.Drawing.Size(112, 24)
			Me.nColorButton1.TabIndex = 6
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(0, 202)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(107, 23)
			Me.label4.TabIndex = 7
			Me.label4.Text = "NColorButton:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nColorComboBox1
			' 
			Me.nColorComboBox1.Location = New System.Drawing.Point(118, 239)
			Me.nColorComboBox1.Name = "nColorComboBox1"
			Me.nColorComboBox1.Size = New System.Drawing.Size(184, 22)
			Me.nColorComboBox1.TabIndex = 8
			Me.nColorComboBox1.Text = "nColorComboBox1"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(0, 239)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(107, 23)
			Me.label5.TabIndex = 9
			Me.label5.Text = "NColorComboBox:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nColorListBox1
			' 
			Me.nColorListBox1.Location = New System.Drawing.Point(118, 273)
			Me.nColorListBox1.Name = "nColorListBox1"
			Me.nColorListBox1.Size = New System.Drawing.Size(184, 144)
			Me.nColorListBox1.TabIndex = 10
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(0, 273)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(107, 23)
			Me.label6.TabIndex = 11
			Me.label6.Text = "NColorListBox:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' NColorToolsUC
			' 
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.nColorListBox1)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.nColorComboBox1)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.nColorButton1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nLuminanceBar1)
			Me.Controls.Add(Me.nColorPool1)
			Me.Controls.Add(Me.nColorBar1)
			Me.Name = "NColorToolsUC"
			Me.Size = New System.Drawing.Size(333, 424)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nColorBar1 As Nevron.UI.WinForm.Controls.NColorBar
		Private nColorPool1 As Nevron.UI.WinForm.Controls.NColorPool
		Private nLuminanceBar1 As Nevron.UI.WinForm.Controls.NLuminanceBar
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private nColorButton1 As Nevron.UI.WinForm.Controls.NColorButton
		Private label4 As System.Windows.Forms.Label
		Private nColorComboBox1 As Nevron.UI.WinForm.Controls.NColorComboBox
		Private label5 As System.Windows.Forms.Label
		Private nColorListBox1 As Nevron.UI.WinForm.Controls.NColorListBox
		Private label6 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label

		#End Region
	End Class
End Namespace
