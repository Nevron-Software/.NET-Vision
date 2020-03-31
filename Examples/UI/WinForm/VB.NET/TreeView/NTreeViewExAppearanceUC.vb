Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Partial Class NTreeViewExAppearanceUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New()
			InitializeComponent()

			Dock = DockStyle.Fill

			m_Images = New Image(5){}
			Dim path As String = "Nevron.Examples.UI.WinForm.TreeView.Resources"
			Dim t As Type = GetType(NTreeViewExAppearanceUC)

			m_Images(0) = NResourceHelper.BitmapFromResource(t, "TreeView1.png", path)
			m_Images(1) = NResourceHelper.BitmapFromResource(t, "TreeView2.png", path)
			m_Images(2) = NResourceHelper.BitmapFromResource(t, "TreeView3.png", path)
			m_Images(3) = NResourceHelper.BitmapFromResource(t, "TreeView4.png", path)
			m_Images(4) = NResourceHelper.BitmapFromResource(t, "TreeView5.png", path)
			m_Images(5) = NResourceHelper.BitmapFromResource(t, "TreeView6.png", path)
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			expandToRightCheck.Checked = True
			multiSelectCheck.Checked = True
			imageHighlightCheck.Checked = True

			settings1Btn_Click(Nothing, Nothing)
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub settings1Btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settings1Btn.Click
			nTreeViewEx1.Suspend()
			nTreeViewEx1.IndicatorStyle = TreeViewIndicatorStyle.OnLeft

			nTreeViewEx1.NormalState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			nTreeViewEx1.HotState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			nTreeViewEx1.SelectedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			nTreeViewEx1.HotSelectedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			nTreeViewEx1.PressedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
			nTreeViewEx1.InactiveSelectedState.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

			nTreeViewEx1.Nodes.Clear()
			nTreeViewEx1.ItemImageSize = New NSize(32, 32)
			nTreeViewEx1.HotState.Image = m_Images(3)
			nTreeViewEx1.SelectedState.Image = m_Images(4)
			nTreeViewEx1.HotSelectedState.Image = m_Images(5)

			Dim child1, child2, child3 As NTreeNode
			Dim richText As String = "<font size='10' face='Trebuchet MS' color='Navy'><b>Sample tree-node with rich text formatting</b></font><br/>The rich text however results in slower speed of the tree-view.<br/>You may specify rich text per desired node only to optimize performance."

			Dim info As NTooltipInfo = New NTooltipInfo()
			info.CaptionText = "<font face='Trebuchet MS' size='10'><b>Sample tooltip header.</b></font>"
			info.ContentImage = m_Images(1)
			info.ContentImageSize = New NSize(32, 32)
			info.ContentText = "This is sample tooltip content. It supports rich text and appearance settings per node.<br/>The individual tooltip is with higher priority than the internal one displayed for hidden items."

			For i As Integer = 1 To 20
				child1 = New NTreeNode()
				child1.TextAlign = ContentAlignment.TopLeft
				child1.Text = richText
				child1.Image = m_Images(1)
				child1.TextProcessMode = ItemTextProcessMode.RichText
				child1.CommonIndicator = CType(i, CommonIndicator)
				child1.TooltipInfo = info

				For j As Integer = 1 To 20
					child2 = New NTreeNode()
					child2.Text = "Simple Text Node"
					child2.Image = m_Images(1)
					child2.CommonIndicator = CType(j, CommonIndicator)
					child2.TooltipInfo = info

					For k As Integer = 1 To 20
						child3 = New NTreeNode()
						child3.Text = "Simple Text Node"
						child3.Image = m_Images(1)
						child3.CommonIndicator = CType(k, CommonIndicator)
						child3.TooltipInfo = info

						child2.Nodes.Add(child3)
					Next k

					child1.Nodes.Add(child2)
				Next j

				nTreeViewEx1.Nodes.Add(child1)
			Next i

			nTreeViewEx1.Resume(True)
			Me.nTreeViewEx1.Nodes(0).Expand()
		End Sub
		Private Sub settings2Btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles settings2Btn.Click
			nTreeViewEx1.Suspend()
			nTreeViewEx1.Nodes.Clear()

			nTreeViewEx1.NormalState.TextRenderingHint = TextRenderingHint.SystemDefault
			nTreeViewEx1.HotState.TextRenderingHint = TextRenderingHint.SystemDefault
			nTreeViewEx1.SelectedState.TextRenderingHint = TextRenderingHint.SystemDefault
			nTreeViewEx1.HotSelectedState.TextRenderingHint = TextRenderingHint.SystemDefault
			nTreeViewEx1.PressedState.TextRenderingHint = TextRenderingHint.SystemDefault
			nTreeViewEx1.InactiveSelectedState.TextRenderingHint = TextRenderingHint.SystemDefault

			Dim normalState As NLightUIItemVisualState = New NLightUIItemVisualState()
			normalState.FillInfo.Gradient1 = Color.Orange
			normalState.FillInfo.Gradient2 = Color.Yellow
			normalState.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.SigmaBell
			normalState.StrokeInfo.SmoothingMode = SmoothingMode.AntiAlias
			normalState.StrokeInfo.Rounding = 3
			normalState.StrokeInfo.Color = Color.Black
			normalState.TextFillInfo.FillStyle = FillStyle.Solid
			normalState.TextFillInfo.Color = Color.Black

			Dim hotState As NLightUIItemVisualState = New NLightUIItemVisualState()
			hotState.FillInfo.Gradient1 = Color.Yellow
			hotState.FillInfo.Gradient2 = Color.Orange
			hotState.FillInfo.GradientStyle = Nevron.UI.WinForm.Controls.GradientStyle.Vista
			hotState.StrokeInfo.SmoothingMode = SmoothingMode.AntiAlias
			hotState.StrokeInfo.PenWidth = 2
			hotState.StrokeInfo.DashStyle = DashStyle.Dash
			hotState.StrokeInfo.Color = Color.Black
			hotState.TextFillInfo.Color = Color.Black

			Dim selectedState As NLightUIItemVisualState = New NLightUIItemVisualState()
			selectedState.FillInfo.Gradient1 = Color.Orange
			selectedState.FillInfo.Gradient2 = Color.Black
			selectedState.StrokeInfo.SmoothingMode = SmoothingMode.AntiAlias
			selectedState.StrokeInfo.Rounding = 3
			selectedState.StrokeInfo.Color = Color.Black
			selectedState.TextFillInfo.Color = Color.White

			nTreeViewEx1.IndicatorStyle = TreeViewIndicatorStyle.OnLeft
			nTreeViewEx1.ItemImageSize = New NSize(32, 32)
			nTreeViewEx1.HotState.Image = m_Images(3)
			nTreeViewEx1.SelectedState.Image = m_Images(4)
			nTreeViewEx1.HotSelectedState.Image = m_Images(5)
			nTreeViewEx1.TrackHotSelectedState = False

			Dim child1, child2, child3 As NTreeNode

			For i As Integer = 1 To 20
				child1 = New NTreeNode()
				child1.Text = "Tree node with local Hot visual state"
				child1.Image = m_Images(1)
				child1.CommonIndicator = CType(i, CommonIndicator)
				child1.SetVisualState(hotState, ItemVisualState.Hot)

				For j As Integer = 1 To 20
					child2 = New NTreeNode()
					child2.Text = "Tree node with local Normal visual state"
					child2.Image = m_Images(1)
					child2.CommonIndicator = CType(j, CommonIndicator)
					child2.SetVisualState(normalState, ItemVisualState.Normal)

					For k As Integer = 1 To 20
						child3 = New NTreeNode()
						child3.Text = "Tree node with local Selected visual state"
						child3.Image = m_Images(1)
						child3.CommonIndicator = CType(k, CommonIndicator)
						child3.SetVisualState(selectedState, ItemVisualState.Selected)

						child2.Nodes.Add(child3)
					Next k

					child1.Nodes.Add(child2)
				Next j

				nTreeViewEx1.Nodes.Add(child1)
			Next i

			Me.nTreeViewEx1.Nodes(0).Expand()
			nTreeViewEx1.Resume(True)
		End Sub
		Private Sub expandAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles expandAllBtn.Click
			nTreeViewEx1.ExpandAll()
		End Sub
		Private Sub collapseAllBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles collapseAllBtn.Click
			nTreeViewEx1.CollapseAll()
		End Sub
		Private Sub expandToRightCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles expandToRightCheck.CheckedChanged
			nTreeViewEx1.ExpandToRight = expandToRightCheck.Checked
		End Sub
		Private Sub multiSelectCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles multiSelectCheck.CheckedChanged
			If multiSelectCheck.Checked Then
				nTreeViewEx1.SelectionMode = ItemSelectionMode.MultiExtended
			Else
				nTreeViewEx1.SelectionMode = ItemSelectionMode.Single
			End If
		End Sub
		Private Sub imageHighlightCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles imageHighlightCheck.CheckedChanged
			If imageHighlightCheck.Checked Then
				nTreeViewEx1.ItemBackgroundMode = ItemBackgroundMode.ImageAndText
			Else
				nTreeViewEx1.ItemBackgroundMode = ItemBackgroundMode.Inherit
			End If
		End Sub

		#End Region

		#Region "Fields"

		Friend m_Images As Image()

		#End Region
	End Class
End Namespace
