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
	''' Summary description for NCustomExpanderUC.
	''' </summary>
	Public Class NCustomExpanderUC
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


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NCustomExpanderUC))
			Me.nExpander1 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nShadowDecorator2 = New Nevron.UI.WinForm.Controls.NShadowDecorator()
			Me.nComboBox2 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nExpander2 = New Nevron.UI.WinForm.Controls.NExpander()
			Me.nShadowDecorator1 = New Nevron.UI.WinForm.Controls.NShadowDecorator()
			Me.nComboBox1 = New Nevron.UI.WinForm.Controls.NComboBox()
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander1.SuspendLayout()
			CType(Me.nShadowDecorator2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nExpander2.SuspendLayout()
			CType(Me.nShadowDecorator1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nExpander1
			' 
			Me.nExpander1.ArrowImageSet.CollapseHot = (CType(resources.GetObject("nExpander1.ArrowImageSet.CollapseHot"), System.Drawing.Image))
			Me.nExpander1.ArrowImageSet.CollapseNormal = (CType(resources.GetObject("nExpander1.ArrowImageSet.CollapseNormal"), System.Drawing.Image))
			Me.nExpander1.ArrowImageSet.ExpandHot = (CType(resources.GetObject("nExpander1.ArrowImageSet.ExpandHot"), System.Drawing.Image))
			Me.nExpander1.ArrowImageSet.ExpandNormal = (CType(resources.GetObject("nExpander1.ArrowImageSet.ExpandNormal"), System.Drawing.Image))
			Me.nExpander1.BackColor = System.Drawing.Color.WhiteSmoke
			Me.nExpander1.Controls.Add(Me.nShadowDecorator2)
			Me.nExpander1.Controls.Add(Me.nComboBox2)
			Me.nExpander1.DrawBorder = True
			Me.nExpander1.HeaderImage = (CType(resources.GetObject("nExpander1.HeaderImage"), System.Drawing.Image))
			Me.nExpander1.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander1.Location = New System.Drawing.Point(8, 8)
			Me.nExpander1.Name = "nExpander1"
            Me.nExpander1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus
			Me.nExpander1.Palette.ControlBorder = System.Drawing.Color.FromArgb((CByte(170)), (CByte(170)), (CByte(170)))
			Me.nExpander1.Palette.ControlLight = System.Drawing.Color.WhiteSmoke
			Me.nExpander1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nExpander1.Size = New System.Drawing.Size(216, 176)
			Me.nExpander1.TabIndex = 0
			Me.nExpander1.Text = "nExpander1"
			' 
			' nShadowDecorator2
			' 
			Me.nShadowDecorator2.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Gel
			Me.nShadowDecorator2.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(51)), (CByte(0)))
			Me.nShadowDecorator2.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(204)))
			Me.nShadowDecorator2.Location = New System.Drawing.Point(12, 72)
			Me.nShadowDecorator2.Name = "nShadowDecorator2"
            Me.nShadowDecorator2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus
			Me.nShadowDecorator2.Palette.ControlBorder = System.Drawing.Color.FromArgb((CByte(170)), (CByte(170)), (CByte(170)))
			Me.nShadowDecorator2.Palette.ControlLight = System.Drawing.Color.WhiteSmoke
			Me.nShadowDecorator2.ShadowInfo.Draw = False
			Me.nShadowDecorator2.Size = New System.Drawing.Size(192, 96)
			Me.nShadowDecorator2.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(153)))
			Me.nShadowDecorator2.StrokeInfo.PenWidth = 5
			Me.nShadowDecorator2.StrokeInfo.Rounding = 10
			Me.nShadowDecorator2.TabIndex = 3
			Me.nShadowDecorator2.Text = "nShadowDecorator2"
			' 
			' nComboBox2
			' 
			Me.nComboBox2.Location = New System.Drawing.Point(12, 40)
			Me.nComboBox2.Name = "nComboBox2"
            Me.nComboBox2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus
			Me.nComboBox2.Palette.ControlBorder = System.Drawing.Color.FromArgb((CByte(170)), (CByte(170)), (CByte(170)))
			Me.nComboBox2.Palette.ControlLight = System.Drawing.Color.WhiteSmoke
			Me.nComboBox2.Size = New System.Drawing.Size(192, 22)
			Me.nComboBox2.TabIndex = 2
			Me.nComboBox2.Text = "nComboBox2"
			' 
			' nExpander2
			' 
			Me.nExpander2.ArrowImageSet.CollapseHot = (CType(resources.GetObject("nExpander2.ArrowImageSet.CollapseHot"), System.Drawing.Image))
			Me.nExpander2.ArrowImageSet.CollapseNormal = (CType(resources.GetObject("nExpander2.ArrowImageSet.CollapseNormal"), System.Drawing.Image))
			Me.nExpander2.ArrowImageSet.ExpandHot = (CType(resources.GetObject("nExpander2.ArrowImageSet.ExpandHot"), System.Drawing.Image))
			Me.nExpander2.ArrowImageSet.ExpandNormal = (CType(resources.GetObject("nExpander2.ArrowImageSet.ExpandNormal"), System.Drawing.Image))
			Me.nExpander2.BackColor = System.Drawing.Color.FromArgb((CByte(214)), (CByte(223)), (CByte(247)))
			Me.nExpander2.Controls.Add(Me.nShadowDecorator1)
			Me.nExpander2.Controls.Add(Me.nComboBox1)
			Me.nExpander2.DrawBorder = True
			Me.nExpander2.HeaderImage = (CType(resources.GetObject("nExpander2.HeaderImage"), System.Drawing.Image))
			Me.nExpander2.HeaderImageSize = New System.Drawing.Size(28, 28)
			Me.nExpander2.Location = New System.Drawing.Point(8, 208)
			Me.nExpander2.Name = "nExpander2"
            Me.nExpander2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus
			Me.nExpander2.Palette.ControlBorder = System.Drawing.SystemColors.ActiveCaptionText
			Me.nExpander2.Palette.ControlLight = System.Drawing.Color.FromArgb((CByte(214)), (CByte(223)), (CByte(247)))
			Me.nExpander2.Palette.ControlText = System.Drawing.SystemColors.ActiveCaptionText
			Me.nExpander2.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nExpander2.Size = New System.Drawing.Size(216, 192)
			Me.nExpander2.TabIndex = 1
			Me.nExpander2.Text = "nExpander2"
			' 
			' nShadowDecorator1
			' 
			Me.nShadowDecorator1.BackColor = System.Drawing.Color.Transparent
			Me.nShadowDecorator1.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Gel
			Me.nShadowDecorator1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(51)), (CByte(102)), (CByte(255)))
			Me.nShadowDecorator1.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(204)), (CByte(236)), (CByte(255)))
			Me.nShadowDecorator1.Location = New System.Drawing.Point(8, 72)
			Me.nShadowDecorator1.Name = "nShadowDecorator1"
            Me.nShadowDecorator1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus
			Me.nShadowDecorator1.Palette.ControlBorder = System.Drawing.SystemColors.ActiveCaptionText
			Me.nShadowDecorator1.Palette.ControlLight = System.Drawing.Color.FromArgb((CByte(214)), (CByte(223)), (CByte(247)))
			Me.nShadowDecorator1.Palette.ControlText = System.Drawing.SystemColors.ActiveCaptionText
			Me.nShadowDecorator1.ShadowInfo.Draw = False
			Me.nShadowDecorator1.Size = New System.Drawing.Size(192, 96)
			Me.nShadowDecorator1.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(153)))
			Me.nShadowDecorator1.StrokeInfo.PenWidth = 5
			Me.nShadowDecorator1.StrokeInfo.Rounding = 10
			Me.nShadowDecorator1.TabIndex = 1
			Me.nShadowDecorator1.Text = "nShadowDecorator1"
			' 
			' nComboBox1
			' 
			Me.nComboBox1.Location = New System.Drawing.Point(8, 40)
			Me.nComboBox1.Name = "nComboBox1"
            Me.nComboBox1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus
			Me.nComboBox1.Palette.ControlBorder = System.Drawing.SystemColors.ActiveCaptionText
			Me.nComboBox1.Palette.ControlLight = System.Drawing.Color.FromArgb((CByte(214)), (CByte(223)), (CByte(247)))
			Me.nComboBox1.Palette.ControlText = System.Drawing.SystemColors.ActiveCaptionText
			Me.nComboBox1.Size = New System.Drawing.Size(192, 22)
			Me.nComboBox1.TabIndex = 0
			Me.nComboBox1.Text = "nComboBox1"
			' 
			' NCustomExpanderUC
			' 
			Me.Controls.Add(Me.nExpander2)
			Me.Controls.Add(Me.nExpander1)
			Me.Name = "NCustomExpanderUC"
			Me.Size = New System.Drawing.Size(240, 416)
			CType(Me.nExpander1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander1.ResumeLayout(False)
			CType(Me.nShadowDecorator2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nExpander2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nExpander2.ResumeLayout(False)
			CType(Me.nShadowDecorator1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private nExpander1 As Nevron.UI.WinForm.Controls.NExpander
		Private nExpander2 As Nevron.UI.WinForm.Controls.NExpander
		Private nComboBox1 As Nevron.UI.WinForm.Controls.NComboBox
		Private nShadowDecorator1 As Nevron.UI.WinForm.Controls.NShadowDecorator
		Private nShadowDecorator2 As Nevron.UI.WinForm.Controls.NShadowDecorator
		Private nComboBox2 As Nevron.UI.WinForm.Controls.NComboBox

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
