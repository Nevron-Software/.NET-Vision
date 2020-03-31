Imports Microsoft.VisualBasic
Imports System

Imports Nevron.Diagram
Imports Nevron.Diagram.Extensions
Imports Nevron.Diagram.Layout
Imports Nevron.Diagram.ThinWeb
Imports Nevron.ThinWeb

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''	Summary description for NClassHierarchyUC.
	''' </summary>
	Partial Public Class NClassHierarchyUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NThinDiagramControl1.Initialized = False Then
				' Init the thin diagram control
				NThinDiagramControl1.CustomRequestCallback = New CustomRequestCallback()
				NThinDiagramControl1.Controller.Tools.Add(New NRectZoomTool())
				Dim panTool As NPanTool = New NPanTool()
				panTool.Enabled = False
				NThinDiagramControl1.Controller.Tools.Add(panTool)

				' Set manual ID so that it can be referenced in JavaScript
				NThinDiagramControl1.StateId = "Diagram1"

				' Init the view
				NThinDiagramControl1.View.Layout = CanvasLayout.Fit

				' Init the toolbar
				NThinDiagramControl1.Toolbar.Visible = True
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomInAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NZoomOutAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())

				Dim values As Array = System.Enum.GetValues(GetType(CanvasLayout))
				Dim i As Integer = 0
				Do While i < values.Length
					NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleViewLayoutAction(CType(values.GetValue(i), CanvasLayout))))
					i += 1
				Loop

				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarSeparator())
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NTogglePanToolAction()))
				NThinDiagramControl1.Toolbar.Items.Add(New NToolbarButton(New NToggleRectZoomToolAction()))

				' Init the document
				InitDocument(NThinDiagramControl1.Document, GetType(NLayout))
			End If
		End Sub

#Region "Implementation"

		Private Shared Sub InitDocument(ByVal document As NDrawingDocument, ByVal type As Type)
			' set up visual formatting
			document.BackgroundStyle.FrameStyle.Visible = False
			document.ActiveLayer.RemoveAllChildren()
			document.BeginInit()

			Dim importer As NClassImporter = New NClassImporter(document)
			importer.ImportInActiveLayer = True
			importer.Import(type)

			document.EndInit()
			document.SizeToContent()
		End Sub

#End Region

#Region "Nested Types"

		<Serializable()> _
		Private Class CustomRequestCallback
			Implements INCustomRequestCallback
#Region "INCustomRequestCallback Members"

			Private Sub OnCustomRequestCallback(ByVal control As NAspNetThinWebControl, ByVal context As NRequestContext, ByVal argument As String) Implements INCustomRequestCallback.OnCustomRequestCallback
				Dim diagramControl As NThinDiagramControl = CType(control, NThinDiagramControl)
				InitDocument(diagramControl.Document, Type.GetType(argument))
				control.UpdateView()
			End Sub

#End Region
		End Class

#End Region
	End Class
End Namespace