using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApp.WebStore.Domain.Common;

namespace WebApp.WebStore.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemID { get; set; }

        [IgnoreDataMember]
        [ForeignKey("Uid")]
        public Order Order { get; set; }
        [IgnoreDataMember]
        public Guid Uid { get; set; }

        [IgnoreDataMember]
        [ForeignKey("Uid")]
        public Product Product { get; set; }

        [IgnoreDataMember]
        public Guid ProductID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public double PricePerUnit { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
