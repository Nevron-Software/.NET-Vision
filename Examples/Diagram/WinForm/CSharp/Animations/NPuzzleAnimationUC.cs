using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Nevron.Diagram;
using Nevron.Diagram.Extensions;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
    /// Summary description for NPuzzleAnimationUC.
	/// </summary>
	public class NPuzzleAnimationUC : NDiagramExampleUC
	{
		#region Constructor

        public NPuzzleAnimationUC(NMainForm form)
            : base(form)
		{
			InitializeComponent();
		}

		#endregion

		#region Component Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnGenerateSwf = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // btnExportToFlash
            // 
            this.btnGenerateSwf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateSwf.Location = new System.Drawing.Point(8, 51);
            this.btnGenerateSwf.Name = "btnGenerateSwf";
            this.btnGenerateSwf.Size = new System.Drawing.Size(232, 23);
            this.btnGenerateSwf.TabIndex = 4;
            this.btnGenerateSwf.Text = "Generate SWF";
            this.btnGenerateSwf.UseVisualStyleBackColor = true;
            this.btnGenerateSwf.Click += new System.EventHandler(this.btnGenerateSwf_Click);
            // 
            // NPuzzleAnimationUC
            // 
            this.Controls.Add(this.btnGenerateSwf);
            this.Name = "NPuzzleAnimationUC";
            this.Size = new System.Drawing.Size(248, 160);
            this.Controls.SetChildIndex(this.btnGenerateSwf, 0);
            this.ResumeLayout(false);

		}

		#endregion

		#region NDiagramExampleUC Overrides

		protected override void LoadExample()
		{
			// begin view init
			view.BeginInit();
			view.Grid.Visible = false;
			view.GlobalVisibility.ShowPorts = false;

			// init document
			InitDocument();

			// end view init
			view.EndInit();
		}

		#endregion

		#region Implementation

		private void InitDocument()
		{
            NPersistencyManager manager = new NPersistencyManager();
			document = manager.LoadDrawingFromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\Data\FlowDiagram.ndx"));

            view.Document = document;
            Form.Document = document;

            document.BeginInit();
            CreateAnimatedGrid(5, 5, 1);
            document.EndInit();
		}
        private void CreateAnimatedGrid(int rows, int columns, float cellFadeDuration)
        {
            // Create the grid layer
            NLayer grid = new NLayer();
            grid.Name = "grid";
            document.Layers.AddChild(grid);

            // Create the cells style sheet
            NStyleSheet style = new NStyleSheet("gridCell");
            NStyle.SetFillStyle(style, new NColorFillStyle(KnownArgbColorValue.White));
            NStyle.SetStrokeStyle(style, new NStrokeStyle(1, KnownArgbColorValue.Black));
            document.StyleSheets.AddChild(style);

            int i, j, count;
            float x, y, time = 0;
            float cellWidth = document.Width / rows;
            float cellHeight = document.Height / columns;

            NFadeAnimation fade;
            NRectangleShape rect;
            List<NRectangleShape> cells = new List<NRectangleShape>();

            // Create the shapes
            for (i = 0, y = 0; i < rows; i++, y += cellHeight)
            {
                for (j = 0, x = 0; j < columns; j++, x += cellWidth)
                {
                    rect = new NRectangleShape(x, y, cellWidth, cellHeight);
                    cells.Add(rect);
                    grid.AddChild(rect);
                    rect.StyleSheetName = style.Name;
                }
            }

            // Create the fade animations
            count = cells.Count;
            Random random = new Random();

            int counter = 1;
            while (count > 0)
            {
                i = random.Next(count);
                rect = cells[i];
                rect.Style.AnimationsStyle = new NAnimationsStyle();

                if (time > 0)
                {
                    fade = new NFadeAnimation(0, time);
					fade.StartAlpha = 1;
					fade.EndAlpha = 1;
                    rect.Style.AnimationsStyle.AddAnimation(fade);
                }

                fade = new NFadeAnimation(time, cellFadeDuration);
                fade.StartAlpha = 1;
                fade.EndAlpha = 0;
                rect.Style.AnimationsStyle.AddAnimation(fade);

                if (counter == 3)
                {
                    // Show 3 cells at a time
                    time += cellFadeDuration;
                    counter = 1;
                }
                else
                {
                    counter++;
                }

                cells.RemoveAt(i);
                count--;
            }
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

        #endregion

        #region Designer Fields

        private NButton btnGenerateSwf;

		#endregion
    }
}