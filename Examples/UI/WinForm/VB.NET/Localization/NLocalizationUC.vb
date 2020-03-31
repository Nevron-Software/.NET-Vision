Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Imports Nevron.Globalization
Imports Nevron.UI.WinForm
Imports Nevron.UI.WinForm.Controls
Imports Nevron.Examples.Framework.WinForm
Imports Nevron.Editors

Namespace Nevron.Examples.UI.WinForm
	''' <summary>
	''' Summary description for NLocalizationUC.
	''' </summary>
	Public Class NLocalizationUC
		Inherits NExampleUserControl
		#Region "Constructor"

		Public Sub New(ByVal f As MainForm)
			MyBase.New(f)
			InitializeComponent()
		End Sub


		#End Region

		#Region "Overrides"

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If

				'NLocalizationManager.Instance.Dictionary = null;
			End If
			MyBase.Dispose(disposing)
		End Sub

		Public Overrides Sub Initialize()
			MyBase.Initialize ()

			InitGermanTranslations()
			InitFrenchTranslations()
		End Sub

		#End Region

		#Region "Implementation"

		Friend Sub InitGermanTranslations()
			m_GermanDictionary = New NDictionary("German")

			m_GermanDictionary.Add("&Restore", "&Restaurieren")
			m_GermanDictionary.Add("&Move", "&Aufregen")
			m_GermanDictionary.Add("&Size", "&Schlichten")
			m_GermanDictionary.Add("Mi&nimize", "Mi&nimieren")
			m_GermanDictionary.Add("Ma&ximize", "Ma&ximieren")
			m_GermanDictionary.Add("&Close", "&Verwachsen")
		End Sub
		Friend Sub InitFrenchTranslations()
			m_FrenchDictionary = New NDictionary("French")

			m_FrenchDictionary.Add("&Restore", "&Restaurer")
			m_FrenchDictionary.Add("&Move", "&Mouvoir")
			m_FrenchDictionary.Add("&Size", "&Ampleur")
			m_FrenchDictionary.Add("Mi&nimize", "Mi&nimiser")
			m_FrenchDictionary.Add("Ma&ximize", "Ma&ximiser")
			m_FrenchDictionary.Add("&Close", "&Fermer")
		End Sub

		#End Region

		#Region "Event Handlers"

		Private Sub germanDictionaryBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles germanDictionaryBtn.Click
			NLocalizationManager.Instance.GlobalDictionary.Clear()
			NLocalizationManager.Instance.GlobalDictionary.CombineWith(m_GermanDictionary)
		End Sub

		Private Sub frenchDictionaryBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles frenchDictionaryBtn.Click
			NLocalizationManager.Instance.GlobalDictionary.Clear()
			NLocalizationManager.Instance.GlobalDictionary.CombineWith(m_FrenchDictionary)
		End Sub

		Private Sub defaultDictionaryBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles defaultDictionaryBtn.Click
			NLocalizationManager.Instance.Clear()
		End Sub
		Private Sub editBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editBtn.Click
			Dim editor As NLocalizationManagerEditor = New NLocalizationManagerEditor()
			editor.ShowDialog()
		End Sub

		#End Region

		#Region "Component Designer generated code"
		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.nRichTextLabel1 = New Nevron.UI.WinForm.Controls.NRichTextLabel()
			Me.germanDictionaryBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.frenchDictionaryBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.defaultDictionaryBtn = New Nevron.UI.WinForm.Controls.NButton()
			Me.editBtn = New Nevron.UI.WinForm.Controls.NButton()
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' nRichTextLabel1
			' 
			Me.nRichTextLabel1.ClientPadding = New Nevron.UI.NPadding(10, 10, 10, 10)
			Me.nRichTextLabel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.nRichTextLabel1.Item.ContentAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.nRichTextLabel1.Item.Style.RichTextFormat = New Nevron.UI.NRichTextFormat(Nevron.GraphicsCore.LineTrimStyle.Word, Nevron.GraphicsCore.ParagraphAlignment.Justify, 0, 0, 0, 0, 0, 0, 0)
			Me.nRichTextLabel1.Location = New System.Drawing.Point(5, 5)
			Me.nRichTextLabel1.Name = "nRichTextLabel1"
			Me.nRichTextLabel1.Size = New System.Drawing.Size(310, 139)
			Me.nRichTextLabel1.StrokeInfo.PenWidth = 3
			Me.nRichTextLabel1.StrokeInfo.Rounding = 5
			Me.nRichTextLabel1.TabIndex = 0
			Me.nRichTextLabel1.Text = "The Nevron <b>NLocalizationManager</b> provides simple yet elegant way for localization of all the internal strings in an application by specifying  custom Dictionaries. The example creates two dictionaries - German and French. Apply the desired dictionary and right-click on the Main Form's caption."
			' 
			' germanDictionaryBtn
			' 
			Me.germanDictionaryBtn.Location = New System.Drawing.Point(8, 192)
			Me.germanDictionaryBtn.Name = "germanDictionaryBtn"
			Me.germanDictionaryBtn.Size = New System.Drawing.Size(176, 32)
			Me.germanDictionaryBtn.TabIndex = 1
			Me.germanDictionaryBtn.Text = "German Dictionary"
'			Me.germanDictionaryBtn.Click += New System.EventHandler(Me.germanDictionaryBtn_Click);
			' 
			' frenchDictionaryBtn
			' 
			Me.frenchDictionaryBtn.Location = New System.Drawing.Point(8, 232)
			Me.frenchDictionaryBtn.Name = "frenchDictionaryBtn"
			Me.frenchDictionaryBtn.Size = New System.Drawing.Size(176, 32)
			Me.frenchDictionaryBtn.TabIndex = 2
			Me.frenchDictionaryBtn.Text = "French Dictionary"
'			Me.frenchDictionaryBtn.Click += New System.EventHandler(Me.frenchDictionaryBtn_Click);
			' 
			' defaultDictionaryBtn
			' 
			Me.defaultDictionaryBtn.Location = New System.Drawing.Point(8, 152)
			Me.defaultDictionaryBtn.Name = "defaultDictionaryBtn"
			Me.defaultDictionaryBtn.Size = New System.Drawing.Size(176, 32)
			Me.defaultDictionaryBtn.TabIndex = 3
			Me.defaultDictionaryBtn.Text = "Default Dictionary"
'			Me.defaultDictionaryBtn.Click += New System.EventHandler(Me.defaultDictionaryBtn_Click);
			' 
			' editBtn
			' 
			Me.editBtn.Location = New System.Drawing.Point(8, 272)
			Me.editBtn.Name = "editBtn"
			Me.editBtn.Size = New System.Drawing.Size(176, 32)
			Me.editBtn.TabIndex = 4
			Me.editBtn.Text = "Edit Localization Manager..."
'			Me.editBtn.Click += New System.EventHandler(Me.editBtn_Click);
			' 
			' NLocalizationUC
			' 
			Me.Controls.Add(Me.editBtn)
			Me.Controls.Add(Me.defaultDictionaryBtn)
			Me.Controls.Add(Me.frenchDictionaryBtn)
			Me.Controls.Add(Me.germanDictionaryBtn)
			Me.Controls.Add(Me.nRichTextLabel1)
			Me.DockPadding.All = 5
			Me.Name = "NLocalizationUC"
			Me.Size = New System.Drawing.Size(320, 312)
			CType(Me.nRichTextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		#Region "Fields"

		Friend m_FrenchDictionary As NDictionary
		Friend m_GermanDictionary As NDictionary

		#End Region

		#Region "Designer Fields"

		Private components As System.ComponentModel.Container = Nothing
		Private nRichTextLabel1 As Nevron.UI.WinForm.Controls.NRichTextLabel
		Private WithEvents germanDictionaryBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents defaultDictionaryBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents editBtn As Nevron.UI.WinForm.Controls.NButton
		Private WithEvents frenchDictionaryBtn As Nevron.UI.WinForm.Controls.NButton

		#End Region
	End Class
End Namespace
