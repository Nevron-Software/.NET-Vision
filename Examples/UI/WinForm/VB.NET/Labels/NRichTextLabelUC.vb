Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NRichTextLabelUC.
	''' </summary>
	Public Class NRichTextLabelUC
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
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NRichTextLabelUC))
			Me.nRichTextLabel1 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nRichTextLabel2 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.nRichTextLabel3 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nRichTextLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nRichTextLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nRichTextLabel1
			' 
			Me.nRichTextLabel1.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(90)), (CByte(125)), (CByte(222)))
			Me.nRichTextLabel1.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(155)), (CByte(186)), (CByte(247)))
			Me.nRichTextLabel1.FillInfo.GradientAngle = 15F
			Me.nRichTextLabel1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRichTextLabel1.Item.Image = (CType(resources.GetObject("nRichTextLabel1.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel1.Item.ImageSize = New Nevron.GraphicsCore.NSize(28, 28)
			Me.nRichTextLabel1.Item.Padding = New Nevron.UI.NPadding(5, 5, 5, 5)
			Me.nRichTextLabel1.Location = New System.Drawing.Point(8, 8)
			Me.nRichTextLabel1.Name = "nRichTextLabel1"
			Me.nRichTextLabel1.Size = New System.Drawing.Size(296, 72)
			Me.nRichTextLabel1.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(0)), (CByte(45)), (CByte(150)))
			Me.nRichTextLabel1.StrokeInfo.PenWidth = 2
			Me.nRichTextLabel1.StrokeInfo.Rounding = 10
			Me.nRichTextLabel1.TabIndex = 0
			Me.nRichTextLabel1.Text = "<font face='Tahoma' color='white'>The Nevron <b><u><font color='whitesmoke'>NRich" & "TextLabel</font></u></b> is a <i><b>revolutionary</b></i> component which allows" & " you to display <font color='red'><b>HTML</b></font> formatted texts with ease.<" & "/font>"
			' 
			' nRichTextLabel2
			' 
			Me.nRichTextLabel2.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass
			Me.nRichTextLabel2.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(102)), (CByte(0)))
			Me.nRichTextLabel2.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nRichTextLabel2.FillInfo.GradientAngle = 15F
			Me.nRichTextLabel2.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nRichTextLabel2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRichTextLabel2.Item.Image = (CType(resources.GetObject("nRichTextLabel2.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel2.Item.ImageSize = New Nevron.GraphicsCore.NSize(28, 28)
			Me.nRichTextLabel2.Item.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nRichTextLabel2.Item.Padding = New Nevron.UI.NPadding(5, 5, 5, 5)
			Me.nRichTextLabel2.Item.Text = ""
			Me.nRichTextLabel2.Item.TextOrientation = Nevron.UI.TextOrientation.Vertical90
			Me.nRichTextLabel2.Location = New System.Drawing.Point(8, 88)
			Me.nRichTextLabel2.Name = "nRichTextLabel2"
			Me.nRichTextLabel2.Size = New System.Drawing.Size(88, 240)
			Me.nRichTextLabel2.StrokeInfo.Color = System.Drawing.Color.FromArgb((CByte(204)), (CByte(0)), (CByte(0)))
			Me.nRichTextLabel2.StrokeInfo.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
			Me.nRichTextLabel2.StrokeInfo.PenWidth = 2
			Me.nRichTextLabel2.StrokeInfo.Rounding = 10
			Me.nRichTextLabel2.TabIndex = 1
			Me.nRichTextLabel2.Text = "<font face='Tahoma'>The Nevron <b><u><font color='whitesmoke'>NRichTextLabel</fon" & "t></u></b> is a <i><b>revolutionary</b></i> component which allows you to displa" & "y <font color='red'><b>HTML</b></font> formatted texts with ease.</font>"
			' 
			' nRichTextLabel3
			' 
			Me.nRichTextLabel3.FillInfo.FillStyle = Nevron.UI.WinForm.Controls.FillStyle.Glass
			Me.nRichTextLabel3.FillInfo.Gradient1 = System.Drawing.Color.FromArgb((CByte(225)), (CByte(212)), (CByte(192)))
			Me.nRichTextLabel3.FillInfo.Gradient2 = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nRichTextLabel3.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			Me.nRichTextLabel3.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRichTextLabel3.Item.Image = (CType(resources.GetObject("nRichTextLabel3.Item.Image"), System.Drawing.Image))
			Me.nRichTextLabel3.Item.ImageSize = New Nevron.GraphicsCore.NSize(28, 28)
			Me.nRichTextLabel3.Item.ImageTextRelation = Nevron.UI.ImageTextRelation.TextAboveImage
			Me.nRichTextLabel3.Item.Padding = New Nevron.UI.NPadding(5, 5, 5, 5)
			Me.nRichTextLabel3.Item.Text = ""
			Me.nRichTextLabel3.Item.TextOrientation = Nevron.UI.TextOrientation.Vertical270
			Me.nRichTextLabel3.Location = New System.Drawing.Point(112, 88)
			Me.nRichTextLabel3.Name = "nRichTextLabel3"
			Me.nRichTextLabel3.ShadowInfo.Color = System.Drawing.Color.FromArgb((CByte(28)), (CByte(28)), (CByte(28)))
			Me.nRichTextLabel3.Size = New System.Drawing.Size(88, 240)
			Me.nRichTextLabel3.StrokeInfo.Color = System.Drawing.Color.Brown
			Me.nRichTextLabel3.StrokeInfo.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
			Me.nRichTextLabel3.StrokeInfo.PenWidth = 2
			Me.nRichTextLabel3.StrokeInfo.Rounding = 10
			Me.nRichTextLabel3.TabIndex = 2
			Me.nRichTextLabel3.Text = "<font face='Tahoma' color='brown'>The Nevron <b><u><font color='black'>NRichTextL" & "abel</font></u></b> is a <i><b>revolutionary</b></i> component which allows you " & "to display <font color='red'><b>HTML</b></font> formatted texts with ease.</font" & ">"
			' 
			' NRichTextLabelUC
			' 
			Me.Controls.Add(Me.nRichTextLabel3)
			Me.Controls.Add(Me.nRichTextLabel2)
			Me.Controls.Add(Me.nRichTextLabel1)
			Me.Name = "NRichTextLabelUC"
			Me.Size = New System.Drawing.Size(312, 336)
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nRichTextLabel2, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nRichTextLabel3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nRichTextLabel2 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nRichTextLabel3 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private nRichTextLabel1 As Nevron.UI.WinForm.Controls.NRichTextLabel

		#End Region
	End Class
End Namespace
