using System.IO;
using System.Windows.Forms;

using Nevron.Diagram.Extensions;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NFlashExportUC.
	/// </summary>
	public class NFlashExportUC : NExportBaseUC
	{
		#region Constructors

		public NFlashExportUC(NMainForm form)
			: base(form)
		{
			btnExport.Text = "Export to SWF";
		}

		#endregion

		#region Overrides

		protected override string ErrorMessage
		{
			get
			{
				return "The generated SWF file failed to open. May be you do not have a Flash player installed.";
			}
		} 
		protected override string Export()
		{
			NFlashExporter exporter = new NFlashExporter(document);
			string fileName = Path.Combine(Application.StartupPath, "test.swf");
			exporter.SaveToFile(fileName);
			return fileName;
		}

		#endregion
	}
}