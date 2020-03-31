Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm
Imports Nevron.GraphicsCore
Imports Nevron.GraphicsCore.Text

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NPopupNotifyUC.
	''' </summary>
	Public Class NPopupNotifyUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()

			InitDefaultPopup()
			InitOffice2003Popup()
			InitMessengerPopup()
			InitShapedPopups()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				m_Office2003Popup.Dispose()
				m_MessengerPopup.Dispose()
				m_ShapedPopup1.Dispose()
				m_ShapedPopup2.Dispose()
				m_ShapedPopup3.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			animationDirectionCombo.FillFromEnum(GetType(PopupAnimationDirection))
			animationDirectionCombo.SelectedItem = PopupAnimationDirection.Automatic
		End Sub


		#End Region

		#Region "Implementation"

		Friend Sub ShowPopup(ByVal popup As NPopupNotify)
			Dim animation As PopupAnimation = PopupAnimation.None
			If m_FadeCheck.Checked Then
				animation = animation Or PopupAnimation.Fade
			End If
			If m_SlideCheck.Checked Then
				animation = animation Or PopupAnimation.Slide
			End If

			popup.AutoHide = m_AutoHideCheck.Checked
			popup.VisibleSpan = CInt(Fix(m_VisibleSpanNumeric.Value))
			popup.Opacity = CInt(Fix(m_OpacityNumeric.Value))
			popup.Animation = animation
			popup.AnimationDirection = CType(animationDirectionCombo.SelectedItem, PopupAnimationDirection)
			popup.VisibleOnMouseOver = m_StayVisibleCheck.Checked
			popup.FullOpacityOnMouseOver = m_FullOpacityCheck.Checked
			popup.AnimationInterval = CInt(Fix(m_IntervalNumeric.Value))
			popup.AnimationSteps = CInt(Fix(m_StepsNumeric.Value))

			popup.Palette.Copy(NUIManager.Palette)
			popup.Show()
		End Sub

		Friend Sub InitDefaultPopup()
			m_SkinPopup = New NPopupNotify()
			m_SkinPopup.OptionsButton = True
			m_SkinPopup.PredefinedStyle = PredefinedPopupStyle.Skinned
			m_SkinPopup.Font = New Font("Tahoma", 8.0f)

			m_SkinPopup.Caption.Content.Text = "Skinnable Popup"

			Dim content As NImageAndTextItem = m_SkinPopup.Content
			content.Image = imageList1.Images(1)
			content.ImageSize = New Nevron.GraphicsCore.NSize(28, 28)

			content.TextMargins = New NPadding(0, 4, 0, 0)
			content.Text = "<b>Peter Brown</b><br>Re: Thank you for purchasing Nevron UI</br><br><font color='navy'>See comments below</font></br>"
			AddHandler content.Click, AddressOf OnContentClick

			Dim comm As Nevron.UI.WinForm.Controls.NCommand
			Dim coll As NCommandCollection = m_SkinPopup.OptionsCommands

			For i As Integer = 1 To 5
				comm = New Nevron.UI.WinForm.Controls.NCommand()
				comm.Properties.Text = "Options command " & i.ToString()
				coll.Add(comm)
			Next i
		End Sub
		Friend Sub InitOffice2003Popup()
			m_Office2003Popup = New NPopupNotify()
			m_Office2003Popup.PredefinedStyle = PredefinedPopupStyle.Office2003
			m_Office2003Popup.Font = New Font("Tahoma", 8.0f)

			Dim content As NImageAndTextItem = m_Office2003Popup.Content
			content.Image = imageList1.Images(1)
			content.ImageSize = New Nevron.GraphicsCore.NSize(28, 28)

			content.TextMargins = New NPadding(0, 4, 0, 0)
			content.Text = "<b>Peter Brown</b><br>Re: Thank you for purchasing Nevron UI</br><br><font color='navy'>See comments below</font></br>"
			AddHandler content.Click, AddressOf OnContentClick

			Dim comm As Nevron.UI.WinForm.Controls.NCommand
			Dim coll As NCommandCollection = m_Office2003Popup.OptionsCommands

			For i As Integer = 1 To 5
				comm = New Nevron.UI.WinForm.Controls.NCommand()
				comm.Properties.Text = "Options command " & i.ToString()
				coll.Add(comm)
			Next i
		End Sub
		Friend Sub InitMessengerPopup()
			m_MessengerPopup = New NPopupNotify()
			m_MessengerPopup.PredefinedStyle = PredefinedPopupStyle.Messenger
			m_MessengerPopup.Font = New Font("Tahoma", 8.0f)

			m_MessengerPopup.Caption.Content.Image = imageList2.Images(0)
			m_MessengerPopup.Caption.Content.Text = "<b><font color='Navy'>Messenger Style Popup</font></b><br/>"
			m_MessengerPopup.Content.ContentAlign = ContentAlignment.TopLeft
			m_MessengerPopup.Content.Image = imageList1.Images(1)
			m_MessengerPopup.Content.ImageSize = New Nevron.GraphicsCore.NSize(28, 28)
			m_MessengerPopup.Content.Padding = New NPadding(4)
			m_MessengerPopup.Content.Text = "<b><u>Notification Content</u></b><br/>You have <u>complete</u> control over text <i>visualization!</i>"
			AddHandler m_MessengerPopup.Content.Click, AddressOf OnContentClick

			m_MessengerPopup.Content.TreatAsOneEntity = False
			m_MessengerPopup.Content.ImageAlign = ContentAlignment.TopLeft
			m_MessengerPopup.Content.TextAlign = ContentAlignment.TopLeft
			'm_MessengerPopup.Content.TextMargins = new NPadding(5, 5, 0, 0);
		End Sub

		Friend Sub InitShapedPopups()
			m_ShapedPopup1 = New NPopupNotify()
			m_ShapedPopup2 = New NPopupNotify()
			m_ShapedPopup3 = New NPopupNotify()

			m_ShapedPopup1.PredefinedStyle = PredefinedPopupStyle.Shaped
			m_ShapedPopup2.PredefinedStyle = PredefinedPopupStyle.Shaped
			m_ShapedPopup3.PredefinedStyle = PredefinedPopupStyle.Shaped

			Dim type As Type = GetType(NPopupNotifyUC)
			Dim path As String = "Nevron.Examples.UI.WinForm.PopupNotify"

			m_ShapedPopup1.ShapeTransparentColor = Color.Magenta
			m_ShapedPopup2.ShapeTransparentColor = Color.Magenta
			m_ShapedPopup3.ShapeTransparentColor = Color.Magenta

			m_ShapedPopup1.Shape = NResourceHelper.BitmapFromResource(type, "notification3.bmp", path)
			m_ShapedPopup1.Caption.ButtonSize = New NSize(20, 20)
			m_ShapedPopup1.Caption.ButtonsMargins = New NPadding(0, 4, 0, 6)
			m_ShapedPopup1.MoveableBounds = New Rectangle(100, 69, 226, 10)
			m_ShapedPopup1.CaptionBounds = New Rectangle(80, 69, 246, 30)
			m_ShapedPopup1.ContentBounds = New Rectangle(100, 79, 206, 46)

			m_ShapedPopup2.Shape = NResourceHelper.BitmapFromResource(type, "notification1.bmp", path)
			m_ShapedPopup2.Content.Padding = New NPadding(6, 0, 0, 0)
			m_ShapedPopup2.Caption.ButtonsMargins = New NPadding(0, 6, 0, 23)
			m_ShapedPopup2.Content.Text = "<font color='#606060' face='Tahoma'><b>Meet John!</b></font>"

			m_ShapedPopup3.Shape = NResourceHelper.BitmapFromResource(type, "notification2.bmp", path)
			m_ShapedPopup3.Caption.ButtonsMargins = New NPadding(0, 3, 0, 4)
			m_ShapedPopup3.Content.Text = "<font face='Trebuchet MS' color='brown' size='10'><b>Welcome to<br/>Nevron UI for .NET</b></font>"

			Dim item As NImageAndTextItem = m_ShapedPopup1.Content
			item.Text = "<u><font face='Verdana' color='Red'><i>You have 1 <font color='Navy'>new</font> message(s)!</i></font></u>"

			Dim list As ImageList = NResourceHelper.ImageListFromBitmap(type, New Size(20, 20), Color.Magenta, "close.bmp", path)
			Dim imageSet As NUIItemImageSet = m_ShapedPopup1.CloseButtonImageSet

			imageSet.NormalImage = list.Images(0)
			imageSet.HotImage = list.Images(1)
			imageSet.PressedImage = list.Images(2)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub m_ShowOffice2003Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowOffice2003Button.Click
			ShowPopup(m_Office2003Popup)
		End Sub

		Private Sub m_MessengerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_MessengerButton.Click
			ShowPopup(m_MessengerPopup)
		End Sub

		Private Sub m_ShapedButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		End Sub
		Private Sub m_ShapedButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShapedButton1.Click
			ShowPopup(m_ShapedPopup1)
		End Sub
		Private Sub m_ShapedButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShapedButton2.Click
			ShowPopup(m_ShapedPopup2)
		End Sub
		Private Sub m_ShapedButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShapedButton3.Click
			ShowPopup(m_ShapedPopup3)
		End Sub
		Private Sub OnContentClick(ByVal sender As Object, ByVal e As EventArgs)
			'NUIItem item = (NUIItem)sender;

'object o = item.GetRenderCacheEntry(UIRenderCacheEntries.TextBounds);
'if(!(o is Rectangle))
'return;

'Rectangle r = (Rectangle)o;

'INUIElementHost host = item.Host;
'Point client = host.ClientMouse;

'if(r.Contains(client))
'MessageBox.Show("Content Text Was Clicked!");
		End Sub

		Private Sub defaultButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles defaultButton.Click
			ShowPopup(m_SkinPopup)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NPopupNotifyUC))
			Me.label1 = New System.Windows.Forms.Label()
			Me.m_OpacityNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.m_VisibleSpanNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_FadeCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_SlideCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_ShowOffice2003Button = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_AutoHideCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_StayVisibleCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
			Me.m_MessengerButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
			Me.m_FullOpacityCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.nGrouper1 = New Nevron.UI.WinForm.Controls.NGrouper()
			Me.nGrouper2 = New Nevron.UI.WinForm.Controls.NGrouper()
			Me.animationDirectionCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label5 = New System.Windows.Forms.Label()
			Me.m_StepsNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label4 = New System.Windows.Forms.Label()
			Me.m_IntervalNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_ShapedButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ShapedButton2 = New Nevron.UI.WinForm.Controls.NButton()
			Me.m_ShapedButton3 = New Nevron.UI.WinForm.Controls.NButton()
			Me.defaultButton = New Nevron.UI.WinForm.Controls.NButton()
			CType(Me.m_OpacityNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_VisibleSpanNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGrouper1.SuspendLayout()
			CType(Me.nGrouper2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGrouper2.SuspendLayout()
			CType(Me.m_StepsNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_IntervalNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.BackColor = System.Drawing.Color.Transparent
			Me.label1.Location = New System.Drawing.Point(8, 32)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(72, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Opacity:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_OpacityNumeric
			' 
			Me.m_OpacityNumeric.Location = New System.Drawing.Point(88, 32)
			Me.m_OpacityNumeric.Maximum = New System.Decimal(New Integer() { 255, 0, 0, 0})
			Me.m_OpacityNumeric.Name = "m_OpacityNumeric"
			Me.m_OpacityNumeric.Size = New System.Drawing.Size(80, 18)
			Me.m_OpacityNumeric.TabIndex = 1
			Me.m_OpacityNumeric.Value = New System.Decimal(New Integer() { 255, 0, 0, 0})
			' 
			' m_VisibleSpanNumeric
			' 
			Me.m_VisibleSpanNumeric.CustomText = " ms"
			Me.m_VisibleSpanNumeric.Increment = New System.Decimal(New Integer() { 10, 0, 0, 0})
			Me.m_VisibleSpanNumeric.Location = New System.Drawing.Point(88, 56)
			Me.m_VisibleSpanNumeric.Maximum = New System.Decimal(New Integer() { 10000, 0, 0, 0})
			Me.m_VisibleSpanNumeric.Name = "m_VisibleSpanNumeric"
			Me.m_VisibleSpanNumeric.Size = New System.Drawing.Size(80, 18)
			Me.m_VisibleSpanNumeric.TabIndex = 3
			Me.m_VisibleSpanNumeric.Value = New System.Decimal(New Integer() { 5000, 0, 0, 0})
			' 
			' label2
			' 
			Me.label2.BackColor = System.Drawing.Color.Transparent
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(72, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Visible Span:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_FadeCheck
			' 
			Me.m_FadeCheck.ButtonProperties.BorderOffset = 2
			Me.m_FadeCheck.Checked = True
			Me.m_FadeCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_FadeCheck.Location = New System.Drawing.Point(80, 112)
			Me.m_FadeCheck.Name = "m_FadeCheck"
			Me.m_FadeCheck.Size = New System.Drawing.Size(72, 24)
			Me.m_FadeCheck.TabIndex = 4
			Me.m_FadeCheck.Text = "Fade"
			Me.m_FadeCheck.TransparentBackground = True
			' 
			' m_SlideCheck
			' 
			Me.m_SlideCheck.ButtonProperties.BorderOffset = 2
			Me.m_SlideCheck.Location = New System.Drawing.Point(80, 136)
			Me.m_SlideCheck.Name = "m_SlideCheck"
			Me.m_SlideCheck.Size = New System.Drawing.Size(72, 24)
			Me.m_SlideCheck.TabIndex = 5
			Me.m_SlideCheck.Text = "Slide"
			Me.m_SlideCheck.TransparentBackground = True
			' 
			' m_ShowOffice2003Button
			' 
			Me.m_ShowOffice2003Button.Location = New System.Drawing.Point(112, 192)
			Me.m_ShowOffice2003Button.Name = "m_ShowOffice2003Button"
			Me.m_ShowOffice2003Button.Size = New System.Drawing.Size(96, 24)
			Me.m_ShowOffice2003Button.TabIndex = 6
			Me.m_ShowOffice2003Button.Text = "Office 2003"
'			Me.m_ShowOffice2003Button.Click += New System.EventHandler(Me.m_ShowOffice2003Button_Click);
			' 
			' m_AutoHideCheck
			' 
			Me.m_AutoHideCheck.ButtonProperties.BorderOffset = 2
			Me.m_AutoHideCheck.Checked = True
			Me.m_AutoHideCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_AutoHideCheck.Location = New System.Drawing.Point(88, 88)
			Me.m_AutoHideCheck.Name = "m_AutoHideCheck"
			Me.m_AutoHideCheck.Size = New System.Drawing.Size(120, 24)
			Me.m_AutoHideCheck.TabIndex = 7
			Me.m_AutoHideCheck.Text = "Auto-hide"
			Me.m_AutoHideCheck.TransparentBackground = True
			' 
			' m_StayVisibleCheck
			' 
			Me.m_StayVisibleCheck.ButtonProperties.BorderOffset = 2
			Me.m_StayVisibleCheck.Checked = True
			Me.m_StayVisibleCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_StayVisibleCheck.Location = New System.Drawing.Point(88, 112)
			Me.m_StayVisibleCheck.Name = "m_StayVisibleCheck"
			Me.m_StayVisibleCheck.Size = New System.Drawing.Size(160, 24)
			Me.m_StayVisibleCheck.TabIndex = 8
			Me.m_StayVisibleCheck.Text = "Visible on mouse over"
			Me.m_StayVisibleCheck.TransparentBackground = True
			' 
			' imageList1
			' 
			Me.imageList1.ImageSize = New System.Drawing.Size(28, 28)
			Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
			' 
			' m_MessengerButton
			' 
			Me.m_MessengerButton.Location = New System.Drawing.Point(216, 192)
			Me.m_MessengerButton.Name = "m_MessengerButton"
			Me.m_MessengerButton.Size = New System.Drawing.Size(96, 24)
			Me.m_MessengerButton.TabIndex = 9
			Me.m_MessengerButton.Text = "Messenger"
'			Me.m_MessengerButton.Click += New System.EventHandler(Me.m_MessengerButton_Click);
			' 
			' imageList2
			' 
			Me.imageList2.ImageSize = New System.Drawing.Size(16, 16)
			Me.imageList2.ImageStream = (CType(resources.GetObject("imageList2.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageList2.TransparentColor = System.Drawing.Color.Magenta
			' 
			' m_FullOpacityCheck
			' 
			Me.m_FullOpacityCheck.ButtonProperties.BorderOffset = 2
			Me.m_FullOpacityCheck.Checked = True
			Me.m_FullOpacityCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.m_FullOpacityCheck.Location = New System.Drawing.Point(88, 136)
			Me.m_FullOpacityCheck.Name = "m_FullOpacityCheck"
			Me.m_FullOpacityCheck.Size = New System.Drawing.Size(160, 24)
			Me.m_FullOpacityCheck.TabIndex = 10
			Me.m_FullOpacityCheck.Text = "Full opacity on mouse over"
			Me.m_FullOpacityCheck.TransparentBackground = True
			' 
			' nGrouper1
			' 
			Me.nGrouper1.Controls.Add(Me.m_VisibleSpanNumeric)
			Me.nGrouper1.Controls.Add(Me.label2)
			Me.nGrouper1.Controls.Add(Me.m_OpacityNumeric)
			Me.nGrouper1.Controls.Add(Me.label1)
			Me.nGrouper1.Controls.Add(Me.m_FullOpacityCheck)
			Me.nGrouper1.Controls.Add(Me.m_AutoHideCheck)
			Me.nGrouper1.Controls.Add(Me.m_StayVisibleCheck)
			Me.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper1.FooterItem.Text = "Footer"
			Me.nGrouper1.FooterItem.Visible = False
			Me.nGrouper1.HeaderItem.Style.FontInfo = New Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular)
			Me.nGrouper1.HeaderItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper1.HeaderItem.Text = "Behaviour"
			Me.nGrouper1.Location = New System.Drawing.Point(8, 8)
			Me.nGrouper1.Name = "nGrouper1"
			Me.nGrouper1.Size = New System.Drawing.Size(256, 176)
			Me.nGrouper1.TabIndex = 13
			Me.nGrouper1.Text = "nGrouper1"
			' 
			' nGrouper2
			' 
			Me.nGrouper2.Controls.Add(Me.animationDirectionCombo)
			Me.nGrouper2.Controls.Add(Me.label5)
			Me.nGrouper2.Controls.Add(Me.m_StepsNumeric)
			Me.nGrouper2.Controls.Add(Me.label4)
			Me.nGrouper2.Controls.Add(Me.m_IntervalNumeric)
			Me.nGrouper2.Controls.Add(Me.label3)
			Me.nGrouper2.Controls.Add(Me.m_SlideCheck)
			Me.nGrouper2.Controls.Add(Me.m_FadeCheck)
			Me.nGrouper2.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper2.FooterItem.Text = "Footer"
			Me.nGrouper2.FooterItem.Visible = False
			Me.nGrouper2.FooterStrokeInfo.PenWidth = 10
			Me.nGrouper2.HeaderItem.Style.FontInfo = New Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular)
			Me.nGrouper2.HeaderItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper2.HeaderItem.Text = "Animation"
			Me.nGrouper2.Location = New System.Drawing.Point(272, 8)
			Me.nGrouper2.Name = "nGrouper2"
			Me.nGrouper2.Size = New System.Drawing.Size(232, 176)
			Me.nGrouper2.TabIndex = 14
			Me.nGrouper2.Text = "nGrouper2"
			' 
			' animationDirectionCombo
			' 
			Me.animationDirectionCombo.Location = New System.Drawing.Point(80, 80)
			Me.animationDirectionCombo.Name = "animationDirectionCombo"
			Me.animationDirectionCombo.Size = New System.Drawing.Size(136, 22)
			Me.animationDirectionCombo.TabIndex = 11
			' 
			' label5
			' 
			Me.label5.BackColor = System.Drawing.Color.Transparent
			Me.label5.Location = New System.Drawing.Point(8, 80)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(64, 24)
			Me.label5.TabIndex = 10
			Me.label5.Text = "Direction:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_StepsNumeric
			' 
			Me.m_StepsNumeric.Location = New System.Drawing.Point(80, 56)
			Me.m_StepsNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.m_StepsNumeric.Name = "m_StepsNumeric"
			Me.m_StepsNumeric.Size = New System.Drawing.Size(64, 18)
			Me.m_StepsNumeric.TabIndex = 9
			Me.m_StepsNumeric.Value = New System.Decimal(New Integer() { 20, 0, 0, 0})
			' 
			' label4
			' 
			Me.label4.BackColor = System.Drawing.Color.Transparent
			Me.label4.Location = New System.Drawing.Point(8, 56)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(64, 16)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Steps:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_IntervalNumeric
			' 
			Me.m_IntervalNumeric.CustomText = " ms"
			Me.m_IntervalNumeric.Location = New System.Drawing.Point(80, 32)
			Me.m_IntervalNumeric.Minimum = New System.Decimal(New Integer() { 1, 0, 0, 0})
			Me.m_IntervalNumeric.Name = "m_IntervalNumeric"
			Me.m_IntervalNumeric.Size = New System.Drawing.Size(64, 18)
			Me.m_IntervalNumeric.TabIndex = 7
			Me.m_IntervalNumeric.Value = New System.Decimal(New Integer() { 20, 0, 0, 0})
			' 
			' label3
			' 
			Me.label3.BackColor = System.Drawing.Color.Transparent
			Me.label3.Location = New System.Drawing.Point(8, 32)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(64, 16)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Interval:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_ShapedButton1
			' 
			Me.m_ShapedButton1.Location = New System.Drawing.Point(8, 224)
			Me.m_ShapedButton1.Name = "m_ShapedButton1"
			Me.m_ShapedButton1.Size = New System.Drawing.Size(96, 24)
			Me.m_ShapedButton1.TabIndex = 15
			Me.m_ShapedButton1.Text = "Shaped 1"
'			Me.m_ShapedButton1.Click += New System.EventHandler(Me.m_ShapedButton1_Click);
			' 
			' m_ShapedButton2
			' 
			Me.m_ShapedButton2.Location = New System.Drawing.Point(112, 224)
			Me.m_ShapedButton2.Name = "m_ShapedButton2"
			Me.m_ShapedButton2.Size = New System.Drawing.Size(96, 24)
			Me.m_ShapedButton2.TabIndex = 16
			Me.m_ShapedButton2.Text = "Shaped 2"
'			Me.m_ShapedButton2.Click += New System.EventHandler(Me.m_ShapedButton2_Click);
			' 
			' m_ShapedButton3
			' 
			Me.m_ShapedButton3.Location = New System.Drawing.Point(216, 224)
			Me.m_ShapedButton3.Name = "m_ShapedButton3"
			Me.m_ShapedButton3.Size = New System.Drawing.Size(96, 24)
			Me.m_ShapedButton3.TabIndex = 17
			Me.m_ShapedButton3.Text = "Shaped 3"
'			Me.m_ShapedButton3.Click += New System.EventHandler(Me.m_ShapedButton3_Click);
			' 
			' defaultButton
			' 
			Me.defaultButton.Location = New System.Drawing.Point(8, 192)
			Me.defaultButton.Name = "defaultButton"
			Me.defaultButton.Size = New System.Drawing.Size(96, 24)
			Me.defaultButton.TabIndex = 18
			Me.defaultButton.Text = "Skinned"
'			Me.defaultButton.Click += New System.EventHandler(Me.defaultButton_Click);
			' 
			' NPopupNotifyUC
			' 
			Me.Controls.Add(Me.defaultButton)
			Me.Controls.Add(Me.m_ShapedButton3)
			Me.Controls.Add(Me.m_ShapedButton2)
			Me.Controls.Add(Me.m_ShapedButton1)
			Me.Controls.Add(Me.nGrouper2)
			Me.Controls.Add(Me.nGrouper1)
			Me.Controls.Add(Me.m_MessengerButton)
			Me.Controls.Add(Me.m_ShowOffice2003Button)
			Me.Name = "NPopupNotifyUC"
			Me.Size = New System.Drawing.Size(512, 256)
			CType(Me.m_OpacityNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_VisibleSpanNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGrouper1.ResumeLayout(False)
			CType(Me.nGrouper2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGrouper2.ResumeLayout(False)
			CType(Me.m_StepsNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_IntervalNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_SkinPopup As NPopupNotify
		Friend m_Office2003Popup As NPopupNotify
		Friend m_MessengerPopup As NPopupNotify
		Friend m_ShapedPopup1 As NPopupNotify
		Friend m_ShapedPopup2 As NPopupNotify
		Friend m_ShapedPopup3 As NPopupNotify

		Private components As System.ComponentModel.IContainer
		Private label1 As System.Windows.Forms.Label
		Private m_OpacityNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private m_VisibleSpanNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private m_FadeCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_SlideCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_AutoHideCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private m_StayVisibleCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_ShowOffice2003Button As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_MessengerButton As Nevron.UI.WinForm.Controls.NButton
		Private imageList2 As System.Windows.Forms.ImageList
		Private m_FullOpacityCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private nGrouper1 As Nevron.UI.WinForm.Controls.NGrouper
		Private nGrouper2 As Nevron.UI.WinForm.Controls.NGrouper
		Private m_IntervalNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private m_StepsNumeric As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private WithEvents m_ShapedButton1 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ShapedButton2 As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents m_ShapedButton3 As Nevron.UI.WinForm.Controls.NButton
		Private label5 As System.Windows.Forms.Label
		Private animationDirectionCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents defaultButton As Nevron.UI.WinForm.Controls.NButton
		Private imageList1 As System.Windows.Forms.ImageList

		#End Region
	End Class
End Namespace
