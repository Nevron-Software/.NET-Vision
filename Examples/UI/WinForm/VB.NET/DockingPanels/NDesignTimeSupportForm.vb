Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NDesignTimeSupportForm.
	''' </summary>
	Public Class NDesignTimeSupportForm
		Inherits System.Windows.Forms.Form
		Private nDockManager1 As Nevron.UI.WinForm.Docking.NDockManager
		Private nDockingPanel1 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nColorPool1 As Nevron.UI.WinForm.Controls.NColorPool
		Private nDockingPanel2 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private imageList1 As System.Windows.Forms.ImageList
		Private nDockingPanel3 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel4 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private nColorBar1 As Nevron.UI.WinForm.Controls.NColorBar
		Private nComboBox1 As Nevron.UI.WinForm.Controls.NComboBox
		Private nDockingPanel5 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nOptionButton1 As Nevron.UI.WinForm.Controls.NOptionButton
		Private nCommand1 As Nevron.UI.WinForm.Controls.NCommand
		Private nCommand2 As Nevron.UI.WinForm.Controls.NCommand
		Private nDockingPanel6 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel7 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel8 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nDockingPanel9 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private nRadioButton1 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nWaitingBar1 As Nevron.UI.WinForm.Controls.NWaitingBar
		Private nProgressBar1 As Nevron.UI.WinForm.Controls.NProgressBar
		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private nCommandBarsManager1 As Nevron.UI.WinForm.Controls.NCommandBarsManager
		Private nMenuBar1 As Nevron.UI.WinForm.Controls.NMenuBar
		Private nCommand3 As Nevron.UI.WinForm.Controls.NCommand
		Private WithEvents nCommand4 As Nevron.UI.WinForm.Controls.NCommand
		Private components As System.ComponentModel.IContainer

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			nDockManager1.RootContainer.BringToFront()

			'add some documents to the framework
			Dim doc As NUIDocument

			For i As Integer = 1 To 4
				doc = New NUIDocument("Nevron Document " & i.ToString(), 0)
				doc.Client = GetTextBox()
				nDockManager1.DocumentManager.AddDocument(doc)
			Next i

			nDockManager1.Palette.Copy(NUIManager.Palette)
			nCommandBarsManager1.Palette.Copy(NUIManager.Palette)

			nComboBox1.Items.Add("NlistBoxItem1")
			nComboBox1.Items.Add("NlistBoxItem2")
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
				If Not nDockManager1 Is Nothing Then
					nDockManager1.Dispose()
				End If

			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Function GetTextBox() As TextBox
			Dim tb As TextBox = New TextBox()
			tb.Multiline = True
			tb.Dock = DockStyle.Fill

			Return tb
		End Function

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim nDockZone0 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone1 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone2 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone3 As Nevron.UI.WinForm.Docking.NDockZone = New Nevron.UI.WinForm.Docking.NDockZone()
			Dim nDockZone4 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone6 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone7 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim nDockZone8 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NDesignTimeSupportForm))
			Me.nDockManager1 = New Nevron.UI.WinForm.Docking.NDockManager()
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.nDockingPanel1 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nColorPool1 = New Nevron.UI.WinForm.Controls.NColorPool()
			Me.nDockingPanel2 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nComboBox1 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nDockingPanel3 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockingPanel4 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nColorBar1 = New Nevron.UI.WinForm.Controls.NColorBar()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nDockingPanel5 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nOptionButton1 = New Nevron.UI.WinForm.Controls.NOptionButton()
			Me.nCommand1 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand2 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nDockingPanel6 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.nDockingPanel7 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nDockingPanel8 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nProgressBar1 = New Nevron.UI.WinForm.Controls.NProgressBar()
			Me.nDockingPanel9 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nWaitingBar1 = New Nevron.UI.WinForm.Controls.NWaitingBar()
			Me.nRadioButton1 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nCommandBarsManager1 = New Nevron.UI.WinForm.Controls.NCommandBarsManager(Me.components)
			Me.nMenuBar1 = New Nevron.UI.WinForm.Controls.NMenuBar()
			Me.nCommand3 = New Nevron.UI.WinForm.Controls.NCommand()
			Me.nCommand4 = New Nevron.UI.WinForm.Controls.NCommand()
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDockingPanel1.SuspendLayout()
			Me.nDockingPanel2.SuspendLayout()
			Me.nDockingPanel4.SuspendLayout()
			Me.nDockingPanel5.SuspendLayout()
			Me.nDockingPanel6.SuspendLayout()
			Me.nDockingPanel8.SuspendLayout()
			Me.nDockingPanel9.SuspendLayout()
			' 
			' nDockManager1
			' 
			Me.nDockManager1.DocumentStyle.ImageList = Me.imageList1
			Me.nDockManager1.Form = Me
			Me.nDockManager1.ImageList = Me.imageList1
			Me.nDockManager1.RootContainerZIndex = 4
			'  
			' Root Zone
			'  
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone0)
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1)
			Me.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Vertical
			'  
			' nDockZone0
			'  
			nDockZone0.AddChild(Me.nDockingPanel7)
			nDockZone0.AddChild(Me.nDockingPanel9)
			nDockZone0.AddChild(Me.nDockingPanel8)
			nDockZone0.Name = "nDockZone0"
			nDockZone0.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone0.Index = 0
			nDockZone0.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 111)
			'  
			' nDockZone1
			'  
			nDockZone1.AddChild(nDockZone2)
			nDockZone1.AddChild(nDockZone8)
			nDockZone1.Name = "nDockZone1"
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone1.Index = 1
			nDockZone1.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 284)
			'  
			' nDockZone2
			'  
			nDockZone2.AddChild(nDockZone3)
			nDockZone2.AddChild(nDockZone7)
			nDockZone2.Name = "nDockZone2"
			nDockZone2.Orientation = System.Windows.Forms.Orientation.Vertical
			nDockZone2.Index = 0
			nDockZone2.SizeInfo.PrefferedSize = New System.Drawing.Size(608, 200)
			'  
			' nDockZone3
			'  
			nDockZone3.AddChild(nDockZone4)
			nDockZone3.AddChild(Me.nDockManager1.DocumentManager.DocumentViewHost)
			nDockZone3.AddChild(nDockZone6)
			nDockZone3.Name = "nDockZone3"
			nDockZone3.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone3.Index = 0
			nDockZone3.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 298)
			'  
			' nDockZone4
			'  
			nDockZone4.AddChild(Me.nDockingPanel6)
			nDockZone4.Name = "nDockZone4"
			nDockZone4.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone4.Index = 0
			nDockZone4.SizeInfo.PrefferedSize = New System.Drawing.Size(250, 200)
			'  
			' nDockZone6
			'  
			nDockZone6.AddChild(Me.nDockingPanel1)
			nDockZone6.AddChild(Me.nDockingPanel4)
			nDockZone6.Name = "nDockZone6"
			nDockZone6.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone6.Index = 2
			nDockZone6.SizeInfo.PrefferedSize = New System.Drawing.Size(169, 200)
			'  
			' nDockZone7
			'  
			nDockZone7.AddChild(Me.nDockingPanel2)
			nDockZone7.AddChild(Me.nDockingPanel3)
			nDockZone7.Name = "nDockZone7"
			nDockZone7.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone7.Index = 1
			nDockZone7.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 132)
			'  
			' nDockZone8
			'  
			nDockZone8.AddChild(Me.nDockingPanel5)
			nDockZone8.Name = "nDockZone8"
			nDockZone8.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone8.Index = 1
			nDockZone8.SizeInfo.PrefferedSize = New System.Drawing.Size(153, 200)
			' 
			' imageList1
			' 
			Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			' 
			' nDockingPanel1
			' 
			Me.nDockingPanel1.Controls.Add(Me.nColorPool1)
			Me.nDockingPanel1.Key = "Panel 1"
			Me.nDockingPanel1.Name = "nDockingPanel1"
			Me.nDockingPanel1.SizeInfo.PrefferedSize = New System.Drawing.Size(169, 200)
			Me.nDockingPanel1.TabIndex = 1
			Me.nDockingPanel1.TabInfo.ImageIndex = 4
			' 
			' nColorPool1
			' 
			Me.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.nColorPool1.Color = System.Drawing.Color.Empty
			Me.nColorPool1.Hue = 0F
			Me.nColorPool1.Location = New System.Drawing.Point(24, 40)
			Me.nColorPool1.Luminance = 0.5F
			Me.nColorPool1.Name = "nColorPool1"
			Me.nColorPool1.Saturation = 0F
			Me.nColorPool1.Size = New System.Drawing.Size(136, 104)
			Me.nColorPool1.TabIndex = 0
			' 
			' nDockingPanel2
			' 
			Me.nDockingPanel2.Controls.Add(Me.nComboBox1)
			Me.nDockingPanel2.Key = "Panel 2"
			Me.nDockingPanel2.Name = "nDockingPanel2"
			Me.nDockingPanel2.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 132)
			Me.nDockingPanel2.TabIndex = 1
			Me.nDockingPanel2.TabInfo.ImageIndex = 0
			' 
			' nComboBox1
			' 
			Me.nComboBox1.Location = New System.Drawing.Point(16, 16)
			Me.nComboBox1.Name = "nComboBox1"
			Me.nComboBox1.Size = New System.Drawing.Size(152, 22)
			Me.nComboBox1.TabIndex = 0
			Me.nComboBox1.Text = "nComboBox1"
			' 
			' nDockingPanel3
			' 
			Me.nDockingPanel3.Key = "Panel 3"
			Me.nDockingPanel3.Name = "nDockingPanel3"
			Me.nDockingPanel3.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 132)
			Me.nDockingPanel3.TabIndex = 2
			Me.nDockingPanel3.TabInfo.ImageIndex = 1
			' 
			' nDockingPanel4
			' 
			Me.nDockingPanel4.Controls.Add(Me.nColorBar1)
			Me.nDockingPanel4.Controls.Add(Me.nButton1)
			Me.nDockingPanel4.Key = "Panel 4"
			Me.nDockingPanel4.Name = "nDockingPanel4"
			Me.nDockingPanel4.SizeInfo.PrefferedSize = New System.Drawing.Size(169, 200)
			Me.nDockingPanel4.TabIndex = 2
			Me.nDockingPanel4.TabInfo.ImageIndex = 2
			' 
			' nColorBar1
			' 
			Me.nColorBar1.Location = New System.Drawing.Point(16, 48)
			Me.nColorBar1.Name = "nColorBar1"
			Me.nColorBar1.Size = New System.Drawing.Size(128, 25)
			Me.nColorBar1.TabIndex = 1
			Me.nColorBar1.Text = "nColorBar1"
			Me.nColorBar1.Value = 125
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(16, 16)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.TabIndex = 0
			Me.nButton1.Text = "nButton1"
			' 
			' nDockingPanel5
			' 
			Me.nDockingPanel5.Controls.Add(Me.nGroupBox1)
			Me.nDockingPanel5.Controls.Add(Me.nOptionButton1)
			Me.nDockingPanel5.Key = "Panel 5"
			Me.nDockingPanel5.Name = "nDockingPanel5"
			Me.nDockingPanel5.SizeInfo.PrefferedSize = New System.Drawing.Size(153, 200)
			Me.nDockingPanel5.TabIndex = 1
			Me.nDockingPanel5.TabInfo.ImageIndex = 5
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(16, 24)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(112, 80)
			Me.nGroupBox1.TabIndex = 0
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "nGroupBox1"
			' 
			' nOptionButton1
			' 
			Me.nOptionButton1.ArrowWidth = 14
			Me.nOptionButton1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand1, Me.nCommand2})
			Me.nOptionButton1.Location = New System.Drawing.Point(8, 128)
			Me.nOptionButton1.Name = "nOptionButton1"
			Me.nOptionButton1.Size = New System.Drawing.Size(120, 23)
			Me.nOptionButton1.TabIndex = 1
			Me.nOptionButton1.Text = "nOptionButton1"
			' 
			' nDockingPanel6
			' 
			Me.nDockingPanel6.Controls.Add(Me.propertyGrid1)
			Me.nDockingPanel6.Key = "Panel 6"
			Me.nDockingPanel6.Name = "nDockingPanel6"
			Me.nDockingPanel6.SizeInfo.PrefferedSize = New System.Drawing.Size(250, 200)
			Me.nDockingPanel6.TabIndex = 1
			Me.nDockingPanel6.TabInfo.ImageIndex = 3
			Me.nDockingPanel6.Text = "Properties"
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.CommandsVisibleIfAvailable = True
			Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.propertyGrid1.LargeButtons = False
			Me.propertyGrid1.LineColor = System.Drawing.SystemColors.Control
			Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.SelectedObject = Me.nDockManager1
			Me.propertyGrid1.Size = New System.Drawing.Size(250, 353)
			Me.propertyGrid1.TabIndex = 0
			Me.propertyGrid1.Text = "propertyGrid1"
			Me.propertyGrid1.ToolbarVisible = False
			Me.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
			Me.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' nDockingPanel7
			' 
			Me.nDockingPanel7.Key = "Panel 7"
			Me.nDockingPanel7.Name = "nDockingPanel7"
			Me.nDockingPanel7.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 111)
			Me.nDockingPanel7.TabIndex = 2
			Me.nDockingPanel7.TabInfo.ImageIndex = 0
			' 
			' nDockingPanel8
			' 
			Me.nDockingPanel8.Controls.Add(Me.nProgressBar1)
			Me.nDockingPanel8.Key = "Panel 8"
			Me.nDockingPanel8.Name = "nDockingPanel8"
			Me.nDockingPanel8.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 111)
			Me.nDockingPanel8.TabIndex = 3
			Me.nDockingPanel8.TabInfo.ImageIndex = 1
			' 
			' nProgressBar1
			' 
			Me.nProgressBar1.Location = New System.Drawing.Point(232, 16)
			Me.nProgressBar1.Name = "nProgressBar1"
			Me.nProgressBar1.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient
			Me.nProgressBar1.Properties.Text = ""
			Me.nProgressBar1.Properties.Value = 50
			Me.nProgressBar1.Size = New System.Drawing.Size(160, 16)
			Me.nProgressBar1.TabIndex = 0
			Me.nProgressBar1.Text = "nProgressBar1"
			' 
			' nDockingPanel9
			' 
			Me.nDockingPanel9.Controls.Add(Me.nWaitingBar1)
			Me.nDockingPanel9.Controls.Add(Me.nRadioButton1)
			Me.nDockingPanel9.Key = "Panel 9"
			Me.nDockingPanel9.Name = "nDockingPanel9"
			Me.nDockingPanel9.SizeInfo.PrefferedSize = New System.Drawing.Size(200, 111)
			Me.nDockingPanel9.TabIndex = 4
			Me.nDockingPanel9.TabInfo.ImageIndex = 2
			' 
			' nWaitingBar1
			' 
			Me.nWaitingBar1.Location = New System.Drawing.Point(264, 16)
			Me.nWaitingBar1.Name = "nWaitingBar1"
			Me.nWaitingBar1.Size = New System.Drawing.Size(240, 16)
			Me.nWaitingBar1.TabIndex = 1
			Me.nWaitingBar1.Text = "nWaitingBar1"
			' 
			' nRadioButton1
			' 
			Me.nRadioButton1.Location = New System.Drawing.Point(32, 16)
			Me.nRadioButton1.Name = "nRadioButton1"
			Me.nRadioButton1.TabIndex = 0
			Me.nRadioButton1.Text = "nRadioButton1"
			' 
			' nCommandBarsManager1
			' 
			Me.nCommandBarsManager1.AllowCustomize = False
			Me.nCommandBarsManager1.ParentControl = Me
			Me.nCommandBarsManager1.Toolbars.Add(Me.nMenuBar1)
			' 
			' nMenuBar1
			' 
			Me.nMenuBar1.AllowDelete = False
			Me.nMenuBar1.AllowHide = False
			Me.nMenuBar1.AllowRename = False
			Me.nMenuBar1.AutoDropDownDelay = False
			Me.nMenuBar1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent
			Me.nMenuBar1.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand3})
			Me.nMenuBar1.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.Text
			Me.nMenuBar1.DefaultLocation = New System.Drawing.Point(0, 0)
			Me.nMenuBar1.HasGripper = False
			Me.nMenuBar1.HasPendantCommand = False
			Me.nMenuBar1.Name = "nMenuBar1"
			Me.nMenuBar1.PrefferedRowIndex = 0
			Me.nMenuBar1.RowIndex = 0
			Me.nMenuBar1.ShowTooltips = False
			Me.nMenuBar1.Text = "Menu Bar"
			' 
			' nCommand3
			' 
			Me.nCommand3.Commands.AddRange(New Nevron.UI.WinForm.Controls.NCommand() { Me.nCommand4})
			Me.nCommand3.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never
			Me.nCommand3.Properties.Text = "&File"
			' 
			' nCommand4
			' 
			Me.nCommand4.Properties.Text = "E&xit"
'			Me.nCommand4.Click += New Nevron.UI.WinForm.Controls.CommandEventHandler(Me.nCommand4_Click);
			' 
			' NDesignTimeSupportForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(888, 622)
			Me.Name = "NDesignTimeSupportForm"
			Me.Text = "Design-Time Generated Layout"
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDockingPanel1.ResumeLayout(False)
			Me.nDockingPanel2.ResumeLayout(False)
			Me.nDockingPanel4.ResumeLayout(False)
			Me.nDockingPanel5.ResumeLayout(False)
			Me.nDockingPanel6.ResumeLayout(False)
			Me.nDockingPanel8.ResumeLayout(False)
			Me.nDockingPanel9.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub state_ResolveDocumentClient(ByVal sender As Object, ByVal e As DocumentEventArgs)
			e.Document.Client = GetTextBox()
		End Sub

		Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
			Dim arr As ArrayList = nDockManager1.GetContainers(DockState.Floating)

			RemoveHandler Application.Idle, AddressOf Application_Idle
		End Sub

		Private Sub nCommand4_Click(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.CommandEventArgs) Handles nCommand4.Click
			Close()
		End Sub
	End Class
End Namespace
