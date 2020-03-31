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
	''' Summary description for NCommandAppearanceUC.
	''' </summary>
	Public Class NCommandAppearanceUC
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

			m_BackgroundTypeCombo.FillFromEnum(GetType(BackgroundType))
			m_BackgroundTypeCombo.SelectedItem = BackgroundType.SolidColor

			m_ShowTooltipsCheck.Checked = True
			m_HasGripperCheck.Checked = False
			m_HasBorderCheck.Checked = False
		End Sub




		#End Region

		#Region "Event Handlers"

		Private Sub m_BackgroundTypeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BackgroundTypeCombo.SelectedIndexChanged
			Dim type As BackgroundType = CType(m_BackgroundTypeCombo.SelectedIndex, BackgroundType)

			nToolbar1.BackgroundType = type
			nToolbar2.BackgroundType = type
			nToolbar3.BackgroundType = type
		End Sub

		Private Sub m_HasBorderCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HasBorderCheck.CheckedChanged
			Dim hasBorder As Boolean = m_HasBorderCheck.Checked
			nToolbar1.HasBorder = hasBorder
			nToolbar2.HasBorder = hasBorder
			nToolbar3.HasBorder = hasBorder
		End Sub

		Private Sub m_HasGripperCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HasGripperCheck.CheckedChanged
			Dim hasGripper As Boolean = m_HasGripperCheck.Checked
			nToolbar1.HasGripper = hasGripper
			nToolbar2.HasGripper = hasGripper
			nToolbar3.HasGripper = hasGripper
		End Sub

		Private Sub m_ShowTooltipsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowTooltipsCheck.CheckedChanged
			Dim count As Integer = Controls.Count
			Dim parent As NCommandParent

			Dim i As Integer = 0
			Do While i < count
				parent = TryCast(Controls(i), NCommandParent)
				If Not parent Is Nothing Then
					parent.ShowTooltips = m_ShowTooltipsCheck.Checked
				End If
				i += 1
			Loop
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NCommandAppearanceUC))
			Me.nCommand22 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand20 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand23 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand26 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand24 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand7 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand8 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand17 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand18 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand19 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand21 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand6 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand27 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand36 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand35 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand37 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand39 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand38 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand30 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand31 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand32 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand33 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand34 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand28 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand5 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand11 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand10 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nToolbar1 = New Nevron.UI.WinForm.Controls.NToolbar()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand9 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand12 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand13 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand15 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand16 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand14 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand25 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.nCommand29 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nToolbar3 = New Nevron.UI.WinForm.Controls.NToolbar()
			Me.nToolbar2 = New Nevron.UI.WinForm.Controls.NToolbar()
			Me.m_HasGripperCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_ShowTooltipsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_HasBorderCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_BackgroundTypeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.SuspendLayout()
			' 
			' nCommand22
			' 
			Me.nCommand22.Properties.BeginGroup = True
			Me.nCommand22.Properties.ImageIndex = 5
			Me.nCommand22.Properties.Text = "Nested Command 2"
			' 
			' nCommand20
			' 
			Me.nCommand20.Properties.ImageIndex = 13
			Me.nCommand20.Properties.Text = "Deeper Nested Command 4"
			' 
			' nCommand23
			' 
			Me.nCommand23.Properties.ImageIndex = 16
			Me.nCommand23.Properties.Text = "Nested Command 3"
			' 
			' nCommand26
			' 
			Me.nCommand26.Properties.ImageIndex = 5
			Me.nCommand26.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nCommand26.Properties.Text = "Open..."
			' 
			' nCommand24
			' 
			Me.nCommand24.Properties.BeginGroup = True
			Me.nCommand24.Properties.ImageIndex = 4
			Me.nCommand24.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nCommand24.Properties.Text = "Save..."
			' 
			' nCommand7
			' 
			Me.nCommand7.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand8, Me.nCommand22, Me.nCommand23})
			Me.nCommand7.Properties.ImageIndex = 1
			Me.nCommand7.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			' 
			' nCommand8
			' 
			Me.nCommand8.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand17, Me.nCommand18, Me.nCommand19, Me.nCommand20, Me.nCommand21})
			Me.nCommand8.Properties.ImageIndex = 3
			Me.nCommand8.Properties.Text = "Nested Command 1"
			' 
			' nCommand17
			' 
			Me.nCommand17.Properties.ImageIndex = 7
			Me.nCommand17.Properties.Text = "Deeper Nested Command 1"
			' 
			' nCommand18
			' 
			Me.nCommand18.Properties.ImageIndex = 9
			Me.nCommand18.Properties.Text = "Deeper Nested Command 2"
			' 
			' nCommand19
			' 
			Me.nCommand19.Properties.ImageIndex = 12
			Me.nCommand19.Properties.Text = "Deeper Nested Command 3"
			' 
			' nCommand21
			' 
			Me.nCommand21.Properties.ImageIndex = 14
			Me.nCommand21.Properties.Text = "Deeper Nested Command 5"
			' 
			' nCommand6
			' 
			Me.nCommand6.Properties.FadeImage = True
			Me.nCommand6.Properties.ImageIndex = 0
			Me.nCommand6.Properties.ImageShadow = True
			Me.nCommand6.Properties.SelectedImageIndex = 21
			' 
			' nCommand27
			' 
			Me.nCommand27.Properties.ImageIndex = 2
			' 
			' nCommand36
			' 
			Me.nCommand36.Properties.BeginGroup = True
			Me.nCommand36.Properties.ImageIndex = 5
			Me.nCommand36.Properties.Text = "Nested Command 2"
			' 
			' nCommand35
			' 
			Me.nCommand35.Properties.ImageIndex = 14
			Me.nCommand35.Properties.Text = "Deeper Nested Command 5"
			' 
			' nCommand37
			' 
			Me.nCommand37.Properties.ImageIndex = 16
			Me.nCommand37.Properties.Text = "Nested Command 3"
			' 
			' nCommand39
			' 
			Me.nCommand39.Properties.ImageIndex = 5
			Me.nCommand39.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nCommand39.Properties.Text = "Open..."
			' 
			' nCommand38
			' 
			Me.nCommand38.Properties.BeginGroup = True
			Me.nCommand38.Properties.ImageIndex = 4
			Me.nCommand38.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nCommand38.Properties.Text = "Save..."
			' 
			' nCommand30
			' 
			Me.nCommand30.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand31, Me.nCommand32, Me.nCommand33, Me.nCommand34, Me.nCommand35})
			Me.nCommand30.Properties.ImageIndex = 3
			Me.nCommand30.Properties.Text = "Nested Command 1"
			' 
			' nCommand31
			' 
			Me.nCommand31.Properties.ImageIndex = 7
			Me.nCommand31.Properties.Text = "Deeper Nested Command 1"
			' 
			' nCommand32
			' 
			Me.nCommand32.Properties.ImageIndex = 9
			Me.nCommand32.Properties.Text = "Deeper Nested Command 2"
			' 
			' nCommand33
			' 
			Me.nCommand33.Properties.ImageIndex = 12
			Me.nCommand33.Properties.Text = "Deeper Nested Command 3"
			' 
			' nCommand34
			' 
			Me.nCommand34.Properties.ImageIndex = 13
			Me.nCommand34.Properties.Text = "Deeper Nested Command 4"
			' 
			' nCommand28
			' 
			Me.nCommand28.Properties.ImageIndex = 0
			' 
			' nCommand5
			' 
			Me.nCommand5.Properties.FadeImage = True
			Me.nCommand5.Properties.ImageIndex = 2
			Me.nCommand5.Properties.ImageShadow = True
			Me.nCommand5.Properties.SelectedImageIndex = 8
			' 
			' nCommand11
			' 
			Me.nCommand11.Properties.ImageIndex = 7
			Me.nCommand11.Properties.Text = "Deeper Nested Command 1"
			' 
			' nCommand10
			' 
			Me.nCommand10.Properties.BeginGroup = True
			Me.nCommand10.Properties.ImageIndex = 5
			Me.nCommand10.Properties.Text = "Nested Command 2"
			' 
			' nToolbar1
			' 
			Me.nToolbar1.AutoSize = False
			Me.nToolbar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1, Me.nCommand2, Me.nCommand3, Me.nCommand4, Me.nCommand25})
			Me.nToolbar1.CommandSize = New System.Drawing.Size(32, 32)
			Me.nToolbar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nToolbar1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nToolbar1.HasGripper = False
			Me.nToolbar1.ImageList = Me.m_ImageList
			Me.nToolbar1.ImageSize = New System.Drawing.Size(24, 24)
			Me.nToolbar1.Location = New System.Drawing.Point(0, 0)
			Me.nToolbar1.Name = "nToolbar1"
			Me.nToolbar1.Size = New System.Drawing.Size(352, 40)
			Me.nToolbar1.Text = "nToolbar1"
			' 
			' nCommand1
			' 
			Me.nCommand1.Properties.FadeImage = True
			Me.nCommand1.Properties.ImageIndex = 2
			Me.nCommand1.Properties.ImageShadow = True
			' 
			' nCommand2
			' 
			Me.nCommand2.Properties.ImageIndex = 0
			' 
			' nCommand3
			' 
			Me.nCommand3.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand9, Me.nCommand10, Me.nCommand14})
			Me.nCommand3.Properties.ImageIndex = 1
			' 
			' nCommand9
			' 
			Me.nCommand9.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand11, Me.nCommand12, Me.nCommand13, Me.nCommand15, Me.nCommand16})
			Me.nCommand9.Properties.ImageIndex = 3
			Me.nCommand9.Properties.Text = "Nested Command 1"
			' 
			' nCommand12
			' 
			Me.nCommand12.Properties.ImageIndex = 9
			Me.nCommand12.Properties.Text = "Deeper Nested Command 2"
			' 
			' nCommand13
			' 
			Me.nCommand13.Properties.ImageIndex = 12
			Me.nCommand13.Properties.Text = "Deeper Nested Command 3"
			' 
			' nCommand15
			' 
			Me.nCommand15.Properties.ImageIndex = 13
			Me.nCommand15.Properties.Text = "Deeper Nested Command 4"
			' 
			' nCommand16
			' 
			Me.nCommand16.Properties.ImageIndex = 14
			Me.nCommand16.Properties.Text = "Deeper Nested Command 5"
			' 
			' nCommand14
			' 
			Me.nCommand14.Properties.ImageIndex = 16
			Me.nCommand14.Properties.Text = "Nested Command 3"
			' 
			' nCommand4
			' 
			Me.nCommand4.Properties.BeginGroup = True
			Me.nCommand4.Properties.ImageIndex = 4
			Me.nCommand4.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nCommand4.Properties.Text = "Save..."
			' 
			' nCommand25
			' 
			Me.nCommand25.Properties.ImageIndex = 5
			Me.nCommand25.Properties.Style = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nCommand25.Properties.Text = "Open..."
			' 
			' m_ImageList
			' 
			Me.m_ImageList.ImageSize = New System.Drawing.Size(16, 16)
			Me.m_ImageList.ImageStream = (CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
			' 
			' nCommand29
			' 
			Me.nCommand29.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand30, Me.nCommand36, Me.nCommand37})
			Me.nCommand29.Properties.DropDownBehavior = Nevron.UI.WinForm.Controls.DropDownBehavior.AlwaysDropDown
			Me.nCommand29.Properties.ImageIndex = 1
			Me.nCommand29.Properties.Text = "Drop-Down"
			' 
			' nToolbar3
			' 
			Me.nToolbar3.CommandLayout = Nevron.UI.WinForm.Controls.CommandLayout.VerticalMaxWidth
			Me.nToolbar3.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand27, Me.nCommand28, Me.nCommand29, Me.nCommand38, Me.nCommand39})
			Me.nToolbar3.CommandSize = New System.Drawing.Size(32, 32)
			Me.nToolbar3.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nToolbar3.HasGripper = False
			Me.nToolbar3.ImageList = Me.m_ImageList
			Me.nToolbar3.ImageSize = New System.Drawing.Size(24, 24)
			Me.nToolbar3.Location = New System.Drawing.Point(56, 48)
			Me.nToolbar3.Name = "nToolbar3"
			Me.nToolbar3.Size = New System.Drawing.Size(109, 182)
			Me.nToolbar3.Text = "nToolbar3"
			' 
			' nToolbar2
			' 
			Me.nToolbar2.AutoSize = False
			Me.nToolbar2.CommandLayout = Nevron.UI.WinForm.Controls.CommandLayout.VerticalSingleColumn
			Me.nToolbar2.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand5, Me.nCommand6, Me.nCommand7, Me.nCommand24, Me.nCommand26})
			Me.nToolbar2.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nToolbar2.Dock = System.Windows.Forms.DockStyle.Left
			Me.nToolbar2.HasGripper = False
			Me.nToolbar2.ImageList = Me.m_ImageList
			Me.nToolbar2.Location = New System.Drawing.Point(0, 40)
			Me.nToolbar2.Name = "nToolbar2"
			Me.nToolbar2.Size = New System.Drawing.Size(28, 328)
			Me.nToolbar2.Text = "nToolbar2"
			' 
			' m_HasGripperCheck
			' 
			Me.m_HasGripperCheck.Location = New System.Drawing.Point(56, 296)
			Me.m_HasGripperCheck.Name = "m_HasGripperCheck"
			Me.m_HasGripperCheck.Size = New System.Drawing.Size(88, 24)
			Me.m_HasGripperCheck.TabIndex = 4
			Me.m_HasGripperCheck.Text = "Has Gripper"
			Me.m_HasGripperCheck.TransparentBackground = True
