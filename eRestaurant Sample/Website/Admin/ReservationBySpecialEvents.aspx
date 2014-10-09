<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReservationBySpecialEvents.aspx.cs" Inherits="ReservationBySpecialEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   <h1>Reservations By Special Event</h1>

    <asp:Label ID="LblSpecialEvents" runat="server" Text="Special Events" AssociatedControlID="SpecialEvents"></asp:Label>
    <asp:DropDownList ID="SpecialEvents" runat="server" DataSourceID="SpecialEventsDataSource" DataTextField="Description" DataValueField="EventCode" AppendDataBoundItems="true">
        <asp:ListItem Value="">Select an Event</asp:ListItem>
        <asp:ListItem Value="">No Event</asp:ListItem>

    </asp:DropDownList>
    <asp:LinkButton ID="ShowReservations" runat="server">Show Reservations</asp:LinkButton>
    
    <asp:ObjectDataSource ID="SpecialEventsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSpecialEvents" TypeName="eRestaurant.BLL.RestaurantAdminController"></asp:ObjectDataSource>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SpecialEventsDataSource">
        
    </asp:GridView>

</asp:Content>

