<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Kategori Ekle</h3>
        </div>
        <div class="FormIcerik">
            <asp:Panel ID="Pnl_Basarili" runat="server" class="BasariliPanel" Visible="false">
                <label>Kategori Ekleme İşlemi <b> Başarıyla </b> Gerçekleşti </label>
            </asp:Panel>
            <asp:Panel ID="Pnl_Basarisiz" runat="server" CssClass="BasarisizPanel" Visible="false">
                <asp:Label ID="Lbl_HataMesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="Satir">
                <label class="Etiket">Kategori Adı</label><br />
                <asp:TextBox ID="Tb_Isim" runat="server" CssClass="MetinKutu" placeholder="Lütfen Boş Bırakmayınız"></asp:TextBox>
            </div>
            <div class="Satir">
                <asp:CheckBox ID="Cb_Durum" runat="server" Text="Aktif Kategori" CssClass="SecimKutu" />
            </div>
            <div class="Satir">
                <asp:Button ID="Btn_KategoriEkle" runat="server" Text="Kategori Kaydet" CssClass="Buton" Onclick="Btn_KategoriEkle_Click" />
            </div>
        </div>
    </div>
</asp:Content>
