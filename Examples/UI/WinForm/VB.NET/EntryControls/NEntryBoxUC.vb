Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NEntryBoxUC.
	''' </summary>
	Public Class NEntryBoxUC
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
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub enabledCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles enabledCheck.CheckedChanged
			Dim container As NEntryContainer

			For Each c As Control In nGroupBoxEx1.Controls
				container = TryCast(c, NEntryContainer)
				If container Is Nothing Then
					Continue For
				End If

				container.Enabled = enabledCheck.Checked
			Next c
		End Sub

		Private Sub fillBoundingBoxCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fillBoundingBoxCheck.CheckedChanged
			Dim container As NEntryContainer

			For Each c As Control In nGroupBoxEx1.Controls
				container = TryCast(c, NEntryContainer)
				If container Is Nothing Then
					Continue For
				End If

				container.FillEntryControlBounds = fillBoundingBoxCheck.Checked
			Next c
		End Sub

		Private Sub interactiveCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles interactiveCheck.CheckedChanged
			Dim container As NEntryContainer

			For Each c As Control In nGroupBoxEx1.Controls
				container = TryCast(c, NEntryContainer)
				If container Is Nothing Then
					Continue For
				End If

				container.Interactive = interactiveCheck.Checked
			Next c
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NEntryBoxUC))
			Me.nGroupBoxEx1 = New Nevron.UI.WinForm.Controls.NGroupBoxEx()
			Me.nEntryContainer4 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox4 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nEntryContainer3 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox3 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nEntryContainer2 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox2 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nEntryContainer1 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nGrouper1 = New Nevron.UI.WinForm.Controls.NGrouper()
			Me.nButton1 = New Nevron.UI.WinForm.Controls.NButton()
			Me.nGroupBoxEx2 = New Nevron.UI.WinForm.Controls.NGroupBoxEx()
			Me.nRadioButton3 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton2 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.nRadioButton1 = New Nevron.UI.WinForm.Controls.NRadioButton()
			Me.fillBoundingBoxCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.enabledCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.interactiveCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.nGroupBoxEx1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBoxEx1.SuspendLayout()
			CType(Me.nEntryContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer4.SuspendLayout()
			CType(Me.nEntryContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer3.SuspendLayout()
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer2.SuspendLayout()
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer1.SuspendLayout()
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGrouper1.SuspendLayout()
			CType(Me.nGroupBoxEx2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBoxEx2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nGroupBoxEx1
			' 
			Me.nGroupBoxEx1.BackColor = System.Drawing.Color.Transparent
			Me.nGroupBoxEx1.Controls.Add(Me.nEntryContainer4)
			Me.nGroupBoxEx1.Controls.Add(Me.nEntryContainer3)
			Me.nGroupBoxEx1.Controls.Add(Me.nEntryContainer2)
			Me.nGroupBoxEx1.Controls.Add(Me.nEntryContainer1)
			Me.nGroupBoxEx1.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.nGroupBoxEx1.HeaderItem.Image = (CType(resources.GetObject("nGroupBoxEx1.HeaderItem.Image"), System.Drawing.Image))
			Me.nGroupBoxEx1.HeaderItem.ImageSizeMode = Nevron.UI.ImageSizeMode.Stretch
			Me.nGroupBoxEx1.HeaderItem.ImageTextSpacing = 2
			Me.nGroupBoxEx1.HeaderItem.Padding = New Nevron.UI.NPadding(1, 1, 1, 1)
			Me.nGroupBoxEx1.HeaderItem.Text = "Customer"
			Me.nGroupBoxEx1.HeaderShadowInfo.Draw = False
			Me.nGroupBoxEx1.HeaderStrokeInfo.Rounding = 5
			Me.nGroupBoxEx1.Location = New System.Drawing.Point(16, 32)
			Me.nGroupBoxEx1.Name = "nGroupBoxEx1"
			Me.nGroupBoxEx1.ShadowInfo.Draw = False
			Me.nGroupBoxEx1.Size = New System.Drawing.Size(344, 224)
			Me.nGroupBoxEx1.StrokeInfo.Rounding = 5
			Me.nGroupBoxEx1.TabIndex = 0
			' 
			' nEntryContainer4
			' 
			Me.nEntryContainer4.ClientPadding = New Nevron.UI.NPadding(1, 1, 1, 1)
			Me.nEntryContainer4.EntryControl = Me.nTextBox4
			Me.nEntryContainer4.Item.ContentAlign = System.Drawing.ContentAlignment.TopLeft
			Me.nEntryContainer4.LabelSize = New System.Drawing.Size(70, 0)
			Me.nEntryContainer4.Location = New System.Drawing.Point(24, 136)
			Me.nEntryContainer4.Name = "nEntryContainer4"
			Me.nEntryContainer4.Size = New System.Drawing.Size(304, 80)
			Me.nEntryContainer4.StrokeInfo.Rounding = 5
			Me.nEntryContainer4.TabIndex = 5
			Me.nEntryContainer4.Text = "Notes:"
			' 
			' nTextBox4
			' 
			Me.nTextBox4.AutoSize = False
			Me.nTextBox4.Border.Style = Nevron.UI.BorderStyle3D.None
			Me.nTextBox4.Location = New System.Drawing.Point(83, 7)
			Me.nTextBox4.Multiline = True
			Me.nTextBox4.Name = "nTextBox4"
			Me.nTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.nTextBox4.Size = New System.Drawing.Size(209, 61)
			Me.nTextBox4.TabIndex = 3
			' 
			' nEntryContainer3
			' 
			Me.nEntryContainer3.ClientPadding = New Nevron.UI.NPadding(1, 1, 1, 1)
			Me.nEntryContainer3.EntryControl = Me.nTextBox3
			Me.nEntryContainer3.LabelSize = New System.Drawing.Size(70, 0)
			Me.nEntryContainer3.Location = New System.Drawing.Point(24, 104)
			Me.nEntryContainer3.Name = "nEntryContainer3"
			Me.nEntryContainer3.Size = New System.Drawing.Size(304, 32)
			Me.nEntryContainer3.StrokeInfo.Rounding = 5
			Me.nEntryContainer3.TabIndex = 4
			Me.nEntryContainer3.Text = "Address:"
			' 
			' nTextBox3
			' 
			Me.nTextBox3.AutoSize = False
			Me.nTextBox3.Border.Style = Nevron.UI.BorderStyle3D.None
			Me.nTextBox3.Location = New System.Drawing.Point(83, 7)
			Me.nTextBox3.Name = "nTextBox3"
			Me.nTextBox3.Size = New System.Drawing.Size(209, 13)
			Me.nTextBox3.TabIndex = 3
			' 
			' nEntryContainer2
			' 
			Me.nEntryContainer2.ClientPadding = New Nevron.UI.NPadding(1, 1, 1, 1)
			Me.nEntryContainer2.EntryControl = Me.nTextBox2
			Me.nEntryContainer2.LabelSize = New System.Drawing.Size(70, 0)
			Me.nEntryContainer2.Location = New System.Drawing.Point(24, 72)
			Me.nEntryContainer2.Name = "nEntryContainer2"
			Me.nEntryContainer2.Size = New System.Drawing.Size(304, 32)
			Me.nEntryContainer2.StrokeInfo.Rounding = 5
			Me.nEntryContainer2.TabIndex = 3
			Me.nEntryContainer2.Text = "Last Name:"
			' 
			' nTextBox2
			' 
			Me.nTextBox2.AutoSize = False
			Me.nTextBox2.Border.Style = Nevron.UI.BorderStyle3D.None
			Me.nTextBox2.Location = New System.Drawing.Point(83, 7)
			Me.nTextBox2.Name = "nTextBox2"
			Me.nTextBox2.Size = New System.Drawing.Size(209, 13)
			Me.nTextBox2.TabIndex = 3
			' 
			' nEntryContainer1
			' 
			Me.nEntryContainer1.ClientPadding = New Nevron.UI.NPadding(1, 1, 1, 1)
			Me.nEntryContainer1.EntryControl = Me.nTextBox1
			Me.nEntryContainer1.LabelSize = New System.Drawing.Size(70, 0)
			Me.nEntryContainer1.Location = New System.Drawing.Point(24, 40)
			Me.nEntryContainer1.Name = "nEntryContainer1"
			Me.nEntryContainer1.Size = New System.Drawing.Size(304, 32)
			Me.nEntryContainer1.StrokeInfo.Rounding = 5
			Me.nEntryContainer1.TabIndex = 2
			Me.nEntryContainer1.Text = "First Name:"
			' 
			' nTextBox1
			' 
			Me.nTextBox1.AutoSize = False
			Me.nTextBox1.Border.Style = Nevron.UI.BorderStyle3D.None
			Me.nTextBox1.Location = New System.Drawing.Point(83, 7)
			Me.nTextBox1.Name = "nTextBox1"
			Me.nTextBox1.Size = New System.Drawing.Size(209, 13)
			Me.nTextBox1.TabIndex = 3
			' 
			' nGrouper1
			' 
			Me.nGrouper1.Controls.Add(Me.nButton1)
			Me.nGrouper1.Controls.Add(Me.nGroupBoxEx2)
			Me.nGrouper1.Controls.Add(Me.nGroupBoxEx1)
			Me.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper1.FooterItem.Text = "Footer"
			Me.nGrouper1.FooterItem.Visible = False
			Me.nGrouper1.HeaderItem.Style.FontInfo = New Nevron.UI.NThemeFontInfo("Tahoma", 10F, Nevron.GraphicsCore.FontStyleEx.Regular)
			Me.nGrouper1.HeaderItem.Style.FrameStyle = Nothing
			Me.nGrouper1.HeaderItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper1.HeaderItem.Text = "Purchase Order"
			Me.nGrouper1.Location = New System.Drawing.Point(8, 8)
			Me.nGrouper1.Name = "nGrouper1"
			Me.nGrouper1.ShadowInfo.Draw = False
			Me.nGrouper1.Size = New System.Drawing.Size(376, 376)
			Me.nGrouper1.TabIndex = 1
			Me.nGrouper1.Text = "nGrouper1"
			' 
			' nButton1
			' 
			Me.nButton1.Location = New System.Drawing.Point(264, 344)
			Me.nButton1.Name = "nButton1"
			Me.nButton1.Size = New System.Drawing.Size(96, 24)
			Me.nButton1.TabIndex = 2
			Me.nButton1.Text = "Submit"
			' 
			' nGroupBoxEx2
			' 
			Me.nGroupBoxEx2.BackColor = System.Drawing.Color.Transparent
			Me.nGroupBoxEx2.Controls.Add(Me.nRadioButton3)
			Me.nGroupBoxEx2.Controls.Add(Me.nRadioButton2)
			Me.nGroupBoxEx2.Controls.Add(Me.nRadioButton1)
			Me.nGroupBoxEx2.HeaderItem.Image = (CType(resources.GetObject("nGroupBoxEx2.HeaderItem.Image"), System.Drawing.Image))
			Me.nGroupBoxEx2.HeaderItem.ImageSizeMode = Nevron.UI.ImageSizeMode.Stretch
			Me.nGroupBoxEx2.HeaderItem.ImageTextSpacing = 2
			Me.nGroupBoxEx2.HeaderItem.Padding = New Nevron.UI.NPadding(1, 1, 1, 1)
			Me.nGroupBoxEx2.HeaderItem.Text = "Ship Via"
			Me.nGroupBoxEx2.HeaderShadowInfo.Draw = False
			Me.nGroupBoxEx2.HeaderStrokeInfo.Rounding = 5
			Me.nGroupBoxEx2.Location = New System.Drawing.Point(16, 264)
			Me.nGroupBoxEx2.Name = "nGroupBoxEx2"
			Me.nGroupBoxEx2.ShadowInfo.Draw = False
			Me.nGroupBoxEx2.Size = New System.Drawing.Size(344, 64)
			Me.nGroupBoxEx2.StrokeInfo.Rounding = 5
			Me.nGroupBoxEx2.TabIndex = 1
			' 
			' nRadioButton3
			' 
			Me.nRadioButton3.Location = New System.Drawing.Point(248, 32)
			Me.nRadioButton3.Name = "nRadioButton3"
			Me.nRadioButton3.Size = New System.Drawing.Size(72, 24)
			Me.nRadioButton3.TabIndex = 4
			Me.nRadioButton3.Text = "Speedy"
			Me.nRadioButton3.TransparentBackground = True
			' 
			' nRadioButton2
			' 
			Me.nRadioButton2.Location = New System.Drawing.Point(136, 32)
			Me.nRadioButton2.Name = "nRadioButton2"
			Me.nRadioButton2.Size = New System.Drawing.Size(80, 24)
			Me.nRadioButton2.TabIndex = 3
			Me.nRadioButton2.Text = "Mail"
			Me.nRadioButton2.TransparentBackground = True
			' 
			' nRadioButton1
			' 
			Me.nRadioButton1.Location = New System.Drawing.Point(32, 32)
			Me.nRadioButton1.Name = "nRadioButton1"
			Me.nRadioButton1.Size = New System.Drawing.Size(56, 24)
			Me.nRadioButton1.TabIndex = 2
			Me.nRadioButton1.Text = "DHL"
			Me.nRadioButton1.TransparentBackground = True
			' 
			' fillBoundingBoxCheck
			' 
			Me.fillBoundingBoxCheck.Checked = True
			Me.fillBoundingBoxCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.fillBoundingBoxCheck.Location = New System.Drawing.Point(392, 32)
			Me.fillBoundingBoxCheck.Name = "fillBoundingBoxCheck"
			Me.fillBoundingBoxCheck.Size = New System.Drawing.Size(128, 24)
			Me.fillBoundingBoxCheck.TabIndex = 2
			Me.fillBoundingBoxCheck.Text = "Fill Bounding Box"
'			Me.fillBoundingBoxCheck.CheckedChanged += New System.EventHandler(Me.fillBoundingBoxCheck_CheckedChanged);
			' 
			' enabledCheck
			' 
			Me.enabledCheck.Checked = True
			Me.enabledCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.enabledCheck.Location = New System.Drawing.Point(392, 8)
			Me.enabledCheck.Name = "enabledCheck"
			Me.enabledCheck.Size = New System.Drawing.Size(128, 24)
			Me.enabledCheck.TabIndex = 3
			Me.enabledCheck.Text = "Enabled"
'			Me.enabledCheck.CheckedChanged += New System.EventHandler(Me.enabledCheck_CheckedChanged);
			' 
			' interactiveCheck
			' 
			Me.interactiveCheck.Checked = True
			Me.interactiveCheck.CheckState = System.Windows.Forms.CheckState.Checked
			Me.interactiveCheck.Location = New System.Drawing.Point(392, 56)
			Me.interactiveCheck.Name = "interactiveCheck"
			Me.interactiveCheck.Size = New System.Drawing.Size(128, 24)
			Me.interactiveCheck.TabIndex = 4
			Me.interactiveCheck.Text = "Interactive"
'			Me.interactiveCheck.CheckedChanged += New System.EventHandler(Me.interactiveCheck_CheckedChanged);
			' 
			' NEntryBoxUC
			' 
			Me.Controls.Add(Me.interactiveCheck)
			Me.Controls.Add(Me.enabledCheck)
			Me.Controls.Add(Me.fillBoundingBoxCheck)
			Me.Controls.Add(Me.nGrouper1)
			Me.Name = "NEntryBoxUC"
			Me.Size = New System.Drawing.Size(520, 392)
			CType(Me.nGroupBoxEx1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBoxEx1.ResumeLayout(False)
			CType(Me.nEntryContainer4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer4.ResumeLayout(False)
			CType(Me.nEntryContainer3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer3.ResumeLayout(False)
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer2.ResumeLayout(False)
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer1.ResumeLayout(False)
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGrouper1.ResumeLayout(False)
			CType(Me.nGroupBoxEx2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBoxEx2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private nGroupBoxEx1 As Nevron.UI.WinForm.Controls.NGroupBoxEx
		Private nGrouper1 As Nevron.UI.WinForm.Controls.NGrouper
		Private nGroupBoxEx2 As Nevron.UI.WinForm.Controls.NGroupBoxEx
		Private nRadioButton1 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton2 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nRadioButton3 As Nevron.UI.WinForm.Controls.NRadioButton
		Private nButton1 As Nevron.UI.WinForm.Controls.NButton
		Private nEntryContainer1 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private nEntryContainer2 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox2 As Nevron.UI.WinForm.Controls.NTextBox
		Private nEntryContainer3 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox3 As Nevron.UI.WinForm.Controls.NTextBox
		Private nEntryContainer4 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox4 As Nevron.UI.WinForm.Controls.NTextBox
		Private WithEvents fillBoundingBoxCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents enabledCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents interactiveCheck As Nevron.UI.WinForm.Controls.NCheckBox

		Private components As System.ComponentModel.Container = Nothing

		#End Region
	End Class
End Namespace
