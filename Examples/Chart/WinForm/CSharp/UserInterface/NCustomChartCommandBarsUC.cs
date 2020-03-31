using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Editors;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.UI;
using System.Collections.Generic;

namespace Nevron.Examples.Chart.WinForm
{
	[ToolboxItem(false)]
	public class NCustomChartCommandBarsUC : NExampleBaseUC
	{
		#region Constructor

		public NCustomChartCommandBarsUC()
		{
			InitializeComponent();
		}


		#endregion

		#region Overrides

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
                // revert to the orignal commander and builder
                m_Manager.Commander = new NChartCommander();
                m_Manager.ToolbarsBuilder = new NChartToolbarCommandBuilder();
                m_Manager.Recreate();
                m_Manager.ChartControl = this.nChartControl1;

				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        protected void RecreateToolbar()
        {
            m_Manager.Commander = new NCustomChartCommander();
            m_Manager.ToolbarsBuilder = new NCustomChartToolbarsBuilder(this);
            m_Manager.Recreate();

            NRange range1 = new NRange();
            range1.ID = NCustomChartCommander.m_CustomCommandRange1;
            range1.Name = "Custom Commands1";
            m_Manager.Ranges.Add(range1);

            NRange range2 = new NRange();
            range2.ID = NCustomChartCommander.m_CustomCommandRange1;
            range2.Name = "Custom Commands1";
            m_Manager.Ranges.Add(range2);

            m_Manager.ChartControl = nChartControl1;

            // remove the palette button from he standard toolbar
            for (int i = m_Manager.Toolbars.Count - 1; i >= 0; i--)
            {
                NDockingToolbar toolbar = m_Manager.Toolbars[i];

                if (toolbar.DefaultRangeID == (int)ChartCommandRange.Standard)
                {
                    // if not removed check whether to remove command from it
                    if (!ShowPaletteButtonCheckBox.Checked)
                    {
                        NCommand command = toolbar.Commands.GetCommandById((int)ChartCommand.ApplyStyleSheet);
                        toolbar.Commands.Remove(command);
                    }
                }
            }
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			m_Manager = ((NMainForm)base.m_MainForm).chartCommandBarsManager;
            
            // set a chart title
            NLabel title = nChartControl1.Labels.AddHeader("Customizing the Command Bar");
            title.TextStyle.FontStyle = new NFontStyle("Times New Roman", 18, FontStyle.Italic);
            title.ContentAlignment = ContentAlignment.BottomCenter;
            title.Location = new NPointL(new NLength(50, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            NPieChart chart = new NPieChart();
            chart.Enable3D = true;
            nChartControl1.Charts.Clear();
            nChartControl1.Charts.Add(chart);

            chart.Projection.SetPredefinedProjection(PredefinedProjection.OrthogonalElevated);
            chart.LightModel.SetPredefinedLightModel(PredefinedLightModel.NorthernLights);

            chart.DisplayOnLegend = nChartControl1.Legends[0];
            chart.Location = new NPointL(new NLength(15, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(70, NRelativeUnit.ParentPercentage), new NLength(70, NRelativeUnit.ParentPercentage));

            NPieSeries pieSeries = (NPieSeries)chart.Series.Add(SeriesType.Pie);
            pieSeries.PieEdgePercent = 30;
            pieSeries.PieStyle = PieStyle.SmoothEdgePie;
            pieSeries.Legend.Mode = SeriesLegendMode.DataPoints;
            pieSeries.Legend.Format = "<label> <percent>";

            pieSeries.AddDataPoint(new NDataPoint(12, "Ships"));
            pieSeries.AddDataPoint(new NDataPoint(42, "Trains"));
            pieSeries.AddDataPoint(new NDataPoint(56, "Cars"));
            pieSeries.AddDataPoint(new NDataPoint(23, "Buses"));
            pieSeries.AddDataPoint(new NDataPoint(18, "Airplanes"));

            for (int i = 0; i < pieSeries.Values.Count; i++ )
            {
                pieSeries.Detachments.Add(0);
            }

            // apply style sheet
			NStyleSheet styleSheet = NStyleSheet.CreatePredefinedStyleSheet(PredefinedStyleSheet.FreshMultiColor);
            styleSheet.Apply(nChartControl1.Document);

            ShowStandardToolbarCheckBox_CheckedChanged(null, null);
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.ShowStandardToolbarCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ShowPaletteButtonCheckBox = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.SuspendLayout();
            // 
            // ShowStandardToolbarCheckBox
            // 
            this.ShowStandardToolbarCheckBox.ButtonProperties.BorderOffset = 2;
            this.ShowStandardToolbarCheckBox.Location = new System.Drawing.Point(13, 12);
            this.ShowStandardToolbarCheckBox.Name = "ShowStandardToolbarCheckBox";
            this.ShowStandardToolbarCheckBox.Size = new System.Drawing.Size(153, 24);
            this.ShowStandardToolbarCheckBox.TabIndex = 0;
            this.ShowStandardToolbarCheckBox.Text = "Show Standard Toolbar";
            this.ShowStandardToolbarCheckBox.CheckedChanged += new System.EventHandler(this.ShowStandardToolbarCheckBox_CheckedChanged);
            // 
            // ShowPaletteButtonCheckBox
            // 
            this.ShowPaletteButtonCheckBox.ButtonProperties.BorderOffset = 2;
            this.ShowPaletteButtonCheckBox.Location = new System.Drawing.Point(13, 42);
            this.ShowPaletteButtonCheckBox.Name = "ShowPaletteButtonCheckBox";
            this.ShowPaletteButtonCheckBox.Size = new System.Drawing.Size(153, 24);
            this.ShowPaletteButtonCheckBox.TabIndex = 1;
            this.ShowPaletteButtonCheckBox.Text = "Show Palette Button";
            this.ShowPaletteButtonCheckBox.CheckedChanged += new System.EventHandler(this.ShowPaletteButtonCheckBox_CheckedChanged);
            // 
            // NCustomChartCommandBarsUC
            // 
            this.Controls.Add(this.ShowPaletteButtonCheckBox);
            this.Controls.Add(this.ShowStandardToolbarCheckBox);
            this.Name = "NCustomChartCommandBarsUC";
            this.Size = new System.Drawing.Size(227, 369);
            this.ResumeLayout(false);

		}
		#endregion

		#region Fields

		private System.ComponentModel.Container components = null;
        public NCheckBox ShowStandardToolbarCheckBox;
        public NCheckBox ShowPaletteButtonCheckBox;

        internal NChartCommandBarsManager m_Manager;

		#endregion

        private void ShowStandardToolbarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RecreateToolbar();

            ShowPaletteButtonCheckBox.Enabled = ShowStandardToolbarCheckBox.Checked;
        }

        private void ShowPaletteButtonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RecreateToolbar();
        }
	}

