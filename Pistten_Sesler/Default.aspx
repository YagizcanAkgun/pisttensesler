<%@ Page Title="" Language="C#" MasterPageFile="~/AraYuz.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pistten_Sesler.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Repeater ID="Rp_Makaleler" runat="server">
     <ItemTemplate>
         <article class="Makale">
             <div>
                 <img src="MakaleGorselleri/<%# Eval("KapakResim") %>" style="width: 100%; border: 5px solid #8A8A8A;" />
             </div>
             <div style="margin-top:30px; margin-bottom:10px; color:#345C8C">
                 <h1><%# Eval("Baslik") %></h1>
             </div>
             <div class="KategoriYazar">
                 <label>Kategori : <%# Eval ("KategoriAdi") %> | Yazar : <%#Eval ("Yazar") %> </label>
                 <span>Ekleme Tarihi : <%# Eval("EklemeTarihiStr") %> | Görüntüleme : <%# Eval("GoruntulemeSayi") %></span>
                 <div style="clear: both"></div>
             </div>
             <div style="margin-top:10px;">
                 <%# Eval("Ozet") %>
                 <br />
                 <a href='MakaleDetay.aspx?makaleID=<%# Eval("ID") %>' class="YaziDevam">Yazının Devamı ...</a>
             </div>
         </article>
     </ItemTemplate>
 </asp:Repeater>
</asp:Content>
