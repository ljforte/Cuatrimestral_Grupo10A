<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProducto.aspx.cs" Inherits="TP_Grupo10A.AltaProducto" %>

<asp:Content ID="AltaProducto" ContentPlaceHolderID="MainContent" runat="server">
    <form class="row g-3">
        <div class="col-md-6">
            <label for="ingresoNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" CssClass="form-control" Placeholder="Máximo 100 caracteres" />
        </div>
<div class="col-md-4">
    <label for="ingresoMarca" class="form-label">Marca</label>
    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select">
        <asp:ListItem Text="Seleccionar..." Value="" />
    </asp:DropDownList>
</div>
        <div class="col-12">
            <label for="ingresoPrecio" class="form-label">Precio</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Solo ingresa numeros" />
        </div>
        <div class="col-12">
            <label for="ingresoStock" class="form-label">Stock</label>
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" Placeholder="Cantidad" />
        </div>
        <div class="col-md-6">
            <label for="ingresoDescripcion" class="form-label">Descripción</label>
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="255" CssClass="form-control" TextMode="MultiLine" Rows="4" Placeholder="Máximo 255 caracteres" />
        </div>
<div class="col-md-4">
    <label for="ingresoCategoria" class="form-label">Categoría</label>
    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-select">
        <asp:ListItem Text="Choose..." Value="" />
    </asp:DropDownList>
</div>
        <div class="col-md-5">
            <label for="ingresoUrlImagen1" class="form-label">URL Imagen 1</label>
            <asp:TextBox ID="txtUrlImagen1" runat="server" CssClass="form-control" Placeholder="URL de la imagen 1" />
        </div>
        <div class="col-md-5">
            <label for="ingresoUrlImagen2" class="form-label">URL Imagen 2</label>
            <asp:TextBox ID="txtUrlImagen2" runat="server" CssClass="form-control" Placeholder="URL de la imagen 2" />
        </div>
        <div class="col-md-5">
            <label for="ingresoUrlImagen3" class="form-label">URL Imagen 3</label>
            <asp:TextBox ID="txtUrlImagen3" runat="server" CssClass="form-control" Placeholder="URL de la imagen 3" />
        </div>
  <div class="form-check">
    <asp:CheckBox ID="checkBoxIsActive" runat="server" CssClass="form-check-input" Text="Activar codigo" />
      <br>
</div>
  <div class="col-12">
     <asp:Button ID="btnAltaProducto" runat="server" Text="Enviar Alta" CssClass="btn btn-primary" style="margin-top: 70px;" OnClick="btnAltaProducto_Click" />
  </div>
</form>
    
</asp:Content>

