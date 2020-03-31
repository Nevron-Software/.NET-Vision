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
	''' Summary description for NTreeViewUC.
	''' </summary>
	Public Class NTreeViewUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
			nTreeView1.LabelEdit = True
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

			nTreeView1.ImageList = MainForm.TestImages
			Dim node1, node2 As TreeNode

			For i As Integer = 0 To 19
				node1 = New TreeNode("NTreeNode " & i.ToString())
				node1.ImageIndex = i
				node1.SelectedImageIndex = i
				For j As Integer = 0 To 19
					node2 = New TreeNode("Sub-NTreeNode " & j.ToString())
					node2.ImageIndex = j
					node2.SelectedImageIndex = j
					node1.Nodes.Add(node2)
				Next j
				nTreeView1.Nodes.Add(node1)
			Next i

			m_iSuspendUpdate += 1

			m_LineColorButton.Color = nTreeView1.LineColor

			m_iSuspendUpdate -= 1
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_CheckBoxesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CheckBoxesCheck.CheckedChanged
			nTreeView1.CheckBoxes = m_CheckBoxesCheck.Checked
		End Sub

		Private Sub m_CustomDrawCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CustomDrawCheck.CheckedChanged
			nTreeView1.CustomDraw = m_CustomDrawCheck.Checked
		End Sub

		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			nTreeView1.Border.ShowEditor()
		End Sub

		Private Sub m_LineColorButton_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_LineColorButton.ColorChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			nTreeView1.LineColor = m_LineColorButton.Color
		End Sub

		Private Sub m_HideSelectionCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HideSelectionCheck.CheckedChanged
			nTreeView1.HideSelection = m_HideSelectionCheck.Checked
		End Sub

		Private Sub hotTrackCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hotTrackCheck.CheckedChanged
			nTreeView1.HotTracking = hotTrackCheck.Checked
		End Sub

		Private Sub boldTextCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles boldTextCheck.CheckedChanged
			If boldTextCheck.Checked Then
				nTreeView1.Font = New Font(nTreeView1.Font, FontStyle.Bold)
			Else
				nTreeView1.Font = New Font(nTreeView1.Font, FontStyle.Regular)
			End If
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nTreeView1 = New Nevron.UI.WinForm.Controls.NTreeView()
			Me.m_CheckBoxesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_CustomDrawCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_LineColorButton = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_HideSelectionCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.hotTrackCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.boldTextCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' nTreeView1
			' 
			Me.nTreeView1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.nTreeView1.ImageIndex = -1
			Me.nTreeView1.Location = New System.Drawing.Point(8, 8)
			Me.nTreeView1.Name = "nTreeView1"
			Me.nTreeView1.SelectedImageIndex = -1
			Me.nTreeView1.Size = New System.Drawing.Size(424, 216)
			Me.nTreeView1.TabIndex = 0
			' 
			' m_CheckBoxesCheck
			' 
			Me.m_CheckBoxesCheck.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_CheckBoxesCheck.ButtonProperties.BorderOffset = 2
			Me.m_CheckBoxesCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.m_CheckBoxesCheck.Location = New System.Drawing.Point(8, 232)
			Me.m_CheckBoxesCheck.Name = "m_CheckBoxesCheck"
			Me.m_CheckBoxesCheck.Size = New System.Drawing.Size(103, 24)
			Me.m_CheckBoxesCheck.TabIndex = 5
			Me.m_CheckBoxesCheck.Text = "CheckBoxes"
'			Me.m_CheckBoxesCheck.CheckedChanged += New System.EventHandler(Me.m_CheckBoxesCheck_CheckedChanged);
			' 
			' m_CustomDrawCheck
			' 
			Me.m_CustomDrawCheck.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_CustomDrawCheck.ButtonProperties.BorderOffset = 2
			Me.m_CustomDrawCheck.Checked = True
			Me.m_CustomDrawCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_CustomDrawCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.m_CustomDrawCheck.Location = New System.Drawing.Point(112, 232)
			Me.m_CustomDrawCheck.Name = "m_CustomDrawCheck"
			Me.m_CustomDrawCheck.Size = New System.Drawing.Size(103, 24)
			Me.m_CustomDrawCheck.TabIndex = 6
			Me.m_CustomDrawCheck.Text = "Custom Draw"
