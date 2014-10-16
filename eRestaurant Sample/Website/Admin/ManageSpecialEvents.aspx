<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageSpecialEvents.aspx.cs" Inherits="Admin_SpecialEvents" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="my" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row col-md-12">
        <h1>Manage Special Events <span class ="glyphicon glyphicon-glass"></span></h1>
    </div>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SpecialEventDataSource" InsertItemPosition="LastItem" DataKeyNames="EventCode">

        <EditItemTemplate>
            <div style="">
                <asp:LinkButton runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                &nbsp;&nbsp;
                <asp:LinkButton runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                &nbsp;&nbsp;&nbsp;
                EventCode:
                <asp:TextBox Text='<%# Bind("EventCode") %>' runat="server" ID="EventCodeTextBox" />
                Description:
                <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" />
                <asp:CheckBox Checked='<%# Bind("Active") %>' runat="server" ID="ActiveCheckBox" Text="Active" />
                

                <%--MAKE CHANGES THE SAME AS IN THE INSERT ITEM--%>
                
               
            </div>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <div style="">
                <asp:LinkButton runat="server" CommandName="Insert"  ID="InsertButton" >Insert <span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton runat="server" CommandName="Cancel"  ID="CancelButton" >Clear <span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                &nbsp;&nbsp;&nbsp;

                <asp:CheckBox Checked='<%# Bind("Active") %>' runat="server" ID="ActiveCheckBox" Text="Active" />
                &mdash;

               <asp:Label ID="Label3" runat="server" AssociatedControlID="EventCodeTextBox" CssClass="control-label">Event Code</asp:Label>
               <asp:TextBox Text='<%# Bind("EventCode") %>' runat="server" ID="EventCodeTextBox" />
               
                
                <asp:Label ID="Label4" runat="server" AssociatedControlID="DescriptionTextBox" CssClass="control-label>">Description</asp:Label>
                <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" />
                
               <%-- <asp:Label ID="Label5" runat="server" AssociatedControlID="ReservationsTextBox" CssClass="control-label">Reservation</asp:Label>
                <asp:TextBox Text='<%# Bind("Reservations") %>' runat="server" ID="ReservationsTextBox" />--%>
                
                <br />
            </>
        </InsertItemTemplate>
        <ItemTemplate>
            <div style="">

                <asp:LinkButton runat="server" CommandName="Edit" ID="EditButton">Edit<span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton runat="server" CommandName="Delete" ID="DeleteButton">Delete <span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox Checked='<%# Eval("Active") %>' runat="server" ID="ActiveCheckBox" Enabled="false" Text="Active" />

                &mdash;
                <asp:Label ID="Label11" runat="server" AssociatedControlID="EventCodeLabel" CssClass="control-label">Event Code</asp:Label>
                <asp:Label Text='<%# Eval("EventCode") %>' runat="server" ID="EventCodeLabel" />

                &mdash;
               <asp:Label ID="Label12" runat="server" AssociatedControlID="DescriptionLabel" CssClass="control-label">Description</asp:Label>
                <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" />


            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <fieldset runat="server" id="itemPlaceholderContainer">
                <div runat="server" id="itemPlaceholder" />
            </fieldset>
        </LayoutTemplate>

    </asp:ListView>
    <my:MessageUserControl runat="server" ID="MessageUserControl" />
    <asp:ObjectDataSource runat="server" ID="SpecialEventDataSource" DataObjectTypeName="eRestaurant.Entities.SpecialEvent" DeleteMethod="DeleteSpecialEvent" InsertMethod="AddSpecialEvent" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSpecialEvents" TypeName="eRestaurant.BLL.RestaurantAdminController" UpdateMethod="UpdateSpecialEvent" OnDeleted="ProcessExceptions" OnInserted="ProcessExceptions" OnUpdated="ProcessExceptions"></asp:ObjectDataSource>
</asp:Content>

