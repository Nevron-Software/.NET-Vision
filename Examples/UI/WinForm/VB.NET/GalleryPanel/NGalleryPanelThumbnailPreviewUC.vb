Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NGalleryPanelThumbnailPreviewUC.
	''' </summary>
	Public Class NGalleryPanelThumbnailPreviewUC
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

			AddHandler nGalleryPanel1.ItemSelectionChanged, AddressOf nGalleryPanel1_ItemSelectionChanged

			For Each item As NGalleryItem In nGalleryPanel1.Items
				item.Label.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
				item.Label.Style.TextShadowStyle = New NShadowStyle(ShadowType.LinearBlur, Color.Gray, 1, 1, 1F, 1)
			Next item

			nGalleryItem1.Selected = True
			previewBox.Image = nGalleryItem1.Label.Image
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub nGalleryPanel1_ItemSelectionChanged(ByVal sender As Object, ByVal e As NGalleryItemSelectionChangedEventArgs)
			If e.Change = GalleryItemSelectionChange.Selected Then
				previewBox.Image = e.Item.Label.Image
			End If
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NGalleryPanelThumbnailPreviewUC))
			Me.previewBox = New System.Windows.Forms.PictureBox()
			Me.nGalleryPanel1 = New Nevron.UI.WinForm.Controls.NGalleryPanel()
			Me.nGalleryItem1 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem2 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem3 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem4 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem5 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem6 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem7 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem8 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem9 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			Me.nGalleryItem10 = New Nevron.UI.WinForm.Controls.NGalleryItem()
			CType(Me.nGalleryPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' previewBox
			' 
			Me.previewBox.Location = New System.Drawing.Point(136, 8)
			Me.previewBox.Name = "previewBox"
			Me.previewBox.Size = New System.Drawing.Size(256, 256)
			Me.previewBox.TabIndex = 0
			Me.previewBox.TabStop = False
			' 
			' nGalleryPanel1
			' 
			Me.nGalleryPanel1.ItemLayout = Nevron.UI.WinForm.Controls.GalleryPanelLayout.HorizontalStack
			Me.nGalleryPanel1.Items.AddRange(New Nevron.UI.WinForm.Controls.NGalleryItem() { Me.nGalleryItem1, Me.nGalleryItem2, Me.nGalleryItem3, Me.nGalleryItem4, Me.nGalleryItem5, Me.nGalleryItem6, Me.nGalleryItem7, Me.nGalleryItem8, Me.nGalleryItem9, Me.nGalleryItem10})
			Me.nGalleryPanel1.ItemSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryPanel1.Location = New System.Drawing.Point(8, 272)
			Me.nGalleryPanel1.Name = "nGalleryPanel1"
			Me.nGalleryPanel1.Size = New System.Drawing.Size(520, 182)
			Me.nGalleryPanel1.TabIndex = 1
			Me.nGalleryPanel1.Text = "nGalleryPanel1"
			' 
			' nGalleryItem1
			' 
			Me.nGalleryItem1.Label.Image = (CType(resources.GetObject("nGalleryItem1.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem1.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem1.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem1.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem1.Label.Text = "Gallery Item 1"
			' 
			' nGalleryItem2
			' 
			Me.nGalleryItem2.Label.Image = (CType(resources.GetObject("nGalleryItem2.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem2.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem2.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem2.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem2.Label.Text = "Gallery Item 2"
			' 
			' nGalleryItem3
			' 
			Me.nGalleryItem3.Label.Image = (CType(resources.GetObject("nGalleryItem3.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem3.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem3.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem3.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem3.Label.Text = "Gallery Item 3"
			' 
			' nGalleryItem4
			' 
			Me.nGalleryItem4.Label.Image = (CType(resources.GetObject("nGalleryItem4.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem4.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem4.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem4.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem4.Label.Text = "Gallery Item 4"
			' 
			' nGalleryItem5
			' 
			Me.nGalleryItem5.Label.Image = (CType(resources.GetObject("nGalleryItem5.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem5.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem5.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem5.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem5.Label.Text = "Gallery Item 5"
			' 
			' nGalleryItem6
			' 
			Me.nGalleryItem6.Label.Image = (CType(resources.GetObject("nGalleryItem6.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem6.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem6.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem6.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem6.Label.Text = "Gallery Item 6"
			' 
			' nGalleryItem7
			' 
			Me.nGalleryItem7.Label.Image = (CType(resources.GetObject("nGalleryItem7.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem7.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem7.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem7.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem7.Label.Text = "Gallery Item 7"
			' 
			' nGalleryItem8
			' 
			Me.nGalleryItem8.Label.Image = (CType(resources.GetObject("nGalleryItem8.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem8.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem8.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem8.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem8.Label.Text = "Gallery Item 8"
			' 
			' nGalleryItem9
			' 
			Me.nGalleryItem9.Label.Image = (CType(resources.GetObject("nGalleryItem9.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem9.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem9.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem9.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem9.Label.Text = "Gallery Item 9"
			' 
			' nGalleryItem10
			' 
			Me.nGalleryItem10.Label.Image = (CType(resources.GetObject("nGalleryItem10.Label.Image"), System.Drawing.Image))
			Me.nGalleryItem10.Label.ImageSize = New Nevron.GraphicsCore.NSize(128, 128)
			Me.nGalleryItem10.Label.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nGalleryItem10.Label.Padding = New Nevron.UI.NPadding(4)
			Me.nGalleryItem10.Label.Text = "Gallery Item 10"
			' 
			' NGalleryPanelThumbnailPreviewUC
			' 
			Me.Controls.Add(Me.nGalleryPanel1)
			Me.Controls.Add(Me.previewBox)
			Me.Name = "NGalleryPanelThumbnailPreviewUC"
			Me.Size = New System.Drawing.Size(560, 472)
			CType(Me.nGalleryPanel1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private previewBox As System.Windows.Forms.PictureBox
		Private nGalleryItem1 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem2 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem3 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem4 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem5 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem6 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem7 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem8 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem9 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryItem10 As Nevron.UI.WinForm.Controls.NGalleryItem
		Private nGalleryPanel1 As Nevron.UI.WinForm.Controls.NGalleryPanel

		#End Region
	End Class
End Namespace
