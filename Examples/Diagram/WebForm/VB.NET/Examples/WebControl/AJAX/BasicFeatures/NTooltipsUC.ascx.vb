Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms

Imports Nevron.Dom
Imports Nevron.Diagram
Imports Nevron.Diagram.Shapes
Imports Nevron.Diagram.Batches
Imports Nevron.Diagram.WebForm
Imports Nevron.UI.WebForm.Controls
Imports Nevron.GraphicsCore

Namespace Nevron.Examples.Diagram.Webform
	''' <summary>
	'''		Summary description for NMouseEvents.
	''' </summary>
	Public Partial Class NTooltipsUC
		Inherits NDiagramExampleUC
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			If NDrawingView1.RequiresInitialization Then
				Dim document As NDrawingDocument = NDrawingView1.Document

				' begin view init
				NDrawingView1.GlobalVisibility.ShowPorts = False
				NDrawingView1.ViewLayout = CanvasLayout.Normal
				NDrawingView1.ScaleX = 0.6f
				NDrawingView1.ScaleY = 0.6f
				NDrawingView1.ViewportOrigin = New NPointF()
				NDrawingView1.Document.GraphicsSettings.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

				' init document
				document.HistoryService.Stop()
				document.BeginInit()

				' create the scene
				CreateElements(document)
				CreateLabels(document)

				' remove the standard frame
				NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = False

				document.EndInit()
			End If
		End Sub

		Protected Sub NDrawingView1_QueryAjaxTools(ByVal sender As Object, ByVal e As EventArgs)
			'	configure the client side tools
			NDrawingView1.AjaxTools.Add(New NAjaxTooltipTool(True))
		End Sub

		#Region "Nested Classes"

		Public Class NChemicalElement
			Public Sub New(ByVal number As Integer, ByVal symbol As String, ByVal weight As String, ByVal col As Integer, ByVal row As Integer, ByVal fillStyle As NFillStyle, ByVal tooltip As String)
				Me.number = number
				Me.symbol = symbol
				Me.weight = weight
				Me.col = col
				Me.row = row
				Me.fillStyle = fillStyle
				Me.tooltip = tooltip
			End Sub

			Public number As Integer
			Public symbol As String
			Public weight As String
			Public col As Integer
			Public row As Integer
			Public fillStyle As NFillStyle
			Public tooltip As String
		End Class

		#End Region

		#Region "Implementation"

		Protected Sub CreateElements(ByVal document As NDrawingDocument)
			document.Style.TextStyle.TextFormat = TextFormat.XML

				' row 1
				' row 2
				' row 3
				' row 4
				' row 5
				' row 6
				' row 7
				' row 8
				' row 9
				' row 10
			Dim elements As NChemicalElement() = { New NChemicalElement(1, "H", "1.01", 1, 1, fsNonMetals, "Hydrogen (H)"), New NChemicalElement(2, "He", "4.00", 18, 1, fsGases, "Helium (He)"), New NChemicalElement(3, "Li", "6.94", 1, 2, fsMetals, "Lithium (Li)"), New NChemicalElement(4, "Be", "9.01", 2, 2, fsMetals, "Beryllium (Be)"), New NChemicalElement(5, "B", "10.81", 13, 2, fsNonMetals, "Boron (B)"), New NChemicalElement(6, "C", "12.01", 14, 2, fsNonMetals, "Carbon (C)"), New NChemicalElement(7, "N", "14.01", 15, 2, fsNonMetals, "Nitrogen (N)"), New NChemicalElement(8, "O", "15.99", 16, 2, fsNonMetals, "Oxygen (O)"), New NChemicalElement(9, "F", "19.00", 17, 2, fsNonMetals, "Fluorine (F)"), New NChemicalElement(10, "Ne", "20.18", 18, 2, fsGases, "Neon (Ne)"), New NChemicalElement(11, "Na", "22.99", 1, 3, fsMetals, "Sodium (Na)"), New NChemicalElement(12, "Mg", "25.31", 2, 3, fsMetals, "Magnesium (Mg)"), New NChemicalElement(13, "Al", "26.98", 13, 3, fsMetals, "Aluminum (Al)"), New NChemicalElement(14, "Si", "28.09", 14, 3, fsMatalloids, "Silicon (Si)"), New NChemicalElement(15, "P", "30.97", 15, 3, fsMatalloids, "Phosphorus (P)"), New NChemicalElement(16, "S", "32.07", 16, 3, fsNonMetals, "Sulfur (S)"), New NChemicalElement(17, "Cl", "35.45", 17, 3, fsNonMetals, "Chlorine (Cl)"), New NChemicalElement(18, "Ar", "39.95", 18, 3, fsGases, "Argon (Ar)"), New NChemicalElement(19, "K", "39.10", 1, 4, fsMetals, "Potassium (K)"), New NChemicalElement(20, "Ca", "40.08", 2, 4, fsMetals, "Calcium (Ca)"), New NChemicalElement(21, "Sc", "44.96", 3, 4, feCentralGroup, "Scandium (Sc)"), New NChemicalElement(22, "Ti", "47.87", 4, 4, feCentralGroup, "Titanium (Ti)"), New NChemicalElement(23, "V", "50.94", 5, 4, feCentralGroup, "Vanadium (V)"), New NChemicalElement(24, "Cr", "52.00", 6, 4, feCentralGroup, "Chromium (Cr"), New NChemicalElement(25, "Mn", "54.94", 7, 4, feCentralGroup, "Manganese (Mn)"), New NChemicalElement(26, "Fe", "55.85", 8, 4, feCentralGroup, "Iron (Fe)"), New NChemicalElement(27, "Co", "58.93", 9, 4, feCentralGroup, "Cobalt (Co)"), New NChemicalElement(28, "Ni", "58.69", 10, 4, feCentralGroup, "Nickel (Ni)"), New NChemicalElement(29, "Cu", "63.55", 11, 4, feCentralGroup, "Copper (Cu)"), New NChemicalElement(30, "Zn", "65.41", 12, 4, feCentralGroup, "Zinc (Zn)"), New NChemicalElement(31, "Ga", "69.72", 13, 4, fsMetals, "Gallium (Ga)"), New NChemicalElement(32, "Ge", "72.64", 14, 4, fsMatalloids, "Germanium (Ge)"), New NChemicalElement(33, "As", "74.92", 15, 4, fsMatalloids, "Arsenic (As)"), New NChemicalElement(34, "Se", "78.96", 16, 4, fsNonMetals, "Selenium (Se)"), New NChemicalElement(35, "Br", "79.90", 17, 4, fsNonMetals, "Bromine (Br)"), New NChemicalElement(36, "Kr", "83.80", 18, 4, fsGases, "Krypton (Kr)"), New NChemicalElement(37, "Rb", "85.47", 1, 5, fsMetals, "Rubidium (Rb)"), New NChemicalElement(38, "Sr", "87.62", 2, 5, fsMetals, "Strontium (Sr)"), New NChemicalElement(39, "Y", "88.91", 3, 5, feCentralGroup, "Yttrium (Y)"), New NChemicalElement(40, "Zr", "91.22", 4, 5, feCentralGroup, "Zirconium (Zr)"), New NChemicalElement(41, "Nb", "92.91", 5, 5, feCentralGroup, "Niobium (Nb)"), New NChemicalElement(42, "Mo", "95.94", 6, 5, feCentralGroup, "Molybdenum (Mo)"), New NChemicalElement(43, "Tc", "(98)", 7, 5, feCentralGroup, "Technetium (Tc)"), New NChemicalElement(44, "Ru", "101.07", 8, 5, feCentralGroup, "Ruthenium (Ru)"), New NChemicalElement(45, "Rh", "102.91", 9, 5, feCentralGroup, "Rhodium (Rh)"), New NChemicalElement(46, "Pd", "106.42", 10, 5, feCentralGroup, "Palladium (Pd)"), New NChemicalElement(47, "Ag", "107.87", 11, 5, feCentralGroup, "Silver (Ag)"), New NChemicalElement(48, "Cd", "112.41", 12, 5, feCentralGroup, "Cadmium (Cd)"), New NChemicalElement(49, "In", "114.82", 13, 5, fsMetals, "Indium (In)"), New NChemicalElement(50, "Sn", "118.71", 14, 5, fsMetals, "Tin (Sn)"), New NChemicalElement(51, "Sb", "121.76", 15, 5, fsMatalloids, "Antimony (Sb)"), New NChemicalElement(52, "Te", "127.60", 16, 5, fsMatalloids, "Tellurium (Te)"), New NChemicalElement(53, "I", "126.90", 17, 5, fsNonMetals, "Iodine (I)"), New NChemicalElement(54, "Xe", "131.29", 18, 5, fsGases, "Xenon (Xe)"), New NChemicalElement(55, "Cs", "132.91", 1, 6, fsMetals, "Cesium (Cs)"), New NChemicalElement(56, "Ba", "137.33", 2, 6, fsMetals, "Barium (Ba)"), New NChemicalElement(57, "*La", "138.91", 3, 6, feCentralGroup, "Lanthanum (La)"), New NChemicalElement(72, "Hf", "178.49", 4, 6, feCentralGroup, "Hafnium (Hf)"), New NChemicalElement(73, "Ta", "180.95", 5, 6, feCentralGroup, "Tantalum (Ta)"), New NChemicalElement(74, "W", "183.84", 6, 6, feCentralGroup, "Tungsten (W)"), New NChemicalElement(75, "Re", "186.21", 7, 6, feCentralGroup, "Rhenium (Re)"), New NChemicalElement(76, "Os", "190.23", 8, 6, feCentralGroup, "Osmium (Os)"), New NChemicalElement(77, "Ir", "192.22", 9, 6, feCentralGroup, "Iridium (Ir)"), New NChemicalElement(78, "Pt", "195.08", 10, 6, feCentralGroup, "Platinum (Pt)"), New NChemicalElement(79, "Au", "196.97", 11, 6, feCentralGroup, "Gold (Au)"), New NChemicalElement(80, "Hg", "200.59", 12, 6, feCentralGroup, "Mercury (Hg)"), New NChemicalElement(81, "Tl", "204.38", 13, 6, fsMetals, "Thallium (Tl)"), New NChemicalElement(82, "Pb", "207.2", 14, 6, fsMetals, "Lead (Pb)"), New NChemicalElement(83, "Bi", "208.98", 15, 6, fsMetals, "Bismuth (Bi)"), New NChemicalElement(84, "Po", "(209)", 16, 6, fsMetals, "Polonium (Po)"), New NChemicalElement(85, "At", "(210)", 17, 6, fsNonMetals, "Astatine (At)"), New NChemicalElement(86, "Rn", "(222)", 18, 6, fsGases, "Radon (Rn)"), New NChemicalElement(87, "Fr", "(223)", 1, 7, fsMetals, "Francium (Fr)"), New NChemicalElement(88, "Ra", "(226)", 2, 7, fsMetals, "Radium (Ra)"), New NChemicalElement(89, "*Ac", "(227)", 3, 7, feCentralGroup, "Actinium (Ac)"), New NChemicalElement(104, "Rf", "(261)", 4, 7, feCentralGroup, "Rutherfordium (Rf)"), New NChemicalElement(105, "Db", "(262)", 5, 7, feCentralGroup, "Dubnium (Db)"), New NChemicalElement(106, "Sg", "(266)", 6, 7, feCentralGroup, "Seaborgium (Sg)"), New NChemicalElement(107, "Bh", "(264)", 7, 7, feCentralGroup, "Bohrium (Bh)"), New NChemicalElement(108, "Hs", "(270)", 8, 7, feCentralGroup, "Hassium (Hs)"), New NChemicalElement(109, "Mt", "(268)", 9, 7, feCentralGroup, "Meitnerium (Mt)"), New NChemicalElement(110, "Ds", "(281)", 10, 7, feCentralGroup, "Darmstadtium (Ds)"), New NChemicalElement(111, "Rg", "(272)", 11, 7, feCentralGroup, "Roentgenium (Rg)"), New NChemicalElement(58, "Ce", "140.12", 5, 9, feMoccasin, "Cerium (Ce)"), New NChemicalElement(59, "Pr", "140.91", 6, 9, feMoccasin, "Praseodymium (Pr)"), New NChemicalElement(60, "Nd", "144.24", 7, 9, feMoccasin, "Neodymium (Nd)"), New NChemicalElement(61, "Pm", "(145)", 8, 9, feMoccasin, "Promethium (Pm)"), New NChemicalElement(62, "Sm", "150.36", 9, 9, feMoccasin, "Samarium (Sm)"), New NChemicalElement(63, "Eu", "151.97", 10, 9, feMoccasin, "Europium (Eu)"), New NChemicalElement(64, "Gd", "157.25", 11, 9, feMoccasin, "Gadolinium (Gd)"), New NChemicalElement(65, "Tb", "158.93", 12, 9, feMoccasin, "Terbium (Tb)"), New NChemicalElement(66, "Dy", "162.50", 13, 9, feMoccasin, "Dysprosium (Dy)"), New NChemicalElement(67, "Ho", "164.93", 14, 9, feMoccasin, "Holmium (Ho)"), New NChemicalElement(68, "Er", "167.26", 15, 9, feMoccasin, "Erbium (Er)"), New NChemicalElement(69, "Tm", "168.93", 16, 9, feMoccasin, "Thulium (Tm)"), New NChemicalElement(70, "Yb", "173.04", 17, 9, feMoccasin, "Ytterbium (Yb)"), New NChemicalElement(71, "Lu", "174.97", 18, 9, feMoccasin, "Lutetium (Lu)"), New NChemicalElement(90, "Th", "232.04", 5, 10, feGold, "Thorium (Th)"), New NChemicalElement(91, "Pa", "231.04", 6, 10, feGold, "Protactinium (Pa)"), New NChemicalElement(92, "U", "238.03", 7, 10, feGold, "Uranium (U)"), New NChemicalElement(93, "Np", "(237)", 8, 10, feGold, "Neptunium (Np)"), New NChemicalElement(94, "Pu", "(244)", 9, 10, feGold, "Plutonium (Pu)"), New NChemicalElement(95, "Am", "(243)", 10, 10, feGold, "Americium (Am)"), New NChemicalElement(96, "Cm", "(247)", 11, 10, feGold, "Curium (Cm)"), New NChemicalElement(97, "Bk", "(247)", 12, 10, feGold, "Berkelium (Bk)"), New NChemicalElement(98, "Cf", "(251)", 13, 10, feGold, "Californium (Cf)"), New NChemicalElement(99, "Es", "(252)", 14, 10, feGold, "Einsteinium (Es)"), New NChemicalElement(100, "Fm", "(257)", 15, 10, feGold, "Fermium (Fm)"), New NChemicalElement(101, "Md", "(258)", 16, 10, feGold, "Mendelevium (Md)"), New NChemicalElement(102, "No", "(259)", 17, 10, feGold, "Nobelium (No)"), New NChemicalElement(103, "Lr", "(262)", 18, 10, feGold, "Lawrencium (Lr)") }

			Dim length As Integer = elements.Length
			Dim i As Integer = 0
			Do While i < length
				AddElement(document, elements(i))
				i += 1
			Loop
		End Sub

		Protected Sub CreateLabels(ByVal document As NDrawingDocument)
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

		Protected Sub AddElement(ByVal document As NDrawingDocument, ByVal ce As NChemicalElement)
			Dim str As String = ce.number.ToString()
			Dim size As NSizeF = New NSizeF(10, 15)
			str &= "<br/><font size='14'><b>" & ce.symbol & "</b></font><br/>"
			str &= ce.weight

			Dim element As NShape = Nothing
			element = New NRectangleShape(GetElementBounds(ce.col, ce.row))
			element.Text = str
			element.Style.InteractivityStyle = New NInteractivityStyle(True, Nothing, ce.tooltip)
			element.Style.FillStyle = ce.fillStyle
			document.ActiveLayer.AddChild(element)
		End Sub

		Protected Function GetElementBounds(ByVal column As Integer, ByVal row As Integer) As NRectangleF
			Dim size As NSizeF = New NSizeF(45, 80)
			Dim origin As NPointF = New NPointF(45, 45)

			Dim x As Single = origin.X + (column - 1) * size.Width
			Dim y As Single = origin.Y + (row - 1) * size.Height

			Return New NRectangleF(x, y, size.Width, size.Height)
		End Function

		#End Region

		#Region "Fields"

		Private fsNonMetals As NFillStyle = New NColorFillStyle(Color.FromArgb(205, 153, 255))
		Private fsMetals As NFillStyle = New NColorFillStyle(Color.FromArgb(155, 207, 255))
		Private fsMatalloids As NFillStyle = New NColorFillStyle(Color.FromArgb(48, 198, 187))
		Private fsGases As NFillStyle = New NColorFillStyle(Color.FromArgb(153, 198, 17))
		Private feMoccasin As NFillStyle = New NColorFillStyle(Color.FromArgb(255, 204, 157))
		Private feGold As NFillStyle = New NColorFillStyle(Color.FromArgb(253, 205, 0))
		Private feCentralGroup As NFillStyle = New NColorFillStyle(Color.FromArgb(255, 154, 204))

		#End Region
	End Class
End Namespace
