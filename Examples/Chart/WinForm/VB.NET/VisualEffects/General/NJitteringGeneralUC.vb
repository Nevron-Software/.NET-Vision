Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Chart
Imports Nevron.Chart.WinForm
Imports Nevron.Chart.Windows

Namespace Nevron.Examples.Chart.WinForm
    <ToolboxItem(False)> _
    Public Class NJitteringGeneralUC
        Inherits NExampleBaseUC
        Private m_Chart As NChart
        Private WithEvents EnableJitteringCheckBox As Nevron.UI.WinForm.Controls.NCheckBox
        Private label1 As System.Windows.Forms.Label
        Private label6 As System.Windows.Forms.Label
        Private WithEvents JitteringDeviationUpDown As Nevron.UI.WinForm.Controls.NNumericUpDown
        Private WithEvents JitteringStepsComboBox As Nevron.UI.WinForm.Controls.NComboBox
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
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
            Me.EnableJitteringCheckBox = New Nevron.UI.WinForm.Controls.NCheckBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label6 = New System.Windows.Forms.Label()
            Me.JitteringDeviationUpDown = New Nevron.UI.WinForm.Controls.NNumericUpDown()
            Me.JitteringStepsComboBox = New Nevron.UI.WinForm.Controls.NComboBox()
            CType(Me.JitteringDeviationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' EnableJitteringCheckBox
            ' 
            Me.EnableJitteringCheckBox.Location = New System.Drawing.Point(11, 12)
            Me.EnableJitteringCheckBox.Name = "EnableJitteringCheckBox"
            Me.EnableJitteringCheckBox.Size = New System.Drawing.Size(120, 21)
            Me.EnableJitteringCheckBox.TabIndex = 0
            Me.EnableJitteringCheckBox.Text = "Enable jittering"
            '			Me.EnableJitteringCheckBox.CheckedChanged += New System.EventHandler(Me.EnableJitteringCheckBox_CheckedChanged);
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(11, 46)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(104, 16)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Jittering steps:"
            ' 
            ' label6
            ' 
            Me.label6.Location = New System.Drawing.Point(11, 104)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(104, 16)
            Me.label6.TabIndex = 3
            Me.label6.Text = "Jittering deviation:"
            ' 
            ' JitteringDeviationUpDown
            ' 
            Me.JitteringDeviationUpDown.DecimalPlaces = 1
            Me.JitteringDeviationUpDown.Increment = New System.Decimal(New Integer() {1, 0, 0, 65536})
            Me.JitteringDeviationUpDown.Location = New System.Drawing.Point(11, 124)
            Me.JitteringDeviationUpDown.Name = "JitteringDeviationUpDown"
            Me.JitteringDeviationUpDown.Size = New System.Drawing.Size(110, 20)
            Me.JitteringDeviationUpDown.TabIndex = 4
            '			Me.JitteringDeviationUpDown.ValueChanged += New System.EventHandler(Me.JitteringDeviationUpDown_ValueChanged);
            ' 
            ' JitteringStepsComboBox
            ' 
            Me.JitteringStepsComboBox.Location = New System.Drawing.Point(11, 66)
            Me.JitteringStepsComboBox.Name = "JitteringStepsComboBox"
            Me.JitteringStepsComboBox.Size = New System.Drawing.Size(110, 21)
            Me.JitteringStepsComboBox.TabIndex = 2
            '			Me.JitteringStepsComboBox.SelectedIndexChanged += New System.EventHandler(Me.JitteringStepsComboBox_SelectedIndexChanged);
            ' 
            ' JitteringGeneralUC
            ' 
            Me.Controls.Add(Me.JitteringStepsComboBox)
            Me.Controls.Add(Me.JitteringDeviationUpDown)
            Me.Controls.Add(Me.label6)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.EnableJitteringCheckBox)
            Me.Name = "JitteringGeneralUC"
            Me.Size = New System.Drawing.Size(175, 183)
            CType(Me.JitteringDeviationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
#End Region

        Public Overrides Sub Initialize()
            MyBase.Initialize()

            nChartControl1.Controller.Tools.Add(New NTrackballTool())

            ' set a chart title
            Dim title As NLabel = nChartControl1.Labels.AddHeader("Jittering / Blur Effect")
            title.TextStyle.FontStyle = New NFontStyle("Times New Roman", 18, FontStyle.Italic)
            title.TextStyle.FillStyle = New NColorFillStyle(GreyBlue)
            title.ContentAlignment = ContentAlignment.BottomCenter
            title.Location = New NPointL(New NLength(50, NRelativeUnit.ParentPercentage), New NLength(2, NRelativeUnit.ParentPercentage))

            m_Chart = nChartControl1.Charts(0)
            m_Chart.Enable3D = True
            m_Chart.Axis(StandardAxis.Depth).Visible = False
            m_Chart.Depth = 34
            m_Chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights)
            m_Chart.Projection.Type = ProjectionType.Perspective
            m_Chart.Projection.Elevation = 17
            m_Chart.Projection.Rotation = -10

            Dim c As Color = Color.FromArgb(128, 128, 192)
            m_Chart.Wall(ChartWallType.Left).FillStyle = New NGradientFillStyle(GradientStyle.DiagonalDown, GradientVariant.Variant3, c, Color.White)
            m_Chart.Wall(ChartWallType.Floor).FillStyle = New NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant3, c, Color.White)
            m_Chart.Wall(ChartWallType.Back).FillStyle = New NGradientFillStyle(GradientStyle.DiagonalDown, GradientVariant.Variant3, c, Color.White)

            Dim bubble As NBubbleSeries = CType(m_Chart.Series.Add(SeriesType.Bubble), NBubbleSeries)
            bubble.InflateMargins = False
            bubble.DataLabelStyle.Visible = False
            bubble.Legend.Mode = SeriesLegendMode.DataPoints
            bubble.BubbleShape = PointShape.Sphere

            bubble.AddDataPoint(New NBubbleDataPoint(10, 10, "B1", New NColorFillStyle(Color.DarkGoldenrod)))
            bubble.AddDataPoint(New NBubbleDataPoint(15, 20, "B2", New NColorFillStyle(Color.IndianRed)))
            bubble.AddDataPoint(New NBubbleDataPoint(12, 25, "B3", New NColorFillStyle(Color.DarkMagenta)))
            bubble.AddDataPoint(New NBubbleDataPoint(8, 15, "B4", New NColorFillStyle(Color.DarkOrchid)))

            Dim bar As NBarSeries = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
            bar.Name = "Stack 1"
            bar.DataLabelStyle.Visible = False
            bar.BarShape = BarShape.Cylinder
            bar.WidthPercent = 60
            bar.DepthPercent = 60
            bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
            bar.FillStyle = New NColorFillStyle(Color.CornflowerBlue)
            bar.Values.FillRandomRange(Random, 4, 5, 15)

            bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
            bar.MultiBarMode = MultiBarMode.Stacked
            bar.Name = "Stack 2"
            bar.DataLabelStyle.Visible = False
            bar.BarShape = BarShape.Cylinder
            bar.WidthPercent = 60
            bar.DepthPercent = 60
            bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
            bar.FillStyle = New NColorFillStyle(Color.Yellow)
            bar.Values.FillRandomRange(Random, 4, 5, 15)

            bar = CType(m_Chart.Series.Add(SeriesType.Bar), NBarSeries)
            bar.MultiBarMode = MultiBarMode.Stacked
            bar.Name = "Stack 3"
            bar.DataLabelStyle.Visible = False
            bar.BarShape = BarShape.Cylinder
            bar.WidthPercent = 60
            bar.DepthPercent = 60
            bar.BorderStyle.Width = New NLength(0, NGraphicsUnit.Pixel)
            bar.FillStyle = New NColorFillStyle(Color.MediumSeaGreen)
            bar.Values.FillRandomRange(Random, 4, 5, 15)

            ' init form controls
            For i As Integer = 2 To 16
                JitteringStepsComboBox.Items.Add(i.ToString())
            Next i

            JitteringStepsComboBox.SelectedIndex = nChartControl1.Settings.JitteringSteps - 2
            JitteringDeviationUpDown.Value = CDec(nChartControl1.Settings.JitteringDeviation)
            JitteringStepsComboBox.Enabled = False
            JitteringDeviationUpDown.Enabled = False
            EnableJitteringCheckBox.Checked = False
        End Sub

        Private Sub EnableJitteringCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EnableJitteringCheckBox.CheckedChanged
            JitteringStepsComboBox.Enabled = EnableJitteringCheckBox.Checked
            JitteringDeviationUpDown.Enabled = EnableJitteringCheckBox.Checked

            If EnableJitteringCheckBox.Checked Then
                nChartControl1.Settings.JitterMode = JitterMode.Enabled
            Else
                nChartControl1.Settings.JitterMode = JitterMode.Disabled
            End If

            If EnableJitteringCheckBox.Checked Then
                nChartControl1.Settings.JitteringSteps = JitteringStepsComboBox.SelectedIndex + 2
                nChartControl1.Settings.JitteringDeviation = CSng(JitteringDeviationUpDown.Value)
            End If

            nChartControl1.Refresh()
        End Sub

        Private Sub JitteringStepsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles JitteringStepsComboBox.SelectedIndexChanged
            If EnableJitteringCheckBox.Checked Then
                nChartControl1.Settings.JitteringSteps = JitteringStepsComboBox.SelectedIndex + 2
                nChartControl1.Settings.JitteringDeviation = Decimal.ToSingle(JitteringDeviationUpDown.Value)

                nChartControl1.Refresh()
            End If
        End Sub

        Private Sub JitteringDeviationUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles JitteringDeviationUpDown.ValueChanged
            If EnableJitteringCheckBox.Checked Then
                nChartControl1.Settings.JitteringSteps = JitteringStepsComboBox.SelectedIndex + 2
                nChartControl1.Settings.JitteringDeviation = Decimal.ToSingle(JitteringDeviationUpDown.Value)

                nChartControl1.Refresh()
            End If
        End Sub
    End Class
End Namespace
