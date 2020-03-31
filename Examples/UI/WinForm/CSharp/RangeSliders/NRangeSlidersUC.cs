using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Nevron.UI;
using Nevron.UI.WinForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public class NRangeSlidersUC : NExampleUserControl
    {
        #region Constructor

        public NRangeSlidersUC(MainForm f)
            : base(f)
		{
			m_Image = NResourceHelper.BitmapFromResource(this.GetType(), "UISplash.png", "Nevron.Examples.UI.WinForm.Resources");
            InitializeComponent();
            Dock = DockStyle.Fill;
		}


		#endregion

        #region Implementation

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void SetupRangeSliders()
        {
            nAnimationSurface1.Size = nuiPanel1.Size;
            nhRangeSlider1.Minimum = 0;
            nhRangeSlider1.Maximum = nuiPanel1.Width;
            nhRangeSlider1.Range = new NRange1DD(0, nAnimationSurface1.Width);

            nvRangeSlider1.Minimum = 0;
            nvRangeSlider1.Maximum = nuiPanel1.Height;
            nvRangeSlider1.Range = new NRange1DD(0, nAnimationSurface1.Height);
        }

        #endregion

        #region Event handlers

        private void NRangeSlidersUC_Load(object sender, EventArgs e)
        {
            SetupRangeSliders();
            this.nAnimationSurface1.Image.Image = m_Image;
        }

        private void nhRangeSlider1_RangeChanged(object sender, RangeSliderEventArgs e)
        {
            int vRange = nvRangeSlider1.Range.GetLength() < 20 ? 20 : (int)nvRangeSlider1.Range.GetLength();
            int hRange = nhRangeSlider1.Range.GetLength() < 20 ? 20 : (int)nhRangeSlider1.Range.GetLength();
            
            if (zoomRadio.Checked)
            {
                nAnimationSurface1.Size = new Size((int)(nuiPanel1.Width * nhRangeSlider1.Maximum / hRange), nAnimationSurface1.Size.Height);
                nAnimationSurface1.Location = new Point((int)((-1) * nhRangeSlider1.Maximum / hRange * nhRangeSlider1.Range.Begin), (int)((-1) * nvRangeSlider1.Maximum / vRange * nvRangeSlider1.Range.Begin));
            }
            if (shrinkRadio.Checked)
            {
                nAnimationSurface1.Size = new Size(hRange, nAnimationSurface1.Size.Height);
                nAnimationSurface1.Location = new Point((int)nhRangeSlider1.Range.Begin, (int)nvRangeSlider1.Range.Begin);
            }
        }

        private void nvRangeSlider1_RangeChanged(object sender, RangeSliderEventArgs e)
        {
            int vRange = nvRangeSlider1.Range.GetLength() < 20 ? 20 : (int)nvRangeSlider1.Range.GetLength();
            int hRange = nhRangeSlider1.Range.GetLength() < 20 ? 20 : (int)nhRangeSlider1.Range.GetLength();


            if (zoomRadio.Checked)
            {
                nAnimationSurface1.Size = new Size(nAnimationSurface1.Size.Width, (int)(nuiPanel1.Height * nvRangeSlider1.Maximum / vRange));
                nAnimationSurface1.Location = new Point((int)((-1) * nhRangeSlider1.Maximum / hRange * nhRangeSlider1.Range.Begin), (int)((-1) * nvRangeSlider1.Maximum / vRange * nvRangeSlider1.Range.Begin));
            }
            if (shrinkRadio.Checked)
            {
                nAnimationSurface1.Size = new Size(nAnimationSurface1.Size.Width, vRange);
                nAnimationSurface1.Location = new Point((int)nhRangeSlider1.Range.Begin, (int)nvRangeSlider1.Range.Begin);
            }
        }

        private void shrinkRadio_CheckedChanged(object sender, EventArgs e)
        {
            SetupRangeSliders();
        }

        private void zoomRadio_CheckedChanged(object sender, EventArgs e)
        {
            SetupRangeSliders();
        }

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NRangeSlidersUC));
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.nAnimationSurface1 = new Nevron.UI.WinForm.Controls.NAnimationSurface();
            this.nvRangeSlider1 = new Nevron.UI.WinForm.Controls.NVRangeSlider();
            this.nhRangeSlider1 = new Nevron.UI.WinForm.Controls.NHRangeSlider();
            this.shrinkRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.zoomRadio = new Nevron.UI.WinForm.Controls.NRadioButton();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.nAnimationSurface1);
            this.nuiPanel1.Location = new System.Drawing.Point(4, 4);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(352, 270);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // nAnimationSurface1
            // 
            this.nAnimationSurface1.AnimationInfo.Fade = true;
            this.nAnimationSurface1.AnimationInfo.Hide = false;
            this.nAnimationSurface1.AnimationInfo.Scroll = false;
            this.nAnimationSurface1.AnimationInfo.Slide = false;
            this.nAnimationSurface1.Location = new System.Drawing.Point(4, 4);
            this.nAnimationSurface1.Name = "nAnimationSurface1";
            this.nAnimationSurface1.Size = new System.Drawing.Size(186, 136);
            this.nAnimationSurface1.TabIndex = 0;
            this.nAnimationSurface1.Text = "nAnimationSurface1";
            // 
            // nvRangeSlider1
            // 
            this.nvRangeSlider1.LargeChange = 10;
            this.nvRangeSlider1.Location = new System.Drawing.Point(363, 4);
            this.nvRangeSlider1.Maximum = 100;
            this.nvRangeSlider1.Minimum = 0;
            this.nvRangeSlider1.MinimumSize = new System.Drawing.Size(17, 34);
            this.nvRangeSlider1.Name = "nvRangeSlider1";
            this.nvRangeSlider1.Range = ((Nevron.GraphicsCore.NRange1DD)(resources.GetObject("nvRangeSlider1.Range")));
            this.nvRangeSlider1.Size = new System.Drawing.Size(17, 270);
            this.nvRangeSlider1.SmallChange = 1;
            this.nvRangeSlider1.TabIndex = 1;
            this.nvRangeSlider1.Text = "nvRangeSlider1";
            this.nvRangeSlider1.Value = 0;
            this.nvRangeSlider1.RangeChanged += new Nevron.UI.WinForm.Controls.RangeSliderEventHandler(this.nvRangeSlider1_RangeChanged);
            // 
            // nhRangeSlider1
            // 
            this.nhRangeSlider1.LargeChange = 10;
            this.nhRangeSlider1.Location = new System.Drawing.Point(4, 281);
            this.nhRangeSlider1.Maximum = 100;
            this.nhRangeSlider1.Minimum = 0;
            this.nhRangeSlider1.MinimumSize = new System.Drawing.Size(34, 17);
            this.nhRangeSlider1.Name = "nhRangeSlider1";
            this.nhRangeSlider1.Range = ((Nevron.GraphicsCore.NRange1DD)(resources.GetObject("nhRangeSlider1.Range")));
            this.nhRangeSlider1.Size = new System.Drawing.Size(352, 17);
            this.nhRangeSlider1.SmallChange = 1;
            this.nhRangeSlider1.TabIndex = 2;
            this.nhRangeSlider1.Text = "nhRangeSlider1";
            this.nhRangeSlider1.Value = 0;
            this.nhRangeSlider1.RangeChanged += new Nevron.UI.WinForm.Controls.RangeSliderEventHandler(this.nhRangeSlider1_RangeChanged);
            // 
            // shrinkRadio
            // 
            this.shrinkRadio.AutoSize = true;
            this.shrinkRadio.ButtonProperties.BorderOffset = 2;
            this.shrinkRadio.Checked = true;
            this.shrinkRadio.Location = new System.Drawing.Point(387, 4);
            this.shrinkRadio.Name = "shrinkRadio";
            this.shrinkRadio.Size = new System.Drawing.Size(55, 17);
            this.shrinkRadio.TabIndex = 4;
            this.shrinkRadio.TabStop = true;
            this.shrinkRadio.Text = "Shrink";
            this.shrinkRadio.CheckedChanged += new System.EventHandler(this.shrinkRadio_CheckedChanged);
            // 
            // zoomRadio
            // 
            this.zoomRadio.AutoSize = true;
            this.zoomRadio.ButtonProperties.BorderOffset = 2;
            this.zoomRadio.Location = new System.Drawing.Point(387, 28);
            this.zoomRadio.Name = "zoomRadio";
            this.zoomRadio.Size = new System.Drawing.Size(52, 17);
            this.zoomRadio.TabIndex = 5;
            this.zoomRadio.Text = "Zoom";
            this.zoomRadio.CheckedChanged += new System.EventHandler(this.zoomRadio_CheckedChanged);
            // 
            // NRangeSlidersUC
            // 
            this.Controls.Add(this.zoomRadio);
            this.Controls.Add(this.shrinkRadio);
            this.Controls.Add(this.nhRangeSlider1);
            this.Controls.Add(this.nvRangeSlider1);
            this.Controls.Add(this.nuiPanel1);
            this.Name = "NRangeSlidersUC";
            this.Size = new System.Drawing.Size(538, 350);
            this.Load += new System.EventHandler(this.NRangeSlidersUC_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion            

        #region Fields

        private System.ComponentModel.Container components = null;
        private NUIPanel nuiPanel1;
        private NVRangeSlider nvRangeSlider1;
        private NHRangeSlider nhRangeSlider1;
        private NAnimationSurface nAnimationSurface1;
        private NRadioButton shrinkRadio;
        private NRadioButton zoomRadio;
        private Image m_Image;

        #endregion    
    }
}
