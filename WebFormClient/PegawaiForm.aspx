<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PegawaiForm.aspx.cs" Inherits="WebFormClient.PegawaiForm" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button Text="Get Pegawai" runat="server" ID="btnGet" OnClick="btnGet_Click" />
    <asp:Label ID="lblPegawai" runat="server" />
    <asp:GridView runat="server" ID="gvPegawai">
    </asp:GridView>
</asp:Content>
