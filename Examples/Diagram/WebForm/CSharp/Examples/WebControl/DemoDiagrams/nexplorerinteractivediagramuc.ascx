<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NExplorerInteractiveDiagramUC" CodeFile="NExplorerInteractiveDiagramUC.ascx.cs" %>

<cc1:NDrawingView id="NDrawingView1" runat="server" Width="650px" Height="650px" AjaxEnabled="True" OnQueryAjaxTools="NDrawingView1_QueryAjaxTools" OnAsyncClick="NDrawingView1_AsyncClick"></cc1:NDrawingView>
