using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.WebStore.Domain.Common;

namespace WebApp.WebStore.Domain.Entities
{
    public class Product : AuditableEntity
    {

        [Key]
        public Guid Uid { get; set; }


        [Required]
        [MaxLength(100)]
        public string Caption { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

        [ForeignKey("BrandTypeEID")]
        public BrandType BrandType { get; set; }

        public int BrandTypeEID { get; set; }


        public virtual ICollection<ProductCategory> ProductCategory { get; set; }

        public virtual ICollection<ProductSizeType> ProductSizeType { get; set; }

    }
}
