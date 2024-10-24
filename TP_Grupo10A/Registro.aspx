<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_Grupo10A.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <style>
       .custom-width {
           max-width: 600px; 
           width: 100%;
       }

       body {
           background-image: url('/Imagenes/FondoRegistro.jpg');
           background-size: cover;
           background-position: center;
           background-repeat: no-repeat;
           color:white;
       }

       .custom2-width {
           max-width: 400px; 
           width: 100%;
       }

        .txt-color {
       background-color: #393737; 
   }
           .txt-color option:checked {
       background-color: #007bff; 
       color: white; 
   }
   </style>

   <br />
   <div>
   <h3>¡Registrate completando los siguientes datos!</h3>
   </div>
   <br />


   <div class="container">

       <div class="row g-3">
           <div class="col-md-4">
               <label for="txtNombre" class="form-label">Nombre</label>
               <asp:TextBox ID="txtNombre" CssClass="form-control custom2-width txt-color" runat="server"></asp:TextBox>
           </div>

           <div class="col-md-4">
               <label for="txtApellido" class="form-label">Apellido</label>
               <asp:TextBox ID="txtApellido" CssClass="form-control custom2-width txt-color" runat="server"></asp:TextBox>
           </div>
       </div>
       <br />

       <div class="row g-3">
           <div class="col-md-5">
               <label for="txtEmail" class="form-label">Email</label>
               <asp:TextBox ID="txtEmail" CssClass="form-control custom-width txt-color" type="email" runat="server"></asp:TextBox>
           </div>

           <div class="col-md-5">
               <label for="Genero" class="form-label">Género</label>
               <asp:DropDownList ID="DropDownList1" CssClass="form-select txt-color" runat="server">
                   <asp:ListItem Text="Seleccione una opción" Value="0" Selected="True" />
                   <asp:ListItem Text="Hombre" Value="1" />
                   <asp:ListItem Text="Mujer" Value="2" />
                   <asp:ListItem Text="Otro" Value="3" />
               </asp:DropDownList>
           </div>
       </div>
       <br />

       <div class="row g-3">
           <div class="col-12">
               <label for="txtDireccion" class="form-label">Dirección</label>
               <asp:TextBox ID="txtDireccion" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
           </div>
       </div>
       <br />
       <div class="row g-3">
           <div class="col-md-6">
               <label for="txtCiudad" class="form-label">Ciudad</label>
               <asp:TextBox ID="txtCiudad" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
           </div>
           <br />

           <div class="col-md-2">
               <label for="CP" class="form-label">Código Postal</label>
               <asp:TextBox ID="txtCP" CssClass="form-control custom-width txt-color" runat="server"></asp:TextBox>
           </div>
       </div>
       <br />

       <div class="row g-3">
           <div class="col-12">
               <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="btn btn-primary" />
           </div>
       </div>
   </div>



</asp:Content>
