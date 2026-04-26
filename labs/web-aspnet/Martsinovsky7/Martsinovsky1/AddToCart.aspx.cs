using System;
using System.Diagnostics;
using System.Web.UI;
using Martsinovsky1.Logic;

namespace Martsinovsky1
{
    public partial class AddToCart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["productID"];
            int productId;

            if (!string.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(productId);
                }
            }
            else
            {
                Debug.Fail("Ошибка : AddToCart.aspx без ProductID.");
                throw new Exception("Ошибка: AddToCart.aspx без ProductID запрещена.");
            }

            Response.Redirect("ShoppingCart.aspx");
        }
    }
}