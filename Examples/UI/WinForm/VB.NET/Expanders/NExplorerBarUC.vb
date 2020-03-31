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
	''' Summary description for NExplorerBarUC.
	''' </summary>
	Public Class NExplorerBarUC
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


		#End Region

		#Region "Event Handlers"

		Private Sub m_ScrollableCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ScrollableCheck.CheckedChanged
			Dim scrollable As Boolean = m_ScrollableCheck.Checked

			nExplorerBar1.Scrollable = scrollable
			nExplorerBar2.Scrollable = scrollable
		End Sub

		Private Sub linkLabel19_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkLabel19.LinkClicked
			Process.Start("http://www.glyfz.com/")
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NExplorerBarUC))
			Me.nExplorerBar1 = New Nevron.UI.WinForm.Controls.NExplorerBar()
			Me.nExpander3 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel3 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
			Me.nExpander2 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel4 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel5 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel6 = New System.Windows.Forms.LinkLabel()
			Me.nExpander1 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel7 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel8 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel9 = New System.Windows.Forms.LinkLabel()
			Me.nExplorerBar2 = New Nevron.UI.WinForm.Controls.NExplorerBar()
			Me.nExpander4 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel10 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel11 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel12 = New System.Windows.Forms.LinkLabel()
			Me.nExpander5 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel13 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel14 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel15 = New System.Windows.Forms.LinkLabel()
			Me.nExpander6 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.linkLabel16 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel17 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel18 = New System.Windows.Forms.LinkLabel()
			Me.m_ScrollableCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.linkLabel19 = New System.Windows.Forms.LinkLabel()
			Me.label1 = New System.Windows.Forms.Label()
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExplorerBar1.SuspendLayout()
			CType(Me.nExpander3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander3.SuspendLayout()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander2.SuspendLayout()
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander1.SuspendLayout()
			CType(Me.nExplorerBar2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExplorerBar2.SuspendLayout()
			CType(Me.nExpander4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander4.SuspendLayout()
			CType(Me.nExpander5, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander5.SuspendLayout()
			CType(Me.nExpander6, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander6.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nExplorerBar1
			' 
			Me.nExplorerBar1.ClientPadding = New Nevron.UI.NPadding(8)
			Me.nExplorerBar1.Controls.Add(Me.nExpander3)
			Me.nExplorerBar1.Controls.Add(Me.nExpander2)
			Me.nExplorerBar1.Controls.Add(Me.nExpander1)
			Me.nExplorerBar1.Location = New System.Drawing.Point(8, 8)
			Me.nExplorerBar1.Name = "nExplorerBar1"
			Me.nExplorerBar1.Size = New System.Drawing.Size(232, 424)
			Me.nExplorerBar1.TabIndex = 0
			Me.nExplorerBar1.Text = "nExplorerBar1"
			' 
			' nExpander3
			' 
			Me.nExpander3.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander3.Controls.Add(Me.linkLabel3)
			Me.nExpander3.Controls.Add(Me.linkLabel2)
			Me.nExpander3.Controls.Add(Me.linkLabel1)
			Me.nExpander3.HeaderImage = (CType(resources.GetObject("nExpander3.HeaderImage"), System.Drawing.Image))
			Me.nExpander3.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander3.Location = New System.Drawing.Point(8, 8)
			Me.nExpander3.Name = "nExpander3"
			Me.nExpander3.Size = New System.Drawing.Size(216, 112)
			Me.nExpander3.TabIndex = 3
			Me.nExpander3.Text = "System Tasks"
			' 
			' linkLabel3
			' 
			Me.linkLabel3.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel3.Image = (CType(resources.GetObject("linkLabel3.Image"), System.Drawing.Image))
			Me.linkLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel3.Location = New System.Drawing.Point(8, 80)
			Me.linkLabel3.Name = "linkLabel3"
			Me.linkLabel3.Size = New System.Drawing.Size(128, 23)
			Me.linkLabel3.TabIndex = 2
			Me.linkLabel3.TabStop = True
			Me.linkLabel3.Text = "Change a setting"
			Me.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel2
			' 
			Me.linkLabel2.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel2.Image = (CType(resources.GetObject("linkLabel2.Image"), System.Drawing.Image))
			Me.linkLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel2.Location = New System.Drawing.Point(8, 56)
			Me.linkLabel2.Name = "linkLabel2"
			Me.linkLabel2.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel2.TabIndex = 1
			Me.linkLabel2.TabStop = True
			Me.linkLabel2.Text = "Add or remove programs"
			Me.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel1
			' 
			Me.linkLabel1.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel1.Image = (CType(resources.GetObject("linkLabel1.Image"), System.Drawing.Image))
			Me.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel1.Location = New System.Drawing.Point(8, 32)
			Me.linkLabel1.Name = "linkLabel1"
			Me.linkLabel1.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel1.TabIndex = 0
			Me.linkLabel1.TabStop = True
			Me.linkLabel1.Text = "View system information"
			Me.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nExpander2
			' 
			Me.nExpander2.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander2.Controls.Add(Me.linkLabel4)
			Me.nExpander2.Controls.Add(Me.linkLabel5)
			Me.nExpander2.Controls.Add(Me.linkLabel6)
			Me.nExpander2.HeaderImage = (CType(resources.GetObject("nExpander2.HeaderImage"), System.Drawing.Image))
			Me.nExpander2.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander2.Location = New System.Drawing.Point(8, 128)
			Me.nExpander2.Name = "nExpander2"
			Me.nExpander2.Size = New System.Drawing.Size(216, 112)
			Me.nExpander2.TabIndex = 2
			Me.nExpander2.Text = "Other Places"
			' 
			' linkLabel4
			' 
			Me.linkLabel4.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel4.Image = (CType(resources.GetObject("linkLabel4.Image"), System.Drawing.Image))
			Me.linkLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel4.Location = New System.Drawing.Point(8, 80)
			Me.linkLabel4.Name = "linkLabel4"
			Me.linkLabel4.Size = New System.Drawing.Size(128, 23)
			Me.linkLabel4.TabIndex = 5
			Me.linkLabel4.TabStop = True
			Me.linkLabel4.Text = "Change a setting"
			Me.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel5
			' 
			Me.linkLabel5.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel5.Image = (CType(resources.GetObject("linkLabel5.Image"), System.Drawing.Image))
			Me.linkLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel5.Location = New System.Drawing.Point(8, 56)
			Me.linkLabel5.Name = "linkLabel5"
			Me.linkLabel5.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel5.TabIndex = 4
			Me.linkLabel5.TabStop = True
			Me.linkLabel5.Text = "Add or remove programs"
			Me.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel6
			' 
			Me.linkLabel6.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel6.Image = (CType(resources.GetObject("linkLabel6.Image"), System.Drawing.Image))
			Me.linkLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel6.Location = New System.Drawing.Point(8, 32)
			Me.linkLabel6.Name = "linkLabel6"
			Me.linkLabel6.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel6.TabIndex = 3
			Me.linkLabel6.TabStop = True
			Me.linkLabel6.Text = "View system information"
			Me.linkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nExpander1
			' 
			Me.nExpander1.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander1.Controls.Add(Me.linkLabel7)
			Me.nExpander1.Controls.Add(Me.linkLabel8)
			Me.nExpander1.Controls.Add(Me.linkLabel9)
			Me.nExpander1.HeaderImage = (CType(resources.GetObject("nExpander1.HeaderImage"), System.Drawing.Image))
			Me.nExpander1.Location = New System.Drawing.Point(8, 248)
			Me.nExpander1.Name = "nExpander1"
			Me.nExpander1.Size = New System.Drawing.Size(216, 112)
			Me.nExpander1.TabIndex = 1
			Me.nExpander1.Text = "Details"
			' 
			' linkLabel7
			' 
			Me.linkLabel7.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel7.Image = (CType(resources.GetObject("linkLabel7.Image"), System.Drawing.Image))
			Me.linkLabel7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel7.Location = New System.Drawing.Point(8, 77)
			Me.linkLabel7.Name = "linkLabel7"
			Me.linkLabel7.Size = New System.Drawing.Size(128, 23)
			Me.linkLabel7.TabIndex = 5
			Me.linkLabel7.TabStop = True
			Me.linkLabel7.Text = "Change a setting"
			Me.linkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel8
			' 
			Me.linkLabel8.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel8.Image = (CType(resources.GetObject("linkLabel8.Image"), System.Drawing.Image))
			Me.linkLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel8.Location = New System.Drawing.Point(8, 53)
			Me.linkLabel8.Name = "linkLabel8"
			Me.linkLabel8.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel8.TabIndex = 4
			Me.linkLabel8.TabStop = True
			Me.linkLabel8.Text = "Add or remove programs"
			Me.linkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel9
			' 
			Me.linkLabel9.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel9.Image = (CType(resources.GetObject("linkLabel9.Image"), System.Drawing.Image))
			Me.linkLabel9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel9.Location = New System.Drawing.Point(8, 29)
			Me.linkLabel9.Name = "linkLabel9"
			Me.linkLabel9.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel9.TabIndex = 3
			Me.linkLabel9.TabStop = True
			Me.linkLabel9.Text = "View system information"
			Me.linkLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nExplorerBar2
			' 
			Me.nExplorerBar2.ClientPadding = New Nevron.UI.NPadding(8)
			Me.nExplorerBar2.Controls.Add(Me.nExpander4)
			Me.nExplorerBar2.Controls.Add(Me.nExpander5)
			Me.nExplorerBar2.Controls.Add(Me.nExpander6)
			Me.nExplorerBar2.Location = New System.Drawing.Point(248, 8)
			Me.nExplorerBar2.Name = "nExplorerBar2"
			Me.nExplorerBar2.Size = New System.Drawing.Size(224, 424)
			Me.nExplorerBar2.TabIndex = 1
			Me.nExplorerBar2.Text = "nExplorerBar2"
			' 
			' nExpander4
			' 
			Me.nExpander4.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander4.Controls.Add(Me.linkLabel10)
			Me.nExpander4.Controls.Add(Me.linkLabel11)
			Me.nExpander4.Controls.Add(Me.linkLabel12)
			Me.nExpander4.HeaderImage = (CType(resources.GetObject("nExpander4.HeaderImage"), System.Drawing.Image))
			Me.nExpander4.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander4.Location = New System.Drawing.Point(8, 8)
			Me.nExpander4.Name = "nExpander4"
			Me.nExpander4.Size = New System.Drawing.Size(208, 112)
			Me.nExpander4.TabIndex = 3
			Me.nExpander4.Text = "System Tasks"
			' 
			' linkLabel10
			' 
			Me.linkLabel10.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel10.Image = (CType(resources.GetObject("linkLabel10.Image"), System.Drawing.Image))
			Me.linkLabel10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel10.Location = New System.Drawing.Point(8, 80)
			Me.linkLabel10.Name = "linkLabel10"
			Me.linkLabel10.Size = New System.Drawing.Size(128, 23)
			Me.linkLabel10.TabIndex = 2
			Me.linkLabel10.TabStop = True
			Me.linkLabel10.Text = "Change a setting"
			Me.linkLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel11
			' 
			Me.linkLabel11.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel11.Image = (CType(resources.GetObject("linkLabel11.Image"), System.Drawing.Image))
			Me.linkLabel11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel11.Location = New System.Drawing.Point(8, 56)
			Me.linkLabel11.Name = "linkLabel11"
			Me.linkLabel11.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel11.TabIndex = 1
			Me.linkLabel11.TabStop = True
			Me.linkLabel11.Text = "Add or remove programs"
			Me.linkLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel12
			' 
			Me.linkLabel12.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel12.Image = (CType(resources.GetObject("linkLabel12.Image"), System.Drawing.Image))
			Me.linkLabel12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel12.Location = New System.Drawing.Point(8, 32)
			Me.linkLabel12.Name = "linkLabel12"
			Me.linkLabel12.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel12.TabIndex = 0
			Me.linkLabel12.TabStop = True
			Me.linkLabel12.Text = "View system information"
			Me.linkLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nExpander5
			' 
			Me.nExpander5.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander5.Controls.Add(Me.linkLabel13)
			Me.nExpander5.Controls.Add(Me.linkLabel14)
			Me.nExpander5.Controls.Add(Me.linkLabel15)
			Me.nExpander5.HeaderImage = (CType(resources.GetObject("nExpander5.HeaderImage"), System.Drawing.Image))
			Me.nExpander5.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander5.Location = New System.Drawing.Point(8, 128)
			Me.nExpander5.Name = "nExpander5"
			Me.nExpander5.Size = New System.Drawing.Size(208, 112)
			Me.nExpander5.TabIndex = 2
			Me.nExpander5.Text = "Other Places"
			' 
			' linkLabel13
			' 
			Me.linkLabel13.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel13.Image = (CType(resources.GetObject("linkLabel13.Image"), System.Drawing.Image))
			Me.linkLabel13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel13.Location = New System.Drawing.Point(8, 80)
			Me.linkLabel13.Name = "linkLabel13"
			Me.linkLabel13.Size = New System.Drawing.Size(128, 23)
			Me.linkLabel13.TabIndex = 5
			Me.linkLabel13.TabStop = True
			Me.linkLabel13.Text = "Change a setting"
			Me.linkLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel14
			' 
			Me.linkLabel14.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel14.Image = (CType(resources.GetObject("linkLabel14.Image"), System.Drawing.Image))
			Me.linkLabel14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel14.Location = New System.Drawing.Point(8, 56)
			Me.linkLabel14.Name = "linkLabel14"
			Me.linkLabel14.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel14.TabIndex = 4
			Me.linkLabel14.TabStop = True
			Me.linkLabel14.Text = "Add or remove programs"
			Me.linkLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel15
			' 
			Me.linkLabel15.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel15.Image = (CType(resources.GetObject("linkLabel15.Image"), System.Drawing.Image))
			Me.linkLabel15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel15.Location = New System.Drawing.Point(8, 32)
			Me.linkLabel15.Name = "linkLabel15"
			Me.linkLabel15.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel15.TabIndex = 3
			Me.linkLabel15.TabStop = True
			Me.linkLabel15.Text = "View system information"
			Me.linkLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nExpander6
			' 
			Me.nExpander6.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nExpander6.Controls.Add(Me.linkLabel16)
			Me.nExpander6.Controls.Add(Me.linkLabel17)
			Me.nExpander6.Controls.Add(Me.linkLabel18)
			Me.nExpander6.HeaderImage = (CType(resources.GetObject("nExpander6.HeaderImage"), System.Drawing.Image))
			Me.nExpander6.Location = New System.Drawing.Point(8, 248)
			Me.nExpander6.Name = "nExpander6"
			Me.nExpander6.Size = New System.Drawing.Size(208, 112)
			Me.nExpander6.TabIndex = 1
			Me.nExpander6.Text = "Details"
			' 
			' linkLabel16
			' 
			Me.linkLabel16.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel16.Image = (CType(resources.GetObject("linkLabel16.Image"), System.Drawing.Image))
			Me.linkLabel16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel16.Location = New System.Drawing.Point(8, 77)
			Me.linkLabel16.Name = "linkLabel16"
			Me.linkLabel16.Size = New System.Drawing.Size(128, 23)
			Me.linkLabel16.TabIndex = 5
			Me.linkLabel16.TabStop = True
			Me.linkLabel16.Text = "Change a setting"
			Me.linkLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel17
			' 
			Me.linkLabel17.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel17.Image = (CType(resources.GetObject("linkLabel17.Image"), System.Drawing.Image))
			Me.linkLabel17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel17.Location = New System.Drawing.Point(8, 53)
			Me.linkLabel17.Name = "linkLabel17"
			Me.linkLabel17.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel17.TabIndex = 4
			Me.linkLabel17.TabStop = True
			Me.linkLabel17.Text = "Add or remove programs"
			Me.linkLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' linkLabel18
			' 
			Me.linkLabel18.BackColor = System.Drawing.Color.Transparent
			Me.linkLabel18.Image = (CType(resources.GetObject("linkLabel18.Image"), System.Drawing.Image))
			Me.linkLabel18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.linkLabel18.Location = New System.Drawing.Point(8, 29)
			Me.linkLabel18.Name = "linkLabel18"
			Me.linkLabel18.Size = New System.Drawing.Size(160, 23)
			Me.linkLabel18.TabIndex = 3
			Me.linkLabel18.TabStop = True
			Me.linkLabel18.Text = "View system information"
			Me.linkLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' m_ScrollableCheck
			' 
			Me.m_ScrollableCheck.ButtonProperties.BorderOffset = 2
			Me.m_ScrollableCheck.Checked = True
			Me.m_ScrollableCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_ScrollableCheck.Location = New System.Drawing.Point(488, 8)
			Me.m_ScrollableCheck.Name = "m_ScrollableCheck"
			Me.m_ScrollableCheck.TabIndex = 2
			Me.m_ScrollableCheck.Text = "Scrollable"
'			Me.m_ScrollableCheck.CheckedChanged += New System.EventHandler(Me.m_ScrollableCheck_CheckedChanged);
			' 
			' linkLabel19
			' 
			Me.linkLabel19.Location = New System.Drawing.Point(488, 64)
			Me.linkLabel19.Name = "linkLabel19"
			Me.linkLabel19.Size = New System.Drawing.Size(120, 23)
			Me.linkLabel19.TabIndex = 7
			Me.linkLabel19.TabStop = True
			Me.linkLabel19.Text = "http://www.glyfz.com/"
			Me.linkLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'			Me.linkLabel19.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabel19_LinkClicked);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(488, 40)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(144, 24)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Sample images used from:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NExplorerBarUC
			' 
			Me.Controls.Add(Me.linkLabel19)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_ScrollableCheck)
			Me.Controls.Add(Me.nExplorerBar2)
			Me.Controls.Add(Me.nExplorerBar1)
			Me.Name = "NExplorerBarUC"
			Me.Size = New System.Drawing.Size(640, 440)
			CType(Me.nExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExplorerBar1.ResumeLayout(False)
			CType(Me.nExpander3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander3.ResumeLayout(False)
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander2.ResumeLayout(False)
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander1.ResumeLayout(False)
			CType(Me.nExplorerBar2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExplorerBar2.ResumeLayout(False)
			CType(Me.nExpander4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander4.ResumeLayout(False)
			CType(Me.nExpander5, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander5.ResumeLayout(False)
			CType(Me.nExpander6, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander6.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nExplorerBar1 As Nevron.UI.WinForm.Controls.NExplorerBar
		Private nExpander1 As Nevron.UI.WinForm.Controls.NExpander
		Private nExpander2 As Nevron.UI.WinForm.Controls.NExpander
		Private nExpander3 As Nevron.UI.WinForm.Controls.NExpander
		Private linkLabel1 As System.Windows.Forms.LinkLabel
		Private linkLabel2 As System.Windows.Forms.LinkLabel
		Private linkLabel3 As System.Windows.Forms.LinkLabel
		Private linkLabel4 As System.Windows.Forms.LinkLabel
		Private linkLabel5 As System.Windows.Forms.LinkLabel
		Private linkLabel6 As System.Windows.Forms.LinkLabel
		Private linkLabel7 As System.Windows.Forms.LinkLabel
		Private linkLabel8 As System.Windows.Forms.LinkLabel
		Private nExplorerBar2 As Nevron.UI.WinForm.Controls.NExplorerBar
		Private nExpander4 As Nevron.UI.WinForm.Controls.NExpander
		Private linkLabel10 As System.Windows.Forms.LinkLabel
		Private linkLabel11 As System.Windows.Forms.LinkLabel
		Private linkLabel12 As System.Windows.Forms.LinkLabel
		Private nExpander5 As Nevron.UI.WinForm.Controls.NExpander
		Private linkLabel13 As System.Windows.Forms.LinkLabel
		Private linkLabel14 As System.Windows.Forms.LinkLabel
		Private linkLabel15 As System.Windows.Forms.LinkLabel
		Private nExpander6 As Nevron.UI.WinForm.Controls.NExpander
		Private linkLabel16 As System.Windows.Forms.LinkLabel
		Private linkLabel17 As System.Windows.Forms.LinkLabel
		Private linkLabel18 As System.Windows.Forms.LinkLabel
		Private WithEvents m_ScrollableCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents linkLabel19 As System.Windows.Forms.LinkLabel
		Private label1 As System.Windows.Forms.Label
		Private linkLabel9 As System.Windows.Forms.LinkLabel

		#End Region
	End Class
End Namespace