'			Me.m_CustomDrawCheck.CheckedChanged += New System.EventHandler(Me.m_CustomDrawCheck_CheckedChanged);
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.m_BorderButton.Location = New System.Drawing.Point(120, 264)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.Size = New System.Drawing.Size(88, 24)
			Me.m_BorderButton.TabIndex = 24
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' m_LineColorButton
			' 
			Me.m_LineColorButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_LineColorButton.ArrowClickOptions = False
			Me.m_LineColorButton.ArrowWidth = 14
			Me.m_LineColorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.m_LineColorButton.Location = New System.Drawing.Point(120, 296)
			Me.m_LineColorButton.Name = "m_LineColorButton"
			Me.m_LineColorButton.Size = New System.Drawing.Size(88, 24)
			Me.m_LineColorButton.TabIndex = 25
'			Me.m_LineColorButton.ColorChanged += New System.EventHandler(Me.m_LineColorButton_ColorChanged);
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.Location = New System.Drawing.Point(48, 296)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 23)
			Me.label1.TabIndex = 26
			Me.label1.Text = "Line Color:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_HideSelectionCheck
			' 
			Me.m_HideSelectionCheck.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_HideSelectionCheck.ButtonProperties.BorderOffset = 2
			Me.m_HideSelectionCheck.Checked = True
			Me.m_HideSelectionCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_HideSelectionCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.m_HideSelectionCheck.Location = New System.Drawing.Point(216, 232)
			Me.m_HideSelectionCheck.Name = "m_HideSelectionCheck"
			Me.m_HideSelectionCheck.Size = New System.Drawing.Size(103, 24)
			Me.m_HideSelectionCheck.TabIndex = 27
			Me.m_HideSelectionCheck.Text = "Hide Selection"
'			Me.m_HideSelectionCheck.CheckedChanged += New System.EventHandler(Me.m_HideSelectionCheck_CheckedChanged);
			' 
			' hotTrackCheck
			' 
			Me.hotTrackCheck.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.hotTrackCheck.ButtonProperties.BorderOffset = 2
			Me.hotTrackCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.hotTrackCheck.Location = New System.Drawing.Point(320, 232)
			Me.hotTrackCheck.Name = "hotTrackCheck"
			Me.hotTrackCheck.Size = New System.Drawing.Size(103, 24)
			Me.hotTrackCheck.TabIndex = 28
			Me.hotTrackCheck.Text = "Hot Track"
'			Me.hotTrackCheck.CheckedChanged += New System.EventHandler(Me.hotTrackCheck_CheckedChanged);
			' 
			' boldTextCheck
			' 
			Me.boldTextCheck.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.boldTextCheck.ButtonProperties.BorderOffset = 2
			Me.boldTextCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.boldTextCheck.Location = New System.Drawing.Point(320, 264)
			Me.boldTextCheck.Name = "boldTextCheck"
			Me.boldTextCheck.Size = New System.Drawing.Size(103, 24)
			Me.boldTextCheck.TabIndex = 29
			Me.boldTextCheck.Text = "Bold Text"
'			Me.boldTextCheck.CheckedChanged += New System.EventHandler(Me.boldTextCheck_CheckedChanged);
			' 
			' NTreeViewUC
			' 
			Me.Controls.Add(Me.boldTextCheck)
			Me.Controls.Add(Me.hotTrackCheck)
			Me.Controls.Add(Me.m_HideSelectionCheck)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_LineColorButton)
			Me.Controls.Add(Me.m_BorderButton)
			Me.Controls.Add(Me.m_CustomDrawCheck)
			Me.Controls.Add(Me.m_CheckBoxesCheck)
			Me.Controls.Add(Me.nTreeView1)
			Me.Name = "NTreeViewUC"
			Me.Size = New System.Drawing.Size(440, 328)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"


		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_CheckBoxesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_CustomDrawCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_LineColorButton As Nevron.UI.WinForm.Controls.NColorButton
		Private label1 As System.Windows.Forms.Label
		Private WithEvents m_HideSelectionCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents hotTrackCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents boldTextCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nTreeView1 As Nevron.UI.WinForm.Controls.NTreeView

		#End Region
	End Class
End Namespace
