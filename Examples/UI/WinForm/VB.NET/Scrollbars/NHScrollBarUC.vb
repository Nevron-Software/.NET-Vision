Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NHScrollBarUC
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

		#Region "Event Handlers"

		Private Sub nhScrollBar1_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles nhScrollBar1.ValueChanged
		End Sub

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			For Each c As Control In Controls
				If TypeOf c Is NScrollBar Then
					c.Enabled = nCheckBox1.Checked
				End If
			Next c
		End Sub

		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox2.CheckedChanged
			For Each c As Control In Controls
				If TypeOf c Is NScrollBar Then
					CType(c, NScrollBar).HotTrack = Me.nCheckBox2.Checked
				End If
			Next c
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nhScrollBar4 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nhScrollBar3 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nhScrollBar2 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nhScrollBar1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' nhScrollBar4
			' 
			Me.nhScrollBar4.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nhScrollBar4.Location = New System.Drawing.Point(8, 72)
			Me.nhScrollBar4.Name = "nhScrollBar4"
			Me.nhScrollBar4.Size = New System.Drawing.Size(408, 56)
			Me.nhScrollBar4.TabIndex = 3
			Me.nhScrollBar4.Text = "nhScrollBar4"
			' 
			' nhScrollBar3
			' 
			Me.nhScrollBar3.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nhScrollBar3.Location = New System.Drawing.Point(8, 136)
			Me.nhScrollBar3.Name = "nhScrollBar3"
			Me.nhScrollBar3.Size = New System.Drawing.Size(408, 136)
			Me.nhScrollBar3.TabIndex = 2
			Me.nhScrollBar3.Text = "nhScrollBar3"
			' 
			' nhScrollBar2
			' 
			Me.nhScrollBar2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nhScrollBar2.Location = New System.Drawing.Point(8, 32)
			Me.nhScrollBar2.Name = "nhScrollBar2"
			Me.nhScrollBar2.Size = New System.Drawing.Size(408, 32)
			Me.nhScrollBar2.TabIndex = 1
			Me.nhScrollBar2.Text = "nhScrollBar2"
			' 
			' nhScrollBar1
			' 
			Me.nhScrollBar1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nhScrollBar1.LargeChange = 5
			Me.nhScrollBar1.Location = New System.Drawing.Point(8, 5)
			Me.nhScrollBar1.Maximum = 255
			Me.nhScrollBar1.Name = "nhScrollBar1"
			Me.nhScrollBar1.Size = New System.Drawing.Size(408, 17)
			Me.nhScrollBar1.TabIndex = 0
			Me.nhScrollBar1.Text = "nhScrollBar1"
'			Me.nhScrollBar1.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.nhScrollBar1_ValueChanged);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 280)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(80, 24)
			Me.nCheckBox1.TabIndex = 4
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Checked = True
			Me.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox2.Location = New System.Drawing.Point(96, 280)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(88, 24)
			Me.nCheckBox2.TabIndex = 5
			Me.nCheckBox2.Text = "&Hot Track"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' NHScrollBarUC
			' 
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nhScrollBar4)
			Me.Controls.Add(Me.nhScrollBar3)
			Me.Controls.Add(Me.nhScrollBar2)
			Me.Controls.Add(Me.nhScrollBar1)
			Me.DockPadding.All = 5
			Me.Name = "NHScrollBarUC"
			Me.Size = New System.Drawing.Size(424, 312)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents nhScrollBar1 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private nhScrollBar2 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private nhScrollBar3 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nhScrollBar4 As Nevron.UI.WinForm.Controls.NHScrollBar

		#End Region
	End Class
End Namespace
