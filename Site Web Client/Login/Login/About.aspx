<%-- **************************************************************************************** 
Cr��e le : 10 novembre 2014
Par : Fran�ois Morin
Date de derni�re modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="Login.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h1>� propos de Nouvh�tel</h1>
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>Nouvh�tel : l�histoire d�une r�ussite dans l�industrie canadienne de la gestion h�teli�re</h2>
        </div>
        
        <br />

        <div class="col-md-5">
            <asp:Image ID="Image3" runat="server" ImageUrl="~\Images\About\HotelAbout.jpg" Width="425" Height="235" BorderStyle="None" />
        </div>

        <div class="col-md-7">
            <blockquote class="pull-left">
                Lors de sa fondation � Richmond, en Colombie-Britannique, en 1962, Nouvh�tel ne comptait � son actif qu�un seul h�tel-motel de 62 chambres. Aujourd�hui, c�est la plus importante soci�t� de gestion d�h�tels de premi�re classe au Canada.
                Notre entreprise se targue maintenant d�un portefeuille de plus de 40 h�tels urbains, a�roportuaires et de vill�giature et est consid�r�e comme �tant la marque de choix par les propri�taires et clients avertis, un employeur exemplaire pour plus de 6 000 personnes et 
                une soci�t� vivement consciente de ses responsabilit�s sociales, d'un oc�an � l'autre.
            </blockquote>
        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <h2>Une tradition de leadership et de vision</h2>
        </div>
        
        <br />

        <div class="col-md-7">
            <blockquote class="pull-left">
                Le leadership et la vision sont des traits qui marquent l�histoire de la soci�t�. Apr�s �tre devenue la principale entreprise h�teli�re de la Colombie-Britannique en 1970, Nouvh�tel a entrepris un ambitieux projet d�expansion vers l�est du pays.
                En 1975, elle a inaugur� le Nouvh�tel Chelsea au centre-ville de Toronto. Comptant 1 590 chambres, cet h�tel est non seulement le plus vaste de Nouvh�tel, mais aussi de l�ensemble du Canada. Delta a ajout� des h�tels � son portefeuille pendant les ann�es 80, notamment au Canada
                Atlantique et au Qu�bec. Malgr� un changement de main en 1987, le rythme rapide des projets d�expansion et de revitalisation s�est maintenu tout au long des ann�es 90.
            </blockquote>
        </div>

        <div class="col-md-5">
            <asp:Image ID="Image2" runat="server" ImageUrl="~\Images\About\HotelFire.jpg" Width="425" Height="235" BorderStyle="None" />
        </div>

    </div>

    <br />

    <div class="row">
        <div class="col-md-12">
            <h2>Au-del� des salaires et des avantages sociaux</h2>
        </div>
        
        <br />

        <div class="col-md-5">
            <asp:Image ID="Image1" runat="server" ImageUrl="~\Images\About\HotelPerson.jpg" Width="425" Height="235" BorderStyle="None" />
        </div>

        <div class="col-md-7">
            <blockquote class="pull-left">
                Reconnue pour les garanties progressives qu�elle fait � ses employ�s, Nouvh�tel continue d�afficher l�un des taux de roulement les plus faibles de l�industrie h�teli�re. Nous offrons �galement un programme d�assistance aux employ�s et
                aux familles, ainsi que d�innombrables possibilit�s de carri�re. Le prestigieux Institut national de la qualit� (INQ) a aussi conf�r� deux Prix Canada pour l�excellence � Nouvh�tel, soit l�un dans la cat�gorie Qualit� (2000) et l�autre dans la cat�gorie Milieu
                de travail sain (2004). C��tait la premi�re fois de l�histoire de l�INQ qu�une entreprise h�teli�re m�ritait ces honneurs. Comparable au Malcolm Baldridge National Quality Award des �tats-Unis, le prix de l�INQ est le plus important � �tre remis aux organismes 
                canadiens qui excellent dans les domaines du leadership, du rendement, de la planification et des activit�s ax�es sur les clients, les employ�s et les fournisseurs.
            </blockquote>
        </div>
    </div>

</asp:Content>
