Imports Microsoft.VisualBasic
Imports System
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
	''' Summary description for NGrouperUC.
	''' </summary>
	Public Class NGrouperUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
			nGrouper3.StrokeInfo.RoundingEdges = RoundingEdges.TopLeft Or RoundingEdges.TopRight
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

			nButton1.TransparentBackground = True
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NGrouperUC))
			Me.nGrouper1 = New Nevron.UI.WinForm.Controls.NGrouper()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nTextBox2 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.nTextBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.nGrouper3 = New Nevron.UI.WinForm.Controls.NGrouper()
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGrouper1.SuspendLayout()
			CType(Me.nGrouper3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nGrouper1
			' 
			Me.nGrouper1.Controls.Add(Me.nButton1)
			Me.nGrouper1.Controls.Add(Me.nTextBox2)
			Me.nGrouper1.Controls.Add(Me.label2)
			Me.nGrouper1.Controls.Add(Me.nTextBox1)
			Me.nGrouper1.Controls.Add(Me.label1)
			Me.nGrouper1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(90)), (CByte(125)), (CByte(222)))
			Me.nGrouper1.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(155)), (CByte(186)), (CByte(247)))
			Me.nGrouper1.FillInfo.GradientAngle = 15F
			Me.nGrouper1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nGrouper1.FooterFillInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(51)), (CByte(153)))
			Me.nGrouper1.FooterFillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid
			Me.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper1.FooterItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper1.FooterItem.Text = "Provide user name and password"
			Me.nGrouper1.FooterStrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(45)), (CByte(150)))
			Me.nGrouper1.HeaderFillInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(51)), (CByte(153)))
			Me.nGrouper1.HeaderFillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Solid
			Me.nGrouper1.HeaderItem.Image = (CType(resources.GetObject("nGrouper1.HeaderItem.Image"), System.Drawing.Image))
			Me.nGrouper1.HeaderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper1.HeaderItem.ImageSize = New Nevron.GraphicsCore.NSize(32, 32)
			Me.nGrouper1.HeaderItem.ImageTextRelation = Nevron.UI.ImageTextRelation.TextBeforeImage
			Me.nGrouper1.HeaderItem.Style.FontInfo = New Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular)
			Me.nGrouper1.HeaderItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper1.HeaderItem.Text = "Login"
			Me.nGrouper1.HeaderItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nGrouper1.HeaderItem.TreatAsOneEntity = False
			Me.nGrouper1.HeaderStrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(45)), (CByte(150)))
			Me.nGrouper1.Location = New System.Drawing.Point(8, 8)
			Me.nGrouper1.Name = "nGrouper1"
			Me.nGrouper1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue
			Me.nGrouper1.PaletteInheritance = Nevron.UI.WinForm.Controls.PaletteInheritance.None
			Me.nGrouper1.Size = New System.Drawing.Size(232, 216)
			Me.nGrouper1.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(45)), (CByte(150)))
			Me.nGrouper1.TabIndex = 0
			Me.nGrouper1.Text = "nGrouper1"
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(128, 128)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue
			Me.nButton1.Size = New System.Drawing.Size(72, 24)
			Me.nButton1.TabIndex = 4
			Me.nButton1.Text = "Login"
			' 
			' nTextBox2
			' 
			Me.nTextBox2.Location = New System.Drawing.Point(96, 104)
			Me.nTextBox2.Name = "nTextBox2"
			Me.nTextBox2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue
			Me.nTextBox2.PasswordChar = "*"c
			Me.nTextBox2.Size = New System.Drawing.Size(104, 18)
			Me.nTextBox2.TabIndex = 3
			Me.nTextBox2.Text = "Password"
			' 
			' label2
			' 
			Me.label2.BackColor = System.Drawing.Color.Transparent
			Me.label2.Location = New System.Drawing.Point(8, 104)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Password:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nTextBox1
			' 
			Me.nTextBox1.Location = New System.Drawing.Point(96, 80)
			Me.nTextBox1.Name = "nTextBox1"
			Me.nTextBox1.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue
			Me.nTextBox1.Size = New System.Drawing.Size(104, 18)
			Me.nTextBox1.TabIndex = 1
			Me.nTextBox1.Text = "User"
			' 
			' label1
			' 
			Me.label1.BackColor = System.Drawing.Color.Transparent
			Me.label1.Location = New System.Drawing.Point(8, 80)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(80, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "User Name:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' nGrouper3
			' 
			Me.nGrouper3.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(221)), (CByte(221)), (CByte(221)))
			Me.nGrouper3.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(192)), (CByte(192)), (CByte(192)))
			Me.nGrouper3.FooterFillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(90)), (CByte(89)), (CByte(89)))
			Me.nGrouper3.FooterFillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(48)), (CByte(47)), (CByte(47)))
			Me.nGrouper3.FooterFillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nGrouper3.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper3.FooterItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper3.FooterItem.Text = "Footer"
			Me.nGrouper3.FooterStrokeInfo.Draw = False
			Me.nGrouper3.HeaderFillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(48)), (CByte(47)), (CByte(47)))
			Me.nGrouper3.HeaderFillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(90)), (CByte(89)), (CByte(89)))
			Me.nGrouper3.HeaderFillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nGrouper3.HeaderItem.Style.FontInfo = New Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular)
			Me.nGrouper3.HeaderItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper3.HeaderItem.Text = "Header"
			Me.nGrouper3.HeaderStrokeInfo.Draw = False
			Me.nGrouper3.HeaderStrokeInfo.Rounding = 5
			Me.nGrouper3.Location = New System.Drawing.Point(240, 8)
			Me.nGrouper3.Name = "nGrouper3"
			Me.nGrouper3.ShadowInfo.Color = System.Drawing.Color.FromArgb((CByte(51)), (CByte(51)), (CByte(51)))
			Me.nGrouper3.Size = New System.Drawing.Size(240, 216)
			Me.nGrouper3.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nGrouper3.StrokeInfo.Rounding = 5
			Me.nGrouper3.TabIndex = 2
			Me.nGrouper3.Text = "nGrouper3"
			' 
			' NGrouperUC
			' 
			Me.Controls.Add(Me.nGrouper3)
			Me.Controls.Add(Me.nGrouper1)
			Me.Name = "NGrouperUC"
			Me.Size = New System.Drawing.Size(488, 232)
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGrouper1.ResumeLayout(False)
			CType(Me.nGrouper3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nGrouper1 As Nevron.UI.WinForm.Controls.NGrouper
		Private label1 As System.Windows.Forms.Label
		Private nTextBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private nTextBox2 As Nevron.UI.WinForm.Controls.NTextBox
		Private label2 As System.Windows.Forms.Label
		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private nGrouper3 As Nevron.UI.WinForm.Controls.NGrouper

		#End Region
	End Class
End Namespace
