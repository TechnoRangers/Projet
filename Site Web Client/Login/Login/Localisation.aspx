<%-- **************************************************************************************** 
Cr��e le : 10 novembre 2014
Par : Fran�ois Morin
Date de derni�re modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Localisation" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Localisation.aspx.vb" Inherits="Login.Localisation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-10">
            <h2>Localisation</h2>
            <hr />
        </div>
    </div>

    <div class="row">
        <iframe
            runat="server"
            id="MyMap"
            width="600"
            height="450"
            frameborder="0" style="border: 0"
            src="https://www.google.com/maps/embed/v1/place?key=AIzaSyClJcaaScvorWUw5YMSlohxqFdV_d7vM_s
    &q=Montreal"></iframe>
    </div>

    <br />

    <div class="row">
        <div class="col-md-10">
            <p>
             Situ� au centre de Saguenay sur la principale art�re commerciale de la ville,
             on retrouve � proximit� de l�h�tel les principaux centres commerciaux de Saguenay, une multitude d�autres
             commerces, restaurants et institutions publiques, le parc industriel, l�universit�, le c�gep, ainsi qu�un bon
             nombre d�installations sportives.
            </p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-5">
            <ul>
                <li><strong>Adresse: </strong><asp:Label ID="lblAdresse" runat="server" Text="" /></li>
                <li><strong>T�l�phone: </strong><asp:Label ID="lblTelephone" runat="server" Text="" /></li>
                <li><strong>T�l�phone r�servation: </strong><asp:Label ID="lblNoReservation" runat="server" Text="" /></li>
                <li><strong>T�l�copieur: </strong><asp:Label ID="lblNoTelecopieur" runat="server" Text="" /></li>
            </ul>
        </div>

        <div class="col-md-5">
            <ul>
                <li><strong>Code postal: </strong><asp:Label ID="lblCodePostal" runat="server" Text="" /></li>
                <li><strong>Heure de prise de possesion des chambres: </strong><asp:Label ID="lblHeure1" runat="server" Text="" /></li>
                <li><strong>Heure de d�part: </strong><asp:Label ID="lblHeure2" runat="server" Text="" /></li>
            </ul>
        </div>

    </div>

</asp:Content>
