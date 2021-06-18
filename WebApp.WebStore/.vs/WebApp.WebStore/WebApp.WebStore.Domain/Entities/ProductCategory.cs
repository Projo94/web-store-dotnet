using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebStore.Domain.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {

        }


        public ProductCategory(Guid productID, int categoryID)
        {
            ProductID = productID;
            CategoryID = categoryID;
        }

        [ForeignKey("Product"), Column(Order = 0)]
        public Guid ProductID { get; set; }

        public virtual Product Product { get; set; }


        [ForeignKey("Category"), Column(Order = 1)]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
