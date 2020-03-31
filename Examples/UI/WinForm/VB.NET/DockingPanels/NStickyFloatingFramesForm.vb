Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NStickyFloatingFramesForm.
	''' </summary>
	Public Class NStickyFloatingFramesForm
		Inherits System.Windows.Forms.Form
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			m_StickyAreaNumeric.Value = nDockManager1.StickyOptions.StickyInflate
			nDockManager1.DocumentStyle.DocumentViewEnabled = False
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				If Not nDockManager1 Is Nothing Then
					nDockManager1.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_LeftEdgeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_LeftEdgeCheck.CheckedChanged
			If m_LeftEdgeCheck.Checked Then
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges Or Edges.Left
			Else
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges And Not Edges.Left
			End If
		End Sub

		Private Sub m_TopEdgeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_TopEdgeCheck.CheckedChanged
			If m_TopEdgeCheck.Checked Then
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges Or Edges.Top
			Else
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges And Not Edges.Top
			End If
		End Sub

		Private Sub m_RightEdgeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_RightEdgeCheck.CheckedChanged
			If m_RightEdgeCheck.Checked Then
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges Or Edges.Right
			Else
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges And Not Edges.Right
			End If
		End Sub

		Private Sub m_BottomEdgeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BottomEdgeCheck.CheckedChanged
			If m_BottomEdgeCheck.Checked Then
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges Or Edges.Bottom
			Else
				nDockManager1.StickyOptions.StickyEdges = nDockManager1.StickyOptions.StickyEdges And Not Edges.Bottom
			End If
		End Sub

		Private Sub m_StickyAreaNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StickyAreaNumeric.ValueChanged
			nDockManager1.StickyOptions.StickyInflate = CInt(Fix(m_StickyAreaNumeric.Value))
		End Sub

		Private Sub m_StickyFramesCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StickyFramesCheck.CheckedChanged
			nDockManager1.StickyFloatingFrames = m_StickyFramesCheck.Checked
		End Sub

		Private Sub m_StickToMainFormCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StickToMainFormCheck.CheckedChanged
			nDockManager1.StickToMainForm = m_StickToMainFormCheck.Checked
		End Sub

		Private Sub m_StickToWorkAreaCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StickToWorkAreaCheck.CheckedChanged
			nDockManager1.StickToWorkingArea = m_StickToWorkAreaCheck.Checked
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim nDockZone0 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone1 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone2 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone4 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone5 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone6 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone7 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Me.nDockManager1 = New Nevron.UI.WinForm.Docking.NDockManager()
			Me.nDockingPanel1 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockingPanel2 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.m_StickyFramesCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_StickToWorkAreaCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_StickToMainFormCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.m_BottomEdgeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_TopEdgeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_RightEdgeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_LeftEdgeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_StickyAreaNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nDockingPanel3 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockingPanel4 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockingPanel5 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDockingPanel2.SuspendLayout()
			Me.nGroupBox1.SuspendLayout()
			CType(Me.m_StickyAreaNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' nDockManager1
			' 
			Me.nDockManager1.Form = Me
			Me.nDockManager1.RootContainerZIndex = 0
			Me.nDockManager1.StickyOptions.StickyInflate = 21
			'  
			' Root Zone
			'  
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0)
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1)
			Me.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal
			'  
			' nDockZone0
			'  
			nDockZone0.AddChild(Me.nDockingPanel2)
			nDockZone0.Name = "nDockZone0"
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone0.Index = 0
			nDockZone0.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.Absolute
			nDockZone0.SizeInfo.PrefferedSize = New System.Drawing.Size(220, 200)
			nDockZone0.SizeInfo.AbsoluteSize = New System.Drawing.Size(220, 0)
			'  
			' nDockZone1
			'  
			nDockZone1.AddChild(nDockZone2)
			nDockZone1.AddChild(nDockZone5)
			nDockZone1.Name = "nDockZone1"
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Vertical
			nDockZone1.Index = 1
			nDockZone1.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.FillInterior
			nDockZone1.SizeInfo.PrefferedSize = New System.Drawing.Size(599, 200)
			'  
			' nDockZone2
			'  
			nDockZone2.AddChild(Me.nDockManager1.DocumentManager.DocumentViewHost)
			nDockZone2.AddChild(nDockZone4)
			nDockZone2.Name = "nDockZone2"
			nDockZone2.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone2.Index = 0
			nDockZone2.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.FillInterior
			nDockZone2.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 118)
			'  
			' nDockZone4
			'  
			nDockZone4.AddChild(Me.nDockingPanel3)
			nDockZone4.AddChild(Me.nDockingPanel4)
			nDockZone4.Name = "nDockZone4"
			nDockZone4.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone4.Index = 1
			nDockZone4.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 179)
			'  
			' nDockZone5
			'  
			nDockZone5.AddChild(nDockZone6)
			nDockZone5.AddChild(nDockZone7)
			nDockZone5.Name = "nDockZone5"
			nDockZone5.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone5.Index = 1
			nDockZone5.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 141)
			'  
			' nDockZone6
			'  
			nDockZone6.AddChild(Me.nDockingPanel5)
			nDockZone6.Name = "nDockZone6"
			nDockZone6.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone6.Index = 0
			nDockZone6.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 141)
			'  
			' nDockZone7
			'  
			nDockZone7.AddChild(Me.nDockingPanel1)
			nDockZone7.Name = "nDockZone7"
			nDockZone7.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone7.Index = 1
			nDockZone7.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 179)
			' 
			' nDockingPanel1
			' 
			Me.nDockingPanel1.Name = "nDockingPanel1"
			Me.nDockingPanel1.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 179)
			Me.nDockingPanel1.TabIndex = 1
			' 
			' nDockingPanel2
			' 
			Me.nDockingPanel2.Controls.Add(Me.m_StickyFramesCheck)
			Me.nDockingPanel2.Controls.Add(Me.m_StickToWorkAreaCheck)
			Me.nDockingPanel2.Controls.Add(Me.m_StickToMainFormCheck)
			Me.nDockingPanel2.Controls.Add(Me.nGroupBox1)
			Me.nDockingPanel2.Controls.Add(Me.label1)
			Me.nDockingPanel2.Controls.Add(Me.m_StickyAreaNumeric)
			Me.nDockingPanel2.Name = "nDockingPanel2"
			Me.nDockingPanel2.SizeInfo.AbsoluteSize = New System.Drawing.Size(220, 0)
			Me.nDockingPanel2.SizeInfo.PrefferedSize = New System.Drawing.Size(220, 200)
			Me.nDockingPanel2.SizeInfo.SizeLogic = Nevron.UI.WinForm.Docking.SizeLogic.Absolute
			Me.nDockingPanel2.TabIndex = 1
			Me.nDockingPanel2.Text = "Sticky Options"
			' 
			' m_StickyFramesCheck
			' 
			Me.m_StickyFramesCheck.Checked = True
			Me.m_StickyFramesCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_StickyFramesCheck.Location = New System.Drawing.Point(88, 144)
			Me.m_StickyFramesCheck.Name = "m_StickyFramesCheck"
			Me.m_StickyFramesCheck.Size = New System.Drawing.Size(128, 24)
			Me.m_StickyFramesCheck.TabIndex = 6
			Me.m_StickyFramesCheck.Text = "Sticky Frames"
'			Me.m_StickyFramesCheck.CheckedChanged += New System.EventHandler(Me.m_StickyFramesCheck_CheckedChanged);
			' 
			' m_StickToWorkAreaCheck
			' 
			Me.m_StickToWorkAreaCheck.Checked = True
			Me.m_StickToWorkAreaCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_StickToWorkAreaCheck.Location = New System.Drawing.Point(88, 192)
			Me.m_StickToWorkAreaCheck.Name = "m_StickToWorkAreaCheck"
			Me.m_StickToWorkAreaCheck.Size = New System.Drawing.Size(128, 24)
			Me.m_StickToWorkAreaCheck.TabIndex = 5
			Me.m_StickToWorkAreaCheck.Text = "Stick To Work Area"
'			Me.m_StickToWorkAreaCheck.CheckedChanged += New System.EventHandler(Me.m_StickToWorkAreaCheck_CheckedChanged);
			' 
			' m_StickToMainFormCheck
			' 
			Me.m_StickToMainFormCheck.Checked = True
			Me.m_StickToMainFormCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_StickToMainFormCheck.Location = New System.Drawing.Point(88, 168)
			Me.m_StickToMainFormCheck.Name = "m_StickToMainFormCheck"
			Me.m_StickToMainFormCheck.Size = New System.Drawing.Size(128, 24)
			Me.m_StickToMainFormCheck.TabIndex = 4
			Me.m_StickToMainFormCheck.Text = "Stick To Main Form"
'			Me.m_StickToMainFormCheck.CheckedChanged += New System.EventHandler(Me.m_StickToMainFormCheck_CheckedChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.m_BottomEdgeCheck)
			Me.nGroupBox1.Controls.Add(Me.m_TopEdgeCheck)
			Me.nGroupBox1.Controls.Add(Me.m_RightEdgeCheck)
			Me.nGroupBox1.Controls.Add(Me.m_LeftEdgeCheck)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(200, 96)
			Me.nGroupBox1.TabIndex = 2
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Sticky Edges"
			' 
			' m_BottomEdgeCheck
			' 
			Me.m_BottomEdgeCheck.Checked = True
			Me.m_BottomEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_BottomEdgeCheck.Location = New System.Drawing.Point(80, 64)
			Me.m_BottomEdgeCheck.Name = "m_BottomEdgeCheck"
			Me.m_BottomEdgeCheck.Size = New System.Drawing.Size(72, 24)
			Me.m_BottomEdgeCheck.TabIndex = 3
			Me.m_BottomEdgeCheck.Text = "Bottom"
'			Me.m_BottomEdgeCheck.CheckedChanged += New System.EventHandler(Me.m_BottomEdgeCheck_CheckedChanged);
			' 
			' m_TopEdgeCheck
			' 
			Me.m_TopEdgeCheck.Checked = True
			Me.m_TopEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_TopEdgeCheck.Location = New System.Drawing.Point(80, 16)
			Me.m_TopEdgeCheck.Name = "m_TopEdgeCheck"
			Me.m_TopEdgeCheck.Size = New System.Drawing.Size(72, 24)
			Me.m_TopEdgeCheck.TabIndex = 2
			Me.m_TopEdgeCheck.Text = "Top"
'			Me.m_TopEdgeCheck.CheckedChanged += New System.EventHandler(Me.m_TopEdgeCheck_CheckedChanged);
			' 
			' m_RightEdgeCheck
			' 
			Me.m_RightEdgeCheck.Checked = True
			Me.m_RightEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_RightEdgeCheck.Location = New System.Drawing.Point(128, 40)
			Me.m_RightEdgeCheck.Name = "m_RightEdgeCheck"
			Me.m_RightEdgeCheck.Size = New System.Drawing.Size(64, 24)
			Me.m_RightEdgeCheck.TabIndex = 1
			Me.m_RightEdgeCheck.Text = "Right"
'			Me.m_RightEdgeCheck.CheckedChanged += New System.EventHandler(Me.m_RightEdgeCheck_CheckedChanged);
			' 
			' m_LeftEdgeCheck
			' 
			Me.m_LeftEdgeCheck.Checked = True
			Me.m_LeftEdgeCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_LeftEdgeCheck.Location = New System.Drawing.Point(24, 40)
			Me.m_LeftEdgeCheck.Name = "m_LeftEdgeCheck"
			Me.m_LeftEdgeCheck.Size = New System.Drawing.Size(72, 24)
			Me.m_LeftEdgeCheck.TabIndex = 0
			Me.m_LeftEdgeCheck.Text = "Left"
'			Me.m_LeftEdgeCheck.CheckedChanged += New System.EventHandler(Me.m_LeftEdgeCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 112)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 24)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Sticky Area:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_StickyAreaNumeric
			' 
			Me.m_StickyAreaNumeric.Location = New System.Drawing.Point(88, 112)
			Me.m_StickyAreaNumeric.Maximum = New System.Decimal(New Integer() { 30, 0, 0, 0})
			Me.m_StickyAreaNumeric.Name = "m_StickyAreaNumeric"
			Me.m_StickyAreaNumeric.Size = New System.Drawing.Size(120, 20)
			Me.m_StickyAreaNumeric.TabIndex = 0
'			Me.m_StickyAreaNumeric.ValueChanged += New System.EventHandler(Me.m_StickyAreaNumeric_ValueChanged);
			' 
			' nDockingPanel3
			' 
			Me.nDockingPanel3.Name = "nDockingPanel3"
			Me.nDockingPanel3.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 179)
			Me.nDockingPanel3.TabIndex = 2
			' 
			' nDockingPanel4
			' 
			Me.nDockingPanel4.Name = "nDockingPanel4"
			Me.nDockingPanel4.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 179)
			Me.nDockingPanel4.TabIndex = 3
			' 
			' nDockingPanel5
			' 
			Me.nDockingPanel5.Name = "nDockingPanel5"
			Me.nDockingPanel5.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 141)
			Me.nDockingPanel5.TabIndex = 1
			' 
			' NStickyFloatingFramesForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(832, 526)
			Me.Name = "NStickyFloatingFramesForm"
			Me.Text = "Sticky Floating Frames Example"
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDockingPanel2.ResumeLayout(False)
			Me.nGroupBox1.ResumeLayout(False)
			CType(Me.m_StickyAreaNumeric, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private nDockManager1 As Nevron.UI.WinForm.Docking.NDockManager
		Private nDockingPanel1 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel2 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private WithEvents m_StickyAreaNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents m_LeftEdgeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_RightEdgeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_TopEdgeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_BottomEdgeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nDockingPanel3 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel4 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private WithEvents m_StickyFramesCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_StickToWorkAreaCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_StickToMainFormCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nDockingPanel5 As Nevron.UI.WinForm.Docking.NDockingPanel

		#End Region
	End Class
End Namespace
