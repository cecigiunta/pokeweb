<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginEjemplo.aspx.cs" Inherits="pokeweb.LoginEjemplo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">User</label>
            <asp:TextBox ID="txtUser" runat="server" placeholder="username" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" placeholder="********" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnLoguear" runat="server" Text="Ingresar" OnClick="btnLoguear_Click" CssClass="btn btn-primary" />

    </div>
</asp:Content>
