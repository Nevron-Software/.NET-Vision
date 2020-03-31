Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NTooltipUC.
	''' </summary>
	Public Class NTooltipUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			m_Properties.SelectedObject = nTooltip1
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
				If Not nTooltip1 Is Nothing Then
					nTooltip1.Dispose()
				End If

			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nRichTextLabel1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles nRichTextLabel1.MouseEnter
			nTooltip1.SetTooltip(nRichTextLabel1)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NTooltipUC))
			Me.nRichTextLabel1 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.m_Properties = New System.Windows.Forms.PropertyGrid()
			Me.nTooltip1 = New Nevron.UI.WinForm.Controls.NTooltip()
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nRichTextLabel1
			' 
			Me.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRichTextLabel1.Item.Padding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nRichTextLabel1.Item.Style.RichTextFormat = New Nevron.UI.NRichTextFormat(Nevron.GraphicsCore.LineTrimStyle.Word, Nevron.GraphicsCore.ParagraphAlignment.Center, 0, 0, 0, 0, 0, 0, 0)
			Me.nRichTextLabel1.Location = New System.Drawing.Point(8, 8)
			Me.nRichTextLabel1.Name = "nRichTextLabel1"
			Me.nRichTextLabel1.Size = New System.Drawing.Size(208, 72)
			Me.nRichTextLabel1.TabIndex = 0
			Me.nRichTextLabel1.Text = "Hover this label to display the tooltip. Change tooltip's content properties from" & " the property grid."
'			Me.nRichTextLabel1.MouseEnter += New System.EventHandler(Me.nRichTextLabel1_MouseEnter);
			' 
			' m_Properties
			' 
			Me.m_Properties.CommandsVisibleIfAvailable = True
			Me.m_Properties.LargeButtons = False
			Me.m_Properties.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.m_Properties.Location = New System.Drawing.Point(224, 8)
			Me.m_Properties.Name = "m_Properties"
			Me.m_Properties.Size = New System.Drawing.Size(256, 272)
			Me.m_Properties.TabIndex = 1
			Me.m_Properties.Text = "propertyGrid1"
			Me.m_Properties.ToolbarVisible = False
			Me.m_Properties.ViewBackColor = System.Drawing.SystemColors.Window
			Me.m_Properties.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' nTooltip1
			' 
			Me.nTooltip1.Content.AutoSizeMask = Nevron.UI.AutoSizeMask.Both
			Me.nTooltip1.Content.Image = (CType(resources.GetObject("nTooltip1.Content.Image"), System.Drawing.Image))
			Me.nTooltip1.Content.ImageAlign = System.Drawing.ContentAlignment.TopLeft
			Me.nTooltip1.Content.ImageSize = New Nevron.GraphicsCore.NSize(32, 32)
			Me.nTooltip1.Content.Padding = New Nevron.UI.NPadding(0, 2, 0, 0)
			Me.nTooltip1.Content.Text = "The Nevron NTooltip component allows you<br/>to display <b>Office 2007</b> style " & "super tooltips<br/>with support for <u>rich</u> text and images."
			Me.nTooltip1.Content.TextAlign = System.Drawing.ContentAlignment.TopLeft
			Me.nTooltip1.Content.TreatAsOneEntity = False
			Me.nTooltip1.Heading.AutoSizeMask = Nevron.UI.AutoSizeMask.Both
			Me.nTooltip1.Heading.ImageAlign = System.Drawing.ContentAlignment.TopLeft
			Me.nTooltip1.Heading.Text = "<b>Nevron NTooltip</b>"
			Me.nTooltip1.Heading.TextAlign = System.Drawing.ContentAlignment.TopLeft
			Me.nTooltip1.Heading.TreatAsOneEntity = False
			Me.nTooltip1.HideDelay = 100
			Me.nTooltip1.ShowDelay = 700
			' 
			' NTooltipUC
			' 
			Me.Controls.Add(Me.m_Properties)
			Me.Controls.Add(Me.nRichTextLabel1)
			Me.Name = "NTooltipUC"
			Me.Size = New System.Drawing.Size(488, 288)
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private WithEvents nRichTextLabel1 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private m_Properties As System.Windows.Forms.PropertyGrid
		Private nTooltip1 As Nevron.UI.WinForm.Controls.NTooltip
		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
