<%@ Page Title="Se connecter" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="Test_ultime.Login" Async="true" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2 class="TitreLogin">Bienvenue sur l'intranet de NOUVHOTEL</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Connectez-vous pour accéder à votre dossier et horaires.</h4>
                    <hr />
                           
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Identifiant</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="Le champ d’adresse de messagerie est obligatoire." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Mot de passe</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Le champ mot de passe est requis." />
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Se connecter" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                   <!-- <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Inscrire comme nouvel utilisateur</asp:HyperLink> /-->
                </p>
                <p>
                    <%-- Activez ceci une fois que vous avez activé la confirmation de votre compte pour la fonctionnalité de réinitialisation du mot de passe
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Vous avez oublié votre mot de passe ? </asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

     <div class="blocmessage">
         <h1 class="titrebloc">Communiqués</h1>
         <div class="message1">
             <h1 class="titremessage"><asp:Label runat="server" ID="TitreMessage1"></asp:Label></h1>
             <h2 class="datemessage"><asp:Label runat="server" ID="DateMessage1"></asp:Label></h2>
             <p class="message"><asp:Label runat="server" ID="Message1"></asp:Label></p>
         </div>
         <hr />
         <div class="message1">
             <h1 class="titremessage"><asp:Label runat="server" ID="TitreMessage2"></asp:Label></h1>
             <h2 class="datemessage"><asp:Label runat="server" ID="DateMessage2"></asp:Label></h2>
             <p class="message"><asp:Label runat="server" ID="Message2"></asp:Label></p>
         </div>
     </div>

    </div>
</asp:Content>
