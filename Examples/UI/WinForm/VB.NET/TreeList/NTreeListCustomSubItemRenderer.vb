Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.UI
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm

Namespace Nevron.Examples.UI.WinForm
	Public Class NTreeListCustomSubItemRenderer
		Inherits NTreeListSubItemRenderer
		#Region "Constructor"

		Public Sub New()
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Sub PrePaintItem(ByVal item As NTreeListNodeSubItem, ByVal context As NTreeListPaintContext)
			Dim bounds As Rectangle = context.TreeList.GetSubItemRect(item).ToRectangle()
			Dim brushRect As Rectangle = bounds
			brushRect.Inflate(1, 1)

			Select Case item.ItemType
				Case TreeListNodeSubItemType.String
					If item.Owner.IsEven Then
						context.Graphics.FillEllipse(Brushes.Cyan, bounds)
					Else
						context.Graphics.FillEllipse(Brushes.Coral, bounds)
					End If
					Return
				Case TreeListNodeSubItemType.DateTime
					Dim c1 As Color
					Dim c2 As Color

					If item.Owner.IsEven Then
						c1 = Color.White
						c2 = Color.YellowGreen
					Else
						c1 = Color.Wheat
						c2 = Color.Silver
					End If

					Dim br As LinearGradientBrush = New LinearGradientBrush(brushRect, c1, c2, 0F)
					context.Graphics.FillRectangle(br, bounds)
					br.Dispose()
					Return
			End Select

			MyBase.PrePaintItem(item, context)
		End Sub
		Public Overrides Sub PostPaintItem(ByVal item As NTreeListNodeSubItem, ByVal context As NTreeListPaintContext)
			Dim orig As Font = context.Font
			Dim newFont As Font = Nothing

			Dim bounds As NRectangle = context.TreeList.GetSubItemRect(item)

			Select Case item.ItemType
				Case TreeListNodeSubItemType.String
					If item.Owner.IsEven Then
						newFont = New Font(orig, FontStyle.Strikeout)
					Else
						newFont = New Font(orig, FontStyle.Italic)
					End If
				Case TreeListNodeSubItemType.Numeric, TreeListNodeSubItemType.DateTime
					If item.Owner.IsEven = False Then
						newFont = New Font(orig, FontStyle.Strikeout)
					Else
						newFont = New Font(orig, FontStyle.Italic)
					End If
			End Select

			If Not newFont Is Nothing Then
				context.Font = newFont
			End If

			MyBase.PostPaintItem(item, context)

			If Not newFont Is Nothing Then
				newFont.Dispose()
			End If

			context.Font = orig
		End Sub

		#End Region
	End Class
End Namespace
