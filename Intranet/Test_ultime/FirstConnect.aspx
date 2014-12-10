<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FirstConnect.aspx.vb" Inherits="Test_ultime.FirstConnect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Première connexion</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2><strong>Première connexion</strong></h2>
        <p>C'est votre première connexion sur l'intranet.<br />
             Veuillez enregistrer un nouvel identifiant et un nouveau mot de passe.</p>
        <p><asp:Label runat="server" ID="lblIdentifiant" Text="Identifiant : "></asp:Label><asp:TextBox runat="server" CssClass="NewID" ID ="txtBoxId"></asp:TextBox></p>
        <asp:RegularExpressionValidator ID="ValidationID" ForeColor="red" ControlToValidate="txtBoxId" Display="Dynamic" ErrorMessage="L'identifiant doit contenir 7 caractères" runat="server" ValidationExpression="^[a-zA-Z0-9_]{7}$" ></asp:RegularExpressionValidator>
        <p><asp:Label runat="server" ID="lblMDP" Text="Mot de passe : "></asp:Label><asp:TextBox runat ="server" ID="txtBoxMDP"></asp:TextBox></p>
        <asp:RegularExpressionValidator ID="ValidationMDP" ForeColor="red" ControlToValidate="txtBoxMDP" Display="Dynamic" ErrorMessage="Le mot de passe doit contenir 7 caractères en minuscules et commencé par une lettre" runat="server" ValidationExpression="^[a-z]{1}[a-z0-9]{6}$" ></asp:RegularExpressionValidator>
        <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer" />
    </div>
    </form>
</body>
</html>
