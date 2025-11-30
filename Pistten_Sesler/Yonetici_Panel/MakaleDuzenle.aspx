<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" AutoEventWireup="true" CodeBehind="MakaleDuzenle.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Makale Ekle</h3>
        </div>
        <div class="FormIcerik">
            <asp:Panel ID="Pnl_Basarili" runat="server" class="BasariliPanel" Visible="false">
                <label>Makale Düzenleme İşlemi <b>Başarıyla </b>Gerçekleşti </label>
            </asp:Panel>
            <asp:Panel ID="Pnl_Basarisiz" runat="server" CssClass="BasarisizPanel" Visible="false">
                <asp:Label ID="Lbl_HataMesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="SolKolon">
                <div class="Satir">
                    <label class="Etiket">Kategori</label><br />
                    <asp:DropDownList ID="Ddl_Kategoriler" runat="server" DataValueField="ID" DataTextField="Isim" CssClass="Dropdown"></asp:DropDownList>
                </div>
                <div class="Satir">
                    <label class="Etiket">Başlık</label><br />
                    <asp:TextBox ID="Tb_Baslik" runat="server" CssClass="MetinKutu"></asp:TextBox>
                </div>
                <div class="Satir">
                    <asp:Image ID="Img_Resim" runat="server" style="width:420px" /><br />
                    <label class="Etiket">Makale Resmi</label><br />
                    <asp:FileUpload ID="Fu_Resim" runat="server" CssClass="MetinKutu" />
                </div>
                <div class="Satir">
                    <asp:CheckBox ID="Cb_AktifMi" runat="server" CssClass="SecimKutu" Text="Makaleyi Yayınla"></asp:CheckBox>
                </div>
                <div class="Satir">
                    <asp:Button ID="Btn_MakaleDuzenle" runat="server" Text="Makale Düzenle" CssClass="Buton" OnClick="Btn_MakaleDuzenle_Click" />
                </div>
            </div>
            <div class="SagKolon">
                <div class="Satir">
                    <label class="Etiket">Özet</label><br />
                    <asp:TextBox ID="Tb_Ozet" runat="server" CssClass="MetinKutu Fullwith" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="Satir">
                    <label class="Etiket">İçerik</label><br />
                    <asp:TextBox ID="Tb_Icerik" runat="server" CssClass="MetinKutu Fullwith" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
    <script>
        CKEDITOR.replace('ContentPlaceHolder1_Tb_Icerik');
    </script>
</asp:Content>
