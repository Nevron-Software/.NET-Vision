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
	''' Summary description for NEntryControlExtendedUC.
	''' </summary>
	Public Class NEntryControlsExtendedUC
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

			AddHandler nGrouper1.FooterItem.HyperLinkClick, AddressOf OnFooterItemHyperLinkClick

			Me.nComboBox1.ListProperties.ColumnOnLeft = False
			Me.nComboBox1.Items.Add(".NET Vision")
			Me.nComboBox1.Items.Add("Chart for .NET")
			Me.nComboBox1.Items.Add("Diagram for .NET")
			Me.nComboBox1.Items.Add("User Interface for .NET")
		End Sub



		#End Region

		#Region "Event Handlers"

		Private Sub OnFooterItemHyperLinkClick(ByVal sender As Object, ByVal e As Nevron.UI.NHyperLinkEventArgs)
			Process.Start(e.Url)
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NEntryControlsExtendedUC))
			Me.nEntryContainer1 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nGrouper1 = New Nevron.UI.WinForm.Controls.NGrouper()
			Me.nGroupBoxEx2 = New Nevron.UI.WinForm.Controls.NGroupBoxEx()
			Me.nEntryContainer8 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nDateTimePicker1 = New Nevron.UI.WinForm.Controls.NDateTimePicker()
			Me.nEntryContainer7 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox6 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nEntryContainer5 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox5 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nEntryContainer4 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox4 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nEntryContainer3 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nComboBox1 = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.nGroupBoxEx1 = New Nevron.UI.WinForm.Controls.NGroupBoxEx()
			Me.nEntryContainer6 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox3 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.nEntryContainer2 = New Nevron.UI.WinForm.Controls.NEntryContainer()
			Me.nTextBox2 = New Nevron.UI.WinForm.Controls.NTextBox()
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer1.SuspendLayout()
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGrouper1.SuspendLayout()
			CType(Me.nGroupBoxEx2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBoxEx2.SuspendLayout()
			CType(Me.nEntryContainer8, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer8.SuspendLayout()
			CType(Me.nEntryContainer7, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer7.SuspendLayout()
			CType(Me.nEntryContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer5.SuspendLayout()
			CType(Me.nEntryContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer4.SuspendLayout()
			CType(Me.nEntryContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer3.SuspendLayout()
			CType(Me.nGroupBoxEx1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nGroupBoxEx1.SuspendLayout()
			CType(Me.nEntryContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer6.SuspendLayout()
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.nEntryContainer2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' nEntryContainer1
			' 
			Me.nEntryContainer1.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer1.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer1.EntryControl = Me.nTextBox1
			Me.nEntryContainer1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nEntryContainer1.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer1.Location = New System.Drawing.Point(16, 32)
			Me.nEntryContainer1.Name = "nEntryContainer1"
			Me.nEntryContainer1.ShadowInfo.Draw = False
			Me.nEntryContainer1.Size = New System.Drawing.Size(392, 24)
			Me.nEntryContainer1.StrokeInfo.Draw = False
			Me.nEntryContainer1.TabIndex = 0
			Me.nEntryContainer1.Text = "Name<font color='red'><b>*</b></font>:"
			' 
			' nTextBox1
			' 
			Me.nTextBox1.Location = New System.Drawing.Point(68, 2)
			Me.nTextBox1.Name = "nTextBox1"
			Me.nTextBox1.Size = New System.Drawing.Size(322, 19)
			Me.nTextBox1.TabIndex = 1
			' 
			' nGrouper1
			' 
			Me.nGrouper1.Controls.Add(Me.nGroupBoxEx2)
			Me.nGrouper1.Controls.Add(Me.nGroupBoxEx1)
			Me.nGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper1.FooterItem.Image = (CType(resources.GetObject("nGrouper1.FooterItem.Image"), System.Drawing.Image))
			Me.nGrouper1.FooterItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft
			Me.nGrouper1.FooterItem.ImageSizeMode = Nevron.UI.ImageSizeMode.Stretch
			Me.nGrouper1.FooterItem.ImageTextRelation = Nevron.UI.ImageTextRelation.None
			Me.nGrouper1.FooterItem.Text = "For more information visit <a href='www.nevron.com'>www.nevron.com</a>"
			Me.nGrouper1.FooterItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper1.HeaderItem.Image = (CType(resources.GetObject("nGrouper1.HeaderItem.Image"), System.Drawing.Image))
			Me.nGrouper1.HeaderItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nGrouper1.HeaderItem.ImageSize = New Nevron.GraphicsCore.NSize(32, 32)
			Me.nGrouper1.HeaderItem.ImageTextRelation = Nevron.UI.ImageTextRelation.None
			Me.nGrouper1.HeaderItem.Style.TextFillStyle = New Nevron.GraphicsCore.NColorFillStyle(New Nevron.GraphicsCore.NArgbColor((CByte(255)), (CByte(255)), (CByte(255)), (CByte(255))))
			Me.nGrouper1.HeaderItem.Style.TextOffset = New Nevron.GraphicsCore.NPoint(0, 0)
			Me.nGrouper1.HeaderItem.Text = "<font shadowtype='linearblur' shadowcolor='black' size='15' face='Trebuchet MS'><" & "b>Purchase Form</b></font><br/><font size='9'>Detailed List</font>"
			Me.nGrouper1.HeaderItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.nGrouper1.HeaderStrokeInfo.Draw = False
			Me.nGrouper1.Location = New System.Drawing.Point(8, 8)
			Me.nGrouper1.Name = "nGrouper1"
			Me.nGrouper1.Size = New System.Drawing.Size(448, 408)
			Me.nGrouper1.TabIndex = 2
			Me.nGrouper1.Text = "nGrouper1"
			' 
			' nGroupBoxEx2
			' 
			Me.nGroupBoxEx2.BackColor = System.Drawing.Color.Transparent
			Me.nGroupBoxEx2.Controls.Add(Me.nEntryContainer8)
			Me.nGroupBoxEx2.Controls.Add(Me.nEntryContainer7)
			Me.nGroupBoxEx2.Controls.Add(Me.nEntryContainer5)
			Me.nGroupBoxEx2.Controls.Add(Me.nEntryContainer4)
			Me.nGroupBoxEx2.Controls.Add(Me.nEntryContainer3)
			Me.nGroupBoxEx2.FillInfo.Draw = False
			Me.nGroupBoxEx2.HeaderItem.Text = "Product Information"
			Me.nGroupBoxEx2.HeaderShadowInfo.Draw = False
			Me.nGroupBoxEx2.HeaderStrokeInfo.Rounding = 2
			Me.nGroupBoxEx2.Location = New System.Drawing.Point(8, 224)
			Me.nGroupBoxEx2.Name = "nGroupBoxEx2"
			Me.nGroupBoxEx2.ShadowInfo.Draw = False
			Me.nGroupBoxEx2.Size = New System.Drawing.Size(424, 144)
			Me.nGroupBoxEx2.StrokeInfo.Rounding = 5
			Me.nGroupBoxEx2.TabIndex = 6
			Me.nGroupBoxEx2.Text = "nGroupBoxEx2"
			' 
			' nEntryContainer8
			' 
			Me.nEntryContainer8.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer8.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer8.EntryControl = Me.nDateTimePicker1
			Me.nEntryContainer8.Item.Padding = New Nevron.UI.NPadding(1, 0, 0, 0)
			Me.nEntryContainer8.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl
			Me.nEntryContainer8.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer8.Location = New System.Drawing.Point(216, 88)
			Me.nEntryContainer8.Name = "nEntryContainer8"
			Me.nEntryContainer8.ShadowInfo.Draw = False
			Me.nEntryContainer8.Size = New System.Drawing.Size(192, 48)
			Me.nEntryContainer8.StrokeInfo.Draw = False
			Me.nEntryContainer8.TabIndex = 6
			Me.nEntryContainer8.Text = "Purchase Date<font color='red'><b>*</b></font>:"
			' 
			' nDateTimePicker1
			' 
			Me.nDateTimePicker1.BackColor = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nDateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nDateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb((CByte(235)), (CByte(235)), (CByte(235)))
			Me.nDateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb((CByte(76)), (CByte(76)), (CByte(76)))
			Me.nDateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb((CByte(242)), (CByte(242)), (CByte(242)))
			Me.nDateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb((CByte(127)), (CByte(127)), (CByte(127)))
			Me.nDateTimePicker1.ForeColor = System.Drawing.Color.FromArgb((CByte(0)), (CByte(0)), (CByte(0)))
			Me.nDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
			Me.nDateTimePicker1.Location = New System.Drawing.Point(2, 21)
			Me.nDateTimePicker1.Name = "nDateTimePicker1"
			Me.nDateTimePicker1.Size = New System.Drawing.Size(188, 21)
			Me.nDateTimePicker1.TabIndex = 7
			' 
			' nEntryContainer7
			' 
			Me.nEntryContainer7.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer7.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer7.EntryControl = Me.nTextBox6
			Me.nEntryContainer7.Item.Padding = New Nevron.UI.NPadding(1, 0, 0, 0)
			Me.nEntryContainer7.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl
			Me.nEntryContainer7.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer7.Location = New System.Drawing.Point(16, 88)
			Me.nEntryContainer7.Name = "nEntryContainer7"
			Me.nEntryContainer7.ShadowInfo.Draw = False
			Me.nEntryContainer7.Size = New System.Drawing.Size(192, 48)
			Me.nEntryContainer7.StrokeInfo.Draw = False
			Me.nEntryContainer7.TabIndex = 5
			Me.nEntryContainer7.Text = "Discount Coupon:"
			' 
			' nTextBox6
			' 
			Me.nTextBox6.Location = New System.Drawing.Point(2, 21)
			Me.nTextBox6.Name = "nTextBox6"
			Me.nTextBox6.Size = New System.Drawing.Size(188, 19)
			Me.nTextBox6.TabIndex = 1
			' 
			' nEntryContainer5
			' 
			Me.nEntryContainer5.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer5.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer5.EntryControl = Me.nTextBox5
			Me.nEntryContainer5.Item.Padding = New Nevron.UI.NPadding(1, 0, 0, 0)
			Me.nEntryContainer5.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl
			Me.nEntryContainer5.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer5.Location = New System.Drawing.Point(312, 32)
			Me.nEntryContainer5.Name = "nEntryContainer5"
			Me.nEntryContainer5.ShadowInfo.Draw = False
			Me.nEntryContainer5.Size = New System.Drawing.Size(96, 48)
			Me.nEntryContainer5.StrokeInfo.Draw = False
			Me.nEntryContainer5.TabIndex = 4
			Me.nEntryContainer5.Text = "Copies<font color='red'><b>*</b></font>:"
			' 
			' nTextBox5
			' 
			Me.nTextBox5.Location = New System.Drawing.Point(2, 21)
			Me.nTextBox5.Name = "nTextBox5"
			Me.nTextBox5.Size = New System.Drawing.Size(92, 19)
			Me.nTextBox5.TabIndex = 1
			' 
			' nEntryContainer4
			' 
			Me.nEntryContainer4.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer4.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer4.EntryControl = Me.nTextBox4
			Me.nEntryContainer4.Item.Padding = New Nevron.UI.NPadding(1, 0, 0, 0)
			Me.nEntryContainer4.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl
			Me.nEntryContainer4.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer4.Location = New System.Drawing.Point(216, 32)
			Me.nEntryContainer4.Name = "nEntryContainer4"
			Me.nEntryContainer4.ShadowInfo.Draw = False
			Me.nEntryContainer4.Size = New System.Drawing.Size(88, 48)
			Me.nEntryContainer4.StrokeInfo.Draw = False
			Me.nEntryContainer4.TabIndex = 3
			Me.nEntryContainer4.Text = "Price(USD)<font color='red'><b>*</b></font>:"
			' 
			' nTextBox4
			' 
			Me.nTextBox4.Location = New System.Drawing.Point(2, 21)
			Me.nTextBox4.Name = "nTextBox4"
			Me.nTextBox4.Size = New System.Drawing.Size(84, 19)
			Me.nTextBox4.TabIndex = 1
			' 
			' nEntryContainer3
			' 
			Me.nEntryContainer3.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer3.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer3.EntryControl = Me.nComboBox1
			Me.nEntryContainer3.Item.ContentAlign = System.Drawing.ContentAlignment.TopLeft
			Me.nEntryContainer3.Item.Padding = New Nevron.UI.NPadding(1, 0, 0, 0)
			Me.nEntryContainer3.LabelControlRelation = Nevron.UI.WinForm.Controls.LabelControlRelation.LabelAboveControl
			Me.nEntryContainer3.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer3.Location = New System.Drawing.Point(16, 32)
			Me.nEntryContainer3.Name = "nEntryContainer3"
			Me.nEntryContainer3.ShadowInfo.Draw = False
			Me.nEntryContainer3.Size = New System.Drawing.Size(192, 48)
			Me.nEntryContainer3.StrokeInfo.Draw = False
			Me.nEntryContainer3.TabIndex = 2
			Me.nEntryContainer3.Text = "Product<font color='red'><b>*</b></font>:"
			' 
			' nComboBox1
			' 
			Me.nComboBox1.Location = New System.Drawing.Point(2, 21)
			Me.nComboBox1.Name = "nComboBox1"
			Me.nComboBox1.Size = New System.Drawing.Size(188, 25)
			Me.nComboBox1.TabIndex = 5
			Me.nComboBox1.Text = "nComboBox1"
			' 
			' nGroupBoxEx1
			' 
			Me.nGroupBoxEx1.BackColor = System.Drawing.Color.Transparent
			Me.nGroupBoxEx1.Controls.Add(Me.nEntryContainer6)
			Me.nGroupBoxEx1.Controls.Add(Me.nEntryContainer1)
			Me.nGroupBoxEx1.Controls.Add(Me.nEntryContainer2)
			Me.nGroupBoxEx1.FillInfo.Draw = False
			Me.nGroupBoxEx1.HeaderItem.Text = "Customer Information"
			Me.nGroupBoxEx1.HeaderShadowInfo.Draw = False
			Me.nGroupBoxEx1.HeaderStrokeInfo.Rounding = 2
			Me.nGroupBoxEx1.Location = New System.Drawing.Point(8, 48)
			Me.nGroupBoxEx1.Name = "nGroupBoxEx1"
			Me.nGroupBoxEx1.ShadowInfo.Draw = False
			Me.nGroupBoxEx1.Size = New System.Drawing.Size(424, 168)
			Me.nGroupBoxEx1.StrokeInfo.Rounding = 5
			Me.nGroupBoxEx1.TabIndex = 5
			Me.nGroupBoxEx1.Text = "nGroupBoxEx1"
			' 
			' nEntryContainer6
			' 
			Me.nEntryContainer6.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer6.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer6.EntryControl = Me.nTextBox3
			Me.nEntryContainer6.Item.ContentAlign = System.Drawing.ContentAlignment.TopRight
			Me.nEntryContainer6.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer6.Location = New System.Drawing.Point(16, 80)
			Me.nEntryContainer6.Name = "nEntryContainer6"
			Me.nEntryContainer6.ShadowInfo.Draw = False
			Me.nEntryContainer6.Size = New System.Drawing.Size(392, 80)
			Me.nEntryContainer6.StrokeInfo.Draw = False
			Me.nEntryContainer6.TabIndex = 2
			Me.nEntryContainer6.Text = "Details:"
			' 
			' nTextBox3
			' 
			Me.nTextBox3.Location = New System.Drawing.Point(68, 2)
			Me.nTextBox3.Multiline = True
			Me.nTextBox3.Name = "nTextBox3"
			Me.nTextBox3.Size = New System.Drawing.Size(322, 76)
			Me.nTextBox3.TabIndex = 1
			' 
			' nEntryContainer2
			' 
			Me.nEntryContainer2.BackColor = System.Drawing.Color.Transparent
			Me.nEntryContainer2.ClientPadding = New Nevron.UI.NPadding(2, 2, 2, 2)
			Me.nEntryContainer2.EntryControl = Me.nTextBox2
			Me.nEntryContainer2.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.nEntryContainer2.LabelSize = New System.Drawing.Size(60, 0)
			Me.nEntryContainer2.Location = New System.Drawing.Point(16, 56)
			Me.nEntryContainer2.Name = "nEntryContainer2"
			Me.nEntryContainer2.ShadowInfo.Draw = False
			Me.nEntryContainer2.Size = New System.Drawing.Size(392, 24)
			Me.nEntryContainer2.StrokeInfo.Draw = False
			Me.nEntryContainer2.TabIndex = 1
			Me.nEntryContainer2.Text = "Address<font color='red'><b>*</b></font>:"
			' 
			' nTextBox2
			' 
			Me.nTextBox2.Location = New System.Drawing.Point(68, 2)
			Me.nTextBox2.Name = "nTextBox2"
			Me.nTextBox2.Size = New System.Drawing.Size(322, 19)
			Me.nTextBox2.TabIndex = 1
			' 
			' NEntryControlsExtendedUC
			' 
			Me.Controls.Add(Me.nGrouper1)
			Me.Font = New System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.Name = "NEntryControlsExtendedUC"
			Me.Size = New System.Drawing.Size(456, 416)
			CType(Me.nEntryContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer1.ResumeLayout(False)
			CType(Me.nGrouper1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGrouper1.ResumeLayout(False)
			CType(Me.nGroupBoxEx2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBoxEx2.ResumeLayout(False)
			CType(Me.nEntryContainer8, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer8.ResumeLayout(False)
			CType(Me.nEntryContainer7, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer7.ResumeLayout(False)
			CType(Me.nEntryContainer5, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer5.ResumeLayout(False)
			CType(Me.nEntryContainer4, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer4.ResumeLayout(False)
			CType(Me.nEntryContainer3, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer3.ResumeLayout(False)
			CType(Me.nGroupBoxEx1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nGroupBoxEx1.ResumeLayout(False)
			CType(Me.nEntryContainer6, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer6.ResumeLayout(False)
			CType(Me.nEntryContainer2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.nEntryContainer2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nEntryContainer1 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nGrouper1 As Nevron.UI.WinForm.Controls.NGrouper
		Private nEntryContainer2 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox2 As Nevron.UI.WinForm.Controls.NTextBox
		Private nEntryContainer3 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nComboBox1 As Nevron.UI.WinForm.Controls.NComboBox
		Private nGroupBoxEx1 As Nevron.UI.WinForm.Controls.NGroupBoxEx
		Private nEntryContainer6 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox3 As Nevron.UI.WinForm.Controls.NTextBox
		Private nGroupBoxEx2 As Nevron.UI.WinForm.Controls.NGroupBoxEx
		Private nEntryContainer4 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox4 As Nevron.UI.WinForm.Controls.NTextBox
		Private nEntryContainer5 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox5 As Nevron.UI.WinForm.Controls.NTextBox
		Private nEntryContainer7 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nTextBox6 As Nevron.UI.WinForm.Controls.NTextBox
		Private nEntryContainer8 As Nevron.UI.WinForm.Controls.NEntryContainer
		Private nDateTimePicker1 As Nevron.UI.WinForm.Controls.NDateTimePicker
		Private nTextBox1 As Nevron.UI.WinForm.Controls.NTextBox

		#End Region
	End Class
End Namespace

