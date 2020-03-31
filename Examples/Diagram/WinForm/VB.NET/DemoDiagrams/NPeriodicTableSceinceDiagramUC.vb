Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports Nevron.GraphicsCore
Imports Nevron.Editors
Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.WinForm

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NPeriodicTableSceinceDiagramUC.
	''' </summary>
	Public Class NPeriodicTableSceinceDiagramUC
		Inherits NDiagramExampleUC
		#Region "Constructor"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			InitializeComponent()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.SuspendLayout()
			' 
			' commonControlsPanel
			' 
			Me.commonControlsPanel.Location = New System.Drawing.Point(0, 304)
			Me.commonControlsPanel.Name = "commonControlsPanel"
			Me.commonControlsPanel.Size = New System.Drawing.Size(248, 80)
			' 
			' NPeriodicTableSceinceDiagramUC
			' 
			Me.Name = "NPeriodicTableSceinceDiagramUC"
			Me.Size = New System.Drawing.Size(248, 384)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "NDiagramExampleUC Overrides"

		Protected Overrides Sub LoadExample()
			' init form feilds
			fsNonMetals = New NColorFillStyle(Color.FromArgb(236, 97, 49))
			fsMetals = New NColorFillStyle(Color.FromArgb(68, 90, 108))
			fsMatalloids = New NColorFillStyle(Color.FromArgb(129, 133, 133))
			fsGases = New NColorFillStyle(Color.FromArgb(247, 150, 56))
			feMoccasin = New NColorFillStyle(Color.FromArgb(252, 218, 196))
			feGold = New NColorFillStyle(Color.Gold)
			feTransitionMetals = New NColorFillStyle(Color.Pink)

			' begin view init
			view.BeginInit()

			view.GlobalVisibility.ShowPorts = False
			view.Grid.Visible = False
			view.ViewLayout = ViewLayout.Fit
			view.HorizontalRuler.Visible = False
			view.VerticalRuler.Visible = False
			view.DocumentPadding = New Nevron.Diagram.NMargins(10)

			document.BeginInit()
			InitDocument()
			document.EndInit()

			' end view init
			view.EndInit()
		End Sub


		#End Region

		#Region "Implementation"

		Private Sub InitDocument()
			' setup document background
			Dim imageFrame As NImageFrameStyle = New NImageFrameStyle()
			imageFrame.Type = ImageFrameType.RoundedTop
			imageFrame.FillStyle = New NGradientFillStyle(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(166, 166, 166), Color.FromArgb(211, 211, 211))
			imageFrame.ShadowStyle.Type = ShadowType.GaussianBlur
			imageFrame.BackgroundColor = view.WindowBackColor ' in order for shadow to blend nicely use the same backcolor
			document.BackgroundStyle.FrameStyle = imageFrame

			CreateElements()
			CreateLabels()
			CreateLegend()
		End Sub

		Private Sub CreateElements()
			Dim element As NShape = Nothing

			document.Style.TextStyle.TextFormat = TextFormat.XML

			' 1
			element = CreateElementShape(1, 1)

			element.Text = GetXMLText(1, "H", "1.01")
			element.Style.FillStyle = (TryCast(fsNonMetals.Clone(), NFillStyle))
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 1)
			element.Text = GetXMLText(2, "He", "4.00")
			element.Style.FillStyle = TryCast(fsGases.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 2
			element = CreateElementShape(1, 2)
			element.Text = GetXMLText(3, "Li", "6.94")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(2, 2)
			element.Text = GetXMLText(4, "Be", "9.01")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(13, 2)
			element.Text = GetXMLText(5, "B", "10.81")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(14, 2)
			element.Text = GetXMLText(6, "C", "12.01")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(15, 2)
			element.Text = GetXMLText(7, "N", "14.01")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(16, 2)
			element.Text = GetXMLText(8, "O", "15.99")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(17, 2)
			element.Text = GetXMLText(9, "F", "19.00")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 2)
			element.Text = GetXMLText(10, "Ne", "20.18")
			element.Style.FillStyle = TryCast(fsGases.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 3
			element = CreateElementShape(1, 3)
			element.Text = GetXMLText(11, "Na", "22.99")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(2, 3)
			element.Text = GetXMLText(12, "Mg", "25.31")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(13, 3)
			element.Text = GetXMLText(13, "Al", "26.98")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(14, 3)
			element.Text = GetXMLText(14, "Si", "28.09")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(15, 3)
			element.Text = GetXMLText(15, "P", "30.97")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(16, 3)
			element.Text = GetXMLText(16, "S", "32.07")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(17, 3)
			element.Text = GetXMLText(17, "Cl", "35.45")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 3)
			element.Text = GetXMLText(18, "Ar", "39.95")
			element.Style.FillStyle = TryCast(fsGases.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 4
			element = CreateElementShape(1, 4)
			element.Text = GetXMLText(19, "K", "39.10")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(2, 4)
			element.Text = GetXMLText(20, "Ca", "40.08")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(3, 4)
			element.Text = GetXMLText(21, "Sc", "44.96")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(4, 4)
			element.Text = GetXMLText(22, "Ti", "47.87")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(5, 4)
			element.Text = GetXMLText(23, "V", "50.94")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(6, 4)
			element.Text = GetXMLText(24, "Cr", "52.00")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(7, 4)
			element.Text = GetXMLText(25, "Mn", "54.94")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(8, 4)
			element.Text = GetXMLText(26, "Fe", "55.85")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(9, 4)
			element.Text = GetXMLText(27, "Co", "58.93")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(10, 4)
			element.Text = GetXMLText(28, "Ni", "58.69")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(11, 4)
			element.Text = GetXMLText(29, "Cu", "63.55")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(12, 4)
			element.Text = GetXMLText(30, "Zn", "65.41")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(13, 4)
			element.Text = GetXMLText(31, "Ga", "69.72")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(14, 4)
			element.Text = GetXMLText(32, "Ge", "72.64")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(15, 4)
			element.Text = GetXMLText(33, "As", "74.92")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(16, 4)
			element.Text = GetXMLText(34, "Se", "78.96")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(17, 4)
			element.Text = GetXMLText(35, "Br", "79.90")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 4)
			element.Text = GetXMLText(36, "Kr", "83.80")
			element.Style.FillStyle = TryCast(fsGases.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 5
			element = CreateElementShape(1, 5)
			element.Text = GetXMLText(37, "Rb", "85.47")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(2, 5)
			element.Text = GetXMLText(38, "Sr", "87.62")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(3, 5)
			element.Text = GetXMLText(39, "Y", "88.91")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(4, 5)
			element.Text = GetXMLText(40, "Zr", "91.22")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(5, 5)
			element.Text = GetXMLText(41, "Nb", "92.91")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(6, 5)
			element.Text = GetXMLText(42, "Mo", "95.94")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(7, 5)
			element.Text = GetXMLText(43, "Tc", "(98)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(8, 5)
			element.Text = GetXMLText(44, "Ru", "101.07")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(9, 5)
			element.Text = GetXMLText(45, "Rh", "102.91")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(10, 5)
			element.Text = GetXMLText(46, "Pd", "106.42")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(11, 5)
			element.Text = GetXMLText(47, "Ag", "107.87")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(12, 5)
			element.Text = GetXMLText(48, "Cd", "112.41")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(13, 5)
			element.Text = GetXMLText(49, "In", "114.82")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(14, 5)
			element.Text = GetXMLText(50, "Sn", "118.71")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(15, 5)
			element.Text = GetXMLText(51, "Sb", "121.76")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(16, 5)
			element.Text = GetXMLText(52, "Te", "127.60")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(17, 5)
			element.Text = GetXMLText(53, "I", "126.90")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 5)
			element.Text = GetXMLText(54, "Xe", "131.29")
			element.Style.FillStyle = TryCast(fsGases.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 6
			element = CreateElementShape(1, 6)
			element.Text = GetXMLText(55, "Cs", "132.91")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(2, 6)
			element.Text = GetXMLText(56, "Ba", "137.33")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(3, 6)
			element.Text = GetXMLText(57, "*La", "138.91")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(4, 6)
			element.Text = GetXMLText(72, "Hf", "178.49")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(5, 6)
			element.Text = GetXMLText(73, "Ta", "180.95")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(6, 6)
			element.Text = GetXMLText(74, "W", "183.84")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(7, 6)
			element.Text = GetXMLText(75, "Re", "186.21")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(8, 6)
			element.Text = GetXMLText(76, "Os", "190.23")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(9, 6)
			element.Text = GetXMLText(77, "Ir", "192.22")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(10, 6)
			element.Text = GetXMLText(78, "Pt", "195.08")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(11, 6)
			element.Text = GetXMLText(79, "Au", "196.97")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(12, 6)
			element.Text = GetXMLText(80, "Hg", "200.59")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(13, 6)
			element.Text = GetXMLText(81, "Tl", "204.38")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(14, 6)
			element.Text = GetXMLText(82, "Pb", "207.2")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(15, 6)
			element.Text = GetXMLText(83, "Bi", "208.98")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(16, 6)
			element.Text = GetXMLText(84, "Po", "(209)")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(17, 6)
			element.Text = GetXMLText(85, "At", "(210)")
			element.Style.FillStyle = TryCast(fsMatalloids.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 6)
			element.Text = GetXMLText(86, "Rn", "(222)")
			element.Style.FillStyle = TryCast(fsGases.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 7
			element = CreateElementShape(1, 7)
			element.Text = GetXMLText(87, "Fr", "(223)")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(2, 7)
			element.Text = GetXMLText(88, "Ra", "(226)")
			element.Style.FillStyle = TryCast(fsMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(3, 7)
			element.Text = GetXMLText(89, "*Ac", "(227)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(4, 7)
			element.Text = GetXMLText(104, "Rf", "(261)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(5, 7)
			element.Text = GetXMLText(105, "Db", "(262)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(6, 7)
			element.Text = GetXMLText(106, "Sg", "(266)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(7, 7)
			element.Text = GetXMLText(107, "Bh", "(264)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(8, 7)
			element.Text = GetXMLText(108, "Hs", "(270)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(9, 7)
			element.Text = GetXMLText(109, "Mt", "(268)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(10, 7)
			element.Text = GetXMLText(110, "Ds", "(281)")
			element.Style.FillStyle = TryCast(fsNonMetals.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 9
			element = CreateElementShape(5, 9)
			element.Text = GetXMLText(58, "Ce", "140.12")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(6, 9)
			element.Text = GetXMLText(59, "Pr", "140.91")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(7, 9)
			element.Text = GetXMLText(60, "Nd", "144.24")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(8, 9)
			element.Text = GetXMLText(61, "Pm", "(145)")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(9, 9)
			element.Text = GetXMLText(62, "Sm", "150.36")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(10, 9)
			element.Text = GetXMLText(63, "Eu", "151.97")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(11, 9)
			element.Text = GetXMLText(64, "Gd", "157.25")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(12, 9)
			element.Text = GetXMLText(65, "Tb", "158.93")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(13, 9)
			element.Text = GetXMLText(66, "Dy", "162.50")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(14, 9)
			element.Text = GetXMLText(67, "Ho", "164.93")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(15, 9)
			element.Text = GetXMLText(68, "Er", "167.26")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(16, 9)
			element.Text = GetXMLText(69, "Tm", "168.93")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(17, 9)
			element.Text = GetXMLText(70, "Yb", "173.04")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 9)
			element.Text = GetXMLText(71, "Lu", "174.97")
			element.Style.FillStyle = TryCast(feMoccasin.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			' 10
			element = CreateElementShape(5, 10)
			element.Text = GetXMLText(90, "Th", "232.04")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(6, 10)
			element.Text = GetXMLText(91, "Pa", "231.04")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(7, 10)
			element.Text = GetXMLText(92, "U", "238.03")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(8, 10)
			element.Text = GetXMLText(93, "Np", "(237)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(9, 10)
			element.Text = GetXMLText(94, "Pu", "(244)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(10, 10)
			element.Text = GetXMLText(95, "Am", "(243)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(11, 10)
			element.Text = GetXMLText(96, "Cm", "(247)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(12, 10)
			element.Text = GetXMLText(97, "Bk", "(247)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(13, 10)
			element.Text = GetXMLText(98, "Cf", "(251)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(14, 10)
			element.Text = GetXMLText(99, "Es", "(252)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(15, 10)
			element.Text = GetXMLText(100, "Fm", "(257)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(16, 10)
			element.Text = GetXMLText(101, "Md", "(258)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(17, 10)
			element.Text = GetXMLText(102, "No", "(259)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

			element = CreateElementShape(18, 10)
			element.Text = GetXMLText(103, "Lr", "(262)")
			element.Style.FillStyle = TryCast(feGold.Clone(), NFillStyle)
			document.ActiveLayer.AddChild(element)

		End Sub

		Private Sub CreateLabels()
			Dim bounds As NRectangleF

			' title
			bounds = Me.GetElementBounds(2, 1)
			bounds.Width = 16 * bounds.Width
			Dim text As NTextShape = New NTextShape("Periodic Table of the Elements", bounds)
			text.Style.TextStyle = New NTextStyle(New Font("Times New Roman", 24, FontStyle.Bold))
			document.ActiveLayer.AddChild(text)

			' Lanthanide Series
			bounds = Me.GetElementBounds(1, 9)
			bounds.Width = 4 * bounds.Width
			text = New NTextShape("* Lanthanide Series:", bounds)
			text.Style.TextStyle = New NTextStyle(New Font("Times New Roman", 12, FontStyle.Bold Or FontStyle.Italic))
			text.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
			document.ActiveLayer.AddChild(text)

			' Actinide Series
			bounds = Me.GetElementBounds(1, 10)
			bounds.Width = 4 * bounds.Width
			text = New NTextShape("* Actinide Series::", bounds)
			text.Style.TextStyle = New NTextStyle(New Font("Times New Roman", 12, FontStyle.Bold Or FontStyle.Italic))
			text.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right
			document.ActiveLayer.AddChild(text)
		End Sub

		Private Sub CreateLegend()
			Dim legend As NGroup = New NGroup()
			Dim item As NCompositeShape = Nothing

			Dim ledendBackground As NRectangleShape = New NRectangleShape(0, 0, 1, 5)
			ledendBackground.Style.FillStyle = New NColorFillStyle(Color.White)
			legend.Shapes.AddChild(ledendBackground)

			item = CreateLegendItem(New NRectangleF(0.1f, 0.1f, 0.8f, 0.8f), "Metals", fsMetals)
			legend.Shapes.AddChild(item)

			item = CreateLegendItem(New NRectangleF(0.1f, 1.1f, 0.8f, 0.8f), "Metalloids", fsMatalloids)
			legend.Shapes.AddChild(item)

			item = CreateLegendItem(New NRectangleF(0.1f, 2.1f, 0.8f, 0.8f), "Non-metals", fsNonMetals)
			legend.Shapes.AddChild(item)

			item = CreateLegendItem(New NRectangleF(0.1f, 3.1f, 0.8f, 0.8f), "Transition Metals", feTransitionMetals)
			legend.Shapes.AddChild(item)

			item = CreateLegendItem(New NRectangleF(0.1f, 4.1f, 0.8f, 0.8f), "Gases", fsGases)
			legend.Shapes.AddChild(item)

			legend.UpdateModelBounds()

			Dim bounds As NRectangleF = Me.GetElementBounds(13, 7)
			bounds.Y = bounds.Y + bounds.Height * 0.1f
			bounds.Width = bounds.Width * 5
			bounds.Height = bounds.Height * 1.8f
			legend.Bounds = bounds

			document.ActiveLayer.AddChild(legend)
		End Sub


		Protected Function CreateElementShape(ByVal col As Integer, ByVal row As Integer) As NShape
			Return New NRectangleShape(GetElementBounds(col, row))
		End Function

		Protected Function CreateLegendItem(ByVal bounds As NRectangleF, ByVal str As String, ByVal fillStyle As NFillStyle) As NCompositeShape
			Dim item As NCompositeShape = New NCompositeShape()

			Dim rect As NRectanglePath = New NRectanglePath(0, 0, 2, 2)
			NStyle.SetFillStyle(rect, (TryCast(fillStyle.Clone(), NFillStyle)))
			item.Primitives.AddChild(rect)

			Dim text As NTextPrimitive = New NTextPrimitive(str, New NRectangleF(2, 0, 4, 2))
			item.Primitives.AddChild(text)

			item.UpdateModelBounds()
			item.Bounds = bounds
			Return item
		End Function


		Protected Function GetXMLText(ByVal number As Integer, ByVal initial As String, ByVal weight As String) As String
			Dim str As String = number.ToString()
			Dim size As NSizeF = New NSizeF(10, 15)
			str &= "<br/><font size='14'><b>" & initial & "</b></font><br/>"
			str &= weight
			Return str
		End Function

		Protected Function GetElementBounds(ByVal column As Integer, ByVal row As Integer) As NRectangleF
			Dim size As NSizeF = New NSizeF(45, 80)
			Dim origin As NPointF = New NPointF(45, 45)

			Dim x As Single = origin.X + (column - 1) * size.Width
			Dim y As Single = origin.Y + (row - 1) * size.Height

			Return New NRectangleF(x, y, size.Width, size.Height)
		End Function


		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing

		#End Region

		#Region "Fields"

		Private fsNonMetals As NFillStyle
		Private fsMetals As NFillStyle
		Private fsMatalloids As NFillStyle
		Private fsGases As NFillStyle
		Private feMoccasin As NFillStyle
		Private feGold As NFillStyle
		Private feTransitionMetals As NFillStyle

		#End Region
	End Class
End Namespace
