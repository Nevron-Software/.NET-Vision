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
	''' Summary description for NExpanderUC.
	''' </summary>
	Public Class NExpanderUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
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
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub m_AnimateCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_AnimateCheck.CheckedChanged
			Dim ex As NExpander

			For Each c As Control In Me.Controls
				ex = TryCast(c, NExpander)
				If ex Is Nothing Then
					Continue For
				End If

				ex.Animate = m_AnimateCheck.Checked
			Next c
		End Sub

		Private Sub m_DrawBorderCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_DrawBorderCheck.CheckedChanged
			Dim ex As NExpander

			For Each c As Control In Me.Controls
				ex = TryCast(c, NExpander)
				If ex Is Nothing Then
					Continue For
				End If

				ex.DrawBorder = m_DrawBorderCheck.Checked
			Next c
		End Sub
		Private Sub m_FocusRectCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FocusRectCheck.CheckedChanged
			Dim ex As NExpander

			For Each c As Control In Me.Controls
				ex = TryCast(c, NExpander)
				If ex Is Nothing Then
					Continue For
				End If

				ex.FocusRect = m_FocusRectCheck.Checked
			Next c
		End Sub
		Private Sub m_CollapseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CollapseButton.Click
			m_PrefferedState = ExpanderState.Collapsed

			nExpander1.State = m_PrefferedState
			nExpander2.State = m_PrefferedState
			nExpander3.State = m_PrefferedState
		End Sub

		Private Sub m_ExpandButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ExpandButton.Click
			m_PrefferedState = ExpanderState.Expanded

			nExpander1.State = m_PrefferedState
			nExpander2.State = m_PrefferedState
			nExpander3.State = m_PrefferedState
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NExpanderUC))
			Me.nExpander1 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel8 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel3 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
			Me.nExpander2 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel7 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel4 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel5 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel6 = New System.Windows.Forms.LinkLabel()
			Me.nExpander3 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nhScrollBar1 = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.nProgressBar1 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nLuminanceBar1 = New Nevron.UI.WinForm.Controls.NLuminanceBar()
			Me.nColorButton1 = New Nevron.UI.WinForm.Controls.NColorButton()
			Me.m_AnimateCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_CollapseButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ExpandButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_DrawBorderCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_FocusRectCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander1.SuspendLayout()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander2.SuspendLayout()
			CType(Me.nExpander3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nExpander1
			' 
			Me.nExpander1.BackColor = System.Drawing.Color.Transparent
			Me.nExpander1.Controls.Add(Me.linkLabel8)
			Me.nExpander1.Controls.Add(Me.linkLabel3)
			Me.nExpander1.Controls.Add(Me.linkLabel2)
			Me.nExpander1.Controls.Add(Me.linkLabel1)
			Me.nExpander1.HeaderImage = (CType(resources.GetObject("nExpander1.HeaderImage"), System.Drawing.Image))
			Me.nExpander1.HeaderImageSize = New System.Drawing.Size(24, 24)
			Me.nExpander1.Location = New System.Drawing.Point(8, 8)
			Me.nExpander1.Name = "nExpander1"
			Me.nExpander1.Size = New System.Drawing.Size(216, 136)
			Me.nExpander1.TabIndex = 0
			Me.nExpander1.Text = "nExpander1"
			' 
			' linkLabel8
			' 
			Me.linkLabel8.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel8.Image = (CType(resources.GetObject("linkLabel8.Image"), System.Drawing.Image))
			Me.linkLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel8.Location = New System.Drawing.Point(8, 104)
			Me.linkLabel8.Name = "linkLabel8"
			Me.linkLabel8.Size = New System.Drawing.Size(88, 24)
			Me.linkLabel8.TabIndex = 4
			Me.linkLabel8.TabStop = True
			Me.linkLabel8.Text = "Shortcuts"
			Me.linkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel3
			' 
			Me.linkLabel3.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel3.Image = (CType(resources.GetObject("linkLabel3.Image"), System.Drawing.Image))
			Me.linkLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel3.Location = New System.Drawing.Point(8, 80)
			Me.linkLabel3.Name = "linkLabel3"
			Me.linkLabel3.Size = New System.Drawing.Size(80, 24)
			Me.linkLabel3.TabIndex = 2
			Me.linkLabel3.TabStop = True
			Me.linkLabel3.Text = "Folders"
			Me.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel2
			' 
			Me.linkLabel2.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel2.Image = (CType(resources.GetObject("linkLabel2.Image"), System.Drawing.Image))
			Me.linkLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel2.Location = New System.Drawing.Point(8, 56)
			Me.linkLabel2.Name = "linkLabel2"
			Me.linkLabel2.Size = New System.Drawing.Size(104, 24)
			Me.linkLabel2.TabIndex = 1
			Me.linkLabel2.TabStop = True
			Me.linkLabel2.Text = "More Tasks"
			Me.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel1
			' 
			Me.linkLabel1.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel1.Image = (CType(resources.GetObject("linkLabel1.Image"), System.Drawing.Image))
			Me.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel1.Location = New System.Drawing.Point(8, 32)
			Me.linkLabel1.Name = "linkLabel1"
			Me.linkLabel1.Size = New System.Drawing.Size(80, 24)
			Me.linkLabel1.TabIndex = 0
			Me.linkLabel1.TabStop = True
			Me.linkLabel1.Text = "Tasks"
			Me.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nExpander2
			' 
			Me.nExpander2.BackColor = System.Drawing.Color.Transparent
			Me.nExpander2.Controls.Add(Me.linkLabel7)
			Me.nExpander2.Controls.Add(Me.linkLabel4)
			Me.nExpander2.Controls.Add(Me.linkLabel5)
			Me.nExpander2.Controls.Add(Me.linkLabel6)
			Me.nExpander2.HeaderImage = (CType(resources.GetObject("nExpander2.HeaderImage"), System.Drawing.Image))
			Me.nExpander2.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander2.Location = New System.Drawing.Point(8, 160)
			Me.nExpander2.Name = "nExpander2"
			Me.nExpander2.Size = New System.Drawing.Size(216, 136)
			Me.nExpander2.TabIndex = 1
			Me.nExpander2.Text = "nExpander2"
			' 
			' linkLabel7
			' 
			Me.linkLabel7.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel7.Image = (CType(resources.GetObject("linkLabel7.Image"), System.Drawing.Image))
			Me.linkLabel7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel7.Location = New System.Drawing.Point(8, 104)
			Me.linkLabel7.Name = "linkLabel7"
			Me.linkLabel7.Size = New System.Drawing.Size(88, 24)
			Me.linkLabel7.TabIndex = 3
			Me.linkLabel7.TabStop = True
			Me.linkLabel7.Text = "Shortcuts"
			Me.linkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel4
			' 
			Me.linkLabel4.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel4.Image = (CType(resources.GetObject("linkLabel4.Image"), System.Drawing.Image))
			Me.linkLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel4.Location = New System.Drawing.Point(8, 80)
			Me.linkLabel4.Name = "linkLabel4"
			Me.linkLabel4.Size = New System.Drawing.Size(80, 24)
			Me.linkLabel4.TabIndex = 2
			Me.linkLabel4.TabStop = True
			Me.linkLabel4.Text = "Folders"
			Me.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel5
			' 
			Me.linkLabel5.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel5.Image = (CType(resources.GetObject("linkLabel5.Image"), System.Drawing.Image))
			Me.linkLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel5.Location = New System.Drawing.Point(8, 56)
			Me.linkLabel5.Name = "linkLabel5"
			Me.linkLabel5.Size = New System.Drawing.Size(104, 24)
			Me.linkLabel5.TabIndex = 1
			Me.linkLabel5.TabStop = True
			Me.linkLabel5.Text = "More Tasks"
			Me.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel6
			' 
			Me.linkLabel6.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel6.Image = (CType(resources.GetObject("linkLabel6.Image"), System.Drawing.Image))
			Me.linkLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel6.Location = New System.Drawing.Point(8, 32)
			Me.linkLabel6.Name = "linkLabel6"
			Me.linkLabel6.Size = New System.Drawing.Size(80, 24)
			Me.linkLabel6.TabIndex = 0
			Me.linkLabel6.TabStop = True
			Me.linkLabel6.Text = "Tasks"
			Me.linkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nExpander3
			' 
			Me.nExpander3.BackColor = System.Drawing.Color.Transparent
			Me.nExpander3.Controls.Add(Me.nhScrollBar1)
			Me.nExpander3.Controls.Add(Me.nProgressBar1)
			Me.nExpander3.Controls.Add(Me.nLuminanceBar1)
			Me.nExpander3.Controls.Add(Me.nColorButton1)
			Me.nExpander3.HeaderImage = (CType(resources.GetObject("nExpander3.HeaderImage"), System.Drawing.Image))
			Me.nExpander3.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander3.Location = New System.Drawing.Point(232, 8)
			Me.nExpander3.Name = "nExpander3"
			Me.nExpander3.Size = New System.Drawing.Size(216, 288)
			Me.nExpander3.TabIndex = 2
			Me.nExpander3.Text = "nExpander3"
			' 
			' nhScrollBar1
			' 
			Me.nhScrollBar1.Location = New System.Drawing.Point(8, 232)
			Me.nhScrollBar1.Name = "nhScrollBar1"
			Me.nhScrollBar1.Size = New System.Drawing.Size(192, 17)
			Me.nhScrollBar1.TabIndex = 4
			Me.nhScrollBar1.Text = "nhScrollBar1"
			' 
			' nProgressBar1
			' 
			Me.nProgressBar1.Location = New System.Drawing.Point(8, 176)
			Me.nProgressBar1.Name = "nProgressBar1"
			Me.nProgressBar1.Size = New System.Drawing.Size(192, 16)
			Me.nProgressBar1.TabIndex = 3
			Me.nProgressBar1.Text = "nProgressBar1"
			' 
			' nLuminanceBar1
			' 
			Me.nLuminanceBar1.Location = New System.Drawing.Point(8, 120)
			Me.nLuminanceBar1.Name = "nLuminanceBar1"
			Me.nLuminanceBar1.Size = New System.Drawing.Size(184, 24)
			Me.nLuminanceBar1.TabIndex = 2
			Me.nLuminanceBar1.Text = "nLuminanceBar1"
			' 
			' nColorButton1
			' 
			Me.nColorButton1.ArrowClickOptions = False
			Me.nColorButton1.ArrowWidth = 14
			Me.nColorButton1.Location = New System.Drawing.Point(8, 72)
			Me.nColorButton1.Name = "nColorButton1"
			Me.nColorButton1.Size = New System.Drawing.Size(88, 23)
			Me.nColorButton1.TabIndex = 1
			' 
			' m_AnimateCheck
			' 
			Me.m_AnimateCheck.ButtonProperties.BorderOffset = 2
			Me.m_AnimateCheck.Checked = True
			Me.m_AnimateCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_AnimateCheck.Location = New System.Drawing.Point(8, 312)
			Me.m_AnimateCheck.Name = "m_AnimateCheck"
			Me.m_AnimateCheck.TabIndex = 3
			Me.m_AnimateCheck.Text = "Animate"
'			Me.m_AnimateCheck.CheckedChanged += New System.EventHandler(Me.m_AnimateCheck_CheckedChanged);
			' 
			' m_CollapseButton
			' 
			Me.m_CollapseButton.Location = New System.Drawing.Point(8, 344)
			Me.m_CollapseButton.Name = "m_CollapseButton"
			Me.m_CollapseButton.Size = New System.Drawing.Size(80, 24)
			Me.m_CollapseButton.TabIndex = 4
			Me.m_CollapseButton.Text = "Collapse All"
'			Me.m_CollapseButton.Click += New System.EventHandler(Me.m_CollapseButton_Click);
			' 
			' m_ExpandButton
			' 
			Me.m_ExpandButton.Location = New System.Drawing.Point(96, 344)
			Me.m_ExpandButton.Name = "m_ExpandButton"
			Me.m_ExpandButton.Size = New System.Drawing.Size(80, 24)
			Me.m_ExpandButton.TabIndex = 5
			Me.m_ExpandButton.Text = "Expand All"
'			Me.m_ExpandButton.Click += New System.EventHandler(Me.m_ExpandButton_Click);
			' 
			' m_DrawBorderCheck
			' 
			Me.m_DrawBorderCheck.ButtonProperties.BorderOffset = 2
			Me.m_DrawBorderCheck.Location = New System.Drawing.Point(112, 312)
			Me.m_DrawBorderCheck.Name = "m_DrawBorderCheck"
			Me.m_DrawBorderCheck.TabIndex = 6
			Me.m_DrawBorderCheck.Text = "Draw Border"
'			Me.m_DrawBorderCheck.CheckedChanged += New System.EventHandler(Me.m_DrawBorderCheck_CheckedChanged);
			' 
			' m_FocusRectCheck
			' 
			Me.m_FocusRectCheck.ButtonProperties.BorderOffset = 2
			Me.m_FocusRectCheck.Checked = True
			Me.m_FocusRectCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_FocusRectCheck.Location = New System.Drawing.Point(216, 312)
			Me.m_FocusRectCheck.Name = "m_FocusRectCheck"
			Me.m_FocusRectCheck.TabIndex = 7
			Me.m_FocusRectCheck.Text = "Focus Rect"
'			Me.m_FocusRectCheck.CheckedChanged += New System.EventHandler(Me.m_FocusRectCheck_CheckedChanged);
			' 
			' NExpanderUC
			' 
			Me.Controls.Add(Me.m_FocusRectCheck)
			Me.Controls.Add(Me.m_DrawBorderCheck)
			Me.Controls.Add(Me.m_ExpandButton)
			Me.Controls.Add(Me.m_CollapseButton)
			Me.Controls.Add(Me.m_AnimateCheck)
			Me.Controls.Add(Me.nExpander3)
			Me.Controls.Add(Me.nExpander2)
			Me.Controls.Add(Me.nExpander1)
			Me.Name = "NExpanderUC"
			Me.Size = New System.Drawing.Size(456, 368)
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander1.ResumeLayout(False)
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander2.ResumeLayout(False)
			CType(Me.nExpander3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_PrefferedState As ExpanderState

		Private components As System.ComponentModel.Container = Nothing
		Private linkLabel1 As System.Windows.Forms.LinkLabel
		Private linkLabel2 As System.Windows.Forms.LinkLabel
		Private linkLabel3 As System.Windows.Forms.LinkLabel
		Private nExpander2 As Nevron.UI.WinForm.Controls.NExpander
		Private linkLabel4 As System.Windows.Forms.LinkLabel
		Private linkLabel5 As System.Windows.Forms.LinkLabel
		Private linkLabel6 As System.Windows.Forms.LinkLabel
		Private linkLabel7 As System.Windows.Forms.LinkLabel
		Private linkLabel8 As System.Windows.Forms.LinkLabel
		Private nExpander3 As Nevron.UI.WinForm.Controls.NExpander
		Private WithEvents m_AnimateCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_CollapseButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ExpandButton As Nevron.UI.WinForm.Controls.NButton
		Private nColorButton1 As Nevron.UI.WinForm.Controls.NColorButton
		Private nLuminanceBar1 As Nevron.UI.WinForm.Controls.NLuminanceBar
		Private nProgressBar1 As Nevron.UI.WinForm.Controls.NProgressBar
		Private nhScrollBar1 As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents m_DrawBorderCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_FocusRectCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nExpander1 As Nevron.UI.WinForm.Controls.NExpander

		#End Region
	End Class
End Namespace
