using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebStore.Domain.Entities
{
    public class BrandType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandTypeEID { get; set; }

        [Required(ErrorMessage = "The max length of Caption field is 100 characters!")]
        [MaxLength(100)]
        public string Caption { get; set; }

    }
}
