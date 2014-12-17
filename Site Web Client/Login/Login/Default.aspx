<%-- **************************************************************************************** 
Cr��e le : 10 novembre 2014
Par : Fran�ois Morin
Date de derni�re modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Accueil" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Login._Default" %>

<asp:Content style="width: 100%;" runat="server" ContentPlaceHolderID="slidercontent">
    <script src="//code.jquery.com/jquery-latest.min.js"></script>
    <script src="Scripts/unslider.js"></script>

    <script>
        $(function () {
            if (window.chrome) {
                $('.banner li').css('background-size', '100% 100%');
            }
            $('.banner').unslider({

                speed: 500,
                delay: 5000,
                complete: function () { },
                keys: true,
                dots: true,
                fluid: true
            });
        });
    </script>

    <div class="banner">
        <ul>
            <li style="background-image: url('Images/Slider/piscine.jpg');">
                <div class="backgrounddivh1">
                    <h1 style="padding-left:2%;">Nouvh�tel</h1>
                </div>
            </li>
            <li style="background-image: url('Images/Slider/granderoue.jpg');">
                <div class="backgrounddivh1">
                    <h1 style="padding-left:2%;">Nouvh�tel</h1>
                </div>
            </li>
            <li style="background-image: url('Images/Slider/pewpew.jpg');">
                <div class="backgrounddivh1">
                    <h1 style="padding-left:2%;">Nouvh�tel</h1>
                </div>
            </li>
            <li style="background-image: url('Images/Slider/borddeplage.jpg');">
                <div class="backgrounddivh1">
                    <h1 style="padding-left:2%;">Nouvh�tel</h1>
                </div>
            </li>
            <li style="background-image: url('Images/Slider/chaise.jpg');">
                <div class="backgrounddivh1">
                    <h1>Nouvh�tel</h1>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="row">

        <div class="col-md-3">

            <asp:Image ID="Image1" runat="server" ImageUrl="~\Images\Accueil\AccueilHotel.jpg" Width="300" Height="144" BorderStyle="None" />

            <h2>D�couvrez nos h�tels</h2>
            <p>
                Nouvh�tel offre de nombreuses destinations de r�ve dans diff�rent h�tels � travers le Canada.
            </p>
            <p>
                <a class="btn btn-default" href="RechercheChambre.aspx">En savoir plus &raquo;</a>
            </p>
        </div>
        <div class="col-md-offset-1 col-md-3">
            <asp:Image ID="Image2" runat="server" ImageUrl="~\Images\Accueil\AccueilChambre.jpg" Width="300" Height="144" BorderStyle="None" />
            <h2>Visitez nos chambre</h2>
            <p>
                D�couvrez l'ameublement, les types de lits et les services offerts aux chambres, et ce, dans tout nos h�tels.
            </p>
            <p>
                <a class="btn btn-default" href="TypesChambre.aspx">En savoir plus &raquo;</a>
            </p>
        </div>

        <div class="col-md-offset-1 col-md-3">
            <asp:Image ID="Image3" runat="server" ImageUrl="~\Images\Accueil\AccueilLobby.jpg" Width="300" Height="144" BorderStyle="None" />
            <h2>R�servez d�s aujourd'hui</h2>
            <p>
                R�servez une chambre en ligne ou par t�l�phone. Disponible � toute heure 7 jours sur 7.
            </p>
            <p>
                <a class="btn btn-default" href="Contact.aspx">En savoir plus &raquo;</a>
            </p>
        </div>
    </div>

    <div class="row">
        <div class="jumbotron">
            <h2>S'inscrire</h2>
            <p>
                R�server une chambre en ligne n'a jamais �t� aussi facile ! Cr�er un compte en quelques clics et commencez � planifier votre prochain s�jour.
            </p>
            <p>
                <a class="btn btn-primary btn-lg" href="Account\Register.aspx">En savoir plus &raquo;</a>
            </p>

        </div>
    </div>

</asp:Content>
