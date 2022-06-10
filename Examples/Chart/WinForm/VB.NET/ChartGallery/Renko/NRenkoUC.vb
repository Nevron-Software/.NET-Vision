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
Imports Nevron.UI.WinForm.Controls
Imports System.Text


Namespace Nevron.Examples.Chart.WinForm
	<ToolboxItem(False)>
	Public Class NRenkoUC
		Inherits NExampleBaseUC

		Private WithEvents UpBorderStyleButton As NButton
		Private WithEvents DownBorderStyleButton As NButton
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents UpFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents DownFillStyleButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents BoxWidthPercentCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents BoxSizeCombo As Nevron.UI.WinForm.Controls.NComboBox
		Private textBox1 As Nevron.UI.WinForm.Controls.NTextBox
		Private label3 As Label
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			InitializeComponent()

			BoxSizeCombo.Items.AddRange(New String(){ "0.5", "1", "2", "2%", "5%", "10%" })
			BoxWidthPercentCombo.Items.AddRange(New String(){ "50%", "75%", "100%" })
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
			Me.UpBorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.UpFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownFillStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.DownBorderStyleButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.BoxWidthPercentCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.BoxSizeCombo = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.textBox1 = New Nevron.UI.WinForm.Controls.NTextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' UpBorderStyleButton
			' 
			Me.UpBorderStyleButton.Location = New System.Drawing.Point(5, 10)
			Me.UpBorderStyleButton.Name = "UpBorderStyleButton"
			Me.UpBorderStyleButton.Size = New System.Drawing.Size(170, 24)
			Me.UpBorderStyleButton.TabIndex = 0
			Me.UpBorderStyleButton.Text = "Up Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpBorderStyleButton.Click += new System.EventHandler(this.UpBorderPropsButton_Click);
			' 
			' UpFillStyleButton
			' 
			Me.UpFillStyleButton.Location = New System.Drawing.Point(5, 72)
			Me.UpFillStyleButton.Name = "UpFillStyleButton"
			Me.UpFillStyleButton.Size = New System.Drawing.Size(170, 24)
			Me.UpFillStyleButton.TabIndex = 2
			Me.UpFillStyleButton.Text = "Up Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.UpFillStyleButton.Click += new System.EventHandler(this.UpFillStyleStyleButton_Click);
			' 
			' DownFillStyleButton
			' 
			Me.DownFillStyleButton.Location = New System.Drawing.Point(5, 103)
			Me.DownFillStyleButton.Name = "DownFillStyleButton"
			Me.DownFillStyleButton.Size = New System.Drawing.Size(170, 24)
			Me.DownFillStyleButton.TabIndex = 3
			Me.DownFillStyleButton.Text = "Down Fill Style..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownFillStyleButton.Click += new System.EventHandler(this.DownFillStyleButton_Click);
			' 
			' DownBorderStyleButton
			' 
			Me.DownBorderStyleButton.Location = New System.Drawing.Point(5, 41)
			Me.DownBorderStyleButton.Name = "DownBorderStyleButton"
			Me.DownBorderStyleButton.Size = New System.Drawing.Size(170, 24)
			Me.DownBorderStyleButton.TabIndex = 1
			Me.DownBorderStyleButton.Text = "Down Border Style ..."
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DownBorderStyleButton.Click += new System.EventHandler(this.DownBorderStyleButton_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(5, 142)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(71, 16)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Box Size:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(5, 203)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(120, 16)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Box Width Percent:"
			' 
			' BoxWidthPercentCombo
			' 
			Me.BoxWidthPercentCombo.ListProperties.CheckBoxDataMember = ""
			Me.BoxWidthPercentCombo.ListProperties.DataSource = Nothing
			Me.BoxWidthPercentCombo.ListProperties.DisplayMember = ""
			Me.BoxWidthPercentCombo.Location = New System.Drawing.Point(5, 221)
			Me.BoxWidthPercentCombo.Name = "BoxWidthPercentCombo"
			Me.BoxWidthPercentCombo.Size = New System.Drawing.Size(167, 21)
			Me.BoxWidthPercentCombo.TabIndex = 7
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoxWidthPercentCombo.SelectedIndexChanged += new System.EventHandler(this.BoxWidthPercentCombo_SelectedIndexChanged);
			' 
			' BoxSizeCombo
			' 
			Me.BoxSizeCombo.ListProperties.CheckBoxDataMember = ""
			Me.BoxSizeCombo.ListProperties.DataSource = Nothing
			Me.BoxSizeCombo.ListProperties.DisplayMember = ""
			Me.BoxSizeCombo.Location = New System.Drawing.Point(5, 161)
			Me.BoxSizeCombo.Name = "BoxSizeCombo"
			Me.BoxSizeCombo.Size = New System.Drawing.Size(167, 21)
			Me.BoxSizeCombo.TabIndex = 5
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.BoxSizeCombo.SelectedIndexChanged += new System.EventHandler(this.BoxSizeCombo_SelectedIndexChanged);
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(5, 271)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(167, 213)
			Me.textBox1.TabIndex = 9
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(5, 254)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(70, 13)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Current Data:"
			' 
			' NRenkoUC
			' 
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.BoxSizeCombo)
			Me.Controls.Add(Me.BoxWidthPercentCombo)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.DownBorderStyleButton)
			Me.Controls.Add(Me.DownFillStyleButton)
			Me.Controls.Add(Me.UpFillStyleButton)
			Me.Controls.Add(Me.UpBorderStyleButton)
			Me.Name = "NRenkoUC"
			Me.Size = New System.Drawing.Size(180, 554)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Public Overrides Sub Initialize()
			MyBase.Initialize()

			' remove all legends
			nChartControl1.Legends.Clear()

			' set a chart title
			Dim title As NLabel = nChartControl1.Labels.AddHeader("Renko Chart")
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

			' setup Renko series
			Dim renko As NRenkoSeries = CType(chart.Series.Add(SeriesType.Renko), NRenkoSeries)
			renko.UseXValues = True

			GenerateData(renko)

			' apply layout
			ConfigureStandardLayout(chart, title, Nothing)

			BoxSizeCombo.SelectedIndex = 1
			BoxWidthPercentCombo.SelectedIndex = 2

			AddHandler nChartControl1.MouseMove, AddressOf nChartControl1_MouseMove
		End Sub

		Private Sub nChartControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim result As NHitTestResult = nChartControl1.HitTest(e.X, e.Y)

			If result.ChartElement = ChartElement.RenkoData Then
				Dim renkoData As NRenkoData = result.RenkoData

				Dim builder As New StringBuilder()

				builder.AppendLine("BeginY:" & renkoData.BeginY.ToString())
				builder.AppendLine("EndY:" & renkoData.EndY.ToString())
				builder.AppendLine("BoxCount:" & renkoData.BoxCount.ToString())
				builder.AppendLine("Direction:" & renkoData.Direction.ToString())
				builder.AppendLine("DirectionChanged:" & renkoData.DirectionChanged.ToString())

				textBox1.Text = builder.ToString()
			Else
				textBox1.Text = String.Empty
			End If
		End Sub

		Private Sub GenerateData(ByVal renko As NRenkoSeries)
			Dim dataGenerator As New NStockDataGenerator(New NRange1DD(50, 350), 0.02, 10)
			dataGenerator.Reset()

			Dim dt As New Date(2007, 1, 1)

			For i As Integer = 0 To 19
				renko.Values.Add(dataGenerator.GetNextValue())
				renko.XValues.Add(dt)

				dt = dt.AddDays(1)
			Next i
		End Sub

		Private Sub UpBorderPropsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpBorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim renko As NRenkoSeries = CType(nChartControl1.Charts(0).Series(0), NRenkoSeries)

			If NStrokeStyleTypeEditor.Edit(renko.BorderStyle, strokeStyleResult) Then
				renko.UpStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub DownBorderStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownBorderStyleButton.Click
			Dim strokeStyleResult As NStrokeStyle = Nothing
			Dim renko As NRenkoSeries = CType(nChartControl1.Charts(0).Series(0), NRenkoSeries)

			If NStrokeStyleTypeEditor.Edit(renko.BorderStyle, strokeStyleResult) Then
				renko.DownStrokeStyle = strokeStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub UpFillStyleStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpFillStyleButton.Click
			Dim upFillStyleResult As NFillStyle = Nothing
			Dim renko As NRenkoSeries = CType(nChartControl1.Charts(0).Series(0), NRenkoSeries)

			If NFillStyleTypeEditor.Edit(renko.UpFillStyle, upFillStyleResult) Then
				renko.UpFillStyle = upFillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub DownFillStyleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DownFillStyleButton.Click
			Dim downFillStyleResult As NFillStyle = Nothing
			Dim renko As NRenkoSeries = CType(nChartControl1.Charts(0).Series(0), NRenkoSeries)

			If NFillStyleTypeEditor.Edit(renko.DownFillStyle, downFillStyleResult) Then
				renko.DownFillStyle = downFillStyleResult
				nChartControl1.Refresh()
			End If
		End Sub

		Private Sub BoxSizeCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BoxSizeCombo.SelectedIndexChanged
			Dim renko As NRenkoSeries = CType(nChartControl1.Charts(0).Series(0), NRenkoSeries)

			Select Case BoxSizeCombo.SelectedIndex
				Case 0
					renko.BoxSize = 0.5
					renko.BoxSizeInPercents = False

				Case 1
					renko.BoxSize = 1
					renko.BoxSizeInPercents = False

				Case 2
					renko.BoxSize = 2
					renko.BoxSizeInPercents = False

				Case 3
					renko.BoxSize = 2
					renko.BoxSizeInPercents = True

				Case 4
					renko.BoxSize = 5
					renko.BoxSizeInPercents = True

				Case 5
					renko.BoxSize = 10
					renko.BoxSizeInPercents = True
			End Select

			nChartControl1.Refresh()
		End Sub

		Private Sub BoxWidthPercentCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BoxWidthPercentCombo.SelectedIndexChanged
			Dim renko As NRenkoSeries = CType(nChartControl1.Charts(0).Series(0), NRenkoSeries)

			Select Case BoxWidthPercentCombo.SelectedIndex
				Case 0
					renko.BoxWidthPercent = 50

				Case 1
					renko.BoxWidthPercent = 75

				Case 2
					renko.BoxWidthPercent = 100
			End Select

			nChartControl1.Refresh()
		End Sub
	End Class
End Namespace