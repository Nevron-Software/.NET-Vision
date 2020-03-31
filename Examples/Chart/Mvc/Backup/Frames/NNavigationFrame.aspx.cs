using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Chart.Mvc
{
    public partial class Frames_NNavigationFrame : NNavigationPage
    {
        public Frames_NNavigationFrame()
        {
            m_TreeNodeTargetFormatter = new NMvcTreeNodeTargetFormatter();
        }

    }
}
