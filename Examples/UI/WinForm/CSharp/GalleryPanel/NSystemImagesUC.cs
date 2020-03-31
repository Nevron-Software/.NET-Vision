using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.GraphicsCore;
using Nevron.UI.WinForm.Controls;
using Nevron.Examples.Framework.WinForm;

namespace Nevron.Examples.UI.WinForm
{
    public partial class NSystemImagesUC : NExampleUserControl
    {
        #region Constructor

        public NSystemImagesUC()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        public override void Initialize()
        {
            base.Initialize();

            this.smallImages.LoadSmallSystemImages();
            this.largeImages.LoadLargeSystemImages();
        }

        #endregion
    }
}
