Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart

Namespace Nevron.Examples.Chart.WinForm
    <ToolboxItem(False)> _
 Public Class NSampledArea2DUC
        Inherits NExampleBaseUC

        Private m_Chart As NChart
        Private m_Area As NAreaSeries
        Private DataPointCountTextBox As Nevron.UI.WinForm.Controls.NTextBox
        Private WithEvents UseXValuesCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
        Private label1 As Label
        Private WithEvents ClearDataButton As Nevron.UI.WinForm.Controls.NButton
        Private WithEvents SampleDistanceScroll As Nevron.UI.WinForm.Controls.NHScrollBar
        Private label2 As Label
        Private WithEvents Add40KDataButton As Nevron.UI.WinForm.Controls.NButton
        Private WithEvents Add20KDataButton As Nevron.UI.WinForm.Controls.NButton
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
            Me.DataPointCountTextBox = New Nevron.UI.WinForm.Controls.NTextBox()
            Me.UseXValuesCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.ClearDataButton = New Nevron.UI.WinForm.Controls.NButton()
            Me.SampleDistanceScroll = New Nevron.UI.WinForm.Controls.NHScrollBar()
            Me.label2 = New System.Windows.Forms.Label()
            Me.Add40KDataButton = New Nevron.UI.WinForm.Controls.NButton()
            Me.Add20KDataButton = New Nevron.UI.WinForm.Controls.NButton()
            Me.SuspendLayout()
            ' 
            ' DataPointCountTextBox
            ' 
            Me.DataPointCountTextBox.Location = New System.Drawing.Point(18, 166)
            Me.DataPointCountTextBox.Name = "DataPointCountTextBox"
            Me.DataPointCountTextBox.ReadOnly = True
            Me.DataPointCountTextBox.Size = New System.Drawing.Size(144, 18)
            Me.DataPointCountTextBox.TabIndex = 6
            ' 
            ' UseXValuesCheckBox
            ' 
            Me.UseXValuesCheckBox.ButtonProperties.BorderOffset = 2
            Me.UseXValuesCheckBox.Location = New System.Drawing.Point(21, 50)
            Me.UseXValuesCheckBox.Name = "UseXValuesCheckBox"
            Me.UseXValuesCheckBox.Size = New System.Drawing.Size(150, 24)
            Me.UseXValuesCheckBox.TabIndex = 2
            Me.UseXValuesCheckBox.Text = "Use X Values"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.UseXValuesCheckBox.CheckedChanged += new System.EventHandler(this.UseXValuesCheckBox_CheckedChanged);
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(18, 142)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(144, 21)
            Me.label1.TabIndex = 5
            Me.label1.Text = "Data Point Count:"
            Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            ' 
            ' ClearDataButton
            ' 
            Me.ClearDataButton.Location = New System.Drawing.Point(18, 240)
            Me.ClearDataButton.Name = "ClearDataButton"
            Me.ClearDataButton.Size = New System.Drawing.Size(144, 23)
            Me.ClearDataButton.TabIndex = 7
            Me.ClearDataButton.Text = "Clear Data"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
            ' 
            ' SampleDistanceScroll
            ' 
            Me.SampleDistanceScroll.LargeChange = 1
            Me.SampleDistanceScroll.Location = New System.Drawing.Point(21, 26)
            Me.SampleDistanceScroll.Maximum = 12
            Me.SampleDistanceScroll.Minimum = 1
            Me.SampleDistanceScroll.MinimumSize = New System.Drawing.Size(32, 16)
            Me.SampleDistanceScroll.Name = "SampleDistanceScroll"
            Me.SampleDistanceScroll.Size = New System.Drawing.Size(144, 18)
            Me.SampleDistanceScroll.TabIndex = 1
            Me.SampleDistanceScroll.Value = 1
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.SampleDistanceScroll.ValueChanged += new Nevron.UI.WinForm.Controls.ScrollBarEventHandler(this.SampleDistanceScroll_ValueChanged);
            ' 
            ' label2
            ' 
            Me.label2.Location = New System.Drawing.Point(21, 10)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(144, 21)
            Me.label2.TabIndex = 0
            Me.label2.Text = "Sample Distance:"
            ' 
            ' Add40KDataButton
            ' 
            Me.Add40KDataButton.Location = New System.Drawing.Point(18, 116)
            Me.Add40KDataButton.Name = "Add40KDataButton"
            Me.Add40KDataButton.Size = New System.Drawing.Size(144, 23)
            Me.Add40KDataButton.TabIndex = 4
            Me.Add40KDataButton.Text = "Add 40,000 Data Points"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.Add40KDataButton.Click += new System.EventHandler(this.Add40KDataButton_Click);
            ' 
            ' Add20KDataButton
            ' 
            Me.Add20KDataButton.Location = New System.Drawing.Point(18, 87)
            Me.Add20KDataButton.Name = "Add20KDataButton"
            Me.Add20KDataButton.Size = New System.Drawing.Size(144, 23)
            Me.Add20KDataButton.TabIndex = 3
            Me.Add20KDataButton.Text = "Add 20,000 Data Points"
            'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
            'ORIGINAL LINE: this.Add20KDataButton.Click += new System.EventHandler(this.Add20KDataButton_Click);
            ' 
            ' NSampledArea2DUC
            ' 
            Me.Controls.Add(Me.DataPointCountTextBox)
            Me.Controls.Add(Me.UseXValuesCheckBox)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.ClearDataButton)
            Me.Controls.Add(Me.SampleDistanceScroll)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.Add40KDataButton)
            Me.Controls.Add(Me.Add20KDataButton)
            Me.Name = "NSampledArea2DUC"
            Me.Size = New System.Drawing.Size(180, 277)
            Me.ResumeLayout(False)

        End Sub
