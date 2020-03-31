Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Namespace Nevron.Examples.Diagram.Webform.GettingStarted
	''' <summary>
	''' Summary description for NPersonalInfoPage.
	''' </summary>
	Public Partial Class NPersonalInfoPage
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim id As Integer = Int32.Parse(HttpContext.Current.Request.QueryString.Get(0))

			Dim personalInfos As NPersonalInfo() = NPersonalInfo.CreateCompanyInfo()
			Dim personalInfo As NPersonalInfo = Nothing

			' find the personal info by id

			Dim i As Integer = 0
			Do While i < personalInfos.Length
				If personalInfos(i).Id = id Then
					personalInfo = personalInfos(i)
					Exit Do
				End If
				i += 1
			Loop

			If Not personalInfo Is Nothing Then
				NameLabel.Text = "This is the personal page of: " & personalInfo.Name
				PositionLabel.Text = "Position in company: " & personalInfo.Position
				BiographyLabel.Text = "Bigoraphy: " & personalInfo.Biography
				PersonPicture.ImageUrl = personalInfo.Picture
			End If
		End Sub
	End Class
End Namespace
