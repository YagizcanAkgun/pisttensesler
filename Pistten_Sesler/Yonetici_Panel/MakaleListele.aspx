<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Makaleler</h3>
        </div>
        <div class="FormIcerik">
            <asp:ListView ID="Lv_Makaleler" runat="server" OnItemCommand ="Lv_Makaleler_ItemCommand">
                <LayoutTemplate>
                    <table class="Liste" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Resim</th>
                                <th>No</th>
                                <th>Başlık</th>
                                <th>Kategori</th>
                                <th>Yazar</th>
                                <th>Görüntüleme Sayı</th>
                                <th>Ekeleme Tarihi</th>
                                <th>Durum</th>
                                <th>Seçenekler</th>
                            </tr>
                        </thead>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center">
                            <img src='../MakaleGorselleri/<%# Eval("KapakResim") %>' width="80" />
                        </td>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Baslik") %></td>
                        <td><%# Eval("KategoriAdi") %></td>
                        <td><%# Eval("Yazar") %></td>
                        <td><%# Eval("GoruntulemeSayi") %></td>
                        <td><%# Eval("EklemeTarihi") %></td>
                        <td><%# Eval("AktifMiStr") %></td>
                        <td>
                            <asp:LinkButton ID="Lbtn_DurumDegistir" runat="server" CssClass="ListeButon Durum" CommandName="DurumDegistir" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                            <a href='MakaleDuzenle.aspx?MakaleID=<%# Eval("ID") %>' class="ListeButon Duzenle">Düzenle</a>
                            <asp:LinkButton ID="Lbtn_Sil" runat="server" CssClass="ListeButon Sil" CommandName ="Sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
