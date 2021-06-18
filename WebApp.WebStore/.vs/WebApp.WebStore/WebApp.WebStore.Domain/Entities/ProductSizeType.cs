using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebStore.Domain.Entities
{
    public class ProductSizeType
    {
        public ProductSizeType()
        {

        }


        public ProductSizeType(Guid productID, int sizeTypeID)
        {
            ProductID = productID;
            SizeTypeID = sizeTypeID;
        }


        [Key, ForeignKey("Product"), Column(Order = 0)]
        public Guid ProductID { get; set; }

        public virtual Product Product { get; set; }

        [Key, ForeignKey("SizeType"), Column(Order = 1)]
        public int SizeTypeID { get; set; }

        public virtual SizeType SizeType { get; set; }


    }
}
