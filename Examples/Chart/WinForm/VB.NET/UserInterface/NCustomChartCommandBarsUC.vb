Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.UI.WinForm.Controls
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.UI
Imports System.Collections.Generic

Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NCustomChartCommandBarsUC
		Inherits NExampleBaseUC

		#Region "Constructor"

		Public Sub New()
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				' revert to the orignal commander and builder
				m_Manager.Commander = New NChartCommander()
				m_Manager.ToolbarsBuilder = New NChartToolbarCommandBuilder()
				m_Manager.Recreate()
				m_Manager.ChartControl = Me.nChartControl1

				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Protected Sub RecreateToolbar()
			m_Manager.Commander = New NCustomChartCommander()
			m_Manager.ToolbarsBuilder = New NCustomChartToolbarsBuilder(Me)
			m_Manager.Recreate()

			Dim range1 As New NRange()
			range1.ID = NCustomChartCommander.m_CustomCommandRange1
			range1.Name = "Custom Commands1"
			m_Manager.Ranges.Add(range1)

			Dim range2 As New NRange()
			range2.ID = NCustomChartCommander.m_CustomCommandRange1
			range2.Name = "Custom Commands1"
			m_Manager.Ranges.Add(range2)

			m_Manager.ChartControl = nChartControl1

			' remove the palette button from he standard toolbar
			For i As Integer = m_Manager.Toolbars.Count - 1 To 0 Step -1
				Dim toolbar As NDockingToolbar = m_Manager.Toolbars(i)

				If toolbar.DefaultRangeID = CInt(ChartCommandRange.Standard) Then
					' if not removed check whether to remove command from it
					If Not ShowPaletteButtonCheckBox.Checked Then
						Dim command As NCommand = toolbar.Commands.GetCommandById(CInt(ChartCommand.ApplyStyleSheet))
						toolbar.Commands.Remove(command)
					End If
				End If
			Next i
		End Sub

		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			m_Manager = DirectCast(MyBase.m_MainForm, NMainForm).chartCommandBarsManager

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Customizing the Command Bar")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As New NPieChart()
			chart.Enable3D = True
			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(chart)

			chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)

			chart.DisplayOnLegend = nChartControl1.Legends(0)
			chart.Location = New NPointL(New NLength(15, NRelativeUnit.ParentPercentage), New NLength(15, NRelativeUnit.ParentPercentage))
			chart.Size = New NSizeL(New NLength(70, NRelativeUnit.ParentPercentage), New NLength(70, NRelativeUnit.ParentPercentage))

			Dim pieSeries As NPieSeries = CType(chart.Series.Add(SeriesType.Pie), NPieSeries)
			pieSeries.PieEdgePercent = 30
			pieSeries.PieStyle = PieStyle.SmoothEdgePie
			pieSeries.Legend.Mode = SeriesLegendMode.DataPoints
			pieSeries.Legend.Format = "<label> <percent>"

			pieSeries.AddDataPoint(New NDataPoint(12, "Ships"))
			pieSeries.AddDataPoint(New NDataPoint(42, "Trains"))
			pieSeries.AddDataPoint(New NDataPoint(56, "Cars"))
			pieSeries.AddDataPoint(New NDataPoint(23, "Buses"))
			pieSeries.AddDataPoint(New NDataPoint(18, "Airplanes"))

			For i As Integer = 0 To pieSeries.Values.Count - 1
				pieSeries.Detachments.Add(0)
			Next i

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			ShowStandardToolbarCheckBox_CheckedChanged(Nothing, Nothing)
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ShowStandardToolbarCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.ShowPaletteButtonCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
			Me.SuspendLayout()
			' 
			' ShowStandardToolbarCheckBox
			' 
			Me.ShowStandardToolbarCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowStandardToolbarCheckBox.Location = New System.Drawing.Point(13, 12)
			Me.ShowStandardToolbarCheckBox.Name = "ShowStandardToolbarCheckBox"
			Me.ShowStandardToolbarCheckBox.Size = New System.Drawing.Size(153, 24)
			Me.ShowStandardToolbarCheckBox.TabIndex = 0
			Me.ShowStandardToolbarCheckBox.Text = "Show Standard Toolbar"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowStandardToolbarCheckBox.CheckedChanged += new System.EventHandler(this.ShowStandardToolbarCheckBox_CheckedChanged);
			' 
			' ShowPaletteButtonCheckBox
			' 
			Me.ShowPaletteButtonCheckBox.ButtonProperties.BorderOffset = 2
			Me.ShowPaletteButtonCheckBox.Location = New System.Drawing.Point(13, 42)
			Me.ShowPaletteButtonCheckBox.Name = "ShowPaletteButtonCheckBox"
			Me.ShowPaletteButtonCheckBox.Size = New System.Drawing.Size(153, 24)
			Me.ShowPaletteButtonCheckBox.TabIndex = 1
			Me.ShowPaletteButtonCheckBox.Text = "Show Palette Button"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ShowPaletteButtonCheckBox.CheckedChanged += new System.EventHandler(this.ShowPaletteButtonCheckBox_CheckedChanged);
			' 
			' NCustomChartCommandBarsUC
			' 
			Me.Controls.Add(Me.ShowPaletteButtonCheckBox)
			Me.Controls.Add(Me.ShowStandardToolbarCheckBox)
			Me.Name = "NCustomChartCommandBarsUC"
			Me.Size = New System.Drawing.Size(227, 369)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Private components As System.ComponentModel.Container = Nothing
		Public WithEvents ShowStandardToolbarCheckBox As NCheckBox
		Public WithEvents ShowPaletteButtonCheckBox As NCheckBox

		Friend m_Manager As NChartCommandBarsManager

		#End Region

		Private Sub ShowStandardToolbarCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowStandardToolbarCheckBox.CheckedChanged
			RecreateToolbar()

			ShowPaletteButtonCheckBox.Enabled = ShowStandardToolbarCheckBox.Checked
		End Sub

		Private Sub ShowPaletteButtonCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShowPaletteButtonCheckBox.CheckedChanged
			RecreateToolbar()
		End Sub
	End Class

	''' <summary>
	''' Summary description for NCustomDiagramToolbarsBuilder.
	''' </summary>
	Public Class NCustomChartToolbarsBuilder
		Inherits NChartToolbarCommandBuilder

		#Region "Constructor"

		''' <summary>
		''' 
		''' </summary>
		''' <param name="customChartCommandBarsUC"></param>
		Public Sub New(ByVal customChartCommandBarsUC As NCustomChartCommandBarsUC)
			m_CustomChartCommandBarsUC = customChartCommandBarsUC
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Function BuildToolbars(ByVal commander As NChartCommander) As NDockingToolbar()
			Dim toolbars As New List(Of NDockingToolbar)(MyBase.BuildToolbars(commander))

				  ' remove all standard toolbars in case of standard toolbar check the 
			' the "Remove Standard Toolbar check button is checked
			For i As Integer = toolbars.Count - 1 To 0 Step -1
				Dim toolbar As NDockingToolbar = toolbars(i)

				Dim remove As Boolean = True
				If toolbar.DefaultRangeID = CInt(ChartCommandRange.Standard) Then
					remove = Not m_CustomChartCommandBarsUC.ShowStandardToolbarCheckBox.Checked
				End If

				If remove Then
					toolbars.RemoveAt(i)
				End If
			Next i

			Dim toolbar1 As New NDockingToolbar()
			toolbar1.DefaultRangeID = NCustomChartCommander.m_CustomCommandRange1
			toolbar1.Text = "Custom Toolbar 1"
			toolbar1.RowIndex = 0
			toolbars.Add(toolbar1)

			Dim toolbar2 As New NDockingToolbar()
			toolbar2.DefaultRangeID = NCustomChartCommander.m_CustomCommandRange2
			toolbar2.Text = "Custom Toolbar 2"
			toolbar2.RowIndex = 0
			toolbars.Add(toolbar2)

			Return toolbars.ToArray()
		End Function

		#End Region

		#Region "Fields"

		Private m_CustomChartCommandBarsUC As NCustomChartCommandBarsUC

		#End Region
	End Class

	Public Class NCustomChartCommander
		Inherits NChartCommander

		#Region "Constructor"

		Shared Sub New()
			Dim thisType As Type = GetType(NCustomChartCommander)
			ImageListCustom = New NCustomImageList(NResourceHelper.BitmapFromResource(thisType, "CustomCommandbarImageList.png", "Nevron.Examples.Chart.WinForm.Resources"), New NSize(16, 16))
		End Sub
		Public Sub New()
			Me.Commands.Add(New NCustomChartButtonCommand1())
			Me.Commands.Add(New NCustomChartButtonCommand2())
		End Sub

		#End Region

		#Region "Overrides"

		Public Overrides Function GetCommandImageInfo(ByVal commandId As Integer, <System.Runtime.InteropServices.Out()> ByRef imageList As NCustomImageList, <System.Runtime.InteropServices.Out()> ByRef imageIndex As Integer) As Boolean
			If commandId = NCustomChartButtonCommand1.m_CommandId OrElse commandId = NCustomChartButtonCommand2.m_CommandId Then
				imageList = ImageListCustom
				imageIndex = 0
				Return True
			Else
				Return MyBase.GetCommandImageInfo(commandId, imageList, imageIndex)
			End If
		End Function

		#End Region

		#Region "Fields"

		Public Shared ImageListCustom As NCustomImageList = Nothing
		Public Shared m_CustomCommandRange1 As Integer = CInt(ChartCommandRange.LightModel + 1)
		Public Shared m_CustomCommandRange2 As Integer = CInt(ChartCommandRange.LightModel + 2)

		#End Region
	End Class

	Public MustInherit Class NCustomPieCommand
		Inherits NChartButtonCommand

		#Region "Constructor"

		''' <summary>
		''' Initializer constructor
		''' </summary>
		''' <param name="rangeId"></param>
		''' <param name="id"></param>
		''' <param name="text"></param>
		''' <param name="tooltipText"></param>
		Public Sub New(ByVal rangeId As Integer, ByVal id As Integer, ByVal text As String, ByVal tooltipText As String)
			MyBase.New(rangeId, id, text, tooltipText)
		End Sub

		#End Region

		#Region "Implementation"

		''' <summary>
		''' Gets the first pie series in the current chart control
		''' </summary>
		''' <returns></returns>
		Protected Function GetPieSeries() As NPieSeries
