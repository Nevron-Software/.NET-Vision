Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm


Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NGroupBoxEx.
	''' </summary>
	Public Class NGroupBoxExUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Component Designer generated code"

		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NGroupBoxExUC))
			Me.nGroupBoxEx1 = New Nevron.UI.WinForm.Controls.NGroupBoxEx()
			Me.nRadioButton1 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nCheckBox1 = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nColorPool1 = New Nevron.UI.WinForm.Controls.NColorPool()
			CType(Me.nGroupBoxEx1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBoxEx1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBoxEx1
			' 
			Me.nGroupBoxEx1.Controls.Add(Me.nRadioButton1)
			Me.nGroupBoxEx1.Controls.Add(Me.nCheckBox1)
			Me.nGroupBoxEx1.Controls.Add(Me.nColorPool1)
			Me.nGroupBoxEx1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(153)), (CByte(204)), (CByte(255)))
			Me.nGroupBoxEx1.FillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText
			Me.nGroupBoxEx1.FillInfo.GradientAngle = 45F
			Me.nGroupBoxEx1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista
			Me.nGroupBoxEx1.HeaderFillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(0)), (CByte(102)), (CByte(204)))
			Me.nGroupBoxEx1.HeaderFillInfo.Gradient2 = System.Drawing.SystemColors.ActiveCaptionText
			Me.nGroupBoxEx1.HeaderFillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista
			Me.nGroupBoxEx1.HeaderItem.Image = (CType(resources.GetObject("nGroupBoxEx1.HeaderItem.Image"), System.Drawing.Image))
			Me.nGroupBoxEx1.HeaderItem.ImageSize = New Nevron.GraphicsCore.NSize(24, 24)
			Me.nGroupBoxEx1.HeaderItem.Text = "NGroupBoxEx"
			Me.nGroupBoxEx1.HeaderStrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(51)), (CByte(153)))
			Me.nGroupBoxEx1.HeaderStrokeInfo.Rounding = 5
			Me.nGroupBoxEx1.Location = New System.Drawing.Point(16, 16)
			Me.nGroupBoxEx1.Name = "nGroupBoxEx1"
			Me.nGroupBoxEx1.Size = New System.Drawing.Size(432, 272)
			Me.nGroupBoxEx1.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(102)), (CByte(204)))
			Me.nGroupBoxEx1.StrokeInfo.PenWidth = 5
			Me.nGroupBoxEx1.StrokeInfo.Rounding = 5
			Me.nGroupBoxEx1.TabIndex = 0
			Me.nGroupBoxEx1.Text = "nGroupBoxEx1"
			' 
			' nRadioButton1
			' 
			Me.nRadioButton1.Location = New System.Drawing.Point(264, 152)
			Me.nRadioButton1.Name = "nRadioButton1"
			Me.nRadioButton1.TabIndex = 5
			Me.nRadioButton1.Text = "nRadioButton1"
			Me.nRadioButton1.TransparentBackground = True
			' 
			' nCheckBox1
			' 
			Me.nCheckBox1.Location = New System.Drawing.Point(264, 104)
			Me.nCheckBox1.Name = "nCheckBox1"
			Me.nCheckBox1.TabIndex = 4
			Me.nCheckBox1.Text = "nCheckBox1"
			Me.nCheckBox1.TransparentBackground = True
			' 
			' nColorPool1
			' 
			Me.nColorPool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.nColorPool1.Color = System.Drawing.Color.Empty
			Me.nColorPool1.Hue = 0F
			Me.nColorPool1.Location = New System.Drawing.Point(48, 96)
			Me.nColorPool1.Luminance = 0.5F
			Me.nColorPool1.Name = "nColorPool1"
			Me.nColorPool1.Saturation = 0F
			Me.nColorPool1.Size = New System.Drawing.Size(202, 102)
			Me.nColorPool1.TabIndex = 2
			' 
			' NGroupBoxExUC
			' 
			Me.Controls.Add(Me.nGroupBoxEx1)
			Me.Name = "NGroupBoxExUC"
			Me.Size = New System.Drawing.Size(512, 352)
			CType(Me.nGroupBoxEx1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBoxEx1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub


		#End Region

		#Region "Fields"

		Private nGroupBoxEx1 As Nevron.UI.WinForm.Controls.NGroupBoxEx
		Private nColorPool1 As Nevron.UI.WinForm.Controls.NColorPool
		Private nCheckBox1 As Nevron.UI.WinForm.Controls.NCheckBox
		Private nRadioButton1 As Nevron.UI.WinForm.Controls.NRadioButton

		#End Region
	End Class
End Namespace
