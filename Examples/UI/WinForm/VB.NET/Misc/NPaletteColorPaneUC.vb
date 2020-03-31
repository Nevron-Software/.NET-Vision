Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NPaletteColorPane.
	''' </summary>
	Public Class NPaletteColorPaneUC
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

			Dim palette As NArgbColorValuePalette = New NArgbColorValuePalette()
			palette.SetPredefinedPalette(PredefinedPalette.Office2003)

			paletteColorPane1.ColorPalette = palette
			AddHandler paletteColorPane1.MouseLeave, AddressOf paletteColorPane1_MouseLeave
		End Sub



		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.paletteColorPane1 = New Nevron.UI.WinForm.Controls.NPaletteColorPane()
			Me.nEntryContainer1 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nEntryContainer2 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nPaletteColorPane1 = New Nevron.UI.WinForm.Controls.NPaletteColorPane()
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer1.SuspendLayout()
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' paletteColorPane1
			' 
			Me.paletteColorPane1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent
			Me.paletteColorPane1.Location = New System.Drawing.Point(109, 3)
			Me.paletteColorPane1.Name = "paletteColorPane1"
			Me.paletteColorPane1.Selectable = True
			Me.paletteColorPane1.Size = New System.Drawing.Size(179, 117)
			Me.paletteColorPane1.TabIndex = 2
			' 
			' nEntryContainer1
			' 
			Me.nEntryContainer1.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer1.EntryControl = Me.paletteColorPane1
			Me.nEntryContainer1.Item.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(204)), (CByte(0)), (CByte(0))))
			Me.nEntryContainer1.Item.Style.TextShadowStyle = New Nevron.GraphicsCore.NShadowStyle(Nevron.GraphicsCore.ShadowType.LinearBlur, New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(128)), (CByte(128)), (CByte(128))), 1, 1, 1F, 1)
			Me.nEntryContainer1.Location = New System.Drawing.Point(8, 8)
			Me.nEntryContainer1.Name = "nEntryContainer1"
			Me.nEntryContainer1.Size = New System.Drawing.Size(296, 128)
			Me.nEntryContainer1.TabIndex = 4
			Me.nEntryContainer1.Text = "Office 2003 Palette:"
			' 
			' nEntryContainer2
			' 
			Me.nEntryContainer2.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer2.EntryControl = Me.nPaletteColorPane1
			Me.nEntryContainer2.Item.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(204)), (CByte(0)), (CByte(0))))
			Me.nEntryContainer2.Item.Style.TextShadowStyle = New Nevron.GraphicsCore.NShadowStyle(Nevron.GraphicsCore.ShadowType.LinearBlur, New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(128)), (CByte(128)), (CByte(128))), 1, 1, 1F, 1)
			Me.nEntryContainer2.Location = New System.Drawing.Point(8, 144)
			Me.nEntryContainer2.Name = "nEntryContainer2"
			Me.nEntryContainer2.Size = New System.Drawing.Size(296, 152)
			Me.nEntryContainer2.TabIndex = 5
			Me.nEntryContainer2.Text = "Color Dialog Palette:"
			' 
			' nPaletteColorPane1
			' 
			Me.nPaletteColorPane1.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent
			Me.nPaletteColorPane1.Location = New System.Drawing.Point(111, 3)
			Me.nPaletteColorPane1.Name = "nPaletteColorPane1"
			Me.nPaletteColorPane1.PredefinedPalette = Nevron.GraphicsCore.PredefinedPalette.Default
			Me.nPaletteColorPane1.Selectable = True
			Me.nPaletteColorPane1.Size = New System.Drawing.Size(177, 141)
			Me.nPaletteColorPane1.TabIndex = 2
			' 
			' NPaletteColorPaneUC
			' 
			Me.Controls.Add(Me.nEntryContainer2)
			Me.Controls.Add(Me.nEntryContainer1)
			Me.Name = "NPaletteColorPaneUC"
			Me.Size = New System.Drawing.Size(312, 304)
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer1.ResumeLayout(False)
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nEntryContainer1 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nEntryContainer2 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nPaletteColorPane1 As Nevron.UI.WinForm.Controls.NPaletteColorPane
		Private paletteColorPane1 As Nevron.UI.WinForm.Controls.NPaletteColorPane

		#End Region

		Private Sub paletteColorPane1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace