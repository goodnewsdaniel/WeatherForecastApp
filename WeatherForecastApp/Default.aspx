<%@ Page  Title="Weather Forecast App" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WeatherForecastApp._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Enter Location to Check Weather Condition:</h3>
    <div class="row justify-content-center"> 
        <asp:TextBox ID="SearchTextBox" runat="server" Font-Size="Smaller" Width="302px" AutoPostBack="True" OnTextChanged="SearchTextBox_TextChanged" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SearchTextBox" CssClass="field-validation-error" ErrorMessage="Location name is required for the operation." />
        <asp:DropDownList ID="NoOfDaysDropDownList" runat="server" Height="29px" Width="100px">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div> 
        <asp:Button ID="SearchLocation" runat="server" Text="Search Location" Font-Size="Smaller" OnClick="SearchLocationButton_Click" />
         <asp:Button ID="DisplayWeatherForecastButton" runat="server" Text="Display Weather Forecast" Font-Size="Smaller" OnClick="DisplayWeatherForecastButton_Click" />
         <asp:Button ID="DisplayTidalDataButton" runat="server" Font-Size="Smaller" Text="Display Tidal Data" OnClick="DisplayTidalDataButton_Click" />
         <asp:Button ID="DisplayHistoricalDataButton" runat="server" Font-Size="Smaller" Text="Display Historical Data" OnClick="DisplayHistoricalDataButton_Click" />
    </div>
            <div>
                <asp:TextBox ID="DisplayResultsTextBox" runat="server" Height="147px" TextMode="MultiLine" Width="838px" Font-Size="Smaller" />
            </div>
</asp:Content>