'			Me.m_HasGripperCheck.CheckedChanged += New System.EventHandler(Me.m_HasGripperCheck_CheckedChanged);
			' 
			' m_ShowTooltipsCheck
			' 
			Me.m_ShowTooltipsCheck.Location = New System.Drawing.Point(56, 344)
			Me.m_ShowTooltipsCheck.Name = "m_ShowTooltipsCheck"
			Me.m_ShowTooltipsCheck.Size = New System.Drawing.Size(96, 24)
			Me.m_ShowTooltipsCheck.TabIndex = 5
			Me.m_ShowTooltipsCheck.Text = "Show Tooltips"
			Me.m_ShowTooltipsCheck.TransparentBackground = True
'			Me.m_ShowTooltipsCheck.CheckedChanged += New System.EventHandler(Me.m_ShowTooltipsCheck_CheckedChanged);
			' 
			' m_HasBorderCheck
			' 
			Me.m_HasBorderCheck.Location = New System.Drawing.Point(56, 320)
			Me.m_HasBorderCheck.Name = "m_HasBorderCheck"
			Me.m_HasBorderCheck.Size = New System.Drawing.Size(88, 24)
			Me.m_HasBorderCheck.TabIndex = 9
			Me.m_HasBorderCheck.Text = "Has Border"
			Me.m_HasBorderCheck.TransparentBackground = True
