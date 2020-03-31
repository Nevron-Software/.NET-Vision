using System.IO;
using System.Windows.Forms;

using Nevron.Diagram.Extensions;

namespace Nevron.Examples.Diagram.WinForm
{
	/// <summary>
	/// Summary description for NAutocadExportUC.
	/// </summary>
	public class NAutocadExportUC : NExportBaseUC
	{
		#region Constructors

		public NAutocadExportUC(NMainForm form)
			: base(form)
		{
			btnExport.Text = "Export to DXF";
		}

		#endregion

		#region Overrides

		protected override string ErrorMessage
		{
			get
			{
				return "The generated AutoCAD DXF file failed to open. May be you do not have a DXF viewer installed (e.g. AutoCAD, DWG TrueView, etc).";
			}
		} 
		protected override string Export()
		{
			NAutocadExporter exporter = new NAutocadExporter(document);
			string fileName = Path.Combine(Application.StartupPath, "test.dxf");
			exporter.SaveToFile(fileName);
			return fileName;
		}

		#endregion
	}
}