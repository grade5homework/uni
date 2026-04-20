using System;
using System.Linq;
using Martsinovsky1.Models;

namespace Martsinovsky1
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Product> GetProducts()
        {
            var _db = new ProductContext();
            IQueryable<Product> query = _db.Products;

            string raw = Request.QueryString["id"];
            int categoryId;
            if (int.TryParse(raw, out categoryId) && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }

            return query;
        }
    }
}