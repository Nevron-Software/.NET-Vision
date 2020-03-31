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
	''' Summary description for NHyperLinkSupportUC.
	''' </summary>
	Public Class NHyperLinkSupportUC
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

			AddHandler nRichTextLabel1.Item.HyperLinkClick, AddressOf OnHyperLinkClick
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub OnHyperLinkClick(ByVal sender As Object, ByVal e As Nevron.UI.NHyperLinkEventArgs)
			Dim url As String = e.Url
			Process.Start(url)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nRichTextLabel1 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nRichTextLabel1
			' 
			Me.nRichTextLabel1.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista
			Me.nRichTextLabel1.Item.Padding = New Nevron.UI.NPadding(5, 5, 5, 5)
			Me.nRichTextLabel1.Location = New System.Drawing.Point(8, 8)
			Me.nRichTextLabel1.Name = "nRichTextLabel1"
			Me.nRichTextLabel1.Size = New System.Drawing.Size(352, 64)
			Me.nRichTextLabel1.StrokeInfo.PenWidth = 3
			Me.nRichTextLabel1.StrokeInfo.Rounding = 10
			Me.nRichTextLabel1.TabIndex = 0
			Me.nRichTextLabel1.Text = "Since Q4 2006 Nevron Rich Texts support hyper links. For more information visit <" & "a href='http://www.nevron.com'>our web site</a>."
			' 
			' NHyperLinkSupportUC
			' 
			Me.Controls.Add(Me.nRichTextLabel1)
			Me.Name = "NHyperLinkSupportUC"
			Me.Size = New System.Drawing.Size(360, 80)
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nRichTextLabel1 As Nevron.UI.WinForm.Controls.NRichTextLabel

		#End Region
	End Class
End Namespace
