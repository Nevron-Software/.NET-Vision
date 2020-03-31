<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStandardShapeUC" CodeFile="NStandardShapeUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:Label id="Label1" runat="server">Shape style:</asp:Label>
		<br />
		<asp:DropDownList id="ShapeStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="UseXValueCheckBox" runat="server" Text="Use X Value" Checked="True" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="UseZValueCheckBox" runat="server" Text="Use Z Value" Checked="True" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="DifferentColorsCheckBox" runat="server" Text="Different colors" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Shapes color:</asp:Label>
		<br />
		<asp:DropDownList id="ShapesColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Projection:</asp:Label>
		<br />
		<asp:DropDownList id="ProjectionDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		General Shape Series Functionality
		<br />
		<br />
		The Shape Series is a versatile rendering series with which you can display a 
		large set of shapes with user defined centers and dimensions in the chart area.<br />
		<br />
		- Shape Style combo controls the shape style of all shapes<br />
		- The Use X Values and Use Z Values check control whether the series must use 
		automatic or user defined center x and z coordinates<br />
		- When the Different Colors check is checked the shapes are displayed in 
		different colors<br />
		- The Shapes Color combo controls the color applied on all shapes<br />
		- The size limit combo boxes control the limit of the largest random value 
		generated for the x, y and z sizes respectively.<br />
		-The Projection combo controls the applied projection.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->