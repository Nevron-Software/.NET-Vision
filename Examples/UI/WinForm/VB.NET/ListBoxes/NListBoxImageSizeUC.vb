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
	''' Summary description for NListBoxImageSizeUC.
	''' </summary>
	Public Class NListBoxImageSizeUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			m_iSuspendUpdate += 1
			InitializeComponent()

			Dock = DockStyle.Fill

			m_iSuspendUpdate -= 1
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_iSuspendUpdate += 1
			Dim i As Integer

			Dim item As NListBoxItem

			For i = 0 To 9
				item = New NListBoxItem(-1, "NListBoxItem" & i)
				If i = 9 Then
					item.Height = 50
				End If
				nListBox1.Items.Add(item)
			Next i

			m_ImageSizeWidthNumeric.Value = nListBox1.ImageSize.Width
			m_ImageSizeHeightNumeric.Value = nListBox1.ImageSize.Height

			nListBox1.DefaultImageIndex = 0
			'nListBox1.ScrollAlwaysVisible = true;

			Dim count As Integer = imageList1.Images.Count

			i = 0
			Do While i < count
				item = New NListBoxItem(i, i.ToString(), False)
				comboBox1.Items.Add(item)
				i += 1
			Loop

			comboBox1.SelectedIndex = 0

			m_iSuspendUpdate -= 1
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

		Private Sub m_ImageSizeWidthNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ImageSizeWidthNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			Dim sz As Size = New Size(CInt(Fix(m_ImageSizeWidthNumeric.Value)), nListBox1.ImageSize.Height)
			nListBox1.ImageSize = sz
		End Sub

		Private Sub m_ImageSizeHeightNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ImageSizeHeightNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			Dim sz As Size = New Size(nListBox1.ImageSize.Width, CInt(Fix(m_ImageSizeHeightNumeric.Value)))
			nListBox1.ImageSize = sz
		End Sub

		Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboBox1.SelectedIndexChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			nListBox1.DefaultImageIndex = comboBox1.SelectedIndex
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NListBoxImageSizeUC))
			Me.nListBox1 = New Nevron.UI.WinForm.Controls.NListBox()
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_ImageSizeWidthNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_ImageSizeHeightNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.comboBox1 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label3 = New System.Windows.Forms.Label()
			CType(Me.m_ImageSizeWidthNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_ImageSizeHeightNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nListBox1
			' 
			Me.nListBox1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nListBox1.ImageList = Me.imageList1
			Me.nListBox1.ImageSize = New Size(32, 32)
			Me.nListBox1.ItemHeight = 50
			Me.nListBox1.Location = New System.Drawing.Point(8, 8)
			Me.nListBox1.Name = "nListBox1"
			Me.nListBox1.Size = New System.Drawing.Size(288, 254)
			Me.nListBox1.TabIndex = 4
			' 
			' imageList1
			' 
			Me.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
			Me.imageList1.ImageSize = New System.Drawing.Size(32, 32)
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.Location = New System.Drawing.Point(8, 272)
			Me.label1.Name = "label1"
			Me.label1.TabIndex = 5
			Me.label1.Text = "Image Size Width:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label2
			' 
			Me.label2.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label2.Location = New System.Drawing.Point(8, 296)
			Me.label2.Name = "label2"
			Me.label2.TabIndex = 6
			Me.label2.Text = "Image Size Height:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_ImageSizeWidthNumeric
			' 
			Me.m_ImageSizeWidthNumeric.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_ImageSizeWidthNumeric.Location = New System.Drawing.Point(112, 272)
			Me.m_ImageSizeWidthNumeric.Maximum = New System.Decimal(New Integer() { 46, 0, 0, 0})
			Me.m_ImageSizeWidthNumeric.Minimum = New System.Decimal(New Integer() { 4, 0, 0, 0})
			Me.m_ImageSizeWidthNumeric.Name = "m_ImageSizeWidthNumeric"
			Me.m_ImageSizeWidthNumeric.Size = New System.Drawing.Size(96, 20)
			Me.m_ImageSizeWidthNumeric.TabIndex = 7
			Me.m_ImageSizeWidthNumeric.Value = New System.Decimal(New Integer() { 4, 0, 0, 0})
'			Me.m_ImageSizeWidthNumeric.ValueChanged += New System.EventHandler(Me.m_ImageSizeWidthNumeric_ValueChanged);
			' 
			' m_ImageSizeHeightNumeric
			' 
			Me.m_ImageSizeHeightNumeric.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.m_ImageSizeHeightNumeric.Location = New System.Drawing.Point(112, 296)
			Me.m_ImageSizeHeightNumeric.Maximum = New System.Decimal(New Integer() { 46, 0, 0, 0})
			Me.m_ImageSizeHeightNumeric.Minimum = New System.Decimal(New Integer() { 4, 0, 0, 0})
			Me.m_ImageSizeHeightNumeric.Name = "m_ImageSizeHeightNumeric"
			Me.m_ImageSizeHeightNumeric.Size = New System.Drawing.Size(96, 20)
			Me.m_ImageSizeHeightNumeric.TabIndex = 8
			Me.m_ImageSizeHeightNumeric.Value = New System.Decimal(New Integer() { 4, 0, 0, 0})
'			Me.m_ImageSizeHeightNumeric.ValueChanged += New System.EventHandler(Me.m_ImageSizeHeightNumeric_ValueChanged);
			' 
			' comboBox1
			' 
			Me.comboBox1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.comboBox1.ImageList = Me.imageList1
			Me.comboBox1.Location = New System.Drawing.Point(112, 320)
			Me.comboBox1.Name = "comboBox1"
			Me.comboBox1.Size = New System.Drawing.Size(96, 21)
			Me.comboBox1.TabIndex = 9
'			Me.comboBox1.SelectedIndexChanged += New System.EventHandler(Me.comboBox1_SelectedIndexChanged);
			' 
			' label3
			' 
			Me.label3.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label3.Location = New System.Drawing.Point(8, 320)
			Me.label3.Name = "label3"
			Me.label3.TabIndex = 10
			Me.label3.Text = "Image Index:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' NListBoxImageSizeUC
			' 
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.comboBox1)
			Me.Controls.Add(Me.m_ImageSizeHeightNumeric)
			Me.Controls.Add(Me.m_ImageSizeWidthNumeric)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nListBox1)
			Me.Name = "NListBoxImageSizeUC"
			Me.Size = New System.Drawing.Size(304, 352)
			CType(Me.m_ImageSizeWidthNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_ImageSizeHeightNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents m_ImageSizeWidthNumeric As NNumericUpDown
		Private WithEvents m_ImageSizeHeightNumeric As NNumericUpDown
		Private nListBox1 As Nevron.UI.WinForm.Controls.NListBox
		Private WithEvents comboBox1 As NComboBox
		Private label3 As System.Windows.Forms.Label
		Private imageList1 As System.Windows.Forms.ImageList
		Private components As System.ComponentModel.IContainer

		#End Region
	End Class
End Namespace
