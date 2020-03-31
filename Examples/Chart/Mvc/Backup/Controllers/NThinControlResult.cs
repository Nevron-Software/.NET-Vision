using System.Web.Mvc;
using Nevron.ThinWeb;

namespace Nevron.Examples.Chart.Mvc
{
    public sealed class NThinControlResult : PartialViewResult
    {
        #region Constructors

        public NThinControlResult(NResponseOutput output)
        {
            m_Output = output;
        }

        #endregion

        #region Overrides

        public override void ExecuteResult(ControllerContext context)
        {
			if (m_Output == null)
				return;

			context.HttpContext.Response.ContentType = m_Output.m_MimeType;

            NTextResponseOutput textOutput = m_Output as NTextResponseOutput;
            if (textOutput != null)
            {

                context.HttpContext.Response.Write(textOutput.m_Text);
                return;
            }

            NBinaryResponseOutput binaryOutput = m_Output as NBinaryResponseOutput;
            if (binaryOutput != null)
            {
				context.HttpContext.Response.Clear();
                context.HttpContext.Response.OutputStream.Write(binaryOutput.m_Data, 0, binaryOutput.m_Length);

                if (binaryOutput.m_Headers != null)
                {
                    int count = binaryOutput.m_Headers.Length;
                    for (int i = 0; i < count; )
                    {
                        context.HttpContext.Response.AppendHeader(binaryOutput.m_Headers[i++], binaryOutput.m_Headers[i++]);
                    }
                }
            }
        }

        #endregion

        #region Fields

        NResponseOutput m_Output;

        #endregion
    }
}
