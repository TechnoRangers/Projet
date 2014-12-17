<%-- **************************************************************************************** 
Cr��e le : 10 novembre 2014
Par : Fran�ois Morin
Date de derni�re modification : 2014-12-15 12:28:48 
****************************************************************************************************** --%>
<%@ Page Title="Types de chambre" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TypesChambre.aspx.vb" Inherits="Login.TypesChambre" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script src="Scripts/lightbox.min.js"></script>
    <link href="Content/lightbox.css" rel="stylesheet" />

    <div class="jumbotron backgradient">
        <h2><strong>Nos types de chambre</strong></h2>
        <p>Trouvez le type de chambre qui convient le mieux pour votre s�jour. Nos type de chambre sont standard dans tous nos h�tels ce qui vous permettra d'avoir la m�me exp�rience partout.</p>
        <p><a href="RechercheChambre.aspx" class="btn btn-primary btn-lg">R�server &raquo;</a></p>
    </div>

    <%-- Panel Chambre Standard --%>
    <div class="panel panel-default">
        <div class="panel-heading">Chambre standard</div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-10">
                    <h1 class="gradient">Standard</h1>
                    <p>Retrouvez le confort d�sir� pour un prix plus qu'abordable.</p>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend class="gradient">Informations</legend>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li><strong>Dimensions :</strong> Environ 375 pieds carr�es / 35 m�tres carr�es</li>
                            <li><strong>Orientation :</strong> Vari�e</li>
                            <li><strong>Emplacement :</strong> Dans tout l'h�tel</li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li><strong>Nombre de lits : </strong>De 1 � 2</li>
                            <li><strong>Ce type de chambre est disponible dans tous les h�tels de la cha�ne.</strong></li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="row">
                <br />
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend class="gradient">Fournitures et services</legend>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li>Peignoir</li>
                            <li>2 t�l�phones</li>
                            <li>T�l�vision LCD</li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li>Mini r�frig�rateur</li>
                            <li>Acc�s Internet haute vitesse sans-fil</li>
                            <li>D�jeuner servi au lit</li>
                        </ul>
                    </div>

                </div>
            </div>

            <script>
                $(document).ready(function () {
                    $("#flip").click(function () {
                        $("#panel").slideToggle("slow");
                        return false;
                        e.preventDefault();
                    });
                });
            </script>

            <%-- Bouton slider images --%>
            <div class="row">
                <div class="col-md-12">
                    <div class="list-group">
                        <a href="#" class="btn btn-success btn-lg btn-block" id="flip">
                            <h4>Galerie</h4>
                        </a>
                        <div class="well" id="panel" style="display: none;">
                            <div class="row">
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/STD/ChambreSTD.jpg" data-lightbox="Standard" data-title="Lit standard">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~\Images\TypeChambre\STD\ChambreSTD.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/STD/LitSTD.jpg" data-lightbox="Standard" data-title="2 lits standard">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~\Images\TypeChambre\STD\LitSTD.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/STD/Lit2STD.jpg" data-lightbox="Standard" data-title="Lit standard">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~\Images\TypeChambre\STD\Lit2STD.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/STD/EvierSTD.jpg" data-lightbox="Standard" data-title="�vier standard">
                                        <asp:Image ID="Image4" runat="server" ImageUrl="~\Images\TypeChambre\STD\EvierSTD.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/STD/DoucheSTD.jpg" data-lightbox="Standard" data-title="Douche standard">
                                        <asp:Image ID="Image5" runat="server" ImageUrl="~\Images\TypeChambre\STD\DoucheSTD.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/STD/BainSTD.jpg" data-lightbox="Standard" data-title="Bain standard">
                                        <asp:Image ID="Image6" runat="server" ImageUrl="~\Images\TypeChambre\STD\BainSTD.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="progress">
        <div class="progress-bar progress-bar-info" style="width: 100%"></div>
    </div>

    <%-- Panel Chambre Deluxe --%>
    <div class="panel panel-default">
        <div class="panel-heading">Chambre deluxe</div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-10">
                    <h1 class="gradient">Deluxe</h1>
                    <p>Confort sup�rieur pour la meilleure exp�rience possible.</p>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend class="gradient">Informations</legend>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li><strong>Dimensions :</strong> Environ 487 pieds carr�es / 45 m�tres carr�es</li>
                            <li><strong>Orientation :</strong> Vari�e</li>
                            <li><strong>Emplacement :</strong> Dans tout l'h�tel</li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li><strong>Nombre de lits : </strong>De 1 � 2</li>
                            <li><strong>Ce type de chambre est disponible dans tous les h�tels de la cha�ne.</strong></li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="row">
                <br />
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend class="gradient">Fournitures et services</legend>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li>Ordinateur</li>
                            <li>2 t�l�phones</li>
                            <li>T�l�vision LCD</li>
                            <li>Foyer au gas</li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li>Mini r�frig�rateur</li>
                            <li>Acc�s Internet haute vitesse sans-fil</li>
                            <li>Bain tourbillon</li>
                            <li>Caf� gratuit servi aux chambres</li>
                        </ul>
                    </div>
                </div>
            </div>

            <script>
                $(document).ready(function () {
                    $("#flip1").click(function () {
                        $("#panel1").slideToggle("slow");
                        return false;
                        e.preventDefault();
                    });
                });
            </script>

            <%-- Bouton slider images --%>
            <div class="row">
                <div class="col-md-12">
                    <div class="list-group">
                        <a href="#" class="btn btn-success btn-lg btn-block" id="flip1">
                            <h4>Galerie</h4>
                        </a>
                        <div class="well" id="panel1" style="display: none;">
                            <div class="row">
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/LUX/ChambreLUX.jpg" data-lightbox="Deluxe" data-title="Lit deluxe">
                                        <asp:Image ID="Image7" runat="server" ImageUrl="~\Images\TypeChambre\LUX\ChambreLUX.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/LUX/LitLUX.jpg" data-lightbox="Deluxe" data-title="2 lits deluxe">
                                        <asp:Image ID="Image8" runat="server" ImageUrl="~\Images\TypeChambre\LUX\LitLUX.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/LUX/Lit2LUX.jpg" data-lightbox="Deluxe" data-title="Lit deluxe">
                                        <asp:Image ID="Image9" runat="server" ImageUrl="~\Images\TypeChambre\LUX\Lit2LUX.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/LUX/Lit3LUX.jpg" data-lightbox="Deluxe" data-title="Lit deluxe">
                                        <asp:Image ID="Image10" runat="server" ImageUrl="~\Images\TypeChambre\LUX\Lit3LUX.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/LUX/Lit4LUX.jpg" data-lightbox="Deluxe" data-title="Lit deluxe">
                                        <asp:Image ID="Image11" runat="server" ImageUrl="~\Images\TypeChambre\LUX\Lit4LUX.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/LUX/DoucheLUX.jpg" data-lightbox="Deluxe" data-title="Douche deluxe">
                                        <asp:Image ID="Image12" runat="server" ImageUrl="~\Images\TypeChambre\LUX\DoucheLUX.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="progress">
        <div class="progress-bar progress-bar-info" style="width: 100%"></div>
    </div>

    <%-- Panel Chambre Suite --%>
    <div class="panel panel-default">
        <div class="panel-heading">Suite</div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-10">
                    <h1 class="gradient">Suite</h1>
                    <p>Grand espaces pour vous offrir une exp�rience m�morable.</p>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend class="gradient">Informations</legend>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li><strong>Dimensions :</strong> Environ 450-500 pieds carr�es / 41-46 m�tres carr�es</li>
                            <li><strong>Orientation :</strong> Vue exceptionnelle</li>
                            <li><strong>Emplacement :</strong> 2e et 3e �tage</li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li><strong>Nombre de lits : </strong>De 1 � 5</li>
                            <li><strong>Consulter nos h�tels pour savoir si il est possible de r�server une suite</strong></li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="row">
                <br />
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend class="gradient">Fournitures et services</legend>
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li>Ordinateur</li>
                            <li>2 t�l�phones</li>
                            <li>T�l�vision ACL de 37 po</li>
                            <li>Foyer au gas</li>
                            <li>Acc�s terrace</li>
                            <li>Articles de toilette</li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="col-md-10">
                        <ul>
                            <li>Coffre fort</li>
                            <li>Mini-r�frig�rateur</li>
                            <li>Acc�s Internet haute vitesse sans-fil</li>
                            <li>Bain tourbillon</li>
                            <li>Douche de plein-pied</li>
                            <li>Caf� gratuit servi aux chambres</li>
                        </ul>
                    </div>
                </div>
            </div>

            <script>
                $(document).ready(function () {
                    $("#flip2").click(function () {
                        $("#panel2").slideToggle("slow");
                        return false;
                        e.preventDefault();
                    });
                });
            </script>

            <%-- Bouton slider images --%>
            <div class="row">
                <div class="col-md-12">
                    <div class="list-group">
                        <a href="#" class="btn btn-success btn-lg btn-block" id="flip2">
                            <h4>Galerie</h4>
                        </a>
                        <div class="well" id="panel2" style="display: none;">
                            <div class="row">
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/SUI/ChambreSUI.jpg" data-lightbox="Suite" data-title="Lit suite">
                                        <asp:Image ID="Image13" runat="server" ImageUrl="~\Images\TypeChambre\SUI\ChambreSUI.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/SUI/LitSUI.jpg" data-lightbox="Suite" data-title="2 lits suite">
                                        <asp:Image ID="Image14" runat="server" ImageUrl="~\Images\TypeChambre\SUI\LitSUI.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/SUI/FireplaceSUI.jpg" data-lightbox="Suite" data-title="Salon suite">
                                        <asp:Image ID="Image15" runat="server" ImageUrl="~\Images\TypeChambre\SUI\FireplaceSUI.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/SUI/WalkInSUI.jpg" data-lightbox="Suite" data-title="Walk-in suite">
                                        <asp:Image ID="Image16" runat="server" ImageUrl="~\Images\TypeChambre\SUI\WalkInSUI.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/SUI/EvierSUI.jpg" data-lightbox="Suite" data-title="�vier suite">
                                        <asp:Image ID="Image17" runat="server" ImageUrl="~\Images\TypeChambre\SUI\EvierSUI.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                                <div class="col-md-4" style="overflow:hidden;">
                                    <a href="Images/TypeChambre/SUI/BainSUI.jpg" data-lightbox="Suite" data-title="Bain suite">
                                        <asp:Image ID="Image18" runat="server" ImageUrl="~\Images\TypeChambre\SUI\BainSUI.jpg" CssClass="clickimage" Width="300" Height="144" BorderStyle="None" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
