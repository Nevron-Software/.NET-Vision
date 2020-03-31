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
	''' Summary description for NColorPaneUC.
	''' </summary>
	Public Class NColorPaneUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			m_iSuspendUpdate += 1

			m_PreviewLabel.BackColor = Color.White

			m_ShowTooltipsCheck.Checked = nColorPane1.ShowTooltips
			m_SelectableCheck.Checked = nColorPane1.Selectable

			m_ColorChangeStyle.FillFromEnum(GetType(ColorChangeStyle), True)
			m_ColorChangeStyle.SelectedItem = nColorPane1.ChangeStyle

			Me.nColorPane1.CommandSize = New Size(21, 21)

			m_CellWidthNumeric.Value = nColorPane1.CommandSize.Width
			m_CellHeightNumeric.Value = nColorPane1.CommandSize.Height

			m_PreviewLabel.BackColor = nColorPane1.Color

			m_iSuspendUpdate -= 1
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#End Region

		#Region "Event Handlers"

		Private Sub nColorPane1_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nColorPane1.ColorChanged
			m_PreviewLabel.BackColor = nColorPane1.Color
		End Sub

		Private Sub m_CellWidthNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CellWidthNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			Dim sz As Size = New Size(CInt(Fix(m_CellWidthNumeric.Value)), nColorPane1.CommandSize.Height)
			nColorPane1.CommandSize = sz
		End Sub

		Private Sub m_CellHeightNumeric_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_CellHeightNumeric.ValueChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			Dim sz As Size = New Size(nColorPane1.CommandSize.Width, CInt(Fix(m_CellHeightNumeric.Value)))
			nColorPane1.CommandSize = sz
		End Sub

		Private Sub m_ColorChangeStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ColorChangeStyle.SelectedIndexChanged
			If m_iSuspendUpdate <> 0 Then
				Return
			End If

			Dim o As Object = m_ColorChangeStyle.SelectedItem
			If o Is Nothing Then
				Return
			End If

			nColorPane1.ChangeStyle = CType(o, ColorChangeStyle)
		End Sub

		Private Sub m_ShowTooltipsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ShowTooltipsCheck.CheckedChanged
			nColorPane1.ShowTooltips = m_ShowTooltipsCheck.Checked
		End Sub

		Private Sub m_SelectableCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_SelectableCheck.CheckedChanged
			nColorPane1.Selectable = m_SelectableCheck.Checked
		End Sub


		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nColorPane1 = New Nevron.UI.WinForm.Controls.NColorPane()
			Me.m_CellWidthNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.m_CellHeightNumeric = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label3 = New System.Windows.Forms.Label()
			Me.m_PreviewLabel = New System.Windows.Forms.Label()
			Me.m_ColorChangeStyle = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.m_ShowTooltipsCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.m_SelectableCheck = New Nevron.UI.WinForm.Controls.NCheckBox()
			CType(Me.m_CellWidthNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.m_CellHeightNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nColorPane1
			' 
			Me.nColorPane1.Color = System.Drawing.Color.FromArgb((CByte(255)), (CByte(255)), (CByte(255)))
			Me.nColorPane1.CommandSize = New System.Drawing.Size(21, 21)
			Me.nColorPane1.ImageSize = New System.Drawing.Size(12, 12)
			Me.nColorPane1.Location = New System.Drawing.Point(8, 8)
			Me.nColorPane1.Name = "nColorPane1"
			Me.nColorPane1.Size = New System.Drawing.Size(305, 308)
			Me.nColorPane1.TabIndex = 0
			Me.nColorPane1.Text = "nColorPane1"
'			Me.nColorPane1.ColorChanged += New System.EventHandler(Me.nColorPane1_ColorChanged);
			' 
			' m_CellWidthNumeric
			' 
			Me.m_CellWidthNumeric.Location = New System.Drawing.Point(112, 320)
			Me.m_CellWidthNumeric.Maximum = New System.Decimal(New Integer() { 30, 0, 0, 0})
			Me.m_CellWidthNumeric.Minimum = New System.Decimal(New Integer() { 4, 0, 0, 0})
			Me.m_CellWidthNumeric.Name = "m_CellWidthNumeric"
			Me.m_CellWidthNumeric.Size = New System.Drawing.Size(88, 20)
			Me.m_CellWidthNumeric.TabIndex = 1
			Me.m_CellWidthNumeric.Value = New System.Decimal(New Integer() { 4, 0, 0, 0})
'			Me.m_CellWidthNumeric.ValueChanged += New System.EventHandler(Me.m_CellWidthNumeric_ValueChanged);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(4, 320)
			Me.label1.Name = "label1"
			Me.label1.TabIndex = 2
			Me.label1.Text = "Cell Width:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(4, 344)
			Me.label2.Name = "label2"
			Me.label2.TabIndex = 4
			Me.label2.Text = "Cell Height:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_CellHeightNumeric
			' 
			Me.m_CellHeightNumeric.Location = New System.Drawing.Point(112, 344)
			Me.m_CellHeightNumeric.Maximum = New System.Decimal(New Integer() { 30, 0, 0, 0})
			Me.m_CellHeightNumeric.Minimum = New System.Decimal(New Integer() { 4, 0, 0, 0})
			Me.m_CellHeightNumeric.Name = "m_CellHeightNumeric"
			Me.m_CellHeightNumeric.Size = New System.Drawing.Size(88, 20)
			Me.m_CellHeightNumeric.TabIndex = 3
			Me.m_CellHeightNumeric.Value = New System.Decimal(New Integer() { 4, 0, 0, 0})
'			Me.m_CellHeightNumeric.ValueChanged += New System.EventHandler(Me.m_CellHeightNumeric_ValueChanged);
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(320, 184)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(56, 24)
			Me.label3.TabIndex = 5
			Me.label3.Text = "Preview:"
			' 
			' m_PreviewLabel
			' 
			Me.m_PreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.m_PreviewLabel.Location = New System.Drawing.Point(320, 204)
			Me.m_PreviewLabel.Name = "m_PreviewLabel"
			Me.m_PreviewLabel.Size = New System.Drawing.Size(120, 112)
			Me.m_PreviewLabel.TabIndex = 6
			' 
			' m_ColorChangeStyle
			' 
			Me.m_ColorChangeStyle.ListProperties.ColumnOnLeft = False
			Me.m_ColorChangeStyle.Location = New System.Drawing.Point(112, 368)
			Me.m_ColorChangeStyle.Name = "m_ColorChangeStyle"
			Me.m_ColorChangeStyle.Size = New System.Drawing.Size(168, 21)
			Me.m_ColorChangeStyle.TabIndex = 7
'			Me.m_ColorChangeStyle.SelectedIndexChanged += New System.EventHandler(Me.m_ColorChangeStyle_SelectedIndexChanged);
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(0, 368)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(104, 23)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Color Change Style"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' m_ShowTooltipsCheck
			' 
			Me.m_ShowTooltipsCheck.Location = New System.Drawing.Point(112, 400)
			Me.m_ShowTooltipsCheck.Name = "m_ShowTooltipsCheck"
			Me.m_ShowTooltipsCheck.TabIndex = 9
			Me.m_ShowTooltipsCheck.Text = "Show Tooltips"
'			Me.m_ShowTooltipsCheck.CheckedChanged += New System.EventHandler(Me.m_ShowTooltipsCheck_CheckedChanged);
			' 
			' m_SelectableCheck
			' 
			Me.m_SelectableCheck.Location = New System.Drawing.Point(216, 400)
			Me.m_SelectableCheck.Name = "m_SelectableCheck"
			Me.m_SelectableCheck.TabIndex = 10
			Me.m_SelectableCheck.Text = "Selectable"
'			Me.m_SelectableCheck.CheckedChanged += New System.EventHandler(Me.m_SelectableCheck_CheckedChanged);
			' 
			' NColorPaneUC
			' 
			Me.Controls.Add(Me.m_SelectableCheck)
			Me.Controls.Add(Me.m_ShowTooltipsCheck)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.m_ColorChangeStyle)
			Me.Controls.Add(Me.m_PreviewLabel)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.m_CellHeightNumeric)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.m_CellWidthNumeric)
			Me.Controls.Add(Me.nColorPane1)
			Me.Name = "NColorPaneUC"
			Me.Size = New System.Drawing.Size(448, 424)
			CType(Me.m_CellWidthNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.m_CellHeightNumeric, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing

		Private WithEvents nColorPane1 As Nevron.UI.WinForm.Controls.NColorPane
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private m_PreviewLabel As System.Windows.Forms.Label
		Private WithEvents m_CellWidthNumeric As NNumericUpDown
		Private WithEvents m_ColorChangeStyle As NComboBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents m_ShowTooltipsCheck As NCheckBox
		Private WithEvents m_SelectableCheck As Nevron.UI.WinForm.Controls.NCheckBox
		Private WithEvents m_CellHeightNumeric As NNumericUpDown

		#End Region
	End Class
End Namespace
