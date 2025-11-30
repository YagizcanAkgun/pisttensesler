<%@ Page Title="" Language="C#" MasterPageFile="~/AraYuz.Master" AutoEventWireup="true" CodeBehind="GirisYap.aspx.cs" Inherits="Pistten_Sesler.GirisYap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="GirisTasiyici Golge">
        <div style="text-align:center;">
            <img src="Assets/SayfaGörselleri/SID_FB_001.gif" style="width:70%"/>
        </div>
        <div class="Satir">
            <label>Mail Adresiniz</label><br />
            <asp:TextBox ID="Tb_Mail" runat="server" CssClass="MetinKutu" placeholder="ornek@ornek.com"></asp:TextBox>
        </div>
        <div class="Satir">
            <label>Şifreniz</label><br />
            <asp:TextBox ID="Tb_Sifre" runat="server" CssClass="MetinKutu" TextMode="Password" placeholder="********"></asp:TextBox>
        </div>
        <div class="Satir" style="text-align:center">
            <a href="#">Şifremi Unuttum</a>
        </div>
        <div class="Satir">
            <asp:Button ID="Lbtn_Giris" runat="server" CssClass="Buton" Text="Giriş Yap" OnClick="Lbtn_Giris_Click"/>
        </div>
    </div>
</asp:Content>
