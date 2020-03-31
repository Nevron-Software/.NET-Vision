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
	''' Summary description for NTabStripUC.
	''' </summary>
	Public Class NTabStripUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			Dock = DockStyle.Fill
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

			Dim tab As NTab

			For Each strip As NTabStrip In Controls
				strip.PaletteInheritance = PaletteInheritance.None
				strip.ImageList = m_ImageList

				For i As Integer = 0 To 4
					tab = New NTab()
					tab.ImageIndex = i
					strip.Tabs.Add(tab)
				Next i
			Next strip

			Me.nTabStrip5.ShowFocusRect = False
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NTabStripUC))
			Me.nTabStrip1 = New Nevron.UI.WinForm.Controls.NTabStrip()
			Me.nTabStrip2 = New Nevron.UI.WinForm.Controls.NTabStrip()
			Me.nTabStrip3 = New Nevron.UI.WinForm.Controls.NTabStrip()
			Me.nTabStrip4 = New Nevron.UI.WinForm.Controls.NTabStrip()
			Me.nTabStrip5 = New Nevron.UI.WinForm.Controls.NTabStrip()
			Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.SuspendLayout()
			' 
			' nTabStrip1
			' 
			Me.nTabStrip1.Cursor = System.Windows.Forms.Cursors.Default
			Me.nTabStrip1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nTabStrip1.Location = New System.Drawing.Point(0, 0)
			Me.nTabStrip1.Name = "nTabStrip1"
			Me.nTabStrip1.Selectable = True
			Me.nTabStrip1.SelectedIndex = -1
			Me.nTabStrip1.Size = New System.Drawing.Size(448, 25)
			Me.nTabStrip1.TabIndex = 0
			Me.nTabStrip1.Text = "nTabStrip1"
			' 
			' nTabStrip2
			' 
			Me.nTabStrip2.Cursor = System.Windows.Forms.Cursors.Default
			Me.nTabStrip2.Dock = System.Windows.Forms.DockStyle.Top
			Me.nTabStrip2.Location = New System.Drawing.Point(0, 25)
			Me.nTabStrip2.Name = "nTabStrip2"
			Me.nTabStrip2.Palette.UseThemes = False
			Me.nTabStrip2.Selectable = True
			Me.nTabStrip2.SelectedIndex = -1
			Me.nTabStrip2.Size = New System.Drawing.Size(448, 69)
			Me.nTabStrip2.TabIndex = 1
			Me.nTabStrip2.Text = "nTabStrip2"
			Me.nTabStrip2.TextOrientation = Nevron.UI.TextOrientation.Vertical90
			' 
			' nTabStrip3
			' 
			Me.nTabStrip3.Cursor = System.Windows.Forms.Cursors.Default
			Me.nTabStrip3.Dock = System.Windows.Forms.DockStyle.Left
			Me.nTabStrip3.Location = New System.Drawing.Point(0, 94)
			Me.nTabStrip3.Name = "nTabStrip3"
			Me.nTabStrip3.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.LunaBlue
			Me.nTabStrip3.Selectable = True
			Me.nTabStrip3.SelectedIndex = -1
			Me.nTabStrip3.Size = New System.Drawing.Size(70, 219)
			Me.nTabStrip3.TabAlign = Nevron.UI.WinForm.Controls.TabAlign.Right
			Me.nTabStrip3.TabCurveWidth = 0
			Me.nTabStrip3.TabIndex = 2
			Me.nTabStrip3.Text = "nTabStrip3"
			' 
			' nTabStrip4
			' 
			Me.nTabStrip4.Cursor = System.Windows.Forms.Cursors.Default
			Me.nTabStrip4.Dock = System.Windows.Forms.DockStyle.Right
			Me.nTabStrip4.Location = New System.Drawing.Point(423, 94)
			Me.nTabStrip4.Name = "nTabStrip4"
			Me.nTabStrip4.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Energy
			Me.nTabStrip4.Selectable = True
			Me.nTabStrip4.SelectedIndex = -1
			Me.nTabStrip4.Size = New System.Drawing.Size(25, 219)
			Me.nTabStrip4.TabAlign = Nevron.UI.WinForm.Controls.TabAlign.Left
			Me.nTabStrip4.TabFitMode = Nevron.UI.WinForm.Controls.TabFitMode.Shrink
			Me.nTabStrip4.TabIndex = 3
			Me.nTabStrip4.TabStyle = Nevron.UI.WinForm.Controls.TabStyle.Buttons
			Me.nTabStrip4.Text = "nTabStrip4"
			' 
			' nTabStrip5
			' 
			Me.nTabStrip5.AllowTabReorder = True
			Me.nTabStrip5.Cursor = System.Windows.Forms.Cursors.Default
			Me.nTabStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.nTabStrip5.Location = New System.Drawing.Point(0, 313)
			Me.nTabStrip5.Name = "nTabStrip5"
			Me.nTabStrip5.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.Standard
			Me.nTabStrip5.Selectable = True
			Me.nTabStrip5.SelectedIndex = -1
			Me.nTabStrip5.Size = New System.Drawing.Size(448, 23)
			Me.nTabStrip5.TabAlign = Nevron.UI.WinForm.Controls.TabAlign.Bottom
			Me.nTabStrip5.TabFitMode = Nevron.UI.WinForm.Controls.TabFitMode.Shrink
			Me.nTabStrip5.TabIndex = 4
			Me.nTabStrip5.TabStyle = Nevron.UI.WinForm.Controls.TabStyle.MultiDocument
			Me.nTabStrip5.Text = "nTabStrip5"
			' 
			' m_ImageList
			' 
			Me.m_ImageList.ImageSize = New System.Drawing.Size(16, 16)
			Me.m_ImageList.ImageStream = (CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
			' 
			' NTabStripUC
			' 
			Me.Controls.Add(Me.nTabStrip4)
			Me.Controls.Add(Me.nTabStrip3)
			Me.Controls.Add(Me.nTabStrip2)
			Me.Controls.Add(Me.nTabStrip1)
			Me.Controls.Add(Me.nTabStrip5)
			Me.Name = "NTabStripUC"
			Me.Size = New System.Drawing.Size(448, 336)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.IContainer
		Private nTabStrip1 As Nevron.UI.WinForm.Controls.NTabStrip
		Private nTabStrip2 As Nevron.UI.WinForm.Controls.NTabStrip
		Private nTabStrip3 As Nevron.UI.WinForm.Controls.NTabStrip
		Private nTabStrip4 As Nevron.UI.WinForm.Controls.NTabStrip
		Private m_ImageList As System.Windows.Forms.ImageList
		Private nTabStrip5 As Nevron.UI.WinForm.Controls.NTabStrip

		#End Region
	End Class
End Namespace
