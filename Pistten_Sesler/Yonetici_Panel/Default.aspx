<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici_Panel/Site1.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
    Inherits="Pistten_Sesler.Yonetici_Panel.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Counts">
        <div class="CountBox">
            <h3><asp:Label ID="Lbl_CategoryCount" runat="server">0</asp:Label></h3>
            adet kategori
        </div>
        <div class="CountBox">
            <h3><asp:Label ID="Lbl_ArthicleCount" runat="server">0</asp:Label></h3>
            adet makale
        </div>
        <div class="CountBox">
            <h3><asp:Label ID="Lbl_MemberCount" runat="server">0</asp:Label></h3>
            adet üye
        </div>
        <div class="CountBox">
            <h3><asp:Label ID="Lbl_CommentCount" runat="server">0</asp:Label></h3>
            adet yorum
        </div>
        <div style="clear:both"></div>
    </div>
    <div style="width:100%; overflow:hidden; margin-top:25px;">
        <div class="FormTasiyici" style="width:48%; float:left;">
            <div class="FormBaslik">
                <h3>Son 5 Yorum</h3>
            </div>
            <div class="FormIcerik">
                <asp:ListView ID="Lv_SonYorumlar" runat="server">
                    <LayoutTemplate>
                        <table class="Liste" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Kullanıcı</th>
                                    <th>Yorum</th>
                                    <th>Tarih</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Uye") %></td>
                            <td><%# Eval("Icerik") %></td>
                            <td><%# Eval("Tarih", "{0:dd.MM.yyyy HH:mm}") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
        <div class="FormTasiyici" style="width:48%; float:right;">
            <div class="FormBaslik">
                <h3>Son 5 Üye</h3>
            </div>
            <div class="FormIcerik">
                <asp:ListView ID="Lv_SonUyeler" runat="server">
                    <LayoutTemplate>
                        <table class="Liste" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Ad Soyad</th>
                                    <th>Kullanıcı Adı</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("ID") %></td>
                            <td><%# Eval("Isim") %> <%# Eval("Soyisim") %></td>
                            <td><%# Eval("KullaniciAdi") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
        <div style="clear:both;"></div>
    </div>
</asp:Content>
