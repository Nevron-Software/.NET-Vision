Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Windows.Forms

Imports Nevron.Diagram.Extensions

Namespace Nevron.Examples.Diagram.WinForm
	''' <summary>
	''' Summary description for NFlashExportUC.
	''' </summary>
	Public Class NFlashExportUC
		Inherits NExportBaseUC
		#Region "Constructors"

		Public Sub New(ByVal form As NMainForm)
			MyBase.New(form)
			btnExport.Text = "Export to SWF"
		End Sub

		#End Region

		#Region "Overrides"

		Protected Overrides ReadOnly Property ErrorMessage() As String
			Get
				Return "The generated SWF file failed to open. May be you do not have a Flash player installed."
			End Get
		End Property
		Protected Overrides Function Export() As String
			Dim exporter As NFlashExporter = New NFlashExporter(document)
			Dim fileName As String = Path.Combine(Application.StartupPath, "test.swf")
			exporter.SaveToFile(fileName)
			Return fileName
		End Function

		#End Region
	End Class
End Namespace