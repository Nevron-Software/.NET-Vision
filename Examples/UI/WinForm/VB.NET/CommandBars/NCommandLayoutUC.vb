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
	Public Class NCommandLayoutUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
		End Sub


		#End Region

		#Region "Implementation"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_LayoutCombo.FillFromEnum(GetType(CommandLayout), True)
			m_LayoutCombo.SelectedItem = CommandLayout.HorizontalSingleRow

			m_BackgroundTypeCombo.FillFromEnum(GetType(BackgroundType), True)
			m_BackgroundTypeCombo.SelectedItem = nToolbar3.BackgroundType

			m_ShowGripperCheck.Checked = True
			m_HasBorderCheck.Checked = nToolbar3.HasBorder
		End Sub

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

		Private Sub m_ShowGripperCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowGripperCheck.CheckedChanged
			nToolbar3.HasGripper = m_ShowGripperCheck.Checked
		End Sub

		Private Sub m_LayoutCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_LayoutCombo.SelectedIndexChanged
			Dim o As Object = Me.m_LayoutCombo.SelectedItem
			If Not(TypeOf o Is CommandLayout) Then
				Return
			End If

			nToolbar3.CommandLayout = CType(o, CommandLayout)
		End Sub

		Private Sub m_BackgroundTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BackgroundTypeCombo.SelectedIndexChanged
			Dim o As Object = m_BackgroundTypeCombo.SelectedItem
			If Not(TypeOf o Is BackgroundType) Then
				Return
			End If

			nToolbar3.BackgroundType = CType(o, BackgroundType)
		End Sub
		Private Sub m_HasBorderCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HasBorderCheck.CheckedChanged
			nToolbar3.HasBorder = m_HasBorderCheck.Checked
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NCommandLayoutUC))
			Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.label3 = New System.Windows.Forms.Label()
			Me.nToolbar3 = New Nevron.UI.WinForm.Controls.NToolbar()
			Me.nCommand17 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand18 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand19 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand20 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand21 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand24 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand25 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand6 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand7 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand8 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand5 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.m_LayoutCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.m_ShowGripperCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_BackgroundTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_HasBorderCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' m_ImageList
			' 
			Me.m_ImageList.ImageSize = New System.Drawing.Size(16, 16)
			Me.m_ImageList.ImageStream = (CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(24, 280)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(88, 23)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Layout Mode:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nToolbar3
			' 
			Me.nToolbar3.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand17, Me.nCommand18, Me.nCommand24, Me.nCommand25, Me.nCommand1, Me.nCommand2, Me.nCommand3, Me.nCommand4, Me.nCommand5})
			Me.nToolbar3.ImageList = Me.m_ImageList
			Me.nToolbar3.Location = New System.Drawing.Point(8, 8)
			Me.nToolbar3.Name = "nToolbar3"
			Me.nToolbar3.Size = New System.Drawing.Size(288, 28)
			Me.nToolbar3.Text = "nToolbar3"
			' 
			' nCommand17
			' 
			Me.nCommand17.Properties.ImageIndex = 3
			Me.nCommand17.Properties.Text = "Command 1"
			' 
			' nCommand18
			' 
			Me.nCommand18.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand19, Me.nCommand20, Me.nCommand21})
			Me.nCommand18.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown
			Me.nCommand18.Properties.ImageIndex = 5
			' 
			' nCommand19
			' 
			Me.nCommand19.Properties.ImageIndex = 6
			Me.nCommand19.Properties.Text = "Nested Command 1"
			' 
			' nCommand20
			' 
			Me.nCommand20.Properties.ImageIndex = 1
			Me.nCommand20.Properties.Text = "Nested Command 2"
			' 
			' nCommand21
			' 
			Me.nCommand21.Properties.ImageIndex = 2
			Me.nCommand21.Properties.Text = "Nested Command 3"
			' 
			' nCommand24
			' 
			Me.nCommand24.Properties.ImageIndex = 4
			Me.nCommand24.Properties.PressedImageIndex = 0
			Me.nCommand24.Properties.SelectedImageIndex = 7
			' 
			' nCommand25
			' 
			Me.nCommand25.Properties.BeginGroup = True
			Me.nCommand25.Properties.ImageIndex = 12
			' 
			' nCommand1
			' 
			Me.nCommand1.Properties.ImageIndex = 8
			' 
			' nCommand2
			' 
			Me.nCommand2.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand6, Me.nCommand7, Me.nCommand8})
			Me.nCommand2.Properties.BeginGroup = True
			Me.nCommand2.Properties.ImageIndex = 15
			Me.nCommand2.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nCommand2.Properties.Text = "New..."
			' 
			' nCommand6
			' 
			Me.nCommand6.Properties.Text = "Project..."
			' 
			' nCommand7
			' 
			Me.nCommand7.Properties.Text = "Blank Solution"
			' 
			' nCommand8
			' 
			Me.nCommand8.Properties.Text = "File..."
			' 
			' nCommand3
			' 
			Me.nCommand3.Properties.ImageIndex = 16
			' 
			' nCommand4
			' 
			Me.nCommand4.Properties.ImageIndex = 18
			' 
			' nCommand5
			' 
			Me.nCommand5.Properties.ImageIndex = 7
			' 
			' m_LayoutCombo
			' 
			Me.m_LayoutCombo.Location = New System.Drawing.Point(120, 280)
			Me.m_LayoutCombo.Name = "m_LayoutCombo"
			Me.m_LayoutCombo.Size = New System.Drawing.Size(184, 22)
			Me.m_LayoutCombo.TabIndex = 14
			Me.m_LayoutCombo.Text = "nComboBox1"
