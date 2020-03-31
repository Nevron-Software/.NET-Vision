Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NRangeSlidersUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			m_Image = NResourceHelper.BitmapFromResource(Me.GetType(), "UISplash.png", "Nevron.Examples.UI.WinForm.Resources")
			InitializeComponent()
			Dock = DockStyle.Fill
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

		Private Sub SetupRangeSliders()
			nAnimationSurface1.Size = nuiPanel1.Size
			nhRangeSlider1.Minimum = 0
			nhRangeSlider1.Maximum = nuiPanel1.Width
			nhRangeSlider1.Range = New NRange1DD(0, nAnimationSurface1.Width)

			nvRangeSlider1.Minimum = 0
			nvRangeSlider1.Maximum = nuiPanel1.Height
			nvRangeSlider1.Range = New NRange1DD(0, nAnimationSurface1.Height)
		End Sub

		#End Region

		#Region "Event handlers"

		Private Sub NRangeSlidersUC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			SetupRangeSliders()
			Me.nAnimationSurface1.Image.Image = m_Image
		End Sub

		Private Sub nhRangeSlider1_RangeChanged(ByVal sender As Object, ByVal e As RangeSliderEventArgs) Handles nhRangeSlider1.RangeChanged
			Dim vRange As Integer
			If nvRangeSlider1.Range.GetLength() < 20 Then
				vRange = 20
			Else
				vRange = CInt(Fix(nvRangeSlider1.Range.GetLength()))
			End If
			Dim hRange As Integer
			If nhRangeSlider1.Range.GetLength() < 20 Then
				hRange = 20
			Else
				hRange = CInt(Fix(nhRangeSlider1.Range.GetLength()))
			End If

			If zoomRadio.Checked Then
				nAnimationSurface1.Size = New Size(CInt(Fix(nuiPanel1.Width * nhRangeSlider1.Maximum / hRange)), nAnimationSurface1.Size.Height)
				nAnimationSurface1.Location = New Point(CInt(Fix((-1) * nhRangeSlider1.Maximum / hRange * nhRangeSlider1.Range.Begin)), CInt(Fix((-1) * nvRangeSlider1.Maximum / vRange * nvRangeSlider1.Range.Begin)))
			End If
			If shrinkRadio.Checked Then
				nAnimationSurface1.Size = New Size(hRange, nAnimationSurface1.Size.Height)
				nAnimationSurface1.Location = New Point(CInt(Fix(nhRangeSlider1.Range.Begin)), CInt(Fix(nvRangeSlider1.Range.Begin)))
			End If
		End Sub

		Private Sub nvRangeSlider1_RangeChanged(ByVal sender As Object, ByVal e As RangeSliderEventArgs) Handles nvRangeSlider1.RangeChanged
			Dim vRange As Integer
			If nvRangeSlider1.Range.GetLength() < 20 Then
				vRange = 20
			Else
				vRange = CInt(Fix(nvRangeSlider1.Range.GetLength()))
			End If
			Dim hRange As Integer
			If nhRangeSlider1.Range.GetLength() < 20 Then
				hRange = 20
			Else
				hRange = CInt(Fix(nhRangeSlider1.Range.GetLength()))
			End If


			If zoomRadio.Checked Then
				nAnimationSurface1.Size = New Size(nAnimationSurface1.Size.Width, CInt(Fix(nuiPanel1.Height * nvRangeSlider1.Maximum / vRange)))
				nAnimationSurface1.Location = New Point(CInt(Fix((-1) * nhRangeSlider1.Maximum / hRange * nhRangeSlider1.Range.Begin)), CInt(Fix((-1) * nvRangeSlider1.Maximum / vRange * nvRangeSlider1.Range.Begin)))
			End If
			If shrinkRadio.Checked Then
				nAnimationSurface1.Size = New Size(nAnimationSurface1.Size.Width, vRange)
				nAnimationSurface1.Location = New Point(CInt(Fix(nhRangeSlider1.Range.Begin)), CInt(Fix(nvRangeSlider1.Range.Begin)))
			End If
		End Sub

		Private Sub shrinkRadio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles shrinkRadio.CheckedChanged
			SetupRangeSliders()
		End Sub

		Private Sub zoomRadio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles zoomRadio.CheckedChanged
			SetupRangeSliders()
		End Sub

		#End Region

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NRangeSlidersUC))
			Me.nuiPanel1 = New Nevron.UI.WinForm.Controls.NUIPanel()
			Me.nAnimationSurface1 = New Nevron.UI.WinForm.Controls.NAnimationSurface()
			Me.nvRangeSlider1 = New Nevron.UI.WinForm.Controls.NVRangeSlider()
			Me.nhRangeSlider1 = New Nevron.UI.WinForm.Controls.NHRangeSlider()
			Me.shrinkRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.zoomRadio = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nuiPanel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nuiPanel1
			' 
			Me.nuiPanel1.Controls.Add(Me.nAnimationSurface1)
			Me.nuiPanel1.Location = New System.Drawing.Point(4, 4)
			Me.nuiPanel1.Name = "nuiPanel1"
			Me.nuiPanel1.Size = New System.Drawing.Size(352, 270)
			Me.nuiPanel1.TabIndex = 0
			Me.nuiPanel1.Text = "nuiPanel1"
			' 
			' nAnimationSurface1
			' 
			Me.nAnimationSurface1.AnimationInfo.Fade = True
			Me.nAnimationSurface1.AnimationInfo.Hide = False
			Me.nAnimationSurface1.AnimationInfo.Scroll = False
			Me.nAnimationSurface1.AnimationInfo.Slide = False
			Me.nAnimationSurface1.Location = New System.Drawing.Point(4, 4)
			Me.nAnimationSurface1.Name = "nAnimationSurface1"
			Me.nAnimationSurface1.Size = New System.Drawing.Size(186, 136)
			Me.nAnimationSurface1.TabIndex = 0
			Me.nAnimationSurface1.Text = "nAnimationSurface1"
			' 
			' nvRangeSlider1
			' 
			Me.nvRangeSlider1.LargeChange = 10
			Me.nvRangeSlider1.Location = New System.Drawing.Point(363, 4)
			Me.nvRangeSlider1.Maximum = 100
			Me.nvRangeSlider1.Minimum = 0
			Me.nvRangeSlider1.MinimumSize = New System.Drawing.Size(17, 34)
			Me.nvRangeSlider1.Name = "nvRangeSlider1"
			Me.nvRangeSlider1.Range = (CType(resources.GetObject("nvRangeSlider1.Range"), Nevron.GraphicsCore.NRange1DD))
			Me.nvRangeSlider1.Size = New System.Drawing.Size(17, 270)
			Me.nvRangeSlider1.SmallChange = 1
			Me.nvRangeSlider1.TabIndex = 1
			Me.nvRangeSlider1.Text = "nvRangeSlider1"
			Me.nvRangeSlider1.Value = 0
