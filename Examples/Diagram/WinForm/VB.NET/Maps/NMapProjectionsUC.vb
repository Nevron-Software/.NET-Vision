Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram
Imports Nevron.Diagram.Filters
Imports Nevron.Diagram.Maps
Imports Nevron.Dom
Imports Nevron.GraphicsCore
Imports Nevron.UI.WinForm.Controls

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NProjectionsUC.
	''' </summary>
	Public Class NMapProjectionsUC
		Inherits NDiagramExampleUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer Generated Code"

		Private Sub InitializeComponent()
			Me.ShowDataButton = New Nevron.UI.WinForm.Controls.NButton()
			Me.cbProjection = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.zoomScrollbar = New Nevron.UI.WinForm.Controls.NHScrollBar()
			Me.lblZoomFactor = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.lblSetting = New System.Windows.Forms.Label()
			Me.nudSetting = New Nevron.UI.WinForm.Controls.NNumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
			Me.lblLattitude = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.lblLongitude = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.lblY = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.lblX = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.cbParallelRenderMode = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.cbMeridianRenderMode = New Nevron.UI.WinForm.Controls.NComboBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.cbLabelRenderMode = New Nevron.UI.WinForm.Controls.NComboBox()
			CType(Me.nudSetting, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tableLayoutPanel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' ShowDataButton
			' 
			Me.ShowDataButton.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.ShowDataButton.Location = New System.Drawing.Point(8, 78)
			Me.ShowDataButton.Name = "ShowDataButton"
			Me.ShowDataButton.Size = New System.Drawing.Size(243, 23)
			Me.ShowDataButton.TabIndex = 3
			Me.ShowDataButton.Text = "Show DBF Data"
			Me.ShowDataButton.UseVisualStyleBackColor = True
'			Me.ShowDataButton.Click += New System.EventHandler(Me.ShowDataButton_Click);
			' 
			' cbProjection
			' 
			Me.cbProjection.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbProjection.DropDownItems = 50
			Me.cbProjection.ListProperties.CheckBoxDataMember = ""
			Me.cbProjection.ListProperties.DataSource = Nothing
			Me.cbProjection.ListProperties.DisplayMember = ""
			Me.cbProjection.Location = New System.Drawing.Point(8, 39)
			Me.cbProjection.Name = "cbProjection"
			Me.cbProjection.Size = New System.Drawing.Size(243, 21)
			Me.cbProjection.TabIndex = 4
'			Me.cbProjection.SelectedIndexChanged += New System.EventHandler(Me.cbProjection_SelectedIndexChanged);
			' 
			' zoomScrollbar
			' 
			Me.zoomScrollbar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.zoomScrollbar.Location = New System.Drawing.Point(7, 136)
			Me.zoomScrollbar.Maximum = 600
			Me.zoomScrollbar.Minimum = 1
			Me.zoomScrollbar.MinimumSize = New System.Drawing.Size(34, 17)
			Me.zoomScrollbar.Name = "zoomScrollbar"
			Me.zoomScrollbar.Size = New System.Drawing.Size(244, 17)
			Me.zoomScrollbar.TabIndex = 8
			Me.zoomScrollbar.Value = 7
'			Me.zoomScrollbar.ValueChanged += New Nevron.UI.WinForm.Controls.ScrollBarEventHandler(Me.zoomScrollbar_ValueChanged);
			' 
			' lblZoomFactor
			' 
			Me.lblZoomFactor.AutoSize = True
			Me.lblZoomFactor.Location = New System.Drawing.Point(5, 118)
			Me.lblZoomFactor.Name = "lblZoomFactor"
			Me.lblZoomFactor.Size = New System.Drawing.Size(94, 13)
			Me.lblZoomFactor.TabIndex = 9
			Me.lblZoomFactor.Tag = "Zoom factor: {0:P}"
			Me.lblZoomFactor.Text = "Zoom factor: {0:P}"
			Me.lblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.label1.ForeColor = System.Drawing.Color.MediumBlue
			Me.label1.Location = New System.Drawing.Point(6, 15)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(82, 16)
			Me.label1.TabIndex = 10
			Me.label1.Tag = ""
			Me.label1.Text = "Projection:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' lblSetting
			' 
			Me.lblSetting.Location = New System.Drawing.Point(3, 178)
			Me.lblSetting.Name = "lblSetting"
			Me.lblSetting.Size = New System.Drawing.Size(123, 13)
			Me.lblSetting.TabIndex = 12
			Me.lblSetting.Tag = ""
			Me.lblSetting.Text = "Projection:"
			Me.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.lblSetting.Visible = False
			' 
			' nudSetting
			' 
			Me.nudSetting.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.nudSetting.Increment = New Decimal(New Integer() { 15, 0, 0, 0})
			Me.nudSetting.Location = New System.Drawing.Point(132, 176)
			Me.nudSetting.Maximum = New Decimal(New Integer() { 180, 0, 0, 0})
			Me.nudSetting.Minimum = New Decimal(New Integer() { 180, 0, 0, -2147483648})
			Me.nudSetting.Name = "nudSetting"
			Me.nudSetting.Size = New System.Drawing.Size(113, 20)
			Me.nudSetting.TabIndex = 13
'			Me.nudSetting.ValueChanged += New System.EventHandler(Me.nudSetting_ValueChanged);
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(204)))
			Me.label2.ForeColor = System.Drawing.Color.MediumBlue
			Me.label2.Location = New System.Drawing.Point(6, 318)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(117, 16)
			Me.label2.TabIndex = 16
			Me.label2.Tag = ""
			Me.label2.Text = "Mouse position:"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' tableLayoutPanel1
			' 
			Me.tableLayoutPanel1.ColumnCount = 2
			Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
			Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
			Me.tableLayoutPanel1.Controls.Add(Me.lblLattitude, 1, 3)
			Me.tableLayoutPanel1.Controls.Add(Me.label9, 0, 3)
			Me.tableLayoutPanel1.Controls.Add(Me.lblLongitude, 1, 2)
			Me.tableLayoutPanel1.Controls.Add(Me.label7, 0, 2)
			Me.tableLayoutPanel1.Controls.Add(Me.lblY, 1, 1)
			Me.tableLayoutPanel1.Controls.Add(Me.label5, 0, 1)
			Me.tableLayoutPanel1.Controls.Add(Me.lblX, 1, 0)
			Me.tableLayoutPanel1.Controls.Add(Me.label3, 0, 0)
			Me.tableLayoutPanel1.Location = New System.Drawing.Point(5, 342)
			Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
			Me.tableLayoutPanel1.RowCount = 4
			Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F))
			Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F))
			Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F))
			Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F))
			Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F))
			Me.tableLayoutPanel1.Size = New System.Drawing.Size(243, 94)
			Me.tableLayoutPanel1.TabIndex = 17
			' 
			' lblLattitude
			' 
			Me.lblLattitude.AutoSize = True
			Me.lblLattitude.Dock = System.Windows.Forms.DockStyle.Fill
			Me.lblLattitude.Location = New System.Drawing.Point(66, 69)
			Me.lblLattitude.Name = "lblLattitude"
			Me.lblLattitude.Size = New System.Drawing.Size(174, 25)
			Me.lblLattitude.TabIndex = 7
			Me.lblLattitude.Text = "0"
			Me.lblLattitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label9.Location = New System.Drawing.Point(3, 69)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(57, 25)
			Me.label9.TabIndex = 6
			Me.label9.Text = "Lattitude:"
			Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' lblLongitude
			' 
			Me.lblLongitude.AutoSize = True
			Me.lblLongitude.Dock = System.Windows.Forms.DockStyle.Fill
			Me.lblLongitude.Location = New System.Drawing.Point(66, 46)
			Me.lblLongitude.Name = "lblLongitude"
			Me.lblLongitude.Size = New System.Drawing.Size(174, 23)
			Me.lblLongitude.TabIndex = 5
			Me.lblLongitude.Text = "0"
			Me.lblLongitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label7.Location = New System.Drawing.Point(3, 46)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(57, 23)
			Me.label7.TabIndex = 4
			Me.label7.Text = "Longitude:"
			Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' lblY
			' 
			Me.lblY.AutoSize = True
			Me.lblY.Dock = System.Windows.Forms.DockStyle.Fill
			Me.lblY.Location = New System.Drawing.Point(66, 23)
			Me.lblY.Name = "lblY"
			Me.lblY.Size = New System.Drawing.Size(174, 23)
			Me.lblY.TabIndex = 3
			Me.lblY.Text = "0"
			Me.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label5.Location = New System.Drawing.Point(3, 23)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(57, 23)
			Me.label5.TabIndex = 2
			Me.label5.Text = "Y:"
			Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' lblX
			' 
			Me.lblX.AutoSize = True
			Me.lblX.Dock = System.Windows.Forms.DockStyle.Fill
			Me.lblX.Location = New System.Drawing.Point(66, 0)
			Me.lblX.Name = "lblX"
			Me.lblX.Size = New System.Drawing.Size(174, 23)
			Me.lblX.TabIndex = 1
			Me.lblX.Text = "0"
			Me.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label3.Location = New System.Drawing.Point(3, 0)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(57, 23)
			Me.label3.TabIndex = 0
			Me.label3.Text = "X:"
			Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' cbParallelRenderMode
			' 
			Me.cbParallelRenderMode.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbParallelRenderMode.DropDownItems = 50
			Me.cbParallelRenderMode.ListProperties.CheckBoxDataMember = ""
			Me.cbParallelRenderMode.ListProperties.DataSource = Nothing
			Me.cbParallelRenderMode.ListProperties.DisplayMember = ""
			Me.cbParallelRenderMode.Location = New System.Drawing.Point(132, 202)
			Me.cbParallelRenderMode.Name = "cbParallelRenderMode"
			Me.cbParallelRenderMode.Size = New System.Drawing.Size(113, 18)
			Me.cbParallelRenderMode.TabIndex = 20
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(9, 204)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(117, 13)
			Me.label4.TabIndex = 22
			Me.label4.Tag = ""
			Me.label4.Text = "Parallel render mode:"
			Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' cbMeridianRenderMode
			' 
			Me.cbMeridianRenderMode.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbMeridianRenderMode.DropDownItems = 50
			Me.cbMeridianRenderMode.ListProperties.CheckBoxDataMember = ""
			Me.cbMeridianRenderMode.ListProperties.DataSource = Nothing
			Me.cbMeridianRenderMode.ListProperties.DisplayMember = ""
			Me.cbMeridianRenderMode.Location = New System.Drawing.Point(132, 226)
			Me.cbMeridianRenderMode.Name = "cbMeridianRenderMode"
			Me.cbMeridianRenderMode.Size = New System.Drawing.Size(113, 18)
			Me.cbMeridianRenderMode.TabIndex = 22
			' 
			' label6
			' 
			Me.label6.Location = New System.Drawing.Point(3, 228)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(123, 13)
			Me.label6.TabIndex = 24
			Me.label6.Tag = ""
			Me.label6.Text = "Meridian render mode:"
			Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(3, 252)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(123, 13)
			Me.label8.TabIndex = 26
			Me.label8.Tag = ""
			Me.label8.Text = "Label render mode:"
			Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			' 
			' cbLabelRenderMode
			' 
			Me.cbLabelRenderMode.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbLabelRenderMode.DropDownItems = 50
			Me.cbLabelRenderMode.ListProperties.CheckBoxDataMember = ""
			Me.cbLabelRenderMode.ListProperties.DataSource = Nothing
			Me.cbLabelRenderMode.ListProperties.DisplayMember = ""
			Me.cbLabelRenderMode.Location = New System.Drawing.Point(132, 250)
			Me.cbLabelRenderMode.Name = "cbLabelRenderMode"
			Me.cbLabelRenderMode.Size = New System.Drawing.Size(113, 18)
			Me.cbLabelRenderMode.TabIndex = 25
			' 
			' NMapProjectionsUC
			' 
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.cbLabelRenderMode)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.tableLayoutPanel1)
			Me.Controls.Add(Me.cbMeridianRenderMode)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.cbParallelRenderMode)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.lblZoomFactor)
			Me.Controls.Add(Me.nudSetting)
			Me.Controls.Add(Me.lblSetting)
			Me.Controls.Add(Me.zoomScrollbar)
			Me.Controls.Add(Me.cbProjection)
			Me.Controls.Add(Me.ShowDataButton)
			Me.Controls.Add(Me.label1)
			Me.Name = "NMapProjectionsUC"
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.ShowDataButton, 0)
			Me.Controls.SetChildIndex(Me.cbProjection, 0)
			Me.Controls.SetChildIndex(Me.zoomScrollbar, 0)
			Me.Controls.SetChildIndex(Me.lblSetting, 0)
			Me.Controls.SetChildIndex(Me.nudSetting, 0)
			Me.Controls.SetChildIndex(Me.lblZoomFactor, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.Controls.SetChildIndex(Me.cbParallelRenderMode, 0)
			Me.Controls.SetChildIndex(Me.label4, 0)
			Me.Controls.SetChildIndex(Me.cbMeridianRenderMode, 0)
			Me.Controls.SetChildIndex(Me.tableLayoutPanel1, 0)
			Me.Controls.SetChildIndex(Me.label6, 0)
			Me.Controls.SetChildIndex(Me.cbLabelRenderMode, 0)
			Me.Controls.SetChildIndex(Me.label8, 0)
			CType(Me.nudSetting, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tableLayoutPanel1.ResumeLayout(False)
			Me.tableLayoutPanel1.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form fields
			view.BeginInit()

			view.ViewLayout = ViewLayout.Fit
			view.Grid.Visible = False
			view.GlobalVisibility.ShowPorts = False
			view.GlobalVisibility.ShowArrowheads = False
			view.VerticalRuler.Visible = False
			view.HorizontalRuler.Visible = False

			' init document
			document.BeginInit()
			InitDocument()
			document.EndInit()

			' init form controls
			InitFormControls()

			' end view init
			view.EndInit()
		End Sub
		Protected Overrides Sub AttachToEvents()
			AddHandler document.EventSinkService.NodeMouseEnter, AddressOf EventSinkService_NodeMouseEnter
			AddHandler document.EventSinkService.NodeMouseLeave, AddressOf EventSinkService_NodeMouseLeave
			AddHandler document.MouseMove, AddressOf document_MouseMove
			MyBase.AttachToEvents()
		End Sub
		Protected Overrides Sub DetachFromEvents()
			RemoveHandler document.EventSinkService.NodeMouseEnter, AddressOf EventSinkService_NodeMouseEnter
			RemoveHandler document.EventSinkService.NodeMouseLeave, AddressOf EventSinkService_NodeMouseLeave
			RemoveHandler document.MouseMove, AddressOf document_MouseMove
			MyBase.DetachFromEvents()
		End Sub

		#End Region

		#Region "Implementation"

		Private Sub InitFormControls()
			PauseEventsHandling()

			m_bZoomWorkedOut = True
			AddHandler view.EventSinkService.TransformationsChanged, AddressOf EventSinkService_TransformationsChanged
			view.Controller.Tools.DisableTools(New String() { Nevron.Diagram.WinForm.NDWFR.ToolSelector })

			Dim zoomFactor As Single = zoomScrollbar.Value / 100.0f
			lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), zoomFactor)

			cbProjection.Items.Clear()
			cbProjection.Items.Add(New NAitoffProjection())
			cbProjection.Items.Add(New NBonneProjection())

			cbProjection.Items.Add(New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Lambert))
			cbProjection.Items.Add(New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Behrmann))
			cbProjection.Items.Add(New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.TristanEdwards))
			cbProjection.Items.Add(New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Peters))
			cbProjection.Items.Add(New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Gall))
			cbProjection.Items.Add(New NCylindricalEqualAreaProjection(CylindricalEqualAreaProjectionType.Balthasart))

			cbProjection.Items.Add(New NEckertIVProjection())
			cbProjection.Items.Add(New NEckertVIProjection())
			cbProjection.Items.Add(New NEquirectangularProjection())
			cbProjection.Items.Add(New NHammerProjection())
			cbProjection.Items.Add(New NKavrayskiyVIIProjection())
			cbProjection.Items.Add(New NMercatorProjection())
			cbProjection.Items.Add(New NMillerCylindricalProjection())
			cbProjection.Items.Add(New NMollweideProjection())
			cbProjection.Items.Add(New NOrthographicProjection())
			cbProjection.Items.Add(New NRobinsonProjection())
			cbProjection.Items.Add(New NStereographicProjection())
			cbProjection.Items.Add(New NVanDerGrintenProjection())
			cbProjection.Items.Add(New NWagnerVIProjection())
			cbProjection.Items.Add(New NWinkelTripelProjection())

			cbProjection.SelectedIndex = 16

			cbMeridianRenderMode.FillFromEnum(GetType(ArcRenderMode))
			cbMeridianRenderMode.SelectedItem = m_MapImporter.Meridians.ArcRenderMode
			AddHandler cbMeridianRenderMode.SelectedIndexChanged, AddressOf cbMeridianRenderMode_SelectedIndexChanged

			cbParallelRenderMode.FillFromEnum(GetType(ArcRenderMode))
			cbParallelRenderMode.SelectedItem = m_MapImporter.Parallels.ArcRenderMode
			AddHandler cbParallelRenderMode.SelectedIndexChanged, AddressOf cbParallelRenderMode_SelectedIndexChanged

			cbLabelRenderMode.FillFromEnum(GetType(ArcLabelRenderMode))
			cbLabelRenderMode.SelectedItem = m_MapImporter.Parallels.LabelRenderMode
			AddHandler cbLabelRenderMode.SelectedIndexChanged, AddressOf cbLabelRenderMode_SelectedIndexChanged

			ResumeEventsHandling()
		End Sub
		Private Sub InitDocument()
			document.Layers.RemoveAllChildren()
			document.Style.StrokeStyle = New NStrokeStyle(1, Color.FromArgb(68, 90, 108))
			document.RoutingManager.Enabled = False
			document.BridgeManager.Enabled = False
			document.Bounds = New NRectangleF(0, 0, 10000, 10000)
			document.BackgroundStyle.FillStyle = New NColorFillStyle(Color.LightBlue)
			CreateStyleSheets()

			m_MapImporter = New NEsriMapImporter()
			m_MapImporter.MapBounds = NMapBounds.World

'INSTANT VB NOTE: The local variable countries was renamed since Visual Basic will not uniquely identify class members when local variables have the same name:
			Dim countries_Renamed As NEsriShapefile = New NEsriShapefile(Path.Combine(Application.StartupPath, COUNTRIES))
			countries_Renamed.NameColumn = "CNTRY_NAME"
			m_MapImporter.AddLayer(countries_Renamed)

			m_MapImporter.Read()

			 m_MapImporter.ShapeCreatedListener = New NCustomShapeCreatedListener()
			m_MapImporter.Parallels.ArcRenderMode = ArcRenderMode.Normal
			m_MapImporter.Meridians.ArcRenderMode = ArcRenderMode.Normal
		End Sub
		Private Sub CreateStyleSheets()
			Dim COLORS As Color() = New Color(){ Color.Tomato, Color.PaleGreen, Color.Gold, Color.PaleGoldenrod, Color.Tan, Color.Khaki, Color.OldLace, Color.Orange }

			Dim ss1, ss2 As NStyleSheet
			Dim i As Integer, count As Integer = COLORS.Length
			i = 0
			Do While i < count
				ss1 = New NStyleSheet()
				ss1.Name = COLORS(i).Name
				ss1.Style.FillStyle = New NColorFillStyle(COLORS(i))
				document.StyleSheets.AddChild(ss1)

				ss2 = New NStyleSheet()
				ss2.Name = COLORS(i).Name & "2"
				ss2.Style.FillStyle = New NColorFillStyle(NColorF.ChangeColorBrightness(COLORS(i), -0.3f))
				document.StyleSheets.AddChild(ss2)
				i += 1
			Loop
		End Sub
		Private Sub ImportMap()
			document.Layers.RemoveAllChildren()

			' Import the map data
			m_MapImporter.Import(document, document.Bounds)
			m_Countries = CType(document.Layers.GetChildByName("countries"), NLayer)

			view.Refresh()
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub EventSinkService_NodeMouseLeave(ByVal args As NNodeViewEventArgs)
			Dim shape As NShape = TryCast(args.Node, NShape)
			If shape Is Nothing OrElse TypeOf shape Is NMapArcsShape Then
				Return
			End If

			shape.StyleSheetName = shape.StyleSheetName.Remove(shape.StyleSheetName.Length - 1)
		End Sub
		Private Sub EventSinkService_NodeMouseEnter(ByVal args As NNodeViewEventArgs)
			Dim shape As NShape = TryCast(args.Node, NShape)
			If shape Is Nothing OrElse TypeOf shape Is NMapArcsShape Then
				Return
			End If

			shape.StyleSheetName = shape.StyleSheetName & "2"
		End Sub
		Private Sub EventSinkService_TransformationsChanged(ByVal sender As Object, ByVal e As EventArgs)
			If m_bZoomWorkedOut Then
				m_bZoomWorkedOut = False
				Return
			End If

			Dim zoomFactor As Single = (view.ScaleX + view.ScaleY) / 2
			If Not lblZoomFactor.Tag Is Nothing Then
				lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), zoomFactor)
			End If

			zoomScrollbar.Value = CInt(Fix(Math.Round(zoomFactor * 100)))
		End Sub

		Private Sub ShowDataButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ShowDataButton.Click
			Dim f As Nevron.UI.WinForm.Controls.NForm = New Nevron.UI.WinForm.Controls.NForm()
			f.SuspendLayout()

			'Create the data grid view
			Dim dg As NDataGridView = New NDataGridView()
			dg.Dock = DockStyle.Fill
			dg.AllowUserToAddRows = False
			dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
			dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
			dg.RowHeadersVisible = False
			dg.ReadOnly = True
			dg.DataSource = m_MapImporter.GetLayerAt(0).DataTable
			f.Controls.Add(dg)

			'Init the form
			f.Icon = Me.Form.Icon
			f.WindowState = FormWindowState.Maximized
			f.Text = String.Format("DBF data for '{0}'", m_MapImporter.GetLayerAt(0).Name)

			f.ResumeLayout()
			f.ShowDialog()
		End Sub
		Private Sub zoomScrollbar_ValueChanged(ByVal sender As Object, ByVal e As Nevron.UI.WinForm.Controls.ScrollBarEventArgs) Handles zoomScrollbar.ValueChanged
			Dim zoomFactor As Single = (view.ScaleX + view.ScaleY) / 2
			Dim scrollFactor As Single = e.ScrollBar.Value / 100.0f
			If zoomFactor <> scrollFactor Then
				If view.ViewLayout <> ViewLayout.Normal Then
					view.ViewLayout = ViewLayout.Normal
				End If

				view.Zoom(scrollFactor)
			End If

			If Not lblZoomFactor.Tag Is Nothing Then
				lblZoomFactor.Text = String.Format(lblZoomFactor.Tag.ToString(), scrollFactor)
			End If
		End Sub
		Private Sub cbProjection_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbProjection.SelectedIndexChanged
			m_MapImporter.Projection = CType(cbProjection.SelectedItem, NMapProjection)
			If TypeOf m_MapImporter.Projection Is NOrthographicProjection Then
				lblSetting.Text = "Central Meridian:"
				nudSetting.Value = CDec((CType(m_MapImporter.Projection, NOrthographicProjection)).CentralMeridian)
				lblSetting.Visible = True
				nudSetting.Visible = True
				nudSetting.Minimum = -180
				nudSetting.Maximum = 180
			ElseIf TypeOf m_MapImporter.Projection Is NBonneProjection Then
				lblSetting.Text = "Standard Parallel:"
				nudSetting.Value = CDec((CType(m_MapImporter.Projection, NBonneProjection)).StandardParallel)
				lblSetting.Visible = True
				nudSetting.Visible = True
				nudSetting.Minimum = -90
				nudSetting.Maximum = 90
			Else
				lblSetting.Visible = False
				nudSetting.Visible = False
			End If

			zoomScrollbar.Focus()
			ImportMap()
		End Sub
		Private Sub cbParallelRenderMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim arcRenderMode As ArcRenderMode = CType((CType(sender, NComboBox)).SelectedItem, ArcRenderMode)
			m_MapImporter.Parallels.ArcRenderMode = arcRenderMode
			NMapArcsShape.Find(document, ArcType.Parallel).ArcRenderMode = arcRenderMode

			document.SmartRefreshAllViews()
		End Sub
		Private Sub cbMeridianRenderMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim arcRenderMode As ArcRenderMode = CType((CType(sender, NComboBox)).SelectedItem, ArcRenderMode)
			m_MapImporter.Meridians.ArcRenderMode = arcRenderMode
			NMapArcsShape.Find(document, ArcType.Meridian).ArcRenderMode = arcRenderMode

			document.SmartRefreshAllViews()
		End Sub
		Private Sub cbLabelRenderMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim labelRenderMode As ArcLabelRenderMode = CType(cbLabelRenderMode.SelectedItem, ArcLabelRenderMode)
			m_MapImporter.Meridians.LabelRenderMode = labelRenderMode
			m_MapImporter.Parallels.LabelRenderMode = labelRenderMode

			NMapArcsShape.Find(document, ArcType.Parallel).LabelRenderMode = labelRenderMode
			NMapArcsShape.Find(document, ArcType.Meridian).LabelRenderMode = labelRenderMode

			document.SmartRefreshAllViews()
		End Sub
		Private Sub nudSetting_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSetting.ValueChanged
			Dim nud As NNumericUpDown = CType(sender, NNumericUpDown)
			If TypeOf m_MapImporter.Projection Is NOrthographicProjection Then
				CType(m_MapImporter.Projection, NOrthographicProjection).CentralMeridian = CSng(nud.Value)
			ElseIf TypeOf m_MapImporter.Projection Is NBonneProjection Then
				CType(m_MapImporter.Projection, NBonneProjection).StandardParallel = CSng(nud.Value)
			Else
				Return
			End If

			ImportMap()
		End Sub

		Private Sub document_MouseMove(ByVal args As NNodeMouseEventArgs)
			Dim point As NPointF = args.ScenePoint
			lblX.Text = point.X.ToString()
			lblY.Text = point.Y.ToString()

			Try
				' Get the inverted point for the current projection
				point = m_MapImporter.Projection.DeprojectPoint(point)
			Catch
				lblLongitude.Text = "Not Available"
				lblLattitude.Text = "Not Available"
				Return
			End Try

			' Check if the longitude or the lattitude are out of bounds
			If point.X < -180 Then
				point.X = -180
			ElseIf point.X > 180 Then
				point.X = 180
			End If

			If point.Y < -90 Then
				point.Y = -90
			ElseIf point.Y > 90 Then
				point.Y = 90
			End If

			lblLongitude.Text = point.X.ToString("F3")
			lblLattitude.Text = point.Y.ToString("F3")
		End Sub

		#End Region

		#Region "Designer Fields"

		Private WithEvents ShowDataButton As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents cbProjection As Nevron.UI.WinForm.Controls.NComboBox
		Private WithEvents zoomScrollbar As Nevron.UI.WinForm.Controls.NHScrollBar
		Private WithEvents nudSetting As Nevron.UI.WinForm.Controls.NNumericUpDown
		Private label1 As Label
		Private label4 As Label
		Private label6 As Label
		Private lblZoomFactor As Label
		Private lblSetting As Label
		Private cbParallelRenderMode As NComboBox
		Private cbMeridianRenderMode As NComboBox
		Private label8 As Label
		Private cbLabelRenderMode As NComboBox

		#End Region

		#Region "Fields"

		Private m_MapImporter As NEsriMapImporter
		Private m_bZoomWorkedOut As Boolean
		Private label2 As Label
		Private tableLayoutPanel1 As TableLayoutPanel
		Private lblLattitude As Label
		Private label9 As Label
		Private lblLongitude As Label
		Private label7 As Label
		Private lblY As Label
		Private label5 As Label
		Private lblX As Label
		Private label3 As Label
		Private m_Countries As NLayer

		#End Region

		#Region "Constants"

		Private Const COUNTRIES As String = "..\..\Resources\Maps\countries.shp"

		#End Region

		#Region "Nested Types"

		Private Class NCustomShapeCreatedListener
			Inherits NShapeCreatedListener
			#Region "Constructors"

			Public Sub New()
			End Sub

			#End Region

			#Region "INShapeCreatedListener"

			Public Overrides Function OnPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Dim shape As NShape = TryCast(element, NShape)
				If shape Is Nothing Then
					Return True
				End If

				Dim name As String = mapFeature.GetAttributeValue("CNTRY_NAME").ToString()
				Dim population As Single = Single.Parse(mapFeature.GetAttributeValue("POP_CNTRY").ToString())
				Dim landArea As Single = Single.Parse(mapFeature.GetAttributeValue("SQKM").ToString())
				Dim interactivityStyle As NInteractivityStyle = New NInteractivityStyle(String.Format("{1}{0}======================{0}Land Area: {2:N} km2{0}Population: {3:N0} people{0}Pop. Density: {4:N} people/km2", Environment.NewLine, name, landArea, population, population / landArea))
				shape.Style.InteractivityStyle = interactivityStyle

				Dim colorIndex As Integer = Integer.Parse(mapFeature.GetAttributeValue("COLOR_MAP").ToString()) - 1
				shape.StyleSheetName = COLORS(colorIndex)

				Return True
			End Function
			Public Overrides Function OnMultiPolygonCreated(ByVal element As NDiagramElement, ByVal mapFeature As NMapFeature) As Boolean
				Return OnPolygonCreated(element, mapFeature)
			End Function

			#End Region

			#Region "Static"

			Private Shared ReadOnly TEXT_SIZE As NSizeF = New NSizeF(150, 30)
			Private Shared ReadOnly COLORS As String() = New String(){ "Tomato", "PaleGreen", "Gold", "PaleGoldenrod", "Tan", "Khaki", "OldLace", "Orange" }

			#End Region
		End Class

		#End Region
	End Class
End Namespace