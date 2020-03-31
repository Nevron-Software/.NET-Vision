Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram.Extensions

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NAutocadExportUC.
	''' </summary>
	Public Class NAutocadExportUC
		Inherits NExportBaseUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			btnExport.Text = "Export to DXF"
		End Sub

		#End Region

		#Region "Overrides"

		Protected Overrides ReadOnly Property ErrorMessage() As String
			Get
				Return "The generated AutoCAD DXF file failed to open. May be you do not have a DXF viewer installed (e.g. AutoCAD, DWG TrueView, etc)."
			End Get
		End Property
		Protected Overrides Function Export() As String
			Dim exporter As NAutocadExporter = New NAutocadExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.dxf")
			exporter.SaveToFile(fileName)
			Return fileName
		End Function

		#End Region
	End Class
End Namespace