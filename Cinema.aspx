<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cinema.aspx.cs" Inherits="DataBaseEserci.Cinema" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblNome" runat="server" Text="Nome"></asp:Label>
             <asp:TextBox ID="TxtNome" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LblCognome" runat="server" Text="Cognome"></asp:Label>
             <asp:TextBox ID="TxtCognome" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LblSala" runat="server" Text="Sala: "></asp:Label>
            <asp:RadioButtonList ID="RdbSala" runat="server">
                <asp:ListItem Value="nord" >Nord</asp:ListItem>
                <asp:ListItem Value="est" >Est</asp:ListItem>
                <asp:ListItem Value="sud" >Sud</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="LblBiglietto" runat="server" Text="Biglietto: "></asp:Label>
            <asp:RadioButtonList ID="RdbBiglietto" runat="server">
                <asp:ListItem Value="ridotto" >Ridotto</asp:ListItem>
                <asp:ListItem Value="intero" >Intero</asp:ListItem>
            </asp:RadioButtonList>
            <br />

            <asp:Button ID="BtnCompro" runat="server" Text="Compra" OnClick="BtnCompro_Click" />

            <br /> 

            <h1>Biglietti Venduti</h1>

            <div>
                Sala Nord: 
   
                <asp:Label ID="LblNord" runat="server" Text="Label"></asp:Label>
                <br />
                Sala Est:
   
                <asp:Label ID="LblEst" runat="server" Text="Label"></asp:Label>
                <br />
                Sala Sud: 
   
                <asp:Label ID="LblSud" runat="server" Text="Label"></asp:Label>
                <br />


                Spettatori:
                <asp:Label ID="LblNomi" runat="server" Text=""></asp:Label>
               
            </div>
        </div>
    </form>
</body>
</html>
