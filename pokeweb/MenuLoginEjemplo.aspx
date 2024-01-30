<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuLoginEjemplo.aspx.cs" Inherits="pokeweb.MenuLoginEjemplo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Menu Login</h1>
    <div class="row">
        <div class="col-12">
            <h3>Te logueaste correctamente</h3>
            <hr />
        </div>
    </div>

    <div class="col-4">
        <asp:Button runat="server" Text="Pagina 1" ID="btnPagina1" OnClick="btnPagina1_Click" CssClass="btn btn-primary" />
    </div>



    <div class="col-4">
        <%--NO QUIERO QUE APAREZCA ESTO SI EL USER NO ES ADMIN--%>
        <%if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
            { %>

        <asp:Button runat="server" Text="Pagina 2" ID="btnPagina2" OnClick="btnPagina2_Click" CssClass="btn btn-primary" />
        <p>Tenes que ser admin</p>

        <% } %>
    </div>


</asp:Content>