'			Me.nvRangeSlider1.RangeChanged += New Nevron.UI.WinForm.Controls.RangeSliderEventHandler(Me.nvRangeSlider1_RangeChanged);
			' 
			' nhRangeSlider1
			' 
			Me.nhRangeSlider1.LargeChange = 10
			Me.nhRangeSlider1.Location = New System.Drawing.Point(4, 281)
			Me.nhRangeSlider1.Maximum = 100
			Me.nhRangeSlider1.Minimum = 0
			Me.nhRangeSlider1.MinimumSize = New System.Drawing.Size(34, 17)
			Me.nhRangeSlider1.Name = "nhRangeSlider1"
			Me.nhRangeSlider1.Range = (CType(resources.GetObject("nhRangeSlider1.Range"), Nevron.GraphicsCore.NRange1DD))
			Me.nhRangeSlider1.Size = New System.Drawing.Size(352, 17)
			Me.nhRangeSlider1.SmallChange = 1
			Me.nhRangeSlider1.TabIndex = 2
			Me.nhRangeSlider1.Text = "nhRangeSlider1"
			Me.nhRangeSlider1.Value = 0
'			Me.nhRangeSlider1.RangeChanged += New Nevron.UI.WinForm.Controls.RangeSliderEventHandler(Me.nhRangeSlider1_RangeChanged);
			' 
			' shrinkRadio
			' 
			Me.shrinkRadio.AutoSize = True
			Me.shrinkRadio.ButtonProperties.BorderOffset = 2
			Me.shrinkRadio.Checked = True
			Me.shrinkRadio.Location = New System.Drawing.Point(387, 4)
			Me.shrinkRadio.Name = "shrinkRadio"
			Me.shrinkRadio.Size = New System.Drawing.Size(55, 17)
			Me.shrinkRadio.TabIndex = 4
			Me.shrinkRadio.TabStop = True
			Me.shrinkRadio.Text = "Shrink"
'			Me.shrinkRadio.CheckedChanged += New System.EventHandler(Me.shrinkRadio_CheckedChanged);
			' 
			' zoomRadio
			' 
			Me.zoomRadio.AutoSize = True
			Me.zoomRadio.ButtonProperties.BorderOffset = 2
			Me.zoomRadio.Location = New System.Drawing.Point(387, 28)
			Me.zoomRadio.Name = "zoomRadio"
			Me.zoomRadio.Size = New System.Drawing.Size(52, 17)
			Me.zoomRadio.TabIndex = 5
			Me.zoomRadio.Text = "Zoom"
'			Me.zoomRadio.CheckedChanged += New System.EventHandler(Me.zoomRadio_CheckedChanged);
			' 
			' NRangeSlidersUC
			' 
			Me.Controls.Add(Me.zoomRadio)
			Me.Controls.Add(Me.shrinkRadio)
			Me.Controls.Add(Me.nhRangeSlider1)
			Me.Controls.Add(Me.nvRangeSlider1)
			Me.Controls.Add(Me.nuiPanel1)
			Me.Name = "NRangeSlidersUC"
			Me.Size = New System.Drawing.Size(538, 350)
'			Me.Load += New System.EventHandler(Me.NRangeSlidersUC_Load);
			Me.nuiPanel1.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region            

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nuiPanel1 As NUIPanel
		Private WithEvents nvRangeSlider1 As NVRangeSlider
		Private WithEvents nhRangeSlider1 As NHRangeSlider
		Private nAnimationSurface1 As NAnimationSurface
		Private WithEvents shrinkRadio As NRadioButton
		Private WithEvents zoomRadio As NRadioButton
		Private m_Image As Image

		#End Region    
	End Class
End Namespace