#End Region

        Public Overrides Sub Initialize()
            MyBase.Initialize()

            ' set a chart title
            Dim title As NLabel = nChartControl1.Labels.AddHeader("2D Sampled Area Chart")
            title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)

            ' no legend
            nChartControl1.Legends.Clear()

            ' setup the chart
            m_Chart = nChartControl1.Charts(0)
            m_Chart.Axis(StandardAxis.Depth).Visible = False

            ' add interlace stripe
            Dim linearScale As NLinearScaleConfigurator = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
            Dim stripStyle As New NScaleStripStyle(New NColorFillStyle(Color.Beige), Nothing, True, 0, 0, 1, 1)
            stripStyle.Interlaced = True
            stripStyle.SetShowAtWall(ChartWallType.Back, True)
            stripStyle.SetShowAtWall(ChartWallType.Left, True)
            linearScale.StripStyles.Add(stripStyle)

            ' apply linear scaling to the x axis
            linearScale = New NLinearScaleConfigurator()
            m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = linearScale

            linearScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, True)
            linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

            linearScale = TryCast(m_Chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator, NLinearScaleConfigurator)
            linearScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot

            ' add the area series
            m_Area = CType(m_Chart.Series.Add(SeriesType.Area), NAreaSeries)
            m_Area.Name = "Area Series"
            m_Area.DataLabelStyle.Visible = False
            m_Area.MarkerStyle.Visible = False
            m_Area.SamplingMode = SeriesSamplingMode.Enabled
            m_Area.UseXValues = True

            ' apply layout
            ConfigureStandardLayout(m_Chart, title, Nothing)

            ' apply style sheet
            Dim styleSheet As NStyleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.Fresh)
            styleSheet.Apply(nChartControl1.Document)

            UseXValuesCheckBox.Checked = True

            Add40KDataButton_Click(Nothing, Nothing)
        End Sub

        Private Sub AddNewData(ByVal count As Integer)
            Dim rand As Random = New Random()
            Dim prevXVal As Double = 0
            Dim prevYVal As Double = 0

            Dim angle As Double = 0
            Dim phase As Double = (Math.PI * 2 * rand.NextDouble()) / count + 0.0001
            Dim magnitude As Double = rand.NextDouble() * 5

            Dim xValues As Double() = New Double(count - 1) {}
            Dim yValues As Double() = New Double(count - 1) {}

            Dim valueCount As Integer = m_Area.Values.Count
            If valueCount > 0 Then
                prevXVal = CDbl(m_Area.XValues(valueCount - 1))
                prevYVal = CDbl(m_Area.Values(valueCount - 1))
            End If


            Dim i As Integer = 0
            Do While i < count
                Dim yStep As Double = prevYVal + Math.Sin(angle) * magnitude
                Dim xStep As Double = rand.NextDouble() * magnitude

                If xStep < 0 Then
                    xStep = 0
                End If

                angle += phase
                prevXVal += xStep

                yValues(i) = yStep
                xValues(i) = prevXVal
                i += 1
            Loop

            valueCount = m_Area.Values.Count
            i = 0
            Do While i < valueCount - 1
                Dim prevVal As Double = CDbl(m_Area.XValues(i))
                Dim nextVal As Double = CDbl(m_Area.XValues(i + 1))
                Debug.Assert(prevVal <= nextVal)
                i += 1
            Loop

            m_Area.Values.AddRange(yValues)
            m_Area.XValues.AddRange(xValues)

            UpdateCounter()

            nChartControl1.Refresh()
        End Sub

        Private Sub SampleDistanceScroll_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles SampleDistanceScroll.ValueChanged
            m_Area.SampleDistance = New NLength(CSng(SampleDistanceScroll.Value))
            nChartControl1.Refresh()
        End Sub

        Private Sub UpdateCounter()
            Dim count As Integer = m_Area.Values.Count
            DataPointCountTextBox.Text = (count \ 1000).ToString() & "K"

            If count > 1000000 Then
                Add20KDataButton.Enabled = False
                Add40KDataButton.Enabled = False
            Else
                Add20KDataButton.Enabled = True
                Add40KDataButton.Enabled = True
            End If
        End Sub

        Private Sub Add20KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add20KDataButton.Click
            AddNewData(20000)
        End Sub

        Private Sub Add40KDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Add40KDataButton.Click
            AddNewData(40000)
        End Sub

        Private Sub ClearDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClearDataButton.Click
            m_Area.Values.Clear()
            UpdateCounter()

            nChartControl1.Refresh()
        End Sub

        Private Sub UseXValuesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles UseXValuesCheckBox.CheckedChanged
            m_Area.UseXValues = UseXValuesCheckBox.Checked

            If UseXValuesCheckBox.Checked Then
                m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NLinearScaleConfigurator()
            Else
                m_Chart.Axis(StandardAxis.PrimaryX).ScaleConfigurator = New NOrdinalScaleConfigurator()
            End If

            nChartControl1.Refresh()
        End Sub
    End Class
End Namespace