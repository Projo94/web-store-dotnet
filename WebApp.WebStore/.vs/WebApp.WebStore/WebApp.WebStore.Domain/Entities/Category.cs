using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebStore.Domain.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "The max length of Caption field is 100 characters!")]
        [MaxLength(100)]
        public string Caption { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }

    }
}


