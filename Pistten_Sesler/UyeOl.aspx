<%@ Page Title="" Language="C#" MasterPageFile="~/AraYuz.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="Pistten_Sesler.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="GirisTasiyici Golge">

        <div style="text-align:center;">
            <img src="Assets/SayfaGörselleri/SID_FB_001.gif" style="width:70%" />
        </div>
        <div class="Satir">
            <label>İsminiz</label><br />
            <asp:TextBox ID="Tb_Isim" runat="server" CssClass="MetinKutu" placeholder="Adınız"></asp:TextBox>
        </div>
        <div class="Satir">
            <label>Soyisminiz</label><br />
            <asp:TextBox ID="Tb_Soyisim" runat="server" CssClass="MetinKutu" placeholder="Soyadınız"></asp:TextBox>
        </div>
        <div class="Satir">
            <label>Kullanıcı Adı</label><br />
            <asp:TextBox ID="Tb_KullaniciAdi" runat="server" CssClass="MetinKutu" placeholder="Kullanıcı adınız"></asp:TextBox>
        </div>
        <div class="Satir">
            <label>Mail Adresiniz</label><br />
            <asp:TextBox ID="Tb_Mail" runat="server" CssClass="MetinKutu" placeholder="ornek@ornek.com"></asp:TextBox>
        </div>
        <div class="Satir">
            <label>Şifreniz</label><br />
            <asp:TextBox ID="Tb_Sifre" runat="server" CssClass="MetinKutu" TextMode="Password" placeholder="********"></asp:TextBox>
        </div>
       
        <div class="Satir" style="text-align:center;">
            <a href="#">Şifremi Unuttum</a>
        </div>
        <div class="Satir">
            <asp:Button ID="Lbtn_Kaydet" runat="server" CssClass="Buton" Text="Kayıt Ol" OnClick="Lbtn_Kaydet_Click" />
        </div>
        <div class="Satir">
            <asp:Panel ID="Pnl_Basarili" runat="server" class="BasariliPanel" Visible="false">
                <label>Kayıt işlemi <b>Başarıyla </b>Gerçekleşti</label>
            </asp:Panel>
            <asp:Panel ID="Pnl_Basarisiz" runat="server" CssClass="BasarisizPanel" Visible="false">
                <asp:Label ID="Lbl_HataMesaj" runat="server"></asp:Label>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