    /// <summary>
    /// Summary description for NCustomDiagramToolbarsBuilder.
    /// </summary>
    public class NCustomChartToolbarsBuilder : NChartToolbarCommandBuilder
    {
        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customChartCommandBarsUC"></param>
        public NCustomChartToolbarsBuilder(NCustomChartCommandBarsUC customChartCommandBarsUC)
        {
            m_CustomChartCommandBarsUC = customChartCommandBarsUC;
        }

        #endregion

        #region Overrides

        public override NDockingToolbar[] BuildToolbars(NChartCommander commander)
        {
            List<NDockingToolbar> toolbars = new List<NDockingToolbar>(base.BuildToolbars(commander));

                  // remove all standard toolbars in case of standard toolbar check the 
            // the "Remove Standard Toolbar check button is checked
            for (int i = toolbars.Count - 1; i >= 0; i--)
            {
                NDockingToolbar toolbar = toolbars[i];

                bool remove = true;
                if (toolbar.DefaultRangeID == (int)ChartCommandRange.Standard)
                {
                    remove = !m_CustomChartCommandBarsUC.ShowStandardToolbarCheckBox.Checked;
                }

                if (remove)
                {
                    toolbars.RemoveAt(i);
                }
            }

            NDockingToolbar toolbar1 = new NDockingToolbar();
            toolbar1.DefaultRangeID = NCustomChartCommander.m_CustomCommandRange1;
            toolbar1.Text = "Custom Toolbar 1";
            toolbar1.RowIndex = 0;
            toolbars.Add(toolbar1);

            NDockingToolbar toolbar2 = new NDockingToolbar();
            toolbar2.DefaultRangeID = NCustomChartCommander.m_CustomCommandRange2;
            toolbar2.Text = "Custom Toolbar 2";
            toolbar2.RowIndex = 0;
            toolbars.Add(toolbar2);

            return toolbars.ToArray();
        }

        #endregion

        #region Fields

        NCustomChartCommandBarsUC m_CustomChartCommandBarsUC;

        #endregion
    }

    public class NCustomChartCommander : NChartCommander
    {
        #region Constructor

        static NCustomChartCommander()
        {
            Type thisType = typeof(NCustomChartCommander);
            ImageListCustom = new NCustomImageList(NResourceHelper.BitmapFromResource(thisType, "CustomCommandbarImageList.png", "Nevron.Examples.Chart.WinForm.Resources"), new NSize(16, 16));            
        }
        public NCustomChartCommander()
        {
            this.Commands.Add(new NCustomChartButtonCommand1());
            this.Commands.Add(new NCustomChartButtonCommand2());
        }

