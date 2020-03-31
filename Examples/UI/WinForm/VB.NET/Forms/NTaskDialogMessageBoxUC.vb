Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NTaskDialogMessageBoxUC.
	''' </summary>
	Public Class NTaskDialogMessageBoxUC
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

			m_CallBack = New NTaskDialogCallBack(AddressOf OnCallBack)
		End Sub


		#End Region

		#Region "Implementation"

		Friend Function CreateDefaultDialog() As NTaskDialog
			Dim dlg As NTaskDialog = New NTaskDialog()
			dlg.Title = "Nevron User Interface Q4 2006"
			dlg.Content.Text = "Download of Nevron .NET Vision Q4 2006 is complete!"
			dlg.Content.Image = NSystemImages.Information
			dlg.Content.ImageSize = New NSize(32, 32)

			Return dlg
		End Function


		#End Region

		#Region "Event Handlers"

		Private Sub standardMessageBoxBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles standardMessageBoxBtn.Click
			Dim dlg As NTaskDialog = CreateDefaultDialog()
			'dlg.PredefinedButtons = TaskDialogButtons.Ok;
			dlg.PreferredWidth = 360

			dlg.Show()
		End Sub

		Private Sub customizedMessageBoxBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles customizedMessageBoxBtn.Click
			Dim dlg As NTaskDialog = New NTaskDialog()
			dlg.PreferredWidth = 400
			dlg.ProgressType = TaskDialogProgressType.Marguee
			dlg.MarqueeProgress.Start()

			dlg.Title = "Nevron User Interface Q4 2006"
			dlg.Content.Style.TextStrokeStyle = New NStrokeStyle(1, Color.Brown)
			dlg.Content.Style.TextFillStyle = New NColorFillStyle(Color.Wheat)
			dlg.Content.Style.TextSmoothingMode = SmoothingMode.AntiAlias
			dlg.Content.Style.FontInfo = New NThemeFontInfo("Trebuchet MS", 22f, FontStyleEx.Bold Or FontStyleEx.Italic)
			dlg.Content.Text = "Downloading Nevron .NET Vision Q4 2006..."

			Dim customButtons As NPushButtonElement() = New NPushButtonElement(1){}
			Dim btn As NPushButtonElement

			btn = New NPushButtonElement()
			btn.Text = "<b>Cancel Download</b>"
			btn.Image = NSystemImages.Error
			btn.ImageTextRelation = ImageTextRelation.ImageAboveText
			btn.ImageSize = New NSize(32, 32)
			btn.Id = 0
			customButtons(0) = btn

			btn = New NPushButtonElement()
			btn.Text = "<b>Pause Download</b>"
			btn.Image = NSystemImages.Exclamation
			btn.ImageTextRelation = ImageTextRelation.ImageAboveText
			btn.ImageSize = New NSize(32, 32)
			btn.Id = 1
			customButtons(1) = btn

			dlg.UserButtons = customButtons
			dlg.DefaultButtonId = 2

			dlg.Show()
		End Sub

		Private Sub vistaLikeNotification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles vistaLikeNotification.Click
			Dim dlg As NTaskDialog = New NTaskDialog()
			dlg.Title = "Copy File"
			dlg.PreferredWidth = 480
			dlg.PredefinedButtons = TaskDialogButtons.Cancel

			Dim fi As NThemeFontInfo = New NThemeFontInfo("Tahoma", 9, FontStyleEx.Regular)

			Dim label As NLabelElement = dlg.Content
			label.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			label.Text = "<font color='navy' size='11' face='Tahoma'>There is already a file with the same name in this location.</font><br/><br/>What would you like to do:"

			Dim largeButtons As NPushButtonElement() = New NPushButtonElement(2){}
			Dim button As NPushButtonElement
			Dim text As String

			button = New NPushButtonElement()
			button.Id = 100
			button.TreatAsOneEntity = False
			button.ImageAlign = ContentAlignment.TopLeft
			button.TextAlign = ContentAlignment.TopLeft
			button.Image = NSystemImages.Question
			button.ImageSize = New NSize(32, 32)
			button.ContentAlign = ContentAlignment.MiddleLeft
			button.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			button.Style.FontInfo = fi
			text = "<font color='navy' size='12'>Copy and replace</font><br/><font color='navy'>Replace the file in the destination folder with the file you are copying:</font><br/>"
			text &= "<b>NTaskDialog.cs</b><br/>"
			text &= "<font color='navy'>NTaskDialog (C:\Projects\UI\WinForm\Controls\Forms\TaskDialog)</font>"
			text &= "<br/>Size: 14 KB<br/>"
			text &= "Date Modified: 03/03/2007 10:00 AM (Newer)"
			button.Text = text
			largeButtons(0) = button

			button = New NPushButtonElement()
			button.Id = 101
			button.TreatAsOneEntity = False
			button.ImageAlign = ContentAlignment.TopLeft
			button.TextAlign = ContentAlignment.TopLeft
			button.Image = NSystemImages.Question
			button.ImageSize = New NSize(32, 32)
			button.ContentAlign = ContentAlignment.MiddleLeft
			button.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			button.Style.FontInfo = fi
			text = "<font color='navy' size='12'>Don't Copy</font><br/><font color='navy'>No files will be changed. Leave this file in the destination folder:</font><br/>"
			text &= "<b>NTaskDialog.cs</b><br/>"
			text &= "<font color='navy'>NTaskDialog (C:\OldProjects\UI\WinForm\Controls\Forms\TaskDialog)</font>"
			text &= "<br/>Size: 12 KB (Smaller)<br/>"
			text &= "Date Modified: 03/03/2007 09:00 AM"
			button.Text = text
			largeButtons(1) = button

			button = New NPushButtonElement()
			button.Id = 102
			button.TreatAsOneEntity = False
			button.ImageAlign = ContentAlignment.TopLeft
			button.TextAlign = ContentAlignment.TopLeft
			button.Image = NSystemImages.Question
			button.ImageSize = New NSize(32, 32)
			button.ContentAlign = ContentAlignment.MiddleLeft
			button.Style.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			button.Style.FontInfo = fi
			text = "<font color='navy' size='12'>Copy, but keep both files</font><br/><font color='navy'>The file you are copying will be renamed ""NTaskDialog (2).cs""</font>"
			button.Text = text
			largeButtons(2) = button

			dlg.DefaultButtonId = 100
			dlg.LargeUserButtons = largeButtons
			dlg.Show()
		End Sub

		Private Sub progressDialogBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles progressDialogBtn.Click
			Dim dlg As NTaskDialog = New NTaskDialog()
			dlg.PreferredWidth = 400
			dlg.ProgressType = TaskDialogProgressType.Standard

			dlg.Title = "Nevron User Interface Q4 2006"
			dlg.Content.Style.FontInfo = New NThemeFontInfo("Tahoma", 10f, FontStyleEx.Regular)
			dlg.Content.Text = "Downloading Nevron .NET Vision Q4 2006..."
			dlg.Content.Image = NSystemImages.Information
			dlg.Content.ImageSize = New NSize(32, 32)
			dlg.ProgressType = TaskDialogProgressType.Standard
			dlg.EnableTimer = True
			dlg.Verification.Text = "Close this dialog when download is complete"
			AddHandler dlg.Notify, m_CallBack

			'inint buttons
			Dim cancelBtn As NPushButtonElement = New NPushButtonElement()
			cancelBtn.Text = "Cancel"
			cancelBtn.Id = 100

			Dim pauseBtn As NPushButtonElement = New NPushButtonElement()
			pauseBtn.Text = "Pause"
			pauseBtn.Id = 101

			Dim resumeBtn As NPushButtonElement = New NPushButtonElement()
			resumeBtn.Text = "Resume"
			resumeBtn.Id = 102

			dlg.UserButtons = New NPushButtonElement() {cancelBtn, pauseBtn, resumeBtn}
			'the defaulted button is "Pause"
			dlg.DefaultButtonId = 101
			dlg.Show()
		End Sub

		Private Sub OnCallBack(ByVal sender As Object, ByVal e As NTaskDialogEventArgs)
			Select Case e.Notification
				Case TaskDialogNotification.ButtonClick
					Dim id As Integer = (CType(sender, NPushButtonElement)).Id
					If id = 100 Then 'cancel button; leave default implementation
						Exit Select
					End If

				Select Case id
					Case 101 'pause button
						m_bPaused = True
					Case 102 'resume button
						m_bPaused = False
				End Select
					'prevent the default implementation of the click which will close the dialog
					e.Cancel = True

				Case TaskDialogNotification.TimerTick
					If m_bPaused Then
						Exit Select
					End If

					Dim dlg As NTaskDialog = e.Dialog
					Dim progress As NProgressBarElement = dlg.ProgressBar

					progress.Value += 1
					If progress.Value = progress.Maximum Then
						If dlg.Verification.CheckState = CheckState.Checked Then
							e.Form.Close()
						End If
					End If
			End Select
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.standardMessageBoxBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.customizedMessageBoxBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.vistaLikeNotification = New Nevron.UI.WinForm.Controls.NButton()
			Me.progressDialogBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' standardMessageBoxBtn
			' 
			Me.standardMessageBoxBtn.Location = New System.Drawing.Point(8, 8)
			Me.standardMessageBoxBtn.Name = "standardMessageBoxBtn"
			Me.standardMessageBoxBtn.Size = New System.Drawing.Size(160, 24)
			Me.standardMessageBoxBtn.TabIndex = 0
			Me.standardMessageBoxBtn.Text = "Standard Message Box..."
'			Me.standardMessageBoxBtn.Click += New System.EventHandler(Me.standardMessageBoxBtn_Click);
			' 
			' customizedMessageBoxBtn
			' 
			Me.customizedMessageBoxBtn.Location = New System.Drawing.Point(8, 72)
			Me.customizedMessageBoxBtn.Name = "customizedMessageBoxBtn"
			Me.customizedMessageBoxBtn.Size = New System.Drawing.Size(160, 24)
			Me.customizedMessageBoxBtn.TabIndex = 1
			Me.customizedMessageBoxBtn.Text = "Marquee Progress Dialog..."
'			Me.customizedMessageBoxBtn.Click += New System.EventHandler(Me.customizedMessageBoxBtn_Click);
			' 
			' vistaLikeNotification
			' 
			Me.vistaLikeNotification.Location = New System.Drawing.Point(8, 104)
			Me.vistaLikeNotification.Name = "vistaLikeNotification"
			Me.vistaLikeNotification.Size = New System.Drawing.Size(160, 24)
			Me.vistaLikeNotification.TabIndex = 2
			Me.vistaLikeNotification.Text = "Vista-like Copy Notification..."
'			Me.vistaLikeNotification.Click += New System.EventHandler(Me.vistaLikeNotification_Click);
			' 
			' progressDialogBtn
			' 
			Me.progressDialogBtn.Location = New System.Drawing.Point(8, 40)
			Me.progressDialogBtn.Name = "progressDialogBtn"
			Me.progressDialogBtn.Size = New System.Drawing.Size(160, 24)
			Me.progressDialogBtn.TabIndex = 3
			Me.progressDialogBtn.Text = "Progress Dialog..."
'			Me.progressDialogBtn.Click += New System.EventHandler(Me.progressDialogBtn_Click);
			' 
			' NTaskDialogMessageBoxUC
			' 
			Me.Controls.Add(Me.progressDialogBtn)
			Me.Controls.Add(Me.vistaLikeNotification)
			Me.Controls.Add(Me.customizedMessageBoxBtn)
			Me.Controls.Add(Me.standardMessageBoxBtn)
			Me.Name = "NTaskDialogMessageBoxUC"
			Me.Size = New System.Drawing.Size(176, 136)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_CallBack As NTaskDialogCallBack
		Friend m_bPaused As Boolean
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents standardMessageBoxBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents vistaLikeNotification As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents progressDialogBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents customizedMessageBoxBtn As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace
