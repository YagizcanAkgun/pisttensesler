<%@ Page Title="" Language="C#" MasterPageFile="~/AraYuz.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="Pistten_Sesler.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="Makale">
        <div>
            <asp:Image ID="Img_Resim" runat="server" Style="width: 100%; border: 5px solid #8A8A8A;" />
        </div>
        <div style="margin-top: 30px; margin-bottom: 10px">
            <h1 style="color:#345C8C">
                <asp:Label ID="Lbl_Baslik" runat="server"></asp:Label>
            </h1>
        </div>
        <div class="KategoriYazar">
            <label>
                Kategori :
                <asp:Literal ID="Ltrl_kategori" runat="server"></asp:Literal>
                | 
                Yazar :
                <asp:Literal ID="Ltrl_yazar" runat="server"></asp:Literal>
            </label>
            <span>Ekleme Tarihi :<asp:Literal ID="Ltrl_eklemeTarihi" runat="server"></asp:Literal>
                |
                Görüntüleme :
                <asp:Literal ID="Ltrl_GorntulemeSayi" runat="server"></asp:Literal></span>
            <div style="clear: both"></div>
        </div>
        <div style="margin-top: 10px; text-align: justify">
            <asp:Literal ID="Lbl_Icerik" runat="server"></asp:Literal>
        </div>
    </article>
    <div class="YorumTasiyici">
        <div class="YorumBaslik">
            <h3>Yorumlar</h3>
        </div>
        <div class="YorumIcerik">
            <asp:Panel ID="Pnl_Basarili" runat="server" CssClass="BasariliPanel" Visible="false">
                <label>Yorum Başarıyla Eklenmiştir. Admin onayından sonra yayınlanacaktır</label>
            </asp:Panel>
            <asp:Panel ID="Pnl_Basarisiz" runat="server" CssClass="BasarisizPanel" Visible="false">
                <asp:Label ID="Lbl_Mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Pnl_GirisVar" runat="server" Visible="false">
                <div class="YorumSatir">
                    <label>Yorum Yazınız</label><br />
                    <asp:TextBox ID="Tb_Yorum" runat="server" TextMode="MultiLine" CssClass="YorumMetinKutu"></asp:TextBox>
                </div>
                <div class="YorumSatir">
                    <asp:Button ID="Btn_YorumYap" runat="server" OnClick="Btn_YorumYap_Click" CssClass="Buton" Text="Yorum Yap" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Pnl_GirisYok" runat="server">
                Yorum yapabilmek İçin Lütfen <a href="GirisYap.aspx" class="GirisYapLink">Giriş Yapınız </a>
            </asp:Panel>
        </div>
    </div>
    <div class="Yorumlar">
        <asp:Repeater ID="Rp_Yorumlar" runat="server">
            <ItemTemplate>
                <label><%# Eval("Uye") %></label> | <label><%# Eval("TarihStr") %></label><br />
                <%# Eval("Icerik") %>
                <hr style="margin:10px 0;" />
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="Pnl_YorumYok" runat="server">
            <h4>Bu makaleye henüz yorum yapılmamış</h4>
        </asp:Panel>
    </div>
</asp:Content>
