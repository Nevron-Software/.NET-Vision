Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NSortingDataUC
		Inherits NExampleBaseUC

		Private m_Chart As NChart
		Private m_Bar As NBarSeries
		Private label1 As System.Windows.Forms.Label
		Private SortOrder As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents ChangeData As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SortAllOnValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SortAllOnLabels As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SortValuesOnly As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents SortFillStylesOnly As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			SortOrder.FillFromEnum(GetType(DataSeriesSortOrder))
		End Sub

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub


		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.ChangeData = New Nevron.UI.WinForm.Controls.NButton()
			Me.SortValuesOnly = New Nevron.UI.WinForm.Controls.NButton()
			Me.SortAllOnValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.SortAllOnLabels = New Nevron.UI.WinForm.Controls.NButton()
			Me.SortOrder = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SortFillStylesOnly = New Nevron.UI.WinForm.Controls.NButton()
			Me.SuspendLayout()
			' 
			' ChangeData
			' 
			Me.ChangeData.Location = New System.Drawing.Point(9, 9)
			Me.ChangeData.Name = "ChangeData"
			Me.ChangeData.Size = New System.Drawing.Size(160, 23)
			Me.ChangeData.TabIndex = 0
			Me.ChangeData.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeData.Click += new System.EventHandler(this.ChangeData_Click);
			' 
			' SortValuesOnly
			' 
			Me.SortValuesOnly.Location = New System.Drawing.Point(9, 106)
			Me.SortValuesOnly.Name = "SortValuesOnly"
			Me.SortValuesOnly.Size = New System.Drawing.Size(160, 24)
			Me.SortValuesOnly.TabIndex = 1
			Me.SortValuesOnly.Text = "Sort Values Only"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SortValuesOnly.Click += new System.EventHandler(this.SortValuesOnly_Click);
			' 
			' SortAllOnValues
			' 
			Me.SortAllOnValues.Location = New System.Drawing.Point(9, 166)
			Me.SortAllOnValues.Name = "SortAllOnValues"
			Me.SortAllOnValues.Size = New System.Drawing.Size(160, 24)
			Me.SortAllOnValues.TabIndex = 2
			Me.SortAllOnValues.Text = "Sort All By Values"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SortAllOnValues.Click += new System.EventHandler(this.SortAllOnValues_Click);
			' 
			' SortAllOnLabels
			' 
			Me.SortAllOnLabels.Location = New System.Drawing.Point(9, 196)
			Me.SortAllOnLabels.Name = "SortAllOnLabels"
			Me.SortAllOnLabels.Size = New System.Drawing.Size(160, 24)
			Me.SortAllOnLabels.TabIndex = 3
			Me.SortAllOnLabels.Text = "Sort All By Labels"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SortAllOnLabels.Click += new System.EventHandler(this.SortAllOnLabels_Click);
			' 
			' SortOrder
			' 
			Me.SortOrder.ListProperties.CheckBoxDataMember = ""
			Me.SortOrder.ListProperties.DataSource = Nothing
			Me.SortOrder.ListProperties.DisplayMember = ""
			Me.SortOrder.Location = New System.Drawing.Point(9, 65)
			Me.SortOrder.Name = "SortOrder"
			Me.SortOrder.Size = New System.Drawing.Size(160, 21)
			Me.SortOrder.TabIndex = 4
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(9, 47)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(160, 16)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Sort Order:"
			' 
			' SortFillStylesOnly
			' 
			Me.SortFillStylesOnly.Location = New System.Drawing.Point(9, 136)
			Me.SortFillStylesOnly.Name = "SortFillStylesOnly"
			Me.SortFillStylesOnly.Size = New System.Drawing.Size(160, 24)
			Me.SortFillStylesOnly.TabIndex = 6
			Me.SortFillStylesOnly.Text = "Sort All By Fill Styles"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.SortFillStylesOnly.Click += new System.EventHandler(this.SortAllOnFillStyles_Click);
			' 
			' NSortingDataUC
			' 
			Me.Controls.Add(Me.SortFillStylesOnly)
			Me.Controls.Add(Me.SortOrder)
			Me.Controls.Add(Me.SortAllOnLabels)
			Me.Controls.Add(Me.SortAllOnValues)
			Me.Controls.Add(Me.SortValuesOnly)
			Me.Controls.Add(Me.ChangeData)
			Me.Controls.Add(Me.label1)
			Me.Name = "NSortingDataUC"
			Me.Size = New System.Drawing.Size(180, 236)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Sorting Data")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 20, FontStyle.Italic)
			title.TextStyle.ShadowStyle.Type = ShadowType.Solid
			title.TextStyle.ShadowStyle.Color = Color.White
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' create a bar chart
			m_Chart = nChartControl1.Charts(0)
			m_Chart.Axis(StandardAxis.Depth).Visible = False

			m_Bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
			m_Bar.Legend.Mode = SeriesLegendMode.DataPoints

			FillRandom(6)

			SortOrder.SelectedIndex = 0
		End Sub

		Private Sub FillRandom(ByVal nCount As Integer)
			m_Bar.Values.FillRandom(Random, nCount)
			m_Bar.Labels.FillRandom(Random, nCount)

			For i As Integer = 0 To nCount - 1
				m_Bar.FillStyles(i) = New NColorFillStyle(RandomColor())
			Next i
		End Sub

		Private Sub ChangeData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeData.Click
			FillRandom(6)
			nChartControl1.Refresh()
		End Sub

		Private Sub SortValuesOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortValuesOnly.Click
			m_Bar.Values.Sort(CType(SortOrder.SelectedIndex, DataSeriesSortOrder))
			nChartControl1.Refresh()
		End Sub

		Private Sub SortAllOnValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortAllOnValues.Click
			Dim arrSeries As NDataSeriesCollection = m_Bar.GetDataSeries(DataSeriesMask.Values Or DataSeriesMask.Labels Or DataSeriesMask.FillStyles, DataSeriesMask.None, False)

			Dim nMasterIndex As Integer = arrSeries.FindByMask(DataSeriesMask.Values)

			arrSeries.Sort(nMasterIndex, CType(SortOrder.SelectedIndex, DataSeriesSortOrder))

			nChartControl1.Refresh()
		End Sub

		Private Sub SortAllOnLabels_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortAllOnLabels.Click
			Dim arrSeries As NDataSeriesCollection = m_Bar.GetDataSeries(DataSeriesMask.Values Or DataSeriesMask.Labels Or DataSeriesMask.FillStyles, DataSeriesMask.None, False)

			Dim nMasterIndex As Integer = arrSeries.FindByMask(DataSeriesMask.Labels)

			arrSeries.Sort(nMasterIndex, CType(SortOrder.SelectedIndex, DataSeriesSortOrder))

			nChartControl1.Refresh()
		End Sub

		Private Sub SortAllOnFillStyles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortFillStylesOnly.Click
			' demonstration of the custom comparer support
			Dim customComparer As New NCustomComparer()

			Dim arrSeries As NDataSeriesCollection = m_Bar.GetDataSeries(DataSeriesMask.Values Or DataSeriesMask.Labels Or DataSeriesMask.FillStyles, DataSeriesMask.None, False)

			Dim nMasterIndex As Integer = arrSeries.FindByMask(DataSeriesMask.FillStyles)

			arrSeries.Sort(nMasterIndex, CType(SortOrder.SelectedIndex, DataSeriesSortOrder), customComparer)

			nChartControl1.Refresh()
		End Sub
	End Class

	Public Class NCustomComparer
		Implements IComparer

		Public Function Compare(ByVal a As Object, ByVal b As Object) As Integer Implements IComparer.Compare
			Dim feA As NFillStyle = DirectCast(a, NFillStyle)
			Dim feB As NFillStyle = DirectCast(b, NFillStyle)

			Dim colorA As Color = feA.GetPrimaryColor().ToColor()
			Dim colorB As Color = feB.GetPrimaryColor().ToColor()

			Dim aRGBSum As Integer = Convert.ToInt32(colorA.R) + Convert.ToInt32(colorA.G) + Convert.ToInt32(colorA.B)
			Dim bRGBSum As Integer = Convert.ToInt32(colorB.R) + Convert.ToInt32(colorB.G) + Convert.ToInt32(colorB.B)

			If aRGBSum < bRGBSum Then
				Return -1
			End If

			If aRGBSum > bRGBSum Then
				Return +1
			End If

			Return 0
		End Function
	End Class
End Namespace