'INSTANT VB NOTE: The variable chartControl was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim chartControl_Renamed As NChartControl = MyBase.ChartControl

			If chartControl_Renamed Is Nothing Then
				Return Nothing
			End If

			' first chart is not a pie or chart does not contain series
			If chartControl_Renamed.Charts.Count = 0 OrElse Not (TypeOf chartControl_Renamed.Charts(0) Is NPieChart) OrElse (chartControl_Renamed.Charts(0).Series.Count = 0) Then
				Return Nothing
			End If

			Return CType(chartControl_Renamed.Charts(0).Series(0), NPieSeries)
		End Function
		''' <summary>
		''' Returns true if the pie is exploded
		''' </summary>
		''' <returns></returns>
		Protected Function IsPieExploded() As Boolean
			Dim pie As NPieSeries = GetPieSeries()

			If pie Is Nothing Then
				Return False
			End If

			For i As Integer = 0 To pie.Detachments.Count - 1
				If DirectCast(pie.Detachments(i), Double) = 0 Then
					Return False
				End If
			Next i

			Return True
		End Function
		''' <summary>
		''' Explodes the pie
		''' </summary>
		Protected Sub ExplodePie()
			Dim pie As NPieSeries = GetPieSeries()

			If pie Is Nothing Then
				Return
			End If

			For i As Integer = 0 To pie.Detachments.Count - 1
				pie.Detachments(i) = 5
			Next i

			Me.ChartControl.Refresh()
		End Sub
		''' <summary>
		''' Returns true if the pie is exploded
		''' </summary>
		''' <returns></returns>
		Protected Function IsPieCollapsed() As Boolean
			Dim pie As NPieSeries = GetPieSeries()

			If pie Is Nothing Then
				Return False
			End If

			For i As Integer = 0 To pie.Detachments.Count - 1
				If DirectCast(pie.Detachments(i), Double) <> 0 Then
					Return False
				End If
			Next i

			Return True
		End Function
		''' <summary>
		''' Collapses all pie segement
		''' </summary>
		Protected Sub CollapsePie()
			Dim pie As NPieSeries = GetPieSeries()

			If pie Is Nothing Then
				Return
			End If

			For i As Integer = 0 To pie.Detachments.Count - 1
				pie.Detachments(i) = 0
			Next i

			Me.ChartControl.Refresh()
		End Sub

		#End Region
	End Class

	''' <summary>
	''' Custom chart command that explodes all pie segments
	''' </summary>
	Public Class NCustomChartButtonCommand1
		Inherits NCustomPieCommand

		#Region "Constructors"

		Public Sub New()
			MyBase.New(NCustomChartCommander.m_CustomCommandRange1, m_CommandId, "Custom command 1. Explodes all pie segments.", "Custom command 1. Explodes all pie segments.")
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides ReadOnly Property Enabled() As Boolean
			Get
				Return MyBase.IsPieCollapsed()
			End Get
		End Property

		Public Overrides Sub Execute()
			MyBase.ExplodePie()
		End Sub

		#End Region

		#Region "Static Fields"

		Public Shared m_CommandId As Integer = CInt(ChartCommand.LastCommandId) + 1

		#End Region
	End Class

	''' <summary>
	''' Custom chart command that collapses all pie segments
	''' </summary>
	Public Class NCustomChartButtonCommand2
		Inherits NCustomPieCommand

		#Region "Constructors"

		Public Sub New()
			MyBase.New(NCustomChartCommander.m_CustomCommandRange2, m_CommandId, "Custom command 2. Collapses all pie segments.", "Custom command 2. Collapses all pie segments.")
		End Sub


		#End Region

		#Region "Overrides"

		Public Overrides ReadOnly Property Enabled() As Boolean
			Get
				Return MyBase.IsPieExploded()
			End Get
		End Property

		Public Overrides Sub Execute()
			MyBase.CollapsePie()
		End Sub

		#End Region

		#Region "Static Fields"

		Public Shared m_CommandId As Integer = CInt(ChartCommand.LastCommandId) + 2

		#End Region
	End Class

End Namespace
