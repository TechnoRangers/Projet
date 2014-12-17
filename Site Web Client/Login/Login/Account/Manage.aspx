<%-- **************************************************************************************** 
Cr��e le : 10 novembre 2014
Par : Fran�ois Morin
Date de derni�re modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="G�rer le compte" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manage.aspx.vb" Inherits="Login.Manage" %>

<%@ Import Namespace="Login" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceHolder" Visible="false" ViewStateMode="Disabled">
            <p class="text-danger"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">

            <section id="informationsForm">
                <asp:PlaceHolder runat="server" ID="modifInfo" Visible="true">
                    <p>Vous �tes connect� en tant que <strong><%: User.Identity.GetUserName() %></strong>.</p>
                    <div class="form-horizontal">
                        <h4>Modifier les informations du compte</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />

                        <%--Nom--%>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1" AssociatedControlID="txtNom" CssClass="col-md-2 control-label">Nom</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtNom" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNom"
                                    CssClass="text-danger" ErrorMessage="Le champ de nom est obligatoire." />
                            </div>
                        </div>

                        <%--Prenom--%>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label2" AssociatedControlID="txtPrenom" CssClass="col-md-2 control-label">Prenom</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtPrenom" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrenom"
                                    CssClass="text-danger" ErrorMessage="Le champ de pr�nom est obligatoire." />
                            </div>
                        </div>

                        <%--Telephone--%>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label3" AssociatedControlID="txtNoTelephone" CssClass="col-md-2 control-label">Num�ro de t�l�phone</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtNoTelephone" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNoTelephone"
                                    CssClass="text-danger" ErrorMessage="Le champ de num�ro de t�l�phone est obligatoire." />
                            </div>
                        </div>

                        <%--Cellulaire--%>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label4" AssociatedControlID="txtCellulaire" CssClass="col-md-2 control-label">Num�ro de cellulaire</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtCellulaire" CssClass="form-control" />
                            </div>
                        </div>
                        <br />

                        <%--Adresse1--%>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label5" AssociatedControlID="txtAdresse1" CssClass="col-md-2 control-label">Adresse 1</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtAdresse1" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAdresse1"
                                    CssClass="text-danger" ErrorMessage="Le champ d'adresse est obligatoire." />
                            </div>
                        </div>

                        <%--Adresse2--%>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label6" AssociatedControlID="txtAdresse2" CssClass="col-md-2 control-label">Adresse 2</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtAdresse2" CssClass="form-control" />
                            </div>
                        </div>
                        <br />

                        <%--Email--%>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label7" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                                    CssClass="text-danger" ErrorMessage="Le champ d'email est obligatoire." />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button ID="btnModifInfos" runat="server" Text="Modifier les infos" CssClass="btn btn-default" />
                            </div>
                        </div>
                        <hr />
                    </div>
                </asp:PlaceHolder>
            </section>


            <section id="passwordForm">
                <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                    <p>
                        Vous ne poss�dez pas de mot de passe local pour ce site. Ajoutez un mot de passe
                        local pour pouvoir vous connecter sans ID de connexion externe.
                    </p>
                    <div class="form-horizontal">
                        <h4>Formulaire de d�finition de mot de passe</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Mot de passe</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                    CssClass="text-danger" ErrorMessage="Le champ mot de passe est requis."
                                    Display="Dynamic" ValidationGroup="SetPassword" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="col-md-2 control-label">Confirmer le mot de passe�</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Le champ confirmer le mot de passe est requis."
                                    ValidationGroup="SetPassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Le mot de passe et le mot de passe de confirmation ne correspondent pas."
                                    ValidationGroup="SetPassword" />

                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="D�finir le mot de passe" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                    <div class="form-horizontal">
                        <h4>Changer le mot de passe</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Mot de passe actuel</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="text-danger" ErrorMessage="Le champ de mot de passe est requis."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">Nouveau mot de passe</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Le nouveau mot de passe est requis."
                                    ValidationGroup="ChangePassword" />
                                <asp:RegularExpressionValidator CssClass="text-danger" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Le mot de passe doit contenir 7 caract�res sans majuscule, ne doit pas commencer pas un chiffre et ne doit pas contenir de caract�re sp�cial." ControlToValidate="NewPassword" ValidationExpression="\b[a-z](([0-9]|[a-z]){6})\b">       
                                </asp:RegularExpressionValidator>     
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-2 control-label">Confirmer le nouveau mot de passe</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="La confirmation du nouveau mot de passe est requise."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Modifier le mot de passe" OnClick="ChangePassword_Click" CssClass="btn btn-default" CausesValidation="true"/>
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>

            <%--<section id="externalLoginsForm" hidden="hidden">

                <asp:ListView runat="server"
                    ItemType="Microsoft.AspNet.Identity.UserLoginInfo"
                    SelectMethod="GetLogins" DeleteMethod="RemoveLogin" DataKeyNames="LoginProvider,ProviderKey">

                    <LayoutTemplate>
                        <h4>Connexions inscrites</h4>
                        <table class="table">
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.LoginProvider %></td>
                            <td>
                                <asp:Button runat="server" Text="Supprimer" CommandName="Delete" CausesValidation="false"
                                    ToolTip='<%# "Supprimer cette " + Item.LoginProvider + " connexion de votre compte" %>'
                                    Visible="<%# CanRemoveExternalLogins %>" CssClass="btn btn-default" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

                <uc:OpenAuthProviders runat="server" ReturnUrl="~/Account/Manage" />
            </section>--%>
        </div>
    </div>
</asp:Content>

