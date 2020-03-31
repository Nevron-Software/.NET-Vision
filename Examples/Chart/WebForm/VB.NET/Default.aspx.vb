Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public Partial Class _Default
	Inherits System.Web.UI.Page
	Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
		'render the frames

		Dim themeName As String = TryCast(Application("themeName"), String)
		Dim hrefLink As String = "Themes/" & themeName & "/Styles.css"

		writer.WriteLine("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Frameset//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd"">")
		writer.WriteLine("<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""en"" lang=""en"">")
		writer.WriteLine("<head>")
		writer.WriteLine("<meta http-equiv=""Content-Type"" content=""application/xhtml+xml; charset=Utf-8"" />")
		writer.WriteLine("<meta http-equiv=""Content-Language"" content=""en"" />")
		writer.WriteLine("<meta http-equiv=""Content-Style-Type"" content=""text/css"" />")
		writer.WriteLine("<meta http-equiv=""Content-Script-Type"" content=""javascript1.2"" />")
		writer.WriteLine("<title>" & PageTitle & "</title>")
		writer.WriteLine("<link href='" & hrefLink & "' rel='stylesheet' />")
		writer.WriteLine("</head>")

		' Root frame begin
		writer.WriteLine("<frameset cols='*,1050px,*' framespacing='0' frameBorder = '0' >")
		writer.WriteLine("<frame name='left' border='0'>")
		' Root frame begin

		writer.WriteLine("<frameset rows='87px, *, 20px' framespacing='0' frameBorder = '0' >")
		writer.WriteLine("	<frame src='Frames/TopBanner.aspx' name='BannerFrame' noresize='noresize' frameborder='0' scrolling='no' style='height:87px' />")
		writer.WriteLine("	<frameset cols='304, *' framespacing='0' frameBorder = '0'>")
		writer.WriteLine("		<frame src='Frames/NNavigationFrame.aspx' name='NavigationFrame' noresize='noresize' frameborder='0' scrolling='no'  />")
		writer.WriteLine("		<frame src='Frames/NExampleFrame.aspx' name='ExampleViewFrame' noresize='noresize' frameborder='0' scrolling='no' />")
		writer.WriteLine("	</frameset>")
		writer.WriteLine("	<frame src='Frames/Footer.aspx' name='FooterFrame' noresize='noresize' frameborder='0' scrolling='no'  />")
		writer.WriteLine("</frameset>")

		' Root frame end
		writer.WriteLine("<frame name='right' frameBorder = '0'>")
		writer.WriteLine("</frameset>")
		' Root frame end

		writer.WriteLine("</html>")
	End Sub

	#Region "Fields"

	Public PageTitle As String = "Nevron Web Examples"

	#End Region
End Class

