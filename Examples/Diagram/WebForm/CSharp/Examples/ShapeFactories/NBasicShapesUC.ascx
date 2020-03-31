<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NBasicShapesUC" CodeFile="NBasicShapesUC.ascx.cs" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" summary="Example layout table">
    <tr>
        <td id="exampleImageCell" class="ImageCell">
            <div id="scrollDiv" style="overflow: auto; width: 550px; height: 420px;">
                <!-- Diagram control placeholder BEGIN -->
                <cc1:NDrawingView ID="NDrawingView1" runat="server" Width="550px" Height="420px">
                </cc1:NDrawingView>
                <!-- Diagram control placeholder END -->
            </div>
        </td>
        <td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">
            &nbsp;</td>
        <td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:200px">
            <!-- Configuration controls panel placeholder BEGIN -->
            <asp:Label ID="Label1" runat="server">Shape Size:</asp:Label>
            <br />
            <asp:DropDownList ID="shapeSizeDropDownList" runat="server" AutoPostBack="True">
                <asp:ListItem>Small</asp:ListItem>
                <asp:ListItem Selected="True">Medium</asp:ListItem>
                <asp:ListItem>Large</asp:ListItem>
            </asp:DropDownList>
            <!-- Configuration controls panel placeholder END -->
        </td>
    </tr>
    <tr>
        <td id="exampleDescriptionCell" class="Description">
            <!-- Description box placeholder BEGIN -->
            The example demonstrates how to use the built in shape factories to dynamically
            create new shapes.
            <!-- Description box placeholder END -->
        </td>
    </tr>
</table>
<!-- Example layout END -->
