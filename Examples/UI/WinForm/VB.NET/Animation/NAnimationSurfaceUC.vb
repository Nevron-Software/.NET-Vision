Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NAnimationSurfaceUC.
	''' </summary>
	Public Class NAnimationSurfaceUC
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

			Me.nAnimationSurface1.AnimationInfo.Steps = 20
			Me.nAnimationSurface1.AnimationInfo.Interval = 20
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_FadeCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_FadeCheck.CheckedChanged
			nAnimationSurface1.AnimationInfo.Fade = m_FadeCheck.Checked
		End Sub
		Private Sub m_SlideCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_SlideCheck.CheckedChanged
			nAnimationSurface1.AnimationInfo.Slide = m_SlideCheck.Checked
		End Sub
		Private Sub m_ScrollCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ScrollCheck.CheckedChanged
			nAnimationSurface1.AnimationInfo.Scroll = m_ScrollCheck.Checked
		End Sub
		Private Sub m_HideCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_HideCheck.CheckedChanged
			nAnimationSurface1.AnimationInfo.Hide = m_HideCheck.Checked
		End Sub
		Private Sub m_StepsNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_StepsNumeric.ValueChanged
			Me.nAnimationSurface1.AnimationInfo.Steps = CInt(Fix(m_StepsNumeric.Value))
		End Sub
		Private Sub m_IntervalNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_IntervalNumeric.ValueChanged
			Me.nAnimationSurface1.AnimationInfo.Interval = CInt(Fix(m_IntervalNumeric.Value))
		End Sub
		Private Sub nButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nButton1.Click
			NImageAnimator.Instance.Animate(Me.nAnimationSurface1)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NAnimationSurfaceUC))
			Me.nAnimationSurface1 = New Nevron.UI.WinForm.Controls.NAnimationSurface()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_FadeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_SlideCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_IntervalNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_StepsNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_HideCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_ScrollCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGroupBox1.SuspendLayout()
			CType(Me.m_IntervalNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_StepsNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nAnimationSurface1
			' 
			Me.nAnimationSurface1.AnimationInfo.Fade = True
			Me.nAnimationSurface1.AnimationInfo.Hide = False
			Me.nAnimationSurface1.AnimationInfo.Scroll = False
			Me.nAnimationSurface1.AnimationInfo.Slide = False
			Me.nAnimationSurface1.Image.Image = (CType(resources.GetObject("nAnimationSurface1.Image.Image"), System.Drawing.Image))
			Me.nAnimationSurface1.Image.Margins = New NPadding(5, 5, 5, 5)
			Me.nAnimationSurface1.Location = New System.Drawing.Point(8, 8)
			Me.nAnimationSurface1.Name = "nAnimationSurface1"
			Me.nAnimationSurface1.Size = New System.Drawing.Size(256, 280)
			Me.nAnimationSurface1.TabIndex = 0
			Me.nAnimationSurface1.Text = "nAnimationSurface1"
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(392, 264)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.Size = New System.Drawing.Size(80, 24)
			Me.nButton1.TabIndex = 1
			Me.nButton1.Text = "Animate"
'			Me.nButton1.Click += New System.EventHandler(Me.nButton1_Click);
			' 
			' m_FadeCheck
			' 
			Me.m_FadeCheck.Checked = True
			Me.m_FadeCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_FadeCheck.Location = New System.Drawing.Point(64, 72)
			Me.m_FadeCheck.Name = "m_FadeCheck"
			Me.m_FadeCheck.TabIndex = 2
			Me.m_FadeCheck.Text = "Fade"
'			Me.m_FadeCheck.CheckedChanged += New System.EventHandler(Me.m_FadeCheck_CheckedChanged);
			' 
			' m_SlideCheck
			' 
			Me.m_SlideCheck.Location = New System.Drawing.Point(64, 96)
			Me.m_SlideCheck.Name = "m_SlideCheck"
			Me.m_SlideCheck.TabIndex = 3
			Me.m_SlideCheck.Text = "Slide"
'			Me.m_SlideCheck.CheckedChanged += New System.EventHandler(Me.m_SlideCheck_CheckedChanged);
			' 
			' nGroupBox1
			' 
			Me.nGroupBox1.Controls.Add(Me.label2)
			Me.nGroupBox1.Controls.Add(Me.m_IntervalNumeric)
			Me.nGroupBox1.Controls.Add(Me.label1)
			Me.nGroupBox1.Controls.Add(Me.m_StepsNumeric)
			Me.nGroupBox1.Controls.Add(Me.m_HideCheck)
			Me.nGroupBox1.Controls.Add(Me.m_ScrollCheck)
			Me.nGroupBox1.Controls.Add(Me.m_FadeCheck)
			Me.nGroupBox1.Controls.Add(Me.m_SlideCheck)
			Me.nGroupBox1.ImageIndex = 0
			Me.nGroupBox1.Location = New System.Drawing.Point(272, 8)
			Me.nGroupBox1.Name = "nGroupBox1"
			Me.nGroupBox1.Size = New System.Drawing.Size(200, 176)
			Me.nGroupBox1.TabIndex = 4
			Me.nGroupBox1.TabStop = False
			Me.nGroupBox1.Text = "Options"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(48, 16)
			Me.label2.TabIndex = 9
			Me.label2.Text = "Interval:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_IntervalNumeric
			' 
			Me.m_IntervalNumeric.Location = New System.Drawing.Point(64, 48)
			Me.m_IntervalNumeric.Maximum = New System.Decimal(New Integer() { 1000, 0, 0, 0})
			Me.m_IntervalNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.m_IntervalNumeric.Name = "m_IntervalNumeric"
			Me.m_IntervalNumeric.Size = New System.Drawing.Size(56, 20)
			Me.m_IntervalNumeric.TabIndex = 8
			Me.m_IntervalNumeric.Value = New System.Decimal(New Integer() { 20, 0, 0, 0})
'			Me.m_IntervalNumeric.ValueChanged += New System.EventHandler(Me.m_IntervalNumeric_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(40, 16)
			Me.label1.TabIndex = 7
			Me.label1.Text = "Steps:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_StepsNumeric
			' 
			Me.m_StepsNumeric.Location = New System.Drawing.Point(64, 24)
			Me.m_StepsNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.m_StepsNumeric.Name = "m_StepsNumeric"
			Me.m_StepsNumeric.Size = New System.Drawing.Size(56, 20)
			Me.m_StepsNumeric.TabIndex = 6
			Me.m_StepsNumeric.Value = New System.Decimal(New Integer() { 20, 0, 0, 0})
'			Me.m_StepsNumeric.ValueChanged += New System.EventHandler(Me.m_StepsNumeric_ValueChanged);
			' 
			' m_HideCheck
			' 
			Me.m_HideCheck.Location = New System.Drawing.Point(64, 144)
			Me.m_HideCheck.Name = "m_HideCheck"
			Me.m_HideCheck.TabIndex = 5
			Me.m_HideCheck.Text = "Hide"
'			Me.m_HideCheck.CheckedChanged += New System.EventHandler(Me.m_HideCheck_CheckedChanged);
			' 
			' m_ScrollCheck
			' 
			Me.m_ScrollCheck.Location = New System.Drawing.Point(64, 120)
			Me.m_ScrollCheck.Name = "m_ScrollCheck"
			Me.m_ScrollCheck.TabIndex = 4
			Me.m_ScrollCheck.Text = "Scroll"
'			Me.m_ScrollCheck.CheckedChanged += New System.EventHandler(Me.m_ScrollCheck_CheckedChanged);
			' 
			' NAnimationSurfaceUC
			' 
			Me.Controls.Add(Me.nGroupBox1)
			Me.Controls.Add(Me.nButton1)
			Me.Controls.Add(Me.nAnimationSurface1)
			Me.Name = "NAnimationSurfaceUC"
			Me.Size = New System.Drawing.Size(480, 304)
			Me.nGroupBox1.ResumeLayout(False)
			CType(Me.m_IntervalNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_StepsNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nAnimationSurface1 As Nevron.UI.WinForm.Controls.NAnimationSurface
		Private WithEvents nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_FadeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_SlideCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nGroupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents m_ScrollCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_StepsNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents m_IntervalNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents m_HideCheck As Nevron.UI.WinForm.Controls.NCheckBox

		#End Region
	End Class
End Namespace
