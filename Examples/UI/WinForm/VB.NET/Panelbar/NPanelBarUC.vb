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
	Public Class NPanelBarUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
		End Sub


		#End Region

		#Region "Implementation"

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

			m_TextAlignCombo.FillFromEnum(GetType(HorizontalAlignment), False)
			m_TextAlignCombo.SelectedItem = HorizontalAlignment.Left
		End Sub




		#End Region

		#Region "Event Handlers"

		Private Sub m_TextAlignCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_TextAlignCombo.SelectedIndexChanged
			For Each band As NBand In nPanelBar1.Controls
				band.TextAlign = CType(m_TextAlignCombo.SelectedIndex, HorizontalAlignment)
			Next band
		End Sub
		Private Sub m_BorderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_BorderButton.Click
			nPanelBar1.Border.ShowEditor()
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NPanelBarUC))
			Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() { "Client1", "00 0000 000000", "Client Address"}, -1)
			Me.nPanelBar1 = New Nevron.UI.WinForm.Controls.NPanelBar()
			Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.m_TextAlignCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_BorderButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.nBand1 = New Nevron.UI.WinForm.Controls.NBand()
			Me.nBand2 = New Nevron.UI.WinForm.Controls.NBand()
			Me.nBand3 = New Nevron.UI.WinForm.Controls.NBand()
			Me.listView1 = New System.Windows.Forms.ListView()
			Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
			Me.nPanelBar1.SuspendLayout()
			Me.nBand3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nPanelBar1
			' 
			Me.nPanelBar1.Controls.Add(Me.nBand1)
			Me.nPanelBar1.Controls.Add(Me.nBand3)
			Me.nPanelBar1.Controls.Add(Me.nBand2)
			Me.nPanelBar1.Dock = System.Windows.Forms.DockStyle.Left
			Me.nPanelBar1.ImageList = Me.m_ImageList
			Me.nPanelBar1.Location = New System.Drawing.Point(0, 0)
			Me.nPanelBar1.Name = "nPanelBar1"
			Me.nPanelBar1.Size = New System.Drawing.Size(280, 368)
			Me.nPanelBar1.TabIndex = 0
			' 
			' m_ImageList
			' 
			Me.m_ImageList.ImageSize = New System.Drawing.Size(16, 16)
			Me.m_ImageList.ImageStream = (CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
			' 
			' m_TextAlignCombo
			' 
			Me.m_TextAlignCombo.Location = New System.Drawing.Point(288, 32)
			Me.m_TextAlignCombo.Name = "m_TextAlignCombo"
			Me.m_TextAlignCombo.Size = New System.Drawing.Size(184, 22)
			Me.m_TextAlignCombo.TabIndex = 1
			Me.m_TextAlignCombo.Text = "nComboBox2"
'			Me.m_TextAlignCombo.SelectedIndexChanged += New System.EventHandler(Me.m_TextAlignCombo_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(288, 8)
			Me.label1.Name = "label1"
			Me.label1.TabIndex = 2
			Me.label1.Text = "TextAlign:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' m_BorderButton
			' 
			Me.m_BorderButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
			Me.m_BorderButton.Location = New System.Drawing.Point(288, 64)
			Me.m_BorderButton.Name = "m_BorderButton"
			Me.m_BorderButton.Size = New System.Drawing.Size(104, 24)
			Me.m_BorderButton.TabIndex = 15
			Me.m_BorderButton.Text = "Border..."
'			Me.m_BorderButton.Click += New System.EventHandler(Me.m_BorderButton_Click);
			' 
			' nBand1
			' 
			Me.nBand1.Caption = "Mail"
			Me.nBand1.ImageIndex = 1
			Me.nBand1.Name = "nBand1"
			Me.nBand1.State = Nevron.UI.WinForm.Controls.BandState.Expanded
			Me.nBand1.TabIndex = 0
			' 
			' nBand2
			' 
			Me.nBand2.Caption = "Shortcuts"
			Me.nBand2.ImageIndex = 2
			Me.nBand2.Name = "nBand2"
			Me.nBand2.TabIndex = 1
			' 
			' nBand3
			' 
			Me.nBand3.Caption = "Contacts"
			Me.nBand3.Controls.Add(Me.listView1)
			Me.nBand3.ImageIndex = 3
			Me.nBand3.Name = "nBand3"
			Me.nBand3.TabIndex = 2
			' 
			' listView1
			' 
			Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
			Me.listView1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.listView1.Items.AddRange(New System.Windows.Forms.ListViewItem() { listViewItem1})
			Me.listView1.Location = New System.Drawing.Point(0, 22)
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New System.Drawing.Size(278, 0)
			Me.listView1.TabIndex = 1
			Me.listView1.View = System.Windows.Forms.View.Details
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "Name"
			' 
			' columnHeader2
			' 
			Me.columnHeader2.Text = "Phone"
			Me.columnHeader2.Width = 91
			' 
			' columnHeader3
			' 
			Me.columnHeader3.Text = "Address"
			Me.columnHeader3.Width = 119
			' 
			' NPanelBarUC
			' 
			Me.Controls.Add(Me.nPanelBar1)
			Me.Controls.Add(Me.m_BorderButton)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_TextAlignCombo)
			Me.Name = "NPanelBarUC"
			Me.Size = New System.Drawing.Size(480, 368)
			Me.nPanelBar1.ResumeLayout(False)
			Me.nBand3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.IContainer


		Private nPanelBar1 As Nevron.UI.WinForm.Controls.NPanelBar
		Private m_ImageList As System.Windows.Forms.ImageList
		Private WithEvents m_BorderButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_TextAlignCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private nBand1 As Nevron.UI.WinForm.Controls.NBand
		Private nBand2 As Nevron.UI.WinForm.Controls.NBand
		Private nBand3 As Nevron.UI.WinForm.Controls.NBand
		Private listView1 As System.Windows.Forms.ListView
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private columnHeader3 As System.Windows.Forms.ColumnHeader
		Private label1 As System.Windows.Forms.Label

		#End Region
	End Class
End Namespace
