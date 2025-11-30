<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Yönetici Giriş Sayfası</title>
    <link href ="Assets/Css/GirisStyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class ="AnaTasiyici Golge">
            <div class="Sol">
                
            </div>
            <div class="Sag">
                <div class ="Baslik">
                    <h2>Yönetici Giriş</h2>
                    <p>Giriş Yapabilmek İçin Lütfen Bilgilerinizi Giriniz</p>
                </div>
                <div class ="Satir">
                    <asp:TextBox ID="Tb_Mail" runat="server" CssClass="MetinKutu" placeholder="Mail Adresiniz" Text="akgunyagizcan84@gmail.com"></asp:TextBox>
                </div>
                <div class="Satir">
                     <asp:TextBox ID="Tb_Sifre" runat="server" CssClass="MetinKutu" placeholder="Şifreniz" Text="147980"></asp:TextBox>
                </div>
                <div class="Satir">
                    <asp:Button ID="Btn_Giris" runat="server" Text="Giriş Yap" CssClass="Buton" OnClick="Btn_Giris_Click" />
                </div>
                <div class="Satir" style="text-align: center">
                    <a href="#" class="SifremiUnuttum">Şifremi Unuttum</a>
                </div>
                <asp:Panel ID="Pnl_Mesaj" runat="server" CssClass="Mesaj" Visible="false">
                    <asp:Label ID="Lbl_Mesaj" runat="server"></asp:Label>
                </asp:Panel>
            </div>
            <div style="clear: both"></div>
        </div>
    </form>
</body>
</html>
