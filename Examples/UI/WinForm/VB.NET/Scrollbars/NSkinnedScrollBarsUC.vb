Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NSkinnedScrollBarsUC.
	''' </summary>
	Public Class NSkinnedScrollBarsUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			' This call is required by the Windows.Forms Form Designer.
			InitializeComponent()

			' TODO: Add any initialization after the InitializeComponent call

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

			nTreeView1.ExpandAll()
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_UseCustomScrollsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_UseCustomScrollsCheck.CheckedChanged
			Dim bChecked As Boolean = m_UseCustomScrollsCheck.Checked

			nListBox1.UseCustomScrollBars = bChecked
			nTextBox1.UseCustomScrollBars = bChecked
			nTreeView1.UseCustomScrollBars = bChecked
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim treeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node21")
			Dim treeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node20", New System.Windows.Forms.TreeNode() { treeNode1})
			Dim treeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node19", New System.Windows.Forms.TreeNode() { treeNode2})
			Dim treeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node18", New System.Windows.Forms.TreeNode() { treeNode3})
			Dim treeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node17", New System.Windows.Forms.TreeNode() { treeNode4})
			Dim treeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node16", New System.Windows.Forms.TreeNode() { treeNode5})
			Dim treeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node9", New System.Windows.Forms.TreeNode() { treeNode6})
			Dim treeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node8", New System.Windows.Forms.TreeNode() { treeNode7})
			Dim treeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node7", New System.Windows.Forms.TreeNode() { treeNode8})
			Dim treeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node6", New System.Windows.Forms.TreeNode() { treeNode9})
			Dim treeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node5", New System.Windows.Forms.TreeNode() { treeNode10})
			Dim treeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node4", New System.Windows.Forms.TreeNode() { treeNode11})
			Dim treeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() { treeNode12})
			Dim treeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node1")
			Dim treeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2")
			Dim treeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node3")
			Dim treeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node10")
			Dim treeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node11")
			Dim treeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node12")
			Dim treeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node13")
			Dim treeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node14")
			Dim treeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node15")
			Me.nListBox1 = New Nevron.UI.WinForm.Controls.NListBox()
			Me.nTextBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nTreeView1 = New Nevron.UI.WinForm.Controls.NTreeView()
			Me.m_UseCustomScrollsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' nListBox1
			' 
			Me.nListBox1.HorizontalExtent = 500
			Me.nListBox1.HorizontalScrollbar = True
			Me.nListBox1.Items.AddRange(New Object() { New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0)), New Nevron.UI.WinForm.Controls.NListBoxItem(Nothing, -1, False, 0, New System.Drawing.Size(0, 0))})
			Me.nListBox1.Location = New System.Drawing.Point(8, 8)
			Me.nListBox1.Name = "nListBox1"
			Me.nListBox1.Size = New System.Drawing.Size(184, 141)
			Me.nListBox1.TabIndex = 0
			' 
			' nTextBox1
			' 
			Me.nTextBox1.Location = New System.Drawing.Point(8, 152)
			Me.nTextBox1.Multiline = True
			Me.nTextBox1.Name = "nTextBox1"
			Me.nTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.nTextBox1.Size = New System.Drawing.Size(184, 144)
			Me.nTextBox1.TabIndex = 1
			Me.nTextBox1.Text = "Line" & Constants.vbCrLf & "Line" & Constants.vbCrLf & "Line" & Constants.vbCrLf & "LineLine" & Constants.vbCrLf & "LineLine" & Constants.vbCrLf & "LineLine" & Constants.vbCrLf & "LineLine" & Constants.vbCrLf & "LineLine" & Constants.vbCrLf & "LineLine" & Constants.vbCrLf & "Lin" & "eLine" & Constants.vbCrLf & "LineLine" & Constants.vbCrLf & "Long LineLong LineLong LineLong LineLong LineLong LineLong Line" & "Long LineLong LineLong Line"
			Me.nTextBox1.WordWrap = False
			' 
			' nTreeView1
			' 
			Me.nTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.nTreeView1.LineColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(127))))), (CInt(Fix((CByte(127))))), (CInt(Fix((CByte(127))))))
			Me.nTreeView1.Location = New System.Drawing.Point(200, 8)
			Me.nTreeView1.Name = "nTreeView1"
			treeNode1.Name = ""
			treeNode1.Text = "Node21"
			treeNode2.Name = ""
			treeNode2.Text = "Node20"
			treeNode3.Name = ""
			treeNode3.Text = "Node19"
			treeNode4.Name = ""
			treeNode4.Text = "Node18"
			treeNode5.Name = ""
			treeNode5.Text = "Node17"
			treeNode6.Name = ""
			treeNode6.Text = "Node16"
			treeNode7.Name = ""
			treeNode7.Text = "Node9"
			treeNode8.Name = ""
			treeNode8.Text = "Node8"
			treeNode9.Name = ""
			treeNode9.Text = "Node7"
			treeNode10.Name = ""
			treeNode10.Text = "Node6"
			treeNode11.Name = ""
			treeNode11.Text = "Node5"
			treeNode12.Name = ""
			treeNode12.Text = "Node4"
			treeNode13.Name = ""
			treeNode13.Text = "Node0"
			treeNode14.Name = ""
			treeNode14.Text = "Node1"
			treeNode15.Name = ""
			treeNode15.Text = "Node2"
			treeNode16.Name = ""
			treeNode16.Text = "Node3"
			treeNode17.Name = ""
			treeNode17.Text = "Node10"
			treeNode18.Name = ""
			treeNode18.Text = "Node11"
			treeNode19.Name = ""
			treeNode19.Text = "Node12"
			treeNode20.Name = ""
			treeNode20.Text = "Node13"
			treeNode21.Name = ""
			treeNode21.Text = "Node14"
			treeNode22.Name = ""
			treeNode22.Text = "Node15"
			Me.nTreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() { treeNode13, treeNode14, treeNode15, treeNode16, treeNode17, treeNode18, treeNode19, treeNode20, treeNode21, treeNode22})
			Me.nTreeView1.Size = New System.Drawing.Size(232, 288)
			Me.nTreeView1.TabIndex = 2
			' 
			' m_UseCustomScrollsCheck
			' 
			Me.m_UseCustomScrollsCheck.ButtonProperties.BorderOffset = 2
			Me.m_UseCustomScrollsCheck.Checked = True
			Me.m_UseCustomScrollsCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_UseCustomScrollsCheck.Location = New System.Drawing.Point(8, 304)
			Me.m_UseCustomScrollsCheck.Name = "m_UseCustomScrollsCheck"
			Me.m_UseCustomScrollsCheck.Size = New System.Drawing.Size(184, 24)
			Me.m_UseCustomScrollsCheck.TabIndex = 3
			Me.m_UseCustomScrollsCheck.Text = "Use Custom ScrollBars"
'			Me.m_UseCustomScrollsCheck.CheckedChanged += New System.EventHandler(Me.m_UseCustomScrollsCheck_CheckedChanged);
			' 
			' NSkinnedScrollBarsUC
			' 
			Me.Controls.Add(Me.m_UseCustomScrollsCheck)
			Me.Controls.Add(Me.nTreeView1)
			Me.Controls.Add(Me.nTextBox1)
			Me.Controls.Add(Me.nListBox1)
			Me.Name = "NSkinnedScrollBarsUC"
			Me.Size = New System.Drawing.Size(440, 328)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nListBox1 As Nevron.UI.WinForm.Controls.NListBox
		Private nTextBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private nTreeView1 As Nevron.UI.WinForm.Controls.NTreeView
		Private WithEvents m_UseCustomScrollsCheck As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
