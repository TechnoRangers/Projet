﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="LocalisationSaguenayCentreDesCongres.aspx.vb" Inherits="Test_ultime.LocalisationSaguenayCentreDesCongres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
		<script type="text/javascript">
		function initialisation(){
		    var centreCarte = new google.maps.LatLng(48.428839, -71.068821);
		var optionsCarte = {
			zoom: 15,
			center: centreCarte
		}
		var maCarte = new google.maps.Map(document.getElementById("carte"), optionsCarte);
		var myMarker = new google.maps.Marker({
			position: centreCarte,
			map: maCarte,
			title: "Nouvhotel Saguenay-Centre des congrès"
			});
		}
	
		google.maps.event.addDomListener(window, 'load', initialisation)
		</script>

    <div id="carte">
        
    </div>

    <div class="InfosLocalisation"></div>
    <div class="ContenuLocalisation">
        <hr style="color:#eab522" />
        <h1 class="TitreLocalisation">Localisation</h1>
        <hr style="color:#eab522" /><br />
        <p class="ParagrapheLocalisation">Situé au centre de Saguenay sur la principale artère commerciale de la ville,
             on retrouve à proximité de l’hôtel les principaux centres commerciaux de Saguenay, une multitude d’autres
             commerces, restaurants et institutions publiques, le parc industriel, l’université, le cégep, ainsi qu’un bon
             nombre d’installations sportives.</p>
        <asp:Label ID="LblAdresse" runat="server" CssClass="lblCoordo"></asp:Label><br /><br />
        <ul>
            <li class="lblAdresse">Téléphone : <asp:Label ID="NoTelephone" runat="server" CssClass="lblCoordo"></asp:Label></li>
            <li class="lblAdresse">Réservation : <asp:Label ID="NoReservation" runat="server" CssClass="lblCoordo"></asp:Label></li>
            <li class="lblAdresse">Télécopieur : <asp:Label ID="NoTélécopieur" runat="server" CssClass="lblCoordo"></asp:Label></li>
        </ul>
    </div>
</asp:Content>
