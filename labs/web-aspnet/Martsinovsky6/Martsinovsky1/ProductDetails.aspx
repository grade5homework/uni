<%@ Page Title="Описание продукта" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Martsinovsky1.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server"
        ItemType="Martsinovsky1.Models.Product"
        SelectMethod="GetProduct"
        RenderOuterTable="false">

        <ItemTemplate>
            <div>
                <h1><%#: Item.ProductName %></h1>
            </div>

            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <br />

            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#: Item.ImagePath %>"
                             style="border:solid; height:300px"
                             alt="<%#: Item.ProductName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align:left;">
                        <b>Description:</b><br />
                        <%#: Item.Description %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#: Item.ProductID %></span>
                        <br />
                        <a href="/AddToCart.aspx?productID=<%#: Item.ProductID %>">
    <span class="ProductListItem">
        <b>Добавить в корзину</b>
    </span>
</a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>