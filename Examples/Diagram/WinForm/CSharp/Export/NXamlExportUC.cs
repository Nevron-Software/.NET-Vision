using System.IO;
using System.Windows.Forms;

using Nevron.Diagram.Extensions;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NXamlExportUC.
	/// </summary>
	public class NXamlExportUC : NExportBaseUC
	{
		#region Constructors

		public NXamlExportUC(NMainForm form)
			: base(form)
		{
			btnExport.Text = "Export to XAML";
		}

		#endregion

		#region Overrides

		protected override string ErrorMessage
		{
			get
			{
				return "The generated XAML file failed to open.";
			}
		} 
		protected override string Export()
		{
			NXamlExporter exporter = new NXamlExporter(document);
			string fileName = Path.Combine(Application.StartupPath, "test.xaml");
			exporter.SaveToFile(fileName);
			return fileName;
		}

		#endregion
	}
}