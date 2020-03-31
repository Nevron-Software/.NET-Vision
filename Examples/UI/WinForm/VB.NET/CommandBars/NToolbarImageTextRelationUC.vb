Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NToolbarImageTextRelationUC.
	''' </summary>
	Public Class NToolbarImageTextRelationUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
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

			Dock = DockStyle.Fill

			relationCombo.FillFromEnum(GetType(ImageTextRelation))
			relationCombo.SelectedItem = ImageTextRelation.ImageBeforeText
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub relationCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles relationCombo.SelectedIndexChanged
			nToolbar1.ImageTextRelation = CType(relationCombo.SelectedItem, ImageTextRelation)
		End Sub
		Private Sub verticalCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles verticalCheck.CheckedChanged
			If verticalCheck.Checked Then
				nToolbar1.CommandLayout = CommandLayout.VerticalSingleColumn
			Else
				nToolbar1.CommandLayout = CommandLayout.HorizontalSingleRow
			End If
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NToolbarImageTextRelationUC))
			Me.nToolbar1 = New Nevron.UI.WinForm.Controls.NToolbar()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand5 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand6 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.label1 = New System.Windows.Forms.Label()
			Me.relationCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.verticalCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCommand9 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand10 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand11 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand12 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand13 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand14 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.SuspendLayout()
			' 
			' nToolbar1
			' 
			Me.nToolbar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.ControlSpecific
			Me.nToolbar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1, Me.nCommand2, Me.nCommand3, Me.nCommand4, Me.nCommand5, Me.nCommand6})
			Me.nToolbar1.CommandSize = New System.Drawing.Size(32, 32)
			Me.nToolbar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.ImageAndText
			Me.nToolbar1.HasBorder = True
			Me.nToolbar1.HasGripper = False
			Me.nToolbar1.ImageSize = New System.Drawing.Size(24, 24)
			Me.nToolbar1.Location = New System.Drawing.Point(8, 8)
			Me.nToolbar1.Name = "nToolbar1"
			Me.nToolbar1.Size = New System.Drawing.Size(466, 38)
			Me.nToolbar1.Text = "nToolbar1"
			' 
			' nCommand1
			' 
			Me.nCommand1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand9, Me.nCommand10})
			Me.nCommand1.Properties.ImageInfo.Image = (CType(resources.GetObject("resource.Image"), System.Drawing.Image))
			Me.nCommand1.Properties.Text = "Mail"
			' 
			' nCommand2
			' 
			Me.nCommand2.Properties.ImageInfo.Image = (CType(resources.GetObject("resource.Image1"), System.Drawing.Image))
			Me.nCommand2.Properties.Text = "Calendar"
			' 
			' nCommand3
			' 
			Me.nCommand3.Properties.ImageInfo.Image = (CType(resources.GetObject("resource.Image2"), System.Drawing.Image))
			Me.nCommand3.Properties.Text = "Contacts"
			' 
			' nCommand4
			' 
			Me.nCommand4.Properties.ImageInfo.Image = (CType(resources.GetObject("resource.Image3"), System.Drawing.Image))
			Me.nCommand4.Properties.Text = "Tasks"
			' 
			' nCommand5
			' 
			Me.nCommand5.Properties.ImageInfo.Image = (CType(resources.GetObject("resource.Image4"), System.Drawing.Image))
			Me.nCommand5.Properties.Text = "Notes"
			' 
			' nCommand6
			' 
			Me.nCommand6.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand11, Me.nCommand12, Me.nCommand13, Me.nCommand14})
			Me.nCommand6.Properties.ImageInfo.Image = (CType(resources.GetObject("resource.Image5"), System.Drawing.Image))
			Me.nCommand6.Properties.Text = "Folders"
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(120, 72)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(120, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Image Text Relation:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' relationCombo
			' 
			Me.relationCombo.Location = New System.Drawing.Point(248, 72)
			Me.relationCombo.Name = "relationCombo"
			Me.relationCombo.Size = New System.Drawing.Size(192, 24)
			Me.relationCombo.TabIndex = 2
			Me.relationCombo.Text = "nComboBox1"
'			Me.relationCombo.SelectedIndexChanged += New System.EventHandler(Me.relationCombo_SelectedIndexChanged);
			' 
			' verticalCheck
			' 
			Me.verticalCheck.ButtonProperties.BorderOffset = 2
			Me.verticalCheck.Location = New System.Drawing.Point(248, 104)
			Me.verticalCheck.Name = "verticalCheck"
			Me.verticalCheck.Size = New System.Drawing.Size(192, 24)
			Me.verticalCheck.TabIndex = 4
			Me.verticalCheck.Text = "Vertical Layout"
'			Me.verticalCheck.CheckedChanged += New System.EventHandler(Me.verticalCheck_CheckedChanged);
			' 
			' nCommand9
			' 
			Me.nCommand9.Properties.Text = "Sub Command 1"
			' 
			' nCommand10
			' 
			Me.nCommand10.Properties.Text = "Sub Command 2"
			' 
			' nCommand11
			' 
			Me.nCommand11.Properties.Text = "Sub Command 1"
			' 
			' nCommand12
			' 
			Me.nCommand12.Properties.Text = "Sub Command 2"
			' 
			' nCommand13
			' 
			Me.nCommand13.Properties.Text = "Sub Command 3"
			' 
			' nCommand14
			' 
			Me.nCommand14.Properties.Text = "Sub Command 4"
			' 
			' NToolbarImageTextRelationUC
			' 
			Me.Controls.Add(Me.verticalCheck)
			Me.Controls.Add(Me.relationCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nToolbar1)
			Me.Name = "NToolbarImageTextRelationUC"
			Me.Size = New System.Drawing.Size(488, 144)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nToolbar1 As Nevron.UI.WinForm.Controls.NToolbar
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand4 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand5 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand6 As Nevron.UI.WinForm.Controls.NCommand
		Private label1 As System.Windows.Forms.Label
		Private WithEvents verticalCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nCommand9 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand10 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand11 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand12 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand13 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand14 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents relationCombo As Nevron.UI.WinForm.Controls.NComboBox

		#End Region
	End Class
End Namespace
