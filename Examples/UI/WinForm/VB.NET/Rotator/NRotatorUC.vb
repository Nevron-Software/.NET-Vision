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
	''' Summary description for NRotatorUC.
	''' </summary>
	Public Class NRotatorUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
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

			directionCombo.FillFromEnum(GetType(RotatorDirection))
			directionCombo.SelectedItem = nRotator1.Direction

			frameDurationNumeric.Value = 3000
			animationIntervalNumeric.Value = 50
			animationStepsNumeric.Value = 10

			AddHandler nRotatorFrame3.Content.HyperLinkClick, AddressOf Content_HyperLinkClick

			startBtn_Click(Nothing, Nothing)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub directionCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles directionCombo.SelectedIndexChanged
			nRotator1.Direction = CType(directionCombo.SelectedItem, RotatorDirection)
		End Sub
		Private Sub frameDurationNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles frameDurationNumeric.ValueChanged
			nRotator1.FrameVisibilityDuration = CInt(Fix(frameDurationNumeric.Value))
		End Sub
		Private Sub animationIntervalNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles animationIntervalNumeric.ValueChanged
			nRotator1.FrameAnimationInterval = CInt(Fix(animationIntervalNumeric.Value))
		End Sub
		Private Sub animationStepsNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles animationStepsNumeric.ValueChanged
			nRotator1.FrameAnimationSteps = CInt(Fix(animationStepsNumeric.Value))
		End Sub
		Private Sub Content_HyperLinkClick(ByVal sender As Object, ByVal e As Nevron.UI.NHyperLinkEventArgs)
			Process.Start(e.Url)
		End Sub

		Private Sub startBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles startBtn.Click
			nRotator1.Start()
			stopBtn.Enabled = True
			startBtn.Enabled = False
		End Sub
		Private Sub stopBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles stopBtn.Click
			nRotator1.Stop()
			stopBtn.Enabled = False
			startBtn.Enabled = True
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NRotatorUC))
			Me.nRotator1 = New Nevron.UI.WinForm.Controls.NRotator()
			Me.nRotatorFrame1 = New Nevron.UI.WinForm.Controls.NRotatorFrame()
			Me.nRotatorFrame2 = New Nevron.UI.WinForm.Controls.NRotatorFrame()
			Me.nRotatorFrame3 = New Nevron.UI.WinForm.Controls.NRotatorFrame()
			Me.label1 = New System.Windows.Forms.Label()
			Me.directionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.frameDurationNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.animationIntervalNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.animationStepsNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.startBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.stopBtn = New Nevron.UI.WinForm.Controls.NButton()
			CType(Me.nRotator1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.frameDurationNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.animationIntervalNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.animationStepsNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nRotator1
			' 
			Me.nRotator1.ClientPadding = New Nevron.UI.NPadding(10)
			Me.nRotator1.Frames.AddRange(New Nevron.UI.WinForm.Controls.NRotatorFrame() { Me.nRotatorFrame1, Me.nRotatorFrame2, Me.nRotatorFrame3})
			Me.nRotator1.Location = New System.Drawing.Point(8, 8)
			Me.nRotator1.Name = "nRotator1"
			Me.nRotator1.Size = New System.Drawing.Size(304, 328)
			Me.nRotator1.TabIndex = 0
			Me.nRotator1.Text = "nRotator1"
			' 
			' nRotatorFrame1
			' 
			Me.nRotatorFrame1.Content.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRotatorFrame1.Content.Image = (CType(resources.GetObject("nRotatorFrame1.Content.Image"), System.Drawing.Image))
			Me.nRotatorFrame1.Content.ImageSize = New Nevron.GraphicsCore.NSize(256, 256)
			Me.nRotatorFrame1.Content.ImageTextRelation = Nevron.UI.ImageTextRelation.ImageAboveText
			Me.nRotatorFrame1.Content.Style.FontInfo = New Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Bold)
			Me.nRotatorFrame1.Content.Style.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
			Me.nRotatorFrame1.Content.Text = "Rotator Frame displaying large image"
			' 
			' nRotatorFrame2
			' 
			Me.nRotatorFrame2.Content.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRotatorFrame2.Content.Style.Background = New Nevron.UI.NImageShape(System.Drawing.Drawing2D.SmoothingMode.Default, New Nevron.GraphicsCore.NSize(0, 0), New Nevron.UI.NPadding(0, 0, 0, 0), Nothing, (CType(resources.GetObject("resource"), System.Drawing.Bitmap)), Nothing, -1, Nevron.UI.ImageSizeMode.Stretch, True, Nevron.UI.ImageSegment.All, New Nevron.UI.NPadding(5))
			Me.nRotatorFrame2.Content.Style.FontInfo = New Nevron.UI.NThemeFontInfo("Arial Narrow", 20F, Nevron.GraphicsCore.FontStyleEx.Regular)
			Me.nRotatorFrame2.Content.Style.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
			Me.nRotatorFrame2.Content.Text = "Rotator Frame with custom background specified"
			' 
			' nRotatorFrame3
			' 
			Me.nRotatorFrame3.Content.Text = "Rotator Frame with hyper-link. Click <a href='http://www.nevron.com'>here</a> to " & "visit our web site."
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(320, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(104, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Direction:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' directionCombo
			' 
			Me.directionCombo.Location = New System.Drawing.Point(320, 40)
			Me.directionCombo.Name = "directionCombo"
			Me.directionCombo.Size = New System.Drawing.Size(168, 22)
			Me.directionCombo.TabIndex = 2
			Me.directionCombo.Text = "nComboBox1"
'			Me.directionCombo.SelectedIndexChanged += New System.EventHandler(Me.directionCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(320, 72)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(104, 23)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Frame Duration:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' frameDurationNumeric
			' 
			Me.frameDurationNumeric.Location = New System.Drawing.Point(320, 96)
			Me.frameDurationNumeric.Maximum = New System.Decimal(New Integer() { 5000, 0, 0, 0})
			Me.frameDurationNumeric.Minimum = New System.Decimal(New Integer() { 100, 0, 0, 0})
			Me.frameDurationNumeric.Name = "frameDurationNumeric"
			Me.frameDurationNumeric.Size = New System.Drawing.Size(88, 20)
			Me.frameDurationNumeric.TabIndex = 4
			Me.frameDurationNumeric.Value = New System.Decimal(New Integer() { 3000, 0, 0, 0})
'			Me.frameDurationNumeric.ValueChanged += New System.EventHandler(Me.frameDurationNumeric_ValueChanged);
			' 
			' animationIntervalNumeric
			' 
			Me.animationIntervalNumeric.Location = New System.Drawing.Point(320, 152)
			Me.animationIntervalNumeric.Maximum = New System.Decimal(New Integer() { 500, 0, 0, 0})
			Me.animationIntervalNumeric.Minimum = New System.Decimal(New Integer() { 10, 0, 0, 0})
			Me.animationIntervalNumeric.Name = "animationIntervalNumeric"
			Me.animationIntervalNumeric.Size = New System.Drawing.Size(88, 20)
			Me.animationIntervalNumeric.TabIndex = 6
			Me.animationIntervalNumeric.Value = New System.Decimal(New Integer() { 10, 0, 0, 0})
'			Me.animationIntervalNumeric.ValueChanged += New System.EventHandler(Me.animationIntervalNumeric_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(320, 128)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(104, 23)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Animation Interval:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' animationStepsNumeric
			' 
			Me.animationStepsNumeric.Location = New System.Drawing.Point(320, 208)
			Me.animationStepsNumeric.Maximum = New System.Decimal(New Integer() { 50, 0, 0, 0})
			Me.animationStepsNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.animationStepsNumeric.Name = "animationStepsNumeric"
			Me.animationStepsNumeric.Size = New System.Drawing.Size(88, 20)
			Me.animationStepsNumeric.TabIndex = 8
			Me.animationStepsNumeric.Value = New System.Decimal(New Integer() { 1, 0, 0, 0})
'			Me.animationStepsNumeric.ValueChanged += New System.EventHandler(Me.animationStepsNumeric_ValueChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(320, 184)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(104, 23)
			Me.label4.TabIndex = 7
			Me.label4.Text = "Animation Steps:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' startBtn
			' 
			Me.startBtn.Location = New System.Drawing.Point(8, 344)
			Me.startBtn.Name = "startBtn"
			Me.startBtn.Size = New System.Drawing.Size(144, 32)
			Me.startBtn.TabIndex = 9
			Me.startBtn.Text = "Start"
'			Me.startBtn.Click += New System.EventHandler(Me.startBtn_Click);
			' 
			' stopBtn
			' 
			Me.stopBtn.Location = New System.Drawing.Point(160, 344)
			Me.stopBtn.Name = "stopBtn"
			Me.stopBtn.Size = New System.Drawing.Size(144, 32)
			Me.stopBtn.TabIndex = 10
			Me.stopBtn.Text = "Stop"
'			Me.stopBtn.Click += New System.EventHandler(Me.stopBtn_Click);
			' 
			' NRotatorUC
			' 
			Me.Controls.Add(Me.stopBtn)
			Me.Controls.Add(Me.startBtn)
			Me.Controls.Add(Me.animationStepsNumeric)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.animationIntervalNumeric)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.frameDurationNumeric)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.directionCombo)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.nRotator1)
			Me.Name = "NRotatorUC"
			Me.Size = New System.Drawing.Size(496, 392)
			CType(Me.nRotator1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.frameDurationNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.animationIntervalNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.animationStepsNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private label1 As System.Windows.Forms.Label
		Private WithEvents directionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents frameDurationNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents animationIntervalNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private WithEvents animationStepsNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private nRotatorFrame1 As Nevron.UI.WinForm.Controls.NRotatorFrame
		Private nRotatorFrame2 As Nevron.UI.WinForm.Controls.NRotatorFrame
		Private nRotatorFrame3 As Nevron.UI.WinForm.Controls.NRotatorFrame
		Private WithEvents startBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents stopBtn As Nevron.UI.WinForm.Controls.NButton
		Private nRotator1 As Nevron.UI.WinForm.Controls.NRotator

		#End Region
	End Class
End Namespace
