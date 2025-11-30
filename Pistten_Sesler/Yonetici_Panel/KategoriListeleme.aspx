<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" AutoEventWireup="true" CodeBehind="KategoriListeleme.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Kategoriler</h3>
        </div>
        <div class="FormIcerik">
            <asp:ListView ID="Lv_Kategoriler" runat="server" OnItemCommand="Lv_Kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table class="Liste" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Kategori No</th>
                                <th>Kategori Adı</th>
                                <th>Durum</th>
                                <th>Seçenekler</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("Isim") %>
                        </td>
                        <td>
                            <%# Eval("DurumStr") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="Lbtn_DurumDegistir" runat="server" CssClass="ListeButon Durum" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                            <a href='KategoriDuzenle.aspx?kategoriID=<%# Eval("ID") %>' class="ListeButon Duzenle">Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
