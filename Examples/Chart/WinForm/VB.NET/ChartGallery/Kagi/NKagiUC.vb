Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports System.Text


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)> _
	Public Class NKagiUC
		Inherits NExampleBaseUC

		Private WithEvents UpStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DownStrokeStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents ReversalAmountCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private label2 As System.Windows.Forms.Label
		Private label1 As Label
		Private textBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			ReversalAmountCombo.Items.AddRange(New String(){ "0.5", "1", "2", "1%", "2%", "5%" })
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
			Me.UpStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownStrokeStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.ReversalAmountCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.textBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.SuspendLayout()
			' 
			' UpStrokeStyleButton
			' 
			Me.UpStrokeStyleButton.Location = New System.Drawing.Point(8, 10)
			Me.UpStrokeStyleButton.Name = "UpStrokeStyleButton"
			Me.UpStrokeStyleButton.Size = New System.Drawing.Size(163, 24)
			Me.UpStrokeStyleButton.TabIndex = 0
			Me.UpStrokeStyleButton.Text = "Up Stroke Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpStrokeStyleButton.Click += new System.EventHandler(this.UpStrokeStyleButton_Click);
			' 
			' DownStrokeStyleButton
			' 
			Me.DownStrokeStyleButton.Location = New System.Drawing.Point(8, 41)
			Me.DownStrokeStyleButton.Name = "DownStrokeStyleButton"
			Me.DownStrokeStyleButton.Size = New System.Drawing.Size(163, 24)
			Me.DownStrokeStyleButton.TabIndex = 1
			Me.DownStrokeStyleButton.Text = "Down Stroke Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownStrokeStyleButton.Click += new System.EventHandler(this.DownStrokeStyleButton_Click);
			' 
			' ReversalAmountCombo
			' 
			Me.ReversalAmountCombo.ListProperties.CheckBoxDataMember = ""
			Me.ReversalAmountCombo.ListProperties.DataSource = Nothing
			Me.ReversalAmountCombo.ListProperties.DisplayMember = ""
			Me.ReversalAmountCombo.Location = New System.Drawing.Point(9, 104)
			Me.ReversalAmountCombo.Name = "ReversalAmountCombo"
			Me.ReversalAmountCombo.Size = New System.Drawing.Size(160, 21)
			Me.ReversalAmountCombo.TabIndex = 3
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.ReversalAmountCombo.SelectedIndexChanged += new System.EventHandler(this.ReversalAmountCombo_SelectedIndexChanged);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(9, 84)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(113, 16)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Reversal Amount:"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(9, 147)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(70, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Current Data:"
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(9, 163)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(161, 213)
			Me.textBox1.TabIndex = 5
			' 
			' NKagiUC
			' 
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.ReversalAmountCombo)
			Me.Controls.Add(Me.DownStrokeStyleButton)
			Me.Controls.Add(Me.UpStrokeStyleButton)
			Me.Name = "NKagiUC"
			Me.Size = New System.Drawing.Size(180, 454)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' remove all legends
			nChartControl1.Legends.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Kagi Chart")
			title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
			title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
			title.ContentAlignment = ContentAlignment.BottomCenter
			title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

			Dim chart As NChart = nChartControl1.Charts(0)

			' setup X axis
			Dim priceConfigurator As New NPriceScaleConfigurator()
			priceConfigurator.InnerMajorTickStyle.LineStyle.Width = New NLength(0)
			chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = priceConfigurator

			' setup Y axis
			Dim linearScale As NLinearScaleConfigurator = CType(chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
			Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
			stripStyle.Interlaced = True
			stripStyle.SetShowAtWall(ChartWallType.Back, True)
			linearScale.StripStyles.Add(stripStyle)

			' setup Kagi series
			Dim kagi As NKagiSeries = CType(chart.Series.Add(SeriesType.Kagi), NKagiSeries)
			kagi.UpStrokeStyle.Color = Color.MidnightBlue
			kagi.DownStrokeStyle.Color = Color.MidnightBlue
			kagi.UseXValues = True

			GenerateData(kagi)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			ReversalAmountCombo.SelectedIndex = 0

			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove
		End Sub

		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If result.ChartElement = ChartElement.KagiData Then
				Dim kagiData As NKagiData = result.KagiData

				Dim builder As New StringBuilder()

				builder.AppendLine("DataIndex:" & kagiData.DataIndex.ToString())
				builder.AppendLine("TrendDirection:" & kagiData.TrendDirection.ToString())
				builder.AppendLine("PriorHigh:" & kagiData.PriorHigh.ToString())
				builder.AppendLine("PriorLow:" & kagiData.PriorLow.ToString())
				builder.AppendLine("X:" & kagiData.X.ToString())
				builder.AppendLine("Y:" & kagiData.Y.ToString())

				textBox1.Text = builder.ToString()
			Else
				textBox1.Text = String.Empty
			End If
		End Sub

		Private Sub GenerateData(ByVal series As NKagiSeries)
			Dim dataGenerator As New NStockDataGenerator(New NRange1DD(50, 350), 0.002, 2)
			dataGenerator.Reset()

			Dim dt As New Date(2007, 1, 1)

			For i As Integer = 0 To 99
				series.Values.Add(dataGenerator.GetNextValue())
				series.XValues.Add(dt)

				dt = dt.AddDays(1)
			Next i
		End Sub

		Private Sub UpStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpStrokeStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim kagi As NKagiSeries = CType(nChartControl1.Charts(0).Series(0), NKagiSeries)


			If NStrokeStyleTypeEditor.Edit(kagi.UpStrokeStyle, strokeStyleResult) Then
				kagi.UpStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub DownStrokeStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownStrokeStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim kagi As NKagiSeries = CType(nChartControl1.Charts(0).Series(0), NKagiSeries)


			If NStrokeStyleTypeEditor.Edit(kagi.DownStrokeStyle, strokeStyleResult) Then
				kagi.DownStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub ReversalAmountCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReversalAmountCombo.SelectedIndexChanged
			Dim kagi As NKagiSeries = CType(nChartControl1.Charts(0).Series(0), NKagiSeries)

			Select Case ReversalAmountCombo.SelectedIndex
				Case 0
					kagi.ReversalAmount = 0.5
					kagi.ReversalAmountInPercents = False

				Case 1
					kagi.ReversalAmount = 1
					kagi.ReversalAmountInPercents = False

				Case 2
					kagi.ReversalAmount = 2
					kagi.ReversalAmountInPercents = False

				Case 3
					kagi.ReversalAmount = 1
					kagi.ReversalAmountInPercents = True

				Case 4
					kagi.ReversalAmount = 2
					kagi.ReversalAmountInPercents = True

				Case 5
					kagi.ReversalAmount = 5
					kagi.ReversalAmountInPercents = True
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace