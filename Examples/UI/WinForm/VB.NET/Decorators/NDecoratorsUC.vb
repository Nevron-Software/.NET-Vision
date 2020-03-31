Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Interop.Win32
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NShadowDecorator.
	''' </summary>
	Public Class NDecoratorsUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			'Dock = DockStyle.Fill;
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
			MyBase.Initialize()
		End Sub

		Protected Overrides Sub WndProc(ByRef m As Message)
			MyBase.WndProc (m)

			If m.Msg <> NWMConstants.WM_MOUSEACTIVATE Then
				Return
			End If

			Dim c As Control = NControlHelper.ControlFromPoint(Control.MousePosition)
			If TypeOf c Is NDecoratorBase Then
				m_Properties.SelectedObject = c
			End If

			Dim decorator As Control = NControlHelper.GetParentOfType(c, GetType(NDecoratorBase))
			If Not decorator Is Nothing Then
				m_Properties.SelectedObject = decorator
			End If
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NDecoratorsUC))
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.m_Properties = New System.Windows.Forms.PropertyGrid()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.panel4 = New System.Windows.Forms.Panel()
			Me.nGroupBox3 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nDecorator2 = New Nevron.UI.WinForm.Controls.NDecorator()
			Me.nDecorator3 = New Nevron.UI.WinForm.Controls.NDecorator()
			Me.label3 = New System.Windows.Forms.Label()
			Me.nShadowDecorator5 = New Nevron.UI.WinForm.Controls.NShadowDecorator()
			Me.nShadowDecorator4 = New Nevron.UI.WinForm.Controls.NShadowDecorator()
			Me.nShadowDecorator3 = New Nevron.UI.WinForm.Controls.NShadowDecorator()
			Me.radioButton1 = New System.Windows.Forms.RadioButton()
			Me.nShadowDecorator2 = New Nevron.UI.WinForm.Controls.NShadowDecorator()
			Me.checkBox1 = New System.Windows.Forms.CheckBox()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.nGroupBox2 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.nShadowDecorator1 = New Nevron.UI.WinForm.Controls.NShadowDecorator()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nDecorator1 = New Nevron.UI.WinForm.Controls.NDecorator()
			Me.label1 = New System.Windows.Forms.Label()
			Me.panel3 = New System.Windows.Forms.Panel()
			Me.nGroupBox1.SuspendLayout()
			Me.panel1.SuspendLayout()
			Me.panel4.SuspendLayout()
			Me.nGroupBox3.SuspendLayout()
			CType(Me.nDecorator2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDecorator2.SuspendLayout()
			CType(Me.nDecorator3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDecorator3.SuspendLayout()
			CType(Me.nShadowDecorator5, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nShadowDecorator4, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nShadowDecorator3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nShadowDecorator3.SuspendLayout()
			CType(Me.nShadowDecorator2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nShadowDecorator2.SuspendLayout()
			Me.panel2.SuspendLayout()
			Me.nGroupBox2.SuspendLayout()
			CType(Me.nShadowDecorator1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nShadowDecorator1.SuspendLayout()
			CType(Me.nDecorator1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nDecorator1.SuspendLayout()
			Me.panel3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.m_Properties)
			Me.nGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(5, 0)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(275, 414)
			Me.nGroupBox1.TabIndex = 0
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Properties"
			' 
			' m_Properties
			' 
			Me.m_Properties.CommandsVisibleIfAvailable = True
			Me.m_Properties.Cursor = System.Windows.Forms.Cursors.HSplit
			Me.m_Properties.Dock = System.Windows.Forms.DockStyle.Fill
			Me.m_Properties.LargeButtons = False
			Me.m_Properties.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.m_Properties.Location = New System.Drawing.Point(3, 16)
			Me.m_Properties.Name = "m_Properties"
			Me.m_Properties.Size = New System.Drawing.Size(269, 395)
			Me.m_Properties.TabIndex = 0
			Me.m_Properties.Text = "PropertyGrid"
			Me.m_Properties.ToolbarVisible = False
			Me.m_Properties.ViewBackColor = System.Drawing.SystemColors.Window
			Me.m_Properties.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.panel4)
			Me.panel1.Controls.Add(Me.panel2)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panel1.Location = New System.Drawing.Point(5, 5)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(342, 414)
			Me.panel1.TabIndex = 1
			' 
			' panel4
			' 
			Me.panel4.Controls.Add(Me.nGroupBox3)
			Me.panel4.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panel4.Location = New System.Drawing.Point(0, 120)
			Me.panel4.Name = "panel4"
			Me.panel4.Size = New System.Drawing.Size(342, 294)
			Me.panel4.TabIndex = 1
			' 
			' nGroupBox3
			' 
			Me.nGroupBox3.BackColor = System.Drawing.Color.Transparent
			Me.nGroupBox3.Controls.Add(Me.nDecorator2)
			Me.nGroupBox3.Controls.Add(Me.nShadowDecorator5)
			Me.nGroupBox3.Controls.Add(Me.nShadowDecorator4)
			Me.nGroupBox3.Controls.Add(Me.nShadowDecorator3)
			Me.nGroupBox3.Controls.Add(Me.nShadowDecorator2)
			Me.nGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nGroupBox3.ImageIndex = 0
			Me.nGroupBox3.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox3.Name = "nGroupBox3"
			Me.nGroupBox3.Size = New System.Drawing.Size(342, 294)
			Me.nGroupBox3.TabIndex = 1
			Me.nGroupBox3.TabStop = False
			Me.nGroupBox3.Text = "Custom Settings"
			' 
			' nDecorator2
			' 
			Me.nDecorator2.Controls.Add(Me.nDecorator3)
			Me.nDecorator2.FillInfo.Gradient1 = System.Drawing.SystemColors.ControlText
			Me.nDecorator2.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText
			Me.nDecorator2.FillInfo.GradientAngle = 240F
			Me.nDecorator2.Location = New System.Drawing.Point(232, 136)
			Me.nDecorator2.Name = "nDecorator2"
			Me.nDecorator2.Size = New System.Drawing.Size(88, 88)
			Me.nDecorator2.StrokeInfo.Color = System.Drawing.SystemColors.ControlText
			Me.nDecorator2.StrokeInfo.Draw = False
			Me.nDecorator2.StrokeInfo.PenWidth = 2
			Me.nDecorator2.StrokeInfo.Rounding = 50
			Me.nDecorator2.TabIndex = 4
			Me.nDecorator2.Text = "nDecorator2"
			' 
			' nDecorator3
			' 
			Me.nDecorator3.Controls.Add(Me.label3)
			Me.nDecorator3.FillInfo.Gradient1 = System.Drawing.SystemColors.ControlText
			Me.nDecorator3.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText
			Me.nDecorator3.FillInfo.GradientAngle = 60F
			Me.nDecorator3.Location = New System.Drawing.Point(16, 16)
			Me.nDecorator3.Name = "nDecorator3"
			Me.nDecorator3.Size = New System.Drawing.Size(56, 56)
			Me.nDecorator3.StrokeInfo.Color = System.Drawing.SystemColors.ControlText
			Me.nDecorator3.StrokeInfo.Draw = False
			Me.nDecorator3.StrokeInfo.Rounding = 50
			Me.nDecorator3.TabIndex = 5
			Me.nDecorator3.Text = "nDecorator3"
			' 
			' label3
			' 
			Me.label3.Image = (CType(resources.GetObject("label3.Image"), System.Drawing.Image))
			Me.label3.Location = New System.Drawing.Point(0, 0)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(56, 48)
			Me.label3.TabIndex = 0
			' 
			' nShadowDecorator5
			' 
			Me.nShadowDecorator5.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass
			Me.nShadowDecorator5.FillInfo.Gradient1 = System.Drawing.Color.Blue
			Me.nShadowDecorator5.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText
			Me.nShadowDecorator5.Location = New System.Drawing.Point(160, 136)
			Me.nShadowDecorator5.Name = "nShadowDecorator5"
			Me.nShadowDecorator5.ShadowInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(51)), (CByte(153)))
			Me.nShadowDecorator5.ShadowInfo.OffsetX = 10
			Me.nShadowDecorator5.ShadowInfo.OffsetY = 10
			Me.nShadowDecorator5.Size = New System.Drawing.Size(56, 56)
			Me.nShadowDecorator5.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(51)), (CByte(102)), (CByte(204)))
			Me.nShadowDecorator5.StrokeInfo.Gradient1 = System.Drawing.Color.Blue
			Me.nShadowDecorator5.StrokeInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText
			Me.nShadowDecorator5.StrokeInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nShadowDecorator5.StrokeInfo.Rounding = 50
			Me.nShadowDecorator5.TabIndex = 3
			' 
			' nShadowDecorator4
			' 
			Me.nShadowDecorator4.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Gel
			Me.nShadowDecorator4.FillInfo.Gradient1 = System.Drawing.Color.Red
			Me.nShadowDecorator4.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText
			Me.nShadowDecorator4.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista
			Me.nShadowDecorator4.Location = New System.Drawing.Point(16, 136)
			Me.nShadowDecorator4.Name = "nShadowDecorator4"
			Me.nShadowDecorator4.ShadowInfo.OffsetX = 10
			Me.nShadowDecorator4.ShadowInfo.OffsetY = 10
			Me.nShadowDecorator4.Size = New System.Drawing.Size(136, 56)
			Me.nShadowDecorator4.StrokeInfo.Color = System.Drawing.SystemColors.ActiveCaptionText
			Me.nShadowDecorator4.StrokeInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(51)), (CByte(0)))
			Me.nShadowDecorator4.StrokeInfo.Gradient2 = System.Drawing.SystemColors.ControlText
			Me.nShadowDecorator4.StrokeInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nShadowDecorator4.StrokeInfo.PenStyle = Nevron.UI.WinForm.Controls.PenStyle.UseBrush
			Me.nShadowDecorator4.StrokeInfo.PenWidth = 5
			Me.nShadowDecorator4.StrokeInfo.Rounding = 20
			Me.nShadowDecorator4.StrokeInfo.RoundingEdges = (CType((Nevron.UI.RoundingEdges.TopRight Or Nevron.UI.RoundingEdges.BottomLeft), Nevron.UI.RoundingEdges))
			Me.nShadowDecorator4.TabIndex = 2
			' 
			' nShadowDecorator3
			' 
			Me.nShadowDecorator3.Controls.Add(Me.radioButton1)
			Me.nShadowDecorator3.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.SegmentedImage
			Me.nShadowDecorator3.FillInfo.SegmentedImage.Image = (CType(resources.GetObject("nShadowDecorator3.FillInfo.SegmentedImage.Image"), System.Drawing.Image))
			Me.nShadowDecorator3.FillInfo.SegmentedImage.Margins = New Nevron.UI.NPadding(4, 4, 4, 4)
			Me.nShadowDecorator3.Location = New System.Drawing.Point(160, 32)
			Me.nShadowDecorator3.Name = "nShadowDecorator3"
			Me.nShadowDecorator3.ShadowInfo.OffsetX = 10
			Me.nShadowDecorator3.ShadowInfo.OffsetY = 10
			Me.nShadowDecorator3.Size = New System.Drawing.Size(160, 88)
			Me.nShadowDecorator3.StrokeInfo.Draw = False
			Me.nShadowDecorator3.TabIndex = 1
			' 
			' radioButton1
			' 
			Me.radioButton1.Location = New System.Drawing.Point(24, 24)
			Me.radioButton1.Name = "radioButton1"
			Me.radioButton1.TabIndex = 0
			Me.radioButton1.Text = "radioButton1"
			' 
			' nShadowDecorator2
			' 
			Me.nShadowDecorator2.Controls.Add(Me.checkBox1)
			Me.nShadowDecorator2.FillInfo.Gradient1 = System.Drawing.Color.WhiteSmoke
			Me.nShadowDecorator2.FillInfo.Gradient2 = System.Drawing.Color.DimGray
			Me.nShadowDecorator2.Location = New System.Drawing.Point(16, 32)
			Me.nShadowDecorator2.Name = "nShadowDecorator2"
			Me.nShadowDecorator2.Size = New System.Drawing.Size(136, 96)
			Me.nShadowDecorator2.StrokeInfo.Gradient1 = System.Drawing.Color.DimGray
			Me.nShadowDecorator2.StrokeInfo.Gradient2 = System.Drawing.Color.WhiteSmoke
			Me.nShadowDecorator2.StrokeInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nShadowDecorator2.StrokeInfo.PenStyle = Nevron.UI.WinForm.Controls.PenStyle.UseBrush
			Me.nShadowDecorator2.StrokeInfo.PenWidth = 5
			Me.nShadowDecorator2.StrokeInfo.Rounding = 10
			Me.nShadowDecorator2.TabIndex = 0
			' 
			' checkBox1
			' 
			Me.checkBox1.BackColor = System.Drawing.Color.Transparent
			Me.checkBox1.Location = New System.Drawing.Point(24, 24)
			Me.checkBox1.Name = "checkBox1"
			Me.checkBox1.Size = New System.Drawing.Size(88, 24)
			Me.checkBox1.TabIndex = 0
			Me.checkBox1.Text = "checkBox1"
			' 
			' panel2
			' 
			Me.panel2.Controls.Add(Me.nGroupBox2)
			Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel2.Location = New System.Drawing.Point(0, 0)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(342, 120)
			Me.panel2.TabIndex = 0
			' 
			' nGroupBox2
			' 
			Me.nGroupBox2.BackColor = System.Drawing.Color.Transparent
			Me.nGroupBox2.Controls.Add(Me.nShadowDecorator1)
			Me.nGroupBox2.Controls.Add(Me.nDecorator1)
			Me.nGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.nGroupBox2.ImageIndex = 0
			Me.nGroupBox2.Location = New System.Drawing.Point(0, 0)
			Me.nGroupBox2.Name = "nGroupBox2"
			Me.nGroupBox2.Size = New System.Drawing.Size(342, 120)
			Me.nGroupBox2.TabIndex = 0
			Me.nGroupBox2.TabStop = False
			Me.nGroupBox2.Text = "Default Settings"
			' 
			' nShadowDecorator1
			' 
			Me.nShadowDecorator1.Controls.Add(Me.label2)
			Me.nShadowDecorator1.Location = New System.Drawing.Point(160, 24)
			Me.nShadowDecorator1.Name = "nShadowDecorator1"
			Me.nShadowDecorator1.Size = New System.Drawing.Size(168, 80)
			Me.nShadowDecorator1.TabIndex = 1
			' 
			' label2
			' 
			Me.label2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label2.Location = New System.Drawing.Point(1, 1)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(161, 73)
			Me.label2.TabIndex = 1
			Me.label2.Text = "This is label nested in a NShadowDecorator instance."
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' nDecorator1
			' 
			Me.nDecorator1.Controls.Add(Me.label1)
			Me.nDecorator1.Location = New System.Drawing.Point(16, 24)
			Me.nDecorator1.Name = "nDecorator1"
			Me.nDecorator1.Size = New System.Drawing.Size(136, 80)
			Me.nDecorator1.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label1.Location = New System.Drawing.Point(1, 1)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(134, 78)
			Me.label1.TabIndex = 0
			Me.label1.Text = "This is label nested in a NDecorator instance."
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' panel3
			' 
			Me.panel3.Controls.Add(Me.nGroupBox1)
			Me.panel3.Dock = System.Windows.Forms.DockStyle.Right
			Me.panel3.DockPadding.Left = 5
			Me.panel3.Location = New System.Drawing.Point(347, 5)
			Me.panel3.Name = "panel3"
			Me.panel3.Size = New System.Drawing.Size(280, 414)
			Me.panel3.TabIndex = 2
			' 
			' NDecoratorsUC
			' 
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.panel3)
			Me.DockPadding.All = 5
			Me.Name = "NDecoratorsUC"
			Me.Size = New System.Drawing.Size(632, 424)
			Me.nGroupBox1.ResumeLayout(False)
			Me.panel1.ResumeLayout(False)
			Me.panel4.ResumeLayout(False)
			Me.nGroupBox3.ResumeLayout(False)
			CType(Me.nDecorator2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDecorator2.ResumeLayout(False)
			CType(Me.nDecorator3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDecorator3.ResumeLayout(False)
			CType(Me.nShadowDecorator5, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nShadowDecorator4, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nShadowDecorator3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nShadowDecorator3.ResumeLayout(False)
			CType(Me.nShadowDecorator2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nShadowDecorator2.ResumeLayout(False)
			Me.panel2.ResumeLayout(False)
			Me.nGroupBox2.ResumeLayout(False)
			CType(Me.nShadowDecorator1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nShadowDecorator1.ResumeLayout(False)
			CType(Me.nDecorator1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nDecorator1.ResumeLayout(False)
			Me.panel3.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private m_Properties As System.Windows.Forms.PropertyGrid
		Private panel1 As System.Windows.Forms.Panel
		Private panel2 As System.Windows.Forms.Panel
		Private nGroupBox2 As Nevron.UI.WinForm.Controls.NGroupBox
		Private panel3 As System.Windows.Forms.Panel
		Private nDecorator1 As Nevron.UI.WinForm.Controls.NDecorator
		Private label1 As System.Windows.Forms.Label
		Private nShadowDecorator1 As Nevron.UI.WinForm.Controls.NShadowDecorator
		Private label2 As System.Windows.Forms.Label
		Private panel4 As System.Windows.Forms.Panel
		Private nGroupBox3 As Nevron.UI.WinForm.Controls.NGroupBox
		Private nShadowDecorator2 As Nevron.UI.WinForm.Controls.NShadowDecorator
		Private radioButton1 As System.Windows.Forms.RadioButton
		Private checkBox1 As System.Windows.Forms.CheckBox
		Private nShadowDecorator4 As Nevron.UI.WinForm.Controls.NShadowDecorator
		Private nShadowDecorator5 As Nevron.UI.WinForm.Controls.NShadowDecorator
		Private nDecorator2 As Nevron.UI.WinForm.Controls.NDecorator
		Private nDecorator3 As Nevron.UI.WinForm.Controls.NDecorator
		Private label3 As System.Windows.Forms.Label
		Private nShadowDecorator3 As Nevron.UI.WinForm.Controls.NShadowDecorator

		#End Region
	End Class
End Namespace