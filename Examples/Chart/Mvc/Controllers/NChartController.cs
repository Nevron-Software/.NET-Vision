using System.Web.Mvc;
using Nevron.Chart.ThinWeb;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.Mvc
{
    public abstract class NChartController : Controller
    {
        public NChartController()
        {

        }

        #region Must Override

        /// <summary>
        /// Called to get the server id the chart
        /// </summary>
        public string ServerId
        {
            get
            {
                string name = this.GetType().Name;
                int index = name.LastIndexOf("Controller");

                return name.Substring(0, index);
            }
        }
        /// <summary>
        /// Called when the control has to be initialized
        /// </summary>
        /// <param name="control"></param>
        public abstract void Initialize(NThinChartControl control);

        #endregion

        #region Implementation

        private NThinChartControl Control
        {
            get
            {
                NThinChartControl control = new NThinChartControl();

                control.StateId = this.ServerId;
                control.ServiceUrl = "/" + ServerId + "/Service";

                return control;
            }
        }

        #endregion

        #region Verbs

        /// <summary>
        /// Renders the initial content of the chart on the page
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Content()
        {
            NThinChartControl control = this.Control;
            control.ConfigureInitialResponse();

            control.ServerSettings.Css.StateHover = "border: 1px solid rgb(38, 148, 232);background: rgb(255, 0, 0);";

            Initialize(control);
            
            return new NThinControlResult(control.ProcessResponses());
        }
        /// <summary>
        /// Services AJAX calls to the control
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Service(string request)
        {
			NThinChartControl ntcc = new NThinChartControl();
            NResponseOutput output = this.Control.ProcessRequest(request);
            return new NThinControlResult(output);
        }
        /// <summary>
        /// Renders the control script
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Script()
        {
			return new NThinControlResult(new NTextResponseOutput(NTextResponseOutput.m_MimeHTML, this.Control.GetIncludeScript()));
        }

        #endregion
    }
}