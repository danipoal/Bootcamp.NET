<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="PrimerEjemplo.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div class="row">
            <div>
                    <div class="form-group">
                        <label>Usuario</label>
                        <asp:TextBox ID="userTextb" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Password</label>
                        <asp:TextBox type="password" ID="passwordTextb" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="log" runat="server" Text="Button" OnClick="log_Click" />
            </div>
        </div>
    </main>
</asp:Content>
