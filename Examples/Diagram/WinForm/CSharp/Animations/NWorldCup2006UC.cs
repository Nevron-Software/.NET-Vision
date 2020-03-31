using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.Diagram.Layout;
using Nevron.Dom;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.WinForm
{
    public class NWorldCup2006UC : NDiagramExampleUC
    {
        #region Constructors

        public NWorldCup2006UC(NMainForm form)
            : base(form)
        {
            InitializeComponent();
        }
        static NWorldCup2006UC()
        {
			MATCHES = new Match[]{	// Round of 16
									new Match("Germany", "Sweden", 2, 0),
									new Match("Argentina", "Mexico", 2, 1),
									new Match("Italy", "Australia", 1, 0),
									new Match("Switzerland", "Ukraine", 0, 3),
									new Match("England", "Ecuador", 1, 0),
									new Match("Portugal", "Netherlands", 1, 0),
									new Match("Brazil", "Ghana", 3, 0),
									new Match("Spain", "France", 1, 3),

									// Quarter finals
									new Match("Argentina", "Germany", 2, 4),
									new Match("Italy", "Ukraine", 3, 0),
									new Match("England", "Portugal", 1, 3),
									new Match("Brazil", "France", 0, 1),

									// Semi finals
									new Match("Italy", "Germany", 2, 0),
									new Match("Portugal", "France", 0, 1),

									// Final
									new Match("France", "Italy", 3, 5) };

            FLAGS = new Dictionary<string, Bitmap>();
            Bitmap flag;
            Rectangle flagBounds = new Rectangle(0, 0, 24, 16);
			using (Bitmap allFlags = Nevron.UI.NResourceHelper.BitmapFromResource(typeof(NWorldCup2006UC), "Flags.bmp", "Nevron.Examples.Diagram.WinForm.Resources"))
			{
				int x = 0, y = 0;

				for (int i = 0; i < 8; i++)
				{
					// create flag for team1
					CreateFlagForTeam(allFlags, x, y, MATCHES[i].team1);

					// advance coordinates
					y += 16;
					
					// create flag for team2
					CreateFlagForTeam(allFlags, x, y, MATCHES[i].team2);
					y += 16;

					if (i == 3)
					{
						x = 24;
						y = 0;
					}
				}
			}
        }

		private static void CreateFlagForTeam(Bitmap allFlags, int x, int y, string name)
		{
			Bitmap flag = new Bitmap(24, 16);

			using (Graphics gr = Graphics.FromImage(flag))
			{
				gr.Clear(Color.White);
				gr.DrawImage(allFlags, new Rectangle(0, 0, 24, 16), x, y, 24, 16, GraphicsUnit.Pixel);
			}

			FLAGS.Add(name, flag);
		}

        #endregion

        #region Component Designer Generated Code

        private void InitializeComponent()
        {
            this.btnGenerateSwf = new Nevron.UI.WinForm.Controls.NButton();
            this.btnGenerateXaml = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // btnGenerateSwf
            // 
            this.btnGenerateSwf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateSwf.Location = new System.Drawing.Point(8, 491);
            this.btnGenerateSwf.Name = "btnGenerateSwf";
            this.btnGenerateSwf.Size = new System.Drawing.Size(244, 23);
            this.btnGenerateSwf.TabIndex = 3;
            this.btnGenerateSwf.Text = "Generate SWF";
            this.btnGenerateSwf.UseVisualStyleBackColor = true;
            this.btnGenerateSwf.Click += new System.EventHandler(this.btnGenerateSwf_Click);
            // 
            // btnGenerateXaml
            // 
            this.btnGenerateXaml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateXaml.Location = new System.Drawing.Point(8, 460);
            this.btnGenerateXaml.Name = "btnGenerateXaml";
            this.btnGenerateXaml.Size = new System.Drawing.Size(244, 23);
            this.btnGenerateXaml.TabIndex = 6;
            this.btnGenerateXaml.Text = "Generate XAML";
            this.btnGenerateXaml.UseVisualStyleBackColor = true;
            this.btnGenerateXaml.Click += new System.EventHandler(this.btnGenerateXaml_Click);
            // 
            // NWorldCup2006UC
            // 
            this.Controls.Add(this.btnGenerateXaml);
            this.Controls.Add(this.btnGenerateSwf);
            this.Name = "NWorldCup2006UC";
            this.Controls.SetChildIndex(this.btnGenerateSwf, 0);
            this.Controls.SetChildIndex(this.btnGenerateXaml, 0);
            this.ResumeLayout(false);

        }

        #endregion

        #region NDiagramExampleUC Overrides

        protected override void LoadExample()
        {
            // begin view init
            view.BeginInit();

            // init view
            view.ViewLayout = ViewLayout.Fit;
            view.DocumentPadding = new Nevron.Diagram.NMargins(10);
            view.Grid.Visible = false;
            view.GlobalVisibility.ShowPorts = false;
            view.HorizontalRuler.Visible = false;
            view.VerticalRuler.Visible = false;

            // init document
            document.BeginInit();
            InitDocument();
            document.EndInit();

            // end view init
            view.EndInit();
        }

        #endregion

        #region Implementation

        private void InitDocument()
        {
            // change default document styles
            document.Style.TextStyle.TextFormat = TextFormat.XML;
            document.Style.StartArrowheadStyle.Shape = ArrowheadShape.None;
            document.Style.EndArrowheadStyle.Shape = ArrowheadShape.None;
            document.Style.FillStyle = new NGradientFillStyle(GradientStyle.DiagonalUp, GradientVariant.Variant1,
                new NArgbColor(155, 184, 209), new NArgbColor(83, 138, 179));

            // the fill style for the cells
            NStyleSheet transparent = new NStyleSheet("transparent");
            NStyle.SetFillStyle(transparent, new NColorFillStyle(KnownArgbColorValue.Transparent));
            document.StyleSheets.AddChild(transparent);

            NNodeList shapes = new NNodeList();
            NShape shape1, shape2, winner = null;
            int i, depth = 0;
            int count = MATCHES.Length;

            for (i = 0; i < count; i++)
            {
                winner = CreateShape(MATCHES[i]);
                shapes.Add(winner);

                if (i >= 8)
				{
					if (i < 12)
					{   // The quarter finals
                        depth = 0;
						shape1 = (NShape)shapes[(i - 8) * 2];
						shape2 = (NShape)shapes[(i - 8) * 2 + 1];
					}
					else if (i < 14)
					{   // The semi finals
                        depth = 2;
						shape1 = (NShape)shapes[8 + (i - 12) * 2];
						shape2 = (NShape)shapes[8 + (i - 12) * 2 + 1];
					}
					else
					{   // The final
                        depth = 4;
						shape1 = (NShape)shapes[12];
						shape2 = (NShape)shapes[13];
					}

                    SetAnimationsStyle(shape1, depth);
                    SetAnimationsStyle(shape2, depth);

					ConnectShapes(shape1, shape2, winner, depth + 1);
				}
            }

            SetAnimationsStyle(winner, depth + 2);

            NLayeredGraphLayout layout = new NLayeredGraphLayout();
            layout.Direction = LayoutDirection.LeftToRight;
            layout.Layout(shapes, new NDrawingLayoutContext(document));

            // resize document to fit all shapes
            document.SizeToContent();
        }
        private void ConnectShapes(NShape shape1, NShape shape2, NShape winner, int depth)
        {
            NPort port = (NPort)winner.Ports.GetChildByName("Left");

            NRoutableConnector connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = shape2;
            connector.EndPlug.Connect(port);
            SetAnimationsStyle(connector, depth);

            connector = new NRoutableConnector();
            document.ActiveLayer.AddChild(connector);
            connector.FromShape = shape1;
            connector.EndPlug.Connect(port);
            SetAnimationsStyle(connector, depth);
        }
        private NTableShape CreateShape(Match m)
        {
            NTableShape table = new NTableShape();
            document.ActiveLayer.AddChild(table);

            table.InitTable(3, 2);
            table.BeginUpdate();

            table.CellPadding = new Nevron.Diagram.NMargins(2);
            table.ShowGrid = false;

            NTableColumn column = (NTableColumn)table.Columns.GetChildAt(1);
            column.SizeMode = TableColumnSizeMode.Fixed;
            column.Width = 90;

            table[0, 0].Bitmap = FLAGS[m.team1];
            table[1, 0].Text = m.team1;
            table[2, 0].Text = m.score1.ToString();

            table[0, 1].Bitmap = FLAGS[m.team2];
            table[1, 1].Text = m.team2;
            table[2, 1].Text = m.score2.ToString();

            // write the winner in bold
            if (m.score1 > m.score2)
            {
                table[1, 0].Text = "<b>" + table[1, 0].Text + "</b>";
                table[2, 0].Text = "<b>" + table[2, 0].Text + "</b>";
            }
            else
            {
                table[1, 1].Text = "<b>" + table[1, 1].Text + "</b>";
                table[2, 1].Text = "<b>" + table[2, 1].Text + "</b>";
            }

            // make all cells transparent so that the background of the table is visible
            int i, j;
            int rowCount = table.RowCount, colCount = table.ColumnCount;
            for (i = 0; i < rowCount; i++)
            {
                for (j = 0; j < colCount; j++)
                {
                    table[j, i].StyleSheetName = "transparent";
                }
            }

            table.EndUpdate();
            table.Ports.DefaultInwardPortUniqueId = ((NPort)table.Ports.GetChildByName("Right")).UniqueId;

            return table;
        }
        private void SetAnimationsStyle(NShape shape, int depth)
        {
            shape.Style.AnimationsStyle = new NAnimationsStyle();

            if (depth > 0)
            {
                NFadeAnimation fade = new NFadeAnimation(0, depth * ANIMATION_DURATION);
                fade.EndAlpha = 0;
                shape.Style.AnimationsStyle.Animations.Add(fade);
            }

            shape.Style.AnimationsStyle.Animations.Add(new NFadeAnimation(depth * ANIMATION_DURATION,
                ANIMATION_DURATION));
        }

        #endregion

        #region Event Handlers

        private void btnGenerateSwf_Click(object sender, System.EventArgs e)
        {
            NFlashExporter flashExporter = new NFlashExporter(document);
            string fileName = Path.Combine(Application.StartupPath, "test.swf");
            flashExporter.SaveToFile(fileName);
            Process.Start(fileName);
        }
        private void btnGenerateXaml_Click(object sender, System.EventArgs e)
        {
            NXamlExporter flashExporter = new NXamlExporter(document);
            string fileName = Path.Combine(Application.StartupPath, "test.xaml");
            flashExporter.SaveToFile(fileName);
            Process.Start(fileName);
        }

        #endregion

        #region Designer Fields

        private Nevron.UI.WinForm.Controls.NButton btnGenerateSwf;
        private Nevron.UI.WinForm.Controls.NButton btnGenerateXaml;

        #endregion

        #region Static

        private const float ANIMATION_DURATION = 1.0f;
        private static readonly NSize FLAG_SIZE = new NSize(48, 32);
        private static readonly Dictionary<string, Bitmap> FLAGS;
        private static readonly Match[] MATCHES = new Match[]{
            // Round of 16
            new Match("Germany", "Sweden", 2, 0),
            new Match("Argentina", "Mexico", 2, 1),
            new Match("Italy", "Australia", 1, 0),
            new Match("Switzerland", "Ukraine", 0, 3),
            new Match("England", "Ecuador", 1, 0),
            new Match("Portugal", "Netherlands", 1, 0),
            new Match("Brazil", "Ghana", 3, 0),
            new Match("Spain", "France", 1, 3),

            // Quarter finals
            new Match("Argentina", "Germany", 2, 4),
            new Match("Italy", "Ukraine", 3, 0),
            new Match("England", "Portugal", 1, 3),
            new Match("Brazil", "France", 0, 1),

            // Semi finals
            new Match("Italy", "Germany", 2, 0),
            new Match("Portugal", "France", 0, 1),

            // Final
            new Match("France", "Italy", 3, 5)
        };

        #endregion

        #region NestedTypes

        struct Match
        {
            public string team1;
            public string team2;
            public int score1;
            public int score2;

            public Match(string team1, string team2, int score1, int score2)
            {
                this.team1 = team1;
                this.team2 = team2;
                this.score1 = score1;
                this.score2 = score2;
            }
        }

        #endregion
    }
}