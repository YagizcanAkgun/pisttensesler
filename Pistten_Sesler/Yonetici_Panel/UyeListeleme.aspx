<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" AutoEventWireup="true" CodeBehind="UyeListeleme.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
        <div class="FormBaslik">
            <h3>Üyeler</h3>
        </div>
        <div class="FormIcerik">
            <asp:ListView ID="Lv_Uyeler" runat="server" OnItemCommand="Lv_Uyeler_ItemCommand">
                <LayoutTemplate>
                    <table class="Liste" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>İsim</th>
                                <th>Soyisim</th>
                                <th>Kullanıcı Adı</th>
                                <th>Mail</th>
                                <th>Durum</th>
                                <th>Seçenekler</th>
                            </tr>
                        </thead>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("Soyisim") %></td>
                        <td><%# Eval("KullaniciAdi") %></td>
                        <td><%# Eval("Mail") %></td>
                        <td><%# Eval("AktifMiStr") %></td>
                        <td>
                            <asp:LinkButton ID="Lbtn_DurumDegistir" runat="server" CssClass="ListeButon Durum"
                                CommandName="DurumDegistir" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>