'			Me.m_HasBorderCheck.CheckedChanged += New System.EventHandler(Me.m_HasBorderCheck_CheckedChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(56, 240)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(96, 23)
			Me.label1.TabIndex = 10
			Me.label1.Text = "Background Type:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' m_BackgroundTypeCombo
			' 
			Me.m_BackgroundTypeCombo.Location = New System.Drawing.Point(56, 264)
			Me.m_BackgroundTypeCombo.Name = "m_BackgroundTypeCombo"
			Me.m_BackgroundTypeCombo.Size = New System.Drawing.Size(176, 24)
			Me.m_BackgroundTypeCombo.TabIndex = 11
			Me.m_BackgroundTypeCombo.Text = "nComboBox1"
'			Me.m_BackgroundTypeCombo.SelectedIndexChanged += New System.EventHandler(Me.m_BackgroundTypeCombo_SelectedIndexChanged);
			' 
			' NCommandAppearanceUC
			' 
			Me.BackgroundImage = (CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image))
			Me.Controls.Add(Me.m_BackgroundTypeCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_HasBorderCheck)
			Me.Controls.Add(Me.m_ShowTooltipsCheck)
			Me.Controls.Add(Me.m_HasGripperCheck)
			Me.Controls.Add(Me.nToolbar3)
			Me.Controls.Add(Me.nToolbar2)
			Me.Controls.Add(Me.nToolbar1)
			Me.Name = "NCommandAppearanceUC"
			Me.Size = New System.Drawing.Size(352, 368)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.IContainer

		Private nCommand22 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand20 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand23 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand26 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand24 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand7 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand8 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand17 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand18 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand19 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand21 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand6 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand27 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand36 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand35 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand37 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand39 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand38 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand30 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand31 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand32 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand33 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand34 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand28 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand5 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand11 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand10 As Nevron.UI.WinForm.Controls.NCommand
		Private nToolbar1 As Nevron.UI.WinForm.Controls.NToolbar
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand9 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand12 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand13 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand15 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand16 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand14 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand4 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand25 As Nevron.UI.WinForm.Controls.NCommand
		Private m_ImageList As System.Windows.Forms.ImageList
		Private nCommand29 As Nevron.UI.WinForm.Controls.NCommand
		Private nToolbar3 As Nevron.UI.WinForm.Controls.NToolbar
		Private nToolbar2 As Nevron.UI.WinForm.Controls.NToolbar
		Private WithEvents m_HasGripperCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_HasBorderCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents m_BackgroundTypeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents m_ShowTooltipsCheck As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
