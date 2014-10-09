<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MenuItemByCategory.aspx.cs" Inherits="Admin_MenuItemByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Menu Item by Menu Category</h1>

    <asp:Label ID="lblMenuCategory" runat="server" Text="Menu Category" AssociatedControlID="Categories"></asp:Label>
    <asp:DropDownList ID="Categories" runat="server" DataSourceID="CategoriesDataSource" DataTextField="Description" DataValueField="MenuCategoryID" AppendDataBoundItems="true">
        <asp:ListItem Value="">Select Category</asp:ListItem>
    </asp:DropDownList>
    <asp:LinkButton ID="LinkButton1" runat="server">Show Items</asp:LinkButton>
    <asp:ObjectDataSource ID="CategoriesDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCategories" TypeName="eRestaurant.BLL.MenuController">
    </asp:ObjectDataSource>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ItemDataSource">
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="CurrentPrice" HeaderText="CurrentPrice" SortExpression="CurrentPrice" />
            <asp:BoundField DataField="CurrentCost" HeaderText="CurrentCost" SortExpression="CurrentCost" />
            <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
            <asp:BoundField DataField="Calories" HeaderText="Calories" SortExpression="Calories" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="Comment" />
            <asp:BoundField DataField="MenuCategoryID" HeaderText="MenuCategoryID" SortExpression="MenuCategoryID" />
        </Columns>
        
    </asp:GridView>
    <asp:ObjectDataSource ID="ItemDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListItembyMenuCategory" TypeName="eRestaurant.BLL.MenuController">
        <SelectParameters>
            <asp:ControlParameter ControlID="Categories" Name="CategID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

