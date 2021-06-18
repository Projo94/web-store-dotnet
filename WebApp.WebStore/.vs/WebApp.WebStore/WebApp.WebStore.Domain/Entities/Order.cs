using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApp.WebStore.Domain.Common;

namespace WebApp.WebStore.Domain.Entities
{
    public class Order : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uid { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public double TotalPrice { get; set; }

        [Required]
        public DateTime CreateDateUtc { get; set; }

        [IgnoreDataMember]
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
