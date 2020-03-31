Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NTaskDialogUC.
	''' </summary>
	Public Class NTaskDialogExtendedUC
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

			Dim item As NImageAndTextItem
			Dim text As String

			Dim t As Type = Me.GetType()
			Dim path As String = "Nevron.Examples.UI.WinForm.Resources.Images.TaskDialog"

			m_TaskDialog = New NTaskDialog()
			m_TaskDialog.PreferredWidth = 350
			m_TaskDialog.PredefinedButtons = TaskDialogButtons.Yes Or TaskDialogButtons.No Or TaskDialogButtons.Cancel
			m_TaskDialog.Title = "Nevron User Interface for .NET"

			'customize header
			item = m_TaskDialog.Content
			item.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			item.TreatAsOneEntity = False
			item.ImageAlign = ContentAlignment.BottomRight
			item.TextAlign = ContentAlignment.TopLeft
			item.ImageTextRelation = ImageTextRelation.None
			item.ImageAlpha = 0.5f
			item.Image = NResourceHelper.BitmapFromResource(t, "computer_48_hot.png", path)
			item.ImageSize = New NSize(48, 48)
			item.Style.TextFillStyle = New NAdvancedGradientFillStyle(AdvancedGradientScheme.Red, 8)
			item.Style.TextShadowStyle = New NShadowStyle(ShadowType.LinearBlur, Color.Gray, 1, 1, 1F, 1)

			text = "<b><font size='10' face='Verdana' color='navy'>Nevron User Interface for .NET Q4 2006 is available!</font></b>"
			text &= "<br/><br/>Following are the new features:"
			text &= "<br/><br/><u>Chart for .NET:</u><br/><br/>"
			text &= "<ul liststyletype='decimal'>"
			text &= "<li>Brand new axis model.</li>"
			text &= "<li>Greatly improved date-time support.</li>"
			text &= "<li>Date-time scrolling.</li>"
			text &= "</ul>"

			text &= "<br/><u>User Interface for .NET:</u><br/><br/>"
			text &= "<ul liststyletype='decimal'>"
			text &= "<li>Extended DateTimePicker.</li>"
			text &= "<li>Vista-like TaskDialog.</li>"
			text &= "<li>Hyper-links per element basis.</li>"
			text &= "</ul>"
			text &= "<br/><font size='10' color='black'>Download the new version now?</font>"
			item.Text = text

			item = m_TaskDialog.Footer
			AddHandler item.HyperLinkClick, AddressOf OnFooterHyperLinkClick
			Dim icon As Icon = SystemIcons.Information
			Dim imageSize As NSize = New NSize(icon.Width, icon.Height)
			item.Image = NSystemImages.Information
			item.ImageSize = imageSize

			text = "For more information visit <a href='http://www.nevron.com/News.aspx?content=News'>www.nevron.com</a>"
			item.Text = text

			item = m_TaskDialog.Verification
			item.Text = "In future download new versions automatically"

			propertyGrid.SelectedObject = m_TaskDialog
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub showDialogButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showDialogButton.Click
			Dim result As Integer = m_TaskDialog.Show()
			Me.dialogResultLabel.Text = result.ToString()
		End Sub

		Private Sub OnFooterHyperLinkClick(ByVal sender As Object, ByVal e As NHyperLinkEventArgs)
			Process.Start(e.Url)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.showDialogButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.propertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.dialogResultLabel = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' showDialogButton
			' 
			Me.showDialogButton.Location = New System.Drawing.Point(160, 336)
			Me.showDialogButton.Name = "showDialogButton"
			Me.showDialogButton.Size = New System.Drawing.Size(104, 24)
			Me.showDialogButton.TabIndex = 0
			Me.showDialogButton.Text = "Show Dialog..."
'			Me.showDialogButton.Click += New System.EventHandler(Me.showDialogButton_Click);
			' 
			' propertyGrid
			' 
			Me.propertyGrid.CommandsVisibleIfAvailable = True
			Me.propertyGrid.LargeButtons = False
			Me.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.propertyGrid.Location = New System.Drawing.Point(0, 24)
			Me.propertyGrid.Name = "propertyGrid"
			Me.propertyGrid.Size = New System.Drawing.Size(264, 304)
			Me.propertyGrid.TabIndex = 4
			Me.propertyGrid.Text = "propertyGrid1"
			Me.propertyGrid.ToolbarVisible = False
			Me.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
			Me.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(128, 23)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Task Dialog Properties:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(0, 336)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(96, 24)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Dialog Result:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' dialogResultLabel
			' 
			Me.dialogResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.dialogResultLabel.Location = New System.Drawing.Point(0, 360)
			Me.dialogResultLabel.Name = "dialogResultLabel"
			Me.dialogResultLabel.Size = New System.Drawing.Size(104, 24)
			Me.dialogResultLabel.TabIndex = 7
			Me.dialogResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' NTaskDialogUC
			' 
			Me.Controls.Add(Me.dialogResultLabel)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.propertyGrid)
			Me.Controls.Add(Me.showDialogButton)
			Me.Name = "NTaskDialogUC"
			Me.Size = New System.Drawing.Size(264, 384)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_TaskDialog As NTaskDialog
		Private components As System.ComponentModel.Container = Nothing
		Private propertyGrid As System.Windows.Forms.PropertyGrid
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private dialogResultLabel As System.Windows.Forms.Label
		Private WithEvents showDialogButton As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace
