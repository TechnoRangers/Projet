<%-- **************************************************************************************** 
Cr��e le : 10 novembre 2014
Par : Fran�ois Morin
Date de derni�re modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Se connecter" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="Login.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Connectez-vous � votre compte en ligne.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Messagerie</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="Le champ d�adresse de messagerie est obligatoire." />
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
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Inscrire comme nouvel utilisateur</asp:HyperLink>
                </p>
                <p>
                    <%-- Activez ceci une fois que vous avez activ� la confirmation de votre compte pour la fonctionnalit� de r�initialisation du mot de passe
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Vous avez oubli� votre mot de passe ? </asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <h4>Inscrivez-vous d�s aujourd'hui</h4>
                <hr />
                <p>
                    Utiliser votre compte en ligne pour
                   r�server une chambre en quelques clics.
                    Si vous avez d�j� r�serv� dans l'un
                    de nos h�tel, vous pouvez utiliser votre
                    compte client qui existe d�j�.     
                </p>
            </section>
        </div>
    </div>
</asp:Content>
