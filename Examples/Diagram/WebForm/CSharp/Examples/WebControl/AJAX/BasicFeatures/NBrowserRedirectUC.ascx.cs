using System;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using Nevron.Dom;
using Nevron.Diagram;
using Nevron.Diagram.Shapes;
using Nevron.Diagram.Batches;
using Nevron.Diagram.WebForm;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	///		Summary description for NMouseEvents.
	/// </summary>
	public partial class NBrowserRedirectUC : NDiagramExampleUC
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (NDrawingView1.RequiresInitialization)
			{
				NDrawingDocument document = NDrawingView1.Document;

				// begin view init
				NDrawingView1.GlobalVisibility.ShowPorts = false;
				NDrawingView1.ViewLayout = CanvasLayout.Normal;
				NDrawingView1.ScaleX = 0.6f;
				NDrawingView1.ScaleY = 0.6f;
				NDrawingView1.ViewportOrigin = new NPointF();
				NDrawingView1.Document.GraphicsSettings.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

				// init document
				document.HistoryService.Stop();
				document.BeginInit();
				
				// create the scene
				CreateElements(document);
				CreateLabels(document);

				// remove the standard frame
				NDrawingView1.Document.BackgroundStyle.FrameStyle.Visible = false;

				document.EndInit();
			}
		}

		protected void NDrawingView1_QueryAjaxTools(object sender, EventArgs e)
		{
			//	configure the client side tools
			NDrawingView1.AjaxTools.Add(new NAjaxRedirectTool(true));
		}

		#region Nested Classes

		public class NChemicalElement
		{
			public NChemicalElement(int number, string symbol, string weight, int col, int row, NFillStyle fillStyle)
			{
				this.number = number;
				this.symbol = symbol;
				this.weight = weight;
				this.col = col;
				this.row = row;
				this.fillStyle = fillStyle;
			}

			public int number;
			public string symbol;
			public string weight;
			public int col;
			public int row;
			public NFillStyle fillStyle;
		}

		#endregion

		#region Implementation

		protected void CreateElements(NDrawingDocument document)
		{
			NFillStyle fsNonMetals = new NColorFillStyle(Color.FromArgb(205, 153, 255));
			NFillStyle fsMetals = new NColorFillStyle(Color.FromArgb(155, 207, 255));
			NFillStyle fsMatalloids = new NColorFillStyle(Color.FromArgb(48, 198, 187));
			NFillStyle fsGases = new NColorFillStyle(Color.FromArgb(153, 198, 17));
			NFillStyle feMoccasin = new NColorFillStyle(Color.FromArgb(255, 204, 157));
			NFillStyle feGold = new NColorFillStyle(Color.FromArgb(253, 205, 0));
			NFillStyle feCentralGroup = new NColorFillStyle(Color.FromArgb(255, 154, 204));

			document.Style.TextStyle.TextFormat = TextFormat.XML;

			NChemicalElement[] elements = 
			{
				// row 1
				new NChemicalElement(1, "H", "1.01", 1, 1, fsNonMetals),
				new NChemicalElement(2, "He", "4.00", 18, 1, fsGases),
				// row 2
				new NChemicalElement(3, "Li", "6.94", 1, 2, fsMetals),
				new NChemicalElement(4, "Be", "9.01", 2, 2, fsMetals),
				new NChemicalElement(5, "B", "10.81", 13, 2, fsNonMetals),
				new NChemicalElement(6, "C", "12.01", 14, 2, fsNonMetals),
				new NChemicalElement(7, "N", "14.01", 15, 2, fsNonMetals),
				new NChemicalElement(8, "O", "15.99", 16, 2, fsNonMetals),
				new NChemicalElement(9, "F", "19.00", 17, 2, fsNonMetals),
				new NChemicalElement(10, "Ne", "20.18", 18, 2, fsGases),
				// row 3
				new NChemicalElement(11, "Na", "22.99", 1, 3, fsMetals),
				new NChemicalElement(12, "Mg", "25.31", 2, 3, fsMetals),
				new NChemicalElement(13, "Al", "26.98", 13, 3, fsMetals),
				new NChemicalElement(14, "Si", "28.09", 14, 3, fsMatalloids),
				new NChemicalElement(15, "P", "30.97", 15, 3, fsMatalloids),
				new NChemicalElement(16, "S", "32.07", 16, 3, fsNonMetals),
				new NChemicalElement(17, "Cl", "35.45", 17, 3, fsNonMetals),
				new NChemicalElement(18, "Ar", "39.95", 18, 3, fsGases),
				// row 4
				new NChemicalElement(19, "K", "39.10", 1, 4, fsMetals),
				new NChemicalElement(20, "Ca", "40.08", 2, 4, fsMetals),
				new NChemicalElement(21, "Sc", "44.96", 3, 4, feCentralGroup),
				new NChemicalElement(22, "Ti", "47.87", 4, 4, feCentralGroup),
				new NChemicalElement(23, "V", "50.94", 5, 4, feCentralGroup),
				new NChemicalElement(24, "Cr", "52.00", 6, 4, feCentralGroup),
				new NChemicalElement(25, "Mn", "54.94", 7, 4, feCentralGroup),
				new NChemicalElement(26, "Fe", "55.85", 8, 4, feCentralGroup),
				new NChemicalElement(27, "Co", "58.93", 9, 4, feCentralGroup),
				new NChemicalElement(28, "Ni", "58.69", 10, 4, feCentralGroup),
				new NChemicalElement(29, "Cu", "63.55", 11, 4, feCentralGroup),
				new NChemicalElement(30, "Zn", "65.41", 12, 4, feCentralGroup),
				new NChemicalElement(31, "Ga", "69.72", 13, 4, fsMetals),
				new NChemicalElement(32, "Ge", "72.64", 14, 4, fsMatalloids),
				new NChemicalElement(33, "As", "74.92", 15, 4, fsMatalloids),
				new NChemicalElement(34, "Se", "78.96", 16, 4, fsNonMetals),
				new NChemicalElement(35, "Br", "79.90", 17, 4, fsNonMetals),
				new NChemicalElement(36, "Kr", "83.80", 18, 4, fsGases),
				// row 5
				new NChemicalElement(37, "Rb", "85.47", 1, 5, fsMetals),
				new NChemicalElement(38, "Sr", "87.62", 2, 5, fsMetals),
				new NChemicalElement(39, "Y", "88.91", 3, 5, feCentralGroup),
				new NChemicalElement(40, "Zr", "91.22", 4, 5, feCentralGroup),
				new NChemicalElement(41, "Nb", "92.91", 5, 5, feCentralGroup),
				new NChemicalElement(42, "Mo", "95.94", 6, 5, feCentralGroup),
				new NChemicalElement(43, "Tc", "(98)", 7, 5, feCentralGroup),
				new NChemicalElement(44, "Ru", "101.07", 8, 5, feCentralGroup),
				new NChemicalElement(45, "Rh", "102.91", 9, 5, feCentralGroup),
				new NChemicalElement(46, "Pd", "106.42", 10, 5, feCentralGroup),
				new NChemicalElement(47, "Ag", "107.87", 11, 5, feCentralGroup),
				new NChemicalElement(48, "Cd", "112.41", 12, 5, feCentralGroup),
				new NChemicalElement(49, "In", "114.82", 13, 5, fsMetals),
				new NChemicalElement(50, "Sn", "118.71", 14, 5, fsMetals),
				new NChemicalElement(51, "Sb", "121.76", 15, 5, fsMatalloids),
				new NChemicalElement(52, "Te", "127.60", 16, 5, fsMatalloids),
				new NChemicalElement(53, "I", "126.90", 17, 5, fsNonMetals),
				new NChemicalElement(54, "Xe", "131.29", 18, 5, fsGases),
				// row 6
				new NChemicalElement(55, "Cs", "132.91", 1, 6, fsMetals),
				new NChemicalElement(56, "Ba", "137.33", 2, 6, fsMetals),
				new NChemicalElement(57, "*La", "138.91", 3, 6, feCentralGroup),
				new NChemicalElement(72, "Hf", "178.49", 4, 6, feCentralGroup),
				new NChemicalElement(73, "Ta", "180.95", 5, 6, feCentralGroup),
				new NChemicalElement(74, "W", "183.84", 6, 6, feCentralGroup),
				new NChemicalElement(75, "Re", "186.21", 7, 6, feCentralGroup),
				new NChemicalElement(76, "Os", "190.23", 8, 6, feCentralGroup),
				new NChemicalElement(77, "Ir", "192.22", 9, 6, feCentralGroup),
				new NChemicalElement(78, "Pt", "195.08", 10, 6, feCentralGroup),
				new NChemicalElement(79, "Au", "196.97", 11, 6, feCentralGroup),
				new NChemicalElement(80, "Hg", "200.59", 12, 6, feCentralGroup),
				new NChemicalElement(81, "Tl", "204.38", 13, 6, fsMetals),
				new NChemicalElement(82, "Pb", "207.2", 14, 6, fsMetals),
				new NChemicalElement(83, "Bi", "208.98", 15, 6, fsMetals),
				new NChemicalElement(84, "Po", "(209)", 16, 6, fsMetals),
				new NChemicalElement(85, "At", "(210)", 17, 6, fsNonMetals),
				new NChemicalElement(86, "Rn", "(222)", 18, 6, fsGases),
				// row 7
				new NChemicalElement(87, "Fr", "(223)", 1, 7, fsMetals),
				new NChemicalElement(88, "Ra", "(226)", 2, 7, fsMetals),
				new NChemicalElement(89, "*Ac", "(227)", 3, 7, feCentralGroup),
				new NChemicalElement(104, "Rf", "(261)", 4, 7, feCentralGroup),
				new NChemicalElement(105, "Db", "(262)", 5, 7, feCentralGroup),
				new NChemicalElement(106, "Sg", "(266)", 6, 7, feCentralGroup),
				new NChemicalElement(107, "Bh", "(264)", 7, 7, feCentralGroup),
				new NChemicalElement(108, "Hs", "(270)", 8, 7, feCentralGroup),
				new NChemicalElement(109, "Mt", "(268)", 9, 7, feCentralGroup),
				new NChemicalElement(110, "Ds", "(281)", 10, 7, feCentralGroup),
				new NChemicalElement(111, "Rg", "(272)", 11, 7, feCentralGroup),
				// row 8
				// row 9
				new NChemicalElement(58, "Ce", "140.12", 5, 9, feMoccasin),
				new NChemicalElement(59, "Pr", "140.91", 6, 9, feMoccasin),
				new NChemicalElement(60, "Nd", "144.24", 7, 9, feMoccasin),
				new NChemicalElement(61, "Pm", "(145)", 8, 9, feMoccasin),
				new NChemicalElement(62, "Sm", "150.36", 9, 9, feMoccasin),
				new NChemicalElement(63, "Eu", "151.97", 10, 9, feMoccasin),
				new NChemicalElement(64, "Gd", "157.25", 11, 9, feMoccasin),
				new NChemicalElement(65, "Tb", "158.93", 12, 9, feMoccasin),
				new NChemicalElement(66, "Dy", "162.50", 13, 9, feMoccasin),
				new NChemicalElement(67, "Ho", "164.93", 14, 9, feMoccasin),
				new NChemicalElement(68, "Er", "167.26", 15, 9, feMoccasin),
				new NChemicalElement(69, "Tm", "168.93", 16, 9, feMoccasin),
				new NChemicalElement(70, "Yb", "173.04", 17, 9, feMoccasin),
				new NChemicalElement(71, "Lu", "174.97", 18, 9, feMoccasin),
				// row 10
				new NChemicalElement(90, "Th", "232.04", 5, 10, feGold),
				new NChemicalElement(91, "Pa", "231.04", 6, 10, feGold),
				new NChemicalElement(92, "U", "238.03", 7, 10, feGold),
				new NChemicalElement(93, "Np", "(237)", 8, 10, feGold),
				new NChemicalElement(94, "Pu", "(244)", 9, 10, feGold),
				new NChemicalElement(95, "Am", "(243)", 10, 10, feGold),
				new NChemicalElement(96, "Cm", "(247)", 11, 10, feGold),
				new NChemicalElement(97, "Bk", "(247)", 12, 10, feGold),
				new NChemicalElement(98, "Cf", "(251)", 13, 10, feGold),
				new NChemicalElement(99, "Es", "(252)", 14, 10, feGold),
				new NChemicalElement(100, "Fm", "(257)", 15, 10, feGold),
				new NChemicalElement(101, "Md", "(258)", 16, 10, feGold),
				new NChemicalElement(102, "No", "(259)", 17, 10, feGold),
				new NChemicalElement(103, "Lr", "(262)", 18, 10, feGold),
			};

			int length = elements.Length;
			for (int i = 0; i < length; i++)
			{
				AddElement(document, elements[i]);	
			}
		}

		protected void CreateLabels(NDrawingDocument document)
		{
			NRectangleF bounds;

			// title
			bounds = this.GetElementBounds(2, 1);
			bounds.Width = 16 * bounds.Width;
			NTextShape text = new NTextShape("Periodic Table of the Elements", bounds);
			text.Style.TextStyle = new NTextStyle(new Font("Times New Roman", 24, FontStyle.Bold));
			document.ActiveLayer.AddChild(text);

			// Lanthanide Series
			bounds = this.GetElementBounds(1, 9);
			bounds.Width = 4 * bounds.Width;
			text = new NTextShape("* Lanthanide Series:", bounds);
			text.Style.TextStyle = new NTextStyle(new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic));
			text.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
			document.ActiveLayer.AddChild(text);

			// Actinide Series
			bounds = this.GetElementBounds(1, 10);
			bounds.Width = 4 * bounds.Width;
			text = new NTextShape("* Actinide Series::", bounds);
			text.Style.TextStyle = new NTextStyle(new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic));
			text.Style.TextStyle.StringFormatStyle.HorzAlign = HorzAlign.Right;
			document.ActiveLayer.AddChild(text);
		}

		protected void AddElement(NDrawingDocument document, NChemicalElement ce)
		{
			string str = ce.number.ToString();
			NSizeF size = new NSizeF(10, 15);
			str += "<br/><font size='14'><b>" + ce.symbol + "</b></font><br/>";
			str += ce.weight;

			NShape element = null;
			element = new NRectangleShape(GetElementBounds(ce.col, ce.row));
			element.Text = str;
			string url = string.Format("http://www.google.com/search?hl=en&q={0}+chemical+element", HttpUtility.UrlEncode(ce.symbol.Replace("*", string.Empty)));
			element.Style.InteractivityStyle = new NInteractivityStyle(true, null, null, CursorType.Default, url);
			element.Style.FillStyle = ce.fillStyle;
			document.ActiveLayer.AddChild(element);
		}

		protected NRectangleF GetElementBounds(int column, int row)
		{
			NSizeF size = new NSizeF(45, 80);
			NPointF origin = new NPointF(45, 45);

			float x = origin.X + (column - 1) * size.Width;
			float y = origin.Y + (row - 1) * size.Height;

			return new NRectangleF(x, y, size.Width, size.Height);
		}

		#endregion
	}
}
