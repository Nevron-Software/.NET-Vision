Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NSplitterUC.
	''' </summary>
	Public Class NSplitterUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
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
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.nSplitter1 = New Nevron.UI.WinForm.Controls.NSplitter()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.nSplitter2 = New Nevron.UI.WinForm.Controls.NSplitter()
			Me.panel3 = New System.Windows.Forms.Panel()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(152, 240)
			Me.panel1.TabIndex = 0
			' 
			' nSplitter1
			' 
			Me.nSplitter1.Location = New System.Drawing.Point(152, 0)
			Me.nSplitter1.Name = "nSplitter1"
			Me.nSplitter1.Size = New System.Drawing.Size(5, 240)
			Me.nSplitter1.TabIndex = 1
			Me.nSplitter1.TabStop = False
			' 
			' panel2
			' 
			Me.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel2.Location = New System.Drawing.Point(158, 0)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(138, 100)
			Me.panel2.TabIndex = 2
			' 
			' nSplitter2
			' 
			Me.nSplitter2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nSplitter2.Location = New System.Drawing.Point(158, 100)
			Me.nSplitter2.Name = "nSplitter2"
			Me.nSplitter2.Size = New System.Drawing.Size(138, 5)
			Me.nSplitter2.TabIndex = 3
			Me.nSplitter2.TabStop = False
			' 
			' panel3
			' 
			Me.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panel3.Location = New System.Drawing.Point(158, 108)
			Me.panel3.Name = "panel3"
			Me.panel3.Size = New System.Drawing.Size(138, 132)
			Me.panel3.TabIndex = 4
			' 
			' NSplitterUC
			' 
			Me.Controls.Add(Me.panel3)
			Me.Controls.Add(Me.nSplitter2)
			Me.Controls.Add(Me.panel2)
			Me.Controls.Add(Me.nSplitter1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "NSplitterUC"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private panel1 As System.Windows.Forms.Panel
		Private nSplitter1 As Nevron.UI.WinForm.Controls.NSplitter
		Private panel2 As System.Windows.Forms.Panel
		Private nSplitter2 As Nevron.UI.WinForm.Controls.NSplitter
		Private panel3 As System.Windows.Forms.Panel

		#End Region
	End Class
End Namespace
