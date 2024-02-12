<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokeweb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Logueate!</h2>
    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox ID="txtEmailLogin" runat="server" placeholder="ejemplo@gmail.com" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox ID="txtPasswordLogin" runat="server" placeholder="********" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
        <a href="/">Cancelar</a>

    </div>



</asp:Content>
