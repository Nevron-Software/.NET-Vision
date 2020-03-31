Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
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
	''' Summary description for NUIPanelUC.
	''' </summary>
	Public Class NUIPanelUC
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

			AddHandler nuiPanel1.HScrollValueChanged, AddressOf nuiPanel1_HScrollValueChanged
			AddHandler nuiPanel1.VScrollValueChanged, AddressOf nuiPanel1_VScrollValueChanged
			nuiPanel1.AutoScroll = True
			propertyGrid1.SelectedObject = nuiPanel1

			Me.nButton1.TransparentBackground = True
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub hScrollNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hScrollNumeric.ValueChanged
			If m_bUpdating Then
				Return
			End If

			m_bUpdating = True
			Me.nuiPanel1.HScroll.Value = CInt(Fix(hScrollNumeric.Value))
			Me.hScrollNumeric.Value = Me.nuiPanel1.HScroll.Value
			m_bUpdating = False
		End Sub

		Private Sub vScrollNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vScrollNumeric.ValueChanged
			If m_bUpdating Then
				Return
			End If

			m_bUpdating = True
			Me.nuiPanel1.VScroll.Value = CInt(Fix(vScrollNumeric.Value))
			Me.vScrollNumeric.Value = Me.nuiPanel1.VScroll.Value
			m_bUpdating = False
		End Sub
		Private Sub nuiPanel1_HScrollValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			If m_bUpdating Then
				Return
			End If

			m_bUpdating = True
			hScrollNumeric.Value = nuiPanel1.HScroll.Value
			m_bUpdating = False
		End Sub

		Private Sub nuiPanel1_VScrollValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			If m_bUpdating Then
				Return
			End If

			m_bUpdating = True
			vScrollNumeric.Value = nuiPanel1.VScroll.Value
			m_bUpdating = False
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nuiPanel1 = New Nevron.UI.WinForm.Controls.NUIPanel()
			Me.nColorPool2 = New Nevron.UI.WinForm.Controls.NColorPool()
			Me.nColorPool1 = New Nevron.UI.WinForm.Controls.NColorPool()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.hScrollNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.vScrollNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.nuiPanel1.SuspendLayout()
			CType(Me.hScrollNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.vScrollNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nuiPanel1
			' 
			Me.nuiPanel1.AutoScroll = True
			Me.nuiPanel1.BackColor = System.Drawing.Color.FromArgb((CByte(191)), (CByte(219)), (CByte(255)))
			Me.nuiPanel1.Border.Style = Nevron.UI.BorderStyle3D.Flat
			Me.nuiPanel1.Controls.Add(Me.nColorPool2)
			Me.nuiPanel1.Controls.Add(Me.nColorPool1)
			Me.nuiPanel1.Controls.Add(Me.nCheckBox1)
			Me.nuiPanel1.Controls.Add(Me.nButton1)
			Me.nuiPanel1.Location = New System.Drawing.Point(8, 8)
			Me.nuiPanel1.Name = "nuiPanel1"
			Me.nuiPanel1.Size = New System.Drawing.Size(264, 208)
			Me.nuiPanel1.TabIndex = 0
			' 
			' nColorPool2
			' 
			Me.nColorPool2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.nColorPool2.Color = System.Drawing.Color.Empty
			Me.nColorPool2.Hue = 0F
			Me.nColorPool2.Location = New System.Drawing.Point(184, 168)
			Me.nColorPool2.Luminance = 0.5F
			Me.nColorPool2.Name = "nColorPool2"
			Me.nColorPool2.Saturation = 0F
			Me.nColorPool2.Size = New System.Drawing.Size(202, 102)
			Me.nColorPool2.TabIndex = 3
			' 
			' nColorPool1
			' 
			Me.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.nColorPool1.Color = System.Drawing.Color.Empty
			Me.nColorPool1.Hue = 0F
			Me.nColorPool1.Location = New System.Drawing.Point(208, 232)
			Me.nColorPool1.Luminance = 0.5F
			Me.nColorPool1.Name = "nColorPool1"
			Me.nColorPool1.Saturation = 0F
			Me.nColorPool1.Size = New System.Drawing.Size(208, 104)
			Me.nColorPool1.TabIndex = 2
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Location = New System.Drawing.Point(8, 40)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.TabIndex = 1
			Me.nCheckBox1.Text = "nCheckBox1"
			Me.nCheckBox1.TransparentBackground = True
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(8, 8)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.TabIndex = 0
			Me.nButton1.Text = "nButton1"
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.CommandsVisibleIfAvailable = True
			Me.propertyGrid1.LargeButtons = False
			Me.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.propertyGrid1.Location = New System.Drawing.Point(280, 8)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.Size = New System.Drawing.Size(296, 344)
			Me.propertyGrid1.TabIndex = 1
			Me.propertyGrid1.Text = "propertyGrid1"
			Me.propertyGrid1.ToolbarVisible = False
			Me.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
			Me.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' hScrollNumeric
			' 
			Me.hScrollNumeric.Location = New System.Drawing.Point(88, 232)
			Me.hScrollNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.hScrollNumeric.Name = "hScrollNumeric"
			Me.hScrollNumeric.Size = New System.Drawing.Size(72, 20)
			Me.hScrollNumeric.TabIndex = 2
'			Me.hScrollNumeric.ValueChanged += New System.EventHandler(Me.hScrollNumeric_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 232)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 24)
			Me.label1.TabIndex = 3
			Me.label1.Text = "HScroll:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 256)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(72, 24)
			Me.label2.TabIndex = 5
			Me.label2.Text = "VScroll:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' vScrollNumeric
			' 
			Me.vScrollNumeric.Location = New System.Drawing.Point(88, 256)
			Me.vScrollNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.vScrollNumeric.Name = "vScrollNumeric"
			Me.vScrollNumeric.Size = New System.Drawing.Size(72, 20)
			Me.vScrollNumeric.TabIndex = 4
'			Me.vScrollNumeric.ValueChanged += New System.EventHandler(Me.vScrollNumeric_ValueChanged);
			' 
			' NUIPanelUC
			' 
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.vScrollNumeric)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.hScrollNumeric)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Controls.Add(Me.nuiPanel1)
			Me.Name = "NUIPanelUC"
			Me.Size = New System.Drawing.Size(576, 352)
			Me.nuiPanel1.ResumeLayout(False)
			CType(Me.hScrollNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.vScrollNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_bUpdating As Boolean

		Private components As System.ComponentModel.Container = Nothing
		Private nuiPanel1 As Nevron.UI.WinForm.Controls.NUIPanel
		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nColorPool2 As Nevron.UI.WinForm.Controls.NColorPool
		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private WithEvents hScrollNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents vScrollNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nColorPool1 As Nevron.UI.WinForm.Controls.NColorPool

		#End Region
	End Class
End Namespace