        #endregion

        #region Overrides

        public override bool GetCommandImageInfo(int commandId, out NCustomImageList imageList, out int imageIndex)
        {
            if (commandId == NCustomChartButtonCommand1.m_CommandId || commandId == NCustomChartButtonCommand2.m_CommandId)
            {
                imageList = ImageListCustom;
                imageIndex = 0;
                return true;
            }
            else
            {
                return base.GetCommandImageInfo(commandId, out imageList, out imageIndex);
            }
        }

        #endregion

        #region Fields

        public static NCustomImageList ImageListCustom = null;
		public static int m_CustomCommandRange1 = (int)(ChartCommandRange.LightModel + 1);
		public static int m_CustomCommandRange2 = (int)(ChartCommandRange.LightModel + 2);

        #endregion
    }

    public abstract class NCustomPieCommand : NChartButtonCommand
    {
        #region Constructor

        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="rangeId"></param>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="tooltipText"></param>
        public NCustomPieCommand(int rangeId, int id, string text, string tooltipText)
            : base(rangeId, id, text, tooltipText)
        {
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Gets the first pie series in the current chart control
        /// </summary>
        /// <returns></returns>
        protected NPieSeries GetPieSeries()
        {
            NChartControl chartControl = base.ChartControl;

            if (chartControl == null)
                return null;

            // first chart is not a pie or chart does not contain series
            if (chartControl.Charts.Count == 0 || !(chartControl.Charts[0] is NPieChart) || (chartControl.Charts[0].Series.Count == 0))
                return null;

            return (NPieSeries)(chartControl.Charts[0].Series[0]);
        }
        /// <summary>
        /// Returns true if the pie is exploded
        /// </summary>
        /// <returns></returns>
        protected bool IsPieExploded()
        {
            NPieSeries pie = GetPieSeries();

            if (pie == null)
                return false;

            for (int i = 0; i < pie.Detachments.Count; i++)
            {
                if ((double)pie.Detachments[i] == 0)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Explodes the pie
        /// </summary>
        protected void ExplodePie()
        {
            NPieSeries pie = GetPieSeries();

            if (pie == null)
                return;

            for (int i = 0; i < pie.Detachments.Count; i++)
            {
                pie.Detachments[i] = 5;
            }

            this.ChartControl.Refresh();
        }
        /// <summary>
        /// Returns true if the pie is exploded
        /// </summary>
        /// <returns></returns>
        protected bool IsPieCollapsed()
        {
            NPieSeries pie = GetPieSeries();

            if (pie == null)
                return false;

            for (int i = 0; i < pie.Detachments.Count; i++)
            {
                if ((double)pie.Detachments[i] != 0)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Collapses all pie segement
        /// </summary>
        protected void CollapsePie()
        {
            NPieSeries pie = GetPieSeries();

            if (pie == null)
                return;

            for (int i = 0; i < pie.Detachments.Count; i++)
            {
                pie.Detachments[i] = 0;
            }

            this.ChartControl.Refresh();
        }

        #endregion
    }

    /// <summary>
    /// Custom chart command that explodes all pie segments
    /// </summary>
    public class NCustomChartButtonCommand1 : NCustomPieCommand
    {
        #region Constructors

        public NCustomChartButtonCommand1()
            : base(NCustomChartCommander.m_CustomCommandRange1, m_CommandId, "Custom command 1. Explodes all pie segments.", "Custom command 1. Explodes all pie segments.")
        {
        }


        #endregion

        #region Overrides

        public override bool Enabled
        {
            get
            {
                return base.IsPieCollapsed();
            }
        }

        public override void Execute()
        {
            base.ExplodePie();
        }
        
        #endregion

        #region Static Fields

        public static int m_CommandId = (int)ChartCommand.LastCommandId + 1;

        #endregion
    }

    /// <summary>
    /// Custom chart command that collapses all pie segments
    /// </summary>
    public class NCustomChartButtonCommand2 : NCustomPieCommand
    {
        #region Constructors

        public NCustomChartButtonCommand2()
            : base(NCustomChartCommander.m_CustomCommandRange2, m_CommandId, "Custom command 2. Collapses all pie segments.", "Custom command 2. Collapses all pie segments.")
        {
        }


        #endregion

        #region Overrides

        public override bool Enabled
        {
            get
            {
                return base.IsPieExploded();
            }
        }

        public override void Execute()
        {
            base.CollapsePie();
        }

        #endregion

        #region Static Fields

        public static int m_CommandId = (int)ChartCommand.LastCommandId + 2;

        #endregion
    }

}
