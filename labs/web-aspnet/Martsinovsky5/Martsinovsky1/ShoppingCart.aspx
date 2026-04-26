<%@ Page Title="Выбранные товары" Language="C#"
    MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ShoppingCart.aspx.cs"
    Inherits="Martsinovsky1.ShoppingCart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead">
        <h1>Корзина</h1>
    </div>

    <hgroup><h2><%: Page.Title %></h2></hgroup>

    <asp:GridView ID="CartList" runat="server"
        AutoGenerateColumns="False" ShowFooter="True"
        GridLines="Vertical" CellPadding="4"
        ItemType="Martsinovsky1.Models.CartItem"
        SelectMethod="GetShoppingCartItems"
        CssClass="table table-striped table-bordered">

        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />
            <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />
            <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)"
                            DataFormatString="{0:c}" />

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server"
                                 Text="<%#: Item.Quantity %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Item Total">
                <ItemTemplate>
                    <%#: String.Format("{0:c}",
                        ((Convert.ToDouble(Item.Quantity)) * Convert.ToDouble(Item.Product.UnitPrice))) %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Remove Item">
                <ItemTemplate>
                    <asp:CheckBox ID="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong>
    </div>

    <br />

    <table>
        <tr>
            <td>
                <asp:Button ID="UpdateBtn" runat="server" Text="Обновить" OnClick="UpdateBtn_Click" />
            </td>
            <td>
                <!-- Место под Checkout, если понадобится -->
            </td>
        </tr>
    </table>
</asp:Content>