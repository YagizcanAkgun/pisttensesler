<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" AutoEventWireup="true" CodeBehind="YorumListeleme.aspx.cs" Inherits="Pistten_Sesler.Yonetici_Panel.YorumListeleme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormTasiyici">
    <div class="FormBaslik">
        <h3>Yorumlar</h3>
    </div>
    <div class="FormIcerik">
        <asp:ListView ID="Lv_Yorumlar" runat="server" OnItemCommand="Lv_Yorumlar_ItemCommand">
            <LayoutTemplate>
                <table class="Liste" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Yorum No</th>
                            <th>Kullanıcı</th>
                            <th>Yorum</th>
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
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Uye") %></td>
                    <td><%# Eval("Icerik") %></td>
                    <td><%# Eval("YayinlaStr") %></td>
                    <td>
                        <asp:LinkButton ID="Lbtn_DurumDegistir" runat="server"
                            CssClass="ListeButon Durum"
                            CommandName="DurumDegistir"
                            CommandArgument='<%# Eval("ID") %>'>
                            Durum Değiştir
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>

        </asp:ListView>

    </div>

</div>
</asp:Content>
