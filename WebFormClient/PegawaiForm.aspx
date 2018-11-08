<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PegawaiForm.aspx.cs" Inherits="WebFormClient.PegawaiForm" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTimer" runat="server" /><br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Masukan Nip :
            <asp:TextBox runat="server" ID="txtNip" /><br />
            Masukan Nama :
            <asp:TextBox runat="server" ID="txtNama" /><br />
            Masukan Email :
            <asp:TextBox runat="server" ID="txtEmail" /><br />
            Masukan Telp :
            <asp:TextBox runat="server" ID="txtTelp" /><br />
            Masukan Umur : 
            <asp:TextBox runat="server" ID="txtUmur" /><br />

            <asp:Button Text="Get Pegawai" runat="server" ID="btnGet" OnClick="btnGet_Click" />
            <asp:Button Text="Get By Nip" ID="btnGetByNip" runat="server" OnClick="btnGetByNip_Click" />
            <asp:Button Text="Add Pegawai" ID="btnAdd" runat="server" OnClick="btnAdd_Click" />
            <asp:Button Text="Update Pegawai" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" />
            <asp:Button Text="Delete" ID="btnDelete" runat="server" OnClick="btnDelete_Click" />
            <asp:Label ID="lblPegawai" runat="server" />
            <asp:GridView runat="server" ID="gvPegawai">
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
