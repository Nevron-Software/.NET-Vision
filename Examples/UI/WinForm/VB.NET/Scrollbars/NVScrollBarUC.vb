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
	Public Class NVScrollBarUC
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
			Me.nvScrollBar1 = New Nevron.UI.WinForm.Controls.NVScrollBar()
			Me.nvScrollBar2 = New Nevron.UI.WinForm.Controls.NVScrollBar()
			Me.nvScrollBar3 = New Nevron.UI.WinForm.Controls.NVScrollBar()
			Me.nvScrollBar4 = New Nevron.UI.WinForm.Controls.NVScrollBar()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' nvScrollBar1
			' 
			Me.nvScrollBar1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.nvScrollBar1.Location = New System.Drawing.Point(8, 8)
			Me.nvScrollBar1.Name = "nvScrollBar1"
			Me.nvScrollBar1.Size = New System.Drawing.Size(17, 320)
			Me.nvScrollBar1.TabIndex = 0
			Me.nvScrollBar1.Text = "nvScrollBar1"
			' 
			' nvScrollBar2
			' 
			Me.nvScrollBar2.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.nvScrollBar2.Location = New System.Drawing.Point(32, 8)
			Me.nvScrollBar2.Name = "nvScrollBar2"
			Me.nvScrollBar2.Size = New System.Drawing.Size(32, 320)
			Me.nvScrollBar2.TabIndex = 1
			Me.nvScrollBar2.Text = "nvScrollBar2"
			' 
			' nvScrollBar3
			' 
			Me.nvScrollBar3.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.nvScrollBar3.Location = New System.Drawing.Point(72, 8)
			Me.nvScrollBar3.Name = "nvScrollBar3"
			Me.nvScrollBar3.Size = New System.Drawing.Size(96, 320)
			Me.nvScrollBar3.TabIndex = 2
			Me.nvScrollBar3.Text = "nvScrollBar3"
			' 
			' nvScrollBar4
			' 
			Me.nvScrollBar4.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.nvScrollBar4.Location = New System.Drawing.Point(176, 8)
			Me.nvScrollBar4.Name = "nvScrollBar4"
			Me.nvScrollBar4.Size = New System.Drawing.Size(200, 320)
			Me.nvScrollBar4.TabIndex = 3
			Me.nvScrollBar4.Text = "nvScrollBar4"
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Checked = True
			Me.nCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox2.Location = New System.Drawing.Point(384, 32)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(88, 24)
			Me.nCheckBox2.TabIndex = 7
			Me.nCheckBox2.Text = "&Hot Track"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(384, 8)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(80, 24)
			Me.nCheckBox1.TabIndex = 6
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' NVScrollBarUC
			' 
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Controls.Add(Me.nvScrollBar4)
			Me.Controls.Add(Me.nvScrollBar3)
			Me.Controls.Add(Me.nvScrollBar2)
			Me.Controls.Add(Me.nvScrollBar1)
			Me.Name = "NVScrollBarUC"
			Me.Size = New System.Drawing.Size(472, 336)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nvScrollBar1 As Nevron.UI.WinForm.Controls.NVScrollBar
		Private nvScrollBar2 As Nevron.UI.WinForm.Controls.NVScrollBar
		Private nvScrollBar3 As Nevron.UI.WinForm.Controls.NVScrollBar
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nvScrollBar4 As Nevron.UI.WinForm.Controls.NVScrollBar

		#End Region
	End Class
End Namespace
