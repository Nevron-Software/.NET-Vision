Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for ComboBoxExample.
	''' </summary>
	Public Class NComboBoxesUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
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

			AddHandler nComboBox1.KeyPress, AddressOf nComboBox1_KeyPress

			m_ColorMode.Items.Add("Known Colors")
			m_ColorMode.Items.Add("Web Colors")
			m_ColorMode.Items.Add("System Colors")

			m_ColorMode.SelectedIndex = 0

			'init some items
			Dim item As NListBoxItem

			For i As Integer = 0 To 9
				item = New NListBoxItem()
				item.Text = "List item " & (i + 1).ToString()
				item.ImageIndex = i

				nComboBox1.Items.Add(item)
				nComboBox2.Items.Add(item)
				nComboBox4.Items.Add(item)
			Next i

			nComboBox2.Editable = True

			AddHandler m_PropertyGrid.PropertyValueChanged, AddressOf m_PropertyGrid_PropertyValueChanged
			m_PropertyGrid.SelectedObject = nComboBox1.ListProperties
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub m_ColorMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ColorMode.SelectedIndexChanged
			Dim index As Integer = m_ColorMode.SelectedIndex
			Select Case index
				Case 0
					m_Colors.PopulateKnownColors()
				Case 1
					m_Colors.PopulateWebColors()
				Case 2
					m_Colors.PopulateSystemColors()
			End Select

			m_Colors.SelectedIndex = 0
		End Sub
		Private Sub nCheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox1.CheckedChanged
			Dim enabled As Boolean = nCheckBox1.Checked
			nComboBox1.Enabled = enabled
			nComboBox2.Enabled = enabled
			nComboBox4.Enabled = enabled
			m_Colors.Enabled = enabled
			m_ColorMode.Enabled = enabled
		End Sub

		Private Sub nCheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nCheckBox2.CheckedChanged
			Dim interactive As Boolean = nCheckBox2.Checked
			nComboBox1.InteractiveBorder = interactive
			nComboBox2.InteractiveBorder = interactive
			nComboBox4.InteractiveBorder = interactive
			m_Colors.InteractiveBorder = interactive
			m_ColorMode.InteractiveBorder = interactive
		End Sub

		Private Sub m_PropertyGrid_PropertyValueChanged(ByVal s As Object, ByVal e As PropertyValueChangedEventArgs)
			Dim props As NListBoxProperties = nComboBox1.ListProperties

			nComboBox2.ListProperties.Copy(props)
			nComboBox4.ListProperties.Copy(props)

			Invalidate(True)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NComboBoxesUC))
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.m_Colors = New Nevron.UI.WinForm.Controls.NColorComboBox()
			Me.m_ColorMode = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nComboBox4 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nComboBox1 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nComboBox2 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nCheckBox2 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_PropertyGrid = New System.Windows.Forms.PropertyGrid()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nGroupBox1.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' imageList1
			' 
			Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
			' 
			' m_Colors
			' 
			Me.m_Colors.Location = New System.Drawing.Point(16, 24)
			Me.m_Colors.Name = "m_Colors"
			Me.m_Colors.Size = New System.Drawing.Size(192, 22)
			Me.m_Colors.TabIndex = 6
			Me.m_Colors.Text = "nColorComboBox1"
			' 
			' m_ColorMode
			' 
			Me.m_ColorMode.Location = New System.Drawing.Point(80, 56)
			Me.m_ColorMode.Name = "m_ColorMode"
			Me.m_ColorMode.Size = New System.Drawing.Size(128, 22)
			Me.m_ColorMode.TabIndex = 8
			Me.m_ColorMode.Text = "nComboBox4"
'			Me.m_ColorMode.SelectedIndexChanged += New System.EventHandler(Me.m_ColorMode_SelectedIndexChanged);
			' 
			' nComboBox4
			' 
			Me.nComboBox4.ImageList = Me.imageList1
			Me.nComboBox4.Location = New System.Drawing.Point(16, 88)
			Me.nComboBox4.Name = "nComboBox4"
			Me.nComboBox4.Size = New System.Drawing.Size(192, 40)
			Me.nComboBox4.TabIndex = 10
			Me.nComboBox4.Text = "nComboBox4"
			' 
			' nComboBox1
			' 
			Me.nComboBox1.ImageList = Me.imageList1
			Me.nComboBox1.Location = New System.Drawing.Point(16, 24)
			Me.nComboBox1.Name = "nComboBox1"
			Me.nComboBox1.Size = New System.Drawing.Size(192, 22)
			Me.nComboBox1.TabIndex = 0
			' 
			' nComboBox2
			' 
			Me.nComboBox2.ImageList = Me.imageList1
			Me.nComboBox2.Location = New System.Drawing.Point(16, 56)
			Me.nComboBox2.Name = "nComboBox2"
			Me.nComboBox2.Size = New System.Drawing.Size(192, 22)
			Me.nComboBox2.TabIndex = 1
			Me.nComboBox2.Text = "nComboBox2"
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Checked = True
			Me.nCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 256)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.Size = New System.Drawing.Size(72, 24)
			Me.nCheckBox1.TabIndex = 20
			Me.nCheckBox1.Text = "&Enable"
'			Me.nCheckBox1.CheckedChanged += New System.EventHandler(Me.nCheckBox1_CheckedChanged);
			' 
			' nCheckBox2
			' 
			Me.nCheckBox2.Location = New System.Drawing.Point(88, 256)
			Me.nCheckBox2.Name = "nCheckBox2"
			Me.nCheckBox2.Size = New System.Drawing.Size(120, 24)
			Me.nCheckBox2.TabIndex = 21
			Me.nCheckBox2.Text = "&Interactive Border"
'			Me.nCheckBox2.CheckedChanged += New System.EventHandler(Me.nCheckBox2_CheckedChanged);
			' 
			' m_PropertyGrid
			' 
			Me.m_PropertyGrid.CommandsVisibleIfAvailable = True
			Me.m_PropertyGrid.LargeButtons = False
			Me.m_PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.m_PropertyGrid.Location = New System.Drawing.Point(8, 24)
			Me.m_PropertyGrid.Name = "m_PropertyGrid"
			Me.m_PropertyGrid.Size = New System.Drawing.Size(328, 240)
			Me.m_PropertyGrid.TabIndex = 22
			Me.m_PropertyGrid.Text = "propertyGrid1"
			Me.m_PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
			Me.m_PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.nComboBox1)
			Me.nGroupBox1.Controls.Add(Me.nComboBox2)
			Me.nGroupBox1.Controls.Add(Me.nComboBox4)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(8, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(224, 136)
			Me.nGroupBox1.TabIndex = 24
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Standard Comboboxes"
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.Controls.Add(Me.label2)
			Me.nGroupBox2.Controls.Add(Me.m_Colors)
			Me.nGroupBox2.Controls.Add(Me.m_ColorMode)
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(8, 152)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(224, 88)
			Me.nGroupBox2.TabIndex = 25
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Color Combobox"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(16, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(56, 23)
			Me.label2.TabIndex = 9
			Me.label2.Text = "Colors:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.Controls.Add(Me.m_PropertyGrid)
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(240, 8)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(344, 272)
			Me.nGroupBox3.TabIndex = 26
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "List Properties"
			' 
			' NComboBoxesUC
			' 
			Me.Controls.Add(Me.nGroupBox3)
			Me.Controls.Add(Me.nGroupBox2)
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nCheckBox2)
			Me.Controls.Add(Me.nCheckBox1)
			Me.Name = "NComboBoxesUC"
			Me.Size = New System.Drawing.Size(592, 288)
			Me.nGroupBox1.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private m_Colors As Nevron.UI.WinForm.Controls.NColorComboBox
		Private WithEvents m_ColorMode As Nevron.UI.WinForm.Controls.NComboBox
		Private imageList1 As System.Windows.Forms.ImageList
		Private nComboBox4 As Nevron.UI.WinForm.Controls.NComboBox
		Private nComboBox1 As Nevron.UI.WinForm.Controls.NComboBox
		Private nComboBox2 As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents nCheckBox2 As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_PropertyGrid As System.Windows.Forms.PropertyGrid
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private label2 As System.Windows.Forms.Label
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox

		Private components As System.ComponentModel.IContainer

		#End Region

		Private Sub nComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
			Debug.WriteLine("Key press...")
		End Sub
	End Class
End Namespace
