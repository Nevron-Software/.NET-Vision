using System.Collections.Generic;
using System.Drawing;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.WebForm;
using Nevron.Dom;
using Nevron.GraphicsCore;
using Nevron.UI.WebForm.Controls;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
    /// Summary description for NWorldCup2006RenderPage.
	/// </summary>
	public partial class NWorldCup2006RenderPage : NDrawingViewHostPage
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NWorldCup2006RenderPage()
		{
            Flags = null;
            InitImages();

			DrawingView = new NDrawingView();
			DrawingView.ViewLayout = CanvasLayout.Stretch;

            NImageResponse swfResponse = new NImageResponse();
            swfResponse.ImageFormat = new NSwfImageFormat();
            swfResponse.StreamImageToBrowser = true;
            DrawingView.ServerSettings.BrowserResponseSettings.DefaultResponse = swfResponse;

			// init document
			NDrawingDocument document = DrawingView.Document;
			document.BeginInit();
			InitDocument(document);
			document.EndInit();

			DrawingView.SizeToContent();
        }

        #endregion

        #region Private Methods

        private void InitDocument(NDrawingDocument document)
		{
			document.BackgroundStyle.FrameStyle.Visible = false;

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
            int count = Matches.Length;

            for (i = 0; i < count; i++)
            {
                winner = CreateShape(Matches[i]);
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
			layout.LayerSpacing = 38;
            layout.Layout(shapes, new NDrawingLayoutContext(document));

            // resize document to fit all shapes
            document.SizeToContent();
        }
        private void ConnectShapes(NShape shape1, NShape shape2, NShape winner, int depth)
        {
            NDrawingDocument document = DrawingView.Document;
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
            NDrawingDocument document = DrawingView.Document;
            NTableShape table = new NTableShape();
            document.ActiveLayer.AddChild(table);

            table.InitTable(3, 2);
            table.BeginUpdate();

            table.CellPadding = new Nevron.Diagram.NMargins(2);
            table.ShowGrid = false;

            NTableColumn column = (NTableColumn)table.Columns.GetChildAt(1);
            column.SizeMode = TableColumnSizeMode.Fixed;
            column.Width = 90;

            table[0, 0].Bitmap = Flags[m.team1];
            table[1, 0].Text = m.team1;
            table[2, 0].Text = m.score1.ToString();

            table[0, 1].Bitmap = Flags[m.team2];
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
                NFadeAnimation fade = new NFadeAnimation(0, depth * AnimationDuration);
                fade.EndAlpha = 0;
                shape.Style.AnimationsStyle.Animations.Add(fade);
            }

            shape.Style.AnimationsStyle.Animations.Add(new NFadeAnimation(depth * AnimationDuration,
                AnimationDuration));
        }

        private void InitImages()
        {
            if (Flags != null)
                return;

            Flags = new Dictionary<string, Bitmap>();
            Rectangle flagBounds = new Rectangle(0, 0, 24, 16);
            using (Bitmap allFlags = new Bitmap(Server.MapPath("~\\Images\\flags.png")))
            {
                int x = 0, y = 0;

                for (int i = 0; i < 8; i++)
                {
                    // create flag for team1
                    CreateFlagForTeam(allFlags, x, y, Matches[i].team1);

                    // advance coordinates
                    y += 16;

                    // create flag for team2
                    CreateFlagForTeam(allFlags, x, y, Matches[i].team2);
                    y += 16;

                    if (i == 3)
                    {
                        x = 24;
                        y = 0;
                    }
                }
            }
        }
        private void CreateFlagForTeam(Bitmap allFlags, int x, int y, string name)
        {
            Bitmap flag = new Bitmap(24, 16);

            using (Graphics gr = Graphics.FromImage(flag))
            {
                gr.Clear(Color.White);
                gr.DrawImage(allFlags, new Rectangle(0, 0, 24, 16), x, y, 24, 16, GraphicsUnit.Pixel);
            }

            Flags.Add(name, flag);
        }

        #endregion

        #region Fields

        private Dictionary<string, Bitmap> Flags;

        #endregion

        #region Constants

        private const float AnimationDuration = 1.0f;
        private static readonly NSize FlagSize = new NSize(48, 32);
        private static readonly Match[] Matches = new Match[]{
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