<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="TP_Grupo10A.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Gestion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Detalle del pedido</h2>
       <div class="card mb-4">
           <div class="card-header bg-info text-white">
               <h3>Resumen de tu Pedido</h3>
           </div>
           <div class="card-body">
               <p><strong>Nombre:</strong> <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre del Usuario"></asp:Label></p>
               <p><strong>Dirección:</strong> <asp:Label ID="lblDireccionCompleta" runat="server" Text="Dirección Completa"></asp:Label></p>
               <p><strong>Estado del Pedido:</strong> <asp:Label ID="lblEstadoPedido" runat="server" Text="Estado Actual"></asp:Label></p>
           </div>
       </div>

       <h4>Productos Comprados</h4>
       <asp:Repeater ID="rptDetallesPedido" runat="server">
           <ItemTemplate>
               <div class="row mb-3">
                   <div class="col-md-3">
                       <strong><%# Eval("producto.Nombre") %></strong>
                   </div>
                   <div class="col-md-3">
                       <%# Eval("Cantidad") %>
                   </div>

                   <div class="col-md-3">
                       $<%# Eval("PrecioUnitario", "{0:F2}") %>
                   </div>

                   <div class="col-md-3">
                       $<%# 
                   (Convert.ToInt32(Eval("Cantidad")) * Convert.ToSingle(Eval("PrecioUnitario"))).ToString("F2") 
                       %>
                   </div>
               </div>
           </ItemTemplate>
         </asp:Repeater>

       <div class="text-end">
           <h4><strong>Total:</strong> $<asp:Label ID="lblTotalPedido" runat="server" Text="0.00"></asp:Label></h4>
       </div>

       <div class="text-center mt-4">
           <a href="GestionPedidos.aspx" class="btn btn-primary">Volver a Gestion</a>
       </div>
   </div>       
</asp:Content>
