using System;
using System.Linq;
using Martsinovsky1.Models;

namespace Martsinovsky1
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Product> GetProduct()
        {
            var _db = new ProductContext();
            IQueryable<Product> query = _db.Products;

            string raw = Request.QueryString["productID"];
            int productId;
            if (int.TryParse(raw, out productId) && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }

            return query;
        }
    }
}