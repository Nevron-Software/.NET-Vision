Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.UI.WinForm.Docking

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NSizingRestrictionsForm.
	''' </summary>
	Public Class NSizingRestrictionsForm
		Inherits NForm
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

				If Not nDockManager1 Is Nothing Then
					nDockManager1.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Implementation"

		Friend Sub UpdateContainer()
			Dim container As NDockingPanelContainer = nDockingPanel1.ContainerPanel
			If container Is Nothing OrElse container.DockState <> DockState.Floating Then
				Return
			End If

			Dim maxWidth As Integer = CInt(Fix(widthNumeric.Value))
			Dim maxHeight As Integer = CInt(Fix(heightNumeric.Value))
			Dim minWidth As Integer = CInt(Fix(minWidthNumeric.Value))
			Dim minHeight As Integer = CInt(Fix(minHeightNumeric.Value))

			container.MinimumSize = New Size(minWidth, minHeight)
			container.MaximumSize = New Size(maxWidth, maxHeight)

			container.Sizable = nCheckBox1.Checked
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nDockManager1_AfterPanelFloat(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Docking.PanelEventArgs) Handles nDockManager1.AfterPanelFloat
			UpdateContainer()
		End Sub
		Private Sub widthNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles widthNumeric.ValueChanged
			UpdateContainer()
		End Sub

		Private Sub heightNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles heightNumeric.ValueChanged
			UpdateContainer()
		End Sub

		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			UpdateContainer()
		End Sub


		#End Region

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim nDockZone1 As Nevron.UI.WinForm.Docking.NDockingPanelHost = New Nevron.UI.WinForm.Docking.NDockingPanelHost()
			Me.nDockManager1 = New Nevron.UI.WinForm.Docking.NDockManager()
			Me.nDockingPanel1 = New Nevron.UI.WinForm.Docking.NDockingPanel()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.minHeightNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.minWidthNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.heightNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.widthNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDockingPanel1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			CType(Me.minHeightNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.minWidthNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBox1.SuspendLayout()
			CType(Me.heightNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.widthNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' nDockManager1
			' 
			Me.nDockManager1.Form = Me
			Me.nDockManager1.RootContainerZIndex = 0
'			Me.nDockManager1.AfterPanelFloat += New Nevron.UI.WinForm.Docking.PanelEventHandler(Me.nDockManager1_AfterPanelFloat);
			'  
			' Root Zone
			'  
			Me.nDockManager1.RootContainer.RootZone.AddChild(nDockZone1)
			Me.nDockManager1.RootContainer.RootZone.Orientation = System.Windows.Forms.Orientation.Horizontal
			'  
			' nDockZone1
			'  
			nDockZone1.AddChild(Me.nDockingPanel1)
			nDockZone1.Name = "nDockZone1"
			nDockZone1.Orientation = System.Windows.Forms.Orientation.Horizontal
			nDockZone1.Index = 0
			nDockZone1.SizeInfo.PrefferedSize = New System.Drawing.Size(250, 200)
			' 
			' nDockingPanel1
			' 
			Me.nDockingPanel1.Controls.Add(Me.nGroupBox2)
			Me.nDockingPanel1.Controls.Add(Me.nGroupBox1)
			Me.nDockingPanel1.Controls.Add(Me.nCheckBox1)
			Me.nDockingPanel1.Name = "nDockingPanel1"
			Me.nDockingPanel1.Permissions.AllowHide = False
			Me.nDockingPanel1.SizeInfo.PrefferedSize = New System.Drawing.Size(250, 200)
			Me.nDockingPanel1.TabIndex = 1
			Me.nDockingPanel1.Text = "Docking Panel"
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.minHeightNumeric)
			Me.nGroupBox2.Controls.Add(Me.minWidthNumeric)
			Me.nGroupBox2.Controls.Add(Me.label3)
			Me.nGroupBox2.Controls.Add(Me.label4)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(8, 120)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(224, 96)
			Me.nGroupBox2.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox2.TabIndex = 2
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Min Floating Size"
			' 
			' minHeightNumeric
			' 
			Me.minHeightNumeric.Increment = New System.Decimal(New Integer() { 10, 0, 0, 0})
			Me.minHeightNumeric.Location = New System.Drawing.Point(80, 48)
			Me.minHeightNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.minHeightNumeric.Name = "minHeightNumeric"
			Me.minHeightNumeric.Size = New System.Drawing.Size(72, 20)
			Me.minHeightNumeric.TabIndex = 3
			Me.minHeightNumeric.Value = New System.Decimal(New Integer() { 150, 0, 0, 0})
			' 
			' minWidthNumeric
			' 
			Me.minWidthNumeric.Increment = New System.Decimal(New Integer() { 10, 0, 0, 0})
			Me.minWidthNumeric.Location = New System.Drawing.Point(80, 24)
			Me.minWidthNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.minWidthNumeric.Name = "minWidthNumeric"
			Me.minWidthNumeric.Size = New System.Drawing.Size(72, 20)
			Me.minWidthNumeric.TabIndex = 2
			Me.minWidthNumeric.Value = New System.Decimal(New Integer() { 150, 0, 0, 0})
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 48)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 23)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Height:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 24)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 23)
			Me.label4.TabIndex = 0
			Me.label4.Text = "Width:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.heightNumeric)
			Me.nGroupBox1.Controls.Add(Me.widthNumeric)
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 16)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(224, 96)
			Me.nGroupBox1.Style = Nevron.UI.WinForm.Controls.GroupBoxStyle.Default
			Me.nGroupBox1.TabIndex = 1
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Max Floating Size"
			' 
			' heightNumeric
			' 
			Me.heightNumeric.Increment = New System.Decimal(New Integer() { 10, 0, 0, 0})
			Me.heightNumeric.Location = New System.Drawing.Point(80, 48)
			Me.heightNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.heightNumeric.Name = "heightNumeric"
			Me.heightNumeric.Size = New System.Drawing.Size(72, 20)
			Me.heightNumeric.TabIndex = 3
			Me.heightNumeric.Value = New System.Decimal(New Integer() { 200, 0, 0, 0})
'			Me.heightNumeric.ValueChanged += New System.EventHandler(Me.heightNumeric_ValueChanged);
			' 
			' widthNumeric
			' 
			Me.widthNumeric.Increment = New System.Decimal(New Integer() { 10, 0, 0, 0})
			Me.widthNumeric.Location = New System.Drawing.Point(80, 24)
			Me.widthNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.widthNumeric.Name = "widthNumeric"
			Me.widthNumeric.Size = New System.Drawing.Size(72, 20)
			Me.widthNumeric.TabIndex = 2
			Me.widthNumeric.Value = New System.Decimal(New Integer() { 200, 0, 0, 0})
'			Me.widthNumeric.ValueChanged += New System.EventHandler(Me.widthNumeric_ValueChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(64, 23)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Height:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Width:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.ButtonProperties.BorderOffset = 2
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 224)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(176, 24)
			Me.nCheckBox1.TabIndex = 0
			Me.nCheckBox1.Text = "Allow sizing in floating state"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' NSizingRestrictionsForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(773, 552)
			Me.Name = "NSizingRestrictionsForm"
			Me.Text = "Docking Panels - Sizing Restrictions Example"
			CType(Me.nDockManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDockingPanel1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			CType(Me.minHeightNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.minWidthNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBox1.ResumeLayout(False)
			CType(Me.heightNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.widthNumeric, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents nDockManager1 As Nevron.UI.WinForm.Docking.NDockManager
		Private nDockingPanel1 As Nevron.UI.WinForm.Docking.NDockingPanel
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents widthNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private minWidthNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private minHeightNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents heightNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown

		#End Region
	End Class
End Namespace
