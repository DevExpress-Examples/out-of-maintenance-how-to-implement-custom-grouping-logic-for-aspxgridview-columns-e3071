<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">

		<asp:AccessDataSource ID="AccessDataSource1" runat="server" 
			DataFile="~/App_Data/nwind.mdb" 
			SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice], [Discontinued] FROM [Products]">
		</asp:AccessDataSource>


		<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
			DataSourceID="AccessDataSource1" KeyFieldName="ProductID" 
			OnCustomColumnGroup="ASPxGridView1_CustomColumnGroup" 
			OnCustomColumnSort="ASPxGridView1_CustomColumnSort" 
			OnCustomGroupDisplayText="ASPxGridView1_CustomGroupDisplayText">

			<GroupSummary>
				<dx:ASPxSummaryItem SummaryType="Count" />
			</GroupSummary>

			<Columns>
				<dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" 
					VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
				</dx:GridViewDataTextColumn>

				<dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="2" 
					GroupIndex="0" SortIndex="0" SortOrder="Ascending">
					<PropertiesTextEdit DisplayFormatString="c">
					</PropertiesTextEdit>
					<Settings AllowDragDrop="False" SortMode="Custom" />
				</dx:GridViewDataTextColumn>

				<dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="3">
				</dx:GridViewDataCheckColumn>
			</Columns>

			<Settings ShowGroupedColumns="True" ShowGroupPanel="True" />
		</dx:ASPxGridView>

	</form>
</body>
</html>