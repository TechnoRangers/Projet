<%-- **************************************************************************************** 
Cr��e le : 10 novembre 2014
Par : Fran�ois Morin
Date de derni�re modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="F�licitation" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PostReservation.aspx.vb" Inherits="Login.PostReservation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row"style="background-image: url('Images/banner-confetti.png'); background-repeat: repeat-x;">
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <div class="row">
        <h2><asp:Label ID="lblMessage" runat="server" Text="Ayyy"/></h2>
        <p>Nous vous souhaitons un excellent s�jour !</p>
        <p>Contactez-nous par t�l�phone si vous souhaitez apporter des modifications � votre r�servation.</p> 
    </div>

</asp:Content>