'			Me.m_LayoutCombo.SelectedIndexChanged += New System.EventHandler(Me.m_LayoutCombo_SelectedIndexChanged);
			' 
			' m_ShowGripperCheck
			' 
			Me.m_ShowGripperCheck.Location = New System.Drawing.Point(120, 344)
			Me.m_ShowGripperCheck.Name = "m_ShowGripperCheck"
			Me.m_ShowGripperCheck.TabIndex = 16
			Me.m_ShowGripperCheck.Text = "Has Gripper"
			Me.m_ShowGripperCheck.TransparentBackground = True
'			Me.m_ShowGripperCheck.CheckedChanged += New System.EventHandler(Me.m_ShowGripperCheck_CheckedChanged);
			' 
			' m_BackgroundTypeCombo
			' 
			Me.m_BackgroundTypeCombo.Location = New System.Drawing.Point(120, 312)
			Me.m_BackgroundTypeCombo.Name = "m_BackgroundTypeCombo"
			Me.m_BackgroundTypeCombo.Size = New System.Drawing.Size(184, 22)
			Me.m_BackgroundTypeCombo.TabIndex = 19
			Me.m_BackgroundTypeCombo.Text = "nComboBox1"
'			Me.m_BackgroundTypeCombo.SelectedIndexChanged += New System.EventHandler(Me.m_BackgroundTypeCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 312)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 23)
			Me.label1.TabIndex = 18
			Me.label1.Text = "Background Type:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_HasBorderCheck
			' 
			Me.m_HasBorderCheck.Location = New System.Drawing.Point(120, 368)
			Me.m_HasBorderCheck.Name = "m_HasBorderCheck"
			Me.m_HasBorderCheck.TabIndex = 21
			Me.m_HasBorderCheck.Text = "Has Border"
			Me.m_HasBorderCheck.TransparentBackground = True
'			Me.m_HasBorderCheck.CheckedChanged += New System.EventHandler(Me.m_HasBorderCheck_CheckedChanged);
			' 
			' NCommandLayoutUC
			' 
			Me.BackgroundImage = (CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image))
			Me.Controls.Add(Me.m_HasBorderCheck)
			Me.Controls.Add(Me.m_BackgroundTypeCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_ShowGripperCheck)
			Me.Controls.Add(Me.m_LayoutCombo)
			Me.Controls.Add(Me.nToolbar3)
			Me.Controls.Add(Me.label3)
			Me.DockPadding.All = 2
			Me.Name = "NCommandLayoutUC"
			Me.Size = New System.Drawing.Size(312, 408)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.IContainer
		Friend m_ImageList As System.Windows.Forms.ImageList
		Private label3 As System.Windows.Forms.Label
		Private nToolbar3 As Nevron.UI.WinForm.Controls.NToolbar
		Private nCommand17 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand18 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand19 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand20 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand21 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand24 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents m_LayoutCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents m_ShowGripperCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand4 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand5 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand6 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand7 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand8 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents m_BackgroundTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents m_HasBorderCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCommand25 As Nevron.UI.WinForm.Controls.NCommand

		#End Region
	End Class
End Namespace
