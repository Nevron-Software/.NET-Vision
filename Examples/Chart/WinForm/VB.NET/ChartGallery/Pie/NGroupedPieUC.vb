Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NGroupedPieUC
		Inherits NExampleBaseUC

		Private m_Pie As NPieSeries
		Private m_Values As NDataSeriesDouble
		Private m_Detachments As NDataSeriesDouble
		Private m_Labels As NDataSeriesString
		Private m_FillStyles As NIndexedAttributeSeries
		Private m_BorderStyles As NIndexedAttributeSeries
		Private m_GroupColor As Color
		Private m_dGroupValue As Double
		Private m_sGroupLabel As String
		Private m_bGroupedData As Boolean
		Private WithEvents ChangeDataButton As Nevron.UI.WinForm.Controls.NButton
		Private label2 As System.Windows.Forms.Label
		Private WithEvents GroupValueText As Nevron.UI.WinForm.Controls.NTextBox
		Private groupBox1 As Nevron.UI.WinForm.Controls.NGroupBox
		Private WithEvents GroupColorButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents GroupLabel As Nevron.UI.WinForm.Controls.NTextBox
		Private label3 As System.Windows.Forms.Label
		Private colorDlg As Nevron.UI.WinForm.Controls.NColorDialog
		Private WithEvents GroupValues As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents UngroupData As Nevron.UI.WinForm.Controls.NButton
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(NGroupedPieUC))
			Me.ChangeDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label2 = New System.Windows.Forms.Label()
			Me.GroupValueText = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.groupBox1 = New Nevron.UI.WinForm.Controls.NGroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.GroupLabel = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.GroupColorButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.colorDlg = New Nevron.UI.WinForm.Controls.NColorDialog()
			Me.GroupValues = New Nevron.UI.WinForm.Controls.NButton()
			Me.UngroupData = New Nevron.UI.WinForm.Controls.NButton()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' ChangeDataButton
			' 
			Me.ChangeDataButton.Location = New System.Drawing.Point(4, 9)
			Me.ChangeDataButton.Name = "ChangeDataButton"
			Me.ChangeDataButton.Size = New System.Drawing.Size(173, 24)
			Me.ChangeDataButton.TabIndex = 0
			Me.ChangeDataButton.Text = "Change Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ChangeDataButton.Click += new System.EventHandler(this.ChangeDataButton_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 106)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(151, 16)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Group Below Value:"
			' 
			' GroupValueText
			' 
			Me.GroupValueText.Location = New System.Drawing.Point(5, 123)
			Me.GroupValueText.Name = "GroupValueText"
			Me.GroupValueText.Size = New System.Drawing.Size(60, 18)
			Me.GroupValueText.TabIndex = 4
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupValueText.TextChanged += new System.EventHandler(this.GroupValueText_TextChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.GroupLabel)
			Me.groupBox1.Controls.Add(Me.GroupColorButton)
			Me.groupBox1.Controls.Add(Me.GroupValueText)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Location = New System.Drawing.Point(6, 109)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(171, 156)
			Me.groupBox1.TabIndex = 3
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Grouped Slice Properties"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(5, 53)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(151, 16)
			Me.label3.TabIndex = 1
			Me.label3.Text = "Label:"
			' 
			' GroupLabel
			' 
			Me.GroupLabel.Location = New System.Drawing.Point(5, 73)
			Me.GroupLabel.Name = "GroupLabel"
			Me.GroupLabel.Size = New System.Drawing.Size(151, 18)
			Me.GroupLabel.TabIndex = 2
			Me.GroupLabel.Text = "Other"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupLabel.TextChanged += new System.EventHandler(this.GroupLabel_TextChanged);
			' 
			' GroupColorButton
			' 
			Me.GroupColorButton.Location = New System.Drawing.Point(5, 20)
			Me.GroupColorButton.Name = "GroupColorButton"
			Me.GroupColorButton.Size = New System.Drawing.Size(151, 24)
			Me.GroupColorButton.TabIndex = 0
			Me.GroupColorButton.Text = "Color..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupColorButton.Click += new System.EventHandler(this.GroupColorButton_Click);
			' 
			' colorDlg
			' 
			Me.colorDlg.ClientSize = New System.Drawing.Size(398, 351)
			Me.colorDlg.Color = System.Drawing.Color.Empty
			Me.colorDlg.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.colorDlg.Icon = (DirectCast(resources.GetObject("colorDlg.Icon"), System.Drawing.Icon))
			Me.colorDlg.Location = New System.Drawing.Point(193, 207)
			Me.colorDlg.MaximizeBox = False
			Me.colorDlg.MinimizeBox = False
			Me.colorDlg.Name = "colorDlg"
			Me.colorDlg.ShowCaptionImage = False
			Me.colorDlg.ShowInTaskbar = False
			Me.colorDlg.Sizable = False
			Me.colorDlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.colorDlg.Text = "Edit Color"
			Me.colorDlg.Visible = False
			' 
			' GroupValues
			' 
			Me.GroupValues.Location = New System.Drawing.Point(4, 41)
			Me.GroupValues.Name = "GroupValues"
			Me.GroupValues.Size = New System.Drawing.Size(173, 24)
			Me.GroupValues.TabIndex = 1
			Me.GroupValues.Text = "Group Values Below Value"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.GroupValues.Click += new System.EventHandler(this.GroupValues_Click);
			' 
			' UngroupData
			' 
			Me.UngroupData.Location = New System.Drawing.Point(4, 73)
			Me.UngroupData.Name = "UngroupData"
			Me.UngroupData.Size = New System.Drawing.Size(173, 24)
			Me.UngroupData.TabIndex = 2
			Me.UngroupData.Text = "Ungroup Data"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UngroupData.Click += new System.EventHandler(this.UngroupData_Click);
			' 
			' NGroupedPieUC
			' 
			Me.Controls.Add(Me.UngroupData)
			Me.Controls.Add(Me.GroupValues)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.ChangeDataButton)
			Me.Name = "NGroupedPieUC"
			Me.Size = New System.Drawing.Size(180, 276)
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Grouped Pie Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			' setup chart
			Dim m_Chart As NChart = New NPieChart()
			m_Chart.Enable3D = True

			nChartControl1.Charts.Clear()
			nChartControl1.Charts.Add(m_Chart)
			m_Chart.DisplayOnLegend = nChartControl1.Legends(0)
			m_Chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated)
			m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.VividCameraLight)
			m_Chart.Location = New NPointL(New NLength(20, NRelativeUnit.ParentPercentage), New NLength(20, NRelativeUnit.ParentPercentage))
			m_Chart.Size = New NSizeL(New NLength(60, NRelativeUnit.ParentPercentage), New NLength(60, NRelativeUnit.ParentPercentage))

			' setup pie series
			m_Pie = CType(m_Chart.Series.Add(SeriesType.Pie), NPieSeries)
			m_Pie.Legend.Mode = SeriesLegendMode.DataPoints
			m_Pie.Legend.Format = "<label> <percent>"
			m_Pie.Legend.TextStyle.FontStyle.EmSize = New NLength(10, NGraphicsUnit.Pixel)
			m_Pie.ConnectorLength = New NLength(10)

			m_Pie.Labels.Add("Cars")
			m_Pie.Labels.Add("Trains")
			m_Pie.Labels.Add("Airplanes")
			m_Pie.Labels.Add("Buses")
			m_Pie.Labels.Add("Bikes")
			m_Pie.Labels.Add("Motorcycles")
			m_Pie.Labels.Add("Shuttles")
			m_Pie.Labels.Add("Rollers")
			m_Pie.Labels.Add("Ski")
			m_Pie.Labels.Add("Surf")

			' fill with random data
			m_Pie.Detachments.FillRandomRange(Random, 10, 0, 0)
			m_Pie.Values.FillRandomRange(Random, 10, 0, 100)

			' apply style sheet
			Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor)
			styleSheet.Apply(nChartControl1.Document)

			' store the original data and styles
			m_Values = DirectCast(m_Pie.Values.Clone(), NDataSeriesDouble)
			m_Detachments = DirectCast(m_Pie.Detachments.Clone(), NDataSeriesDouble)
			m_Labels = DirectCast(m_Pie.Labels.Clone(), NDataSeriesString)
			m_FillStyles = DirectCast(m_Pie.FillStyles.Clone(), NIndexedAttributeSeries)
			m_BorderStyles = DirectCast(m_Pie.BorderStyles.Clone(), NIndexedAttributeSeries)
			m_bGroupedData = False

			' init form controls
			GroupValueText.Text = "34"
			m_sGroupLabel = "Other"
			m_GroupColor = Color.Red
		End Sub

		Private Sub ChangeDataButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDataButton.Click
			' generate random values
			m_Pie.Values.FillRandomRange(Random, 10, 0, 100)

			' store the new values
			m_Values = DirectCast(m_Pie.Values.Clone(), NDataSeriesDouble)

			' restore other data series
			m_Pie.Detachments = DirectCast(m_Detachments.Clone(), NDataSeriesDouble)
			m_Pie.Labels = DirectCast(m_Labels.Clone(), NDataSeriesString)
			m_Pie.FillStyles = DirectCast(m_FillStyles.Clone(), NIndexedAttributeSeries)
			m_Pie.BorderStyles = DirectCast(m_BorderStyles.Clone(), NIndexedAttributeSeries)

			m_bGroupedData = False
			nChartControl1.Refresh()
		End Sub

		Private Sub GroupValueText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupValueText.TextChanged
			Try
				m_dGroupValue = Double.Parse(GroupValueText.Text)
			Catch
			End Try
		End Sub

		Private Sub GroupLabel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupLabel.TextChanged
			If nChartControl1 Is Nothing Then
				Return
			End If

			m_sGroupLabel = GroupLabel.Text

			If m_bGroupedData Then
				m_Pie.Labels(m_Pie.Labels.Count -1) = m_sGroupLabel
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub GroupColorButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupColorButton.Click
			colorDlg.Color = m_GroupColor

			If colorDlg.ShowDialog() = DialogResult.Cancel Then
				Return
			End If

			m_GroupColor = colorDlg.Color

			If m_bGroupedData Then
				Dim nIndex As Integer = m_Pie.Values.Count - 1

				m_Pie.FillStyles(nIndex) = New NColorFillStyle(m_GroupColor)
				DirectCast(m_Pie.BorderStyles(nIndex), NStrokeStyle).Color = m_GroupColor
			End If

			nChartControl1.Refresh()
		End Sub

		Private Sub GroupValues_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupValues.Click
			If m_bGroupedData Then
				MessageBox.Show("Click the ungroup button first")
				Return
			End If

			' get a subset containing the pies which are smaller than the specified value
			Dim smallerThanValue As NDataSeriesSubset = m_Pie.Values.Filter(Nevron.Chart.CompareMethod.Less, m_dGroupValue)

			' determine the sum of the filtered pies
			Dim dOtherSliceValue As Double = m_Pie.Values.Evaluate("SUM", smallerThanValue)

			' remove the data points contained in the 
			For i As Integer = m_Pie.GetDataPointCount() To 0 Step -1
				If smallerThanValue.Contains(i) Then
					m_Pie.RemoveDataPointAt(i)
				End If
			Next i

			' add a detached pie with the specified group label and color
			Dim dp As New NDataPoint(dOtherSliceValue, m_sGroupLabel)
			dp(DataPointValue.PieDetachment) = 2
			dp(DataPointValue.FillStyle) = New NColorFillStyle(m_GroupColor)
			dp(DataPointValue.StrokeStyle) = New NStrokeStyle(1, m_GroupColor)
			m_Pie.AddDataPoint(dp)

			m_bGroupedData = True
			nChartControl1.Refresh()
		End Sub

		Private Sub UngroupData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UngroupData.Click
			If m_bGroupedData = False Then
				MessageBox.Show("Data is not grouped - click the Group Values button first")
				Return
			End If

			' just restore with initial data
			m_Pie.Values = DirectCast(m_Values.Clone(), NDataSeriesDouble)
			m_Pie.Detachments = DirectCast(m_Detachments.Clone(), NDataSeriesDouble)
			m_Pie.Labels = DirectCast(m_Labels.Clone(), NDataSeriesString)
			m_Pie.FillStyles = DirectCast(m_FillStyles.Clone(), NIndexedAttributeSeries)
			m_Pie.BorderStyles = DirectCast(m_BorderStyles.Clone(), NIndexedAttributeSeries)

			m_bGroupedData = False
			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace
