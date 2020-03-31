Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeListFormattingUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill

			m_List = New NTreeList()
			m_List.Dock = DockStyle.Fill
			m_List.AutoSizeColumns = False
			'm_List.EnableGroupBy = false;

			m_List.Parent = Me
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			m_List.Suspend()

			InitColumns()
			InitNodes()

			'm_List.BestFitAllColumns();
			m_List.BestFitAllNodes()
			m_List.BestFitColumnHeaderHeight()

			m_List.Resume(True)
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub InitColumns()
			Dim column As NTreeListColumn
			m_List.HeaderNormalState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			m_List.HeaderHotState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			m_List.HeaderPressedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

			'text column
			column = New NTreeListColumn()
			column.Name = "StringColumn"
			column.Header.Text = "<font color='Red'><b>String Column</b></font><br/><font size='7'>Displays strings.</font>"
			column.Header.TextProcessMode = ItemTextProcessMode.RichText
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 160
			m_List.Columns.Add(column)

			'image column
			column = New NTreeListColumn()
			column.Name = "ImageColumn"
			column.Header.Text = "<font color='Navy'><b>Image Column</b></font><br/><font size='7'>Displays images.</font>"
			column.Header.TextProcessMode = ItemTextProcessMode.RichText
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 120
			m_List.Columns.Add(column)

			'numeric column
			column = New NTreeListColumn()
			column.Name = "NumColumn"
			column.Header.Text = "<font color='Brown'><b>Numeric Column</b></font><br/><font size='7'>Displays numbers.</font>"
			column.Header.TextProcessMode = ItemTextProcessMode.RichText
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 120
			m_List.Columns.Add(column)

			'date-time column
			column = New NTreeListColumn()
			column.Name = "DateColumn"
			column.Header.Text = "<font color='Orange'><b>DateTime Column</b></font><br/><font size='7'>Displays DateTime values.</font>"
			column.Header.TextProcessMode = ItemTextProcessMode.RichText
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 220
			m_List.Columns.Add(column)

			'boolean column
			column = New NTreeListColumn()
			column.Name = "BoolColumn"
			column.Header.Text = "<font color='Violet'><b>Boolen Column</b></font><br/><font size='7'>Displays Boolean values.</font>"

			column.Header.TextProcessMode = ItemTextProcessMode.RichText
			column.ContentAlign = ContentAlignment.MiddleCenter
			column.Width = 140
			m_List.Columns.Add(column)
		End Sub
		Friend Sub InitNodes()
			Dim node As NTreeListNode
			Dim boldFont As Font = New Font("Trebuchet MS", 10F, FontStyle.Bold)
			Dim dateFont As Font = New Font("Verdana", 8F, FontStyle.Underline)
			Dim textFill As NFillInfo = New NFillInfo()
			textFill.Gradient1 = Color.WhiteSmoke
			textFill.Gradient2 = Color.YellowGreen
			textFill.GradientAngle = 0F

			Dim numFill As NFillInfo = New NFillInfo()
			numFill.Gradient1 = Color.Yellow
			numFill.Gradient2 = Color.OrangeRed
			numFill.GradientAngle = 45F

			Dim boolFill As NFillInfo = New NFillInfo()
			boolFill.Gradient2 = Color.Yellow
			boolFill.Gradient1 = Color.Green
			boolFill.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista
			boolFill.GradientAngle = 135F

			Dim ticks As Long = DateTime.Now.Ticks

			For i As Integer = 1 To 30
				node = New NTreeListNode()

				'text sub-item
				Dim stringItem As NTreeListNodeStringSubItem = New NTreeListNodeStringSubItem()
				stringItem.Text = "String SubItem " & i
				stringItem.Font = boldFont
				stringItem.FillInfo = textFill
				stringItem.Column = m_List.Columns(0)
				node.SubItems.Add(stringItem)

				'image sub-item
				Dim imageItem As NTreeListNodeImageSubItem = New NTreeListNodeImageSubItem()
				imageItem.Image = NSystemImages.Information
				imageItem.Column = m_List.Columns(1)
				imageItem.ImageSize = New NSize(32, 32)
				node.SubItems.Add(imageItem)

				'numeric sub-item
				Dim numItem As NTreeListNodeNumericSubItem = New NTreeListNodeNumericSubItem()
				numItem.Value = i * 10
				numItem.FormatString = "$#,###0.00"
				numItem.Column = m_List.Columns(2)
				numItem.FillInfo = numFill
				node.SubItems.Add(numItem)

				'date sub-item
				Dim dateItem As NTreeListNodeDateTimeSubItem = New NTreeListNodeDateTimeSubItem()
				dateItem.Value = New DateTime(ticks + i * 10000000)
				dateItem.FormatString = "F"
				dateItem.Font = dateFont
				dateItem.RenderingHint = TextRenderingHint.ClearTypeGridFit
				dateItem.Column = m_List.Columns(3)
				node.SubItems.Add(dateItem)

				'bool sub-item
				Dim boolItem As NTreeListNodeBooleanSubItem = New NTreeListNodeBooleanSubItem()
				boolItem.Value = (i Mod 2) = 0
				boolItem.Column = m_List.Columns(4)
				boolItem.FillInfo = boolFill
				node.SubItems.Add(boolItem)

				m_List.Nodes.Add(node)
			Next i
		End Sub

		#End Region

		#Region "Fields"

		Friend m_List As NTreeList

		#End Region
	End Class
End Namespace
