Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram.Extensions

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NXamlExportUC.
	''' </summary>
	Public Class NXamlExportUC
		Inherits NExportBaseUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			btnExport.Text = "Export to XAML"
		End Sub

		#End Region

		#Region "Overrides"

		Protected Overrides ReadOnly Property ErrorMessage() As String
			Get
				Return "The generated XAML file failed to open."
			End Get
		End Property
		Protected Overrides Function Export() As String
			Dim exporter As NXamlExporter = New NXamlExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.xaml")
			exporter.SaveToFile(fileName)
			Return fileName
		End Function

		#End Region
	End Class
End Namespace