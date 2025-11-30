<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Kategori Düzenle</h3>

        </div>
        <div class="FormIcerik">
            <asp:Panel ID="Pnl_Basarili" runat="server" class="BasariliPanel" Visible="false">
                <label>Kategori düzenleme işlemi <b> başarıyla </b> gerçekleşti </label>
            </asp:Panel>
            <asp:Panel ID="Pnl_Basarisiz" runat="server" CssClass="BasarisizPanel" Visible="false">
                <asp:Label ID="Lbl_HataMesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="Satir">
                <label class="Etiket">Kategori Adı</label><br />
                <asp:TextBox ID="Tb_Isim" runat="server" CssClass="MetinKutu" placeholder="Lütfen Boş Bırakmayınız" MaxLength="25"></asp:TextBox>
            </div>
            <div class="Satir">
                <asp:CheckBox ID="Cb_Durum" runat="server" Text="Aktif Kategori" CssClass="SecimKutu" />
            </div>
            <div class="Satir">
                <asp:Button ID="Btn_KategoriDuzenle" runat="server" Text="Kategori Düzenle" CssClass="Buton" OnClick="btn_kategoriDuzenle_Click" />
            </div>
        </div>
    </div>
</asp:Content>
