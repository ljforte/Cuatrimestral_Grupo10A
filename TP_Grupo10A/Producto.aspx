<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TP_Grupo10A.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="ProductoPage">
            <div class="productos-container">
            <asp:Repeater ID="RepeaterProductos" runat="server">
                <HeaderTemplate>
                    <table class="tablaProductos">
                        <thead>
                            <tr>
                                <th>ProductoID</th>
                                <th>Nombre</th>
                                <th>Descripción</th>
                                <th>Marca</th>
                                <th>Categoría</th>
                                <th>Precio</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ProductoID") %></td>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Descripcion") %></td>
                        <td><%# Eval("MarcaID.Nombre") %></td>
                        <td><%# Eval("CategoriaID.Nombre") %></td>
                        <td><%# Eval("Precio", "{0:C}") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        </main>
</asp:Content>
