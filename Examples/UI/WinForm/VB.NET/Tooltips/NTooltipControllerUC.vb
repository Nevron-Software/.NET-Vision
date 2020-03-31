Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NTooltipControllerUC.
	''' </summary>
	Public Class NTooltipControllerUC
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


		#End Region

		#Region "Event Handlers"

		Private Sub nRichTextLabel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nRichTextLabel1.MouseDown, nRichTextLabel2.MouseDown
			Dim nc As NControl = CType(sender, NControl)
			propertyGrid.SelectedObject = nc.TooltipInfo
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NTooltipControllerUC))
			Me.nRichTextLabel1 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.propertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.nRichTextLabel2 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nRichTextLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nRichTextLabel1
			' 
			Me.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRichTextLabel1.Location = New System.Drawing.Point(8, 344)
			Me.nRichTextLabel1.Name = "nRichTextLabel1"
			Me.nRichTextLabel1.Size = New System.Drawing.Size(192, 72)
			Me.nRichTextLabel1.StrokeInfo.PenWidth = 3
			Me.nRichTextLabel1.StrokeInfo.Rounding = 5
			Me.nRichTextLabel1.TabIndex = 1
			Me.nRichTextLabel1.Text = "Rich Text Label 1<br/><b>Click to see its TooltipInfo.</b>"
			Me.nRichTextLabel1.TooltipInfo.CaptionText = "<b>Rich Text Label 1</b>"
			Me.nRichTextLabel1.TooltipInfo.ContentImage = (CType(resources.GetObject("nRichTextLabel1.TooltipInfo.ContentImage"), System.Drawing.Image))
			Me.nRichTextLabel1.TooltipInfo.ContentImageSize = New Nevron.GraphicsCore.NSize(32, 32)
			Me.nRichTextLabel1.TooltipInfo.ContentText = "Sample tooltip over<br/><b>Note</b> the <font face='Verdana' size='10' color='Red" & "'>rich</font> text formatting."
			Me.nRichTextLabel1.TooltipInfo.FooterImage = (CType(resources.GetObject("nRichTextLabel1.TooltipInfo.FooterImage"), System.Drawing.Image))
			Me.nRichTextLabel1.TooltipInfo.FooterText = "Press F1 for more help."
'			Me.nRichTextLabel1.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.nRichTextLabel1_MouseDown);
			' 
			' propertyGrid
			' 
			Me.propertyGrid.CommandsVisibleIfAvailable = True
			Me.propertyGrid.LargeButtons = False
			Me.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.propertyGrid.Location = New System.Drawing.Point(8, 8)
			Me.propertyGrid.Name = "propertyGrid"
			Me.propertyGrid.Size = New System.Drawing.Size(384, 328)
			Me.propertyGrid.TabIndex = 3
			Me.propertyGrid.Text = "propertyGrid1"
			Me.propertyGrid.ToolbarVisible = False
			Me.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
			Me.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' nRichTextLabel2
			' 
			Me.nRichTextLabel2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRichTextLabel2.Location = New System.Drawing.Point(208, 344)
			Me.nRichTextLabel2.Name = "nRichTextLabel2"
			Me.nRichTextLabel2.Size = New System.Drawing.Size(192, 72)
			Me.nRichTextLabel2.StrokeInfo.PenWidth = 3
			Me.nRichTextLabel2.StrokeInfo.Rounding = 5
			Me.nRichTextLabel2.TabIndex = 4
			Me.nRichTextLabel2.Text = "Rich Text Label 2<br/><b>Click to see its TooltipInfo.</b>"
			Me.nRichTextLabel2.TooltipInfo.Background = New Nevron.UI.NImageShape(System.Drawing.Drawing2D.SmoothingMode.Default, New Nevron.GraphicsCore.NSize(0, 0), New Nevron.UI.NPadding(0, 0, 0, 0), Nothing, (CType(resources.GetObject("resource"), System.Drawing.Bitmap)), Nothing, -1, Nevron.UI.ImageSizeMode.Stretch, True, Nevron.UI.ImageSegment.All, New Nevron.UI.NPadding(4))
			Me.nRichTextLabel2.TooltipInfo.CaptionText = "<b>Rich Text Label 2</b>"
			Me.nRichTextLabel2.TooltipInfo.ContentImage = (CType(resources.GetObject("nRichTextLabel2.TooltipInfo.ContentImage"), System.Drawing.Image))
			Me.nRichTextLabel2.TooltipInfo.ContentImageSize = New Nevron.GraphicsCore.NSize(32, 32)
			Me.nRichTextLabel2.TooltipInfo.ContentText = "Sample tooltip<br/><b>Note</b> the <font face='Verdana' size='10' color='Red' sha" & "dowcolor='yellow' shadowtype='solid'>custom</font> background specified."
			Me.nRichTextLabel2.TooltipInfo.DefaultBorder = False
			Me.nRichTextLabel2.TooltipInfo.EnableSkinning = False
			Me.nRichTextLabel2.TooltipInfo.FooterImage = (CType(resources.GetObject("nRichTextLabel2.TooltipInfo.FooterImage"), System.Drawing.Image))
			Me.nRichTextLabel2.TooltipInfo.FooterText = "Press F1 for more help."
			Me.nRichTextLabel2.TooltipInfo.Padding = New Nevron.UI.NPadding(5, 5, 4, 4)
'			Me.nRichTextLabel2.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.nRichTextLabel1_MouseDown);
			' 
			' NTooltipControllerUC
			' 
			Me.Controls.Add(Me.nRichTextLabel2)
			Me.Controls.Add(Me.propertyGrid)
			Me.Controls.Add(Me.nRichTextLabel1)
			Me.Name = "NTooltipControllerUC"
			Me.Size = New System.Drawing.Size(400, 416)
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nRichTextLabel2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private WithEvents nRichTextLabel1 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private propertyGrid As System.Windows.Forms.PropertyGrid
		Private WithEvents nRichTextLabel2 As Nevron.UI.WinForm.Controls.NRichTextLabel

		#End Region
	End Class
End Namespace
