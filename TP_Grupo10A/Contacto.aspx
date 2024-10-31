<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TP_Grupo10A.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <div class="row">

            <form>
                <div class="col-md-9">
                    
                        <h4>Contacto</h4>
                        <p>Envíanos tu consulta o comentario y te responderemos a la brevedad.</p>

                        <div >
                            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" CssClass="form-label">Nombre</asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" Required="true"></asp:TextBox>
                        </div>
                        <div >
                            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label">Email</asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" TextMode="Email" Required="true"></asp:TextBox>
                        </div>
                        <div >
                            <asp:Label ID="lblTelefono" runat="server" AssociatedControlID="txtTelefono" CssClass="form-label">Teléfono</asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Teléfono" TextMode="Phone" Required="true"></asp:TextBox>
                        </div>
                        <div >
                            <asp:Label ID="lblMensaje" runat="server" AssociatedControlID="txtMensaje" CssClass="form-label">Mensaje</asp:Label>
                            <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" Placeholder="Mensaje" TextMode="MultiLine" Required="true"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />


                    
                </div>
            </form>

            <div class="col-md-3">
                <ul class="list-group">
                    <li class="list-group-item">
                        <span><i class="fab fa-whatsapp"></i>WhatsApp</span>
                        <a class="nav-link" href="https://web.whatsapp.com/">
                            <p>+54 9 11 1234-4567</p>
                        </a>

                    </li>
                    <li class="list-group-item">
                        <span><i class="fas fa-phone"></i>Atención al cliente</span>
                        <a class="nav-link" href="https://web.whatsapp.com/">
                            <p>+54 9 11 1234-4567</p>
                        </a>
                    </li>
                    <li class="list-group-item">
                        <span><i class="far fa-envelope"></i>Asesoramiento</span>
                        <p>support@fbe.com.ar</p>
                    </li>
                    <li class="list-group-item">
                        <span><i class="fas fa-map-marker-alt"></i>Ubicación</span>
                        <p>
                            Av. Hipólito Yrigoyen 288 - Gral. Pacheco (Tigre)
                        </p>
                    </li>
                    <li class="list-group-item">
                        <span><i class="far fa-clock"></i>Horarios de atención</span>
                        <p>Lunes a Viernes: 09.30 hs a 18.30 hs</p>
                    </li>
                </ul>
            </div>
        </div>
    </main>
</asp:Content>
