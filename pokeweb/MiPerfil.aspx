<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="pokeweb.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validator {
        color: red;
        font-size: 20px;
        }
    </style>

    <script>
        function validar() {
            const txtApellidoPerfil = document.getElementById("txtApellidoPerfil");
            if (txtApellidoPerfil.value == "") {
                txtApellidoPerfil.classList.add("is-invalid")  //Clases de bootstrap de validacion
                return false
            }
            txtApellidoPerfil.classList.remove("is-invalid")
            return true
        }
    </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mi perfil!!</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmailPerfil" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombrePerfil" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validator" ErrorMessage="El Nombre es requerido" ControlToValidate="txtNombrePerfil" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellidoPerfil" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                <%-- ClientIDMODE: static: para que el ID permanezca igual en el html en el navegador--%>

              <%--  <asp:RangeValidator ErrorMessage="Fuera de Rango" ControlToValidate="txtApellidoPerfil" 
                    Type="Integer" MinimumValue="1" MaximumValue="20"                    
                    runat="server" />--%>
 
              <%--  <asp:RegularExpressionValidator ErrorMessage="Solo Numeros!" ControlToValidate="txtApellidoPerfil" 
                    ValidationExpression="^[0-9]+$" runat="server" />--%>

            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFecNacPerfil" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                 <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imageNuevoPerfil" CssClass="img-fluid mb-3" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/2/2c/Default_pfp.svg" runat="server" />

        </div>
    </div>
    <asp:Button ID="btnGuardarPerfil" runat="server" Text="Guardar"
        OnClientClick="return validar()"
        OnClick="btnGuardarPerfil_Click" CssClass="btn btn-primary" />
    <a href="/">Cancelar</a>
</asp:Content>
