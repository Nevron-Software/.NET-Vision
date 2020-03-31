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
	''' Summary description for NFontListBoxUC.
	''' </summary>
	Public Class NFontListBoxUC
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

			nListBox1.DisplayStyle = FontDisplayStyle.Name
			nListBox2.DisplayStyle = FontDisplayStyle.NameInFont
			nListBox3.DisplayStyle = FontDisplayStyle.NameAndSample
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nListBox1 = New NFontListBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nListBox2 = New NFontListBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.nListBox3 = New NFontListBox()
			Me.SuspendLayout()
			' 
			' nListBox1
			' 
			Me.nListBox1.Location = New System.Drawing.Point(16, 32)
			Me.nListBox1.Name = "nListBox1"
			Me.nListBox1.Size = New System.Drawing.Size(224, 184)
			Me.nListBox1.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(224, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Name only:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(256, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(256, 23)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Name in font:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nListBox2
			' 
			Me.nListBox2.Location = New System.Drawing.Point(256, 32)
			Me.nListBox2.Name = "nListBox2"
			Me.nListBox2.Size = New System.Drawing.Size(256, 184)
			Me.nListBox2.TabIndex = 2
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(16, 224)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(264, 23)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Name and sample:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' nListBox3
			' 
			Me.nListBox3.Location = New System.Drawing.Point(16, 248)
			Me.nListBox3.Name = "nListBox3"
			Me.nListBox3.Size = New System.Drawing.Size(496, 184)
			Me.nListBox3.TabIndex = 4
			' 
			' NFontListBoxUC
			' 
			Me.AutoScroll = True
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.nListBox3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.nListBox2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nListBox1)
			Me.Name = "NFontListBoxUC"
			Me.Size = New System.Drawing.Size(528, 456)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nListBox1 As Nevron.UI.WinForm.Controls.NFontListBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private nListBox2 As Nevron.UI.WinForm.Controls.NFontListBox
		Private label3 As System.Windows.Forms.Label
		Private nListBox3 As Nevron.UI.WinForm.Controls.NFontListBox

		#End Region
	End Class
End Namespace
